Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports SEAN
Imports Newtonsoft.Json
Imports SEAN.ConfigurationStoring
Imports SocialExplorer.IO
Imports System.Text

Public Class frmPayrollSender

    Private Sub frmPayrollSender_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bin = New DirectoryInfo(Application.StartupPath).Parent.FullName & "\"
        emailConfFilePath = bin & "Email Info.xml"
        EmailInfo = New clsEmailInfo

        If File.Exists(emailConfFilePath) Then
            EmailInfo = XmlSerialization.ReadFromFile(emailConfFilePath, EmailInfo)
        Else
            While Not runEmailConf() : End While
        End If
    End Sub


#Region "timesheet"
    Private emailConfFilePath As String '= bin & "Email Info.xml"
    Private bin As String

    Private Sub btnEmailConf_Click(sender As Object, e As EventArgs) Handles btnEmailConf.Click
        runEmailConf()
    End Sub
    Private WithEvents client As SmtpClient
    Private EmailInfo As clsEmailInfo
    Private Sub sendPayrollEmail(filePath As String)
        client = New SmtpClient("mail.ddcgroup.asia", 587)
        Dim sendermAddr As New MailAddress(EmailInfo.SenderAddress, EmailInfo.RecipientName, System.Text.Encoding.UTF8)
        Dim recipientmAddr As New MailAddress(EmailInfo.RecipientAddress, EmailInfo.RecipientName, System.Text.Encoding.UTF8)
        Dim mMessage As New MailMessage(sendermAddr, recipientmAddr)
        With mMessage

        End With
        Dim st As String = "test message"
        client.SendAsync(mMessage, st)
        mMessage.Dispose()
        mMessage.Attachments.Add(New Attachment(filePath))
    End Sub
    Private Sub client_SendCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles client.SendCompleted

    End Sub

    Public Function SendAPIMessage(PostData As String, Address As String) As String
        Try
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
        Catch ex As Exception
            Return SendAPIMessage(PostData, Address)
        End Try
        Return Nothing
    End Function

    Public Class clss
        Public date_from As String
        Public date_to As String

    End Class

    Private Sub RequestTimeSheet()
        Dim rawPayrollData As String = "" '= SendAPIMessage("", "http://192.168.23.51/hrms/pages/send_timelog")
        Dim tm As New clss With {.date_from = "2020-02-20", .date_to = "2020-03-04"}
        Dim postData As String = "postData=" & JsonConvert.SerializeObject(tm, Formatting.Indented)

        rawPayrollData = SendAPIMessage(postData, "http://idcsi-officesuites.com:8080/mail/pages/send_timelog")
        '     rawPayrollData = rawPayrollData.Replace(".", "")
        Dim payrollDate As String = ""
        If rawPayrollData <> "" Then
            'Dim tms1 As New List(Of clsNewPayroll)
            'tms1 = JsonConvert.DeserializeObject(rawPayrollData, tms1.GetType)

            Dim tms As New List(Of clsNewPayroll)
            Dim bank_categories As New List(Of List(Of clsNewPayroll))
            Dim payroll_codes As New List(Of List(Of clsNewPayroll))
            tms = JsonConvert.DeserializeObject(rawPayrollData, tms.GetType)
            gen.readTimesheetGuide(bin & "\Data\Timesheet Guide_20200215-FINAL.xls", tms)
            bank_categories = (From res In tms Group By res.bank_category Into ts = Group Select ts.ToList).ToList 'grouped by bank category

            For i As Integer = 0 To bank_categories.Count - 1
                Dim bcPayCodes As List(Of List(Of clsNewPayroll)) = (From res In bank_categories(i) Group By res.payroll_code Into ts = Group Select ts.ToList).ToList 'bank categories grouped by payroll codes
                payroll_codes.AddRange(bcPayCodes)
            Next

            'Dim tmp As Date = Now 'tms(0).logs.log_date
            'If tmp.Day >= 5 And tmp.Day <= 19 Then
            '    payrollDate = String.Format("{0}{1}{2}", tmp.Month, 30, tmp.Year)
            'ElseIf tmp.Day < 5 Then
            '    tmp = tmp.AddMonths(-1)
            '    If tmp.Month = 12 Then
            '        tmp = tmp.AddYears(-1)
            '    End If
            '    payrollDate = String.Format("{0}{1}{2}", tmp.Month - 1, 15, tmp.Year)
            'ElseIf tmp.Day > 19 Then
            '    payrollDate = String.Format("{0}{1}{2}", tmp.Month, 15, tmp.Year)
            'End If

            For i As Integer = 0 To payroll_codes.Count - 1
                writeExcel(payroll_codes(i), payrollDate)
            Next
            '    MsgBox("done")
        End If
    End Sub

    Private Sub writeExcel(payroll_codes As List(Of clsPayroll), payrollDate As String)
        Dim pays As New ForPAY
        For Each payroll_code As clsPayroll In payroll_codes
            '   pays.Employees.Add(payroll_code)
        Next


        If pays.Employees.Count > 0 Then
            Dim pCode As String = pays.Employees(0).payroll_code
            If pCode = "" Then pCode = "NOCODE"
            Dim bankCat As String = pays.Employees(0).bank_category
            If bankCat = "" Then bankCat = "NOBANKCATEGORY"

            Dim filename As String = String.Format("{0}_{1}_{2}", pCode, bankCat, payrollDate)
            Dim filePath As String = String.Format("{0}\Payrolls\{1}.xlsx", bin, filename)
            If Not payrollNameExist(filename) Then
                pays.WriteTimesheetExcelReport(filePath, pCode, bankCat, payrollDate)
                dgv.Invoke(Sub() dgv.Rows.Add(filename, filePath, "Send", "Waiting"))
            End If
        End If
    End Sub

    Private Sub writeExcel(payroll_codes As List(Of clsNewPayroll), payrollDate As String)
        Dim pays As New ForPAY
        For Each payroll_code As clsNewPayroll In payroll_codes
            pays.Employees.Add(payroll_code)
        Next


        If pays.Employees.Count > 0 Then
            Dim pCode As String = pays.Employees(0).payroll_code
            If pCode = "" Then pCode = "NOCODE"
            Dim bankCat As String = pays.Employees(0).bank_category
            If bankCat = "" Then bankCat = "NOBANKCATEGORY"

            Dim filename As String = String.Format("{0}_{1}_{2}", pCode, bankCat, payrollDate)
            Dim filePath As String = String.Format("{0}\Payrolls\{1}.xlsx", bin, filename)
            If Not payrollNameExist(filename) Then
                pays.WriteTimesheetExcelReport(filePath, pCode, bankCat, payrollDate)
                dgv.Invoke(Sub() dgv.Rows.Add(filename, filePath, "Send", "Waiting"))
            End If
        End If
    End Sub

    Private Function payrollNameExist(name As String) As Boolean
        For i As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(i).Cells(0).Value = name Then
                Return True
            End If
        Next
        Return False
    End Function

    'Private Sub RequestTimesheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequestTimesheetToolStripMenuItem.Click
    '    RequestTimeSheet()
    'End Sub

    Private Function runEmailConf() As Boolean
        Using s As sfrmConfiguration = New sfrmConfiguration(EmailInfo)
            If s.ShowDialog() = Windows.Forms.DialogResult.OK Then
                EmailInfo = s.EmailInfo
                XmlSerialization.WriteToFile(emailConfFilePath, EmailInfo)
                MsgBox("Saved")
                Return True
            Else
                Return False
            End If
        End Using
    End Function
