Imports System.ComponentModel
Imports Neurotec.Biometrics
Imports System.Net
Imports System.IO
Imports SEAN.DatabaseManagement

Public Class frmMain
    'use default property for status bar
    Private User As New UserRecords
    Private UserTime As UserTimeStatus
  
    Private callback As DoWorkEventHandler
    Protected WithEvents bgwScan As New BackgroundWorker()
    Protected WithEvents bgwScanSP As New BackgroundWorker()
    Private specialButton As ToolStripMenuItem
    Private accessGranted As Boolean = False
    Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            lbCompany.Text = My.Settings.Company
            TimeRecorderUserEngines = New UserDatabase(True)
    End Sub

    Sub New(_userDB As UserDatabase)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        TimeRecorderUserEngines = _userDB
        lbCompany.Text = My.Settings.Company
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = Not MsgBox("closing", MsgBoxStyle.YesNo) = MsgBoxResult.Yes
        If Not accessGranted Then
            e.Cancel = True
            specialButton = Nothing
            tbAdminID.Enabled = True
            tbAdminID.Focus()
        Else
            accessGranted = False
            '  Me.Close()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
       SetupFingerprintScanner()
        setupFaceScanner()
        setupMarquee()

        MainSetup()
        SetupDGV(dgv)
        tbID.Select()
        sfrmFaceScanner.Show()
        FaceScannerEnabled = True
    End Sub

