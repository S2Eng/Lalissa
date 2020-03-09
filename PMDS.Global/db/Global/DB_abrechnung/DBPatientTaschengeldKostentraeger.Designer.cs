namespace PMDS.DB.Global
{
    partial class DBPatientTaschengeldKostentraeger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientTaschengeldKostentraeger));
            this.daPatientTaschengeldKostentraeger = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daAllEntries = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            // 
            // daPatientTaschengeldKostentraeger
            // 
            this.daPatientTaschengeldKostentraeger.DeleteCommand = this.oleDbDeleteCommand;
            this.daPatientTaschengeldKostentraeger.InsertCommand = this.oleDbInsertCommand;
            this.daPatientTaschengeldKostentraeger.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientTaschengeldKostentraeger.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientTaschengeldKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAB", "GueltigAB"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis")})});
            this.daPatientTaschengeldKostentraeger.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [PatientTaschengeldKostentraeger] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAB", System.Data.OleDb.OleDbType.Date, 16, "GueltigAB"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAB", System.Data.OleDb.OleDbType.Date, 16, "GueltigAB"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAllEntries
            // 
            this.daAllEntries.DeleteCommand = this.oleDbCommand1;
            this.daAllEntries.InsertCommand = this.oleDbCommand2;
            this.daAllEntries.SelectCommand = this.oleDbCommand3;
            this.daAllEntries.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientTaschengeldKostentraeger", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDKostentraeger", "IDKostentraeger"),
                        new System.Data.Common.DataColumnMapping("GueltigAB", "GueltigAB"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("Betrag", "Betrag"),
                        new System.Data.Common.DataColumnMapping("ErfasstAm", "ErfasstAm"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("AbgerechnetBis", "AbgerechnetBis")})});
            this.daAllEntries.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PatientTaschengeldKostentraeger] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAB", System.Data.OleDb.OleDbType.Date, 16, "GueltigAB"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, IDPatient, IDKostentraeger, GueltigAB, GueltigBis, Betrag, Erfasst" +
                "Am, IDBenutzer, AbgerechnetBis\r\nFROM         PatientTaschengeldKostentraeger\r\nOR" +
                "DER BY GueltigAB, GueltigBis";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDKostentraeger", System.Data.OleDb.OleDbType.Guid, 0, "IDKostentraeger"),
            new System.Data.OleDb.OleDbParameter("GueltigAB", System.Data.OleDb.OleDbType.Date, 16, "GueltigAB"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Betrag", System.Data.OleDb.OleDbType.Double, 0, "Betrag"),
            new System.Data.OleDb.OleDbParameter("ErfasstAm", System.Data.OleDb.OleDbType.Date, 16, "ErfasstAm"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("AbgerechnetBis", System.Data.OleDb.OleDbType.Date, 16, "AbgerechnetBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.OleDb.OleDbDataAdapter daPatientTaschengeldKostentraeger;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private System.Data.OleDb.OleDbDataAdapter daAllEntries;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
    }
}
