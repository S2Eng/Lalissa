namespace PMDS.DB
{
    partial class DBQM
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
            System.Data.OleDb.OleDbConnection oleDbConnection1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBQM));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegePlanByAufenthalt_Gruppe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzwerteForEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzWert = new System.Data.OleDb.OleDbDataAdapter();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=sty041;Integrated Security=SSPI;Initial Catalog=PM" +
    "DS_DemoGross";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.Char, 1, "EintragGruppe")});
            // 
            // daPflegePlanByAufenthalt_Gruppe
            // 
            this.daPflegePlanByAufenthalt_Gruppe.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegePlanByAufenthalt_Gruppe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"),
                        new System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daZusatzwerteForEintrag
            // 
            this.daZusatzwerteForEintrag.SelectCommand = this.oleDbSelectCommand2;
            this.daZusatzwerteForEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("MinValue", "MinValue"),
                        new System.Data.Common.DataColumnMapping("MaxValue", "MaxValue"),
                        new System.Data.Common.DataColumnMapping("FeldNr", "FeldNr"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("DruckenJN", "DruckenJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppeEintrag", "IDZusatzGruppeEintrag"),
                        new System.Data.Common.DataColumnMapping("AktivJN", "AktivJN")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT     ID, IDZusatzGruppeEintrag, IDObjekt, Wert, ZahlenWert, RawFormat, Zahl" +
    "enWertFloat\r\nFROM         ZusatzWert\r\nWHERE     (ID = ?)";
            this.oleDbSelectCommand3.Connection = oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [ZusatzWert] ([ID], [IDZusatzGruppeEintrag], [IDObjekt], [Wert], [Zah" +
    "lenWert], [RawFormat], [ZahlenWertFloat]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDZusatzGruppeEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wert"),
            new System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.Integer, 0, "ZahlenWert"),
            new System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.LongVarBinary, 0, "RawFormat"),
            new System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.Double, 0, "ZahlenWertFloat")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [ZusatzWert] SET [ID] = ?, [IDZusatzGruppeEintrag] = ?, [IDObjekt] = ?, [W" +
    "ert] = ?, [ZahlenWert] = ?, [RawFormat] = ?, [ZahlenWertFloat] = ? WHERE (([ID] " +
    "= ?))";
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDZusatzGruppeEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("Wert", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wert"),
            new System.Data.OleDb.OleDbParameter("ZahlenWert", System.Data.OleDb.OleDbType.Integer, 0, "ZahlenWert"),
            new System.Data.OleDb.OleDbParameter("RawFormat", System.Data.OleDb.OleDbType.LongVarBinary, 0, "RawFormat"),
            new System.Data.OleDb.OleDbParameter("ZahlenWertFloat", System.Data.OleDb.OleDbType.Double, 0, "ZahlenWertFloat"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [ZusatzWert] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daZusatzWert
            // 
            this.daZusatzWert.DeleteCommand = this.oleDbDeleteCommand1;
            this.daZusatzWert.InsertCommand = this.oleDbInsertCommand1;
            this.daZusatzWert.SelectCommand = this.oleDbSelectCommand3;
            this.daZusatzWert.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzWert", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppeEintrag", "IDZusatzGruppeEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"),
                        new System.Data.Common.DataColumnMapping("RawFormat", "RawFormat"),
                        new System.Data.Common.DataColumnMapping("ZahlenWertFloat", "ZahlenWertFloat")})});
            this.daZusatzWert.UpdateCommand = this.oleDbUpdateCommand1;

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPflegePlanByAufenthalt_Gruppe;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbDataAdapter daZusatzwerteForEintrag;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daZusatzWert;
    }
}
