<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSettings
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbDetectFacialFeature = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chbUseDeviceManager = New System.Windows.Forms.CheckBox()
        Me.nmConfidenceThreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbLivenessMode = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nmQualityThreshold = New System.Windows.Forms.NumericUpDown()
        Me.nmMaximalRoll = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nmMaximalYaw = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nmLivenessBlinkThreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbTemplateSize = New System.Windows.Forms.ComboBox()
        Me.chbUseLiveness = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbMatchingSpeed = New System.Windows.Forms.ComboBox()
        Me.nmLivenessThreshold = New System.Windows.Forms.NumericUpDown()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.chbSingleImageRecongition = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nmUserReloginTime = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nmMatchingScoreThreshold = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nmConfidenceThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmQualityThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmMaximalRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmMaximalYaw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmLivenessBlinkThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmLivenessThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.nmUserReloginTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nmMatchingScoreThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(561, 380)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 27)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nmMatchingScoreThreshold)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chbDetectFacialFeature)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chbUseDeviceManager)
        Me.GroupBox1.Controls.Add(Me.nmConfidenceThreshold)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbLivenessMode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.nmQualityThreshold)
        Me.GroupBox1.Controls.Add(Me.nmMaximalRoll)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nmMaximalYaw)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nmLivenessBlinkThreshold)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cbTemplateSize)
        Me.GroupBox1.Controls.Add(Me.chbUseLiveness)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbMatchingSpeed)
        Me.GroupBox1.Controls.Add(Me.nmLivenessThreshold)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 367)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Biometric Client Settings"
        '
        'chbDetectFacialFeature
        '
        Me.chbDetectFacialFeature.AutoSize = True
        Me.chbDetectFacialFeature.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbDetectFacialFeature.Location = New System.Drawing.Point(177, 60)
        Me.chbDetectFacialFeature.Name = "chbDetectFacialFeature"
        Me.chbDetectFacialFeature.Size = New System.Drawing.Size(141, 19)
        Me.chbDetectFacialFeature.TabIndex = 69
        Me.chbDetectFacialFeature.Text = "Detect Facial Feature"
        Me.chbDetectFacialFeature.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Maximal Yaw"
        '
        'chbUseDeviceManager
        '
        Me.chbUseDeviceManager.AutoSize = True
        Me.chbUseDeviceManager.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbUseDeviceManager.Location = New System.Drawing.Point(177, 23)
        Me.chbUseDeviceManager.Name = "chbUseDeviceManager"
        Me.chbUseDeviceManager.Size = New System.Drawing.Size(136, 19)
        Me.chbUseDeviceManager.TabIndex = 68
        Me.chbUseDeviceManager.Text = "Use Device Manager"
        Me.chbUseDeviceManager.UseVisualStyleBackColor = True
        '
        'nmConfidenceThreshold
        '
        Me.nmConfidenceThreshold.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmConfidenceThreshold.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmConfidenceThreshold.Location = New System.Drawing.Point(156, 184)
        Me.nmConfidenceThreshold.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmConfidenceThreshold.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmConfidenceThreshold.Name = "nmConfidenceThreshold"
        Me.nmConfidenceThreshold.Size = New System.Drawing.Size(126, 23)
        Me.nmConfidenceThreshold.TabIndex = 50
        Me.nmConfidenceThreshold.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Maximal Roll"
        '
        'cbLivenessMode
        '
        Me.cbLivenessMode.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbLivenessMode.FormattingEnabled = True
        Me.cbLivenessMode.Location = New System.Drawing.Point(118, 89)
        Me.cbLivenessMode.Name = "cbLivenessMode"
        Me.cbLivenessMode.Size = New System.Drawing.Size(164, 23)
        Me.cbLivenessMode.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 15)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Confidence Threshold"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 15)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Liveness Mode"
        '
        'nmQualityThreshold
        '
        Me.nmQualityThreshold.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmQualityThreshold.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmQualityThreshold.Location = New System.Drawing.Point(131, 211)
        Me.nmQualityThreshold.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmQualityThreshold.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmQualityThreshold.Name = "nmQualityThreshold"
        Me.nmQualityThreshold.Size = New System.Drawing.Size(152, 23)
        Me.nmQualityThreshold.TabIndex = 53
        Me.nmQualityThreshold.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'nmMaximalRoll
        '
        Me.nmMaximalRoll.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nmMaximalRoll.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nmMaximalRoll.Location = New System.Drawing.Point(112, 54)
        Me.nmMaximalRoll.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.nmMaximalRoll.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nmMaximalRoll.Name = "nmMaximalRoll"
        Me.nmMaximalRoll.Size = New System.Drawing.Size(58, 23)
        Me.nmMaximalRoll.TabIndex = 65
        Me.nmMaximalRoll.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 15)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Quality Threshold"
        '
        'nmMaximalYaw
        '
        Me.nmMaximalYaw.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nmMaximalYaw.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nmMaximalYaw.Location = New System.Drawing.Point(112, 23)
        Me.nmMaximalYaw.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.nmMaximalYaw.Minimum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.nmMaximalYaw.Name = "nmMaximalYaw"
        Me.nmMaximalYaw.Size = New System.Drawing.Size(58, 23)
        Me.nmMaximalYaw.TabIndex = 64
        Me.nmMaximalYaw.Value = New Decimal(New Integer() {15, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 283)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 15)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Matching Speed"
        '
        'nmLivenessBlinkThreshold
        '
        Me.nmLivenessBlinkThreshold.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmLivenessBlinkThreshold.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmLivenessBlinkThreshold.Location = New System.Drawing.Point(177, 143)
        Me.nmLivenessBlinkThreshold.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmLivenessBlinkThreshold.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmLivenessBlinkThreshold.Name = "nmLivenessBlinkThreshold"
        Me.nmLivenessBlinkThreshold.Size = New System.Drawing.Size(105, 23)
        Me.nmLivenessBlinkThreshold.TabIndex = 63
        Me.nmLivenessBlinkThreshold.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 311)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Template Size"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 145)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(139, 15)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Liveness Blink Threshold"
        '
        'cbTemplateSize
        '
        Me.cbTemplateSize.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbTemplateSize.FormattingEnabled = True
        Me.cbTemplateSize.Location = New System.Drawing.Point(118, 308)
        Me.cbTemplateSize.Name = "cbTemplateSize"
        Me.cbTemplateSize.Size = New System.Drawing.Size(164, 23)
        Me.cbTemplateSize.TabIndex = 57
        '
        'chbUseLiveness
        '
        Me.chbUseLiveness.AutoSize = True
        Me.chbUseLiveness.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbUseLiveness.Location = New System.Drawing.Point(177, 42)
        Me.chbUseLiveness.Name = "chbUseLiveness"
        Me.chbUseLiveness.Size = New System.Drawing.Size(95, 19)
        Me.chbUseLiveness.TabIndex = 61
        Me.chbUseLiveness.Text = "Use Liveness"
        Me.chbUseLiveness.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 15)
        Me.Label9.TabIndex = 58
        Me.Label9.Text = "Liveness Threshold"
        '
        'cbMatchingSpeed
        '
        Me.cbMatchingSpeed.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cbMatchingSpeed.FormattingEnabled = True
        Me.cbMatchingSpeed.Location = New System.Drawing.Point(131, 280)
        Me.cbMatchingSpeed.Name = "cbMatchingSpeed"
        Me.cbMatchingSpeed.Size = New System.Drawing.Size(151, 23)
        Me.cbMatchingSpeed.TabIndex = 60
        '
        'nmLivenessThreshold
        '
        Me.nmLivenessThreshold.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmLivenessThreshold.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmLivenessThreshold.Location = New System.Drawing.Point(147, 116)
        Me.nmLivenessThreshold.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmLivenessThreshold.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmLivenessThreshold.Name = "nmLivenessThreshold"
        Me.nmLivenessThreshold.Size = New System.Drawing.Size(135, 23)
        Me.nmLivenessThreshold.TabIndex = 59
        Me.nmLivenessThreshold.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'OFD
        '
        Me.OFD.CheckFileExists = False
        Me.OFD.CheckPathExists = False
        '
        'chbSingleImageRecongition
        '
        Me.chbSingleImageRecongition.AutoSize = True
        Me.chbSingleImageRecongition.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbSingleImageRecongition.Location = New System.Drawing.Point(14, 26)
        Me.chbSingleImageRecongition.Name = "chbSingleImageRecongition"
        Me.chbSingleImageRecongition.Size = New System.Drawing.Size(161, 19)
        Me.chbSingleImageRecongition.TabIndex = 70
        Me.chbSingleImageRecongition.Text = "Single Image Recongition"
        Me.chbSingleImageRecongition.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.nmUserReloginTime)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.chbSingleImageRecongition)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(354, 188)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(293, 100)
        Me.GroupBox3.TabIndex = 30
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Others"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(170, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 15)
        Me.Label13.TabIndex = 73
        Me.Label13.Text = "hr/s"
        '
        'nmUserReloginTime
        '
        Me.nmUserReloginTime.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmUserReloginTime.Location = New System.Drawing.Point(118, 55)
        Me.nmUserReloginTime.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nmUserReloginTime.Name = "nmUserReloginTime"
        Me.nmUserReloginTime.Size = New System.Drawing.Size(46, 23)
        Me.nmUserReloginTime.TabIndex = 71
        Me.nmUserReloginTime.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(11, 57)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 15)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "User Relogin Time"
        '
        'nmMatchingScoreThreshold
        '
        Me.nmMatchingScoreThreshold.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.nmMatchingScoreThreshold.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nmMatchingScoreThreshold.Location = New System.Drawing.Point(176, 240)
        Me.nmMatchingScoreThreshold.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.nmMatchingScoreThreshold.Name = "nmMatchingScoreThreshold"
        Me.nmMatchingScoreThreshold.Size = New System.Drawing.Size(106, 23)
        Me.nmMatchingScoreThreshold.TabIndex = 70
        Me.nmMatchingScoreThreshold.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 242)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 15)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Matching Score Threshold"
        '
        'dlgSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 415)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "dlgSettings"
        Me.Text = "Face Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nmConfidenceThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmQualityThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmMaximalRoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmMaximalYaw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmLivenessBlinkThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmLivenessThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.nmUserReloginTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nmMatchingScoreThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chbUseDeviceManager As System.Windows.Forms.CheckBox
    Friend WithEvents nmConfidenceThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbLivenessMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nmQualityThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents nmMaximalRoll As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nmMaximalYaw As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nmLivenessBlinkThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbTemplateSize As System.Windows.Forms.ComboBox
    Friend WithEvents chbUseLiveness As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbMatchingSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents nmLivenessThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents chbDetectFacialFeature As System.Windows.Forms.CheckBox
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chbSingleImageRecongition As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nmUserReloginTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nmMatchingScoreThreshold As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
