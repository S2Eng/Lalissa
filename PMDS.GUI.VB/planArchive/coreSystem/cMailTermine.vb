

Public Class cMailTermine

    Public gen As New GeneralArchiv
    Public Shared anzNachrichten As Integer = 0
    Public Shared listeOffenTermine As New frmOffeneTermine




    Public Function sendEMail(ByVal mailAn As String, ByVal mailCC As String, ByVal BCC As Boolean, ByVal mitMsgBox As Boolean,
                                ByVal title As String, ByVal text As String,
                                ByVal attachmentFiles As ArrayList, ByVal isHTML As Boolean,
                                ByVal updateAlsGesendet As Boolean, ByVal IDAufgabe As System.Guid,
                                Optional ByVal throwExep As Boolean = False) As Boolean
        Try
            Me.readCustMailUsr(PMDS.Global.ENV.USERID)

            Dim anzAn As Integer = 0
            Dim anzCC As Integer = 0
            Dim anzBCC As Integer = 0
            Dim anzAnh‰nge As Integer = 0

            Dim email As New System.Net.Mail.MailMessage()
            Dim adrFrom As New System.Net.Mail.MailAddress(PMDS.Global.clSMTP.SMTPFrom)
            email.From = adrFrom

            Dim arrAdr As New ArrayList
            arrAdr = Me.getArrAdresses(mailAn)
            For Each adr As String In arrAdr
                Dim adrTo As New System.Net.Mail.MailAddress(adr)
                email.To.Add(adrTo)
                anzAn += 1
            Next

            arrAdr.Clear()
            arrAdr = Me.getArrAdresses(mailCC)
            For Each adr As String In arrAdr
                If Not BCC Then
                    Dim adrCC As New System.Net.Mail.MailAddress(adr)
                    email.CC.Add(adrCC)
                    anzCC += 1
                Else
                    Dim adrBCC As New System.Net.Mail.MailAddress(adr)
                    email.Bcc.Add(adrBCC)
                    anzBCC += 1
                End If
            Next

            email.Subject = title
            email.Priority = Net.Mail.MailPriority.Normal
            email.Body = text
            email.IsBodyHtml = isHTML

            Dim clOp As New clStringOperate
            If Not attachmentFiles Is Nothing Then
                For Each fil As GeneralArchiv.clAnhang In attachmentFiles
                    Dim sTyp As String = clOp.GetFiletyp(fil.datei)
                    Dim filDest As String = PMDS.Global.ENV.path_Temp + "\" + fil.bezeichnung
                    gen.GarbColl()
                    If System.IO.File.Exists(filDest + sTyp) Then
                        Try
                            System.IO.File.Delete(filDest + sTyp)
                        Catch ex As Exception
                            For i As Integer = 1 To 10000
                                filDest = PMDS.Global.ENV.path_Temp + "\" + fil.bezeichnung + i.ToString
                                If Not System.IO.File.Exists(filDest + sTyp) Then
                                    Exit For
                                End If
                            Next
                        End Try
                    End If
                    gen.GarbColl()
                    System.IO.File.Copy(fil.datei, filDest + sTyp)
                    Dim newAttachment As New System.Net.Mail.Attachment(filDest + sTyp)
                    email.Attachments.Add(newAttachment)
                    anzAnh‰nge += 1
                Next
            End If
            gen.GarbColl()

            Dim SmtpMail As New System.Net.Mail.SmtpClient(PMDS.Global.clSMTP.SMTPServer, PMDS.Global.clSMTP.SMTPPort)
            Dim basicAuthenticationInfo As New System.Net.NetworkCredential(PMDS.Global.clSMTP.SMTPLoginUsr, PMDS.Global.clSMTP.SMTPLoginPwd)
            SmtpMail.Credentials = basicAuthenticationInfo
            'SmtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            SmtpMail.Send(email)
            Dim compSql1 As New compSql()
            If updateAlsGesendet Then compSql1.SendeWebauftrag(IDAufgabe)

            If mitMsgBox Then
                Dim sHTML As String = ""
                If isHTML Then : sHTML = "Ja" : Else : sHTML = "Nein" : End If
                Dim anzGes As Integer = anzAn + anzCC
                MsgBox("Es wurde/n " + anzGes.ToString + " E-Mails versendet!" + vbNewLine + vbNewLine +
                        "   Anzahl Adressen:    " + anzAn.ToString + vbNewLine +
                        "   Anzahl CC-Adressen: " + anzCC.ToString + vbNewLine +
                        "   Anzahl BCC-Adressen:" + anzBCC.ToString + vbNewLine +
                        "   Anzahl Anh‰nge:     " + anzAnh‰nge.ToString + vbNewLine +
                        "   HTML:               " + sHTML.ToString,
                          MsgBoxStyle.Exclamation, "E-Mails versenden")
            End If
            Return True

        Catch ex As Exception
            If throwExep Then
                Throw New Exception(ex.ToString)
            Else
                gen.GetEcxeptionGeneral(ex)
            End If
        End Try
    End Function
    Public Sub readCustMailUsr(ByVal IDBenutzer As System.Guid)
        Try
            If IDBenutzer.ToString = System.Guid.Empty.ToString Then
                PMDS.Global.ENV.readIniSMTP()
                If (PMDS.Global.clSMTP.SMTPServer = "") Then PMDS.Global.clSMTP.SMTPServer = System.Net.Dns.GetHostName
                If PMDS.Global.clSMTP.SMTPFrom = "" Then Throw New Exception("readCustMailUsr: Kein 'SMTPFrom' in Config zur Versendung des Mails angegeben!")
            Else
                Dim ben As New PMDS.db.DBBenutzer()
                Dim dt As DataTable = ben.readSMTPAngaben(IDBenutzer)
                PMDS.Global.clSMTP.SMTPServer = dt.Rows(0)("smtpSrv")
                If PMDS.Global.clSMTP.SMTPServer = "" Then
                    PMDS.Global.ENV.readIniSMTP()
                    If (PMDS.Global.clSMTP.SMTPServer = "") Then PMDS.Global.clSMTP.SMTPServer = System.Net.Dns.GetHostName
                    If PMDS.Global.clSMTP.SMTPFrom = "" Then Throw New Exception("readCustMailUsr: Kein 'SMTPFrom' in Config zur Versendung des Mails angegeben!")
                Else
                    PMDS.Global.clSMTP.SMTPPort = dt.Rows(0)("smtpPort")
                    PMDS.Global.clSMTP.SMTPLoginUsr = dt.Rows(0)("smtpAbsender")
                    PMDS.Global.clSMTP.SMTPLoginPwd = dt.Rows(0)("smtpPwd")
                    PMDS.Global.clSMTP.SMTPAuth = dt.Rows(0)("smtpAuthentStandard")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("readCustMailUsr: " + ex.ToString())
        End Try
    End Sub


    Public Function getObjectNachricht(ByVal IDAufgabe As System.Guid) As clObject
        Try
            Dim ret As New clObject
            If IDAufgabe.ToString <> gen.EmptyGuid.ToString Then
                Dim tblAdminAufgabeZuordnung As New sqlAufgabeZuordnung
                tblAdminAufgabeZuordnung.SelectAllRows_IDAufgabe(IDAufgabe)
                If tblAdminAufgabeZuordnung.dtAufgabeZuordnung.Rows.Count > 0 Then
                    Dim r As DataRow = tblAdminAufgabeZuordnung.dtAufgabeZuordnung.Rows(0)
                    ret.id = r("IDZuordnung").ToString
                    Dim pat As New PMDS.BusinessLogic.Patient(gen.StrToGuid(ret.id))
                    ret.bezeichnung = pat.Vorname + " " + pat.Nachname
                    If tblAdminAufgabeZuordnung.dtAufgabeZuordnung.Rows.Count > 1 Then
                        Throw New Exception("getObjectNachricht: Zu viele Objekte zu Nachricht '" + IDAufgabe.ToString + "' in Db")
                    End If

                    Return ret
                End If
            End If
            Return ret

        Catch ex As Exception
            Throw New Exception("getObjectNachricht: " + ex.ToString())
        End Try
    End Function

    Public Function getArrAdresses(ByVal adress As String) As ArrayList
        Try

            Dim arrAdresses As New ArrayList
            Dim maiAdr As String = "" : Dim akPos As Integer = 0
            For Each s As String In adress
                If s = ";" Then
                    If Not gen.IsNull(maiAdr) Then arrAdresses.Add(Trim(maiAdr))
                    maiAdr = ""
                Else
                    maiAdr += s
                End If
                akPos += 1
            Next
            If Not gen.IsNull(maiAdr) Then arrAdresses.Add(maiAdr)
            Return arrAdresses

        Catch ex As Exception
            Throw New Exception("getArrAdresses: " + ex.ToString())
        End Try
    End Function




    Public Sub Termin_Neu(ByVal Dat As Date, ByVal Time As Date,
                          ByVal idobject As String, ByVal patient As String,
                              ByVal modalWindow As contPlanungMain, ByVal modalWindowErinnerung As frmOffeneTermine)
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            exch.app = General.InitApplicationAufgabenTermine.terminNeu
            Dim frm As New frmNachricht
            frm._typ = General.eTypPlanung.termin
            frm.dateTemp = Dat
            frm.timeTemp = Time
            frm.modalWindow = modalWindow
            frm.modalWindowErinnerung = modalWindowErinnerung
            frm.IDobject = idobject
            frm.patient = patient

            frm.Show()
            frm.Init(exch)

        Catch ex As Exception
            Throw New Exception("Termin_Neu: " + ex.ToString())
        End Try
    End Sub
    Public Sub Mail_Neu(ByVal Dat As Date, ByVal Time As Date,
                         ByVal idobject As String, ByVal patient As String,
                         ByVal modalWindow As contPlanungMain,
                         ByVal typMail As GeneralArchiv.eTypMail, ByRef modalWindowErinnerung As frmOffeneTermine)
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            exch.app = General.InitApplicationAufgabenTermine.mailNeu
            exch.typMail = typMail
            Dim frm As New frmNachricht
            frm._typ = General.eTypPlanung.mail
            frm.dateTemp = Nothing      'Dat
            frm.timeTemp = Nothing      'Time
            frm.modalWindow = modalWindow
            frm.modalWindowErinnerung = modalWindowErinnerung

            frm.IDobject = idobject
            frm.patient = patient

            frm.Show()
            frm.Init(exch)

        Catch ex As Exception
            Throw New Exception("Mail_Neu: " + ex.ToString())
        End Try
    End Sub

    Public Function nachricht÷ffnen(ByVal IDAufgabe As System.Guid, ByVal modalWindow As contPlanungMain,
                                          ByVal IDobject As String, ByRef modalWindowErinnerung As frmOffeneTermine) As Boolean
        Dim General As New GeneralArchiv
        Try
            Dim exch As New Exchange
            Dim tblAdminAufgaben As New sqlAufgaben
            tblAdminAufgaben.getAufgaben(IDAufgabe)
            If tblAdminAufgaben.tAufgaben.Rows.Count = 1 Then
                Dim DataRow As DataRow = tblAdminAufgaben.tAufgaben.Rows(0)
                Dim compSql1 As New compSql()
                Dim dt As New DataTable()
                compSql1.getAufgabeArt(DataRow("IDArt"), dt)
                If dt.Rows.Count = 1 Then
                    Dim r As DataRow = dt.Rows(0)
                    exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen
                    exch.str = General.GuidToStr(IDAufgabe)
                    Dim frm As New frmNachricht
                    If r("ID").ToString = General.IDMail.ToString Then
                        frm._typ = General.eTypPlanung.mail
                    ElseIf r("ID").ToString = General.IDTermin.ToString Or r("ID").ToString = General.IDTermin2.ToString Then
                        frm._typ = General.eTypPlanung.termin
                    Else
                        Try
                            Throw New Exception("nachricht÷ffnen: Nachricht hat falsche IDArt! IDAufgabe: '" + IDAufgabe.ToString + "'")
                        Catch ex As Exception
                            General.GetEcxeptionGeneral(ex)
                        End Try
                    End If
                    frm.IDobject = ""
                    frm.patient = ""
                    frm.modalWindow = modalWindow
                    frm.modalWindowErinnerung = modalWindowErinnerung
                    frm.Show()
                    frm.Init(exch)
                End If
            Else
                MsgBox("Termin bzw. E-Mail existiert nicht mehr!", MsgBoxStyle.Information, "PMDS")
            End If

        Catch ex As Exception
            Throw New Exception("nachricht÷ffnen: " + ex.ToString())
        End Try
    End Function

End Class

