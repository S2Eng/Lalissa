


Public Class compAuswahllisten

    Public database As New db
    Public gen As New General

    Public daSelAuswahllisteGruppe As String = ""
    Public daSelAuswahllisten As String = ""
    Public daSelAuswahlListObj As String = ""

    Public Shared IDRiskClassKeine As New System.Guid("00000000-0000-0000-1800-000000000009")


    Public Enum eTypSelGruppen
        all = 0
        IDGruppe = 1
    End Enum
    Public Enum eTypAuswahlList
        gruppe = 0
        IDNr = 1
        typ = 2
        gruppeUndNr = 3
        extern = 4
        bezeichnung = 5
        guid = 6
        FolderPlans = 7
        ID = 100
        All = 200
    End Enum
    Public Enum eTypAuswahlObj
        IDObject = 0
        IDAuswahlSub = 1
        IDSatz = 2
        IDObjectSubGruppeID = 3
        IDObjectIDProduct = 4
        ID = 10
    End Enum


    Public Enum eDbTypAuswObj
        SatzProvStufe = 1
        VermProvStufe = 2
        VermÜberKrit = 3
        SubAuswahllist = 4

        RiskClassesObject = 5
        RiskClassesInsuranceMasterData = 6
        RiskClassesInsurance = 7

        non = -100
    End Enum







    Public Function getGruppenRow(ByVal idGruppe As String) As dsAuswahllisten.AuswahllisteGruppeRow
        Dim ds As New dsAuswahllisten
        Me.loadGruppen(ds, eTypSelGruppen.IDGruppe, idGruppe)
        If ds.AuswahllisteGruppe.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.AuswahllisteGruppe.Rows.Count = 1 Then
            Return ds.AuswahllisteGruppe.Rows(0)
        ElseIf ds.AuswahllisteGruppe.Rows.Count > 1 Then
            Throw New Exception("getGruppenRow.idGruppe: more than one entry to idGruppe '" + idGruppe.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function loadGruppen(ByRef ds As dsAuswahllisten, ByVal typSel As eTypSelGruppen, _
                                Optional ByVal IDGruppe As String = "") As Boolean

        Me.daAuswahllisteGruppe.SelectCommand.CommandText = Me.daSelAuswahllisteGruppe
        database.setDBConnection_dataAdapter(Me.daAuswahllisteGruppe)
        Me.daAuswahllisteGruppe.SelectCommand.Parameters.Clear()

        If typSel = eTypSelGruppen.all Then
            Dim sWhere As String = "  "
            Me.daAuswahllisteGruppe.SelectCommand.CommandText += sWhere + " order by gruppe asc "
        ElseIf typSel = eTypSelGruppen.IDGruppe Then
            Dim sWhere As String = " where ID = ? "
            Me.daAuswahllisteGruppe.SelectCommand.CommandText += sWhere
            Me.daAuswahllisteGruppe.SelectCommand.Parameters.AddWithValue("ID", IDGruppe)

        Else
            Throw New Exception("loadGruppen: typ '" + typSel.ToString() + "' not allowed!")
        End If

        Me.daAuswahllisteGruppe.Fill(ds.AuswahllisteGruppe)
        Return True
    End Function
    Public Function addRowAuswahlGruppe(ByRef ds As dsAuswahllisten) As dsAuswahllisten.AuswahllisteGruppeRow
        Dim rNew As dsAuswahllisten.AuswahllisteGruppeRow = ds.AuswahllisteGruppe.NewRow()
        rNew.ID = "New Key ..."
        rNew.gruppe = ""
        rNew.sys = False
        rNew.Sublist = ""
        rNew.KeyCol = ""
        rNew.Sort = ""
        ds.AuswahllisteGruppe.Rows.InsertAt(rNew, 0)
        Return rNew
    End Function

    Public Function getAuswahllisteRow(ByVal idGruppe As String, ByVal typSel As eTypAuswahlList, _
                                        ByVal idNr As String, _
                                        Optional ByVal bezeichnung As String = "", _
                                        Optional ByVal guid As System.Guid = Nothing, _
                                        Optional ByVal doException As Boolean = True) As dsAuswahllisten.AuswahllistenRow

        Dim ds As New dsAuswahllisten
        Me.loadAuswahllisten(idGruppe, ds, typSel, "", idNr, bezeichnung, guid)
        If ds.Auswahllisten.Rows.Count = 0 Then
            Return Nothing
        ElseIf ds.Auswahllisten.Rows.Count = 1 Then
            Return ds.Auswahllisten.Rows(0)
        ElseIf ds.Auswahllisten.Rows.Count > 1 Then
            Throw New Exception("getAuswahllisteRow.id: More than one entry to idNr '" + idNr.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function getAuswahllistenRow(ByVal idGruppe As String, ByVal idNr As String, ByVal typSel As eTypAuswahlList, _
                                        ByVal throwExceptionIfNothingFound As Boolean) As dsAuswahllisten.AuswahllistenRow
        Dim ds As New dsAuswahllisten
        Me.loadAuswahllisten(idGruppe, ds, typSel, "", idNr)
        If ds.Auswahllisten.Rows.Count = 0 Then
            If throwExceptionIfNothingFound Then
                Throw New Exception("getAuswahllistenRow.idGruppe: Keinen Eintrag zu IDNr '" + idNr + "' und idGruppe '" + idGruppe.ToString() + "' gefunden!")
            End If
            Return Nothing
        ElseIf ds.Auswahllisten.Rows.Count = 1 Then
            Return ds.Auswahllisten.Rows(0)
        ElseIf ds.Auswahllisten.Rows.Count > 1 Then
            Throw New Exception("getAuswahllistenRow.idGruppe: More than one entry to IDNr '" + idNr + "' and idGruppe '" + idGruppe.ToString() + "' found!")
            Return Nothing
        End If
    End Function
    Public Function loadAuswahllisten(ByVal idGruppe As String, ByRef ds As dsAuswahllisten, ByVal typSel As eTypAuswahlList, _
                                      Optional ByVal typ As String = "", Optional ByVal idNr As String = "",
                                      Optional ByVal bezeichnung As String = "", _
                                      Optional ByVal guid As System.Guid = Nothing, _
                                      Optional ByVal Klassifizierung As String = "") As Boolean

        Me.daAuswahllisten.SelectCommand.CommandText = Me.daSelAuswahllisten
        database.setDBConnection_dataAdapter(Me.daAuswahllisten)
        Me.daAuswahllisten.SelectCommand.Parameters.Clear()

        If typSel = eTypAuswahlList.gruppe Then
            Dim sWhere As String = " where IDGruppe = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " order by Bezeichnung asc "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("IDGruppe", idGruppe)

        ElseIf typSel = eTypAuswahlList.guid Then
            Dim sWhere As String = " where IDGruppe = ?  and ID = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("ID", guid)

        ElseIf typSel = eTypAuswahlList.IDNr Then
            Dim sWhere As String = " where IDGruppe = ?  and IDNr = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("IDNr", idNr)

        ElseIf typSel = eTypAuswahlList.bezeichnung Then
            Dim sWhere As String = " where IDGruppe = ?  and Bezeichnung = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("Bezeichnung", bezeichnung)

        ElseIf typSel = eTypAuswahlList.gruppeUndNr Then
            Dim sWhere As String = " where IDGruppe = ? and typ = ? "
            If Klassifizierung.Trim() <> "" Then
                sWhere += " and Klassifizierung = '" + Klassifizierung.Trim() + "' "
            End If
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("typ", typ)

        ElseIf typSel = eTypAuswahlList.FolderPlans Then
            Dim sWhere As String = " where IDGruppe = ? and typ = ? "
            If idNr.Trim() <> "" Then
                sWhere += " and (Extern like '%" + idNr.Trim() + ";%' or Extern='') "
            End If
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("typ", typ)

        ElseIf typSel = eTypAuswahlList.extern Then
            Dim sWhere As String = " where IDGruppe = ? and Extern = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("idGruppe", idGruppe)
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("Extern", typ)

        ElseIf typSel = eTypAuswahlList.ID Then
            Dim sWhere As String = " where ID = ? "
            Me.daAuswahllisten.SelectCommand.CommandText += sWhere + " "
            Me.daAuswahllisten.SelectCommand.Parameters.AddWithValue("ID", guid)

        ElseIf typSel = eTypAuswahlList.All Then
            Dim sOrderBy As String = " order by IDGruppe asc,  Bezeichnung asc "
            Me.daAuswahllisten.SelectCommand.CommandText += sOrderBy + " "

        Else
            Throw New Exception("loadAuswahllisten: typ '" + typSel.ToString() + "' not allowed!")
        End If

        Me.daAuswahllisten.Fill(ds.Auswahllisten)
        Return True
    End Function
    Public Function addRowAuswahlliste(ByRef ds As dsAuswahllisten) As dsAuswahllisten.AuswahllistenRow
        Dim rNew As dsAuswahllisten.AuswahllistenRow = ds.Auswahllisten.NewRow()
        rNew.ID = System.Guid.NewGuid
        rNew.Bezeichnung = ""
        rNew.IDNr = ""
        rNew.typ = ""
        rNew.Klassifizierung = ""
        rNew.Extern = ""
        rNew.IDGruppe = ""
        rNew.ErstelltAm = Now

        Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
        rNew.ErstelltVon = UserLoggedIn.Trim()
        rNew.Kennung = ""
        rNew.SetSortNull()
        rNew.Beschreibung = ""
        ds.Auswahllisten.Rows.InsertAt(rNew, 0)
        Return rNew
    End Function

    Public Function deleteAllAuswahllistenFromGroup(ByVal IDGruppe As String) As Boolean
        Dim cmd As New System.Data.OleDb.OleDbCommand
        cmd.Parameters.Clear()
        cmd.CommandText = "DELETE FROM Auswahllisten WHERE IDGruppe = ? "
        cmd.Connection = Me.database.getConnDB()
        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.VarChar, 80, "IDGruppe")).Value = IDGruppe
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function DeleteRow(ByVal ID As System.Guid) As Boolean
        Dim cmd As New System.Data.OleDb.OleDbCommand
        cmd.Parameters.Clear()
        cmd.CommandText = "DELETE FROM Auswahllisten WHERE ID = ? "
        cmd.Connection = Me.database.getConnDB()
        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function DeleteRowObj(ByVal IDSatz As System.Guid, ByVal typ As compAuswahllisten.eDbTypAuswObj) As Boolean
        Dim cmd As New System.Data.OleDb.OleDbCommand
        cmd.Parameters.Clear()
        cmd.CommandText = "DELETE FROM AuswahllistenObj WHERE IDSatz = ? and Typ = ?"
        cmd.Connection = Me.database.getConnDB()
        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSatz", System.Data.OleDb.OleDbType.Guid, 16, "IDSatz")).Value = IDSatz
        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 100, "Typ")).Value = typ.ToString()
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Public Function DeleteRowObj(ByVal ID As System.Guid) As Boolean
        Dim cmd As New System.Data.OleDb.OleDbCommand
        cmd.Parameters.Clear()
        cmd.CommandText = "DELETE FROM AuswahllistenObj WHERE ID = ? "
        cmd.Connection = Me.database.getConnDB()
        cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = ID
        cmd.ExecuteNonQuery()
        Return True
    End Function


    Public Function loadAuswahlListObj(ByVal IDGuid As System.Guid,
                                        ByVal typDB As compAuswahllisten.eDbTypAuswObj,
                                        ByRef ds As dsAuswahllisten,
                                        ByVal typSel As eTypAuswahlObj,
                                        Optional ByVal IDGruppe As String = "",
                                        Optional ByVal IDProduct As System.Guid = Nothing,
                                        Optional iIsHistory As Integer = -1) As Boolean

        Me.daAuswahllistenObj.SelectCommand.CommandText = Me.daSelAuswahlListObj
        database.setDBConnection_dataAdapter(Me.daAuswahllistenObj)
        Me.daAuswahllistenObj.SelectCommand.Parameters.Clear()

        Dim sWhereIsHistory As String = ""
        If iIsHistory = 1 Then
            sWhereIsHistory += " and IsHistory=1  "
        ElseIf iIsHistory = 0 Then
            sWhereIsHistory += " and IsHistory=0 "
        End If

        If typSel = eTypAuswahlObj.IDObject Then
            Dim sWhere As String = " where IDObject = ? and Typ = ?  " + sWhereIsHistory
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere + " order by AuswahlTxt asc "
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDObject", IDGuid)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("typ", typDB.ToString())

        ElseIf typSel = eTypAuswahlObj.IDObjectIDProduct Then
            Dim sWhere As String = " where IDObject = ? and IDProduct = ? and Typ = ?  "
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere + " order by AuswahlTxt asc "
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDObject", IDGuid)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDProduct", IDProduct)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("typ", typDB.ToString())

        ElseIf typSel = eTypAuswahlObj.IDObjectSubGruppeID Then
            Dim sWhere As String = " where IDObject = ? and SubGruppeID = ? and Typ = ?  "
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere + " order by AuswahlTxt asc "
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDObject", IDGuid)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("SubGruppeID", IDGruppe)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("typ", typDB.ToString())

        ElseIf typSel = eTypAuswahlObj.IDAuswahlSub Then
            Dim sWhere As String = " where IDAuswahlSub = ? and Typ = ?  "
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere + " order by AuswahlTxt asc "
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDAuswahlSub", IDGuid)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("typ", typDB.ToString())

        ElseIf typSel = eTypAuswahlObj.IDSatz Then
            Dim sWhere As String = " where IDSatz = ? and Typ = ?  " + sWhereIsHistory
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere + " order by AuswahlTxt asc "
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("IDSatz", IDGuid)
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("typ", typDB.ToString())

        ElseIf typSel = eTypAuswahlObj.ID Then
            Dim sWhere As String = " where ID = ? "
            Me.daAuswahllistenObj.SelectCommand.CommandText += sWhere
            Me.daAuswahllistenObj.SelectCommand.Parameters.AddWithValue("ID", IDGuid)

        Else
            Throw New Exception("loadAuswahlListObj: typ '" + typSel.ToString() + "' not allowed!")
        End If

        Me.daAuswahllistenObj.Fill(ds.AuswahllistenObj)
        Return True
    End Function
    Public Function addRowAuswahllisteObj(ByRef ds As dsAuswahllisten) As dsAuswahllisten.AuswahllistenObjRow
        Dim rNew As dsAuswahllisten.AuswahllistenObjRow = ds.AuswahllistenObj.NewRow()
        rNew.ID = System.Guid.NewGuid
        rNew.SetIDAuswahlNull()
        rNew.AuswahlTxt = ""
        rNew.AuswahlGruppeID = ""

        rNew.SetIDProductNull()

        rNew.SetVonNull()
        rNew.SetBisNull()

        rNew.SetIDObjectNull()
        rNew.IDObjectTxt = ""
        rNew.SetIDAuswahlSubNull()
        rNew.SetIDSchemaNull()
        rNew.SetIDSatzNull()

        rNew.SubGruppeID = ""
        rNew.Typ = ""
        rNew.IDClassification = ""
        rNew.SetIDVersicherungNull()
        rNew.SetSortNull()
        rNew.Beschreibung = ""

        rNew.SetZahlweiseNull()
        rNew.Kalender = False
        rNew.ProvZahlNachschüssig = False
        rNew.ProvType = ""
        rNew.ProvVerzicht = 0

        rNew.ErstelltAm = Now
        Dim UserLoggedIn As String = Me.gen.getLoggedInUser()
        rNew.ErstelltVon = UserLoggedIn.Trim()

        rNew.IsActive = False
        rNew.IsHistory = False

        ds.AuswahllistenObj.Rows.InsertAt(rNew, 0)
        Return rNew
    End Function

    Public Function checkIfIDNrIsInt(ByRef ds As dsAuswahllisten) As Boolean
        Try
            Dim nextIDOwnInt As Integer = 0
            For Each rSelList As dsAuswahllisten.AuswahllistenRow In ds.Auswahllisten
                If rSelList.RowState <> DataRowState.Deleted Then
                    If rSelList.IDNr.Trim() <> "" Then
                        Try
                            Dim actNr As Integer = rSelList.IDNr
                        Catch ex As Exception
                            Return False
                        End Try
                    End If
                End If
            Next
            Return True

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
            Return 5000
        End Try
    End Function
    Public Function getNextIDNr(ByRef ds As dsAuswahllisten) As Integer
        Try
            Dim nextIDOwnInt As Integer = 0
            For Each rSelList As dsAuswahllisten.AuswahllistenRow In ds.Auswahllisten
                If rSelList.RowState <> DataRowState.Deleted Then
                    If rSelList.IDNr.Trim() <> "" Then
                        nextIDOwnInt = IIf(nextIDOwnInt < rSelList.IDNr, rSelList.IDNr, nextIDOwnInt)
                    End If
                End If
            Next
            Return (nextIDOwnInt + 1)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
            Return 5000
        End Try
    End Function


End Class
