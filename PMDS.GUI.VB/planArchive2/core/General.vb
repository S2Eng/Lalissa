Imports System.IO



Public Class General

    Public Shared EmptyGuid As System.Guid = Nothing
    Public Shared UrlOutlookWebAPI As String = ""                   'lthNotOKEMailSystemAK
    Public Shared AllgPostboxEinsehbar As Boolean = True
    Public Shared sLanguage As String = "DE"
    Public Shared errorNoRessourceFound As Boolean = True
    Public Shared autoUI As Boolean = True

    Public Shared lstToolbars As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinToolbars.UltraToolbarsManager)
    Public Shared TouchToolBarManager As Infragistics.Win.DefaultableBoolean = Infragistics.Win.DefaultableBoolean.False

    Public Shared InitHTMLEditorEveryClick As Boolean = False

    Public Shared maxSizeEMailKB As Integer = 300000000
    Public Shared abort As Boolean = False

    Public Shared ImportTasks As Boolean = True
    Public Shared ServicesTestmodus As Boolean = True
    Public Shared SyncContacts As Boolean = True


    Public Shared iAccountsSucessfullScanned As Integer = 0
    Public Shared iCounterExceptionsToSend As Integer = 0
    Public Shared ExceptionsToSend As String = ""
    Public Shared AutoScannServiceOnOff As Boolean = False

    Public Shared FullUserAuthenticationForOutlookWebAPILogIn As Boolean = False

    Public Shared checkEMailsBodyForContracts As Boolean = True
    Public Shared ActivateExchangeServicesOnClient As Boolean = False
    Public Shared InfoMailService As New clPlan.cInfoMailService()

    Public Shared bSendOnServer As Boolean = True
    Public Shared CheckMemorySizeProcess As Boolean = False
    Public Shared maxSizeMemory As Integer = 6000   'in mb

    Public Shared color_standardBlue As New System.Drawing.Color
    Public Shared color_standardOrange As New System.Drawing.Color


    Public Enum eRessoourcenTypeSub
        User = 0
        None = 100
    End Enum

    Public Enum eControlType
        Textfield = 0
        TextfieldMulti = 1
        Numeric = 2
        [Integer] = 17
        ComboBox = 3
        DateTime = 4
        [Date] = 5
        Time = 6
        CheckBox = 7
        ThreeStateCheckBox = 8
        Label = 9
    End Enum
    Public Enum eApplications
        PMDS = 0
    End Enum
    Public Enum eParticipant
        All = 0
    End Enum

    Public Enum InitApplicationAufgabenTermine

        Posteingang = 600
        Postausgang = 601
        PosteingangPostausgang = 602

        nachrichtAnzeigen = 640
        terminNeu = 661
        mailNeu = 703

    End Enum

    Public Class cInfoPlan
        Public ID As System.Guid = Nothing
        Public Body As String = ""
        Public IsHtml As Boolean = False
        Public Betreff As String = ""
        Public MailAdressTo As String = ""
        Public MailFrom As String = ""
        Public MailSentAt As String = ""
        Public Txt As String = ""
    End Class
    Public Class exchPlan

        Public app As Integer = 0
        Public str As String = ""
        Public typMail As New General.eTypMail

    End Class

    Public Class clTagOrdner

        Public ID As New System.Guid
        Public IDSyOrdner As Integer = 0
        Public typ As New eTyp
        Public fileInfo As New clFileInfo


        Public Enum eTyp
            typOrdner = 2
            typDateiAblegen = 3
            typDateiSuchen = 4
            keiner = 100
        End Enum
        Sub New()
            Me.ID = Nothing
            Me.typ = eTyp.keiner
        End Sub

    End Class

    Public Enum eTypMail
        an = 0
        cc = 1
        bcc = 2
    End Enum

    Public doBookmarksEditor1 As New QS2.Desktop.Txteditor.doBookmarks()

    Public Enum eAuswahlStatusMail
        gesendet = 0
        entwürfe = 1
        alle = 2
    End Enum
    Public Enum eKeyCol
        Guid = 0
        IDNr = 1
        IDStr = 2
        Description = 3
    End Enum
    Public Enum eStatusForm
        neu = 1
        edit = 5
    End Enum
    Public Enum etyp
        all = 0
        onlyShow = 1
        minimalForEdit = 2
        biografie = 3
        calc = 4
    End Enum
    Public Class cObjectsRow
        Public txt As String = ""
        Public lstObjects As New System.Collections.Generic.List(Of Guid)
    End Class

    Public Class cSerientermine
        Public dFrom As Date = Nothing
        Public dTo As Nullable(Of Date) = Nothing
        Public IsGanzerTag As Boolean = False
    End Class

    Public Shared MainCallFcts As dMainCallFcts
    Public Delegate Sub dMainCallFcts(ByVal FctCallMainFctPlan As PMDS.Global.ENV.eFctCallMainFctPlan, ByVal cCallMainFctPlan As PMDS.Global.ENV.eCallMainFctPlan)











    Public Sub callMainFctPMDS(ByVal FctCallMainFctPlan As PMDS.Global.ENV.eFctCallMainFctPlan, ByVal cCallMainFctPlan As PMDS.Global.ENV.eCallMainFctPlan)
        Try
            General.MainCallFcts.Invoke(FctCallMainFctPlan, cCallMainFctPlan)

        Catch ex As Exception
            Throw New Exception("General.callMainFctPMDS: " + ex.ToString())
        End Try
    End Sub

    Public Function calcDateStartEnd(dFrom As Nullable(Of Date), dTo As Nullable(Of Date), GanzerTag As Boolean,
                                        IsSerientermin As Boolean,
                                        SerienterminType As String,
                                        iWiedWertJeden As Nullable(Of Integer), TagWochenMonat As String,
                                        NTenMonat As Nullable(Of Integer), Wochentage As String,
                                        ByRef lstDatesResult As System.Collections.Generic.List(Of cSerientermine),
                                        SerienterminEndetAm As Nullable(Of Date), ByRef IDSerientermin As Guid) As Boolean
        Try
            Dim iSerientermintype As Integer = System.Convert.ToInt32(SerienterminType.Trim())

            If iSerientermintype = 1 Then               'Täglich                    (Wochentage)
                Dim dFromTmp As Date = dFrom
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, GanzerTag)

                    If (Wochentage.Trim().Contains(("Mo;").Trim()) And dFromTmp.DayOfWeek = DayOfWeek.Monday) Or
                        (Wochentage.Trim().Contains(("Di;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Tuesday) Or
                        (Wochentage.Trim().Contains(("Mi;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Wednesday) Or
                        (Wochentage.Trim().Contains(("Do;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Thursday) Or
                        (Wochentage.Trim().Contains(("Fr;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Friday) Or
                        (Wochentage.Trim().Contains(("Sa;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Saturday) Or
                        (Wochentage.Trim().Contains(("So;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Sunday) Then

                        Dim newSerientermine As New cSerientermine()
                        newSerientermine.dFrom = actDateStartTmp
                        newSerientermine.dTo = actDateEndTmp
                        newSerientermine.IsGanzerTag = GanzerTag
                        lstDatesResult.Add(newSerientermine)
                    End If

                    dFromTmp = dFromTmp.AddDays(1)
                End While

            ElseIf iSerientermintype = 2 Then           'Alle Tage/Woche/Monat      (WiedWertJeden - Tage Wochen Monat >> Wochen=Wochentage)
                Dim iWeeksOver As Integer = 1
                Dim iTageAddedWeek As Integer = 1           ' (iWiedWertJeden - 1) * 7
                Dim iLastWeekDone As Integer = -1
                Dim bWeekOK As Boolean = False
                Dim dFromTmp As Date = dFrom
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, GanzerTag)

                    Dim bSerienterminOK As Boolean = True
                    If TagWochenMonat = 1 Then          'Tage
                        bSerienterminOK = False
                        If iWeeksOver = 1 Then
                            bWeekOK = True
                            iLastWeekDone = 1
                        Else
                            If iWeeksOver = (iWiedWertJeden.Value) + iLastWeekDone Then
                                bWeekOK = True
                                iLastWeekDone = iWeeksOver
                            End If
                        End If
                        If bWeekOK Then
                            If (Wochentage.Trim().Contains(("Mo;").Trim()) And dFromTmp.DayOfWeek = DayOfWeek.Monday) Or
                                (Wochentage.Trim().Contains(("Di;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Tuesday) Or
                                (Wochentage.Trim().Contains(("Mi;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Wednesday) Or
                                (Wochentage.Trim().Contains(("Do;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Thursday) Or
                                (Wochentage.Trim().Contains(("Fr;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Friday) Or
                                (Wochentage.Trim().Contains(("Sa;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Saturday) Or
                                (Wochentage.Trim().Contains(("So;").Trim()) And actDateStartTmp.DayOfWeek = DayOfWeek.Sunday) Then      'Tag OK?)

                                bSerienterminOK = True
                            End If
                        End If
                    End If
                    If bSerienterminOK Then
                        Dim newSerientermine As New cSerientermine()
                        newSerientermine.dFrom = actDateStartTmp
                        newSerientermine.dTo = actDateEndTmp
                        newSerientermine.IsGanzerTag = GanzerTag
                        lstDatesResult.Add(newSerientermine)
                    End If

                    If TagWochenMonat = 0 Then          'Tage
                        dFromTmp = dFromTmp.AddDays(iWiedWertJeden.Value)
                    ElseIf TagWochenMonat = 1 Then      'Wochen
                        dFromTmp = dFromTmp.AddDays(1)
                        iTageAddedWeek += 1
                        If iTageAddedWeek > 7 Then
                            iTageAddedWeek = 1
                            iWeeksOver += 1
                            bWeekOK = False
                        End If
                    ElseIf TagWochenMonat = 2 Then      'Monat
                        dFromTmp = dFromTmp.AddMonths(iWiedWertJeden.Value)
                    Else
                        Throw New Exception("calcDateStartEnd: TagWochenMonat '" + TagWochenMonat.ToString() + "' not allowed!")
                    End If
                End While

            ElseIf iSerientermintype = 3 Then           'Jeden n-ten Monat          (iNTenMonat) 
                Dim dFromTmp As Date = dFrom
                Dim iLastMonth As Integer = -1
                While (dFromTmp.Date <= SerienterminEndetAm.Value.Date)
                    Dim actDateStartTmp As Date = New Date(dFromTmp.Year, dFromTmp.Month, dFromTmp.Day, dFrom.Value.Hour, dFrom.Value.Minute, dFrom.Value.Second)
                    Dim actDateEndTmp = Me.getEndDayForTermin(actDateStartTmp, dFrom.Value, dTo, GanzerTag)

                    If actDateStartTmp.Day = NTenMonat.Value Then
                        Dim newSerientermine As New cSerientermine()
                        newSerientermine.dFrom = actDateStartTmp
                        newSerientermine.dTo = actDateEndTmp
                        newSerientermine.IsGanzerTag = GanzerTag
                        lstDatesResult.Add(newSerientermine)
                    End If

                    dFromTmp = dFromTmp.AddDays(1)
                End While
            End If

        Catch ex As Exception
            Throw New Exception("General.calcDateStartEnd: " + ex.ToString())
        End Try
    End Function
    Public Function getEndDayForTermin(actDay As Date, dFromOrig As Date, dToOrig As Nullable(Of Date), GanzerTag As Boolean) As Date
        Try
            If GanzerTag Then
                Dim EndTmp As Date = New Date(actDay.Date.Year, actDay.Date.Month, actDay.Day, 23, 59, 59)
                Return EndTmp
            Else
                Dim EndTmp As Date = New Date(actDay.Date.Year, actDay.Date.Month, actDay.Day, dToOrig.Value.Hour, dToOrig.Value.Minute, dToOrig.Value.Second)
                If dToOrig.Value.Date > dFromOrig.Date Then
                    Dim iDaysDiff As Integer = DateDiff(DateInterval.Day, dFromOrig.Date, dToOrig.Value.Date)
                    EndTmp = EndTmp.AddDays(iDaysDiff)
                End If
                Return EndTmp
            End If

        Catch ex As Exception
            Throw New Exception("General.getEndDayForTermin: " + ex.ToString())
        End Try
    End Function


    Public Function getInfo(ByVal IDDoku As System.Guid) As String
        Try
            Dim textTyp As String = ""
            Dim compDoku1 As New compDoku()
            Dim db As New dbArchiv()
            Dim b As New PMDS.db.PMDSBusiness()
            compDoku1.getObject(IDDoku, compDoku.eTypSelObj.idDoku, db)
            Using db2 As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rObj As dbArchiv.archObjectRow In db.archObject
                    If b.checkPatientExists(rObj.IDObject, db2) Then
                        Dim rPatient As PMDS.db.Entities.Patient = b.getPatient2(rObj.IDObject, db2)
                        textTyp += "    " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim()
                    Else
                        textTyp += "    " + "Patient not exists in db"
                    End If
                Next
            End Using

            If Not Me.IsNull(textTyp) Then
                textTyp = doUI.getRes("Relationships") + ":" + vbNewLine + textTyp
            End If
            Return textTyp

        Catch ex As Exception
            Throw New Exception("General.getInfo: " + ex.ToString())
        End Try
    End Function

    Public Sub openDocus(ByRef dbArchivToOpen As dbArchiv, ByVal title As String, ByVal editorToWork As TXTextControl.TextControl)
        Try
            Dim frmTxtEditor1 As QS2.Desktop.Txteditor.frmTxtEditor = General.openTxtEditor(False)
            frmTxtEditor1.Text = doUI.getRes("TextWillBeLoaded") + " ..."
            frmTxtEditor1.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView

            Dim doEditor1 As New QS2.Desktop.Txteditor.doEditor()
            Dim binExport() As Byte = Nothing
            Dim anz As Integer = 1
            For Each rDocu As dbArchiv.archDokuRow In dbArchivToOpen.archDoku
                'If rDocu.DateinameTyp.Trim().ToLower() = (".pdf").ToLower() Then
                '    Me.doEditor.showText("", TXTextControl.StreamType.AdobePDF, False, TXTextControl.ViewMode.PageView, editorToWork, Nothing, rDocu.doku)
                'ElseIf rDocu.DateinameTyp.Trim().ToLower() = (".rtf").ToLower() Then
                '    Dim strDocu As String = Me.gen.ByteToString(rDocu.doku)
                '    Me.doEditor.showText(strDocu, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, editorToWork)
                'ElseIf rDocu.DateinameTyp.Trim().ToLower() = (".html").ToLower() Then
                '    Dim strDocu As String = Me.gen.ByteToString(rDocu.doku)
                '    Me.doEditor.showText(strDocu, TXTextControl.StreamType.HTMLFormat, False, TXTextControl.ViewMode.PageView, editorToWork)
                'End If

                If anz > 1 Then
                    'Me.doEditor.insertPagebreak(frmTxtEditor1.ContTxtEditor1.textControl1)
                End If

                'Me.doEditor.appendText(Me.doEditor.getTextInByte(TXTextControl.BinaryStreamType.InternalFormat, editorToWork), frmTxtEditor1.ContTxtEditor1.textControl1)
                doEditor1.appendText(rDocu.binIntern, frmTxtEditor1.ContTxtEditor1.textControl1)
                anz += 1
            Next

            Me.doAutoSiteNummbering(frmTxtEditor1.ContTxtEditor1.textControl1)
            frmTxtEditor1.Text = title

        Catch exept As Exception
            Throw New Exception("General.openDocus: " + exept.ToString())
        End Try
    End Sub

    Public Shared Function openTxtEditor(WithVariables As Boolean) As QS2.Desktop.Txteditor.frmTxtEditor
        Try
            Dim frmTxtEditor As New QS2.Desktop.Txteditor.frmTxtEditor()
            frmTxtEditor = New QS2.Desktop.Txteditor.frmTxtEditor()

            If WithVariables Then
                frmTxtEditor.fFelderEinAus2 = False
            End If

            frmTxtEditor.ContTxtEditor1.doNew(True)
            frmTxtEditor.ContTxtEditor1.loadForm(False, New DataSet, True)
            frmTxtEditor.ContTxtEditor1.setNewControlTyp(etyp.all)
            frmTxtEditor.ContTxtEditor1.FileNew(False, False)
            frmTxtEditor.ContTxtEditor1.clearForm()
            frmTxtEditor.Show()
            frmTxtEditor.BringToFront()
            Return frmTxtEditor

        Catch ex As Exception
            Throw New Exception("General.cTxtEditor: " + ex.ToString())
        End Try
    End Function
    Public Function checkSonderSigns(ByVal txt As String) As String
        Try
            txt = txt.Replace(":", "-")
            txt = txt.Replace(",", "-")
            txt = txt.Replace("?", " ")
            txt = txt.Replace(":", "")
            txt = txt.Replace(":", "")
            txt = txt.Replace(":", "")
            txt = txt.Replace(":", "")
            txt = txt.Replace(":", "")
            Return txt

        Catch ex As Exception   
            Throw New Exception("General.checkSonderSigns: " + ex.ToString())
        End Try
    End Function
    Public Function checkComboBox(ByRef cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal auswahlPflicht As Boolean,
                                  Optional ByVal setFocus As Boolean = True) As Boolean
        Try
            'If cmb.Focused Then
            Dim gen As New General()
            Dim bFound As Boolean = False
            If auswahlPflicht Then
                If gen.IsNull(cmb.Value) Then

                    Dim sTitle As String = doUI.getRes("Selection")
                    Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                         doUI.getRes("PleaseDoARightSelection") + "!"
                    doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                    If setFocus Then cmb.Focus()
                    Return False
                End If
            Else
                If gen.IsNull(cmb.Value) Then
                    Return True
                End If
            End If

            For Each itm As Infragistics.Win.ValueListItem In cmb.Items
                If cmb.Value.ToString = itm.DataValue.ToString Then
                    cmb.SelectedItem = itm
                    Return True
                End If
            Next
            If Not bFound Then

                Dim sTitle As String = doUI.getRes("Selection")
                Dim sTxt As String = doUI.getRes("EntryDoesNotExist") + "!" + vbNewLine +
                                     doUI.getRes("PleaseDoARightSelection") + "!"
                doUI.doMessageBoxTranslated(sTxt, sTitle, MsgBoxStyle.Information)

                If setFocus Then cmb.Focus()
                Return False
            End If
            Return False

        Catch ex As Exception
            Throw New Exception("General.checkComboBox: " + ex.ToString())
        End Try
    End Function
    Public Function loadSignatureAsRtf(ByRef SignatureRtf As String) As Boolean
        Try
            Return True

            'Dim editorSrv As New TXTextControl.ServerTextControl               'lthNotOKEMailSystemAK
            'editorSrv.Create()

            'Dim actUsr1 As New actUsr()
            'Dim SignByte As Byte() = actUsr1.adjustRead(core.SystemDb.compAdjust.eAdjust.mySignature, core.SystemDb.compAdjust.eTypSelAdjust.forUsr)
            'If Not SignByte Is Nothing Then
            '    'Dim signStr As String = Me.ByteToString(SignByte)
            '    Dim doEditor1 As New ITSCont.core.SystemDb.doEditor()
            '    doEditor1.showTextSrvxy("", TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editorSrv, SignByte)
            '    SignatureRtf = doEditor1.getTextSrvxy(TXTextControl.StringStreamType.RichTextFormat, editorSrv)
            '    editorSrv.Dispose()
            '    editorSrv = Nothing

            '    Return True
            'End If

        Catch ex As Exception
            Throw New Exception("General.loadSignature: " + ex.ToString())
        End Try
    End Function
    Public Function loadSignatureAsHTMLxy() As String
        Try
            Return ""

            'Dim editorSrv As New TXTextControl.ServerTextControl           'lthNotOKEMailSystemAK
            'editorSrv.Create()

            'Dim actUsr1 As New actUsr()
            'Dim SignByte As Byte() = actUsr1.adjustRead(core.SystemDb.compAdjust.eAdjust.mySignature, core.SystemDb.compAdjust.eTypSelAdjust.forUsr)
            'If Not SignByte Is Nothing Then
            '    'Dim signStr As String = Me.ByteToString(SignByte)
            '    Dim doEditor1 As New ITSCont.core.SystemDb.doEditor()
            '    doEditor1.showTextSrvxy("", TXTextControl.StreamType.RichTextFormat, True, TXTextControl.ViewMode.PageView, editorSrv, SignByte)
            '    Dim html As String = doEditor1.getTextSrvxy(TXTextControl.StringStreamType.HTMLFormat, editorSrv)
            '    editorSrv.Dispose()
            '    editorSrv = Nothing
            '    Return html
            'End If

            'editorSrv.Dispose()
            'editorSrv = Nothing

        Catch ex As Exception
            Throw New Exception("General.loadSignature: " + ex.ToString())
        End Try
    End Function

    Public Function StrToGuid(ByVal ID_str As String) As System.Guid
        Try
            If Not Me.IsNull(ID_str) Then
                Try
                    Dim ID As New System.Guid(ID_str)
                    Return ID
                Catch ex As Exception
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("General.StrToGuid: " + ex.ToString())
        End Try
    End Function
    Public Function GuidToStr(ByVal ID As System.Guid) As String
        Try
            Return ID.ToString

        Catch ex As Exception
            Throw New Exception("General.GuidToStr: " + ex.ToString())
            Return Nothing
        End Try
    End Function

    Public Function OpenSelList(ByRef IDGroupStr As String) As Boolean
        Try
            Dim frmSelListsManage As New QS2.sitemap.vb.frmSelLists()
            frmSelListsManage.ContSelList1.doAutoRessource = True
            frmSelListsManage.ContSelList1.defaultApplication = "PMDS"
            frmSelListsManage.ContSelList1.TypeStr = QS2.core.Enums.eTypeQuery.User.ToString()
            frmSelListsManage.ContSelList1.Username = QS2.core.vb.actUsr.rUsr.UserName
            frmSelListsManage.ContSelList1.IDParticipant = "ALL"
            frmSelListsManage.ContSelList1.IDGruppeStr = IDGroupStr
            frmSelListsManage.TypeStr = QS2.core.Enums.eTypeQuery.User.ToString()
            frmSelListsManage.typeUI = QS2.sitemap.vb.frmSelLists.eTypeUI.manageQueryGroups
            frmSelListsManage._Private = False
            frmSelListsManage.ShowDialog()
            If frmSelListsManage.ContSelList1.savedClicked Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("General.OpenSelList: " + ex.ToString())
        End Try
    End Function
    Public Shared Function searchEnumTypEMailAccount(ByVal keyToSearch As String, ByVal typEnum As Type) As compUserAccounts.eTypEMailAccount
        Try
            For Each val As Integer In [Enum].GetValues(typEnum)
                Dim str As String = [Enum].GetName(typEnum, val)
                If keyToSearch = str Then
                    Return val
                End If
            Next
            Throw New Exception("General.searchEnumTypEMailAccount: Key '" + keyToSearch + "' not found!")

        Catch ex As Exception
            Throw New Exception("General.searchEnumTypEMailAccount: " + ex.ToString())
        End Try
    End Function

    Public Sub loadDSSelListHelper(ByRef tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries),
                                   ByRef dsAuswahllistenToFill As dsAuswahllisten)
        Try
            For Each rSelListExists As PMDS.db.Entities.tblSelListEntries In tSelListEntriesReturn
                Dim rNew As dsAuswahllisten.SelListHelperRow = Me.getNewRowSelListHelper(dsAuswahllistenToFill)
                rNew.ID = rSelListExists.ID
                rNew.IDGuid = rSelListExists.IDGuid
                rNew.IDOwnStr = rSelListExists.IDOwnStr.Trim()
                If Not rSelListExists Is Nothing Then
                    rNew.IDOwnInt = rSelListExists.IDOwnInt.Value
                Else
                    rNew.IDOwnInt = -999
                End If
                rNew.Description = rSelListExists.Description.Trim()
                rNew.IDRessource = rSelListExists.IDRessource.Trim()
            Next

        Catch ex As Exception
            Throw New Exception("General.loadDSSelListHelper: " + ex.ToString())
        End Try
    End Sub
    Public Function getNewRowSelListHelper(ByRef ds As dsAuswahllisten) As dsAuswahllisten.SelListHelperRow
        Try
            Dim rNew As dsAuswahllisten.SelListHelperRow = ds.SelListHelper.NewRow()
            rNew.ID = -9999
            rNew.IDGuid = System.Guid.NewGuid()
            rNew.IDOwnStr = ""
            rNew.SetIDOwnIntNull()
            rNew.Description = ""
            rNew.IDRessource = ""

            ds.SelListHelper.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("General.getNewRowSelListHelper: " + ex.ToString())
        End Try
    End Function

    Public Function loadSelList(ByVal lst As Infragistics.Win.ValueList,
                                        ByVal cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor,
                                        ByVal gruppe As String, ByRef tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries),
                                        ByVal typKey As General.eKeyCol, ByRef MaxIDSelListEntryReturn As Integer) As Boolean
        Try
            If Not lst Is Nothing Then
                lst.ValueListItems.Clear()
            End If
            If Not cbo Is Nothing Then
                cbo.Items.Clear()
            End If

            MaxIDSelListEntryReturn = -1
            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim tSelListEntries As System.Linq.IQueryable(Of PMDS.db.Entities.tblSelListEntries) = b.getSelListEntries2(gruppe.Trim(), db)
                For Each rSelList As PMDS.db.Entities.tblSelListEntries In tSelListEntries
                    If MaxIDSelListEntryReturn < rSelList.ID Then
                        MaxIDSelListEntryReturn = rSelList.ID
                    End If

                    Dim SelListTxt As String = rSelList.IDRessource.Trim()
                    Dim sSelListTranslated As String = QS2.core.language.sqlLanguage.getRes(rSelList.IDRessource.Trim())
                    If sSelListTranslated.Trim() <> "" Then
                        SelListTxt = sSelListTranslated.Trim()
                    End If
                    rSelList.Description = SelListTxt.Trim()

                    If Not cbo Is Nothing Then
                        Select Case typKey
                            Case General.eKeyCol.Guid
                                cbo.Items.Add(rSelList.IDGuid, SelListTxt.Trim())
                            Case General.eKeyCol.IDNr
                                cbo.Items.Add(rSelList.IDOwnInt.Value, SelListTxt.Trim())
                            Case General.eKeyCol.IDStr
                                cbo.Items.Add(rSelList.IDOwnStr.Trim(), SelListTxt.Trim())
                            Case General.eKeyCol.Description
                                cbo.Items.Add(SelListTxt.Trim(), SelListTxt.Trim())
                        End Select
                    End If
                    If Not lst Is Nothing Then
                        Select Case typKey
                            Case General.eKeyCol.Guid
                                lst.ValueListItems.Add(rSelList.IDGuid, SelListTxt.Trim())
                            Case General.eKeyCol.IDNr
                                lst.ValueListItems.Add(rSelList.IDOwnInt.Value, SelListTxt.Trim())
                            Case General.eKeyCol.IDStr
                                lst.ValueListItems.Add(rSelList.IDOwnStr.Trim(), SelListTxt.Trim())
                            Case General.eKeyCol.Description
                                lst.ValueListItems.Add(SelListTxt.Trim(), SelListTxt.Trim())
                        End Select
                    End If
                Next

                tSelListEntriesReturn = tSelListEntries.ToList()
                Return True
            End Using

        Catch ex As Exception
            Throw New Exception("General.loadSelList: " + ex.ToString())
        End Try
    End Function

    Public Sub doAutoSiteNummbering(ByRef editor As TXTextControl.TextControl)
        Try
            Me.doBookmarksEditor1.setPageOf(editor, TXTextControl.HeaderFooterType.Footer, TXTextControl.HorizontalAlignment.Right, 7.5)

        Catch exept As Exception
            Throw New Exception("General.doAutoSiteNummbering: " + exept.ToString())
        End Try
    End Sub

    Public Function newMessage(ByVal Dat As Date, ByVal Time As Date,
                                modalWindow As contPlanung2,
                                IDActivity As System.Guid,
                                asModalDialog As Boolean,
                                generatePlanForEachObj As Boolean,
                                bezeichnung As String,
                                dateiTyp As String,
                                byteStreamAnhang() As Byte,
                                loadAllActivities As Boolean,
                                newInstanzWindow As Boolean,
                                TypeUI As contPlanungData.eTypeUI, PlanArchive As contPlanungData.cPlanArchive,
                                Optional eMail As Boolean = False,
                                Optional IDArt As Integer = -1,
                                Optional betreff As String = "",
                                Optional body As String = "",
                                Optional bodyIsHtml As Boolean = False,
                                Optional Mailadresse As String = "") As frmNachricht3
        Try
            Dim frm As frmNachricht3 = Nothing
            If newInstanzWindow Then
                frm = New frmNachricht3()
                frm.InSharedMemory = False
            Else
                frm = HandleMessage.getMessage()
            End If
            frm.modalWindow = modalWindow

            Dim exch As New exchPlan
            exch.app = General.InitApplicationAufgabenTermine.terminNeu

            frm.modalWindow = modalWindow
            frm.IDActivityForNewPlan = IDActivity
            frm.generatePlanForEachObj = generatePlanForEachObj
            frm.loadForm()
            frm.Init(exch, clPlan.typPlan_AufgabeTermin, TypeUI, PlanArchive)
            frm.dteBeginntAm.DateTime = New Date(Dat.Year, Dat.Month, Dat.Day, Time.Hour, Time.Minute, 0)
            If Not byteStreamAnhang Is Nothing Then
                frm.contListeAnhang.addAnhangAusArchiv(byteStreamAnhang, bezeichnung, dateiTyp, frm.rPlan.ID)
            End If

            'If asModalDialog Then
            If Not newInstanzWindow Then
                'System.Windows.Forms.Application.DoEvents()
                'frm.Visible = True
                'System.Windows.Forms.Application.DoEvents()
                'frm.doVisible()
                'frm.Visible = False
                'System.Windows.Forms.Application.DoEvents()

                If asModalDialog Then
                    frm.Show()
                    'Me.setParMessageForModalDialog(frm, asModalDialog, eMail, IDArt, betreff, body, bodyIsHtml, Mailadresse)
                    'frm.ShowDialog()
                Else
                    frm.Show()
                End If
            Else
                If asModalDialog Then
                    frm.Show()
                    'Me.setParMessageForModalDialog(frm, asModalDialog, eMail, IDArt, betreff, body, bodyIsHtml, Mailadresse)
                    'frm.ShowDialog()
                Else
                    frm.Show()
                End If
            End If

            Return frm

        Catch ex As Exception
            Throw New Exception("General.newMessage: " + ex.ToString())
        Finally
        End Try
    End Function

    Public Sub openPlans(ByRef lstPlansSelected As System.Collections.Generic.List(Of cInfoPlan), ByVal title As String, ByVal editorToWork As TXTextControl.TextControl)
            Try
                Dim gen As New General()
                Dim frmTxtEditor1 As QS2.Desktop.Txteditor.frmTxtEditor = General.openTxtEditor(False)
                frmTxtEditor1.Text = doUI.getRes("TextWillBeLoaded") + " ..."
                frmTxtEditor1.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView

                Dim binExport() As Byte = Nothing
                Dim anz As Integer = 1
                For Each InfoPlan As cInfoPlan In lstPlansSelected
                    frmTxtEditor1.ContTxtEditor1.textControl1.Append(InfoPlan.MailAdressTo.Trim() + ", " + InfoPlan.MailSentAt.ToString() + vbNewLine + vbNewLine, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewSection)
                    frmTxtEditor1.ContTxtEditor1.textControl1.Append(InfoPlan.Betreff.Trim() + vbNewLine + vbNewLine, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.None)
                    If InfoPlan.IsHtml Then
                        frmTxtEditor1.ContTxtEditor1.textControl1.Append(InfoPlan.Body.Trim(), TXTextControl.StringStreamType.HTMLFormat, TXTextControl.AppendSettings.None)
                    Else
                        frmTxtEditor1.ContTxtEditor1.textControl1.Append(InfoPlan.Body.Trim(), TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.None)
                    End If
                    anz += 1
                Next

                Me.doAutoSiteNummbering(frmTxtEditor1.ContTxtEditor1.textControl1)
                If title.Trim() <> "" Then
                    frmTxtEditor1.Text = title
                End If

            Catch exept As Exception
                Throw New Exception("General.openPlans: " + exept.ToString())
            End Try
        End Sub
        Public Function addInteropSendEMail(ByRef dsInteropPar1 As dsInteropPar) As Boolean
            Try
                Dim compInterop1 As New compInterop()
                Dim dsInterop1 As New dsInterop()
                compInterop1.getInterop(dsInterop1, System.Guid.NewGuid(), -1, compInterop.eSelInterop.allPast, compInterop.eMachine.client, 0, "", "", "", Nothing, "", False)
                Dim rNewInterop As dsInterop.tblInteropRow = compInterop1.newRowInterop(dsInterop1.tblInterop, compInterop.eTypActionInterop.sendEMails, True, dsInteropPar1, True)
                compInterop1.daInterop.Update(dsInterop1.tblInterop)
                Return True

            Catch ex As Exception
                Throw New Exception("General.addInteropSendEMail: " + ex.ToString())
            End Try
        End Function
        Public Function addInteropPar(ByVal IDPlan As System.Guid, ByVal IDPlanParent As System.Guid, ByRef dsInteropPar1 As dsInteropPar) As Boolean
            Try
                Dim rInterPar As dsInteropPar.InteropParRow = dsInteropPar1.InteropPar.NewRow()
                rInterPar.IDGuid = IDPlan
                Dim gen As New General()
                If Not gen.IsNull(IDPlanParent) Then
                    rInterPar.IDGuidParent = IDPlanParent
                End If
                rInterPar.IDStr = ""
                dsInteropPar1.InteropPar.Rows.Add(rInterPar)
                Return True

            Catch ex As Exception
                Throw New Exception("General.addInteropPar: " + ex.ToString())
            End Try
        End Function

        Public Shared Function ReplaceMetaContentInHTML(ByRef sHtmlOrig As String) As String
            Try
                If sHtmlOrig.Trim().ToLower().Contains(("TX151HTM 15.1.303.503").Trim().ToLower()) Then
                    sHtmlOrig = sHtmlOrig.Replace(("TX151HTM 15.1.303.503").Trim(), "<meta content=" + Chr(34) + "text/html; charset=utf-8" + Chr(34) + "")
                End If
                If sHtmlOrig.Trim().ToLower().Contains(("TX151HTM 20.0.500.500").Trim().ToLower()) Then
                    sHtmlOrig = sHtmlOrig.Replace(("TX151HTM 20.0.500.500").Trim(), "<meta content=" + Chr(34) + "text/html; charset=utf-8" + Chr(34) + "")
                End If

                Return sHtmlOrig

            Catch ex As Exception
                Throw New Exception("General.ReplaceMetaContentInHTML: " + ex.ToString())
            End Try
        End Function

        Public Sub waitTime(ByVal nTimeMS As Integer)
            System.Threading.Thread.Sleep(nTimeMS)
            'System.Threading.Thread.CurrentThread.Sleep(nTimeMS)
        End Sub
        Public Function readByteStreamFile(ByVal file As String) As Byte()
            Try

                ' Read File into byte Array
                Dim fs As New System.IO.FileStream(file, FileMode.Open, FileAccess.Read)
                Dim r As New BinaryReader(fs)
                Dim fileByte(fs.Length) As Byte
                fileByte = r.ReadBytes(fs.Length)
                fs.Close()
                r.Close()
                Return fileByte

            Catch ex As Exception
                Throw New Exception("General.readByteStreamFile: " + ex.ToString())
            End Try
        End Function

        Public Function getLoggedInUser() As String
            Try
                Dim UserLoggedIn As String = ""
                Dim b As New PMDS.db.PMDSBusiness()
                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim rUsr As PMDS.db.Entities.Benutzer = b.LogggedOnUser(db)
                    UserLoggedIn = rUsr.Benutzer1.Trim()
                End Using

                Return UserLoggedIn.Trim()

            Catch ex As Exception
                Throw New Exception("General.getLoggedInUser: " + ex.ToString())
            End Try
        End Function

    Public Function getAllSachb(ByVal cbo As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal valList As Infragistics.Win.ValueList,
                                Optional ByVal tagAlsIDObject As Boolean = False,
                                Optional NurStrukturUnterhalb As Boolean = False) As IQueryable(Of PMDS.db.Entities.Benutzer)
        Try
            If Not cbo Is Nothing Then
                cbo.Items.Clear()
            End If
            If Not valList Is Nothing Then
                valList.ValueListItems.Clear()
            End If

            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim lstBenutzerReturn As New System.Collections.Generic.List(Of Guid)
                Dim tBenutzer As IQueryable(Of PMDS.db.Entities.Benutzer) = b.getAllUsers(db, lstBenutzerReturn)
                For Each rUsr As PMDS.db.Entities.Benutzer In tBenutzer
                    If Not cbo Is Nothing Then
                        If Not tagAlsIDObject Then
                            cbo.Items.Add(rUsr.Benutzer1.Trim(), rUsr.Benutzer1.Trim())
                        Else
                            cbo.Items.Add(rUsr.ID, rUsr.Benutzer1.Trim())
                        End If
                    End If
                    If Not valList Is Nothing Then
                        If Not tagAlsIDObject Then
                            valList.ValueListItems.Add(rUsr.Benutzer1.Trim(), rUsr.Benutzer1.Trim())
                        Else
                            valList.ValueListItems.Add(rUsr.ID, rUsr.Benutzer1.Trim())
                        End If
                    End If
                Next

                Return tBenutzer
            End Using

        Catch ex As Exception
            Throw New Exception("General.getAllSachb: " + ex.ToString())
        Finally
        End Try
    End Function


    Public Sub GetEcxeptionGeneral(ByVal ex As Exception)
        PMDS.Global.ENV.HandleException(ex)
    End Sub

    Public Shared Sub getExep(ByVal ex As Exception)
        Dim gen As New General()
        gen.GetEcxeptionGeneral(ex)
    End Sub


    Public Function IsNull(ByVal Obj As Object) As Boolean
        Try
            IsNull = True

            If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                IsNull = True
            Else
                If Obj.GetType.ToString = "System.Guid" Then
                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                        IsNull = True
                    Else
                        If Obj.ToString = EmptyGuid.ToString Then
                            IsNull = True
                        Else
                            IsNull = False
                        End If
                    End If
                ElseIf Obj.GetType.ToString = "System.String" Then
                    If Object.Equals(Nothing, Trim(Obj)) Or Object.Equals(System.DBNull.Value, Trim(Obj)) Or Object.Equals("", Trim(Obj)) Then
                        IsNull = True
                    Else
                        If Obj.ToString = EmptyGuid.ToString Then
                            IsNull = True
                        Else
                            IsNull = False
                        End If
                    End If
                ElseIf Obj.GetType.ToString = "System.DateTime" Then
                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                        IsNull = True
                    Else
                        If Obj.Year = 1 And Obj.Month = 1 And Obj.Day = 1 Then
                            IsNull = True
                        Else
                            IsNull = False
                        End If
                    End If
                Else
                    If Object.Equals(Nothing, Obj) Or Object.Equals(System.DBNull.Value, Obj) Or Object.Equals("", Obj) Then
                        IsNull = True
                    Else
                        IsNull = False
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("General.IsNull: " + ex.ToString())
        End Try
    End Function

    Public Sub GarbColl()
            Try
            'System.GC.Collect(0, GCCollectionMode.Forced)
            'System.GC.Collect(0, GCCollectionMode.Optimized)
            'System.GC.Collect()

        Catch ex As Exception
                Throw New Exception("General.GarbColl: " + ex.ToString())
            End Try
        End Sub

    Public Shared Sub addStrToSql(ByRef sqlTxt As String, ByRef where As String)
        Try
            where += IIf(where.Trim() = "", " where " + sqlTxt, " and " + sqlTxt)

        Catch ex As Exception
            Throw New Exception("General.addStrToSql: " + ex.ToString())
        End Try
    End Sub

End Class
