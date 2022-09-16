namespace PMDS.DB.Global
{
    partial class DBSTAMP_Kostentragungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSTAMP_Kostentragungen));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daSTAMP_Kostentragungen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.dsSTAMP_Kostentragungen = new PMDS.Global.dsSTAMP_Kostentragungen();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            ((System.ComponentModel.ISupportInitialize)(this.dsSTAMP_Kostentragungen)).BeginInit();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STY041\\MSSQL2019;Integrated Security=SSPI;Initial " +
    "Catalog=PMDS_DemoGross";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // daSTAMP_Kostentragungen
            // 
            this.daSTAMP_Kostentragungen.DeleteCommand = this.oleDbDeleteCommand;
            this.daSTAMP_Kostentragungen.InsertCommand = this.oleDbInsertCommand;
            this.daSTAMP_Kostentragungen.SelectCommand = this.oleDbSelectCommand1;
            this.daSTAMP_Kostentragungen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "STAMP_Kostentragungen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Finanzierung", "Finanzierung"),
                        new System.Data.Common.DataColumnMapping("FinanzierungSonstige", "FinanzierungSonstige"),
                        new System.Data.Common.DataColumnMapping("GueltigVon", "GueltigVon"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis"),
                        new System.Data.Common.DataColumnMapping("Gemeinde", "Gemeinde"),
                        new System.Data.Common.DataColumnMapping("Bundesland", "Bundesland"),
                        new System.Data.Common.DataColumnMapping("Land", "Land"),
                        new System.Data.Common.DataColumnMapping("Deleted", "Deleted"),
                        new System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser"),
                        new System.Data.Common.DataColumnMapping("CreatedDate", "CreatedDate"),
                        new System.Data.Common.DataColumnMapping("UpdatedUser", "UpdatedUser"),
                        new System.Data.Common.DataColumnMapping("LastUpdateDate", "LastUpdateDate")})});
            this.daSTAMP_Kostentragungen.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [STAMP_Kostentragungen] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Finanzierung", System.Data.OleDb.OleDbType.VarChar, 0, "Finanzierung"),
            new System.Data.OleDb.OleDbParameter("FinanzierungSonstige", System.Data.OleDb.OleDbType.VarChar, 0, "FinanzierungSonstige"),
            new System.Data.OleDb.OleDbParameter("GueltigVon", System.Data.OleDb.OleDbType.Date, 16, "GueltigVon"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Gemeinde", System.Data.OleDb.OleDbType.VarChar, 0, "Gemeinde"),
            new System.Data.OleDb.OleDbParameter("Bundesland", System.Data.OleDb.OleDbType.VarChar, 0, "Bundesland"),
            new System.Data.OleDb.OleDbParameter("Land", System.Data.OleDb.OleDbType.VarChar, 0, "Land"),
            new System.Data.OleDb.OleDbParameter("Deleted", System.Data.OleDb.OleDbType.Boolean, 0, "Deleted"),
            new System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.Guid, 0, "CreatedUser"),
            new System.Data.OleDb.OleDbParameter("CreatedDate", System.Data.OleDb.OleDbType.Date, 16, "CreatedDate"),
            new System.Data.OleDb.OleDbParameter("UpdatedUser", System.Data.OleDb.OleDbType.Guid, 0, "UpdatedUser"),
            new System.Data.OleDb.OleDbParameter("LastUpdateDate", System.Data.OleDb.OleDbType.Date, 16, "LastUpdateDate")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Finanzierung", System.Data.OleDb.OleDbType.VarChar, 0, "Finanzierung"),
            new System.Data.OleDb.OleDbParameter("FinanzierungSonstige", System.Data.OleDb.OleDbType.VarChar, 0, "FinanzierungSonstige"),
            new System.Data.OleDb.OleDbParameter("GueltigVon", System.Data.OleDb.OleDbType.Date, 16, "GueltigVon"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Gemeinde", System.Data.OleDb.OleDbType.VarChar, 0, "Gemeinde"),
            new System.Data.OleDb.OleDbParameter("Bundesland", System.Data.OleDb.OleDbType.VarChar, 0, "Bundesland"),
            new System.Data.OleDb.OleDbParameter("Land", System.Data.OleDb.OleDbType.VarChar, 0, "Land"),
            new System.Data.OleDb.OleDbParameter("Deleted", System.Data.OleDb.OleDbType.Boolean, 0, "Deleted"),
            new System.Data.OleDb.OleDbParameter("CreatedUser", System.Data.OleDb.OleDbType.Guid, 0, "CreatedUser"),
            new System.Data.OleDb.OleDbParameter("CreatedDate", System.Data.OleDb.OleDbType.Date, 16, "CreatedDate"),
            new System.Data.OleDb.OleDbParameter("UpdatedUser", System.Data.OleDb.OleDbType.Guid, 0, "UpdatedUser"),
            new System.Data.OleDb.OleDbParameter("LastUpdateDate", System.Data.OleDb.OleDbType.Date, 16, "LastUpdateDate"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsSTAMP_Kostentragungen
            // 
            this.dsSTAMP_Kostentragungen.DataSetName = "dsSTAMP_Kostentragungen";
            this.dsSTAMP_Kostentragungen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsSTAMP_Kostentragungen)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbDataAdapter daSTAMP_Kostentragungen;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private PMDS.Global.dsSTAMP_Kostentragungen dsSTAMP_Kostentragungen;
    }
}
