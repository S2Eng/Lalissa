//----------------------------------------------------------------------------
/// <summary>
///	DBKlinikAbteilungen.cs
/// Erstellt am:	07.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die KlinikAbteilungs-Informationen.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBKlinikAbteilungen : DBBase, IDBBase
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daAbteilungByKlinik;
		private System.Data.OleDb.OleDbDataAdapter daAbteilungListe;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private dsAbteilung dsAbteilung1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbDataAdapter daUAbtByKlinik;
		private System.Data.OleDb.OleDbDataAdapter daUAbtKontaktByKlinik;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBKlinikAbteilungen()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBKlinikAbteilungen));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daAbteilungByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daAbteilungListe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsAbteilung1 = new PMDS.Global.db.Patient.dsAbteilung();
            this.daUAbtByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daUAbtKontaktByKlinik = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daAbteilungByKlinik
            // 
            this.daAbteilungByKlinik.SelectCommand = this.oleDbSelectCommand2;
            this.daAbteilungByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Tel", "Tel"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("Mobil", "Mobil"),
                        new System.Data.Common.DataColumnMapping("Andere", "Andere"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
                        new System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"),
                        new System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"),
                        new System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // daAbteilungListe
            // 
            this.daAbteilungListe.SelectCommand = this.oleDbSelectCommand1;
            this.daAbteilungListe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "IDListe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Bezeichnung AS TEXT\r\nFROM         Abteilung\r\nORDER BY Reihenfolge," +
    " TEXT";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            // 
            // dsAbteilung1
            // 
            this.dsAbteilung1.DataSetName = "dsAbteilung";
            this.dsAbteilung1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsAbteilung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daUAbtByKlinik
            // 
            this.daUAbtByKlinik.DeleteCommand = this.oleDbDeleteCommand1;
            this.daUAbtByKlinik.InsertCommand = this.oleDbInsertCommand1;
            this.daUAbtByKlinik.SelectCommand = this.oleDbSelectCommand3;
            this.daUAbtByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDKlinik", "IDKlinik"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Basisabteilung", "Basisabteilung")})});
            this.daUAbtByKlinik.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Abteilung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [Abteilung] ([ID], [IDKlinik], [Bezeichnung], [IDKontakt], [RMOptiona" +
    "lJN], [Reihenfolge], [Basisabteilung]) VALUES (?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Basisabteilung", System.Data.OleDb.OleDbType.Boolean, 0, "Basisabteilung")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT        ID, IDKlinik, Bezeichnung, IDKontakt, RMOptionalJN, Reihenfolge, Ba" +
    "sisabteilung\r\nFROM            Abteilung\r\nWHERE        (IDKlinik = ?)\r\nORDER BY B" +
    "ezeichnung";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE [Abteilung] SET [ID] = ?, [IDKlinik] = ?, [Bezeichnung] = ?, [IDKontakt] =" +
    " ?, [RMOptionalJN] = ?, [Reihenfolge] = ?, [Basisabteilung] = ? WHERE (([ID] = ?" +
    "))";
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDKlinik", System.Data.OleDb.OleDbType.Guid, 0, "IDKlinik"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("IDKontakt", System.Data.OleDb.OleDbType.Guid, 0, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 0, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Basisabteilung", System.Data.OleDb.OleDbType.Boolean, 0, "Basisabteilung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daUAbtKontaktByKlinik
            // 
            this.daUAbtKontaktByKlinik.DeleteCommand = this.oleDbDeleteCommand2;
            this.daUAbtKontaktByKlinik.InsertCommand = this.oleDbInsertCommand2;
            this.daUAbtKontaktByKlinik.SelectCommand = this.oleDbSelectCommand4;
            this.daUAbtKontaktByKlinik.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDKontakt", "IDKontakt"),
                        new System.Data.Common.DataColumnMapping("Tel", "Tel"),
                        new System.Data.Common.DataColumnMapping("Fax", "Fax"),
                        new System.Data.Common.DataColumnMapping("Mobil", "Mobil"),
                        new System.Data.Common.DataColumnMapping("Andere", "Andere"),
                        new System.Data.Common.DataColumnMapping("Email", "Email"),
                        new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
                        new System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1"),
                        new System.Data.Common.DataColumnMapping("Zusatz2", "Zusatz2"),
                        new System.Data.Common.DataColumnMapping("Zusatz3", "Zusatz3")})});
            this.daUAbtKontaktByKlinik.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = "DELETE FROM Kontakt WHERE (ID = ?)";
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDKontakt", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO Kontakt(ID, Tel, Fax, Mobil, Andere, Email, Ansprechpartner, Zusatz1," +
    " Zusatz2, Zusatz3) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 25, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 25, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 25, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 25, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 50, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 50, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz3")});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = "SELECT ID AS IDKontakt, Tel, Fax, Mobil, Andere, Email, Ansprechpartner, Zusatz1," +
    " Zusatz2, Zusatz3 FROM Kontakt WHERE (ID = ?)";
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDKontakt")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = "UPDATE Kontakt SET ID = ?, Tel = ?, Fax = ?, Mobil = ?, Andere = ?, Email = ?, An" +
    "sprechpartner = ?, Zusatz1 = ?, Zusatz2 = ?, Zusatz3 = ? WHERE (ID = ?)";
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDKontakt"),
            new System.Data.OleDb.OleDbParameter("Tel", System.Data.OleDb.OleDbType.VarChar, 25, "Tel"),
            new System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarChar, 25, "Fax"),
            new System.Data.OleDb.OleDbParameter("Mobil", System.Data.OleDb.OleDbType.VarChar, 25, "Mobil"),
            new System.Data.OleDb.OleDbParameter("Andere", System.Data.OleDb.OleDbType.VarChar, 25, "Andere"),
            new System.Data.OleDb.OleDbParameter("Email", System.Data.OleDb.OleDbType.VarChar, 50, "Email"),
            new System.Data.OleDb.OleDbParameter("Ansprechpartner", System.Data.OleDb.OleDbType.VarChar, 50, "Ansprechpartner"),
            new System.Data.OleDb.OleDbParameter("Zusatz1", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz1"),
            new System.Data.OleDb.OleDbParameter("Zusatz2", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz2"),
            new System.Data.OleDb.OleDbParameter("Zusatz3", System.Data.OleDb.OleDbType.VarChar, 75, "Zusatz3"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDKontakt", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsAbteilung1)).EndInit();

		}
		#endregion
	
		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung aller Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daAll
		{
			get	{	return daAbteilungListe;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daAbteilungByKlinik;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neue KlinikAbteilung erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Abgleich der Daten mit Datenbank.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void Write()
		{
			DataTable tKontaktINSUPD= ((IDBBase)this).ITEM.GetChanges(DataRowState.Added | DataRowState.Modified);
			DataTable tKontaktDEL	= ((IDBBase)this).ITEM.GetChanges(DataRowState.Deleted);

			if (tKontaktINSUPD != null)
				DataBase.Update(daUAbtKontaktByKlinik, tKontaktINSUPD);

			DataBase.Update(daUAbtByKlinik,	((IDBBase)this).ITEM);

			if (tKontaktDEL != null)
				DataBase.Update(daUAbtKontaktByKlinik, tKontaktDEL);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Eintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAbteilung.AbteilungRow AddEntry()
		{
			return ITEM.AddAbteilungRow(Guid.NewGuid(), (Guid)ID, "", Guid.NewGuid(), "", "", "", "", 
									"", "", "", "", "", false, 0, false);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern (mehere Einträge)
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAbteilung.AbteilungDataTable ITEM
		{
			get	{	return dsAbteilung1.Abteilung;	}
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
	}
}
