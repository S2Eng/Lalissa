Imports qs2.core.db.ERSystem
Imports System.Data.Common
Imports System.Data.SqlClient
Imports PMDS.db.Entities
Imports qs2.core.vb.DTOs

Public Class businessFramework

    Private sqlAdminWork As qs2.core.vb.sqlAdmin = Nothing
    Private dsAllProcedures As qs2.core.vb.dsAdmin = Nothing
    Private dsAdminWork As qs2.core.vb.dsAdmin = Nothing
    Private sqlObjectsWork As sqlObjects = Nothing
    Private IsInitialized As Boolean = False
    Private _Application As String = ""
    Private _Participant As String = ""

    Private Delegate Sub StatusUI(txt As String)

    Public Class cSelListAndObj
        Public rSelList As dsAdmin.tblSelListEntriesRow = Nothing
    End Class

    Public Sub Inititialize(Application As String, Participant As String, loadAllProcedures As Boolean)
        Try
            If Me.IsInitialized Then
                Exit Sub
            End If

            Me.dsAllProcedures = New qs2.core.vb.dsAdmin()
            Me.dsAdminWork = New qs2.core.vb.dsAdmin()
            Me.sqlAdminWork = New qs2.core.vb.sqlAdmin()
            Me.sqlAdminWork.initControl()
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
                '    rNewProt.Txt = "IDRes '" + IDRes.Trim() + "' could not added to QS2-Database! (Table=Ressources, Application='" + Settings._Application.ToString() + "', TypeRes='" + ResourceTypeToLoad.ToString() + "'" + vbNewLine +
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

    Public Function getProductsForUser(IDGuidObject As System.Guid, db As PMDS.db.Entities.ERModellPMDSEntities) As IQueryable(Of PMDS.db.Entities.tblObjectApplications)
        Try
            Dim tObjectApplications As IQueryable(Of PMDS.db.Entities.tblObjectApplications) = From rObjectApplications In db.tblObjectApplications Where rObjectApplications.IDObjectGuid = IDGuidObject
            Return tObjectApplications

        Catch ex As Exception
            Throw New Exception("businessFramework.getProductsForUser: " + ex.ToString())
        End Try
    End Function

    Public Function checkSelListIsUsedInStays(IDSelList As Integer, ByRef sProt As String) As Boolean
        Try
            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
            With db
                Dim tSelListEntries As IQueryable(Of PMDS.db.Entities.tblSelListEntries) = Nothing
                tSelListEntries = From rSelListEntries In db.tblSelListEntries Where rSelListEntries.ID = IDSelList
                If tSelListEntries.Count <> 1 Then
                    Throw New Exception("checkSelListIsUsedInStays: IDSelList '" + IDSelList.ToString() + "' not exists in DB!")
                End If
                Dim rSelList As PMDS.db.Entities.tblSelListEntries = tSelListEntries.First()

                Dim tSelListGroup As IQueryable(Of PMDS.db.Entities.tblSelListGroup) = Nothing
                tSelListGroup = From rSelListGroup In db.tblSelListGroup Where rSelListGroup.ID = rSelList.IDGroup
                If tSelListGroup.Count <> 1 Then
                    Throw New Exception("checkSelListIsUsedInStays: rSelList.IDGroup '" + rSelList.IDGroup.ToString() + "' not exists in DB!")
                End If
                Dim rSelListGrp As PMDS.db.Entities.tblSelListGroup = tSelListGroup.First()

                Dim bIsUsedInStays As Boolean = Me.checkSelListIsUsedInStays(rSelList.IDOwnInt, db, rSelListGrp.IDGroupStr.Trim(), rSelListGrp.IDApplication.Trim(), False, sProt, rSelList.IDRessource.Trim())
                Dim bIsUsedInStaysAlias As Boolean = Me.checkSelListIsUsedInStays(rSelList.IDOwnInt, db, rSelListGrp.IDGroupStr.Trim(), rSelListGrp.IDApplication.Trim(), True, sProt, rSelList.IDRessource.Trim())
                Return bIsUsedInStays Or bIsUsedInStaysAlias
            End With

            Return False

        Catch ex As Exception
            Throw New Exception("businessFramework.checkSelListisusedInStays: " + ex.ToString())
        End Try
    End Function

    Public Function checkSelListIsUsedInStays(IDOwnInt As Integer, db As PMDS.db.Entities.ERModellPMDSEntities,
                                               FldShort As String, IDApplication As String, checkAlias As Boolean,
                                               ByRef sProt As String, ByRef IDResSelList As String) As Boolean
        Try
            Dim tCriteria As IQueryable(Of PMDS.db.Entities.tblCriteria) = Nothing
            If checkAlias Then
                tCriteria = From rCriteria In db.tblCriteria Where rCriteria.AliasFldShort = FldShort And rCriteria.IDApplication = IDApplication
            Else
                tCriteria = From rCriteria In db.tblCriteria Where rCriteria.FldShort = FldShort And rCriteria.IDApplication = IDApplication
            End If
            If tCriteria.Count > 1 Then
                Throw New Exception("checkSelListIsUsedInStays: tSelListEntries.Count>1 for FldShort '" + FldShort.Trim() + "' and IDApplication '" + IDApplication.Trim() + "'!")
            ElseIf tCriteria.Count = 1 Then
                Dim rCrit As PMDS.db.Entities.tblCriteria = tCriteria.First()
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

    Public Function checkRolesReportDocu(IDReportDocu As Integer, ByRef lstRolesForUserActive As System.Collections.Generic.List(Of cSelListAndObj)) As Boolean
        Try
            If ENV.adminSecure Then
                Return True
            End If

            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
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

            Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
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

    Public Function CheckUserHasRightChapter(IDApplication As String, IDSelListChapter As Integer, lSelListEntryObj_RolesUsr As List(Of Integer),
                                             db As PMDS.db.Entities.ERModellPMDSEntities) As Boolean
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

    Public Function GetRolesForUser(IDApplication As String, IDObject As Integer, db As PMDS.db.Entities.ERModellPMDSEntities) As List(Of Integer)
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

    Public Function CheckSelListNrInStays(IDApplication As String, IDParticipant As String, IDGoupStr As String, IDSelListEntry As Integer, IDOnwInt As Integer, IDGuidStayOpend As Nullable(Of Guid),
                                         db As PMDS.db.Entities.ERModellPMDSEntities, ByRef sProt As String) As Boolean
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
