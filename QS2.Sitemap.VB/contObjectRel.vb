Imports qs2.core.vb




Public Class contObjectRel


    Public sqlObjects1 As New sqlObjects()
    Public IDGuidObject As System.Guid = Nothing

    Public editable As Boolean = False

    Public mainWindow As Object
    Public ui As New qs2.sitemap.ui()

    Public isLoaded As Boolean = False





    Private Sub contGirokonto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.loadRes()
            Me.sqlObjects1.initControl()

            Me.isLoaded = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Me.btnAdd2.initControl()
        Me.btnDel2.initControl()
    End Sub

    Public Sub loadUsers()
        Try
            Me.DsObject1.tblObject.Clear()
            Me.UltraGrid1.DisplayLayout.ValueLists("users").ValueListItems.Clear()
            Me.sqlObjects1.getObject2(Me.DsObject1, sqlObjects.eTypObj.IsUser, Nothing, Nothing, "", "", Nothing, "", sqlObjects.eTypSelObj.AllUser, qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "", "")
            For Each r As dsObjects.tblObjectRow In Me.DsObject1.tblObject
                Me.UltraGrid1.DisplayLayout.ValueLists("users").ValueListItems.Add(r.IDGuid, sqlObjects.getNameCombination(r))
            Next

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadData(ByVal idGuidObj As System.Guid)
        Try
            Me.loadUsers()

            Me.IDGuidObject = idGuidObj
            Me.DsObject1.tblObjectRel.Clear()
            Me.sqlObjects1.getObjectRel(Me.IDGuidObject, Me.DsObject1, sqlObjects.eTypSelAnspr.idObject)
            Me.UltraGrid1.Refresh()

            Me.UltraGrid1.Selected.Rows.Clear()
            Me.UltraGrid1.ActiveRow = Nothing

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub



    Public Sub clearControl()
        Me.DsObject1.tblObjectRel.Clear()
        Me.UltraGrid1.Refresh()
    End Sub

    Public Function validate() As Boolean
        Try
            For Each r As dsObjects.tblObjectRelRow In Me.DsObject1.tblObjectRel
                If r.RowState <> DataRowState.Deleted Then
                    r.SetColumnError(Me.DsObject1.tblObjectRel.IDGuidObjectSubColumn.ColumnName, "")
                    r.IDGuidObject = Me.IDGuidObject
                    If r.IDGuidObjectSub.Equals(System.Guid.Empty) Then
                        Dim txt As String = qs2.core.language.sqlLanguage.getRes("NoUserName")
                        r.SetColumnError(Me.DsObject1.tblObjectRel.IDGuidObjectSubColumn.ColumnName, txt)
                        qs2.core.generic.showMessageBox(txt, Windows.Forms.MessageBoxButtons.OK, "")
                        Return False

                    End If
                End If
            Next

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function save(ByVal IDGuidObj As System.Guid) As Boolean
        Try
            Me.IDGuidObject = IDGuidObj
            If Not Me.validate() Then Return False
            Me.sqlObjects1.daObjectRel.Update(Me.DsObject1.tblObjectRel)
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function add() As Boolean
        Try
            Me.loadUsers()

            Dim rNew As dsObjects.tblObjectRelRow = Me.sqlObjects1.getNewRowObjectRel(Me.DsObject1)
            rNew.IDGuidObject = Me.IDGuidObject

            If Me.DsObject1.tblObject.Rows.Count > 0 Then
                Dim rObjRel As dsObjects.tblObjectRow = Me.DsObject1.tblObject.Rows(0)
                rNew.IDGuidObjectSub = rObjRel.IDGuid
            End If

            Me.UltraGrid1.Refresh()
            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Public Sub deleteRows()
        Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
        qs2.core.ui.getSelectedGridRows(Me.UltraGrid1, rSelected, True)
        If (rSelected.Count > 0) Then
               For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                rGrid.Delete(False)
            Next
        Else
            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecord"), Windows.Forms.MessageBoxButtons.OK, "")
        End If
    End Sub


    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.btnAdd2.Enabled = bEdit
            Me.btnDel2.Enabled = bEdit
            Me.PanelButt.Visible = bEdit
            Me.editable = bEdit
            If Me.editable Then
                Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles UltraGrid1.BeforeCellActivate
        If Not Me.editable Then
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Else
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End If
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        If Me.UltraGrid1.Focused Then
            e.DisplayPromptMsg = True
            e.Cancel = True
        Else
            e.DisplayPromptMsg = False
        End If
    End Sub


    Public Sub SetWidthHeigth(ByVal Width As Integer, ByVal Height As Integer)
        Try
            Me.Width = Width
            Me.Height = Height

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Sub

    Private Sub UltraGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.Click
        'Try
        '    Me.Cursor = Windows.Forms.Cursors.WaitCursor

        '    If Not Me.UltraGrid1.ActiveCell Is Nothing Then
        '        If Me.UltraGrid1.ActiveCell.Column.ToString() = "Mail" Then
        '            Dim v As DataRowView = Me.UltraGrid1.ActiveCell.Row.ListObject
        '            Dim rAnsprech As dsObject.tblObjectAnsprRow = v.Row
        '            If rAnsprech.Mail.Trim() <> "" Then
        '                Me.newMail(rAnsprech.IDObjectSub, rAnsprech.Mail)
        '            End If
        '        End If
        '    End If

        'Catch ex As Exception
        '    qs2.core.generic.getExep(ex.ToString(), ex.Message)
        'Finally
        '    Me.Cursor = Windows.Forms.Cursors.Default
        'End Try
    End Sub

    Private Sub reloadListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reloadListToolStripMenuItem.Click
        Me.loadUsers()
    End Sub

    Private Sub btnAdd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.add()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.deleteRows()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
