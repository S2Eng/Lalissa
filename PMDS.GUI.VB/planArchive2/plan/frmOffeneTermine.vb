Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared
Imports Infragistics.Win.UltraWinEditors

Imports System.Windows.Forms
Imports System.Drawing



Public Class frmOffeneTermine2

    Public compPlan1 As New compPlan()

    Private gen As New General

    Public isLoaded As Boolean = False

    Public typUI As New eTypUI()
    Public Enum eTypUI
        admin = 0
        user = 1
    End Enum


    Public Enum eDoAction
        alleAufErledigt = 0
        selection = 10
    End Enum

    Public doUI1 As New doUI()

    Public LayoutName As String = "PlansReminder"





    Private Sub frmOffeneTermine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.Text = doUI.getRes("memorywizard")
            Me.initControl()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.AcceptButton = Me.btnSearch
            Me.CancelButton = Me.btnClose

            Me.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)
            Me.btnEndPlanEntry.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.AlsExcelExportierenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Excel, 32, 32)

            Me.CancelButton = Me.btnClose

            Dim ui1 As New UI()
            ui1.setMergeStyle(Me.gridPlans, True, False)

            Me.gridPlans.DisplayLayout.ValueLists("IDArt").ValueListItems.Clear()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.gen.loadSelList(Me.gridPlans.DisplayLayout.ValueLists("IDArt"), Nothing, "PT", tSelListEntriesReturn, General.eKeyCol.IDNr, MaxIDSelListEntryReturn)

            Me.gen.getAllSachb(Me.cboUsers, Nothing)

            Me.cboArt.initControl(False, False, General.eKeyCol.IDNr, Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList, False)
            Me.cboArt.loadSelList2("PT")

            If Me.typUI = eTypUI.admin Then
                Me.cboUsers.Visible = True
                Me.lblUsers.Visible = True
                Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
                Me.cboUsers.Value = UserLoggedIn.Trim()

            ElseIf Me.typUI = eTypUI.user Then
                Me.cboUsers.Visible = False
                Me.lblUsers.Visible = False

            End If

            Me.resetUI()

            Dim IsAdmin As Boolean = True
            If IsAdmin Or PMDS.Global.ENV.adminSecure Then
                Me.LayoutManagerToolStripMenuItem.Visible = True
            Else
                Me.LayoutManagerToolStripMenuItem.Visible = False
            End If

            Me.searchPlans()

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub searchPlans()
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.DsPlanSearch1.Clear()

            Dim nSelArt As Integer = -1
            Dim rSelSelListArt As dsAuswahllisten.SelListHelperRow = Me.cboArt.getSelectedSelList(False)
            If Not rSelSelListArt Is Nothing Then
                nSelArt = Me.cboArt.cboComboBoxSelList.Value
            End If
            'System.Convert.ToInt32(rSelSelListArt.IDNr) = clPlan.typPlan_EMailEmpfangen
            'frmNewPlan.cboArt2.cboComboBoxSelList.Value = clPlan.typPlan_EMailGesendet

            Dim usrToSearch As String = ""
            If Me.typUI = eTypUI.admin Then
                usrToSearch = Me.cboUsers.Text.Trim()
            ElseIf Me.typUI = eTypUI.user Then
                Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
                usrToSearch = UserLoggedIn.Trim()
            End If

            Dim sqlCommand As String = ""
            Dim suche As New suchePlan()
            suche.searchPlan2(Me.DsPlanSearch1, "", "", "", Nothing, Nothing, Me.txtSearch.Text, False, New dsPlan.planObjectDataTable, True, usrToSearch, True,
                                Me.udtVon.Value, Me.udtBis.Value, False, 0, 0, Nothing, nSelArt, Nothing, -1, True, sqlCommand, "", "")
            Me.gridPlans.Refresh()

            Me.setCountUI()

            'If Me.DsPlanSearch1.plan.Rows.Count < 2000 Then
            '    For Each rPlan As dsPlanSearch.planRow In Me.DsPlanSearch1.plan
            '        Dim gridRowAct As UltraGridRow = Me.gridPlans.Rows.GetRowWithListIndex(Me.DsPlanSearch1.plan.Rows.IndexOf(rPlan))
            '        If Not rPlan.readed Then
            '            'If Not gridRowAct Is Nothing Then
            '            gridRowAct.Appearance.FontData.Bold = DefaultableBoolean.True
            '            'End If
            '        Else
            '            gridRowAct.Appearance.FontData.Bold = DefaultableBoolean.False
            '        End If
            '    Next
            'End If

            Me.gridPlans.ActiveRow = Nothing

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.searchPlans: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub setCountUI()
        Try
            If Me.DsPlanSearch1.plan.Rows.Count > 0 Then
                Me.lblInfo.Text = Me.DsPlanSearch1.plan.Rows.Count.ToString + " " + doUI.getRes("Founded")
                'Me.lblInfo.Appearance.FontData.Bold = DefaultableBoolean.True
                Me.lblInfo.Appearance.ForeColor = System.Drawing.Color.DarkRed
            Else
                Me.lblInfo.Text = doUI.getRes("NoOpenedPlanEntriesFound") + "!"
                Me.lblInfo.Appearance.FontData.Bold = DefaultableBoolean.False
                Me.lblInfo.Appearance.ForeColor = System.Drawing.Color.Black
            End If
            'Me.Text = "Erinnerungsassistent (" + Me.DsPlanSearch1.plan.Rows.Count.ToString + ")"

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.setCountUI: " + ex.ToString())
        End Try
    End Sub
    Private Sub UltraGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPlans.DoubleClick
        Try
            Dim ui1 As New PMDS.Global.UIGlobal()
            If ui1.evDoubleClickOK(sender, e, Me.gridPlans) Then
                Me.PlanungseintragÖffnen()
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub PlanungseintragÖffnen()
        Try
            If Not Me.gen.IsNull(Me.gridPlans.ActiveRow) Then
                If Not Me.gridPlans.ActiveRow.IsGroupByRow Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim ui1 As New UI()
                    ui1.openMessage(gridPlans.ActiveRow.Cells("ID").Value, Nothing, Me, False)
                    Me.Cursor = Cursors.Default
                End If
            Else
                doUI.doMessageBox2("NoEntrySelected", "", "!")
            End If

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.PlanungseintragÖffnen: " + ex.ToString())
        End Try
    End Sub

    Private Sub txtSuche_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Enter
        Try
            Me.txtSearch.SelectAll()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub txtSuche_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        Try
            'Select Case Asc(e.KeyChar)
            '    Case 13
            '        Me.searchPlans()

            'End Select

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.searchPlans()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEndPlanEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndPlanEntry.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.doActionDocusGrid(True, eDoAction.alleAufErledigt, True)

            'If Not Me.gen.IsNull(Me.gridPlans.ActiveRow) Then
            '    If Not Me.gridPlans.ActiveRow.IsGroupByRow And Not Me.gridPlans.ActiveRow.IsFilterRow Then
            '        If MsgBox("Wollen Sie den Planungseintrag wirklich als erledigt markieren?", MsgBoxStyle.YesNo, "Planungseintrag als erledigt markieren") = MsgBoxResult.Yes Then
            '            Me.Cursor = Cursors.WaitCursor
            '            If Me.compPlan1.updatePlanStatus(gridPlans.ActiveRow.Cells("ID").Value, "Erledigt") Then
            '                Me.searchPlans()
            '            End If
            '            Me.Cursor = Cursors.Default
            '        End If
            '    Else
            '        MsgBox("Keinen Planungseintrag ausgewählt!", MsgBoxStyle.Information, "Planungseintrag als erledigt markieren")
            '    End If
            'Else
            '    MsgBox("Keinen Planungseintrag ausgewählt!", MsgBoxStyle.Information, "Planungseintrag als erledigt markieren")
            'End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnPlanEntyOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanEntyOpen.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.PlanungseintragÖffnen()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lblResetSearching_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblResetSearching.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.resetUI()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub resetUI()
        Try
            Me.udtVon.Value = Nothing
            Me.udtBis.Value = Me.gen.getDate235959(Now.Date)

            Me.cboArt.cboComboBoxSelList.Value = Nothing
            Me.txtSearch.Text = ""

            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
            If Me.typUI = eTypUI.admin Then
                Me.cboUsers.Value = UserLoggedIn.Trim()
                'Me.cboUsers.Value = Nothing
                'Me.cboUsers.Text = ""

            ElseIf Me.typUI = eTypUI.user Then
                Me.cboUsers.Value = UserLoggedIn.Trim()

            End If

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.resetUI: " + ex.ToString())
        End Try
    End Sub

    Private Sub GruppierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruppierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.GruppierenToolStripMenuItem.Checked Then
                Me.gridPlans.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            Else
                Me.gridPlans.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ui As New UI()
            ui.setFilterGridKomplex(Me.gridPlans, Me.FilterToolStripMenuItem.Checked, True)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub gridPlans_BeforeRowActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridPlans.BeforeRowActivate
        Try
            e.Row.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub AlsExcelExportierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlsExcelExportierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.exportToExcel()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub exportToExcel()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim export As New PMDS.GUI.VB.gridExport()
            export.exportGrid(Me.gridPlans, PMDS.GUI.VB.gridExport.eTyp.excel, Nothing, "", Nothing, "")

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.exportToExcel: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub doActionDocusGrid(ByVal bSelect As Boolean, ByVal typAction As eDoAction, ByVal withMsgBox As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim retMsgBox As MsgBoxResult = MsgBoxResult.Yes
            If withMsgBox Then
                If typAction = eDoAction.alleAufErledigt Then
                    retMsgBox = doUI.doMessageBox3("DoYouRealyWantToMarkTheSelectedPlanEntriesAsDone", "Plans", MsgBoxStyle.YesNo, "?")
                End If

            End If

            If retMsgBox <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            Dim bSelectedOnly As Boolean = False
            If typAction <> eDoAction.selection Then
                bSelectedOnly = True
            End If

            Dim anz As Integer = 0
            Dim selectedRows As UltraGridRow() = PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridPlans, bSelectedOnly, True)
            If selectedRows.Count > 0 Then
                For Each r As UltraGridRow In selectedRows
                    If PMDS.Global.generic.IsInExpandedGroup(r) Then
                        Dim v As DataRowView = r.ListObject
                        Dim rActuellPlan As dsPlanSearch.planRow = v.Row

                        If typAction = eDoAction.selection Then
                            r.Selected = bSelect
                            anz += 1

                        ElseIf typAction = eDoAction.alleAufErledigt Then
                            Me.compPlan1.updatePlanStatus(rActuellPlan.ID, "Erledigt")
                            rActuellPlan.Delete()
                            anz += 1
                        End If
                    End If
                Next

                If typAction <> eDoAction.selection Then
                    If anz > 0 Then
                        Me.gridPlans.Refresh()
                        Me.gridPlans.UpdateData()
                    End If
                End If

                If withMsgBox Then
                    If typAction = eDoAction.alleAufErledigt Then
                        Dim strTitle As String = doUI.getRes("Plans")
                        Dim strText As String = doUI.getRes("ActivityPerformed2")
                        strText = String.Format(strText, anz.ToString())
                        doUI.doMessageBoxTranslated(strText, strTitle, "!")
                        If anz > 0 Then
                            'Me.searchEntriesForActivity(rSelActivity.ID)
                        End If

                    End If

                End If

            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.doActionDocusGrid: " + ex.ToString())
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Function getSelectedPlan(ByVal withMsgBox As Boolean, ByRef rowGrid As UltraGridRow) As dsPlanSearch.planRow
        Try
            If Not Me.gridPlans.ActiveRow Is Nothing Then
                If Me.gridPlans.ActiveRow.IsGroupByRow Or Me.gridPlans.ActiveRow.IsFilterRow Then
                    If withMsgBox Then
                        doUI.doMessageBox2("NoEntrySelected", "", "!")
                        Me.gridPlans.Focus()
                    End If
                    rowGrid = Nothing
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridPlans.ActiveRow.ListObject
                    Dim rSelPlan As dsPlanSearch.planRow = v.Row
                    rowGrid = Me.gridPlans.ActiveRow
                    Return rSelPlan
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Me.gridPlans.Focus()
                End If
                rowGrid = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.getSelectedPlan: " + ex.ToString())
        End Try
    End Function

    Private Sub AlleAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doActionDocusGrid(True, eDoAction.selection, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub KeineAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doActionDocusGrid(False, eDoAction.selection, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub WechelnZuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WechelnZuToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.wechselnZuPlanungseintrag(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub InNeuemTabÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InNeuemTabÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.wechselnZuPlanungseintrag(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub wechselnZuPlanungseintrag(ByVal neuesTab As Boolean)
        Try
            Dim gridIsInFront As Boolean = False
            Dim rowSelected As UltraGridRow = Nothing
            Dim rSelPlan As dsPlanSearch.planRow = Me.getSelectedPlan(True, rowSelected)
            If Not rSelPlan Is Nothing Then
                'Me.appManag1.wechselnZuObjectPlan(rSelPlan.ID, neuesTab, True)
            Else
                doUI.doMessageBox2("NoEntrySelected", "", "!")
            End If

        Catch ex As Exception
            Throw New Exception("frmOffeneTermine2.wechselnZuPlanungseintrag: " + ex.ToString())
        End Try
    End Sub


    Private Sub LayoutManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LayoutManagerToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

End Class