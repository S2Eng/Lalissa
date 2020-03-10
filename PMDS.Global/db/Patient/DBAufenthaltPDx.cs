//----------------------------------------------------------------------------------------------
//	DBPflegePlanPDx.cs
//  Zugriffsfunktionen auf die einem Aufenthalt zugeordneten PDx bezogen auf einen A
//  Erstellt am:	14.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Text;

using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.DB;
using System.Data.OleDb;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DBPflegeplan
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBAufenthaltPDx : System.ComponentModel.Component
	{
		private Guid			_IDAufenthalt;

		private System.Data.OleDb.OleDbDataAdapter daAufenthaltPDx;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsAufenthaltPDx dsAufenthaltPDx1;
        private OleDbDataAdapter daAufenthaltPDxWundeJN;
        private OleDbCommand oleDbCommand1;
        private OleDbCommand oleDbCommand2;
        private OleDbCommand oleDbCommand3;
        private OleDbCommand oleDbCommand4;
		private System.ComponentModel.Container components = null;

		public DBAufenthaltPDx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBAufenthaltPDx()
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
		/// Liefert true wenn die lokalisierung übereinstimmt oder true wenn 
		/// es sich um eine nicht lokalisierte geschichte handelt
		/// </summary>
		//----------------------------------------------------------------------------
		private bool IsLokalisiert(dsAufenthaltPDx.AufenthaltPDxRow rs, ASZMSelectionArgs args)
		{
			if(rs.Lokalisierung.Trim() == args.Lokalisierung.Trim() && rs.LokalisierungSeite.Trim() == args.LokalisierungSeite.Trim())
				return true;
			else
				return false;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Fügt einen neuen Eintrag in die DB ein
		/// Zusammenhang: Wenn in PflegePlan ein neuer Eintrag gemacht wird dann
		/// muss hier ein neuer Datensatz erstellt werden der den Zusammenhang
		/// zwischen dem Aufenthalt und der zugehörigen PDx herstellt.
		/// Es wird die IDAufenthaltPDx geliefert (wird benutzt um die Verbindung zum PflegeplanPDx herzustellen)
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid InsertPPEntry(ASZMSelectionArgs args, Guid IDUser, Guid IDPflegePlan) 
		{
			// Den Eintrg nur hinzufügen wenns die Konbination IDEintrag + IDPDx + lokalisierung noch nicht gibt.
			bool bFound = false;
			Guid IDRet = Guid.Empty;
			foreach(dsAufenthaltPDx.AufenthaltPDxRow rs in dsAufenthaltPDx1.AufenthaltPDx) 
			{
				if(rs.IDPDX == args.IDPDX && rs.ErledigtJN == false && IsLokalisiert(rs, args))  
				{
					bFound = true;
					IDRet = rs.ID;
					if(rs.StartDatum > args.StartDatum)			// Wenn ein Jüngerer Eintrag gemacht wird dann Datum aktualisieren
						rs.StartDatum = args.StartDatum.Date;
					break;
				}
			}

			if(!bFound)
			{
				dsAufenthaltPDx.AufenthaltPDxRow r = dsAufenthaltPDx1.AufenthaltPDx.NewAufenthaltPDxRow();
				r.SetEndeDatumNull();
				r.SetIDBenutzer_BeendetNull();
                
                // 28.3.2007 mda Erweiterung 
                if (ENV.EvaluierungsTyp == EvaluierungsTypen.PDX && args.EvalStartDatum != new DateTime(1900, 1, 1))
                    r.NaechsteEvaluierung = args.EvalStartDatum;
                else
                    r.SetNaechsteEvaluierungNull();

                r.ID					        = Guid.NewGuid();
				r.IDAufenthalt			        = _IDAufenthalt;
				r.DatumErstellt			        = DateTime.Now;
				r.StartDatum			        = args.StartDatum;
				r.ErledigtGrund			        = "";
				r.ErledigtJN			        = false;
				r.IDAufenthalt			        = _IDAufenthalt;			
				r.IDBenutzer_Erstellt	        = IDUser;
				r.IDPDX					        = args.IDPDX;
				r.LokalisierungJN		        = args.LokalisierungJN;
				r.Lokalisierung			        = args.Lokalisierung.Trim();
				r.LokalisierungSeite	        = args.LokalisierungSeite.Trim();
                r.resourceklient                = "";
                r.NaechsteEvaluierungBemerkung  = args.EvalBemerkung;

				// Felder die erst beim lesen ergänzt werden würden füllen
				DBPDx db = new DBPDx();
				dsPDx.PDXRow rp = db.ReadOne(r.IDPDX);

				r.Klartext				= rp.Klartext;
				r.EntferntJN			= rp.EntferntJN;
				r.Code					= rp.Code;
				r.ThematischeID			= rp.ThematischeID;
				r.Definition			= rp.Definition;
                r.Gruppe                = rp.Gruppe;
                r.resourceklient        = args.Resourceklient; //Neu nach 14.05.2007 MDA: Ressouce übernehmen
                r.WundeJN               = args.WundeJN;
				

				dsAufenthaltPDx1.AufenthaltPDx.AddAufenthaltPDxRow(r);
				IDRet = r.ID;
			}

			return IDRet;
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAufenthaltPDx));
            this.daAufenthaltPDx = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsAufenthaltPDx1 = new PMDS.Data.Patient.dsAufenthaltPDx();
            this.daAufenthaltPDxWundeJN = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltPDx1)).BeginInit();
            // 
            // daAufenthaltPDx
            // 
            this.daAufenthaltPDx.DeleteCommand = this.oleDbDeleteCommand3;
            this.daAufenthaltPDx.InsertCommand = this.oleDbInsertCommand3;
            this.daAufenthaltPDx.SelectCommand = this.oleDbSelectCommand3;
            this.daAufenthaltPDx.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AufenthaltPDx", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("resourceklient", "resourceklient"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung")})});
            this.daAufenthaltPDx.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM AufenthaltPDx WHERE (ID = ?)";
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = resources.GetString("oleDbInsertCommand3.CommandText");
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.Char, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 1, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.Char, 50, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.Char, 50, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("resourceklient", System.Data.OleDb.OleDbType.Char, 2048, "resourceklient"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 8, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.Char, 255, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 16, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN")});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = resources.GetString("oleDbUpdateCommand3.CommandText");
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.Char, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 1, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.Char, 50, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.Char, 50, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("resourceklient", System.Data.OleDb.OleDbType.Char, 2048, "resourceklient"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 8, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.Char, 255, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 16, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsAufenthaltPDx1
            // 
            this.dsAufenthaltPDx1.DataSetName = "dsAufenthaltPDx";
            this.dsAufenthaltPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsAufenthaltPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAufenthaltPDxWundeJN
            // 
            this.daAufenthaltPDxWundeJN.DeleteCommand = this.oleDbCommand1;
            this.daAufenthaltPDxWundeJN.InsertCommand = this.oleDbCommand2;
            this.daAufenthaltPDxWundeJN.SelectCommand = this.oleDbCommand3;
            this.daAufenthaltPDxWundeJN.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "AufenthaltPDx", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("resourceklient", "resourceklient"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung")})});
            this.daAufenthaltPDxWundeJN.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM AufenthaltPDx WHERE (ID = ?)";
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.oleDbConnection1;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.Char, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 1, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.Char, 50, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.Char, 50, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("resourceklient", System.Data.OleDb.OleDbType.Char, 2048, "resourceklient"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 8, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.Char, 255, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 16, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 8, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 8, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.Char, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 8, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 1, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.Char, 50, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.Char, 50, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("resourceklient", System.Data.OleDb.OleDbType.Char, 2048, "resourceklient"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 8, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.Char, 255, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 16, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN")});
            ((System.ComponentModel.ISupportInitialize)(this.dsAufenthaltPDx1)).EndInit();

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle einem Aufenthalt zugeordneten Zuordnungen von PDx mit den
		/// Einträgen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsAufenthaltPDx.AufenthaltPDxDataTable AUFENTHALTPDX
		{
			get 
			{
				return dsAufenthaltPDx1.AufenthaltPDx;
			}
		}

		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest sämtliche verspeicherten Einträge der PflegePlanPDx welche zu einem
		/// bestimmten Aufenthalt gehören
		/// (Pflegeplan ist immer einen Aufenthalt zugeordnet)
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(Guid IDAufenthalt)
		{
			_IDAufenthalt = IDAufenthalt;
			dsAufenthaltPDx1.Clear();
			daAufenthaltPDx.SelectCommand.Parameters[0].Value = IDAufenthalt;
			DataBase.Fill(daAufenthaltPDx, dsAufenthaltPDx1);
		}

        //Neu nach 12.09.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liest sämtliche verspeicherten Einträge der PflegePlanPDx welche zu einem
        /// bestimmten Aufenthalt gehören
        /// (Pflegeplan ist immer einen Aufenthalt zugeordnet)
        /// Nur Normale PDx'en oder nur Wunden je nach modus werden gelesen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Read(Guid IDAufenthalt, PflegePlanModus modus)
        {
            _IDAufenthalt = IDAufenthalt;
            dsAufenthaltPDx1.Clear();
            daAufenthaltPDxWundeJN.SelectCommand.Parameters[0].Value = IDAufenthalt;
            daAufenthaltPDxWundeJN.SelectCommand.Parameters[1].Value = modus == PflegePlanModus.Normal ? false : true;
            DataBase.Fill(daAufenthaltPDxWundeJN, dsAufenthaltPDx1);
        }

        //----------------------------------------------------------------------------
		/// <summary>
		///	schreibt die Änderungen in die Datenbank
		///	Parameter ist die aktuelle angemeldete Benutzer ID
		///	UserID und ÄnderungsFelder brauchen nicht befüllt zu werden
		///	Eine Historie wird automatisch geschrieben
		/// </summary>
		//----------------------------------------------------------------------------
		public void Write()
		{
            // Wenn sich das System im Evaluierungsmodus befindet, dann muss bei beendeten oder hinzugefügten
            // PDx Datensätzen diese ID mit verspeichert werden
            if (ENV.CurrentIDEvaluierung != Guid.Empty)
            {
                foreach (dsAufenthaltPDx.AufenthaltPDxRow r in dsAufenthaltPDx1.AufenthaltPDx.Rows)
                {
                    if ( (r.RowState == DataRowState.Added) || (r.RowState == DataRowState.Modified && r.ErledigtJN) )
                        r.IDEvaluierung = ENV.CurrentIDEvaluierung;
                }
            }
			DataBase.Update(daAufenthaltPDx, dsAufenthaltPDx1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	Speichert die Beendigung der Pflegeprobleme in die Zuordnungstabelle PDx->Eintrag
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndPDx(PDxLokalisiert[] rpdx, string sReason, DateTime dtEnd)
		{
			foreach(dsAufenthaltPDx.AufenthaltPDxRow r in   dsAufenthaltPDx1.AufenthaltPDx) 
			{
				if(r.ErledigtJN)					// Erledigte ignorieren
					continue;

				foreach(PDxLokalisiert l in rpdx)
				{
					if(r.ID == l._IDAufenthaltPDx)
					{
						r.ErledigtJN			= true;
						r.ErledigtGrund 		= sReason;
						r.EndeDatum				= dtEnd;
						r.DatumGeaendert		= DateTime.Now;
						r.IDBenutzer_Beendet	= ENV.USERID;
					}
				}
			}
		}

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert sämtliche aktuelle in der DB verspeicherten Resourcen eines Aufenhaltes
        /// </summary>
        //----------------------------------------------------------------------------
        public static PDxResource[] GetAllResourceEntries(Guid IDAufenthalt)
        {
            try
            {
                //Ist über Config-Schalter steuerbar. Wird wahrscheinlich gar nicht mehr gebraucht
                List<PDxResource> al = new List<PDxResource>();
                OleDbCommand cmd = new OleDbCommand();
                StringBuilder sb = new StringBuilder();
                sb.Append("Select resourceklient, pdx.Klartext ");
                sb.Append("from AufenthaltPDx inner join Pdx on AufenthaltPdx.IDPDx = Pdx.id ");
                sb.Append("where IDAufenthalt = ? ");
                sb.Append("and (not resourceklient is null) and (not len(resourceklient) = 0) ");
                sb.Append("and AufenthaltPDx.wundeJN=0 ");
                sb.Append("and AufenthaltPDx.ErledigtJN=0 order by klartext");
                cmd.CommandText = sb.ToString();
                cmd.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt);
                cmd.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cmd;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                foreach (System.Data.DataRow r in dtSelect.Rows)
                {
                    string s = r[0].ToString().Trim();
                    if (s.Length > 0)
                    {
                        string Klartext = r[1].ToString().Trim();
                        al.Add(new PDxResource(Klartext, s));
                    }
                }

                return al.ToArray();

            }
            catch (Exception ex)
            {
                throw new Exception("GetAllResourceEntries: " + ex.ToString());
            }
        }

	}

}
