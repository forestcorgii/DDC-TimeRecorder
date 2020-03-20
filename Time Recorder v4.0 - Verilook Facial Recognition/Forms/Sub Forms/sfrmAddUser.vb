Imports System.IO
Imports System.Data.OleDb
Imports VerilookLib

Namespace AddingUser
    Public Class frmAddUser
        Public NewUserDB As UserCollection
        Public NewUserRecord As New UserRecord
        Public FaceManager As VerilookManager
        Private _faceprintRegistered As Boolean = False
         Private Function checkFaceAvailable(_user As UserRecord) As Boolean
            Dim value As Boolean = Not (_user.FaceImage_1 Is Nothing Or _user.FaceImage_2 Is Nothing Or _user.FaceImage_3 Is Nothing)
            If value Then
                lbFaceStatus.ForeColor = Color.MidnightBlue
                lbFaceStatus.Text = "Your Face has been registered."
            Else
                lbFaceStatus.ForeColor = Color.Maroon
                lbFaceStatus.Text = "Your Face is not yet registered."
            End If
            Return value
        End Function

        Private Function validInfo() As Boolean
            If NewUserDB.Lookup(tbEmpNum.Text) IsNot Nothing Then
                MsgBox("This ID is already taken.")
                tbEmpNum.Select()
                Return False
            ElseIf (Not tbEmpNum.Text.Equals("")) And (cbCompBranch.Equals("") Or cbDept.Equals("") _
                        Or tbMname.Equals("") Or tbLname.Text.Equals("") Or tbFname.Text.Equals("")) Then
                If MsgBox("All Fields are important and should not be blanked, do You want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return True
                Else : Return False
                End If
            ElseIf tbEmpNum.Text.Equals("") Then
                MsgBox("Your ID is Blank.")
                tbEmpNum.Select()
                Return False
            Else
                Return True
            End If
        End Function

        Private Sub frmAddUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If addedMore Then DialogResult = Windows.Forms.DialogResult.OK
        End Sub

        Private Sub frmAddUser_Load(sender As Object, e As EventArgs) Handles Me.Load
            cbCompBranch.Focus()
            cbCompBranch.SelectedIndex = 0
            cbDept.SelectedIndex = 0
            cbSched.SelectedIndex = 0
            DialogResult = Windows.Forms.DialogResult.None
            addedMore = False
        End Sub

        Private Sub btnRegisterFace_Click(sender As Object, e As EventArgs) Handles btnRegisterFace.Click
            If checkFaceAvailable(NewUserRecord) Then
                If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Else : Exit Sub
                End If
            End If
            FaceManager.editFaceTemplate(NewUserRecord)
            checkFaceAvailable(NewUserRecord)
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If validInfo() Then

                SaveUser()

                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End Sub

        Private addedMore As Boolean
        Private Sub btnAddMore_Click(sender As Object, e As EventArgs) Handles btnAddMore.Click
            If validInfo() Then

                SaveUser()

                tbEmpNum.Text = ""
                tbFname.Text = ""
                tbLname.Text = ""
                tbMname.Text = ""
                cbAdmin.Checked = False

                NewUserRecord = New UserRecord
                checkFaceAvailable(NewUserRecord)

                addedMore = True
            End If
        End Sub

        Public Sub SaveUser()
            With NewUserRecord
                .EmployeeID = tbEmpNum.Text
                .Project = cbProject.Text
                .Department = cbDept.Text
                .Company = cbCompBranch.Text
                .Schedule = cbSched.Text
                .FirstName = tbFname.Text
                .LastName = tbLname.Text
                .MiddleName = tbMname.Text
                .Admin = cbAdmin.Checked
                .Active = True

                .saveToDB(FaceManager.MySQLDatabaseManager, Programs.UserTablename)
            End With
            NewUserDB.Add(NewUserRecord)
            MsgBox("New User has Been Added.")
        End Sub
    End Class
End Namespace