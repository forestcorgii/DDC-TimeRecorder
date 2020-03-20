Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Module Variables

    Public UserTables As List(Of String)

   

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
        Public Const TS As String = "OUT.XLS"
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

    'Public Class EmpTimeTable
    '    Public ID As String
    '    Public defIdx As Integer
    '    Public printName As String

    '    Public outTM As String
    '    Public outDT As String
    '    Public inTM As String
    '    Public inDT As String

    '    Public comp As String
    '    Public empNum As String
    '    Public firstName As String
    '    Public middleName As String
    '    Public lastName As String
    '    Public department As String

    '    Public status As String
    '    Public tmIN As String
    '    Public tmOUT As String
    '    Public DAY As String
    'End Class

    Public Class TimeLabels
        Public Const timeIN As String = "TIME IN"
        Public Const timeOUT As String = "TIME OUT"
        Public Const standBy As String = "Type Backslash(/) First for TIME IN and an Asterisk(*) for TIME OUT"
        Public Const cancelled As String = "Cancelled"
        Public Const none As String = ""
    End Class

#Region "Fingerprints"
    Public Class printInfo
        Public idx As Integer
        Public name As String
        Public pb As PictureBox
    End Class
#End Region


End Module
