Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinToolbars



Public Class contTextTemplates

    Public gen As New General()
    Public editable As Boolean = False

    Public abort As Boolean = True
    Public ui1 As New UI

    Public isLoaded As Boolean = False

    Public modalWindow As frmTextTemplates

    Public doEditor1 As New QS2.Desktop.Txteditor.doEditor()

    Public txtChanged As Boolean = False
    Public rTextTemplateSelected As dsAutoDocu.tblTextTemplatesRow = Nothing
    Public doUI1 As New doUI()

    Public contSelectPatienten As New contSelectPatientenBenutzer()
    Public contSelectBenutzer As New contSelectPatientenBenutzer()
    Public contSelectSelListCategories As New contSelectSelList()







    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            'If Not ITSCont.core.SystemDb.actUsr.rUsr.IsAdmin And Not Settings.adminSecure Then
            'End If
            'Me.ui1.setMergeStyle(Me.gridUserAccounts, True, True)
            'Me.doGridUI(False)

            For Each col As UltraGridColumn In Me.gridTextTemplates.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            Me.gridTextTemplates.DisplayLayout.Bands(0).Columns(Me.DsAutoDocu1.tblTextTemplates.BezeichnungColumn.ColumnName).Hidden = False
            Me.gridTextTemplates.DisplayLayout.Bands(0).Columns(Me.DsAutoDocu1.tblTextTemplates.ErstelltAmColumn.ColumnName).Hidden = False
            Me.gridTextTemplates.DisplayLayout.Bands(0).Columns(Me.DsAutoDocu1.tblTextTemplates.ErstelltVonColumn.ColumnName).Hidden = False

            Me.contSelectPatienten.MainTextTemplates = Me
            Me.contSelectPatienten.initControl(contSelectPatientenBenutzer.eTypeUI.Patients, False, True, Me.dropDownPatienten)
            Me.contSelectBenutzer.MainTextTemplates = Me
            Me.contSelectBenutzer.initControl(contSelectPatientenBenutzer.eTypeUI.Users, False, True, Me.dropDownUsers)

            Me.contSelectSelListCategories.MainTextTemplates = Me
            Me.contSelectSelListCategories.initControl("PlanCategory", False, True, Me.dropDownCategories, False, "Categories", "", False)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories

            Me.uPopupContPatienten.PopupControl = Me.contSelectPatienten
            Me.dropDownPatienten.PopupItem = Me.uPopupContPatienten

            Me.uPopupContUser.PopupControl = Me.contSelectBenutzer
            Me.dropDownUsers.PopupItem = Me.uPopupContUser

            Me.ContTextTemplateFiles1.modalWindow = Me
            Me.ContTextTemplateFiles1.initControl()
            Me.loadEditor()
            Me.loadData()

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contTextTemplates.initControl:" + ex.ToString())
        End Try
    End Sub

    Private Sub loadEditor()
        Try
            Me.ContTxtEditor1.doNew(True)
            'Me.ContTxtEditor1.doNew(False)
            Me.ContTxtEditor1.loadForm(False, Nothing, False)

            Me.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
            Me.ContTxtEditor1.setControlTyp()
            Me.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView
            Me.ContTxtEditor1.callEditorKeyPress = New QS2.Desktop.Txteditor.contTxtEditor.delEditorKeyPress(AddressOf Me.EditorKeyIsPressed)
            Dim dOnNewClicked As New QS2.Desktop.Txteditor.contTxtEditor.onNewClicked(AddressOf Me.TxtEditorNewClicked)
            Me.ContTxtEditor1.delOnNewClicked = dOnNewClicked
            Me.ContTxtEditor1.EnableToolbarButtons()

        Catch ex As Exception
            Throw New Exception("contTextTemplates.loadEditor:" + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub loadData()
        Try
            Me.txtBetreff.Text = ""
            Me.txtMailAn.Text = ""
            Me.txtMailCC.Text = ""
            Me.txtMailBCC.Text = ""

            Me.txtBenutzer.Text = ""
            Me.contSelectBenutzer.DsPlan1.Clear()
            Me.contSelectBenutzer.setLabelCount2()

            Me.txtPatienten.Text = ""
            Me.contSelectPatienten.DsPlan1.Clear()
            Me.contSelectPatienten.setLabelCount2()

            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.contSelectSelListCategories.setLabelCount2()

            Me.ContTextTemplateFiles1.clearUI()
            Me.ContTxtEditor1.Visible = False

            Me.DsAutoDocu1.Clear()
            Me.CompAutoDocu1.getTextTamplates(Nothing, Me.DsAutoDocu1, compAutoDocu.eSelTextTemplates.All)
            Me.gridTextTemplates.Refresh()

            Me.ContTxtEditor1.FileNew(False, False)
            Me.ContTxtEditor1.lockEingbe = True
            Me.txtChanged = False
            Me.rTextTemplateSelected = Nothing

            Me.lockUnlock(False)

            Me.lblCount.Text = doUI.getRes("Founded") + ": " + Me.DsAutoDocu1.tblTextTemplates.Rows.Count.ToString()

            Me.gridTextTemplates.Selected.Rows.Clear()
            Me.gridTextTemplates.ActiveRow = Nothing

        Catch ex As Exception
            Throw New Exception("contTextTemplates.loadData:" + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub clearErrProvider()
        Me.ErrorProvider1.SetError(Me.btnAdd, "")
        For Each rGrid As UltraGridRow In Me.gridTextTemplates.Rows
            Dim v As DataRowView = rGrid.ListObject
            Dim rTextTemplate As dsAutoDocu.tblTextTemplatesRow = v.Row
            If rTextTemplate.RowState <> DataRowState.Deleted Then
                rTextTemplate.SetColumnError(Me.DsAutoDocu1.tblTextTemplates.BezeichnungColumn.ColumnName, "")
            End If
        Next
    End Sub
    Public Function validate() As Boolean
        Try
            Me.clearErrProvider()

            Dim sResTitle As String = "Save"
            Dim sTitle As String = doUI.getRes("Save")

            For Each rGrid As UltraGridRow In Me.gridTextTemplates.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rTextTemplate As dsAutoDocu.tblTextTemplatesRow = v.Row

                If rTextTemplate.RowState <> DataRowState.Deleted Then
                    If rTextTemplate.Bezeichnung.Trim() = "" Then
                        Dim str As String = doUI.getRes("BezeichnungInputRequired")
                        rTextTemplate.SetColumnError(Me.DsAutoDocu1.tblTextTemplates.BezeichnungColumn.ColumnName, str)
                        doUI.doMessageBoxTranslated(str, sTitle, MsgBoxStyle.Information)
                        Return False
                    End If

                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contTextTemplates.validate:" + ex.ToString())
        End Try
    End Function
    Public Function save() As Boolean
        Try
            Dim rAutoDocu As dsAutoDocu.tblTextTemplatesRow = Me.getSelectedRow(False)
            If Not rAutoDocu Is Nothing Then
                Me.saveTextTemplateForRow(rAutoDocu, False)
            End If

            If Not Me.validate() Then Return False
            If Not Me.ContTextTemplateFiles1.validate() Then Return False

            If Not IsNothing(rAutoDocu) Then
                rAutoDocu.Betreff = Me.txtBetreff.Text.Trim()
                rAutoDocu.An = Me.txtMailAn.Text.Trim()
                rAutoDocu.CC = Me.txtMailCC.Text.Trim()
                rAutoDocu.BCC = Me.txtMailBCC.Text.Trim()

                Me.rTextTemplateSelected.lstIDPatienten = Me.contSelectPatienten.getDataColl()
                Me.rTextTemplateSelected.lstIDBenutzer = Me.contSelectBenutzer.getDataColl()

                Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
                Me.rTextTemplateSelected.lstCategories = Me.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            End If


            Me.CompAutoDocu1.daTextTemplates.Update(Me.DsAutoDocu1.tblTextTemplates)
            Me.ContTextTemplateFiles1.saveData()
            Return True

        Catch ex As Exception
            Throw New Exception("contTextTemplates.save:" + ex.ToString())
        End Try
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.save() Then
                Me.loadData()
                'Me.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub add()
        Try
            Dim rNew As dsAutoDocu.tblTextTemplatesRow = Me.CompAutoDocu1.getNewRowTextTemplates(Me.DsAutoDocu1)

            'Me.modalWindow.setStatBarEdited(True)
            Me.ContTxtEditor1.Visible = True

            Me.txtBetreff.Text = ""
            Me.txtMailAn.Text = ""
            Me.txtMailCC.Text = ""
            Me.txtMailBCC.Text = ""

            Me.ContTxtEditor1.FileNew(False, False)
            Me.ContTxtEditor1.lockEingbe = False
            Me.txtChanged = False
            Me.rTextTemplateSelected = rNew

            Me.gridTextTemplates.Selected.Rows.Clear()
            Me.gridTextTemplates.ActiveRow = Nothing

            Dim gridRowToSelect As UltraGridRow = Me.gridTextTemplates.Rows.GetRowWithListIndex(Me.DsAutoDocu1.tblTextTemplates.Rows.IndexOf(rNew))
            Me.gridTextTemplates.ActiveRow = gridRowToSelect

            Me.ContTextTemplateFiles1.loadData(rNew.ID)

            Me.txtBenutzer.Text = ""
            Me.contSelectBenutzer.DsPlan1.Clear()
            Me.contSelectBenutzer.setLabelCount2()

            Me.txtPatienten.Text = ""
            Me.contSelectPatienten.DsPlan1.Clear()
            Me.contSelectPatienten.setLabelCount2()

            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.contSelectSelListCategories.setLabelCount2()

        Catch ex As Exception
            Throw New Exception("contTextTemplates.add:" + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub delete()
        Try
            Dim arrSelected As New System.Collections.Generic.List(Of UltraGridRow)

            Dim sitemap1 As New PMDS.Global.UIGlobal()
            Dim res As System.Windows.Forms.DialogResult = PMDS.Global.generic.doAction2([Global].generic.eAction.print, "", "", "", Me.gridTextTemplates, Nothing, arrSelected, False, True)
            Dim listID As New System.Collections.Generic.List(Of System.Guid)
            If arrSelected.Count = 0 Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Me.Cursor = Windows.Forms.Cursors.Default
                Exit Sub
            Else
                If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntries", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                    For Each r As UltraGridRow In arrSelected
                        r.Delete()
                        'Me.modalWindow.setStatBarEdited(True)
                        Me.ContTxtEditor1.FileNew(False, False)
                        Me.ContTxtEditor1.lockEingbe = False
                        Me.txtChanged = False
                        Me.rTextTemplateSelected = Nothing

                        Me.ContTextTemplateFiles1._IDTextTemplate = Nothing
                        Me.txtBetreff.Text = ""
                        Me.txtMailAn.Text = ""
                        Me.txtMailCC.Text = ""
                        Me.txtMailBCC.Text = ""
                        Me.ContTextTemplateFiles1.clearUI()

                        Me.txtBenutzer.Text = ""
                        Me.contSelectBenutzer.DsPlan1.Clear()
                        Me.contSelectBenutzer.setLabelCount2()

                        Me.txtPatienten.Text = ""
                        Me.contSelectPatienten.DsPlan1.Clear()
                        Me.contSelectPatienten.setLabelCount2()

                        Me.contSelectSelListCategories.setSelectionOnOff(False)
                        Me.contSelectSelListCategories.setLabelCount2()
                    Next
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contTextTemplates.delete:" + ex.ToString())
        Finally
        End Try
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.delete()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.btnAdd.Enabled = bEdit
            Me.btnDel.Enabled = bEdit
            Me.btnSave.Enabled = bEdit
            Me.btnApport.Enabled = bEdit

            Me.txtBetreff.Enabled = bEdit
            Me.txtMailAn.Enabled = bEdit
            Me.txtMailCC.Enabled = bEdit
            Me.txtMailBCC.Enabled = bEdit

            Me.ContTextTemplateFiles1.btnAdd.Enabled = bEdit
            Me.ContTextTemplateFiles1.btnDel.Enabled = bEdit

            Me.editable = bEdit

            If Me.editable Then
                Me.gridTextTemplates.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.gridTextTemplates.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

            Me.ContTxtEditor1.lockEingbe = Not bEdit

        Catch ex As Exception
            Throw New Exception("contTextTemplates.lockUnlock:" + ex.ToString())
        End Try
    End Sub
    Public Sub TxtEditorNewClicked()
        Try
            Me.txtChanged = True

        Catch ex As Exception
            Throw New Exception("contTextTemplates.TxtEditorNewClicked:" + ex.ToString())
        End Try
    End Sub
    Public Sub EditorKeyIsPressed()
        Try
            Me.txtChanged = True

        Catch ex As Exception
            Throw New Exception("contTextTemplates.EditorKeyIsPressed:" + ex.ToString())
        End Try
    End Sub
    Private Sub UltraGrid1_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridTextTemplates.BeforeCellActivate
        Try
            If e.Cell.Row.IsFilterRow Or e.Cell.Row.IsGroupByRow Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            End If

            If Not Me.editable Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                If e.Cell.Column.ToString().Trim().ToLower().Equals(Me.DsAutoDocu1.tblTextTemplates.BezeichnungColumn.ColumnName.Trim().ToLower()) Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridTextTemplates.BeforeRowsDeleted
        If Me.gridTextTemplates.Focused Then
            e.DisplayPromptMsg = True
            e.Cancel = True
        Else
            e.DisplayPromptMsg = False
        End If
    End Sub


    Private Sub btnApport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApport.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadData()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AlleAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        Me.AlleAuswählen(True)
    End Sub
    Private Sub KeineAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswählenToolStripMenuItem.Click
        Me.AlleAuswählen(False)
    End Sub

    Public Sub AlleAuswählen(ByVal JaNein As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            For Each r As UltraGridRow In PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridTextTemplates, False, True)
                If PMDS.Global.generic.IsInExpandedGroup(r) Then
                    r.Selected = JaNein
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.add()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.modalWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub gridAutoDocus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridTextTemplates.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim sitemap1 As New PMDS.Global.UIGlobal()
            If sitemap1.evClickOK(sender, e, Me.gridTextTemplates) Then
                Dim rTextTemplate As dsAutoDocu.tblTextTemplatesRow = Me.getSelectedRow(False)
                If Not rTextTemplate Is Nothing Then
                    Me.getDocuForRow(rTextTemplate, True, False)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub saveTextTemplateForRow(ByRef rTextTemplate As dsAutoDocu.tblTextTemplatesRow, ByVal withMsgBox As Boolean)
        Try
            If Not rTextTemplate Is Nothing Then   'And Me.txtChanged 
                Dim retMsgBox As MsgBoxResult = MsgBoxResult.Yes
                If withMsgBox Then
                    retMsgBox = doUI.doMessageBox3("SaveChanges", "Save", MsgBoxStyle.YesNo, "?")
                End If
                If retMsgBox = MsgBoxResult.Yes Then
                    rTextTemplate.Txt = Me.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, Me.ContTxtEditor1.textControl1)
                End If
            End If

            Me.txtChanged = False
            Me.rTextTemplateSelected = rTextTemplate

            Me.ContTxtEditor1.lockEingbe = Not Me.editable

        Catch ex As Exception
            Throw New Exception("contTextTemplates.saveTextTemplateForRow:" + ex.ToString())
        End Try
    End Sub
    Public Sub getDocuForRow(ByRef rTextTemplate As dsAutoDocu.tblTextTemplatesRow, ByVal withMsgBox As Boolean, saveChanges As Boolean)
        Try
            Me.ContTxtEditor1.Visible = True

            If saveChanges Then
                Me.saveTextTemplateForRow(Me.rTextTemplateSelected, withMsgBox)
            End If

            Me.txtChanged = False
            Me.rTextTemplateSelected = rTextTemplate

            Me.txtBetreff.Text = Me.rTextTemplateSelected.Betreff
            Me.txtMailAn.Text = Me.rTextTemplateSelected.An
            Me.txtMailCC.Text = Me.rTextTemplateSelected.CC
            Me.txtMailBCC.Text = Me.rTextTemplateSelected.BCC

            Me.contSelectPatienten.loadDataColl(Me.rTextTemplateSelected.lstIDPatienten.Trim())
            Me.contSelectPatienten.setLabelCount2()
            Me.contSelectBenutzer.loadDataColl(Me.rTextTemplateSelected.lstIDBenutzer.Trim())
            Me.contSelectBenutzer.setLabelCount2()

            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.contSelectSelListCategories.loadDataColl(Me.rTextTemplateSelected.lstCategories)
            Me.contSelectSelListCategories.setLabelCount2()

            Me.ContTxtEditor1.FileNew(False, False)
            Me.ContTxtEditor1.showText(rTextTemplate.Txt, TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView)

            Me.ContTextTemplateFiles1.loadData(Me.rTextTemplateSelected.ID)
            Me.ContTxtEditor1.lockEingbe = Not Me.editable

        Catch ex As Exception
            Throw New Exception("contTextTemplates.getDocuForRow:" + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal withMsgBox As Boolean) As dsAutoDocu.tblTextTemplatesRow
        Try
            If Not Me.gridTextTemplates.ActiveRow Is Nothing Then
                If Me.gridTextTemplates.ActiveRow.IsGroupByRow Or Me.gridTextTemplates.ActiveRow.IsFilterRow Then
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridTextTemplates.ActiveRow.ListObject
                    Dim rSelRow As dsAutoDocu.tblTextTemplatesRow = v.Row
                    Return rSelRow
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contTextTemplates.getSelectedRow:" + ex.ToString())
        End Try
    End Function


    Private Sub btnSearchAn_Click(sender As Object, e As EventArgs) Handles btnSearchAn.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnSearchCc_Click(sender As Object, e As EventArgs) Handles btnSearchCc.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnBcc_Click(sender As Object, e As EventArgs) Handles btnBcc.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub dropDownUsers_Click(sender As Object, e As EventArgs) Handles dropDownUsers.Click
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub dropDownPatienten_Click(sender As Object, e As EventArgs) Handles dropDownPatienten.Click
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub dropDownEdit2_Click(sender As Object, e As EventArgs) Handles dropDownEdit2.Click
        Try
            Me.lockUnlock(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class