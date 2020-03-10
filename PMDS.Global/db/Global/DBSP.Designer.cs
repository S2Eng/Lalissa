namespace PMDS.DB.Global
{
    partial class DBSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSP));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daSP = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daSPPOS = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daSPPE = new System.Data.OleDb.OleDbDataAdapter();
            this.daSP_open = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
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
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("offenJN", System.Data.OleDb.OleDbType.Boolean, 0, "offenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("EreignisZeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "EreignisZeitpunkt")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("IDStandardProzeduren", System.Data.OleDb.OleDbType.Guid, 0, "IDStandardProzeduren"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("offenJN", System.Data.OleDb.OleDbType.Boolean, 0, "offenJN"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("EreignisZeitpunkt", System.Data.OleDb.OleDbType.Date, 16, "EreignisZeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [SP] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daSP
            // 
            this.daSP.DeleteCommand = this.oleDbDeleteCommand1;
            this.daSP.InsertCommand = this.oleDbInsertCommand1;
            this.daSP.SelectCommand = this.oleDbSelectCommand1;
            this.daSP.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("offenJN", "offenJN"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("EreignisZeitpunkt", "EreignisZeitpunkt")})});
            this.daSP.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     ID, IDSP, IDEintrag, oefterJN, Anmerkung, IDBenutzer_Erstellt, IDBenut" +
                "zer_Geaendert, DatumGeaendert, DatumErstellt, aktivJN, wiederumam\r\nFROM         " +
                "SPPOS\r\nWHERE     (IDSP = ?)";
            this.oleDbSelectCommand2.Connection = oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 16, "IDSP")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 0, "IDSP"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("oefterJN", System.Data.OleDb.OleDbType.Boolean, 0, "oefterJN"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("aktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "aktivJN"),
            new System.Data.OleDb.OleDbParameter("wiederumam", System.Data.OleDb.OleDbType.Date, 16, "wiederumam")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 0, "IDSP"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("oefterJN", System.Data.OleDb.OleDbType.Boolean, 0, "oefterJN"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("aktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "aktivJN"),
            new System.Data.OleDb.OleDbParameter("wiederumam", System.Data.OleDb.OleDbType.Date, 16, "wiederumam"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [SPPOS] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daSPPOS
            // 
            this.daSPPOS.DeleteCommand = this.oleDbDeleteCommand2;
            this.daSPPOS.InsertCommand = this.oleDbInsertCommand2;
            this.daSPPOS.SelectCommand = this.oleDbSelectCommand2;
            this.daSPPOS.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SPPOS", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDSP", "IDSP"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("oefterJN", "oefterJN"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("aktivJN", "aktivJN"),
                        new System.Data.Common.DataColumnMapping("wiederumam", "wiederumam")})});
            this.daSPPOS.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT     ID, IDSP, IDPflegeEintrag\r\nFROM         SPPE\r\nWHERE     (IDSP = ?)";
            this.oleDbSelectCommand3.Connection = oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 16, "IDSP")});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO [SPPE] ([ID], [IDSP], [IDPflegeEintrag]) VALUES (?, ?, ?)";
            this.oleDbInsertCommand3.Connection = oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 0, "IDSP"),
            new System.Data.OleDb.OleDbParameter("IDPflegeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeEintrag")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE [SPPE] SET [ID] = ?, [IDSP] = ?, [IDPflegeEintrag] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand3.Connection = oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDSP", System.Data.OleDb.OleDbType.Guid, 0, "IDSP"),
            new System.Data.OleDb.OleDbParameter("IDPflegeEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegeEintrag"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [SPPE] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daSPPE
            // 
            this.daSPPE.DeleteCommand = this.oleDbDeleteCommand3;
            this.daSPPE.InsertCommand = this.oleDbInsertCommand3;
            this.daSPPE.SelectCommand = this.oleDbSelectCommand3;
            this.daSPPE.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SPPE", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDSP", "IDSP"),
                        new System.Data.Common.DataColumnMapping("IDPflegeEintrag", "IDPflegeEintrag")})});
            this.daSPPE.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // daSP_open
            // 
            this.daSP_open.SelectCommand = this.oleDbCommand3;
            this.daSP_open.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "SP", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("IDStandardProzeduren", "IDStandardProzeduren"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("offenJN", "offenJN"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("EreignisZeitpunkt", "EreignisZeitpunkt")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});

        }

        #endregion

        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daSP;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter daSPPOS;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private System.Data.OleDb.OleDbDataAdapter daSPPE;
        private System.Data.OleDb.OleDbDataAdapter daSP_open;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
    }
}