#Region "Setup"
    Public Sub MainSetup()
        Directory.CreateDirectory(Application.StartupPath & "\" & bioInfo.timeTableFolder)
        TMconn = New SQLiteConfiguration(String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM, ext.sqliteEx), openNow:=True)
        For Each user As UserRecords In TimeRecorderUserEngines
            If Not TMconn.CheckTable(user.ID) Then
                TMconn.CreateTable(user.ID, TMFieldTypes)
            End If
        Next
    End Sub

    Private Sub setupFingerprintScanner()
        callback = AddressOf doVerify
        bgwScan.WorkerSupportsCancellation = True
        bgwScan.WorkerReportsProgress = True

        bgwScanSP.WorkerSupportsCancellation = True
        bgwScanSP.WorkerReportsProgress = True
    End Sub

    Private Sub setupFaceScanner()
        FaceRecognizer = New FaceRecognition(TimeRecorderUserEngines)
    End Sub

    Private Sub SetupDGV(dgv As DataGridView)
        Dim ioFilePath As String = String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, FileList.BackUpIO, ext.sqliteEx)
        If File.Exists(ioFilePath) Then
            dgv.Rows.Clear()
            Dim tmp As New DataTable
            IOconn = New SQLiteConfiguration(ioFilePath, openNow:=True)
            tmp = IOconn.ToDT(String.Format("SELECT  * FROM IO"))
            If tmp.Rows.Count > 0 Then
                For j As Integer = tmp.Rows.Count - 1 To tmp.Rows.Count - 50 Step -1
                    Dim i As DataRow = tmp.Rows(j)
                    dgv.Rows.Add(i.Item(1).ToString, i.Item(2).ToString, i.Item(0).ToString, i.Item(3).ToString)
                    If j = 0 Then Exit For
                Next
            End If
        Else
            IOconn = New SQLiteConfiguration(ioFilePath, openNow:=True)
            IOconn.CreateTable("IO", IOFieldType)
        End If

        dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        If Not dgv.Rows.Count = 0 Then dgv.CurrentCell = dgv.Item(0, 0)
        Application.DoEvents()
    End Sub

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
    Private Sub tbID_KeyDown(sender As Object, e As KeyEventArgs) Handles tbID.KeyDown
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

    Private Sub tbID_TextChanged(sender As Object, e As EventArgs) Handles tbID.TextChanged
        If Not tbID.Text.Equals("") Then
            If bgwScan.IsBusy Then CancelScanningHandler()
            User = TimeRecorderUserEngines.Lookup(tbID.Text)
            If User IsNot Nothing Then
                FaceScannerEnabled = False
                UserTime = New UserTimeStatus(User)
                greet(String.Format("Hi, {0}.", User.FirstName.Split(" ")(0)), savedColors.greetColor, 360)
                changeStatus("ID has been found.", savedColors.validColor, 4)
                useID(User.ID)
                bgwScan.RunWorkerAsync(New CData(Engine.Users(0), Name).EngineUser)
            Else : changeStatus(resultTypes.ID_404, savedColors.errColor, 4)
                lbGreet.Text = resultTypes.StandBy
            End If
        End If
    End Sub

    Private Sub tbAdminID_TextChanged(sender As Object, e As EventArgs) Handles tbAdminID.TextChanged
        If Not tbAdminID.Text.Equals("") Then
            If bgwScanSP.IsBusy Then CancelScanningHandler()

            User = TimeRecorderUserEngines.Lookup(tbAdminID.Text)
            If User IsNot Nothing Then
                If User.Admin Then
                    greet(String.Format("Hi, {0}.", User.FirstName.Split(" ")(0)), savedColors.greetColor, 360)
                    changeStatus("ID has been found.", savedColors.validColor, 4)
                    useID(User.ID)
                    bgwScanSP.RunWorkerAsync(New CData(Engine.Users(0), Name).EngineUser)
                Else
                    changeStatus("This is not an Admin's ID.", savedColors.errColor, 4)
                End If
            Else
                changeStatus(resultTypes.ID_404, savedColors.errColor, 4)
            End If
        End If
    End Sub

    Private Sub tbAdminID_MouseMove(sender As Object, e As MouseEventArgs) Handles tbAdminID.MouseMove
        tbAdminID.Text = ""
        tbAdminID.Enabled = True
    End Sub

    Private Sub tbID_LostFocus(sender As Object, e As EventArgs) Handles tbID.LostFocus
        'If Not tbAdminID.Enabled Then setTimertoReFocus(30)
    End Sub

    Private Sub btnProfiles_Click(sender As Object, e As EventArgs) Handles btnProfiles.Click
        If Not accessGranted Then
            FaceScannerEnabled = False
            specialButton = btnProfiles
            tbAdminID.Enabled = True
            tbAdminID.Focus()
        Else
          Using userProfiles As New sfrmUserProfiles(TimeRecorderUserEngines)
                userProfiles.ShowDialog()
                TimeRecorderUserEngines = userProfiles.userDB
            End Using
            FaceScannerEnabled = True
            accessGranted = False
        End If
    End Sub

    Private Sub btnExporter_Click(sender As Object, e As EventArgs) Handles btnExporter.Click
        If Not accessGranted Then
            FaceScannerEnabled = False
            specialButton = btnExporter
            tbAdminID.Enabled = True
            tbAdminID.Focus()
        Else
            accessGranted = False
            Dim exporter As New sfrmExporter(TimeRecorderUserEngines)
            exporter.ShowDialog()
            FaceScannerEnabled = True
        End If
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If Not accessGranted Then
            FaceScannerEnabled = False
            specialButton = btnSettings
            tbAdminID.Enabled = True
            tbAdminID.Focus()
        Else
            FaceScannerEnabled = True
            accessGranted = False
            sfrmSettings.ShowDialog()
            lbCompany.Text = My.Settings.Company
            End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click, btnExit.Click
        If Not accessGranted Then
            FaceScannerEnabled = False
            specialButton = btnMaximize
            tbAdminID.Enabled = True
            tbAdminID.Focus()
        Else
            accessGranted = False
            Me.Close()
        End If
    End Sub

#End Region
    

