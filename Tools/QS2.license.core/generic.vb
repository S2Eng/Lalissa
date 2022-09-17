


Public Class generic


    Public Shared FileTypeLicQs2 As String = "Text Files (*.txt)|*.txt"




    Public Shared Sub getExep(ex As String)
        System.Windows.Forms.MessageBox.Show(ex.ToString(), "Error")
    End Sub

    Public Shared Function checkPwd(mainWindow As System.Windows.Forms.Form)
        Dim frmInputPwd1 As New frmInputPwd()
        If mainWindow Is Nothing Then
            frmInputPwd1.ShowDialog()
        Else
            frmInputPwd1.ShowDialog(mainWindow)
        End If
        If Not frmInputPwd1.abort Then
            If frmInputPwd1.pwdOK Then
                Return True
            End If
        End If
    End Function

    Public Function getDirectory(Optional ByVal defaultDir As String = "") As String
        Try

            Dim FolderBrowserDialog1 As New System.Windows.Forms.FolderBrowserDialog()
            FolderBrowserDialog1.SelectedPath = defaultDir
            FolderBrowserDialog1.Description = "Please select the path where to save the license-file"
            If FolderBrowserDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Return FolderBrowserDialog1.SelectedPath
            End If

        Catch ex As Exception
            Throw New Exception("generic.saveFile:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function saveFile(ByVal DateiTyp As String, _
                                         Optional ByVal fileNameDefault As String = "", _
                                         Optional ByVal defaultDir As String = "") As String
        Try

            Dim SaveFileDialog As New System.Windows.Forms.SaveFileDialog
            SaveFileDialog.FileName = fileNameDefault
            SaveFileDialog.InitialDirectory = defaultDir
            SaveFileDialog.Filter = DateiTyp
            SaveFileDialog.FilterIndex = 1
            SaveFileDialog.RestoreDirectory = True

            If SaveFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Return SaveFileDialog.FileName
            End If

        Catch ex As Exception
            Throw New Exception("generic.saveFile:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Shared Function getFolder(ByVal typ As System.Environment.SpecialFolder) As String
        Return System.Environment.GetFolderPath(typ)
    End Function

    Public Sub OpenDirectoryInExplorer(ByRef pathToOpen As String)
        'Shell("explorer.exe '" + Application.StartupPath + "'")

        Dim infoProc As New System.Diagnostics.ProcessStartInfo()
        infoProc.FileName = "explorer.exe"
        infoProc.Arguments = pathToOpen
        System.Diagnostics.Process.Start(infoProc)
    End Sub

    Public Shared Function getDir(ByVal File As String) As String
        Return System.IO.Path.GetFullPath(File)
    End Function
    Public Shared Function getFileName(ByVal File As String, ByVal withExtension As Boolean) As String
        If withExtension Then
            Return System.IO.Path.GetFileName(File)
        Else
            Return System.IO.Path.GetFileNameWithoutExtension(File)
        End If
    End Function

End Class
