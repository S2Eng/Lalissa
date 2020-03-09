Partial Class compDoku
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        Me.sqldaDoku = Me.daDoku.SelectCommand.CommandText
        Me.sqldaObject = Me.daDocuObject.SelectCommand.CommandText
        Me.sqldaOrdner = Me.daOrdner.SelectCommand.CommandText
        Me.sqldaDokuSchlagw = Me.daDokuSchlag.SelectCommand.CommandText
    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Komponenten-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Komponenten-Designer erforderlich.
    'Das Bearbeiten ist mit dem Komponenten-Designer möglich.
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compDoku))
        Me.daDoku = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.conArchiv = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.daDocuObject = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        Me.daOrdner = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        Me.daDokuSchlag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand13 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand14 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand15 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand16 = New System.Data.OleDb.OleDbCommand()
        Me.daSearchDokus = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand20 = New System.Data.OleDb.OleDbCommand()
        '
        'daDoku
        '
        Me.daDoku.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daDoku.InsertCommand = Me.OleDbInsertCommand1
        Me.daDoku.SelectCommand = Me.OleDbSelectCommand1
        Me.daDoku.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "archDoku", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("Größe", "Größe"), New System.Data.Common.DataColumnMapping("AbgelegtVon", "AbgelegtVon"), New System.Data.Common.DataColumnMapping("AbgelegtAm", "AbgelegtAm"), New System.Data.Common.DataColumnMapping("Winzip", "Winzip"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("doku", "doku"), New System.Data.Common.DataColumnMapping("dokuOrig", "dokuOrig"), New System.Data.Common.DataColumnMapping("RechNr", "RechNr"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("intReleased", "intReleased"), New System.Data.Common.DataColumnMapping("binIntern", "binIntern")})})
        Me.daDoku.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [archDoku] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.conArchiv
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'conArchiv
        '
        Me.conArchiv.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=ITSContDev"
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.conArchiv
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 16, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 16, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("Größe", System.Data.OleDb.OleDbType.[Double], 0, "Größe"), New System.Data.OleDb.OleDbParameter("AbgelegtVon", System.Data.OleDb.OleDbType.VarChar, 0, "AbgelegtVon"), New System.Data.OleDb.OleDbParameter("AbgelegtAm", System.Data.OleDb.OleDbType.Date, 16, "AbgelegtAm"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 0, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 0, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 0, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 0, "DateinameTyp"), New System.Data.OleDb.OleDbParameter("doku", System.Data.OleDb.OleDbType.LongVarBinary, 0, "doku"), New System.Data.OleDb.OleDbParameter("dokuOrig", System.Data.OleDb.OleDbType.VarChar, 0, "dokuOrig"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("IDActivity", System.Data.OleDb.OleDbType.Guid, 0, "IDActivity"), New System.Data.OleDb.OleDbParameter("db", System.Data.OleDb.OleDbType.LongVarBinary, 0, "db"), New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 0, "IDStatus"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.VarChar, 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("intReleased", System.Data.OleDb.OleDbType.[Boolean], 0, "intReleased"), New System.Data.OleDb.OleDbParameter("binIntern", System.Data.OleDb.OleDbType.LongVarBinary, 0, "binIntern")})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = resources.GetString("OleDbSelectCommand1.CommandText")
        Me.OleDbSelectCommand1.Connection = Me.conArchiv
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = resources.GetString("OleDbUpdateCommand1.CommandText")
        Me.OleDbUpdateCommand1.Connection = Me.conArchiv
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 16, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 16, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("Größe", System.Data.OleDb.OleDbType.[Double], 0, "Größe"), New System.Data.OleDb.OleDbParameter("AbgelegtVon", System.Data.OleDb.OleDbType.VarChar, 0, "AbgelegtVon"), New System.Data.OleDb.OleDbParameter("AbgelegtAm", System.Data.OleDb.OleDbType.Date, 16, "AbgelegtAm"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 0, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 0, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 0, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 0, "DateinameTyp"), New System.Data.OleDb.OleDbParameter("doku", System.Data.OleDb.OleDbType.LongVarBinary, 0, "doku"), New System.Data.OleDb.OleDbParameter("dokuOrig", System.Data.OleDb.OleDbType.VarChar, 0, "dokuOrig"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("IDActivity", System.Data.OleDb.OleDbType.Guid, 0, "IDActivity"), New System.Data.OleDb.OleDbParameter("db", System.Data.OleDb.OleDbType.LongVarBinary, 0, "db"), New System.Data.OleDb.OleDbParameter("IDStatus", System.Data.OleDb.OleDbType.VarChar, 0, "IDStatus"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.VarChar, 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("intReleased", System.Data.OleDb.OleDbType.[Boolean], 0, "intReleased"), New System.Data.OleDb.OleDbParameter("binIntern", System.Data.OleDb.OleDbType.LongVarBinary, 0, "binIntern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daDocuObject
        '
        Me.daDocuObject.DeleteCommand = Me.OleDbCommand1
        Me.daDocuObject.InsertCommand = Me.OleDbCommand2
        Me.daDocuObject.SelectCommand = Me.OleDbCommand3
        Me.daDocuObject.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "archObject", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDoku", "IDDoku"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDSelList", "IDSelList")})})
        Me.daDocuObject.UpdateCommand = Me.OleDbCommand4
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "DELETE FROM [archObject] WHERE (([ID] = ?))"
        Me.OleDbCommand1.Connection = Me.conArchiv
        Me.OleDbCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = "INSERT INTO [archObject] ([ID], [IDDoku], [IDObject], [IDSelList]) VALUES (?, ?, " &
    "?, ?)"
        Me.OleDbCommand2.Connection = Me.conArchiv
        Me.OleDbCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 0, "IDDoku"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDSelList", System.Data.OleDb.OleDbType.Guid, 0, "IDSelList")})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = "SELECT        ID, IDDoku, IDObject, IDSelList" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            archObject"
        Me.OleDbCommand3.Connection = Me.conArchiv
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = "UPDATE [archObject] SET [ID] = ?, [IDDoku] = ?, [IDObject] = ?, [IDSelList] = ? W" &
    "HERE (([ID] = ?))"
        Me.OleDbCommand4.Connection = Me.conArchiv
        Me.OleDbCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 0, "IDDoku"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDSelList", System.Data.OleDb.OleDbType.Guid, 0, "IDSelList"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daOrdner
        '
        Me.daOrdner.DeleteCommand = Me.OleDbCommand5
        Me.daOrdner.InsertCommand = Me.OleDbCommand6
        Me.daOrdner.SelectCommand = Me.OleDbCommand7
        Me.daOrdner.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "archOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Extern", "Extern"), New System.Data.Common.DataColumnMapping("IDOrdnerMain", "IDOrdnerMain"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Icon", "Icon"), New System.Data.Common.DataColumnMapping("IDSystemordner", "IDSystemordner")})})
        Me.daOrdner.UpdateCommand = Me.OleDbCommand8
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = "DELETE FROM [archOrdner] WHERE (([ID] = ?))"
        Me.OleDbCommand5.Connection = Me.conArchiv
        Me.OleDbCommand5.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = "INSERT INTO [archOrdner] ([ID], [Bezeichnung], [Extern], [IDOrdnerMain], [Erstell" &
    "tAm], [ErstelltVon], [Icon], [IDSystemordner]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbCommand6.Connection = Me.conArchiv
        Me.OleDbCommand6.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDOrdnerMain", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdnerMain"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner")})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = "SELECT        ID, Bezeichnung, Extern, IDOrdnerMain, ErstelltAm, ErstelltVon, Ico" &
    "n, IDSystemordner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            archOrdner"
        Me.OleDbCommand7.Connection = Me.conArchiv
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = "UPDATE [archOrdner] SET [ID] = ?, [Bezeichnung] = ?, [Extern] = ?, [IDOrdnerMain]" &
    " = ?, [ErstelltAm] = ?, [ErstelltVon] = ?, [Icon] = ?, [IDSystemordner] = ? WHER" &
    "E (([ID] = ?))"
        Me.OleDbCommand8.Connection = Me.conArchiv
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDOrdnerMain", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdnerMain"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daDokuSchlag
        '
        Me.daDokuSchlag.DeleteCommand = Me.OleDbCommand13
        Me.daDokuSchlag.InsertCommand = Me.OleDbCommand14
        Me.daDokuSchlag.SelectCommand = Me.OleDbCommand15
        Me.daDokuSchlag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "archDokuSchlag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDoku", "IDDoku"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort")})})
        Me.daDokuSchlag.UpdateCommand = Me.OleDbCommand16
        '
        'OleDbCommand13
        '
        Me.OleDbCommand13.CommandText = "DELETE FROM [archDokuSchlag] WHERE (([ID] = ?))"
        Me.OleDbCommand13.Connection = Me.conArchiv
        Me.OleDbCommand13.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand14
        '
        Me.OleDbCommand14.CommandText = "INSERT INTO [archDokuSchlag] ([ID], [IDDoku], [Schlagwort]) VALUES (?, ?, ?)"
        Me.OleDbCommand14.Connection = Me.conArchiv
        Me.OleDbCommand14.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 0, "IDDoku"), New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 0, "Schlagwort")})
        '
        'OleDbCommand15
        '
        Me.OleDbCommand15.CommandText = "SELECT        ID, IDDoku, Schlagwort" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            archDokuSchlag"
        Me.OleDbCommand15.Connection = Me.conArchiv
        '
        'OleDbCommand16
        '
        Me.OleDbCommand16.CommandText = "UPDATE [archDokuSchlag] SET [ID] = ?, [IDDoku] = ?, [Schlagwort] = ? WHERE (([ID]" &
    " = ?))"
        Me.OleDbCommand16.Connection = Me.conArchiv
        Me.OleDbCommand16.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDoku", System.Data.OleDb.OleDbType.Guid, 0, "IDDoku"), New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 0, "Schlagwort"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSearchDokus
        '
        Me.daSearchDokus.SelectCommand = Me.OleDbCommand20
        Me.daSearchDokus.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "archDoku", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("Größe", "Größe"), New System.Data.Common.DataColumnMapping("AbgelegtVon", "AbgelegtVon"), New System.Data.Common.DataColumnMapping("AbgelegtAm", "AbgelegtAm"), New System.Data.Common.DataColumnMapping("Winzip", "Winzip"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("Ordner", "Ordner"), New System.Data.Common.DataColumnMapping("OrdnerExtern", "OrdnerExtern"), New System.Data.Common.DataColumnMapping("IDSystemordner", "IDSystemordner"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("IDDoku", "IDDoku"), New System.Data.Common.DataColumnMapping("dokuOrig", "dokuOrig"), New System.Data.Common.DataColumnMapping("RechNr", "RechNr"), New System.Data.Common.DataColumnMapping("IDActivity", "IDActivity"), New System.Data.Common.DataColumnMapping("db", "db"), New System.Data.Common.DataColumnMapping("IDStatus", "IDStatus"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("anzObject", "anzObject"), New System.Data.Common.DataColumnMapping("intReleased", "intReleased"), New System.Data.Common.DataColumnMapping("binIntern", "binIntern")})})
        '
        'OleDbCommand20
        '
        Me.OleDbCommand20.CommandText = resources.GetString("OleDbCommand20.CommandText")
        Me.OleDbCommand20.Connection = Me.conArchiv

    End Sub

    Public WithEvents daDoku As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand1 As OleDb.OleDbCommand
    Friend WithEvents conArchiv As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As OleDb.OleDbCommand
    Public WithEvents daDocuObject As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand4 As OleDb.OleDbCommand
    Public WithEvents daOrdner As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand5 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand6 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand7 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand8 As OleDb.OleDbCommand
    Public WithEvents daDokuSchlag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand13 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand14 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand15 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand16 As OleDb.OleDbCommand
    Public WithEvents daSearchDokus As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand20 As OleDb.OleDbCommand
End Class
