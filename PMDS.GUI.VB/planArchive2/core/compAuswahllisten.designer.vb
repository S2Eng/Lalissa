Partial Class compAuswahllisten
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

        Me.daSelAuswahllisteGruppe = Me.daAuswahllisteGruppe.SelectCommand.CommandText
        Me.daSelAuswahllisten = Me.daAuswahllisten.SelectCommand.CommandText
        Me.daSelAuswahlListObj = Me.daAuswahllistenObj.SelectCommand.CommandText
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compAuswahllisten))
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.daAuswahllisten = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.daAuswahllisteGruppe = New System.Data.OleDb.OleDbDataAdapter()
        Me.daAuswahllistenObj = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=ITSContDev"
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [Auswahllisten] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.dbConn
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = resources.GetString("OleDbUpdateCommand1.CommandText")
        Me.OleDbUpdateCommand1.Connection = Me.dbConn
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDGruppe"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDNr", System.Data.OleDb.OleDbType.VarChar, 0, "IDNr"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("Klassifizierung", System.Data.OleDb.OleDbType.VarChar, 0, "Klassifizierung"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.VarChar, 0, "Extern"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Kennung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kennung"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.[Integer], 0, "Sort"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = resources.GetString("OleDbInsertCommand1.CommandText")
        Me.OleDbInsertCommand1.Connection = Me.dbConn
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDGruppe"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDNr", System.Data.OleDb.OleDbType.VarChar, 0, "IDNr"), New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.VarChar, 0, "typ"), New System.Data.OleDb.OleDbParameter("Klassifizierung", System.Data.OleDb.OleDbType.VarChar, 0, "Klassifizierung"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.VarChar, 0, "Extern"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Kennung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kennung"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.[Integer], 0, "Sort"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung")})
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT        ID, IDGruppe, Bezeichnung, IDNr, typ, Klassifizierung, Extern, Erst" &
    "elltAm, ErstelltVon, Kennung, Sort, Beschreibung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Auswahllisten"
        Me.OleDbSelectCommand1.Connection = Me.dbConn
        '
        'daAuswahllisten
        '
        Me.daAuswahllisten.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daAuswahllisten.InsertCommand = Me.OleDbInsertCommand1
        Me.daAuswahllisten.SelectCommand = Me.OleDbSelectCommand1
        Me.daAuswahllisten.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Auswahllisten", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDNr", "IDNr"), New System.Data.Common.DataColumnMapping("typ", "typ"), New System.Data.Common.DataColumnMapping("Klassifizierung", "Klassifizierung"), New System.Data.Common.DataColumnMapping("Extern", "Extern"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Kennung", "Kennung"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung")})})
        Me.daAuswahllisten.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbDeleteCommand
        '
        Me.OleDbDeleteCommand.CommandText = "DELETE FROM [AuswahllisteGruppe] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand.Connection = Me.dbConn
        Me.OleDbDeleteCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbUpdateCommand
        '
        Me.OleDbUpdateCommand.CommandText = "UPDATE [AuswahllisteGruppe] SET [ID] = ?, [gruppe] = ?, [sys] = ?, [Sublist] = ?," &
    " [KeyCol] = ?, [Sort] = ? WHERE (([ID] = ?))"
        Me.OleDbUpdateCommand.Connection = Me.dbConn
        Me.OleDbUpdateCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "gruppe"), New System.Data.OleDb.OleDbParameter("sys", System.Data.OleDb.OleDbType.[Boolean], 0, "sys"), New System.Data.OleDb.OleDbParameter("Sublist", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sublist"), New System.Data.OleDb.OleDbParameter("KeyCol", System.Data.OleDb.OleDbType.VarChar, 0, "KeyCol"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.VarChar, 0, "Sort"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand
        '
        Me.OleDbInsertCommand.CommandText = "INSERT INTO [AuswahllisteGruppe] ([ID], [gruppe], [sys], [Sublist], [KeyCol], [So" &
    "rt]) VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand.Connection = Me.dbConn
        Me.OleDbInsertCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "gruppe"), New System.Data.OleDb.OleDbParameter("sys", System.Data.OleDb.OleDbType.[Boolean], 0, "sys"), New System.Data.OleDb.OleDbParameter("Sublist", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sublist"), New System.Data.OleDb.OleDbParameter("KeyCol", System.Data.OleDb.OleDbType.VarChar, 0, "KeyCol"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.VarChar, 0, "Sort")})
        '
        'OleDbSelectCommand3
        '
        Me.OleDbSelectCommand3.CommandText = "SELECT        ID, gruppe, sys, Sublist, KeyCol, Sort" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Auswahllist" &
    "eGruppe"
        Me.OleDbSelectCommand3.Connection = Me.dbConn
        '
        'daAuswahllisteGruppe
        '
        Me.daAuswahllisteGruppe.DeleteCommand = Me.OleDbDeleteCommand
        Me.daAuswahllisteGruppe.InsertCommand = Me.OleDbInsertCommand
        Me.daAuswahllisteGruppe.SelectCommand = Me.OleDbSelectCommand3
        Me.daAuswahllisteGruppe.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AuswahllisteGruppe", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("gruppe", "gruppe"), New System.Data.Common.DataColumnMapping("sys", "sys"), New System.Data.Common.DataColumnMapping("Sublist", "Sublist"), New System.Data.Common.DataColumnMapping("KeyCol", "KeyCol"), New System.Data.Common.DataColumnMapping("Sort", "Sort")})})
        Me.daAuswahllisteGruppe.UpdateCommand = Me.OleDbUpdateCommand
        '
        'daAuswahllistenObj
        '
        Me.daAuswahllistenObj.DeleteCommand = Me.OleDbCommand1
        Me.daAuswahllistenObj.InsertCommand = Me.OleDbCommand2
        Me.daAuswahllistenObj.SelectCommand = Me.OleDbCommand3
        Me.daAuswahllistenObj.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AuswahllistenObj", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAuswahl", "IDAuswahl"), New System.Data.Common.DataColumnMapping("AuswahlTxt", "AuswahlTxt"), New System.Data.Common.DataColumnMapping("AuswahlGruppeID", "AuswahlGruppeID"), New System.Data.Common.DataColumnMapping("Von", "Von"), New System.Data.Common.DataColumnMapping("Bis", "Bis"), New System.Data.Common.DataColumnMapping("IDObject", "IDObject"), New System.Data.Common.DataColumnMapping("IDObjectTxt", "IDObjectTxt"), New System.Data.Common.DataColumnMapping("IDAuswahlSub", "IDAuswahlSub"), New System.Data.Common.DataColumnMapping("IDProduct", "IDProduct"), New System.Data.Common.DataColumnMapping("IDSchema", "IDSchema"), New System.Data.Common.DataColumnMapping("IDSatz", "IDSatz"), New System.Data.Common.DataColumnMapping("SubGruppeID", "SubGruppeID"), New System.Data.Common.DataColumnMapping("Typ", "Typ"), New System.Data.Common.DataColumnMapping("IDClassification", "IDClassification"), New System.Data.Common.DataColumnMapping("IDVersicherung", "IDVersicherung"), New System.Data.Common.DataColumnMapping("Sort", "Sort"), New System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Zahlweise", "Zahlweise"), New System.Data.Common.DataColumnMapping("Kalender", "Kalender"), New System.Data.Common.DataColumnMapping("ProvZahlNachschüssig", "ProvZahlNachschüssig"), New System.Data.Common.DataColumnMapping("ProvType", "ProvType"), New System.Data.Common.DataColumnMapping("ProvVerzicht", "ProvVerzicht"), New System.Data.Common.DataColumnMapping("IsActive", "IsActive"), New System.Data.Common.DataColumnMapping("IsHistory", "IsHistory")})})
        Me.daAuswahllistenObj.UpdateCommand = Me.OleDbCommand4
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "DELETE FROM [AuswahllistenObj] WHERE (([ID] = ?))"
        Me.OleDbCommand1.Connection = Me.dbConn
        Me.OleDbCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = resources.GetString("OleDbCommand2.CommandText")
        Me.OleDbCommand2.Connection = Me.dbConn
        Me.OleDbCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAuswahl", System.Data.OleDb.OleDbType.Guid, 0, "IDAuswahl"), New System.Data.OleDb.OleDbParameter("AuswahlTxt", System.Data.OleDb.OleDbType.VarChar, 0, "AuswahlTxt"), New System.Data.OleDb.OleDbParameter("AuswahlGruppeID", System.Data.OleDb.OleDbType.VarChar, 0, "AuswahlGruppeID"), New System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"), New System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDObjectTxt", System.Data.OleDb.OleDbType.VarChar, 0, "IDObjectTxt"), New System.Data.OleDb.OleDbParameter("IDAuswahlSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAuswahlSub"), New System.Data.OleDb.OleDbParameter("IDProduct", System.Data.OleDb.OleDbType.Guid, 0, "IDProduct"), New System.Data.OleDb.OleDbParameter("IDSchema", System.Data.OleDb.OleDbType.Guid, 0, "IDSchema"), New System.Data.OleDb.OleDbParameter("IDSatz", System.Data.OleDb.OleDbType.Guid, 0, "IDSatz"), New System.Data.OleDb.OleDbParameter("SubGruppeID", System.Data.OleDb.OleDbType.VarChar, 0, "SubGruppeID"), New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"), New System.Data.OleDb.OleDbParameter("IDClassification", System.Data.OleDb.OleDbType.VarChar, 0, "IDClassification"), New System.Data.OleDb.OleDbParameter("IDVersicherung", System.Data.OleDb.OleDbType.Guid, 0, "IDVersicherung"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.[Integer], 0, "Sort"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Zahlweise", System.Data.OleDb.OleDbType.[Integer], 0, "Zahlweise"), New System.Data.OleDb.OleDbParameter("Kalender", System.Data.OleDb.OleDbType.[Boolean], 0, "Kalender"), New System.Data.OleDb.OleDbParameter("ProvZahlNachschüssig", System.Data.OleDb.OleDbType.[Boolean], 0, "ProvZahlNachschüssig"), New System.Data.OleDb.OleDbParameter("ProvType", System.Data.OleDb.OleDbType.VarChar, 0, "ProvType"), New System.Data.OleDb.OleDbParameter("ProvVerzicht", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(6, Byte), "ProvVerzicht", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.[Boolean], 0, "IsActive"), New System.Data.OleDb.OleDbParameter("IsHistory", System.Data.OleDb.OleDbType.[Boolean], 0, "IsHistory")})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = resources.GetString("OleDbCommand3.CommandText")
        Me.OleDbCommand3.Connection = Me.dbConn
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = resources.GetString("OleDbCommand4.CommandText")
        Me.OleDbCommand4.Connection = Me.dbConn
        Me.OleDbCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAuswahl", System.Data.OleDb.OleDbType.Guid, 0, "IDAuswahl"), New System.Data.OleDb.OleDbParameter("AuswahlTxt", System.Data.OleDb.OleDbType.VarChar, 0, "AuswahlTxt"), New System.Data.OleDb.OleDbParameter("AuswahlGruppeID", System.Data.OleDb.OleDbType.VarChar, 0, "AuswahlGruppeID"), New System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"), New System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"), New System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"), New System.Data.OleDb.OleDbParameter("IDObjectTxt", System.Data.OleDb.OleDbType.VarChar, 0, "IDObjectTxt"), New System.Data.OleDb.OleDbParameter("IDAuswahlSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAuswahlSub"), New System.Data.OleDb.OleDbParameter("IDProduct", System.Data.OleDb.OleDbType.Guid, 0, "IDProduct"), New System.Data.OleDb.OleDbParameter("IDSchema", System.Data.OleDb.OleDbType.Guid, 0, "IDSchema"), New System.Data.OleDb.OleDbParameter("IDSatz", System.Data.OleDb.OleDbType.Guid, 0, "IDSatz"), New System.Data.OleDb.OleDbParameter("SubGruppeID", System.Data.OleDb.OleDbType.VarChar, 0, "SubGruppeID"), New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.VarChar, 0, "Typ"), New System.Data.OleDb.OleDbParameter("IDClassification", System.Data.OleDb.OleDbType.VarChar, 0, "IDClassification"), New System.Data.OleDb.OleDbParameter("IDVersicherung", System.Data.OleDb.OleDbType.Guid, 0, "IDVersicherung"), New System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.[Integer], 0, "Sort"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Zahlweise", System.Data.OleDb.OleDbType.[Integer], 0, "Zahlweise"), New System.Data.OleDb.OleDbParameter("Kalender", System.Data.OleDb.OleDbType.[Boolean], 0, "Kalender"), New System.Data.OleDb.OleDbParameter("ProvZahlNachschüssig", System.Data.OleDb.OleDbType.[Boolean], 0, "ProvZahlNachschüssig"), New System.Data.OleDb.OleDbParameter("ProvType", System.Data.OleDb.OleDbType.VarChar, 0, "ProvType"), New System.Data.OleDb.OleDbParameter("ProvVerzicht", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(6, Byte), "ProvVerzicht", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("IsActive", System.Data.OleDb.OleDbType.[Boolean], 0, "IsActive"), New System.Data.OleDb.OleDbParameter("IsHistory", System.Data.OleDb.OleDbType.[Boolean], 0, "IsHistory"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})

    End Sub
    Friend WithEvents dbConn As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAuswahllisten As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand3 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAuswahllistenObj As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand4 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAuswahllisteGruppe As System.Data.OleDb.OleDbDataAdapter

End Class
