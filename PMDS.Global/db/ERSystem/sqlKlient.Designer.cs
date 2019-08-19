namespace PMDS.Global.db.ERSystem
{
    partial class sqlKlient
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlKlient));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daPatient = new System.Data.SqlClient.SqlDataAdapter();
            this.daAufenthalt = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.daAufenthaltVerlauf = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand6 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand7 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand8 = new System.Data.SqlClient.SqlCommand();
            this.daAbteilung = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand9 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand10 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand11 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand12 = new System.Data.SqlClient.SqlCommand();
            this.daBereich = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand13 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand14 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand15 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand16 = new System.Data.SqlClient.SqlCommand();
            this.daPatientSmall = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand19 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConn;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = "Data Source=192.168.80.210;Initial Catalog=PMDSDev;Integrated Security=True";
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConn;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAdresse", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAdresse"),
            new System.Data.SqlClient.SqlParameter("@IDKontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontakt"),
            new System.Data.SqlClient.SqlParameter("@Vorname", System.Data.SqlDbType.VarChar, 0, "Vorname"),
            new System.Data.SqlClient.SqlParameter("@Nachname", System.Data.SqlDbType.VarChar, 0, "Nachname"),
            new System.Data.SqlClient.SqlParameter("@Geburtsdatum", System.Data.SqlDbType.DateTime, 0, "Geburtsdatum"),
            new System.Data.SqlClient.SqlParameter("@Titel", System.Data.SqlDbType.VarChar, 0, "Titel"),
            new System.Data.SqlClient.SqlParameter("@Sexus", System.Data.SqlDbType.VarChar, 0, "Sexus"),
            new System.Data.SqlClient.SqlParameter("@Konfision", System.Data.SqlDbType.VarChar, 0, "Konfision"),
            new System.Data.SqlClient.SqlParameter("@Familienstand", System.Data.SqlDbType.VarChar, 0, "Familienstand"),
            new System.Data.SqlClient.SqlParameter("@Staatsb", System.Data.SqlDbType.VarChar, 0, "Staatsb"),
            new System.Data.SqlClient.SqlParameter("@Klasse", System.Data.SqlDbType.VarChar, 0, "Klasse"),
            new System.Data.SqlClient.SqlParameter("@KrankenKasse", System.Data.SqlDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.SqlClient.SqlParameter("@BlutGruppe", System.Data.SqlDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.SqlClient.SqlParameter("@Resusfaktor", System.Data.SqlDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.SqlClient.SqlParameter("@LedigerName", System.Data.SqlDbType.VarChar, 0, "LedigerName"),
            new System.Data.SqlClient.SqlParameter("@Geburtsort", System.Data.SqlDbType.VarChar, 0, "Geburtsort"),
            new System.Data.SqlClient.SqlParameter("@Voraufenthalt", System.Data.SqlDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.SqlClient.SqlParameter("@Angehörige", System.Data.SqlDbType.Text, 0, "Angehörige"),
            new System.Data.SqlClient.SqlParameter("@VersicherungsNr", System.Data.SqlDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.SqlClient.SqlParameter("@ArbeitslosBezSeit", System.Data.SqlDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.SqlClient.SqlParameter("@KrankengeldSeit", System.Data.SqlDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.SqlClient.SqlParameter("@Hauptversicherung", System.Data.SqlDbType.Text, 0, "Hauptversicherung"),
            new System.Data.SqlClient.SqlParameter("@ErlernterBeruf", System.Data.SqlDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.SqlClient.SqlParameter("@Besonderheit", System.Data.SqlDbType.Text, 0, "Besonderheit"),
            new System.Data.SqlClient.SqlParameter("@Betreuer", System.Data.SqlDbType.Text, 0, "Betreuer"),
            new System.Data.SqlClient.SqlParameter("@Sachwalter", System.Data.SqlDbType.Text, 0, "Sachwalter"),
            new System.Data.SqlClient.SqlParameter("@SachWalterBelange", System.Data.SqlDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.SqlClient.SqlParameter("@SachWalterVon", System.Data.SqlDbType.DateTime, 0, "SachWalterVon"),
            new System.Data.SqlClient.SqlParameter("@SachWalterBis", System.Data.SqlDbType.DateTime, 0, "SachWalterBis"),
            new System.Data.SqlClient.SqlParameter("@SterbeRegel", System.Data.SqlDbType.Text, 0, "SterbeRegel"),
            new System.Data.SqlClient.SqlParameter("@Depotinjektion", System.Data.SqlDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.SqlClient.SqlParameter("@Hausarzt", System.Data.SqlDbType.Text, 0, "Hausarzt"),
            new System.Data.SqlClient.SqlParameter("@Vermerk", System.Data.SqlDbType.Text, 0, "Vermerk"),
            new System.Data.SqlClient.SqlParameter("@SterbeDatum", System.Data.SqlDbType.DateTime, 0, "SterbeDatum"),
            new System.Data.SqlClient.SqlParameter("@AktuellerDienstgeber", System.Data.SqlDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.SqlClient.SqlParameter("@DerzeitigerBeruf", System.Data.SqlDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.SqlClient.SqlParameter("@RezeptgebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@PflegegeldantragJN", System.Data.SqlDbType.Bit, 0, "PflegegeldantragJN"),
            new System.Data.SqlClient.SqlParameter("@DatumPflegegeldantrag", System.Data.SqlDbType.DateTime, 0, "DatumPflegegeldantrag"),
            new System.Data.SqlClient.SqlParameter("@PensionsteilungsantragJN", System.Data.SqlDbType.Bit, 0, "PensionsteilungsantragJN"),
            new System.Data.SqlClient.SqlParameter("@DatumPensionsteilungsantrag", System.Data.SqlDbType.DateTime, 0, "DatumPensionsteilungsantrag"),
            new System.Data.SqlClient.SqlParameter("@FIBUKonto", System.Data.SqlDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.SqlClient.SqlParameter("@RollungVon", System.Data.SqlDbType.DateTime, 0, "RollungVon"),
            new System.Data.SqlClient.SqlParameter("@RollungBis", System.Data.SqlDbType.DateTime, 0, "RollungBis"),
            new System.Data.SqlClient.SqlParameter("@Adelstitel", System.Data.SqlDbType.VarChar, 0, "Adelstitel"),
            new System.Data.SqlClient.SqlParameter("@Anrede", System.Data.SqlDbType.VarChar, 0, "Anrede"),
            new System.Data.SqlClient.SqlParameter("@Initialberuehrung", System.Data.SqlDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.SqlClient.SqlParameter("@Klingeln", System.Data.SqlDbType.VarChar, 0, "Klingeln"),
            new System.Data.SqlClient.SqlParameter("@Wohnsituation", System.Data.SqlDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.SqlClient.SqlParameter("@Haustier", System.Data.SqlDbType.VarChar, 0, "Haustier"),
            new System.Data.SqlClient.SqlParameter("@LiftJN", System.Data.SqlDbType.Bit, 0, "LiftJN"),
            new System.Data.SqlClient.SqlParameter("@WohnungAbgemeldetJN", System.Data.SqlDbType.Bit, 0, "WohnungAbgemeldetJN"),
            new System.Data.SqlClient.SqlParameter("@Haarfarbe", System.Data.SqlDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.SqlClient.SqlParameter("@Augenfarbe", System.Data.SqlDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.SqlClient.SqlParameter("@BesondereAeusserlicheKennzeichen", System.Data.SqlDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.SqlClient.SqlParameter("@Foto", System.Data.SqlDbType.Image, 0, "Foto"),
            new System.Data.SqlClient.SqlParameter("@FernsehgebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@TelefongebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@BewerberJN", System.Data.SqlDbType.Bit, 0, "BewerberJN"),
            new System.Data.SqlClient.SqlParameter("@BewerbungaktivJN", System.Data.SqlDbType.Bit, 0, "BewerbungaktivJN"),
            new System.Data.SqlClient.SqlParameter("@PflegeArt", System.Data.SqlDbType.VarChar, 0, "PflegeArt"),
            new System.Data.SqlClient.SqlParameter("@BewerbungDatum", System.Data.SqlDbType.DateTime, 0, "BewerbungDatum"),
            new System.Data.SqlClient.SqlParameter("@EinzugswunschDatum", System.Data.SqlDbType.DateTime, 0, "EinzugswunschDatum"),
            new System.Data.SqlClient.SqlParameter("@AuszugswunschDatum", System.Data.SqlDbType.DateTime, 0, "AuszugswunschDatum"),
            new System.Data.SqlClient.SqlParameter("@Zimmerwunsch", System.Data.SqlDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.SqlClient.SqlParameter("@Stationswunsch", System.Data.SqlDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.SqlClient.SqlParameter("@SonstigeWuensche", System.Data.SqlDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.SqlClient.SqlParameter("@BewerbungsGrund", System.Data.SqlDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.SqlClient.SqlParameter("@Prioritaet", System.Data.SqlDbType.VarChar, 0, "Prioritaet"),
            new System.Data.SqlClient.SqlParameter("@ReligionWunsch", System.Data.SqlDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.SqlClient.SqlParameter("@KommunionJN", System.Data.SqlDbType.Bit, 0, "KommunionJN"),
            new System.Data.SqlClient.SqlParameter("@KrankensalbungJN", System.Data.SqlDbType.Bit, 0, "KrankensalbungJN"),
            new System.Data.SqlClient.SqlParameter("@BewerberBemerkung", System.Data.SqlDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.SqlClient.SqlParameter("@WaescheMarkiert", System.Data.SqlDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.SqlClient.SqlParameter("@WaescheWaschen", System.Data.SqlDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.SqlClient.SqlParameter("@Zustaendige_Stelle", System.Data.SqlDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.SqlClient.SqlParameter("@Groesse", System.Data.SqlDbType.Int, 0, "Groesse"),
            new System.Data.SqlClient.SqlParameter("@Statur", System.Data.SqlDbType.VarChar, 0, "Statur"),
            new System.Data.SqlClient.SqlParameter("@Namenstag", System.Data.SqlDbType.DateTime, 0, "Namenstag"),
            new System.Data.SqlClient.SqlParameter("@Kosename", System.Data.SqlDbType.VarChar, 0, "Kosename"),
            new System.Data.SqlClient.SqlParameter("@Privatversicherung", System.Data.SqlDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.SqlClient.SqlParameter("@PrivPolNr", System.Data.SqlDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@PatientenverfuegungJN", System.Data.SqlDbType.Bit, 0, "PatientenverfuegungJN"),
            new System.Data.SqlClient.SqlParameter("@PatientenverfuegungBeachtlichJN", System.Data.SqlDbType.Bit, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.SqlClient.SqlParameter("@PatientverfuegungDatum", System.Data.SqlDbType.DateTime, 0, "PatientverfuegungDatum"),
            new System.Data.SqlClient.SqlParameter("@PatientverfuegungAnmerkung", System.Data.SqlDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.SqlClient.SqlParameter("@Klientennummer", System.Data.SqlDbType.VarChar, 0, "Klientennummer"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@abwesenheitenHändBerech", System.Data.SqlDbType.Bit, 0, "abwesenheitenHändBerech"),
            new System.Data.SqlClient.SqlParameter("@Sollstand", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@minSaldo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Kennwort", System.Data.SqlDbType.VarChar, 0, "Kennwort"),
            new System.Data.SqlClient.SqlParameter("@blob_Einverständniserklärung", System.Data.SqlDbType.VarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.SqlClient.SqlParameter("@EinverständniserklärungFileType", System.Data.SqlDbType.NVarChar, 0, "EinverständniserklärungFileType"),
            new System.Data.SqlClient.SqlParameter("@jpg_Einverständniserklärung", System.Data.SqlDbType.VarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.SqlClient.SqlParameter("@Verstorben", System.Data.SqlDbType.Bit, 0, "Verstorben"),
            new System.Data.SqlClient.SqlParameter("@Todeszeitpunkt", System.Data.SqlDbType.DateTime, 0, "Todeszeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@DNR", System.Data.SqlDbType.Bit, 0, "DNR"),
            new System.Data.SqlClient.SqlParameter("@Milieubetreuung", System.Data.SqlDbType.Bit, 0, "Milieubetreuung"),
            new System.Data.SqlClient.SqlParameter("@KZUeberlebender", System.Data.SqlDbType.Bit, 0, "KZUeberlebender"),
            new System.Data.SqlClient.SqlParameter("@Anatomie", System.Data.SqlDbType.Bit, 0, "Anatomie"),
            new System.Data.SqlClient.SqlParameter("@Einzelzimmer", System.Data.SqlDbType.Bit, 0, "Einzelzimmer"),
            new System.Data.SqlClient.SqlParameter("@Selbstzahler", System.Data.SqlDbType.Bit, 0, "Selbstzahler"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@KürzungLetzterTagAnwesenheit", System.Data.SqlDbType.Bit, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.SqlClient.SqlParameter("@Behindertenausweis", System.Data.SqlDbType.Bit, 0, "Behindertenausweis"),
            new System.Data.SqlClient.SqlParameter("@Sozialcard", System.Data.SqlDbType.Bit, 0, "Sozialcard"),
            new System.Data.SqlClient.SqlParameter("@IDAdresseSub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAdresseSub"),
            new System.Data.SqlClient.SqlParameter("@IDKontaktSub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontaktSub"),
            new System.Data.SqlClient.SqlParameter("@Betreuungsstufe", System.Data.SqlDbType.VarChar, 0, "Betreuungsstufe"),
            new System.Data.SqlClient.SqlParameter("@BetreuungsstufeAb", System.Data.SqlDbType.DateTime, 0, "BetreuungsstufeAb"),
            new System.Data.SqlClient.SqlParameter("@BetreuungsstufeBis", System.Data.SqlDbType.DateTime, 0, "BetreuungsstufeBis"),
            new System.Data.SqlClient.SqlParameter("@lstSprachen", System.Data.SqlDbType.NVarChar, 0, "lstSprachen"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoAb", System.Data.SqlDbType.DateTime, 0, "RezGebBef_RegoAb"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoBis", System.Data.SqlDbType.DateTime, 0, "RezGebBef_RegoBis"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_UnbefristetJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_UnbefristetJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_BefristetJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetBis", System.Data.SqlDbType.DateTime, 0, "RezGebBef_BefristetBis"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_WiderrufJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_WiderrufJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_WiderrufGrund", System.Data.SqlDbType.NVarChar, 0, "RezGebBef_WiderrufGrund"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_RegoJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetAb", System.Data.SqlDbType.DateTime, 0, "RezGebBef_BefristetAb"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_SachwalterJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_SachwalterJN")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConn;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAdresse", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAdresse"),
            new System.Data.SqlClient.SqlParameter("@IDKontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontakt"),
            new System.Data.SqlClient.SqlParameter("@Vorname", System.Data.SqlDbType.VarChar, 0, "Vorname"),
            new System.Data.SqlClient.SqlParameter("@Nachname", System.Data.SqlDbType.VarChar, 0, "Nachname"),
            new System.Data.SqlClient.SqlParameter("@Geburtsdatum", System.Data.SqlDbType.DateTime, 0, "Geburtsdatum"),
            new System.Data.SqlClient.SqlParameter("@Titel", System.Data.SqlDbType.VarChar, 0, "Titel"),
            new System.Data.SqlClient.SqlParameter("@Sexus", System.Data.SqlDbType.VarChar, 0, "Sexus"),
            new System.Data.SqlClient.SqlParameter("@Konfision", System.Data.SqlDbType.VarChar, 0, "Konfision"),
            new System.Data.SqlClient.SqlParameter("@Familienstand", System.Data.SqlDbType.VarChar, 0, "Familienstand"),
            new System.Data.SqlClient.SqlParameter("@Staatsb", System.Data.SqlDbType.VarChar, 0, "Staatsb"),
            new System.Data.SqlClient.SqlParameter("@Klasse", System.Data.SqlDbType.VarChar, 0, "Klasse"),
            new System.Data.SqlClient.SqlParameter("@KrankenKasse", System.Data.SqlDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.SqlClient.SqlParameter("@BlutGruppe", System.Data.SqlDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.SqlClient.SqlParameter("@Resusfaktor", System.Data.SqlDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.SqlClient.SqlParameter("@LedigerName", System.Data.SqlDbType.VarChar, 0, "LedigerName"),
            new System.Data.SqlClient.SqlParameter("@Geburtsort", System.Data.SqlDbType.VarChar, 0, "Geburtsort"),
            new System.Data.SqlClient.SqlParameter("@Voraufenthalt", System.Data.SqlDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.SqlClient.SqlParameter("@Angehörige", System.Data.SqlDbType.Text, 0, "Angehörige"),
            new System.Data.SqlClient.SqlParameter("@VersicherungsNr", System.Data.SqlDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.SqlClient.SqlParameter("@ArbeitslosBezSeit", System.Data.SqlDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.SqlClient.SqlParameter("@KrankengeldSeit", System.Data.SqlDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.SqlClient.SqlParameter("@Hauptversicherung", System.Data.SqlDbType.Text, 0, "Hauptversicherung"),
            new System.Data.SqlClient.SqlParameter("@ErlernterBeruf", System.Data.SqlDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.SqlClient.SqlParameter("@Besonderheit", System.Data.SqlDbType.Text, 0, "Besonderheit"),
            new System.Data.SqlClient.SqlParameter("@Betreuer", System.Data.SqlDbType.Text, 0, "Betreuer"),
            new System.Data.SqlClient.SqlParameter("@Sachwalter", System.Data.SqlDbType.Text, 0, "Sachwalter"),
            new System.Data.SqlClient.SqlParameter("@SachWalterBelange", System.Data.SqlDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.SqlClient.SqlParameter("@SachWalterVon", System.Data.SqlDbType.DateTime, 0, "SachWalterVon"),
            new System.Data.SqlClient.SqlParameter("@SachWalterBis", System.Data.SqlDbType.DateTime, 0, "SachWalterBis"),
            new System.Data.SqlClient.SqlParameter("@SterbeRegel", System.Data.SqlDbType.Text, 0, "SterbeRegel"),
            new System.Data.SqlClient.SqlParameter("@Depotinjektion", System.Data.SqlDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.SqlClient.SqlParameter("@Hausarzt", System.Data.SqlDbType.Text, 0, "Hausarzt"),
            new System.Data.SqlClient.SqlParameter("@Vermerk", System.Data.SqlDbType.Text, 0, "Vermerk"),
            new System.Data.SqlClient.SqlParameter("@SterbeDatum", System.Data.SqlDbType.DateTime, 0, "SterbeDatum"),
            new System.Data.SqlClient.SqlParameter("@AktuellerDienstgeber", System.Data.SqlDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.SqlClient.SqlParameter("@DerzeitigerBeruf", System.Data.SqlDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.SqlClient.SqlParameter("@RezeptgebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@PflegegeldantragJN", System.Data.SqlDbType.Bit, 0, "PflegegeldantragJN"),
            new System.Data.SqlClient.SqlParameter("@DatumPflegegeldantrag", System.Data.SqlDbType.DateTime, 0, "DatumPflegegeldantrag"),
            new System.Data.SqlClient.SqlParameter("@PensionsteilungsantragJN", System.Data.SqlDbType.Bit, 0, "PensionsteilungsantragJN"),
            new System.Data.SqlClient.SqlParameter("@DatumPensionsteilungsantrag", System.Data.SqlDbType.DateTime, 0, "DatumPensionsteilungsantrag"),
            new System.Data.SqlClient.SqlParameter("@FIBUKonto", System.Data.SqlDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.SqlClient.SqlParameter("@RollungVon", System.Data.SqlDbType.DateTime, 0, "RollungVon"),
            new System.Data.SqlClient.SqlParameter("@RollungBis", System.Data.SqlDbType.DateTime, 0, "RollungBis"),
            new System.Data.SqlClient.SqlParameter("@Adelstitel", System.Data.SqlDbType.VarChar, 0, "Adelstitel"),
            new System.Data.SqlClient.SqlParameter("@Anrede", System.Data.SqlDbType.VarChar, 0, "Anrede"),
            new System.Data.SqlClient.SqlParameter("@Initialberuehrung", System.Data.SqlDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.SqlClient.SqlParameter("@Klingeln", System.Data.SqlDbType.VarChar, 0, "Klingeln"),
            new System.Data.SqlClient.SqlParameter("@Wohnsituation", System.Data.SqlDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.SqlClient.SqlParameter("@Haustier", System.Data.SqlDbType.VarChar, 0, "Haustier"),
            new System.Data.SqlClient.SqlParameter("@LiftJN", System.Data.SqlDbType.Bit, 0, "LiftJN"),
            new System.Data.SqlClient.SqlParameter("@WohnungAbgemeldetJN", System.Data.SqlDbType.Bit, 0, "WohnungAbgemeldetJN"),
            new System.Data.SqlClient.SqlParameter("@Haarfarbe", System.Data.SqlDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.SqlClient.SqlParameter("@Augenfarbe", System.Data.SqlDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.SqlClient.SqlParameter("@BesondereAeusserlicheKennzeichen", System.Data.SqlDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.SqlClient.SqlParameter("@Foto", System.Data.SqlDbType.Image, 0, "Foto"),
            new System.Data.SqlClient.SqlParameter("@FernsehgebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@TelefongebuehrbefreiungJN", System.Data.SqlDbType.Bit, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.SqlClient.SqlParameter("@BewerberJN", System.Data.SqlDbType.Bit, 0, "BewerberJN"),
            new System.Data.SqlClient.SqlParameter("@BewerbungaktivJN", System.Data.SqlDbType.Bit, 0, "BewerbungaktivJN"),
            new System.Data.SqlClient.SqlParameter("@PflegeArt", System.Data.SqlDbType.VarChar, 0, "PflegeArt"),
            new System.Data.SqlClient.SqlParameter("@BewerbungDatum", System.Data.SqlDbType.DateTime, 0, "BewerbungDatum"),
            new System.Data.SqlClient.SqlParameter("@EinzugswunschDatum", System.Data.SqlDbType.DateTime, 0, "EinzugswunschDatum"),
            new System.Data.SqlClient.SqlParameter("@AuszugswunschDatum", System.Data.SqlDbType.DateTime, 0, "AuszugswunschDatum"),
            new System.Data.SqlClient.SqlParameter("@Zimmerwunsch", System.Data.SqlDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.SqlClient.SqlParameter("@Stationswunsch", System.Data.SqlDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.SqlClient.SqlParameter("@SonstigeWuensche", System.Data.SqlDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.SqlClient.SqlParameter("@BewerbungsGrund", System.Data.SqlDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.SqlClient.SqlParameter("@Prioritaet", System.Data.SqlDbType.VarChar, 0, "Prioritaet"),
            new System.Data.SqlClient.SqlParameter("@ReligionWunsch", System.Data.SqlDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.SqlClient.SqlParameter("@KommunionJN", System.Data.SqlDbType.Bit, 0, "KommunionJN"),
            new System.Data.SqlClient.SqlParameter("@KrankensalbungJN", System.Data.SqlDbType.Bit, 0, "KrankensalbungJN"),
            new System.Data.SqlClient.SqlParameter("@BewerberBemerkung", System.Data.SqlDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.SqlClient.SqlParameter("@WaescheMarkiert", System.Data.SqlDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.SqlClient.SqlParameter("@WaescheWaschen", System.Data.SqlDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.SqlClient.SqlParameter("@Zustaendige_Stelle", System.Data.SqlDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.SqlClient.SqlParameter("@Groesse", System.Data.SqlDbType.Int, 0, "Groesse"),
            new System.Data.SqlClient.SqlParameter("@Statur", System.Data.SqlDbType.VarChar, 0, "Statur"),
            new System.Data.SqlClient.SqlParameter("@Namenstag", System.Data.SqlDbType.DateTime, 0, "Namenstag"),
            new System.Data.SqlClient.SqlParameter("@Kosename", System.Data.SqlDbType.VarChar, 0, "Kosename"),
            new System.Data.SqlClient.SqlParameter("@Privatversicherung", System.Data.SqlDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.SqlClient.SqlParameter("@PrivPolNr", System.Data.SqlDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@PatientenverfuegungJN", System.Data.SqlDbType.Bit, 0, "PatientenverfuegungJN"),
            new System.Data.SqlClient.SqlParameter("@PatientenverfuegungBeachtlichJN", System.Data.SqlDbType.Bit, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.SqlClient.SqlParameter("@PatientverfuegungDatum", System.Data.SqlDbType.DateTime, 0, "PatientverfuegungDatum"),
            new System.Data.SqlClient.SqlParameter("@PatientverfuegungAnmerkung", System.Data.SqlDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.SqlClient.SqlParameter("@Klientennummer", System.Data.SqlDbType.VarChar, 0, "Klientennummer"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@abwesenheitenHändBerech", System.Data.SqlDbType.Bit, 0, "abwesenheitenHändBerech"),
            new System.Data.SqlClient.SqlParameter("@Sollstand", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@minSaldo", System.Data.SqlDbType.Decimal, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@Kennwort", System.Data.SqlDbType.VarChar, 0, "Kennwort"),
            new System.Data.SqlClient.SqlParameter("@blob_Einverständniserklärung", System.Data.SqlDbType.VarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.SqlClient.SqlParameter("@EinverständniserklärungFileType", System.Data.SqlDbType.NVarChar, 0, "EinverständniserklärungFileType"),
            new System.Data.SqlClient.SqlParameter("@jpg_Einverständniserklärung", System.Data.SqlDbType.VarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.SqlClient.SqlParameter("@Verstorben", System.Data.SqlDbType.Bit, 0, "Verstorben"),
            new System.Data.SqlClient.SqlParameter("@Todeszeitpunkt", System.Data.SqlDbType.DateTime, 0, "Todeszeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@DNR", System.Data.SqlDbType.Bit, 0, "DNR"),
            new System.Data.SqlClient.SqlParameter("@Milieubetreuung", System.Data.SqlDbType.Bit, 0, "Milieubetreuung"),
            new System.Data.SqlClient.SqlParameter("@KZUeberlebender", System.Data.SqlDbType.Bit, 0, "KZUeberlebender"),
            new System.Data.SqlClient.SqlParameter("@Anatomie", System.Data.SqlDbType.Bit, 0, "Anatomie"),
            new System.Data.SqlClient.SqlParameter("@Einzelzimmer", System.Data.SqlDbType.Bit, 0, "Einzelzimmer"),
            new System.Data.SqlClient.SqlParameter("@Selbstzahler", System.Data.SqlDbType.Bit, 0, "Selbstzahler"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@KürzungLetzterTagAnwesenheit", System.Data.SqlDbType.Bit, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.SqlClient.SqlParameter("@Behindertenausweis", System.Data.SqlDbType.Bit, 0, "Behindertenausweis"),
            new System.Data.SqlClient.SqlParameter("@Sozialcard", System.Data.SqlDbType.Bit, 0, "Sozialcard"),
            new System.Data.SqlClient.SqlParameter("@IDAdresseSub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAdresseSub"),
            new System.Data.SqlClient.SqlParameter("@IDKontaktSub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontaktSub"),
            new System.Data.SqlClient.SqlParameter("@Betreuungsstufe", System.Data.SqlDbType.VarChar, 0, "Betreuungsstufe"),
            new System.Data.SqlClient.SqlParameter("@BetreuungsstufeAb", System.Data.SqlDbType.DateTime, 0, "BetreuungsstufeAb"),
            new System.Data.SqlClient.SqlParameter("@BetreuungsstufeBis", System.Data.SqlDbType.DateTime, 0, "BetreuungsstufeBis"),
            new System.Data.SqlClient.SqlParameter("@lstSprachen", System.Data.SqlDbType.NVarChar, 0, "lstSprachen"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoAb", System.Data.SqlDbType.DateTime, 0, "RezGebBef_RegoAb"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoBis", System.Data.SqlDbType.DateTime, 0, "RezGebBef_RegoBis"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_UnbefristetJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_UnbefristetJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_BefristetJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetBis", System.Data.SqlDbType.DateTime, 0, "RezGebBef_BefristetBis"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_WiderrufJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_WiderrufJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_WiderrufGrund", System.Data.SqlDbType.NVarChar, 0, "RezGebBef_WiderrufGrund"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_RegoJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_RegoJN"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_BefristetAb", System.Data.SqlDbType.DateTime, 0, "RezGebBef_BefristetAb"),
            new System.Data.SqlClient.SqlParameter("@RezGebBef_SachwalterJN", System.Data.SqlDbType.Bit, 0, "RezGebBef_SachwalterJN"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [Patient] WHERE (([ID] = @Original_ID))";
            this.sqlDeleteCommand1.Connection = this.sqlConn;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatient
            // 
            this.daPatient.DeleteCommand = this.sqlDeleteCommand1;
            this.daPatient.InsertCommand = this.sqlInsertCommand1;
            this.daPatient.SelectCommand = this.sqlSelectCommand1;
            this.daPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Sexus", "Sexus"),
                        new System.Data.Common.DataColumnMapping("Konfision", "Konfision"),
                        new System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"),
                        new System.Data.Common.DataColumnMapping("Staatsb", "Staatsb"),
                        new System.Data.Common.DataColumnMapping("Klasse", "Klasse"),
                        new System.Data.Common.DataColumnMapping("KrankenKasse", "KrankenKasse"),
                        new System.Data.Common.DataColumnMapping("BlutGruppe", "BlutGruppe"),
                        new System.Data.Common.DataColumnMapping("Resusfaktor", "Resusfaktor"),
                        new System.Data.Common.DataColumnMapping("LedigerName", "LedigerName"),
                        new System.Data.Common.DataColumnMapping("Geburtsort", "Geburtsort"),
                        new System.Data.Common.DataColumnMapping("Voraufenthalt", "Voraufenthalt"),
                        new System.Data.Common.DataColumnMapping("Angehörige", "Angehörige"),
                        new System.Data.Common.DataColumnMapping("VersicherungsNr", "VersicherungsNr"),
                        new System.Data.Common.DataColumnMapping("ArbeitslosBezSeit", "ArbeitslosBezSeit"),
                        new System.Data.Common.DataColumnMapping("KrankengeldSeit", "KrankengeldSeit"),
                        new System.Data.Common.DataColumnMapping("Hauptversicherung", "Hauptversicherung"),
                        new System.Data.Common.DataColumnMapping("ErlernterBeruf", "ErlernterBeruf"),
                        new System.Data.Common.DataColumnMapping("Besonderheit", "Besonderheit"),
                        new System.Data.Common.DataColumnMapping("Betreuer", "Betreuer"),
                        new System.Data.Common.DataColumnMapping("Sachwalter", "Sachwalter"),
                        new System.Data.Common.DataColumnMapping("SachWalterBelange", "SachWalterBelange"),
                        new System.Data.Common.DataColumnMapping("SachWalterVon", "SachWalterVon"),
                        new System.Data.Common.DataColumnMapping("SachWalterBis", "SachWalterBis"),
                        new System.Data.Common.DataColumnMapping("SterbeRegel", "SterbeRegel"),
                        new System.Data.Common.DataColumnMapping("Depotinjektion", "Depotinjektion"),
                        new System.Data.Common.DataColumnMapping("Hausarzt", "Hausarzt"),
                        new System.Data.Common.DataColumnMapping("Vermerk", "Vermerk"),
                        new System.Data.Common.DataColumnMapping("SterbeDatum", "SterbeDatum"),
                        new System.Data.Common.DataColumnMapping("AktuellerDienstgeber", "AktuellerDienstgeber"),
                        new System.Data.Common.DataColumnMapping("DerzeitigerBeruf", "DerzeitigerBeruf"),
                        new System.Data.Common.DataColumnMapping("RezeptgebuehrbefreiungJN", "RezeptgebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("PflegegeldantragJN", "PflegegeldantragJN"),
                        new System.Data.Common.DataColumnMapping("DatumPflegegeldantrag", "DatumPflegegeldantrag"),
                        new System.Data.Common.DataColumnMapping("PensionsteilungsantragJN", "PensionsteilungsantragJN"),
                        new System.Data.Common.DataColumnMapping("DatumPensionsteilungsantrag", "DatumPensionsteilungsantrag"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("RollungVon", "RollungVon"),
                        new System.Data.Common.DataColumnMapping("RollungBis", "RollungBis"),
                        new System.Data.Common.DataColumnMapping("Adelstitel", "Adelstitel"),
                        new System.Data.Common.DataColumnMapping("Anrede", "Anrede"),
                        new System.Data.Common.DataColumnMapping("Initialberuehrung", "Initialberuehrung"),
                        new System.Data.Common.DataColumnMapping("Klingeln", "Klingeln"),
                        new System.Data.Common.DataColumnMapping("Wohnsituation", "Wohnsituation"),
                        new System.Data.Common.DataColumnMapping("Haustier", "Haustier"),
                        new System.Data.Common.DataColumnMapping("LiftJN", "LiftJN"),
                        new System.Data.Common.DataColumnMapping("WohnungAbgemeldetJN", "WohnungAbgemeldetJN"),
                        new System.Data.Common.DataColumnMapping("Haarfarbe", "Haarfarbe"),
                        new System.Data.Common.DataColumnMapping("Augenfarbe", "Augenfarbe"),
                        new System.Data.Common.DataColumnMapping("BesondereAeusserlicheKennzeichen", "BesondereAeusserlicheKennzeichen"),
                        new System.Data.Common.DataColumnMapping("Foto", "Foto"),
                        new System.Data.Common.DataColumnMapping("FernsehgebuehrbefreiungJN", "FernsehgebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("TelefongebuehrbefreiungJN", "TelefongebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("BewerberJN", "BewerberJN"),
                        new System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"),
                        new System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"),
                        new System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"),
                        new System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"),
                        new System.Data.Common.DataColumnMapping("Stationswunsch", "Stationswunsch"),
                        new System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"),
                        new System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"),
                        new System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"),
                        new System.Data.Common.DataColumnMapping("ReligionWunsch", "ReligionWunsch"),
                        new System.Data.Common.DataColumnMapping("KommunionJN", "KommunionJN"),
                        new System.Data.Common.DataColumnMapping("KrankensalbungJN", "KrankensalbungJN"),
                        new System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"),
                        new System.Data.Common.DataColumnMapping("WaescheMarkiert", "WaescheMarkiert"),
                        new System.Data.Common.DataColumnMapping("WaescheWaschen", "WaescheWaschen"),
                        new System.Data.Common.DataColumnMapping("Zustaendige_Stelle", "Zustaendige_Stelle"),
                        new System.Data.Common.DataColumnMapping("Groesse", "Groesse"),
                        new System.Data.Common.DataColumnMapping("Statur", "Statur"),
                        new System.Data.Common.DataColumnMapping("Namenstag", "Namenstag"),
                        new System.Data.Common.DataColumnMapping("Kosename", "Kosename"),
                        new System.Data.Common.DataColumnMapping("Privatversicherung", "Privatversicherung"),
                        new System.Data.Common.DataColumnMapping("PrivPolNr", "PrivPolNr"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("PatientenverfuegungJN", "PatientenverfuegungJN"),
                        new System.Data.Common.DataColumnMapping("PatientenverfuegungBeachtlichJN", "PatientenverfuegungBeachtlichJN"),
                        new System.Data.Common.DataColumnMapping("PatientverfuegungDatum", "PatientverfuegungDatum"),
                        new System.Data.Common.DataColumnMapping("PatientverfuegungAnmerkung", "PatientverfuegungAnmerkung"),
                        new System.Data.Common.DataColumnMapping("Klientennummer", "Klientennummer"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("abwesenheitenHändBerech", "abwesenheitenHändBerech"),
                        new System.Data.Common.DataColumnMapping("Sollstand", "Sollstand"),
                        new System.Data.Common.DataColumnMapping("minSaldo", "minSaldo"),
                        new System.Data.Common.DataColumnMapping("Kennwort", "Kennwort"),
                        new System.Data.Common.DataColumnMapping("blob_Einverständniserklärung", "blob_Einverständniserklärung"),
                        new System.Data.Common.DataColumnMapping("EinverständniserklärungFileType", "EinverständniserklärungFileType"),
                        new System.Data.Common.DataColumnMapping("jpg_Einverständniserklärung", "jpg_Einverständniserklärung"),
                        new System.Data.Common.DataColumnMapping("Verstorben", "Verstorben"),
                        new System.Data.Common.DataColumnMapping("Todeszeitpunkt", "Todeszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("DNR", "DNR"),
                        new System.Data.Common.DataColumnMapping("Milieubetreuung", "Milieubetreuung"),
                        new System.Data.Common.DataColumnMapping("KZUeberlebender", "KZUeberlebender"),
                        new System.Data.Common.DataColumnMapping("Anatomie", "Anatomie"),
                        new System.Data.Common.DataColumnMapping("Einzelzimmer", "Einzelzimmer"),
                        new System.Data.Common.DataColumnMapping("Selbstzahler", "Selbstzahler"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("KürzungLetzterTagAnwesenheit", "KürzungLetzterTagAnwesenheit"),
                        new System.Data.Common.DataColumnMapping("Behindertenausweis", "Behindertenausweis"),
                        new System.Data.Common.DataColumnMapping("Sozialcard", "Sozialcard"),
                        new System.Data.Common.DataColumnMapping("IDAdresseSub", "IDAdresseSub"),
                        new System.Data.Common.DataColumnMapping("IDKontaktSub", "IDKontaktSub"),
                        new System.Data.Common.DataColumnMapping("Betreuungsstufe", "Betreuungsstufe"),
                        new System.Data.Common.DataColumnMapping("BetreuungsstufeAb", "BetreuungsstufeAb"),
                        new System.Data.Common.DataColumnMapping("BetreuungsstufeBis", "BetreuungsstufeBis"),
                        new System.Data.Common.DataColumnMapping("lstSprachen", "lstSprachen"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_RegoAb", "RezGebBef_RegoAb"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_RegoBis", "RezGebBef_RegoBis"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_UnbefristetJN", "RezGebBef_UnbefristetJN"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_BefristetJN", "RezGebBef_BefristetJN"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_BefristetBis", "RezGebBef_BefristetBis"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_WiderrufJN", "RezGebBef_WiderrufJN"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_WiderrufGrund", "RezGebBef_WiderrufGrund"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_RegoJN", "RezGebBef_RegoJN"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_BefristetAb", "RezGebBef_BefristetAb"),
                        new System.Data.Common.DataColumnMapping("RezGebBef_SachwalterJN", "RezGebBef_SachwalterJN")})});
            this.daPatient.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // daAufenthalt
            // 
            this.daAufenthalt.DeleteCommand = this.sqlCommand1;
            this.daAufenthalt.InsertCommand = this.sqlCommand2;
            this.daAufenthalt.SelectCommand = this.sqlCommand3;
            this.daAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Aufnahme", "IDBenutzer_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Entlassung", "IDBenutzer_Entlassung"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Aufnahme", "IDEinrichtung_Aufnahme"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung_Entlassung", "IDEinrichtung_Entlassung"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("AufnahmeArt", "AufnahmeArt"),
                        new System.Data.Common.DataColumnMapping("BegleitungVon", "BegleitungVon"),
                        new System.Data.Common.DataColumnMapping("Entlassungsbemerkung", "Entlassungsbemerkung"),
                        new System.Data.Common.DataColumnMapping("SomatischeAuff", "SomatischeAuff"),
                        new System.Data.Common.DataColumnMapping("PsychischeAuff", "PsychischeAuff"),
                        new System.Data.Common.DataColumnMapping("VerhaltenAufnahme", "VerhaltenAufnahme"),
                        new System.Data.Common.DataColumnMapping("SonstigeBesonderheiten", "SonstigeBesonderheiten"),
                        new System.Data.Common.DataColumnMapping("SofortMassnahmen", "SofortMassnahmen"),
                        new System.Data.Common.DataColumnMapping("IDUrlaub", "IDUrlaub"),
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"),
                        new System.Data.Common.DataColumnMapping("Fallnummer", "Fallnummer"),
                        new System.Data.Common.DataColumnMapping("Gruppenkennzahl", "Gruppenkennzahl"),
                        new System.Data.Common.DataColumnMapping("Verfuegungsdatum", "Verfuegungsdatum"),
                        new System.Data.Common.DataColumnMapping("Bermerkung", "Bermerkung"),
                        new System.Data.Common.DataColumnMapping("Besuchsregelung", "Besuchsregelung"),
                        new System.Data.Common.DataColumnMapping("Postregelung", "Postregelung"),
                        new System.Data.Common.DataColumnMapping("SonstigeRegelung", "SonstigeRegelung"),
                        new System.Data.Common.DataColumnMapping("Erwartungen", "Erwartungen"),
                        new System.Data.Common.DataColumnMapping("IDErstkontakt", "IDErstkontakt"),
                        new System.Data.Common.DataColumnMapping("Gewicht", "Gewicht"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("TaschengeldSollstand", "TaschengeldSollstand"),
                        new System.Data.Common.DataColumnMapping("TaschegeldVortragDatum", "TaschegeldVortragDatum"),
                        new System.Data.Common.DataColumnMapping("TaschengeldVortragBetrag", "TaschengeldVortragBetrag"),
                        new System.Data.Common.DataColumnMapping("Ausgleichszahlung", "Ausgleichszahlung"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})});
            this.daAufenthalt.UpdateCommand = this.sqlCommand4;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "DELETE FROM [Aufenthalt] WHERE (([ID] = @Original_ID))";
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = resources.GetString("sqlCommand2.CommandText");
            this.sqlCommand2.Connection = this.sqlConn;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDPatient", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPatient"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthaltVerlauf", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthaltVerlauf"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Aufnahme", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Aufnahme"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Entlassung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Entlassung"),
            new System.Data.SqlClient.SqlParameter("@IDEinrichtung_Aufnahme", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.SqlClient.SqlParameter("@IDEinrichtung_Entlassung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEinrichtung_Entlassung"),
            new System.Data.SqlClient.SqlParameter("@Aufnahmezeitpunkt", System.Data.SqlDbType.DateTime, 0, "Aufnahmezeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@Entlassungszeitpunkt", System.Data.SqlDbType.DateTime, 0, "Entlassungszeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeArt", System.Data.SqlDbType.Int, 0, "AufnahmeArt"),
            new System.Data.SqlClient.SqlParameter("@BegleitungVon", System.Data.SqlDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.SqlClient.SqlParameter("@Entlassungsbemerkung", System.Data.SqlDbType.Text, 0, "Entlassungsbemerkung"),
            new System.Data.SqlClient.SqlParameter("@SomatischeAuff", System.Data.SqlDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.SqlClient.SqlParameter("@PsychischeAuff", System.Data.SqlDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.SqlClient.SqlParameter("@VerhaltenAufnahme", System.Data.SqlDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.SqlClient.SqlParameter("@SonstigeBesonderheiten", System.Data.SqlDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.SqlClient.SqlParameter("@SofortMassnahmen", System.Data.SqlDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.SqlClient.SqlParameter("@IDUrlaub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDUrlaub"),
            new System.Data.SqlClient.SqlParameter("@Fallnummer", System.Data.SqlDbType.Float, 0, "Fallnummer"),
            new System.Data.SqlClient.SqlParameter("@Gruppenkennzahl", System.Data.SqlDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.SqlClient.SqlParameter("@Verfuegungsdatum", System.Data.SqlDbType.DateTime, 0, "Verfuegungsdatum"),
            new System.Data.SqlClient.SqlParameter("@Bermerkung", System.Data.SqlDbType.VarChar, 0, "Bermerkung"),
            new System.Data.SqlClient.SqlParameter("@Besuchsregelung", System.Data.SqlDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.SqlClient.SqlParameter("@Postregelung", System.Data.SqlDbType.VarChar, 0, "Postregelung"),
            new System.Data.SqlClient.SqlParameter("@SonstigeRegelung", System.Data.SqlDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.SqlClient.SqlParameter("@Erwartungen", System.Data.SqlDbType.VarChar, 0, "Erwartungen"),
            new System.Data.SqlClient.SqlParameter("@IDErstkontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDErstkontakt"),
            new System.Data.SqlClient.SqlParameter("@Gewicht", System.Data.SqlDbType.Float, 0, "Gewicht"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierung", System.Data.SqlDbType.DateTime, 0, "NaechsteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierungBemerkung", System.Data.SqlDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.SqlClient.SqlParameter("@TaschengeldSollstand", System.Data.SqlDbType.Float, 0, "TaschengeldSollstand"),
            new System.Data.SqlClient.SqlParameter("@TaschegeldVortragDatum", System.Data.SqlDbType.DateTime, 0, "TaschegeldVortragDatum"),
            new System.Data.SqlClient.SqlParameter("@TaschengeldVortragBetrag", System.Data.SqlDbType.Float, 0, "TaschengeldVortragBetrag"),
            new System.Data.SqlClient.SqlParameter("@Ausgleichszahlung", System.Data.SqlDbType.Float, 0, "Ausgleichszahlung"),
            new System.Data.SqlClient.SqlParameter("@IDKlinik", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKlinik"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich")});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = resources.GetString("sqlCommand3.CommandText");
            this.sqlCommand3.Connection = this.sqlConn;
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = resources.GetString("sqlCommand4.CommandText");
            this.sqlCommand4.Connection = this.sqlConn;
            this.sqlCommand4.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDPatient", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPatient"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthaltVerlauf", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthaltVerlauf"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Aufnahme", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Aufnahme"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Entlassung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Entlassung"),
            new System.Data.SqlClient.SqlParameter("@IDEinrichtung_Aufnahme", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEinrichtung_Aufnahme"),
            new System.Data.SqlClient.SqlParameter("@IDEinrichtung_Entlassung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEinrichtung_Entlassung"),
            new System.Data.SqlClient.SqlParameter("@Aufnahmezeitpunkt", System.Data.SqlDbType.DateTime, 0, "Aufnahmezeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@Entlassungszeitpunkt", System.Data.SqlDbType.DateTime, 0, "Entlassungszeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeArt", System.Data.SqlDbType.Int, 0, "AufnahmeArt"),
            new System.Data.SqlClient.SqlParameter("@BegleitungVon", System.Data.SqlDbType.VarChar, 0, "BegleitungVon"),
            new System.Data.SqlClient.SqlParameter("@Entlassungsbemerkung", System.Data.SqlDbType.Text, 0, "Entlassungsbemerkung"),
            new System.Data.SqlClient.SqlParameter("@SomatischeAuff", System.Data.SqlDbType.VarChar, 0, "SomatischeAuff"),
            new System.Data.SqlClient.SqlParameter("@PsychischeAuff", System.Data.SqlDbType.VarChar, 0, "PsychischeAuff"),
            new System.Data.SqlClient.SqlParameter("@VerhaltenAufnahme", System.Data.SqlDbType.VarChar, 0, "VerhaltenAufnahme"),
            new System.Data.SqlClient.SqlParameter("@SonstigeBesonderheiten", System.Data.SqlDbType.VarChar, 0, "SonstigeBesonderheiten"),
            new System.Data.SqlClient.SqlParameter("@SofortMassnahmen", System.Data.SqlDbType.VarChar, 0, "SofortMassnahmen"),
            new System.Data.SqlClient.SqlParameter("@IDUrlaub", System.Data.SqlDbType.UniqueIdentifier, 0, "IDUrlaub"),
            new System.Data.SqlClient.SqlParameter("@Fallnummer", System.Data.SqlDbType.Float, 0, "Fallnummer"),
            new System.Data.SqlClient.SqlParameter("@Gruppenkennzahl", System.Data.SqlDbType.VarChar, 0, "Gruppenkennzahl"),
            new System.Data.SqlClient.SqlParameter("@Verfuegungsdatum", System.Data.SqlDbType.DateTime, 0, "Verfuegungsdatum"),
            new System.Data.SqlClient.SqlParameter("@Bermerkung", System.Data.SqlDbType.VarChar, 0, "Bermerkung"),
            new System.Data.SqlClient.SqlParameter("@Besuchsregelung", System.Data.SqlDbType.VarChar, 0, "Besuchsregelung"),
            new System.Data.SqlClient.SqlParameter("@Postregelung", System.Data.SqlDbType.VarChar, 0, "Postregelung"),
            new System.Data.SqlClient.SqlParameter("@SonstigeRegelung", System.Data.SqlDbType.VarChar, 0, "SonstigeRegelung"),
            new System.Data.SqlClient.SqlParameter("@Erwartungen", System.Data.SqlDbType.VarChar, 0, "Erwartungen"),
            new System.Data.SqlClient.SqlParameter("@IDErstkontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDErstkontakt"),
            new System.Data.SqlClient.SqlParameter("@Gewicht", System.Data.SqlDbType.Float, 0, "Gewicht"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierung", System.Data.SqlDbType.DateTime, 0, "NaechsteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierungBemerkung", System.Data.SqlDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.SqlClient.SqlParameter("@TaschengeldSollstand", System.Data.SqlDbType.Float, 0, "TaschengeldSollstand"),
            new System.Data.SqlClient.SqlParameter("@TaschegeldVortragDatum", System.Data.SqlDbType.DateTime, 0, "TaschegeldVortragDatum"),
            new System.Data.SqlClient.SqlParameter("@TaschengeldVortragBetrag", System.Data.SqlDbType.Float, 0, "TaschengeldVortragBetrag"),
            new System.Data.SqlClient.SqlParameter("@Ausgleichszahlung", System.Data.SqlDbType.Float, 0, "Ausgleichszahlung"),
            new System.Data.SqlClient.SqlParameter("@IDKlinik", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKlinik"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAufenthaltVerlauf
            // 
            this.daAufenthaltVerlauf.DeleteCommand = this.sqlCommand5;
            this.daAufenthaltVerlauf.InsertCommand = this.sqlCommand6;
            this.daAufenthaltVerlauf.SelectCommand = this.sqlCommand7;
            this.daAufenthaltVerlauf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AufenthaltVerlauf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung_Von", "IDAbteilung_Von"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung_Nach", "IDAbteilung_Nach"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Datum", "Datum"),
                        new System.Data.Common.DataColumnMapping("ZuweisenderArzt", "ZuweisenderArzt"),
                        new System.Data.Common.DataColumnMapping("AufnahmeArzt", "AufnahmeArzt"),
                        new System.Data.Common.DataColumnMapping("Aufnahmegespraech", "Aufnahmegespraech"),
                        new System.Data.Common.DataColumnMapping("Abschlussbemerkung", "Abschlussbemerkung"),
                        new System.Data.Common.DataColumnMapping("AufnahmeStatus", "AufnahmeStatus")})});
            this.daAufenthaltVerlauf.UpdateCommand = this.sqlCommand8;
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = "DELETE FROM [AufenthaltVerlauf] WHERE (([ID] = @Original_ID))";
            this.sqlCommand5.Connection = this.sqlConn;
            this.sqlCommand5.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand6
            // 
            this.sqlCommand6.CommandText = resources.GetString("sqlCommand6.CommandText");
            this.sqlCommand6.Connection = this.sqlConn;
            this.sqlCommand6.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung_Von", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung_Von"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung_Nach", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung_Nach"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@Bemerkung", System.Data.SqlDbType.Text, 0, "Bemerkung"),
            new System.Data.SqlClient.SqlParameter("@Datum", System.Data.SqlDbType.DateTime, 0, "Datum"),
            new System.Data.SqlClient.SqlParameter("@ZuweisenderArzt", System.Data.SqlDbType.VarChar, 0, "ZuweisenderArzt"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeArzt", System.Data.SqlDbType.VarChar, 0, "AufnahmeArzt"),
            new System.Data.SqlClient.SqlParameter("@Aufnahmegespraech", System.Data.SqlDbType.Text, 0, "Aufnahmegespraech"),
            new System.Data.SqlClient.SqlParameter("@Abschlussbemerkung", System.Data.SqlDbType.Text, 0, "Abschlussbemerkung"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeStatus", System.Data.SqlDbType.Text, 0, "AufnahmeStatus")});
            // 
            // sqlCommand7
            // 
            this.sqlCommand7.CommandText = resources.GetString("sqlCommand7.CommandText");
            this.sqlCommand7.Connection = this.sqlConn;
            // 
            // sqlCommand8
            // 
            this.sqlCommand8.CommandText = resources.GetString("sqlCommand8.CommandText");
            this.sqlCommand8.Connection = this.sqlConn;
            this.sqlCommand8.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung_Von", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung_Von"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung_Nach", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung_Nach"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@Bemerkung", System.Data.SqlDbType.Text, 0, "Bemerkung"),
            new System.Data.SqlClient.SqlParameter("@Datum", System.Data.SqlDbType.DateTime, 0, "Datum"),
            new System.Data.SqlClient.SqlParameter("@ZuweisenderArzt", System.Data.SqlDbType.VarChar, 0, "ZuweisenderArzt"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeArzt", System.Data.SqlDbType.VarChar, 0, "AufnahmeArzt"),
            new System.Data.SqlClient.SqlParameter("@Aufnahmegespraech", System.Data.SqlDbType.Text, 0, "Aufnahmegespraech"),
            new System.Data.SqlClient.SqlParameter("@Abschlussbemerkung", System.Data.SqlDbType.Text, 0, "Abschlussbemerkung"),
            new System.Data.SqlClient.SqlParameter("@AufnahmeStatus", System.Data.SqlDbType.Text, 0, "AufnahmeStatus"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAbteilung
            // 
            this.daAbteilung.DeleteCommand = this.sqlCommand9;
            this.daAbteilung.InsertCommand = this.sqlCommand10;
            this.daAbteilung.SelectCommand = this.sqlCommand11;
            this.daAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            this.daAbteilung.UpdateCommand = this.sqlCommand12;
            // 
            // sqlCommand9
            // 
            this.sqlCommand9.CommandText = "DELETE FROM [Abteilung] WHERE (([ID] = @Original_ID))";
            this.sqlCommand9.Connection = this.sqlConn;
            this.sqlCommand9.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand10
            // 
            this.sqlCommand10.CommandText = resources.GetString("sqlCommand10.CommandText");
            this.sqlCommand10.Connection = this.sqlConn;
            this.sqlCommand10.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Bezeichnung", System.Data.SqlDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.SqlClient.SqlParameter("@IDKlinik", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKlinik"),
            new System.Data.SqlClient.SqlParameter("@IDKontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontakt"),
            new System.Data.SqlClient.SqlParameter("@RMOptionalJN", System.Data.SqlDbType.Bit, 0, "RMOptionalJN"),
            new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 0, "Reihenfolge"),
            new System.Data.SqlClient.SqlParameter("@Basisabteilung", System.Data.SqlDbType.Bit, 0, "Basisabteilung")});
            // 
            // sqlCommand11
            // 
            this.sqlCommand11.CommandText = "SELECT        ID, Bezeichnung, IDKlinik, IDKontakt, RMOptionalJN, Reihenfolge, Ba" +
    "sisabteilung\r\nFROM            Abteilung";
            this.sqlCommand11.Connection = this.sqlConn;
            // 
            // sqlCommand12
            // 
            this.sqlCommand12.CommandText = resources.GetString("sqlCommand12.CommandText");
            this.sqlCommand12.Connection = this.sqlConn;
            this.sqlCommand12.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@Bezeichnung", System.Data.SqlDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.SqlClient.SqlParameter("@IDKlinik", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKlinik"),
            new System.Data.SqlClient.SqlParameter("@IDKontakt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDKontakt"),
            new System.Data.SqlClient.SqlParameter("@RMOptionalJN", System.Data.SqlDbType.Bit, 0, "RMOptionalJN"),
            new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 0, "Reihenfolge"),
            new System.Data.SqlClient.SqlParameter("@Basisabteilung", System.Data.SqlDbType.Bit, 0, "Basisabteilung"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daBereich
            // 
            this.daBereich.DeleteCommand = this.sqlCommand13;
            this.daBereich.InsertCommand = this.sqlCommand14;
            this.daBereich.SelectCommand = this.sqlCommand15;
            this.daBereich.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("UnterAerztlicheFuehrungJN", "UnterAerztlicheFuehrungJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            this.daBereich.UpdateCommand = this.sqlCommand16;
            // 
            // sqlCommand13
            // 
            this.sqlCommand13.CommandText = "DELETE FROM [Bereich] WHERE (([ID] = @Original_ID))";
            this.sqlCommand13.Connection = this.sqlConn;
            this.sqlCommand13.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand14
            // 
            this.sqlCommand14.CommandText = resources.GetString("sqlCommand14.CommandText");
            this.sqlCommand14.Connection = this.sqlConn;
            this.sqlCommand14.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@Bezeichnung", System.Data.SqlDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.SqlClient.SqlParameter("@UnterAerztlicheFuehrungJN", System.Data.SqlDbType.Bit, 0, "UnterAerztlicheFuehrungJN"),
            new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 0, "Reihenfolge")});
            // 
            // sqlCommand15
            // 
            this.sqlCommand15.CommandText = "SELECT        ID, IDAbteilung, IDBereich, Bezeichnung, UnterAerztlicheFuehrungJN," +
    " Reihenfolge\r\nFROM            Bereich";
            this.sqlCommand15.Connection = this.sqlConn;
            // 
            // sqlCommand16
            // 
            this.sqlCommand16.CommandText = resources.GetString("sqlCommand16.CommandText");
            this.sqlCommand16.Connection = this.sqlConn;
            this.sqlCommand16.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@Bezeichnung", System.Data.SqlDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.SqlClient.SqlParameter("@UnterAerztlicheFuehrungJN", System.Data.SqlDbType.Bit, 0, "UnterAerztlicheFuehrungJN"),
            new System.Data.SqlClient.SqlParameter("@Reihenfolge", System.Data.SqlDbType.Int, 0, "Reihenfolge"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientSmall
            // 
            this.daPatientSmall.SelectCommand = this.sqlCommand19;
            this.daPatientSmall.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich")})});
            // 
            // sqlCommand19
            // 
            this.sqlCommand19.CommandText = "SELECT        ID, Vorname, Nachname, IDAbteilung, IDBereich\r\nFROM            Pati" +
    "ent";
            this.sqlCommand19.Connection = this.sqlConn;

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection sqlConn;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
        private System.Data.SqlClient.SqlCommand sqlCommand6;
        private System.Data.SqlClient.SqlCommand sqlCommand7;
        private System.Data.SqlClient.SqlCommand sqlCommand8;
        public System.Data.SqlClient.SqlDataAdapter daPatient;
        public System.Data.SqlClient.SqlDataAdapter daAufenthalt;
        public System.Data.SqlClient.SqlDataAdapter daAufenthaltVerlauf;
        public System.Data.SqlClient.SqlDataAdapter daAbteilung;
        private System.Data.SqlClient.SqlCommand sqlCommand9;
        private System.Data.SqlClient.SqlCommand sqlCommand10;
        private System.Data.SqlClient.SqlCommand sqlCommand11;
        private System.Data.SqlClient.SqlCommand sqlCommand12;
        public System.Data.SqlClient.SqlDataAdapter daBereich;
        private System.Data.SqlClient.SqlCommand sqlCommand13;
        private System.Data.SqlClient.SqlCommand sqlCommand14;
        private System.Data.SqlClient.SqlCommand sqlCommand15;
        private System.Data.SqlClient.SqlCommand sqlCommand16;
        public System.Data.SqlClient.SqlDataAdapter daPatientSmall;
        private System.Data.SqlClient.SqlCommand sqlCommand19;
    }
}
