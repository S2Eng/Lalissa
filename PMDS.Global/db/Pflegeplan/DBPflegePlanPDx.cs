//----------------------------------------------------------------------------------------------
//	DBPflegePlanPDx.cs
//  Zugriffsfunktionen auf die einem Pflegeplan zugeordneten PDx bezogen auf einen Pflegeplan
//  Erstellt am:	14.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

using RBU;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// DBPflegeplan
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBPflegePlanPDx : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPflegePlanPDx;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private dsPflegePlanPDx dsPflegePlanPDx1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter daPflegePlanPDxWundeJN;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbDataAdapter daPPPDxZuordnungen;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
		private System.ComponentModel.Container components = null;

		public DBPflegePlanPDx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------
		public DBPflegePlanPDx()
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

		private void GetLokalisierung(dsAufenthaltPDx.AufenthaltPDxDataTable dt, Guid IDAuenthaltPDx, out string sLokalisierung, out string sLokalisierungSeite) 
		{
			sLokalisierung = "";
			sLokalisierungSeite = "";
			foreach(dsAufenthaltPDx.AufenthaltPDxRow r in dt) 
			{
				if(r.ID == IDAuenthaltPDx) 
				{
					sLokalisierung		= r.Lokalisierung.Trim();
					sLokalisierungSeite = r.LokalisierungSeite.Trim();
					return;
				}
			}
			throw new Exception("DBPflegePlanPDx::GetLokalisierung() -> AufenthaltPDx wurde nicht gefunden. Informieren Sie Ihren Systemadministrator");
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// 19.1.2006 ab jetzt wird die lokalisierung mit berücksichtigt.
		/// Fügt einen neuen Eintrag in die DB ein
		/// Zusammenhang: Wenn in PflegePlan ein neuer Eintrag gemacht wird dann
		/// muss hier ein neuer Datensatz erstellt werden der den Zusammenhang
		/// zwischen dem Eintrag im Pflegeplan und der zugehörigen PDx herstellt.
		/// Wir nun im Pflegeplan ein Eintrag mit einer bestimmten Pdx und Lokalisierung (auch wenn die leer ist) 
		/// gemacht, dann wird wenn der Eintrag schon im Pflegeplan vorhanden ist hier ein 
		/// zusätzlicher Eintrag gemacht. (Einer wird angelegt wenn der Eintrag im PflegePlan 
		/// noch nicht vorhanden war.
		/// </summary>
		//----------------------------------------------------------------------------
		public void InsertPPEntry(ASZMSelectionArgs args, Guid IDUser, Guid IDPflegePlan, Guid IDAufenthaltPDx, bool bInsertEver,dsAufenthaltPDx.AufenthaltPDxDataTable dtAufenthaltPDx) 
		{
			// Den Eintrg nur hinzufügen wenns die Konbination IDEintrag + IDPDx noch nicht gibt.
			if(!bInsertEver) 
			{
				string sLokalisierung = "";
				string sLokalisierungSeite = "";
				bool bFound = false;
				foreach(dsPflegePlanPDx.PflegePlanPDxRow rs in dsPflegePlanPDx1.PflegePlanPDx) 
				{
					GetLokalisierung(dtAufenthaltPDx, rs.IDAufenthaltPDx, out sLokalisierung, out sLokalisierungSeite);
					if(rs.IDPDX == args.IDPDX && rs.IDEintrag == args.IDEintrag && rs.ErledigtJN == false && sLokalisierung.Trim() == args.Lokalisierung.Trim() && sLokalisierungSeite.Trim() == args.LokalisierungSeite.Trim())  
					{
						bFound = true;
						break;
					}
				}
				if(bFound)
					return;
			}

			dsPflegePlanPDx.PflegePlanPDxRow r = dsPflegePlanPDx1.PflegePlanPDx.NewPflegePlanPDxRow();
			r.SetDatumBeendetNull();
			r.SetIDBenutzer_BeendetNull();
			r.ID					= Guid.NewGuid();
			r.IDEintrag				= args.IDEintrag;
			r.DatumErstellt			= DateTime.Now;
			r.ErledigtGrund			= "";
			r.ErledigtJN			= false;
			
			r.IDBenutzer_Erstellt	= IDUser;
			r.IDPDX					= args.IDPDX;
			r.IDPflegePlan			= IDPflegePlan;
			r.IDAufenthaltPDx		= IDAufenthaltPDx;

			dsPflegePlanPDx1.PflegePlanPDx.AddPflegePlanPDxRow(r);
		}


		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPflegePlanPDx));
            this.daPflegePlanPDx = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsPflegePlanPDx1 = new dsPflegePlanPDx();
            this.daPflegePlanPDxWundeJN = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPPPDxZuordnungen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanPDx1)).BeginInit();
            // 
            // daPflegePlanPDx
            // 
            this.daPflegePlanPDx.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPflegePlanPDx.InsertCommand = this.oleDbInsertCommand1;
            this.daPflegePlanPDx.SelectCommand = this.oleDbSelectCommand1;
            this.daPflegePlanPDx.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlanPDx", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumBeendet", "DatumBeendet"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltPDx", "IDAufenthaltPDx")})});
            this.daPflegePlanPDx.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM PflegePlanPDx WHERE (ID = ?)";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumBeendet", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumBeendet"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltPDx", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltPDx")});
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
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPflegePlan", System.Data.OleDb.OleDbType.Guid, 16, "IDPflegePlan"),
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Erstellt", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Erstellt"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer_Beendet", System.Data.OleDb.OleDbType.Guid, 16, "IDBenutzer_Beendet"),
            new System.Data.OleDb.OleDbParameter("DatumErstellt", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumErstellt"),
            new System.Data.OleDb.OleDbParameter("DatumBeendet", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "DatumBeendet"),
            new System.Data.OleDb.OleDbParameter("ErledigtJN", System.Data.OleDb.OleDbType.Boolean, 1, "ErledigtJN"),
            new System.Data.OleDb.OleDbParameter("ErledigtGrund", System.Data.OleDb.OleDbType.VarChar, 255, "ErledigtGrund"),
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag"),
            new System.Data.OleDb.OleDbParameter("IDAufenthaltPDx", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthaltPDx"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPflegePlanPDx1
            // 
            this.dsPflegePlanPDx1.DataSetName = "dsPflegePlanPDx";
            this.dsPflegePlanPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPflegePlanPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPflegePlanPDxWundeJN
            // 
            this.daPflegePlanPDxWundeJN.SelectCommand = this.oleDbCommand3;
            this.daPflegePlanPDxWundeJN.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlanPDx", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumBeendet", "DatumBeendet"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltPDx", "IDAufenthaltPDx")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 1, "WundeJN")});
            // 
            // daPPPDxZuordnungen
            // 
            this.daPPPDxZuordnungen.SelectCommand = this.oleDbCommand4;
            this.daPPPDxZuordnungen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PflegePlanPDx", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPflegePlan", "IDPflegePlan"),
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Erstellt", "IDBenutzer_Erstellt"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer_Beendet", "IDBenutzer_Beendet"),
                        new System.Data.Common.DataColumnMapping("DatumErstellt", "DatumErstellt"),
                        new System.Data.Common.DataColumnMapping("DatumBeendet", "DatumBeendet"),
                        new System.Data.Common.DataColumnMapping("ErledigtJN", "ErledigtJN"),
                        new System.Data.Common.DataColumnMapping("ErledigtGrund", "ErledigtGrund"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAufenthaltPDx", "IDAufenthaltPDx")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDEintrag", System.Data.OleDb.OleDbType.Guid, 16, "IDEintrag")});
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegePlanPDx1)).EndInit();

		}
		#endregion


		//----------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle einem Aufenthalt zugeordneten Zuordnungen von PDx mit den
		/// Einträgen
		/// </summary>
		//----------------------------------------------------------------------------
		public dsPflegePlanPDx.PflegePlanPDxDataTable PFLEGEPLANPDX 
		{
			get 
			{
				return dsPflegePlanPDx1.PflegePlanPDx;
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
			dsPflegePlanPDx1.Clear();
			daPflegePlanPDx.SelectCommand.Parameters[0].Value = IDAufenthalt;
			DataBase.Fill(daPflegePlanPDx, dsPflegePlanPDx1);
		}

        public void GetPflegeplanPDxZuordnungen(Guid IDEintrag)
        {
            dsPflegePlanPDx1.Clear();
            this.daPPPDxZuordnungen.SelectCommand.Parameters[0].Value = IDEintrag;
            DataBase.Fill(daPPPDxZuordnungen, dsPflegePlanPDx1);
        }


        //Neu nach 19.09.2008 MDA
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liest sämtliche verspeicherten Einträge der PflegePlanPDx welche zu einem
        /// bestimmten Aufenthalt gehören
        /// (Pflegeplan ist immer einen Aufenthalt zugeordnet)
        /// Nur Normale Pflegepläne oder nur Wunden je nach modus werden gelesen
        /// </summary>
        //----------------------------------------------------------------------------
        public void Read(Guid IDAufenthalt, PflegePlanModus modus)
		{
			dsPflegePlanPDx1.Clear();
            daPflegePlanPDxWundeJN.SelectCommand.Parameters[0].Value = IDAufenthalt;
            daPflegePlanPDxWundeJN.SelectCommand.Parameters[1].Value = modus == PflegePlanModus.Normal ? false : true;
            DataBase.Fill(daPflegePlanPDxWundeJN, dsPflegePlanPDx1);
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
			//PMDS.GUI.frmDebugDataset frm = new PMDS.GUI.frmDebugDataset(dsPflegePlanPDx1);
			//frm.ShowDialog();
			DataBase.Update(daPflegePlanPDx, dsPflegePlanPDx1);
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	Speichert die Beendigung der Pflegeprobleme in die Zuordnungstabelle PDx->Eintrag
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndPDx(ASZMLokalisiert[] rpdx, string sReason, DateTime dtEnd)
		{
			foreach(dsPflegePlanPDx.PflegePlanPDxRow r in   dsPflegePlanPDx1.PflegePlanPDx.Rows) 
			{
				if(r.ErledigtJN)					// Erledigte ignorieren
					continue;

				foreach(ASZMLokalisiert l in rpdx)
				{
					if(r.ID	== l._IDPflegePlanPDx)
					{
						r.ErledigtJN			= true;
						r.ErledigtGrund 		= sReason;
						r.DatumBeendet			= dtEnd;
						r.IDBenutzer_Beendet	= ENV.USERID;
					}
				}
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	Speichert die Beendigung der Pflegeprobleme in die Zuordnungstabelle PDx->Eintrag
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndASZM(ASZMLokalisiert[] rpdx, string sReason, DateTime dtEnd)
		{
			foreach(dsPflegePlanPDx.PflegePlanPDxRow r in   dsPflegePlanPDx1.PflegePlanPDx.Rows) 
			{
				if(r.ErledigtJN)					// Erledigte ignorieren
					continue;

				foreach(ASZMLokalisiert l in rpdx)
				{
					if(r.ID	== l._IDPflegePlanPDx)
					{
						r.ErledigtJN			= true;
						r.ErledigtGrund 		= sReason;
						r.DatumBeendet			= dtEnd;
						r.IDBenutzer_Beendet	= ENV.USERID;
					}
				}
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		///	markiert alle PDX Zuordnungen zur PflegeplanID als erledigt mit Grund und Datum
		/// </summary>
		//----------------------------------------------------------------------------
		public void EndPflegePlanPDx(Guid IDPflegePlan, string sReason, DateTime dtEnd) 
		{
			foreach(dsPflegePlanPDx.PflegePlanPDxRow r in  PFLEGEPLANPDX) 
			{
				if(r.ErledigtJN)			// Erledigte ignorieren
					continue;

				if(r.IDPflegePlan == IDPflegePlan) 
				{
					r.ErledigtJN			= true;
					r.ErledigtGrund 		= sReason;
					r.DatumBeendet			= dtEnd;
					r.IDBenutzer_Beendet	= ENV.USERID;
				}
			}
		}
	}
}
