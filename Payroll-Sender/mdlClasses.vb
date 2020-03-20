Imports SEAN.DatabaseManagement
Imports NPOI.SS.UserModel
Imports System.IO
Imports NPOI.XSSF.UserModel
Imports System.Xml.Serialization
Imports NPOI.HSSF.UserModel

Public Class clsSenderTimelog
    Public ID As String
    Public EmployeeID As String

    Public TimeInSendStatus As Byte
    Public TimeOutSendStatus As Byte

    Private ReadOnly Property _timeBound As Integer
        Get
            Select Case Now.Day
                Case 5, 6, 7, 20, 21, 22
                    Return 24
                Case Else
                    Return 48
            End Select
        End Get
    End Property

    Public ReadOnly Property Valid As Boolean
        Get
            If Timeout = "null" And Timein = "null" Then Return False
            If (TimeInSendStatus = 1 AndAlso TimeOutSendStatus = 1) Then Return False
            If TimeInSendStatus = 1 AndAlso Timeout = "null" Then Return False
            If TimeOutSendStatus = 1 AndAlso Timein = "null" Then Return False
            If ((Not Timein = "null") AndAlso (Now - Date.Parse(Timein)).TotalHours <= _timeBound) Then Return False
            If ((Not Timeout = "null") AndAlso (Now - Date.Parse(Timeout)).TotalHours <= _timeBound) Then Return False
            Return True
        End Get
    End Property

    Public Property encrypted_data As String
        Get
            Return encrypt(LogDate)
        End Get
        Set(value As String)

        End Set
    End Property
    Public Property LogDate As String
        Get
            If Timein <> "null" Then
                Return Date.Parse(Timein).ToString("yyyy-MM-dd")
            ElseIf Timeout <> "null" Then
                Return Date.Parse(Timeout).ToString("yyyy-MM-dd")
            End If
            Return ""
        End Get
        Set(value As String)

        End Set
    End Property
    Private _timein As String
    Public Property Timein As String
        Get
            If _timein <> Nothing And _timein <> "" Then
                Return _timein
            Else : Return "null"
            End If
        End Get
        Set(value As String)
            _timein = value
        End Set
    End Property

    Private _timeout As String
    Public Property Timeout As String
        Get
            If _timeout <> Nothing And _timeout <> "" Then
                Return _timeout
            Else : Return "null"
            End If
        End Get
        Set(value As String)
            _timeout = value
        End Set
    End Property

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

    Public Sub ClearTime()
        _timein = ""
        _timeout = ""
        TimeInSendStatus = 0
        TimeOutSendStatus = 0
    End Sub

End Class

