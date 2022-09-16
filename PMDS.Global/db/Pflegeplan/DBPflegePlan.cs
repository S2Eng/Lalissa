//----------------------------------------------------------------------------------------------
//	DBPflegePlan.cs
//  Zugriffsfunktionen auf den Pflegeplan bezogen auf einen Aufenthalt
//  Erstellt am:	14.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.db.Entities;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;
using RBU;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DBPflegeplan
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPflegePlan : System.ComponentModel.Component
	{
		private Guid				_IDAufenthalt;

        private static OleDbCommand     _cmdGetLastRMTime;
        private static OleDbDataAdapter _daGetAllZiele;
        private static OleDbDataAdapter _daGetAllZielePDx;

		private System.Data.OleDb.OleDbDataAdapter daPflegePlan;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbDataAdapter daPflegePlanH;
        private System.Data.OleDb.OleDbDataAdapter daPflegePlanOnce;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbDataAdapter daPflegePlanZusatzEintraege;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand4;
        private dsPflegePlanZusatzEintraege dsPflegePlanZusatzEintraege1;
		private System.Data.OleDb.OleDbDataAdapter dapflegePlanBarcodeID;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand5;
        private OleDbCommand oleDbSelectCommand6;
        private OleDbDataAdapter daPflgePlanZusatzGruppeEintrag;
        public dsPflegePlan dsPflegePlan1;
        private dsPflegePlan dsPflegePlan2;
        private dsPflegePlanH dsPflegePlanH1;
        private OleDbCommand oleDbCommand4;
        private OleDbDataAdapter daPflegePlanWundenJN;
        private OleDbDataAdapter daPflegeplanByEintrag;
        private OleDbCommand oleDbCommand1;
		private System.ComponentModel.Container components = null;

		public DBPflegePlan(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Einen Spendervorbereitungseintrag hinzufügen
		/// </summary>
		//----------------------------------------------------------------------------
		public void InsertSpenderVorbereitung()
		{
			
		}



        public void Write(Guid IDUser, bool bSetChangedUser, bool bWriteHistory)
        {
            DataBase.Update(daPflegePlan, dsPflegePlan1);

            DateTime dNow = DateTime.Now;
            dsPflegePlanH1.Clear();
            foreach (dsPflegePlan.PflegePlanRow r in PFLEGEPLAN_EINTRAEGE.Rows)                                       // Für jeden geänderten / neuen Eintrag einen Eintrag in die Historie schreiben
            {
                if (!(r.RowState == DataRowState.Modified || r.RowState == DataRowState.Added || r.RowState == DataRowState.Deleted))
                    continue;

                string Aktion = "";
                switch (r.RowState)
                {
                    case DataRowState.Added:
                        Aktion = "A";
                        break;
                    case DataRowState.Deleted:
                        Aktion = "D";
                        break;
                    case DataRowState.Modified:
                        Aktion = "C";
                        break;
                }

                PMDS.DB.PMDSBusiness b = new PMDSBusiness();
                b.savePflegeplanH(r.ID, ref Aktion, ref dNow);
            }
        }


		public DBPflegePlan()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPflegePlan));
            this.daPflegePlan = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daPflegePlanH = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daPflegePlanOnce = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPflegePlanZusatzEintraege = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand4 = new System.Data.OleDb.OleDbCommand();
            this.dapflegePlanBarcodeID = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand6 = new System.Data.OleDb.OleDbCommand();
            this.daPflgePlanZusatzGruppeEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.dsPflegePlanZusatzEintraege1 = new PMDS.Global.db.Pflegeplan.dsPflegePlanZusatzEintraege();
            this.dsPflegePlanH1 = new PMDS.Data.PflegePlan.dsPflegePlanH();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daPflegePlanWundenJN = new System.Data.OleDb.OleDbDataAdapter();
            this.daPflegeplanByEintrag = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsPflegePlan1 = new PMDS.Data.PflegePlan.dsPflegePlan();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanZusatzEintraege1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanH1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlan1)).BeginInit();
            // 
            // daPflegePlan
            // 
            this.daPflegePlan.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegePlan.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegePlan.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegePlan.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"),
                        new System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            this.daPflegePlan.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [PflegePlan] WHERE (([ID] = ?) AND ([IDAufenthalt] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV10V;Integrated Security=SSPI;Initial Catalog" +
    "=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OriginalJN"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 16, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 16, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, "LetztesDatum"),
            new System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "LetzteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeloeschtJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, "PDXJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("UntertaegigeJN", System.Data.OleDb.OleDbType.Boolean, 0, "UntertaegigeJN"),
            new System.Data.OleDb.OleDbParameter("SpenderAbgabeJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpenderAbgabeJN"),
            new System.Data.OleDb.OleDbParameter("IDUntertaegigeGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDUntertaegigeGruppe"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"),
            new System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, "ZuErledigenBis"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.Boolean, 0, "wundejn"),
            new System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, "EintragFlag"),
            new System.Data.OleDb.OleDbParameter("NächstesDatum", System.Data.OleDb.OleDbType.Date, 16, "NächstesDatum"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("PrivatJN", System.Data.OleDb.OleDbType.Boolean, 0, "PrivatJN"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("lstIDPDx", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDPDx"),
            new System.Data.OleDb.OleDbParameter("lstPDxBezeichnung", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstPDxBezeichnung"),
            new System.Data.OleDb.OleDbParameter("AnmerkungRtf", System.Data.OleDb.OleDbType.LongVarWChar, 0, "AnmerkungRtf"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("PSEKlasse", System.Data.OleDb.OleDbType.VarWChar, 0, "PSEKlasse")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OriginalJN"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 16, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 16, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, "LetztesDatum"),
            new System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "LetzteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeloeschtJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, "PDXJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("UntertaegigeJN", System.Data.OleDb.OleDbType.Boolean, 0, "UntertaegigeJN"),
            new System.Data.OleDb.OleDbParameter("SpenderAbgabeJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpenderAbgabeJN"),
            new System.Data.OleDb.OleDbParameter("IDUntertaegigeGruppe", System.Data.OleDb.OleDbType.Guid, 0, "IDUntertaegigeGruppe"),
            new System.Data.OleDb.OleDbParameter("IDLinkDokument", System.Data.OleDb.OleDbType.Guid, 0, "IDLinkDokument"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"),
            new System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, "ZuErledigenBis"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.Boolean, 0, "wundejn"),
            new System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, "EintragFlag"),
            new System.Data.OleDb.OleDbParameter("NächstesDatum", System.Data.OleDb.OleDbType.Date, 16, "NächstesDatum"),
            new System.Data.OleDb.OleDbParameter("IDDekurs", System.Data.OleDb.OleDbType.Guid, 0, "IDDekurs"),
            new System.Data.OleDb.OleDbParameter("PrivatJN", System.Data.OleDb.OleDbType.Boolean, 0, "PrivatJN"),
            new System.Data.OleDb.OleDbParameter("IDExtern", System.Data.OleDb.OleDbType.Guid, 0, "IDExtern"),
            new System.Data.OleDb.OleDbParameter("lstIDPDx", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstIDPDx"),
            new System.Data.OleDb.OleDbParameter("lstPDxBezeichnung", System.Data.OleDb.OleDbType.LongVarWChar, 0, "lstPDxBezeichnung"),
            new System.Data.OleDb.OleDbParameter("AnmerkungRtf", System.Data.OleDb.OleDbType.LongVarWChar, 0, "AnmerkungRtf"),
            new System.Data.OleDb.OleDbParameter("IDBefund", System.Data.OleDb.OleDbType.Guid, 0, "IDBefund"),
            new System.Data.OleDb.OleDbParameter("PSEKlasse", System.Data.OleDb.OleDbType.VarWChar, 0, "PSEKlasse"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegePlanH
            // 
            this.daPflegePlanH.DeleteCommand = this.oleDbDeleteCommand2;
            this.daPflegePlanH.InsertCommand = this.oleDbInsertCommand2;
            this.daPflegePlanH.SelectCommand = this.oleDbSelectCommand2;
            this.daPflegePlanH.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlanH", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Aktion", "Aktion"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("IDEvaluierung", "IDEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag")})});
            this.daPflegePlanH.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Aktion", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Aktion", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Aktion", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Aktion", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPflegePlan", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPflegePlan", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPflegePlan", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAufenthalt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDEintrag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OriginalJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OriginalJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OriginalJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumErstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumGeaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_StartDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "StartDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_StartDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "StartDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EndeDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EndeDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EndeDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EndeDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LetztesDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LetztesDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LetztesDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LetzteEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LetzteEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LetzteEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Warnhinweis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Warnhinweis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Warnhinweis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Anmerkung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Anmerkung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Anmerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErledigtGrund", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErledigtGrund", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErledigtGrund", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Text", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Intervall", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Intervall", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Intervall", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Intervall", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_WochenTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "WochenTage", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_WochenTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WochenTage", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IntervallTyp", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IntervallTyp", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EvalTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EvalTage", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EvalTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EvalTage", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBerufsstand", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBerufsstand", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBerufsstand", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ParalellJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParalellJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParalellJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Dauer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Dauer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LokalisierungJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LokalisierungJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EinmaligJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EinmaligJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EinmaligJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErledigtJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErledigtJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErledigtJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GeloeschtJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GeloeschtJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GeloeschtJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Lokalisierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Lokalisierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Lokalisierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LokalisierungSeite", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LokalisierungSeite", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungSeite", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EintragGruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EintragGruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EintragGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PDXJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PDXJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PDXJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RMOptionalJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NaechsteEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierungBemerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OhneZeitBezug", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDZeitbereich", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDZeitbereich", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDZeitbereich", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ZuErledigenBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ZuErledigenBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ZuErledigenBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EintragFlag", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = resources.GetString("oleDbInsertCommand2.CommandText");
            this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OriginalJN"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 16, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 16, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, "LetztesDatum"),
            new System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "LetzteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeloeschtJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, "PDXJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"),
            new System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, "ZuErledigenBis"),
            new System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, "EintragFlag")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer_Geaendert"),
            new System.Data.OleDb.OleDbParameter("OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, "OriginalJN"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, "DatumGeaendert"),
            new System.Data.OleDb.OleDbParameter("StartDatum", System.Data.OleDb.OleDbType.Date, 16, "StartDatum"),
            new System.Data.OleDb.OleDbParameter("EndeDatum", System.Data.OleDb.OleDbType.Date, 16, "EndeDatum"),
            new System.Data.OleDb.OleDbParameter("LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, "LetztesDatum"),
            new System.Data.OleDb.OleDbParameter("LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "LetzteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, "Warnhinweis"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("Text", System.Data.OleDb.OleDbType.VarChar, 0, "Text"),
            new System.Data.OleDb.OleDbParameter("Intervall", System.Data.OleDb.OleDbType.Integer, 0, "Intervall"),
            new System.Data.OleDb.OleDbParameter("WochenTage", System.Data.OleDb.OleDbType.Integer, 0, "WochenTage"),
            new System.Data.OleDb.OleDbParameter("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, "IntervallTyp"),
            new System.Data.OleDb.OleDbParameter("EvalTage", System.Data.OleDb.OleDbType.Integer, 0, "EvalTage"),
            new System.Data.OleDb.OleDbParameter("IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, "IDBerufsstand"),
            new System.Data.OleDb.OleDbParameter("ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, "ParalellJN"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "LokalisierungJN"),
            new System.Data.OleDb.OleDbParameter("EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, "EinmaligJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeloeschtJN"),
            new System.Data.OleDb.OleDbParameter("Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, "Lokalisierung"),
            new System.Data.OleDb.OleDbParameter("LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, "LokalisierungSeite"),
            new System.Data.OleDb.OleDbParameter("EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, "EintragGruppe"),
            new System.Data.OleDb.OleDbParameter("PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, "PDXJN"),
            new System.Data.OleDb.OleDbParameter("RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, "RMOptionalJN"),
            new System.Data.OleDb.OleDbParameter("IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, "IDEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, "NaechsteEvaluierung"),
            new System.Data.OleDb.OleDbParameter("NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, "NaechsteEvaluierungBemerkung"),
            new System.Data.OleDb.OleDbParameter("OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, "OhneZeitBezug"),
            new System.Data.OleDb.OleDbParameter("IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, "IDZeitbereich"),
            new System.Data.OleDb.OleDbParameter("ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, "ZuErledigenBis"),
            new System.Data.OleDb.OleDbParameter("EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, "EintragFlag"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Aktion", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Aktion", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Aktion", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Aktion", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDPflegePlan", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDPflegePlan", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPflegePlan", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDAufenthalt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAufenthalt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDEintrag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDEintrag", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEintrag", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Erstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBenutzer_Geaendert", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBenutzer_Geaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_OriginalJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "OriginalJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_OriginalJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OriginalJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumErstellt", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumErstellt", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumErstellt", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_DatumGeaendert", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_DatumGeaendert", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "DatumGeaendert", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_StartDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "StartDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_StartDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "StartDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EndeDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EndeDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EndeDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EndeDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LetztesDatum", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LetztesDatum", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LetztesDatum", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LetztesDatum", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LetzteEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LetzteEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LetzteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LetzteEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Warnhinweis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Warnhinweis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Warnhinweis", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Warnhinweis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Anmerkung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Anmerkung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Anmerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErledigtGrund", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErledigtGrund", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErledigtGrund", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Text", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Text", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Text", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Intervall", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Intervall", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Intervall", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Intervall", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_WochenTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "WochenTage", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_WochenTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WochenTage", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IntervallTyp", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IntervallTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IntervallTyp", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EvalTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EvalTage", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EvalTage", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EvalTage", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDBerufsstand", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDBerufsstand", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDBerufsstand", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDBerufsstand", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ParalellJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ParalellJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ParalellJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ParalellJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Dauer", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Dauer", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LokalisierungJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LokalisierungJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EinmaligJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EinmaligJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EinmaligJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EinmaligJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ErledigtJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ErledigtJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ErledigtJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_GeloeschtJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GeloeschtJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_GeloeschtJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GeloeschtJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Lokalisierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Lokalisierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Lokalisierung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Lokalisierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_LokalisierungSeite", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "LokalisierungSeite", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungSeite", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungSeite", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EintragGruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EintragGruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EintragGruppe", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EintragGruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_PDXJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "PDXJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_PDXJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PDXJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_RMOptionalJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "RMOptionalJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDEvaluierung", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_NaechsteEvaluierung", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierung", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_NaechsteEvaluierung", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_NaechsteEvaluierungBemerkung", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "NaechsteEvaluierungBemerkung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_OhneZeitBezug", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "OhneZeitBezug", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_IDZeitbereich", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IDZeitbereich", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_IDZeitbereich", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDZeitbereich", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ZuErledigenBis", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ZuErledigenBis", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ZuErledigenBis", System.Data.OleDb.OleDbType.Date, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ZuErledigenBis", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_EintragFlag", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EintragFlag", System.Data.DataRowVersion.Original, null)});
            // 
            // daPflegePlanOnce
            // 
            this.daPflegePlanOnce.SelectCommand = this.oleDbSelectCommand3;
            this.daPflegePlanOnce.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"),
                        new System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daPflegePlanZusatzEintraege
            // 
            this.daPflegePlanZusatzEintraege.SelectCommand = this.oleDbSelectCommand4;
            this.daPflegePlanZusatzEintraege.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("MinValue", "MinValue"),
                        new System.Data.Common.DataColumnMapping("MaxValue", "MaxValue")})});
            // 
            // oleDbSelectCommand4
            // 
            this.oleDbSelectCommand4.CommandText = resources.GetString("oleDbSelectCommand4.CommandText");
            this.oleDbSelectCommand4.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // dapflegePlanBarcodeID
            // 
            this.dapflegePlanBarcodeID.SelectCommand = this.oleDbSelectCommand5;
            this.dapflegePlanBarcodeID.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("BarcodeID", "BarcodeID")})});
            // 
            // oleDbSelectCommand5
            // 
            this.oleDbSelectCommand5.CommandText = "SELECT ID, BarcodeID, CAST(NULL AS DateTime) AS Zeitpunkt FROM PflegePlan WHERE (" +
    "ID = ?)";
            this.oleDbSelectCommand5.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbSelectCommand6
            // 
            this.oleDbSelectCommand6.CommandText = resources.GetString("oleDbSelectCommand6.CommandText");
            this.oleDbSelectCommand6.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDObjekt", System.Data.OleDb.OleDbType.Guid, 16, "IDObjekt")});
            // 
            // daPflgePlanZusatzGruppeEintrag
            // 
            this.daPflgePlanZusatzGruppeEintrag.SelectCommand = this.oleDbSelectCommand6;
            this.daPflgePlanZusatzGruppeEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung"),
                        new System.Data.Common.DataColumnMapping("Typ", "Typ"),
                        new System.Data.Common.DataColumnMapping("ListenEintraege", "ListenEintraege"),
                        new System.Data.Common.DataColumnMapping("MinValue", "MinValue"),
                        new System.Data.Common.DataColumnMapping("MaxValue", "MaxValue"),
                        new System.Data.Common.DataColumnMapping("FeldNr", "FeldNr"),
                        new System.Data.Common.DataColumnMapping("OptionalJN", "OptionalJN"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe")})});
            // 
            // dsPflegePlanZusatzEintraege1
            // 
            this.dsPflegePlanZusatzEintraege1.DataSetName = "dsPflegePlanZusatzEintraege";
            this.dsPflegePlanZusatzEintraege1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlanZusatzEintraege1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPflegePlanH1
            // 
            this.dsPflegePlanH1.DataSetName = "dsPflegePlanH";
            this.dsPflegePlanH1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlanH1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.Boolean, 1, "wundejn")});
            // 
            // daPflegePlanWundenJN
            // 
            this.daPflegePlanWundenJN.SelectCommand = this.oleDbCommand4;
            this.daPflegePlanWundenJN.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"),
                        new System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // daPflegeplanByEintrag
            // 
            this.daPflegeplanByEintrag.SelectCommand = this.oleDbCommand1;
            this.daPflegeplanByEintrag.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlan", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Geaendert", "IDBenutzer_Geaendert"),
                        new System.Data.Common.DataColumnMapping("OriginalJN", "OriginalJN"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumGeaendert", "DatumGeaendert"),
                        new System.Data.Common.DataColumnMapping("StartDatum", "StartDatum"),
                        new System.Data.Common.DataColumnMapping("EndeDatum", "EndeDatum"),
                        new System.Data.Common.DataColumnMapping("LetztesDatum", "LetztesDatum"),
                        new System.Data.Common.DataColumnMapping("LetzteEvaluierung", "LetzteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("Text", "Text"),
                        new System.Data.Common.DataColumnMapping("Intervall", "Intervall"),
                        new System.Data.Common.DataColumnMapping("WochenTage", "WochenTage"),
                        new System.Data.Common.DataColumnMapping("IntervallTyp", "IntervallTyp"),
                        new System.Data.Common.DataColumnMapping("EvalTage", "EvalTage"),
                        new System.Data.Common.DataColumnMapping("IDBerufsstand", "IDBerufsstand"),
                        new System.Data.Common.DataColumnMapping("ParalellJN", "ParalellJN"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("LokalisierungJN", "LokalisierungJN"),
                        new System.Data.Common.DataColumnMapping("EinmaligJN", "EinmaligJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("GeloeschtJN", "GeloeschtJN"),
                        new System.Data.Common.DataColumnMapping("Lokalisierung", "Lokalisierung"),
                        new System.Data.Common.DataColumnMapping("LokalisierungSeite", "LokalisierungSeite"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("PDXJN", "PDXJN"),
                        new System.Data.Common.DataColumnMapping("RMOptionalJN", "RMOptionalJN"),
                        new System.Data.Common.DataColumnMapping("UntertaegigeJN", "UntertaegigeJN"),
                        new System.Data.Common.DataColumnMapping("SpenderAbgabeJN", "SpenderAbgabeJN"),
                        new System.Data.Common.DataColumnMapping("IDUntertaegigeGruppe", "IDUntertaegigeGruppe"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierung", "NaechsteEvaluierung"),
                        new System.Data.Common.DataColumnMapping("NaechsteEvaluierungBemerkung", "NaechsteEvaluierungBemerkung"),
                        new System.Data.Common.DataColumnMapping("IDZeitbereich", "IDZeitbereich"),
                        new System.Data.Common.DataColumnMapping("ZuErledigenBis", "ZuErledigenBis"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug"),
                        new System.Data.Common.DataColumnMapping("wundejn", "wundejn"),
                        new System.Data.Common.DataColumnMapping("EintragFlag", "EintragFlag"),
                        new System.Data.Common.DataColumnMapping("NächstesDatum", "NächstesDatum"),
                        new System.Data.Common.DataColumnMapping("IDDekurs", "IDDekurs"),
                        new System.Data.Common.DataColumnMapping("PrivatJN", "PrivatJN"),
                        new System.Data.Common.DataColumnMapping("IDExtern", "IDExtern"),
                        new System.Data.Common.DataColumnMapping("lstIDPDx", "lstIDPDx"),
                        new System.Data.Common.DataColumnMapping("lstPDxBezeichnung", "lstPDxBezeichnung"),
                        new System.Data.Common.DataColumnMapping("AnmerkungRtf", "AnmerkungRtf"),
                        new System.Data.Common.DataColumnMapping("IDBefund", "IDBefund"),
                        new System.Data.Common.DataColumnMapping("PSEKlasse", "PSEKlasse")})});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = resources.GetString("oleDbCommand1.CommandText");
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag")});
            // 
            // dsPflegePlan1
            // 
            this.dsPflegePlan1.DataSetName = "dsPflegePlan";
            this.dsPflegePlan1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlan1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanZusatzEintraege1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanH1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlan1)).EndInit();

		}
		#endregion

		//----------------------------------------------------------------------------
		/// <summary> 
		/// Liefert zu einer ID die zugehörigen ZusatzEinträge
		/// </summary>
		//----------------------------------------------------------------------------
		public dsPflegePlanZusatzEintraege.ZusatzEintragDataTable GetAllZusatzEintraegeFromID(Guid IDPflegePlan) 
		{
			dsPflegePlanZusatzEintraege1.Clear();
			daPflegePlanZusatzEintraege.SelectCommand.Parameters[0].Value = IDPflegePlan;
			DataBase.Fill(daPflegePlanZusatzEintraege, dsPflegePlanZusatzEintraege1.ZusatzEintrag);
			return dsPflegePlanZusatzEintraege1.ZusatzEintrag;
		}
        
		//----------------------------------------------------------------------------
		/// <summary>
		/// Fügt einen neuen Eintrrag in die DB ein
		/// </summary>
		//----------------------------------------------------------------------------
		public Guid InsertPPEntry(ASZMSelectionArgs args, Guid IDUser) 
		{
			dsPflegePlan.PflegePlanRow r = dsPflegePlan1.PflegePlan.NewPflegePlanRow();
			r.ID					= Guid.NewGuid();
            r.Anmerkung             = args.Anmerkung;
			r.DatumErstellt			= DateTime.Now;
			r.DatumGeaendert		= DateTime.Now;
			r.Dauer					= args.Dauer;
			r.EinmaligJN			= args.EinmaligJN;
			r.SetEndeDatumNull();
			r.ErledigtGrund			= "";
			r.ErledigtJN			= false;
			r.EvalTage				= args.EvalTage;
			r.GeloeschtJN			= false;
			r.IDAufenthalt			= _IDAufenthalt;
			r.IDBenutzer_Erstellt	= IDUser;
			r.IDBenutzer_Geaendert	= IDUser;
			r.IDBerufsstand			= args.IDBerufsstand;
			r.SpenderAbgabeJN		= args.SpenderAbgabgeJN;
			
			if(args.IDEintrag == Guid.Empty)
				r.SetIDEintragNull();
			else
				r.IDEintrag				= args.IDEintrag;
			
			r.Intervall				= args.Intervall;
			r.IntervallTyp			= args.IntervallTyp;
			r.SetLetzteEvaluierungNull();
			r.SetLetztesDatumNull();
			r.Lokalisierung			= args.Lokalisierung.Trim();
			r.LokalisierungJN		= args.LokalisierungJN;
			r.LokalisierungSeite	= args.LokalisierungSeite.Trim();
			r.OriginalJN			= true;							// Am begimm immer unverändert
			r.ParalellJN			= args.ParalellJN;
			r.StartDatum			= args.StartDatum;
			r.Text					= args.Text;
			r.Warnhinweis			= args.Warnhinweis;
			r.WochenTage			= args.WochenTage;
			r.EintragGruppe			= args.EintragGruppe.ToString();
			r.PDXJN					= args.ISPDX;
			r.RMOptionalJN			= args.RMOptionalJN;

            //Neu nach 26.06.2008 MDA
            //Ohne Zeitbetzug und Zeitbereich aus den Args übernehmen
            r.OhneZeitBezug         = args.OhneZeitBezug;
            r.EintragFlag           = args.EintragFlag;

            if (args.IDZeitbereich != Guid.Empty)
                r.IDZeitbereich = args.IDZeitbereich;
            else
                r.SetIDZeitbereichNull();

            r.ZuErledigenBis = args.ZuErledigenBis;
            //ende MDA
			// mda 5.4.2007
            if (ENV.EvaluierungsTyp == EvaluierungsTypen.Ziel)
            {
                r.NaechsteEvaluierungBemerkung = args.EvalBemerkung;

                if(args.EvalStartDatum != new DateTime(1900, 1, 1) && args.EintragGruppe == EintragGruppe.Z)        // nächste Evaluierung nur für Ziele
                    r.NaechsteEvaluierung = args.EvalStartDatum;
                else
                    r.SetNaechsteEvaluierungNull();
            }
            else
            {
                r.NaechsteEvaluierungBemerkung = "";
                r.SetNaechsteEvaluierungNull();
            } // ende mda

			if(args.IDUntertaegigGruppe == Guid.Empty)				// UNtertägigkeitsz zusammengehörigkeit von Maßnahmen
			{
				r.SetIDUntertaegigeGruppeNull();
				r.UntertaegigeJN = false;
			}
			else 
			{
				r.IDUntertaegigeGruppe = args.IDUntertaegigGruppe;
				r.UntertaegigeJN = true;
			}

            if (args.IDLinkDokument == Guid.Empty)
                r.SetIDLinkDokumentNull();
            else
                r.IDLinkDokument = args.IDLinkDokument;

            r.WundeJN = args.WundeJN; //Neu nach 19.09.2008 MDA
            r.SetIDDekursNull();
            r.PrivatJN = false;
            r.SetIDExternNull();
            r.SetNächstesDatumNull();
            r.lstIDPDx = "";
            r.lstPDxBezeichnung = "";
            r.AnmerkungRtf = "";
            r.SetIDBefundNull();
            r.PSEKlasse = "<nicht zugeordnet>";


			dsPflegePlan1.PflegePlan.AddPflegePlanRow(r);

			return r.ID;											// Den neu angelegten Pflegeplan rückliefern
		}

		public dsPflegePlan.PflegePlanRow FindPflegePlanRowByID(Guid IDRow) 
		{
			return dsPflegePlan1.PflegePlan.FindByID(IDRow);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert sämtliche Pflegeplaneinträge als Datatable
		/// </summary>
		//----------------------------------------------------------------------------
		public dsPflegePlan.PflegePlanDataTable PFLEGEPLAN_EINTRAEGE
		{
			get 
			{
				return dsPflegePlan1.PflegePlan;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liest sämtliche verspeicherten Einträge des Pflegeplanes
		/// </summary>
		//----------------------------------------------------------------------------
		public void Read(Guid IDAufenthalt)
		{
			_IDAufenthalt	= IDAufenthalt;

			dsPflegePlan1.Clear();
			daPflegePlan.SelectCommand.Parameters[0].Value	= IDAufenthalt;
			DataBase.Fill(daPflegePlan, dsPflegePlan1);

		}

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liest sämtliche verspeicherten Einträge des Pflegeplanes
        /// Nur Normale Pflegediagnosen oder nur Wunden je nach modus werden gelesen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Read(Guid IDAufenthalt, PflegePlanModus modus)
        {
            _IDAufenthalt = IDAufenthalt;

            dsPflegePlan1.Clear();
            daPflegePlanWundenJN.SelectCommand.Parameters[0].Value = IDAufenthalt;
            daPflegePlanWundenJN.SelectCommand.Parameters[1].Value = modus == PflegePlanModus.Normal ? false : true;
            DataBase.Fill(daPflegePlanWundenJN, dsPflegePlan1);
        }

        //----------------------------------------------------------------------------
		/// <summary>
		/// Liest sämtliche verspeicherten Einträge des Pflegeplanes
		/// Exception wenn nicht genau ein gelesener Datensatz
		/// </summary>
		//----------------------------------------------------------------------------
		public void ReadOnce(Guid IDPflegePlan)
		{
			dsPflegePlan1.Clear();
			daPflegePlanOnce.SelectCommand.Parameters[0].Value	= IDPflegePlan;
			DataBase.Fill(daPflegePlanOnce, dsPflegePlan1);
			if(dsPflegePlan1.PflegePlan.Count != 1)
				throw new Exception(string.Format("Invalid RowCount ({0}) during DBPflegePlan::ReadOnce()", dsPflegePlan1.PflegePlan.Count.ToString()));
		}


        public void GetPflegeplanByIDEintrag(Guid IDEintrag)
        {
            dsPflegePlan1.Clear();
            this.daPflegeplanByEintrag.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daPflegeplanByEintrag, dsPflegePlan1);
        }

		//----------------------------------------------------------------------------
		/// <summary>
		///	Beendet alle im Array angegebenen ASZM auf ID Basis
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndIDPflegePlanFromASZML(ASZMLokalisiert[] raszm, string sReason, DateTime dtEnd)
		{
			foreach(dsPflegePlan.PflegePlanRow r in PFLEGEPLAN_EINTRAEGE.Rows)			// Für jeden geänderten / neuen Eintrag einen Eintrag in die Historie schreiben
			{
				if(r.ErledigtJN || r.GeloeschtJN)
					continue;

				foreach(ASZMLokalisiert l in raszm)
				{
					if(!l._bCanPPFinished)
						continue;
					if(l._IDPflegePlan == r.ID) 
					{
						r.ErledigtJN	= true;
						r.ErledigtGrund = sReason;
						r.EndeDatum		= dtEnd;
					}
				}
			}
		}

		
		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert die erste Row im Dataset
		/// </summary>
		//----------------------------------------------------------------------------
		private dsPflegePlan.PflegePlanRow FIRSTROW 
		{
			get 
			{
				return dsPflegePlan1.PflegePlan[0];
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Beendet einen übergebenen Eintrag soferne noch nicht beendet 
		/// die Änderungen werden erst nach einem Write geschrieben
		/// die Änderungen sind auch sofort im assoziierten Dataset verfügbar
		/// Die ID muss auch im gelesenen Dataset vorhanden sein sonst wird eine 
		/// Exception ausgelöst
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndPflegePlanID(Guid IDPflegeplan, string sReason, DateTime dtEnd)
		{
			dsPflegePlan.PflegePlanRow r =  PFLEGEPLAN_EINTRAEGE.FindByID(IDPflegeplan);
			if(r == null)
				throw new Exception(string.Format("Pflegeplan Row {0} not found - PflegePlan::EndPflegePlanID()", IDPflegeplan.ToString()));

			if(r.ErledigtJN == true)			// Sollte der Eintrag bereits erledigt sein dann nix mehr tun
				return;

			r.ErledigtJN	= true;
			r.ErledigtGrund = sReason;
			r.EndeDatum		= dtEnd;
		}
		

		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert true wenn zu diesem Pflegeplaneintrag der Rückmeldetext optional ist
		/// false sonst
		/// </summary>
		//----------------------------------------------------------------------------
		public static bool IsRMOptional(Guid IDPflegeplan)
		{
			DBPflegePlan plan = new DBPflegePlan();
			plan.ReadOnce(IDPflegeplan);
			return plan.FIRSTROW.RMOptionalJN;
		}

        //Neu nach 17.07.2007 MDA
        public static dsPflgePlanZusatzGruppeEintrag.PflgePlanZusatzGruppeEintragDataTable GetPflgePlanZusatzGruppeEintraege(Guid IDPflegePlan, Guid IDAbteilung)
        {
            dsPflgePlanZusatzGruppeEintrag ds = new dsPflgePlanZusatzGruppeEintrag();
            DBPflegePlan plan = new DBPflegePlan();
            plan.daPflgePlanZusatzGruppeEintrag.SelectCommand.Parameters[0].Value = IDPflegePlan;
            plan.daPflgePlanZusatzGruppeEintrag.SelectCommand.Parameters[1].Value = IDAbteilung;
            DataBase.Fill(plan.daPflgePlanZusatzGruppeEintrag, ds.PflgePlanZusatzGruppeEintrag);
            return ds.PflgePlanZusatzGruppeEintrag;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle M ohne Zeitliche Zuordnung zu einem Aufenthalt
        /// </summary>
        //----------------------------------------------------------------------------
        public static dsPflegePlan.PflegePlanDataTable MohneZeitbezug(Guid IDAufenthalt)
        {
            OleDbCommand cmd = new OleDbCommand("Select  ID, IDAufenthalt, IDEintrag, IDBenutzer_Erstellt, IDBenutzer_Geaendert, OriginalJN, DatumErstellt, DatumGeaendert, StartDatum, EndeDatum, LetztesDatum, LetzteEvaluierung, Warnhinweis, Anmerkung, ErledigtGrund, Text, Intervall, WochenTage, IntervallTyp, EvalTage, IDBerufsstand, ParalellJN, Dauer, LokalisierungJN, EinmaligJN, ErledigtJN, GeloeschtJN, Lokalisierung, LokalisierungSeite, EintragGruppe, PDXJN, RMOptionalJN, UntertaegigeJN, SpenderAbgabeJN, IDUntertaegigeGruppe, IDLinkDokument, NaechsteEvaluierung, NaechsteEvaluierungBemerkung, IDZeitbereich, ZuErledigenBis, OhneZeitBezug, WundeJN");
            cmd.CommandText += " from Pflegeplan where IDAufenthalt = ? and ohneZeitbezug=1 and erledigtjn= 0";
            cmd.Parameters.AddWithValue("IDAufenthalt", IDAufenthalt);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dsPflegePlan.PflegePlanDataTable dt = new dsPflegePlan.PflegePlanDataTable();
            DataBase.Fill(da, dt);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den letzte RückmeldeZeitpunkt einer M eines Aufenthaltes
        /// oder 1900 wenn noch kein eintrag vorhanden ist
        /// </summary>
        //----------------------------------------------------------------------------
        public static DateTime GetLastRMTime(Guid IDAufenthalt, Guid IDEintrag)
        {
            try
            {
                //osxy Sollte eigentlich im Pflegeplan Spalte Letztes Datum stehen. Nochmals prüfen.
                if (_cmdGetLastRMTime == null)
                {
                    _cmdGetLastRMTime = new OleDbCommand("select max(Zeitpunkt) from PflegeEintrag where IDAufenthalt = ? and IDEintrag = ?");
                    _cmdGetLastRMTime.Parameters.Add("IDAufenthalt", OleDbType.Guid);
                    _cmdGetLastRMTime.Parameters.Add("IDEintrag", OleDbType.Guid);
                }

                DateTime dtRet = new DateTime(1900, 1, 1);
                _cmdGetLastRMTime.Parameters[0].Value = IDAufenthalt;
                _cmdGetLastRMTime.Parameters[1].Value = IDEintrag;
                _cmdGetLastRMTime.Connection = PMDS.Global.dbBase.getConn();
                System.Data.DataTable dtSelect = new System.Data.DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = _cmdGetLastRMTime;
                da.SelectCommand.CommandTimeout = 0;
                da.Fill(dtSelect);
                if (dtSelect.Rows.Count > 0)
                {
                    System.Data.DataRow r = dtSelect.Rows[0];
                    if (r[0] != System.DBNull.Value)
                    {
                        dtRet = (DateTime)r[0];
                    }
                }


                return dtRet;

            }
            catch (Exception ex)
            {
                throw new Exception("GetLastRMTime: " + ex.ToString());
            }
        }


        public static dsPflegePlan GetAllZiele(Guid IDAufenthalt, bool wunde, bool alleZiele)
        {
            if (_daGetAllZiele == null)
                _daGetAllZiele = new OleDbDataAdapter();
            
            if (alleZiele)
                    _daGetAllZiele.SelectCommand = new OleDbCommand("select * from PflegePlan where IDAufenthalt = ? and EintragGruppe ='Z' and wundejn = ?");

            else // nur aktive
                    _daGetAllZiele.SelectCommand = new OleDbCommand("select * from PflegePlan where IDAufenthalt = ? and EintragGruppe ='Z' and ErledigtJN = 0 and wundejn = ?");
                
            _daGetAllZiele.SelectCommand.Parameters.Add("IDAufenthalt", OleDbType.Guid);
            _daGetAllZiele.SelectCommand.Parameters.Add("wundejn", OleDbType.Boolean);

            _daGetAllZiele.SelectCommand.Parameters[0].Value = IDAufenthalt;
            _daGetAllZiele.SelectCommand.Parameters[1].Value = wunde;


            dsPflegePlan ds = new dsPflegePlan();
            DataBase.Fill(_daGetAllZiele, ds.PflegePlan);

            return ds;
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert die Pdx(en), die zu einem Ziel gehören als String für Tooltip
        /// </summary>
        //----------------------------------------------------------------------------
        public string GetPDxZiele(Guid IDPflegeplan, Infragistics.Win.UltraWinGrid.UltraGridRow rowGrid)
        {
            if (_daGetAllZielePDx == null)
                _daGetAllZielePDx = new OleDbDataAdapter();

            string sqlCmd = "SELECT DISTINCT PDX.Klartext AS PDxKlartext " +
                             "FROM PflegePlanPDx INNER JOIN PDX ON PflegePlanPDx.IDPDX = PDX.ID " +
                             "WHERE PflegePlanPDx.IDPflegePlan = ? and PflegePlanPDx.ErledigtJN=0";

            _daGetAllZielePDx.SelectCommand = new OleDbCommand(sqlCmd);
            _daGetAllZielePDx.SelectCommand.Parameters.Add("IDPflegeplan", OleDbType.Guid);
            _daGetAllZielePDx.SelectCommand.Parameters[0].Value = IDPflegeplan;

            //DataTable dt = new DataTable();
            //DataBase.Fill(_daGetAllZielePDx, dt);

            dsZielePDx dsZ = new dsZielePDx();
            DataBase.Fill(_daGetAllZielePDx, dsZ.ZielePDx);

            string ret = QS2.Desktop.ControlManagment.ControlManagment.getRes("... keine PDx gefunden.");    
            if (dsZ.ZielePDx.Rows.Count > 0)
            {
                ret = "... in PDx ";
                foreach (dsZielePDx.ZielePDxRow rZ in dsZ.ZielePDx.Rows)
                {
                    ret += rZ.PDxKlartext + " | ";
                }
                    
            }
            ret = ret.Substring(0, ret.Length - 2);
            return ret;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen in die DB
        /// </summary>
        //----------------------------------------------------------------------------
        public void Update(dsPflegePlan ds)
        {
            DataBase.Update(daPflegePlan, ds.PflegePlan);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegeplan update für Sichtbarmachung Ziele in Intervention
        /// [lth]
        /// </summary>
        //----------------------------------------------------------------------------
        public  bool  updatePflegePlan(Guid IDPflegeplan)
        {
            //OleDbCommand cmd = new OleDbCommand( );
            //cmd.Connection = DataBase.CONNECTION;
            ////cmd.Parameters.Add("", OleDbType.Date, 16, "").Value = from;
            //cmd.CommandText = "UPDATE PflegePlan   SET  Intervall = ?, WochenTage = ?, IntervallTyp = ?, EvalTage = ?  WHERE ID = ? ";
            //cmd.Parameters.Add("Intervall", System.Data.OleDb.OleDbType.Integer , 1, "Intervall").Value = 24;
            //cmd.Parameters.Add("WochenTage", System.Data.OleDb.OleDbType.Integer, 1, "WochenTage").Value = 127;
            //cmd.Parameters.Add("IntervallTyp", System.Data.OleDb.OleDbType.Integer, 1, "IntervallTyp").Value = 1;
            //cmd.Parameters.Add("EvalTage", System.Data.OleDb.OleDbType.Integer, 1, "EvalTage").Value = 1;
            //cmd.Parameters.Add( "ID", System.Data.OleDb.OleDbType.Guid, 16, "ID").Value = IDPflegeplan;
            //cmd.ExecuteNonQuery();
            return true;
        }


        
	}
}
