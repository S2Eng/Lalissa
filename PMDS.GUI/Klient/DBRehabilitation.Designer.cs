using PMDS.GUI.Klient;

namespace PMDS.Klient
{
    partial class DBRehabilitation
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
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsRehabilitation1 = new dsRehabilitation();
            this.dsResourcen = new dsRehabilitation();
            this.dsMaßnahmen = new dsRehabilitation();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daRehablilitation = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsRehabilitation1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResourcen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMaßnahmen)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // dsRehabilitation1
            // 
            this.dsRehabilitation1.DataSetName = "dsRehabilitation";
            this.dsRehabilitation1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsResourcen
            // 
            this.dsResourcen.DataSetName = "dsRehabilitation";
            this.dsResourcen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsMaßnahmen
            // 
            this.dsMaßnahmen.DataSetName = "dsRehabilitation";
            this.dsMaßnahmen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDPatient, Beschreibung, Ziel, Institution, Von, Bis, EndeGrund, B" +
                "emerkung, MassnahmeJN\r\nFROM         Rehabilitation\r\nWHERE     (IDPatient = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Rehabilitation] ([ID], [IDPatient], [Beschreibung], [Ziel], [Institu" +
                "tion], [Von], [Bis], [EndeGrund], [Bemerkung], [MassnahmeJN]) VALUES (?, ?, ?, ?" +
                ", ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Ziel", System.Data.OleDb.OleDbType.VarChar, 0, "Ziel"),
            new System.Data.OleDb.OleDbParameter("Institution", System.Data.OleDb.OleDbType.VarChar, 0, "Institution"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("EndeGrund", System.Data.OleDb.OleDbType.VarChar, 0, "EndeGrund"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("MassnahmeJN", System.Data.OleDb.OleDbType.Boolean, 0, "MassnahmeJN")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Rehabilitation] SET [ID] = ?, [IDPatient] = ?, [Beschreibung] = ?, [Ziel]" +
                " = ?, [Institution] = ?, [Von] = ?, [Bis] = ?, [EndeGrund] = ?, [Bemerkung] = ?," +
                " [MassnahmeJN] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Ziel", System.Data.OleDb.OleDbType.VarChar, 0, "Ziel"),
            new System.Data.OleDb.OleDbParameter("Institution", System.Data.OleDb.OleDbType.VarChar, 0, "Institution"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("EndeGrund", System.Data.OleDb.OleDbType.VarChar, 0, "EndeGrund"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("MassnahmeJN", System.Data.OleDb.OleDbType.Boolean, 0, "MassnahmeJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Rehabilitation] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daRehablilitation
            // 
            this.daRehablilitation.DeleteCommand = this.oleDbDeleteCommand1;
            this.daRehablilitation.InsertCommand = this.oleDbInsertCommand1;
            this.daRehablilitation.SelectCommand = this.oleDbSelectCommand1;
            this.daRehablilitation.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Rehabilitation", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Ziel", "Ziel"),
                        new System.Data.Common.DataColumnMapping("Institution", "Institution"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("EndeGrund", "EndeGrund"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("MassnahmeJN", "MassnahmeJN")})});
            this.daRehablilitation.UpdateCommand = this.oleDbUpdateCommand1;
            ((System.ComponentModel.ISupportInitialize)(this.dsRehabilitation1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsResourcen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMaßnahmen)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsRehabilitation dsRehabilitation1;
        private dsRehabilitation dsResourcen;
        private dsRehabilitation dsMaßnahmen;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daRehablilitation;
    }
}
