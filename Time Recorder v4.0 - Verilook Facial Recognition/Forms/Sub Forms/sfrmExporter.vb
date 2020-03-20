Imports System.IO
Imports SEAN.DatabaseManagement
Imports VerilookLib.DB
Imports VerilookLib

Public Class sfrmExporter

    Public DBMngr As SEAN.DatabaseManagement.MysqlConfiguration
    Public Users As UserCollection
    Sub New() '_users As UserCollection)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '     Users = _users
    End Sub
#Region "PUBLIC PROPERTIES"
    Public ReadOnly Property DateA() As Date
        Get
            Return DTP1.Value
        End Get
    End Property

    Public ReadOnly Property DateB() As Date
        Get
            Return DTP2.Value
        End Get
    End Property
#End Region

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If DateA <> DateB Then
            If FBD.ShowDialog = Windows.Forms.DialogResult.OK Then
                produceTimesheet(DateA, DateB, FBD.SelectedPath)
                Me.Close()
            End If
        Else
            MsgBox("Date range should be al least 1 day apart.")
        End If
    End Sub

#Region "Timesheet"
    Public Sub produceTimesheet(ByVal dateA As Date, ByVal dateB As Date, outpath As String)
        '   Dim TMTblConn As SQLiteConfiguration
        Try

            Dim TMTblDT, EmpDT As New DataTable

            Dim newline As String = "{0,-50}" & vbTab & "{1,-10}" & vbTab & "{2,-10}" & vbTab & "{3,-8}" 'ROW FORMAT

            '========Paths
            Dim TS As String = String.Format("{0}\{1}", outpath, FileList.TS)
            '======

            '=====Connection
            'TMTblConn = New SQLiteConfiguration(String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM, ext.sqliteEx), openNow:=True)
            '=======

            Directory.CreateDirectory(String.Format("{0}{1}", Application.StartupPath, bioInfo.timeSheetFolder))
            Using w As StreamWriter = File.CreateText(TS)

                w.WriteLine("Name" & vbTab & "Id No" & vbTab & "Date" & vbTab & "   Time    In") 'HEADER

                PB1.Maximum = Users.Count
                PB1.Value = 0
                Users.Sort()
                For Each i As UserRecord In Users

                    TMTblDT = DBMngr.ToDT(String.Format("SELECT * FROM `faces_schema`.`tbltimelog` WHERE employee_id='{0}'", i.EmployeeID))
                    If TMTblDT.Rows.Count > 0 Then
                        Dim currentDay As String = ""

                        Dim firstLine As Boolean = True
                        For j As Integer = 0 To TMTblDT.Rows.Count - 1
                            Dim row As DataRow = TMTblDT.Rows(j)
                            Dim day As String = ""
                            Dim datetime As String() = row.Item("time_in").ToString.Split(" ")
                            Dim time As Date = Date.Parse(row.Item("time_in").ToString)
                            Dim _date = row.Item("logdate").ToString

                            If dateA <= Date.Parse(_date) And dateB >= Date.Parse(_date) Then
                                If firstLine Then
                                    currentDay = datetime(0)
                                    day = datetime(0)

                                    w.WriteLine(String.Format(newline, "", "", "", "")) 'NEWLINE
                                    w.WriteLine(String.Format(newline, i.FullName, i.EmployeeID, day, time.ToString("yyyy-MM-dd HH:mm:ss"))) ' time(1))) 'WRITE TIMELOG
                                    firstLine = False
                                Else
                                    If Not currentDay = datetime(0) Then
                                        currentDay = datetime(0)
                                        day = datetime(0)
                                    End If
                                    w.WriteLine(String.Format(newline, "", "", day, time.ToString("yyyy-MM-dd HH:mm:ss"))) 'WRITE TIMELOG
                                End If
                            End If
                        Next
                    End If
                    PB1.Value += 1
                    Application.DoEvents()
                Next
            End Using
            MsgBox(String.Format("DONE!!{0}See file here: {1}", vbNewLine, TS))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub frmExporter_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Now.Day < 5 And Now.Day > 20 Then
            DTP1.Value = adjustDate(20)
            DTP2.Value = adjustDate(4)
        Else
            DTP1.Value = adjustDate(5)
            DTP2.Value = adjustDate(19, False)
        End If
    End Sub

    Private Function adjustDate(day As Integer, Optional adjustMonth As Boolean = True) As Date
        Dim MM As Integer = Now.Month
        Dim yyyy As Integer = Now.Year
        Dim dd As Integer = Now.Day + 3

        If dd < day And adjustMonth Then
            MM -= 1
            If MM = 0 Then
                yyyy -= 1 : MM = 12
            End If
        End If

        Return Date.Parse(String.Format("{0}/{1}/{2}", MM, day, yyyy))
    End Function

End Class