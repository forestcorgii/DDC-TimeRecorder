Imports System.IO
Imports System.Data.OleDb
Imports VerilookLib

Public Class sfrmUserProfiles
    Private filteredUserDB As New UserCollection
    Public userDB As New UserCollection
    Private userInfo As New UserRecord
    Public FaceManager As VerilookManager
    Public DatabaseManager As SEAN.DatabaseManagement.SQLiteConfiguration

#Region "Public Property"
    Public Property Schedule As String
        Get
            Return cbSched.Text
        End Get
        Set(value As String)
            cbSched.Text = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return cbCompany.Text
        End Get
        Set(value As String)
            cbCompany.Text = value
        End Set
    End Property

    Public Property Department As String
        Get
            Return cbDepartment.Text
        End Get
        Set(value As String)
            cbDepartment.Text = value
        End Set
    End Property

    Public Property Project As String
        Get
            Return cbProject.Text
        End Get
        Set(value As String)
            cbProject.Text = value
        End Set
    End Property


    Public Property FirstName As String
        Get
            Return tbFirstName.Text
        End Get
        Set(value As String)
            tbFirstName.Text = value
        End Set
    End Property

    Public Property LastName As String
        Get
            Return tbLastName.Text
        End Get
        Set(value As String)
            tbLastName.Text = value
        End Set
    End Property

    Public Property MiddleName As String
        Get
            Return tbMiddleName.Text
        End Get
        Set(value As String)
            tbMiddleName.Text = value
        End Set
    End Property

    Public Property EmployeeNumber As String
        Get
            Return tbEmployeeNumber.Text
        End Get
        Set(value As String)
            tbEmployeeNumber.Text = value
        End Set
    End Property

    Public Property Admin As Boolean
        Get
            Return cbAdmin.Checked
        End Get
        Set(value As Boolean)
            cbAdmin.Checked = value
        End Set
    End Property

    Public Property Active As Boolean
        Get
            Return cbActive.Checked
        End Get
        Set(value As Boolean)
            cbActive.Checked = value
        End Set
    End Property


    Private Function checkFaceAvailable(_user As UserRecord) As Boolean
        Dim value As Boolean = Not (_user.FaceImage_1 Is Nothing Or _user.FaceImage_2 Is Nothing Or _user.FaceImage_3 Is Nothing)
        If value Then
            lbMessage2.ForeColor = Color.MidnightBlue
            lbMessage2.Text = "Your Face has been registered."
        Else
            lbMessage2.ForeColor = Color.Maroon
            lbMessage2.Text = "Your Face is not yet registered."
        End If
        Return value
    End Function

#End Region

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub sfrmUserProfiles_Load(sender As Object, e As EventArgs) Handles Me.Load
        readUserDB(userDB)
        cbSearchOption.SelectedIndex = 0
    End Sub

    Public Sub readUserDB(_userDB As UserCollection)
        dgv.Rows.Clear()
        For Each userRec As UserRecord In _userDB
            With userRec
                dgv.Rows.Add(userRec, .FirstName, .LastName, .MI, .Company, .Project, .Department, .Schedule, .Active, .Admin)
            End With
        Next
    End Sub

    Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
        If Not dgv.Rows.Count = 0 And dgv.CurrentRow IsNot Nothing Then
            userInfo = dgv.CurrentRow.Cells(0).Value
            With userInfo
                EmployeeNumber = .EmployeeID
                FirstName = .FirstName
                LastName = .LastName
                MiddleName = .MiddleName
                Company = .Company
                Project = .Project
                Department = .Department
                Schedule = .Schedule
                Admin = .Admin
                Active = .Active

                cbActive.Enabled = (.NoFaceImage = False)
            End With
            checkFaceAvailable(userInfo)
        End If
    End Sub


    Private Sub btnRegFace_Click(sender As Object, e As EventArgs) Handles btnRegFace.Click
        If checkFaceAvailable(userInfo) Then
            If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Else : Exit Sub
            End If
        End If

        FaceManager.editFaceTemplate(userInfo)
        checkFaceAvailable(userInfo)
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addUser As New AddingUser.frmAddUser With {.FaceManager = FaceManager, .NewUserDB = userDB}
        If addUser.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FaceManager.GetTemplate()
            ' userDB = addUser.NewUserDB
            VerilookLib.UserCollection.CollectUsers(userDB, Programs.UserTablename, FaceManager.MySQLDatabaseManager, False)
            readUserDB(userDB)

            'If Not addUser.NewUserDB.ToString = "" Then
            'userDB.Add(addUser.NewUserDB)
            'With addUser.NewUserDB
            '    dgv.Rows.Add(addUser.NewUserDB, .FirstName, .LastName, .MI, .Company, .Department, .Schedule, .Active, .Admin)
            'End With
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With userInfo
            If Not .EmployeeID = EmployeeNumber Then
                DatabaseManager.AlterTablename(.EmployeeID, EmployeeNumber)
            End If

            .EmployeeID = EmployeeNumber
            .Project = Project
            .Department = Department
            .Schedule = Schedule
            .Company = Company
            .FirstName = FirstName
            .LastName = LastName
            .MiddleName = MiddleName
            .Admin = Admin
            .Active = Active

            .saveToDB(FaceManager.MySQLDatabaseManager, Programs.UserTablename)
        End With

        With dgv.CurrentRow
            .Cells(0).Value = userInfo
            .Cells(1).Value = FirstName
            .Cells(2).Value = LastName
            .Cells(3).Value = MiddleName
            .Cells(4).Value = Company
            .Cells(5).Value = Project
            .Cells(6).Value = Department
            .Cells(7).Value = Schedule
            .Cells(8).Value = Active
            .Cells(9).Value = Admin
        End With

        MsgBox("All Changes Has been Saved.")
    End Sub

    Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cbSearchAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbSearchAdmin.CheckedChanged
        If tbSearch.Text = "" Then
            filteredUserDB = New UserCollection
            filteredUserDB.AddRange((From res In userDB Where res.Admin = cbSearchAdmin.Checked).ToList)
            readUserDB(filteredUserDB)
        Else : btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cbSearchAvailable_CheckedChanged(sender As Object, e As EventArgs) Handles cbSearchActive.CheckedChanged
        If tbSearch.Text = "" Then
            filteredUserDB = New UserCollection
            filteredUserDB.AddRange((From res In userDB Where res.Active = cbSearchActive.Checked).ToList)
            readUserDB(filteredUserDB)
        Else : btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        filteredUserDB = New UserCollection
        Select Case cbSearchOption.Text.ToUpper
            Case "EMPLOYEE NUMBER"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.EmployeeID.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case "COMPANY"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.Company.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case "DEPARTMENT"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.Department.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case "FIRSTNAME"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.FirstName.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case "LASTNAME"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.LastName.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case "MIDDLE INITIAL"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.MI.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Active = cbSearchActive.Checked).ToList)
            Case Else
                Exit Sub
        End Select
        readUserDB(filteredUserDB)
    End Sub
End Class