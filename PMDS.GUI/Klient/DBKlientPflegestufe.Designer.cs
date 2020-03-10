using PMDS.GUI.Klient;

namespace PMDS.Klient
{
    partial class DBKlientPflegestufe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlientPflegestufe));
            this.dsPatientPflegestufe1 = new PMDS.GUI.Klient.dsKlientPflegestufe();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatientPflegestufe = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientPflegestufe1)).BeginInit();
            // 
            // dsPatientPflegestufe1
            // 
            this.dsPatientPflegestufe1.DataSetName = "dsPatientPflegestufe";
            this.dsPatientPflegestufe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "BetragVerwendbar", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(3)), "GutschriftProTagAbwesend", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("AenderungsantragDatum", System.Data.OleDb.OleDbType.Date, 16, "AenderungsantragDatum"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufeAntrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufeAntrag"),
            new System.Data.OleDb.OleDbParameter("GenehmigungDatum", System.Data.OleDb.OleDbType.Date, 16, "GenehmigungDatum"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufeGenehmigt", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufeGenehmigt"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufe", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufe"),
            new System.Data.OleDb.OleDbParameter("BetragVerwendbar", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(2)), "BetragVerwendbar", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GutschriftProTagAbwesend", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(10)), ((byte)(3)), "GutschriftProTagAbwesend", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("GueltigAb", System.Data.OleDb.OleDbType.Date, 16, "GueltigAb"),
            new System.Data.OleDb.OleDbParameter("AenderungsantragDatum", System.Data.OleDb.OleDbType.Date, 16, "AenderungsantragDatum"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufeAntrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufeAntrag"),
            new System.Data.OleDb.OleDbParameter("GenehmigungDatum", System.Data.OleDb.OleDbType.Date, 16, "GenehmigungDatum"),
            new System.Data.OleDb.OleDbParameter("IDPflegegeldstufeGenehmigt", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegegeldstufeGenehmigt"),
            new System.Data.OleDb.OleDbParameter("GueltigBis", System.Data.OleDb.OleDbType.Date, 16, "GueltigBis"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PatientPflegestufe] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientPflegestufe
            // 
            this.daPatientPflegestufe.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatientPflegestufe.InsertCommand = this.oleDbInsertCommand1;
            this.daPatientPflegestufe.SelectCommand = this.oleDbSelectCommand1;
            this.daPatientPflegestufe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PatientPflegestufe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufe", "IDPflegegeldstufe"),
                        new System.Data.Common.DataColumnMapping("BetragVerwendbar", "BetragVerwendbar"),
                        new System.Data.Common.DataColumnMapping("GutschriftProTagAbwesend", "GutschriftProTagAbwesend"),
                        new System.Data.Common.DataColumnMapping("GueltigAb", "GueltigAb"),
                        new System.Data.Common.DataColumnMapping("AenderungsantragDatum", "AenderungsantragDatum"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufeAntrag", "IDPflegegeldstufeAntrag"),
                        new System.Data.Common.DataColumnMapping("GenehmigungDatum", "GenehmigungDatum"),
                        new System.Data.Common.DataColumnMapping("IDPflegegeldstufeGenehmigt", "IDPflegegeldstufeGenehmigt"),
                        new System.Data.Common.DataColumnMapping("GueltigBis", "GueltigBis")})});
            this.daPatientPflegestufe.UpdateCommand = this.oleDbUpdateCommand1;
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientPflegestufe1)).EndInit();

        }

        #endregion

        private dsKlientPflegestufe dsPatientPflegestufe1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPatientPflegestufe;
    }
}
