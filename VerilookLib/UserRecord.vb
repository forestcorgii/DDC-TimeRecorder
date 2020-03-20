Imports Neurotec.Biometrics
Imports Neurotec.IO
Imports SEAN.DatabaseManagement
Imports MySql.Data

Public Class UserRecord
    Private _id As Integer
    Private _fname As String = ""
    Private _lname As String = ""
    Private _mname As String = ""
    Private _empid As String = ""
    Private _dept As String = ""
    Private _co As String = ""
    Private _sched As String
    Private _proj As String
    Private _admin As Boolean = False
    Private _active As Boolean = False

    Private _faceimg1 As NSubject
    Private _faceimg2 As NSubject
    Private _faceimg3 As NSubject

#Region "Public Properties"
    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property Active As Boolean
        Get
            Return _active
        End Get
        Set(value As Boolean)
            _active = value
        End Set
    End Property

    Public Property Schedule As String
        Get
            Return _sched
        End Get
        Set(value As String)
            _sched = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _lname
        End Get
        Set(value As String)
            _lname = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return _mname
        End Get
        Set(value As String)
            _mname = value
        End Set
    End Property

    Public Property EmployeeID As String
        Get
            Return _empid
        End Get
        Set(value As String)
            _empid = value
        End Set
    End Property

    Public Property Admin As Boolean
        Get
            Return _admin
        End Get
        Set(value As Boolean)
            _admin = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return _co
        End Get
        Set(value As String)
            _co = value
        End Set
    End Property

    Public Property Department As String
        Get
            Return _dept
        End Get
        Set(value As String)
            _dept = value
        End Set
    End Property

    Public Property Project As String
        Get
            If _proj Is Nothing Then Return ""
            Return _proj
        End Get
        Set(value As String)
            _proj = value
        End Set
    End Property

    Public Property FirstName As String
        Get
            Return _fname
        End Get
        Set(value As String)
            _fname = value
        End Set
    End Property

    Public Property FaceImage_1 As NSubject
        Get
            Return _faceimg1
        End Get
        Set(value As NSubject)
            _faceimg1 = value
        End Set
    End Property

    Public Property FaceImage_2 As NSubject
        Get
            Return _faceimg2
        End Get
        Set(value As NSubject)
            _faceimg2 = value
        End Set
    End Property

    Public Property FaceImage_3 As NSubject
        Get
            Return _faceimg3
        End Get
        Set(value As NSubject)
            _faceimg3 = value
        End Set
    End Property

    Public ReadOnly Property NoFaceImage As Boolean
        Get
            Return FaceImage_1 Is Nothing
        End Get
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return String.Format("{0}, {1} {2}.", LastName, FirstName, MI)
        End Get
    End Property

    Public ReadOnly Property MI As String
        Get
            If MiddleName = "" Then Return ""
            Return MiddleName.Substring(0, 1)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return EmployeeID
    End Function
#End Region

    Sub New()
    End Sub

    Sub New(rdr As MySql.Data.MySqlClient.MySqlDataReader)
        _id = rdr("id")
        _fname = rdr("firstname")
        _lname = rdr("lastname")
        _mname = rdr("middlename")
        _empid = rdr("employee_id")
        _dept = rdr("department")
        _proj = rdr("project")
        _co = rdr("company")
        _sched = rdr("schedule")
        _admin = rdr("admin")
        _active = rdr("active")
        _faceimg1 = GetBlob(rdr("face_img1"))
        _faceimg2 = GetBlob(rdr("face_img2")) '  rdr( "face_img2"))
        _faceimg3 = GetBlob(rdr("face_img3"))
    End Sub
    Private Function GetBlob(blob As Object) As NSubject
        If IsDBNull(blob) = False Then
            Return NSubject.FromMemory(NBuffer.FromArray(blob))
        End If
        Return Nothing
    End Function

    Public Sub saveToDB(dbMngr As MysqlConfiguration, _userTablename As String)
        Dim userExist As Boolean
        Dim rdr As MySql.Data.MySqlClient.MySqlDataReader
        If _id <> Nothing Then
            rdr = dbMngr.ExecuteDataReader("SELECT * FROM `" & _userTablename & "` WHERE `employee_id` = '" & _empid & "'")
            userExist = rdr.HasRows
            rdr.Close()
        End If

        Try
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand()
            cmd.Connection = dbMngr.Connection
            With cmd.Parameters
                .Add("@id", MySqlClient.MySqlDbType.MediumBlob).Value = _id
                .Add("@firstname", MySqlClient.MySqlDbType.String).Value = FirstName
                .Add("@lastname", MySqlClient.MySqlDbType.String).Value = LastName
                .Add("@middlename", MySqlClient.MySqlDbType.String).Value = MiddleName
                .Add("@employee_id", MySqlClient.MySqlDbType.String).Value = EmployeeID
                .Add("@department", MySqlClient.MySqlDbType.String).Value = Department
                .Add("@company", MySqlClient.MySqlDbType.String).Value = Company
                .Add("@schedule", MySqlClient.MySqlDbType.String).Value = Schedule
                .Add("@project", MySqlClient.MySqlDbType.String).Value = Project
                .Add("@admin", MySqlClient.MySqlDbType.String).Value = Admin

                If NoFaceImage = False Then
                    .Add("@active", MySqlClient.MySqlDbType.String).Value = Active
                    .Add("@face_img1", MySqlClient.MySqlDbType.Binary).Value = _faceimg1.GetTemplateBuffer.ToArray
                    .Add("@face_img2", MySqlClient.MySqlDbType.Binary).Value = _faceimg2.GetTemplateBuffer.ToArray
                    .Add("@face_img3", MySqlClient.MySqlDbType.Binary).Value = _faceimg3.GetTemplateBuffer.ToArray
                Else : .Add("@active", MySqlClient.MySqlDbType.String).Value = False
                    .Add("@face_img1", MySqlClient.MySqlDbType.Binary).Value = Nothing
                    .Add("@face_img2", MySqlClient.MySqlDbType.Binary).Value = Nothing
                    .Add("@face_img3", MySqlClient.MySqlDbType.Binary).Value = Nothing
                End If
            End With
            Dim qry As String

            If userExist Then
                qry = "UPDATE `" & _userTablename & "` SET `employee_id`=@employee_id, `firstname`=@firstname, `lastname`=@lastname, `middlename`=@middlename, `project`=@project, `department`=@department," _
                    & " `company`=@company, `schedule`=@schedule, `admin`=@admin, `active`=@active, `face_img1`=@face_img1, `face_img2`=@face_img2, `face_img3`=@face_img3 WHERE `id`=@id"
            Else : qry = "INSERT INTO `" & _userTablename & "` (`firstname`,`lastname`,`middlename`,`employee_id`,`project`,`department`,`company`,`schedule`,`admin`,`active`,`face_img1`,`face_img2`,`face_img3`)" _
                    & "VALUES(@firstname,@lastname,@middlename,@employee_id,@project,@department,@company,@schedule,@admin,@active,@face_img1,@face_img2,@face_img3)"
            End If

            cmd.CommandText = qry
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

