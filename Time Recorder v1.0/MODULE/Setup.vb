Imports System.IO
Imports System.Windows.Forms
Namespace VBNETSample
   
    Module Setup
        Public Sub SETUPBIOMETIRC()
            frmSettings.readData()
            testBio.ComName = frmSettings.ComName

            If Not File.Exists(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM)) Then
                Directory.CreateDirectory(Application.StartupPath & "\" & bioInfo.timeTableFolder)
                mdbCreate(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM, ext.mdbEx))
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM), TMconn)
            Else
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.TM), TMconn)
            End If
            setupDGV()
        End Sub

        Private Sub setupDGV()
            If File.Exists(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.BackUpIO)) Then
                testBio.dgv.Rows.Clear()
                Dim tmp As New DataTable
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.BackUpIO), IOconn)
                mdbToDT(String.Format("SELECT  * FROM IO WHERE Date = '{0}'", testBio.DT), tmp, IOconn)

                Dim counter As Integer = 0
                For Each i As DataRow In tmp.Rows
                    testBio.dgv.Rows.Insert(0, i.Item(0).ToString, i.Item(1).ToString, i.Item(2).ToString, i.Item(3).ToString, i.Item(4).ToString)

                    If counter = 50 Then
                        Exit For
                    Else
                        counter += 1
                    End If
                Next
            Else
                mdbCreate(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.BackUpIO, ext.mdbEx))
                mdbOpen(String.Format("{0}{1}{2}", Application.StartupPath, bioInfo.timeTableFolder, FileList.BackUpIO), IOconn)
                mdbCreateTable("IO", New String() {"Date-text", "Name-text", "Dept-text", "IN-text", "OUT-text"}, IOconn)
            End If
        End Sub
    End Module
End Namespace

