Imports Neurotec.Biometrics.Client
Imports Neurotec.Images
Imports Neurotec.Licensing


Imports Neurotec.Biometrics
Imports Neurotec.Devices

Imports System.Xml.Serialization
Imports SEAN.ConfigurationStoring
Imports System.IO
<XmlRoot("Settings")> _
Public Class SettingsManager
    'Public ReadOnly Property DatabaseFullPath As String
    '    Get
    '        Return Path.Combine(DatabaseDirectory, DatabaseName) & ".db"
    '    End Get
    'End Property
    ' Public DatabaseName As String
    ' Public DatabaseDirectory As String
    Public Face As FaceSetting
    ' Public UserTablename As String
    Sub New()
        Face = New FaceSetting
        '    DatabaseName = ""
        '    DatabaseDirectory = ""
    End Sub

    Public Class FaceSetting
        Public SingleImageRecognition As Boolean
        Public UserReloginTime As Double

        Public MaximalYaw As Single
        Public MaximalRoll As Single
        Public MatchingScoreThreshold As Single
        Public ConfidenceThreshold As Single
        Public QualityThreshold As Single
        Public MatchingSpeed As NMatchingSpeed
        Public TemplateSize As NTemplateSize

        Public UseDeviceManager As Boolean

        Public UseLiveness As Boolean
        Public DetectFacialFeature As Boolean
        Public LivenessThreshold As Single
        Public LivenessBlinkThreshold As Single
        Public LivenessMode As NLivenessMode

        <XmlIgnore> Private _ConfFilename As String
        <XmlIgnore> Public Property ConfFilename As String
            Get
                Return _ConfFilename
            End Get
            Set(value As String)
                _ConfFilename = value
            End Set
        End Property
        Sub New()
        End Sub

        Sub New(_fPath As String)
            ConfFilename = _fPath
        End Sub

        Public Sub ConfigureEngine(ByRef eng As NBiometricClient)
            With eng
                .FacesMaximalRoll = MaximalRoll
                .FacesMaximalYaw = MaximalYaw

                .FacesMatchingSpeed = MatchingSpeed
                .FacesTemplateSize = TemplateSize

                .FacesLivenessMode = LivenessMode
                .FacesLivenessThreshold = LivenessThreshold
                .FacesLivenessBlinkTimeout = LivenessBlinkThreshold

                .FacesQualityThreshold = QualityThreshold
                .FacesConfidenceThreshold = ConfidenceThreshold

                .UseDeviceManager = UseDeviceManager
                .FacesDetectAllFeaturePoints = DetectFacialFeature
            End With
        End Sub


    End Class
End Class
