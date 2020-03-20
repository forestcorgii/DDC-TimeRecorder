
Public Class TimeSheetExporter

#Region "PUBLIC PROPERTIES"
    Public ReadOnly Property DateA() As Date
        Get
            Return DTP1.Value
        End Get
    End Property

    Public ReadOnly Property DateB() As Date
        Get
            Return DTP2.Value

        End Get
    End Property
#End Region

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If DateA <> DateB Then
            produceTimesheet(DateA, DateB)
            Me.Close()
        Else
            MsgBox("Date ranges should be more than 1 day apart.")
        End If
    End Sub
End Class