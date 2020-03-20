Imports System.ComponentModel

Public Class sfrmPrintReader
    Public UserDB As New UserRecords
    Private callback As DoWorkEventHandler
    Protected WithEvents bgwScan As New BackgroundWorker()

    Public Sub New(_userDB As UserRecords)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UserDB = _userDB
        UserDB.UserRecs = New List(Of UserRecord)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmPrintReader_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        clean()
    End Sub

    Private Sub frmPrintReader_Load(sender As Object, e As EventArgs) Handles Me.Load
        pb1.Value = 0
        callback = AddressOf doEnroll
        bgwScan.WorkerSupportsCancellation = True
        bgwScan.WorkerReportsProgress = True

        useID(TempUsername)
        bgwScan.RunWorkerAsync(False)
    End Sub

    Private Sub enroll(e As Object)
        If e IsNot Nothing Then
            Dim result As EnrollmentResult = DirectCast(e, EnrollmentResult)
            If result.engineStatus = Neurotec.Biometrics.NffvStatus.TemplateCreated Then
                UserDB.UserRecs.Add(New UserRecord(result.engineUser.Id, UserDB.UserRecs.Count + 1))
                startCount()
                If UserDB.UserRecs.Count = 4 Then
                    Me.Close()
                Else
                    bgwScan.RunWorkerAsync(False)
                End If
            End If
        End If
    End Sub

    Private Sub clean()
        If bgwScan.IsBusy Then
            CancelScanningHandler()
            Engine.Dispose()
        End If
        If Not UserDB.UserRecs.Count = 4 Then
            IO.File.Delete(IO.Path.Combine(Application.StartupPath, TempUsername & ext.datEx))
        End If

        useID(DummyUsername) '//To release temp user from fingerprint Server
        Engine.Dispose()
        IO.File.Delete(IO.Path.Combine(Application.StartupPath, DummyUsername & ext.datEx))
    End Sub

    Private Sub startCount()
        For i As Integer = 1 To 150
            pb1.Value += 1
        Next
    End Sub

#Region "Background worker"
    Private Sub BusyForm_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwScan.DoWork
        Try
            callback(sender, e)
        Catch ex As Exception
            'workerError = ex
        End Try
    End Sub

    Private Sub BusyForm_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwScan.RunWorkerCompleted
        If Not e.Cancelled Then
            enroll(e.Result)
        End If
    End Sub
#End Region


End Class