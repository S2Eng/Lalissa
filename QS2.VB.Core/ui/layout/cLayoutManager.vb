Imports Infragistics.Win.UltraWinGrid



Public Class cLayoutManager
 
    Public _LayoutKey As String = ""

    Public gridUIToSave As Infragistics.Win.UltraWinGrid.UltraGrid = Nothing
    Public typLayoutGrid As New eTypLayoutGrid()
    Public Enum eTypLayoutGrid
        onlyFirstBand = 0
        allBands = 1
    End Enum

    Public rLayout As dsLayout.LayoutRow = Nothing








    Public Sub initControl()
        Try
 

        Catch ex As Exception
            Throw New Exception("cLayoutManager.initControl: " + ex.ToString())
        End Try
    End Sub


    Public Function load(Key As String, _
                             DsLayout1 As dsLayout, CompLayout1 As compLayout, _
                             LayoutNameDefault As String, _
                             DeleteOldLayout As Boolean, BuildNewLayout As Boolean) As Boolean
        Try
            If DsLayout1 Is Nothing Then
                DsLayout1 = New dsLayout()
            End If
            If CompLayout1 Is Nothing Then
                CompLayout1 = New compLayout()
                CompLayout1.initControl()
            End If

            DsLayout1.Clear()
            Me._LayoutKey = Key.Trim()

            'If DeleteExistingLayout Then
            '    CompLayout1.deleteLayoutKeyGrid(Key.Trim())
            'End If

            CompLayout1.getLayout(DsLayout1, System.Guid.NewGuid.ToString(), compLayout.eSelLayoutGrid.LayoutName, Nothing, "")
            CompLayout1.getLayoutGrid(System.Guid.NewGuid, DsLayout1, compLayout.eSelLayoutGrid.Grid)

            If Me._LayoutKey.Trim() = "" Then
                Dim str As String = ""
            End If

            CompLayout1.getLayout(DsLayout1, "", compLayout.eSelLayoutGrid.Key, Nothing, Me._LayoutKey.Trim())
            If DsLayout1.Layout.Rows.Count > 1 Then
                Throw New Exception("contLayoutGrid.loadData: Me.DsLayoutGrid1.Layout.Rows.Count >0! Key'" + Me._LayoutKey + "'!")
            ElseIf DsLayout1.Layout.Rows.Count = 1 Then
                Me.rLayout = DsLayout1.Layout.Rows(0)

            ElseIf DsLayout1.Layout.Rows.Count = 0 Then
                Me.rLayout = CompLayout1.newLayout(DsLayout1)
                Me.rLayout.CreateFrom = qs2.core.vb.actUsr.rUsr.UserName
                Me.rLayout.Key = _LayoutKey.Trim()
                Me.rLayout.LayoutName = LayoutNameDefault.Trim()
                Me.rLayout.AutoFitStyleGrid = qs2.core.ui.eAutoFitStyle.None.ToString()
                Me.rLayout.GridAutoNewline = True

            End If

            'CompLayout1.deleteLayoutGrid(Me.rLayout.IDGuid)
            CompLayout1.getLayoutGrid(Me.rLayout.IDGuid, DsLayout1, compLayout.eSelLayoutGrid.Grid)
            If DeleteOldLayout Then
                For Each rLayoutGrid As dsLayout.LayoutGridsRow In DsLayout1.LayoutGrids
                    rLayoutGrid.Delete()
                Next
            End If

            Dim bFirstLoadingGrid As Boolean = False
            If DsLayout1.LayoutGrids.Rows.Count = 0 Then
                bFirstLoadingGrid = True
            End If

            'If BuildNewGridForSaveing Then
            '    'Me.buildGridForSave(rLayout, DsLayout1, CompLayout1)
            'End If
            If BuildNewLayout Then
                If Not Me.gridUIToSave Is Nothing Then
                    Me.showLayoutInGrid(Me.rLayout, DsLayout1, CompLayout1)
                End If
            End If

            Me.checkDoubledKey(Me._LayoutKey)

            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.loadData: " + ex.ToString())
        End Try
    End Function
    Public Function newLayout(ByRef DsLayout1 As dsLayout, ByRef CompLayout1 As compLayout, Key As String) As Boolean
        Try
            If DsLayout1 Is Nothing Then
                DsLayout1 = New dsLayout()
            End If
            If CompLayout1 Is Nothing Then
                CompLayout1 = New compLayout()
                CompLayout1.initControl()
            End If

            DsLayout1.Clear()
            Me._LayoutKey = Key.Trim()

            CompLayout1.getLayout(DsLayout1, System.Guid.NewGuid.ToString(), compLayout.eSelLayoutGrid.LayoutName, Nothing, "")
            CompLayout1.getLayoutGrid(System.Guid.NewGuid, DsLayout1, compLayout.eSelLayoutGrid.Grid)

            Me.rLayout = CompLayout1.newLayout(DsLayout1)
            Me.rLayout.LayoutName = Me._LayoutKey.Trim()
            Me.rLayout.Key = Me._LayoutKey.Trim()
            Me.rLayout.AutoFitStyleGrid = qs2.core.ui.eAutoFitStyle.None.ToString()
            Me.rLayout.GridAutoNewline = True

            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.loadData: " + ex.ToString())
        End Try
    End Function


    Public Function saveData(ByRef DsLayout1 As dsLayout, ByRef CompLayout1 As compLayout) As Boolean
        Try
            CompLayout1.daLayout.Update(DsLayout1.Layout)
            CompLayout1.daLayoutGrid.Update(DsLayout1.LayoutGrids)
            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.saveData: " + ex.ToString())
        End Try
    End Function
    Public Function copyLayout(IDLayout As System.Guid, _
                               ByRef sKeyLayoutCopied As String, ByRef IDLayoutCopied As System.Guid, _
                               ByRef nCounterCopied As Integer) As Boolean
        Try
            Dim dsLayoutTmp As New dsLayout()
            Dim compLayoutTmp As New compLayout()
            compLayoutTmp.initControl()

            compLayoutTmp.getLayout(dsLayoutTmp, "", compLayout.eSelLayoutGrid.IDLayout, IDLayout, "")
            Dim rLayoutToCopy As dsLayout.LayoutRow = dsLayoutTmp.Layout.Rows(0)
            compLayoutTmp.getLayoutGrid(IDLayout, dsLayoutTmp, compLayout.eSelLayoutGrid.Grid)

            Dim dsLayoutCopied As New dsLayout()
            Dim rNewLayout As dsLayout.LayoutRow = dsLayoutCopied.Layout.NewRow()
            rNewLayout.ItemArray = rLayoutToCopy.ItemArray
            rNewLayout.IDGuid = System.Guid.NewGuid()
            rNewLayout.Key = "Copy " + nCounterCopied.ToString() + " of " + rLayoutToCopy.Key.Trim()
            rNewLayout.LayoutName = "Copy " + nCounterCopied.ToString() + " of " + rLayoutToCopy.LayoutName.Trim()
            dsLayoutCopied.Layout.Rows.Add(rNewLayout)

            For Each rLayoutGridFound As dsLayout.LayoutGridsRow In dsLayoutTmp.LayoutGrids
                Dim rNewLayoutGrid As dsLayout.LayoutGridsRow = dsLayoutCopied.LayoutGrids.NewRow()
                rNewLayoutGrid.ItemArray = rLayoutGridFound.ItemArray
                rNewLayoutGrid.IDGuid = System.Guid.NewGuid()
                rNewLayoutGrid.IDLayout = rNewLayout.IDGuid
                dsLayoutCopied.LayoutGrids.Rows.Add(rNewLayoutGrid)
            Next

            compLayoutTmp.daLayout.Update(dsLayoutCopied.Layout)
            compLayoutTmp.daLayoutGrid.Update(dsLayoutCopied.LayoutGrids)

            sKeyLayoutCopied = rNewLayout.Key.Trim()
            IDLayoutCopied = rNewLayout.IDGuid
            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.copyLayout: " + ex.ToString())
        End Try
    End Function


    Public Sub checkDoubledKey(ByRef Key As String)
        Try
            Dim dsLayoutCheck As New dsLayout()
            Dim compLayoutCheck As New compLayout()
            compLayoutCheck.getLayout(dsLayoutCheck, "", compLayout.eSelLayoutGrid.Key, Nothing, Key.Trim())
            If dsLayoutCheck.Layout.Rows.Count > 1 Then
                Throw New Exception("cLayoutManager.checkDoubbledKey: dsLayoutCheck.Layout.Rows.Count > 1 for Key '" + Key.Trim() + "'!")
            End If

        Catch ex As Exception
            Throw New Exception("cLayoutManager.checkDoubbledKey: " + ex.ToString())
        End Try
    End Sub

    Public Function showLayoutInGrid(rLayout As dsLayout.LayoutRow, _
                            ByRef DsLayout1 As dsLayout, ByRef CompLayout1 As compLayout) As Boolean
        Try
            Dim dsLayoutGridAdded As New dsLayout()
            CompLayout1.PrepareGrid(Me.gridUIToSave, rLayout)
            Me.gridUIToSave.Refresh()

            Dim anyColumnAdded As Boolean = False
            For Each bandFound As UltraGridBand In Me.gridUIToSave.DisplayLayout.Bands
                If Me.typLayoutGrid = eTypLayoutGrid.allBands Or bandFound.Index = 0 Then

                    ' get lastSort from Db in Band
                    Dim nLastSortInBand As Integer = 0
                    'Dim arrLayoutGrids() As dsLayout.LayoutGridsRow = DsLayout1.LayoutGrids.Select(DsLayout1.LayoutGrids.BandColumn.ColumnName + "=" + bandFound.Index.ToString() + "", DsLayout1.LayoutGrids.SortColumn.ColumnName + " desc")
                    'For Each rLayoutGridInDB As dsLayout.LayoutGridsRow In arrLayoutGrids
                    '    nLastSortInBand = rLayoutGridInDB.Sort
                    '    Exit For
                    'Next

                    Dim dtSorted As New DataTable()
                    dtSorted.Columns.Add("Key", GetType(String))
                    dtSorted.Columns.Add("VisiblePosition", GetType(Integer))
                    For Each columnFound As UltraGridColumn In bandFound.Columns
                        Dim NewRowColumnFound As DataRow = dtSorted.NewRow()
                        NewRowColumnFound("Key") = columnFound.Key
                        NewRowColumnFound("VisiblePosition") = columnFound.Header.VisiblePosition
                        dtSorted.Rows.Add(NewRowColumnFound)
                    Next
                    Dim arrColumnsSorted() As DataRow = dtSorted.Select("", "VisiblePosition asc")
                    For Each rColumnFoundSorted As DataRow In arrColumnsSorted
                        Dim columnFound As UltraGridColumn = bandFound.Columns(rColumnFoundSorted("Key"))

                        Dim bColExistsInDb As Boolean = False
                        'For Each rLayoutGridInDB As dsLayout.LayoutGridsRow In DsLayout1.LayoutGrids
                        '    If columnFound.Key.Equals(rLayoutGridInDB.ColumnName) Then
                        '        bColExistsInDb = True
                        '    End If
                        'Next

                        If Not bColExistsInDb Then
                            Dim rNewLayoutGrid As dsLayout.LayoutGridsRow = CompLayout1.newLayoutGrid(DsLayout1, rLayout.IDGuid)
                            rNewLayoutGrid.GridName = Me.gridUIToSave.Name
                            rNewLayoutGrid.Band = bandFound.Index
                            rNewLayoutGrid.ColumnName = columnFound.Key.Trim()
                            rNewLayoutGrid.ColumnCaption = columnFound.Header.Caption.Trim()
                            rNewLayoutGrid.Visible = Not columnFound.Hidden Or columnFound.IsGroupByColumn
                            rNewLayoutGrid.ColumnWith = columnFound.Width
                            rNewLayoutGrid.GroupBy = columnFound.IsGroupByColumn
                            If columnFound.CellMultiLine = Infragistics.Win.DefaultableBoolean.True Then
                                rNewLayoutGrid.AutoSizeHeigthColumn = True
                            Else
                                rNewLayoutGrid.AutoSizeHeigthColumn = False
                            End If
                            rNewLayoutGrid.TypeUI = columnFound.Style
                            rNewLayoutGrid.TypeCol = columnFound.DataType.ToString()
                            For Each colSortedFound As UltraGridColumn In bandFound.SortedColumns
                                If colSortedFound.Key.Equals(columnFound.Key) Then
                                    rNewLayoutGrid.OrderBy = True
                                    If colSortedFound.SortIndicator = SortIndicator.Descending Then
                                        rNewLayoutGrid.Desc = True
                                    Else
                                        rNewLayoutGrid.Desc = False
                                    End If
                                End If
                            Next
                            'For Each UltraGridGroup1 As UltraGridGroup In bandFound.Groups

                            'Next
                            nLastSortInBand += 1
                            rNewLayoutGrid.IDLayout = rLayout.IDGuid
                            'rNewLayoutGrid.Sort = nLastSortInBand
                            rNewLayoutGrid.Sort = columnFound.Header.VisiblePosition + 1
                        End If
                    Next
                End If
            Next

            'For Each rLayoutGridAdded As dsLayout.LayoutGridsRow In dsLayoutGridAdded.LayoutGrids
            '    Dim rNewLayoutGrid As dsLayout.LayoutGridsRow = CompLayout1.newLayoutGrid(DsLayout1, rLayout.IDGuid)
            '    rNewLayoutGrid.ItemArray = rLayoutGridAdded.ItemArray
            '    anyColumnAdded = True
            'Next

            'If anyColumnAdded Then
            '    CompLayout1.daLayout.Update(DsLayout1.Layout)
            '    CompLayout1.daLayoutGrid.Update(DsLayout1.LayoutGrids)
            'End If

            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.setGrid: " + ex.ToString())
        End Try
    End Function
    Public Function buildGridForSave(rLayout As dsLayout.LayoutRow, _
                          ByRef DsLayout1 As dsLayout, ByRef CompLayout1 As compLayout) As Boolean
        Try
            Me.gridUIToSave = New Infragistics.Win.UltraWinGrid.UltraGrid()
            Me.gridUIToSave.DataSource = DsLayout1.LayoutGrids
            Me.gridUIToSave.DataMember = DsLayout1.LayoutGrids.TableName
            Me.gridUIToSave.DataBind()
            Me.gridUIToSave.UpdateData()

            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.setGrid: " + ex.ToString())
        End Try
    End Function

    Public Function ResetLayout(ByRef CompLayout1 As compLayout) As Boolean
        Try
            If Not Me.gridUIToSave Is Nothing Then
                CompLayout1.resetLayoutGrid(Me.gridUIToSave)
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("cLayoutManager.ResetLayout: " + ex.ToString())
        End Try
    End Function

End Class
