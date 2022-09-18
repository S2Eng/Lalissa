Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid
Imports VB = Microsoft.VisualBasic



Public Class compLayout

    Public Shared selLayout As String = ""
    Public Shared selLayoutGrid As String = ""
    Public database As New qs2.core.dbBase


    Public Enum eSelLayoutGrid
        Grid = 92300
        LayoutName = 92301
        IDLayout = 92302
        All = 92303
        KeyNotIDGuid = 92304
        LayoutNameNotIDGuid = 92305
        Key = 92306
    End Enum

    Public Class cLoadedLayout
        Public LayoutFrom As Date = Nothing
        Public IsLoaded As Boolean = False
    End Class

    Public Shared dsLanguageUpdate As qs2.core.language.dsLanguage = Nothing
    Public Shared sqlLanguageUpdate As qs2.core.language.sqlLanguage = Nothing
    Public Shared DoNotShowRessources As Boolean = False

    Public Shared iCouterException As Integer = 0







    Public Sub initControl()
        compLayout.selLayout = Me.daLayout.SelectCommand.CommandText
        compLayout.selLayoutGrid = Me.daLayoutGrid.SelectCommand.CommandText
    End Sub


    Public Function getLayout(ByRef dsLayout As dsLayout, ByVal LayoutName As String,
                         ByVal TypSel As eSelLayoutGrid, ByVal IDGuid As System.Guid,
                         ByVal key As String) As Boolean
        Try
            Me.daLayout.SelectCommand.CommandText = compLayout.selLayout
            Me.database.setConnection(Me.daLayout)
            Me.daLayout.SelectCommand.Parameters.Clear()
            Me.daLayout.SelectCommand.Parameters.Clear()

            If TypSel = eSelLayoutGrid.LayoutName Then
                Dim sWhere As String = " where LayoutName = @LayoutName "
                Me.daLayout.SelectCommand.CommandText += sWhere
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@LayoutName", LayoutName.Trim())

            ElseIf TypSel = eSelLayoutGrid.Key Then
                Dim sWhere As String = " where [Key] = @Key "
                Me.daLayout.SelectCommand.CommandText += sWhere
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@Key", key.Trim())

            ElseIf TypSel = eSelLayoutGrid.IDLayout Then
                Dim sWhere As String = " where IDGuid = @IDGuid "
                Me.daLayout.SelectCommand.CommandText += sWhere
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@IDGuid", IDGuid)

            ElseIf TypSel = eSelLayoutGrid.LayoutNameNotIDGuid Then
                Dim sWhere As String = " where LayoutName = @LayoutName and IDGuid <> @IDGuid"
                Me.daLayout.SelectCommand.CommandText += sWhere
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@LayoutName", LayoutName.Trim())
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@IDGuid", IDGuid)

            ElseIf TypSel = eSelLayoutGrid.KeyNotIDGuid Then
                Dim sWhere As String = " where [Key] = @Key and IDGuid <> @IDGuid"
                Me.daLayout.SelectCommand.CommandText += sWhere
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@Key", key.Trim())
                Me.daLayout.SelectCommand.Parameters.AddWithValue("@IDGuid", IDGuid)

            ElseIf TypSel = eSelLayoutGrid.All Then
                Dim xy As String = ""

            Else
                Throw New Exception("compLayout.getLayout: TypSel '" + TypSel.ToString() + "' is wrong!")
            End If

            Me.daLayout.Fill(dsLayout.Layout)
            compLayout.iCouterException = 0
            Return True

        Catch ex As Exception
            If Me.checkExceptionOpendDataReader(ex.ToString()) Then
                Me.getLayout(dsLayout, LayoutName, TypSel, IDGuid, key)
                Return True
            Else
                compLayout.iCouterException = 0
                Throw New Exception("compLayout.getLayout: " + ex.ToString())
            End If
        End Try
    End Function
    Public Function newLayout(ByRef dsLayout1 As dsLayout) As dsLayout.LayoutRow

        Dim rNew As dsLayout.LayoutRow = dsLayout1.Layout.NewRow()
        rNew.IDGuid = System.Guid.NewGuid
        rNew.LayoutName = ""
        rNew.AllUsers = True
        rNew.CreateFrom = qs2.core.vb.actUsr.rUsr.UserName
        rNew.CreateAt = Now
        rNew.Key = ""
        rNew.GridRowMinHeigth = -1
        rNew.GridRowMaxHeigth = -1

        rNew.AutoFitStyleGrid = ""
        rNew.GridAutoNewline = False
        rNew.ShowAlwaysGroupBy = False
        rNew.CaptionVisible = False
        rNew.AutoSizeWidthColumns = False

        dsLayout1.Layout.Rows.Add(rNew)
        Return rNew

    End Function
    Public Function deleteLayout(ByVal Key As String) As Boolean

        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " delete from " + qs2.core.dbBase.dbSchema + "Layout where [Key] = '" + Key.Trim() + "' "
        cmd.Connection = database.dbConn
        cmd.ExecuteNonQuery()
        Return True

    End Function
    Public Function deleteLayoutGrid(ByVal IDLayout As System.Guid) As Boolean

        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " delete from " + qs2.core.dbBase.dbSchema + "LayoutGrids where IDLayout = '" + IDLayout.ToString() + "' "
        cmd.Connection = database.dbConn
        cmd.ExecuteNonQuery()
        Return True

    End Function
    Public Function deleteLayout(ByVal IDGuid As System.Guid) As Boolean

        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " delete from " + qs2.core.dbBase.dbSchema + "Layout where IDGuid = '" + IDGuid.ToString() + "' "
        cmd.Connection = database.dbConn
        cmd.ExecuteNonQuery()
        Return True

    End Function

    Public Function getLayoutGrid(ByVal IDLayout As System.Guid, ByRef dsLayoutGrid1 As dsLayout,
                             ByVal TypSel As eSelLayoutGrid) As Boolean
        Try
            Me.daLayoutGrid.SelectCommand.CommandText = compLayout.selLayoutGrid
            Me.database.setConnection(Me.daLayoutGrid)
            Me.daLayoutGrid.SelectCommand.Parameters.Clear()

            If TypSel = eSelLayoutGrid.Grid Then
                Dim sWhere As String = " where IDLayout = @IDLayout "
                Dim sOrderBy As String = " order by Band asc, Sort asc "
                Me.daLayoutGrid.SelectCommand.CommandText += sWhere + sOrderBy
                Me.daLayoutGrid.SelectCommand.Parameters.AddWithValue("@IDLayout", IDLayout)

            Else
                Throw New Exception("compLayout.getLayoutGrid: TypSel '" + TypSel.ToString() + "' is wrong!")
            End If

            Me.daLayoutGrid.Fill(dsLayoutGrid1.LayoutGrids)
            compLayout.iCouterException = 0
            Return True

        Catch ex As Exception
            If Me.checkExceptionOpendDataReader(ex.ToString()) Then
                Me.getLayoutGrid(IDLayout, dsLayoutGrid1, TypSel)
                Return True
            Else
                compLayout.iCouterException = 0
                Throw New Exception("compLayout.getLayoutGrid: " + ex.ToString())
            End If
        End Try
    End Function

    Public Function newLayoutGrid(ByRef dsLayoutGrid1 As dsLayout, IDLayout As System.Guid) As dsLayout.LayoutGridsRow

        Dim rNew As dsLayout.LayoutGridsRow = dsLayoutGrid1.LayoutGrids.NewRow()
        rNew.IDGuid = System.Guid.NewGuid
        rNew.GridName = ""
        rNew.Band = 0
        rNew.ColumnName = ""
        rNew.OrderBy = False
        rNew.Desc = False
        rNew.Visible = True
        rNew.ColumnWith = -1
        rNew.GroupBy = False
        rNew.Sort = -1
        rNew.IDLayout = IDLayout
        rNew.GridAutoNewline = False
        rNew.TypeCol = ""
        rNew.AutoSizeHeigthColumn = False
        rNew.ColMinHeigth = -1
        rNew.ColMaxHeigth = -1
        rNew.ColumnCaption = ""
        rNew.SetTypeUINull()

        dsLayoutGrid1.LayoutGrids.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function doLayoutGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal Key As String,
                                 dsLayoutForTest As dsLayout, ByRef LayoutFound As Boolean,
                                 HideGroupByBox As Boolean, doAutoTranslate As Boolean, AutoAddNewRessources As Boolean)
        Try
            compLayout.iCouterException = 0
            If Me.DesignMode Then
                Exit Function
            End If

            Dim compLayoutRun As New compLayout()
            Dim dsLayoutRun As New dsLayout()
            Dim rLayout As dsLayout.LayoutRow = Nothing

            Dim DoGridLayout As Boolean = False
            If Not dsLayoutForTest Is Nothing Then
                dsLayoutRun = dsLayoutForTest
                rLayout = dsLayoutForTest.Layout.Rows(0)
                DoGridLayout = True
                LayoutFound = True
            Else
                compLayoutRun.getLayout(dsLayoutRun, "", compLayout.eSelLayoutGrid.Key, Nothing, Key.Trim())
                If dsLayoutRun.Layout.Rows.Count > 1 Then
                    Throw New Exception("doLayoutGrid: dsLayoutGridRun.Layout.Rows.Count > 1! LayoutKey'" + Key.Trim() + "'!")
                ElseIf dsLayoutRun.Layout.Rows.Count = 1 Then
                    rLayout = dsLayoutRun.Layout.Rows(0)
                    compLayoutRun.getLayoutGrid(rLayout.IDGuid, dsLayoutRun, compLayout.eSelLayoutGrid.Grid)
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
                            compLayout.sqlLanguageUpdate = New language.sqlLanguage()
                            compLayout.sqlLanguageUpdate.initControl()
                            compLayout.dsLanguageUpdate = New language.dsLanguage()
                        End If
                        Dim IDRes As String = ""
                        If grid.Parent Is Nothing Then
                            IDRes = grid.Name.Trim() + "_" + columnFound.Key.Trim()
                        Else
                            IDRes = grid.Name.Trim() + "_" + grid.Parent.Name.Trim() + "_" + columnFound.Key.Trim()
                        End If

                        compLayout.dsLanguageUpdate.Clear()
                        Dim IDResFound As Boolean = False
                        Dim translatedTxt As String = ""
                        'Dim ResourceTypeForAutoInsert As qs2.core.Enums.eResourceType
                        Dim rRes As qs2.core.language.dsLanguage.RessourcenRow
                        translatedTxt = qs2.core.language.sqlLanguage.getRes(IDRes, core.Enums.eResourceType.Label, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                                                             qs2.core.license.doLicense.rApplication.IDApplication.Trim(), rRes, False, False)
                        If rRes Is Nothing Then
                            IDResFound = False
                        Else
                            IDResFound = True
                        End If

                        If rRes Is Nothing Then
                            If AutoAddNewRessources Then
                                Dim b As New qs2.core.vb.businessFramework()
                                b.addNewResAuto(IDRes, Enums.eResourceType.Label, "", columnFound.Header.Caption.Trim(), "", rRes)
                                If Not compLayout.DoNotShowRessources Then
                                    translatedTxt = columnFound.Header.Caption.Trim()
                                End If
                            End If
                            'End If
                        End If

                        If compLayout.DoNotShowRessources And IDResFound Then
                            translatedTxt = ""
                        End If
                        columnFound.Header.Caption = translatedTxt.Trim()
                    End If
                Next
            Next

            If DoGridLayout Then
                Me.PrepareGrid(grid, rLayout)

                'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                'grid.DisplayLayout.Override.ColumnAutoSizeMode = ColumnAutoSizeMode.None
                'grid.DisplayLayout.Override.ColumnSizingArea = ColumnSizingArea.EntireColumn
                'grid.DisplayLayout.Override.AllowColMoving = AllowColMoving.WithinGroup
                'grid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.NotAllowed
                'grid.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
                'grid.DisplayLayout.Override.RowSizingArea = RowSizingArea.EntireRow
                'grid.DisplayLayout.Override.RowSizing = RowSizing.AutoFree

                'grid.DisplayLayout.Bands(0).Override.ColumnAutoSizeMode = ColumnAutoSizeMode.None
                'grid.DisplayLayout.Bands(0).Override.ColumnSizingArea = ColumnSizingArea.EntireColumn
                'grid.DisplayLayout.Bands(0).Override.AllowColMoving = AllowColMoving.WithinGroup
                'grid.DisplayLayout.Bands(0).Override.AllowColSwapping = AllowColSwapping.NotAllowed
                'grid.DisplayLayout.Bands(0).Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
                'grid.DisplayLayout.Bands(0).Override.RowSizingArea = RowSizingArea.EntireRow
                'grid.DisplayLayout.Bands(0).Override.RowSizing = RowSizing.AutoFree

                'grid.DisplayLayout.Override.AllowColSizing = AllowColSizing.Default
                'grid.DisplayLayout.Bands(0).Override.AllowColSizing = AllowColSizing.Default

                'grid.DisplayLayout.Override.DefaultColWidth = 120
                'grid.DisplayLayout.Bands(0).Override.DefaultColWidth = 120

                ' Do Sort Columns in all Bands, With and Visible Y/N
                Dim lastBandIndex As Integer = -1
                Dim ActuellVisiblePosition As Integer = -1
                Dim arrLayoutGrid() As dsLayout.LayoutGridsRow = dsLayoutRun.LayoutGrids.Select("", "Sort asc")
                For Each rLayoutGirdFound As dsLayout.LayoutGridsRow In arrLayoutGrid
                    If rLayoutGirdFound.RowState <> DataRowState.Deleted Then
                        Dim bColumnDone As Boolean = False
                        For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                            Dim BandIndex As Integer = 0
                            If Not rLayoutGirdFound Is Nothing Then
                                BandIndex = rLayoutGirdFound.Band
                            End If
                            If bandFound.Index.Equals(BandIndex) Then
                                For Each columnFound As UltraGridColumn In bandFound.Columns
                                    If columnFound.Key.Trim().ToLower().Equals(rLayoutGirdFound.ColumnName.Trim().ToLower()) Then
                                        ActuellVisiblePosition += 1
                                        columnFound.ResetRowLayoutColumnInfo()
                                        'columnFound.AutoSizeMode = ColumnAutoSizeMode.VisibleRows

                                        columnFound.Header.VisiblePosition = ActuellVisiblePosition
                                        If rLayoutGirdFound.ColumnCaption.Trim() <> "" Then
                                            If Not doAutoTranslate Then
                                                columnFound.Header.Caption = rLayoutGirdFound.ColumnCaption.Trim()
                                            End If

                                            'If doAutoTranslate Then
                                            '    If compLayout.sqlLanguageUpdate Is Nothing Then
                                            '        compLayout.sqlLanguageUpdate = New language.sqlLanguage()
                                            '        compLayout.sqlLanguageUpdate.initControl()
                                            '        compLayout.dsLanguageUpdate = New language.dsLanguage()
                                            '    End If
                                            '    Dim IDRes As String = ""
                                            '    If grid.Parent Is Nothing Then
                                            '        IDRes = grid.Name.Trim() + "_" + columnFound.Key.Trim()
                                            '    Else
                                            '        IDRes = grid.Name.Trim() + "_" + grid.Parent.Name.Trim() + "_" + columnFound.Key.Trim()
                                            '    End If

                                            '    compLayout.dsLanguageUpdate.Clear()
                                            '    Dim IDResFound As Boolean = False
                                            '    Dim translatedTxt As String = ""
                                            '    Dim ResourceTypeForAutoInsert As qs2.core.Enums.eResourceType
                                            '    Dim rRes As qs2.core.language.dsLanguage.RessourcenRow
                                            '    translatedTxt = qs2.core.language.sqlLanguage.getRes(IDRes, core.Enums.eResourceType.Label, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                            '                                                         qs2.core.license.doLicense.rApplication.IDApplication.Trim(), rRes, False, False)
                                            '    If rRes Is Nothing Then
                                            '        IDResFound = False
                                            '    Else
                                            '        IDResFound = True
                                            '    End If

                                            '    If rRes Is Nothing Then
                                            '        If AutoAddNewRessources Then
                                            '            Me.addNewResAuto(IDRes, Enums.eResourceType.Label, "", rLayoutGirdFound.ColumnCaption.Trim(), rRes)
                                            '            If Not compLayout.DoNotShowRessources Then
                                            '                translatedTxt = rLayoutGirdFound.ColumnCaption.Trim()
                                            '            End If
                                            '        End If
                                            '        'End If
                                            '    End If

                                            '    If compLayout.DoNotShowRessources Then
                                            '        translatedTxt = ""
                                            '    End If
                                            '    columnFound.Header.Caption = translatedTxt.Trim()
                                            'Else
                                            '    columnFound.Header.Caption = rLayoutGirdFound.ColumnCaption.Trim()
                                            'End If
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
                                            'columnFound.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
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
                                Next
                            End If
                            lastBandIndex = bandFound.Index
                            'ActuellVisiblePosition = -1
                        Next
                    End If
                Next

                ' Do OrderBy and Group-By in all Bands
                Dim lstBandsWhereOrderByFound As New System.Collections.Generic.List(Of Integer)
                Dim lstBandsWhereGroupByFound As New System.Collections.Generic.List(Of Integer)
                Dim lstColumnOrderBy As New System.Collections.Generic.List(Of dsLayout.LayoutGridsRow)
                For Each rLayoutGirdFound As dsLayout.LayoutGridsRow In arrLayoutGrid
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
                For Each rLayoutGirdFound As dsLayout.LayoutGridsRow In lstColumnOrderBy
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
                    For Each rLayoutGirdFound As dsLayout.LayoutGridsRow In lstColumnOrderBy
                        grid.DisplayLayout.Bands(rLayoutGirdFound.Band).SortedColumns.Add(rLayoutGirdFound.ColumnName.Trim(), rLayoutGirdFound.Desc, rLayoutGirdFound.GroupBy)
                        If grid.DisplayLayout.Bands(rLayoutGirdFound.Band).Columns.Exists(rLayoutGirdFound.ColumnName.Trim()) Then
                            If rLayoutGirdFound.GroupBy Then
                                grid.DisplayLayout.Bands(rLayoutGirdFound.Band).Columns(rLayoutGirdFound.ColumnName.Trim()).Hidden = True
                            End If
                        End If
                    Next
                End If

                ' Expand first Nodes
                Me.expandFirstGroupByRowInGrid(grid)
                grid.Refresh()
            End If

            compLayout.iCouterException = 0
            Return True

        Catch ex As Exception
            compLayout.iCouterException = 0
            Throw New Exception("compLayoutGrid.doLayoutGrid: " + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function PrepareGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, rLayout As dsLayout.LayoutRow)
        Try
            If grid.DisplayLayout Is Nothing Then
                'MsgBox("edd")
            End If

            If rLayout.AutoFitStyleGrid <> Nothing Then
                If rLayout.AutoFitStyleGrid.Trim().Equals("") Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                ElseIf rLayout.AutoFitStyleGrid.Trim().ToLower().Equals(qs2.core.ui.eAutoFitStyle.None.ToString().Trim().ToLower()) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
                ElseIf rLayout.AutoFitStyleGrid.Trim().ToLower().Equals(qs2.core.ui.eAutoFitStyle.ExtendLastColumn.ToString().Trim().ToLower()) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
                ElseIf rLayout.AutoFitStyleGrid.Trim().ToLower().Equals(qs2.core.ui.eAutoFitStyle.ResizeAllColumns.ToString().Trim().ToLower()) Then
                    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                End If
            Else
                grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
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
                    'columnFound.CellMultiLine = Infragistics.Win.DefaultableBoolean.True
                    columnFound.AutoSizeMode = ColumnAutoSizeMode
                Next
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("compLayoutGrid.PrepareGrid: " + vbNewLine + ex.ToString())
        End Try
    End Function


    Public Function resetLayoutGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            For Each bandFound As UltraGridBand In grid.DisplayLayout.Bands
                For Each columnFound As UltraGridColumn In bandFound.Columns
                    columnFound.Hidden = False
                Next
                bandFound.ClearGroupByColumns()
            Next
            grid.Refresh()

            Return True

        Catch ex As Exception
            'Throw New Exception("compLayoutGrid.doLayoutGrid: " + vbNewLine + ex.ToString())
        End Try
    End Function


    Public Sub expandFirstGroupByRowInGrid(grid As UltraGrid)
        Try
            For Each rowInGrid As UltraGridRow In grid.Rows
                If rowInGrid.IsGroupByRow Then
                    'rowInGrid.ExpandAll()
                    Exit For
                End If
            Next

        Catch ex As Exception
        End Try
    End Sub
    Public Function sys_deleteAllLayouts() As Boolean

        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " delete from " + qs2.core.dbBase.dbSchema + "Layout "
        cmd.Connection = database.dbConn
        cmd.ExecuteNonQuery()
        Return True

    End Function



    Public Function checkExceptionOpendDataReader(sExcept As String)
        If compLayout.iCouterException >= 5 Then
            compLayout.iCouterException = 0
            Return False
        Else
            If sExcept.Contains(("bereits ein geöffneter DataReader").Trim()) Then
                qs2.core.generic.WaitMilli(200)
                compLayout.iCouterException += 1
                Return True
            Else
                Return False
            End If
        End If
    End Function

End Class
