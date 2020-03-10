namespace PMDS.Global.db.ERSystem
{
    partial class sqlVO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlVO));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daVO = new System.Data.OleDb.OleDbDataAdapter();
            this.daVO_Bestelldaten = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daVO_Bestellpostitionen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.da_VOLager = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.dbConn;
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.dbConn;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Guid, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("Menge", System.Data.OleDb.OleDbType.Double, 0, "Menge"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarWChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Hinweis", System.Data.OleDb.OleDbType.VarWChar, 0, "Hinweis"),
            new System.Data.OleDb.OleDbParameter("DatumVerordnetAb", System.Data.OleDb.OleDbType.DBDate, 0, "DatumVerordnetAb"),
            new System.Data.OleDb.OleDbParameter("DatumVerordnetBis", System.Data.OleDb.OleDbType.DBDate, 0, "DatumVerordnetBis"),
            new System.Data.OleDb.OleDbParameter("BestaetigtVon", System.Data.OleDb.OleDbType.VarWChar, 0, "BestaetigtVon"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.dbConn;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Guid, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("Menge", System.Data.OleDb.OleDbType.Double, 0, "Menge"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarWChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Hinweis", System.Data.OleDb.OleDbType.VarWChar, 0, "Hinweis"),
            new System.Data.OleDb.OleDbParameter("DatumVerordnetAb", System.Data.OleDb.OleDbType.DBDate, 0, "DatumVerordnetAb"),
            new System.Data.OleDb.OleDbParameter("DatumVerordnetBis", System.Data.OleDb.OleDbType.DBDate, 0, "DatumVerordnetBis"),
            new System.Data.OleDb.OleDbParameter("BestaetigtVon", System.Data.OleDb.OleDbType.VarWChar, 0, "BestaetigtVon"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [VO] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.dbConn;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daVO
            // 
            this.daVO.DeleteCommand = this.oleDbDeleteCommand1;
            this.daVO.InsertCommand = this.oleDbInsertCommand1;
            this.daVO.SelectCommand = this.oleDbSelectCommand1;
            this.daVO.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VO", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("Menge", "Menge"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Hinweis", "Hinweis"),
                        new System.Data.Common.DataColumnMapping("DatumVerordnetAb", "DatumVerordnetAb"),
                        new System.Data.Common.DataColumnMapping("DatumVerordnetBis", "DatumVerordnetBis"),
                        new System.Data.Common.DataColumnMapping("BestaetigtVon", "BestaetigtVon"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerErstellt", "IDBenutzerErstellt"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiErstellt", "LoginNameFreiErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerGeaendert", "IDBenutzerGeaendert"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiGeaendert", "LoginNameFreiGeaendert"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant"),
                        new System.Data.Common.DataColumnMapping("HinweisLieferant", "HinweisLieferant"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung")})});
            this.daVO.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daVO_Bestelldaten
            // 
            this.daVO_Bestelldaten.DeleteCommand = this.oleDbCommand1;
            this.daVO_Bestelldaten.InsertCommand = this.oleDbCommand2;
            this.daVO_Bestelldaten.SelectCommand = this.oleDbCommand3;
            this.daVO_Bestelldaten.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VO_Bestelldaten", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDVerordnung", "IDVerordnung"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("EigentumKlient", "EigentumKlient"),
                        new System.Data.Common.DataColumnMapping("Menge", "Menge"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant"),
                        new System.Data.Common.DataColumnMapping("HinweisLieferant", "HinweisLieferant"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerErstellt", "IDBenutzerErstellt"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiErstellt", "LoginNameFreiErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzergeaendert", "IDBenutzergeaendert"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiGeaendert", "LoginNameFreiGeaendert"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("Dauerbestellung", "Dauerbestellung"),
                        new System.Data.Common.DataColumnMapping("DatumNaechsterAnspruch", "DatumNaechsterAnspruch"),
                        new System.Data.Common.DataColumnMapping("SerienterminEndetAm", "SerienterminEndetAm"),
                        new System.Data.Common.DataColumnMapping("SerienterminType", "SerienterminType"),
                        new System.Data.Common.DataColumnMapping("WiedWertJeden", "WiedWertJeden"),
                        new System.Data.Common.DataColumnMapping("TagWochenMonat", "TagWochenMonat"),
                        new System.Data.Common.DataColumnMapping("nTenMonat", "nTenMonat"),
                        new System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("EinmaligeAnforderung", "EinmaligeAnforderung")})});
            this.daVO_Bestelldaten.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [VO_Bestelldaten] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.dbConn;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.dbConn;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDVerordnung", System.Data.OleDb.OleDbType.Guid, 0, "IDVerordnung"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBDate, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.DBDate, 0, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Guid, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("EigentumKlient", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlient"),
            new System.Data.OleDb.OleDbParameter("Menge", System.Data.OleDb.OleDbType.Double, 0, "Menge"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarWChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBDate, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBDate, 0, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Dauerbestellung", System.Data.OleDb.OleDbType.Boolean, 0, "Dauerbestellung"),
            new System.Data.OleDb.OleDbParameter("DatumNaechsterAnspruch", System.Data.OleDb.OleDbType.DBDate, 0, "DatumNaechsterAnspruch"),
            new System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.Date, 16, "SerienterminEndetAm"),
            new System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarChar, 0, "SerienterminType"),
            new System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.Integer, 0, "WiedWertJeden"),
            new System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.VarChar, 0, "TagWochenMonat"),
            new System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.Integer, 0, "nTenMonat"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarChar, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("EinmaligeAnforderung", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligeAnforderung")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.dbConn;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.dbConn;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDVerordnung", System.Data.OleDb.OleDbType.Guid, 0, "IDVerordnung"),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.DBDate, 0, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.DBDate, 0, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Guid, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("EigentumKlient", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlient"),
            new System.Data.OleDb.OleDbParameter("Menge", System.Data.OleDb.OleDbType.Double, 0, "Menge"),
            new System.Data.OleDb.OleDbParameter("Einheit", System.Data.OleDb.OleDbType.VarWChar, 0, "Einheit"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBDate, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzergeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzergeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBDate, 0, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("Dauerbestellung", System.Data.OleDb.OleDbType.Boolean, 0, "Dauerbestellung"),
            new System.Data.OleDb.OleDbParameter("DatumNaechsterAnspruch", System.Data.OleDb.OleDbType.DBDate, 0, "DatumNaechsterAnspruch"),
            new System.Data.OleDb.OleDbParameter("SerienterminEndetAm", System.Data.OleDb.OleDbType.Date,16, "SerienterminEndetAm"),
            new System.Data.OleDb.OleDbParameter("SerienterminType", System.Data.OleDb.OleDbType.VarChar, 0, "SerienterminType"),
            new System.Data.OleDb.OleDbParameter("WiedWertJeden", System.Data.OleDb.OleDbType.Integer, 0, "WiedWertJeden"),
            new System.Data.OleDb.OleDbParameter("TagWochenMonat", System.Data.OleDb.OleDbType.VarChar, 0, "TagWochenMonat"),
            new System.Data.OleDb.OleDbParameter("nTenMonat", System.Data.OleDb.OleDbType.Integer, 0, "nTenMonat"),
            new System.Data.OleDb.OleDbParameter("Wochentage", System.Data.OleDb.OleDbType.VarChar, 0, "Wochentage"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("EinmaligeAnforderung", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligeAnforderung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daVO_Bestellpostitionen
            // 
            this.daVO_Bestellpostitionen.DeleteCommand = this.oleDbCommand5;
            this.daVO_Bestellpostitionen.InsertCommand = this.oleDbCommand6;
            this.daVO_Bestellpostitionen.SelectCommand = this.oleDbCommand7;
            this.daVO_Bestellpostitionen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VO_Bestellpostitionen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDBestelldaten_VO", "IDBestelldaten_VO"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("IDMedikamentGeliefert", "IDMedikamentGeliefert"),
                        new System.Data.Common.DataColumnMapping("DatumBestellung", "DatumBestellung"),
                        new System.Data.Common.DataColumnMapping("MengeBestellung", "MengeBestellung"),
                        new System.Data.Common.DataColumnMapping("EinheitBestellung", "EinheitBestellung"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("Status", "Status"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant"),
                        new System.Data.Common.DataColumnMapping("HinweisLieferant", "HinweisLieferant"),
                        new System.Data.Common.DataColumnMapping("DatumLieferung", "DatumLieferung"),
                        new System.Data.Common.DataColumnMapping("MengeLieferung", "MengeLieferung"),
                        new System.Data.Common.DataColumnMapping("EinheitLieferung", "EinheitLieferung"),
                        new System.Data.Common.DataColumnMapping("BemerkungLieferung", "BemerkungLieferung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerErstellt", "IDBenutzerErstellt"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiErstellt", "LoginNameFreiErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerGeaendert", "IDBenutzerGeaendert"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiGeaendert", "LoginNameFreiGeaendert"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("UserChanged", "UserChanged"),
                        new System.Data.Common.DataColumnMapping("DatumBestellungPlan", "DatumBestellungPlan")})});
            this.daVO_Bestellpostitionen.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM [VO_Bestellpostitionen] WHERE (([ID] = ?))";
            this.oleDbCommand5.Connection = this.dbConn;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = resources.GetString("oleDbCommand6.CommandText");
            this.oleDbCommand6.Connection = this.dbConn;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDBestelldaten_VO", System.Data.OleDb.OleDbType.Guid, 0, "IDBestelldaten_VO"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("IDMedikamentGeliefert", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikamentGeliefert"),
            new System.Data.OleDb.OleDbParameter("DatumBestellung", System.Data.OleDb.OleDbType.DBDate, 0, "DatumBestellung"),
            new System.Data.OleDb.OleDbParameter("MengeBestellung", System.Data.OleDb.OleDbType.Double, 0, "MengeBestellung"),
            new System.Data.OleDb.OleDbParameter("EinheitBestellung", System.Data.OleDb.OleDbType.VarWChar, 0, "EinheitBestellung"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.Guid, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("DatumLieferung", System.Data.OleDb.OleDbType.DBDate, 0, "DatumLieferung"),
            new System.Data.OleDb.OleDbParameter("MengeLieferung", System.Data.OleDb.OleDbType.Double, 0, "MengeLieferung"),
            new System.Data.OleDb.OleDbParameter("EinheitLieferung", System.Data.OleDb.OleDbType.VarWChar, 0, "EinheitLieferung"),
            new System.Data.OleDb.OleDbParameter("BemerkungLieferung", System.Data.OleDb.OleDbType.VarWChar, 0, "BemerkungLieferung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBDate, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBDate, 0, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("UserChanged", System.Data.OleDb.OleDbType.Boolean, 0, "UserChanged"),
            new System.Data.OleDb.OleDbParameter("DatumBestellungPlan", System.Data.OleDb.OleDbType.DBDate, 0, "DatumBestellungPlan")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = resources.GetString("oleDbCommand7.CommandText");
            this.oleDbCommand7.Connection = this.dbConn;
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.dbConn;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDBestelldaten_VO", System.Data.OleDb.OleDbType.Guid, 0, "IDBestelldaten_VO"),
            new System.Data.OleDb.OleDbParameter("IDMedikament", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikament"),
            new System.Data.OleDb.OleDbParameter("IDMedikamentGeliefert", System.Data.OleDb.OleDbType.Guid, 0, "IDMedikamentGeliefert"),
            new System.Data.OleDb.OleDbParameter("DatumBestellung", System.Data.OleDb.OleDbType.DBDate, 0, "DatumBestellung"),
            new System.Data.OleDb.OleDbParameter("MengeBestellung", System.Data.OleDb.OleDbType.Double, 0, "MengeBestellung"),
            new System.Data.OleDb.OleDbParameter("EinheitBestellung", System.Data.OleDb.OleDbType.VarWChar, 0, "EinheitBestellung"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarWChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("Status", System.Data.OleDb.OleDbType.Guid, 0, "Status"),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.Guid, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("HinweisLieferant", System.Data.OleDb.OleDbType.VarWChar, 0, "HinweisLieferant"),
            new System.Data.OleDb.OleDbParameter("DatumLieferung", System.Data.OleDb.OleDbType.DBDate, 0, "DatumLieferung"),
            new System.Data.OleDb.OleDbParameter("MengeLieferung", System.Data.OleDb.OleDbType.Double, 0, "MengeLieferung"),
            new System.Data.OleDb.OleDbParameter("EinheitLieferung", System.Data.OleDb.OleDbType.VarWChar, 0, "EinheitLieferung"),
            new System.Data.OleDb.OleDbParameter("BemerkungLieferung", System.Data.OleDb.OleDbType.VarWChar, 0, "BemerkungLieferung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBDate, 0, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.DBDate, 0, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("UserChanged", System.Data.OleDb.OleDbType.Boolean, 0, "UserChanged"),
            new System.Data.OleDb.OleDbParameter("DatumBestellungPlan", System.Data.OleDb.OleDbType.DBDate, 0, "DatumBestellungPlan"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // da_VOLager
            // 
            this.da_VOLager.DeleteCommand = this.oleDbCommand9;
            this.da_VOLager.InsertCommand = this.oleDbCommand10;
            this.da_VOLager.SelectCommand = this.oleDbCommand11;
            this.da_VOLager.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "VO_Lager", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDVO", "IDVO"),
                        new System.Data.Common.DataColumnMapping("Seriennummer", "Seriennummer"),
                        new System.Data.Common.DataColumnMapping("Zustand", "Zustand"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerErstellt", "IDBenutzerErstellt"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiErstellt", "LoginNameFreiErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerGeaendert", "IDBenutzerGeaendert"),
                        new System.Data.Common.DataColumnMapping("LoginNameFreiGeaendert", "LoginNameFreiGeaendert")})});
            this.da_VOLager.UpdateCommand = this.oleDbCommand12;
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = "DELETE FROM [VO_Lager] WHERE (([ID] = ?))";
            this.oleDbCommand9.Connection = this.dbConn;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = resources.GetString("oleDbCommand10.CommandText");
            this.oleDbCommand10.Connection = this.dbConn;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDVO", System.Data.OleDb.OleDbType.Guid, 0, "IDVO"),
            new System.Data.OleDb.OleDbParameter("Seriennummer", System.Data.OleDb.OleDbType.VarWChar, 0, "Seriennummer"),
            new System.Data.OleDb.OleDbParameter("Zustand", System.Data.OleDb.OleDbType.VarWChar, 0, "Zustand"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert")});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = "SELECT        ID, IDVO, Seriennummer, Zustand, DatumErstellt, IDBenutzerErstellt," +
    " LoginNameFreiErstellt, DatumGeaendert, IDBenutzerGeaendert, LoginNameFreiGeaend" +
    "ert\r\nFROM            VO_Lager";
            this.oleDbCommand11.Connection = this.dbConn;
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = resources.GetString("oleDbCommand12.CommandText");
            this.oleDbCommand12.Connection = this.dbConn;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDVO", System.Data.OleDb.OleDbType.Guid, 0, "IDVO"),
            new System.Data.OleDb.OleDbParameter("Seriennummer", System.Data.OleDb.OleDbType.VarWChar, 0, "Seriennummer"),
            new System.Data.OleDb.OleDbParameter("Zustand", System.Data.OleDb.OleDbType.VarWChar, 0, "Zustand"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerErstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerErstellt"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiErstellt", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerGeaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerGeaendert"),
            new System.Data.OleDb.OleDbParameter("LoginNameFreiGeaendert", System.Data.OleDb.OleDbType.VarWChar, 0, "LoginNameFreiGeaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection dbConn;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        public System.Data.OleDb.OleDbDataAdapter daVO;
        public System.Data.OleDb.OleDbDataAdapter daVO_Bestelldaten;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        public System.Data.OleDb.OleDbDataAdapter daVO_Bestellpostitionen;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        public System.Data.OleDb.OleDbDataAdapter da_VOLager;
        private System.Data.OleDb.OleDbCommand oleDbCommand9;
        private System.Data.OleDb.OleDbCommand oleDbCommand10;
        private System.Data.OleDb.OleDbCommand oleDbCommand11;
        private System.Data.OleDb.OleDbCommand oleDbCommand12;
    }
}
