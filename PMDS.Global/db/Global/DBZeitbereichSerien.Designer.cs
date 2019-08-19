namespace PMDS.DB.Global
{
    partial class DBZeitbereichSerien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBZeitbereichSerien));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daZeitbereichSerien = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich0", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich0"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich1", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich1"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich2", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich2"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich3", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich3"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich4", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich4"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich5", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich5"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich6", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich6"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich7", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich7")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich0", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich0"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich1", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich1"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich2", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich2"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich3", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich3"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich4", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich4"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich5", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich5"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich6", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich6"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich7", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich7"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [ZeitbereichSerien] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daZeitbereichSerien
            // 
            this.daZeitbereichSerien.DeleteCommand = this.oleDbDeleteCommand1;
            this.daZeitbereichSerien.InsertCommand = this.oleDbInsertCommand1;
            this.daZeitbereichSerien.SelectCommand = this.oleDbSelectCommand1;
            this.daZeitbereichSerien.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZeitbereichSerien", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich0", "IDZeitbereich0"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich1", "IDZeitbereich1"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich2", "IDZeitbereich2"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich3", "IDZeitbereich3"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich4", "IDZeitbereich4"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich5", "IDZeitbereich5"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich6", "IDZeitbereich6"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich7", "IDZeitbereich7")})});
            this.daZeitbereichSerien.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daZeitbereichSerien;
    }
}
