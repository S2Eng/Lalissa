Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports qs2.Resources
Imports Infragistics.Win.UltraWinToolTip

Public Class contSelChaptFldShort


    Public IDParticipant As String = ""
    Public IDApplication As String = ""
    'Public selrCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow
    'Public selrGridCriteria As UltraGridRow

    Public selRowsGrid As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)

    Public ui1 As New qs2.core.ui()
    'Public mainWindow As frmSelectField
    Public funct1 As New qs2.core.vb.funct()

    Public delOnSelection As onSelection
    Public Delegate Sub onSelection(ByVal close As Boolean)

    Public delOnAddWithoutClosing As onAddWithoutClosing
    Public Delegate Sub onAddWithoutClosing(selectedTab As Integer, selRowsGrid As System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow),
                                            ByRef protocoll As String, add As Boolean, rSelListSelChapter As qs2.core.vb.dsAdmin.tblSelListEntriesRow,
                                            StayTypeToShowChapters As qs2.core.Enums.eStayTyp, addPlaceholder As Boolean)

    Public rSelQuery As qs2.core.vb.dsAdmin.tblSelListEntriesRow = Nothing
    Public SelectedTypQueryDef As String = ""
    Public modeQueryUI As qs2.core.Enums.eTypeQuery = Nothing
    Public StayTypeToShowChapters As qs2.core.Enums.eStayTyp = core.Enums.eStayTyp.All

    Public SelectionWithoutClosing As Boolean = False
    Public protocoll As String = ""

    Public add As Boolean = False

    Public dsAdminTmp2 As New core.vb.dsAdmin()
    Public b As New qs2.core.vb.businessFramework()
    Public b2 As New core.db.ERSystem.businessFramework()

    Public rSelListSelChapter2 As qs2.core.vb.dsAdmin.tblSelListEntriesRow = Nothing
    Public ui3 As New qs2.core.vb.ui()










    Public Sub initControl()
        Try
            Me.SqlAdmin1.initControl()

            Me.DropDownApplications1.initControl(False)
            Me.DropDownApplications1.loadData()

            For Each col As UltraGridColumn In Me.gridChapter.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            Me.gridChapter.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
            'Me.gridChapter.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.FldShortColumnColumn.ColumnName).Hidden = False

            Me.loadRes()

            If Not Me.DesignMode Then
                Me.TranslateToolStripMenuItem.Visible = True
                Me.ToolStripMenuItemSpaceTranslate.Visible = True
            Else
                Me.TranslateToolStripMenuItem.Visible = True
                Me.ToolStripMenuItemSpaceTranslate.Visible = True
            End If

            If Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower()) And
                    Me.rSelQuery.TypeStr.Trim().ToLower().Equals(core.Enums.eTypeQuery.User.ToString().Trim().ToLower()) And
                    Me.modeQueryUI = core.Enums.eTypeQuery.User Then

                'Me.optionSetChaptersYN.Visible = False

            End If

            Me.loadChapters(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.gridCriterias.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ..."

            Me.gridCriterias.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.FldShortColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.UsedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Used")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.UseInQueriesColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("UseInQueries")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.SourceTableColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Table")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.ControlTypeColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ControlType")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblCriteria.preferedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Prefered")

            Me.gridChapter.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter")

            Me.optionSetChaptersYN.Items(0).DisplayText = qs2.core.language.sqlLanguage.getRes("FieldsInChapters")
            Me.optionSetChaptersYN.Items(1).DisplayText = qs2.core.language.sqlLanguage.getRes("FieldsNoChapters")

            Me.TranslateToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("TranslateEntry")
            Me.TranslateToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32)

            Me.gridChapter.Text = qs2.core.language.sqlLanguage.getRes("Chapters")
            Me.gridCriterias.Text = qs2.core.language.sqlLanguage.getRes("Fields")
            Me.chkOnlyShowPreferedFields.Text = qs2.core.language.sqlLanguage.getRes("OnlyShowPreferedFields")
            Me.MarkAsPreferedFieldToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_marked, 32, 32)
            Me.chkOnlyShowPreferedFields.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_marked, 32, 32)
            Me.chkOnlyShowPreferedFields.Visible = False

            Me.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search")

            Me.MarkAsPreferedFieldToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("MarkAsPreferedField")
            Me.MarkNotAsPreferedFieldToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("MarkNotAsPreferedField")

            Dim info As New UltraToolTipInfo()
            info.ToolTipText = qs2.core.language.sqlLanguage.getRes("AddPlaceholderField")
            info.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAddPlaceholder, info)
            Me.btnAddPlaceholder.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadChapters(ByVal withChapters As Boolean)
        Try
            Me.gridBagLayoutPanelChapters.Visible = withChapters

            Me.DsAdmin1.tblSelListEntries.Rows.Clear()
            Me.DsAdmin1.tblCriteria.Rows.Clear()
            Me.gridCriterias.Refresh()

            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim lSelListEntryObj_RolesUsr As List(Of Integer) = b.GetRolesForUser(IDApplication, qs2.core.vb.actUsr.rUsr.ID, db)
                If withChapters Then
                    Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                    If Me.rSelQuery.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower()) And
                            Me.rSelQuery.TypeStr.Trim().ToLower().Equals(core.Enums.eTypeQuery.User.ToString().Trim().ToLower()) And
                            (Me.modeQueryUI = core.Enums.eTypeQuery.User Or Me.modeQueryUI = core.Enums.eTypeQuery.Admin) Then

                        Me.StayTypeToShowChapters = ui3.getQueryChapterType(Me.rSelQuery.Classification)

                        If Me.StayTypeToShowChapters = core.Enums.eStayTyp.Stay Then
                            Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters0", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)

                        ElseIf Me.StayTypeToShowChapters = core.Enums.eStayTyp.FollowUp Then
                            Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters1", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)

                        Else
                            Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters0", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)
                            Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters1", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)
                            Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters0", Me.IDParticipant, qs2.core.license.doLicense.eApp.ALL.ToString(), Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)

                        End If
                    Else
                        Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters0", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)
                        Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters1", Me.IDParticipant, Me.IDApplication, Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)
                        Me.SqlAdmin1.getSelListEntrys(Parameters, "Chapters0", Me.IDParticipant, qs2.core.license.doLicense.eApp.ALL.ToString(), Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlList.group)

                    End If

                    Dim lstChaptersToDelete As New System.Collections.Generic.List(Of qs2.core.vb.dsAdmin.tblSelListEntriesRow)
                    For Each rSelListChapter As qs2.core.vb.dsAdmin.tblSelListEntriesRow In Me.DsAdmin1.tblSelListEntries
                        Dim rigthOK As Boolean = True

                        If qs2.core.ENV.adminSecure Then
                            rigthOK = True
                        End If
                        
                        If Not rigthOK Then
                            lstChaptersToDelete.Add(rSelListChapter)
                        End If
                        
                        If Not b.CheckUserHasRightChapter(IDApplication, rSelListChapter.ID, lSelListEntryObj_RolesUsr, db) Then
                            lstChaptersToDelete.Add(rSelListChapter)
                        End If
                    Next

                    For Each rSelListChapterToDelete As qs2.core.vb.dsAdmin.tblSelListEntriesRow In lstChaptersToDelete
                        rSelListChapterToDelete.Delete()
                    Next
                    Me.DsAdmin1.tblSelListEntries.AcceptChanges()
                    Me.gridChapter.Refresh()

                    For Each rGridSelEntry As UltraGridRow In Me.gridChapter.Rows
                        Dim v As DataRowView = rGridSelEntry.ListObject
                        Dim rSelEntry As qs2.core.vb.dsAdmin.tblSelListEntriesRow = v.Row
                        Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, Me.IDParticipant, Me.IDApplication, True, False)
                        If resFound.Trim() = "" Then
                            rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = rSelEntry.IDRessource
                        Else
                            rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = resFound
                        End If
                    Next

                    Me.gridChapter.DisplayLayout.Bands(0).SortedColumns.Clear()
                    Me.gridChapter.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)

                Else
                    Me.gridChapter.Refresh()

                    Me.DsAdmin1.tblCriteria.Rows.Clear()
                    Me.DsAdmin1.tblSelListEntriesObj.Rows.Clear()
                    Me.loadFields(Nothing, False, Me.IDApplication)
                    Me.loadFields(Nothing, False, qs2.core.license.doLicense.eApp.ALL.ToString())
                End If

                Me.setTitleGridChapters(Me.DsAdmin1.tblSelListEntries.Rows.Count)
                Me.gridChapter.Selected.Rows.Clear()
                Me.gridChapter.ActiveRow = Nothing
            End With

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadFields(ByVal rSelListEntry As qs2.core.vb.dsAdmin.tblSelListEntriesRow,
                          ByVal withChapters As Boolean, ByVal IDApplicationToSearch As String)
        Try
            'Me.btnOK.Enabled = False
            Me.rSelListSelChapter2 = rSelListEntry

            If withChapters Then
                Me.DsAdmin1.tblSelListEntriesObj.Clear()
                Me.SqlAdmin1.getSelListEntrysObj(Nothing, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "", Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.allCriterias, IDApplicationToSearch, rSelListEntry.ID)
                'Me.SqlAdmin1.getSelListEntrysObj(Nothing, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "", Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.allCriterias, IDApplicationToSearch, rSelListEntry.ID)

                For Each rSelObj As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow In Me.DsAdmin1.tblSelListEntriesObj
                    Dim arrCriterias() As qs2.core.vb.dsAdmin.tblCriteriaRow = Me.SqlAdmin1.getCriterias(Me.DsAdmin1, core.vb.sqlAdmin.eTypSelCriteria.idRam,
                                                                                                         rSelObj.FldShort, IDApplicationToSearch, False, True,
                                                                                                         Me.chkOnlyShowPreferedFields.Checked, "", "", False)
                    For Each rCrit As qs2.core.vb.dsAdmin.tblCriteriaRow In arrCriterias

                        If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                            If rCrit.UseInQueries And rCrit.Used Then
                                arrCriterias.CopyToDataTable(Me.DsAdmin1.tblCriteria, LoadOption.Upsert)
                            End If
                        Else
                            If rCrit.UseInQueries And rCrit.Used Then
                                arrCriterias.CopyToDataTable(Me.DsAdmin1.tblCriteria, LoadOption.Upsert)
                            End If
                        End If
                    Next
                Next
            Else
                Me.SqlAdmin1.getCriterias(Me.DsAdmin1, core.vb.sqlAdmin.eTypSelCriteria.search, "", IDApplicationToSearch, True, True,
                                          Me.chkOnlyShowPreferedFields.Checked, "", "", False)
            End If

            Dim lstCriteriasToDelete As New System.Collections.Generic.List(Of qs2.core.vb.dsAdmin.tblCriteriaRow)
            Dim b As New qs2.core.vb.businessFramework()
            For Each rCritGridRow As UltraGridRow In Me.gridCriterias.Rows
                Dim v As System.Data.DataRowView = rCritGridRow.ListObject
                Dim rCrit As qs2.core.vb.dsAdmin.tblCriteriaRow = v.Row

                Dim rigthOK As Boolean = b.checkRigthFldShortForRole(rCrit.FldShort.Trim(), qs2.core.vb.actUsr.rUsr.ID, rCrit.IDApplication.Trim(), True)
                If qs2.core.ENV.developModus Then
                    rigthOK = True
                End If
                If Not rigthOK Then
                    lstCriteriasToDelete.Add(rCrit)
                End If

                Dim HasLicenseKey = False
                HasLicenseKey = Me.b.checkLicenseKey(rCrit.FldShort.Trim(), rCrit.IDApplication.Trim(), dsAdminTmp2)
                If qs2.core.ENV.developModus Then
                    HasLicenseKey = True
                End If
                If Not HasLicenseKey Then
                    lstCriteriasToDelete.Add(rCrit)
                End If
            Next
            For Each rCrit As qs2.core.vb.dsAdmin.tblCriteriaRow In lstCriteriasToDelete
                rCrit.Delete()
            Next
            Me.DsAdmin1.tblCriteria.AcceptChanges()
            Me.gridCriterias.Refresh()
            qs2.sitemap.ui.translateCriterias(Me.gridCriterias.Rows, Me.IDParticipant, core.Enums.eResourceType.Label, True, False, "", True)

            Me.gridCriterias.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.gridCriterias.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)

            Me.doSearch(Me.txtSearchCriteria.Text.Trim())
            Me.setTitleGridFields(Me.gridCriterias.Rows.Count)

            Me.gridCriterias.Selected.Rows.Clear()
            Me.gridCriterias.ActiveRow = Nothing

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Public Sub setTitleGridChapters(ByVal count As Integer)
        Me.gridChapter.Text = qs2.core.language.sqlLanguage.getRes("Chapters") + If(count > 0, " [" + qs2.core.language.sqlLanguage.getRes("Found") + ":" + count.ToString() + "]", "")
    End Sub
    Public Sub setTitleGridFields(ByVal count As Integer)
        Me.gridCriterias.Text = qs2.core.language.sqlLanguage.getRes("Fields") + If(count > 0, " [" + qs2.core.language.sqlLanguage.getRes("Found") + ":" + count.ToString() + "]", "")
    End Sub

    Public Function getSelectedRows(ByVal msgBox As Boolean) As System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
        Try
            'If Not Me.gridCriterias.ActiveRow Is Nothing Then
            '    Dim v As DataRowView = Me.gridCriterias.ActiveRow.ListObject
            '    Dim rCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow = v.Row
            '    Me.selrGridCriteria = Me.gridCriterias.ActiveRow
            '    Return rCriteria
            'Else
            '    If msgBox Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            '    Return Nothing
            'End If

            Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
            qs2.core.ui.getSelectedGridRows(Me.gridCriterias, rSelected, True)
            If (rSelected.Count = 0) Then
                'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
            End If
            Return rSelected

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function getActiveRow(ByVal msgBox As Boolean, ByRef activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As qs2.core.vb.dsAdmin.tblCriteriaRow
        Try
            If Not Me.gridCriterias.ActiveRow Is Nothing Then
                If Me.gridCriterias.ActiveRow.IsGroupByRow Or Me.gridCriterias.ActiveRow.IsFilterRow Then
                    If msgBox Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridCriterias.ActiveRow.ListObject
                    Dim rCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow = v.Row
                    activeRow = Me.gridCriterias.ActiveRow
                    Return rCriteria
                End If
            Else
                If msgBox Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
                Return Nothing
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Private Sub griChapter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridChapter.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.ui1.evClickOK(sender, e, Me.gridChapter) Then
                Me.loadFieldsForChapter()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub loadFieldsForChapter()
        Try
            If Not Me.gridChapter.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.gridChapter.ActiveRow.ListObject
                Dim rSelListEntry As qs2.core.vb.dsAdmin.tblSelListEntriesRow = v.Row

                Me.DsAdmin1.tblCriteria.Rows.Clear()
                Me.DsAdmin1.tblSelListEntriesObj.Rows.Clear()
                Me.loadFields(rSelListEntry, True, Me.IDApplication)
                Me.loadFields(rSelListEntry, True, qs2.core.license.doLicense.eApp.ALL.ToString())
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridCriterias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridCriterias.Click
        Try
            'If Me.ui1.evClickOK(sender, e, Me.gridCriterias) Then
            '    Me.doSelectRowCriteria(False)
            'End If
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridCriterias_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridCriterias.DoubleClick
        Try
            If Me.ui1.evDoubleClickOK(sender, e, Me.gridCriterias) Then
                If Not Me.delOnSelection Is Nothing Then Me.delOnSelection.Invoke(False)
                'If Not Me.delOnAddWithoutClosing Is Nothing Then
                '    Me.delOnAddWithoutClosing.Invoke(0, Me.getSelectedRows(False), Me.protocoll, True)
                'End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Function doSelectRows(ByVal msgBox As Boolean) As Boolean
        Try
            Me.selRowsGrid.Clear()
            Me.selRowsGrid = Me.getSelectedRows(msgBox)
            If Me.selRowsGrid.Count > 0 Then
                Return True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Private Sub gridCriterias_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridCriterias.AfterRowActivate

    End Sub
    Private Sub gridCriterias_BeforeRowActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridCriterias.BeforeRowActivate
        Try
            e.Row.Activation = Activation.NoEdit
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub optionSetChaptersYN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optionSetChaptersYN.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.optionSetChaptersYN.Focused Then
                Me.loadChapters(Me.optionSetChaptersYN.Value)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub


    Private Sub txtSearchCriteria_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchCriteria.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.txtSearchCriteria.Focused Then
                Me.doSearch(Me.txtSearchCriteria.Text.Trim())
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub doSearch(ByVal txtToSearch As String)
        Try
            Me.funct1.clearAllFilter(Me.gridCriterias)
            'Me.funct1.clearFilter(Me.DsAuswahllisten1.tblSelListGroup.IDGroupStrColumn, Me.gridGroup)

            If txtToSearch.Trim() <> "" Then

                Me.funct1.setFilter(Me.DsAdmin1.tblCriteria.FldShortColumn.ColumnName,
                                                FilterLogicalOperator.Or, txtToSearch.Trim(),
                                                FilterComparisionOperator.StartsWith, Me.gridCriterias,
                                                Me.gridCriterias.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(qs2.core.generic.columnNameText,
                            FilterLogicalOperator.Or, txtToSearch.Trim(),
                            FilterComparisionOperator.StartsWith, Me.gridCriterias,
                            Me.gridCriterias.DisplayLayout.Bands(0).Index)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Private Sub MarkAsPreferedFieldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkAsPreferedFieldToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doPreferedField(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub MarkNotAsPreferedFieldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkNotAsPreferedFieldToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doPreferedField(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub doPreferedField(ByRef bPrefered As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rSelected As System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow) = Me.getSelectedRows(True)
            If rSelected.Count > 0 Then
                For Each rSelField As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                    Dim v As DataRowView = rSelField.ListObject
                    Dim rCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow = v.Row

                    Dim dsAdminUpdate As New qs2.core.vb.dsAdmin()
                    Dim sqlAdminUpdate As New qs2.core.vb.sqlAdmin()
                    sqlAdminUpdate.initControl()
                    sqlAdminUpdate.getCriterias(dsAdminUpdate, core.vb.sqlAdmin.eTypSelCriteria.id, rCriteria.FldShort,
                                                rCriteria.IDApplication, False, False, False, "", "", False)
                    If dsAdminUpdate.tblCriteria.Rows.Count <> 1 Then
                        Throw New Exception("contSelChaptFldShort.doPreferedField: dsAdminUpdate.tblCriteria.Rows.Count <> 1 !")
                    End If
                    Dim rCriteriaUpdate As qs2.core.vb.dsAdmin.tblCriteriaRow = dsAdminUpdate.tblCriteria.Rows(0)
                    rCriteriaUpdate.prefered = bPrefered
                    sqlAdminUpdate.daCriteria.Update(dsAdminUpdate.tblCriteria)

                    If Me.chkOnlyShowPreferedFields.Checked Then
                        If Not rCriteriaUpdate.prefered Then
                            rSelField.Hidden = True
                        End If
                    End If
                Next

                Dim sqlAdmin1 As New qs2.core.vb.sqlAdmin()
                sqlAdmin1.initControl()
                sqlAdmin1.loadAll(True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub chkOnlyShowPreferedFields_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnlyShowPreferedFields.CheckedChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.chkOnlyShowPreferedFields.Focused Then
                If Me.optionSetChaptersYN.Value = 0 Then
                    Me.loadChapters(Me.optionSetChaptersYN.Value)
                Else
                    Me.loadFieldsForChapter()
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub TranslateToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TranslateToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim actGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow = Me.getActiveRow(True, actGridRow)
            If Not rCriteria Is Nothing Then
                If Me.openTranslate(rCriteria.FldShort, rCriteria.IDApplication, actGridRow.Cells(qs2.core.generic.columnNameText).Value.ToString().Trim()) Then
                    If Me.optionSetChaptersYN.Value = 0 Then
                        Me.loadChapters(Me.optionSetChaptersYN.Value)
                    Else
                        Me.loadFieldsForChapter()
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function openTranslate(IDRes As String, IDApplication As String, defaultText As String) As Boolean
        Try
            Dim frmTranslateText1 As New frmTranslateText()
            frmTranslateText1.IDResToTranslate = IDRes
            frmTranslateText1.Application = IDApplication
            frmTranslateText1.txtTranslationForIDResGerman.Text = defaultText.Trim()
            frmTranslateText1.ShowDialog(Me)
            If Not frmTranslateText1.abort Then
                Return True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Private Sub btnAddPlaceholder_Click(sender As Object, e As EventArgs) Handles btnAddPlaceholder.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.SelectionWithoutClosing Then
                'If Not Me.ContSelChaptFldShort1.delOnAddWithoutClosing Is Nothing Then
                Me.delOnAddWithoutClosing.Invoke(0, Me.getSelectedRows(False), Me.protocoll, Me.add, Nothing, StayTypeToShowChapters, True)
                'End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
