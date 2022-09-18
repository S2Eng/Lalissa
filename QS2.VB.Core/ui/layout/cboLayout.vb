

Public Class cboLayout

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public lastIDLayoutSelected As System.Guid = Nothing

    Public _ExtendedView As Boolean = False




    Private Sub cboLayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(ManageModexy As Boolean, ShowDeleteSelection As Boolean, ExtendedView As Boolean)
        Try
            Me._ExtendedView = ExtendedView
            Me.lblLayoutName.Text = qs2.core.language.sqlLanguage.getRes("Layouts")

            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.cboLay.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.LayoutNameColumn.ColumnName).Hidden = False
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.LayoutNameColumn.ColumnName).Width = 380
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Width = 220

            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.AllUsersColumn.ColumnName).Hidden = False
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.CreateAtColumn.ColumnName).Hidden = False
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.CreateFromColumn.ColumnName).Hidden = False
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Hidden = False

            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.LayoutNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("LayoutName")
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.AllUsersColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("AllUsers")
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.CreateFromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("CreatedUser")
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.CreateAtColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Created")
            Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key")

            Me.btnOpenLayoutManager.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.btnDeleteSelection.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Dim infoToolTip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("DeleteSelectionFromComboBox")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnDeleteSelection, infoToolTip)

            infoToolTip = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoToolTip.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("")
            infoToolTip.ToolTipText = qs2.core.language.sqlLanguage.getRes("ManageLayouts")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnOpenLayoutManager, infoToolTip)

            Me.PanelDeleteSelectionLayoutManager.Visible = ShowDeleteSelection
            If Not ShowDeleteSelection Then
                Me.PanelDeleteSelectionLayoutManager.Width = 0
            End If

            If ExtendedView Then
                Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Hidden = False
            Else
                Me.cboLay.DisplayLayout.Bands(0).Columns(Me.DsLayout1.Layout.KeyColumn.ColumnName).Hidden = True
            End If

            'Me.cboLay.Enabled = ManageMode

        Catch ex As Exception
            Throw New Exception("cboLayout.initControl: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub LoadData()
        Try
            Me.DsLayout1.Clear()
            Me.CompLayout1.getLayout(Me.DsLayout1, "", compLayout.eSelLayoutGrid.All, Nothing, "")
            Me.cboLay.Refresh()

            Me.cboLay.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cboLay.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsLayout1.Layout.LayoutNameColumn.ColumnName, False)

            'If Not Me.rGuidLastSelectedLayout = Nothing Then
            '    Me.SelectLayout(rGuidLastSelectedLayout)
            '    If Not Me.delonValueChanged Is Nothing Then
            '        Me.delonValueChanged.Invoke()
            '    End If
            'End If

        Catch ex As Exception
            Throw New Exception("cboLayout.LoadData: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Sub ClearData()
        Try
            Me.DsLayout1.Clear()
            Me.cboLay.Refresh()

        Catch ex As Exception
            Throw New Exception("cboLayout.ClearData: " + ex.ToString())
        Finally
        End Try
    End Sub

    Public Sub SelectLayout(ByRef IDLayout As System.Guid)
        Try
            Me.cboLay.Value = IDLayout
            If Not Me.cboLay.SelectedRow Is Nothing Then
                'Dim v As DataRowView = Me.cboLay.SelectedRow.ListObject
                'Dim rLayout As dsLayout.LayoutRow = v.Row
            End If

            'Me.rGuidLastSelectedLayout = IDLayout

        Catch ex As Exception
            Throw New Exception("cboLayout.SelectLayout: " + ex.ToString())
        Finally
        End Try
    End Sub
    Public Function getSelectedRow(ByVal msgBox As Boolean) As dsLayout.LayoutRow
        Try
            If Not Me.cboLay.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.cboLay.ActiveRow.ListObject
                Dim rSelLayout As dsLayout.LayoutRow = v.Row
                Return rSelLayout
            Else
                If msgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected"), Windows.Forms.MessageBoxButtons.OK, _
                                                    qs2.core.language.sqlLanguage.getRes("Sort"))
                End If
            End If

        Catch ex As Exception
            Throw New Exception("cboLayout.getSelectedRow: " + ex.ToString())
        End Try
    End Function

    Private Sub cboLay_ValueChanged(sender As Object, e As EventArgs) Handles cboLay.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.cboLay.Focused Then
                Me.lastIDLayoutSelected = Me.cboLay.Value
                If Not Me.delonValueChanged Is Nothing Then
                    Me.delonValueChanged.Invoke()
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnDeleteSelection_Click(sender As Object, e As EventArgs) Handles btnDeleteSelection.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.DeleteSelection()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub DeleteSelection()
        Try
            Me.cboLay.Value = Nothing

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub OpenLayoutManager()
        Try
            Dim frmLayoutGrid As New qs2.core.vb.frmLayoutManager()
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1._LayoutKey = ""
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1.gridUIToSave = Nothing
            frmLayoutGrid.ContLayoutGrid1.cLayoutManager1.typLayoutGrid = cLayoutManager.eTypLayoutGrid.onlyFirstBand
            frmLayoutGrid.initControl("", True, "", Me._ExtendedView)
            frmLayoutGrid.ShowDialog(Me)
            Me.LoadData()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnOpenLayoutManager_Click(sender As Object, e As EventArgs) Handles btnOpenLayoutManager.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.OpenLayoutManager()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
End Class
