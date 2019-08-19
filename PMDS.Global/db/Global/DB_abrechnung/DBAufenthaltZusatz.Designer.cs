namespace PMDS.Calc.Admin.DB
{
    partial class DBAufenthaltZusatz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAufenthaltZusatz));
            this.daByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daAufenthaltZusatz = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            // 
            // daByAufenthalt
            // 
            this.daByAufenthalt.SelectCommand = this.oleDbSelectCommand1;
            this.daByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AufenthaltZusatz", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Zimmernummer", "Zimmernummer"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeAntragDatum", "SozialhilfeAntragDatum"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeBescheidJN", "SozialhilfeBescheidJN"),
                        new System.Data.Common.DataColumnMapping("MinSaldo", "MinSaldo"),
                        new System.Data.Common.DataColumnMapping("OffeneRechnungJN", "OffeneRechnungJN"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeBescheidGZ", "SozialhilfeBescheidGZ")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, IDAufenthalt, Zimmernummer, SozialhilfeAntragDatum, SozialhilfeBes" +
                "cheidJN, MinSaldo, OffeneRechnungJN, SozialhilfeBescheidGZ\r\nFROM         Aufenth" +
                "altZusatz\r\nWHERE     (IDAufenthalt = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daAufenthaltZusatz
            // 
            this.daAufenthaltZusatz.DeleteCommand = this.oleDbDeleteCommand;
            this.daAufenthaltZusatz.InsertCommand = this.oleDbInsertCommand;
            this.daAufenthaltZusatz.SelectCommand = this.oleDbCommand2;
            this.daAufenthaltZusatz.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AufenthaltZusatz", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Zimmernummer", "Zimmernummer"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeAntragDatum", "SozialhilfeAntragDatum"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeBescheidJN", "SozialhilfeBescheidJN"),
                        new System.Data.Common.DataColumnMapping("MinSaldo", "MinSaldo"),
                        new System.Data.Common.DataColumnMapping("OffeneRechnungJN", "OffeneRechnungJN"),
                        new System.Data.Common.DataColumnMapping("SozialhilfeBescheidGZ", "SozialhilfeBescheidGZ")})});
            this.daAufenthaltZusatz.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [AufenthaltZusatz] WHERE (([ID] = ?))";
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
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Zimmernummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmernummer"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeAntragDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SozialhilfeAntragDatum"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeBescheidJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialhilfeBescheidJN"),
            new System.Data.OleDb.OleDbParameter("MinSaldo", System.Data.OleDb.OleDbType.Double, 0, "MinSaldo"),
            new System.Data.OleDb.OleDbParameter("OffeneRechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "OffeneRechnungJN"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeBescheidGZ", System.Data.OleDb.OleDbType.VarChar, 0, "SozialhilfeBescheidGZ")});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "SELECT     ID, IDAufenthalt, Zimmernummer, SozialhilfeAntragDatum, SozialhilfeBes" +
                "cheidJN, MinSaldo, OffeneRechnungJN, SozialhilfeBescheidGZ\r\nFROM         Aufenth" +
                "altZusatz";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = resources.GetString("oleDbUpdateCommand.CommandText");
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Zimmernummer", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmernummer"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeAntragDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SozialhilfeAntragDatum"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeBescheidJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialhilfeBescheidJN"),
            new System.Data.OleDb.OleDbParameter("MinSaldo", System.Data.OleDb.OleDbType.Double, 0, "MinSaldo"),
            new System.Data.OleDb.OleDbParameter("OffeneRechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "OffeneRechnungJN"),
            new System.Data.OleDb.OleDbParameter("SozialhilfeBescheidGZ", System.Data.OleDb.OleDbType.VarChar, 0, "SozialhilfeBescheidGZ"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});

        }

        #endregion

        private System.Data.OleDb.OleDbDataAdapter daByAufenthalt;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbDataAdapter daAufenthaltZusatz;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand;
    }
}
