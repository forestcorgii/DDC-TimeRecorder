Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace Neurotec.Gui
    Partial Public Class Scan
        Inherits Form
        Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Private callback As DoWorkEventHandler
        Private argument As Object
        Private results As RunWorkerCompletedEventArgs
        Private workerError As Exception
        Friend WithEvents lbFName As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lbDept As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lbStatus As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Protected _worker As New BackgroundWorker()
        Friend WithEvents lbPrompt As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents lbSC As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lbEM As System.Windows.Forms.Label
        Private mouseDownLoc As Point

        Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
            mouseDownLoc.X = e.X
            mouseDownLoc.Y = e.Y
        End Sub
        Private Sub Label1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
            If e.Button = MouseButtons.Left Then
                Me.Left += e.X - mouseDownLoc.X
                Me.Top += e.Y - mouseDownLoc.Y
            End If
        End Sub

        Private Sub New(ByVal info As String(), ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean)
            Me.New(info, title, callback, reportsProgress, Nothing, Nothing)
        End Sub

        Private Sub New(ByVal info As String(), ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal args As Object, ByVal cancelHandler As EventHandler)
            InitializeComponent()

            fullname = info(1)
            SC = info(2)
            department = info(3)
            EM = info(4)

            If info(0) = "-1" Then
                displayTimeIn("TIME IN")
            Else
                displayTimeOut("TIME OUT")
            End If

            If Not reportsProgress Then
                ProgressBar.Style = ProgressBarStyle.Marquee
            End If

            SetExecutionText(title)
            Me.callback = callback
            argument = args
            _worker.WorkerReportsProgress = reportsProgress
            AddHandler _worker.DoWork, AddressOf BusyForm_DoWork
            AddHandler _worker.RunWorkerCompleted, AddressOf BusyForm_RunWorkerCompleted
            AddHandler _worker.ProgressChanged, AddressOf BusyForm_ProgressChanged

            If cancelHandler IsNot Nothing Then
                _worker.WorkerSupportsCancellation = True
                AddHandler btnCancel.Click, cancelHandler
                AddHandler btnCancel.Click, New EventHandler(AddressOf PostOnCancelClick)
                btnCancel.Enabled = True
                btnCancel.Visible = True
            End If
        End Sub

        Private Sub PostOnCancelClick(ByVal sender As Object, ByVal e As EventArgs)
            btnCancel.Enabled = False
            btnCancel.Refresh()
        End Sub

        Public Shared Function RunLongTask(ByVal info As String(), ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal args As Object, ByVal cancelHandler As EventHandler) As RunWorkerCompletedEventArgs
            Using frmLongTask As New Scan(info, title, callback, reportsProgress, args, cancelHandler)
                frmLongTask.ShowDialog()
                If frmLongTask.workerError IsNot Nothing Then
                    Throw frmLongTask.workerError
                End If
                Return frmLongTask.results
            End Using
        End Function

        Private Sub Scan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
            If e.KeyCode = Keys.Escape Then
                btnCancel.PerformClick()
            End If
        End Sub

        Private Sub BusyForm_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
            _worker.RunWorkerAsync(argument)
        End Sub



#Region "Time in/Time out"

        Public Sub displayTimeIn(ByVal st As String)
             status = st
            Application.DoEvents()
        End Sub

        Public Sub displayTimeOut(ByVal st As String)
            status = st
            Application.DoEvents()
        End Sub
#End Region

#Region "Background worker"
        Private Sub BusyForm_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            Try
                callback(sender, e)
            Catch ex As Exception
                workerError = ex
            End Try
        End Sub

        Private Sub BusyForm_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
            Dim text As String = TryCast(e.UserState, String)
            If text IsNot Nothing Then
                SetExecutionText(text)
            End If
        End Sub

        Private Sub BusyForm_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            results = e
            Close()
        End Sub
#End Region

#Region "Setters/Getters"
        Public Delegate Sub StringMethod(ByVal value As String)
        Public Sub SetExecutionText(ByVal text As String)
            Try
                If Me.InvokeRequired Then
                    lbPrompt.Invoke(DirectCast(AddressOf SetExecutionText, StringMethod))
                Else
                    lbPrompt.Text = text
                End If
            Finally
            End Try
        End Sub

        Public Delegate Sub IntegerMethod(ByVal value As Integer)
        Public Sub SetExecutionValue(ByVal value As Integer)
            Try
                If ProgressBar.InvokeRequired Then
                    ProgressBar.Invoke(DirectCast(AddressOf SetExecutionValue, IntegerMethod), value)
                Else
                    ProgressBar.Value = value
                End If
            Finally
            End Try
        End Sub
#End Region

#Region "Public Properties"
        Public Property fullname() As String
            Get
                Return lbFName.Text
            End Get
            Set(ByVal value As String)
                lbFName.Text = value
            End Set
        End Property
        Public Property department() As String
            Get
                Return lbDept.Text
            End Get
            Set(ByVal value As String)
                lbDept.Text = value
            End Set
        End Property
        Public Property SC() As String
            Get
                Return lbSC.Text
            End Get
            Set(ByVal value As String)
                lbSC.Text = value
            End Set
        End Property
        Public Property EM() As String
            Get
                Return lbEM.Text
            End Get
            Set(ByVal value As String)
                lbEM.Text = value
            End Set
        End Property
        Public Property status() As String
            Get
                Return lbStatus.Text
            End Get
            Set(ByVal value As String)
                lbStatus.Text = value
            End Set
        End Property
