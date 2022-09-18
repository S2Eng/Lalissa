namespace qs2.core.language
{
    partial class sqlLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sqlLanguage));
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.dbConn = new System.Data.SqlClient.SqlConnection();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.daLanguage = new System.Data.SqlClient.SqlDataAdapter();
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = resources.GetString("sqlSelectCommand1.CommandText");
            this.sqlSelectCommand1.Connection = this.dbConn;
            // 
            // dbConn
            // 
            this.dbConn.ConnectionString = "Data Source=s2sty010;Initial Catalog=QS2_DEV2;Integrated Security=True";
            this.dbConn.FireInfoMessageEventOnUserErrors = false;
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Connection = this.dbConn;
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IDRes", System.Data.SqlDbType.NVarChar, 0, "IDRes"),
            new System.Data.SqlClient.SqlParameter("@English", System.Data.SqlDbType.NVarChar, 0, "English"),
            new System.Data.SqlClient.SqlParameter("@German", System.Data.SqlDbType.NVarChar, 0, "German"),
            new System.Data.SqlClient.SqlParameter("@User", System.Data.SqlDbType.NVarChar, 0, "User"),
            new System.Data.SqlClient.SqlParameter("@IDLanguageUser", System.Data.SqlDbType.NVarChar, 0, "IDLanguageUser"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"),
            new System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"),
            new System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"),
            new System.Data.SqlClient.SqlParameter("@TypeSub", System.Data.SqlDbType.NVarChar, 0, "TypeSub"),
            new System.Data.SqlClient.SqlParameter("@fileBytes", System.Data.SqlDbType.VarBinary, 0, "fileBytes"),
            new System.Data.SqlClient.SqlParameter("@fileType", System.Data.SqlDbType.NVarChar, 0, "fileType"),
            new System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"),
            new System.Data.SqlClient.SqlParameter("@CreatedUser", System.Data.SqlDbType.NVarChar, 0, "CreatedUser"),
            new System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"),
            new System.Data.SqlClient.SqlParameter("@Image", System.Data.SqlDbType.NVarChar, 0, "Image"),
            new System.Data.SqlClient.SqlParameter("@ImageWidth", System.Data.SqlDbType.Int, 0, "ImageWidth"),
            new System.Data.SqlClient.SqlParameter("@ImageHeigth", System.Data.SqlDbType.Int, 0, "ImageHeigth"),
            new System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"),
            new System.Data.SqlClient.SqlParameter("@LastChange", System.Data.SqlDbType.DateTime, 0, "LastChange"),
            new System.Data.SqlClient.SqlParameter("@ResGroup", System.Data.SqlDbType.NVarChar, 0, "ResGroup")});
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Connection = this.dbConn;
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IDRes", System.Data.SqlDbType.NVarChar, 0, "IDRes"),
            new System.Data.SqlClient.SqlParameter("@English", System.Data.SqlDbType.NVarChar, 0, "English"),
            new System.Data.SqlClient.SqlParameter("@German", System.Data.SqlDbType.NVarChar, 0, "German"),
            new System.Data.SqlClient.SqlParameter("@User", System.Data.SqlDbType.NVarChar, 0, "User"),
            new System.Data.SqlClient.SqlParameter("@IDLanguageUser", System.Data.SqlDbType.NVarChar, 0, "IDLanguageUser"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@IDApplication", System.Data.SqlDbType.NVarChar, 0, "IDApplication"),
            new System.Data.SqlClient.SqlParameter("@IDParticipant", System.Data.SqlDbType.NVarChar, 0, "IDParticipant"),
            new System.Data.SqlClient.SqlParameter("@Type", System.Data.SqlDbType.NVarChar, 0, "Type"),
            new System.Data.SqlClient.SqlParameter("@TypeSub", System.Data.SqlDbType.NVarChar, 0, "TypeSub"),
            new System.Data.SqlClient.SqlParameter("@fileBytes", System.Data.SqlDbType.VarBinary, 0, "fileBytes"),
            new System.Data.SqlClient.SqlParameter("@fileType", System.Data.SqlDbType.NVarChar, 0, "fileType"),
            new System.Data.SqlClient.SqlParameter("@Created", System.Data.SqlDbType.DateTime, 0, "Created"),
            new System.Data.SqlClient.SqlParameter("@CreatedUser", System.Data.SqlDbType.NVarChar, 0, "CreatedUser"),
            new System.Data.SqlClient.SqlParameter("@IDGuid", System.Data.SqlDbType.UniqueIdentifier, 0, "IDGuid"),
            new System.Data.SqlClient.SqlParameter("@Image", System.Data.SqlDbType.NVarChar, 0, "Image"),
            new System.Data.SqlClient.SqlParameter("@ImageWidth", System.Data.SqlDbType.Int, 0, "ImageWidth"),
            new System.Data.SqlClient.SqlParameter("@ImageHeigth", System.Data.SqlDbType.Int, 0, "ImageHeigth"),
            new System.Data.SqlClient.SqlParameter("@Classification", System.Data.SqlDbType.NVarChar, 0, "Classification"),
            new System.Data.SqlClient.SqlParameter("@LastChange", System.Data.SqlDbType.DateTime, 0, "LastChange"),
            new System.Data.SqlClient.SqlParameter("@ResGroup", System.Data.SqlDbType.NVarChar, 0, "ResGroup"),
            new System.Data.SqlClient.SqlParameter("@Original_IDRes", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDRes", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDLanguageUser", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDLanguageUser", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDApplication", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDApplication", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_IDParticipant", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDParticipant", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_Type", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Type", System.Data.DataRowVersion.Original, null)});
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
            new System.Data.SqlClient.SqlParameter("@Original_Type", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Type", System.Data.DataRowVersion.Original, null)});
            // 
            // daLanguage
            // 
            this.daLanguage.DeleteCommand = this.sqlDeleteCommand1;
            this.daLanguage.InsertCommand = this.sqlInsertCommand1;
            this.daLanguage.SelectCommand = this.sqlSelectCommand1;
            this.daLanguage.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
                        new System.Data.Common.DataColumnMapping("CreatedUser", "CreatedUser"),
                        new System.Data.Common.DataColumnMapping("IDGuid", "IDGuid"),
                        new System.Data.Common.DataColumnMapping("Image", "Image"),
                        new System.Data.Common.DataColumnMapping("ImageWidth", "ImageWidth"),
                        new System.Data.Common.DataColumnMapping("ImageHeigth", "ImageHeigth"),
                        new System.Data.Common.DataColumnMapping("Classification", "Classification"),
                        new System.Data.Common.DataColumnMapping("LastChange", "LastChange"),
                        new System.Data.Common.DataColumnMapping("ResGroup", "ResGroup")})});
            this.daLanguage.UpdateCommand = this.sqlUpdateCommand1;

        }

        #endregion

        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlConnection dbConn;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        public System.Data.SqlClient.SqlDataAdapter daLanguage;
    }
}
