//----------------------------------------------------------------------------
/// <summary>
///	DBPrintZusatzwerte.cs
/// Erstellt am:	26.8.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Zugriffsklasse auf die Zusatzwerte von Patienten (per Aufenthalt)
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPrintZusatzwert : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzVerlauf;
		private dsZusatzVerlauf dsZusatzVerlauf1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzVerlaufAll;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private dsZusatzVerlaufAll dsZusatzVerlaufAll1;
		private System.Data.OleDb.OleDbDataAdapter daZusatzVerlaufOneEintrag;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPrintZusatzwert()
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

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zusatzwerte für einen einzelnen Aufenthalt hier aber nur diejenigen
		/// Einträge welche Zahlentechnisch verarbeitbar sind
		/// </summary>
		//----------------------------------------------------------------------------
		public dsZusatzVerlauf.ZusatzWertDataTable ReadVerlauf(Guid IDAufenthalt, string IDZusatzeintrag, DateTime From, DateTime to) 
		{
			dsZusatzVerlauf1.Clear();
			daZusatzVerlauf.SelectCommand.Parameters[0].Value = IDAufenthalt;
            daZusatzVerlauf.SelectCommand.Parameters[1].Value = From;
            daZusatzVerlauf.SelectCommand.Parameters[2].Value = to;
            daZusatzVerlauf.SelectCommand.Parameters[3].Value = IDZusatzeintrag;
			DataBase.Fill(daZusatzVerlauf, dsZusatzVerlauf1.ZusatzWert);
			return dsZusatzVerlauf1.ZusatzWert;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zusatzwerte für einen einzelnen Aufenthalt 
		/// Die jüngsten Einträge werden zuerst geliefert
		/// </summary>
		//----------------------------------------------------------------------------
		public dsZusatzVerlaufAll.ZusatzWertDataTable ReadVerlaufAll(Guid IDAufenthalt)
		{
			dsZusatzVerlaufAll1.Clear();
			daZusatzVerlaufAll.SelectCommand.Parameters[0].Value = IDAufenthalt;
			DataBase.Fill(daZusatzVerlaufAll, dsZusatzVerlaufAll1.ZusatzWert);
			return dsZusatzVerlaufAll1.ZusatzWert;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Zusatzwerte für einen IDPflegeEintrag 
		/// </summary>
		//----------------------------------------------------------------------------
		public dsZusatzVerlaufAll.ZusatzWertDataTable ReadVerlaufOneEintrag(Guid IDPflegeEintrag)
		{
			dsZusatzVerlaufAll1.Clear();
			daZusatzVerlaufOneEintrag.SelectCommand.Parameters[0].Value = IDPflegeEintrag;
			DataBase.Fill(daZusatzVerlaufOneEintrag, dsZusatzVerlaufAll1.ZusatzWert);
			return dsZusatzVerlaufAll1.ZusatzWert;
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPrintZusatzwert));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.daZusatzVerlauf = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzVerlaufAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daZusatzVerlaufOneEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsZusatzVerlauf1 = new dsZusatzVerlauf();
            this.dsZusatzVerlaufAll1 = new dsZusatzVerlaufAll();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzVerlauf1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzVerlaufAll1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // daZusatzVerlauf
            // 
            this.daZusatzVerlauf.SelectCommand = this.oleDbSelectCommand1;
            this.daZusatzVerlauf.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("Eintrag", "Eintrag"),
                        new System.Data.Common.DataColumnMapping("Massnahme", "Massnahme"),
                        new System.Data.Common.DataColumnMapping("Liste", "Liste"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag")})});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.Date, 8, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 8, "Zeitpunkt"),
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Char, 6, "ID")});
            // 
            // daZusatzVerlaufAll
            // 
            this.daZusatzVerlaufAll.SelectCommand = this.oleDbCommand1;
            this.daZusatzVerlaufAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"),
                        new System.Data.Common.DataColumnMapping("Massnahme", "Massnahme"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // daZusatzVerlaufOneEintrag
            // 
            this.daZusatzVerlaufOneEintrag.SelectCommand = this.oleDbCommand2;
            this.daZusatzVerlaufOneEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("Zeitpunkt", "Zeitpunkt"),
                        new System.Data.Common.DataColumnMapping("ZahlenWert", "ZahlenWert"),
                        new System.Data.Common.DataColumnMapping("Wert", "Wert"),
                        new System.Data.Common.DataColumnMapping("IDZusatzEintrag", "IDZusatzEintrag"),
                        new System.Data.Common.DataColumnMapping("Massnahme", "Massnahme"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("Benutzer", "Benutzer"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("DurchgefuehrtJN", "DurchgefuehrtJN"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // dsZusatzVerlauf1
            // 
            this.dsZusatzVerlauf1.DataSetName = "dsZusatzVerlauf";
            this.dsZusatzVerlauf1.Locale = new System.Globalization.CultureInfo("de-AT");
            this.dsZusatzVerlauf1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsZusatzVerlaufAll1
            // 
            this.dsZusatzVerlaufAll1.DataSetName = "dsZusatzVerlaufAll";
            this.dsZusatzVerlaufAll1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsZusatzVerlaufAll1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzVerlauf1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsZusatzVerlaufAll1)).EndInit();

		}
		#endregion
	}
}
