Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports SEAN.DatabaseManagement
Imports VerilookLib.DB
Imports VerilookLib

Module Variables
    '  Public TimeRecorderUserEngines As UserCollection
 
   
    Public Class ext
        Public Const datEx As String = ".dat"
        Public Const xmlEx As String = ".xml"
        Public Const infEx As String = ".inf"
        Public Const mdbEx As String = ".mdb"
        Public Const csvEx As String = ".csv"
        Public Const cutEx As String = ".cut"
        Public Const sqliteEx As String = ".db"
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
        Public Const BackUpIO As String = "BACKUPINOUT"
        Public Const TM As String = "TIMETABLE"
        Public Const EL As String = "EMPLIST"
        Public Const TS As String = "OUT.XLS"
        Public Const ST As String = "SETTINGS.txt"
    End Class

 End Module
