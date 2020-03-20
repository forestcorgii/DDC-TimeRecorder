Imports System.IO
Imports System.Data.OleDb

Namespace AddingUser
    Public Class frmAddUser
        Public NewUserDB As New UserRecords
        Private _fingerprintRegistered As Boolean = False
        Private Property fingerprintRegistered As Boolean
            Get
                Return _fingerprintRegistered
            End Get
            Set(value As Boolean)
                _fingerprintRegistered = value
                If value Then
                    lbFingerprintStatus.ForeColor = Color.MidnightBlue
                    lbFingerprintStatus.Text = "Your Fingerprint has been registered."
                Else
                    lbFingerprintStatus.ForeColor = Color.Maroon
                    lbFingerprintStatus.Text = "Your Fingerprint is not yet registered."
                End If
            End Set
        End Property

        Private _faceprintRegistered As Boolean = False
        Private Property faceRegistered As Boolean
            Get
                Return _faceprintRegistered
            End Get
            Set(value As Boolean)
                _faceprintRegistered = value
                If value Then
                    lbFaceStatus.ForeColor = Color.MidnightBlue
                    lbFaceStatus.Text = "Your Face has been registered."
                Else
                    lbFaceStatus.ForeColor = Color.Maroon
                    lbFaceStatus.Text = "Your Face is not yet registered."
                End If
            End Set
        End Property

        Private Function validInfo() As Boolean
            If (Not tbID.Text.Equals("")) And (cbCompBranch.Equals("") Or cbDept.Equals("") _
            Or tbMname.Equals("") Or tbLname.Text.Equals("") Or tbFname.Text.Equals("") Or tbEmpNum.Text.Equals("")) Then
                If MsgBox("All Fields are important and should not be blank, do You want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return True
                Else : Return False
                End If
            ElseIf tbID.Text.Equals("") Then
                MsgBox("Your ID is Blank.")
                tbID.Select()
                Return False
            ElseIf Not fingerprintRegistered Then
                If MsgBox("You haven't registered your fingerprint yet, do You want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    btnRegisterFingerprint.Select()
                    Return True
                Else : Return False
                End If
            Else
                Return True
            End If
        End Function

        Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles Me.Load
            cbCompBranch.Focus()
            cbCompBranch.SelectedIndex = 0
            cbDept.SelectedIndex = 0
            cbSched.SelectedIndex = 0
        End Sub

        Private Sub btnRegisterFingerprint_Click(sender As Object, e As EventArgs) Handles btnRegisterFingerprint.Click
            If fingerprintRegistered Then
                If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    File.Delete(Path.Combine(Application.StartupPath, TempUsername & ext.datEx))
                Else
                    Exit Sub
                End If
            End If

            Dim frmPrint As New sfrmPrintReader
            frmPrint.ShowDialog()
            If File.Exists(Path.Combine(Application.StartupPath, TempUsername & ext.datEx)) Then
                NewUserDB = frmPrint.UserDB
                fingerprintRegistered = True
            End If
        End Sub

        Private Sub btnRegisterFace_Click(sender As Object, e As EventArgs) Handles btnRegisterFace.Click
            If faceRegistered Then
                If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ' File.Delete(Path.Combine(Application.StartupPath, TempUsername & ext.datEx))
                Else : Exit Sub
                End If
            End If

            Using frmScan As New sfrmFaceReader(NewUserDB)
                frmScan.ShowDialog()
                If frmScan.Valid Then
                    faceRegistered = True
                    NewUserDB.FaceImage_1 = frmScan.pixSample1.ImageIpl.ToBytes
                    NewUserDB.FaceImage_2 = frmScan.pixSample2.ImageIpl.ToBytes
                    NewUserDB.FaceImage_3 = frmScan.pixSample3.ImageIpl.ToBytes
                End If
            End Using
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If validInfo() Then
                '//SAVE
                With NewUserDB
                    .ID = tbID.Text
                    .EmployeeNumber = tbEmpNum.Text
                    .Department = cbDept.Text
                    .Company = cbCompBranch.Text
                    .Schedule = cbSched.Text
                    .FirstName = tbFname.Text
                    .LastName = tbLname.Text
                    .MiddleName = tbMname.Text
                    .Admin = cbAdmin.Checked
                    .Available = fingerprintRegistered
                    .WriteToFile(.ID & ext.xmlEx)
                    If fingerprintRegistered Then FileSystem.Rename(Path.Combine(Application.StartupPath, TempUsername & ext.datEx), Path.Combine(Application.StartupPath, .ID & ext.datEx))
                    TMconn.CreateTable(.ID, TMFieldTypes)
                End With

                MsgBox("Registration Complete.")
                Me.Close()
            End If
        End Sub
    End Class
End Namespace