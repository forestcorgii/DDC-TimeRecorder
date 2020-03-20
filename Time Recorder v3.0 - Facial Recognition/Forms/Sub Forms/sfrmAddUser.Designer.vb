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
            Me.lbFaceStatus = New System.Windows.Forms.Label()
            Me.btnRegisterFace = New System.Windows.Forms.Button()
            Me.cbSched = New System.Windows.Forms.ComboBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cbAdmin = New System.Windows.Forms.CheckBox()
            Me.tbID = New CustomComponents.ModifiedTextbox(Me.components)
            Me.tbFname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.tbEmpNum = New CustomComponents.ModifiedTextbox(Me.components)
            Me.lbFingerprintStatus = New System.Windows.Forms.Label()
            Me.btnRegisterFingerprint = New System.Windows.Forms.Button()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cbCompBranch = New System.Windows.Forms.ComboBox()
            Me.tbLname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.Label9 = New System.Windows.Forms.Label()
            Me.tbMname = New CustomComponents.ModifiedTextbox(Me.components)
            Me.cbDept = New System.Windows.Forms.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
            Me.btnSave.Location = New System.Drawing.Point(12, 389)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(337, 23)
            Me.btnSave.TabIndex = 11
            Me.btnSave.Text = "SAVE"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox2.Controls.Add(Me.lbFaceStatus)
            Me.GroupBox2.Controls.Add(Me.btnRegisterFace)
            Me.GroupBox2.Controls.Add(Me.cbSched)
            Me.GroupBox2.Controls.Add(Me.Label10)
            Me.GroupBox2.Controls.Add(Me.cbAdmin)
            Me.GroupBox2.Controls.Add(Me.tbID)
            Me.GroupBox2.Controls.Add(Me.tbFname)
            Me.GroupBox2.Controls.Add(Me.tbEmpNum)
            Me.GroupBox2.Controls.Add(Me.lbFingerprintStatus)
            Me.GroupBox2.Controls.Add(Me.btnRegisterFingerprint)
            Me.GroupBox2.Controls.Add(Me.Label7)
            Me.GroupBox2.Controls.Add(Me.Label8)
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
            Me.GroupBox2.Size = New System.Drawing.Size(335, 371)
            Me.GroupBox2.TabIndex = 10
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "User Information"
            '
            'lbFaceStatus
            '
            Me.lbFaceStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFaceStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbFaceStatus.ForeColor = System.Drawing.Color.Maroon
            Me.lbFaceStatus.Location = New System.Drawing.Point(23, 329)
            Me.lbFaceStatus.Name = "lbFaceStatus"
            Me.lbFaceStatus.Size = New System.Drawing.Size(187, 39)
            Me.lbFaceStatus.TabIndex = 42
            Me.lbFaceStatus.Text = "Your Face is not yet registered."
            Me.lbFaceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRegisterFace
            '
            Me.btnRegisterFace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRegisterFace.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRegisterFace.Location = New System.Drawing.Point(212, 329)
            Me.btnRegisterFace.Name = "btnRegisterFace"
            Me.btnRegisterFace.Size = New System.Drawing.Size(115, 39)
            Me.btnRegisterFace.TabIndex = 43
            Me.btnRegisterFace.Text = "Register Owner's Face"
            Me.btnRegisterFace.UseVisualStyleBackColor = True
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
            Me.cbSched.Location = New System.Drawing.Point(105, 88)
            Me.cbSched.Name = "cbSched"
            Me.cbSched.Size = New System.Drawing.Size(222, 23)
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
            Me.cbAdmin.Location = New System.Drawing.Point(273, 235)
            Me.cbAdmin.Name = "cbAdmin"
            Me.cbAdmin.Size = New System.Drawing.Size(51, 33)
            Me.cbAdmin.TabIndex = 14
            Me.cbAdmin.Text = "Admin:"
            Me.cbAdmin.UseVisualStyleBackColor = True
            '
            'tbID
            '
            Me.tbID.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Numeric
            Me.tbID.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Proper
            Me.tbID.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbID.Location = New System.Drawing.Point(17, 250)
            Me.tbID.Name = "tbID"
            Me.tbID.OtherCharacter = Nothing
            Me.tbID.Size = New System.Drawing.Size(114, 23)
            Me.tbID.TabIndex = 8
            Me.tbID.WithSpaces = False
            '
            'tbFname
            '
            Me.tbFname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbFname.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbFname.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbFname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbFname.Location = New System.Drawing.Point(105, 141)
            Me.tbFname.Name = "tbFname"
            Me.tbFname.OtherCharacter = "'-"
            Me.tbFname.Size = New System.Drawing.Size(222, 23)
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
            Me.tbEmpNum.Location = New System.Drawing.Point(140, 250)
            Me.tbEmpNum.Name = "tbEmpNum"
            Me.tbEmpNum.OtherCharacter = Nothing
            Me.tbEmpNum.Size = New System.Drawing.Size(127, 23)
            Me.tbEmpNum.TabIndex = 9
            Me.tbEmpNum.WithSpaces = False
            '
            'lbFingerprintStatus
            '
            Me.lbFingerprintStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFingerprintStatus.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbFingerprintStatus.ForeColor = System.Drawing.Color.Maroon
            Me.lbFingerprintStatus.Location = New System.Drawing.Point(23, 283)
            Me.lbFingerprintStatus.Name = "lbFingerprintStatus"
            Me.lbFingerprintStatus.Size = New System.Drawing.Size(187, 39)
            Me.lbFingerprintStatus.TabIndex = 10
            Me.lbFingerprintStatus.Text = "Your Fingerprint is not yet registered."
            Me.lbFingerprintStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRegisterFingerprint
            '
            Me.btnRegisterFingerprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRegisterFingerprint.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRegisterFingerprint.Location = New System.Drawing.Point(212, 283)
            Me.btnRegisterFingerprint.Name = "btnRegisterFingerprint"
            Me.btnRegisterFingerprint.Size = New System.Drawing.Size(115, 39)
            Me.btnRegisterFingerprint.TabIndex = 10
            Me.btnRegisterFingerprint.Text = "Register Fingerprint"
            Me.btnRegisterFingerprint.UseVisualStyleBackColor = True
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(14, 32)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(102, 15)
            Me.Label7.TabIndex = 11
            Me.Label7.Text = "Company Branch:"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.Location = New System.Drawing.Point(15, 235)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(81, 15)
            Me.Label8.TabIndex = 12
            Me.Label8.Text = "ID: (Titanium)"
            '
            'cbCompBranch
            '
            Me.cbCompBranch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbCompBranch.BackColor = System.Drawing.Color.DimGray
            Me.cbCompBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCompBranch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cbCompBranch.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbCompBranch.ForeColor = System.Drawing.Color.White
            Me.cbCompBranch.FormattingEnabled = True
            Me.cbCompBranch.Items.AddRange(New Object() {"IDCSI", "FPOSI", "Accudata"})
            Me.cbCompBranch.Location = New System.Drawing.Point(128, 29)
            Me.cbCompBranch.Name = "cbCompBranch"
            Me.cbCompBranch.Size = New System.Drawing.Size(199, 23)
            Me.cbCompBranch.TabIndex = 3
            '
            'tbLname
            '
            Me.tbLname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbLname.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
            Me.tbLname.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
            Me.tbLname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbLname.Location = New System.Drawing.Point(105, 171)
            Me.tbLname.Name = "tbLname"
            Me.tbLname.OtherCharacter = "'-"
            Me.tbLname.Size = New System.Drawing.Size(222, 23)
            Me.tbLname.TabIndex = 6
            Me.tbLname.WithSpaces = True
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.Location = New System.Drawing.Point(137, 235)
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
            Me.tbMname.Location = New System.Drawing.Point(105, 200)
            Me.tbMname.Name = "tbMname"
            Me.tbMname.OtherCharacter = "'-"
            Me.tbMname.Size = New System.Drawing.Size(222, 23)
            Me.tbMname.TabIndex = 7
            Me.tbMname.WithSpaces = True
            '
            'cbDept
            '
            Me.cbDept.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbDept.BackColor = System.Drawing.Color.DimGray
            Me.cbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDept.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.cbDept.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbDept.ForeColor = System.Drawing.Color.White
            Me.cbDept.FormattingEnabled = True
            Me.cbDept.Items.AddRange(New Object() {"Software", "PC", "QC", "Admin"})
            Me.cbDept.Location = New System.Drawing.Point(105, 59)
            Me.cbDept.Name = "cbDept"
            Me.cbDept.Size = New System.Drawing.Size(222, 23)
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
            Me.Label5.Location = New System.Drawing.Point(14, 202)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(85, 15)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "Middle Name:"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(16, 144)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(71, 15)
            Me.Label3.TabIndex = 2
            Me.Label3.Text = "First Name:"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(16, 173)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(69, 15)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Last Name:"
            '
            'frmAddUser
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.Gainsboro
            Me.ClientSize = New System.Drawing.Size(359, 420)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.GroupBox2)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmAddUser"
            Me.Text = "frmAddUser"
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents tbID As CustomComponents.ModifiedTextbox
        Friend WithEvents tbFname As CustomComponents.ModifiedTextbox
        Friend WithEvents tbEmpNum As CustomComponents.ModifiedTextbox
        Friend WithEvents lbFingerprintStatus As System.Windows.Forms.Label
        Friend WithEvents btnRegisterFingerprint As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
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
    End Class
End Namespace