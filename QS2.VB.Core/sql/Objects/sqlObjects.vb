﻿Imports qs2.core




Public Class sqlObjects

    Public sel_daObject As String = ""
    Public sel_daObjectRel As String = ""
    Public sel_daAdress As String = ""
    Public sel_daObjectRights As String = ""
    Public sel_daMedArchiv As String = ""

    Public sel_daObjectSmall As String = ""
    Public sel_daStaySmall As String = ""
    Public sel_daObjectApplications As String = ""

    Public database As New qs2.core.dbBase

    Public Shared userName_Supervisor As String = "Supervisor"
    Public Shared userName_Admin As String = "Admin"
    Public Shared userName_Superadmin As String = "Superadmin"


    Public isInitialized As Boolean = False



    Public Sub initControl()
        If Me.isInitialized Then
            Exit Sub
        End If

        Me.sel_daObject = Me.daObject.SelectCommand.CommandText
        Me.sel_daObjectRel = Me.daObjectRel.SelectCommand.CommandText
        Me.sel_daAdress = Me.daAdress.SelectCommand.CommandText
        Me.sel_daStay = Me.daStay.SelectCommand.CommandText
        Me.sel_daMedArchiv = Me.daMedArchiv.SelectCommand.CommandText

        Me.sel_daObjectSmall = Me.daObjectSmall.SelectCommand.CommandText
        Me.sel_daStaySmall = Me.daStaySmall.SelectCommand.CommandText
        Me.sel_daObjectApplications = Me.daObjectApplications.SelectCommand.CommandText

        Me.isInitialized = True
    End Sub


    Public Enum eTypSelObj
        ID = 2000
        All = 2001
        AllUser = 2002
        likeName = 2003
        DOB = 2004
        UserNameDomain = 2005
        UserName = 2006
        UserNameParticipant = 2023
        PatID = 2007
        MedRecN = 2008
        FollowUpDate = 2009
        RecordID = 2010
        IDGuid = 2011
        CheckExtNrNoIDObject = 2013
        CheckExtNr = 2014
        CPBSerialNumber = 2015
        SurgeryDate = 2016
        NameAndDOB = 2017
        LogInParticipant = 2018
        OrgUnitStay = 2019
        AllPatients = 2020
        SelectPatientsForAutoDelete = 2021
        SearchForDeathStatus = 2022
        ExtID = 2024
        ExtIDIDParticipant = 2025
        AllUsersIDParticipant = 2026
    End Enum
    Public Enum eTypObj
        IsPatient = 2050
        IsPersonal = 2051
        IsUser = 2052
        all = 2053
        none = -1
    End Enum

    Public Enum eTypSelAdr
        id = 2060
        idObject = 2061
        IsMainAdress = 2062
    End Enum
    Public Enum eTypSelAnspr
        id = 2070
        idObject = 2071
        idObjectSub = 2072
    End Enum
    Public Enum eTypSelObjRights
        allObject = 2080
        right = 2081
    End Enum
    Public Enum eTypSelStay
        all = 2090
        IDIDParticipant = 2091      'RecordID
        IDObjectForApplication = 2092
        allPatient = 2093
        MedRecN = 2094
        MedRecNIncidence = 2100
        OrgUnitStay = 2101
        FollowUpDate = 2095
        SurgDt = 2096
        IDGuidStay = 2097
        CheckMedRecNrWithoutIDStay = 2098
        CheckMedRecNr = 2099
        CheckIncidenceWithoutIDStay = 2112
        CheckIncidence = 2113
        SendStay = 2114
        CPBSerialNumber = 2115
        IDIDApplicationIDParticipant = 2116
        allPatientAllAplicationsAllparticipants = 2117
        AdmDtFromTo = 2118
        DeleteStaysAutoStart = 2119
        searchStaysForRecordID = 2120
        SearchForDeathStatus = 2121
        allPatientSimple = 2122
    End Enum

    Public Enum eTypSelMedArchiv
        IDStay = 3000
        IDObject = 3001
        IDGuid = 3002
        DocuStatus = 3003
    End Enum

    Public sel_daStay As String = ""

    Public Shared dsAllUsers As dsObjects = Nothing








    Public Shared Function loadAllData() As Boolean
        Try
            Dim sqlObjectsTemp As New sqlObjects()
            sqlObjectsTemp.initControl()
            If sqlObjects.dsAllUsers Is Nothing Then
                sqlObjects.dsAllUsers = New dsObjects()
            End If
            sqlObjects.dsAllUsers.Clear()
            sqlObjects.dsAllUsers = sqlObjectsTemp.getAllUsers()
            sqlObjectsTemp.getObjectApplications(Nothing, sqlObjects.dsAllUsers, eTypObj.all)

        Catch ex As Exception
            Throw New Exception("loadAllData: " + ex.ToString())
        End Try
    End Function

    Public Function checkObject(ByVal id As Integer) As Boolean
        Dim ds As New dsObjects
        Me.getObject(id, ds, eTypSelObj.ID)
        If ds.tblObject.Rows.Count = 0 Then
            Return False
        ElseIf ds.tblObject.Rows.Count = 1 Then
            Return True
        ElseIf ds.tblObject.Rows.Count > 1 Then
            Throw New Exception("checkObject.id: More than one Row for IDObject '" + id.ToString() + "' found!")
            Return False
        End If
    End Function
    Public Function getObjectRow(ByVal id As Integer, ByVal typSel As eTypSelObj,
                                Optional ByVal typObj As eTypObj = eTypObj.none,
                                Optional ByVal nr As String = "",
                                Optional ByVal UserName As String = "",
                                Optional IDGuid As System.Guid = Nothing) As dsObjects.tblObjectRow

        Dim ds As New dsObjects()
        Me.getObject(id, ds, typSel, typObj, nr, UserName, False, IDGuid)
        If ds.tblObject.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblObject.Rows.Count = 1 Then
            Return ds.tblObject.Rows(0)
        ElseIf ds.tblObject.Rows.Count > 1 Then
            Throw New Exception("getObjectRow.id: More than one Row for IDObject '" + id.ToString() + "' / Nr '" + nr.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function getObject(ByVal id As Integer, ByRef ds As dsObjects, ByVal typSel As eTypSelObj,
                                Optional ByVal typObj As eTypObj = eTypObj.none,
                                Optional ByVal nr As String = "",
                                Optional ByVal UserName As String = "",
                                Optional checkSupervisor As Boolean = True,
                                Optional IDGuid As System.Guid = Nothing, Optional Participant As String = "",
                                Optional IsHeadQuarter As Boolean = False,
                                Optional lstApplications As System.Collections.Generic.List(Of String) = Nothing) As Boolean
        Try
            Me.daObject.SelectCommand.CommandText = Me.sel_daObject
            database.setConnection(Me.daObject)
            Me.daObject.SelectCommand.Parameters.Clear()

            If typSel = eTypSelObj.ID Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.IDColumn.ColumnName)
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.IDColumn.ColumnName), id)

            ElseIf typSel = eTypSelObj.SelectPatientsForAutoDelete Then
                Dim sWhere As String = " where tblObject.IsPatient=1 AND Not (tblObject.IDGuid IN (SELECT PatIDGuid FROM qs2.tblStay)) "
                If UserName.Trim() <> "" Then
                    sWhere += " and (NameCombination like '%" + UserName.Trim() + "%' or LastName like '%" + UserName.Trim() + "%' or FirstName like '%" + UserName.Trim() + "%') "
                End If
                Me.daObject.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelObj.IDGuid Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.IDGuidColumn.ColumnName)
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.IDGuidColumn.ColumnName), IDGuid)

            ElseIf typSel = eTypSelObj.UserNameDomain Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.UserNameDomainColumn.ColumnName)
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.UserNameDomainColumn.ColumnName), UserName)

            ElseIf typSel = eTypSelObj.UserName Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.UserNameColumn.ColumnName)
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.UserNameColumn.ColumnName), UserName)

            ElseIf typSel = eTypSelObj.UserNameParticipant Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.UserNameColumn.ColumnName) + " and IDParticipant='" + Participant.Trim() + "' "
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.UserNameColumn.ColumnName), UserName)

            ElseIf typSel = eTypSelObj.All Then
                Dim sWhere As String = " "
                sWhere += getSqlTyp(typObj, sWhere)
                Me.genSqlWhereParticipant(IsHeadQuarter, sWhere, Participant, False)
                Me.daObject.SelectCommand.CommandText += sWhere + sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelObj.AllUser Then
                Dim sWhere As String = sqlTxt.where + ds.tblObject.IsUserColumn.ColumnName + " = 1 "
                If UserName.Trim() <> "" Then
                    sWhere += sqlTxt.and + " (" + ds.tblObject.LastNameColumn.ColumnName + " like '%" + UserName.Trim() + "%' or " + ds.tblObject.FirstNameColumn.ColumnName + " like '%" + UserName.Trim() + "%') "
                End If
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                If checkSupervisor Then
                    Me.getSqlWhereSupervisor(Me.daObject.SelectCommand.CommandText, ds)
                End If
                Me.daObject.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelObj.AllPatients Then
                Dim sWhere As String = sqlTxt.where + ds.tblObject.IsPatientColumn.ColumnName + " = 1 "
                If UserName.Trim() <> "" Then
                    sWhere += sqlTxt.and + " (" + ds.tblObject.LastNameColumn.ColumnName + " like '%" + UserName.Trim() + "%' or " + ds.tblObject.FirstNameColumn.ColumnName + " like '%" + UserName.Trim() + "%') "
                End If
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                If checkSupervisor Then
                    Me.getSqlWhereSupervisor(Me.daObject.SelectCommand.CommandText, ds)
                End If

                Me.daObject.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelObj.AllUsersIDParticipant Then
                Dim sWhere As String = sqlTxt.where + ds.tblObject.IsPatientColumn.ColumnName + " = 0 "
                sWhere += " and " + ds.tblObject.IDParticipantColumn.ColumnName + "='" + Participant.Trim() + "' and " +
                                " " + ds.tblObject.IDParticipantColumn.ColumnName + "<>'' "
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelObj.LogInParticipant Then
                Dim sWhere As String = sqlTxt.where + ds.tblObject.IsUserColumn.ColumnName + " = 1 "
                sWhere += getSqlTyp(typObj, sWhere)
                Me.daObject.SelectCommand.CommandText += sWhere
                If checkSupervisor Then
                    'Me.getSqlWhereSupervisor(Me.daObject.SelectCommand.CommandText, ds)
                End If

                Me.daObject.SelectCommand.CommandText += " and ((" + ds.tblObject.IDParticipantColumn.ColumnName + "='" + Participant.Trim() + "' and " +
                                                        " " + ds.tblObject.IDParticipantColumn.ColumnName + "<>'' "

                'Dim sWhereSubUserGrps As String = " and ID IN (Select IDObject From qs2.tblSelListEntriesObj Where typIDGroup = 'Usergroups') "
                'Me.daObject.SelectCommand.CommandText += sWhereSubUserGrps
                Me.daObject.SelectCommand.CommandText += " And ID IN (SELECT DISTINCT qs2.tblObject.ID FROM  qs2.tblObject INNER JOIN qs2.tblSelListEntriesObj ON  " +
                                                    " qs2.tblObject.ID = qs2.tblSelListEntriesObj.IDObject WHERE (qs2.tblSelListEntriesObj.typIDGroup = 'ROLES' and qs2.tblSelListEntriesObj.Active=1)) "


                If (Not lstApplications Is Nothing) AndAlso lstApplications.Count > 0 Then
                    Dim sWhereApps As String = ""
                    For Each IDApplicationLicensed As String In lstApplications
                        sWhereApps += IIf(sWhereApps.Trim() = "", " ", " or ") + " qs2.tblObjectApplications.IDApplication='" + IDApplicationLicensed.Trim() + "' "
                    Next
                    Dim sWhereSubUserApps As String = " and IDGuid IN (Select IDObjectGuid From qs2.tblObjectApplications where (" + sWhereApps + ")) "
                    Me.daObject.SelectCommand.CommandText += sWhereSubUserApps
                End If
                Me.daObject.SelectCommand.CommandText += ") "

                If Not checkSupervisor Then
                    Me.daObject.SelectCommand.CommandText += " or " + ds.tblObject.UserNameColumn.ColumnName + "='Supervisor') "
                Else
                    Me.daObject.SelectCommand.CommandText += " and " + ds.tblObject.UserNameColumn.ColumnName + "<>'Supervisor') "
                    'Me.daObject.SelectCommand.CommandText += " or (" + ds.tblObject.isAdminColumn.ColumnName + "=1 and " + ds.tblObject.IDParticipantColumn.ColumnName + "='') "
                    Me.daObject.SelectCommand.CommandText += " or (" + ds.tblObject.isAdminColumn.ColumnName + "=1 and " + ds.tblObject.IDParticipantColumn.ColumnName + "='" + Participant.Trim() + "'  and (UserName='Admin' or UserName='Superadmin') and UserName<>'Supervisor') "
                End If

                Me.daObject.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelObj.CheckExtNr Then
                Dim sWhere As String = sqlTxt.where + ds.tblObject.IDColumn.ColumnName + " <> " + sqlTxt.sMonkey.Trim() + "ID" + sqlTxt.and +
                                        sqlTxt.getColWhere(ds.tblObject.ExtIDColumn.ColumnName)

                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.IDColumn.ColumnName), id)
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.ExtIDColumn.ColumnName), nr.Trim())

            ElseIf typSel = eTypSelObj.CheckExtNrNoIDObject Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.ExtIDColumn.ColumnName)
                Me.daObject.SelectCommand.CommandText += sWhere
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.ExtIDColumn.ColumnName), nr.Trim())

            ElseIf typSel = eTypSelObj.ExtID Then
                Dim sWhere As String = sqlTxt.where + " ExtID='" + nr.Trim() + "' "
                Me.daObject.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelObj.ExtIDIDParticipant Then
                Dim sWhere As String = sqlTxt.where + " ExtID='" + nr.Trim() + "' and IDParticipant='" + Participant.Trim() + "' "
                Me.daObject.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("sqlObjects.getObject: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daObject.Fill(ds.tblObject)
            Return True

        Catch ex As Exception
            Throw New Exception("getObject: " + ex.ToString())
        End Try
    End Function
    Public Function getObject2(ByRef ds As dsObjects, ByVal typObj As eTypObj,
                               ByVal dateSearchFrom As Date, ByVal dateSearchTo As Date,
                               ByVal lastname As String, ByVal firstname As String, ByVal DOB As DateTime,
                               ByVal searchUsername As String, ByVal typSel As eTypSelObj, IsHeadQuarter As Boolean,
                               ByRef IDParticipant As String, INKlauselObjectFields As String, INKlauselSheriffs As String) As Boolean

        Me.daObject.SelectCommand.CommandText = Me.sel_daObject
        database.setConnection(Me.daObject)
        Me.daObject.SelectCommand.Parameters.Clear()

        Dim sWhere As String = " where IDGuid<>'" + System.Guid.NewGuid().ToString() + "' "
        sWhere += getSqlTyp(typObj, sWhere)
        Me.daObject.SelectCommand.CommandText += sWhere
        If typSel = eTypSelObj.DOB Then
            Me.genSqlWhereParticipant(IsHeadQuarter, Me.daObject.SelectCommand.CommandText, IDParticipant, False)
            Dim Heute As DateTime = Now.Date
            Dim dateFrom As DateTime = Heute
            Dim dateTo As DateTime = Heute
            dateFrom = DateAdd(DateInterval.Year, -99, Heute)
            dateTo = DateAdd(DateInterval.Year, +99, Heute)

            dateFrom = IIf(IsNothing(dateSearchFrom), dateFrom, dateSearchFrom.Date)
            dateTo = IIf(IsNothing(dateSearchTo), dateTo, dateSearchTo)

            Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.DOBColumn.ColumnName + ">=@" + ds.tblObject.DOBColumn.ColumnName + "1 " + sqlTxt.and +
                                                        ds.tblObject.DOBColumn.ColumnName + "<=@" + ds.tblObject.DOBColumn.ColumnName + "2"
            Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.DOBColumn.ColumnName + "1"), dateFrom)
            Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.DOBColumn.ColumnName) + "2", dateTo)

            Dim sqlWhereObj As String = Me.getWhereObjectsObj(INKlauselSheriffs, INKlauselObjectFields)
            If sqlWhereObj.Trim() <> "" Then
                sqlWhereObj = " " + IIf(Me.daObject.SelectCommand.CommandText.Trim().ToLower().Contains(("where").Trim().ToLower()), sqlTxt.and, sqlTxt.where) + " " + sqlWhereObj
                Me.daObject.SelectCommand.CommandText += sqlWhereObj
            End If
            'If INKlauselSheriffs.Trim() <> "" Then
            '    Dim sqlWhereObj As String = ""
            '    sqlWhereObj += " and IDGuid IN (Select PatIDGuid from qs2.tblStay where " + INKlauselSheriffs + " "
            '    If INKlauselObjectFields.Trim() <> "" Then
            '        sqlWhereObj += INKlauselObjectFields
            '    End If
            '    sqlWhereObj += " ) "
            '    Me.daObject.SelectCommand.CommandText += sqlWhereObj
            'End If

        ElseIf typSel = eTypSelObj.likeName Then
            Dim orIsAdminTmp As Boolean = False
            If typObj = eTypObj.IsUser Then
                orIsAdminTmp = True
            End If
            Me.genSqlWhereParticipant(IsHeadQuarter, Me.daObject.SelectCommand.CommandText, IDParticipant, orIsAdminTmp)
            If lastname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.like + " '" + lastname + "%' "
            End If
            If firstname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.FirstNameColumn.ColumnName + sqlTxt.like + " '" + firstname + "%' "
            End If
            If searchUsername <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.UserNameColumn.ColumnName + sqlTxt.like + " '%" + searchUsername + "%' "
            End If

            Dim sqlWhereObj As String = Me.getWhereObjectsObj(INKlauselSheriffs, INKlauselObjectFields)
            If sqlWhereObj.Trim() <> "" Then
                sqlWhereObj = " " + IIf(Me.daObject.SelectCommand.CommandText.Trim().ToLower().Contains(("where").Trim().ToLower()), sqlTxt.and, sqlTxt.where) + " " + sqlWhereObj
                Me.daObject.SelectCommand.CommandText += sqlWhereObj
            End If

        ElseIf typSel = eTypSelObj.PatID Then
            Me.genSqlWhereParticipant(IsHeadQuarter, Me.daObject.SelectCommand.CommandText, IDParticipant, False)
            If lastname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.ExtIDColumn.ColumnName + sqlTxt.equals + " '" + lastname + "' "
            End If
            Dim sqlWhereObj As String = Me.getWhereObjectsObj(INKlauselSheriffs, INKlauselObjectFields)
            If sqlWhereObj.Trim() <> "" Then
                sqlWhereObj = " " + IIf(Me.daObject.SelectCommand.CommandText.Trim().ToLower().Contains(("where").Trim().ToLower()), sqlTxt.and, sqlTxt.where) + " " + sqlWhereObj
                Me.daObject.SelectCommand.CommandText += sqlWhereObj
            End If

        ElseIf typSel = eTypSelObj.ID Then
            If lastname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.IDColumn.ColumnName + sqlTxt.equals + " '" + lastname + "' "
            End If
            Dim sqlWhereObj As String = Me.getWhereObjectsObj(INKlauselSheriffs, INKlauselObjectFields)
            If sqlWhereObj.Trim() <> "" Then
                sqlWhereObj = " " + IIf(Me.daObject.SelectCommand.CommandText.Trim().ToLower().Contains(("where").Trim().ToLower()), sqlTxt.and, sqlTxt.where) + " " + sqlWhereObj
                Me.daObject.SelectCommand.CommandText += sqlWhereObj
            End If

            'ElseIf typSel = eTypSelObj.MedRecN Then   'Suche in Stay
            '    If lastname <> "" Then

            '        Me.getStayRow(Val(lastname), qs2.core.vb.sqlObjects.eTypSelStay.MedRecN, "Application", "staytype")
            '        Me.daObjectSmall.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.ExtIDColumn.ColumnName + sqlTxt.equals + " '" + lastname + "' "
            '    End If
        ElseIf typSel = eTypSelObj.AllUser Then
            Me.genSqlWhereParticipant(IsHeadQuarter, Me.daObject.SelectCommand.CommandText, IDParticipant, False)
            'Me.daObjectNoSave.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc

        ElseIf typSel = eTypSelObj.NameAndDOB Then
            Me.genSqlWhereParticipant(IsHeadQuarter, Me.daObject.SelectCommand.CommandText, IDParticipant, False)
            If lastname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.equals + " '" + lastname + "' "
            End If
            If firstname <> "" Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.FirstNameColumn.ColumnName + sqlTxt.equals + " '" + firstname + "' "
            End If
            If Not IsNothing(DOB) Then
                Me.daObject.SelectCommand.CommandText += sqlTxt.and + ds.tblObject.DOBColumn.ColumnName + "=@" + ds.tblObject.DOBColumn.ColumnName
                Me.daObject.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObject.DOBColumn.ColumnName), DOB)
            End If

        Else
            Throw New Exception("sqlObjects.getObject2: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.getSqlWhereSupervisor(Me.daObject.SelectCommand.CommandText, ds)

        Me.daObject.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblObject.LastNameColumn.ColumnName + sqlTxt.asc
        Me.daObject.Fill(ds.tblObject)
        Return True

    End Function
    Public Function getWhereObjectsObj(ByRef INKlauselSheriffs As String, ByRef INKlauselObjectFields As String) As String
        Try
            Dim sqlWhereObj As String = ""
            If INKlauselSheriffs.Trim() <> "" Then
                sqlWhereObj += " IDGuid IN (Select PatIDGuid from qs2.tblStay where " + INKlauselSheriffs + " "
                If INKlauselObjectFields.Trim() <> "" Then
                    sqlWhereObj += INKlauselObjectFields
                End If
                sqlWhereObj += " ) "
            End If

            Return sqlWhereObj

        Catch ex As Exception
            Throw New Exception("getWhereObjectsObj: " + ex.ToString())
        End Try
    End Function
    Public Function getWhereObjectsStay(ByRef INKlauselSheriffs As String, ByRef INKlauselObjectFields As String) As String
        Try
            Dim sqlWhereObj As String = ""
            If INKlauselSheriffs.Trim() <> "" Then
                sqlWhereObj += " " + INKlauselSheriffs + " "
                If INKlauselObjectFields.Trim() <> "" Then
                    sqlWhereObj += " " + INKlauselObjectFields + " "
                End If
            End If

            Return sqlWhereObj

        Catch ex As Exception
            Throw New Exception("getWhereObjectsStay: " + ex.ToString())
        End Try
    End Function
    Public Function getAllUsers() As dsObjects
        Dim dsAllUsr As New dsObjects()
        Me.getObject(Nothing, dsAllUsr, eTypSelObj.AllUser)
        Return dsAllUsr
    End Function
    Public Function getSqlTyp(ByVal typObj As eTypObj, ByRef sWhere As String) As String
        Dim ds As New dsObjects()
        If typObj = eTypObj.IsPatient Then
            Return IIf(Trim(sWhere) = "", sqlTxt.where + ds.tblObject.IsPatientColumn.ColumnName + " = 1 ", sqlTxt.and + ds.tblObject.IsPatientColumn.ColumnName + " = 1 ")
        ElseIf typObj = eTypObj.IsPersonal Then
            Return IIf(Trim(sWhere) = "", sqlTxt.where + ds.tblObject.IsPersonalColumn.ColumnName + " = 1 ", sqlTxt.and + ds.tblObject.IsPersonalColumn.ColumnName + " = 1 ")
        ElseIf typObj = eTypObj.IsUser Then
            Return IIf(Trim(sWhere) = "", sqlTxt.where + ds.tblObject.IsUserColumn.ColumnName + " = 1 ", sqlTxt.and + ds.tblObject.IsUserColumn.ColumnName + " = 1 ")
        End If
    End Function

    Public Shared Function getNameCombination(ByRef rObj As dsObjects.tblObjectRow) As String
        If rObj.LastName.Trim() <> "" And rObj.FirstName.Trim() = "" Then
            Return rObj.LastName.Trim()
        ElseIf rObj.LastName.Trim() <> "" And rObj.FirstName.Trim() <> "" Then
            Return rObj.LastName.Trim() + " " + rObj.FirstName.Trim()
        ElseIf rObj.LastName.Trim() = "" And rObj.FirstName.Trim() <> "" Then
            Return rObj.FirstName.Trim()
        Else
            Return "[No Name]"
        End If
    End Function



    Public Function getNewRowObject(ByVal dsObject1 As dsObjects) As dsObjects.tblObjectRow
        Dim rNew As dsObjects.tblObjectRow = dsObject1.tblObject.NewRow()
        rNew.FirstName = ""
        rNew.LastName = ""
        rNew.NameCombination = ""
        rNew.IsPatient = False
        rNew.IsPersonal = False
        rNew.IsUser = False
        rNew.Title = ""
        rNew.SetDOBNull()
        rNew.SetGenderNull()
        rNew.SetRaceNull()
        rNew.SSN = ""
        rNew.IsJehova = -1
        rNew.KavVidierungPwd = ""
        rNew.Domain = ""
        rNew.UserName = ""
        rNew.isAdmin = False
        rNew.UserShort = ""
        rNew.Password = ""
        rNew.IsImported = False
        rNew.Sort = 0
        rNew.ExtID = ""
        rNew.Active = False
        rNew.CreatedUserID = ""
        rNew.Created = Now
        rNew.UserNameDomain = ""
        rNew.Role = -1
        rNew.IDParticipant = ""
        rNew.IDGuid = System.Guid.NewGuid()

        rNew.MtStat = -1
        rNew.IsMtDateNull()
        rNew.MTLocatn = -1
        rNew.MtCause = -1
        rNew.ICD9 = ""

        rNew.Classification = ""
        rNew.Description = ""
        rNew.PatOrigin = -1
        rNew.MtCauseDescription = ""
        rNew.Systemuser = False
        rNew.CongenitalData = ""
        rNew.ConAntDiag = False
        rNew.ConGestAge = 0
        rNew.UserCode = ""
        rNew.ExtIDNr = -1
        rNew.MaidenName = ""
        rNew.BPKZ = ""
        rNew.BPKZ1 = ""
        rNew.BPKZ2 = ""
        rNew.ShowUpdateNewsAtStartup = True

        dsObject1.tblObject.Rows.Add(rNew)
        Return rNew

    End Function

    Public Function UpdatePwd(IDGuid As System.Guid, NewPwdDecrypted As String) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = "update " + qs2.core.dbBase.dbSchema + "tblObject set Password=" + sqlTxt.sMonkey + "Password where IDGuid=" + sqlTxt.sMonkey + "IDGuid"
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblObject.PasswordColumn.ColumnName), System.Data.SqlDbType.VarChar, 150, sqlTxt.getColPar(ds.tblObject.PasswordColumn.ColumnName))).Value = NewPwdDecrypted.Trim()
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblObject.IDGuidColumn.ColumnName), System.Data.SqlDbType.UniqueIdentifier, 16, sqlTxt.getColPar(ds.tblObject.IDGuidColumn.ColumnName))).Value = IDGuid
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.UpdatePwd: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function deleteObject(ByVal IDObjectGuid As Guid) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblObject.TableName + " where IDGuid='" + IDObjectGuid.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteObject: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function deleteGuid(ByVal IDGuid As System.Guid) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblObject.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblObject.IDGuidColumn.ColumnName)
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblObject.IDGuidColumn.ColumnName), System.Data.SqlDbType.UniqueIdentifier, 16, sqlTxt.getColPar(ds.tblObject.IDGuidColumn.ColumnName))).Value = IDGuid
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteGuid: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function deletePatients_AutoStartxyxyxyxy() As Boolean
        Try
            Dim dsObjectsUpdate As New dsObjects()
            Dim sqlObjectsUpdate As New sqlObjects()
            sqlObjectsUpdate.initControl()
            sqlObjectsUpdate.getObject(-999, dsObjectsUpdate, eTypSelObj.SelectPatientsForAutoDelete)
            For Each rPatToDelete As dsObjects.tblObjectRow In dsObjectsUpdate.tblObject
                Using ProtocollManager As New Protocol()
                    ProtocollManager.dsNew = dsObjectsUpdate
                    Dim sInfo As String = ""
                    If rPatToDelete.NameCombination.Trim() <> "" Then
                        sInfo = "Auto-Delete Patient: " + rPatToDelete.NameCombination.Trim() + vbNewLine
                    Else
                        sInfo = "Auto-Delete Patient: " + rPatToDelete.LastName.Trim() + " " + rPatToDelete.FirstName.Trim() + vbNewLine
                    End If
                    ProtocollManager.save2(Protocol.eTypeProtocoll.DeletePatient, rPatToDelete.IDGuid, qs2.core.generic.idMinus,
                                 qs2.core.license.doLicense.rParticipant.IDParticipant, "", "", sInfo, Protocol.eActionProtocol.None, rPatToDelete.NameCombination.Trim(), "")
                End Using

                rPatToDelete.Delete()
            Next
            'sqlObjectsUpdate.daObject.Update(dsObjectsUpdate.tblObject)

            Return True

            'Dim ds As New dsObjects()
            'Dim cmd As New SqlClient.SqlCommand()

            'cmd.CommandText = "Delete from " + qs2.core.dbBase.dbSchema + "tblObject where tblObject.IsPatient=1 AND Not (tblObject.IDGuid IN (SELECT PatIDGuid FROM qs2.tblStay)) "
            'cmd.Connection = qs2.core.dbBase.dbConn
            'cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("sqlObjects.deletePatients_AutoStart: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getAdressMain(ByVal IDGuidObject As System.Guid) As dsObjects.tblAdressRow
        Dim ds As New dsObjects()
        Me.getAdressRow(IDGuidObject, ds, eTypSelAdr.IsMainAdress)
        If ds.tblAdress.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblAdress.Rows.Count = 1 Then
            Return ds.tblAdress.Rows(0)
        ElseIf ds.tblAdress.Rows.Count > 1 Then
            Throw New Exception("getAdressMain.id:  More than one Row for IDGuidObject '" + IDGuidObject.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function getAdressRow(ByVal IDGuidObject As System.Guid, ByVal ds As dsObjects, ByVal typSel As eTypSelAdr) As dsObjects.tblAdressRow
        Me.getAdress(IDGuidObject, ds, typSel)
        If ds.tblAdress.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblAdress.Rows.Count = 1 Then
            Return ds.tblAdress.Rows(0)
        ElseIf ds.tblAdress.Rows.Count > 1 Then
            Throw New Exception("getAdressRow.id: More than one Row for IDGuidObject '" + IDGuidObject.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function getAdress(ByVal IDGuid As System.Guid, ByRef ds As dsObjects, ByVal typSel As eTypSelAdr) As Boolean

        Me.daAdress.SelectCommand.CommandText = Me.sel_daAdress
        database.setConnection(Me.daAdress)
        Me.daAdress.SelectCommand.Parameters.Clear()

        If typSel = eTypSelAdr.id Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdress.IDGuidColumn.ColumnName)
            Me.daAdress.SelectCommand.CommandText += sWhere
            Me.daAdress.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdress.IDGuidColumn.ColumnName), IDGuid)

        ElseIf typSel = eTypSelAdr.idObject Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdress.IDGuidObjectColumn.ColumnName)
            Me.daAdress.SelectCommand.CommandText += sWhere
            Me.daAdress.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdress.IDGuidObjectColumn.ColumnName), IDGuid)

        ElseIf typSel = eTypSelAdr.IsMainAdress Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblAdress.IDGuidObjectColumn.ColumnName) + sqlTxt.and + ds.tblAdress.IsMainAdressColumn.ColumnName + " = 1 "
            Me.daAdress.SelectCommand.CommandText += sWhere
            Me.daAdress.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblAdress.IDGuidObjectColumn.ColumnName), IDGuid)

        Else
            Throw New Exception("sqlObjects.getAdress: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daAdress.Fill(ds.tblAdress)
        Return True

    End Function
    Public Function getNewRowAdressen(ByVal dsObject1 As dsObjects) As dsObjects.tblAdressRow
        Dim rNew As dsObjects.tblAdressRow = dsObject1.tblAdress.NewRow()
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.CountryID = -1
        rNew.ZIP = ""
        rNew.City = ""
        rNew.Street = ""
        rNew.PhonePrivat = ""
        rNew.PhoneBusiness = ""
        rNew.PhoneMobil = ""
        rNew.EMail = ""
        rNew.Web = ""
        rNew.Fax = ""
        rNew.IsMainAdress = False
        rNew.IDGuidObject = System.Guid.Empty
        dsObject1.tblAdress.Rows.Add(rNew)
        Return rNew
    End Function

    Public Function getObjectRelRow(ByVal IDGuidObject As System.Guid, ByVal ds As dsObjects, ByVal typSel As eTypSelAnspr) As dsObjects.tblObjectRelRow
        Me.getObjectRel(IDGuidObject, ds, typSel)
        If ds.tblObjectRel.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblObjectRel.Rows.Count = 1 Then
            Return ds.tblObjectRel.Rows(0)
        ElseIf ds.tblObjectRel.Rows.Count > 1 Then
            Throw New Exception("getObjectRelRow.id: Mehr als ein Object zu IDGuidObject '" + IDGuidObject.ToString() + "' gefunden!")
            Return Nothing
        End If
    End Function
    Public Function getObjectRel(ByVal IDGuidObject As System.Guid, ByRef ds As dsObjects, ByVal typSel As eTypSelAnspr) As Boolean

        Me.daObjectRel.SelectCommand.CommandText = Me.sel_daObjectRel
        database.setConnection(Me.daObjectRel)
        Me.daObjectRel.SelectCommand.Parameters.Clear()

        If typSel = eTypSelAnspr.id Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObjectRel.IDGuidColumn.ColumnName)
            Me.daObjectRel.SelectCommand.CommandText += sWhere
            Me.daObjectRel.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObjectRel.IDGuidColumn.ColumnName), IDGuidObject)

        ElseIf typSel = eTypSelAnspr.idObject Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObjectRel.IDGuidObjectColumn.ColumnName)
            Me.daObjectRel.SelectCommand.CommandText += sWhere
            Me.daObjectRel.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObjectRel.IDGuidObjectColumn.ColumnName), IDGuidObject)

        ElseIf typSel = eTypSelAnspr.idObjectSub Then
            Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblObjectRel.IDGuidObjectSubColumn.ColumnName)
            Me.daObjectRel.SelectCommand.CommandText += sWhere
            Me.daObjectRel.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblObjectRel.IDGuidObjectSubColumn.ColumnName), IDGuidObject)

        Else
            Throw New Exception("sqlObjects.getObjectRel: typSel '" + typSel.ToString() + "' is wrong!")
        End If

        Me.daObjectRel.Fill(ds.tblObjectRel)
        Return True

    End Function
    Public Function getNewRowObjectRel(ByVal dsObject1 As dsObjects) As dsObjects.tblObjectRelRow
        Dim rNew As dsObjects.tblObjectRelRow = dsObject1.tblObjectRel.NewRow()
        rNew.IDGuid = System.Guid.NewGuid()
        rNew.IDGuidObject = System.Guid.Empty
        rNew.IDGuidObjectSub = System.Guid.Empty
        dsObject1.tblObjectRel.Rows.Add(rNew)
        Return rNew
    End Function
    Public Function deleteObjectRelSub(ByVal IDObject As System.Guid) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = "delete " + qs2.core.dbBase.dbSchema + ds.tblObjectRel.TableName + sqlTxt.where + " IDGuidObject='" + IDObject.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            cmd = New SqlClient.SqlCommand
            cmd.CommandText = "delete " + qs2.core.dbBase.dbSchema + ds.tblObjectRel.TableName + sqlTxt.where + " IDGuidObjectSub='" + IDObject.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteObjectRelSub: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getSqlWhereSupervisor(ByRef sqlCommand As String, ByRef ds As dsObjects)

        If Not actUsr.rUsr Is Nothing Then
            If actUsr.rUsr.UserName.ToLower().Trim() <> sqlObjects.userName_Supervisor.Trim().ToLower() Then
                Dim sqlWhereSupervisor As String = ds.tblObject.UserNameColumn.ColumnName + sqlTxt.notEquals + " '" + sqlObjects.userName_Supervisor + "' "
                sqlCommand += IIf(sqlCommand.Contains(sqlTxt.where.Trim()), sqlTxt.and, sqlTxt.where) + sqlWhereSupervisor
            End If
        Else
            Dim sqlWhereSupervisor As String = ds.tblObject.UserNameColumn.ColumnName + sqlTxt.notEquals + " '" + sqlObjects.userName_Supervisor + "' "
            sqlCommand += IIf(sqlCommand.Contains(sqlTxt.where.Trim()), sqlTxt.and, sqlTxt.where) + sqlWhereSupervisor
        End If

    End Function


    Public Function getStaysRow(ByVal id As Integer, ByVal typSel As eTypSelStay,
                                ByVal application As String,
                                ByVal StayTyp As qs2.core.Enums.eStayTyp,
                                ByVal IDParticipant As String,
                                ByVal IDGuid As System.Guid, IsHeadQuarter As Boolean) As dsObjects.tblStayRow

        Dim ds As New dsObjects()
        Me.getStay(id, "", Nothing, Nothing, ds, typSel, application.ToString(), StayTyp, IDParticipant, IDGuid, "", qs2.core.Enums.eSearchType.Simple,
                   IsHeadQuarter, -1, Nothing, -1, False, "", "", -1, -1, -1, "")
        If ds.tblStay.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.tblStay.Rows.Count = 1 Then
            Return ds.tblStay.Rows(0)
        ElseIf ds.tblStay.Rows.Count > 1 Then
            Throw New Exception("getStayRow.id: More than one Row for id '" + id.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function getStay(ByVal id As Integer, ByVal strSearch As String, ByVal datSearchFrom As Date, ByVal datSearchTo As Date,
                            ByRef ds As dsObjects,
                            ByVal typSel As eTypSelStay,
                            ByVal application As String,
                            ByVal StayTyp As qs2.core.Enums.eStayTyp,
                            ByVal IDParticipant As String,
                            ByVal IDGuid As System.Guid,
                            ByVal Nr As String,
                            ByVal SpecialSearch As qs2.core.Enums.eSearchType, IsHeadquarter As Boolean,
                            ByVal Incidence As Integer, IDGuidNot As Nullable(Of System.Guid),
                            ByVal Active As Integer, DateIsAdmitDate As Boolean,
                            INKlauselObjectFields As String, INKlauselSheriffs As String,
                            IsSurgical As Integer, IsCardiological As Integer, IsCongenital As Integer, sWhereStayIDGuid As String,
                            Optional repairSurg115 As Boolean = False, Optional sqlWhereAdmin As String = "") As Boolean

        Try
            Me.daStay.SelectCommand.CommandText = Me.sel_daStay
            database.setConnection(Me.daStay)
            Me.daStay.SelectCommand.CommandTimeout = 7200
            Me.daStay.SelectCommand.Parameters.Clear()

            If typSel = eTypSelStay.IDIDParticipant Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDColumn.ColumnName) +
                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName)
                'Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName), id)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), IDParticipant)

            ElseIf typSel = eTypSelStay.searchStaysForRecordID Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDColumn.ColumnName) +
                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName) +
                                         sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                'Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName), id)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), IDParticipant)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)

            ElseIf typSel = eTypSelStay.DeleteStaysAutoStart Then
                'Dim AdmDatToDelete As Date = datSearchFrom.Date
                'If ENV.XMonthDeleteStaysStartUp > 0 Then
                '    AdmDatToDelete = AdmDatToDelete.AddMonths((ENV.XMonthDeleteStaysStartUp * -1))
                'End If
                Dim sWhere As String = " where IDGuid<>'" + System.Guid.NewGuid.ToString() + "' and IsActive= 0 and Surgeon = -1 AND SurgDtStart IS NULL "
                If datSearchFrom <> Nothing Then
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.greaterEquals, "From")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName + "From"), datSearchFrom.Date)
                End If
                If datSearchTo <> Nothing Then
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.smallerEquals, "To")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName) + "To", datSearchTo.Date)
                End If

                Me.daStay.SelectCommand.CommandText += sWhere
                'Me.daStay.SelectCommand.CommandText += sqlTxt.where + ds.tblStay.AdmitDtColumn.ColumnName + "<" + sqlTxt.sMonkey + ds.tblStay.AdmitDtColumn.ColumnName + " and " +
                '                    " IsActive= 0 and Surgeon = -1 AND SurgDtStart IS NULL "
                'Me.daStay.SelectCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName), System.Data.SqlDbType.DateTime, 0, sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName))).Value = AdmDatToDelete.Date
                Dim whereOK As Boolean = True

            ElseIf typSel = eTypSelStay.IDIDApplicationIDParticipant Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDColumn.ColumnName) +
                                        sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName) +
                                          sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName), id)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), IDParticipant)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)

            ElseIf typSel = eTypSelStay.IDGuidStay Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDGuidColumn.ColumnName)
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDGuidColumn.ColumnName), IDGuid)

            ElseIf typSel = eTypSelStay.allPatient Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.PatIDGuidColumn.ColumnName)
                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then _
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)

                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.PatIDGuidColumn.ColumnName), IDGuid)
                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then _
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)

                Me.daStay.SelectCommand.CommandText += " and " + ds.tblStay.StayTypColumn.ColumnName + "=0"

                'Me.daStay.SelectCommand.CommandText += sqlTxt.orderBy + ds.tblStay.IDStayParentColumn.ColumnName + sqlTxt.asc

            ElseIf typSel = eTypSelStay.allPatientSimple Then
                Dim sWhere As String = " where PatIDGuid='" + IDGuid.ToString() + "' and StayTyp=0 "
                Dim sOrderBy As String = " order by MedRecN asc, IDApplication asc, IDParticipant asc "
                Me.daStay.SelectCommand.CommandText += sWhere + sOrderBy

            ElseIf typSel = eTypSelStay.allPatientAllAplicationsAllparticipants Then
                Dim sWhere As String = sqlTxt.where + ds.tblStay.PatIDGuidColumn.ColumnName + "='" + IDGuid.ToString() + "'"
                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.CommandText += " order by MedRecN asc, IDApplication asc"

            ElseIf typSel = eTypSelStay.IDObjectForApplication Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.PatIDGuidColumn.ColumnName)
                If StayTyp <> Enums.eStayTyp.All Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                End If
                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then _
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)

                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                If Incidence > 0 Then
                    sWhere += " and " + ds.tblStay.IncidenceColumn.ColumnName + "=" + Incidence.ToString() + ""
                End If
                If Not IDGuidNot Is Nothing Then
                    sWhere += " and " + ds.tblStay.IDGuidColumn.ColumnName + "<>'" + IDGuidNot.ToString() + "' "
                End If
                Me.daStay.SelectCommand.CommandText += sWhere

                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.PatIDGuidColumn.ColumnName), IDGuid)
                If StayTyp <> Enums.eStayTyp.All Then
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If
                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then _
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)

            ElseIf typSel = eTypSelStay.AdmDtFromTo Then
                Dim sWhere As String = ""
                If application.Trim() = "" Then
                    Throw New Exception("getStay: application='' not allowed!")
                End If
                sWhere += sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application.Trim())

                If datSearchFrom <> Nothing Then
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.greaterEquals, "From")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName + "From"), datSearchFrom.Date)
                End If
                If datSearchTo <> Nothing Then
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.smallerEquals, "To")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName) + "To", datSearchTo.Date)
                End If

                If strSearch.Trim() <> "" Then
                    sWhere += sqlTxt.and + " MedRecN='" + strSearch.Trim() + "' "
                End If

                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.CommandText += " order by AdmitDt desc"

            ElseIf typSel = eTypSelStay.SendStay Then

                Dim sWhere As String = ""
                Dim sWhereSTS As String
                Dim sWhereSTSIncorrectlyStaysFromServer As String

                Select Case SpecialSearch
                    Case Enums.eSearchType.STS
                        sWhere = sqlTxt.where + getSQLForSTS(datSearchFrom, datSearchTo, ds, application, StayTyp, IDParticipant, Nr, SpecialSearch,
                                      Active, DateIsAdmitDate, IsSurgical, IsCardiological, IsCongenital, "", repairSurg115)
                    Case Enums.eSearchType.STSIncorrectlyStaysFromServer
                        sWhere = sqlTxt.where + getSQLForSTS(datSearchFrom, datSearchTo, ds, application, StayTyp, IDParticipant, Nr, SpecialSearch,
                                      Active, DateIsAdmitDate, IsSurgical, IsCardiological, IsCongenital, sWhereStayIDGuid, repairSurg115)
                    Case Enums.eSearchType.STSAndSTSIncorrectlyStaysFromServer
                        sWhereSTS = getSQLForSTS(datSearchFrom, datSearchTo, ds, application, StayTyp, IDParticipant, Nr, Enums.eSearchType.STS,
                                      Active, DateIsAdmitDate, IsSurgical, IsCardiological, IsCongenital, "", repairSurg115)
                        sWhereSTSIncorrectlyStaysFromServer = getSQLForSTS(datSearchFrom, datSearchTo, ds, application, StayTyp, IDParticipant, Nr, Enums.eSearchType.STSIncorrectlyStaysFromServer,
                                      Active, DateIsAdmitDate, IsSurgical, IsCardiological, IsCongenital, sWhereStayIDGuid, repairSurg115)
                        sWhere = sqlTxt.where + "(" + sWhereSTS + ") OR (" + sWhereSTSIncorrectlyStaysFromServer + ")"
                    Case Else
                        sWhere = sqlTxt.where + getSQLForSTS(datSearchFrom, datSearchTo, ds, application, StayTyp, IDParticipant, Nr, SpecialSearch,
                                      Active, DateIsAdmitDate, IsSurgical, IsCardiological, IsCongenital, "", repairSurg115)
                End Select

                If Not String.IsNullOrEmpty(sqlWhereAdmin) Then
                    Dim db As PMDS.db.Entities.ERModellPMDSEntities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                    With db
                        Dim tSelListEntriesViews = (From s In db.tblSelListEntries
                                                    Join sg In db.tblSelListGroup On sg.ID Equals s.IDGroup
                                                    Where sg.IDApplication = "ALL" And sg.IDGroupStr = "ViewsQueries"
                                                    Select ID2 = s.ID, s.IDRessource, IDGuid2 = s.IDGuid).ToList()

                        Dim sFromTables As String = " qs2.tblStay "
                        Dim sWhereTables As String = ""
                        For Each rSelListViews In tSelListEntriesViews
                            sFromTables += ", qs2." + rSelListViews.IDRessource
                            sWhereTables += IIf(String.IsNullOrEmpty(sWhereTables), " ", " and ") + "qs2." + rSelListViews.IDRessource + ".IDGuid=qs2.tblStay.IDGuid "
                        Next

                        Me.daStay.SelectCommand.CommandText = Me.daStay.SelectCommand.CommandText.Replace(" qs2.tblStay", sFromTables)
                        Me.daStay.SelectCommand.CommandText = Me.daStay.SelectCommand.CommandText.Replace(" IDGuid,", " qs2.tblStay.IDGuid,")
                        sWhere += IIf(String.IsNullOrEmpty(sWhere), " where ", " and ") + sWhereTables
                        Dim sqlWhereSubTmp As String = " qs2.tblStay.IDGuid IN (Select IDGuid from qs2." + application + "_Stays where " + sqlWhereAdmin + ") "
                        sWhere += IIf(String.IsNullOrEmpty(sWhere), " where ", " and ") + sqlWhereSubTmp
                    End With
                End If

                Me.daStay.SelectCommand.CommandText += sWhere
                Me.daStay.SelectCommand.CommandText += " order by PatIDGuid asc"

            ElseIf typSel = eTypSelStay.MedRecN Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.MedRecNColumn.ColumnName)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.MedRecNColumn.ColumnName), strSearch)

                If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If

                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                End If
                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.OrgUnitStay Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.OrgUnitStayColumn.ColumnName)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.OrgUnitStayColumn.ColumnName), strSearch)

                If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If

                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                End If
                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.MedRecNIncidence Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.MedRecNColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IncidenceColumn.ColumnName)

                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.MedRecNColumn.ColumnName), strSearch)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IncidenceColumn.ColumnName), Incidence)

                If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If

                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                    sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                End If

                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.FollowUpDate Then    'Wenn FollowUpDate = Nothing -> keine Datumsbeschränkung
                Dim sWhere As String = ""
                If datSearchFrom <> Nothing Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + " " + ds.tblStay.FUPDtPlanColumn.ColumnName + ">=" + sqlTxt.sMonkey + ds.tblStay.FUPDtPlanColumn.ColumnName + "1"
                    Me.daStay.SelectCommand.Parameters.AddWithValue(ds.tblStay.FUPDtPlanColumn.ColumnName + "1", datSearchFrom.Date)
                End If

                If datSearchTo <> Nothing Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + " " + ds.tblStay.FUPDtPlanColumn.ColumnName + "<=" + sqlTxt.sMonkey + ds.tblStay.FUPDtPlanColumn.ColumnName + "2"
                    Me.daStay.SelectCommand.Parameters.AddWithValue(ds.tblStay.FUPDtPlanColumn.ColumnName + "2", datSearchTo)
                End If

                If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If

                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                End If

                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.SurgDt Then
                Dim sWhere As String = ""
                If datSearchFrom <> Nothing Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + " " + ds.tblStay.SurgDtStartColumn.ColumnName + ">=" + sqlTxt.sMonkey + ds.tblStay.SurgDtStartColumn.ColumnName + "1"
                    Me.daStay.SelectCommand.Parameters.AddWithValue(ds.tblStay.SurgDtStartColumn.ColumnName + "1", datSearchFrom.Date)
                End If

                If datSearchTo <> Nothing Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + " " + ds.tblStay.SurgDtStartColumn.ColumnName + "<=" + sqlTxt.sMonkey + ds.tblStay.SurgDtStartColumn.ColumnName + "2"
                    Me.daStay.SelectCommand.Parameters.AddWithValue(ds.tblStay.SurgDtStartColumn.ColumnName + "2", datSearchTo)
                End If

                If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                End If

                If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                End If

                Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                If sqlWhereObj.Trim() <> "" Then
                    sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                End If
                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.CheckMedRecNrWithoutIDStay Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.MedRecNColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IncidenceColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName)

                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.MedRecNColumn.ColumnName), strSearch)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IncidenceColumn.ColumnName), System.Convert.ToInt32(Nr.Trim()))
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), IDParticipant)

                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.CheckMedRecNr Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.MedRecNColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IncidenceColumn.ColumnName)
                sWhere += sqlTxt.and + ds.tblStay.IDColumn.ColumnName + " <> " + sqlTxt.sMonkey + ds.tblStay.IDColumn.ColumnName + " "

                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.MedRecNColumn.ColumnName), strSearch)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IncidenceColumn.ColumnName), System.Convert.ToInt32(Nr.Trim()))
                Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName), id)

                Me.daStay.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelStay.CPBSerialNumber Then

                Dim sWhere As String = ""

                If application.Trim.ToLower() = qs2.core.license.doLicense.eApp.CARDIAC.ToString().ToLower() Then
                    sWhere += IIf(sWhere = "", sqlTxt.where, sqlTxt.and) + SearchInSubtables(qs2.core.Enums.eSearchInSubtables.CPBNumber, strSearch)

                    If StayTyp <> qs2.core.Enums.eStayTyp.All Then
                        sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                        Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
                    End If

                    If application.Trim().ToLower() <> license.doLicense.eApp.ALL.ToString().Trim().ToLower() Then
                        sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
                        Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application)
                    End If

                    Me.genSqlWhereParticipant(IsHeadquarter, sWhere, IDParticipant, False)
                    Dim sqlWhereObj As String = Me.getWhereObjectsStay(INKlauselSheriffs, INKlauselObjectFields)
                    If sqlWhereObj.Trim() <> "" Then
                        sWhere += " " + IIf(sWhere.Trim() = "", sqlTxt.where, sqlTxt.and) + " " + sqlWhereObj
                    End If
                    Me.daStay.SelectCommand.CommandText += sWhere

                Else
                    Throw New Exception("sqlObjects.getStay: typSel '" + typSel.ToString() + "' now allowed for IDApplication '" + application.ToString() + "'!")
                End If

            Else
                Throw New Exception("sqlObjects.getStay: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daStay.Fill(ds.tblStay)
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.getStay: " + ex.ToString())
        End Try
    End Function

    Private Function getSQLForSTS(datSearchFrom As Date,
                                  datSearchTo As Date,
                                  ds As dsObjects,
                                  application As String,
                                  StayTyp As qs2.core.Enums.eStayTyp,
                                  IDParticipant As String,
                                  Nr As String,
                                  SpecialSearch As qs2.core.Enums.eSearchType,
                                  Active As Integer,
                                  DateIsAdmitDate As Boolean,
                                  IsSurgical As Integer,
                                  IsCardiological As Integer,
                                  IsCongenital As Integer,
                                  sWhereStayIDGuid As String,
                                  repairSurg115 As Boolean) As String

        Try
            Dim sLicCardiac As String = license.doLicense.eApp.CARDIAC.ToString()

            Dim sWhere As String = " 1=1 "
            Dim sWhereTmp3 As String = ""
            Me.genSqlSurgOrCardio(IsSurgical, IsCardiological, IsCongenital, sWhereTmp3)
            If sWhereTmp3.Trim() <> "" Then
                sWhere += " and " + sWhereTmp3 + " "
            End If

            If SpecialSearch <> Enums.eSearchType.STSIncorrectlyStaysFromServer And SpecialSearch <> Enums.eSearchType.STSAndSTSIncorrectlyStaysFromServer Then
                If Active = 1 Then
                    sWhere += sqlTxt.and + ds.tblStay.IsActiveColumn.ColumnName + " = 1 "
                ElseIf Active = 0 Then
                    sWhere += sqlTxt.and + ds.tblStay.IsActiveColumn.ColumnName + " = 0 "
                End If
            End If

            If IDParticipant.Trim() <> license.doLicense.eApp.ALL.ToString() And IDParticipant.Trim() <> "" Then
                sWhere += sqlTxt.and + sqlTxt.getWhereString(ds.tblStay.IDParticipantColumn.ColumnName, IDParticipant)
                'sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName)
                'Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), IDParticipant.ToString())
            End If

            Dim bSearchFUPs As Boolean = False
            If StayTyp = Enums.eStayTyp.FollowUp Then
                bSearchFUPs = True
            End If
            If StayTyp <> Enums.eStayTyp.All Then
                sWhere += sqlTxt.and + sqlTxt.getWhereInt(ds.tblStay.StayTypColumn.ColumnName, StayTyp)
                'sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.StayTypColumn.ColumnName)
                'Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.StayTypColumn.ColumnName), CInt(StayTyp))
            Else
                Dim bAllStays As Boolean = True
            End If

            sWhere += sqlTxt.and + sqlTxt.getWhereString(ds.tblStay.IDApplicationColumn.ColumnName, application)
            'sWhere += sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)
            'Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), application.Trim())

            If SpecialSearch <> Enums.eSearchType.STSIncorrectlyStaysFromServer Then
                If datSearchFrom <> Nothing And Not DateIsAdmitDate Then
                    Dim dFromTmp As New Date(datSearchFrom.Date.Year, datSearchFrom.Date.Month, datSearchFrom.Date.Day, 0, 0, 0)
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.SurgDtStartColumn.ColumnName, sqlTxt.greaterEquals, "From")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.SurgDtStartColumn.ColumnName + "From"), dFromTmp)
                End If
                If datSearchTo <> Nothing And Not DateIsAdmitDate Then
                    Dim dToTmp As New Date(datSearchTo.Date.Year, datSearchTo.Date.Month, datSearchTo.Date.Day, 23, 59, 59)
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.SurgDtStartColumn.ColumnName, sqlTxt.smallerEquals, "To")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.SurgDtStartColumn.ColumnName) + "To", dToTmp)
                End If
                If datSearchFrom <> Nothing And DateIsAdmitDate Then
                    Dim dFromTmp As New Date(datSearchFrom.Date.Year, datSearchFrom.Date.Month, datSearchFrom.Date.Day, 0, 0, 0)
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.greaterEquals, "From")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName + "From"), dFromTmp)
                End If
                If datSearchTo <> Nothing And DateIsAdmitDate Then
                    Dim dToTmp As New Date(datSearchTo.Date.Year, datSearchTo.Date.Month, datSearchTo.Date.Day, 23, 59, 59)
                    sWhere += sqlTxt.and + sqlTxt.getColWherePost(ds.tblStay.AdmitDtColumn.ColumnName, sqlTxt.smallerEquals, "To")
                    Me.daStay.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName) + "To", dToTmp)
                End If
            End If

            If bSearchFUPs Then
                If (SpecialSearch = Enums.eSearchType.STS) Then
                    sWhere += sqlTxt.and + " " + ds.tblStay.SentColumn.ColumnName + " =0 "
                ElseIf (SpecialSearch = Enums.eSearchType.Simple) Then
                    Dim bSpecialSearchSimple As Boolean = True
                Else
                    Throw New Exception("getStay: SearchType is not FUP (bSearchFUPs=false) and SearchType is not KAV or AKH or EACTS or STS!")
                End If

            Else
                If (SpecialSearch = Enums.eSearchType.STS) Then           'Completed = true, tblStay_CARDIAC_A_E.IsAquired = true, SentDate = null
                    sWhere += sqlTxt.and + " " + ds.tblStay.StayCompleteColumn.ColumnName + " = 1 "
                    sWhere += sqlTxt.and + " " + ds.tblStay.SentColumn.ColumnName + " = 0 "

                    If application.Equals(sLicCardiac, StringComparison.OrdinalIgnoreCase) Then
                        sWhere += sqlTxt.and + SearchInSubtables(qs2.core.Enums.eSearchInSubtables.IsAquired, "")
                    End If

                ElseIf (SpecialSearch = Enums.eSearchType.EACTS) Then     'Completed = true, tblStay_CARDIAC_A_E.IsCongenital = true, SentDate = null
                    sWhere += sqlTxt.and + " " + ds.tblStay.StayCompleteColumn.ColumnName + " = 1 "
                    sWhere += sqlTxt.and + SearchInSubtables(qs2.core.Enums.eSearchInSubtables.IsCongenital, "")

                ElseIf (SpecialSearch = Enums.eSearchType.KAV Or SpecialSearch = Enums.eSearchType.AKH) Then       'tblStay_CARDIAC_A_E.IsAquired = true, Records in tblMedArchiv with SendDate = NULL
                    sWhere += sqlTxt.and + SearchInSubtables(qs2.core.Enums.eSearchInSubtables.UnsentMedArchiv, "")

                ElseIf (SpecialSearch = Enums.eSearchType.Simple) Then
                    Dim bSpecialSearchSimple As Boolean = True

                ElseIf (SpecialSearch = Enums.eSearchType.STSIncorrectlyStaysFromServer) Then
                    If application.Equals(sLicCardiac, StringComparison.OrdinalIgnoreCase) Then
                        sWhere += sqlTxt.and + SearchInSubtables(qs2.core.Enums.eSearchInSubtables.IsAquired, "")
                    End If

                Else
                    Throw New Exception("getStay: SearchType is not FUP (bSearchFUPs=false) and SearchType is not KAV or AKH or EACTS or STS!")
                End If

            End If

            If Nr.Trim() <> "" Then
                sWhere += sqlTxt.and + ds.tblStay.MedRecNColumn.ColumnName + " like '%" + Nr.Trim() + "%' "
            End If
            If sWhereStayIDGuid.Trim() <> "" Then
                sWhere += sqlTxt.and + sWhereStayIDGuid
            End If

            If repairSurg115 Then
                sWhere += " and (Select Count(*) From qs2.tblStay_CARDIAC_P1_Z where " +
                " qs2.tblStay.ID = qs2.tblStay_CARDIAC_P1_Z.ID And qs2.tblStay.IDParticipant = qs2.tblStay_CARDIAC_P1_Z.IDParticipant And " +
                " qs2.tblStay.IDApplication = qs2.tblStay_CARDIAC_P1_Z.IDApplication And " +
                " (((Not VAC1Date Is null) And VAC1Surg=-1) Or ((Not VAC2Date Is null) And VAC2Surg=-1) Or " +
                " ((Not VAC3Date Is null) And VAC3Surg=-1) Or ((Not VAC4Date Is null) And VAC4Surg=-1) Or " +
                " ((Not VAC5Date Is null) And VAC5Surg=-1) Or ((Not VAC6Date Is null) And VAC6Surg=-1) Or " +
                " ((Not VAC7Date Is null) And VAC7Surg=-1) Or ((Not VAC8Date Is null) And VAC8Surg=-1) Or " +
                " ((Not VAC9Date Is null) And VAC9Surg=-1) Or ((Not VAC10Date Is null) And VAC10Surg=-1) Or " +
                " ((Not VAC11Date Is null) And VAC11Surg=-1) Or ((Not VAC12Date Is null) And VAC12Surg=-1) Or " +
                " ((Not VAC13Date Is null) And VAC13Surg=-1) Or ((Not VAC14Date Is null) And VAC14Surg=-1) Or " +
                " ((Not VAC15Date Is null) And VAC15Surg=-1))) > 0 "
            End If

            Return sWhere

        Catch ex As Exception
            Throw New Exception("getSQLForSTS: " + ex.ToString())
        End Try
    End Function

    Public Sub genSqlSurgOrCardio(ByRef IsSurgical As Integer, ByRef IsCardiological As Integer, ByRef IsCongenital As Integer,
                                                               ByRef SqlWhere As String)
        Try
            Dim sWhereSurgeonRole As String = ""
            If IsSurgical = 1 And IsCardiological = -1 Then
                sWhereSurgeonRole = " (SurgeonRole=1  or SurgeonRole=-3) "
            ElseIf IsSurgical = -1 And IsCardiological = 1 Then
                sWhereSurgeonRole = " (SurgeonRole=9  or SurgeonRole=-3) "
            ElseIf IsSurgical = 1 And IsCardiological = 1 Then
                sWhereSurgeonRole = " (SurgeonRole=1 or SurgeonRole=9 or SurgeonRole=-3) "
            End If

            If Not String.IsNullOrEmpty(sWhereSurgeonRole) Then
                SqlWhere = " tblStay.IDGuid IN (Select qs2.tblStay.IDGuid FROM " +
                                    " qs2.tblStay_CARDIAC_A_E INNER JOIN " +
                                    " qs2.tblStay ON qs2.tblStay_CARDIAC_A_E.ID = qs2.tblStay.ID And qs2.tblStay_CARDIAC_A_E.IDParticipant = qs2.tblStay.IDParticipant And " +
                                    " qs2.tblStay_CARDIAC_A_E.IDApplication = qs2.tblStay.IDApplication " +
                                    " where " + sWhereSurgeonRole + ") "
            End If


            'If IsSurgical = 1 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsSurgical=1")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'ElseIf IsSurgical = 0 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsSurgical=0")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'End If

            'If IsCardiological = 1 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsCardiological=1")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'ElseIf IsCardiological = 0 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsCardiological=0")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'End If

            'If IsCongenital = 1 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsCongenital=1")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'ElseIf IsCongenital = 0 Then
            '    Dim sqlTmp3 As String = sqlTmp.Replace("{0}", "IsCongenital=0")
            '    SqlWhere += IIf(SqlWhere.Trim() = "", " ", " and ") + sqlTmp3
            'End If

        Catch ex As Exception
            Throw New Exception("sqlObjects.genSqlSurgOrCardio: " + ex.ToString())
        End Try
    End Sub

    Public Sub genSqlWhereParticipant(ByRef IsHeadQuarter As Boolean, ByRef sqlWhere As String, ByRef IDParticipant As String, _
                                      ByRef orIsAdmin As Boolean)
        Try
            If Not IsHeadQuarter Then
                If IDParticipant.Trim() = "" Then
                    Throw New Exception("genSqlWhereParticipant: IDparticipant='' not allowed!")
                End If
                Dim SqlWhereTmp As String = " IDParticipant='" + IDParticipant.Trim() + "' "
                If orIsAdmin And qs2.core.vb.actUsr.rUsr.isAdmin Then
                    SqlWhereTmp = " (" + SqlWhereTmp + " or (isAdmin=1 and IDparticipant='' )) "
                End If
                If sqlWhere.Contains("where") Then
                    sqlWhere += " and " + SqlWhereTmp
                Else
                    sqlWhere += " where " + SqlWhereTmp
                End If
            End If

        Catch ex As Exception
            Throw New Exception("genSqlWhereParticipant: " + ex.ToString())
        End Try
    End Sub

    Public Function SearchInSubtables(ByRef SearchWhat As qs2.core.Enums.eSearchInSubtables, strSearch As String) As String
        Try
            If SearchWhat = qs2.core.Enums.eSearchInSubtables.CPBNumber Then
                Return " qs2.tblStay.ID IN  (Select ID from qs2.tblStay_CARDIAC_Z1_Z9 where LTRIM(RTRIM(CPBSerialNo)) = '" + strSearch.Trim + "')"
            ElseIf SearchWhat = qs2.core.Enums.eSearchInSubtables.IsCongenital Then
                Return " qs2.tblStay.ID IN  (Select ID from qs2.tblStay_CARDIAC_A_E where IsCongenital = 1)"
            ElseIf SearchWhat = qs2.core.Enums.eSearchInSubtables.IsAquired Then
                Return " qs2.tblStay.ID IN  (Select ID from qs2.tblStay_CARDIAC_A_E where IsAquired = 1)"
            ElseIf SearchWhat = qs2.core.Enums.eSearchInSubtables.UnsentMedArchiv Then
                Return " qs2.tblStay.ID IN  (Select IDStay from qs2.tblMedArchiv where Result = '')"
            End If

        Catch ex As Exception
            Throw New Exception("sqlObjects.getWhereproductStays: " + ex.ToString())
        End Try
    End Function

    Public Function getNextIDStay(IDParticipant As String, IDApplication As String) As Integer
        Dim dt As New DataTable()

        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " Select Max(ID) as LastID from " + qs2.core.dbBase.dbSchema + "tblStay where IDParticipant='" + IDParticipant.Trim() + "' and IDApplication = '" + IDApplication + "' "
        cmd.Connection = qs2.core.dbBase.dbConn
        da.SelectCommand = cmd
        da.Fill(dt)
        If dt.Rows.Count = 1 Then
            If dt.Rows(0)("LastID") Is System.DBNull.Value Then
                Return 1
            Else
                Return System.Convert.ToInt32(dt.Rows(0)("LastID") + 1)
            End If
        ElseIf dt.Rows.Count = 0 Then
            Return 1
        ElseIf dt.Rows.Count > 1 Then
            Throw New Exception("getNextIDStay: Error dt.Rows.Count > 1 !")
        End If
    End Function
    Public Sub getNextExtIDObject(IDParticipant As String, ByRef NextExtIDObject As String)

        Dim dt As New DataTable()          'lthxy
        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = "Select Top 1 CONVERT(decimal(20,0), ExtID) AS ExtID from" + qs2.core.dbBase.dbSchema + "tblObject " + _
                   " where IDParticipant = '" + IDParticipant + "'" + _
                   " and isnumeric(ExtID) = 1" + _
                   " order by  CONVERT(decimal(20,0), ExtID) desc"

        cmd.Connection = qs2.core.dbBase.dbConn
        da.SelectCommand = cmd
        da.Fill(dt)
        If dt.Rows.Count = 0 Then
            NextExtIDObject = "1"
        Else
            For Each rObj As DataRow In dt.Rows
                NextExtIDObject = (rObj("ExtID") + 1).ToString().Trim()
            Next
        End If

        'Dim dt As New DataTable()          'lthxy
        'Dim da As New SqlClient.SqlDataAdapter()
        'Dim cmd As New SqlClient.SqlCommand
        'cmd.CommandText = " Select distinct ExtID from " + qs2.core.dbBase.dbSchema + "tblObject " + " order by ExtID desc "

        'cmd.Connection = qs2.core.dbBase.dbConn
        'da.SelectCommand = cmd
        'da.Fill(dt)
        'If dt.Rows.Count > 0 Then
        '    Dim LastExtNr As Integer = 1
        '    For Each rObj As DataRow In dt.Rows
        '        Dim bOk As Boolean = False
        '        Try
        '            LastExtNr = System.Convert.ToInt32(rObj("ExtID").ToString())
        '            bOk = True
        '        Catch ex As Exception
        '            Dim str As String = ""
        '        End Try
        '        If bOk Then
        '            LastExtNr += 1
        '            NextExtIDObject = LastExtNr.ToString()
        '        End If
        '    Next
        '    NextExtIDObject = "1"
        'Else
        '    NextExtIDObject = "1"
        'End If
    End Sub
    Public Function getNextMedRecNrForProductAuto(ByRef IDParticipant As String, IDApplication As String, ByRef NextMedRecNrToReturn As String, _
                                                  ByRef StayTyp As qs2.core.Enums.eStayTyp) As Boolean
        Try
            Dim dt As New DataTable()
            Dim da As New SqlClient.SqlDataAdapter()
            Dim cmd As New SqlClient.SqlCommand

            Dim prefixMedRecNr As String = ""

            If StayTyp = Enums.eStayTyp.Stay Then
                prefixMedRecNr = ""
                cmd.CommandText = " Select Top 1 CONVERT(decimal(20,0), MedRecN) AS MedRecN from " + qs2.core.dbBase.dbSchema + "tblStay " + _
                    " where IDApplication = '" + IDApplication + "'" + _
                    " and IDParticipant = '" + IDParticipant + "'" + _
                    " and isnumeric(MedRecN) = 1" + _
                    " order by  CONVERT(decimal(20,0), MedRecN) desc"

            ElseIf StayTyp = Enums.eStayTyp.FollowUp Then
                prefixMedRecNr = "FUP_"
                cmd.CommandText = " Select Top 1 CONVERT(decimal(20,0), substring(MedRecN, 5, 100)) AS MedRecN from  " + qs2.core.dbBase.dbSchema + "tblStay " + _
                    " where IDApplication = '" + IDApplication + "'" + _
                    " and IDParticipant = '" + IDParticipant + "'" + _
                    " and Left(MedRecN, 4) = 'FUP_'" + _
                    " order by  CONVERT(decimal(20,0), substring( MedRecN, 5, 100)) desc"
            Else
                Throw New Exception("StayTyp '" + StayTyp.ToString() + "' not supported!")
            End If

            cmd.Connection = qs2.core.dbBase.dbConn
            da.SelectCommand = cmd
            da.Fill(dt)
            If dt.Rows.Count = 0 Then
                NextMedRecNrToReturn = prefixMedRecNr + "1"
            Else
                For Each rStay As DataRow In dt.Rows
                    Try
                        NextMedRecNrToReturn = prefixMedRecNr + (rStay("MedRecN") + 1).ToString().Trim()
                    Catch ex As Exception
                        Throw New Exception("getNextMedRecNrForProductAuto: " + ex.ToString())
                    End Try
                Next
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.getNextMedRecNrForProductAuto: " + ex.ToString())
        End Try
    End Function

    Public Function getIncidenceForMedRecNr(MedRecNr As String, IDParticipant As String, IDApplication As String) As Integer
        Dim dt As New DataTable()

        Dim da As New SqlClient.SqlDataAdapter()
        Dim cmd As New SqlClient.SqlCommand
        cmd.CommandText = " Select Max(Incidence) as LastIncidence from " + qs2.core.dbBase.dbSchema + "tblStay where MedRecN='" + MedRecNr.Trim() + "' and IDParticipant='" + IDParticipant.Trim() + "' and IDApplication = '" + IDApplication + "' "
        cmd.Connection = qs2.core.dbBase.dbConn
        da.SelectCommand = cmd
        da.Fill(dt)
        If dt.Rows.Count = 1 Then
            If dt.Rows(0)("LastIncidence") Is System.DBNull.Value Then
                Return 1
            Else
                Return System.Convert.ToInt32(dt.Rows(0)("LastIncidence") + 1)
            End If
        ElseIf dt.Rows.Count = 0 Then
            Return 1
        ElseIf dt.Rows.Count > 1 Then
            Throw New Exception("getIncidenceForMedRecNr: Error dt.Rows.Count > 1 !")
        End If

    End Function

    Public Function getNewRowStay(ByVal dsStay1 As dsObjects) As dsObjects.tblStayRow
        Dim rNew As dsObjects.tblStayRow = dsStay1.tblStay.NewRow()
        rNew.ID = -999
        rNew.IDApplication = ""
        rNew.IDParticipant = ""
        rNew.MedRecN = ""
        rNew.Incidence = 1
        rNew.SetIDStayParentNull()
        rNew.SetIDParticipantParentNull()
        rNew.SetIDApplicationParentNull()
        rNew.SetOPTypNull()
        rNew.StayTyp = CInt(qs2.core.Enums.eStayTyp.Stay)
        rNew.SetSurgDtStartNull()
        rNew.SetSurgDtEndNull()
        rNew.SetFUPDtPlanNull()
        rNew.SetFUPDtNull()
        rNew.SurgDuratMin = 0
        rNew.SetAdmitDtNull()
        rNew.PatIDGuid = System.Guid.Empty
        rNew.PatExtID = ""
        rNew.PatAge = 0
        rNew.PatHeight = 0
        rNew.PatWeight = 0
        rNew.PatBMI = 0
        rNew.SetDischDtNull()
        rNew.IsActive = False
        rNew.IsPlanned = False
        rNew.StayComplete = False
        rNew.IDVendor = "S2"
        rNew.DataVrsn = ""
        rNew.SoftVrsn = ""
        rNew.SoftVrsnTo = ""
        rNew.CreatedDt = Now
        rNew.IDGuid = System.Guid.NewGuid()

        rNew.Classification = ""
        rNew.Description = ""

        rNew.MtOpD = -1
        rNew.Mt30Stat = -1
        rNew.DisLocatn = -1
        rNew.MtDCStat = -1

        rNew.PatStreet = ""
        rNew.PatZIP = ""
        rNew.PatCity = ""
        rNew.PatCountryID = -1
        rNew.HasComplications = -1

        rNew.BMIGroup = -1

        rNew.Surgeon = -1
        rNew.Surg_Assist1 = -1
        rNew.Surg_Assist2 = -1
        rNew.Surg_Partim = -1
        rNew.Surg_ReOp = -1
        rNew.Surg_Assumption = -1
        rNew.Perfusionist = -1
        rNew.Perfusionist_Assist1 = -1
        rNew.Anaesthesist = -1
        rNew.Anaesthesist_Assist1 = -1
        rNew.Consultant = -1
        rNew.Resident = -1
        rNew.ScrubNurse = -1

        rNew.StayDuratDays = -1
        rNew.StayPostOpDuratDays = -1

        rNew.PatCountry = ""
        rNew.PatOrigin = -1
        rNew.PatTel = ""
        rNew.Payor = -1
        rNew.Sent = False
        rNew.IsSentDateNull()

        rNew.CongenitalData = ""
        rNew.OrgUnitStay = ""
        rNew.SetLastChangeNull()
        rNew.SetOpenSinceNull()

        rNew.BPKZ = ""
        rNew.BPKZDone = -1
        rNew.BPKZOK = False
        rNew.BPKZStatus = ""
        rNew.BPKZFinishedClient = False

        rNew.TransferOK = -1
        rNew.TransferProtocol = ""
        rNew.SetTransferFromNull()
        rNew.SurgeonRole = -1

        rNew.IDPredecessor = ""
        rNew.IDSucessors = ""
        rNew.PredecessorText = ""
        rNew.SucessorsText = ""

        dsStay1.tblStay.Rows.Add(rNew)

        Return rNew

    End Function
    Public Function deleteStayPatIDGuid(ByVal PatIDGuid As System.Guid) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblStay.TableName + sqlTxt.where + ds.tblStay.PatIDGuidColumn.ColumnName + "='" + PatIDGuid.ToString() + "'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteStayPatIDGuid: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function deleteStay(ByVal IDStay As Integer, ByVal IDParticipant As String, IDApplication As String) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblStay.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDColumn.ColumnName) +
                                sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantColumn.ColumnName) +
                                sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationColumn.ColumnName)

            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName))).Value = IDStay
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName), System.Data.SqlDbType.VarChar, 150, sqlTxt.getColPar(ds.tblStay.IDParticipantColumn.ColumnName))).Value = IDParticipant
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName), System.Data.SqlDbType.VarChar, 30, sqlTxt.getColPar(ds.tblStay.IDApplicationColumn.ColumnName))).Value = IDApplication

            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteStay: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function updateStay_FieldCongenitalData(ByVal IDObjectGuidNew As Guid, ByVal IDObjectGuidOld As Guid) As Boolean
        Try
            Dim tSel As New DataTable()
            Dim daSel As New System.Data.SqlClient.SqlDataAdapter()
            Dim cmdSel As New System.Data.SqlClient.SqlCommand
            cmdSel.CommandText = "Select IDGuid, CongenitalData from " + qs2.core.dbBase.dbSchema + " tblStay where CongenitalData like '%" + IDObjectGuidOld.ToString() + "%'"
            cmdSel.Connection = qs2.core.dbBase.dbConn
            cmdSel.CommandTimeout = 0
            daSel.SelectCommand = cmdSel
            daSel.Fill(tSel)

            For Each rStay As DataRow In tSel.Rows
                Dim IDGuidStay As System.Guid = rStay("IDGuid")
                Dim sCongenitalData As String = rStay("CongenitalData").ToString()
                sCongenitalData = sCongenitalData.Replace(IDObjectGuidOld.ToString().ToLower(), IDObjectGuidNew.ToString().ToUpper())
                sCongenitalData = sCongenitalData.Replace(IDObjectGuidOld.ToString().ToUpper(), IDObjectGuidNew.ToString().ToUpper())

                Dim cmdUpdate As New System.Data.SqlClient.SqlCommand
                cmdUpdate.CommandText = "Update" + qs2.core.dbBase.dbSchema + " tblStay set CongenitalData='" + sCongenitalData + "' where IDGuid='" + IDGuidStay.ToString() + "'"
                cmdUpdate.Connection = qs2.core.dbBase.dbConn
                cmdUpdate.CommandTimeout = 0
                cmdUpdate.ExecuteNonQuery()
            Next

            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.updateStay_FieldCongenitalData: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function deleteStayChilds(ByVal IDStayParent As Integer, ByVal IDParticipant As String, IDApplication As String) As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblStay.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IDStayParentColumn.ColumnName) + _
                                sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDParticipantParentColumn.ColumnName) + _
                                sqlTxt.and + sqlTxt.getColWhere(ds.tblStay.IDApplicationParentColumn.ColumnName)
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDStayParentColumn.ColumnName), System.Data.SqlDbType.Int, 4, sqlTxt.getColPar(ds.tblStay.IDColumn.ColumnName))).Value = IDStayParent
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDParticipantParentColumn.ColumnName), System.Data.SqlDbType.VarChar, 150, sqlTxt.getColPar(ds.tblStay.IDParticipantParentColumn.ColumnName))).Value = IDParticipant
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IDApplicationParentColumn.ColumnName), System.Data.SqlDbType.VarChar, 30, sqlTxt.getColPar(ds.tblStay.IDApplicationParentColumn.ColumnName))).Value = IDApplication

            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteStayChilds: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function deleteStays_AutoStartxyxy() As Boolean
        Try
            Dim ds As New dsObjects()
            Dim cmd As New SqlClient.SqlCommand()

            Dim AdmDatToDelete As Date = Now
            If ENV.XMonthDeleteStaysStartUp > 0 Then
                AdmDatToDelete = AdmDatToDelete.AddMonths((ENV.XMonthDeleteStaysStartUp * -1))
            End If

            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.tblStay.TableName + sqlTxt.where + sqlTxt.getColWhere(ds.tblStay.IsActiveColumn.ColumnName) +
                                sqlTxt.and + ds.tblStay.AdmitDtColumn.ColumnName + "<" + sqlTxt.sMonkey + ds.tblStay.AdmitDtColumn.ColumnName + ""

            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.IsActiveColumn.ColumnName), System.Data.SqlDbType.Bit, 0, sqlTxt.getColPar(ds.tblStay.IsActiveColumn.ColumnName))).Value = False
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter(sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName), System.Data.SqlDbType.DateTime, 0, sqlTxt.getColPar(ds.tblStay.AdmitDtColumn.ColumnName))).Value = AdmDatToDelete.Date

            cmd.Connection = qs2.core.dbBase.dbConn
            'cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.deleteStays_AutoStart: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getMedArchiv(ByVal IDGuidObject As System.Guid, _
                                   ByVal IDGuidStay As System.Guid, _
                                   ByRef ds As dsObjects, ByVal typSel As eTypSelMedArchiv, Status As String) As Boolean

        Try
            Me.daMedArchiv.SelectCommand.CommandText = "SELECT * FROM qs2.tblMedArchiv "
            database.setConnection(Me.daMedArchiv)
            Me.daMedArchiv.SelectCommand.Parameters.Clear()

            If typSel = eTypSelMedArchiv.IDStay Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblMedArchiv.IDStayGuidColumn.ColumnName)
                Me.daMedArchiv.SelectCommand.CommandText += sWhere
                Me.daMedArchiv.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblMedArchiv.IDStayGuidColumn.ColumnName), IDGuidStay)

            ElseIf typSel = eTypSelMedArchiv.IDObject Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblMedArchiv.IDObjectGuidColumn.ColumnName)
                Me.daMedArchiv.SelectCommand.CommandText += sWhere
                Me.daMedArchiv.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblMedArchiv.IDObjectGuidColumn.ColumnName), IDGuidObject)

            ElseIf typSel = eTypSelMedArchiv.IDGuid Then
                Dim sWhere As String = sqlTxt.where + sqlTxt.getColWhere(ds.tblMedArchiv.IDGuidColumn.ColumnName)
                Me.daMedArchiv.SelectCommand.CommandText += sWhere
                Me.daMedArchiv.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(ds.tblMedArchiv.IDGuidColumn.ColumnName), IDGuidObject)

            ElseIf typSel = eTypSelMedArchiv.DocuStatus Then
                Dim sWhere As String = sqlTxt.where + ds.tblMedArchiv.IDStayGuidColumn.ColumnName + "='" + IDGuidStay.ToString() + "' and " + _
                                    ds.tblMedArchiv.StatusColumn.ColumnName + "='" + Status.Trim() + "' and " + _
                                    " (not " + ds.tblMedArchiv.CreatedColumn.ColumnName + " is null) "
                Dim sOrderBy As String = " order by " + ds.tblMedArchiv.CreatedColumn.ColumnName + " desc;"
                Me.daMedArchiv.SelectCommand.CommandText += sWhere + sOrderBy

            Else
                Throw New Exception("sqlObjects.getMedArchiv: typSel '" + typSel.ToString() + "' is wrong!")
            End If

            Me.daMedArchiv.Fill(ds.tblMedArchiv)
            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.getMedArchiv: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function getLastDocument_VersionMedArchiv(IDParticipant As String, IDApplication As String, IDStayGuid As String) As Integer
        Try
            Dim dt As New DataTable()

            Dim da As New SqlClient.SqlDataAdapter()
            Dim cmd As New SqlClient.SqlCommand
            cmd.CommandText = " Select Max(Document_Version) as LastDocument_Version from " + qs2.core.dbBase.dbSchema + "tblMedArchiv where " + _
                                " IDParticipant='" + IDParticipant.Trim() + "' and IDApplication = '" + IDApplication + "' and IDStayGuid = '" + IDStayGuid + "' "
            cmd.Connection = qs2.core.dbBase.dbConn
            da.SelectCommand = cmd
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                If dt.Rows(0)("LastDocument_Version") Is System.DBNull.Value Then
                    Return 0
                Else
                    Return System.Convert.ToInt32(dt.Rows(0)("LastDocument_Version"))
                End If
            ElseIf dt.Rows.Count = 0 Then
                Return 0
            ElseIf dt.Rows.Count > 1 Then
                Throw New Exception("getNextDocument_VersionMedArchiv: Error dt.Rows.Count > 1 !")
            End If

        Catch ex As Exception
            Throw New Exception("getNextDocument_VersionMedArchiv: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowMedArchiv(ByVal dsObjects As dsObjects) As dsObjects.tblMedArchivRow
        Try
            Dim rNew As dsObjects.tblMedArchivRow = dsObjects.tblMedArchiv.NewRow()

            rNew.IDGuid = System.Guid.NewGuid()
            rNew.IDParticipant = ""
            rNew.IDApplication = ""
            rNew.SetIDObjectGuidNull()
            rNew.Document64 = ""
            rNew.SetSendDateNull()
            rNew.Status = ""
            rNew.Result = ""
            rNew.FileName = ""
            rNew.DocName = ""
            rNew.DocID = ""
            rNew.SetDocumentByteNull()
            rNew.Document_Version = 0
            rNew.DocumentInfo_HL7 = ""
            rNew.SetIDStayGuidNull()
            rNew.Description = ""
            rNew.SetCreatedNull()

            dsObjects.tblMedArchiv.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("getNewRowMedArchiv: " + ex.ToString())
        End Try
    End Function


    Public Function getObjectSmall(ByVal id As Integer, ByRef ds As dsObjects, ByVal typeSel As eTypSelObj) As Boolean
        Try
            Me.daObjectSmall.SelectCommand.CommandText = Me.sel_daObjectSmall
            database.setConnection(Me.daObjectSmall)
            Me.daObjectSmall.SelectCommand.Parameters.Clear()

            If typeSel = eTypSelObj.SearchForDeathStatus Then
                Dim sWhere As String = " where IsPatient=1 and (Select Count(*) from qs2.tblStay where StayComplete=1) > 0 and (MtStat=1 or MtStat=3 or MtStat=-1)"
                Dim sOrderBy As String = " order by NameCombination asc "
                Me.daObjectSmall.SelectCommand.CommandText += sWhere + sOrderBy

            Else
                Throw New Exception("sqlObjects.getObjectSmall: typeSel '" + typeSel.ToString() + "' is wrong!")
            End If

            Me.daObjectSmall.Fill(ds.tblObjectSmall)
            Return True

        Catch ex As Exception
            Throw New Exception("getObjectSmall: " + ex.ToString())
        End Try
    End Function

    Public Function getStaySmall(ByVal id As Integer, ByRef ds As dsObjects, ByVal typeSel As eTypSelStay,
                                 ByRef IDGuid As System.Guid, ByRef DeathDate As Date) As Boolean
        Try
            Me.daStaySmall.SelectCommand.CommandText = Me.sel_daStaySmall
            database.setConnection(Me.daStaySmall)
            Me.daStaySmall.SelectCommand.Parameters.Clear()

            If typeSel = eTypSelStay.SearchForDeathStatus Then
                'Dim DeathDateTmp As Date = DeathDate.Date.AddDays(30)
                Dim sWhere As String = " where PatIDGuid='" + IDGuid.ToString() + "' and (not SurgDtStart is null) and StayTyp=0 " +
                                        " "
                Dim sOrderBy As String = " order by MedRecN asc, IDApplication asc, IDParticipant asc "
                Me.daStaySmall.SelectCommand.CommandText += sWhere + sOrderBy

            Else
                Throw New Exception("sqlObjects.getStaySmall: typeSel '" + typeSel.ToString() + "' is wrong!")
            End If

            Me.daStaySmall.Fill(ds.tblStaySmall)
            Return True

        Catch ex As Exception
            Throw New Exception("getStaySmall: " + ex.ToString())
        End Try
    End Function

    Public Function getObjectApplications(ByVal IDGuid As System.Guid, ByRef ds As dsObjects, ByVal typeSel As eTypObj) As Boolean
        Try
            Me.daObjectApplications.SelectCommand.CommandText = Me.sel_daObjectApplications
            database.setConnection(Me.daObjectApplications)
            Me.daObjectApplications.SelectCommand.Parameters.Clear()

            If typeSel = eTypObj.all Then
                Dim sWhere As String = ""
                Dim sOrderBy As String = " order by IDApplication asc, IDObjectGuid asc "
                Me.daObjectApplications.SelectCommand.CommandText += sWhere + sOrderBy

            Else
                Throw New Exception("sqlObjects.getObjectApplications: typeSel '" + typeSel.ToString() + "' is wrong!")
            End If

            Me.daObjectApplications.Fill(ds.tblObjectApplications)
            Return True

        Catch ex As Exception
            Throw New Exception("getObjectApplications: " + ex.ToString())
        End Try
    End Function

End Class