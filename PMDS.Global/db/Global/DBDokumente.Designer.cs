using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    partial class DBDokumente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBDokumente));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daDokumente = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsDokumente1 = new dsDokumente();
            ((System.ComponentModel.ISupportInitialize)(this.dsDokumente1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDObject, Gruppe, SortOrder, Inhalt, Erstellungsdatum, Aenderungsda" +
                "tum, IDBenutzer_Erstellt, IDBenutzer_Geaendert\r\nFROM         Dokumente\r\nWHERE   " +
                "  (IDObject = ?) AND (Gruppe = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 16, "IDObject"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.Char, 10, "Gruppe")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Dokumente] ([ID], [IDObject], [Gruppe], [SortOrder], [Inhalt], [Erst" +
                "ellungsdatum], [Aenderungsdatum], [IDBenutzer_Erstellt], [IDBenutzer_Geaendert]) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("SortOrder", System.Data.OleDb.OleDbType.Integer, 0, "SortOrder"),
            new System.Data.OleDb.OleDbParameter("Inhalt", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Inhalt"),
            new System.Data.OleDb.OleDbParameter("Erstellungsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Erstellungsdatum"),
            new System.Data.OleDb.OleDbParameter("Aenderungsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Aenderungsdatum"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDObject", System.Data.OleDb.OleDbType.Guid, 0, "IDObject"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("SortOrder", System.Data.OleDb.OleDbType.Integer, 0, "SortOrder"),
            new System.Data.OleDb.OleDbParameter("Inhalt", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Inhalt"),
            new System.Data.OleDb.OleDbParameter("Erstellungsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Erstellungsdatum"),
            new System.Data.OleDb.OleDbParameter("Aenderungsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Aenderungsdatum"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Dokumente] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daDokumente
            // 
            this.daDokumente.DeleteCommand = this.oleDbDeleteCommand1;
            this.daDokumente.InsertCommand = this.oleDbInsertCommand1;
            this.daDokumente.SelectCommand = this.oleDbSelectCommand1;
            this.daDokumente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Dokumente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDObject", "IDObject"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("SortOrder", "SortOrder"),
                        new System.Data.Common.DataColumnMapping("Inhalt", "Inhalt"),
                        new System.Data.Common.DataColumnMapping("Erstellungsdatum", "Erstellungsdatum"),
                        new System.Data.Common.DataColumnMapping("Aenderungsdatum", "Aenderungsdatum"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert")})});
            this.daDokumente.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // dsDokumente1
            // 
            this.dsDokumente1.DataSetName = "dsDokumente";
            this.dsDokumente1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsDokumente1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daDokumente;
        private dsDokumente dsDokumente1;

    }
}
