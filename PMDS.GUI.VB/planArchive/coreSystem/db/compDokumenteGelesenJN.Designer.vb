Partial Class compDokumenteGelesenJN
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        Container.Add(Me)

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compDokumenteGelesenJN))
        Me.OleDbSelectCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.conDB = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbDeleteCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.daDokumenteGelesen_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN = New System.Data.OleDb.OleDbCommand
        Me.daAlleDokumenteGelesenJN = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein = New System.Data.OleDb.OleDbCommand
        Me.daAlleDokumenteGelesenJaNein = New System.Data.OleDb.OleDbDataAdapter
        '
        'OleDbSelectCommand_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_IDDokumenteneintrag.CommandText = "SELECT     ID, IDDokumenteneintrag, gelesen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblDokumenteGelesen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WH" & _
            "ERE     (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_IDDokumenteneintrag.Connection = Me.conDB
        Me.OleDbSelectCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'conDB
        '
        Me.conDB.ConnectionString = "Provider=SQLNCLI.1;Data Source=s2sty002\test;Persist Security Info=True;Password=" & _
            "test;User ID=sa;Initial Catalog=Archiv"
        '
        'OleDbInsertCommand_IDDokumenteneintrag
        '
        Me.OleDbInsertCommand_IDDokumenteneintrag.CommandText = "INSERT INTO [tblDokumenteGelesen] ([ID], [IDDokumenteneintrag], [gelesen]) VALUES" & _
            " (?, ?, ?)"
        Me.OleDbInsertCommand_IDDokumenteneintrag.Connection = Me.conDB
        Me.OleDbInsertCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 0, "gelesen")})
        '
        'OleDbUpdateCommand_IDDokumenteneintrag
        '
        Me.OleDbUpdateCommand_IDDokumenteneintrag.CommandText = "UPDATE [tblDokumenteGelesen] SET [ID] = ?, [IDDokumenteneintrag] = ?, [gelesen] =" & _
            " ? WHERE (([ID] = ?))"
        Me.OleDbUpdateCommand_IDDokumenteneintrag.Connection = Me.conDB
        Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 0, "gelesen"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDeleteCommand_IDDokumenteneintrag
        '
        Me.OleDbDeleteCommand_IDDokumenteneintrag.CommandText = "DELETE FROM [tblDokumenteGelesen] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_IDDokumenteneintrag.Connection = Me.conDB
        Me.OleDbDeleteCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daDokumenteGelesen_IDDokumenteneintrag
        '
        Me.daDokumenteGelesen_IDDokumenteneintrag.DeleteCommand = Me.OleDbDeleteCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.InsertCommand = Me.OleDbInsertCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumenteGelesen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen")})})
        Me.daDokumenteGelesen_IDDokumenteneintrag.UpdateCommand = Me.OleDbUpdateCommand_IDDokumenteneintrag
        '
        'OleDbSelectCommand_AlleDokumenteGelesenJN
        '
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN.CommandText = resources.GetString("OleDbSelectCommand_AlleDokumenteGelesenJN.CommandText")
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN.Connection = Me.conDB
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 1, "gelesen")})
        '
        'daAlleDokumenteGelesenJN
        '
        Me.daAlleDokumenteGelesenJN.SelectCommand = Me.OleDbSelectCommand_AlleDokumenteGelesenJN
        Me.daAlleDokumenteGelesenJN.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("BezeichnungOrdner", "BezeichnungOrdner"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp")})})
        '
        'OleDbSelectCommand_AlleDokumenteGelesenJaNein
        '
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.CommandText = resources.GetString("OleDbSelectCommand_AlleDokumenteGelesenJaNein.CommandText")
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.Connection = Me.conDB
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 1, "gelesen")})
        '
        'daAlleDokumenteGelesenJaNein
        '
        Me.daAlleDokumenteGelesenJaNein.SelectCommand = Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein
        Me.daAlleDokumenteGelesenJaNein.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen")})})

    End Sub
    Friend WithEvents OleDbSelectCommand_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumenteGelesen_IDDokumenteneintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents conDB As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand_AlleDokumenteGelesenJN As System.Data.OleDb.OleDbCommand
    Friend WithEvents daAlleDokumenteGelesenJN As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_AlleDokumenteGelesenJaNein As System.Data.OleDb.OleDbCommand
    Friend WithEvents daAlleDokumenteGelesenJaNein As System.Data.OleDb.OleDbDataAdapter

End Class
