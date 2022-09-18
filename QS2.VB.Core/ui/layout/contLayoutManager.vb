Imports VB = Microsoft.VisualBasic
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win




Public Class contLayoutManager

    Private editable As Boolean = False
    Private isLoaded As Boolean = False

    Public doUI1 As New doUI()
    Public mainWindow As frmLayoutManager = Nothing

    Public abort As Boolean = True

    Public lstColViewGrid As New System.Collections.Generic.List(Of String)
    Public lstColViewGridDeactivate As New System.Collections.Generic.List(Of String)

    Public layoutDeleted As Boolean = False
    Public _ManageMode As Boolean = False

    Public funct1 As New qs2.core.vb.funct()

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public cLayoutManager1 As New cLayoutManager()

    Public isNew As Boolean = False

    Public delonSaveClick As onValueSave
    Public Delegate Sub onValueSave(ByVal rLayout As dsLayout.LayoutRow)

    Public Enum eTypeAction
        AllColumnsVisible = 0
        NoColumnsVisible = 1
    End Enum

    Public nCounterCopied As Integer = 0








    Private Sub contVermGruppeObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ManageModexy As Boolean, ExtendedView As Boolean)
        Try
            If Me.isLoaded Then Exit Sub

            Me.ContLayout1.mainWindow = Me

            Me._ManageMode = ManageModexy
            Me.cLayoutManager1.initControl()

            Dim newRessourcesAdded As Integer = 0
            'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.CompLayout1.initControl()
            Me.ContLayout1.initControl(False, ExtendedView)

            Me.loadRes(ExtendedView)
            Me.ContLayoutSelection1.mainWIndow = Me
            Me.ContLayoutSelection1.initControl(ManageModexy, ExtendedView)

            Me.clearUI(True)
            Me.NewLayout("")
            Me.ContLayout1.txtLayoutName.Focus()

            If Not Me.cLayoutManager1.gridUIToSave Is Nothing Then
                Me.btnTestLayout.Visible = True
                Me.btnResetLayoutGrid.Visible = True
            Else
                Me.btnTestLayout.Visible = False
                Me.btnResetLayoutGrid.Visible = False
            End If

            Me.gridLayoutGrid.AllowDrop = True

            If Not ENV.adminSecure Then
                Me.ContLayoutSelection1.CboLayout1.Enabled = False
            End If

            Dim InfragColumnStyle As New Infragistics.Win.UltraWinGrid.ColumnStyle()
            qs2.core.vb.funct.getEnumAsList2(InfragColumnStyle.GetType(), Me.gridLayoutGrid.DisplayLayout.ValueLists("TypeUI"))

            Me.chkShowOnlyVisibleColumns.Checked = True

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes(ExtendedView As Boolean)
        Try
            Me.btnDown.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_down, 32, 32)
            Me.btnUp.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_up, 32, 32)
            Me.btnSave.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

            Me.btnClose.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Beenden, 32, 32)
            Me.btnAbort.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32)

            Me.btnAddLayoutRow.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.btnDeleteLayoutRow.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Me.btnTestLayout.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.ContLayoutSelection1.loadResLayoutGrids(Me.gridLayoutGrid.DisplayLayout.Bands(0))

            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.ColumnCaptionColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName)

            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.ColumnWithColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.OrderByColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.DescColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.GroupByColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.SortColumn.ColumnName)
            'Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.BandColumn.ColumnName)
            'Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.GridAutoNewlineColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.TypeColColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.AutoSizeHeigthColumnColumn.ColumnName)
            Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.TypeUIColumn.ColumnName)
            'Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.ColMinHeigthColumn.ColumnName)
            'Me.lstColViewGrid.Add(Me.DsLayout1.LayoutGrids.ColMaxHeigthColumn.ColumnName)
            If ExtendedView Then

            Else

            End If
            Me.funct1.gridAdvancedView(False, Me.gridLayoutGrid, Me.lstColViewGrid, Me.lstColViewGridDeactivate)

            Me.lblCopyLayout.Text = qs2.core.language.sqlLanguage.getRes("CopyLayout")
            Me.lblSearchinGrid.Text = qs2.core.language.sqlLanguage.getRes("Search")

            Me.chkShowOnlyVisibleColumns.Text = qs2.core.language.sqlLanguage.getRes("OnlyShowVisibleColumns")
            Me.btnResetLayoutGrid.Text = qs2.core.language.sqlLanguage.getRes("ResetLayout")

            Me.btnAllColumnsVisible.Text = qs2.core.language.sqlLanguage.getRes("AllColumnsVisible")
            Me.btnNoColumnsVisible.Text = qs2.core.language.sqlLanguage.getRes("NoColumnsVisible")

            Dim infoToolTip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("AddRowToTable")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnAddLayoutRow, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("DeleteSelectedRowFromTable")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDeleteLayoutRow, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("Close")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnClose, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("TestLayout")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnTestLayout, infoToolTip)

            Me.btnSave.Text = qs2.core.language.sqlLanguage.getRes("Save")
            Me.btnAbort.Text = qs2.core.language.sqlLanguage.getRes("Undo2")

            If ExtendedView Then
                Me.gridLayoutGrid.DisplayLayout.Bands(0).Columns(Me.DsLayout1.LayoutGrids.TypeColColumn.ColumnName).Hidden = False
                Me.PanelOben.Height = 212
            Else
                Me.gridLayoutGrid.DisplayLayout.Bands(0).Columns(Me.DsLayout1.LayoutGrids.TypeColColumn.ColumnName).Hidden = True
                Me.PanelOben.Height = 187
            End If

            If Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Me.lblCopyLayout.Visible = False
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Function loadData(Key As String, LayoutNameDefault As String, DeleteOldLayout As Boolean, BuildNewLayout As Boolean, _
                             OnlyShowVisibleColumns As Boolean) As Boolean
        Try
            Me.clearUI(False)
            Me.isNew = False

            Me.cLayoutManager1.load(Key, Me.DsLayout1, Me.CompLayout1, LayoutNameDefault, DeleteOldLayout, BuildNewLayout)
            'Me.DsLayout1.LayoutGrids.AcceptChanges()
            Me.ShowColumnsVisible(OnlyShowVisibleColumns)
            Me.gridLayoutGrid.Refresh()
            Me.SetUICounterColumns()

            Dim rLayout As dsLayout.LayoutRow = Me.DsLayout1.Layout.Rows(0)
            Me.ContLayout1.SetRowToUI()
            Me.ContLayoutSelection1.CboLayout1.SelectLayout(rLayout.IDGuid)

            Me.ContLayoutSelection1.CboLayout1.lastIDLayoutSelected = rLayout.IDGuid

            If Not Me.mainWindow Is Nothing Then
                If Not rLayout Is Nothing Then
                    If rLayout.RowState <> DataRowState.Deleted And rLayout.RowState <> DataRowState.Detached Then
                        Me.mainWindow.Text = qs2.core.language.sqlLanguage.getRes("LayoutManager") + " " + rLayout.LayoutName.Trim()
                    End If
                End If
            End If

            'For Each RowGrid As UltraGridRow In Me.gridLayoutGrid.Rows
            '    Dim v As DataRowView = RowGrid.ListObject
            '    Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = v.Row

            '    Dim ColStyleUI As Infragistics.Win.UltraWinGrid.ColumnStyle = ColumnStyle.Default
            '    If Not rSelLayoutGrid.IsTypeUINull() Then
            '        ColStyleUI = rSelLayoutGrid.TypeUI
            '    End If
            '    RowGrid.Cells(Me.DsLayout1.LayoutGrids.TypeUIColumn.ColumnName).Value = System.Convert.ToInt32(ColStyleUI)
            'Next
            'Me.gridLayoutGrid.Refresh()

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Sub SetUICounterColumns()
        lblCounterColumns.Text = "" + qs2.core.language.sqlLanguage.getRes("Found") + ": " + Me.gridLayoutGrid.Rows.Count.ToString() + ""
    End Sub
    Public Sub ShowColumnsVisible(OnlyShowVisibleColumns As Boolean)
        Try
            For Each rowGrid As UltraGridRow In Me.gridLayoutGrid.Rows
                Dim v As DataRowView = rowGrid.ListObject
                Dim rLayoutGridAct As dsLayout.LayoutGridsRow = v.Row
                If OnlyShowVisibleColumns And Not rLayoutGridAct.Visible Then
                    rowGrid.Hidden = True
                ElseIf OnlyShowVisibleColumns And rLayoutGridAct.Visible Then
                    rowGrid.Hidden = False
                ElseIf Not OnlyShowVisibleColumns Then
                    rowGrid.Hidden = False
                End If
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function NewLayout(Key As String) As Boolean
        Try
            Me.clearUI(True)
            Me.ContLayoutSelection1.CboLayout1.DeleteSelection()

            Me.cLayoutManager1.newLayout(Me.DsLayout1, Me.CompLayout1, "")
            Me.gridLayoutGrid.Refresh()
            Me.ContLayout1.SetRowToUI()

            Me.isNew = True

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Function clearUI(LoadCboLayout As Boolean) As Boolean
        Try
            Me.isNew = False
            Me.DsLayout1.LayoutGrids.Clear()
            If LoadCboLayout Then
                'Me.ContLayoutSelection1.CboLayout1.lastIDLayoutSelected = Nothing
                Me.ContLayoutSelection1.CboLayout1.LoadData()
            End If

            Me.ContLayout1.ClearUI()
            Me.lblCounterColumns.Text = ""
            Me.txtSearchinGrid.Text = ""
            Me.funct1.clearAllFilter(Me.gridLayoutGrid)

            Me.CompLayout1.getLayoutGrid(System.Guid.NewGuid(), Me.DsLayout1, compLayout.eSelLayoutGrid.Grid)
            Me.gridLayoutGrid.Refresh()

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Sub SetUI()
        Try
            If Me.isNew Then

            Else

            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.SetUI:" + ex.ToString())
        End Try
    End Sub

    Public Sub refreshControl()
        Try


        Catch ex As Exception
            Throw New Exception("contLayoutGrid.refreshControl:" + ex.ToString())
        End Try
    End Sub

    Public Function validate() As Boolean
        Try
            'Me.ErrorProvider1.SetError(Me.btnAdd, "")

            'For Each rGrid As UltraGridRow In Me.gridSelListObj.Rows
            '    Dim v As DataRowView = rGrid.ListObject
            '    Dim rSelListObj As dsAuswahllisten.AuswahllistenObjRow = v.Row

            '    rSelListObj.SetColumnError(Me.DsAuswahllisten1.AuswahllistenObj.IDAuswahlColumn.ColumnName, "")

            '    If rSelListObj.RowState <> DataRowState.Deleted Then
            '        If Me.typDB = compAuswahllisten.eDbTypAuswObj.RiskClassesInsuranceMasterData Then
            '            If rSelListObj.AuswahlTxt.Trim() = "" Then
            '                Me.gridSelListObj.ActiveRow = rGrid
            '                Dim str As String = compAutoUI.getRes("InputRequired")
            '                rSelListObj.SetColumnError(Me.DsAuswahllisten1.AuswahllistenObj.AuswahlTxtColumn.ColumnName, str)
            '                Me.ErrorProvider1.SetError(Me.btnAdd, str)
            '                ITSCont.core.SystemDb.doUI.doMessageBox("InputRequired", "SelList", "!")
            '                Return False
            '            End If
            '        End If
            '    End If
            'Next

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function



    Private Sub gridVermGruppe_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridLayoutGrid.BeforeCellActivate
        Try
            If Not Me.editable Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                If e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName.Trim().ToLower() Or _
                   e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColumnCaptionColumn.ColumnName.Trim().ToLower() Or _
                   e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColumnWithColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.OrderByColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.DescColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.SortColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.GridAutoNewlineColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.AutoSizeHeigthColumnColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColMinHeigthColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColMaxHeigthColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.GroupByColumn.ColumnName.Trim().ToLower() Or _
                    e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.TypeUIColumn.ColumnName.Trim().ToLower() Then

                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Else
                    If e.Cell.Column.ToString() = Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName And _
                        Me._ManageMode Then

                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                    Else
                        e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    End If
                End If
            End If

            'e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColumnCaptionColumn.ColumnName.Trim().ToLower() Or _
            'e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName.Trim().ToLower() Or _

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridLayoutGrid_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridLayoutGrid.BeforeCellUpdate
        Try
            If e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.SortColumn.ColumnName.Trim().ToLower() Then
 
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridLayoutGrid_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridLayoutGrid.AfterCellUpdate
        Try
            If e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.SortColumn.ColumnName.Trim().ToLower() Or _
                e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName.Trim().ToLower() Then
                Me.gridLayoutGrid.UpdateData()

                Dim v As DataRowView = e.Cell.Row.ListObject
                Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = v.Row
                Me.doSort(rSelLayoutGrid, True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridLayoutGrid_CellChange(sender As Object, e As CellEventArgs) Handles gridLayoutGrid.CellChange
        Try
            If e.Cell.Column.ToString().Trim().ToLower() = Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName.Trim().ToLower() Then
                Me.gridLayoutGrid.UpdateData()

                Dim v As DataRowView = e.Cell.Row.ListObject
                Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = v.Row
                Me.doSort(rSelLayoutGrid, True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridLayoutGrid_SelectionDrag(sender As Object, e As ComponentModel.CancelEventArgs) Handles gridLayoutGrid.SelectionDrag
        Try
            qs2.core.vb.ui.gridLayoutGrid_SelectionDrag(sender, e)
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridLayoutGrid_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles gridLayoutGrid.DragOver
        Try
            qs2.core.vb.ui.gridLayoutGrid_DragOver(sender, e)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridLayoutGrid_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles gridLayoutGrid.DragDrop
        Try
            Dim ugrOver As UltraGridRow = Nothing
            Dim SelRows As SelectedRowsCollection = Nothing
            qs2.core.vb.ui.gridLayoutGrid_DragDrop(sender, e, SelRows, ugrOver)

            For Each aRow As UltraGridRow In SelRows
                Dim GridRowBefore As UltraGridRow = Nothing
                Dim SortBefore As Integer = 0
                Dim ToTop As Boolean = False
                Dim rSelLayoutGridAct As dsLayout.LayoutGridsRow = Nothing
                If ugrOver.Index > 0 Then
                    GridRowBefore = Me.gridLayoutGrid.Rows(ugrOver.Index)
                    Dim vBefore As DataRowView = GridRowBefore.ListObject
                    Dim rSelLayoutGridBefore As dsLayout.LayoutGridsRow = vBefore.Row
                    SortBefore = rSelLayoutGridBefore.Sort
                    ToTop = True

                    Dim vAct As DataRowView = aRow.ListObject
                    rSelLayoutGridAct = vAct.Row
                    rSelLayoutGridAct.Sort = SortBefore

                Else
                    GridRowBefore = Me.gridLayoutGrid.Rows(ugrOver.Index)
                    Dim vBefore As DataRowView = GridRowBefore.ListObject
                    Dim rSelLayoutGridBefore As dsLayout.LayoutGridsRow = vBefore.Row
                    SortBefore = rSelLayoutGridBefore.Sort
                    ToTop = False

                    Dim vAct As DataRowView = aRow.ListObject
                    rSelLayoutGridAct = vAct.Row
                    rSelLayoutGridAct.Sort = SortBefore
                End If

                Me.doSort(rSelLayoutGridAct, ToTop)

            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.editable = bEdit
            Me.btnUp.Enabled = bEdit
            Me.btnDown.Enabled = bEdit

            If Me.editable Then
                Me.gridLayoutGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.gridLayoutGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = Me.getSelectedRow(True)
            If Not rSelLayoutGrid Is Nothing Then
                rSelLayoutGrid.Sort -= 1
                Me.doSort(rSelLayoutGrid, True)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = Me.getSelectedRow(True)
            If Not rSelLayoutGrid Is Nothing Then
                rSelLayoutGrid.Sort += 1
                Me.doSort(rSelLayoutGrid, False)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub doSort(ByRef rSelLayoutGrid As dsLayout.LayoutGridsRow, ToTop As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.funct1.doSortAuto(Me.DsLayout1.LayoutGrids, Me.DsLayout1.LayoutGrids.SortColumn.ColumnName, _
                                     Me.DsLayout1.LayoutGrids.IDGuidColumn.ColumnName, _
                                     rSelLayoutGrid, Me.gridLayoutGrid, _
                                     True, Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName, _
                                     Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName, ToTop)

            'Me.funct1.doSort(toTop, True, NewPositon, Me.DsLayout1.LayoutGrids, Me.DsLayout1.LayoutGrids.SortColumn.ColumnName, _
            '                 Me.DsLayout1.LayoutGrids.IDGuidColumn.ColumnName, _
            '                 rSelLayoutGrid, Me.gridLayoutGrid, _
            '                 True, Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName, _
            '                 Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName)


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean) As dsLayout.LayoutGridsRow
        Try
            If Not Me.gridLayoutGrid.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.gridLayoutGrid.ActiveRow.ListObject
                Dim rSelLayoutGrid As dsLayout.LayoutGridsRow = v.Row
                Return rSelLayoutGrid
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, _
                                                    qs2.core.language.sqlLanguage.getRes("Sort"))
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function


    Public Function newLayoutGridRow() As Boolean
        Try
            Dim rNewLayoutGrid As dsLayout.LayoutGridsRow = Me.CompLayout1.newLayoutGrid(Me.DsLayout1, Me.cLayoutManager1.rLayout.IDGuid)

            Me.gridLayoutGrid.Refresh()
            Me.gridLayoutGrid.UpdateData()

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.newLayoutRow: " + ex.ToString())
        End Try
    End Function
    Public Function DeleteLayoutGridRow() As Boolean
        Try
            Dim rSelLayoutGrod As dsLayout.LayoutGridsRow = Me.getSelectedRow(True)
            If Not rSelLayoutGrod Is Nothing Then
                rSelLayoutGrod.Delete()
                Me.gridLayoutGrid.Refresh()
                Me.gridLayoutGrid.UpdateData()
            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.DeleteLayoutRow: " + ex.ToString())
        End Try
    End Function
    Public Sub SetLayoutToGrid()
        Try
            If Not Me.cLayoutManager1.gridUIToSave Is Nothing Then
                Me.gridLayoutGrid.UpdateData()
                Dim LayoutFound As Boolean = False
                Me.CompLayout1.doLayoutGrid(Me.cLayoutManager1.gridUIToSave, Me.cLayoutManager1.rLayout.Key.Trim(), Nothing, LayoutFound, True, False, False)
            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.SetLayoutToGrid: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.ContLayout1.validateData() Then
                If Me.validate() Then
                    Me.ContLayout1.GetUIToRow()
                    If Me.cLayoutManager1.saveData(Me.DsLayout1, Me.CompLayout1) Then
                        Me.abort = False
                        Me.ContLayoutSelection1.CboLayout1.LoadData()
                        If Me.isNew Then
                            Me.ContLayoutSelection1.CboLayout1.lastIDLayoutSelected = Me.cLayoutManager1.rLayout.IDGuid
                        End If
                        Me.loadData(Me.cLayoutManager1.rLayout.Key.Trim(), "", False, False, Me.chkShowOnlyVisibleColumns.Checked)
                        Me.ContLayoutSelection1.CboLayout1.SelectLayout(Me.cLayoutManager1.rLayout.IDGuid)

                        Me.SetLayoutToGrid()
                        If Not Me.delonSaveClick Is Nothing Then
                            Me.delonSaveClick.Invoke(Me.cLayoutManager1.rLayout)
                        End If

                        'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DataSaved") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                        If Not Me._ManageMode Then
                            'Me.mainWindow.Close()
                        End If
                    Else
                        Throw New Exception("contLayoutGrid.btnSave_Click: Error Save Layout!")
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub




    Public Function LayoutGridLöschen(ByRef CloseForm As Boolean) As Boolean
        Try
            Dim ret As MsgBoxResult
            ret = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToDeleteTheLayout") + "?", Windows.Forms.MessageBoxButtons.YesNo, "")
            If ret = MsgBoxResult.Yes Then
                Me.CompLayout1.deleteLayout(Me.cLayoutManager1._LayoutKey)
                Me.cLayoutManager1.ResetLayout(Me.CompLayout1)
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("LayoutDeleted") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Me.layoutDeleted = True
                If CloseForm Then
                    Me.mainWindow.Close()
                End If
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.LayoutLöschen: " + ex.ToString())
        End Try
    End Function


    Private Sub btnAddNewLayoutRow_Click(sender As Object, e As EventArgs) Handles btnAddLayoutRow.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.newLayoutGridRow()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAddDeleteLayoutRow_Click(sender As Object, e As EventArgs) Handles btnDeleteLayoutRow.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.DeleteLayoutGridRow()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.refreshUI()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub refreshUI()
        Try
            Dim rLayoutSelected As dsLayout.LayoutRow = Me.ContLayoutSelection1.CboLayout1.getSelectedRow(False)
            If Not rLayoutSelected Is Nothing Then
                Me.loadData(rLayoutSelected.Key.Trim(), "", False, False, Me.chkShowOnlyVisibleColumns.Checked)
                Me.SetLayoutToGrid()
            Else
                Me.NewLayout("")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub chkShowOnlyVisibleColumns_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOnlyVisibleColumns.CheckedChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.chkShowOnlyVisibleColumns.Focus() Then
                Me.ShowColumnsVisible(Me.chkShowOnlyVisibleColumns.Checked)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnTestLayout_Click(sender As Object, e As EventArgs) Handles btnTestLayout.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.TestLayout()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub TestLayout()
        Try
            'Dim rLayoutSelected As dsLayout.LayoutRow = Me.ContLayoutSelection1.CboLayout1.getSelectedRow(True)
            'If Not rLayoutSelected Is Nothing Then
            Me.gridLayoutGrid.UpdateData()
            Dim LayoutFound As Boolean = False
            Me.CompLayout1.doLayoutGrid(Me.cLayoutManager1.gridUIToSave, Me.cLayoutManager1.rLayout.Key.Trim(), Me.DsLayout1, LayoutFound, True, False, False)
            'End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.TestLayout: " + ex.ToString())
        End Try
    End Sub
    Private Sub btnResetLayoutGrid_Click_1(sender As Object, e As EventArgs) Handles btnResetLayoutGrid.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.ResetLayoutGrid()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub ResetLayoutGrid()
        Try
            Dim ret As MsgBoxResult
            ret = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToResetTheLayout") + "?", Windows.Forms.MessageBoxButtons.YesNo, "")
            If ret = MsgBoxResult.Yes Then
                Me.cLayoutManager1.ResetLayout(Me.CompLayout1)
                'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ActivityPerformed"), Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnAllColumnsVisible_Click(sender As Object, e As EventArgs) Handles btnAllColumnsVisible.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doAction(eTypeAction.AllColumnsVisible)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnNoColumnsVisible_Click(sender As Object, e As EventArgs) Handles btnNoColumnsVisible.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doAction(eTypeAction.NoColumnsVisible)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub doAction(TypeAction As eTypeAction)
        Try
            For Each rRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridLayoutGrid.Rows
                Dim v As DataRowView = rRowGrid.ListObject
                Dim rLayoutGrid As dsLayout.LayoutGridsRow = v.Row

                If TypeAction = eTypeAction.AllColumnsVisible Then
                    rLayoutGrid.Visible = True
                ElseIf TypeAction = eTypeAction.NoColumnsVisible Then
                    rLayoutGrid.Visible = False
                End If

            Next

            Me.gridLayoutGrid.UpdateData()

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.doAction: " + ex.ToString())
        End Try
    End Sub

    Private Sub gridLayoutGrid_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridLayoutGrid.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub lblCopyLayout_Click(sender As Object, e As EventArgs) Handles lblCopyLayout.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim rLayoutSelected As dsLayout.LayoutRow = Me.ContLayoutSelection1.CboLayout1.getSelectedRow(True)
            If Not rLayoutSelected Is Nothing Then
                Dim sKeyLayoutCopied As String = ""
                Dim IDLayoutCopied As System.Guid = Nothing
                nCounterCopied += 1
                Me.cLayoutManager1.copyLayout(rLayoutSelected.IDGuid, sKeyLayoutCopied, IDLayoutCopied, Me.nCounterCopied)

                Me.clearUI(True)
                Me.loadData(sKeyLayoutCopied.Trim(), "", False, False, Me.chkShowOnlyVisibleColumns.Checked)
                Me.SetLayoutToGrid()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub txtSearchinGrid_ValueChanged(sender As Object, e As EventArgs) Handles txtSearchinGrid.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.txtSearchinGrid.Focused Then
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
            Me.funct1.clearAllFilter(Me.gridLayoutGrid)

            If Me.txtSearchinGrid.Text.Trim() <> "" Then
                Me.funct1.setFilter(Me.DsLayout1.LayoutGrids.ColumnCaptionColumn.ColumnName, _
                                                FilterLogicalOperator.Or, Me.txtSearchinGrid.Text.Trim(), _
                                                FilterComparisionOperator.StartsWith, Me.gridLayoutGrid, _
                                                Me.gridLayoutGrid.DisplayLayout.Bands(0).Index)

                Me.funct1.setFilter(Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName, _
                                                FilterLogicalOperator.Or, Me.txtSearchinGrid.Text.Trim(), _
                                                FilterComparisionOperator.StartsWith, Me.gridLayoutGrid, _
                                                Me.gridLayoutGrid.DisplayLayout.Bands(0).Index)
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub gridLayoutGrid_BeforeAutoSizeEdit(sender As Object, e As CancelableAutoSizeEditEventArgs) Handles gridLayoutGrid.BeforeAutoSizeEdit
        Try
            'e.StartHeight = 200

        Catch ex As Exception
               qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class
