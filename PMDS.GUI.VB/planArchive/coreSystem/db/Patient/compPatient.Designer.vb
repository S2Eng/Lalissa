Partial Class compPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(compPatient))
        Me.OleDbSelectCommand_PatientByID = New System.Data.OleDb.OleDbCommand()
        Me.dbPMDS = New System.Data.OleDb.OleDbConnection()
        Me.daPatientByID = New System.Data.OleDb.OleDbDataAdapter()
        '
        'OleDbSelectCommand_PatientByID
        '
        Me.OleDbSelectCommand_PatientByID.CommandText = resources.GetString("OleDbSelectCommand_PatientByID.CommandText")
        Me.OleDbSelectCommand_PatientByID.Connection = Me.dbPMDS
        Me.OleDbSelectCommand_PatientByID.Parameters.AddRange(New System.Data.OleDb.OleDbParameter() {New System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")})
        '
        'dbPMDS
        '
        Me.dbPMDS.ConnectionString = "Provider=SQLNCLI11;Data Source=STY040;Integrated Security=SSPI;Initial Catalog=PM" & _
    "DS_DemoGross"
        '
        'daPatientByID
        '
        Me.daPatientByID.SelectCommand = Me.OleDbSelectCommand_PatientByID
        Me.daPatientByID.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Abteilung", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"), New System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"), New System.Data.Common.DataColumnMapping("Titel", "Titel"), New System.Data.Common.DataColumnMapping("Sexus", "Sexus"), New System.Data.Common.DataColumnMapping("Konfision", "Konfision"), New System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"), New System.Data.Common.DataColumnMapping("Staatsb", "Staatsb"), New System.Data.Common.DataColumnMapping("Klasse", "Klasse"), New System.Data.Common.DataColumnMapping("KrankenKasse", "KrankenKasse"), New System.Data.Common.DataColumnMapping("BlutGruppe", "BlutGruppe"), New System.Data.Common.DataColumnMapping("Resusfaktor", "Resusfaktor"), New System.Data.Common.DataColumnMapping("LedigerName", "LedigerName"), New System.Data.Common.DataColumnMapping("Geburtsort", "Geburtsort"), New System.Data.Common.DataColumnMapping("Voraufenthalt", "Voraufenthalt"), New System.Data.Common.DataColumnMapping("Angehörige", "Angehörige"), New System.Data.Common.DataColumnMapping("VersicherungsNr", "VersicherungsNr"), New System.Data.Common.DataColumnMapping("ArbeitslosBezSeit", "ArbeitslosBezSeit"), New System.Data.Common.DataColumnMapping("KrankengeldSeit", "KrankengeldSeit"), New System.Data.Common.DataColumnMapping("Hauptversicherung", "Hauptversicherung"), New System.Data.Common.DataColumnMapping("ErlernterBeruf", "ErlernterBeruf"), New System.Data.Common.DataColumnMapping("Besonderheit", "Besonderheit"), New System.Data.Common.DataColumnMapping("Betreuer", "Betreuer"), New System.Data.Common.DataColumnMapping("Sachwalter", "Sachwalter"), New System.Data.Common.DataColumnMapping("SachWalterBelange", "SachWalterBelange"), New System.Data.Common.DataColumnMapping("SachWalterVon", "SachWalterVon"), New System.Data.Common.DataColumnMapping("SachWalterBis", "SachWalterBis"), New System.Data.Common.DataColumnMapping("SterbeRegel", "SterbeRegel"), New System.Data.Common.DataColumnMapping("Depotinjektion", "Depotinjektion"), New System.Data.Common.DataColumnMapping("Hausarzt", "Hausarzt"), New System.Data.Common.DataColumnMapping("Vermerk", "Vermerk"), New System.Data.Common.DataColumnMapping("SterbeDatum", "SterbeDatum"), New System.Data.Common.DataColumnMapping("AktuellerDienstgeber", "AktuellerDienstgeber"), New System.Data.Common.DataColumnMapping("DerzeitigerBeruf", "DerzeitigerBeruf"), New System.Data.Common.DataColumnMapping("RezeptgebuehrbefreiungJN", "RezeptgebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("PflegegeldantragJN", "PflegegeldantragJN"), New System.Data.Common.DataColumnMapping("DatumPflegegeldantrag", "DatumPflegegeldantrag"), New System.Data.Common.DataColumnMapping("PensionsteilungsantragJN", "PensionsteilungsantragJN"), New System.Data.Common.DataColumnMapping("DatumPensionsteilungsantrag", "DatumPensionsteilungsantrag"), New System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"), New System.Data.Common.DataColumnMapping("RollungVon", "RollungVon"), New System.Data.Common.DataColumnMapping("RollungBis", "RollungBis"), New System.Data.Common.DataColumnMapping("Adelstitel", "Adelstitel"), New System.Data.Common.DataColumnMapping("Anrede", "Anrede"), New System.Data.Common.DataColumnMapping("Initialberuehrung", "Initialberuehrung"), New System.Data.Common.DataColumnMapping("Klingeln", "Klingeln"), New System.Data.Common.DataColumnMapping("Wohnsituation", "Wohnsituation"), New System.Data.Common.DataColumnMapping("Haustier", "Haustier"), New System.Data.Common.DataColumnMapping("LiftJN", "LiftJN"), New System.Data.Common.DataColumnMapping("WohnungAbgemeldetJN", "WohnungAbgemeldetJN"), New System.Data.Common.DataColumnMapping("Haarfarbe", "Haarfarbe"), New System.Data.Common.DataColumnMapping("Augenfarbe", "Augenfarbe"), New System.Data.Common.DataColumnMapping("BesondereAeusserlicheKennzeichen", "BesondereAeusserlicheKennzeichen"), New System.Data.Common.DataColumnMapping("Foto", "Foto"), New System.Data.Common.DataColumnMapping("FernsehgebuehrbefreiungJN", "FernsehgebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("TelefongebuehrbefreiungJN", "TelefongebuehrbefreiungJN"), New System.Data.Common.DataColumnMapping("BewerberJN", "BewerberJN"), New System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"), New System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"), New System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"), New System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"), New System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"), New System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"), New System.Data.Common.DataColumnMapping("Stationswunsch", "Stationswunsch"), New System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"), New System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"), New System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"), New System.Data.Common.DataColumnMapping("ReligionWunsch", "ReligionWunsch"), New System.Data.Common.DataColumnMapping("KommunionJN", "KommunionJN"), New System.Data.Common.DataColumnMapping("KrankensalbungJN", "KrankensalbungJN"), New System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"), New System.Data.Common.DataColumnMapping("WaescheMarkiert", "WaescheMarkiert"), New System.Data.Common.DataColumnMapping("WaescheWaschen", "WaescheWaschen"), New System.Data.Common.DataColumnMapping("Zustaendige_Stelle", "Zustaendige_Stelle"), New System.Data.Common.DataColumnMapping("Groesse", "Groesse"), New System.Data.Common.DataColumnMapping("Statur", "Statur"), New System.Data.Common.DataColumnMapping("Namenstag", "Namenstag"), New System.Data.Common.DataColumnMapping("Kosename", "Kosename"), New System.Data.Common.DataColumnMapping("Privatversicherung", "Privatversicherung"), New System.Data.Common.DataColumnMapping("PrivPolNr", "PrivPolNr"), New System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"), New System.Data.Common.DataColumnMapping("PatientenverfuegungJN", "PatientenverfuegungJN"), New System.Data.Common.DataColumnMapping("PatientenverfuegungBeachtlichJN", "PatientenverfuegungBeachtlichJN"), New System.Data.Common.DataColumnMapping("PatientverfuegungDatum", "PatientverfuegungDatum"), New System.Data.Common.DataColumnMapping("PatientverfuegungAnmerkung", "PatientverfuegungAnmerkung"), New System.Data.Common.DataColumnMapping("Klientennummer", "Klientennummer"), New System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"), New System.Data.Common.DataColumnMapping("abwesenheitenHändBerech", "abwesenheitenHändBerech"), New System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"), New System.Data.Common.DataColumnMapping("Strasse", "Strasse"), New System.Data.Common.DataColumnMapping("Plz", "Plz"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("LandKZ", "LandKZ"), New System.Data.Common.DataColumnMapping("Tel", "Tel"), New System.Data.Common.DataColumnMapping("Fax", "Fax"), New System.Data.Common.DataColumnMapping("Mobil", "Mobil"), New System.Data.Common.DataColumnMapping("Andere", "Andere"), New System.Data.Common.DataColumnMapping("Email", "Email"), New System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"), New System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"), New System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"), New System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3"), New System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"), New System.Data.Common.DataColumnMapping("IDAdresse1", "IDAdresse1"), New System.Data.Common.DataColumnMapping("IDKontakt1", "IDKontakt1")})})

    End Sub
    Friend WithEvents OleDbSelectCommand_PatientByID As System.Data.OleDb.OleDbCommand
    Friend WithEvents dbPMDS As System.Data.OleDb.OleDbConnection
    Friend WithEvents daPatientByID As System.Data.OleDb.OleDbDataAdapter

End Class
