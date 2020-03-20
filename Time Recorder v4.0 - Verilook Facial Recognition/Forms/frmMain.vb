Imports System.ComponentModel
Imports Neurotec.Biometrics
Imports System.Net
Imports System.IO
Imports SEAN.DatabaseManagement
Imports VerilookLib
Imports VerilookLib.DB
Imports SEAN
Imports Newtonsoft.Json

Public Class frmMain
    'use default property for status bar
    Private User As New UserRecord
    Private UserTime As UserTimeStatus
    Public UsedUsers As clsUsedUsers
    Public authButton As Object
    Public FaceManager As VerilookManager

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lbCompany.Text = My.Settings.Company
        '    TimeRecorderUserEngines = New UserCollection
    End Sub

    Sub New(_userDB As UserCollection)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        '  TimeRecorderUserEngines = _userDB
        lbCompany.Text = My.Settings.Company
    End Sub

    'Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    '    'e.Cancel = Not MsgBox("closing", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
    '    If Not accessGranted Then
    '        e.Cancel = True
    '        specialButton = Nothing
    '        tbAdminID.Enabled = True
    '        tbAdminID.Focus()
    '    Else
    '        accessGranted = False
    '        '  Me.Close()
    '    End If
    'End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        setupMarquee()
        SetupDGV(dgv)
        FaceManager.TrySetupWorkers(Me)
        UsedUsers = New clsUsedUsers
        showStream()
    End Sub

#Region "Setup"

    Private StatusItems As List(Of cmbItem)

    Private Sub SetupDGV(dgv As DataGridView)
        dgv.Rows.Clear()
        StatusItems = New List(Of cmbItem)
        StatusItems.Add(New cmbItem() With {.Text = "TIME IN", .DisplayText = "TIME IN"})
        StatusItems.Add(New cmbItem() With {.Text = "TIME OUT", .DisplayText = "TIME OUT"})
        StatusItems.Add(New cmbItem() With {.Text = "BREAK", .DisplayText = "BREAK"})

        Dim ss = CType(dgv.Columns(5), DataGridViewComboBoxColumn)
        ss.Items.Add(StatusItems(0))
        ss.Items.Add(StatusItems(1))
        ss.Items.Add(StatusItems(2))
        ss.ValueMember = "Text"
        ss.DisplayMember = "DisplayText"

        Dim tmp As New DataTable
        tmp = FaceManager.MySQLDatabaseManager.ToDT(String.Format("SELECT  * FROM IO"))
        If tmp.Rows.Count > 0 Then
            For j As Integer = tmp.Rows.Count - 1 To tmp.Rows.Count - 50 Step -1
                Dim i As DataRow = tmp.Rows(j)
                Dim dgvr As New DataGridViewRow
                dgvr.CreateCells(dgv)
                With dgvr
                    .Cells(0).Value = i.Item("name").ToString
                    .Cells(1).Value = i.Item("project").ToString
                    .Cells(2).Value = i.Item("department").ToString
                    .Cells(3).Value = Date.Parse(i.Item("date")).ToString("yyyy-MM-dd")
                    .Cells(4).Value = New clsTimeDisplay(Date.Parse(i.Item("time"))) ' Date.Parse(i.Item("time")).ToString("hh:mm tt")
                    .Cells(5).Value = StatusItems(CInt(i.Item("logstatus")))
                    .Cells(6).Value = i.Item("employee_id").ToString
                    .Cells(7).Value = i.Item("id")
                End With

                dgv.Rows.Add(dgvr) 'i.Item("name").ToString, i.Item("project").ToString, i.Item("department").ToString, i.Item("date").ToString, i.Item("time").ToString)
                If j = 0 Then Exit For
            Next
        End If

        dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        If Not dgv.Rows.Count = 0 Then dgv.CurrentCell = dgv.Item(0, 0)
        Application.DoEvents()
    End Sub


    Public Class cmbItem
        Property Text() As String
        Property DisplayText() As String

        Public Shared Function FindIndex(_text As String) As Integer
            Select Case _text
                Case "TIME IN" : Return 0
                Case "TIME OUT" : Return 1
                Case "BREAK" : Return 2
                    '  Case Else ': MsgBox("cmbItem: Null")
                    '      Return 0
            End Select
            Return -1
        End Function
    End Class

    Private Sub setupMarquee()
        'DownloadString("http://www.idcsi-officesuites.com:8080/hrms/announcement.php?id=IUUI65DSDSS35OPUY")
    End Sub

    Private Sub downloadString(ByVal address As String)
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString(address)
        Console.WriteLine(reply)
    End Sub

