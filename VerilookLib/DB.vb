Imports System.Xml.Serialization
Imports System.Windows.Forms

Public Class DB
#Region "SQLite"
    Public Const SQLiteConfigFileExtension = ".sqlite.config.xml"
    <XmlRoot("SQLiteConfiguration")> Public Class SQLiteConfiguration
        <XmlIgnore> Public Connection As New SQLite.SQLiteConnection
        Public DBPath As String
        Public Password As String

        Sub New(_dbpath As String, Optional _password As String = "", Optional openNow As Boolean = False)
            DBPath = _dbpath
            Password = _password
            If openNow Then
                Open()
            End If
        End Sub

        Public Function CloneConnection() As SQLite.SQLiteConnection
            Dim con As SQLite.SQLiteConnection = Nothing
            con = Connection.Clone
            Return con
        End Function

        Public Sub Open()
            SQLiteConfiguration.Open(DBPath, Connection, Password)
        End Sub

        Public Shared Sub Open(_dbpath As String, ByRef _con As SQLite.SQLiteConnection, Optional _password As String = "")
            Try
                _con = New SQLite.SQLiteConnection("Data Source=""" & _dbpath & """;Password=" & _password & "")
                _con.Open()
            Catch ex As Exception
                MessageBox.Show("Can't connect right now, Please try again.", "Error: SQL Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub Close()
            Connection.Close()
            Connection.Dispose()
        End Sub

        Public Shared Function CreateSchema(filename As String)
            Try
                SQLite.SQLiteConnection.CreateFile(filename)
                Return True
            Catch : Return False
            End Try
        End Function

        Public Sub TryCreateTable(ByVal tbl As String, ByVal flds As String(), Optional overwrite As Boolean = False)
            If CheckTable(tbl) Then
                If Not overwrite Then Exit Sub
                ExecuteQuery("DROP TABLE `" & tbl & "`")
            End If

            CreateTable(tbl, flds)
        End Sub
        Public Sub CreateTable(ByVal tbl As String, ByVal flds As String())
            SQLiteConfiguration.CreateTable(tbl, flds, Connection)
        End Sub
        Public Shared Sub CreateTable(ByVal tbl As String, ByVal flds As String(), ByVal con As SQLite.SQLiteConnection)
            Dim qry As String = String.Format("CREATE TABLE `{0}`(", tbl)
            For i As Integer = 0 To flds.Length - 1
                qry &= IIf(i = 0, flds(i), "," & flds(i))
            Next
            qry &= ")"

            SQLiteConfiguration.ExecuteQuery(qry, con)
        End Sub

        Public Shared Sub AlterTablename(tablename As String, newTablename As String, con As SQLite.SQLiteConnection)
            SQLiteConfiguration.ExecuteDataReader("Alter Table `" & tablename & "` Rename To `" & newTablename & "`", con)
        End Sub

        Public Sub AlterTablename(tablename As String, newTablename As String)
            SQLiteConfiguration.AlterTablename(tablename, newTablename, Connection)
        End Sub

        Public Function ExecuteDataReader(query As String) As SQLite.SQLiteDataReader
            Return SQLiteConfiguration.ExecuteDataReader(query, Connection)
        End Function

        Public Shared Function ExecuteDataReader(query As String, _con As SQLite.SQLiteConnection) As SQLite.SQLiteDataReader
            Return New SQLite.SQLiteCommand(query, _con).ExecuteReader
        End Function

        Public Function ExecuteQuery(query As String) As Boolean
            Return SQLiteConfiguration.ExecuteQuery(query, Connection)
        End Function

        Public Shared Function ExecuteQuery(query As String, _con As SQLite.SQLiteConnection) As Boolean
            Try
                Dim command As New SQLite.SQLiteCommand(query, _con)
                command.ExecuteNonQuery()
                command.Dispose()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message & " ExecuteQuery")
                Return False
            End Try
        End Function

        Public Sub Insert(ByVal tbl As String, ByVal fld As String(), ByVal val As Object())
            SQLiteConfiguration.Insert(tbl, fld, val, Connection)
        End Sub
        Public Shared Sub Insert(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), con As SQLite.SQLiteConnection)
            Dim qry As String = String.Format("INSERT INTO `{0}` (", tbl)
            Dim valtype As String = ""

            For i As Integer = 0 To fld.Length - 1
                Dim f As String = fld(i)
                If f = fld(0) Then
                    qry &= String.Format("`{0}`", f)
                Else
                    qry &= String.Format(",`{0}`", f)
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

            SQLiteConfiguration.ExecuteQuery(qry, con)
        End Sub
        Public Sub Update(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal condition As Object())
            SQLiteConfiguration.Update(tbl, fld, val, condition, Connection)
        End Sub
        Public Shared Sub Update(ByVal tbl As String, ByVal fld As String(), ByVal val As Object(), ByVal condition As Object(), ByVal con As SQLite.SQLiteConnection)
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

            SQLiteConfiguration.ExecuteQuery(qry, con)
        End Sub

        Public Function ToDT(qry As String) As DataTable
            Return SQLiteConfiguration.ToDT(qry, Connection)
        End Function
        Public Shared Function ToDT(qry As String, _con As SQLite.SQLiteConnection) As DataTable
            Try
                Dim dt As New DataTable
                Dim command As New SQLite.SQLiteDataAdapter(qry, _con)
                command.Fill(dt)
                command.Dispose()
                Return dt
            Catch ex As Exception
                MsgBox(ex.Message & " ExecuteQuery")
                Return Nothing
            End Try
        End Function

        Public Function CheckTable(tbl As String) As Boolean
            Return SQLiteConfiguration.CheckTable(tbl, Connection)
        End Function
        Public Function GetTables() As List(Of String)
            Return SQLiteConfiguration.GetTables(Connection)
        End Function
        Public Shared Function CheckTable(tbl As String, _con As SQLite.SQLiteConnection) As Boolean
            Return SQLiteConfiguration.GetTables(_con).Contains(tbl.ToLower)
        End Function
        Public Shared Function GetTables(_con As SQLite.SQLiteConnection) As List(Of String)
            Dim lst As New List(Of String)
            Using rdr As SQLite.SQLiteDataReader = SQLiteConfiguration.ExecuteDataReader("SELECT `name` FROM sqlite_master WHERE type='table';", _con)
                While rdr.Read
                    lst.Add(rdr.Item(0).ToString.ToLower)
                End While
            End Using
            Return lst
        End Function
    End Class
#End Region
End Class
