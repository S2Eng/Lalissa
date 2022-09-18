Imports System.Data.OleDb
Imports Infragistics.Win.UltraWinGrid
Imports VB = Microsoft.VisualBasic




Public Class sqlProtocoll

    Public Shared seldaProtocol As String = ""
    Public database As New qs2.core.dbBase

    Public Enum eSelProtocoll
        ID = 924000
        OfUser = 924001
        All = 924002
        IDProtocol = 924003
        IDObject = 924004
        IDStay = 924005
        sKey = 924006
        SearchPatient = 924007
        SearchUser = 924008
        RunQuery = 924009
        RunReport = 924010
    End Enum

    Public Sub initControl()
        sqlProtocoll.seldaProtocol = Me.daProtocol.SelectCommand.CommandText
    End Sub

    'Diese Methode nicht löschen. Wird für PMDS benötigt!
    Public Function getProtocol(ByVal ID As System.Guid, ByRef dsProtocoll As dsProtocol, ByVal TypSel As eSelProtocoll,
                                Usr As String, IDGuidObject As System.Guid, IDStay As Integer, IDParticipant As String, sKey As String,
                                dFrom As Nullable(Of DateTime), dTo As Nullable(Of DateTime), txt As String, ByRef SqlCommandReturn As String) As Boolean

        getProtocol(ID, dsProtocoll, TypSel,
                                Usr, IDGuidObject, IDStay, IDParticipant, sKey,
                                dFrom, dTo, txt, SqlCommandReturn, False)
    End Function

    Public Function getProtocol(ByVal ID As System.Guid, ByRef dsProtocoll As dsProtocol, ByVal TypSel As eSelProtocoll,
                                Usr As String, IDGuidObject As System.Guid, IDStay As Integer, IDParticipant As String, sKey As String,
                                dFrom As Nullable(Of DateTime), dTo As Nullable(Of DateTime), txt As String, ByRef SqlCommandReturn As String, FilterUserApps As Boolean) As Boolean
        Try
            Dim lstTxtVars As New System.Collections.Generic.List(Of String)()
            If txt.Trim() <> "" Then
                lstTxtVars = Me.getVarsTxt(txt)
            End If

            'Filter result for Applied products of User only
            Dim sWhere = ""
            Dim FilterProductsEntries As String = ""
            Dim GuidUsr As Guid = If(actUsr.rUsr Is Nothing, Guid.Empty, actUsr.rUsr.IDGuid)
            Dim UserName As String = If(actUsr.rUsr Is Nothing, "NO USER LOGGED IN", actUsr.rUsr.UserName.Trim())

            If FilterUserApps And Not qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                Dim lstUsrApps As New List(Of String) From {"", qs2.core.license.doLicense.eApp.ALL.ToString()} 'ALL und Empty als Default, wenn User mindestens ein Produkt hat
                Dim b As businessFramework = New businessFramework()

                Using db As qs2.db.Entities.ERModellQS2Entities = qs2.core.db.ERSystem.businessFramework.getDBContext()
                    Dim tObjectApplications As IQueryable(Of qs2.db.Entities.tblObjectApplications) = b.getProductsForUser(GuidUsr, db)

                    If tObjectApplications.Count() > 0 Then
                        For Each rApp As qs2.db.Entities.tblObjectApplications In tObjectApplications
                            lstUsrApps.Add(rApp.IDApplication)
                        Next

                        For Each Product As String In lstUsrApps
                            FilterProductsEntries += IIf(String.IsNullOrWhiteSpace(FilterProductsEntries), "", " OR ")
                            FilterProductsEntries += "IDApplication = '" + Product + "'"
                        Next

                        FilterProductsEntries = "(" + FilterProductsEntries + ")"
                    Else
                        FilterProductsEntries = "(IDApplication = '" + qs2.core.license.doLicense.eApp.NONE.ToString() + "')"  'User hat kein Produkt zugeordnet -> darf keine Einträge im Log sehen
                    End If
                End Using
            End If

            Me.daProtocol.SelectCommand.CommandText = sqlProtocoll.seldaProtocol
            Me.daProtocol.SelectCommand.CommandTimeout = 0
            Me.database.setConnection(Me.daProtocol)
            Me.daProtocol.SelectCommand.Parameters.Clear()

            If TypSel = eSelProtocoll.ID Then
                sWhere = sqlTxt.where + sqlTxt.getColWhere(dsProtocoll.Protocol.IDGuidColumn.ColumnName)
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Me.daProtocol.SelectCommand.CommandText += sWhere
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.IDGuidColumn.ColumnName), ID)

            ElseIf TypSel = eSelProtocoll.OfUser Then
                sWhere = sqlTxt.where + "[" + dsProtocoll.Protocol.UserColumn.ColumnName + "]=@" + dsProtocoll.Protocol.UserColumn.ColumnName
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Me.daProtocol.SelectCommand.CommandText += sWhere
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.UserColumn.ColumnName), Usr)

            ElseIf TypSel = eSelProtocoll.All Then
                sWhere = ""
                If Not dFrom Is Nothing Then
                    sWhere += IIf(sWhere.Trim() = "", " where ", " and ") + " CreatedDay>=@CreatedDay1 "
                    Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.CreatedDayColumn.ColumnName + "1"), dFrom.Value.Date)
                End If
                If Not dTo Is Nothing Then
                    sWhere += IIf(sWhere.Trim() = "", " where ", " and ") + " CreatedDay<=@CreatedDay2 "
                    Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.CreatedDayColumn.ColumnName + "2"), dTo.Value.Date)
                End If

                Dim sWhereTxtSum As String = ""
                For Each vVar As String In lstTxtVars
                    Dim sWhereTxt As String = "  Protocol like '%" + vVar.Trim() + "%' or " +
                                                " Info like '%" + vVar.Trim() + "%' or " +
                                                " Sql like '%" + vVar.Trim() + "%' or " +
                                                " InfoFile like '%" + vVar.Trim() + "%' or " +
                                                " progress like '%" + vVar.Trim() + "%' or " +
                                                " Patient like '%" + vVar.Trim() + "%' or " +
                                                " IDParticipant like '%" + vVar.Trim() + "%' or " +
                                                " MedRecNr like '%" + vVar.Trim() + "%'  "

                    sWhereTxtSum += IIf(sWhereTxtSum.Trim() = "", " ", " or ") + sWhereTxt
                Next

                If sWhereTxtSum.Trim() <> "" Then
                    sWhere += IIf(sWhereTxtSum.Trim() = "", " where ", " and ") + " ( " + sWhereTxtSum + " ) "
                End If

                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Dim sOrderBy As String = " order by " + dsProtocoll.Protocol.UserColumn.ColumnName + " asc"
                Me.daProtocol.SelectCommand.CommandText += sWhere + sOrderBy

            ElseIf TypSel = eSelProtocoll.IDObject Then
                sWhere = sqlTxt.where + sqlTxt.getColWhere(dsProtocoll.Protocol.IDGuidObjectColumn.ColumnName)
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Me.daProtocol.SelectCommand.CommandText += sWhere
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.IDGuidObjectColumn.ColumnName), IDGuidObject)

            ElseIf TypSel = eSelProtocoll.IDStay Then
                sWhere = sqlTxt.where + sqlTxt.getColWhere(dsProtocoll.Protocol.IDStayColumn.ColumnName) + sqlTxt.and + sqlTxt.getColWhere(dsProtocoll.Protocol.IDParticipantColumn.ColumnName)
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Me.daProtocol.SelectCommand.CommandText += sWhere
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.IDStayColumn.ColumnName), IDStay)
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.IDParticipantColumn.ColumnName), IDParticipant)

            ElseIf TypSel = eSelProtocoll.sKey Then
                sWhere = sqlTxt.where + sqlTxt.getColWhere(dsProtocoll.Protocol.sKeyColumn.ColumnName)
                Me.daProtocol.SelectCommand.CommandText += sWhere
                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.sKeyColumn.ColumnName), sKey)
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)


            ElseIf TypSel = eSelProtocoll.SearchPatient Or TypSel = eSelProtocoll.SearchUser Or
                    TypSel = eSelProtocoll.RunQuery Or TypSel = eSelProtocoll.RunReport Then
                sWhere = sqlTxt.where + sqlTxt.getColWhere(dsProtocoll.Protocol.TypeColumn.ColumnName)

                If Not ENV.adminSecure Then
                    sWhere += " and [User]  ='" + UserName.Trim() + "' "
                End If
                sWhere = AddUserAppFilter(sWhere, FilterProductsEntries, FilterUserApps)

                Me.daProtocol.SelectCommand.Parameters.AddWithValue(sqlTxt.getColPar(dsProtocoll.Protocol.TypeColumn.ColumnName), TypSel.ToString())
            Else
                Throw New Exception("sqlProtocoll.getProtocoll: TypSel '" + TypSel.ToString() + "' is wrong!")
            End If

            Me.daProtocol.Fill(dsProtocoll)
            SqlCommandReturn = Me.daProtocol.SelectCommand.CommandText
            Return True
            '
        Catch ex As Exception
            Throw New Exception("getProtocol: " + ex.ToString())
        End Try
    End Function


    Private Function AddUserAppFilter(sWhere As String, FilterProductsEntries As String, FilterUserApps As Boolean) As String

        If FilterUserApps And Not String.IsNullOrWhiteSpace(FilterProductsEntries) Then
            Return sWhere + IIf(String.IsNullOrWhiteSpace(sWhere), " WHERE ", " AND ") + FilterProductsEntries
        Else
            Return sWhere
        End If


    End Function

    Public Function getVarsTxt(ByRef txt As String) As System.Collections.Generic.List(Of String)
        Try
            Dim lstTxt As New System.Collections.Generic.List(Of String)
            Dim bEndSearch As Boolean = False
            Dim iCounter As Integer = 0
            Dim iLastPosStart As Integer = 0
            While Not bEndSearch
                Dim iPosKA As Integer = txt.Trim().IndexOf("@", iLastPosStart)
                If iPosKA <> -1 Then
                    iLastPosStart = iPosKA + 1
                    Dim iPosKA2 As Integer = txt.Trim().IndexOf("@", iPosKA + 1)
                    iCounter += 1
                    If iPosKA2 <> -1 Then
                        'iLastPosStart = iPosKA2 + 1
                        Dim sVar As String = txt.Trim().Substring(iPosKA + 1, iPosKA2 - iPosKA - 2)
                        lstTxt.Add(sVar)
                    Else
                        Dim sVar As String = txt.Trim().Substring(iPosKA + 1, txt.Length - iPosKA - 1)
                        lstTxt.Add(sVar)
                    End If
                Else
                    If iCounter = 0 Then
                        lstTxt.Add(txt.Trim())
                    End If
                    bEndSearch = True
                End If
            End While

            Return lstTxt

        Catch ex As Exception
            Throw New Exception("getVarsTxt: " + ex.ToString())
        End Try
    End Function

    Public Function sys_deleteWholeProtocolFromDataService() As Boolean
        Try
            Dim ds As New dsProtocol()
            Dim cmd As New SqlClient.SqlCommand()
            cmd.CommandText = sqlTxt.delete + qs2.core.dbBase.dbSchema + ds.Protocol.TableName + sqlTxt.where + ds.Protocol.TypeColumn.ColumnName + sqlTxt.like + " 'DataService%'"
            cmd.Connection = qs2.core.dbBase.dbConn
            cmd.ExecuteNonQuery()

            Return True

        Catch ex As Exception
            Throw New Exception("sqlObjects.sys_deleteWholeProtocolFromDataService: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function newProtocol(ByRef dsProtocoll1 As dsProtocol) As dsProtocol.ProtocolRow
        Dim rNew As dsProtocol.ProtocolRow = dsProtocoll1.Protocol.NewRow()
        rNew.IDGuid = System.Guid.NewGuid
        rNew.Protocol = ""
        rNew.Type = ""
        rNew.SetIDGuidObjectNull()
        rNew.SetIDStayNull()
        rNew.SetIDParticipantNull()
        rNew.SetIDStayApplicationNull()
        rNew.SetsKeyNull()
        rNew.IDApplication = ""
        rNew.Info = ""
        If qs2.core.vb.actUsr.rUsr Is Nothing Then
            rNew.User = "Not logged in"
        Else
            rNew.User = qs2.core.vb.actUsr.rUsr.UserName
        End If

        Dim dNow As Date = Now
        rNew.Created = dNow
        rNew.Classification = ""
        rNew.Sql = ""
        rNew.InfoFile = ""
        rNew.Db = ""
        rNew.CreatedDay = dNow.Date
        rNew.progress = ""
        rNew.Patient = ""
        rNew.MedRecNr = ""

        dsProtocoll1.Protocol.Rows.Add(rNew)
        Return rNew
    End Function

End Class
