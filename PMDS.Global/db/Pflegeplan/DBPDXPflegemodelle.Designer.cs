using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
    partial class DBPDXPflegemodelle
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
            this.dsPDXPflegemodelle1 = new dsPDXPflegemodelle();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPDXPflegemodelle = new System.Data.OleDb.OleDbDataAdapter();
            this.daPDXPflegemodelleByPDX = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXPflegemodelle1)).BeginInit();
            // 
            // dsPDXPflegemodelle1
            // 
            this.dsPDXPflegemodelle1.DataSetName = "dsPDXPflegemodelle";
            this.dsPDXPflegemodelle1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDPDX, IDPflegemodelle\r\nFROM         PDXPflegemodelle";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [PDXPflegemodelle] ([ID], [IDPDX], [IDPflegemodelle]) VALUES (?, ?, ?" +
                ")";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPflegemodelle", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegemodelle")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [PDXPflegemodelle] SET [ID] = ?, [IDPDX] = ?, [IDPflegemodelle] = ? WHERE " +
                "(([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPflegemodelle", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegemodelle"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PDXPflegemodelle] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPDXPflegemodelle
            // 
            this.daPDXPflegemodelle.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPDXPflegemodelle.InsertCommand = this.oleDbInsertCommand1;
            this.daPDXPflegemodelle.SelectCommand = this.oleDbSelectCommand1;
            this.daPDXPflegemodelle.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXPflegemodelle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDPflegemodelle", "IDPflegemodelle")})});
            this.daPDXPflegemodelle.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daPDXPflegemodelleByPDX
            // 
            this.daPDXPflegemodelleByPDX.DeleteCommand = this.oleDbCommand1;
            this.daPDXPflegemodelleByPDX.InsertCommand = this.oleDbCommand2;
            this.daPDXPflegemodelleByPDX.SelectCommand = this.oleDbCommand3;
            this.daPDXPflegemodelleByPDX.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXPflegemodelle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDPflegemodelle", "IDPflegemodelle")})});
            this.daPDXPflegemodelleByPDX.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [PDXPflegemodelle] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [PDXPflegemodelle] ([ID], [IDPDX], [IDPflegemodelle]) VALUES (?, ?, ?" +
                ")";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPflegemodelle", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegemodelle")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, IDPDX, IDPflegemodelle\r\nFROM         PDXPflegemodelle WHERE IDPDX=" +
                "?";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE [PDXPflegemodelle] SET [ID] = ?, [IDPDX] = ?, [IDPflegemodelle] = ? WHERE " +
                "(([ID] = ?))";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 0, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPflegemodelle", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegemodelle"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXPflegemodelle1)).EndInit();

        }

        #endregion

        private dsPDXPflegemodelle dsPDXPflegemodelle1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPDXPflegemodelle;
        private System.Data.OleDb.OleDbDataAdapter daPDXPflegemodelleByPDX;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
    }
}