Public Class clsPayroll
    Public ReadOnly Property Fullname As String
        Get
            Dim mi As Char = ""
            If middle_name.Length > 0 Then mi = middle_name(0)
            Return String.Format("{0},{1} {2}", last_name, first_name, mi)
        End Get
    End Property
    Public ReadOnly Property Valid As Boolean
        Get
            If employee_id Is Nothing Then Return False
            If first_name Is Nothing Then Return False

            If logs Is Nothing Then Return False
            If logs.Count <= 0 Then Return False
            Return True
        End Get
    End Property
    Public employee_id As String
    Public first_name As String
    Public last_name As String
    Public middle_name As String
    Public location As Object
    Public bank_category As String
    Public payroll_code As String
    Public rec_type As String
    Public Remarks As String

    Public ID As String
    Public Schedule As String
    Public logs As List(Of clsTimelog)

    Public TotalRegularHours As Integer
    Public TotalRegularOT As Integer
    Public TotalSunday As Integer
    Public TotalHoliday As Integer
    Public TotalNightDifferential As Integer
    Public TotalTardy As Integer

    Sub New(_timelogs As List(Of clsTimelog))
        'Timelogs = New List(Of clsTimelog)
        'If _timelogs.Count > 0 Then
        '    'ID = _timelogs(0).employee_id
        '    'first_name = _timelogs(0).first_name
        '    'last_name = _timelogs(0).last_name
        '    'middle_name = _timelogs(0).middle_name
        '    'location = _timelogs(0).location

        '    'PayrollCode = _timelogs(0).payroll_code
        '    'BankCategory = _timelogs(0).bank_category
        '    'rec_type = _timelogs(0).rec_type
        'End If
        'Timelogs.AddRange(_timelogs)
    End Sub

    Public Class clsLog
        Public time_in As String
        Public time_out As String
        Public log_date As String
    End Class

    Public Class clsTimelog
        'Public employee_id As String
        'Public first_name As String
        'Public last_name As String
        'Public middle_name As String
        'Public location As String
        'Public bank_category As String
        'Public payroll_code As String
        'Public rec_type As String

        Public time_in As String
        Public time_out As String
        Public log_date As String

        Public RegularHours As Integer
        Public NightDifferential As Integer
        Public RegularOT As Integer
        Public Sunday As Integer
        Public tardy As Double
        Public Holiday As Integer
        Public LeaveCount As Integer


        Private Function checkLeave() As Boolean
            Select Case time_out.ToUpper
                Case "APPROVED WITH PAY"
                    If time_in = "1" Then
                        LeaveCount = 8
                    Else : LeaveCount = 4
                    End If
                    Return True
            End Select
            Return False
        End Function

        Public ReadOnly Property TimeIn As Date
            Get
                Try
                    Return Date.Parse(time_in)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property
        Public ReadOnly Property TimeOut As Date
            Get
                Try
                    Return Date.Parse(time_out)
                Catch ex As Exception
                    Return Nothing
                End Try
            End Get
        End Property

        Public ReadOnly Property Valid As Boolean
            Get
                If (TimeIn = Nothing Or TimeOut = Nothing) Or (TimeIn = TimeOut) Then
                    Return False
                Else : Return True
                End If
            End Get
        End Property

        Public ReadOnly Property UnderTime As Boolean
            Get
                If Valid And TotalHours < 9 Then
                    Return True
                Else : Return False
                End If
            End Get
        End Property

        Public ReadOnly Property TotalHours As Double
            Get
                If Valid Then
                    Return (TimeOut - TimeIn).TotalHours
                Else : Return 0
                End If
            End Get
        End Property

        Private ReadOnly Property isSunday As Boolean
            Get
                Return TimeIn.ToString("dddd").ToUpper = "SUNDAY"
            End Get
        End Property

        Public Sub GetInitialComputation()
            Dim totalHrs As Double = 0
            Dim excessHrs As Double = 0
            If Not checkLeave() Then
                If Not UnderTime Then
                    RegularHours = 8
                    excessHrs = validateHours(TotalHours - 9) ' GETTING OT
                    If excessHrs > 0 Then
                        RegularOT = excessHrs
                    End If
                Else
                    If TotalHours > 5 Then
                        RegularHours = validateHours(TotalHours - 1)
                    ElseIf TotalHours >= 0.5 Then
                        RegularHours = validateHours(TotalHours - 0.5)
                    Else : RegularHours = validateHours(TotalHours)
                    End If
                End If

                Dim tmpTMin As Date = Date.Parse(TimeIn.ToString("MM/dd/yyyy HH:00:00")) 'GETTING ND
                If TimeIn.Hour = 22 And TimeIn.Minute >= 30 Then
                    NightDifferential += 0.5
                    tmpTMin = tmpTMin.AddHours(1)
                ElseIf isND(TimeIn.Hour) Then
                    If TimeIn.Minute >= 30 Then
                        NightDifferential += 0.5
                        tmpTMin = tmpTMin.AddHours(1)
                    End If
                End If
                Do Until tmpTMin >= TimeOut Or tmpTMin.Hour = 6
                    tmpTMin = tmpTMin.AddHours(1)
                    Select Case tmpTMin.Hour
                        Case 23, 0, 1, 2, 3, 4, 5, 6
                            If tmpTMin >= TimeOut And TimeOut.Minute >= 30 Then
                                NightDifferential += 0.5
                            Else : NightDifferential += 1
                            End If
                    End Select
                Loop
            Else
                RegularHours = LeaveCount
            End If

            If isSunday Then
                Sunday = RegularHours
                RegularHours = 0
            End If
        End Sub

        Private Function isND(hr As Integer) As Boolean
            Select Case hr
                Case 23, 0, 1, 2, 3, 4, 5, 6 ',22
                    Return True
            End Select
            Return False
        End Function
        Private Function validateHours(hrs As Double) As Double
            Dim splitted_hrs As String() = hrs.ToString("N1").Split(".")
            Dim wholeNumber As Integer = splitted_hrs(0)
            Dim tenth As Integer = splitted_hrs(1)

            If tenth >= 5 Then
                tenth = 5
            Else : tenth = 0
            End If

            If wholeNumber = 0 And tenth = 0 Then
                Return 0
            ElseIf Not wholeNumber = 0 And tenth = 0 Then
                Return CInt(wholeNumber)
            Else
                Return Val(String.Format("{0}.{1}", wholeNumber, tenth))
            End If
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0} - {1}", TimeIn, TimeOut)
        End Function
    End Class

    Public Sub Compute()
        TotalRegularHours = 0
        TotalRegularOT = 0
        TotalTardy = 0

        TotalSunday = 0
        TotalHoliday = 0
        TotalNightDifferential = 0

        For Each timelog As clsTimelog In logs
            With timelog
                If .time_in.Length <= 3 Or (.TimeIn.ToString("yyyyMMdd HHmmss") <> "00010101 000000" And .TimeOut.ToString("yyyyMMdd HHmmss") <> "00010101 000000") Then
                    .GetInitialComputation()
                    If .TotalHours >= 0 Then
                        TotalRegularHours += .RegularHours
                        TotalRegularOT += .RegularOT
                        TotalTardy += .tardy

                        TotalSunday += .Sunday
                        TotalHoliday = .Holiday
                        TotalNightDifferential += .NightDifferential
                    End If
                End If
            End With
        Next
    End Sub

    Public Function GetValue(field As String)
        Select Case field
            Case "DATA"
            Case "CODE"
            Case "ID"
                Return employee_id
            Case "REG_HRS"
                Return logs(0).RegularHours
            Case "R_OT"
                Return TotalRegularOT
            Case "RD_OT"

            Case "RD_8"
            Case "HOL_OT"
            Case "HOL_OT8"
            Case "ND"
            Case "ABS_TAR"
            Case "ADJUST1"
            Case "GROSS_PAY"
            Case "ADJUST2"
            Case "TAX"
            Case "SSS_EE"
            Case "SSS_ER"
            Case "PHIC"
            Case "NET_PAY"
            Case "REG_PAY"
            Case "TAG"
        End Select
    End Function

    Public Overrides Function ToString() As String
        Return String.Format("{0} - {1} - {2} - {3} - {4}", employee_id, Fullname, TotalRegularHours, payroll_code, bank_category)
    End Function
