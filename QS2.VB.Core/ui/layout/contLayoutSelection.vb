

Public Class contLayoutSelection


    Private isLoaded As Boolean = False

    Public doUI1 As New doUI()

    Public mainWIndow As contLayoutManager = Nothing
    Public _ManageModexy As Boolean = False





    Private Sub contLayoutSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ManageModexy As Boolean, ExtendedView As Boolean)
        Try
            If Me.isLoaded Then Exit Sub

            Me._ManageModexy = ManageModexy
            Dim newRessourcesAdded As Integer = 0
            'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.CompLayout1.initControl()
            Me.loadRes(ExtendedView)

            Dim dOnValueChangedCourtage As New cboLayout.onValueChanged(AddressOf Me.ValueCboLayoutsChanged)
            Me.CboLayout1.delonValueChanged = dOnValueChangedCourtage

            'Me.PanelComboLayout.Visible = ManageMode
            Me.CboLayout1.initControl(ManageModexy, False, ExtendedView)
            Me.CboLayout1.LoadData()

            'Me.btnDeleteLayout.Visible = ManageMode
            'Me.btnNewLayout.Visible = ManageMode
            'Me.btnEditLayout.Visible = ManageMode

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub ValueCboLayoutsChanged()
        Try
            If Not Me.mainWIndow Is Nothing Then
                Me.mainWIndow.clearUI(False)
                Dim rLayoutSelected As dsLayout.LayoutRow = Me.CboLayout1.getSelectedRow(False)
                If Not rLayoutSelected Is Nothing Then
                    Me.mainWIndow.loadData(rLayoutSelected.Key.Trim(), "", False, False, Me.mainWIndow.chkShowOnlyVisibleColumns.Checked)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.ValueCboLayoutsChanged: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadRes(ExtendedView As Boolean)
        Try
            Me.btnDeleteLayout.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnNewLayout.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
            Me.btnRefresh.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32)

            Me.loadResLayout(Me.CboLayout1.cboLay.DisplayLayout.Bands(0))

            Dim infoToolTip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("Refresh")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnRefresh, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("DeleteLayout")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDeleteLayout, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("NewLayout")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnNewLayout, infoToolTip)

            'infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            'infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            'infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("EditLayout")
            'Me.UltraToolTipManager1.SetUltraToolTip(Me.btnEditLayout, infoToolTip)

            If ExtendedView Then
                Me.CboLayout1.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Hidden = False
                Me.btnNewLayout.Visible = True
            Else
                Me.CboLayout1.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Hidden = True
                Me.btnNewLayout.Visible = False
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadResLayoutGrids(Band As Infragistics.Win.UltraWinGrid.UltraGridBand)
        Try
            Band.Columns(Me.DsLayout1.LayoutGrids.IDGuidColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.IDGuid", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.GridNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.GridName", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.BandColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.Band", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.ColumnNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.ColumnName", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.ColumnWithColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.ColumnWith", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.VisibleColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.Visible", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.OrderByColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.OrderBy", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.DescColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.Desc", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.GroupByColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.GroupBy", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.SortColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.Sort", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.IDLayoutColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.IDLayout", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.GridAutoNewlineColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("AutoNewline", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.TypeColColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Typ", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.AutoSizeHeigthColumnColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("AutoSizeHeigthColumn", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.ColMinHeigthColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ColMinHeigth", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.ColMaxHeigthColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ColMaxHeigth", False)
            Band.Columns(Me.DsLayout1.LayoutGrids.ColumnCaptionColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ColumnCaption", False)

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.loadResLayoutGrids: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadResLayout(Band As Infragistics.Win.UltraWinGrid.UltraGridBand)
        Try
            Band.Columns(Me.DsLayout1.Layout.IDGuidColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutGrids.IDGuid", False)
            Band.Columns(Me.DsLayout1.Layout.LayoutNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutName", False)
            Band.Columns(Me.DsLayout1.Layout.AllUsersColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("AllUsers", False)
            Band.Columns(Me.DsLayout1.Layout.CreateFromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("CreatedUser", False)
            Band.Columns(Me.DsLayout1.Layout.CreateAtColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Created", False)
            Band.Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key", False)
            Band.Columns(Me.DsLayout1.Layout.GridRowMinHeigthColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("GridRowMinHeigth", False)
            Band.Columns(Me.DsLayout1.Layout.GridRowMaxHeigthColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("GridRowMaxHeigth", False)

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.loadResLayoutGrids: " + ex.ToString())
        End Try
    End Sub
    Public Function LayoutLöschen() As Boolean
        Try
            Dim rLayoutSelected As dsLayout.LayoutRow = Me.CboLayout1.getSelectedRow(True)
            If Not rLayoutSelected Is Nothing Then
                Dim ret As MsgBoxResult
                ret = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DoYouRealyWantToDeleteTheLayout") + "?", Windows.Forms.MessageBoxButtons.YesNo, "")
                If ret = MsgBoxResult.Yes Then
                    Me.CompLayout1.deleteLayout(rLayoutSelected.IDGuid)
                    Me.CboLayout1.ClearData()
                    If Not Me.mainWIndow Is Nothing Then
                        Me.mainWIndow.NewLayout("")
                        Me.mainWIndow.cLayoutManager1.ResetLayout(Me.mainWIndow.CompLayout1)
                    End If

                    'qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("LayoutDeleted") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contLayoutGrid.LayoutLöschen: " + ex.ToString())
        End Try
    End Function



    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Me.CboLayout1.LoadData()
            Me.mainWIndow.NewLayout("")

            Dim dsLayoutWork As New dsLayout()
            Dim compLayoutWork As New compLayout()
            compLayoutWork.initControl()
            compLayoutWork.getLayout(dsLayoutWork, "", compLayout.eSelLayoutGrid.IDLayout, Me.CboLayout1.lastIDLayoutSelected, "")
            If dsLayoutWork.Layout.Rows.Count = 1 Then
                Dim rSelectedLayout As dsLayout.LayoutRow = dsLayoutWork.Layout.Rows(0)
                Me.mainWIndow.loadData(rSelectedLayout.Key.Trim(), "", False, False, Me.mainWIndow.chkShowOnlyVisibleColumns.Checked)
            ElseIf dsLayoutWork.Layout.Rows.Count = 0 Then
                Me.CboLayout1.lastIDLayoutSelected = Nothing
            ElseIf dsLayoutWork.Layout.Rows.Count > 1 Then
                Throw New Exception("btnRefresh_Click: dsLayoutWork.Layout.Rows.Count > 1 for Key='" + Me.CboLayout1.lastIDLayoutSelected.ToString() + "'!")
            End If


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDeleteLayout_Click(sender As Object, e As EventArgs) Handles btnDeleteLayout.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.LayoutLöschen() Then
                Me.CboLayout1.lastIDLayoutSelected = Nothing
                Me.CboLayout1.LoadData()
                Me.mainWIndow.ContLayout1.txtLayoutName.Focus()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnNewLayout_Click(sender As Object, e As EventArgs) Handles btnNewLayout.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.CboLayout1.lastIDLayoutSelected = Nothing
            Me.mainWIndow.NewLayout("")
            Me.mainWIndow.ContLayout1.txtLayoutName.Focus()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
