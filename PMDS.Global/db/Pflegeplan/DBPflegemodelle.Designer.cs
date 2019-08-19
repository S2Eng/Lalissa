using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
    partial class DBPflegemodelle
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
            this.dsPflegemodelle1 = new dsPflegemodelle();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegemodelle = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegemodelle1)).BeginInit();
            // 
            // dsPflegemodelle1
            // 
            this.dsPflegemodelle1.DataSetName = "dsPflegemodelle";
            this.dsPflegemodelle1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Modell, ModellgruppeKlartext, Modellgruppe, Reihenfolge\r\nFROM     " +
                "    Pflegemodelle ORDER BY Modell, Modellgruppe, Reihenfolge";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Pflegemodelle] ([ID], [Modell], [ModellgruppeKlartext], [Modellgrupp" +
                "e], [Reihenfolge]) VALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("ModellgruppeKlartext", System.Data.OleDb.OleDbType.VarChar, 0, "ModellgruppeKlartext"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Pflegemodelle] SET [ID] = ?, [Modell] = ?, [ModellgruppeKlartext] = ?, [M" +
                "odellgruppe] = ?, [Reihenfolge] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.VarChar, 0, "Modell"),
            new System.Data.OleDb.OleDbParameter("ModellgruppeKlartext", System.Data.OleDb.OleDbType.VarChar, 0, "ModellgruppeKlartext"),
            new System.Data.OleDb.OleDbParameter("Modellgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Modellgruppe"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Pflegemodelle] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegemodelle
            // 
            this.daPflegemodelle.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegemodelle.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegemodelle.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegemodelle.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pflegemodelle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("ModellgruppeKlartext", "ModellgruppeKlartext"),
                        new System.Data.Common.DataColumnMapping("Modellgruppe", "Modellgruppe"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            this.daPflegemodelle.UpdateCommand = this.oleDbUpdateCommand1;
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegemodelle1)).EndInit();

        }

        #endregion

        private dsPflegemodelle dsPflegemodelle1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPflegemodelle;
    }
}
