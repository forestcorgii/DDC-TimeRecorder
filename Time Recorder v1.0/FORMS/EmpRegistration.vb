Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Neurotec.Biometrics
Imports System.Data.OleDb

Namespace VBNETSample
    Public Class EmpRegistration
        Inherits Form
        Private unRegID As New List(Of String)
        Private RegID As New List(Of String)
        Private empConn As New OleDbConnection
        Public fp As Bitmap
        Private defaultprint As String = ""

#Region "Public Properties"
        Public Property ID() As String
            Get
                Return tbID.Text
            End Get
            Set(ByVal value As String)
                tbID.Text = value
            End Set
        End Property

        Public Property department() As String
            Get
                Return cbDept.Text
            End Get
            Set(ByVal value As String)
                cbDept.Text = value
            End Set
        End Property

        Public Property lastname() As String
            Get
                Return tbLName.Text
            End Get
            Set(ByVal value As String)
                tbLName.Text = value
            End Set
        End Property

        Public Property firstname() As String
            Get
                Return tbFName.Text
            End Get
            Set(ByVal value As String)
                tbFName.Text = value
            End Set
        End Property

        Public Property middlename() As String
            Get
                Return tbMName.Text
            End Get
            Set(ByVal value As String)
                tbMName.Text = value
            End Set
        End Property

        Public Property company() As String
            Get
                Return cbSC.Text
            End Get
            Set(ByVal value As String)
                cbSC.Text = value
            End Set
        End Property

        Public Property empnum() As String
            Get
                Return tbEM.Text
            End Get
            Set(ByVal value As String)
                tbEM.Text = value
            End Set
        End Property

        Public Property Admin() As Boolean
            Get
                Return cbAdmin.Checked
            End Get
            Set(ByVal value As Boolean)
                cbAdmin.Checked = value
            End Set
        End Property

        Public Property CAT() As String
            Get
                Return cbCAT.Text
            End Get
            Set(ByVal value As String)
                cbCAT.Text = value
            End Set
        End Property
#End Region
        Private Sub btnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScan.Click
            If validateAll() = False Then
                     unRegID.Add(ID)
                If File.Exists(Application.StartupPath & "\" & ID & ext.xmlEx) Then
                    If MsgBox("Saved Fingerprint will be cleared from the database. Continue?", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
                        deleteUser(ID)
                    End If
                End If
                Using regF As New getFingerprints(ID)
                    regF.ShowDialog()
                    If regF.DialogResult = DialogResult.Yes Then
                        MessageBox.Show("Fingerprint is registered to the database Successfully..")
                        defaultprint = regF.cbDefPrint.SelectedItem
                        lbFP.Text = "Default Fingerprint: " & defaultprint
                        SAVECHANGESToolStripMenuItem.PerformClick()
                    Else
                        MessageBox.Show("Register Failed..")
                        lbFP.Text = "Default Fingerprint: None"
                    End If
                End Using
            End If
        End Sub

        Private Sub EmpRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            InitializeComponent()

            openEmpList()

            company = frmSettings.Acro
            tbID.Select()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            delUnRegID()

            If RegID.Count <> 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.Cancel
            End If

            Me.Close()
        End Sub

#Region "Saving"
        Public Sub editInfo()
            If checkID() Then
                mdbUpdate("List", New String() {"EmpNo", "Firstname", "Lastname", "MI", "Company", "Department", "Fingerprint", "Admin"}, _
                New Object() {empnum, firstname, lastname, middlename, company, department, defaultprint, Admin}, New String() {"ID", ID}, empConn)

                Using writeInf As StreamWriter = File.CreateText(String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, ID, ext.infEx))
                    writeInf.WriteLine(defaultprint)
                    writeInf.WriteLine(empnum)
                    writeInf.WriteLine(company)
                    writeInf.WriteLine(department)
                    writeInf.WriteLine(firstname)
                    writeInf.WriteLine(lastname)
                    writeInf.WriteLine(middlename)
                End Using
                MsgBox("Saved.")
            End If
        End Sub
        Public Sub saveUser()
            Using writeInf As StreamWriter = File.AppendText(String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, ID, ext.infEx))
                writeInf.WriteLine(defaultprint)
                writeInf.WriteLine(empnum)
                writeInf.WriteLine(company)
                writeInf.WriteLine(department)
                writeInf.WriteLine(firstname)
                writeInf.WriteLine(lastname)
                writeInf.WriteLine(middlename)
            End Using

            mdbInsert("List", New String() {"ID", "EmpNo", "Firstname", "Lastname", "MI", "Company", "Department", "Fingerprint", "Admin"}, _
           New Object() {ID, empnum, firstname, lastname, middlename, company, department, defaultprint, Admin}, empConn)

            mdbCreateTable(ID, New String() {"DAY-AUTOINCREMENT PRIMARY KEY", "DATE-text(15)", "IN-text(40)", "OUT-text(40)"}, TMconn)
            RegID.Add(ID)

            MsgBox("Saved.")
        End Sub
