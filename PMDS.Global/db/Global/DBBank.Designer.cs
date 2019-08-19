using PMDS.Global.db.Global;

namespace PMDS.DB.Global
{
    partial class DBBank
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
            this.dsBank1 = new dsBank();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daBankByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daBankIDKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsBank1)).BeginInit();
            // 
            // dsBank1
            // 
            this.dsBank1.DataSetName = "dsBank";
            this.dsBank1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // daBankByID
            // 
            this.daBankByID.DeleteCommand = this.oleDbCommand1;
            this.daBankByID.InsertCommand = this.oleDbCommand2;
            this.daBankByID.SelectCommand = this.oleDbCommand3;
            this.daBankByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bank", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Kontonummer", "Kontonummer"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("IBAN", "IBAN"),
                        new System.Data.Common.DataColumnMapping("BIC", "BIC"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            this.daBankByID.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [Bank] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [Bank] ([ID], [Bezeichnung], [Kontonummer], [BLZ], [IBAN], [BIC], [ID" +
    "Klinik]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Kontonummer", System.Data.OleDb.OleDbType.Integer, 0, "Kontonummer"),
            new System.Data.OleDb.OleDbParameter("BLZ", System.Data.OleDb.OleDbType.Integer, 0, "BLZ"),
            new System.Data.OleDb.OleDbParameter("IBAN", System.Data.OleDb.OleDbType.VarChar, 0, "IBAN"),
            new System.Data.OleDb.OleDbParameter("BIC", System.Data.OleDb.OleDbType.VarChar, 0, "BIC"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Bezeichnung, Kontonummer, BLZ, IBAN, BIC, IDKlinik\r\nFROM       " +
    "     Bank\r\nWHERE        (ID = ?)";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE [Bank] SET [ID] = ?, [Bezeichnung] = ?, [Kontonummer] = ?, [BLZ] = ?, [IBA" +
    "N] = ?, [BIC] = ?, [IDKlinik] = ? WHERE (([ID] = ?))";
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Kontonummer", System.Data.OleDb.OleDbType.Integer, 0, "Kontonummer"),
            new System.Data.OleDb.OleDbParameter("BLZ", System.Data.OleDb.OleDbType.Integer, 0, "BLZ"),
            new System.Data.OleDb.OleDbParameter("IBAN", System.Data.OleDb.OleDbType.VarChar, 0, "IBAN"),
            new System.Data.OleDb.OleDbParameter("BIC", System.Data.OleDb.OleDbType.VarChar, 0, "BIC"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daBankIDKlinik
            // 
            this.daBankIDKlinik.SelectCommand = this.oleDbCommand7;
            this.daBankIDKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bank", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Kontonummer", "Kontonummer"),
                        new System.Data.Common.DataColumnMapping("BLZ", "BLZ"),
                        new System.Data.Common.DataColumnMapping("IBAN", "IBAN"),
                        new System.Data.Common.DataColumnMapping("BIC", "BIC"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik")})});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT        ID, Bezeichnung, Kontonummer, BLZ, IBAN, BIC, IDKlinik\r\nFROM       " +
    "     Bank\r\nWHERE        (IDKlinik = ?)";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            ((System.ComponentModel.ISupportInitialize)(this.dsBank1)).EndInit();

        }

        #endregion

        private dsBank dsBank1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daBankByID;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbDataAdapter daBankIDKlinik;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
    }
}
