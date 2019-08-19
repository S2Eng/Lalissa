using PMDS.Global.db.Global;
namespace PMDS.DB.Global
{
    partial class DBPatientbewerber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPatientbewerber));
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daBewerber = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daPatientBereich = new System.Data.OleDb.OleDbDataAdapter();
            this.dsPatientBereich1 = new PMDS.Data.Patient.dsPatientBereich();
            this.dsPatientBewerber1 = new PMDS.Global.db.Global.dsPatientBewerber();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daPatientByID = new System.Data.OleDb.OleDbDataAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBereich1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBewerber1)).BeginInit();
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STY040;Integrated Security=SSPI;Initial Catalog=PM" +
    "DS_VergissMeinNicht_50";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Patient] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daBewerber
            // 
            this.daBewerber.DeleteCommand = this.oleDbDeleteCommand1;
            this.daBewerber.InsertCommand = this.oleDbInsertCommand1;
            this.daBewerber.SelectCommand = this.oleDbSelectCommand1;
            this.daBewerber.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"),
                        new System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"),
                        new System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"),
                        new System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"),
                        new System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"),
                        new System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"),
                        new System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"),
                        new System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"),
                        new System.Data.Common.DataColumnMapping("Sexus", "Sexus"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daBewerber.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            // 
            // daPatientBereich
            // 
            this.daPatientBereich.SelectCommand = this.oleDbSelectCommand2;
            this.daPatientBereich.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Name", "Name"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
                        new System.Data.Common.DataColumnMapping("Bereich", "Bereich"),
                        new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt")})});
            // 
            // dsPatientBereich1
            // 
            this.dsPatientBereich1.DataSetName = "dsPatientBereich";
            this.dsPatientBereich1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPatientBewerber1
            // 
            this.dsPatientBewerber1.DataSetName = "dsPatientBewerber";
            this.dsPatientBewerber1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Patient] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatientByID
            // 
            this.daPatientByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daPatientByID.InsertCommand = this.oleDbInsertCommand2;
            this.daPatientByID.SelectCommand = this.oleDbSelectCommand3;
            this.daPatientByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"),
                        new System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"),
                        new System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"),
                        new System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"),
                        new System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"),
                        new System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"),
                        new System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"),
                        new System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Sexus", "Sexus"),
                        new System.Data.Common.DataColumnMapping("Familienstand", "Familienstand")})});
            this.daPatientByID.UpdateCommand = this.oleDbUpdateCommand2;
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBereich1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPatientBewerber1)).EndInit();

        }

        #endregion

        private dsPatientBewerber dsPatientBewerber1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daBewerber;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbDataAdapter daPatientBereich;
        private PMDS.Data.Patient.dsPatientBereich dsPatientBereich1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter daPatientByID;
    }
}
