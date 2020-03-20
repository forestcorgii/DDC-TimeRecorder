

Public Class sfrmConfiguration
    Public EmailInfo As clsEmailInfo

    Sub New(_emailinfo As clsEmailInfo)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        EmailInfo = New clsEmailInfo
        If _emailinfo IsNot Nothing Then
            EmailInfo = _emailinfo
            With EmailInfo
                tbHost.Text = .Host
                tbPort.Text = .Port
                tbRecipientAddress.Text = .RecipientAddress
                tbRecipientName.Text = .RecipientName
                tbSenderAddress.Text = .SenderAddress
                tbSenderName.Text = .SenderName
            End With
        End If

        DialogResult = Windows.Forms.DialogResult.None
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With EmailInfo
            .Host = tbHost.Text
            .Port = tbPort.Text
            .RecipientAddress = tbRecipientAddress.Text
            .RecipientName = tbRecipientName.Text
            .SenderAddress = tbSenderAddress.Text
            .SenderName = tbSenderName.Text
        End With
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class