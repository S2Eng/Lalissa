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
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("ELGAHausarzt", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAHausarzt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationOID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationOID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationName"),
            new System.Data.OleDb.OleDbParameter("IstOrganisation", System.Data.OleDb.OleDbType.Boolean, 0, "IstOrganisation")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("ELGAHausarzt", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAHausarzt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationOID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationOID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationName"),
            new System.Data.OleDb.OleDbParameter("IstOrganisation", System.Data.OleDb.OleDbType.Boolean, 0, "IstOrganisation"),
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
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung"),
                        new System.Data.Common.DataColumnMapping("ELGAAbgeglichen", "ELGAAbgeglichen"),
                        new System.Data.Common.DataColumnMapping("ELGAHausarzt", "ELGAHausarzt"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationOID", "ELGA_OrganizationOID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationName", "ELGA_OrganizationName"),
                        new System.Data.Common.DataColumnMapping("IstOrganisation", "IstOrganisation")})});
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
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung"),
                        new System.Data.Common.DataColumnMapping("ELGAAbgeglichen", "ELGAAbgeglichen"),
                        new System.Data.Common.DataColumnMapping("ELGAHausarzt", "ELGAHausarzt"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationOID", "ELGA_OrganizationOID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationName", "ELGA_OrganizationName"),
                        new System.Data.Common.DataColumnMapping("IstOrganisation", "IstOrganisation")})});
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
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung"),
                        new System.Data.Common.DataColumnMapping("ELGAAbgeglichen", "ELGAAbgeglichen"),
                        new System.Data.Common.DataColumnMapping("ELGAHausarzt", "ELGAHausarzt"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationOID", "ELGA_OrganizationOID"),
                        new System.Data.Common.DataColumnMapping("ELGA_OrganizationName", "ELGA_OrganizationName"),
                        new System.Data.Common.DataColumnMapping("IstOrganisation", "IstOrganisation")})});
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
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("ELGAHausarzt", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAHausarzt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationOID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationOID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationName"),
            new System.Data.OleDb.OleDbParameter("IstOrganisation", System.Data.OleDb.OleDbType.Boolean, 0, "IstOrganisation")});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("ELGAHausarzt", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAHausarzt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationOID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationOID"),
            new System.Data.OleDb.OleDbParameter("ELGA_OrganizationName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OrganizationName"),
            new System.Data.OleDb.OleDbParameter("IstOrganisation", System.Data.OleDb.OleDbType.Boolean, 0, "IstOrganisation"),
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
