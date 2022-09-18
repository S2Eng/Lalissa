Imports qs2.core.vb
Imports VB = Microsoft.VisualBasic

Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win




Public Class contSelListsChapter

    Public sqlAdmin1 As New qs2.core.vb.sqlAdmin()

    Public dsAdminSelListObj1 As New qs2.core.vb.dsAdmin

    Public rGroupSelected As dsAdmin.tblSelListGroupRow
    Public IDApplication As String = ""
    Public IDParticipant As String = ""
    Public rSelEntry As dsAdmin.tblSelListEntriesRow

    Public clSitemap As New qs2.sitemap.ui()

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Private editable As Boolean = False
    Public funct1 As New qs2.core.vb.funct()

    Public typIDGroup As String = ""

    Public frmMain As frmSelListsChapter = Nothing

    Public _textCaption As String = ""

    Public coliSelection As String = "iSelection"
    Public _showiSelect As Boolean = False









    Private Sub contVermGruppeObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ByVal textCaption As String, showiSelect As Boolean)
        Try
            Me._showiSelect = showiSelect
            Me._textCaption = textCaption.Trim()

            Me.sqlAdmin1.initControl()
            Me.loadRes()

            Me.gridCriterias.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True
            Me.gridCriterias.Text = Me._textCaption

            Me.optChapterStayFollowUp.CheckedIndex = 0

            Me.ContCboSelListChapters.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
            Me.ContCboSelListChapters.IDApplication = Me.IDApplication

            Dim onlyLicensedProducts As Boolean = True
            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                onlyLicensedProducts = False
            End If
            Me.ComboApplication1.initControlxy(True, onlyLicensedProducts, True)
            Me.ComboApplication1.setApplication(Me.IDApplication)

            Me.ContCboSelListChapters.IDApplication = Me.IDApplication
            Me.ContCboSelListChapters.IDGroupStr = Me.optChapterStayFollowUp.Value.ToString()

            Dim dOnValueChanged As New qs2.sitemap.vb.contCboSelList.onValueChanged(AddressOf Me.onValueChangedChapters)
            Me.ContCboSelListChapters.delonValueChanged = dOnValueChanged

            Me.ContCboSelListChapters.initControl(True, False, Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDown)
            Me.ContCboSelListChapters.loadData()

            If actUsr.IsAdminSecureOrSupervisor() Then
                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = True
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = True
                Me.ToolStripMenuItemSpace10.Visible = True
            Else
                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = False
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace10.Visible = False
            End If

            If showiSelect Then
                Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.coliSelection.Trim()).Hidden = False
                Me.gridCriterias.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection.Trim()).Hidden = True
            Else
                Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.coliSelection.Trim()).Hidden = True
                Me.gridCriterias.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection.Trim()).Hidden = False
            End If

            If Me.typIDGroup.Trim() <> "Criterias_Roles" And Me.typIDGroup.Trim() <> "CriteriasUser_Roles" And Me.typIDGroup.Trim() <> "ProcGrp0" And
                Me.typIDGroup.Trim() <> "ProcGrp1" And Me.typIDGroup.Trim() <> "Chapters0" And Me.typIDGroup.Trim() <> "Chapters1" Then

                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = False
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace10.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.FldShortColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("FldShort")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.IDApplicationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Application")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.ControlTypeColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeControl")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.SourceTableColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Table")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.UsedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Used")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.UseInQueriesColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("UseInQueries")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.dsAdminSelListObj1.tblCriteria.UserDefinedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("UserDefined")

            Me.gridCriterias.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Translation")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection).Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection")
            Me.gridCriterias.DisplayLayout.Bands(0).Columns(Me.coliSelection).Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection")

            Me.AllToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectAll")
            Me.SelectNoneToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectNone")

            Me.lblSearch.Text = qs2.core.language.sqlLanguage.getRes("Search")
            Me.lblChapters.Text = qs2.core.language.sqlLanguage.getRes("Chapters")

            Me.optChapterStayFollowUp.Items(0).DisplayText = qs2.core.language.sqlLanguage.getRes("Stay")
            Me.optChapterStayFollowUp.Items(1).DisplayText = qs2.core.language.sqlLanguage.getRes("FollowUp")

            Me.BuildSqlCheckedTrueToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("BuildSqlCheckedTrue")
            Me.BuildSqlCheckedFalseToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("BuildSqlCheckedFalse")

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.loadRes: " + ex.ToString())
        End Try
    End Sub
   
    Public Sub loadData()
        Try
            Me.DsAdmin1.Clear()
            Me.dsAdminSelListObj1.Clear()

            Dim selApp As QS2.core.license.doLicense.eApp = Me.ComboApplication1.getSelectedApplication()
            If selApp <> core.license.doLicense.eApp.ALL Then
                Me.IDApplication = selApp.ToString()
            End If

            Dim ChapterSelected As String = ""
            Dim rSelListChapter As dsAdmin.tblSelListEntriesRow = Me.ContCboSelListChapters.getSelectedSelList(False)
            If Not rSelListChapter Is Nothing Then
                ChapterSelected = rSelListChapter.IDOwnStr
            End If

            'If ChapterSelected.Trim() <> "" Then
            Dim IDGroupStr As String = ""
            IDGroupStr = Me.optChapterStayFollowUp.Value.ToString().Trim()
            'Dim IDApplicationRead As qs2.core.license.doLicense.eApp = qs2.core.generic.searchEnumApplication(Me.IDApplication)
            'Me.sqlAdmin1.getCriterias(Me.DsAdmin1, sqlAdmin.eTypSelCriteria.search, "", "", _
            '                        True, False, False, ChapterSelected.Trim(), IDGroupStr)
            Me.sqlAdmin1.getCriterias(Me.DsAdmin1, sqlAdmin.eTypSelCriteria.search, "", Me.IDApplication, _
                      False, False, False, ChapterSelected.Trim(), IDGroupStr, True)

            Me.gridCriterias.Refresh()

            'Me.sqlAdmin1.getSelListEntrysObj(Nothing, sqlAdmin.eDbTypAuswObj.Criterias, "", Me.dsAdminSelListObj1, sqlAdmin.eTypAuswahlObj.allCriterias, _
            '                             qs2.core.license.doLicense.eApp.ALL.ToString(), Me.rSelEntry.ID, "", -999, "", -999, ChapterSelected.Trim(), IDGroupStr)
            Me.sqlAdmin1.getSelListEntrysObj(Nothing, sqlAdmin.eDbTypAuswObj.Criterias, "", Me.dsAdminSelListObj1, sqlAdmin.eTypAuswahlObj.allCriterias,
                                             Me.IDApplication, Me.rSelEntry.ID, "", -999, "", -999, ChapterSelected.Trim(), IDGroupStr, True, Nothing, "", Me.typIDGroup.Trim())

            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridCriterias.Rows
                Dim v As DataRowView = r.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                Dim arrSelListObjSearch As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow() = Nothing
                arrSelListObjSearch = Me.dsAdminSelListObj1.tblSelListEntriesObj.Select(Me.dsAdminSelListObj1.tblSelListEntriesObj.FldShortColumn.ColumnName + "='" + rCriteria.FldShort + "' ")
                'arrSelListObjSearch = Me.dsAdminSelListObj1.tblSelListEntriesObj.Select(Me.dsAdminSelListObj1.tblSelListEntriesObj.FldShortColumn.ColumnName + "='" + rCriteria.FldShort + "' and " + _
                '                                                    Me.dsAdminSelListObj1.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "='" + rCriteria.IDApplication + "'")

                If arrSelListObjSearch.Length > 0 Then
                    Dim rSelListObj As dsAdmin.tblSelListEntriesObjRow = arrSelListObjSearch(0)
                    If Me._showiSelect Then
                        If rSelListObj.IsnVisibleNull() Then
                            r.Cells(Me.coliSelection.Trim()).Value = System.DBNull.Value
                        Else
                            If rSelListObj.nVisible = 1 Then
                                r.Cells(Me.coliSelection.Trim()).Value = 1
                            ElseIf rSelListObj.nVisible = 0 Then
                                r.Cells(Me.coliSelection.Trim()).Value = 0
                            Else
                                Throw New Exception("contSelListsChapter.loadData: rSelListObj.nVisible '" + rSelListObj.nVisible.ToString() + "' not allowed for Me.typIDGroup '" + Me.typIDGroup.Trim() + "'!")
                            End If
                        End If
                    Else
                        r.Cells(qs2.core.generic.columnNameSelection).Value = True
                    End If
                Else
                    If Me._showiSelect Then
                        r.Cells(Me.coliSelection.Trim()).Value = System.DBNull.Value
                    Else
                        Dim bNotSelected As Boolean = True
                    End If
                End If

                'For Each rObj As dsAdmin.tblSelListEntriesObjRow In Me.dsAdminSelListObj1.tblSelListEntriesObj
                '    If rObj.FldShort == r.Cells(Me.dsAdminSelListObj1.tblCriteria.FldShortColumn.ColumnName).Value Then
                '        r.Cells(qs2.core.generic.columnNameSelection).Value = True
                '    End If
                'Next

                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rCriteria.FldShort, Me.IDParticipant, Me.IDApplication)
                If resFound.Trim() = "" Then
                    r.Cells(qs2.core.generic.columnNameText).Value = rCriteria.FldShort
                Else
                    r.Cells(qs2.core.generic.columnNameText).Value = resFound
                End If
            Next

            Me.gridCriterias.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.gridCriterias.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)

            Me.gridCriterias.Refresh()
            Me.gridCriterias.UpdateData()

            Me.gridCriterias.Selected.Rows.Clear()
            Me.gridCriterias.ActiveRow = Nothing

            'Me.gridVermGruppe.Refresh()
            'Else
            'Me.gridCriterias.Refresh()
            'End If
            Me.setCount()

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Sub setCount()
        Me.gridCriterias.Text = Me._textCaption + " (" + Me.DsAdmin1.tblCriteria.Rows.Count.ToString() + ")"
    End Sub

    Public Sub save()
        Try
            'Dim sqlDelete As String = ""
            'For Each r As dsAdmin.tblSelListEntriesObjRow In Me.dsAdminSelListObj1.tblSelListEntriesObj
            '    qs2.core.dbBase.generateDeleteCommandGuid(qs2.core.dbBase.dbSchema + Me.dsAdminSelListObj1.tblSelListEntriesObj.TableName, _
            '                                          Me.dsAdminSelListObj1.tblSelListEntriesObj.IDGuidColumn.ColumnName, _
            '                                          r.IDGuid.ToString(), sqlDelete)
            'Next
            'If sqlDelete <> "" Then qs2.core.dbBase.executeCommand(sqlDelete)

            'Me.dsAdminSelListObj1.tblSelListEntriesObj.Rows.Clear()
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridCriterias.Rows
                Dim v As DataRowView = r.ListObject
                Dim rCriteria As qs2.core.vb.dsAdmin.tblCriteriaRow = v.Row

                Dim arrSelListObjSearch As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow() = Nothing
                arrSelListObjSearch = Me.dsAdminSelListObj1.tblSelListEntriesObj.Select(Me.dsAdminSelListObj1.tblSelListEntriesObj.FldShortColumn.ColumnName + "='" + rCriteria.FldShort + "' and " + _
                                                                    Me.dsAdminSelListObj1.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "='" + rCriteria.IDApplication + "'")

                If arrSelListObjSearch.Length > 0 Then
                    If Me._showiSelect Then
                        If (Not r.Cells(Me.coliSelection.Trim()).Value Is System.DBNull.Value) AndAlso (r.Cells(Me.coliSelection.Trim()).Value = 1 Or r.Cells(Me.coliSelection.Trim()).Value = 0) Then
                            Dim FirstSaved As Boolean = False
                            For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In arrSelListObjSearch
                                If Not FirstSaved Then
                                    Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.addRow(r, rCriteria, False, rSelListEntriesObj)
                                    If r.Cells(Me.coliSelection.Trim()).Value = 1 Then
                                        rNew.nVisible = 1
                                    ElseIf r.Cells(Me.coliSelection.Trim()).Value = 0 Then
                                        rNew.nVisible = 0
                                    Else
                                        Throw New Exception("contSelListsChapter.save: r.Cells(Me.coliSelection.Trim()).Value  '" + r.Cells(Me.coliSelection.Trim()).Value.ToString() + "' not allowed for Me.typIDGroup '" + Me.typIDGroup.Trim() + "'!")
                                    End If
                                    FirstSaved = True
                                Else
                                    rSelListEntriesObj.Delete()
                                End If
                            Next
                        Else
                            For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In arrSelListObjSearch
                                rSelListEntriesObj.Delete()
                            Next
                        End If
                    Else
                        If r.Cells(qs2.core.generic.columnNameSelection).Value = True Then
                            Dim FirstSaved As Boolean = False
                            For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In arrSelListObjSearch
                                If Not FirstSaved Then
                                    Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.addRow(r, rCriteria, False, rSelListEntriesObj)
                                    FirstSaved = True
                                Else
                                    rSelListEntriesObj.Delete()
                                End If
                            Next
                        Else
                            For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In arrSelListObjSearch
                                rSelListEntriesObj.Delete()
                            Next
                        End If
                    End If
                Else
                    If Me._showiSelect Then
                        If (Not r.Cells(Me.coliSelection.Trim()).Value Is System.DBNull.Value) AndAlso (r.Cells(Me.coliSelection.Trim()).Value = 1 Or r.Cells(Me.coliSelection.Trim()).Value = 0) Then
                            Dim rSelListEntriesObjRow As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Nothing
                            Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.addRow(r, rCriteria, True, rSelListEntriesObjRow)
                            If r.Cells(Me.coliSelection.Trim()).Value = 1 Then
                                rNew.nVisible = 1
                            ElseIf r.Cells(Me.coliSelection.Trim()).Value = 0 Then
                                rNew.nVisible = 0
                            Else
                                Throw New Exception("contSelListsChapter.save: r.Cells(Me.coliSelection.Trim()).Value  '" + r.Cells(Me.coliSelection.Trim()).Value.ToString() + "' not allowed for Me.typIDGroup '" + Me.typIDGroup.Trim() + "'!")
                            End If
                        End If
                    Else
                        If r.Cells(qs2.core.generic.columnNameSelection).Value = True Then
                            Dim rSelListEntriesObjRow As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Nothing
                            Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.addRow(r, rCriteria, True, rSelListEntriesObjRow)
                        End If
                    End If
                End If
            Next

            Me.sqlAdmin1.daSelListEntrysObj.Update(Me.dsAdminSelListObj1.tblSelListEntriesObj)

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.save: " + ex.ToString())
        End Try
    End Sub
    Public Function addRow(ByVal r As Infragistics.Win.UltraWinGrid.UltraGridRow, _
                            ByVal rCrit As qs2.core.vb.dsAdmin.tblCriteriaRow, IsNew As Boolean, _
                            ByRef rSelListEntriesObjRow As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow) As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow
        Try
            If IsNew Then
                rSelListEntriesObjRow = Me.sqlAdmin1.getNewRowSelListObj(Me.dsAdminSelListObj1)
            End If

            rSelListEntriesObjRow.typIDGroup = Me.typIDGroup
            rSelListEntriesObjRow.IDSelListEntry = Me.rSelEntry.ID
            rSelListEntriesObjRow.FldShort = rCrit.FldShort
            rSelListEntriesObjRow.IDApplication = rCrit.IDApplication
            rSelListEntriesObjRow.Description = ""
            rSelListEntriesObjRow.IDClassification = ""
            rSelListEntriesObjRow.Sort = 0
            If Me._showiSelect Then
                rSelListEntriesObjRow.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
            Else
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    rSelListEntriesObjRow.IDParticipant = ""
                Else
                    If rSelListEntriesObjRow.typIDGroup.Trim().ToLower().Equals(("Criterias_Roles").Trim().ToLower()) Then
                        rSelListEntriesObjRow.IDParticipant = ""
                    Else
                        rSelListEntriesObjRow.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                    End If
                End If
            End If
            rSelListEntriesObjRow.SetIDOwnIntNull()

            Return rSelListEntriesObjRow

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.addRow: " + ex.ToString())
        End Try
    End Function

    Private Sub gridVermGruppe_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridCriterias.CellChange
        Me.gridCriterias.UpdateData()
        If Not delonValueChanged Is Nothing Then delonValueChanged.Invoke()
    End Sub

    Private Sub gridVermGruppe_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridCriterias.BeforeCellActivate

        If Not Me.editable Then
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Else
            If e.Cell.Column.ToString() = qs2.core.generic.columnNameSelection Or e.Cell.Column.ToString() = Me.coliSelection.Trim() Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
        End If

    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.editable = bEdit
            If Me.editable Then
                Me.gridCriterias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.gridCriterias.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsAdmin.tblCriteriaRow
        Try
            If Not Me.gridCriterias.ActiveRow Is Nothing Then
                If Me.gridCriterias.ActiveRow.IsGroupByRow Or Me.gridCriterias.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    Dim v As DataRowView = Me.gridCriterias.ActiveRow.ListObject
                    Dim rSelObj As dsAdmin.tblCriteriaRow = v.Row
                    selRowGrid = Me.gridCriterias.ActiveRow
                    Return rSelObj
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Public Sub selectAll(ByVal selectYN As Boolean)
        Try
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridCriterias.Rows
                Dim v As DataRowView = r.ListObject
                Dim rCriteria As dsAdmin.tblCriteriaRow = v.Row

                If Me._showiSelect Then
                    If selectYN Then
                        r.Cells(Me.coliSelection.Trim()).Value = 1
                    Else
                        r.Cells(Me.coliSelection.Trim()).Value = 0
                    End If
                Else
                    r.Cells(qs2.core.generic.columnNameSelection).Value = selectYN
                End If
            Next
            If Not delonValueChanged Is Nothing Then delonValueChanged.Invoke()

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.selectAll: " + ex.ToString())
        End Try
    End Sub

    Private Sub AllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.selectAll(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub SelectNoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.selectAll(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub lblSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSearch.Click

    End Sub
    Private Sub txtSearchText_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.txtSearchText.Focused Then
                Me.doSearch()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub doSearch()
        Try
            Me.funct1.clearAllFilter(Me.gridCriterias)
            'Me.funct1.clearFilter(Me.DsAuswahllisten1.tblSelListGroup.IDGroupStrColumn, Me.gridGroup)

            If Me.txtSearchText.Text.Trim() <> "" Then

                Me.funct1.setFilter(Me.DsAdmin1.tblCriteria.FldShortColumn.ColumnName, _
                                                FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(), _
                                                FilterComparisionOperator.StartsWith, Me.gridCriterias, _
                                                Me.gridCriterias.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(qs2.core.generic.columnNameText, _
                            FilterLogicalOperator.Or, Me.txtSearchText.Text.Trim(), _
                            FilterComparisionOperator.StartsWith, Me.gridCriterias, _
                            Me.gridCriterias.DisplayLayout.Bands(0).Index)
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsChapter.doSearch: " + ex.ToString())
        End Try
    End Sub

    Private Sub ComboApplication1_evOnChange(selectedApplication As String) Handles ComboApplication1.evOnChange
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.IDApplication = selectedApplication
            Me.ContCboSelListChapters.IDApplication = Me.IDApplication
            Me.frmMain.IDApplication = Me.IDApplication
            Me.frmMain.setTitle()
            Me.ContCboSelListChapters.IDGroupStr = Me.optChapterStayFollowUp.Value.ToString()
            Me.ContCboSelListChapters.loadData()

            Me.ContCboSelListChapters.clearSelection()

            Me.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub optChapterStayFollowUp_ValueChanged(sender As Object, e As EventArgs) Handles optChapterStayFollowUp.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.optChapterStayFollowUp.Focused Then

                'Me.ContCboSelListChapters.IDApplication = Me.ComboApplication1.getSelectedApplication().ToString()
                Me.ContCboSelListChapters.IDGroupStr = Me.optChapterStayFollowUp.Value.ToString()
                Me.ContCboSelListChapters.loadData()

                Me.ContCboSelListChapters.clearSelection()

                Me.loadData()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub onValueChangedChapters()
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.loadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub BuildSqlCheckedTrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildSqlCheckedTrueToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selApp As qs2.core.license.doLicense.eApp = Me.ComboApplication1.getSelectedApplication()
            If selApp <> core.license.doLicense.eApp.ALL Then
                'Dim ChapterSelected As String = ""
                'Dim rSelListChapter As dsAdmin.tblSelListEntriesRow = Me.ContCboSelListChapters.getSelectedSelList(False)
                'If Not rSelListChapter Is Nothing Then
                Dim gridRow As UltraGridRow = Nothing
                Dim rCriteriaSel As dsAdmin.tblCriteriaRow = Me.getSelectedRow(True, gridRow)
                If Not rCriteriaSel Is Nothing Then
                    Dim b As New businessFramework()
                    b.buildSqlCheckedUncheckedRole(True, rCriteriaSel.FldShort.Trim(), rCriteriaSel.IDApplication.Trim(), Me.rSelEntry.ID.ToString(),
                                                   Me.typIDGroup.Trim(), "", rCriteriaSel)
                End If
                'End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub BuildSqlCheckedFalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildSqlCheckedFalseToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selApp As qs2.core.license.doLicense.eApp = Me.ComboApplication1.getSelectedApplication()
            If selApp <> core.license.doLicense.eApp.ALL Then
                'Dim ChapterSelected As String = ""
                'Dim rSelListChapter As dsAdmin.tblSelListEntriesRow = Me.ContCboSelListChapters.getSelectedSelList(False)
                'If Not rSelListChapter Is Nothing Then
                Dim gridRow As UltraGridRow = Nothing
                Dim rCriteriaSel As dsAdmin.tblCriteriaRow = Me.getSelectedRow(True, gridRow)
                If Not rCriteriaSel Is Nothing Then
                    Dim b As New businessFramework()
                    b.buildSqlCheckedUncheckedRole(False, rCriteriaSel.FldShort.Trim(), rCriteriaSel.IDApplication.Trim(), Me.rSelEntry.ID.ToString(),
                                                   Me.typIDGroup.Trim(), "", rCriteriaSel)
                End If
                'End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
