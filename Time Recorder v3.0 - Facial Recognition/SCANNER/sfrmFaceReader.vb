Imports OpenCvSharp

Public Class sfrmFaceReader

    Public ReadOnly Property Valid As Boolean
        Get
            Return pixSample1.ImageIpl IsNot Nothing _
                And pixSample2.ImageIpl IsNot Nothing _
                And pixSample3.ImageIpl IsNot Nothing
        End Get
    End Property

    Sub New()
        InitializeComponent()
        FaceRecognizer.StartLiveFeed()
    End Sub

    Sub New(user As UserRecords)
        InitializeComponent()
        With user
            pixSample1.ImageIpl = .FaceImage_1_mat
            pixSample2.ImageIpl = .FaceImage_2_mat
            pixSample3.ImageIpl = .FaceImage_3_mat
        End With
    End Sub

    Private Sub sfrmAddFace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FaceRecognizer.ParentPictureBox = pixDetector
        FaceRecognizer.StartLiveFeed(50)
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If pixDetector.ImageIpl IsNot Nothing Then
            Dim b As Bitmap = FaceRecognizer.detectFace(pixDetector.ImageIpl)
            If b IsNot Nothing Then
                If pixSample1.ImageIpl Is Nothing Then
                    pixSample1.ImageIpl = Extensions.BitmapConverter.ToMat(b)
                ElseIf pixSample2.ImageIpl Is Nothing Then
                    pixSample2.ImageIpl = Extensions.BitmapConverter.ToMat(b)
                ElseIf pixSample3.ImageIpl Is Nothing Then
                    pixSample3.ImageIpl = Extensions.BitmapConverter.ToMat(b)
                Else : Close()
                End If
            Else : MsgBox("No Face Found.")
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        pixSample1.ImageIpl = Nothing
        pixSample2.ImageIpl = Nothing
        pixSample3.ImageIpl = Nothing
    End Sub

End Class