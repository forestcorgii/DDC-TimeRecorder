<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sfrmPrintReader
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sfrmPrintReader))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pb1 = New CustomComponents.ArcProgressbar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Time_Recorder_v3._0.My.Resources.Resources.info
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 76)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Press the scanner using your Right Index Finger or other Finger." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press it four" & _
    " times using the same Finger."
        '
        'pb1
        '
        Me.pb1.AngleLength = 67.0!
        Me.pb1.BackColor = System.Drawing.Color.Gray
        Me.pb1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pb1.Location = New System.Drawing.Point(56, 94)
        Me.pb1.Margin = New System.Windows.Forms.Padding(0)
        Me.pb1.MarqueeSpeed = 1
        Me.pb1.MarqueeType = CustomComponents.ArcProgressbar.mrqType.Process2
        Me.pb1.MaxValue = 600.0R
        Me.pb1.MinimumSize = New System.Drawing.Size(50, 50)
        Me.pb1.Name = "pb1"
        Me.pb1.OuterBackColor = System.Drawing.Color.White
        Me.pb1.OuterMargin = 10
        Me.pb1.OuterWidth = 5
        Me.pb1.PenWidth = 15
        Me.pb1.ProcessBackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.pb1.ProcessForeColor = System.Drawing.Color.Maroon
        Me.pb1.ProcessMargin = 10
        Me.pb1.ProgressTextEnable = False
        Me.pb1.ProgressType = CustomComponents.ArcProgressbar.pType.WithValue
        Me.pb1.Size = New System.Drawing.Size(150, 150)
        Me.pb1.startAngle = 0.0!
        Me.pb1.StartMarquee = True
        Me.pb1.TabIndex = 2
        Me.pb1.Value = 100.0R
        '
        'frmPrintReader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(246, 252)
        Me.Controls.Add(Me.pb1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPrintReader"
        Me.Text = "frmPrintReader"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pb1 As CustomComponents.ArcProgressbar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
