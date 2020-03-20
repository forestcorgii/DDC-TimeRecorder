Imports VerilookLib
Imports SEAN.DatabaseManagement
Public Class UserTimeStatus
    Inherits UserRecord
    Public NewLog As Boolean
    Public LogStatus As enumlogStatus
    Public SendStatus As Integer
    Public LogDate As Date

    Public TimeIn As Date
    Public TimeOut As Date

    Public BreakTimeIn As Date
    Public BreakTimeOut As Date
    Public dbMngr As MysqlConfiguration


    Public ReadOnly Property isComplete As Boolean
        Get
            Return Not TimeOut = Nothing
        End Get
    End Property

    Sub New(_userDB As UserRecord, _dbMngr As MysqlConfiguration) ', _userState As String)
        ' UserState = _userState
        dbMngr = _dbMngr
        With _userDB
            ID = .ID
            EmployeeID = .EmployeeID
            FirstName = .FirstName
            LastName = .LastName
            MiddleName = .MiddleName
            Company = .Company
            Schedule = .Schedule
            Department = .Department
            Project = .Project
            Admin = .Admin
        End With
        '  getTimeTableInfo()
    End Sub

    Public Sub Fill(reader As MySql.Data.MySqlClient.MySqlDataReader)
        If reader.HasRows Then
            reader.Read()
            ID = reader.Item("id")
            LogStatus = reader.Item("logstatus")
            SendStatus = reader.Item("status")
            TimeIn = Date.Parse(reader.Item("time"))
            LogDate = Date.Parse(reader.Item("date"))
        End If
        reader.Close()
    End Sub

    Public ReadOnly Property TotalHours As Integer
        Get
            Return (Now - TimeIn).TotalHours
        End Get
    End Property

    Public Sub getTimeTableInfo(Optional _date As Date = Nothing)
        Dim dt As New DataTable
        If _date = Nothing Then
            dt = dbMngr.ToDT(String.Format("SELECT * FROM `{0}` WHERE `employee_id`='{1}' AND `status` NOT LIKE 4" _
                                       & " ORDER BY `time_in` DESC LIMIT 1;", Programs.TMTablename, EmployeeID))
        Else
            dt = dbMngr.ToDT(String.Format("SELECT * FROM `{0}` WHERE `employee_id`='{1}' AND `logdate`='{2}' AND `status` NOT LIKE 4" _
                                       & " ORDER BY `time_in` DESC LIMIT 1;", Programs.TMTablename, EmployeeID, ConvertToDBDateFormat(_date)))
        End If
        If Not dt.Rows.Count = 0 Then
            LogDate = dt.Rows(0).Item("logdate")
            TimeIn = dt.Rows(0).Item("time_in")
            TimeOut = dt.Rows(0).Item("time_out")
            BreakTimeIn = dt.Rows(0).Item("breaktime_in")
            BreakTimeOut = dt.Rows(0).Item("breaktime_out")
            LogStatus = dt.Rows(0).Item("status")

            NewLog = False
        Else : NewLog = True
        End If
    End Sub

    Public Sub UpdateLog()
        If CheckLog() Then
            LogStatus = enumlogStatus.FOR_SEND
            dbMngr.Update(Programs.TMTablename, Programs.TMFields, {EmployeeID, LogDate, TimeIn, TimeOut, BreakTimeIn, BreakTimeOut, CInt(LogStatus)}, {New SQLCondition("logdate", LogDate)})
            resetLog()
        End If

        AssignLog(Now)
        If NewLog Then 'insert
            dbMngr.Insert(Programs.TMTablename, Programs.TMFields, {EmployeeID, LogDate, TimeIn, TimeOut, BreakTimeIn, BreakTimeOut, CInt(LogStatus)})
        Else 'update
            dbMngr.Update(Programs.TMTablename, Programs.TMFields, {EmployeeID, LogDate, TimeIn, TimeOut, BreakTimeIn, BreakTimeOut, CInt(LogStatus)}, {New SQLCondition("logdate", LogDate, "AND"), New SQLCondition("employee_id", EmployeeID)})
        End If


        ''for one time log
        'LogDate = Now
        'TimeIn = Now
        'Status = logStatus.FOR_SEND
        'dbMngr.Insert(Programs.TMTablename, Programs.TMFields, {EmployeeID, LogDate, TimeIn, TimeOut, BreakTimeIn, BreakTimeOut, CInt(Status)})
        ''end
    End Sub

    'Select Case Schedule
    '    Case "1ST"
    '        If Now.Hour >= 5 And Now.Hour <= 7 Then
    '            tmp = 0 'time in
    '        ElseIf Now.Hour >= 14 Or Now.Hour < 5 Then 'And Now.Hour <= 16 
    '            tmp = 1 'time out
    '        ElseIf Now.Hour > 7 And Now.Hour < 14 Then
    '            tmp = 2 'break time
    '        End If
    '    Case "2ND"
    '        If Now.Hour >= 13 And Now.Hour <= 15 Then
    '            tmp = 0
    '        ElseIf Now.Hour >= 22 Or Now.Hour < 13 Then
    '            tmp = 1
    '        ElseIf Now.Hour > 15 And Now.Hour < 22 Then
    '            tmp = 2
    '        End If
    '    Case "3RD"
    '        If Now.Hour >= 22 And Now.Hour <= 0 Then
    '            tmp = 0
    '        ElseIf Now.Hour >= 7 And Now.Hour < 22 Then
    '            tmp = 1
    '        ElseIf Now.Hour > 0 And Now.Hour < 7 Then
    '            tmp = 2
    '        End If
    '    Case "SWING"
    '        If Now.Hour >= 16 And Now.Hour <= 18 Then
    '            tmp = 0
    '        ElseIf Now.Hour >= 1 And Now.Hour < 16 Then
    '            tmp = 1
    '        ElseIf Now.Hour > 18 And Now.Hour < 1 Then
    '            tmp = 2
    '        End If
    '        '   Case Else 'test 
    'End Select
    Public Function AssignLog(presentDate As Date) As Boolean
        Dim tmp As Integer = 0

        If TimeOut = Nothing Then
            tmp = 1
        ElseIf (presentDate - TimeIn).TotalHours Then
            tmp = 2
        End If

        If tmp = 0 Then
            If TimeIn = Nothing Or TimeIn.ToString("HHmmss") = "000000" Then
                TimeIn = presentDate
                LogStatus = enumlogStatus.TIME_IN
            End If
        ElseIf tmp = 1 Then
            If TimeIn = Nothing Or TimeOut.ToString("HHmmss") = "000000" Then
                TimeOut = presentDate
                LogStatus = enumlogStatus.TIME_OUT
            End If
        ElseIf tmp = 2 Then
            If BreakTimeIn = Nothing Then
                BreakTimeIn = presentDate
                LogStatus = enumlogStatus.TIME_OUT
            Else
                BreakTimeOut = presentDate
                LogStatus = enumlogStatus.TIME_OUT
            End If
        End If

        If LogDate = Nothing Then
            LogDate = presentDate
        End If

        Return tmp
    End Function

    'Select Case Schedule
    '           Case "1ST"
    '               If newdate And Now.Hour >= 5 Then
    '                   createNewLog = True
    '               End If
    '           Case "2ND"
    '               If newdate And Now.Hour >= 13 Then
    '                   createNewLog = True
    '               End If
    '           Case "3RD"
    '               If newdate And Now.Hour >= 22 Then
    '                   createNewLog = True
    '               End If
    '           Case "SWING"
    '               If newdate And Now.Hour >= 16 Then
    '                   createNewLog = True
    '               End If
    '        End Select
    Public Function CheckLog() As Boolean
        Dim createNewLog As Boolean = False
        If Not NewLog Then
            Dim newdate As Boolean = LogDate.Day <> Now.Day
            If newdate Then
                If TimeIn <> Nothing AndAlso (Now - TimeIn).TotalHours >= 9 Then
                    createNewLog = True
                End If
            End If
        End If
        Return createNewLog
    End Function

    Private Sub fixLog()
        If TimeOut = Nothing Then
            If BreakTimeOut <> Nothing Then
                TimeOut = BreakTimeOut
                BreakTimeOut = Nothing
            ElseIf BreakTimeIn <> Nothing Then
                TimeOut = BreakTimeIn
                BreakTimeIn = Nothing
            End If
        End If
    End Sub

    Private Sub resetLog()
        LogDate = Nothing
        TimeIn = Nothing
        TimeOut = Nothing
        BreakTimeIn = Nothing
        BreakTimeOut = Nothing

        LogStatus = enumlogStatus.TIME_IN

        NewLog = True
    End Sub

    'Private Function checkNullDate(dt As Date)

    'End Function

    Public Enum enumlogStatus
        TIME_IN = 0
        BREAKTIME_IN = 1
        BREAKTIME_OUT = 2
        TIME_OUT = 3
        FOR_SEND = 4
    End Enum
End Class

