Partial Class compSql
    Inherits System.ComponentModel.Component

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Erforderlich für die Unterstützung des Windows.Forms-Klassenkompositions-Designers
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compSql))
        Me.daPatientByID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_PatientByID = New System.Data.OleDb.OleDbCommand()
        Me.daDokumenteGelesen_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.daAlleDokumenteGelesenJN = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN = New System.Data.OleDb.OleDbCommand()
        Me.daAlleDokumenteGelesenJaNein = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein = New System.Data.OleDb.OleDbCommand()
        Me.daDokumente_IDDokueintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag = New System.Data.OleDb.OleDbCommand()
        Me.daDokumenteintrag_anzahl = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Dokumenteintrag_anzahl = New System.Data.OleDb.OleDbCommand()
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
        Me.dbConn = New System.Data.OleDb.OleDbConnection()
        Me.daPfad = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Pfad = New System.Data.OleDb.OleDbCommand()
        Me.daRechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe = New System.Data.OleDb.OleDbCommand()
        Me.daRechteOrdner_IDOrdner = New System.Data.OleDb.OleDbDataAdapter()
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner = New System.Data.OleDb.OleDbCommand()
        Me.daSchränkeAlle = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Schränke = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Schränke = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Schränke = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Schränke = New System.Data.OleDb.OleDbCommand()
        Me.daFächer_IDSchrank = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Fächer_IDSchrank = New System.Data.OleDb.OleDbCommand()
        Me.daOrdner_IDFach = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Ordner_IDFach = New System.Data.OleDb.OleDbCommand()
        Me.daFächer_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Fächer_ID = New System.Data.OleDb.OleDbCommand()
        Me.daSchrank_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Schrank_ID = New System.Data.OleDb.OleDbCommand()
        Me.daAlleDateienPapierkorb = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_AlleDateienPapierkorb = New System.Data.OleDb.OleDbCommand()
        Me.daDokumentendaten_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.daSchlagwort_IDThema = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Schlagwort_IDThema = New System.Data.OleDb.OleDbCommand()
        Me.daThema_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Thema_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Thema_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Thema_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Thema_ID = New System.Data.OleDb.OleDbCommand()
        Me.daSchlagwort_All = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Schlagwort_All = New System.Data.OleDb.OleDbCommand()
        Me.daDokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag = New System.Data.OleDb.OleDbCommand()
        Me.daDokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID = New System.Data.OleDb.OleDbCommand()
        Me.daSchlagwort_ID = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbSelectCommand_Schlagwort_ID = New System.Data.OleDb.OleDbCommand()
        Me.daThema_All = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_Thema_All = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_Thema_All = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_Thema_All = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_Thema_All = New System.Data.OleDb.OleDbCommand()
        Me.daObjects_IDDokumenteintrag = New System.Data.OleDb.OleDbDataAdapter()
        Me.OleDbDeleteCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbInsertCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbSelectCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand()
        Me.OleDbUpdateCommand_IDDokumenteintrag = New System.Data.OleDb.OleDbCommand()
        '
        'daPatientByID
        '
        Me.daPatientByID.SelectCommand = Me.OleDbSelectCommand_PatientByID
        Me.daPatientByID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Abteilung", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"), New System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"), New System.Data.Common.DataColumnMapping("Titel", "Titel"), New System.Data.Common.DataColumnMapping("Sexus", "Sexus"), New System.Data.Common.DataColumnMapping("Konfision", "Konfision"), New System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"), New System.Data.Common.DataColumnMapping("Staatsb", "Staatsb"), New System.Data.Common.DataColumnMapping("Klasse", "Klasse"), New System.Data.Common.DataColumnMapping("KrankenKasse", "KrankenKasse"), New System.Data.Common.DataColumnMapping("BlutGruppe", "BlutGruppe"), New System.Data.Common.DataColumnMapping("Resusfaktor", "Resusfaktor"), New System.Data.Common.DataColumnMapping("LedigerName", "LedigerName"), New System.Data.Common.DataColumnMapping("Geburtsort", "Geburtsort"), New System.Data.Common.DataColumnMapping("Voraufenthalt", "Voraufenthalt"), New System.Data.Common.DataColumnMapping("Angehörige", "Angehörige"), New System.Data.Common.DataColumnMapping("VersicherungsNr", "VersicherungsNr"), New System.Data.Common.DataColumnMapping("ArbeitslosBezSeit", "ArbeitslosBezSeit"), New System.Data.Common.DataColumnMapping("KrankengeldSeit", "KrankengeldSeit"), New System.Data.Common.DataColumnMapping("Hauptversicherung", "Hauptversicherung"), New System.Data.Common.DataColumnMapping("ErlernterBeruf", "ErlernterBeruf"), New System.Data.Common.DataColumnMapping("Besonderheit", "Besonderheit"), New System.Data.Common.DataColumnMapping("Betreuer", "Betreuer"), New System.Data.Common.DataColumnMapping("Sachwalter", "Sachwalter"), New System.Data.Common.DataColumnMapping("SachWalterBelange", "SachWalterBelange"), New System.Data.Common.DataColumnMapping("SachWalterVon", "SachWalterVon"), New System.Data.Common.DataColumnMapping("SachWalterBis", "SachWalterBis"), New System.Data.Common.DataColumnMapping("SterbeRegel", "SterbeRegel"), New System.Data.Common.DataColumnMapping("Depotinjektion", "Depotinjektion"), New System.Data.Common.DataColumnMapping("Hausarzt", "Hausarzt"), New System.Data.Common.DataColumnMapping("Vermerk", "Vermerk"), New System.Data.Common.DataColumnMapping("SterbeDatum", "SterbeDatum"), New System.Data.Common.DataColumnMapping("AktuellerDienstgeber", "AktuellerDienstgeber"), New System.Data.Common.DataColumnMapping("DerzeitigerBeruf", "DerzeitigerBeruf"), New System.Data.Common.DataColumnMapping("RezeptgebuehrbefreiungJN", "RezeptgebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("PflegegeldantragJN", "PflegegeldantragJN"), New System.Data.Common.DataColumnMapping("DatumPflegegeldantrag", "DatumPflegegeldantrag"), New System.Data.Common.DataColumnMapping("PensionsteilungsantragJN", "PensionsteilungsantragJN"), New System.Data.Common.DataColumnMapping("DatumPensionsteilungsantrag", "DatumPensionsteilungsantrag"), New System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"), New System.Data.Common.DataColumnMapping("RollungVon", "RollungVon"), New System.Data.Common.DataColumnMapping("RollungBis", "RollungBis"), New System.Data.Common.DataColumnMapping("Adelstitel", "Adelstitel"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("Initialberuehrung", "Initialberuehrung"), New System.Data.Common.DataColumnMapping("Klingeln", "Klingeln"), New System.Data.Common.DataColumnMapping("Wohnsituation", "Wohnsituation"), New System.Data.Common.DataColumnMapping("Haustier", "Haustier"), New System.Data.Common.DataColumnMapping("LiftJN", "LiftJN"), New System.Data.Common.DataColumnMapping("WohnungAbgemeldetJN", "WohnungAbgemeldetJN"), New System.Data.Common.DataColumnMapping("Haarfarbe", "Haarfarbe"), New System.Data.Common.DataColumnMapping("Augenfarbe", "Augenfarbe"), New System.Data.Common.DataColumnMapping("BesondereAeusserlicheKennzeichen", "BesondereAeusserlicheKennzeichen"), New System.Data.Common.DataColumnMapping("Foto", "Foto"), New System.Data.Common.DataColumnMapping("FernsehgebuehrbefreiungJN", "FernsehgebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("TelefongebuehrbefreiungJN", "TelefongebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("BewerberJN", "BewerberJN"), New System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"), New System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"), New System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"), New System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"), New System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"), New System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"), New System.Data.Common.DataColumnMapping("Stationswunsch", "Stationswunsch"), New System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"), New System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"), New System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"), New System.Data.Common.DataColumnMapping("ReligionWunsch", "ReligionWunsch"), New System.Data.Common.DataColumnMapping("KommunionJN", "KommunionJN"), New System.Data.Common.DataColumnMapping("KrankensalbungJN", "KrankensalbungJN"), New System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"), New System.Data.Common.DataColumnMapping("WaescheMarkiert", "WaescheMarkiert"), New System.Data.Common.DataColumnMapping("WaescheWaschen", "WaescheWaschen"), New System.Data.Common.DataColumnMapping("Zustaendige_Stelle", "Zustaendige_Stelle"), New System.Data.Common.DataColumnMapping("Groesse", "Groesse"), New System.Data.Common.DataColumnMapping("Statur", "Statur"), New System.Data.Common.DataColumnMapping("Namenstag", "Namenstag"), New System.Data.Common.DataColumnMapping("Kosename", "Kosename"), New System.Data.Common.DataColumnMapping("Privatversicherung", "Privatversicherung"), New System.Data.Common.DataColumnMapping("PrivPolNr", "PrivPolNr"), New System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"), New System.Data.Common.DataColumnMapping("PatientenverfuegungJN", "PatientenverfuegungJN"), New System.Data.Common.DataColumnMapping("PatientenverfuegungBeachtlichJN", "PatientenverfuegungBeachtlichJN"), New System.Data.Common.DataColumnMapping("PatientverfuegungDatum", "PatientverfuegungDatum"), New System.Data.Common.DataColumnMapping("PatientverfuegungAnmerkung", "PatientverfuegungAnmerkung"), New System.Data.Common.DataColumnMapping("Klientennummer", "Klientennummer"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("abwesenheitenHändBerech", "abwesenheitenHändBerech"), New System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("Plz", "Plz"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("LandKZ", "LandKZ"), New System.Data.Common.DataColumnMapping("Tel", "Tel"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("Mobil", "Mobil"), New System.Data.Common.DataColumnMapping("Andere", "Andere"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"), New System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"), New System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"), New System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("IDAdresse1", "IDAdresse1"), New System.Data.Common.DataColumnMapping("IDKontakt1", "IDKontakt1")})})
        '
        'OleDbSelectCommand_PatientByID
        '
        Me.OleDbSelectCommand_PatientByID.CommandText = resources.GetString("OleDbSelectCommand_PatientByID.CommandText")
        Me.OleDbSelectCommand_PatientByID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")})
        '
        'daDokumenteGelesen_IDDokumenteneintrag
        '
        Me.daDokumenteGelesen_IDDokumenteneintrag.DeleteCommand = Me.OleDbDeleteCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.InsertCommand = Me.OleDbInsertCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteneintrag
        Me.daDokumenteGelesen_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumenteGelesen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen")})})
        Me.daDokumenteGelesen_IDDokumenteneintrag.UpdateCommand = Me.OleDbUpdateCommand_IDDokumenteneintrag
        '
        'OleDbDeleteCommand_IDDokumenteneintrag
        '
        Me.OleDbDeleteCommand_IDDokumenteneintrag.CommandText = "DELETE FROM [tblDokumenteGelesen] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_IDDokumenteneintrag
        '
        Me.OleDbInsertCommand_IDDokumenteneintrag.CommandText = "INSERT INTO [tblDokumenteGelesen] ([ID], [IDDokumenteneintrag], [gelesen]) VALUES" &
    " (?, ?, ?)"
        Me.OleDbInsertCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 0, "gelesen")})
        '
        'OleDbSelectCommand_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_IDDokumenteneintrag.CommandText = "SELECT     ID, IDDokumenteneintrag, gelesen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblDokumenteGelesen" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WH" &
    "ERE     (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'OleDbUpdateCommand_IDDokumenteneintrag
        '
        Me.OleDbUpdateCommand_IDDokumenteneintrag.CommandText = "UPDATE [tblDokumenteGelesen] SET [ID] = ?, [IDDokumenteneintrag] = ?, [gelesen] =" &
    " ? WHERE (([ID] = ?))"
        Me.OleDbUpdateCommand_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 0, "gelesen"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAlleDokumenteGelesenJN
        '
        Me.daAlleDokumenteGelesenJN.SelectCommand = Me.OleDbSelectCommand_AlleDokumenteGelesenJN
        Me.daAlleDokumenteGelesenJN.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("BezeichnungOrdner", "BezeichnungOrdner"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp")})})
        '
        'OleDbSelectCommand_AlleDokumenteGelesenJN
        '
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN.CommandText = resources.GetString("OleDbSelectCommand_AlleDokumenteGelesenJN.CommandText")
        Me.OleDbSelectCommand_AlleDokumenteGelesenJN.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 1, "gelesen")})
        '
        'daAlleDokumenteGelesenJaNein
        '
        Me.daAlleDokumenteGelesenJaNein.SelectCommand = Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein
        Me.daAlleDokumenteGelesenJaNein.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDDokumenteneintrag", "IDDokumenteneintrag"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("gelesen", "gelesen")})})
        '
        'OleDbSelectCommand_AlleDokumenteGelesenJaNein
        '
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.CommandText = resources.GetString("OleDbSelectCommand_AlleDokumenteGelesenJaNein.CommandText")
        Me.OleDbSelectCommand_AlleDokumenteGelesenJaNein.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("gelesen", System.Data.OleDb.OleDbType.[Boolean], 1, "gelesen")})
        '
        'daDokumente_IDDokueintrag
        '
        Me.daDokumente_IDDokueintrag.SelectCommand = Me.OleDbSelectCommand_Dokumente_IDDokueintrag
        Me.daDokumente_IDDokueintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("DateinameOrig", "DateinameOrig"), New System.Data.Common.DataColumnMapping("VerzeichnisOrig", "VerzeichnisOrig"), New System.Data.Common.DataColumnMapping("DokumentGröße", "DokumentGröße"), New System.Data.Common.DataColumnMapping("DokumentErstellt", "DokumentErstellt"), New System.Data.Common.DataColumnMapping("DokumentGeändert", "DokumentGeändert"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("Winzip", "Winzip"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp")})})
        '
        'OleDbSelectCommand_Dokumente_IDDokueintrag
        '
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag.CommandText = resources.GetString("OleDbSelectCommand_Dokumente_IDDokueintrag.CommandText")
        Me.OleDbSelectCommand_Dokumente_IDDokueintrag.Connection = Me.dbConn
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
        Me.OleDbDeleteCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Dokumenteintrag_ID
        '
        Me.OleDbInsertCommand_Dokumenteintrag_ID.CommandText = "INSERT INTO [tblDokumenteintrag] ([ID], [IDOrdner], [Bezeichnung], [Notiz], [Noti" &
    "zRTF], [GültigVon], [GültigBis], [Wichtigkeit], [ErstelltAm], [ErstelltVon]) VAL" &
    "UES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("NotizRTF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "NotizRTF"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 16, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 16, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon")})
        '
        'OleDbSelectCommand_Dokumenteintrag_ID
        '
        Me.OleDbSelectCommand_Dokumenteintrag_ID.CommandText = "SELECT        ID, IDOrdner, Bezeichnung, Notiz, NotizRTF, GültigVon, GültigBis, W" &
    "ichtigkeit, ErstelltAm, ErstelltVon" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            tblDokumenteintrag" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE  " &
    "      (ID = ?)"
        Me.OleDbSelectCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Dokumenteintrag_ID
        '
        Me.OleDbUpdateCommand_Dokumenteintrag_ID.CommandText = resources.GetString("OleDbUpdateCommand_Dokumenteintrag_ID.CommandText")
        Me.OleDbUpdateCommand_Dokumenteintrag_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("Notiz", System.Data.OleDb.OleDbType.VarChar, 0, "Notiz"), New System.Data.OleDb.OleDbParameter("NotizRTF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "NotizRTF"), New System.Data.OleDb.OleDbParameter("GültigVon", System.Data.OleDb.OleDbType.Date, 16, "GültigVon"), New System.Data.OleDb.OleDbParameter("GültigBis", System.Data.OleDb.OleDbType.Date, 16, "GültigBis"), New System.Data.OleDb.OleDbParameter("Wichtigkeit", System.Data.OleDb.OleDbType.VarChar, 0, "Wichtigkeit"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Dokumente_ID
        '
        Me.OleDbInsertCommand_Dokumente_ID.CommandText = resources.GetString("OleDbInsertCommand_Dokumente_ID.CommandText")
        Me.OleDbInsertCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("DateinameOrig", System.Data.OleDb.OleDbType.VarChar, 300, "DateinameOrig"), New System.Data.OleDb.OleDbParameter("VerzeichnisOrig", System.Data.OleDb.OleDbType.VarChar, 500, "VerzeichnisOrig"), New System.Data.OleDb.OleDbParameter("DokumentGröße", System.Data.OleDb.OleDbType.[Double], 8, "DokumentGröße"), New System.Data.OleDb.OleDbParameter("DokumentErstellt", System.Data.OleDb.OleDbType.Date, 8, "DokumentErstellt"), New System.Data.OleDb.OleDbParameter("DokumentGeändert", System.Data.OleDb.OleDbType.Date, 8, "DokumentGeändert"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 1, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 100, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 150, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 50, "DateinameTyp")})
        '
        'OleDbSelectCommand_Dokumente_ID
        '
        Me.OleDbSelectCommand_Dokumente_ID.CommandText = resources.GetString("OleDbSelectCommand_Dokumente_ID.CommandText")
        Me.OleDbSelectCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Dokumente_ID
        '
        Me.OleDbUpdateCommand_Dokumente_ID.CommandText = resources.GetString("OleDbUpdateCommand_Dokumente_ID.CommandText")
        Me.OleDbUpdateCommand_Dokumente_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("DateinameOrig", System.Data.OleDb.OleDbType.VarChar, 300, "DateinameOrig"), New System.Data.OleDb.OleDbParameter("VerzeichnisOrig", System.Data.OleDb.OleDbType.VarChar, 500, "VerzeichnisOrig"), New System.Data.OleDb.OleDbParameter("DokumentGröße", System.Data.OleDb.OleDbType.[Double], 8, "DokumentGröße"), New System.Data.OleDb.OleDbParameter("DokumentErstellt", System.Data.OleDb.OleDbType.Date, 8, "DokumentErstellt"), New System.Data.OleDb.OleDbParameter("DokumentGeändert", System.Data.OleDb.OleDbType.Date, 8, "DokumentGeändert"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Winzip", System.Data.OleDb.OleDbType.[Boolean], 1, "Winzip"), New System.Data.OleDb.OleDbParameter("Archivordner", System.Data.OleDb.OleDbType.VarChar, 100, "Archivordner"), New System.Data.OleDb.OleDbParameter("DateinameArchiv", System.Data.OleDb.OleDbType.VarChar, 150, "DateinameArchiv"), New System.Data.OleDb.OleDbParameter("DateinameTyp", System.Data.OleDb.OleDbType.VarChar, 50, "DateinameTyp"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'dbConn
        '
        Me.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\SQL2008R2;Integrated Security=SSPI;Initi" &
    "al Catalog=PMDSDev"
        '
        'daPfad
        '
        Me.daPfad.DeleteCommand = Me.OleDbDeleteCommand_Pfad
        Me.daPfad.InsertCommand = Me.OleDbInsertCommand_Pfad
        Me.daPfad.SelectCommand = Me.OleDbSelectCommand_Pfad
        Me.daPfad.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblPfad", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Archivpfad", "Archivpfad")})})
        Me.daPfad.UpdateCommand = Me.OleDbUpdateCommand_Pfad
        '
        'OleDbDeleteCommand_Pfad
        '
        Me.OleDbDeleteCommand_Pfad.CommandText = "DELETE FROM [tblPfad] WHERE (([Archivpfad] = ?))"
        Me.OleDbDeleteCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Archivpfad", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Pfad
        '
        Me.OleDbInsertCommand_Pfad.CommandText = "INSERT INTO [tblPfad] ([Archivpfad]) VALUES (?)"
        Me.OleDbInsertCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, "Archivpfad")})
        '
        'OleDbSelectCommand_Pfad
        '
        Me.OleDbSelectCommand_Pfad.CommandText = "SELECT Archivpfad FROM tblPfad"
        '
        'OleDbUpdateCommand_Pfad
        '
        Me.OleDbUpdateCommand_Pfad.CommandText = "UPDATE [tblPfad] SET [Archivpfad] = ? WHERE (([Archivpfad] = ?))"
        Me.OleDbUpdateCommand_Pfad.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, "Archivpfad"), New System.Data.OleDb.OleDbParameter("Original_Archivpfad", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Archivpfad", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daRechteOrdner_IDOrdnerIDGruppe
        '
        Me.daRechteOrdner_IDOrdnerIDGruppe.DeleteCommand = Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.InsertCommand = Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.SelectCommand = Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
        Me.daRechteOrdner_IDOrdnerIDGruppe.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblRechteOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe")})})
        Me.daRechteOrdner_IDOrdnerIDGruppe.UpdateCommand = Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        'OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "DELETE FROM [tblRechteOrdner] WHERE (([ID] = ?))"
        Me.OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "INSERT INTO [tblRechteOrdner] ([ID], [IDOrdner], [IDGruppe]) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDGruppe")})
        '
        'OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "SELECT     ID, IDOrdner, IDGruppe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblRechteOrdner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE     (IDOrd" &
    "ner = ?) AND (IDGruppe = ?)"
        Me.OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")})
        '
        'OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe
        '
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.CommandText = "UPDATE [tblRechteOrdner] SET [ID] = ?, [IDOrdner] = ?, [IDGruppe] = ? WHERE (([ID" &
    "] = ?))"
        Me.OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 0, "IDOrdner"), New System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDGruppe"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daRechteOrdner_IDOrdner
        '
        Me.daRechteOrdner_IDOrdner.SelectCommand = Me.OLEBSelectCommand_RechteOrdner_IDOrdner
        Me.daRechteOrdner_IDOrdner.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblRechteOrdner", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe")})})
        '
        'OLEBSelectCommand_RechteOrdner_IDOrdner
        '
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner.CommandText = "SELECT     ID, IDOrdner, IDGruppe" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM         tblRechteOrdner" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE     (IDOrd" &
    "ner = ?)"
        Me.OLEBSelectCommand_RechteOrdner_IDOrdner.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDOrdner", System.Data.OleDb.OleDbType.Guid, 16, "IDOrdner")})
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
        Me.OleDbDeleteCommand_Schränke.CommandText = "DELETE FROM [tblSchrank] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([Erstellt" &
    "Am] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Schränke
        '
        Me.OleDbInsertCommand_Schränke.CommandText = "INSERT INTO [tblSchrank] ([ID], [Bezeichnung], [ErstelltAm], [ErstelltVon], [Exte" &
    "rn]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Schränke
        '
        Me.OleDbSelectCommand_Schränke.CommandText = "SELECT ID, Bezeichnung, ErstelltAm, ErstelltVon, Extern FROM tblSchrank ORDER BY " &
    "Bezeichnung asc"
        '
        'OleDbUpdateCommand_Schränke
        '
        Me.OleDbUpdateCommand_Schränke.CommandText = resources.GetString("OleDbUpdateCommand_Schränke.CommandText")
        Me.OleDbUpdateCommand_Schränke.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Fächer_IDSchrank.CommandText = "DELETE FROM [tblFach] WHERE (([ID] = ?) AND ([Bezeichnung] = ?) AND ([IDSchrank] " &
    "= ?) AND ([ErstelltAm] = ?) AND ([ErstelltVon] = ?) AND ([Extern] = ?))"
        Me.OleDbDeleteCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Fächer_IDSchrank
        '
        Me.OleDbInsertCommand_Fächer_IDSchrank.CommandText = "INSERT INTO [tblFach] ([ID], [Bezeichnung], [IDSchrank], [ErstelltAm], [ErstelltV" &
    "on], [Extern]) VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Fächer_IDSchrank
        '
        Me.OleDbSelectCommand_Fächer_IDSchrank.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" &
    "HERE (IDSchrank = ?) ORDER BY Bezeichnung asc"
        Me.OleDbSelectCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank")})
        '
        'OleDbUpdateCommand_Fächer_IDSchrank
        '
        Me.OleDbUpdateCommand_Fächer_IDSchrank.CommandText = resources.GetString("OleDbUpdateCommand_Fächer_IDSchrank.CommandText")
        Me.OleDbUpdateCommand_Fächer_IDSchrank.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Bezeichnung", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDSchrank", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDSchrank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltAm", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ErstelltVon", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Extern", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extern", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Ordner_IDFach
        '
        Me.OleDbInsertCommand_Ordner_IDFach.CommandText = "INSERT INTO [tblOrdner] ([ID], [Bezeichnung], [IDFach], [ErstelltAm], [ErstelltVo" &
    "n], [Icon], [Extern], [IDSystemordner]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 0, "IDFach"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner")})
        '
        'OleDbSelectCommand_Ordner_IDFach
        '
        Me.OleDbSelectCommand_Ordner_IDFach.CommandText = "SELECT ID, Bezeichnung, IDFach, ErstelltAm, ErstelltVon, Icon, Extern, IDSystemor" &
    "dner   FROM tblOrdner WHERE (IDFach = ?) ORDER BY Bezeichnung"
        Me.OleDbSelectCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 16, "IDFach")})
        '
        'OleDbUpdateCommand_Ordner_IDFach
        '
        Me.OleDbUpdateCommand_Ordner_IDFach.CommandText = "UPDATE [tblOrdner] SET [ID] = ?, [Bezeichnung] = ?, [IDFach] = ?, [ErstelltAm] = " &
    "?, [ErstelltVon] = ?, [Icon] = ?, [Extern] = ?, [IDSystemordner] = ? WHERE (([ID" &
    "] = ?))"
        Me.OleDbUpdateCommand_Ordner_IDFach.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDFach", System.Data.OleDb.OleDbType.Guid, 0, "IDFach"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("IDSystemordner", System.Data.OleDb.OleDbType.[Integer], 0, "IDSystemordner"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Fächer_ID
        '
        Me.OleDbInsertCommand_Fächer_ID.CommandText = "INSERT INTO tblFach(ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern) " &
    "VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern")})
        '
        'OleDbSelectCommand_Fächer_ID
        '
        Me.OleDbSelectCommand_Fächer_ID.CommandText = "SELECT ID, Bezeichnung, IDSchrank, ErstelltAm, ErstelltVon, Extern FROM tblFach W" &
    "HERE (ID = ?)"
        Me.OleDbSelectCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Fächer_ID
        '
        Me.OleDbUpdateCommand_Fächer_ID.CommandText = "UPDATE tblFach SET ID = ?, Bezeichnung = ?, IDSchrank = ?, ErstelltAm = ?, Erstel" &
    "ltVon = ?, Extern = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Fächer_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 300, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("IDSchrank", System.Data.OleDb.OleDbType.Guid, 16, "IDSchrank"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 1, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Schrank_ID
        '
        Me.OleDbInsertCommand_Schrank_ID.CommandText = "INSERT INTO [tblSchrank] ([ID], [Bezeichnung], [ErstelltAm], [ErstelltVon], [Exte" &
    "rn]) VALUES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern")})
        '
        'OleDbSelectCommand_Schrank_ID
        '
        Me.OleDbSelectCommand_Schrank_ID.CommandText = "SELECT ID, Bezeichnung, ErstelltAm, ErstelltVon, Extern FROM tblSchrank WHERE (ID" &
    " = ?)"
        Me.OleDbSelectCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Schrank_ID
        '
        Me.OleDbUpdateCommand_Schrank_ID.CommandText = "UPDATE [tblSchrank] SET [ID] = ?, [Bezeichnung] = ?, [ErstelltAm] = ?, [ErstelltV" &
    "on] = ?, [Extern] = ? WHERE (([ID] = ?))"
        Me.OleDbUpdateCommand_Schrank_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 0, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Extern", System.Data.OleDb.OleDbType.[Boolean], 0, "Extern"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daAlleDateienPapierkorb
        '
        Me.daAlleDateienPapierkorb.SelectCommand = Me.OleDbSelectCommand_AlleDateienPapierkorb
        Me.daAlleDateienPapierkorb.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDSystemordner", "IDSystemordner"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("IDDokumente", "IDDokumente")})})
        '
        'OleDbSelectCommand_AlleDateienPapierkorb
        '
        Me.OleDbSelectCommand_AlleDateienPapierkorb.CommandText = resources.GetString("OleDbSelectCommand_AlleDateienPapierkorb.CommandText")
        '
        'daDokumentendaten_IDDokumenteneintrag
        '
        Me.daDokumentendaten_IDDokumenteneintrag.SelectCommand = Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
        Me.daDokumentendaten_IDDokumenteneintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblDokumente", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDOrdner", "IDOrdner"), New System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"), New System.Data.Common.DataColumnMapping("Notiz", "Notiz"), New System.Data.Common.DataColumnMapping("GültigVon", "GültigVon"), New System.Data.Common.DataColumnMapping("GültigBis", "GültigBis"), New System.Data.Common.DataColumnMapping("Wichtigkeit", "Wichtigkeit"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon"), New System.Data.Common.DataColumnMapping("BezeichnungOrdner", "BezeichnungOrdner"), New System.Data.Common.DataColumnMapping("DateinameArchiv", "DateinameArchiv"), New System.Data.Common.DataColumnMapping("DateinameTyp", "DateinameTyp"), New System.Data.Common.DataColumnMapping("Archivordner", "Archivordner"), New System.Data.Common.DataColumnMapping("DokumentGröße", "DokumentGröße"), New System.Data.Common.DataColumnMapping("IDDokument", "IDDokument"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("IDFach", "IDFach")})})
        '
        'OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandText = resources.GetString("OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.CommandText")
        Me.OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")})
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
        Me.OleDbDeleteCommand_Schlagwort_IDThema.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Schlagwort_IDThema
        '
        Me.OleDbInsertCommand_Schlagwort_IDThema.CommandText = "INSERT INTO tblSchlagwörter(ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon) VAL" &
    "UES (?, ?, ?, ?, ?)"
        Me.OleDbInsertCommand_Schlagwort_IDThema.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema"), New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 300, "Schlagwort"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon")})
        '
        'OleDbSelectCommand_Schlagwort_IDThema
        '
        Me.OleDbSelectCommand_Schlagwort_IDThema.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter WHER" &
    "E (IDThema = ?) ORDER BY Schlagwort"
        Me.OleDbSelectCommand_Schlagwort_IDThema.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema")})
        '
        'OleDbUpdateCommand_Schlagwort_IDThema
        '
        Me.OleDbUpdateCommand_Schlagwort_IDThema.CommandText = "UPDATE tblSchlagwörter SET ID = ?, IDThema = ?, Schlagwort = ?, ErstelltAm = ?, E" &
    "rstelltVon = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Schlagwort_IDThema.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDThema", System.Data.OleDb.OleDbType.Guid, 16, "IDThema"), New System.Data.OleDb.OleDbParameter("Schlagwort", System.Data.OleDb.OleDbType.VarChar, 300, "Schlagwort"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_Thema_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Thema_ID
        '
        Me.OleDbInsertCommand_Thema_ID.CommandText = "INSERT INTO tblThemen(ID, Thema, ErstelltAm, ErstelltVon) VALUES (?, ?, ?, ?)"
        Me.OleDbInsertCommand_Thema_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon")})
        '
        'OleDbSelectCommand_Thema_ID
        '
        Me.OleDbSelectCommand_Thema_ID.CommandText = "SELECT ID, Thema, ErstelltAm, ErstelltVon FROM tblThemen WHERE (ID = ?)"
        Me.OleDbSelectCommand_Thema_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
        '
        'OleDbUpdateCommand_Thema_ID
        '
        Me.OleDbUpdateCommand_Thema_ID.CommandText = "UPDATE tblThemen SET ID = ?, Thema = ?, ErstelltAm = ?, ErstelltVon = ? WHERE (ID" &
    " = ?)"
        Me.OleDbUpdateCommand_Thema_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSchlagwort_All
        '
        Me.daSchlagwort_All.SelectCommand = Me.OleDbSelectCommand_Schlagwort_All
        Me.daSchlagwort_All.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDThema", "IDThema"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        '
        'OleDbSelectCommand_Schlagwort_All
        '
        Me.OleDbSelectCommand_Schlagwort_All.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter ORDE" &
    "R BY Schlagwort"
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
        Me.OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "INSERT INTO tblDokumenteneintragSchlagwörter(ID, IDSchlagwort, IDDokumenteneintra" &
    "g) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "SELECT ID, IDSchlagwort, IDDokumenteneintrag FROM tblDokumenteneintragSchlagwörte" &
    "r WHERE (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag
        '
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.CommandText = "UPDATE tblDokumenteneintragSchlagwörter SET ID = ?, IDSchlagwort = ?, IDDokumente" &
    "neintrag = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
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
        Me.OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.CommandText = "INSERT INTO tblDokumenteneintragSchlagwörter(ID, IDSchlagwort, IDDokumenteneintra" &
    "g) VALUES (?, ?, ?)"
        Me.OleDbInsertCommand_DokumenteneintragSchlagwörter_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'OleDbSelectCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.CommandText = "SELECT ID, IDSchlagwort, IDDokumenteneintrag FROM tblDokumenteneintragSchlagwörte" &
    "r WHERE (IDDokumenteneintrag = ?)"
        Me.OleDbSelectCommand_DokumenteneintragSchlagwörter_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag")})
        '
        'OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID
        '
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.CommandText = "UPDATE tblDokumenteneintragSchlagwörter SET ID = ?, IDSchlagwort = ?, IDDokumente" &
    "neintrag = ? WHERE (ID = ?)"
        Me.OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("IDSchlagwort", System.Data.OleDb.OleDbType.Guid, 16, "IDSchlagwort"), New System.Data.OleDb.OleDbParameter("IDDokumenteneintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteneintrag"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daSchlagwort_ID
        '
        Me.daSchlagwort_ID.SelectCommand = Me.OleDbSelectCommand_Schlagwort_ID
        Me.daSchlagwort_ID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblSchlagwörter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDThema", "IDThema"), New System.Data.Common.DataColumnMapping("Schlagwort", "Schlagwort"), New System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"), New System.Data.Common.DataColumnMapping("ErstelltVon", "ErstelltVon")})})
        '
        'OleDbSelectCommand_Schlagwort_ID
        '
        Me.OleDbSelectCommand_Schlagwort_ID.CommandText = "SELECT ID, IDThema, Schlagwort, ErstelltAm, ErstelltVon FROM tblSchlagwörter WHER" &
    "E (ID = ?)"
        Me.OleDbSelectCommand_Schlagwort_ID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")})
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
        Me.OleDbDeleteCommand_Thema_All.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_Thema_All
        '
        Me.OleDbInsertCommand_Thema_All.CommandText = "INSERT INTO tblThemen(ID, Thema, ErstelltAm, ErstelltVon) VALUES (?, ?, ?, ?)"
        Me.OleDbInsertCommand_Thema_All.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon")})
        '
        'OleDbSelectCommand_Thema_All
        '
        Me.OleDbSelectCommand_Thema_All.CommandText = "SELECT ID, Thema, ErstelltAm, ErstelltVon FROM tblThemen ORDER BY Thema"
        '
        'OleDbUpdateCommand_Thema_All
        '
        Me.OleDbUpdateCommand_Thema_All.CommandText = "UPDATE tblThemen SET ID = ?, Thema = ?, ErstelltAm = ?, ErstelltVon = ? WHERE (ID" &
    " = ?)"
        Me.OleDbUpdateCommand_Thema_All.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"), New System.Data.OleDb.OleDbParameter("Thema", System.Data.OleDb.OleDbType.VarChar, 300, "Thema"), New System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 8, "ErstelltAm"), New System.Data.OleDb.OleDbParameter("ErstelltVon", System.Data.OleDb.OleDbType.VarChar, 100, "ErstelltVon"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing)})
        '
        'daObjects_IDDokumenteintrag
        '
        Me.daObjects_IDDokumenteintrag.DeleteCommand = Me.OleDbDeleteCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.InsertCommand = Me.OleDbInsertCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.SelectCommand = Me.OleDbSelectCommand_IDDokumenteintrag
        Me.daObjects_IDDokumenteintrag.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "tblObjekt", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("ID", "ID"), New System.Data.Common.DataColumnMapping("IDDokumenteintrag", "IDDokumenteintrag"), New System.Data.Common.DataColumnMapping("Datenbankidentität", "Datenbankidentität"), New System.Data.Common.DataColumnMapping("Server", "Server"), New System.Data.Common.DataColumnMapping("Datenbank", "Datenbank"), New System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"), New System.Data.Common.DataColumnMapping("Passwort", "Passwort"), New System.Data.Common.DataColumnMapping("IDTyp", "IDTyp"), New System.Data.Common.DataColumnMapping("ID_guid", "ID_guid"), New System.Data.Common.DataColumnMapping("ID_str", "ID_str"), New System.Data.Common.DataColumnMapping("ID_int", "ID_int"), New System.Data.Common.DataColumnMapping("bezeichnung", "bezeichnung")})})
        Me.daObjects_IDDokumenteintrag.UpdateCommand = Me.OleDbUpdateCommand_IDDokumenteintrag
        '
        'OleDbDeleteCommand_IDDokumenteintrag
        '
        Me.OleDbDeleteCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbDeleteCommand_IDDokumenteintrag.CommandText")
        Me.OleDbDeleteCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDDokumenteintrag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbankidentität", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Server", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Server", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Datenbank", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Benutzer", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Passwort", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Passwort", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDTyp", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_guid", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_guid", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_str", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_str", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "bezeichnung", System.Data.DataRowVersion.Original, Nothing)})
        '
        'OleDbInsertCommand_IDDokumenteintrag
        '
        Me.OleDbInsertCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbInsertCommand_IDDokumenteintrag.CommandText")
        Me.OleDbInsertCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, "Datenbankidentität"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, "Datenbank"), New System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"), New System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("ID_guid", System.Data.OleDb.OleDbType.Guid, 0, "ID_guid"), New System.Data.OleDb.OleDbParameter("ID_str", System.Data.OleDb.OleDbType.VarChar, 0, "ID_str"), New System.Data.OleDb.OleDbParameter("ID_int", System.Data.OleDb.OleDbType.[Integer], 0, "ID_int"), New System.Data.OleDb.OleDbParameter("bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "bezeichnung")})
        '
        'OleDbSelectCommand_IDDokumenteintrag
        '
        Me.OleDbSelectCommand_IDDokumenteintrag.CommandText = "SELECT ID, IDDokumenteintrag, Datenbankidentität, Server, Datenbank, Benutzer, Pa" &
    "sswort, IDTyp, ID_guid, ID_str, ID_int, bezeichnung  FROM tblObjekt WHERE (IDDok" &
    "umenteintrag = ?)"
        Me.OleDbSelectCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDDokumenteintrag")})
        '
        'OleDbUpdateCommand_IDDokumenteintrag
        '
        Me.OleDbUpdateCommand_IDDokumenteintrag.CommandText = resources.GetString("OleDbUpdateCommand_IDDokumenteintrag.CommandText")
        Me.OleDbUpdateCommand_IDDokumenteintrag.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"), New System.Data.OleDb.OleDbParameter("IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDDokumenteintrag"), New System.Data.OleDb.OleDbParameter("Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, "Datenbankidentität"), New System.Data.OleDb.OleDbParameter("Server", System.Data.OleDb.OleDbType.VarChar, 0, "Server"), New System.Data.OleDb.OleDbParameter("Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, "Datenbank"), New System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"), New System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"), New System.Data.OleDb.OleDbParameter("IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, "IDTyp"), New System.Data.OleDb.OleDbParameter("ID_guid", System.Data.OleDb.OleDbType.Guid, 0, "ID_guid"), New System.Data.OleDb.OleDbParameter("ID_str", System.Data.OleDb.OleDbType.VarChar, 0, "ID_str"), New System.Data.OleDb.OleDbParameter("ID_int", System.Data.OleDb.OleDbType.[Integer], 0, "ID_int"), New System.Data.OleDb.OleDbParameter("bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "bezeichnung"), New System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDDokumenteintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDDokumenteintrag", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbankidentität", System.Data.OleDb.OleDbType.[Boolean], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbankidentität", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Server", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Server", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Server", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Datenbank", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Datenbank", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Datenbank", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Benutzer", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Benutzer", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_Passwort", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_Passwort", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Passwort", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_IDTyp", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDTyp", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_guid", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_guid", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_guid", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_str", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_str", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_str", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("IsNull_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, True, Nothing), New System.Data.OleDb.OleDbParameter("Original_ID_int", System.Data.OleDb.OleDbType.[Integer], 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ID_int", System.Data.DataRowVersion.Original, Nothing), New System.Data.OleDb.OleDbParameter("Original_bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "bezeichnung", System.Data.DataRowVersion.Original, Nothing)})

    End Sub

    Friend WithEvents daPatientByID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_PatientByID As OleDb.OleDbCommand
    Friend WithEvents daDokumenteGelesen_IDDokumenteneintrag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents daAlleDokumenteGelesenJN As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_AlleDokumenteGelesenJN As OleDb.OleDbCommand
    Friend WithEvents daAlleDokumenteGelesenJaNein As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_AlleDokumenteGelesenJaNein As OleDb.OleDbCommand
    Friend WithEvents daDokumente_IDDokueintrag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumente_IDDokueintrag As OleDb.OleDbCommand
    Friend WithEvents daDokumenteintrag_anzahl As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumenteintrag_anzahl As OleDb.OleDbCommand
    Friend WithEvents daDokumenteintrag_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Dokumenteintrag_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumenteintrag_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Dokumenteintrag_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumenteintrag_ID As OleDb.OleDbCommand
    Friend WithEvents daDokumente_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Dokumente_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumente_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Dokumente_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumente_ID As OleDb.OleDbCommand
    Friend WithEvents dbConn As OleDb.OleDbConnection
    Friend WithEvents daPfad As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Pfad As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Pfad As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Pfad As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Pfad As OleDb.OleDbCommand
    Friend WithEvents daRechteOrdner_IDOrdnerIDGruppe As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_RechteOrdner_IDOrdnerIDGruppe As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_RechteOrdner_IDOrdnerIDGruppe As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_RechteOrdner_IDOrdnerIDGruppe As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_RechteOrdner_IDOrdnerIDGruppe As OleDb.OleDbCommand
    Friend WithEvents daRechteOrdner_IDOrdner As OleDb.OleDbDataAdapter
    Friend WithEvents OLEBSelectCommand_RechteOrdner_IDOrdner As OleDb.OleDbCommand
    Public WithEvents daSchränkeAlle As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Schränke As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schränke As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Schränke As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schränke As OleDb.OleDbCommand
    Public WithEvents daFächer_IDSchrank As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Fächer_IDSchrank As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Fächer_IDSchrank As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Fächer_IDSchrank As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Fächer_IDSchrank As OleDb.OleDbCommand
    Public WithEvents daOrdner_IDFach As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Ordner_IDFach As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Ordner_IDFach As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Ordner_IDFach As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Ordner_IDFach As OleDb.OleDbCommand
    Public WithEvents daFächer_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Fächer_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Fächer_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Fächer_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Fächer_ID As OleDb.OleDbCommand
    Friend WithEvents daSchrank_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Schrank_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schrank_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Schrank_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schrank_ID As OleDb.OleDbCommand
    Friend WithEvents daAlleDateienPapierkorb As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_AlleDateienPapierkorb As OleDb.OleDbCommand
    Friend WithEvents daDokumentendaten_IDDokumenteneintrag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Dokumentendaten_IDDokumenteneintrag As OleDb.OleDbCommand
    Public WithEvents daSchlagwort_IDThema As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Schlagwort_IDThema As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Schlagwort_IDThema As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Schlagwort_IDThema As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Schlagwort_IDThema As OleDb.OleDbCommand
    Public WithEvents daThema_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Thema_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Thema_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Thema_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Thema_ID As OleDb.OleDbCommand
    Friend WithEvents daSchlagwort_All As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schlagwort_All As OleDb.OleDbCommand
    Friend WithEvents daDokumenteneintrag_IDDokumenteneintrag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Dokumenteneintrag_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Dokumenteneintrag_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Dokumenteneintrag_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Dokumenteneintrag_IDDokumenteneintrag As OleDb.OleDbCommand
    Friend WithEvents daDokumenteneintragSchlagwörter_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_DokumenteneintragSchlagwörter_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_DokumenteneintragSchlagwörter_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_DokumenteneintragSchlagwörter_ID As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_DokumenteneintragSchlagwörter_ID As OleDb.OleDbCommand
    Friend WithEvents daSchlagwort_ID As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCommand_Schlagwort_ID As OleDb.OleDbCommand
    Public WithEvents daThema_All As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_Thema_All As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_Thema_All As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_Thema_All As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_Thema_All As OleDb.OleDbCommand
    Friend WithEvents daObjects_IDDokumenteintrag As OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDeleteCommand_IDDokumenteintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCommand_IDDokumenteintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCommand_IDDokumenteintrag As OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCommand_IDDokumenteintrag As OleDb.OleDbCommand
End Class
