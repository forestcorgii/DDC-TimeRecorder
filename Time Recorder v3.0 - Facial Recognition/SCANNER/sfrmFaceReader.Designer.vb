<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmFaceReader
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
        Me.pixSample1 = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.pixSample2 = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.pixSample3 = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.pixDetector = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        CType(Me.pixSample1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pixSample2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pixSample3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pixDetector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pixSample1
        '
        Me.pixSample1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pixSample1.Location = New System.Drawing.Point(12, 398)
        Me.pixSample1.Name = "pixSample1"
        Me.pixSample1.Size = New System.Drawing.Size(140, 140)
        Me.pixSample1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pixSample1.TabIndex = 0
        Me.pixSample1.TabStop = False
        '
        'pixSample2
        '
        Me.pixSample2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pixSample2.Location = New System.Drawing.Point(157, 398)
        Me.pixSample2.Name = "pixSample2"
        Me.pixSample2.Size = New System.Drawing.Size(140, 140)
        Me.pixSample2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pixSample2.TabIndex = 1
        Me.pixSample2.TabStop = False
        '
        'pixSample3
        '
        Me.pixSample3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pixSample3.Location = New System.Drawing.Point(302, 398)
        Me.pixSample3.Name = "pixSample3"
        Me.pixSample3.Size = New System.Drawing.Size(140, 140)
        Me.pixSample3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pixSample3.TabIndex = 2
        Me.pixSample3.TabStop = False
        '
        'pixDetector
        '
        Me.pixDetector.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pixDetector.Location = New System.Drawing.Point(12, 12)
        Me.pixDetector.Name = "pixDetector"
        Me.pixDetector.Size = New System.Drawing.Size(711, 380)
        Me.pixDetector.TabIndex = 3
        Me.pixDetector.TabStop = False
        '
        'timer1
        '
        Me.timer1.Interval = 3000
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(448, 398)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(448, 427)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'sfrmAddFace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 541)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.pixDetector)
        Me.Controls.Add(Me.pixSample3)
        Me.Controls.Add(Me.pixSample2)
        Me.Controls.Add(Me.pixSample1)
        Me.Name = "sfrmAddFace"
        Me.Text = "sfrmAddFace"
        CType(Me.pixSample1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pixSample2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pixSample3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pixDetector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents pixSample1 As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents pixSample2 As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents pixSample3 As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents pixDetector As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class
