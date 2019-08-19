namespace PMDS.DB.Global
{
    partial class DBAutoUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAutoUI));
            this.daUIDefinitionsByDBTable = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dbConn = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            // 
            // daUIDefinitionsByDBTable
            // 
            this.daUIDefinitionsByDBTable.DeleteCommand = this.oleDbCommand1;
            this.daUIDefinitionsByDBTable.InsertCommand = this.oleDbCommand2;
            this.daUIDefinitionsByDBTable.SelectCommand = this.oleDbCommand3;
            this.daUIDefinitionsByDBTable.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblUIDefinitions", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("UIType", "UIType"),
                        new System.Data.Common.DataColumnMapping("ElementType", "ElementType"),
                        new System.Data.Common.DataColumnMapping("DataType", "DataType"),
                        new System.Data.Common.DataColumnMapping("LabelTxt", "LabelTxt"),
                        new System.Data.Common.DataColumnMapping("IsGroupHeader", "IsGroupHeader"),
                        new System.Data.Common.DataColumnMapping("DbTable", "DbTable"),
                        new System.Data.Common.DataColumnMapping("DbColumn", "DbColumn"),
                        new System.Data.Common.DataColumnMapping("ElementHeigth", "ElementHeigth"),
                        new System.Data.Common.DataColumnMapping("ElementWidth", "ElementWidth"),
                        new System.Data.Common.DataColumnMapping("sort", "sort")})});
            this.daUIDefinitionsByDBTable.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [tblUIDefinitions] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.dbConn;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.dbConn;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("UIType", System.Data.OleDb.OleDbType.WChar, 0, "UIType"),
            new System.Data.OleDb.OleDbParameter("ElementType", System.Data.OleDb.OleDbType.WChar, 0, "ElementType"),
            new System.Data.OleDb.OleDbParameter("DataType", System.Data.OleDb.OleDbType.WChar, 0, "DataType"),
            new System.Data.OleDb.OleDbParameter("LabelTxt", System.Data.OleDb.OleDbType.WChar, 0, "LabelTxt"),
            new System.Data.OleDb.OleDbParameter("IsGroupHeader", System.Data.OleDb.OleDbType.Boolean, 0, "IsGroupHeader"),
            new System.Data.OleDb.OleDbParameter("DbTable", System.Data.OleDb.OleDbType.WChar, 0, "DbTable"),
            new System.Data.OleDb.OleDbParameter("DbColumn", System.Data.OleDb.OleDbType.WChar, 0, "DbColumn"),
            new System.Data.OleDb.OleDbParameter("ElementHeigth", System.Data.OleDb.OleDbType.Integer, 0, "ElementHeigth"),
            new System.Data.OleDb.OleDbParameter("ElementWidth", System.Data.OleDb.OleDbType.Integer, 0, "ElementWidth"),
            new System.Data.OleDb.OleDbParameter("sort", System.Data.OleDb.OleDbType.Integer, 0, "sort")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, UIType, ElementType, DataType, LabelTxt, IsGroupHeader, DbTable" +
    ", DbColumn, ElementHeigth, ElementWidth, sort \r\nFROM            tblUIDefinitions" +
    " where  DbTable = ? order by sort asc";
            this.oleDbCommand3.Connection = this.dbConn;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("DbTable", System.Data.OleDb.OleDbType.WChar, 250, "DbTable")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.dbConn;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("UIType", System.Data.OleDb.OleDbType.WChar, 0, "UIType"),
            new System.Data.OleDb.OleDbParameter("ElementType", System.Data.OleDb.OleDbType.WChar, 0, "ElementType"),
            new System.Data.OleDb.OleDbParameter("DataType", System.Data.OleDb.OleDbType.WChar, 0, "DataType"),
            new System.Data.OleDb.OleDbParameter("LabelTxt", System.Data.OleDb.OleDbType.WChar, 0, "LabelTxt"),
            new System.Data.OleDb.OleDbParameter("IsGroupHeader", System.Data.OleDb.OleDbType.Boolean, 0, "IsGroupHeader"),
            new System.Data.OleDb.OleDbParameter("DbTable", System.Data.OleDb.OleDbType.WChar, 0, "DbTable"),
            new System.Data.OleDb.OleDbParameter("DbColumn", System.Data.OleDb.OleDbType.WChar, 0, "DbColumn"),
            new System.Data.OleDb.OleDbParameter("ElementHeigth", System.Data.OleDb.OleDbType.Integer, 0, "ElementHeigth"),
            new System.Data.OleDb.OleDbParameter("ElementWidth", System.Data.OleDb.OleDbType.Integer, 0, "ElementWidth"),
            new System.Data.OleDb.OleDbParameter("sort", System.Data.OleDb.OleDbType.Integer, 0, "sort"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        public System.Data.OleDb.OleDbDataAdapter daUIDefinitionsByDBTable;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbConnection dbConn;
    }
}