#End Region

#Region "Controls"
    Private Sub tbID_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode
            Case Keys.Back
                'Case Keys.Oem2, Keys.Divide
                '    lbTimeLabel.Text = TimeLabels.timeIN
                '    lbTimeLabel.BackColor = Color.FromArgb(0, 10, 100)
                '    lbTimeLabel.ForeColor = Color.White

                '    tmBlinker.Stop()
                '    lbMessage2.Visible = True
                ' Case 42, Keys.Multiply '*'
                '    lbTimeLabel.Text = TimeLabels.timeOUT
                '    lbTimeLabel.BackColor = Color.FromArgb(90, 10, 10)
                '    lbTimeLabel.ForeColor = Color.White

                '    tmBlinker.Stop()
                '    lbMessage2.Visible = True
                ' Case Else
                '    If lbTimeLabel.Text = TimeLabels.none Then
                '        tmBlinker.Start()
                '        e.SuppressKeyPress = True
                '    End If
        End Select
    End Sub

    Private Sub btnProfiles_Click(sender As Object, e As EventArgs) Handles btnProfiles.Click
        If tryAccess(btnProfiles) Then
            UsedUsers = frmStream.UsedUsers
            frmStream.Close()
            Using userProfiles As New sfrmUserProfiles() With {.FaceManager = FaceManager, .userDB = FaceManager.UserRecords}
                userProfiles.ShowDialog()
            End Using
            '     Programs.CheckMissingUserTable(FaceManager)
            VerilookLib.UserCollection.CollectUsers(FaceManager.UserRecords, Programs.UserTablename, FaceManager.MySQLDatabaseManager, False)
            showStream()
        End If
    End Sub

    Private Sub btnExporter_Click(sender As Object, e As EventArgs) Handles btnExporter.Click
        If tryAccess(btnExporter) Then
            UsedUsers = frmStream.UsedUsers
            frmStream.Close()
            Dim exporter As New sfrmExporter With {.Users = FaceManager.UserRecords, .DBMngr = FaceManager.MySQLDatabaseManager}
            exporter.ShowDialog()

            showStream()
        End If
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If tryAccess(btnSettings) Then
            UsedUsers = frmStream.UsedUsers
            frmStream.Close()
            sfrmSettings.FaceManager = FaceManager
            If sfrmSettings.ShowDialog() = Windows.Forms.DialogResult.OK Then lbCompany.Text = My.Settings.Company
            showStream()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub

    Private Function tryAccess(btn As Object) As Boolean
        With frmStream
            If .AllowAuth Then

                changeStatus("Requesting...", savedColors.validColor, 3)
                authButton = Nothing
                tbAdminID.Visible = False
                .AllowAuth = False
                .PendingAuth = False
                Return True
            Else

                changeStatus("Requesting...", savedColors.stndByColor, 3)
                authButton = btn
                tbAdminID.Visible = True
                .PendingAuth = True
                Return False
            End If
        End With
    End Function
#End Region


#Region "Properties"

    Public ReadOnly Property DateNow() As String
        Get
            Return Microsoft.VisualBasic.Strings.Format(Date.Now, "yyyy-MM-dd")
        End Get
    End Property

    Public ReadOnly Property Time() As String
        Get
            Return lbTime.Text
        End Get
    End Property

    Public ReadOnly Property DateTime() As Date
        Get
            Return Date.Parse(String.Format(DateNow & " " & Time))
        End Get
    End Property
#End Region

