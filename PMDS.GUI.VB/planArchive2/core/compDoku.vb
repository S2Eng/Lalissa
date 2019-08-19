


Public Class compDoku

    Public ReadOnly sqldaDoku As String = ""
    Public ReadOnly sqldaObject As String = ""
    Public ReadOnly sqldaOrdner As String = ""
    Public ReadOnly sqldaDokuSchlagw As String = ""


    Public Enum eTypSelDoku
        id = 0
        idOrdner = 1
        LikeBezeichnung = 2
        all = 100
    End Enum
    Public Enum eTypSelObj
        id = 0
        idDoku = 1
        idObject = 2
        bezObj = 3
        idObjectIDSelList = 4
    End Enum
    Public Enum eTypSelOrd
        id = 0
        idMain = 1
        checkSys = 2
        getIDSys = 3
        ordnerName = 4
        all = 100
    End Enum
    Public Enum eTypSelSchlagw
        id = 0
        all = 100
    End Enum
    Public Enum eTypSelDokuSchlagw
        id = 0
        allidDoku = 1
        schlagwort = 3
    End Enum

    Public database As New db()
    Public gen As New General()








    Public Function getDokuRow(ByVal id As System.Guid, ByVal db As dbArchiv) As dbArchiv.archDokuRow
        Try
            Me.getDoku(id, eTypSelDoku.id, db, "")
            If db.archDoku.Rows.Count = 0 Then
                Return Nothing
            ElseIf db.archDoku.Rows.Count = 1 Then
                Return db.archDoku.Rows(0)
            ElseIf db.archDoku.Rows.Count > 1 Then
                Throw New Exception("getDokuRow.id: More than one Dokument to idDoku '" + id.ToString() + "' found!")
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("compDoku.getDokuRow: " + ex.ToString())
        End Try
    End Function
    Public Function getDoku(ByVal id As System.Guid, ByVal typSel As eTypSelDoku, ByVal db As dbArchiv, ByRef Bezeichnung As String) As Boolean
        Try
            Me.daDoku.SelectCommand.CommandText = Me.sqldaDoku
        Me.database.setDBConnection_dataAdapter(Me.daDoku)
        Me.daDoku.SelectCommand.Parameters.Clear()

        If typSel = eTypSelDoku.id Then
            Dim sWhere As String = " where ID = ? "
            Me.daDoku.SelectCommand.CommandText += sWhere
            Me.daDoku.SelectCommand.Parameters.AddWithValue("ID", id)

        ElseIf typSel = eTypSelDoku.idOrdner Then
            Dim sWhere As String = " where IDOrdner = ? "
            Me.daDoku.SelectCommand.CommandText += sWhere
            Me.daDoku.SelectCommand.Parameters.AddWithValue("IDOrdner", id)

        ElseIf typSel = eTypSelDoku.LikeBezeichnung Then
            Dim sWhere As String = " where Bezeichnung like '%" + Bezeichnung.Trim() + "%' "
            Me.daDoku.SelectCommand.CommandText += sWhere

        Else
            Throw New Exception("getDoku: typSel '" + typSel.ToString() + "' not allowed!")
        End If

        Me.daDoku.Fill(db.archDoku)
        Return True


        Catch ex As Exception
            Throw New Exception("compDoku.getDoku: " + ex.ToString())
        End Try
    End Function
    Public Function deleteDoku(ByVal idDoku As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  archDoku  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idDoku
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.deleteDoku: " + ex.ToString())
        End Try
    End Function

    Public Function getObjectRow(ByVal id As System.Guid) As dbArchiv.archObjectRow
        Try
            Dim db As New dbArchiv()
        Me.getObject(id, eTypSelObj.idDoku, db)
            If db.archObject.Rows.Count = 0 Then
                Return Nothing
            ElseIf db.archObject.Rows.Count = 1 Then
                Return db.archObject.Rows(0)
            ElseIf db.archObject.Rows.Count > 1 Then
                Throw New Exception("getObjectRow.id: more than one  Object to id '" + id.ToString() + "' found!")
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("compDoku.getObjectRow: " + ex.ToString())
        End Try
    End Function
    Public Function getObject(ByVal id As System.Guid, ByVal typSel As eTypSelObj, ByVal db As dbArchiv,
                              Optional ByVal bez As String = "", Optional ByVal IDGruppe As String = "",
                              Optional ByVal IDSelList As System.Guid = Nothing) As Boolean
        Try
            Me.daDocuObject.SelectCommand.CommandText = Me.sqldaObject
            Me.database.setDBConnection_dataAdapter(Me.daDocuObject)
            Me.daDocuObject.SelectCommand.Parameters.Clear()

            If typSel = eTypSelObj.idDoku Then
                Dim sWhere As String = " where IDDoku = ? "
                Me.daDocuObject.SelectCommand.CommandText += sWhere
                Me.daDocuObject.SelectCommand.Parameters.AddWithValue("IDDoku", id)
            ElseIf typSel = eTypSelObj.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daDocuObject.SelectCommand.CommandText += sWhere
                Me.daDocuObject.SelectCommand.Parameters.AddWithValue("ID", id)
            ElseIf typSel = eTypSelObj.idObject Then
                Dim sWhere As String = " where IDObject = ? "
                Me.daDocuObject.SelectCommand.CommandText += sWhere
                Me.daDocuObject.SelectCommand.Parameters.AddWithValue("IDObject", id)
            ElseIf typSel = eTypSelObj.idObjectIDSelList Then
                Dim sWhere As String = " where IDObject = ? and IDSelList = ? "
                Me.daDocuObject.SelectCommand.CommandText += sWhere
                Me.daDocuObject.SelectCommand.Parameters.AddWithValue("IDObject", id)
                Me.daDocuObject.SelectCommand.Parameters.AddWithValue("IDSelList", IDSelList)
            ElseIf typSel = eTypSelObj.bezObj Then
                Dim sWhere As String = " where ObjectBezeichnung like '%" + bez.Trim() + "%' "
                Me.daDocuObject.SelectCommand.CommandText += sWhere

            Else
                Throw New Exception("getObject: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daDocuObject.Fill(db.archObject)
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.getObject: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowDoku(ByVal dbArchiv1 As dbArchiv) As dbArchiv.archDokuRow
        Try
            Dim rNew As dbArchiv.archDokuRow = dbArchiv1.archDoku.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.SetIDOrdnerNull()
            rNew.Bezeichnung = ""
            rNew.Notiz = ""
            rNew.SetGültigVonNull()
            rNew.SetGültigBisNull()
            rNew.Wichtigkeit = ""
            rNew.Größe = 0
            rNew.AbgelegtVon = ""
            rNew.SetAbgelegtAmNull()
            rNew.Winzip = False
            rNew.Archivordner = ""
            rNew.DateinameArchiv = ""
            rNew.DateinameTyp = ""
            rNew.RechNr = ""
            rNew.SetdbNull()
            rNew.SetIDStatusNull()
            rNew.SetIDTypNull()
            rNew.SetIDActivityNull()
            rNew.SetdokuNull()
            rNew.dokuOrig = ""
            rNew.SetdokuNull()
            rNew.SetbinInternNull()
            rNew.intReleased = True

            dbArchiv1.archDoku.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compDoku.getNewRowDoku: " + ex.ToString())
        End Try
    End Function

    Public Function deleteDocuments(ByVal sWhere As String) As Boolean
        Try
            If sWhere.Trim() = "" Then
                Throw New Exception("deleteDocuments: sWhere='' not allowed!")
            End If

            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "delete [archDoku] where " + sWhere
            Command.Connection = Me.database.getConnDB()
            Command.CommandTimeout = 0
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.deleteDocuments: " + ex.ToString())
        End Try
    End Function

    Public Function getNewRowArchObject(tArchObjects As dbArchiv.archObjectDataTable) As dbArchiv.archObjectRow
        Try
            Dim rNew As dbArchiv.archObjectRow = tArchObjects.NewRow()
            rNew.ID = System.Guid.NewGuid()
            rNew.IDObject = System.Guid.NewGuid()
            rNew.IDDoku = System.Guid.NewGuid()
            rNew.SetIDSelListNull()
            tArchObjects.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compDoku.getNewRowArchObject: " + ex.ToString())
        End Try
    End Function
    Public Function getOrdnerRow(ByVal id As System.Guid, ByVal typSel As eTypSelOrd, ByVal db As dbArchiv,
                                  Optional ByVal IDSystemordner As Integer = 0) As dbArchiv.archOrdnerRow
        Try
            Me.getOrdner(id, typSel, db, IDSystemordner)
            If db.archOrdner.Rows.Count = 0 Then
                Return Nothing
            ElseIf db.archOrdner.Rows.Count = 1 Then
                Return db.archOrdner.Rows(0)
            ElseIf db.archOrdner.Rows.Count > 1 Then
                Throw New Exception("getOrdnerRow.id: more than one folder to id '" + id.ToString() + "' found!")
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("compDoku.getOrdnerRow: " + ex.ToString())
        End Try
    End Function
    Public Function checkSystemordner(ByVal IDSystemordner As Integer) As Boolean
        Try
            Dim db As dbArchiv
            Me.getOrdner(System.Guid.NewGuid(), eTypSelOrd.checkSys, db, IDSystemordner)
            If db.archOrdner.Rows.Count = 0 Then
                Return False
            ElseIf db.archOrdner.Rows.Count = 1 Then
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("compDoku.checkSystemordner: " + ex.ToString())
        End Try
    End Function
    Public Function getOrdner(ByVal id As System.Guid, ByVal typSel As eTypSelOrd, ByVal db As dbArchiv,
                              Optional ByVal IDSystemordner As Integer = 0, Optional ByVal ordnername As String = "") As Boolean
        Try
            Me.daOrdner.SelectCommand.CommandText = Me.sqldaOrdner
            Me.database.setDBConnection_dataAdapter(Me.daOrdner)
            Me.daOrdner.SelectCommand.Parameters.Clear()

            If typSel = eTypSelOrd.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daOrdner.SelectCommand.CommandText += sWhere
                Me.daOrdner.SelectCommand.Parameters.AddWithValue("id", id)

            ElseIf typSel = eTypSelOrd.idMain Then
                Dim sWhere As String = ""
                If id = System.Guid.Empty Then
                    sWhere = " where IDOrdnerMain is null "
                Else
                    sWhere = " where IDOrdnerMain = ? "
                    Me.daOrdner.SelectCommand.Parameters.AddWithValue("IDOrdnerMain", id)
                End If
                Me.daOrdner.SelectCommand.CommandText += sWhere

            ElseIf typSel = eTypSelOrd.checkSys Then
                Dim sWhere As String = " where IDSystemordner = ? "
                Me.daOrdner.SelectCommand.CommandText += sWhere
                Me.daOrdner.SelectCommand.Parameters.AddWithValue("IDSystemordner", IDSystemordner)

            ElseIf typSel = eTypSelOrd.all Then
                Dim sWhere As String = " "
                Me.daOrdner.SelectCommand.CommandText += sWhere + " order by Bezeichnung asc"

            ElseIf typSel = eTypSelOrd.getIDSys Then
                Dim sWhere As String = " where IDSystemordner = ? "
                Me.daOrdner.SelectCommand.CommandText += sWhere
                Me.daOrdner.SelectCommand.Parameters.AddWithValue("IDSystemordner", IDSystemordner)

            ElseIf typSel = eTypSelOrd.ordnerName Then
                Dim sWhere As String = " where Bezeichnung = ? "
                Me.daOrdner.SelectCommand.CommandText += sWhere
                Me.daOrdner.SelectCommand.Parameters.AddWithValue("Bezeichnung", ordnername)

            Else
                Throw New Exception("getOrdner: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daOrdner.Fill(db.archOrdner)
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.getOrdner: " + ex.ToString())
        End Try
    End Function

    Public Function UpdateDoku(ByVal IDDoku As System.Guid, ByVal Bezeichnung As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE archDoku SET  Bezeichnung = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 100, "Bezeichnung")).Value = Bezeichnung.Trim()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDoku
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compDoku.UpdateDoku: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateOrdDoku(ByVal IDDoku As System.Guid, ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE archDoku SET  IDOrdner = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")).Value = IDOrdner
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDoku
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compDoku.UpdateOrdDoku: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateDokuIntReleased(ByVal IDDoku As System.Guid, ByVal intReleased As Boolean) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE archDoku SET  intReleased = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("intReleased", System.Data.OleDb.OleDbType.Boolean, 1, "intReleased")).Value = intReleased
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDoku
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compDoku.UpdateDokuIntReleased: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateDokuIDTyp(ByVal IDDoku As System.Guid, ByVal IDTyp As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE archDoku SET  IDTyp = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.VarChar, 120, "IDTyp")).Value = IDTyp
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDoku
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compDoku.UpdateDokuIDTyp: " + ex.ToString())
        End Try
    End Function
    Public Function UpdateDokuIDStatus(ByVal IDDoku As System.Guid, ByVal IDStatus As String) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0
            Command.CommandText = "UPDATE archDoku SET  IDStatus = ?  WHERE ID = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 120, "IDStatus")).Value = IDStatus
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDoku
            Command.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception("compDoku.UpdateDokuIDStatus: " + ex.ToString())
        End Try
    End Function
    Public Function deleteOrdner(ByVal idOrdner As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  archOrdner  WHERE ID = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = idOrdner
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.deleteOrdner: " + ex.ToString())
        End Try
    End Function
    Public Function getNewRowOrdner(ByVal dbArchiv1 As dbArchiv) As dbArchiv.archOrdnerRow
        Try
            Dim rNew As dbArchiv.archOrdnerRow = dbArchiv1.archOrdner.NewRow()
            rNew.ID = System.Guid.NewGuid
            rNew.Bezeichnung = ""
            rNew.Extern = False
            rNew.SetIDOrdnerMainNull()
            rNew.ErstelltAm = Now
            rNew.ErstelltVon = ""
            rNew.SetIconNull()
            rNew.IDSystemordner = -1
            dbArchiv1.archOrdner.Rows.Add(rNew)
            Return rNew

        Catch ex As Exception
            Throw New Exception("compDoku.getNewRowOrdner: " + ex.ToString())
        End Try
    End Function

    Public Function clearSystemordner(ByVal IDSystemordner As Integer) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand
            Command.CommandText = "UPDATE archOrdner SET  IDSystemordner = -1  WHERE IDSystemordner = ? "
            Command.Connection = Me.database.getConnDB()
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.Integer, 4, "IDSystemordner")).Value = IDSystemordner
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.clearSystemordner: " + ex.ToString())
        End Try
    End Function

    Public Sub getAuswahlisten2(ByVal ds As dsAuswahllisten,
                               ByVal idGruppe As String,
                               ByVal typKey As General.eKeyCol)
        Try
            Dim gen As New General()
            ds.Clear()

            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            gen.loadSelList(Nothing, Nothing, idGruppe, tSelListEntriesReturn, typKey, MaxIDSelListEntryReturn)
            gen.loadDSSelListHelper(tSelListEntriesReturn, ds)

        Catch ex As Exception
            Throw New Exception("compDoku.getAuswahlisten2: " + ex.ToString())
        End Try
    End Sub
    Public Function deleteDokuAllSchlagw(ByVal idDoku As System.Guid) As Boolean
        Try
            Dim dt As New DataTable
            Dim cmd As New OleDb.OleDbCommand
            cmd.CommandText = "delete  archDokuSchlag  WHERE IDDoku = ? "
            cmd.Connection = Me.database.getConnDB()
            cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 16, "IDDoku")).Value = idDoku
            cmd.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.deleteDokuAllSchlagw: " + ex.ToString())
        End Try
    End Function


    Public Function getDokuSchlag(ByVal id As System.Guid, ByVal typSel As eTypSelDokuSchlagw, ByVal db As dbArchiv) As Boolean
        Try
            Me.daDokuSchlag.SelectCommand.CommandText = Me.sqldaDokuSchlagw
            Me.database.setDBConnection_dataAdapter(Me.daDokuSchlag)
            Me.daDokuSchlag.SelectCommand.Parameters.Clear()

            If typSel = eTypSelDokuSchlagw.id Then
                Dim sWhere As String = " where ID = ? "
                Me.daDokuSchlag.SelectCommand.CommandText += sWhere
                Me.daDokuSchlag.SelectCommand.Parameters.AddWithValue("id", id)

            ElseIf typSel = eTypSelDokuSchlagw.allidDoku Then
                Dim sWhere As String = " where IDDoku = ? "
                Me.daDokuSchlag.SelectCommand.CommandText += sWhere
                Me.daDokuSchlag.SelectCommand.Parameters.AddWithValue("IDDoku", id)

            ElseIf typSel = eTypSelDokuSchlagw.schlagwort Then
                Dim sWhere As String = " where Schlagwort = ? order by Schlagwort asc "
                Me.daDokuSchlag.SelectCommand.CommandText += sWhere
                Me.daDokuSchlag.SelectCommand.Parameters.AddWithValue("Schlagwort", id)

            Else
                Throw New Exception("getDokuSchlag: typSel '" + typSel.ToString() + "' not allowed!")
            End If

            Me.daDokuSchlag.Fill(db.archDokuSchlag)
            Return True

        Catch ex As Exception
            Throw New Exception("compDoku.getDokuSchlag: " + ex.ToString())
        End Try
    End Function

End Class

