//----------------------------------------------------------------------------
/// <summary>
///	DBPrintPflegebericht.cs
/// Erstellt am:	14.3.2005
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

using RBU;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Datenbankklasse für den Zugriff auf Report-Informationen
	/// Die Exceptions müssen von Caller verarbeitet werden
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPrintPflegebericht : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private dsRepPflegebericht dsRepPflegebericht1;
		private System.Data.OleDb.OleDbDataAdapter daPflegeberichtByAufenthalt;
		private System.Data.OleDb.OleDbDataAdapter daPflegeberichtByAufenthaltDate;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private dsRepAufgabe dsRepAufgabe1;
		private System.Data.OleDb.OleDbDataAdapter daRepAufgabe;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPrintPflegebericht()
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
			this.daPflegeberichtByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsRepPflegebericht1 = new dsRepPflegebericht();
			this.daPflegeberichtByAufenthaltDate = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
			this.daRepAufgabe = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsRepAufgabe1 = new dsRepAufgabe();
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebericht1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRepAufgabe1)).BeginInit();
			// 
			// oleDbConnection1
			// 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
			// 
			// daPflegeberichtByAufenthalt
			// 
			this.daPflegeberichtByAufenthalt.SelectCommand = this.oleDbSelectCommand1;
			this.daPflegeberichtByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
			new System.Data.Common.DataTableMapping("Table", "Bericht", new System.Data.Common.DataColumnMapping[] {
			new System.Data.Common.DataColumnMapping("ID", "ID"),
			new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
			new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
			new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
			new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
			new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
			new System.Data.Common.DataColumnMapping("Text", "Text"),
			new System.Data.Common.DataColumnMapping("PDx", "PDx"),
			new System.Data.Common.DataColumnMapping("Ersteller", "Ersteller"),
			new System.Data.Common.DataColumnMapping("IDPflegeEintrag", "IDPflegeEintrag")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT Patient.ID, Patient.Vorname, Patient.Nachname, Patient.Geburtsdatum, Aufenthalt.Aufnahmezeitpunkt, PflegeEintrag.Zeitpunkt, PflegeEintrag.Text, PflegePlan.Text AS PflegePlanText, Benutzer.Nachname + ' ' + Benutzer.Vorname AS Ersteller, Eintrag.Text AS EintragText, PflegePlan.OriginalJN, PflegePlan.EintragGruppe, PflegeEintrag.IDAufenthalt, Benutzer.Benutzer, PflegeEintrag.ID AS IDPflegeEintrag, PflegeEintrag.EintragsTyp FROM Patient INNER JOIN Aufenthalt ON Patient.ID = Aufenthalt.IDPatient INNER JOIN PflegeEintrag ON Aufenthalt.ID = PflegeEintrag.IDAufenthalt INNER JOIN Benutzer ON PflegeEintrag.IDBenutzer = Benutzer.ID LEFT OUTER JOIN Eintrag ON PflegeEintrag.IDEintrag = Eintrag.ID LEFT OUTER JOIN PflegePlan ON PflegeEintrag.IDPflegePlan = PflegePlan.ID WHERE (Aufenthalt.ID = ?) ORDER BY PflegeEintrag.Zeitpunkt";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			// 
			// dsRepPflegebericht1
			// 
			this.dsRepPflegebericht1.DataSetName = "dsRepPflegebericht";
			this.dsRepPflegebericht1.Locale = new System.Globalization.CultureInfo("de-AT");
			// 
			// daPflegeberichtByAufenthaltDate
			// 
			this.daPflegeberichtByAufenthaltDate.SelectCommand = this.oleDbCommand1;
			this.daPflegeberichtByAufenthaltDate.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																													  new System.Data.Common.DataTableMapping("Table", "Bericht", new System.Data.Common.DataColumnMapping[] {
																																																								 new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																								 new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
																																																								 new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
																																																								 new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
																																																								 new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
																																																								 new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
																																																								 new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																								 new System.Data.Common.DataColumnMapping("PDx", "PDx"),
																																																								 new System.Data.Common.DataColumnMapping("Ersteller", "Ersteller"),
																																																								 new System.Data.Common.DataColumnMapping("IDPflegeEintrag", "IDPflegeEintrag")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = @"SELECT Patient.ID, Patient.Vorname, Patient.Nachname, Patient.Geburtsdatum, Aufenthalt.Aufnahmezeitpunkt, PflegeEintrag.Zeitpunkt, PflegeEintrag.Text, PflegePlan.Text AS PflegePlanText, Benutzer.Nachname + ' ' + Benutzer.Vorname AS Ersteller, Eintrag.Text AS EintragText, PflegePlan.OriginalJN, PflegePlan.EintragGruppe, PflegeEintrag.IDAufenthalt, Benutzer.Benutzer, PflegeEintrag.ID AS IDPflegeEintrag, PflegeEintrag.EintragsTyp FROM Patient INNER JOIN Aufenthalt ON Patient.ID = Aufenthalt.IDPatient INNER JOIN PflegeEintrag ON Aufenthalt.ID = PflegeEintrag.IDAufenthalt INNER JOIN Benutzer ON PflegeEintrag.IDBenutzer = Benutzer.ID LEFT OUTER JOIN Eintrag ON PflegeEintrag.IDEintrag = Eintrag.ID LEFT OUTER JOIN PflegePlan ON PflegeEintrag.IDPflegePlan = PflegePlan.ID WHERE (Aufenthalt.ID = ?) AND (PflegeEintrag.Zeitpunkt >= ?) AND (PflegeEintrag.Zeitpunkt <= ?) ORDER BY PflegeEintrag.Zeitpunkt";
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Zeitpunkt", System.Data.OleDb.OleDbType.Date, 8, "Zeitpunkt"));
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Zeitpunkt1", System.Data.OleDb.OleDbType.Date, 8, "Zeitpunkt"));
			// 
			// daRepAufgabe
			// 
			this.daRepAufgabe.SelectCommand = this.oleDbCommand2;
			this.daRepAufgabe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								   new System.Data.Common.DataTableMapping("Table", "Aufgabe", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																			  new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
																																																			  new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																			  new System.Data.Common.DataColumnMapping("Bemerkung", "Bemerkung"),
																																																			  new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
																																																			  new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
																																																			  new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
																																																			  new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
																																																			  new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
																																																			  new System.Data.Common.DataColumnMapping("TextErledigt", "TextErledigt")})});
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = @"SELECT Aufgabe.ID, Aufgabe.IDAufenthalt, Aufgabe.Text, Aufgabe.Bemerkung, Aufgabe.DatumErstellt, Aufgabe.DatumGeaendert, Aufgabe.ErledigtJN, Aufgabe.TextErledigt, Benutzer.Benutzer AS BenutzerErstellt, Benutzer_1.Benutzer AS BenutzerBeendet FROM Aufgabe LEFT OUTER JOIN Benutzer Benutzer_1 ON Aufgabe.IDBenutzer_Beendet = Benutzer_1.ID LEFT OUTER JOIN Benutzer ON Aufgabe.IDBenutzer_Erstellt = Benutzer.ID WHERE (Aufgabe.IDAufenthalt = ?)";
			this.oleDbCommand2.Connection = this.oleDbConnection1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			// 
			// dsRepAufgabe1
			// 
			this.dsRepAufgabe1.DataSetName = "dsRepAufgabe";
			this.dsRepAufgabe1.Locale = new System.Globalization.CultureInfo("de-DE");
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebericht1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRepAufgabe1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest alle Aufgaben zu einem Aufenthalt
		/// bClearDataset == true ==> dataset vorher löschen sonst zu dataset hinzufügen
		/// </summary>
		//----------------------------------------------------------------------------
		public void ReadAufgabeByAufenthalt(Guid IDAufenthalt)
		{
			daRepAufgabe.SelectCommand.Parameters[0].Value = IDAufenthalt;
			DataBase.Fill(daRepAufgabe, dsRepAufgabe1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die aufbereiteten Aufgaben als Datatable
		/// </summary>
		//----------------------------------------------------------------------------
		public dsRepAufgabe.AufgabeDataTable	AUFGBEDATATABLE 
		{
			get 
			{
				return dsRepAufgabe1.Aufgabe;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Pflegebericht anhand des Aufenthalts ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public void ReadPflegeberichtByAufenthalt(Guid id)
		{
			daPflegeberichtByAufenthalt.SelectCommand.Parameters[0].Value = id;
			DataBase.Fill(daPflegeberichtByAufenthalt, dsRepPflegebericht1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die Tabelle Bericht
		/// </summary>
		//----------------------------------------------------------------------------
		public dsRepPflegebericht.BerichtDataTable BERICHTDATATABLE 
		{
			get 
			{
				return dsRepPflegebericht1.Bericht;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// leert das Dataset Pflegebericht und Aufgabe
		/// </summary>
		//----------------------------------------------------------------------------
		public void ClearDataset() 
		{
			dsRepPflegebericht1.Clear();
			dsRepAufgabe1.Clear();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Pflegebericht anhand des Aufenthalts ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public void ReadPflegeberichtByAufenthaltDate(Guid id, DateTime dtFrom, DateTime dtTo)
		{
			daPflegeberichtByAufenthaltDate.SelectCommand.Parameters[0].Value = id;
			daPflegeberichtByAufenthaltDate.SelectCommand.Parameters[1].Value = dtFrom;
			daPflegeberichtByAufenthaltDate.SelectCommand.Parameters[2].Value = dtTo;
			DataBase.Fill(daPflegeberichtByAufenthaltDate, dsRepPflegebericht1);
		}

	}
}
