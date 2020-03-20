Imports Neurotec.Biometrics
Imports Neurotec.Biometrics.Client
Imports SEAN.ConfigurationStoring
Public Class dlgSettings
    Public Settings As SettingsManager
    Private confFilePath As String
  
    Sub New(Optional _confFilePath As String = "")
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Settings = New SettingsManager
        confFilePath = _confFilePath
        loadItems()
        If IO.File.Exists(confFilePath) Then
            Settings = XmlSerialization.ReadFromFile(_confFilePath, Settings)
            With Settings.Face
                nmMaximalYaw.Value = .MaximalYaw
                nmMaximalRoll.Value = .MaximalRoll

                nmConfidenceThreshold.Value = .ConfidenceThreshold
                nmQualityThreshold.Value = .QualityThreshold
                nmMatchingScoreThreshold.Value = .MatchingScoreThreshold

                cbLivenessMode.Text = .LivenessMode.ToString
                nmLivenessThreshold.Value = .LivenessThreshold
                nmLivenessBlinkThreshold.Value = .LivenessBlinkThreshold

                nmUserReloginTime.Value = .UserReloginTime

                cbTemplateSize.Text = .TemplateSize.ToString
                cbMatchingSpeed.Text = .MatchingSpeed.ToString

                chbUseDeviceManager.Checked = .UseDeviceManager
                chbUseLiveness.Checked = .UseLiveness
                chbDetectFacialFeature.Checked = .DetectFacialFeature
                chbSingleImageRecongition.Checked = .SingleImageRecognition
            End With
        
        End If
    End Sub

    Private Sub dlgSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
    
    End Sub
    Private Sub loadItems()
        cbTemplateSize.Items.AddRange({NTemplateSize.Compact.ToString, NTemplateSize.Small.ToString, _
                               NTemplateSize.Medium.ToString, NTemplateSize.Large.ToString})
        cbMatchingSpeed.Items.AddRange({NMatchingSpeed.Low.ToString, NMatchingSpeed.Medium.ToString, NMatchingSpeed.High.ToString})
        cbLivenessMode.Items.AddRange({NLivenessMode.Active.ToString, NLivenessMode.Passive.ToString, _
                                       NLivenessMode.PassiveAndActive.ToString, NLivenessMode.Simple.ToString, _
                                       NLivenessMode.Custom.ToString, NLivenessMode.None.ToString})
        cbTemplateSize.SelectedIndex = 0
        cbMatchingSpeed.SelectedIndex = 0
        cbLivenessMode.SelectedIndex = 0
    End Sub
    Public ReadOnly Property MatchingSpeed As NMatchingSpeed
        Get
            Select Case cbMatchingSpeed.Text
                Case NMatchingSpeed.High.ToString
                    Return NMatchingSpeed.High
                Case NMatchingSpeed.Medium.ToString
                    Return NMatchingSpeed.Medium
                Case Else
                    Return NMatchingSpeed.Low
            End Select
        End Get
    End Property
    Public ReadOnly Property TemplateSize As NTemplateSize
        Get
            Select Case cbTemplateSize.Text
                Case NTemplateSize.Small.ToString
                    Return NTemplateSize.Small
                Case NTemplateSize.Medium.ToString
                    Return NTemplateSize.Medium
                Case NTemplateSize.Large.ToString
                    Return NTemplateSize.Large
                Case Else
                    Return NTemplateSize.Compact
            End Select
        End Get
    End Property
    Private ReadOnly Property LivenessMode As NLivenessMode
        Get
            Select Case cbLivenessMode.Text
                Case NLivenessMode.Active.ToString
                    Return NLivenessMode.Active
                Case NLivenessMode.Passive.ToString
                    Return NLivenessMode.Passive
                Case NLivenessMode.PassiveAndActive.ToString
                    Return NLivenessMode.PassiveAndActive
                Case NLivenessMode.Simple.ToString
                    Return NLivenessMode.Simple
                Case Else
                    Return NLivenessMode.None
            End Select
        End Get
    End Property

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With Settings.Face
            .MaximalYaw = nmMaximalYaw.Value
            .MaximalRoll = nmMaximalRoll.Value

            .ConfidenceThreshold = nmConfidenceThreshold.Value
            .QualityThreshold = nmQualityThreshold.Value
            .MatchingScoreThreshold = nmMatchingScoreThreshold.Value

            .LivenessMode = LivenessMode
            .LivenessThreshold = nmLivenessThreshold.Value
            .LivenessBlinkThreshold = nmLivenessBlinkThreshold.Value

            .UserReloginTime = nmUserReloginTime.Value

            .TemplateSize = TemplateSize
            .MatchingSpeed = MatchingSpeed

            .UseDeviceManager = chbUseDeviceManager.Checked
            .UseLiveness = chbUseLiveness.Checked
            .DetectFacialFeature = chbDetectFacialFeature.Checked
            .SingleImageRecognition = chbSingleImageRecongition.Checked
        End With
     
        Me.Close()
    End Sub

    'Private Sub btnSelectDBFilename_Click(sender As Object, e As EventArgs)
    '    OFD.Filter = "DB Files| *.db"
    '    If OFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        tbDBFilename.Text = SEAN.General.ConvertToUNCPath(OFD.FileName)
    '    End If
    'End Sub

 
End Class