//----------------------------------------------------------------------------
/// <summary>
///	DBReport.cs
/// Erstellt am:	18.1.2005
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;

namespace PMDS.Print.DB
{



	public class DBReport : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private dsRepPflegebericht dsRepPflegebericht1;
		private System.Data.OleDb.OleDbDataAdapter daPflegeberichtByAufenthalt;
		private System.Data.OleDb.OleDbDataAdapter daPflegebriefByAufenthalt;
		private System.Data.OleDb.OleDbCommand oleDbCommand1;
		private dsRepPflegebrief dsRepPflegebrief1;
		private System.Data.OleDb.OleDbDataAdapter daPatientByAufenthalt;
		private System.Data.OleDb.OleDbCommand oleDbCommand2;
		private System.Data.OleDb.OleDbDataAdapter daAbteilungByID;
		private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbDataAdapter daEinrichtungByID;
		private System.Data.OleDb.OleDbCommand oleDbCommand4;
		private System.Data.OleDb.OleDbDataAdapter daOffeneTermineByAufenthalt;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBReport()
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
			this.daPflegebriefByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsRepPflegebrief1 = new dsRepPflegebrief();
			this.daPatientByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
			this.daAbteilungByID = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
			this.daEinrichtungByID = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
			this.daOffeneTermineByAufenthalt = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebericht1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebrief1)).BeginInit();
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Auto Translate=True;User ID=eddi;Tag with column collation when possible=False;Data Source=REINI3GHZ;Password=eddi;Initial Catalog=PMDS_eddi;Use Procedure for Prepare=1;Provider=""SQLOLEDB.1"";Persist Security Info=True;Workstation ID=REINIGHZ;Use Encryption for Data=False;Packet Size=4096";
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
																																																							 new System.Data.Common.DataColumnMapping("Ersteller", "Ersteller")})});
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = @"SELECT Patient.ID, Patient.Vorname, Patient.Nachname, Patient.Geburtsdatum, Aufenthalt.Aufnahmezeitpunkt, PflegeEintrag.Zeitpunkt, PflegeEintrag.Text, PflegePlan.Text AS PDx, Benutzer.Nachname + ' ' + Benutzer.Vorname AS Ersteller FROM Patient INNER JOIN Aufenthalt ON Patient.ID = Aufenthalt.IDPatient INNER JOIN PflegeEintrag ON Aufenthalt.ID = PflegeEintrag.IDAufenthalt INNER JOIN Benutzer ON PflegeEintrag.IDBenutzer = Benutzer.ID LEFT OUTER JOIN PflegePlan ON PflegeEintrag.IDPflegePlan = PflegePlan.ID WHERE (Aufenthalt.ID = ?) ORDER BY PflegeEintrag.Zeitpunkt";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			// 
			// dsRepPflegebericht1
			// 
			this.dsRepPflegebericht1.DataSetName = "dsRepPflegebericht";
			this.dsRepPflegebericht1.Locale = new System.Globalization.CultureInfo("de-AT");
			// 
			// daPflegebriefByAufenthalt
			// 
			this.daPflegebriefByAufenthalt.SelectCommand = this.oleDbCommand1;
			this.daPflegebriefByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												new System.Data.Common.DataTableMapping("Table", "Brief", new System.Data.Common.DataColumnMapping[] {
																																																						 new System.Data.Common.DataColumnMapping("AufenthaltID", "AufenthaltID"),
																																																						 new System.Data.Common.DataColumnMapping("PDx", "PDx"),
																																																						 new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
																																																						 new System.Data.Common.DataColumnMapping("DatumBeendet", "DatumBeendet"),
																																																						 new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
																																																						 new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN")})});
			// 
			// oleDbCommand1
			// 
			this.oleDbCommand1.CommandText = @"SELECT AufenthaltPDx.IDAufenthalt AS AufenthaltID, PDX.Klartext AS PDx, AufenthaltPDx.StartDatum AS DatumErstellt, AufenthaltPDx.EndeDatum AS DatumBeendet, AufenthaltPDx.ErledigtGrund, AufenthaltPDx.ErledigtJN FROM AufenthaltPDx INNER JOIN PDX ON AufenthaltPDx.IDPDX = PDX.ID WHERE (AufenthaltPDx.IDAufenthalt = ?) ORDER BY AufenthaltPDx.StartDatum";
			this.oleDbCommand1.Connection = this.oleDbConnection1;
			this.oleDbCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "AufenthaltID"));
			// 
			// dsRepPflegebrief1
			// 
			this.dsRepPflegebrief1.DataSetName = "dsRepPflegebrief";
			this.dsRepPflegebrief1.Locale = new System.Globalization.CultureInfo("de-DE");
			// 
			// daPatientByAufenthalt
			// 
			this.daPatientByAufenthalt.SelectCommand = this.oleDbCommand2;
			this.daPatientByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "Patient", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("AufenthaltID", "AufenthaltID"),
																																																					   new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																					   new System.Data.Common.DataColumnMapping("Vorname", "Vorname"),
																																																					   new System.Data.Common.DataColumnMapping("Nachname", "Nachname"),
																																																					   new System.Data.Common.DataColumnMapping("Geburtsdatum", "Geburtsdatum"),
																																																					   new System.Data.Common.DataColumnMapping("Aufnahmezeitpunkt", "Aufnahmezeitpunkt"),
																																																					   new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
																																																					   new System.Data.Common.DataColumnMapping("Plz", "Plz"),
																																																					   new System.Data.Common.DataColumnMapping("Ort", "Ort")})});
			// 
			// oleDbCommand2
			// 
			this.oleDbCommand2.CommandText = @"SELECT Aufenthalt.ID AS AufenthaltID, Patient.ID, Patient.Vorname, Patient.Nachname, Patient.Geburtsdatum, Aufenthalt.Aufnahmezeitpunkt, Adresse.Strasse, Adresse.Plz, Adresse.Ort FROM Patient INNER JOIN Aufenthalt ON Patient.ID = Aufenthalt.IDPatient INNER JOIN Adresse ON Patient.IDAdresse = Adresse.ID WHERE (Aufenthalt.ID = ?)";
			this.oleDbCommand2.Connection = this.oleDbConnection1;
			this.oleDbCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "AufenthaltID"));
			// 
			// daAbteilungByID
			// 
			this.daAbteilungByID.SelectCommand = this.oleDbCommand3;
			this.daAbteilungByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Abteilung", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("Klinik", "Klinik"),
																																																				   new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
																																																				   new System.Data.Common.DataColumnMapping("Plz", "Plz"),
																																																				   new System.Data.Common.DataColumnMapping("Ort", "Ort"),
																																																				   new System.Data.Common.DataColumnMapping("Abteilung", "Abteilung"),
																																																				   new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
																																																				   new System.Data.Common.DataColumnMapping("Tel", "Tel"),
																																																				   new System.Data.Common.DataColumnMapping("Fax", "Fax"),
																																																				   new System.Data.Common.DataColumnMapping("Email", "Email")})});
			// 
			// oleDbCommand3
			// 
			this.oleDbCommand3.CommandText = @"SELECT Klinik.Bezeichnung AS Klinik, Adresse.Strasse, Adresse.Plz, Adresse.Ort, Abteilung.Bezeichnung AS Abteilung, Kontakt.Ansprechpartner, Kontakt.Tel, Kontakt.Fax, Kontakt.Email, ZusatzWert.RawFormat AS Logo FROM ZusatzWert INNER JOIN ZusatzGruppeEintrag ON ZusatzWert.IDZusatzGruppeEintrag = ZusatzGruppeEintrag.ID AND ZusatzGruppeEintrag.IDZusatzGruppe = 'KLI' AND ZusatzGruppeEintrag.IDZusatzEintrag = 'KLOGO' AND ZusatzGruppeEintrag.IDObjekt = '{00000000-0000-0000-0000-000000000000}' RIGHT OUTER JOIN Abteilung INNER JOIN Klinik ON Abteilung.IDKlinik = Klinik.ID INNER JOIN Adresse ON Klinik.IDAdresse = Adresse.ID INNER JOIN Kontakt ON Abteilung.IDKontakt = Kontakt.ID ON ZusatzGruppeEintrag.IDObjekt = Klinik.ID WHERE (Abteilung.ID = ?)";
			this.oleDbCommand3.Connection = this.oleDbConnection1;
			this.oleDbCommand3.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			// 
			// daEinrichtungByID
			// 
			this.daEinrichtungByID.SelectCommand = this.oleDbCommand4;
			this.daEinrichtungByID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										new System.Data.Common.DataTableMapping("Table", "Einrichtung", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Einrichtung", "Einrichtung"),
																																																					   new System.Data.Common.DataColumnMapping("Strasse", "Strasse"),
																																																					   new System.Data.Common.DataColumnMapping("Plz", "Plz"),
																																																					   new System.Data.Common.DataColumnMapping("Ort", "Ort"),
																																																					   new System.Data.Common.DataColumnMapping("Ansprechpartner", "Ansprechpartner"),
																																																					   new System.Data.Common.DataColumnMapping("Tel", "Tel"),
																																																					   new System.Data.Common.DataColumnMapping("Fax", "Fax"),
																																																					   new System.Data.Common.DataColumnMapping("Mobil", "Mobil"),
																																																					   new System.Data.Common.DataColumnMapping("Andere", "Andere"),
																																																					   new System.Data.Common.DataColumnMapping("Email", "Email"),
																																																					   new System.Data.Common.DataColumnMapping("Zusatz1", "Zusatz1")})});
			// 
			// oleDbCommand4
			// 
			this.oleDbCommand4.CommandText = @"SELECT Einrichtung.Text AS Einrichtung, Adresse.Strasse, Adresse.Plz, Adresse.Ort, Kontakt.Ansprechpartner, Kontakt.Tel, Kontakt.Fax, Kontakt.Mobil, Kontakt.Andere, Kontakt.Email, Kontakt.Zusatz1 FROM Einrichtung INNER JOIN Adresse ON Einrichtung.IDAdresse = Adresse.ID INNER JOIN Kontakt ON Einrichtung.IDKontakt = Kontakt.ID WHERE (Einrichtung.ID = ?)";
			this.oleDbCommand4.Connection = this.oleDbConnection1;
			this.oleDbCommand4.Parameters.Add(new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"));
			// 
			// daOffeneTermineByAufenthalt
			// 
			this.daOffeneTermineByAufenthalt.SelectCommand = this.oleDbSelectCommand2;
			this.daOffeneTermineByAufenthalt.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																												  new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
																																																								new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
																																																								new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
																																																								new System.Data.Common.DataColumnMapping("Text", "Text"),
																																																								new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
																																																								new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
																																																								new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
																																																								new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
																																																								new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
																																																								new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
																																																								new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
																																																								new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
																																																								new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
																																																								new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe")})});
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = @"SELECT StartDatum, LetztesDatum, Text, Anmerkung, Warnhinweis, Intervall, WochenTage, IntervallTyp, EvalTage, EinmaligJN, ErledigtJN, GeloeschtJN, EintragGruppe FROM PflegePlan WHERE (GeloeschtJN = 0) AND (ErledigtJN = 0) AND (EintragGruppe = 'T') AND (IDAufenthalt = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"));
			// 
			// oleDbConnection2
			// 
			this.oleDbConnection2.ConnectionString = @"Integrated Security=SSPI;Packet Size=4096;Data Source=REINI3GHZ;Tag with column collation when possible=False;Initial Catalog=PMDS;Use Procedure for Prepare=1;Auto Translate=True;Persist Security Info=False;Provider=""SQLOLEDB.1"";Workstation ID=REINI3GHZ;Use Encryption for Data=False";
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebericht1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRepPflegebrief1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary>
		/// Pflegebericht anhand des Aufenthalts ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsRepPflegebericht PflegeberichtByAufenthalt(Guid id)
		{
			dsRepPflegebericht ds = new dsRepPflegebericht();
			daPflegeberichtByAufenthalt.SelectCommand.Parameters[0].Value = id;
            RBU.DataBase.Fill(daPflegeberichtByAufenthalt, ds.Bericht);
			return ds;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Pflegebrief anhand des Aufenthalts ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public dsRepPflegebrief PflegebriefByAufenthalt(Guid id, Guid idAbteilung, Guid idEinrichtung)
		{
			dsRepPflegebrief ds = new dsRepPflegebrief();

			daPatientByAufenthalt.SelectCommand.Parameters[0].Value = id;
            RBU.DataBase.Fill(daPatientByAufenthalt, ds.Patient);

			daPflegebriefByAufenthalt.SelectCommand.Parameters[0].Value = id;
            RBU.DataBase.Fill(daPflegebriefByAufenthalt, ds.Brief);

			daAbteilungByID.SelectCommand.Parameters[0].Value = idAbteilung;
            RBU.DataBase.Fill(daAbteilungByID, ds.Abteilung);

			daEinrichtungByID.SelectCommand.Parameters[0].Value = idEinrichtung;
            RBU.DataBase.Fill(daEinrichtungByID, ds.Einrichtung);
			
			daOffeneTermineByAufenthalt.SelectCommand.Parameters[0].Value = id;
            RBU.DataBase.Fill(daOffeneTermineByAufenthalt, ds.PflegePlan);

			return ds;
		}
	}
}
