Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Partial Public Class ScanNew
    Inherits Form
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Private callback As DoWorkEventHandler
    Private argument As Object
    Private results As RunWorkerCompletedEventArgs
    Private workerError As Exception
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected _worker As New BackgroundWorker()
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbPrompt As System.Windows.Forms.Label
    Friend WithEvents lbMSG As System.Windows.Forms.Label

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

    Private Sub New(ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean)
        Me.New(title, callback, reportsProgress, Nothing, Nothing)
    End Sub

    Private Sub New(ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal args As Object, ByVal cancelHandler As EventHandler)
        InitializeComponent()

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

    Public Shared Function RunLongTask(ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal cancelHandler As EventHandler) As RunWorkerCompletedEventArgs
        Using frmLongTask As New ScanNew(title, callback, reportsProgress, False, cancelHandler)
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

    Public Shared Function RunLongTask(ByVal msg As String, ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal args As Object, ByVal cancelHandler As EventHandler) As RunWorkerCompletedEventArgs
        Using frmLongTask As New ScanNew(msg, title, callback, reportsProgress, args, cancelHandler)
            frmLongTask.ShowDialog()
            If frmLongTask.workerError IsNot Nothing Then
                Throw frmLongTask.workerError
            End If
            Return frmLongTask.results
        End Using
    End Function

    Private Sub New(ByVal msg As String, ByVal title As String, ByVal callback As DoWorkEventHandler, ByVal reportsProgress As Boolean, ByVal args As Object, ByVal cancelHandler As EventHandler)
        InitializeComponent()

        If Not reportsProgress Then
            ProgressBar.Style = ProgressBarStyle.Marquee
        End If

        lbMSG.Text = msg

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

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanNew))
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lbPrompt = New System.Windows.Forms.Label
        Me.lbMSG = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(6, 33)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(325, 28)
        Me.ProgressBar.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "click ESC to cancel"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.GhostWhite
        Me.Panel1.Controls.Add(Me.lbMSG)
        Me.Panel1.Controls.Add(Me.ProgressBar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 82)
        Me.Panel1.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.btnCancel.Location = New System.Drawing.Point(305, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(38, 35)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.UseVisualStyleBackColor = False
        Me.btnCancel.Visible = False
        '
        'lbPrompt
        '
        Me.lbPrompt.BackColor = System.Drawing.Color.Transparent
        Me.lbPrompt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrompt.ForeColor = System.Drawing.Color.White
        Me.lbPrompt.Location = New System.Drawing.Point(2, 3)
        Me.lbPrompt.Name = "lbPrompt"
        Me.lbPrompt.Size = New System.Drawing.Size(304, 29)
        Me.lbPrompt.TabIndex = 17
        Me.lbPrompt.Text = "Prompt"
        Me.lbPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbMSG
        '
        Me.lbMSG.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMSG.Location = New System.Drawing.Point(5, 6)
        Me.lbMSG.Name = "lbMSG"
        Me.lbMSG.Size = New System.Drawing.Size(326, 24)
        Me.lbMSG.TabIndex = 10
        '
        'ScanNew
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(342, 119)
        Me.Controls.Add(Me.lbPrompt)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "ScanNew"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

End Class



