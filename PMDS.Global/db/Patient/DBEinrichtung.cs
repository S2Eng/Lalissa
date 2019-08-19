//----------------------------------------------------------------------------
/// <summary>
///	DBEinrichtung.cs
/// Erstellt am:	17.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die Einrichtungs-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBEinrichtung : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daEinrichtungByID;
		private System.Data.OleDb.OleDbDataAdapter daEinrichtungListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private dsEinrichtung dsEinrichtung1;
        public OleDbDataAdapter daAllEinrichtungen;
        private OleDbCommand oleDbCommand3;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBEinrichtung()
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
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daEinrichtungListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daEinrichtungByID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsEinrichtung1 = new PMDS.Global.db.Patient.dsEinrichtung();
            this.daAllEinrichtungen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsEinrichtung1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // daEinrichtungListe
            // 
            this.daEinrichtungListe.SelectCommand = this.oleDbSelectCommand1;
            this.daEinrichtungListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT ID, Text AS TEXT FROM Einrichtung ORDER BY Text";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // daEinrichtungByID
            // 
            this.daEinrichtungByID.DeleteCommand = this.oleDbDeleteCommand2;
            this.daEinrichtungByID.InsertCommand = this.oleDbInsertCommand2;
            this.daEinrichtungByID.SelectCommand = this.oleDbSelectCommand2;
            this.daEinrichtungByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Einrichtung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGAAbgeglichen", "ELGAAbgeglichen"),
                        new System.Data.Common.DataColumnMapping("IstKrankenkasse", "IstKrankenkasse")})});
            this.daEinrichtungByID.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM [Einrichtung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO [Einrichtung] ([ID], [Text], [IDAdresse], [IDKontakt], [ELGA_OID], [E" +
    "LGAAbgeglichen], [IstKrankenkasse]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("IstKrankenkasse", System.Data.OleDb.OleDbType.Boolean, 0, "IstKrankenkasse")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT        ID, Text, IDAdresse, IDKontakt, ELGA_OID, ELGAAbgeglichen, IstKrank" +
    "enkasse\r\nFROM            Einrichtung\r\nWHERE        (ID = ?)";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE [Einrichtung] SET [ID] = ?, [Text] = ?, [IDAdresse] = ?, [IDKontakt] = ?, " +
    "[ELGA_OID] = ?, [ELGAAbgeglichen] = ?, [IstKrankenkasse] = ? WHERE (([ID] = ?))";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("IDAdresse", System.Data.OleDb.OleDbType.Guid, 0, "IDAdresse"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("ELGA_OID", System.Data.OleDb.OleDbType.VarWChar, 0, "ELGA_OID"),
            new System.Data.OleDb.OleDbParameter("ELGAAbgeglichen", System.Data.OleDb.OleDbType.Boolean, 0, "ELGAAbgeglichen"),
            new System.Data.OleDb.OleDbParameter("IstKrankenkasse", System.Data.OleDb.OleDbType.Boolean, 0, "IstKrankenkasse"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsEinrichtung1
            // 
            this.dsEinrichtung1.DataSetName = "dsEinrichtung";
            this.dsEinrichtung1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsEinrichtung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAllEinrichtungen
            // 
            this.daAllEinrichtungen.SelectCommand = this.oleDbCommand3;
            this.daAllEinrichtungen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Einrichtung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("IDAdresse", "IDAdresse"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("ELGA_OID", "ELGA_OID"),
                        new System.Data.Common.DataColumnMapping("ELGAAbgeglichen", "ELGAAbgeglichen"),
                        new System.Data.Common.DataColumnMapping("IstKrankenkasse", "IstKrankenkasse")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT        ID, Text, IDAdresse, IDKontakt , ELGA_OID, ELGAAbgeglichen, IstKran" +
    "kenkasse \r\nFROM            Einrichtung\r\nORDER BY Text";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            ((System.ComponentModel.ISupportInitialize)(this.dsEinrichtung1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daEinrichtungListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daEinrichtungByID;	}
		}
        public bool getAllEinrichtungen( dsEinrichtung ds)
        {
            ds.Clear();
            //this.daAllEinrichtungen.SelectCommand.Parameters[0].Value = IDKlinik;
            RBU.DataBase.Fill(this.daAllEinrichtungen, ds);
            return true;
        }
		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen ZusatzEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddEinrichtungRow(Guid.NewGuid(), "", Guid.Empty, Guid.Empty, "", false, false);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsEinrichtung.EinrichtungDataTable ITEM
		{
			get	{	return dsEinrichtung1.Einrichtung;	}
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
	}
}
