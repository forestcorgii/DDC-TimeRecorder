Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Data.OleDb

Public Class frmSettings
    Private settingConn As New OleDbConnection
    Private settingPath As String

#Region "Public Properties"
    Public Property ComName() As String
        Get
            Return tbComName.Text
        End Get
        Set(ByVal value As String)
            tbComName.Text = value
        End Set
    End Property

    Public Property Acro() As String
        Get
            Return tbComAcro.Text
        End Get
        Set(ByVal value As String)
            tbComAcro.Text = value
        End Set
    End Property

#End Region

#Region "Subs and Functions"
    Public Sub readData()

        settingPath = String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.settingsFolder, FileList.ST)

        If File.Exists(settingPath) Then
            Using r As StreamReader = New StreamReader(settingPath)
                ComName = r.ReadLine
                Acro = r.ReadLine
            End Using
        Else
            Directory.CreateDirectory(String.Format("{0}{1}", Application.StartupPath, bioInfo.settingsFolder))
        End If
    End Sub

    Private Sub writeData()
        Using w As StreamWriter = File.CreateText(settingPath)
            w.WriteLine(ComName)
            w.WriteLine(Acro)
        End Using
        MsgBox("Saved.")
        Me.Close()
       End Sub
#End Region

    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        readData()
    End Sub

    Private Sub btnSAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSAVE.Click
        writeData()
        readData()
    End Sub
End Class