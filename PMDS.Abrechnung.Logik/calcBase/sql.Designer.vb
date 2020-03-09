Partial Class Sql
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Sql))
        Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.daBillHeader = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.daBooking = New System.Data.OleDb.OleDbDataAdapter()
        Me.daBill = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.daKost = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.daKlient = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.daKlinik = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.daRechNr = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand10 = New System.Data.OleDb.OleDbCommand()
        Me.daDepotgeldIDKlient = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand9 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand = New System.Data.OleDb.OleDbCommand()
        Me.daAufenthaltAct = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand13 = New System.Data.OleDb.OleDbCommand()
        Me.daPflegeStAct = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand11 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.OleDbInsertCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbDeleteCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.daBillUpdate = New System.Data.OleDb.OleDbDataAdapter()
        Me.daBillHeaderUpdate = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand12 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand14 = New System.Data.OleDb.OleDbCommand()
        '
        'OleDbSelectCommand1
        '
        Me.OleDbSelectCommand1.CommandText = "SELECT        ID, dbCalc, protokoll, IDKlinik" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            billHeader"
        Me.OleDbSelectCommand1.Connection = Me.dbConn
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=sty041;Integrated Security=SSPI;Initial Catalog=PM" &
    "DS_Bernstein"
        '
        'OleDbInsertCommand1
        '
        Me.OleDbInsertCommand1.CommandText = "INSERT INTO [billHeader] ([ID], [dbCalc], [protokoll], [IDKlinik]) VALUES (?, ?, " &
    "?, ?)"
        Me.OleDbInsertCommand1.Connection = Me.dbConn
        Me.OleDbInsertCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbCalc"), New System.Data.OleDb.OleDbParameter("protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "protokoll"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")})
        '
        'OleDbUpdateCommand1
        '
        Me.OleDbUpdateCommand1.CommandText = "UPDATE [billHeader] SET [ID] = ?, [dbCalc] = ?, [protokoll] = ?, [IDKlinik] = ? W" &
    "HERE (([ID] = ?))"
        Me.OleDbUpdateCommand1.Connection = Me.dbConn
        Me.OleDbUpdateCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbCalc"), New System.Data.OleDb.OleDbParameter("protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "protokoll"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDeleteCommand1
        '
        Me.OleDbDeleteCommand1.CommandText = "DELETE FROM [billHeader] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand1.Connection = Me.dbConn
        Me.OleDbDeleteCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daBillHeader
        '
        Me.daBillHeader.DeleteCommand = Me.OleDbDeleteCommand1
        Me.daBillHeader.InsertCommand = Me.OleDbInsertCommand1
        Me.daBillHeader.SelectCommand = Me.OleDbSelectCommand1
        Me.daBillHeader.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "billHeader", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("dbCalc", "dbCalc"), New System.Data.Common.DataColumnMapping("protokoll", "protokoll"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})})
        Me.daBillHeader.UpdateCommand = Me.OleDbUpdateCommand1
        '
        'OleDbSelectCommand2
        '
        Me.OleDbSelectCommand2.CommandText = "SELECT        bookings.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            bookings"
        Me.OleDbSelectCommand2.Connection = Me.dbConn
        '
        'OleDbInsertCommand2
        '
        Me.OleDbInsertCommand2.CommandText = resources.GetString("OleDbInsertCommand2.CommandText")
        Me.OleDbInsertCommand2.Connection = Me.dbConn
        Me.OleDbInsertCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Buchungsdatum"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Sollkonto", System.Data.OleDb.OleDbType.VarChar, 0, "Sollkonto"), New System.Data.OleDb.OleDbParameter("Habenkonto", System.Data.OleDb.OleDbType.VarChar, 0, "Habenkonto"), New System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "Betrag", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("MWStSatz", System.Data.OleDb.OleDbType.[Integer], 0, "MWStSatz"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarWChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 0, "IDKlient"), New System.Data.OleDb.OleDbParameter("IDKostenträger", System.Data.OleDb.OleDbType.VarChar, 0, "IDKostenträger"), New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstellt"), New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 16, "ErstellAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")})
        '
        'OleDbUpdateCommand2
        '
        Me.OleDbUpdateCommand2.CommandText = resources.GetString("OleDbUpdateCommand2.CommandText")
        Me.OleDbUpdateCommand2.Connection = Me.dbConn
        Me.OleDbUpdateCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Buchungsdatum"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Sollkonto", System.Data.OleDb.OleDbType.VarChar, 0, "Sollkonto"), New System.Data.OleDb.OleDbParameter("Habenkonto", System.Data.OleDb.OleDbType.VarChar, 0, "Habenkonto"), New System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "Betrag", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("MWStSatz", System.Data.OleDb.OleDbType.[Integer], 0, "MWStSatz"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarWChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 0, "IDKlient"), New System.Data.OleDb.OleDbParameter("IDKostenträger", System.Data.OleDb.OleDbType.VarChar, 0, "IDKostenträger"), New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstellt"), New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 16, "ErstellAm"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDeleteCommand2
        '
        Me.OleDbDeleteCommand2.CommandText = "DELETE FROM [bookings] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand2.Connection = Me.dbConn
        Me.OleDbDeleteCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daBooking
        '
        Me.daBooking.DeleteCommand = Me.OleDbDeleteCommand2
        Me.daBooking.InsertCommand = Me.OleDbInsertCommand2
        Me.daBooking.SelectCommand = Me.OleDbSelectCommand2
        Me.daBooking.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "bookings", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Buchungsdatum", "Buchungsdatum"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Sollkonto", "Sollkonto"), New System.Data.Common.DataColumnMapping("Habenkonto", "Habenkonto"), New System.Data.Common.DataColumnMapping("Betrag", "Betrag"), New System.Data.Common.DataColumnMapping("MWStSatz", "MWStSatz"), New System.Data.Common.DataColumnMapping("RechNr", "RechNr"), New System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"), New System.Data.Common.DataColumnMapping("IDKostenträger", "IDKostenträger"), New System.Data.Common.DataColumnMapping("Erstellt", "Erstellt"), New System.Data.Common.DataColumnMapping("ErstellAm", "ErstellAm"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})})
        Me.daBooking.UpdateCommand = Me.OleDbUpdateCommand2
        '
        'daBill
        '
        Me.daBill.SelectCommand = Me.OleDbCommand3
        Me.daBill.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "bills", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Freigegeben", "Freigegeben"), New System.Data.Common.DataColumnMapping("RechNr", "RechNr"), New System.Data.Common.DataColumnMapping("datum", "datum"), New System.Data.Common.DataColumnMapping("KlientName", "KlientName"), New System.Data.Common.DataColumnMapping("KostenträgerName", "KostenträgerName"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Typ", "Typ"), New System.Data.Common.DataColumnMapping("Rechnung", "Rechnung"), New System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"), New System.Data.Common.DataColumnMapping("IDKost", "IDKost"), New System.Data.Common.DataColumnMapping("IDKostIntern", "IDKostIntern"), New System.Data.Common.DataColumnMapping("betrag", "betrag"), New System.Data.Common.DataColumnMapping("IDAbrechnung", "IDAbrechnung"), New System.Data.Common.DataColumnMapping("IDSR", "IDSR"), New System.Data.Common.DataColumnMapping("Erstellt", "Erstellt"), New System.Data.Common.DataColumnMapping("ErstellAm", "ErstellAm"), New System.Data.Common.DataColumnMapping("dbBill", "dbBill"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("RechDatum", "RechDatum"), New System.Data.Common.DataColumnMapping("IDBillStorno", "IDBillStorno"), New System.Data.Common.DataColumnMapping("srJN", "srJN")})})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = "SELECT        bills.* , srJN = CASE IDSR WHEN '' THEN 0 ELSE  1 END  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM      " &
    "      bills"
        Me.OleDbCommand3.Connection = Me.dbConn
        '
        'daKost
        '
        Me.daKost.SelectCommand = Me.OleDbCommand7
        Me.daKost.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Kostentraeger", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Name", "Name"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("PLZ", "PLZ"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"), New System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"), New System.Data.Common.DataColumnMapping("BLZ", "BLZ"), New System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"), New System.Data.Common.DataColumnMapping("Bank", "Bank"), New System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"), New System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("Betrag", "Betrag"), New System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"), New System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"), New System.Data.Common.DataColumnMapping("ZahlartOld", "ZahlartOld"), New System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"), New System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN"), New System.Data.Common.DataColumnMapping("SammelabrechnungJN", "SammelabrechnungJN"), New System.Data.Common.DataColumnMapping("UIDNr", "UIDNr"), New System.Data.Common.DataColumnMapping("GSBG", "GSBG"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("IDKostentraegerSub", "IDKostentraegerSub")})})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = resources.GetString("OleDbCommand7.CommandText")
        Me.OleDbCommand7.Connection = Me.dbConn
        '
        'daKlient
        '
        Me.daKlient.SelectCommand = Me.OleDbCommand5
        Me.daKlient.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Adresse", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"), New System.Data.Common.DataColumnMapping("Titel", "Titel"), New System.Data.Common.DataColumnMapping("Sexus", "Sexus"), New System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"), New System.Data.Common.DataColumnMapping("Staatsb", "Staatsb"), New System.Data.Common.DataColumnMapping("Klasse", "Klasse"), New System.Data.Common.DataColumnMapping("KrankenKasse", "KrankenKasse"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("Plz", "Plz"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("LandKZ", "LandKZ"), New System.Data.Common.DataColumnMapping("IDKost", "IDKost"), New System.Data.Common.DataColumnMapping("Klientennummer", "Klientennummer"), New System.Data.Common.DataColumnMapping("Sollstand", "Sollstand"), New System.Data.Common.DataColumnMapping("minSaldo", "minSaldo"), New System.Data.Common.DataColumnMapping("abwesenheitenHändBerech", "abwesenheitenHändBerech"), New System.Data.Common.DataColumnMapping("WohnungAbgemeldetJN", "WohnungAbgemeldetJN"), New System.Data.Common.DataColumnMapping("KürzungLetzterTagAnwesenheit", "KürzungLetzterTagAnwesenheit")})})
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = resources.GetString("OleDbCommand5.CommandText")
        Me.OleDbCommand5.Connection = Me.dbConn
        '
        'daKlinik
        '
        Me.daKlinik.SelectCommand = Me.OleDbCommand6
        Me.daKlinik.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Adresse", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"), New System.Data.Common.DataColumnMapping("ZVR", "ZVR"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("Plz", "Plz"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("LandKZ", "LandKZ"), New System.Data.Common.DataColumnMapping("Tel", "Tel"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("Mobil", "Mobil"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"), New System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"), New System.Data.Common.DataColumnMapping("IDBank", "IDBank"), New System.Data.Common.DataColumnMapping("Bank", "Bank"), New System.Data.Common.DataColumnMapping("Kontonummer", "Kontonummer"), New System.Data.Common.DataColumnMapping("BLZ", "BLZ"), New System.Data.Common.DataColumnMapping("IBAN", "IBAN"), New System.Data.Common.DataColumnMapping("BIC", "BIC"), New System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"), New System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"), New System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3")})})
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = resources.GetString("OleDbCommand6.CommandText")
        Me.OleDbCommand6.Connection = Me.dbConn
        '
        'daRechNr
        '
        Me.daRechNr.SelectCommand = Me.OleDbCommand10
        Me.daRechNr.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "rechNr", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("typ", "typ"), New System.Data.Common.DataColumnMapping("nr", "nr"), New System.Data.Common.DataColumnMapping("year", "year")})})
        '
        'OleDbCommand10
        '
        Me.OleDbCommand10.CommandText = "SELECT        typ, nr, year" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            rechNr" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE        (typ = ?) and y" &
    "ear = ?"
        Me.OleDbCommand10.Connection = Me.dbConn
        Me.OleDbCommand10.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.[Char], 50, "typ"), New System.Data.OleDb.OleDbParameter("year", System.Data.OleDb.OleDbType.[Integer], 4, "year")})
        '
        'daDepotgeldIDKlient
        '
        Me.daDepotgeldIDKlient.DeleteCommand = Me.OleDbCommand8
        Me.daDepotgeldIDKlient.InsertCommand = Me.OleDbInsertCommand
        Me.daDepotgeldIDKlient.SelectCommand = Me.OleDbCommand9
        Me.daDepotgeldIDKlient.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Taschengeld", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("IDBenutzerdurchgefuehrt", "IDBenutzerdurchgefuehrt"), New System.Data.Common.DataColumnMapping("BelegNr", "BelegNr"), New System.Data.Common.DataColumnMapping("Datum", "Datum"), New System.Data.Common.DataColumnMapping("Grund", "Grund"), New System.Data.Common.DataColumnMapping("Einzahlung", "Einzahlung"), New System.Data.Common.DataColumnMapping("Auszahlung", "Auszahlung"), New System.Data.Common.DataColumnMapping("Saldo", "Saldo"), New System.Data.Common.DataColumnMapping("Lieferant", "Lieferant"), New System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"), New System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"), New System.Data.Common.DataColumnMapping("AbgerechnetJN", "AbgerechnetJN"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})})
        Me.daDepotgeldIDKlient.UpdateCommand = Me.OleDbUpdateCommand
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = "DELETE FROM [Taschengeld] WHERE (([ID] = ?))"
        Me.OleDbCommand8.Connection = Me.dbConn
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand
        '
        Me.OleDbInsertCommand.CommandText = resources.GetString("OleDbInsertCommand.CommandText")
        Me.OleDbInsertCommand.Connection = Me.dbConn
        Me.OleDbInsertCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"), New System.Data.OleDb.OleDbParameter("IDBenutzerdurchgefuehrt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerdurchgefuehrt"), New System.Data.OleDb.OleDbParameter("BelegNr", System.Data.OleDb.OleDbType.VarChar, 0, "BelegNr"), New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"), New System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"), New System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Einzahlung", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Auszahlung", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Saldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Saldo", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarChar, 0, "Lieferant"), New System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"), New System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.[Integer], 0, "Zahlart"), New System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.[Boolean], 0, "AbgerechnetJN"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")})
        '
        'OleDbCommand9
        '
        Me.OleDbCommand9.CommandText = "SELECT        Taschengeld.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Taschengeld"
        Me.OleDbCommand9.Connection = Me.dbConn
        '
        'OleDbUpdateCommand
        '
        Me.OleDbUpdateCommand.CommandText = resources.GetString("OleDbUpdateCommand.CommandText")
        Me.OleDbUpdateCommand.Connection = Me.dbConn
        Me.OleDbUpdateCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"), New System.Data.OleDb.OleDbParameter("IDBenutzerdurchgefuehrt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerdurchgefuehrt"), New System.Data.OleDb.OleDbParameter("BelegNr", System.Data.OleDb.OleDbType.VarChar, 0, "BelegNr"), New System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"), New System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"), New System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Einzahlung", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Auszahlung", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Saldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(10, Byte), CType(2, Byte), "Saldo", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarChar, 0, "Lieferant"), New System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"), New System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.[Integer], 0, "Zahlart"), New System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.[Boolean], 0, "AbgerechnetJN"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAufenthaltAct
        '
        Me.daAufenthaltAct.SelectCommand = Me.OleDbCommand13
        Me.daAufenthaltAct.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Aufenthalt", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"), New System.Data.Common.DataColumnMapping("Zimmernummer", "Zimmernummer"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})})
        '
        'OleDbCommand13
        '
        Me.OleDbCommand13.CommandText = resources.GetString("OleDbCommand13.CommandText")
        Me.OleDbCommand13.Connection = Me.dbConn
        '
        'daPflegeStAct
        '
        Me.daPflegeStAct.SelectCommand = Me.OleDbCommand11
        Me.daPflegeStAct.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "PatientPflegestufe", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("StufeNr", "StufeNr"), New System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb")})})
        '
        'OleDbCommand11
        '
        Me.OleDbCommand11.CommandText = resources.GetString("OleDbCommand11.CommandText")
        Me.OleDbCommand11.Connection = Me.dbConn
        '
        'OleDbSelectCommand3
        '
        Me.OleDbSelectCommand3.CommandText = resources.GetString("OleDbSelectCommand3.CommandText")
        Me.OleDbSelectCommand3.Connection = Me.dbConn
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STY040;Integrated Security=SSPI;Initial Catalog=PM" &
    "DS_DemoGross"
        '
        'OleDbInsertCommand3
        '
        Me.OleDbInsertCommand3.CommandText = resources.GetString("OleDbInsertCommand3.CommandText")
        Me.OleDbInsertCommand3.Connection = Me.dbConn
        Me.OleDbInsertCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("Freigegeben", System.Data.OleDb.OleDbType.[Boolean], 0, "Freigegeben"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("datum", System.Data.OleDb.OleDbType.Date, 16, "datum"), New System.Data.OleDb.OleDbParameter("KlientName", System.Data.OleDb.OleDbType.VarChar, 0, "KlientName"), New System.Data.OleDb.OleDbParameter("KostenträgerName", System.Data.OleDb.OleDbType.VarChar, 0, "KostenträgerName"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.[Integer], 0, "Status"), New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.[Integer], 0, "Typ"), New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Rechnung"), New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 0, "IDKlient"), New System.Data.OleDb.OleDbParameter("IDKost", System.Data.OleDb.OleDbType.VarChar, 0, "IDKost"), New System.Data.OleDb.OleDbParameter("IDKostIntern", System.Data.OleDb.OleDbType.VarChar, 0, "IDKostIntern"), New System.Data.OleDb.OleDbParameter("betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "betrag", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("IDAbrechnung", System.Data.OleDb.OleDbType.VarChar, 0, "IDAbrechnung"), New System.Data.OleDb.OleDbParameter("IDSR", System.Data.OleDb.OleDbType.VarChar, 0, "IDSR"), New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstellt"), New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 16, "ErstellAm"), New System.Data.OleDb.OleDbParameter("dbBill", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbBill"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("RechDatum", System.Data.OleDb.OleDbType.Date, 16, "RechDatum"), New System.Data.OleDb.OleDbParameter("IDBillStorno", System.Data.OleDb.OleDbType.LongVarWChar, 0, "IDBillStorno"), New System.Data.OleDb.OleDbParameter("ExportiertJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ExportiertJN"), New System.Data.OleDb.OleDbParameter("RollungAnz", System.Data.OleDb.OleDbType.[Integer], 0, "RollungAnz")})
        '
        'OleDbUpdateCommand3
        '
        Me.OleDbUpdateCommand3.CommandText = resources.GetString("OleDbUpdateCommand3.CommandText")
        Me.OleDbUpdateCommand3.Connection = Me.dbConn
        Me.OleDbUpdateCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("Freigegeben", System.Data.OleDb.OleDbType.[Boolean], 0, "Freigegeben"), New System.Data.OleDb.OleDbParameter("RechNr", System.Data.OleDb.OleDbType.VarChar, 0, "RechNr"), New System.Data.OleDb.OleDbParameter("datum", System.Data.OleDb.OleDbType.Date, 16, "datum"), New System.Data.OleDb.OleDbParameter("KlientName", System.Data.OleDb.OleDbType.VarChar, 0, "KlientName"), New System.Data.OleDb.OleDbParameter("KostenträgerName", System.Data.OleDb.OleDbType.VarChar, 0, "KostenträgerName"), New System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.[Integer], 0, "Status"), New System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.[Integer], 0, "Typ"), New System.Data.OleDb.OleDbParameter("Rechnung", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Rechnung"), New System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.VarChar, 0, "IDKlient"), New System.Data.OleDb.OleDbParameter("IDKost", System.Data.OleDb.OleDbType.VarChar, 0, "IDKost"), New System.Data.OleDb.OleDbParameter("IDKostIntern", System.Data.OleDb.OleDbType.VarChar, 0, "IDKostIntern"), New System.Data.OleDb.OleDbParameter("betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, False, CType(18, Byte), CType(3, Byte), "betrag", System.Data.DataRowVersion.Current, Nothing), New System.Data.OleDb.OleDbParameter("IDAbrechnung", System.Data.OleDb.OleDbType.VarChar, 0, "IDAbrechnung"), New System.Data.OleDb.OleDbParameter("IDSR", System.Data.OleDb.OleDbType.VarChar, 0, "IDSR"), New System.Data.OleDb.OleDbParameter("Erstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "Erstellt"), New System.Data.OleDb.OleDbParameter("ErstellAm", System.Data.OleDb.OleDbType.Date, 16, "ErstellAm"), New System.Data.OleDb.OleDbParameter("dbBill", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbBill"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("RechDatum", System.Data.OleDb.OleDbType.Date, 16, "RechDatum"), New System.Data.OleDb.OleDbParameter("IDBillStorno", System.Data.OleDb.OleDbType.LongVarWChar, 0, "IDBillStorno"), New System.Data.OleDb.OleDbParameter("ExportiertJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ExportiertJN"), New System.Data.OleDb.OleDbParameter("RollungAnz", System.Data.OleDb.OleDbType.[Integer], 0, "RollungAnz"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDeleteCommand3
        '
        Me.OleDbDeleteCommand3.CommandText = "DELETE FROM [bills] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand3.Connection = Me.dbConn
        Me.OleDbDeleteCommand3.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daBillUpdate
        '
        Me.daBillUpdate.DeleteCommand = Me.OleDbDeleteCommand3
        Me.daBillUpdate.InsertCommand = Me.OleDbInsertCommand3
        Me.daBillUpdate.SelectCommand = Me.OleDbSelectCommand3
        Me.daBillUpdate.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "bills", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Freigegeben", "Freigegeben"), New System.Data.Common.DataColumnMapping("RechNr", "RechNr"), New System.Data.Common.DataColumnMapping("datum", "datum"), New System.Data.Common.DataColumnMapping("KlientName", "KlientName"), New System.Data.Common.DataColumnMapping("KostenträgerName", "KostenträgerName"), New System.Data.Common.DataColumnMapping("Status", "Status"), New System.Data.Common.DataColumnMapping("Typ", "Typ"), New System.Data.Common.DataColumnMapping("Rechnung", "Rechnung"), New System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"), New System.Data.Common.DataColumnMapping("IDKost", "IDKost"), New System.Data.Common.DataColumnMapping("IDKostIntern", "IDKostIntern"), New System.Data.Common.DataColumnMapping("betrag", "betrag"), New System.Data.Common.DataColumnMapping("IDAbrechnung", "IDAbrechnung"), New System.Data.Common.DataColumnMapping("IDSR", "IDSR"), New System.Data.Common.DataColumnMapping("Erstellt", "Erstellt"), New System.Data.Common.DataColumnMapping("ErstellAm", "ErstellAm"), New System.Data.Common.DataColumnMapping("dbBill", "dbBill"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("RechDatum", "RechDatum"), New System.Data.Common.DataColumnMapping("IDBillStorno", "IDBillStorno"), New System.Data.Common.DataColumnMapping("ExportiertJN", "ExportiertJN"), New System.Data.Common.DataColumnMapping("RollungAnz", "RollungAnz")})})
        Me.daBillUpdate.UpdateCommand = Me.OleDbUpdateCommand3
        '
        'daBillHeaderUpdate
        '
        Me.daBillHeaderUpdate.DeleteCommand = Me.OleDbCommand1
        Me.daBillHeaderUpdate.InsertCommand = Me.OleDbCommand2
        Me.daBillHeaderUpdate.SelectCommand = Me.OleDbCommand4
        Me.daBillHeaderUpdate.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "billHeader", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("dbCalc", "dbCalc"), New System.Data.Common.DataColumnMapping("protokoll", "protokoll"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})})
        Me.daBillHeaderUpdate.UpdateCommand = Me.OleDbCommand12
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "DELETE FROM [billHeader] WHERE (([ID] = ?))"
        Me.OleDbCommand1.Connection = Me.dbConn
        Me.OleDbCommand1.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = "INSERT INTO [billHeader] ([ID], [dbCalc], [protokoll], [IDKlinik]) VALUES (?, ?, " &
    "?, ?)"
        Me.OleDbCommand2.Connection = Me.dbConn
        Me.OleDbCommand2.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbCalc"), New System.Data.OleDb.OleDbParameter("protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "protokoll"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")})
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = "SELECT        ID, dbCalc, protokoll, IDKlinik" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            billHeader"
        Me.OleDbCommand4.Connection = Me.dbConn
        '
        'OleDbCommand12
        '
        Me.OleDbCommand12.CommandText = "UPDATE [billHeader] SET [ID] = ?, [dbCalc] = ?, [protokoll] = ?, [IDKlinik] = ? W" &
    "HERE (([ID] = ?))"
        Me.OleDbCommand12.Connection = Me.dbConn
        Me.OleDbCommand12.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"), New System.Data.OleDb.OleDbParameter("dbCalc", System.Data.OleDb.OleDbType.LongVarWChar, 0, "dbCalc"), New System.Data.OleDb.OleDbParameter("protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "protokoll"), New System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbDataAdapter1
        '
        Me.OleDbDataAdapter1.SelectCommand = Me.OleDbCommand14
        Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Kostentraeger", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Name", "Name"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("PLZ", "PLZ"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Rechnungsempfaenger", "Rechnungsempfaenger"), New System.Data.Common.DataColumnMapping("Rechnungsanschrift", "Rechnungsanschrift"), New System.Data.Common.DataColumnMapping("BLZ", "BLZ"), New System.Data.Common.DataColumnMapping("Kontonr", "Kontonr"), New System.Data.Common.DataColumnMapping("Bank", "Bank"), New System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"), New System.Data.Common.DataColumnMapping("ErlagscheingebuehrJN", "ErlagscheingebuehrJN"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("Betrag", "Betrag"), New System.Data.Common.DataColumnMapping("TransferleistungJN", "TransferleistungJN"), New System.Data.Common.DataColumnMapping("TaschengeldJN", "TaschengeldJN"), New System.Data.Common.DataColumnMapping("ZahlartOld", "ZahlartOld"), New System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"), New System.Data.Common.DataColumnMapping("PatientbezogenJN", "PatientbezogenJN"), New System.Data.Common.DataColumnMapping("SammelabrechnungJN", "SammelabrechnungJN"), New System.Data.Common.DataColumnMapping("UIDNr", "UIDNr"), New System.Data.Common.DataColumnMapping("GSBG", "GSBG"), New System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"), New System.Data.Common.DataColumnMapping("IDKostentraegerSub", "IDKostentraegerSub")})})
        '
        'OleDbCommand14
        '
        Me.OleDbCommand14.CommandText = resources.GetString("OleDbCommand14.CommandText")
        Me.OleDbCommand14.Connection = Me.dbConn

    End Sub
    Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daBillHeader As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents dbConn As System.Data.OleDb.OleDbConnection
    Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daBooking As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents daBill As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand3 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daKost As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand7 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daKlient As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand5 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daKlinik As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand6 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daRechNr As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand10 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daDepotgeldIDKlient As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand8 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand9 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand As System.Data.OleDb.OleDbCommand
    Friend WithEvents daAufenthaltAct As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand13 As System.Data.OleDb.OleDbCommand
    Friend WithEvents daPflegeStAct As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand11 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbConnection1 As OleDb.OleDbConnection
    Friend WithEvents OleDbInsertCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCommand3 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand1 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand2 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand4 As OleDb.OleDbCommand
    Friend WithEvents OleDbCommand12 As OleDb.OleDbCommand
    Public WithEvents daBillUpdate As OleDb.OleDbDataAdapter
    Public WithEvents daBillHeaderUpdate As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDataAdapter1 As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand14 As OleDb.OleDbCommand
End Class
