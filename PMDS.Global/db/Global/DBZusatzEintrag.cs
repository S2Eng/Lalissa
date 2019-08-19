//----------------------------------------------------------------------------
/// <summary>
///	DBZusatzEintrag.cs
/// Erstellt am:	29.9.2004
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

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf ZusatzEinträge.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBZusatzEintrag : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbDataAdapter daZusatzEintragByID;
		private dsZusatzEintrag dsZusatzEintrag1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzEintragListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBZusatzEintrag()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBZusatzEintrag));
            this.daZusatzEintragListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daZusatzEintragByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsZusatzEintrag1 = new PMDS.Global.db.Global.dsZusatzEintrag();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzEintrag1)).BeginInit();
            // 
            // daZusatzEintragListe
            // 
            this.daZusatzEintragListe.SelectCommand = this.oleDbSelectCommand2;
            this.daZusatzEintragListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ID, ID + \' - \' + Bezeichnung AS TEXT FROM ZusatzEintrag";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=192.168.80.210;Integrated Security=SSPI;Initial Ca" +
    "talog=PMDSDev";
            // 
            // daZusatzEintragByID
            // 
            this.daZusatzEintragByID.DeleteCommand = this.oleDbDeleteCommand1;
            this.daZusatzEintragByID.InsertCommand = this.oleDbInsertCommand1;
            this.daZusatzEintragByID.SelectCommand = this.oleDbSelectCommand1;
            this.daZusatzEintragByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "ZusatzEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("MinValue", "MinValue"),
                        new System.Data.Common.DataColumnMapping("MaxValue", "MaxValue"),
                        new System.Data.Common.DataColumnMapping("FeldNr", "FeldNr"),
                        new System.Data.Common.DataColumnMapping("ELGA_ID", "ELGA_ID"),
                        new System.Data.Common.DataColumnMapping("ELGA_Code", "ELGA_Code"),
                        new System.Data.Common.DataColumnMapping("ELGA_CodeSystem", "ELGA_CodeSystem"),
                        new System.Data.Common.DataColumnMapping("ELGA_DisplayName", "ELGA_DisplayName"),
                        new System.Data.Common.DataColumnMapping("ELGA_Unit", "ELGA_Unit"),
                        new System.Data.Common.DataColumnMapping("ELGA_Version", "ELGA_Version")})});
            this.daZusatzEintragByID.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [ZusatzEintrag] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Integer, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("ListenEintraege", System.Data.OleDb.OleDbType.LongVarChar, 0, "ListenEintraege"),
            new System.Data.OleDb.OleDbParameter("MinValue", System.Data.OleDb.OleDbType.Double, 0, "MinValue"),
            new System.Data.OleDb.OleDbParameter("MaxValue", System.Data.OleDb.OleDbType.Double, 0, "MaxValue"),
            new System.Data.OleDb.OleDbParameter("ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_ID"),
            new System.Data.OleDb.OleDbParameter("ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Code"),
            new System.Data.OleDb.OleDbParameter("ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_CodeSystem"),
            new System.Data.OleDb.OleDbParameter("ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_DisplayName"),
            new System.Data.OleDb.OleDbParameter("ELGA_Unit", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Unit"),
            new System.Data.OleDb.OleDbParameter("ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Version")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Char, 6, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Typ", System.Data.OleDb.OleDbType.Integer, 0, "Typ"),
            new System.Data.OleDb.OleDbParameter("ListenEintraege", System.Data.OleDb.OleDbType.LongVarChar, 0, "ListenEintraege"),
            new System.Data.OleDb.OleDbParameter("MinValue", System.Data.OleDb.OleDbType.Double, 0, "MinValue"),
            new System.Data.OleDb.OleDbParameter("MaxValue", System.Data.OleDb.OleDbType.Double, 0, "MaxValue"),
            new System.Data.OleDb.OleDbParameter("ELGA_ID", System.Data.OleDb.OleDbType.Integer, 0, "ELGA_ID"),
            new System.Data.OleDb.OleDbParameter("ELGA_Code", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Code"),
            new System.Data.OleDb.OleDbParameter("ELGA_CodeSystem", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_CodeSystem"),
            new System.Data.OleDb.OleDbParameter("ELGA_DisplayName", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_DisplayName"),
            new System.Data.OleDb.OleDbParameter("ELGA_Unit", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Unit"),
            new System.Data.OleDb.OleDbParameter("ELGA_Version", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_Version"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT ID, Bezeichnung, Typ, ListenEintraege FROM ZusatzEintrag WHERE (ID = ?)";
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.VarChar, 6, "ID")});
            // 
            // dsZusatzEintrag1
            // 
            this.dsZusatzEintrag1.DataSetName = "dsZusatzEintrag";
            this.dsZusatzEintrag1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsZusatzEintrag1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzEintrag1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daZusatzEintragListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daZusatzEintragByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddZusatzEintragRow("", "", 0, "", 0.0, 0.0, -1, "", "", "", "", "");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsZusatzEintrag.ZusatzEintragDataTable ITEM
		{
			get	{	return dsZusatzEintrag1.ZusatzEintrag;	}
		}

		#region IDBBase Members

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		DataTable IDBBase.ITEM
		{
			get	{	return this.ITEM;	}
		}

		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert ob Eintrag bereits Existiert
		/// </summary> 
		//----------------------------------------------------------------------------
		public virtual bool Exist(string entryID) 
		{
			// wenn Eintrag gelesen wurde ist keine
			// Überprüfung notwendig
			if (entryID == (string)ID)
				return false;

            return PMDS.DB.DBUtil.ZusatzEintragExists(entryID);
		}
	}
}
