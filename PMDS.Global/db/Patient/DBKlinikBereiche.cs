//----------------------------------------------------------------------------
/// <summary>
///	DBKlinikBereiche.cs
/// Erstellt am:	07.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die KlinikBereichs-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBKlinikBereiche : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daBereicheByKlinik;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter daBereicheByAbteilung;
        private dsBereich dsBereich1;
        private OleDbCommand oleDbDeleteCommand;
        private OleDbCommand oleDbInsertCommand;
        private OleDbCommand oleDbUpdateCommand;
        private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBKlinikBereiche()
		{
			InitializeComponent();
			IsSingleEntry = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlinikBereiche));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daBereicheByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daBereicheByAbteilung = new System.Data.OleDb.OleDbDataAdapter();
            this.dsBereich1 = new PMDS.Global.db.Patient.dsBereich();
            this.oleDbInsertCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsBereich1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Persist Security Info=True;Password=NiwQ" +
    "s21+!;User ID=hl;Initial Catalog=PMDSDev";
            // 
            // daBereicheByKlinik
            // 
            this.daBereicheByKlinik.DeleteCommand = this.oleDbDeleteCommand;
            this.daBereicheByKlinik.InsertCommand = this.oleDbInsertCommand;
            this.daBereicheByKlinik.SelectCommand = this.oleDbSelectCommand1;
            this.daBereicheByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Bereichstyp", "Bereichstyp"),
                        new System.Data.Common.DataColumnMapping("AnzahlBetten", "AnzahlBetten")})});
            this.daBereicheByKlinik.UpdateCommand = this.oleDbUpdateCommand;
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Param1", System.Data.OleDb.OleDbType.Guid, 16)});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // daBereicheByAbteilung
            // 
            this.daBereicheByAbteilung.SelectCommand = this.oleDbSelectCommand2;
            this.daBereicheByAbteilung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Bereich", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Bereichstyp", "Bereichstyp"),
                        new System.Data.Common.DataColumnMapping("AnzahlBetten", "AnzahlBetten")})});
            // 
            // dsBereich1
            // 
            this.dsBereich1.DataSetName = "dsBereich";
            this.dsBereich1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsBereich1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbInsertCommand
            // 
            this.oleDbInsertCommand.CommandText = "INSERT INTO [Bereich] ([ID], [IDAbteilung], [IDBereich], [Bezeichnung], [Reihenfo" +
    "lge], [Bereichstyp], [AnzahlBetten]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bereichstyp", System.Data.OleDb.OleDbType.VarChar, 0, "Bereichstyp"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten")});
            // 
            // oleDbUpdateCommand
            // 
            this.oleDbUpdateCommand.CommandText = "UPDATE [Bereich] SET [ID] = ?, [IDAbteilung] = ?, [IDBereich] = ?, [Bezeichnung] " +
    "= ?, [Reihenfolge] = ?, [Bereichstyp] = ?, [AnzahlBetten] = ? WHERE (([ID] = ?))" +
    "";
            this.oleDbUpdateCommand.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 0, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 0, "IDBereich"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bereichstyp", System.Data.OleDb.OleDbType.VarChar, 0, "Bereichstyp"),
            new System.Data.OleDb.OleDbParameter("AnzahlBetten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlBetten"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand
            // 
            this.oleDbDeleteCommand.CommandText = "DELETE FROM [Bereich] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsBereich1)).EndInit();

		}
		#endregion
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daBereicheByKlinik;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue KlinikBereiche erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBereich.BereichRow AddEntryxy()
		{
			dsBereich.BereichRow r = ITEM.NewBereichRow();

			r.ID			= Guid.NewGuid();
            r.SetIDAbteilungNull();
			r.Bezeichnung	= "";
            r.Reihenfolge   = 0;
            r.Bereichstyp = "";
            r.AnzahlBetten = 0;
			ITEM.AddBereichRow(r);
			return r;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern (mehere Einträge)
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBereich.BereichDataTable ITEM
		{
			get	{	return dsBereich1.Bereich;	}
		}

		#region IDBBase  Members

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
		/// Einträge neu lesen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsBereich.BereichDataTable ByAbteilung(Guid id)
		{
			dsBereich ds = new dsBereich();
			daBereicheByAbteilung.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daBereicheByAbteilung, ds.Bereich);
			return ds.Bereich;
		}

    }
}