#Region "Timer Eventhandler"
    Private Sub tmClock_Tick(sender As Object, e As EventArgs) Handles tmClock.Tick
        lbTime.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "hh:mm:ss tt")
        lbDate.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "dd dddd MMMM yyyy")
    End Sub

    Private Sub Clock1_TimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock1.TimeChanged
        Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(Date.Now)
    End Sub

#End Region

#Region "Methods"
    Private Sub showStream()
        With frmStream
            .UsedUsers = UsedUsers
            .FaceManager = FaceManager
            .MainForm = Me
            .Show()
        End With
    End Sub

    Private Sub changeStatus(resultString As String, statBarColor As Color, duration As Double)
        lbState.Text = resultString
        stState.BackColor = statBarColor
        tmStatus.Interval = 1000 * duration
        Application.DoEvents()

        tmStatus.Enabled = True
        tmStatus.Start()
    End Sub

    Public Sub addToTimetable(_userTime As UserTimeStatus) ', _faceMngr As VerilookManager)
        With _userTime
            Dim state As String = ""
            Dim _status As Byte = 0
            Dim _logDate As Date = Now
            Dim _id As Integer = 0
            .Fill(FaceManager.MySQLDatabaseManager.ExecuteDataReader _
                                                                  ("SELECT * FROM `IO` WHERE `employee_id`='" & .EmployeeID & "' ORDER BY `id` DESC LIMIT 1"))
           

            Dim tmpUT As New UserTimeStatus(New UserRecord, FaceManager.MySQLDatabaseManager)
            tmpUT.Fill(FaceManager.MySQLDatabaseManager.ExecuteDataReader _
                                                                  ("SELECT * FROM `IO` WHERE logstatus = 0 AND `employee_id`='" & .EmployeeID & "' ORDER BY `id` DESC LIMIT 1"))

            If .LogDate.ToString("yyyyMMdd HHmmss") <> "00010101 000000" Then
                If .SendStatus <> 1 Then
                    Select Case .LogStatus
                        Case 0 'IN
                            If (Now - .TimeIn).TotalHours < 8 Then
                                _status = 2
                            ElseIf General.Math.Between((Now - .TimeIn).TotalHours, 16, Integer.MaxValue) Then
                                _status = 0
                            Else : _status = 1
                            End If
                        Case 2 'BREAK
                            If (Now - tmpUT.TimeIn).TotalHours < 8 Then
                                _status = 2
                            ElseIf General.Math.Between((Now - tmpUT.TimeIn).TotalHours, 16, Integer.MaxValue) Then
                                _status = 0
                            Else : _status = 1
                            End If
                        Case 1 'OUT
                            If General.Math.Between((Now - .TimeIn).TotalHours, 8, Integer.MaxValue) Then
                                _status = 0
                            Else : _status = 1
                            End If
                    End Select
                End If
            Else : _status = 0
            End If

            If _status <> 0 AndAlso .LogStatus <> 1 Then
                If ((Now - .TimeIn).TotalHours <= 24 AndAlso (_logDate.Day - .LogDate.Day) = 1) Then
                    _logDate = _logDate.AddDays(-1)
                End If
            End If

            FaceManager.MySQLDatabaseManager.Insert("IO", Programs.IOFields, {.EmployeeID, _logDate, .FullName, .Project, .Department, Now.ToString("yyyy-MM-dd HH:mm:00"), _status, 0})
            Using rdr As MySql.Data.MySqlClient.MySqlDataReader = FaceManager.MySQLDatabaseManager.ExecuteDataReader _
                                                                  ("SELECT * FROM `IO` ORDER BY `id` DESC LIMIT 1")
                rdr.Read()
                _id = rdr.Item("id")
            End Using

            dgv.Rows.Insert(0, .FullName, .Project, .Department, _logDate.ToString("yyyy-MM-dd"), New clsTimeDisplay(Now), StatusItems(_status), .EmployeeID, _id)
            If My.Settings.dumpenabled Then
                If My.Settings.dumpenabled Then IO.Directory.CreateDirectory(Application.StartupPath & "\Dump")
                Using writer As StreamWriter = File.CreateText(String.Format("{0}\Dump\{1}_{2}.txt", Application.StartupPath, .EmployeeID, .TimeOut.ToString("yyyyMMdd_HHmmss")))
                    writer.WriteLine(Now.ToString("G"))
                    writer.WriteLine(state)
                    writer.WriteLine(.FullName)
                    writer.WriteLine(.EmployeeID)
                    writer.WriteLine(.Schedule)
                    writer.WriteLine(.Department)
                    writer.WriteLine(.Company)
                End Using
            End If
        End With
        dgv.CurrentCell = dgv.Item(0, 0)
    End Sub
