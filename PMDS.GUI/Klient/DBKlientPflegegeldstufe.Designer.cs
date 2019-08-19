using PMDS.GUI.Klient;

namespace PMDS.Klient
{
    partial class DBKlientPflegegeldstufe
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
            this.dsKlientPflegegeldstufe1 = new dsKlientPflegegeldstufe();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegegeldstufe = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientPflegegeldstufe1)).BeginInit();
            // 
            // dsKlientPflegegeldstufe1
            // 
            this.dsKlientPflegegeldstufe1.DataSetName = "dsPflegegeldstufe";
            this.dsKlientPflegegeldstufe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, StufeNr, Divisor, Bezeichnung\r\nFROM         Pflegegeldstufe\r\nORDER" +
                " BY Bezeichnung";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Pflegegeldstufe] ([ID], [StufeNr], [Divisor], [Bezeichnung]) VALUES " +
                "(?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Pflegegeldstufe] SET [ID] = ?, [StufeNr] = ?, [Divisor] = ?, [Bezeichnung" +
                "] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("StufeNr", System.Data.OleDb.OleDbType.Integer, 0, "StufeNr"),
            new System.Data.OleDb.OleDbParameter("Divisor", System.Data.OleDb.OleDbType.Integer, 0, "Divisor"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Pflegegeldstufe] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegegeldstufe
            // 
            this.daPflegegeldstufe.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegegeldstufe.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegegeldstufe.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegegeldstufe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pflegegeldstufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("StufeNr", "StufeNr"),
                        new System.Data.Common.DataColumnMapping("Divisor", "Divisor"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daPflegegeldstufe.UpdateCommand = this.oleDbUpdateCommand1;
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientPflegegeldstufe1)).EndInit();

        }

        #endregion

        private dsKlientPflegegeldstufe dsKlientPflegegeldstufe1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPflegegeldstufe;
    }
}
