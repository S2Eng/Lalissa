Imports System.Windows.Forms
Imports System.Drawing


Public Class contMailInputSrv


    Public gen As New General()
    Public genMain As New General()
    Public isLoaded As Boolean = False

    Public mainWindow As frmMailInputSrv
    Public mailsSaved As Boolean = False

    'Public messages As New System.Collections.Generic.Dictionary(Of Integer, OpenPop.Mime.Message)
    Public messages As New System.Collections.Generic.List(Of clPlan.cMessage)

    Public clFold As New clFolder
    Public StringOperate As New QS2.functions.vb.functOld()

    Public clPlan1 As New clPlan()
    Public dsPlanReaded As New dsPlan()
    Public compPlan1 As New compPlan()

    Public IDUserAccountSelected As System.Guid = Nothing
    Public doUI1 As New doUI()

    Public Class cNodeTree
        Public NrAttechmentChiliKat As Integer = -1
        Public Attachment As clPlan.cTgAttachment = Nothing
    End Class






    Private Sub contMailInputSrv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.UltraTabControlMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
            Me.UltraTabControlMail.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
            Me.UltraTabControlMail.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard

            Me.doRes()

            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
            Me.ContComboUserAccounts1.initControl(Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList)
            If PMDS.Global.ENV.adminSecure Then
                Me.ContComboUserAccounts1.loadUserAccounts(compUserAccounts.eTypEMailAccount.Pop3, "")
            Else
                Me.ContComboUserAccounts1.loadUserAccounts(compUserAccounts.eTypEMailAccount.Pop3, UserLoggedIn.Trim())
            End If
            If Not Me.IDUserAccountSelected = Nothing Then
                Me.ContComboUserAccounts1.cboComboBoxUsrAccounts.Value = Me.IDUserAccountSelected
            End If

            Me.ContTxtEditor1.doNew(False)
            Me.ContTxtEditor1.loadForm(False, Nothing, False)
            Me.ContTxtEditor1.setControlTyp()

            Me.lblPosteingang.Text = doUI.getRes("Inbox")
            Me.lblFound.Text = ""
            Me.lblTextIsHtmJN.Text = ""

            Me.clearUIEMail()
            Me.setStatusBarUI(False)
            'contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.initControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub doRes()
        Try
            Me.btnReadMails.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32)
            Me.btnImportEMails.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.ImageList1Small.Images.Clear()
            Me.ImageList1Small.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Abbrechen, 32, 32))
            Me.ImageList1Small.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32))

            Me.btnAbort.ImageList = Me.ImageList1Small
            Me.btnAbort.Appearance.Image = Me.ImageList1Small.Images(0)

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.doRes: " + ex.ToString())
        End Try
    End Sub

    Public Sub readMailsFromServer()
        Dim dStart As Date = Now
        Dim dEnd As Date = Nothing
        Try
            Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = Me.ContComboUserAccounts1.getSelectedUserAccount(False)
            If rUserAccount Is Nothing Then
                Me.ContComboUserAccounts1.cboComboBoxUsrAccounts.Focus()
                doUI.doMessageBox2("NoAccountSelected", "", "!")
                Exit Sub
            End If

            'Dim nSecondTimerScannEMail As Integer = Me.actUsr1.adjustRead(compAdjust.eAdjust.EMailPosteingangOnServerSecondTimer, compAdjust.eTypSelAdjust.all)
            clPlan.abortIMport = False
            Me.ContTxtEditor1.clearForm()
            Me.treeListMails.Nodes.Clear()

            Dim protokoll As String = ""
            Dim protokollErr As String = ""
            Dim numMessages As Long

            Me.messages.Clear()
            Me.setStatusBarUI(True)
            Me.dsPlanReaded.Clear()
            Dim InfoMailService As New clPlan.cInfoMailService()
            Dim EMailAccount As New clPlan.cEMailAccount()
            EMailAccount.rUserAccount = rUserAccount
            General.abort = False
            InfoMailService.iCounterIncomingEMails2 = 0

            'contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
            Me.clearUIEMail()

            Dim sInfoAccountsScanned As String = ""
            Dim iFoundItems As Integer = 0
            Dim iFoundFolders As Integer = 0
            Me.lblFound.Text = ""

            Dim EMailsVomServerLöschen As Boolean = False
            Dim cOutlookWebAPI1 As New cOutlookWebAPI()
            'cOutlookWebAPI1.readFoldersOutlook(dsPlanReaded, compPlan1, messages, False, False, General.maxSizeEMailKB,
            '                                                EMailsVomServerLöschen, Me.chkAutoAbortLastDateReceived.Checked, protokoll, protokollErr,
            '                                                True, General.InfoMailService, EMailAccount, General.UrlOutlookWebAPI.Trim(), Me.treeListMails, dStart.ToString,
            '                                                Me.UltraProgressBar1, iFoundItems, iFoundFolders, sInfoAccountsScanned, False, True)

            Me.lblFound.Text = "Found: " + iFoundItems.ToString()

            If protokoll.Trim() <> "" Then
                Dim frmProt As New QS2.core.vb.frmProtocol()
                frmProt.initControl()
                frmProt.Show()
                frmProt.ContProtocol1.setText(protokoll.Trim())
                frmProt.Text = doUI.getRes("RecordingEMailsFromTheInboxServer")
            End If

        Catch ex As Exception
            Me.setStatusBarUI(False)
            Throw New Exception("contMailInputSrv.readMailsFromServer: " + ex.ToString())
        Finally
            Me.setStatusBarUI(False)
            dEnd = Now
            'MsgBox("Start: " + dStart.ToString() + vbNewLine + "End: " + dEnd.ToString())
        End Try
    End Sub
    Public Sub setStatusBarUI(ByVal bOn As Boolean)
        Try
            Me.UltraProgressBar1.Visible = bOn
            Me.UltraProgressBar1.Value = 0
            Me.UltraProgressBar1.Minimum = 0
            Me.UltraProgressBar1.Maximum = 100

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.setStatusBarUI: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadMail(ByVal Nr As Integer, ByRef cTgMailSelected As clPlan.cTgMail,
                        ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow)
        Try
            Me.clearUIEMail()

            'Dim messageFound As clPlan.cMessage = Me.messages(Nr)

            Me.txtSubject.Text = cTgMailSelected.rPlan.Betreff.Trim()
            Me.lblVonDatum.Text = cTgMailSelected.rPlan.empfangenAm       '"Gesendet: " + message.Headers.Date
            Me.txtFrom.Text = cTgMailSelected.rPlan.MailFrom            'message.Headers.From.MailAddress.Address
            Me.txtTo.Text = cTgMailSelected.rPlan.MailAn
            Me.txtCc.Text = cTgMailSelected.rPlan.MailCC
            Me.txtBcc.Text = cTgMailSelected.rPlan.MailBcc

            If cTgMailSelected.cMessage1.hasHtml Then
                Me.showBody(cTgMailSelected.cMessage1.bodyHtml, TXTextControl.StreamType.HTMLFormat, rUserAccount)
            Else
                Me.showBody(cTgMailSelected.cMessage1.bodyTxt, TXTextControl.StreamType.PlainText, rUserAccount)
            End If

            'Dim dsObjectReadObj As New dsObject()                  'lthNotOKEMailSystemAK
            'Dim compObjectReadObj As New compObject()
            'Me.treeObjects.Nodes.Clear()
            'Dim arrPlanObject As dsPlan.planObjectRow() = Me.dsPlanReaded.planObject.Select(Me.dsPlanReaded.planObject.IDPlanColumn.ColumnName + "='" + cTgMailSelected.rPlan.ID.ToString() + "'")
            'For Each rPlanObj As dsPlan.planObjectRow In arrPlanObject
            '    Dim rObj As dsObject.tblObjectRow = compObjectReadObj.getObjectRow(rPlanObj.IDObject, compObject.eTypSelObj.ID)
            '    'Dim rObjAdr As dsObject.tblAdressenRow = compObjectReadObj.getAdressenRow(rPlanObj.IDObject, dsObjectReadObj, compObject.eTypSelAdr.idObject)
            '    Dim nodeTree As Infragistics.Win.UltraWinTree.UltraTreeNode = Me.treeObjects.Nodes.Add(rObj.ID.ToString, rObj.Name)
            '    nodeTree.Tag = rObj
            'Next

            'Me.loadAttachments(cTgMailSelected.cMessage1.emailChili, rUserAccount.OutlookWebAPI, cTgMailSelected)
            'Me.doDetailEMail(message)

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.loadMail: " + ex.ToString())
        End Try
    End Sub

    Public Sub showBody(ByRef txt As String, ByRef typBody As TXTextControl.StreamType,
                        ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow)
        Try
            'contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)

            'Dim sTxt As String = Me.genMain.ByteToString(plainTextPart.Body)
            'Me.ContTxtEditor1.showText(txt, typBody, True, TXTextControl.ViewMode.PageView)
            'Me.setWebBrowser(txt)

            Dim statButt As Infragistics.Win.UltraWinToolbars.StateButtonTool
            If Me.HtmlToolStripMenuItem.Checked Then
                If typBody = TXTextControl.StreamType.HTMLFormat Then
                    Me.lblTextIsHtmJN.Text = "Html"
                    'Me.winFormHtmlEditor1.DocumentHtml = txt

                    'statButt = Me.UltraToolbarsManagerBody.Tools("statButtHtml")
                    'statButt.Checked = True
                    'Me.UltraTabControlMail.SelectedTab = Me.UltraTabControlMail.Tabs(0)

                ElseIf typBody = TXTextControl.StreamType.PlainText Then
                    If clPlan.checkIfTextIsHtmlText(txt.Trim()) Then
                        Me.lblTextIsHtmJN.Text = "Html"
                        'Me.winFormHtmlEditor1.DocumentHtml = txt
                    Else
                        Me.lblTextIsHtmJN.Text = "Text"
                        'Me.winFormHtmlEditor1.Content.SetBodyText(txt)
                    End If

                    'statButt = Me.UltraToolbarsManagerBody.Tools("statButtText")
                    'statButt.Checked = True
                    'Me.UltraTabControlMail.SelectedTab = Me.UltraTabControlMail.Tabs(1)

                End If
            End If

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.showBody: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadAttachments(ByRef isOutlookWebAPI As Boolean,
                               ByRef cTgMailSelected As clPlan.cTgMail)
        Try
            Me.treeAttachments.Nodes.Clear()
            Dim funct1 As New QS2.functions.vb.functOld()

            For Each Attachment As clPlan.cTgAttachment In cTgMailSelected.lstAttachments
                Dim newNode As Infragistics.Win.UltraWinTree.UltraTreeNode = Me.treeAttachments.Nodes.Add(System.Guid.NewGuid().ToString(), Attachment.fileName.Trim())
                Dim cNodeTree As New cNodeTree()
                cNodeTree.Attachment = Attachment
                cNodeTree.Attachment = Attachment
                newNode.Tag = cNodeTree
            Next

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.loadAttachments: " + ex.ToString())
        End Try
    End Sub
    Public Sub openAttachment(ByRef NodeTree As cNodeTree, ByRef isOutlookWebAPI As Boolean, _
                              ByRef Attachment As clPlan.cTgAttachment)
        Try
            Dim funct1 As New QS2.functions.vb.functOld()
            Dim clFolder1 As New UI()

            Dim DirName As String = clFolder1.selectFolder()
            If Not gen.IsNull(DirName) Then
                Dim sFilename As String = DirName + "\" + Attachment.fileName + Attachment.typeFile
                If funct1.saveFileFromBytes(sFilename, Attachment.byt, False) Then
                    clFolder1.openFile(sFilename, Attachment.typeFile, False, Nothing, False, True, False)
                End If
                'MsgBox(compAutoUI.getRes("EntrySaved"), MsgBoxStyle.Information, "Save")
            End If

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.openAttachment: " + ex.ToString())
        End Try
    End Sub

    Public Sub deleteEMail(ByVal Nr As Integer, ByVal keyNode As String)
        Try
            If doUI.doMessageBox3("DoYouWantToDeleteTheEMailsReallyFromTheServer", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                'Me.pop3Client.DeleteMessage(Nr)
                Me.treeListMails.Nodes(keyNode).Remove()
                'Me.readMailsFromServer()
            End If

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.deleteEMail: " + ex.ToString())
        End Try
    End Sub

    Public Sub clearUIEMail()
        Try
            Me.txtFrom.Text = ""
            Me.txtTo.Text = ""
            Me.txtCc.Text = ""
            Me.txtBcc.Text = ""

            Me.txtSubject.Text = ""
            Me.ContTxtEditor1.clearForm()

            Me.lblVonDatum.Text = ""
            'contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
            Me.SplitContainerMail.Panel2Collapsed = False

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.clearUIEMail: " + ex.ToString())
        End Try
    End Sub
    Public Sub EMailsÜbernehmen()
        Try
            Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = Me.ContComboUserAccounts1.getSelectedUserAccount(False)
            If rUserAccount Is Nothing Then
                Me.ContComboUserAccounts1.cboComboBoxUsrAccounts.Focus()
                doUI.doMessageBox2("NoAccountSelected", "", "!")
                Exit Sub
            End If

            If doUI.doMessageBox3("DoYouRealyWantToImportTheEMails", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                Dim dsPlanUpdate As New dsPlan()
                Dim compPlanUpdate As New compPlan()

                compPlanUpdate.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlanUpdate)
                compPlanUpdate.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.id, dsPlanUpdate)
                compPlanUpdate.getPlanObject(System.Guid.NewGuid(), compPlan.eTypSelPlanObject.id, dsPlanUpdate)

                Dim firstReceiveDate As Date = Nothing
                Dim anzImported As Integer = 0
                For Each actNode As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.treeListMails.Nodes
                    If actNode.CheckedState = CheckState.Checked Then
                        Dim cTgMailSelected As clPlan.cTgMail = actNode.Tag
                        Dim rNewPlan As dsPlan.planRow = compPlanUpdate.getNewRowPlan(dsPlanUpdate)
                        rNewPlan.ItemArray = cTgMailSelected.rPlan.ItemArray
                        rNewPlan.ID = System.Guid.NewGuid()
                        rNewPlan.IDKlinik = PMDS.Global.ENV.IDKlinik

                        Dim arrPlanObject As dsPlan.planObjectRow() = Me.dsPlanReaded.planObject.Select(Me.dsPlanReaded.planObject.IDPlanColumn.ColumnName + "='" + cTgMailSelected.rPlan.ID.ToString() + "'")
                        For Each rPlanObj As dsPlan.planObjectRow In arrPlanObject
                            Dim rNewPlanObject As dsPlan.planObjectRow = compPlan1.getNewRowPlanObject(dsPlanUpdate.planObject)
                            rNewPlanObject.ItemArray = rPlanObj.ItemArray
                            rNewPlanObject.ID = System.Guid.NewGuid()
                            rNewPlanObject.IDPlan = rNewPlan.ID
                        Next

                        Dim arrPlanAnhang As dsPlan.planAnhangRow() = Me.dsPlanReaded.planAnhang.Select(Me.dsPlanReaded.planAnhang.IDPlanColumn.ColumnName + "='" + cTgMailSelected.rPlan.ID.ToString() + "'")
                        For Each rPlanObj As dsPlan.planAnhangRow In arrPlanAnhang
                            Dim rNewPlanAnhang As dsPlan.planAnhangRow = dsPlanUpdate.planAnhang.NewRow()
                            rNewPlanAnhang.ItemArray = rPlanObj.ItemArray
                            rNewPlanAnhang.ID = System.Guid.NewGuid()
                            rNewPlanAnhang.IDPlan = rNewPlan.ID
                            dsPlanUpdate.planAnhang.Rows.Add(rNewPlanAnhang)
                        Next

                        If anzImported = 0 Then
                            firstReceiveDate = rNewPlan.empfangenAm
                        End If
                        anzImported += 1
                    End If
                Next

                If anzImported > 0 Then
                    compPlanUpdate.daPlan.Update(dsPlanUpdate.plan)
                    compPlanUpdate.daPlanObject.Update(dsPlanUpdate.planObject)
                    compPlanUpdate.daPlanAnhang.Update(dsPlanUpdate.planAnhang)
                End If

                Dim compUserAccounts1 As New compUserAccounts()
                If anzImported > 0 Then
                    compUserAccounts1.updatelastReceive(rUserAccount.ID, firstReceiveDate)
                End If
                MsgBox(doUI.getRes("EntriesAreSaved"), MsgBoxStyle.Information, "Import")
            End If

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.EMailsÜbernehmen: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnReadMails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadMails.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.readMailsFromServer()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnÜbernehmen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportEMails.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.EMailsÜbernehmen()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub treeListMails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles treeListMails.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.treeListMails.Focused Then
                If Not Me.treeListMails.ActiveNode Is Nothing Then
                    Dim cTgMailSelected As clPlan.cTgMail = Me.treeListMails.ActiveNode.Tag
                    Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = Me.ContComboUserAccounts1.getSelectedUserAccount(False)
                    If rUserAccount Is Nothing Then
                        Me.ContComboUserAccounts1.cboComboBoxUsrAccounts.Focus()
                        doUI.doMessageBox2("NoAccountSelected", "", "!")
                        Exit Sub
                    End If

                    If Me.HtmlToolStripMenuItem.Checked Then
                        If cTgMailSelected.tagValue.GetType().ToString().ToLower() = ("System.Int32").ToString().ToLower() Then
                            Dim msgNr As Integer = System.Convert.ToInt32(cTgMailSelected.tagValue)
                            Me.loadMail(msgNr, cTgMailSelected, rUserAccount)
                        End If
                    Else
                        Dim msgNr As Integer = System.Convert.ToInt32(cTgMailSelected.tagValue)
                        Me.loadMail(msgNr, cTgMailSelected, rUserAccount)
                    End If
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub treeListMails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles treeListMails.DoubleClick
        Try

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        Try
            clPlan.abortIMport = True
            cOutlookWebAPI.abort = True

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub SichernUnterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SichernUnterToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.treeAttachments.Focused Then
                If Not Me.treeAttachments.ActiveNode Is Nothing Then
                    Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = Me.ContComboUserAccounts1.getSelectedUserAccount(False)
                    If rUserAccount Is Nothing Then
                        Me.ContComboUserAccounts1.cboComboBoxUsrAccounts.Focus()
                        doUI.doMessageBox2("NoAccountSelected", "", "!")
                        Exit Sub
                    End If

                    Dim NodeTree As cNodeTree = Me.treeAttachments.ActiveNode.Tag
                    Me.openAttachment(NodeTree, rUserAccount.OutlookWebAPI, NodeTree.Attachment)
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.treeListMails.Focused Then
                If Not Me.treeListMails.ActiveNode Is Nothing Then
                    Dim msgNr As Integer = Me.treeListMails.ActiveNode.Tag
                    Me.deleteEMail(msgNr, Me.treeListMails.ActiveNode.Key)
                End If
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub infoSmtpEMail()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.treeListMails.Focused Then
                If Not Me.treeListMails.ActiveNode Is Nothing Then
                    Dim clTgSelected As clPlan.cTgMail = Me.treeListMails.ActiveNode.Tag
                    'Dim dsMIME As DataSet = Me.clPlan1.getDetailMIMEEMail(clTgSelected.cMessage1.messagexy, clTgSelected.MessageIDAct)
                    'Dim frmDS As New ITSCont.ui.Sitemap.frmProtDS()
                    'frmDS.typ = ITSCont.ui.Sitemap.frmProtDS.eTyp.protokoll
                    'frmDS._dbProt = dsMIME
                    'frmDS.addLogDS(False, False)
                    'frmDS.loadTable("EMailMIME")
                    'frmDS.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
                    'frmDS.Show()
                    MessageBox.Show("No Mime-information exists!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.infoSmtpEMail: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub HtmlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HtmlToolStripMenuItem.Click
        Try
            Me.UltraTabControlMail.SelectedTab = Me.UltraTabControlMail.Tabs(1)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InfoEMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoEMailToolStripMenuItem.Click
        Try
            Me.infoSmtpEMail()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.wechselnZu(False)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub InNeuemTabÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InNeuemTabÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.wechselnZu(True)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub wechselnZu(ByVal neuesTab As Boolean)
        Try
            'If Not Me.treeObjects.ActiveNode Is Nothing Then               'lthNotPossibleAK
            '    Dim rObj As dsObject.tblObjectRow = Me.treeObjects.ActiveNode.Tag
            '    Me.appManag1.LoadObject(rObj.ID, neuesTab)
            'Else
            '    ITSCont.core.SystemDb.doUI.doMessageBox("NoEntrySelected", "", "!")
            'End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.mainWindow.Close()

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub alleKeine(ByVal bOn As System.Windows.Forms.CheckState)
        Try
            For Each nod As Infragistics.Win.UltraWinTree.UltraTreeNode In Me.treeListMails.Nodes
                nod.CheckedState = bOn
            Next

        Catch ex As Exception
            Throw New Exception("contMailInputSrv.alleKeine: " + ex.ToString())
        End Try
    End Sub
    Private Sub AllÜbernehmenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllÜbernehmenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.alleKeine(CheckState.Checked)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub KeineÜbernehmenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineÜbernehmenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.alleKeine(CheckState.Unchecked)

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ProtokollMarkierungEMailScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProtokollMarkierungEMailScanToolStripMenuItem.Click
        Try
            clPlan.protWindowMarkOn = Me.ProtokollMarkierungEMailScanToolStripMenuItem.Checked

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
