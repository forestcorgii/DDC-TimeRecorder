Imports System.Data.OleDb
Imports System.IO

Module MDB

    Public Provider As String = "Provider=Microsoft.JET.OLEDB.4.0;Data Source="
    Public TMconn, SETconn, IOconn As System.Data.OleDb.OleDbConnection


#Region "OPEN"
    Public Sub mdbOpen(ByVal DatabaseFullPath As String, ByRef con As OleDbConnection)
        Try
            con = New System.Data.OleDb.OleDbConnection(Provider & DatabaseFullPath & ";User Id=admin;Password=;")
        Catch ex As System.Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

#Region "Create"
    Public Sub mdbCreate(ByVal DatabaseFullPath As String)
        Try
            Dim cat As New ADOX.Catalog
            cat.Create(Provider & DatabaseFullPath & ";Jet OLEDB:Engine Type=5")
        Catch Ex As System.Exception
        End Try
    End Sub

    Public Sub mdbCreateTable(ByVal tbl As String, ByVal flds As String(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("CREATE TABLE {0}(", tbl)
        For Each fld As String In flds
            Dim tmp() As String = fld.Split(Char.Parse("-"))
            If fld = flds(0) Then
                qry &= String.Format("[{0}] {1}", tmp(0), tmp(1))
            Else
                qry &= String.Format(",[{0}] {1}", tmp(0), tmp(1))
            End If
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub
#End Region

#Region "Convert"
    Public Sub mdbToDT(ByVal qry As String, ByRef dt As System.Data.DataTable, ByVal con As OleDbConnection)
        Try
            dt = New DataTable
            Dim da As New OleDbDataAdapter(qry, con)
            da.Fill(dt)
        Catch
        End Try
    End Sub
#End Region

#Region "Commands"
    Public Sub executeQRY(ByVal Qry As String, ByVal con As OleDbConnection)
        Try
            Dim com As New OleDbCommand(Qry, con)
            If con.State = System.Data.ConnectionState.Closed Then con.Open()
            com.ExecuteNonQuery()
            If con.State = System.Data.ConnectionState.Closed Then con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub mdbInsert(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("INSERT INTO {0} (", tbl)
        Dim valtype As String = ""

        For i As Integer = 0 To fld.Length - 1
            Dim f As String = fld(i)
            If f = fld(0) Then
                qry &= String.Format("[{0}]", f)
            Else
                qry &= String.Format(",[{0}]", f)
            End If
        Next

        qry &= ") VALUES("

        For i As Integer = 0 To val.Length - 1
            Dim v = val(i)
            valtype = TypeName(v)
            If i = 0 Then
                If valtype = "String" Then
                    qry &= String.Format("'{0}'", v)
                Else
                    qry &= String.Format("{0}", v)
                End If
            Else
                If valtype = "String" Then
                    qry &= String.Format(",'{0}'", v)
                Else
                    qry &= String.Format(",{0}", v)
                End If
            End If
        Next
        qry &= ")"

        executeQRY(qry, con)
    End Sub

    Public Sub mdbUpdate(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal condition As Object(), ByVal con As OleDbConnection)
        Dim qry As String = String.Format("UPDATE {0} SET ", tbl)
        Dim valtype As String = ""

        If fld.Length = val.Length Then
            For f As Integer = 0 To fld.GetUpperBound(0)
                valtype = TypeName(val(f))
                If f = 0 Then
                    If valtype = "String" Then
                        qry &= String.Format("[{0}]='{1}'", fld(f), val(f))
                    Else
                        qry &= String.Format("[{0}]={1}", fld(f), val(f))
                    End If
                Else
                    If valtype = "String" Then
                        qry &= String.Format(",[{0}]='{1}'", fld(f), val(f))
                    Else
                        qry &= String.Format(",[{0}]={1}", fld(f), val(f))
                    End If
                End If
            Next
        End If

        If Not condition Is Nothing Then
            If TypeName(condition(1)) = "String" Then
                qry &= String.Format(" WHERE {0} = '{1}'", condition(0), condition(1))
            Else
                qry &= String.Format(" WHERE {0} = {1}", condition(0), condition(1))
            End If
        End If

        executeQRY(qry, con)
    End Sub
#End Region

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

End Module