End Class

Public Class clsNewPayroll
    Public ReadOnly Property Fullname As String
        Get
            Dim mi As Char = ""
            If middle_name.Length > 0 Then mi = middle_name(0)
            Return String.Format("{0},{1} {2}", last_name, first_name, mi)
        End Get
    End Property
    Public ReadOnly Property Valid As Boolean
        Get
            If employee_id Is Nothing Then Return False
            If first_name Is Nothing Then Return False

            If logs Is Nothing Then Return False
            If logs.Count <= 0 Then Return False
            Return True
        End Get
    End Property
    Public employee_id As String
    Public first_name As String
    Public last_name As String
    Public middle_name As String
    Public location As Object
    Public bank_category As String
    Public payroll_code As String
    Public rec_type As String
    Public Remarks As String

    Public ID As String
    Public Schedule As String
    Public logs As List(Of clsNewTimeLog)


    Public Function GetValue(field As String)
        Select Case field
            Case "DATA"
            Case "CODE"
            Case "ID"
                Return employee_id
            Case "REG_HRS"
                Return logs(0).total_hours
            Case "R_OT"
                Return logs(0).total_ots
            Case "RD_OT"
                Return logs(0).total_rd_ot
            Case "RD_8"

            Case "HOL_OT"
                Return logs(0).total_h_ot
            Case "HOL_OT8"
            Case "ND"
                Return logs(0).total_nd
            Case "ABS_TAR"
            Case "ADJUST1"
            Case "GROSS_PAY"
            Case "ADJUST2"
            Case "TAX"
            Case "SSS_EE"
            Case "SSS_ER"
            Case "PHIC"
            Case "NET_PAY"
            Case "REG_PAY"
            Case "TAG"
        End Select
    End Function

End Class

Public Class clsNewTimeLog
    Public total_hours As Double
    Public total_ots As Double
    Public total_rd_ot As Double
    Public total_h_ot As Double
    Public total_nd As Double
    Public total_tardy As Double
End Class

