

Public Class compSchrankFachOrdner
    Inherits System.ComponentModel.Component

    Private gen As New GeneralArchiv
    Private genMain As New GeneralArchiv



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
    Public WithEvents daSchränkeAlle As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daFächer_IDSchrank As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daOrdner_IDFach As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daFächer_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schränke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schränke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schränke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Schränke As System.Data.OleDb.OleDbCommand
    Friend WithEvents daSchrank_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Fächer_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Fächer_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Fächer_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Fächer_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Fächer_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Fächer_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Fächer_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Fächer_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Ordner_IDFach As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Ordner_IDFach As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Ordner_IDFach As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_AlleDateienPapierkorb As System.Data.OleDb.OleDbCommand
    Friend WithEvents daAlleDateienPapierkorb As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumentendaten_IDDokumenteneintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Ordner_IDFach As System.Data.OleDb.OleDbCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compSchrankFachOrdner))
        Me.daSchränkeAlle = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Schränke = New System.Data.OleDb.OleDbCommand
        Me.conArchiv = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand_Schränke = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Schränke = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Schränke = New System.Data.OleDb.OleDbCommand
        Me.daFächer_IDSchrank = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.daOrdner_IDFach = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.daFächer_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand
        Me.daSchrank_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_AlleDateienPapierkorb = New System.Data.OleDb.OleDbCommand
        Me.daAlleDateienPapierkorb = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.daDokumentendaten_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter
        '
        'daSchränkeAlle
        '
        Me.daSchränkeAlle.DeleteCommand = Me.OleDbDeleteCommand_Schränke
        Me.daSchränkeAlle.InsertCommand = Me.OleDbInsertCommand_Schränke
        Me.daSchränkeAlle.SelectCommand = Me.OleDbSelectCommand_Schränke
        Me.daSchränkeAlle.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchrank", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daSchränkeAlle.UpdateCommand = Me.OleDbUpdateCommand_Schränke
        '
        'OleDbDeleteCommand_Schränke
        '
        Me.OleDbDeleteCommand_Schränke.CommandText = "DELETE FROM [tblSchrank] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([Erstellt" & _
            "Am] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_Schränke.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "Provider=SQLNCLI.1;Data Source=s2sty002\test;Persist Security Info=True;Password=" & _
            "test;User ID=sa;Initial Catalog=Archiv"
        '
        'OleDbInsertCommand_Schränke
        '
        Me.OleDbInsertCommand_Schränke.CommandText = "INSERT INTO [tblSchrank] ([ID], [Bezeichnung], [ErstelltAm], [ErstelltVon], [Exte" & _
            "rn]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schränke.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Schränke
        '
        Me.OleDbSelectCommand_Schränke.CommandText = "SELECT ID, Bezeichnung, ErstelltAm, ErstelltVon, Extern FROM tblSchrank ORDER BY " & _
            "Bezeichnung asc"
        Me.OleDbSelectCommand_Schränke.Connection = Me.conArchiv
        '
        'OleDbUpdateCommand_Schränke
        '
        Me.OleDbUpdateCommand_Schränke.CommandText = resources.GetString("OleDbUpdateCommand_Schränke.CommandText")
        Me.OleDbUpdateCommand_Schränke.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daFächer_IDSchrank
        '
        Me.daFächer_IDSchrank.DeleteCommand = Me.OleDbDeleteCommand_Fächer_IDSchrank
        Me.daFächer_IDSchrank.InsertCommand = Me.OleDbInsertCommand_Fächer_IDSchrank
        Me.daFächer_IDSchrank.SelectCommand = Me.OleDbSelectCommand_Fächer_IDSchrank
        Me.daFächer_IDSchrank.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblFach", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDSchrank", "IDSchrank"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daFächer_IDSchrank.UpdateCommand = Me.OleDbUpdateCommand_Fächer_IDSchrank
        '
        'OleDbDeleteCommand_Fächer_IDSchrank
        '
        Me.OleDbDeleteCommand_Fächer_IDSchrank.CommandText = "DELETE FROM [tblFach] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([IDSchrank] " & _
            "= ?) AND ([ErstelltAm] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_Fächer_IDSchrank.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Fächer_IDSchrank
        '
        Me.OleDbInsertCommand_Fächer_IDSchrank.CommandText = "INSERT INTO [tblFach] ([ID], [Bezeichnung], [IDSchrank], [ErstelltAm], [ErstelltV" & _
            "on], [Extern]) VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Fächer_IDSchrank.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Fächer_IDSchrank
        '
        Me.OleDbSelectCommand_Fächer_IDSchrank.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" & _
            "HERE (IDSchrank = ?) ORDER BY Bezeichnung asc"
        Me.OleDbSelectCommand_Fächer_IDSchrank.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank")})
        '
        'OleDbUpdateCommand_Fächer_IDSchrank
        '
        Me.OleDbUpdateCommand_Fächer_IDSchrank.CommandText = resources.GetString("OleDbUpdateCommand_Fächer_IDSchrank.CommandText")
        Me.OleDbUpdateCommand_Fächer_IDSchrank.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daOrdner_IDFach
        '
        Me.daOrdner_IDFach.DeleteCommand = Me.OleDbDeleteCommand_Ordner_IDFach
        Me.daOrdner_IDFach.InsertCommand = Me.OleDbInsertCommand_Ordner_IDFach
        Me.daOrdner_IDFach.SelectCommand = Me.OleDbSelectCommand_Ordner_IDFach
        Me.daOrdner_IDFach.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDFach", "IDFach"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Icon", "Icon"), New System.Data.Common.DataColumnMapping("Extern", "Extern"), New System.Data.Common.DataColumnMapping("IDSystemordner", "IDSystemordner")})})
        Me.daOrdner_IDFach.UpdateCommand = Me.OleDbUpdateCommand_Ordner_IDFach
        '
        'OleDbDeleteCommand_Ordner_IDFach
        '
        Me.OleDbDeleteCommand_Ordner_IDFach.CommandText = "DELETE FROM [tblOrdner] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_Ordner_IDFach.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Ordner_IDFach
        '
        Me.OleDbInsertCommand_Ordner_IDFach.CommandText = "INSERT INTO [tblOrdner] ([ID], [Bezeichnung], [IDFach], [ErstelltAm], [ErstelltVo" & _
            "n], [Icon], [Extern], [IDSystemordner]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Ordner_IDFach.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 0, "IDFach"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner")})
        '
        'OleDbSelectCommand_Ordner_IDFach
        '
        Me.OleDbSelectCommand_Ordner_IDFach.CommandText = "SELECT ID, Bezeichnung, IDFach, ErstelltAm, ErstelltVon, Icon, Extern, IDSystemor" & _
            "dner   FROM tblOrdner WHERE (IDFach = ?) ORDER BY Bezeichnung"
        Me.OleDbSelectCommand_Ordner_IDFach.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 16, "IDFach")})
        '
        'OleDbUpdateCommand_Ordner_IDFach
        '
        Me.OleDbUpdateCommand_Ordner_IDFach.CommandText = "UPDATE [tblOrdner] SET [ID] = ?, [Bezeichnung] = ?, [IDFach] = ?, [ErstelltAm] = " & _
            "?, [ErstelltVon] = ?, [Icon] = ?, [Extern] = ?, [IDSystemordner] = ? WHERE (([ID" & _
            "] = ?))"
        Me.OleDbUpdateCommand_Ordner_IDFach.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 0, "IDFach"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daFächer_ID
        '
        Me.daFächer_ID.DeleteCommand = Me.OleDbDeleteCommand_Fächer_ID
        Me.daFächer_ID.InsertCommand = Me.OleDbInsertCommand_Fächer_ID
        Me.daFächer_ID.SelectCommand = Me.OleDbSelectCommand_Fächer_ID
        Me.daFächer_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblFach", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDSchrank", "IDSchrank"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daFächer_ID.UpdateCommand = Me.OleDbUpdateCommand_Fächer_ID
        '
        'OleDbDeleteCommand_Fächer_ID
        '
        Me.OleDbDeleteCommand_Fächer_ID.CommandText = "DELETE FROM tblFach WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Fächer_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Fächer_ID
        '
        Me.OleDbInsertCommand_Fächer_ID.CommandText = "INSERT INTO tblFach(ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern) " & _
            "VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Fächer_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern")})
        '
        'OleDbSelectCommand_Fächer_ID
        '
        Me.OleDbSelectCommand_Fächer_ID.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" & _
            "HERE (ID = ?)"
        Me.OleDbSelectCommand_Fächer_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Fächer_ID
        '
        Me.OleDbUpdateCommand_Fächer_ID.CommandText = "UPDATE tblFach SET ID = ?, Bezeichnung = ?, IDSchrank = ?, ErstelltAm = ?, Erstel" & _
            "ltVon = ?, Extern = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Fächer_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSchrank_ID
        '
        Me.daSchrank_ID.DeleteCommand = Me.OleDbDeleteCommand_Schrank_ID
        Me.daSchrank_ID.InsertCommand = Me.OleDbInsertCommand_Schrank_ID
        Me.daSchrank_ID.SelectCommand = Me.OleDbSelectCommand_Schrank_ID
        Me.daSchrank_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchrank", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daSchrank_ID.UpdateCommand = Me.OleDbUpdateCommand_Schrank_ID
        '
        'OleDbDeleteCommand_Schrank_ID
        '
        Me.OleDbDeleteCommand_Schrank_ID.CommandText = "DELETE FROM [tblSchrank] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_Schrank_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Schrank_ID
        '
        Me.OleDbInsertCommand_Schrank_ID.CommandText = "INSERT INTO [tblSchrank] ([ID], [Bezeichnung], [ErstelltAm], [ErstelltVon], [Exte" & _
            "rn]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schrank_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Schrank_ID
        '
        Me.OleDbSelectCommand_Schrank_ID.CommandText = "SELECT ID, Bezeichnung, ErstelltAm, ErstelltVon, Extern FROM tblSchrank WHERE (ID" & _
            " = ?)"
        Me.OleDbSelectCommand_Schrank_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Schrank_ID
        '
        Me.OleDbUpdateCommand_Schrank_ID.CommandText = "UPDATE [tblSchrank] SET [ID] = ?, [Bezeichnung] = ?, [ErstelltAm] = ?, [ErstelltV" & _
            "on] = ?, [Extern] = ? WHERE (([ID] = ?))"
        Me.OleDbUpdateCommand_Schrank_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbSelectCommand_AlleDateienPapierkorb
        '
        Me.OleDbSelectCommand_AlleDateienPapierkorb.CommandText = resources.GetString("OleDbSelectCommand_AlleDateienPapierkorb.CommandText")
        Me.OleDbSelectCommand_AlleDateienPapierkorb.Connection = Me.conArchiv
        '
        'daAlleDateienPapierkorb
        '
        Me.daAlleDateienPapierkorb.SelectCommand = Me.OleDbSelectCommand_AlleDateienPapierkorb
        Me.daAlleDateienPapierkorb.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSystemordner", "IDSystemordner"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDDokumente", "IDDokumente")})})
        '
        'OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandText = resources.GetString("OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandText")
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")})
        '
        'daDokumentendaten_IDDokumenteneintrag
        '
        Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
        Me.daDokumentendaten_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("BezeichnungOrdner", "BezeichnungOrdner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DokumentGröße", "DokumentGröße"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("IDFach", "IDFach")})})

    End Sub

