<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmFaceScanner
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
        Me.pixDetector = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.pb1 = New ModifiedComponents.ArcProgressbar()
        CType(Me.pixDetector, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pixDetector
        '
        Me.pixDetector.Location = New System.Drawing.Point(0, 0)
        Me.pixDetector.Name = "pixDetector"
        Me.pixDetector.Size = New System.Drawing.Size(636, 373)
        Me.pixDetector.TabIndex = 0
        Me.pixDetector.TabStop = False
        '
        'pb1
        '
        Me.pb1.AngleLength = 69.0!
        Me.pb1.BackColor = System.Drawing.Color.Transparent
        Me.pb1.Location = New System.Drawing.Point(566, 376)
        Me.pb1.Margin = New System.Windows.Forms.Padding(0)
        Me.pb1.MarqueeSpeed = 10
        Me.pb1.MarqueeType = ModifiedComponents.ArcProgressbar.mrqType.Process1
        Me.pb1.MaxValue = 600.0R
        Me.pb1.MinimumSize = New System.Drawing.Size(32, 32)
        Me.pb1.Name = "pb1"
        Me.pb1.OuterBackColor = System.Drawing.Color.Gray
        Me.pb1.OuterMargin = 0
        Me.pb1.OuterWidth = 5
        Me.pb1.PenWidth = 15
        Me.pb1.ProcessBackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.pb1.ProcessForeColor = System.Drawing.Color.Maroon
        Me.pb1.ProcessMargin = 1
        Me.pb1.ProgressTextEnable = False
        Me.pb1.ProgressType = ModifiedComponents.ArcProgressbar.pType.Marquee
        Me.pb1.Size = New System.Drawing.Size(70, 70)
        Me.pb1.startAngle = 0.0!
        Me.pb1.StartMarquee = True
        Me.pb1.TabIndex = 3
        Me.pb1.Value = 550.0R
        '
        'sfrmFaceScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 445)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.pixDetector)
        Me.Name = "sfrmFaceScanner"
        Me.Text = "sfrmFaceScanner"
        Me.TopMost = True
        CType(Me.pixDetector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pixDetector As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents pb1 As ModifiedComponents.ArcProgressbar
End Class
