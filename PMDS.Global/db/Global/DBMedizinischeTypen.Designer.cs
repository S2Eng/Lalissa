namespace PMDS.DB.Global
{
    partial class DBMedizinischeTypen
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
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMedizinischeTypen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.daMedizinischeTypenByTyp = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, Nummer, MedizinischerTyp, Beschreibung, Icon, IconOFF, bVisible" +
    "\r\nFROM            MedizinischeTypen\r\nORDER BY Nummer";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [MedizinischeTypen] ([ID], [Nummer], [MedizinischerTyp], [Beschreibun" +
    "g], [Icon], [IconOFF], [bVisible]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Nummer", System.Data.OleDb.OleDbType.Integer, 0, "Nummer"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"),
            new System.Data.OleDb.OleDbParameter("IconOFF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "IconOFF"),
            new System.Data.OleDb.OleDbParameter("bVisible", System.Data.OleDb.OleDbType.Boolean, 0, "bVisible")});
            // 
            // daMedizinischeTypen
            // 
            this.daMedizinischeTypen.DeleteCommand = this.oleDbDeleteCommand;
            this.daMedizinischeTypen.InsertCommand = this.oleDbInsertCommand1;
            this.daMedizinischeTypen.SelectCommand = this.oleDbSelectCommand1;
            this.daMedizinischeTypen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeTypen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Nummer", "Nummer"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Icon", "Icon"),
                        new System.Data.Common.DataColumnMapping("IconOFF", "IconOFF"),
                        new System.Data.Common.DataColumnMapping("bVisible", "bVisible")})});
            this.daMedizinischeTypen.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [MedizinischeTypen] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [MedizinischeTypen] SET [ID] = ?, [Nummer] = ?, [MedizinischerTyp] = ?, [B" +
    "eschreibung] = ?, [Icon] = ?, [IconOFF] = ?, [bVisible] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Nummer", System.Data.OleDb.OleDbType.Integer, 0, "Nummer"),
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 0, "MedizinischerTyp"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Icon", System.Data.OleDb.OleDbType.LongVarBinary, 0, "Icon"),
            new System.Data.OleDb.OleDbParameter("IconOFF", System.Data.OleDb.OleDbType.LongVarBinary, 0, "IconOFF"),
            new System.Data.OleDb.OleDbParameter("bVisible", System.Data.OleDb.OleDbType.Boolean, 0, "bVisible"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daMedizinischeTypenByTyp
            // 
            this.daMedizinischeTypenByTyp.SelectCommand = this.oleDbCommand3;
            this.daMedizinischeTypenByTyp.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "MedizinischeTypen", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Nummer", "Nummer"),
                        new System.Data.Common.DataColumnMapping("MedizinischerTyp", "MedizinischerTyp"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Icon", "Icon"),
                        new System.Data.Common.DataColumnMapping("IconOFF", "IconOFF"),
                        new System.Data.Common.DataColumnMapping("bVisible", "bVisible")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Nummer, MedizinischerTyp, Beschreibung, Icon, IconOFF, bVisible" +
    "\r\nFROM            MedizinischeTypen\r\nWHERE        (MedizinischerTyp = ?)\r\nORDER " +
    "BY Nummer";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("MedizinischerTyp", System.Data.OleDb.OleDbType.Integer, 4, "MedizinischerTyp")});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbDataAdapter daMedizinischeTypen;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        private System.Data.OleDb.OleDbDataAdapter daMedizinischeTypenByTyp;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
    }
}
