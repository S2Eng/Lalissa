

Public Class compSchrankFachOrdner
    Inherits System.ComponentModel.Component

    Private gen As New GeneralArchiv
    Private genMain As New GeneralArchiv



#Region " Vom Component Designer generierter Code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'F�r Support von Windows.Forms-Klassenkompositions-Designer
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Komponenten-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf�gen

    End Sub

    'Die Komponente �berschreibt den L�schvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F�r Komponenten-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist f�r den Komponenten-Designer erforderlich
    'Sie kann mit dem Komponenten-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents conArchiv As System.Data.OleDb.OleDbConnection
    Public WithEvents daSchr�nkeAlle As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daF�cher_IDSchrank As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daOrdner_IDFach As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daF�cher_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schr�nke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schr�nke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schr�nke As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Schr�nke As System.Data.OleDb.OleDbCommand
    Friend WithEvents daSchrank_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Schrank_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_F�cher_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_F�cher_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_F�cher_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_F�cher_IDSchrank As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_F�cher_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_F�cher_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_F�cher_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_F�cher_ID As System.Data.OleDb.OleDbCommand
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
        Me.daSchr�nkeAlle = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Schr�nke = New System.Data.OleDb.OleDbCommand
        Me.conArchiv = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand_Schr�nke = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Schr�nke = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Schr�nke = New System.Data.OleDb.OleDbCommand
        Me.daF�cher_IDSchrank = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_F�cher_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_F�cher_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_F�cher_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_F�cher_IDSchrank = New System.Data.OleDb.OleDbCommand
        Me.daOrdner_IDFach = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand
        Me.daF�cher_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_F�cher_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_F�cher_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_F�cher_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_F�cher_ID = New System.Data.OleDb.OleDbCommand
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
        'daSchr�nkeAlle
        '
        Me.daSchr�nkeAlle.DeleteCommand = Me.OleDbDeleteCommand_Schr�nke
        Me.daSchr�nkeAlle.InsertCommand = Me.OleDbInsertCommand_Schr�nke
        Me.daSchr�nkeAlle.SelectCommand = Me.OleDbSelectCommand_Schr�nke
        Me.daSchr�nkeAlle.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchrank", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daSchr�nkeAlle.UpdateCommand = Me.OleDbUpdateCommand_Schr�nke
        '
        'OleDbDeleteCommand_Schr�nke
        '
        Me.OleDbDeleteCommand_Schr�nke.CommandText = "DELETE FROM [tblSchrank] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([Erstellt" & _
            "Am] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_Schr�nke.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Schr�nke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "Provider=SQLNCLI.1;Data Source=s2sty002\test;Persist Security Info=True;Password=" & _
            "test;User ID=sa;Initial Catalog=Archiv"
        '
        'OleDbInsertCommand_Schr�nke
        '
        Me.OleDbInsertCommand_Schr�nke.CommandText = "INSERT INTO [tblSchrank] ([ID], [Bezeichnung], [ErstelltAm], [ErstelltVon], [Exte" & _
            "rn]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schr�nke.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Schr�nke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Schr�nke
        '
        Me.OleDbSelectCommand_Schr�nke.CommandText = "SELECT ID, Bezeichnung, ErstelltAm, ErstelltVon, Extern FROM tblSchrank ORDER BY " & _
            "Bezeichnung asc"
        Me.OleDbSelectCommand_Schr�nke.Connection = Me.conArchiv
        '
        'OleDbUpdateCommand_Schr�nke
        '
        Me.OleDbUpdateCommand_Schr�nke.CommandText = resources.GetString("OleDbUpdateCommand_Schr�nke.CommandText")
        Me.OleDbUpdateCommand_Schr�nke.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Schr�nke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daF�cher_IDSchrank
        '
        Me.daF�cher_IDSchrank.DeleteCommand = Me.OleDbDeleteCommand_F�cher_IDSchrank
        Me.daF�cher_IDSchrank.InsertCommand = Me.OleDbInsertCommand_F�cher_IDSchrank
        Me.daF�cher_IDSchrank.SelectCommand = Me.OleDbSelectCommand_F�cher_IDSchrank
        Me.daF�cher_IDSchrank.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblFach", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDSchrank", "IDSchrank"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daF�cher_IDSchrank.UpdateCommand = Me.OleDbUpdateCommand_F�cher_IDSchrank
        '
        'OleDbDeleteCommand_F�cher_IDSchrank
        '
        Me.OleDbDeleteCommand_F�cher_IDSchrank.CommandText = "DELETE FROM [tblFach] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([IDSchrank] " & _
            "= ?) AND ([ErstelltAm] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_F�cher_IDSchrank.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_F�cher_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_F�cher_IDSchrank
        '
        Me.OleDbInsertCommand_F�cher_IDSchrank.CommandText = "INSERT INTO [tblFach] ([ID], [Bezeichnung], [IDSchrank], [ErstelltAm], [ErstelltV" & _
            "on], [Extern]) VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_F�cher_IDSchrank.Connection = Me.conArchiv
        Me.OleDbInsertCommand_F�cher_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_F�cher_IDSchrank
        '
        Me.OleDbSelectCommand_F�cher_IDSchrank.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" & _
            "HERE (IDSchrank = ?) ORDER BY Bezeichnung asc"
        Me.OleDbSelectCommand_F�cher_IDSchrank.Connection = Me.conArchiv
        Me.OleDbSelectCommand_F�cher_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank")})
        '
        'OleDbUpdateCommand_F�cher_IDSchrank
        '
        Me.OleDbUpdateCommand_F�cher_IDSchrank.CommandText = resources.GetString("OleDbUpdateCommand_F�cher_IDSchrank.CommandText")
        Me.OleDbUpdateCommand_F�cher_IDSchrank.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_F�cher_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
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
        'daF�cher_ID
        '
        Me.daF�cher_ID.DeleteCommand = Me.OleDbDeleteCommand_F�cher_ID
        Me.daF�cher_ID.InsertCommand = Me.OleDbInsertCommand_F�cher_ID
        Me.daF�cher_ID.SelectCommand = Me.OleDbSelectCommand_F�cher_ID
        Me.daF�cher_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblFach", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDSchrank", "IDSchrank"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Extern", "Extern")})})
        Me.daF�cher_ID.UpdateCommand = Me.OleDbUpdateCommand_F�cher_ID
        '
        'OleDbDeleteCommand_F�cher_ID
        '
        Me.OleDbDeleteCommand_F�cher_ID.CommandText = "DELETE FROM tblFach WHERE (ID = ?)"
        Me.OleDbDeleteCommand_F�cher_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_F�cher_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_F�cher_ID
        '
        Me.OleDbInsertCommand_F�cher_ID.CommandText = "INSERT INTO tblFach(ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern) " & _
            "VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_F�cher_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_F�cher_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern")})
        '
        'OleDbSelectCommand_F�cher_ID
        '
        Me.OleDbSelectCommand_F�cher_ID.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" & _
            "HERE (ID = ?)"
        Me.OleDbSelectCommand_F�cher_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_F�cher_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_F�cher_ID
        '
        Me.OleDbUpdateCommand_F�cher_ID.CommandText = "UPDATE tblFach SET ID = ?, Bezeichnung = ?, IDSchrank = ?, ErstelltAm = ?, Erstel" & _
            "ltVon = ?, Extern = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_F�cher_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_F�cher_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.daDokumentendaten_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("G�ltigVon", "G�ltigVon"), New System.Data.Common.DataColumnMapping("G�ltigBis", "G�ltigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("BezeichnungOrdner", "BezeichnungOrdner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DokumentGr��e", "DokumentGr��e"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("IDFach", "IDFach")})})

    End Sub

