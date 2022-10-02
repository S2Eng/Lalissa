Imports System.Data.OleDb



Public Class suchePlan

    Private gen As New General()
    Private db As New db()

    Public Class cAbtBereich
        Public ID As Guid = Nothing
        Public isAbt As Boolean = False
        Public IDParent As System.Guid = Nothing
    End Class








    Public Function searchPlan(ByVal ds As dsPlanSearch,
                         ByVal sqlPriorität As String,
                         ByVal sqlErledigt As String, ByVal sqlEMailGesendet As String,
                         ByVal dVon As Date, ByVal dBis As Date,
                         ByVal txt As String,
                         ByVal tDesign As Integer,
                         ByVal iTyp As Integer,
                         ByRef SqlCommandReturn As String,
                         ByRef lstSelectedCategories As System.Collections.Generic.List(Of String),
                         ByRef lstPatients As System.Collections.Generic.List(Of Guid),
                         ByRef lstUsers As System.Collections.Generic.List(Of Guid), doInit As Boolean, PlanArchive As contPlanungData.cPlanArchive,
                         ByRef TypeUI As contPlanungData.eTypeUI, LayoutGrid As contPlanungData.eLayoutGrid, ByRef IDKlinik As Guid) As Boolean
        Try
            Dim SQL_where As String = ""

            Dim sql_Klinik As String = " [plan].IDKlinik='" + IDKlinik.ToString() + "' "
            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_Klinik, " and " + sql_Klinik)

            'SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sqlWhereKlinik, " and " + sqlWhereKlinik)
            If lstPatients.Count > 0 Then
                Me.getWhereLstIDsPatients(lstPatients, doInit, PlanArchive, TypeUI, SQL_where)
            End If
            If lstUsers.Count > 0 Then
                Me.getWhereLstIDsUsers(lstUsers, doInit, PlanArchive, TypeUI, SQL_where)
            End If

            If TypeUI = contPlanungData.eTypeUI.PlanKlienten Then
                Dim bStop As Boolean = True

            ElseIf TypeUI = contPlanungData.eTypeUI.PlanMy Then
                Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
                Dim sql_id As String = " [plan].Für = '" + UserLoggedIn.Trim() + "' "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)

            ElseIf TypeUI = contPlanungData.eTypeUI.PlansAll Then
                Dim bStop As Boolean = True

            ElseIf TypeUI = contPlanungData.eTypeUI.IDKlient Then
                If PMDS.Global.ENV.CurrentIDPatient = Nothing Then
                    Throw New Exception("searchPlan2: PMDS.Global.Settings.CurrentIDPatient = Nothing not allowed!")
                End If
                Dim id_str As String = " planObject.idObject = '" + PMDS.Global.ENV.CurrentIDPatient.ToString + "' "
                Dim sql_sub As String = " Patient.ID in ( SELECT idObject FROM  planObject " +
                                        " where  " + id_str + ") "

                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            Else
                Throw New Exception("searchPlan2: TypeUI '" + TypeUI.ToString() + "' not allowed!")
            End If

            If txt <> "" Then
                Dim id_str As String = " ( [plan].Betreff like '%" + txt + "%' ) "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
            End If

            If lstSelectedCategories.Count > 0 Then
                Dim sql_id As String = ""
                For Each sCategory As String In lstSelectedCategories
                    Dim id_str As String = " [plan].Category like '%" + sCategory.ToString + "%' "
                    sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
                Next
                Dim sql_sub As String = " (" + sql_id + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If

            If sqlErledigt.Trim() <> "" Then
                Dim sql_id As String = " (" + sqlErledigt + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If
            'If LayoutGrid <> contPlanungData.eLayoutGrid.Beginn And sqlErledigt.Trim() <> "" Then
            '    Dim sql_id As String = " (" + sqlErledigt + ") "
            '    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            'End If
            If sqlPriorität.Trim() <> "" Then
                Dim sql_id As String = " (" + sqlPriorität + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If
            If sqlEMailGesendet.Trim() <> "" Then
                Dim sql_id As String = " (" + sqlEMailGesendet + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If

            If iTyp < 1 Then
                Throw New Exception("searchPlan: iTyp<1  not allowed!")
            End If
            If iTyp <> -1 Then
                Dim sql_id As String = "  [plan].IDArt = " + iTyp.ToString() + " "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If

            If tDesign = 1 Or tDesign = 0 Then
                Dim sql_id As String = "  [plan].design = " + tDesign.ToString() + " "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If

            Dim VonTmp As Date = Nothing
            If Not gen.IsNull(dVon) Then
                VonTmp = New Date(dVon.Year, dVon.Month, dVon.Day, 0, 0, 0)
            End If
            Dim BisTmp As Date = Nothing
            If Not gen.IsNull(dBis) Then
                BisTmp = New Date(dBis.Year, dBis.Month, dBis.Day, 23, 59, 59)
            End If

            If iTyp = 1 Then            ' Posteingang
                If Not gen.IsNull(VonTmp) Then
                    Dim id_str As String = "  [plan].empfangenAm >= ? "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                End If
                If Not gen.IsNull(BisTmp) Then
                    Dim id_str As String = "  [plan].empfangenAm <= ? "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                End If

            ElseIf iTyp = 2 Then        ' Postausgang
                If tDesign = 1 Then
                    If Not gen.IsNull(VonTmp) Then
                        Dim id_str As String = "  [plan].BeginntAm >= ? "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                    End If
                    If Not gen.IsNull(BisTmp) Then
                        Dim id_str As String = "  [plan].BeginntAm <= ? "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                    End If
                ElseIf tDesign = 0 Then
                    Dim id_strIsNull As String = "  [plan].gesendetAm is null "
                    If Not gen.IsNull(VonTmp) Then
                        Dim id_str As String = "  ( [plan].gesendetAm >= ? or " + id_strIsNull + ") "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                    End If
                    If Not gen.IsNull(BisTmp) Then
                        Dim id_str As String = "  ( [plan].gesendetAm <= ? or " + id_strIsNull + ") "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                    End If
                End If
            Else
                If Not gen.IsNull(VonTmp) Then
                    Dim id_str As String = "  [plan].BeginntAm >= ? "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                End If
                If Not gen.IsNull(BisTmp) Then
                    Dim id_str As String = "  [plan].BeginntAm <= ? "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
                End If
            End If

            Dim cmd As New OleDbCommand()
            If iTyp = 1 Then
                If Not gen.IsNull(VonTmp) Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("empfangenAm", System.Data.OleDb.OleDbType.Date, 16, "empfangenAm")).Value = VonTmp
                End If
                If Not gen.IsNull(BisTmp) Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("empfangenAm", System.Data.OleDb.OleDbType.Date, 16, "empfangenAm")).Value = BisTmp
                End If

            ElseIf iTyp = 2 Then
                If tDesign = 1 Then
                    If Not gen.IsNull(VonTmp) Then
                        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = VonTmp
                    End If
                    If Not gen.IsNull(BisTmp) Then
                        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = BisTmp
                    End If
                ElseIf tDesign = 0 Then
                    If Not gen.IsNull(VonTmp) Then
                        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("gesendetAm", System.Data.OleDb.OleDbType.Date, 16, "gesendetAm")).Value = VonTmp
                    End If
                    If Not gen.IsNull(BisTmp) Then
                        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("gesendetAm", System.Data.OleDb.OleDbType.Date, 16, "gesendetAm")).Value = BisTmp
                    End If
                End If
            Else
                If Not gen.IsNull(VonTmp) Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = VonTmp
                End If
                If Not gen.IsNull(BisTmp) Then
                    cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = BisTmp
                End If
            End If


            Dim Sql As String = ""
            Dim compPlanSql As New compPlan()
            Dim da As New OleDbDataAdapter()
            If TypeUI = contPlanungData.eTypeUI.PlansAll Or TypeUI = contPlanungData.eTypeUI.PlanMy Then
                Sql = compPlanSql.daPlanSearchPatientsAll.SelectCommand.CommandText
            Else
                Sql = compPlanSql.daPlanSearchPatients.SelectCommand.CommandText
            End If

            'If LayoutGrid = contPlanungData.eLayoutGrid.Beginn Then
            '    Sql = compPlanSql.daPlanSearch.SelectCommand.CommandText
            'Else
            '    If TypeUI = contPlanungData.eTypeUI.PlansAll Or TypeUI = contPlanungData.eTypeUI.PlanMy Then
            '        Sql = compPlanSql.daPlanSearchPatientsAll.SelectCommand.CommandText
            '    Else
            '        Sql = compPlanSql.daPlanSearchPatients.SelectCommand.CommandText
            '    End If
            'End If

            cmd.CommandText = Sql + SQL_where + " order by [plan].BeginntAm desc , [plan].FälligAm desc  "
            cmd.Connection = Me.db.getConnDB()
            cmd.CommandTimeout = 0
            da.SelectCommand = cmd
            da.Fill(ds.plan)

            SqlCommandReturn = cmd.CommandText
            Return True






            'Dim sqlWhereKlinik As String = ""
            'sqlWhereKlinik = "Select dbo.planObject.IDObject From dbo.Klinik INNER Join dbo.Abteilung ON dbo.Klinik.ID = dbo.Abteilung.IDKlinik INNER Join " +
            '                    " dbo.Aufenthalt ON dbo.Abteilung.ID = dbo.Aufenthalt.IDAbteilung INNER Join dbo.planObject ON dbo.Aufenthalt.IDPatient = dbo.planObject.IDObject where dbo.Klinik.ID = '" + IDKlinik.ToString() + "' "
            'SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sqlWhereKlinik, " and " + sqlWhereKlinik)

            'sqlWhereKlinik = "Select dbo.Benutzer.ID As IDBenutzer  From dbo.Benutzer INNER Join dbo.BenutzerAbteilung ON dbo.Benutzer.ID = dbo.BenutzerAbteilung.IDBenutzer INNER Join " +
            '                    "dbo.Klinik INNER Join dbo.Abteilung ON dbo.Klinik.ID = dbo.Abteilung.IDKlinik ON dbo.BenutzerAbteilung.IDAbteilung = dbo.Abteilung.ID where dbo.Klinik.ID = '" + IDKlinik.ToString() + "' "
            'SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sqlWhereKlinik, " and " + sqlWhereKlinik)



            'Dim dsUserAccountsRead As New dsUserAccounts()
            'Dim compUserAccountsRead As New compUserAccounts()
            'compUserAccountsRead.getUserAccounts(Nothing, "", dsUserAccountsRead, compUserAccounts.eTypSelUserAccounts.PostOfficeBoxForAll, compUserAccounts.eTypEMailAccount.Pop3, True)

            'Dim SqlTxtAccounts As String = ""
            'If (PostOfficeBoxForAll And Not imGesamtsystemSuchen) Or (PostOfficeBoxForAll And offTermine) Then
            '    If General.AllgPostboxEinsehbar Then
            '        For Each rUserAccountForAll As dsUserAccounts.tblUserAccountsRow In dsUserAccountsRead.tblUserAccounts
            '            SqlTxtAccounts += IIf(SqlTxtAccounts.Trim() = "", "", " or ") + "[plan].Für='" + rUserAccountForAll.Usr.Trim() + "' "
            '        Next
            '        If SqlTxtAccounts.Trim() <> "" Then
            '            SqlTxtAccounts = " " + SqlTxtAccounts + " "
            '            'SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + SqlTxtAccounts, " and " + SqlTxtAccounts)
            '        End If
            '    End If
            'End If

            'If Not imGesamtsystemSuchen Then
            '    Dim sql_id As String = " [plan].Für = '" + UserLoggedIn.Trim() + "' "
            '    If SqlTxtAccounts.Trim() <> "" Then
            '        sql_id = " ( " + sql_id + " or " + SqlTxtAccounts + " ) "
            '    End If
            '    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            'Else
            '    If usr.Trim() <> "" Then
            '        Dim sql_id As String = " [plan].Für = '" + usr + "' "
            '        If SqlTxtAccounts.Trim() <> "" Then
            '            sql_id = " ( " + sql_id + " or " + SqlTxtAccounts + " ) "
            '        End If
            '        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            '    End If
            'End If

        Catch ex As OleDbException
            Throw New Exception("suchePlan.searchPlan: " + ex.ToString())
        End Try
    End Function

    Public Function searchPlanBereich(ByVal ds As dsPlanSearch, compPlanSearch As compPlan,
                         ByVal sqlStatus As String,
                         ByVal dVon As Date, ByVal dBis As Date,
                         ByVal Betreff As String,
                         ByRef SqlCommandReturn As String,
                         ByRef lstSelectedCategories As System.Collections.Generic.List(Of String),
                         ByRef lstSelectedAbteilungen As System.Collections.Generic.List(Of suchePlan.cAbtBereich),
                         ByRef lstSelectedBereiche As System.Collections.Generic.List(Of suchePlan.cAbtBereich),
                         ByRef lstSelectedBerufsgruppen As System.Collections.Generic.List(Of String),
                         ByRef lAllBerufsstandGruppe As System.Collections.Generic.List(Of String),
                         LayoutGrid As contPlanungDataBereich.eLayoutGrid, ByRef IDKlinik As Guid) As Boolean
        Try
            compPlanSearch.daSearchPlanBereich.SelectCommand.Parameters.Clear()

            Dim SQL_where As String = ""
            SQL_where = " where [planBereich].IDKlinik='" + IDKlinik.ToString() + "' "

            If Betreff <> "" Then
                Dim id_str As String = " ( [planBereich].Betreff like '%" + Betreff + "%' ) "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
            End If

            If lstSelectedCategories.Count > 0 Then
                Dim sql_Category As String = ""
                For Each sCategory As String In lstSelectedCategories
                    Dim id_str As String = " [planBereich].Category like '%" + sCategory.ToString + "%' "
                    sql_Category += IIf(gen.IsNull(Trim(sql_Category)), id_str, " or " + id_str)
                Next
                Dim sql_sub As String = " (" + sql_Category + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If

            Dim sql_SubAbt As String = ""
            If lstSelectedAbteilungen.Count > 0 Then
                Dim sql_Sub As String = ""
                For Each AbtBereich As cAbtBereich In lstSelectedAbteilungen
                    Dim id_str As String = " [planBereich].IDAbteilung='" + AbtBereich.ID.ToString() + "' "
                    sql_Sub += IIf(gen.IsNull(Trim(sql_Sub)), id_str, " or " + id_str)
                Next
                sql_SubAbt = " (" + sql_Sub + ") "
            End If
            Dim sql_SubBereiche As String = ""
            If lstSelectedBereiche.Count > 0 Then
                Dim sql_Sub As String = ""
                For Each AbtBereich As cAbtBereich In lstSelectedBereiche
                    Dim id_str As String = " [planBereich].IDBereich='" + AbtBereich.ID.ToString() + "' "
                    sql_Sub += IIf(gen.IsNull(Trim(sql_Sub)), id_str, " or " + id_str)
                Next
                sql_SubBereiche = " (" + sql_Sub + ") "
            End If
            If Not String.IsNullOrEmpty(sql_SubAbt) Or Not String.IsNullOrEmpty(sql_SubBereiche) Then
                Dim sql_SubAbtBereiche As String = ""
                If Not String.IsNullOrEmpty(sql_SubAbt) Then
                    sql_SubAbtBereiche += IIf(gen.IsNull(Trim(sql_SubAbtBereiche)), " (" + sql_SubAbt + ") ", " or (" + sql_SubAbt + ") ")
                End If
                If Not String.IsNullOrEmpty(sql_SubBereiche) Then
                    sql_SubAbtBereiche += IIf(gen.IsNull(Trim(sql_SubAbtBereiche)), " (" + sql_SubBereiche + ") ", " or (" + sql_SubBereiche + ") ")
                End If
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_SubAbtBereiche, " and " + sql_SubAbtBereiche)
            End If

            If lstSelectedBerufsgruppen.Count > 0 Then
                Dim sql_Berufsgrp As String = ""
                For Each sTxt As String In lstSelectedBerufsgruppen
                    Dim id_str As String = " [planBereich].lstBerufsgruppen like '%" + sTxt.ToString + "%' "
                    sql_Berufsgrp += IIf(gen.IsNull(Trim(sql_Berufsgrp)), id_str, " or " + id_str)
                Next
                Dim sql_sub As String = " (" + sql_Berufsgrp + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            'If lAllBerufsstandGruppe.Count > 0 Then
            '    Dim sql_Berufsgrp As String = ""
            '    For Each sTxt As String In lAllBerufsstandGruppe
            '        Dim id_str As String = " [planBereich].lstBerufsgruppen like '%" + sTxt.ToString + "%' "
            '        sql_Berufsgrp += IIf(gen.IsNull(Trim(sql_Berufsgrp)), id_str, " or " + id_str)
            '    Next
            '    Dim sql_sub As String = " (" + sql_Berufsgrp + ") "
            '    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            'End If

            If sqlStatus.Trim() <> "" Then
                Dim sql_id As String = " (" + sqlStatus + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_id, " and " + sql_id)
            End If

            Dim VonTmp As Date = Nothing
            If Not gen.IsNull(dVon) Then
                VonTmp = New Date(dVon.Year, dVon.Month, dVon.Day, 0, 0, 0)
            End If
            Dim BisTmp As Date = Nothing
            If Not gen.IsNull(dBis) Then
                BisTmp = New Date(dBis.Year, dBis.Month, dBis.Day, 23, 59, 59)
            End If
            If Not gen.IsNull(VonTmp) Then
                Dim id_str As String = "  [planBereich].BeginntAm >= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
            End If
            If Not gen.IsNull(BisTmp) Then
                Dim id_str As String = "  [planBereich].BeginntAm <= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + id_str, " and " + id_str)
            End If

            If Not gen.IsNull(VonTmp) Then
                compPlanSearch.daSearchPlanBereich.SelectCommand.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = VonTmp
            End If
            If Not gen.IsNull(BisTmp) Then
                compPlanSearch.daSearchPlanBereich.SelectCommand.Parameters.Add(New System.Data.OleDb.OleDbParameter("BeginntAm", System.Data.OleDb.OleDbType.Date, 16, "BeginntAm")).Value = BisTmp
            End If

            compPlanSearch.daSearchPlanBereich.SelectCommand.CommandText = compPlanSearch.sqldaSearchPlanBereich
            compPlanSearch.daSearchPlanBereich.SelectCommand.CommandText += " " + SQL_where + " order by [planBereich].BeginntAm desc "
            compPlanSearch.daSearchPlanBereich.SelectCommand.Connection = Me.db.getConnDB()
            compPlanSearch.daSearchPlanBereich.SelectCommand.CommandTimeout = 0
            compPlanSearch.daSearchPlanBereich.Fill(ds.planBereich)

            SqlCommandReturn = compPlanSearch.daSearchPlanBereich.SelectCommand.CommandText
            Return True

        Catch ex As OleDbException
            Throw New Exception("suchePlan.searchPlanBereich: " + ex.ToString())
        End Try
    End Function


    Public Sub getWhereLstIDsPatients(ByRef lstIDs As System.Collections.Generic.List(Of Guid), doInit As Boolean, PlanArchive As contPlanungData.cPlanArchive,
                                    ByRef TypeUI As contPlanungData.eTypeUI, ByRef SQL_where As String)
        Try
            Dim sql_id As String = ""
            For Each ID As Guid In lstIDs
                Dim id_str As String = " planObject.idObject = '" + ID.ToString + "' "
                sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
            Next
            Dim sql_sub As String = " Patient.ID in ( SELECT idObject FROM  planObject " +
                                        " where  " + sql_id + ") "

            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)

        Catch ex As OleDbException
            Throw New Exception("suchePlan.getWhereLstIDsPatients: " + ex.ToString())
        End Try
    End Sub
    Public Sub getWhereLstIDsUsers(ByRef lstIDs As System.Collections.Generic.List(Of Guid), doInit As Boolean, PlanArchive As contPlanungData.cPlanArchive,
                                ByRef TypeUI As contPlanungData.eTypeUI, ByRef SQL_where As String)
        Try
            Dim sql_id As String = ""
            For Each ID As Guid In lstIDs
                Dim id_str As String = " planObject.idObject = '" + ID.ToString + "' "
                sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
            Next
            Dim sql_sub As String = " [plan].ID in ( SELECT IDPlan FROM  planObject " +
                                        " where  " + sql_id + ") "

            SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)

        Catch ex As OleDbException
            Throw New Exception("suchePlan.getWhereLstIDsUsers: " + ex.ToString())
        End Try
    End Sub

End Class
