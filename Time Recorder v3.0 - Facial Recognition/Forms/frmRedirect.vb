Imports Time_Recorder_v3._0.AddingUser

Public Class frmRedirect
   
    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        frmMain.MainSetup()
        TimeRecorderUserEngines = New UserDatabase(True)
        If TimeRecorderUserEngines.Count = 0 Then
            frmSetup.ShowDialog()
            If frmSetup.NewUserDB Is Nothing Then Exit Sub Else TimeRecorderUserEngines.Add(frmSetup.NewUserDB)
        End If

        Dim frm As New frmMain()
        frm.ShowDialog()
    End Sub

    Private Sub frmRedirect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Close()
    End Sub
End Class