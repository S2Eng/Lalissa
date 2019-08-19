

Public Class compDokumenteintrag
    Inherits System.ComponentModel.Component


    Private gen As New GeneralArchiv
    Private db As New db



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
    Friend WithEvents conArchiv As System.Data.OleDb.OleDbConnection
    Friend WithEvents daDokumenteintrag_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents daDokumente_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumente_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumente_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumente_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Dokumente_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Dokumenteintrag_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumenteintrag_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumenteintrag_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Dokumenteintrag_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumente_IDDokueintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumente_IDDokueintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Dokumenteintrag_anzahl As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumenteintrag_anzahl As System.Data.OleDb.OleDbDataAdapter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compDokumenteintrag))
        Me.conArchiv = New System.Data.OleDb.OleDbConnection()
        Me.daDokumenteintrag_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Dokumenteintrag_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Dokumenteintrag_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Dokumenteintrag_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Dokumenteintrag_ID = New System.Data.OleDb.OleDbCommand()
        Me.daDokumente_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Dokumente_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Dokumente_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Dokumente_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Dokumente_ID = New System.Data.OleDb.OleDbCommand()
        Me.daDokumente_IDDokueintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag = New System.Data.OleDb.OleDbCommand()
        Me.daDokumenteintrag_anzahl = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Dokumenteintrag_anzahl = New System.Data.OleDb.OleDbCommand()
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" & _
    "al Catalog=PMDSDev"
        '
        'daDokumenteintrag_ID
        '
        Me.daDokumenteintrag_ID.DeleteCommand = Me.OleDbDeleteCommand_Dokumenteintrag_ID
        Me.daDokumenteintrag_ID.InsertCommand = Me.OleDbInsertCommand_Dokumenteintrag_ID
        Me.daDokumenteintrag_ID.SelectCommand = Me.OleDbSelectCommand_Dokumenteintrag_ID
        Me.daDokumenteintrag_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumenteintrag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("NotizRTF", "NotizRTF"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        Me.daDokumenteintrag_ID.UpdateCommand = Me.OleDbUpdateCommand_Dokumenteintrag_ID
        '
        'OleDbDeleteCommand_Dokumenteintrag_ID
        '
        Me.OleDbDeleteCommand_Dokumenteintrag_ID.CommandText = "DELETE FROM [tblDokumenteintrag] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_Dokumenteintrag_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Dokumenteintrag_ID
        '
        Me.OleDbInsertCommand_Dokumenteintrag_ID.CommandText = "INSERT INTO [tblDokumenteintrag] ([ID], [IDOrdner], [Bezeichnung], [Notiz], [Noti" & _
    "zRTF], [GültigVon], [GültigBis], [Wichtigkeit], [ErstelltAm], [ErstelltVon]) VAL" & _
    "UES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Dokumenteintrag_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("NotizRTF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "NotizRTF"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon")})
        '
        'OleDbSelectCommand_Dokumenteintrag_ID
        '
        Me.OleDbSelectCommand_Dokumenteintrag_ID.CommandText = "SELECT        ID, IDOrdner, Bezeichnung, Notiz, NotizRTF, GültigVon, GültigBis, W" & _
    "ichtigkeit, ErstelltAm, ErstelltVon" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblDokumenteintrag" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE  " & _
    "      (ID = ?)"
        Me.OleDbSelectCommand_Dokumenteintrag_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Dokumenteintrag_ID
        '
        Me.OleDbUpdateCommand_Dokumenteintrag_ID.CommandText = resources.GetString("OleDbUpdateCommand_Dokumenteintrag_ID.CommandText")
        Me.OleDbUpdateCommand_Dokumenteintrag_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("NotizRTF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "NotizRTF"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daDokumente_ID
        '
        Me.daDokumente_ID.DeleteCommand = Me.OleDbDeleteCommand_Dokumente_ID
        Me.daDokumente_ID.InsertCommand = Me.OleDbInsertCommand_Dokumente_ID
        Me.daDokumente_ID.SelectCommand = Me.OleDbSelectCommand_Dokumente_ID
        Me.daDokumente_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("DateinameOrig", "DateinameOrig"), New System.Data.Common.DataColumnMapping("VerzeichnisOrig", "VerzeichnisOrig"), New System.Data.Common.DataColumnMapping("DokumentGröße", "DokumentGröße"), New System.Data.Common.DataColumnMapping("DokumentErstellt", "DokumentErstellt"), New System.Data.Common.DataColumnMapping("DokumentGeändert", "DokumentGeändert"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Winzip", "Winzip"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp")})})
        Me.daDokumente_ID.UpdateCommand = Me.OleDbUpdateCommand_Dokumente_ID
        '
        'OleDbDeleteCommand_Dokumente_ID
        '
        Me.OleDbDeleteCommand_Dokumente_ID.CommandText = "DELETE FROM tblDokumente WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Dokumente_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Dokumente_ID
        '
        Me.OleDbInsertCommand_Dokumente_ID.CommandText = resources.GetString("OleDbInsertCommand_Dokumente_ID.CommandText")
        Me.OleDbInsertCommand_Dokumente_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("DateinameOrig", System.Data.OleDb.OleDbType.VarChar, 300, "DateinameOrig"), New System.Data.OleDb.OleDbParameter("VerzeichnisOrig", System.Data.OleDb.OleDbType.VarChar, 500, "VerzeichnisOrig"), New System.Data.OleDb.OleDbParameter("DokumentGröße", System.Data.OleDb.OleDbType.[Double], 8, "DokumentGröße"), New System.Data.OleDb.OleDbParameter("DokumentErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DokumentErstellt"), New System.Data.OleDb.OleDbParameter("DokumentGeändert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DokumentGeändert"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 1, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 100, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 150, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 50, "DateinameTyp")})
        '
        'OleDbSelectCommand_Dokumente_ID
        '
        Me.OleDbSelectCommand_Dokumente_ID.CommandText = resources.GetString("OleDbSelectCommand_Dokumente_ID.CommandText")
        Me.OleDbSelectCommand_Dokumente_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Dokumente_ID
        '
        Me.OleDbUpdateCommand_Dokumente_ID.CommandText = resources.GetString("OleDbUpdateCommand_Dokumente_ID.CommandText")
        Me.OleDbUpdateCommand_Dokumente_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("DateinameOrig", System.Data.OleDb.OleDbType.VarChar, 300, "DateinameOrig"), New System.Data.OleDb.OleDbParameter("VerzeichnisOrig", System.Data.OleDb.OleDbType.VarChar, 500, "VerzeichnisOrig"), New System.Data.OleDb.OleDbParameter("DokumentGröße", System.Data.OleDb.OleDbType.[Double], 8, "DokumentGröße"), New System.Data.OleDb.OleDbParameter("DokumentErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DokumentErstellt"), New System.Data.OleDb.OleDbParameter("DokumentGeändert", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DokumentGeändert"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 1, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 100, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 150, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 50, "DateinameTyp"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daDokumente_IDDokueintrag
        '
        Me.daDokumente_IDDokueintrag.SelectCommand = Me.OleDbSelectCommand_Dokumente_IDDokueintrag
        Me.daDokumente_IDDokueintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("DateinameOrig", "DateinameOrig"), New System.Data.Common.DataColumnMapping("VerzeichnisOrig", "VerzeichnisOrig"), New System.Data.Common.DataColumnMapping("DokumentGröße", "DokumentGröße"), New System.Data.Common.DataColumnMapping("DokumentErstellt", "DokumentErstellt"), New System.Data.Common.DataColumnMapping("DokumentGeändert", "DokumentGeändert"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Winzip", "Winzip"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp")})})
        '
        'OleDbSelectCommand_Dokumente_IDDokueintrag
        '
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag.CommandText = resources.GetString("OleDbSelectCommand_Dokumente_IDDokueintrag.CommandText")
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")})
        '
        'daDokumenteintrag_anzahl
        '
        Me.daDokumenteintrag_anzahl.SelectCommand = Me.OleDbSelectCommand_Dokumenteintrag_anzahl
        Me.daDokumenteintrag_anzahl.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Table", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("anzahl", "anzahl")})})
        '
        'OleDbSelectCommand_Dokumenteintrag_anzahl
        '
        Me.OleDbSelectCommand_Dokumenteintrag_anzahl.CommandText = "SELECT COUNT(*) AS anzahl FROM tblDokumenteintrag"
        Me.OleDbSelectCommand_Dokumenteintrag_anzahl.Connection = Me.conArchiv

    End Sub

