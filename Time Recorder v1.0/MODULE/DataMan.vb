Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Collections.Generic
Imports System.Windows.Forms

Module DataMan

    Public empDS As New DataSet

    Public Sub addTimeToDgv(ByRef dgv As DataGridView, ByVal name As String, ByVal timeIN As String, ByVal timeOUT As String, ByVal total As String)
        dgv.Rows.Add(name, timeIN, timeOUT, total)
    End Sub

    Public Function getTables(ByVal con As OleDbConnection) As List(Of String)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim dt As New DataTable
        getTables = New List(Of String)
        Dim restrictions() As String = New String(3) {}
        restrictions(3) = "Table"
        dt = con.GetSchema("Tables", restrictions)
        For i As Integer = 0 To dt.Rows.Count - 1
            getTables.Add(dt.Rows(i)(2).ToString)
        Next
        If con.State = ConnectionState.Open Then con.Close()
        Return getTables
    End Function

    Public Sub getDataFromTimeTable()
        Dim tbl As New List(Of String)
        tbl = getTables(TMconn)

        For Each t As String In tbl
            '   EmpTimeTable.fullName = t
            '     mdbToDT(String.Format("SELECT * FROM {0} "))
        Next
    End Sub

    Public Class EmpList
        Public fname As String
        Public IDnumber As String

        Public Sub New()

        End Sub

        Public Property fullname() As String
            Get
                Return fname
            End Get
            Set(ByVal value As String)
                fname = value
            End Set
        End Property

        Public Property ID() As String
            Get
                Return IDnumber
            End Get
            Set(ByVal value As String)
                IDnumber = value
            End Set
        End Property
    End Class
End Module
