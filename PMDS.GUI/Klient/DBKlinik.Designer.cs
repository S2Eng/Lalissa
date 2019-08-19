using PMDS.Global.db.Patient;
namespace PMDS.Klient
{
    partial class DBKlinik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlinik));
            this.dsKlinikByAufenthalt = new PMDS.Global.db.Patient.dsKlinik();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daKlinikByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinikByAufenthalt)).BeginInit();
            // 
            // dsKlinikByAufenthalt
            // 
            this.dsKlinikByAufenthalt.DataSetName = "dsKlinik";
            this.dsKlinikByAufenthalt.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsKlinikByAufenthalt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // daKlinikByAufenthalt
            // 
            this.daKlinikByAufenthalt.SelectCommand = this.oleDbSelectCommand1;
            this.daKlinikByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Klinik", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheLeitungJN", "MitAerztlicheLeitungJN"),
                        new System.Data.Common.DataColumnMapping("MitAerztlicheAufsichtJN", "MitAerztlicheAufsichtJN"),
                        new System.Data.Common.DataColumnMapping("MitPflegedienstleitungJN", "MitPflegedienstleitungJN"),
                        new System.Data.Common.DataColumnMapping("MitPaedagischeLeitungJN", "MitPaedagischeLeitungJN"),
                        new System.Data.Common.DataColumnMapping("Einrichtungsleiter", "Einrichtungsleiter"),
                        new System.Data.Common.DataColumnMapping("IDBank", "IDBank"),
                        new System.Data.Common.DataColumnMapping("ZVR", "ZVR"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterTitel", "EinrichtungsleiterTitel"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterVorname", "EinrichtungsleiterVorname"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGA_AuthorSpeciality", "ELGA_AuthorSpeciality")})});
            ((System.ComponentModel.ISupportInitialize)(this.dsKlinikByAufenthalt)).EndInit();

        }

        #endregion

        private dsKlinik dsKlinikByAufenthalt;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbDataAdapter daKlinikByAufenthalt;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
    }
}
