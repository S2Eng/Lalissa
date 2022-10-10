Imports qs2.core.vb
Imports VB = Microsoft.VisualBasic
Imports Infragistics.Win.UltraWinGrid




Public Class contSelListsObj

    Public sqlAdmin1 As New qs2.core.vb.sqlAdmin()

    Public dsAuswahllistenObj As New qs2.core.vb.dsAdmin
    Public arrAuswahlObj As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow()

    Public _idObject_IDSelListEntrySublist_IDStay As Integer = -999
    Public _IDSelListEntry As Integer = -999
    Public _IDSelListEntrySublist As Integer = -999
    Public _IDParticipantStay As String = qs2.core.license.doLicense.eApp.ALL.ToString()
    Public _IDApplicationStay As String = ""
    Public typDB As qs2.core.vb.sqlAdmin.eDbTypAuswObj
    Public grpToLoad As String

    Public SubListObjToLoad As String = ""
    Public SubListObjToLoad2 As String = ""
    Public SubListObjToLoad3 As String = ""
    Public SubListObjToLoad4 As String = ""

    Private _IDApplication As String = ""
    Private _IDParticipantAll As String = ""


    Public typ As New eTyp
    Public Enum eTyp
        savedForObject = 0
        saveForSelList = 1
        saveForStay = 2
    End Enum

    Public _typUI As New eTypUI()
    Public Enum eTypUI
        normal = 0
        Procedures = 1
        GroupSelection = 2
        Roles = 3
        SaveSubQueries = 4
    End Enum

    Public clSitemap As New qs2.sitemap.ui()

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged(IDSelList As Integer, bOn As Boolean, ByRef ColumnNameClicked As String)

    Private editable As Boolean = False
    Public TypeStr As String = ""
    Private _showComboApplications As Boolean = False

    Public mainWindow As frmSelListsObj = Nothing
    Private _textCaption As String = ""
    Private _captionVisible As Infragistics.Win.DefaultableBoolean = Infragistics.Win.DefaultableBoolean.True

    Public _dsAdminSub As dsAdmin = Nothing

    Public IDApplicationToAssignForSublists As String = ""
    Public IDParticipantToAssignForSublists As String = ""

    Public protToSave As String = ""

    Public colEditableWhenCompleted As String = "EditableWhenCompleted"
    Public _gridExpandAll As Boolean = False

    Public hideComboApplications As Boolean = False









    Private Sub contVermGruppeObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Public Sub initControl(ByVal captionVisible As Infragistics.Win.DefaultableBoolean, ByVal textCaption As String,
                        ByVal showColumnIDDescription As Boolean, ByVal showColumnID As Boolean, ByVal lstClassification As System.Collections.ArrayList,
                        ByVal AutoFitStyle As Infragistics.Win.UltraWinGrid.AutoFitStyle,
                        ByVal typUI As eTypUI, showComboApplications As Boolean, IDApplication As String, IDParticipant As String)
        Try
            Me._typUI = typUI
            Me._showComboApplications = showComboApplications
            Me._IDApplication = IDApplication
            Me._IDParticipantAll = IDParticipant
            Me._captionVisible = captionVisible
            Me._textCaption = textCaption

            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.gridSelListObj.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection).Hidden = False
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False

            Me.lblGroup.Text = qs2.core.language.sqlLanguage.getRes("Group")

            Me.sqlAdmin1.initControl()
            Me.loadRes(lstClassification, AutoFitStyle)

            Me.gridSelListObj.DisplayLayout.CaptionVisible = captionVisible
            Me.setTitleGrid()

            Me.BuildSqlCheckedTrueToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("BuildSqlCheckedTrue")
            Me.BuildSqlCheckedFalseToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("BuildSqlCheckedFalse")

            Me.ContCboGroup1.initControl(contCboGroup.eTyp.SelListUsr)
            If Me._typUI = eTypUI.normal Then
                Me.PanelOben.Visible = False
                Me.AssignCriteriaToolStripMenuItem.Visible = False
                Me.AssignCriteriaCustomerToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace01.Visible = False

            ElseIf Me._typUI = eTypUI.SaveSubQueries Then
                Me.PanelOben.Visible = False
                Me.AssignCriteriaToolStripMenuItem.Visible = False
                Me.AssignCriteriaCustomerToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace01.Visible = False
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.tblSelListEntries.SubQueryColumn.ColumnName).Hidden = False

            ElseIf Me._typUI = eTypUI.Procedures Then
                Me.PanelOben.Visible = False
                Me.AssignCriteriaToolStripMenuItem.Visible = False
                Me.AssignCriteriaCustomerToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace01.Visible = False
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.tblSelListEntries.IsMainColumn.ColumnName).Hidden = False
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText.Trim()).Width = 500

            ElseIf Me._typUI = eTypUI.GroupSelection Then
                Me.PanelOben.Visible = True
                Me.AssignCriteriaToolStripMenuItem.Visible = False
                Me.AssignCriteriaCustomerToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace01.Visible = False
                Me.ContCboGroup1.IDApplication = Me._IDApplication
                Me.ContCboGroup1.IDParticipant = Me._IDParticipantAll
                Me.ContCboGroup1.loadGroups()
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnActive).Hidden = False

            ElseIf Me._typUI = eTypUI.Roles Then
                Me.PanelOben.Visible = False
                Me.AssignCriteriaToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor()
                Me.AssignCriteriaCustomerToolStripMenuItem.Visible = qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.vb.actUsr.rUsr.isAdmin
                Me.ToolStripMenuItemSpace01.Visible = True
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnActive).Hidden = False

            End If

            If showComboApplications Then
                Me.PanelOben.Visible = True
                Me.ComboApplication.Visible = True
                Me.lblApplication.Visible = True
                Dim onlyLicensedProducts As Boolean = True
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    onlyLicensedProducts = False
                End If
                Me.ComboApplication.initControlxy(True, onlyLicensedProducts, True)
                Me.ComboApplication.cboApplications.Value = Me._IDApplication
            Else
                Me.ComboApplication.Visible = False
                Me.lblApplication.Visible = False
            End If

            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.IDRessourceColumn.ColumnName).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.IDColumn.ColumnName).Hidden = Not showColumnID
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.DescriptionColumn.ColumnName).Hidden = Not showColumnIDDescription

            For Each itmClassification In lstClassification
                Me.gridSelListObj.DisplayLayout.ValueLists(qs2.core.generic.columnNameClassification).ValueListItems.Add(itmClassification, qs2.core.language.sqlLanguage.getRes(itmClassification))
            Next

            If actUsr.IsAdminSecureOrSupervisor() Then
                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = True
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = True
                Me.ToolStripMenuItemSpace10.Visible = True
            Else
                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = False
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace10.Visible = False
            End If

            If Me.grpToLoad.Trim() <> "Right" And Me.grpToLoad.Trim() <> "ProcGrp0" And
                Me.grpToLoad.Trim() <> "ProcGrp1" And Me.grpToLoad.Trim() <> "Chapters0" And Me.grpToLoad.Trim() <> "Chapters1" Then

                Me.BuildSqlCheckedTrueToolStripMenuItem.Visible = False
                Me.BuildSqlCheckedFalseToolStripMenuItem.Visible = False
                Me.ToolStripMenuItemSpace10.Visible = False
            End If

            If Me.hideComboApplications Then
                Me.ComboApplication.Visible = False
                Me.lblApplication.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub setTitleGrid()
        If Me._captionVisible = Infragistics.Win.DefaultableBoolean.True Then
            Dim sTranlatedTitle As String = qs2.core.language.sqlLanguage.getRes(Me._textCaption, Me._IDParticipantAll, Me._IDApplication, True)
            If sTranlatedTitle.Trim() = "" Then
                Me.gridSelListObj.Text = Me._textCaption
            Else
                Me.gridSelListObj.Text = sTranlatedTitle
            End If
        End If
    End Sub

    Public Sub loadRes(ByVal lstClassification As System.Collections.ArrayList, ByVal AutoFitStyle As Infragistics.Win.UltraWinGrid.AutoFitStyle)
        Try
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("To")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Of")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.IDColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Nr")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.DescriptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Description")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnActive).Header.Caption = qs2.core.language.sqlLanguage.getRes("Active")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.dsAuswahllistenObj.tblSelListEntries.IsMainColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IsMain")

            Me.gridSelListObj.DisplayLayout.AutoFitStyle = AutoFitStyle

            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Entry")
            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameIDKey).Header.Caption = qs2.core.language.sqlLanguage.getRes("OwnKeyInt")

            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameClassification).Header.Caption = qs2.core.language.sqlLanguage.getRes("Classification")
            If lstClassification.Count > 0 Then
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameClassification).Hidden = False
            Else
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameClassification).Hidden = True
            End If

            Me.gridSelListObj.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection).Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection")

            Me.SelectAllToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectAll")
            Me.SelectNoneToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectNone")
            Me.AssignCriteriaToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("AssignCriterias")
            Me.AssignCriteriaToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)
            Me.AssignCriteriaCustomerToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("AssignCriteriasCustomer")
            Me.AssignCriteriaCustomerToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_selLists, 32, 32)
            Me.OpenSelListToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("OpenSelList")

            Me.lblApplication.Text = qs2.core.language.sqlLanguage.getRes("Application")

            Dim ToolTipInfo As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            Me.btnReload.OwnTooltipText = qs2.core.language.sqlLanguage.getRes("Reload")

        Catch ex As Exception
            Throw New Exception("contSelListsObj.loadRes: " + ex.ToString())
        End Try
    End Sub

    Public Sub reloadData()
        Try
            Me.loadData(Me._idObject_IDSelListEntrySublist_IDStay, Me._dsAdminSub, Me._IDParticipantStay, Me._IDApplicationStay,
                        Me._IDSelListEntry, Me._IDSelListEntrySublist, Me._gridExpandAll)
            Me.setTitleGrid()
            If Not Me.mainWindow Is Nothing Then
                Me.mainWindow.setTitle(Me._IDApplication, Me._IDParticipantAll, Me.mainWindow._IDRessourceForSave)
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.reloadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData(ByVal idObject_IDSelListEntrySublist_IDStay As Integer, ByVal dsAdminSub As dsAdmin,
                        ByVal IDParticipantStay As String, ByVal IDApplicationStay As String,
                        ByVal IDSelListEntry As Integer, ByVal IDSelListEntrySublist As Integer, gridExpandAll As Boolean)
        Try
            Me._idObject_IDSelListEntrySublist_IDStay = idObject_IDSelListEntrySublist_IDStay
            Me._IDSelListEntry = IDSelListEntry
            Me._IDSelListEntrySublist = IDSelListEntrySublist
            Me._dsAdminSub = dsAdminSub
            Me.DsAuswahllisten1.Clear()
            Me.dsAuswahllistenObj.Clear()
            Me._IDParticipantStay = IDParticipantStay
            Me._IDApplicationStay = IDApplicationStay
            Me.protToSave = ""
            Me._gridExpandAll = gridExpandAll

            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            If Me.TypeStr.Trim() = "" Then
                Try

                    Select Case Me.grpToLoad
                        Case "Queries"
                            Parameters.doExecptIfNotFound = False
                            Me.sqlAdmin1.getSelListEntrysAll(Parameters, Me.grpToLoad, Me.DsAuswahllisten1, qs2.core.vb.sqlAdmin.eTypAuswahlList.group,
                                                     Me._IDParticipantAll, Me._IDApplication)
                        Case Else
                            Parameters.doExecptIfNotFound = False
                            Me.sqlAdmin1.getSelListEntrysAll(Parameters, Me.grpToLoad, Me.DsAuswahllisten1, qs2.core.vb.sqlAdmin.eTypAuswahlList.groupParticipantOwnOrAll,
                                                     Me._IDParticipantAll, Me._IDApplication)
                    End Select

                Catch ex As Exception
                    qs2.core.generic.getExep(ex.ToString(), ex.Message)
                End Try

                If Parameters.GroupNotFoundInAnyApplication Then
                    Dim sTxt As String = System.String.Format(qs2.core.language.sqlLanguage.getRes("GroupXNotFound"), Me.grpToLoad)
                    qs2.core.generic.showMessageBox(sTxt + "!", Windows.Forms.MessageBoxButtons.OK, "")
                End If

                If Me._IDApplication.Trim().ToLower() <> Parameters.rGrpFound.IDApplication.Trim().ToLower() Then
                    Dim sTxt As String = System.String.Format(qs2.core.language.sqlLanguage.getRes("ForSelectedApplicationXNoGroupXFound"), qs2.core.language.sqlLanguage.getRes(Me._IDApplication), Me.grpToLoad)
                    qs2.core.generic.showMessageBox(sTxt + "!", Windows.Forms.MessageBoxButtons.OK, "")
                    Me._IDApplication = Parameters.rGrpFound.IDApplication
                    Me.ComboApplication.cboApplications.Value = Parameters.rGrpFound.IDApplication
                End If
            Else
                Try
                    Me.sqlAdmin1.getSelListEntrysAll(Parameters, Me.grpToLoad, Me.DsAuswahllisten1, qs2.core.vb.sqlAdmin.eTypAuswahlList.groupTypStr, Me._IDParticipantAll, Me._IDApplication, Me.TypeStr)
                Catch ex As Exception
                    qs2.core.generic.getExep(ex.ToString(), ex.Message)
                End Try
            End If

            Me.gridSelListObj.Refresh()
            If gridExpandAll Then
                Me.gridSelListObj.Rows.ExpandAll(True)
            End If

            If Me._typUI = eTypUI.Procedures Then
                For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                    Dim bFound As Boolean = False
                    Dim v As DataRowView = rGrid.ListObject
                    Dim rSelEntryGrid As dsAdmin.tblSelListEntriesRow = v.Row
                    For Each rSelListObj As dsAdmin.tblSelListEntriesObjRow In Me._dsAdminSub.tblSelListEntriesObj
                        If rSelListObj.IDSelListEntry.Equals(rSelEntryGrid.ID) Then
                            bFound = True
                        End If
                    Next
                    If Not bFound Then
                        rGrid.Hidden = True
                        'rSelEntryGrid.Delete()
                        'Me.gridSelListObj.Refresh()
                    End If
                Next
            End If

            Me.arrAuswahlObj = Nothing
            If Me.typ = eTyp.savedForObject Then
                Me.sqlAdmin1.getSelListEntrysObj(Me._idObject_IDSelListEntrySublist_IDStay, Me.typDB, "NONE", Me.dsAuswahllistenObj, sqlAdmin.eTypAuswahlObj.obj, core.license.doLicense.eApp.ALL.ToString())
                Me.arrAuswahlObj = Me.dsAuswahllistenObj.tblSelListEntriesObj.Select(Me.dsAuswahllistenObj.tblSelListEntriesObj.IDObjectColumn.ColumnName + "=" + Me._idObject_IDSelListEntrySublist_IDStay.ToString() + " and " +
                                                                                    Me.dsAuswahllistenObj.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='" + Me.typDB.ToString() + "'")

            ElseIf Me.typ = eTyp.saveForSelList Then
                Me.sqlAdmin1.getSelListEntrysObj(Me._idObject_IDSelListEntrySublist_IDStay, sqlAdmin.eDbTypAuswObj.SubSelList, Me.grpToLoad, Me.dsAuswahllistenObj, sqlAdmin.eTypAuswahlObj.sellist, core.license.doLicense.eApp.ALL.ToString())
                Me.arrAuswahlObj = Me.dsAuswahllistenObj.tblSelListEntriesObj.Select(Me.dsAuswahllistenObj.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName + "=" + Me._idObject_IDSelListEntrySublist_IDStay.ToString() + " and " +
                                                                                    Me.dsAuswahllistenObj.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='" + Me.grpToLoad.ToString() + "'")

            ElseIf Me.typ = eTyp.saveForStay Then
                Me.sqlAdmin1.getSelListEntrysObj(-999, sqlAdmin.eDbTypAuswObj.SubSelList, Me.typDB.ToString(), Me.dsAuswahllistenObj,
                                                 sqlAdmin.eTypAuswahlObj.IDSelListEntrySubListIDStayTypIDGroup, Me._IDApplicationStay,
                                                  Me._IDSelListEntry, "", Me._idObject_IDSelListEntrySublist_IDStay, Me._IDParticipantStay, Me._IDSelListEntrySublist)
                Me.arrAuswahlObj = Me.dsAuswahllistenObj.tblSelListEntriesObj.Select("", "")

            End If

            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Value = System.DBNull.Value
                r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Value = System.DBNull.Value

                r.Cells(qs2.core.generic.columnNameClassification).Value = ""
                r.Cells(qs2.core.generic.columnNameIDKey).Value = System.DBNull.Value

                r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.SortColumn.ColumnName).Value = 0
                r.Cells(qs2.core.generic.columnActive).Value = False
                r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.IsMainColumn.ColumnName).Value = False

                Dim v As DataRowView = r.ListObject
                Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, Me._IDParticipantAll, Me._IDApplication)
                If resFound.Trim() = "" Then
                    r.Cells(qs2.core.generic.columnNameText).Value = rSelEntry.IDRessource
                Else
                    r.Cells(qs2.core.generic.columnNameText).Value = resFound
                End If

                r.Cells(Me.colEditableWhenCompleted).Value = False
            Next

            For Each rObj As dsAdmin.tblSelListEntriesObjRow In Me.arrAuswahlObj
                For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                    If rObj.IDSelListEntry.Equals(r.Cells(Me.dsAuswahllistenObj.tblSelListEntries.IDColumn.ColumnName).Value) Then

                        r.Cells(qs2.core.generic.columnNameSelection).Value = True
                        r.Cells(qs2.core.generic.columnNameClassification).Value = rObj.IDClassification
                        r.Cells(qs2.core.generic.columnActive).Value = rObj.Active
                        r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.IsMainColumn.ColumnName).Value = rObj.IsMain

                        If Not rObj.IsIDOwnIntNull() Then
                            r.Cells(qs2.core.generic.columnNameIDKey).Value = rObj.IDOwnInt
                        End If

                        r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.SortColumn.ColumnName).Value = rObj.Sort
                        If rObj.IsFromNull() Then
                            r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Value = System.DBNull.Value
                        Else
                            r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Value = rObj.From
                        End If
                        If rObj.Is_ToNull() Then
                            r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Value = System.DBNull.Value
                        Else
                            r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Value = rObj._To
                        End If

                        If rObj.IDClassification.Trim().ToLower().Contains(sqlAdmin.IDClassificationChapterAlwaysEditable.Trim().Trim().ToLower()) Then
                            r.Cells(Me.colEditableWhenCompleted).Value = True
                        Else
                            r.Cells(Me.colEditableWhenCompleted).Value = False
                        End If
                    End If
                Next
            Next

            Me.gridSelListObj.Selected.Rows.Clear()
            Me.gridSelListObj.ActiveRow = Nothing

            Me.gridSelListObj.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.gridSelListObj.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)
            'Me.gridVermGruppe.Refresh()

            If Me.typ = eTyp.saveForSelList And Me.grpToLoad.Trim().ToLower().Equals(("CHAPTERS0").Trim().ToLower()) Then
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.colEditableWhenCompleted).Hidden = False
            Else
                Me.gridSelListObj.DisplayLayout.Bands(0).Columns(Me.colEditableWhenCompleted).Hidden = True
            End If

            If Not Me.mainWindow Is Nothing Then
                Me.mainWindow.btnSave2.Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub save(ByVal idObject_IDSelListEntrySublist_IDStay As Integer)
        Try
            Dim sqlDelete As String = ""
            Me._idObject_IDSelListEntrySublist_IDStay = idObject_IDSelListEntrySublist_IDStay
            If Not Me.arrAuswahlObj Is Nothing Then
                For Each rSelListObj As dsAdmin.tblSelListEntriesObjRow In Me.arrAuswahlObj
                    Dim bDelete As Boolean = False
                    'If Not r.IsIDApplicationNull() Then
                    '    If r.IDApplication.Trim().ToLower() = Me._IDApplication.Trim().ToLower() Then
                    '        bDelete = True
                    '    End If
                    'Else
                    '    bDelete = True
                    'End If
                    'If bDelete Then
                    'rSelListObj.IDSelListEntry
                    'Dim rSelListFound As dsAdmin.tblSelListEntriesRow = Me.sqlAdmin1.getSelListEntrysRow(Me.grpToLoad, sqlAdmin.eTypAuswahlList.id, "", -999, "", rSelListObj.IDSelListEntry)
                    For Each gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                        Dim v As DataRowView = gridRow.ListObject
                        Dim rSelListGrid As dsAdmin.tblSelListEntriesRow = v.Row
                        If rSelListObj.RowState <> DataRowState.Detached Then
                            If rSelListGrid.ID.Equals(rSelListObj.IDSelListEntry) Then
                                bDelete = True
                                Exit For
                            End If
                        Else
                            Dim str As String = ""
                        End If
                    Next
                    If bDelete Then
                        qs2.core.dbBase.generateDeleteCommandGuid(qs2.core.dbBase.dbSchema + Me.dsAuswahllistenObj.tblSelListEntriesObj.TableName,
                                          Me.dsAuswahllistenObj.tblSelListEntriesObj.IDGuidColumn.ColumnName,
                                          rSelListObj.IDGuid.ToString(), sqlDelete)
                    End If
                Next
            End If
            If sqlDelete <> "" Then qs2.core.dbBase.executeCommand(sqlDelete)

            Me.dsAuswahllistenObj.tblSelListEntriesObj.Rows.Clear()
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                If r.Cells(qs2.core.generic.columnNameSelection).Value = True Then
                    Dim v As DataRowView = r.ListObject
                    Dim rDs As qs2.core.vb.dsAdmin.tblSelListEntriesRow = v.Row
                    Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.addRow(r, rDs)
                End If
            Next

            Me.sqlAdmin1.daSelListEntrysObj.Update(Me.dsAuswahllistenObj.tblSelListEntriesObj)

        Catch ex As Exception
            Throw New Exception("contSelListsObj.save: " + ex.ToString())
        End Try
    End Sub
    Public Sub rejectChangesxy()
        Try
            For Each r As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow In Me.arrAuswahlObj
                r.RejectChanges()
            Next

        Catch ex As Exception
            Throw New Exception("contSelListsObj.rejectChanges: " + ex.ToString())
        End Try
    End Sub
    Public Function addRow(ByVal r As Infragistics.Win.UltraWinGrid.UltraGridRow,
                           ByVal rDs As qs2.core.vb.dsAdmin.tblSelListEntriesRow) As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow
        Try
            Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.sqlAdmin1.getNewRowSelListObj(Me.dsAuswahllistenObj)
            If Me.typ = eTyp.savedForObject Then
                rNew.typIDGroup = Me.typDB.ToString()
                rNew.IDObject = Me._idObject_IDSelListEntrySublist_IDStay
                rNew.SetIDSelListEntrySublistNull()
                rNew.SetFldShortNull()
                rNew.SetIDApplicationNull()

            ElseIf Me.typ = eTyp.saveForSelList Then
                rNew.typIDGroup = Me.grpToLoad.ToString()
                rNew.IDSelListEntrySublist = Me._idObject_IDSelListEntrySublist_IDStay
                rNew.SetIDObjectNull()
                rNew.SetFldShortNull()
                rNew.SetIDApplicationNull()

            ElseIf Me.typ = eTyp.saveForStay Then
                rNew.typIDGroup = Me.typDB.ToString()
                rNew.IDStay = Me._idObject_IDSelListEntrySublist_IDStay
                rNew.IDParticipantStay = Me._IDParticipantStay
                rNew.IDApplicationStay = Me._IDApplicationStay
                rNew.IDSelListEntrySublist = Me._IDSelListEntrySublist
                rNew.SetIDObjectNull()

            End If

            rNew.IDSelListEntry = rDs.ID
            rNew.Description = ""
            rNew.Active = r.Cells(qs2.core.generic.columnActive).Value
            rNew.IsMain = r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.IsMainColumn.ColumnName).Value

            If r.Cells(qs2.core.generic.columnNameClassification).Value Is System.DBNull.Value Then
                rNew.IDClassification = ""
            Else
                rNew.IDClassification = r.Cells(qs2.core.generic.columnNameClassification).Value
            End If
            If r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.SortColumn.ColumnName).Value Is System.DBNull.Value Then
                rNew.Sort = 0
            Else
                rNew.Sort = r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.SortColumn.ColumnName).Value
            End If

            If r.Cells(qs2.core.generic.columnNameIDKey).Value Is System.DBNull.Value Then
                rNew.SetIDOwnIntNull()
            Else
                rNew.IDOwnInt = r.Cells(qs2.core.generic.columnNameIDKey).Value
            End If

            If r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Value Is System.DBNull.Value Then
                rNew.SetFromNull()
            Else
                rNew.From = r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName).Value
            End If
            If r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Value Is System.DBNull.Value Then
                rNew.Set_ToNull()
            Else
                rNew._To = r.Cells(Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName).Value
            End If

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() And qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev Then
                rNew.IDParticipant = ""
            Else
                rNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
            End If

            If Me.typ = eTyp.saveForSelList And Me.grpToLoad.Trim().ToLower().Equals(("CHAPTERS0").Trim().ToLower()) Then
                If r.Cells(Me.colEditableWhenCompleted).Value = True Then
                    If Not rNew.IDClassification.Trim().ToLower().Contains((sqlAdmin.IDClassificationChapterAlwaysEditable.Trim()).ToLower()) Then
                        rNew.IDClassification += sqlAdmin.IDClassificationChapterAlwaysEditable.Trim()
                    End If
                ElseIf r.Cells(Me.colEditableWhenCompleted).Value = False Then
                    If rNew.IDClassification.Trim().ToLower().Contains((sqlAdmin.IDClassificationChapterAlwaysEditable.Trim()).ToLower()) Then
                        rNew.IDClassification = rNew.IDClassification.Replace(sqlAdmin.IDClassificationChapterAlwaysEditable.Trim(), "")
                    End If
                End If
            End If

            Return rNew

        Catch ex As Exception
            Throw New Exception("contSelListsObj.addRow: " + ex.ToString())
        End Try
    End Function
    Public Sub resizeControl(ByVal w As Double, ByVal h As Double)
        Me.Width = w
        Me.Height = h
    End Sub

    Public Sub doChange(resetAll As Boolean, IDSelListEntryToKeep As Integer, bOn As Boolean, ByRef ColumnNameClicked As String)
        If Me._typUI = eTypUI.Procedures Then
            Me.resetDropDownProcGroupsMain(resetAll, IDSelListEntryToKeep, ColumnNameClicked)
        End If
        If Not Me.delonValueChanged Is Nothing Then
            Me.delonValueChanged.Invoke(IDSelListEntryToKeep, bOn, ColumnNameClicked)
        End If
    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.editable = bEdit
            If Me.editable Then
                Me.gridSelListObj.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.gridSelListObj.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

            If Me.editable Then
                Me.gridSelListObj.ContextMenuStrip = Me.ContextMenuStrip1
            Else
                Me.gridSelListObj.ContextMenuStrip = Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
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
    Public Sub selectAll(ByVal Yes As Boolean)
        Try
            For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
                r.Cells(qs2.core.generic.columnNameSelection).Value = Yes
            Next
            Me.doChange(True, -999, True, "")

            If Not Me.mainWindow Is Nothing Then
                Me.mainWindow.btnSave2.Enabled = True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub AssignCriteriaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AssignCriteriaToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub AssignCriteriaCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssignCriteriaCustomerToolStripMenuItem.Click
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsAdmin.tblSelListEntriesRow
        Try
            If Not Me.gridSelListObj.ActiveRow Is Nothing Then
                If Me.gridSelListObj.ActiveRow.IsGroupByRow Or Me.gridSelListObj.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                Else
                    Dim v As DataRowView = Me.gridSelListObj.ActiveRow.ListObject
                    Dim rSelSelList As dsAdmin.tblSelListEntriesRow = v.Row
                    selRowGrid = Me.gridSelListObj.ActiveRow
                    Return rSelSelList
                End If
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, "")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Private Sub ComboApplication_evOnChange(selectedApplication As System.String) Handles ComboApplication.evOnChange
        Try
            Me.ContCboGroup1.IDApplication = selectedApplication
            Me._IDApplication = selectedApplication
            Dim dsAdminSub As New dsAdmin()
            Me.loadData(Me._idObject_IDSelListEntrySublist_IDStay, dsAdminSub, Me._IDParticipantStay, Me._IDApplicationStay, Me._IDSelListEntry, Me._IDSelListEntrySublist, Me._gridExpandAll)
            Me.setTitleGrid()
            If Not Me.mainWindow Is Nothing Then
                Me.mainWindow.setTitle(Me._IDApplication, Me._IDParticipantAll, Me.mainWindow._IDRessourceForSave)
            End If

        Catch ex As Exception
            Throw New Exception("contSelListsObj.ComboApplication_evOnChange: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnReload_Click(sender As System.Object, e As System.EventArgs) Handles btnReload.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.reloadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub OpenSelListToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenSelListToolStripMenuItem.Click
        Try
            Dim frmSelListsManage As New qs2.sitemap.vb.frmSelLists()
            frmSelListsManage.ContSelList1.doAutoRessource = True
            frmSelListsManage.ContSelList1.defaultApplication = Me._IDApplication
            frmSelListsManage.ContSelList1.TypeStr = core.Enums.eTypeQuery.User.ToString()
            frmSelListsManage.ContSelList1.Username = qs2.core.vb.actUsr.rUsr.UserName
            frmSelListsManage.ContSelList1.IDParticipant = Me._IDParticipantAll
            frmSelListsManage.ContSelList1.IDGruppeStr = Me.grpToLoad
            frmSelListsManage.TypeStr = qs2.core.Enums.eTypeQuery.Admin.ToString()
            frmSelListsManage.typeUI = sitemap.vb.frmSelLists.eTypeUI.manageQueryGroups
            frmSelListsManage._Private = False
            frmSelListsManage.ShowDialog(Me)
            If frmSelListsManage.ContSelList1.savedClicked Then
                Me.reloadData()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridSelListObj2_BeforeCellActivate(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridSelListObj.BeforeCellActivate
        Try
            If Not Me.editable Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                If e.Cell.Column.ToString() = qs2.core.generic.columnActive Or e.Cell.Column.ToString() = qs2.core.generic.columnNameSelection Or
                    e.Cell.Column.ToString() = qs2.core.generic.columnNameIDKey.ToString() Or
                    e.Cell.Column.ToString() = qs2.core.generic.columnNameClassification Or
                    e.Cell.Column.ToString() = Me.dsAuswahllistenObj.tblSelListEntries.IDRessourceColumn.ColumnName Or
                    e.Cell.Column.ToString() = Me.dsAuswahllistenObj.tblSelListEntriesObj.IsMainColumn.ColumnName Or
                    e.Cell.Column.ToString() = Me.dsAuswahllistenObj.tblSelListEntriesObj.FromColumn.ColumnName Or
                     e.Cell.Column.ToString().Trim().ToLower() = Me.colEditableWhenCompleted.Trim().ToLower() Or
                    e.Cell.Column.ToString() = Me.dsAuswahllistenObj.tblSelListEntriesObj.ToColumn.ColumnName Then

                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridSelListObj2_CellChange(sender As System.Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridSelListObj.CellChange
        Try
            Me.gridSelListObj.UpdateData()

            Dim v As DataRowView = e.Cell.Row.ListObject
            Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row
            Me.doChange(False, rSelEntry.ID, e.Cell.Row.Cells(qs2.core.generic.columnNameSelection).Value, e.Cell.Column.ToString())

            If Me._typUI = eTypUI.Procedures Then
                If e.Cell.Column.ToString().Equals(Me.DsAuswahllisten1.tblSelListEntries.IsMainColumn.ColumnName) Then
                    e.Cell.Row.Cells(qs2.core.generic.columnNameSelection).Value = True
                End If
                If e.Cell.Column.ToString().Equals(qs2.core.generic.columnNameSelection) Then
                    If e.Cell.Row.Cells(qs2.core.generic.columnNameSelection).Value = False Then
                        e.Cell.Row.Cells(Me.DsAuswahllisten1.tblSelListEntries.IsMainColumn.ColumnName).Value = False
                    End If
                End If
            End If

            If Me.typ = eTyp.savedForObject And (Me._typUI = eTypUI.Roles Or Me._typUI = eTypUI.normal) AndAlso (Not rSelEntry Is Nothing) Then
                Dim sTxtChanged As String = ""
                If Me._typUI = eTypUI.Roles Then
                    sTxtChanged += "Role "
                ElseIf Me._typUI = eTypUI.normal Then
                    sTxtChanged += "Right "
                End If
                sTxtChanged += "" + e.Cell.Row.Cells(qs2.core.generic.columnNameText.Trim()).Value + " - Column "
                If e.Cell.Column.ToString().Trim().ToLower().Equals((qs2.core.generic.columnNameSelection.Trim()).ToLower()) Then
                    sTxtChanged += "" + e.Cell.Column.ToString() + " changed to value " + e.Cell.Value.ToString() + " "
                ElseIf e.Cell.Column.ToString().Trim().ToLower().Equals((qs2.core.generic.columnActive.Trim()).ToLower()) Then
                    sTxtChanged += "" + e.Cell.Column.ToString() + " changed to value " + e.Cell.Value.ToString() + " "
                End If
                Me.protToSave += sTxtChanged + vbNewLine
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub resetDropDownProcGroupsMain(resetAll As Boolean, IDSelListEntryToKeep As Integer,
                                           ByRef ColumnNameClicked As String)

        For Each r As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSelListObj.Rows
            Dim v As DataRowView = r.ListObject
            Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row
            If Not resetAll Then
                If Not IDSelListEntryToKeep.Equals(rSelEntry.ID) Then
                    If ColumnNameClicked.Trim().ToLower().Contains(qs2.core.generic.columnNameSelection.Trim().ToLower()) Then
                        'rSelEntry.IsMain = False
                    ElseIf ColumnNameClicked.Trim().ToLower().Contains(Me.DsAuswahllisten1.tblSelListEntries.IsMainColumn.ColumnName.Trim().ToLower()) Then
                        rSelEntry.IsMain = False
                    End If
                Else

                End If
            Else
                If ColumnNameClicked.Trim().ToLower().Contains(qs2.core.generic.columnNameSelection.Trim().ToLower()) Then
                    'rSelEntry.IsMain = False
                ElseIf ColumnNameClicked.Trim().ToLower().Contains(Me.DsAuswahllisten1.tblSelListEntries.IsMainColumn.ColumnName.Trim().ToLower()) Then
                    rSelEntry.IsMain = False
                End If
            End If
        Next

    End Sub

    Private Sub OpenSelListObjToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenSelListObjToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelListGroupSelected As dsAdmin.tblSelListEntriesRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelListGroupSelected Is Nothing Then
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.sqlAdmin1.getSelListGroupRowID(rSelListGroupSelected.IDGroup)
                'Dim sublist As String = "Right"

                Dim frm As New frmSelListsObj()
                frm.ContSelListsObj1.TypeStr = TypeStr
                frm.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelListGroupSelected.ID
                frm.ContSelListsObj1.IDApplicationToAssignForSublists = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1._IDApplication = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1.grpToLoad = Me.SubListObjToLoad     'rGroup.IDGroupStr
                frm.ContSelListsObj1.hideComboApplications = True
                Dim lstClassification As New System.Collections.ArrayList()
                'If tagMenü.rGroup.IDGroupStr.ToLower().Trim() = ("Queries").ToLower().Trim() Then
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString())
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString())
                '    lstClassification.Add("")
                'End If

                frm.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList
                frm.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList
                frm.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, contSelListsObj.eTypUI.normal,
                              True, Me.IDApplicationToAssignForSublists, rGroup.IDParticipant,
                              Me.SubListObjToLoad, rSelListGroupSelected.IDRessource)

                frm.ShowDialog(Me)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub OpenSelListObj2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelListObj2ToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelListGroupSelected As dsAdmin.tblSelListEntriesRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelListGroupSelected Is Nothing Then
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.sqlAdmin1.getSelListGroupRowID(rSelListGroupSelected.IDGroup)
                'Dim sublist As String = "Right"

                Dim frm As New frmSelListsObj()
                frm.ContSelListsObj1.TypeStr = TypeStr
                frm.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelListGroupSelected.ID
                frm.ContSelListsObj1.IDApplicationToAssignForSublists = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1._IDApplication = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1.grpToLoad = Me.SubListObjToLoad2     'rGroup.IDGroupStr
                Dim lstClassification As New System.Collections.ArrayList()
                'If tagMenü.rGroup.IDGroupStr.ToLower().Trim() = ("Queries").ToLower().Trim() Then
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString())
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString())
                '    lstClassification.Add("")
                'End If

                frm.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList
                frm.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList
                frm.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, contSelListsObj.eTypUI.normal,
                              True, Me.IDApplicationToAssignForSublists, rGroup.IDParticipant,
                              Me.SubListObjToLoad2, rSelListGroupSelected.IDRessource)

                frm.ShowDialog(Me)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub OpenSelListObj3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelListObj3ToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelListGroupSelected As dsAdmin.tblSelListEntriesRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelListGroupSelected Is Nothing Then
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.sqlAdmin1.getSelListGroupRowID(rSelListGroupSelected.IDGroup)
                'Dim sublist As String = "Right"

                Dim frm As New frmSelListsObj()
                frm.ContSelListsObj1.TypeStr = TypeStr
                frm.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelListGroupSelected.ID
                frm.ContSelListsObj1.IDApplicationToAssignForSublists = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1._IDApplication = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1.grpToLoad = Me.SubListObjToLoad3     'rGroup.IDGroupStr
                Dim lstClassification As New System.Collections.ArrayList()
                'If tagMenü.rGroup.IDGroupStr.ToLower().Trim() = ("Queries").ToLower().Trim() Then
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString())
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString())
                '    lstClassification.Add("")
                'End If

                frm.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList
                frm.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList
                frm.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, contSelListsObj.eTypUI.normal,
                              True, Me.IDApplicationToAssignForSublists, rGroup.IDParticipant,
                              Me.SubListObjToLoad, rSelListGroupSelected.IDRessource)

                frm.ShowDialog(Me)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub OpenSelListObj4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenSelListObj4ToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelListGroupSelected As dsAdmin.tblSelListEntriesRow = Me.getSelectedRow(True, selRowGrid)
            If Not rSelListGroupSelected Is Nothing Then
                Dim rGroup As dsAdmin.tblSelListGroupRow = Me.sqlAdmin1.getSelListGroupRowID(rSelListGroupSelected.IDGroup)
                'Dim sublist As String = "Right"

                Dim frm As New frmSelListsObj()
                frm.ContSelListsObj1.TypeStr = TypeStr
                frm.ContSelListsObj1._idObject_IDSelListEntrySublist_IDStay = rSelListGroupSelected.ID
                frm.ContSelListsObj1.IDApplicationToAssignForSublists = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1._IDApplication = Me.IDApplicationToAssignForSublists
                frm.ContSelListsObj1.grpToLoad = Me.SubListObjToLoad4     'rGroup.IDGroupStr
                Dim lstClassification As New System.Collections.ArrayList()
                'If tagMenü.rGroup.IDGroupStr.ToLower().Trim() = ("Queries").ToLower().Trim() Then
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.MainReport.ToString())
                '    lstClassification.Add(qs2.core.Enums.eTypSubReport.SubReport.ToString())
                '    lstClassification.Add("")
                'End If

                frm.ContSelListsObj1.typDB = sqlAdmin.eDbTypAuswObj.SubSelList
                frm.ContSelListsObj1.typ = contSelListsObj.eTyp.saveForSelList
                frm.loadData(lstClassification, AutoFitStyle.ExtendLastColumn, contSelListsObj.eTypUI.normal,
                              True, Me.IDApplicationToAssignForSublists, rGroup.IDParticipant,
                              Me.SubListObjToLoad, rSelListGroupSelected.IDRessource)

                frm.ShowDialog(Me)

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub BuildSqlCheckedTrueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildSqlCheckedTrueToolStripMenuItem.Click
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub BuildSqlCheckedFalseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildSqlCheckedFalseToolStripMenuItem.Click
        Try

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
