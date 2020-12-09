Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars




Public Class contSelectSelList

    Public abort As Boolean = True
    Public _GoupIDStr As String = ""

    Public _dropDownButton As UltraDropDownButton = Nothing
    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing

    Public IsInitialized As Boolean = False
    Public gen As New General()
    Public UIGlobal1 As New PMDS.Global.UIGlobal()
    Public b As New PMDS.db.PMDSBusiness()
    Public colSelect As String = "Select"

    Public MainMessage As frmNachricht3 = Nothing
    Public MainPlanSearch As contPlanung2 = Nothing
    Public MainPlanBereicheSearch As contPlanung2Bereich = Nothing
    Public MainTextTemplates As contTextTemplates = Nothing

    Public _IsSearch As Boolean = False
    Public _IsEditable As Boolean = False
    Public _IsTextTemplate As Boolean = False
    Public _SelListPMDS As Boolean = False
    Public _Bereich As Boolean = False

    Public _IDRes As String = ""
    Public _Title As String = ""

    Public funct1 As New QS2.core.vb.funct()








    Private Sub contSelectSelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(GoupIDStr As String, IsSearch As Boolean, IsTextTemplate As Boolean, dropDownButton As UltraDropDownButton, SelListPMDS As Boolean,
                           IDRes As String, Title As String, Bereich As Boolean)
        Try
            If Not Me.IsInitialized Then
                Me._GoupIDStr = GoupIDStr
                Me._IsSearch = IsSearch
                Me._IsTextTemplate = IsTextTemplate
                Me._dropDownButton = dropDownButton
                Me._SelListPMDS = SelListPMDS
                Me._IDRes = IDRes
                Me._Title = Title
                Me._Bereich = Bereich

                Me.btnSelectSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
                Me.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
                Me.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
                Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

                If Me._IsSearch Then
                    Me.btnSelectSave.Text = doUI.getRes("OK")
                    Me.lblSelectAll.Visible = True
                    Me.lblSelectNone.Visible = True
                Else
                    Me.btnSelectSave.Text = doUI.getRes("OK")
                    Me.lblSelectAll.Visible = False
                    Me.lblSelectNone.Visible = False
                End If

                If Me._IsTextTemplate Then
                    Me.btnSelectSave.Visible = False
                End If

                Me.loadSelList()
                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contSelectSelList.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadSelList()
        Try
            Me.DsClipboard1.Clear()
            Me.gridSelList.Refresh()
            Me.Editable(False)
            Me.txtSearch.Text = ""
            Me.funct1.clearAllFilter(Me.gridSelList)

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                If Not Me._SelListPMDS Then
                    Dim tSelListEntries As System.Linq.IQueryable(Of PMDS.db.Entities.tblSelListEntries) = Me.b.getSelListEntries2(Me._GoupIDStr.Trim(), db)
                    For Each rSelListEntry As PMDS.db.Entities.tblSelListEntries In tSelListEntries
                        Dim rNew As dsClipboard.tblSelListEntriesTmpRow = Me.CompPlan1.getNewRowSelListEntriesTmp(Me.DsClipboard1)
                        rNew.ID = rSelListEntry.ID
                        'Dim TxtTranslated As String = doUI.getRes(rSelListEntry.IDRessource.Trim())
                        'If TxtTranslated.Trim = "" Then
                        '    TxtTranslated = rSelListEntry.IDRessource.Trim()
                        'End If
                        rNew.Bezeichnung = rSelListEntry.IDRessource.Trim()
                        rNew.IDOwnInt = rSelListEntry.IDOwnInt
                        rNew.IDOwnStr = rSelListEntry.IDOwnStr.Trim()
                        rNew.IDGuid = rSelListEntry.IDGuid
                    Next
                Else
                    Dim tAuswahlListe As System.Linq.IQueryable(Of PMDS.db.Entities.AuswahlListe) = Me.b.GetAuswahlliste(db, Me._GoupIDStr.Trim(), -100000, False)
                    Dim iCounter As Integer = 0
                    For Each rAuswahlListe As PMDS.db.Entities.AuswahlListe In tAuswahlListe
                        Dim rNew As dsClipboard.tblSelListEntriesTmpRow = Me.CompPlan1.getNewRowSelListEntriesTmp(Me.DsClipboard1)
                        rNew.ID = iCounter
                        'Dim TxtTranslated As String = doUI.getRes(rSelListEntry.IDRessource.Trim())
                        'If TxtTranslated.Trim = "" Then
                        '    TxtTranslated = rSelListEntry.IDRessource.Trim()
                        'End If
                        rNew.Bezeichnung = rAuswahlListe.Bezeichnung.Trim()
                        rNew.IDOwnInt = iCounter
                        rNew.IDOwnStr = rAuswahlListe.ID.ToString()
                        rNew.IDGuid = rAuswahlListe.ID

                        iCounter += 1
                    Next
                End If
            End Using

            Me.DsClipboard1.AcceptChanges()
            Me.gridSelList.Refresh()
            Me.setLabelCount2()

        Catch ex As Exception
            Throw New Exception("contSelectSelList.loadSelList: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadDataColl(ByRef sGuids As String)
        Try
            Dim lstCategories As New System.Collections.Generic.List(Of String)()
            If sGuids.Trim().Contains(";") Then
                lstCategories = PMDS.Global.generic.readStrVariables(sGuids.Trim())
            Else
                lstCategories = PMDS.Global.generic.readStrVariables(sGuids.Trim())
                lstCategories.Add(sGuids.Trim())
            End If

            For Each sCategory As String In lstCategories
                For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                    Dim v As DataRowView = rGridRow.ListObject
                    Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                    If rSelRow.Bezeichnung.Trim().ToLower().Equals(sCategory.Trim().ToLower()) Then
                        rGridRow.Cells(Me.colSelect.Trim()).Value = True
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("contSelectSelList.loadDataColl: " + ex.ToString())
        End Try
    End Sub

    Public Function validatedata() As Boolean
        Try
            For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                If rSelRow.RowState <> DataRowState.Deleted Then
                    If rSelRow.Bezeichnung.Trim() = "" Then
                        rSelRow.SetColumnError(Me.DsClipboard1.tblSelListEntriesTmp.BezeichnungColumn.ColumnName, "ErrorInput")
                        doUI.doMessageBox2("DescriptionInputRequired", "", "")
                        Return False

                    Else
                        If rSelRow.Bezeichnung.Trim().Contains(";") Or rSelRow.Bezeichnung.Trim().Contains("/") Or rSelRow.Bezeichnung.Trim().Contains("\") Or rSelRow.Bezeichnung.Trim().Contains("´`") Then
                            doUI.doMessageBox2("TextContainsUnauthorizedCharacters", "", "")
                            Return False
                        End If

                        'Dim pattern As String = "^[a-zA-Z\s]+$"
                        'Dim reg As New Text.RegularExpressions.Regex(pattern)
                        'If Not reg.IsMatch(rSelRow.Bezeichnung.Trim()) Then
                        '    doUI.doMessageBox2("TextContainsUnauthorizedCharacters", "", "")
                        '    Return False
                        'End If
                    End If
                End If
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectSelList.validatedata: " + ex.ToString())
        End Try
    End Function

    Public Function saveData() As Boolean
        Try
            If Not Me.validatedata() Then
                Return False
            End If

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rSelRow As dsClipboard.tblSelListEntriesTmpRow In Me.DsClipboard1.tblSelListEntriesTmp
                    Dim bSaveChanges As Boolean = False

                    If rSelRow.RowState = DataRowState.Added Then
                        If Not Me._SelListPMDS Then
                            Dim rNewSelListEntry As PMDS.db.Entities.tblSelListEntries = PMDS.Global.db.ERSystem.EFEntities.newtblSelListEntries(db)
                            rNewSelListEntry.ID = rSelRow.ID
                            rNewSelListEntry.IDRessource = rSelRow.Bezeichnung.Trim()
                            rNewSelListEntry.IDOwnInt = rSelRow.IDOwnInt
                            rNewSelListEntry.IDOwnStr = rSelRow.IDOwnStr.Trim()
                            rNewSelListEntry.IDGuid = rSelRow.IDGuid
                            rNewSelListEntry.IDGroup = rSelRow.IDGroup
                            rNewSelListEntry.IDParticipant = QS2.core.license.doLicense.rParticipant.IDParticipant.Trim()
                            db.tblSelListEntries.Add(rNewSelListEntry)
                            bSaveChanges = True
                        Else
                            Dim rNewAuswahlListe As PMDS.db.Entities.AuswahlListe = PMDS.Global.db.ERSystem.EFEntities.newAuswahlListe(db)
                            rNewAuswahlListe.ID = rSelRow.IDGuid
                            rNewAuswahlListe.Bezeichnung = rSelRow.Bezeichnung.Trim()
                            rNewAuswahlListe.IDAuswahlListeGruppe = Me._GoupIDStr.Trim()
                            rNewAuswahlListe.Reihenfolge = -1
                            rNewAuswahlListe.GehörtzuGruppe = False
                            rNewAuswahlListe.IstGruppe = False
                            rNewAuswahlListe.Hierarche = -1
                            rNewAuswahlListe.Beschreibung = ""

                            db.AuswahlListe.Add(rNewAuswahlListe)
                            bSaveChanges = True
                        End If

                    ElseIf rSelRow.RowState = DataRowState.Modified Then
                        If Not Me._SelListPMDS Then
                            Me.b.checkSelListEntryDescription(rSelRow.IDGuid, rSelRow.Bezeichnung.Trim(), db)
                        Else
                            Me.b.checkAusawhllisteDescription(rSelRow.IDGuid, rSelRow.Bezeichnung.Trim(), db)
                        End If

                    ElseIf rSelRow.RowState = DataRowState.Deleted Then
                        If Not Me._SelListPMDS Then
                            Dim IDGuidSelList As Guid = rSelRow("IDGuid", DataRowVersion.Original)
                            Dim rSelList As PMDS.db.Entities.tblSelListEntries = Me.b.getSelListEntry(IDGuidSelList, db)
                            db.tblSelListEntries.Remove(rSelList)
                            bSaveChanges = True
                        Else
                            Dim IDGuidSelList As Guid = rSelRow("IDGuid", DataRowVersion.Original)
                            Dim rSelList As PMDS.db.Entities.AuswahlListe = Me.b.GetAuswahllisteByID(IDGuidSelList, db)
                            db.AuswahlListe.Remove(rSelList)
                            bSaveChanges = True
                        End If

                    End If

                    If bSaveChanges Then
                        db.SaveChanges()
                    End If
                Next
            End Using

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectSelList.saveData: " + ex.ToString())
        End Try
    End Function

    Public Function getSelectedData2(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of String)) As String
        Try
            Dim lstSelCategoriesTmp As New System.Collections.Generic.List(Of String)
            For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                If rSelRow.RowState <> DataRowState.Deleted Then
                    If rGridRow.Cells(Me.colSelect.Trim()).Value = True Then
                        lstSelCategoriesTmp.Add(rSelRow.Bezeichnung.ToString())
                    End If
                End If
            Next

            Dim lstSelectedSelLists As String = ""
            If lstSelCategoriesTmp.Count = 1 Then
                lstSelectedSelLists += lstSelCategoriesTmp(0).ToString().Trim()
            Else
                For Each sCategory As String In lstSelCategoriesTmp
                    lstSelectedSelLists += sCategory.Trim() + ";"
                Next
            End If

            lstSelectedRowsReturn = lstSelCategoriesTmp
            Return lstSelectedSelLists.Trim()

        Catch ex As Exception
            Throw New Exception("contSelectSelList.getSelectedData: " + ex.ToString())
        End Try
    End Function
    Public Sub getSelectedIDs(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of Guid))
        Try
            For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                If rSelRow.RowState <> DataRowState.Deleted Then
                    If rGridRow.Cells(Me.colSelect.Trim()).Value = True Then
                        lstSelectedRowsReturn.Add(rSelRow.IDGuid)
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("contSelectSelList.getSelectedIDs: " + ex.ToString())
        End Try
    End Sub

    Public Function Editable(ByRef bEdit As Boolean) As Boolean
        Try
            Me._IsEditable = bEdit

            Me.btnAbort.Visible = bEdit
            Me.btnSave.Visible = bEdit
            Me.btnEdit.Visible = Not bEdit

            Me.btnAdd.Visible = bEdit
            Me.btnDel.Visible = bEdit

        Catch ex As Exception
            Throw New Exception("contSelectSelList.Editable: " + ex.ToString())
        End Try
    End Function

    Public Sub addRow()
        Try
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rNew As dsClipboard.tblSelListEntriesTmpRow = Me.CompPlan1.getNewRowSelListEntriesTmp(Me.DsClipboard1)
                Dim IDOwnIntMax As Integer = -999
                Dim rSelListGroup As PMDS.db.Entities.tblSelListGroup = Nothing

                Dim iMaxID = -999
                If Not Me._SelListPMDS Then
                    iMaxID = Me.b.getSelListEntriesMaxID(Me._GoupIDStr.Trim(), db, IDOwnIntMax, rSelListGroup)
                Else
                    For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                        Dim v As DataRowView = rGridRow.ListObject
                        Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row
                        If rSelRow.RowState <> DataRowState.Deleted Then
                            If rSelRow.ID > iMaxID Then
                                iMaxID = rSelRow.ID
                            End If
                        End If
                    Next
                End If
                If iMaxID = -999 Then
                    Dim sID As String = rSelListGroup.ID.ToString() + "0001"
                    rNew.ID = System.Convert.ToInt32(sID.Trim())
                Else
                    rNew.ID = iMaxID + 1
                End If
                If Not Me._SelListPMDS Then
                    rNew.IDGroup = rSelListGroup.ID
                Else
                    rNew.IDGroup = -999
                End If
                If IDOwnIntMax = -999 Then
                    rNew.IDOwnInt = 1
                Else
                    rNew.IDOwnInt = IDOwnIntMax + 1
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectSelList.addRow: " + ex.ToString())
        End Try
    End Sub

    Public Sub deleteRow()
        Try
            Dim rSelGridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Nothing
            Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = Me.getSelectedRow(True, rSelGridRow)
            If Not rSelRow Is Nothing Then
                rSelRow.Delete()
                Me.gridSelList.Refresh()
            End If

        Catch ex As Exception
            Throw New Exception("contSelectSelList.deleteRow: " + ex.ToString())
        End Try
    End Sub

    Public Function getSelectedRow(ByVal msgBox As Boolean, ByRef selRowGrid As Infragistics.Win.UltraWinGrid.UltraGridRow) As dsClipboard.tblSelListEntriesTmpRow
        Try
            If Not Me.gridSelList.ActiveRow Is Nothing Then
                If Me.gridSelList.ActiveRow.IsGroupByRow Or Me.gridSelList.ActiveRow.IsFilterRow Then
                    If msgBox Then
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!")
                    End If
                Else
                    Dim v As DataRowView = Me.gridSelList.ActiveRow.ListObject
                    Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row
                    selRowGrid = Me.gridSelList.ActiveRow
                    Return rSelRow
                End If
            Else
                If msgBox Then
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelectSelList.getSelectedRow: " + ex.ToString())
        End Try
    End Function


    Public Sub setSelectionOnOff(bOn As Boolean)
        Try
            For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                rGridRow.Cells(Me.colSelect.Trim()).Value = bOn
            Next

            Me.setLabelCount2()

        Catch ex As Exception
            Throw New Exception("contSelectSelList.setSelectionOnOff: " + ex.ToString())
        End Try
    End Sub

    Public Sub setLabelCount2()
        Try
            Dim CategoriesSelected As String = ""
            Dim iCountSelected As Integer = 0
            For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
                Dim v As DataRowView = rGridRow.ListObject
                Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

                If rSelRow.RowState <> DataRowState.Deleted Then
                    If rGridRow.Cells(Me.colSelect.Trim()).Value = True Then
                        iCountSelected += 1
                        CategoriesSelected += rSelRow.Bezeichnung.Trim() + ";"
                    End If
                End If
            Next

            If Me._IsSearch Then
                If Not Me._SelListPMDS Then
                    'Dim IDRes As String = "Categories"
                    Dim sTxtReturn As String = doUI.getRes(Me._IDRes.Trim()) + " (" + iCountSelected.ToString() + ")"
                    Me._dropDownButton.Text = sTxtReturn.Trim()
                Else
                    Dim sTxtReturn As String = Me._IDRes + " (" + iCountSelected.ToString() + ")"
                    Me._dropDownButton.Text = sTxtReturn.Trim()
                End If
            Else
                If iCountSelected > 0 Then
                    Me._dropDownButton.Text = CategoriesSelected
                Else
                    If Not Me._SelListPMDS Then
                        Me._dropDownButton.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kategorie wählen")
                    Else
                        Me._dropDownButton.Text = Me._Title
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contSelectSelList.setLabelCount: " + ex.ToString())
        End Try
    End Sub
    Public Sub clearFilterSearch()
        Try
            Me.txtSearch.Text = ""
            Me.funct1.clearAllFilter(Me.gridSelList)

        Catch ex As Exception
            Throw New Exception("contSelectSelList.clearFilterSearch: " + ex.ToString())
        End Try
    End Sub


    Private Sub gridSelList_BeforeCellActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridSelList.BeforeCellActivate
        Try
            If e.Cell.Column.ToString().Trim().ToLower().Equals(Me.colSelect.Trim().ToLower()) Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                If Me._IsEditable Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub gridSelList_Click(sender As Object, e As EventArgs) Handles gridSelList.Click
        Try
            If Me.UIGlobal1.evClickOK(sender, e, Me.gridSelList) Then

            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub gridSelList_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridSelList.BeforeRowsDeleted
        Try


        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub gridSelList_CellChange(sender As Object, e As CellEventArgs) Handles gridSelList.CellChange
        Try
            If e.Cell.Column.ToString().Trim().ToLower().Equals(Me.colSelect.Trim().ToLower()) Then
                Me.gridSelList.UpdateData()
                Dim bValueTmp As Boolean = e.Cell.Row.Cells(Me.colSelect.Trim()).Value
                If Not Me._IsSearch Then
                    Me.setSelectionOnOff(False)
                End If
                Me.gridSelList.UpdateData()
                If Not Me._IsSearch Then
                    e.Cell.Row.Cells(Me.colSelect.Trim()).Value = bValueTmp
                End If
                Me.setLabelCount2()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnSelectSave_Click(sender As Object, e As EventArgs) Handles btnSelectSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me._IsEditable Then
                If Not Me.saveData() Then
                    Me.Editable(False)
                    Exit Sub
                End If
            End If

            Me.abort = False
            Me.popupContMainSearch.Close()

            If Me._IsSearch Then
                'Me.MainPlanSearch.ContPlanung1.search(False, False, True, False)
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.addRow()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.deleteRow()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.saveData() Then
                Me.loadSelList()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadSelList()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.Editable(True)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub txtSearch_ValueChanged(sender As Object, e As EventArgs) Handles txtSearch.ValueChanged
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Me.txtSearch.Focused Then
                Me.funct1.clearAllFilter(Me.gridSelList)
                If Me.txtSearch.Text.Trim() <> "" Then
                    Me.funct1.setFilter("Bezeichnung",
                                FilterLogicalOperator.Or, Me.txtSearch.Text.Trim(),
                                FilterComparisionOperator.StartsWith, Me.gridSelList,
                                Me.gridSelList.DisplayLayout.Bands(0).Index)
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub lblSelectAll_Click(sender As Object, e As EventArgs) Handles lblSelectAll.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.setSelectionOnOff(True)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub lblSelectNone_Click(sender As Object, e As EventArgs) Handles lblSelectNone.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.setSelectionOnOff(False)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class
