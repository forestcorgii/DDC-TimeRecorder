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
        Me.tbCompany = New CustomComponents.ModifiedTextbox(Me.components)
        Me.tbCompAcro = New CustomComponents.ModifiedTextbox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbDump = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(372, 72)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Information"
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
        Me.btnSave.Location = New System.Drawing.Point(282, 81)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(98, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'cbDump
        '
        Me.cbDump.AutoSize = True
        Me.cbDump.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDump.Location = New System.Drawing.Point(14, 83)
        Me.cbDump.Name = "cbDump"
        Me.cbDump.Size = New System.Drawing.Size(144, 19)
        Me.cbDump.TabIndex = 14
        Me.cbDump.Text = "Enable Dump Feature"
        Me.cbDump.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(385, 116)
        Me.Controls.Add(Me.cbDump)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(401, 155)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tbCompany As CustomComponents.ModifiedTextbox
    Friend WithEvents tbCompAcro As CustomComponents.ModifiedTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cbDump As System.Windows.Forms.CheckBox
End Class
