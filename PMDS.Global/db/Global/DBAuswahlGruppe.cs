//----------------------------------------------------------------------------
/// <summary>
///	DBAuswahlGruppe.cs
/// Erstellt am:	15.9.2004
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
	/// Datenbankklasse für den Zugriff auf die AuswahlListeGruppe.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBAuswahlGruppe : DBBaseEntries, IDBBaseEntries
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daAuswahlGruppeByID;
		private System.Data.OleDb.OleDbDataAdapter daAuswahlByGruppe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbDataAdapter daAuswahlGruppeListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private PMDS.Global.db.Global.dsAuswahlGruppe dsAuswahlGruppe1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBAuswahlGruppe()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAuswahlGruppe));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daAuswahlGruppeListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daAuswahlGruppeByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daAuswahlByGruppe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsAuswahlGruppe1 = new PMDS.Global.db.Global.dsAuswahlGruppe();
            ((System.ComponentModel.ISupportInitialize)(this.dsAuswahlGruppe1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // daAuswahlGruppeListe
            // 
            this.daAuswahlGruppeListe.SelectCommand = this.oleDbSelectCommand1;
            this.daAuswahlGruppeListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, ID + \' - \' + Bezeichnung AS TEXT FROM AuswahlListeGruppe";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daAuswahlGruppeByID
            // 
            this.daAuswahlGruppeByID.DeleteCommand = this.oleDbDeleteCommand3;
            this.daAuswahlGruppeByID.InsertCommand = this.oleDbInsertCommand3;
            this.daAuswahlGruppeByID.SelectCommand = this.oleDbSelectCommand3;
            this.daAuswahlGruppeByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AuswahlListeGruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("sys", "sys"),
                        new System.Data.Common.DataColumnMapping("ExactMatch", "ExactMatch"),
                        new System.Data.Common.DataColumnMapping("PflichtJN", "PflichtJN"),
                        new System.Data.Common.DataColumnMapping("IntID", "IntID"),
                        new System.Data.Common.DataColumnMapping("ElgaJN", "ElgaJN"),
                        new System.Data.Common.DataColumnMapping("ELGA_UseMeaning", "ELGA_UseMeaning")})});
            this.daAuswahlGruppeByID.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM [AuswahlListeGruppe] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO [AuswahlListeGruppe] ([ID], [Bezeichnung], [sys], [ExactMatch], [Pfli" +
    "chtJN], [IntID], [ElgaJN], [ELGA_UseMeaning]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("sys", System.Data.OleDb.OleDbType.Boolean, 0, "sys"),
            new System.Data.OleDb.OleDbParameter("ExactMatch", System.Data.OleDb.OleDbType.Boolean, 0, "ExactMatch"),
            new System.Data.OleDb.OleDbParameter("PflichtJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflichtJN"),
            new System.Data.OleDb.OleDbParameter("IntID", System.Data.OleDb.OleDbType.Integer, 0, "IntID"),
            new System.Data.OleDb.OleDbParameter("ElgaJN", System.Data.OleDb.OleDbType.Boolean, 0, "ElgaJN"),
            new System.Data.OleDb.OleDbParameter("ELGA_UseMeaning", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_UseMeaning")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT        ID, Bezeichnung, sys, ExactMatch, PflichtJN, IntID, ElgaJN, ELGA_Us" +
    "eMeaning\r\nFROM            AuswahlListeGruppe\r\nWHERE        (ID = ?)";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Char, 3, "ID")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE [AuswahlListeGruppe] SET [ID] = ?, [Bezeichnung] = ?, [sys] = ?, [ExactMat" +
    "ch] = ?, [PflichtJN] = ?, [IntID] = ?, [ElgaJN] = ?, [ELGA_UseMeaning] = ? WHERE" +
    " (([ID] = ?))";
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("sys", System.Data.OleDb.OleDbType.Boolean, 0, "sys"),
            new System.Data.OleDb.OleDbParameter("ExactMatch", System.Data.OleDb.OleDbType.Boolean, 0, "ExactMatch"),
            new System.Data.OleDb.OleDbParameter("PflichtJN", System.Data.OleDb.OleDbType.Boolean, 0, "PflichtJN"),
            new System.Data.OleDb.OleDbParameter("IntID", System.Data.OleDb.OleDbType.Integer, 0, "IntID"),
            new System.Data.OleDb.OleDbParameter("ElgaJN", System.Data.OleDb.OleDbType.Boolean, 0, "ElgaJN"),
            new System.Data.OleDb.OleDbParameter("ELGA_UseMeaning", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_UseMeaning"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daAuswahlByGruppe
            // 
            this.daAuswahlByGruppe.DeleteCommand = this.oleDbDeleteCommand2;
            this.daAuswahlByGruppe.InsertCommand = this.oleDbInsertCommand2;
            this.daAuswahlByGruppe.SelectCommand = this.oleDbSelectCommand2;
            this.daAuswahlByGruppe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AuswahlListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAuswahlListeGruppe", "IDAuswahlListeGruppe"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IstGruppe", "IstGruppe"),
                        new System.Data.Common.DataColumnMapping("GehörtzuGruppe", "GehörtzuGruppe"),
                        new System.Data.Common.DataColumnMapping("Hierarche", "Hierarche"),
                        new System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"),
                        new System.Data.Common.DataColumnMapping("Unterdruecken", "Unterdruecken"),
                        new System.Data.Common.DataColumnMapping("ELGA_ID", "ELGA_ID"),
                        new System.Data.Common.DataColumnMapping("ELGA_Code", "ELGA_Code"),
                        new System.Data.Common.DataColumnMapping("ELGA_CodeSystem", "ELGA_CodeSystem"),
                        new System.Data.Common.DataColumnMapping("ELGA_DisplayName", "ELGA_DisplayName"),
                        new System.Data.Common.DataColumnMapping("ELGA_Version", "ELGA_Version")})});
            this.daAuswahlByGruppe.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAuswahlListeGruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAuswahlListeGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Bezeichnung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IstGruppe", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IstGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GehörtzuGruppe", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GehörtzuGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Hierarche", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hierarche", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Beschreibung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Unterdruecken", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Unterdruecken", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_Code", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_CodeSystem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_DisplayName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_Version", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDAuswahlListeGruppe"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IstGruppe", System.Data.OleDb.OleDbType.Boolean, 0, "IstGruppe"),
            new System.Data.OleDb.OleDbParameter("GehörtzuGruppe", System.Data.OleDb.OleDbType.VarWChar, 0, "GehörtzuGruppe"),
            new System.Data.OleDb.OleDbParameter("Hierarche", System.Data.OleDb.OleDbType.Integer, 0, "Hierarche"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Unterdruecken", System.Data.OleDb.OleDbType.Boolean, 0, "Unterdruecken"),
            new System.Data.OleDb.OleDbParameter("ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_ID"),
            new System.Data.OleDb.OleDbParameter("ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Code"),
            new System.Data.OleDb.OleDbParameter("ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_CodeSystem"),
            new System.Data.OleDb.OleDbParameter("ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_DisplayName"),
            new System.Data.OleDb.OleDbParameter("ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Version")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.Char, 3, "IDAuswahlListeGruppe")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "IDAuswahlListeGruppe"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IstGruppe", System.Data.OleDb.OleDbType.Boolean, 0, "IstGruppe"),
            new System.Data.OleDb.OleDbParameter("GehörtzuGruppe", System.Data.OleDb.OleDbType.VarWChar, 0, "GehörtzuGruppe"),
            new System.Data.OleDb.OleDbParameter("Hierarche", System.Data.OleDb.OleDbType.Integer, 0, "Hierarche"),
            new System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, "Beschreibung"),
            new System.Data.OleDb.OleDbParameter("Unterdruecken", System.Data.OleDb.OleDbType.Boolean, 0, "Unterdruecken"),
            new System.Data.OleDb.OleDbParameter("ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_ID"),
            new System.Data.OleDb.OleDbParameter("ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Code"),
            new System.Data.OleDb.OleDbParameter("ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_CodeSystem"),
            new System.Data.OleDb.OleDbParameter("ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_DisplayName"),
            new System.Data.OleDb.OleDbParameter("ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Version"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAuswahlListeGruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAuswahlListeGruppe", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAuswahlListeGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Bezeichnung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IstGruppe", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IstGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_GehörtzuGruppe", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GehörtzuGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Hierarche", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Hierarche", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Beschreibung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Unterdruecken", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Unterdruecken", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_Code", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_CodeSystem", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_DisplayName", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ELGA_Version", System.Data.DataRowVersion.Original, null)});
            // 
            // dsAuswahlGruppe1
            // 
            this.dsAuswahlGruppe1.DataSetName = "dsAuswahlGruppe";
            this.dsAuswahlGruppe1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsAuswahlGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsAuswahlGruppe1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daAuswahlGruppeListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daAuswahlGruppeByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daSubEntries
		{
			get	{	return daAuswahlByGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddAuswahlListeGruppeRow("", "", false, false, false,false,0,0);
			SUBITEMS.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAuswahlGruppe.AuswahlListeRow NewEntry()
		{
			return SUBITEMS.AddAuswahlListeRow(Guid.NewGuid(), ITEM[0].ID, 
				SUBITEMS.Count+1, "", false, "", -1, "", false, -1, "", "", "", "");
		}

        public dsAuswahlGruppe.AuswahlListeGruppeRow getGroup(string Group)
        {
            daAuswahlGruppeByID.SelectCommand.Parameters[0].Value = Group;
            dsAuswahlGruppe.AuswahlListeGruppeDataTable t = new dsAuswahlGruppe.AuswahlListeGruppeDataTable();
            DataBase.Fill(daAuswahlGruppeByID, t);
            return (dsAuswahlGruppe.AuswahlListeGruppeRow)t.Rows[0];
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// DatenTabelle liefern
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual dsAuswahlGruppe.AuswahlListeGruppeDataTable ITEM
		{
			get	{	return dsAuswahlGruppe1.AuswahlListeGruppe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAuswahlGruppe.AuswahlListeDataTable SUBITEMS
		{
			get	{	return dsAuswahlGruppe1.AuswahlListe;	}
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
