Imports Infragistics.Win
Imports Infragistics.Win.Misc
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars


Public Class contSelectAbteilBereiche

    Public abort As Boolean = True

    Public _dropDownButton As UltraDropDownButton = Nothing
    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing

    Public IsInitialized As Boolean = False
    Public gen As New General()
    Public UIGlobal1 As New PMDS.Global.UIGlobal()
    Public b As New PMDS.db.PMDSBusiness()

    Public MainMessage As frmNachricht3 = Nothing
    Public MainPlanSearch As contPlanung2 = Nothing
    Public MainPlanBereicheSearch As contPlanung2Bereich = Nothing

    Public funct1 As New QS2.core.vb.funct()








    Private Sub contSelectSelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(dropDownButton As UltraDropDownButton)
        Try
            If Not Me.IsInitialized Then
                Me._dropDownButton = dropDownButton

                Me.btnSelectSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
                Me.btnSelectSave.Text = doUI.getRes("OK")

                Me.loadAbtBereiche()
                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadAbtBereiche()
        Try
            Me.DsClipboard1.Clear()
            Me.txtSearch.Text = ""

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim tAuswahlListe As System.Linq.IQueryable(Of PMDS.db.Entities.AuswahlListe) = Me.b.GetAuswahlliste(db, "", -100000, False)
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
            End Using

            Me.DsClipboard1.AcceptChanges()

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.loadSelList: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadDataColl(ByRef sGuids As String)
        Try
            Dim lstCategories As New System.Collections.Generic.List(Of String)()
            If sGuids.Trim().Contains(";") Then
                lstCategories = PMDS.Global.generic.readStrVariables(sGuids.Trim())
            Else lstCategories = PMDS.Global.generic.readStrVariables(sGuids.Trim())
                lstCategories.Add(sGuids.Trim())
            End If

            'For Each sCategory As String In lstCategories
            '    For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
            '        Dim v As DataRowView = rGridRow.ListObject
            '        Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

            '        If rSelRow.Bezeichnung.Trim().ToLower().Equals(sCategory.Trim().ToLower()) Then
            '            rGridRow.Cells(Me.colSelect.Trim()).Value = True
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.loadDataColl: " + ex.ToString())
        End Try
    End Sub

    Public Function validatedata() As Boolean
        Try
            'For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
            '    Dim v As DataRowView = rGridRow.ListObject
            '    Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

            '    If rSelRow.RowState <> DataRowState.Deleted Then
            '        If rSelRow.Bezeichnung.Trim() = "" Then
            '            rSelRow.SetColumnError(Me.DsClipboard1.tblSelListEntriesTmp.BezeichnungColumn.ColumnName, "ErrorInput")
            '            doUI.doMessageBox2("DescriptionInputRequired", "", "")
            '            Return False

            '        Else
            '            If rSelRow.Bezeichnung.Trim().Contains(";") Or rSelRow.Bezeichnung.Trim().Contains("/") Or rSelRow.Bezeichnung.Trim().Contains("\") Or rSelRow.Bezeichnung.Trim().Contains("´`") Then
            '                doUI.doMessageBox2("TextContainsUnauthorizedCharacters", "", "")
            '                Return False
            '            End If

            '            'Dim pattern As String = "^[a-zA-Z\s]+$"
            '            'Dim reg As New Text.RegularExpressions.Regex(pattern)
            '            'If Not reg.IsMatch(rSelRow.Bezeichnung.Trim()) Then
            '            '    doUI.doMessageBox2("TextContainsUnauthorizedCharacters", "", "")
            '            '    Return False
            '            'End If
            '        End If
            '    End If
            'Next

            Return True

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.validatedata: " + ex.ToString())
        End Try
    End Function

    Public Function getSelectedData2(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of String)) As String
        Try
            'Dim lstSelCategoriesTmp As New System.Collections.Generic.List(Of String)
            'For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
            '    Dim v As DataRowView = rGridRow.ListObject
            '    Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

            '    If rSelRow.RowState <> DataRowState.Deleted Then
            '        If rGridRow.Cells(Me.colSelect.Trim()).Value = True Then
            '            lstSelCategoriesTmp.Add(rSelRow.Bezeichnung.ToString())
            '        End If
            '    End If
            'Next

            'Dim lstSelectedSelLists As String = ""
            'If lstSelCategoriesTmp.Count = 1 Then
            '    lstSelectedSelLists += lstSelCategoriesTmp(0).ToString().Trim()
            'Else
            '    For Each sCategory As String In lstSelCategoriesTmp
            '        lstSelectedSelLists += sCategory.Trim() + ";"
            '    Next
            'End If

            'lstSelectedRowsReturn = lstSelCategoriesTmp
            'Return lstSelectedSelLists.Trim()

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.getSelectedData: " + ex.ToString())
        End Try
    End Function
    Public Sub getSelectedIDs(ByRef lstSelectedRowsReturn As System.Collections.Generic.List(Of Guid))
        Try
            'For Each rGridRow As UltraGridRow In Me.gridSelList.Rows
            '    Dim v As DataRowView = rGridRow.ListObject
            '    Dim rSelRow As dsClipboard.tblSelListEntriesTmpRow = v.Row

            '    If rSelRow.RowState <> DataRowState.Deleted Then
            '        If rGridRow.Cells(Me.colSelect.Trim()).Value = True Then
            '            lstSelectedRowsReturn.Add(rSelRow.IDGuid)
            '        End If
            '    End If
            'Next

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.getSelectedIDs: " + ex.ToString())
        End Try
    End Sub

    Public Sub addRow()
        Try
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rNew As dsClipboard.tblSelListEntriesTmpRow = Me.CompPlan1.getNewRowSelListEntriesTmp(Me.DsClipboard1)
                Dim IDOwnIntMax As Integer = -999
                Dim rSelListGroup As PMDS.db.Entities.tblSelListGroup = Nothing

                Dim iMaxID = -999
                iMaxID = Me.b.getSelListEntriesMaxID("", db, IDOwnIntMax, rSelListGroup)

                If iMaxID = -999 Then
                    Dim sID As String = rSelListGroup.ID.ToString() + "0001"
                    rNew.ID = System.Convert.ToInt32(sID.Trim())
                Else
                    rNew.ID = iMaxID + 1
                End If
                rNew.IDGroup = rSelListGroup.ID
                If IDOwnIntMax = -999 Then
                    rNew.IDOwnInt = 1
                Else
                    rNew.IDOwnInt = IDOwnIntMax + 1
                End If
            End Using

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.addRow: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearFilterSearch()
        Try
            Me.txtSearch.Text = ""

        Catch ex As Exception
            Throw New Exception("contSelectAbteilBereiche.clearFilterSearch: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnSelectSave_Click(sender As Object, e As EventArgs) Handles btnSelectSave.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.abort = False
            Me.popupContMainSearch.Close()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class

