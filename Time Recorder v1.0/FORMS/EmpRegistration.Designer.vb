Namespace VBNETSample
    Partial Class EmpRegistration
        Inherits System.Windows.Forms.Form

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmpRegistration))
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.tbID = New System.Windows.Forms.TextBox()
            Me.tbFName = New System.Windows.Forms.TextBox()
            Me.tbLName = New System.Windows.Forms.TextBox()
            Me.tbMName = New System.Windows.Forms.TextBox()
            Me.btnScan = New System.Windows.Forms.Button()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cbDept = New System.Windows.Forms.ComboBox()
            Me.cbSC = New System.Windows.Forms.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.tbEM = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
            Me.OPTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnNEW = New System.Windows.Forms.ToolStripMenuItem()
            Me.SAVECHANGESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.EXITToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.cbAdmin = New System.Windows.Forms.CheckBox()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.lbFP = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
            Me.dgv = New System.Windows.Forms.DataGridView()
            Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clEmpNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clFname = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clLName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clMName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clDept = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clFingerprint = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.clAdmin = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
            Me.tbSearch = New System.Windows.Forms.TextBox()
            Me.cbCAT = New System.Windows.Forms.ComboBox()
            Me.MenuStrip1.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            Me.TableLayoutPanel4.SuspendLayout()
            CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel5.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label1.Location = New System.Drawing.Point(3, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 30)
            Me.Label1.TabIndex = 4
            Me.Label1.Text = "ID:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label2
            '
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label2.Location = New System.Drawing.Point(3, 30)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 30)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "First Name:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label3.Location = New System.Drawing.Point(3, 60)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 30)
            Me.Label3.TabIndex = 6
            Me.Label3.Text = "Last Name:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label4.Location = New System.Drawing.Point(3, 90)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 30)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "Middle Initial:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tbID
            '
            Me.tbID.BackColor = System.Drawing.Color.GhostWhite
            Me.tbID.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbID.Location = New System.Drawing.Point(105, 3)
            Me.tbID.MaxLength = 4
            Me.tbID.Name = "tbID"
            Me.tbID.Size = New System.Drawing.Size(200, 21)
            Me.tbID.TabIndex = 1
            '
            'tbFName
            '
            Me.tbFName.BackColor = System.Drawing.Color.GhostWhite
            Me.tbFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.tbFName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbFName.Location = New System.Drawing.Point(105, 33)
            Me.tbFName.MaxLength = 50
            Me.tbFName.Name = "tbFName"
            Me.tbFName.Size = New System.Drawing.Size(200, 21)
            Me.tbFName.TabIndex = 2
            '
            'tbLName
            '
            Me.tbLName.BackColor = System.Drawing.Color.GhostWhite
            Me.tbLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.tbLName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbLName.Location = New System.Drawing.Point(105, 63)
            Me.tbLName.MaxLength = 50
            Me.tbLName.Name = "tbLName"
            Me.tbLName.Size = New System.Drawing.Size(200, 21)
            Me.tbLName.TabIndex = 3
            '
            'tbMName
            '
            Me.tbMName.BackColor = System.Drawing.Color.GhostWhite
            Me.tbMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.tbMName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbMName.Location = New System.Drawing.Point(105, 93)
            Me.tbMName.MaxLength = 5
            Me.tbMName.Name = "tbMName"
            Me.tbMName.Size = New System.Drawing.Size(200, 21)
            Me.tbMName.TabIndex = 4
            '
            'btnScan
            '
            Me.btnScan.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnScan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnScan.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnScan.Location = New System.Drawing.Point(3, 3)
            Me.btnScan.Name = "btnScan"
            Me.btnScan.Size = New System.Drawing.Size(153, 27)
            Me.btnScan.TabIndex = 8
            Me.btnScan.Text = "Get Fingerprint"
            Me.btnScan.UseVisualStyleBackColor = False
            '
            'Label6
            '
            Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label6.Location = New System.Drawing.Point(3, 120)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 30)
            Me.Label6.TabIndex = 21
            Me.Label6.Text = "EMP. #:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cbDept
            '
            Me.cbDept.BackColor = System.Drawing.Color.GhostWhite
            Me.cbDept.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbDept.FormattingEnabled = True
            Me.cbDept.Items.AddRange(New Object() {"Software", "PC", "QC", "Admin"})
            Me.cbDept.Location = New System.Drawing.Point(105, 183)
            Me.cbDept.Name = "cbDept"
            Me.cbDept.Size = New System.Drawing.Size(200, 23)
            Me.cbDept.TabIndex = 6
            '
            'cbSC
            '
            Me.cbSC.BackColor = System.Drawing.Color.GhostWhite
            Me.cbSC.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbSC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbSC.Enabled = False
            Me.cbSC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbSC.FormattingEnabled = True
            Me.cbSC.Items.AddRange(New Object() {"IDCSI", "FPOSI", "Accudata"})
            Me.cbSC.Location = New System.Drawing.Point(105, 153)
            Me.cbSC.Name = "cbSC"
            Me.cbSC.Size = New System.Drawing.Size(200, 23)
            Me.cbSC.TabIndex = 7
            '
            'Label5
            '
            Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label5.Location = New System.Drawing.Point(3, 180)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 30)
            Me.Label5.TabIndex = 14
            Me.Label5.Text = "Department:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tbEM
            '
            Me.tbEM.BackColor = System.Drawing.Color.GhostWhite
            Me.tbEM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.tbEM.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbEM.Location = New System.Drawing.Point(105, 123)
            Me.tbEM.MaxLength = 4
            Me.tbEM.Name = "tbEM"
            Me.tbEM.Size = New System.Drawing.Size(200, 21)
            Me.tbEM.TabIndex = 5
            '
            'Label7
            '
            Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.AliceBlue
            Me.Label7.Location = New System.Drawing.Point(3, 150)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 30)
            Me.Label7.TabIndex = 23
            Me.Label7.Text = "Company :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MenuStrip1
            '
            Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OPTIONToolStripMenuItem})
            Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(1169, 24)
            Me.MenuStrip1.TabIndex = 24
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'OPTIONToolStripMenuItem
            '
            Me.OPTIONToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNEW, Me.SAVECHANGESToolStripMenuItem, Me.EXITToolStripMenuItem})
            Me.OPTIONToolStripMenuItem.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
            Me.OPTIONToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.OPTIONToolStripMenuItem.Name = "OPTIONToolStripMenuItem"
            Me.OPTIONToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
            Me.OPTIONToolStripMenuItem.Text = "OPTION"
            '
            'btnNEW
            '
            Me.btnNEW.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.btnNEW.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnNEW.Name = "btnNEW"
            Me.btnNEW.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
            Me.btnNEW.Size = New System.Drawing.Size(224, 22)
            Me.btnNEW.Text = "NEW"
            '
            'SAVECHANGESToolStripMenuItem
            '
            Me.SAVECHANGESToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.SAVECHANGESToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.SAVECHANGESToolStripMenuItem.Name = "SAVECHANGESToolStripMenuItem"
            Me.SAVECHANGESToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
            Me.SAVECHANGESToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
            Me.SAVECHANGESToolStripMenuItem.Text = "SAVE CHANGES"
            '
            'EXITToolStripMenuItem
            '
            Me.EXITToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.EXITToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.EXITToolStripMenuItem.Name = "EXITToolStripMenuItem"
            Me.EXITToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
            Me.EXITToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
            Me.EXITToolStripMenuItem.Text = "EXIT"
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
            Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel4)
            Me.SplitContainer1.Size = New System.Drawing.Size(1169, 563)
            Me.SplitContainer1.SplitterDistance = 314
            Me.SplitContainer1.TabIndex = 25
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 1
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
            Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.13953!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.86047!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(314, 563)
            Me.TableLayoutPanel2.TabIndex = 0
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667!))
            Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.tbID, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.cbDept, 1, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.cbSC, 1, 5)
            Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 6)
            Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.tbFName, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.tbEM, 1, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.tbLName, 1, 2)
            Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 4)
            Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.tbMName, 1, 3)
            Me.TableLayoutPanel1.Controls.Add(Me.cbAdmin, 1, 7)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 9
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(308, 321)
            Me.TableLayoutPanel1.TabIndex = 0
            '
            'cbAdmin
            '
            Me.cbAdmin.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbAdmin.Location = New System.Drawing.Point(105, 213)
            Me.cbAdmin.Name = "cbAdmin"
            Me.cbAdmin.Size = New System.Drawing.Size(200, 24)
            Me.cbAdmin.TabIndex = 24
            Me.cbAdmin.Text = "Admin"
            Me.cbAdmin.UseVisualStyleBackColor = True
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 1
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.btnScan, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.lbFP, 0, 1)
            Me.TableLayoutPanel3.Controls.Add(Me.Label8, 0, 2)
            Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 330)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 3
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(308, 230)
            Me.TableLayoutPanel3.TabIndex = 1
            '
            'lbFP
            '
            Me.lbFP.AutoSize = True
            Me.lbFP.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lbFP.Location = New System.Drawing.Point(3, 45)
            Me.lbFP.Name = "lbFP"
            Me.lbFP.Size = New System.Drawing.Size(302, 23)
            Me.lbFP.TabIndex = 9
            '
            'Label8
            '
            Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label8.Location = New System.Drawing.Point(3, 68)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(302, 162)
            Me.Label8.TabIndex = 10
            Me.Label8.Text = "CTRL + N   -  Refresh" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CTRL + S    -  Save/Edit Employee's Information"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TableLayoutPanel4
            '
            Me.TableLayoutPanel4.ColumnCount = 1
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.Controls.Add(Me.dgv, 0, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel5, 0, 0)
            Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 2
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.Size = New System.Drawing.Size(851, 563)
            Me.TableLayoutPanel4.TabIndex = 25
            '
            'dgv
            '
            Me.dgv.AllowUserToAddRows = False
            Me.dgv.AllowUserToDeleteRows = False
            Me.dgv.AllowUserToResizeRows = False
            Me.dgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.clEmpNo, Me.clFname, Me.clLName, Me.clMName, Me.clCompany, Me.clDept, Me.clFingerprint, Me.clAdmin})
            Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgv.EnableHeadersVisualStyles = False
            Me.dgv.Location = New System.Drawing.Point(3, 33)
            Me.dgv.MultiSelect = False
            Me.dgv.Name = "dgv"
            Me.dgv.RowHeadersVisible = False
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!)
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.AliceBlue
            Me.dgv.RowsDefaultCellStyle = DataGridViewCellStyle3
            Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgv.Size = New System.Drawing.Size(845, 527)
            Me.dgv.TabIndex = 0
            '
            'clID
            '
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            Me.clID.DefaultCellStyle = DataGridViewCellStyle2
            Me.clID.FillWeight = 102.6831!
            Me.clID.HeaderText = "ID"
            Me.clID.Name = "clID"
            Me.clID.ReadOnly = True
            Me.clID.Width = 65
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
            'clDept
            '
            Me.clDept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.clDept.FillWeight = 102.6831!
            Me.clDept.HeaderText = "Department"
            Me.clDept.Name = "clDept"
            Me.clDept.ReadOnly = True
            '
            'clFingerprint
            '
            Me.clFingerprint.HeaderText = "Fingerprint"
            Me.clFingerprint.Name = "clFingerprint"
            Me.clFingerprint.ReadOnly = True
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
            'TableLayoutPanel5
            '
            Me.TableLayoutPanel5.ColumnCount = 3
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Controls.Add(Me.tbSearch, 0, 0)
            Me.TableLayoutPanel5.Controls.Add(Me.cbCAT, 0, 0)
            Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 1
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Size = New System.Drawing.Size(845, 24)
            Me.TableLayoutPanel5.TabIndex = 1
            '
            'tbSearch
            '
            Me.tbSearch.BackColor = System.Drawing.Color.GhostWhite
            Me.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tbSearch.Location = New System.Drawing.Point(203, 3)
            Me.tbSearch.MaxLength = 4
            Me.tbSearch.Name = "tbSearch"
            Me.tbSearch.Size = New System.Drawing.Size(194, 21)
            Me.tbSearch.TabIndex = 8
            '
            'cbCAT
            '
            Me.cbCAT.BackColor = System.Drawing.Color.GhostWhite
            Me.cbCAT.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbCAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbCAT.FormattingEnabled = True
            Me.cbCAT.Items.AddRange(New Object() {"ID", "Employee Number", "Firstname", "Lastname", "Middle Initial", "Company", "Department"})
            Me.cbCAT.Location = New System.Drawing.Point(3, 3)
            Me.cbCAT.Name = "cbCAT"
            Me.cbCAT.Size = New System.Drawing.Size(194, 23)
            Me.cbCAT.TabIndex = 7
            '
            'EmpRegistration
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1169, 587)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.MenuStrip1)
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.MenuStrip1
            Me.Name = "EmpRegistration"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Time Recorder v1.0"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            Me.TableLayoutPanel4.ResumeLayout(False)
            CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel5.ResumeLayout(False)
            Me.TableLayoutPanel5.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents tbID As System.Windows.Forms.TextBox
        Friend WithEvents tbFName As System.Windows.Forms.TextBox
        Friend WithEvents tbLName As System.Windows.Forms.TextBox
        Friend WithEvents tbMName As System.Windows.Forms.TextBox
        Friend WithEvents btnScan As System.Windows.Forms.Button
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cbDept As System.Windows.Forms.ComboBox
        Friend WithEvents cbSC As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents tbEM As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
        Friend WithEvents OPTIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnNEW As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents SAVECHANGESToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents EXITToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents lbFP As System.Windows.Forms.Label
        Friend WithEvents cbAdmin As System.Windows.Forms.CheckBox
        Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents dgv As System.Windows.Forms.DataGridView
        Friend WithEvents clID As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clEmpNo As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clFname As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clLName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clMName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clCompany As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clDept As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clFingerprint As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents clAdmin As System.Windows.Forms.DataGridViewCheckBoxColumn
        Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents tbSearch As System.Windows.Forms.TextBox
        Friend WithEvents cbCAT As System.Windows.Forms.ComboBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
    End Class
End Namespace


