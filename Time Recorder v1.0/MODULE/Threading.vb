Imports System.Threading
Imports System.Object
Imports System.IO.StreamReader
Imports System.IO.StreamWriter
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports IDCSIBiometrics.VBNETSample

Module Threading
    Public DAYOFF As Thread
    Public CUTOFF As Thread
    Public HOLIDAY As Thread
    Public ABSENT As Thread

    Public Sub startTask(ByVal task As String)
        Select Case task
            Case "ABSENT"
                ABSENT = New System.Threading.Thread(AddressOf doAB)
                ABSENT.Start()
            Case "HOLIDAY"
                HOLIDAY = New System.Threading.Thread(AddressOf doHO)
                HOLIDAY.Start()
            Case "DAYOFF"
                DAYOFF = New System.Threading.Thread(AddressOf doDO)
                DAYOFF.Start()
            Case "CUTOFF"
                CUTOFF = New System.Threading.Thread(AddressOf doTimeSheet)
                CUTOFF.Start()
        End Select
    End Sub

    Private Sub doAB()
        'put code here
        insertFlag("AB", timeInfo.inDT)
        ABSENT.Abort()
    End Sub

    Private Sub doDO()
        'put code here
        insertFlag("OFF", timeInfo.inDT)
        DAYOFF.Abort()
    End Sub

    Private Sub doHO()
        'put code here
        insertFlag("HOL", timeInfo.inDT)
        HOLIDAY.Abort()
    End Sub

    Private Sub doTimeSheet()
        'put code here
        produceTimeSheet()
        CUTOFF.Abort()
    End Sub

    Private Sub produceTimeSheet()
        Dim TMDT As New DataTable
        Dim tbls As New System.Collections.Generic.List(Of String)
        tbls = getTables(TMconn)

        'IO.Directory.Delete(bioInfo.timeSheetPath, True)
        'IO.Directory.CreateDirectory(bioInfo.timeSheetPath)

        For Each tbl As String In tbls
            TMDT = New DataTable
            mdbToDT("SELECT * FROM " & tbl, TMDT, SETconn)

            Dim DT, RHR, ROT, ND, AB, HOL, DOFF As String
            Dim TMIN, TMOUT As String()
            Dim contents As String = """""DATE"""""",""""""IN"""""",""""""OUT"""""",""""""R_HRS"""""",""""""R_OT"""""",""""""ND"""""
            For Each rw As DataRow In TMDT.Rows
                TMIN = rw.Item("IN").ToString.Split(Char.Parse(" "))
                TMOUT = rw.Item("OUT").ToString.Split(Char.Parse(" "))

                DT = rw.Item("DATE").ToString
                RHR = rw.Item("HR").ToString
                ROT = rw.Item("OT").ToString
                ND = rw.Item("ND").ToString

                'FLAG
                AB = rw.Item("AB").ToString
                HOL = rw.Item("HOL").ToString
                DOFF = rw.Item("OFF").ToString
                '-----

                If HOL = "1" Then
                    contents &= String.Format("{0}""""{1}"""""",""""""{2}"""""",""""""{3}"""""",""""""{4}"""""",""""""{5}"""""",""""""{6}""""", Environment.NewLine, DT, "HOLIDAY", "", "", "", "")
                ElseIf DOFF = "1" Then
                    contents &= String.Format("{0}""""{1}"""""",""""""{2}"""""",""""""{3}"""""",""""""{4}"""""",""""""{5}"""""",""""""{6}""""", Environment.NewLine, DT, "DAY OFF", "", "", "", "")
                ElseIf AB = "1" Then
                    contents &= String.Format("{0}""""{1}"""""",""""""{2}"""""",""""""{3}"""""",""""""{4}"""""",""""""{5}"""""",""""""{6}""""", Environment.NewLine, DT, "ABSENT", "", "", "", "")
                Else
                    contents &= String.Format("{0}""""{1}"""""",""""""{2}"""""",""""""{3}"""""",""""""{4}"""""",""""""{5}"""""",""""""{6}""""", Environment.NewLine, DT, TMIN(1), TMOUT(1), RHR, ROT, ND)
                End If
            Next
            File.WriteAllText(Application.StartupPath & "\" & bioInfo.timeSheetFolder & "\" & tbl & ext.csvEx, contents)
        Next
    End Sub

    Private Sub insertFlag(ByVal fld As String, ByVal DT As String)
        'Dim FLAGDT As New DataTable
        'Dim tbls As New List(Of String)
        'tbls = getTables(TMconn)

        'For Each tbl As String In tbls
        '    FLAGDT = New DataTable
        '    mdbToDT("SELECT * FROM " & tbl, FLAGDT, SETconn)
        '    If FLAGDT.Rows.Count > dayNUM Then
        '        mdbInsert(tbl, New String() {"DATE", fld}, New String() {DT, "1"}, TMconn)
        '    End If
        'Next
    End Sub
End Module


