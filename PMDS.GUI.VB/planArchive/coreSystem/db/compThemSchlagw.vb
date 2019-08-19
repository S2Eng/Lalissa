

Public Class compThemSchlagw
    Inherits System.ComponentModel.Component

    Private gen As New GeneralArchiv
    Dim db As New  db




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
    Friend WithEvents OleDbSelectCommand_Thema_All As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Thema_All As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Thema_All As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Thema_All As System.Data.OleDb.OleDbCommand
    Friend WithEvents conArchiv As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand_Schlagwort_IDThema As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schlagwort_IDThema As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schlagwort_IDThema As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Schlagwort_IDThema As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Thema_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Thema_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Thema_ID As System.Data.OleDb.OleDbCommand
    Public WithEvents daThema_All As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daSchlagwort_IDThema As System.Data.OleDb.OleDbDataAdapter
    Public WithEvents daThema_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents daSchlagwort_All As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schlagwort_All As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumenteneintrag_IDDokumenteneintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDokumenteneintragSchlagwörter_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_DokumenteneintragSchlagwörter_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_DokumenteneintragSchlagwörter_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand_Thema_ID As System.Data.OleDb.OleDbCommand
    Friend WithEvents daSchlagwort_ID As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schlagwort_ID As System.Data.OleDb.OleDbCommand
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.daThema_All = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Thema_All = New System.Data.OleDb.OleDbCommand
        Me.conArchiv = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCommand_Thema_All = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Thema_All = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Thema_All = New System.Data.OleDb.OleDbCommand
        Me.daSchlagwort_IDThema = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand
        Me.daThema_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Thema_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Thema_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Thema_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Thema_ID = New System.Data.OleDb.OleDbCommand
        Me.daSchlagwort_All = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand_Schlagwort_All = New System.Data.OleDb.OleDbCommand
        Me.daDokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand
        Me.daDokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand
        Me.daSchlagwort_ID = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbSelectCommand_Schlagwort_ID = New System.Data.OleDb.OleDbCommand
        '
        'daThema_All
        '
        Me.daThema_All.DeleteCommand = Me.OleDbDeleteCommand_Thema_All
        Me.daThema_All.InsertCommand = Me.OleDbInsertCommand_Thema_All
        Me.daThema_All.SelectCommand = Me.OleDbSelectCommand_Thema_All
        Me.daThema_All.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblThemen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Thema", "Thema"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        Me.daThema_All.UpdateCommand = Me.OleDbUpdateCommand_Thema_All
        '
        'OleDbDeleteCommand_Thema_All
        '
        Me.OleDbDeleteCommand_Thema_All.CommandText = "DELETE FROM tblThemen WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Thema_All.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "User ID=itscont;Tag with column collation when possible=False;Data Source=""s2sty0" & _
        "50\itscont"";Password=itscont;Initial Catalog=S2DokuManagment;Use Procedure for P" & _
        "repare=1;Auto Translate=True;Persist Security Info=True;Provider=""SQLOLEDB.1"";Wo" & _
        "rkstation ID=S2STY012;Use Encryption for Data=False;Packet Size=4096"
        '
        'OleDbInsertCommand_Thema_All
        '
        Me.OleDbInsertCommand_Thema_All.CommandText = "INSERT INTO tblThemen(ID, Thema, ErstelltAm, ErstelltVon) VALUES (?, ?, ?, ?)"
        Me.OleDbInsertCommand_Thema_All.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbInsertCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"))
        Me.OleDbInsertCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbInsertCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        '
        'OleDbSelectCommand_Thema_All
        '
        Me.OleDbSelectCommand_Thema_All.CommandText = "SELECT ID, Thema, ErstelltAm, ErstelltVon FROM tblThemen ORDER BY Thema"
        Me.OleDbSelectCommand_Thema_All.Connection = Me.conArchiv
        '
        'OleDbUpdateCommand_Thema_All
        '
        Me.OleDbUpdateCommand_Thema_All.CommandText = "UPDATE tblThemen SET ID = ?, Thema = ?, ErstelltAm = ?, ErstelltVon = ? WHERE (ID" & _
        " = ?)"
        Me.OleDbUpdateCommand_Thema_All.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbUpdateCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"))
        Me.OleDbUpdateCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbUpdateCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        Me.OleDbUpdateCommand_Thema_All.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daSchlagwort_IDThema
        '
        Me.daSchlagwort_IDThema.DeleteCommand = Me.OleDbDeleteCommand_Schlagwort_IDThema
        Me.daSchlagwort_IDThema.InsertCommand = Me.OleDbInsertCommand_Schlagwort_IDThema
        Me.daSchlagwort_IDThema.SelectCommand = Me.OleDbSelectCommand_Schlagwort_IDThema
        Me.daSchlagwort_IDThema.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDThema", "IDThema"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        Me.daSchlagwort_IDThema.UpdateCommand = Me.OleDbUpdateCommand_Schlagwort_IDThema
        '
        'OleDbDeleteCommand_Schlagwort_IDThema
        '
        Me.OleDbDeleteCommand_Schlagwort_IDThema.CommandText = "DELETE FROM tblSchlagwörter WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Schlagwort_IDThema.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand_Schlagwort_IDThema
        '
        Me.OleDbInsertCommand_Schlagwort_IDThema.CommandText = "INSERT INTO tblSchlagwörter(ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon) VAL" & _
        "UES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schlagwort_IDThema.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema"))
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 300, "Schlagwort"))
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        '
        'OleDbSelectCommand_Schlagwort_IDThema
        '
        Me.OleDbSelectCommand_Schlagwort_IDThema.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter WHER" & _
        "E (IDThema = ?) ORDER BY Schlagwort"
        Me.OleDbSelectCommand_Schlagwort_IDThema.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema"))
        '
        'OleDbUpdateCommand_Schlagwort_IDThema
        '
        Me.OleDbUpdateCommand_Schlagwort_IDThema.CommandText = "UPDATE tblSchlagwörter SET ID = ?, IDThema = ?, Schlagwort = ?, ErstelltAm = ?, E" & _
        "rstelltVon = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema"))
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 300, "Schlagwort"))
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daThema_ID
        '
        Me.daThema_ID.DeleteCommand = Me.OleDbDeleteCommand_Thema_ID
        Me.daThema_ID.InsertCommand = Me.OleDbInsertCommand_Thema_ID
        Me.daThema_ID.SelectCommand = Me.OleDbSelectCommand_Thema_ID
        Me.daThema_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblThemen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Thema", "Thema"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        Me.daThema_ID.UpdateCommand = Me.OleDbUpdateCommand_Thema_ID
        '
        'OleDbDeleteCommand_Thema_ID
        '
        Me.OleDbDeleteCommand_Thema_ID.CommandText = "DELETE FROM tblThemen WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Thema_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand_Thema_ID
        '
        Me.OleDbInsertCommand_Thema_ID.CommandText = "INSERT INTO tblThemen(ID, Thema, ErstelltAm, ErstelltVon) VALUES (?, ?, ?, ?)"
        Me.OleDbInsertCommand_Thema_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbInsertCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"))
        Me.OleDbInsertCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbInsertCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        '
        'OleDbSelectCommand_Thema_ID
        '
        Me.OleDbSelectCommand_Thema_ID.CommandText = "SELECT ID, Thema, ErstelltAm, ErstelltVon FROM tblThemen WHERE (ID = ?)"
        Me.OleDbSelectCommand_Thema_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        '
        'OleDbUpdateCommand_Thema_ID
        '
        Me.OleDbUpdateCommand_Thema_ID.CommandText = "UPDATE tblThemen SET ID = ?, Thema = ?, ErstelltAm = ?, ErstelltVon = ? WHERE (ID" & _
        " = ?)"
        Me.OleDbUpdateCommand_Thema_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbUpdateCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"))
        Me.OleDbUpdateCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ErstelltAm"))
        Me.OleDbUpdateCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"))
        Me.OleDbUpdateCommand_Thema_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daSchlagwort_All
        '
        Me.daSchlagwort_All.SelectCommand = Me.OleDbSelectCommand_Schlagwort_All
        Me.daSchlagwort_All.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDThema", "IDThema"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        '
        'OleDbSelectCommand_Schlagwort_All
        '
        Me.OleDbSelectCommand_Schlagwort_All.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter ORDE" & _
        "R BY Schlagwort"
        Me.OleDbSelectCommand_Schlagwort_All.Connection = Me.conArchiv
        '
        'daDokumenteneintrag_IDDokumenteneintrag
        '
        Me.daDokumenteneintrag_IDDokumenteneintrag.DeleteCommand = Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag
        Me.daDokumenteneintrag_IDDokumenteneintrag.InsertCommand = Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag
        Me.daDokumenteneintrag_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag
        Me.daDokumenteneintrag_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumenteneintragSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDSchlagwort", "IDSchlagwort"), New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag")})})
        Me.daDokumenteneintrag_IDDokumenteneintrag.UpdateCommand = Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        'OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "DELETE FROM tblDokumenteneintragSchlagwörter WHERE (ID = ?)"
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "INSERT INTO tblDokumenteneintragSchlagwörter(ID, IDSchlagwort, IDDokumenteneintra" & _
        "g) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = Me.conArchiv
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"))
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        '
        'OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "SELECT ID, IDSchlagwort, IDDokumenteneintrag FROM tblDokumenteneintragSchlagwörte" & _
        "r WHERE (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        '
        'OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "UPDATE tblDokumenteneintragSchlagwörter SET ID = ?, IDSchlagwort = ?, IDDokumente" & _
        "neintrag = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"))
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daDokumenteneintragSchlagwörter_ID
        '
        Me.daDokumenteneintragSchlagwörter_ID.DeleteCommand = Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID
        Me.daDokumenteneintragSchlagwörter_ID.InsertCommand = Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID
        Me.daDokumenteneintragSchlagwörter_ID.SelectCommand = Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID
        Me.daDokumenteneintragSchlagwörter_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumenteneintragSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDSchlagwort", "IDSchlagwort"), New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag")})})
        Me.daDokumenteneintragSchlagwörter_ID.UpdateCommand = Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID
        '
        'OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID.CommandText = "DELETE FROM tblDokumenteneintragSchlagwörter WHERE (ID = ?)"
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID.Connection = Me.conArchiv
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.CommandText = "INSERT INTO tblDokumenteneintragSchlagwörter(ID, IDSchlagwort, IDDokumenteneintra" & _
        "g) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Connection = Me.conArchiv
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"))
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        '
        'OleDbSelectCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.CommandText = "SELECT ID, IDSchlagwort, IDDokumenteneintrag FROM tblDokumenteneintragSchlagwörte" & _
        "r WHERE (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        '
        'OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.CommandText = "UPDATE tblDokumenteneintragSchlagwörter SET ID = ?, IDSchlagwort = ?, IDDokumente" & _
        "neintrag = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Connection = Me.conArchiv
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"))
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"))
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing))
        '
        'daSchlagwort_ID
        '
        Me.daSchlagwort_ID.SelectCommand = Me.OleDbSelectCommand_Schlagwort_ID
        Me.daSchlagwort_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDThema", "IDThema"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        '
        'OleDbSelectCommand_Schlagwort_ID
        '
        Me.OleDbSelectCommand_Schlagwort_ID.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter WHER" & _
        "E (ID = ?)"
        Me.OleDbSelectCommand_Schlagwort_ID.Connection = Me.conArchiv
        Me.OleDbSelectCommand_Schlagwort_ID.Parameters.Add(New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"))

    End Sub

#End Region




    Public Function LesenAllerThemenUndSchlagwörter() As dsPlanArchive
        Try
            Dim data As New dsPlanArchive
            Dim UIElements1 As New UIElements()
            Dim lstTablesNotDelete As New System.Collections.Generic.List(Of String)()
            lstTablesNotDelete.Add(data.tblThemen.TableName.Trim())
            lstTablesNotDelete.Add(data.tblSchlagwörter.TableName.Trim())
            UIElements1.deleteTablesFromDataSet(data, lstTablesNotDelete)

            Dim conn As New db
            Me.OleDbSelectCommand_Thema_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_All.CommandTimeout = 0
            Me.daThema_All.SelectCommand = Me.OleDbSelectCommand_Thema_All
            Me.daThema_All.Fill(data.tblThemen)

            Me.OleDbSelectCommand_Schlagwort_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_All.CommandTimeout = 0
            Me.daSchlagwort_All.SelectCommand = Me.OleDbSelectCommand_Schlagwort_All
            Me.daSchlagwort_All.Fill(data.tblSchlagwörter)

            Dim view As New DataView
            Dim rel_thema As New DataRelation("RelAufgabenArt", data.tblThemen.Columns("ID"), data.tblSchlagwörter.Columns("IDThema"))
            data.Relations.Add(rel_thema)

            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function LesenAllerThemen() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Thema_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_All.CommandTimeout = 0
            Me.daThema_All.SelectCommand = Me.OleDbSelectCommand_Thema_All
            Me.daThema_All.Fill(data.tblThemen)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function ExistiertThema(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New  db
            Me.OleDbSelectCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Thema_ID.CommandTimeout = 0
            Me.daThema_ID.SelectCommand = Me.OleDbSelectCommand_Thema_ID
            Me.daThema_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daThema_ID.Fill(data)
            If data.tblThemen.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function LesenAlleSchlagwörter(ByVal IDThema As System.Guid) As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_IDThema.CommandTimeout = 0
            Me.daSchlagwort_IDThema.SelectCommand = Me.OleDbSelectCommand_Schlagwort_IDThema
            Me.daSchlagwort_IDThema.SelectCommand.Parameters("IDThema").Value = IDThema
            Me.daSchlagwort_IDThema.Fill(data.tblSchlagwörter)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function LesenAllerSchlagwörter() As dsPlanArchive
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schlagwort_All.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_All.CommandTimeout = 0
            Me.daSchlagwort_All.SelectCommand = Me.OleDbSelectCommand_Schlagwort_All
            Me.daSchlagwort_All.Fill(data.tblSchlagwörter)
            Return data

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function ThemaSpeichern(ByRef dsThema As dsPlanArchive) As Boolean
        Try

            For Each r_thema As dsPlanArchive.tblThemenRow In dsThema.tblThemen
                If Not Me.ExistiertThema(r_thema.ID) Then
                    Me.insertThema(r_thema)
                Else
                    Me.updateThema(r_thema)
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertThema(ByVal r_thema As dsPlanArchive.tblThemenRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_Thema_ID.Parameters("ID").Value = r_thema.ID
            Me.OleDbInsertCommand_Thema_ID.Parameters("Thema").Value = r_thema.Thema
            Me.OleDbInsertCommand_Thema_ID.Parameters("ErstelltAm").Value = r_thema.ErstelltAm
            Me.OleDbInsertCommand_Thema_ID.Parameters("ErstelltVon").Value = r_thema.ErstelltVon

            Me.OleDbInsertCommand_Thema_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateThema(ByVal r_thema As dsPlanArchive.tblThemenRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_Thema_ID.Parameters("ID").Value = r_thema.ID
            Me.OleDbUpdateCommand_Thema_ID.Parameters("Thema").Value = r_thema.Thema
            Me.OleDbUpdateCommand_Thema_ID.Parameters("ErstelltAm").Value = r_thema.ErstelltAm
            Me.OleDbUpdateCommand_Thema_ID.Parameters("ErstelltVon").Value = r_thema.ErstelltVon
            Me.OleDbUpdateCommand_Thema_ID.Parameters("Original_ID").Value = r_thema.ID

            Me.OleDbUpdateCommand_Thema_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function ExistiertSchlagwort(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New db
            Me.OleDbSelectCommand_Schlagwort_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_Schlagwort_ID.CommandTimeout = 0
            Me.daSchlagwort_ID.SelectCommand = Me.OleDbSelectCommand_Schlagwort_ID
            Me.daSchlagwort_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daSchlagwort_ID.Fill(data)
            If data.tblSchlagwörter.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function SchlagwörterSpeichern(ByRef dsSchlagwörter As dsPlanArchive) As Boolean
        Try

            For Each r_schlagwort As dsPlanArchive.tblSchlagwörterRow In dsSchlagwörter.tblSchlagwörter
                If Not Me.ExistiertSchlagwort(r_schlagwort.ID) Then
                    Me.insertSchlagwörter(r_schlagwort)
                Else
                    Me.updateSchlagwörter(r_schlagwort)
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub insertSchlagwörter(ByVal r_schlagwort As dsPlanArchive.tblSchlagwörterRow)
        Try
            Dim conn As New db
            Me.OleDbInsertCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbInsertCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ID").Value = r_schlagwort.ID
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("IDThema").Value = r_schlagwort.IDThema
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("Schlagwort").Value = r_schlagwort.Schlagwort
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ErstelltAm").Value = r_schlagwort.ErstelltAm
            Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters("ErstelltVon").Value = r_schlagwort.ErstelltVon

            Me.OleDbInsertCommand_Schlagwort_IDThema.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Public Sub updateSchlagwörter(ByVal r_schlagwort As dsPlanArchive.tblSchlagwörterRow)
        Try
            Dim conn As New db
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbUpdateCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ID").Value = r_schlagwort.ID
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("IDThema").Value = r_schlagwort.IDThema
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("Schlagwort").Value = r_schlagwort.Schlagwort
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ErstelltAm").Value = r_schlagwort.ErstelltAm
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("ErstelltVon").Value = r_schlagwort.ErstelltVon
            Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters("Original_ID").Value = r_schlagwort.ID

            Me.OleDbUpdateCommand_Schlagwort_IDThema.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function writeDokumenteneintragSchlagwörter(ByVal r As dsPlanArchive.tblDokumenteneintragSchlagwörterRow) As Boolean
        Try

            Me.insertDokumenteneintragSchlagwörter(r)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function

    Public Function insertDokumenteneintragSchlagwörter(ByVal r As dsPlanArchive.tblDokumenteneintragSchlagwörterRow)
        Try

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Connection = db.getConnDB
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.CommandTimeout = 0

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("ID").Value = r.ID
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDSchlagwort").Value = r.IDSchlagwort
            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDDokumenteneintrag").Value = r.IDDokumenteneintrag

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function updateDokumenteneintragSchlagwörter(ByVal r As dsPlanArchive.tblDokumenteneintragSchlagwörterRow)
        Try

            Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Connection = db.getConnDB
            Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.CommandTimeout = 0

            Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDSchlagwort").Value = r.IDSchlagwort
            Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters("IDDokumenteneintrag").Value = r.IDDokumenteneintrag
            Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters("Original_ID").Value = r.ID

            Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function ExistiertDokumenteneintragSchlagwörter(ByVal ID As System.Guid) As Boolean
        Try

            Dim data As New dsPlanArchive
            Dim conn As New  db
            Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.Connection = conn.getConnDB
            Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.CommandTimeout = 0
            Me.daDokumenteneintragSchlagwörter_ID.SelectCommand = Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID
            Me.daDokumenteneintragSchlagwörter_ID.SelectCommand.Parameters("ID").Value = ID
            Me.daDokumenteneintragSchlagwörter_ID.Fill(data)
            If data.tblDokumenteneintragSchlagwörter.Rows.Count = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Sub deleteDokumenteneintragSchlagwörter(ByVal IDDokumenteneintrag As System.Guid)
        Try
            Dim conn As New  db

            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandTimeout = 0
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters("Original_ID").Value = IDDokumenteneintrag
            Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.ExecuteNonQuery()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Public Function deleteThema(ByVal IDThema As System.Guid) As Boolean
        Try
            Dim conn As New  db
            Me.OleDbDeleteCommand_Thema_ID.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Thema_ID.CommandTimeout = 0

            Me.OleDbDeleteCommand_Thema_ID.Parameters("Original_ID").Value = IDThema
            Me.OleDbDeleteCommand_Thema_ID.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function
    Public Function deleteSchlagwort(ByVal IDSchlagwort As System.Guid) As Boolean
        Try
            Dim conn As New  db
            Me.OleDbDeleteCommand_Schlagwort_IDThema.Connection = conn.getConnDB
            Me.OleDbDeleteCommand_Schlagwort_IDThema.CommandTimeout = 0

            Me.OleDbDeleteCommand_Schlagwort_IDThema.Parameters("Original_ID").Value = IDSchlagwort
            Me.OleDbDeleteCommand_Schlagwort_IDThema.ExecuteNonQuery()
            Return True

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Function



End Class
