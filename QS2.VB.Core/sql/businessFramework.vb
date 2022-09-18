Imports qs2.core.db.ERSystem
Imports qs2.core.vb

Imports System.Collections
Imports System.Data.Common
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Imports System.Linq.Expressions
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity

Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.OleDb

Imports qs2.db.Entities
Imports qs2.core.vb.DTOs

Public Class businessFramework


    Private sqlAdminWork As qs2.core.vb.sqlAdmin = Nothing
    Private dsAllProcedures As qs2.core.vb.dsAdmin = Nothing
    Private dsAdminWork As qs2.core.vb.dsAdmin = Nothing

    Public dsObjectsWork As dsObjects = Nothing
    Public sqlObjectsWork As sqlObjects = Nothing

    Private IsInitialized As Boolean = False

    Private _Application As String = ""
    Private _Participant As String = ""

    Public Enum eTypeProtocoll
        onlyMessageBox = 0
        MessageBoxAndProtocoll = 1
        onlyProtocoll = 2
    End Enum

    Public Shared sWhereRolesUserObj As String = ""
    Public Shared bWhereRolesUserObj As Boolean = False

    Public Delegate Sub StatusUI(txt As String)
    Public Shared delStatusUI As StatusUI = Nothing

    Public Class cSelListAndObj
        'Public rRoleObj As dsAdmin.getAllUsersWithRolesRow = Nothing
        Public rSelList As dsAdmin.tblSelListEntriesRow = Nothing
        Public rSelListObj As dsAdmin.tblSelListEntriesObjRow = Nothing
        Public anyUserFoundForRole As Boolean = False
        Public RoleFoundInDefinition As Boolean = False
    End Class

    Public Class cProtEntry
        Public ShortInfo As String = ""
        Public MedRecNr As String = ""
        Public ChangedAt As String = ""
        Public FromUser As String = ""
        Public Participant As String = ""
        Public IDStay As Integer = -1
        Public Application As String = ""

        Public ProtFrom As Date = Nothing

        Public lstProtDetail As New System.Collections.Generic.List(Of cProtEntryDetail)
    End Class
    Public Class cProtEntryDetail
        Public ColName As String = ""
        Public FldShort As String = ""
        Public ImputType As String = ""
        Public OldValue As String = ""
        Public OldValueDB As String = ""
        Public NewValue As String = ""
        Public NewValueDB As String = ""
        Public SqlTable As String = ""

        Public IDStay As Integer = -1
        Public Application As String = ""
        Public IDParticipant = ""

        Public ProtFrom As Date = Nothing
    End Class


    Public Class objSel
        Public Property PatExtID As String = ""
        Public Property NameCombination As String = ""
        Public Property MedRecN As String = ""
        Public Property AdmitDt As DateTime = Nothing
        Public Property SurgDtStartDt As DateTime? = Nothing
        Public Property ID As Integer = 0
        Public Property IDGuid As Guid = Guid.Empty
    End Class

    Public Shared Property dsSysDB1 As core.SysDB.dsSysDB = Nothing
    Public Shared Property sqlSysDB1 As core.SysDB.sqlSysDB = Nothing











    Public Sub Inititialize(Application As String, Participant As String, loadAllProcedures As Boolean)
        Try
            If Me.IsInitialized Then
                Exit Sub
            End If

            Me.dsAllProcedures = New qs2.core.vb.dsAdmin()
            Me.dsAdminWork = New qs2.core.vb.dsAdmin()
            Me.sqlAdminWork = New qs2.core.vb.sqlAdmin()
            Me.sqlAdminWork.initControl()

            Me.dsObjectsWork = New dsObjects()
            Me.sqlObjectsWork = New sqlObjects()
            Me.sqlObjectsWork.initControl()

            Me._Application = Application
            Me._Participant = Participant

            If loadAllProcedures Then
                Me.LoadAllProcedures("Procedures", Me._Application, Me._Participant, False)
            End If

            Me.IsInitialized = True

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.Inititialize: " + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function getIncidenceForMedRecNr(ByRef rStay As dsObjects.tblStayRow, ByRef ActualMeRecNr As String) As Integer
        Try
            Return Me.sqlObjectsWork.getIncidenceForMedRecNr(ActualMeRecNr, rStay.IDParticipant, rStay.IDApplication)

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getIncidenceForMedRecNr: " + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Sub doMessage(ByRef IDRessourceOrTxt As String, ByRef FldShort As String, ByRef TypeProtocoll As eTypeProtocoll,
                                  ByRef tProtocolToAdd As qs2.core.vb.dsAdmin.protokollDataTable, ByRef supressFldShort As Boolean)
        Try
            Dim Translation As String = qs2.core.language.sqlLanguage.getRes(IDRessourceOrTxt.Trim()).Trim()
            If Translation.Trim() = "" Then
                Translation = IDRessourceOrTxt.Trim()
            End If

            If TypeProtocoll = eTypeProtocoll.onlyProtocoll Or TypeProtocoll = eTypeProtocoll.MessageBoxAndProtocoll Then
                Dim rProt As qs2.core.vb.dsAdmin.protokollRow = Me.sqlAdminWork.getNewRowProtocol(tProtocolToAdd)
                rProt.TextMessage = Translation
                rProt.TextControl = FldShort.Trim()
                rProt.supress = supressFldShort
            End If

            If TypeProtocoll = eTypeProtocoll.onlyMessageBox Or TypeProtocoll = eTypeProtocoll.MessageBoxAndProtocoll Then
                qs2.core.generic.showMessageBox(IDRessourceOrTxt.Trim(), Windows.Forms.MessageBoxButtons.OK, "")
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.doMessage: " + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function getMainProcedure(ByRef IDStay As Integer,
                                     ByRef rSelListProcedure As qs2.core.vb.dsAdmin.tblSelListEntriesRow,
                                     ByRef rSelListProcGrp As qs2.core.vb.dsAdmin.tblSelListEntriesRow,
                                     ByRef rObjProcedure As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow) As Boolean
        Try
            Me.dsAdminWork.Clear()
            Me.dsAllProcedures.tblSelListEntriesObj.Rows.Clear()
            Me.sqlAdminWork.getSelListEntrysObj(-999, qs2.core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, qs2.core.vb.sqlAdmin.eDbTypAuswObj.ProceduresToStay.ToString(),
                                                Me.dsAllProcedures,
                                                qs2.core.vb.sqlAdmin.eTypAuswahlObj.IDStayTypIDGroup, Me._Application,
                                                -999, "", IDStay, Me._Participant, -999)

            Me.LoadAllProcedures("Procedures", Me._Application, "ALL", True)

            For Each rObj As qs2.core.vb.dsAdmin.tblSelListEntriesObjRow In Me.dsAllProcedures.tblSelListEntriesObj
                For Each rSelList As qs2.core.vb.dsAdmin.tblSelListEntriesRow In Me.dsAllProcedures.tblSelListEntries
                    If rObj.IDSelListEntry.Equals(rSelList.ID) Then
                        If rObj.IsMain Then
                            rObjProcedure = rObj
                            rSelListProcedure = rSelList

                            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
                            Dim arrSellistEntries() As qs2.core.vb.dsAdmin.tblSelListEntriesRow = Me.sqlAdminWork.getSelListEntrys(Parameters, "", "", "", Me.dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.IDRam, "", -999, "", rObj.IDSelListEntrySublist, "", "")
                            If arrSellistEntries.Length <> 1 Then
                                Throw New Exception("doProductsAll.getMainProcedure: Me.dsAdminWork.tblSelListEntries.Rows.Count <> 1 for rObj.IDSelListEntrySublist '" + rObj.IDSelListEntrySublist.ToString() + "', IDStay='" + IDStay.ToString() + "'!")
                            End If
                            rSelListProcGrp = arrSellistEntries(0)

                            Return True
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getMainProcedure: " + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Sub LoadAllProcedures(Group As String, Application As String, Participant As String, ByRef onlyMainProc As Boolean)
        Try
            Me.dsAllProcedures.tblSelListEntries.Rows.Clear()
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Me.sqlAdminWork.getSelListEntrysAll(Parameters, Group.Trim(), Me.dsAllProcedures, qs2.core.vb.sqlAdmin.eTypAuswahlList.group,
                                     Participant, Application)

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.LoadAllProcedures: " + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function AutoDelete() As Boolean
        Try
            Dim sqlObjectsUpdate As New sqlObjects()

            If ENV.XMonthDeleteStaysStartUp >= 0 Then
                'sqlObjectsUpdate.deleteStays_AutoStart()
            End If
            If ENV.DeletePatientsNoStayStartUp Then
                'sqlObjectsUpdate.deletePatients_AutoStart()
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.AutoDelete: " + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getCriteria(ByRef FldShort As String, ByRef Application As String,
                                ByRef FieldForALLProducts As Boolean) As qs2.core.vb.dsAdmin.tblCriteriaRow
        Try
            Dim arrCriteria() As qs2.core.vb.dsAdmin.tblCriteriaRow = Nothing
            Dim IDApplicationTmp As String = ""
            If FieldForALLProducts Then
                IDApplicationTmp = core.license.doLicense.eApp.ALL.ToString()
                arrCriteria = Me.sqlAdminWork.getCriterias(Me.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam,
                                                           FldShort.Trim(), IDApplicationTmp.Trim(), False, False, False, "", "", False)
            Else
                IDApplicationTmp = Application
                arrCriteria = Me.sqlAdminWork.getCriterias(Me.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam,
                                                           FldShort.Trim(), IDApplicationTmp.Trim(), False, False, False, "", "", False)
            End If
            If arrCriteria.Length <> 1 Then
                Throw New Exception("buisLogAdmin.getCriteria: No Criteria found for FldShort '" + FldShort.ToString() + "' and Application '" + Application.ToString() + "'!")
            End If
            Return arrCriteria(0)

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getCriteria:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function saveCriteria(ByRef rCriteriaToSave As qs2.core.vb.dsAdmin.tblCriteriaRow) As Boolean
        Try
            Dim dsAdmindnUpdate As New dsAdmin()
            Dim sqlAdminUpdate As New sqlAdmin()
            sqlAdminUpdate.initControl()

            sqlAdminUpdate.getCriterias(dsAdmindnUpdate, qs2.core.vb.sqlAdmin.eTypSelCriteria.id,
                                                       rCriteriaToSave.FldShort.Trim(), rCriteriaToSave.IDApplication.Trim(), False, False, False, "", "", False)
            If dsAdmindnUpdate.tblCriteria.Rows.Count <> 1 Then
                Throw New Exception("buisLogAdmin.saveCriteria: No Criteria found for FldShort '" + rCriteriaToSave.FldShort.ToString() + "' and Application '" + rCriteriaToSave.IDApplication.ToString() + "'!")
            End If

            Dim rCriteriaUpdate As qs2.core.vb.dsAdmin.tblCriteriaRow = dsAdmindnUpdate.tblCriteria.Rows(0)
            rCriteriaUpdate.ItemArray = rCriteriaToSave.ItemArray
            sqlAdminUpdate.daCriteria.Update(dsAdmindnUpdate.tblCriteria)

            Return True

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.saveCriteria:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function checkRigthButtons(IDSelListButton As Integer, IDUser As Integer) As Boolean
        Try
            Dim arrSeLListButton() As dsAdmin.getButtonsForUserRow = sqlAdmin.dsAllAdmin.getButtonsForUser.Select(" IDSelListChapter=" + IDSelListButton.ToString() + " and IDObject=" + IDUser.ToString())
            If arrSeLListButton.Length > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthButtons:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Sub checkChapterClassification(IDSelListButton As Integer, IDUser As Integer, ByRef ChapterAlwaysEditable As Boolean, Chapter As String)
        Try
            Dim sWhere As String = " IDSelListChapter=" + IDSelListButton.ToString() + " and IDObject=" + IDUser.ToString() + " and IDClassification like '%Type=EditableWhenCompleted;%'"
            Dim arrSeLListButtonChaptersAlwaysEditable() As dsAdmin.GetChaptersAlwaysEditableAllUsersRow = sqlAdmin.dsAllAdmin.GetChaptersAlwaysEditableAllUsers.Select(sWhere)
            If arrSeLListButtonChaptersAlwaysEditable.Length > 0 Then
                ChapterAlwaysEditable = True
            Else
                ChapterAlwaysEditable = False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthButtons:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Function checkRigthChapterForUserxyxy(IDOwnStrChapter As String, IDUser As Integer, IDApplication As String) As Boolean
        Try
            If IDUser <= -99 Then
                Throw New Exception("checkRigthChapterForuser: IDUser <= -99 not allowed!")
            End If

            Dim arrvSelListAllChapters0 As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Chapters0.ToString(), IDApplication, "")
            Dim arrvSelListAllChapters1 As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Chapters1.ToString(), IDApplication, "")

            Dim sWhereChapters As String = ""
            Me.getWhere(arrvSelListAllChapters0, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                                        sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, False, sWhereChapters, sqlTxt.or)
            Me.getWhere(arrvSelListAllChapters1, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                            sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereChapters, sqlTxt.or)

            Dim arrvSelListAllRoles As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Roles.ToString(), license.doLicense.eApp.ALL.ToString(), "")
            Dim sWhereRoles As String = ""
            Me.getWhere(arrvSelListAllRoles, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                      sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereRoles, sqlTxt.or)
            Dim arrSelListRolesUser As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, IDUser, sWhereRoles, "", "", "")

            Dim sWhereRolesForChapters As String = ""
            If arrSelListRolesUser.Length > 0 Then
                Me.getWhere(arrSelListRolesUser, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName,
                                sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName, True, sWhereRolesForChapters, sqlTxt.or)
                Dim arrSelListRigthChapters As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, -999, sWhereChapters, sWhereRolesForChapters, "", "")
                If Not arrSelListRigthChapters Is Nothing Then
                    For Each rSelListRigthChapter As dsAdmin.tblSelListEntriesObjRow In arrSelListRigthChapters
                        Dim sWhereSelList As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDColumn.ColumnName + "=" + rSelListRigthChapter.IDSelListEntry.ToString() + ""
                        Dim arrSelList() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhereSelList)
                        Dim rSelList As dsAdmin.tblSelListEntriesRow = arrSelList(0)
                        If rSelList.IDOwnStr.Trim().ToLower().Equals(IDOwnStrChapter.Trim.ToLower()) Then
                            Return True
                        End If
                    Next
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthChapterForuser:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkRigthProcGroupForUserxyxy(IDOwnStrProcGrp As String, IDUser As Integer, IDApplication As String) As Boolean
        Try
            If IDUser <= -99 Then
                Throw New Exception("checkRigthProcGroupForUser: IDUser <= -99 not allowed!")
            End If

            Dim arrvSelListAllProcGrp0 As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.ProcGrp0.ToString(), IDApplication, "")
            Dim arrvSelListAllProcGrp1 As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.ProcGrp1.ToString(), IDApplication, "")

            Dim sWhereChapters As String = ""
            Me.getWhere(arrvSelListAllProcGrp0, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                                        sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, False, sWhereChapters, sqlTxt.or)
            Me.getWhere(arrvSelListAllProcGrp1, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                            sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereChapters, sqlTxt.or)

            Dim arrvSelListAllRoles As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Roles.ToString(), license.doLicense.eApp.ALL.ToString(), "")
            Dim sWhereRoles As String = ""
            Me.getWhere(arrvSelListAllRoles, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                      sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereRoles, sqlTxt.or)
            Dim arrSelListRolesUser As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, IDUser, sWhereRoles, "", "", "")

            Dim sWhereRolesForProcGrp As String = ""
            If arrSelListRolesUser.Length > 0 Then
                Me.getWhere(arrSelListRolesUser, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName,
                                sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName, True, sWhereRolesForProcGrp, sqlTxt.or)
                Dim arrSelListRigthProcGroups As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, -999, sWhereChapters, sWhereRolesForProcGrp, "", "")
                If Not arrSelListRigthProcGroups Is Nothing Then
                    For Each rSelListRigthProcGroup As dsAdmin.tblSelListEntriesObjRow In arrSelListRigthProcGroups
                        Dim sWhereSelList As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDColumn.ColumnName + "=" + rSelListRigthProcGroup.IDSelListEntry.ToString() + ""
                        Dim arrSelList() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhereSelList)
                        Dim rSelList As dsAdmin.tblSelListEntriesRow = arrSelList(0)
                        If rSelList.IDOwnStr.Trim().ToLower().Equals(IDOwnStrProcGrp.Trim.ToLower()) Then
                            Return True
                        End If
                    Next
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthProcGroupForUser:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function checkRigthFldShortForRole(FldShort As String, IDUser As Integer, ByRef IDApplication As String, ByRef HasCriteria As Boolean) As Boolean
        Try
            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Return True
            End If

            Dim sWhere As String = "FldShort='" + FldShort.Trim() + "' and (IDApplication='" + IDApplication.Trim() + "' or IDApplication='ALL')"
            Dim arrRightCriteria() As qs2.core.vb.dsAdmin.getCriteriasForUserRow = qs2.core.vb.sqlAdmin.dsAllAdmin.getCriteriasForUser.Select(sWhere, "")
            If arrRightCriteria.Length > 0 Then
                Dim rigthOKnVisible As Integer = Me.checkRigthFldShortForRoleUser(FldShort, IDUser, IDApplication, HasCriteria)
                If rigthOKnVisible = -1 Or rigthOKnVisible = 1 Then
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthFldShortForFole:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkRigthFldShortForRoleUser(FldShort As String, IDUser As Integer, ByRef IDApplication As String, ByRef HasCriteria As Boolean) As Integer
        Try
            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Return 1
            End If

            Dim sWhere As String = "FldShort='" + FldShort.Trim() + "' and (IDApplication='" + IDApplication.Trim() + "' or IDApplication='ALL')"
            Dim arrRightCriteriaUser() As qs2.core.vb.dsAdmin.getCriteriasUserForUserRow = qs2.core.vb.sqlAdmin.dsAllAdmin.getCriteriasUserForUser.Select(sWhere, "")
            If arrRightCriteriaUser.Length > 0 Then
                Dim rRightCriteriaUser As qs2.core.vb.dsAdmin.getCriteriasUserForUserRow = arrRightCriteriaUser(0)
                If rRightCriteriaUser.IsnVisibleNull() Then
                    Return -1
                Else
                    Return rRightCriteriaUser.nVisible
                End If
            Else
                Return -1
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthFldShortForRoleUser:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkLicenseKey(FldShort As String, Application As String, dsAdmin1 As dsAdmin) As Boolean
        Try
            Dim b2 As New core.db.ERSystem.businessFramework()
            Dim rCriteriaFound As qs2.core.vb.dsAdmin.tblCriteriaRow = Nothing
            Dim HasCriteria As Boolean = False
            Me.checkCriteria(FldShort, Application, HasCriteria, rCriteriaFound, dsAdmin1)
            If Not rCriteriaFound Is Nothing Then
                If rCriteriaFound.LicenseKey.Trim() = "" Then
                    Return True
                Else
                    Dim lstLicenseKeys As New System.Collections.Generic.List(Of String)()
                    lstLicenseKeys = Me.getVariablesLicenseKeys(rCriteriaFound.LicenseKey.Trim())
                    Dim bHasLicenseKey As Boolean = b2.checkLicenseKey(lstLicenseKeys, FldShort.Trim(), Application.Trim())
                    If Not bHasLicenseKey Then
                        Dim bHasLicense As Boolean = True
                    End If
                    Return bHasLicenseKey
                End If
            Else
                Throw New Exception("checkLicenseKey: no Criteria found for FldShort '" + FldShort.Trim() + "' and Application '" + Application.Trim() + "'!")
                'Return True
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkLicenseKey: " + ex.ToString())
        End Try
    End Function
    Public Function checkRigthFldShortForRolexyxy(FldShort As String, IDUser As Integer, ByRef IDApplication As String, ByRef HasCriteria As Boolean) As Boolean
        Try
            If FldShort.Trim() = "" Then
                Throw New Exception("checkRigthFldShortForRole: FldShort='' not allowed!")
            End If
            If IDUser <= -99 Then
                Throw New Exception("checkRigthFldShortForRole: IDUser <= -99 not allowed!")
            End If

            Me.Inititialize(IDApplication, qs2.core.license.doLicense.eApp.ALL.ToString(), False)
            Dim rCriteriaBack As dsAdmin.tblCriteriaRow = Nothing
            Me.checkCriteria(FldShort, IDApplication, HasCriteria, rCriteriaBack, Me.dsAdminWork)

            'businessFramework.sWhereRolesUserObj = ""
            Dim sWhereRolesUserForFldShort As String = " " + sqlAdmin.dsAllAdmin.tblSelListEntriesObj.FldShortColumn.ColumnName + "='" + FldShort.Trim() + "' "
            If Not businessFramework.bWhereRolesUserObj Then
                Dim arrvSelListAllRoles As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Roles.ToString(), license.doLicense.eApp.ALL.ToString(), "")
                Dim sWhereRoles As String = ""
                Me.getWhere(arrvSelListAllRoles, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                          sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereRoles, sqlTxt.or)
                Dim arrSelListRolesUser As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, IDUser, sWhereRoles, "", "", "")

                Me.getWhere(arrSelListRolesUser, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                              sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName, True, businessFramework.sWhereRolesUserObj, sqlTxt.or)

                businessFramework.bWhereRolesUserObj = True
            Else
                Dim xy As String = ""
            End If

            If businessFramework.sWhereRolesUserObj.Trim() = "" Then
                Return False
            End If

            sWhereRolesUserForFldShort += " and " + businessFramework.sWhereRolesUserObj
            Dim arrSelListRightFldShortForRole As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, -999, sWhereRolesUserForFldShort, "", IDApplication,
                                                                                                    "Criterias_Roles")
            If Not arrSelListRightFldShortForRole Is Nothing Then
                If arrSelListRightFldShortForRole.Length > 0 Then
                    'For Each rSelListRigthChapter As dsAdmin.tblSelListEntriesObjRow In arrSelListRightFldShortForRole
                    'Next
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthFldShortForFole:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Sub checkCriteria(ByRef FldShort As String, ByRef IDApplication As String, ByRef HasCriteria As Boolean,
                             ByRef rCriteriaBack As dsAdmin.tblCriteriaRow, ByRef dsAdminTmp As dsAdmin)
        Try
            Me.Inititialize("", "", False)

            dsAdminTmp.Clear()
            Dim arrCriteria() As dsAdmin.tblCriteriaRow = Me.sqlAdminWork.getCriterias(dsAdminTmp, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, IDApplication,
                                                            False, False, False, "", "", False)
            If arrCriteria.Length > 1 Then
                Throw New Exception("buisLogAdmin.checkCriteria: arrCriteria.Length > 1 for FldShor '" + FldShort.Trim() + "' not allowed!")
            End If
            If arrCriteria.Length = 1 Then
                HasCriteria = True
                rCriteriaBack = arrCriteria(0)
                Exit Sub
            ElseIf arrCriteria.Length = 0 Then
                dsAdminTmp.Clear()
                arrCriteria = Me.sqlAdminWork.getCriterias(dsAdminTmp, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                                False, False, False, "", "", False)
                If arrCriteria.Length > 1 Then
                    Throw New Exception("buisLogAdmin.checkCriteria: arrCriteria.Length > 1 for FldShor '" + FldShort.Trim() + "' not allowed!")
                End If
                If arrCriteria.Length = 1 Then
                    HasCriteria = True
                    rCriteriaBack = arrCriteria(0)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkCriteria:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Function checkRigthStay(ByRef IDGuidStay As System.Guid, ByRef Application As String, ByRef RunAsSystemuser As Boolean, ByRef runAsUserID As Integer,
                                        ByRef WithMsgBox As Boolean)
        Try
            Dim IDUserTmp As Integer = qs2.core.vb.actUsr.rUsr.ID
            If RunAsSystemuser Then
                IDUserTmp = runAsUserID
            End If

            Dim b As New qs2.core.vb.businessFramework()
            Dim bRigthOK As Boolean = False
            If qs2.core.ENV.ControlOpenStayType = 0 Then
                bRigthOK = b.checkIsAdminOrUserIsInStayAsObject(IDGuidStay, IDUserTmp, Application, False)
            ElseIf qs2.core.ENV.ControlOpenStayType = 1 Then
                bRigthOK = b.checkIsAdminOrUserIsInStayAsObject(IDGuidStay, IDUserTmp, Application, True)
            Else
                Throw New Exception("checkRigthStay: ENV.ControlOpenStayType '" + ENV.ControlOpenStayType.ToString() + "' not allowed in config-File!")
            End If

            If bRigthOK Then
                Return True
            Else
                If WithMsgBox Then
                    If qs2.core.ENV.ControlOpenStayType = 0 Then   'Dieser Eingriff entspricht nicht Ihrer Rollenzuordnung.
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRight_RoleRestriction"), Windows.Forms.MessageBoxButtons.OK, "")
                    Else 'Diesen Eingriff darf nur der Operateur und seine berechtigten Vertreter ändern.
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRight_RoleRestriciton_Extended"), Windows.Forms.MessageBoxButtons.OK, "")
                    End If
                End If
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRigthStay: " + ex.ToString())
        End Try
    End Function

    Public Function checkRolesUser(checkVersion2 As Boolean, IDApplication As String, FldShortColumn As String, Table As String) As Boolean
        Try
            Dim lstRolesForUserActive As New System.Collections.Generic.List(Of cSelListAndObj)
            Me.getAllRolesForUser(actUsr.rUsr.ID, lstRolesForUserActive, False)
            If lstRolesForUserActive.Count = 0 Then
                Return False
            End If

            'Dim lstRolesToCheckFromConfig As New System.Collections.Generic.List(Of String)
            'Dim bProveRole As Boolean = False
            'If checkVersion2 Then
            '    sqlObjectsWork.getObjectRel(actUsr.rUsr.IDGuid, dsObjectsWork, sqlObjects.eTypSelAnspr.idObjectSub)
            '    lstRolesToCheckFromConfig = qs2.core.generic.readStrVariables(qs2.core.ENV.ControlOpenStayTypeRoles.Trim())
            '    For Each cRoleUser As cSelListAndObj In lstRolesForUserActive
            '        For Each cRoleToCheck As String In lstRolesToCheckFromConfig
            '            If cRoleUser.rSelList.IDOwnInt.Equals(System.Convert.ToInt32(cRoleToCheck.Trim())) Then
            '                bProveRole = True
            '            End If
            '        Next
            '    Next
            'End If

            Dim HasCriteria As Boolean = False
            Dim rCriteriaBack As dsAdmin.tblCriteriaRow = Nothing
            Me.checkCriteria(FldShortColumn.Trim(), IDApplication, HasCriteria, rCriteriaBack, Me.dsAdminWork)
            If Not HasCriteria Then
                Throw New Exception("buisLogAdmin.checkIsAdminOrUserIsInStayAsObject: No criteria found for objectField '" + FldShortColumn.Trim() + "' in table '" + Table.Trim() + "'!")
            End If

            'Dim lstRolesToCheckFromConfig As New System.Collections.Generic.List(Of String)
            'Dim bAnyUserFoundAllRoles As Boolean = False
            'Dim lstVarDeputyCriteriaExists As Boolean = False
            'Dim bUserFound As Boolean = False
            Dim lstRolesCriteriaClassifications As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
            lstRolesCriteriaClassifications = Me.getVariablesClassification(rCriteriaBack.Classification.Trim())
            'Dim lstClassificationsVarIDOwnInt As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
            'Dim lstVarIDOwnIntClassification As System.Collections.Generic.List(Of qs2.core.Enums.cVariables) = Nothing
            'Dim IDObjectInDBBack As Integer = -1
            'Me.checkRoleUser(actUsr.rUsr.ID, IDApplication, checkVersion2, lstRolesForUserActive, lstVarIDOwnIntClassification, lstRolesToCheckFromConfig,
            '                                FldShortColumn, Table, rStay, bAnyUserFoundAllRoles, bUserFound, IDObjectInDBBack, lstVarDeputyCriteriaExists)
            'If bUserFound Then
            '    Return True
            'End If

            Dim HasRole As Boolean = False
            For Each cRoleUser As cSelListAndObj In lstRolesForUserActive
                For Each VarIDOwnIntClassification As qs2.core.Enums.cVariables In lstRolesCriteriaClassifications
                    If VarIDOwnIntClassification.definition.Trim().ToLower().Equals("IDOwnInt".Trim().ToLower()) Then
                        If cRoleUser.rSelList.IDOwnInt.Equals(System.Convert.ToInt32(VarIDOwnIntClassification.value)) Then
                            Return True
                        End If
                    End If
                Next
            Next


            'If checkVersion2 Then
            '    If Not IsDeputy Then
            '        Return False
            '    End If
            'End If
            'For Each cRoleUser As cSelListAndObj In lstRolesForUserActive
            '    For Each VarIDOwnIntClassification As qs2.core.Enums.cVariables In lstVarIDOwnIntClassification
            '        Dim bRoleCheck As Boolean = False
            '        If checkVersion2 Then
            '            For Each cRoleToCheckFromConfig As String In lstRolesToCheckFromConfig
            '                If System.Convert.ToInt32(VarIDOwnIntClassification.value.Trim()).Equals(System.Convert.ToInt32(cRoleToCheckFromConfig.Trim())) Then
            '                    bRoleCheck = True
            '                End If
            '            Next
            '        Else
            '            bRoleCheck = True
            '        End If

            '        If bRoleCheck And cRoleUser.rSelList.IDOwnInt.Equals(System.Convert.ToInt32(VarIDOwnIntClassification.value)) Then
            '            IDObjectInDBBack = Me.getIDObjectFromComboStay(FldShortColumn.Trim(), Table.Trim(), rStay)
            '            'If IDObjectInDB <> -1 And IDUser.Equals(IDObjectInDB) Then
            '            If IDObjectInDBBack <> -1 Then
            '                Dim bCheck As Boolean = False
            '                If checkVersion2 Then
            '                    If IDObjectInDBBack.Equals(IDUser) Then
            '                        bCheck = True
            '                    Else
            '                        'Version Graz
            '                        'Wenn angemeldeter User Rolle Admin hat, dann darf er den Stay öffnen, wenn der Operateur die selbe zweite Rolle hat
            '                        bAnyUserFoundAllRoles = True
            '                        Dim lstRolesForUserInComboBox2 As New System.Collections.Generic.List(Of cSelListAndObj)
            '                        Me.getAllRolesForUser(IDObjectInDBBack, lstRolesForUserInComboBox2, False)
            '                        For Each cRoleUserInVombo As cSelListAndObj In lstRolesForUserInComboBox2
            '                            If cRoleUser.rSelList.IDOwnInt.Equals(cRoleUserInVombo.rSelList.IDOwnInt) Then
            '                                cRoleUser.anyUserFoundForRole = True
            '                                For Each cRoleUserLoggedIn As cSelListAndObj In lstRolesForUserActive
            '                                    If cRoleUserLoggedIn.rSelList.IDOwnInt.Equals(11) Then
            '                                        bUserFound = True
            '                                    End If
            '                                Next
            '                            End If
            '                        Next
            '                    End If
            '                Else
            '                    bCheck = True
            '                End If
            '                If bCheck Then
            '                    bAnyUserFoundAllRoles = True
            '                    Dim lstRolesForUserInComboBox As New System.Collections.Generic.List(Of cSelListAndObj)
            '                    Me.getAllRolesForUser(IDObjectInDBBack, lstRolesForUserInComboBox, False)
            '                    For Each cRoleUserInVombo As cSelListAndObj In lstRolesForUserInComboBox
            '                        If cRoleUser.rSelList.IDOwnInt.Equals(cRoleUserInVombo.rSelList.IDOwnInt) Then
            '                            cRoleUser.anyUserFoundForRole = True
            '                            bUserFound = True
            '                        End If
            '                    Next
            '                End If
            '            End If
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRolesUser: " + ex.ToString())
        End Try
    End Function
    Public Function checkIsAdminOrUserIsInStayAsObject(IDGuidStay As System.Guid, IDUser As Integer, IDApplication As String, ByRef checkVersion2 As Boolean) As Boolean
        Try
            If IDUser <= -99 Then
                Throw New Exception("checkIsAdminOrUserIsInStayAsObject: IDUser <= -99 not allowed!")
            End If
            Me.Inititialize("", "", False)

            If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Or qs2.core.ENV.IgnoreRoles Then
                Return True
            End If

            Dim dsAdminTmp As New dsAdmin()
            Dim sqlAdminTmp As New sqlAdmin()
            sqlAdminTmp.initControl()

            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()
            Dim rUser As qs2.core.vb.dsObjects.tblObjectRow = sqlObjectsTmp.getObjectRow(IDUser, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
            If rUser.isAdmin Then
                Return True
            End If
            Dim rStay As qs2.core.vb.dsObjects.tblStayRow = sqlObjectsTmp.getStaysRow(-999, sqlObjects.eTypSelStay.IDGuidStay, "", Enums.eStayTyp.All, "", IDGuidStay, False)
            If rStay.StayTyp = qs2.core.Enums.eStayTyp.Stay Then
                'get Roles for user
                Dim lstRolesForUserActive As New System.Collections.Generic.List(Of cSelListAndObj)
                Me.getAllRolesForUser(IDUser, lstRolesForUserActive, False)
                If (Not checkVersion2) And lstRolesForUserActive.Count = 0 Then
                    Return False
                End If

                Dim bProveRole As Boolean = False
                Dim lstRolesToCheckFromConfig As New System.Collections.Generic.List(Of String)
                dsObjectsWork.tblObjectRel.Clear()
                If checkVersion2 Then
                    'qs2.core.ENV.ControlOpenStayType=1
                    Dim sSumControlOpenStayTypeRoles As String = ""
                    sqlObjectsWork.getObjectRel(rUser.IDGuid, dsObjectsWork, sqlObjects.eTypSelAnspr.idObjectSub)
                    lstRolesToCheckFromConfig = qs2.core.generic.readStrVariables(qs2.core.ENV.ControlOpenStayTypeRoles.Trim())
                    For Each cRoleUser As cSelListAndObj In lstRolesForUserActive
                        For Each cRoleToCheck As String In lstRolesToCheckFromConfig
                            sSumControlOpenStayTypeRoles += cRoleToCheck + ";"
                            If cRoleUser.rSelList.IDOwnInt.Equals(System.Convert.ToInt32(cRoleToCheck.Trim())) Then
                                bProveRole = True
                            End If
                        Next
                    Next
                Else
                    'qs2.core.ENV.ControlOpenStayType=0
                End If

                'get Object-Fields from product-Stays with Criterias
                Dim dsAdminDeputy As New dsAdmin()
                Dim bUserFound As Boolean = False
                Dim arrSelListObjFieldInDB() As dsAdmin.tblSelListEntriesRow = Nothing
                Me.getAllObjectFieldsInProductStay(arrSelListObjFieldInDB, False, IDApplication)
                Dim bAnyUserFoundAllRoles As Boolean = False
                For Each rSelListObjFieldInDB As dsAdmin.tblSelListEntriesRow In arrSelListObjFieldInDB
                    Dim HasCriteria As Boolean = False
                    Dim rCriteriaBack As dsAdmin.tblCriteriaRow = Nothing
                    Me.checkCriteria(rSelListObjFieldInDB.FldShortColumn.Trim(), IDApplication, HasCriteria, rCriteriaBack, Me.dsAdminWork)
                    If Not HasCriteria Then
                        Throw New Exception("buisLogAdmin.checkIsAdminOrUserIsInStayAsObject: No criteria found for objectField '" + rSelListObjFieldInDB.FldShortColumn.Trim() + "' in table '" + rSelListObjFieldInDB._Table.Trim() + "'!")
                    End If
                    'If rCriteriaBack.Classification.Trim() <> "" Then
                    '    Throw New Exception("buisLogAdmin.checkIsAdminOrUserIsInStayAsObject: rCriteriaBack.Classification.Trim() = "" for objectField '" + rSelListObjFieldInDB.FldShortColumn.Trim() + "' in table '" + rSelListObjFieldInDB._Table.Trim() + "'!")
                    'End If

                    If rCriteriaBack.Classification.Trim() <> "" Then
                        'get Roles for Criterias for Object-Fields from Product-Stays
                        Dim lstAllClassifications As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
                        lstAllClassifications = Me.getVariablesClassification(rCriteriaBack.Classification.Trim())

                        Dim b As New core.vb.businessFramework()
                        Dim lstClassificationsVarIDOwnIntAll As New List(Of qs2.core.Enums.cVariables)()

                        Dim lstClassificationsVarIDOwnIntNoApp As New List(Of qs2.core.Enums.cVariables)()
                        lstClassificationsVarIDOwnIntNoApp = b.getValueVariableClassification(qs2.core.Enums.cVariablesDefinition.IDOwnInt, lstAllClassifications)
                        qs2.core.generic.getListVarIDOwnInt(lstClassificationsVarIDOwnIntNoApp, lstClassificationsVarIDOwnIntAll, False)

                        Dim lstClassificationsVarIDOwnIntApp As New List(Of qs2.core.Enums.cVariables)()
                        lstClassificationsVarIDOwnIntApp = b.getValueVariableClassificationStr(qs2.core.Enums.cVariablesDefinition.IDOwnInt.ToString() + rStay.IDApplication.Trim(), lstAllClassifications)
                        qs2.core.generic.getListVarIDOwnInt(lstClassificationsVarIDOwnIntApp, lstClassificationsVarIDOwnIntAll, True)

                        'Dim lstClassificationsVarIDOwnInt As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
                        'Dim lstVarIDOwnIntClassification As System.Collections.Generic.List(Of qs2.core.Enums.cVariables) = Nothing
                        'lstVarIDOwnIntClassification = Me.getValueVariableClassification(Enums.cVariablesDefinition.IDOwnInt, lstAllClassifications)
                        If lstClassificationsVarIDOwnIntAll.Count = 0 Then
                            Throw New Exception("buisLogAdmin.checkIsAdminOrUserIsInStayAsObject: lstVarIDOwnInt.Count = 0 for objectField '" + rSelListObjFieldInDB.FldShortColumn.Trim() + "' in table '" + rSelListObjFieldInDB._Table.Trim() + "'!")
                        End If

                        Dim lstVarDeputyCriteriaExists As Boolean = False
                        Dim lstVarDeputyCriteria As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)()
                        If checkVersion2 Then
                            lstVarDeputyCriteria = Me.getValueVariableClassification(Enums.cVariablesDefinition.DeputyCriteria, lstAllClassifications)
                            If lstVarDeputyCriteria.Count > 0 Then
                                lstVarDeputyCriteriaExists = True
                            End If
                        End If

                        Dim IDObjectInDBBack As Integer = -1
                        Me.checkRoleUser(IDUser, IDApplication, checkVersion2, lstRolesForUserActive, lstClassificationsVarIDOwnIntAll, lstRolesToCheckFromConfig,
                                            rSelListObjFieldInDB.FldShortColumn, rSelListObjFieldInDB._Table, rStay, bAnyUserFoundAllRoles, bUserFound, IDObjectInDBBack, lstVarDeputyCriteriaExists)
                        If bUserFound Then
                            Return True
                        End If

                        Dim IDObjectInDBForCriteria As Integer = -1
                        If checkVersion2 And lstVarDeputyCriteriaExists Then
                            IDObjectInDBForCriteria = Me.getIDObjectFromComboStay(rSelListObjFieldInDB.FldShortColumn.Trim(), rSelListObjFieldInDB._Table.Trim(), rStay)
                            If IDObjectInDBForCriteria <> -1 Then
                                bAnyUserFoundAllRoles = True
                            End If
                        End If

                        If checkVersion2 And (Not bUserFound) Then
                            For Each CriteriaDeputy As qs2.core.Enums.cVariables In lstVarDeputyCriteria
                                dsAdminDeputy.Clear()
                                Dim rCriteriaBackDeputy As dsAdmin.tblCriteriaRow = Nothing
                                Dim HasCriteriaDeputy As Boolean = False
                                Me.checkCriteria(CriteriaDeputy.value.Trim().Trim(), IDApplication, HasCriteriaDeputy, rCriteriaBackDeputy, dsAdminDeputy)
                                If rCriteriaBackDeputy Is Nothing Then
                                    Throw New Exception("rCriteriaBackDeputy is nothing not allowed for IDStay '" + rStay.ID.ToString() + "'!")
                                End If
                                Dim IDObjectInDBDeputy As Integer = Me.getIDObjectFromComboStay(rCriteriaBackDeputy.FldShort.Trim(), rCriteriaBackDeputy.SourceTable.Trim(), rStay)
                                If IDObjectInDBDeputy <> -1 Then
                                    If IDUser.Equals(IDObjectInDBDeputy) Then
                                        For Each rObjDebuty As dsObjects.tblObjectRelRow In dsObjectsWork.tblObjectRel
                                            Dim rUsrCboBox As dsObjects.tblObjectRow = sqlObjectsWork.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", rObjDebuty.IDGuidObject)
                                            If Not rUsrCboBox Is Nothing Then
                                                If IDObjectInDBForCriteria <> -1 And rUsrCboBox.ID.Equals(IDObjectInDBForCriteria) Then
                                                    bUserFound = True
                                                    Return True
                                                End If
                                            End If
                                        Next
                                    End If
                                End If
                            Next
                        End If
                    End If
                Next

                If bUserFound Then
                    Return True
                End If
                If Not checkVersion2 Then
                    If Not bAnyUserFoundAllRoles Then
                        Return True
                    End If
                Else
                    If Not bAnyUserFoundAllRoles Then
                        Return True
                    End If
                End If

                'Dim bAnyUserFoundAllRoles As Boolean = False
                'For Each cSelListAndObj As cSelListAndObj In lstRolesForUserActive
                '    If cSelListAndObj.RoleFoundInDefinition Then
                '        If cSelListAndObj.anyUserFoundForRole Then
                '            bAnyUserFoundAllRoles = True
                '        End If
                '    End If
                'Next
                If Not bAnyUserFoundAllRoles Then
                    Return True
                End If

                Return bUserFound
            Else
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkIsAdminOrUserIsInStayAsObject: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkRoleUser(ByRef IDUser As Integer, ByRef IDApplication As String, ByRef checkVersion2 As Boolean,
                                           ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj),
                                           ByRef lstVarIDOwnIntClassification As System.Collections.Generic.List(Of qs2.core.Enums.cVariables),
                                           ByRef lstRolesToCheckFromConfig As System.Collections.Generic.List(Of String),
                                           ByRef FldShortColumn As String, ByRef Table As String, ByRef rStay As qs2.core.vb.dsObjects.tblStayRow,
                                           ByRef bAnyUserFoundAllRoles As Boolean, ByRef bUserFound As Boolean, ByRef IDObjectInDBBack As Integer,
                                           ByRef IsDeputy As Boolean) As Boolean
        Try
            If checkVersion2 Then
                If Not IsDeputy Then
                    Return False
                End If
            End If
            For Each cRoleUser As cSelListAndObj In lstRolesForUserActive
                For Each VarIDOwnIntClassification As qs2.core.Enums.cVariables In lstVarIDOwnIntClassification
                    Dim bRoleCheck As Boolean = False
                    If checkVersion2 Then
                        For Each cRoleToCheckFromConfig As String In lstRolesToCheckFromConfig
                            If System.Convert.ToInt32(VarIDOwnIntClassification.value.Trim()).Equals(System.Convert.ToInt32(cRoleToCheckFromConfig.Trim())) Then
                                bRoleCheck = True
                            End If
                        Next
                    Else
                        bRoleCheck = True
                    End If

                    If bRoleCheck And cRoleUser.rSelList.IDOwnInt.Equals(System.Convert.ToInt32(VarIDOwnIntClassification.value)) Then
                        IDObjectInDBBack = Me.getIDObjectFromComboStay(FldShortColumn.Trim(), Table.Trim(), rStay)
                        'If IDObjectInDB <> -1 And IDUser.Equals(IDObjectInDB) Then
                        If IDObjectInDBBack <> -1 Then
                            Dim bCheck As Boolean = False
                            If checkVersion2 Then
                                If IDObjectInDBBack.Equals(IDUser) Then
                                    bCheck = True
                                Else
                                    'Version Graz
                                    'Wenn angemeldeter User Rolle Admin hat, dann darf er den Stay öffnen, wenn der Operateur die selbe zweite Rolle hat
                                    bAnyUserFoundAllRoles = True
                                    Dim lstRolesForUserInComboBox2 As New System.Collections.Generic.List(Of cSelListAndObj)
                                    Me.getAllRolesForUser(IDObjectInDBBack, lstRolesForUserInComboBox2, False)
                                    For Each cRoleUserInVombo As cSelListAndObj In lstRolesForUserInComboBox2
                                        If cRoleUser.rSelList.IDOwnInt.Equals(cRoleUserInVombo.rSelList.IDOwnInt) Then
                                            cRoleUser.anyUserFoundForRole = True
                                            For Each cRoleUserLoggedIn As cSelListAndObj In lstRolesForUserActive
                                                If cRoleUserLoggedIn.rSelList.IDOwnInt.Equals(11) Then
                                                    bUserFound = True
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            Else
                                bCheck = True
                            End If
                            If bCheck Then
                                bAnyUserFoundAllRoles = True
                                Dim lstRolesForUserInComboBox As New System.Collections.Generic.List(Of cSelListAndObj)
                                Me.getAllRolesForUser(IDObjectInDBBack, lstRolesForUserInComboBox, False)
                                For Each cRoleUserInVombo As cSelListAndObj In lstRolesForUserInComboBox
                                    If cRoleUser.rSelList.IDOwnInt.Equals(cRoleUserInVombo.rSelList.IDOwnInt) Then
                                        cRoleUser.anyUserFoundForRole = True
                                        bUserFound = True
                                    End If
                                Next
                            End If
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRoleUser: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getIDObjectFromComboStay(ByRef FldShortColumn As String, ByRef Table As String, ByRef rStay As qs2.core.vb.dsObjects.tblStayRow) As Integer
        Try
            Dim dt As New DataTable()
            Dim da As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmd As New System.Data.SqlClient.SqlCommand() With {
                .CommandText = " Select " + FldShortColumn.Trim() + " from qs2." + Table.Trim() + " where " +
                                                        " ID=" + rStay.ID.ToString() + " and IDApplication='" + rStay.IDApplication.Trim() + "' and IDParticipant='" + rStay.IDParticipant.Trim() + "' ",
                .Connection = qs2.core.dbBase.dbConn
            }
            da.SelectCommand = cmd
            da.Fill(dt)

            Dim IDObjectInDB As Integer = dt.Rows(0)(0)
            Return IDObjectInDB

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getIDObjectFromComboStay: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Sub getAllRolesForUser2(ByRef IDUser As Integer, ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj),
                                   onlyActiveRoles As Boolean)
        Try
            Dim arrRolesUser() As dsAdmin.getAllUsersWithRolesRow = sqlAdmin.dsAllAdmin.getAllUsersWithRoles.Select("ID=" + IDUser.ToString())
            'If actUsr.lstRolesUser.Count > 0 Then
            If arrRolesUser.Count > 0 Then
                For Each rRoleUser As dsAdmin.getAllUsersWithRolesRow In arrRolesUser
                    Dim NewSelListAndObj As New cSelListAndObj()
                    'NewSelListAndObj.rRoleObj = rRoleUser
                    lstRolesForUserActive.Add(NewSelListAndObj)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getAllRolesForUser:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub getAllRolesForUser(IDUser As Integer, ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj),
                                   onlyActiveRoles As Boolean)
        Try
            Dim sWhereRolesUserObj As String = ""
            Dim arrvSelListAllRoles As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Roles.ToString(), license.doLicense.eApp.ALL.ToString(), "")
            Dim sWhereRoles As String = ""
            Me.getWhere(arrvSelListAllRoles, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                                      sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereRoles, sqlTxt.or)
            Dim arrSelListObjRolesUser As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, IDUser, sWhereRoles, "", "", "")

            Me.getWhere(arrSelListObjRolesUser, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
                          sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName, True, sWhereRolesUserObj, sqlTxt.or)
            If Not arrSelListObjRolesUser Is Nothing Then
                If arrSelListObjRolesUser.Length > 0 Then
                    For Each rSelListObjRolesUser As dsAdmin.tblSelListEntriesObjRow In arrSelListObjRolesUser
                        Dim arrSelListRole() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDColumn.ColumnName + "=" + rSelListObjRolesUser.IDSelListEntry.ToString() + "", "")
                        Dim rSelListRole As dsAdmin.tblSelListEntriesRow = arrSelListRole(0)
                        If (Not onlyActiveRoles) Or (onlyActiveRoles And rSelListObjRolesUser.Active) Then
                            Dim NewSelListAndObj As New cSelListAndObj() With {
                                .rSelList = rSelListRole,
                                .rSelListObj = rSelListObjRolesUser
                            }
                            lstRolesForUserActive.Add(NewSelListAndObj)
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getAllRolesForUser:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    'Public Sub getAllProductsForUser(IDUser As Integer, ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj),
    '                               onlyActiveRoles As Boolean)
    '    Try
    '        Dim sWhereRolesUserObj As String = ""
    '        Dim arrvSelListAllRoles As dsAdmin.vListEntriesWithGroupRow() = Me.getSelListRows(db.ERSystem.businessFramework.eTypIDGroup.Roles.ToString(), license.doLicense.eApp.ALL.ToString(), "")
    '        Dim sWhereRoles As String = ""
    '        Me.getWhere(arrvSelListAllRoles, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
    '                                  sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDColumn.ColumnName, True, sWhereRoles, sqlTxt.or)
    '        Dim arrSelListObjRolesUser As dsAdmin.tblSelListEntriesObjRow() = Me.getSelListObjRows(-999, -999, IDUser, sWhereRoles, "", "", "")

    '        Me.getWhere(arrSelListObjRolesUser, sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName,
    '                      sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName, True, sWhereRolesUserObj, sqlTxt.or)
    '        If Not arrSelListObjRolesUser Is Nothing Then
    '            If arrSelListObjRolesUser.Length > 0 Then
    '                For Each rSelListObjRolesUser As dsAdmin.tblSelListEntriesObjRow In arrSelListObjRolesUser
    '                    Dim arrSelListRole() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDColumn.ColumnName + "=" + rSelListObjRolesUser.IDSelListEntry.ToString() + "", "")
    '                    Dim rSelListRole As dsAdmin.tblSelListEntriesRow = arrSelListRole(0)
    '                    If (Not onlyActiveRoles) Or (onlyActiveRoles And rSelListObjRolesUser.Active) Then
    '                        Dim NewSelListAndObj As New cSelListAndObj() With {
    '                            .rSelList = rSelListRole,
    '                            .rSelListObj = rSelListObjRolesUser
    '                        }
    '                        lstRolesForUserActive.Add(NewSelListAndObj)
    '                    End If
    '                Next
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("buisLogAdmin.getAllRolesForUser:" + vbNewLine + vbNewLine + ex.ToString())
    '    End Try
    'End Sub


    Public Sub getAllObjectFieldsInProductStay(ByRef arrSelListObjFieldInDB() As dsAdmin.tblSelListEntriesRow, Sheriff As Boolean, Application As String)
        Try
            Dim IDGroupStr As String = ""
            If Sheriff Then
                IDGroupStr = "ObjectFieldsSheriff"
            Else
                IDGroupStr = "ObjectFields"
            End If
            Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='" + IDGroupStr.Trim() + "'", "")
            Dim sWhere As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntryGroup(0).ID.ToString() + ""
            If Application.Trim() <> "" Then
                sWhere += " and (" + qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDOwnStrColumn.ColumnName + "='" + Application.Trim() + "' or " +
                            qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDOwnStrColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString() + "') "
            End If
            arrSelListObjFieldInDB = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhere, qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.FldShortColumnColumn.ColumnName + " asc")

            If arrSelListObjFieldInDB.Length = 0 Then
                If Not Sheriff Then
                    Throw New Exception("buisLogAdmin.getAllObjectFieldsInProductStay: arrSelListObjFieldInDB.Length = 0 not allowed for IDGroupStr 'ObjectFields'!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getAllObjectFieldsInProductStay:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Function addNewResAuto(ByRef IDRes As String,
                                      ByRef ResourceTypeToLoad As core.Enums.eResourceType,
                                      ByRef TxtEnglish As String, ByRef TxtGerman As String, ByRef TypeSub As String,
                                      ByRef rRes As qs2.core.language.dsLanguage.RessourcenRow) As Boolean
        Try
            Dim dsLanguageUpdate As New language.dsLanguage()
            Dim sqlLanguageUpdate As New qs2.core.language.sqlLanguage()
            sqlLanguageUpdate.initControl()

            sqlLanguageUpdate.getLanguage(System.Guid.NewGuid().ToString(), dsLanguageUpdate,
                                               core.language.sqlLanguage.eTypSelLang.IDRes,
                                               core.Enums.eResourceType.Label, qs2.core.license.doLicense.rApplication.IDApplication.Trim())

            rRes = sqlLanguageUpdate.newRowLanguage(dsLanguageUpdate,
                                                           "", IDRes,
                                                           "", qs2.core.license.doLicense.rApplication.IDApplication.Trim(), qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(),
                                                           ResourceTypeToLoad,
                                                           core.Enums.eTypeSub.User, "")

            rRes.English = TxtEnglish.Trim()
            rRes.German = TxtGerman.Trim()
            rRes.User = ""
            rRes.IDLanguageUser = qs2.core.license.doLicense.eApp.ALL.ToString()
            rRes.Description = ""
            rRes.CreatedUser = "Auto-Res-Managment"
            rRes.TypeSub = TypeSub.Trim()
            rRes.Classification = "ControlType=Grid;"
            Try
                sqlLanguageUpdate.daLanguage.Update(dsLanguageUpdate.Ressourcen)
                Dim rNewResToAdd As qs2.core.language.dsLanguage.RessourcenRow = qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen.NewRow()
                rNewResToAdd.ItemArray = rRes.ItemArray
                qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen.Rows.Add(rNewResToAdd)
            Catch ex As Exception
                Dim sExcept As String = ex.ToString()
                Throw New Exception(sExcept)
                'qs2.core.language.sqlLanguage.getRes(IDRes, IDRes, TxtGerman, ControlGroup, ResourceTypeToLoad, rRes)
                'If rRes Is Nothing Then
                '    Dim rNewProt As dsControls.ProtocollRow = ControlManagment.addProtocoll(ControlManagment.dsControls)
                '    rNewProt.IDRes = IDRes
                '    rNewProt.Txt = "IDRes '" + IDRes.Trim() + "' could not added to QS2-Database! (Table=Ressources, Application='" + ENV._Application.ToString() + "', TypeRes='" + ResourceTypeToLoad.ToString() + "'" + vbNewLine +
                '                    "TxtGerman='" + TxtGerman + "')"

                '    rNewProt.Cont = cont
                '    rNewProt.ControlType = cont.GetType().ToString()
                '    'Throw New Exception("doRessources.AddResAuto: IDRes '" + IDRes + "' cannot automatically inserted because IDRes exists! (eResourceTypeToInsert='" + ResourceTypeToInsert.ToString() + "')")
                'Else
                '    Dim str As String = ""
                'End If
            End Try

            Return True

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.doResAuto: " + ex.ToString())
        End Try
    End Function

    Public Sub checkRolesForUserTable(ByRef dsObjects1 As dsObjects)
        Try
            Dim lstToDelete As New System.Collections.Generic.List(Of dsObjects.tblObjectRow)
            For Each rUser As dsObjects.tblObjectRow In dsObjects1.tblObject
                If rUser.ID = 67852 Then
                    Dim xy As String = ""
                End If
                Dim arrUserWithRoles() As dsAdmin.getAllUsersWithRolesRow = sqlAdmin.dsAllAdmin.getAllUsersWithRoles.Select("ID=" + rUser.ID.ToString() + "")
                If arrUserWithRoles.Length = 0 And (Not rUser.UserName.Trim().ToLower().Equals(("Supervisor").Trim().ToLower())) And
                         (Not rUser.UserName.Trim().ToLower().Equals(("Admin").Trim().ToLower())) And
                         (Not rUser.UserName.Trim().ToLower().Equals(("Superadmin").Trim().ToLower())) Then
                    lstToDelete.Add(rUser)
                End If
            Next
            For Each rUser As dsObjects.tblObjectRow In lstToDelete
                rUser.Delete()
            Next
            dsObjects1.tblObject.AcceptChanges()

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRolesForUserTable:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub
    Public Sub checkRolesForUserTable_old(ByRef dsObjects1 As dsObjects)
        Try
            Dim lstRolesForUserActive As New List(Of qs2.core.vb.businessFramework.cSelListAndObj)()
            Dim lstToDelete As New System.Collections.Generic.List(Of dsObjects.tblObjectRow)
            For Each rUser As dsObjects.tblObjectRow In dsObjects1.tblObject
                lstRolesForUserActive.Clear()
                Me.getAllRolesForUser(rUser.ID, lstRolesForUserActive, True)
                If lstRolesForUserActive.Count = 0 And (Not rUser.UserName.Trim().ToLower().Equals(("Supervisor").Trim().ToLower())) And
                    (Not rUser.UserName.Trim().ToLower().Equals(("Admin").Trim().ToLower())) Then
                    lstToDelete.Add(rUser)
                Else
                    Dim str As String = ""
                End If
            Next
            For Each rUser As dsObjects.tblObjectRow In lstToDelete
                rUser.Delete()
            Next
            dsObjects1.tblObject.AcceptChanges()

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.checkRolesForUserTable:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub

    Public Sub changeObjectFieldsInStays(ByRef IDObjectOld As Integer, ByRef IDObjectNew As Integer)
        Try
            Me.Inititialize("", "", False)

            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()
            Dim bUserFound As Boolean = False
            Dim arrSelListObjFieldInDB() As dsAdmin.tblSelListEntriesRow = Nothing
            Me.getAllObjectFieldsInProductStay(arrSelListObjFieldInDB, False, "")
            Dim bAnyUserFoundAllRoles As Boolean = False
            For Each rSelListObjFieldInDB As dsAdmin.tblSelListEntriesRow In arrSelListObjFieldInDB
                Try
                    Dim cmd As New System.Data.SqlClient.SqlCommand() With {
                        .CommandTimeout = 0,
                        .Connection = qs2.core.dbBase.dbConn,
                        .CommandText = "Update " + qs2.core.dbBase.dbSchema + rSelListObjFieldInDB._Table.Trim() + " set " + rSelListObjFieldInDB.FldShortColumn.Trim() + "=" + IDObjectNew.ToString() +
                                            " where " + rSelListObjFieldInDB.FldShortColumn.Trim() + "=" + IDObjectOld.ToString() + ""
                    }
                    cmd.ExecuteNonQuery()

                Catch ex2 As Exception
                    Throw New Exception("changeObjectFieldsInStays: " + ex2.ToString())
                End Try
            Next

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.changeObjectFieldsInStays: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub


    Public Function getVariablesClassification(sClassification As String) As System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
        Try
            Dim lstClassificationsReturn As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
            Dim lstVarClassification As New System.Collections.Generic.List(Of String)
            lstVarClassification = qs2.core.generic.readStrVariables(sClassification.Trim())
            For Each defVarClassification As String In lstVarClassification
                Dim cVariableNew As New qs2.core.Enums.cVariables()
                qs2.core.vb.funct.getVariablesLefRightOfPoint(defVarClassification, cVariableNew.definition, cVariableNew.value, "=")
                lstClassificationsReturn.Add(cVariableNew)
            Next
            Return lstClassificationsReturn

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getVariablesClassification:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getVariablesLicenseKeys(sLicenseKeys As String) As System.Collections.Generic.List(Of String)
        Try
            Dim lstLicenseKeysReturn As New System.Collections.Generic.List(Of String)
            If sLicenseKeys.Trim() <> "" Then
                Dim lstVarLicenseKeys As New System.Collections.Generic.List(Of String)
                lstVarLicenseKeys = qs2.core.generic.readStrVariables(sLicenseKeys.Trim())
                For Each defVarLicenseKey As String In lstVarLicenseKeys
                    lstLicenseKeysReturn.Add(defVarLicenseKey)
                Next
            End If
            Return lstLicenseKeysReturn

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getVariablesLicenseKeys:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getValueVariableClassification(VariableToSearch As qs2.core.Enums.cVariablesDefinition, ByRef lstVariablesClassification As System.Collections.Generic.List(Of qs2.core.Enums.cVariables)) As System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
        Try
            Dim lstClassificationsReturn As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
            For Each VariableFromLst As qs2.core.Enums.cVariables In lstVariablesClassification
                If VariableFromLst.definition.Trim().ToLower().Equals(VariableToSearch.ToString().Trim().ToLower()) Then
                    lstClassificationsReturn.Add(VariableFromLst)
                End If
            Next
            Return lstClassificationsReturn

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getValueVariableClassification:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getValueVariableClassificationStr(VariableToSearch As String, ByRef lstVariablesClassification As System.Collections.Generic.List(Of qs2.core.Enums.cVariables)) As System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
        Try
            Dim lstClassificationsReturn As New System.Collections.Generic.List(Of qs2.core.Enums.cVariables)
            For Each VariableFromLst As qs2.core.Enums.cVariables In lstVariablesClassification
                If VariableFromLst.definition.Trim().ToLower().Equals(VariableToSearch.ToString().Trim().ToLower()) Then
                    lstClassificationsReturn.Add(VariableFromLst)
                End If
            Next
            Return lstClassificationsReturn

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getValueVariableClassification:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getSelListRows(ByRef IDGroupStr As String, ByRef IDApplication As String, ByRef IDParticipant As String) As dsAdmin.vListEntriesWithGroupRow()
        Try
            Dim arrvListEntriesWithGroupRow As dsAdmin.vListEntriesWithGroupRow() = Nothing
            Dim sWhere As String = ""
            sWhere = sqlAdmin.dsAllAdmin.vListEntriesWithGroup.g_IDGroupStrColumn.ColumnName + "='" + IDGroupStr.ToString() + "'"
            If IDApplication.Trim() = "" Then
                Throw New Exception("buisLogAdmin.getSelListRows: IDApplication='' now allowed!")
            End If
            sWhere += " and " + sqlAdmin.dsAllAdmin.vListEntriesWithGroup.g_IDApplicationColumn.ColumnName + "='" + IDApplication.ToString() + "'"
            If IDParticipant.Trim() <> "" Then
                sWhere += " and " + sqlAdmin.dsAllAdmin.vListEntriesWithGroup.g_IDParticipantColumn.ColumnName + "='" + IDParticipant.ToString() + "'"
            End If

            arrvListEntriesWithGroupRow = sqlAdmin.dsAllAdmin.vListEntriesWithGroup.Select(sWhere,
                                                             sqlAdmin.dsAllAdmin.vListEntriesWithGroup.s_IDOwnStrColumn.ColumnName + " asc")

            Return arrvListEntriesWithGroupRow

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getSelListRows:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getSelListObjRows(ByRef IDSelListEntry As Integer, ByRef IDSelListEntrySublist As Integer, ByRef IDObject As Integer,
                                      ByRef sWhereIDSelList1 As String, ByRef sWhereIDSelList2 As String, ByRef IDApplication As String,
                                      ByRef typIDGroup As String) As dsAdmin.tblSelListEntriesObjRow()
        Try
            Dim arrSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow() = Nothing
            If IDSelListEntry <> -999 And IDSelListEntrySublist = -999 And
                sWhereIDSelList1.Trim() = "" And sWhereIDSelList2.Trim() = "" Then

                Dim sWhereTmp As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName + "=" + IDSelListEntry.ToString() + " " +
                                                                                        Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp, "")
                Return arrSelListEntriesObj

            ElseIf IDSelListEntry <> -999 And IDSelListEntrySublist <> -999 And sWhereIDSelList1.Trim() = "" Then

                Dim sWhereTmp As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName + "=" + IDSelListEntry.ToString() + " and " +
                                                                                       sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName + "=" + IDSelListEntrySublist.ToString() + " " +
                                                                                        Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp)
                Return arrSelListEntriesObj

            ElseIf IDSelListEntry <> -999 And IDSelListEntrySublist <> -999 And sWhereIDSelList1.Trim() = "" And sWhereIDSelList2.Trim() = "" Then

                Dim sWhereTmp As String = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntryColumn.ColumnName + "=" + IDSelListEntry.ToString() + " and " +
                                            sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDSelListEntrySublistColumn.ColumnName + "=" + IDSelListEntrySublist.ToString() + " " +
                                             Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp, "")
                Return arrSelListEntriesObj

            ElseIf IDSelListEntry = -999 And IDSelListEntrySublist = -999 And sWhereIDSelList1.Trim() <> "" And sWhereIDSelList2.Trim() = "" Then

                Dim sWhereTmp = sWhereIDSelList1 + " " + Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp, "")
                Return arrSelListEntriesObj

            ElseIf IDSelListEntry = -999 And IDSelListEntrySublist = -999 And sWhereIDSelList1.Trim() <> "" And sWhereIDSelList2.Trim() <> "" Then

                Dim sWhereTmp = sWhereIDSelList1 + " and " + sWhereIDSelList2 + " " +
                                Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp, "")
                Return arrSelListEntriesObj

            ElseIf IDSelListEntry = -999 And IDSelListEntrySublist = -999 And sWhereIDSelList1.Trim() = "" And sWhereIDSelList2.Trim() <> "" Then

                Dim sWhereTmp = sWhereIDSelList2 + " " +
                                Me.getWhereApplication(IDApplication) + " " + Me.getWhereTypIDGroup(typIDGroup) + " " + Me.getWhereIDObject(IDObject)
                arrSelListEntriesObj = sqlAdmin.dsAllAdmin.tblSelListEntriesObj.Select(sWhereTmp, "")
                Return arrSelListEntriesObj

            Else
                Throw New Exception("buisLogAdmin.getSelListObjRows: else not allowed!")
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getSelListObjRows:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getWhereApplication(ByRef Application As String) As String
        Dim sWhere As String = ""
        If Application.Trim() <> "" Then
            sWhere = " and (" + sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "='" + Application.Trim() + "' or " +
                        " " + sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDApplicationColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString() + "') "
        End If
        Return sWhere
    End Function
    Public Function getWhereTypIDGroup(ByRef typIDGroup As String) As String
        Dim sWhere As String = ""
        If typIDGroup.Trim() <> "" Then
            sWhere = " and " + sqlAdmin.dsAllAdmin.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "='" + typIDGroup.Trim() + "'"
        End If
        Return sWhere
    End Function
    Public Function getWhereIDObject(ByRef IDObject As Integer) As String
        Dim sWhere As String = ""
        If IDObject >= -99 Then
            sWhere = " and " + sqlAdmin.dsAllAdmin.tblSelListEntriesObj.IDObjectColumn.ColumnName + "=" + IDObject.ToString() + " "
        End If
        Return sWhere
    End Function
    Public Sub getWhere(ByRef arrRows() As System.Data.DataRow, ByRef NameColumnWhere As String, ByRef NameColumnValue As String,
                         ByRef doClamps As Boolean, ByRef sWhere As String, ByRef Operand As String)
        Try
            For Each r As DataRow In arrRows
                sWhere += "" + IIf(sWhere.Trim() = "", "", " " + Operand.Trim() + " ") + NameColumnWhere + "=" + r(NameColumnValue).ToString() + " "
            Next
            If sWhere.Trim() <> "" And doClamps Then
                sWhere = " (" + sWhere + ") "
            End If

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.getWhere:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Sub


    Public Function CopyStay(rStayToCopy As qs2.core.vb.dsObjects.tblStayRow, IDPatientNew As Guid) As Boolean
        Try
            Dim dNow As DateTime = Now
            Dim dsUpdate As New dsObjects()
            Dim sqlObjectsUpdate As New sqlObjects()
            sqlObjectsUpdate.initControl()

            Dim SqlObjectsOrig As New sqlObjects()
            SqlObjectsOrig.initControl()
            Dim rObjOrig As qs2.core.vb.dsObjects.tblObjectRow = SqlObjectsOrig.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", IDPatientNew)

            Dim SqlObjectsNew As New sqlObjects()
            SqlObjectsNew.initControl()
            Dim rObjNew As qs2.core.vb.dsObjects.tblObjectRow = SqlObjectsNew.getObjectRow(-999, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", rStayToCopy.PatIDGuid)
            If (Not rObjOrig.IsDOBNull() AndAlso (Not rObjNew.IsDOBNull()) AndAlso (Not rObjOrig.DOB.Date.Equals(rObjNew.DOB.Date))) Then
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DOBOfBothPatientsDoesNotMatch") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

            sqlObjectsUpdate.getStay(-999, "", Nothing, Nothing, dsUpdate, sqlObjects.eTypSelStay.IDGuidStay, "", Enums.eStayTyp.Stay, "",
                                     rStayToCopy.IDGuid, "", Enums.eSearchType.AKH, False, -999, Nothing, -999, False, "", "", -1, -1, -1, "")
            If dsUpdate.tblStay.Rows.Count <> 1 Then
                Throw New Exception("CopyStay: dsUpdate.tblStay.Rows.Count<>1 for IDStay '" + rStayToCopy.ID.ToString() + "'!")
            End If
            'Dim rNewStay As qs2.core.vb.dsObjects.tblStayRow = sqlObjectsUpdate.getNewRowStay(dsUpdate)
            Dim rNewStay As qs2.core.vb.dsObjects.tblStayRow = dsUpdate.tblStay.Rows(0)
            rNewStay.ItemArray = rStayToCopy.ItemArray
            rNewStay.PatIDGuid = IDPatientNew

            'rNewStay.PatExtID = rObj.ExtID
            'rNewStay.SetFUPDtNull()
            'rNewStay.SetFUPDtPlanNull()
            'rNewStay.PatOrigin = rObj.PatOrigin
            'If (Not rNewStay.IsAdmitDtNull() And Not rObj.IsDOBNull) Then
            '    rNewStay.PatAge = businessFramework.CalcAgeInYears(rObj.DOB, rNewStay.AdmitDt.Date)
            'End If

            'Dim rMainAdress As qs2.core.vb.dsObjects.tblAdressRow = SqlObjects1.getAdressMain(rNewStay.PatIDGuid)
            'rNewStay.PatStreet = rMainAdress.Street.Trim()
            'If rMainAdress.PhoneMobil.Trim() <> "" Then
            '    rNewStay.PatTel = rMainAdress.PhoneMobil.Trim()
            'ElseIf rMainAdress.PhonePrivat.Trim() <> "" Then
            '    rNewStay.PatTel = rMainAdress.PhonePrivat.Trim()
            'Else
            '    rNewStay.PatTel = rMainAdress.PhoneBusiness.Trim()
            'End If
            'rNewStay.PatZIP = rMainAdress.ZIP.Trim()
            'rNewStay.PatCity = rMainAdress.City.Trim()
            'rNewStay.PatCountryID = rMainAdress.CountryID

            'rNewStay.StayComplete = False
            'rNewStay.IsActive = True
            sqlObjectsUpdate.daStay.Update(dsUpdate.tblStay)

            Return True

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.CopyStay:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Shared Function CalcAgeInYears(birthday As DateTime, checkdate As DateTime) As Int32
        Try
            Dim years As Int32 = checkdate.Year - birthday.Year
            birthday = birthday.AddYears(years)
            If (checkdate.CompareTo(birthday) < 0) Then years = years - 1
            Return years

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.CalcAge: error calculating age = " + ex.ToString())
        End Try
    End Function

    Public Function WaitStayIsAddedFromHL7Service(MedRecNrAutoOpen As String, ParticipantAutoOpen As String, IDApplication As String, ByRef abortWaiting As Boolean) As Boolean
        Try
            Dim b As New core.db.ERSystem.businessFramework()
            Dim dsSysDB1 As New core.SysDB.dsSysDB()
            Dim sqlSysDB1 As New core.SysDB.sqlSysDB()
            sqlSysDB1.initControl()

            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                sqlSysDB1.getTables(dsSysDB1, core.SysDB.sqlSysDB.eTypSelColumns.likeTableName, IDApplication.Trim())
                Dim AllTablesOK As Boolean = False
                Dim dStart As Date = Now
                While Not AllTablesOK
                    Dim bTableStayIsAdded As Boolean = False
                    Dim iCounterTableExistsInDB As Integer = 0
                    Dim iStaysFound As Integer = 0

                    Dim rStay As qs2.db.Entities.tblStay = b.getStay(MedRecNrAutoOpen.Trim(), IDApplication.Trim(),
                                                                ParticipantAutoOpen.Trim(), 1, db, iStaysFound)
                    If iStaysFound = 0 Then
                        Dim bTableNotOK As Boolean = True
                    ElseIf iStaysFound = 1 Then
                        bTableStayIsAdded = True

                        'Dim bTableStayIsAdded As Boolean = False
                        Dim dsStays As New DataSet()
                        Dim parameters As New System.Collections.Generic.List(Of System.Data.SqlClient.SqlParameter)
                        Dim ParametersAsTxt As String = ""
                        'qs2.core.dbBase.fillDataSet("Select * from " + qs2.core.dbBase.dbSchema + "tblStay where ID=" + rStayAdded.ID.ToString() + " And " +
                        '                                        " IDApplication='" + rStayAdded.IDApplication.Trim() + "' and IDParticipant='" + rStayAdded.IDParticipant.Trim() + "'",
                        '                                        parameters, dsStays, "tblStay", "dsProductStays", ParametersAsTxt, False)
                        'If dsStays.Tables(0).Rows.Count = 0 Then
                        '    Dim bTableNotOK As Boolean = True
                        'ElseIf dsStays.Tables(0).Rows.Count = 1 Then
                        '    bTableStayIsAdded = True
                        'ElseIf dsStays.Tables(0).Rows.Count > 1 Then
                        '    Throw New Exception("cSendStay.SendStay: dsStays.Tables(0).Rows.Count>1 for IDStayGuid'" + rStayAdded.IDGuid.ToString() + "'!")
                        'End If

                        For Each rTableToSend As qs2.core.SysDB.dsSysDB.TablesCatalogRow In dsSysDB1.TablesCatalog
                            dsStays.Clear()
                            qs2.core.dbBase.fillDataSet("Select * from " + qs2.core.dbBase.dbSchema + rTableToSend.TABLE_NAME.Trim() + " where ID=" + rStay.ID.ToString() + " and " +
                                                                    " IDApplication='" + rStay.IDApplication.Trim() + "' and IDParticipant='" + rStay.IDParticipant.Trim() + "'",
                                                                    parameters, dsStays, rTableToSend.TABLE_NAME.Trim(), "dsProductStays", ParametersAsTxt, False)

                            If dsStays.Tables(0).Rows.Count = 0 Then
                                Dim bTableNotOK As Boolean = True
                            ElseIf dsStays.Tables(0).Rows.Count = 1 Then
                                Dim rProductStay As DataRow = dsStays.Tables(0).Rows(0)
                                iCounterTableExistsInDB += 1

                            ElseIf dsStays.Tables(0).Rows.Count > 1 Then
                                Throw New Exception("cSendStay.SendStay: dsStays.Tables(0).Rows.Count>1 for IDStayGuid'" + rStay.IDGuid.ToString() + "'!")
                            End If
                        Next

                    ElseIf iStaysFound > 1 Then
                        Throw New Exception("cSendStay.SendStay: iStaysFound>1 for MedRecN'" + MedRecNrAutoOpen.Trim() + "' and Participant '" + ParticipantAutoOpen.Trim() + "'!")
                    End If

                    If bTableStayIsAdded And iCounterTableExistsInDB = (dsSysDB1.TablesCatalog.Rows.Count) Then
                        AllTablesOK = True
                        Exit While
                    End If

                    If (Now - dStart).TotalSeconds > 30 Then
                        abortWaiting = True
                        Exit While
                    End If

                    generic.Wait(2)
                    System.Windows.Forms.Application.DoEvents()
                End While
            End With

        Catch ex As Exception
            Throw New Exception("businessFramework.WaitStayIsAddedFromHL7Service:" + ex.ToString())
        End Try
    End Function
    Public Function CopyStayTable(ByRef rStayParent As dsObjects.tblStayRow, ByRef rStayChild As dsObjects.tblStayRow,
                                  ByRef arrSelListFieldsStayCopy() As dsAdmin.tblSelListEntriesRow,
                                  ByRef TableToCopy As String, Optional IDParticipant As String = "", Optional tColumns As qs2.core.SysDB.dsSysDB.COLUMNSDataTable = Nothing) As Boolean
        Try

            Dim lstFieldsForTable As New System.Collections.Generic.List(Of String)
            If tColumns Is Nothing Then
                For Each rSelListFound As dsAdmin.tblSelListEntriesRow In arrSelListFieldsStayCopy
                    If rSelListFound._Table.Trim().ToLower().Equals(TableToCopy.Trim().ToLower()) Then
                        lstFieldsForTable.Add(rSelListFound.FldShortColumn.Trim())
                    End If
                Next
            Else
                For Each rSelListFound In tColumns
                    lstFieldsForTable.Add(rSelListFound.COLUMN_NAME.Trim())
                Next
            End If

            Dim daParent As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmdParent As New System.Data.SqlClient.SqlCommand()
            Dim dtParent As New DataTable()
            cmdParent.CommandTimeout = 0
            cmdParent.Connection = qs2.core.dbBase.dbConn

            Dim daChild As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmdChild As New System.Data.SqlClient.SqlCommand()
            Dim dtChild As New DataTable()
            Dim cbChild As New System.Data.SqlClient.SqlCommandBuilder(daChild)
            cmdChild.CommandTimeout = 0
            cmdChild.Connection = qs2.core.dbBase.dbConn

            Dim sWhereTmp As String = " where IDParticipant='" + rStayParent.IDParticipant.Trim() + "' and IDApplication='" + rStayParent.IDApplication.Trim() + "' "
            Dim sWhereTmp2 As String = ""
            If IDParticipant.Trim() <> "" Then
                sWhereTmp2 = " where IDParticipant='" + IDParticipant.Trim() + "' and IDApplication='" + rStayParent.IDApplication.Trim() + "' "
            Else
                sWhereTmp2 = sWhereTmp
            End If

            Dim sWhereParent As String = sWhereTmp + " and ID=" + rStayParent.ID.ToString() + " "
            Dim sWhereChild As String = sWhereTmp2 + " and ID=" + rStayChild.ID.ToString() + " "

            cmdParent.CommandText = " Select * from qs2." + TableToCopy.Trim() + " " + sWhereParent
            daParent.SelectCommand = cmdParent
            daParent.Fill(dtParent)
            If dtParent.Rows.Count <> 1 Then
                Throw New Exception("businessFramework.CopyStayTable: CopyStayTable: dt.Rows.Count <> 1 for copy table '" + TableToCopy + "' for StayID '" +
                                        rStayParent.ID.ToString() + "' and IDApplication '" + rStayParent.IDApplication.Trim() + "'")
            End If

            cmdChild.CommandText = " Select * from qs2." + TableToCopy.Trim() + " " + sWhereChild
            daChild.SelectCommand = cmdChild
            daChild.Fill(dtChild)
            If dtChild.Rows.Count <> 1 Then
                Throw New Exception("businessFramework.CopyStayTable: CopyStayTable: dt.Rows.Count <> 1 for copy table '" + TableToCopy + "' for StayID '" +
                                        rStayChild.ID.ToString() + "' and IDApplication '" + rStayParent.IDApplication.Trim() + "'")
            End If

            Dim iCounterFieldsUpdated As Integer = 0
            Dim rParent As DataRow = dtParent.Rows(0)
            Dim rChild As DataRow = dtChild.Rows(0)
            For Each colDefChild As DataColumn In dtChild.Columns
                If (Not colDefChild.ColumnName.Trim().ToLower().Equals(("ID").Trim().ToLower())) And
                    (Not colDefChild.ColumnName.Trim().ToLower().Equals(("IDApplication").Trim().ToLower())) And
                    (Not colDefChild.ColumnName.Trim().ToLower().Equals(("IDParticipant").Trim().ToLower())) Then

                    If (colDefChild.ColumnName.Trim().ToLower().Equals(("OpTAVI").Trim().ToLower())) Then
                        Dim bStop As Boolean = True
                    End If

                    Dim bCopyValue As Boolean = False
                    For Each fieldToCopyFromSelList As String In lstFieldsForTable
                        If colDefChild.ColumnName.Trim().ToLower().Equals(fieldToCopyFromSelList.Trim().ToLower()) Then
                            bCopyValue = True
                        End If
                    Next
                    If bCopyValue Then
                        Dim oChild As Object = rChild(colDefChild.ColumnName)
                        Dim oParent As Object = rParent(colDefChild.ColumnName)
                        If oChild Is System.DBNull.Value Then
                            Dim str As String = ""
                        End If
                        If oParent Is System.DBNull.Value Then
                            Dim str As String = ""
                        End If
                        If Not rChild(colDefChild.ColumnName).Equals(rParent(colDefChild.ColumnName)) Then
                            rChild(colDefChild.ColumnName) = rParent(colDefChild.ColumnName)
                            iCounterFieldsUpdated += 1
                        End If
                    End If
                End If
            Next

            cbChild.GetUpdateCommand()
            daChild.Update(dtChild)

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.CopyStayTable: " + vbNewLine + ex.ToString())
        End Try
    End Function


    Public Function changeSelListKAVToInt(CountryIDOwnStrKAV) As Integer
        Try
            Dim arrSelListEntryGroupKAV() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='CountryIDKAV'", "")
            Dim arrSelListEntriesKAV() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntryGroupKAV(0).ID.ToString() + "",
                                                                                                                               qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.IDOwnStrColumn.ColumnName + " asc")
            For Each rSelListFoundKAV As dsAdmin.tblSelListEntriesRow In arrSelListEntriesKAV
                If rSelListFoundKAV.IDOwnStr.Trim().ToLower().Equals(CountryIDOwnStrKAV.Trim().ToLower()) Then
                    Return rSelListFoundKAV.IDOwnInt
                End If
            Next

        Catch ex As Exception
            Throw New Exception("buisLogAdmin.changeSelListKAVToIntern:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Sub GetGuidsForObjectFields(ByRef ServiceInput As qs2.core.vb.QS2Service1.cServiceInput, ByRef dsToSend As DataSet,
                                        ByRef dsAdminObjectFields As dsAdmin)
        Try
            Dim dsObjectsTmp As New dsObjects()
            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()

            Dim iCounter As Integer = 0
            Dim lstFieldsToChange As New System.Collections.Generic.List(Of qs2.core.vb.QS2Service1.cSqlParameter)
            For Each dt As DataTable In dsToSend.Tables
                For Each col As DataColumn In dt.Columns
                    For Each rSelListObjField As dsAdmin.tblSelListEntriesRow In dsAdminObjectFields.tblSelListEntries
                        If col.ColumnName.Trim().ToLower().Equals(rSelListObjField.FldShortColumn.Trim().ToLower()) Then
                            For Each rData As DataRow In dt.Rows
                                Dim iIDObject As Integer = System.Convert.ToInt32(rData(rSelListObjField.FldShortColumn.Trim))
                                If iIDObject <> -1 Then
                                    Dim rObj As dsObjects.tblObjectRow = sqlObjectsTmp.getObjectRow(iIDObject, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
                                    If Not rObj Is Nothing Then
                                        Dim newPar As New qs2.core.vb.QS2Service1.cSqlParameter() With {
                                            .ParameterName = col.ColumnName.Trim()
                                        }
                                        newPar.SourceColumn = newPar.ParameterName
                                        newPar.sValue = iIDObject.ToString()
                                        newPar.IDObjectGuid = rObj.IDGuid.ToString()
                                        newPar.IsObjectFieldForChange = True
                                        lstFieldsToChange.Add(newPar)
                                    Else
                                        rData(rSelListObjField.FldShortColumn.Trim) = -1
                                    End If
                                    iCounter += 1
                                End If
                            Next
                        End If
                    Next
                Next
            Next

            Dim ParService(iCounter - 1) As qs2.core.vb.QS2Service1.cSqlParameter
            iCounter = 0
            For Each par As qs2.core.vb.QS2Service1.cSqlParameter In lstFieldsToChange
                ParService(iCounter) = par
                iCounter += 1
            Next
            ServiceInput.parameters = ParService

        Catch ex As Exception
            Throw New Exception("businessFramework.getGuidsForObjectFields: " + ex.ToString())
        End Try
    End Sub
    Public Sub autoGenerateObjectFields(genSheriffFields As Boolean, doAll As Boolean, Optional AddGroup As Boolean = True)
        Try
            Dim sqlAdminTmp As New sqlAdmin()
            sqlAdminTmp.initControl()

            Dim sWhere As String = ""
            Dim sWhereLicenseKeys As String = ""
            If doAll Then
                sqlAdmin.dsAllAdminAll = New dsAdmin()
                sWhere = " Classification like '%ComboType=Roles%'"
            Else
                If Not ENV.adminSecure Then
                    For Each rLicenuserLoggedOn As qs2.core.license.dsLicense.VariablesRow In qs2.core.license.doLicense.tVariables
                        Dim obj As Object = rLicenuserLoggedOn.VarValue.Trim()
                        If Not rLicenuserLoggedOn.VarValue.Trim().Equals(("0").Trim()) And Not rLicenuserLoggedOn.VarValue.Trim().Equals(("").Trim()) Then
                            sWhereLicenseKeys += IIf(sWhereLicenseKeys.Trim() = "", " ", " or ") + " LicenseKey like '%" + rLicenuserLoggedOn.VarName.Trim() + "%'"
                        End If
                    Next
                    If sWhereLicenseKeys.Trim() = "" Then
                        sWhereLicenseKeys = " ( " + " LicenseKey = '') "
                    Else
                        sWhereLicenseKeys = " ( " + sWhereLicenseKeys + " OR LicenseKey = '') "
                    End If
                    sWhere = sWhereLicenseKeys + " and Classification like '%ComboType=Roles%'"
                Else
                    sWhere = " Classification like '%ComboType=Roles%'"
                End If

                If genSheriffFields Then
                    sWhere += " and Classification like '%DeputyCriteria=%'"
                End If
            End If

            Dim sOrderBy As String = ""
            Dim arrCrit As dsAdmin.tblCriteriaRow() = sqlAdmin.dsAllAdmin.tblCriteria.Select(sWhere, sOrderBy)

            Dim rNewSelListGroup As core.vb.dsAdmin.tblSelListGroupRow = Nothing
            If AddGroup Then
                If doAll Then
                    rNewSelListGroup = sqlAdminTmp.getNewRowSelListGroup(sqlAdmin.dsAllAdminAll)
                Else
                    rNewSelListGroup = sqlAdminTmp.getNewRowSelListGroup(sqlAdmin.dsAllAdmin)
                End If
                rNewSelListGroup.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()
                rNewSelListGroup.IDParticipant = qs2.core.license.doLicense.eApp.ALL.ToString()
                If doAll Then
                    rNewSelListGroup.IDGroupStr = "ObjectFieldsAll"
                Else
                    If genSheriffFields Then
                        rNewSelListGroup.IDGroupStr = "ObjectFieldsSheriff"
                        rNewSelListGroup.ID = 2
                    Else
                        rNewSelListGroup.IDGroupStr = "ObjectFields"
                        rNewSelListGroup.ID = 1
                    End If
                End If
            Else
                Dim IDGroupStr As String = ""
                If genSheriffFields Then
                    IDGroupStr = "ObjectFieldsSheriff"
                Else
                    IDGroupStr = "ObjectFields"
                End If
                Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.IDGroupStrColumn.ColumnName + "='" + IDGroupStr.Trim() + "'", "")
                rNewSelListGroup = arrSelListEntryGroup(0)
            End If

            Dim IDSelList As Integer = 0
            Dim IDSort As Integer = 0
            For Each rCriteriaRoles As dsAdmin.tblCriteriaRow In arrCrit
                Dim rNewSelList As core.vb.dsAdmin.tblSelListEntriesRow = Nothing
                If doAll Then
                    rNewSelList = sqlAdminTmp.getNewRowSelList(sqlAdmin.dsAllAdminAll, True)
                Else
                    rNewSelList = sqlAdminTmp.getNewRowSelList(sqlAdmin.dsAllAdmin, True)
                End If

                rNewSelList.FldShortColumn = rCriteriaRoles.FldShort.Trim()
                rNewSelList._Table = rCriteriaRoles.SourceTable.Trim()
                rNewSelList.IDGroup = rNewSelListGroup.ID

                Dim sIDSelList As String = ""
                If IDSelList < 10 Then
                    sIDSelList = "000"
                ElseIf IDSelList >= 10 And IDSelList < 100 Then
                    sIDSelList = "00"
                ElseIf IDSelList >= 100 And IDSelList < 1000 Then
                    sIDSelList = "0"
                Else
                    Throw New Exception("autoGenerateObjectFields: IDSelList>= 1000 not allowed for IDGroupStr '" + rNewSelListGroup.IDGroupStr.ToString() + "'!")
                End If
                Dim IDSelListTmp As String = rNewSelListGroup.ID.ToString() + sIDSelList.Trim() + IDSelList.ToString()
                rNewSelList.ID = System.Convert.ToInt32(IDSelListTmp)
                rNewSelList.IDOwnStr = rCriteriaRoles.IDApplication.Trim()

                rNewSelList.sort = IDSort
                rNewSelList.IDRessource = rCriteriaRoles.FldShort.Trim() + "_" + IDSelList.ToString()
                rNewSelList.Classification = rCriteriaRoles.Classification

                IDSort += 1
                IDSelList += 1
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.autoGenerateObjectFields: " + ex.ToString())
        End Try
    End Sub
    Public Sub getObjectFields(ByRef ServiceInput As qs2.core.vb.QS2Service1.cServiceInput, isFct As Boolean, IsSend As Boolean,
                               ByRef dsAdminObjectFields As dsAdmin)
        Try
            Dim dsObjectsTmp As New dsObjects()
            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()

            Dim dtToDelete As New System.Collections.Generic.List(Of String)
            For Each dt As DataTable In dsAdminObjectFields.Tables
                If Not dt.TableName.Trim().ToLower().Equals(dsAdminObjectFields.tblSelListEntries.TableName.Trim().ToLower()) Then
                    dtToDelete.Add(dt.TableName)
                    dt.ChildRelations.Clear()
                    dt.ParentRelations.Clear()
                End If
            Next
            For Each dtName As String In dtToDelete
                dsAdminObjectFields.Tables.Remove(dtName)
            Next
            Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.IDGroupStrColumn.ColumnName + "='ObjectFieldsAll'", "")
            Dim arrSelListEntries() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntryGroup(0).ID.ToString() + "",
                                                                                                                               qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.FldShortColumnColumn.ColumnName + " asc")
            For Each rSelListFound As dsAdmin.tblSelListEntriesRow In arrSelListEntries
                If Not ServiceInput.parameters Is Nothing Then
                    For Each par As qs2.core.vb.QS2Service1.cSqlParameter In ServiceInput.parameters
                        If (rSelListFound.FldShortColumn).Trim().ToLower().Equals(par.SourceColumn.Trim().ToLower()) Then
                            Dim rObj As dsObjects.tblObjectRow = sqlObjectsTmp.getObjectRow(System.Convert.ToInt32(par.sValue), sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
                            par.IDObjectGuid = rObj.IDGuid.ToString()
                            par.IsObjectFieldForChange = True
                        End If
                    Next
                End If

                Dim rNew As dsAdmin.tblSelListEntriesRow = dsAdminObjectFields.tblSelListEntries.NewRow()
                rNew.ItemArray = rSelListFound.ItemArray
                dsAdminObjectFields.tblSelListEntries.Rows.Add(rNew)
            Next

            Dim sw As New System.IO.StringWriter()
            dsAdminObjectFields.WriteXml(sw, System.Data.XmlWriteMode.WriteSchema)
            ServiceInput.dsObjectFields = sw.ToString()
            sw.Close()

        Catch ex As Exception
            Throw New Exception("businessFramework.getObjectFields: " + ex.ToString())
        End Try
    End Sub
    Public Function checkIfObjectFieldForExtern(FieldName As String) As Boolean
        Try
            Dim dsAdminObjectFields As New dsAdmin()
            Dim dsObjectsTmp As New dsObjects()
            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()

            Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.IDGroupStrColumn.ColumnName + "='ObjectFieldsAll'", "")
            Dim arrSelListEntries() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntryGroup(0).ID.ToString() + "",
                                                                                                                               qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.FldShortColumnColumn.ColumnName + " asc")
            For Each rSelListFound As dsAdmin.tblSelListEntriesRow In arrSelListEntries
                If FieldName.Trim().ToLower().Equals(rSelListFound.FldShortColumn.Trim().ToLower()) Then
                    Return True
                End If
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.checkIfObjectFieldForExtern: " + ex.ToString())
        End Try
    End Function
    Public Function checkIDObjectSavedInStay(ByRef IDObject As Integer) As Boolean
        Try
            Dim sqlObjectsRead As New sqlObjects()
            sqlObjectsRead.initControl()
            Dim rObj As dsObjects.tblObjectRow = sqlObjectsRead.getObjectRow(IDObject, sqlObjects.eTypSelObj.ID)

            Dim arrSelListEntryGroup() As dsAdmin.tblSelListGroupRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListGroup.IDGroupStrColumn.ColumnName + "='ObjectFieldsAll'", "")
            Dim arrSelListEntries() As dsAdmin.tblSelListEntriesRow = qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.Select(qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrSelListEntryGroup(0).ID.ToString() + "",
                                                                                                                               qs2.core.vb.sqlAdmin.dsAllAdminAll.tblSelListEntries.FldShortColumnColumn.ColumnName + " asc")

            Dim bUserExistsInDatabase As Boolean = False
            For Each rSelListFound As dsAdmin.tblSelListEntriesRow In arrSelListEntries
                Dim dt As New DataTable()
                Dim cmd As New SqlClient.SqlCommand()
                Dim da As New SqlClient.SqlDataAdapter()
                cmd.CommandTimeout = 0
                cmd.Connection = qs2.core.dbBase.dbConn

                Dim sqlCommand As String = ""
                sqlCommand = " Select ID, IDParticipant, IDApplication, " + rSelListFound.FldShortColumn.Trim() + " from qs2." + rSelListFound._Table.Trim() + " where  " + rSelListFound.FldShortColumn.Trim() + "=" + IDObject.ToString() + " "
                cmd.CommandText = sqlCommand

                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    bUserExistsInDatabase = True
                End If
            Next

            Return bUserExistsInDatabase

        Catch ex As Exception
            Throw New Exception("businessFramework.checkIDObjectSavedInStay: " + ex.ToString())
        End Try
    End Function

    Public Function getGuidForObject(intIDObjectToCheck As Integer) As System.Guid
        Try
            Dim sqlObjectsTmp As New sqlObjects()
            sqlObjectsTmp.initControl()

            Dim rObj As dsObjects.tblObjectRow = sqlObjectsTmp.getObjectRow(intIDObjectToCheck, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none)
            Return rObj.IDGuid

        Catch ex As Exception
            Throw New Exception("businessFramework.getGuidForObject: " + ex.ToString())
        End Try
    End Function
    Public Function CheckAddNull(str As String) As String
        Try
            If str.Trim().Length = 1 Then
                Return "0" + str.Trim()
            ElseIf str.Trim().Length = 2 Then
                Return str.Trim()
            Else
                Throw New Exception("businessFramework.CheckNull: str.Trim().Length > 2 not possible for Str'" + str.Trim() + "'!")
            End If
        Catch ex As Exception
            Throw New Exception("businessFramework.CheckNull: " + ex.ToString())
        End Try
    End Function

    Public Function checkFieldsForTranslateSelList(ValueToCheck As String, QryColumn As String, IDApplication As String,
                                               ByRef EuroscoreTranslated As String) As Boolean
        Try
            Dim IDGroupStrScoreTyp As String = "rptCARDIAC_ScoreTyp"
            Dim IDGroupStrScoreTyp2 As String = "rptCardiac_EuroSCOREVersion"

            If QryColumn.Trim().Trim().ToLower().Equals((IDGroupStrScoreTyp).Trim().ToLower()) Then
                Dim IDOwnInt As Integer = System.Convert.ToInt32(ValueToCheck.Trim())
                EuroscoreTranslated = Me.translateSelList(IDGroupStrScoreTyp, IDOwnInt, IDApplication.Trim()).Trim()
                Return True
            End If
            If QryColumn.Trim().Trim().ToLower().Equals((IDGroupStrScoreTyp2).Trim().ToLower()) Then
                Dim IDOwnInt As Integer = System.Convert.ToInt32(ValueToCheck.Trim())
                EuroscoreTranslated = Me.translateSelList(IDGroupStrScoreTyp2, IDOwnInt, IDApplication.Trim()).Trim()
                Return True
            End If

            Return False

        Catch ex As Exception
            Throw New Exception("businessFramework.checkFieldsForTranslateSelList: " + ex.ToString())
        End Try
    End Function
    Public Function translateSelList(IDGruppeToSearch As String, IDOwnInt As Integer, IDApplication As String) As String
        Try
            Dim dsAdmin1 As New dsAdmin()
            Dim sqlAdmin1 As New sqlAdmin()
            sqlAdmin1.initControl()
            Dim AllProducts As Boolean = False
            Dim IDApplicationTmp As String = ""

            Dim arrGrp() As qs2.core.vb.dsAdmin.tblSelListGroupRow = sqlAdmin1.getSelListGroup(dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, "ALL", IDApplication)
            If arrGrp.Length <> 1 Then
                arrGrp = sqlAdmin1.getSelListGroup(dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelGruppen.IDGruppeRam, IDGruppeToSearch, "ALL", qs2.core.license.doLicense.eApp.ALL.ToString())
                If arrGrp.Length <> 1 Then
                    Throw New Exception("businessFramework.translateSelList: No rGroup found for IDGroup '" + IDGruppeToSearch.Trim() + "'!")
                Else
                    AllProducts = True
                    IDApplicationTmp = qs2.core.license.doLicense.eApp.ALL.ToString()
                End If
            End If

            Dim rGrp As qs2.core.vb.dsAdmin.tblSelListGroupRow = arrGrp(0)
            Dim Parameters As New qs2.core.vb.sqlAdmin.ParametersSelListEntries()
            Dim arrSelListEntries() As qs2.core.vb.dsAdmin.tblSelListEntriesRow
            arrSelListEntries = sqlAdmin1.getSelListEntrys(Parameters, IDGruppeToSearch, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                            IDApplicationTmp,
                                                            dsAdmin1, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDGroupRam, "", 0, "", rGrp.ID)
            For Each rSelListEntry As dsAdmin.tblSelListEntriesRow In arrSelListEntries
                If rSelListEntry.IDOwnInt.Equals(IDOwnInt) Then
                    Dim TranslationFound As String = qs2.core.language.sqlLanguage.getRes(rSelListEntry.IDRessource, True, True).Trim()
                    If TranslationFound.Trim() = "" Then
                        Return TranslationFound.Trim()
                    Else
                        Return TranslationFound.Trim()
                    End If
                End If
            Next

            Return IDOwnInt.ToString()

        Catch ex As Exception
            Throw New Exception("businessFramework.translateSelList: " + ex.ToString())
        End Try
    End Function

    Public Sub getProtocolStayForUser(rStayFound As qs2.core.vb.dsObjects.tblStayRow, ByRef sProtocolUser As String,
                                      ByRef iCounter As Integer, ByRef iCounterColumn As Integer,
                                      ByRef sProtocolError As String,
                                      ByRef lstProt As System.Collections.Generic.List(Of cProtEntry), bRepairSurg115 As Boolean)
        Try
            Dim sLineCol As String = "--------------------------------------------------------------------------------------------"
            Dim sColInfoEnd As String = ""
            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                db.Configuration.LazyLoadingEnabled = False

                Dim tProtocol As IQueryable(Of qs2.db.Entities.Protocol) = From rProtocol In db.Protocol Where rProtocol.IDStay = rStayFound.ID And
                                                                                    rProtocol.IDParticipant = rStayFound.IDParticipant And
                                                                                    rProtocol.IDApplication = rStayFound.IDApplication And
                                                                                    rProtocol.Type = "Stay" Order By rProtocol.Created Descending
                Dim FieldAdded As New System.Collections.Generic.List(Of String)
                For Each rProtocol In tProtocol
                    Dim NewProtEntry As New cProtEntry() With {
                        .ShortInfo = iCounter.ToString() + ". " + qs2.core.language.sqlLanguage.getRes("Stay") + ": " + rStayFound.MedRecN.Trim() + vbNewLine +
                                        qs2.core.language.sqlLanguage.getRes("ChangedAt") + ": " + rProtocol.Created.ToString("yyyy-MM-dd HH:mm:ss").Trim() + vbNewLine +
                                        qs2.core.language.sqlLanguage.getRes("FromUser") + ": " + rProtocol.User.Trim() + vbNewLine +
                                        qs2.core.language.sqlLanguage.getRes("Participant") + ": " + rStayFound.IDParticipant.Trim() + vbNewLine +
                                        qs2.core.language.sqlLanguage.getRes("ShortInfo") + ": " + rProtocol.Info.Trim() + vbNewLine + vbNewLine,
                        .MedRecNr = rStayFound.MedRecN.Trim(),
                        .ChangedAt = rProtocol.Created.ToString("yyyy-MM-dd HH:mm:ss").Trim(),
                        .FromUser = rProtocol.User.Trim(),
                        .Participant = rStayFound.IDParticipant.Trim(),
                        .IDStay = rStayFound.ID,
                        .Application = rStayFound.IDApplication.Trim(),
                        .ProtFrom = rProtocol.Created
                    }
                    lstProt.Add(NewProtEntry)

                    Dim bEnd As Boolean = False
                    Dim actPos As Integer = 0
                    Dim sProtocol As String = rProtocol.Protocol1.Trim()
                    Do While (Not bEnd)
                        Dim posNewValue As Integer = -1
                        Dim posTable As Integer = sProtocol.IndexOf("Table:", actPos)
                        If posTable = -1 Then
                            Exit Do
                        Else
                            Dim posColumn As Integer = sProtocol.IndexOf("Column:", posTable + 6)
                            If posColumn = -1 Then
                                Exit Do
                            Else
                                Dim posOrigValue As Integer = sProtocol.IndexOf("Original value:", posColumn + 7)
                                posNewValue = sProtocol.IndexOf("New value", posOrigValue + 15)
                                If posOrigValue <> -1 And posNewValue <> -1 Then
                                    Dim sTable As String = sProtocol.Substring(posTable + 6, posColumn - 6 - posTable)
                                    Dim sColumn As String = sProtocol.Substring(posColumn + 7, posOrigValue - posColumn - 7)
                                    Dim sOrigValue As String = sProtocol.Substring(posOrigValue + 15, posNewValue - posOrigValue - 15)
                                    Dim sNewValue As String = ""
                                    Dim posEndColumn As Integer = sProtocol.IndexOf("----------------------------------------", posNewValue + 9)
                                    If posEndColumn = -1 Then
                                        Throw New Exception("getProtocolStayForUser: posEndColumn not found in protocol ''" + rProtocol.IDApplication.ToString() + "!")
                                    Else
                                        sNewValue = sProtocol.Substring(posNewValue + 9, posEndColumn - posNewValue - 9)
                                    End If

                                    Dim bDoField As Boolean = False
                                    If bRepairSurg115 Then
                                        If sColumn.Trim().ToLower().Equals(("VAC1Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC2Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC3Surg").Trim().ToLower()) Or
                                                sColumn.Trim().ToLower().Equals(("VAC4Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC5Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC6Surg").Trim().ToLower()) Or
                                                sColumn.Trim().ToLower().Equals(("VAC7Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC8Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC9Surg").Trim().ToLower()) Or
                                                sColumn.Trim().ToLower().Equals(("VAC10Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC11Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC12Surg").Trim().ToLower()) Or
                                                sColumn.Trim().ToLower().Equals(("VAC13Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC14Surg").Trim().ToLower()) Or sColumn.Trim().ToLower().Equals(("VAC15Surg").Trim().ToLower()) Then

                                            If sOrigValue.Trim() <> "-1" Then
                                                If Not FieldAdded.Contains(sColumn.Trim()) Then
                                                    bDoField = True
                                                End If
                                            End If
                                        End If
                                    Else
                                        bDoField = True
                                    End If

                                    If bDoField Then
                                        Dim NewProtEntryDetail As New cProtEntryDetail()
                                        NewProtEntry.lstProtDetail.Add(NewProtEntryDetail)
                                        iCounterColumn += 1

                                        NewProtEntryDetail.IDParticipant = rStayFound.IDParticipant.Trim()
                                        NewProtEntryDetail.IDStay = rStayFound.ID
                                        NewProtEntryDetail.Application = rStayFound.IDApplication.Trim()
                                        NewProtEntryDetail.ProtFrom = rProtocol.Created

                                        NewProtEntryDetail.OldValueDB = sOrigValue.Trim()
                                        NewProtEntryDetail.NewValueDB = sNewValue.Trim()

                                        Dim rCriteriaFound As qs2.db.Entities.tblCriteria = Nothing
                                        If Me.getCriteria(rStayFound.IDApplication.Trim(), sColumn.Trim(), sProtocolError, rCriteriaFound, db) Then
                                            NewProtEntryDetail.FldShort = rCriteriaFound.FldShort.Trim()
                                            NewProtEntryDetail.SqlTable = rCriteriaFound.SourceTable.Trim()
                                            NewProtEntryDetail.FldShort = rCriteriaFound.FldShort.Trim()

                                            Dim sColumnTranslated As String = qs2.core.language.sqlLanguage.getRes(rCriteriaFound.FldShort.Trim(), True)
                                            If sColumnTranslated.Trim() <> "" Then
                                                NewProtEntryDetail.ColName = sColumnTranslated.Trim()   'qs2.core.language.sqlLanguage.getRes("Column") + ": " + sColumnTranslated.Trim() + sColInfoEnd
                                            Else
                                                NewProtEntryDetail.ColName = sColumn.Trim()             'qs2.core.language.sqlLanguage.getRes("Column") + ": " + sColumn.Trim() + sColInfoEnd
                                            End If
                                            Dim sControlTypeTranslated As String = qs2.core.language.sqlLanguage.getRes(rCriteriaFound.ControlType.Trim(), True)
                                            If sControlTypeTranslated.Trim() = "" Then
                                                sControlTypeTranslated = rCriteriaFound.ControlType.Trim()
                                            End If
                                            NewProtEntryDetail.ImputType = sControlTypeTranslated.Trim()            'qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + sControlTypeTranslated.Trim() + sColInfoEnd

                                            If (rCriteriaFound.ControlType.Trim().ToLower().Equals((Enums.eControlType.ComboBox.ToString()).Trim().ToLower) Or
                                                rCriteriaFound.ControlType.Trim().ToLower().Equals((Enums.eControlType.ComboBoxNoDb.ToString()).Trim().ToLower)) And Not rCriteriaFound.Classification.Trim().ToLower().Contains(("Type=IDObject").Trim().ToLower()) Then

                                                Dim IDOwnIntOrig As Integer = -999
                                                If Integer.TryParse(sOrigValue.Trim(), IDOwnIntOrig) Then
                                                    Dim sTranslatedSelListReturn As String = ""
                                                    Dim sGroupSelList As String = rCriteriaFound.FldShort.Trim()
                                                    If rCriteriaFound.AliasFldShort.Trim() <> "" Then
                                                        sGroupSelList = rCriteriaFound.AliasFldShort.Trim()
                                                    End If
                                                    If Me.getSelListGroupSearchTranslation(rStayFound.IDApplication.Trim(), sGroupSelList.Trim(), IDOwnIntOrig, sTranslatedSelListReturn, sProtocolError, db) Then
                                                        NewProtEntryDetail.OldValue = sTranslatedSelListReturn.Trim() + "  (" + sOrigValue.Trim() + ")"               'qs2.core.language.sqlLanguage.getRes("OldValue") + ": " + sTranslatedSelListReturn.Trim() + "  (" + sOrigValue.Trim() + ")" + vbNewLine
                                                    Else
                                                        NewProtEntryDetail.OldValue = sOrigValue.Trim()                                 'qs2.core.language.sqlLanguage.getRes("OldValue") + ": " + sOrigValue.Trim() + sColInfoEnd
                                                    End If
                                                Else
                                                    NewProtEntryDetail.OldValue = sOrigValue.Trim()                                     'qs2.core.language.sqlLanguage.getRes("OldValue") + ": " + sOrigValue.Trim() + sColInfoEnd
                                                End If

                                                Dim IDOwnIntNew As Integer = -999
                                                If Integer.TryParse(sNewValue.Trim(), IDOwnIntNew) Then
                                                    Dim sTranslatedSelListReturn As String = ""
                                                    Dim sGroupSelList As String = rCriteriaFound.FldShort.Trim()
                                                    If rCriteriaFound.AliasFldShort.Trim() <> "" Then
                                                        sGroupSelList = rCriteriaFound.AliasFldShort.Trim()
                                                    End If
                                                    If Me.getSelListGroupSearchTranslation(rStayFound.IDApplication.Trim(), sGroupSelList.Trim(), IDOwnIntNew, sTranslatedSelListReturn, sProtocolError, db) Then
                                                        NewProtEntryDetail.NewValue = sTranslatedSelListReturn.Trim() + "  (" + sNewValue.Trim() + ")"                 'qs2.core.language.sqlLanguage.getRes("NewValue") + ": " + sTranslatedSelListReturn.Trim() + "  (" + sNewValue.Trim() + ")" + sColInfoEnd
                                                    Else
                                                        NewProtEntryDetail.NewValue = sNewValue.Trim()                                  'qs2.core.language.sqlLanguage.getRes("NewValue") + ": " + sNewValue.Trim() + sColInfoEnd
                                                    End If
                                                Else
                                                    NewProtEntryDetail.NewValue = sNewValue.Trim()                                      'qs2.core.language.sqlLanguage.getRes("NewValue") + ": " + sNewValue.Trim() + sColInfoEnd
                                                End If

                                            Else
                                                NewProtEntryDetail.OldValue = sOrigValue.Trim()                                         'qs2.core.language.sqlLanguage.getRes("OldValue") + ": " + sOrigValue.Trim() + sColInfoEnd
                                                NewProtEntryDetail.NewValue = sNewValue.Trim()                                          'qs2.core.language.sqlLanguage.getRes("NewValue") + ": " + sNewValue.Trim() + sColInfoEnd
                                            End If

                                            If rCriteriaFound.Classification.Trim().ToLower().Contains(("Type=IDObject").Trim().ToLower()) Then
                                                Dim iOldValueDB As Integer = System.Convert.ToInt32(NewProtEntryDetail.OldValueDB.ToString())
                                                If iOldValueDB <> -1 Then
                                                    Dim tObjects As IQueryable(Of qs2.db.Entities.tblObject) = From rObj In db.tblObject Where rObj.ID = iOldValueDB
                                                    If tObjects.Count() > 0 Then
                                                        Dim rObj As qs2.db.Entities.tblObject = tObjects.First()
                                                        NewProtEntryDetail.OldValue = rObj.LastName.Trim() + " " + rObj.FirstName.Trim() + " (" + NewProtEntryDetail.OldValueDB + ")"
                                                    End If
                                                End If

                                                Dim iNewValueDB As Integer = System.Convert.ToInt32(NewProtEntryDetail.NewValueDB.ToString())
                                                If iNewValueDB <> -1 Then
                                                    Dim tObjects As IQueryable(Of qs2.db.Entities.tblObject) = From rObj In db.tblObject Where rObj.ID = iNewValueDB
                                                    If tObjects.Count() > 0 Then
                                                        Dim rObj As qs2.db.Entities.tblObject = tObjects.First()
                                                        NewProtEntryDetail.NewValue = rObj.LastName.Trim() + " " + rObj.FirstName.Trim() + " (" + NewProtEntryDetail.NewValueDB + ")"
                                                    End If
                                                End If
                                            End If

                                        Else
                                            'sProtocolUser += qs2.core.language.sqlLanguage.getRes("Table") + ": " + sTable.Trim() + vbNewLine
                                            Dim sColumnTranslated As String = qs2.core.language.sqlLanguage.getRes(sColumn.Trim(), True)
                                            If sColumnTranslated.Trim() <> "" Then
                                                NewProtEntryDetail.ColName = sColumnTranslated.Trim()                           'qs2.core.language.sqlLanguage.getRes("Column") + ": " + sColumnTranslated.Trim() + sColInfoEnd
                                            Else
                                                NewProtEntryDetail.ColName = sColumn.Trim()                                     'qs2.core.language.sqlLanguage.getRes("Column") + ": " + sColumn.Trim() + sColInfoEnd
                                            End If
                                            NewProtEntryDetail.OldValue = sOrigValue.Trim()                                     'qs2.core.language.sqlLanguage.getRes("OldValue") + ": " + sOrigValue.Trim() + sColInfoEnd
                                            NewProtEntryDetail.NewValue = sNewValue.Trim()                                      'qs2.core.language.sqlLanguage.getRes("NewValue") + ": " + sNewValue.Trim() + sColInfoEnd
                                        End If

                                        FieldAdded.Add(NewProtEntryDetail.FldShort.Trim())
                                    End If
                                    'sProtocolUser += vbNewLine
                                Else
                                    Throw New Exception("getProtocolStayForUser: posOrigValue<>-1 And posNewValue<>-1 not allowed for IDprotocol '" + rProtocol.IDApplication.ToString() + "'!")
                                End If
                            End If
                        End If

                        If posNewValue <> -1 Then
                            Dim posTableNext As Integer = sProtocol.IndexOf("Table:", posNewValue + 9)
                            If posTableNext = -1 Then
                                Exit Do
                            Else
                                actPos = posTableNext
                            End If
                        Else
                            Exit Do
                        End If
                    Loop
                    'sProtocolUser += sLineCol + vbNewLine + vbNewLine
                Next
            End With

            'int Position1 = frmEditor.ContTxtEditor1.textControl1.InputPosition.TextPosition;
            'this.doEditor1.appendText2(infoRow.Trim(), frmEditor.ContTxtEditor1.textControl1, TXTextControl.StringStreamType.PlainText);
            'this.doEditor1.insertLinebreakxy(frmEditor.ContTxtEditor1.textControl1);
            'frmEditor.ContTxtEditor1.textControl1.Select(Position1, frmEditor.ContTxtEditor1.textControl1.Text.Length - Position1);
            'frmEditor.ContTxtEditor1.textControl1.Selection.FontSize = 10 * 20;
            'frmEditor.ContTxtEditor1.textControl1.Selection.FontName = "Arial";
            'frmEditor.ContTxtEditor1.textControl1.Selection.ForeColor = System.Drawing.Color.RoyalBlue;
            'frmEditor.ContTxtEditor1.textControl1.Selection.Bold = true;

        Catch ex As Exception
            Throw New Exception("businessFramework.getProtocolStayForUser: " + ex.ToString())
        End Try
    End Sub

    Public Function getCriteria(IDApplication As String, sColumn As String, ByRef sProtocol As String,
                                ByRef rCriteriaReturn As qs2.db.Entities.tblCriteria,
                                 db As qs2.db.Entities.ERModellQS2Entities) As Boolean
        Try
            Dim tCriteria As IQueryable(Of qs2.db.Entities.tblCriteria) = From rCriteria In db.tblCriteria Where rCriteria.IDApplication = IDApplication And
                                                                                rCriteria.FldShort = sColumn
            If tCriteria.Count = 1 Then
                Dim rCriteria As qs2.db.Entities.tblCriteria = tCriteria.First()
                rCriteriaReturn = rCriteria
                Return True
            ElseIf tCriteria.Count = 0 Then
                Dim sAppAll As String = qs2.core.license.doLicense.eApp.ALL.ToString().Trim()
                tCriteria = From rCriteria In db.tblCriteria Where rCriteria.IDApplication = sAppAll And
                                                                    rCriteria.FldShort = sColumn

                If tCriteria.Count = 1 Then
                    Dim rCriteria As qs2.db.Entities.tblCriteria = tCriteria.First()
                    rCriteriaReturn = rCriteria
                    Return True
                ElseIf tCriteria.Count = 0 Then
                    Return False
                Else
                    Throw New Exception("tCriteria.Count>1 for FldShort '" + sColumn.Trim() + "' and IDApplication '" + IDApplication.Trim() + "'!")
                End If
            Else
                Throw New Exception("tCriteria.Count>1 for FldShort '" + sColumn.Trim() + "' and IDApplication '" + IDApplication.Trim() + "'!")
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.getCriteria: " + ex.ToString())
        End Try
    End Function
    Public Function getSelListGroupSearchTranslation(IDApplication As String, sColumn As String, ByRef IDOwnInt As Integer,
                                                     ByRef sTranslatedReturn As String, ByRef sProtocol As String,
                                                     db As qs2.db.Entities.ERModellQS2Entities) As Boolean
        Try
            Dim tSelListGroup As IQueryable(Of qs2.db.Entities.tblSelListGroup) = From rSelListGroup In db.tblSelListGroup Where
                                                                                        rSelListGroup.IDGroupStr = sColumn And
                                                                                        rSelListGroup.IDApplication = IDApplication
            If tSelListGroup.Count = 1 Then
                Dim rSelListGroup As qs2.db.Entities.tblSelListGroup = tSelListGroup.First()
                Me.getSelListTranslated(IDApplication, sColumn, IDOwnInt, sTranslatedReturn, sProtocol, db, rSelListGroup)
                Return True
            Else
                Dim sAppAll As String = qs2.core.license.doLicense.eApp.ALL.ToString().Trim()
                tSelListGroup = From rSelListGroup In db.tblSelListGroup Where
                                                        rSelListGroup.IDGroupStr = sColumn And
                                                        rSelListGroup.IDApplication = sAppAll
                If tSelListGroup.Count = 1 Then
                    Dim rSelListGroup As qs2.db.Entities.tblSelListGroup = tSelListGroup.First()
                    Me.getSelListTranslated(IDApplication, sColumn, IDOwnInt, sTranslatedReturn, sProtocol, db, rSelListGroup)
                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.getSelListGroupSearchTranslation: " + ex.ToString())
        End Try
    End Function
    Public Function getSelListTranslated(IDApplication As String, sColumn As String, ByRef IDOwnInt As Integer,
                                                 ByRef sTranslatedReturn As String, ByRef sProtocol As String,
                                                 db As qs2.db.Entities.ERModellQS2Entities, rSelListGroup As qs2.db.Entities.tblSelListGroup) As Boolean
        Try
            Dim tSelListEntries As IQueryable(Of qs2.db.Entities.tblSelListEntries) = From rSelListEntries In db.tblSelListEntries Where
                                                                        rSelListEntries.IDGroup = rSelListGroup.ID

            Dim bFound As Boolean = False
            For Each rSelListEntry As qs2.db.Entities.tblSelListEntries In tSelListEntries
                If Not rSelListEntry.IDOwnInt Is Nothing Then
                    If rSelListEntry.IDOwnInt.Equals(IDOwnInt) Then
                        Dim sSelListTranslated As String = qs2.core.language.sqlLanguage.getRes(rSelListEntry.IDRessource, True)
                        If sSelListTranslated.Trim() <> "" Then
                            sTranslatedReturn = sSelListTranslated
                            bFound = True
                            Return True
                        Else
                            sTranslatedReturn = IDOwnInt.ToString()
                            bFound = True
                            Return True
                        End If
                    End If
                End If
            Next
            If Not bFound = True Then
                Dim xy As String = ""
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.getSelListTranslated: " + ex.ToString())
        End Try
    End Function


    Public Sub checkDoubledRows()
        Try
            Dim sProtocollDetailDoubledDeleted As String = ""
            Dim iCounterDoubledDeleted As Integer = 0
            Dim dsHelperRead As New dsHelper()
            Dim sqlHelperRead As New sqlHelper()
            sqlHelperRead.initControl()

            sqlHelperRead.getSelListObjDoubledSelLists(sqlHelper.eTypeSel.All, dsHelperRead)
            For Each rHelper As dsHelper.tblSelListObjDoubledSelListsRow In dsHelperRead.tblSelListObjDoubledSelLists
                Dim dDoubledFoundForDelete As Boolean = False
                'Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                'Dim tSelListEntriesObj As IQueryable(Of qs2.db.Entities.tblSelListEntriesObj) = Nothing
                'tSelListEntriesObj = From rSelListEntriesObj In db.tblSelListEntriesObj
                '                     Where rSelListEntriesObj.IDSelListEntry = rHelper.IDSelListEntry And (Not rSelListEntriesObj.IDSelListEntrySublist Is Nothing) And
                '                            rSelListEntriesObj.IDSelListEntrySublist = rHelper.IDSelListEntrySublist And
                '                            rSelListEntriesObj.typIDGroup = rHelper.typIDGroup And
                '                            rSelListEntriesObj.FldShort Is Nothing And rSelListEntriesObj.IDApplication Is Nothing And rSelListEntriesObj.IDObject Is Nothing And
                '                            rSelListEntriesObj.IDStay Is Nothing And rSelListEntriesObj.IDParticipantStay = Nothing And rSelListEntriesObj.IDApplicationStay Is Nothing And
                '                            (rSelListEntriesObj.IDParticipant = "" Or rSelListEntriesObj.IDParticipant = "ALL")

                'Dim b2 As New qs2.core.db.ERSystem.businessFramework()
                'Dim tSelListEntriesObj As IQueryable(Of qs2.db.Entities.tblSelListEntriesObj) = b2.getSelListObjDoubledSelLists(rHelper.IDSelListEntry, rHelper.IDSelListEntrySublist, rHelper.typIDGroup.Trim(), db)

                Dim dsAdminUpdate As New dsAdmin()
                Dim sqlAdminUpdate As New sqlAdmin()
                sqlAdminUpdate.initControl()
                sqlAdminUpdate.getSelListObjDoubledSelLists(dsAdminUpdate, rHelper.IDSelListEntry, rHelper.IDSelListEntrySublist, rHelper.typIDGroup.Trim())

                Dim iCounterDoubled As Integer = 0
                Dim lstRowsToDelete As New System.Collections.Generic.List(Of dsAdmin.tblSelListEntriesObjRow)
                If dsAdminUpdate.tblSelListEntriesObj.Rows.Count > 1 Then
                    For Each rDoubleSelListObj As dsAdmin.tblSelListEntriesObjRow In dsAdminUpdate.tblSelListEntriesObj
                        If (Not rDoubleSelListObj.IsIDSelListEntrySublistNull()) And rDoubleSelListObj.IsFldShortNull() And rDoubleSelListObj.IsIDStayNull() And
                                    rDoubleSelListObj.IsIDApplicationStayNull() And rDoubleSelListObj.IsIDParticipantStayNull() And
                                    rDoubleSelListObj.IsIDObjectNull() Then

                            If iCounterDoubled > 0 Then
                                lstRowsToDelete.Add(rDoubleSelListObj)
                                dDoubledFoundForDelete = True
                                iCounterDoubledDeleted += 1
                                sProtocollDetailDoubledDeleted += "typIDGroup=" + rDoubleSelListObj.typIDGroup.Trim() + ", IDSelListEntry=" + rDoubleSelListObj.IDSelListEntry.ToString() + ", IDSelListEntrySublist=" + rDoubleSelListObj.IDSelListEntrySublist.ToString() + "" + vbNewLine
                            End If
                            iCounterDoubled += 1
                        Else
                            Dim xy As String = ""
                        End If
                    Next
                    For Each rDoubleSelListObjToDelete As dsAdmin.tblSelListEntriesObjRow In lstRowsToDelete
                        rDoubleSelListObjToDelete.Delete()
                    Next
                    If dDoubledFoundForDelete Then
                        sqlAdminUpdate.daSelListEntrysObj.Update(dsAdminUpdate.tblSelListEntriesObj)
                    End If
                End If
            Next

            sqlHelperRead.getSelListObjDoubledFldShorts(sqlHelper.eTypeSel.All, dsHelperRead)
            For Each rHelper As dsHelper.tblSelListObjDoubledFldShortsRow In dsHelperRead.tblSelListObjDoubledFldShorts
                Dim dDoubledFoundForDelete As Boolean = False
                'Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                'Dim tSelListEntriesObj As IQueryable(Of qs2.db.Entities.tblSelListEntriesObj) = Nothing
                'tSelListEntriesObj = From rSelListEntriesObj In db.tblSelListEntriesObj
                '                     Where rSelListEntriesObj.IDSelListEntry = rHelper.IDSelListEntry And
                '                            rSelListEntriesObj.IDSelListEntrySublist Is Nothing And
                '                            rSelListEntriesObj.typIDGroup = rHelper.typIDGroup And (Not rSelListEntriesObj.FldShort Is Nothing) And
                '                            rSelListEntriesObj.FldShort = rHelper.FldShort And rSelListEntriesObj.IDApplication = rHelper.IDApplication And
                '                            rSelListEntriesObj.IDObject Is Nothing And
                '                            rSelListEntriesObj.IDStay Is Nothing And rSelListEntriesObj.IDParticipantStay = Nothing And rSelListEntriesObj.IDApplicationStay Is Nothing And
                '                            (rSelListEntriesObj.IDParticipant = "" Or rSelListEntriesObj.IDParticipant = "ALL")

                'Dim b2 As New qs2.core.db.ERSystem.businessFramework()
                'Dim tSelListEntriesObj As IQueryable(Of qs2.db.Entities.tblSelListEntriesObj) = b2.getSelListObjDoubledFldShorts(rHelper.IDSelListEntry, rHelper.FldShort.Trim(), rHelper.IDApplication.Trim(), rHelper.typIDGroup.Trim(), db)

                Dim dsAdminUpdate As New dsAdmin()
                Dim sqlAdminUpdate As New sqlAdmin()
                sqlAdminUpdate.initControl()
                sqlAdminUpdate.getSelListObjDoubledFldShorts(dsAdminUpdate, rHelper.IDSelListEntry, rHelper.FldShort.Trim(), rHelper.IDApplication.Trim(), rHelper.typIDGroup.Trim())

                Dim lstRowsToDelete As New System.Collections.Generic.List(Of dsAdmin.tblSelListEntriesObjRow)
                Dim iCounterDoubled As Integer = 0
                If dsAdminUpdate.tblSelListEntriesObj.Rows.Count > 1 Then
                    For Each rDoubleSelListObj As dsAdmin.tblSelListEntriesObjRow In dsAdminUpdate.tblSelListEntriesObj
                        If rDoubleSelListObj.IsIDSelListEntrySublistNull() And (Not rDoubleSelListObj.IsFldShortNull()) And rDoubleSelListObj.IsIDStayNull() And
                                    rDoubleSelListObj.IsIDApplicationStayNull() And rDoubleSelListObj.IsIDParticipantStayNull() And
                                    rDoubleSelListObj.IsIDObjectNull() Then

                            If iCounterDoubled > 0 Then
                                lstRowsToDelete.Add(rDoubleSelListObj)
                                dDoubledFoundForDelete = True
                                iCounterDoubledDeleted += 1
                                sProtocollDetailDoubledDeleted += "typIDGroup=" + rDoubleSelListObj.typIDGroup.Trim() + ", IDSelListEntry=" + rDoubleSelListObj.IDSelListEntry.ToString() + ", FldShort=" + rDoubleSelListObj.FldShort.Trim() + "" + vbNewLine
                            End If
                            iCounterDoubled += 1
                        Else
                            Dim xy As String = ""
                        End If
                    Next
                    For Each rDoubleSelListObjToDelete As dsAdmin.tblSelListEntriesObjRow In lstRowsToDelete
                        rDoubleSelListObjToDelete.Delete()
                    Next
                    If dDoubledFoundForDelete Then
                        sqlAdminUpdate.daSelListEntrysObj.Update(dsAdminUpdate.tblSelListEntriesObj)
                    End If
                End If
            Next

            Dim sProtocollHeader As String = ""
            If iCounterDoubledDeleted = 0 Then
                sProtocollHeader = "No doubled rows found for delete!"
            Else
                sProtocollHeader = iCounterDoubledDeleted.ToString() + " doubled rows found and deleted!"
            End If

            If sProtocollDetailDoubledDeleted.Trim() <> "" Then
                sProtocollDetailDoubledDeleted = "Rows deleted:" + vbNewLine + sProtocollDetailDoubledDeleted
            End If

            Dim frmProtocol1 As New frmProtocol()
            frmProtocol1.initControl()
            frmProtocol1.Text = "Clear doubled Rows"
            frmProtocol1.Show()
            frmProtocol1.ContProtocol1.setText(sProtocollHeader + vbNewLine + vbNewLine + sProtocollDetailDoubledDeleted.Trim())

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.checkDoubledRows: " + ex.ToString())
        End Try
    End Sub

    Public Function copyStaysToDB(ByRef ConnStrAimDB As String, ByRef rStayToCopy As dsObjects.tblStayRow,
                                 ByRef iCounter As Integer, ByRef protocol As String, ByRef UpdateExistingStays As Boolean) As Boolean
        Try
            Dim bStayAdded As Boolean = False
            Dim iCounterProductStaysAdded As Integer = 0

            Dim dsSysDBRead As New qs2.core.SysDB.dsSysDB()
            Dim sqlSysDBRead As New qs2.core.SysDB.sqlSysDB()
            sqlSysDBRead.initControl()

            'ConnStrAimDB = ConnStrAimDB.Replace(qs2.core.dbBase.PwdEncrypted, qs2.core.dbBase.PwdDecrypted)
            Dim connZiel As New System.Data.SqlClient.SqlConnection(ConnStrAimDB)
            connZiel.Open()

            Dim sWhereProductStaysxy As String = " ID=" + rStayToCopy.ID.ToString() + " and IDParticipant='" + rStayToCopy.IDParticipant + "' and " +
                                    " IDApplication='" + rStayToCopy.IDApplication + "' "

            Dim sWhereProductStaysMedRecNr As String = "  IDParticipant='" + rStayToCopy.IDParticipant + "' and " +
                                                    " IDApplication='" + rStayToCopy.IDApplication + "' and " +
                                                     " MedRecN='" + rStayToCopy.MedRecN + "' and " +
                                                      " Incidence=" + rStayToCopy.Incidence.ToString() + " "

            Dim sInfoStay As String = " MedRecNr: " + rStayToCopy.MedRecN.Trim() + " (" + sWhereProductStaysxy + ") "

            Dim sWhereFields As String = ""
            dsSysDBRead.COLUMNS.Clear()
            sqlSysDBRead.getSysColumns("tblStay", dsSysDBRead, SysDB.sqlSysDB.eTypSelColumns.table)
            For Each rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow In dsSysDBRead.COLUMNS
                sWhereFields += IIf(sWhereFields.Trim() = "", " ", ",") + rColSys.COLUMN_NAME.Trim()
            Next

            Dim dt_Ziel2 As New DataTable()
            Dim da_Ziel2 As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmd_Ziel2 As New System.Data.SqlClient.SqlCommand() With {
                .CommandTimeout = 0,
                .Connection = connZiel
            }
            da_Ziel2.SelectCommand = cmd_Ziel2
            cmd_Ziel2.CommandText = " Select " + sWhereFields + " from qs2.tblStay where " + sWhereProductStaysMedRecNr
            da_Ziel2.Fill(dt_Ziel2)
            If dt_Ziel2.Rows.Count = 1 Then
                Dim xy As String = ""
                'protocol += "MedRecN exists in Database!" + " -- MedRecNr " + sWhereProductStaysMedRecNr + " already  more than one in Aim-DB!" + sInfoStay + "!" + vbNewLine
                'If DeleteIfKeyMedRecNrExists Then
                '    'cmd_Ziel2 = New System.Data.SqlClient.SqlCommand()
                '    'cmd_Ziel2.CommandTimeout = 0
                '    'cmd_Ziel2.Connection = connZiel
                '    'cmd_Ziel2.CommandText = " Delete from qs2.tblStay where " + sWhereProductStaysMedRecNr
                '    'cmd_Ziel2.ExecuteNonQuery()

                '    'Dim NextMedRecN As String = ""
                '    'Dim sql As New sqlObjects()
                '    'sql.initControl()
                '    'sql.getNextMedRecNrForProductAuto(rStayToCopy.IDParticipant, rStayToCopy.IDApplication, NextMedRecN, Enums.eStayTyp.Stay)
                'Else
                '    Return False
                'End If

            ElseIf dt_Ziel2.Rows.Count > 1 Then
                Dim sExcept As String = "Exception Table:tblStay" + " -- MedRecNr " + sInfoStay + " (" + sWhereProductStaysMedRecNr + ") " + " already exists more than one time in target-DB!" + sInfoStay + "!" + vbNewLine
                Throw New Exception(sExcept)
            End If

            Dim dt_Quelle As New DataTable()
            Dim da_Quelle As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmd_Quelle As New System.Data.SqlClient.SqlCommand()
            cmd_Quelle.Connection = qs2.core.dbBase.dbConn
            cmd_Quelle.CommandTimeout = 0
            cmd_Quelle.CommandText = " Select " + sWhereFields + " from qs2.tblStay where " + sWhereProductStaysxy
            da_Quelle.SelectCommand = cmd_Quelle
            da_Quelle.Fill(dt_Quelle)
            If dt_Quelle.Rows.Count <> 1 Then
                protocol += "Exception tblStay: dt_Quelle.Rows.Count<>1 for MedRecNr " + sInfoStay + "!" + vbNewLine
            End If

            Dim dt_Ziel As New DataTable()
            Dim da_Ziel As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmd_Ziel As New System.Data.SqlClient.SqlCommand()
            cmd_Ziel.CommandTimeout = 0
            cmd_Ziel.Connection = connZiel
            da_Ziel.SelectCommand = cmd_Ziel
            cmd_Ziel.CommandText = cmd_Quelle.CommandText
            da_Ziel.Fill(dt_Ziel)
            If dt_Ziel.Rows.Count = 0 Then
                If dt_Ziel2.Rows.Count = 1 Then
                    protocol += "Error " + " -- MedRecNr " + sInfoStay + " already exists in Target-Database! Stay can not updated!" + vbNewLine
                    Return False
                End If

                Dim rToCopy As DataRow = dt_Quelle.Rows(0)
                Dim rNew As DataRow = dt_Ziel.NewRow()
                rNew.ItemArray = rToCopy.ItemArray
                dt_Ziel.Rows.Add(rNew)
                dt_Ziel.AcceptChanges()
                rNew.SetAdded()

                Dim builder As New SqlCommandBuilder(da_Ziel)
                builder.GetUpdateCommand()
                da_Ziel.Update(dt_Ziel)
                bStayAdded = True

            ElseIf dt_Ziel.Rows.Count = 1 Then
                If Not UpdateExistingStays Then
                    Return False
                End If

                Dim bAnyChanges As Boolean = False
                Dim r_QuelleOrig As DataRow = dt_Quelle.Rows(0)
                Dim r_ZielSave As DataRow = dt_Ziel.Rows(0)

                Dim TargetRowHasMainStay As Boolean = False
                Dim IDStayParent As Integer = 0
                Dim IDParticipantParent As String = ""
                Dim IDApplicationParent As String = ""
                If Not r_ZielSave("IDStayParent") Is System.DBNull.Value Then
                    IDStayParent = r_ZielSave("IDStayParent")
                    IDParticipantParent = r_ZielSave("IDParticipantParent")
                    IDApplicationParent = r_ZielSave("IDApplicationParent")
                    TargetRowHasMainStay = True
                End If

                'r_QuelleOrig("DischDt") = System.DBNull.Value
                'r_ZielSave("DischDt") = Now
                For Each col As DataColumn In dt_Ziel.Columns
                    If Not r_ZielSave(col.ColumnName).Equals(r_QuelleOrig(col.ColumnName)) Then
                        r_ZielSave(col.ColumnName) = r_QuelleOrig(col.ColumnName)
                        bAnyChanges = True
                    End If
                Next
                If TargetRowHasMainStay Then
                    r_ZielSave("IDStayParent") = IDStayParent
                    r_ZielSave("IDParticipantParent") = IDParticipantParent
                    r_ZielSave("IDApplicationParent") = IDApplicationParent
                    bAnyChanges = True
                End If
                If bAnyChanges Then
                    Dim builder As New SqlCommandBuilder(da_Ziel)
                    builder.GetUpdateCommand()
                    da_Ziel.Update(dt_Ziel)
                End If
                bStayAdded = True

                'protocol += "Info Table:tblStay" + " -- MedRecNr " + sInfoStay + " already exists in Aim-DB" + vbNewLine

            ElseIf dt_Ziel.Rows.Count > 1 Then
                protocol += "Exception Table:tblStay" + " -- MedRecNr " + sInfoStay + " already exists more than one time in target-DB!" + sInfoStay + "!" + vbNewLine
            End If

            sqlSysDBRead.getTables(dsSysDBRead, SysDB.sqlSysDB.eTypSelColumns.likeTableName, "" + rStayToCopy.IDApplication.Trim() + "_")
            For Each rSysTable As qs2.core.SysDB.dsSysDB.TablesCatalogRow In dsSysDBRead.TablesCatalog
                sWhereFields = ""
                dsSysDBRead.COLUMNS.Clear()
                sqlSysDBRead.getSysColumns(rSysTable.TABLE_NAME.TrimEnd(), dsSysDBRead, SysDB.sqlSysDB.eTypSelColumns.table)
                For Each rColSys As qs2.core.SysDB.dsSysDB.COLUMNSRow In dsSysDBRead.COLUMNS
                    sWhereFields += IIf(sWhereFields.Trim() = "", " ", ", ") + rColSys.COLUMN_NAME.Trim()
                Next

                dt_Quelle = New DataTable()
                da_Quelle = New System.Data.SqlClient.SqlDataAdapter()
                cmd_Quelle = New System.Data.SqlClient.SqlCommand()
                cmd_Quelle.Connection = qs2.core.dbBase.dbConn
                cmd_Quelle.CommandTimeout = 0
                cmd_Quelle.CommandText = " Select " + sWhereFields + " from qs2." + rSysTable.TABLE_NAME.Trim() + " where " + sWhereProductStaysxy
                da_Quelle.SelectCommand = cmd_Quelle
                da_Quelle.Fill(dt_Quelle)
                If dt_Quelle.Rows.Count <> 1 Then
                    protocol += "Exception " + rSysTable.TABLE_NAME.Trim() + ": dt_Quelle.Rows.Count<>1 for MedRecNr " + sInfoStay + "!" + vbNewLine
                End If

                dt_Ziel = New DataTable()
                da_Ziel = New System.Data.SqlClient.SqlDataAdapter()
                cmd_Ziel = New System.Data.SqlClient.SqlCommand()
                cmd_Ziel.Connection = connZiel
                cmd_Ziel.CommandTimeout = 0
                da_Ziel.SelectCommand = cmd_Ziel
                cmd_Ziel.CommandText = cmd_Quelle.CommandText
                da_Ziel.Fill(dt_Ziel)
                If dt_Ziel.Rows.Count = 0 Then
                    Dim rToCopy As DataRow = dt_Quelle.Rows(0)
                    Dim rNew As DataRow = dt_Ziel.NewRow()
                    rNew.ItemArray = rToCopy.ItemArray
                    dt_Ziel.Rows.Add(rNew)
                    dt_Ziel.AcceptChanges()
                    rNew.SetAdded()

                    Dim builder As New SqlCommandBuilder(da_Ziel)
                    builder.GetUpdateCommand()
                    da_Ziel.Update(dt_Ziel)
                    iCounterProductStaysAdded += 1

                ElseIf dt_Ziel.Rows.Count = 1 Then
                    Dim bAnyChanges As Boolean = False
                    Dim r_QuelleOrig As DataRow = dt_Quelle.Rows(0)
                    Dim r_ZielSave As DataRow = dt_Ziel.Rows(0)
                    For Each col As DataColumn In dt_Ziel.Columns
                        If Not r_ZielSave(col.ColumnName).Equals(r_QuelleOrig(col.ColumnName)) Then
                            r_ZielSave(col.ColumnName) = r_QuelleOrig(col.ColumnName)
                            bAnyChanges = True
                        End If
                    Next
                    If bAnyChanges Then
                        Dim builder As New SqlCommandBuilder(da_Ziel)
                        builder.GetUpdateCommand()
                        da_Ziel.Update(dt_Ziel)
                    End If
                    iCounterProductStaysAdded += 1
                    'protocol += "Info Table: " + rSysTable.TABLE_NAME.Trim() + " -- MedRecNr " + sInfoStay + " already exists in Aim-DB" + vbNewLine

                ElseIf dt_Ziel.Rows.Count > 1 Then
                    protocol += "Exception Table:" + rSysTable.TABLE_NAME.Trim() + " -- MedRecNr " + sInfoStay + " already  more than one in Aim-DB!" + sInfoStay + "!" + vbNewLine
                End If
            Next

            If protocol.Trim() <> "" Then
                protocol += vbNewLine
            End If
            If bStayAdded And iCounterProductStaysAdded > 0 Then
                iCounter += 1
                Dim txt As String = iCounter.ToString() + " Stays saved"
                txt = "(MedRecN: " + rStayToCopy.MedRecN.Trim() + ") " + txt
                Me.showStatusUI(txt)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.copyStaysToDB: " + ex.ToString())
        End Try
    End Function

    Public Sub showStatusUI(txt As String)
        Try
            If Not businessFramework.delStatusUI Is Nothing Then
                businessFramework.delStatusUI.Invoke(txt)
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.showStatusUI: " + ex.ToString())
        End Try
    End Sub

    Public Function getProductsForUser(IDGuidObject As System.Guid, db As qs2.db.Entities.ERModellQS2Entities) As IQueryable(Of qs2.db.Entities.tblObjectApplications)
        Try
            Dim tObjectApplications As IQueryable(Of qs2.db.Entities.tblObjectApplications) = From rObjectApplications In db.tblObjectApplications Where rObjectApplications.IDObjectGuid = IDGuidObject
            Return tObjectApplications

        Catch ex As Exception
            Throw New Exception("businessFramework.getProductsForUser: " + ex.ToString())
        End Try
    End Function

    Public Sub loadENVFromAdjustmentStayType(ByRef sStartTypeStayUIReturn As String)
        Try
            Dim oStartTypeStayUI As Object = actUsr.adjustRead("", sqlAdmin.eAdjust.StartTypeStayUI, sqlAdmin.eTypSelAdjust.all, "")
            If Not oStartTypeStayUI Is Nothing Then
                Dim sStartTypeStayUI As String = oStartTypeStayUI.ToString().Trim()
                If sStartTypeStayUI.Trim().ToLower().Trim().Equals(qs2.core.Enums.eStartTypeStayUI.Single.ToString().Trim().ToLower()) Then
                    qs2.core.ENV.StaysAsThread = False
                    qs2.core.ENV.StaysAsExternProcess2 = False
                ElseIf sStartTypeStayUI.Trim().ToLower().Trim().Equals(qs2.core.Enums.eStartTypeStayUI.Thread.ToString().Trim().ToLower()) Then
                    qs2.core.ENV.StaysAsThread = True
                    qs2.core.ENV.StaysAsExternProcess2 = False
                    Throw New Exception("loadENVFromAdjustmentStayType: s2.core.ENV.StaysAsThread = True not allowed!")
                ElseIf sStartTypeStayUI.Trim().ToLower().Trim().Equals(qs2.core.Enums.eStartTypeStayUI.Process.ToString().Trim().ToLower()) Then
                    qs2.core.ENV.StaysAsThread = False
                    qs2.core.ENV.StaysAsExternProcess2 = True
                Else
                    Throw New Exception("loadENVFromAdjustment: sStartTypeStayUI '" + sStartTypeStayUI.Trim() + "' not allowed!")
                End If
                sStartTypeStayUIReturn = sStartTypeStayUI.Trim()
            Else
                actUsr.adjustSave("", sqlAdmin.eAdjust.StartTypeStayUI, sqlAdmin.eTypSelAdjust.all, qs2.core.Enums.eStartTypeStayUI.Process.ToString().Trim())
                qs2.core.ENV.StaysAsThread = False
                qs2.core.ENV.StaysAsExternProcess2 = True
                sStartTypeStayUIReturn = qs2.core.Enums.eStartTypeStayUI.Process.ToString().Trim()
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.loadENVFromAdjustmentStayType: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadENVFromAdjustment(ByRef tControlOpenStayType As Integer,
                                     ByRef tControlOpenStayTypeRoles As String, loadDefaultFromENV As Boolean,
                                     ByRef sStartTypeStayUIReturn As String)
        Try
            Me.loadENVFromAdjustmentStayType(sStartTypeStayUIReturn)

            Dim oControlOpenStayType As Object = actUsr.adjustRead("", sqlAdmin.eAdjust.ControlOpenStayType, sqlAdmin.eTypSelAdjust.all, "")
            If Not oControlOpenStayType Is Nothing Then
                tControlOpenStayType = System.Convert.ToInt32(oControlOpenStayType.ToString().Trim())
            Else
                If loadDefaultFromENV Then
                    tControlOpenStayType = qs2.core.ENV.ControlOpenStayType
                End If
            End If

            Dim oControlOpenStayTypeRoles As Object = actUsr.adjustRead("", sqlAdmin.eAdjust.ControlOpenStayTypeRoles, sqlAdmin.eTypSelAdjust.all, "")
            If Not oControlOpenStayTypeRoles Is Nothing Then
                tControlOpenStayTypeRoles = oControlOpenStayTypeRoles.ToString().Trim()
            Else
                If loadDefaultFromENV Then
                    tControlOpenStayTypeRoles = qs2.core.ENV.ControlOpenStayTypeRoles
                End If
            End If

            Me.loadENVFromAdjustmentGrid(tControlOpenStayType, tControlOpenStayTypeRoles, loadDefaultFromENV, sStartTypeStayUIReturn)

        Catch ex As Exception
            Throw New Exception("businessFramework.loadENVFromAdjustment: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadENVFromAdjustmentGrid(ByRef tControlOpenStayType As Integer,
                                            ByRef tControlOpenStayTypeRoles As String, loadDefaultFromENV As Boolean,
                                            ByRef sStartTypeStayUIReturn As String)
        Try
            Dim dsHelper1 As New dsHelper()
            Dim sqlHelper1 As New sqlHelper()
            sqlHelper1.initControl()

            Dim dsAdminRead As New dsAdmin()
            Dim sqlAdminRead As New sqlAdmin()
            sqlAdminRead.initControl()

            sqlAdminRead.getAdjust("", sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant, dsAdminRead, sqlAdmin.eTypSelAdjust.allGrid, "")
            'sqlAdminRead.getAdjust("", sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant, dsAdminRead, sqlAdmin.eTypSelAdjust.allGrid, "")
            For Each rAdjust As dsAdmin.tblAdjustRow In dsAdminRead.tblAdjust
                Dim lstVars As System.Collections.Generic.List(Of String) = qs2.core.generic.getVarsBy(rAdjust.str.Trim(), "_")
                Dim IDParticipant As String = lstVars(0).Trim()
                Dim sValue As String = lstVars(1).Trim()
                Dim IDGuid As System.Guid = New Guid(lstVars(2).Trim())
                Dim Product As String = ""
                If lstVars.Count > 3 Then
                    Product = lstVars(3).Trim()
                End If

                If (IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()) And Product.Trim() = "") Or
                    (IDParticipant.Trim().ToLower().Equals(qs2.core.license.doLicense.rParticipant.IDParticipant.Trim().ToLower()) And
                     Product.Trim().ToLower() = qs2.core.license.doLicense.rApplication.IDApplication.Trim().ToLower()) Then

                    If rAdjust.setting.Trim().ToLower().Equals(sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant.ToString().Trim().ToLower()) Then
                        tControlOpenStayType = System.Convert.ToInt32(sValue.Trim())
                    ElseIf rAdjust.setting.Trim().ToLower().Equals(sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant.ToString().Trim().ToLower()) Then
                        tControlOpenStayTypeRoles = sValue.Trim()
                    ElseIf rAdjust.setting.Trim().ToLower().Equals(sqlAdmin.eAdjust.UploadPrintAllChapters.ToString().Trim().ToLower()) Then
                        If sValue.Trim() = "1" Then
                            ENV.UploadPrintAllChapters = True
                        ElseIf sValue.Trim() = "0" Then
                            ENV.UploadPrintAllChapters = False
                        Else
                            Throw New Exception("loadENVFromAdjustmentGrid: sValue '" + sValue.Trim() + "' for UploadPrintAllChapters not allowed!")
                        End If
                    Else
                        Throw New Exception("loadENVFromAdjustmentGrid: rAdjust.Variable '" + rAdjust.setting.Trim() + "' not allowed!")
                    End If

                End If
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.loadENVFromAdjustmentGrid: " + ex.ToString())
        End Try
    End Sub

    Public Function checkSelListIsUsedInStays(IDSelList As Integer, ByRef sProt As String) As Boolean
        Try
            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim tSelListEntries As IQueryable(Of qs2.db.Entities.tblSelListEntries) = Nothing
                tSelListEntries = From rSelListEntries In db.tblSelListEntries Where rSelListEntries.ID = IDSelList
                If tSelListEntries.Count <> 1 Then
                    Throw New Exception("checkSelListIsUsedInStays: IDSelList '" + IDSelList.ToString() + "' not exists in DB!")
                End If
                Dim rSelList As qs2.db.Entities.tblSelListEntries = tSelListEntries.First()

                Dim tSelListGroup As IQueryable(Of qs2.db.Entities.tblSelListGroup) = Nothing
                tSelListGroup = From rSelListGroup In db.tblSelListGroup Where rSelListGroup.ID = rSelList.IDGroup
                If tSelListGroup.Count <> 1 Then
                    Throw New Exception("checkSelListIsUsedInStays: rSelList.IDGroup '" + rSelList.IDGroup.ToString() + "' not exists in DB!")
                End If
                Dim rSelListGrp As qs2.db.Entities.tblSelListGroup = tSelListGroup.First()

                Dim bIsUsedInStays As Boolean = Me.checkSelListIsUsedInStays(rSelList.IDOwnInt, db, rSelListGrp.IDGroupStr.Trim(), rSelListGrp.IDApplication.Trim(), False, sProt, rSelList.IDRessource.Trim())
                Dim bIsUsedInStaysAlias As Boolean = Me.checkSelListIsUsedInStays(rSelList.IDOwnInt, db, rSelListGrp.IDGroupStr.Trim(), rSelListGrp.IDApplication.Trim(), True, sProt, rSelList.IDRessource.Trim())
                Return bIsUsedInStays Or bIsUsedInStaysAlias
            End With

            Return False

        Catch ex As Exception
            Throw New Exception("businessFramework.checkSelListisusedInStays: " + ex.ToString())
        End Try
    End Function
    Public Function checkSelListIsUsedInStays(IDOwnInt As Integer, db As qs2.db.Entities.ERModellQS2Entities,
                                               FldShort As String, IDApplication As String, checkAlias As Boolean,
                                               ByRef sProt As String, ByRef IDResSelList As String) As Boolean
        Try
            Dim tCriteria As IQueryable(Of qs2.db.Entities.tblCriteria) = Nothing
            If checkAlias Then
                tCriteria = From rCriteria In db.tblCriteria Where rCriteria.AliasFldShort = FldShort And rCriteria.IDApplication = IDApplication
            Else
                tCriteria = From rCriteria In db.tblCriteria Where rCriteria.FldShort = FldShort And rCriteria.IDApplication = IDApplication
            End If
            If tCriteria.Count > 1 Then
                Throw New Exception("checkSelListIsUsedInStays: tSelListEntries.Count>1 for FldShort '" + FldShort.Trim() + "' and IDApplication '" + IDApplication.Trim() + "'!")
            ElseIf tCriteria.Count = 1 Then
                Dim rCrit As qs2.db.Entities.tblCriteria = tCriteria.First()
                If Not rCrit.ControlType.Trim().ToLower().Equals(core.Enums.eControlType.ComboBox.ToString().Trim().ToLower()) Then
                    Throw New Exception("checkSelListIsUsedInStays: rCrit.ControlType<>ComboBox for FldShort='" + rCrit.FldShort.Trim() + "' and IDApplication='" + rCrit.IDApplication.Trim() + "'")
                End If

                Dim b1 As New qs2.core.db.ERSystem.businessFramework()
                Dim b As New businessFramework()
                Dim dt As New DataTable()
                Dim da As New SqlClient.SqlDataAdapter()
                Dim cmd As New SqlClient.SqlCommand()
                cmd.CommandTimeout = 0
                cmd.CommandText = " select ID, IDParticipant, IDApplication, " + rCrit.FldShort.Trim() + " from qs2." + rCrit.SourceTable.Trim() + " where " + rCrit.FldShort.Trim() + "=" + IDOwnInt.ToString() + ""
                cmd.Connection = qs2.core.dbBase.dbConn
                da.SelectCommand = cmd
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    Dim sFieldTranslated As String = qs2.core.language.sqlLanguage.getRes(IDResSelList.Trim())
                    If sFieldTranslated.Trim() = "" Then
                        sFieldTranslated = rCrit.FldShort.Trim()
                    End If

                    Dim sInfoStay As String = ""
                    For Each rStayProductTable As DataRow In dt.Rows
                        Dim rStay As tblStay = b1.getStay(rStayProductTable("ID"), rStayProductTable("IDParticipant"), rStayProductTable("IDApplication"), db)
                        sInfoStay = " (MedRecN: " + rStay.MedRecN.Trim() + ", IDStay: " + rStay.ID.ToString().Trim() + ", IDApplication: " + rStay.IDApplication.Trim() + ")"
                    Next

                    sProt += sFieldTranslated.Trim() + sInfoStay + vbNewLine + vbNewLine
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.checkSelListIsUsedInStays: " + ex.ToString())
        End Try
    End Function

    Public Function checkColumnComboBoxExistsSelListRelation(FldShortToCkeck As String, Application As String,
                                                               ByRef arrRelationship() As dsAdmin.tblRelationshipRow, ByRef FldShortParentReturn As String) As Boolean
        Try
            Dim sWhere As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.FldShortChildColumn.ColumnName + "='" + FldShortToCkeck.Trim() + "' and " +
                                    " (" + qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.IDApplicationChildColumn.ColumnName + "='" + qs2.core.license.doLicense.eApp.ALL.ToString().Trim() + "' or " +
                                    "" + qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.IDApplicationChildColumn.ColumnName + "='" + Application.Trim() + "') and " +
                                    qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.TypeSubColumn.ColumnName + "='SelList'"

            arrRelationship = qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.Select(sWhere, "")
            If arrRelationship.Length > 0 Then
                Dim sLastFldShortParent As String = ""
                For Each rRel As qs2.core.vb.dsAdmin.tblRelationshipRow In arrRelationship
                    If sLastFldShortParent.Trim() <> "" And (Not rRel.FldShortParent.Trim().ToLower().Equals(sLastFldShortParent.Trim().ToLower())) Then
                        Throw New Exception("checkColumnComboBoxExistsSelListRelation: rRel.FldShortParent.Trim().ToLower().Equals(sLastFldShortParent.Trim().ToLower()) not the same for FldShortChild '" + FldShortToCkeck.Trim() + "'!")
                    End If
                    sLastFldShortParent = rRel.FldShortParent.Trim()
                Next
                FldShortParentReturn = sLastFldShortParent.Trim()
                Return True
            Else
                Return False
            End If


        Catch ex As Exception
            Throw New Exception("businessFramework.checkColumnComboBoxExistsSelListRelation: " + ex.ToString())
        End Try
    End Function
    Public Function cetTranslationForColumnComboBoxExistsSelListRelation(FldShortToCkeck As String, FldShortParent As String, Application As String) As Boolean
        Try
            Dim sWhere As String = qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.IDKeyColumn.ColumnName + "='" + FldShortToCkeck.Trim() + "' and " +
                                    qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.TypeSubColumn.ColumnName + "='SubList'"

            Dim arrRelationship() As dsAdmin.tblRelationshipRow = qs2.core.vb.sqlAdmin.dsAllAdmin.tblRelationship.Select(sWhere, "")
            If arrRelationship.Length > 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.cetTranslationForColumnComboBoxExistsSelListRelation: " + ex.ToString())
        End Try
    End Function

    Public Function buildSqlCheckedUncheckedRole(ByRef bOn As Boolean, ByRef FldShort As String, ByRef Application As String,
                                                    ByRef IDSelListEntry As Integer, ByRef typIDGroup As String, ByRef Role As String,
                                                    ByRef rCriteriaSel As dsAdmin.tblCriteriaRow) As Boolean
        Try
            Dim SqlResult As String = ""
            Dim FldShortTmp As String = "'" + FldShort.Trim() + "'"
            Dim ApplicationTmp As String = "'" + Application.Trim() + "'"

            Dim bOK As Boolean = Me.getSqlCmdSelListEntriesObj(bOn, FldShortTmp, ApplicationTmp, "Null", IDSelListEntry, "Null", typIDGroup.Trim(), "", "",
                                                              qs2.core.license.doLicense.eApp.ALL.ToString(), True, SqlResult)
            If Not bOK Then
                Throw New Exception("buildSqlCheckedUncheckedRole: getSqlCmdSelListEntriesObj()=false not allowed!")
            End If

            Dim frmProt As New frmProtocol()
            frmProt.initControl()
            frmProt.Show()
            frmProt.Text = "Auto-gen Sql"
            frmProt.ContProtocol1.setText(SqlResult)

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.buildSqlCheckedUncheckedRole: " + ex.ToString())
        End Try
    End Function
    Public Function buildSqlCheckedUncheckedSelListObj(ByRef bOn As Boolean,
                                                        ByRef rSelList As dsAdmin.tblSelListEntriesRow,
                                                        ByRef Application As String, ByRef IDSelListMain As Integer,
                                                        ByRef typIDGroup As String) As Boolean
        Try
            Dim SqlResult As String = ""

            Dim bOK As Boolean = Me.getSqlCmdSelListEntriesObj(bOn, "Null", "Null", "Null", rSelList.ID, IDSelListMain.ToString(), typIDGroup.Trim(), "", "",
                                                              qs2.core.license.doLicense.eApp.ALL.ToString(), False, SqlResult)
            If Not bOK Then
                Throw New Exception("buildSqlCheckedUncheckedSelListObj: getSqlCmdSelListEntriesObj()=false not allowed!")
            End If

            Dim frmProt As New frmProtocol()
            frmProt.initControl()
            frmProt.Show()
            frmProt.Text = "Auto-gen Sql"
            frmProt.ContProtocol1.setText(SqlResult)

            'SqlUpdateUserRights += " and (" + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "Criterias_Roles" + "' and " +
            '                        " " + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "Right" + "' and " +
            '                        " " + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "ProcGrp0" + "' and " +
            '                        " " + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "ProcGrp1" + "' and " +
            '                        " " + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "Chapters0" + "' and " +
            '                        " " + dsDevDB.tblSelListEntriesObj.typIDGroupColumn.ColumnName + "<>'" + "Chapters1" + "') ";

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.buildSqlCheckedUncheckedSelListObj: " + ex.ToString())
        End Try
    End Function

    Public Function getSqlCmdSelListEntriesObj(ByRef IsOn As Boolean, ByRef FldShortNull2 As String, ByRef IDApplicationNull2 As String, ByRef IDObjectNull As String,
                                               ByRef iIDSelListEntry As Integer, ByRef IDSelListEntrySublistNull As String,
                                               ByRef typIDGroup As String, ByRef IDClassification As String,
                                               ByRef Description As String, ByRef IDParticipant As String, ByRef IsCriteria As Boolean,
                                               ByRef SqlResult As String) As Boolean
        Try
            Dim IDStayNull As String = "Null"
            Dim IDParticipantStayNull As String = "Null"
            Dim IDApplicationStayNull As String = "Null"
            Dim IDOwnIntNull As String = "Null"
            Dim CreatedUsr As String = "Supervisor"
            Dim Sort As Integer = -1
            Dim IsMain As Integer = 0
            Dim Active As Integer = 0
            Dim IDObjectGuidNull As String = "Null"

            If typIDGroup.Trim() = "" Then
                Throw New Exception("getSqlCmdSelListEntriesObj: typIDGroup.Trim()='' not allowed")
            End If

            If IsCriteria Then
                If FldShortNull2.Trim() = "" Or FldShortNull2.Trim() = "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: FldShortNull.Trim()='' or 'Null' not allowed")
                End If
                If IDApplicationNull2.Trim() = "" Or IDApplicationNull2.Trim() = "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: IDApplicationNull.Trim()='' or 'Null' not allowed")
                End If
                If IDSelListEntrySublistNull.Trim() <> "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: IDSelListEntrySublistNull.Trim()<>'Null' not allowed")
                End If
            Else
                If FldShortNull2.Trim() <> "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: FldShortNull.Trim()<>'Null' not allowed")
                End If
                If IDApplicationNull2.Trim() <> "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: IDApplicationNull.Trim()<>'Null' not allowed")
                End If
                If IDSelListEntrySublistNull.Trim() = "Null" Then
                    Throw New Exception("getSqlCmdSelListEntriesObj: IDSelListEntrySublistNull.Trim()='Null' not allowed")
                End If
                Dim iIDSelListEntrySublistNull As Integer = System.Convert.ToInt32(IDSelListEntrySublistNull.Trim())
            End If

            Dim sInfoSql As String = ""
            Dim sOnOff As String = IIf(IsOn, "on", "off")
            If IsCriteria Then
                sInfoSql = "FldShort " + FldShortNull2.Replace("'", "").Trim() + " is " + sOnOff.Trim() + " for typIDGroup " + typIDGroup.Trim() + ""
            Else
                sInfoSql = "FldShort " + iIDSelListEntry.ToString() + " is " + sOnOff.Trim() + " for typIDGroup " + typIDGroup.Trim() + ""
            End If

            If IsOn Then
                Dim SqlExists As String = ""
                If IsCriteria Then
                    SqlExists = "If (SELECT COUNT(*) AS Found FROM qs2.tblSelListEntriesObj WHERE IDSelListEntry=" + iIDSelListEntry.ToString() + " And FldShort=" + FldShortNull2.Trim() + " AND IDApplication=" + IDApplicationNull2.Trim() + " AND " +
                                    "typIDGroup='" + typIDGroup.Trim() + "') = 0 " + vbNewLine +
                                    "BEGIN" + vbNewLine +
                                    "       ###" + vbNewLine +
                                    "       Print '" + sInfoSql.Trim() + "'" + vbNewLine +
                                    "End"
                Else
                    SqlExists = "If (SELECT COUNT(*) AS Found FROM qs2.tblSelListEntriesObj WHERE IDSelListEntry=" + iIDSelListEntry.ToString() + " And IDSelListEntrySublist=" + IDSelListEntrySublistNull.ToString() +
                                    "And typIDGroup='" + typIDGroup.Trim() + "') = 0 " + vbNewLine +
                                    "BEGIN" + vbNewLine +
                                    "       ###" + vbNewLine +
                                    "       Print '" + sInfoSql.Trim() + "'" + vbNewLine +
                                    "End"
                End If

                Dim SqlInsert As String = "INSERT  qs2.tblSelListEntriesObj " +
                                    "(IDGuid, " +
                                    "FldShort, " +
                                    "IDApplication, " +
                                    "IDObject, " +
                                    "IDSelListEntrySublist, " +
                                    "IDSelListEntry, " +
                                    "IDStay, " +
                                    "IDParticipantStay, " +
                                    "IDApplicationStay, " +
                                    "typIDGroup, " +
                                    "IDClassification, " +
                                    "IDOwnInt, " +
                                    "CreatedBy, " +
                                    "ModifiedBy, " +
                                    "Description, " +
                                    "Sort, " +
                                    "IsMain, " +
                                    "Active, " +
                                    "IDParticipant, " +
                                    "IDObjectGuid" +
                                    ") " +
                                    "VALUES(" +
                                    "'" + System.Guid.NewGuid().ToString() + "'," +
                                    "" + FldShortNull2.Trim() + "," +
                                    "" + IDApplicationNull2.Trim() + "," +
                                    "" + IDObjectNull.Trim() + "," +
                                    "" + IDSelListEntrySublistNull.Trim() + "," +
                                    "" + iIDSelListEntry.ToString() + "," +
                                    "" + IDStayNull.Trim() + "," +
                                    "" + IDParticipantStayNull.Trim() + "," +
                                    "" + IDApplicationStayNull.Trim() + "," +
                                    "'" + typIDGroup.Trim() + "'," +
                                    "'" + IDClassification.Trim() + "'," +
                                    "" + IDOwnIntNull.Trim() + "," +
                                    "'" + CreatedUsr.Trim() + "'," +
                                    "'" + CreatedUsr.Trim() + "'," +
                                    "'" + Description.Trim() + "'," +
                                    "" + Sort.ToString() + "," +
                                    "" + IsMain.ToString() + "," +
                                    "" + Active.ToString() + "," +
                                    "'" + IDParticipant.Trim() + "'," +
                                    "" + IDObjectGuidNull.Trim() + "" +
                                    ")"

                SqlExists = SqlExists.Replace("###", SqlInsert)
                SqlResult = SqlExists
                Return True
            Else
                Dim sqlDelete As String = ""
                If IsCriteria Then
                    sqlDelete = "DELETE FROM qs2.tblSelListEntriesObj WHERE IDSelListEntry=" + iIDSelListEntry.ToString() + " AND  FldShort=" + FldShortNull2.Trim() + " AND IDApplication=" + IDApplicationNull2.Trim() + " AND typIDGroup='" + typIDGroup.Trim() + "'" + vbNewLine +
                                "Print '" + sInfoSql.Trim() + "'"
                Else
                    sqlDelete = "DELETE FROM qs2.tblSelListEntriesObj WHERE IDSelListEntry=" + iIDSelListEntry.ToString() + " AND  IDSelListEntrySublist=" + IDSelListEntrySublistNull.Trim() + " AND typIDGroup='" + typIDGroup.Trim() + "'" + vbNewLine +
                                "Print '" + sInfoSql.Trim() + "'"
                End If

                SqlResult = sqlDelete
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.getSqlCmdSelListEntriesObj: " + ex.ToString())
        End Try
    End Function

    Public Function loadVarsSettings() As System.Collections.Generic.List(Of qs2.core.ENV.cVarsSettings)
        Try
            Dim lstSettings As New System.Collections.Generic.List(Of qs2.core.ENV.cVarsSettings)

            Dim c = New core.ENV.cVarsSettings()
            c.VarDef = sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant.ToString()
            c.VarDescription = sqlAdmin.eAdjust.ControlOpenStayTypeIDParticipant.ToString()
            c.defaultValue = "0"
            c.TypeSetting = qs2.core.ENV.eTypeSetting.tInt
            lstSettings.Add(c)

            c = New core.ENV.cVarsSettings()
            c.VarDef = sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant.ToString()
            c.VarDescription = sqlAdmin.eAdjust.ControlOpenStayTypeRolesIDParticipant.ToString()
            c.defaultValue = "0"
            c.TypeSetting = qs2.core.ENV.eTypeSetting.tInt
            lstSettings.Add(c)

            c = New core.ENV.cVarsSettings()
            c.VarDef = sqlAdmin.eAdjust.UploadPrintAllChapters.ToString()
            c.VarDescription = sqlAdmin.eAdjust.UploadPrintAllChapters.ToString()
            c.defaultValue = "0"
            c.TypeSetting = qs2.core.ENV.eTypeSetting.tInt
            lstSettings.Add(c)

            Return lstSettings

        Catch ex As Exception
            Throw New Exception("businessFramework.loadVarsSettings: " + ex.ToString())
        End Try
    End Function


    Public Sub loadAllCriteriasObjectFields(ByRef IDApplicationSel As String, ByRef DsHelper1 As dsHelper, ByRef DsAdmin1 As dsAdmin,
                                            ByRef SqlAdmin1 As sqlAdmin)
        Try
            Dim rNewCriteriaSmall As dsHelper.CriteriasSmallRow = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "LastName", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "FirstName", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "DOB", Enums.eControlType.Date, "", "Null")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "Gender", Enums.eControlType.ComboBox, "Gender", "0")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "Title", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "Street", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "CountryID", Enums.eControlType.ComboBox, "CountryID", "-1")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "ZIP", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "City", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "PhonePrivat", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "PhoneMobil", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "Email", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "MtStat", Enums.eControlType.ComboBox, "MtStat", "-1")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "MtDate", Enums.eControlType.Date, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "MtCause", Enums.eControlType.ComboBox, "MtCause", "-1")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "MTLocatn", Enums.eControlType.ComboBox, "MTLocatn", "-1")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "SSN", Enums.eControlType.Textfield, "", "")

            rNewCriteriaSmall = SqlAdmin1.addRowCriteriaSmall(DsHelper1)
            Me.loadAllCriteriasObjectField(rNewCriteriaSmall, "ICD9", Enums.eControlType.Textfield, "", "")

        Catch ex As Exception
            Throw New Exception("businessFramework.loadAllCriteriasObjectFields: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadAllCriteriasObjectField(ByRef rNewCriteriaSmall As dsHelper.CriteriasSmallRow, ByRef FldShort As String, ByRef ControlType As Enums.eControlType,
                                           ByRef SelList As String, ByRef DefaultValue As String)
        Try
            Dim FldShortTranslated As String = qs2.core.language.sqlLanguage.getRes(FldShort.Trim(), qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "All")

            rNewCriteriaSmall.FldShort = FldShort.Trim()
            If FldShortTranslated.Trim() <> "" Then
                rNewCriteriaSmall.Field = FldShortTranslated.Trim()
            Else
                rNewCriteriaSmall.Field = rNewCriteriaSmall.FldShort.Trim()
            End If

            Dim ControlTypeTranslated As String = qs2.core.language.sqlLanguage.getRes(ControlType.ToString().Trim(), qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), "ALL")
            If ControlTypeTranslated.Trim() <> "" Then
                rNewCriteriaSmall.ControlType = ControlTypeTranslated.Trim()
            Else
                rNewCriteriaSmall.ControlType = ControlType.ToString().Trim()
            End If

            rNewCriteriaSmall.Editable = True
            rNewCriteriaSmall.FUP = False
            rNewCriteriaSmall.Chapter = "No chapter"
            rNewCriteriaSmall.Application = "ALL"
            rNewCriteriaSmall.DefaultValue = DefaultValue.Trim()
            'rNewCriteriaSmall.MinVal = rCriteria.ControlMinVal.Trim()
            'rNewCriteriaSmall.MaxVal = rCriteria.ControlMaxVal.Trim()
            'rNewCriteriaSmall.MinLength = rCriteria.ControlMinLength
            'rNewCriteriaSmall.MaxLength = rCriteria.ControlMaxLength

        Catch ex As Exception
            Throw New Exception("businessFramework.loadAllCriteriasObjectField: " + ex.ToString())
        End Try
    End Sub

    Public Sub addSelListEntriesFromRelationsships(ByRef rSelListParent As dsAdmin.tblSelListEntriesRow, ByRef rSelListGrp As dsAdmin.tblSelListGroupRow,
                                                   ByRef rCriteria As dsAdmin.tblCriteriaRow, ByRef IDApplicationSel As String,
                                                   ByRef rNewSelListSmallParent As dsHelper.SelListSmallRow, ByRef dsHelper1 As dsHelper,
                                                   ByRef SqlAdmin1 As sqlAdmin, ByRef dsAdminTmp As dsAdmin)
        Try
            Dim sWhereRelationsshipSelLists As String = "" + sqlAdmin.dsAllAdmin.tblRelationship.TypeSubColumn.ColumnName + "='SelList' and " +
                                                        " " + sqlAdmin.dsAllAdmin.tblRelationship.FldShortParentColumn.ColumnName + "='" + rCriteria.FldShort.Trim() + "' and " +
                                                        " " + sqlAdmin.dsAllAdmin.tblRelationship.IDApplicationParentColumn.ColumnName + "='" + rCriteria.IDApplication.Trim() + "' "
            Dim arrRelationsshipSelLists As dsAdmin.tblRelationshipRow() = sqlAdmin.dsAllAdmin.tblRelationship.Select(sWhereRelationsshipSelLists, "")

            For Each rRel As dsAdmin.tblRelationshipRow In arrRelationsshipSelLists
                Dim lstVarIDOwnIntSelList As New System.Collections.Generic.List(Of String)
                lstVarIDOwnIntSelList = qs2.core.generic.readStrVariables(rRel.Conditions.Trim())
                For Each sIDOwnIntSelList As String In lstVarIDOwnIntSelList
                    Dim iIDOnwIntParentSelList As Integer = System.Convert.ToInt32(sIDOwnIntSelList.Trim())
                    If rSelListParent.IDOwnInt.Equals(iIDOnwIntParentSelList) Then
                        dsAdminTmp.Clear()
                        Dim arrGp As dsAdmin.tblSelListGroupRow() = SqlAdmin1.getSelListGroup(dsAdminTmp, sqlAdmin.eTypSelGruppen.IDGruppeRam, rRel.IDKey.Trim(), "ALL", IDApplicationSel.Trim())
                        Dim sWhereSelList As String = "" + sqlAdmin.dsAllAdmin.tblSelListEntries.IDGroupColumn.ColumnName + "=" + arrGp(0).ID.ToString() + ""
                        Dim arrSelLists As dsAdmin.tblSelListEntriesRow() = sqlAdmin.dsAllAdmin.tblSelListEntries.Select(sWhereSelList, sqlAdmin.dsAllAdmin.tblSelListEntries.IDOwnIntColumn.ColumnName + " asc")
                        For Each rSelList As dsAdmin.tblSelListEntriesRow In arrSelLists
                            Dim rNewSelListSmall1 As dsHelper.SelListSmall1Row = SqlAdmin1.addRowSelListSmall1(dsHelper1)
                            rNewSelListSmall1.IDOwnInt = rSelList.IDOwnInt
                            rNewSelListSmall1.IDOwnStr = rSelList.IDOwnStr.Trim()
                            Dim SelListTranslated As String = qs2.core.language.sqlLanguage.getRes(rSelList.IDRessource.Trim(), qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), IDApplicationSel.Trim())
                            If SelListTranslated.Trim() <> "" Then
                                rNewSelListSmall1.SelList = SelListTranslated.Trim()
                            Else
                                rNewSelListSmall1.SelList = rSelList.IDRessource.Trim()
                            End If
                            rNewSelListSmall1.IDSelList = rSelList.ID
                            rNewSelListSmall1.IDGroupStr = rSelListGrp.IDGroupStr.Trim()
                            rNewSelListSmall1.Application = arrGp(0).IDApplication.Trim()
                            rNewSelListSmall1.IDOwnIntParent = iIDOnwIntParentSelList
                            rNewSelListSmall1.IDSelListParent = rSelListParent.ID
                        Next
                    End If
                Next
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.addSelListEntriesFromRelationsships: " + ex.ToString())
        End Try
    End Sub





    ' 2018
    Public Function getIDSelListAllProcButtons(IDApplication As String, ByRef lstIDsProcGrpButtons As System.Collections.Generic.List(Of Integer)) As IEnumerable(Of dsAdmin.tblSelListEntriesRow)
        Try
            'Dim tRightProcGrpButtons = From g In sqlAdmin.dsAllAdmin.tblSelListGroup
            '                           Join s In sqlAdmin.dsAllAdmin.tblSelListEntries On g.ID Equals s.IDGroup Where
            '                            (g.IDGroupStr = "ProcGrp0" Or g.IDGroupStr = "ProcGrp1") And g.IDApplication = IDApplication
            '                           Select New With {.id =s.ID}

            Dim tRightProcGrpButtons As IEnumerable(Of dsAdmin.tblSelListEntriesRow) = From g In sqlAdmin.dsAllAdmin.tblSelListGroup
                                                                                       Join s In sqlAdmin.dsAllAdmin.tblSelListEntries On g.ID Equals s.IDGroup Where
                                                                                        (g.IDGroupStr = "ProcGrp0" Or g.IDGroupStr = "ProcGrp1") And g.IDApplication = IDApplication
                                                                                       Select s

            For Each b As dsAdmin.tblSelListEntriesRow In tRightProcGrpButtons
                lstIDsProcGrpButtons.Add(b.ID)
            Next
            Return tRightProcGrpButtons

        Catch ex As Exception
            Throw New Exception("businessFramework.getIDSelListAllProcButtons: " + ex.ToString())
        End Try
    End Function

    Public Function saveMedRecNInMedArchive(ByRef sProt As String, ByRef iUpdated As Integer, db As qs2.db.Entities.ERModellQS2Entities) As Boolean
        Try
            Dim lstMedArchiveCheck As New System.Collections.Generic.List(Of qs2.db.Entities.tblMedArchiv)()
            Dim tMedArchiv As IQueryable(Of qs2.db.Entities.tblMedArchiv) = From rMedArchiv In db.tblMedArchiv Where rMedArchiv.DocumentInfo_HL7 <> "" And rMedArchiv.IDParticipant = "91130" Order By rMedArchiv.Created Descending
            For Each rMedArchiv As qs2.db.Entities.tblMedArchiv In tMedArchiv
                lstMedArchiveCheck.Add(rMedArchiv)
            Next

            For Each rMedArchiv As qs2.db.Entities.tblMedArchiv In lstMedArchiveCheck
                If Not rMedArchiv.IDStayGuid Is Nothing Then
                    Dim tStay As IQueryable(Of qs2.db.Entities.tblStay) = From rtblStay In db.tblStay Where rtblStay.IDGuid = rMedArchiv.IDStayGuid
                    If tStay.Count() = 1 Then
                        Dim rStay As qs2.db.Entities.tblStay = tStay.First()
                        If rStay.MedRecN.Trim().Length <> 8 Then
                            sProt += "Warning: Length MedRecNr <> 8 for " + rStay.MedRecN.Trim() + "" + vbNewLine + vbNewLine
                        Else
                            Dim iPosStart As Integer = rMedArchiv.DocumentInfo_HL7.IndexOf("<AID><IDKey>")
                            If iPosStart <> -1 Then
                                Dim iPosEnd As Integer = rMedArchiv.DocumentInfo_HL7.IndexOf("</IDKey>", iPosStart)
                                If iPosEnd <> -1 Then
                                    Dim iPosStartSpace4 As Integer = rMedArchiv.DocumentInfo_HL7.IndexOf("    ", iPosStart)
                                    If iPosStartSpace4 <> -1 Then
                                        If iPosStartSpace4 >= (iPosStart + 12) And iPosStartSpace4 < iPosEnd Then
                                            Dim sSubStrToReplace As String = rMedArchiv.DocumentInfo_HL7.Substring(iPosStart, (iPosEnd + 8) - iPosStart)
                                            Dim sSubStrTmp As String = rMedArchiv.DocumentInfo_HL7.Substring(iPosStart + 12, iPosStartSpace4 - (iPosStart + 12))
                                            If (sSubStrTmp.Trim() = "91639998") Then
                                                Dim sSubStrNew As String = "<AID><IDKey>" + sSubStrTmp + "    " + rStay.MedRecN.Trim() + "</IDKey>"

                                                If Not (sSubStrToReplace.Trim().Equals(sSubStrNew.Trim())) Then
                                                    rMedArchiv.DocumentInfo_HL7 = rMedArchiv.DocumentInfo_HL7.Replace(sSubStrToReplace, sSubStrNew)
                                                    db.SaveChanges()

                                                    Dim sInfoCreated As String = ""
                                                    If Not rMedArchiv.Created Is Nothing Then
                                                        sInfoCreated = rMedArchiv.Created.ToString()
                                                    End If
                                                    sProt += "Med. archive row for MedRecNr " + rStay.MedRecN.Trim() + " from " + sInfoCreated + " updated" + "" + vbNewLine + vbNewLine
                                                    iUpdated += 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.saveMedRecNInMedArchive: " + ex.ToString())
        End Try
    End Function


    Public Function checkShowUpdateNews(IDObject As Guid, db As qs2.db.Entities.ERModellQS2Entities) As Boolean
        Try
            Dim rObjectUpdate As qs2.db.Entities.tblObject = (From rObject In db.tblObject Where rObject.IDGuid = IDObject).First()
            Return rObjectUpdate.ShowUpdateNewsAtStartup

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.checkShowUpdateNews: " + ex.ToString())
        End Try
    End Function

    Public Sub updateNewsShowOnOff(bOn As Boolean, IDObject As Guid, ByRef db As qs2.db.Entities.ERModellQS2Entities)
        Try
            Dim rObjectUpdate As qs2.db.Entities.tblObject = (From rObject In db.tblObject Where rObject.IDGuid = IDObject).First()
            rObjectUpdate.ShowUpdateNewsAtStartup = bOn
            db.SaveChanges()

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.updateNewsShowOnOff: " + ex.ToString())
        End Try
    End Sub



    Public Function updateData1(RunUpdate As Boolean, NurESLog As Boolean, ByRef sProtSum As String, ByRef db As qs2.db.Entities.ERModellQS2Entities)
        Try

            Dim IDParticipant = qs2.core.license.doLicense.rParticipant.IDParticipant.ToString()

            Dim sqlStaysDemo2 As String = " SELECT qs2.tblStay.MedRecN, qs2.tblStay_CARDIAC_A_E.IsCongenital as A_E_IsCongenital FROM qs2.tblStay, qs2.tblStay_CARDIAC_A_E " +
                                            " where qs2.tblStay.ID=qs2.tblStay_CARDIAC_A_E.ID and qs2.tblStay.IDParticipant=qs2.tblStay_CARDIAC_A_E.IDParticipant and qs2.tblStay.IDApplication=qs2.tblStay_CARDIAC_A_E.IDApplication " +
                                            " "
            Dim tStaysDemo2 As List(Of objSel) = db.Database.SqlQuery(Of objSel)(sqlStaysDemo2).ToList()
            ' objSel entsprechend um die Felder im Select erweitern mit gleichem Namen, where Klausel nach Bedarf anpassen


            Dim iCounter As Integer = 0
            Dim lstUpdates As New List(Of objSel)
            Dim lstUpdatesESrelevant As New List(Of objSel)
            Dim lstValvesMoved As New List(Of objSel)
            Dim sb As New System.Text.StringBuilder


            sb.Append("Protokoll für Herbstupdate 2018 vom " + DateTime.Now.ToString() + vbNewLine + vbNewLine)

            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("1. Aktion Ao-Prozedur 'Resektion Sub-Aorten-Stenose': Zu Ao-Prozedur 'Ersatz' konvertieren und 'Subvalvuläre Myektomie (HOCM)' aktiv setzen." + vbNewLine)
            sb.Append("   Bedingungen: Int. Klappenprozedur: Ao-Prozedur = 'Resektion Sub-Aorten-Stenose'" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate1 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_M_N2 In db.tblStay_CARDIAC_M_N2 On s.ID Equals s_M_N2.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_IC_L.OpValve = 1 And s_IC_L.OpAortic = 7 _
                                                    And s.IDParticipant = s_IC_L.IDParticipant _
                                                    And s.IDParticipant = s_M_N2.IDParticipant _
                                                    And o.IDParticipant = s.IDParticipant And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()

            If tUpdate1.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate1.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate1
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))
                    If (RunUpdate) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)

                        Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                        sb.Append("Konv. Klappen: Ao-Prozedur (" + s_IC_L.OpAortic.ToString() + " -> 2)" + vbNewLine)
                        s_IC_L.OpAortic = 2

                        Dim s_M_N2 As tblStay_CARDIAC_M_N2 = (From rS In db.tblStay_CARDIAC_M_N2 Where rS.ID = r.ID).First()
                        sb.Append("Subvalvuläre Myektomie (HOCM) (" + s_M_N2.Ausflusstraktresektion.ToString() + " -> 1)" + vbNewLine)
                        s_M_N2.Ausflusstraktresektion = 1

                        If s_M_N2.OpOCard <> 1 Then
                            sb.Append("Andere kardiale Eingriffe (" + s_M_N2.OpOCard.ToString() + " -> 1)" + vbNewLine)
                            s_M_N2.OpOCard = 1
                        End If
                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)

                        'Protokoll für das Update schreiben
                        'Dim Protocol_1 As New qs2.core.vb.Protocol()
                        'Protocol_1.save2(Protocol.eTypeProtocoll.UpdateData, Nothing, -999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), qs2.core.license.doLicense.rApplication.IDApplication.Trim(), "",
                        '"Update Herbst 2018", Protocol.eActionProtocol.None, "", "", sProtSum)
                    Else
                        sb.Append("Nur geprüft." + vbNewLine)
                    End If
                    db.SaveChanges()
                Next
                tUpdate1 = Nothing
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("2. Aktion ADP-Hemmer Med.: ADP Hemmer Med auf unbekannt setzen." + vbNewLine)
            sb.Append("   Bedingungen: 'ADP-Hemmer' = angehakt und 'ADP Hemmer Med' = undefiniert" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate2 As List(Of objSel) = (From s In db.tblStay
                                               Join s_F_I In db.tblStay_CARDIAC_F_I On s.ID Equals s_F_I.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_F_I.MedADPI = 1 And s_F_I.MedADPITyp = -1 _
                                                    And s.IDParticipant = s_F_I.IDParticipant _
                                                    And o.IDParticipant = s.IDParticipant And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()


            If tUpdate2.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate2.Count.ToString() + ")" + vbNewLine)
                If NurESLog Then
                    sb.Append("Detailliertes Protokoll durch den Benutzer deaktiviert." + vbNewLine)
                    For Each r As objSel In tUpdate2
                        iCounter += 1
                        If (RunUpdate) Then
                            Dim s_F_I As tblStay_CARDIAC_F_I = (From rS In db.tblStay_CARDIAC_F_I Where rS.ID = r.ID).First()
                            s_F_I.MedADPITyp = 888
                        End If
                    Next
                    db.SaveChanges()
                Else
                    For Each r As objSel In tUpdate2
                        iCounter += 1
                        sb.Append(getHeaderZeile(r, iCounter))
                        If (RunUpdate) Then
                            sb.Append("DURCHGEFÜHRT." + vbNewLine)
                            Dim s_F_I As tblStay_CARDIAC_F_I = (From rS In db.tblStay_CARDIAC_F_I Where rS.ID = r.ID).First()
                            sb.Append("ADP Hemmer Med (" + s_F_I.MedADPITyp.ToString() + " -> 888)" + vbNewLine)
                            s_F_I.MedADPITyp = 888
                            lstUpdates.Add(r)
                        Else
                            sb.Append("Nur geprüft." + vbNewLine)
                        End If
                    Next
                    db.SaveChanges()
                End If
                tUpdate2 = Nothing
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("3. Implantation TAVI: Verschieben auf Prozedurengruppe Klappen interventionell" + vbNewLine)
            sb.Append("Bedingungen: 'TAVI  (Klappen intervenionell) ist gewählt, Ao-Procedure = Implantation TAVI, Ao-Erweiterungsplastik = nein, Implantat ist in der neuen Liste verfügbar." + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate3 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_TAVI In db.tblStay_CARDIAC_TAVI On s.ID Equals s_TAVI.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_TAVI.OpTAVI = 1 And s_IC_L.OpAortic = 11 And s_IC_L.OpAortic_Int = -1 And s_IC_L.AnlrEnl <> 1 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()

            If tUpdate3.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate3.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate3
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))

                    Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                    Dim bCheckAnlrEn As Boolean = s_IC_L.AnlrEnl <> 1       'Erweiterungsplastik darf nicht gesetzt sein

                    Dim lValve As tblSelListEntries = Nothing
                    Dim bCheckValve As Boolean = False
                    Dim i As Integer = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).Count()
                    If i = 1 Then
                        lValve = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).First() 'Klappe muss in der neuen Liste enthalten sein
                        bCheckValve = True
                    End If

                    If Not bCheckValve Then
                        sb.Append("Kein Update möglich. Klappe " + s_IC_L.VSAoIm.ToString() + " nicht in neuer Liste vorhanden. " + vbNewLine)
                    End If

                    If Not bCheckAnlrEn Then
                        sb.Append("Kein Update möglich. Erweiterungsplastik ist angehakt. " + vbNewLine)
                    End If

                    If (RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)

                        sb.Append("Int. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic_Int.ToString + " -> " + s_IC_L.OpAortic.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy_Int.ToString + " -> " + s_IC_L.VSAoImTy.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm_Int.ToString + " -> " + s_IC_L.VSAoIm.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz_Int.ToString() + " -> " + s_IC_L.VSAoImSz.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup_Int.ToString + " -> " + s_IC_L.VSAoImSzGroup.ToString + ")" + vbNewLine)

                        s_IC_L.OpAortic_Int = s_IC_L.OpAortic
                        s_IC_L.VSAoImTy_Int = s_IC_L.VSAoImTy
                        s_IC_L.VSAoIm_Int = s_IC_L.VSAoIm
                        s_IC_L.VSAoImSz_Int = s_IC_L.VSAoImSz
                        s_IC_L.VSAoImSzGroup_Int = s_IC_L.VSAoImSzGroup

                        sb.Append("Konv. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic.ToString + " -> 1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpAortic = -1
                        s_IC_L.VSAoImTy = -1
                        s_IC_L.VSAoIm = -1
                        s_IC_L.VSAoImSz = -1
                        s_IC_L.VSAoImSzGroup = 1

                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)
                        lstValvesMoved.Add(r)

                    ElseIf (Not RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("Nur geprüft, kein Update." + vbNewLine)
                    End If
                Next
                db.SaveChanges()
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)



            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("4. Ballonvalvuloplastie: Verschieben auf Prozedurengruppe Klappen interventionell" + vbNewLine)
            sb.Append("Bedingungen: 'TAVI  (Klappen intervenionell) ist gewählt, Ao-Procedure = Ballonvalvuloplastie, Ao-Erweiterungsplastik = nein, Implantat ist in der neuen Liste verfügbar." + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate4 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_TAVI In db.tblStay_CARDIAC_TAVI On s.ID Equals s_TAVI.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_TAVI.OpTAVI = 1 And s_IC_L.OpAortic = 12 And s_IC_L.OpAortic_Int = -1 And s_IC_L.AnlrEnl <> 1 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()

            If tUpdate4.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate4.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate4
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))

                    Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                    Dim bCheckAnlrEn As Boolean = s_IC_L.AnlrEnl <> 1       'Erweiterungsplastik darf nicht gesetzt sein

                    Dim lValve As tblSelListEntries = Nothing
                    Dim bCheckValve As Boolean = False
                    Dim i As Integer = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).Count()
                    If i = 1 Then
                        lValve = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).First() 'Klappe muss in der neuen Liste enthalten sein
                        bCheckValve = True
                    End If

                    If Not bCheckValve Then
                        sb.Append("Kein Update möglich. Klappe " + s_IC_L.VSAoIm.ToString() + " nicht in neuer Liste vorhanden. " + vbNewLine)
                    End If

                    If Not bCheckAnlrEn Then
                        sb.Append("Kein Update möglich. Erweiterungsplastik ist angehakt. " + vbNewLine)
                    End If

                    If (RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)

                        sb.Append("Int. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic_Int.ToString() + " -> " + s_IC_L.OpAortic.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy_Int.ToString + " -> " + s_IC_L.VSAoImTy.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm_Int.ToString + " -> " + s_IC_L.VSAoIm.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz_Int.ToString + " -> " + s_IC_L.VSAoImSz.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup_Int.ToString + " -> " + s_IC_L.VSAoImSzGroup.ToString + ")" + vbNewLine)

                        s_IC_L.OpAortic_Int = s_IC_L.OpAortic
                        s_IC_L.VSAoImTy_Int = s_IC_L.VSAoImTy
                        s_IC_L.VSAoIm_Int = s_IC_L.VSAoIm
                        s_IC_L.VSAoImSz_Int = s_IC_L.VSAoImSz
                        s_IC_L.VSAoImSzGroup_Int = s_IC_L.VSAoImSzGroup

                        sb.Append("Konv. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic.ToString + " -> 1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpAortic = -1
                        s_IC_L.VSAoImTy = -1
                        s_IC_L.VSAoIm = -1
                        s_IC_L.VSAoImSz = -1
                        s_IC_L.VSAoImSzGroup = 1

                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)
                        lstValvesMoved.Add(r)

                    ElseIf (Not RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("Nur geprüft, kein Update." + vbNewLine)
                    End If
                Next
                db.SaveChanges()
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)



            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("5. Klappe in Klappe: Verschieben auf Prozedurengruppe Klappen interventionell" + vbNewLine)
            sb.Append("Bedingungen: 'TAVI  (Klappen intervenionell) ist gewählt, Ao-Procedure = Klappe in Klappe, Ao-Erweiterungsplastik = nein, Implantat ist in der neuen Liste verfügbar." + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate5 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_TAVI In db.tblStay_CARDIAC_TAVI On s.ID Equals s_TAVI.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Join v In db.tblSelListEntries On v.IDOwnInt Equals s_IC_L.VSAoIm
                                               Where s_TAVI.OpTAVI = 1 And s_IC_L.OpAortic = 13 And s_IC_L.OpAortic_Int = -1 And s_IC_L.AnlrEnl <> 1 And v.IDGroup = 3423 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()
            If tUpdate5.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate5.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate5
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))

                    Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                    Dim bCheckAnlrEn As Boolean = s_IC_L.AnlrEnl <> 1       'Erweiterungsplastik darf nicht gesetzt sein

                    Dim lValve As tblSelListEntries = Nothing
                    Dim bCheckValve As Boolean = False
                    Dim i As Integer = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).Count()
                    If i = 1 Then
                        lValve = (From rV In db.tblSelListEntries Where rV.IDOwnInt = s_IC_L.VSAoIm And rV.IDGroup = 3423).First() 'Klappe muss in der neuen Liste enthalten sein
                        bCheckValve = True
                    End If

                    If Not bCheckValve Then
                        sb.Append("Kein Update möglich. Klappe " + s_IC_L.VSAoIm.ToString() + " nicht in neuer Liste vorhanden. " + vbNewLine)
                    End If

                    If Not bCheckAnlrEn Then
                        sb.Append("Kein Update möglich. Erweiterungsplastik ist angehakt. " + vbNewLine)
                    End If

                    If (RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)

                        sb.Append("Int. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic_Int.ToString() + " -> " + s_IC_L.OpAortic.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy_Int.ToString + " -> " + s_IC_L.VSAoImTy.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm_Int.ToString + " -> " + s_IC_L.VSAoIm.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz_Int.ToString + " -> " + s_IC_L.VSAoImSz.ToString + ")" + vbNewLine)
                        sb.Append("Int. Klappen: Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup_Int.ToString + " -> " + s_IC_L.VSAoImSzGroup.ToString + ")" + vbNewLine)

                        s_IC_L.OpAortic_Int = s_IC_L.OpAortic
                        s_IC_L.VSAoImTy_Int = s_IC_L.VSAoImTy
                        s_IC_L.VSAoIm_Int = s_IC_L.VSAoIm
                        s_IC_L.VSAoImSz_Int = s_IC_L.VSAoImSz
                        s_IC_L.VSAoImSzGroup_Int = s_IC_L.VSAoImSzGroup

                        sb.Append("Konv. Klappen: Ao-Prozedure (" + s_IC_L.OpAortic.ToString + " -> 1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Typ (" + s_IC_L.VSAoImTy.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat (" + s_IC_L.VSAoIm.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größe (" + s_IC_L.VSAoImSz.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Ao-Implantat Größengruppe (" + s_IC_L.VSAoImSzGroup.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpAortic = -1
                        s_IC_L.VSAoImTy = -1
                        s_IC_L.VSAoIm = -1
                        s_IC_L.VSAoImSz = -1
                        s_IC_L.VSAoImSzGroup = 1

                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)
                        lstValvesMoved.Add(r)

                    ElseIf (Not RunUpdate And bCheckAnlrEn And bCheckValve) Then
                        sb.Append("Nur geprüft, kein Update." + vbNewLine)
                    End If
                Next
                db.SaveChanges()
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("6. Mitraclip: Verschieben auf Prozedurengruppe Klappen interventionell" + vbNewLine)
            sb.Append("Bedingungen: 'TAVI  (Klappen intervenionell) ist gewählt, Mi-Procedure = MitraClip" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate6 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_TAVI In db.tblStay_CARDIAC_TAVI On s.ID Equals s_TAVI.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_TAVI.OpTAVI = 1 And s_IC_L.OpMitral = 6 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()

            If tUpdate6.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate6.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate6
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))
                    If (RunUpdate) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)
                        Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()

                        sb.Append("Int. Klappen: Mi-Prozedure (" + s_IC_L.OpMitral_Int.ToString + " -> 4)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Typ (" + s_IC_L.VSMiImTy_Int.ToString + " -> 20)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat (" + s_IC_L.VSMiIm_Int.ToString + " -> 6)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Größe (" + s_IC_L.VSMiImSz_Int.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Größengruppe (" + s_IC_L.VSMiImSzGroup_Int.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpMitral_Int = 4
                        s_IC_L.VSMiImTy_Int = 20
                        s_IC_L.VSMiIm_Int = 6
                        s_IC_L.VSMiImSz_Int = -1
                        s_IC_L.VSMiImSzGroup_Int = 1

                        sb.Append("Konv. Klappen: Mi-Prozedure (" + s_IC_L.OpMitral.ToString + " -> 1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Typ (" + s_IC_L.VSMiImTy.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat (" + s_IC_L.VSMiIm.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Größe (" + s_IC_L.VSMiImSz.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Größengruppe (" + s_IC_L.VSMiImSzGroup.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpMitral = -1
                        s_IC_L.VSMiImTy = -1
                        s_IC_L.VSMiIm = -1
                        s_IC_L.VSMiImSz = -1
                        s_IC_L.VSMiImSzGroup = 1

                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)
                        lstValvesMoved.Add(r)

                    Else
                        sb.Append("Nur geprüft." + vbNewLine)
                    End If
                Next
                db.SaveChanges()
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("7. NeoChord: Verschieben auf Prozedurengruppe Klappen interventionell" + vbNewLine)
            sb.Append("Bedingungen: 'TAVI  (Klappen intervenionell) ist gewählt, Mi-Procedure = NeoChord" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate7 As List(Of objSel) = (From s In db.tblStay
                                               Join s_IC_L In db.tblStay_CARDIAC_IC_L On s.ID Equals s_IC_L.ID
                                               Join s_TAVI In db.tblStay_CARDIAC_TAVI On s.ID Equals s_TAVI.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_TAVI.OpTAVI = 1 And s_IC_L.OpMitral = 8 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()

            If tUpdate7.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate7.Count.ToString() + ")" + vbNewLine)
                For Each r As objSel In tUpdate7
                    iCounter += 1
                    sb.Append(getHeaderZeile(r, iCounter))
                    If (RunUpdate) Then
                        sb.Append("DURCHGEFÜHRT." + vbNewLine)
                        Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()

                        sb.Append("Int. Klappen: Mi-Prozedure (" + s_IC_L.OpMitral_Int.ToString + " -> 4)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Typ (" + s_IC_L.VSMiImTy_Int.ToString + " -> 20)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat (" + s_IC_L.VSMiIm_Int.ToString + " -> 8)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Größe (" + s_IC_L.VSMiImSz_Int.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Int. Klappen: Mi-Implantat Größengruppe (" + s_IC_L.VSMiImSzGroup_Int.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpMitral_Int = 4
                        s_IC_L.VSMiImTy_Int = 20
                        s_IC_L.VSMiIm_Int = 8
                        s_IC_L.VSMiImSz_Int = -1
                        s_IC_L.VSAoImSzGroup_Int = 1

                        sb.Append("Konv. Klappen: Mi-Prozedure (" + s_IC_L.OpMitral.ToString + " -> 1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Typ (" + s_IC_L.VSMiImTy.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat (" + s_IC_L.VSMiIm.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Größe (" + s_IC_L.VSMiImSz.ToString + " -> -1)" + vbNewLine)
                        sb.Append("Konv. Klappen: Mi-Implantat Größengruppe (" + s_IC_L.VSMiImSzGroup.ToString + " -> 1)" + vbNewLine)

                        s_IC_L.OpMitral = -1
                        s_IC_L.VSMiImTy = -1
                        s_IC_L.VSMiIm = -1
                        s_IC_L.VSMiImSz = -1
                        s_IC_L.VSMiImSzGroup = 1

                        lstUpdates.Add(r)
                        lstUpdatesESrelevant.Add(r)
                        lstValvesMoved.Add(r)

                    Else
                        sb.Append("Nur geprüft." + vbNewLine)
                    End If
                Next
                db.SaveChanges()
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("8. Aktion Pulmonalarteriendruck-Methode.: für bestehende Datensätze auf undefiniert setzen." + vbNewLine)
            sb.Append("Bedingungen: 'Pulmunalarteriendruck gemessen' = angehakt und 'Methode' = ??" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            Dim tUpdate8 As List(Of objSel) = (From s In db.tblStay
                                               Join s_F_I In db.tblStay_CARDIAC_F_I On s.ID Equals s_F_I.ID
                                               Join o In db.tblObject On s.PatIDGuid Equals o.IDGuid
                                               Where s_F_I.HDPAD = 1 And s_F_I.HDPAMeth = -1 _
                                                    And s.IDParticipant = IDParticipant And s.IDApplication = "CARDIAC"
                                               Select New objSel With {.NameCombination = o.NameCombination, .PatExtID = o.ExtID, .MedRecN = s.MedRecN, .AdmitDt = s.AdmitDt, .SurgDtStartDt = s.SurgDtStart, .ID = s.ID}).ToList()
            If tUpdate8.Count = 0 Then
                sb.Append("Keine Datensätze für Update gefunden." + vbNewLine)
            Else
                sb.Append("Liste der gefundenen Datensätze (" + tUpdate8.Count.ToString() + ")" + vbNewLine)
                If NurESLog Then
                    sb.Append("Detailliertes Protokoll durch den Benutzer deaktiviert." + vbNewLine)
                    For Each r As objSel In tUpdate8
                        iCounter += 1
                        If (RunUpdate) Then
                            Dim s_F_I As tblStay_CARDIAC_F_I = (From rS In db.tblStay_CARDIAC_F_I Where rS.ID = r.ID).First()
                            s_F_I.HDPAMeth = 888
                        End If
                    Next
                    db.SaveChanges()
                Else
                    For Each r As objSel In tUpdate8
                        iCounter += 1
                        sb.Append(getHeaderZeile(r, iCounter))
                        If (RunUpdate) Then
                            sb.Append("DURCHGEFÜHRT." + vbNewLine)
                            Dim s_F_I As tblStay_CARDIAC_F_I = (From rS In db.tblStay_CARDIAC_F_I Where rS.ID = r.ID).First()
                            sb.Append("ADP Hemmer Meth (" + s_F_I.HDPAMeth.ToString + " -> 888)" + vbNewLine)
                            s_F_I.HDPAMeth = 888
                            lstUpdates.Add(r)
                        Else
                            sb.Append("Nur geprüft." + vbNewLine)
                        End If
                    Next
                    db.SaveChanges()
                End If
                tUpdate8 = Nothing
            End If
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append(vbNewLine + vbNewLine)


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("9. Korrektur der verschobenen interv. Klappen. Setzen der nicht operierten Positionen auf Nein" + vbNewLine)
            sb.Append("Bedingungen: 'Datensatz wurde verschoben und Klappenposition ist '??'" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            For Each r In lstValvesMoved
                Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                iCounter += 1
                sb.Append(getHeaderZeile(r, iCounter))
                sb.Append("Prüfen, ob Klappenposition auf 'Nein' gesetzt werden muss." + vbNewLine)

                If s_IC_L.OpAortic_Int = -1 Then
                    sb.Append("   Interv. Klappen: Ao-Prozedur (" + s_IC_L.OpAortic_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpAortic_Int = 1
                End If

                If s_IC_L.OpMitral_Int = -1 Then
                    sb.Append("   Interv. Klappen: Mi-Prozedur (" + s_IC_L.OpMitral_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpMitral_Int = 1
                End If

                If s_IC_L.OpTricus_Int = -1 Then
                    sb.Append("   Interv. Klappen: Tr-Prozedur (" + s_IC_L.OpTricus_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpTricus_Int = 1
                End If

                If s_IC_L.OpPulm_Int = -1 Then
                    sb.Append("   Interv. Klappen: Pu-Prozedur (" + s_IC_L.OpPulm_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpPulm_Int = 1
                End If
            Next
            If RunUpdate Then
                db.SaveChanges()
            Else
                sb.Append("Nur geprüft." + vbNewLine)
            End If


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("10. Nach Verschieben der interv. Klappen: Proz.Gruppe 'Konv. Klappen' wenn erforderlich zurücksetzen" + vbNewLine)
            sb.Append("Bedingungen: 'Klappen-Info wurde von konv. auf interv. verschoben, alle konv. Klappenpositionen sind '??'" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            For Each r In lstValvesMoved
                Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                sb.Append(getHeaderZeile(r, iCounter))
                iCounter += 1
                sb.Append("Prüfen, ob Proc. Group 'konv. Klappen' auf 'Nein' gesetzt werden muss." + vbNewLine)

                If r.ID = 28066 Then
                    Dim x As String = ""
                End If

                If s_IC_L.OpValve = 1 And s_IC_L.OpAortic <= 1 And s_IC_L.OpMitral <= 1 And s_IC_L.OpTricus <= 1 And s_IC_L.OpPulm <= 1 _
                    And s_IC_L.VSGarbImTy <= 1 Then
                    sb.Append("   Proz.Gruppe 'konv. Klappen'  (" + s_IC_L.OpValve.ToString + " -> 0)" + vbNewLine)
                    s_IC_L.OpValve = 0
                End If
            Next
            If RunUpdate Then
                db.SaveChanges()
            Else
                sb.Append("Nur geprüft." + vbNewLine)
            End If


            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            sb.Append("11. Nach Verschieben der interv. Klappen: undefinierte Positionen auf 'Nein' setzen" + vbNewLine)
            sb.Append("Bedingungen: 'Klappen-Info wurde von konv. auf interv. verschoben, int. Klappenposition ist '??'" + vbNewLine)
            sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            For Each r In lstValvesMoved
                Dim s_IC_L As tblStay_CARDIAC_IC_L = (From rS In db.tblStay_CARDIAC_IC_L Where rS.ID = r.ID).First()
                sb.Append(getHeaderZeile(r, iCounter))
                iCounter += 1
                sb.Append("Prüfen, ob Proc. Group 'konv. Klappen' auf 'Nein' gesetzt werden muss." + vbNewLine)

                If s_IC_L.OpAortic_Int = -1 Then
                    sb.Append("   Aortenposition für int. Klappe korrigieren  (" + s_IC_L.OpAortic_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpAortic_Int = 1
                End If

                If s_IC_L.OpMitral_Int = -1 Then
                    sb.Append("   Mitralposition für int. Klappe korrigieren  (" + s_IC_L.OpMitral_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpMitral_Int = 1
                End If

                If s_IC_L.OpTricus_Int = -1 Then
                    sb.Append("   Tricus-Position für int. Klappe korrigieren  (" + s_IC_L.OpTricus_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpTricus_Int = 1
                End If

                If s_IC_L.OpPulm_Int = -1 Then
                    sb.Append("   Pulm-Position für int. Klappe korrigieren  (" + s_IC_L.OpPulm_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.OpPulm_Int = 1
                End If

                If s_IC_L.VSGarbImTy_Int = -1 Then
                    sb.Append("   Verworfende Klappen-Position für int. Klappe korrigieren  (" + s_IC_L.VSGarbImTy_Int.ToString + " -> 1)" + vbNewLine)
                    s_IC_L.VSGarbImTy_Int = 1
                End If
            Next
            If RunUpdate Then
                db.SaveChanges()
            Else
                sb.Append("Nur geprüft." + vbNewLine)
            End If

            'Zeitraum für ES-Neuberechnung ausgeben
            Dim minDt As Date = New Date(3000, 1, 1)
            Dim maxDt As Date = New Date(1900, 1, 1)

            For Each r In lstUpdatesESrelevant
                minDt = IIf(r.AdmitDt < minDt, r.AdmitDt, minDt)
                maxDt = IIf(r.AdmitDt > maxDt, r.AdmitDt, minDt)
            Next

            If minDt <> New Date(3000, 1, 1) Or maxDt <> New Date(1900, 1, 1) Then
                sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
                sb.Append("Bitte berechnen Sie den Zeitraum von " + minDt.ToString + " bis " + maxDt.ToString + " neu, da sich die Datenänderungen in diesem Zeitraum auf den EuroSCORE auswirken können.")
                sb.Append("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------" + vbNewLine)
            End If

            sProtSum = sb.ToString()


            Dim Protocol1 As New qs2.core.vb.Protocol()
            'Dim IDGuid As Guid = System.Guid.NewGuid()
            'Dim tProtocol As IQueryable(Of qs2.db.Entities.Protocol) = From rProtocol In db.Protocol Where rProtocol.IDGuid = IDGuid And
            '                                                                    rProtocol.Type = "Update Herbst 2018" Order By rProtocol.Created Descending
            'For Each rProtDemo In tProtocol
            '    Dim x As New Guid(rProtDemo.User)
            '    'do anything
            'Next
            'db.SaveChanges()
            Protocol1.save2(Protocol.eTypeProtocoll.UpdateData, Nothing, -999, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), qs2.core.license.doLicense.rApplication.IDApplication.Trim(), "",
                        "Update Herbst 2018", Protocol.eActionProtocol.None, "", "", sProtSum)

            Return True

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.updateData1: " + ex.ToString())
        End Try
    End Function





    Private Function getHeaderZeile(r As objSel, i As Integer) As String
        Try
            Return i.ToString() + ". " + r.NameCombination + "(" + r.PatExtID + "), Aufnahmedatum = " + r.AdmitDt.ToString("dd.MM.yyyy") + ", Aufnahmezahl = " + r.MedRecN + ", OpDatum = " + IIf(IsNothing(r.SurgDtStartDt), "<nicht ausgefüllt>", System.Convert.ToDateTime(r.SurgDtStartDt).ToString("dd.MM.yyyy")) + ": "
        Catch ex As Exception
            Throw New Exception("businessFramework.getHeaderZeile: " + ex.ToString())
        End Try
    End Function

    Public Function getStaysEF(ByRef db As qs2.db.Entities.ERModellQS2Entities)
        Try

            Dim sqlStaysDemo2 As String = " SELECT qs2.tblStay.MedRecN, qs2.tblStay_CARDIAC_A_E.IsCongenital as A_E_IsCongenital FROM qs2.tblStay, qs2.tblStay_CARDIAC_A_E " +
                                            " where qs2.tblStay.ID=qs2.tblStay_CARDIAC_A_E.ID and " +
                                            "   s.IDParticipant = IDParticipant and " +
                                            "   qs2.tblStay.IDApplication=qs2.tblStay_CARDIAC_A_E.IDApplication " +
                                            " "
            Dim tStaysDemo2 As List(Of objSel) = db.Database.SqlQuery(Of objSel)(sqlStaysDemo2).ToList()
            ' objSel entsprechend um die Felder im Select erweitern mit gleichem Namen, where Klausel nach Bedarf anpassen

            For Each rStayDemo As objSel In tStaysDemo2
                Dim txtTmp As String = rStayDemo.MedRecN
            Next

            Return True

            'Dim da As New System.Data.SqlClient.SqlDataAdapter()
            'Dim cmd As New System.Data.SqlClient.SqlCommand()
            'cmd.CommandText = sqlStaysDemo2
            'cmd.Connection = qs2.core.dbBase.dbConn
            'cmd.CommandTimeout = 0
            'da.SelectCommand = cmd

            'Dim dt As New DataTable()
            'da.Fill(dt)
            'For Each r As DataRow In dt.Rows
            '    'r("A_E_IsCongenital")
            'Next

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.getStaysEF: " + ex.ToString())
        End Try
    End Function

    Public Function sys_AdjustmentQTHDb() As Boolean
        Try
            Dim cmd As New System.Data.SqlClient.SqlCommand() With {
                .CommandText = "EXEC [qs2].[GetDataFromQTH] '" + qs2.core.license.doLicense.rParticipant.IDParticipant + "'",
                .Connection = qs2.core.dbBase.dbConn
            }
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.sys_AdjustmentQTHDb: " + ex.ToString())
        End Try
    End Function



    Public Function copyRehangStaysToNewParticipant(ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                         ByRef NoStaysFound As Boolean, ByRef sProt As String, ByRef lblINfo As Infragistics.Win.Misc.UltraLabel) As Boolean

        Dim dNow As DateTime = Now
        Dim doCopy As Boolean = False
        Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
        With db
            Dim IDGuidUsr As Guid = Nothing
            Dim tStaysSqlCommand As List(Of DTOs.StayDtoS1)
            If Not Me.checkStayCopyRehang(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand, sProt) Then
                Return False
            End If
            'If doCopy Then
            Me.newSuperUser(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand, IDGuidUsr, sProt)
            'End If

            If tStaysSqlCommand.Count() > 0 Then
                Dim lPatientsDelete As New System.Collections.Generic.List(Of Guid)()
                Dim lOldObjComboBoxesCopied As New System.Collections.Generic.List(Of ObjectCopiedDto)()
                Dim lStaysChildsRehanged As New System.Collections.Generic.List(Of StaysRehangDto)()
                Dim iCounter As Integer = 0
                Dim lStaysCopy As New List(Of DTOs.StaysRehangDto)
                For Each rStayFound As DTOs.StayDtoS1 In tStaysSqlCommand
                    Dim dsObject1 As dsObjects = Nothing
                    Dim sqlObject1 As sqlObjects = Nothing

                    Dim dsObject2 As dsObjects = Nothing
                    Dim sqlObject2 As sqlObjects = Nothing

                    Dim dsAdmin1 As dsAdmin = Nothing
                    Dim sqlAdmin1 As sqlAdmin = Nothing

                    Dim dsAdmin2 As dsAdmin = Nothing
                    Dim sqlAdmin2 As sqlAdmin = Nothing

                    Dim dsLanguage1 As language.dsLanguage = Nothing
                    Dim sqlLanguage1 As language.sqlLanguage = Nothing

                    Dim dsLanguage2 As language.dsLanguage = Nothing
                    Dim sqlLanguage2 As language.sqlLanguage = Nothing


                    Me.getCopyRehangStaysGetNewSqlInstances(db, dsObject1, sqlObject1, dsObject2, sqlObject2,
                                                    dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2,
                                                    dsLanguage1, sqlLanguage1, dsLanguage2, sqlLanguage2, sProt)

                    iCounter += 1
                    sProt += "---------- begin write " + iCounter.ToString() + ". stay and patient from " + tStaysSqlCommand.Count.ToString() + " (stay-IDGuid:" + rStayFound.IDGuid.ToString() + ")" + vbNewLine + vbNewLine
                    lblINfo.Text = "write stay " + iCounter.ToString() + " from " + tStaysSqlCommand.Count.ToString() + " for participant " + IDParticipantNew.Trim() + " "
                    System.Windows.Forms.Application.DoEvents()

                    Dim StaysRehangDto1 As New DTOs.StaysRehangDto() With {.IDStayOld = rStayFound.ID, .IDParticipantOld = rStayFound.IDParticipant,
                                                                                .IDApplicationOld = rStayFound.IDApplication, .IDGuidOld = rStayFound.IDGuid}
                    StaysRehangDto1.IDStayOld = rStayFound.ID
                    StaysRehangDto1.IDParticipantOld = rStayFound.IDParticipant.Trim()
                    StaysRehangDto1.IDApplicationOld = rStayFound.IDApplication.Trim()
                    StaysRehangDto1.IDGuidOld = rStayFound.IDGuid
                    lStaysCopy.Add(StaysRehangDto1)

                    Dim IDPatientNewGuid As Guid = Nothing
                    Dim IDPatientNewIDdBack As Integer = -1
                    Me.copyRehangPatient(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                                         dsObject1, sqlObject1, dsObject2, sqlObject2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound, IDPatientNewGuid, IDGuidUsr,
                                         lStaysCopy, StaysRehangDto1, sProt, lPatientsDelete, rStayFound.PatIDGuid, IDPatientNewIDdBack)

                    Dim IDStayNewGuid As Guid = Nothing
                    If Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                                        dsObject1, sqlObject1, dsObject2, sqlObject2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                                        IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied,
                                        lStaysChildsRehanged) Then

                        Me.copyRehangStayMasterdata(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                                                        dsObject1, sqlObject1, dsObject2, sqlObject2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, dsLanguage1, sqlLanguage1, dsLanguage2, sqlLanguage2,
                                                        rStayFound, IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt)
                    End If
                Next

                Me.CopyRehangDeleteOldPatient(db, IDParticipantOld, IDParticipantNew, lPatientsDelete, sProt)
                If lStaysChildsRehanged.Count() > 0 Then
                    For Each s As StaysRehangDto In lStaysChildsRehanged
                        Dim cmd As New SqlCommand()
                        cmd.Connection = qs2.core.dbBase.dbConn
                        cmd.CommandText = " update qs2.tblStay set IDParticipantParent='" + s.IDParticipantNew.Trim() + "', IDApplicationParent='" + s.IDApplicationNew + "', IDStayParent=" + s.IDStayNew.ToString() + " " +
                                          " where IDGuid='" + s.IDGuidNew.ToString() + "' "
                        cmd.ExecuteNonQuery()
                    Next
                End If
            End If
        End With

        Return True

    End Function
    Public Sub getCopyRehangStaysGetNewSqlInstances(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                                    ByRef dsObject1 As dsObjects, ByRef sqlObjects1 As sqlObjects,
                                                    ByRef dsObject2 As dsObjects, ByRef sqlObjects2 As sqlObjects,
                                                    ByRef dsAdmin1 As dsAdmin, ByRef sqlAdmin1 As sqlAdmin,
                                                    ByRef dsAdmin2 As dsAdmin, ByRef sqlAdmin2 As sqlAdmin,
                                                    ByRef dsLanguage1 As language.dsLanguage, ByRef sqlLanguage1 As language.sqlLanguage,
                                                    ByRef dsLanguage2 As language.dsLanguage, ByRef sqlLanguage2 As language.sqlLanguage,
                                                    ByRef sProt As String)

        dsObject1 = New dsObjects()
        sqlObjects1 = New sqlObjects()
        sqlObjects1.initControl()

        dsObject2 = New dsObjects()
        sqlObjects2 = New sqlObjects()
        sqlObjects2.initControl()

        dsAdmin1 = New dsAdmin()
        sqlAdmin1 = New sqlAdmin()
        sqlAdmin1.initControl()

        dsAdmin2 = New dsAdmin()
        sqlAdmin2 = New sqlAdmin()
        sqlAdmin2.initControl()

        dsLanguage1 = New language.dsLanguage()
        sqlLanguage1 = New language.sqlLanguage()
        sqlLanguage1.initControl()

        dsLanguage2 = New language.dsLanguage()
        sqlLanguage2 = New language.sqlLanguage()
        sqlLanguage2.initControl()

    End Sub

    Public Function checkStayCopyRehang(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                        ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                        ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                        ByRef sProt As String) As Boolean

        Dim sqlStay As String = "Select ID, IDParticipant, IDApplication, IDGuid, PatIDGuid from qs2." + IDApplication.Trim() + "_STAYS where IDApplication='" + IDApplication.Trim() + "' and IDParticipant='" + IDParticipantOld.Trim() + "' "
        Dim pars(0) As DbParameter
        'pars(0) = New SqlParameter("", "")
        Dim sOrderBy As String = " order by IDStayParent desc "
        Dim sqlCmd As String = sqlStay + " and " + SqlWhere + sOrderBy
        tStaysSqlCommand = db.Database.SqlQuery(Of DTOs.StayDtoS1)(sqlCmd, pars).ToList
        sProt += tStaysSqlCommand.Count().ToString() + " stays found for Sql-Command " + sqlCmd + "" + vbNewLine + vbNewLine
        If tStaysSqlCommand.Count() = 0 Then
            NoStaysFound = True
            sProt += "No stays found for sql-command '" + sqlCmd.Trim() + "'" + vbNewLine + vbNewLine
            Return False
        End If

        Dim tStaysCheckAll As List(Of DTOs.StayDtoS1) = db.Database.SqlQuery(Of DTOs.StayDtoS1)(sqlStay + sOrderBy).ToList
        sProt += tStaysCheckAll.Count().ToString() + " stays found for Sql-Command " + sqlStay + "" + vbNewLine + vbNewLine
        If tStaysCheckAll.Count() = 0 Then
            NoStaysFound = True
            sProt += "No stays found for sql-command '" + sqlStay.Trim() + "'" + vbNewLine + vbNewLine
            Return False
        End If
        'If tStaysCheckAll.Count() > tStaysSqlCommand.Count() Then
        '    sProt += tStaysSqlCommand.Count().ToString() + " stays found for copy stays (Sql-Command " + sqlStay + ")" + vbNewLine + vbNewLine
        '    doCopy = True
        'End If

        Return True

    End Function
    Public Function newSuperUser(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                        ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                        ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                        ByRef IDGuidUsr As Guid, ByRef sProt As String) As Boolean

        Dim dsObject1 As dsObjects = Nothing
        Dim sqlObject1 As sqlObjects = Nothing

        Dim dsObject2 As dsObjects = Nothing
        Dim sqlObject2 As sqlObjects = Nothing

        Dim dsAdmin1 As dsAdmin = Nothing
        Dim sqlAdmin1 As sqlAdmin = Nothing

        Dim dsAdmin2 As dsAdmin = Nothing
        Dim sqlAdmin2 As sqlAdmin = Nothing

        Dim dsLanguage1 As language.dsLanguage = Nothing
        Dim sqlLanguage1 As language.sqlLanguage = Nothing

        Dim dsLanguage2 As language.dsLanguage = Nothing
        Dim sqlLanguage2 As language.sqlLanguage = Nothing

        Me.getCopyRehangStaysGetNewSqlInstances(db, dsObject1, sqlObject1, dsObject2, sqlObject2,
                                                    dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2,
                                                    dsLanguage1, sqlLanguage1, dsLanguage2, sqlLanguage2, sProt)

        Dim dsUpdateUser As New dsObjects()
        Dim sqlObjectsUpdateUser As New sqlObjects()
        sqlObjectsUpdateUser.initControl()
        Dim IDObjectBack As Integer = -1
        sqlObjectsUpdateUser.checkUsrSupervisor(False, True, IDParticipantNew.Trim(), False, IDGuidUsr, IDObjectBack)
        'sqlObjectsUpdateUser.checkUsrSupervisor(True, False, "", False)
        sProt += "User Admin inserted for participant " + IDParticipantNew.Trim() + " (IDGuid-Admin='" + IDGuidUsr.ToString() + "')" + vbNewLine + vbNewLine

        Dim IDGuidUsrTmp As Guid = IDGuidUsr
        Dim IDAppTmp As String = IDApplication
        Dim tObjApp As List(Of qs2.db.Entities.tblObjectApplications) = (From rObjA In db.tblObjectApplications Where rObjA.IDObjectGuid = IDGuidUsrTmp And rObjA.IDApplication = IDAppTmp).ToList()
        If tObjApp.Count() = 0 Then
            Dim rNewObjApp As New tblObjectApplications()
            rNewObjApp.ID = System.Guid.NewGuid
            rNewObjApp.IDApplication = IDApplication.Trim()
            rNewObjApp.IDObjectGuid = IDGuidUsr
            db.tblObjectApplications.Add(rNewObjApp)
            db.SaveChanges()
        End If

        'sqlAdmin1.getSelListEntrysObj(-1, sqlAdmin.eDbTypAuswObj.Criterias, "", dsAdmin1, sqlAdmin.eTypAuswahlObj.IDSelListEntryIDObject, rPatientAct.ID, -1, "", -1, "", -1, "", "", False)
        sqlAdmin2.getSelListEntrysObj(-1, sqlAdmin.eDbTypAuswObj.Roles, "", dsAdmin2, sqlAdmin.eTypAuswahlObj.IDSelListEntryIDObject, "", -1, "", -1, "", -1, "", "", False, System.Guid.NewGuid)

        Dim rObjectFound As tblObject = (From o In db.tblObject
                                         Where o.IDGuid = IDGuidUsrTmp).First()
        dsAdmin2.Clear()
        Dim rSelListEntriesObjNew As dsAdmin.tblSelListEntriesObjRow = sqlAdmin2.getNewRowSelListObj(dsAdmin2)
        rSelListEntriesObjNew.IDGuid = System.Guid.NewGuid()
        rSelListEntriesObjNew.IDObject = rObjectFound.ID
        rSelListEntriesObjNew.IDSelListEntry = 10020011   'admin-role
        rSelListEntriesObjNew.typIDGroup = "Roles"
        rSelListEntriesObjNew.Active = True
        sqlAdmin2.daSelListEntrysObj.Update(dsAdmin2.tblSelListEntriesObj)

        Return True

    End Function
    Public Function copyRehangPatient(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                        ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                        ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                        ByRef dsObject1 As dsObjects, ByRef sqlObjects1 As sqlObjects, ByRef dsObject2 As dsObjects, ByRef sqlObjects2 As sqlObjects,
                                        ByRef dsAdmin1 As dsAdmin, ByRef sqlAdmin1 As sqlAdmin, ByRef dsAdmin2 As dsAdmin, ByRef sqlAdmin2 As sqlAdmin,
                                        ByRef rStayFound As DTOs.StayDtoS1,
                                        ByRef IDPatientNewGuidBack As System.Guid, ByRef IDGuidUsr As Guid,
                                        ByRef lStaysCopy As List(Of DTOs.StaysRehangDto),
                                        ByRef StaysRehangDto1 As DTOs.StaysRehangDto, ByRef sProt As String,
                                        ByRef lPatientsDelete As System.Collections.Generic.List(Of Guid), ByRef IDPatientToCopyRehang As Guid,
                                        ByRef IDPatientNewIDdBack As Integer) As Boolean
        Dim sExceptInfo As String = "patient-IDGuid: '" + IDPatientToCopyRehang.ToString() + "' "
        Try
            dsObject1.Clear()
            dsObject2.Clear()
            dsAdmin1.Clear()
            dsAdmin2.Clear()

            sqlObjects1.getObject(-999, dsObject1, sqlObjects.eTypSelObj.IDGuid, sqlObjects.eTypObj.none, "", "", False, IDPatientToCopyRehang)
            If dsObject1.tblObject.Rows.Count() <> 1 Then
                Throw New Exception("businessFramework.copyRehangPatient: dsUpdate.tblObject.Rows.Count<>1 for IDGuid '" + "" + "'!")
            End If
            Dim rPatientAct As dsObjects.tblObjectRow = dsObject1.tblObject.Rows(0)
            If rPatientAct.LastName.Trim().Equals(("Zuleger").Trim()) Then
                Dim bStop As Boolean = True
            End If
            'Dim rPatientAdressAct As dsObjects.tblAdressRow = Nothing
            'If Not rPatientAct.IsPatient Then
            sqlObjects1.getAdress(IDPatientToCopyRehang, dsObject1, sqlObjects.eTypSelAdr.idObject)
            'If dsObject1.tblAdress.Rows.Count() <> 1 Then
            '    Throw New Exception("businessFramework.copyRehangPatient: dsUpdate.tblAdress.Rows.Count<>1 for IDGuid '" + "" + "'!")
            'End If
            'If dsObject1.tblAdress.Count = 1 Then
            '    rPatientAdressAct = sqlObjects1.getNewRowAdressen(dsObject1)
            'ElseIf dsObject1.tblAdress.Count > 1 Then
            '    Throw New Exception("businessFramework.copyRehangPatient: dsObject1.tblAdress.Count>1 not allowed for IDPatient '" + rPatientAct.IDGuid.ToString() + "'!")
            'End If
            ''End If

            sqlAdmin1.getSelListEntrysObj(rPatientAct.ID, sqlAdmin.eDbTypAuswObj.Criterias, "", dsAdmin1, sqlAdmin.eTypAuswahlObj.objOnly, "", -1, "", -1, "", -1, "", "", False)
            sqlAdmin2.getSelListEntrysObj(-54367, sqlAdmin.eDbTypAuswObj.Criterias, "", dsAdmin2, sqlAdmin.eTypAuswahlObj.objOnly, "", -1, "", -1, "", -1, "", "", False, System.Guid.NewGuid)

            sqlObjects1.getMedArchiv(rPatientAct.IDGuid, Nothing, dsObject1, sqlObjects.eTypSelMedArchiv.IDObject, "")
            sqlObjects2.getMedArchiv(System.Guid.NewGuid, Nothing, dsObject2, sqlObjects.eTypSelMedArchiv.IDObject, "")

            Dim doCopyTmp As Boolean = True
            If doCopyTmp Then
                Dim IDExtTmp As String = ""
                Dim bCopyPatientTmp As Boolean = False
                Dim rPatientCopy As dsObjects.tblObjectRow = Nothing
                Dim IDObjectFound As Integer = -1

                'If Not rPatientAct.IsPatient Then
                If rPatientAct.ExtID.Trim() <> "" And IDParticipantNew.Trim() <> "" Then
                    Dim IDPartTmp As String = IDParticipantNew
                    Dim tObjectFound3 As List(Of tblObject) = (From o In db.tblObject
                                                               Where o.ExtID = rPatientAct.ExtID And o.IDParticipant = IDPartTmp).ToList()
                    If tObjectFound3.Count() = 1 Then
                        'IDExtTmp = System.Guid.NewGuid.ToString()
                        Dim rObjFound3 As tblObject = tObjectFound3.First()
                        IDObjectFound = rObjFound3.ID
                        bCopyPatientTmp = False
                    ElseIf tObjectFound3.Count() > 1 Then
                        Throw New Exception("copyRehangPatient: tObjectFound3.Count()>1 not allowed for ExtID='" + rPatientAct.ExtID.Trim() + "' and IDParticipant='" + IDParticipantNew.Trim() + "'!")
                    Else
                        IDExtTmp = rPatientAct.ExtID
                        bCopyPatientTmp = True
                    End If
                    'Else
                    '    IDExtTmp = rPatientAct.ExtID
                    'End If
                Else
                    If rPatientAct.IsPatient Then
                        IDExtTmp = System.Guid.NewGuid.ToString()
                        bCopyPatientTmp = True
                        'Throw New Exception("copyRehangPatient: ExtID='' and IDParticipantNew='' not allowed for Patient-Guid='" + rPatientAct.IDGuid.ToString() + "'!")
                    Else
                        IDExtTmp = System.Guid.NewGuid.ToString()
                        Dim bPartExtIDEmpty As Boolean = True
                    End If
                End If

                If Not bCopyPatientTmp Then
                    sqlObjects2.getObject(IDObjectFound, dsObject2, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none, "", "", False, Nothing)
                    rPatientCopy = dsObject2.tblObject.Rows(0)
                Else
                    sqlObjects2.getObject(-5364, dsObject2, sqlObjects.eTypSelObj.ID, sqlObjects.eTypObj.none, "", "", False, Nothing)
                    rPatientCopy = sqlObjects2.getNewRowObject(dsObject2)
                    rPatientCopy.ItemArray = rPatientAct.ItemArray
                    rPatientCopy.IDGuid = System.Guid.NewGuid()
                    rPatientCopy.IDParticipant = IDParticipantNew.Trim()
                    rPatientCopy.ExtID = IDExtTmp.Trim()
                    sqlObjects2.daObject.Update(dsObject2.tblObject)
                End If

                sqlObjects2.getAdress(System.Guid.NewGuid(), dsObject2, sqlObjects.eTypSelAdr.idObject)
                If dsObject1.tblAdress.Count > 0 Then
                    For Each rAdressToCopy As dsObjects.tblAdressRow In dsObject1.tblAdress
                        Try
                            Dim tObjAdressCheck = (From o In db.tblAdress
                                                   Where o.IDGuidObject = rPatientCopy.IDGuid
                                                   Select o.IDGuid).ToList()
                            If tObjAdressCheck.Count() = 0 Then
                                Dim rPatientAdressCopy As dsObjects.tblAdressRow = sqlObjects2.getNewRowAdressen(dsObject2)
                                rPatientAdressCopy.ItemArray = rPatientAdressCopy.ItemArray
                                rPatientAdressCopy.IDGuid = System.Guid.NewGuid()
                                rPatientAdressCopy.IDGuidObject = rPatientCopy.IDGuid
                                rPatientAdressCopy.IsMainAdress = True
                                sqlObjects2.daAdress.Update(dsObject2.tblAdress)
                            Else
                                Dim bObjAdreswsExists As Boolean = True
                            End If

                        Catch ex As Exception
                            Throw New Exception("businessFramework.copyRehangPatient: copy Adress-IDGuid: '" + rAdressToCopy.IDGuid.ToString() + "'" +
                                                                                        vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                        End Try
                    Next
                End If
                sProt += "Patient '" + rPatientCopy.LastName.Trim() + " " + rPatientCopy.FirstName.Trim() + "' copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                Dim IDGuidUsrTmp As Guid = IDGuidUsr
                Dim IDAppTmp As String = IDApplication
                Dim tObjApp As List(Of qs2.db.Entities.tblObjectApplications) = (From rObjA In db.tblObjectApplications Where rObjA.IDObjectGuid = rPatientAct.IDGuid).ToList()
                For Each rObjAppExists In tObjApp
                    Try
                        Dim rNewObjApp As New tblObjectApplications()
                        rNewObjApp.ID = System.Guid.NewGuid
                        rNewObjApp.IDApplication = rObjAppExists.IDApplication.Trim()
                        rNewObjApp.IDObjectGuid = rPatientCopy.IDGuid
                        db.tblObjectApplications.Add(rNewObjApp)
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangPatient: copy ObjectApplications - ID: '" + rObjAppExists.ID.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next

                For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In dsAdmin1.tblSelListEntriesObj
                    Try
                        dsAdmin2.Clear()
                        Dim rSelListEntriesObjNew As dsAdmin.tblSelListEntriesObjRow = sqlAdmin2.getNewRowSelListObj(dsAdmin2)
                        rSelListEntriesObjNew.ItemArray = rSelListEntriesObj.ItemArray
                        rSelListEntriesObjNew.IDGuid = System.Guid.NewGuid()
                        If rSelListEntriesObj.IDParticipant.Trim() <> "" Then
                            rSelListEntriesObjNew.IDParticipant = IDParticipantNew.Trim()
                        End If
                        Dim rObjFound2 As tblObject = (From obj In db.tblObject Where obj.IDGuid = rPatientCopy.IDGuid
                                                       Order By obj.ID).First()
                        rSelListEntriesObjNew.IDObject = rObjFound2.ID
                        sqlAdmin2.daSelListEntrysObj.Update(dsAdmin2.tblSelListEntriesObj)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangPatient: copy sellistobj - IDGuid-sellistentryobj: '" + rSelListEntriesObj.IDGuid.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next

                For Each rMedArchiveAct As dsObjects.tblMedArchivRow In dsObject1.tblMedArchiv
                    Try
                        dsObject2.Clear()
                        Dim rMedArchiveNew As dsObjects.tblMedArchivRow = sqlObjects2.getNewRowMedArchiv(dsObject2)
                        rMedArchiveNew.ItemArray = rMedArchiveAct.ItemArray
                        rMedArchiveNew.IDGuid = System.Guid.NewGuid()
                        rMedArchiveNew.IDObjectGuid = rPatientCopy.IDGuid

                        sqlObjects2.daMedArchiv.Update(dsObject2.tblMedArchiv)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangPatient: copy medarchive - IDGuid-medarchive: '" + rMedArchiveAct.IDGuid.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsObject1.tblMedArchiv.Count().ToString() + " medarchives for patient copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                If Not lPatientsDelete Is Nothing Then
                    If Not lPatientsDelete.Contains(rPatientAct.IDGuid) Then
                        lPatientsDelete.Add(rPatientAct.IDGuid)
                    End If
                End If

                IDPatientNewGuidBack = rPatientCopy.IDGuid
                Dim rObjInserted = (From o In db.tblObject
                                    Where o.IDGuid = rPatientCopy.IDGuid
                                    Select o.IDGuid, o.ID).First()
                IDPatientNewIDdBack = rObjInserted.ID
            Else
                Throw New Exception("copyRehangPatient: Rehang patient not activated!")

                rPatientAct.IDParticipant = IDParticipantNew.Trim()
                sqlObjects1.daObject.Update(dsObject1.tblObject)

                IDPatientNewGuidBack = rPatientAct.IDGuid
                IDPatientNewIDdBack = rPatientAct.ID
                sProt += "Patient '" + rPatientAct.LastName.Trim() + " " + rPatientAct.FirstName.Trim() + "' rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                For Each rMedArchiveAct As dsObjects.tblMedArchivRow In dsObject1.tblMedArchiv
                    Try
                        Dim rMedArchiveUpdate As qs2.db.Entities.tblMedArchiv = (From rMed In db.tblMedArchiv Where rMed.IDObjectGuid = rPatientAct.IDGuid).First()
                        rMedArchiveUpdate.IDObjectGuid = rPatientAct.IDGuid
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangPatient: rehang medarchive - IDGuid-medarchive: '" + rMedArchiveAct.IDGuid.ToString() + "'" +
                                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsObject1.tblMedArchiv.Count().ToString() + " medarchives for object rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.copyRehangPatient: patient-IDGuid:'" + sExceptInfo + "'" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function copyRehangStay(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                        ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                        ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                        ByRef dsObject1 As dsObjects, ByRef sqlObjects1 As sqlObjects, ByRef dsObject2 As dsObjects, ByRef sqlObjects2 As sqlObjects,
                                        ByRef dsAdmin1 As dsAdmin, ByRef sqlAdmin1 As sqlAdmin, ByRef dsAdmin2 As dsAdmin, ByRef sqlAdmin2 As sqlAdmin,
                                        rStayFound As DTOs.StayDtoS1, IDPatientNewGuid As Guid, ByRef IDStayNewGuid As Guid, ByRef IDGuidUsr As Guid,
                                        ByRef lStaysCopy As List(Of DTOs.StaysRehangDto), ByRef StaysRehangDto1 As DTOs.StaysRehangDto,
                                        ByRef sProt As String, ByRef lOldObjComboBoxesCopied As System.Collections.Generic.List(Of ObjectCopiedDto),
                                        ByRef lStaysChildsRehanged As System.Collections.Generic.List(Of StaysRehangDto)) As Boolean
        Dim sExceptInfo As String = "stay-IDGuid: '" + rStayFound.IDGuid.ToString() + "' "
        Try
            dsObject1.Clear()
            dsObject2.Clear()
            dsAdmin1.Clear()
            dsAdmin2.Clear()

            sqlObjects1.getStay(-999, "", Nothing, Nothing, dsObject1, sqlObjects.eTypSelStay.IDGuidStay, "", Enums.eStayTyp.Stay, "",
                                            rStayFound.IDGuid, "", Enums.eSearchType.AKH, False, -999, Nothing, -999, False, "", "", -1, -1, -1, "")
            If dsObject1.tblStay.Rows.Count <> 1 Then
                Throw New Exception("businessFramework.copyRehangStay: dsUpdate.tblStay.Rows.Count<>1 for IDStay '" + rStayFound.ID.ToString() + "'!")
            End If
            Dim rStayAct As dsObjects.tblStayRow = dsObject1.tblStay(0)

            qs2.core.dbBase.setConnection(sqlAdmin2.daStayAdditions)
            sqlAdmin1.getStayAdditions(rStayAct.ID, rStayAct.IDParticipant, dsAdmin1, sqlAdmin.eTypSelStayAdditions.idStay2, sqlAdmin.eTypStayAdditions.assignStay, rStayAct.IDApplication.Trim(), System.Guid.Empty, "", False)
            sqlAdmin2.getStayAdditions(-1, rStayAct.IDParticipant, dsAdmin2, sqlAdmin.eTypSelStayAdditions.IDGuid, sqlAdmin.eTypStayAdditions.assignStay, rStayAct.IDApplication.Trim(), System.Guid.Empty, "", False, System.Guid.NewGuid())

            sqlAdmin1.getSelListEntrysObj(-1, sqlAdmin.eDbTypAuswObj.Criterias, "", dsAdmin1, sqlAdmin.eTypAuswahlObj.IDStay, rStayAct.IDApplication.Trim(), -1, "", rStayAct.ID, rStayAct.IDParticipant.Trim(), -1, "", "", False)
            sqlAdmin2.getSelListEntrysObj(--1, sqlAdmin.eDbTypAuswObj.Criterias, "", dsAdmin2, sqlAdmin.eTypAuswahlObj.IDGuid, "", -1, "", -1, "", -1, "", "", False, System.Guid.NewGuid)

            sqlObjects1.getMedArchiv(Nothing, rStayFound.IDGuid, dsObject1, sqlObjects.eTypSelMedArchiv.IDStay, "")
            sqlObjects2.getMedArchiv(Nothing, System.Guid.NewGuid, dsObject2, sqlObjects.eTypSelMedArchiv.IDStay, "")

            Dim doCopyTmp As Boolean = False
            If doCopyTmp Then
                Throw New Exception("copyRehangStay: Copy stay not activated!")

                Dim eStayType As qs2.core.Enums.eStayTyp = rStayAct.StayTyp
                Dim rNewStayNew As qs2.core.vb.dsObjects.tblStayRow
                Dim lstTablesDistinct As New System.Collections.Generic.List(Of String)

                StaysRehangDto1.IDStayNew = rNewStayNew.ID
                StaysRehangDto1.IDApplicationNew = rNewStayNew.IDApplication.Trim()
                StaysRehangDto1.IDParticipantNew = rNewStayNew.IDParticipant.Trim()
                StaysRehangDto1.IDGuidNew = rNewStayNew.IDGuid
                sProt += "Stay '" + rNewStayNew.IDGuid.ToString() + "' copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                For Each rStayAddition As dsAdmin.tblStayAdditionsRow In dsAdmin1.tblStayAdditions
                    Try
                        dsAdmin2.Clear()
                        Dim rStayAdditionNew As dsAdmin.tblStayAdditionsRow = sqlAdmin2.addNewStayAddition(dsAdmin2.tblStayAdditions)
                        rStayAdditionNew.ItemArray = rStayAddition.ItemArray
                        rStayAdditionNew.IDGuid = System.Guid.NewGuid()
                        rStayAdditionNew.IDStayParent = rNewStayNew.ID                  'lthxy >> StayChild & changeSelListKAVToInt() - IDStayNewGuid fehlen noch
                        rStayAdditionNew.IDApplicationStayParent = rNewStayNew.IDApplication.Trim()
                        rStayAdditionNew.IDParticipantStayParent = rNewStayNew.IDParticipant.Trim()
                        If Not rStayAddition.IsIDPatientNull() Then
                            rStayAdditionNew.IDPatient = IDPatientNewGuid
                        End If

                        If Not rStayAdditionNew.IsIDStayChildNull() Then
                            Dim StaysRehangDtoFound = (From rStayDto In lStaysCopy Where rStayDto.IDStayOld = rStayAdditionNew.IDStayChild And rStayDto.IDApplicationOld = rStayAdditionNew.IDApplicationStayChild And
                                                    rStayDto.IDParticipantOld = rStayAdditionNew.IDParticipantStayChild).First()

                            rStayAdditionNew.IDStayChild = StaysRehangDtoFound.IDStayNew
                            rStayAdditionNew.IDApplicationStayChild = StaysRehangDtoFound.IDApplicationNew.Trim()
                            rStayAdditionNew.IDParticipantStayChild = StaysRehangDtoFound.IDParticipantNew.Trim()
                        End If

                        sqlAdmin2.daStayAdditions.Update(dsAdmin2.tblStayAdditions)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: copy medarchive - IDGuid-stayaddition: '" + rStayAddition.IDGuid.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next

                For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In dsAdmin1.tblSelListEntriesObj
                    Try
                        dsAdmin2.Clear()
                        Dim rSelListEntriesObjNew As dsAdmin.tblSelListEntriesObjRow = sqlAdmin2.getNewRowSelListObj(dsAdmin2)
                        rSelListEntriesObjNew.ItemArray = rSelListEntriesObj.ItemArray
                        rSelListEntriesObjNew.IDGuid = System.Guid.NewGuid()
                        rSelListEntriesObjNew.IDStay = rNewStayNew.ID
                        rSelListEntriesObjNew.IDApplicationStay = rNewStayNew.IDApplication.Trim()
                        rSelListEntriesObjNew.IDParticipantStay = rNewStayNew.IDParticipant.Trim()
                        If rSelListEntriesObj.IDParticipant.Trim() <> "" Then
                            rSelListEntriesObjNew.IDParticipant = rNewStayNew.IDParticipant.Trim()
                        End If
                        If Not rSelListEntriesObj.IsIDObjectNull() Then
                            Dim rPatientNew As tblObject = (From obj In db.tblObject Where obj.IDGuid = IDPatientNewGuid
                                                            Order By obj.ID).First()
                            rSelListEntriesObjNew.IDObject = rPatientNew.ID
                        End If
                        sqlAdmin2.daSelListEntrysObj.Update(dsAdmin2.tblSelListEntriesObj)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: copy medarchive - IDGuid-sellistentryobj: '" + rSelListEntriesObj.IDGuid.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next

                For Each rMedArchiveAct As dsObjects.tblMedArchivRow In dsObject1.tblMedArchiv
                    Try
                        dsObject2.Clear()
                        Dim rMedArchiveNew As dsObjects.tblMedArchivRow = sqlObjects2.getNewRowMedArchiv(dsObject2)
                        rMedArchiveNew.ItemArray = rMedArchiveAct.ItemArray
                        rMedArchiveNew.IDGuid = System.Guid.NewGuid()
                        rMedArchiveNew.IDStay = rNewStayNew.ID
                        rMedArchiveNew.IDParticipant = rNewStayNew.IDParticipant()
                        rMedArchiveNew.IDApplication = rNewStayNew.IDApplication.Trim()
                        rMedArchiveNew.IDStayGuid = rNewStayNew.IDGuid

                        sqlObjects2.daMedArchiv.Update(dsObject2.tblMedArchiv)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: copy medarchive - IDGuid-medarchive: '" + rMedArchiveAct.IDGuid.ToString() + "'" +
                                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsObject1.tblMedArchiv.Count().ToString() + " medarchives for stay copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine
            Else
                Try
                    Dim rStayCheckParent7 = (From o4 In db.tblStay
                                             Where o4.IDGuid = rStayAct.IDGuid
                                             Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                                                o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).First()

                    Dim IDPartTmpNew As String = IDParticipantNew.Trim()
                    Dim IDPartTmpOld As String = IDParticipantOld.Trim()
                    Dim bSetParentNull As Boolean = False
                    If Not rStayCheckParent7.IDStayParent Is Nothing Then
                        'Dim rStayParentTmp = (From o4 In db.tblStay
                        '                      Where o4.ID = rStayCheckParent7.IDStayParent And o4.IDApplication = rStayCheckParent7.IDApplicationParent And
                        '                        o4.IDParticipant = IDPartTmpNew
                        '                      Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                        '                            o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).FirstOrDefault()
                        'If rStayParentTmp Is Nothing Then
                        '    sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                        '    'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                        '    '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                        '    '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                        '    'lStaysChildsRehanged.Add(rStayAct.IDGuid)
                        '    Return False
                        'End If

                        Dim stayPar As New StaysRehangDto() With {.IDGuidNew = rStayAct.IDGuid, .IDParticipantNew = IDParticipantNew, .IDStayNew = rStayCheckParent7.IDStayParent, .IDApplicationNew = rStayCheckParent7.IDApplicationParent}
                        lStaysChildsRehanged.Add(stayPar)
                        bSetParentNull = True

                        'For Each oStay As DTOs.StayDtoS1 In tStaysSqlCommand
                        '    If oStay.ID.Equals(rStayCheckParent7.IDStayParent) And oStay.IDApplication.Equals(rStayCheckParent7.IDApplicationParent) And
                        '        oStay.IDParticipant.Equals(rStayCheckParent7.IDParticipantParent) Then
                        '    End If
                        'Next

                        'Dim rStayCheckParent8 = (From o4 In db.tblStay
                        '                         Where o4.IDGuid = rStayAct.IDGuid
                        '                         Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                        '                            o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).First()

                        'Dim tStayCheckParentNew = (From o In db.tblStay
                        '                           Where o.ID = rStayCheckParent7.IDStayParent And
                        '                               o.IDApplication = rStayCheckParent7.IDApplicationParent And
                        '                               o.IDParticipant = IDPartTmpNew.Trim()
                        '                           Select o.IDGuid, o.ID, o.IDParticipantParent, o.IDApplicationParent, o.IDStayParent)
                        'If tStayCheckParentNew.Count() = 0 Then
                        '    Dim rStayCheckParentNew = tStayCheckParentNew.First()
                        '    sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                        '    'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                        '    '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                        '    '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                        '    lStaysNotCopied.Add(rStayCheckParentNew.IDGuid)
                        '    Return False
                        'End If

                        'Dim tStayCheckParentNew2 = (From o In db.tblStay
                        '                            Where o.ID = rStayCheckParent7.IDStayParent And
                        '                               o.IDApplication = rStayCheckParent7.IDApplicationParent And
                        '                               o.IDParticipant = IDPartTmpOld.Trim()
                        '                            Select o.IDGuid, o.ID, o.IDParticipantParent, o.IDApplicationParent, o.IDStayParent)
                        'If tStayCheckParentNew2.Count() = 0 Then
                        '    Dim rStayCheckParentNew = tStayCheckParentNew2.First()
                        '    sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                        '    'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                        '    '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                        '    '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                        '    lStaysNotCopied.Add(rStayCheckParentNew.IDGuid)
                        '    Return False
                        'End If
                    Else
                        Dim rStayChildTmp = (From o4 In db.tblStay
                                             Where o4.IDStayParent = rStayCheckParent7.ID And o4.IDApplicationParent = rStayCheckParent7.IDApplication2 And
                                                o4.IDParticipant = IDPartTmpNew
                                             Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                                                    o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).FirstOrDefault()
                        If Not rStayChildTmp Is Nothing Then
                            sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                            'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                            '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                            '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                            'lStaysChildsRehanged.Add(rStayAct.IDGuid)
                            Return False
                        End If

                        Dim rStayChildTmp2 = (From o4 In db.tblStay
                                              Where o4.IDStayParent = rStayCheckParent7.ID And o4.IDApplicationParent = rStayCheckParent7.IDApplication2 And
                                                o4.IDParticipant = IDPartTmpOld
                                              Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                                                    o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).FirstOrDefault()
                        If Not rStayChildTmp2 Is Nothing Then
                            sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                            'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                            '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                            '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                            'lStaysChildsRehanged.Add(rStayAct.IDGuid)
                            Return False
                        End If

                        'Dim tStayCheckParentNew = (From o In db.tblStay
                        '                           Where o.IDStayParent = rStayCheckParent7.ID And
                        '                               o.IDApplicationParent = rStayCheckParent7.IDApplication2 And
                        '                               o.IDParticipantParent = IDPartTmpNew.Trim()
                        '                           Select o.IDGuid, o.ID, o.IDParticipantParent, o.IDApplicationParent, o.IDStayParent)
                        'If tStayCheckParentNew.Count() > 0 Then
                        '    Dim rStayCheckParentNew = tStayCheckParentNew.First()
                        '    sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                        '    'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                        '    '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                        '    '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                        '    lStaysNotCopied.Add(rStayCheckParentNew.IDGuid)
                        '    Return False
                        'End If

                        'Dim tStayCheckParentNew2 = (From o In db.tblStay
                        '                            Where o.IDStayParent = rStayCheckParent7.ID And
                        '                               o.IDApplicationParent = rStayCheckParent7.IDApplication2 And
                        '                               o.IDParticipantParent = IDPartTmpOld.Trim()
                        '                            Select o.IDGuid, o.ID, o.IDParticipantParent, o.IDApplicationParent, o.IDStayParent)
                        'If tStayCheckParentNew2.Count() > 0 Then
                        '    Dim rStayCheckParentNew = tStayCheckParentNew2.First()
                        '    sProt += "Stay-IDGuid '" + rStayAct.IDGuid.ToString() + "' can not copied because ParentStay not exists for new participant '" + IDParticipantNew.Trim() + "'" + vbNewLine + vbNewLine
                        '    'Me.copyRehangStay(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                        '    '              dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                        '    '              IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)
                        '    lStaysNotCopied.Add(rStayCheckParentNew.IDGuid)
                        '    Return False
                        'End If
                    End If

                    Dim cmd As New SqlCommand()
                    cmd.Connection = qs2.core.dbBase.dbConn
                    If bSetParentNull Then
                        cmd.CommandText = " update qs2.tblStay set IDParticipant='" + IDParticipantNew.Trim() + "', PatIDGuid='" + IDPatientNewGuid.ToString() + "', IDStayParent=null, IDParticipantParent=null, IDApplicationParent=null " +
                                          " where IDGuid='" + rStayAct.IDGuid.ToString() + "' "
                    Else
                        cmd.CommandText = " update qs2.tblStay set IDParticipant='" + IDParticipantNew.Trim() + "', PatIDGuid='" + IDPatientNewGuid.ToString() + "' " +
                                          " where IDGuid='" + rStayAct.IDGuid.ToString() + "' "
                    End If
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    Throw New Exception("businessFramework.copyRehangStay: update tblStay - " + ex.ToString())
                End Try

                Dim lstTablesDistinct As New System.Collections.Generic.List(Of String)
                For Each tableName As String In lstTablesDistinct
                    Try
                        Dim sqlStayUpdate As String = "Update qs2." + tableName.Trim() + " set  IDParticipant='" + IDParticipantNew.Trim() + "' where ID=" + rStayAct.ID.ToString() + " and IDParticipant='" + rStayAct.IDParticipant.Trim() + "' and IDApplication='" + rStayAct.IDApplication.Trim() + "' "
                        Dim iResultUpdate As Integer = db.Database.ExecuteSqlCommand(sqlStayUpdate)

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang stay-table'" + tableName.Trim() + "' - IDGuid-stay: '" + rStayAct.IDGuid.ToString() + "'" +
                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                'Dim sqlStayDelete As String = "delete from qs2.tblStay where IDGuid='" + rNewStayNew.IDGuid.ToString() + "' "
                'Dim iResultDelete As Integer = db.Database.ExecuteSqlCommand(sqlStayDelete)
                sProt += "Stay '" + rStayAct.IDGuid.ToString() + " rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine
                IDStayNewGuid = rStayAct.IDGuid

                For Each rStayAdditionAct As dsAdmin.tblStayAdditionsRow In dsAdmin1.tblStayAdditions
                    Try
                        Dim rStayAdditionUpdate As qs2.db.Entities.tblStayAdditions = (From rStayAdd In db.tblStayAdditions Where rStayAdd.IDGuid = rStayAdditionAct.IDGuid).First()
                        rStayAdditionUpdate.IDParticipantStayParent = IDParticipantNew.Trim()
                        If Not rStayAdditionAct.IsIDApplicationStayChildNull() Then
                            rStayAdditionUpdate.IDParticipantStayChild = IDParticipantNew.Trim()
                        End If
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang ressources - IDGuid-stayaddition: '" + rStayAdditionAct.IDGuid.ToString() + "'" +
                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                For Each rSelListEntriesObj As dsAdmin.tblSelListEntriesObjRow In dsAdmin1.tblSelListEntriesObj
                    Try
                        Dim rSelListEntriesObjUpdate As qs2.db.Entities.tblSelListEntriesObj = (From rObj In db.tblSelListEntriesObj Where rObj.IDGuid = rSelListEntriesObj.IDGuid).First()
                        rSelListEntriesObjUpdate.IDParticipantStay = IDParticipantNew.Trim()
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang ressources - IDGuid-sellistentryobj: '" + rSelListEntriesObj.IDGuid.ToString() + "'" +
                                                            vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next

                For Each rMedArchiveAct As dsObjects.tblMedArchivRow In dsObject1.tblMedArchiv
                    Try
                        Dim IDStayGuidTmp As Guid = IDStayNewGuid
                        Dim rStayTmp9 = (From o4 In db.tblStay
                                         Where o4.IDGuid = IDStayGuidTmp
                                         Select o4.IDGuid, o4.ID, IDApplication2 = o4.IDApplication, o4.IDParticipant,
                                                o4.IDParticipantParent, o4.IDApplicationParent, o4.IDStayParent).First()

                        Dim rMedArchiveUpdate As qs2.db.Entities.tblMedArchiv = (From rMed In db.tblMedArchiv Where rMed.IDGuid = rMedArchiveAct.IDGuid).First()
                        rMedArchiveUpdate.IDStay = rStayTmp9.ID
                        rMedArchiveUpdate.IDParticipant = rStayTmp9.IDParticipant()
                        rMedArchiveUpdate.IDApplication = rStayTmp9.IDApplication2.Trim()
                        rMedArchiveUpdate.IDStayGuid = rStayTmp9.IDGuid
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang medarchive - IDGuid-medarchive: '" + rMedArchiveAct.IDGuid.ToString() + "'" +
                                                            vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsObject1.tblMedArchiv.Count().ToString() + " medarchives for stay rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                Me.CopyStayObjectFields(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                                            dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                                            IDPatientNewGuid, IDStayNewGuid, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, lOldObjComboBoxesCopied)

                'Dim eStayType As qs2.core.Enums.eStayTyp = rStayAct.StayTyp
                'Dim rNewStayNew As qs2.core.vb.dsObjects.tblStayRow
                'Me.CopyStay(rStayAct.IDApplication, rStayAct, eStayType, IDPatientNewGuid, rNewStayNew, "")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.copyRehangStay: stay-IDGuid: '" + sExceptInfo + "'" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function CopyStayObjectFields(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                            ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                            ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                            ByRef dsObject1 As dsObjects, ByRef sqlObjects1 As sqlObjects, ByRef dsObject2 As dsObjects, ByRef sqlObjects2 As sqlObjects,
                                            ByRef dsAdmin1 As dsAdmin, ByRef sqlAdmin1 As sqlAdmin, ByRef dsAdmin2 As dsAdmin, ByRef sqlAdmin2 As sqlAdmin,
                                            rStayFound As DTOs.StayDtoS1, IDPatientNewGuid As Guid, IDStayNewGuid As Guid, ByRef IDGuidUsr As Guid,
                                            ByRef lStaysCopy As List(Of DTOs.StaysRehangDto), ByRef StaysRehangDto1 As DTOs.StaysRehangDto,
                                            ByRef sProt As String, ByRef lOldObjComboBoxesCopied As System.Collections.Generic.List(Of ObjectCopiedDto)) As Boolean
        Dim sExceptInfo As String = "stay-IDGuid: '" + rStayFound.IDGuid.ToString() + "' "
        Try
            Dim dsAdminObjectFields As New dsAdmin()
            Dim ServiceInput As New qs2.core.vb.QS2Service1.cServiceInput()
            Dim b As New qs2.core.vb.businessFramework()
            b.getObjectFields(ServiceInput, False, True, dsAdminObjectFields)
            For Each rSelList As dsAdmin.tblSelListEntriesRow In dsAdminObjectFields.tblSelListEntries
                Try
                    Dim sqlStayFld As String = "Select " + rSelList.FldShortColumn.Trim() + " from qs2." + rSelList._Table.Trim() + " where ID=" + rStayFound.ID.ToString() + " and IDApplication='" + IDApplication.Trim() + "' and IDParticipant='" + IDParticipantNew.Trim() + "' "
                    Dim tStysFld As List(Of Integer) = db.Database.SqlQuery(Of Integer)(sqlStayFld).ToList
                    If tStysFld.Count() > 0 Then
                        Dim IDObjectToCopy As Integer = tStysFld.First()
                        If IDObjectToCopy <> -1 Then
                            Dim tObjToCopy = (From o In db.tblObject
                                              Where o.ID = IDObjectToCopy
                                              Select o.IDGuid, o.ID)

                            If tObjToCopy.Count() = 1 Then
                                Dim rObjToCopy = tObjToCopy.First()

                                Dim IDPatientNewGuidCboBox As Guid = Nothing
                                Dim IDPatientNewIDdBack As Integer = -1
                                Dim IDPatientCboBox As Guid = rObjToCopy.IDGuid

                                Dim tCheckOldObj = (From o In lOldObjComboBoxesCopied
                                                    Where o.IDOld = rObjToCopy.ID
                                                    Select o.IDGuidOld, o.IDOld, o.IDGuidNew, o.IDNew)
                                If tCheckOldObj.Count() = 0 Then
                                    Me.copyRehangPatient(db, IDParticipantOld, IDParticipantNew, SqlWhere, IDApplication, NoStaysFound, doCopy, dNow, tStaysSqlCommand,
                                             dsObject1, sqlObjects1, dsObject2, sqlObjects2, dsAdmin1, sqlAdmin1, dsAdmin2, sqlAdmin2, rStayFound,
                                             IDPatientNewGuidCboBox, IDGuidUsr, lStaysCopy, StaysRehangDto1, sProt, Nothing, IDPatientCboBox, IDPatientNewIDdBack)

                                    lOldObjComboBoxesCopied.Add(New ObjectCopiedDto() With {.IDOld = rObjToCopy.ID, .IDGuidOld = rObjToCopy.IDGuid,
                                                                                            .IDNew = IDPatientNewIDdBack, .IDGuidNew = IDPatientNewGuidCboBox})
                                ElseIf tCheckOldObj.Count() = 1 Then
                                    Dim ObjectCopiedDtoAct = tCheckOldObj.First()
                                    IDPatientNewGuidCboBox = ObjectCopiedDtoAct.IDGuidNew
                                Else
                                    Throw New Exception("CopyStayObjectFields: tCheckOldObj.Count()>1 not allowed for IDObjectOld '" + rObjToCopy.ID.ToString() + "'!")
                                End If

                                Dim rObjCopied = (From o In db.tblObject
                                                  Where o.IDGuid = IDPatientNewGuidCboBox
                                                  Select o.IDGuid, o.ID).First()

                                Dim updateStayFld As String = "update qs2." + rSelList._Table.Trim() + " set " + rSelList.FldShortColumn.Trim() + "=" + rObjCopied.ID.ToString() + " where ID=" + rStayFound.ID.ToString() + " and IDApplication='" + IDApplication.Trim() + "' and IDParticipant='" + IDParticipantNew.Trim() + "' "
                                Dim iRes As Integer = db.Database.ExecuteSqlCommand(updateStayFld)

                            ElseIf tObjToCopy.Count() > 1 Then
                                Throw New Exception("CopyStayObjectFields: not allowed for object-ID '" + IDObjectToCopy.ToString() + "'!")
                            Else
                                Dim bObjIDNotFound As Boolean = True
                            End If
                        End If
                    End If

                Catch ex As Exception
                    Throw New Exception("businessFramework.CopyStayObjectFields: rehang Stay copy objfields - IDGuid-Stay: error write object-combobox-field '" + rSelList.FldShortColumn.Trim() + "' for table '" + rSelList._Table.Trim() + "'" +
                                                                vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                End Try
            Next

        Catch ex As Exception
            Throw New Exception("businessFramework.CopyStayObjectFields: stay-IDGuid: '" + sExceptInfo + "'" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function CopyRehangDeleteOldPatient(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                                ByRef IDParticipantOld As String, ByRef IDParticipantNew As String,
                                                ByRef lPatientsDelete As System.Collections.Generic.List(Of Guid),
                                                ByRef sProt As String) As Boolean

        For Each IDGuidPatient As Guid In lPatientsDelete
            Dim rObj = (From o In db.tblObject
                        Where o.IDGuid = IDGuidPatient
                        Select o.IDGuid, o.ID).First()

            Dim sExceptInfo As String = "Object-IDGuid: '" + IDGuidPatient.ToString() + "' "

            Dim tStaysPatient = (From o In db.tblStay
                                 Where o.PatIDGuid = IDGuidPatient
                                 Select o.IDGuid, o.ID)

            If tStaysPatient.Count() = 0 Then
                Dim sqlDelSelListObj As String = "delete from qs2.tblSelListEntriesObj where IDObject=" + rObj.ID.ToString() + " "
                Dim iRes1 As Integer = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                Dim sqlDelPatient As String = "delete from qs2.tblObject where IDGuid='" + rObj.IDGuid.ToString() + "' "
                Dim iRes2 As Integer = db.Database.ExecuteSqlCommand(sqlDelPatient)
            End If
        Next
        sProt += "---------- " + lPatientsDelete.Count().ToString() + " old patients cleared (no stays For old participant found For this patients)" + vbNewLine + vbNewLine

    End Function
    Public Function copyRehangStayMasterdata(ByRef db As qs2.db.Entities.ERModellQS2Entities,
                                                ByRef IDParticipantOld As String, ByRef IDParticipantNew As String, ByRef SqlWhere As String, ByRef IDApplication As String,
                                                ByRef NoStaysFound As Boolean, ByRef doCopy As Boolean, ByRef dNow As DateTime, ByRef tStaysSqlCommand As List(Of DTOs.StayDtoS1),
                                                ByRef dsObject1 As dsObjects, ByRef sqlObjects1 As sqlObjects, ByRef dsObject2 As dsObjects, ByRef sqlObjects2 As sqlObjects,
                                                ByRef dsAdmin1 As dsAdmin, ByRef sqlAdmin1 As sqlAdmin, ByRef dsAdmin2 As dsAdmin, ByRef sqlAdmin2 As sqlAdmin,
                                                ByRef dsLanguage1 As language.dsLanguage, sqlLanguage1 As language.sqlLanguage,
                                                ByRef dsLanguage2 As language.dsLanguage, sqlLanguage2 As language.sqlLanguage,
                                                ByRef rStayFound As DTOs.StayDtoS1, ByRef IDPatientNewGuid As Guid, ByRef IDStayNewGuid As Guid, ByRef IDGuidUsr As Guid,
                                                ByRef lStaysCopy As List(Of DTOs.StaysRehangDto), ByRef StaysRehangDto1 As DTOs.StaysRehangDto, ByRef sProt As String) As Boolean
        Dim sExceptInfo As String = "stay-IDGuid: '" + rStayFound.IDGuid.ToString() + "' "
        Try
            dsObject1.Clear()
            dsObject2.Clear()
            dsAdmin1.Clear()
            dsAdmin2.Clear()
            dsLanguage1.Clear()
            dsLanguage2.Clear()

            sqlAdmin1.getSelListEntrys(New sqlAdmin.ParametersSelListEntries(), "", IDParticipantOld.Trim(), "", dsAdmin1, sqlAdmin.eTypAuswahlList.IDParticipantUserSelList, "", -1, "", -1, "", "", False)
            sqlAdmin2.getSelListEntrys(New sqlAdmin.ParametersSelListEntries(), "", IDParticipantOld.Trim(), "", dsAdmin2, sqlAdmin.eTypAuswahlList.id, "", -1, "", -500023, "", "", False)

            sqlLanguage1.getLanguage("", dsLanguage1, language.sqlLanguage.eTypSelLang.IDParticipant, Enums.eResourceType.All, "", IDParticipantOld.Trim())
            sqlLanguage2.getLanguage(System.Guid.NewGuid.ToString(), dsLanguage2, language.sqlLanguage.eTypSelLang.IDRes, Enums.eResourceType.All, "", "")

            Dim doCopyTmp As Boolean = True
            If doCopyTmp Then
                For Each rSelListAct As dsAdmin.tblSelListEntriesRow In dsAdmin1.tblSelListEntries
                    Try
                        dsAdmin2.Clear()
                        Dim rSelListNew As dsAdmin.tblSelListEntriesRow = sqlAdmin2.getNewRowSelList(dsAdmin2, False)
                        rSelListNew.ItemArray = rSelListAct.ItemArray
                        rSelListNew.IDGuid = System.Guid.NewGuid()

                        Dim rGroup As tblSelListGroup = (From grp In db.tblSelListGroup Where grp.ID = rSelListAct.IDGroup
                                                         Order By grp.ID).First()

                        Dim IDStayNewGuidTmp As Guid = IDStayNewGuid
                        Dim rStayNew As tblStay = (From o In db.tblStay Where o.IDGuid = IDStayNewGuidTmp).First()

                        Dim bCriteriaFound As Boolean = False
                        Dim bCopySelListEntry As Boolean = False
                        Dim FldShortTmp As String = ""
                        Dim rCriteria As tblCriteria = (From o In db.tblCriteria Where o.FldShort = rGroup.IDGroupStr And o.IDApplication = rStayNew.IDApplication And o.ControlType = "ComboBox").FirstOrDefault()
                        If rCriteria Is Nothing Then
                            rCriteria = (From o In db.tblCriteria Where o.FldShort = rGroup.IDGroupStr And o.IDApplication = "ALL" And o.ControlType = "ComboBox").FirstOrDefault()
                            If Not rCriteria Is Nothing Then
                                bCriteriaFound = True
                                If rCriteria.AliasFldShort.Trim() <> "" Then
                                    FldShortTmp = rCriteria.AliasFldShort.Trim()
                                    bCopySelListEntry = True
                                End If
                            End If
                        Else
                            bCriteriaFound = True
                            If rCriteria.AliasFldShort.Trim() <> "" Then
                                FldShortTmp = rCriteria.AliasFldShort.Trim()
                                bCopySelListEntry = True
                            Else
                                FldShortTmp = rCriteria.FldShort.Trim()
                                bCopySelListEntry = True
                            End If
                        End If

                        If bCopySelListEntry Then
                            Dim checkSelListEntry As String = "Select " + FldShortTmp.Trim() + " from qs2." + IDApplication.Trim() + "_STAYS where ID=" + rStayNew.ID.ToString() + " and IDApplication='" + rStayNew.IDApplication.Trim() + "' and IDParticipant='" + rStayNew.IDParticipant.Trim() + "' "
                            Dim tSelListEntryCheck As List(Of Integer) = db.Database.SqlQuery(Of Integer)(checkSelListEntry).ToList
                            If tSelListEntryCheck.Count() = 1 Then
                                Dim iValueSelListEntry As Integer = tSelListEntryCheck.First()
                                If iValueSelListEntry <> -1 And rSelListAct.IDOwnInt = iValueSelListEntry Then
                                    Dim IDPartNewTmp As String = IDParticipantNew
                                    Dim tSelListSearch As List(Of tblSelListEntries) = (From sl In db.tblSelListEntries
                                                                                        Where sl.IDRessource = rSelListNew.IDRessource And
                                                                                        sl.IDParticipant = IDPartNewTmp And
                                                                                        sl.IDGroup = rSelListNew.IDGroup).ToList()
                                    If tSelListSearch.Count() = 0 Then
                                        rSelListNew.IDParticipant = IDParticipantNew.Trim()

                                        Dim IDOwnStrNext As String = ""
                                        Dim NextIDOwnInt As Integer = sqlAdmin1.getNextIDOwnIntSelList(rGroup.ID, True, False)
                                        Dim bSearchSelListID As Boolean = True
                                        Dim IDSelListNextCalculated As Integer = -999
                                        sqlAdmin1.getNextIDSelListGeneric(IDSelListNextCalculated, IDOwnStrNext, NextIDOwnInt, rGroup.ID)
                                        While bSearchSelListID
                                            Dim tSelListCheckID As List(Of tblSelListEntries) = (From sl In db.tblSelListEntries
                                                                                                 Where sl.ID = IDSelListNextCalculated).ToList()
                                            If tSelListCheckID.Count() > 0 Then
                                                NextIDOwnInt += 1
                                                sqlAdmin1.getNextIDSelListGeneric(IDSelListNextCalculated, IDOwnStrNext, NextIDOwnInt, rGroup.ID)
                                            Else
                                                bSearchSelListID = False
                                            End If
                                        End While

                                        rSelListNew.ID = IDSelListNextCalculated
                                        'rSelListNew.IDOwnInt = NextIDOwnInt
                                        rSelListNew.sort = Me.getLastSortNumberSelListEntry(db, rGroup.ID)
                                        rSelListNew.IDParticipant = IDParticipantNew.Trim()
                                        sqlAdmin2.daSelListEntrys.Update(dsAdmin2.tblSelListEntries)
                                    Else
                                        Dim bExists As Boolean = True
                                    End If
                                End If

                            ElseIf tSelListEntryCheck.Count() = 0 Then
                                Dim bSelListStayNoValue As Boolean = True
                            Else
                                Throw New Exception("copyRehangStayMasterdata: not allowed!")
                            End If
                        End If

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStayMasterdata: copy IDGuid-SelListEntry: '" + rSelListAct.IDGuid.ToString() + "'" +
                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsAdmin1.tblSelListEntries.Count().ToString() + " sellistentries copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                For Each rResAct As language.dsLanguage.RessourcenRow In dsLanguage1.Ressourcen
                    Try
                        Dim IDPartTmp As String = IDParticipantNew
                        Dim tResSearch As List(Of Ressourcen) = (From s In db.Ressourcen
                                                                 Where s.IDRes = rResAct.IDRes And
                                                                    s.IDParticipant = IDPartTmp And s.IDApplication = rResAct.IDApplication And
                                                                    s.IDLanguageUser = rResAct.IDLanguageUser And s.Type = rResAct.Type).ToList()
                        dsLanguage2.Clear()
                        If tResSearch.Count() = 0 Then
                            Dim rResNew As language.dsLanguage.RessourcenRow = sqlLanguage2.newRowLanguage(dsLanguage2, "", "", "", "", "", Enums.eResourceType.Label, Enums.eTypeSub.None, "")
                            rResNew.ItemArray = rResAct.ItemArray
                            rResNew.IDGuid = System.Guid.NewGuid()
                            rResNew.IDParticipant = IDParticipantNew.Trim()

                            sqlLanguage2.daLanguage.Update(dsLanguage2.Ressourcen)
                        Else
                            Dim bExists As Boolean = True
                        End If

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStayMasterdata: copy ressources - IDGuid-ressource: '" + rResAct.IDGuid.ToString() + "'" +
                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsLanguage1.Ressourcen.Count().ToString() + " ressources copied for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine
            Else
                Throw New Exception("copyRehangStayMasterdata: Fct rehang Masterdata not activated!")

                For Each rSelListAct As dsAdmin.tblSelListEntriesRow In dsAdmin1.tblSelListEntries
                    Try
                        Dim rSelListEntry As qs2.db.Entities.tblSelListEntries = (From rStayAdd In db.tblSelListEntries Where rStayAdd.IDGuid = rSelListAct.IDGuid).First()
                        rSelListEntry.IDParticipant = IDParticipantNew.Trim()
                        db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang IDGuid-sellistentry: '" + rSelListAct.IDGuid.ToString() + "'" +
                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsAdmin1.tblSelListEntries.Count().ToString() + " selListEntries rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine

                For Each rResAct As language.dsLanguage.RessourcenRow In dsLanguage1.Ressourcen
                    Try
                        Dim cmd As New SqlCommand()
                        cmd.Connection = qs2.core.dbBase.dbConn
                        cmd.CommandText = " update qs2.Ressourcen set IDParticipant='" + IDParticipantNew.Trim() + "' where IDGuid='" + rResAct.IDGuid.ToString() + "' "
                        cmd.ExecuteNonQuery()

                        'Dim rResUpdate As qs2.db.Entities.Ressourcen = (From rRes In db.Ressourcen Where rRes.IDGuid = rResAct.IDGuid).First()
                        'rResUpdate.IDParticipant = IDParticipantNew.Trim()
                        'db.SaveChanges()

                    Catch ex As Exception
                        Throw New Exception("businessFramework.copyRehangStay: rehang IDGuid-ressource: '" + rResAct.IDGuid.ToString() + "'" +
                                                                    vbNewLine + "" + sExceptInfo + vbNewLine + ex.ToString())
                    End Try
                Next
                sProt += dsLanguage1.Ressourcen.Count().ToString() + " ressources rehang for participant " + IDParticipantNew.Trim() + "" + vbNewLine + vbNewLine
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("businessFramework.copyRehangStayMasterdata: stay-IDGuid: '" + sExceptInfo + "'" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getLastSortNumberSelListEntry(ByRef db As qs2.db.Entities.ERModellQS2Entities, IDGroup As Integer) As Integer

        Dim LastNr As Integer = 0
        Dim tSelListEntries As List(Of qs2.db.Entities.tblSelListEntries) = (From rStayAdd In db.tblSelListEntries Where rStayAdd.IDGroup = IDGroup).ToList()
        For Each rSelListAct As tblSelListEntries In tSelListEntries
            If rSelListAct.sort > LastNr Then
                LastNr = rSelListAct.sort
            End If
        Next
        Return LastNr

    End Function

    Public Function getNextIDSelList(ByRef db As qs2.db.Entities.ERModellQS2Entities, IDGroup As Integer) As Integer
        Try

            'Achtung: diese Funktion darf nur für das Kopieren von Queries verwendet werden.
            'Bei AdminSecure würde sie eine neunstellige (statt achtstellige) Zahl zurückgeben, wenn es bereits eine Userdefinierte Query gibt!!!!

            Dim rSelListGrp = (From s In db.tblSelListGroup
                               Where s.ID = IDGroup Order By s.ID Descending
                               Select ID = s.ID, s.IDRessource, IDGuid = s.IDGuid).ToList().First()

            Dim tSelListEntries = (From s In db.tblSelListEntries
                                   Join sg In db.tblSelListGroup On sg.ID Equals s.IDGroup
                                   Where sg.ID = rSelListGrp.ID Order By s.ID Descending
                                   Select ID2 = s.ID, s.IDRessource, IDGuid2 = s.IDGuid).ToList()

            Dim newIDSelList As Integer = 0
            If tSelListEntries.Count > 0 Then
                newIDSelList = tSelListEntries.First().ID2 + 1
            Else
                newIDSelList = System.Convert.ToInt32(rSelListGrp.ID.ToString() + 1.ToString().PadLeft(IIf(qs2.core.vb.actUsr.IsAdminSecureOrSupervisor(), 4, 5), "0").ToString())
            End If

            Return newIDSelList

        Catch ex As Exception
            Throw New Exception("getNextIDSelList: " + ex.ToString())
        End Try
    End Function

    Public Sub updateStayField(FldShort As String, oValue As Object, IDStay As Integer, IDParticipant As String, IDApplication As String)

        If businessFramework.sqlSysDB1 Is Nothing Then
            businessFramework.dsSysDB1 = New SysDB.dsSysDB()
            businessFramework.sqlSysDB1 = New SysDB.sqlSysDB()
            businessFramework.sqlSysDB1.initControl()
        End If

        businessFramework.dsSysDB1.Clear()
        sqlSysDB1.getSysColumns("", businessFramework.dsSysDB1, SysDB.sqlSysDB.eTypSelColumns.ColumnTablenameLike, FldShort.Trim(), IDApplication.Trim())
        Dim rColumn As SysDB.dsSysDB.COLUMNSRow = businessFramework.dsSysDB1.COLUMNS.Rows(0)

        Dim sql As String = " update qs2." + rColumn.TABLE_NAME.Trim() + " set " + rColumn.COLUMN_NAME + " = @Value " +
                            " where ID=@IDStay and IDApplication=@IDApplication and IDParticipant=@IDParticipant"

        Dim cmdUpdate As New SqlCommand(sql, qs2.core.dbBase.dbConn)
        cmdUpdate.Parameters.AddWithValue("@Value", oValue)
        cmdUpdate.Parameters.AddWithValue("@IDStay", IDStay.ToString())
        cmdUpdate.Parameters.AddWithValue("@IDApplication", IDApplication)
        cmdUpdate.Parameters.AddWithValue("@IDParticipant", IDParticipant)
        cmdUpdate.ExecuteNonQuery()
    End Sub

    Public Sub TestUpdateStay()
        Me.updateStayField("TransferProtocol", 23, 93082, "94020", "CARDIAC")
        Me.updateStayField("DocID", "xy", 93082, "94020", "CARDIAC")
        Me.updateStayField("NoErrors", 123, 93082, "94020", "CARDIAC")
        Me.updateStayField("StayComplete", True, 93082, "94020", "CARDIAC")
        Me.updateStayField("CreatLstmgdl", 12.34, 93082, "94020", "CARDIAC")
        Me.updateStayField("LogEuroScoreEstimated_II_Date", New Date(2020, 3, 14, 2, 3, 4), 93082, "94020", "CARDIAC")
    End Sub

    Public Function checkRolesReportDocu(IDReportDocu As Integer, ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj)) As Boolean
        Try
            If ENV.adminSecure Then
                Return True
            End If

            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim tSelListEntryObj_Roles = (From o In db.tblSelListEntriesObj
                                              Join s In db.tblSelListEntries On o.IDSelListEntrySublist Equals s.ID
                                              Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                                              Where o.IDSelListEntrySublist = IDReportDocu And o.typIDGroup = "Roles" And (sg.IDGroupStr = "Reports" Or sg.IDGroupStr = "Documents") And
                                                        o.IDParticipant = license.doLicense.rParticipant.IDParticipant
                                              Select o.IDSelListEntry, o.IDSelListEntrySublist, o.IDGuid).ToList()

                If tSelListEntryObj_Roles.Count() = 0 Then
                    Return True
                Else
                    For Each cRoleUsr As cSelListAndObj In lstRolesForUserActive
                        Dim tSelListEntryObj = (From o In tSelListEntryObj_Roles
                                                Where o.IDSelListEntry = cRoleUsr.rSelList.ID
                                                Select o.IDSelListEntry, o.IDSelListEntrySublist, o.IDGuid).ToList()

                        If tSelListEntryObj.Count() > 0 Then
                            Return True
                        End If
                    Next
                End If

            End With

            Return False

        Catch ex As Exception
            Throw New Exception("businessFramework.checkRolesReportDocu: " + ex.ToString())
        End Try
    End Function

    Public Function checkUserRightsReportDocu(IDReportDocu As Integer) As Boolean
        Try
            If ENV.adminSecure Then
                Return True
            End If

            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                If (From o In db.tblSelListEntriesObj
                    Join s In db.tblSelListEntries On o.IDSelListEntry Equals s.ID
                    Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                    Where o.IDSelListEntry = IDReportDocu And o.typIDGroup = "UserDocuments" And sg.IDGroupStr = "Documents" And o.IDParticipant = license.doLicense.rParticipant.IDParticipant
                    Select o.IDSelListEntry, o.IDSelListEntrySublist, o.IDGuid).ToList().Count() = 0 Then

                    Return True
                Else
                    Return (From o In db.tblSelListEntriesObj
                            Join s In db.tblSelListEntries On o.IDSelListEntry Equals s.ID
                            Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                            Where o.IDSelListEntry = IDReportDocu And o.typIDGroup = "UserDocuments" And sg.IDGroupStr = "Documents" And
                                                      o.IDObject = actUsr.rUsr.ID And o.IDParticipant = license.doLicense.rParticipant.IDParticipant
                            Select o.IDSelListEntry, o.IDSelListEntrySublist, o.IDGuid).ToList().Count > 0
                End If
            End With

        Catch ex As Exception
            Throw New Exception("businessFramework.checkUserRightsReportDocu: " + ex.ToString())
        End Try
    End Function

    Public Function CreateNewProduct(App As String, ByRef sProt As String) As Boolean
        Try
            Dim dNow As Date = Now

            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim iGrp = (From o In db.tblSelListGroup Order By o.ID Descending
                            Select o.ID).Distinct.ToList().Last()
                Dim nextGrp As Integer = ((CInt(iGrp / 100) + 3) * 100)

                Dim IDSelListEntryProcGrp0 As Integer = -1
                Dim IDSelListEntryProcGrp1 As Integer = -1
                Dim IDSelListEntryChapter0 As Integer = -1
                Dim IDSelListEntryChapter1 As Integer = -1

                ' Add ProcGroup0
                Dim newGrp As tblSelListGroup = Me.AddSelListGrp(App, nextGrp, "ProcGrp0", "Chapters0;Criterias;Procedures;",
                                                                 "sort", "", db, True, sProt, dNow)

                Dim nextID As Integer = CInt(nextGrp.ToString() + "0001")
                Dim newSelList As tblSelListEntries = Me.AddSelListEntry(App, nextID, "procGrpNC_A", "Supervisor",
                                                                        1, "A", -1, "chaptA", newGrp.ID, newGrp.IDGroupStr,
                                                                        "tblStay_NC_1", db, True, sProt, dNow)
                IDSelListEntryProcGrp0 = newSelList.ID

                Dim newRes As Ressourcen = Me.AddRessource("ALL", "procGrpNC_A", "A", "A", "ALL", "Label", "", "", db, True, sProt, dNow)

                ' Add ProcGroup1
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "ProcGrp1", "Chapters1;Criterias;Procedures;",
                                            "sort", "", db, True, sProt, dNow)

                nextID = CInt(nextGrp.ToString() + "0001")
                newSelList = Me.AddSelListEntry(App, nextID, "procGrpNC_FUP1", "Supervisor",
                                                1, "FUP1", -1, "NC_FUP1", newGrp.ID, newGrp.IDGroupStr,
                                                "tblStay_NC_FUP1", db, True, sProt, dNow)
                IDSelListEntryProcGrp1 = newSelList.ID

                newRes = Me.AddRessource("ALL", "procGrpNC_FUP1", "FUP1", "FUP1", "ALL", "Label", "", "", db, True, sProt, dNow)

                ' Add Chapter0
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Chapters0", "Criterias;",
                                            "sort", "", db, True, sProt, dNow)

                nextID = CInt(nextGrp.ToString() + "0001")
                newSelList = Me.AddSelListEntry(App, nextID, "chaptNC_A", "Supervisor",
                                                1, "A", -1, "", newGrp.ID, newGrp.IDGroupStr,
                                                "", db, True, sProt, dNow)
                IDSelListEntryChapter0 = newSelList.ID

                newRes = Me.AddRessource("ALL", "chaptNC_A", "A", "A", "ALL", "Label", "", "", db, True, sProt, dNow)

                ' Add Chapter1
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Chapters1", "Criterias;",
                                                                 "sort", "", db, True, sProt, dNow)

                nextID = CInt(nextGrp.ToString() + "0001")
                newSelList = Me.AddSelListEntry(App, nextID, "chaptNC_FUP1", "Supervisor",
                                                1, "FUP1", -1, "", newGrp.ID, newGrp.IDGroupStr,
                                                "", db, True, sProt, dNow)
                IDSelListEntryChapter1 = newSelList.ID

                newRes = Me.AddRessource("ALL", "chaptNC_FUP1", "FUP1", "FUP1", "ALL", "Label", "", "", db, True, sProt, dNow)

                ' Add Procedures
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Procedures", "Criterias;",
                                            "sort", "", db, True, sProt, dNow)
                ' Add Queries
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Queries", "Roles;",
                                            "sort", "Admin;User;", db, True, sProt, dNow)

                ' Add QueryGroups
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "QueryGroups", "Queries;",
                                            "sort", "", db, True, sProt, dNow)

                ' Add Reports
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Reports", "Queries;Roles;",
                                            "sort", "", db, True, sProt, dNow)

                ' Add ReportGroups  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "ReportGroups", "Reports;",
                                            "sort", "", db, True, sProt, dNow)

                ' Add SimpleFunctions  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "SimpleFunctions", "",
                                            "sort", "", db, True, sProt, dNow)

                ' Add SimpleQueries  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "SimpleQueries", "",
                                            "sort", "", db, True, sProt, dNow)

                ' Add Documents  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "Documents", "Queries;Roles;",
                                            "sort", "Admin;User;", db, True, sProt, dNow)

                ' Add DocumentGroups  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "DocumentGroups", "Documents;",
                                            "sort", "", db, True, sProt, dNow)

                ' Add DocumentDirectories  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "DocumentDirectories", "",
                                            "sort", "", db, True, sProt, dNow)

                ' Add AnonymousColumns  
                nextGrp += 1
                newGrp = Me.AddSelListGrp(App, nextGrp, "AnonymousColumns", "",
                                            "sort", "", db, True, sProt, dNow)

                ' Add Criterias  
                nextGrp += 1
                Dim newCriteria As tblCriteria = Me.addCriteria(App, "chaptA", "CheckBox", db, True, sProt, dNow)
                newCriteria = Me.addCriteria(App, "NC_FUP1", "CheckBox", db, True, sProt, dNow)

                ' Add ProcGrps to Chapters
                Dim newSelListObj As tblSelListEntriesObj = Me.addSelListObj(IDSelListEntryChapter0, IDSelListEntryProcGrp0, "", "", "Chapters0", db, True, sProt, dNow)
                newSelListObj = Me.addSelListObj(IDSelListEntryChapter1, IDSelListEntryProcGrp1, "", "", "Chapters1", db, True, sProt, dNow)
            End With

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.createNewProduct: " + ex.ToString())
        End Try
    End Function

    Public Function AddSelListGrp(IDApplication As String, nextGrp As Integer, IDGroupStr As String,
                             Sublist As String, Sort As String, TypeEnum As String,
                             db As qs2.db.Entities.ERModellQS2Entities, saveChanges As Boolean,
                             ByRef sProt As String, dNow As Date) As tblSelListGroup
        Try
            Dim tSelListGrp As List(Of qs2.db.Entities.tblSelListGroup) = (From o In db.tblSelListGroup Where
                                                    o.IDApplication = IDApplication And o.IDGroupStr = IDGroupStr And
                                                    o.IDParticipant = "ALL" Order By o.IDGuid Descending).ToList()

            If tSelListGrp.Count() = 0 Then
                Dim newGrp As tblSelListGroup = EFEntities.newtblSelListGroup(db)
                newGrp.ID = nextGrp
                newGrp.IDGuid = System.Guid.NewGuid()
                newGrp.IDRessource = IDGroupStr
                newGrp.IDGroupStr = IDGroupStr
                newGrp.IDApplication = IDApplication
                newGrp.Sublist = Sublist
                newGrp.SortColumn = Sort
                newGrp.IDParticipant = "ALL"
                newGrp.TypeEnum = TypeEnum

                If saveChanges Then
                    db.tblSelListGroup.Add(newGrp)
                    db.SaveChanges()
                End If

                sProt += "SelListGroup '" + IDGroupStr + "' for Application '" + IDApplication + "' added" + vbNewLine
                Return newGrp
            Else
                sProt += "SelListGroup '" + IDGroupStr + "' for Application '" + IDApplication + "' already exists" + vbNewLine
                Return tSelListGrp.First()
            End If

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.addSelListGrp: " + ex.ToString())
        End Try
    End Function

    Public Function AddSelListEntry(IDApplication As String, nextID As Integer, IDRessource As String,
                                    TypeStr As String, Sort As Integer, IDOwnStr As String, IDOwnInt As Integer,
                                    ByRef FldShortColumn As String, IDGroup As Integer, IDGroupStr As String, Table As String,
                                    db As qs2.db.Entities.ERModellQS2Entities, saveChanges As Boolean,
                                    ByRef sProt As String, dNow As Date) As tblSelListEntries
        Try
            Dim tSelListEntry As List(Of qs2.db.Entities.tblSelListEntries) = (From o In db.tblSelListEntries Where
                                                    o.IDRessource = IDRessource And
                                                    o.IDParticipant = "ALL" And o.IDGroup = IDGroup Order By o.IDGuid Descending).ToList()

            If tSelListEntry.Count() = 0 Then
                Dim newSelList As tblSelListEntries = EFEntities.newtblSelListEntries(db)
                newSelList.ID = nextID
                newSelList.IDGuid = System.Guid.NewGuid()
                newSelList.IDRessource = IDRessource
                newSelList.sort = Sort
                newSelList.TypeStr = TypeStr
                newSelList.IDParticipant = "ALL"
                newSelList.IDOwnInt = IDOwnInt
                newSelList.IDOwnStr = IDOwnStr
                newSelList.FldShortColumn = FldShortColumn
                newSelList.Table = Table
                newSelList.IDGroup = IDGroup

                If saveChanges Then
                    db.tblSelListEntries.Add(newSelList)
                    db.SaveChanges()
                End If

                sProt += "SelListEntry '" + IDRessource + "' and IDGroup '" + IDGroupStr + "' added" + vbNewLine
                Return newSelList
            Else
                sProt += "SelListEntry '" + IDRessource + "' and IDGroup '" + IDGroupStr + "' already exists" + vbNewLine
                Return tSelListEntry.First()
            End If

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.addSelListGrp: " + ex.ToString())
        End Try
    End Function

    Public Function AddRessource(IDApplication As String, IDRes As String, German As String,
                                    English As String, IDParticipant As String, Type As String,
                                    FldShortColumn As String, Table As String,
                                    db As qs2.db.Entities.ERModellQS2Entities, saveChanges As Boolean,
                                    ByRef sProt As String, dNow As Date) As Ressourcen
        Try
            Dim tRes As List(Of qs2.db.Entities.Ressourcen) = (From o In db.Ressourcen Where o.IDRes = IDRes And o.IDApplication = IDApplication And o.IDParticipant = "ALL" And
                                                    o.IDLanguageUser = "ALL" And o.Type = "Label" Order By o.IDRes Descending).ToList()

            If tRes.Count() = 0 Then
                Dim newRes As Ressourcen = EFEntities.newRessourcen(db)
                newRes.IDRes = IDRes
                newRes.IDGuid = System.Guid.NewGuid()
                newRes.German = German
                newRes.English = English
                newRes.IDParticipant = IDParticipant
                newRes.IDParticipant = "ALL"
                newRes.IDLanguageUser = "ALL"
                newRes.Created = dNow
                newRes.LastChange = dNow
                newRes.IDApplication = IDApplication
                newRes.Type = "Label"

                If saveChanges Then
                    db.Ressourcen.Add(newRes)
                    db.SaveChanges()
                End If

                sProt += "Ressource '" + IDRes + "' added" + vbNewLine
                Return newRes
            Else
                sProt += "Ressource '" + IDRes + "' already exists" + vbNewLine
                Return tRes.First()
            End If

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.addRessource: " + ex.ToString())
        End Try
    End Function

    Public Function AddSelListObj(IDSelListEntry As Nullable(Of Integer),
                                    IDSelListEntrySublist As Nullable(Of Integer),
                                    FldShortCriteria As String, IDApplicationCriteria As String, typIDGroup As String,
                                    db As qs2.db.Entities.ERModellQS2Entities, saveChanges As Boolean,
                                    ByRef sProt As String, dNow As Date) As tblSelListEntriesObj
        Try
            'Dim tSelListObj As List(Of qs2.db.Entities.tblSelListEntriesObj) = (From o In db.tblSelListEntriesObj Where o.IDSelListEntry = IDSelListEntry And o.FldShort = FldShortCriteria And
            '                                        o.IDApplication = IDApplicationCriteria And o.typIDGroup = typIDGroup Order By o.IDGuid Descending).ToList()

            Dim tSelListObj As List(Of qs2.db.Entities.tblSelListEntriesObj) = (From o In db.tblSelListEntriesObj Where
                                                    o.IDSelListEntry = IDSelListEntry And o.typIDGroup = typIDGroup Order By o.IDGuid Descending).ToList()

            If tSelListObj.Count() = 0 Then
                Dim newSelListObj As tblSelListEntriesObj = EFEntities.newtblSelListEntriesObj(db)
                newSelListObj.IDSelListEntry = IDSelListEntry
                newSelListObj.IDSelListEntrySublist = IDSelListEntrySublist
                newSelListObj.IDGuid = System.Guid.NewGuid()
                newSelListObj.typIDGroup = typIDGroup
                If String.IsNullOrEmpty(FldShortCriteria) Or String.IsNullOrEmpty(IDApplicationCriteria) Then
                    newSelListObj.FldShort = Nothing
                    newSelListObj.IDApplication = Nothing
                Else
                    newSelListObj.FldShort = FldShortCriteria
                    newSelListObj.IDApplication = IDApplicationCriteria
                End If
                newSelListObj.Created = dNow
                newSelListObj.CreatedBy = "Auto"
                newSelListObj.Modified = dNow
                newSelListObj.ModifiedBy = "Auto"

                If saveChanges Then
                    db.tblSelListEntriesObj.Add(newSelListObj)
                    db.SaveChanges()
                End If

                sProt += "IDSelListEntry '" + IDSelListEntry.ToString() + "' added to SelListObj" + vbNewLine
                Return newSelListObj
            Else
                sProt += "Ressource '" + IDSelListEntry.ToString() + "' already exists in SelListObj" + vbNewLine
            End If

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.addSelListObj: " + ex.ToString())
        End Try
    End Function

    Public Function AddCriteria(IDApplication As String, FldShort As String, ControlType As String,
                                db As qs2.db.Entities.ERModellQS2Entities, saveChanges As Boolean,
                                ByRef sProt As String, dNow As Date) As tblCriteria
        Try
            Dim tCriteria As List(Of qs2.db.Entities.tblCriteria) = (From o In db.tblCriteria Where o.FldShort = FldShort And o.IDApplication = IDApplication
                                                                     Order By o.FldShort Descending).ToList()

            If tCriteria.Count() = 0 Then
                Dim newCriteria As tblCriteria = EFEntities.NewtblCriteria(db)
                newCriteria.FldShort = FldShort
                newCriteria.IDApplication = IDApplication
                newCriteria.ControlType = ControlType
                newCriteria.Used = True
                newCriteria.Editable = True
                newCriteria.ControlMinLength = -1
                newCriteria.ControlMaxLength = -1
                newCriteria.ControlMinVal = "-1"
                newCriteria.ControlMaxVal = "-1"

                If saveChanges Then
                    db.tblCriteria.Add(newCriteria)
                    db.SaveChanges()
                End If

                sProt += "FldShort '" + FldShort.ToString() + "' and Application '" + IDApplication + "' added to Criteria" + vbNewLine
                Return newCriteria
            Else
                sProt += "FldShort '" + FldShort.ToString() + "' and Application '" + IDApplication + "' already exists in Criteria" + vbNewLine
            End If

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.addCriteria: " + ex.ToString())
        End Try
    End Function

    Public Function RemoveProduct(App As String) As Boolean
        Try
            Dim db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim sqlDelSelListObj As String = "delete from qs2.tblStay where qs2.tblStay.IDApplication='" + App + "' "
                Dim iRes As Integer = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblSelListEntriesObj where IDSelListEntry in (Select qs2.tblSelListEntries.ID from qs2.tblSelListEntries, qs2.tblSelListGroup  where qs2.tblSelListEntries.IDGroup=qs2.tblSelListGroup.ID And qs2.tblSelListGroup.IDApplication='" + App + "') "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblSelListEntriesObj where IDSelListEntrySublist in (Select qs2.tblSelListEntries.ID from qs2.tblSelListEntries, qs2.tblSelListGroup  where qs2.tblSelListEntries.IDGroup=qs2.tblSelListGroup.ID And qs2.tblSelListGroup.IDApplication='" + App + "') "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblSelListEntries where IDGroup in (Select qs2.tblSelListGroup.ID from qs2.tblSelListGroup where qs2.tblSelListGroup.IDApplication='" + App + "') "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblSelListGroup where qs2.tblSelListGroup.IDApplication='" + App + "' "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblRelationship where qs2.tblRelationship.IDApplicationParent='" + App + "' "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblRelationship where qs2.tblRelationship.IDApplicationChild='" + App + "' "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.tblCriteria where qs2.tblCriteria.IDApplication='" + App + "' "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)

                sqlDelSelListObj = " delete from qs2.Ressourcen where qs2.Ressourcen.IDApplication='" + App + "' "
                iRes = db.Database.ExecuteSqlCommand(sqlDelSelListObj)
            End With

        Catch ex As System.Data.Entity.Validation.DbEntityValidationException
            Throw New System.Data.Entity.Validation.DbEntityValidationException(qs2.core.db.ERSystem.businessFramework.getDbEntityValidationException(ex), ex)
        Catch ex As Exception
            Throw New Exception("businessFramework.RemoveProduct: " + ex.ToString())
        End Try
    End Function

    Public Function CheckUserHasRightChapter(IDApplication As String, IDSelListChapter As Integer, lSelListEntryObj_RolesUsr As List(Of Integer),
                                             db As qs2.db.Entities.ERModellQS2Entities) As Boolean
        Try
            If ENV.adminSecure Then
                'Return True
            End If

            Dim tSelListEntryObj_ChaptersInRoles = (From o In db.tblSelListEntriesObj
                                                    Join s In db.tblSelListEntries On o.IDSelListEntrySublist Equals s.ID
                                                    Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                                                    Where o.IDSelListEntry = IDSelListChapter And lSelListEntryObj_RolesUsr.Contains(o.IDSelListEntrySublist) And
                                                      (o.typIDGroup = "Chapters0" Or o.typIDGroup = "Chapters1") And sg.IDGroupStr = "Roles"
                                                    Select o.IDSelListEntry).ToList()

            If tSelListEntryObj_ChaptersInRoles.Count() > 0 Then
                Dim tSelListEntryObj_ChapterToProcGroup = (From o In db.tblSelListEntriesObj
                                                           Join s In db.tblSelListEntries On o.IDSelListEntrySublist Equals s.ID
                                                           Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                                                           Where tSelListEntryObj_ChaptersInRoles.Contains(o.IDSelListEntry) And
                                                               (o.typIDGroup = "Chapters0" Or o.typIDGroup = "Chapters1") And
                                                                   (sg.IDGroupStr = "ProcGrp0" Or sg.IDGroupStr = "ProcGrp1") And sg.IDApplication = IDApplication
                                                           Select o.IDSelListEntry, o.IDSelListEntrySublist, o.IDGuid).ToList()

                Return tSelListEntryObj_ChapterToProcGroup.Count() > 0
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.CheckChapterAssignedToProcGroup: " + ex.ToString())
        End Try
    End Function

    Public Function GetRolesForUser(IDApplication As String, IDObject As Integer, db As qs2.db.Entities.ERModellQS2Entities) As List(Of Integer)
        Try
            Return (From o In db.tblSelListEntriesObj
                    Join s In db.tblSelListEntries On o.IDSelListEntry Equals s.ID
                    Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                    Where o.IDObject = IDObject And o.typIDGroup = "Roles" And sg.IDGroupStr = "Roles" And sg.IDApplication = "ALL"
                    Select o.IDSelListEntry).ToList()

        Catch ex As Exception
            Throw New Exception("businessFramework.GetRolesForUser: " + ex.ToString())
        End Try
    End Function
    Public Function GetRolesForUser2(IDApplication As String, IDObject As Integer, db As qs2.db.Entities.ERModellQS2Entities) As List(Of Nullable(Of Integer))
        Try
            Return (From o In db.tblSelListEntriesObj
                    Join s In db.tblSelListEntries On o.IDSelListEntry Equals s.ID
                    Join sg In db.tblSelListGroup On s.IDGroup Equals sg.ID
                    Where o.IDObject = IDObject And o.typIDGroup = "Roles" And sg.IDGroupStr = "Roles" And sg.IDApplication = "ALL"
                    Select s.IDOwnInt).ToList()

        Catch ex As Exception
            Throw New Exception("businessFramework.GetRolesForUser2: " + ex.ToString())
        End Try
    End Function

    Public Function CheckSelListNrInStays(IDApplication As String, IDParticipant As String, IDGoupStr As String, IDSelListEntry As Integer, IDOnwInt As Integer, IDGuidStayOpend As Nullable(Of Guid),
                                         db As qs2.db.Entities.ERModellQS2Entities, ByRef sProt As String) As Boolean
        Try
            If ENV.adminSecure Then
                Return True
            End If

            Dim rSelListEntry = (From o In db.tblSelListEntries
                                 Join s In db.tblSelListGroup On o.IDGroup Equals s.ID
                                 Where s.IDGroupStr = IDGoupStr And s.IDApplication = IDApplication And o.ID = IDSelListEntry
                                 Select o.IDOwnInt, IDPart = o.IDParticipant, o.IDGuid, o.ID).ToList().First()

            If String.IsNullOrEmpty(rSelListEntry.IDPart) Or rSelListEntry.IDPart.Equals("ALL", StringComparison.InvariantCultureIgnoreCase) Then
                Dim sTitleProt As String = qs2.core.language.sqlLanguage.getRes("SelListEntryCanNotDeletedPart")
                sProt = sTitleProt + vbNewLine
                Return False
            End If

            Dim rCriteria = (From c In db.tblCriteria
                             Where c.FldShort = IDGoupStr And (c.IDApplication = IDApplication Or c.IDApplication = "ALL")
                             Select c.FldShort, c.SourceTable, c.AliasFldShort).ToList().FirstOrDefault()

            If Not rCriteria Is Nothing Then
                If Not String.IsNullOrEmpty(rCriteria.AliasFldShort) Then
                    rCriteria = (From c In db.tblCriteria
                                 Where c.FldShort = rCriteria.AliasFldShort And (c.IDApplication = IDApplication Or c.IDApplication = "ALL")
                                 Select c.FldShort, c.SourceTable, c.AliasFldShort).ToList().FirstOrDefault()
                End If
            End If

            If Not rCriteria Is Nothing Then
                'If Not IDGuidStayOpend Is Nothing Then
                'Dim rStay = (From s In db.tblStay
                '                 Where s.IDGuid = IDGuidStayOpend
                '                 Select s.ID, s.IDParticipant, IDApp = s.IDApplication).ToList().First()
                'End If

                Dim SqlCmd As String = " Select " + rCriteria.FldShort + " as IDField, ID, IDParticipant, IDApplication from qs2." + rCriteria.SourceTable + " where " +
                                        "IDApplication='" + IDApplication + "' and IDParticipant='" + IDParticipant + "' and " + rCriteria.FldShort + "=" + rSelListEntry.IDOwnInt.ToString() + ""

                'Dim SqlCmd As String = " Select " + rCriteria.FldShort + " as IDField, ID, IDParticipant, IDApplication from qs2." + rCriteria.SourceTable + " where ID<>" + rStay.ID.ToString() + " and " +
                '                        "IDParticipant<>'" + rStay.IDParticipant + "' and IDApplication<>'" + rStay.IDApp + "' and rCriteria.FldShort =" + rSelListEntry.IDOwnInt.ToString() + ""

                Dim pars(0) As DbParameter
                pars(0) = New SqlParameter("", "")
                Dim tStays As List(Of DTOs.tInt) = db.Database.SqlQuery(Of DTOs.tInt)(SqlCmd, pars).ToList()
                If tStays.Count() > 0 Then
                    For Each rStayIDOwnInt In tStays
                        Dim rStaySameValue = (From s In db.tblStay
                                              Where s.ID = rStayIDOwnInt.ID And s.IDApplication = rStayIDOwnInt.IDApplication And s.IDParticipant = rStayIDOwnInt.IDParticipant
                                              Select s.ID, IDPartic = s.IDParticipant, IDApp = s.IDApplication, s.MedRecN, s.Incidence, s.StayTyp).ToList().First()

                        sProt += qs2.core.language.sqlLanguage.getRes("MedRecNr") + ": " + "" + rStaySameValue.MedRecN + ", " +
                                qs2.core.language.sqlLanguage.getRes("Incidence") + ": " + rStaySameValue.Incidence.ToString() + " " +
                                " (" + IIf(rStaySameValue.StayTyp = 0, qs2.core.language.sqlLanguage.getRes("Stay"), qs2.core.language.sqlLanguage.getRes("cmb_FollowUp")) + ")"
                    Next

                    Dim sTitleProt As String = qs2.core.language.sqlLanguage.getRes("StaysSameValueFldShort")
                    sProt = sTitleProt + vbNewLine + vbNewLine + sProt

                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("businessFramework.CheckSelListNrInStays: " + ex.ToString())
        End Try
    End Function

End Class
