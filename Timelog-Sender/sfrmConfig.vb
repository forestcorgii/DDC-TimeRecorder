Imports SEAN.ConfigurationStoring
Public Class sfrmConfig

    Public GeneralConfig As GeneralConfiguration
    Private confFilePath As String

    Sub New(_generalConfig As GeneralConfiguration, _confFilePath As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogResult = Windows.Forms.DialogResult.None
        confFilePath = _confFilePath
        generalConfig = _generalConfig
        With generalConfig
            tbAddress.Text = generalConfig.Address
            nmWorkersCount.Value = .WorkersCount
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With generalConfig
            generalConfig.Address = tbAddress.Text
            .WorkersCount = nmWorkersCount.Value
        End With
        XmlSerialization.WriteToFile(confFilePath, generalConfig)

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class