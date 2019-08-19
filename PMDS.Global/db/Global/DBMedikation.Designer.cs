namespace PMDS.DB.Global
{
    partial class DBMedikation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBMedikation));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daMedikationVonBis = new System.Data.OleDb.OleDbDataAdapter();
            oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            // 
            // oleDbConnection1
            // 
            oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = oleDbConnection1;
            // 
            // daMedikationVonBis
            // 
            this.daMedikationVonBis.SelectCommand = this.oleDbSelectCommand1;
            this.daMedikationVonBis.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDMedikament", "IDMedikament"),
                        new System.Data.Common.DataColumnMapping("AbzugebenVon", "AbzugebenVon"),
                        new System.Data.Common.DataColumnMapping("AbzugebenBis", "AbzugebenBis"),
                        new System.Data.Common.DataColumnMapping("BeaufsichtigungJN", "BeaufsichtigungJN"),
                        new System.Data.Common.DataColumnMapping("ZP0", "ZP0"),
                        new System.Data.Common.DataColumnMapping("ZP1", "ZP1"),
                        new System.Data.Common.DataColumnMapping("ZP2", "ZP2"),
                        new System.Data.Common.DataColumnMapping("ZP3", "ZP3"),
                        new System.Data.Common.DataColumnMapping("ZP4", "ZP4"),
                        new System.Data.Common.DataColumnMapping("ZP5", "ZP5"),
                        new System.Data.Common.DataColumnMapping("ZP6", "ZP6"),
                        new System.Data.Common.DataColumnMapping("Einheit", "Einheit"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("Wochentage", "Wochentage"),
                        new System.Data.Common.DataColumnMapping("BedarfsMedikationJN", "BedarfsMedikationJN"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("Herrichten", "Herrichten"),
                        new System.Data.Common.DataColumnMapping("AerztlichevorbereitungJN", "AerztlichevorbereitungJN"),
                        new System.Data.Common.DataColumnMapping("Verabreichungsart", "Verabreichungsart"),
                        new System.Data.Common.DataColumnMapping("Applikationsform", "Applikationsform"),
                        new System.Data.Common.DataColumnMapping("Wiederholungstyp", "Wiederholungstyp"),
                        new System.Data.Common.DataColumnMapping("Wiederholungseinheit", "Wiederholungseinheit"),
                        new System.Data.Common.DataColumnMapping("Wiederholungswert", "Wiederholungswert"),
                        new System.Data.Common.DataColumnMapping("StandardzeitenJN", "StandardzeitenJN"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt0", "Zeitpunkt0"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt1", "Zeitpunkt1"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt2", "Zeitpunkt2"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt3", "Zeitpunkt3"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt4", "Zeitpunkt4"),
                        new System.Data.Common.DataColumnMapping("Packunggroesse", "Packunggroesse"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("LangText", "LangText"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("IDAerzte", "IDAerzte"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("PatVorname", "PatVorname"),
                        new System.Data.Common.DataColumnMapping("PatNachname", "PatNachname"),
                        new System.Data.Common.DataColumnMapping("PatGeburtsdatum", "PatGeburtsdatum"),
                        new System.Data.Common.DataColumnMapping("PatTitel", "PatTitel"),
                        new System.Data.Common.DataColumnMapping("PatSexus", "PatSexus")})});
            this.daMedikationVonBis.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.daMedikationVonBis_RowUpdated);

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbDataAdapter daMedikationVonBis;
    }
}
