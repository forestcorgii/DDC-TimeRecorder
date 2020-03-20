Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Module Variables

    Public Class ext
        Public Const datEx As String = ".dat"
        Public Const xmlEx As String = ".xml"
        Public Const infEx As String = ".inf"
        Public Const mdbEx As String = ".mdb"
        Public Const csvEx As String = ".csv"
        Public Const cutEx As String = ".cut"
    End Class

    Public Class bioInfo
        Public Const outPath As String = "D:\BIOMETRICS"
        Public Const timeTableFolder As String = "\Timetable\"
        Public Const timeSheetFolder As String = "\TimeSheets\"
        Public Const settingsFolder As String = "\Settings\"

        Public Const ScannerName As String = "UareU"
        Public Const pass As String = ""
    End Class

    Public Class FileList
        Public Const BackUpIO As String = "BACKUPINOUT.mdb"
        Public Const TM As String = "TIMETABLE.mdb"
        Public Const EL As String = "EMPLIST.mdb"
        Public Const TS As String = "FAC.XLS"
        Public Const ST As String = "SETTINGS.txt"
    End Class

    Public Class Stat
        Public Const C As String = "Canceled !!!"
        Public Const ST As String = "Scanner Timout..."
        Public Const ER As String = "Fingerprint Mismatch..."
        Public Const SUC As String = "Fingerprint Match..."
        Public Const NR As String = ""
        Public Const WF As String = "Waiting for Fingerprint..."
        Public Const UI As String = "Unknown ID..."
        Public Const NIR As String = "Registered..."
        Public Const INR As String = "Not Registered..."
    End Class

    Public Class EmpTimeTable
        Public ID As String
        Public defIdx As Integer
        Public printName As String

        Public outTM As String
        Public outDT As String
        Public inTM As String
        Public inDT As String

        Public comp As String
        Public empNum As String
        Public firstName As String
        Public middleName As String
        Public lastName As String
        Public department As String

        Public status As String
        Public tmIN As String
        Public tmOUT As String
        'Public HR As String
        'Public ND As String
        'Public OT As String
        'Public AB As String
        Public DAY As String

        'Public DAYOFF As String
        'Public CUTOFF As String
        'Public HOLIDAY As String
    End Class

    'Public Class dayStatus
    '    Public DAYOFF As String
    '    Public CUTOFF As String
    '    Public HOLIDAY As String
    'End Class

    Public Class TimeLabel
        Public Const timeIN As String = "Time IN"
        Public Const timeOUT As String = "Time OUT"
        Public Const standBy As String = "Type Backslash(/) First for TIME IN and an Asterisk(*) for TIME OUT"
    End Class

#Region "Fingerprints"
    Public Class printInfo
        Public idx As Integer
        Public name As String
        Public pb As PictureBox
    End Class
#End Region

#Region "Form Settings"
    'Public Class reminder
    '    Public Const HOL As String = "HOLIDAY: To put a series of days properly it should be separated by a Dash(-)."
    '    Public Const CUT As String = "CUT-OFF: To put a series of days properly it should be separated by a Dash(-)."
    '    Public Const DAY As String = "DAY-OFF: Tick all Day off only."
    '    Public Const CDF As String = "CHANGE DEFAULT FINGERPRINT: Type your ID number then choose your new default fingerprint. "
    'End Class

    'Public TBLNAME As String() = New String() {"HOLIDAY", "DAYOFF", "CUTOFF"}
#End Region
End Module
