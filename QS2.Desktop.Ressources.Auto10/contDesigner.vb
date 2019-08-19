


Public Class contDesigner

    Public mainForm As frmDesigner = Nothing
    Public ui1 As New UI()

    Public _rSelControl As dsControls.ControlsRow = Nothing

    Public isInitialized As Boolean = False






    Public Sub initControl()
        Try
            If Me.isInitialized Then
                Exit Sub
            End If

            Me.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32)


            Me.isInitialized = True

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Public Sub refreshUI(ByRef IDRes As String)
        Try
            Me.gridDesigner.DataSource = ControlManagment.dsControls
            Me.gridDesigner.DataMember = ControlManagment.dsControls.Controls.TableName
            Me.gridDesigner.Refresh()

            Me.txtSearch.Text = IDRes

            If IDRes.Trim() = "" Then
                Me.ui1.clearAllFilter(Me.gridDesigner)
            Else
                Me.doSearch(IDRes)
            End If

            Me.clearBarDetail()
            Me.SetUIFound()

            Me.gridDesigner.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.gridDesigner.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsControls1.Controls.CreatedColumn.ColumnName, True)
            Me.gridDesigner.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsControls1.Controls.IDResColumn.ColumnName, False)
            Me.gridDesigner.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsControls1.Controls.ControlTypeShortColumn.ColumnName, False)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub


    Public Sub setBarDetail(rSelControl As dsControls.ControlsRow)
        Try
            Me._rSelControl = rSelControl
            Me.PanelDetailBar.Visible = True

        Catch ex As Exception
            Throw New Exception("contDesigner.setBarDetail: " + ex.ToString())
        End Try
    End Sub
    Public Sub clearBarDetail()
        Try
            Me._rSelControl = Nothing
            Me.PanelDetailBar.Visible = False

        Catch ex As Exception
            Throw New Exception("contDesigner.clearBarDetail: " + ex.ToString())
        End Try
    End Sub

    Public Sub SetUIFound()
        Me.lblFound.Text = "Found: " + Me.gridDesigner.Rows.Count.ToString()
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsControls.ControlsRow
        Try
            If Not Me.gridDesigner.ActiveRow Is Nothing Then
                If Me.gridDesigner.ActiveRow.IsGroupByRow Or Me.gridDesigner.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!")
                    End If
                Else
                    Dim v As DataRowView = Me.gridDesigner.ActiveRow.ListObject
                    Dim rSelControl As dsControls.ControlsRow = v.Row
                    selRowGrid = Me.gridDesigner.ActiveRow
                    Return rSelControl
                End If
            Else
                If msgBox Then
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contDesigner.getSelectedRow: " + ex.ToString())
        End Try
    End Function


    Private Sub gridDesigner_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridDesigner.BeforeCellActivate
        Try
            If e.Cell.Row.IsFilterRow Or e.Cell.Row.IsGroupByRow Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                Dim v As DataRowView = e.Cell.Row.ListObject
                Dim rSelRes As dsControls.ControlsRow = v.Row

                If e.Cell.Column.ToString() = Me.DsControls1.Controls.IDResColumn.ColumnName Or _
                    e.Cell.Column.ToString() = Me.DsControls1.Controls.IDResColumn.ColumnName Or _
                    e.Cell.Column.ToString() = Me.DsControls1.Controls.IDResColumn.ColumnName Then

                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub gridDesigner_BeforeRowActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridDesigner.BeforeRowActivate
        Try

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub gridDesigner_Click(sender As Object, e As EventArgs) Handles gridDesigner.Click
        Try
            If Me.ui1.evClickOK(sender, e, Me.gridDesigner) Then
                Me.clearBarDetail()
                Dim rSelGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
                Dim rSelControl As dsControls.ControlsRow = Me.getSelectedRow(False, rSelGridRow)
                If Not rSelControl Is Nothing Then
                    Me.setBarDetail(rSelControl)
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub gridDesigner_DoubleClick(sender As Object, e As EventArgs) Handles gridDesigner.DoubleClick
        Try
            If Me.ui1.evDoubleClickOK(sender, e, Me.gridDesigner) Then
                Me.clearBarDetail()
                Dim rSelGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
                Dim rSelControl As dsControls.ControlsRow = Me.getSelectedRow(False, rSelGridRow)
                If Not rSelControl Is Nothing Then
                    Me.setBarDetail(rSelControl)
                    Dim selHandleEvent As HandleEvent = rSelControl.HandleEvent
                    selHandleEvent.OpenResManager(Me._rSelControl)
                End If
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub


    Public Sub doSearch(ByRef StrToSearch As String)
        Try
            Me.ui1.clearAllFilter(Me.gridDesigner)
            If StrToSearch.Trim() <> "" Then

                Me.ui1.setFilter(ControlManagment.dsControls.Controls.IDResColumn.ColumnName, _
                                    Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or, StrToSearch.Trim(), _
                                    Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith, Me.gridDesigner, _
                                    Me.gridDesigner.DisplayLayout.Bands(0).Index)

                Me.ui1.setFilter(ControlManagment.dsControls.Controls.ControlTextColumn.ColumnName, _
                                    Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or, StrToSearch.Trim(), _
                                    Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith, Me.gridDesigner, _
                                    Me.gridDesigner.DisplayLayout.Bands(0).Index)

                'Me.ui1.setFilter(ControlManagment.dsControls.Controls.IDResColumn.ColumnName, _
                '                    Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or, StrToSearch.Trim(), _
                '                    Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith, Me.gridDesigner, _
                '                    Me.gridDesigner.DisplayLayout.Bands(0).Index)

                'Me.ui1.setFilter(ControlManagment.dsControls.Controls.IDResColumn.ColumnName, _
                '                    Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or, StrToSearch.Trim(), _
                '                    Infragistics.Win.UltraWinGrid.FilterComparisionOperator.StartsWith, Me.gridDesigner, _
                '                    Me.gridDesigner.DisplayLayout.Bands(0).Index)

            End If

        Catch ex As Exception
            Throw New Exception("contHandleRessources.doSearch: " + ex.ToString())
        End Try
    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.mainForm.Close()
        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub txtSearch_ValueChanged(sender As Object, e As EventArgs) Handles txtSearch.ValueChanged
        Try
            If Me.txtSearch.Focused Then
                Me.doSearch(Me.txtSearch.Text.Trim())
                Me.clearBarDetail()
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub FilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterToolStripMenuItem.Click
        Try
            Me.ui1.setFilterGridKomplex(Me.gridDesigner, FilterToolStripMenuItem.Checked, True)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub GroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupToolStripMenuItem.Click
        Try
            If Not Me.GroupToolStripMenuItem.Checked Then
                Me.gridDesigner.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical
            Else
                Me.gridDesigner.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub




    Private Sub btnRessourcen_Click(sender As Object, e As EventArgs) Handles btnRessourcen.Click
        Try
            Dim selHandleEvent As HandleEvent = Me._rSelControl.HandleEvent
            selHandleEvent.OpenResManager(Me._rSelControl)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub btnCriterias_Click(sender As Object, e As EventArgs) Handles btnCriterias.Click
        Try
            Dim selHandleEvent As HandleEvent = Me._rSelControl.HandleEvent
            selHandleEvent.OpenCriterias(Me._rSelControl)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub btnControlDatabase_Click(sender As Object, e As EventArgs) Handles btnControlDatabase.Click
        Try
            Dim selHandleEvent As HandleEvent = Me._rSelControl.HandleEvent
            selHandleEvent.OpenTableViewer(Me._rSelControl)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub btnControlInfo_Click(sender As Object, e As EventArgs) Handles btnControlInfo.Click
        Try
            Dim selHandleEvent As HandleEvent = Me._rSelControl.HandleEvent
            selHandleEvent.openInfoControl(Me._rSelControl, Me.mainForm)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            Me.refreshUI("")

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub gridDesigner_AfterRowActivate(sender As Object, e As EventArgs) Handles gridDesigner.AfterRowActivate
        Try
            Me.SetUIFound()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
    Private Sub gridDesigner_AfterCellActivate(sender As Object, e As EventArgs) Handles gridDesigner.AfterCellActivate
        Try
            Me.SetUIFound()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub CopyCellToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyCellToolStripMenuItem.Click
        Try
            If Not Me.gridDesigner.ActiveRow Is Nothing Then
                System.Windows.Forms.Clipboard.SetDataObject(Me.gridDesigner.ActiveCell.Value.ToString())
            End If

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

End Class