#End Region


    Public Function LesenAlleSchr�nke() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schr�nke.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schr�nke.CommandTimeout = 0
            Me.daSchr�nkeAlle.SelectCommand = Me.OleDbSelectCommand_Schr�nke
            data.Clear()
            Me.daSchr�nkeAlle.Fill(data)
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
    Public Function Schr�nkeSpeichern(ByRef dsSchr�nke As dsPlanArchive) As Boolean
        Try

            For Each r_schrank As dsPlanArchive.tblSchrankRow In dsSchr�nke.tblSchrank
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

    Public Function LesenDatenF�rDokument(ByVal IDDokumenteneintrag As System.Guid) As dsDokumentendaten
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

    Public Function LesenAlleF�cher(ByVal IDSchrank As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_F�cher_IDSchrank.Connection = conn.getConnDB
            Me.OleDbSelectCommand_F�cher_IDSchrank.CommandTimeout = 0
            Me.daF�cher_IDSchrank.SelectCommand = Me.OleDbSelectCommand_F�cher_IDSchrank
            Me.daF�cher_IDSchrank.SelectCommand.Parameters("IDSchrank").Value = IDSchrank
            Me.daF�cher_IDSchrank.Fill(data)
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
            Me.OleDbSelectCommand_F�cher_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_F�cher_ID.CommandTimeout = 0
            Me.daF�cher_ID.SelectCommand = Me.OleDbSelectCommand_F�cher_ID
            Me.daF�cher_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daF�cher_ID.Fill(data)
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
    Public Function F�cherSpeichern(ByRef dsF�cher As dsPlanArchive) As Boolean
        Try

            For Each r_fach As dsPlanArchive.tblFachRow In dsF�cher.tblFach
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
            Me.OleDbInsertCommand_F�cher_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_F�cher_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_F�cher_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbInsertCommand_F�cher_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbInsertCommand_F�cher_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbInsertCommand_F�cher_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbInsertCommand_F�cher_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbInsertCommand_F�cher_ID.Parameters("Extern").Value = r_fach.Extern

            Me.OleDbInsertCommand_F�cher_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateFach(ByVal r_fach As dsPlanArchive.tblFachRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_F�cher_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_F�cher_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_F�cher_ID.Parameters("ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("Bezeichnung").Value = r_fach.Bezeichnung
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("IDSchrank").Value = r_fach.IDSchrank
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("ErstelltAm").Value = r_fach.ErstelltAm
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("ErstelltVon").Value = r_fach.ErstelltVon
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("Original_ID").Value = r_fach.ID
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("Extern").Value = r_fach.Extern
            Me.OleDbUpdateCommand_F�cher_ID.Parameters("Original_ID").Value = r_fach.ID

            Me.OleDbUpdateCommand_F�cher_ID.ExecuteNonQuery()

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
    Public Function deleteF�cher(ByVal IDFach As System.Guid) As Boolean
        Try
            Dim conn As New db
            Me.OleDbDeleteCommand_F�cher_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_F�cher_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_F�cher_ID.Parameters("Original_ID").Value = IDFach
            Me.OleDbDeleteCommand_F�cher_ID.ExecuteNonQuery()
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
