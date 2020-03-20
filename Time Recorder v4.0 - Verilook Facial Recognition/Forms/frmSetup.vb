Imports System.IO
Imports VerilookLib

Namespace AddingUser
    Public Class frmSetup
        Public NewUserDB As UserRecord
        Private _faceRegistered As Boolean = False
        Public FaceManager As VerilookManager

        Private Function checkFaceAvailable(_user As UserRecord) As Boolean
            Dim value As Boolean = Not (_user.FaceImage_1 Is Nothing Or _user.FaceImage_2 Is Nothing Or _user.FaceImage_3 Is Nothing)
            If value Then
                lbRegStatus.ForeColor = Color.MidnightBlue
                lbRegStatus.Text = "Your Face has been registered."
            Else
                lbRegStatus.ForeColor = Color.Maroon
                lbRegStatus.Text = "Your Face is not yet registered."
            End If
            Return value
        End Function

        Private Function validInfo() As Boolean
            If (Not tbEmpNum.Text.Equals("")) And (tbCompany.Text.Equals("") Or tbCompAcro.Text.Equals("") Or cbCompBranch.Equals("") Or cbDept.Equals("") _
            Or tbMname.Equals("") Or tbLname.Text.Equals("") Or tbFname.Text.Equals("")) Then
                If MsgBox("All Fields are important and should not be blank, do You want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return True
                Else : Return False
                End If
            ElseIf tbEmpNum.Text.Equals("") Then
                MsgBox("Your ID is Blank.")
                tbEmpNum.Select()
                Return False
            ElseIf Not checkFaceAvailable(NewUserDB) Then
                MsgBox("You haven't registered your face yet.")
                btnRegPrint.Select()
                Return False
            Else
                Return True
            End If
        End Function

        Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles Me.Load
            tbCompany.Focus()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If validInfo() Then
                '//SAVE
                With NewUserDB
                    .EmployeeID = tbEmpNum.Text
                    .Department = cbDept.Text
                    .Project = cbProject.Text
                    .Company = cbCompBranch.Text
                    .FirstName = tbFname.Text
                    .LastName = tbLname.Text
                    .MiddleName = tbMname.Text
                    .Schedule = cbSched.Text
                    .Admin = True
                    .Active = True

                    .saveToDB(FaceManager.MySQLDatabaseManager, Programs.UserTablename)
                End With

                My.Settings.Acronym = tbCompAcro.Text
                My.Settings.Company = tbCompany.Text
                My.Settings.Save()

                MsgBox("Setup is Complete.")
                Me.Close()
            End If
        End Sub

        Private Sub btnRegPrint_Click(sender As Object, e As EventArgs) Handles btnRegPrint.Click
            FaceManager.editFaceTemplate(NewUserDB)
            checkFaceAvailable(NewUserDB)
        End Sub
    End Class
End Namespace
