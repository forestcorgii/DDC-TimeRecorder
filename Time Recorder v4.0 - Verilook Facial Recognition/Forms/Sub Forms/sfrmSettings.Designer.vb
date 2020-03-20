<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sfrmSettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbCompany = New CustomComponents.ModifiedTextbox(Me.components)
        Me.tbCompAcro = New CustomComponents.ModifiedTextbox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOpenBiometricClientSettings = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDump = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbCompany)
        Me.GroupBox1.Controls.Add(Me.tbCompAcro)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnOpenBiometricClientSettings)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbDump)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 130)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Information"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(157, 100)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(40, 23)
        Me.NumericUpDown1.TabIndex = 48
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(200, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "month/s prior."
        '
        'tbCompany
        '
        Me.tbCompany.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
        Me.tbCompany.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
        Me.tbCompany.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompany.Location = New System.Drawing.Point(6, 43)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.OtherCharacter = Nothing
        Me.tbCompany.Size = New System.Drawing.Size(266, 23)
        Me.tbCompany.TabIndex = 1
        Me.tbCompany.WithSpaces = True
        '
        'tbCompAcro
        '
        Me.tbCompAcro.Character = CustomComponents.ModifiedTextbox.CharacterTypes.Alpha
        Me.tbCompAcro.CharacterCasing = CustomComponents.ModifiedTextbox.charCases.Upper
        Me.tbCompAcro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompAcro.Location = New System.Drawing.Point(278, 43)
        Me.tbCompAcro.Name = "tbCompAcro"
        Me.tbCompAcro.OtherCharacter = Nothing
        Me.tbCompAcro.Size = New System.Drawing.Size(94, 23)
        Me.tbCompAcro.TabIndex = 2
        Me.tbCompAcro.WithSpaces = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 15)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Clear Employees Records:"
        '
        'btnOpenBiometricClientSettings
        '
        Me.btnOpenBiometricClientSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenBiometricClientSettings.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenBiometricClientSettings.Location = New System.Drawing.Point(157, 69)
        Me.btnOpenBiometricClientSettings.Name = "btnOpenBiometricClientSettings"
        Me.btnOpenBiometricClientSettings.Size = New System.Drawing.Size(215, 23)
        Me.btnOpenBiometricClientSettings.TabIndex = 44
        Me.btnOpenBiometricClientSettings.Text = "Open Biometric Client Settings"
        Me.btnOpenBiometricClientSettings.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Name:"
        '
        'cbDump
        '
        Me.cbDump.AutoSize = True
        Me.cbDump.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDump.Location = New System.Drawing.Point(6, 72)
        Me.cbDump.Name = "cbDump"
        Me.cbDump.Size = New System.Drawing.Size(144, 19)
        Me.cbDump.TabIndex = 14
        Me.cbDump.Text = "Enable Dump Feature"
        Me.cbDump.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(275, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Acronym:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(23, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(282, 141)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'sfrmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(385, 171)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(401, 155)
        Me.Name = "sfrmSettings"
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbCompany As CustomComponents.ModifiedTextbox
    Friend WithEvents tbCompAcro As CustomComponents.ModifiedTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbDump As System.Windows.Forms.CheckBox
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOpenBiometricClientSettings As System.Windows.Forms.Button
End Class
