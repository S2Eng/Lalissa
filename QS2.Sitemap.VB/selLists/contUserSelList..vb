



Public Class contUserSelList

    Public _IDSelListEntryQuery As Integer = -1
    Public _IDApplication As String = ""

    Public abort As Boolean = True
    Public mainWindow As frmUserSelList = Nothing
    Public ui1 As New qs2.core.ui()

    Public _eDbTypAuswObj As qs2.core.vb.sqlAdmin.eDbTypAuswObj = core.vb.sqlAdmin.eDbTypAuswObj.UserQueries





    Private Sub contUserSelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initControl(ByRef IDSelListEntryQuery As Integer, ByRef IDApplication As String)
        Try
            Me._IDSelListEntryQuery = IDSelListEntryQuery
            Me._IDApplication = IDApplication

            Me.btnOK2.initControl()
            Me.btnAbort2.initControl()

            Me.mainWindow.AcceptButton = Me.btnOK2
            Me.mainWindow.CancelButton = Me.btnAbort2

            Me.btnOK2.Text = qs2.core.language.sqlLanguage.getRes("OK")
            Me.btnOK2.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.btnAbort2.Text = qs2.core.language.sqlLanguage.getRes("Abort")
            Me.btnAbort2.Appearance.Image = Nothing

            For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.gridUsers.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.gridUsers.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Me.gridUsers.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection.Trim()).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.UserNameColumn.ColumnName).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.IDParticipantColumn.ColumnName).Hidden = False
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.TitleColumn.ColumnName).Hidden = True

            Me.gridUsers.DisplayLayout.Bands(0).Columns(qs2.core.generic.columnNameSelection.Trim()).Header.Caption = qs2.core.language.sqlLanguage.getRes("Selection")
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.UserNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("User")
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.LastNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Lastname")
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.FirstNameColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("Firstname")
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.DOBColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("DateOfBirth")
            Me.gridUsers.DisplayLayout.Bands(0).Columns(Me.DsObjects1.tblObject.IDParticipantColumn.ColumnName).Header.Caption = qs2.core.language.sqlLanguage.getRes("IDParticipant")

            Me.SelectAllToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectAll")
            Me.SelectNoneToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelectNone")

            Me.SqlAdmin1.initControl()
            Me.SqlObjects1.initControl()
            Me.loadData()

        Catch ex As Exception
            Throw New Exception("contUserSelList.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData()
        Try
            Me.DsAdmin1.Clear()
            Me.DsObjects1.Clear()
            Me.SqlObjects1.getObject(-999, Me.DsObjects1, core.vb.sqlObjects.eTypSelObj.AllUsersIDParticipant, core.vb.sqlObjects.eTypObj.all, "", "", False, Nothing,
                                     qs2.core.license.doLicense.rParticipant.IDParticipant.Trim())
            Me.gridUsers.Refresh()

            Me.SqlAdmin1.getSelListEntrysObj(Me._IDSelListEntryQuery, _eDbTypAuswObj, _eDbTypAuswObj.ToString(), Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntry, "", -999, "", -999, "", -999, "", "", False, System.Guid.NewGuid())
            For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridUsers.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rSelObj As qs2.core.vb.dsObjects.tblObjectRow = v.Row

                Dim arrSelListObj() As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.DsAdmin1.tblSelListEntriesObj.Select("IDObject=" + rSelObj.ID.ToString() + "", "")
                If arrSelListObj.Length > 0 Then
                    rGrid.Cells(qs2.core.generic.columnNameSelection.Trim()).Value = True
                Else
                    rGrid.Cells(qs2.core.generic.columnNameSelection.Trim()).Value = False
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contUserSelList.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Function saveData() As Boolean
        Try
            Me.SqlAdmin1.deleteSelListEntryObj(Me._IDSelListEntryQuery, _eDbTypAuswObj.ToString())

            For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridUsers.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rSelObj As qs2.core.vb.dsObjects.tblObjectRow = v.Row

                If rGrid.Cells(qs2.core.generic.columnNameSelection.Trim()).Value = True Then
                    Me.DsAdmin1.tblSelListEntriesObj.Clear()
                    Me.SqlAdmin1.getSelListEntrysObj(-999, _eDbTypAuswObj, "", Me.DsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.IDGuid, "", -999, "", -999, "", -999, "", "", False, System.Guid.NewGuid())
                    Dim rNew As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow = Me.SqlAdmin1.getNewRowSelListObj(Me.DsAdmin1)
                    rNew.typIDGroup = _eDbTypAuswObj.ToString()
                    rNew.IDObject = rSelObj.ID
                    rNew.SetFldShortNull()
                    rNew.SetIDApplicationNull()
                    rNew.IDSelListEntry = Me._IDSelListEntryQuery
                    rNew.SetIDSelListEntrySublistNull()
                    rNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()

                    'If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() And qs2.core.Settings.ConnectedOnDesignerDB_QS2_Dev Then
                    '    rNew.IDParticipant = ""
                    'Else
                    '    rNew.IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                    'End If

                    Me.SqlAdmin1.daSelListEntrysObj.Update(Me.DsAdmin1)
                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contUserSelList.saveData: " + ex.ToString())
        End Try
    End Function

    Public Sub selectAll(bOn As Boolean)
        Try
            For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridUsers.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rSelRow As qs2.core.vb.dsObjects.tblObjectRow = v.Row

                rGrid.Cells(qs2.core.generic.columnNameSelection).Value = bOn
            Next

        Catch ex As Exception
            Throw New Exception("contUserSelList.selectAll: " + ex.ToString())
        End Try
    End Sub




    Private Sub gridPatients_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridUsers.BeforeCellActivate
        Try
            If e.Cell.Column.ToString().Trim().ToLower().Equals(qs2.core.generic.columnNameSelection.Trim().ToLower()) Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridPatients_Click(sender As Object, e As EventArgs) Handles gridUsers.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.ui1.evClickOK(sender, e, Me.gridUsers) Then

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub gridPatients_DoubleClick(sender As Object, e As EventArgs) Handles gridUsers.DoubleClick
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.ui1.evDoubleClickOK(sender, e, Me.gridUsers) Then

            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub gridPatients_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridUsers.BeforeRowsDeleted
        Try
            e.DisplayPromptMsg = False
            e.Cancel = True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub


    Private Sub btnOK2_Click(sender As Object, e As EventArgs) Handles btnOK2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me.saveData() Then
                Me.abort = False
                Me.mainWindow.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort2_Click(sender As Object, e As EventArgs) Handles btnAbort2.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.abort = True
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.selectAll(True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub SelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectNoneToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.selectAll(False)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
