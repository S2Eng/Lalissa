Imports Infragistics.Win.UltraWinListView
Imports System.Windows.Forms
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid


Public Class contTextTemplateFiles

    Public _IDTextTemplate As Guid = Nothing

    Public modalWindow As contTextTemplates = Nothing

    Public ui As New UI
    Public fct As New QS2.functions.vb.FileFunctions()

    Public isLoaded As Boolean = False
    Public editable As Boolean = False
    Public doUI1 As New doUI()

    Public gen As New General()








    Private Sub contTextTemplateFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.btnAdd.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDel.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.initControl:" + ex.ToString())
        End Try
    End Sub
    Public Sub clearUI()
        Try
            Me.DsAutoDocu1.Clear()
            Me.gridTextTemplatesFiles.Refresh()

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.clearUI:" + ex.ToString())
        End Try
    End Sub
    Public Sub loadData(ByRef IDTextTemplate As Guid)
        Try
            Me._IDTextTemplate = IDTextTemplate

            If Me._IDTextTemplate = Nothing Then
                Throw New Exception("contTextTemplateFiles.loadData: Me._IDTextTemplate = Nothing not allowed!")
            End If

            Me.DsAutoDocu1.Clear()
            Me.gridTextTemplatesFiles.Refresh()

            Me.CompAutoDocu1.getTextTamplatesFiles(Me._IDTextTemplate, Me.DsAutoDocu1, compAutoDocu.eSelTextTemplates.IDTextTemplate)
            Me.gridTextTemplatesFiles.Refresh()

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.loadData:" + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub clearErrProvider()
        Me.ErrorProvider1.SetError(Me.btnAdd, "")
        For Each rGrid As UltraGridRow In Me.gridTextTemplatesFiles.Rows
            Dim v As DataRowView = rGrid.ListObject
            Dim rTextTemplateFiles As dsAutoDocu.tblTextTemplatesFilesRow = v.Row
            If rTextTemplateFiles.RowState <> DataRowState.Deleted Then
                rTextTemplateFiles.SetColumnError(Me.DsAutoDocu1.tblTextTemplatesFiles.BezeichnungColumn.ColumnName, "")
            End If
        Next
    End Sub
    Public Function validate() As Boolean
        Try
            Me.clearErrProvider()

            Dim sResTitle As String = "Save"
            Dim sTitle As String = doUI.getRes("Save")

            For Each rGrid As UltraGridRow In Me.gridTextTemplatesFiles.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rTextTemplateFiles As dsAutoDocu.tblTextTemplatesFilesRow = v.Row

                If rTextTemplateFiles.RowState <> DataRowState.Deleted Then
                    If rTextTemplateFiles.Bezeichnung.Trim() = "" Then
                        Dim str As String = doUI.getRes("BezeichnungInputRequired")
                        rTextTemplateFiles.SetColumnError(Me.DsAutoDocu1.tblTextTemplatesFiles.BezeichnungColumn.ColumnName, str)
                        doUI.doMessageBoxTranslated(str, sTitle, MsgBoxStyle.Information)
                        Return False
                    End If

                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.validate:" + ex.ToString())
        End Try
    End Function
    Public Function saveData() As Boolean
        Try
            'If Me._IDTextTemplate = Nothing Then
            '    Throw New Exception("contTextTemplateFiles.saveData: Me._IDTextTemplate = Nothing not allowed!")
            'End If

            Me.CompAutoDocu1.daTextTemplatesFiles.Update(Me.DsAutoDocu1.tblTextTemplatesFiles)
            Return True

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.saveData:" + ex.ToString())
        Finally
        End Try
    End Function

    Public Sub add()
        Try
            Dim funct1 As New QS2.functions.vb.FileFunctions()
            Dim selectedFile As String = ""
            selectedFile = funct1.selectFile("All Files (*.*)|*.*|" +
                                                        "Microsoft Word Files (*.doc)|*.doc|" +
                                                        "Microsoft Excel Files (*.xls)|*.xls|" +
                                                        "Text Files (*.txt)|*.txt|" +
                                                        "pdf Files (*.pdf)|*.pdf|" +
                                                        "rtf Files (*.Rtf)|*.rtf", "")
            If Not gen.IsNull(selectedFile) Then
                Dim dateiTyp As String = System.IO.Path.GetExtension(selectedFile)
                Dim bez As String = Microsoft.VisualBasic.InputBox(doUI.getRes("AddAppendix"), doUI.getRes("EnterANameForTheDocument"), System.IO.Path.GetFileNameWithoutExtension(selectedFile))
                If bez <> "" Then
                    Dim bs() As Byte = Me.gen.readByteStreamFile(selectedFile)

                    Dim rNew As dsAutoDocu.tblTextTemplatesFilesRow = Me.CompAutoDocu1.getNewRowTextTemplatesFiles(Me.DsAutoDocu1)
                    rNew.IDTextTemplate = Me._IDTextTemplate
                    rNew.Bezeichnung = bez.Trim()
                    rNew.FileType = dateiTyp
                    rNew.Docu = bs

                    Me.gridTextTemplatesFiles.Refresh()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.add:" + ex.ToString())
        End Try
    End Sub

    Public Sub del()
        Try
            Dim arrSelected As New System.Collections.Generic.List(Of UltraGridRow)

            Dim res As System.Windows.Forms.DialogResult = PMDS.Global.generic.doAction2([Global].generic.eAction.print, "", "", "", Me.gridTextTemplatesFiles, Nothing, arrSelected, False, True)
            Dim listID As New System.Collections.Generic.List(Of System.Guid)
            If arrSelected.Count = 0 Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                    For Each r As UltraGridRow In arrSelected
                        r.Delete()
                    Next
                    Me.gridTextTemplatesFiles.Refresh()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.del:" + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal withMsgBox As Boolean) As dsAutoDocu.tblTextTemplatesFilesRow
        Try
            If Not Me.gridTextTemplatesFiles.ActiveRow Is Nothing Then
                If Me.gridTextTemplatesFiles.ActiveRow.IsGroupByRow Or Me.gridTextTemplatesFiles.ActiveRow.IsFilterRow Then
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridTextTemplatesFiles.ActiveRow.ListObject
                    Dim rSelRow As dsAutoDocu.tblTextTemplatesFilesRow = v.Row
                    Return rSelRow
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contTextTemplateFiles.getSelectedRow:" + ex.ToString())
        End Try
    End Function

    Public Sub FileOpen(ByRef showMsgBox As Boolean)
        Try
            Dim rTextTempülateFile As dsAutoDocu.tblTextTemplatesFilesRow = Me.getSelectedRow(showMsgBox)
            If Not rTextTempülateFile Is Nothing Then
                Dim clOpen As New clFolder
                Dim clArchiv As New cArchive()
                clOpen.openFile(clArchiv.getFileFromDB(rTextTempülateFile.Bezeichnung, rTextTempülateFile.FileType, rTextTempülateFile.Docu), Nothing, False, True, False)
            End If

        Catch ex As Exception
            Throw New Exception("FileOpen: " + ex.ToString())
        End Try
    End Sub
    Public Sub SaveFileAs()
        Try
            Dim rTextTempülateFile As dsAutoDocu.tblTextTemplatesFilesRow = Me.getSelectedRow(True)
            If Not rTextTempülateFile Is Nothing Then
                Dim clOpen As New clFolder
                Dim clArchiv As New cArchive()
                Dim ui1 As New UI()
                ui1.saveFileAs(clArchiv.getFileFromDB(rTextTempülateFile.Bezeichnung, rTextTempülateFile.FileType, rTextTempülateFile.Docu), rTextTempülateFile.FileType)
            End If

        Catch ex As Exception
            Throw New Exception("SaveFileAs: " + ex.ToString())
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.add()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.del()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub gridTextTemplatesFiles_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridTextTemplatesFiles.BeforeCellActivate
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            e.Cell.Activation = Activation.NoEdit

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub gridTextTemplatesFiles_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridTextTemplatesFiles.BeforeRowsDeleted
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            e.DisplayPromptMsg = False
            'e.Cancel = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub gridTextTemplatesFiles_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles gridTextTemplatesFiles.ClickCell
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub gridTextTemplatesFiles_DoubleClick(sender As Object, e As EventArgs) Handles gridTextTemplatesFiles.DoubleClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim ui1 As New PMDS.Global.UIGlobal()
            If ui1.evDoubleClickOK(sender, e, Me.gridTextTemplatesFiles) Then
                Me.FileOpen(False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub DateiÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateiÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.FileOpen(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub SpeichernUnterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.SaveFileAs()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
