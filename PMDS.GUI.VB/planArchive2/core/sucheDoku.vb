Imports System.Data.OleDb



Public Class sucheDoku

    Private gen As New General()
    Private db As New db()




    Public Function searchDocu(ByVal ds As dsDokuSearch, ByVal Bezeichnung As String,
                                        ByVal Ordner As ArrayList, ByVal IDSchlagwörter As ArrayList,
                                        ByVal GültigVon As DateTime, ByVal GültigBis As DateTime,
                                        ByVal Wichtigkeit As String, ByRef tArchivObjects As dbArchiv.archObjectDataTable,
                                         ByVal AbgelegtVon As DateTime, ByVal AbgelegtBis As DateTime, ByVal benutzer As String,
                                        ByVal Papierkorb As Boolean,
                                        ByVal imGesamtsystemSuchen As Boolean) As Boolean
        Try
            Dim UserLoggedIn As String = Me.gen.getLoggedInUser()

            Dim cmd As New OleDbCommand
            Dim da As New OleDbDataAdapter
            Dim Sql As String = ""
            Dim SQL_where As String = ""
            Dim compDokuSql As New compDoku
            Sql = compDokuSql.daSearchDokus.SelectCommand.CommandText

            If Papierkorb Then
                SQL_where += " where archOrdner.IDSystemordner = 1  "
            End If
            If Not Papierkorb Then
                SQL_where += " where archOrdner.IDSystemordner <> 1 and archOrdner.IDSystemordner <> 2 "
            End If

            If Not gen.IsNull(Bezeichnung) Then
                Dim sql_sub As String = " archDoku.Bezeichnung LIKE '%" + Bezeichnung + "%' "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(Wichtigkeit) Then
                Dim sql_sub As String = " archDoku.Wichtigkeit = '" + Wichtigkeit + "' "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(GültigVon) Then
                Dim sql_sub As String = " archDoku.GültigVon >= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(GültigBis) Then
                Dim sql_sub As String = " archDoku.GültigBis <= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(AbgelegtVon) Then
                Dim sql_sub As String = " archDoku.AbgelegtAm >= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(AbgelegtBis) Then
                Dim sql_sub As String = " archDoku.AbgelegtAm <= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(IDSchlagwörter) Then
                If IDSchlagwörter.Count > 0 Then
                    Dim sql_id As String = ""
                    For Each id As String In IDSchlagwörter
                        Dim id_str As String = " archDokuSchlag.Schlagwort = '" + id.ToString + "' "
                        sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
                    Next
                    Dim sql_sub As String = " ( SELECT Count(*) FROM  archDokuSchlag " +
                                            " where archDokuSchlag.IDDoku =  archDoku.ID and ( " + sql_id + ")) > 0 "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                End If
            End If
            If tArchivObjects.Rows.Count > 0 Then
                Dim sql_sub As String = " archDoku.ID IN (Select IDDoku from archObject "
                Dim sql_ID As String = " "
                For Each ob As dbArchiv.archObjectRow In tArchivObjects
                    sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                    Dim str As String = ""
                    Dim id As New System.Guid(ob.IDObject.ToString)
                    sql_ID += " archObject.IDObject = '" + id.ToString + "' "
                Next
                sql_sub += sql_ID + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            Else
                If imGesamtsystemSuchen Then
                    If Not gen.IsNull(Trim(benutzer)) Then
                        Dim sql_sub As String = " archDoku.AbgelegtVon = '" + benutzer + "' "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                    End If
                Else
                    Dim sql_sub As String = " archDoku.AbgelegtVon = '" + UserLoggedIn.Trim() + "' "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                End If
            End If

            If Ordner.Count > 0 Then
                Dim sql_sub As String = "  archDoku.IDOrdner IN (Select ID from archOrdner "
                Dim sql_ID As String = " "
                For Each IDOrdner As Object In Ordner
                    sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                    sql_ID += " archOrdner.ID = '" + IDOrdner.ToString + "' "
                Next
                sql_sub += sql_ID + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            Sql += SQL_where

            cmd = New OleDbCommand(Sql, Me.db.getConnDB())
            cmd.CommandTimeout = 0
            If Not gen.IsNull(GültigVon) Then
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 8, "GültigVon")).Value = GültigVon
            End If
            If Not gen.IsNull(GültigBis) Then
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 8, "GültigBis")).Value = GültigBis
            End If
            If Not gen.IsNull(AbgelegtVon) Then
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("AbgelegtAm", System.Data.OleDb.OleDbType.Date, 8, "AbgelegtAm")).Value = AbgelegtVon
            End If
            If Not gen.IsNull(AbgelegtBis) Then
                cmd.Parameters.Add(New System.Data.OleDb.OleDbParameter("AbgelegtAm", System.Data.OleDb.OleDbType.Date, 8, "AbgelegtAm")).Value = AbgelegtBis
            End If
            da.SelectCommand = cmd
            da.Fill(ds.archDoku)
            Return True

        Catch ex As OleDbException
            Throw New Exception("sucheDoku.searchDocu: " + ex.ToString())
        Finally
        End Try
    End Function

End Class
