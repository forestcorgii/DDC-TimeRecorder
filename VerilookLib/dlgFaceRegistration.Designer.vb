<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgFaceRegistration
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
        Me.fvStream = New Neurotec.Biometrics.Gui.NFaceView()
        Me.fv1 = New Neurotec.Biometrics.Gui.NFaceView()
        Me.fv2 = New Neurotec.Biometrics.Gui.NFaceView()
        Me.fv3 = New Neurotec.Biometrics.Gui.NFaceView()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.tmClosingAttempt = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'fvStream
        '
        Me.fvStream.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fvStream.BackColor = System.Drawing.Color.Transparent
        Me.fvStream.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fvStream.Face = Nothing
        Me.fvStream.FaceIds = Nothing
        Me.fvStream.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fvStream.Location = New System.Drawing.Point(1, 1)
        Me.fvStream.Name = "fvStream"
        Me.fvStream.ShowIcaoArrows = True
        Me.fvStream.ShowTokenImageRectangle = True
        Me.fvStream.Size = New System.Drawing.Size(581, 244)
        Me.fvStream.TabIndex = 0
        Me.fvStream.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'fv1
        '
        Me.fv1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fv1.BackColor = System.Drawing.Color.DimGray
        Me.fv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fv1.Face = Nothing
        Me.fv1.FaceIds = Nothing
        Me.fv1.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fv1.Location = New System.Drawing.Point(1, 246)
        Me.fv1.Name = "fv1"
        Me.fv1.ShowIcaoArrows = True
        Me.fv1.ShowTokenImageRectangle = True
        Me.fv1.Size = New System.Drawing.Size(139, 142)
        Me.fv1.TabIndex = 1
        Me.fv1.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'fv2
        '
        Me.fv2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fv2.BackColor = System.Drawing.Color.DimGray
        Me.fv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fv2.Face = Nothing
        Me.fv2.FaceIds = Nothing
        Me.fv2.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fv2.Location = New System.Drawing.Point(141, 246)
        Me.fv2.Name = "fv2"
        Me.fv2.ShowIcaoArrows = True
        Me.fv2.ShowTokenImageRectangle = True
        Me.fv2.Size = New System.Drawing.Size(139, 142)
        Me.fv2.TabIndex = 2
        Me.fv2.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'fv3
        '
        Me.fv3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fv3.BackColor = System.Drawing.Color.DimGray
        Me.fv3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fv3.Face = Nothing
        Me.fv3.FaceIds = Nothing
        Me.fv3.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fv3.Location = New System.Drawing.Point(281, 246)
        Me.fv3.Name = "fv3"
        Me.fv3.ShowIcaoArrows = True
        Me.fv3.ShowTokenImageRectangle = True
        Me.fv3.Size = New System.Drawing.Size(139, 142)
        Me.fv3.TabIndex = 2
        Me.fv3.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'btnCapture
        '
        Me.btnCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCapture.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapture.Location = New System.Drawing.Point(429, 252)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(149, 105)
        Me.btnCapture.TabIndex = 3
        Me.btnCapture.Text = "Capture"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'btnRestart
        '
        Me.btnRestart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRestart.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestart.Location = New System.Drawing.Point(429, 363)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(149, 25)
        Me.btnRestart.TabIndex = 4
        Me.btnRestart.Text = "Restart"
        Me.btnRestart.UseVisualStyleBackColor = True
        '
        'tmClosingAttempt
        '
        Me.tmClosingAttempt.Interval = 1000
        '
        'dlgFaceRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(584, 391)
        Me.Controls.Add(Me.btnRestart)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.fv2)
        Me.Controls.Add(Me.fv3)
        Me.Controls.Add(Me.fv1)
        Me.Controls.Add(Me.fvStream)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "dlgFaceRegistration"
        Me.ShowIcon = False
        Me.Text = "Capturing Face Images..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fvStream As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents fv1 As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents fv2 As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents fv3 As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents btnRestart As System.Windows.Forms.Button
    Friend WithEvents tmClosingAttempt As System.Windows.Forms.Timer
End Class
