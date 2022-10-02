Imports PMDS.Global



Public Class ucBiografie

    Private contTxtEditor1 As New QS2.Desktop.Txteditor.contTxtEditor()
    Private ucVorhandeneBiografien As New ucBiografienVorh()
    Private dbBiografien As New sqlBiografien

    Private gen As New GeneralArchiv()
    Private compPatient As New compSql
    Private doBookmarks As New QS2.Desktop.Txteditor.doBookmarks()
    Public doEditor As New QS2.Desktop.Txteditor.doEditor()




    Public Enum uiState
        formularAnzeigen = 0
        formularNeuErstellen = 1
        leer = 2
    End Enum

    Private _istoSave As Boolean
    Public IDPatient As Guid

    '_MaxFormularCount: 0 ist unbegrenzt, 1 = 1, sonst kein Auswahl zur Zeit 
    Private ReadOnly _MaxFormularCount = 1
    Private ReadOnly EnableSavedFormularEdit = True

    Private Sub ucBiographie_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub loadForm()
        Try 
            Me.PanelEditor2.Controls.Add(Me.contTxtEditor1)
            Me.contTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
            Me.contTxtEditor1.LinealeOnOff(True)
            Me.contTxtEditor1.SetUIReadOnOff(False)
            Me.contTxtEditor1.loadForm(False, Nothing, False)
            Me.contTxtEditor1.setControlTyp()
            Me.contTxtEditor1.FileNew(False, False)

            Me.ucVorhandeneBiografien.modalWindow = Me
            Me.uPopupContContainerVorhBiografien.PopupControl = Me.ucVorhandeneBiografien
            Me.uDropDownButtVorhBiografien.PopupItem = Me.uPopupContContainerVorhBiografien

            Me.btnArchivAblegen.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Oeffnen, QS2.Resources.getRes.ePicTyp.ico)


            AddHandler Me.contTxtEditor1.textControl1_IsToSave, AddressOf Me.EnableDisableButtons

        Catch ex As Exception
            Throw New Exception("loadForm:" + ex.ToString())
        End Try
    End Sub

    Public Sub loadDatenFürPatient()
        Me.dbBiografien.DataTable.Rows.Clear()
        ui_onOff(uiState.leer)
        Me.ucVorhandeneBiografien.loadBiografien(True)
        Me.contTxtEditor1.setControlTyp()

    End Sub
    Public Sub loadFormular(ByVal ID As System.Guid, ByVal load As Boolean)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.dbBiografien.DataTable.Rows.Clear()
            ui_onOff(uiState.formularAnzeigen)
            Me.dbBiografien.loadFormular(ID)
            If Me.dbBiografien.DataTable.Rows.Count = 1 Then
                Dim r As DataRow = Me.dbBiografien.DataTable.Rows(0)
                Me.contTxtEditor1.showText(r("BLOP"), TXTextControl.StreamType.RichTextFormat, EnableSavedFormularEdit, TXTextControl.ViewMode.PageView)

                Dim ben As New PMDS.BusinessLogic.Benutzer(gen.StrToGuid(r("IDBenutzer_Erstellt").ToString))
                Me.lblErstelltVon.Text = "Von: " + ben.BenutzerName
                Me.lblErstelltVon.Tag = ID
                Me.lblErstelltAm.Text = "Am: " + Format(r("Datumerstellt"), "dd.MM.yyyy HH:mm").ToString
                Me.lblErstelltAm.Tag = Format(r("Datumerstellt"), "dd.MM.yyyy HH:mm").ToString
                contTxtEditor1.ISTOSAVE = False
                'RefreshbtnPlusMinusVisibity(0, False)

            Else
                Throw New Exception("loadFormular: Fehler beim Laden des Formulares (ID: " + ID.ToString + ")")
            End If

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Property ISTOSAVE() As Boolean
        Get
            Return contTxtEditor1.ISTOSAVE
        End Get
        Set(ByVal value As Boolean)
            contTxtEditor1.ISTOSAVE = value
        End Set
    End Property

    Public Sub RefreshbtnPlusMinusVisibity(ByVal BiographienAnzahl As Int16, ByVal useit As Boolean)

        btnMinus.Visible = Not (Me.lblErstelltVon.Tag Is Nothing)

        If (MaxFormularCount = 0) Then
            btnPlusxyxy.Visible = True
        ElseIf (useit And BiographienAnzahl = 0) Then
            btnPlusxyxy.Visible = True
        Else : btnPlusxyxy.Visible = False

        End If

        ' bei fehlendem Recht: Button jedenfalls ausblenden
        If ENV.HasRight(UserRights.DatenerhebungAendern) = False Then
            Me.btnPlusxyxy.Visible = False
            Me.btnSpeichern.Visible = False
        End If

        If ENV.HasRight(UserRights.DatenerhebungLoeschen) = False Then
            Me.btnMinus.Visible = False
            Me.btnSpeichern.Visible = False
        End If

        If ENV.HasRight(UserRights.DatenerhebungAnzeigen) = False Then
            Me.uDropDownButtVorhBiografien.Visible = False
            Me.btnPlusxyxy.Visible = False
            Me.btnMinus.Visible = False
            Me.btnSpeichern.Visible = False
        End If

    End Sub

    Public ReadOnly Property MaxFormularCount() As Int16
        Get
            Return _MaxFormularCount
        End Get
    End Property

    Public Sub saveFormular()
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If (Me.lblErstelltVon.Tag Is Nothing Or Me.dbBiografien.DataTable.Rows.Count = 0) Then
                Dim ret As clObject = Me.dbBiografien.InsertRow(doEditor.getText(TXTextControl.StreamType.RichTextFormat, Me.contTxtEditor1.textControl1), IDPatient)
                If ret.ok Then
                    Me.loadFormular(gen.StrToGuid(ret.id), True)
                    contTxtEditor1.ISTOSAVE = False
                Else
                    Throw New Exception("saveFormular: Fehler beim Speichern des Formulares!")
                End If

            ElseIf (MaxFormularCount = 0 And Not (Me.lblErstelltVon.Tag = Me.dbBiografien.DataTable.Rows(0).Item("ID"))) Then
                Dim ret As clObject = Me.dbBiografien.InsertRow(Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, Me.contTxtEditor1.textControl1), IDPatient)
                If ret.ok Then
                    Me.loadFormular(gen.StrToGuid(ret.id), True)
                    contTxtEditor1.ISTOSAVE = False
                Else
                    Throw New Exception("saveFormular: Fehler beim Speichern des Formulares!")
                End If

            Else : Dim ret As Boolean = Me.dbBiografien.UpdateBiographie(Me.dbBiografien.DataTable.Rows(0).Item("ID"), Me.doEditor.getText(TXTextControl.StreamType.RichTextFormat, Me.contTxtEditor1.textControl1))
                If ret Then
                    contTxtEditor1.ISTOSAVE = False
                    'Me.loadFormular(gen.StrToGuid(Me.dbBiografien.DataTable.Rows(0).Item("ID").ToString), True)
                Else
                    Throw New Exception("saveFormular: Fehler beim Speichern des Formulares!")
                End If
            End If


            ui_onOff(uiState.formularAnzeigen)

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Public Sub loadFormularvorlage(ByVal vorlageRTF As String)
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.ui_onOff(uiState.formularNeuErstellen)
            Me.contTxtEditor1.showFile(vorlageRTF, False, TXTextControl.StreamType.RichTextFormat, TXTextControl.ViewMode.PageView, True)
            Me.fillFormTemplate()
            'Me.contTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.Normal

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub fillFormTemplate()
        Try

            'Dim dsPatientInfo1 As dsPatientInfo = compPatient.getPatientendaten(PMDS.Global.Settings.CurrentIDPatient)

            Dim p As New PMDS.BusinessLogic.Patient(PMDS.Global.ENV.CurrentIDPatient)

            If Not IsDBNull(p.Aufenthalt.IDAbteilung) AndAlso p.Aufenthalt.IDAbteilung <> Guid.Empty Then
                Dim b As New PMDS.db.PMDSBusiness()
                Dim rUsr As PMDS.db.Entities.Benutzer = b.LogggedOnUser()
                Dim rAbteilung As PMDS.db.Entities.Abteilung
                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    rAbteilung = b.getAbteilung(p.Aufenthalt.IDAbteilung, db)
                End Using

                '                Dim r As dsPatientInfo.AbteilungRow = dsPatientInfo1.Abteilung.Rows(0)
                '               doBookmarks.setBookmarks(r, Me.contTxtEditor1.textControl1)

                Dim gebdat As Date = p.Geburtsdatum

                doBookmarks.setBookmark("[Benutzer]", rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim(), Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("[Abteilung]", rAbteilung.Bezeichnung.Trim(), Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("[ErstelltAm]", DateTime.Now.ToString("dd.MM.yyyy"), Me.contTxtEditor1.textControl1)

                doBookmarks.setBookmark("Vorname", p.Vorname, Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("Nachname", p.Nachname, Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("Geburtsdatum", gebdat.ToString("dd.MM.yyyy"), Me.contTxtEditor1.textControl1)

                doBookmarks.setBookmark("[Vorname]", p.Vorname, Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("[Nachname]", p.Nachname, Me.contTxtEditor1.textControl1)
                doBookmarks.setBookmark("[Geburtsdatum]", gebdat.ToString("dd.MM.yyyy"), Me.contTxtEditor1.textControl1)


                'Me.contTxtEditor1.textControl1.Text = Me.contTxtEditor1.textControl1.Text.Replace("[Vorname]", p.Vorname.Trim())
                'Me.contTxtEditor1.textControl1.Text = Me.contTxtEditor1.textControl1.Text.Replace("[Nachname]", p.Nachname.Trim())
                'Me.contTxtEditor1.textControl1.Text = Me.contTxtEditor1.textControl1.Text.Replace("[Geburtsdatum]", p.Geburtsdatum.ToString("dd.MM.yyyy"))
            Else
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Für den Patienten wurden keine vollständigen Stammdaten gefunden!" + vbNewLine +
                       "Abteilung, Kontaktdaten, etc. bitte vollständig ausfüllen ..." + vbNewLine + vbNewLine +
                       "(Hinweis: Vorlage wurde nicht automatisch mit Klientendaten befüllt)", MsgBoxStyle.Exclamation, "Biografievorlage")
            End If

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
        End Try
    End Sub


    Private Sub ucBiographie_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub
    Public Sub resizeForm(ByVal w As Integer, ByVal h As Integer)
        Me.Width = w
        Me.Height = h
        contTxtEditor1.resizeControl(Me.PanelEditor2.Width, Me.PanelEditor2.Height)
    End Sub

    Private Sub btnSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeichern.Click
        Me.saveFormular()
        If Me.biografieArchivAblegen Then
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Biografie wurde ins Archiv abgelegt!", MsgBoxStyle.Information, "Ins Archiv ablegen")
        End If
    End Sub

    Private Sub btnAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbbrechen.Click

        If (Me.dbBiografien.DataTable.Rows.Count = 0 Or (Me.lblErstelltVon.Tag Is Nothing)) Then
            ui_onOff(uiState.leer)
        Else : Me.loadFormular(gen.StrToGuid(Me.dbBiografien.DataTable.Rows(0).Item("ID").ToString), True)
            'RefreshbtnPlusMinusVisibity(0, False)
        End If

    End Sub


    Public Function biografieArchivAblegen() As Boolean
        Try
            Dim comp As New compSql
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            Dim bezOrdner As String = "Biografien"
            IDOrdner = comp.GetOrdnerBiografie(bezOrdner)
            If gen.IsNull(IDOrdner) Then
                'comp.neuenOrdnerAnlegen(bezOrdner)
                'IDOrdner = comp.GetOrdnerBiografie(bezOrdner)
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Es existiert im Archiv kein Ordner 'Biografien'." + vbNewLine +
                       "Bitte erstellen, damit eine Biografie abgelegt werden kann!", MsgBoxStyle.Information, "Ins Archiv ablegen")
                Return False
            End If

            Me.contTxtEditor1.ExportPDF(System.IO.Path.Combine(PMDS.Global.ENV.path_Temp, System.Guid.NewGuid.ToString + ".pdf"), False, False)
            'Me.contTxtEditor1.ExportPDF("")
            Dim sFileToSave As String = Me.contTxtEditor1.FileHandler1.DocumentFileName

            'clTag = n.Tag
            If System.IO.File.Exists(sFileToSave) Then
                If Not gen.IsNull(sFileToSave) Then
                    Dim strOp As New clStringOperate
                    Dim filInfoProvNote As New System.IO.FileInfo(sFileToSave)
                    Dim fileInfo As New clFileInfo

                    ' Read File into byte Array
                    Dim fs As New System.IO.FileStream(sFileToSave, IO.FileMode.Open, IO.FileAccess.Read)
                    Dim r As New System.IO.BinaryReader(fs)
                    Dim fileByte(fs.Length) As Byte
                    fileByte = r.ReadBytes(fs.Length)
                    fileInfo.fileB = fileByte

                    fileInfo.file_Bezeichnung = "Biografie für '" + gen.getPatientName(PMDS.Global.ENV.CurrentIDPatient) + "' vom " + Me.lblErstelltAm.Tag.ToString

                    fileInfo.file_erstelltAm = Now
                    fileInfo.file_geändertAm = Now
                    fileInfo.file_größe = filInfoProvNote.Length
                    fileInfo.file_IDOrdner = IDOrdner
                    fileInfo.file_name = strOp.GetFileName(sFileToSave, False)
                    fileInfo.file_origVerzeichnis = strOp.GetDir(sFileToSave)
                    fileInfo.file_typ = strOp.GetFiletyp(sFileToSave)
                    Dim arrFile As New ArrayList
                    arrFile.Add(fileInfo)
                    Dim obs As New ArrayList
                    Dim clObj As New clObject()
                    clObj.id = PMDS.Global.ENV.CurrentIDPatient.ToString
                    clObj.bezeichnung = gen.getPatientName(PMDS.Global.ENV.CurrentIDPatient)
                    obs.Add(clObj)

                    'obs.Add(IDFirma.ToString)

                    Dim dataSchlagwortKat As New dsPlanArchive
                    Dim clSave As New cArchive
                    Dim ret As New cArchive.clRet
                    ret = clSave.DokumentInsArchivAblegen(arrFile, "Anhang für Planungssystem von " + Now.Date.ToString, _
                             Nothing, Nothing, "M", Nothing, obs, dataSchlagwortKat)
                    If ret.OK Then
                        Return True
                    Else
                        Throw New Exception("biografieArchivAblegen: Sichern ins Archiv fehlgeschlagen!")
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Function


    Public Sub ui_onOff(ByVal state As uiState)

        If state = uiState.formularNeuErstellen Then

            Me.PanelEditor2.Visible = True
            Me.ucVorhandeneBiografien.loadBiografien(False)
            Me.btnSpeichern.Enabled = True
            Me.btnMinus.Enabled = False
            Me.btnPlusxyxy.Enabled = False
            Me.btnPrint.Enabled = True
            Me.btnArchivAblegen.Enabled = True
            Me.btnAbbrechen.Enabled = True
            Me.lblErstelltVon.Visible = False
            Me.lblErstelltAm.Visible = False
            Me.lblErstelltVon.Tag = Nothing
            contTxtEditor1.ISTOSAVE = True
            'RefreshbtnPlusMinusVisibity(0, False)

        ElseIf state = uiState.leer Then
            Me.PanelEditor2.Visible = False
            Me.ucVorhandeneBiografien.loadBiografien(False)
            Me.btnSpeichern.Enabled = False
            Me.btnMinus.Enabled = False
            Me.btnPlusxyxy.Enabled = True
            Me.btnPrint.Enabled = False
            Me.btnArchivAblegen.Enabled = False
            Me.btnAbbrechen.Enabled = False
            Me.lblErstelltVon.Visible = False
            Me.lblErstelltAm.Visible = False
            Me.lblErstelltVon.Tag = Nothing
            Me.lblErstelltAm.Tag = Nothing
            contTxtEditor1.ISTOSAVE = False
            'RefreshbtnPlusMinusVisibity(0, False)

        ElseIf state = uiState.formularAnzeigen Then
            Me.PanelEditor2.Visible = True
            Me.ucVorhandeneBiografien.loadBiografien(False)
            Me.btnSpeichern.Enabled = False
            Me.btnMinus.Enabled = True
            Me.btnPlusxyxy.Enabled = True
            Me.btnPrint.Enabled = True
            Me.btnArchivAblegen.Enabled = True
            Me.btnAbbrechen.Enabled = False
            Me.lblErstelltVon.Visible = False
            Me.lblErstelltAm.Visible = False
            'Me.lblErstelltVon.Tag = Nothing
            'RefreshbtnPlusMinusVisibity(0, False)

            'ElseIf state = uiState.formularAnzeigen Then
            '    Me.PanelEditor2.Visible = True
            '    'Me.ucVorhandeneBiografien.loadBiografien()
            '    Me.btnSpeichern.Enabled = False
            '    Me.btnMinus.Enabled = True
            '    Me.btnPlus.Enabled = True
            '    Me.btnPrint.Enabled = True
            '    Me.btnArchivAblegen.Enabled = True
            '    Me.btnAbbrechen.Enabled = True
            '    Me.lblErstelltVon.Visible = True
            '    Me.lblErstelltAm.Visible = True

        End If

        Me.resizeForm(Me.Width, Me.Height)

    End Sub
    Public Sub EnableDisableButtons()
        Me.btnSpeichern.Enabled = True
        Me.btnAbbrechen.Enabled = True
    End Sub

    Private Sub btnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Wollen Sie die Biografie wirklich löschen?", MsgBoxStyle.YesNo, "Biografie löschen") = MsgBoxResult.Yes Then
            If Me.dbBiografien.biografieLöschen(Me.lblErstelltVon.Tag) Then
                ui_onOff(uiState.leer)
            End If
        End If

        'RefreshbtnPlusMinusVisibity(0, False)
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlusxyxy.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim sFirstFile As String = Me.onlyOneTempLoaded()
            Me.contTxtEditor1.setControlTyp()
            If sFirstFile = "" Then
                Dim frmAdd As New frmBiografieAdd
                frmAdd.modalWindow = Me
                frmAdd.ShowDialog(Me)
                If Not frmAdd.abort Then
                    ui_onOff(uiState.formularNeuErstellen)
                Else
                    ui_onOff(uiState.leer)
                End If
            Else
                Me.loadFormularvorlage(sFirstFile)
            End If

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub



    Public Function onlyOneTempLoaded() As String
        Dim strOp As New clStringOperate

        Dim sFirstTemp As String = ""
        Dim anz As Integer = 0
        For Each f As String In System.IO.Directory.GetFiles(PMDS.Global.ENV.path_BiografieVorlagen)
            If LCase(strOp.GetFiletyp(f)) = ".rtf" Then
                anz += 1
                If anz = 1 Then sFirstTemp = f
            End If
        Next

        If anz = 1 Then
            Return sFirstTemp
        Else
            Return ""
        End If

    End Function
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            'Me.contTxtEditor1.ExportPDF(General.path_Temp + "\" + System.Guid.NewGuid.ToString + ".pdf")
            Me.contTxtEditor1.ExportPDF("", True, False)

        Catch ex As Exception
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB(ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnArchivAblegen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivAblegen.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        If QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Wollen Sie die Biografie wirklich ins Archiv ablegen?", MsgBoxStyle.YesNo, "Ins Archiv ablegen") = MsgBoxResult.Yes Then
            If Me.biografieArchivAblegen Then
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Biografie wurde ins Archiv abgelegt!", MsgBoxStyle.Information, "Ins Archiv ablegen")
            End If
        End If

        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Public Sub setControlsAktivDisable(ByVal bOn As Boolean)

        panelUntenRechts.Visible = Not bOn
        PanelButtonOben2.Visible = Not bOn

    End Sub


End Class
