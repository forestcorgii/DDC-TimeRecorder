Imports System.Windows.Forms
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.IO

Namespace VBNETSample
    Public Class getFingerprints
        Private printList As New List(Of printInfo)
        Private _ID As String

        Public Sub New(ByVal id As String)
            InitializeComponent()

            _ID = id
            useID(_ID)
            setupPrintList()
        End Sub

        Private Sub setupPrintList()

            Dim p As New printInfo
            p.idx = 0
            p.name = "Specimen 1"
            p.pb = pb1
            printList.Add(p)

            p = New printInfo
            p.idx = 1
            p.name = "Specimen 2"
            p.pb = pb2
            printList.Add(p)

            p = New printInfo
            p.idx = 2
            p.name = "Specimen 3"
            p.pb = pb3
            printList.Add(p)

            p = New printInfo
            p.idx = 3
            p.name = "Specimen 4"
            p.pb = pb4
            printList.Add(p)
        End Sub

        Private Function enrollPrint(ByVal info As printInfo, ByVal pb As PictureBox) As Boolean
            Dim bmp As Bitmap = EnrollID(info.name)
            If bmp IsNot Nothing Then
                pb.Image = bmp
            Else
                Return False
            End If
            Return True
        End Function

        Private Sub startPrinting()
            For Each newPrint As printInfo In printList
                If newPrint.pb.Image Is Nothing Then
                    If Not enrollPrint(newPrint, newPrint.pb) Then
                        btnResume.Enabled = True
                        Exit Sub
                    End If
                End If
            Next

            If MessageBox.Show("All Fingerprints are registered. Do you want to save?", "Confirm Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Me.DialogResult = DialogResult.Yes
                Me.Close()
            End If
        End Sub

        Private Sub clearAllPrint()
            If clearPrints() Then
                For Each pbprint As printInfo In printList
                    pbprint.pb.Image = Nothing
                Next
                btnStart.Enabled = True
            End If
        End Sub

        Private Sub btnResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResume.Click
            btnResume.Enabled = False
            startPrinting()
        End Sub

        Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
            If cbDefPrint.Text = "" Then
                MsgBox("Select Fingerprint first.")
            Else
                btnStart.Enabled = False
                startPrinting()
            End If
        End Sub

        Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
            If clearPrints() Then
                For Each pbprint As printInfo In printList
                    pbprint.pb.Image = Nothing
                Next
                btnStart.Enabled = True
            End If
        End Sub
    End Class
End Namespace

