<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimelogSender
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.label1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbQueue = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btnStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConfiguration = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGeneralConf = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDatabaseConf = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmLister = New System.Windows.Forms.Timer(Me.components)
        Me.lstErrorLog = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmUpdateChecker = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.label1, Me.lbStatus, Me.lbQueue})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 412)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(586, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'label1
        '
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(42, 17)
        Me.label1.Text = "Status:"
        '
        'lbStatus
        '
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(59, 17)
        Me.lbStatus.Text = "Standby..."
        '
        'lbQueue
        '
        Me.lbQueue.Name = "lbQueue"
        Me.lbQueue.Size = New System.Drawing.Size(73, 17)
        Me.lbQueue.Text = "On Queue: 0"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStart, Me.btnStop, Me.btnConfiguration})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(586, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btnStart
        '
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(43, 20)
        Me.btnStart.Text = "Start"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(43, 20)
        Me.btnStop.Text = "Stop"
        '
        'btnConfiguration
        '
        Me.btnConfiguration.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnConfiguration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGeneralConf, Me.btnDatabaseConf})
        Me.btnConfiguration.Name = "btnConfiguration"
        Me.btnConfiguration.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.btnConfiguration.Size = New System.Drawing.Size(93, 20)
        Me.btnConfiguration.Text = "Configuration"
        '
        'btnGeneralConf
        '
        Me.btnGeneralConf.Name = "btnGeneralConf"
        Me.btnGeneralConf.Size = New System.Drawing.Size(152, 22)
        Me.btnGeneralConf.Text = "General"
        '
        'btnDatabaseConf
        '
        Me.btnDatabaseConf.Name = "btnDatabaseConf"
        Me.btnDatabaseConf.Size = New System.Drawing.Size(152, 22)
        Me.btnDatabaseConf.Text = "Database"
        '
        'tmLister
        '
        Me.tmLister.Interval = 1000
        '
        'lstErrorLog
        '
        Me.lstErrorLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstErrorLog.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader12, Me.ColumnHeader6})
        Me.lstErrorLog.FullRowSelect = True
        Me.lstErrorLog.Location = New System.Drawing.Point(2, 27)
        Me.lstErrorLog.Name = "lstErrorLog"
        Me.lstErrorLog.Size = New System.Drawing.Size(582, 382)
        Me.lstErrorLog.TabIndex = 3
        Me.lstErrorLog.UseCompatibleStateImageBehavior = False
        Me.lstErrorLog.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 56
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Date"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Message"
        Me.ColumnHeader6.Width = 394
        '
        'tmUpdateChecker
        '
        Me.tmUpdateChecker.Interval = 1000
        '
        'frmTimelogSender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 434)
        Me.Controls.Add(Me.lstErrorLog)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmTimelogSender"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents label1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnConfiguration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmLister As System.Windows.Forms.Timer
    Friend WithEvents lstErrorLog As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lbStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbQueue As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnDatabaseConf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnGeneralConf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmUpdateChecker As System.Windows.Forms.Timer

End Class
