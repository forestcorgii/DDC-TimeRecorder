Imports Time_Recorder_v2._0.AddingUser

Public Class frmRedirect
    Private userDB As UserDatabase

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        MainSetup()
        userDB = New UserDatabase(True)
        If userDB.Count = 0 Then
            frmSetup.ShowDialog()
            If frmSetup.NewUserDB Is Nothing Then Exit Sub Else userDB.Add(frmSetup.NewUserDB)
        End If

        Dim frm As New frmMain(userDB)
        frm.ShowDialog()
    End Sub

    Private Sub frmRedirect_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Close()
    End Sub
End Class