Imports qs2.core




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

        Me.sel_daObjectSmall = Me.daObjectSmall.SelectCommand.CommandText
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
