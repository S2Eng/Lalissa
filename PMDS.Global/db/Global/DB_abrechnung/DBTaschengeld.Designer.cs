namespace PMDS.DB.Global
{
    partial class DBTaschengeld
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBTaschengeld));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daTaschengeldByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.daKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsTaschengeld1 = new PMDS.Global.db.Global.ds_abrechnung.dsTaschengeld();
            ((System.ComponentModel.ISupportInitialize)(this.dsTaschengeld1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.dbConn;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 8, "Datum"),
            new System.Data.OleDb.OleDbParameter("Datum1", System.Data.OleDb.OleDbType.Date, 8, "Datum"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.dbConn;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerdurchgefuehrt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerdurchgefuehrt"),
            new System.Data.OleDb.OleDbParameter("BelegNr", System.Data.OleDb.OleDbType.VarChar, 0, "BelegNr"),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Einzahlung", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Auszahlung", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Saldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Saldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarChar, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgerechnetJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.dbConn;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerdurchgefuehrt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerdurchgefuehrt"),
            new System.Data.OleDb.OleDbParameter("BelegNr", System.Data.OleDb.OleDbType.VarChar, 0, "BelegNr"),
            new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.Date, 16, "Datum"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("Einzahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Einzahlung", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Auszahlung", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Auszahlung", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Saldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "Saldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("Lieferant", System.Data.OleDb.OleDbType.VarChar, 0, "Lieferant"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Zahlart", System.Data.OleDb.OleDbType.Integer, 0, "Zahlart"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetJN", System.Data.OleDb.OleDbType.Boolean, 0, "AbgerechnetJN"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Taschengeld] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.dbConn;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daTaschengeldByPatient
            // 
            this.daTaschengeldByPatient.DeleteCommand = this.oleDbDeleteCommand1;
            this.daTaschengeldByPatient.InsertCommand = this.oleDbInsertCommand1;
            this.daTaschengeldByPatient.SelectCommand = this.oleDbSelectCommand1;
            this.daTaschengeldByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Taschengeld", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerdurchgefuehrt", "IDBenutzerdurchgefuehrt"),
                        new System.Data.Common.DataColumnMapping("BelegNr", "BelegNr"),
                        new System.Data.Common.DataColumnMapping("Datum", "Datum"),
                        new System.Data.Common.DataColumnMapping("Grund", "Grund"),
                        new System.Data.Common.DataColumnMapping("Einzahlung", "Einzahlung"),
                        new System.Data.Common.DataColumnMapping("Auszahlung", "Auszahlung"),
                        new System.Data.Common.DataColumnMapping("Saldo", "Saldo"),
                        new System.Data.Common.DataColumnMapping("Lieferant", "Lieferant"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Zahlart", "Zahlart"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetJN", "AbgerechnetJN"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daTaschengeldByPatient.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daKostentraeger
            // 
            this.daKostentraeger.SelectCommand = this.oleDbCommand3;
            this.daKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Name AS TEXT \r\nFROM            Kostentraeger\r\nWHERE        (IDP" +
    "atient = ?) AND (IDKlinik = ?)\r\nORDER BY TEXT";
            this.oleDbCommand3.Connection = this.dbConn;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // dsTaschengeld1
            // 
            this.dsTaschengeld1.DataSetName = "dsTaschengeld";
            this.dsTaschengeld1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsTaschengeld1)).EndInit();

        }

        #endregion

        private PMDS.Global.db.Global.ds_abrechnung.dsTaschengeld dsTaschengeld1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection dbConn;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daKostentraeger;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        public System.Data.OleDb.OleDbDataAdapter daTaschengeldByPatient;
    }
}
