Imports System.Text.RegularExpressions
'Imports Microsoft.Exchange.WebServices.Data
Imports System.Net
Imports System.Collections.Generic





Public Class clPlan

    Public gen As New General()

    Public Shared anzNachrichten As Integer = 0
    Public compUserAccounts1 As New compUserAccounts()

    Public Class cTgMail
        Public tagValue As Object = Nothing
        Public rPlan As dsPlan.planRow = Nothing
        Public cMessage1 As cMessage
        Public MessageIDAct As String = ""
        Public isOutlookWebAPI As Boolean = False
        Public lstAttachments As New System.Collections.Generic.List(Of cTgAttachment)
    End Class
    Public Class cTgAttachment
        Public byt() As Byte = Nothing
        Public fileName As String = ""
        Public typeFile As String = ""
        Public isItemAttachment As Boolean = False
    End Class

    Public Shared protWindowNormalOn As Boolean = False
    Public Shared protWindowMarkOn As Boolean = False


    Public funct1 As New QS2.functions.vb.FileFunctions()
    Public Shared abortIMport As Boolean = False
    Public db1 As New db()

    Public compPlanRead As New compPlan()

    Public Class cMessage
        'Public itemOutlook As Microsoft.Exchange.WebServices.Data.Item = Nothing
        'Public itemTask As Microsoft.Exchange.WebServices.Data.Task = Nothing
        Public bodyTxt As String = ""
        Public bodyHtml As String = ""
        Public hasHtml As Boolean = False
    End Class


    Public Shared typPlan_EMailEmpfangen As Integer = 1
    Public Shared typPlan_EMailGesendet As Integer = 2

    Public Shared typPlan_AufgabeTermin As Integer = 3
    Public Shared typPlan_Notiz As Integer = 5


    Public delDoInfoUI As onDoInfoUI
    Public Delegate Sub onDoInfoUI(ByVal logText As String, isException As Boolean, SendException As Boolean)


    Public Class cInfoMailService
        Public iCounterIncomingEMails2 As Integer = 0
        Public iCounterIncomingAppointmentsTasks As Integer = 0
        Public iCounterIncomingContacts As Integer = 0
    End Class
    Public Class cEMailAccount
        Public rUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
        Public isConnectedToServer As Boolean = False
    End Class

    Public Shared iCounterEMailsSent As Integer = 0

    Public Shared bDatumFixieren As Boolean = False
    Public Shared dVonFixiert As Date = Nothing
    Public Shared dBisFixiert As Date = Nothing








    Public Sub deletePlanBereich(ByRef rPlan As dsPlan.planBereichRow, ByRef abort As Boolean, ByRef mainWindow As contPlanung2Bereich, frmMessage As frmNachrichtBereich)
        Try
            Dim compPlanTmp As New compPlan()
            Dim b As New PMDS.db.PMDSBusiness()

            Dim txtTranslatedMsgBox As String = doUI.getRes("DoYouRealyWantToDeleteTheEntry") + "?" + vbNewLine
            txtTranslatedMsgBox += Me.getInfosPlan(rPlan.ID)
            If doUI.doMessageBoxTranslated(txtTranslatedMsgBox, "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not rPlan.IsIDSerienterminNull() Then
                    Dim txtTranslatedMsgBoxST As String = doUI.getRes("SerienterminLöschenAlleSerientermineLöschen") + "?"
                    Dim InfoST As String = ""
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                        Dim rPlansST As System.Linq.IQueryable(Of PMDS.db.Entities.planBereich) = b.getPlansBereichSerientermin(rPlan.IDSerientermin, rPlan.BeginntAm.Date, db)
                        InfoST = vbNewLine + vbNewLine + doUI.getRes("AnzahlSerientermine") + ": " + rPlansST.Count().ToString()
                    End Using

                    If doUI.doMessageBoxTranslated(txtTranslatedMsgBoxST + InfoST, "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        compPlanTmp.deletePlanBereich(rPlan.ID)
                        compPlanTmp.deletePlanBereichSerientermin(rPlan.IDSerientermin, rPlan.BeginntAm.Date)
                        abort = False
                    Else
                        compPlanTmp.deletePlanBereich(rPlan.ID)
                        abort = False
                    End If
                Else
                    compPlanTmp.deletePlanBereich(rPlan.ID)
                    abort = False
                End If

                If Not mainWindow Is Nothing Then
                    mainWindow.ContPlanungDataBereich1.search(False, False, False)
                End If
                If Not frmMessage Is Nothing Then
                    frmMessage.Close()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("clPlan.deletePlanBereich: " + ex.ToString())
        End Try
    End Sub


    Public Sub deletePlan(ByRef rPlan As dsPlan.planRow, ByRef abort As Boolean, ByRef mainWindow As contPlanung2, frmMessage As frmNachricht3)
        Try
            Dim compPlanTmp As New compPlan()
            Dim b As New PMDS.db.PMDSBusiness()

            Dim txtTranslatedMsgBox As String = doUI.getRes("DoYouRealyWantToDeleteTheEntry") + "?" + vbNewLine
            txtTranslatedMsgBox += Me.getInfosPlan(rPlan.ID)
            If doUI.doMessageBoxTranslated(txtTranslatedMsgBox, "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                If Not rPlan.IsIDSerienterminNull() Then
                    Dim txtTranslatedMsgBoxST As String = doUI.getRes("SerienterminLöschenAlleSerientermineLöschen") + "?"
                    Dim InfoST As String = ""
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                        Dim rPlansST As System.Linq.IQueryable(Of PMDS.db.Entities.plan) = b.getPlansSerientermin(rPlan.IDSerientermin, rPlan.BeginntAm.Date, db)
                        InfoST = vbNewLine + vbNewLine + doUI.getRes("AnzahlSerientermine") + ": " + rPlansST.Count().ToString()
                    End Using

                    If doUI.doMessageBoxTranslated(txtTranslatedMsgBoxST + InfoST, "", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                        'cOutlookWebAPI1.deleteOutlookItem(rPlan.ID, rPlan.SendWithPostOfficeBoxForAll)
                        compPlanTmp.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, rPlan.IDArt, rPlan.Betreff)
                        compPlanTmp.deletePlanSerientermin(rPlan.IDSerientermin, rPlan.BeginntAm.Date)
                        abort = False
                    Else
                        Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                        'cOutlookWebAPI1.deleteOutlookItem(rPlan.ID, rPlan.SendWithPostOfficeBoxForAll)
                        compPlanTmp.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, rPlan.IDArt, rPlan.Betreff)
                        abort = False
                    End If
                Else
                    Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                    'cOutlookWebAPI1.deleteOutlookItem(rPlan.ID, rPlan.SendWithPostOfficeBoxForAll)
                    compPlanTmp.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, rPlan.IDArt, rPlan.Betreff)
                    abort = False
                End If

                If Not mainWindow Is Nothing Then
                    mainWindow.ContPlanung1.search(False, False, False, False)
                End If
                If Not frmMessage Is Nothing Then
                    frmMessage.Close()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("clPlan.deletePlan: " + ex.ToString())
        End Try
    End Sub

    Public Function getInfosPlan(ByRef IDPlan As Guid) As String
        Try
            Dim clPlan1 As New clPlan()
            Dim dsPlanTmp As New dsPlan()
            Dim compPlanTmp As New compPlan()
            compPlanTmp.getPlanObject(IDPlan, compPlan.eTypSelPlanObject.allIDPlan, dsPlanTmp)

            Dim sInfoKlientPatients As String = ""
            Dim iCounterKlientPatients As Integer = 0
            Dim sInfoTmp As String = clPlan1.getObjectsPlanInfos(dsPlanTmp, True, False, iCounterKlientPatients)
            If iCounterKlientPatients > 0 Then
                sInfoKlientPatients += vbNewLine + doUI.getRes("Patienten") + " (" + iCounterKlientPatients.ToString() + "): " + sInfoTmp
            End If

            iCounterKlientPatients = 0
            sInfoTmp = ""
            sInfoTmp = clPlan1.getObjectsPlanInfos(dsPlanTmp, False, True, iCounterKlientPatients)
            If iCounterKlientPatients > 0 Then
                sInfoKlientPatients += doUI.getRes("Benutzer") + " (" + iCounterKlientPatients.ToString() + "): " + sInfoTmp
            End If

            Return sInfoKlientPatients

        Catch ex As Exception
            Throw New Exception("clPlan.getInfosPlan: " + ex.ToString())
        End Try
    End Function
    Public Function getObjectsPlanInfos(ByRef DsPlan1 As dsPlan, ByRef getInfoPatients As Boolean, getInfoUsers As Boolean, ByRef iCounter As Integer) As String
        Try
            Dim b As New PMDS.db.PMDSBusiness()

            Dim sInfo As String = ""
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                For Each rPlanObject As dsPlan.planObjectRow In DsPlan1.planObject
                    If rPlanObject.RowState <> DataRowState.Deleted Then
                        If getInfoPatients Then
                            If b.checkIDIsPatient(rPlanObject.IDObject, db) Then
                                'os191224
                                Dim rPatInfo = (From p In db.Patient
                                                Where p.ID = rPlanObject.IDObject
                                                Select New With
                                                {p.Nachname, p.Vorname}).First()
                                'Dim rPatient As PMDS.db.Entities.Patient = b.getPatient(rPlanObject.IDObject, db)
                                sInfo += rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim() + ", "
                                iCounter += 1
                            End If
                        ElseIf getInfoUsers Then
                            If b.checkIDIsBenutzer(rPlanObject.IDObject, db) Then
                                Dim rPatient As PMDS.db.Entities.Benutzer = b.getUser(rPlanObject.IDObject, db)
                                sInfo += rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + ", "
                                iCounter += 1
                            End If
                        End If
                    End If
                Next
            End Using

            If iCounter > 0 Then
                sInfo += vbNewLine + vbNewLine
            End If
            Return sInfo

        Catch ex As Exception
            Throw New Exception("clPlan.getObjectsPlanInfos: " + ex.ToString())
        End Try
    End Function


    Public Function sendEMail(ByVal mailAn As String, ByVal mailCC As String, ByVal BCc As String, ByVal mitMsgBox As Boolean,
                              ByVal title As String, ByVal text As String,
                              ByVal tPlanAnhang As dsPlan.planAnhangDataTable, ByVal isHTML As Boolean,
                              ByVal updateAlsGesendet As Boolean, ByVal IDPlan As System.Guid, ByVal IDPlanMain As System.Guid,
                              ByVal throwExep As Boolean, ByVal doExceptToProtokoll As Boolean, ByRef protokoll As String,
                              ByVal isService As Boolean,
                              ByRef rUsrAccount As dsUserAccounts.tblUserAccountsRow,
                              ByRef WaitATimeAfterSent As Boolean, IsSystemErrorMessage As Boolean) As Boolean
        Try
            If IsSystemErrorMessage Then
                Dim compUserAccountsTmp As New compUserAccounts()     'lthNotOKEMailSystemAK
                Dim dsUserAccountsTmp As New dsUserAccounts()
                rUsrAccount = compUserAccountsTmp.getNewRowUserAccounts(dsUserAccountsTmp.tblUserAccounts)
                'rUsrAccount.Name = Settings.Systemmessage_Name.Trim()
                'rUsrAccount.AdrFrom = Settings.Systemmessage_AdrFrom.Trim()
                'rUsrAccount.Server = Settings.Systemmessage_Server.Trim()
                'rUsrAccount.Port = Settings.Systemmessage_Port
                'rUsrAccount.UsrAuthentication = Settings.Systemmessage_User.Trim()
                'rUsrAccount.PwdAuthentication = Settings.Systemmessage_Pwd.Trim()
                'rUsrAccount.SSL = Settings.Systemmessage_SSl
                rUsrAccount.OutlookWebAPI = True
            End If

            If rUsrAccount.OutlookWebAPI Then
                Throw New Exception("sendEMail: send per OutlookWebAPI not activated!")
                'Return Me.sendEMailOutlookWebAPI(mailAn, mailCC, BCc, mitMsgBox, title, text, tPlanAnhang, isHTML, updateAlsGesendet, IDPlan,
                '                            IDPlanMain, throwExep, doExceptToProtokoll, protokoll, isService, rUsrAccount, WaitATimeAfterSent,
                '                            IsSystemErrorMessage)
            Else
                Throw New Exception("sendEMail: send per smtp not activated!")
                Return Me.sendEMailSmtp(mailAn, mailCC, BCc, mitMsgBox, title, text, tPlanAnhang, isHTML, updateAlsGesendet, IDPlan,
                                            IDPlanMain, throwExep, doExceptToProtokoll, protokoll, isService, rUsrAccount, WaitATimeAfterSent,
                                            IsSystemErrorMessage)
            End If

            'Return Me.sendEMailSmtp(mailAn, mailCC, BCc, mitMsgBox, title, text, tPlanAnhang, isHTML, updateAlsGesendet, IDPlan, _
            '                IDPlanMain, throwExep, doExceptToProtokoll, protokoll, isService, rUsrAccount, WaitATimeAfterSent, _
            '                IsSystemErrorMessage)

        Catch ex As Exception
            If throwExep Then
                Throw New Exception(ex.ToString)
            ElseIf doExceptToProtokoll Then
                protokoll += ex.ToString() + vbNewLine + vbNewLine
            Else
                Me.gen.GetEcxeptionGeneral(ex)
            End If
        End Try
    End Function
    Public Function sendEMailSmtp(ByVal mailAn As String, ByVal mailCC As String, ByVal BCc As String, ByVal mitMsgBox As Boolean,
                                ByVal title As String, ByVal text As String,
                                ByVal tPlanAnhang As dsPlan.planAnhangDataTable, ByVal isHTML As Boolean,
                                ByVal updateAlsGesendet As Boolean, ByVal IDPlan As System.Guid, ByVal IDPlanMain As System.Guid,
                                ByVal throwExep As Boolean, ByVal doExceptToProtokoll As Boolean, ByRef protokoll As String,
                                ByVal isService As Boolean,
                                ByRef rUsrAccount As dsUserAccounts.tblUserAccountsRow,
                                ByRef WaitATimeAfterSent As Boolean, IsSystemErrorMessage As Boolean) As Boolean
        Dim txtDump As String = ""
        Try
            Dim anzAn As Integer = 0
            Dim anzCC As Integer = 0
            Dim anzBCC As Integer = 0
            Dim anzAnhänge As Integer = 0

            Dim email As New System.Net.Mail.MailMessage()
            Dim adrFrom As New System.Net.Mail.MailAddress(rUsrAccount.AdrFrom, rUsrAccount.Name)
            email.From = adrFrom

            txtDump += "email.From: " + adrFrom.Address + vbNewLine

            'If ITSCont.core.SystemDb.actUsr.rUsrAdr.Email.Trim() <> "" Then
            '    adrFrom = New System.Net.Mail.MailAddress(ITSCont.core.SystemDb.actUsr.rUsrAdr.Email.Trim())
            '    email.From = adrFrom
            '    txtDump += "email.From: " + email.From.Address + vbNewLine
            'End If

            Dim arrAdr As New ArrayList
            arrAdr = Me.getArrAdresses(mailAn)
            Dim i As Integer = 0
            For Each adr As String In arrAdr
                If clPlan.IsValidEmail(adr, protokoll, "") Then
                    Dim adrTo As New System.Net.Mail.MailAddress(adr)
                    email.To.Add(adrTo)
                    txtDump += "email.To: " + email.To(i).Address + vbNewLine
                    anzAn += 1
                    i += 1
                End If
            Next

            arrAdr.Clear()
            arrAdr = Me.getArrAdresses(mailCC)
            i = 0
            For Each adr As String In arrAdr
                If clPlan.IsValidEmail(adr, protokoll, "") Then
                    Dim adrCC As New System.Net.Mail.MailAddress(adr)
                    email.CC.Add(adrCC)
                    txtDump += "email.CC: " + email.CC(i).Address + vbNewLine
                    anzCC += 1
                    i += 1
                End If
            Next

            arrAdr.Clear()
            arrAdr = Me.getArrAdresses(BCc)
            i = 0
            For Each adr As String In arrAdr
                If clPlan.IsValidEmail(adr, protokoll, "") Then
                    Dim adrBCC As New System.Net.Mail.MailAddress(adr)
                    email.Bcc.Add(adrBCC)
                    txtDump += "email.Bcc: " + email.Bcc(i).Address + vbNewLine
                    anzBCC += 1
                    i += 1
                End If
            Next

            email.Subject = title
            txtDump += "email.Subject: " + email.Subject + vbNewLine
            email.Priority = Net.Mail.MailPriority.Normal
            email.Body = text
            email.IsBodyHtml = isHTML
            txtDump += "email.IsBodyHtml: " + email.IsBodyHtml.ToString() + vbNewLine

            i = 0
            For Each rAnhang As dsPlan.planAnhangRow In tPlanAnhang
                Dim memStream As New System.IO.MemoryStream(rAnhang.doku)
                Dim newAttachment As New System.Net.Mail.Attachment(memStream, rAnhang.Bezeichnung + rAnhang.DateiTyp)
                email.Attachments.Add(newAttachment)
                txtDump += "email.Attachments: " + email.Attachments(i).ContentId + vbNewLine
                anzAnhänge += 1
                i += 1
            Next

            Me.gen.GarbColl()

            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls
            Dim SmtpMail As New System.Net.Mail.SmtpClient(rUsrAccount.Server, rUsrAccount.Port)
            txtDump += "SmtpMail.Host: " + SmtpMail.Host + vbNewLine
            txtDump += "SmtpMail.Port: " + SmtpMail.Port.ToString() + vbNewLine

            Dim basicAuthenticationInfo As New System.Net.NetworkCredential(rUsrAccount.UsrAuthentication, rUsrAccount.PwdAuthentication)
            txtDump += "basicAuthenticationInfo.UserName: " + basicAuthenticationInfo.UserName + vbNewLine
            txtDump += "basicAuthenticationInfo.Domain: " + basicAuthenticationInfo.Domain + vbNewLine
            SmtpMail.Credentials = basicAuthenticationInfo
            txtDump += "SmtpMail.Credentials: OK" + vbNewLine
            'SmtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            'SmtpMail.ClientCertificates = System.Security.Cryptography.X509Certificates.

            SmtpMail.EnableSsl = rUsrAccount.SSL
            SmtpMail.Port = rUsrAccount.Port
            'TLS aktivieren

            'SmtpMail.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory
            SmtpMail.Send(email)
            txtDump += "SmtpMail.Send: OK" + vbNewLine
            'If updateAlsGesendet Then Me.SendeWebauftrag(IDAufgabe)

            Dim sHTML As String = ""
            If isHTML Then : sHTML = "Ja" : Else : sHTML = "Nein" : End If
            Dim anzGes As Integer = anzAn + anzCC
            Dim msgTxt As String = anzGes.ToString + " E-Mails sent!" + vbNewLine + vbNewLine +
                                  "   Adresses:     " + anzAn.ToString + vbNewLine +
                                  "   CC:           " + anzCC.ToString + vbNewLine +
                                  "   BCC:          " + anzBCC.ToString + vbNewLine +
                                  "   Appendix:     " + anzAnhänge.ToString + vbNewLine +
                                  "   HTML:         " + sHTML.ToString
            If mitMsgBox Then
                MsgBox(msgTxt, MsgBoxStyle.Exclamation, "Sending E-Mails")
                'Else
                '    protokoll += ""
            End If

            If updateAlsGesendet Then
                Dim compPlan1 As New compPlan()
                Dim rPlan As dsPlan.planRow = Me.compPlanRead.getPlanRow(IDPlan, compPlan.eTypSelPlan.id, True)
                If Not rPlan Is Nothing Then
                    compPlan1.updateGesendetAm(IDPlan, Now)
                    compPlan1.UpdatePlanDesign(IDPlan, False)
                    compPlan1.UpdatePlanIDUserAccount(IDPlan, rUsrAccount.ID)
                    compPlan1.UpdatePlanIsOwner(IDPlan, True)
                End If

                Dim rPlanParent As dsPlan.planRow = Me.compPlanRead.getPlanRow(IDPlanMain, compPlan.eTypSelPlan.id, True)
                If Not rPlanParent Is Nothing Then
                    compPlan1.updateGesendetAm(rPlanParent.ID, Now)
                    compPlan1.UpdatePlanDesign(rPlanParent.ID, False)
                    'compPlan1.UpdatePlanIDUserAccount(rPlanParent.ID, rUsrAccount.ID)
                    If rPlanParent.IDArt = clPlan.typPlan_EMailGesendet Or
                        rPlanParent.IDArt = clPlan.typPlan_AufgabeTermin Then

                        compPlan1.UpdatePlanIsOwner(rPlanParent.ID, False)

                        'ElseIf rPlanParent.IDArt = clPlan.typPlan_Workshop Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_Seminar Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_Webauftrag Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_Webinar Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_TelTermin Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_TerminVorOrt Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_Anfahrt Or _
                        '    rPlanParent.IDArt = clPlan.typPlan_Abfahrt Then

                        '    compPlan1.UpdatePlanIsOwner(rPlanParent.ID, True)

                    End If
                End If
                'compPlan1.UpdatePlanDesign(IDPlan, False)
            End If
            Return True

        Catch ex As Exception
            If throwExep Then
                'MsgBox("Dump Send E-Mail-Smtp:" + vbNewLine + txtDump.ToString(), vbInformation, "Error sending E-Mails")
                If txtDump.Trim() <> "" Then
                    Throw New Exception(txtDump.ToString + vbNewLine + vbNewLine + ex.ToString)
                Else
                    Throw New Exception(ex.ToString)
                End If

            ElseIf doExceptToProtokoll Then
                protokoll += ex.ToString() + vbNewLine + vbNewLine
            Else
                gen.GetEcxeptionGeneral(ex)
                If txtDump.Trim() <> "" Then
                    Throw New Exception(txtDump.ToString)
                End If
            End If
        Finally
            'If WaitATimeAfterSent Then
            '    'System.Threading.Thread.Sleep(Settings.WaitAfterEMailSent * 1000)
            'End If
        End Try
    End Function
    Public Function sendEMailOutlookWebAPIxy(ByVal mailAn As String, ByVal mailCC As String, ByVal BCc As String, ByVal mitMsgBox As Boolean,
                                            ByVal title As String, ByVal text As String,
                                            ByVal tPlanAnhang As dsPlan.planAnhangDataTable, ByVal isHTML As Boolean,
                                            ByVal updateAlsGesendet As Boolean, ByVal IDPlan As System.Guid, ByVal IDPlanMain As System.Guid,
                                            ByVal throwExep As Boolean, ByVal doExceptToProtokoll As Boolean, ByRef protokoll As String,
                                            ByVal isService As Boolean,
                                            ByRef rUsrAccount As dsUserAccounts.tblUserAccountsRow,
                                            ByRef WaitATimeAfterSent As Boolean, IsSystemErrorMessage As Boolean) As Boolean
        Dim txtDump As String = ""
        Try
            'Dim anzAn As Integer = 0
            'Dim anzCC As Integer = 0
            'Dim anzBCC As Integer = 0
            'Dim anzAnhänge As Integer = 0

            'Dim es As New ExchangeService(ExchangeVersion.Exchange2013_SP1)
            'es.Url = New Uri(General.UrlOutlookWebAPI.Trim())
            'es.Credentials = New NetworkCredential(rUsrAccount.UsrAuthentication.Trim(), rUsrAccount.PwdAuthentication.Trim())
            'txtDump += "basicAuthenticationInfo.UserName: " + rUsrAccount.UsrAuthentication.Trim() + vbNewLine
            'txtDump += "basicAuthenticationInfo.Domain: " + rUsrAccount.UsrAuthentication.Trim() + vbNewLine

            'Dim message As New EmailMessage(es)
            'Dim adrSender As New Microsoft.Exchange.WebServices.Data.EmailAddress()
            'adrSender.Address = rUsrAccount.AdrFrom.Trim()
            'message.From = adrSender
            'txtDump += "email.From: " + adrSender.Address + vbNewLine
            'message.Subject = title.Trim()
            'txtDump += "email.Subject: " + message.Subject + vbNewLine
            'message.Body = text
            ''message.Priority = Net.Mail.MailPriority.Normal
            'If isHTML Then
            '    message.Body.BodyType = BodyType.HTML
            'Else
            '    message.Body.BodyType = BodyType.Text
            'End If
            'txtDump += "email.IsBodyHtml: " + isHTML.ToString() + vbNewLine

            'Dim arrAdr As New ArrayList
            'arrAdr = Me.getArrAdresses(mailAn)
            'Dim i As Integer = 0
            'For Each adr As String In arrAdr
            '    If clPlan.IsValidEmail(adr, protokoll, "") Then
            '        Dim adrTo As New Microsoft.Exchange.WebServices.Data.EmailAddress()
            '        adrTo.Address = adr.Trim()
            '        message.ToRecipients.Add(adrTo)
            '        txtDump += "email.To: " + adrTo.Address + vbNewLine
            '        anzAn += 1
            '        i += 1
            '    End If
            'Next
            'arrAdr.Clear()
            'arrAdr = Me.getArrAdresses(mailCC)
            'i = 0
            'For Each adr As String In arrAdr
            '    If clPlan.IsValidEmail(adr, protokoll, "") Then
            '        Dim adrCC As New Microsoft.Exchange.WebServices.Data.EmailAddress()
            '        adrCC.Address = adr.Trim()
            '        message.CcRecipients.Add(adrCC)
            '        txtDump += "email.CC: " + adrCC.Address + vbNewLine
            '        anzCC += 1
            '        i += 1
            '    End If
            'Next
            'arrAdr.Clear()
            'arrAdr = Me.getArrAdresses(BCc)
            'i = 0
            'For Each adr As String In arrAdr
            '    If clPlan.IsValidEmail(adr, protokoll, "") Then
            '        Dim adrBCC As New Microsoft.Exchange.WebServices.Data.EmailAddress()
            '        adrBCC.Address = adr.Trim()
            '        message.BccRecipients.Add(adrBCC)
            '        txtDump += "email.Bcc: " + adrBCC.Address + vbNewLine
            '        anzBCC += 1
            '        i += 1
            '    End If
            'Next

            'i = 0
            'For Each rAnhang As dsPlan.planAnhangRow In tPlanAnhang
            '    Dim memStream As New System.IO.MemoryStream(rAnhang.doku)
            '    Dim attachmentName As String = rAnhang.Bezeichnung.Trim() + rAnhang.DateiTyp.Trim()
            '    Dim fileAttachment As FileAttachment = message.Attachments.AddFileAttachment(attachmentName.Trim(), memStream)
            '    txtDump += "email.Attachments: " + attachmentName + vbNewLine
            '    anzAnhänge += 1
            '    i += 1
            'Next
            'gen.GarbColl()

            'message.Send()
            'txtDump += "Outlook-E-mail.Send: OK" + vbNewLine
            ''If updateAlsGesendet Then Me.SendeWebauftrag(IDAufgabe)

            'Dim sHTML As String = ""
            'If isHTML Then : sHTML = "Ja" : Else : sHTML = "Nein" : End If
            'Dim anzGes As Integer = anzAn + anzCC
            'Dim msgTxt As String = anzGes.ToString + " Outlook-E-Mails sent!" + vbNewLine + vbNewLine +
            '                      "   Adresses:     " + anzAn.ToString + vbNewLine +
            '                      "   CC:           " + anzCC.ToString + vbNewLine +
            '                      "   BCC:          " + anzBCC.ToString + vbNewLine +
            '                      "   Appendix:     " + anzAnhänge.ToString + vbNewLine +
            '                      "   HTML:         " + sHTML.ToString
            'If mitMsgBox Then
            '    MsgBox(msgTxt, MsgBoxStyle.Exclamation, "Sending E-Mails")
            '    'Else
            '    '    protokoll += ""
            'End If

            'If updateAlsGesendet Then
            '    Dim compPlan1 As New compPlan()
            '    Dim rPlan As dsPlan.planRow = Me.compPlanRead.getPlanRow(IDPlan, compPlan.eTypSelPlan.id, True)
            '    If Not rPlan Is Nothing Then
            '        compPlan1.updateGesendetAm(IDPlan, Now)
            '        compPlan1.UpdatePlanDesign(IDPlan, False)
            '        compPlan1.UpdatePlanIDUserAccount(IDPlan, rUsrAccount.ID)
            '        compPlan1.UpdatePlanIsOwner(IDPlan, True)
            '    End If

            '    Dim rPlanParent As dsPlan.planRow = Me.compPlanRead.getPlanRow(IDPlanMain, compPlan.eTypSelPlan.id, True)
            '    If Not rPlanParent Is Nothing Then
            '        compPlan1.updateGesendetAm(rPlanParent.ID, Now)
            '        compPlan1.UpdatePlanDesign(rPlanParent.ID, False)
            '        'compPlan1.UpdatePlanIDUserAccount(rPlanParent.ID, rUsrAccount.ID)
            '        If rPlanParent.IDArt = clPlan.typPlan_EMailGesendet Or
            '            rPlanParent.IDArt = clPlan.typPlan_AufgabeTermin Then

            '            compPlan1.UpdatePlanIsOwner(rPlanParent.ID, False)

            '            'ElseIf rPlanParent.IDArt = clPlan.typPlan_Workshop Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_Seminar Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_Webauftrag Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_Webinar Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_TelTermin Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_TerminVorOrt Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_Anfahrt Or _
            '            '    rPlanParent.IDArt = clPlan.typPlan_Abfahrt Then

            '            '    compPlan1.UpdatePlanIsOwner(rPlanParent.ID, True)

            '        End If
            '    End If
            '    'compPlan1.UpdatePlanDesign(IDPlan, False)
            'End If

            Return True

        Catch ex As Exception
            If throwExep Then
                'MsgBox("Dump Send E-Mail-Smtp:" + vbNewLine + txtDump.ToString(), vbInformation, "Error sending E-Mails")
                If txtDump.Trim() <> "" Then
                    Throw New Exception(txtDump.ToString + vbNewLine + vbNewLine + ex.ToString)
                Else
                    Throw New Exception(ex.ToString)
                End If

            ElseIf doExceptToProtokoll Then
                protokoll += ex.ToString() + vbNewLine + vbNewLine
            Else
                gen.GetEcxeptionGeneral(ex)
                If txtDump.Trim() <> "" Then
                    Throw New Exception(txtDump.ToString)
                End If
            End If
        Finally
            'If WaitATimeAfterSent Then
            '    'System.Threading.Thread.Sleep(Settings.WaitAfterEMailSent * 1000)
            'End If
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
            Throw New Exception("clPlan.getArrAdresses: " + ex.ToString())
        End Try
    End Function


    Public Shared Function IsValidEmail(ByRef EMail As String, ByRef protocol As String, ByRef objectName As String) As Boolean
        Try
            If Not clPlan.IsValidEmailxy(EMail) Then
                Dim sTxtErr As String = doUI.getRes("EMailIXNotCorrect")
                sTxtErr = String.Format(sTxtErr, EMail)
                If objectName.Trim() <> "" Then
                    sTxtErr += "   -   " + objectName.Trim()
                End If
                protocol += sTxtErr + vbNewLine + protocol
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New Exception("clPlan.IsValidEmail: " + ex.ToString())
        End Try
    End Function
    Public Shared Function IsValidEmailxy(ByVal EMails As String) As Boolean
        ' Return true if strIn is in valid e-mail format.
        Return Regex.IsMatch(EMails,
               "^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
               "(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$")

    End Function



    Public Shared Function checkIfTextIsHtmlText(ByRef BodyText As String) As Boolean
        Try
            If BodyText.Trim().ToLower().Contains(("<br />").Trim().ToLower()) Or BodyText.Trim().ToLower().Contains(("<html>").Trim().ToLower()) Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("clPlan.checkIfTextIsHtmlText: " + ex.ToString())
        End Try
    End Function

    Public Function getBerufsgruppeFromLoggedInUser(db As PMDS.db.Entities.ERModellPMDSEntities) As System.Collections.Generic.List(Of String)
        Try
            Dim lBerufsstände As New System.Collections.Generic.List(Of String)()

            Dim b As New PMDS.db.PMDSBusiness()
            Dim rUsr As PMDS.db.Entities.Benutzer = b.getUser(PMDS.Global.ENV.USERID, db)

            If Not rUsr.IDBerufsstand Is Nothing Then
                Dim rSelListBerufsstand = (From o In db.AuswahlListe
                                           Where o.ID = rUsr.IDBerufsstand And o.IstGruppe = False And o.IDAuswahlListeGruppe = "BER"
                                           Select o.ID, o.Bezeichnung, o.GehörtzuGruppe, o.Hierarche).ToList().First()


                lBerufsstände.Add(rSelListBerufsstand.Bezeichnung.Trim())
            Else
                Throw New Exception("clPlan.getBerufsgruppeFromLoggedInUser: rUsr.IDBerufsstand=null for User '" + rUsr.Benutzer1.Trim() + "'not allowed!")
            End If

            Return lBerufsstände

        Catch ex As Exception
            Throw New Exception("clPlan.getBerufsgruppeFromLoggedInUser: " + ex.ToString())
        End Try
    End Function

End Class

