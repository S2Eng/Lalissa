namespace PMDS.DB.Global
{
    partial class DBEssen
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
            System.Data.OleDb.OleDbConnection oleDbConnection1;
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daEssen = new System.Data.OleDb.OleDbDataAdapter();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STY041\\MSSQL2019;Integrated Security=SSPI;Initial " +
    "Catalog=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Tag, AnzahlBetten, Belegung, EssenPersonal, EssenGaeste, Urlaube\r\n" +
    "FROM         Essen\r\nWHERE     (Tag >= ?) AND (Tag <= ?)";
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tag", System.Data.DataRowVersion.Current, "01.01.2000"),
            new System.Data.OleDb.OleDbParameter("Tag1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Tag", System.Data.DataRowVersion.Current, "31.12.2020")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Essen] ([ID], [Tag], [AnzahlBetten], [Belegung], [EssenPersonal], [E" +
    "ssenGaeste], [Urlaube]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Tag"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten"),
            new System.Data.OleDb.OleDbParameter("Belegung", System.Data.OleDb.OleDbType.Integer, 0, "Belegung"),
            new System.Data.OleDb.OleDbParameter("EssenPersonal", System.Data.OleDb.OleDbType.Integer, 0, "EssenPersonal"),
            new System.Data.OleDb.OleDbParameter("EssenGaeste", System.Data.OleDb.OleDbType.Integer, 0, "EssenGaeste"),
            new System.Data.OleDb.OleDbParameter("Urlaube", System.Data.OleDb.OleDbType.Integer, 0, "Urlaube")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Essen] SET [ID] = ?, [Tag] = ?, [AnzahlBetten] = ?, [Belegung] = ?, [Esse" +
    "nPersonal] = ?, [EssenGaeste] = ?, [Urlaube] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Tag"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten"),
            new System.Data.OleDb.OleDbParameter("Belegung", System.Data.OleDb.OleDbType.Integer, 0, "Belegung"),
            new System.Data.OleDb.OleDbParameter("EssenPersonal", System.Data.OleDb.OleDbType.Integer, 0, "EssenPersonal"),
            new System.Data.OleDb.OleDbParameter("EssenGaeste", System.Data.OleDb.OleDbType.Integer, 0, "EssenGaeste"),
            new System.Data.OleDb.OleDbParameter("Urlaube", System.Data.OleDb.OleDbType.Integer, 0, "Urlaube"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Essen] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daEssen
            // 
            this.daEssen.DeleteCommand = this.oleDbDeleteCommand1;
            this.daEssen.InsertCommand = this.oleDbInsertCommand1;
            this.daEssen.SelectCommand = this.oleDbSelectCommand1;
            this.daEssen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Essen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Tag", "Tag"),
                        new System.Data.Common.DataColumnMapping("AnzahlBetten", "AnzahlBetten"),
                        new System.Data.Common.DataColumnMapping("Belegung", "Belegung"),
                        new System.Data.Common.DataColumnMapping("EssenPersonal", "EssenPersonal"),
                        new System.Data.Common.DataColumnMapping("EssenGaeste", "EssenGaeste"),
                        new System.Data.Common.DataColumnMapping("Urlaube", "Urlaube")})});
            this.daEssen.UpdateCommand = this.oleDbUpdateCommand1;

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daEssen;
    }
}
