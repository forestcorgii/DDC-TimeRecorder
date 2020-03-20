Imports System.IO
Imports System.Data.OleDb

Namespace AddingUser
    Public Class frmAddUser
        Public NewUserDB As New UserRecords
        Private _registered As Boolean = False
        Private Property registered As Boolean
            Get
                Return _registered
            End Get
            Set(value As Boolean)
                _registered = value
                If value Then
                    lbRegStatus.ForeColor = Color.MidnightBlue
                    lbRegStatus.Text = "Your Fingerprint has been registered."
                Else
                    lbRegStatus.ForeColor = Color.Maroon
                    lbRegStatus.Text = "Your Fingerprint is not yet registered."
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
            ElseIf Not registered Then
                If MsgBox("You haven't registered your fingerprint yet, do You want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    btnRegPrint.Select()
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

        Private Sub btnRegPrint_Click(sender As Object, e As EventArgs) Handles btnRegPrint.Click
            If registered Then
                If MsgBox("Re-scan? Previous data will be overwritten.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    File.Delete(Path.Combine(Application.StartupPath, TempUsername & ext.datEx))
                Else
                    Exit Sub
                End If
            End If

            Dim frmPrint As New frmPrintReader
            frmPrint.ShowDialog()
            If File.Exists(Path.Combine(Application.StartupPath, TempUsername & ext.datEx)) Then
                NewUserDB = frmPrint.UserDB
                registered = True
            End If
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
                    .Available = registered
                    .WriteToFile(.ID & ext.xmlEx)
                    If registered Then FileSystem.Rename(Path.Combine(Application.StartupPath, TempUsername & ext.datEx), Path.Combine(Application.StartupPath, .ID & ext.datEx))
                    mdbCreateTable(.ID, New String() {"DATE-text(15)", "_TIME-text(40)", "FLAG-text(10)"}, TMconn)
                End With

                  MsgBox("Registration Complete.")
                Me.Close()
            End If
        End Sub

     
    End Class
End Namespace