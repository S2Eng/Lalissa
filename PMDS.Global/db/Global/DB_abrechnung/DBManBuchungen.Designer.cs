namespace PMDS.DB.Global
{
    partial class DBManBuchungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBManBuchungen));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daManBuchugenIDKlient = new System.Data.OleDb.OleDbDataAdapter();
            this.daIDAlleKostFürKlient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daManBuchugenID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.Guid, 16, "IDKlient"),
            new System.Data.OleDb.OleDbParameter("datum", System.Data.OleDb.OleDbType.Date, 8, "datum"),
            new System.Data.OleDb.OleDbParameter("datum1", System.Data.OleDb.OleDbType.Date, 8, "datum"),
            new System.Data.OleDb.OleDbParameter("abgerechJN", System.Data.OleDb.OleDbType.Boolean, 1, "abgerechJN"),
            new System.Data.OleDb.OleDbParameter("abgerechJN1", System.Data.OleDb.OleDbType.Boolean, 1, "abgerechJN"),
            new System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.Integer, 4, "typ"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=stysrv10v;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("datum", System.Data.OleDb.OleDbType.Date, 16, "datum"),
            new System.Data.OleDb.OleDbParameter("ReNr", System.Data.OleDb.OleDbType.VarChar, 0, "ReNr"),
            new System.Data.OleDb.OleDbParameter("abrechGruppe", System.Data.OleDb.OleDbType.Integer, 0, "abrechGruppe"),
            new System.Data.OleDb.OleDbParameter("gruppeTxt", System.Data.OleDb.OleDbType.VarChar, 0, "gruppeTxt"),
            new System.Data.OleDb.OleDbParameter("IDRef", System.Data.OleDb.OleDbType.Guid, 0, "IDRef"),
            new System.Data.OleDb.OleDbParameter("betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("MwSt", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "MwSt", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("brutto", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "brutto", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("buchText", System.Data.OleDb.OleDbType.VarChar, 0, "buchText"),
            new System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.Guid, 0, "IDKlient"),
            new System.Data.OleDb.OleDbParameter("abgerechJN", System.Data.OleDb.OleDbType.Boolean, 0, "abgerechJN"),
            new System.Data.OleDb.OleDbParameter("abgerechAm", System.Data.OleDb.OleDbType.Date, 16, "abgerechAm"),
            new System.Data.OleDb.OleDbParameter("erfasst", System.Data.OleDb.OleDbType.VarChar, 0, "erfasst"),
            new System.Data.OleDb.OleDbParameter("am", System.Data.OleDb.OleDbType.Date, 16, "am"),
            new System.Data.OleDb.OleDbParameter("Zeitraumdetail", System.Data.OleDb.OleDbType.VarChar, 0, "Zeitraumdetail"),
            new System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.Integer, 0, "typ"),
            new System.Data.OleDb.OleDbParameter("RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, "RechnungTyp"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("datum", System.Data.OleDb.OleDbType.Date, 16, "datum"),
            new System.Data.OleDb.OleDbParameter("ReNr", System.Data.OleDb.OleDbType.VarChar, 0, "ReNr"),
            new System.Data.OleDb.OleDbParameter("abrechGruppe", System.Data.OleDb.OleDbType.Integer, 0, "abrechGruppe"),
            new System.Data.OleDb.OleDbParameter("gruppeTxt", System.Data.OleDb.OleDbType.VarChar, 0, "gruppeTxt"),
            new System.Data.OleDb.OleDbParameter("IDRef", System.Data.OleDb.OleDbType.Guid, 0, "IDRef"),
            new System.Data.OleDb.OleDbParameter("betrag", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "betrag", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("MwSt", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "MwSt", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("brutto", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "brutto", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("buchText", System.Data.OleDb.OleDbType.VarChar, 0, "buchText"),
            new System.Data.OleDb.OleDbParameter("IDKlient", System.Data.OleDb.OleDbType.Guid, 0, "IDKlient"),
            new System.Data.OleDb.OleDbParameter("abgerechJN", System.Data.OleDb.OleDbType.Boolean, 0, "abgerechJN"),
            new System.Data.OleDb.OleDbParameter("abgerechAm", System.Data.OleDb.OleDbType.Date, 16, "abgerechAm"),
            new System.Data.OleDb.OleDbParameter("erfasst", System.Data.OleDb.OleDbType.VarChar, 0, "erfasst"),
            new System.Data.OleDb.OleDbParameter("am", System.Data.OleDb.OleDbType.Date, 16, "am"),
            new System.Data.OleDb.OleDbParameter("Zeitraumdetail", System.Data.OleDb.OleDbType.VarChar, 0, "Zeitraumdetail"),
            new System.Data.OleDb.OleDbParameter("typ", System.Data.OleDb.OleDbType.Integer, 0, "typ"),
            new System.Data.OleDb.OleDbParameter("RechnungTyp", System.Data.OleDb.OleDbType.Integer, 0, "RechnungTyp"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [manBuch] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daManBuchugenIDKlient
            // 
            this.daManBuchugenIDKlient.DeleteCommand = this.oleDbDeleteCommand1;
            this.daManBuchugenIDKlient.InsertCommand = this.oleDbInsertCommand1;
            this.daManBuchugenIDKlient.SelectCommand = this.oleDbSelectCommand1;
            this.daManBuchugenIDKlient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "manBuch", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("datum", "datum"),
                        new System.Data.Common.DataColumnMapping("ReNr", "ReNr"),
                        new System.Data.Common.DataColumnMapping("abrechGruppe", "abrechGruppe"),
                        new System.Data.Common.DataColumnMapping("gruppeTxt", "gruppeTxt"),
                        new System.Data.Common.DataColumnMapping("IDRef", "IDRef"),
                        new System.Data.Common.DataColumnMapping("betrag", "betrag"),
                        new System.Data.Common.DataColumnMapping("MwSt", "MwSt"),
                        new System.Data.Common.DataColumnMapping("brutto", "brutto"),
                        new System.Data.Common.DataColumnMapping("buchText", "buchText"),
                        new System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"),
                        new System.Data.Common.DataColumnMapping("abgerechJN", "abgerechJN"),
                        new System.Data.Common.DataColumnMapping("abgerechAm", "abgerechAm"),
                        new System.Data.Common.DataColumnMapping("erfasst", "erfasst"),
                        new System.Data.Common.DataColumnMapping("am", "am"),
                        new System.Data.Common.DataColumnMapping("Zeitraumdetail", "Zeitraumdetail"),
                        new System.Data.Common.DataColumnMapping("typ", "typ"),
                        new System.Data.Common.DataColumnMapping("RechnungTyp", "RechnungTyp"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto")})});
            this.daManBuchugenIDKlient.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daIDAlleKostFürKlient
            // 
            this.daIDAlleKostFürKlient.SelectCommand = this.oleDbCommand3;
            this.daIDAlleKostFürKlient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Kostenträger", "Kostenträger"),
                        new System.Data.Common.DataColumnMapping("IDKostenträger", "IDKostenträger"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("GültigAb", "GültigAb"),
                        new System.Data.Common.DataColumnMapping("GültigBis", "GültigBis")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPatient1", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // daManBuchugenID
            // 
            this.daManBuchugenID.SelectCommand = this.oleDbCommand4;
            this.daManBuchugenID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "manBuch", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("datum", "datum"),
                        new System.Data.Common.DataColumnMapping("ReNr", "ReNr"),
                        new System.Data.Common.DataColumnMapping("abrechGruppe", "abrechGruppe"),
                        new System.Data.Common.DataColumnMapping("gruppeTxt", "gruppeTxt"),
                        new System.Data.Common.DataColumnMapping("IDRef", "IDRef"),
                        new System.Data.Common.DataColumnMapping("betrag", "betrag"),
                        new System.Data.Common.DataColumnMapping("MwSt", "MwSt"),
                        new System.Data.Common.DataColumnMapping("brutto", "brutto"),
                        new System.Data.Common.DataColumnMapping("buchText", "buchText"),
                        new System.Data.Common.DataColumnMapping("IDKlient", "IDKlient"),
                        new System.Data.Common.DataColumnMapping("abgerechJN", "abgerechJN"),
                        new System.Data.Common.DataColumnMapping("abgerechAm", "abgerechAm"),
                        new System.Data.Common.DataColumnMapping("erfasst", "erfasst"),
                        new System.Data.Common.DataColumnMapping("am", "am"),
                        new System.Data.Common.DataColumnMapping("Zeitraumdetail", "Zeitraumdetail"),
                        new System.Data.Common.DataColumnMapping("typ", "typ"),
                        new System.Data.Common.DataColumnMapping("RechnungTyp", "RechnungTyp"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daManBuchugenIDKlient;
        private System.Data.OleDb.OleDbDataAdapter daIDAlleKostFürKlient;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daManBuchugenID;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
    }
}
