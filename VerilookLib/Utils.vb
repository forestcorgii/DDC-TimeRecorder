Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms

Public NotInheritable Class Utils
    Private Sub New()
    End Sub
    Public Shared Function GetTrialModeFlag() As Boolean
        Dim filePath = New DirectoryInfo(Application.StartupPath).Parent.FullName & "/Licenses/TrialFlag.txt"
        If File.Exists(filePath) Then
            Dim lines = File.ReadAllLines(filePath)
            If lines.Length > 0 AndAlso lines(0).Trim().ToLower().Equals("true") Then
                Return True
            End If
        Else
            Console.WriteLine("Failed to locate file: " + Path.GetFullPath(filePath))
        End If
        Return False
    End Function

    Public Shared Function GetLicenses() As String()
        Try
            Dim licFiles As String() = Directory.GetFiles(New DirectoryInfo(Application.StartupPath).Parent.FullName & "/Licenses", "*.lic")
            Dim licCons As New List(Of String)
            For Each licFile In licFiles
                licCons.Add(File.ReadAllText(licFile))
            Next
            Return licCons.ToArray
        Catch ex As Exception
            ShowException(ex)
        End Try
        Return Nothing
    End Function

    Public Shared Function QualityToPercent(ByVal value As Byte) As Integer
        Return (2 * value * 100 + 255) \ (2 * 255)
    End Function

    Public Shared Function QualityFromPercent(ByVal value As Integer) As Byte
        Return CByte((2 * value * 255 + 100) / (2 * 100))
    End Function

    Public Shared Function MatchingThresholdToString(ByVal value As Integer) As String
        Dim p As Double = -value / 12.0
        Return String.Format(String.Format("{{0:P{0}}}", Math.Max(0, CInt(Fix(Math.Ceiling(-p))) - 2)), Math.Pow(10, p))
    End Function

    Public Shared Function MatchingThresholdFromString(ByVal value As String) As Integer
        Dim p As Double = Math.Log10(Math.Max(Double.Epsilon, Math.Min(1, Double.Parse(value.Replace(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "")) / 100)))
        Return Math.Max(0, CInt(Fix(Math.Round(-12 * p))))
    End Function

    Public Shared Function MaximalRotationToDegrees(ByVal value As Byte) As Integer
        Return (2 * value * 360 + 256) \ (2 * 256)
    End Function

    Public Shared Function MaximalRotationFromDegrees(ByVal value As Integer) As Byte
        Return CByte((2 * value * 256 + 360) / (2 * 360))
    End Function

    Public Shared Function GetUserLocalDataDir(ByVal productName As String) As String
        Dim localDataDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
        localDataDir = Path.Combine(localDataDir, "Neurotechnology")
        If (Not Directory.Exists(localDataDir)) Then
            Directory.CreateDirectory(localDataDir)
        End If
        localDataDir = Path.Combine(localDataDir, productName)
        If (Not Directory.Exists(localDataDir)) Then
            Directory.CreateDirectory(localDataDir)
        End If

        Return localDataDir
    End Function

    Public Shared Sub ShowException(ByVal ex As Exception)
        'Do While (TypeOf ex Is AggregateException) AndAlso (ex.InnerException IsNot Nothing)
        '    ex = ex.InnerException
        'Loop

        MessageBox.Show(ex.ToString(), Nothing, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
End Class
