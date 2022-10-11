

Public Class cTranslate


    Public Function saveTranslation(IDRes As String, translatedTxtGerm As String, translatedTxtEng As String, translatedTxtUser As String,
                                    IDApplication As String, doLoadAllRessources As Boolean) As Boolean
        Try
            Dim IDPartipantTmp = qs2.core.license.doLicense.eApp.ALL.ToString()
            Dim rLanguageFound As qs2.core.language.dsLanguage.RessourcenRow
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            Dim dsLanguage1 As New qs2.core.language.dsLanguage()
            sqlLanguage1.getLanguageRow(IDRes, dsLanguage1, IDApplication, IDPartipantTmp,
                                        core.Enums.eResourceType.Label.ToString(), Enums.eTypeSub.User, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                        False, False)

            If dsLanguage1.Ressourcen.Rows.Count = 0 Then
                rLanguageFound = sqlLanguage1.newRowLanguage(dsLanguage1, translatedTxtGerm.Trim(), IDRes, qs2.core.vb.actUsr.rUsr.UserName, IDApplication, IDPartipantTmp,
                                                             core.Enums.eResourceType.Label, core.Enums.eTypeSub.User, qs2.core.license.doLicense.eApp.ALL.ToString())
            ElseIf dsLanguage1.Ressourcen.Rows.Count = 1 Then
                rLanguageFound = dsLanguage1.Ressourcen.Rows(0)
            Else
                Throw New Exception("saveTranslation:  dsLanguage1.Ressourcen.Rows.Count = o or 1!  IDRes:" + IDRes + "'!")
            End If
            rLanguageFound.English = translatedTxtEng.Trim()
            rLanguageFound.German = translatedTxtGerm.Trim()
            rLanguageFound.User = translatedTxtUser.Trim()
            rLanguageFound.Created = System.DateTime.Now
            rLanguageFound.CreatedUser = qs2.core.vb.actUsr.rUsr.UserName

            If System.Diagnostics.Process.GetCurrentProcess().ProcessName = "devenv" Then
                rLanguageFound.TypeSub = ""
                If rLanguageFound.IDApplication.Trim() = "" Then
                    rLanguageFound.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()
                End If
            End If

            sqlLanguage1.daLanguage.Update(dsLanguage1.Ressourcen)

            If doLoadAllRessources Then
                sqlLanguage1.loadAllRessources()
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("cTranslate.saveTranslation: " + ex.ToString())
        End Try
    End Function

    Public Function saveAutoTranslation(IDRes As String, translatedTxtGerm As String, translatedTxtEng As String, translatedTxtUser As String,
                                        IDApplication As String, ByRef iCounterInserted As Integer, ByRef iCounterUpdated As Integer,
                                        ByRef sProt As String, ByRef onlyAddRes As Boolean) As Boolean
        Try
            Dim InfoRes As String = "IDRes:" + IDRes + ", English:" + translatedTxtEng.Trim() + ", German:" + translatedTxtGerm.Trim() + ""
            Dim IDPartipantAll As String = ""
            IDPartipantAll = qs2.core.license.doLicense.eApp.ALL.ToString()

            Dim rLanguageFound As qs2.core.language.dsLanguage.RessourcenRow = Nothing
            Dim sqlLanguage1 As New qs2.core.language.sqlLanguage()
            Dim dsLanguage1 As New qs2.core.language.dsLanguage()
            sqlLanguage1.getLanguageRow(IDRes, dsLanguage1, IDApplication, IDPartipantAll,
                                        core.Enums.eResourceType.Label.ToString(), Enums.eTypeSub.Supervisor, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                        False, False)

            Dim isNew As Boolean = False
            Dim isUpdated As Boolean = False
            If dsLanguage1.Ressourcen.Rows.Count = 0 Then
                sqlLanguage1.getLanguageRow(IDRes, dsLanguage1, qs2.core.license.doLicense.eApp.ALL.ToString(), IDPartipantAll,
                                                core.Enums.eResourceType.Label.ToString(), Enums.eTypeSub.Supervisor, qs2.core.license.doLicense.eApp.ALL.ToString(),
                                                False, False)
                If dsLanguage1.Ressourcen.Rows.Count = 0 Then
                    rLanguageFound = sqlLanguage1.newRowLanguage(dsLanguage1, translatedTxtGerm.Trim(), IDRes, qs2.core.vb.actUsr.rUsr.UserName, IDApplication, IDPartipantAll,
                                                             core.Enums.eResourceType.Label, core.Enums.eTypeSub.None, qs2.core.license.doLicense.eApp.ALL.ToString())
                    iCounterInserted += 1
                    sProt += InfoRes + " inserted" + vbNewLine
                    isNew = True

                ElseIf dsLanguage1.Ressourcen.Rows.Count = 1 Then
                    If onlyAddRes Then
                        sProt += InfoRes + " already exists" + vbNewLine
                        Return False
                    Else
                        rLanguageFound = dsLanguage1.Ressourcen.Rows(0)
                        iCounterUpdated += 1
                        sProt += InfoRes + " updated" + vbNewLine
                        isUpdated = True
                    End If
                Else
                    Throw New Exception("saveTranslation:  dsLanguage1.Ressourcen.Rows.Count = o or 1!  IDRes:" + IDRes + "'!")
                End If

            ElseIf dsLanguage1.Ressourcen.Rows.Count = 1 Then
                If onlyAddRes Then
                    sProt += InfoRes + " already exists" + vbNewLine
                    Return False
                Else
                    rLanguageFound = dsLanguage1.Ressourcen.Rows(0)
                    iCounterUpdated += 1
                    sProt += InfoRes + " updated" + vbNewLine
                    isUpdated = True
                End If
            Else
                Throw New Exception("saveTranslation:  dsLanguage1.Ressourcen.Rows.Count = o or 1!  IDRes:" + IDRes + "'!")
            End If

            rLanguageFound.English = translatedTxtEng.Trim()
            rLanguageFound.German = translatedTxtGerm.Trim()
            rLanguageFound.User = translatedTxtUser.Trim()
            rLanguageFound.Created = System.DateTime.Now
            rLanguageFound.CreatedUser = ""     'qs2.core.vb.actUsr.rUsr.UserName

            If System.Diagnostics.Process.GetCurrentProcess().ProcessName = "devenv" Then
                rLanguageFound.TypeSub = ""
                If rLanguageFound.IDApplication.Trim() = "" Then
                    rLanguageFound.IDApplication = qs2.core.license.doLicense.eApp.ALL.ToString()
                End If
            End If

            sqlLanguage1.daLanguage.Update(dsLanguage1.Ressourcen)
            Return True

        Catch ex As Exception
            Throw New Exception("cTranslate.saveTranslation: " + ex.ToString())
        End Try
    End Function
End Class
