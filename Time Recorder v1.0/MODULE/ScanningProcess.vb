Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Neurotec.Biometrics

Namespace VBNETSample
    Module ScanningProcess
        Private _engine As Nffv
        Private _userDatabaseFile As String
        Private _userDB As VBNETSample.UserDatabase
        Private UserInfo As New List(Of CData)
        Private timeInfo As New EmpTimeTable

#Region "Enroll/Verify Class"
        Friend Class VerificationResult
            Public engineStatus As NffvStatus
            Public score As Integer
        End Class

        Friend Class EnrollmentResult
            Public engineStatus As NffvStatus
            Public engineUser As NffvUser
        End Class
#End Region

#Region "NEW"
        Public Sub getTimeInfo(ByVal df As EmpTimeTable)
            timeInfo = New EmpTimeTable
            timeInfo = df

        End Sub
#End Region


#Region "OPEN USER ID"
        Public Sub openUserDat(ByRef engine As Global.Neurotec.Biometrics.Nffv, ByVal id As String)
            Try
                engine = New Nffv(id & ext.datEx, bioInfo.pass, bioInfo.ScannerName)
            Catch generatedExceptionName As Exception
                MessageBox.Show(Nothing, "Failed to initialize Nffv or create/load database.\r\nPlease check if:\r\n - Provided password is correct;\r\n - Database filename is correct;\r\n", "Nffv C# Sample", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return
            End Try
            NewID(engine, id & ext.xmlEx)
        End Sub

        Public Sub NewID(ByVal engine As Nffv, ByVal userDatabaseFile As String)
            _engine = engine
            _userDatabaseFile = userDatabaseFile
            Try
                _userDB = VBNETSample.UserDatabase.ReadFromFile(userDatabaseFile)
            Catch
                _userDB = New VBNETSample.UserDatabase()
            End Try
        End Sub

        Public Sub useID(ByVal idnum As String)
            If _engine IsNot Nothing Then
                refreshScanner()
            End If

            openUserDat(_engine, idnum)
        End Sub
#End Region

#Region "Enroll"
        Public Function EnrollID(ByVal printName As String) As System.Drawing.Bitmap
            Try
                Dim taskResult As RunWorkerCompletedEventArgs = ScanNew.RunLongTask(Stat.WF, New DoWorkEventHandler(AddressOf doEnroll), Nothing, New EventHandler(AddressOf CancelScanningHandler))
                Dim enrollmentResult As EnrollmentResult = DirectCast(taskResult.Result, EnrollmentResult)
                If enrollmentResult.engineStatus = NffvStatus.TemplateCreated Then
                    Dim engineUser As NffvUser = enrollmentResult.engineUser
                    Dim userName As String = printName
                    If userName.Length <= 0 Then
                        userName = engineUser.Id.ToString()
                    End If
                    _userDB.Add(New UserRecord(engineUser.Id, userName))
                    Try
                        _userDB.WriteToFile(_userDatabaseFile)
                    Catch
                    End Try
                    Return engineUser.GetBitmap()
                Else
                    Dim engineStatus As NffvStatus = enrollmentResult.engineStatus
                    MessageBox.Show(String.Format("Enrollment was not finished. Reason: {0}", engineStatus))
                End If
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try
            Return Nothing
        End Function
        Public Sub doEnroll(ByVal sender As Object, ByVal args As DoWorkEventArgs)
            Dim enrollmentResults As New EnrollmentResult()
            enrollmentResults.engineUser = _engine.Enroll(20000, enrollmentResults.engineStatus)
            args.Result = enrollmentResults
        End Sub
#End Region

#Region "Verify"
        Public Sub doVerify(ByVal sender As Object, ByVal args As DoWorkEventArgs)
            Dim verificationResult As New VerificationResult()
            verificationResult.score = _engine.Verify(DirectCast(args.Argument, NffvUser), 20000, verificationResult.engineStatus)
            args.Result = verificationResult
        End Sub

        Public Function VerifyID(ByVal IDnum As String) As Boolean
            If File.Exists(Application.StartupPath & "\" & IDnum & ext.datEx) = True And IDnum <> "" Then
                useID(IDnum)
                UserInfo = New List(Of CData)
                UserInfo.Add(New CData(_engine.Users(timeInfo.defIdx), IDnum))

                While True
                    Try
                        Dim taskResult As RunWorkerCompletedEventArgs
                        Dim verificationResult As VerificationResult

                        taskResult = Neurotec.Gui.Scan.RunLongTask(New String() {timeInfo.status, timeInfo.printName, timeInfo.comp, timeInfo.department, timeInfo.empNum}, _
                        Stat.WF, New DoWorkEventHandler(AddressOf doVerify), False, DirectCast(UserInfo(0), CData).EngineUser, New EventHandler(AddressOf CancelScanningHandler))

                        verificationResult = DirectCast(taskResult.Result, VerificationResult)
                        If verificationResult.engineStatus = NffvStatus.TemplateCreated Then
                            If verificationResult.score > 0 Then
                                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.SUC, "SUCCESS")
                                refreshScanner()
                                Return True
                            Else
                                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.ER, "FAILED")
                            End If
                        Else
                            setTimer(testBio.Timer1, testBio.lbPromt, 1, String.Format("Verification was not finished. Reason: {0}", verificationResult.engineStatus), "FAILED")
                            Return False
                        End If
                    Catch ex As Exception
                        setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.C, "FAILED")
                        refreshScanner()
                        Return False
                    End Try
                End While
            Else
                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.UI, "FAILED")
                Return False
            End If
        End Function

        Public Function VerifyAdmin(ByVal IDnum As String) As Boolean

            If File.Exists(Application.StartupPath & "\" & IDnum & ext.datEx) = True And IDnum <> "" Then
                useID(IDnum)
                UserInfo = New List(Of CData)
                UserInfo.Add(New CData(_engine.Users(timeInfo.defIdx), IDnum))

                While True
                    Try
                        Dim taskResult As RunWorkerCompletedEventArgs
                        Dim verificationResult As VerificationResult

                        taskResult = ScanNew.RunLongTask("Administrator's Fingerprint is Needed", Stat.WF, New DoWorkEventHandler(AddressOf doVerify), False, DirectCast(UserInfo(0), CData).EngineUser, New EventHandler(AddressOf CancelScanningHandler))

                        verificationResult = DirectCast(taskResult.Result, VerificationResult)
                        If verificationResult.engineStatus = NffvStatus.TemplateCreated Then
                            If verificationResult.score > 0 Then
                                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.SUC, "SUCCESS")
                                refreshScanner()
                                Return True
                            Else
                                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.ER, "FAILED")
                            End If
                        Else
                            setTimer(testBio.Timer1, testBio.lbPromt, 1, String.Format("Verification was not finished. Reason: {0}", verificationResult.engineStatus), "FAILED")
                            Return False
                        End If
                    Catch ex As Exception
                        setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.C, "FAILED")
                        refreshScanner()
                        Return False
                    End Try
                End While
            Else
                setTimer(testBio.Timer1, testBio.lbPromt, 1, Stat.UI, "FAILED")
                Return False
            End If
        End Function
