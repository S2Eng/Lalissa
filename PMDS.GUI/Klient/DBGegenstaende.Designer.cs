namespace PMDS.Klient
{
    partial class DBGegenstaende
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBGegenstaende));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsGegenstaende1 = new PMDS.GUI.Klient.dsGegenstaende();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daGegenstaende = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsGegenstaende1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // dsGegenstaende1
            // 
            this.dsGegenstaende1.DataSetName = "dsGegenstaende";
            this.dsGegenstaende1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerausgegeben", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerausgegeben"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerzurueck", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerzurueck"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Nr", System.Data.OleDb.OleDbType.VarChar, 0, "Nr"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Eigentuemer", System.Data.OleDb.OleDbType.VarChar, 0, "Eigentuemer"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("HilfesmittelJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfesmittelJN"),
            new System.Data.OleDb.OleDbParameter("EigentumKlinikJN", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlinikJN"),
            new System.Data.OleDb.OleDbParameter("EigentumKlientJN", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlientJN"),
            new System.Data.OleDb.OleDbParameter("MieteJN", System.Data.OleDb.OleDbType.Boolean, 0, "MieteJN"),
            new System.Data.OleDb.OleDbParameter("LetzteUeberpruefungAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteUeberpruefungAm"),
            new System.Data.OleDb.OleDbParameter("NaechsteUeberpruefungAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteUeberpruefungAm")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerausgegeben", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerausgegeben"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerzurueck", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerzurueck"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Nr", System.Data.OleDb.OleDbType.VarChar, 0, "Nr"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Eigentuemer", System.Data.OleDb.OleDbType.VarChar, 0, "Eigentuemer"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("HilfesmittelJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfesmittelJN"),
            new System.Data.OleDb.OleDbParameter("EigentumKlinikJN", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlinikJN"),
            new System.Data.OleDb.OleDbParameter("EigentumKlientJN", System.Data.OleDb.OleDbType.Boolean, 0, "EigentumKlientJN"),
            new System.Data.OleDb.OleDbParameter("MieteJN", System.Data.OleDb.OleDbType.Boolean, 0, "MieteJN"),
            new System.Data.OleDb.OleDbParameter("LetzteUeberpruefungAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "LetzteUeberpruefungAm"),
            new System.Data.OleDb.OleDbParameter("NaechsteUeberpruefungAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "NaechsteUeberpruefungAm"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Gegenstaende] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daGegenstaende
            // 
            this.daGegenstaende.DeleteCommand = this.oleDbDeleteCommand1;
            this.daGegenstaende.InsertCommand = this.oleDbInsertCommand1;
            this.daGegenstaende.SelectCommand = this.oleDbSelectCommand1;
            this.daGegenstaende.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Gegenstaende", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerausgegeben", "IDBenutzerausgegeben"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerzurueck", "IDBenutzerzurueck"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Nr", "Nr"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Eigentuemer", "Eigentuemer"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
                        new System.Data.Common.DataColumnMapping("HilfesmittelJN", "HilfesmittelJN"),
                        new System.Data.Common.DataColumnMapping("EigentumKlinikJN", "EigentumKlinikJN"),
                        new System.Data.Common.DataColumnMapping("EigentumKlientJN", "EigentumKlientJN"),
                        new System.Data.Common.DataColumnMapping("MieteJN", "MieteJN"),
                        new System.Data.Common.DataColumnMapping("LetzteUeberpruefungAm", "LetzteUeberpruefungAm"),
                        new System.Data.Common.DataColumnMapping("NaechsteUeberpruefungAm", "NaechsteUeberpruefungAm")})});
            this.daGegenstaende.UpdateCommand = this.oleDbUpdateCommand1;
            ((System.ComponentModel.ISupportInitialize)(this.dsGegenstaende1)).EndInit();

        }

        #endregion

        private PMDS.GUI.Klient.dsGegenstaende dsGegenstaende1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daGegenstaende;
    }
}
