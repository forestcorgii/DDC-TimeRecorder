﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmUserProfiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sfrmUserProfiles))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.clEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clFname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clLName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clProject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clSched = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clActive = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clAdmin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.cbSearchActive = New System.Windows.Forms.CheckBox()
        Me.cbSearchAdmin = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbSearch = New System.Windows.Forms.TextBox()
        Me.cbSearchOption = New System.Windows.Forms.ComboBox()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbProject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.lbMessage2 = New System.Windows.Forms.Label()
        Me.btnRegFace = New System.Windows.Forms.Button()
        Me.cbSched = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbDepartment = New System.Windows.Forms.ComboBox()
        Me.cbCompany = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbAdmin = New System.Windows.Forms.CheckBox()
        Me.tbEmployeeNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMiddleName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbLastName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbFirstName = New System.Windows.Forms.TextBox()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToResizeRows = False
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clEmpNo, Me.clFname, Me.clLName, Me.clMName, Me.clCompany, Me.clProject, Me.clDept, Me.clSched, Me.clActive, Me.clAdmin})
        Me.dgv.EnableHeadersVisualStyles = False
        Me.dgv.Location = New System.Drawing.Point(317, 39)
        Me.dgv.MultiSelect = False
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.AliceBlue
        Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(748, 457)
        Me.dgv.TabIndex = 1
        '
        'clEmpNo
        '
        Me.clEmpNo.FillWeight = 102.6831!
        Me.clEmpNo.HeaderText = "Emp No."
        Me.clEmpNo.Name = "clEmpNo"
        Me.clEmpNo.ReadOnly = True
        Me.clEmpNo.Width = 85
        '
        'clFname
        '
        Me.clFname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clFname.FillWeight = 102.6831!
        Me.clFname.HeaderText = "Firstname"
        Me.clFname.Name = "clFname"
        Me.clFname.ReadOnly = True
        '
        'clLName
        '
        Me.clLName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clLName.FillWeight = 102.6831!
        Me.clLName.HeaderText = "Lastname"
        Me.clLName.Name = "clLName"
        Me.clLName.ReadOnly = True
        '
        'clMName
        '
        Me.clMName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clMName.FillWeight = 102.6831!
        Me.clMName.HeaderText = "MI"
        Me.clMName.Name = "clMName"
        Me.clMName.ReadOnly = True
        Me.clMName.Width = 35
        '
        'clCompany
        '
        Me.clCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clCompany.FillWeight = 102.6831!
        Me.clCompany.HeaderText = "Company"
        Me.clCompany.Name = "clCompany"
        Me.clCompany.ReadOnly = True
        '
        'clProject
        '
        Me.clProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clProject.HeaderText = "Project"
        Me.clProject.Name = "clProject"
        Me.clProject.ReadOnly = True
        '
        'clDept
        '
        Me.clDept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clDept.FillWeight = 102.6831!
        Me.clDept.HeaderText = "Department"
        Me.clDept.Name = "clDept"
        Me.clDept.ReadOnly = True
        '
        'clSched
        '
        Me.clSched.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.clSched.HeaderText = "Schedule"
        Me.clSched.Name = "clSched"
        '
        'clActive
        '
        Me.clActive.HeaderText = "Active"
        Me.clActive.Name = "clActive"
        Me.clActive.ReadOnly = True
        Me.clActive.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'clAdmin
        '
        Me.clAdmin.FillWeight = 81.21828!
        Me.clAdmin.HeaderText = "Admin"
        Me.clAdmin.Name = "clAdmin"
        Me.clAdmin.ReadOnly = True
        Me.clAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clAdmin.Width = 60
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnSearch)
        Me.Panel1.Controls.Add(Me.cbSearchActive)
        Me.Panel1.Controls.Add(Me.cbSearchAdmin)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.tbSearch)
        Me.Panel1.Controls.Add(Me.cbSearchOption)
        Me.Panel1.Location = New System.Drawing.Point(317, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 35)
        Me.Panel1.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(584, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 36
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbSearchActive
        '
        Me.cbSearchActive.AutoSize = True
        Me.cbSearchActive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchActive.Location = New System.Drawing.Point(507, 7)
        Me.cbSearchActive.Name = "cbSearchActive"
        Me.cbSearchActive.Size = New System.Drawing.Size(60, 19)
        Me.cbSearchActive.TabIndex = 36
        Me.cbSearchActive.Text = "Active"
        Me.cbSearchActive.UseVisualStyleBackColor = True
        '
        'cbSearchAdmin
        '
        Me.cbSearchAdmin.AutoSize = True
        Me.cbSearchAdmin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchAdmin.Location = New System.Drawing.Point(439, 7)
        Me.cbSearchAdmin.Name = "cbSearchAdmin"
        Me.cbSearchAdmin.Size = New System.Drawing.Size(62, 19)
        Me.cbSearchAdmin.TabIndex = 37
        Me.cbSearchAdmin.Text = "Admin"
        Me.cbSearchAdmin.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(117, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Search :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbSearch
        '
        Me.tbSearch.BackColor = System.Drawing.Color.GhostWhite
        Me.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSearch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSearch.Location = New System.Drawing.Point(311, 5)
        Me.tbSearch.MaxLength = 1000
        Me.tbSearch.Name = "tbSearch"
        Me.tbSearch.Size = New System.Drawing.Size(122, 23)
        Me.tbSearch.TabIndex = 10
        '
        'cbSearchOption
        '
        Me.cbSearchOption.BackColor = System.Drawing.Color.DimGray
        Me.cbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearchOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSearchOption.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearchOption.ForeColor = System.Drawing.Color.White
        Me.cbSearchOption.FormattingEnabled = True
        Me.cbSearchOption.Items.AddRange(New Object() {"Employee Number", "Firstname", "Lastname", "Middle Initial", "Company", "Department"})
        Me.cbSearchOption.Location = New System.Drawing.Point(169, 5)
        Me.cbSearchOption.Name = "cbSearchOption"
        Me.cbSearchOption.Size = New System.Drawing.Size(136, 23)
        Me.cbSearchOption.TabIndex = 9
        '
        'btnAddUser
        '
        Me.btnAddUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddUser.BackColor = System.Drawing.Color.DimGray
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddUser.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddUser.ForeColor = System.Drawing.Color.White
        Me.btnAddUser.Image = Global.Time_Recorder_v4._0.My.Resources.Resources.add_business_card_symbol
        Me.btnAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddUser.Location = New System.Drawing.Point(214, 10)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(91, 25)
        Me.btnAddUser.TabIndex = 3
        Me.btnAddUser.Text = "Register"
        Me.btnAddUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.cbProject)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cbActive)
        Me.Panel2.Controls.Add(Me.lbMessage2)
        Me.Panel2.Controls.Add(Me.btnRegFace)
        Me.Panel2.Controls.Add(Me.cbSched)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnAddUser)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cbDepartment)
        Me.Panel2.Controls.Add(Me.cbCompany)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cbAdmin)
        Me.Panel2.Controls.Add(Me.tbEmployeeNumber)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbMiddleName)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbLastName)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbFirstName)
        Me.Panel2.Location = New System.Drawing.Point(6, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(310, 491)
        Me.Panel2.TabIndex = 3
        '
        'cbProject
        '
        Me.cbProject.BackColor = System.Drawing.Color.DimGray
        Me.cbProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbProject.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProject.ForeColor = System.Drawing.Color.White
        Me.cbProject.FormattingEnabled = True
        Me.cbProject.Location = New System.Drawing.Point(96, 180)
        Me.cbProject.Name = "cbProject"
        Me.cbProject.Size = New System.Drawing.Size(209, 23)
        Me.cbProject.TabIndex = 41
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 30)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Project:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbActive.Location = New System.Drawing.Point(177, 63)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(60, 19)
        Me.cbActive.TabIndex = 40
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'lbMessage2
        '
        Me.lbMessage2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMessage2.ForeColor = System.Drawing.Color.Black
        Me.lbMessage2.Location = New System.Drawing.Point(7, 343)
        Me.lbMessage2.Name = "lbMessage2"
        Me.lbMessage2.Size = New System.Drawing.Size(170, 42)
        Me.lbMessage2.TabIndex = 39
        Me.lbMessage2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRegFace
        '
        Me.btnRegFace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegFace.Location = New System.Drawing.Point(183, 345)
        Me.btnRegFace.Name = "btnRegFace"
        Me.btnRegFace.Size = New System.Drawing.Size(115, 39)
        Me.btnRegFace.TabIndex = 38
        Me.btnRegFace.Text = "Register Face Image"
        Me.btnRegFace.UseVisualStyleBackColor = True
        '
        'cbSched
        '
        Me.cbSched.BackColor = System.Drawing.Color.DimGray
        Me.cbSched.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbSched.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSched.ForeColor = System.Drawing.Color.White
        Me.cbSched.FormattingEnabled = True
        Me.cbSched.Items.AddRange(New Object() {"1ST", "2ND", "3RD", "SWING"})
        Me.cbSched.Location = New System.Drawing.Point(97, 151)
        Me.cbSched.Name = "cbSched"
        Me.cbSched.Size = New System.Drawing.Size(209, 23)
        Me.cbSched.TabIndex = 36
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(4, 146)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 30)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "Schedule :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(153, 446)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(145, 35)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Save Changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 30)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Company :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbDepartment
        '
        Me.cbDepartment.BackColor = System.Drawing.Color.DimGray
        Me.cbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbDepartment.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDepartment.ForeColor = System.Drawing.Color.White
        Me.cbDepartment.FormattingEnabled = True
        Me.cbDepartment.Items.AddRange(New Object() {"Software", "PC", "QC", "Admin"})
        Me.cbDepartment.Location = New System.Drawing.Point(96, 121)
        Me.cbDepartment.Name = "cbDepartment"
        Me.cbDepartment.Size = New System.Drawing.Size(209, 23)
        Me.cbDepartment.TabIndex = 26
        '
        'cbCompany
        '
        Me.cbCompany.BackColor = System.Drawing.Color.DimGray
        Me.cbCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbCompany.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCompany.ForeColor = System.Drawing.Color.White
        Me.cbCompany.FormattingEnabled = True
        Me.cbCompany.Items.AddRange(New Object() {"IDCSI", "FPOSI", "Accudata"})
        Me.cbCompany.Location = New System.Drawing.Point(96, 91)
        Me.cbCompany.Name = "cbCompany"
        Me.cbCompany.Size = New System.Drawing.Size(209, 23)
        Me.cbCompany.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 30)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Department :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbAdmin
        '
        Me.cbAdmin.AutoSize = True
        Me.cbAdmin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAdmin.Location = New System.Drawing.Point(243, 63)
        Me.cbAdmin.Name = "cbAdmin"
        Me.cbAdmin.Size = New System.Drawing.Size(62, 19)
        Me.cbAdmin.TabIndex = 30
        Me.cbAdmin.Text = "Admin"
        Me.cbAdmin.UseVisualStyleBackColor = True
        '
        'tbEmployeeNumber
        '
        Me.tbEmployeeNumber.BackColor = System.Drawing.Color.GhostWhite
        Me.tbEmployeeNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbEmployeeNumber.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEmployeeNumber.Location = New System.Drawing.Point(6, 39)
        Me.tbEmployeeNumber.MaxLength = 4
        Me.tbEmployeeNumber.Name = "tbEmployeeNumber"
        Me.tbEmployeeNumber.Size = New System.Drawing.Size(299, 23)
        Me.tbEmployeeNumber.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 18)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Employee Number:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 283)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 30)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Middle Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbMiddleName
        '
        Me.tbMiddleName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbMiddleName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbMiddleName.Location = New System.Drawing.Point(96, 286)
        Me.tbMiddleName.MaxLength = 50
        Me.tbMiddleName.Name = "tbMiddleName"
        Me.tbMiddleName.Size = New System.Drawing.Size(209, 23)
        Me.tbMiddleName.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 30)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Last Name :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbLastName
        '
        Me.tbLastName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbLastName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLastName.Location = New System.Drawing.Point(96, 256)
        Me.tbLastName.MaxLength = 50
        Me.tbLastName.Name = "tbLastName"
        Me.tbLastName.Size = New System.Drawing.Size(209, 23)
        Me.tbLastName.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 223)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 30)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "First Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbFirstName
        '
        Me.tbFirstName.BackColor = System.Drawing.Color.GhostWhite
        Me.tbFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbFirstName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbFirstName.Location = New System.Drawing.Point(96, 226)
        Me.tbFirstName.MaxLength = 50
        Me.tbFirstName.Name = "tbFirstName"
        Me.tbFirstName.Size = New System.Drawing.Size(209, 23)
        Me.tbFirstName.TabIndex = 7
        '
        'sfrmUserProfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1069, 498)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "sfrmUserProfiles"
        Me.Text = "UserProfiles"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAddUser As System.Windows.Forms.Button
    Friend WithEvents tbSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbSearchOption As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbLastName As System.Windows.Forms.TextBox
    Friend WithEvents tbEmployeeNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents cbCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbSearchActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbSearchAdmin As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents cbSched As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lbMessage2 As System.Windows.Forms.Label
    Friend WithEvents btnRegFace As System.Windows.Forms.Button
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clEmpNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clFname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clLName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clCompany As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clProject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clDept As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clSched As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clActive As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clAdmin As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
