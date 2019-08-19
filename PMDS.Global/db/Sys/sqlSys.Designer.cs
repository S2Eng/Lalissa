namespace PMDS.Global.db.Sys
{
    partial class sqlSys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlSys));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daRessourcenITSCont = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daRessourcenITSCont
            // 
            this.daRessourcenITSCont.SelectCommand = this.oleDbSelectCommand1;
            this.daRessourcenITSCont.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Ressourcen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDRes", "IDRes"),
                        new System.Data.Common.DataColumnMapping("English", "English"),
                        new System.Data.Common.DataColumnMapping("German", "German"),
                        new System.Data.Common.DataColumnMapping("User", "User"),
                        new System.Data.Common.DataColumnMapping("IDLanguageUser", "IDLanguageUser"),
                        new System.Data.Common.DataColumnMapping("Description", "Description"),
                        new System.Data.Common.DataColumnMapping("IDApplication", "IDApplication"),
                        new System.Data.Common.DataColumnMapping("IDParticipant", "IDParticipant"),
                        new System.Data.Common.DataColumnMapping("Type", "Type"),
                        new System.Data.Common.DataColumnMapping("TypeSub", "TypeSub"),
                        new System.Data.Common.DataColumnMapping("fileBytes", "fileBytes"),
                        new System.Data.Common.DataColumnMapping("fileType", "fileType"),
                        new System.Data.Common.DataColumnMapping("Created", "Created"),
                        new System.Data.Common.DataColumnMapping("Changed", "Changed"),
                        new System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser"),
                        new System.Data.Common.DataColumnMapping("autoNr", "autoNr"),
                        new System.Data.Common.DataColumnMapping("TableName", "TableName"),
                        new System.Data.Common.DataColumnMapping("ColumnName", "ColumnName")})});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02V\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=ITSContDev";

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daRessourcenITSCont;
    }
}
