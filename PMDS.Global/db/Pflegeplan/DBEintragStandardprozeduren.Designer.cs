using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.PflegePlan
{
    partial class DBEintragStandardprozeduren
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
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daStProzedByEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsEintragStandardprozeduren1 = new dsEintragStandardprozeduren();
            this.dsEintragStandardprozeduren2 = new dsEintragStandardprozeduren();
            this.daStdProzByStandardProz = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragStandardprozeduren1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragStandardprozeduren2)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDEintrag, IDStandardProzeduren\r\nFROM         EintragStandardproze" +
                "duren\r\nWHERE     (IDEintrag = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [EintragStandardprozeduren] ([ID], [IDEintrag], [IDStandardProzeduren" +
                "]) VALUES (?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [EintragStandardprozeduren] SET [ID] = ?, [IDEintrag] = ?, [IDStandardProz" +
                "eduren] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [EintragStandardprozeduren] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daStProzedByEintrag
            // 
            this.daStProzedByEintrag.DeleteCommand = this.oleDbDeleteCommand1;
            this.daStProzedByEintrag.InsertCommand = this.oleDbInsertCommand1;
            this.daStProzedByEintrag.SelectCommand = this.oleDbSelectCommand1;
            this.daStProzedByEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EintragStandardprozeduren", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren")})});
            this.daStProzedByEintrag.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // dsEintragStandardprozeduren1
            // 
            this.dsEintragStandardprozeduren1.DataSetName = "dsEintragStandardprozeduren";
            this.dsEintragStandardprozeduren1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsEintragStandardprozeduren2
            // 
            this.dsEintragStandardprozeduren2.DataSetName = "dsEintragStandardprozeduren";
            this.dsEintragStandardprozeduren2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daStdProzByStandardProz
            // 
            this.daStdProzByStandardProz.SelectCommand = this.oleDbCommand3;
            this.daStdProzByStandardProz.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "EintragStandardprozeduren", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, IDEintrag, IDStandardProzeduren\r\nFROM         EintragStandardproze" +
                "duren\r\nWHERE     (IDStandardProzeduren = ?)";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 16, "IDStandardProzeduren")});
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragStandardprozeduren1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEintragStandardprozeduren2)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daStProzedByEintrag;
        private dsEintragStandardprozeduren dsEintragStandardprozeduren1;
        private dsEintragStandardprozeduren dsEintragStandardprozeduren2;
        private System.Data.OleDb.OleDbDataAdapter daStdProzByStandardProz;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
    }
}