#Region "Properties"
    Public WriteOnly Property FaceScannerEnabled As Boolean
        Set(value As Boolean)
            If value = True Then
                FaceRecognizer.ParentPictureBox = sfrmFaceScanner.pixDetector
                FaceRecognizer.StartLiveFeed(50)
            Else
                FaceRecognizer.EndLiveFeed()
                '  sfrmFaceScanner.Hide()
            End If
        End Set
    End Property

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

    Private Sub tmStatus_Tick(sender As Object, e As EventArgs) Handles tmStatus.Tick
        stState.BackColor = savedColors.stndByColor
        lbState.Text = resultTypes.StandBy
        tmStatus.Enabled = False
    End Sub

    Public Sub setTimertoReFocus(ByVal sec As Integer)
        tmFocus.Enabled = False
        tmFocus.Interval = sec * 1000
        tmFocus.Enabled = True
        tmFocus.Start()
    End Sub

    Private Sub tmFocus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmFocus.Tick
        tmFocus.Enabled = False
        tmFocus.Stop()
        tbID.Focus()
    End Sub

    Private Sub tmGreet_Tick(sender As Object, e As EventArgs) Handles tmGreet.Tick
        lbGreet.BackColor = savedColors.greetColor
        lbGreet.Text = resultTypes.StandBy
        tmGreet.Enabled = False
    End Sub
#End Region

#Region "Methods"
    Private Sub splash(result As String, Optional message As String = "", Optional duration As Double = 1)
        If result = resultTypes.Success Then
            Dim spl As New SuccessSplash(message, duration)
            spl.ShowDialog()
        Else
            Dim spl As New FailedSplash(result, duration)
            spl.ShowDialog()
        End If
    End Sub

    Private Sub changeStatus(resultString As String, statBarColor As Color, duration As Double)
        lbState.Text = resultString
        stState.BackColor = statBarColor
        tmStatus.Interval = 1000 * duration
        Application.DoEvents()

        tmStatus.Enabled = True
        tmStatus.Start()
    End Sub

    Private Sub greet(resultString As String, statBarColor As Color, duration As Double)
        lbGreet.Text = resultString
        lbGreet.BackColor = statBarColor
        tmGreet.Interval = 1000 * duration
        Application.DoEvents()

        tmGreet.Enabled = True
        tmGreet.Start()
    End Sub

    Private Sub reScan()
        Try
            If bgwScan.IsBusy Then Exit Sub
            If User IsNot Nothing Then
                useID(User.ID)
                bgwScan.RunWorkerAsync(New CData(Engine.Users(0), Name).EngineUser)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub reScanSP()
        Try
            If bgwScanSP.IsBusy Then Exit Sub
            If User IsNot Nothing Then
                useID(User.ID)
                bgwScanSP.RunWorkerAsync(New CData(Engine.Users(0), Name).EngineUser)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub addToTimetable(_userTime As UserTimeStatus) '_dgv As DataGridView)
        With _userTime
            Dim state As String = ""

            If Not TMconn.CheckTable(.ID) Then
                TMconn.CreateTable(.ID, TMFieldTypes)
            End If

            ._presentTime = Now
            TMconn.Insert(.ID, TMFields, {.PresentTime("D"), .PresentTime, state})

            dgv.Rows.Insert(0, .FullName, .Department, .PresentTime("D"), .PresentTime("T"))
            IOconn.Insert("IO", IOFields, New String() {.PresentTime("D"), .FullName, .Department, .PresentTime("T")})

            If My.Settings.dumpenabled Then
                If My.Settings.dumpenabled Then IO.Directory.CreateDirectory(Application.StartupPath & "\Dump")
                Using writer As StreamWriter = File.CreateText(String.Format("{0}\Dump\{1}_{2}.txt", Application.StartupPath, .ID, ._presentTime.ToString("yyyyMMdd_HHmmss")))
                    writer.WriteLine(.PresentTime)
                    ' writer.WriteLine(state)
                    writer.WriteLine(.FullName)
                    writer.WriteLine(.EmployeeNumber)
                    writer.WriteLine(.ID)
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
    Private Class resultTypes
        Public Const Success As String = "Fingerprint Match"
        Public Const Fail As String = "Fingerprint does not Match, please try again."
        Public Const TimeOut As String = "Scanner Timed out, please try again."
        Public Const StandBy As String = "Welcome."
        Public Const ID_404 As String = "ID not found."
        Public Const RuntimeError As String = "There's an Error:"
    End Class

    Private savedColors As New _savedColors
    Private Class _savedColors
        Public errColor As Color = Color.FromArgb(90, 10, 10)
        Public validColor As Color = Color.FromArgb(0, 108, 39)
        Public waitColor As Color = Color.FromArgb(37, 40, 45) 'Color.FromArgb(5, 100, 5) '200,150,30)
        Public stndByColor As Color = Color.FromArgb(37, 40, 45)
        Public greetColor As Color = Color.Transparent
    End Class
  
