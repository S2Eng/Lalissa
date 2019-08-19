namespace PMDS.Global.db.ERSystem
{
    partial class sqlPlanungIntervention
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlPlanungIntervention));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlConn = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daPflegeplan = new System.Data.SqlClient.SqlDataAdapter();
            this.daPflegeEintrag = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.sqlConn;
            // 
            // sqlConn
            // 
            this.sqlConn.ConnectionString = "Data Source=STYSRV02V\\SQL2008R2;Initial Catalog=PMDSDev;Integrated Security=True";
            this.sqlConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.sqlConn;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDEintrag", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEintrag"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Erstellt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Erstellt"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Geaendert", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Geaendert"),
            new System.Data.SqlClient.SqlParameter("@OriginalJN", System.Data.SqlDbType.Bit, 0, "OriginalJN"),
            new System.Data.SqlClient.SqlParameter("@DatumErstellt", System.Data.SqlDbType.DateTime, 0, "DatumErstellt"),
            new System.Data.SqlClient.SqlParameter("@DatumGeaendert", System.Data.SqlDbType.DateTime, 0, "DatumGeaendert"),
            new System.Data.SqlClient.SqlParameter("@StartDatum", System.Data.SqlDbType.DateTime, 0, "StartDatum"),
            new System.Data.SqlClient.SqlParameter("@EndeDatum", System.Data.SqlDbType.DateTime, 0, "EndeDatum"),
            new System.Data.SqlClient.SqlParameter("@LetztesDatum", System.Data.SqlDbType.DateTime, 0, "LetztesDatum"),
            new System.Data.SqlClient.SqlParameter("@LetzteEvaluierung", System.Data.SqlDbType.DateTime, 0, "LetzteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@Warnhinweis", System.Data.SqlDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.SqlClient.SqlParameter("@Anmerkung", System.Data.SqlDbType.VarChar, 0, "Anmerkung"),
            new System.Data.SqlClient.SqlParameter("@ErledigtGrund", System.Data.SqlDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 0, "Text"),
            new System.Data.SqlClient.SqlParameter("@Intervall", System.Data.SqlDbType.Int, 0, "Intervall"),
            new System.Data.SqlClient.SqlParameter("@WochenTage", System.Data.SqlDbType.Int, 0, "WochenTage"),
            new System.Data.SqlClient.SqlParameter("@IntervallTyp", System.Data.SqlDbType.Int, 0, "IntervallTyp"),
            new System.Data.SqlClient.SqlParameter("@EvalTage", System.Data.SqlDbType.Int, 0, "EvalTage"),
            new System.Data.SqlClient.SqlParameter("@IDBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@ParalellJN", System.Data.SqlDbType.Bit, 0, "ParalellJN"),
            new System.Data.SqlClient.SqlParameter("@Dauer", System.Data.SqlDbType.Int, 0, "Dauer"),
            new System.Data.SqlClient.SqlParameter("@LokalisierungJN", System.Data.SqlDbType.Bit, 0, "LokalisierungJN"),
            new System.Data.SqlClient.SqlParameter("@EinmaligJN", System.Data.SqlDbType.Bit, 0, "EinmaligJN"),
            new System.Data.SqlClient.SqlParameter("@ErledigtJN", System.Data.SqlDbType.Bit, 0, "ErledigtJN"),
            new System.Data.SqlClient.SqlParameter("@GeloeschtJN", System.Data.SqlDbType.Bit, 0, "GeloeschtJN"),
            new System.Data.SqlClient.SqlParameter("@Lokalisierung", System.Data.SqlDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.SqlClient.SqlParameter("@LokalisierungSeite", System.Data.SqlDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.SqlClient.SqlParameter("@EintragGruppe", System.Data.SqlDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.SqlClient.SqlParameter("@PDXJN", System.Data.SqlDbType.Bit, 0, "PDXJN"),
            new System.Data.SqlClient.SqlParameter("@RMOptionalJN", System.Data.SqlDbType.Bit, 0, "RMOptionalJN"),
            new System.Data.SqlClient.SqlParameter("@UntertaegigeJN", System.Data.SqlDbType.Bit, 0, "UntertaegigeJN"),
            new System.Data.SqlClient.SqlParameter("@SpenderAbgabeJN", System.Data.SqlDbType.Bit, 0, "SpenderAbgabeJN"),
            new System.Data.SqlClient.SqlParameter("@IDUntertaegigeGruppe", System.Data.SqlDbType.UniqueIdentifier, 0, "IDUntertaegigeGruppe"),
            new System.Data.SqlClient.SqlParameter("@IDLinkDokument", System.Data.SqlDbType.UniqueIdentifier, 0, "IDLinkDokument"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierung", System.Data.SqlDbType.DateTime, 0, "NaechsteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierungBemerkung", System.Data.SqlDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.SqlClient.SqlParameter("@OhneZeitBezug", System.Data.SqlDbType.Bit, 0, "OhneZeitBezug"),
            new System.Data.SqlClient.SqlParameter("@IDZeitbereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDZeitbereich"),
            new System.Data.SqlClient.SqlParameter("@ZuErledigenBis", System.Data.SqlDbType.DateTime, 0, "ZuErledigenBis"),
            new System.Data.SqlClient.SqlParameter("@wundejn", System.Data.SqlDbType.Bit, 0, "wundejn"),
            new System.Data.SqlClient.SqlParameter("@EintragFlag", System.Data.SqlDbType.Int, 0, "EintragFlag"),
            new System.Data.SqlClient.SqlParameter("@NächstesDatum", System.Data.SqlDbType.DateTime, 0, "NächstesDatum"),
            new System.Data.SqlClient.SqlParameter("@IDDekurs", System.Data.SqlDbType.UniqueIdentifier, 0, "IDDekurs"),
            new System.Data.SqlClient.SqlParameter("@PrivatJN", System.Data.SqlDbType.Bit, 0, "PrivatJN"),
            new System.Data.SqlClient.SqlParameter("@IDExtern", System.Data.SqlDbType.UniqueIdentifier, 0, "IDExtern"),
            new System.Data.SqlClient.SqlParameter("@Startdatum_Neu", System.Data.SqlDbType.DateTime, 0, "Startdatum_Neu"),
            new System.Data.SqlClient.SqlParameter("@lstIDPDx", System.Data.SqlDbType.NVarChar, 0, "lstIDPDx"),
            new System.Data.SqlClient.SqlParameter("@lstPDxBezeichnung", System.Data.SqlDbType.NVarChar, 0, "lstPDxBezeichnung"),
            new System.Data.SqlClient.SqlParameter("@AnmerkungRtf", System.Data.SqlDbType.NVarChar, 0, "AnmerkungRtf"),
            new System.Data.SqlClient.SqlParameter("@IDBefund", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBefund"),
            new System.Data.SqlClient.SqlParameter("@Verordnungen", System.Data.SqlDbType.NVarChar, 0, "Verordnungen")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.sqlConn;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDEintrag", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEintrag"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Erstellt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Erstellt"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer_Geaendert", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer_Geaendert"),
            new System.Data.SqlClient.SqlParameter("@OriginalJN", System.Data.SqlDbType.Bit, 0, "OriginalJN"),
            new System.Data.SqlClient.SqlParameter("@DatumErstellt", System.Data.SqlDbType.DateTime, 0, "DatumErstellt"),
            new System.Data.SqlClient.SqlParameter("@DatumGeaendert", System.Data.SqlDbType.DateTime, 0, "DatumGeaendert"),
            new System.Data.SqlClient.SqlParameter("@StartDatum", System.Data.SqlDbType.DateTime, 0, "StartDatum"),
            new System.Data.SqlClient.SqlParameter("@EndeDatum", System.Data.SqlDbType.DateTime, 0, "EndeDatum"),
            new System.Data.SqlClient.SqlParameter("@LetztesDatum", System.Data.SqlDbType.DateTime, 0, "LetztesDatum"),
            new System.Data.SqlClient.SqlParameter("@LetzteEvaluierung", System.Data.SqlDbType.DateTime, 0, "LetzteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@Warnhinweis", System.Data.SqlDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.SqlClient.SqlParameter("@Anmerkung", System.Data.SqlDbType.VarChar, 0, "Anmerkung"),
            new System.Data.SqlClient.SqlParameter("@ErledigtGrund", System.Data.SqlDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.VarChar, 0, "Text"),
            new System.Data.SqlClient.SqlParameter("@Intervall", System.Data.SqlDbType.Int, 0, "Intervall"),
            new System.Data.SqlClient.SqlParameter("@WochenTage", System.Data.SqlDbType.Int, 0, "WochenTage"),
            new System.Data.SqlClient.SqlParameter("@IntervallTyp", System.Data.SqlDbType.Int, 0, "IntervallTyp"),
            new System.Data.SqlClient.SqlParameter("@EvalTage", System.Data.SqlDbType.Int, 0, "EvalTage"),
            new System.Data.SqlClient.SqlParameter("@IDBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@ParalellJN", System.Data.SqlDbType.Bit, 0, "ParalellJN"),
            new System.Data.SqlClient.SqlParameter("@Dauer", System.Data.SqlDbType.Int, 0, "Dauer"),
            new System.Data.SqlClient.SqlParameter("@LokalisierungJN", System.Data.SqlDbType.Bit, 0, "LokalisierungJN"),
            new System.Data.SqlClient.SqlParameter("@EinmaligJN", System.Data.SqlDbType.Bit, 0, "EinmaligJN"),
            new System.Data.SqlClient.SqlParameter("@ErledigtJN", System.Data.SqlDbType.Bit, 0, "ErledigtJN"),
            new System.Data.SqlClient.SqlParameter("@GeloeschtJN", System.Data.SqlDbType.Bit, 0, "GeloeschtJN"),
            new System.Data.SqlClient.SqlParameter("@Lokalisierung", System.Data.SqlDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.SqlClient.SqlParameter("@LokalisierungSeite", System.Data.SqlDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.SqlClient.SqlParameter("@EintragGruppe", System.Data.SqlDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.SqlClient.SqlParameter("@PDXJN", System.Data.SqlDbType.Bit, 0, "PDXJN"),
            new System.Data.SqlClient.SqlParameter("@RMOptionalJN", System.Data.SqlDbType.Bit, 0, "RMOptionalJN"),
            new System.Data.SqlClient.SqlParameter("@UntertaegigeJN", System.Data.SqlDbType.Bit, 0, "UntertaegigeJN"),
            new System.Data.SqlClient.SqlParameter("@SpenderAbgabeJN", System.Data.SqlDbType.Bit, 0, "SpenderAbgabeJN"),
            new System.Data.SqlClient.SqlParameter("@IDUntertaegigeGruppe", System.Data.SqlDbType.UniqueIdentifier, 0, "IDUntertaegigeGruppe"),
            new System.Data.SqlClient.SqlParameter("@IDLinkDokument", System.Data.SqlDbType.UniqueIdentifier, 0, "IDLinkDokument"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierung", System.Data.SqlDbType.DateTime, 0, "NaechsteEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@NaechsteEvaluierungBemerkung", System.Data.SqlDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.SqlClient.SqlParameter("@OhneZeitBezug", System.Data.SqlDbType.Bit, 0, "OhneZeitBezug"),
            new System.Data.SqlClient.SqlParameter("@IDZeitbereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDZeitbereich"),
            new System.Data.SqlClient.SqlParameter("@ZuErledigenBis", System.Data.SqlDbType.DateTime, 0, "ZuErledigenBis"),
            new System.Data.SqlClient.SqlParameter("@wundejn", System.Data.SqlDbType.Bit, 0, "wundejn"),
            new System.Data.SqlClient.SqlParameter("@EintragFlag", System.Data.SqlDbType.Int, 0, "EintragFlag"),
            new System.Data.SqlClient.SqlParameter("@NächstesDatum", System.Data.SqlDbType.DateTime, 0, "NächstesDatum"),
            new System.Data.SqlClient.SqlParameter("@IDDekurs", System.Data.SqlDbType.UniqueIdentifier, 0, "IDDekurs"),
            new System.Data.SqlClient.SqlParameter("@PrivatJN", System.Data.SqlDbType.Bit, 0, "PrivatJN"),
            new System.Data.SqlClient.SqlParameter("@IDExtern", System.Data.SqlDbType.UniqueIdentifier, 0, "IDExtern"),
            new System.Data.SqlClient.SqlParameter("@Startdatum_Neu", System.Data.SqlDbType.DateTime, 0, "Startdatum_Neu"),
            new System.Data.SqlClient.SqlParameter("@lstIDPDx", System.Data.SqlDbType.NVarChar, 0, "lstIDPDx"),
            new System.Data.SqlClient.SqlParameter("@lstPDxBezeichnung", System.Data.SqlDbType.NVarChar, 0, "lstPDxBezeichnung"),
            new System.Data.SqlClient.SqlParameter("@AnmerkungRtf", System.Data.SqlDbType.NVarChar, 0, "AnmerkungRtf"),
            new System.Data.SqlClient.SqlParameter("@IDBefund", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBefund"),
            new System.Data.SqlClient.SqlParameter("@Verordnungen", System.Data.SqlDbType.NVarChar, 0, "Verordnungen"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = "DELETE FROM [PflegePlan] WHERE (([ID] = @Original_ID) AND ([IDAufenthalt] = @Orig" +
    "inal_IDAufenthalt))";
            this.sqlDeleteCommand1.Connection = this.sqlConn;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegeplan
            // 
            this.daPflegeplan.DeleteCommand = this.sqlDeleteCommand1;
            this.daPflegeplan.InsertCommand = this.sqlInsertCommand1;
            this.daPflegeplan.SelectCommand = this.sqlSelectCommand1;
            this.daPflegeplan.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("Verordnungen", "Verordnungen")})});
            this.daPflegeplan.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // daPflegeEintrag
            // 
            this.daPflegeEintrag.DeleteCommand = this.sqlCommand1;
            this.daPflegeEintrag.InsertCommand = this.sqlCommand2;
            this.daPflegeEintrag.SelectCommand = this.sqlCommand3;
            this.daPflegeEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IstDauer", "IstDauer"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Wichtig", "Wichtig"),
                        new System.Data.Common.DataColumnMapping("IDWichtig", "IDWichtig"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("EvalStatus", "EvalStatus"),
                        new System.Data.Common.DataColumnMapping("PflegeplanText", "PflegeplanText"),
                        new System.Data.Common.DataColumnMapping("IDSollberufsstand", "IDSollberufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlanBerufsstand", "IDPflegePlanBerufsstand"),
                        new System.Data.Common.DataColumnMapping("IDPflegeplanH", "IDPflegeplanH"),
                        new System.Data.Common.DataColumnMapping("Solldauer", "Solldauer"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("PflegePlanDauer", "PflegePlanDauer"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("CC", "CC"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("Startdatum_Neu", "Startdatum_Neu"),
                        new System.Data.Common.DataColumnMapping("TextRtf", "TextRtf"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetJN", "AbgezeichnetJN"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetIDBenutzer", "AbgezeichnetIDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgezeichnetAm", "AbgezeichnetAm"),
                        new System.Data.Common.DataColumnMapping("Dekursherkunft", "Dekursherkunft"),
                        new System.Data.Common.DataColumnMapping("AbzeichnenJN", "AbzeichnenJN"),
                        new System.Data.Common.DataColumnMapping("HAGPflichtigJN", "HAGPflichtigJN"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("LogInNameFrei", "LogInNameFrei")})});
            this.daPflegeEintrag.UpdateCommand = this.sqlCommand4;
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = "DELETE FROM [PflegeEintrag] WHERE (([ID] = @Original_ID) AND ([IDAufenthalt] = @O" +
    "riginal_IDAufenthalt))";
            this.sqlCommand1.Connection = this.sqlConn;
            this.sqlCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = resources.GetString("sqlCommand2.CommandText");
            this.sqlCommand2.Connection = this.sqlConn;
            this.sqlCommand2.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, "ID"),
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDPflegePlan", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegePlan"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@IDEintrag", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEintrag"),
            new System.Data.SqlClient.SqlParameter("@IDBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@DatumErstellt", System.Data.SqlDbType.DateTime, 0, "DatumErstellt"),
            new System.Data.SqlClient.SqlParameter("@Zeitpunkt", System.Data.SqlDbType.DateTime, 0, "Zeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.NVarChar, 0, "Text"),
            new System.Data.SqlClient.SqlParameter("@IstDauer", System.Data.SqlDbType.Int, 0, "IstDauer"),
            new System.Data.SqlClient.SqlParameter("@DurchgefuehrtJN", System.Data.SqlDbType.Bit, 0, "DurchgefuehrtJN"),
            new System.Data.SqlClient.SqlParameter("@EintragsTyp", System.Data.SqlDbType.Int, 0, "EintragsTyp"),
            new System.Data.SqlClient.SqlParameter("@Wichtig", System.Data.SqlDbType.Int, 0, "Wichtig"),
            new System.Data.SqlClient.SqlParameter("@IDWichtig", System.Data.SqlDbType.UniqueIdentifier, 0, "IDWichtig"),
            new System.Data.SqlClient.SqlParameter("@IDEvaluierung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@EvalStatus", System.Data.SqlDbType.Int, 0, "EvalStatus"),
            new System.Data.SqlClient.SqlParameter("@PflegeplanText", System.Data.SqlDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.SqlClient.SqlParameter("@IDSollberufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDSollberufsstand"),
            new System.Data.SqlClient.SqlParameter("@IDPflegePlanBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegePlanBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@IDPflegeplanH", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegeplanH"),
            new System.Data.SqlClient.SqlParameter("@Solldauer", System.Data.SqlDbType.Int, 0, "Solldauer"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@PflegePlanDauer", System.Data.SqlDbType.Int, 0, "PflegePlanDauer"),
            new System.Data.SqlClient.SqlParameter("@IDDekurs", System.Data.SqlDbType.UniqueIdentifier, 0, "IDDekurs"),
            new System.Data.SqlClient.SqlParameter("@CC", System.Data.SqlDbType.Bit, 0, "CC"),
            new System.Data.SqlClient.SqlParameter("@IDExtern", System.Data.SqlDbType.UniqueIdentifier, 0, "IDExtern"),
            new System.Data.SqlClient.SqlParameter("@Startdatum_Neu", System.Data.SqlDbType.DateTime, 0, "Startdatum_Neu"),
            new System.Data.SqlClient.SqlParameter("@TextRtf", System.Data.SqlDbType.VarChar, 0, "TextRtf"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetJN", System.Data.SqlDbType.Bit, 0, "AbgezeichnetJN"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetIDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetAm", System.Data.SqlDbType.DateTime, 0, "AbgezeichnetAm"),
            new System.Data.SqlClient.SqlParameter("@Dekursherkunft", System.Data.SqlDbType.Int, 0, "Dekursherkunft"),
            new System.Data.SqlClient.SqlParameter("@AbzeichnenJN", System.Data.SqlDbType.Bit, 0, "AbzeichnenJN"),
            new System.Data.SqlClient.SqlParameter("@HAGPflichtigJN", System.Data.SqlDbType.Bit, 0, "HAGPflichtigJN"),
            new System.Data.SqlClient.SqlParameter("@IDBefund", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBefund"),
            new System.Data.SqlClient.SqlParameter("@LogInNameFrei", System.Data.SqlDbType.NVarChar, 0, "LogInNameFrei")});
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
            new System.Data.SqlClient.SqlParameter("@IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAufenthalt"),
            new System.Data.SqlClient.SqlParameter("@IDPflegePlan", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegePlan"),
            new System.Data.SqlClient.SqlParameter("@IDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@IDEintrag", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEintrag"),
            new System.Data.SqlClient.SqlParameter("@IDBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@DatumErstellt", System.Data.SqlDbType.DateTime, 0, "DatumErstellt"),
            new System.Data.SqlClient.SqlParameter("@Zeitpunkt", System.Data.SqlDbType.DateTime, 0, "Zeitpunkt"),
            new System.Data.SqlClient.SqlParameter("@Text", System.Data.SqlDbType.NVarChar, 0, "Text"),
            new System.Data.SqlClient.SqlParameter("@IstDauer", System.Data.SqlDbType.Int, 0, "IstDauer"),
            new System.Data.SqlClient.SqlParameter("@DurchgefuehrtJN", System.Data.SqlDbType.Bit, 0, "DurchgefuehrtJN"),
            new System.Data.SqlClient.SqlParameter("@EintragsTyp", System.Data.SqlDbType.Int, 0, "EintragsTyp"),
            new System.Data.SqlClient.SqlParameter("@Wichtig", System.Data.SqlDbType.Int, 0, "Wichtig"),
            new System.Data.SqlClient.SqlParameter("@IDWichtig", System.Data.SqlDbType.UniqueIdentifier, 0, "IDWichtig"),
            new System.Data.SqlClient.SqlParameter("@IDEvaluierung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDEvaluierung"),
            new System.Data.SqlClient.SqlParameter("@EvalStatus", System.Data.SqlDbType.Int, 0, "EvalStatus"),
            new System.Data.SqlClient.SqlParameter("@PflegeplanText", System.Data.SqlDbType.VarChar, 0, "PflegeplanText"),
            new System.Data.SqlClient.SqlParameter("@IDSollberufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDSollberufsstand"),
            new System.Data.SqlClient.SqlParameter("@IDPflegePlanBerufsstand", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegePlanBerufsstand"),
            new System.Data.SqlClient.SqlParameter("@IDPflegeplanH", System.Data.SqlDbType.UniqueIdentifier, 0, "IDPflegeplanH"),
            new System.Data.SqlClient.SqlParameter("@Solldauer", System.Data.SqlDbType.Int, 0, "Solldauer"),
            new System.Data.SqlClient.SqlParameter("@IDBereich", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBereich"),
            new System.Data.SqlClient.SqlParameter("@IDAbteilung", System.Data.SqlDbType.UniqueIdentifier, 0, "IDAbteilung"),
            new System.Data.SqlClient.SqlParameter("@PflegePlanDauer", System.Data.SqlDbType.Int, 0, "PflegePlanDauer"),
            new System.Data.SqlClient.SqlParameter("@IDDekurs", System.Data.SqlDbType.UniqueIdentifier, 0, "IDDekurs"),
            new System.Data.SqlClient.SqlParameter("@CC", System.Data.SqlDbType.Bit, 0, "CC"),
            new System.Data.SqlClient.SqlParameter("@IDExtern", System.Data.SqlDbType.UniqueIdentifier, 0, "IDExtern"),
            new System.Data.SqlClient.SqlParameter("@Startdatum_Neu", System.Data.SqlDbType.DateTime, 0, "Startdatum_Neu"),
            new System.Data.SqlClient.SqlParameter("@TextRtf", System.Data.SqlDbType.VarChar, 0, "TextRtf"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetJN", System.Data.SqlDbType.Bit, 0, "AbgezeichnetJN"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetIDBenutzer", System.Data.SqlDbType.UniqueIdentifier, 0, "AbgezeichnetIDBenutzer"),
            new System.Data.SqlClient.SqlParameter("@AbgezeichnetAm", System.Data.SqlDbType.DateTime, 0, "AbgezeichnetAm"),
            new System.Data.SqlClient.SqlParameter("@Dekursherkunft", System.Data.SqlDbType.Int, 0, "Dekursherkunft"),
            new System.Data.SqlClient.SqlParameter("@AbzeichnenJN", System.Data.SqlDbType.Bit, 0, "AbzeichnenJN"),
            new System.Data.SqlClient.SqlParameter("@HAGPflichtigJN", System.Data.SqlDbType.Bit, 0, "HAGPflichtigJN"),
            new System.Data.SqlClient.SqlParameter("@IDBefund", System.Data.SqlDbType.UniqueIdentifier, 0, "IDBefund"),
            new System.Data.SqlClient.SqlParameter("@LogInNameFrei", System.Data.SqlDbType.NVarChar, 0, "LogInNameFrei"),
            new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDAufenthalt", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});

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
        public System.Data.SqlClient.SqlDataAdapter daPflegeplan;
        public System.Data.SqlClient.SqlDataAdapter daPflegeEintrag;
    }
}
