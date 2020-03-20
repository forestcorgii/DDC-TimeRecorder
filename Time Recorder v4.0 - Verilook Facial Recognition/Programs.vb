Imports VerilookLib
Imports System.IO
Imports SEAN.DatabaseManagement
Friend NotInheritable Class Programs



#Region "Arrays"
    Public Shared UserTablename As String = "tbluser"
    Public Shared UserFieldTypes As String() = {"`id` INTEGER PRIMARY KEY AUTOINCREMENT", "`employee_id` TEXT(5)", "`firstname` TEXT(50)", "`lastname` TEXT(50)", _
                                      "`middlename` TEXT(50)", "`project` TEXT(50)", "`department` TEXT(50)", "`company` TEXT(50)", _
                                      "`schedule` INTEGER", "`active` TEXT(10)", "`admin` TEXT(10)", _
                                      "`face_img1` BLOB", "`face_img2` BLOB", "`face_img3` BLOB"}
    Public Shared UserFields As String() = {"id", "employee_id", "firstname", "lastname", "asd", "middlename", "department", "company", _
                                     "schedule", "active", "admin", "face_img1", "face_img2", "face_img3"}

    Public Shared TMTablename As String = "tbltimelog"
    Public Shared TMFieldTypes As String() = {"`employee_id` VARCHAR(4)", "`logdate` VARCHAR(15)", "`time_in` DATETIME", "`time_out` DATETIME" _
                                               , "`breaktime_in` DATETIME", "`breaktime_out` DATETIME", "status INT(1)"}
    Public Shared TMFields As String() = {"employee_id", "logdate", "time_in", "time_out", "breaktime_in", "breaktime_out", "status"}
    'Public Shared TMFieldTypes As String() = {"`DATE` TEXT(15)", "`_TIME` TEXT(40)", "`FLAG` TEXT(10)"}
    'Public Shared TMFields As String() = {"DATE", "_TIME", "FLAG"}

    Public Shared IOTablename As String = "IO"
    Public Shared IOFieldType As String() = {"`date` TEXT", "`name` TEXT", "`project` TEXT", "`department` TEXT", "`time` TEXT"}
    Public Shared IOFields As String() = {"employee_id", "date", "name", "project", "department", "time", "logstatus", "status"}

#End Region

    Sub New()
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim bin As String = New DirectoryInfo(Application.StartupPath).Parent.FullName 'Path.GetFullPath("..")
            Try
            Dim _mngr As New VerilookManager(bin, useTrial:=VerilookLib.Utils.GetTrialModeFlag)
            _mngr.MySQLDatabaseManager = MysqlConfiguration.StartDefaultSetup(bin & "\conf\", "dbConf")
            _mngr.MySQLDatabaseManager.SetupConnection()

            _mngr.MySQLDatabaseManager.TryCreateTable(Programs.UserTablename, UserFieldTypes)
            _mngr.MySQLDatabaseManager.TryCreateTable(IOTablename, IOFieldType)

            VerilookLib.UserCollection.CollectUsers(_mngr.UserRecords, Programs.UserTablename, _mngr.MySQLDatabaseManager, _mngr.Settings.Face.SingleImageRecognition)
            _mngr.GetTemplate()

            If _mngr.UserRecords.Count < 1 Then
                With AddingUser.frmSetup
                    .FaceManager = _mngr
                    .NewUserDB = New UserRecord
                End With

                If Not AddingUser.frmSetup.ShowDialog = DialogResult.OK Then
                    Exit Sub
                End If
            End If
            Application.Run(New frmMain() With {.FaceManager = _mngr})
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

    Private Shared Sub transferToMysql(u As UserCollection, con As MysqlConfiguration, userTablename As String)
        For i As Integer = 0 To u.Count - 1
            u(i).saveToDB(con, userTablename)
        Next
    End Sub

    Public Shared Sub splash(result As String, Optional message As String = "", Optional duration As Double = 1)
        If result = resultTypes.Success Then
            Dim spl As New SuccessSplash(message, duration)
            spl.Show()
        Else
            Dim spl As New FailedSplash(result, duration)
            spl.Show()
        End If
    End Sub

    Private Class resultTypes
        Public Const Success As String = "Fingerprint Match"
        Public Const Fail As String = "Fingerprint does not Match, please try again."
        Public Const TimeOut As String = "Scanner Timed out, please try again."
        Public Const StandBy As String = "Welcome."
        Public Const ID_404 As String = "ID not found."
        Public Const RuntimeError As String = "There's an Error:"
    End Class
End Class
