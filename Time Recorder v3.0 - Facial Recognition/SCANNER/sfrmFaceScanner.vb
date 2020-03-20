Public Class sfrmFaceScanner
  
    Private Sub sfrmAddFace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FaceRecognizer.ParentPictureBox = pixDetector
        pb1.MaxValue = 200

    End Sub

    Private recognizedUser As UserRecords
    Private userTime As UserTimeStatus
    Private mismatchCount As Integer
    Private matchCount As Integer

    Private Property recognizeCount As Integer
        Get
            Return pb1.Value
        End Get
        Set(value As Integer)
            pb1.Value = value
            If value = 0 Then
                pb1.Visible = False
            Else : pb1.Visible = True
            End If
        End Set
    End Property
    Private Sub pixDetector_Invalidated(sender As Object, e As InvalidateEventArgs) Handles pixDetector.Invalidated
        If pixDetector.ImageIpl IsNot Nothing Then
           Dim faceResult As Integer = FaceRecognizer.Recognize(FaceRecognizer.CapturedFace)
            If recognizeCount = 0 Then
                recognizedUser = TimeRecorderUserEngines.Lookup(faceResult)
                userTime = New UserTimeStatus(recognizedUser)
            ElseIf matchCount >= 200 Or matchCount >= 200 Then
                showResult()
                reset()
            ElseIf recognizedUser IsNot Nothing Then
                If recognizedUser.ID = faceResult Then
                    matchCount += 1
                    recognizeCount += 1
                Else : mismatchCount += 1
                End If
            End If
        End If
    End Sub

    Private Sub showResult()
        If matchCount > mismatchCount Then
            frmMain.addToTimetable(userTime)
        End If
    End Sub
    Private Sub reset()
        matchCount = 0
        mismatchCount = 0
        recognizeCount = 0
        recognizedUser = Nothing
    End Sub
End Class