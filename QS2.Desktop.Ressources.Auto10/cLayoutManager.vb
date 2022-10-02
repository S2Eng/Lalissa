Imports Infragistics.Win.UltraWinGrid
Imports QS2.core.vb
Imports QS2.core
Imports S2Extensions

Public Class cLayoutManager2

    Public _LayoutKey As String = ""
    Public gridUIToSave As Infragistics.Win.UltraWinGrid.UltraGrid = Nothing

    Public Sub initControl()
        Try

        Catch ex As Exception
            Throw New Exception("cLayoutManager.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Function doLayoutGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal Key As String,
                                 dsLayoutForTest As dsManage, ByRef LayoutFound As Boolean,
                                 HideGroupByBox As Boolean, doAutoTranslate As Boolean, AutoAddNewRessources As Boolean)
        Dim sExcept As String = ""
        compSql.iCouterException = 0
        Try
            Dim compLayoutRun As New compSql()
            compLayoutRun.initControl()
            Dim dsLayoutRun As New dsManage()
            Dim rLayout As dsManage.LayoutRow = Nothing

            Dim DoGridLayout As Boolean = False
            If Not dsLayoutForTest Is Nothing Then
                dsLayoutRun = dsLayoutForTest
                rLayout = dsLayoutForTest.Layout.Rows(0)
                DoGridLayout = True
                LayoutFound = True
            Else
                compLayoutRun.getLayout(dsLayoutRun, "", Nothing, Key.Trim())
                If dsLayoutRun.Layout.Rows.Count > 1 Then
                    Throw New Exception("doLayoutGrid: dsLayoutGridRun.Layout.Rows.Count > 1! LayoutKey'" + Key.Trim() + "'!")
                ElseIf dsLayoutRun.Layout.Rows.Count = 1 Then
                    rLayout = dsLayoutRun.Layout.Rows(0)
                    compLayoutRun.getLayoutGrid(rLayout.IDGuid, dsLayoutRun)
                    For Each columnFound As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
                        columnFound.Hidden = True
                    Next
                    DoGridLayout = True
                    LayoutFound = True
                End If
            End If

            For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                For Each columnFound As UltraGridColumn In bandFound.Columns
                    If doAutoTranslate Then
                        If compLayout.sqlLanguageUpdate Is Nothing Then
                            compLayout.sqlLanguageUpdate = New QS2.core.language.sqlLanguage()
                            compLayout.sqlLanguageUpdate.initControl()
                            compLayout.dsLanguageUpdate = New QS2.core.language.dsLanguage()
                        End If

                        Dim IDRes As String = ""
                        If grid.Parent Is Nothing Then
                            IDRes = grid.Name.Trim() + "_" + columnFound.Key.Trim()
                        Else
                            IDRes = grid.Name.Trim() + "_" + grid.Parent.Name.Trim() + "_" + columnFound.Key.Trim()
                        End If

                        compLayout.dsLanguageUpdate.Clear()
                        Dim translatedTxt As String = ""
                        Dim rRes As QS2.core.language.dsLanguage.RessourcenRow
                        translatedTxt = QS2.core.language.sqlLanguage.getRes(IDRes, core.Enums.eResourceType.Label, QS2.core.license.doLicense.eApp.ALL.ToString(),
                                                                                             QS2.core.license.doLicense.rApplication.IDApplication.Trim(), rRes, False, False)

                        If IsNothing(rRes) Then
                            If AutoAddNewRessources Then
                                Dim b As New QS2.core.vb.businessFramework()
                                b.addNewResAuto(IDRes, QS2.core.Enums.eResourceType.Label, "", columnFound.Header.Caption.Trim(), "", rRes)
                                If Not compLayout.DoNotShowRessources Then
                                    translatedTxt = columnFound.Header.Caption.Trim()
                                End If
                            End If
                        End If

                        If compLayout.DoNotShowRessources And Not IsNothing(rRes) Then
                            translatedTxt = ""
                        End If
                        columnFound.Header.Caption = translatedTxt.Trim()
                    End If
                Next
            Next

            If DoGridLayout Then
                Me.PrepareGrid(grid, rLayout)
                ' Do Sort Columns in all Bands, With and Visible Y/N
                Dim lastBandIndex As Integer = -1
                Dim ActuellVisiblePosition As Integer = -1
                Dim arrLayoutGrid() As dsManage.LayoutGridsRow = dsLayoutRun.LayoutGrids.Select("", "Sort asc")
                For Each rLayoutGirdFound As dsManage.LayoutGridsRow In arrLayoutGrid
                    If rLayoutGirdFound.RowState <> DataRowState.Deleted Then
                        Dim bColumnDone As Boolean = False
                        For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                            Dim BandIndex As Integer = 0
                            If Not rLayoutGirdFound Is Nothing Then
                                BandIndex = rLayoutGirdFound.Band
                            End If
                            If bandFound.Index.Equals(BandIndex) Then
                                For Each columnFound As UltraGridColumn In bandFound.Columns
                                    Try
                                        If Not columnFound.DataType.Name.Equals("ChapteredColumnType", StringComparison.CurrentCultureIgnoreCase) Then
                                            If columnFound.Key.Trim().ToLower().Equals(rLayoutGirdFound.ColumnName.Trim().ToLower()) Then
                                                sExcept = rLayoutGirdFound.ColumnName.Trim()
                                                ActuellVisiblePosition += 1
                                                columnFound.ResetRowLayoutColumnInfo()

                                                columnFound.Header.VisiblePosition = ActuellVisiblePosition
                                                If rLayoutGirdFound.ColumnCaption.Trim() <> "" Then
                                                    If Not doAutoTranslate Then
                                                        columnFound.Header.Caption = rLayoutGirdFound.ColumnCaption.Trim()
                                                    End If
                                                End If

                                                If rLayoutGirdFound.Visible Then
                                                    columnFound.Hidden = False
                                                Else
                                                    columnFound.Hidden = True
                                                End If

                                                Dim ColumnAutoSizeMode As New ColumnAutoSizeMode()
                                                If rLayout.AutoSizeWidthColumns Then
                                                    ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
                                                    columnFound.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
                                                    columnFound.AutoSizeMode = ColumnAutoSizeMode
                                                    columnFound.PerformAutoResize()
                                                Else
                                                    ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.None
                                                    columnFound.PerformAutoResize()
                                                    If rLayoutGirdFound.ColumnWith > 0 Then
                                                        columnFound.Width = rLayoutGirdFound.ColumnWith
                                                    End If
                                                End If

                                                If rLayoutGirdFound.AutoSizeHeigthColumn Then
                                                    columnFound.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
                                                Else
                                                    columnFound.CellMultiLine = Infragistics.Win.DefaultableBoolean.False
                                                End If

                                                If rLayoutGirdFound.ColMinHeigth > 0 Then
                                                End If
                                                If rLayoutGirdFound.ColMaxHeigth > 0 Then
                                                End If

                                                If Not rLayoutGirdFound.IsTypeUINull() Then
                                                    Dim ColStyleUI As Infragistics.Win.UltraWinGrid.ColumnStyle = rLayoutGirdFound.TypeUI       'qs2.core.generic.searchEnumColumnStyleInfragistics(rLayoutGirdFound.TypeUI.Trim())
                                                    columnFound.Style = ColStyleUI
                                                Else
                                                    columnFound.Style = ColumnStyle.Default
                                                End If
                                            End If
                                        End If

                                    Catch ex As Exception
                                        Throw New Exception("cLayoutManager.doLayoutGrid for each - : " + vbNewLine + ex.ToString())
                                    End Try
                                Next
                            End If
                            lastBandIndex = bandFound.Index
                        Next
                    End If
                Next

                ' Do OrderBy and Group-By in all Bands
                Dim lstBandsWhereOrderByFound As New System.Collections.Generic.List(Of Integer)
                Dim lstBandsWhereGroupByFound As New System.Collections.Generic.List(Of Integer)
                Dim lstColumnOrderBy As New System.Collections.Generic.List(Of dsManage.LayoutGridsRow)
                For Each rLayoutGirdFound As dsManage.LayoutGridsRow In arrLayoutGrid
                    If rLayoutGirdFound.RowState <> DataRowState.Deleted Then
                        For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                            If bandFound.Index.Equals(rLayoutGirdFound.Band) Then

                                For Each columnFound As UltraGridColumn In bandFound.Columns
                                    If columnFound.Key.Trim().ToLower().Equals(rLayoutGirdFound.ColumnName.Trim().ToLower()) Then
                                        If rLayoutGirdFound.Visible And (rLayoutGirdFound.OrderBy Or rLayoutGirdFound.GroupBy) Then
                                            lstColumnOrderBy.Add(rLayoutGirdFound)

                                            Dim bBandInexExists As Boolean = False
                                            For Each bandIndexFoundInList As Integer In lstBandsWhereOrderByFound
                                                If bandIndexFoundInList.Equals(bandFound.Index) Then
                                                    bBandInexExists = True
                                                End If
                                            Next
                                            If Not bBandInexExists Then
                                                lstBandsWhereOrderByFound.Add(bandFound.Index)
                                            End If

                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next

                ' Group by
                For Each bandIndex As Integer In lstBandsWhereOrderByFound
                    grid.DisplayLayout.Bands(bandIndex).SortedColumns.Clear()
                Next
                Dim bGroupByFound As Boolean = False
                For Each rLayoutGirdFound As dsManage.LayoutGridsRow In lstColumnOrderBy
                    If rLayoutGirdFound.GroupBy Then
                        bGroupByFound = True
                    End If
                Next
                If bGroupByFound Then
                    grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
                Else
                    If rLayout.ShowAlwaysGroupBy Then
                        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
                    Else
                        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical
                    End If
                End If
                If lstBandsWhereOrderByFound.Count > 0 Then
                    For Each rLayoutGirdFound As dsManage.LayoutGridsRow In lstColumnOrderBy
                        grid.DisplayLayout.Bands(rLayoutGirdFound.Band).SortedColumns.Add(rLayoutGirdFound.ColumnName.Trim(), rLayoutGirdFound.Desc, rLayoutGirdFound.GroupBy)
                        If grid.DisplayLayout.Bands(rLayoutGirdFound.Band).Columns.Exists(rLayoutGirdFound.ColumnName.Trim()) Then
                            If rLayoutGirdFound.GroupBy Then
                                grid.DisplayLayout.Bands(rLayoutGirdFound.Band).Columns(rLayoutGirdFound.ColumnName.Trim()).Hidden = True
                            End If
                        End If
                    Next
                End If

                grid.Refresh()
            End If

            compSql.iCouterException = 0
            Return True

        Catch ex As Exception
            compSql.iCouterException = 0
            Throw New Exception("cLayoutManager.doLayoutGrid: Info Except:" + sExcept + vbNewLine + ex.ToString())
        End Try
    End Function

    Private Function PrepareGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, rLayout As dsManage.LayoutRow)
        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None

            If rLayout.AutoFitStyleGrid <> Nothing Then
                If rLayout.AutoFitStyleGrid.sEquals(QS2.core.ui.eAutoFitStyle.None) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                ElseIf rLayout.AutoFitStyleGrid.sEquals(QS2.core.ui.eAutoFitStyle.ExtendLastColumn) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
                ElseIf rLayout.AutoFitStyleGrid.sEquals(QS2.core.ui.eAutoFitStyle.ResizeAllColumns) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If
            End If

            Dim ColumnAutoSizeMode As New ColumnAutoSizeMode()
            If rLayout.AutoSizeWidthColumns Then
                ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
            Else
                ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.None
            End If
            grid.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode

            grid.DisplayLayout.Override.ColumnSizingArea = ColumnSizingArea.EntireColumn
            grid.DisplayLayout.Override.AllowColMoving = AllowColMoving.WithinGroup
            grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed
            grid.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            grid.DisplayLayout.Override.RowSizingArea = RowSizingArea.EntireRow
            If rLayout.GridAutoNewline Then
                grid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree
            Else
                grid.DisplayLayout.Override.RowSizing = RowSizing.Free
            End If
            grid.DisplayLayout.Bands(0).Override.ColumnAutoSizeMode = ColumnAutoSizeMode

            grid.DisplayLayout.Bands(0).Override.ColumnSizingArea = ColumnSizingArea.EntireColumn
            grid.DisplayLayout.Bands(0).Override.AllowColMoving = AllowColMoving.WithinGroup
            grid.DisplayLayout.Bands(0).Override.AllowColSwapping = AllowColSwapping.NotAllowed
            grid.DisplayLayout.Bands(0).Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            grid.DisplayLayout.Bands(0).Override.RowSizingArea = RowSizingArea.EntireRow
            If rLayout.GridAutoNewline Then
                grid.DisplayLayout.Bands(0).Override.RowSizing = RowSizing.AutoFree
            Else
                grid.DisplayLayout.Bands(0).Override.RowSizing = RowSizing.Free
            End If

            grid.DisplayLayout.Override.SupportDataErrorInfo = SupportDataErrorInfo.RowsAndCells

            grid.DisplayLayout.Override.AllowColSizing = AllowColSizing.Free
            grid.DisplayLayout.Bands(0).Override.AllowColSizing = AllowColSizing.Free

            grid.DisplayLayout.Override.DefaultColWidth = 120
            grid.DisplayLayout.Bands(0).Override.DefaultColWidth = 120

            If rLayout.CaptionVisible Then
                grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True
            Else
                grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False
            End If

            For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                bandFound.ResetRowLayoutStyle()
                For Each columnFound As UltraGridColumn In bandFound.Columns
                    columnFound.ResetRowLayoutColumnInfo()
                    columnFound.AutoSizeMode = ColumnAutoSizeMode
                Next
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.PrepareGrid: " + vbNewLine + ex.ToString())
        End Try
    End Function
End Class