#End Region

#Region "Delete"
        Public Sub deleteUser(ByVal idNum As String)
            If Not File.Exists(Application.StartupPath & "\" & idNum & ext.datEx) Then
                Return
            End If

            useID(idNum)

            _engine.Users.Clear()
            _userDB.Clear()
            Try
                _userDB.WriteToFile(_userDatabaseFile)
            Catch
            End Try
        End Sub

        Public Sub deletePrint(ByVal idNum As String, ByVal idx As Integer)
            _userDB.Remove(_userDB.Lookup(DirectCast(UserInfo(idx), CData).ID))
            Try
                _userDB.WriteToFile(_userDatabaseFile)
            Catch
            End Try

            _engine.Users.RemoveAt(UserInfo(idx).ID)
        End Sub

        Public Function clearPrints() As Boolean
            If MessageBox.Show("All Fingerprints will be cleared. Do you want to continue?", "Confirm Clearing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
                Return False
            End If

            _engine.Users.Clear()
            _userDB.Clear()
            Try
                _userDB.WriteToFile(_userDatabaseFile)
            Catch
            End Try
            Return True
        End Function
#End Region

#Region "Processes"
        Public Sub CancelScanningHandler(ByVal sender As Object, ByVal e As EventArgs)
            _engine.Cancel()
        End Sub

        Public Sub refreshScanner()
            _engine.Dispose()
        End Sub
#End Region

        Public Class CData
            Implements IDisposable
            Private _engineUser As NffvUser
            Private _image As Bitmap
            Private _name As String

            Public Sub New(ByVal engineUser As NffvUser, ByVal name As String)
                _engineUser = engineUser
                _image = engineUser.GetBitmap()
                _name = name
            End Sub

            Public ReadOnly Property EngineUser() As NffvUser
                Get
                    Return _engineUser
                End Get
            End Property

            Public ReadOnly Property Image() As Bitmap
                Get
                    Return _image
                End Get
            End Property

            Public ReadOnly Property ID() As Integer
                Get
                    Return _engineUser.Id
                End Get
            End Property

            Public Property Name() As String
                Get
                    Return _name
                End Get
                Set(ByVal value As String)
                    _name = value
                End Set
            End Property
            Public Overrides Function ToString() As String
                Return Name
            End Function
#Region "IDisposable Members"

            Public Sub Dispose() Implements IDisposable.Dispose
                If _image IsNot Nothing Then
                    _image.Dispose()
                    _image = Nothing
                End If
            End Sub

#End Region
        End Class
    End Module
End Namespace

