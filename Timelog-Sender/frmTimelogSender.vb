Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json
Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports NPOI.XSSF.UserModel
Imports System.Net.Mail

Imports SEAN
Imports SEAN.ConfigurationStoring
Imports SEAN.DatabaseManagement

Public Class frmTimelogSender
    Private databaseManager As New DatabaseManagement.MysqlConfiguration
    Private generalConfig As New GeneralConfiguration
    Private WithEvents messengers As Workers
    Private indexOnQueue As List(Of String)

    Private bin As String
    Dim genConfFilepath As String
    Private LogStream As StreamWriter
    Private LogFormat As String = "ID: {0} Log Date: {1} IN: {2} OUT: {3}"
    Private iotablename As String = "io"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        indexOnQueue = New List(Of String)
        messengers = New Workers(Me, 1000)
        messengers.SetWorker(1)
        databaseManager = DatabaseManagement.MysqlConfiguration.StartDefaultSetup(Application.StartupPath, My.Application.Info.AssemblyName)
        databaseManager.SetupConnection()

        bin = New DirectoryInfo(Application.StartupPath).Parent.FullName & "\"
        genConfFilepath = Application.StartupPath & "\" & My.Application.Info.AssemblyName & ".conf.xml"
        If File.Exists(genConfFilepath) Then
            generalConfig = XmlSerialization.ReadFromFile(genConfFilepath, generalConfig)
        Else
            btnGeneralConf.PerformClick()
        End If

        '  tmUpdateChecker_Tick(Nothing, Nothing)
        '  tmUpdateChecker.Interval = (60 * 1000) * 60
        sendingQueues = New List(Of clsSenderTimelog)
       End Sub

    Private Sub btnDatabaseConf_Click(sender As Object, e As EventArgs) Handles btnDatabaseConf.Click
        databaseManager.Close()
        databaseManager = DatabaseManagement.MysqlConfiguration.OpenEditor(databaseManager, Application.StartupPath, My.Application.Info.AssemblyName)
    End Sub
    Private Sub btnGeneralConf_Click(sender As Object, e As EventArgs) Handles btnGeneralConf.Click
        Using genconfForm As New sfrmConfig(generalConfig, genConfFilepath)
            If genconfForm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                generalConfig = genconfForm.GeneralConfig
                messengers.SetWorker(generalConfig.WorkersCount)
            End If
        End Using
    End Sub

    Private lastListing As Date
    Private Sub tmLister_Tick(sender As Object, e As EventArgs) Handles tmLister.Tick
        Me.Invoke(Sub() tmLister.Enabled = False)

        Dim tm As TimeSpan = (Now - lastListing)
        If tm.TotalSeconds >= 120 Then
            'list
            tmUpdateChecker_Tick(Nothing, Nothing)
            listTimelog()
            lastListing = Now
        Else
            lbStatus.Text = CInt(120 - tm.TotalSeconds) & "sec/s before listing..."
        End If

        Me.Invoke(Sub() tmLister.Enabled = True)
    End Sub

    ''' <summary>
    ''' update 010420 - basis for recognizing new log is changed from the logdate to the logstatus
    ''' update 010820 - basis for recognizing new log is modified, it will ignore timeout log that are found in the middle 
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub listTimelog()
        If sendingQueues.Count = 0 And messengers.QueueArgs.Count = 0 Then 'check for queued logs
            'Get for Update IDs
            Dim empids As New List(Of String)
            Dim rdr As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT `employee_id` FROM `" & iotablename & "` WHERE (`status` = 0 OR `status` = 2) GROUP BY `employee_id`;") 'AND `employee_id` = 'CP01'  
            While rdr.Read
                empids.Add(rdr.Item("employee_id"))
            End While
            rdr.Close()

            'Get timelog
            For Each empid As String In empids
                rdr = databaseManager.ExecuteDataReader("SELECT * FROM `" & iotablename & "` WHERE `employee_id`='" & empid & "' ORDER BY `time` DESC;")
                Dim logStatus As Byte = 0
                Dim _timeLog As New clsSenderTimelog
                _timeLog.EmployeeID = empid
                Dim _logdate As String = ""
                While rdr.Read
                    Dim _id As String = empid & " " & dateParse(rdr.Item("date"), "yyyy-MM-dd")
                    If indexOnQueue.Contains(_id) = False Then
                        logStatus = rdr.Item("logstatus")
                        If logStatus = 0 Then
                            If Not _timeLog.Timein = "null" Then
                                addLine(_timeLog)
                            End If
                            _timeLog.Timein = dateParse(rdr.Item("time"), "yyyy-MM-dd HH:mm:ss")
                            _timeLog.TimeInSendStatus = rdr.Item("status")
                            _timeLog.ID = _id
                            If _timeLog.Timeout = "null" Then
                                addLine(_timeLog)
                            End If
                        ElseIf (logStatus = 1 Or logStatus = 2) Then
                            If Not _timeLog.Timeout = "null" Then
                                If (dateParse(_timeLog.Timeout, "yyyy-MM-dd") = dateParse(rdr.Item("time"), "yyyy-MM-dd")) Then
                                    Continue While
                                End If
                                addLine(_timeLog)
                            End If

                            _timeLog.Timeout = dateParse(rdr.Item("time"), "yyyy-MM-dd HH:mm:ss")
                            _timeLog.TimeOutSendStatus = rdr.Item("status")
                            _timeLog.ID = _id
                        End If
                    End If
                End While
                If indexOnQueue.Contains(_timeLog.ID) = False AndAlso _timeLog.Valid Then
                    addLine(_timeLog)
                End If
                Application.DoEvents()
                rdr.Close()
            Next
            addToQueue()
        ElseIf sendingQueues.Count > 0 And messengers.QueueArgs.Count = 0 Then
            addToQueue()
        End If
        'Dim a = (From res In sendingQueues Group By id = res.EmployeeID, Date.Parse(res.t Into Group, Count()).ToList

    End Sub
    '  While rdr.Read
    'Dim _id As Integer = rdr.Item("id")
    '            If indexOnQueue.Contains(_id) = False Then
    '                logStatus = rdr.Item("logstatus")
    '                If logStatus = 0 Then
    '                    If _timeLog.Timein <> "null" Or _timeLog.Timeout <> "null" Then
    '                        addLine(_timeLog)
    '                    End If

    '                    _timeLog.Timein = dateParse(rdr.Item("time"), "yyyy-MM-dd HH:mm:ss")
    '                    _timeLog.TimeInSendStatus = rdr.Item("status")
    '                    _timeLog.ID = _id
    '                ElseIf logStatus = 1 Then 'Or logStatus = 2 Then
    '                    If _timeLog.Timeout <> "null" Then
    '                        addLine(_timeLog)
    '                     End If

    '                    _timeLog.Timeout = dateParse(rdr.Item("time"), "yyyy-MM-dd HH:mm:ss")
    '                    _timeLog.TimeOutSendStatus = rdr.Item("status")
    '                    _timeLog.ID = _id
    '                End If
    '            End If
    '            Me.Invoke(Sub() indexOnQueue.Add(_id))
    '        End While
    Private Function dateParse(dt As Object, Optional format As String = Nothing) As String
        If IsDBNull(dt) = False Then
            If format <> Nothing Then
                Return Date.Parse(dt).ToString(format)
            Else : Return Date.Parse(dt).ToString()
            End If
        Else : Return ""
        End If
    End Function
    Private sendingQueues As List(Of clsSenderTimelog)
    Private Sub addLine(ByRef timeLog As clsSenderTimelog)
        If timeLog.Valid Then
            Dim da As String = timeLog.EmployeeID & " " & timeLog.LogDate
            Me.Invoke(Sub() indexOnQueue.Add(da)) 'indexOnQueue.Add(timeLog.EmployeeID & " " & timeLog.LogDate)
            sendingQueues.Add(timeLog.Clone)
        End If
        timeLog.ClearTime()
    End Sub

    Private Sub addToQueue()
        If sendingQueues.Count > 0 Then
            For i As Integer = 0 To sendingQueues.Count - 1
                messengers.AddtoQueue(sendingQueues(i))
            Next
        Else : indexOnQueue.Clear()
        End If
        lbQueue.Text = messengers.QueueArgs.Count
    End Sub

    Private Sub messengers_RunWorkersCompleted(sender As Object) Handles messengers.RunWorkersCompleted
        '       indexOnQueue.Clear()
    End Sub
    ''' <summary>
    ''' update 010420 - change update query condition from `date` to `time`
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub messengers_Worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles messengers.Worker_DoWork
        Dim args = e.Argument
        Try
            Dim timelog As clsSenderTimelog = e.Argument
            If sendTimeLog(timelog.ID, timelog.EmployeeID, timelog.Timein, timelog.Timeout) Then
                If timelog.Timein <> "null" Then
                    databaseManager.ExecuteQuery(String.Format("UPDATE `{0}` SET status={1} WHERE employee_id='{2}' AND `time`='{3}' ", iotablename, 1, timelog.EmployeeID, timelog.Timein)) 'Date.Parse(IIf(args(3) <> "null", args(3), args(4))).ToString("yyyy-MM-dd")))
                End If
                If timelog.Timeout <> "null" Then
                    databaseManager.ExecuteQuery(String.Format("UPDATE `{0}` SET status={1} WHERE employee_id='{2}' AND `time`='{3}' ", iotablename, 1, timelog.EmployeeID, timelog.Timeout)) 'Date.Parse(IIf(args(3) <> "null", args(3), args(4))).ToString("yyyy-MM-dd")))
                End If

                writeOnLogStream(args)
                sendingQueues.Remove(timelog)
                Me.Invoke(Sub() lbQueue.Text = sendingQueues.Count)
            Else : writeOnLogStream(args, True)
                messengers.AddtoQueue(timelog)
            End If
        Catch ex As Exception
            logErrorMessage(args(1), "Dowork: " & ex.Message)
        End Try
    End Sub

    Private Sub writeOnLogStream(args As clsSenderTimelog, Optional isError As Boolean = False)
        LogStream = File.AppendText(bin & "log\" & Now.ToString("yyyy-MM-dd") & ".log")
        LogStream.AutoFlush = True
        LogStream.WriteLine(LogFormat, args.EmployeeID, args.LogDate, args.Timein, args.Timeout)
        If isError Then
            LogStream.Write(" AN ERROR OCCURED IN THIS LINE!!!")
        End If
        LogStream.Close()
    End Sub

    Private Sub messengers_Worker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles messengers.Worker_RunWorkerCompleted
        ' lbQueue.Text = "On Queue: " & indexOnQueue.Count
    End Sub

    Public Function SendAPIMessage(PostData As String, Address As String) As String
        Dim w As WebRequest = WebRequest.Create(Address)
        w.Method = "POST"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(PostData)
        w.ContentType = "application/x-www-form-urlencoded"
        w.ContentLength = byteArray.Length

        Dim dataStream As Stream = w.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)

        Dim response As WebResponse = w.GetResponse()
        dataStream = response.GetResponseStream()

        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        reader.Close()
        dataStream.Close()
        response.Close()

        Return responseFromServer
    End Function

    Private Function sendTimeLog(id As String, empid As String, timein As String, timeout As String) As Boolean
        Dim responseFromServer As String = ""
        Dim failcnt As Short = 0
        While True
            Try
                Dim l As New clsSenderTimelog With {.ID = id, .EmployeeID = empid, .Timein = timein, .Timeout = timeout, ._type = "Send"}
                Dim postData As String = "postData= " & JsonConvert.SerializeObject(l, Formatting.Indented)
                responseFromServer = SendAPIMessage(postData, generalConfig.Address) '"http://localhost/hrms/pages/receive_timelog")
                If responseFromServer.Contains("Message sent") = False Then
                    If failcnt >= 10 Then
                        logErrorMessage(id, String.Format("Alert!   IN:{0}   OUT:{1}  Message:'{2}'", timein, timeout, responseFromServer))
                        Return False
                    End If
                    failcnt += 1
                Else
                    logErrorMessage(id, "Message Sent: " & responseFromServer)
                    Return True
                End If
                Return True
            Catch ex As Exception
                logErrorMessage(id, "Time Sending: " & ex.Message)
                Exit While
            End Try
        End While
        Return False
    End Function

    Private Function requestUpdate(logdate As String) As String
        Dim responseFromServer As String = ""
        Try
            Dim l As New clsRequest With {.LogDate = logdate, ._type = "Request"}

            Dim postData As String = "postData= " & JsonConvert.SerializeObject(l, Formatting.Indented)
            responseFromServer = SendAPIMessage(postData, generalConfig.Address) '"http://localhost/hrms-ltac/pages/receive_timelog")

            Return responseFromServer
        Catch ex As Exception
            logErrorMessage("ERROR", "Update Request: " & ex.Message)
        End Try
        Return Nothing
    End Function

    Private Sub updateLogs(logdate As String)
        Try
            Dim tms As New List(Of clsUpdateLog)
            tms = JsonConvert.DeserializeObject(requestUpdate(logdate), tms.GetType)
            For i As Integer = 0 To tms.Count - 1
                Dim empinfo As clsEmployeeInfo = retrieveEmployeeInfo(tms(i).id_number)
                '  databaseManager.ExecuteQuery(String.Format("DELETE FROM `IO` WHERE employee_id='{0}' AND `date`='{1}' AND `logstatus`=2", tms(i).id_number, logdate))
                checkTimelog_exist(empinfo, tms(i), 0) 'for time in
                checkTimelog_exist(empinfo, tms(i), 1) 'for time out
            Next
        Catch ex As Exception
            logErrorMessage("ERROR", "Update Log - " & logdate & ": " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="empid"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function retrieveEmployeeInfo(empid As String) As clsEmployeeInfo
        Dim rdr As MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM `io` WHERE `employee_id`='" & empid & "' LIMIT 1;")
        Dim empInfo As clsEmployeeInfo = Nothing
        While rdr.Read
            empInfo = New clsEmployeeInfo
            With empInfo
                .EmployeeID = rdr.Item("employee_id")
                .Fullname = rdr.Item("name")
                .Project = rdr.Item("project")
                .Department = rdr.Item("department")
            End With
        End While
        rdr.Close()
        Return empInfo
    End Function

    Private Function checkTimelog_exist(empinf As clsEmployeeInfo, updatelog As clsUpdateLog, logstatus As Integer) As Boolean
        Dim isValid As Boolean = True
        If empinf IsNot Nothing Then
            Dim rdr As MySqlDataReader = databaseManager.ExecuteDataReader(String.Format("SELECT * FROM `io` WHERE `employee_id`='{0}' AND `date`='{1}';", empinf.EmployeeID, updatelog.log_date, logstatus))
            Dim logExists As Boolean = rdr.HasRows
            Dim logtime As String = updatelog.edited_time_in
            If logstatus = 1 Then
                logtime = updatelog.edited_time_out
                If logtime = "0000-00-00 00:00:00" Then
                    logtime = updatelog.original_time_out
                End If
            Else
                If logtime = "0000-00-00 00:00:00" Then
                    logtime = updatelog.original_time_in
                End If
            End If

            While rdr.Read
                If logtime = rdr.Item("time") Then
                    isValid = False
                End If
            End While
            rdr.Close()

            If Not logtime = "0000-00-00 00:00:00" And isValid Then
                If logExists Then
                    databaseManager.ExecuteQuery(String.Format("UPDATE `IO` SET `time`='{0}' WHERE `logstatus`={1} AND employee_id='{2}' AND `date`='{3}'", logtime, logstatus, empinf.EmployeeID, updatelog.log_date))
                Else
                    databaseManager.ExecuteQuery(String.Format("INSERT INTO `IO` (`employee_id`,`name`,`project`,`department`,`date`,`time`,`logstatus`,`status`)VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},1);" _
                                    , empinf.EmployeeID, empinf.Fullname, empinf.Project, empinf.Department, updatelog.log_date, logtime, logstatus))
                End If
                logErrorMessage(empinf.EmployeeID, String.Format("TimelogSender Editted!! TIME: {0} - STATUS: {1}", logtime, logstatus))
                isValid = True
            End If
        End If
        Return isValid
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class clsEmployeeInfo
        Public EmployeeID As String
        Public Fullname As String
        Public Project As String
        Public Department As String
    End Class


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tmUpdateChecker_Tick(sender As Object, e As EventArgs) Handles tmUpdateChecker.Tick
        '   tmUpdateChecker.Enabled = False
        updateLogs(Now.ToString("yyyy-MM-dd"))
        updateLogs(Now.AddDays(-1).ToString("yyyy-MM-dd"))
        updateLogs(Now.AddDays(-2).ToString("yyyy-MM-dd"))
        '  tmUpdateChecker.Enabled = True
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'RequestTimeSheet()
        'tmUpdateChecker_Tick(Nothing, Nothing)
        '  tmUpdateChecker.Enabled = True
        tmLister_Tick(Nothing, Nothing)
        tmLister.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        btnConfiguration.Enabled = False
        lbStatus.Text = "Running..."
        messengers.StartWorking()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        '   tmUpdateChecker.Enabled = False
        tmLister.Enabled = False
        btnStart.Enabled = True
        btnStop.Enabled = False
        btnConfiguration.Enabled = True
        lbStatus.Text = "Stopped..."
        messengers.StopWorking()
    End Sub

    Private Sub logErrorMessage(id As String, msg As String)
        Dim l As New ListViewItem({id, Now, msg})
        lstErrorLog.Invoke(Sub() lstErrorLog.Items.Insert(0, l))
    End Sub

    '#Region "timesheet"
    '    Private emailConfFilePath As String '= bin & "Email Info.xml"
    '    Public Sub ini()

    '        emailConfFilePath = bin & "Email Info.xml"

    '        EmailInfo = New clsEmailInfo
    '        If File.Exists(emailConfFilePath) Then
    '            EmailInfo = XmlSerialization.ReadFromFile(emailConfFilePath, EmailInfo)
    '        Else
    '            While Not runEmailConf() : End While
    '        End If
    '    End Sub

    '    Private Sub btnEmailConf_Click(sender As Object, e As EventArgs) Handles btnEmailConf.Click
    '        runEmailConf()
    '    End Sub
    '    Private WithEvents client As SmtpClient
    '    Private Sub sendPayrollEmail()
    '        client = New SmtpClient("", 3306)
    '        Dim sendermAddr As New MailAddress(EmailInfo.SenderAddress, EmailInfo.RecipientName, System.Text.Encoding.UTF8)
    '        Dim recipientmAddr As New MailAddress(EmailInfo.RecipientAddress, EmailInfo.RecipientName, System.Text.Encoding.UTF8)
    '        Dim mMessage As New MailMessage(sendermAddr, recipientmAddr)
    '        With mMessage

    '        End With
    '        Dim st As String = "test message"
    '        client.SendAsync(mMessage, st)
    '        mMessage.Dispose()
    '        'mMessage.Attachments = {New Attachment("")}
    '    End Sub
    '    Private Sub client_SendCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles client.SendCompleted

    '    End Sub

    '    Private Sub RequestTimeSheet()


    '        Dim rawPayrollData As String = "" '= SendAPIMessage("", "http://192.168.23.51/hrms/pages/send_timelog")
    '        Try
    '            Dim postData As String = "postData"
    '            rawPayrollData = SendAPIMessage("", "http://localhost/hrms/pages/send_timelog")

    '        Catch ex As Exception
    '        End Try

    '        'rawPayrollData = "[{""employee_id"":""D526"",""log_date"":""2019-09-20"",""time_in"":""2019-09-20 11:00:00"",""time_out"":""2019-09-20 23:00:00""},{""employee_id"":""D526"",""log_date"":""2019-09-21"",""time_in"":""2019-10-21 09:00:00"",""time_out"":""2019-10-21 18:00:00""},{""employee_id"":""D526"",""log_date"":""2019-09-23"",""time_in"":""2019-10-23 09:00:00"",""time_out"":""2019-10-23 18:00:00""},{""employee_id"":""D526"",""log_date"":""2019-09-24"",""time_in"":""2019-10-24 09:00:00"",""time_out"":""2019-10-24 18:00:00""},{""employee_id"":""D526"",""log_date"":""2019-09-27"",""time_in"":""2019-10-27 09:00:00"",""time_out"":""2019-10-27 18:00:00""},{""employee_id"":""D526"",""log_date"":""2019-10-03"",""time_in"":""2019-10-03 09:00:00"",""time_out"":""2019-10-03 18:00:00""},{""employee_id"":""LS50"",""log_date"":""2019-09-20"",""time_in"":""2019-10-24 09:00:00"",""time_out"":""2019-10-24 18:00:00""}]"

    '        If rawPayrollData <> "" Then
    '            Dim tms As New List(Of clsPayroll.clsTimelog)
    '            Dim pays As New ForPAY
    '            Dim da
    '            tms = JsonConvert.DeserializeObject(rawPayrollData, tms.GetType)
    '            da = (From res In tms Group By id = res.employee_id Into ts = Group Select ts).ToList

    '            For Each d As clsPayroll.clsTimelog() In da
    '                Dim newPayroll As clsPayroll = New clsPayroll(d.ToList, databaseManager)
    '                newPayroll.Compute()
    '                pays.Employees.Add(newPayroll)
    '            Next

    '            pays.WriteExcelReport("E:\asda.xlsx")

    '            MsgBox("done")

    '        End If
    '    End Sub
    '    Private Sub RequestTimesheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestTimesheetToolStripMenuItem.Click
    '        RequestTimeSheet()
    '    End Sub

    '    Private Function runEmailConf() As Boolean
    '        Using s As sfrmConfiguration = New sfrmConfiguration(EmailInfo)
    '            If s.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '                EmailInfo = s.EmailInfo
    '                XmlSerialization.WriteToFile(emailConfFilePath, EmailInfo)
    '                MsgBox("Saved")
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        End Using
    '    End Function

    '#End Region





End Class
