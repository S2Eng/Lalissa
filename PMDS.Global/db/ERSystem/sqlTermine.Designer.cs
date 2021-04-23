namespace PMDS.Global.db.ERSystem
{
    partial class sqlTermine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlTermine));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.davInterventionen = new System.Data.OleDb.OleDbDataAdapter();
            this.davÜbergabe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.dbConn;
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=sty041;Integrated Security=SSPI;Initial Catalog=PM" +
    "DS_DemoGross";
            // 
            // davInterventionen
            // 
            this.davInterventionen.SelectCommand = this.oleDbSelectCommand1;
            this.davInterventionen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vInterventionen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Auswahl", "Auswahl"),
                        new System.Data.Common.DataColumnMapping("von", "von"),
                        new System.Data.Common.DataColumnMapping("bis", "bis"),
                        new System.Data.Common.DataColumnMapping("Klient", "Klient"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Maßnahme", "Maßnahme"),
                        new System.Data.Common.DataColumnMapping("Anmerkung und Hinweis", "Anmerkung und Hinweis"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("Klinik", "Klinik"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("Benutzer (erstellt)", "Benutzer (erstellt)"),
                        new System.Data.Common.DataColumnMapping("Benutzer (geändert)", "Benutzer (geändert)"),
                        new System.Data.Common.DataColumnMapping("Berufsstand Soll", "Berufsstand Soll"),
                        new System.Data.Common.DataColumnMapping("Eintragstyp", "Eintragstyp"),
                        new System.Data.Common.DataColumnMapping("UrlaubJN", "UrlaubJN"),
                        new System.Data.Common.DataColumnMapping("EntlassenJN", "EntlassenJN"),
                        new System.Data.Common.DataColumnMapping("IDBezug", "IDBezug"),
                        new System.Data.Common.DataColumnMapping("AbgesetztJN", "AbgesetztJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GelöschtJN", "GelöschtJN"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("MitPflegediagnoseAbzeichnenJN", "MitPflegediagnoseAbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("TerminJN", "TerminJN"),
                        new System.Data.Common.DataColumnMapping("Startdatum", "Startdatum"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplan", "IDPflegeplan"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstBDxBezeichnung", "lstBDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRTF", "AnmerkungRTF"),
                        new System.Data.Common.DataColumnMapping("OhneZeitbezugJN", "OhneZeitbezugJN"),
                        new System.Data.Common.DataColumnMapping("ÜberfälligJN", "ÜberfälligJN"),
                        new System.Data.Common.DataColumnMapping("vonDatum", "vonDatum"),
                        new System.Data.Common.DataColumnMapping("bisDatum", "bisDatum"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("EvaluierungUeberfällig", "EvaluierungUeberfällig")})});
            // 
            // davÜbergabe
            // 
            this.davÜbergabe.SelectCommand = this.oleDbCommand1;
            this.davÜbergabe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "vÜbergabe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Auswahl", "Auswahl"),
                        new System.Data.Common.DataColumnMapping("Klient", "Klient"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Durchgeführt", "Durchgeführt"),
                        new System.Data.Common.DataColumnMapping("Maßnahme", "Maßnahme"),
                        new System.Data.Common.DataColumnMapping("Dekurs", "Dekurs"),
                        new System.Data.Common.DataColumnMapping("DekursRtf", "DekursRtf"),
                        new System.Data.Common.DataColumnMapping("DekursHerkunft", "DekursHerkunft"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("Zusatzwerte", "Zusatzwerte"),
                        new System.Data.Common.DataColumnMapping("lstIDZusatzwerte", "lstIDZusatzwerte"),
                        new System.Data.Common.DataColumnMapping("Klinik", "Klinik"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("DatumAbgezeichnet", "DatumAbgezeichnet"),
                        new System.Data.Common.DataColumnMapping("BenutzerAbgezeichnet", "BenutzerAbgezeichnet"),
                        new System.Data.Common.DataColumnMapping("Berufsstand Ist", "Berufsstand Ist"),
                        new System.Data.Common.DataColumnMapping("Berufsstand Soll", "Berufsstand Soll"),
                        new System.Data.Common.DataColumnMapping("Wichtig für", "Wichtig für"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDBezug", "IDBezug"),
                        new System.Data.Common.DataColumnMapping("Eintragstyp", "Eintragstyp"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktDatum", "ZeitpunktDatum"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegeEintrag", "IDPflegeEintrag"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDWichtigFür", "IDWichtigFür"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerAbgezeichnet", "IDBenutzerAbgezeichnet"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplan", "IDPflegeplan"),
                        new System.Data.Common.DataColumnMapping("GehörtZuGruppe", "GehörtZuGruppe"),
                        new System.Data.Common.DataColumnMapping("BerufsstandHierarchie", "BerufsstandHierarchie"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("lstZusatzIDs", "lstZusatzIDs"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.dbConn;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection dbConn;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        public System.Data.OleDb.OleDbDataAdapter davInterventionen;
        public System.Data.OleDb.OleDbDataAdapter davÜbergabe;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
    }
}
