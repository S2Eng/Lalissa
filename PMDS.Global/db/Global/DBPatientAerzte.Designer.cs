using PMDS.Global.db.Global;
namespace PMDS.DB.Global
{
    partial class DBPatientAerzte
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
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatientAerzte = new System.Data.OleDb.OleDbDataAdapter();
            this.dsPatientAerzte1 = new dsPatientAerzte();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAerzte1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDPatient, IDAerzte, HausarztJN, ZuweiserJN, AufnahmearztJN, Behan" +
                "delnderFAJN, Von, Bis\r\nFROM         PatientAerzte\r\nWHERE     (IDPatient = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [PatientAerzte] ([ID], [IDPatient], [IDAerzte], [HausarztJN], [Zuweis" +
                "erJN], [AufnahmearztJN], [BehandelnderFAJN], [Von], [Bis]) VALUES (?, ?, ?, ?, ?" +
                ", ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("HausarztJN", System.Data.OleDb.OleDbType.Boolean, 0, "HausarztJN"),
            new System.Data.OleDb.OleDbParameter("ZuweiserJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZuweiserJN"),
            new System.Data.OleDb.OleDbParameter("AufnahmearztJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmearztJN"),
            new System.Data.OleDb.OleDbParameter("BehandelnderFAJN", System.Data.OleDb.OleDbType.Boolean, 0, "BehandelnderFAJN"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [PatientAerzte] SET [ID] = ?, [IDPatient] = ?, [IDAerzte] = ?, [HausarztJN" +
                "] = ?, [ZuweiserJN] = ?, [AufnahmearztJN] = ?, [BehandelnderFAJN] = ?, [Von] = ?" +
                ", [Bis] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAerzte", System.Data.OleDb.OleDbType.Guid, 0, "IDAerzte"),
            new System.Data.OleDb.OleDbParameter("HausarztJN", System.Data.OleDb.OleDbType.Boolean, 0, "HausarztJN"),
            new System.Data.OleDb.OleDbParameter("ZuweiserJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZuweiserJN"),
            new System.Data.OleDb.OleDbParameter("AufnahmearztJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmearztJN"),
            new System.Data.OleDb.OleDbParameter("BehandelnderFAJN", System.Data.OleDb.OleDbType.Boolean, 0, "BehandelnderFAJN"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientAerzte] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientAerzte
            // 
            this.daPatientAerzte.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientAerzte.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientAerzte.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientAerzte.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientAerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAerzte", "IDAerzte"),
                        new System.Data.Common.DataColumnMapping("HausarztJN", "HausarztJN"),
                        new System.Data.Common.DataColumnMapping("ZuweiserJN", "ZuweiserJN"),
                        new System.Data.Common.DataColumnMapping("AufnahmearztJN", "AufnahmearztJN"),
                        new System.Data.Common.DataColumnMapping("BehandelnderFAJN", "BehandelnderFAJN"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis")})});
            this.daPatientAerzte.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // dsPatientAerzte1
            // 
            this.dsPatientAerzte1.DataSetName = "dsPatientAerzte";
            this.dsPatientAerzte1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientAerzte1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPatientAerzte;
        private dsPatientAerzte dsPatientAerzte1;
    }
}
