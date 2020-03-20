Imports System.IO
Imports System.Windows.Forms
Imports Neurotec.Biometrics

Public Class UserCollection
    Inherits List(Of UserRecord)

    'Public Shared DefaultUserTablename As String = "tbluser"
    'Public Shared DefaultUserFieldTypes As String() = {"`id` INTEGER PRIMARY KEY AUTOINCREMENT", "`name` TEXT(50)", "`face_img1` BLOB"}
    'Public Shared DefaultUserFields As String() = {"id", "name", "face_img1"}


    Sub New()

    End Sub

    Public Sub CollectUsers(tablename As String, databaseManager As SEAN.DatabaseManagement.MysqlConfiguration, SingleImageRecognition As Boolean)
        UserCollection.CollectUsers(Me, tablename, databaseManager, SingleImageRecognition)
    End Sub

   
    Public Shared Sub CollectUsers(ByRef _userCollection As UserCollection, tablename As String, databaseManager As SEAN.DatabaseManagement.MysqlConfiguration, SingleImageRecognition As Boolean)
        Dim rdr As MySql.Data.MySqlClient.MySqlDataReader = databaseManager.ExecuteDataReader("SELECT * FROM `" & tablename & "`")
        'Collect the Users
        _userCollection = New UserCollection
        While rdr.Read
            _userCollection.Add(New UserRecord(rdr))
        End While
        ' Create subjects from selected templates
        For i As Integer = 0 To _userCollection.Count - 1
            With _userCollection.Item(i)
                If .Active Then
                    .FaceImage_1.Id = .EmployeeID & "_1"
                    If Not SingleImageRecognition Then
                        .FaceImage_2.Id = .EmployeeID & "_2"
                        .FaceImage_3.Id = .EmployeeID & "_3"
                    End If
                End If
            End With
        Next i
        rdr.Close()
    End Sub

    Public Function Lookup(id As String) As UserRecord
        Dim userFound As UserRecord = (From res In Me Where res.EmployeeID.Equals(id) Take 1 Select res).FirstOrDefault
        Return userFound
    End Function

    Public Overloads Sub Sort()
        Dim tmp As New UserCollection()
        tmp.AddRange(Me)
        Me.Clear()
        Me.AddRange((From res As UserRecord In tmp Select res Order By res.FullName Ascending).ToList)
    End Sub

#Region "Commented"
    Public Sub CollectUsers(tablename As String, databaseManager As SEAN.DatabaseManagement.SQLiteConfiguration, SingleImageRecognition As Boolean)
        UserCollection.CollectUsers(Me, tablename, databaseManager, SingleImageRecognition)
    End Sub

    Public Shared Sub CollectUsers(ByRef _userCollection As UserCollection, tablename As String, databaseManager As SEAN.DatabaseManagement.SQLiteConfiguration, SingleImageRecognition As Boolean)
        Dim rdr As SQLite.SQLiteDataReader = databaseManager.ExecuteDataReader("SELECT * FROM `" & tablename & "`")
        'Collect the Users
        _userCollection = New UserCollection
        While rdr.Read
            _userCollection.Add(New UserRecord(rdr))
        End While
        ' Create subjects from selected templates
        For i As Integer = 0 To _userCollection.Count - 1
            With _userCollection.Item(i)
                If .Active Then
                    .FaceImage_1.Id = .EmployeeID & "_1"
                    If Not SingleImageRecognition Then
                        .FaceImage_2.Id = .EmployeeID & "_2"
                        .FaceImage_3.Id = .EmployeeID & "_3"
                    End If
                End If
            End With
        Next i
        rdr.Close()
    End Sub

#End Region
End Class
