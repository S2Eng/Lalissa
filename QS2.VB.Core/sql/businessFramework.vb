
Public Class businessFramework

    Public Class cSelListAndObj
        Public rSelList As dsAdmin.tblSelListEntriesRow = Nothing
    End Class

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

End Class
