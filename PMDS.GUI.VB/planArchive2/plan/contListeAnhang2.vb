Imports Infragistics.Win.UltraWinListView
Imports System.Windows.Forms
Imports System.Drawing



Public Class contListeAnhang2

    Public _IDPlan As Guid = Nothing

    Public modalWindow As frmNachricht3
    Public general As New General

    Public compPlan1 As New compPlan()
    Public ui As New UI
    Public fct As New QS2.functions.vb.functOld()

    Public tPlanAnhangSich As New dsPlan.planAnhangDataTable()
    Public isLoaded As Boolean = False
    Public editable As Boolean = False
    Public doUI1 As New doUI()

    Public popupContMainSearch As Infragistics.Win.Misc.UltraPopupControlContainer = Nothing






    Private Sub contListeAnhang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            If Me.isLoaded Then Exit Sub

            Me.LöschenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnAddFile.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub lockUnlockMain(ByVal bEdit As Boolean)
        Try
            Me.ToolStripMenuItemSpace1.Visible = bEdit
            Me.LöschenToolStripMenuItem.Visible = bEdit

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.lockUnlockMain: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadData(ByVal idPlan As System.Guid)
        Try
            Me._IDPlan = idPlan
            Me.DsPlan2.Clear()
            Me.compPlan1.getPlanAnhang(idPlan, compPlan.eTypSelPlanAnhang.idPlan, Me.DsPlan2)
            Me.UltraGrid1.Refresh()

            Me.doCount()

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.loadData: " + ex.ToString())
        End Try
    End Sub
    Public Sub doCount()
        Try


        Catch ex As Exception
            Throw New Exception("contListeAnhang2.doCount: " + ex.ToString())
        End Try
    End Sub
    Public Sub löschen()
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not Me.UltraGrid1.ActiveRow Is Nothing Then
                If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                    Dim v As DataRowView = Me.UltraGrid1.ActiveRow.ListObject
                    Dim rObj As dsPlan.planAnhangRow = v.Row
                    rObj.Delete()
                    Me.doCount()
                End If
            End If
        Catch ex As Exception
            Throw New Exception("contListeAnhang2.löschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub anhangTempSichern()
        Try
            Me.tPlanAnhangSich.Clear()
            For Each rPlanAnhang As dsPlan.planAnhangRow In Me.DsPlan2.planAnhang
                Dim rNew As dsPlan.planAnhangRow = Me.tPlanAnhangSich.NewRow()
                rNew.ItemArray = rPlanAnhang.ItemArray
                Me.tPlanAnhangSich.Rows.Add(rNew)
            Next

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.anhangTempSichern: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadAnhangTemp(ByVal IDPlan As System.Guid, ByVal dsPlanNew As dsPlan)
        Try
            For Each rPlanAnhang As dsPlan.planAnhangRow In Me.tPlanAnhangSich
                Dim rNew As dsPlan.planAnhangRow = dsPlanNew.planAnhang.NewRow()
                rNew.ItemArray = rPlanAnhang.ItemArray
                rNew.IDPlan = IDPlan
                rNew.ID = System.Guid.NewGuid()
                dsPlanNew.planAnhang.Rows.Add(rNew)
            Next

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.loadAnhangTemp: " + ex.ToString())
        End Try
    End Sub
    Public Function anhangHinzufügen(ByVal idPlan As System.Guid) As Boolean
        Try
            Dim GeneralArchiv1 As New GeneralArchiv()
            Dim selectedFile As String = ""
            selectedFile = GeneralArchiv1.SelectFile(True, "")
            If Not general.IsNull(selectedFile) Then
                Dim dateiTyp As String = fct.GetFiletyp(selectedFile)
                Dim bez As String = Microsoft.VisualBasic.InputBox(doUI.getRes("AddAppendix"), doUI.getRes("EnterANameForTheDocument"), fct.GetFileName(selectedFile, True))
                If bez <> "" Then
                    Dim bs() As Byte = general.readByteStreamFile(selectedFile)
                    Me.addFile(bs, bez, dateiTyp, idPlan)
                End If
                Me.doCount()
            End If

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.anhangHinzufügen: " + ex.ToString())
        End Try
    End Function
    Public Function addAnhangAusArchiv(ByVal byteStream() As Byte, ByVal bezeichnung As String, ByVal DateiTyp As String,
                                       ByVal idPlan As System.Guid) As Boolean
        Try
            Me.addFile(byteStream, bezeichnung, DateiTyp, idPlan)
            Me.doCount()

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.addAnhangAusArchiv: " + ex.ToString())
        End Try
    End Function
    Public Function addFile(ByVal byteStream() As Byte, ByVal bezeichnung As String, ByVal DateiTyp As String,
                            ByVal idPlan As System.Guid) As Boolean
        Try
            Dim rNew As dsPlan.planAnhangRow = Me.compPlan1.getNewRowPlanAnhang(Me.DsPlan2.planAnhang, idPlan)
            rNew.doku = byteStream
            rNew.Bezeichnung = bezeichnung
            rNew.DateiTyp = DateiTyp
            Me.UltraGrid1.Refresh()

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.addFile: " + ex.ToString())
        End Try
    End Function
    Public Sub copyAnhänge(ByRef tAnhangCopyTo As dsPlan.planAnhangDataTable, ByRef idPlanToCopy As System.Guid)
        Try
            For Each rAnhangFound As dsPlan.planAnhangRow In Me.DsPlan2.planAnhang
                Dim rNewAnhang As dsPlan.planAnhangRow = Me.compPlan1.getNewRowPlanAnhang(tAnhangCopyTo, System.Guid.NewGuid())
                rNewAnhang.ItemArray = rAnhangFound.ItemArray
                rNewAnhang.ID = System.Guid.NewGuid()
                rNewAnhang.IDPlan = idPlanToCopy
            Next

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.copyAnhänge: " + ex.ToString())
        End Try
    End Sub
    Public Function setLabelCount2(IDRes As String) As String
        Try
            Dim iCounter As Integer = 0
            For Each rPlanAnhang As dsPlan.planAnhangRow In Me.DsPlan2.planAnhang
                If rPlanAnhang.RowState <> DataRowState.Deleted Then
                    iCounter += 1
                End If
            Next

            Dim sTxtReturn As String = doUI.getRes(IDRes.Trim()) + " (" + iCounter.ToString() + ")"
            Return sTxtReturn.Trim()

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.setLabelCount: " + ex.ToString())
        End Try
    End Function

    Public Function save(ByVal IDPlan As System.Guid) As Boolean
        Try
            Me.compPlan1.daPlanAnhang.Update(Me.DsPlan2.planAnhang)

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.save: " + ex.ToString())
        End Try
    End Function

    Private Sub DateiÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.openAnhang()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub openAnhang()
        Try
            If Not Me.UltraGrid1.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.UltraGrid1.ActiveRow.ListObject
                Dim rAnh As dsPlan.planAnhangRow = v.Row
                Dim clOpen As New UI()
                Dim clArchiv As New cArchive()
                clOpen.openFile(clArchiv.getFileFromDB(rAnh.Bezeichnung, rAnh.DateiTyp, rAnh.doku), "", False, Nothing, False, True, False)
            End If

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.openAnhang: " + ex.ToString())
        End Try
    End Sub
    Public Sub speichernUnter()
        Try
            If Not Me.UltraGrid1.ActiveRow Is Nothing Then
                Dim v As DataRowView = Me.UltraGrid1.ActiveRow.ListObject
                Dim rAnh As dsPlan.planAnhangRow = v.Row
                Dim clOpen As New UI()
                Dim clArchiv As New cArchive()
                clOpen.saveFileAs(clArchiv.getFileFromDB(rAnh.Bezeichnung, rAnh.DateiTyp, rAnh.doku), rAnh.DateiTyp)
            End If

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.speichernUnter: " + ex.ToString())
        End Try
    End Sub
    Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Try
            Me.speichernUnter()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UltraGrid1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid1.DoubleClick
        Try
            Me.openAnhang()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub LöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        Try
            Me.löschen()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Function getAllFiles() As dsPlan.planAnhangDataTable
        Try
            Return Me.DsPlan2.planAnhang

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Function

    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.editable = bEdit
            Me.btnAddFile.Visible = bEdit
            If Me.editable Then
                Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
            Else
                Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            End If

        Catch ex As Exception
            Throw New Exception("contListeAnhang2.lockUnlock: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraGrid1_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles UltraGrid1.BeforeCellActivate
        Try
            If Not Me.editable Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Else
                If e.Cell.Column.ToString() = Me.DsPlan2.planAnhang.BezeichnungColumn.ColumnName Then
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Else
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                End If

            End If
        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnAddFile_Click(sender As Object, e As EventArgs) Handles btnAddFile.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.anhangHinzufügen(Me._IDPlan)

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
