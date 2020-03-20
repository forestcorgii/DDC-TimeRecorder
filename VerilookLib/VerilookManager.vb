Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Neurotec.Biometrics.Client
Imports Neurotec.Images
Imports Neurotec.Licensing


Imports Neurotec.Biometrics
Imports Neurotec.Devices
Imports System.IO
Imports System.Xml.Serialization
Imports SEAN.ConfigurationStoring
Imports SEAN
Imports System.Runtime.CompilerServices

Public Class VerilookManager
    Public Event FaceIdentified(sender As Object, e As VerilookEventArgs)

#Region "Saved Fields"
    Public Settings As SettingsManager
#End Region

#Region "Ignored Fields"
    Public UserRecords As Object
    Public ConfFilename As String
    Public OpeningCamera As Boolean

    Public WithEvents SubjectWorker As Workers
    Private ParentForm As Form

    Private _biometricClient As NBiometricClient
    Private _biometricClient2 As NBiometricClient
    Private _biometricClient3 As NBiometricClient
    Private _isSegmentationActivated? As Boolean

    Private CameraSubject1 As NSubject
    Private CameraSubject2 As NSubject
    Private faceSubjects As List(Of NSubject)

    Private _deviceManager As NDeviceManager

    Public SQLiteDatabaseManager As SEAN.DatabaseManagement.SQLiteConfiguration
    Public MySQLDatabaseManager As SEAN.DatabaseManagement.MysqlConfiguration

    Public ProcessType As FaceProcessType

    Private EnrollmentTask As NBiometricTask

#End Region
    Public Function ToInt() As String
        Return 0
    End Function


    Sub New(Optional _ConfFilename As String = "", Optional noStream As Boolean = False, Optional useTrial As Boolean = False)
        If noStream = False Then licenseSetup(useTrial)
        Dim binPath As String = New DirectoryInfo(Application.StartupPath).Parent.FullName
        Settings = New SettingsManager
        TrySetupWorkers()

        ConfFilename = _ConfFilename & "\Conf\VerilookConf.xml"
        Dim reconfigure As Boolean = True
        Try
            While reconfigure = True
                If File.Exists(ConfFilename) Then
                    Settings = XmlSerialization.ReadFromFile(ConfFilename, Settings)
                    reconfigure = False
                Else : reconfigure = True
                    Directory.CreateDirectory(Path.GetDirectoryName(ConfFilename))
                End If

                If reconfigure Then SetBiometricClientParams()
            End While

            _biometricClient = New NBiometricClient With {.BiometricTypes = NBiometricType.Face}
            Settings.Face.ConfigureEngine(_biometricClient)

            _biometricClient2 = New NBiometricClient() With {.BiometricTypes = NBiometricType.Face, .UseDeviceManager = False, .FacesMatchingSpeed = NMatchingSpeed.High}

            _biometricClient3 = New NBiometricClient With {.BiometricTypes = NBiometricType.Face}
            Settings.Face.ConfigureEngine(_biometricClient3)

            _deviceManager = _biometricClient.DeviceManager

            If noStream = False Then
                If (Not _isSegmentationActivated.HasValue) Then
                    _isSegmentationActivated = NLicense.IsComponentActivated("Biometrics.FaceSegmentsDetection")
                End If
            End If
            '  GetTemplate() '(databasemanager, UserRecords)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
    End Sub