#End Region

    Public dbfFlds As String() = {"DATA SmallInt", "CODE SmallInt", "ID Text(4)", "REG_HRS Float", "R_OT Float", "RD_OT Float", "RD_8 Float", _
                                  "HOL_OT Float", "HOL_OT8 Float", "ND Float", "ABS_TAR Float", "ADJUST1 Float", "GROSS_PAY Float", "ADJUST2 Float", _
                                  "TAX Float", "SSS_EE Float", "SSS_ER Float", "PHIC Float", "NET_PAY Float", "REG_PAY Float", "TAG Text(1)"}
    Public Sub SaveToDBF(dbfPath As String, values As List(Of clsPayroll))
        Dim ExportedDbf = New SocialExplorer.IO.FastDBF.DbfFile(System.Text.Encoding.GetEncoding(1252))
        ExportedDbf.Open(dbfPath, FileMode.Create)

        For Each col In dbfFlds
            Dim fldinf As String() = col.Split(" ")
            Select Case fldinf(1).ToUpper
                Case "FLOAT"
                    ExportedDbf.Header.AddColumn(New FastDBF.DbfColumn(fldinf(0), FastDBF.DbfColumn.DbfColumnType.Float, 0, 0))
                Case "SMALLINT"
                    ExportedDbf.Header.AddColumn(New FastDBF.DbfColumn(fldinf(0), FastDBF.DbfColumn.DbfColumnType.Integer, 0, 0))
                Case "TEXT(4)"
                    ExportedDbf.Header.AddColumn(New FastDBF.DbfColumn(fldinf(0), FastDBF.DbfColumn.DbfColumnType.Character, 4, 0))
                Case "TEXT(1)"
                    ExportedDbf.Header.AddColumn(New FastDBF.DbfColumn(fldinf(0), FastDBF.DbfColumn.DbfColumnType.Character, 1, 0))
            End Select
        Next

        For r As Integer = 0 To values.Count - 1

            Dim NewRec = New SocialExplorer.IO.FastDBF.DbfRecord(ExportedDbf.Header)

            'For c As Integer = 0 To dbfFlds.Length - 1

            '    NewRec(c) = dt.Rows(r)(col).ToString
            '    ColumnCounter = ColumnCounter + 1
            'Next

            ExportedDbf.Write(NewRec, True)

        Next

        ExportedDbf.Close()
    End Sub

    Private lastListing As Date
    Private Sub tmLister_Tick(sender As Object, e As EventArgs) Handles tmLister.Tick
        Me.Invoke(Sub() tmLister.Enabled = False)
        Dim tm As TimeSpan = (Now - lastListing)
        If tm.TotalSeconds >= 30 Then
            'list
            RequestTimeSheet()
            lastListing = Now
        Else
            lbStatus.Text = 30 - tm.TotalSeconds.ToString("##") & "sec/s before listing..."
        End If

        '    Me.Invoke(Sub() tmLister.Enabled = True)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        tmLister_Tick(Nothing, Nothing)
        tmLister.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        btnConfiguration.Enabled = False
        lbStatus.Text = "Running..."
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        tmLister.Enabled = False
        btnStart.Enabled = True
        btnStop.Enabled = False
        btnConfiguration.Enabled = True
        lbStatus.Text = "Stopped..."
    End Sub

    Private Sub dgv_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Me.Datagridview_ButtonClick
        MsgBox(e.RowIndex)
        'TODO - Button Clicked - Execute Code Here
    End Sub
    Event Datagridview_ButtonClick(sender As DataGridView, e As DataGridViewCellEventArgs)
    Private Sub dgv_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
            RaiseEvent Datagridview_ButtonClick(senderGrid, e)
        End If
    End Sub
End Class
