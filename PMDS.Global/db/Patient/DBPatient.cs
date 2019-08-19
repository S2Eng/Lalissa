using PMDS.Data.Patient;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;
using RBU;
//----------------------------------------------------------------------------
/// <summary>
///	DBPatient.cs
/// Erstellt am:	26.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Text;



namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Patienten-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPatient : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daPatientByID;
		private System.Data.OleDb.OleDbDataAdapter daPatientListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter daPatientListeFilter;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
		private OleDbDataAdapter daPatientListeFilterMitEntlassenen;
        private OleDbCommand oleDbCommand1;
        private OleDbDataAdapter daAerzteByPatient;
        private OleDbCommand oleDbCommand2;
        private dsAerzte dsAerzte1;
        private OleDbCommand oleDbSelectCommand4;
        private OleDbDataAdapter daPatientNichtAufgenommen;
        private OleDbDataAdapter daPatientListeFilterMitBezugsPfleger; ///{{{eng}}}04.10.2007
        private OleDbCommand oleDbCommand3;
        private OleDbDataAdapter daPatientFoto;
        private OleDbCommand oleDbSelectCommand5;
        private OleDbDataAdapter daPatientByNr;
        private OleDbCommand oleDbCommand4;								///{{{eng}}}04.10.2007
		private System.ComponentModel.Container components = null;

        private static OleDbCommand _cmdPflegeStufe;
        private static OleDbCommand _cmdSachwalter;
        private static OleDbCommand _cmdFreiheitsbeschränkung;
        private OleDbDataAdapter daIDPatientListeFilter;
        private OleDbCommand oleDbCommand5;
        private OleDbDataAdapter daKlientenlisteGrid;
        private OleDbCommand oleDbCommand6;
        private OleDbDataAdapter daKlientenlisteGridMitBezugsPfleger;
        private OleDbCommand oleDbCommand7;
        private OleDbDataAdapter daKlientenlisteGridHistorie;
        private OleDbCommand oleDbCommand8;
        private OleDbDataAdapter daPatientZusaätzlicheDatenByID;
        private OleDbCommand oleDbCommand9;
        private OleDbCommand oleDbCommand10;
        private OleDbCommand oleDbCommand11;
        private OleDbCommand oleDbCommand12;
        private OleDbDataAdapter daPatientNurBewerber;
        private OleDbCommand oleDbCommand13;
        private dsPatient dsPatient1;
        private static OleDbCommand _cmdFreiheitbeschraenkt;






		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPatient()
		{
			try {
			InitializeComponent();
			}
			catch{
			}
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert das Foto als byte[] des Klienten oder null
        /// </summary>
        //----------------------------------------------------------------------------
        public byte[] GetFoto(Guid IDPatient)
        {
            dsPatientFoto.PatientDataTable dt = new dsPatientFoto.PatientDataTable();
            daPatientFoto.SelectCommand.Parameters[0].Value = IDPatient;
            DataBase.Fill(daPatientFoto, dt);
            if (dt.Count > 0)
                if(!dt[0].IsFotoNull())
                    return dt[0].Foto;
            return null;
        }
        
		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatient));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daPatientListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatientByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatientListeFilter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPatientListeFilterMitEntlassenen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daAerzteByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsAerzte1 = new PMDS.Global.db.Global.dsAerzte();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daPatientNichtAufgenommen = new System.Data.OleDb.OleDbDataAdapter();
            this.daPatientListeFilterMitBezugsPfleger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPatientFoto = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daPatientByNr = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daIDPatientListeFilter = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daKlientenlisteGrid = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.daKlientenlisteGridMitBezugsPfleger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.daKlientenlisteGridHistorie = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.daPatientZusaätzlicheDatenByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.daPatientNurBewerber = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand13 = new System.Data.OleDb.OleDbCommand();
            this.dsPatient1 = new PMDS.Global.db.Patient.dsPatient();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatient1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // daPatientListe
            // 
            this.daPatientListe.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Nachname + \' \' + Vorname AS TEXT\r\nFROM         dbo.Patient\r\nORDER " +
    "BY Nachname + \' \' + Vorname";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daPatientByID
            // 
            this.daPatientByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientByID.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientByID.SelectCommand = this.oleDbSelectCommand2;
            this.daPatientByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("Milieubetreuung", "Milieubetreuung"),
                        new System.Data.Common.DataColumnMapping("KZUeberlebender", "KZUeberlebender"),
                        new System.Data.Common.DataColumnMapping("Anatomie", "Anatomie"),
                        new System.Data.Common.DataColumnMapping("Einzelzimmer", "Einzelzimmer"),
                        new System.Data.Common.DataColumnMapping("Selbstzahler", "Selbstzahler"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("KürzungLetzterTagAnwesenheit", "KürzungLetzterTagAnwesenheit"),
                        new System.Data.Common.DataColumnMapping("Behindertenausweis", "Behindertenausweis"),
                        new System.Data.Common.DataColumnMapping("Sozialcard", "Sozialcard"),
                        new System.Data.Common.DataColumnMapping("IDAdresseSub", "IDAdresseSub")})});
            this.daPatientByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Patient] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection2;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection2
            // 
            this.oleDbConnection2.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection2;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Konfision", System.Data.OleDb.OleDbType.VarChar, 0, "Konfision"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("Staatsb", System.Data.OleDb.OleDbType.VarChar, 0, "Staatsb"),
            new System.Data.OleDb.OleDbParameter("Klasse", System.Data.OleDb.OleDbType.VarChar, 0, "Klasse"),
            new System.Data.OleDb.OleDbParameter("KrankenKasse", System.Data.OleDb.OleDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.OleDb.OleDbParameter("BlutGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.OleDb.OleDbParameter("Resusfaktor", System.Data.OleDb.OleDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.OleDb.OleDbParameter("LedigerName", System.Data.OleDb.OleDbType.VarChar, 0, "LedigerName"),
            new System.Data.OleDb.OleDbParameter("Geburtsort", System.Data.OleDb.OleDbType.VarChar, 0, "Geburtsort"),
            new System.Data.OleDb.OleDbParameter("Voraufenthalt", System.Data.OleDb.OleDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.OleDb.OleDbParameter("Angehörige", System.Data.OleDb.OleDbType.LongVarChar, 0, "Angehörige"),
            new System.Data.OleDb.OleDbParameter("VersicherungsNr", System.Data.OleDb.OleDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.OleDb.OleDbParameter("ArbeitslosBezSeit", System.Data.OleDb.OleDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.OleDb.OleDbParameter("KrankengeldSeit", System.Data.OleDb.OleDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.OleDb.OleDbParameter("Hauptversicherung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hauptversicherung"),
            new System.Data.OleDb.OleDbParameter("ErlernterBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.OleDb.OleDbParameter("Besonderheit", System.Data.OleDb.OleDbType.LongVarChar, 0, "Besonderheit"),
            new System.Data.OleDb.OleDbParameter("Betreuer", System.Data.OleDb.OleDbType.LongVarChar, 0, "Betreuer"),
            new System.Data.OleDb.OleDbParameter("Sachwalter", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sachwalter"),
            new System.Data.OleDb.OleDbParameter("SachWalterBelange", System.Data.OleDb.OleDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.OleDb.OleDbParameter("SachWalterVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterVon"),
            new System.Data.OleDb.OleDbParameter("SachWalterBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterBis"),
            new System.Data.OleDb.OleDbParameter("SterbeRegel", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbeRegel"),
            new System.Data.OleDb.OleDbParameter("Depotinjektion", System.Data.OleDb.OleDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.OleDb.OleDbParameter("Hausarzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hausarzt"),
            new System.Data.OleDb.OleDbParameter("Vermerk", System.Data.OleDb.OleDbType.LongVarChar, 0, "Vermerk"),
            new System.Data.OleDb.OleDbParameter("SterbeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SterbeDatum"),
            new System.Data.OleDb.OleDbParameter("AktuellerDienstgeber", System.Data.OleDb.OleDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.OleDb.OleDbParameter("DerzeitigerBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.OleDb.OleDbParameter("RezeptgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("PflegegeldantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegegeldantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPflegegeldantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPflegegeldantrag"),
            new System.Data.OleDb.OleDbParameter("PensionsteilungsantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PensionsteilungsantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPensionsteilungsantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPensionsteilungsantrag"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("RollungVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungVon"),
            new System.Data.OleDb.OleDbParameter("RollungBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungBis"),
            new System.Data.OleDb.OleDbParameter("Klientennummer", System.Data.OleDb.OleDbType.VarChar, 0, "Klientennummer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("abwesenheitenHändBerech", System.Data.OleDb.OleDbType.Boolean, 0, "abwesenheitenHändBerech"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Kennwort", System.Data.OleDb.OleDbType.VarChar, 0, "Kennwort"),
            new System.Data.OleDb.OleDbParameter("blob_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("EinverständniserklärungFileType", System.Data.OleDb.OleDbType.VarWChar, 0, "EinverständniserklärungFileType"),
            new System.Data.OleDb.OleDbParameter("jpg_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("Verstorben", System.Data.OleDb.OleDbType.Boolean, 0, "Verstorben"),
            new System.Data.OleDb.OleDbParameter("Todeszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Todeszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("DNR", System.Data.OleDb.OleDbType.Boolean, 0, "DNR"),
            new System.Data.OleDb.OleDbParameter("Adelstitel", System.Data.OleDb.OleDbType.VarChar, 0, "Adelstitel"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Initialberuehrung", System.Data.OleDb.OleDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.OleDb.OleDbParameter("Klingeln", System.Data.OleDb.OleDbType.VarChar, 0, "Klingeln"),
            new System.Data.OleDb.OleDbParameter("Wohnsituation", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.OleDb.OleDbParameter("Haustier", System.Data.OleDb.OleDbType.VarChar, 0, "Haustier"),
            new System.Data.OleDb.OleDbParameter("LiftJN", System.Data.OleDb.OleDbType.Boolean, 0, "LiftJN"),
            new System.Data.OleDb.OleDbParameter("WohnungAbgemeldetJN", System.Data.OleDb.OleDbType.Boolean, 0, "WohnungAbgemeldetJN"),
            new System.Data.OleDb.OleDbParameter("Haarfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.OleDb.OleDbParameter("Augenfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.OleDb.OleDbParameter("BesondereAeusserlicheKennzeichen", System.Data.OleDb.OleDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.OleDb.OleDbParameter("FernsehgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("TelefongebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerberJN"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("Stationswunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("ReligionWunsch", System.Data.OleDb.OleDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.OleDb.OleDbParameter("KommunionJN", System.Data.OleDb.OleDbType.Boolean, 0, "KommunionJN"),
            new System.Data.OleDb.OleDbParameter("KrankensalbungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KrankensalbungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("WaescheMarkiert", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.OleDb.OleDbParameter("WaescheWaschen", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.OleDb.OleDbParameter("Zustaendige_Stelle", System.Data.OleDb.OleDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.Integer, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Statur", System.Data.OleDb.OleDbType.VarChar, 0, "Statur"),
            new System.Data.OleDb.OleDbParameter("Namenstag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Namenstag"),
            new System.Data.OleDb.OleDbParameter("Kosename", System.Data.OleDb.OleDbType.VarChar, 0, "Kosename"),
            new System.Data.OleDb.OleDbParameter("Privatversicherung", System.Data.OleDb.OleDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.OleDb.OleDbParameter("PrivPolNr", System.Data.OleDb.OleDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungJN"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungBeachtlichJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "PatientverfuegungDatum"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungAnmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.OleDb.OleDbParameter("Milieubetreuung", System.Data.OleDb.OleDbType.Boolean, 0, "Milieubetreuung"),
            new System.Data.OleDb.OleDbParameter("KZUeberlebender", System.Data.OleDb.OleDbType.Boolean, 0, "KZUeberlebender"),
            new System.Data.OleDb.OleDbParameter("Anatomie", System.Data.OleDb.OleDbType.Boolean, 0, "Anatomie"),
            new System.Data.OleDb.OleDbParameter("Einzelzimmer", System.Data.OleDb.OleDbType.Boolean, 0, "Einzelzimmer"),
            new System.Data.OleDb.OleDbParameter("Selbstzahler", System.Data.OleDb.OleDbType.Boolean, 0, "Selbstzahler"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("KürzungLetzterTagAnwesenheit", System.Data.OleDb.OleDbType.Boolean, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.OleDb.OleDbParameter("Behindertenausweis", System.Data.OleDb.OleDbType.Boolean, 0, "Behindertenausweis"),
            new System.Data.OleDb.OleDbParameter("Sozialcard", System.Data.OleDb.OleDbType.Boolean, 0, "Sozialcard"),
            new System.Data.OleDb.OleDbParameter("IDAdresseSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresseSub")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection2;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Konfision", System.Data.OleDb.OleDbType.VarChar, 0, "Konfision"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("Staatsb", System.Data.OleDb.OleDbType.VarChar, 0, "Staatsb"),
            new System.Data.OleDb.OleDbParameter("Klasse", System.Data.OleDb.OleDbType.VarChar, 0, "Klasse"),
            new System.Data.OleDb.OleDbParameter("KrankenKasse", System.Data.OleDb.OleDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.OleDb.OleDbParameter("BlutGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.OleDb.OleDbParameter("Resusfaktor", System.Data.OleDb.OleDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.OleDb.OleDbParameter("LedigerName", System.Data.OleDb.OleDbType.VarChar, 0, "LedigerName"),
            new System.Data.OleDb.OleDbParameter("Geburtsort", System.Data.OleDb.OleDbType.VarChar, 0, "Geburtsort"),
            new System.Data.OleDb.OleDbParameter("Voraufenthalt", System.Data.OleDb.OleDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.OleDb.OleDbParameter("Angehörige", System.Data.OleDb.OleDbType.LongVarChar, 0, "Angehörige"),
            new System.Data.OleDb.OleDbParameter("VersicherungsNr", System.Data.OleDb.OleDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.OleDb.OleDbParameter("ArbeitslosBezSeit", System.Data.OleDb.OleDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.OleDb.OleDbParameter("KrankengeldSeit", System.Data.OleDb.OleDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.OleDb.OleDbParameter("Hauptversicherung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hauptversicherung"),
            new System.Data.OleDb.OleDbParameter("ErlernterBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.OleDb.OleDbParameter("Besonderheit", System.Data.OleDb.OleDbType.LongVarChar, 0, "Besonderheit"),
            new System.Data.OleDb.OleDbParameter("Betreuer", System.Data.OleDb.OleDbType.LongVarChar, 0, "Betreuer"),
            new System.Data.OleDb.OleDbParameter("Sachwalter", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sachwalter"),
            new System.Data.OleDb.OleDbParameter("SachWalterBelange", System.Data.OleDb.OleDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.OleDb.OleDbParameter("SachWalterVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterVon"),
            new System.Data.OleDb.OleDbParameter("SachWalterBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterBis"),
            new System.Data.OleDb.OleDbParameter("SterbeRegel", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbeRegel"),
            new System.Data.OleDb.OleDbParameter("Depotinjektion", System.Data.OleDb.OleDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.OleDb.OleDbParameter("Hausarzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hausarzt"),
            new System.Data.OleDb.OleDbParameter("Vermerk", System.Data.OleDb.OleDbType.LongVarChar, 0, "Vermerk"),
            new System.Data.OleDb.OleDbParameter("SterbeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SterbeDatum"),
            new System.Data.OleDb.OleDbParameter("AktuellerDienstgeber", System.Data.OleDb.OleDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.OleDb.OleDbParameter("DerzeitigerBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.OleDb.OleDbParameter("RezeptgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("PflegegeldantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegegeldantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPflegegeldantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPflegegeldantrag"),
            new System.Data.OleDb.OleDbParameter("PensionsteilungsantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PensionsteilungsantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPensionsteilungsantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPensionsteilungsantrag"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("RollungVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungVon"),
            new System.Data.OleDb.OleDbParameter("RollungBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungBis"),
            new System.Data.OleDb.OleDbParameter("Klientennummer", System.Data.OleDb.OleDbType.VarChar, 0, "Klientennummer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("abwesenheitenHändBerech", System.Data.OleDb.OleDbType.Boolean, 0, "abwesenheitenHändBerech"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Kennwort", System.Data.OleDb.OleDbType.VarChar, 0, "Kennwort"),
            new System.Data.OleDb.OleDbParameter("blob_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("EinverständniserklärungFileType", System.Data.OleDb.OleDbType.VarWChar, 0, "EinverständniserklärungFileType"),
            new System.Data.OleDb.OleDbParameter("jpg_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("Verstorben", System.Data.OleDb.OleDbType.Boolean, 0, "Verstorben"),
            new System.Data.OleDb.OleDbParameter("Todeszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Todeszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("DNR", System.Data.OleDb.OleDbType.Boolean, 0, "DNR"),
            new System.Data.OleDb.OleDbParameter("Adelstitel", System.Data.OleDb.OleDbType.VarChar, 0, "Adelstitel"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Initialberuehrung", System.Data.OleDb.OleDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.OleDb.OleDbParameter("Klingeln", System.Data.OleDb.OleDbType.VarChar, 0, "Klingeln"),
            new System.Data.OleDb.OleDbParameter("Wohnsituation", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.OleDb.OleDbParameter("Haustier", System.Data.OleDb.OleDbType.VarChar, 0, "Haustier"),
            new System.Data.OleDb.OleDbParameter("LiftJN", System.Data.OleDb.OleDbType.Boolean, 0, "LiftJN"),
            new System.Data.OleDb.OleDbParameter("WohnungAbgemeldetJN", System.Data.OleDb.OleDbType.Boolean, 0, "WohnungAbgemeldetJN"),
            new System.Data.OleDb.OleDbParameter("Haarfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.OleDb.OleDbParameter("Augenfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.OleDb.OleDbParameter("BesondereAeusserlicheKennzeichen", System.Data.OleDb.OleDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.OleDb.OleDbParameter("FernsehgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("TelefongebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerberJN"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("Stationswunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("ReligionWunsch", System.Data.OleDb.OleDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.OleDb.OleDbParameter("KommunionJN", System.Data.OleDb.OleDbType.Boolean, 0, "KommunionJN"),
            new System.Data.OleDb.OleDbParameter("KrankensalbungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KrankensalbungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("WaescheMarkiert", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.OleDb.OleDbParameter("WaescheWaschen", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.OleDb.OleDbParameter("Zustaendige_Stelle", System.Data.OleDb.OleDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.Integer, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Statur", System.Data.OleDb.OleDbType.VarChar, 0, "Statur"),
            new System.Data.OleDb.OleDbParameter("Namenstag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Namenstag"),
            new System.Data.OleDb.OleDbParameter("Kosename", System.Data.OleDb.OleDbType.VarChar, 0, "Kosename"),
            new System.Data.OleDb.OleDbParameter("Privatversicherung", System.Data.OleDb.OleDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.OleDb.OleDbParameter("PrivPolNr", System.Data.OleDb.OleDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungJN"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungBeachtlichJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "PatientverfuegungDatum"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungAnmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.OleDb.OleDbParameter("Milieubetreuung", System.Data.OleDb.OleDbType.Boolean, 0, "Milieubetreuung"),
            new System.Data.OleDb.OleDbParameter("KZUeberlebender", System.Data.OleDb.OleDbType.Boolean, 0, "KZUeberlebender"),
            new System.Data.OleDb.OleDbParameter("Anatomie", System.Data.OleDb.OleDbType.Boolean, 0, "Anatomie"),
            new System.Data.OleDb.OleDbParameter("Einzelzimmer", System.Data.OleDb.OleDbType.Boolean, 0, "Einzelzimmer"),
            new System.Data.OleDb.OleDbParameter("Selbstzahler", System.Data.OleDb.OleDbType.Boolean, 0, "Selbstzahler"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("KürzungLetzterTagAnwesenheit", System.Data.OleDb.OleDbType.Boolean, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.OleDb.OleDbParameter("Behindertenausweis", System.Data.OleDb.OleDbType.Boolean, 0, "Behindertenausweis"),
            new System.Data.OleDb.OleDbParameter("Sozialcard", System.Data.OleDb.OleDbType.Boolean, 0, "Sozialcard"),
            new System.Data.OleDb.OleDbParameter("IDAdresseSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresseSub"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientListeFilter
            // 
            this.daPatientListeFilter.SelectCommand = this.oleDbSelectCommand3;
            this.daPatientListeFilter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            // 
            // daPatientListeFilterMitEntlassenen
            // 
            this.daPatientListeFilterMitEntlassenen.SelectCommand = this.oleDbCommand1;
            this.daPatientListeFilterMitEntlassenen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "UrlaubVerlauf", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // daAerzteByPatient
            // 
            this.daAerzteByPatient.SelectCommand = this.oleDbCommand2;
            this.daAerzteByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Bis")});
            // 
            // dsAerzte1
            // 
            this.dsAerzte1.DataSetName = "dsAerzte";
            this.dsAerzte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            // 
            // daPatientNichtAufgenommen
            // 
            this.daPatientNichtAufgenommen.SelectCommand = this.oleDbSelectCommand4;
            this.daPatientNichtAufgenommen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Sexus", "Sexus")})});
            // 
            // daPatientListeFilterMitBezugsPfleger
            // 
            this.daPatientListeFilterMitBezugsPfleger.SelectCommand = this.oleDbCommand3;
            this.daPatientListeFilterMitBezugsPfleger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("idBezugsPfleger", "idBezugsPfleger"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // daPatientFoto
            // 
            this.daPatientFoto.SelectCommand = this.oleDbSelectCommand5;
            this.daPatientFoto.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Foto", "Foto")})});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = "SELECT     Foto\r\nFROM         Patient\r\nWHERE     (ID = ?)";
            this.oleDbSelectCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daPatientByNr
            // 
            this.daPatientByNr.SelectCommand = this.oleDbCommand4;
            this.daPatientByNr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Klientennummer", System.Data.OleDb.OleDbType.Char, 20, "Klientennummer")});
            // 
            // daIDPatientListeFilter
            // 
            this.daIDPatientListeFilter.SelectCommand = this.oleDbCommand5;
            this.daIDPatientListeFilter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID")})});
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = resources.GetString("oleDbCommand5.CommandText");
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            // 
            // daKlientenlisteGrid
            // 
            this.daKlientenlisteGrid.SelectCommand = this.oleDbCommand6;
            this.daKlientenlisteGrid.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("fruehestesUnterbringungEnde", "fruehestesUnterbringungEnde"),
                        new System.Data.Common.DataColumnMapping("Kennwort", "Kennwort")})});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = resources.GetString("oleDbCommand6.CommandText");
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            // 
            // daKlientenlisteGridMitBezugsPfleger
            // 
            this.daKlientenlisteGridMitBezugsPfleger.SelectCommand = this.oleDbCommand7;
            this.daKlientenlisteGridMitBezugsPfleger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("idBezugsPfleger", "idBezugsPfleger"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("fruehestesUnterbringungEnde", "fruehestesUnterbringungEnde"),
                        new System.Data.Common.DataColumnMapping("Kennwort", "Kennwort")})});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = resources.GetString("oleDbCommand7.CommandText");
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            // 
            // daKlientenlisteGridHistorie
            // 
            this.daKlientenlisteGridHistorie.SelectCommand = this.oleDbCommand8;
            this.daKlientenlisteGridHistorie.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("fruehestesUnterbringungEnde", "fruehestesUnterbringungEnde")})});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Param1", System.Data.OleDb.OleDbType.Guid, 16)});
            // 
            // daPatientZusaätzlicheDatenByID
            // 
            this.daPatientZusaätzlicheDatenByID.DeleteCommand = this.oleDbCommand9;
            this.daPatientZusaätzlicheDatenByID.InsertCommand = this.oleDbCommand10;
            this.daPatientZusaätzlicheDatenByID.SelectCommand = this.oleDbCommand11;
            this.daPatientZusaätzlicheDatenByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Sollstand", "Sollstand"),
                        new System.Data.Common.DataColumnMapping("minSaldo", "minSaldo")})});
            this.daPatientZusaätzlicheDatenByID.UpdateCommand = this.oleDbCommand12;
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = "DELETE FROM [Patient] WHERE (([ID] = ?) AND ([Sollstand] = ?) AND ([minSaldo] = ?" +
    "))";
            this.oleDbCommand9.Connection = this.oleDbConnection2;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = "INSERT INTO [Patient] ([ID], [Sollstand], [minSaldo]) VALUES (?, ?, ?)";
            this.oleDbCommand10.Connection = this.oleDbConnection2;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null)});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = "SELECT        ID, Sollstand, minSaldo\r\nFROM            Patient\r\nWHERE        (ID " +
    "= ?)";
            this.oleDbCommand11.Connection = this.oleDbConnection2;
            this.oleDbCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = "UPDATE [Patient] SET [ID] = ?, [Sollstand] = ?, [minSaldo] = ? WHERE (([ID] = ?) " +
    "AND ([Sollstand] = ?) AND ([minSaldo] = ?))";
            this.oleDbCommand12.Connection = this.oleDbConnection2;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientNurBewerber
            // 
            this.daPatientNurBewerber.SelectCommand = this.oleDbCommand13;
            this.daPatientNurBewerber.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("UrlaubText", "UrlaubText"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt")})});
            // 
            // oleDbCommand13
            // 
            this.oleDbCommand13.CommandText = resources.GetString("oleDbCommand13.CommandText");
            this.oleDbCommand13.Connection = this.oleDbConnection1;
            // 
            // dsPatient1
            // 
            this.dsPatient1.DataSetName = "dsPatient";
            this.dsPatient1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsPatient1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatient1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daPatientListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daPatientByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddPatientRow(Guid.NewGuid(), Guid.Empty, Guid.Empty, "", "", DateTime.MinValue,
				"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 
				"", "", "", "", "", DateTime.MinValue, DateTime.MinValue, "", "",
				"", "", DateTime.MinValue, "", "", false, false, DateTime.Now, false, DateTime.Now, "", DateTime.Now, DateTime.Now, "", 
                System.Guid.Empty, false, 0, 0, "", null, "", null, false, DateTime.MinValue, false,"", "", "", "", "", "", false, false, "", "", "",
                false, false, false, false, "", DateTime.MinValue , DateTime.MinValue , DateTime.MinValue, "", "", "", "", "",
                "", false, false, "", "", "", "", 0, "", DateTime.MinValue, "", "","", Guid.Empty, false, false, DateTime.MinValue, "", 
                false, false, false, false, false, System.Guid.Empty, false, false, false, System.Guid.Empty);

            ITEM[0].SetIDAbteilungNull();
            ITEM[0].SetGeburtsdatumNull();
			ITEM[0].SetSachWalterVonNull();
			ITEM[0].SetSachWalterBisNull();
			ITEM[0].SetSterbeDatumNull();
			ITEM[0].SetDatumPensionsteilungsantragNull();
			ITEM[0].SetDatumPflegegeldantragNull();
			ITEM[0].SetRollungBisNull();
			ITEM[0].SetRollungVonNull();
            ITEM[0].SetKlientennummerNull();
            ITEM[0].SetSterbeDatumNull();
            ITEM[0].SetTodeszeitpunktNull();
            ITEM[0].Setjpg_EinverständniserklärungNull();
            ITEM[0].Setblob_EinverständniserklärungNull();

            ITEM[0].SetBewerbungDatumNull();
            ITEM[0].SetEinzugswunschDatumNull();
            ITEM[0].SetAuszugswunschDatumNull();
            ITEM[0].SetNamenstagNull();
            ITEM[0].SetIDBenutzerNull();
            ITEM[0].SetPatientverfuegungDatumNull();
            ITEM[0].SetIDBereichNull();
            ITEM[0].SetIDAdresseSubNull();

        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsPatient.PatientDataTable ITEM
		{
			get	{	return dsPatient1.Patient;	}
		}

		#region IDBBase Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}

		#endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Patienten mit Stationen {{{eng}}} 04.10.2007
        /// </summary>    
        //----------------------------------------------------------------------------
        public dsPatientStation.PatientDataTable ByFilter(string patient,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, bool bShowEntlassen, Guid idBezugsPerson, System.Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            StringBuilder sbWhere = new StringBuilder();
            string sFieldJoin = " Aufenthalt.IDAbteilung ";
            SetFilterCommandTextWithJoin(cmd, sbWhere, patient, bKlinik, idAbteilung, idBereich, bShowEntlassen, idBezugsPerson, IDKlinik, sFieldJoin);

            //sbWhere.Append(" and Aufenthalt.ID is null");
            sbWhere.Append(" ORDER BY (Patient.Nachname + '  ' + Patient.Vorname)");

            if (idBezugsPerson == Guid.Empty)
                cmd.CommandText = this.daPatientListeFilter.SelectCommand.CommandText + sbWhere.ToString();

            else
                cmd.CommandText = daPatientListeFilterMitBezugsPfleger.SelectCommand.CommandText + sbWhere.ToString();
            
            dsPatientStation ds = new dsPatientStation();
            DataBase.Fill(da, ds.Patient);
            return ds.Patient;

        }
        public dsPatientStation.PatientDataTable GetKlientenNurBewerber()
        {
            dsPatientStation ds = new dsPatientStation();
            DataBase.Fill(this.daPatientNurBewerber, ds.Patient);
            return ds.Patient;
        }
        
		//----------------------------------------------------------------------------
		/// <summary>
		/// Patienten mit Stationen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsPatientStation.PatientDataTable ByFilter(Guid idPatient)
		{
			OleDbCommand cmd = new OleDbCommand();
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);

			string sWhere = " WHERE Patient.ID = ? ";
			cmd.Parameters.Add("Patient", OleDbType.Guid).Value = idPatient;
			cmd.CommandText = daPatientListeFilter.SelectCommand.CommandText+sWhere;

			dsPatientStation ds = new dsPatientStation();
			DataBase.Fill(da, ds.Patient);
			return ds.Patient;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Patienten mit Stationen
        /// </summary>
        //----------------------------------------------------------------------------
        public dsPatientStation.PatientDataTable GetPatienten(string patient,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, DateTime aufnahmezeitpunktVon, DateTime aufnahmezeitpunktBis,
            DateTime entlassungszeitpunktVon, DateTime entlassungszeitpunktBis, System.Guid IDKlinik)
        {
            //Nicht entlassene
            bool bShowEntlassen = false;

            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            StringBuilder sb = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder();

            //Änderung nach 17.10.2007 MDA
            SetFilterCommandTextWithJoin(cmd, sbWhere, patient, bKlinik, idAbteilung, idBereich, bShowEntlassen, Guid.Empty, IDKlinik);

            //Neu nach 30.10.2008 MDA
            //*************
            sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
            sbWhere.Append("AufenthaltVerlauf.IDAufenthalt is not null");
            //*****************

            if (aufnahmezeitpunktVon != new DateTime(1900, 01, 01))
            {
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("Aufenthalt.Aufnahmezeitpunkt >= ?");
                cmd.Parameters.Add("Aufnahmezeitpunkt", OleDbType.Date).Value = aufnahmezeitpunktVon.Date;
            }

            DateTime dt;
            if (aufnahmezeitpunktBis != new DateTime(1900, 01, 01))
            {
                dt = new DateTime(aufnahmezeitpunktBis.Year, aufnahmezeitpunktBis.Month, aufnahmezeitpunktBis.Day, 23, 59, 59);
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("Aufenthalt.Aufnahmezeitpunkt <= ?");
                cmd.Parameters.Add("Aufnahmezeitpunkt1", OleDbType.Date).Value = dt;
            }

            sb.Append(daPatientListeFilter.SelectCommand.CommandText);
            sb.Append(sbWhere.ToString());

            //Entlassene
            bShowEntlassen = (entlassungszeitpunktVon != new DateTime(1900, 01, 01) || entlassungszeitpunktBis != new DateTime(1900, 01, 01)) ? true : false;

            if (bShowEntlassen)
            {
                sb.Append(" union ");
                sb.Append(daPatientListeFilter.SelectCommand.CommandText);
                sbWhere = new StringBuilder();

                // normaler Filter
                if (patient != null && patient != "")
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("(Patient.Nachname + ' ' + Patient.Vorname) like ? ");
                    cmd.Parameters.Add("Name1", OleDbType.VarChar).Value = "%" + patient + "%";
                }

                // Klinik Filter
                if (bKlinik)
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Abteilung.IDKlinik = ? ");
                    cmd.Parameters.Add("Klinik1", OleDbType.Guid).Value = IDKlinik;
                }
                else
                {
                    string xy = "";
                }

                // Abteilungs [] Filter
                if (idAbteilung != null  )
                {
                    if (idAbteilung.Length > 0 && !(idAbteilung.Length == 1 && idAbteilung[0] == Guid.Empty))
                    {

                        sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                        StringBuilder sbAbt = new StringBuilder();
                        int x = 0;
                        foreach (Guid g in idAbteilung)
                        {
                            x++;
                            sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");
                            sbAbt.Append("Abteilung.ID = ? ");
                            cmd.Parameters.Add("Abteilung1" + x.ToString(), OleDbType.Guid).Value = g;
                        }
                        sbAbt.Append(") ");
                        sbWhere.Append(sbAbt.ToString());
                    }
                }


                // Bereichs Filter
                if (idBereich != Guid.Empty)
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Bereich.ID = ? ");
                    cmd.Parameters.Add("Bereich1", OleDbType.Guid).Value = idBereich;
                }

                if (entlassungszeitpunktVon != new DateTime(1900, 01, 01))
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Aufenthalt.Entlassungszeitpunkt >= ? ");
                    cmd.Parameters.Add("Entlassungszeitpunkt", OleDbType.Date).Value = entlassungszeitpunktVon.Date;
                }

                if (entlassungszeitpunktBis != new DateTime(1900, 01, 01))
                {
                    dt = new DateTime(entlassungszeitpunktBis.Year, entlassungszeitpunktBis.Month, entlassungszeitpunktBis.Day, 23, 59, 59);
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Aufenthalt.Entlassungszeitpunkt <= ? ");
                    cmd.Parameters.Add("Entlassungszeitpunkt1", OleDbType.Date).Value = dt;
                }

                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("Patient.ID not in (");
                sbWhere.Append(daIDPatientListeFilter.SelectCommand.CommandText);

                StringBuilder sb2 = new StringBuilder();
                // normaler Filter
                if (patient != null && patient != "")
                {
                    sb2.Append((sb2.Length == 0) ? " WHERE " : " AND ");
                    sb2.Append("(Patient.Nachname + ' ' + Patient.Vorname) like ? ");
                    cmd.Parameters.Add("Name2", OleDbType.VarChar).Value = "%" + patient + "%";
                }

                // Klinik Filter
                if (bKlinik)
                {
                    sb2.Append((sb2.Length == 0) ? " WHERE " : " AND ");
                    sb2.Append("Abteilung.IDKlinik = ? ");
                    cmd.Parameters.Add("Klinik2", OleDbType.Guid).Value = IDKlinik;
                }

                if (idAbteilung != null)
                {
                    // Abteilungs [] Filter
                    if (idAbteilung.Length > 0 && !(idAbteilung.Length == 1 && idAbteilung[0] == Guid.Empty))
                    {
                        sb2.Append((sb2.Length == 0) ? " WHERE " : " AND ");
                        StringBuilder sbAbt = new StringBuilder();
                        int x = 0;
                        foreach (Guid g in idAbteilung)
                        {
                            x++;
                            sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");
                            sbAbt.Append("Abteilung.ID = ?");
                            cmd.Parameters.Add("Abteilung2" + x.ToString(), OleDbType.Guid).Value = g;
                        }
                        sbAbt.Append(") ");
                        sb2.Append(sbAbt.ToString());
                    }
                }

                // Bereichs Filter
                if (idBereich != Guid.Empty)
                {
                    sb2.Append((sb2.Length == 0) ? " WHERE " : " AND ");
                    sb2.Append("Bereich.ID = ? ");
                    cmd.Parameters.Add("Bereich2", OleDbType.Guid).Value = idBereich;
                }

                sbWhere.Append(sb2.ToString());
                sbWhere.Append(" AND Aufenthalt.Entlassungszeitpunkt is null ");
                sbWhere.Append(" AND AufenthaltVerlauf.IDAufenthalt is not null ");
                sbWhere.Append(")");

                sb.Append(sbWhere.ToString());
            }

            sb.Append(" ORDER BY (Patient.Nachname + '  ' + Patient.Vorname)");
            cmd.CommandText = sb.ToString();

            dsPatientStation ds = new dsPatientStation();
            DataBase.Fill(da, ds.Patient);
            return ds.Patient;
        }
		//Änderung nach 17.10.2007 MDA:
        //Statt ByFilter =>GetPatienten
        //----------------------------------------------------------------------------
        /// <summary>
        /// Patienten mit Stationen
        /// </summary>
        //----------------------------------------------------------------------------
        //public dsPatientStation.PatientDataTable GetPatienten(string patient,
        //    bool bKlinik, Guid[] idAbteilung, Guid idBereich, DateTime aufnahmezeitpunktVon, DateTime aufnahmezeitpunktBis,
        //    DateTime entlassungszeitpunktVon, DateTime entlassungszeitpunktBis)
        //{
        //    bool bShowEntlassen = (entlassungszeitpunktVon != new DateTime(1900, 01, 01) || entlassungszeitpunktBis != new DateTime(1900, 01, 01)) ? true : false;
            
        //    OleDbCommand cmd = new OleDbCommand();
        //    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

        //    StringBuilder sbWhere = new StringBuilder();

        //    //Änderung nach 17.10.2007 MDA
        //    SetFilterCommandText(cmd, sbWhere, patient, bKlinik, idAbteilung, idBereich, bShowEntlassen, Guid.Empty);
            
        //    //Neu nach 30.10.2008 MDA
        //    //*************
        //    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
        //    sbWhere.Append("AufenthaltVerlauf.IDAufenthalt is not null");
        //    //*****************

        //    if (aufnahmezeitpunktVon != new DateTime(1900, 01, 01))
        //    {
        //        sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
        //        sbWhere.Append("Aufenthalt.Aufnahmezeitpunkt >= ?");
        //        cmd.Parameters.Add("Aufnahmezeitpunkt", OleDbType.Date).Value = aufnahmezeitpunktVon.Date;
        //    }

        //    DateTime dt;
        //    if (aufnahmezeitpunktBis != new DateTime(1900, 01, 01))
        //    {
        //        dt = new DateTime(aufnahmezeitpunktBis.Year, aufnahmezeitpunktBis.Month, aufnahmezeitpunktBis.Day, 23, 59, 59);
        //        sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
        //        sbWhere.Append("Aufenthalt.Aufnahmezeitpunkt <= ?");
        //        cmd.Parameters.Add("Aufnahmezeitpunkt1", OleDbType.Date).Value = dt;
        //    }

        //    if (bShowEntlassen)
        //    {
        //        if (entlassungszeitpunktVon != new DateTime(1900, 01, 01))
        //        {
        //            sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
        //            sbWhere.Append("Aufenthalt.Entlassungszeitpunkt >= ?");
        //            cmd.Parameters.Add("Entlassungszeitpunkt", OleDbType.Date).Value = entlassungszeitpunktVon.Date;
        //        }

        //        if (entlassungszeitpunktBis != new DateTime(1900, 01, 01))
        //        {
        //            dt = new DateTime(entlassungszeitpunktBis.Year, entlassungszeitpunktBis.Month, entlassungszeitpunktBis.Day, 23, 59, 59);
        //            sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
        //            sbWhere.Append("Aufenthalt.Entlassungszeitpunkt <= ?");
        //            cmd.Parameters.Add("Entlassungszeitpunkt1", OleDbType.Date).Value = dt;
        //        }
        //    }

        //    sbWhere.Append(" ORDER BY (Patient.Nachname + '  ' + Patient.Vorname)");
        //    cmd.CommandText = daPatientListeFilter.SelectCommand.CommandText + sbWhere.ToString();

        //    dsPatientStation ds = new dsPatientStation();
        //    DataBase.Fill(da, ds.Patient);
        //    return ds.Patient;
        //}
 
		//----------------------------------------------------------------------------
		/// <summary>
		/// Existiert der Patient bereits
		/// </summary> 
		//----------------------------------------------------------------------------
		public static bool IsUserDefined(string vorname, string nachname, DateTime gebDatum) 
		{
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT ID FROM Patient WHERE (Vorname like ?) and (Nachname like ?) and (Geburtsdatum = ?)";
                cmd.Parameters.Add("VORNAME", OleDbType.VarChar).Value = vorname;
                cmd.Parameters.Add("NACHNAME", OleDbType.VarChar).Value = nachname;
                cmd.Parameters.Add("GEBDATUM", OleDbType.DBTimeStamp).Value = gebDatum;
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("IsUserDefined: " + ex.ToString());
            }
		}

		public void WriteFibuDaten(Guid idPatient, string konto)
		{
			string sqlPattern = "update Patient set FIBUKonto='{0}' where ID='{1}'";
			string sql = String.Format (sqlPattern, konto, idPatient);
			OleDbCommand cmd = new OleDbCommand();
			cmd.CommandText = sql;
			DataBase.EcecuteNonQuery(cmd);
		}

        //Neu nach 19.06.2007 MDA:
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Ärzte eines Patienten
        /// </summary> 
        //----------------------------------------------------------------------------
        public dsAerzte.AerzteDataTable GetAllAerzte(DateTime datum)
        {
            dsAerzte1.Aerzte.Clear();
            daAerzteByPatient.SelectCommand.Parameters[0].Value = ID;
            daAerzteByPatient.SelectCommand.Parameters[1].Value = datum;
            daAerzteByPatient.SelectCommand.Parameters[2].Value = datum;

            DataBase.Fill(daAerzteByPatient, dsAerzte1.Aerzte);
            return dsAerzte1.Aerzte;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle nicht gerade aufgenommenen Klienten
        /// </summary> 
        //----------------------------------------------------------------------------
        public dsPatientNichtAufgenommen.PatientDataTable GetAlleNichtAufgenommenen()
        {
            dsPatientNichtAufgenommen.PatientDataTable dt = new dsPatientNichtAufgenommen.PatientDataTable();
            DataBase.Fill(daPatientNichtAufgenommen, dt);
            return dt;
        }
        
        //Neu nach 08.07.2008 MDA
        /// <summary>
        /// Klient nach nummer suchen
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public  dsPatientStation.PatientDataTable PatientByNumber(string number)
        {
            dsPatientStation ds = new dsPatientStation();
            daPatientByNr.SelectCommand.Parameters[0].Value = number;
            DataBase.Fill(daPatientByNr, ds.Patient);
            return ds.Patient;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert zum Klienten die aktuelle Pflegegeldstufe oder -1 wenn noch keine Pflegestufe defineirt ist
        /// </summary> 
        //----------------------------------------------------------------------------
        public static int AktuellePflegeStufe(Guid IDPatient)
        {
            int iRet = -1;
            if (_cmdPflegeStufe == null)
            {
                _cmdPflegeStufe = new OleDbCommand();
                _cmdPflegeStufe.CommandText = "SELECT TOP 1 Pflegegeldstufe.StufeNr FROM PatientPflegestufe INNER JOIN Pflegegeldstufe ON PatientPflegestufe.IDPflegegeldstufe = Pflegegeldstufe.ID WHERE PatientPflegestufe.IDPatient = ? and (CAST(FLOOR(CAST(PatientPflegestufe.GueltigAb AS FLOAT)) AS DATETIME) <= ?) ORDER BY PatientPflegestufe.GueltigAb DESC";
                _cmdPflegeStufe.Parameters.Add("IDPatient", OleDbType.Guid);
                _cmdPflegeStufe.Parameters.Add("GueltigAb", OleDbType.DBTimeStamp);
            }

            _cmdPflegeStufe.Parameters[0].Value = IDPatient;
            _cmdPflegeStufe.Parameters[1].Value = DateTime.Now.Date;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = _cmdPflegeStufe;
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            da.SelectCommand.Connection = RBU.DataBase.CONNECTION;
            DataTable dt = new DataTable();
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(dt);
            foreach (DataRow r in dt.Rows)
            {
                if (r[0] != System.DBNull.Value)
                    iRet = System.Convert.ToInt32(r[0]);
            }

            return iRet;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Sachwalter als String - Jede Zeile ist ein aktivver Sachwalter
        /// </summary> 
        //----------------------------------------------------------------------------
        public static string SachwalterIconText(Guid IDPatient)
        {
            try
            {
                string sRet = "";
                if (_cmdSachwalter == null)
                {
                    _cmdSachwalter = new OleDbCommand();
                    _cmdSachwalter.CommandText = "SELECT Vorname + ' ' + Nachname AS Name, SachwalterJN, Von, Belange FROM Sachwalter WHERE IDPAtient = ? and ( (Von <= ?) AND (Bis IS NULL) OR (Von <= ?) AND (Bis >= ?))";
                    _cmdSachwalter.Parameters.Add("IDPatient", OleDbType.Guid);
                    _cmdSachwalter.Parameters.Add("V1", OleDbType.DBTimeStamp);
                    _cmdSachwalter.Parameters.Add("V2", OleDbType.DBTimeStamp);
                    _cmdSachwalter.Parameters.Add("B1", OleDbType.DBTimeStamp);
                }

                _cmdSachwalter.Parameters[0].Value = IDPatient;
                _cmdSachwalter.Parameters[1].Value = DateTime.Now.Date;
                _cmdSachwalter.Parameters[2].Value = DateTime.Now.Date;
                _cmdSachwalter.Parameters[3].Value = DateTime.Now.Date;

                _cmdSachwalter.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = _cmdSachwalter;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                foreach (System.Data.DataRow r in dtSelect.Rows)
                {
                    if (r[0] != System.DBNull.Value)
                    {
                        if (sRet.Trim() != "")
                        {
                            sRet += "\r\n";
                        }

                        string sTxtAdd = "";
                        if (r["Von"] != System.DBNull.Value)
                        {
                            sTxtAdd += " (" + QS2.Desktop.ControlManagment.ControlManagment.getRes("Ab") + ": " + ((DateTime)r["Von"]).ToString("dd.MM.yyyy");
                        }
                        if (r["Belange"] != System.DBNull.Value)
                        {
                            sTxtAdd += (sTxtAdd.Trim() == "" ? " (" : ", ") + QS2.Desktop.ControlManagment.ControlManagment.getRes("Belange") + ": " + r["Belange"].ToString();
                        }
                        sTxtAdd += (sTxtAdd.Trim() == "" ? "" : ")");

                        if (r["SachwalterJN"] != System.DBNull.Value && (bool)r["SachwalterJN"] == true)
                        {
                            sRet += QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter") + ": " + r[0].ToString().Trim() + sTxtAdd;
                        }
                        else
                        {
                            sRet += QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgebevollmächtiger") + ": " + r[0].ToString().Trim() + sTxtAdd;
                        }
                    }
                }

                return sRet;

            }
            catch (Exception ex)
            {
                throw new Exception("SachwalterIconText: " + ex.ToString());
            }

        }

        public static PMDS.Global.retFkt freiheitsbeschränkungJN(Guid IDAufenthalt)
        {

            PMDS.Global.retFkt ret = new PMDS.Global.retFkt();

            OleDbDataAdapter da = new OleDbDataAdapter ();

            if (_cmdFreiheitsbeschränkung == null)
            {
                _cmdFreiheitsbeschränkung = new OleDbCommand();

                //_cmdFreiheitsbeschränkung.CommandText += " SELECT     TOP (100) PERCENT ID, IDAufenthalt, Grund, Beginn, Dauer, AngeordnetVon, AngeordnetAm, AufgehobenAm, " +
                //        " AufgehobenVon, TatsaechlicheEnde, Aktion, VoraussichtlicheDauer, Zeitraum, VoraussichtlichesEnde " +
                //        " FROM         dbo.Unterbringung  where IDAufenthalt = ? and not (AufgehobenAm is null) and AufgehobenAm = ? ";

                _cmdFreiheitsbeschränkung.CommandText += " SELECT     TOP (100) PERCENT ID, IDAufenthalt, Grund, Beginn, Dauer, AngeordnetVon, AngeordnetAm, AufgehobenAm, " +
                        " AufgehobenVon, TatsaechlicheEnde, Aktion, VoraussichtlicheDauer, Zeitraum, VoraussichtlichesEnde " +
                        " FROM dbo.Unterbringung  where IDAufenthalt = ? and (AufgehobenAm is null or AufgehobenAm > ?) and  Beginn <= ? ";

                _cmdFreiheitsbeschränkung.Parameters.Add("IDAufenthalt", OleDbType.Guid);
                _cmdFreiheitsbeschränkung.Parameters.Add("AufgehobenAm", OleDbType.DBTimeStamp);
                _cmdFreiheitsbeschränkung.Parameters.Add("Beginn", OleDbType.DBTimeStamp    );
            }

            _cmdFreiheitsbeschränkung.Parameters[0].Value = ENV.IDAUFENTHALT;
             _cmdFreiheitsbeschränkung.Parameters[1].Value = DateTime.Now;
            _cmdFreiheitsbeschränkung.Parameters[2].Value = DateTime.Now;

            DataTable dt = new DataTable ();
            da.SelectCommand = _cmdFreiheitsbeschränkung;
            //da.SelectCommand.Connection = DataBase.CONNECTION;
            //da.Fill(dt);
            DataBase.Fill(da, dt);
            
            int i = 0;

            foreach  (DataRow r in dt.Rows)
            {
                i += 1;
                string vorEnde = "";
               // System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox((r["VoraussichtlichesEnde"].GetType()).ToString() );
                if (r["VoraussichtlichesEnde"] != null & (r["VoraussichtlichesEnde"]).GetType() != typeof (System.DBNull) )//& ((DateTime)r["VoraussichtlichesEnde"]).Year != 1753)
                    
                    if(((DateTime)r["VoraussichtlichesEnde"]).Year != 1753)
                    {
                        vorEnde = QS2.Desktop.ControlManagment.ControlManagment.getRes(", Vorraussichtliches Ende: ") + ((DateTime)r["VoraussichtlichesEnde"]).ToString("dd.MM.yyyy");
                    }
                ret.txt1 += QS2.Desktop.ControlManagment.ControlManagment.getRes("Einschränkung ") + i.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" vom ") + ((DateTime)r["Beginn"]).ToString("dd.MM.yyyy") + vorEnde + "\n";
            }
            if (ret.txt1 != "")
            {
                ret.title   = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es bestehen offene Freiheitsbeschränkungen für den Patienten! (Anzahl: ") + dt.Rows.Count.ToString() + ")";    
            }
            return ret;
        }

        public dsPatientStation.PatientDataTable GetKlientenByAbteilungen(string patient,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, bool bShowEntlassen, System.Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            StringBuilder sbWhere = new StringBuilder();

            //Änderung nach 17.10.2007 MDA
            SetFilterCommandText(cmd, sbWhere, patient, bKlinik, idAbteilung, idBereich, Guid.Empty, false, IDKlinik);

            StringBuilder sb = new StringBuilder();
            sb.Append(daPatientListeFilter.SelectCommand.CommandText);
            sb.Append(sbWhere.ToString());

            if (bShowEntlassen)
            {
                sb.Append(" union select dbo.Patient.ID, dbo.Patient.Nachname + '  ' + dbo.Patient.Vorname AS Name, dbo.Patient.Geburtsdatum,");
                sb.Append(" '' AS Abteilung, '' AS Bereich, '' AS UrlaubText from Patient WHERE (NOT (ID IN (SELECT IDPatient FROM Aufenthalt");
                sb.Append(" WHERE (Entlassungszeitpunkt IS NULL))))");
            }

            sb.Append(" ORDER BY (Patient.Nachname + '  ' + Patient.Vorname)");

            cmd.CommandText = sb.ToString();

            dsPatientStation ds = new dsPatientStation();
            DataBase.Fill(da, ds.Patient);
            return ds.Patient;
        }

        private void SetFilterCommandTextWithJoin(OleDbCommand cmd, StringBuilder sbWhere, string patient,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, bool bShowEntlassen, Guid idBezugsPerson, System.Guid IDKlinik,
            string sFieldJoin = " IDAbteilung ")
        {
            SetFilterCommandText(cmd, sbWhere, patient, bKlinik, idAbteilung, idBereich, idBezugsPerson, bShowEntlassen, IDKlinik, sFieldJoin);

            if (!bShowEntlassen)
            {
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("Aufenthalt.Entlassungszeitpunkt is null");
            }
            else
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append(" Entlassungszeitpunkt is not null");
                }
        }

        private void SetFilterCommandText(OleDbCommand cmd, StringBuilder sbWhere, string patient,
            bool bKlinik, Guid[] idAbteilung, Guid idBereich, Guid idBezugsPerson, bool bShowEntlassen, System.Guid IDKlinik,
            string sFieldJoin = " IDAbteilung ")
        {
            if (patient != null && patient != "")
            {
                if (bShowEntlassen)
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Name like ? ");
                    cmd.Parameters.Add("Name", OleDbType.VarChar).Value = "%" + patient + "%";
                }
                else
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("(Patient.Nachname + ' ' + Patient.Vorname) like ? ");
                    cmd.Parameters.Add("Name", OleDbType.VarChar).Value = "%" + patient + "%";
                }
            }

            if (bKlinik)
            {
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("Abteilung.IDKlinik = ?");
                cmd.Parameters.Add("Klinik", OleDbType.Guid).Value = IDKlinik;
            }

            if (idAbteilung != null)
            {
                if (!bShowEntlassen)
                {
                    //if (idAbteilung.Length > 0)
                    //{
                    //    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    //    StringBuilder sbAbt = new StringBuilder();
                    //    int x = 0;
                    //    foreach (Guid g in idAbteilung)
                    //    {
                    //        x++;
                    //        sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");

                    //        if (bShowEntlassen) sbAbt.Append("IDAbteilung = ?");
                    //        else sbAbt.Append("Abteilung.ID = ?");
                    //        cmd.Parameters.Add("Abteilung" + x.ToString(), OleDbType.Guid).Value = g;
                    //    }
                    //    sbAbt.Append(")");
                    //    sbWhere.Append(sbAbt.ToString());
                    //}

                    //if (idAbteilung.Length > 0 && !(idAbteilung.Length == 1 && idAbteilung[0] == Guid.Empty))
                    //{
                    //    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    //    StringBuilder sbAbt = new StringBuilder();
                    //    int x = 0;
                    //    foreach (Guid g in idAbteilung)
                    //    {
                    //        x++;
                    //        sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");

                    //        if (bShowEntlassen) sbAbt.Append("IDAbteilung = ?");
                    //        else sbAbt.Append("Abteilung.ID = ?");
                    //        cmd.Parameters.Add("Abteilung" + x.ToString(), OleDbType.Guid).Value = g;
                    //    }
                    //    sbAbt.Append(")");
                    //    sbWhere.Append(sbAbt.ToString());
                    //}
                    //else if ((idAbteilung.Length == 1 && idAbteilung[0] == Guid.Empty))
                    //{
                    //    string txt = " not Aufenthalt.ID is Null ";
                    //    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " + txt : " AND " + txt);

                    //    if (!bShowEntlassen)
                    //    {
                    //        string txt2 = " (not Aufenthalt.IDAbteilung is Null and Aufenthalt.IDAbteilung <> '" + System.Guid.Empty.ToString() + "') ";
                    //        sbWhere.Append((sbWhere.Length == 0) ? " WHERE " + txt : " AND " + txt2);
                    //    }
                    //}
                }
                else
                {
                    //if (idAbteilung.Length > 0)
                    //{
                    //    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    //    StringBuilder sbAbt = new StringBuilder();
                    //    int x = 0;
                    //    foreach (Guid g in idAbteilung)
                    //    {
                    //        x++;
                    //        sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");

                    //        if (bShowEntlassen) sbAbt.Append("IDAbteilung = ?");
                    //        else sbAbt.Append("Abteilung.ID = ?");
                    //        cmd.Parameters.Add("Abteilung" + x.ToString(), OleDbType.Guid).Value = g;
                    //    }
                    //    sbAbt.Append(")");
                    //    sbWhere.Append(sbAbt.ToString());
                    //}
                }

                //string sWhereKlinik = " IDPatient IN ( SELECT pat10.ID AS IDPatientKlinik " +
                //                        " FROM dbo.Abteilung AS abt10 INNER JOIN " +
                //                        " dbo.Klinik AS klinik10 ON abt10.IDKlinik = klinik10.ID INNER JOIN" +
                //                        " dbo.Patient AS pat10 ON abt10.ID = pat10.IDAbteilung where klinik10.ID = '" + IDKlinik.ToString()  +  "' ) ";

                int anzAbtInSql = 0;
                if (idAbteilung.Length > 0 && !(idAbteilung.Length == 1 && idAbteilung[0] == Guid.Empty))
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    StringBuilder sbAbt = new StringBuilder();
                    int x = 0;
                    foreach (Guid g in idAbteilung)
                    {
                        x++;
                        sbAbt.Append((sbAbt.Length == 0) ? "(" : " or ");

                        if (bShowEntlassen) sbAbt.Append("IDAbteilung = '" + g.ToString() + "'");
                        else sbAbt.Append("Abteilung.ID = '" + g.ToString() + "'");
                        //cmd.Parameters.Add("Abteilung" + x.ToString(), OleDbType.Guid).Value = g;
                        anzAbtInSql += 1;
                    }
                    sbAbt.Append(")");
                    sbWhere.Append(sbAbt.ToString());
                }
                 
                string sFieldJoinIDklinik = "";
                if (!bShowEntlassen)
                {
                    sFieldJoin = " Abteilung.ID ";
                    sFieldJoinIDklinik = " Aufenthalt ";
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append(sFieldJoinIDklinik + ".IDKlinik = '" + IDKlinik.ToString() + "' ");
                }
                else
                {
                    if (anzAbtInSql == 0)
                    {
                        //sFieldJoin = " Aufenthalt.IDAbteilung ";
                        string xy = "";
                    }
                    else
                    {
                        sFieldJoin = " IDAbteilung ";
                    }
                }

                string sWhereKlinik = " " + sFieldJoin + " IN (SELECT abt10.ID " + 
                                    " FROM dbo.Abteilung AS abt10 INNER JOIN " + 
                                    " dbo.Klinik AS klinik10 ON abt10.IDKlinik = klinik10.ID " +
                                    " where abt10.IDKlinik = '" + IDKlinik.ToString() + "' ) ";
                
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append(sWhereKlinik.ToString());
            }

            if (idBereich != Guid.Empty)
            {
                if (bShowEntlassen)
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("IDBereich = ?");
                    cmd.Parameters.Add("Bereich", OleDbType.Guid).Value = idBereich;
                }
                else
                {
                    sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                    sbWhere.Append("Bereich.ID = ?");
                    cmd.Parameters.Add("Bereich", OleDbType.Guid).Value = idBereich;
                }
            }

            if (idBezugsPerson != Guid.Empty)
            {
                sbWhere.Append((sbWhere.Length == 0) ? " WHERE " : " AND ");
                sbWhere.Append("BenutzerBezug.IDBenutzer = ?");
                cmd.Parameters.Add("IDBezugspfleger", OleDbType.Guid).Value = idBezugsPerson;
            }
        }


        public PMDS.Data.Patient.dsPatientZusaätzlicheDatenByID.PatientRow getPatDatenZusätzlich(System.Guid IDPatient)
        {
            PMDS.Data.Patient.dsPatientZusaätzlicheDatenByID ds = new PMDS.Data.Patient.dsPatientZusaätzlicheDatenByID();
            daPatientZusaätzlicheDatenByID.SelectCommand.Parameters[0].Value = IDPatient;
            DataBase.Fill(daPatientZusaätzlicheDatenByID, ds.Patient);
            return (PMDS.Data.Patient.dsPatientZusaätzlicheDatenByID.PatientRow)ds.Patient.Rows[0];
        }

	}
}
