Imports System.IO
Imports System.Data.OleDb

Public Class frmUserProfiles
    Private filteredUserDB As New UserDatabase(False)
    Public userDB As New UserDatabase(False)
    Private userInfo As New UserRecords

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

    Public Property ID As String
        Get
            Return tbID.Text
        End Get
        Set(value As String)
            tbID.Text = value
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

    Public Property Available As Boolean
        Get
            Return cbAvailable.Checked
        End Get
        Set(value As Boolean)
            cbAvailable.Checked = value

            If value Then
                lbMessage1.ForeColor = Color.MidnightBlue
                lbMessage1.Text = "Your Fingerprint has been registered."
            Else
                lbMessage1.ForeColor = Color.Maroon
                lbMessage1.Text = "Your Fingerprint is not yet registered."
            End If
        End Set
    End Property

#End Region

    Sub New(ByRef _userDB As UserDatabase)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        userDB = _userDB
        readUserDB(userDB)
        cbSearchOption.SelectedIndex = 0
    End Sub

    Public Sub readUserDB(_userDB As UserDatabase)
        dgv.Rows.Clear()
        For Each userRec As UserRecords In _userDB
            With userRec
                dgv.Rows.Add(userRec, .EmployeeNumber, .FirstName, .LastName, .MI, .Company, .Department, .Schedule, .Available, .Admin)
            End With
        Next
    End Sub

    Private Sub dgv_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgv.CurrentCellChanged
        If Not dgv.Rows.Count = 0 And dgv.CurrentRow IsNot Nothing Then
            userInfo = dgv.CurrentRow.Cells(0).Value
            With userInfo
                ID = .ID
                EmployeeNumber = .EmployeeNumber
                FirstName = .FirstName
                LastName = .LastName
                MiddleName = .MiddleName
                Company = .Company
                Department = .Department
                Schedule = .Schedule
                Available = .Available
                Admin = .Admin
            End With
        End If
    End Sub

    Private Sub btnRegPrint_Click(sender As Object, e As EventArgs) Handles btnRegPrint.Click
        If Available Then
            If Not MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        Dim frmPrint As New frmPrintReader(userInfo)
        frmPrint.ShowDialog()
        If File.Exists(Path.Combine(Application.StartupPath, TempUsername & ext.datEx)) Then
            File.Delete(Path.Combine(Application.StartupPath, ID & ext.datEx))
            FileSystem.Rename(Path.Combine(Application.StartupPath, TempUsername & ext.datEx), Path.Combine(Application.StartupPath, ID & ext.datEx))
            userInfo = frmPrint.UserDB
            Available = True
            MsgBox("New Fingerprint has been saved.")
            UserTables = getTables(TMconn)
        End If
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addUser As New AddingUser.frmAddUser
        addUser.ShowDialog()
        If Not addUser.NewUserDB.Empty Then
            userDB.Add(addUser.NewUserDB)

            With addUser.NewUserDB
                dgv.Rows.Add(addUser.NewUserDB, .EmployeeNumber, .FirstName, .LastName, .MI, .Company, .Department, .Schedule, .Available, .Admin)
            End With
            UserTables = getTables(TMconn)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With userInfo
            .EmployeeNumber = EmployeeNumber
            .Department = Department
            .Schedule = Schedule
            .Company = Company
            .FirstName = FirstName
            .LastName = LastName
            .MiddleName = MiddleName
            .Admin = Admin
            .Available = Available
            .WriteToFile(.ID & ext.xmlEx)
        End With

        With dgv.CurrentRow
            .Cells(1).Value = EmployeeNumber
            .Cells(2).Value = FirstName
            .Cells(3).Value = LastName
            .Cells(4).Value = MiddleName
            .Cells(5).Value = Company
            .Cells(6).Value = Department
            .Cells(7).Value = Schedule
            .Cells(8).Value = Available
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
        filteredUserDB = New UserDatabase(False)
        filteredUserDB.AddRange((From res In userDB Where res.Admin = cbSearchAdmin.Checked).ToList)
        readUserDB(filteredUserDB)
    End Sub

    Private Sub cbSearchAvailable_CheckedChanged(sender As Object, e As EventArgs) Handles cbSearchAvailable.CheckedChanged
        filteredUserDB = New UserDatabase(False)
        filteredUserDB.AddRange((From res In userDB Where res.Available = cbSearchAvailable.Checked).ToList)
        readUserDB(filteredUserDB)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        filteredUserDB = New UserDatabase(False)
        Select Case cbSearchOption.Text.ToUpper
            Case "ID"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.ID.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "EMPLOYEE NUMBER"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.EmployeeNumber.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "COMPANY"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.Company.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "DEPARTMENT"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.Department.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "FIRSTNAME"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.FirstName.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "LASTNAME"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.LastName.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case "MIDDLE INITIAL"
                filteredUserDB.AddRange( _
                    (From res In userDB Where res.MI.ToUpper = tbSearch.Text And res.Admin = cbSearchAdmin.Checked And res.Available = cbSearchAvailable.Checked).ToList)
            Case Else
                Exit Sub
        End Select
        readUserDB(filteredUserDB)
    End Sub


End Class