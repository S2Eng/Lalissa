using PMDS.Global.db.Global;
namespace PMDS.DB.Global
{
    partial class DBAerzte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAerzte));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daAerzte = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAerzteByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.dsAerzte1 = new PMDS.Global.db.Global.dsAerzte();
            this.dsAerzte2 = new PMDS.Global.db.Global.dsAerzte();
            this.daAerzteByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte2)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        ID, IDAdresse, IDKontakt, Titel, Nachname, Vorname, Fachrichtung\r\nF" +
    "ROM            Aerzte\r\nORDER BY Vorname, Nachname";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Aerzte] ([ID], [IDAdresse], [IDKontakt], [Titel], [Nachname], [Vorna" +
    "me], [Fachrichtung]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Aerzte] SET [ID] = ?, [IDAdresse] = ?, [IDKontakt] = ?, [Titel] = ?, [Nac" +
    "hname] = ?, [Vorname] = ?, [Fachrichtung] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Aerzte] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAerzte
            // 
            this.daAerzte.DeleteCommand = this.oleDbDeleteCommand1;
            this.daAerzte.InsertCommand = this.oleDbInsertCommand1;
            this.daAerzte.SelectCommand = this.oleDbSelectCommand1;
            this.daAerzte.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung")})});
            this.daAerzte.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // daAerzteByPatient
            // 
            this.daAerzteByPatient.SelectCommand = this.oleDbSelectCommand2;
            this.daAerzteByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung")})});
            // 
            // dsAerzte1
            // 
            this.dsAerzte1.DataSetName = "dsAerzte";
            this.dsAerzte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsAerzte2
            // 
            this.dsAerzte2.DataSetName = "dsAerzte";
            this.dsAerzte2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAerzteByID
            // 
            this.daAerzteByID.DeleteCommand = this.oleDbDeleteCommand;
            this.daAerzteByID.InsertCommand = this.oleDbInsertCommand;
            this.daAerzteByID.SelectCommand = this.oleDbCommand1;
            this.daAerzteByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung")})});
            this.daAerzteByID.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Aerzte] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO [Aerzte] ([ID], [IDAdresse], [IDKontakt], [Titel], [Nachname], [Vorna" +
    "me], [Fachrichtung]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung")});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT     Aerzte.ID, Aerzte.IDAdresse,Aerzte.IDKontakt, Aerzte.Titel, Aerzte.Nac" +
    "hname, Aerzte.Vorname, Aerzte.Fachrichtung\r\nFROM         Aerzte  \r\nWHERE   ID=?";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [Aerzte] SET [ID] = ?, [IDAdresse] = ?, [IDKontakt] = ?, [Titel] = ?, [Nac" +
    "hname] = ?, [Vorname] = ?, [Fachrichtung] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAerzte2)).EndInit();

        }

        #endregion

        private dsAerzte dsAerzte1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daAerzte;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbDataAdapter daAerzteByPatient;
        private dsAerzte dsAerzte2;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
        public System.Data.OleDb.OleDbDataAdapter daAerzteByID;
    }
}
