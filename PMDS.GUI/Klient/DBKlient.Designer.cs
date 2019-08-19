using PMDS.GUI.Klient;
namespace PMDS.Klient
{
    partial class DBKlient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlient));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.dsKontaktperson1 = new PMDS.GUI.Klient.dsKontaktperson();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daArztByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
            this.dsKlientSachwalter1 = new PMDS.GUI.Klient.dsKlientSachwalter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daSachwalterByPatient = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daKontaktPBypatient = new System.Data.OleDb.OleDbDataAdapter();
            this.dsSachwalter1 = new PMDS.GUI.Klient.dsSachwalter();
            this.dsKontaktpersonen = new PMDS.GUI.Klient.dsKontaktpersonen();
            this.dsDienstleister = new PMDS.GUI.Klient.dsKontaktpersonen();
            this.dsKlient1 = new PMDS.GUI.Klient.dsKlient();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktperson1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientSachwalter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSachwalter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktpersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDienstleister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlient1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM dbo.Kontaktperson\r\nWHERE     (ID = ?)";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 16, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 16, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.Char, 255, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.Char, 25, "Nachname"),
            new System.Data.OleDb.OleDbParameter("VerstaendigenJN", System.Data.OleDb.OleDbType.Boolean, 1, "VerstaendigenJN"),
            new System.Data.OleDb.OleDbParameter("Kontaktart", System.Data.OleDb.OleDbType.Char, 255, "Kontaktart"),
            new System.Data.OleDb.OleDbParameter("Verwandtschaft", System.Data.OleDb.OleDbType.Char, 255, "Verwandtschaft"),
            new System.Data.OleDb.OleDbParameter("ExternerDienstleisterJN", System.Data.OleDb.OleDbType.Boolean, 1, "ExternerDienstleisterJN"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.Char, 25, "Vorname")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 16, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 16, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.Char, 255, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.Char, 25, "Nachname"),
            new System.Data.OleDb.OleDbParameter("VerstaendigenJN", System.Data.OleDb.OleDbType.Boolean, 1, "VerstaendigenJN"),
            new System.Data.OleDb.OleDbParameter("Kontaktart", System.Data.OleDb.OleDbType.Char, 255, "Kontaktart"),
            new System.Data.OleDb.OleDbParameter("Verwandtschaft", System.Data.OleDb.OleDbType.Char, 255, "Verwandtschaft"),
            new System.Data.OleDb.OleDbParameter("ExternerDienstleisterJN", System.Data.OleDb.OleDbType.Boolean, 1, "ExternerDienstleisterJN"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.Char, 25, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsKontaktperson1
            // 
            this.dsKontaktperson1.DataSetName = "dsKontaktperson";
            this.dsKontaktperson1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT     ID, IDAufenthalt, IDAdresse, IDKontakt, Titel, Nachname, Vorname, Fach" +
    "richtung, HausarztJN, ZuweiserJN, AufnahmearztJN, BehandelnderFAJN\r\nFROM        " +
    " Aerzte\r\nWHERE     (IDAufenthalt = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("HausarztJN", System.Data.OleDb.OleDbType.Boolean, 0, "HausarztJN"),
            new System.Data.OleDb.OleDbParameter("ZuweiserJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZuweiserJN"),
            new System.Data.OleDb.OleDbParameter("AufnahmearztJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmearztJN"),
            new System.Data.OleDb.OleDbParameter("BehandelnderFAJN", System.Data.OleDb.OleDbType.Boolean, 0, "BehandelnderFAJN")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Fachrichtung", System.Data.OleDb.OleDbType.VarChar, 0, "Fachrichtung"),
            new System.Data.OleDb.OleDbParameter("HausarztJN", System.Data.OleDb.OleDbType.Boolean, 0, "HausarztJN"),
            new System.Data.OleDb.OleDbParameter("ZuweiserJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZuweiserJN"),
            new System.Data.OleDb.OleDbParameter("AufnahmearztJN", System.Data.OleDb.OleDbType.Boolean, 0, "AufnahmearztJN"),
            new System.Data.OleDb.OleDbParameter("BehandelnderFAJN", System.Data.OleDb.OleDbType.Boolean, 0, "BehandelnderFAJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Aerzte] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daArztByAufenthalt
            // 
            this.daArztByAufenthalt.DeleteCommand = this.oleDbDeleteCommand2;
            this.daArztByAufenthalt.InsertCommand = this.oleDbInsertCommand2;
            this.daArztByAufenthalt.SelectCommand = this.oleDbSelectCommand2;
            this.daArztByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Aerzte", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Fachrichtung", "Fachrichtung"),
                        new System.Data.Common.DataColumnMapping("HausarztJN", "HausarztJN"),
                        new System.Data.Common.DataColumnMapping("ZuweiserJN", "ZuweiserJN"),
                        new System.Data.Common.DataColumnMapping("AufnahmearztJN", "AufnahmearztJN"),
                        new System.Data.Common.DataColumnMapping("BehandelnderFAJN", "BehandelnderFAJN")})});
            this.daArztByAufenthalt.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // dsKlientSachwalter1
            // 
            this.dsKlientSachwalter1.DataSetName = "dsKlientSachwalter";
            this.dsKlientSachwalter1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Konfision", System.Data.OleDb.OleDbType.VarChar, 0, "Konfision"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("Staatsb", System.Data.OleDb.OleDbType.VarChar, 0, "Staatsb"),
            new System.Data.OleDb.OleDbParameter("Klasse", System.Data.OleDb.OleDbType.VarChar, 0, "Klasse"),
            new System.Data.OleDb.OleDbParameter("KrankenKasse", System.Data.OleDb.OleDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.OleDb.OleDbParameter("BlutGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.OleDb.OleDbParameter("Resusfaktor", System.Data.OleDb.OleDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.OleDb.OleDbParameter("LedigerName", System.Data.OleDb.OleDbType.VarChar, 0, "LedigerName"),
            new System.Data.OleDb.OleDbParameter("Geburtsort", System.Data.OleDb.OleDbType.VarChar, 0, "Geburtsort"),
            new System.Data.OleDb.OleDbParameter("Voraufenthalt", System.Data.OleDb.OleDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.OleDb.OleDbParameter("Angehörige", System.Data.OleDb.OleDbType.LongVarChar, 0, "Angehörige"),
            new System.Data.OleDb.OleDbParameter("VersicherungsNr", System.Data.OleDb.OleDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.OleDb.OleDbParameter("ArbeitslosBezSeit", System.Data.OleDb.OleDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.OleDb.OleDbParameter("KrankengeldSeit", System.Data.OleDb.OleDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.OleDb.OleDbParameter("Hauptversicherung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hauptversicherung"),
            new System.Data.OleDb.OleDbParameter("ErlernterBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.OleDb.OleDbParameter("Besonderheit", System.Data.OleDb.OleDbType.LongVarChar, 0, "Besonderheit"),
            new System.Data.OleDb.OleDbParameter("Betreuer", System.Data.OleDb.OleDbType.LongVarChar, 0, "Betreuer"),
            new System.Data.OleDb.OleDbParameter("Sachwalter", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sachwalter"),
            new System.Data.OleDb.OleDbParameter("SachWalterBelange", System.Data.OleDb.OleDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.OleDb.OleDbParameter("SachWalterVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterVon"),
            new System.Data.OleDb.OleDbParameter("SachWalterBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterBis"),
            new System.Data.OleDb.OleDbParameter("SterbeRegel", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbeRegel"),
            new System.Data.OleDb.OleDbParameter("Depotinjektion", System.Data.OleDb.OleDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.OleDb.OleDbParameter("Hausarzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hausarzt"),
            new System.Data.OleDb.OleDbParameter("Vermerk", System.Data.OleDb.OleDbType.LongVarChar, 0, "Vermerk"),
            new System.Data.OleDb.OleDbParameter("SterbeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SterbeDatum"),
            new System.Data.OleDb.OleDbParameter("AktuellerDienstgeber", System.Data.OleDb.OleDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.OleDb.OleDbParameter("DerzeitigerBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.OleDb.OleDbParameter("RezeptgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("PflegegeldantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegegeldantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPflegegeldantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPflegegeldantrag"),
            new System.Data.OleDb.OleDbParameter("PensionsteilungsantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PensionsteilungsantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPensionsteilungsantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPensionsteilungsantrag"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("RollungVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungVon"),
            new System.Data.OleDb.OleDbParameter("RollungBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungBis"),
            new System.Data.OleDb.OleDbParameter("Adelstitel", System.Data.OleDb.OleDbType.VarChar, 0, "Adelstitel"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Initialberuehrung", System.Data.OleDb.OleDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.OleDb.OleDbParameter("Klingeln", System.Data.OleDb.OleDbType.VarChar, 0, "Klingeln"),
            new System.Data.OleDb.OleDbParameter("Wohnsituation", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.OleDb.OleDbParameter("Haustier", System.Data.OleDb.OleDbType.VarChar, 0, "Haustier"),
            new System.Data.OleDb.OleDbParameter("LiftJN", System.Data.OleDb.OleDbType.Boolean, 0, "LiftJN"),
            new System.Data.OleDb.OleDbParameter("WohnungAbgemeldetJN", System.Data.OleDb.OleDbType.Boolean, 0, "WohnungAbgemeldetJN"),
            new System.Data.OleDb.OleDbParameter("Haarfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.OleDb.OleDbParameter("Augenfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.OleDb.OleDbParameter("BesondereAeusserlicheKennzeichen", System.Data.OleDb.OleDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.OleDb.OleDbParameter("FernsehgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("TelefongebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerberJN"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("Stationswunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("ReligionWunsch", System.Data.OleDb.OleDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.OleDb.OleDbParameter("KommunionJN", System.Data.OleDb.OleDbType.Boolean, 0, "KommunionJN"),
            new System.Data.OleDb.OleDbParameter("KrankensalbungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KrankensalbungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("WaescheMarkiert", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.OleDb.OleDbParameter("WaescheWaschen", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.OleDb.OleDbParameter("Zustaendige_Stelle", System.Data.OleDb.OleDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.Integer, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Statur", System.Data.OleDb.OleDbType.VarChar, 0, "Statur"),
            new System.Data.OleDb.OleDbParameter("Namenstag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Namenstag"),
            new System.Data.OleDb.OleDbParameter("Kosename", System.Data.OleDb.OleDbType.VarChar, 0, "Kosename"),
            new System.Data.OleDb.OleDbParameter("Privatversicherung", System.Data.OleDb.OleDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.OleDb.OleDbParameter("PrivPolNr", System.Data.OleDb.OleDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungJN"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungBeachtlichJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "PatientverfuegungDatum"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungAnmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.OleDb.OleDbParameter("Klientennummer", System.Data.OleDb.OleDbType.VarChar, 0, "Klientennummer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Kennwort", System.Data.OleDb.OleDbType.VarChar, 0, "Kennwort"),
            new System.Data.OleDb.OleDbParameter("Verstorben", System.Data.OleDb.OleDbType.Boolean, 0, "Verstorben"),
            new System.Data.OleDb.OleDbParameter("Todeszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Todeszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("DNR", System.Data.OleDb.OleDbType.Boolean, 0, "DNR"),
            new System.Data.OleDb.OleDbParameter("abwesenheitenHändBerech", System.Data.OleDb.OleDbType.Boolean, 0, "abwesenheitenHändBerech"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("blob_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("EinverständniserklärungFileType", System.Data.OleDb.OleDbType.VarWChar, 0, "EinverständniserklärungFileType"),
            new System.Data.OleDb.OleDbParameter("jpg_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("Milieubetreuung", System.Data.OleDb.OleDbType.Boolean, 0, "Milieubetreuung"),
            new System.Data.OleDb.OleDbParameter("KZUeberlebender", System.Data.OleDb.OleDbType.Boolean, 0, "KZUeberlebender"),
            new System.Data.OleDb.OleDbParameter("Anatomie", System.Data.OleDb.OleDbType.Boolean, 0, "Anatomie"),
            new System.Data.OleDb.OleDbParameter("Einzelzimmer", System.Data.OleDb.OleDbType.Boolean, 0, "Einzelzimmer"),
            new System.Data.OleDb.OleDbParameter("Selbstzahler", System.Data.OleDb.OleDbType.Boolean, 0, "Selbstzahler"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("KürzungLetzterTagAnwesenheit", System.Data.OleDb.OleDbType.Boolean, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.OleDb.OleDbParameter("Behindertenausweis", System.Data.OleDb.OleDbType.Boolean, 0, "Behindertenausweis"),
            new System.Data.OleDb.OleDbParameter("Sozialcard", System.Data.OleDb.OleDbType.Boolean, 0, "Sozialcard"),
            new System.Data.OleDb.OleDbParameter("IDAdresseSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresseSub"),
            new System.Data.OleDb.OleDbParameter("IDKontaktSub", System.Data.OleDb.OleDbType.Guid, 0, "IDKontaktSub"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Patient] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daPatient
            // 
            this.daPatient.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPatient.InsertCommand = this.oleDbInsertCommand;
            this.daPatient.SelectCommand = this.oleDbSelectCommand1;
            this.daPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Sexus", "Sexus"),
                        new System.Data.Common.DataColumnMapping("Konfision", "Konfision"),
                        new System.Data.Common.DataColumnMapping("Familienstand", "Familienstand"),
                        new System.Data.Common.DataColumnMapping("Staatsb", "Staatsb"),
                        new System.Data.Common.DataColumnMapping("Klasse", "Klasse"),
                        new System.Data.Common.DataColumnMapping("KrankenKasse", "KrankenKasse"),
                        new System.Data.Common.DataColumnMapping("BlutGruppe", "BlutGruppe"),
                        new System.Data.Common.DataColumnMapping("Resusfaktor", "Resusfaktor"),
                        new System.Data.Common.DataColumnMapping("LedigerName", "LedigerName"),
                        new System.Data.Common.DataColumnMapping("Geburtsort", "Geburtsort"),
                        new System.Data.Common.DataColumnMapping("Voraufenthalt", "Voraufenthalt"),
                        new System.Data.Common.DataColumnMapping("Angehörige", "Angehörige"),
                        new System.Data.Common.DataColumnMapping("VersicherungsNr", "VersicherungsNr"),
                        new System.Data.Common.DataColumnMapping("ArbeitslosBezSeit", "ArbeitslosBezSeit"),
                        new System.Data.Common.DataColumnMapping("KrankengeldSeit", "KrankengeldSeit"),
                        new System.Data.Common.DataColumnMapping("Hauptversicherung", "Hauptversicherung"),
                        new System.Data.Common.DataColumnMapping("ErlernterBeruf", "ErlernterBeruf"),
                        new System.Data.Common.DataColumnMapping("Besonderheit", "Besonderheit"),
                        new System.Data.Common.DataColumnMapping("Betreuer", "Betreuer"),
                        new System.Data.Common.DataColumnMapping("Sachwalter", "Sachwalter"),
                        new System.Data.Common.DataColumnMapping("SachWalterBelange", "SachWalterBelange"),
                        new System.Data.Common.DataColumnMapping("SachWalterVon", "SachWalterVon"),
                        new System.Data.Common.DataColumnMapping("SachWalterBis", "SachWalterBis"),
                        new System.Data.Common.DataColumnMapping("SterbeRegel", "SterbeRegel"),
                        new System.Data.Common.DataColumnMapping("Depotinjektion", "Depotinjektion"),
                        new System.Data.Common.DataColumnMapping("Hausarzt", "Hausarzt"),
                        new System.Data.Common.DataColumnMapping("Vermerk", "Vermerk"),
                        new System.Data.Common.DataColumnMapping("SterbeDatum", "SterbeDatum"),
                        new System.Data.Common.DataColumnMapping("AktuellerDienstgeber", "AktuellerDienstgeber"),
                        new System.Data.Common.DataColumnMapping("DerzeitigerBeruf", "DerzeitigerBeruf"),
                        new System.Data.Common.DataColumnMapping("RezeptgebuehrbefreiungJN", "RezeptgebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("PflegegeldantragJN", "PflegegeldantragJN"),
                        new System.Data.Common.DataColumnMapping("DatumPflegegeldantrag", "DatumPflegegeldantrag"),
                        new System.Data.Common.DataColumnMapping("PensionsteilungsantragJN", "PensionsteilungsantragJN"),
                        new System.Data.Common.DataColumnMapping("DatumPensionsteilungsantrag", "DatumPensionsteilungsantrag"),
                        new System.Data.Common.DataColumnMapping("FIBUKonto", "FIBUKonto"),
                        new System.Data.Common.DataColumnMapping("RollungVon", "RollungVon"),
                        new System.Data.Common.DataColumnMapping("RollungBis", "RollungBis"),
                        new System.Data.Common.DataColumnMapping("Adelstitel", "Adelstitel"),
                        new System.Data.Common.DataColumnMapping("Anrede", "Anrede"),
                        new System.Data.Common.DataColumnMapping("Initialberuehrung", "Initialberuehrung"),
                        new System.Data.Common.DataColumnMapping("Klingeln", "Klingeln"),
                        new System.Data.Common.DataColumnMapping("Wohnsituation", "Wohnsituation"),
                        new System.Data.Common.DataColumnMapping("Haustier", "Haustier"),
                        new System.Data.Common.DataColumnMapping("LiftJN", "LiftJN"),
                        new System.Data.Common.DataColumnMapping("WohnungAbgemeldetJN", "WohnungAbgemeldetJN"),
                        new System.Data.Common.DataColumnMapping("Haarfarbe", "Haarfarbe"),
                        new System.Data.Common.DataColumnMapping("Augenfarbe", "Augenfarbe"),
                        new System.Data.Common.DataColumnMapping("BesondereAeusserlicheKennzeichen", "BesondereAeusserlicheKennzeichen"),
                        new System.Data.Common.DataColumnMapping("FernsehgebuehrbefreiungJN", "FernsehgebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("TelefongebuehrbefreiungJN", "TelefongebuehrbefreiungJN"),
                        new System.Data.Common.DataColumnMapping("BewerberJN", "BewerberJN"),
                        new System.Data.Common.DataColumnMapping("BewerbungaktivJN", "BewerbungaktivJN"),
                        new System.Data.Common.DataColumnMapping("PflegeArt", "PflegeArt"),
                        new System.Data.Common.DataColumnMapping("BewerbungDatum", "BewerbungDatum"),
                        new System.Data.Common.DataColumnMapping("EinzugswunschDatum", "EinzugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("AuszugswunschDatum", "AuszugswunschDatum"),
                        new System.Data.Common.DataColumnMapping("Zimmerwunsch", "Zimmerwunsch"),
                        new System.Data.Common.DataColumnMapping("Stationswunsch", "Stationswunsch"),
                        new System.Data.Common.DataColumnMapping("SonstigeWuensche", "SonstigeWuensche"),
                        new System.Data.Common.DataColumnMapping("BewerbungsGrund", "BewerbungsGrund"),
                        new System.Data.Common.DataColumnMapping("Prioritaet", "Prioritaet"),
                        new System.Data.Common.DataColumnMapping("ReligionWunsch", "ReligionWunsch"),
                        new System.Data.Common.DataColumnMapping("KommunionJN", "KommunionJN"),
                        new System.Data.Common.DataColumnMapping("KrankensalbungJN", "KrankensalbungJN"),
                        new System.Data.Common.DataColumnMapping("BewerberBemerkung", "BewerberBemerkung"),
                        new System.Data.Common.DataColumnMapping("WaescheMarkiert", "WaescheMarkiert"),
                        new System.Data.Common.DataColumnMapping("WaescheWaschen", "WaescheWaschen"),
                        new System.Data.Common.DataColumnMapping("Zustaendige_Stelle", "Zustaendige_Stelle"),
                        new System.Data.Common.DataColumnMapping("Groesse", "Groesse"),
                        new System.Data.Common.DataColumnMapping("Statur", "Statur"),
                        new System.Data.Common.DataColumnMapping("Namenstag", "Namenstag"),
                        new System.Data.Common.DataColumnMapping("Kosename", "Kosename"),
                        new System.Data.Common.DataColumnMapping("Privatversicherung", "Privatversicherung"),
                        new System.Data.Common.DataColumnMapping("PrivPolNr", "PrivPolNr"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("PatientenverfuegungJN", "PatientenverfuegungJN"),
                        new System.Data.Common.DataColumnMapping("PatientenverfuegungBeachtlichJN", "PatientenverfuegungBeachtlichJN"),
                        new System.Data.Common.DataColumnMapping("PatientverfuegungDatum", "PatientverfuegungDatum"),
                        new System.Data.Common.DataColumnMapping("PatientverfuegungAnmerkung", "PatientverfuegungAnmerkung"),
                        new System.Data.Common.DataColumnMapping("Klientennummer", "Klientennummer"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Kennwort", "Kennwort"),
                        new System.Data.Common.DataColumnMapping("Verstorben", "Verstorben"),
                        new System.Data.Common.DataColumnMapping("Todeszeitpunkt", "Todeszeitpunkt"),
                        new System.Data.Common.DataColumnMapping("DNR", "DNR"),
                        new System.Data.Common.DataColumnMapping("abwesenheitenHändBerech", "abwesenheitenHändBerech"),
                        new System.Data.Common.DataColumnMapping("Sollstand", "Sollstand"),
                        new System.Data.Common.DataColumnMapping("minSaldo", "minSaldo"),
                        new System.Data.Common.DataColumnMapping("blob_Einverständniserklärung", "blob_Einverständniserklärung"),
                        new System.Data.Common.DataColumnMapping("EinverständniserklärungFileType", "EinverständniserklärungFileType"),
                        new System.Data.Common.DataColumnMapping("jpg_Einverständniserklärung", "jpg_Einverständniserklärung"),
                        new System.Data.Common.DataColumnMapping("Milieubetreuung", "Milieubetreuung"),
                        new System.Data.Common.DataColumnMapping("KZUeberlebender", "KZUeberlebender"),
                        new System.Data.Common.DataColumnMapping("Anatomie", "Anatomie"),
                        new System.Data.Common.DataColumnMapping("Einzelzimmer", "Einzelzimmer"),
                        new System.Data.Common.DataColumnMapping("Selbstzahler", "Selbstzahler"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("KürzungLetzterTagAnwesenheit", "KürzungLetzterTagAnwesenheit"),
                        new System.Data.Common.DataColumnMapping("Behindertenausweis", "Behindertenausweis"),
                        new System.Data.Common.DataColumnMapping("Sozialcard", "Sozialcard"),
                        new System.Data.Common.DataColumnMapping("IDAdresseSub", "IDAdresseSub"),
                        new System.Data.Common.DataColumnMapping("IDKontaktSub", "IDKontaktSub")})});
            this.daPatient.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT     ID, IDPatient, IDAdresse, IDKontakt, Titel, Nachname, Vorname, Sachwal" +
    "terJN, Belange, Von, Bis, Gericht, BestimmtAm, Bemerkung\r\nFROM         Sachwalte" +
    "r\r\nWHERE     (IDPatient = ?)";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = resources.GetString("oleDbInsertCommand3.CommandText");
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("SachwalterJN", System.Data.OleDb.OleDbType.Boolean, 0, "SachwalterJN"),
            new System.Data.OleDb.OleDbParameter("Belange", System.Data.OleDb.OleDbType.VarChar, 0, "Belange"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Gericht", System.Data.OleDb.OleDbType.VarChar, 0, "Gericht"),
            new System.Data.OleDb.OleDbParameter("BestimmtAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BestimmtAm"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = resources.GetString("oleDbUpdateCommand3.CommandText");
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("SachwalterJN", System.Data.OleDb.OleDbType.Boolean, 0, "SachwalterJN"),
            new System.Data.OleDb.OleDbParameter("Belange", System.Data.OleDb.OleDbType.VarChar, 0, "Belange"),
            new System.Data.OleDb.OleDbParameter("Von", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Von"),
            new System.Data.OleDb.OleDbParameter("Bis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Bis"),
            new System.Data.OleDb.OleDbParameter("Gericht", System.Data.OleDb.OleDbType.VarChar, 0, "Gericht"),
            new System.Data.OleDb.OleDbParameter("BestimmtAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BestimmtAm"),
            new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Bemerkung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [Sachwalter] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daSachwalterByPatient
            // 
            this.daSachwalterByPatient.DeleteCommand = this.oleDbDeleteCommand3;
            this.daSachwalterByPatient.InsertCommand = this.oleDbInsertCommand3;
            this.daSachwalterByPatient.SelectCommand = this.oleDbSelectCommand3;
            this.daSachwalterByPatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Sachwalter", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("SachwalterJN", "SachwalterJN"),
                        new System.Data.Common.DataColumnMapping("Belange", "Belange"),
                        new System.Data.Common.DataColumnMapping("Von", "Von"),
                        new System.Data.Common.DataColumnMapping("Bis", "Bis"),
                        new System.Data.Common.DataColumnMapping("Gericht", "Gericht"),
                        new System.Data.Common.DataColumnMapping("BestimmtAm", "BestimmtAm"),
                        new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung")})});
            this.daSachwalterByPatient.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT     ID, IDPatient, IDAdresse, IDKontakt, Titel, Nachname, Vorname, Verstae" +
    "ndigenJN, Kontaktart, Verwandtschaft, ExternerDienstleisterJN\r\nFROM         Kont" +
    "aktperson\r\nWHERE     (IDPatient = ?)";
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbInsertCommand4
            // 
            this.oleDbInsertCommand4.CommandText = resources.GetString("oleDbInsertCommand4.CommandText");
            this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("VerstaendigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerstaendigenJN"),
            new System.Data.OleDb.OleDbParameter("Kontaktart", System.Data.OleDb.OleDbType.VarChar, 0, "Kontaktart"),
            new System.Data.OleDb.OleDbParameter("Verwandtschaft", System.Data.OleDb.OleDbType.VarChar, 0, "Verwandtschaft"),
            new System.Data.OleDb.OleDbParameter("ExternerDienstleisterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ExternerDienstleisterJN")});
            // 
            // oleDbUpdateCommand4
            // 
            this.oleDbUpdateCommand4.CommandText = resources.GetString("oleDbUpdateCommand4.CommandText");
            this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("VerstaendigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerstaendigenJN"),
            new System.Data.OleDb.OleDbParameter("Kontaktart", System.Data.OleDb.OleDbType.VarChar, 0, "Kontaktart"),
            new System.Data.OleDb.OleDbParameter("Verwandtschaft", System.Data.OleDb.OleDbType.VarChar, 0, "Verwandtschaft"),
            new System.Data.OleDb.OleDbParameter("ExternerDienstleisterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ExternerDienstleisterJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand4
            // 
            this.oleDbDeleteCommand4.CommandText = "DELETE FROM [Kontaktperson] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daKontaktPBypatient
            // 
            this.daKontaktPBypatient.DeleteCommand = this.oleDbDeleteCommand4;
            this.daKontaktPBypatient.InsertCommand = this.oleDbInsertCommand4;
            this.daKontaktPBypatient.SelectCommand = this.oleDbSelectCommand4;
            this.daKontaktPBypatient.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Kontaktperson", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Titel", "Titel"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("VerstaendigenJN", "VerstaendigenJN"),
                        new System.Data.Common.DataColumnMapping("Kontaktart", "Kontaktart"),
                        new System.Data.Common.DataColumnMapping("Verwandtschaft", "Verwandtschaft"),
                        new System.Data.Common.DataColumnMapping("ExternerDienstleisterJN", "ExternerDienstleisterJN")})});
            this.daKontaktPBypatient.UpdateCommand = this.oleDbUpdateCommand4;
            // 
            // dsSachwalter1
            // 
            this.dsSachwalter1.DataSetName = "dsSachwalter";
            this.dsSachwalter1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsKontaktpersonen
            // 
            this.dsKontaktpersonen.DataSetName = "dsKontaktpersonen";
            this.dsKontaktpersonen.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsDienstleister
            // 
            this.dsDienstleister.DataSetName = "dsKontaktpersonen";
            this.dsDienstleister.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsKlient1
            // 
            this.dsKlient1.DataSetName = "dsKlient";
            this.dsKlient1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = resources.GetString("oleDbInsertCommand.CommandText");
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Geburtsdatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Geburtsdatum"),
            new System.Data.OleDb.OleDbParameter("Titel", System.Data.OleDb.OleDbType.VarChar, 0, "Titel"),
            new System.Data.OleDb.OleDbParameter("Sexus", System.Data.OleDb.OleDbType.VarChar, 0, "Sexus"),
            new System.Data.OleDb.OleDbParameter("Konfision", System.Data.OleDb.OleDbType.VarChar, 0, "Konfision"),
            new System.Data.OleDb.OleDbParameter("Familienstand", System.Data.OleDb.OleDbType.VarChar, 0, "Familienstand"),
            new System.Data.OleDb.OleDbParameter("Staatsb", System.Data.OleDb.OleDbType.VarChar, 0, "Staatsb"),
            new System.Data.OleDb.OleDbParameter("Klasse", System.Data.OleDb.OleDbType.VarChar, 0, "Klasse"),
            new System.Data.OleDb.OleDbParameter("KrankenKasse", System.Data.OleDb.OleDbType.VarChar, 0, "KrankenKasse"),
            new System.Data.OleDb.OleDbParameter("BlutGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "BlutGruppe"),
            new System.Data.OleDb.OleDbParameter("Resusfaktor", System.Data.OleDb.OleDbType.VarChar, 0, "Resusfaktor"),
            new System.Data.OleDb.OleDbParameter("LedigerName", System.Data.OleDb.OleDbType.VarChar, 0, "LedigerName"),
            new System.Data.OleDb.OleDbParameter("Geburtsort", System.Data.OleDb.OleDbType.VarChar, 0, "Geburtsort"),
            new System.Data.OleDb.OleDbParameter("Voraufenthalt", System.Data.OleDb.OleDbType.VarChar, 0, "Voraufenthalt"),
            new System.Data.OleDb.OleDbParameter("Angehörige", System.Data.OleDb.OleDbType.LongVarChar, 0, "Angehörige"),
            new System.Data.OleDb.OleDbParameter("VersicherungsNr", System.Data.OleDb.OleDbType.VarChar, 0, "VersicherungsNr"),
            new System.Data.OleDb.OleDbParameter("ArbeitslosBezSeit", System.Data.OleDb.OleDbType.VarChar, 0, "ArbeitslosBezSeit"),
            new System.Data.OleDb.OleDbParameter("KrankengeldSeit", System.Data.OleDb.OleDbType.VarChar, 0, "KrankengeldSeit"),
            new System.Data.OleDb.OleDbParameter("Hauptversicherung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hauptversicherung"),
            new System.Data.OleDb.OleDbParameter("ErlernterBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "ErlernterBeruf"),
            new System.Data.OleDb.OleDbParameter("Besonderheit", System.Data.OleDb.OleDbType.LongVarChar, 0, "Besonderheit"),
            new System.Data.OleDb.OleDbParameter("Betreuer", System.Data.OleDb.OleDbType.LongVarChar, 0, "Betreuer"),
            new System.Data.OleDb.OleDbParameter("Sachwalter", System.Data.OleDb.OleDbType.LongVarChar, 0, "Sachwalter"),
            new System.Data.OleDb.OleDbParameter("SachWalterBelange", System.Data.OleDb.OleDbType.VarChar, 0, "SachWalterBelange"),
            new System.Data.OleDb.OleDbParameter("SachWalterVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterVon"),
            new System.Data.OleDb.OleDbParameter("SachWalterBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SachWalterBis"),
            new System.Data.OleDb.OleDbParameter("SterbeRegel", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbeRegel"),
            new System.Data.OleDb.OleDbParameter("Depotinjektion", System.Data.OleDb.OleDbType.VarChar, 0, "Depotinjektion"),
            new System.Data.OleDb.OleDbParameter("Hausarzt", System.Data.OleDb.OleDbType.LongVarChar, 0, "Hausarzt"),
            new System.Data.OleDb.OleDbParameter("Vermerk", System.Data.OleDb.OleDbType.LongVarChar, 0, "Vermerk"),
            new System.Data.OleDb.OleDbParameter("SterbeDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "SterbeDatum"),
            new System.Data.OleDb.OleDbParameter("AktuellerDienstgeber", System.Data.OleDb.OleDbType.VarChar, 0, "AktuellerDienstgeber"),
            new System.Data.OleDb.OleDbParameter("DerzeitigerBeruf", System.Data.OleDb.OleDbType.VarChar, 0, "DerzeitigerBeruf"),
            new System.Data.OleDb.OleDbParameter("RezeptgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "RezeptgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("PflegegeldantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegegeldantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPflegegeldantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPflegegeldantrag"),
            new System.Data.OleDb.OleDbParameter("PensionsteilungsantragJN", System.Data.OleDb.OleDbType.Boolean, 0, "PensionsteilungsantragJN"),
            new System.Data.OleDb.OleDbParameter("DatumPensionsteilungsantrag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "DatumPensionsteilungsantrag"),
            new System.Data.OleDb.OleDbParameter("FIBUKonto", System.Data.OleDb.OleDbType.VarChar, 0, "FIBUKonto"),
            new System.Data.OleDb.OleDbParameter("RollungVon", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungVon"),
            new System.Data.OleDb.OleDbParameter("RollungBis", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "RollungBis"),
            new System.Data.OleDb.OleDbParameter("Adelstitel", System.Data.OleDb.OleDbType.VarChar, 0, "Adelstitel"),
            new System.Data.OleDb.OleDbParameter("Anrede", System.Data.OleDb.OleDbType.VarChar, 0, "Anrede"),
            new System.Data.OleDb.OleDbParameter("Initialberuehrung", System.Data.OleDb.OleDbType.VarChar, 0, "Initialberuehrung"),
            new System.Data.OleDb.OleDbParameter("Klingeln", System.Data.OleDb.OleDbType.VarChar, 0, "Klingeln"),
            new System.Data.OleDb.OleDbParameter("Wohnsituation", System.Data.OleDb.OleDbType.VarChar, 0, "Wohnsituation"),
            new System.Data.OleDb.OleDbParameter("Haustier", System.Data.OleDb.OleDbType.VarChar, 0, "Haustier"),
            new System.Data.OleDb.OleDbParameter("LiftJN", System.Data.OleDb.OleDbType.Boolean, 0, "LiftJN"),
            new System.Data.OleDb.OleDbParameter("WohnungAbgemeldetJN", System.Data.OleDb.OleDbType.Boolean, 0, "WohnungAbgemeldetJN"),
            new System.Data.OleDb.OleDbParameter("Haarfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Haarfarbe"),
            new System.Data.OleDb.OleDbParameter("Augenfarbe", System.Data.OleDb.OleDbType.VarChar, 0, "Augenfarbe"),
            new System.Data.OleDb.OleDbParameter("BesondereAeusserlicheKennzeichen", System.Data.OleDb.OleDbType.VarChar, 0, "BesondereAeusserlicheKennzeichen"),
            new System.Data.OleDb.OleDbParameter("FernsehgebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "FernsehgebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("TelefongebuehrbefreiungJN", System.Data.OleDb.OleDbType.Boolean, 0, "TelefongebuehrbefreiungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerberJN"),
            new System.Data.OleDb.OleDbParameter("BewerbungaktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewerbungaktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegeArt", System.Data.OleDb.OleDbType.VarChar, 0, "PflegeArt"),
            new System.Data.OleDb.OleDbParameter("BewerbungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "BewerbungDatum"),
            new System.Data.OleDb.OleDbParameter("EinzugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EinzugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("AuszugswunschDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AuszugswunschDatum"),
            new System.Data.OleDb.OleDbParameter("Zimmerwunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Zimmerwunsch"),
            new System.Data.OleDb.OleDbParameter("Stationswunsch", System.Data.OleDb.OleDbType.VarChar, 0, "Stationswunsch"),
            new System.Data.OleDb.OleDbParameter("SonstigeWuensche", System.Data.OleDb.OleDbType.VarChar, 0, "SonstigeWuensche"),
            new System.Data.OleDb.OleDbParameter("BewerbungsGrund", System.Data.OleDb.OleDbType.VarChar, 0, "BewerbungsGrund"),
            new System.Data.OleDb.OleDbParameter("Prioritaet", System.Data.OleDb.OleDbType.VarChar, 0, "Prioritaet"),
            new System.Data.OleDb.OleDbParameter("ReligionWunsch", System.Data.OleDb.OleDbType.VarChar, 0, "ReligionWunsch"),
            new System.Data.OleDb.OleDbParameter("KommunionJN", System.Data.OleDb.OleDbType.Boolean, 0, "KommunionJN"),
            new System.Data.OleDb.OleDbParameter("KrankensalbungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KrankensalbungJN"),
            new System.Data.OleDb.OleDbParameter("BewerberBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "BewerberBemerkung"),
            new System.Data.OleDb.OleDbParameter("WaescheMarkiert", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheMarkiert"),
            new System.Data.OleDb.OleDbParameter("WaescheWaschen", System.Data.OleDb.OleDbType.VarChar, 0, "WaescheWaschen"),
            new System.Data.OleDb.OleDbParameter("Zustaendige_Stelle", System.Data.OleDb.OleDbType.VarChar, 0, "Zustaendige_Stelle"),
            new System.Data.OleDb.OleDbParameter("Groesse", System.Data.OleDb.OleDbType.Integer, 0, "Groesse"),
            new System.Data.OleDb.OleDbParameter("Statur", System.Data.OleDb.OleDbType.VarChar, 0, "Statur"),
            new System.Data.OleDb.OleDbParameter("Namenstag", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Namenstag"),
            new System.Data.OleDb.OleDbParameter("Kosename", System.Data.OleDb.OleDbType.VarChar, 0, "Kosename"),
            new System.Data.OleDb.OleDbParameter("Privatversicherung", System.Data.OleDb.OleDbType.VarChar, 0, "Privatversicherung"),
            new System.Data.OleDb.OleDbParameter("PrivPolNr", System.Data.OleDb.OleDbType.VarChar, 0, "PrivPolNr"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungJN"),
            new System.Data.OleDb.OleDbParameter("PatientenverfuegungBeachtlichJN", System.Data.OleDb.OleDbType.Boolean, 0, "PatientenverfuegungBeachtlichJN"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "PatientverfuegungDatum"),
            new System.Data.OleDb.OleDbParameter("PatientverfuegungAnmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "PatientverfuegungAnmerkung"),
            new System.Data.OleDb.OleDbParameter("Klientennummer", System.Data.OleDb.OleDbType.VarChar, 0, "Klientennummer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Kennwort", System.Data.OleDb.OleDbType.VarChar, 0, "Kennwort"),
            new System.Data.OleDb.OleDbParameter("Verstorben", System.Data.OleDb.OleDbType.Boolean, 0, "Verstorben"),
            new System.Data.OleDb.OleDbParameter("Todeszeitpunkt", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Todeszeitpunkt"),
            new System.Data.OleDb.OleDbParameter("DNR", System.Data.OleDb.OleDbType.Boolean, 0, "DNR"),
            new System.Data.OleDb.OleDbParameter("abwesenheitenHändBerech", System.Data.OleDb.OleDbType.Boolean, 0, "abwesenheitenHändBerech"),
            new System.Data.OleDb.OleDbParameter("Sollstand", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "Sollstand", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("minSaldo", System.Data.OleDb.OleDbType.Numeric, 0, System.Data.ParameterDirection.Input, false, ((byte)(18)), ((byte)(3)), "minSaldo", System.Data.DataRowVersion.Current, null),
            new System.Data.OleDb.OleDbParameter("blob_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "blob_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("EinverständniserklärungFileType", System.Data.OleDb.OleDbType.VarWChar, 0, "EinverständniserklärungFileType"),
            new System.Data.OleDb.OleDbParameter("jpg_Einverständniserklärung", System.Data.OleDb.OleDbType.LongVarBinary, 0, "jpg_Einverständniserklärung"),
            new System.Data.OleDb.OleDbParameter("Milieubetreuung", System.Data.OleDb.OleDbType.Boolean, 0, "Milieubetreuung"),
            new System.Data.OleDb.OleDbParameter("KZUeberlebender", System.Data.OleDb.OleDbType.Boolean, 0, "KZUeberlebender"),
            new System.Data.OleDb.OleDbParameter("Anatomie", System.Data.OleDb.OleDbType.Boolean, 0, "Anatomie"),
            new System.Data.OleDb.OleDbParameter("Einzelzimmer", System.Data.OleDb.OleDbType.Boolean, 0, "Einzelzimmer"),
            new System.Data.OleDb.OleDbParameter("Selbstzahler", System.Data.OleDb.OleDbType.Boolean, 0, "Selbstzahler"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("KürzungLetzterTagAnwesenheit", System.Data.OleDb.OleDbType.Boolean, 0, "KürzungLetzterTagAnwesenheit"),
            new System.Data.OleDb.OleDbParameter("Behindertenausweis", System.Data.OleDb.OleDbType.Boolean, 0, "Behindertenausweis"),
            new System.Data.OleDb.OleDbParameter("Sozialcard", System.Data.OleDb.OleDbType.Boolean, 0, "Sozialcard"),
            new System.Data.OleDb.OleDbParameter("IDAdresseSub", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresseSub"),
            new System.Data.OleDb.OleDbParameter("IDKontaktSub", System.Data.OleDb.OleDbType.Guid, 0, "IDKontaktSub")});
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktperson1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlientSachwalter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSachwalter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKontaktpersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsDienstleister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsKlient1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsKlient dsKlient1;
        private dsKontaktperson dsKontaktperson1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private System.Data.OleDb.OleDbDataAdapter daArztByAufenthalt;
        private dsKlientSachwalter dsKlientSachwalter1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPatient;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private System.Data.OleDb.OleDbDataAdapter daSachwalterByPatient;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
        private System.Data.OleDb.OleDbDataAdapter daKontaktPBypatient;
        private dsSachwalter dsSachwalter1;
        private dsKontaktpersonen dsKontaktpersonen;
        private dsKontaktpersonen dsDienstleister;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand;
    }
}
