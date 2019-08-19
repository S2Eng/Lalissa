using PMDS.Global.db.Global;
namespace PMDS.DB.Global
{
    partial class DBNachricht
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBNachricht));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daNachricht = new System.Data.OleDb.OleDbDataAdapter();
            this.dsNachricht1 = new dsNachricht();
            this.dsNachricht2 = new dsNachricht();
            this.daComHistorie = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsNachricht1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsNachricht2)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzerFrom")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerFrom"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandFrom"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerTo"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandTo"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("TerminTyp", System.Data.OleDb.OleDbType.Integer, 0, "TerminTyp"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Zeitstempel", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitstempel"),
            new System.Data.OleDb.OleDbParameter("Nachricht", System.Data.OleDb.OleDbType.LongVarChar, 0, "Nachricht")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerFrom"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandFrom"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerTo"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandTo"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("TerminTyp", System.Data.OleDb.OleDbType.Integer, 0, "TerminTyp"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Zeitstempel", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitstempel"),
            new System.Data.OleDb.OleDbParameter("Nachricht", System.Data.OleDb.OleDbType.LongVarChar, 0, "Nachricht"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [tbl_Nachricht] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daNachricht
            // 
            this.daNachricht.DeleteCommand = this.oleDbDeleteCommand1;
            this.daNachricht.InsertCommand = this.oleDbInsertCommand1;
            this.daNachricht.SelectCommand = this.oleDbSelectCommand1;
            this.daNachricht.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tbl_Nachricht", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerFrom", "IDBenutzerFrom"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstandFrom", "IDBerufsstandFrom"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerTo", "IDBenutzerTo"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstandTo", "IDBerufsstandTo"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("TerminTyp", "TerminTyp"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Zeitstempel", "Zeitstempel"),
                        new System.Data.Common.DataColumnMapping("Nachricht", "Nachricht")})});
            this.daNachricht.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // dsNachricht1
            // 
            this.dsNachricht1.DataSetName = "dsNachricht";
            this.dsNachricht1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsNachricht2
            // 
            this.dsNachricht2.DataSetName = "dsNachricht";
            this.dsNachricht2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daComHistorie
            // 
            this.daComHistorie.DeleteCommand = this.oleDbCommand1;
            this.daComHistorie.InsertCommand = this.oleDbCommand2;
            this.daComHistorie.SelectCommand = this.oleDbCommand3;
            this.daComHistorie.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tbl_Nachricht", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerFrom", "IDBenutzerFrom"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstandFrom", "IDBerufsstandFrom"),
                        new System.Data.Common.DataColumnMapping("IDBenutzerTo", "IDBenutzerTo"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstandTo", "IDBerufsstandTo"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("TerminTyp", "TerminTyp"),
                        new System.Data.Common.DataColumnMapping("EintragsTyp", "EintragsTyp"),
                        new System.Data.Common.DataColumnMapping("Zeitstempel", "Zeitstempel"),
                        new System.Data.Common.DataColumnMapping("Nachricht", "Nachricht")})});
            this.daComHistorie.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [tbl_Nachricht] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerFrom"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandFrom"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerTo"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandTo"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("TerminTyp", System.Data.OleDb.OleDbType.Integer, 0, "TerminTyp"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Zeitstempel", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitstempel"),
            new System.Data.OleDb.OleDbParameter("Nachricht", System.Data.OleDb.OleDbType.LongVarChar, 0, "Nachricht")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzerFrom"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerTo", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzerTo"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Zeitpunkt")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerFrom"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandFrom", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandFrom"),
            new System.Data.OleDb.OleDbParameter("IDBenutzerTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzerTo"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstandTo", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstandTo"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("TerminTyp", System.Data.OleDb.OleDbType.Integer, 0, "TerminTyp"),
            new System.Data.OleDb.OleDbParameter("EintragsTyp", System.Data.OleDb.OleDbType.Integer, 0, "EintragsTyp"),
            new System.Data.OleDb.OleDbParameter("Zeitstempel", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Zeitstempel"),
            new System.Data.OleDb.OleDbParameter("Nachricht", System.Data.OleDb.OleDbType.LongVarChar, 0, "Nachricht"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsNachricht1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsNachricht2)).EndInit();

        }

        #endregion

        private dsNachricht dsNachricht1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daNachricht;
        private dsNachricht dsNachricht2;
        private System.Data.OleDb.OleDbDataAdapter daComHistorie;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
    }
}
