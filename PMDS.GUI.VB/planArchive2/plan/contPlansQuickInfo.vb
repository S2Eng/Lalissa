Imports Infragistics.Win.UltraWinGrid



Public Class contPlansQuickInfo

    Public gen As New General()
    Public isLoaded As Boolean = False

    Public _IDChild As System.Guid = Nothing
    Public _typBundleUI As New eTypBundleUI
    Public Enum eTypBundleUI
        obj = 0
        contract = 1
    End Enum
    Public suchePlan1 As New suchePlan()
    Public ui1 As New UI()

    Public container_InfoCalc As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool
    Public doUI1 As New doUI()

    Public editable As Boolean = False

    Public Enum eDoAction
        delete = 0
        markAsDone = 1
        selection = 10
    End Enum

    Public UIGlobal1 As New PMDS.Global.UIGlobal()
    Public dsSelListType As New dsAuswahllisten()








    Public Sub initControl(ByRef typBundleUI As eTypBundleUI)
        Try
            If Me.isLoaded Then Return

            Me.Text = compAutoUI.getRes("ImportantPlans")

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
            Me.grpInfo.Text = compAutoUI.getRes("ImportantPlans")

            Me._typBundleUI = typBundleUI
            'Me.PanelInfo.BackColor = Me.gen.color_standardBlue

            Me.container_InfoCalc = Me.UltraToolbarsManager1.Tools("popUpInfo")
            Me.dropDownInfo.PopupItem = Me.container_InfoCalc

            For Each col As UltraGridColumn In Me.gridPlansQuick.DisplayLayout.Bands(0).Columns
                col.Hidden = True
            Next

            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Hidden = False
            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.FälligAmColumn.ColumnName).Hidden = False
            'Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName).Hidden = False
            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns("typeTxt").Hidden = False
            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns("typeTxt").Header.Caption = compAutoUI.getRes("Type")

            Me.toolbarQuickPlans.Tools("btnAddPlan").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.toolbarQuickPlans.Tools("btnMarkAsDone").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.toolbarQuickPlans.Tools("btnDelete").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.AlsErledigtMarkierenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.doTypesPlan(True)
            Me.gen.getAllSachb(Nothing, Me.gridPlansQuick.DisplayLayout.ValueLists("Users"))

            'Dim PopupContainer As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = Me.UltraToolbarsManager1.Tools("popUpInfo")
            'PopupContainer.Control = Me.PanelInfo

            'Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.BetreffColumn.ColumnName).Header.Caption = compAutoUI.getRes("Created")
            'Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.FälligAmColumn.ColumnName).Header.Caption = compAutoUI.getRes("ErstelltVon")
            'Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDTypColumn.ColumnName).Header.Caption = compAutoUI.getRes("Main")

            Me.dropDownInfo.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.loadData(True, Nothing)
            Me.lockUnlock(True)

            Me.isLoaded = True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub doTypesPlan(ByVal loadList As Boolean)
        Try
            Dim DropDownGridSelListType As New dropDownGridSelList
            DropDownGridSelListType.initControl(True)
            DropDownGridSelListType.loadSelList("PT", General.eKeyCol.IDNr)

            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDArtColumn.ColumnName).ValueList = DropDownGridSelListType.dropDownSelList
            Me.gridPlansQuick.DisplayLayout.Bands(0).Columns(Me.DsPlanSearch1.plan.IDArtColumn.ColumnName).Style = ColumnStyle.DropDownList

            Me.dsSelListType.Clear()
            Me.gridPlansQuick.DisplayLayout.ValueLists("Typ").ValueListItems.Clear()
            'Me.clObjekte1.loadAuswahlliste(Me.gridPlansQuick.DisplayLayout.ValueLists("Typ"), Nothing, "PT", Me.dsSelListType, "", "", core.SystemDb.Enums.eKeyCol.IDNr)
            Me.gen.loadAuswahlliste(Nothing, Nothing, "PT", Me.dsSelListType, "", "", General.eKeyCol.IDNr, Nothing, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub setToolTipDropDownButt(ByVal tooltipTitle As String, ByVal tooltipText As String)
        Dim infoToolTip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
        infoToolTip.ToolTipTitle = tooltipTitle
        infoToolTip.ToolTipText = tooltipText
        Me.UltraToolTipManager1.SetUltraToolTip(Me.dropDownInfo, infoToolTip)
    End Sub

    Public Function loadData(ByVal init As Boolean, ByVal IDChild As System.Guid) As Boolean
        Try
            Me.clearControl()

            Me.DsPlanSearch1.Clear()
            Me._IDChild = System.Guid.NewGuid
            If Not init Then
                Me._IDChild = IDChild
            End If

            Dim SqlCommandReturn As String = ""
            Dim dsPlan1 As New dsPlan()
            Dim rPlanObj As dsPlan.planObjectRow = CompPlan1.getNewRowPlanObject(dsPlan1.planObject)
            rPlanObj.IDObject = Me._IDChild
            Me.suchePlan1.searchPlan2(Me.DsPlanSearch1, "", "", "", Nothing, Nothing, "", False, dsPlan1.planObject, True, "",
                                      False, Nothing, Nothing, True, 0, 0, Nothing, -1, Nothing, -1, False, SqlCommandReturn, "", "")
            Me.gridPlansQuick.Refresh()
            Me.lblCount.Text = compAutoUI.getRes("Founded") + ": " + Me.DsPlanSearch1.plan.Rows.Count.ToString()

            For Each rGrid As UltraGridRow In Me.gridPlansQuick.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rSelPlan As dsPlanSearch.planRow = v.Row

                Dim arrTypeFound() As dsAuswahllisten.AuswahllistenRow = Me.dsSelListType.Auswahllisten.Select(Me.dsSelListType.Auswahllisten.IDNrColumn.ColumnName + "='" + rSelPlan.IDArt.ToString() + "'", "")
                If arrTypeFound.Length <> 1 Then
                    Throw New Exception("loadTypesPlan: plan.Type '" + rSelPlan.IDTyp.ToString() + "' in SelList 'PT' not found!")
                Else
                    rGrid.Cells("typeTxt").Value = compAutoUI.getRes(arrTypeFound(0).Bezeichnung)
                End If
            Next

            If Not init Then
                If Me.DsPlanSearch1.plan.Rows.Count > 0 Then
                    Me.setToolTipDropDownButt(compAutoUI.getRes("ImportantPlans"), compAutoUI.getRes("ThereAreImportantendPlans"))
                    Me.dropDownInfo.Text = "(" + Me.DsPlanSearch1.plan.Rows.Count.ToString() + ")"
                Else
                    Me.setToolTipDropDownButt(compAutoUI.getRes("ImportantPlans"), compAutoUI.getRes("NoImportantendPlans"))
                    Me.dropDownInfo.Text = ""
                End If
            Else
                Me.setToolTipDropDownButt("", "")
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Function

    Public Sub popUpControl()
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            'Me.loadData(False)
            Me.dropDownInfo.DropDown()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub clearControl()
        Try
            Me.DsPlanSearch1.Clear()
            Me.gridPlansQuick.Refresh()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub gridActivities_BeforeRowActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles gridPlansQuick.BeforeRowActivate
        e.Row.Activation = Activation.NoEdit
    End Sub
    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.editable = bEdit
            Me.PanelTop.Visible = bEdit

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub dropDownInfo_MouseEnterElement(ByVal sender As System.Object, ByVal e As Infragistics.Win.UIElementEventArgs) Handles dropDownInfo.MouseEnterElement

    End Sub
    Private Sub dropDownInfo_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropDownInfo.MouseLeave
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            'Me.UltraToolTipManager1.ShowToolTip(Me.dropDownInfo)
            'Me.dropDownInfo.CloseUp()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub dropDownInfo_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dropDownInfo.MouseUp
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.loadDataUI()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub loadDataUI()
        Try
            If Me.dropDownInfo.IsDroppedDown Then
                'Me.grpInfo.Appearance.BorderAlpha = Infragistics.Win.Alpha.UseAlphaLevel
                'Me.grpInfo.Appearance.AlphaLevel = 255
                Me.loadData(False, Me._IDChild)
                Me.dropDownInfo.DropDown()
                'Me.UltraToolTipManager1.ShowToolTip(Me.dropDownInfo)
            Else
                Me.dropDownInfo.CloseUp()

            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UltraToolbarsManager2_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles toolbarQuickPlans.ToolClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "btnAddPlan"
                    Me.addPlan()

                Case "btnMarkAsDone"
                    Me.doActionQuickPlans(False, eDoAction.markAsDone, True)

                Case "btnDelete"
                    Me.doActionQuickPlans(False, eDoAction.delete, True)

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub addPlan()
        Try
            Me.gen.newMessage(Now, Now, New dsPlan.planObjectDataTable(), Nothing, Nothing, Nothing, False, False,
                                "", "", Nothing, False, False)


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub doActionQuickPlans(ByVal bSelect As Boolean, ByVal typAction As eDoAction, ByVal withMsgBox As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim sStatus As String = ""
            Dim retMsgBox As MsgBoxResult = MsgBoxResult.Yes
            If withMsgBox Then
                If typAction = eDoAction.delete Then
                    retMsgBox = doUI.doMessageBox("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?")

                ElseIf typAction = eDoAction.markAsDone Then
                    retMsgBox = doUI.doMessageBox("DoYouRealyWantToMarkTheSelectedPlanEntriesAsDone", "SendEMails", MsgBoxStyle.YesNo, "?")

                End If
            End If

            If retMsgBox <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            Dim bSelectedOnly As Boolean = False
            If typAction <> eDoAction.selection Then
                bSelectedOnly = True
            End If

            Dim generic1 As New PMDS.Global.generic()
            Dim anz As Integer = 0
            Dim selectedRows As UltraGridRow() = PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridPlansQuick, bSelectedOnly, True)
            If selectedRows.Count > 0 Then
                For Each r As UltraGridRow In selectedRows
                    If generic1.IsInExpandedGroup(r) Then
                        Dim v As DataRowView = r.ListObject
                        Dim rSelPlan As dsPlanSearch.planRow = v.Row

                        If typAction = eDoAction.selection Then
                            r.Selected = bSelect
                            anz += 1

                        ElseIf typAction = eDoAction.delete Then
                            Me.CompPlan1.deletePlan(rSelPlan.ID)
                            rSelPlan.Delete()
                            anz += 1

                        ElseIf typAction = eDoAction.markAsDone Then
                            Me.CompPlan1.updatePlanStatus(rSelPlan.ID, "Erledigt")
                            anz += 1

                        End If
                    End If
                Next

                If typAction <> eDoAction.selection Then
                    If anz > 0 Then
                        Me.gridPlansQuick.Refresh()
                        Me.gridPlansQuick.UpdateData()
                    End If
                End If

                If withMsgBox Then
                    If typAction = eDoAction.delete Then
                        Dim strTitle As String = compAutoUI.getRes("Delete")
                        Dim strText As String = compAutoUI.getRes("ActivityPerformed2")
                        strText = String.Format(strText, anz.ToString())
                        doUI.doMessageBoxTranslated(strText, strTitle, "!")
                        If anz > 0 Then
                            Me.loadData(False, Me._IDChild)
                        End If

                    ElseIf typAction = eDoAction.markAsDone Then
                        Dim strTitle As String = compAutoUI.getRes("Delete")
                        Dim strText As String = compAutoUI.getRes("ActivityPerformed2")
                        strText = String.Format(strText, anz.ToString())
                        doUI.doMessageBoxTranslated(strText, strTitle, "!")
                        If anz > 0 Then
                            Me.loadData(False, Me._IDChild)
                        End If

                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub openPlan(ByVal withMsgBox As Boolean)
        Try
            Dim rowGridSelected As UltraGridRow = Nothing
            Dim rSelPlan As dsPlanSearch.planRow = Me.getSelectedPlan(withMsgBox, rowGridSelected)
            If Not rSelPlan Is Nothing Then
                Dim UI1 As New UI()
                UI1.openMessage(rSelPlan.ID, Nothing, Nothing, False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Function getSelectedPlan(ByVal withMsgBox As Boolean, ByRef rowGrid As UltraGridRow) As dsPlanSearch.planRow
        Try
            If Not Me.gridPlansQuick.ActiveRow Is Nothing Then
                If Me.gridPlansQuick.ActiveRow.IsGroupByRow Or Me.gridPlansQuick.ActiveRow.IsFilterRow Then
                    If withMsgBox Then
                        doUI.doMessageBox("NoEntrySelected", "", "!")
                        Me.gridPlansQuick.Focus()
                    End If
                    rowGrid = Nothing
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridPlansQuick.ActiveRow.ListObject
                    Dim rSelPlan As dsPlanSearch.planRow = v.Row
                    rowGrid = Me.gridPlansQuick.ActiveRow
                    Return rSelPlan
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox("NoEntrySelected", "", "!")
                    Me.gridPlansQuick.Focus()
                End If
                rowGrid = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Function

    Private Sub ÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.openPlan(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub gridPlansQuick_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridPlansQuick.DoubleClick
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If UIGlobal1.evDoubleClickOK(sender, e, Me.gridPlansQuick) Then
                Me.openPlan(False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
 
    Private Sub gridPlansQuick_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridPlansQuick.BeforeRowsDeleted
        Try
            If gridPlansQuick.Focused Then
                e.DisplayPromptMsg = False
            Else
                e.DisplayPromptMsg = False
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub AlsErledigtMarkierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlsErledigtMarkierenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doActionQuickPlans(False, eDoAction.markAsDone, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AlleAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doActionQuickPlans(True, eDoAction.selection, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub KeineAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.doActionQuickPlans(False, eDoAction.selection, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

 
End Class
