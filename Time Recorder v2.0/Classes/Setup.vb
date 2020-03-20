Imports System.IO

Module Setup
    Public Sub MainSetup()
       If Not File.Exists(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM)) Then
            Directory.CreateDirectory(Application.StartupPath & "\" & bioInfo.timeTableFolder)
            mdbCreate(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM, ext.mdbEx))
            mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM), TMconn)
        Else
            mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM), TMconn)
        End If

        UserTables = getTables(TMconn)
    End Sub
End Module
