namespace PMDS.DB.Global
{
    partial class DBLinkDokumente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBLinkDokumente));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daLinkDokumente = new System.Data.OleDb.OleDbDataAdapter();
            this.daLinkDokumanteByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daLinkDokumenteIDListeAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Beschreibung, LinkName, Dokument, Gruppe, Erstellungsdatum, Aender" +
                "ungsdatum, IDBenutzer_Erstellt, IDBenutzer_Geaendert\r\nFROM         LinkDokumente" +
                "\r\nORDER BY LinkName";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("LinkName", System.Data.OleDb.OleDbType.VarChar, 0, "LinkName"),
            new System.Data.OleDb.OleDbParameter("Dokument", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Dokument"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Erstellungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Erstellungsdatum"),
            new System.Data.OleDb.OleDbParameter("Aenderungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Aenderungsdatum"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("LinkName", System.Data.OleDb.OleDbType.VarChar, 0, "LinkName"),
            new System.Data.OleDb.OleDbParameter("Dokument", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Dokument"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.VarChar, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("Erstellungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Erstellungsdatum"),
            new System.Data.OleDb.OleDbParameter("Aenderungsdatum", System.Data.OleDb.OleDbType.Date, 16, "Aenderungsdatum"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [LinkDokumente] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daLinkDokumente
            // 
            this.daLinkDokumente.DeleteCommand = this.oleDbDeleteCommand1;
            this.daLinkDokumente.InsertCommand = this.oleDbInsertCommand1;
            this.daLinkDokumente.SelectCommand = this.oleDbSelectCommand1;
            this.daLinkDokumente.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "LinkDokumente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("LinkName", "LinkName"),
                        new System.Data.Common.DataColumnMapping("Dokument", "Dokument"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("Erstellungsdatum", "Erstellungsdatum"),
                        new System.Data.Common.DataColumnMapping("Aenderungsdatum", "Aenderungsdatum"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert")})});
            this.daLinkDokumente.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // daLinkDokumanteByID
            // 
            this.daLinkDokumanteByID.SelectCommand = this.oleDbCommand3;
            this.daLinkDokumanteByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "LinkDokumente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("LinkName", "LinkName"),
                        new System.Data.Common.DataColumnMapping("Dokument", "Dokument"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("Erstellungsdatum", "Erstellungsdatum"),
                        new System.Data.Common.DataColumnMapping("Aenderungsdatum", "Aenderungsdatum"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, Beschreibung, LinkName, Dokument, Gruppe, Erstellungsdatum, Aender" +
                "ungsdatum, IDBenutzer_Erstellt, IDBenutzer_Geaendert\r\nFROM         LinkDokumente" +
                "\r\nWHERE     (ID = ?)";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daLinkDokumenteIDListeAll
            // 
            this.daLinkDokumenteIDListeAll.SelectCommand = this.oleDbCommand4;
            this.daLinkDokumenteIDListeAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "LinkDokumente", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "SELECT     ID, Beschreibung AS TEXT\r\nFROM         LinkDokumente\r\nORDER BY Beschre" +
                "ibung";
            this.oleDbCommand4.Connection = this.oleDbConnection1;

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daLinkDokumente;
        private System.Data.OleDb.OleDbDataAdapter daLinkDokumanteByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daLinkDokumenteIDListeAll;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;

    }
}
