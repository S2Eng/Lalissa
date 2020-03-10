namespace PMDS.DB.Global
{
    partial class DBVerwaltung
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
            this.daObjektKatalog = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            // 
            // daObjektKatalog
            // 
            this.daObjektKatalog.DeleteCommand = this.oleDbDeleteCommand3;
            this.daObjektKatalog.InsertCommand = this.oleDbInsertCommand3;
            this.daObjektKatalog.SelectCommand = this.oleDbSelectCommand3;
            this.daObjektKatalog.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ObjektKatalog", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegeintrag", "IDPflegeintrag"),
                        new System.Data.Common.DataColumnMapping("IDBeruf", "IDBeruf"),
                        new System.Data.Common.DataColumnMapping("Main", "Main"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("TypeObj", "TypeObj"),
                        new System.Data.Common.DataColumnMapping("Classification", "Classification"),
                        new System.Data.Common.DataColumnMapping("Sort", "Sort")})});
            this.daObjektKatalog.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [ObjektKatalog] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = this.dbConn;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO [ObjektKatalog] ([ID], [IDPflegeintrag], [IDBeruf], [Main], [Von], [B" +
    "is], [TypeObj], [Classification], [Sort]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand3.Connection = this.dbConn;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegeintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeintrag"),
            new System.Data.OleDb.OleDbParameter("IDBeruf", System.Data.OleDb.OleDbType.Guid, 0, "IDBeruf"),
            new System.Data.OleDb.OleDbParameter("Main", System.Data.OleDb.OleDbType.Boolean, 0, "Main"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.Date, 16, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.Date, 16, "Bis"),
            new System.Data.OleDb.OleDbParameter("TypeObj", System.Data.OleDb.OleDbType.VarChar, 0, "TypeObj"),
            new System.Data.OleDb.OleDbParameter("Classification", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Classification"),
            new System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.Integer, 0, "Sort")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT        ID, IDPflegeintrag, IDBeruf, Main, Von, Bis, TypeObj, Classificatio" +
    "n, Sort\r\nFROM            ObjektKatalog";
            this.oleDbSelectCommand3.Connection = this.dbConn;
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE [ObjektKatalog] SET [ID] = ?, [IDPflegeintrag] = ?, [IDBeruf] = ?, [Main] " +
    "= ?, [Von] = ?, [Bis] = ?, [TypeObj] = ?, [Classification] = ?, [Sort] = ? WHERE" +
    " (([ID] = ?))";
            this.oleDbUpdateCommand3.Connection = this.dbConn;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegeintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeintrag"),
            new System.Data.OleDb.OleDbParameter("IDBeruf", System.Data.OleDb.OleDbType.Guid, 0, "IDBeruf"),
            new System.Data.OleDb.OleDbParameter("Main", System.Data.OleDb.OleDbType.Boolean, 0, "Main"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.Date, 16, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.Date, 16, "Bis"),
            new System.Data.OleDb.OleDbParameter("TypeObj", System.Data.OleDb.OleDbType.VarChar, 0, "TypeObj"),
            new System.Data.OleDb.OleDbParameter("Classification", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Classification"),
            new System.Data.OleDb.OleDbParameter("Sort", System.Data.OleDb.OleDbType.Integer, 0, "Sort"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        public System.Data.OleDb.OleDbDataAdapter daObjektKatalog;
        private System.Data.OleDb.OleDbConnection dbConn;
    }
}
