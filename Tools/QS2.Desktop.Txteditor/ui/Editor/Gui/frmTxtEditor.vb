Imports System.Windows.Forms

Public Class frmTxtEditor


    Public fFelderEinAus2 As Boolean = False
    Public ds As DataSet

    Private Sub frmTxtEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            generic.getRes("Texteditor")
            Me.ContTxtEditor1.mainForm = Me
            Me.ContTxtEditor1.doNew(True)
            Me.ContTxtEditor1.loadForm(False, Me.ds, True)
            Me.ContTxtEditor1.setControlTyp()
            Me.ContTxtEditor1.FileNew(False, False)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function openDokument(ByVal docu As String, ByVal typ As TXTextControl.StreamType, ByVal lockEingbe As Boolean) As Boolean
        Try
            If docu = "" Then
                generic.showMessageBox(generic.getRes("NoDocumentSpecified"), Windows.Forms.MessageBoxButtons.OK, _
                                                generic.getRes("OpenDocument"))
            End If
            Me.ContTxtEditor1.showFile(docu, lockEingbe, typ, TXTextControl.ViewMode.PageView, False)
            Return True

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
        End Try
    End Function

    Private Sub frmTxtEditor_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    End Sub

    Private Sub lblProtocol_Click(sender As System.Object, e As System.EventArgs) Handles lblProtocol.Click
        Try
            Dim frmProtocol1 As New frmProtocol()
            frmProtocol1.initControl()
            frmProtocol1.Text = Me.ContTxtEditor1.ProtocollTitle
            frmProtocol1.ContProtocol1.txtProtokoll.Text = Me.ContTxtEditor1.ProtocollText
            frmProtocol1.Show()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class