#End Region


    Public Function LesenAlleSchränke() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schränke.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schränke.CommandTimeout = 0
            Me.daSchränkeAlle.SelectCommand = Me.OleDbSelectCommand_Schränke
            data.Clear()
            Me.daSchränkeAlle.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function AlleDateienAusPapierkorbLesen() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_AlleDateienPapierkorb.Connection = conn.getConnDB
            Me.OleDbSelectCommand_AlleDateienPapierkorb.CommandTimeout = 0
            Me.daAlleDateienPapierkorb.SelectCommand = Me.OleDbSelectCommand_AlleDateienPapierkorb
            Me.daAlleDateienPapierkorb.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function ExistiertSchrank(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schrank_ID.CommandTimeout = 0
            Me.daSchrank_ID.SelectCommand = Me.OleDbSelectCommand_Schrank_ID
            Me.daSchrank_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daSchrank_ID.Fill(data)
            If data.tblSchrank.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function SchränkeSpeichern(ByRef dsSchränke As dsPlanArchive) As Boolean
        Try

            For Each r_schrank As dsPlanArchive.tblSchrankRow In dsSchränke.tblSchrank
                If Me.ExistiertSchrank(r_schrank.ID) Then
                    Me.updateSchrank(r_schrank)
                Else
                    Me.insertSchrank(r_schrank)
                End If
            Next


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertSchrank(ByVal r_schrank As dsPlanArchive.tblSchrankRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Schrank_ID.Parameters("ID").Value = r_schrank.ID
            Me.OleDbInsertCommand_Schrank_ID.Parameters("Bezeichnung").Value = r_schrank.Bezeichnung
            Me.OleDbInsertCommand_Schrank_ID.Parameters("ErstelltAm").Value = r_schrank.ErstelltAm
            Me.OleDbInsertCommand_Schrank_ID.Parameters("ErstelltVon").Value = r_schrank.ErstelltVon
            Me.OleDbInsertCommand_Schrank_ID.Parameters("Extern").Value = r_schrank.Extern

            Me.OleDbInsertCommand_Schrank_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateSchrank(ByVal r_schrank As dsPlanArchive.tblSchrankRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ID").Value = r_schrank.ID
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Bezeichnung").Value = r_schrank.Bezeichnung
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ErstelltAm").Value = r_schrank.ErstelltAm
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("ErstelltVon").Value = r_schrank.ErstelltVon
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Extern").Value = r_schrank.Extern
            Me.OleDbUpdateCommand_Schrank_ID.Parameters("Original_ID").Value = r_schrank.ID

            Me.OleDbUpdateCommand_Schrank_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function LesenDatenFürDokument(ByVal IDDokumenteneintrag As System.Guid) As dsDokumentendaten
        Try
            Dim data As New dsDokumentendaten
            Dim conn As New db
            Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandTimeout = 0
            Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
            Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand.Parameters("ID").Value = IDDokumenteneintrag
            Me.daDokumentendaten_IDDokumenteneintrag.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function LesenAlleFächer(ByVal IDSchrank As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Fächer_IDSchrank.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Fächer_IDSchrank.CommandTimeout = 0
            Me.daFächer_IDSchrank.SelectCommand = Me.OleDbSelectCommand_Fächer_IDSchrank
            Me.daFächer_IDSchrank.SelectCommand.Parameters("IDSchrank").Value = IDSchrank
            Me.daFächer_IDSchrank.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function ExistiertFach(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Fächer_ID.CommandTimeout = 0
            Me.daFächer_ID.SelectCommand = Me.OleDbSelectCommand_Fächer_ID
            Me.daFächer_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daFächer_ID.Fill(data)
            If data.tblFach.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function FächerSpeichern(ByRef dsFächer As dsPlanArchive) As Boolean
        Try

            For Each r_fach As dsPlanArchive.tblFachRow In dsFächer.tblFach
                If Me.ExistiertFach(r_fach.ID) Then
                    Me.updateFach(r_fach)
                Else
                    Me.insertFach(r_fach)
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertFach(ByVal r_fach As dsPlanArchive.tblFachRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Fächer_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbInsertCommand_Fächer_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbInsertCommand_Fächer_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbInsertCommand_Fächer_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbInsertCommand_Fächer_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbInsertCommand_Fächer_ID.Parameters("Extern").Value = r_fach.Extern

            Me.OleDbInsertCommand_Fächer_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateFach(ByVal r_fach As dsPlanArchive.tblFachRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Original_ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Extern").Value = r_fach.Extern
            Me.OleDbUpdateCommand_Fächer_ID.Parameters("Original_ID").Value = r_fach.ID

            Me.OleDbUpdateCommand_Fächer_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function LesenAlleOrdner(ByVal IDFach As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Ordner_IDFach.CommandTimeout = 0
            Me.daOrdner_IDFach.SelectCommand = Me.OleDbSelectCommand_Ordner_IDFach
            Me.daOrdner_IDFach.SelectCommand.Parameters("IDFach").Value = IDFach
            Me.daOrdner_IDFach.Fill(data)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function ExistiertPapierkorbJN() As Boolean
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New DataTable
            Dim conn As New db
            Dim Sql As String = "SELECT *  FROM tblOrdner where IDSystemordner = 1 "
            Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
            Command.CommandTimeout = 0
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(data)
            If data.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function GetIDOrdnerPapierkorb() As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New DataTable
            Dim conn As New db
            Dim Sql As String = "SELECT ID  FROM tblOrdner where IDSystemordner = 1 "
            Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
            Command.CommandTimeout = 0
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(data)
            If data.Rows.Count = 1 Then
                Return data.Rows(0)("ID")
            End If
            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function GetIDOrdnerAnhangPlanungssystem() As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New DataTable
            Dim conn As New db
            Dim Sql As String = "SELECT ID  FROM tblOrdner where IDSystemordner = 2 "
            Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
            Command.CommandTimeout = 0
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(data)
            If data.Rows.Count = 1 Then
                Return data.Rows(0)("ID")
            End If
            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function GetOrdnerBiografie(ByVal bez As String) As System.Guid
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New DataTable
            Dim conn As New db
            Dim Sql As String = "SELECT ID  FROM tblOrdner where Bezeichnung = '" + bez + "' "
            Dim Command As New OleDb.OleDbCommand(Sql, conn.getConnDB)
            Command.CommandTimeout = 0
            DataAdapter.SelectCommand = Command
            DataAdapter.Fill(data)
            If data.Rows.Count = 1 Then
                Return data.Rows(0)("ID")
            End If
            Return Nothing

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Sub insertOrdner(ByVal r_ordner As dsPlanArchive.tblOrdnerRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ID").Value = r_ordner.ID
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Bezeichnung").Value = r_ordner.Bezeichnung
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("IDFach").Value = r_ordner.IDFach
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ErstelltAm").Value = r_ordner.ErstelltAm
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("ErstelltVon").Value = r_ordner.ErstelltVon
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Icon").Value = Nothing
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("Extern").Value = r_ordner.Extern
            Me.OleDbInsertCommand_Ordner_IDFach.Parameters("IDSystemordner").Value = r_ordner.IDSystemordner

            Me.OleDbInsertCommand_Ordner_IDFach.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Function updateOrdner(ByVal r_ordner As dsPlanArchive.tblOrdnerRow) As Boolean
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ID").Value = r_ordner.ID
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Bezeichnung").Value = r_ordner.Bezeichnung
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("IDFach").Value = r_ordner.IDFach
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ErstelltAm").Value = r_ordner.ErstelltAm
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("ErstelltVon").Value = r_ordner.ErstelltVon
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Icon").Value = Nothing
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Extern").Value = r_ordner.Extern
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Original_ID").Value = r_ordner.ID
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("IDSystemordner").Value = r_ordner.IDSystemordner

            Me.OleDbUpdateCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function UpdateIDOrdner_Dokumenteintrag(ByVal IDDokumenteintrag As System.Guid, ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim DataAdapter As New OleDb.OleDbDataAdapter
            Dim data As New dsPlanArchive
            Dim conn As New db
            Dim Command As New OleDb.OleDbCommand()
            Command.CommandTimeout = 0

            Command.CommandText = "UPDATE tblDokumenteintrag SET  IDOrdner = ?  WHERE ID = ? "
            Command.Connection = conn.getConnDB
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")).Value = IDOrdner
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")).Value = IDDokumenteintrag
            Command.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function updateOrdner_CleyrSystemordner(ByVal IDSystemordner As Integer) As Boolean
        Try
            Dim Command As New OleDb.OleDbCommand
            Dim conn As New db
            Command.CommandText = "UPDATE tblOrdner SET  IDSystemordner = -1  WHERE IDSystemordner = ? "
            Command.Connection = conn.getConnDB
            Command.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.Integer, 4, "IDSystemordner")).Value = IDSystemordner
            Command.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function updateOrdnerExternIntern(ByVal IDOrdner As System.Guid, ByVal extern As Boolean) As Boolean
        Try
            Dim conn As New db

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Clear()
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandText = "UPDATE tblOrdner SET   Extern = ? WHERE (ID = ?)"
            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = Me.conArchiv

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Add(New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.Boolean, 1, "Extern"))
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))

            Me.OleDbUpdateCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Extern").Value = extern
            Me.OleDbUpdateCommand_Ordner_IDFach.Parameters("Original_ID").Value = IDOrdner

            Me.OleDbUpdateCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function deleteOrdner(ByVal IDOrdner As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Ordner_IDFach.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Ordner_IDFach.CommandTimeout = 0

            Me.OleDbDeleteCommand_Ordner_IDFach.Parameters("Original_ID").Value = IDOrdner
            Me.OleDbDeleteCommand_Ordner_IDFach.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function deleteSchrank(ByVal IDSchrank As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Schrank_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Schrank_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Schrank_ID.Parameters("Original_ID").Value = IDSchrank
            Me.OleDbDeleteCommand_Schrank_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function deleteFächer(ByVal IDFach As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_Fächer_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Fächer_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Fächer_ID.Parameters("Original_ID").Value = IDFach
            Me.OleDbDeleteCommand_Fächer_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function


    Public Function neuenOrdnerAnlegen(ByVal bez As String) As Boolean
        Dim gen As New GeneralArchiv
        Try

            Dim data As New dsPlanArchive
            Dim r_ordner As dsPlanArchive.tblOrdnerRow
            Dim comp As New compSchrankFachOrdner

            r_ordner = data.tblOrdner.NewRow
            gen.initRow(r_ordner)

            r_ordner.ID = System.Guid.NewGuid
            r_ordner.IDFach = Nothing
            r_ordner.Bezeichnung = bez
            r_ordner.ErstelltVon = genMain.actUser
            r_ordner.ErstelltAm = Now
            r_ordner.IDSystemordner = -1
            comp.insertOrdner(r_ordner)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

End Class
