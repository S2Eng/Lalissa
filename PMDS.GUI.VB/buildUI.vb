Imports System.Windows.Forms

Imports Infragistics.Win
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinTree

Imports System.Drawing

Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinGrid




Public Class buildUI



    Public Function clearPopUp(ByRef iTools As ToolsCollection) As Boolean
        Try
            Dim arrRemov As New ArrayList
            For Each Tool In iTools
                arrRemov.Add(Tool)
            Next

            For Each tb As ToolBase In arrRemov
                iTools.Remove(tb)
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("clearPopUp: " + ex.ToString())
        End Try
    End Function

    Public Sub setFilterGridKomplex(ByVal grd As UltraGrid, ByVal bIsOn As Boolean, ByVal doSplitterFunctions As Boolean,
                                    ByVal setMergeOn As Boolean)
        Try
            If bIsOn Then
                grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
                grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                grd.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden
                grd.DisplayLayout.Override.FilterRowPrompt = "Hier klicken um Daten zu filtern"
                grd.DisplayLayout.Override.FilterRowAppearance.ForeColor = Color.DarkGray
                grd.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.White
                grd.DisplayLayout.Override.FilterRowAppearance.FontData.Bold = DefaultableBoolean.False
                grd.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo
                grd.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.Row
                grd.DisplayLayout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Contains
                grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
                grd.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
                grd.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.None
                'grd.DisplayLayout.Override.GroupByColumnsHidden = DefaultableBoolean.Default
                'grd.DisplayLayout.Override.GroupByRowExpansionStyle = GroupByRowExpansionStyle.Default
                'grd.DisplayLayout.Override.GroupByRowInitialExpansionState = GroupByRowInitialExpansionState.Default
                '      grd.DisplayLayout.Override.GroupBySummaryDisplayStyle = 
                grd.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
                ' grd.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.LightSteelBlue
                Me.setMergeStyle(grd, setMergeOn, doSplitterFunctions)
                'grd.DisplayLayout.Override.FilterRowPromptAppearance.FontData.SizeInPoints = 10
                grd.DisplayLayout.Override.FilterRowPromptAppearance.ForeColor = Color.DarkGray

            Else
                grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            End If

        Catch ex As Exception
            Throw New Exception("setFilterGridKomplex: " + ex.ToString())
        End Try
    End Sub
    Public Sub setMergeStyle(ByVal grd As UltraGrid, ByVal setMergeOn As Boolean, ByVal doSplitterFunctions As Boolean)
        Try
            If setMergeOn Then
                grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
                grd.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.Beige
            Else
                grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
            End If

            grd.DisplayLayout.Override.RowSizing = RowSizing.Free
            grd.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True

            If doSplitterFunctions Then
                grd.DisplayLayout.MaxColScrollRegions = 2
                grd.DisplayLayout.MaxRowScrollRegions = 2
            Else
                grd.DisplayLayout.MaxColScrollRegions = 1
                grd.DisplayLayout.MaxRowScrollRegions = 1
            End If

        Catch ex As Exception
            Throw New Exception("setMergeStyle: " + ex.ToString())
        End Try
    End Sub

End Class

