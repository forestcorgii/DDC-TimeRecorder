Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports IDCSIBiometrics.VBNETSample
Imports System.Data.OleDb

Module Process
    ' Public NDList As New List(Of NDInfo)
    Public timeInfo As New EmpTimeTable

    Public Function msgBox_in(ByVal msg As String, Optional ByVal caption As String = "", Optional ByVal maxLength As Integer = 10000, Optional ByVal acceptBlank As Boolean = True, Optional ByVal width As Integer = 300, Optional ByVal height As Integer = -1) As String
        If Not msg_in.Created Then
            Dim h As Integer = height
            If height = -1 Then
                h = msg_in.Height
            End If
            msg_in.Size = New Size(width, h)

            msg_in.lblPrompt.Text = msg
            msg_in.Text = caption

            msg_in.txtInput.MaxLength = maxLength
            msg_in.acceptBlank = acceptBlank
            msg_in.ShowDialog()

            If msg_in.DialogResult = DialogResult.OK Then
                msgBox_in = msg_in.txtInput.Text
                msg_in.txtInput.Text = ""
                Return msgBox_in
            End If
        End If
        Return ""
    End Function

    Public Sub setTimer(ByVal tm As Timer, ByVal lb As Label, ByVal sec As Integer, ByVal txt As String, ByVal promptType As String, Optional ByVal op As Boolean = False)
        Select Case promptType
            Case "FAILED"
                If op = True Then
                    lb.ForeColor = Color.Red
                Else
                    lb.BackColor = Color.FromArgb(85, 0, 0)
                    lb.ForeColor = Color.White
                End If
          
            Case "SUCCESS"
                lb.BackColor = Color.FromArgb(22, 45, 87)
                lb.ForeColor = Color.White
        End Select

        lb.Text = txt
        tm.Enabled = False
        tm.Interval = sec * 1000
        tm.Enabled = True
        tm.Start()
    End Sub

    Public Sub getInfo()
        If File.Exists((String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, testBio.ID, ext.infEx))) Then
            timeInfo = New EmpTimeTable
            With timeInfo
                Using str As StreamReader = New StreamReader((String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, testBio.ID, ext.infEx)))
                    Dim l As String = testBio.ID
                    .ID = l

                    l = str.ReadLine
                    Integer.TryParse(l.Substring(0, 1), .defIdx)
                    .printName = l.Substring(2)

                    l = str.ReadLine
                    .empNum = l

                    l = str.ReadLine
                    .comp = l

                    l = str.ReadLine
                    .department = l

                    l = str.ReadLine
                    .firstName = l

                    l = str.ReadLine
                    .lastName = l

                    l = str.ReadLine
                    .middleName = l

                    .printName = String.Format("{0}, {1} {2}.", .lastName, .firstName, .middleName)
                    getTimeTableInfo(timeInfo)
                    ScanningProcess.getTimeInfo(timeInfo)
                    ' Application.DoEvents()

                    If .status = "C" Then Exit Sub

                    If VerifyID(.ID) Then
                        addToTimetable()
                    End If
                End Using
            End With
        Else
            setTimer(testBio.Timer1, testBio.lbPromt, 2, Stat.UI, "FAILED")
        End If
    End Sub

    Private Sub getTimeTableInfo(ByRef tm As EmpTimeTable)
        Dim inArr As String()
        Dim dt As New DataTable
        mdbToDT(String.Format("SELECT * FROM {0} ORDER BY [DAY] DESC", tm.ID), dt, TMconn)

        With tm

            If testBio.TimeInfo = TimeLabel.timeOUT Then
                If dt.Rows.Count <> 0 Then
                    If dt.Rows(0).Item("OUT").ToString <> "" Then
                        MsgBox("Timing out without timing in as not valid.")
                        .status = "C"
                    Else
                        .status = "0"
                        .DAY = dt.Rows(0).Item("DAY").ToString()
                        .outDT = testBio.DT
                        .outTM = testBio.TM
                        .tmIN = dt.Rows(0).Item("IN").ToString
                        inArr = .tmIN.Split(" ")
                        .inDT = inArr(0)
                        .inTM = inArr(1)
                        .tmOUT = String.Format("{0} {1}", tm.outDT, .outTM)
                    End If
                Else
                    MsgBox("Timing out without timing in as not valid.")
                    .status = "C"
                End If
            ElseIf testBio.TimeInfo = TimeLabel.timeIN Then
                If dt.Rows.Count <> 0 Then
                    inArr = dt.Rows(0).Item("IN").ToString.Split(" ")
                    If inArr(0) = testBio.DT Then
                        MsgBox("You've already timed in this day")
                        .status = "C"
                    Else
                        .status = "-1"
                    End If
                Else
                    .status = "-1"
                End If
                .inDT = testBio.DT
                .inTM = testBio.TM
                .tmIN = String.Format("{0} {1}", .inDT, .inTM)
            End If
        End With
    End Sub

    Public Sub addToTimetable()
        With timeInfo
            '"Date-text", "Name-text", "Dept-text", "IN-text", "OUT-text"
            If .status = "-1" Then
                testBio.dgv.Rows.Insert(0, .inDT, .printName, .department, .inTM)
                mdbInsert(.ID, New String() {"DATE", "IN"}, New String() {.inDT, .tmIN}, TMconn)

                mdbInsert("IO", New String() {"Date", "Name", "Dept", "IN", "OUT"}, New String() {.inDT, .printName, .department, .inTM, ""}, IOconn)
            Else
                testBio.dgv.Rows.Insert(0, .outDT, .printName, .department, .inTM, .outTM)
                mdbUpdate(.ID, New String() {"IN", "OUT"}, New String() {.tmIN, .tmOUT}, _
                New Object() {"DAY", Integer.Parse(timeInfo.DAY)}, TMconn)

                mdbInsert("IO", New String() {"Date", "Name", "Dept", "IN", "OUT"}, New String() {.inDT, .printName, .department, .inTM, .outTM}, IOconn)
            End If
        End With
    End Sub

    '   Private Sub getHRS(ByRef tm As EmpTimeTable, ByVal timeIN As String(), ByVal timeOut As String())
    'Dim inDT As String() = timeIN(0).Split(Char.Parse("-"))
    'Dim outDT As String() = timeOut(0).Split(Char.Parse("-"))

    'Dim inTM As String() = timeIN(1).Split(Char.Parse(":"))
    'Dim outTM As String() = timeOut(1).Split(Char.Parse(":"))

    'Dim NOD As Integer = (Date.Parse(timeOut(0)) - Date.Parse(timeIN(0))).Days
    'Dim NOH As Integer = (Date.Parse(timeOut(0) & " " & timeOut(1)) - Date.Parse(timeOut(0) & " " & timeIN(1))).Hours + (NOD * 24)
    'Dim NOM As Integer

    'Dim tmp As Integer = 0
    '    If Integer.Parse(outTM(0)) = 0 Then tmp = 24 Else tmp = Integer.Parse(outTM(0)) - 1
    '    If Integer.Parse(inTM(1)) > Integer.Parse(outTM(1)) Then
    '        If NOH <> 0 Then NOH -= 1
    '        NOM = (Date.Parse(outTM(0) & ":" & outTM(1) & ":" & outTM(2)) - Date.Parse(tmp.ToString("D2") & ":" & inTM(1) & ":" & inTM(2))).Minutes
    '    Else
    '        NOM = (Date.Parse(outTM(0) & ":" & outTM(1) & ":" & outTM(2)) - Date.Parse(outTM(0) & ":" & inTM(1) & ":" & inTM(2))).Minutes
    '    End If

    ''If NOM > 58 Then
    ''    NOH += 1
    ''    NOM = 0
    ''ElseIf NOM > 28 Then
    ''    NOM = 30
    ''End If

    '    If NOH >= 6 Then NOH -= 1

    '    If NOH >= 8 Then
    '        tm.OT = String.Format("{0}:{1}", (NOH - 8).ToString("D2"), NOM.ToString("D2"))
    '        NOH = 8
    '        NOM = 0
    '    End If

    '    If NOH <= 5 Then
    '        If MessageBox.Show("Your current working hour is less than the minimum working hour(5hrs.)" & Environment.NewLine & " It will be count as absent " & Environment.NewLine & " Do you want to continue?", "Ask", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '            tm.AB = "1"
    '        Else
    '            tm.status = "C"
    '        End If
    '    End If

    '    tm.HR = String.Format("{0}:{1}", NOH.ToString("D2"), NOM.ToString("D2"))
    '    tm.ND = getND(String.Format("{0} {1}", timeIN(0), inTM(0))).ToString("D2")

    '    tm.inDT = timeIN(0)
    '    tm.inTM = timeIN(1)
    'End Sub
    '#Region "Night Differential"
    '    Public Class NDInfo
    '        Public dateTime As String
    '        Public CNT As Integer
    '        Public HR As Integer
    '    End Class

    '    Public Sub addNDToList(ByVal DT As String, ByVal HR As String)
    '        Dim add As Boolean = False
    '        If NDList.Count >= 100 Then
    '            NDList.RemoveAt(0)
    '        End If

    '        If NDList.Count = 0 Then
    '            add = True
    '        Else
    '            If NDList.Item(NDList.Count - 1).HR <> Integer.Parse(HR) Then add = True
    '        End If

    '        If add = True Then
    '            Dim ND As New NDInfo
    '            Select Case Integer.Parse(HR)
    '                Case 23, 24, 1, 2, 3, 4, 5, 6
    '                    ND.CNT = 1
    '                Case Else
    '                    ND.CNT = 0
    '            End Select
    '            ND.HR = Integer.Parse(HR)
    '            ND.dateTime = String.Format("{0} {1}", DT, HR)
    '            NDList.Add(ND)
    '        End If
    '    End Sub

    '    Private Function getND(ByVal dt As String) As Integer
    '        Dim NDC As Integer = 0
    '        For Each i As NDInfo In NDList
    '            NDC += i.CNT
    '            If dt = String.Format("{0} {1}", i.dateTime, i.HR) Then Exit For
    '        Next
    '        Return NDC
    '    End Function
    '#End Region

    '#Region "Day Count"
    '    Private HOLList As New List(Of String)
    '    Private CUTList As New List(Of String)
    '    Private DOList As New List(Of String)

    '    Public dayNUM As Integer = 1
    '    Private dayNOW As Integer = 0
    '    Private dayNameNOW As String = ""
    '    Public dtNOW As String = ""


    '    '===variables for cutoff date
    '    Public startCutDate As String = ""
    '    Public endCutDate As String = ""
    '    '====
    '    Public Sub checkDAY(ByVal NEWday As Integer, ByVal NEWdayname As String, ByVal NEWDT As String)
    '        If dayNOW = 0 Then
    '            dayNOW = NEWday
    '            dayNameNOW = NEWdayname
    '            dtNOW = NEWDT
    '            editCutoffInfo(generateCutoffDate(Date.Parse(dtNOW).ToString("ddMMyy")), String.Format("{0} {1} {2} {3}", dayNUM, dayNOW, dayNameNOW, dtNOW))
    '        End If
    '        If dayNOW <> NEWday Then
    '            If HOLList.Contains(dayNOW.ToString) Then
    '                startTask("HOLIDAY")
    '            ElseIf DOList.Contains(dayNameNOW.ToUpper) Then
    '                startTask("DAYOFF")
    '            Else
    '                startTask("ABSENT")
    '            End If

    '            'If CUTList.Contains(dayNOW.ToString) Then
    '            '    startTask("CUTOFF")
    '            '    dayNUM = 1
    '            '    editCutoffInfo(generateCutoffDate(Date.Parse(dtNOW).ToString("ddMMyy")), String.Format("{0} {1} {2} {3}", dayNUM, dayNOW, dayNameNOW, dtNOW))
    '            'Else
    '            '    getDayNumber()
    '            'End If

    '            dtNOW = NEWDT
    '            dayNOW = NEWday
    '            dayNameNOW = NEWdayname
    '            editCutoffInfo(String.Format("{0}-{1}", startCutDate, endCutDate), String.Format("{0} {1} {2} {3}", dayNUM, dayNOW, dayNameNOW, dtNOW))
    '        End If
    '    End Sub

    '    Private Sub getDayNumber()
    '        Dim dd As Integer = Integer.Parse(startCutDate.Substring(0, 2))
    '        Dim mm As Integer = Integer.Parse(startCutDate.Substring(2, 2))
    '        Dim yy As Integer = Integer.Parse(startCutDate.Substring(4, 2))

    '        dayNUM = (Date.Parse(dtNOW) - Date.Parse(String.Format("{0}/{1}/{2}", mm, dd, yy))).Days
    '    End Sub

    '    Public Sub getCutoffInfo()
    '        Using str As StreamReader = New StreamReader((String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeSheetFolder, "CUTOFF", ext.cutEx)))
    '            Dim l As String = str.ReadLine
    '            If l IsNot Nothing Then
    '                Dim tmp As String() = l.Split(Char.Parse("-"))
    '                startCutDate = tmp(0)
    '                endCutDate = tmp(1)

    '                l = str.ReadLine
    '                tmp = l.Split(Char.Parse(" "))

    '                dayNUM = Integer.Parse(tmp(0))
    '                dayNOW = Integer.Parse(tmp(1))
    '                dayNameNOW = tmp(2)
    '                dtNOW = tmp(3)
    '            End If
    '        End Using
    '    End Sub

    '    Public Sub editCutoffInfo(ByVal firstline As String, ByVal secondline As String)
    '        '  File.WriteAllText((String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeSheetFolder, "CUTOFF", ext.cutEx)), String.Format("{0}{1}{2}", firstline, Environment.NewLine, secondline))
    '    End Sub

    '    Private Function generateCutoffDate(ByVal startingDate As String) As String
    '        Dim addone As Boolean = True

    '        Dim sdd As Integer = Integer.Parse(startingDate.Substring(0, 2))
    '        Dim smm As Integer = Integer.Parse(startingDate.Substring(2, 2))
    '        Dim syy As Integer = Integer.Parse(startingDate.Substring(4, 2))
    '        Dim edd, emm, eyy As Integer

    '        Dim startCut As Integer = Integer.Parse(CUTList.Item(0))
    '        Dim endCut As Integer = Integer.Parse(CUTList.Item(1))

    '        If CUTList.Count = 2 Then
    '            eyy = syy
    '            emm = smm
    '            If sdd = startCut Or (sdd >= startCut And sdd < 20) Then
    '                edd = endCut - 1
    '                sdd = startCut
    '            ElseIf sdd < startCut Then
    '                edd = startCut - 1
    '                sdd = endCut

    '                If smm = 1 Then
    '                    smm = 12
    '                    syy -= 1
    '                Else
    '                    smm -= 1
    '                End If
    '                addone = False
    '            Else
    '                edd = startCut - 1
    '                sdd = endCut
    '            End If

    '            If addone = True Then
    '                If smm = 12 Then
    '                    emm = 1
    '                    eyy += 1
    '                Else
    '                    emm += 1
    '                End If
    '            End If

    '        ElseIf CUTList.Count = 1 Then
    '            eyy = syy
    '            emm = smm
    '            edd = sdd

    '            If addone = True Then
    '                If smm = 12 Then
    '                    emm = 1
    '                    eyy += 1
    '                Else
    '                    emm += 1
    '                End If
    '            End If
    '        End If

    '        startCutDate = String.Format("{0}{1}{2}", sdd.ToString("D2"), smm.ToString("D2"), syy.ToString("D2"))
    '        endCutDate = String.Format("{0}{1}{2}", edd.ToString("D2"), emm.ToString("D2"), eyy.ToString("D2"))

    '        getDayNumber()
    '        Return String.Format("{0}-{1}", startCutDate, endCutDate)
    '    End Function
    '#End Region

    '#Region "Month Count"
    '    Private currentMonth As Integer = 0
    '    Private dst As dayStatus

    '    Public Sub changeHOLlist(ByVal mo As Integer)
    '        If currentMonth <> mo Then
    '            currentMonth = mo

    '            dst = New dayStatus
    '            Dim dayStatus As New DataSet
    '            Dim da As New OleDbDataAdapter

    '            dayStatus.Tables.Add("HOLIDAY")
    '            dayStatus.Tables.Add("DAYOFF")
    '            dayStatus.Tables.Add("CUTOFF")

    '            da = New OleDbDataAdapter("SELECT * FROM HOLIDAY", SETconn)
    '            da.Fill(dayStatus.Tables(0))

    '            da = New OleDbDataAdapter("SELECT * FROM DAYOFF", SETconn)
    '            da.Fill(dayStatus.Tables(1))

    '            da = New OleDbDataAdapter("SELECT * FROM CUTOFF", SETconn)
    '            da.Fill(dayStatus.Tables(2))

    '            With dayStatus.Tables(0)
    '                dst.HOLIDAY = .Rows(mo - 1).Item("DAYS").ToString
    '                For Each i As String In dst.HOLIDAY.Split(Char.Parse("-"))
    '                    HOLList.Add(i)
    '                Next
    '            End With

    '            With dayStatus.Tables(1)
    '                dst.DAYOFF = .Rows(0).Item(0).ToString
    '                For i As Integer = 0 To dst.DAYOFF.Length - 1
    '                    Dim tmp As String = ""
    '                    Select Case i
    '                        Case 0
    '                            tmp = "SUN"
    '                        Case 1
    '                            tmp = "MON"
    '                        Case 2
    '                            tmp = "TUE"
    '                        Case 3
    '                            tmp = "WED"
    '                        Case 4
    '                            tmp = "THU"
    '                        Case 5
    '                            tmp = "FRI"
    '                        Case 6
    '                            tmp = "SAT"
    '                    End Select
    '                    If dst.DAYOFF.Substring(i, 1) = "1" Then
    '                        DOList.Add(tmp)
    '                    End If
    '                Next
    '            End With

    '            With dayStatus.Tables(2)
    '                dst.CUTOFF = .Rows(0).Item(0).ToString
    '                For Each i As String In dst.CUTOFF.Split(Char.Parse("-"))
    '                    CUTList.Add(i)
    '                Next
    '            End With
    '        End If
    '    End Sub
    '#End Region