#End Region

#Region "Background worker"

    Private Sub BusyForm_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwScan.DoWork
        Try
            callback(sender, e)
        Catch ex As Exception
            'workerError = ex
        End Try
    End Sub

    Private Sub BusyFormSP_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwScanSP.DoWork
        Try
            callback(sender, e)
        Catch ex As Exception
            'workerError = ex
        End Try
    End Sub

    Private Sub bgwScan_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwScan.RunWorkerCompleted
        Engine.Dispose()
        If Not e.Cancelled Then
            If verify(e.Result) Then
                addToTimetable(UserTime)
                tbID.Text = ""
                greet("Welcome.", savedColors.greetColor, 1)
                FaceScannerEnabled = True
            Else
                tbID.Select()
                reScan()
            End If
        End If
    End Sub

    Private Sub bgwScanSP_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwScanSP.RunWorkerCompleted
        Engine.Dispose()
        If Not e.Cancelled Then
            If spVerify(e.Result) Then
                tbAdminID.Enabled = False
                tbAdminID.Text = ""
                accessGranted = True
                greet("Welcome.", savedColors.greetColor, 1)

                If specialButton IsNot Nothing Then
                    specialButton.PerformClick()
                Else : Me.Close()
                End If
            Else
                tbAdminID.Select()
                reScanSP()
            End If
        End If
    End Sub


#End Region

#Region "Verification"
    Private Function verify(res As Object) As Boolean
        Dim result As Object = DirectCast(res, VerificationResult)
        If result.engineStatus = NffvStatus.TemplateCreated Then
            If result.score > 0 Then
                changeStatus(resultTypes.Success, savedColors.validColor, 0.7)
                splash(resultTypes.Success, "GOOD DAY, " & User.FullName, 0.7)
                Return True
            Else : changeStatus(resultTypes.Fail, savedColors.errColor, 0.7)
                splash(resultTypes.Fail, duration:=0.7)
            End If
        ElseIf result.engineStatus = NffvStatus.ScannerTimeout Then
            changeStatus(resultTypes.TimeOut, savedColors.errColor, 2)
        Else : changeStatus(resultTypes.Fail, savedColors.errColor, 2) 'changeStatus(String.Format("Error. Reason: {0}", result.engineStatus), savedColors.errColor, 2)
        End If
        Return False
    End Function
    Private Function spVerify(res As Object) As Boolean
        Dim result As Object = DirectCast(res, VerificationResult)
        If result.engineStatus = NffvStatus.TemplateCreated Then
            If result.score > 0 Then
                changeStatus(resultTypes.Success, savedColors.validColor, 2)
                Return True
            Else : changeStatus(resultTypes.Fail, savedColors.errColor, 2)
            End If
        ElseIf result.engineStatus = NffvStatus.ScannerTimeout Then
            changeStatus(resultTypes.TimeOut, savedColors.errColor, 2)
        Else : changeStatus(resultTypes.Fail, savedColors.errColor, 2) 'changeStatus(String.Format("Error. Reason: {0}", result.engineStatus), savedColors.errColor, 2)
        End If
        Return False
    End Function
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
End Class


