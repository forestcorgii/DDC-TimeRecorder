Namespace VBNETSample
    Partial Class getFingerprints
        Inherits System.Windows.Forms.Form

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(getFingerprints))
            Me.pb2 = New System.Windows.Forms.PictureBox()
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
            Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
            Me.pb3 = New System.Windows.Forms.PictureBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
            Me.pb4 = New System.Windows.Forms.PictureBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
            Me.pb1 = New System.Windows.Forms.PictureBox()
            Me.cbDefPrint = New System.Windows.Forms.ComboBox()
            Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.PictureBox2 = New System.Windows.Forms.PictureBox()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
            Me.btnStart = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnResume = New System.Windows.Forms.ToolStripMenuItem()
            Me.btnClearAll = New System.Windows.Forms.ToolStripMenuItem()
            CType(Me.pb2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TableLayoutPanel5.SuspendLayout()
            CType(Me.pb3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel6.SuspendLayout()
            CType(Me.pb4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel4.SuspendLayout()
            CType(Me.pb1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel2.SuspendLayout()
            Me.TableLayoutPanel3.SuspendLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'pb2
            '
            Me.pb2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.pb2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb2.Location = New System.Drawing.Point(3, 28)
            Me.pb2.Name = "pb2"
            Me.pb2.Size = New System.Drawing.Size(199, 220)
            Me.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pb2.TabIndex = 0
            Me.pb2.TabStop = False
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel5, 0, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel6, 1, 1)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 2
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(421, 515)
            Me.TableLayoutPanel1.TabIndex = 3
            '
            'TableLayoutPanel5
            '
            Me.TableLayoutPanel5.ColumnCount = 1
            Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Controls.Add(Me.pb3, 0, 1)
            Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 0)
            Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 260)
            Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
            Me.TableLayoutPanel5.RowCount = 2
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel5.Size = New System.Drawing.Size(204, 252)
            Me.TableLayoutPanel5.TabIndex = 6
            '
            'pb3
            '
            Me.pb3.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.pb3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb3.Location = New System.Drawing.Point(3, 28)
            Me.pb3.Name = "pb3"
            Me.pb3.Size = New System.Drawing.Size(198, 221)
            Me.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pb3.TabIndex = 0
            Me.pb3.TabStop = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(3, 0)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(198, 25)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "Specimen 3"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TableLayoutPanel6
            '
            Me.TableLayoutPanel6.ColumnCount = 1
            Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel6.Controls.Add(Me.pb4, 0, 1)
            Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 0)
            Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
            Me.TableLayoutPanel6.Location = New System.Drawing.Point(213, 260)
            Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
            Me.TableLayoutPanel6.RowCount = 2
            Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel6.Size = New System.Drawing.Size(205, 252)
            Me.TableLayoutPanel6.TabIndex = 7
            '
            'pb4
            '
            Me.pb4.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.pb4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb4.Location = New System.Drawing.Point(3, 28)
            Me.pb4.Name = "pb4"
            Me.pb4.Size = New System.Drawing.Size(199, 221)
            Me.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pb4.TabIndex = 0
            Me.pb4.TabStop = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(3, 0)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(199, 25)
            Me.Label4.TabIndex = 1
            Me.Label4.Text = "Specimen 4"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TableLayoutPanel4
            '
            Me.TableLayoutPanel4.ColumnCount = 1
            Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.Controls.Add(Me.pb1, 0, 1)
            Me.TableLayoutPanel4.Controls.Add(Me.cbDefPrint, 0, 0)
            Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
            Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
            Me.TableLayoutPanel4.RowCount = 2
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel4.Size = New System.Drawing.Size(204, 251)
            Me.TableLayoutPanel4.TabIndex = 5
            '
            'pb1
            '
            Me.pb1.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.pb1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb1.Location = New System.Drawing.Point(3, 23)
            Me.pb1.Name = "pb1"
            Me.pb1.Size = New System.Drawing.Size(198, 225)
            Me.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pb1.TabIndex = 0
            Me.pb1.TabStop = False
            '
            'cbDefPrint
            '
            Me.cbDefPrint.BackColor = System.Drawing.Color.White
            Me.cbDefPrint.Dock = System.Windows.Forms.DockStyle.Fill
            Me.cbDefPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbDefPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbDefPrint.FormattingEnabled = True
            Me.cbDefPrint.Items.AddRange(New Object() {"Pinky Left", "Ring Left", "Middle Left", "Index Left", "Thumb Left", "Thumb Right", "Index Right", "Middle Right", "Ring Right", "Pinky Right"})
            Me.cbDefPrint.Location = New System.Drawing.Point(3, 3)
            Me.cbDefPrint.Name = "cbDefPrint"
            Me.cbDefPrint.Size = New System.Drawing.Size(198, 21)
            Me.cbDefPrint.TabIndex = 9
            '
            'TableLayoutPanel2
            '
            Me.TableLayoutPanel2.ColumnCount = 1
            Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Controls.Add(Me.pb2, 0, 1)
            Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
            Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TableLayoutPanel2.Location = New System.Drawing.Point(213, 3)
            Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
            Me.TableLayoutPanel2.RowCount = 2
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel2.Size = New System.Drawing.Size(205, 251)
            Me.TableLayoutPanel2.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(3, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(199, 25)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Specimen 2 "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TableLayoutPanel3
            '
            Me.TableLayoutPanel3.ColumnCount = 1
            Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
            Me.TableLayoutPanel3.Controls.Add(Me.PictureBox2, 0, 1)
            Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
            Me.TableLayoutPanel3.RowCount = 3
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel3.Size = New System.Drawing.Size(200, 100)
            Me.TableLayoutPanel3.TabIndex = 0
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label2.Location = New System.Drawing.Point(3, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(194, 20)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "Finger Name"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'PictureBox2
            '
            Me.PictureBox2.BackColor = System.Drawing.SystemColors.ControlDark
            Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PictureBox2.Location = New System.Drawing.Point(3, 23)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(194, 14)
            Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.PictureBox2.TabIndex = 0
            Me.PictureBox2.TabStop = False
            '
            'Button2
            '
            Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Button2.Location = New System.Drawing.Point(3, -13)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(139, 24)
            Me.Button2.TabIndex = 1
            Me.Button2.Text = "Change"
            Me.Button2.UseVisualStyleBackColor = True
            '
            'MenuStrip1
            '
            Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnStart, Me.btnResume, Me.btnClearAll})
            Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(421, 24)
            Me.MenuStrip1.TabIndex = 5
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'btnStart
            '
            Me.btnStart.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnStart.ForeColor = System.Drawing.Color.White
            Me.btnStart.Name = "btnStart"
            Me.btnStart.Size = New System.Drawing.Size(47, 20)
            Me.btnStart.Text = "Start"
            '
            'btnResume
            '
            Me.btnResume.Enabled = False
            Me.btnResume.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnResume.ForeColor = System.Drawing.Color.White
            Me.btnResume.Name = "btnResume"
            Me.btnResume.Size = New System.Drawing.Size(66, 20)
            Me.btnResume.Text = "Resume"
            '
            'btnClearAll
            '
            Me.btnClearAll.BackColor = System.Drawing.Color.Transparent
            Me.btnClearAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.btnClearAll.ForeColor = System.Drawing.Color.White
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.Size = New System.Drawing.Size(65, 20)
            Me.btnClearAll.Text = "Clear all"
            '
            'getFingerprints
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(137, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(421, 539)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Controls.Add(Me.MenuStrip1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MainMenuStrip = Me.MenuStrip1
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "getFingerprints"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Time Recorder v1.0"
            CType(Me.pb2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel5.ResumeLayout(False)
            CType(Me.pb3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel6.ResumeLayout(False)
            CType(Me.pb4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel4.ResumeLayout(False)
            CType(Me.pb1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel2.ResumeLayout(False)
            Me.TableLayoutPanel3.ResumeLayout(False)
            Me.TableLayoutPanel3.PerformLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents pb2 As System.Windows.Forms.PictureBox
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pb3 As System.Windows.Forms.PictureBox
        Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pb4 As System.Windows.Forms.PictureBox
        Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
        Friend WithEvents btnClearAll As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnResume As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents btnStart As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pb1 As System.Windows.Forms.PictureBox
        Friend WithEvents cbDefPrint As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label

    End Class
End Namespace