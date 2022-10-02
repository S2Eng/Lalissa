Imports Microsoft.Exchange.WebServices.Data
Imports System.Net
Imports System.Collections.Generic
Imports System.Collections.ObjectModel



Public Class cOutlookWebAPI


    Public delDoInfoUI As onDoInfoUI
    Public Delegate Sub onDoInfoUI(ByVal logText As String, isException As Boolean, SendException As Boolean)

    Public gen As New General()

    Public compPlanRead2 As New compPlan()
    Public compUserAccounts1 As New compUserAccounts()

    Public Shared abort As Boolean = False

    Public Shared dateExit As New Date(2015, 3, 4, 11, 0, 0)
    'Public Shared dateExit As New Date(1900, 1, 1, 0, 0, 0)
    Public NoNameOnExchange As String = "[No Name in Exchange-Server]"

    Public Shared lastUpdateCategories As Date = Now
    Public Shared nextUpdateCategories As Date = Now

    Public database As New db()








    'Public Function readFoldersOutlook(ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                                   ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                                                   ByRef doSave As Boolean,
    '                                                   ByVal abortIfEMailIsInDB As Boolean,
    '                                                   ByRef maxSizeEMailKB As Integer, ByRef EMailsVomServerLöschen As Boolean,
    '                                                   ByRef checkLastRecieveDate As Boolean,
    '                                                   ByRef protokoll As String, ByRef protokollErr As String, ByVal doExept As Boolean,
    '                                                   ByRef InfoMailService As clPlan.cInfoMailService,
    '                                                   ByRef EMailAccount As clPlan.cEMailAccount, ByRef Url As String,
    '                                                   ByRef tree As Infragistics.Win.UltraWinTree.UltraTree, ByRef dNow As Date,
    '                                                   ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar,
    '                                                   ByRef iFoundItems As Integer, ByRef iFoundFolders As Integer,
    '                                                   ByRef sInfoAccountsScanned As String, ByRef checkEmptyItems As Boolean,
    '                                                   ByRef FromUI As Boolean) As Boolean
    '    Dim sInfoAccount As String = ""
    '    Try
    '        dsPlan1.Clear()
    '        compPlan1.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlan1)
    '        compPlan1.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.id, dsPlan1)
    '        compPlan1.getPlanObject(System.Guid.NewGuid(), compPlan.eTypSelPlanObject.id, dsPlan1)

    '        messages = New System.Collections.Generic.List(Of clPlan.cMessage)

    '        Dim txtStart As String = "E-Mail-Scan Account '" + EMailAccount.rUserAccount.Name + "' startet at: '" + Now.ToString() + "'" + vbNewLine
    '        sInfoAccount = "E-Mail-Scan Inbox activ ..." + vbNewLine +
    '                                         "    Account: '" + EMailAccount.rUserAccount.Name + "'" + vbNewLine +
    '                                         "    E-Mail-Adress: '" + EMailAccount.rUserAccount.AdrFrom + "'" + vbNewLine +
    '                                         "    User: '" + EMailAccount.rUserAccount.Usr + "'" + vbNewLine +
    '                                         "    Server: '" + EMailAccount.rUserAccount.Server + "'" + vbNewLine +
    '                                         "    User-Authentification: '" + EMailAccount.rUserAccount.UsrAuthentication + "'"

    '        If Not Me.delDoInfoUI Is Nothing Then
    '            If clPlan.protWindowNormalOn Then
    '                Me.delDoInfoUI.Invoke(txtStart + vbNewLine + sInfoAccount, False, False)
    '            End If
    '        End If

    '        Dim UsrAuthenticationTmp As String = Me.getUserForOutlookWebAPI(EMailAccount.rUserAccount)
    '        Dim es As New ExchangeService(ExchangeVersion.Exchange2013_SP1)
    '        es.Url = New Uri(Url)
    '        es.Credentials = New System.Net.NetworkCredential(UsrAuthenticationTmp.Trim(), EMailAccount.rUserAccount.PwdAuthentication.Trim())
    '        'es.Url = New Uri("https://exchange.world4you.com/EWS/Exchange.asmx")
    '        'es.Url = New Uri("https://dc-srv/EWS/Exchange.asmx")
    '        'es.Url = New Uri("http://192.168.0.100/EWS/Exchange.asmx")
    '        'es.Credentials = New NetworkCredential("hl@s2-engineering.com", "xy")
    '        'es.AutodiscoverUrl("hl@s2-engineering.com")

    '        Dim Size As Integer = 8000
    '        Dim datLastReceived As New Date(1900, 1, 1, 0, 0, 0)
    '        If Not EMailAccount.rUserAccount.IslastReceiveNull() Then
    '            datLastReceived = EMailAccount.rUserAccount.lastReceive
    '        End If

    '        If Not General.ServicesTestmodus Then
    '            dsPlan1.Clear()
    '            Me.readFolder(Size, iFoundItems, iFoundFolders, es, WellKnownFolderName.Inbox, EMailAccount.rUserAccount, dsPlan1, compPlan1, messages,
    '                            abortIfEMailIsInDB, maxSizeEMailKB, False, checkLastRecieveDate, protokoll, protokollErr, doExept, doSave,
    '                            InfoMailService, datLastReceived, tree, dNow, bar, checkEmptyItems, WellKnownFolderName.Inbox)
    '            dsPlan1.Clear()
    '        End If

    '        If General.ImportTasks And (Not FromUI) And (Not checkEmptyItems) Then
    '            If Not General.ServicesTestmodus Then
    '                dsPlan1.Clear()
    '                Me.readFolder(Size, iFoundItems, iFoundFolders, es, WellKnownFolderName.Calendar, EMailAccount.rUserAccount, dsPlan1, compPlan1, messages,
    '                                abortIfEMailIsInDB, maxSizeEMailKB, False, checkLastRecieveDate, protokoll, protokollErr, doExept, doSave,
    '                                InfoMailService, datLastReceived, tree, dNow, bar, False, WellKnownFolderName.Calendar)
    '                dsPlan1.Clear()

    '                Me.readFolder(Size, iFoundItems, iFoundFolders, es, WellKnownFolderName.Tasks, EMailAccount.rUserAccount, dsPlan1, compPlan1, messages,
    '                                abortIfEMailIsInDB, maxSizeEMailKB, False, checkLastRecieveDate, protokoll, protokollErr, doExept, doSave,
    '                                InfoMailService, datLastReceived, tree, dNow, bar, False, WellKnownFolderName.Tasks)
    '                dsPlan1.Clear()

    '                Me.readFolder(Size, iFoundItems, iFoundFolders, es, WellKnownFolderName.Contacts, EMailAccount.rUserAccount, dsPlan1, compPlan1, messages,
    '                                abortIfEMailIsInDB, maxSizeEMailKB, False, checkLastRecieveDate, protokoll, protokollErr, doExept, doSave,
    '                                InfoMailService, datLastReceived, tree, dNow, bar, False, WellKnownFolderName.Contacts)
    '                dsPlan1.Clear()

    '                'Dim folders As New Collection(Of Microsoft.Exchange.WebServices.Data.Folder)
    '                ''Get the root Contacts folder And load all properties. This results in a GetFolder operation call to EWS.
    '                'Dim rootContactFolder2 As Object = ContactsFolder.Bind(es, WellKnownFolderName.Root)
    '                'Dim rootContactFolder As ContactsFolder = ContactsFolder.Bind(es, WellKnownFolderName.Root)
    '                'folders.Add(rootContactFolder)

    '                'Dim initialFolderSearchOffset As Integer = 0
    '                'Dim folderSearchPageSize As Integer = 100
    '                'Dim AreMoreFolders As Boolean = True
    '                'Dim FolderView As New FolderView(folderSearchPageSize, initialFolderSearchOffset)
    '                'FolderView.Traversal = FolderTraversal.Deep
    '                'FolderView.PropertySet = New PropertySet(BasePropertySet.IdOnly)

    '                'While AreMoreFolders
    '                '    '// Find all the child folders of the default Contacts folder. This results in a FindFolder operation call to EWS.
    '                '    Dim childrenOfContactsFolderResults As FindFoldersResults = rootContactFolder.FindFolders(FolderView)
    '                '    If FolderView.Offset = 0 Then
    '                '        Dim sFoundChildFolder As String = "Found {0} child folders of the default Contacts folder." + childrenOfContactsFolderResults.TotalCount.ToString()
    '                '    End If
    '                '    For Each f As Folder In childrenOfContactsFolderResults.Folders
    '                '        Dim contactFolder As ContactsFolder = f
    '                '        '// Loads all the properties for the folder. This results in a GetFolder operation call to EWS.
    '                '        contactFolder.Load()
    '                '        Dim Info As String = "Loaded a folder named {0} and added it to the collection of contact folders." + contactFolder.DisplayName
    '                '        '// Add the folder to the collection of contact folders.
    '                '        folders.Add(contactFolder)

    '                '    Next
    '                '    '// Turn off paged searches if there are no more folders to return.
    '                '    If childrenOfContactsFolderResults.MoreAvailable = False Then
    '                '        AreMoreFolders = False
    '                '    Else
    '                '        FolderView.Offset = FolderView.Offset + folderSearchPageSize
    '                '    End If
    '                'End While
    '            End If
    '            If Not checkEmptyItems And General.SyncContacts Then
    '                dsPlan1.Clear()
    '                Me.syncContactsToITSCont(Size, iFoundItems, iFoundFolders, es, WellKnownFolderName.Contacts, EMailAccount.rUserAccount, dsPlan1, compPlan1, messages,
    '                                abortIfEMailIsInDB, maxSizeEMailKB, False, checkLastRecieveDate, protokoll, protokollErr, doExept, doSave,
    '                                InfoMailService, datLastReceived, tree, dNow, bar, False)
    '                dsPlan1.Clear()
    '            End If

    '            If Not General.ServicesTestmodus And (Not checkEmptyItems) Then
    '                'If dNow >= cOutlookWebAPI.nextUpdateCategories Then
    '                'Me.UpdateCategoriesFromExchangeToDBWebCall(es, dNow, EMailAccount.rUserAccount)
    '                '    cOutlookWebAPI.lastUpdateCategories = Now
    '                '    cOutlookWebAPI.nextUpdateCategories = cOutlookWebAPI.lastUpdateCategories.AddMinutes(10)

    '                '    'Me.UpdateCategoriesFromExchangeToDB(es, WellKnownFolderName.Calendar, dNow)
    '                '    'Me.UpdateCategoriesFromExchangeToDB(es, WellKnownFolderName.Tasks, dNow)
    '                '    'Me.UpdateCategoriesFromExchangeToDB(es, WellKnownFolderName.Contacts, dNow)
    '                'End If
    '            End If
    '        End If

    '        General.iAccountsSucessfullScanned += 1
    '        If doSave Then
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                If clPlan.protWindowNormalOn Then
    '                    Dim txtEnd As String = "Scan für Account '" + EMailAccount.rUserAccount.Name + "' ended at: '" + Now.ToString() + "'"
    '                    Me.delDoInfoUI.Invoke(txtEnd + vbNewLine + sInfoAccount, False, False)
    '                End If
    '            End If
    '        End If

    '        If iFoundItems > 0 Then
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                If clPlan.protWindowNormalOn Then
    '                    Dim txtEnd As String = "Note: " + iFoundItems.ToString() + " new Items/s received und imported for Account " + EMailAccount.rUserAccount.Name + "'"
    '                    Me.delDoInfoUI.Invoke(txtEnd + vbNewLine + sInfoAccount, False, False)
    '                End If
    '            End If
    '        End If

    '        Dim dEnd As Date = Now
    '        sInfoAccountsScanned += "                Adress: " + EMailAccount.rUserAccount.Name.Trim() + ", Server: " + General.UrlOutlookWebAPI.Trim() + "(by OutlookAPI, Start: " + dNow.ToString() + ", End: " + dEnd.ToString() + ")" + vbNewLine

    '        Return True

    '    Catch ex As Exception
    '        If Not Me.delDoInfoUI Is Nothing Then
    '            Me.delDoInfoUI.Invoke("Error Scan for Account '" + EMailAccount.rUserAccount.Name + "'!" + vbNewLine + sInfoAccount + vbNewLine + ex.ToString, False, False)
    '        End If
    '        If doExept Then
    '            gen.GetEcxeptionGeneral(ex)
    '        Else
    '            General.iCounterExceptionsToSend += 1
    '            General.ExceptionsToSend += General.iCounterExceptionsToSend.ToString() + ". Exception" + vbNewLine + sInfoAccount + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '            'protokollErr += ex.ToString() + vbNewLine + vbNewLine
    '            'ITSCont.core.SystemDb.General.SendSystemErrorPerEMailToServiceCenter(protokollErr.ToString(), General.eTypeEMailMessage.E_Mail_SERVER, True, False, True, True, False)
    '        End If
    '    End Try
    'End Function
    'Public Function getUserForOutlookWebAPI(ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow) As String
    '    Try
    '        Dim UsrAuthenticationTmp As String = ""
    '        If General.FullUserAuthenticationForOutlookWebAPILogIn Then
    '            UsrAuthenticationTmp = rUserAccount.UsrAuthentication.Trim()
    '        Else
    '            If rUserAccount.UsrAuthentication.Trim().Contains("@") Then
    '                Dim iPosA As Integer = 0
    '                iPosA = rUserAccount.UsrAuthentication.Trim().IndexOf("@")
    '                UsrAuthenticationTmp = rUserAccount.UsrAuthentication.Trim().Substring(0, iPosA)
    '            Else
    '                UsrAuthenticationTmp = rUserAccount.UsrAuthentication.Trim()
    '            End If
    '        End If

    '        Return UsrAuthenticationTmp.Trim()

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.getUserForOutlookWebAPI: " + ex.ToString())
    '    End Try
    'End Function


    'Public Function readFolder(ByRef Size As Integer, ByRef iFoundItems As Integer, ByRef iFoundFolders As Integer,
    '                            ByRef es As ExchangeService, ByRef TypeFolder As WellKnownFolderName,
    '                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                            ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                            ByRef abortIfEMailIsInDB As Boolean,
    '                            ByRef maxSizteEMailKB As Integer, ByRef EMailsVomServerLöschen As Boolean,
    '                            ByRef checkLastRecieve As Boolean,
    '                            ByRef protokoll As String, ByRef protokollErr As String, ByRef doExept As Boolean,
    '                            ByRef doSave As Boolean,
    '                            ByRef InfoMailService As clPlan.cInfoMailService, ByRef datLastReceived As Date,
    '                            ByRef tree As Infragistics.Win.UltraWinTree.UltraTree, ByRef dNow As Date,
    '                            ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar, ByRef checkEmptyItems As Boolean,
    '                            ByRef TypeSearch As WellKnownFolderName) As Boolean
    '    Dim InfoExcept As String = rUserAccount.UsrAuthentication.Trim()
    '    Try
    '        Dim viewFolders As New FolderView(Size)
    '        viewFolders.Traversal = FolderTraversal.Deep
    '        'Dim returnValue As FindFoldersResults = es.FindFolders(parentFolderName, viewFolders)
    '        Dim rootFolder As Folder = Folder.Bind(es, TypeFolder)
    '        Dim FoldersFound As FindFoldersResults = rootFolder.FindFolders(viewFolders)

    '        Me.findItemsInFolder(Nothing, Size, iFoundItems, es, TypeFolder, rUserAccount, dsPlan1, compPlan1,
    '                            messages, maxSizteEMailKB, EMailsVomServerLöschen, checkLastRecieve,
    '                            protokoll, protokollErr, doExept, doSave, datLastReceived,
    '                            InfoMailService, True, abortIfEMailIsInDB, tree, dNow, bar, InfoExcept, checkEmptyItems, TypeSearch)

    '        If cOutlookWebAPI.abort Then
    '            Return False
    '        End If

    '        Me.findFolders_Rek(rootFolder, Size, iFoundItems, iFoundFolders, es, TypeFolder, rUserAccount, dsPlan1, compPlan1, messages,
    '                            maxSizteEMailKB, EMailsVomServerLöschen, checkLastRecieve, protokoll, protokollErr, doExept,
    '                            doSave, datLastReceived, InfoMailService, abortIfEMailIsInDB, tree, dNow, bar, InfoExcept, checkEmptyItems, TypeSearch)

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.readFolder: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function

    'Public Sub findFolders_Rek(ByRef rootFolder As Folder, ByRef Size As Integer, ByRef iFoundItems As Integer, ByRef iFoundFolders As Integer,
    '                            ByRef es As ExchangeService, ByRef TypeFolder As WellKnownFolderName,
    '                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                            ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                            ByRef maxSizteEMailKB As Integer, ByRef EMailsVomServerLöschen As Boolean,
    '                            ByRef checkLastRecieve As Boolean,
    '                            ByRef protokoll As String, ByRef protokollErr As String, ByRef doExept As Boolean,
    '                            ByRef doSave As Boolean,
    '                            ByRef datLastReceived As Date,
    '                            ByRef InfoMailService As clPlan.cInfoMailService, ByRef abortIfEMailIsInDB As Boolean,
    '                            ByRef tree As Infragistics.Win.UltraWinTree.UltraTree, ByRef dNow As Date,
    '                            ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar,
    '                            ByRef InfoExcept As String, ByRef checkEmptyItems As Boolean,
    '                            ByRef TypeSearch As WellKnownFolderName)
    '    Try
    '        Dim viewFolders As New FolderView(Size)
    '        viewFolders.Traversal = FolderTraversal.Deep
    '        'Dim returnValue As FindFoldersResults = es.FindFolders(parentFolderName, viewFolders)
    '        Dim FoldersFound As FindFoldersResults = rootFolder.FindFolders(viewFolders)
    '        For Each folder As Microsoft.Exchange.WebServices.Data.Folder In FoldersFound
    '            Try
    '                'If (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.VoiceMail.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ToDoSearch.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.SyncIssues.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ServerFailures.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.SentItems.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.SearchFolders.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.RecoverableItemsVersions.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.RecoverableItemsRoot.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.RecoverableItemsPurges.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.RecoverableItemsDeletions.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.RecipientCache.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.Outbox.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.LocalFailures.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.Drafts.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.DeletedItems.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ConversationHistory.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.Conflicts.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.Calendar.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveRoot.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveRecoverableItemsVersions.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveRecoverableItemsRoot.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveRecoverableItemsPurges.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveRecoverableItemsDeletions.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveMsgFolderRoot.ToString().Trim().ToLower()) And _
    '                '   (Not folder.DisplayName.Trim().ToLower().StartsWith(("Spooler").ToString().Trim().ToLower())) And _
    '                '   (Not folder.DisplayName.Trim().ToLower().StartsWith(("System").ToString().Trim().ToLower())) And _
    '                '       (Not folder.DisplayName.Trim().ToLower().StartsWith(("System").ToString().Trim().ToLower())) And _
    '                '   (Not folder.DisplayName.Trim().ToLower() = WellKnownFolderName.ArchiveDeletedItems.ToString().Trim().ToLower()) Then

    '                folder.Load()

    '                'If folder.EffectiveRights = EffectiveRights.Modify Or folder.EffectiveRights = EffectiveRights.Read Then
    '                'Dim oMsg As Microsoft.Office.Interop.Outlook.MailItem = oItems.Item(i)
    '                Dim folderNameTmp As String = Me.IsNull(folder.DisplayName, False, "DisplayName")
    '                If folderNameTmp.Trim() = "" Then
    '                    folderNameTmp = "No name"
    '                End If
    '                Dim ConversationIDFolderTmp As String = folder.Id.UniqueId.Trim()

    '                iFoundFolders += 1

    '                Me.findFolders_Rek(folder, Size, iFoundItems, iFoundFolders, es, TypeFolder, rUserAccount, dsPlan1, compPlan1, messages,
    '                                        maxSizteEMailKB, EMailsVomServerLöschen, checkLastRecieve, protokoll, protokollErr, doExept,
    '                                        doSave, datLastReceived, InfoMailService, abortIfEMailIsInDB, tree, dNow, bar, InfoExcept, checkEmptyItems,
    '                                        TypeSearch)

    '                Me.findItemsInFolder(folder, Size, iFoundItems, es, TypeFolder, rUserAccount, dsPlan1, compPlan1,
    '                                        messages, maxSizteEMailKB, EMailsVomServerLöschen, checkLastRecieve,
    '                                        protokoll, protokollErr, doExept, doSave, datLastReceived,
    '                                        InfoMailService, False, abortIfEMailIsInDB, tree, dNow, bar, InfoExcept, checkEmptyItems,
    '                                        TypeSearch)
    '                'End If
    '                'End If


    '            Catch ex2 As Exception
    '                Dim sExcept As String = "cOutlookWebAPI.findFolders_Rek: Account " + InfoExcept.Trim() + ", Foldername: " + folder.DisplayName.Trim() + ": " + vbNewLine + ex2.ToString() + vbNewLine + vbNewLine
    '                Throw New Exception(sExcept)
    '            End Try
    '        Next

    '    Catch ex As Exception
    '        Dim sExcept As String = "cOutlookWebAPI.findFolders_Rek: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '        Throw New Exception(sExcept)
    '    End Try
    'End Sub
    'Public Function findItemsInFolder(folderParent As Folder,
    '                              ByRef Size As Integer, ByRef iFoundItems As Integer,
    '                              ByRef es As ExchangeService, ByRef TypeFolder As WellKnownFolderName,
    '                              ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                              ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                              ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                              ByRef maxSizteEMailKB As Integer, ByRef EMailsVomServerLöschen As Boolean,
    '                              ByRef checkLastRecieve As Boolean,
    '                              ByRef protokoll As String, ByRef protokollErr As String, ByRef doExept As Boolean,
    '                              ByRef doSave As Boolean,
    '                              ByRef datLastReceived As Date,
    '                              ByRef InfoMailService As clPlan.cInfoMailService, ByRef IsRoot As Boolean, ByRef abortIfEMailIsInDB As Boolean,
    '                              ByRef tree As Infragistics.Win.UltraWinTree.UltraTree, ByRef dNow As Date,
    '                              ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar,
    '                              ByRef InfoExcept As String, ByRef checkEmptyItems As Boolean,
    '                              ByRef TypeSearch As WellKnownFolderName) As Boolean
    '    Dim SubjectTmp As String = ""
    '    Dim functionMarker As String = ""
    '    Dim dReceived As Date = Nothing
    '    Try
    '        Dim SearchFilterCollection As New List(Of SearchFilter)
    '        'SearchFilterCollection.Add(New SearchFilter.ContainsSubstring(ItemSchema.Subject, "Test"))
    '        'SearchFilterCollection.Add(New SearchFilter.ContainsSubstring(ItemSchema.Body, "homecoming"))
    '        SearchFilterCollection.Add(New SearchFilter.ContainsSubstring(ItemSchema.DateTimeReceived, cOutlookWebAPI.dateExit))
    '        ' Create the search filter.
    '        Dim searchFilter As SearchFilter = New SearchFilter.SearchFilterCollection(LogicalOperator.And, SearchFilterCollection.ToArray())
    '        ' Create a view with a page size of 50.
    '        Dim view As New ItemView(999999000)
    '        view.Traversal = ItemTraversal.Associated

    '        'Identify the Subject and DateTimeReceived properties to return.
    '        'Indicate that the base property will be the item identifier

    '        'view.PropertySet = (New PropertySet(BasePropertySet.FirstClassProperties, ItemSchema.DateTimeReceived))
    '        ' Order the search results by the DateTimeReceived in descending order.

    '        If TypeSearch = WellKnownFolderName.Contacts Then
    '            view.OrderBy.Add(ItemSchema.DateTimeCreated, SortDirection.Descending)
    '        Else
    '            view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending)
    '        End If

    '        ' Set the traversal to shallow. (Shallow is the default option; other options are Associated and SoftDeleted.)
    '        view.Traversal = ItemTraversal.Shallow
    '        'es.LoadPropertiesForItems(findResults, itItemPropSet)

    '        ' Send the request to search the Inbox and get the results.
    '        'Dim findResults As FindItemsResults(Of Item) = es.FindItems(WellKnownFolderName.Inbox, searchFilter, view)
    '        Dim findResults As FindItemsResults(Of Item)
    '        If IsRoot Then
    '            findResults = es.FindItems(TypeFolder, view)
    '            'findResults = es.FindItems(TypeFolder, searchFilter, view)
    '        Else
    '            findResults = folderParent.FindItems(TypeFolder, view)
    '            'findResults = folderParent.FindItems(searchFilter, view)
    '        End If

    '        If checkEmptyItems Then
    '            Me.checkEmptyBodyEMails(es, rUserAccount, folderParent, TypeFolder, messages, protokoll, protokollErr,
    '                                    doExept, IsRoot, datLastReceived, InfoMailService, dNow, InfoExcept)

    '        Else
    '            If findResults.TotalCount > 0 Then
    '                functionMarker += "1;"
    '                'Dim itItemPropSet As PropertySet = New PropertySet(BasePropertySet.IdOnly,
    '                '                                                     ItemSchema.Attachments,
    '                '                                                     ItemSchema.Subject,
    '                '                                                     ItemSchema.Importance,
    '                '                                                     ItemSchema.DateTimeReceived,
    '                '                                                     ItemSchema.DateTimeSent,
    '                '                                                     ItemSchema.ItemClass,
    '                '                                                     ItemSchema.Size,
    '                '                                                     ItemSchema.Sensitivity,
    '                '                                                     EmailMessageSchema.From,
    '                '                                                     EmailMessageSchema.CcRecipients,
    '                '                                                     EmailMessageSchema.ToRecipients,
    '                '                                                     EmailMessageSchema.InternetMessageId,
    '                '                                                     ItemSchema.MimeContent)
    '                'es.LoadPropertiesForItems(findResults, itItemPropSet)

    '                If Not bar Is Nothing Then
    '                    bar.Value = 0
    '                    bar.Maximum = findResults.TotalCount
    '                    System.Windows.Forms.Application.DoEvents()
    '                End If
    '                Dim iCounterLocal As Integer = 0
    '                For Each obj As Microsoft.Exchange.WebServices.Data.Item In findResults
    '                    functionMarker = ""
    '                    If cOutlookWebAPI.abort Then
    '                        Return False
    '                    End If
    '                    If doSave Then
    '                        dsPlan1.Clear()
    '                        'If Not db.ConnITSCont.State = ConnectionState.Open Then
    '                        '    db1.Connect()
    '                        'End If
    '                        compPlan1.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlan1)
    '                        compPlan1.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.id, dsPlan1)
    '                        compPlan1.getPlanObject(System.Guid.NewGuid(), compPlan.eTypSelPlanObject.id, dsPlan1)
    '                    End If
    '                    If TypeSearch = WellKnownFolderName.Inbox Then
    '                        Try
    '                            If TypeOf obj Is Microsoft.Exchange.WebServices.Data.EmailMessage Then
    '                                Dim EMailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage = obj
    '                                Me.addUpdateMailsToITSCont(EMailMessage, es, tree, dsPlan1, compPlan1, doSave, EMailsVomServerLöschen, dNow, InfoMailService,
    '                                                            findResults, iCounterLocal, iFoundItems, maxSizteEMailKB, rUserAccount, bar,
    '                                                            SubjectTmp, functionMarker, dReceived, InfoExcept, folderParent, checkLastRecieve, datLastReceived,
    '                                                            abortIfEMailIsInDB, protokoll, protokollErr)
    '                            Else
    '                                Dim NoMail As Boolean = True
    '                            End If

    '                        Catch ex2 As Exception
    '                            Me.doException(doExept, functionMarker, SubjectTmp, dReceived, ex2, rUserAccount, "Items")
    '                        End Try

    '                    ElseIf TypeSearch = WellKnownFolderName.Contacts Then
    '                        If TypeOf obj Is Microsoft.Exchange.WebServices.Data.Contact Then
    '                            Try
    '                                Dim Contact As Microsoft.Exchange.WebServices.Data.Contact = obj
    '                                Contact.Load()
    '                                'Me.addUpdateContactToITSCont(protokoll, protokollErr, Contact, dNow, rUserAccount, SubjectTmp,
    '                                '                                functionMarker, dReceived, InfoExcept, checkLastRecieve,
    '                                '                                datLastReceived, abortIfEMailIsInDB)

    '                            Catch ex2 As Exception
    '                                Me.doException(doExept, functionMarker, SubjectTmp, dReceived, ex2, rUserAccount, "Contact")
    '                            End Try

    '                        ElseIf TypeOf obj Is Microsoft.Exchange.WebServices.Data.ContactGroup Then
    '                            Try
    '                                Dim ContactGroup As Microsoft.Exchange.WebServices.Data.ContactGroup = obj
    '                                ContactGroup.Load()
    '                                Dim DisplayNameTmp As String = "Contact-Group " + Me.IsNull(ContactGroup.DisplayName, False, "DisplayName")
    '                                Dim ConversationIDTmp = ContactGroup.ConversationId.UniqueId.ToString().Trim()

    '                                iFoundItems += 1
    '                                iCounterLocal += 1

    '                            Catch ex2 As Exception
    '                                Me.doException(doExept, functionMarker, SubjectTmp, dReceived, ex2, rUserAccount, "ContactGroup")
    '                            End Try
    '                        End If

    '                    ElseIf TypeSearch = WellKnownFolderName.Calendar Then
    '                        If TypeOf obj Is Microsoft.Exchange.WebServices.Data.Appointment Then
    '                            Try
    '                                Dim Appoinment As Microsoft.Exchange.WebServices.Data.Appointment = obj
    '                                Appoinment.Load()
    '                                Me.addUpdateCalendarToITSCont(Appoinment, es, TypeFolder, dsPlan1, compPlan1, doSave, EMailsVomServerLöschen, dNow, InfoMailService, findResults,
    '                                                                iCounterLocal, iFoundItems, maxSizteEMailKB, rUserAccount, SubjectTmp, functionMarker, dReceived,
    '                                                                InfoExcept, checkLastRecieve, datLastReceived, abortIfEMailIsInDB, protokoll, protokollErr)

    '                            Catch ex2 As Exception
    '                                Me.doException(doExept, functionMarker, SubjectTmp, dReceived, ex2, rUserAccount, "Appoinments")
    '                            End Try
    '                        End If

    '                    ElseIf TypeSearch = WellKnownFolderName.Tasks Then
    '                        If TypeOf obj Is Microsoft.Exchange.WebServices.Data.Task Then
    '                            Try
    '                                Dim Task As Microsoft.Exchange.WebServices.Data.Task = obj
    '                                Task.Load()
    '                                Me.addUpdateTasksToITSCont(Task, es, TypeFolder, dsPlan1, compPlan1, doSave, EMailsVomServerLöschen, dNow, InfoMailService, findResults,
    '                                                            iCounterLocal, iFoundItems, maxSizteEMailKB, rUserAccount, SubjectTmp, functionMarker, dReceived,
    '                                                            InfoExcept, checkLastRecieve, datLastReceived, abortIfEMailIsInDB, protokoll, protokollErr)



    '                            Catch ex2 As Exception
    '                                Me.doException(doExept, functionMarker, SubjectTmp, dReceived, ex2, rUserAccount, "Tasks")
    '                            End Try
    '                        End If

    '                    Else
    '                        Dim str As String = ""
    '                    End If
    '                Next
    '            End If
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        Dim sExcept As String = "cOutlookWebAPI.findItemsInFolder: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '        Throw New Exception(sExcept)
    '    End Try
    'End Function

    'Public Function addUpdateMailsToITSCont(ByRef EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage,
    '                                        ByRef es As ExchangeService,
    '                                        ByRef tree As Infragistics.Win.UltraWinTree.UltraTree,
    '                                        ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan, ByRef doSave As Boolean,
    '                                        ByRef EMailsVomServerLöschen As Boolean, ByRef dNow As Date,
    '                                        ByRef InfoMailService As clPlan.cInfoMailService,
    '                                        ByRef findResults As FindItemsResults(Of Item),
    '                                        ByRef iCounterLocal As Integer, ByRef iFoundItems As Integer, ByRef maxSizteEMailKB As Integer,
    '                                        ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                                        ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar,
    '                                        ByRef SubjectTmp As String, ByRef functionMarker As String, ByRef dReceived As Date,
    '                                        ByRef InfoExcept As String, ByRef folderParent As Folder,
    '                                        ByRef checkLastRecieve As Boolean, ByRef datLastReceived As Date,
    '                                        ByRef abortIfEMailIsInDB As Boolean, ByRef Protokoll As String, ByRef ProtokollErr As String) As Boolean
    '    Try
    '        dReceived = Nothing
    '        dReceived = Me.IsNull(EmailMessage.DateTimeReceived, False, "DateTimeReceived")
    '        SubjectTmp = ""
    '        SubjectTmp = Me.IsNull(EmailMessage.Subject, False, "Subject")

    '        'ATS-112-712_Arlt_Ulf_1800004     Stornogefahr PV-000-193
    '        'If SubjectTmp.Trim().ToLower().Contains(("Mahnung aufgehoben FLV").Trim().ToLower()) Then   'lthxy
    '        '    Dim str As String = ""
    '        'Else
    '        '    Continue For
    '        'End If

    '        If SubjectTmp.Trim() = "" Then
    '            SubjectTmp = "No Subject ..."
    '        End If
    '        If dReceived = Nothing Then
    '            Throw New Exception("EMailMessage.DateTimeReceived=Nothing for E-Mail '" + SubjectTmp.Trim() + "'!")
    '        End If
    '        functionMarker += "1;"
    '        If checkLastRecieve Then
    '            'If Not rUserAccount.IslastReceiveNull() Then
    '            Dim lastReceiveBack As Date = datLastReceived.AddDays(-8)     'datLastReceived.AddHours(-168)  'dNow.AddHours(-168)
    '            If dReceived <= lastReceiveBack Then
    '                functionMarker += "1.1;"
    '                Return False
    '            End If
    '            'End If
    '        End If
    '        If dReceived.Date < cOutlookWebAPI.dateExit.Date Then
    '            Return False
    '        End If
    '        functionMarker += "1.2;"

    '        Dim pSet1 As PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)
    '        EmailMessage.Load(pSet1)
    '        functionMarker += "1.3;"

    '        Dim AdressFrom As String = ""
    '        If Not EmailMessage.Sender Is Nothing Then
    '            AdressFrom = Me.IsNull(EmailMessage.Sender.Address, False, "Address")
    '        Else
    '            Dim txtErrAnhang As String = "Info: E-Mail '" + SubjectTmp + "' from '" + dReceived.ToString() + "' has no AdressFrom!"
    '            Me.addProtokoll(txtErrAnhang, Protokoll, True, False)
    '            Me.addProtokoll(txtErrAnhang, ProtokollErr, True, False)
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                Me.delDoInfoUI.Invoke(txtErrAnhang, False, False)
    '            End If
    '        End If

    '        functionMarker += "1.4;"
    '        Dim IDTmp As String = Me.IsNull(EmailMessage.InternetMessageId, False, "InternetMessageId")
    '        functionMarker += "1.5;"
    '        If IDTmp Is Nothing Then
    '            Throw New Exception("EMailMessage.Id=Nothing for E-Mail '" + SubjectTmp.Trim() + "' from '" + AdressFrom + "'!")
    '        End If
    '        If IDTmp.Trim() = "" Then
    '            Throw New Exception("EMailMessage.Id='' for E-Mail '" + SubjectTmp.Trim() + "' from '" + AdressFrom + "'!")
    '        End If
    '        Dim dReceivedTicks As New TimeSpan(dReceived.Ticks)
    '        functionMarker += "1.6;"
    '        Dim IDIntern As String = IDTmp.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        functionMarker += "2;"
    '        Dim iSizteMsg As Integer = Me.IsNull(EmailMessage.Size, False, "Size")

    '        'Try
    '        '    iSizteMsg = EMailMessage.Size
    '        'Catch ex As Exception
    '        '    Dim txtErrGetMsgHeader As String = "Error: pop3Client.GetMessageSize-->Counter " + iFoundItems.ToString() + "" + vbNewLine + ex.ToString()
    '        '    Me.addProtokoll(txtErrGetMsgHeader, protokoll, True, False)
    '        '    Me.addProtokoll(txtErrGetMsgHeader, protokollErr, True, False)
    '        '    If Not Me.delDoInfoUI Is Nothing Then
    '        '        Me.delDoInfoUI.Invoke(txtErrGetMsgHeader, True)
    '        '    End If
    '        '    If Not doExept Then
    '        '        ITSCont.core.SystemDb.General.SendSystemErrorPerEMailToServiceCenter(ex.ToString(), General.eTypeEMailMessage.E_Mail_SERVER, True, False, True, True, False)
    '        '    End If
    '        '    Continue For
    '        'End Try

    '        Dim ConversationId As String = Me.IsNull(EmailMessage.ConversationId.UniqueId.ToString(), False, "ConversationId")
    '        Dim IDoutlook As String = EmailMessage.Id.UniqueId.ToString()
    '        Dim IDoutlookTicks As String = IDoutlook.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        Dim LastModifiedTime As Date = Me.IsNull(EmailMessage.LastModifiedTime, False, "LastModifiedTime")

    '        Dim doAnhänge As Boolean = True
    '        If maxSizteEMailKB > 0 Then
    '            functionMarker += "3;"
    '            Dim iSizteMsgKB As Integer = (iSizteMsg / 1000)
    '            If iSizteMsgKB > maxSizteEMailKB Then
    '                doAnhänge = False
    '                If clPlan.protWindowNormalOn Then
    '                    Dim txtErrAnhang As String = "Info: E-Mail '" + SubjectTmp + "' from '" + dReceived.ToString() + "' was not imported because to Big! (Size in Kb:" + iSizteMsgKB.ToString() + ")"
    '                    Me.addProtokoll(txtErrAnhang, Protokoll, True, False)
    '                    Me.addProtokoll(txtErrAnhang, ProtokollErr, True, False)
    '                    If Not Me.delDoInfoUI Is Nothing Then
    '                        Me.delDoInfoUI.Invoke(txtErrAnhang, False, False)
    '                    End If
    '                End If
    '                functionMarker += "3.1;"
    '                'Continue For
    '            End If
    '        End If
    '        'If IDIntern = Nothing Then
    '        '    Me.getConversationIDFromReceivedAdress(IDIntern, SubjectTmp, dReceived, AdressFrom, rUserAccount, lastReceivedIsSaved, _
    '        '                                           protokoll, protokollErr)
    '        'Else
    '        '    If IDIntern.Trim() = "" Then
    '        '        Me.getConversationIDFromReceivedAdress(IDIntern, SubjectTmp, dReceived, AdressFrom, rUserAccount, lastReceivedIsSaved, _
    '        '                                               protokoll, protokollErr)
    '        '    End If
    '        'End If
    '        If Not folderParent Is Nothing Then
    '            'Me.synFoldersEMails(InfoExcept, folderParent.DisplayName.Trim(), es, rUserAccount)
    '        End If

    '        functionMarker += "4;"
    '        Dim dsPlanCheckDeleted As New dsPlan()
    '        Me.compPlanRead2.getPlanStatus(IDIntern.Trim(), compPlan.eTypSelPlan.MessageId, dsPlanCheckDeleted, compPlan.eStatusPlan.deleted, rUserAccount.Usr, Nothing)
    '        If dsPlanCheckDeleted.planStatus.Rows.Count > 0 Then
    '            If clPlan.protWindowNormalOn Then
    '                Dim txtErr As String = "Info: E-Mail '" + SubjectTmp + "' from '" + dReceived.ToString() + "' was deleted from User '" + rUserAccount.Usr + "'!"
    '                Me.addProtokoll(txtErr, Protokoll, True, False)
    '                Me.addProtokoll(txtErr, ProtokollErr, True, False)
    '                If Not Me.delDoInfoUI Is Nothing Then
    '                    Me.delDoInfoUI.Invoke(txtErr, False, False)
    '                End If
    '            End If
    '            functionMarker += "4.1;"
    '            Exit Function
    '        End If

    '        Dim bodyWasEmptyLastReceive As Boolean = False
    '        functionMarker += "5;"
    '        dsPlanCheckDeleted = New dsPlan()
    '        'Me.compPlanRead.getPlanStatus(IDIntern.Trim(), compPlan.eTypSelPlan.MessageId, dsPlanCheckDeleted, compPlan.eStatusPlan.bodyEmpty, rUserAccount.Usr)
    '        'If dsPlanCheckDeleted.planStatus.Rows.Count > 0 Then
    '        '    bodyWasEmptyLastReceive = True
    '        'End If

    '        Dim rPlanCheckImported As dsPlan.planRow = Nothing
    '        If Not bodyWasEmptyLastReceive Then
    '            functionMarker += "6;"
    '            Dim dsPlanTmp As New dsPlan()
    '            rPlanCheckImported = Me.compPlanRead2.getPlanRow2(dsPlanTmp, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '            If Not rPlanCheckImported Is Nothing Then
    '                Me.checkAndProtocolIfPlanExistsMoreThan2(IDIntern, rUserAccount, dReceived, SubjectTmp, Protokoll, ProtokollErr, "Mail")
    '                If clPlan.protWindowNormalOn Then
    '                    'Dim txtInfoIsImported As String = "Info: E-Mail '" + messageHeaders.Subject.Trim() + "' vom '" + dReceived.ToString() + "' von '" + messageHeaders.From.MailAddress.Address.Trim() + "' wurde bereits eingespielt!"
    '                    Dim txtInfoIsImported As String = "Info: E-Mail '" + SubjectTmp.Trim() + "' from '" + dReceived.ToString() + "' was already imported!"
    '                    Me.addProtokoll(txtInfoIsImported, Protokoll, True, False)
    '                    Me.addProtokoll(txtInfoIsImported, ProtokollErr, True, False)
    '                    If Not Me.delDoInfoUI Is Nothing Then
    '                        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    '                    End If
    '                End If
    '                If abortIfEMailIsInDB Then
    '                    functionMarker += "6.1;"
    '                    Exit Function
    '                End If
    '            End If
    '        End If

    '        functionMarker += "7;"
    '        Dim cTgMailToAdd As clPlan.cTgMail = Nothing
    '        Dim cMessageNew As New clPlan.cMessage()
    '        cMessageNew.itemOutlook = EmailMessage

    '        Dim rNewPlan As dsPlan.planRow = Nothing
    '        If Not bodyWasEmptyLastReceive Then
    '            rNewPlan = compPlan1.getNewRowPlan(dsPlan1)
    '        Else
    '            rNewPlan = compPlan1.getPlanRow2(dsPlan1, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '        End If

    '        rNewPlan.OutlookAPI = True
    '        rNewPlan.ConversationID = ConversationId.Trim()
    '        Dim newTreeNode As Infragistics.Win.UltraWinTree.UltraTreeNode = Nothing
    '        If Not tree Is Nothing Then
    '            cTgMailToAdd = New clPlan.cTgMail()
    '            cTgMailToAdd.tagValue = iFoundItems
    '            cTgMailToAdd.isOutlookWebAPI = True
    '            cTgMailToAdd.rPlan = rNewPlan
    '            cTgMailToAdd.cMessage1 = cMessageNew
    '            cTgMailToAdd.MessageIDAct = IDIntern
    '            newTreeNode = tree.Nodes.Add(System.Guid.NewGuid.ToString(), dReceived.ToString("yyyy-MM-dd HH:mm:ss") + " - " + SubjectTmp.Trim())
    '            functionMarker += "9.1;"
    '            newTreeNode.Tag = cTgMailToAdd
    '            If Not rPlanCheckImported Is Nothing Then
    '                newTreeNode.Override.NodeAppearance.ForeColor = System.Drawing.Color.DarkRed
    '            End If
    '        End If
    '        functionMarker += "8;"
    '        rNewPlan.readed = False
    '        rNewPlan.MessageId = IDIntern.Trim()
    '        rNewPlan.empfangenAm = dReceived
    '        rNewPlan.IDArt = 1
    '        rNewPlan.Betreff = SubjectTmp.Trim()
    '        functionMarker += "9;"
    '        rNewPlan.Für = rUserAccount.Usr
    '        rNewPlan.MailFrom = AdressFrom.Trim()
    '        rNewPlan.IDoutlook = IDoutlook.Trim()
    '        rNewPlan.IDoutlookTicks = IDoutlookTicks.Trim()
    '        functionMarker += "10;"

    '        For Each adressTo As Microsoft.Exchange.WebServices.Data.EmailAddress In EmailMessage.ToRecipients
    '            If Not adressTo.Address Is Nothing Then
    '                rNewPlan.MailAn += adressTo.Address.Trim() + ";"
    '            Else
    '                If clPlan.protWindowNormalOn Then
    '                    'Dim txtInfoIsImported As String = "Info: E-Mail '" + messageHeaders.Subject.Trim() + "' vom '" + dReceived.ToString() + "' von '" + messageHeaders.From.MailAddress.Address.Trim() + "' wurde bereits eingespielt!"
    '                    Dim txtInfoIsImported As String = "Info: E-Mail '" + SubjectTmp.Trim() + "' from '" + dReceived.ToString() + "' >> rNewPlan.MailAn=''!"
    '                    Me.addProtokoll(txtInfoIsImported, Protokoll, True, False)
    '                    Me.addProtokoll(txtInfoIsImported, ProtokollErr, True, False)
    '                    If Not Me.delDoInfoUI Is Nothing Then
    '                        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    '                    End If
    '                End If
    '                Exit Function
    '            End If
    '        Next
    '        For Each adressCC As Microsoft.Exchange.WebServices.Data.EmailAddress In EmailMessage.CcRecipients
    '            rNewPlan.MailCC += adressCC.Address.Trim() + ";"
    '        Next
    '        For Each adressBcc As Microsoft.Exchange.WebServices.Data.EmailAddress In EmailMessage.BccRecipients
    '            rNewPlan.MailBcc += adressBcc.Address.Trim() + ";"
    '        Next
    '        functionMarker += "11;"
    '        rNewPlan.ErstelltVon = rUserAccount.Usr
    '        rNewPlan.ErstelltAm = Now
    '        rNewPlan.IDUserAccount = rUserAccount.ID
    '        'Try
    '        '    Me.gen.waitTime(80)
    '        '    Dim pSet As PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)
    '        '    EMailMessage.Load(pSet)
    '        '    'EMailMessage.Load()
    '        '    Me.gen.waitTime(80)
    '        'Catch ex As Exception
    '        '    Dim sExcep As String = "findItemsFolder: " + ex.ToString()
    '        '    Throw New Exception(sExcep)
    '        'End Try

    '        If (Not folderParent Is Nothing) Then
    '            rNewPlan.Folder = folderParent.DisplayName.Trim()
    '        Else
    '            rNewPlan.Folder = ""
    '        End If

    '        Me.getBody(rNewPlan, EmailMessage, Nothing, Nothing, cMessageNew, SubjectTmp, dReceived, IDIntern, rUserAccount, Protokoll, ProtokollErr)
    '        Me.getAnhänge(rNewPlan, bodyWasEmptyLastReceive, EmailMessage, Nothing, Nothing, cMessageNew, SubjectTmp, dReceived, IDIntern,
    '                                              rUserAccount, doAnhänge, Protokoll, ProtokollErr, functionMarker, tree, dsPlan1, cTgMailToAdd, newTreeNode)

    '        If (Not bodyWasEmptyLastReceive) Then
    '            functionMarker += "13;"
    '            Me.scannObjectsForEMails(rNewPlan.MailFrom.Trim(), dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker)
    '        End If

    '        Dim lstObjectsAdded As New System.Collections.Generic.List(Of Guid)()
    '        If General.AutoScannServiceOnOff Then
    '            Me.scannSubjectBodyForContract(rNewPlan.Betreff.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "E#Mail", lstObjectsAdded)
    '            If General.checkEMailsBodyForContracts Then
    '                Me.scannSubjectBodyForContract(rNewPlan.Text.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "E#Mail", lstObjectsAdded)
    '            End If
    '        End If

    '        'functionMarker += "18;"
    '        'Dim ds As New ITSCont.core.SystemDb.dsEMailPopInfo
    '        'Me.getNewRowEMailMIME("Mime", sMime, ds)
    '        'rNewPlan.DetailsMIME = email.GetMime().Trim()   ' Me.db1.getXMLDb(ds, XmlWriteMode.WriteSchema)
    '        If doSave Then
    '            functionMarker += "14;"
    '        Else
    '            functionMarker += "OK;"
    '        End If

    '        Me.UpdateCategoriesFromoExchangeToDB(es, dNow, Nothing, Nothing, EmailMessage, rNewPlan)

    '        If doSave Then
    '            'Me.UpdateCategoriesinFolder(es, EMailMessage.ConversationId, InfoExcept, EMailMessage.ParentFolderId)
    '            'Dim txtPlan As String = rNewPlan.Text
    '            'rNewPlan.Text = ""
    '            compPlan1.daPlan.Update(dsPlan1.plan)
    '            If (Not bodyWasEmptyLastReceive) Then
    '                compPlan1.daPlanObject.Update(dsPlan1.planObject)
    '                compPlan1.daPlanAnhang.Update(dsPlan1.planAnhang)
    '                'compPlan1.UpdatePlanText(rNewPlan.ID, txtPlan)
    '                'If Me.gen.IsNull(dFirstSaved) Then
    '                '    dFirstSaved = rNewPlan.empfangenAm
    '                'End If
    '                Me.saveLastReceivedDate(dReceived, rUserAccount)
    '                If rNewPlan.Folder.Trim() <> "" Then
    '                    'Me.synFoldersEMails(InfoExcept, rNewPlan.Folder.Trim(), es, rUserAccount)
    '                End If
    '                InfoMailService.iCounterIncomingEMails2 += 1
    '            End If
    '            functionMarker += "OK;"
    '        End If
    '        If EMailsVomServerLöschen Then
    '        End If

    '        If Not Me.delDoInfoUI Is Nothing Then
    '            'If clPlan.protWindowNormalOn Then
    '            Dim txtPos As String = "E-Mail " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "' was imported"
    '            Me.delDoInfoUI.Invoke(txtPos, False, False)
    '            'End If
    '            If clPlan.protWindowMarkOn Then
    '                Dim txtFctMarker As String = "Fct.Marker: " + functionMarker.Trim() + "        E-Mail '" + SubjectTmp.Trim() + "'     " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "'"
    '                Me.delDoInfoUI.Invoke(txtFctMarker, False, False)
    '            End If
    '        End If

    '        iFoundItems += 1
    '        iCounterLocal += 1
    '        If Not bar Is Nothing Then
    '            bar.Value = iCounterLocal    'System.Convert.ToInt32(((findResults.TotalCount - iCounterLocal) / findResults.TotalCount) * 100)
    '            System.Windows.Forms.Application.DoEvents()
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.addUpdateMailsToITSCont: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function
    'Public Sub syncFolderExchangeToDBxyxy(ByRef EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage,
    '                                        ByRef es As ExchangeService,
    '                                        ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                        ByRef dNow As Date,
    '                                        ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                                        ByRef InfoExcept As String, ByRef folderParent As Folder,
    '                                        ByRef Protokoll As String, ByRef ProtokollErr As String,
    '                                        ByRef IDIntern As String)
    '    Try
    '        If IDIntern.Trim() = "" Then
    '            Throw New Exception("syncFolderExchangeToDB: IDIntern='' not allowed!")
    '        End If

    '        Dim rPlanCheckImported As dsPlan.planRow = Nothing
    '        Dim dsPlanTmp As New dsPlan()
    '        Dim compPlanReadTmp As New compPlan()
    '        'rPlanCheckImported = Me.compPlanRead.getPlanRow2(dsPlanTmp, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '        compPlanReadTmp.getPlan(Nothing, compPlan.eTypSelPlan.MessageIdMIME, dsPlanTmp, IDIntern.Trim(), rUserAccount.Usr)
    '        For Each rPlan As dsPlan.planRow In dsPlanTmp.plan
    '            If rPlan.Folder.Trim() <> "" Then
    '                'Me.synFoldersEMails(InfoExcept, rPlan.Folder.Trim(), es, rUserAccount)
    '            End If
    '        Next
    '        If Not rPlanCheckImported Is Nothing Then
    '            If rPlanCheckImported.Folder.Trim() <> "" Then
    '                'Me.synFoldersEMails(InfoExcept, rPlanCheckImported.Folder.Trim(), es, rUserAccount)
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.syncFolderExchangeToDB: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Sub
    'Public Sub synFoldersEMailsxy(ByRef InfoExcept As String, ByRef FolderNameExchangeFromMail As String, ByRef es As ExchangeService,
    '                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow)
    '    Try
    '        Dim b As New PMDS.db.PMDSBusiness()
    '        Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
    '            Dim rSelListGroup As PMDS.db.Entities.tblSelListGroup = b.getSelListEntryGroup("FoldPlans", db)

    '            Dim MaxIDSelListEntryReturn As Integer = -1
    '            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
    '            Me.gen.loadSelList(Nothing, Nothing, "FoldPlans", tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntryReturn)
    '            Dim bFolderNameExists As Boolean = False
    '            For Each rSelListFolderITSCont As PMDS.db.Entities.tblSelListEntries In tSelListEntriesReturn
    '                If rSelListFolderITSCont.Description.Trim().ToLower().Equals(FolderNameExchangeFromMail.Trim().ToLower()) Then
    '                    bFolderNameExists = True
    '                End If
    '            Next
    '            If Not bFolderNameExists Then
    '                Dim rNewSelList As PMDS.db.Entities.tblSelListEntries = PMDS.Global.db.ERSystem.EFEntities.newtblSelListEntries(db)
    '                'Dim rNewSelList As New PMDS.db.Entities.tblSelListEntries()
    '                rNewSelList.IDGroup = rSelListGroup.ID
    '                rNewSelList.IDRessource = FolderNameExchangeFromMail.Trim()
    '                rNewSelList.IDGuid = System.Guid.NewGuid()
    '                rNewSelList.ID = MaxIDSelListEntryReturn + 1
    '                rNewSelList.Classification = "FromExchange"
    '                rNewSelList.Extern = rUserAccount.Usr.Trim() + ";"
    '                db.tblSelListEntries.Add(rNewSelList)
    '                db.SaveChanges()

    '                Dim txtPos As String = "Folder " + FolderNameExchangeFromMail.Trim() + " added to Exchange - Account '" + rUserAccount.Name + "!"
    '                Me.delDoInfoUI.Invoke(txtPos, False, False)
    '            End If
    '        End Using

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.synFoldersEMails: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Sub

    'Public Function addUpdateCalendarToITSCont(ByRef Appoinment As Microsoft.Exchange.WebServices.Data.Appointment,
    '                                            ByRef es As ExchangeService,
    '                                            ByRef TypeFolder As WellKnownFolderName,
    '                                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan, ByRef doSave As Boolean,
    '                                            ByRef EMailsVomServerLöschen As Boolean, ByRef dNow As Date,
    '                                            ByRef InfoMailService As clPlan.cInfoMailService,
    '                                            ByRef findResults As FindItemsResults(Of Item),
    '                                            ByRef iCounterLocal As Integer, ByRef iFoundItems As Integer, ByRef maxSizteEMailKB As Integer,
    '                                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                                            ByRef SubjectTmp As String, ByRef functionMarker As String, ByRef dReceived As Date,
    '                                            ByRef InfoExcept As String,
    '                                            ByRef checkLastRecieve As Boolean, ByRef datLastReceived As Date,
    '                                            ByRef abortIfEMailIsInDB As Boolean, ByRef Protokoll As String, ByRef ProtokollErr As String) As Boolean
    '    Try
    '        'Dim oMsg As Microsoft.Office.Interop.Outlook.MailItem = oItems.Item(i)
    '        SubjectTmp = ""
    '        SubjectTmp = Me.IsNull(Appoinment.Subject, False, "Subject")
    '        If SubjectTmp.Trim() = "" Then
    '            SubjectTmp = "No Subject ..."
    '        End If

    '        Dim StartAtTmp As DateTime = Nothing
    '        If Appoinment.Start <> Nothing Then
    '            StartAtTmp = Me.IsNull(Appoinment.Start, False, "Start")
    '        Else
    '            StartAtTmp = Me.IsNull(Appoinment.DateTimeCreated, False, "DateTimeCreated")
    '        End If
    '        dReceived = StartAtTmp
    '        Dim EndAtTmp As DateTime = Nothing
    '        If Appoinment.End <> Nothing Then
    '            EndAtTmp = Me.IsNull(Appoinment.End, False, "End")
    '        End If

    '        Dim ConversationIDTmp As String = Appoinment.ConversationId.UniqueId.ToString().Trim()
    '        Dim dReceivedTicks As New TimeSpan(dReceived.Ticks)
    '        Dim IDIntern As String = ConversationIDTmp.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        Dim IDoutlook As String = Appoinment.Id.UniqueId.ToString()
    '        Dim IDoutlookTicks As String = IDoutlook.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        If Not Me.delDoInfoUI Is Nothing Then
    '            'Me.delDoInfoUI.Invoke("Reading Appointment '" + SubjectTmp.Trim() + "'", True, False)
    '        End If
    '        Dim LastModifiedTime As Date = Me.IsNull(Appoinment.LastModifiedTime, False, "LastModifiedTime")

    '        If checkLastRecieve Then
    '            Dim lastReceiveBack As Date = datLastReceived.AddDays(-8)    'datLastReceived.AddHours(-336)
    '            If dReceived <= lastReceiveBack Then
    '                Return False
    '            End If
    '        End If
    '        If dReceived.Date < cOutlookWebAPI.dateExit.Date Then
    '            Return False
    '        End If

    '        Dim dsPlanCheckDeleted As New dsPlan()
    '        Me.compPlanRead2.getPlanStatus(IDIntern.Trim(), compPlan.eTypSelPlan.MessageId, dsPlanCheckDeleted, compPlan.eStatusPlan.deleted, rUserAccount.Usr, Nothing)
    '        If dsPlanCheckDeleted.planStatus.Rows.Count > 0 Then
    '            If clPlan.protWindowNormalOn Then
    '                Dim txtErr As String = "Info: Appointment '" + SubjectTmp + "' from '" + dReceived.ToString() + "' was deleted from User '" + rUserAccount.Usr + "'!"
    '                Me.addProtokoll(txtErr, Protokoll, True, False)
    '                Me.addProtokoll(txtErr, ProtokollErr, True, False)
    '                If Not Me.delDoInfoUI Is Nothing Then
    '                    Me.delDoInfoUI.Invoke(txtErr, False, False)
    '                End If
    '            End If
    '            Return False
    '        End If

    '        Dim PlanExistsInDB As Boolean = False
    '        Dim dsPlanTmp2 As New dsPlan()
    '        Dim rPlanCheckImported As dsPlan.planRow = Me.compPlanRead2.getPlanRow2(dsPlanTmp2, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '        If Not rPlanCheckImported Is Nothing Then
    '            PlanExistsInDB = True
    '            Me.checkAndProtocolIfPlanExistsMoreThan2(IDIntern, rUserAccount, dReceived, SubjectTmp, Protokoll, ProtokollErr, "Calendar")
    '            'If clPlan.protWindowNormalOn Then
    '            '    Dim txtInfoIsImported As String = "Info: Appointment '" + SubjectTmp.Trim() + "' from '" + dReceived.ToString() + "' was already imported!"
    '            '    Me.addProtokoll(txtInfoIsImported, Protokoll, True, False)
    '            '    Me.addProtokoll(txtInfoIsImported, ProtokollErr, True, False)
    '            '    If Not Me.delDoInfoUI Is Nothing Then
    '            '        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    '            '    End If
    '            'End If
    '            'If abortIfEMailIsInDB Then
    '            '    Return False
    '            'End If
    '        End If

    '        Dim bDoUpdate As Boolean = False
    '        If PlanExistsInDB Then
    '            compPlan1.getPlan(Nothing, compPlan.eTypSelPlan.MessageIdMIME, dsPlan1, IDIntern.Trim(), rUserAccount.Usr)
    '            'compPlan1.getPlan(rPlanCheckImported.ID, compPlan.eTypSelPlan.id, dsPlan1)
    '            'If dsPlan1.plan.Rows.Count <> 1 Then
    '            '    Throw New Exception("dsPlan1.plan.Rows.Count <> 1 for IDPlan '" + rPlanCheckImported.ID.ToString() + "'!")
    '            'End If
    '            'rNewPlan = dsPlan1.plan.Rows(0)
    '            For Each rPlan As dsPlan.planRow In dsPlan1.plan
    '                If (Not rPlan.IsLastSyncToExchangeNull()) AndAlso LastModifiedTime > rPlan.LastSyncToExchange Then
    '                    'If Not rPlan.Status.Trim().ToLower().Equals(("Erledigt").Trim().ToLower()) Then
    '                    bDoUpdate = True
    '                    'End If
    '                End If
    '            Next
    '            If Not bDoUpdate Then
    '                Exit Function
    '            End If
    '        Else
    '            Dim rNewPlan As dsPlan.planRow = Nothing
    '            rNewPlan = compPlan1.getNewRowPlan(dsPlan1)
    '        End If

    '        For Each rNewPlan As dsPlan.planRow In dsPlan1.plan
    '            'rNewPlan = compPlan1.getPlanRow2(dsPlan1, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '            rNewPlan.BeginntAm = dReceived
    '            If EndAtTmp <> Nothing Then
    '                rNewPlan.FälligAm = EndAtTmp
    '            End If
    '            rNewPlan.OutlookAPI = True
    '            rNewPlan.ConversationID = ConversationIDTmp.Trim()
    '            rNewPlan.readed = False
    '            rNewPlan.MessageId = IDIntern.Trim()
    '            rNewPlan.empfangenAm = dReceived
    '            rNewPlan.IDArt = 3
    '            rNewPlan.Betreff = SubjectTmp.Trim()
    '            rNewPlan.Für = rUserAccount.Usr
    '            rNewPlan.IDoutlook = IDoutlook.Trim()
    '            rNewPlan.IDoutlookTicks = IDoutlookTicks.Trim()
    '            rNewPlan.LastSyncToExchange = Now.AddSeconds(2)

    '            'rNewPlan.MailFrom = Task.Owner
    '            For Each adressTo As Microsoft.Exchange.WebServices.Data.EmailAddress In Appoinment.RequiredAttendees
    '                rNewPlan.MailAn += adressTo.Address.Trim() + ";"
    '            Next
    '            For Each adressCC As Microsoft.Exchange.WebServices.Data.EmailAddress In Appoinment.OptionalAttendees
    '                rNewPlan.MailCC += adressCC.Address.Trim() + ";"
    '            Next
    '            'For Each adressBcc As Microsoft.Exchange.WebServices.Data.EmailAddress In Task.BccRecipients
    '            '    rNewPlan.MailBcc += adressBcc.Address.Trim() + ";"
    '            'Next
    '            rNewPlan.ErstelltVon = rUserAccount.Usr
    '            rNewPlan.ErstelltAm = dNow
    '            rNewPlan.IDUserAccount = rUserAccount.ID
    '            Dim imp As Microsoft.Exchange.WebServices.Data.Importance = Appoinment.Importance
    '            If imp.High Then
    '                rNewPlan.wichtig = True
    '            End If
    '            'rNewPlan.gesendetAm    Appoinment.DateTimeSent

    '            Dim cMessageNew As New clPlan.cMessage()
    '            Dim isHtml As Boolean = False
    '            Dim bodyWasEmptyLastReceive As Boolean = False
    '            Me.getBody(rNewPlan, Nothing, Appoinment, Nothing, cMessageNew, SubjectTmp, dReceived, IDIntern, rUserAccount, Protokoll, ProtokollErr)
    '            Me.getAnhänge(rNewPlan, bodyWasEmptyLastReceive, Nothing, Appoinment, Nothing, cMessageNew, SubjectTmp, dReceived, IDIntern,
    '                                              rUserAccount, True, Protokoll, ProtokollErr, functionMarker, Nothing, dsPlan1, Nothing, Nothing)

    '            If (Not bodyWasEmptyLastReceive) Then
    '                Me.scannObjectsForEMails(rNewPlan.MailAn.Trim(), dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker)
    '            End If

    '            Dim lstObjectsAdded As New System.Collections.Generic.List(Of Guid)()
    '            If General.AutoScannServiceOnOff Then
    '                Me.scannSubjectBodyForContract(rNewPlan.Betreff.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "Calendar", lstObjectsAdded)
    '                If General.checkEMailsBodyForContracts Then
    '                    Me.scannSubjectBodyForContract(rNewPlan.Text.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "Calendar", lstObjectsAdded)
    '                End If
    '            End If

    '            Me.UpdateCategoriesFromoExchangeToDB(es, dNow, Appoinment, Nothing, Nothing, rNewPlan)

    '            compPlan1.daPlan.Update(dsPlan1.plan)
    '            If (Not bodyWasEmptyLastReceive) Then
    '                compPlan1.daPlanObject.Update(dsPlan1.planObject)
    '                compPlan1.daPlanAnhang.Update(dsPlan1.planAnhang)
    '                'compPlan1.UpdatePlanText(rNewPlan.ID, txtPlan)
    '                'If Me.gen.IsNull(dFirstSaved) Then
    '                '    dFirstSaved = rNewPlan.empfangenAm
    '                'End If
    '                'Me.saveLastReceivedDate(dReceived, rUserAccount)
    '                InfoMailService.iCounterIncomingAppointmentsTasks += 1
    '            End If
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                'If clPlan.protWindowNormalOn Then
    '                Dim txtPos As String = "Appointment " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "' was imported"
    '                Me.delDoInfoUI.Invoke(txtPos, False, False)
    '                'End If
    '                If clPlan.protWindowMarkOn Then
    '                    Dim txtFctMarker As String = "Fct.Marker: " + functionMarker.Trim() + "        Appointment '" + SubjectTmp.Trim() + "'     " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "'"
    '                    Me.delDoInfoUI.Invoke(txtFctMarker, False, False)
    '                End If
    '            End If

    '            iFoundItems += 1
    '            iCounterLocal += 1
    '        Next

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.addUpdateCalendarToITSCont: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function
    'Public Function addUpdateTasksToITSCont(ByRef Task As Microsoft.Exchange.WebServices.Data.Task,
    '                                            ByRef es As ExchangeService,
    '                                            ByRef TypeFolder As WellKnownFolderName,
    '                                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan, ByRef doSave As Boolean,
    '                                            ByRef EMailsVomServerLöschen As Boolean, ByRef dNow As Date,
    '                                            ByRef InfoMailService As clPlan.cInfoMailService,
    '                                            ByRef findResults As FindItemsResults(Of Item),
    '                                            ByRef iCounterLocal As Integer, ByRef iFoundItems As Integer, ByRef maxSizteEMailKB As Integer,
    '                                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                                            ByRef SubjectTmp As String, ByRef functionMarker As String, ByRef dReceived As Date,
    '                                            ByRef InfoExcept As String,
    '                                            ByRef checkLastRecieve As Boolean, ByRef datLastReceived As Date,
    '                                            ByRef abortIfEMailIsInDB As Boolean, ByRef Protokoll As String, ByRef ProtokollErr As String) As Boolean
    '    Try
    '        'Dim oMsg As Microsoft.Office.Interop.Outlook.MailItem = oItems.Item(i)
    '        SubjectTmp = ""
    '        SubjectTmp = Me.IsNull(Task.Subject, False, "Subject")
    '        If SubjectTmp.Trim() = "" Then
    '            SubjectTmp = "No Subject ..."
    '        End If

    '        Dim StartAtTmp As DateTime = Nothing
    '        If Task.StartDate Is Nothing Then
    '            StartAtTmp = Me.IsNull(Task.DateTimeCreated, False, "StartDate")
    '        Else
    '            StartAtTmp = Me.IsNull(Task.StartDate, False, "StartDate")
    '        End If
    '        dReceived = StartAtTmp
    '        Dim ConversationIDTmp As String = Task.ConversationId.UniqueId.ToString().Trim()
    '        Dim dReceivedTicks As New TimeSpan(dReceived.Ticks)
    '        Dim IDIntern As String = ConversationIDTmp.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        Dim IDoutlook As String = Task.Id.UniqueId.ToString()
    '        Dim IDoutlookTicks As String = IDoutlook.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        If Not Me.delDoInfoUI Is Nothing Then
    '            'Me.delDoInfoUI.Invoke("Reading task '" + SubjectTmp.Trim() + "'", True, False)
    '        End If
    '        Dim LastModifiedTime As Date = Me.IsNull(Task.LastModifiedTime, False, "LastModifiedTime")

    '        If checkLastRecieve Then
    '            Dim lastReceiveBack As Date = datLastReceived.AddDays(-8)          'datLastReceived.AddHours(-336)
    '            If dReceived <= lastReceiveBack Then
    '                Return False
    '            End If
    '        End If
    '        If dReceived.Date < cOutlookWebAPI.dateExit.Date Then
    '            Return False
    '        End If
    '        Dim CompleteDateTmp As DateTime = Nothing
    '        If Not Task.CompleteDate Is Nothing Then
    '            CompleteDateTmp = Me.IsNull(Task.CompleteDate, False, "CompleteDate")
    '        End If

    '        Dim dsPlanCheckDeleted As New dsPlan()
    '        Me.compPlanRead2.getPlanStatus(IDIntern.Trim(), compPlan.eTypSelPlan.MessageId, dsPlanCheckDeleted, compPlan.eStatusPlan.deleted, rUserAccount.Usr, Nothing)
    '        If dsPlanCheckDeleted.planStatus.Rows.Count > 0 Then
    '            If clPlan.protWindowNormalOn Then
    '                Dim txtErr As String = "Info: Task '" + SubjectTmp + "' from '" + dReceived.ToString() + "' was deleted from User '" + rUserAccount.Usr + "'!"
    '                Me.addProtokoll(txtErr, Protokoll, True, False)
    '                Me.addProtokoll(txtErr, ProtokollErr, True, False)
    '                If Not Me.delDoInfoUI Is Nothing Then
    '                    Me.delDoInfoUI.Invoke(txtErr, False, False)
    '                End If
    '            End If
    '            Return False
    '        End If

    '        Dim PlanExistsInDB As Boolean = False
    '        Dim dsPlanTmp2 As New dsPlan()
    '        Dim rPlanCheckImported As dsPlan.planRow = Me.compPlanRead2.getPlanRow2(dsPlanTmp2, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '        If Not rPlanCheckImported Is Nothing Then
    '            PlanExistsInDB = True
    '            Me.checkAndProtocolIfPlanExistsMoreThan2(IDIntern, rUserAccount, dReceived, SubjectTmp, Protokoll, ProtokollErr, "Task")
    '            'If clPlan.protWindowNormalOn Then
    '            '    Dim txtInfoIsImported As String = "Info: Task '" + SubjectTmp.Trim() + "' from '" + dReceived.ToString() + "' was already imported!"
    '            '    Me.addProtokoll(txtInfoIsImported, Protokoll, True, False)
    '            '    Me.addProtokoll(txtInfoIsImported, ProtokollErr, True, False)
    '            '    If Not Me.delDoInfoUI Is Nothing Then
    '            '        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    '            '    End If
    '            'End If
    '            'If abortIfEMailIsInDB Then
    '            '    Return False
    '            'End If
    '        End If

    '        Dim bDoUpdate As Boolean = False
    '        If PlanExistsInDB Then
    '            compPlan1.getPlan(Nothing, compPlan.eTypSelPlan.MessageIdMIME, dsPlan1, IDIntern.Trim(), rUserAccount.Usr)
    '            'compPlan1.getPlan(rPlanCheckImported.ID, compPlan.eTypSelPlan.id, dsPlan1)
    '            'If dsPlan1.plan.Rows.Count <> 1 Then
    '            '    Throw New Exception("dsPlan1.plan.Rows.Count <> 1 for IDPlan '" + rPlanCheckImported.ID.ToString() + "'!")
    '            'End If
    '            'rNewPlan = dsPlan1.plan.Rows(0)
    '            For Each rPlan As dsPlan.planRow In dsPlan1.plan
    '                If (Not rPlan.IsLastSyncToExchangeNull()) AndAlso LastModifiedTime > rPlan.LastSyncToExchange Then
    '                    'If Not rPlan.Status.Trim().ToLower().Equals(("Erledigt").Trim().ToLower()) Then
    '                    bDoUpdate = True
    '                    'End If
    '                End If
    '            Next
    '            If Not bDoUpdate Then
    '                Exit Function
    '            End If
    '        Else
    '            Dim rNewPlan As dsPlan.planRow = Nothing
    '            rNewPlan = compPlan1.getNewRowPlan(dsPlan1)
    '        End If

    '        For Each rNewPlan As dsPlan.planRow In dsPlan1.plan
    '            'rNewPlan = compPlan1.getPlanRow2(dsPlan1, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '            rNewPlan.BeginntAm = dReceived
    '            If CompleteDateTmp <> Nothing Then
    '                rNewPlan.FälligAm = CompleteDateTmp
    '            End If
    '            rNewPlan.OutlookAPI = True
    '            rNewPlan.ConversationID = ConversationIDTmp.Trim()
    '            rNewPlan.readed = False
    '            rNewPlan.MessageId = IDIntern.Trim()
    '            rNewPlan.empfangenAm = dReceived
    '            rNewPlan.IDArt = 5
    '            rNewPlan.Betreff = SubjectTmp.Trim()
    '            rNewPlan.Für = rUserAccount.Usr
    '            rNewPlan.IDoutlook = IDoutlook.Trim()
    '            rNewPlan.IDoutlookTicks = IDoutlookTicks.Trim()
    '            rNewPlan.LastSyncToExchange = Now.AddSeconds(2)

    '            'rNewPlan.MailFrom = Task.Owner
    '            For Each adressTo As Microsoft.Exchange.WebServices.Data.EmailAddress In Task.Contacts
    '                rNewPlan.MailAn += adressTo.Address.Trim() + ";"
    '            Next
    '            'For Each adressCC As Microsoft.Exchange.WebServices.Data.EmailAddress In Task.CcRecipients
    '            '    rNewPlan.MailCC += adressCC.Address.Trim() + ";"
    '            'Next
    '            'For Each adressBcc As Microsoft.Exchange.WebServices.Data.EmailAddress In Task.BccRecipients
    '            '    rNewPlan.MailBcc += adressBcc.Address.Trim() + ";"
    '            'Next
    '            rNewPlan.ErstelltVon = rUserAccount.Usr
    '            rNewPlan.ErstelltAm = Now
    '            rNewPlan.IDUserAccount = rUserAccount.ID
    '            Dim imp As Microsoft.Exchange.WebServices.Data.Importance = Task.Importance
    '            If imp.High Then
    '                rNewPlan.wichtig = True
    '            End If

    '            Dim cMessageNew As New clPlan.cMessage()
    '            Dim isHtml As Boolean = False
    '            Dim bodyWasEmptyLastReceive As Boolean = False
    '            Me.getBody(rNewPlan, Nothing, Nothing, Task, cMessageNew, SubjectTmp, dReceived, IDIntern, rUserAccount, Protokoll, ProtokollErr)
    '            Me.getAnhänge(rNewPlan, bodyWasEmptyLastReceive, Nothing, Nothing, Task, cMessageNew, SubjectTmp, dReceived, IDIntern,
    '                                                  rUserAccount, True, Protokoll, ProtokollErr, functionMarker, Nothing, dsPlan1, Nothing, Nothing)

    '            If (Not bodyWasEmptyLastReceive) Then
    '                Me.scannObjectsForEMails(rNewPlan.MailAn.Trim(), dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker)
    '            End If

    '            Dim lstObjectsAdded As New System.Collections.Generic.List(Of Guid)()
    '            If General.AutoScannServiceOnOff Then
    '                Me.scannSubjectBodyForContract(rNewPlan.Betreff.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "Task", lstObjectsAdded)
    '                If General.checkEMailsBodyForContracts Then
    '                    Me.scannSubjectBodyForContract(rNewPlan.Text.Trim(), rNewPlan.html, rNewPlan.Betreff.Trim(), dReceived, dsPlan1.planObject, rNewPlan.ID, dsPlan1, compPlan1, Protokoll, functionMarker, "Task", lstObjectsAdded)
    '                End If
    '            End If

    '            Me.UpdateCategoriesFromoExchangeToDB(es, dNow, Nothing, Task, Nothing, rNewPlan)

    '            compPlan1.daPlan.Update(dsPlan1.plan)
    '            If (Not bodyWasEmptyLastReceive) Then
    '                compPlan1.daPlanObject.Update(dsPlan1.planObject)
    '                compPlan1.daPlanAnhang.Update(dsPlan1.planAnhang)
    '                'compPlan1.UpdatePlanText(rNewPlan.ID, txtPlan)
    '                'If Me.gen.IsNull(dFirstSaved) Then
    '                '    dFirstSaved = rNewPlan.empfangenAm
    '                'End If
    '                'Me.saveLastReceivedDate(dReceived, rUserAccount)
    '                InfoMailService.iCounterIncomingAppointmentsTasks += 1
    '            End If
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                'If clPlan.protWindowNormalOn Then
    '                Dim txtPos As String = "Task " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "' was imported"
    '                Me.delDoInfoUI.Invoke(txtPos, False, False)
    '                'End If
    '                If clPlan.protWindowMarkOn Then
    '                    Dim txtFctMarker As String = "Fct.Marker: " + functionMarker.Trim() + "        Task '" + SubjectTmp.Trim() + "'     " + (iCounterLocal).ToString() + " from " + findResults.TotalCount.ToString() + " Account '" + rUserAccount.Name + "'"
    '                    Me.delDoInfoUI.Invoke(txtFctMarker, False, False)
    '                End If
    '            End If

    '            iFoundItems += 1
    '            iCounterLocal += 1
    '        Next

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.addUpdateTasksToITSCont: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function

    'Public Sub doException(ByRef doExep As Boolean, ByRef functionMarker As String, ByRef SubjectTmp As String, ByRef dReceived As Date,
    '                     ByRef ex2 As Exception, ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, sErrType As String)

    '    Dim txtDetail As String = ""
    '    txtDetail = sErrType + " - Account: " + rUserAccount.UsrAuthentication.Trim() + ", Subject: " + SubjectTmp + ", ReceivedAt: " + dReceived.ToString() + "" + vbNewLine
    '    If doExep Then
    '        Dim sExcept As String = "strExceptionMark=" + functionMarker + vbNewLine + txtDetail + vbNewLine + vbNewLine + ex2.ToString()
    '        Throw New Exception(sExcept)
    '    Else
    '        Dim sExcep As String = "strExceptionMark=" + functionMarker + vbNewLine + txtDetail + vbNewLine + ex2.ToString()
    '        'protokollErr += ex.ToString() + vbNewLine + vbNewLine
    '        If Not Me.delDoInfoUI Is Nothing Then
    '            Me.delDoInfoUI.Invoke(sExcep.Trim(), True, False)
    '        End If
    '        General.iCounterExceptionsToSend += 1
    '        General.ExceptionsToSend += General.iCounterExceptionsToSend.ToString() + ". Exception" + vbNewLine + sExcep.Trim() + vbNewLine + vbNewLine
    '    End If
    '    'Dim sExcept As String = "cOutlookWebAPI.findItemsInFolder: " + vbNewLine + ex2.ToString() + vbNewLine + vbNewLine
    '    'Throw New Exception(sExcept)

    'End Sub

    'Public Sub checkAndProtocolIfPlanExistsMoreThan2(ByRef IDIntern As String, ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef dReceived As Date,
    '                                     ByRef SubjectTmp As String, ByRef Protokoll As String, ByRef ProtokollErr As String, ByRef sInfoType As String)
    '    Try
    '        If IDIntern.Trim() = "" Then
    '            Throw New Exception("checkAndProtocolIfPlanExistsMoreThan2: IDIntern.Trim()='' now allowed!")
    '        End If
    '        Dim compPlanTmp2 As New compPlan()
    '        Dim dsPlanTmp2 As New dsPlan()
    '        'rPlanCheckImported = Me.compPlanRead.getPlanRow2(dsPlanTmp, Nothing, compPlan.eTypSelPlan.MessageIdMIME, False, IDIntern.Trim(), rUserAccount.Usr)
    '        compPlanTmp2.getPlan(Nothing, compPlan.eTypSelPlan.MessageIdMIME, dsPlanTmp2, IDIntern.Trim(), rUserAccount.Usr)
    '        If dsPlanTmp2.plan.Rows.Count > 1 Then
    '            Dim txtInfoIsDoubledExists As String = "Info: " + sInfoType.Trim() + " '" + SubjectTmp.Trim() + "' from '" + dReceived.ToString() + "' >> there are '" + dsPlanTmp2.plan.Rows.Count.ToString() + "' existing plans!"
    '            Me.addProtokoll(txtInfoIsDoubledExists, Protokoll, True, False)
    '            Me.addProtokoll(txtInfoIsDoubledExists, ProtokollErr, True, False)
    '            If Not Me.delDoInfoUI Is Nothing Then
    '                Me.delDoInfoUI.Invoke(txtInfoIsDoubledExists, False, False)
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("checkAndProtocolIfPlanExistsMoreThan2: " + ex.ToString())
    '    End Try
    'End Sub




    'Public Function syncContactsToITSCont(ByRef Size As Integer, ByRef iFoundItems As Integer, ByRef iFoundFolders As Integer,
    '                            ByRef es As ExchangeService, ByRef TypeFolder As WellKnownFolderName,
    '                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                            ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                            ByRef abortIfEMailIsInDB As Boolean,
    '                            ByRef maxSizteEMailKB As Integer, ByRef EMailsVomServerLöschen As Boolean,
    '                            ByRef checkLastRecieve As Boolean,
    '                            ByRef protokoll As String, ByRef protokollErr As String, ByRef doExept As Boolean,
    '                            ByRef doSave As Boolean,
    '                            ByRef InfoMailService As clPlan.cInfoMailService, ByRef datLastReceived As Date,
    '                            ByRef tree As Infragistics.Win.UltraWinTree.UltraTree, ByRef dNow As Date,
    '                            ByRef bar As Infragistics.Win.UltraWinProgressBar.UltraProgressBar, ByRef checkEmptyItems As Boolean) As Boolean
    '    Dim InfoExcept As String = rUserAccount.UsrAuthentication.Trim()
    '    Try
    '        'Dim compObjectRead As New compObject()             'lthNotPossibleAK
    '        'If rUserAccount.Usr.Trim() = "" Then
    '        '    Throw New Exception("syncContacts: rUserAccount.Usr='' not possible!" + vbNewLine + InfoExcept)
    '        'End If
    '        'Dim rUsr As dsObject.tblObjectRow = compObjectRead.getObjectRow(Nothing, compObject.eTypSelObj.usr, compObject.eTypObj.none, rUserAccount.Usr.Trim(), True)
    '        'If rUsr Is Nothing Then
    '        '    Throw New Exception("syncContacts: rUsr is Nothing is not possible!" + vbNewLine + InfoExcept)
    '        'End If

    '        'Dim dsObjectRead As New dsObject()
    '        'compObjectRead.getObjectSub(rUsr.ID, dsObjectRead, Nothing)
    '        'For Each rObjInterestedPerson As dsObject.tblObjectSubRow In dsObjectRead.tblObjectSub
    '        '    Me.syncContactsToITSCont(rObjInterestedPerson.IDObject, protokoll, protokollErr, doSave, dNow, rUserAccount, InfoExcept, es, TypeFolder, doExept)
    '        'Next

    '        ''dsObjectRead = New dsObject()
    '        ''compObjectRead.getObject(rUsr.ID, dsObjectRead, compObject.eTypSelObj.SearchChangedContactsOnExchange)
    '        ''For Each rObjSynced As dsObject.tblObjectRow In dsObjectRead.tblObject
    '        ''    Me.syncContact(rObjSynced.ID, protokoll, protokollErr, doSave, dNow, rUserAccount, InfoExcept, es, TypeFolder, doExept)
    '        ''Next

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.syncContactsToITSCont: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function
    'Public Function syncContactsToITSCont(ByRef IDObjectToUpdate As System.Guid, ByRef protokoll As String, ByRef protokollErr As String,
    '                                ByRef doSave As Boolean, ByRef dNow As Date,
    '                                ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef InfoExcept As String,
    '                                ByRef es As ExchangeService, ByRef TypeFolder As WellKnownFolderName,
    '                                ByRef doExept As Boolean) As Boolean
    '    Try
    '        Dim functionMarker As String = ""
    '        If cOutlookWebAPI.abort Then
    '            Return False
    '        End If

    '        'Dim dsObjectRead As New dsObject()
    '        'Dim compObjectRead As New compObject()
    '        'compObjectRead.getObject(IDObjectToUpdate, dsObjectRead, compObject.eTypSelObj.ID)
    '        'If dsObjectRead.tblObject.Rows.Count <> 1 Then
    '        '    Throw New Exception("syncContactsToITSCont: dsObjectRead.tblObject.Rows.Count<>1 is not possible! (rObjInterestedPerson.IDObject = '" + IDObjectToUpdate.ToString() + "')" + vbNewLine + InfoExcept)
    '        'End If
    '        'Dim rObj As dsObject.tblObjectRow = dsObjectRead.tblObject.Rows(0)
    '        'compObjectRead.getAdressen(rObj.ID, dsObjectRead, compObject.eTypSelAdr.idObject)
    '        'Dim rMainAdress As dsObject.tblAdressenRow = Nothing
    '        'Dim rSecondAdress As dsObject.tblAdressenRow = Nothing
    '        'For Each rAdr As dsObject.tblAdressenRow In dsObjectRead.tblAdressen
    '        '    If rAdr.Hauptwohnsitz Then
    '        '        rMainAdress = rAdr
    '        '    Else
    '        '        rSecondAdress = rAdr
    '        '    End If
    '        'Next
    '        'If rMainAdress Is Nothing Then
    '        '    Throw New Exception("syncContactsToITSCont: rMainAdress is nothing is not possible! (rObjInterestedPerson.IDObject = '" + IDObjectToUpdate.ToString() + "')" + vbNewLine + InfoExcept)
    '        'End If

    '        'compObjectRead.getObjectZusatz(rObj.ID, dsObjectRead, compObject.eTypSelZusatz.idObject)
    '        'Dim rObjzusatz As dsObject.tblObjectZusatzRow = dsObjectRead.tblObjectZusatz.Rows(0)

    '        'Dim LastChangeITSCont As Date = New Date(1900, 1, 1, 0, 0, 0)
    '        'If Not rObj.IsLastChangeNull() Then
    '        '    LastChangeITSCont = rObj.LastChange
    '        'End If
    '        'Dim LastChangeExchange As Date = New Date(1900, 1, 2, 0, 0, 0)
    '        'If Not rObj.IsLastChangeExchangeNull() Then
    '        '    LastChangeExchange = rObj.LastChangeExchange
    '        'End If

    '        'Dim bDoUpdateContactOnExchange As Boolean = False
    '        'If rObj.FromExchange And (Not rObj.IsDatumImportNull()) And ((rObj.IsLastChangeExchangeNull()) Or LastChangeITSCont > LastChangeExchange) Then
    '        '    bDoUpdateContactOnExchange = True
    '        'End If

    '        'If bDoUpdateContactOnExchange Then
    '        '    Dim bIDOutlookFoundOnServer As Boolean = False
    '        '    Dim isNew As Boolean = False
    '        '    Dim obj As Microsoft.Exchange.WebServices.Data.Item = Nothing
    '        '    Dim Contact As Microsoft.Exchange.WebServices.Data.Contact = Nothing
    '        '    If Not rObj.IsIDOutlookNull() AndAlso rObj.IDOutlook.Trim() <> "" Then
    '        '        Dim SearchFilterCollection As New List(Of SearchFilter)
    '        '        SearchFilterCollection.Add(New SearchFilter.ContainsSubstring(ItemSchema.Id, rObj.IDOutlook.Trim()))
    '        '        Dim searchFilter As SearchFilter = New SearchFilter.SearchFilterCollection(LogicalOperator.And, SearchFilterCollection.ToArray())
    '        '        Dim view As New ItemView(999999000)

    '        '        view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Ascending)
    '        '        view.Traversal = ItemTraversal.Shallow
    '        '        Dim findResults As FindItemsResults(Of Item)
    '        '        findResults = es.FindItems(TypeFolder, view)
    '        '        'If IsRoot Then
    '        '        '    findResults = es.FindItems(TypeFolder, view)
    '        '        'Else
    '        '        '    findResults = folderParent.FindItems(TypeFolder, view)
    '        '        'End If

    '        '        If General.ServicesTestmodus Then
    '        '            'Me.testAddContactToExchange(protokoll, protokollErr, rUserAccount, functionMarker, InfoExcept, dNow, es)
    '        '        End If

    '        '        Dim iCounterContactsUpdated As Integer = 0
    '        '        For Each obj2 As Microsoft.Exchange.WebServices.Data.Item In findResults
    '        '            If TypeOf obj2 Is Microsoft.Exchange.WebServices.Data.Contact Then
    '        '                'If findResults.TotalCount = 1 Then
    '        '                Dim SubjectTmp As String = ""
    '        '                Dim dReceived As Date = Nothing
    '        '                Try
    '        '                    obj = findResults.Items(0)
    '        '                    bIDOutlookFoundOnServer = True
    '        '                    isNew = False
    '        '                    If TypeOf obj Is Microsoft.Exchange.WebServices.Data.Contact Then
    '        '                        If (Not isNew) And (Not TypeOf obj Is Microsoft.Exchange.WebServices.Data.Contact) Then
    '        '                            Throw New Exception("syncContact: obj '" + obj.GetType().ToString() + "' is no Contact not possible! (IDoutlook='" + rObj.IDOutlook.Trim() + "')")
    '        '                        End If
    '        '                        Contact = obj
    '        '                        Contact.Load()
    '        '                        Me.updateITSContContactToExchange(rObj, rMainAdress, rSecondAdress, rObjzusatz, protokoll, protokollErr, Contact,
    '        '                                                            rUserAccount, functionMarker, InfoExcept, dNow, iCounterContactsUpdated)

    '        '                        'If Me.checkImportContactHasChangedOnExchange(rObj, rMainAdress, rObjzusatz, protokoll, protokollErr, Contact,
    '        '                        '                                                 rUserAccount, functionMarker, InfoExcept) Then
    '        '                        '    Me.addUpdateContactToITSCont(protokoll, protokollErr, Contact, dNow, rUserAccount,
    '        '                        '                                    SubjectTmp, functionMarker, dReceived, InfoExcept, False, dNow, True)
    '        '                        'End If
    '        '                    Else
    '        '                        Dim bNoContact As Boolean = True
    '        '                    End If

    '        '                Catch ex2 As Exception
    '        '                    Dim txtDetail As String = ""
    '        '                    txtDetail = "syncContactsToITSCont - Account: " + rUserAccount.UsrAuthentication.Trim() + ", Subject: " + SubjectTmp + ", ReceivedAt: " + dReceived.ToString() + "" + vbNewLine
    '        '                    If doExept Then
    '        '                        Dim sExcept As String = "strExceptionMark=" + functionMarker + vbNewLine + txtDetail + vbNewLine + vbNewLine + ex2.ToString()
    '        '                        Throw New Exception(sExcept)
    '        '                    Else
    '        '                        Dim sExcep As String = "syncContactsToITSCont-strExceptionMark=" + functionMarker + vbNewLine + txtDetail + vbNewLine + ex2.ToString()
    '        '                        If Not Me.delDoInfoUI Is Nothing Then
    '        '                            Me.delDoInfoUI.Invoke(sExcep.Trim(), True, False)
    '        '                        End If
    '        '                        General.iCounterExceptionsToSend += 1
    '        '                        General.ExceptionsToSend += General.iCounterExceptionsToSend.ToString() + ". Exception" + vbNewLine + sExcep.Trim() + vbNewLine + vbNewLine
    '        '                    End If
    '        '                End Try

    '        '                'ElseIf findResults.TotalCount = 0 Then
    '        '                '    bIDOutlookFoundOnServer = False
    '        '                '    isNew = True
    '        '                '    Contact = New Contact(es)
    '        '                'ElseIf findResults.TotalCount > 1 Then
    '        '                '    Throw New Exception("syncContact: indResults.TotalCount>1 is not possible! (rObjInterestedPerson.IDObject = '" + rObj.IDOutlook.Trim() + "')" + vbNewLine + InfoExcept)
    '        '                'End If
    '        '            ElseIf TypeOf obj2 Is Microsoft.Exchange.WebServices.Data.ContactGroup Then
    '        '                Dim bIsContactGroup As Boolean = True
    '        '            End If
    '        '        Next
    '        '    Else
    '        '        bIDOutlookFoundOnServer = False
    '        '        isNew = True
    '        '        Contact = New Contact(es)
    '        '    End If
    '        'End If

    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.syncContactsToITSCont: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function

    ''Public Function updateITSContContactToExchange(ByRef rObj As dsObject.tblObjectRow, rMainAdress As dsObject.tblAdressenRow,
    ''                                                    ByRef rSecondAdress As dsObject.tblAdressenRow,
    ''                                                    ByRef rObjzusatz As dsObject.tblObjectZusatzRow,
    ''                                                    ByRef protokoll As String, ByRef protokollErr As String,
    ''                                                    ByRef ContactToUpdate As Microsoft.Exchange.WebServices.Data.Contact,
    ''                                                    ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    ''                                                    ByRef functionMarker As String, ByRef InfoExcept As String,
    ''                                                    ByRef dNow As Date, ByRef iCounterContactsUpdated As Integer) As Boolean
    ''    Try
    ''        Dim InfoContact As String = ""
    ''        If rObj.IsPerson Then
    ''            ContactToUpdate.Surname = rObj.Vorname.Trim()
    ''            ContactToUpdate.GivenName = rObj.Nachname.Trim()
    ''            ContactToUpdate.GivenName = ContactToUpdate.GivenName + " " + ContactToUpdate.Surname
    ''            ContactToUpdate.NickName = ContactToUpdate.Surname
    ''            ContactToUpdate.CompanyName = rObj.NameErweitert.Trim()
    ''            ContactToUpdate.DisplayName = ContactToUpdate.GivenName
    ''            InfoContact = ContactToUpdate.GivenName
    ''        Else
    ''            ContactToUpdate.GivenName = rObj.Name.Trim()
    ''            ContactToUpdate.CompanyName = rObj.NameErweitert.Trim()
    ''            ContactToUpdate.NickName = ContactToUpdate.CompanyName
    ''            ContactToUpdate.Surname = ""
    ''            ContactToUpdate.DisplayName = ContactToUpdate.CompanyName
    ''            InfoContact = ContactToUpdate.CompanyName
    ''        End If
    ''        ContactToUpdate.JobTitle = rObj.Titel.Trim()
    ''        'ContactToUpdate.Body = New MessageBody(BodyType.HTML, "")
    ''        ContactToUpdate.BusinessHomePage = rMainAdress.Web.Trim()

    ''        'Dim EMailAdress1 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        'If ContactToUpdate.EmailAddresses.Contains(EmailAddressKey.EmailAddress1) Then
    ''        '    EMailAdress1 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1)
    ''        'Else
    ''        '    ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1) = New EmailAddress()
    ''        '    EMailAdress1 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1)
    ''        'End If
    ''        'Dim EMailAdress2 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        'If ContactToUpdate.EmailAddresses.Contains(EmailAddressKey.EmailAddress2) Then
    ''        '    EMailAdress2 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2)
    ''        'Else
    ''        '    ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2) = New EmailAddress()
    ''        '    EMailAdress2 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2)
    ''        'End If
    ''        'Dim EMailAdress3 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        'If ContactToUpdate.EmailAddresses.Contains(EmailAddressKey.EmailAddress3) Then
    ''        '    EMailAdress3 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3)
    ''        'Else
    ''        '    ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3) = New EmailAddress()
    ''        '    EMailAdress3 = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3)
    ''        'End If

    ''        If rMainAdress.EmailBeruflich.Trim() <> "" Then
    ''            ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1) = New EmailAddress()
    ''            Dim EMailAdress1 As Microsoft.Exchange.WebServices.Data.EmailAddress = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1)
    ''            EMailAdress1.Address = rMainAdress.EmailBeruflich.Trim()
    ''        End If
    ''        If rMainAdress.Email.Trim() <> "" Then
    ''            ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2) = New EmailAddress()
    ''            Dim EMailAdress2 As Microsoft.Exchange.WebServices.Data.EmailAddress = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2)
    ''            EMailAdress2.Address = rMainAdress.Email.Trim()
    ''        End If
    ''        If rMainAdress.EmailBeruflich2.Trim() <> "" Then
    ''            ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3) = New EmailAddress()
    ''            Dim EMailAdress3 As Microsoft.Exchange.WebServices.Data.EmailAddress = ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3)
    ''            EMailAdress3.Address = rMainAdress.EmailBeruflich2.Trim()
    ''        End If


    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Home) Then
    ''        '    phyAdress_Home = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home) = New PhysicalAddressEntry()
    ''        '    phyAdress_Home = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        'End If
    ''        'Dim phyAdress_Business As PhysicalAddressEntry = Nothing
    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Business) Then
    ''        '    phyAdress_Business = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business) = New PhysicalAddressEntry()
    ''        '    phyAdress_Business = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        'End If
    ''        'Dim phyAdress_Other As PhysicalAddressEntry = Nothing
    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Other) Then
    ''        '    phyAdress_Other = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other) = New PhysicalAddressEntry()
    ''        '    phyAdress_Other = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        'End If

    ''        'Dim phyAdress_Home As PhysicalAddressEntry = Nothing
    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Home) Then
    ''        '    phyAdress_Home = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home) = New PhysicalAddressEntry()
    ''        '    phyAdress_Home = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        'End If
    ''        'Dim phyAdress_Business As PhysicalAddressEntry = Nothing
    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Business) Then
    ''        '    phyAdress_Business = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business) = New PhysicalAddressEntry()
    ''        '    phyAdress_Business = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        'End If
    ''        'Dim phyAdress_Other As PhysicalAddressEntry = Nothing
    ''        'If ContactToUpdate.PhysicalAddresses.Contains(PhysicalAddressKey.Other) Then
    ''        '    phyAdress_Other = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        'Else
    ''        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other) = New PhysicalAddressEntry()
    ''        '    phyAdress_Other = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        'End If

    ''        ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business) = New PhysicalAddressEntry()
    ''        Dim phyAdress_Business As PhysicalAddressEntry = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        phyAdress_Business.PostalCode = rMainAdress.PLZ.Trim()
    ''        phyAdress_Business.City = rMainAdress.Ort.Trim()
    ''        phyAdress_Business.Street = rMainAdress.Straße.Trim()
    ''        phyAdress_Business.CountryOrRegion = ""
    ''        phyAdress_Business.State = rMainAdress.LandKZ.Trim()

    ''        If Not rSecondAdress Is Nothing Then
    ''            ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home) = New PhysicalAddressEntry()
    ''            Dim phyAdress_Home As PhysicalAddressEntry = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''            phyAdress_Home.PostalCode = rSecondAdress.PLZ.Trim()
    ''            phyAdress_Home.City = rSecondAdress.Ort.Trim()
    ''            phyAdress_Home.Street = rSecondAdress.Straße.Trim()
    ''            phyAdress_Home.CountryOrRegion = ""
    ''            phyAdress_Home.State = rSecondAdress.LandKZ.Trim()
    ''        Else
    ''            ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home) = New PhysicalAddressEntry()
    ''            Dim phyAdress_Home As PhysicalAddressEntry = ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home)
    ''            phyAdress_Home.PostalCode = ""
    ''            phyAdress_Home.City = ""
    ''            phyAdress_Home.Street = ""
    ''            phyAdress_Home.CountryOrRegion = ""
    ''            phyAdress_Home.State = ""
    ''        End If

    ''        Dim PrimaryPhone As String = ""
    ''        If rMainAdress.TelMobil.Trim() <> "" Then
    ''            If PrimaryPhone.Trim() = "" Then
    ''                PrimaryPhone = rMainAdress.TelMobil.Trim()
    ''            End If
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.MobilePhone) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.MobilePhone) = rMainAdress.TelMobil.Trim()
    ''        End If

    ''        If rMainAdress.TelGesch.Trim() <> "" Then
    ''            If PrimaryPhone.Trim() = "" Then
    ''                PrimaryPhone = rMainAdress.TelGesch.Trim()
    ''            End If
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone) = rMainAdress.TelGesch.Trim()
    ''        End If

    ''        If rMainAdress.TelGesch2.Trim() <> "" Then
    ''            If PrimaryPhone.Trim() = "" Then
    ''                PrimaryPhone = rMainAdress.TelGesch2.Trim()
    ''            End If
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone2) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone2) = rMainAdress.TelGesch2.Trim()
    ''        End If

    ''        If rMainAdress.TelPrivat.Trim() <> "" Then
    ''            If PrimaryPhone.Trim() = "" Then
    ''                PrimaryPhone = rMainAdress.TelPrivat.Trim()
    ''            End If
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomePhone) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomePhone) = rMainAdress.TelPrivat.Trim()
    ''        End If

    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomePhone2) = New PhoneNumberKey()
    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomePhone2) = ""

    ''        If PrimaryPhone.Trim() <> "" Then
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.PrimaryPhone) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.PrimaryPhone) = PrimaryPhone

    ''            'ContactToUpdate.PhoneNumbers(PhoneNumberKey.CarPhone) = New PhoneNumberKey()
    ''            'ContactToUpdate.PhoneNumbers(PhoneNumberKey.CarPhone) = PrimaryPhone
    ''        End If

    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.CompanyMainPhone) = New PhoneNumberKey()
    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.CompanyMainPhone) = PrimaryPhone

    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.AssistantPhone) = New PhoneNumberKey()
    ''        'ContactToUpdate.PhoneNumbers(PhoneNumberKey.AssistantPhone) = ""

    ''        If rMainAdress.FaxBeruflich.Trim() <> "" Then
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessFax) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessFax) = rMainAdress.FaxBeruflich.Trim()
    ''        End If
    ''        If rMainAdress.Fax.Trim() <> "" Then
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomeFax) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomeFax) = rMainAdress.Fax.Trim()
    ''        End If
    ''        If rMainAdress.Fax2.Trim() <> "" Then
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.OtherFax) = New PhoneNumberKey()
    ''            ContactToUpdate.PhoneNumbers(PhoneNumberKey.OtherFax) = rMainAdress.Fax2.Trim()
    ''        End If

    ''        'Dim mode As SendInvitationsOrCancellationsMode
    ''        'mode = SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy
    ''        ContactToUpdate.Update(ConflictResolutionMode.AutoResolve)

    ''        Dim dsObjectUpdate As New dsObject()
    ''        Dim compObjectUpdate As New compObject()
    ''        compObjectUpdate.getObject(rObj.ID, dsObjectUpdate, compObject.eTypSelObj.ID)
    ''        Dim rObjUpdate As dsObject.tblObjectRow = dsObjectUpdate.tblObject.Rows(0)
    ''        rObjUpdate.LastChangeExchange = Now.AddSeconds(1)
    ''        compObjectUpdate.daObject.Update(dsObjectUpdate.tblObject)

    ''        iCounterContactsUpdated += 1

    ''        Dim txtErr As String = "Contact '" + InfoContact + "' was synchronized from ITSCont to Exchange! (User-Account=" + rUserAccount.Usr + ")"
    ''        Me.addProtokoll(txtErr, protokoll, True, False)
    ''        If Not Me.delDoInfoUI Is Nothing Then
    ''            Me.delDoInfoUI.Invoke(txtErr, False, False)
    ''        End If

    ''        Return True

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.updateITSContContactToExchange: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function

    'Public Function searchContactGroup(ByRef es As ExchangeService, ByRef NameToSearch As String) As ContactGroup
    '    Try
    '        Dim view As New ItemView(9999)
    '        Dim findResults As FindItemsResults(Of Item)
    '        findResults = es.FindItems(WellKnownFolderName.Contacts, view)
    '        For Each itm As Object In findResults
    '            If TypeOf itm Is Microsoft.Exchange.WebServices.Data.ContactGroup Then
    '                Dim ContactGroup As Microsoft.Exchange.WebServices.Data.ContactGroup = itm
    '                If ContactGroup.DisplayName.Trim().ToLower().Equals(NameToSearch.Trim().ToLower()) Then
    '                    ContactGroup.Load()
    '                    Return ContactGroup
    '                End If
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.searchContactGroup: " + ex.ToString())
    '    End Try
    'End Function

    ''Public Function addUpdateContactToITSCont(ByRef protokoll As String, ByRef protokollErr As String,
    ''                                            ByRef Contact As Microsoft.Exchange.WebServices.Data.Contact, ByRef dNow As Date,
    ''                                            ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    ''                                            ByRef SubjectTmp As String, ByRef functionMarker As String, ByRef dReceived As Date,
    ''                                            ByRef InfoExcept As String,
    ''                                            ByRef checkLastRecieve As Boolean, ByRef datLastReceived As Date,
    ''                                            ByRef abortIfEMailIsInDB As Boolean) As Boolean
    ''    Try
    ''        Dim IDOutlookTmp2 As String = Me.IsNull(Contact.Id.UniqueId, False, "UniqueId")
    ''        functionMarker += "1.2;"
    ''        If IDOutlookTmp2 Is Nothing AndAlso IDOutlookTmp2.Trim() = "" Then
    ''            Throw New Exception("Contact.Id=Nothing for Contact '" + SubjectTmp.Trim() + "!")
    ''        End If
    ''        functionMarker += "1.3;"

    ''        'If abortIfEMailIsInDB Then
    ''        '    functionMarker += "1.8;"
    ''        '    Return False
    ''        'End If

    ''        Dim dsPlanCheckDeleted2 As New dsPlan()
    ''        Me.compPlanRead2.getPlanStatus(IDOutlookTmp2.Trim(), compPlan.eTypSelPlan.MessageIdNoUser, dsPlanCheckDeleted2, compPlan.eStatusPlan.deleted, rUserAccount.Usr, Nothing)
    ''        If dsPlanCheckDeleted2.planStatus.Rows.Count > 0 Then
    ''            If clPlan.protWindowNormalOn Then
    ''                Dim txtErr As String = "Info: Contact '" + SubjectTmp + "' was deleted from User '" + rUserAccount.Usr + "'!"
    ''                Me.addProtokoll(txtErr, protokoll, True, False)
    ''                Me.addProtokoll(txtErr, protokollErr, True, False)
    ''                If Not Me.delDoInfoUI Is Nothing Then
    ''                    Me.delDoInfoUI.Invoke(txtErr, False, False)
    ''                End If
    ''            End If
    ''            functionMarker += "1.5;"
    ''            Return False
    ''        End If

    ''        functionMarker += "1.6;"

    ''        Dim dsObjectUpdate As New dsSearchObjects()
    ''        Dim compObjectUpdate As New compObject()

    ''        Dim LastModifiedTime As Date = Me.IsNull(Contact.LastModifiedTime, False, "LastModifiedTime")
    ''        Dim doUpdateObjImport As Boolean = False
    ''        Dim existsInblObjektImport1 As Boolean = False
    ''        Dim existsInblObjektImport2 As Boolean = False
    ''        Me.checkContactHasModified(IDOutlookTmp2, Nothing, Contact, compObjectUpdate, dsObjectUpdate, SubjectTmp, InfoExcept, protokoll, protokollErr,
    ''                                   LastModifiedTime, doUpdateObjImport, existsInblObjektImport1)
    ''        If Not doUpdateObjImport Then
    ''            Dim notUpdate As Boolean = True
    ''            'Return False
    ''        End If

    ''        functionMarker += "1.7;"
    ''        Dim compObjectCheck2 As New compObject()
    ''        Dim dsObjectCheck2 As New dsObject()
    ''        compObjectCheck2.getObject(Nothing, dsObjectCheck2, compObject.eTypSelObj.IDOutlook, compObject.eTypObj.none, IDOutlookTmp2.Trim())
    ''        If (Not existsInblObjektImport1) And dsObjectCheck2.tblObject.Rows.Count > 0 Then
    ''            For Each rObj As dsObject.tblObjectRow In dsObjectCheck2.tblObject
    ''                If Not rObj.IsIDObjectImnportNull() Then
    ''                    doUpdateObjImport = False
    ''                    Me.checkContactHasModified(IDOutlookTmp2, rObj.IDObjectImnport, Contact, compObjectUpdate, dsObjectUpdate, SubjectTmp, InfoExcept, protokoll, protokollErr,
    ''                                               LastModifiedTime, doUpdateObjImport, existsInblObjektImport2)
    ''                    If Not doUpdateObjImport Then
    ''                        Dim notUpdate As Boolean = True
    ''                        'Return False
    ''                    End If
    ''                End If
    ''            Next

    ''            'If clPlan.protWindowNormalOn Then
    ''            '    'Dim txtInfoIsImported As String = "Info: E-Mail '" + messageHeaders.Subject.Trim() + "' vom '" + dReceived.ToString() + "' von '" + messageHeaders.From.MailAddress.Address.Trim() + "' wurde bereits eingespielt!"
    ''            '    Dim txtInfoIsImported As String = "Info: Contact '" + SubjectTmp.Trim() + "' is imported in Table tblObject!"
    ''            '    Me.addProtokoll(txtInfoIsImported, protokoll, True, False)
    ''            '    Me.addProtokoll(txtInfoIsImported, protokollErr, True, False)
    ''            '    If Not Me.delDoInfoUI Is Nothing Then
    ''            '        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    ''            '    End If
    ''            'End If
    ''        End If
    ''        dsObjectCheck2.Clear()

    ''        If (existsInblObjektImport1 Or existsInblObjektImport2) And (Not doUpdateObjImport) Then
    ''            Return False
    ''        End If

    ''        If Not doUpdateObjImport Then
    ''            Dim rNew As dsSearchObjects.tblObjectImportRow = compObjectUpdate.getNewRowObjectImport(dsObjectUpdate)
    ''            Me.addUpdateContactToITSContRow(IDOutlookTmp2, rNew, protokoll, protokollErr, Contact, dNow, rUserAccount, SubjectTmp, functionMarker,
    ''                                            dReceived, InfoExcept, checkLastRecieve, datLastReceived, abortIfEMailIsInDB,
    ''                                            dsObjectUpdate, compObjectUpdate, False)
    ''        Else
    ''            For Each rObjImport As dsSearchObjects.tblObjectImportRow In dsObjectUpdate.tblObjectImport
    ''                Me.addUpdateContactToITSContRow(IDOutlookTmp2, rObjImport, protokoll, protokollErr, Contact, dNow, rUserAccount, SubjectTmp, functionMarker,
    ''                                                dReceived, InfoExcept, checkLastRecieve, datLastReceived, abortIfEMailIsInDB,
    ''                                                dsObjectUpdate, compObjectUpdate, True)
    ''            Next
    ''        End If

    ''        Return True

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.addUpdateContactOnServer: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function

    ''Public Sub checkContactHasModified(ByRef IDOutlookTmp As String, ByRef IDImportObject As System.Guid, ByRef Contact As Contact, ByRef compObjectUpdate As compObject,
    ''                                        ByRef dsObjectUpdate As dsSearchObjects, SubjectTmp As String, ByRef InfoExcept As String,
    ''                                        ByRef Protokoll As String, ByRef ProtokollErr As String,
    ''                                        ByRef LastModifiedTime As Date,
    ''                                        ByRef doUpdateObjImport As Boolean,
    ''                                        ByRef existsInblObjektImport As Boolean)
    ''    Try
    ''        dsObjectUpdate = New dsSearchObjects()
    ''        If IDImportObject = Nothing Then
    ''            compObjectUpdate.getObjectImport("", Nothing, dsObjectUpdate, IDOutlookTmp.Trim(), -1, "", Nothing)
    ''        Else
    ''            compObjectUpdate.getObjectImport("", IDImportObject, dsObjectUpdate, "", -1, "", Nothing)
    ''        End If
    ''        If dsObjectUpdate.tblObjectImport.Rows.Count > 0 Then
    ''            If dsObjectUpdate.tblObjectImport.Rows.Count <> 1 Then
    ''                Dim txtInfoIsImported As String = "Info: Contact '" + SubjectTmp.Trim() + "' (IDOutlookTmp='" + IDOutlookTmp.Trim() + "') is exists in Table tblObjectimport more than one!"
    ''                Me.addProtokoll(txtInfoIsImported, Protokoll, True, False)
    ''                Me.addProtokoll(txtInfoIsImported, ProtokollErr, True, False)
    ''                If Not Me.delDoInfoUI Is Nothing Then
    ''                    Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    ''                End If
    ''            End If

    ''            existsInblObjektImport = True
    ''            'Dim rObjImport As dsSearchObjects.tblObjectImportRow = dsObjectCheck.tblObjectImport.Rows(0)
    ''            For Each rObjImport As dsSearchObjects.tblObjectImportRow In dsObjectUpdate.tblObjectImport
    ''                If Not rObjImport.IsLastChangeOnExchangeNull() AndAlso LastModifiedTime > rObjImport.LastChangeOnExchange Then
    ''                    doUpdateObjImport = True
    ''                End If
    ''            Next

    ''            'If clPlan.protWindowNormalOn Then
    ''            '    'Dim txtInfoIsImported As String = "Info: E-Mail '" + messageHeaders.Subject.Trim() + "' vom '" + dReceived.ToString() + "' von '" + messageHeaders.From.MailAddress.Address.Trim() + "' wurde bereits eingespielt!"
    ''            '    Dim txtInfoIsImported As String = "Info: Contact '" + SubjectTmp.Trim() + "' is imported in Table tblObjectImport!"
    ''            '    Me.addProtokoll(txtInfoIsImported, protokoll, True, False)
    ''            '    Me.addProtokoll(txtInfoIsImported, protokollErr, True, False)
    ''            '    If Not Me.delDoInfoUI Is Nothing Then
    ''            '        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    ''            '    End If
    ''            'End If
    ''            'If abortIfEMailIsInDB Then
    ''            '    functionMarker += "1.7;"
    ''            '    Return False
    ''            'End If
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkContactHasModified: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    ''    End Try
    ''End Sub

    ''Public Function addUpdateContactToITSContRow(ByRef IDOutlookTmp As String, ByRef rNewUpdate As dsSearchObjects.tblObjectImportRow,
    ''                                                ByRef protokoll As String, ByRef protokollErr As String,
    ''                                                ByRef Contact As Microsoft.Exchange.WebServices.Data.Contact, ByRef dNow As Date,
    ''                                                ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    ''                                                ByRef SubjectTmp As String, ByRef functionMarker As String, ByRef dReceived As Date,
    ''                                                ByRef InfoExcept As String,
    ''                                                ByRef checkLastRecieve As Boolean, ByRef datLastReceived As Date,
    ''                                                ByRef abortIfEMailIsInDB As Boolean,
    ''                                                ByRef dsObjectUpdate As dsSearchObjects, compObjectUpdate As compObject,
    ''                                                ByRef IsUpdate As Boolean) As Boolean
    ''    Try
    ''        SubjectTmp = ""
    ''        SubjectTmp = Me.IsNull(Contact.DisplayName, False, "DisplayName")

    ''        If SubjectTmp.Trim().ToLower().Contains(("Theo2").Trim().ToLower()) Then
    ''            Dim sStop As Boolean = True
    ''        End If

    ''        dReceived = Me.IsNull(Contact.DateTimeCreated, False, "DateTimeCreated")
    ''        If dReceived = Nothing Then
    ''            Throw New Exception("Contact.dReceived=Nothing for Contact '" + SubjectTmp.Trim() + "'!")
    ''        End If
    ''        functionMarker += "0;"              'lthxy
    ''        'If checkLastRecieve Then
    ''        '    'If Not rUserAccount.IslastReceiveNull() Then
    ''        '    Dim lastReceiveBack As Date = datLastReceived.AddHours(-168)
    ''        '    If dReceived <= lastReceiveBack Then
    ''        '        functionMarker += "0.1;"
    ''        '        Return False
    ''        '    End If
    ''        '    'End If
    ''        'End If
    ''        If dReceived.Date < cOutlookWebAPI.dateExit.Date Then
    ''            Return False
    ''        End If
    ''        functionMarker += "0.2;"

    ''        Dim LastNameTmp As String = ""      'Me.IsNull(Contact.PhoneticLastName, False, "PhoneticLastName")
    ''        Dim FirstNameTmp As String = ""     'Me.IsNull(Contact.PhoneticFirstName, False, "PhoneticFirstName")
    ''        Dim CompleteName As String = ""
    ''        Dim TitleTmp As String = ""         'Contact.JobTitle.Trim()
    ''        If Not Contact.CompleteName Is Nothing Then
    ''            LastNameTmp = Me.IsNull(Contact.CompleteName.Surname, False, "Surname")
    ''            FirstNameTmp = Me.IsNull(Contact.CompleteName.GivenName, False, "GivenName")
    ''            TitleTmp = Me.IsNull(Contact.CompleteName.Title, False, "Title")
    ''        Else
    ''            Dim sNoCompleteName As Boolean = True
    ''        End If

    ''        Dim GivenName As String = Me.IsNull(Contact.GivenName, False, "GivenName")
    ''        Dim NickName As String = Me.IsNull(Contact.NickName, False, "NickName")
    ''        Dim CompanyName As String = Me.IsNull(Contact.CompanyName, False, "CompanyName")

    ''        functionMarker += "1.1;"

    ''        'rNewUpdate.ID = System.Guid.NewGuid()
    ''        rNewUpdate.IDOutlook = IDOutlookTmp.Trim()
    ''        If FirstNameTmp.Trim() <> "" And LastNameTmp.Trim() <> "" Then
    ''            rNewUpdate.IsPerson = True
    ''            rNewUpdate.FirstName = FirstNameTmp.Trim()
    ''            rNewUpdate.FirstNameSecond = ""
    ''            rNewUpdate.LastName = LastNameTmp.Trim()
    ''            SubjectTmp = rNewUpdate.LastName.Trim() + " " + rNewUpdate.FirstName.Trim()
    ''            rNewUpdate.Firma = ""

    ''        ElseIf FirstNameTmp.Trim() = "" And LastNameTmp.Trim() <> "" Then
    ''            rNewUpdate.IsPerson = False
    ''            rNewUpdate.FirstName = ""
    ''            rNewUpdate.FirstNameSecond = ""
    ''            rNewUpdate.LastName = LastNameTmp.Trim()
    ''            SubjectTmp = rNewUpdate.LastName.Trim()
    ''            rNewUpdate.Firma = LastNameTmp.Trim()

    ''        ElseIf FirstNameTmp.Trim() <> "" And LastNameTmp.Trim() = "" Then
    ''            rNewUpdate.IsPerson = False
    ''            rNewUpdate.FirstName = ""
    ''            rNewUpdate.FirstNameSecond = ""
    ''            rNewUpdate.LastName = FirstNameTmp.Trim()
    ''            SubjectTmp = rNewUpdate.LastName.Trim()
    ''            rNewUpdate.Firma = FirstNameTmp.Trim()

    ''        ElseIf FirstNameTmp.Trim() = "" And LastNameTmp.Trim() = "" Then
    ''            Me.searchNameAutoForContact(rNewUpdate, Contact)
    ''            SubjectTmp = rNewUpdate.LastName.Trim() + " " + rNewUpdate.FirstName.Trim()
    ''        Else
    ''            Me.searchNameAutoForContact(rNewUpdate, Contact)
    ''            SubjectTmp = rNewUpdate.LastName.Trim() + " " + rNewUpdate.FirstName.Trim()
    ''        End If

    ''        If CompanyName.Trim() <> "" Then
    ''            rNewUpdate.Firma = CompanyName.Trim()
    ''        End If
    ''        If TitleTmp.Trim() <> "" Then
    ''            rNewUpdate.Title = TitleTmp.Trim()
    ''        End If

    ''        If Not IsUpdate Then
    ''            rNewUpdate.BriefanredeExcel = ""
    ''            rNewUpdate.Briefanrede = "Sehr geehrte Damen und Herren"
    ''        End If

    ''        Dim BusinessHomePage As String = Me.IsNull(Contact.BusinessHomePage, False, "BusinessHomePage")
    ''        rNewUpdate.Website = BusinessHomePage.Trim()

    ''        Dim EMailAdress1 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress1) Then
    ''            EMailAdress1 = Contact.EmailAddresses(EmailAddressKey.EmailAddress1)
    ''        End If
    ''        Dim EMailAdress2 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress2) Then
    ''            EMailAdress2 = Contact.EmailAddresses(EmailAddressKey.EmailAddress2)
    ''        End If
    ''        Dim EMailAdress3 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress3) Then
    ''            EMailAdress3 = Contact.EmailAddresses(EmailAddressKey.EmailAddress3)
    ''        End If

    ''        If (Not EMailAdress1 Is Nothing) AndAlso Me.IsNull(EMailAdress1.Address, False, "Address") <> "" Then
    ''            rNewUpdate.EMailBeruflich = EMailAdress1.Address.Trim()
    ''            rNewUpdate.EMailBenachrichtigung = rNewUpdate.EMailBeruflich.Trim()
    ''        End If
    ''        If (Not EMailAdress2 Is Nothing) AndAlso Me.IsNull(EMailAdress2.Address, False, "Address") <> "" Then
    ''            rNewUpdate.EMailBeruflich2 = EMailAdress2.Address.Trim()
    ''            If rNewUpdate.EMailBenachrichtigung.Trim() = "" Then
    ''                rNewUpdate.EMailBenachrichtigung = rNewUpdate.EMailBeruflich2.Trim()
    ''            End If
    ''        End If
    ''        If (Not EMailAdress3 Is Nothing) AndAlso Me.IsNull(EMailAdress3.Address, False, "Address") <> "" Then
    ''            rNewUpdate.EMailPrivate = EMailAdress3.Address.Trim()
    ''            If rNewUpdate.EMailBenachrichtigung.Trim() = "" Then
    ''                rNewUpdate.EMailBenachrichtigung = rNewUpdate.EMailPrivate.Trim()
    ''            End If
    ''        End If

    ''        Dim phyAdress_Home As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Home) Then
    ''            phyAdress_Home = Contact.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        End If
    ''        Dim phyAdress_Business As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Business) Then
    ''            phyAdress_Business = Contact.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        End If
    ''        Dim phyAdress_Other As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Other) Then
    ''            phyAdress_Other = Contact.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        End If

    ''        If Not phyAdress_Business Is Nothing Then
    ''            rNewUpdate.adr1PLZ = Me.IsNull(phyAdress_Business.PostalCode, False, "PostalCode")
    ''            rNewUpdate.adr1Ort = Me.IsNull(phyAdress_Business.City, False, "City")
    ''            rNewUpdate.adr1Strasse = Me.IsNull(phyAdress_Business.Street, False, "Street")
    ''            'rNew.adr1LandKZ = Me.IsNull(phyAdress_Business.CountryOrRegion, False, "CountryOrRegion")   
    ''            rNewUpdate.adr1LandExcel = Me.IsNull(phyAdress_Business.State, False, "State")
    ''        End If

    ''        rNewUpdate.adr1IsMain = True
    ''        Dim adr1LandExcelTmp As String = ITSContBusiness.getCountryImportObjects(rNewUpdate.adr1LandExcel.Trim())
    ''        If adr1LandExcelTmp.Trim() <> "" Then
    ''            rNewUpdate.Nationalität = adr1LandExcelTmp.Trim()
    ''            rNewUpdate.adr1LandKZ = rNewUpdate.Nationalität
    ''            rNewUpdate.Sprache = rNewUpdate.adr1LandKZ
    ''        Else
    ''            rNewUpdate.Nationalität = ""
    ''            rNewUpdate.Sprache = ""
    ''        End If

    ''        If Not phyAdress_Home Is Nothing Then
    ''            rNewUpdate.adr2PLZ = Me.IsNull(phyAdress_Home.PostalCode, False, "PostalCode")
    ''            rNewUpdate.adr2Ort = Me.IsNull(phyAdress_Home.City, False, "City")
    ''            rNewUpdate.adr2Strasse = Me.IsNull(phyAdress_Home.Street, False, "Street")
    ''            'rNew.adr1LandKZ = Me.IsNull(phyAdress_Home.CountryOrRegion, False, "CountryOrRegion")  
    ''            rNewUpdate.adr2LandExcel = Me.IsNull(phyAdress_Home.State, False, "State")
    ''        End If

    ''        If Not phyAdress_Other Is Nothing Then
    ''            Dim PostalCode_Other As String = Me.IsNull(phyAdress_Other.PostalCode, False, "PostalCode")
    ''            Dim City_Other As String = Me.IsNull(phyAdress_Other.City, False, "City")
    ''            Dim Street_Other As String = Me.IsNull(phyAdress_Other.Street, False, "Street")
    ''            Dim CountryOrRegion_Other As String = Me.IsNull(phyAdress_Other.CountryOrRegion, False, "CountryOrRegion")
    ''            Dim State_Other As String = Me.IsNull(phyAdress_Other.State, False, "State")

    ''            If PostalCode_Other.Trim() <> "" Or City_Other.Trim() <> "" Or Street_Other.Trim() <> "" Or State_Other.Trim() <> "" Then
    ''                rNewUpdate.Info += "Other Adress from Exchange-Server: " + State_Other.Trim() + " - " + PostalCode_Other.Trim() + " " + City_Other.Trim() + " " + Street_Other.Trim() + ""
    ''                'Dim txtInfoIs3Adress As String = "Info: Contact '" + SubjectTmp.Trim() + "' has 3 Adresses (phyAdress_Other)!"
    ''                'Me.addProtokoll(txtInfoIs3Adress, protokoll, True, False)
    ''            End If
    ''        End If


    ''        Dim BusinessPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.BusinessPhone) Then
    ''            BusinessPhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.BusinessPhone), False, "BusinessPhone")
    ''        End If
    ''        Dim BusinessPhone2 As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.BusinessPhone2) Then
    ''            BusinessPhone2 = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.BusinessPhone2), False, "BusinessPhone2")
    ''        End If
    ''        Dim HomePhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.HomePhone) Then
    ''            HomePhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.HomePhone), False, "HomePhone")
    ''        End If
    ''        Dim HomePhone2 As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.HomePhone2) Then
    ''            HomePhone2 = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.HomePhone2), False, "HomePhone2")
    ''        End If
    ''        Dim MobilePhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.MobilePhone) Then
    ''            MobilePhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.MobilePhone), False, "MobilePhone")
    ''        End If
    ''        Dim PrimaryPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.PrimaryPhone) Then
    ''            PrimaryPhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.PrimaryPhone), False, "PrimaryPhone")
    ''        End If
    ''        Dim CarPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.CarPhone) Then
    ''            CarPhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.CarPhone), False, "CarPhone")
    ''        End If
    ''        Dim CompanyMainPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.CompanyMainPhone) Then
    ''            CompanyMainPhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.CompanyMainPhone), False, "CompanyMainPhone")
    ''        End If
    ''        Dim AssistantPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.AssistantPhone) Then
    ''            AssistantPhone = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.AssistantPhone), False, "AssistantPhone")
    ''        End If


    ''        If BusinessPhone.Trim() <> "" Then
    ''            rNewUpdate.TelGeschäftlich = BusinessPhone.Trim()
    ''        End If
    ''        If BusinessPhone2.Trim() <> "" Then
    ''            rNewUpdate.TelMobile = BusinessPhone2.Trim()
    ''        End If
    ''        If MobilePhone.Trim() <> "" Then
    ''            rNewUpdate.TelMobile2 = MobilePhone.Trim()
    ''        End If
    ''        If HomePhone.Trim() <> "" Then
    ''            rNewUpdate.TelPrivate = HomePhone.Trim()
    ''        End If

    ''        If CompanyMainPhone.Trim() <> "" Then
    ''            Me.setPhone(CompanyMainPhone.Trim(), rNewUpdate)
    ''        End If
    ''        If PrimaryPhone.Trim() <> "" Then
    ''            Me.setPhone(PrimaryPhone.Trim(), rNewUpdate)
    ''        End If
    ''        If HomePhone2.Trim() <> "" Then
    ''            Me.setPhone(HomePhone2.Trim(), rNewUpdate)
    ''        End If
    ''        If CarPhone.Trim() <> "" Then
    ''            Me.setPhone(CarPhone.Trim(), rNewUpdate)
    ''        End If
    ''        If AssistantPhone.Trim() <> "" Then
    ''            Me.setPhone(AssistantPhone.Trim(), rNewUpdate)
    ''        End If


    ''        Dim BusinessFax As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.BusinessFax) Then
    ''            BusinessFax = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.BusinessFax), False, "BusinessFax")
    ''        End If
    ''        Dim HomeFax As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.HomeFax) Then
    ''            HomeFax = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.HomeFax), False, "HomeFax")
    ''        End If
    ''        Dim OtherFax As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.OtherFax) Then
    ''            OtherFax = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.OtherFax), False, "OtherFax")
    ''        End If
    ''        If BusinessFax.Trim() <> "" Then
    ''            rNewUpdate.Fax = BusinessFax.Trim()
    ''        End If
    ''        If HomeFax.Trim() <> "" Then
    ''            If rNewUpdate.Fax.Trim() = "" Then
    ''                rNewUpdate.Fax = HomeFax.Trim()
    ''            Else
    ''                rNewUpdate.Info += "Fax: " + HomeFax.Trim() + vbNewLine
    ''            End If
    ''        End If
    ''        If OtherFax.Trim() <> "" Then
    ''            If rNewUpdate.Fax.Trim() = "" Then
    ''                rNewUpdate.Fax = OtherFax.Trim()
    ''            Else
    ''                rNewUpdate.Info += "Fax: " + OtherFax.Trim() + vbNewLine
    ''            End If
    ''        End If

    ''        'rNewUpdate.SetIDBetreuerNull()
    ''        If Not IsUpdate Then
    ''            rNewUpdate.IDBerufsgruppe = 27
    ''            rNewUpdate.IDBeruf = 1200
    ''            rNewUpdate.IDStatus = 19
    ''            rNewUpdate.SetIDVermittlertypNull()
    ''            rNewUpdate.Quelle = "Exchange"
    ''            rNewUpdate.EntdecktAm = dReceived.Date
    ''            rNewUpdate.FromExchange = True
    ''            'rNewUpdate.SetImportedObjectNull()
    ''            rNewUpdate.Imported = False
    ''            rNewUpdate.SetImportedAtNull()
    ''            rNewUpdate.ImportedFrom = rUserAccount.Usr.Trim()                ' actUsr.rUsr.usr.Trim()
    ''            rNewUpdate.From = dNow
    ''            rNewUpdate.DateImportedFromExchange = dNow
    ''            rNewUpdate.Action = Enums.eActionImport.NewObject.ToString()

    ''            Dim rObj As dsObject.tblObjectRow = compObjectUpdate.getObjectRow(Nothing, compObject.eTypSelObj.usr, compObject.eTypObj.none, rNewUpdate.ImportedFrom.Trim())
    ''            If Not rObj Is Nothing Then
    ''                rNewUpdate.IDBetreuer = rObj.ID
    ''            End If
    ''        End If

    ''        rNewUpdate.LastChangeOnExchange = Now.AddSeconds(2)
    ''        If IsUpdate Then
    ''            rNewUpdate.ChangedOnExchange = True
    ''        Else
    ''            Dim bIsNewContact As Boolean = True
    ''        End If

    ''        compObjectUpdate.daObjectImport.Update(dsObjectUpdate.tblObjectImport)
    ''        'InfoMailService.iCounterIncomingContacts += 1

    ''        'iFoundItems += 1
    ''        'iCounterLocal += 1

    ''        Return True

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.addUpdateContactToITSContRow: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function

    ''Public Function checkImportContactHasChangedOnExchange(ByRef rObj As dsObject.tblObjectRow, rMainAdress As dsObject.tblAdressenRow,
    ''                                                        ByRef rObjzusatz As dsObject.tblObjectZusatzRow,
    ''                                                        ByRef protokoll As String, ByRef protokollErr As String,
    ''                                                        ByRef Contact As Microsoft.Exchange.WebServices.Data.Contact,
    ''                                                        ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    ''                                                        ByRef functionMarker As String, ByRef InfoExcept As String) As Boolean
    ''    Try
    ''        Dim DisplayNameTmp As String = Me.IsNull(Contact.DisplayName, False, "DisplayName")
    ''        If DisplayNameTmp.Trim().ToLower().Contains(("xy").Trim().ToLower()) Then
    ''            Dim sStop As Boolean = True
    ''        End If
    ''        Dim DateTimeCreatedTmp As Date = Me.IsNull(Contact.DateTimeCreated, False, "DateTimeCreated")
    ''        functionMarker += "0;"

    ''        Dim LastNameTmp As String = ""
    ''        Dim FirstNameTmp As String = ""
    ''        Dim CompleteName As String = ""
    ''        Dim TitleTmp As String = ""

    ''        Dim GivenName As String = Me.IsNull(Contact.GivenName, False, "GivenName")
    ''        Dim NickName As String = Me.IsNull(Contact.NickName, False, "NickName")
    ''        Dim CompanyName As String = Me.IsNull(Contact.CompanyName, False, "CompanyName")
    ''        functionMarker += "1.1;"
    ''        Dim IDOutlookTmp As String = Me.IsNull(Contact.Id.UniqueId, False, "UniqueId")
    ''        functionMarker += "1.2;"
    ''        If IDOutlookTmp Is Nothing AndAlso IDOutlookTmp.Trim() = "" Then
    ''            Throw New Exception("Contact.Id=Nothing for Contact '" + DisplayNameTmp.Trim() + "!")
    ''        End If
    ''        functionMarker += "1.3;"

    ''        Dim NameAnyChanged As Boolean = False
    ''        If FirstNameTmp.Trim().ToLower() <> "" And LastNameTmp.Trim().ToLower() <> "" Then
    ''            If FirstNameTmp.Trim().ToLower() <> rObj.Vorname.Trim().ToLower() Or LastNameTmp.Trim().ToLower() <> rObj.Nachname.Trim().ToLower() Or
    ''                (Not rObj.IsPerson) Then
    ''                NameAnyChanged = True
    ''            End If

    ''        ElseIf FirstNameTmp.Trim().ToLower() = "" And LastNameTmp.Trim().ToLower() <> "" Then
    ''            If LastNameTmp.Trim().ToLower() <> rObj.Name.Trim().ToLower() Or
    ''                  (rObj.IsPerson) Then
    ''                NameAnyChanged = True
    ''            End If

    ''        ElseIf FirstNameTmp.Trim().ToLower() <> "" And LastNameTmp.Trim().ToLower() = "" Then
    ''            If FirstNameTmp.Trim().ToLower() <> rObj.Name.Trim().ToLower() Or
    ''                  (rObj.IsPerson) Then
    ''                NameAnyChanged = True
    ''            End If

    ''        ElseIf FirstNameTmp.Trim().ToLower() = "" And LastNameTmp.Trim().ToLower() = "" Then
    ''            If Me.checkChangedNameInContact(DisplayNameTmp, GivenName, NickName, CompanyName, rObj, NameAnyChanged) Then
    ''                NameAnyChanged = True
    ''            End If
    ''        Else
    ''            If Me.checkChangedNameInContact(DisplayNameTmp, GivenName, NickName, CompanyName, rObj, NameAnyChanged) Then
    ''                NameAnyChanged = True
    ''            End If
    ''        End If

    ''        Dim EMailAdress1 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress1) Then
    ''            EMailAdress1 = Contact.EmailAddresses(EmailAddressKey.EmailAddress1)
    ''        End If
    ''        Dim EMailAdress2 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress2) Then
    ''            EMailAdress2 = Contact.EmailAddresses(EmailAddressKey.EmailAddress2)
    ''        End If
    ''        Dim EMailAdress3 As Microsoft.Exchange.WebServices.Data.EmailAddress = Nothing
    ''        If Contact.EmailAddresses.Contains(EmailAddressKey.EmailAddress3) Then
    ''            EMailAdress3 = Contact.EmailAddresses(EmailAddressKey.EmailAddress3)
    ''        End If

    ''        Dim bEMailAdressFound As Boolean = False
    ''        If (Not EMailAdress1 Is Nothing) AndAlso Me.IsNull(EMailAdress1.Address, False, "Address") <> "" Then
    ''            Me.checkEMailAdressImportedContact(EMailAdress1.Address.Trim(), rMainAdress, bEMailAdressFound)
    ''        End If
    ''        If (Not EMailAdress2 Is Nothing) AndAlso Me.IsNull(EMailAdress2.Address, False, "Address") <> "" Then
    ''            Me.checkEMailAdressImportedContact(EMailAdress2.Address.Trim(), rMainAdress, bEMailAdressFound)
    ''        End If
    ''        If (Not EMailAdress3 Is Nothing) AndAlso Me.IsNull(EMailAdress3.Address, False, "Address") <> "" Then
    ''            Me.checkEMailAdressImportedContact(EMailAdress3.Address.Trim(), rMainAdress, bEMailAdressFound)
    ''        End If

    ''        Dim phyAdress_Home As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Home) Then
    ''            phyAdress_Home = Contact.PhysicalAddresses(PhysicalAddressKey.Home)
    ''        End If
    ''        Dim phyAdress_Business As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Business) Then
    ''            phyAdress_Business = Contact.PhysicalAddresses(PhysicalAddressKey.Business)
    ''        End If
    ''        Dim phyAdress_Other As PhysicalAddressEntry = Nothing
    ''        If Contact.PhysicalAddresses.Contains(PhysicalAddressKey.Other) Then
    ''            phyAdress_Other = Contact.PhysicalAddresses(PhysicalAddressKey.Other)
    ''        End If

    ''        Dim bAdressOK As Boolean = False
    ''        If Not phyAdress_Business Is Nothing Then
    ''            Dim PostalCode As String = Me.IsNull(phyAdress_Business.PostalCode, False, "PostalCode")
    ''            Dim City As String = Me.IsNull(phyAdress_Business.City, False, "City")
    ''            Dim Street As String = Me.IsNull(phyAdress_Business.Street, False, "Street")
    ''            Dim CountryOrRegion As String = Me.IsNull(phyAdress_Business.CountryOrRegion, False, "CountryOrRegion")
    ''            Dim State As String = Me.IsNull(phyAdress_Business.State, False, "State")

    ''            Me.checkAdressImportedContact(PostalCode, City, Street, CountryOrRegion, State, rMainAdress, bAdressOK)
    ''        End If
    ''        If Not phyAdress_Home Is Nothing Then
    ''            Dim PostalCode As String = Me.IsNull(phyAdress_Home.PostalCode, False, "PostalCode")
    ''            Dim City As String = Me.IsNull(phyAdress_Home.City, False, "City")
    ''            Dim Street As String = Me.IsNull(phyAdress_Home.Street, False, "Street")
    ''            Dim CountryOrRegion As String = Me.IsNull(phyAdress_Home.CountryOrRegion, False, "CountryOrRegion")
    ''            Dim State As String = Me.IsNull(phyAdress_Home.State, False, "State")

    ''            Me.checkAdressImportedContact(PostalCode, City, Street, CountryOrRegion, State, rMainAdress, bAdressOK)
    ''        End If
    ''        If Not phyAdress_Other Is Nothing Then
    ''            Dim PostalCode As String = Me.IsNull(phyAdress_Other.PostalCode, False, "PostalCode")
    ''            Dim City As String = Me.IsNull(phyAdress_Other.City, False, "City")
    ''            Dim Street As String = Me.IsNull(phyAdress_Other.Street, False, "Street")
    ''            Dim CountryOrRegion As String = Me.IsNull(phyAdress_Other.CountryOrRegion, False, "CountryOrRegion")
    ''            Dim State As String = Me.IsNull(phyAdress_Other.State, False, "State")

    ''            Me.checkAdressImportedContact(PostalCode, City, Street, CountryOrRegion, State, rMainAdress, bAdressOK)
    ''        End If

    ''        Dim bPhoneFound As Boolean = False
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.BusinessPhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.BusinessPhone), False, "BusinessPhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim BusinessPhone2 As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.BusinessPhone2) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.BusinessPhone2), False, "BusinessPhone2")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim HomePhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.HomePhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.HomePhone), False, "HomePhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim HomePhone2 As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.HomePhone2) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.HomePhone2), False, "HomePhone2")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim MobilePhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.MobilePhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.MobilePhone), False, "MobilePhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim PrimaryPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.PrimaryPhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.PrimaryPhone), False, "PrimaryPhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim CarPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.CarPhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.CarPhone), False, "CarPhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim CompanyMainPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.CompanyMainPhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.CompanyMainPhone), False, "CompanyMainPhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If
    ''        Dim AssistantPhone As String = ""
    ''        If Contact.PhoneNumbers.Contains(PhoneNumberKey.AssistantPhone) Then
    ''            Dim Phone As String = Me.IsNull(Contact.PhoneNumbers(PhoneNumberKey.AssistantPhone), False, "AssistantPhone")
    ''            Me.checkPhonNrImportedContract(Phone.Trim(), rMainAdress, bPhoneFound)
    ''        End If


    ''        If NameAnyChanged Or (Not bEMailAdressFound) Or (Not bAdressOK) Or (Not bPhoneFound) Then
    ''            Return True
    ''        Else
    ''            Return False
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkImportContactHasChangedOnExchange: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function

    'Public Sub UpdateCategoriesFromoExchangeToDB(ByRef es As ExchangeService, ByRef dNow As Date,
    '                                            ByRef Appoinment As Microsoft.Exchange.WebServices.Data.Appointment,
    '                                            ByRef Task As Microsoft.Exchange.WebServices.Data.Task,
    '                                            ByRef EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage,
    '                                            ByRef rNewPlan As dsPlan.planRow)
    '    Try
    '        Dim lstCategories As New StringList()
    '        If Not (Appoinment Is Nothing) Then
    '            lstCategories = Appoinment.Categories
    '        ElseIf Not (Task Is Nothing) Then
    '            lstCategories = Task.Categories
    '        ElseIf Not (EmailMessage Is Nothing) Then
    '            lstCategories = EmailMessage.Categories
    '        End If

    '        Dim bCategoryDone As Boolean = False
    '        For Each CategoryExchange As String In lstCategories
    '            If Not bCategoryDone Then
    '                rNewPlan.Category = CategoryExchange.Trim()
    '                bCategoryDone = True
    '            End If
    '        Next

    '        'If cOutlookWebAPI.compAuswahllistenUpdate Is Nothing Then
    '        '    cOutlookWebAPI.compAuswahllistenUpdate = New compAuswahllisten()
    '        '    cOutlookWebAPI.dsAuswahListCategory = New dsAuswahllisten()
    '        '    cOutlookWebAPI.clObjekte1 = New clObjekte()

    '        '    rGrp = cOutlookWebAPI.compAuswahllistenUpdate.getGruppenRow("PlanCategory")
    '        '    cOutlookWebAPI.clObjekte1.loadAuswahlliste(Nothing, Nothing, "PlanCategory", dsAuswahListCategory, "", "", Enums.eKeyCol.Description)
    '        'End If

    '        'Dim lstCategories As New StringList()
    '        'If Not (Appoinment Is Nothing) Then
    '        '    lstCategories = Appoinment.Categories
    '        'ElseIf Not (Task Is Nothing) Then
    '        '    lstCategories = Task.Categories
    '        'End If

    '        'Dim bExistsInDB As Boolean = False
    '        'For Each CategoryExchange As String In lstCategories
    '        '    For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    '        '        If rSelListCategory.Bezeichnung.Trim().ToLower().Equals(CategoryExchange.Trim().ToLower()) Then
    '        '            rNewPlan.Category = rSelListCategory.IDNr.Trim()
    '        '            Exit Sub
    '        '        End If
    '        '    Next
    '        '    If Not bExistsInDB Then
    '        '        'Dim dsAuswahllistenUpdate As New dsAuswahllisten()
    '        '        'compAuswahllistenUpdate.loadAuswahllisten("", dsAuswahllistenUpdate, compAuswahllisten.eTypAuswahlList.guid, "", "", "", System.Guid.NewGuid())
    '        '        'Dim rNewSelList As dsAuswahllisten.AuswahllistenRow = compAuswahllistenUpdate.addRowAuswahlliste(dsAuswahllistenUpdate)
    '        '        'rNewSelList.ID = System.Guid.NewGuid()
    '        '        'rNewSelList.IDGruppe = rGrp.ID
    '        '        'rNewSelList.IDNr = CategoryExchange.Trim()
    '        '        'rNewSelList.Bezeichnung = rNewSelList.IDNr.Trim()
    '        '        'rNewSelList.ErstelltAm = Now
    '        '        'rNewSelList.ErstelltVon = actUsr.rUsr.usr.Trim()

    '        '        'compAuswahllistenUpdate.daAuswahllisten.Update(dsAuswahllistenUpdate.Auswahllisten)
    '        '    End If
    '        'Next

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.UpdateCategoriesFromDBToExchange: Account " + vbNewLine + ex.ToString())
    '    End Try
    'End Sub

    ''Public Sub UpdateCategoriesFromExchangeToDBWebCall(ByRef es As ExchangeService, ByRef dNow As Date,
    ''                                                   ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow)   'ByRef FolderID As FolderId,
    ''    Try
    ''        If cOutlookWebAPI.compAuswahllistenUpdate Is Nothing Then
    ''            cOutlookWebAPI.compAuswahllistenUpdate = New compAuswahllisten()
    ''            cOutlookWebAPI.dsAuswahListCategory = New dsAuswahllisten()
    ''            cOutlookWebAPI.clObjekte1 = New clObjekte()

    ''            rGrp = cOutlookWebAPI.compAuswahllistenUpdate.getGruppenRow("PlanCategory")
    ''        End If

    ''        dsAuswahListCategory.Clear()
    ''        cOutlookWebAPI.clObjekte1.loadAuswahlliste(Nothing, Nothing, "PlanCategory", dsAuswahListCategory, "", "", Enums.eKeyCol.Description, Nothing, False, True)

    ''        Dim lstCategoryAdded As New System.Collections.Generic.List(Of String)
    ''        Dim List As MasterCategoryList.MasterCategoryList = MasterCategoryList.MasterCategoryList.Bind(es)
    ''        If Not List.Categories Is Nothing Then
    ''            For Each categoryExchange As MasterCategoryList.Category In List.Categories
    ''                Dim bExistsInDB As Boolean = False
    ''                For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    ''                    If rSelListCategory.Bezeichnung.Trim().ToLower().Equals(categoryExchange.Name.Trim().ToLower()) Then
    ''                        bExistsInDB = True
    ''                    End If
    ''                Next
    ''                Dim bCategoryAlreadyAdded As Boolean = False
    ''                For Each CategoryAdded As String In lstCategoryAdded
    ''                    If CategoryAdded.Trim().ToLower().Equals(categoryExchange.Name.Trim().ToLower()) Then
    ''                        bCategoryAlreadyAdded = True
    ''                    End If
    ''                Next

    ''                If Not bExistsInDB And Not bCategoryAlreadyAdded Then
    ''                    Dim dsAuswahllistenUpdate As New dsAuswahllisten()
    ''                    compAuswahllistenUpdate.loadAuswahllisten("", dsAuswahllistenUpdate, compAuswahllisten.eTypAuswahlList.guid, "", "", "", System.Guid.NewGuid())
    ''                    Dim rNewSelList As dsAuswahllisten.AuswahllistenRow = compAuswahllistenUpdate.addRowAuswahlliste(dsAuswahllistenUpdate)
    ''                    rNewSelList.ID = System.Guid.NewGuid()
    ''                    rNewSelList.IDGruppe = rGrp.ID
    ''                    rNewSelList.IDNr = categoryExchange.Name.Trim()
    ''                    rNewSelList.Bezeichnung = rNewSelList.IDNr.Trim()
    ''                    rNewSelList.ErstelltAm = Now
    ''                    rNewSelList.ErstelltVon = rUserAccount.Usr.Trim()

    ''                    compAuswahllistenUpdate.daAuswahllisten.Update(dsAuswahllistenUpdate.Auswahllisten)
    ''                    lstCategoryAdded.Add(rNewSelList.Bezeichnung.Trim())

    ''                    Dim txtPos As String = "Category  " + rNewSelList.Bezeichnung.Trim() + " added to ITSCont - Account '" + rUserAccount.Name + "!"
    ''                    Me.delDoInfoUI.Invoke(txtPos, False, False)
    ''                End If
    ''            Next
    ''        End If

    ''        Dim lstCategoriesToAddToExchange As New System.Collections.Generic.List(Of String)
    ''        List = MasterCategoryList.MasterCategoryList.Bind(es)
    ''        dsAuswahListCategory.Clear()
    ''        cOutlookWebAPI.clObjekte1.loadAuswahlliste(Nothing, Nothing, "PlanCategory", dsAuswahListCategory, "", "", Enums.eKeyCol.Description, Nothing, False, True)
    ''        If Not List.Categories Is Nothing Then
    ''            For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    ''                For Each category As MasterCategoryList.Category In List.Categories
    ''                    If Not rSelListCategory.Bezeichnung.Trim().ToLower().Equals(category.Name.Trim().ToLower()) Then
    ''                        lstCategoriesToAddToExchange.Add(rSelListCategory.Bezeichnung.Trim())
    ''                    End If
    ''                Next
    ''            Next
    ''        End If

    ''        'For Each CategoriesToAdd As String In lstCategoriesToAddToExchange
    ''        '    List = MasterCategoryList.MasterCategoryList.Bind(es)
    ''        '    List.Categories.Add(New MasterCategoryList.Category(CategoriesToAdd.Trim(), MasterCategoryList.CategoryColor.Yellow, MasterCategoryList.CategoryKeyboardShortcut.CtrlF10))
    ''        '    List.Update()

    ''        '    Dim txtPos As String = "Category " + CategoriesToAdd.Trim() + " added to Exchange - Account '" + rUserAccount.Name + "!"
    ''        '    Me.delDoInfoUI.Invoke(txtPos, False, False)
    ''        'Next

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.UpdateCategoriesFromExchangeToDBWebCall: Account " + vbNewLine + ex.ToString())
    ''    End Try
    ''End Sub



    ''Public Function UpdateConversationsFromExchangeToDBxy(ByRef es As ExchangeService, ByRef conversation As Conversation,
    ''                                                    ByRef dNow As Date, ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow) As Boolean
    ''    Try
    ''        If cOutlookWebAPI.compAuswahllistenUpdate Is Nothing Then
    ''            cOutlookWebAPI.compAuswahllistenUpdate = New compAuswahllisten()
    ''            cOutlookWebAPI.dsAuswahListCategory = New dsAuswahllisten()
    ''            cOutlookWebAPI.clObjekte1 = New clObjekte()

    ''            rGrp = cOutlookWebAPI.compAuswahllistenUpdate.getGruppenRow("PlanCategory")
    ''            cOutlookWebAPI.clObjekte1.loadAuswahlliste(Nothing, Nothing, "PlanCategory", dsAuswahListCategory, "", "", Enums.eKeyCol.Description)
    ''        End If

    ''        If Not conversation.Categories Is Nothing Then
    ''            For Each CategoryExchange As String In conversation.Categories
    ''                Dim bExistsInDB As Boolean = False
    ''                For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    ''                    If rSelListCategory.Bezeichnung.Trim().ToLower().Equals(CategoryExchange.Trim().ToLower()) Then
    ''                        bExistsInDB = True
    ''                    End If
    ''                Next

    ''                If Not bExistsInDB Then
    ''                    Dim dsAuswahllistenUpdate As New dsAuswahllisten()
    ''                    compAuswahllistenUpdate.loadAuswahllisten("", dsAuswahllistenUpdate, compAuswahllisten.eTypAuswahlList.guid, "", "", "", System.Guid.NewGuid())
    ''                    Dim rNewSelList As dsAuswahllisten.AuswahllistenRow = compAuswahllistenUpdate.addRowAuswahlliste(dsAuswahllistenUpdate)
    ''                    rNewSelList.ID = System.Guid.NewGuid()
    ''                    rNewSelList.IDGruppe = rGrp.ID
    ''                    rNewSelList.IDNr = CategoryExchange.Trim()
    ''                    rNewSelList.Bezeichnung = rNewSelList.IDNr.Trim()
    ''                    rNewSelList.ErstelltAm = Now
    ''                    rNewSelList.ErstelltVon = rUserAccount.Usr.Trim()

    ''                    compAuswahllistenUpdate.daAuswahllisten.Update(dsAuswahllistenUpdate.Auswahllisten)
    ''                    Return True

    ''                    'Dim categories As New List(Of String)()
    ''                    ''categories.Add(CategoryExchange.Trim())
    ''                    'conversation.EnableAlwaysCategorizeItems(categories, True)
    ''                    'conversation.EnableAlwaysMoveItems(WellKnownFolderName.Drafts, False)
    ''                End If
    ''            Next
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.UpdateConversationsFromExchangeToDB: Account " + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function

    ''Public Sub UpdateCategoriesFromDBToExchange(ByRef es As ExchangeService, Foldername As WellKnownFolderName, ByRef dNow As Date,
    ''                                            ByRef Appoinment As Microsoft.Exchange.WebServices.Data.Appointment,
    ''                                            ByRef Task As Microsoft.Exchange.WebServices.Data.Task,
    ''                                            ByRef CategoryToSave As String)
    ''    Try
    ''        Dim compAuswahllistenUpdate As New compAuswahllisten()
    ''        Dim clObjekte1 As New clObjekte
    ''        Dim dsAuswahListCategory As New ITSCont.core.SystemDb.dsAuswahllisten()

    ''        Dim rGrp As dsAuswahllisten.AuswahllisteGruppeRow = compAuswahllistenUpdate.getGruppenRow("PlanCategory")
    ''        clObjekte1.loadAuswahlliste(Nothing, Nothing, "PlanCategory", dsAuswahListCategory, "", "", Enums.eKeyCol.Description)

    ''        Dim lstCategories As New StringList()
    ''        If Not (Appoinment Is Nothing) Then
    ''            lstCategories = Appoinment.Categories
    ''        ElseIf Not (Task Is Nothing) Then
    ''            lstCategories = Task.Categories
    ''        End If

    ''        Dim bExistsInDB As Boolean = False
    ''        For Each CategoryExchange As String In lstCategories
    ''            If CategoryToSave.Trim().ToLower().Equals(CategoryExchange.Trim().ToLower()) Then
    ''                bExistsInDB = True
    ''            End If
    ''        Next
    ''        If Not bExistsInDB Then
    ''            If Not (Appoinment Is Nothing) Then
    ''                Appoinment.Categories.Add(CategoryToSave.Trim())
    ''            ElseIf Not (Task Is Nothing) Then
    ''                Task.Categories.Add(CategoryToSave.Trim())
    ''            End If
    ''            'Dim categories As New List(Of String)()
    ''            'categories.Add(rSelListCategory.Bezeichnung.Trim())
    ''            'Appoinment.EnableAlwaysCategorizeItems(categories, True)
    ''            'Appoinment.EnableAlwaysMoveItems(WellKnownFolderName.Drafts, False)
    ''        End If

    ''        'For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    ''        '    Dim bExistsInDB As Boolean = False
    ''        '    For Each CategoryExchange As String In Appoinment.Categories
    ''        '        If rSelListCategory.Bezeichnung.Trim().ToLower().Equals(CategoryExchange.Trim().ToLower()) Then
    ''        '            bExistsInDB = True
    ''        '        End If
    ''        '    Next
    ''        '    If Not bExistsInDB Then
    ''        '        Appoinment.Categories.Add(rSelListCategory.Bezeichnung.Trim())
    ''        '        'Dim categories As New List(Of String)()
    ''        '        'categories.Add(rSelListCategory.Bezeichnung.Trim())
    ''        '        'Appoinment.EnableAlwaysCategorizeItems(categories, True)
    ''        '        'Appoinment.EnableAlwaysMoveItems(WellKnownFolderName.Drafts, False)
    ''        '    End If
    ''        'Next

    ''        'Dim view As ConversationIndexedItemView = New ConversationIndexedItemView(5000)
    ''        ''Dim queryString As String = "subject:news"
    ''        'Dim conversations As ICollection(Of Conversation) = es.FindConversation(view, Foldername)    'queryString

    ''        'For Each rSelListCategory As dsAuswahllisten.AuswahllistenRow In dsAuswahListCategory.Auswahllisten
    ''        '    For Each conversation As Conversation In conversations
    ''        '        Dim TopicTmp As String = conversation.Topic
    ''        '        Dim LastDeliveryTimeTmp As Date = conversation.LastDeliveryTime
    ''        '        Me.UpdateConversationsFromDBToExchange(es, conversation, rSelListCategory, dNow)
    ''        '        For Each GlUniqRec As String In conversation.GlobalUniqueRecipients
    ''        '            Dim GlUniqRecTmp As String = GlUniqRec
    ''        '        Next
    ''        '    Next
    ''        'Next

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.UpdateCategoriesFromDBToExchange: Account " + vbNewLine + ex.ToString())
    ''    End Try
    ''End Sub

    ''Public Function UpdateConversationsFromDBToExchangexyxy(ByRef es As ExchangeService, ByRef conversation As Conversation,
    ''                                                    ByRef rSelListCategory As dsAuswahllisten.AuswahllistenRow,
    ''                                                    ByRef dNow As Date) As Boolean
    ''    Try
    ''        Dim bExistsInDB As Boolean = False
    ''        For Each CategoryExchange As String In conversation.Categories
    ''            If rSelListCategory.Bezeichnung.Trim().ToLower().Equals(CategoryExchange.Trim().ToLower()) Then
    ''                bExistsInDB = True
    ''            End If
    ''        Next

    ''        If Not bExistsInDB Then
    ''            Dim categories As New List(Of String)()
    ''            categories.Add(rSelListCategory.Bezeichnung.Trim())
    ''            conversation.EnableAlwaysCategorizeItems(categories, True)
    ''            conversation.EnableAlwaysMoveItems(WellKnownFolderName.Drafts, False)
    ''            Return True
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.UpdateConversationsFromDBToExchange: Account " + vbNewLine + ex.ToString())
    ''    End Try
    ''End Function


    ''Public Sub setPhone(ByRef PhoneToSet As String, ByRef rNew As dsSearchObjects.tblObjectImportRow)
    ''    Try
    ''        Dim bPhoneSet As Boolean = False
    ''        If rNew.TelGeschäftlich.Trim() = "" Then
    ''            rNew.TelGeschäftlich = PhoneToSet.Trim()
    ''            bPhoneSet = True
    ''        End If
    ''        If rNew.TelMobile.Trim() = "" Then
    ''            rNew.TelMobile = PhoneToSet.Trim()
    ''            bPhoneSet = True
    ''        End If
    ''        If rNew.TelMobile2.Trim() = "" Then
    ''            rNew.TelMobile2 = PhoneToSet.Trim()
    ''            bPhoneSet = True
    ''        End If
    ''        If rNew.TelPrivate.Trim() = "" Then
    ''            rNew.TelPrivate = PhoneToSet.Trim()
    ''            bPhoneSet = True
    ''        End If

    ''        If Not bPhoneSet Then
    ''            rNew.Info += "Phone: " + PhoneToSet.ToString() + vbNewLine
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.setPhone: " + ex.ToString())
    ''    End Try
    ''End Sub

    ''Public Sub searchNameAutoForContact(ByRef rNew As dsSearchObjects.tblObjectImportRow,
    ''                                    ByRef Contact As Microsoft.Exchange.WebServices.Data.Contact)
    ''    Try
    ''        Dim DisplayName As String = Me.IsNull(Contact.DisplayName, False, "CompleteName")
    ''        Dim GivenName As String = Me.IsNull(Contact.GivenName, False, "GivenName")
    ''        Dim NickName As String = Me.IsNull(Contact.NickName, False, "NickName")
    ''        Dim CompanyName As String = Me.IsNull(Contact.CompanyName, False, "CompanyName")

    ''        rNew.IsPerson = False
    ''        rNew.FirstName = ""
    ''        rNew.FirstNameSecond = ""
    ''        rNew.LastName = NoNameOnExchange
    ''        rNew.Firma = NoNameOnExchange

    ''        Dim bPhoneSet As Boolean = False
    ''        If DisplayName.Trim() <> "" Then
    ''            rNew.LastName = DisplayName.Trim()
    ''            bPhoneSet = True
    ''        Else
    ''            If CompanyName.Trim() <> "" Then
    ''                rNew.LastName = CompanyName.Trim()
    ''                bPhoneSet = True
    ''            Else
    ''                If GivenName.Trim() <> "" Then
    ''                    rNew.LastName = GivenName.Trim()
    ''                    bPhoneSet = True
    ''                Else
    ''                    If NickName.Trim() <> "" Then
    ''                        rNew.LastName = NickName.Trim()
    ''                        bPhoneSet = True
    ''                    End If
    ''                End If
    ''            End If
    ''        End If

    ''        'If Not bPhoneSet Then
    ''        '    rNew.Info += "name: " + PhoneToSet.ToString() + vbNewLine
    ''        'End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.searchNameAutoForContact: " + ex.ToString())
    ''    End Try
    ''End Sub
    ''Public Function checkChangedNameInContact(ByRef DisplayName As String, ByRef GivenName As String, ByRef NickName As String,
    ''                                     ByRef CompanyName As String, ByRef rObj As dsObject.tblObjectRow,
    ''                                     ByRef AnyChanged As Boolean) As Boolean
    ''    Try
    ''        If DisplayName.Trim() <> "" Then
    ''            If DisplayName.Trim().ToLower() <> rObj.Name.Trim().ToLower() Then
    ''                AnyChanged = True
    ''                Return True
    ''            End If
    ''        Else
    ''            If CompanyName.Trim() <> "" Then
    ''                If CompanyName.Trim().ToLower() <> rObj.Name.Trim().ToLower() Then
    ''                    AnyChanged = True
    ''                    Return True
    ''                End If
    ''            Else
    ''                If GivenName.Trim() <> "" Then
    ''                    If GivenName.Trim().ToLower() <> rObj.Name.Trim().ToLower() Then
    ''                        AnyChanged = True
    ''                        Return True
    ''                    End If
    ''                Else
    ''                    If NickName.Trim() <> "" Then
    ''                        If NickName.Trim().ToLower() <> rObj.Name.Trim().ToLower() Then
    ''                            AnyChanged = True
    ''                            Return True
    ''                        End If
    ''                    End If
    ''                End If
    ''            End If
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkChangedNameInContact: " + ex.ToString())
    ''    End Try
    ''End Function
    ''Public Function checkEMailAdressImportedContact(ByRef EMailAdressFromExchange As String, ByRef rAdrMain As dsObject.tblAdressenRow,
    ''                                                ByRef bAdressFound As Boolean) As Boolean
    ''    Try
    ''        If rAdrMain.Email.Trim().ToLower() = EMailAdressFromExchange.Trim().ToLower() Then
    ''            bAdressFound = True
    ''        End If
    ''        If rAdrMain.EmailBeruflich.Trim().ToLower() = EMailAdressFromExchange.Trim().ToLower() Then
    ''            bAdressFound = True
    ''        End If
    ''        If rAdrMain.EmailBeruflich2.Trim().ToLower() = EMailAdressFromExchange.Trim().ToLower() Then
    ''            bAdressFound = True
    ''        End If
    ''        If rAdrMain.EMailBenachrichtigung.Trim().ToLower() = EMailAdressFromExchange.Trim().ToLower() Then
    ''            bAdressFound = True
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkEMailAdressImportedContact: " + ex.ToString())
    ''    End Try
    ''End Function
    ''Public Function checkAdressImportedContact(ByRef PostalCode As String, ByRef City As String, ByRef Street As String,
    ''                                           ByRef CountryOrRegion As String, ByRef State As String,
    ''                                            ByRef rAdrMain As dsObject.tblAdressenRow,
    ''                                            ByRef bAdressFound As Boolean) As Boolean
    ''    Try
    ''        If rAdrMain.Email.Trim().ToLower() = PostalCode.Trim().ToLower() And
    ''            rAdrMain.Email.Trim().ToLower() = City.Trim().ToLower() And
    ''            rAdrMain.Email.Trim().ToLower() = Street.Trim().ToLower() And
    ''            rAdrMain.Email.Trim().ToLower() = State.Trim().ToLower() Then

    ''            bAdressFound = True
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkAdressImportedContact: " + ex.ToString())
    ''    End Try
    ''End Function
    ''Public Function checkPhonNrImportedContract(ByRef PhoneNr As String, ByRef rAdrMain As dsObject.tblAdressenRow,
    ''                                            ByRef bPhoneFound As Boolean) As Boolean
    ''    Try
    ''        If rAdrMain.TelGesch.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If
    ''        If rAdrMain.TelGesch2.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If
    ''        If rAdrMain.TelMobil.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If
    ''        If rAdrMain.TelMobil2.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If
    ''        If rAdrMain.TelMobilBeruflich.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If
    ''        If rAdrMain.TelPrivat.Trim().ToLower() = PhoneNr.Trim().ToLower() Then
    ''            bPhoneFound = True
    ''        End If

    ''    Catch ex As Exception
    ''        Throw New Exception("cOutlookWebAPI.checkPhonNrImportedContract: " + ex.ToString())
    ''    End Try
    ''End Function

    'Public Sub getBody(ByRef rNewPlan As dsPlan.planRow,
    '                   ByRef EMailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage,
    '                   ByRef Appoinment As Microsoft.Exchange.WebServices.Data.Appointment,
    '                   ByRef Task As Microsoft.Exchange.WebServices.Data.Task,
    '                   ByRef cMessageNew As clPlan.cMessage, ByRef SubjectTmp As String, ByRef dReceived As Date, ByRef IDIntern As String,
    '                   ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow,
    '                   ByRef Protokoll As String, ByRef protokollErr As String)
    '    Try
    '        Dim doBody As Boolean = False
    '        If Not EMailMessage Is Nothing Then
    '            If Not EMailMessage.Body Is Nothing Then
    '                doBody = True
    '            Else
    '                'For Each rPlanUpdate As dsPlan.planRow In dsPlan1.plan
    '                '    Dim compPlanUpdate As New compPlan()
    '                '    rPlanUpdate.Text = TxtBodyTmp
    '                '    rPlanUpdate.html = isHtml
    '                '    compPlanUpdate.deletePlanStatus(rPlanUpdate.ID)
    '                'Next
    '            End If
    '        ElseIf Not Appoinment Is Nothing Then
    '            If Not Appoinment.Body Is Nothing Then
    '                doBody = True
    '            Else
    '                'For Each rPlanUpdate As dsPlan.planRow In dsPlan1.plan
    '                '    Dim compPlanUpdate As New compPlan()
    '                '    rPlanUpdate.Text = TxtBodyTmp
    '                '    rPlanUpdate.html = isHtml
    '                '    compPlanUpdate.deletePlanStatus(rPlanUpdate.ID)
    '                'Next
    '            End If
    '        Else
    '            If Not Task.Body Is Nothing Then
    '                doBody = True
    '            End If
    '        End If

    '        Dim isHtml As Boolean = False
    '        If doBody Then
    '            Dim TxtBodyTmp As String = ""
    '            If Not EMailMessage Is Nothing Then
    '                If EMailMessage.Body.BodyType = BodyType.HTML Then
    '                    isHtml = True
    '                Else
    '                    isHtml = False
    '                End If

    '                If Not EMailMessage.Body.Text Is Nothing Then
    '                    TxtBodyTmp = EMailMessage.Body.Text.Trim()
    '                End If
    '                'pSet = New PropertySet(BasePropertySet.FirstClassProperties)
    '                'pSet.RequestedUniqueBodyType = BodyType.HTML
    '                'EMailMessage.Load(pSet)
    '                'Dim s As String = EMailMessage.UniqueBody.Text()
    '            ElseIf Not Appoinment Is Nothing Then
    '                If Appoinment.Body.BodyType = BodyType.HTML Then
    '                    isHtml = True
    '                Else
    '                    isHtml = False
    '                End If

    '                If Not Appoinment.Body.Text Is Nothing Then
    '                    TxtBodyTmp = Appoinment.Body.Text.Trim()
    '                End If
    '                'pSet = New PropertySet(BasePropertySet.FirstClassProperties)
    '                'pSet.RequestedUniqueBodyType = BodyType.HTML
    '                'EMailMessage.Load(pSet)
    '                'Dim s As String = EMailMessage.UniqueBody.Text()
    '            ElseIf Not Task Is Nothing Then
    '                If Task.Body.BodyType = BodyType.HTML Then
    '                    isHtml = True
    '                Else
    '                    isHtml = False
    '                End If

    '                If Not Task.Body.Text Is Nothing Then
    '                    TxtBodyTmp = Task.Body.Text.Trim()
    '                End If
    '            Else
    '                Throw New Exception("Type getBody not defined!")
    '            End If
    '            If Me.checkBodyIsEmpty(TxtBodyTmp.Trim(), True) Then
    '                Dim pSet As PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)
    '                If Not EMailMessage Is Nothing Then
    '                    EMailMessage.Load(pSet)
    '                    Me.gen.waitTime(1000)
    '                    If Not EMailMessage.Body.Text Is Nothing Then
    '                        TxtBodyTmp = EMailMessage.Body.Text.Trim()
    '                    End If
    '                ElseIf Not Appoinment Is Nothing Then
    '                    Appoinment.Load(pSet)
    '                    Me.gen.waitTime(1000)
    '                    If Not Appoinment.Body.Text Is Nothing Then
    '                        TxtBodyTmp = Appoinment.Body.Text.Trim()
    '                    End If
    '                Else
    '                    Task.Load(pSet)
    '                    Me.gen.waitTime(1000)
    '                    If Not Task.Body.Text Is Nothing Then
    '                        TxtBodyTmp = Task.Body.Text.Trim()
    '                    End If
    '                End If

    '                If Me.checkBodyIsEmpty(TxtBodyTmp.Trim(), True) Then
    '                    Dim dsStatusUpdate As New dsPlan()
    '                    Dim compPlanUpdate As New compPlan()
    '                    compPlanUpdate.getPlanStatus(System.Guid.NewGuid().ToString(), compPlan.eTypSelPlan.MessageId, dsStatusUpdate, compPlan.eStatusPlan.bodyEmpty, System.Guid.NewGuid().ToString(), Nothing)
    '                    Dim rPlanStatusUpdate As dsPlan.planStatusRow = compPlanUpdate.getNewRowPlanStatus(dsStatusUpdate.planStatus, IDIntern.Trim(), rNewPlan.ID, rUserAccount.Usr, compPlan.eStatusPlan.bodyEmpty, SubjectTmp.Trim())
    '                    compPlanUpdate.daPlanStatus.Update(dsStatusUpdate.planStatus)
    '                Else
    '                    'For Each rPlanUpdate As dsPlan.planRow In dsPlan1.plan
    '                    '    Dim compPlanUpdate As New compPlan()
    '                    '    rPlanUpdate.Text = TxtBodyTmp
    '                    '    rPlanUpdate.html = isHtml
    '                    '    compPlanUpdate.deletePlanStatus(rPlanUpdate.ID)
    '                    'Next
    '                End If
    '                ' ''isHtml = False
    '                ''If Not EMailMessage.TextBody Is Nothing Then
    '                ''    'If EMailMessage.TextBody.BodyType = BodyType.Text Then
    '                ''    If (Not EMailMessage.TextBody.Text.Trim().ToLower().Equals(("<html></html>").Trim().ToLower())) And _
    '                ''        EMailMessage.TextBody.Text.Trim() <> "" Then
    '                ''        TxtBodyTmp = EMailMessage.TextBody.Text.Trim()
    '                ''        If EMailMessage.TextBody.BodyType = BodyType.HTML Then
    '                ''            isHtml = True
    '                ''        Else
    '                ''            isHtml = False
    '                ''        End If
    '                ''    End If
    '                ''    'End If
    '                ''End If
    '                Dim txtErr As String = "Info: E-Mail '" + SubjectTmp + "' from '" + dReceived.ToString() + "' has body <html></html>!" + vbNewLine +
    '                                                                "TextBody" + TxtBodyTmp.Trim()
    '                Me.addProtokoll(txtErr, Protokoll, True, False)
    '                Me.addProtokoll(txtErr, protokollErr, True, False)
    '                If Not Me.delDoInfoUI Is Nothing Then
    '                    Me.delDoInfoUI.Invoke(txtErr, False, False)
    '                End If
    '            Else
    '                'For Each rPlanUpdate As dsPlan.planRow In dsPlan1.plan
    '                '    Dim compPlanUpdate As New compPlan()
    '                '    rPlanUpdate.Text = TxtBodyTmp
    '                '    rPlanUpdate.html = isHtml
    '                '    compPlanUpdate.deletePlanStatus(rPlanUpdate.ID)
    '                'Next
    '            End If

    '            rNewPlan.Text = TxtBodyTmp.Trim()
    '            rNewPlan.html = isHtml
    '            If isHtml Then
    '                cMessageNew.bodyHtml = TxtBodyTmp.Trim()
    '            Else
    '                cMessageNew.bodyTxt = TxtBodyTmp.Trim()
    '            End If
    '            cMessageNew.hasHtml = isHtml

    '            'Try
    '            '    Dim txtPos As String = "1. CheckBody " + dReceived.ToString() + vbNewLine + SubjectTmp.Trim() + vbNewLine + EMailMessage.Body.Text.Trim() + vbNewLine
    '            '    Me.delDoInfoUI.Invoke(txtPos, False)
    '            'Catch ex As Exception
    '            'End Try
    '            'Try
    '            '    Dim txtPos As String = "2. CheckBody " + dReceived.ToString() + vbNewLine + SubjectTmp.Trim() + vbNewLine + EMailMessage.TextBody.Text.Trim() + vbNewLine
    '            '    Me.delDoInfoUI.Invoke(txtPos, False)
    '            'Catch ex As Exception
    '            'End Try
    '            'Try
    '            '    Dim txtPos As String = "3. CheckBody " + dReceived.ToString() + vbNewLine + SubjectTmp.Trim() + vbNewLine + isHtml.ToString() + vbNewLine
    '            '    Me.delDoInfoUI.Invoke(txtPos, False)
    '            'Catch ex As Exception
    '            'End Try
    '        End If
    '        If rNewPlan.Text.Trim() = "" Then
    '            'If Not EMailMessage.TextBody Is Nothing Then
    '            '    If EMailMessage.TextBody.BodyType = BodyType.HTML Then
    '            '        isHtml = True
    '            '    Else
    '            '        isHtml = False
    '            '    End If
    '            '    Dim TxtBodyTmp As String = ""
    '            '    If EMailMessage.TextBody.Text() <> Nothing Then
    '            '        TxtBodyTmp = EMailMessage.TextBody.Text().Trim()
    '            '    End If
    '            '    rNewPlan.Text = TxtBodyTmp.Trim()
    '            '    rNewPlan.html = isHtml
    '            '    cMessageNew.bodyHtml = TxtBodyTmp.Trim()
    '            '    cMessageNew.hasHtml = isHtml
    '            'End If
    '        End If
    '        If rNewPlan.Text.Trim() = "" Then
    '            'Dim str As String = ""
    '            'Throw New Exception("E-Mail '" + email.Subject.Trim() + "' from '" + dReceived.ToString() + "' has no HtmlBody and no TextBody!")
    '            rNewPlan.Text = ""
    '            rNewPlan.html = False
    '            cMessageNew.bodyHtml = ""
    '            cMessageNew.hasHtml = False
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("getBody: " + ex.ToString())
    '    End Try
    'End Sub
    'Public Sub getAnhänge(ByRef rNewPlan As dsPlan.planRow, ByRef bodyWasEmptyLastReceive As Boolean,
    '                       ByRef EMailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage,
    '                       ByRef Appoinment As Microsoft.Exchange.WebServices.Data.Appointment,
    '                       ByRef Task As Microsoft.Exchange.WebServices.Data.Task,
    '                       ByRef cMessageNew As clPlan.cMessage, ByRef SubjectTmp As String, ByRef dReceived As Date, ByRef IDIntern As String,
    '                       ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef doAnhänge As Boolean,
    '                       ByRef Protokoll As String, ByRef protokollErr As String, ByRef functionMarker As String,
    '                       ByRef tree2 As Infragistics.Win.UltraWinTree.UltraTree,
    '                       ByRef dsPlan1 As dsPlan, ByRef cTgMailToAdd As clPlan.cTgMail,
    '                       ByRef newTreeNode As Infragistics.Win.UltraWinTree.UltraTreeNode)
    '    Try
    '        Dim doAttachments As Boolean = False
    '        If Not EMailMessage Is Nothing Then
    '            If EMailMessage.HasAttachments Then
    '                doAttachments = True
    '            End If
    '        ElseIf Not Appoinment Is Nothing Then
    '            If Appoinment.HasAttachments Then
    '                doAttachments = True
    '            End If
    '        Else
    '            If Task.HasAttachments Then
    '                doAttachments = True
    '            End If
    '        End If

    '        functionMarker += "12;"
    '        If doAnhänge And (Not bodyWasEmptyLastReceive) Then
    '            If doAttachments Then
    '                If Not tree2 Is Nothing Then
    '                    newTreeNode.Text = "[A] " + newTreeNode.Text
    '                End If
    '                Dim lstAttachments As New System.Collections.Generic.List(Of Microsoft.Exchange.WebServices.Data.Attachment)
    '                If Not EMailMessage Is Nothing Then
    '                    For Each Attachment As Microsoft.Exchange.WebServices.Data.Attachment In EMailMessage.Attachments
    '                        lstAttachments.Add(Attachment)
    '                    Next
    '                ElseIf Not Appoinment Is Nothing Then
    '                    For Each Attachment As Microsoft.Exchange.WebServices.Data.Attachment In Appoinment.Attachments
    '                        lstAttachments.Add(Attachment)
    '                    Next
    '                Else
    '                    For Each Attachment As Microsoft.Exchange.WebServices.Data.Attachment In Task.Attachments
    '                        lstAttachments.Add(Attachment)
    '                    Next
    '                End If
    '                For Each Attachment As Microsoft.Exchange.WebServices.Data.Attachment In lstAttachments
    '                    Attachment.Load()

    '                    'Dim dirTmp As String = My.Computer.FileSystem.SpecialDirectories.Temp
    '                    Dim rNewPlanAnhang As dsPlan.planAnhangRow = Nothing
    '                    If TypeOf Attachment Is Microsoft.Exchange.WebServices.Data.FileAttachment Then
    '                        rNewPlanAnhang = dsPlan1.planAnhang.NewRow()
    '                        rNewPlanAnhang.ID = System.Guid.NewGuid()
    '                        rNewPlanAnhang.IDPlan = rNewPlan.ID
    '                        If Not Attachment.Name Is Nothing Then
    '                            rNewPlanAnhang.Bezeichnung = Attachment.Name.Trim()
    '                        Else
    '                            rNewPlanAnhang.Bezeichnung = ""
    '                        End If
    '                        rNewPlanAnhang.DateiTyp = ""
    '                        Dim fileExtension As String = ""
    '                        If Not Attachment.ContentType Is Nothing Then
    '                            If Attachment.ContentType.Trim().Contains("/") Then
    '                                Dim iPos As Integer = Attachment.ContentType.Trim().LastIndexOf("/")
    '                                fileExtension = Attachment.ContentType.Trim().Substring(iPos + 1, Attachment.ContentType.Trim().Length - iPos - 1)
    '                                rNewPlanAnhang.DateiTyp = "." + fileExtension.Trim() ' System.IO.Path.GetExtension(sTypeFile)
    '                            End If
    '                        End If
    '                        If fileExtension.Trim() = "" Then
    '                            If rNewPlanAnhang.Bezeichnung.Trim().Contains(".") Then
    '                                Dim iPos As Integer = rNewPlanAnhang.Bezeichnung.Trim().LastIndexOf(".")
    '                                fileExtension = rNewPlanAnhang.Bezeichnung.Trim().Substring(iPos + 1, rNewPlanAnhang.Bezeichnung.Trim().Length - iPos - 1)
    '                                rNewPlanAnhang.DateiTyp = "." + fileExtension.Trim() ' System.IO.Path.GetExtension(sTypeFile)
    '                            End If
    '                        End If

    '                        Dim FileAttachment As Microsoft.Exchange.WebServices.Data.FileAttachment = DirectCast(Attachment, FileAttachment)
    '                        FileAttachment.Load()
    '                        Dim ContentBytes() As Byte = FileAttachment.Content
    '                        rNewPlanAnhang.doku = ContentBytes

    '                        If Not tree2 Is Nothing Then
    '                            Dim newAttachment As New clPlan.cTgAttachment()
    '                            newAttachment.byt = ContentBytes
    '                            newAttachment.fileName = rNewPlanAnhang.Bezeichnung
    '                            newAttachment.typeFile = rNewPlanAnhang.DateiTyp
    '                            cTgMailToAdd.lstAttachments.Add(newAttachment)
    '                        End If

    '                        'Using File2Disk As System.IO.Stream = New  _
    '                        '    System.IO.FileStream(dirTmp + "\" + FileAttachment.Name, System.IO.FileMode.Create)
    '                        '    File2Disk.Write(FileAttachment.Content, 0, FileAttachment.Content.Length)
    '                        '    File2Disk.Flush()
    '                        '    File2Disk.Close()
    '                        '    FileAttachment.Load()
    '                        'End Using

    '                        dsPlan1.planAnhang.Rows.Add(rNewPlanAnhang)
    '                    Else
    '                        Dim ItemAttachment As Microsoft.Exchange.WebServices.Data.Item = DirectCast(Attachment, ItemAttachment).Item
    '                        If TypeOf ItemAttachment Is Microsoft.Exchange.WebServices.Data.EmailMessage Then
    '                        Else
    '                        End If
    '                        'EMailMessage.Load(New PropertySet(ItemSchema.MimeContent))
    '                        Dim str As String = ""

    '                        If Not tree2 Is Nothing Then
    '                            'Dim newAttachment As New clPlan.cTgAttachment()
    '                            'newAttachment.byt = Nothing
    '                            'newAttachment.fileName = rNewPlanAnhang.Bezeichnung
    '                            'newAttachment.typeFile = rNewPlanAnhang.DateiTyp
    '                            'newAttachment.isItemAttachment = True
    '                            'cTgMailToAdd.lstAttachments.Add(newAttachment)
    '                        End If

    '                        'es.LoadPropertiesForItems(EMailMessage, New PropertySet(ItemSchema.MimeContent))

    '                        'Dim propSet As New PropertySet()
    '                        'propSet.RequestedBodyType = BodyType.Text
    '                        'propSet.BasePropertySet = BasePropertySet.FirstClassProperties
    '                        'ItemAttachment.Load(New PropertySet())
    '                        'es.LoadPropertiesForItems(EMailMessage, New PropertySet(ItemSchema.MimeContent))

    '                        'Dim itItemPropSet As PropertySet = New PropertySet(BasePropertySet.IdOnly,
    '                        '                                                     ItemSchema.Attachments,
    '                        '                                                     ItemSchema.Subject,
    '                        '                                                     ItemSchema.Importance,
    '                        '                                                     ItemSchema.DateTimeReceived,
    '                        '                                                     ItemSchema.DateTimeSent,
    '                        '                                                     ItemSchema.ItemClass,
    '                        '                                                     ItemSchema.Size,
    '                        '                                                     ItemSchema.Sensitivity,
    '                        '                                                     EmailMessageSchema.From,
    '                        '                                                     EmailMessageSchema.CcRecipients,
    '                        '                                                     EmailMessageSchema.ToRecipients,
    '                        '                                                     EmailMessageSchema.InternetMessageId,
    '                        '                                                     ItemSchema.MimeContent)
    '                        'es.LoadPropertiesForItems(EMailMessage, itItemPropSet)




    '                        'Dim ContentBytes() As Byte = Convert.FromBase64String(ItemAttachment.MimeContent.Content().ToString())
    '                        'Dim ContentBytes() As Byte = Convert.FromBase64String(ItemAttachment.ToString())
    '                        'Dim mimeContent2 As Object = ItemAttachment.MimeContent
    '                        'Dim ContentBytesxy() As Byte = mimeContent2.Content
    '                        'Dim findResultsAtt As FindItemsResults(Of Item)
    '                        'findResultsAtt = es.GetAttachments((TypeFolder, view)


    '                        'rNewPlanAnhang.doku = ContentBytesxy
    '                        'Using Item2Disk As System.IO.Stream = New System.IO.FileStream(dirTmp & "\" + ItemAttachment.Subject + ".eml", System.IO.FileMode.Create)
    '                        '    Item2Disk.Write(ContentBytes, 0, ContentBytes.Length)
    '                        '    Item2Disk.Flush()
    '                        '    Item2Disk.Close()
    '                        'End Using
    '                    End If
    '                Next
    '                functionMarker += "12.1;"
    '            End If
    '            'Else
    '            '    Dim txtAnhang As String = "Account " + InfoExcept.Trim() + ", Info: E-Mail '" + rNewPlan.Betreff + "' from " + rNewPlan.empfangenAm.ToString() + ": Appendix not imported, because to Big! " + vbNewLine
    '            '    protokoll += txtAnhang
    '            '    protokollErr += txtAnhang
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("getAnhänge: " + ex.ToString())
    '    End Try
    'End Sub

    'Public Sub checkEmptyBodyEMails(ByRef es As ExchangeService,
    '                              ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef folderParent As Folder,
    '                              TypeFolder As WellKnownFolderName,
    '                              ByRef messages As System.Collections.Generic.List(Of clPlan.cMessage),
    '                              ByRef protokoll As String, ByRef protokollErr As String, ByRef doExept As Boolean,
    '                              ByRef IsRoot As Boolean,
    '                              ByRef datLastReceived As Date,
    '                              ByRef InfoMailService As clPlan.cInfoMailService,
    '                              ByRef dNow As Date,
    '                              ByRef InfoExcept As String)
    '    Try
    '        Dim dsPlanTmp As New dsPlan()
    '        Dim compPlanTmp As New compPlan()
    '        Dim datCheckUntil As Date = dNow.AddDays(-14)
    '        compPlanTmp.getPlan(Nothing, compPlan.eTypSelPlan.EmpfangenAmBigger, dsPlanTmp, "", "", datCheckUntil.Date)
    '        Dim arrPlan() As dsPlan.planRow = dsPlanTmp.plan.Select("", "empfangenAm desc")
    '        'Me.WriteProt("arrPlan.count = " + arrPlan.Length.ToString(), protokoll, protokollErr)

    '        Dim view As New ItemView(999999000)
    '        view.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending)
    '        view.Traversal = ItemTraversal.Shallow
    '        Dim findResults As FindItemsResults(Of Item)
    '        If IsRoot Then
    '            findResults = es.FindItems(TypeFolder, view)
    '        Else
    '            findResults = folderParent.FindItems(TypeFolder, view)
    '        End If
    '        'Me.WriteProt("Emails outlook Check.TotalCount = " + findResults.TotalCount.ToString() + "", protokoll, protokollErr)
    '        Dim iCounterLocal As Integer = 0
    '        For Each obj As Microsoft.Exchange.WebServices.Data.Item In findResults
    '            If TypeOf obj Is Microsoft.Exchange.WebServices.Data.EmailMessage Then
    '                Dim EMailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage = obj
    '                Dim dReceived As Date = Nothing
    '                dReceived = Me.IsNull(EMailMessage.DateTimeReceived, False, "DateTimeReceived")
    '                Dim SubjectTmp As String = ""
    '                SubjectTmp = Me.IsNull(EMailMessage.Subject, False, "Subject")

    '                If SubjectTmp.Trim().ToLower().Contains(("ATS-039-811").Trim().ToLower()) Then   'lthxy
    '                    Dim str As String = ""
    '                End If

    '                If dReceived = Nothing Then
    '                    Throw New Exception("EMailMessage.DateTimeReceived=Nothing for E-Mail '" + SubjectTmp.Trim() + "'!")
    '                End If
    '                Dim lastReceiveBack As Date = datLastReceived.AddDays(-14)
    '                If dReceived <= lastReceiveBack Then
    '                    Exit Sub
    '                End If
    '                If dReceived.Date < cOutlookWebAPI.dateExit.Date Then
    '                    Exit Sub
    '                End If
    '                Dim IDTmp As String = Me.IsNull(EMailMessage.InternetMessageId, False, "InternetMessageId")
    '                If IDTmp Is Nothing Then
    '                    Throw New Exception("EMailMessage.Id=Nothing for E-Mail '" + SubjectTmp.Trim() + "'!")
    '                End If
    '                If IDTmp.Trim() = "" Then
    '                    Throw New Exception("EMailMessage.Id='' for E-Mail '" + SubjectTmp.Trim() + "'!")
    '                End If
    '                Dim dReceivedTicks As New TimeSpan(dReceived.Ticks)
    '                Dim IDIntern As String = IDTmp.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '                'Me.WriteProt("1. " + SubjectTmp.Trim(), protokoll, protokollErr)

    '                For Each rPlanBodyEmpty As dsPlan.planRow In arrPlan
    '                    Dim iPosLastMessageID As Integer = rPlanBodyEmpty.MessageId.Trim().IndexOf("_ReceivedAt")
    '                    Dim ConversationIDTmp As String = rPlanBodyEmpty.MessageId.Trim().Substring(0, iPosLastMessageID)
    '                    'Me.WriteProt("2. " + rPlanBodyEmpty.Betreff.Trim(), protokoll, protokollErr)

    '                    If rPlanBodyEmpty.MessageId.Trim().Equals(IDIntern.Trim()) Then
    '                        'Me.WriteProt("3. " + rPlanBodyEmpty.Betreff.Trim(), protokoll, protokollErr)
    '                        'ATS-112-712_Arlt_Ulf_1800004     Stornogefahr PV-000-193
    '                        If rPlanBodyEmpty.Betreff.Trim().ToLower().StartsWith(("ATS-039-811").Trim().ToLower()) Then   'lthxy
    '                            Dim str As String = ""
    '                        End If
    '                        If Me.checkBodyIsEmpty(rPlanBodyEmpty.Text.Trim(), True) Then
    '                            Dim pSet As PropertySet = New PropertySet(BasePropertySet.FirstClassProperties)
    '                            'EMailMessage.Load(pSet)
    '                            EMailMessage.Load()
    '                            'Me.gen.waitTime(80)
    '                            'Me.WriteProt("nach EMailMessage.Load", protokoll, protokollErr)

    '                            Dim isHtml As Boolean = False
    '                            If Not EMailMessage.Body Is Nothing Then
    '                                If EMailMessage.Body.BodyType = BodyType.HTML Then
    '                                    isHtml = True
    '                                Else
    '                                    isHtml = False
    '                                End If
    '                                Dim TxtBodyTmp As String = ""
    '                                If Not EMailMessage.Body.Text Is Nothing Then
    '                                    TxtBodyTmp = EMailMessage.Body.Text.Trim()
    '                                End If
    '                                If Me.checkBodyIsEmpty(TxtBodyTmp.Trim(), True) Then
    '                                    Dim txtErr As String = "Info check E-Mail-Body: E-Mail '" + rPlanBodyEmpty.Betreff.Trim() + "' from '" + rPlanBodyEmpty.empfangenAm.ToString() + "' has body <html></html>!" + vbNewLine +
    '                                                                        "TextBody" + TxtBodyTmp.Trim()
    '                                    Me.WriteProt(txtErr, protokoll, protokollErr)
    '                                Else
    '                                    Dim dsPlanUpdate As New dsPlan()
    '                                    Dim compPlanUpdate As New compPlan()
    '                                    compPlanUpdate.getPlan(Nothing, compPlan.eTypSelPlan.MessageIdMIME, dsPlanUpdate, rPlanBodyEmpty.MessageId.Trim(), rPlanBodyEmpty.Für.Trim())
    '                                    Dim rPlanUpdate As dsPlan.planRow = dsPlanUpdate.plan.Rows(0)
    '                                    rPlanUpdate.Text = TxtBodyTmp.Trim()
    '                                    rPlanUpdate.html = isHtml
    '                                    compPlanUpdate.daPlan.Update(dsPlanUpdate.plan)

    '                                    Dim txtErr As String = "Info check E-Mail-Body: E-Mail '" + rPlanBodyEmpty.Betreff.Trim() + "' from '" + rPlanBodyEmpty.empfangenAm.ToString() + "' empty body corrected!" + vbNewLine +
    '                                                                    "TextBody" + TxtBodyTmp.Trim()
    '                                    Me.WriteProt(txtErr, protokoll, protokollErr)
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                Next
    '            End If
    '        Next

    '    Catch ex As Exception
    '        Dim sExcept As String = "checkEmptyBodyEMails.findItemsInFolder: Account " + InfoExcept.Trim() + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '        Throw New Exception(sExcept)
    '    End Try
    'End Sub

    'Public Function checkBodyIsEmpty(ByRef sBody As String, alsoCheckNoTxt As Boolean) As Boolean
    '    Try
    '        'If sBody.Trim().ToLower() = "<html></html>".Trim().ToLower() Or sBody.Trim() = "" Then
    '        'If sBody.StartsWith("<html></html>", StringComparison.InvariantCultureIgnoreCase) Then
    '        If StringComparer.CurrentCultureIgnoreCase.Equals(sBody.Trim(), "<html></html>".Trim()) Then
    '            Return True
    '        Else
    '            If alsoCheckNoTxt Then
    '                If sBody.Trim() = "" Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            Else
    '                Return False
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("checkBodyIsEmpty: " + ex.ToString())
    '    End Try
    'End Function

    'Public Sub WriteProt(ByRef txtErr As String, ByRef Protokoll As String, ByRef protokollErr As String)
    '    Me.addProtokoll(txtErr, Protokoll, True, False)
    '    Me.addProtokoll(txtErr, protokollErr, True, False)
    '    If Not Me.delDoInfoUI Is Nothing Then
    '        Me.delDoInfoUI.Invoke(txtErr, False, False)
    '    End If

    'End Sub










    'Public Function scannObjectsForEMails(ByRef MailFrom As String, ByRef tPlanObjects As dsPlan.planObjectDataTable, ByRef IDPlan As System.Guid,
    '                                        ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                        ByRef protokoll As String, ByRef functionMark As String) As Boolean
    '    Try
    '        If MailFrom.Trim() <> "" Then

    '            Dim b As New PMDS.db.PMDSBusiness()
    '            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
    '                Dim rUsr As PMDS.db.Entities.Benutzer = b.LogggedOnUser(db)
    '                'Dim rKontakt As PMDS.db.Entities.Kontakt = b.getKontakt(rUsr.IDKontakt, db)
    '                Dim arr As dsPlan.planObjectRow() = dsPlan1.planObject.Select(dsPlan1.planObject.IDPlanColumn.ColumnName + "='" + IDPlan.ToString() + "' and " + dsPlan1.planObject.IDObjectColumn.ColumnName + "='" + rUsr.ID.ToString() + "'")
    '                If arr.Length = 0 Then
    '                    Dim dsPlanCheck As New dsPlan()
    '                    Dim compPlanRead As New compPlan()
    '                    compPlanRead.getPlanObject(IDPlan, compPlan.eTypSelPlanObject.allIDPlan, dsPlanCheck)
    '                    Dim bExist As Boolean = False
    '                    For Each rPlanChecked As dsPlan.planObjectRow In dsPlanCheck.planObject
    '                        If rPlanChecked.IDObject.Equals(rUsr.ID) Then
    '                            bExist = True
    '                        End If
    '                    Next
    '                    If Not bExist Then
    '                        Dim rNewPlanObject As dsPlan.planObjectRow = compPlan1.getNewRowPlanObject(dsPlan1.planObject)
    '                        rNewPlanObject.IDPlan = IDPlan
    '                        rNewPlanObject.IDObject = rUsr.ID
    '                        functionMark += "17.1;"
    '                    End If
    '                End If
    '            End Using
    '            Return True
    '        Else
    '            'Throw New Exception("scannObjectsForEMails: MailFrom is empty!")
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("scannObjectsForEMails: " + ex.ToString())
    '    End Try
    'End Function

    'Public Function scannSubjectBodyForContract(ByRef TxtToCheck As String, ByRef isHtml As Boolean, ByRef Subject As String, ByRef dReceived As Date,
    '                                            ByRef tPlanObjects As dsPlan.planObjectDataTable, ByRef IDPlan As System.Guid,
    '                                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                            ByRef protokoll As String, ByRef functionMark As String, ByRef TypeScann As String,
    '                                            ByRef lstObjectsAdded As System.Collections.Generic.List(Of Guid)) As Boolean
    '    Dim sExceptInfoWord As String = ""
    '    Dim iCounterTmp As Integer = 0
    '    Try
    '        If TxtToCheck.Trim() <> "" Then
    '            Dim wordsCheck As String() = TxtToCheck.Trim().Split(" ")
    '            If wordsCheck.Length > 0 Then
    '                Dim dsPlanCheck As New dsPlan()
    '                Dim compPlanRead As New compPlan()

    '                Dim dt As New DataTable()
    '                Dim da As New OleDb.OleDbDataAdapter()
    '                Dim cmd As New OleDb.OleDbCommand()
    '                Dim sqlTxt As String = " Select ID, PolizzenNr from tblVertrag where PolizzenNr='?' "
    '                cmd.Connection = database.getConnDB()
    '                cmd.CommandTimeout = 0
    '                da.SelectCommand = cmd
    '                Dim iCounter As Integer = 0
    '                For Each wordCheck As String In wordsCheck
    '                    sExceptInfoWord = wordCheck.Trim()
    '                    iCounterTmp = iCounter
    '                    dt.Clear()
    '                    cmd.CommandText = sqlTxt
    '                    If wordCheck.Trim() <> "" Then
    '                        If wordCheck.Trim().Contains("1-003.") Then
    '                            Dim bStop As Boolean = True
    '                        End If

    '                        If wordCheck.Trim().Length >= 3 Then
    '                            If isHtml And wordCheck.Trim().StartsWith("&nbsp;") Then
    '                                wordCheck = wordCheck.Trim().Substring(6, wordCheck.Trim().Length - 6)
    '                            End If
    '                            Dim checkSign As String = "" + ControlChars.Quote + ">"
    '                            If isHtml And wordCheck.Trim().Contains(checkSign) Then
    '                                Dim iPos As Integer = wordCheck.Trim().IndexOf(checkSign)
    '                                wordCheck = wordCheck.Trim().Substring(iPos + 2, wordCheck.Trim().Length - iPos - 2)

    '                                checkSign = "<"
    '                                If wordCheck.Trim().Contains(checkSign) Then
    '                                    iPos = wordCheck.Trim().IndexOf(checkSign)
    '                                    If iPos > 0 Then
    '                                        wordCheck = wordCheck.Trim().Substring(0, iPos)
    '                                    End If
    '                                End If
    '                            End If

    '                            Me.scannSubjectBodySearchInDB(wordCheck, isHtml, Subject, dReceived, IDPlan, dsPlan1, compPlan1, dt, da, cmd,
    '                                                            dsPlanCheck, compPlanRead, sqlTxt, protokoll, functionMark, TypeScann, sExceptInfoWord, iCounterTmp,
    '                                                            lstObjectsAdded)

    '                            Dim lstWordsToCheckReturn As New System.Collections.Generic.List(Of String)()
    '                            Me.checkTxtForPoliceGetWords(wordCheck, isHtml, Subject, dReceived, lstWordsToCheckReturn, IDPlan, dsPlan1, compPlan1, dt, da, cmd,
    '                                                            dsPlanCheck, compPlanRead, sqlTxt, protokoll, functionMark, TypeScann, sExceptInfoWord, iCounterTmp)

    '                            For Each wordCheck2 As String In lstWordsToCheckReturn
    '                                Me.scannSubjectBodySearchInDB(wordCheck2, isHtml, Subject, dReceived, IDPlan, dsPlan1, compPlan1, dt, da, cmd,
    '                                                                dsPlanCheck, compPlanRead, sqlTxt, protokoll, functionMark, TypeScann, sExceptInfoWord, iCounterTmp,
    '                                                                lstObjectsAdded)
    '                            Next
    '                        End If
    '                    End If
    '                    iCounter += 1
    '                Next
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("scannSubjectBodyForContract: type scanning: " + TypeScann + " - Error in scann word:" + sExceptInfoWord + " - position in text:" + iCounterTmp.ToString() + vbNewLine + ex.ToString())
    '    End Try
    'End Function
    'Public Sub checkTxtForPoliceGetWords(ByRef wordCheck As String, ByRef isHtml As Boolean, ByRef Subject As String, ByRef dReceived As Date,
    '                                        ByRef lstWordsToCheckReturn As System.Collections.Generic.List(Of String),
    '                                        ByRef IDPlan As System.Guid,
    '                                        ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                        ByRef dt As DataTable, ByRef da As OleDb.OleDbDataAdapter, ByRef cmd As OleDb.OleDbCommand,
    '                                        ByRef dsPlanCheck As dsPlan, ByRef compPlanRead As compPlan, ByRef sqlTxt As String,
    '                                        ByRef protokoll As String, ByRef functionMark As String, ByRef TypeScann As String,
    '                                        ByRef sExceptInfoWord As String, ByRef iCounterTmp As Integer)
    '    Try
    '        Dim wordsCheckTmp1 As String() = wordCheck.Trim().Split("!")
    '        For Each wordCheck2 As String In wordsCheckTmp1
    '            Dim wordsCheckTmp2 As String() = wordCheck2.Trim().Split("?")
    '            For Each wordCheck3 As String In wordsCheckTmp2
    '                Dim wordsCheckTmp4 As String() = wordCheck3.Trim().Split(":")
    '                For Each wordCheck4 As String In wordsCheckTmp4
    '                    Dim wordsCheckTmp5 As String() = wordCheck4.Trim().Split(";")
    '                    For Each wordCheck5 As String In wordsCheckTmp5
    '                        Dim wordsCheckTmp6 As String() = wordCheck5.Trim().Split("(")
    '                        For Each wordCheck7 As String In wordsCheckTmp6
    '                            Dim wordsCheckTmp7 As String() = wordCheck7.Trim().Split(")")
    '                            For Each wordCheck8 As String In wordsCheckTmp7
    '                                Dim wordsCheckTmp8 As String() = wordCheck8.Trim().Split(",")
    '                                For Each wordCheck9 As String In wordsCheckTmp8
    '                                    Dim wordsCheckTmp9 As String() = wordCheck9.Trim().Split("'")
    '                                    For Each wordCheck10 As String In wordsCheckTmp9
    '                                        Dim wordsCheckTmp10 As String() = wordCheck10.Trim().Split("<")
    '                                        For Each wordCheck11 As String In wordsCheckTmp10
    '                                            Dim wordsCheckTmp11 As String() = wordCheck11.Trim().Split(">")
    '                                            For Each wordCheck12 As String In wordsCheckTmp11
    '                                                Dim wordsCheckTmp12 As String() = wordCheck12.Trim().Split(">")
    '                                                For Each wordCheck13 As String In wordsCheckTmp12
    '                                                    Dim wordsCheckTmp13 As String() = wordCheck13.Trim().Split(ControlChars.Quote)
    '                                                    For Each wordCheck14 As String In wordsCheckTmp13
    '                                                        Dim wordsCheckTmp14 As String() = wordCheck14.Trim().Split("'")
    '                                                        For Each wordCheck15 As String In wordsCheckTmp14
    '                                                            If wordCheck15.Trim().Length >= 3 Then
    '                                                                lstWordsToCheckReturn.Add(wordCheck15)
    '                                                            End If
    '                                                        Next
    '                                                    Next
    '                                                Next
    '                                            Next
    '                                        Next
    '                                    Next
    '                                Next
    '                            Next
    '                        Next
    '                    Next
    '                Next
    '            Next
    '        Next

    '    Catch ex As Exception
    '        Throw New Exception("checkTxtForPoliceGetWords: type scanning: " + TypeScann + " - Error in scann word:" + sExceptInfoWord + " - position in text:" + iCounterTmp.ToString() + vbNewLine + ex.ToString())
    '    End Try
    'End Sub

    'Public Sub scannSubjectBodySearchInDB(ByRef wordSubject As String, ByRef isHtml As Boolean, ByRef Subject As String, ByRef dReceived As Date,
    '                                            ByRef IDPlan As System.Guid,
    '                                            ByRef dsPlan1 As dsPlan, ByRef compPlan1 As compPlan,
    '                                            ByRef dt As DataTable, ByRef da As OleDb.OleDbDataAdapter, ByRef cmd As OleDb.OleDbCommand,
    '                                            ByRef dsPlanCheck As dsPlan, ByRef compPlanRead As compPlan, ByRef sqlTxt As String,
    '                                            ByRef protokoll As String, ByRef functionMark As String, ByRef TypeScann As String,
    '                                            ByRef sExceptInfoWord As String, ByRef iCounterTmp As Integer,
    '                                            ByRef lstObjectsAdded As System.Collections.Generic.List(Of Guid))
    '    Try
    '        dt.Clear()
    '        cmd.CommandText = sqlTxt
    '        cmd.CommandText = cmd.CommandText.Replace("?", wordSubject.Trim())
    '        Try
    '            da.Fill(dt)
    '        Catch ex As Exception
    '            Dim sExcept As String = ex.ToString()
    '        End Try

    '        If dt.Rows.Count = 1 Then
    '            Dim rPoliceFound As DataRow = dt.Rows(0)
    '            Dim guidContract As New Guid(rPoliceFound(0).ToString().Trim())
    '            Dim Police As String = rPoliceFound(1).ToString().Trim()

    '            dsPlanCheck.Clear()
    '            compPlanRead.getPlanObject(IDPlan, compPlan.eTypSelPlanObject.allIDPlan, dsPlanCheck)
    '            Dim bExist As Boolean = False
    '            For Each rPlanChecked As dsPlan.planObjectRow In dsPlanCheck.planObject
    '                If rPlanChecked.IDObject.Equals(guidContract) Then
    '                    bExist = True
    '                End If
    '            Next
    '            If Not bExist Then
    '                Dim bObjectAdded As Boolean = False
    '                For Each IDObjectAdded As Guid In lstObjectsAdded
    '                    If IDObjectAdded.Equals(guidContract) Then
    '                        bObjectAdded = True
    '                    End If
    '                Next
    '                If Not bObjectAdded Then
    '                    Dim rNewPlanObject As dsPlan.planObjectRow = compPlan1.getNewRowPlanObject(dsPlan1.planObject)
    '                    rNewPlanObject.IDPlan = IDPlan
    '                    rNewPlanObject.IDObject = guidContract
    '                    lstObjectsAdded.Add(rNewPlanObject.IDObject)

    '                    Dim txtInfoIsImported As String = "Info: " + TypeScann.Trim() + " '" + Subject.Trim() + "' from '" + dReceived.ToString() + "' auto-added to Police '" + Police.Trim() + "'!"
    '                    Me.addProtokoll(txtInfoIsImported, protokoll, True, False)
    '                    If Not Me.delDoInfoUI Is Nothing Then
    '                        Me.delDoInfoUI.Invoke(txtInfoIsImported, False, False)
    '                    End If
    '                    'functionMark += "18.1;"
    '                End If

    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("scannSubjectBodySearchInDB: type scanning: " + TypeScann + " - Error in scann word:" + sExceptInfoWord + " - position in text:" + iCounterTmp.ToString() + vbNewLine + ex.ToString())
    '    End Try
    'End Sub

    'Public Sub addProtokoll(ByRef txt As String, ByRef protokoll As String, ByRef zeilenumbruch As Boolean, ByRef nurZeilenumbruch As Boolean)

    '    If nurZeilenumbruch Then
    '        protokoll += vbNewLine
    '    Else
    '        protokoll += txt
    '        If zeilenumbruch Then
    '            protokoll += vbNewLine
    '        End If
    '    End If

    'End Sub
    'Public Sub saveLastReceivedDate(ByRef receiveActuellMail As Date, ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow)
    '    Try
    '        If Not rUserAccount.IslastReceiveNull() Then
    '            If receiveActuellMail > rUserAccount.lastReceive Then
    '                compUserAccounts1.updatelastReceive(rUserAccount.ID, receiveActuellMail)
    '                rUserAccount.lastReceive = receiveActuellMail
    '            End If
    '        Else
    '            compUserAccounts1.updatelastReceive(rUserAccount.ID, receiveActuellMail)
    '            rUserAccount.lastReceive = receiveActuellMail
    '        End If

    '    Catch ex As Exception
    '        Dim sExcept As String = "saveLastReceivedDate: " + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '        Throw New Exception(sExcept)
    '    End Try
    'End Sub
    'Public Function IsNull(ByRef oValue As Object, ByRef doException As Boolean, ByRef fieldDescription As String) As String
    '    Try
    '        If oValue = Nothing Then
    '            If doException Then
    '                Dim sExcept As String = "checkIfIsNull: Field " + fieldDescription.Trim() + "=null no allowed!" + vbNewLine + vbNewLine
    '                Throw New Exception(sExcept)
    '            Else
    '                Return ""
    '            End If
    '        Else
    '            If oValue Is System.DBNull.Value Then
    '                If doException Then
    '                    Dim sExcept As String = "checkIfIsNull: Field " + fieldDescription.Trim() + "=DBNull.value no allowed!" + vbNewLine + vbNewLine
    '                    Throw New Exception(sExcept)
    '                Else
    '                    Return ""
    '                End If
    '            Else
    '                Return oValue.ToString().Trim()
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Dim sExcept As String = "checkIfIsNull: " + vbNewLine + ex.ToString() + vbNewLine + vbNewLine
    '        Throw New Exception(sExcept)
    '    End Try
    'End Function

    'Public Function saveToOutlook(ByRef IDPlan As System.Guid, ByRef PostboxForAll As Boolean,
    '                              ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef TaskSetCompleteDate As Boolean) As Boolean
    '    Try
    '        'Dim dNow As Date = Now
    '        'If Not General.ActivateExchangeServicesOnClient Then
    '        '    Me.saveLastChangeOutlook(IDPlan)
    '        '    Return False
    '        'End If

    '        'If General.UrlOutlookWebAPI.Trim() <> "" Then
    '        '    Dim dsPlanRead As New dsPlan()
    '        '    Dim compPlanRead As New compPlan()
    '        '    compPlanRead.getPlan(IDPlan, compPlan.eTypSelPlan.id, dsPlanRead)
    '        '    Dim rPlanReaded As dsPlan.planRow = dsPlanRead.plan.Rows(0)
    '        '    If rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Or
    '        '        rPlanReaded.IDArt = clPlan.typPlan_Notiz Then

    '        '        Dim es As Microsoft.Exchange.WebServices.Data.ExchangeService = Me.getExchangeServiceObjForLoggedInUser(PostboxForAll, rUserAccount)

    '        '        Dim lstMailAn As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(rPlanReaded.MailAn.Trim())
    '        '        Dim lstMailAnCC As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(rPlanReaded.MailCC.Trim())
    '        '        Dim lstMailAnBCc As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(rPlanReaded.MailBcc.Trim())

    '        '        'compPlanRead.getPlanObject(rPlanReaded.ID, compPlan.eTypSelPlanObject.allIDPlan, dsPlanRead)
    '        '        'Dim compObject1 As New ITSCont.core.SystemDb.compObject()
    '        '        'Dim compObjectRead As New compObject()
    '        '        'For Each rObj As dsPlan.planObjectRow In dsPlanRead.planObject
    '        '        '    Dim rUsr As dsObject.tblObjectRow = compObjectRead.getObjectRow(rObj.IDObject, compObject.eTypSelObj.ID)
    '        '        '    lstObjectsToSend.Add(rUsr.)
    '        '        'Next

    '        '        If rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Then
    '        '            ''Dim IDoutlookTmp As String = rPlanReaded.IDoutlook.Trim()
    '        '            'Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '            'Dim searchFilter As SearchFilter = New SearchFilter.IsEqualTo(ItemSchema.Id, ItemId)
    '        '            'Dim view As New ItemView(100)
    '        '            'view.PropertySet = New PropertySet(BasePropertySet.FirstClassProperties, EmailMessageSchema.Subject)
    '        '            'Dim findResults As FindItemsResults(Of Item) = es.FindItems(WellKnownFolderName.Calendar, searchFilter, view)
    '        '            'If findResults.TotalCount = 1 Then
    '        '            'Else
    '        '            'End If

    '        '            Dim IsNew As Boolean = False
    '        '            Dim Appoinment As Microsoft.Exchange.WebServices.Data.Appointment = Nothing
    '        '            If rPlanReaded.IDoutlook.Trim() = "" Then
    '        '                Appoinment = New Microsoft.Exchange.WebServices.Data.Appointment(es)
    '        '                IsNew = True
    '        '            Else
    '        '                Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '                Try
    '        '                    Appoinment = Appointment.Bind(es, ItemId)
    '        '                    Appoinment.Load()
    '        '                Catch ex As Exception
    '        '                    If doUI.doMessageBox3("ItemNotFoundInOutlookCreateNewOne", "", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
    '        '                        Appoinment = New Microsoft.Exchange.WebServices.Data.Appointment(es)
    '        '                        IsNew = True
    '        '                    Else
    '        '                        Return False
    '        '                    End If
    '        '                End Try
    '        '            End If

    '        '            Appoinment.Subject = rPlanReaded.Betreff.Trim()
    '        '            If Not rPlanReaded.IsBeginntAmNull() Then
    '        '                Appoinment.Start = rPlanReaded.BeginntAm
    '        '            Else
    '        '                Appoinment.Start = rPlanReaded.ErstelltAm
    '        '            End If
    '        '            If Not rPlanReaded.IsFälligAmNull() Then
    '        '                Appoinment.End = rPlanReaded.FälligAm
    '        '            End If

    '        '            If Not rPlanReaded.html Then
    '        '                Appoinment.Body = rPlanReaded.Text
    '        '                'Dim txtControlSrv As New TXTextControl.ServerTextControl()
    '        '                'Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
    '        '                'txtControlSrv.Load(rPlanReaded.Text, TXTextControl.StreamType.PlainText, LoadSettings)
    '        '                'Dim SaveSettings As New TXTextControl.SaveSettings()
    '        '                'Dim BodyHtmlTmp As String = ""
    '        '                'txtControlSrv.Save(BodyHtmlTmp, TXTextControl.StreamType.HTMLFormat, SaveSettings)
    '        '                'Appoinment.Body = BodyHtmlTmp
    '        '            Else
    '        '                Appoinment.Body = rPlanReaded.Text
    '        '            End If

    '        '            For Each ToAdress As String In lstMailAn
    '        '                Appoinment.RequiredAttendees.Add(ToAdress.Trim())
    '        '            Next
    '        '            For Each ToAdress As String In lstMailAnCC
    '        '                Appoinment.RequiredAttendees.Add(ToAdress.Trim())
    '        '            Next
    '        '            For Each ToAdress As String In lstMailAnBCc
    '        '                Appoinment.OptionalAttendees.Add(ToAdress.Trim())
    '        '            Next

    '        '            'Me.UpdateCategoriesFromDBToExchange(es, WellKnownFolderName.Calendar, dNow, Appoinment, Nothing, rPlanReaded.Category.Trim())

    '        '            If IsNew Then
    '        '                Appoinment.Save(SendInvitationsMode.SendToAllAndSaveCopy)
    '        '                Appoinment.Load()

    '        '                rPlanReaded.ConversationID = Appoinment.ConversationId.UniqueId.ToString().Trim()
    '        '                rPlanReaded.IDoutlook = Appoinment.Id.UniqueId.ToString().Trim()
    '        '                Dim dReceivedTicks As New TimeSpan(rPlanReaded.BeginntAm.Ticks)
    '        '                Dim IDIntern As String = rPlanReaded.ConversationID.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        '                rPlanReaded.MessageId = IDIntern
    '        '                rPlanReaded.IDoutlookTicks = rPlanReaded.IDoutlook.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        '                compPlanRead.daPlan.Update(dsPlanRead)
    '        '            Else
    '        '                Dim mode As SendInvitationsOrCancellationsMode
    '        '                If Appoinment.IsMeeting Then
    '        '                    mode = SendInvitationsOrCancellationsMode.SendToAllAndSaveCopy
    '        '                Else
    '        '                    mode = SendInvitationsOrCancellationsMode.SendToNone
    '        '                End If
    '        '                Appoinment.Update(ConflictResolutionMode.AlwaysOverwrite, mode)
    '        '            End If

    '        '            Me.saveLastChangeOutlook(IDPlan)
    '        '            Return True

    '        '        ElseIf rPlanReaded.IDArt = clPlan.typPlan_Notiz Then
    '        '            Dim IsNew As Boolean = False
    '        '            Dim Task As Microsoft.Exchange.WebServices.Data.Task = Nothing
    '        '            If rPlanReaded.IDoutlook.Trim() = "" Then
    '        '                Task = New Microsoft.Exchange.WebServices.Data.Task(es)
    '        '                IsNew = True
    '        '            Else
    '        '                Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '                Try
    '        '                    Task = Task.Bind(es, ItemId)
    '        '                    Task.Load()
    '        '                Catch ex As Exception
    '        '                    If doUI.doMessageBox3(" ", "", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
    '        '                        Task = New Microsoft.Exchange.WebServices.Data.Task(es)
    '        '                        IsNew = True
    '        '                    Else
    '        '                        Return False
    '        '                    End If
    '        '                End Try
    '        '            End If

    '        '            Task.Subject = rPlanReaded.Betreff.Trim()
    '        '            If Not rPlanReaded.IsBeginntAmNull() Then
    '        '                Task.StartDate = rPlanReaded.BeginntAm
    '        '            Else
    '        '                Task.StartDate = rPlanReaded.ErstelltAm
    '        '            End If
    '        '            If TaskSetCompleteDate AndAlso (Not rPlanReaded.IsFälligAmNull()) Then
    '        '                Task.CompleteDate = rPlanReaded.FälligAm
    '        '            End If

    '        '            If Not rPlanReaded.html Then
    '        '                Task.Body = rPlanReaded.Text
    '        '                'Dim txtControlSrv As New TXTextControl.ServerTextControl()
    '        '                'Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
    '        '                'txtControlSrv.Load(rPlanReaded.Text, TXTextControl.StreamType.PlainText, LoadSettings)
    '        '                'Dim SaveSettings As New TXTextControl.SaveSettings()
    '        '                'Dim BodyHtmlTmp As String = ""
    '        '                'txtControlSrv.Save(BodyHtmlTmp, TXTextControl.StreamType.HTMLFormat, SaveSettings)
    '        '                'Task.Body = BodyHtmlTmp
    '        '            Else
    '        '                Task.Body = rPlanReaded.Text
    '        '            End If

    '        '            'Me.UpdateCategoriesFromDBToExchange(es, WellKnownFolderName.Calendar, dNow, Nothing, Task, rPlanReaded.Category.Trim())

    '        '            If IsNew Then
    '        '                Task.Save()
    '        '                Task.Load()

    '        '                rPlanReaded.ConversationID = Task.ConversationId.UniqueId.ToString().Trim()
    '        '                rPlanReaded.IDoutlook = Task.Id.UniqueId.ToString().Trim()
    '        '                Dim dReceivedTicks As New TimeSpan(rPlanReaded.BeginntAm.Ticks)
    '        '                Dim IDIntern As String = rPlanReaded.ConversationID.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        '                rPlanReaded.MessageId = IDIntern
    '        '                rPlanReaded.IDoutlookTicks = rPlanReaded.IDoutlook.Trim() + "_ReceivedAt" + dReceivedTicks.ToString()
    '        '                compPlanRead.daPlan.Update(dsPlanRead)
    '        '            Else
    '        '                Task.Update(ConflictResolutionMode.AlwaysOverwrite, False)
    '        '            End If

    '        '            Me.saveLastChangeOutlook(IDPlan)
    '        '            Return True

    '        '        End If
    '        '    End If
    '        'End If

    '    Catch ex As Exception
    '        Me.saveLastChangeOutlook(IDPlan)
    '        Throw New Exception("cOutlookWebAPI.saveToOutlook: " + ex.ToString())
    '    End Try
    'End Function
    'Public Function saveContactToExchange(ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow, ByRef IDObject As System.Guid) As Boolean
    '    Dim sInfo As String = ""
    '    Try
    '        'Dim dNow As Date = Now
    '        'Dim dsObjectUpdate As New dsObject()
    '        'Dim compObjectUpdate As New compObject()

    '        ''Dim compUserAccountsRead As New compUserAccounts()
    '        ''Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = compUserAccountsRead.getUserAccountsRow(IDUserAccount, "", compUserAccounts.eTypSelUserAccounts.id, compUserAccounts.eTypEMailAccount.Pop3, True, True)
    '        'Dim dsObjectSupervisor As New dsObject()
    '        'Dim compObjectSupervisor As New compObject()
    '        'compObjectSupervisor.getObject(Nothing, dsObjectSupervisor, compObject.eTypSelObj.usr, compObject.eTypObj.none, rUserAccount.Usr.Trim(), False, "", "", "")
    '        'If dsObjectSupervisor.tblObject.Rows.Count <> 1 Then
    '        '    Throw New Exception("saveContactToExchange: dsObjectSupervisor.tblObject.Rows.Count<>1 for IDObject '" + rUserAccount.Usr.Trim() + "'!")
    '        'End If
    '        'Dim rObjSupervisor As dsObject.tblObjectRow = dsObjectSupervisor.tblObject.Rows(0)

    '        'compObjectUpdate.getObject(IDObject, dsObjectUpdate, compObject.eTypSelObj.ID)
    '        'Dim rObj As dsObject.tblObjectRow = dsObjectUpdate.tblObject.Rows(0)
    '        'sInfo = " (Object: " + rObj.Name.Trim() + ")"

    '        'Dim rAdressMain As dsObject.tblAdressenRow = Nothing
    '        'Dim rAdressSecond As dsObject.tblAdressenRow = Nothing
    '        'compObjectUpdate.getAdressen(rObj.ID, dsObjectUpdate, compObject.eTypSelAdr.idObject)
    '        'For Each rAdress As dsObject.tblAdressenRow In dsObjectUpdate.tblAdressen
    '        '    If rAdress.Hauptwohnsitz Then
    '        '        rAdressMain = rAdress
    '        '    Else
    '        '        If rAdressSecond Is Nothing Then
    '        '            rAdressSecond = rAdress
    '        '        End If
    '        '    End If
    '        'Next

    '        'compObjectUpdate.getObjectZusatz(rObj.ID, dsObjectUpdate, compObject.eTypSelZusatz.idObject)
    '        'Dim rNewObjzusatz As dsObject.tblObjectZusatzRow = dsObjectUpdate.tblObjectZusatz.Rows(0)

    '        ''If Not rObj.IsIDOutlookNull() Then
    '        ''End If

    '        'Dim es As Microsoft.Exchange.WebServices.Data.ExchangeService = Me.getExchangeServiceObjForLoggedInUser(rUserAccount.PostOfficeBoxForAll, rUserAccount)
    '        'Dim ContactToUpdate As New Microsoft.Exchange.WebServices.Data.Contact(es)

    '        'If rObj.IsPerson Then
    '        '    ContactToUpdate.Surname = rObj.Vorname.Trim()
    '        '    ContactToUpdate.GivenName = rObj.Nachname.Trim()
    '        '    ContactToUpdate.NickName = ContactToUpdate.Surname
    '        '    ContactToUpdate.DisplayName = ContactToUpdate.GivenName
    '        'Else
    '        '    ContactToUpdate.CompanyName = rObj.Name.Trim()
    '        '    ContactToUpdate.NickName = ContactToUpdate.CompanyName.Trim()
    '        '    ContactToUpdate.DisplayName = ContactToUpdate.CompanyName.Trim()
    '        '    ContactToUpdate.GivenName = ContactToUpdate.CompanyName.Trim()
    '        'End If

    '        'ContactToUpdate.JobTitle = rObj.Titel.Trim()
    '        'ContactToUpdate.Body = New MessageBody(BodyType.HTML, "")
    '        'ContactToUpdate.BusinessHomePage = rAdressMain.Web.Trim()

    '        'ContactToUpdate.Save()
    '        'ContactToUpdate.Load()

    '        'Dim bMailSetForContactGroup As Boolean = False
    '        'Dim bEMail1Set As Boolean = False
    '        'If rAdressMain.EmailBeruflich.Trim() <> "" Then
    '        '    ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1) = New EmailAddress(rAdressMain.EmailBeruflich.Trim())
    '        '    bMailSetForContactGroup = True
    '        '    bEMail1Set = True
    '        '    If rAdressMain.Email.Trim() <> "" Then
    '        '        ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2) = New EmailAddress(rAdressMain.Email.Trim())
    '        '        bEMail1Set = True
    '        '    End If
    '        'Else
    '        '    If rAdressMain.Email.Trim() <> "" Then
    '        '        ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress1) = New EmailAddress(rAdressMain.Email.Trim())
    '        '        bMailSetForContactGroup = True
    '        '        bEMail1Set = True
    '        '    Else
    '        '        If rAdressMain.EmailBeruflich2.Trim() <> "" Then
    '        '            ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress2) = New EmailAddress(rAdressMain.EmailBeruflich2.Trim())
    '        '        End If
    '        '    End If
    '        'End If
    '        'If rAdressMain.EMailBenachrichtigung.Trim() <> "" Then
    '        '    ContactToUpdate.EmailAddresses(EmailAddressKey.EmailAddress3) = New EmailAddress(rAdressMain.EMailBenachrichtigung.Trim())
    '        'End If

    '        ''ContactToUpdate.Update(ConflictResolutionMode.AlwaysOverwrite)
    '        ''ContactToUpdate.Load()

    '        'Dim adr1Entry As PhysicalAddressEntry = New PhysicalAddressEntry()
    '        'adr1Entry.PostalCode = rAdressMain.PLZ.Trim()
    '        'adr1Entry.City = rAdressMain.Ort.Trim()
    '        'adr1Entry.Street = rAdressMain.Straße.Trim()
    '        'adr1Entry.CountryOrRegion = "" 'rAdressMain.LandKZ.Trim()
    '        'adr1Entry.State = rAdressMain.LandKZ.Trim()
    '        'ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Business) = adr1Entry
    '        ''ContactToUpdate.Update(ConflictResolutionMode.AlwaysOverwrite)
    '        ''ContactToUpdate.Load()

    '        'If Not rAdressSecond Is Nothing Then
    '        '    Dim adr2Entry As PhysicalAddressEntry = New PhysicalAddressEntry()
    '        '    adr2Entry.PostalCode = rAdressSecond.PLZ.Trim()
    '        '    adr2Entry.City = rAdressSecond.Ort.Trim()
    '        '    adr2Entry.Street = rAdressSecond.Straße.Trim()
    '        '    adr2Entry.CountryOrRegion = "" 'rAdressSecond.LandKZ.Trim()
    '        '    adr2Entry.State = rAdressSecond.LandKZ.Trim()
    '        '    ContactToUpdate.PhysicalAddresses(PhysicalAddressKey.Home) = adr2Entry
    '        'End If

    '        'Dim PrimPhone As String = ""
    '        'If rAdressMain.TelMobil.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.MobilePhone) = rAdressMain.TelMobil.Trim()
    '        '    PrimPhone = rAdressMain.TelMobil.Trim()
    '        'End If
    '        'If rAdressMain.TelGesch.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone) = rAdressMain.TelGesch.Trim()
    '        '    If PrimPhone.Trim() = "" Then
    '        '        PrimPhone = rAdressMain.TelGesch.Trim()
    '        '    End If
    '        'End If
    '        'If rAdressMain.TelGesch2.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessPhone2) = rAdressMain.TelGesch2.Trim()
    '        'End If
    '        'If rAdressMain.TelPrivat.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomePhone) = rAdressMain.TelPrivat.Trim()
    '        '    If PrimPhone.Trim() = "" Then
    '        '        PrimPhone = rAdressMain.TelPrivat.Trim()
    '        '    End If
    '        'End If
    '        'If rAdressMain.TelMobil2.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.OtherTelephone) = rAdressMain.TelMobil2.Trim()
    '        'End If

    '        'If PrimPhone.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.PrimaryPhone) = PrimPhone.Trim()
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.CarPhone) = PrimPhone.Trim()
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.CompanyMainPhone) = PrimPhone.Trim()
    '        'End If
    '        ''ContactToUpdate.PhoneNumbers(PhoneNumberKey.AssistantPhone) = "AssistantPhone"

    '        'If rAdressMain.Fax.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.HomeFax) = rAdressMain.Fax.Trim()
    '        'End If
    '        'If rAdressMain.FaxBeruflich.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.BusinessFax) = rAdressMain.FaxBeruflich.Trim()
    '        'End If
    '        'If rAdressMain.Fax2.Trim() <> "" Then
    '        '    ContactToUpdate.PhoneNumbers(PhoneNumberKey.OtherFax) = rAdressMain.Fax2.Trim()
    '        'End If

    '        'ContactToUpdate.Update(ConflictResolutionMode.AlwaysOverwrite)
    '        'ContactToUpdate.Load()

    '        'Dim ContactGroup As ContactGroup = Nothing
    '        'ContactGroup = Me.searchContactGroup(es, "ITSCont")
    '        'If ContactGroup Is Nothing Then
    '        '    Dim newContactGroup As ContactGroup = New ContactGroup(es)
    '        '    newContactGroup.DisplayName = "ITSCont"
    '        '    newContactGroup.Save()
    '        '    newContactGroup.Members.AddContactEmailAddress(ContactToUpdate, EmailAddressKey.EmailAddress1)
    '        '    newContactGroup.Update(ConflictResolutionMode.AlwaysOverwrite)

    '        '    ContactGroup = newContactGroup
    '        'End If

    '        'If bMailSetForContactGroup Then
    '        '    Dim gm As GroupMember = New GroupMember(ContactToUpdate, EmailAddressKey.EmailAddress1)
    '        '    ContactGroup.Members.Add(gm)
    '        '    ContactGroup.Update(ConflictResolutionMode.AlwaysOverwrite)
    '        'End If

    '        'rObj.FromExchange = True
    '        'rObj.IDOutlook = ContactToUpdate.Id.UniqueId.ToString()
    '        'rObj.DatumImport = dNow
    '        'rObj.LastChangeExchange = dNow
    '        'rObj.IDBetreuer = rObjSupervisor.ID
    '        'compObjectUpdate.daObject.Update(dsObjectUpdate.tblObject)

    '        'Dim b As New ITSContBusiness()
    '        'If Not b.checkIfObjectExistsInObjectSub(rObj.ID) Then
    '        '    compObjectUpdate.getObjectSub(System.Guid.NewGuid(), dsObjectUpdate, Nothing)
    '        '    Dim rNewObjSub As dsObject.tblObjectSubRow = compObjectUpdate.getNewRowObjectSub(dsObjectUpdate)
    '        '    rNewObjSub.IDObject = rObj.ID
    '        '    rNewObjSub.IDObjectMain = rObjSupervisor.ID
    '        '    rNewObjSub.TypeMain = "ContactExportedToExchangeFromUser"
    '        '    rNewObjSub.Created = dNow
    '        '    rNewObjSub.CreatedFrom = actUsr.rUsr.usr.Trim()
    '        '    compObjectUpdate.daObjectsSub.Update(dsObjectUpdate.tblObjectSub)
    '        'End If

    '        'Dim dsSearchObjectsUpdate As New dsSearchObjects()
    '        'compObjectUpdate.getObjectImport("", rObj.ID, dsSearchObjectsUpdate, "", -1, "", rObj.ID)
    '        'If dsSearchObjectsUpdate.tblObjectImport.Rows.Count > 0 Then
    '        '    For Each rObjImport As dsSearchObjects.tblObjectImportRow In dsSearchObjectsUpdate.tblObjectImport
    '        '        rObjImport.IDOutlook = rObj.IDOutlook
    '        '    Next
    '        '    compObjectUpdate.daObjectImport.Update(dsSearchObjectsUpdate.tblObjectImport)
    '        'End If
    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.saveContactToExchange: Object " + sInfo.Trim() + vbNewLine + ex.ToString())
    '    End Try
    'End Function


    'Public Function deleteOutlookItem(ByRef IDPlan As System.Guid, ByRef PostboxForAll As Boolean) As Boolean
    '    Try
    '        'If Not General.ActivateExchangeServicesOnClient Then
    '        '    Return False
    '        'End If

    '        'If General.UrlOutlookWebAPI.Trim() <> "" Then
    '        '    Dim dsPlanRead As New dsPlan()
    '        '    Dim compPlanRead As New compPlan()
    '        '    compPlanRead.getPlan(IDPlan, compPlan.eTypSelPlan.id, dsPlanRead)
    '        '    Dim rPlanReaded As dsPlan.planRow = dsPlanRead.plan.Rows(0)
    '        '    If rPlanReaded.IDoutlook.Trim() <> "" Then
    '        '        If rPlanReaded.IDArt = clPlan.typPlan_EMailEmpfangen Or
    '        '            rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Or
    '        '            rPlanReaded.IDArt = clPlan.typPlan_Notiz Then

    '        '            Dim es As Microsoft.Exchange.WebServices.Data.ExchangeService = Me.getExchangeServiceObjForLoggedInUser(PostboxForAll, Nothing)
    '        '            If rPlanReaded.IDArt = clPlan.typPlan_EMailEmpfangen Then
    '        '                Dim EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage = Nothing
    '        '                Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '                Try
    '        '                    EmailMessage = EmailMessage.Bind(es, ItemId)
    '        '                    EmailMessage.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Catch ex As Exception
    '        '                End Try

    '        '                'Dim EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage = EmailMessage.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '        '                'EmailMessage.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Return True

    '        '            ElseIf rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Then
    '        '                Dim Appoinment As Microsoft.Exchange.WebServices.Data.Appointment = Nothing
    '        '                Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '                Try
    '        '                    Appoinment = Appointment.Bind(es, ItemId)
    '        '                    Appoinment.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Catch ex As Exception
    '        '                End Try

    '        '                'Dim Appoinment As Microsoft.Exchange.WebServices.Data.Appointment = Appointment.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '        '                'Appoinment.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Return True

    '        '            ElseIf rPlanReaded.IDArt = clPlan.typPlan_Notiz Then
    '        '                Dim Task As Microsoft.Exchange.WebServices.Data.Task = Nothing
    '        '                Dim ItemId As New ItemId(rPlanReaded.IDoutlook.Trim())
    '        '                Try
    '        '                    Task = Task.Bind(es, ItemId)
    '        '                    Task.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Catch ex As Exception
    '        '                End Try

    '        '                'Dim Task As Microsoft.Exchange.WebServices.Data.Task = Task.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '        '                'Task.Delete(DeleteMode.MoveToDeletedItems)
    '        '                Return True

    '        '            End If
    '        '        End If
    '        '    End If
    '        'End If

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.deleteOutlookItem: " + ex.ToString())
    '    End Try
    'End Function

    'Public Function setReaded(ByRef IDPlan As System.Guid, ByRef IsReaded As Boolean, ByRef NotMarkAsReaded As Boolean, ByRef PostboxForAll As Boolean) As Boolean
    '    Try
    '        If Not General.ActivateExchangeServicesOnClient Then
    '            Return False
    '        End If

    '        Dim doMarkingAsReaded As Boolean = True
    '        If PMDS.Global.Settings.adminSecure Then
    '            If NotMarkAsReaded Then
    '                doMarkingAsReaded = False
    '            End If
    '        End If

    '        If General.UrlOutlookWebAPI.Trim() <> "" And doMarkingAsReaded Then
    '            Dim dsPlanRead As New dsPlan()
    '            Dim compPlanRead As New compPlan()
    '            compPlanRead.getPlan(IDPlan, compPlan.eTypSelPlan.id, dsPlanRead)
    '            Dim rPlanReaded As dsPlan.planRow = dsPlanRead.plan.Rows(0)
    '            If rPlanReaded.IDoutlook.Trim() <> "" Then
    '                If rPlanReaded.IDArt = clPlan.typPlan_EMailEmpfangen Or
    '                    rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Or
    '                    rPlanReaded.IDArt = clPlan.typPlan_Notiz Then

    '                    Dim es As Microsoft.Exchange.WebServices.Data.ExchangeService = Me.getExchangeServiceObjForLoggedInUser(PostboxForAll, Nothing)
    '                    If rPlanReaded.IDArt = clPlan.typPlan_EMailEmpfangen Then
    '                        Dim EmailMessage As Microsoft.Exchange.WebServices.Data.EmailMessage = EmailMessage.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '                        EmailMessage.IsRead = IsReaded
    '                        EmailMessage.Update(ConflictResolutionMode.AlwaysOverwrite)
    '                        Return True

    '                        'ElseIf rPlanReaded.IDArt = clPlan.typPlan_AufgabeTermin Then
    '                        '    Dim Appoinment As Microsoft.Exchange.WebServices.Data.Appointment = Appointment.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '                        '    Appoinment.Delete(DeleteMode.MoveToDeletedItems)
    '                        '    Return True

    '                        'ElseIf rPlanReaded.IDArt = clPlan.typPlan_Notiz Then
    '                        '    Dim Task As Microsoft.Exchange.WebServices.Data.Task = Task.Bind(es, rPlanReaded.IDoutlook.Trim(), New PropertySet())
    '                        '    Task.Delete(DeleteMode.MoveToDeletedItems)
    '                        '    Return True

    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As Microsoft.Exchange.WebServices.Data.ServiceResponseException
    '        Dim sExcept As String = ex.ToString()    'lthxy
    '        'Throw New Exception("cOutlookWebAPI.setReaded: " + ex.ToString())
    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.setReaded: " + ex.ToString())
    '    End Try
    'End Function

    'Public Function getExchangeServiceObjForLoggedInUser(ByRef PostboxForAll As Boolean,
    '                                                     ByRef rUserAccount As dsUserAccounts.tblUserAccountsRow) As Microsoft.Exchange.WebServices.Data.ExchangeService
    '    Try
    '        If General.UrlOutlookWebAPI.Trim() <> "" Then
    '            Dim compUserAccountsRead As New compUserAccounts()
    '            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
    '            If (rUserAccount Is Nothing) Then
    '                If PostboxForAll Then
    '                    rUserAccount = compUserAccountsRead.getUserAccountsRow(Nothing, "", compUserAccounts.eTypSelUserAccounts.PostOfficeBoxForAll, compUserAccounts.eTypEMailAccount.Pop3, False, True)
    '                    If rUserAccount Is Nothing Then
    '                        rUserAccount = compUserAccountsRead.getUserAccountsRow(Nothing, UserLoggedIn.Trim(), compUserAccounts.eTypSelUserAccounts.usr, compUserAccounts.eTypEMailAccount.Pop3, True, True)
    '                    End If
    '                Else
    '                    rUserAccount = compUserAccountsRead.getUserAccountsRow(Nothing, UserLoggedIn.Trim(), compUserAccounts.eTypSelUserAccounts.usr, compUserAccounts.eTypEMailAccount.Pop3, True, True)
    '                End If
    '            End If

    '            Dim cOutlookWebAPI1 As New cOutlookWebAPI()
    '            Dim UsrAuthenticationTmp As String = cOutlookWebAPI1.getUserForOutlookWebAPI(rUserAccount)

    '            Dim es As New Microsoft.Exchange.WebServices.Data.ExchangeService(ExchangeVersion.Exchange2013_SP1)
    '            es.Url = New Uri(General.UrlOutlookWebAPI.Trim())
    '            es.Credentials = New System.Net.NetworkCredential(UsrAuthenticationTmp.Trim(), rUserAccount.PwdAuthentication.Trim())

    '            Return es
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.getExchangeServiceObjForLoggedInUser: " + ex.ToString())
    '    End Try
    'End Function

    'Public Function saveLastChangeOutlook(ByRef IDPlan As System.Guid) As Boolean
    '    Try
    '        Dim compPlanUpdate As New compPlan()
    '        compPlanUpdate.updateLstChangeToOutlook(IDPlan)
    '        Return True

    '    Catch ex As Exception
    '        Throw New Exception("cOutlookWebAPI.saveLastChangeOutlook: " + ex.ToString())
    '    End Try
    'End Function

End Class
