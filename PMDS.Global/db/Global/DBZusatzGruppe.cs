//----------------------------------------------------------------------------
/// <summary>
///	DBZusatzGruppe.cs
/// Erstellt am:	01.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die ZusatzGruppe.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBZusatzGruppe : DBBaseEntries, IDBBaseEntries
	{
		private bool _bUseAbteilung;
        private bool _bUseFilter;

		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzGruppeByID;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter daZusatzGruppeListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand6;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand4;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand4;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand4;
		private System.Data.OleDb.OleDbDataAdapter daZusatzByGruppe;
		private dsZusatzGruppeEintrag dsZusatzGruppeEintrag1;
		private dsZusatzGruppe dsZusatzGruppe1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzByGruppeAbteilung;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private OleDbDataAdapter daZusatzgruppeEintragByID;
        private OleDbCommand oleDbCommand5;
        private OleDbCommand oleDbCommand6;
        private OleDbCommand oleDbCommand7;
        private OleDbCommand oleDbCommand8;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBZusatzGruppe()
		{
			InitializeComponent();
            _bUseFilter = true;
			Filter		= Guid.Empty;
			UseAbteilung= false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBZusatzGruppe));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daZusatzGruppeByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzGruppeListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzByGruppe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand4 = new System.Data.OleDb.OleDbCommand();
            this.dsZusatzGruppeEintrag1 = new PMDS.Global.db.Global.dsZusatzGruppeEintrag();
            this.dsZusatzGruppe1 = new PMDS.Global.db.Global.dsZusatzGruppe();
            this.daZusatzByGruppeAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzgruppeEintragByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppeEintrag1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppe1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // daZusatzGruppeByID
            // 
            this.daZusatzGruppeByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daZusatzGruppeByID.InsertCommand = this.oleDbInsertCommand2;
            this.daZusatzGruppeByID.SelectCommand = this.oleDbSelectCommand4;
            this.daZusatzGruppeByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzGruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daZusatzGruppeByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM ZusatzGruppe WHERE (ID = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO ZusatzGruppe(ID, Bezeichnung) VALUES (?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 6, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT ID, Bezeichnung FROM ZusatzGruppe WHERE (ID = ?)";
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 6, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE ZusatzGruppe SET ID = ?, Bezeichnung = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 6, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daZusatzGruppeListe
            // 
            this.daZusatzGruppeListe.SelectCommand = this.oleDbSelectCommand5;
            this.daZusatzGruppeListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "TEXT")})});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = "SELECT ID, ID + \' - \' + Bezeichnung as TEXT FROM ZusatzGruppe";
            this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
            // 
            // daZusatzByGruppe
            // 
            this.daZusatzByGruppe.DeleteCommand = this.oleDbDeleteCommand4;
            this.daZusatzByGruppe.InsertCommand = this.oleDbInsertCommand4;
            this.daZusatzByGruppe.SelectCommand = this.oleDbSelectCommand6;
            this.daZusatzByGruppe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzGruppeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppe", "IDZusatzGruppe"),
                        new System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("IDFilter", "IDFilter"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("DruckenJN", "DruckenJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("AktivJN", "AktivJN")})});
            this.daZusatzByGruppe.UpdateCommand = this.oleDbUpdateCommand4;
            // 
            // oleDbDeleteCommand4
            // 
            this.oleDbDeleteCommand4.CommandText = "DELETE FROM [ZusatzGruppeEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand4.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand4
            // 
            this.oleDbInsertCommand4.CommandText = "INSERT INTO [ZusatzGruppeEintrag] ([ID], [IDZusatzGruppe], [IDZusatzEintrag], [ID" +
    "Objekt], [IDFilter], [OptionalJN], [DruckenJN], [Reihenfolge], [AktivJN]) VALUES" +
    " (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand4.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN")});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.Char, 6, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 16, "IDFilter")});
            // 
            // oleDbUpdateCommand4
            // 
            this.oleDbUpdateCommand4.CommandText = resources.GetString("oleDbUpdateCommand4.CommandText");
            this.oleDbUpdateCommand4.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsZusatzGruppeEintrag1
            // 
            this.dsZusatzGruppeEintrag1.DataSetName = "dsZusatzGruppeEintrag";
            this.dsZusatzGruppeEintrag1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsZusatzGruppeEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsZusatzGruppe1
            // 
            this.dsZusatzGruppe1.DataSetName = "dsZusatzGruppe";
            this.dsZusatzGruppe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsZusatzGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daZusatzByGruppeAbteilung
            // 
            this.daZusatzByGruppeAbteilung.DeleteCommand = this.oleDbCommand1;
            this.daZusatzByGruppeAbteilung.InsertCommand = this.oleDbCommand2;
            this.daZusatzByGruppeAbteilung.SelectCommand = this.oleDbCommand3;
            this.daZusatzByGruppeAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzGruppeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppe", "IDZusatzGruppe"),
                        new System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("IDFilter", "IDFilter"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("DruckenJN", "DruckenJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("AktivJN", "AktivJN")})});
            this.daZusatzByGruppeAbteilung.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM [ZusatzGruppeEintrag] WHERE (([ID] = ?))";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO [ZusatzGruppeEintrag] ([ID], [IDZusatzGruppe], [IDZusatzEintrag], [ID" +
    "Objekt], [IDFilter], [OptionalJN], [DruckenJN], [Reihenfolge], [AktivJN]) VALUES" +
    " (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.Char, 6, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 16, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daZusatzgruppeEintragByID
            // 
            this.daZusatzgruppeEintragByID.DeleteCommand = this.oleDbCommand5;
            this.daZusatzgruppeEintragByID.InsertCommand = this.oleDbCommand6;
            this.daZusatzgruppeEintragByID.SelectCommand = this.oleDbCommand7;
            this.daZusatzgruppeEintragByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzGruppeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDZusatzGruppe", "IDZusatzGruppe"),
                        new System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"),
                        new System.Data.Common.DataColumnMapping("IDObjekt", "IDObjekt"),
                        new System.Data.Common.DataColumnMapping("IDFilter", "IDFilter"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("DruckenJN", "DruckenJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("AktivJN", "AktivJN")})});
            this.daZusatzgruppeEintragByID.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM [ZusatzGruppeEintrag] WHERE (([ID] = ?))";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO [ZusatzGruppeEintrag] ([ID], [IDZusatzGruppe], [IDZusatzEintrag], [ID" +
    "Objekt], [IDFilter], [OptionalJN], [DruckenJN], [Reihenfolge], [AktivJN]) VALUES" +
    " (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT        ID, IDZusatzGruppe, IDZusatzEintrag, IDObjekt, IDFilter, OptionalJN" +
    ", DruckenJN, Reihenfolge, AktivJN\r\nFROM            ZusatzGruppeEintrag\r\nWHERE   " +
    "     (IDZusatzGruppe = ?)";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.Char, 6, "IDZusatzGruppe")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = resources.GetString("oleDbCommand8.CommandText");
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDZusatzGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzGruppe"),
            new System.Data.OleDb.OleDbParameter("IDZusatzEintrag", System.Data.OleDb.OleDbType.VarChar, 0, "IDZusatzEintrag"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 0, "IDObjekt"),
            new System.Data.OleDb.OleDbParameter("IDFilter", System.Data.OleDb.OleDbType.Guid, 0, "IDFilter"),
            new System.Data.OleDb.OleDbParameter("OptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OptionalJN"),
            new System.Data.OleDb.OleDbParameter("DruckenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DruckenJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("AktivJN", System.Data.OleDb.OleDbType.Boolean, 0, "AktivJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppeEintrag1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzGruppe1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Auf Abteilung filtern
		/// </summary>
		//----------------------------------------------------------------------------
		public bool UseAbteilung
		{
			get	{	return _bUseAbteilung;	}
			set	{	_bUseAbteilung = value;	}
		}

        public bool UseFilter
        {
            get { return _bUseFilter; }
            set { _bUseFilter = value; }
        }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Filter setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Filter
		{
            get { return _bUseFilter ? (Guid)daSubEntries.SelectCommand.Parameters[1].Value : Guid.Empty; }
			set	
            {
                if (_bUseFilter)
                    daSubEntries.SelectCommand.Parameters[1].Value = value;			
            }
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abteilung setzten
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid Abteilung
		{
			get	{	return (Guid)daZusatzByGruppeAbteilung.SelectCommand.Parameters[2].Value;	}
			set	{	daZusatzByGruppeAbteilung.SelectCommand.Parameters[2].Value = value;		}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daZusatzGruppeListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daZusatzGruppeByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daSubEntries
		{
			get	
			{
                if (UseAbteilung)
                    return daZusatzByGruppeAbteilung;
                else if (UseFilter)
                    return daZusatzByGruppe;
                else
                    return daZusatzgruppeEintragByID;	
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddZusatzGruppeRow("", "");
			SUBITEMS.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsZusatzGruppeEintrag.ZusatzGruppeEintragRow NewEntry()
		{
			return SUBITEMS.AddZusatzGruppeEintragRow(Guid.NewGuid(),
					ITEM[0].ID, "", Guid.Empty, Filter, true, true,0, true);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsZusatzGruppe.ZusatzGruppeDataTable ITEM
		{
			get	{	return dsZusatzGruppe1.ZusatzGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsZusatzGruppeEintrag.ZusatzGruppeEintragDataTable SUBITEMS
		{
			get	{	return dsZusatzGruppeEintrag1.ZusatzGruppeEintrag;	}
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
	}
}
