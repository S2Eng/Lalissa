

Public Class frmHTMLOptions
    Public FileHandler1 As FileHandler

    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        FileHandler1.CSSFileName = txtStylesheetFile.Text
        If optNoStylesheet.Checked Then
            FileHandler1.CSSSaveMode = TXTextControl.CssSaveMode.None
        Else
            If optInlineStylesheet.Checked Then
                FileHandler1.CSSSaveMode = TXTextControl.CssSaveMode.Inline
            Else
                If optSaveStylesheetInSeperateFile.Checked Then
                    FileHandler1.CSSSaveMode = TXTextControl.CssSaveMode.OverwriteFile
                Else
                    FileHandler1.CSSSaveMode = TXTextControl.CssSaveMode.CreateFile
                End If
            End If
        End If
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub optNoStylesheet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optNoStylesheet.CheckedChanged
        EnableFilename(False)
    End Sub

    Private Sub optInlineStylesheet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optInlineStylesheet.CheckedChanged
        EnableFilename(False)
    End Sub

    Private Sub optSaveStylesheetInSeperateFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSaveStylesheetInSeperateFile.CheckedChanged
        EnableFilename(True)
    End Sub

    Private Sub optSaveButDoNotOverwriteExistingFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSaveButDoNotOverwriteExistingFile.CheckedChanged
        EnableFilename(True)
    End Sub

    Private Sub EnableFilename(ByVal Enable As Boolean)
        lblStylesheetFile.Enabled = Enable
        txtStylesheetFile.Enabled = Enable
    End Sub

    Private Sub frmHTMLOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtStylesheetFile.Text = FileHandler1.CSSFileName
        Select Case FileHandler1.CSSSaveMode
            Case TXTextControl.CssSaveMode.None
                optNoStylesheet.Checked = True
                ' break
            Case TXTextControl.CssSaveMode.Inline
                optInlineStylesheet.Checked = True
                ' break
            Case TXTextControl.CssSaveMode.OverwriteFile
                optSaveStylesheetInSeperateFile.Checked = True
                ' break
            Case TXTextControl.CssSaveMode.CreateFile
                optSaveButDoNotOverwriteExistingFile.Checked = True
                ' break
        End Select
    End Sub


End Class