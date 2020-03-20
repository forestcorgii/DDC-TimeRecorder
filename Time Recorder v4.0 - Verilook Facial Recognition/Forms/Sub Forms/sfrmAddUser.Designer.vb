Namespace AddingUser
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAddUser
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddUser))
            Me.btnSave = New System.Windows.Forms.Button()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.cbProject = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lbFaceStatus = New System.Windows.Forms.Label()
            Me.btnRegisterFace = New System.Windows.Forms.Button()
            Me.cbSched = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cbAdmin = New System.Windows.Forms.CheckBox()
            Me.tbFname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.tbEmpNum = New CustomComponents.ModifiedTextbox(Me.components)
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cbCompBranch = New System.Windows.Forms.ComboBox()
            Me.tbLname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.Label9 = New System.Windows.Forms.Label()
            Me.tbMname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.cbDept = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnAddMore = New System.Windows.Forms.Button()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
            Me.btnSave.Location = New System.Drawing.Point(152, 368)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(198, 23)
            Me.btnSave.TabIndex = 11
            Me.btnSave.Text = "SAVE"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.cbProject)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Controls.Add(Me.lbFaceStatus)
            Me.GroupBox2.Controls.Add(Me.btnRegisterFace)
            Me.GroupBox2.Controls.Add(Me.cbSched)
            Me.GroupBox2.Controls.Add(Me.Label10)
            Me.GroupBox2.Controls.Add(Me.cbAdmin)
            Me.GroupBox2.Controls.Add(Me.tbFname)
            Me.GroupBox2.Controls.Add(Me.tbEmpNum)
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
            Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(336, 350)
            Me.GroupBox2.TabIndex = 10
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "User Information"
            '
            'cbProject
            '
            Me.cbProject.BackColor = System.Drawing.Color.DimGray
            Me.cbProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbProject.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbProject.ForeColor = System.Drawing.Color.White
            Me.cbProject.FormattingEnabled = True
            Me.cbProject.Location = New System.Drawing.Point(105, 117)
            Me.cbProject.Name = "cbProject"
            Me.cbProject.Size = New System.Drawing.Size(223, 23)
            Me.cbProject.TabIndex = 44
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(12, 112)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(87, 30)
            Me.Label1.TabIndex = 45
            Me.Label1.Text = "Project:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbFaceStatus
            '
            Me.lbFaceStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbFaceStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbFaceStatus.ForeColor = System.Drawing.Color.Maroon
            Me.lbFaceStatus.Location = New System.Drawing.Point(23, 308)
            Me.lbFaceStatus.Name = "lbFaceStatus"
            Me.lbFaceStatus.Size = New System.Drawing.Size(187, 39)
            Me.lbFaceStatus.TabIndex = 42
            Me.lbFaceStatus.Text = "Your Face is not yet registered."
            Me.lbFaceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRegisterFace
            '
            Me.btnRegisterFace.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnRegisterFace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRegisterFace.Location = New System.Drawing.Point(212, 308)
            Me.btnRegisterFace.Name = "btnRegisterFace"
            Me.btnRegisterFace.Size = New System.Drawing.Size(115, 39)
            Me.btnRegisterFace.TabIndex = 43
            Me.btnRegisterFace.Text = "Register Owner's Face"
            Me.btnRegisterFace.UseVisualStyleBackColor = True
            '
            'cbSched
            '
            Me.cbSched.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbSched.BackColor = System.Drawing.Color.DimGray
            Me.cbSched.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbSched.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbSched.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbSched.ForeColor = System.Drawing.Color.White
            Me.cbSched.FormattingEnabled = True
            Me.cbSched.Items.AddRange(New Object() {"1ST", "2ND", "3RD", "SWING"})
            Me.cbSched.Location = New System.Drawing.Point(105, 88)
            Me.cbSched.Name = "cbSched"
            Me.cbSched.Size = New System.Drawing.Size(223, 23)
            Me.cbSched.TabIndex = 40
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Black
            Me.Label10.Location = New System.Drawing.Point(16, 83)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(77, 30)
            Me.Label10.TabIndex = 41
            Me.Label10.Text = "Schedule :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cbAdmin
            '
            Me.cbAdmin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbAdmin.AutoSize = True
            Me.cbAdmin.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.cbAdmin.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbAdmin.Location = New System.Drawing.Point(274, 254)
            Me.cbAdmin.Name = "cbAdmin"
            Me.cbAdmin.Size = New System.Drawing.Size(51, 33)
            Me.cbAdmin.TabIndex = 14
            Me.cbAdmin.Text = "Admin:"
            Me.cbAdmin.UseVisualStyleBackColor = True
            '
            'tbFname
            '
            Me.tbFname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbFname.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbFname.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbFname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbFname.Location = New System.Drawing.Point(105, 160)
            Me.tbFname.Name = "tbFname"
            Me.tbFname.OtherCharacter = "'-ñÑ"
            Me.tbFname.Size = New System.Drawing.Size(223, 23)
            Me.tbFname.TabIndex = 5
            Me.tbFname.WithSpaces = True
            '
            'tbEmpNum
            '
            Me.tbEmpNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbEmpNum.Character = CustomComponents.ModifiedTextbox.CharacterTypes.AlphaNumeric
            Me.tbEmpNum.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbEmpNum.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbEmpNum.Location = New System.Drawing.Point(140, 269)
            Me.tbEmpNum.Name = "tbEmpNum"
            Me.tbEmpNum.OtherCharacter = Nothing
            Me.tbEmpNum.Size = New System.Drawing.Size(128, 23)
            Me.tbEmpNum.TabIndex = 9
            Me.tbEmpNum.WithSpaces = False
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(14, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(62, 15)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Company:"
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
            Me.cbCompBranch.Location = New System.Drawing.Point(105, 29)
            Me.cbCompBranch.Name = "cbCompBranch"
            Me.cbCompBranch.Size = New System.Drawing.Size(223, 23)
            Me.cbCompBranch.TabIndex = 3
            '
            'tbLname
            '
            Me.tbLname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbLname.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbLname.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbLname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbLname.Location = New System.Drawing.Point(105, 190)
            Me.tbLname.Name = "tbLname"
            Me.tbLname.OtherCharacter = "'-ñÑ"
            Me.tbLname.Size = New System.Drawing.Size(223, 23)
            Me.tbLname.TabIndex = 6
            Me.tbLname.WithSpaces = True
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(137, 254)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(114, 15)
            Me.Label9.TabIndex = 13
            Me.Label9.Text = "Employee Number:"
            '
            'tbMname
            '
            Me.tbMname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbMname.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbMname.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbMname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbMname.Location = New System.Drawing.Point(105, 219)
            Me.tbMname.Name = "tbMname"
            Me.tbMname.OtherCharacter = "'-ñÑ"
            Me.tbMname.Size = New System.Drawing.Size(223, 23)
            Me.tbMname.TabIndex = 7
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
            Me.cbDept.Size = New System.Drawing.Size(223, 23)
            Me.cbDept.TabIndex = 4
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.Location = New System.Drawing.Point(14, 62)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(79, 15)
            Me.Label6.TabIndex = 10
            Me.Label6.Text = "Department:"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.Location = New System.Drawing.Point(14, 221)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(85, 15)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Middle Name:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(16, 163)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 15)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "First Name:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(16, 192)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(69, 15)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Last Name:"
            '
            'btnAddMore
            '
            Me.btnAddMore.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddMore.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
            Me.btnAddMore.Location = New System.Drawing.Point(12, 368)
            Me.btnAddMore.Name = "btnAddMore"
            Me.btnAddMore.Size = New System.Drawing.Size(134, 23)
            Me.btnAddMore.TabIndex = 12
            Me.btnAddMore.Text = "Save and Add More"
            Me.btnAddMore.UseVisualStyleBackColor = True
            '
            'frmAddUser
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Gainsboro
            Me.ClientSize = New System.Drawing.Size(360, 399)
            Me.Controls.Add(Me.btnAddMore)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.GroupBox2)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.KeyPreview = True
            Me.Name = "frmAddUser"
            Me.Text = "frmAddUser"
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents tbFname As CustomComponents.ModifiedTextbox
        Friend WithEvents tbEmpNum As CustomComponents.ModifiedTextbox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cbCompBranch As System.Windows.Forms.ComboBox
        Friend WithEvents tbLname As CustomComponents.ModifiedTextbox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents tbMname As CustomComponents.ModifiedTextbox
        Friend WithEvents cbDept As System.Windows.Forms.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cbAdmin As System.Windows.Forms.CheckBox
        Friend WithEvents cbSched As System.Windows.Forms.ComboBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lbFaceStatus As System.Windows.Forms.Label
        Friend WithEvents btnRegisterFace As System.Windows.Forms.Button
        Friend WithEvents btnAddMore As System.Windows.Forms.Button
        Friend WithEvents cbProject As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End Namespace