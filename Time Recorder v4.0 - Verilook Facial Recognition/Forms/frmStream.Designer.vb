<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStream
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tmChecker = New System.Windows.Forms.Timer(Me.components)
        Me.tmClosingAttempt = New System.Windows.Forms.Timer(Me.components)
        Me.fvStream2 = New Neurotec.Biometrics.Gui.NFaceView()
        Me.tmCamera2Checking = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.fvStream.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fvStream
        '
        Me.fvStream.BackColor = System.Drawing.Color.Black
        Me.fvStream.Controls.Add(Me.Button1)
        Me.fvStream.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fvStream.Face = Nothing
        Me.fvStream.FaceIds = Nothing
        Me.fvStream.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fvStream.Location = New System.Drawing.Point(1, 1)
        Me.fvStream.Margin = New System.Windows.Forms.Padding(1)
        Me.fvStream.Name = "fvStream"
        Me.fvStream.ShowIcaoArrows = True
        Me.fvStream.ShowTokenImageRectangle = True
        Me.fvStream.Size = New System.Drawing.Size(400, 223)
        Me.fvStream.TabIndex = 0
        Me.fvStream.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 346)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tmChecker
        '
        Me.tmChecker.Interval = 2000
        '
        'tmClosingAttempt
        '
        Me.tmClosingAttempt.Interval = 500
        '
        'fvStream2
        '
        Me.fvStream2.BackColor = System.Drawing.Color.Black
        Me.fvStream2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fvStream2.Face = Nothing
        Me.fvStream2.FaceIds = Nothing
        Me.fvStream2.IcaoArrowsColor = System.Drawing.Color.Red
        Me.fvStream2.Location = New System.Drawing.Point(403, 1)
        Me.fvStream2.Margin = New System.Windows.Forms.Padding(1)
        Me.fvStream2.Name = "fvStream2"
        Me.fvStream2.ShowIcaoArrows = True
        Me.fvStream2.ShowTokenImageRectangle = True
        Me.fvStream2.Size = New System.Drawing.Size(1, 223)
        Me.fvStream2.TabIndex = 1
        Me.fvStream2.TokenImageRectangleColor = System.Drawing.Color.White
        '
        'tmCamera2Checking
        '
        Me.tmCamera2Checking.Interval = 500
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.fvStream, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.fvStream2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(402, 225)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'frmStream
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 225)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.KeyPreview = True
        Me.Name = "frmStream"
        Me.Text = "frmStream"
        Me.fvStream.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fvStream As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents tmChecker As System.Windows.Forms.Timer
    Friend WithEvents tmClosingAttempt As System.Windows.Forms.Timer
    Friend WithEvents fvStream2 As Neurotec.Biometrics.Gui.NFaceView
    Friend WithEvents tmCamera2Checking As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
