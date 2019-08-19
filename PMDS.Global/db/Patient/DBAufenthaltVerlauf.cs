//----------------------------------------------------------------------------
/// <summary>
///	DBAufenthaltVerlauf.cs
/// Erstellt am:	12.10.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;

using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf die AufenthaltVerläufe.
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBAufenthaltVerlauf : DBBaseEntries, IDBBaseEntries
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter daAufenthaltVerlaufByID;
        private dsAufenthaltVerlauf dsAufenthaltVerlauf1;
		private System.Data.OleDb.OleDbDataAdapter daAufenthaltVerlaufByAufenthalt;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbDataAdapter daVersetzungByAufenthalt;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbDataAdapter daBenutzerByAufenthaltVerlauf;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
        private dsBenutzerBezug dsBenutzerBezug1;
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
		public DBAufenthaltVerlauf()
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
			this.daAufenthaltVerlaufByID = new System.Data.OleDb.OleDbDataAdapter();
            this.dsAufenthaltVerlauf1 = new dsAufenthaltVerlauf();
			this.daAufenthaltVerlaufByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.daVersetzungByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.daBenutzerByAufenthaltVerlauf = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsBenutzerBezug1 = new dsBenutzerBezug();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltVerlauf1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBenutzerBezug1)).BeginInit();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"User ID=sa;Data Source=""HOFER\VSdotNET"";Tag with column collation when possible=False;Initial Catalog=PMDS;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=HOFER;Use Encryption for Data=False;Packet Size=4096";
			// 
			// daAufenthaltVerlaufByID
			// 
			this.daAufenthaltVerlaufByID.DeleteCommand = this.oleDbDeleteCommand1;
			this.daAufenthaltVerlaufByID.InsertCommand = this.oleDbInsertCommand1;
			this.daAufenthaltVerlaufByID.SelectCommand = this.oleDbSelectCommand1;
			this.daAufenthaltVerlaufByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "AufenthaltVerlauf", new System.Data.Common.DataColumnMapping[] {
																																																								   new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																								   new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
																																																								   new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
																																																								   new System.Data.Common.DataColumnMapping("IDAbteilung_Von", "IDAbteilung_Von"),
																																																								   new System.Data.Common.DataColumnMapping("IDAbteilung_Nach", "IDAbteilung_Nach"),
																																																								   new System.Data.Common.DataColumnMapping("IDBereich", "IDBereich"),
																																																								   new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
																																																								   new System.Data.Common.DataColumnMapping("Datum", "Datum"),
																																																								   new System.Data.Common.DataColumnMapping("ZuweisenderArzt", "ZuweisenderArzt"),
																																																								   new System.Data.Common.DataColumnMapping("AufnahmeArzt", "AufnahmeArzt"),
																																																								   new System.Data.Common.DataColumnMapping("Aufnahmegespraech", "Aufnahmegespraech"),
																																																								   new System.Data.Common.DataColumnMapping("Abschlussbemerkung", "Abschlussbemerkung"),
																																																								   new System.Data.Common.DataColumnMapping("AufnahmeStatus", "AufnahmeStatus")})});
			this.daAufenthaltVerlaufByID.UpdateCommand = this.oleDbUpdateCommand1;
			// 
			// dsAufenthaltVerlauf1
			// 
			this.dsAufenthaltVerlauf1.DataSetName = "dsAufenthaltVerlauf";
			this.dsAufenthaltVerlauf1.Locale = new System.Globalization.CultureInfo("de-AT");
			// 
			// daAufenthaltVerlaufByAufenthalt
			// 
			this.daAufenthaltVerlaufByAufenthalt.SelectCommand = this.oleDbCommand1;
			this.daAufenthaltVerlaufByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "Aufenthalt", new System.Data.Common.DataColumnMapping[] {
																																																									new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																									new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
																																																									new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
																																																									new System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf"),
																																																									new System.Data.Common.DataColumnMapping("IDBenutzer_Aufnahme", "IDBenutzer_Aufnahme"),
																																																									new System.Data.Common.DataColumnMapping("IDBenutzer_Entlassung", "IDBenutzer_Entlassung"),
																																																									new System.Data.Common.DataColumnMapping("IDEinrichtung_Aufnahme", "IDEinrichtung_Aufnahme"),
																																																									new System.Data.Common.DataColumnMapping("IDEinrichtung_Entlassung", "IDEinrichtung_Entlassung"),
																																																									new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
																																																									new System.Data.Common.DataColumnMapping("Entlassungszeitpunkt", "Entlassungszeitpunkt"),
																																																									new System.Data.Common.DataColumnMapping("AufnahmeArt", "AufnahmeArt"),
																																																									new System.Data.Common.DataColumnMapping("BegleitungVon", "BegleitungVon"),
																																																									new System.Data.Common.DataColumnMapping("Entlassungsbemerkung", "Entlassungsbemerkung"),
																																																									new System.Data.Common.DataColumnMapping("SomatischeAuff", "SomatischeAuff"),
																																																									new System.Data.Common.DataColumnMapping("PsychischeAuff", "PsychischeAuff"),
																																																									new System.Data.Common.DataColumnMapping("VerhaltenAufnahme", "VerhaltenAufnahme"),
																																																									new System.Data.Common.DataColumnMapping("SonstigeBesonderheiten", "SonstigeBesonderheiten"),
																																																									new System.Data.Common.DataColumnMapping("SofortMassnahmen", "SofortMassnahmen")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = "SELECT ID, IDAufenthalt, IDBenutzer, IDAbteilung_Von, IDAbteilung_Nach, IDBereich" +
				", Bemerkung, Datum, ZuweisenderArzt, AufnahmeArzt, Aufnahmegespraech, Abschlussb" +
				"emerkung, AufnahmeStatus FROM AufenthaltVerlauf WHERE (IDAufenthalt = ?) ORDER B" +
				"Y Datum";
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			// 
			// daVersetzungByAufenthalt
			// 
			this.daVersetzungByAufenthalt.SelectCommand = this.oleDbCommand2;
			this.daVersetzungByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											   new System.Data.Common.DataTableMapping("Table", "Versetzungen", new System.Data.Common.DataColumnMapping[] {
																																																							   new System.Data.Common.DataColumnMapping("Datum", "Datum"),
																																																							   new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung")})});
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = "SELECT AufenthaltVerlauf.Datum, Abteilung.Bezeichnung AS Abteilung FROM Aufenthal" +
				"tVerlauf INNER JOIN Abteilung ON AufenthaltVerlauf.IDAbteilung_Nach = Abteilung." +
				"ID WHERE (AufenthaltVerlauf.IDAufenthalt = ?) ORDER BY AufenthaltVerlauf.Datum D" +
				"ESC";
			this.oleDbCommand2.Connection = this.oleDbConnection1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			// 
			// daBenutzerByAufenthaltVerlauf
			// 
			this.daBenutzerByAufenthaltVerlauf.DeleteCommand = this.oleDbDeleteCommand2;
			this.daBenutzerByAufenthaltVerlauf.InsertCommand = this.oleDbInsertCommand2;
			this.daBenutzerByAufenthaltVerlauf.SelectCommand = this.oleDbSelectCommand2;
			this.daBenutzerByAufenthaltVerlauf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													new System.Data.Common.DataTableMapping("Table", "BenutzerBezug", new System.Data.Common.DataColumnMapping[] {
																																																									 new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
																																																									 new System.Data.Common.DataColumnMapping("IDAufenthaltVerlauf", "IDAufenthaltVerlauf")})});
			this.daBenutzerByAufenthaltVerlauf.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = "DELETE FROM BenutzerBezug WHERE (IDAufenthaltVerlauf = ?) AND (IDBenutzer = ?)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDAufenthaltVerlauf", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO BenutzerBezug(IDBenutzer, IDAufenthaltVerlauf) VALUES (?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltVerlauf"));
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT IDBenutzer, IDAufenthaltVerlauf FROM BenutzerBezug WHERE (IDAufenthaltVerl" +
				"auf = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltVerlauf"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = "UPDATE BenutzerBezug SET IDBenutzer = ?, IDAufenthaltVerlauf = ? WHERE (IDAufenth" +
				"altVerlauf = ?) AND (IDBenutzer = ?)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltVerlauf"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IDAufenthaltVerlauf", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDAufenthaltVerlauf", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "IDBenutzer", System.Data.DataRowVersion.Original, null));
			// 
			// dsBenutzerBezug1
			// 
			this.dsBenutzerBezug1.DataSetName = "dsBenutzerBezug";
			this.dsBenutzerBezug1.Locale = new System.Globalization.CultureInfo("de-AT");
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT ID, IDAufenthalt, IDBenutzer, IDAbteilung_Von, IDAbteilung_Nach, IDBereich" +
				", Bemerkung, Datum, ZuweisenderArzt, AufnahmeArzt, Aufnahmegespraech, Abschlussb" +
				"emerkung, AufnahmeStatus FROM AufenthaltVerlauf WHERE (ID = ?)";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = @"INSERT INTO AufenthaltVerlauf(ID, IDAufenthalt, IDBenutzer, IDAbteilung_Von, IDAbteilung_Nach, IDBereich, Bemerkung, Datum, ZuweisenderArzt, AufnahmeArzt, Aufnahmegespraech, Abschlussbemerkung, AufnahmeStatus) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAbteilung_Von", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung_Von"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAbteilung_Nach", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung_Nach"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 16, "IDBereich"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Bemerkung"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datum"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ZuweisenderArzt", System.Data.OleDb.OleDbType.VarChar, 50, "ZuweisenderArzt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AufnahmeArzt", System.Data.OleDb.OleDbType.VarChar, 50, "AufnahmeArzt"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Aufnahmegespraech", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Aufnahmegespraech"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Abschlussbemerkung", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Abschlussbemerkung"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AufnahmeStatus", System.Data.OleDb.OleDbType.VarChar, 2147483647, "AufnahmeStatus"));
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE AufenthaltVerlauf SET ID = ?, IDAufenthalt = ?, IDBenutzer = ?, IDAbteilung_Von = ?, IDAbteilung_Nach = ?, IDBereich = ?, Bemerkung = ?, Datum = ?, ZuweisenderArzt = ?, AufnahmeArzt = ?, Aufnahmegespraech = ?, Abschlussbemerkung = ?, AufnahmeStatus = ? WHERE (ID = ?)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAbteilung_Von", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung_Von"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAbteilung_Nach", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung_Nach"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDBereich", System.Data.OleDb.OleDbType.Guid, 16, "IDBereich"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Bemerkung", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Bemerkung"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Datum", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "Datum"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ZuweisenderArzt", System.Data.OleDb.OleDbType.VarChar, 50, "ZuweisenderArzt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AufnahmeArzt", System.Data.OleDb.OleDbType.VarChar, 50, "AufnahmeArzt"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Aufnahmegespraech", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Aufnahmegespraech"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Abschlussbemerkung", System.Data.OleDb.OleDbType.VarChar, 2147483647, "Abschlussbemerkung"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("AufnahmeStatus", System.Data.OleDb.OleDbType.VarChar, 2147483647, "AufnahmeStatus"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM AufenthaltVerlauf WHERE (ID = ?)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ID", System.Data.DataRowVersion.Original, null));
			((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltVerlauf1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsBenutzerBezug1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung bestimmter Eintrags.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daFilterEntry
		{
			get	{	return daAufenthaltVerlaufByID;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Adapter zur Ermittlung der Sub-Einträge.
		/// </summary>
		//----------------------------------------------------------------------------
		protected override OleDbDataAdapter daSubEntries
		{
			get	{	return daBenutzerByAufenthaltVerlauf;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen Aufenthalt erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public override void New()
		{
			ITEM.Clear();
			ITEM.AddAufenthaltVerlaufRow(Guid.NewGuid(), Guid.Empty, Guid.Empty,
				Guid.Empty, Guid.Empty, Guid.Empty, "", DateTime.Now, 
				"", "", "", "", "");

			ITEM[0].SetIDAbteilung_VonNull();
			ITEM[0].SetIDAbteilung_NachNull();
			ITEM[0].SetIDBereichNull();

			SUBITEMS.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Neuen SubEintrag erzeugen.
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerBezug.BenutzerBezugRow NewEntry()
		{
			return SUBITEMS.AddBenutzerBezugRow(Guid.Empty, ITEM[0].ID);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsAufenthaltVerlauf.AufenthaltVerlaufDataTable ITEM
		{
			get	{	return dsAufenthaltVerlauf1.AufenthaltVerlauf;	}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// DatenTabelle liefern
		/// </summary>
		//----------------------------------------------------------------------------
		public virtual dsBenutzerBezug.BenutzerBezugDataTable SUBITEMS
		{
			get	{	return dsBenutzerBezug1.BenutzerBezug;	}
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
		/// AufenthalteVerlauf für Aufenthalt ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsAufenthaltVerlauf.AufenthaltVerlaufDataTable ByAufenthalt(Guid id)
		{
			dsAufenthaltVerlauf ds = new dsAufenthaltVerlauf();
			daAufenthaltVerlaufByAufenthalt.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daAufenthaltVerlaufByAufenthalt, ds.AufenthaltVerlauf);
			return ds.AufenthaltVerlauf;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Versetzungen für Aufenthalt ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsAufenthaltVerlauf.VersetzungenDataTable VersetzungByAufenthalt(Guid id)
		{
			dsAufenthaltVerlauf ds = new dsAufenthaltVerlauf();
			daVersetzungByAufenthalt.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daVersetzungByAufenthalt, ds.Versetzungen);
			return ds.Versetzungen;
		}
	}
}