#Region "Timesheet"
    Public Sub produceTimesheet(ByVal dateA As Date, ByVal dateB As Date)
        Dim TMTblConn, EmpConn As New OleDb.OleDbConnection
        Dim TMTblDT, EmpDT As New DataTable
        Dim NM, IDNO, timeIN, timeOUT As String
        Dim datetimeIN, datetimeOUT As String()

        Dim newline As String = String.Format("{0,-50}{1}{2,-10}{3}{4,-10}{5}{6,-8}", "", vbTab, "", vbTab, "", vbTab, "")

        '========Paths
        Dim TM As String = String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM)
        Dim EM As String = String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.EL)
        Dim TS As String = String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeSheetFolder, FileList.TS)
        '======

        '=====Connection
        mdbOpen(EM, EmpConn)
        mdbOpen(TM, TMTblConn)
        '=======

        mdbToDT("SELECT * FROM List ORDER BY [Lastname]", EmpDT, EmpConn)

        Directory.CreateDirectory(String.Format("{0}{1}", Application.StartupPath, bioInfo.timeSheetFolder))
        Using w As StreamWriter = File.CreateText(TS)

            w.WriteLine(String.Format("{0}{1}{2}{3}{4}", "Name" & vbTab, "Id No" & vbTab, "Date" & vbTab, "   Time", "    In"))

            Dim rowIndex As Integer = 0
            For Each i As DataRow In EmpDT.Rows
                rowIndex += 1
                NM = addL(String.Format("{0}, {1} {2}.", i.Item("Lastname"), i.Item("Firstname"), i.Item("MI")), 50)
                IDNO = addL(i.Item("ID"), 10)

                mdbToDT(String.Format("SELECT * FROM {0}", IDNO), TMTblDT, TMTblConn)
                If TMTblDT.Rows.Count > 0 Then
                    For Each j As DataRow In TMTblDT.Rows
                        datetimeIN = j.Item("IN").ToString.Split(" ")
                        datetimeOUT = j.Item("OUT").ToString.Split(" ")
                        If Date.Parse(datetimeIN(0)) > dateA And Date.Parse(datetimeIN(0)) < dateB Then
                            timeIN = String.Format("{0}{1}{2}", addL(datetimeIN(0), 10), vbTab, addL(datetimeIN(1), 8))
                            If datetimeOUT(0) = "" Then
                                timeOUT = String.Format("{0}{1}{2}", addL("", 10), vbTab, addL("", 8))
                            ElseIf Not datetimeIN(0) = datetimeOUT(0) Then
                                timeOUT = String.Format("{0}{1}{2}", addL(datetimeOUT(0), 10), vbTab, addL(datetimeOUT(1), 8))
                            Else
                                timeOUT = String.Format("{0}{1}{2}", addL("", 10), vbTab, addL(datetimeOUT(1), 8))
                            End If

                            w.WriteLine(String.Format("{0}{1}{2}{3}{4}", NM, vbTab, IDNO, vbTab, timeIN))
                            w.WriteLine(String.Format("{0}{1}{2}{3}{4}", addL("", 50), vbTab, addL("", 10), vbTab, timeOUT))

                            NM = addL("", 50)
                            IDNO = addL("", 10)

                            If Not rowIndex = EmpDT.Rows.Count Then
                                w.WriteLine(newline)
                            End If
                        End If
                           Next
                End If
            Next
        End Using
        MsgBox(String.Format("DONE!!{0}See file here: {1}", vbNewLine, TS))
    End Sub

    Public Function addL(ByVal str As String, ByVal valLen As Integer, Optional ByVal myChar As String = " ") As String
        If Len(str) < valLen Then
            Do Until Len(str) = valLen
                str = str & myChar
            Loop
        End If
        addL = str
    End Function
#End Region
End Module


