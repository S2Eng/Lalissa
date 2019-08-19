Imports System.Data.OleDb


Public Class compDokumentSuchen
    Inherits System.ComponentModel.Component

    Private gen As New GeneralArchiv
    Private genMain As New GeneralArchiv
    Private db As New db
    Public data As New dsPlanArchive




#Region " Vom Component Designer generierter Code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Für Support von Windows.Forms-Klassenkompositions-Designer
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Komponenten-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Komponenten-Designer erforderlich
    'Sie kann mit dem Komponenten-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region


    Public Enum etyp
        dokumente = 0
    End Enum

    Public Sub qryDokumenteSuchen(ByVal Bezeichnung As String, _
                                        ByVal Ordner As ArrayList, ByVal IDSchlagwörter As ArrayList, _
                                        ByVal GültigVon As DateTime, ByVal GültigBis As DateTime, _
                                        ByVal Wichtigkeit As String, ByVal objects As ArrayList, _
                                        ByVal TypObjects As ArrayList, _
                                        ByVal typSuche As etyp, _
                                        ByVal AbgelegtVon As DateTime, ByVal AbgelegtBis As DateTime, ByVal benutzer As String, _
                                        ByVal Papierkorb As Boolean, ByVal AnhangPlanungssystem As Boolean, ByVal nurPapierkorb As Boolean, _
                                        ByVal imGesamtsystemSuchen As Boolean)
        Try
            Dim DataTable As New DataTable
            Dim Command As New OleDbCommand
            Dim Parameter As OleDbParameter
            Dim DataAdapter As New OleDbDataAdapter

            Dim Sql As String = ""
            Dim SQL_where As String = ""

            If typSuche = etyp.dokumente Then
                Sql = "SELECT  dbo.tblDokumenteintrag.Bezeichnung, dbo.tblDokumente.Archivordner, dbo.tblDokumente.DateinameArchiv, dbo.tblDokumente.Winzip,  dbo.tblDokumente.DateinameOrig, dbo.tblDokumente.VerzeichnisOrig, dbo.tblDokumente.DokumentGröße, dbo.tblDokumente.DokumentErstellt, " + _
                            " dbo.tblObjekt.ID_guid, (dbo.Patient.Vorname  + ' ' +  dbo.Patient.Nachname) as Patient," + _
                            " dbo.tblDokumente.DokumentGeändert, dbo.tblDokumente.ErstelltAm, dbo.tblDokumente.ErstelltVon,   " + _
                            " CAST(dbo.tblDokumente.IDDokumenteintrag AS Varchar(50)) AS IDDokumenteintrag, CAST(dbo.tblDokumente.ID AS Varchar(50)) AS IDDokument, dbo.tblDokumenteintrag.Notiz, dbo.tblDokumenteintrag.GültigVon,  " + _
                            " dbo.tblDokumenteintrag.GültigBis, dbo.tblDokumenteintrag.Wichtigkeit, CAST(dbo.tblDokumenteintrag.IDOrdner AS Varchar(50)) AS IDOrdner, " + _
                            " dbo.tblOrdner.Bezeichnung AS BezeichnungOrdner, dbo.tblOrdner.Extern , dbo.tblDokumente.DateinameTyp " + _
                            " FROM dbo.Patient RIGHT OUTER JOIN " + _
                            " dbo.tblObjekt ON dbo.Patient.ID = dbo.tblObjekt.ID_guid RIGHT OUTER JOIN " + _
                            " dbo.tblDokumente INNER JOIN " + _
                            " dbo.tblDokumenteintrag ON dbo.tblDokumente.IDDokumenteintrag = dbo.tblDokumenteintrag.ID INNER JOIN " + _
                            " dbo.tblOrdner ON dbo.tblDokumenteintrag.IDOrdner = dbo.tblOrdner.ID ON dbo.tblObjekt.IDDokumenteintrag = dbo.tblDokumenteintrag.ID "

            End If

            If nurPapierkorb Then
                Dim sql_subIDSystemordner As String = " orSys.IDSystemordner = 1 "
                SQL_where += " where dbo.tblDokumenteintrag.IDOrdner IN ( SELECT distinct orSys.ID FROM  dbo.tblOrdner orSys where dbo.tblDokumenteintrag.IDOrdner = orSys.ID and ( " + sql_subIDSystemordner + " ))  "
            Else
                Dim sql_subIDSystemordner As String = " orSys.IDSystemordner = -1 "
                If Papierkorb Then sql_subIDSystemordner += " or orSys.IDSystemordner = 1 "
                If AnhangPlanungssystem Then sql_subIDSystemordner += " or orSys.IDSystemordner = 2 "
                SQL_where += " where dbo.tblDokumenteintrag.IDOrdner IN ( SELECT distinct orSys.ID FROM  dbo.tblOrdner orSys where dbo.tblDokumenteintrag.IDOrdner = orSys.ID and ( " + sql_subIDSystemordner + " ))  "

            End If

            If Not gen.IsNull(Bezeichnung) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.Bezeichnung LIKE '%" + Bezeichnung + "%' "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(Wichtigkeit) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.Wichtigkeit = '" + Wichtigkeit + "' "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(GültigVon) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.GültigVon >= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(GültigBis) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.GültigBis <= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(AbgelegtVon) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltAm >= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(AbgelegtBis) Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltAm <= ? "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            If Not gen.IsNull(IDSchlagwörter) Then
                If IDSchlagwörter.Count > 0 Then
                    Dim sql_id As String = ""
                    For Each id As System.Guid In IDSchlagwörter
                        Dim id_str As String = " ds.IDSchlagwort = '" + id.ToString + "' "
                        sql_id += IIf(gen.IsNull(Trim(sql_id)), id_str, " or " + id_str)
                    Next
                    Dim sql_sub As String = " ( SELECT Count(*) FROM  dbo.tblDokumenteneintragSchlagwörter ds " + _
                                            " where ds.IDDokumenteneintrag = dbo.tblDokumente.IDDokumenteintrag and ( " + sql_id + ")) > 0 "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                End If
            End If
            If objects.Count > 0 Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.ID IN (Select IDDokumenteintrag from tblObjekt "
                Dim sql_ID As String = " "
                For Each ob As clObject In objects
                    sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                    If ob.id.GetType.ToString = "System.Int32" Then
                        sql_ID += " ID_int = " + ob.id.ToString + " "
                    ElseIf ob.id.GetType.ToString = "System.String" Then
                        Try
                            Dim str As String = ""
                            Dim id As New System.Guid(ob.id.ToString)
                            sql_ID += " ID_guid = '" + id.ToString + "' "
                        Catch ex As Exception
                            sql_ID += " ID_str = '" + ob.id + "' "
                        End Try
                    End If
                Next
                sql_sub += sql_ID + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            Else
                If imGesamtsystemSuchen Then
                    If Not gen.IsNull(Trim(benutzer)) Then
                        Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltVon = '" + benutzer + "' "
                        SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                    End If
                Else
                    Dim sql_sub As String = " dbo.tblDokumenteintrag.ErstelltVon = '" + Me.genMain.actUser + "' "
                    SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
                End If
            End If

            If Ordner.Count > 0 Then
                Dim sql_sub As String = " dbo.tblDokumenteintrag.IDOrdner IN (Select ID from tblOrdner "
                Dim sql_ID As String = " "
                For Each IDOrdner As Object In Ordner
                    Dim typ As New compTypObjekt.eTyp
                    sql_ID += IIf(gen.IsNull(Trim(sql_ID)), " where ", " or ")
                    sql_ID += " ID = '" + IDOrdner.ToString + "' "
                Next
                sql_sub += sql_ID + ") "
                SQL_where += IIf(gen.IsNull(Trim(SQL_where)), " where " + sql_sub, " and " + sql_sub)
            End If
            Sql += SQL_where

            Command = New OleDbCommand(Sql, db.getConnDB)
            Command.CommandTimeout = 0
            If Not gen.IsNull(GültigVon) Then
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 8, "GültigVon")).Value = GültigVon
            End If
            If Not gen.IsNull(GültigBis) Then
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 8, "GültigBis")).Value = GültigBis
            End If
            If Not gen.IsNull(AbgelegtVon) Then
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = AbgelegtVon
            End If
            If Not gen.IsNull(AbgelegtBis) Then
                Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm")).Value = AbgelegtBis
            End If
            DataAdapter.SelectCommand = Command

            DataAdapter.Fill(Me.data.tblDokumenteSuchen)


        Catch ex As OleDbException
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try

    End Sub




End Class
