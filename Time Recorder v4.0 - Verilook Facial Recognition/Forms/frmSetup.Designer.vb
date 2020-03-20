Namespace AddingUser
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSetup
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup))
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.tbCompany = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.tbCompAcro = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.cbProject = New System.Windows.Forms.ComboBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cbSched = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.tbFname = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.tbEmpNum = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.lbRegStatus = New System.Windows.Forms.Label()
            Me.btnRegPrint = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cbCompBranch = New System.Windows.Forms.ComboBox()
            Me.tbLname = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.Label9 = New System.Windows.Forms.Label()
            Me.tbMname = New ModifiedComponents.ModifiedTextbox(Me.components)
            Me.cbDept = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(7, 27)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(98, 15)
            Me.Label1.TabIndex = 1000
            Me.Label1.Text = "Company Name:"
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(230, 27)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(60, 15)
            Me.Label2.TabIndex = 40
            Me.Label2.Text = "Acronym:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(16, 171)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 15)
            Me.Label3.TabIndex = 43
            Me.Label3.Text = "First Name:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(16, 200)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(69, 15)
            Me.Label4.TabIndex = 44
            Me.Label4.Text = "Last Name:"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Controls.Add(Me.tbCompany)
            Me.GroupBox1.Controls.Add(Me.tbCompAcro)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Controls.Add(Me.Label2)
            Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(327, 72)
            Me.GroupBox1.TabIndex = 100
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Company Information"
            '
            'tbCompany
            '
            Me.tbCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbCompany.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbCompany.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbCompany.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbCompany.Location = New System.Drawing.Point(6, 43)
            Me.tbCompany.Name = "tbCompany"
            Me.tbCompany.OtherCharacter = Nothing
            Me.tbCompany.Size = New System.Drawing.Size(221, 23)
            Me.tbCompany.TabIndex = 1
            Me.tbCompany.WithSpaces = True
            '
            'tbCompAcro
            '
            Me.tbCompAcro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbCompAcro.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbCompAcro.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbCompAcro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbCompAcro.Location = New System.Drawing.Point(233, 43)
            Me.tbCompAcro.Name = "tbCompAcro"
            Me.tbCompAcro.OtherCharacter = Nothing
            Me.tbCompAcro.Size = New System.Drawing.Size(81, 23)
            Me.tbCompAcro.TabIndex = 2
            Me.tbCompAcro.WithSpaces = False
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.cbProject)
            Me.GroupBox2.Controls.Add(Me.Label8)
            Me.GroupBox2.Controls.Add(Me.cbSched)
            Me.GroupBox2.Controls.Add(Me.Label10)
            Me.GroupBox2.Controls.Add(Me.tbFname)
            Me.GroupBox2.Controls.Add(Me.tbEmpNum)
            Me.GroupBox2.Controls.Add(Me.lbRegStatus)
            Me.GroupBox2.Controls.Add(Me.btnRegPrint)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.cbCompBranch)
            Me.GroupBox2.Controls.Add(Me.tbLname)
            Me.GroupBox2.Controls.Add(Me.Label9)
            Me.GroupBox2.Controls.Add(Me.tbMname)
            Me.GroupBox2.Controls.Add(Me.cbDept)
            Me.GroupBox2.Controls.Add(Me.Label6)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.Location = New System.Drawing.Point(12, 80)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(327, 359)
            Me.GroupBox2.TabIndex = 110
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Admin Information"
            '
            'cbProject
            '
            Me.cbProject.BackColor = System.Drawing.Color.DimGray
            Me.cbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbProject.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbProject.ForeColor = System.Drawing.Color.White
            Me.cbProject.FormattingEnabled = True
            Me.cbProject.Location = New System.Drawing.Point(105, 119)
            Me.cbProject.Name = "cbProject"
            Me.cbProject.Size = New System.Drawing.Size(214, 23)
            Me.cbProject.TabIndex = 456
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(16, 114)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(77, 30)
            Me.Label8.TabIndex = 457
            Me.Label8.Text = "Project:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cbSched.Location = New System.Drawing.Point(105, 90)
            Me.cbSched.Name = "cbSched"
            Me.cbSched.Size = New System.Drawing.Size(214, 23)
            Me.cbSched.TabIndex = 5
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(16, 85)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(77, 30)
            Me.Label10.TabIndex = 39
            Me.Label10.Text = "Schedule:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tbFname
            '
            Me.tbFname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbFname.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbFname.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbFname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbFname.Location = New System.Drawing.Point(105, 168)
            Me.tbFname.Name = "tbFname"
            Me.tbFname.OtherCharacter = "'-ñÑ"
            Me.tbFname.Size = New System.Drawing.Size(214, 23)
            Me.tbFname.TabIndex = 6
            Me.tbFname.WithSpaces = True
            '
            'tbEmpNum
            '
            Me.tbEmpNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbEmpNum.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.AlphaNumeric
            Me.tbEmpNum.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbEmpNum.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbEmpNum.Location = New System.Drawing.Point(200, 283)
            Me.tbEmpNum.Name = "tbEmpNum"
            Me.tbEmpNum.OtherCharacter = Nothing
            Me.tbEmpNum.Size = New System.Drawing.Size(119, 23)
            Me.tbEmpNum.TabIndex = 10
            Me.tbEmpNum.WithSpaces = False
            '
            'lbRegStatus
            '
            Me.lbRegStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbRegStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbRegStatus.ForeColor = System.Drawing.Color.Maroon
            Me.lbRegStatus.Location = New System.Drawing.Point(23, 312)
            Me.lbRegStatus.Name = "lbRegStatus"
            Me.lbRegStatus.Size = New System.Drawing.Size(179, 39)
            Me.lbRegStatus.TabIndex = 78
            Me.lbRegStatus.Text = "Your Fingerprint is not yet registered."
            Me.lbRegStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRegPrint
            '
            Me.btnRegPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRegPrint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRegPrint.Location = New System.Drawing.Point(204, 312)
            Me.btnRegPrint.Name = "btnRegPrint"
            Me.btnRegPrint.Size = New System.Drawing.Size(115, 39)
            Me.btnRegPrint.TabIndex = 11
            Me.btnRegPrint.Text = "Register Fingerprint"
            Me.btnRegPrint.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(14, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(102, 15)
            Me.Label7.TabIndex = 41
            Me.Label7.Text = "Company Branch:"
            '
            'cbCompBranch
            '
            Me.cbCompBranch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbCompBranch.BackColor = System.Drawing.Color.DimGray
            Me.cbCompBranch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cbCompBranch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbCompBranch.ForeColor = System.Drawing.Color.White
            Me.cbCompBranch.FormattingEnabled = True
            Me.cbCompBranch.Items.AddRange(New Object() {"IDCSI", "FPOSI", "Accudata"})
            Me.cbCompBranch.Location = New System.Drawing.Point(128, 29)
            Me.cbCompBranch.Name = "cbCompBranch"
            Me.cbCompBranch.Size = New System.Drawing.Size(191, 23)
            Me.cbCompBranch.TabIndex = 3
            '
            'tbLname
            '
            Me.tbLname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbLname.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbLname.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbLname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbLname.Location = New System.Drawing.Point(105, 198)
            Me.tbLname.Name = "tbLname"
            Me.tbLname.OtherCharacter = "'-ñÑ"
            Me.tbLname.Size = New System.Drawing.Size(214, 23)
            Me.tbLname.TabIndex = 7
            Me.tbLname.WithSpaces = True
            '
            'Label9
            '
            Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(197, 268)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(114, 15)
            Me.Label9.TabIndex = 46
            Me.Label9.Text = "Employee Number:"
            '
            'tbMname
            '
            Me.tbMname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbMname.Character = ModifiedComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbMname.CharacterCasing = ModifiedComponents.ModifiedTextbox.charCases.Upper
            Me.tbMname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbMname.Location = New System.Drawing.Point(105, 227)
            Me.tbMname.Name = "tbMname"
            Me.tbMname.OtherCharacter = "'-ñÑ"
            Me.tbMname.Size = New System.Drawing.Size(214, 23)
            Me.tbMname.TabIndex = 8
            Me.tbMname.WithSpaces = True
            '
            'cbDept
            '
            Me.cbDept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbDept.BackColor = System.Drawing.Color.DimGray
            Me.cbDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cbDept.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDept.ForeColor = System.Drawing.Color.White
            Me.cbDept.FormattingEnabled = True
            Me.cbDept.Items.AddRange(New Object() {"Software", "PC", "QC", "Admin"})
            Me.cbDept.Location = New System.Drawing.Point(105, 59)
            Me.cbDept.Name = "cbDept"
            Me.cbDept.Size = New System.Drawing.Size(214, 23)
            Me.cbDept.TabIndex = 4
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(14, 62)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(79, 15)
            Me.Label6.TabIndex = 42
            Me.Label6.Text = "Department:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(14, 229)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(85, 15)
            Me.Label5.TabIndex = 455
            Me.Label5.Text = "Middle Name:"
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(20, Byte), Integer))
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
            Me.btnSave.Location = New System.Drawing.Point(12, 445)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(329, 23)
            Me.btnSave.TabIndex = 12
            Me.btnSave.Text = "SAVE"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'frmSetup
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Gainsboro
            Me.ClientSize = New System.Drawing.Size(351, 473)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.KeyPreview = True
            Me.MaximizeBox = False
            Me.Name = "frmSetup"
            Me.Text = "Setup"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cbCompBranch As System.Windows.Forms.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cbDept As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents btnRegPrint As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lbRegStatus As System.Windows.Forms.Label
        Friend WithEvents tbCompany As ModifiedComponents.ModifiedTextbox
        Friend WithEvents tbCompAcro As ModifiedComponents.ModifiedTextbox
        Friend WithEvents tbFname As ModifiedComponents.ModifiedTextbox
        Friend WithEvents tbEmpNum As ModifiedComponents.ModifiedTextbox
        Friend WithEvents tbLname As ModifiedComponents.ModifiedTextbox
        Friend WithEvents tbMname As ModifiedComponents.ModifiedTextbox
        Friend WithEvents cbSched As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents cbProject As System.Windows.Forms.ComboBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
    End Class
End Namespace