#End Region


    Public Function LesenDokument(ByVal ID As System.Guid) As dsPlanArchive.tblDokumenteRow
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumente_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumente_ID.CommandTimeout = 0
            Me.daDokumente_ID.SelectCommand = Me.OleDbSelectCommand_Dokumente_ID
            Me.daDokumente_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daDokumente_ID.Fill(data)

            Dim ret As New ArrayList
            If data.tblDokumente.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblDokumenteRow
                r = data.tblDokumente.NewRow
                r = data.tblDokumente.Rows(0)
                Return r
            End If

            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function LesenDokument_IDDokueintrag(ByVal IDDokumenteintrag As System.Guid) As dsPlanArchive.tblDokumenteRow
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumente_IDDokueintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumente_IDDokueintrag.CommandTimeout = 0
            Me.daDokumente_IDDokueintrag.SelectCommand = Me.OleDbSelectCommand_Dokumente_IDDokueintrag
            Me.daDokumente_IDDokueintrag.SelectCommand.Parameters("IDDokumenteintrag").Value = IDDokumenteintrag
            Me.daDokumente_IDDokueintrag.Fill(data)

            If data.tblDokumente.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblDokumenteRow
                r = data.tblDokumente.NewRow
                r = data.tblDokumente.Rows(0)
                Return r
            End If

            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function LesenDokumenteintrag(ByVal ID As System.Guid) As dsPlanArchive.tblDokumenteintragRow
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumenteintrag_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumenteintrag_ID.CommandTimeout = 0
            Me.daDokumenteintrag_ID.SelectCommand = Me.OleDbSelectCommand_Dokumenteintrag_ID
            Me.daDokumenteintrag_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daDokumenteintrag_ID.Fill(data)

            Dim ret As New ArrayList
            If data.tblDokumenteintrag.Rows.Count = 1 Then
                Dim r As dsPlanArchive.tblDokumenteintragRow
                r = data.tblDokumenteintrag.NewRow
                r = data.tblDokumenteintrag.Rows(0)
                Return r
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function insertDokument(ByVal r As dsPlanArchive.tblDokumenteRow) As Boolean
        Try

            Me.OleDbInsertCommand_Dokumente_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_Dokumente_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("IDDokumenteintrag").Value = r.IDDokumenteintrag
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameOrig").Value = r.DateinameOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("VerzeichnisOrig").Value = r.VerzeichnisOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGröße").Value = r.DokumentGröße
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentErstellt").Value = r.DokumentErstellt
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGeändert").Value = r.DokumentGeändert
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltVon").Value = r.ErstelltVon
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Winzip").Value = r.Winzip
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Archivordner").Value = r.Archivordner
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameArchiv").Value = r.DateinameArchiv
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameTyp").Value = r.DateinameTyp

            Me.OleDbInsertCommand_Dokumente_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub updateDokument(ByVal r As dsPlanArchive.tblDokumenteRow)
        Try

            Me.OleDbUpdateCommand_Dokumente_ID.Connection = db.getConnDB
            Me.OleDbUpdateCommand_Dokumente_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumente_ID.Parameters("IDDokumenteintrag").Value = r.IDDokumenteintrag
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Dateiname").Value = r.DateinameOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("VerzeichnisOrig").Value = r.VerzeichnisOrig
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGröße").Value = r.DokumentGröße
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentErstellt").Value = r.DokumentErstellt
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DokumentGeändert").Value = r.DokumentGeändert
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("ErstelltVon").Value = r.ErstelltVon
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Winzip").Value = r.Winzip
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("Archivordner").Value = r.Archivordner
            Me.OleDbInsertCommand_Dokumente_ID.Parameters("DateinameTyp").Value = r.DateinameTyp
            Me.OleDbUpdateCommand_Dokumente_ID.Parameters("Original_ID").Value = r.ID

            Me.OleDbUpdateCommand_Dokumente_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function insertDokumenteintrag(ByVal r As dsPlanArchive.tblDokumenteintragRow) As Boolean
        Try

            Me.OleDbInsertCommand_Dokumenteintrag_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_Dokumenteintrag_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("IDOrdner").Value = r.IDOrdner
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Bezeichnung").Value = r.Bezeichnung
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Notiz").Value = r.Notiz
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("NotizRTF").Value = System.DBNull.Value
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigVon").Value = gen.proveDateTime(r.GültigVon)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigBis").Value = gen.proveDateTime(r.GültigBis)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Wichtigkeit").Value = r.Wichtigkeit
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltVon").Value = r.ErstelltVon

            Me.OleDbInsertCommand_Dokumenteintrag_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub updateDokumenteintrag(ByVal r As dsPlanArchive.tblDokumenteintragRow)
        Try

            Me.OleDbUpdateCommand_Dokumenteintrag_ID.Connection = db.getConnDB
            Me.OleDbUpdateCommand_Dokumenteintrag_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("IDOrdner").Value = r.IDOrdner
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Bezeichnung").Value = r.Bezeichnung
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Notiz").Value = r.Notiz
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("NotizRTF").Value = System.DBNull.Value
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigVon").Value = gen.proveDateTime(r.GültigVon)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("GültigBis").Value = gen.proveDateTime(r.GültigBis)
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("Wichtigkeit").Value = r.Wichtigkeit
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltAm").Value = r.ErstelltAm
            Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters("ErstelltVon").Value = r.ErstelltVon
            Me.OleDbUpdateCommand_Dokumenteintrag_ID.Parameters("Original_ID").Value = r.ID

            Me.OleDbUpdateCommand_Dokumenteintrag_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Function DokumenteneintragLöschen(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.CommandTimeout = 0
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.Parameters("Original_ID").Value = ID
            Me.OleDbDeleteCommand_Dokumenteintrag_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function AnzahlEintägeDokumente() As Integer
        Try

            Dim tbl As New DataTable
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumenteintrag_anzahl.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumenteintrag_anzahl.CommandTimeout = 0
            Me.daDokumenteintrag_anzahl.SelectCommand = Me.OleDbSelectCommand_Dokumenteintrag_anzahl
            Me.daDokumenteintrag_anzahl.Fill(tbl)

            If tbl.Rows.Count = 1 Then
                Return tbl.Rows(0)(0)
            Else
                Return 0
            End If

            Return 0

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

End Class
