Imports qs2.core

Public Class sqlObjects

    Public sel_daObject As String = ""
    Public database As New qs2.core.dbBase
    Public Shared userName_Supervisor As String = "Supervisor"
    Public isInitialized As Boolean = False

    Public Sub initControl()
        If Me.isInitialized Then
            Exit Sub
        End If

        Me.sel_daObject = Me.daObject.SelectCommand.CommandText
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

        Catch ex As Exception
            Throw New Exception("loadAllData: " + ex.ToString())
        End Try
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

                Me.daObject.SelectCommand.CommandText += " and ((" + ds.tblObject.IDParticipantColumn.ColumnName + "='" + Participant.Trim() + "' and " +
                                                        " " + ds.tblObject.IDParticipantColumn.ColumnName + "<>'' "

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

    Public Sub genSqlWhereParticipant(ByRef IsHeadQuarter As Boolean, ByRef sqlWhere As String, ByRef IDParticipant As String,
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
End Class
