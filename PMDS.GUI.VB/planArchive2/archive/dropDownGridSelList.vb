Imports Infragistics.Win.UltraWinGrid



Public Class dropDownGridSelList

    Public gen As New General()
    Public isLoaded As Boolean = False
    Public doUI1 As New doUI()





    Private Sub droDownSelList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl(Optional ByVal translate As Boolean = True, Optional ByVal onlyComponents As Boolean = False)
        Try
            If Me.isLoaded Then Return

            Dim newRessourcesAdded As Integer = 0
            If translate Then
                Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
            End If
            If onlyComponents Then
                Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)
            End If

            For Each col As UltraGridColumn In Me.dropDownSelList.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.dropDownSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.DescriptionColumn.ColumnName).Hidden = False
            Me.dropDownSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.IDOwnIntColumn.ColumnName).Hidden = False

            Me.dropDownSelList.DisplayLayout.Override.ActiveRowAppearance.BackColor = General.color_standardBlue
            Me.dropDownSelList.DisplayLayout.Override.SelectedRowAppearance.BackColor = General.color_standardBlue
            Me.dropDownSelList.DisplayLayout.Override.SelectedRowAppearance.BackColor = General.color_standardBlue

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("dropDownGridSelList.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadSelLists(ByVal gruppe As String, ByVal typKey As General.eKeyCol)
        Try
            If typKey = General.eKeyCol.IDNr Then
                Me.dropDownSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDOwnIntColumn.ColumnName
            ElseIf typKey = General.eKeyCol.IDStr Then
                Me.dropDownSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDOwnStrColumn.ColumnName
            ElseIf typKey = General.eKeyCol.Guid Then
                Me.dropDownSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDGuidColumn.ColumnName
            ElseIf typKey = General.eKeyCol.Description Then
                Me.dropDownSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.DescriptionColumn.ColumnName
            End If

            Me.DsAuswahllisten1.SelListHelper.Clear()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.gen.loadSelList(Nothing, Nothing, gruppe, tSelListEntriesReturn, typKey, MaxIDSelListEntryReturn)
            gen.loadDSSelListHelper(tSelListEntriesReturn, Me.DsAuswahllisten1)
            Me.dropDownSelList.Refresh()

        Catch ex As Exception
            Throw New Exception("dropDownGridSelList.loadSelLists: " + ex.ToString())
        End Try
    End Sub

End Class
