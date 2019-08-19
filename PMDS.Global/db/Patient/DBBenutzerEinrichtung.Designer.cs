namespace PMDS.DB.Patient
{
    partial class DBBenutzerEinrichtung
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
            this.daBenutzerEinrichtung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            // 
            // daBenutzerEinrichtung
            // 
            this.daBenutzerEinrichtung.DeleteCommand = this.oleDbDeleteCommand;
            this.daBenutzerEinrichtung.InsertCommand = this.oleDbInsertCommand;
            this.daBenutzerEinrichtung.SelectCommand = this.oleDbSelectCommand1;
            this.daBenutzerEinrichtung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "BenutzerEinrichtung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDEinrichtung", "IDEinrichtung"),
                        new System.Data.Common.DataColumnMapping("Default", "Default")})});
            this.daBenutzerEinrichtung.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        BenutzerEinrichtung.*\r\nFROM            BenutzerEinrichtung";
            this.oleDbSelectCommand1.Connection = this.dbConn;
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO [BenutzerEinrichtung] ([ID], [IDBenutzer], [IDEinrichtung], [Default]" +
                ") VALUES (?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.dbConn;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung"),
            new System.Data.OleDb.OleDbParameter("Default", System.Data.OleDb.OleDbType.Boolean, 0, "Default")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [BenutzerEinrichtung] SET [ID] = ?, [IDBenutzer] = ?, [IDEinrichtung] = ?," +
                " [Default] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand.Connection = this.dbConn;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDEinrichtung", System.Data.OleDb.OleDbType.Guid, 0, "IDEinrichtung"),
            new System.Data.OleDb.OleDbParameter("Default", System.Data.OleDb.OleDbType.Boolean, 0, "Default"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [BenutzerEinrichtung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.dbConn;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        public System.Data.OleDb.OleDbDataAdapter daBenutzerEinrichtung;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbConnection dbConn;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
    }
}
