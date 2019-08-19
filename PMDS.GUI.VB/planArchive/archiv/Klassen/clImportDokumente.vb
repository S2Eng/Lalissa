

Public Class clImportDokumente

    Private s2General As New GeneralArchiv
    Public Protokoll As String = ""
    Public anzAbgelegt As Integer = 0
    Public genMain As New GeneralArchiv




    Public Function importVerzeichnisse(ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim browse As New System.Windows.Forms.FolderBrowserDialog
            Dim verz As String = browse.ShowDialog()
            If Not s2General.IsNull(verz) Then

                MsgBox("Das Verzeichnis wurde erfolgreich importiert!" + vbNewLine +
                        "", MsgBoxStyle.Information, "Archivsystem")
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("importVerzeichnisse: " + ex.ToString())
        End Try
    End Function



End Class