//----------------------------------------------------------------------------
/// <summary>
///	DBBenutzer.cs
/// Erstellt am:	14.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;
//lthArztabrechnung  daBenutzer neu generieren mit ArztabrechnungJN und dsBenutzer nachziehen



namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Benutzerinformationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBBenutzer : DBBaseEntries, IDBBaseEntries
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daBenutzerByID;
		private System.Data.OleDb.OleDbDataAdapter daBenutzerListe;
        private PMDS.Global.db.Global.dsBenutzer dsBenutzer1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private dsBenutzerGruppe dsBenutzerGruppe1;
        private System.Data.OleDb.OleDbDataAdapter daBenutzerGruppeByBenutzer;
        public OleDbDataAdapter daBenutzerAbteilungByBenutzer;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
        private dsBenutzerAbteilung dsBenutzerAbteilung1;
		private System.Data.OleDb.OleDbDataAdapter daPflegerListe;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private OleDbDataAdapter daPflegerByAbteilung;
        private OleDbCommand oleDbCommand2;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBBenutzer()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBBenutzer));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daBenutzerListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daBenutzerByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsBenutzer1 = new PMDS.Global.db.Global.dsBenutzer();
            this.daBenutzerGruppeByBenutzer = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsBenutzerGruppe1 = new PMDS.Global.db.Global.dsBenutzerGruppe();
            this.daBenutzerAbteilungByBenutzer = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsBenutzerAbteilung1 = new PMDS.Global.db.Global.dsBenutzerAbteilung();
            this.daPflegerListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegerByAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerGruppe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerAbteilung1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // daBenutzerListe
            // 
            this.daBenutzerListe.SelectCommand = this.oleDbSelectCommand1;
            this.daBenutzerListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Benutzer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, Benutzer + \' - \' + Nachname + \' \' + Vorname AS TEXT FROM Benutzer ORDE" +
    "R BY AktivJN desc, Benutzer";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daBenutzerByID
            // 
            this.daBenutzerByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daBenutzerByID.InsertCommand = this.oleDbInsertCommand2;
            this.daBenutzerByID.SelectCommand = this.oleDbSelectCommand2;
            this.daBenutzerByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Benutzer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
                        new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
                        new System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"),
                        new System.Data.Common.DataColumnMapping("Passwort", "Passwort"),
                        new System.Data.Common.DataColumnMapping("AktivJN", "AktivJN"),
                        new System.Data.Common.DataColumnMapping("PflegerJN", "PflegerJN"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID"),
                        new System.Data.Common.DataColumnMapping("Eintrittsdatum", "Eintrittsdatum"),
                        new System.Data.Common.DataColumnMapping("Austrittsdatum", "Austrittsdatum"),
                        new System.Data.Common.DataColumnMapping("smtpSrv", "smtpSrv"),
                        new System.Data.Common.DataColumnMapping("smtpPort", "smtpPort"),
                        new System.Data.Common.DataColumnMapping("smtpAbsender", "smtpAbsender"),
                        new System.Data.Common.DataColumnMapping("smtpPwd", "smtpPwd"),
                        new System.Data.Common.DataColumnMapping("smtpAuthentStandard", "smtpAuthentStandard"),
                        new System.Data.Common.DataColumnMapping("IsGeneric", "IsGeneric"),
                        new System.Data.Common.DataColumnMapping("IDArzt", "IDArzt"),
                        new System.Data.Common.DataColumnMapping("ArztabrechnungJN", "ArztabrechnungJN"),
                        new System.Data.Common.DataColumnMapping("Signatur", "Signatur"),
                        new System.Data.Common.DataColumnMapping("ELGAUser", "ELGAUser"),
                        new System.Data.Common.DataColumnMapping("ELGAPatID", "ELGAPatID"),
                        new System.Data.Common.DataColumnMapping("ELGAActive", "ELGAActive"),
                        new System.Data.Common.DataColumnMapping("ELGAAutoLogin", "ELGAAutoLogin"),
                        new System.Data.Common.DataColumnMapping("ELGAAutostartSession", "ELGAAutostartSession"),
                        new System.Data.Common.DataColumnMapping("ELGAValidTrough", "ELGAValidTrough"),
                        new System.Data.Common.DataColumnMapping("ELGA_AuthorSpeciality", "ELGA_AuthorSpeciality")})});
            this.daBenutzerByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Benutzer] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"),
            new System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegerJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegerJN"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Eintrittsdatum", System.Data.OleDb.OleDbType.Date, 16, "Eintrittsdatum"),
            new System.Data.OleDb.OleDbParameter("Austrittsdatum", System.Data.OleDb.OleDbType.Date, 16, "Austrittsdatum"),
            new System.Data.OleDb.OleDbParameter("smtpSrv", System.Data.OleDb.OleDbType.VarChar, 0, "smtpSrv"),
            new System.Data.OleDb.OleDbParameter("smtpPort", System.Data.OleDb.OleDbType.Integer, 0, "smtpPort"),
            new System.Data.OleDb.OleDbParameter("smtpAbsender", System.Data.OleDb.OleDbType.VarChar, 0, "smtpAbsender"),
            new System.Data.OleDb.OleDbParameter("smtpPwd", System.Data.OleDb.OleDbType.VarChar, 0, "smtpPwd"),
            new System.Data.OleDb.OleDbParameter("smtpAuthentStandard", System.Data.OleDb.OleDbType.Boolean, 0, "smtpAuthentStandard"),
            new System.Data.OleDb.OleDbParameter("IsGeneric", System.Data.OleDb.OleDbType.Boolean, 0, "IsGeneric"),
            new System.Data.OleDb.OleDbParameter("IDArzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArzt"),
            new System.Data.OleDb.OleDbParameter("ArztabrechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ArztabrechnungJN"),
            new System.Data.OleDb.OleDbParameter("Signatur", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Signatur"),
            new System.Data.OleDb.OleDbParameter("ELGAUser", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGAUser"),
            new System.Data.OleDb.OleDbParameter("ELGAPatID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGAPatID"),
            new System.Data.OleDb.OleDbParameter("ELGAActive", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAActive"),
            new System.Data.OleDb.OleDbParameter("ELGAAutoLogin", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAutoLogin"),
            new System.Data.OleDb.OleDbParameter("ELGAAutostartSession", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAutostartSession"),
            new System.Data.OleDb.OleDbParameter("ELGAValidTrough", System.Data.OleDb.OleDbType.Date, 16, "ELGAValidTrough"),
            new System.Data.OleDb.OleDbParameter("ELGA_AuthorSpeciality", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_AuthorSpeciality")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarChar, 0, "Vorname"),
            new System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarChar, 0, "Nachname"),
            new System.Data.OleDb.OleDbParameter("Benutzer", System.Data.OleDb.OleDbType.VarChar, 0, "Benutzer"),
            new System.Data.OleDb.OleDbParameter("Passwort", System.Data.OleDb.OleDbType.VarChar, 0, "Passwort"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN"),
            new System.Data.OleDb.OleDbParameter("PflegerJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflegerJN"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("Eintrittsdatum", System.Data.OleDb.OleDbType.Date, 16, "Eintrittsdatum"),
            new System.Data.OleDb.OleDbParameter("Austrittsdatum", System.Data.OleDb.OleDbType.Date, 16, "Austrittsdatum"),
            new System.Data.OleDb.OleDbParameter("smtpSrv", System.Data.OleDb.OleDbType.VarChar, 0, "smtpSrv"),
            new System.Data.OleDb.OleDbParameter("smtpPort", System.Data.OleDb.OleDbType.Integer, 0, "smtpPort"),
            new System.Data.OleDb.OleDbParameter("smtpAbsender", System.Data.OleDb.OleDbType.VarChar, 0, "smtpAbsender"),
            new System.Data.OleDb.OleDbParameter("smtpPwd", System.Data.OleDb.OleDbType.VarChar, 0, "smtpPwd"),
            new System.Data.OleDb.OleDbParameter("smtpAuthentStandard", System.Data.OleDb.OleDbType.Boolean, 0, "smtpAuthentStandard"),
            new System.Data.OleDb.OleDbParameter("IsGeneric", System.Data.OleDb.OleDbType.Boolean, 0, "IsGeneric"),
            new System.Data.OleDb.OleDbParameter("IDArzt", System.Data.OleDb.OleDbType.Guid, 0, "IDArzt"),
            new System.Data.OleDb.OleDbParameter("ArztabrechnungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ArztabrechnungJN"),
            new System.Data.OleDb.OleDbParameter("Signatur", System.Data.OleDb.OleDbType.LongVarWChar, 0, "Signatur"),
            new System.Data.OleDb.OleDbParameter("ELGAUser", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGAUser"),
            new System.Data.OleDb.OleDbParameter("ELGAPatID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGAPatID"),
            new System.Data.OleDb.OleDbParameter("ELGAActive", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAActive"),
            new System.Data.OleDb.OleDbParameter("ELGAAutoLogin", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAutoLogin"),
            new System.Data.OleDb.OleDbParameter("ELGAAutostartSession", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAutostartSession"),
            new System.Data.OleDb.OleDbParameter("ELGAValidTrough", System.Data.OleDb.OleDbType.Date, 16, "ELGAValidTrough"),
            new System.Data.OleDb.OleDbParameter("ELGA_AuthorSpeciality", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_AuthorSpeciality"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsBenutzer1
            // 
            this.dsBenutzer1.DataSetName = "dsBenutzer";
            this.dsBenutzer1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsBenutzer1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daBenutzerGruppeByBenutzer
            // 
            this.daBenutzerGruppeByBenutzer.DeleteCommand = this.oleDbDeleteCommand1;
            this.daBenutzerGruppeByBenutzer.InsertCommand = this.oleDbInsertCommand1;
            this.daBenutzerGruppeByBenutzer.SelectCommand = this.oleDbSelectCommand3;
            this.daBenutzerGruppeByBenutzer.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "BenutzerGruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDGruppe", "IDGruppe")})});
            this.daBenutzerGruppeByBenutzer.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM BenutzerGruppe WHERE (IDBenutzer = ?) AND (IDGruppe = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDGruppe", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO BenutzerGruppe(IDBenutzer, IDGruppe) VALUES (?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT IDBenutzer, IDGruppe FROM BenutzerGruppe WHERE (IDBenutzer = ?)";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE BenutzerGruppe SET IDBenutzer = ?, IDGruppe = ? WHERE (IDBenutzer = ?) AND" +
    " (IDGruppe = ?)";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDGruppe"),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDGruppe", System.Data.DataRowVersion.Original, null)});
            // 
            // dsBenutzerGruppe1
            // 
            this.dsBenutzerGruppe1.DataSetName = "dsBenutzerGruppe";
            this.dsBenutzerGruppe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsBenutzerGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daBenutzerAbteilungByBenutzer
            // 
            this.daBenutzerAbteilungByBenutzer.DeleteCommand = this.oleDbDeleteCommand3;
            this.daBenutzerAbteilungByBenutzer.InsertCommand = this.oleDbInsertCommand3;
            this.daBenutzerAbteilungByBenutzer.SelectCommand = this.oleDbSelectCommand4;
            this.daBenutzerAbteilungByBenutzer.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "BenutzerAbteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung")})});
            this.daBenutzerAbteilungByBenutzer.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM BenutzerAbteilung WHERE (IDAbteilung = ?) AND (IDBenutzer = ?)";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO BenutzerAbteilung(IDBenutzer, IDAbteilung) VALUES (?, ?)";
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT IDBenutzer, IDAbteilung FROM BenutzerAbteilung WHERE (IDBenutzer = ?)";
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE BenutzerAbteilung SET IDBenutzer = ?, IDAbteilung = ? WHERE (IDAbteilung =" +
    " ?) AND (IDBenutzer = ?)";
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null)});
            // 
            // dsBenutzerAbteilung1
            // 
            this.dsBenutzerAbteilung1.DataSetName = "dsBenutzerAbteilung";
            this.dsBenutzerAbteilung1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsBenutzerAbteilung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPflegerListe
            // 
            this.daPflegerListe.SelectCommand = this.oleDbCommand1;
            this.daPflegerListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Benutzer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT ID, Benutzer + \' - \' + Nachname + \' \' + Vorname AS TEXT FROM Benutzer WHER" +
    "E (PflegerJN = 1) ORDER BY Benutzer";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // daPflegerByAbteilung
            // 
            this.daPflegerByAbteilung.SelectCommand = this.oleDbCommand2;
            this.daPflegerByAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Benutzer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerGruppe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsBenutzerAbteilung1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daBenutzerListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daBenutzerByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daSubEntries
		{
			get	{	return daBenutzerGruppeByBenutzer;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// ID setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public override object ID
		{
			get	{	return base.ID;		}
			set	
			{	
				base.ID = value;
				daBenutzerAbteilungByBenutzer.SelectCommand.Parameters[0].Value = value;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
    	    PMDS.Global.db.Global.dsBenutzer.BenutzerRow rBenutzer =	ITEM.AddBenutzerRow(Guid.NewGuid(), Guid.Empty, Guid.Empty, "", "", "",
				"", true, false, Guid.Empty, DateTime.Now,  DateTime.Now, "", -1, "", "", false, false, Guid.Empty, false, "", "", "", false, false, false, DateTime.Now, "");
			SUBITEMS.Clear();
			SUBITEMS2.Clear();
            rBenutzer.SetIDArztNull();
            rBenutzer.SetEintrittsdatumNull();
            rBenutzer.SetAustrittsdatumNull();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerGruppe.BenutzerGruppeRow NewEntry()
		{
			return SUBITEMS.AddBenutzerGruppeRow(ITEM[0].ID, Guid.Empty);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag2 erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerAbteilung.BenutzerAbteilungRow NewEntry2()
		{
			return SUBITEMS2.AddBenutzerAbteilungRow(ITEM[0].ID, Guid.Empty);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einträge neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public override void Read()
		{
			base.Read();
			SUBITEMS2.Clear();
			DataBase.Fill(daBenutzerAbteilungByBenutzer, SUBITEMS2);
		}


        public void getAbteilungByUser(dsBenutzerAbteilung ds, System.Guid IDBenutzer)
        {
            daBenutzerAbteilungByBenutzer.SelectCommand.Parameters[0].Value = IDBenutzer;
            DataBase.Fill(daBenutzerAbteilungByBenutzer, ds.BenutzerAbteilung);
        }
        public void getAllBenutzerOrderByAktiv(dsGUIDListe ds)
        {
            DataBase.Fill(this.daBenutzerListe, ds.IDListe);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Abgleich der Daten mit Datenbank.
        /// </summary>
        //----------------------------------------------------------------------------
        public override void Write()
		{
			base.Write();
			DataBase.Update(daBenutzerAbteilungByBenutzer, SUBITEMS2);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual PMDS.Global.db.Global.dsBenutzer.BenutzerDataTable ITEM
		{
			get	{	return dsBenutzer1.Benutzer;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// BenutzerGruppen DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerGruppe.BenutzerGruppeDataTable SUBITEMS
		{
			get	{	return dsBenutzerGruppe1.BenutzerGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// benutzerAbteilungen DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerAbteilung.BenutzerAbteilungDataTable SUBITEMS2
		{
			get	{	return dsBenutzerAbteilung1.BenutzerAbteilung;	}
		}

		#region IDBBase & IDBBaseEntries Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		DataRow IDBBaseEntries.NewEntry()
		{
			return this.NewEntry();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBaseEntries.SUBITEMS
		{
			get	{	return this.SUBITEMS;	}
		}

		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die User ID
		/// </summary> 
		//----------------------------------------------------------------------------
		public static object UserID(string user) 
		{
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT ID FROM Benutzer WHERE (Benutzer = ?)";
                cmd.Parameters.AddWithValue("BENUTZER", user);

                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    return r[0];
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("UserID: " + ex.ToString());
            }
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// LIste aller Pfleger
		/// </summary> 
		//----------------------------------------------------------------------------
		public dsGUIDListe.IDListeDataTable AllPfleger()
		{
			dsGUIDListe ds = new dsGUIDListe();
			DataBase.Fill(daPflegerListe, ds.IDListe);
			return ds.IDListe;
		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// LIste aller Pfleger einer Abteilung
        /// </summary> 
        //----------------------------------------------------------------------------
        public dsGUIDListe.IDListeDataTable AllPfleger(Guid IDAbteilung)
        {
            dsGUIDListe ds = new dsGUIDListe();
            daPflegerByAbteilung.SelectCommand.Parameters[0].Value = IDAbteilung;
            DataBase.Fill(daPflegerByAbteilung, ds.IDListe);
            return ds.IDListe;
        }
        
        public bool updateSMTPAngaben(Guid IDBenutzer, string smtpSrv, int  smtpPort, string smtpAbsender, string smtpPwd, Boolean smtpAuthentStandard)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBase.CONNECTION;
            cmd.CommandText = "UPDATE Benutzer   SET  smtpSrv = ?, smtpPort = ?, smtpAbsender = ?, smtpPwd = ?, smtpAuthentStandard = ?  WHERE ID = ? ";
            cmd.Parameters.Add("smtpSrv", System.Data.OleDb.OleDbType.VarChar, 150, "smtpSrv").Value = smtpSrv;
            cmd.Parameters.Add("smtpPort", System.Data.OleDb.OleDbType.Integer , 4, "smtpPort").Value = smtpPort;
            cmd.Parameters.Add("smtpAbsender", System.Data.OleDb.OleDbType.VarChar, 150, "smtpAbsender").Value = smtpAbsender;
            cmd.Parameters.Add("smtpPwd", System.Data.OleDb.OleDbType.VarChar , 100, "smtpPwd").Value = smtpPwd;
            cmd.Parameters.Add("smtpAuthentStandard", System.Data.OleDb.OleDbType.Boolean , 1, "smtpAuthentStandard").Value = smtpAuthentStandard;
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDBenutzer;
            cmd.ExecuteNonQuery();
            return true;
        }

        public DataTable readSMTPAngaben( System.Guid IDBenutzer)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = DataBase.CONNECTION;
            cmd.CommandText = "Select   smtpSrv, smtpPort, smtpAbsender, smtpPwd, smtpAuthentStandard   from   Benutzer  WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDBenutzer;
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }
         
        public bool deletBenutzer(System.Guid IDBenutzer)
        {
            OleDbCommand cmd = new OleDbCommand();
            
            //DBAbteilung DBAbteilung1 = new DBAbteilung();
            //dsAbteilung dsAbteilung1 = new dsAbteilung();
            //DBAbteilung1.getAbteilungenByKlinik(rKlinik.ID, dsAbteilung1);
            //foreach (dsAbteilung.AbteilungRow rAbteilung in dsAbteilung1.Abteilung)
            //{
            //    DBKlinikBereiche DBKlinikBereiche1 = new DBKlinikBereiche();
            //    dsBereich.BereichDataTable tBereicheAbteilung = DBKlinikBereiche1.ByAbteilung(rAbteilung.ID);
            //    foreach (dsBereich.BereichRow rBereich in tBereicheAbteilung)
            //    {
            //        cmd = new OleDbCommand();
            //        cmd.Connection = RBU.DataBase.CONNECTION;
            //        cmd.CommandTimeout = 180;
            //        cmd.CommandText = " Delete from  Bereich  WHERE ID = ? ";
            //        cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rBereich.ID;
            //        cmd.ExecuteNonQuery();
            //    }

            //    cmd = new OleDbCommand();
            //    cmd.Connection = RBU.DataBase.CONNECTION;
            //    cmd.CommandTimeout = 180;
            //    cmd.CommandText = " Delete from  Abteilung  WHERE ID = ? ";
            //    cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rAbteilung.ID;
            //    cmd.ExecuteNonQuery();
            //}

            //cmd = new OleDbCommand();
            //cmd.Connection = RBU.DataBase.CONNECTION;
            //cmd.CommandTimeout = 180;
            //cmd.CommandText = " Delete from  Bank  WHERE ID = ? ";
            //cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = rKlinik.IDBank;
            //cmd.ExecuteNonQuery();

            cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandTimeout = 180;
            cmd.CommandText = " Delete from  Benutzer  WHERE ID = ? ";
            cmd.Parameters.Add("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDBenutzer;
            cmd.ExecuteNonQuery();

            return true;
        }

	}
}
