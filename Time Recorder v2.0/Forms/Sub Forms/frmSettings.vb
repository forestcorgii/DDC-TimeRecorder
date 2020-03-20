Public Class frmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbCompany.Text = My.Settings.Company
        tbCompAcro.Text = My.Settings.Acronym
        cbDump.Checked = My.Settings.dumpenabled
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("Are You sure you want to save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            My.Settings.Acronym = tbCompAcro.Text
            My.Settings.Company = tbCompany.Text
            My.Settings.dumpenabled = cbDump.Checked
            My.Settings.Save()
            If My.Settings.dumpenabled Then IO.Directory.CreateDirectory(Application.StartupPath & "\Dump")

            Me.Close()
        End If
    End Sub

End Class