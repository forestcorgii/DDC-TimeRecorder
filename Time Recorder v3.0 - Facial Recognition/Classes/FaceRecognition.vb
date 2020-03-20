Imports OpenCvSharp
Imports System.IO
Imports SEAN
Imports SEAN.ConfigurationStoring
Imports MySql

Public Class FaceRecognition
    Public Cascade As CascadeClassifier
    Public faceRecognizer As Face.FaceRecognizer
    Public CapturedFace As Bitmap
    Public cap As VideoCapture
    Public minFaceSize As Size
    Public ParentPictureBox As UserInterface.PictureBoxIpl
    Private WithEvents tmLiveFeed As New Timer

    Sub New(_userDatabase As UserDatabase, Optional pb As UserInterface.PictureBoxIpl = Nothing)
        cap = New VideoCapture(CaptureDevice.Any)
        cap.Open(CaptureDevice.Any)
        tmLiveFeed.Enabled = False
        ParentPictureBox = pb
        minFaceSize = New Size(10, 10)
        trainRecognizer(_userDatabase)
        Cascade = New CascadeClassifier("C:\Emgu\emgucv-windesktop 3.4.3.3016\opencv\data\haarcascades\haarcascade_frontalface_default.xml")
    End Sub

    Public Sub StartLiveFeed(Optional interval As Integer = 1000)
        tmLiveFeed.Interval = interval
        tmLiveFeed.Enabled = True
    End Sub

    Public Sub EndLiveFeed()
        tmLiveFeed.Enabled = False
    End Sub

    Private Sub tmLiveFeed_Tick(sender As Object, e As EventArgs) Handles tmLiveFeed.Tick
        Dim im As New Mat
        cap.Read(im)
        detectFace(im)
    End Sub

    Public Function detectFace(_image As mat, Optional toRecognize As Boolean = True) As Bitmap
        Dim nextFrame As mat = _image
        Dim faceRects As OpenCvSharp.Rect() = Cascade.DetectMultiScale(_image, 1.1, 10, HaarDetectionType.FindBiggestObject, minFaceSize)
        Dim capturedFaces As New List(Of Bitmap)
        Dim _capturedFace As Bitmap
        Dim i As Integer = 0
        If faceRects.Length > 0 Then
            ' For i As Integer = 0 To faceRects.Length - 1
            _capturedFace = New Bitmap(1000, 1000)
            Using g As Graphics = Graphics.FromImage(_capturedFace)
                g.DrawImage(New Bitmap(_image.ToMemoryStream), New Rectangle(0, 0, 1000, 1000), _
                            New Rectangle(faceRects(i).X, faceRects(i).Y, faceRects(i).Width, faceRects(i).Height), GraphicsUnit.Pixel)
            End Using

            If faceRecognizer IsNot Nothing And toRecognize Then
                Dim result As Integer = Recognize(_capturedFace)
                If result = 0 Then
                    nextFrame.PutText("unknown", faceRects(i).Location, HersheyFonts.HersheyComplexSmall, 2, Scalar.DarkGreen)
                Else : nextFrame.PutText(result, faceRects(i).Location, HersheyFonts.HersheyComplexSmall, 2, Scalar.DarkGreen)
                End If
            End If
            CapturedFace = _capturedFace
            nextFrame.Rectangle(faceRects(i), Scalar.Red)
            capturedFaces.Add(_capturedFace)
            '  Next
        End If
        ParentPictureBox.ImageIpl = _image
        Return (From res As Bitmap In capturedFaces Order By res.Width Select res Take 1).FirstOrDefault
    End Function

    Public Function Recognize(face As Bitmap) As Integer
        Dim result As Integer = 0
        If faceRecognizer IsNot Nothing And face IsNot Nothing Then
            Dim fmat As Mat = Extensions.BitmapConverter.ToMat(face)
            fmat = Cv2.ImDecode(fmat.ToBytes, ImreadModes.GrayScale)
            fmat.Resize(1000)
            result = faceRecognizer.Predict(fmat)
        End If
        Return result
    End Function
    Private Sub trainRecognizer(userEngines As UserDatabase)
        Dim idx As Integer = 0
        Dim faceImages As New List(Of Mat)
        Dim faceIDs As New List(Of Integer)
        Dim stream As New MemoryStream()
        Dim fmat As Mat

        For i As Integer = 0 To userEngines.Count - 1
            If userEngines(i).FaceImage_1 IsNot Nothing Then
                stream = New MemoryStream()
                stream.Write(userEngines(i).FaceImage_1_mat.ToBytes, 0, userEngines(i).FaceImage_1_mat.ToBytes.Length)
                fmat = userEngines(i).FaceImage_1_mat.Clone : fmat.Resize(1000)
                faceImages.Add(fmat) : faceIDs.Add(userEngines(i).ID)

                stream = New MemoryStream()
                stream.Write(userEngines(i).FaceImage_2_mat.ToBytes, 0, userEngines(i).FaceImage_2_mat.ToBytes.Length)
                fmat = userEngines(i).FaceImage_2_mat.Clone : fmat.Resize(1000)
                faceImages.Add(fmat) : faceIDs.Add(userEngines(i).ID)

                stream = New MemoryStream()
                stream.Write(userEngines(i).FaceImage_3_mat.ToBytes, 0, userEngines(i).FaceImage_3_mat.ToBytes.Length)
                fmat = userEngines(i).FaceImage_3_mat.Clone : fmat.Resize(1000)
                faceImages.Add(fmat) : faceIDs.Add(userEngines(i).ID)
            End If
        Next

        If faceImages.Count > 1 Then
            faceRecognizer = Face.LBPHFaceRecognizer.Create
            faceRecognizer.Train(faceImages, faceIDs)
        End If
    End Sub
End Class