#Region "Methods for Setups"
    Public CameraList As List(Of NDevice)

    Private Sub licenseSetup(Optional useTrial As Boolean = False)
        '     If Not My.Computer.Name = "IDCFC-0192" And useTrial = False Then
        For Each lic As String In Utils.GetLicenses
            NLicense.Add(lic)
        Next
        '   Else : NLicenseManager.TrialMode = useTrial
        '   End If

        Const Components As String = "Biometrics.FaceExtraction,Biometrics.FaceMatching,Biometrics.FaceDetection,Devices.Cameras,Biometrics.FaceSegmentsDetection"
        For Each component As String In Components.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
            If NLicense.ObtainComponents("/local", "5000", component) = False Then
                MessageBox.Show(component & " Component License is not activated", Nothing, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '  Throw New Exception("Component License is not activated")
            End If
        Next
    End Sub

    Public ReadOnly Property Runnable As Boolean
        Get
            Return UserRecords IsNot Nothing And (MySQLDatabaseManager IsNot Nothing) 'Or SQLiteDatabaseManager IsNot Nothing)
        End Get
    End Property

    Public Sub GetTemplate(Optional templateCount As Integer = 1)
        If Runnable Then
            ' Create subjects from selected templates
            faceSubjects = New List(Of NSubject)
            Dim addedUser As New List(Of String)
            For i As Integer = 0 To UserRecords.Count - 1
                With UserRecords(i)
                    If Not addedUser.Contains(.EmployeeID) Then
                        addedUser.Add(.EmployeeID)
                        If .Active AndAlso .FaceImage_1 IsNot Nothing Then
                            .FaceImage_1.Id = .EmployeeID & "_1"
                            faceSubjects.Add(.FaceImage_1)
                            If templateCount >= 2 Then
                                .FaceImage_2.Id = .EmployeeID & "_2"
                                faceSubjects.Add(.FaceImage_2)
                            End If
                            If templateCount >= 3 Then
                                .FaceImage_3.Id = .EmployeeID & "_3"
                                faceSubjects.Add(.FaceImage_3)
                            End If
                            If templateCount >= 4 Then
                                .FaceImage_4.Id = .EmployeeID & "_4"
                                faceSubjects.Add(.FaceImage_4)
                            End If
                        End If
                    End If
                End With
            Next i

            EnrollmentTask = New NBiometricTask(NBiometricOperations.Enroll)
            For Each t As NSubject In faceSubjects
                EnrollmentTask.Subjects.Add(t)
            Next t
        Else : MsgBox("Can't run Verilook Manager.")
        End If
    End Sub

    Public Sub editFaceTemplate(ByRef newUser As UserRecord)
        Using freg As New dlgFaceRegistration With {.FaceManager = Me, .User = newUser}
            freg.ShowDialog()
            With newUser
                If freg.fs1 IsNot Nothing Then
                    .FaceImage_1 = freg.fs1
                    .FaceImage_2 = freg.fs2
                    .FaceImage_3 = freg.fs3
                End If
            End With
        End Using
    End Sub

    Private Sub setCamera(ByRef _subject As NSubject, fv As Gui.NFaceView, Optional captureOptions As NBiometricCaptureOptions = NBiometricCaptureOptions.Manual)
        ' Set face capture from stream
        OpeningCamera = True
        Dim face As New NFace() With {.CaptureOptions = captureOptions}
        _subject = New NSubject()
        _subject.Faces.Add(face)
        fv.Face = face
    End Sub

    Public Sub SetBiometricClientParams()
        Using conf As New dlgSettings(ConfFilename)
            conf.ShowDialog()
            Settings = conf.Settings
        End Using
        XmlSerialization.WriteToFile(ConfFilename, Settings)
    End Sub

    Public Sub GetCameraList()
        CameraList = New List(Of NDevice)
        For Each device As NDevice In _deviceManager.Devices
            CameraList.Add(device)
        Next
    End Sub

#End Region

#Region "Methods for Recognition"
    Public Async Function StartProcess(_parentform As Form, fv As Gui.NFaceView, _processType As FaceProcessType, Optional useSecond As Boolean = False) As System.Threading.Tasks.Task ', Optional firstCapture As Boolean = False) As System.Threading.Tasks.Task
        ProcessType = _processType
        ParentForm = _parentform
        TrySetupWorkers(_parentform)

        If useSecond AndAlso CameraList.Count > 1 Then
            setupTimer2(True)
            Settings.Face.ConfigureEngine(_biometricClient3)
            _biometricClient3.FaceCaptureDevice = CameraList(1)
            setCamera(CameraSubject2, fv)
            Await _biometricClient3.CaptureAsync(CameraSubject2)
        Else
            setupTimer1(True)
            Settings.Face.ConfigureEngine(_biometricClient)
            setCamera(CameraSubject1, fv) ', NBiometricCaptureOptions.Stream)
            Await _biometricClient.CaptureAsync(CameraSubject1)   '  CaptureAsync() 'Await _biometricClient.CaptureAsync(CameraSubject1)
        End If
    End Function

    Public Async Sub StopProcess() 'As Task(Of Boolean)
        If Camera1InUse Then
            setupTimer1(False)
            Await _biometricClient.ClearAsync()
            CameraSubject1.Faces(0).Image = Nothing
        End If

        If Camera2InUse Then
            setupTimer2(False)
            Await _biometricClient3.ClearAsync()
            CameraSubject2.Faces(0).Image = Nothing
        End If
    End Sub

    Public Sub ForceCapture()
        _biometricClient.ForceStart()
        If Camera2InUse Then _biometricClient3.ForceStart()
    End Sub

    Public Async Function CaptureAsync(fv As Gui.NFaceView, Optional captureOptions As NBiometricCaptureOptions = NBiometricCaptureOptions.Manual) As Task(Of Object())
        Dim s As New NSubject
        setCamera(s, fv, captureOptions)
        Dim status = Await _biometricClient.CaptureAsync(s)
        Return {s, status}
    End Function

    Public Async Sub CaptureAsync()
        While True
            Await _biometricClient.CaptureAsync(CameraSubject1)
            Dim i As NImage = CameraSubject1.Faces(0).Image
            Await DetectFacesAsync(i, ProcessType)
        End While
    End Sub

    Public Async Function DetectFacesAsync(ByVal image As NImage, _processType As FaceProcessType) As Task(Of NFace()) 'System.Threading.Tasks.Task
        If image IsNot Nothing Then
            OpeningCamera = False
            Try
                Dim faces As New List(Of NFace)
                Dim face = Await _biometricClient.DetectFacesAsync(image)
                For i As Integer = 0 To face.Objects.Count - 1
                    Dim nla As New NLAttributes With {.BoundingRect = face.Objects(i).BoundingRect}
                    Dim f = NFace.FromImageAndAttributes(face.Image, nla)
                    faces.Add(f)
                Next
                If faces.Count > 0 Then
                    If _processType = FaceProcessType.Identify Then
                        IdentifyFaces(faces.ToArray, image)
                    Else : Return faces.ToArray
                    End If
                End If
            Catch ex As Exception
                Utils.ShowException(ex)
            End Try
        End If
        Return Nothing
    End Function

    Private Sub IdentifyFaces(faces As NFace(), image As NImage)
        For i As Integer = 0 To faces.Length - 1
            SubjectWorker.AddtoQueue({faces(i), faces.Length})
        Next
    End Sub

#End Region

#Region "Workers Methods"
    Public Sub TrySetupWorkers(Optional _parentForm As Form = Nothing, Optional workerCount As Integer = 1)
        Try
            SubjectWorker = New SEAN.Workers(_parentForm)
            SubjectWorker.SetWorker(workerCount)
        Catch ex As Exception

        End Try
    End Sub

    Private Async Sub subjectWorker_Worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles SubjectWorker.Worker_DoWork
        Try
            Dim s As New NSubject, msg As String = ""
            Dim id As String = "", score As String = "", st As NBiometricStatus

            s.Faces.Add(e.Argument(0))
            If s IsNot Nothing AndAlso faceSubjects IsNot Nothing AndAlso faceSubjects.Count > 0 Then
                Await _biometricClient2.ClearAsync()

                Dim taskAsync = Await _biometricClient2.PerformTaskAsync(EnrollmentTask)
                If taskAsync.Status = NBiometricStatus.Ok Then
                    Dim identifyTask = Await _biometricClient2.IdentifyAsync(s)
                    If identifyTask = NBiometricStatus.Ok OrElse identifyTask = NBiometricStatus.MatchNotFound Then
                        Dim m = (From res In s.MatchingResults Where res.Score >= Settings.Face.MatchingScoreThreshold Order By res.Score Descending Take 1 Select {res.Id, res.Score}).FirstOrDefault
                        If m IsNot Nothing Then
                            id = m(0) : score = m(1)
                            msg = String.Format("ID: {0}, Score: {1}", id, score)
                        Else : msg = String.Format("Identification failed: {0}", identifyTask)
                            Exit Sub
                        End If
                    Else : msg = String.Format("Identification failed: {0}", identifyTask)
                        Exit Sub
                    End If
                    st = identifyTask
                Else : st = taskAsync.Status
                    msg = String.Format("Enrollment failed: {0}", taskAsync.Status)
                    Exit Sub
                End If
            End If

            Dim args As New VerilookEventArgs
            With args
                .Subject = s
                .UserID = id
                .Score = score
                .Message = msg
                .Status = st
                .ElapseTime = (Now - stTime)
                .Faces = e.Argument(1)
            End With
            RaiseEvent FaceIdentified(Me, args)
        Catch ex As Exception
            Utils.ShowException(ex)
        End Try
        '     ParentForm.Invoke(Sub() tmDetectCam1.Enabled = True)
    End Sub

#End Region

#Region "Detection Timer"
    Private stTime As Date
    Private WithEvents tmDetectCam1 As New Timer
    Private WithEvents tmDetectCam2 As New Timer

    Public Camera1InUse As Boolean
    Public Camera2InUse As Boolean

    Private Async Sub tmDetectCam1_Tick(sender As Object, e As EventArgs) Handles tmDetectCam1.Tick
        tmDetectCam1.Enabled = False
        stTime = Now
        Dim i As NImage = CameraSubject1.Faces(0).Image
        Await DetectFacesAsync(i, ProcessType)
        tmDetectCam1.Enabled = True
    End Sub

    Private Async Sub tmDetectCam2_Tick(sender As Object, e As EventArgs) Handles tmDetectCam2.Tick
        tmDetectCam2.Enabled = False
        stTime = Now
        Dim i As NImage = CameraSubject2.Faces(0).Image
        Await DetectFacesAsync(i, ProcessType)
        tmDetectCam2.Enabled = True
    End Sub

    Private Sub setupTimer1(enable As Boolean)
        If enable Then
            tmDetectCam1 = New Timer
            tmDetectCam1.Interval = 1000
        End If
        tmDetectCam1.Enabled = enable
        Camera1InUse = enable
    End Sub
    Private Sub setupTimer2(enable As Boolean)
        If enable Then
            tmDetectCam2 = New Timer
            tmDetectCam2.Interval = 1000
        End If
        tmDetectCam2.Enabled = enable
        Camera2InUse = enable
    End Sub
#End Region
End Class



Public Class VerilookEventArgs
    Inherits EventArgs

    Public UserID As String
    Public Subject As NSubject

    Public Status As NBiometricStatus = NBiometricStatus.None
    Public Score As String
    Public Message As String

    Public ElapseTime As TimeSpan

    Public Faces As Integer
End Class

Public Enum FaceProcessType
    Detect
    Identify
End Enum

