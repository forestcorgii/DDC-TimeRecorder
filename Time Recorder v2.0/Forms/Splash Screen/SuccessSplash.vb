Public NotInheritable Class SuccessSplash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Public Sub New(message As String, Optional duration As Double = 1)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lbMessage.Text = message
        tmDuration.Interval = duration * 1000
    End Sub

    Private Sub SuccessSplash_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmDuration.Enabled = True
        tmDuration.Start()
    End Sub

    Private Sub tmDuration_Tick(sender As Object, e As EventArgs) Handles tmDuration.Tick
        Me.Close()
    End Sub
End Class
