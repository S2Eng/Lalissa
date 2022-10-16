
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

End Class
