Imports Neurotec.Biometrics
Imports System.ComponentModel

Module Scanner
    Public Engine As Nffv
    Public TempUsername As String = "TempUser"
    Public DummyUsername As String = "DummyUser"

#Region "Biometrics Event Handler"
    Public Sub doVerify(ByVal sender As Object, ByVal args As DoWorkEventArgs)
        Dim verificationResult As New VerificationResult()
        verificationResult.score = Engine.Verify(DirectCast(args.Argument, NffvUser), 360000, verificationResult.engineStatus)
        args.Result = verificationResult
    End Sub

    Public Sub doEnroll(ByVal sender As Object, ByVal args As DoWorkEventArgs)
        Dim enrollmentResults As New EnrollmentResult()
        enrollmentResults.engineUser = Engine.Enroll(360000, enrollmentResults.engineStatus)
        args.Result = enrollmentResults
    End Sub
#End Region

#Region "Verify Class"
    Friend Class VerificationResult
        Public engineStatus As NffvStatus
        Public score As Integer
    End Class

    Friend Class EnrollmentResult
        Public engineStatus As NffvStatus
        Public engineUser As NffvUser
    End Class
#End Region

#Region "OPEN USER ID"
    Public Sub openUserDat(ByRef _engine As Global.Neurotec.Biometrics.Nffv, ByVal id As String)
        Try
            _engine = New Nffv(id & ext.datEx, bioInfo.pass, bioInfo.ScannerName)
        Catch generatedExceptionName As Exception
            MessageBox.Show(Nothing, "Failed to initialize Nffv or create/load database.\r\nPlease check if:\r\n - Provided password is correct;\r\n - Database filename is correct;\r\n", "Nffv C# Sample", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
        End Try
    End Sub

    Public Sub useID(ByVal idnum As String)
        If Engine IsNot Nothing Then
            refreshScanner()
        End If

        openUserDat(Engine, idnum)
    End Sub

    Public Sub refreshScanner()
        Engine.Dispose()
    End Sub

    Public Sub CancelScanningHandler()
        Engine.Cancel()
    End Sub
#End Region

End Module
