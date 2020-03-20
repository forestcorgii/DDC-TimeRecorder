Imports VerilookLib
Imports System.Net
Imports System.Text
Imports System.IO

Public Class frmStream
    Public FaceManager As VerilookManager
    Public UsedUsers As clsUsedUsers
    Public MainForm As frmMain
    Public AllowAuth As Boolean
    Public PendingAuth As Boolean
    Private userReloginTime As Double
    Private Sub frmStream_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.TopMost = True
            Case Keys.F12
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
                Me.TopMost = False
            Case Keys.Escape
                Me.TopMost = False
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Me.WindowState = FormWindowState.Normal
        End Select
    End Sub

    Private Async Sub frmStream_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmClosingAttempt.Enabled = False
        tmCamera2Checking.Enabled = True
        userReloginTime = FaceManager.Settings.Face.UserReloginTime

        AddHandler FaceManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
        If UsedUsers Is Nothing Then
            UsedUsers = New clsUsedUsers
        End If

        Await FaceManager.StartProcess(Me, fvStream, FaceProcessType.Identify)
    End Sub

    Private Sub FaceManager_FaceIdentified(sender As Object, e As VerilookEventArgs) 'Handles FaceManager.FaceIdentified
        If e.Status = Neurotec.Biometrics.NBiometricStatus.Ok Then
            If PendingAuth Then
                MainForm.Invoke(Sub()
                                    If FaceManager.UserRecords.Lookup(e.UserID.Split("_")(0)).Admin Then
                                        AllowAuth = True
                                        MainForm.authButton.PerformClick()
                                    End If
                                End Sub)
            ElseIf Not UsedUsers.Contains(e.UserID.Split("_")(0)) Then
                MainForm.Invoke(Sub()
                                    UsedUsers.Add(New clsUsedUser() With {.ID = e.UserID.Split("_")(0)})
                                    MainForm.addToTimetable(New UserTimeStatus(FaceManager.UserRecords.Lookup(e.UserID.Split("_")(0)), FaceManager.MySQLDatabaseManager))
                                    Programs.splash("Fingerprint Match", e.Score & " - " & e.UserID.Split("_")(0) & " - " & e.ElapseTime.TotalSeconds.ToString("0.00") & " - " & e.Faces, 3)
                                End Sub)
            End If
        End If

        If Me.IsHandleCreated Then
            Me.Invoke(Sub() tmChecker.Enabled = True)
        End If
    End Sub

    Private Sub sendTime()
        Dim w As WebRequest = WebRequest.Create("http://192.168.23.16/lis/functions/timesheet")
        w.Method = "POST"
        '      w.Credentials = New NetworkCredential("Annalyn Montaniel", "yoan0502")
        Dim postData As String = String.Format("authtoken={0}&date={1}&timein={2}&timeout={3}", encrypt("2019-07-18 06:00:00"), "2019-07-18", "2019-07-18 06:00:00", "2019-07-18 15:00:00")
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        w.ContentType = "application/x-www-form-urlencoded"
        w.ContentLength = byteArray.Length

        Dim dataStream As Stream = w.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)

        dataStream.Close()

        Dim response As WebResponse = w.GetResponse()
        Debug.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()

        Dim reader As New StreamReader(dataStream)

        Dim responseFromServer As String = reader.ReadToEnd()
        
        Debug.WriteLine(responseFromServer)

        reader.Close()
        dataStream.Close()
        response.Close()
    End Sub

    Private Function encrypt(val As String) As String
        Dim newVal As String = ""
        For i As Integer = 0 To val.Length - 1
            Dim v As String = val(i)
            If Char.IsNumber(v) Then
                newVal &= Chr(Asc(val(i)) + CInt(v))
            Else
                newVal &= Chr(Asc(val(i)) + 3)
            End If
        Next
        Return newVal
    End Function

    Private Sub frmStream_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not closeForm Then
            RemoveHandler FaceManager.FaceIdentified, AddressOf FaceManager_FaceIdentified
            FaceManager.ForceCapture()
            tmClosingAttempt.Enabled = True
            e.Cancel = True
        Else : FaceManager.StopProcess()
        End If
    End Sub

    Private closeForm As Boolean
    Private Sub tmClosingAttempt_Tick(sender As Object, e As EventArgs) Handles tmClosingAttempt.Tick
        closeForm = True
        tmClosingAttempt.Enabled = False
        Me.Close()
    End Sub

    Private Sub NFaceView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles fvStream.MouseDoubleClick
        If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub tmChecker_Tick(sender As Object, e As EventArgs) Handles tmChecker.Tick
        If UsedUsers.Count > 0 Then
            Dim updatedItems As clsUsedUser() = (From res As clsUsedUser In UsedUsers Where res.Elapse.TotalSeconds < userReloginTime * 60 Select res).ToArray
            UsedUsers = New clsUsedUsers(updatedItems)
        Else : tmChecker.Enabled = False
        End If
    End Sub

    Private Async Sub tmCamera2Checking_Tick(sender As Object, e As EventArgs) Handles tmCamera2Checking.Tick
        FaceManager.GetCameraList()
        If Not FaceManager.Camera2InUse And FaceManager.CameraList.Count > 1 Then
            TableLayoutPanel1.ColumnStyles(1).SizeType = SizeType.Percent
            TableLayoutPanel1.ColumnStyles(1).Width = 100
            tmCamera2Checking.Enabled = False
            Await FaceManager.StartProcess(Me, fvStream2, FaceProcessType.Identify, True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sendTime()
    End Sub
End Class
Public Class clsUsedUsers
    Inherits List(Of clsUsedUser)

    Sub New()

    End Sub

    Sub New(_users As clsUsedUser())
        AddRange(_users)
    End Sub

    Public Shadows Function Contains(userID As String) As Boolean
        If Count > 0 Then
            Return (From res As clsUsedUser In Me Where res.ID = userID Select res).ToList.Count > 0
        End If
        Return False
    End Function
End Class

Public Class clsUsedUser
    Public ID As String
    Private timeCreated As Date

    Public ReadOnly Property Elapse As TimeSpan
        Get
            Return Now - timeCreated
        End Get
    End Property

    Sub New()
        timeCreated = Now
    End Sub
End Class
