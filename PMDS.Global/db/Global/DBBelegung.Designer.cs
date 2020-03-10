namespace PMDS.DB.Global
{
    partial class DBBelegung
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
            this.daBelegung = new System.Data.OleDb.OleDbDataAdapter();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDAbteilung, Tag, AnzahlBetten, Belegung\r\nFROM         Belegung\r\nW" +
                "HERE     (IDAbteilung = ?) AND (Tag >= ?) AND (Tag <= ?)";
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.Date, 8, "Tag"),
            new System.Data.OleDb.OleDbParameter("Tag1", System.Data.OleDb.OleDbType.Date, 8, "Tag")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Belegung] ([ID], [IDAbteilung], [Tag], [AnzahlBetten], [Belegung]) V" +
                "ALUES (?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.Date, 16, "Tag"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten"),
            new System.Data.OleDb.OleDbParameter("Belegung", System.Data.OleDb.OleDbType.Integer, 0, "Belegung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Belegung] SET [ID] = ?, [IDAbteilung] = ?, [Tag] = ?, [AnzahlBetten] = ?," +
                " [Belegung] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Tag", System.Data.OleDb.OleDbType.Date, 16, "Tag"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten"),
            new System.Data.OleDb.OleDbParameter("Belegung", System.Data.OleDb.OleDbType.Integer, 0, "Belegung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Belegung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daBelegung
            // 
            this.daBelegung.DeleteCommand = this.oleDbDeleteCommand1;
            this.daBelegung.InsertCommand = this.oleDbInsertCommand1;
            this.daBelegung.SelectCommand = this.oleDbSelectCommand1;
            this.daBelegung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Belegung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Tag", "Tag"),
                        new System.Data.Common.DataColumnMapping("AnzahlBetten", "AnzahlBetten"),
                        new System.Data.Common.DataColumnMapping("Belegung", "Belegung")})});
            this.daBelegung.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daBelegung;
    }
}
