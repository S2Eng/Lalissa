Imports Infragistics.Win.UltraWinGrid
Imports qs2.core.vb
Imports qs2.sitemap




Public Class contCboSelList

    Public isLoaded As Boolean = False

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public rGroup As dsAdmin.tblSelListGroupRow = Nothing
    Public IDApplication As String = ""
    Public IDParticipant As String = ""
    Public IDGroupStr As String = ""
    Public _UserEntry As Boolean = False





    Public Sub initControl(ByVal alwaysQuickButton As Boolean, ByVal dontShowQuickButton As Boolean,
                           ByRef ComboStyle As UltraComboStyle)
        Try
            If Me.isLoaded Then Return

            Me.cboSelList.DropDownStyle = ComboStyle

            Me.SqlAdmin1.initControl()

            Me.ImageListSmall.Images.Clear()
            Me.ImageListSmall.Images.Add(qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Plus, 32, 32))
            Me.cboSelList.ButtonsRight(0).Appearance.Image = Me.ImageListSmall.Images(0)

            For Each col As UltraGridColumn In Me.cboSelList.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next
            Me.cboSelList.DropDownStyle = ComboStyle

            Me.cboSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
            'Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Hidden = False
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Hidden = False
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Hidden = False
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Hidden = False

            Me.cboSelList.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Designation")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IDRessource")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Created")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.CreatedUserColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("CreatedUser")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.IDOwnIntColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("ID")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrFromColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionFrom")
            Me.cboSelList.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListEntries.VersionNrToColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("VersionTo")

            Me.DeleteSelectionToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("DeleteSelection")

            If alwaysQuickButton Then
                Me.cboSelList.ButtonsRight(0).Visible = True
            ElseIf dontShowQuickButton Then
                Me.cboSelList.ButtonsRight(0).Visible = False
            Else
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.cboSelList.ButtonsRight(0).Visible = True
                Else
                    Me.cboSelList.ButtonsRight(0).Visible = False
                End If
            End If

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadGroup()
        Try
            Me.rGroup = Me.SqlAdmin1.getSelListGroupRow(Me.IDGroupStr, Me.IDParticipant, Me.IDApplication)
            If Me.rGroup Is Nothing Then
                Throw New Exception("initControl: IDGroup '" + Me.IDGroupStr + "' not found!")
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadData()
        Try
            Me.loadGroup()

            Me.DsAdmin1.Clear()
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.SqlAdmin1.getSelListEntrys(Parameters, "", qs2.core.license.doLicense.rParticipant.IDParticipant, qs2.core.license.doLicense.rApplication.IDApplication, Me.DsAdmin1, sqlAdmin.eTypAuswahlList.IDGroupParticipantAndAll, "", -999, "", rGroup.ID)
            Me.cboSelList.Refresh()

            For Each rGridSelEntry As UltraGridRow In Me.cboSelList.Rows
                Dim v As DataRowView = rGridSelEntry.ListObject
                Dim rSelEntry As dsAdmin.tblSelListEntriesRow = v.Row
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rSelEntry.IDRessource, rGroup.IDParticipant, rGroup.IDApplication)
                If resFound.Trim() = "" Then
                    rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = rSelEntry.IDRessource
                Else
                    rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = resFound
                End If
            Next

            Me.cboSelList.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cboSelList.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)
            Me.cboSelList.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsAdmin1.tblSelListEntries.IDRessourceColumn.ColumnName, False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub cboComboBoxSelList_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cboSelList.EditorButtonClick
        Try
        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub cboComboBoxSelList_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSelList.ValueChanged
        Try
            If Me.cboSelList.Focused Then
                If Not Me.delonValueChanged Is Nothing Then
                    Me.delonValueChanged.Invoke()
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub clearSelection()
        'Me.cboComboBoxSelList.Value = Nothing
        Me.cboSelList.SelectedRow = Nothing
        Me.cboSelList.ActiveRow = Nothing
        Me.cboSelList.Text = ""

        Me.cboSelList.Refresh()
    End Sub

    Private Sub DeleteSelectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteSelectionToolStripMenuItem.Click
        Try
            Me.clearSelection()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
End Class