#End Region

#Region "Delete Unregistered User"
        Public Sub delUnRegID()
            For Each i As String In unRegID
                If unRegID.Contains(ID) And RegID.Contains(ID) = False Then
                    deleteUser(i)
                End If
            Next
        End Sub
#End Region

#Region "Refresh"
        Public Sub refreshALL()
            tbID.Enabled = True
            btnScan.Enabled = True

            openEmpList()

            ID = ""
            lastname = ""
            firstname = ""
            middlename = ""
            empnum = ""
            company = ""
            department = ""
            cbAdmin.Checked = False
        End Sub
#End Region

#Region "Employee List"
        Private Sub openEmpList()
            If Not File.Exists(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, filelist.EL)) Then
                mdbCreate(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, filelist.EL))
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.EL), empConn)
                mdbCreateTable("List", New String() {"ID-text(10)", "EmpNo-text(50)", "Firstname-text(50)", "Lastname-text(50)", "MI-text(10)", "Department-text(50)", "Company-text(50)", "Fingerprint-text(50)", "Admin-YESNO"}, empConn)
            Else
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.EL), empConn)
            End If
            Dim tmp As New DataTable
            mdbToDT("SELECT * FROM List", tmp, empConn)
            populateDGV(tmp)
        End Sub

        Private Sub populateDGV(ByVal dt As DataTable)
            dgv.Rows.Clear()

           Dim id, fn, ln, mi, com, df, dp, em As String
            Dim ad As Boolean
         
            For Each i As DataRow In dt.Rows
                id = i.Item("ID").ToString
                fn = i.Item("Firstname").ToString
                ln = i.Item("Lastname").ToString
                mi = i.Item("MI").ToString
                com = i.Item("Company").ToString
                em = i.Item("EmpNo").ToString
                df = i.Item("Fingerprint").ToString
                dp = i.Item("Department").ToString
                ad = i.Item("Admin")

                dgv.Rows.Add(id, em, fn, ln, mi, com, dp, df, ad)
            Next
        End Sub

        Private Function checkID() As Boolean
            If File.Exists(String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, ID, ext.infEx)) Then
                Return True
            End If
            Return False
        End Function
#End Region


#Region "Validation"
        Sub chBlank(ByVal v As String, ByRef invalid As Boolean)
            If v = "" Then invalid = False
        End Sub

        Public Function validateAll() As Boolean
            Dim invalid As Boolean = False
            If validation(tbID.Name, ID) Then
                invalid = True
            ElseIf validation(tbFName.Name, firstname) Then
                invalid = True
            ElseIf validation(tbLName.Name, lastname) Then
                invalid = True
            ElseIf validation(tbMName.Name, middlename) Then
                invalid = True
            ElseIf validation(cbDept.Name, department) Then
                invalid = True
            End If
            Return invalid
        End Function

        Public Function validation(ByVal n As String, ByVal v As String) As Boolean
            Dim invalid As Boolean = False
            If invalid = False Then
                Select Case n
                    Case tbID.Name
                        chBlank(v, invalid)
                        If invalid = True Then
                            MessageBox.Show("ID Number is blank")
                        Else
                            If ID.Length <> 4 Then
                                invalid = True
                                MessageBox.Show("ID must have 4 digits")
                            End If
                        End If
                    Case tbFName.Name
                        chBlank(v, invalid)
                        If invalid = True Then MessageBox.Show("First Name is blank")
                    Case tbLName.Name
                        chBlank(v, invalid)
                        If invalid = True Then MessageBox.Show("Last Name is blank")
                    Case tbMName.Name
                        chBlank(v, invalid)
                        If invalid = True Then MessageBox.Show("Middle Name is blank")
                    Case cbDept.Name
                        chBlank(v, invalid)
                        If invalid = False Then
                            For Each i As String In cbDept.Items.ToString
                                If v = i Then
                                    invalid = False
                                    MessageBox.Show("Please select a department")
                                    Exit Select
                                End If
                            Next
                        Else
                            MessageBox.Show("Please select a department")
                        End If
                End Select
            End If
            Return invalid
        End Function
