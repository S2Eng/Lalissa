Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing





Public Class contObjects


    Public compPlan1 As New compPlan()
    Public modalWindow As frmNachricht2
    Public isLoaded As Boolean = False

    Public Enum eTypActionPlanAnhang
        selection = 0
        delete = 1
    End Enum
    Public doUI1 As New doUI()
    Public gen As New General()






    Private Sub contObjects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub

    Private Sub WechselnZuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WechselnZuToolStripMenuItem.Click
        Try
            Me.openObjectAnhang(False)

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.ObjektHinzufügenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.VertragHinzufügenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.ObjektbezugLöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.SetRigthAussendienstmirarbeiter()

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contObjects.initControl: " + ex.ToString())
        End Try
    End Sub
    Public Function SetRigthAussendienstmirarbeiter()
        Try
            Dim IsAussendienstmitarbeiter As Boolean = False
            If IsAussendienstmitarbeiter Then
                For Each tpItm As ToolStripItem In Me.ContextMenuStrip1.Items
                    tpItm.Visible = False
                Next
                Me.ObjektHinzufügenToolStripMenuItem.Visible = True
                Me.VertragHinzufügenToolStripMenuItem.Visible = True
                Me.lblAddObject.Visible = True
                Me.lblAddContract.Visible = True
            End If

        Catch ex As Exception
            Throw New Exception("contObjects.SetRigthAussendienstmirarbeiter: " + ex.ToString())
        End Try
    End Function
    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.ObjektHinzufügenToolStripMenuItem.Visible = bEdit
            Me.VertragHinzufügenToolStripMenuItem.Visible = bEdit
            Me.ObjektbezugLöschenToolStripMenuItem.Visible = bEdit
            Me.ToolStripMenuItemSpace0.Visible = bEdit
            Me.ToolStripMenuItemSpace1.Visible = bEdit

            Me.lblAddObject.Visible = bEdit
            Me.lblAddContract.Visible = bEdit

            Me.SetRigthAussendienstmirarbeiter()

        Catch ex As Exception
            Throw New Exception("contObjects.lockUnlock: " + ex.ToString())
        End Try
    End Sub
    Public Sub openObjectAnhang(ByVal neuesTab As Boolean)
        Try
            Dim selRowAnhangObject As UltraGridRow = Nothing
            Dim rSelPlanAnhang As dsPlan.planObjectRow = Me.getSelectedAnhangObject(True, selRowAnhangObject)
            If Not rSelPlanAnhang Is Nothing Then
                'doManag.wechselnZu(Me.gridObjects.ActiveRow.Cells("IDObject").Value, neuesTab, False, True)        'lthNotPossibleAK
            End If

        Catch ex As Exception
            Throw New Exception("contObjects.openObjectAnhang: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData(ByVal IDPlan As System.Guid, ByVal setCountUI As Boolean)
        Try
            Me.DsPlan1.Clear()
            Me.compPlan1.getPlanObject(IDPlan, compPlan.eTypSelPlanObject.allIDPlan, Me.DsPlan1)
            Me.gridObjects.Refresh()

            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridObjects.Rows
                    Dim v As DataRowView = row.ListObject
                    Dim rObj As dsPlan.planObjectRow = v.Row

                    Dim rUsr As PMDS.db.Entities.Benutzer = b.getUser(rObj.ID, db)
                    row.Cells("Bezeichnung").Value = rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim()
                Next
            End Using
            'For Each rObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
            '    rObj.ObjectName = compObject1.getObjectName(IDObject)
            'Next

            If setCountUI Then
                Me.setCount()
            End If

        Catch ex As Exception
            Throw New Exception("contObjects.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub setCount()
        Try
            Dim anz As Integer = 0
            For Each rplanObject As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rplanObject.RowState <> DataRowState.Deleted Then
                    anz += 1
                Else
                    Dim s As String = ""
                End If
            Next

            Dim popContHistorie As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool
            'popContHistorie = Me.modalWindow.toolbarsManagerMain.Tools("popUpContUpObjects")
            'Me.modalWindow.toolbarsManagerMain.Tools("popUpContUpObjects").SharedProps.AppearancesLarge.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            'Me.modalWindow.toolbarsManagerMain.Tools("popUpContUpObjects").SharedProps.Caption = compAutoUI.getRes("Objects") + " (" + anz.ToString + ")"

        Catch ex As Exception
            Throw New Exception("contObjects.setCount: " + ex.ToString())
        End Try
    End Sub
    Public Sub save()
        Try
            Me.compPlan1.daPlanObject.Update(Me.DsPlan1.planObject)

        Catch ex As Exception
            Throw New Exception("contObjects.save: " + ex.ToString())
        End Try
    End Sub
    'Public Sub getPolices(ByRef lstPolicesExists As System.Collections.Generic.List(Of String))
    '    Try
    '        Dim b As New ITSContBusiness()
    '        Using db As ITSCont.db.Entities.ERModelITSContEntities = ITSContBusiness.getDBContext()
    '            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridObjects.Rows
    '                Dim v As DataRowView = row.ListObject
    '                Dim rObj As dsPlan.planObjectRow = v.Row

    '                Dim rContract As ITSCont.db.Entities.tblVertrag = b.getContractByID2(rObj.IDObject, db)
    '                If Not rContract Is Nothing Then
    '                    lstPolicesExists.Add(rContract.PolizzenNr.Trim())
    '                End If
    '            Next
    '        End Using

    '    Catch ex As Exception
    '        Throw New Exception("contObjects.getPolices: " + ex.ToString())
    '    End Try
    'End Sub
    Public Function checkObjectExists(ByVal IDObject As System.Guid, ByVal IDPlan As System.Guid) As Boolean
        Try
            Dim bObjExists As Boolean = False
            For Each rObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rObj.IDObject.Equals(IDObject) Then
                    bObjExists = True
                End If
            Next

            Return bObjExists

        Catch ex As Exception
            Throw New Exception("contObjects.checkObjectExists: " + ex.ToString())
        End Try
    End Function
    Public Sub checkAndAddNewObject(ByVal IDObject As System.Guid, ByVal IDPlan As System.Guid)
        Try
            Dim bObjExists As Boolean = False
            For Each rObj As dsPlan.planObjectRow In Me.DsPlan1.planObject
                If rObj.IDObject.Equals(IDObject) Then
                    bObjExists = True
                End If
            Next

            If Not bObjExists Then
                Dim rNewPlanObject As dsPlan.planObjectRow = Me.compPlan1.getNewRowPlanObject(Me.DsPlan1.planObject)
                rNewPlanObject.ID = System.Guid.NewGuid()
                rNewPlanObject.IDObject = IDObject
                rNewPlanObject.IDPlan = IDPlan
            End If
            Me.gridObjects.Refresh()


            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridObjects.Rows
                    Dim v As DataRowView = row.ListObject
                    Dim rObj As dsPlan.planObjectRow = v.Row
                    Dim rUsr As PMDS.db.Entities.Benutzer = b.getUser(rObj.ID, db)
                    row.Cells("Bezeichnung").Value = rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim()
                Next
            End Using

            Me.setCount()

        Catch ex As Exception
            Throw New Exception("contObjects.checkAndAddNewObject: " + ex.ToString())
        End Try
    End Sub
    Public Sub addNewObject(ByRef tPlanObjecs As dsPlan.planObjectDataTable, ByVal IDObject As System.Guid,
                            ByVal IDPlan As System.Guid, ByRef rPlan As dsPlan.planRow)
        Try
            Dim rNewPlanObject As dsPlan.planObjectRow = Me.compPlan1.getNewRowPlanObject(tPlanObjecs)
            rNewPlanObject.ID = System.Guid.NewGuid()
            rNewPlanObject.IDObject = IDObject
            rNewPlanObject.IDPlan = IDPlan

            'Dim gridRow As Infragistics.Win.UltraWinGrid.UltraGridRow = Me.gridObjects.Rows.GetRowWithListIndex(Me.DsPlan1.planObject.Rows.IndexOf(rNewPlanObject))
            'gridRow.Cells("Bezeichnung").Value = Me.compObject1.getObjectName(IDObject, False)

        Catch ex As Exception
            Throw New Exception("contObjects.addNewObject: " + ex.ToString())
        End Try
    End Sub

    Private Sub ObjektbezugLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjektbezugLöschenToolStripMenuItem.Click
        Try
            Me.doAction(eTypActionPlanAnhang.delete, True)

            'Dim selRowAnhangObject As UltraGridRow = Nothing
            'Dim rSelPlanAnhang As dsPlan.planObjectRow = Me.getSelectedAnhangObject(True, selRowAnhangObject)
            'If Not rSelPlanAnhang Is Nothing Then
            '    Dim IDObjectSaved As System.Guid = rSelPlanAnhang.IDObject
            '    rSelPlanAnhang.Delete()
            '    If Not Me.modalWindow.tPlanObjects Is Nothing Then
            '        Dim arrPlanAnhang As dsPlan.planObjectRow() = Me.modalWindow.tPlanObjects.Select(Me.DsPlan1.planObject.IDObjectColumn.ColumnName + "='" + IDObjectSaved.ToString() + "'")
            '        For Each rPlanAnhang As dsPlan.planObjectRow In arrPlanAnhang
            '            rPlanAnhang.Delete()
            '        Next
            '    End If

            '    Me.gridObjects.Refresh()
            'End If

            'Me.setCount()

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Public Function doAction(ByRef typAction As eTypActionPlanAnhang, ByRef withMsgBox As Boolean) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim arrSelected As New System.Collections.Generic.List(Of UltraGridRow)
            Dim sitemap1 As New PMDS.Global.generic()
            Dim res As System.Windows.Forms.DialogResult = sitemap1.doAction(PMDS.Global.generic.eAction.print, "", "", "", Me.gridObjects, Nothing, arrSelected, False, False)
            Dim listID As New System.Collections.Generic.List(Of System.Guid)
            If arrSelected.Count = 0 Then
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
                Me.Cursor = Cursors.Default
                Return False
            End If

            Dim resDoAction As MsgBoxResult = MsgBoxResult.Yes
            If withMsgBox Then
                If typAction = eTypActionPlanAnhang.selection Then

                ElseIf typAction = eTypActionPlanAnhang.delete Then
                    'resDoAction = ITSCont.core.SystemDb.doUI.doMessageBox("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?")
                End If
            End If

            If resDoAction = MsgBoxResult.Yes Then
                'Dim compActivities1 As New ITSCont.core.SystemDb.compActivities()
                'Dim tClipboard As New dsClipboard.clipboardDataTable()
                Dim anz As Integer = 0

                For Each rSelObjGrid As UltraGridRow In arrSelected
                    Dim v As DataRowView = rSelObjGrid.ListObject
                    Dim rSelPlanObject As dsPlan.planObjectRow = v.Row

                    If resDoAction = MsgBoxResult.Yes Then
                        If typAction = eTypActionPlanAnhang.selection Then
                            anz += 1

                        ElseIf typAction = eTypActionPlanAnhang.delete Then
                            Dim IDObjectSaved As System.Guid = rSelPlanObject.IDObject
                            rSelPlanObject.Delete()
                            'Dim arrPlanAnhang As dsPlan.planObjectRow() = Me.modalWindow.tPlanObjectsAllCopy.Select(Me.DsPlan1.planObject.IDObjectColumn.ColumnName + "='" + IDObjectSaved.ToString() + "'")
                            'For Each rPlanAnhang As dsPlan.planObjectRow In arrPlanAnhang
                            '    rPlanAnhang.Delete()
                            'Next
                            anz += 1

                        End If
                    End If
                Next

                If typAction = eTypActionPlanAnhang.selection Then

                ElseIf typAction = eTypActionPlanAnhang.delete Then
                    Me.gridObjects.Refresh()
                    Me.setCount()
                    If withMsgBox Then
                        'Dim strTitle As String = compAutoUI.getRes("Delete")
                        'Dim strText As String = compAutoUI.getRes("ActivityPerformed2")
                        'strText = String.Format(strText, anz.ToString())
                        'ITSCont.core.SystemDb.doUI.doMessageBoxTranslated(strText, strTitle, "!")
                    End If

                End If

                Return True
            End If

        Catch ex As Exception
            Throw New Exception("contObjects.doAction: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Function doTxtObjects() As Boolean
        Try
            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rSelObjGrid As UltraGridRow In Me.gridObjects.Rows
                    Dim v As DataRowView = rSelObjGrid.ListObject
                    Dim rSelPlanObject As dsPlan.planObjectRow = v.Row

                    If (b.checkIDIsBenutzer(rSelPlanObject.ID, db)) Then
                        Dim rUsr As PMDS.db.Entities.Benutzer = b.getUser(rSelPlanObject.ID, db)
                        rSelObjGrid.Cells("Bezeichnung").Value = rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim()

                    ElseIf (b.checkIDIsPatient(rSelPlanObject.ID, db)) Then
                        Dim rPat As PMDS.db.Entities.Patient = b.getPatient2(rSelPlanObject.ID, db)
                        rSelObjGrid.Cells("Bezeichnung").Value = rPat.Nachname.Trim() + " " + rPat.Vorname.Trim()

                    End If
                Next
            End Using

        Catch ex As Exception
            Throw New Exception("contObjects.doTxtObjects: " + ex.ToString())
        End Try
    End Function

    Public Function getSelectedAnhangObject(ByVal withMsgBox As Boolean, ByRef rowGrid As UltraGridRow) As dsPlan.planObjectRow
        Try
            If Not Me.gridObjects.ActiveRow Is Nothing Then
                If Me.gridObjects.ActiveRow.IsGroupByRow Or Me.gridObjects.ActiveRow.IsFilterRow Then
                    If withMsgBox Then
                        doUI.doMessageBox2("NoEntrySelected", "", "!")
                        Me.gridObjects.Focus()
                    End If
                    rowGrid = Nothing
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridObjects.ActiveRow.ListObject
                    Dim rSelPlanAnhang As dsPlan.planObjectRow = v.Row
                    rowGrid = Me.gridObjects.ActiveRow
                    Return rSelPlanAnhang
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Me.gridObjects.Focus()
                End If
                rowGrid = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contObjects.getSelectedAnhangObject: " + ex.ToString())
        End Try
    End Function

    Private Sub gridObjects_BeforeRowsDeleted(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridObjects.BeforeRowsDeleted
        Try
            'If Me.gridObjects.Focused Then
            '    e.Cancel = True
            'End If

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub

    Private Sub ObjektHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjektHinzufügenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.modalWindow.searchObjekts2(Nothing, frmNachricht.eTypUIPlan.addObjekt)

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InNeuemTabÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InNeuemTabÖffnenToolStripMenuItem.Click
        Try
            Me.openObjectAnhang(True)

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub

    Private Sub VertragHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VertragHinzufügenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.modalWindow.searchVerträge(frmNachricht.eTypUIPlan.addObjekt)

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
 
    Private Sub lblAddObject_Click(sender As Object, e As EventArgs) Handles lblAddObject.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.modalWindow.searchObjekts2(Nothing, frmNachricht.eTypUIPlan.addObjekt)

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub lblAddContract_Click(sender As Object, e As EventArgs) Handles lblAddContract.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.modalWindow.searchVerträge(frmNachricht.eTypUIPlan.addObjekt)

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnAssignOrderTask_Click(sender As Object, e As EventArgs) Handles btnAssignOrderTask.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.modalWindow.searchOrderTasks()

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
