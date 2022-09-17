namespace qs2.core.SysDB
{
    partial class sqlSysDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlSysDB));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.dbConn = new System.Data.SqlClient.SqlConnection();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daColumns = new System.Data.SqlClient.SqlDataAdapter();
            this.daTables = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
            this.daSysPrimaryKeys = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
            this.daSysForeignKeys = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daSysComputedColumns = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
            this.daSysIdentityColumns = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.dbConn;
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Data Source=S2STY010\\SQL2005;Initial Catalog=QS2_DEV;Integrated Security=True";
            this.dbConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = resources.GetString("sqlDeleteCommand1.CommandText");
            this.sqlDeleteCommand1.Connection = this.dbConn;
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_IDRes", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDRes", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDLanguageUser", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDLanguageUser", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDApplication", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDParticipant", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDParticipant", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Typ", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Typ", System.Data.DataRowVersion.Original, null)});
            // 
            // daColumns
            // 
            this.daColumns.DeleteCommand = this.sqlDeleteCommand1;
            this.daColumns.SelectCommand = this.sqlSelectCommand1;
            this.daColumns.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "COLUMNS", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TABLE_CATALOG", "TABLE_CATALOG"),
                        new System.Data.Common.DataColumnMapping("TABLE_SCHEMA", "TABLE_SCHEMA"),
                        new System.Data.Common.DataColumnMapping("TABLE_NAME", "TABLE_NAME"),
                        new System.Data.Common.DataColumnMapping("COLUMN_NAME", "COLUMN_NAME"),
                        new System.Data.Common.DataColumnMapping("ORDINAL_POSITION", "ORDINAL_POSITION"),
                        new System.Data.Common.DataColumnMapping("COLUMN_DEFAULT", "COLUMN_DEFAULT"),
                        new System.Data.Common.DataColumnMapping("IS_NULLABLE", "IS_NULLABLE"),
                        new System.Data.Common.DataColumnMapping("DATA_TYPE", "DATA_TYPE"),
                        new System.Data.Common.DataColumnMapping("CHARACTER_MAXIMUM_LENGTH", "CHARACTER_MAXIMUM_LENGTH"),
                        new System.Data.Common.DataColumnMapping("CHARACTER_OCTET_LENGTH", "CHARACTER_OCTET_LENGTH"),
                        new System.Data.Common.DataColumnMapping("NUMERIC_PRECISION", "NUMERIC_PRECISION"),
                        new System.Data.Common.DataColumnMapping("NUMERIC_PRECISION_RADIX", "NUMERIC_PRECISION_RADIX"),
                        new System.Data.Common.DataColumnMapping("NUMERIC_SCALE", "NUMERIC_SCALE"),
                        new System.Data.Common.DataColumnMapping("DATETIME_PRECISION", "DATETIME_PRECISION"),
                        new System.Data.Common.DataColumnMapping("CHARACTER_SET_CATALOG", "CHARACTER_SET_CATALOG"),
                        new System.Data.Common.DataColumnMapping("CHARACTER_SET_SCHEMA", "CHARACTER_SET_SCHEMA"),
                        new System.Data.Common.DataColumnMapping("CHARACTER_SET_NAME", "CHARACTER_SET_NAME"),
                        new System.Data.Common.DataColumnMapping("COLLATION_CATALOG", "COLLATION_CATALOG"),
                        new System.Data.Common.DataColumnMapping("COLLATION_SCHEMA", "COLLATION_SCHEMA"),
                        new System.Data.Common.DataColumnMapping("COLLATION_NAME", "COLLATION_NAME")})});
            // 
            // daTables
            // 
            this.daTables.SelectCommand = this.sqlCommand2;
            this.daTables.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "COLUMNS", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TABLE_NAME", "TABLE_NAME")})});
            // 
            // sqlCommand2
            // 
            this.sqlCommand2.CommandText = "SELECT  Distinct TABLE_NAME \r\nFROM         INFORMATION_SCHEMA.COLUMNS";
            this.sqlCommand2.Connection = this.dbConn;
            // 
            // daSysPrimaryKeys
            // 
            this.daSysPrimaryKeys.SelectCommand = this.sqlCommand3;
            this.daSysPrimaryKeys.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "KEY_COLUMN_USAGE", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TABLE_NAME", "TABLE_NAME"),
                        new System.Data.Common.DataColumnMapping("CONSTRAINT_NAME", "CONSTRAINT_NAME"),
                        new System.Data.Common.DataColumnMapping("COLUMN_NAME", "COLUMN_NAME"),
                        new System.Data.Common.DataColumnMapping("ORDINAL_POSITION", "ORDINAL_POSITION")})});
            // 
            // sqlCommand3
            // 
            this.sqlCommand3.CommandText = resources.GetString("sqlCommand3.CommandText");
            this.sqlCommand3.Connection = this.dbConn;
            // 
            // daSysForeignKeys
            // 
            this.daSysForeignKeys.SelectCommand = this.sqlCommand1;
            this.daSysForeignKeys.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "syscolumns", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Child_Table", "Child_Table"),
                        new System.Data.Common.DataColumnMapping("FKey_Name", "FKey_Name"),
                        new System.Data.Common.DataColumnMapping("FKey_Col", "FKey_Col"),
                        new System.Data.Common.DataColumnMapping("Parent_Table", "Parent_Table"),
                        new System.Data.Common.DataColumnMapping("Ref_KeyCol", "Ref_KeyCol")})});
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandText = resources.GetString("sqlCommand1.CommandText");
            this.sqlCommand1.Connection = this.dbConn;
            // 
            // daSysComputedColumns
            // 
            this.daSysComputedColumns.SelectCommand = this.sqlCommand4;
            this.daSysComputedColumns.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "computed_columns", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TableName", "TableName"),
                        new System.Data.Common.DataColumnMapping("ComputedColumn", "ComputedColumn"),
                        new System.Data.Common.DataColumnMapping("definition", "definition")})});
            // 
            // sqlCommand4
            // 
            this.sqlCommand4.CommandText = "SELECT OBJECT_NAME(object_id) AS \'TableName\',name AS \'ComputedColumn\',definition " +
    "FROM sys.Computed_columns";
            this.sqlCommand4.Connection = this.dbConn;
            // 
            // daSysIdentityColumns
            // 
            this.daSysIdentityColumns.SelectCommand = this.sqlCommand5;
            this.daSysIdentityColumns.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "COLUMNS", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("table_name", "table_name"),
                        new System.Data.Common.DataColumnMapping("column_name", "column_name"),
                        new System.Data.Common.DataColumnMapping("ordinal_position", "ordinal_position"),
                        new System.Data.Common.DataColumnMapping("data_type", "data_type")})});
            // 
            // sqlCommand5
            // 
            this.sqlCommand5.CommandText = " select table_name, column_name, ordinal_position, data_type \r\nfrom information_s" +
    "chema.columns \r\nwhere \r\ntable_schema = \'dbo\' \r\nand columnproperty(object_id(tabl" +
    "e_name), column_name,\'IsIdentity\') = 1";
            this.sqlCommand5.Connection = this.dbConn;

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection dbConn;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        public System.Data.SqlClient.SqlDataAdapter daColumns;
        public System.Data.SqlClient.SqlDataAdapter daTables;
        private System.Data.SqlClient.SqlCommand sqlCommand2;
        public System.Data.SqlClient.SqlDataAdapter daSysPrimaryKeys;
        private System.Data.SqlClient.SqlCommand sqlCommand3;
        public System.Data.SqlClient.SqlDataAdapter daSysForeignKeys;
        private System.Data.SqlClient.SqlCommand sqlCommand1;
        public System.Data.SqlClient.SqlDataAdapter daSysComputedColumns;
        private System.Data.SqlClient.SqlCommand sqlCommand4;
        public System.Data.SqlClient.SqlDataAdapter daSysIdentityColumns;
        private System.Data.SqlClient.SqlCommand sqlCommand5;
    }
}