#End Region

        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scan))
            Me.ProgressBar = New System.Windows.Forms.ProgressBar
            Me.btnCancel = New System.Windows.Forms.Button
            Me.lbFName = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.lbDept = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.lbStatus = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.Label7 = New System.Windows.Forms.Label
            Me.lbSC = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.lbEM = New System.Windows.Forms.Label
            Me.lbPrompt = New System.Windows.Forms.Label
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'ProgressBar
            '
            Me.ProgressBar.Location = New System.Drawing.Point(15, 186)
            Me.ProgressBar.Name = "ProgressBar"
            Me.ProgressBar.Size = New System.Drawing.Size(316, 27)
            Me.ProgressBar.TabIndex = 0
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Transparent
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
            Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopRight
            Me.btnCancel.Location = New System.Drawing.Point(306, 1)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(38, 35)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.UseVisualStyleBackColor = False
            Me.btnCancel.Visible = False
            '
            'lbFName
            '
            Me.lbFName.BackColor = System.Drawing.Color.Transparent
            Me.lbFName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbFName.ForeColor = System.Drawing.Color.Black
            Me.lbFName.Location = New System.Drawing.Point(104, 16)
            Me.lbFName.Name = "lbFName"
            Me.lbFName.Size = New System.Drawing.Size(227, 33)
            Me.lbFName.TabIndex = 2
            Me.lbFName.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(15, 114)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(45, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "DEPT:"
            '
            'lbDept
            '
            Me.lbDept.BackColor = System.Drawing.Color.Transparent
            Me.lbDept.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDept.ForeColor = System.Drawing.Color.Black
            Me.lbDept.Location = New System.Drawing.Point(104, 114)
            Me.lbDept.Name = "lbDept"
            Me.lbDept.Size = New System.Drawing.Size(227, 15)
            Me.lbDept.TabIndex = 4
            Me.lbDept.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(15, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(82, 16)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "FULLNAME:"
            '
            'lbStatus
            '
            Me.lbStatus.BackColor = System.Drawing.Color.Transparent
            Me.lbStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbStatus.ForeColor = System.Drawing.Color.Black
            Me.lbStatus.Location = New System.Drawing.Point(104, 149)
            Me.lbStatus.Name = "lbStatus"
            Me.lbStatus.Size = New System.Drawing.Size(227, 15)
            Me.lbStatus.TabIndex = 6
            Me.lbStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(15, 149)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(62, 16)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "STATUS:"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(3, 216)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(115, 15)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "click ESC to cancel"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
            Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.Panel1.Controls.Add(Me.Label7)
            Me.Panel1.Controls.Add(Me.lbSC)
            Me.Panel1.Controls.Add(Me.Label5)
            Me.Panel1.Controls.Add(Me.lbEM)
            Me.Panel1.Controls.Add(Me.ProgressBar)
            Me.Panel1.Controls.Add(Me.lbFName)
            Me.Panel1.Controls.Add(Me.Label1)
            Me.Panel1.Controls.Add(Me.Label4)
            Me.Panel1.Controls.Add(Me.Label2)
            Me.Panel1.Controls.Add(Me.lbStatus)
            Me.Panel1.Controls.Add(Me.lbDept)
            Me.Panel1.Controls.Add(Me.Label3)
            Me.Panel1.Location = New System.Drawing.Point(4, 33)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(340, 237)
            Me.Panel1.TabIndex = 10
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Black
            Me.Label7.Location = New System.Drawing.Point(16, 90)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(75, 16)
            Me.Label7.TabIndex = 18
            Me.Label7.Text = "COMPANY:"
            '
            'lbSC
            '
            Me.lbSC.BackColor = System.Drawing.Color.Transparent
            Me.lbSC.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbSC.ForeColor = System.Drawing.Color.Black
            Me.lbSC.Location = New System.Drawing.Point(110, 88)
            Me.lbSC.Name = "lbSC"
            Me.lbSC.Size = New System.Drawing.Size(221, 15)
            Me.lbSC.TabIndex = 19
            Me.lbSC.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(16, 65)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(109, 16)
            Me.Label5.TabIndex = 16
            Me.Label5.Text = "EMPLOYEE NO :"
            '
            'lbEM
            '
            Me.lbEM.BackColor = System.Drawing.Color.Transparent
            Me.lbEM.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbEM.ForeColor = System.Drawing.Color.Black
            Me.lbEM.Location = New System.Drawing.Point(107, 66)
            Me.lbEM.Name = "lbEM"
            Me.lbEM.Size = New System.Drawing.Size(224, 15)
            Me.lbEM.TabIndex = 17
            Me.lbEM.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lbPrompt
            '
            Me.lbPrompt.BackColor = System.Drawing.Color.Transparent
            Me.lbPrompt.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbPrompt.ForeColor = System.Drawing.Color.White
            Me.lbPrompt.Location = New System.Drawing.Point(0, 1)
            Me.lbPrompt.Name = "lbPrompt"
            Me.lbPrompt.Size = New System.Drawing.Size(299, 29)
            Me.lbPrompt.TabIndex = 16
            Me.lbPrompt.Text = "Prompt"
            Me.lbPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Scan
            '
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(348, 275)
            Me.Controls.Add(Me.lbPrompt)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.btnCancel)
            Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Name = "Scan"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.TopMost = True
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

    End Class
End Namespace


