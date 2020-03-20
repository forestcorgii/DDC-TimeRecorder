Imports System
Imports System.NET
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Neurotec.Biometrics


Namespace VBNETSample
    Public Class testBio
        Inherits Form

        Private Sub testBio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If getAdminPriv() Then
                On Error Resume Next
                If TMconn.State = ConnectionState.Open Then
                    TMconn.Close()
                End If
            Else
                e.Cancel = True
            End If
        End Sub

        Private Sub testBio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            InitializeComponent()
            SETUPBIOMETIRC()

            TimeInfo = TimeLabel.standBy
            prompt = Stat.NR
            txtID.Select()

            dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Application.DoEvents()
            'DownloadString("http://www.idcsi-officesuites.com:8080/hrms/announcement.php?id=IUUI65DSDSS35OPUY")
        End Sub

        Public Shared Sub DownloadString(ByVal address As String)
            Dim client As WebClient = New WebClient()
            Dim reply As String = client.DownloadString(address)
            Console.WriteLine(reply)
        End Sub

        Private Sub txtID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.GotFocus
            txtID.Text = ""
            txtID.ForeColor = Color.Black
        End Sub

        Private Sub txtID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyDown
            Debug.Print(Chr(e.KeyCode))
        End Sub

        Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = Chr(8) Then
                If Not TimeInfo = TimeLabel.standBy Then
                    If ID.Length = 3 Then
                        ID &= e.KeyChar
                        If ID.Length = 4 Then
                            getInfo()
                            refreshAll()
                            TimeInfo = TimeLabel.standBy
                            e.Handled = True
                        Else
                            refreshAll()
                            e.Handled = True
                        End If
                    End If
                Else
                    setTimer(Timer1, lbTimeInfo, 1, TimeLabel.standBy, "FAILED", True)
                    e.Handled = True
                End If
            ElseIf e.KeyChar = "/" Then
                TimeInfo = TimeLabel.timeIN
                e.Handled = True
            ElseIf e.KeyChar = "*" Then
                TimeInfo = TimeLabel.timeOUT
                e.Handled = True
            Else
                e.Handled = True
            End If
        End Sub

        Private Sub txtID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtID.LostFocus
            setTimertoReFocus(4)
        End Sub

        Private Function getAdminPriv() As Boolean
            Dim tmpDT As New DataTable
            Dim tmpConn As New OleDb.OleDbConnection
            Dim tmpStr As String = msgBox_in("Administrator's ID is needed to proceed", "", 4, False)
            If File.Exists((String.Format("{0}{1}{2}{3}", Application.StartupPath, bioInfo.timeTableFolder, tmpStr, ext.infEx))) Then
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.EL), tmpConn)
                mdbToDT("SELECT Admin FROM List WHERE ID = '" & tmpStr & "'", tmpDT, tmpConn)
                If tmpDT.Rows(0).Item("Admin") = True Then
                    If VerifyAdmin(tmpStr) Then
                        Return True
                    Else
                        ' MsgBox("Fingerprint Mismatch")
                        Return False
                    End If
                Else
                    MsgBox("The user of this ID is not an Administrator.")
                    Return False
                End If
            End If
            Return False
        End Function

        Private Sub btnEnroll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnroll.Click
            If File.Exists(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.EL)) Then
                If Not getAdminPriv() Then
                    Exit Sub
                End If
            End If
            Using regFrm As New VBNETSample.EmpRegistration
                regFrm.ShowDialog()
                'If regFrm.DialogResult = Windows.Forms.DialogResult.OK Then
                '    setTimer(Timer1, lbPromt, 2, Stat.NIR, "SUCCESS")
                'Else
                '    setTimer(Timer1, lbPromt, 2, Stat.INR, "FAILED")
                'End If
            End Using
        End Sub

#Region "PUBLIC PROPERTIES"
        Public Property ID() As String
            Get
                Return txtID.Text
            End Get
            Set(ByVal value As String)
                txtID.Text = value
            End Set
        End Property

        Public Property TimeInfo() As String
            Get
                Return lbTimeInfo.Text
            End Get
            Set(ByVal value As String)
                lbTimeInfo.Text = value
            End Set
        End Property

        Public Property ComName() As String
            Get
                Return lbComName.Text
            End Get
            Set(ByVal value As String)
                lbComName.Text = value
            End Set
        End Property

        Public ReadOnly Property DT() As String
            Get
                Return Microsoft.VisualBasic.Strings.Format(Date.Now, "yyyy-MM-dd")
            End Get
        End Property

        Public ReadOnly Property TM() As String
            Get
                Return lbClock.Text
            End Get
        End Property

        Public Property prompt() As String
            Get
                Return lbPromt.Text
            End Get
            Set(ByVal value As String)
                lbPromt.Text = value
            End Set
        End Property
#End Region

#Region "Timer settings"
        Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            Timer1.Enabled = False
            Timer1.Stop()
            lbPromt.Text = Stat.NR
            lbPromt.BackColor = Color.White
            lbPromt.ForeColor = Color.Black
            lbTimeInfo.BackColor = Color.Transparent
            lbTimeInfo.ForeColor = Color.White
        End Sub

        Public Sub setTimertoReFocus(ByVal sec As Integer)
            Timer2.Enabled = False
            Timer2.Interval = sec * 1000
            Timer2.Enabled = True
            Timer2.Start()
        End Sub

        Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
            Timer2.Enabled = False
            Timer2.Stop()
            txtID.Focus()
        End Sub

        Private Sub clock_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clock.Tick
            lbClock.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "HH:mm:ss")
            lbDate.Text = Microsoft.VisualBasic.Strings.Format(Date.Now, "dd dddd MMMM yyyy")
        End Sub

        Private Sub Clock1_TimeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Clock1.TimeChanged
            Me.Clock1.UtcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now)
        End Sub

        Private Sub NDCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Counter.Tick
            ' changeHOLlist(Date.Now.Month)
            'addNDToList(DT, Microsoft.VisualBasic.Strings.Format(Date.Now, "HH"))
            ' checkDAY(Date.Now.Day, Date.Now.ToString("ddd"), Date.Now.ToString("MM/dd/yy"))
        End Sub
#End Region

        Private Sub refreshAll()
            ID = ""
        End Sub

        Private Sub OPTIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPTIONToolStripMenuItem.Click
            If getAdminPriv() Then
                TimeSheetExporter.ShowDialog()
            End If
        End Sub

        Private Sub SETTINGSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SETTINGSToolStripMenuItem.Click
            If getAdminPriv() Then
                frmSettings.ShowDialog()
                SETUPBIOMETIRC()
            End If
        End Sub

     
    End Class
End Namespace

