Imports Infragistics.Win.UltraWinGrid
Imports qs2.core.vb
Imports qs2.sitemap
Imports qs2.Resources



Public Class contCboGroup

    Public isLoaded As Boolean = False

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public IDApplication As String = ""
    Public IDParticipant As String = ""

    Public _Typ As New eTyp()
    Public Enum eTyp
        SelListUsr = 0

    End Enum




    Public Sub initControl(typ As eTyp)
        Try
            If Me.isLoaded Then Return

            Me._Typ = typ
            Me.cboGroup.DropDownStyle = UltraComboStyle.DropDownList

            Me.SqlAdmin1.initControl()

            For Each col As UltraGridColumn In Me.cboGroup.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.cboGroup.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Hidden = False
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDParticipantColumn.ColumnName).Hidden = False
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDApplicationColumn.ColumnName).Hidden = False
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName).Hidden = False

            Me.cboGroup.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameText).Header.Caption = qs2.core.language.sqlLanguage.getRes("Group")
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDParticipantColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Participant")
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDApplicationColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Application")
            Me.cboGroup.DisplayLayout.Bands(0).Columns(Me.DsAdmin1.tblSelListGroup.IDGroupStrColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Key")

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadGroups()
        Try
            Me.DsAdmin1.Clear()

            If Me._Typ = eTyp.SelListUsr Then
                Me.SqlAdmin1.getSelListGroup(Me.DsAdmin1, sqlAdmin.eTypSelGruppen.SelListUsr, "", Me.IDParticipant, Me.IDApplication, 0, "SelListUsr")
            Else
                Throw New Exception("loadGroup: _Typ '" + Me._Typ.ToString() + "' not supported!")
            End If
            Me.cboGroup.Refresh()

            For Each rGridSelEntry As UltraGridRow In Me.cboGroup.Rows
                Dim v As DataRowView = rGridSelEntry.ListObject
                Dim rGroup As dsAdmin.tblSelListGroupRow = v.Row
                Dim resFound As String = qs2.core.language.sqlLanguage.getRes(rGroup.IDRessource, rGroup.IDParticipant, rGroup.IDApplication)
                If resFound.Trim() = "" Then
                    rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = rGroup.IDRessource
                Else
                    rGridSelEntry.Cells(qs2.core.generic.columnNameText).Value = resFound
                End If
            Next

            Me.cboGroup.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cboGroup.DisplayLayout.Bands(0).SortedColumns.Add(qs2.core.generic.columnNameText, False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function getSelectedGroup(ByVal withMsgBox As Boolean) As dsAdmin.tblSelListGroupRow
        Try
            If Not Me.cboGroup.ActiveRow Is Nothing Then
                If Me.cboGroup.ActiveRow.IsGroupByRow Or Me.cboGroup.ActiveRow.IsFilterRow Then
                    If withMsgBox Then
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                        Me.cboGroup.Focus()
                    End If
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.cboGroup.ActiveRow.ListObject
                    Dim rSelGroup As dsAdmin.tblSelListGroupRow = v.Row
                    Return rSelGroup
                End If
            Else
                If withMsgBox Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoEntrySelected") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                    Me.cboGroup.Focus()
                End If
                Return Nothing
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Private Sub cboComboBoxSelList_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.ValueChanged
        Try
            If Me.cboGroup.Focused Then
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
        Me.cboGroup.SelectedRow = Nothing
        Me.cboGroup.ActiveRow = Nothing
        Me.cboGroup.Text = ""

        Me.cboGroup.Refresh()
    End Sub


End Class