#End Region

#Region "Classes"


    Private savedColors As New _savedColors
    Private Class _savedColors

        Public errColor As Color = Color.FromArgb(90, 10, 10)
        Public validColor As Color = Color.FromArgb(0, 108, 39)
        Public waitColor As Color = Color.FromArgb(37, 40, 45) 'Color.FromArgb(5, 100, 5) '200,150,30)
        Public stndByColor As Color = Color.FromArgb(37, 40, 45)
        Public greetColor As Color = Color.Transparent
    End Class

#End Region

#Region "Moving Form"
    Private Const WM_NCLBUTTONDOWN As Integer = &HA1
    Private Const HTCAPTION As Integer = 2

    Private Sub MoveForm()
        ReleaseCapture()
        SendMessage(Me.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0)
    End Sub

    <Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    <Runtime.InteropServices.DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

#End Region

    Private Sub MenuStrip1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDoubleClick
        btmMax.PerformClick()
    End Sub

    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            MoveForm()
        End If
    End Sub

    Private Sub btmMax_Click(sender As Object, e As EventArgs) Handles btmMax.Click
        If Me.WindowState = FormWindowState.Maximized Then
            btmMax.Image = My.Resources.expand_button
            btmMax.Text = "MAXIMIZE"
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Normal Then
            btmMax.Image = My.Resources.blank_check_box
            btmMax.Text = "RESTORE"
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub



    Private Sub dgv_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEndEdit
        If e.ColumnIndex = 5 AndAlso e.RowIndex >= 0 Then
            With dgv.Rows(e.RowIndex)
                Dim _status As Short = cmbItem.FindIndex(.Cells(5).Value.ToString)
                If _status >= 0 Then
                    Dim _empID As String = .Cells(6).Value
                    Dim _id As Integer = .Cells(7).Value

                    Dim _logDate As Date = Date.Parse(.Cells(3).Value)
                    Dim _time As clsTimeDisplay = .Cells(4).Value 'Date.Parse(_logDate.ToString("yyyy-MM-dd") & " " & .Cells(4).Value)

                    Dim prevTI As UserTimeStatus = New UserTimeStatus(FaceManager.UserRecords.lookup(_empID), FaceManager.MySQLDatabaseManager)
                    prevTI.Fill(FaceManager.MySQLDatabaseManager.ExecuteDataReader _
                                              ("SELECT * FROM `IO` WHERE `logstatus`= 0 AND employee_id='" & prevTI.EmployeeID & "' AND `time` < '" & _time._date.ToString("yyyy-MM-dd HH:mm:00") & "' ORDER BY `id` DESC LIMIT 1"))

                    If (prevTI.LogStatus <> 1 AndAlso _status <> 0) And (((_time._date - prevTI.TimeIn).TotalHours <= 24 AndAlso (_logDate.Day - prevTI.LogDate.Day) = 1)) Then
                        _logDate = prevTI.LogDate
                    ElseIf _status = 0 Then
                        _logDate = _time._date
                    End If

                    FaceManager.MySQLDatabaseManager.ExecuteQuery(String.Format("UPDATE `{0}` SET `date`='{1}', status={2}, logstatus={3} WHERE id={4}", Programs.IOTablename, _logDate.ToString("yyyy-MM-dd"), 2, _status, _id))

                    .Cells(3).Value = _logDate.ToString("yyyy-MM-dd")
                End If
            End With
        End If
    End Sub

    Public Class clsTimeDisplay
        Public _date As Date

        Sub New(__date As Date)
            _date = __date
        End Sub

        Public Overrides Function ToString() As String
            Return _date.ToString("hh:mm tt")
        End Function
    End Class
End Class