Public Class gen
    Public Shared Sub readTimesheetGuide(path As String, ByRef emps As List(Of clsPayroll))
        Dim book As IWorkbook = Nothing
        Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        book = New HSSFWorkbook(fs)

        Dim sheet As ISheet = book.GetSheetAt(0)
        For i As Integer = 0 To sheet.LastRowNum - 1
            Dim row As IRow = sheet.GetRow(i)
            For j As Integer = 0 To emps.Count - 1
                If emps(j).employee_id = row.GetCell(1).ToString Then
                    emps(j).payroll_code = row.GetCell(3).ToString
                    emps(j).Remarks = row.GetCell(6).ToString
                End If
            Next
        Next

    End Sub

    Public Shared Sub readTimesheetGuide(path As String, ByRef emps As List(Of clsNewPayroll))
        Dim book As IWorkbook = Nothing
        Dim fs As FileStream = New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
        book = New HSSFWorkbook(fs)

        Dim sheet As ISheet = book.GetSheetAt(0)
        For i As Integer = 0 To sheet.LastRowNum - 1
            Dim row As IRow = sheet.GetRow(i)
            For j As Integer = 0 To emps.Count - 1
                If emps(j).employee_id = row.GetCell(1).ToString Then
                    emps(j).payroll_code = row.GetCell(3).ToString
                    emps(j).Remarks = row.GetCell(6).ToString
                End If
            Next
        Next

    End Sub
End Class


Public Class ForPAY
    Public Employees As List(Of clsNewPayroll) 'Public Employees As List(Of clsPayroll)
    Public Holiday As List(Of Date)

    Sub New()
        Employees = New List(Of clsNewPayroll) '       Employees = New List(Of clsPayroll)
        Holiday = New List(Of Date)
    End Sub

 

    Public Function WriteTimesheetExcelReport(filePath As String, payroll_code As String, bank_category As String, payrollDate As String) As Boolean
        Try
            Dim nWorkBook As IWorkbook = New XSSFWorkbook
            Dim nSheet As ISheet = nWorkBook.CreateSheet(bank_category)
            '  Dim row As IRow = nSheet.CreateRow(0)

            createCellLines(0, {"", "", payroll_code & " - " & bank_category}, nSheet)
            createCellLines(1, {"", "", payrollDate}, nSheet)
            createCellLines(2, {""}, nSheet)
            createCellLines(3, {"#", "ID #", "NAMES", "DEPT", "REG HRS", "R OT", "SUN", "HOL", "ND", "TARDY"}, nSheet)

            Dim rowidx As Integer = 4
            For Each payroll As clsNewPayroll In Employees
                'Debug.WriteLine("{0} {1} {2}", payroll.Fullname, payroll.employee_id, payroll.logs(0))
                If payroll.Valid Then 'IsNot Nothing Then
                    '     payroll.Compute()
                    'createCellLines(rowidx, {rowidx - 3, payroll.employee_id, payroll.Fullname, payroll.location, payroll.TotalRegularHours, payroll.TotalRegularOT, _
                    '                         payroll.TotalSunday, payroll.TotalHoliday, payroll.TotalNightDifferential, payroll.TotalTardy}, nSheet)
                    createCellLines(rowidx, {rowidx - 3, payroll.employee_id, payroll.Fullname, payroll.location, payroll.logs(0).total_hours, payroll.logs(0).total_ots, _
                                             payroll.logs(0).total_rd_ot, payroll.logs(0).total_h_ot, payroll.logs(0).total_nd, payroll.logs(0).total_tardy}, nSheet)
                    rowidx += 1
                End If
            Next

            Using wrtr As FileStream = New IO.FileStream(filePath, FileMode.Create, FileAccess.Write)
                nWorkBook.Write(wrtr)
            End Using
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub createCellLines(rowidx As Integer, cellnames As String(), nsheet As ISheet)
        Dim row As IRow = nsheet.CreateRow(rowidx)
        For colidx As Integer = 0 To cellnames.Length - 1
            Dim cel As ICell = row.CreateCell(colidx)
            cel.SetCellValue(cellnames(colidx))
        Next
    End Sub
End Class

Public Class clsEmailInfo
    Public Port As Integer
    Public Host As String

    Public SenderName As String
    Public RecipientName As String

    Public SenderAddress As String
    Public RecipientAddress As String


End Class


