Imports Infragistics.Win.UltraWinListView
Imports System.Windows.Forms




Public Class contListeAnhang

    Public modalWindow As frmNachricht
    Public general As New GeneralArchiv



    Private Sub contListeAnhang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub listDateiAnhang_ItemActivated(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListView.ItemActivatedEventArgs) Handles listDateiAnhang.ItemActivated
        Try

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub DateiÖffnen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.listDateiAnhang.Items.Count > 0 Then
                Dim clTag As New GeneralArchiv.clAnhang
                clTag = Me.listDateiAnhang.SelectedItems(0).Tag
                Dim clOpen As New clFolder
                Dim compPfad As New compSql
                Dim pfadArchivsystem As String = compPfad.pfadLesen()
                If Not general.IsNull(pfadArchivsystem) Then
                    If Not clOpen.openFile(clTag.datei, "", True, False) Then
                        clOpen.DateiSpeichernUnter(clTag.datei, "", False)
                        Exit Sub
                    End If
                Else
                    MsgBox("Es existiert keinArchivpfad im Archivsystem!" + vbNewLine + _
                                "Bitte wenden Sie sich an Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Anhang löschen")
            End If

        Catch ex As Exception
            Throw New Exception("DateiÖffnen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub listDateiAnhang_ItemDoubleClick(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinListView.ItemDoubleClickEventArgs) Handles listDateiAnhang.ItemDoubleClick
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiÖffnen()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub anhangLesen(ByVal clDateiToAdd As GeneralArchiv.clAnhang)
        Try
            Dim arrNeueDateien As New ArrayList
            For Each n As UltraListViewItem In Me.listDateiAnhang.Items
                Dim clTag As New GeneralArchiv.clAnhang
                clTag = n.Tag
                If clTag.NochSpeichern Then
                    arrNeueDateien.Add(clTag)
                End If
            Next
            Me.listDateiAnhang.Items.Clear()

            Dim comp As New compSql
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            IDOrdner = comp.GetIDOrdnerAnhangPlanungssystem()
            If Not general.IsNull(IDOrdner) Then
                Dim compPfad As New compSql
                Dim pfadArchivsystem As String = compPfad.pfadLesen()
                If Not general.IsNull(pfadArchivsystem) Then
                    Dim tblAnhang As New sqlAufgabenAnhang
                    tblAnhang.SelectRow_IDAufgabe(Me.modalWindow._idaufgabe)
                    Dim compDokuDaten As New compSql

                    For Each r As DataRow In tblAnhang.dtAufgabenAnhang.Rows
                        Dim dsDaten As New dsPlanArchive
                        dsDaten = compDokuDaten.LesenDatenFürDokument(r("IDDokumenteintrag"))
                        For Each r_daten As dsPlanArchive.tblDokumenteRow In dsDaten.tblDokumente
                            Dim clTag As New GeneralArchiv.clAnhang
                            Dim n As UltraListViewItem
                            n = Me.listDateiAnhang.Items.Add(r_daten.IDDokumenteintrag.ToString, r_daten.Bezeichnung)
                            clTag.Anhang = r("Anhang")
                            clTag.datei = pfadArchivsystem + "\" + r_daten.Archivordner + "\" + r_daten.DateinameArchiv
                            clTag.IDDokumenteneintrag = r_daten.IDDokumenteintrag
                            clTag.bezeichnung = r_daten.Bezeichnung
                            clTag.NochSpeichern = False
                            n.Tag = clTag
                            If r("Anhang") = True Then
                                n.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
                            Else
                                n.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
                            End If
                        Next
                    Next
                    If Not general.IsNull(clDateiToAdd) Then
                        Dim clTag As New GeneralArchiv.clAnhang
                        Dim n As UltraListViewItem
                        n = Me.listDateiAnhang.Items.Add(clDateiToAdd.IDDokumenteneintrag.ToString, clDateiToAdd.bezeichnung)
                        clTag.Anhang = clDateiToAdd.Anhang
                        clTag.datei = clDateiToAdd.datei
                        clTag.IDDokumenteneintrag = clDateiToAdd.IDDokumenteneintrag
                        clTag.bezeichnung = clDateiToAdd.bezeichnung
                        clTag.NochSpeichern = True
                        clTag.dateiAusArchiv = clDateiToAdd.dateiAusArchiv
                        n.Tag = clTag
                        n.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
                    End If
                    For Each cTag As GeneralArchiv.clAnhang In arrNeueDateien
                        Dim n As UltraListViewItem
                        n = Me.listDateiAnhang.Items.Add(cTag.IDDokumenteneintrag.ToString, cTag.bezeichnung)
                        n.Tag = cTag
                        n.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32)
                    Next
                End If
            End If

            If Me.listDateiAnhang.Items.Count > 0 Then
                Dim popContHistorie As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool
                popContHistorie = Me.modalWindow.UltraToolbarsManager.Tools("popUpContListeAnhang")
                Me.modalWindow.UltraToolbarsManager.Tools("popUpContListeAnhang").SharedProps.AppearancesLarge.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                Me.modalWindow.UltraToolbarsManager.Tools("popUpContListeAnhang").SharedProps.Caption = "Liste Anhang (" + Me.listDateiAnhang.Items.Count.ToString + ")"
            End If

        Catch ex As Exception
            Throw New Exception("anhangLesen: " + ex.ToString())
        End Try
    End Sub

    Public Sub anhangLöschen()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.listDateiAnhang.SelectedItems.Count > 0 Then
                If MsgBox("Wollen Sie den Anhang wirklich löschen?", MsgBoxStyle.YesNo, "Anhang löschen") = MsgBoxResult.Yes Then
                    Dim clDelete As New cArchive
                    Dim clTag As New GeneralArchiv.clAnhang
                    clTag = Me.listDateiAnhang.SelectedItems(0).Tag
                    If clTag.NochSpeichern Then
                        Me.listDateiAnhang.Items.Remove(Me.listDateiAnhang.SelectedItems(0))
                    Else
                        If clTag.Anhang Then
                            If clDelete.dateiAusArchivLöschen(clTag.IDDokumenteneintrag, False) Then
                                Dim tbl As New sqlAufgabenAnhang
                                tbl.DeleteRow_IDAufgabe_IDDokumenteintrag(Me.modalWindow._idaufgabe, clTag.IDDokumenteneintrag)
                                Me.anhangLesen(Nothing)
                            End If
                        Else
                            MsgBox("Dieser Anhang kann nicht gelöscht werden, da es sich um einen Anhang aus dem Archiv handelt!", MsgBoxStyle.Information, "Anhang löschen")
                        End If
                    End If
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Anhang löschen")
            End If

        Catch ex As Exception
            Throw New Exception("anhangLöschen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function addAnhang() As Boolean
        Try
            Dim clArchiv As New cArchive
            If Not clArchiv.checkSysOrdner_anhangPlanung() Then Return False

            Dim cl As New UIElements
            Dim datei As String = general.SelectFile(False, "All Files (*.*)|*.*|" +
                        "Microsoft Word Files (*.doc)|*.doc|" +
                        "Microsoft Excel Files (*.xls)|*.xls|" +
                        "Text Files (*.txt)|*.txt|" +
                        "pdf Files (*.pdf)|*.pdf|" +
                        "rtf Files (*.Rtf)|*.rtf")

            If Not general.IsNull(datei) Then
                Dim strOp As New clStringOperate
                Dim sBezeichnung As String = InputBox("Geben Sie eine Bezeichnung für den Anhang ein:", "Anhang speichern", strOp.GetFileName(datei, False))
                If Not general.IsNull(sBezeichnung) Then
                    Dim cAnhang As New GeneralArchiv.clAnhang
                    cAnhang.NochSpeichern = True
                    cAnhang.datei = datei
                    cAnhang.bezeichnung = sBezeichnung
                    cAnhang.IDDokumenteneintrag = System.Guid.NewGuid
                    cAnhang.Anhang = True
                    Me.anhangLesen(cAnhang)
                    Return True
                End If
            End If

        Catch ex As Exception
            Throw New Exception("addAnhang: " + ex.ToString())
        End Try
    End Function
    Public Function addAnhangAusArchiv(ByVal IDDokumenteneintrag As System.Guid, ByVal bezeichnung As String) As Boolean
        Try
            Dim cAnhang As New GeneralArchiv.clAnhang
            cAnhang.NochSpeichern = True
            cAnhang.dateiAusArchiv = True
            cAnhang.datei = ""
            cAnhang.bezeichnung = bezeichnung
            cAnhang.IDDokumenteneintrag = IDDokumenteneintrag
            Me.anhangLesen(cAnhang)

        Catch ex As Exception
            Throw New Exception("addAnhangAusArchiv: " + ex.ToString())
        Finally
        End Try
    End Function
    Public Function anhangSichern() As Boolean
        Try
            Dim comp As New compSql
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing

            IDOrdner = comp.GetIDOrdnerAnhangPlanungssystem()
            If Not General.IsNull(IDOrdner) Then
                For Each n As UltraListViewItem In Me.listDateiAnhang.Items
                    Dim clTag As New GeneralArchiv.clAnhang
                    clTag = n.Tag
                    If clTag.NochSpeichern And Not clTag.dateiAusArchiv Then
                        If System.IO.File.Exists(clTag.datei) Then
                            If Not general.IsNull(clTag.datei) Then
                                Dim strOp As New clStringOperate
                                Dim filInfoProvNote As New System.IO.FileInfo(clTag.datei)
                                Dim fileInfo As New clFileInfo

                                ' Read File into byte Array
                                Dim fs As New System.IO.FileStream(clTag.datei, IO.FileMode.Open, IO.FileAccess.Read)
                                Dim r As New System.IO.BinaryReader(fs)
                                Dim fileByte(fs.Length) As Byte
                                fileByte = r.ReadBytes(fs.Length)
                                fileInfo.fileB = fileByte

                                fileInfo.file_Bezeichnung = clTag.bezeichnung

                                fileInfo.file_erstelltAm = Now
                                fileInfo.file_geändertAm = Now
                                fileInfo.file_größe = filInfoProvNote.Length
                                fileInfo.file_IDOrdner = IDOrdner
                                fileInfo.file_name = strOp.GetFileName(clTag.datei, False)
                                fileInfo.file_origVerzeichnis = strOp.GetDir(clTag.datei)
                                fileInfo.file_typ = strOp.GetFiletyp(clTag.datei)
                                Dim arrFile As New ArrayList
                                arrFile.Add(fileInfo)
                                Dim obs As New ArrayList
                                'obs.Add(IDFirma.ToString)

                                Dim dataSchlagwortKat As New dsPlanArchive
                                Dim clSave As New cArchive
                                Dim ret As New cArchive.clRet
                                ret = clSave.DokumentInsArchivAblegen(arrFile, "Anhang für Planungssystem von " + Now.Date.ToString,
                                         Nothing, Nothing, "M", Nothing, obs, dataSchlagwortKat)
                                If ret.OK Then
                                    Dim tblAnhang As New sqlAufgabenAnhang
                                    tblAnhang.ID = System.Guid.NewGuid
                                    tblAnhang.IDAufgabe = Me.modalWindow._idaufgabe
                                    tblAnhang.IDDokumenteintrag = ret.arrIDDokumenteneintrag(0)
                                    tblAnhang.Anhang = True
                                    tblAnhang.InsertRow()
                                Else
                                    Throw New Exception("anhangSichern: Eine Datei konnte nicht als Anhang zu einem Termin/Webtermin gesichert werden!")
                                End If
                            End If
                        Else
                            MsgBox("Die Datei '" + clTag.datei + "' kann nicht hinzugefügt werden, da sie nicht mehr existiert!", MsgBoxStyle.Information, "Anhang hinzufügen")
                            Return False
                        End If

                    ElseIf clTag.NochSpeichern And clTag.dateiAusArchiv Then
                        Dim tblAnhang As New sqlAufgabenAnhang
                        tblAnhang.ID = System.Guid.NewGuid
                        tblAnhang.IDAufgabe = Me.modalWindow._idaufgabe
                        tblAnhang.IDDokumenteintrag = clTag.IDDokumenteneintrag
                        tblAnhang.Anhang = False
                        tblAnhang.InsertRow()

                    End If
                Next
                Return True
            Else
                MsgBox("Es existiert kein Systemordner für einen Dateianhang im Planungssystem!" + vbNewLine +
                        "Bitte wenden Sie sich an Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("anhangSichern: " + ex.ToString())
        End Try
    End Function
    Public Sub DateiInDieZwischenablageKopierenxy()
        Try
            Me.Cursor = Cursors.WaitCursor

            'If Me.listDateiAnhang.SelectedItems.Count > 0 Then
            '    Dim clTag As New General.clAnhang
            '    clTag = Me.listDateiAnhang.SelectedItems(0).Tag
            '    Dim clOpen As New S2CoreSystem.clFolder
            '    Dim compPfad As New S2ArchivWork.compPfad
            '    Dim pfadArchivsystem As String = compPfad.pfadLesen()
            '    If Not general.IsNull(pfadArchivsystem) Then
            '        Dim neuerName As String = InputBox("Name für die Zwischenablage:", "Datei in die Zwischenablage kopieren")
            '        If Not general.IsNull(neuerName) Then
            '            Dim cl As New S2ArchivWork.clArchivsystem
            '            If cl.dateiZurZwischenablageHinzufügen(clTag.datei, neuerName) <> "" Then
            '                MsgBox("Die Datei wurde in die Zwischenablage kopiert!", MsgBoxStyle.Information, "Zwischenablage kopieren")
            '            End If
            '        End If
            '    Else
            '        MsgBox("Es existiert keinArchivpfad im Archivsystem!" + vbNewLine + _
            '                    "Bitte wenden Sie sich an Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
            '    End If
            'Else
            '    MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Anhang löschen")
            'End If

        Catch ex As Exception
            Throw New Exception("DateiInDieZwischenablageKopieren: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DateiÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiÖffnen()

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub SpeichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeichernUnterToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.listDateiAnhang.SelectedItems.Count > 0 Then
                Dim clTag As New GeneralArchiv.clAnhang
                clTag = Me.listDateiAnhang.SelectedItems(0).Tag
                Dim clOpen As New clFolder
                Dim compPfad As New compSql
                Dim pfadArchivsystem As String = compPfad.pfadLesen()
                If Not general.IsNull(pfadArchivsystem) Then
                    clOpen.DateiSpeichernUnter(clTag.datei, "", False)
                    Exit Sub
                Else
                    MsgBox("Es existiert keinArchivpfad im Archivsystem!" + vbNewLine + _
                                "Bitte wenden Sie sich an Ihren Administrator.", MsgBoxStyle.Information, "Archivsystem")
                End If
            Else
                MsgBox("Es wurde keine Datei ausgewählt!", MsgBoxStyle.Information, "Anhang löschen")
            End If

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager1.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "InZwischenablageKopieren"
                'If Not Me.checkLizenzArchivsystem(True) Then Exit Sub
                'Me.DateiInDieZwischenablageKopieren()

                Case "AnhangLöschen"
                    Me.anhangLöschen()

            End Select

        Catch ex As Exception
            general.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
