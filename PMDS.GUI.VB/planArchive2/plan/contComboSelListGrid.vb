Imports Infragistics.Win.UltraWinGrid



Public Class contComboSelListGrid

    Public gen As New General()
    Public isLoaded As Boolean = False
    Public groupToLoad As String = ""
    Public _typKey As General.eKeyCol

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public doUI1 As New doUI()

    Public _Description As Boolean = False







    Public Sub initControl(Description As Boolean, ByVal quickButton As Boolean,
                           ByVal typKey As General.eKeyCol, ByVal ComboStyle As UltraComboStyle,
                           ByVal quickButtonSmall As Boolean,
                           Optional withDropDown As Integer = -1,
                           Optional quickButtonSmallAlways As Boolean = False)
        Try
            If Me.isLoaded Then Return

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me._Description = Description
            Me._typKey = typKey
            For Each col As UltraGridColumn In Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.cboComboBoxSelList.DropDownStyle = ComboStyle
            Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.DescriptionColumn.ColumnName).Hidden = False

            If Me._typKey = General.eKeyCol.Guid Then
                Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.IDGuidColumn.ColumnName).Hidden = True
                Me.cboComboBoxSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDGuidColumn.ColumnName
            ElseIf Me._typKey = General.eKeyCol.IDNr Then
                Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.IDOwnIntColumn.ColumnName).Hidden = False
                Me.cboComboBoxSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDOwnIntColumn.ColumnName
            ElseIf Me._typKey = General.eKeyCol.IDStr Then
                Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.IDOwnStrColumn.ColumnName).Hidden = False
                Me.cboComboBoxSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDOwnStrColumn.ColumnName
            ElseIf Me._typKey = General.eKeyCol.Description Then
                Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.IDRessourceColumn.ColumnName).Hidden = True
                Me.cboComboBoxSelList.ValueMember = Me.DsAuswahllisten1.SelListHelper.IDRessourceColumn.ColumnName
            End If

            Me.ImageListSmall.Images.Clear()
            Me.ImageListSmall.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32))
            If quickButtonSmall Then
                'Me.cboComboBoxSelList.ButtonsRight(0).Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(getRes.ePicture.ico_add, getRes.ePicTyp.ico)
                Me.cboComboBoxSelList.ButtonsRight(0).Appearance.Image = Me.ImageListSmall.Images(0)
            Else
                'Me.cboComboBoxSelList.ButtonsRight(0).Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(getRes.ePicture.ico_add, getRes.ePicTyp.ico)
                Me.cboComboBoxSelList.ButtonsRight(0).Appearance.Image = Me.ImageListSmall.Images(0)
            End If

            If quickButton Then
                Dim IsAdmin As Boolean = True
                If Not IsAdmin And Not PMDS.Global.ENV.adminSecure Then
                    Me.cboComboBoxSelList.ButtonsRight(0).Visible = False
                Else
                    Me.cboComboBoxSelList.ButtonsRight(0).Visible = True
                End If
            Else
                Me.cboComboBoxSelList.ButtonsRight(0).Visible = False
            End If

            If quickButtonSmallAlways Then
                Me.cboComboBoxSelList.ButtonsRight(0).Visible = True
            End If

            Me.doWidth()

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub doWidth()
        Try
            Dim iWidthCalc As Integer = (Me.Width + 100)
            If iWidthCalc < 200 Then
                iWidthCalc = 200
            End If
            Me.cboComboBoxSelList.DisplayLayout.Bands(0).Columns(Me.DsAuswahllisten1.SelListHelper.DescriptionColumn.ColumnName).Width = iWidthCalc

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.doWidth: " + ex.ToString())
        End Try
    End Sub
    Public Sub editable(bOn As Boolean)
        Try
            If bOn Then
                Dim IsAdmin As Boolean = True
                If Not IsAdmin And Not PMDS.Global.ENV.adminSecure Then
                    Me.cboComboBoxSelList.ButtonsRight(0).Visible = False
                Else
                    Me.cboComboBoxSelList.ButtonsRight(0).Visible = True
                End If
            Else
                Me.cboComboBoxSelList.ButtonsRight(0).Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.editable: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadSelList2(ByVal gruppe As String, Optional IsFolderPlans As Boolean = False)
        Try
            Me.DsAuswahllisten1.SelListHelper.Clear()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            If IsFolderPlans Then
                Me.gen.loadSelList(Nothing, Nothing, gruppe, tSelListEntriesReturn, Me._typKey, MaxIDSelListEntryReturn)
            Else
                Me.gen.loadSelList(Nothing, Nothing, gruppe, tSelListEntriesReturn, Me._typKey, MaxIDSelListEntryReturn)
            End If
            gen.loadDSSelListHelper(tSelListEntriesReturn, Me.DsAuswahllisten1)

            ' Me.cboComboBoxSelList.Refresh()
            Me.cboComboBoxSelList.DataSource = Me.DsAuswahllisten1
            Me.cboComboBoxSelList.DataMember = Me.DsAuswahllisten1.SelListHelper.TableName
            Me.cboComboBoxSelList.DataBind()

            Me.groupToLoad = gruppe

            Me.cboComboBoxSelList.DisplayLayout.Bands(0).SortedColumns.Clear()
            Me.cboComboBoxSelList.DisplayLayout.Bands(0).SortedColumns.Add(Me.DsAuswahllisten1.SelListHelper.DescriptionColumn.ColumnName, False)

            Me.doWidth()

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.loadSelList2: " + ex.ToString())
        End Try
    End Sub

    Private Sub cboComboBoxSelList_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles cboComboBoxSelList.EditorButtonClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If (e.Button.Key = "search") Then
                If Me.gen.OpenSelList(Me.groupToLoad.Trim()) Then
                    Me.loadSelList2(Me.groupToLoad)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function getSelectedSelList(ByVal withMsgBox As Boolean) As dsAuswahllisten.SelListHelperRow
        Try
            If Not Me.cboComboBoxSelList.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.cboComboBoxSelList.ActiveRow.ListObject
                Dim rSelSelList As dsAuswahllisten.SelListHelperRow = v.Row
                Return rSelSelList
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Me.cboComboBoxSelList.Focus()
                End If
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.getSelectedSelList: " + ex.ToString())
        End Try
    End Function

    Private Sub AuswahlLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuswahlLöschenToolStripMenuItem.Click
        Try
            Me.clearSelection()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub cboComboBoxSelList_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboComboBoxSelList.ValueChanged
        Try
            If Me.cboComboBoxSelList.Focused Then
                If Not Me.delonValueChanged Is Nothing Then
                    Me.delonValueChanged.Invoke()
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub clearSelection()
        Try
            'Me.cboComboBoxSelList.Value = Nothing
            Me.cboComboBoxSelList.SelectedRow = Nothing
            Me.cboComboBoxSelList.ActiveRow = Nothing
            Me.cboComboBoxSelList.Text = ""
            Me.cboComboBoxSelList.Refresh()

        Catch ex As Exception
            Throw New Exception("contComboSelListGrid.clearSelection: " + ex.ToString())
        End Try
    End Sub

End Class