#Region "SQLite codes(commented)"
    Sub New(rdr As SQLite.SQLiteDataReader)
        _id = rdr("id")
        _fname = rdr("firstname")
        _lname = rdr("lastname")
        _mname = rdr("middlename")
        _empid = rdr("employee_id")
        _dept = rdr("department")
        _co = rdr("company")
        _sched = rdr("schedule")
        _admin = rdr("admin")
        _active = rdr("active")
        _faceimg1 = NSubject.FromMemory(NBuffer.FromArray(rdr("face_img1")))
        _faceimg2 = NSubject.FromMemory(NBuffer.FromArray(rdr("face_img2"))) '  rdr( "face_img2"))
        _faceimg3 = NSubject.FromMemory(NBuffer.FromArray(rdr("face_img3")))
    End Sub


    'Public Sub saveToDB(dbMngr As SQLiteConfiguration, _userTablename As String)
    '    Dim userExist As Boolean
    '    Dim rdr As SQLite.SQLiteDataReader
    '    If _id <> Nothing Then
    '        rdr = dbMngr.ExecuteDataReader("SELECT * FROM `" & _userTablename & "` WHERE `id` = '" & _id & "'")
    '        userExist = rdr.HasRows
    '        rdr.Close()
    '    End If

    '    Try
    '        Dim cmd As New SQLite.SQLiteCommand(dbMngr.Connection)
    '        With cmd.Parameters
    '            .Add("@id", DbType.Int32).Value = _id
    '            .Add("@firstname", DbType.String).Value = FirstName
    '            .Add("@lastname", DbType.String).Value = LastName
    '            .Add("@middlename", DbType.String).Value = MiddleName
    '            .Add("@employee_id", DbType.String).Value = EmployeeID
    '            .Add("@department", DbType.String).Value = Department
    '            .Add("@company", DbType.String).Value = Company
    '            .Add("@schedule", DbType.String).Value = Schedule
    '            .Add("@admin", DbType.String).Value = Admin
    '            .Add("@active", DbType.String).Value = Active

    '            .Add("@face_img1", DbType.Binary).Value = _faceimg1.GetTemplateBuffer.ToArray
    '            .Add("@face_img2", DbType.Binary).Value = _faceimg2.GetTemplateBuffer.ToArray
    '            .Add("@face_img3", DbType.Binary).Value = _faceimg3.GetTemplateBuffer.ToArray
    '        End With
    '        Dim qry As String

    '        If userExist Then
    '            qry = "UPDATE `" & _userTablename & "` SET `employee_id`=@employee_id, `firstname`=@firstname, `lastname`=@lastname, `middlename`=@middlename, `department`=@department," _
    '                & " `company`=@company, `schedule`=@schedule, `admin`=@admin, `active`=@active, `face_img1`=@face_img1, `face_img2`=@face_img2, `face_img3`=@face_img3 WHERE `id`=@id"
    '        Else : qry = "INSERT INTO `" & _userTablename & "` (`firstname`,`lastname`,`middlename`,`employee_id`,`department`,`company`,`schedule`,`admin`,`active`,`face_img1`,`face_img2`,`face_img3`)" _
    '                & "VALUES(@firstname,@lastname,@middlename,@employee_id,@department,@company,@schedule,@admin,@active,@face_img1,@face_img2,@face_img3)"
    '        End If
    '        cmd.CommandText = qry
    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Utils.ShowException(ex)
    '    End Try
    'End Sub
#End Region

End Class