#End Region

#Region "KEYDOWN"
        Private alphaKey As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'"
        Private numKey As String = "0123456789"

        Private Sub tbFName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbFName.KeyDown
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If validation(tbFName.Name, firstname) = False Then
                    tbLName.Select()
                End If
            End If
        End Sub

        Private Sub tbID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbID.KeyDown
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If File.Exists(String.Format("{0}\{1}{2}", Application.StartupPath, ID, ext.xmlEx)) Then
                    MessageBox.Show("This ID is already taken")
                Else
                    If validation(tbID.Name, ID) = False Then
                        tbFName.Select()
                    End If
                End If
            End If
        End Sub

        Private Sub tbLName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbLName.KeyDown
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If validation(tbLName.Name, lastname) = False Then
                    tbMName.Select()
                End If
            End If
        End Sub

        Private Sub tbMName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbMName.KeyDown
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If validation(tbMName.Name, middlename) = False Then
                    btnScan.PerformClick()
                End If
            End If
        End Sub

#End Region

        Private Sub NEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEW.Click
            refreshALL()
        End Sub

        Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
            delUnRegID()

            If RegID.Count <> 0 Then
                Me.DialogResult = DialogResult.OK
            Else
                Me.DialogResult = DialogResult.Cancel
            End If

            Me.Close()
        End Sub

        Private Sub SAVECHANGESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVECHANGESToolStripMenuItem.Click
            If validateAll() = False Then
                If checkID() Then
                    editInfo()
                Else
                    saveUser()
                End If
                openEmpList()
                tbID.Select()
            End If
        End Sub

        Private Sub dgv_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv.CurrentCellChanged
            Try
                If dgv.Rows.Count <> 0 Then
                    With dgv.Rows(dgv.CurrentRow.Index)
                        ID = .Cells(0).Value
                        empnum = .Cells(1).Value
                        firstname = .Cells(2).Value
                        lastname = .Cells(3).Value
                        middlename = .Cells(4).Value
                        company = .Cells(5).Value
                        department = .Cells(6).Value
                        defaultprint = .Cells(7).Value
                        Admin = .Cells(8).Value
                    End With

                    lbFP.Text = "Default Fingerprint: " & defaultprint
                End If
            Catch
            End Try
        End Sub

      
        Private Sub searchByCAT(ByVal txt As String)
            Dim tmp As New DataTable
            Dim qry As String = "SELECT * FROM List WHERE "
            Select Case CAT.ToUpper
                Case "ID"
                    qry &= String.Format("{0} LIKE '%{1}%'", "ID", txt)
                Case "EMPLOYEE NUMBER"
                    qry &= String.Format("{0} LIKE '%{1}%'", "EmpNo", txt)
                Case "COMPANY"
                    qry &= String.Format("{0} LIKE '%{1}%''", "Company", txt)
                Case "DEPARTMENT"
                    qry &= String.Format("{0} LIKE '%{1}%''", "Department", txt)
                Case "FIRSTNAME"
                    qry &= String.Format("{0} LIKE '%{1}%'", "Firstname", txt)
                Case "LASTNAME"
                    qry &= String.Format("{0} LIKE '%{1}%'", "Lastname", txt)
                Case "MIDDLE INITIAL"
                    qry &= String.Format("{0} LIKE '%{1}%'", "MI", txt)
                Case Else
                    Exit Sub
            End Select
            mdbToDT(qry, tmp, empConn)
            populateDGV(tmp)
        End Sub

        Private Sub tbSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbSearch.TextChanged
            If CAT <> "" And tbSearch.Text <> "" Then
                searchByCAT(tbSearch.Text)
            ElseIf tbSearch.Text = "" Then
                openEmpList()
            End If
        End Sub
    End Class
End Namespace