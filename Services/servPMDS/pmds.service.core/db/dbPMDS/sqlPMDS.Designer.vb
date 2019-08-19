Partial Class sqlPMDS
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

        Me.sqldaBenutzer = Me.daBenutzer.SelectCommand.CommandText
        Me.sqldaAbteilungen = Me.daAbteilungen.SelectCommand.CommandText
        Me.sqldaBereiche = Me.daBereiche.SelectCommand.CommandText
        Me.sqldaPatienten = Me.daPatienten.SelectCommand.CommandText
        Me.sqldaAufenthalte = Me.daAufenthalte.SelectCommand.CommandText
        Me.sqldaAufenthaltVerläufe = Me.daAufenthaltVerläufe.SelectCommand.CommandText
        Me.sqldaTasks = Me.daTasks.SelectCommand.CommandText
        Me.sqldaAuswahllisten = Me.daAuswahlliste.SelectCommand.CommandText

        Me.sqldaPflegeplan = Me.daPflegeplan.SelectCommand.CommandText
        Me.sqldaPflegeplanH = Me.daPflegeplanH.SelectCommand.CommandText
        Me.sqldaPflegeeintrag = Me.daPflegeeintrag.SelectCommand.CommandText
        Me.sqldaZusatzwert = Me.daZusatzwert.SelectCommand.CommandText

        Me.sqldaQuickmeldung = Me.daQuickmeldung.SelectCommand.CommandText

        Me.sqldaAufenthaltPDX = Me.daAufenthaltPDX.SelectCommand.CommandText
        Me.sqldaWundeKopf = Me.daWundeKopf.SelectCommand.CommandText
        Me.sqldaWundePos = Me.daWundePos.SelectCommand.CommandText
        Me.sqldaWundePosBilder = Me.daWundePosBilder.SelectCommand.CommandText

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sqlPMDS))
        Me.daBenutzer = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
        Me.daAbteilungen = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand7 = New System.Data.OleDb.OleDbCommand()
        Me.daBereiche = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand11 = New System.Data.OleDb.OleDbCommand()
        Me.daPatienten = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand15 = New System.Data.OleDb.OleDbCommand()
        Me.daAufenthalte = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand19 = New System.Data.OleDb.OleDbCommand()
        Me.daAufenthaltVerläufe = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand23 = New System.Data.OleDb.OleDbCommand()
        Me.daTasks = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand25 = New System.Data.OleDb.OleDbCommand()
        Me.daEintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbInsertCommand = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand18 = New System.Data.OleDb.OleDbCommand()
        Me.daZusatzgruppeEintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand26 = New System.Data.OleDb.OleDbCommand()
        Me.daZusatzEintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand27 = New System.Data.OleDb.OleDbCommand()
        Me.daZusatzwert = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand5 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand8 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand28 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand6 = New System.Data.OleDb.OleDbCommand()
        Me.daAuswahlliste = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand()
        Me.daPflegeplan = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand29 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand30 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand31 = New System.Data.OleDb.OleDbCommand()
        Me.daPflegeplanH = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand9 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand10 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand12 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand13 = New System.Data.OleDb.OleDbCommand()
        Me.daPflegeeintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand14 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand16 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand17 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand20 = New System.Data.OleDb.OleDbCommand()
        Me.daQuickmeldung = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand()
        Me.daAufenthaltPDX = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand21 = New System.Data.OleDb.OleDbCommand()
        Me.daWundeKopf = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand22 = New System.Data.OleDb.OleDbCommand()
        Me.daWundePos = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand36 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand33 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand34 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand35 = New System.Data.OleDb.OleDbCommand()
        Me.daWundePosBilder = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbCommand24 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand32 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand37 = New System.Data.OleDb.OleDbCommand()
        Me.OleDbCommand38 = New System.Data.OleDb.OleDbCommand()
        '
        'daBenutzer
        '
        Me.daBenutzer.SelectCommand = Me.OleDbCommand1
        Me.daBenutzer.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Benutzer", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"), New System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"), New System.Data.Common.DataColumnMapping("Passwort", "Passwort"), New System.Data.Common.DataColumnMapping("AktivJN", "AktivJN"), New System.Data.Common.DataColumnMapping("PflegerJN", "PflegerJN"), New System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"), New System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"), New System.Data.Common.DataColumnMapping("Eintrittsdatum", "Eintrittsdatum"), New System.Data.Common.DataColumnMapping("Austrittsdatum", "Austrittsdatum"), New System.Data.Common.DataColumnMapping("smtpSrv", "smtpSrv"), New System.Data.Common.DataColumnMapping("smtpPort", "smtpPort"), New System.Data.Common.DataColumnMapping("smtpAbsender", "smtpAbsender"), New System.Data.Common.DataColumnMapping("smtpPwd", "smtpPwd"), New System.Data.Common.DataColumnMapping("smtpAuthentStandard", "smtpAuthentStandard")})})
        '
        'OleDbCommand1
        '
        Me.OleDbCommand1.CommandText = "SELECT        Benutzer.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Benutzer"
        Me.OleDbCommand1.Connection = Me.OleDbConnection1
        '
        'OleDbConnection1
        '
        Me.OleDbConnection1.ConnectionString = "Provider=SQLNCLI.1;Data Source=sty039;Integrated Security=SSPI;Initial Catalog=PM" & _
    "DS_DemoGroß"
        '
        'daAbteilungen
        '
        Me.daAbteilungen.SelectCommand = Me.OleDbCommand7
        Me.daAbteilungen.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Abteilung", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})})
        '
        'OleDbCommand7
        '
        Me.OleDbCommand7.CommandText = "SELECT        Abteilung.ID, Abteilung.Bezeichnung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Abteilung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.OleDbCommand7.Connection = Me.OleDbConnection1
        '
        'daBereiche
        '
        Me.daBereiche.SelectCommand = Me.OleDbCommand11
        Me.daBereiche.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Bereich", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})})
        '
        'OleDbCommand11
        '
        Me.OleDbCommand11.CommandText = "SELECT        ID, Bezeichnung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Bereich"
        Me.OleDbCommand11.Connection = Me.OleDbConnection1
        '
        'daPatienten
        '
        Me.daPatienten.SelectCommand = Me.OleDbCommand15
        Me.daPatienten.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Patient", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Sexus", "Sexus")})})
        '
        'OleDbCommand15
        '
        Me.OleDbCommand15.CommandText = "SELECT        Nachname, Vorname, ID, Sexus" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Patient"
        Me.OleDbCommand15.Connection = Me.OleDbConnection1
        '
        'daAufenthalte
        '
        Me.daAufenthalte.SelectCommand = Me.OleDbCommand19
        Me.daAufenthalte.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Aufenthalt", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf")})})
        '
        'OleDbCommand19
        '
        Me.OleDbCommand19.CommandText = "SELECT        ID, IDPatient, IDAufenthaltVerlauf" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Aufenthalt"
        Me.OleDbCommand19.Connection = Me.OleDbConnection1
        '
        'daAufenthaltVerläufe
        '
        Me.daAufenthaltVerläufe.SelectCommand = Me.OleDbCommand23
        Me.daAufenthaltVerläufe.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AufenthaltVerlauf", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDAbteilung_Nach", "IDAbteilung_Nach"), New System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})})
        '
        'OleDbCommand23
        '
        Me.OleDbCommand23.CommandText = "SELECT        ID, IDAufenthalt, IDAbteilung_Nach, IDBereich" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Aufe" & _
    "nthaltVerlauf"
        Me.OleDbCommand23.Connection = Me.OleDbConnection1
        '
        'daTasks
        '
        Me.daTasks.SelectCommand = Me.OleDbCommand25
        Me.daTasks.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "vPflegePlanPDx", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"), New System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"), New System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"), New System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Intervall", "Intervall"), New System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"), New System.Data.Common.DataColumnMapping("BerufstandPP", "BerufstandPP"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"), New System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"), New System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"), New System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"), New System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"), New System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"), New System.Data.Common.DataColumnMapping("BarcodeIDPP", "BarcodeIDPP"), New System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug")})})
        '
        'OleDbCommand25
        '
        Me.OleDbCommand25.CommandText = resources.GetString("OleDbCommand25.CommandText")
        Me.OleDbCommand25.Connection = Me.OleDbConnection1
        '
        'daEintrag
        '
        Me.daEintrag.InsertCommand = Me.OleDbInsertCommand
        Me.daEintrag.SelectCommand = Me.OleDbCommand18
        Me.daEintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Eintrag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"), New System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"), New System.Data.Common.DataColumnMapping("Sicht", "Sicht"), New System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("flag", "flag"), New System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"), New System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"), New System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug")})})
        '
        'OleDbInsertCommand
        '
        Me.OleDbInsertCommand.CommandText = "INSERT INTO [Eintrag] ([ID], [EntferntJN], [EintragGruppe], [Sicht], [Warnhinweis" & _
    "], [Text], [flag], [IDLinkDokument], [BedarfsMedikationJN], [OhneZeitBezug]) VAL" & _
    "UES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand.Connection = Me.OleDbConnection1
        Me.OleDbInsertCommand.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.[Boolean], 0, "EntferntJN"), New System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"), New System.Data.OleDb.OleDbParameter("Sicht", System.Data.OleDb.OleDbType.VarChar, 0, "Sicht"), New System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("flag", System.Data.OleDb.OleDbType.[Integer], 0, "flag"), New System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"), New System.Data.OleDb.OleDbParameter("BedarfsMedikationJN", System.Data.OleDb.OleDbType.[Boolean], 0, "BedarfsMedikationJN"), New System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.[Boolean], 0, "OhneZeitBezug")})
        '
        'OleDbCommand18
        '
        Me.OleDbCommand18.CommandText = "SELECT        ID, EntferntJN, EintragGruppe, Sicht, Warnhinweis, Text, flag, IDLi" & _
    "nkDokument, BedarfsMedikationJN, OhneZeitBezug" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Eintrag"
        Me.OleDbCommand18.Connection = Me.OleDbConnection1
        '
        'daZusatzgruppeEintrag
        '
        Me.daZusatzgruppeEintrag.SelectCommand = Me.OleDbCommand26
        Me.daZusatzgruppeEintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "ZusatzGruppeEintrag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDZusatzGruppe", "IDZusatzGruppe"), New System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"), New System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"), New System.Data.Common.DataColumnMapping("IDFilter", "IDFilter"), New System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"), New System.Data.Common.DataColumnMapping("DruckenJN", "DruckenJN"), New System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})})
        '
        'OleDbCommand26
        '
        Me.OleDbCommand26.CommandText = "SELECT        ID, IDZusatzGruppe, IDZusatzEintrag, IDObjekt, IDFilter, OptionalJN" & _
    ", DruckenJN, Reihenfolge" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            ZusatzGruppeEintrag"
        Me.OleDbCommand26.Connection = Me.OleDbConnection1
        '
        'daZusatzEintrag
        '
        Me.daZusatzEintrag.SelectCommand = Me.OleDbCommand27
        Me.daZusatzEintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "ZusatzEintrag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Typ", "Typ"), New System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"), New System.Data.Common.DataColumnMapping("MinValue", "MinValue"), New System.Data.Common.DataColumnMapping("MaxValue", "MaxValue"), New System.Data.Common.DataColumnMapping("FeldNr", "FeldNr")})})
        '
        'OleDbCommand27
        '
        Me.OleDbCommand27.CommandText = "SELECT        ID, Bezeichnung, Typ, ListenEintraege, MinValue, MaxValue, FeldNr" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & _
    "FROM            ZusatzEintrag"
        Me.OleDbCommand27.Connection = Me.OleDbConnection1
        '
        'daZusatzwert
        '
        Me.daZusatzwert.DeleteCommand = Me.OleDbCommand5
        Me.daZusatzwert.InsertCommand = Me.OleDbCommand8
        Me.daZusatzwert.SelectCommand = Me.OleDbCommand28
        Me.daZusatzwert.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "ZusatzWert", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDZusatzGruppeEintrag", "IDZusatzGruppeEintrag"), New System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"), New System.Data.Common.DataColumnMapping("Wert", "Wert"), New System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"), New System.Data.Common.DataColumnMapping("RawFormat", "RawFormat"), New System.Data.Common.DataColumnMapping("ZahlenWertFloat", "ZahlenWertFloat")})})
        Me.daZusatzwert.UpdateCommand = Me.OleDbCommand6
        '
        'OleDbCommand5
        '
        Me.OleDbCommand5.CommandText = "DELETE FROM [ZusatzWert] WHERE (([ID] = ?))"
        Me.OleDbCommand5.Connection = Me.OleDbConnection1
        Me.OleDbCommand5.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand8
        '
        Me.OleDbCommand8.CommandText = "INSERT INTO [ZusatzWert] ([ID], [IDZusatzGruppeEintrag], [IDObjekt], [Wert], [Zah" & _
    "lenWert], [RawFormat], [ZahlenWertFloat]) VALUES (?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbCommand8.Connection = Me.OleDbConnection1
        Me.OleDbCommand8.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDZusatzGruppeEintrag"), New System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"), New System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wert"), New System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.[Integer], 0, "ZahlenWert"), New System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.LongVarBinary, 0, "RawFormat"), New System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.[Double], 0, "ZahlenWertFloat")})
        '
        'OleDbCommand28
        '
        Me.OleDbCommand28.CommandText = "SELECT        ID, IDZusatzGruppeEintrag, IDObjekt, Wert, ZahlenWert, RawFormat, Z" & _
    "ahlenWertFloat" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            ZusatzWert"
        Me.OleDbCommand28.Connection = Me.OleDbConnection1
        '
        'OleDbCommand6
        '
        Me.OleDbCommand6.CommandText = "UPDATE [ZusatzWert] SET [ID] = ?, [IDZusatzGruppeEintrag] = ?, [IDObjekt] = ?, [W" & _
    "ert] = ?, [ZahlenWert] = ?, [RawFormat] = ?, [ZahlenWertFloat] = ? WHERE (([ID] " & _
    "= ?))"
        Me.OleDbCommand6.Connection = Me.OleDbConnection1
        Me.OleDbCommand6.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDZusatzGruppeEintrag"), New System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"), New System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wert"), New System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.[Integer], 0, "ZahlenWert"), New System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.LongVarBinary, 0, "RawFormat"), New System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.[Double], 0, "ZahlenWertFloat"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAuswahlliste
        '
        Me.daAuswahlliste.SelectCommand = Me.OleDbCommand2
        Me.daAuswahlliste.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AuswahlListe", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAuswahlListeGruppe", "IDAuswahlListeGruppe"), New System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})})
        '
        'OleDbCommand2
        '
        Me.OleDbCommand2.CommandText = "SELECT        ID, IDAuswahlListeGruppe, Reihenfolge, Bezeichnung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM           " & _
    " AuswahlListe"
        Me.OleDbCommand2.Connection = Me.OleDbConnection1
        '
        'daPflegeplan
        '
        Me.daPflegeplan.DeleteCommand = Me.OleDbCommand4
        Me.daPflegeplan.InsertCommand = Me.OleDbCommand29
        Me.daPflegeplan.SelectCommand = Me.OleDbCommand30
        Me.daPflegeplan.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "PflegePlan", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"), New System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"), New System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"), New System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"), New System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"), New System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"), New System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"), New System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"), New System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Intervall", "Intervall"), New System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"), New System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"), New System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"), New System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"), New System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"), New System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"), New System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"), New System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"), New System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"), New System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"), New System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"), New System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"), New System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"), New System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"), New System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"), New System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"), New System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"), New System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"), New System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"), New System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"), New System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"), New System.Data.Common.DataColumnMapping("wundejn", "wundejn"), New System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag")})})
        Me.daPflegeplan.UpdateCommand = Me.OleDbCommand31
        '
        'OleDbCommand4
        '
        Me.OleDbCommand4.CommandText = "DELETE FROM [PflegePlan] WHERE (([ID] = ?))"
        Me.OleDbCommand4.Connection = Me.OleDbConnection1
        Me.OleDbCommand4.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand29
        '
        Me.OleDbCommand29.CommandText = resources.GetString("OleDbCommand29.CommandText")
        Me.OleDbCommand29.Connection = Me.OleDbConnection1
        Me.OleDbCommand29.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "OriginalJN"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"), New System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndeDatum"), New System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetztesDatum"), New System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteEvaluierung"), New System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"), New System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"), New System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.[Integer], 0, "Intervall"), New System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.[Integer], 0, "WochenTage"), New System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IntervallTyp"), New System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.[Integer], 0, "EvalTage"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ParalellJN"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.[Boolean], 0, "LokalisierungJN"), New System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.[Boolean], 0, "EinmaligJN"), New System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ErledigtJN"), New System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "GeloeschtJN"), New System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"), New System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"), New System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"), New System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.[Boolean], 0, "PDXJN"), New System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "RMOptionalJN"), New System.Data.OleDb.OleDbParameter("UntertaegigeJN", System.Data.OleDb.OleDbType.[Boolean], 0, "UntertaegigeJN"), New System.Data.OleDb.OleDbParameter("SpenderAbgabeJN", System.Data.OleDb.OleDbType.[Boolean], 0, "SpenderAbgabeJN"), New System.Data.OleDb.OleDbParameter("IDUntertaegigeGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDUntertaegigeGruppe"), New System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"), New System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.[Boolean], 0, "OhneZeitBezug"), New System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"), New System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZuErledigenBis"), New System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.[Boolean], 0, "wundejn"), New System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.[Integer], 0, "EintragFlag")})
        '
        'OleDbCommand30
        '
        Me.OleDbCommand30.CommandText = resources.GetString("OleDbCommand30.CommandText")
        Me.OleDbCommand30.Connection = Me.OleDbConnection1
        '
        'OleDbCommand31
        '
        Me.OleDbCommand31.CommandText = resources.GetString("OleDbCommand31.CommandText")
        Me.OleDbCommand31.Connection = Me.OleDbConnection1
        Me.OleDbCommand31.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "OriginalJN"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"), New System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndeDatum"), New System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetztesDatum"), New System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteEvaluierung"), New System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"), New System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"), New System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.[Integer], 0, "Intervall"), New System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.[Integer], 0, "WochenTage"), New System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IntervallTyp"), New System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.[Integer], 0, "EvalTage"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ParalellJN"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.[Boolean], 0, "LokalisierungJN"), New System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.[Boolean], 0, "EinmaligJN"), New System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ErledigtJN"), New System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "GeloeschtJN"), New System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"), New System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"), New System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"), New System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.[Boolean], 0, "PDXJN"), New System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "RMOptionalJN"), New System.Data.OleDb.OleDbParameter("UntertaegigeJN", System.Data.OleDb.OleDbType.[Boolean], 0, "UntertaegigeJN"), New System.Data.OleDb.OleDbParameter("SpenderAbgabeJN", System.Data.OleDb.OleDbType.[Boolean], 0, "SpenderAbgabeJN"), New System.Data.OleDb.OleDbParameter("IDUntertaegigeGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDUntertaegigeGruppe"), New System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"), New System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.[Boolean], 0, "OhneZeitBezug"), New System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"), New System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZuErledigenBis"), New System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.[Boolean], 0, "wundejn"), New System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.[Integer], 0, "EintragFlag"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPflegeplanH
        '
        Me.daPflegeplanH.DeleteCommand = Me.OleDbCommand9
        Me.daPflegeplanH.InsertCommand = Me.OleDbCommand10
        Me.daPflegeplanH.SelectCommand = Me.OleDbCommand12
        Me.daPflegeplanH.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "PflegePlanH", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Aktion", "Aktion"), New System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"), New System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"), New System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"), New System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"), New System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"), New System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"), New System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"), New System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"), New System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("Intervall", "Intervall"), New System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"), New System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"), New System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"), New System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"), New System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"), New System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"), New System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"), New System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"), New System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"), New System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"), New System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"), New System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"), New System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"), New System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"), New System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"), New System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"), New System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"), New System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag")})})
        Me.daPflegeplanH.UpdateCommand = Me.OleDbCommand13
        '
        'OleDbCommand9
        '
        Me.OleDbCommand9.CommandText = "DELETE FROM [PflegePlanH] WHERE (([ID] = ?))"
        Me.OleDbCommand9.Connection = Me.OleDbConnection1
        Me.OleDbCommand9.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand10
        '
        Me.OleDbCommand10.CommandText = resources.GetString("OleDbCommand10.CommandText")
        Me.OleDbCommand10.Connection = Me.OleDbConnection1
        Me.OleDbCommand10.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"), New System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "OriginalJN"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"), New System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndeDatum"), New System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetztesDatum"), New System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteEvaluierung"), New System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"), New System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"), New System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.[Integer], 0, "Intervall"), New System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.[Integer], 0, "WochenTage"), New System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IntervallTyp"), New System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.[Integer], 0, "EvalTage"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ParalellJN"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.[Boolean], 0, "LokalisierungJN"), New System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.[Boolean], 0, "EinmaligJN"), New System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ErledigtJN"), New System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "GeloeschtJN"), New System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"), New System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"), New System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"), New System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.[Boolean], 0, "PDXJN"), New System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "RMOptionalJN"), New System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"), New System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.[Boolean], 0, "OhneZeitBezug"), New System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"), New System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZuErledigenBis"), New System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.[Integer], 0, "EintragFlag")})
        '
        'OleDbCommand12
        '
        Me.OleDbCommand12.CommandText = resources.GetString("OleDbCommand12.CommandText")
        Me.OleDbCommand12.Connection = Me.OleDbConnection1
        '
        'OleDbCommand13
        '
        Me.OleDbCommand13.CommandText = resources.GetString("OleDbCommand13.CommandText")
        Me.OleDbCommand13.Connection = Me.OleDbConnection1
        Me.OleDbCommand13.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"), New System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "OriginalJN"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"), New System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndeDatum"), New System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetztesDatum"), New System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteEvaluierung"), New System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"), New System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"), New System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.[Integer], 0, "Intervall"), New System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.[Integer], 0, "WochenTage"), New System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IntervallTyp"), New System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.[Integer], 0, "EvalTage"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ParalellJN"), New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.[Integer], 0, "Dauer"), New System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.[Boolean], 0, "LokalisierungJN"), New System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.[Boolean], 0, "EinmaligJN"), New System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "ErledigtJN"), New System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "GeloeschtJN"), New System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"), New System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"), New System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"), New System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.[Boolean], 0, "PDXJN"), New System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.[Boolean], 0, "RMOptionalJN"), New System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteEvaluierung"), New System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"), New System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.[Boolean], 0, "OhneZeitBezug"), New System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"), New System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZuErledigenBis"), New System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.[Integer], 0, "EintragFlag"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daPflegeeintrag
        '
        Me.daPflegeeintrag.DeleteCommand = Me.OleDbCommand14
        Me.daPflegeeintrag.InsertCommand = Me.OleDbCommand16
        Me.daPflegeeintrag.SelectCommand = Me.OleDbCommand17
        Me.daPflegeeintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "PflegeEintrag", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"), New System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"), New System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"), New System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"), New System.Data.Common.DataColumnMapping("Text", "Text"), New System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"), New System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"), New System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"), New System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"), New System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"), New System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"), New System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"), New System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"), New System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"), New System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"), New System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"), New System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"), New System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer")})})
        Me.daPflegeeintrag.UpdateCommand = Me.OleDbCommand20
        '
        'OleDbCommand14
        '
        Me.OleDbCommand14.CommandText = "DELETE FROM [PflegeEintrag] WHERE (([ID] = ?))"
        Me.OleDbCommand14.Connection = Me.OleDbConnection1
        Me.OleDbCommand14.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand16
        '
        Me.OleDbCommand16.CommandText = resources.GetString("OleDbCommand16.CommandText")
        Me.OleDbCommand16.Connection = Me.OleDbConnection1
        Me.OleDbCommand16.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"), New System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.[Integer], 0, "IstDauer"), New System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "DurchgefuehrtJN"), New System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.[Integer], 0, "EintragsTyp"), New System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.[Integer], 0, "Wichtig"), New System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"), New System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"), New System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.[Integer], 0, "EvalStatus"), New System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"), New System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"), New System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"), New System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"), New System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.[Integer], 0, "Solldauer"), New System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"), New System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"), New System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.[Integer], 0, "PflegePlanDauer")})
        '
        'OleDbCommand17
        '
        Me.OleDbCommand17.CommandText = resources.GetString("OleDbCommand17.CommandText")
        Me.OleDbCommand17.Connection = Me.OleDbConnection1
        '
        'OleDbCommand20
        '
        Me.OleDbCommand20.CommandText = resources.GetString("OleDbCommand20.CommandText")
        Me.OleDbCommand20.Connection = Me.OleDbConnection1
        Me.OleDbCommand20.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"), New System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"), New System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"), New System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"), New System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"), New System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"), New System.Data.OleDb.OleDbParameter("IstDauer", System.Data.OleDb.OleDbType.[Integer], 0, "IstDauer"), New System.Data.OleDb.OleDbParameter("DurchgefuehrtJN", System.Data.OleDb.OleDbType.[Boolean], 0, "DurchgefuehrtJN"), New System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.[Integer], 0, "EintragsTyp"), New System.Data.OleDb.OleDbParameter("Wichtig", System.Data.OleDb.OleDbType.[Integer], 0, "Wichtig"), New System.Data.OleDb.OleDbParameter("IDWichtig", System.Data.OleDb.OleDbType.Guid, 0, "IDWichtig"), New System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"), New System.Data.OleDb.OleDbParameter("EvalStatus", System.Data.OleDb.OleDbType.[Integer], 0, "EvalStatus"), New System.Data.OleDb.OleDbParameter("PflegeplanText", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeplanText"), New System.Data.OleDb.OleDbParameter("IDSollberufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDSollberufsstand"), New System.Data.OleDb.OleDbParameter("IDPflegePlanBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlanBerufsstand"), New System.Data.OleDb.OleDbParameter("IDPflegeplanH", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeplanH"), New System.Data.OleDb.OleDbParameter("Solldauer", System.Data.OleDb.OleDbType.[Integer], 0, "Solldauer"), New System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"), New System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"), New System.Data.OleDb.OleDbParameter("PflegePlanDauer", System.Data.OleDb.OleDbType.[Integer], 0, "PflegePlanDauer"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daQuickmeldung
        '
        Me.daQuickmeldung.SelectCommand = Me.OleDbCommand3
        Me.daQuickmeldung.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "QuickMeldung", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})})
        '
        'OleDbCommand3
        '
        Me.OleDbCommand3.CommandText = "SELECT        ID, Bezeichnung, IDEintrag, IDAbteilung" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            QuickMeldu" & _
    "ng"
        Me.OleDbCommand3.Connection = Me.OleDbConnection1
        '
        'daAufenthaltPDX
        '
        Me.daAufenthaltPDX.SelectCommand = Me.OleDbCommand21
        Me.daAufenthaltPDX.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "AufenthaltPDx", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"), New System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"), New System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"), New System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"), New System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"), New System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"), New System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"), New System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"), New System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"), New System.Data.Common.DataColumnMapping("resourceklient", "resourceklient"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"), New System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"), New System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"), New System.Data.Common.DataColumnMapping("wundejn", "wundejn")})})
        '
        'OleDbCommand21
        '
        Me.OleDbCommand21.CommandText = "SELECT        AufenthaltPDx.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            AufenthaltPDx"
        Me.OleDbCommand21.Connection = Me.OleDbConnection1
        '
        'daWundeKopf
        '
        Me.daWundeKopf.SelectCommand = Me.OleDbCommand22
        Me.daWundeKopf.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "WundeKopf", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDAufenthaltPDx", "IDAufenthaltPDx"), New System.Data.Common.DataColumnMapping("Wundart", "Wundart"), New System.Data.Common.DataColumnMapping("Dekuskala", "Dekuskala"), New System.Data.Common.DataColumnMapping("Dekuwert", "Dekuwert"), New System.Data.Common.DataColumnMapping("ClickedImage", "ClickedImage"), New System.Data.Common.DataColumnMapping("ClickedValueX", "ClickedValueX"), New System.Data.Common.DataColumnMapping("ClickedValueY", "ClickedValueY"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"), New System.Data.Common.DataColumnMapping("BekanntSeit", "BekanntSeit"), New System.Data.Common.DataColumnMapping("BisherigeBehandlung", "BisherigeBehandlung")})})
        '
        'OleDbCommand22
        '
        Me.OleDbCommand22.CommandText = "SELECT        WundeKopf.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            WundeKopf"
        Me.OleDbCommand22.Connection = Me.OleDbConnection1
        '
        'daWundePos
        '
        Me.daWundePos.DeleteCommand = Me.OleDbCommand36
        Me.daWundePos.InsertCommand = Me.OleDbCommand33
        Me.daWundePos.SelectCommand = Me.OleDbCommand34
        Me.daWundePos.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "WundePos", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDWundeKopf", "IDWundeKopf"), New System.Data.Common.DataColumnMapping("Erhebungszeitpunkt", "Erhebungszeitpunkt"), New System.Data.Common.DataColumnMapping("Stadium", "Stadium"), New System.Data.Common.DataColumnMapping("Schmerzqualitaet", "Schmerzqualitaet"), New System.Data.Common.DataColumnMapping("Schmerzintensitaet", "Schmerzintensitaet"), New System.Data.Common.DataColumnMapping("NekroseJN", "NekroseJN"), New System.Data.Common.DataColumnMapping("Wundzustand", "Wundzustand"), New System.Data.Common.DataColumnMapping("L", "L"), New System.Data.Common.DataColumnMapping("B", "B"), New System.Data.Common.DataColumnMapping("H", "H"), New System.Data.Common.DataColumnMapping("Erreger", "Erreger"), New System.Data.Common.DataColumnMapping("Infektionszeichen", "Infektionszeichen"), New System.Data.Common.DataColumnMapping("Heilungsverlauf", "Heilungsverlauf"), New System.Data.Common.DataColumnMapping("Heilungstext", "Heilungstext"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"), New System.Data.Common.DataColumnMapping("GranulationProz", "GranulationProz"), New System.Data.Common.DataColumnMapping("EpithelisierungProz", "EpithelisierungProz"), New System.Data.Common.DataColumnMapping("FistelnTaschen", "FistelnTaschen"), New System.Data.Common.DataColumnMapping("Wundbelag", "Wundbelag"), New System.Data.Common.DataColumnMapping("WundeFreiliegendeStrukturen", "WundeFreiliegendeStrukturen"), New System.Data.Common.DataColumnMapping("Wundsekretion", "Wundsekretion"), New System.Data.Common.DataColumnMapping("Sekretionsmenge", "Sekretionsmenge"), New System.Data.Common.DataColumnMapping("Wundgeruch", "Wundgeruch"), New System.Data.Common.DataColumnMapping("WundrandIntakt", "WundrandIntakt"), New System.Data.Common.DataColumnMapping("WundrandMazeriert", "WundrandMazeriert"), New System.Data.Common.DataColumnMapping("WundrandUnterminiertZerklueftet", "WundrandUnterminiertZerklueftet"), New System.Data.Common.DataColumnMapping("WundrandGeroetet", "WundrandGeroetet"), New System.Data.Common.DataColumnMapping("WundrandHyperkeratose", "WundrandHyperkeratose"), New System.Data.Common.DataColumnMapping("WundumgebungIntakt", "WundumgebungIntakt"), New System.Data.Common.DataColumnMapping("WundumgebungTrockenPergamentartig", "WundumgebungTrockenPergamentartig"), New System.Data.Common.DataColumnMapping("WundumgebungEkzemOedemRoetung", "WundumgebungEkzemOedemRoetung"), New System.Data.Common.DataColumnMapping("WundumgebungSpannungsblase", "WundumgebungSpannungsblase"), New System.Data.Common.DataColumnMapping("Wundumgebung", "Wundumgebung"), New System.Data.Common.DataColumnMapping("WundrandOedemoesWulstig", "WundrandOedemoesWulstig")})})
        Me.daWundePos.UpdateCommand = Me.OleDbCommand35
        '
        'OleDbCommand36
        '
        Me.OleDbCommand36.CommandText = "DELETE FROM [WundePos] WHERE (([ID] = ?))"
        Me.OleDbCommand36.Connection = Me.OleDbConnection1
        Me.OleDbCommand36.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand33
        '
        Me.OleDbCommand33.CommandText = resources.GetString("OleDbCommand33.CommandText")
        Me.OleDbCommand33.Connection = Me.OleDbConnection1
        Me.OleDbCommand33.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, "IDWundeKopf"), New System.Data.OleDb.OleDbParameter("Erhebungszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Erhebungszeitpunkt"), New System.Data.OleDb.OleDbParameter("Stadium", System.Data.OleDb.OleDbType.[Integer], 0, "Stadium"), New System.Data.OleDb.OleDbParameter("Schmerzqualitaet", System.Data.OleDb.OleDbType.VarChar, 0, "Schmerzqualitaet"), New System.Data.OleDb.OleDbParameter("Schmerzintensitaet", System.Data.OleDb.OleDbType.[Integer], 0, "Schmerzintensitaet"), New System.Data.OleDb.OleDbParameter("NekroseJN", System.Data.OleDb.OleDbType.[Boolean], 0, "NekroseJN"), New System.Data.OleDb.OleDbParameter("Wundzustand", System.Data.OleDb.OleDbType.VarChar, 0, "Wundzustand"), New System.Data.OleDb.OleDbParameter("L", System.Data.OleDb.OleDbType.[Double], 0, "L"), New System.Data.OleDb.OleDbParameter("B", System.Data.OleDb.OleDbType.[Double], 0, "B"), New System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.[Double], 0, "H"), New System.Data.OleDb.OleDbParameter("Erreger", System.Data.OleDb.OleDbType.VarChar, 0, "Erreger"), New System.Data.OleDb.OleDbParameter("Infektionszeichen", System.Data.OleDb.OleDbType.VarChar, 0, "Infektionszeichen"), New System.Data.OleDb.OleDbParameter("Heilungsverlauf", System.Data.OleDb.OleDbType.[Integer], 0, "Heilungsverlauf"), New System.Data.OleDb.OleDbParameter("Heilungstext", System.Data.OleDb.OleDbType.VarChar, 0, "Heilungstext"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("GranulationProz", System.Data.OleDb.OleDbType.[Integer], 0, "GranulationProz"), New System.Data.OleDb.OleDbParameter("EpithelisierungProz", System.Data.OleDb.OleDbType.[Integer], 0, "EpithelisierungProz"), New System.Data.OleDb.OleDbParameter("FistelnTaschen", System.Data.OleDb.OleDbType.VarChar, 0, "FistelnTaschen"), New System.Data.OleDb.OleDbParameter("Wundbelag", System.Data.OleDb.OleDbType.VarChar, 0, "Wundbelag"), New System.Data.OleDb.OleDbParameter("WundeFreiliegendeStrukturen", System.Data.OleDb.OleDbType.VarChar, 0, "WundeFreiliegendeStrukturen"), New System.Data.OleDb.OleDbParameter("Wundsekretion", System.Data.OleDb.OleDbType.VarChar, 0, "Wundsekretion"), New System.Data.OleDb.OleDbParameter("Sekretionsmenge", System.Data.OleDb.OleDbType.VarChar, 0, "Sekretionsmenge"), New System.Data.OleDb.OleDbParameter("Wundgeruch", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgeruch"), New System.Data.OleDb.OleDbParameter("WundrandIntakt", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandIntakt"), New System.Data.OleDb.OleDbParameter("WundrandMazeriert", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandMazeriert"), New System.Data.OleDb.OleDbParameter("WundrandUnterminiertZerklueftet", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandUnterminiertZerklueftet"), New System.Data.OleDb.OleDbParameter("WundrandGeroetet", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandGeroetet"), New System.Data.OleDb.OleDbParameter("WundrandHyperkeratose", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandHyperkeratose"), New System.Data.OleDb.OleDbParameter("WundumgebungIntakt", System.Data.OleDb.OleDbType.[Boolean], 0, "WundumgebungIntakt"), New System.Data.OleDb.OleDbParameter("WundumgebungTrockenPergamentartig", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungTrockenPergamentartig"), New System.Data.OleDb.OleDbParameter("WundumgebungEkzemOedemRoetung", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungEkzemOedemRoetung"), New System.Data.OleDb.OleDbParameter("WundumgebungSpannungsblase", System.Data.OleDb.OleDbType.[Boolean], 0, "WundumgebungSpannungsblase"), New System.Data.OleDb.OleDbParameter("Wundumgebung", System.Data.OleDb.OleDbType.VarChar, 0, "Wundumgebung"), New System.Data.OleDb.OleDbParameter("WundrandOedemoesWulstig", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandOedemoesWulstig")})
        '
        'OleDbCommand34
        '
        Me.OleDbCommand34.CommandText = "SELECT       WundePos.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM WundePos"
        Me.OleDbCommand34.Connection = Me.OleDbConnection1
        '
        'OleDbCommand35
        '
        Me.OleDbCommand35.CommandText = resources.GetString("OleDbCommand35.CommandText")
        Me.OleDbCommand35.Connection = Me.OleDbConnection1
        Me.OleDbCommand35.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDWundeKopf", System.Data.OleDb.OleDbType.Guid, 0, "IDWundeKopf"), New System.Data.OleDb.OleDbParameter("Erhebungszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Erhebungszeitpunkt"), New System.Data.OleDb.OleDbParameter("Stadium", System.Data.OleDb.OleDbType.[Integer], 0, "Stadium"), New System.Data.OleDb.OleDbParameter("Schmerzqualitaet", System.Data.OleDb.OleDbType.VarChar, 0, "Schmerzqualitaet"), New System.Data.OleDb.OleDbParameter("Schmerzintensitaet", System.Data.OleDb.OleDbType.[Integer], 0, "Schmerzintensitaet"), New System.Data.OleDb.OleDbParameter("NekroseJN", System.Data.OleDb.OleDbType.[Boolean], 0, "NekroseJN"), New System.Data.OleDb.OleDbParameter("Wundzustand", System.Data.OleDb.OleDbType.VarChar, 0, "Wundzustand"), New System.Data.OleDb.OleDbParameter("L", System.Data.OleDb.OleDbType.[Double], 0, "L"), New System.Data.OleDb.OleDbParameter("B", System.Data.OleDb.OleDbType.[Double], 0, "B"), New System.Data.OleDb.OleDbParameter("H", System.Data.OleDb.OleDbType.[Double], 0, "H"), New System.Data.OleDb.OleDbParameter("Erreger", System.Data.OleDb.OleDbType.VarChar, 0, "Erreger"), New System.Data.OleDb.OleDbParameter("Infektionszeichen", System.Data.OleDb.OleDbType.VarChar, 0, "Infektionszeichen"), New System.Data.OleDb.OleDbParameter("Heilungsverlauf", System.Data.OleDb.OleDbType.[Integer], 0, "Heilungsverlauf"), New System.Data.OleDb.OleDbParameter("Heilungstext", System.Data.OleDb.OleDbType.VarChar, 0, "Heilungstext"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("GranulationProz", System.Data.OleDb.OleDbType.[Integer], 0, "GranulationProz"), New System.Data.OleDb.OleDbParameter("EpithelisierungProz", System.Data.OleDb.OleDbType.[Integer], 0, "EpithelisierungProz"), New System.Data.OleDb.OleDbParameter("FistelnTaschen", System.Data.OleDb.OleDbType.VarChar, 0, "FistelnTaschen"), New System.Data.OleDb.OleDbParameter("Wundbelag", System.Data.OleDb.OleDbType.VarChar, 0, "Wundbelag"), New System.Data.OleDb.OleDbParameter("WundeFreiliegendeStrukturen", System.Data.OleDb.OleDbType.VarChar, 0, "WundeFreiliegendeStrukturen"), New System.Data.OleDb.OleDbParameter("Wundsekretion", System.Data.OleDb.OleDbType.VarChar, 0, "Wundsekretion"), New System.Data.OleDb.OleDbParameter("Sekretionsmenge", System.Data.OleDb.OleDbType.VarChar, 0, "Sekretionsmenge"), New System.Data.OleDb.OleDbParameter("Wundgeruch", System.Data.OleDb.OleDbType.VarChar, 0, "Wundgeruch"), New System.Data.OleDb.OleDbParameter("WundrandIntakt", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandIntakt"), New System.Data.OleDb.OleDbParameter("WundrandMazeriert", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandMazeriert"), New System.Data.OleDb.OleDbParameter("WundrandUnterminiertZerklueftet", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandUnterminiertZerklueftet"), New System.Data.OleDb.OleDbParameter("WundrandGeroetet", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandGeroetet"), New System.Data.OleDb.OleDbParameter("WundrandHyperkeratose", System.Data.OleDb.OleDbType.[Boolean], 0, "WundrandHyperkeratose"), New System.Data.OleDb.OleDbParameter("WundumgebungIntakt", System.Data.OleDb.OleDbType.[Boolean], 0, "WundumgebungIntakt"), New System.Data.OleDb.OleDbParameter("WundumgebungTrockenPergamentartig", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungTrockenPergamentartig"), New System.Data.OleDb.OleDbParameter("WundumgebungEkzemOedemRoetung", System.Data.OleDb.OleDbType.VarChar, 0, "WundumgebungEkzemOedemRoetung"), New System.Data.OleDb.OleDbParameter("WundumgebungSpannungsblase", System.Data.OleDb.OleDbType.[Boolean], 0, "WundumgebungSpannungsblase"), New System.Data.OleDb.OleDbParameter("Wundumgebung", System.Data.OleDb.OleDbType.VarChar, 0, "Wundumgebung"), New System.Data.OleDb.OleDbParameter("WundrandOedemoesWulstig", System.Data.OleDb.OleDbType.VarChar, 0, "WundrandOedemoesWulstig"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daWundePosBilder
        '
        Me.daWundePosBilder.DeleteCommand = Me.OleDbCommand24
        Me.daWundePosBilder.InsertCommand = Me.OleDbCommand32
        Me.daWundePosBilder.SelectCommand = Me.OleDbCommand37
        Me.daWundePosBilder.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "WundePosBilder", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDWundePos", "IDWundePos"), New System.Data.Common.DataColumnMapping("Bild", "Bild"), New System.Data.Common.DataColumnMapping("Thumbnail", "Thumbnail"), New System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"), New System.Data.Common.DataColumnMapping("druckenJN", "druckenJN"), New System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"), New System.Data.Common.DataColumnMapping("ZeitpunktBild", "ZeitpunktBild"), New System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"), New System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"), New System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"), New System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert")})})
        Me.daWundePosBilder.UpdateCommand = Me.OleDbCommand38
        '
        'OleDbCommand24
        '
        Me.OleDbCommand24.CommandText = resources.GetString("OleDbCommand24.CommandText")
        Me.OleDbCommand24.Connection = Me.OleDbConnection1
        Me.OleDbCommand24.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDWundePos", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Reihenfolge", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_druckenJN", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "druckenJN", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Beschreibung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ZeitpunktBild", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ZeitpunktBild", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_DatumErstellt", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "DatumErstellt", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DatumErstellt", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_DatumGeaendert", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "DatumGeaendert", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DatumGeaendert", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbCommand32
        '
        Me.OleDbCommand32.CommandText = resources.GetString("OleDbCommand32.CommandText")
        Me.OleDbCommand32.Connection = Me.OleDbConnection1
        Me.OleDbCommand32.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, "IDWundePos"), New System.Data.OleDb.OleDbParameter("Bild", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Bild"), New System.Data.OleDb.OleDbParameter("Thumbnail", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Thumbnail"), New System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.[Integer], 0, "Reihenfolge"), New System.Data.OleDb.OleDbParameter("druckenJN", System.Data.OleDb.OleDbType.[Boolean], 0, "druckenJN"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"), New System.Data.OleDb.OleDbParameter("ZeitpunktBild", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZeitpunktBild"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert")})
        '
        'OleDbCommand37
        '
        Me.OleDbCommand37.CommandText = "SELECT        WundePosBilder.*" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            WundePosBilder"
        Me.OleDbCommand37.Connection = Me.OleDbConnection1
        '
        'OleDbCommand38
        '
        Me.OleDbCommand38.CommandText = resources.GetString("OleDbCommand38.CommandText")
        Me.OleDbCommand38.Connection = Me.OleDbConnection1
        Me.OleDbCommand38.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, "IDWundePos"), New System.Data.OleDb.OleDbParameter("Bild", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Bild"), New System.Data.OleDb.OleDbParameter("Thumbnail", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Thumbnail"), New System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.[Integer], 0, "Reihenfolge"), New System.Data.OleDb.OleDbParameter("druckenJN", System.Data.OleDb.OleDbType.[Boolean], 0, "druckenJN"), New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"), New System.Data.OleDb.OleDbParameter("ZeitpunktBild", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "ZeitpunktBild"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"), New System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"), New System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumErstellt"), New System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumGeaendert"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDWundePos", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDWundePos", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Reihenfolge", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_druckenJN", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "druckenJN", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Beschreibung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ZeitpunktBild", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ZeitpunktBild", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_DatumErstellt", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "DatumErstellt", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DatumErstellt", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_DatumGeaendert", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "DatumGeaendert", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_DatumGeaendert", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "DatumGeaendert", System.Data.DataRowVersion.Original, Nothing)})

    End Sub
    Public WithEvents daBenutzer As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
    Public WithEvents daAbteilungen As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand7 As System.Data.OleDb.OleDbCommand
    Public WithEvents daBereiche As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand11 As System.Data.OleDb.OleDbCommand
    Public WithEvents daPatienten As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand15 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAufenthalte As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand19 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAufenthaltVerläufe As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand23 As System.Data.OleDb.OleDbCommand
    Public WithEvents daTasks As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand25 As System.Data.OleDb.OleDbCommand
    Public WithEvents daEintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand18 As System.Data.OleDb.OleDbCommand
    Public WithEvents daZusatzgruppeEintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand26 As System.Data.OleDb.OleDbCommand
    Public WithEvents daZusatzEintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand27 As System.Data.OleDb.OleDbCommand
    Public WithEvents daZusatzwert As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand28 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand As System.Data.OleDb.OleDbCommand
    Public WithEvents daAuswahlliste As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand2 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand5 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand8 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand6 As System.Data.OleDb.OleDbCommand
    Public WithEvents daPflegeplan As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand4 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand29 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand30 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand31 As System.Data.OleDb.OleDbCommand
    Public WithEvents daPflegeplanH As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand9 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand10 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand12 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand13 As System.Data.OleDb.OleDbCommand
    Public WithEvents daPflegeeintrag As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand14 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand16 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand17 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand20 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand1 As System.Data.OleDb.OleDbCommand
    Public WithEvents daQuickmeldung As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand3 As System.Data.OleDb.OleDbCommand
    Public WithEvents daAufenthaltPDX As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand21 As System.Data.OleDb.OleDbCommand
    Public WithEvents daWundeKopf As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand22 As System.Data.OleDb.OleDbCommand
    Public WithEvents daWundePos As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand36 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand33 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand34 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand35 As System.Data.OleDb.OleDbCommand
    Public WithEvents daWundePosBilder As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbCommand24 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand32 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand37 As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbCommand38 As System.Data.OleDb.OleDbCommand

End Class
