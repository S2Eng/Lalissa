//----------------------------------------------------------------------------------------------
//	DBPDx.cs
//  Zugriffsfunktionen auf die DB für die Pflegedefinition
//  Erstellt am:	13.9.2004
//  Erstellt von:	RBU
//----------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB
{
	/// <summary>
	/// Summary description for DBPDx.
	/// </summary>
	public class DBPDx : System.ComponentModel.Component
	{
		private System.Data.OleDb.OleDbDataAdapter daPDx;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
        public dsPDx dsPDx1;
        private System.Data.OleDb.OleDbDataAdapter daPDxAll;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
		private System.Data.OleDb.OleDbDataAdapter daPDxGruppeAll;
		private System.Data.OleDb.OleDbDataAdapter daPDXGruppeEintragAll;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand3;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand3;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand3;
		private System.Data.OleDb.OleDbDataAdapter daPDxGruppe;
		private System.Data.OleDb.OleDbCommand oleDbCommand7;
		private System.Data.OleDb.OleDbCommand oleDbCommand8;
		private System.Data.OleDb.OleDbCommand oleDbCommand6;
		private System.Data.OleDb.OleDbCommand oleDbCommand5;
        public dsPDxGruppe dsPDxGruppe1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;
		private System.Data.OleDb.OleDbConnection oleDbConnection2;
        private OleDbDataAdapter daPDxEintragZuordnungen;
        private OleDbCommand oleDbCommand4;
		
		private System.ComponentModel.Container components = null;

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="container"></param>
		//----------------------------------------------------------------------------------------------
		public DBPDx(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Konstruktor
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public DBPDx()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void GetPDxList() 
		{

		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDx.PDXRow ReadOne(Guid IDPDx) 
		{
			dsPDx ds = new dsPDx();
			daPDx.SelectCommand.Parameters[0].Value = IDPDx;		
			DataBase.Fill(daPDx, ds);
			if(ds.PDX.Count != 1)
				throw new Exception("The Rowcount is not equeal 1 - DBPDx::Read()");
			return ds.PDX[0];
		}


		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle vorhandenen PDx als Datatable
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDx.PDXDataTable PDXEINTRAEGE 
		{
			get 
			{
				dsPDx ds = new dsPDx();
				DataBase.Fill(daPDxAll, ds);
				return ds.PDX;
			}
		}


		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle vorhandenen PDx als PDxdef[]
		/// </summary>
		/// <returns></returns>
		//----------------------------------------------------------------------------------------------
		public PDXDef[] GetAllPDx() 
		{
			ArrayList al = new ArrayList();
			dsPDx ds = new dsPDx();
			DataBase.Fill(daPDxAll, ds);
			foreach(dsPDx.PDXRow r in ds.PDX)
			{
				PDXDef def			        = new PDXDef();
				def.Changed			        = false;
				def.Code			        = r.Code;
				def.Definition		        = r.Definition;
				def.EntferntJN		        = r.EntferntJN;
				def.ID				        = r.ID;
				def.Klartext		        = r.Klartext;
				def.ThematischeID	        = r.ThematischeID;
                def.PDXGruppe               = (ePDXGruppe)r.Gruppe;
                def.PDXLokalisierungsTyp    = (PDxLokalisierungsTypen)r.LokalisierungsTyp;
                def.PDXKuerzel              = r.PDXKuerzel;   //Gernot%%
				al.Add(def);
			}

			return (PDXDef[])al.ToArray(typeof(PDXDef));
		}

		//public 

		//----------------------------------------------------------------------------
		/// <summary>
		/// Speichert die GruppenEinträgein der DB
		/// </summary>
		//----------------------------------------------------------------------------
		public void UpdatePDXGruppenEintrag(Guid[] aIDPDx, Guid IDPDxGruppe) 
		{
			// Alle entfernen und dann wieder einfügen
			dsPDxGruppeEintrag ds = new dsPDxGruppeEintrag();
			daPDXGruppeEintragAll.SelectCommand.Parameters[0].Value	= IDPDxGruppe;
			DataBase.Fill(daPDXGruppeEintragAll, ds);
			
			foreach(dsPDxGruppeEintrag.PDXGruppeEintragRow r1 in DBUtil.CurrentRows(ds.PDXGruppeEintrag)) 
				r1.Delete();
			DataBase.Update(daPDXGruppeEintragAll, ds);

			// Alle einfügen
			ds.Clear();
			dsPDxGruppeEintrag.PDXGruppeEintragRow r;
			foreach(Guid IDPdx in aIDPDx) 
			{
				r = ds.PDXGruppeEintrag.NewPDXGruppeEintragRow();
				r.IDPDX = IDPdx;
				r.IDPDXGruppe	= IDPDxGruppe;
				ds.PDXGruppeEintrag.AddPDXGruppeEintragRow(r);
			}

			DataBase.Update(daPDXGruppeEintragAll, ds);

		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle vorhandenen PDxGruppen als PDxGruppedef[] welche zu einer bestimmten Abteilung gehören
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public PDXGruppeDef[] GetAllPDxGruppe(Guid IDAbteilung) 
		{
			ArrayList al = new ArrayList();
			dsPDxGruppe ds = new dsPDxGruppe();
			daPDxGruppeAll.SelectCommand.Parameters[0].Value = IDAbteilung;
			DataBase.Fill(daPDxGruppeAll, ds);
			foreach(dsPDxGruppe.PDXGruppeRow r in ds.PDXGruppe)
			{
				PDXGruppeDef def	= new PDXGruppeDef();
				def.Changed			= false;
				def.Bezeichnung		= r.Bezeichnung;
				def.IDAbteilung		= r.IDAbteilung;
				def.ID				= r.ID;
				def.Reihenfolge		= r.Reihenfolge;
				al.Add(def);
			}

			return (PDXGruppeDef[])al.ToArray(typeof(PDXGruppeDef));
		}


		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle vorhandenen PDxGruppen welche zu einer bestimmten Abteilung gehören
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDxGruppe.PDXGruppeDataTable GetAllTopGruppen(Guid IDAbteilung) 
		{	
			//dsPDxGruppe ds = new dsPDxGruppe();
			daPDxGruppeAll.SelectCommand.Parameters[0].Value = IDAbteilung;
			dsPDxGruppe1.Clear();
			DataBase.Fill(daPDxGruppeAll, dsPDxGruppe1);
			return dsPDxGruppe1.PDXGruppe;
		}



		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle vorhandenen PDxGruppenEinträge als PDxGruppeEintragdef[]
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public PDXGruppeEintragDef[] GetAllPDxGruppeEintrag(Guid IDPDxGruppe) 
		{
			ArrayList al = new ArrayList();
			dsPDxGruppeEintrag ds = new dsPDxGruppeEintrag();
			daPDXGruppeEintragAll.SelectCommand.Parameters[0].Value	= IDPDxGruppe;
			DataBase.Fill(daPDXGruppeEintragAll, ds);
			foreach(dsPDxGruppeEintrag.PDXGruppeEintragRow r in ds.PDXGruppeEintrag) 
			{
				PDXGruppeEintragDef def = new PDXGruppeEintragDef();
				def.Definition		= r.Definition;
				def.Klartext		= r.Klartext;
				def.IDPDX			= r.IDPDX;
				def.IDPDXGruppe		= r.IDPDXGruppe;
				al.Add(def);
			}
			return (PDXGruppeEintragDef[])al.ToArray(typeof(PDXGruppeEintragDef));
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle PDXGruppen (Top 10 Gruppen) einer bestimmten Abteilung
		/// </summary>
		//----------------------------------------------------------------------------------------------
        public dsIDTextBezeichnung GetAllPDxGruppeFromAbteilung(Guid IDAbteilung, bool Pflegeplanmodus_Wunde)
		{
			dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
            OleDbCommand cmd;

           // if (Pflegeplanmodus_Wunde)
                 //cmd = new OleDbCommand("SELECT DISTINCT ID, Bezeichnung AS TEXT "
            //                       +"FROM (SELECT TOP 100 PDXGruppe.ID,Reihenfolge, PDXGruppe.Bezeichnung"
                 //                       +" FROM PDXGruppe INNER JOIN PDXGruppeEintrag ON PDXGruppe.ID = PDXGruppeEintrag.IDPDXGruppe INNER JOIN PDX ON PDXGruppeEintrag.IDPDX = PDX.ID"
                 //                       +" WHERE (PDXGruppe.IDAbteilung = ?) AND (wundejn = ?) ORDER BY Reihenfolge)AS derivedtable");

            cmd = new OleDbCommand("SELECT     PDXGruppe.ID, PDXGruppe.Bezeichnung AS Text FROM PDXGruppe INNER JOIN "
                                    +"(SELECT DISTINCT PDXGruppeEintrag.IDPDXGruppe FROM PDXGruppeEintrag INNER JOIN PDX ON PDXGruppeEintrag.IDPDX = PDX.ID "
                                + " WHERE (PDX.wundejn = ?)) AS InnerTable ON InnerTable.IDPDXGruppe = PDXGruppe.ID WHERE (PDXGruppe.IDAbteilung = ?)  ORDER BY PDXGruppe.Reihenfolge");

           
            cmd.Parameters.Add(new OleDbParameter("wundejn", OleDbType.Boolean));
            cmd.Parameters.Add(new OleDbParameter("ID", OleDbType.Guid));
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			da.TableMappings.Add( new System.Data.Common.DataTableMapping("_Table", "IDListe"));
            da.SelectCommand.Parameters[0].Value = Pflegeplanmodus_Wunde;
			da.SelectCommand.Parameters[1].Value = IDAbteilung;
            
			DataBase.Fill(da,ds);
            
            // RBU: 6.6.2006 Änderungswunsch fs: Wenn keine Top 10 für eine Abteilung definiert ist dann sollen alle aus der generellen Abteilung genommen werden
            if (ds._Table.Count == 0)
            {
                da.SelectCommand.Parameters[1].Value = Guid.Empty;		// generelle Abteilung
                DataBase.Fill(da, ds);
            }

			return ds;
		}


		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle PDX zu einer bestimmten Gruppe
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsIDTextBezeichnung GetPDxFromPDxGruppeID(Guid IDPDxGruppe) 
		{
			dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
			OleDbCommand cmd = new OleDbCommand("SELECT PDX.ID, PDX.Klartext AS TEXT, PDX.Definition AS Bezeichnung FROM  PDXGruppeEintrag INNER JOIN  PDX ON PDXGruppeEintrag.IDPDX = PDX.ID " 
												+  " WHERE (PDXGruppeEintrag.IDPDXGruppe = ?) AND (PDX.EntferntJN = 0) order by 2" );
			cmd.Parameters.Add(new OleDbParameter("ID", OleDbType.Guid));
			cmd.Parameters[0].Value = IDPDxGruppe;
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			da.TableMappings.Add( new System.Data.Common.DataTableMapping("_Table", "IDListe"));
			DataBase.Fill(da,ds);
			return ds;
		}

        //Neu nach 15.09.2008 MDA
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle PDX zu einer bestimmten Gruppe
        /// modus = Normal: Werden nur normale PDx'en geliefert.
        /// modus = Wunden: Werden nur Wunden bezeichnete PDx'en geliefert.
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public dsIDTextBezeichnung GetPDxFromPDxGruppeID(Guid IDPDxGruppe, PflegePlanModus modus)
        {
            dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT PDX.ID, PDX.Klartext AS TEXT, PDX.Definition AS Bezeichnung FROM  PDXGruppeEintrag INNER JOIN  PDX ON PDXGruppeEintrag.IDPDX = PDX.ID ");
            sb.Append(" WHERE (PDXGruppeEintrag.IDPDXGruppe = ?) AND (PDX.EntferntJN = 0)");
            sb.Append(" AND PDX.WundeJN =");
            sb.Append(modus == PflegePlanModus.Normal ? 0 : 1);
            sb.Append(" order by TEXT");

            OleDbCommand cmd = new OleDbCommand(sb.ToString());
            cmd.Parameters.Add(new OleDbParameter("ID", OleDbType.Guid));
            cmd.Parameters[0].Value = IDPDxGruppe;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.TableMappings.Add(new System.Data.Common.DataTableMapping("_Table", "IDListe"));
            DataBase.Fill(da, ds);
            return ds;
        }

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Pdx mit zugehörigen gefundenen Suchtext
		/// sSearchCriteria beinhalte die Suchwörter durch leerzeichen getrennt
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsIDTextBezeichnung GetPDxFromSearchText(string sSearchCriteria, SearchCondition condition) 
		{
            OleDbCommand cmd = GetPDXCommandFromSearchText(sSearchCriteria, condition);

			dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			da.TableMappings.Add( new System.Data.Common.DataTableMapping("_Table", "IDListe"));
			DataBase.Fill(da,ds);
			return ds;
		}

        //Neu nach 24.09.2008 MDA
        public dsPDxEintraege GetPDxZuordnugenFromSearchText(string sSearchCriteria, SearchCondition condition, PflegePlanModus modus, Guid IDAbteilung, bool PDxEntferntJN)
        {
            string sCriteria = "";
            using (OleDbCommand cmd = new OleDbCommand())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(daPDxEintragZuordnungen.SelectCommand.CommandText + " AND ");

                cmd.Parameters.AddWithValue("EntferntJN", PDxEntferntJN ? 1 : 0);
                cmd.Parameters.AddWithValue("WundeJN", modus == PflegePlanModus.Wunde ? 1 : 0);
                cmd.Parameters.AddWithValue("IDAbteilung", IDAbteilung);

                string[] sa = sSearchCriteria.Split(' ');
                bool bFirst = true;
                foreach (string s in sa)                            // Für jeden Suchbegriff das Statement zusammenbauen
                {
                    sCriteria = s.Trim();
                    if (sCriteria.Length == 0)
                        continue;

                    if (!bFirst)
                    {
                        if (condition == SearchCondition.AND)
                            sb.Append(" AND ");
                        else
                            sb.Append(" OR ");
                    }

                    sb.Append(" ( PDX.Klartext like ? OR PDX.Definition like ? )");
                    OleDbParameter p1 = cmd.Parameters.Add(new OleDbParameter("Klartext", OleDbType.VarChar));
                    OleDbParameter p2 = cmd.Parameters.Add(new OleDbParameter("Definition", OleDbType.VarChar));
                    p1.Value = "%" + s + "%";
                    p2.Value = "%" + s + "%";

                    bFirst = false;
                }

                sb.Append(" ORDER BY PDX.Gruppe, PDX.Klartext, Eintrag.EintragGruppe, Eintrag.Text");

                cmd.CommandText = sb.ToString();

                using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                {
                    using (dsPDxEintraege ds = new dsPDxEintraege())
                    {
                        DataBase.Fill(da, ds.PDXEintraege);
                        return ds;
                    }
                }
            }
        }

        //Neu nach 13.10.2008 MDA
        public dsPDxEintraege GetWundenZuordnugen(Guid IDAbteilung)
        {
            OleDbCommand cmd = new OleDbCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append(daPDxEintragZuordnungen.SelectCommand.CommandText);
            cmd.Parameters.AddWithValue("WundeJN", 1);
            cmd.Parameters.AddWithValue("IDAbteilung", IDAbteilung);
            
            sb.Append(" ORDER BY PDX.Klartext, Eintrag.EintragGruppe, Eintrag.Text");

            cmd.CommandText = sb.ToString();

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dsPDxEintraege ds = new dsPDxEintraege();
            DataBase.Fill(da, ds.PDXEintraege);
            return ds;
        }

        //Neu nach 15.09.2008 MDA
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Liefert alle Pdx mit zugehörigen gefundenen Suchtext
        /// sSearchCriteria beinhalte die Suchwörter durch leerzeichen getrennt
        /// modus = Normal: Werden nur normale PDx'en geliefert.
        /// modus = Wunden: Werden nur Wunden bezeichnete PDx'en geliefert.
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public dsIDTextBezeichnung GetPDxFromSearchText(string sSearchCriteria, SearchCondition condition, PflegePlanModus modus, bool PDxEntferntJN)
        {
            OleDbCommand cmd = GetPDXCommandFromSearchText(sSearchCriteria, condition);

            StringBuilder sb = new StringBuilder();
            sb.Append(cmd.CommandText);
            if (modus == PflegePlanModus.Normal)
                sb.Append(" AND WundeJN = 0");
            //else if (modus == PflegePlanModus.NormalAktiv)
            //    sb.Append(" AND WundeJN = 0 AND EntferntJN = 0");
            //else if (modus == PflegePlanModus.NormalEntfernt)
            //    sb.Append(" AND WundeJN = 0 AND EntferntJN = 1");
            else if (modus == PflegePlanModus.Wunde)
                sb.Append(" AND WundeJN = 1");
            //else if (modus == PflegePlanModus.WundeAktiv)
            //    sb.Append(" AND WundeJN = 1 AND EntferntJN = 0");
            //else if (modus == PflegePlanModus.WundeEntfernt)
            //    sb.Append(" AND WundeJN = 1 AND EntferntJN = 1");

            if (PDxEntferntJN == true)
                sb.Append(" AND EntferntJN = 1");
            else
                sb.Append(" AND EntferntJN = 0");

            cmd.CommandText = sb.ToString();

            dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.TableMappings.Add(new System.Data.Common.DataTableMapping("_Table", "IDListe"));
            DataBase.Fill(da, ds);
            return ds;
        }

        //Neu nach 13.10.2008 MDA
        /// <summary>
        /// Alle Wunde zurückgeben
        /// </summary>
        /// <returns></returns>
        public dsIDTextBezeichnung GetPDxWunden()
        {
            OleDbCommand cmd = new OleDbCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT PDX.ID, PDX.Klartext AS TEXT, PDX.Definition AS Bezeichnung FROM  PDX WHERE WundeJN=1 order by TEXT");
            cmd.CommandText = sb.ToString();

            dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.TableMappings.Add(new System.Data.Common.DataTableMapping("_Table", "IDListe"));
            DataBase.Fill(da, ds);
            return ds;
        }

        //Neu nach 15.09.2008 MDA
        private static OleDbCommand GetPDXCommandFromSearchText(string sSearchCriteria, SearchCondition condition)
        {
            string sCriteria = "";
            OleDbCommand cmd = new OleDbCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT PDX.ID, PDX.Klartext AS TEXT, PDX.Definition AS Bezeichnung FROM  PDX WHERE ");
            string[] sa = sSearchCriteria.Split(' ');
            bool bFirst = true;
            foreach (string s in sa)							// Für jeden Suchbegriff das Statement zusammenbauen
            {
                sCriteria = s.Trim();
                if (sCriteria.Length == 0)
                    continue;

                if (!bFirst)
                {
                    if (condition == SearchCondition.AND)
                        sb.Append(" AND ");
                    else
                        sb.Append(" OR ");
                }

                sb.Append(" ( Klartext like ? OR Definition like ? )");
                OleDbParameter p1 = cmd.Parameters.Add(new OleDbParameter("Klartext", OleDbType.VarChar));
                OleDbParameter p2 = cmd.Parameters.Add(new OleDbParameter("Klartext", OleDbType.VarChar));
                p1.Value = "%" + s + "%";
                p2.Value = "%" + s + "%";

                bFirst = false;
            }

            cmd.CommandText = sb.ToString();
            return cmd;
        }

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Einträge mit PDx zugehörigkeit wo der Suchtext und die Suchkriterien entsprechen.
		/// Die Abteilung wird berücksichtigt
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDxEintrag.PDXEintragDataTable GetEintragFromSearchText(string sSearchCriteria, SearchCondition condition, bool bGeneral) 
		{
			string sCriteria = "";
			OleDbCommand cmd = new OleDbCommand();
			StringBuilder sb = new StringBuilder();

			sb.Append("SELECT  newid() AS ID, null as IDPDX, ID as IDEintrag, null as IDAbteilung,  EintragGruppe, Text, '' as Klartext, Warnhinweis, Sicht ");
			sb.Append(" FROM EINTRAG WHERE EntferntJN = 0 and (");

			string[] sa = sSearchCriteria.Split(' ');
			bool bFirst = true;
			foreach(string s in sa)							// Für jeden Suchbegriff das Statement zusammenbauen
			{
				sCriteria = s.Trim();
				if(sCriteria.Length == 0)
					continue;

				if(!bFirst)
				{
					if(condition == SearchCondition.AND)
						sb.Append(" AND ");
					else
						sb.Append(" OR ");
				}
                
				sb.Append(" ( Text like ? ) ");
				OleDbParameter p1 = cmd.Parameters.Add(new OleDbParameter("Text", OleDbType.VarChar));
				p1.Value	= "%" + s + "%";
				bFirst = false;
			}

			sb.Append(")"); // Schließende Klammer nach EntferntJN
			cmd.CommandText = sb.ToString();

			dsPDxEintrag.PDXEintragDataTable dt = new dsPDxEintrag.PDXEintragDataTable();
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataBase.Fill(da,dt);
			if(bGeneral)				// bei den generellen Einträgen muss Guid.Empty als IDAbteilung eingetragen sein ...
			{
				foreach(dsPDxEintrag.PDXEintragRow r in dt)
				{
					r.IDAbteilung = Guid.Empty;
				}
			}
			return dt;
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Liefert alle Einträge mit PDx zugehörigkeit wo der Suchtext und die Suchkriterien entsprechen.
		/// Die Abteilung wird berücksichtigt
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public dsPDxEintrag.PDXEintragDataTable GetPDxEintragFromSearchText(string sSearchCriteria, SearchCondition condition, Guid IDAbteilung) 
		{
			string sCriteria = "";
			OleDbCommand cmd = new OleDbCommand();
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT  PDXEintrag.ID AS ID, PDXEintrag.IDPDX, PDXEintrag.IDEintrag, PDXEintrag.IDAbteilung, Eintrag.EintragGruppe, Eintrag.Text, PDX.Klartext, Eintrag.Warnhinweis, Eintrag.Sicht ");
			sb.Append(" FROM PDX INNER JOIN PDXEintrag ON PDX.ID = PDXEintrag.IDPDX");
			sb.Append(" INNER JOIN Eintrag ON PDXEintrag.IDEintrag = Eintrag.ID WHERE IDAbteilung = ? AND ");
			OleDbParameter pa = cmd.Parameters.Add(new OleDbParameter("IDAbteilung", OleDbType.Guid));
			pa.Value = IDAbteilung;


			string[] sa = sSearchCriteria.Split(' ');
			bool bFirst = true;
			foreach(string s in sa)							// Für jeden Suchbegriff das Statement zusammenbauen
			{
				sCriteria = s.Trim();
				if(sCriteria.Length == 0)
					continue;

				if(!bFirst)
				{
					if(condition == SearchCondition.AND)
						sb.Append(" AND ");
					else
						sb.Append(" OR ");
				}
                
				sb.Append(" ( Text like ? ) ");
				OleDbParameter p1 = cmd.Parameters.Add(new OleDbParameter("Text", OleDbType.VarChar));
				p1.Value	= "%" + s + "%";
				bFirst = false;
			}

			cmd.CommandText = sb.ToString();

			dsPDxEintrag.PDXEintragDataTable dt = new dsPDxEintrag.PDXEintragDataTable();
			OleDbDataAdapter da = new OleDbDataAdapter(cmd);
			DataBase.Fill(da,dt);
			return dt;
		}


		

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Aktualisiert eine PDx in der DB
		/// Die def muss korrekt ausgefüllt sein. Für neue Pdx muss die ID auch schon mit
		/// Guid.New belegt sein
		/// </summary>
		/// <param name="def"></param>
		//----------------------------------------------------------------------------------------------
		public void PdxToDB(PDXDef def, bool bDelete) 
		{
			// Prüfen ob Pdx in der DB vorhanden ist NEIN ==> neu anlegen
			dsPDx1.Clear();
			daPDx.SelectCommand.Parameters[0].Value = def.ID;		
			DataBase.Fill(daPDx, dsPDx1);	
			
			
			if(bDelete)							// Löschen ---------------------------------------------------
			{	
				if(dsPDx1.PDX.Count > 0)  
				{
					dsPDx1.PDX[0].Delete();
				}
			} 
			else								// Aktualiseren einfügen -------------------------------------
			{

				dsPDx.PDXRow r;
				if(dsPDx1.PDX.Count == 0) 
				{
					r	= dsPDx1.PDX.NewPDXRow();
					r.ID			= def.ID;
					r.EntferntJN	= def.EntferntJN;
                    r.WundeJN = false;
                    r.PDXKuerzel = "";  //Gernot%%
					dsPDx1.PDX.AddPDXRow(r);
				}
				else 
					r = dsPDx1.PDX[0];

				r.Code			    = def.Code;
				r.Definition	    = def.Definition;
				r.Klartext		    = def.Klartext;
				r.ThematischeID	    = def.ThematischeID;
                r.Gruppe            = (int)def.PDXGruppe;
                r.LokalisierungsTyp = (int)def.PDXLokalisierungsTyp;
                r.WundeJN           = def.WundeJN;
                r.PDXKuerzel        = def.PDXKuerzel;//Gernot%%
                r.EntferntJN        = def.EntferntJN;
			}

			DataBase.Update(daPDx, dsPDx1);

		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Aktualisiert eine PDxGruppe in der DB
		/// Die def muss korrekt ausgefüllt sein. Für neue Pdx muss die ID auch schon mit
		/// Guid.New belegt sein
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void PdxGruppeToDB(PDXGruppeDef def, bool bDelete) 
		{
			// Prüfen ob PdxGruppe in der DB vorhanden ist NEIN ==> neu anlegen
			dsPDxGruppe ds = new dsPDxGruppe();
			daPDxGruppe.SelectCommand.Parameters[0].Value = def.ID;		
			DataBase.Fill(daPDxGruppe, ds);	
			
			
			if(bDelete)							// Löschen ---------------------------------------------------
			{	
				if(ds.PDXGruppe.Count > 0)  
				{
					ds.PDXGruppe[0].Delete();
				}
			} 
			else								// Aktualiseren einfügen -------------------------------------
			{

				dsPDxGruppe.PDXGruppeRow r;
				if(ds.PDXGruppe.Count == 0) 
				{
					r	= ds.PDXGruppe.NewPDXGruppeRow();
					r.ID			= def.ID;
					r.IDAbteilung	= def.IDAbteilung;
					r.Reihenfolge	= def.Reihenfolge;
					ds.PDXGruppe.AddPDXGruppeRow(r);
				}
				else 
					r = ds.PDXGruppe[0];

				r.Bezeichnung	= def.Bezeichnung;
			}

			DataBase.Update(daPDxGruppe, ds);

		}



		public void PdxGruppeToDB(Guid ID,Guid IDAbteilung,string Bezeichnung,int Reihenfolge, bool bdelete)
		{
			// Prüfen ob PdxGruppe in der DB vorhanden ist NEIN ==> neu anlegen
			dsPDxGruppe ds = new dsPDxGruppe();
			daPDxGruppe.SelectCommand.Parameters[0].Value = ID;		
			DataBase.Fill(daPDxGruppe, ds);	
			
			
			if(bdelete)							// Löschen ---------------------------------------------------
			{	
				if(ds.PDXGruppe.Count > 0)  
				{
					ds.PDXGruppe[0].Delete();
				}
			} 
			
			else								// Aktualiseren einfügen -------------------------------------
			{

				dsPDxGruppe.PDXGruppeRow r;
				if(ds.PDXGruppe.Count == 0) 
				{
					r	= ds.PDXGruppe.NewPDXGruppeRow();
					r.ID			= ID;
					r.IDAbteilung	= IDAbteilung;
					r.Reihenfolge	= Reihenfolge;
					ds.PDXGruppe.AddPDXGruppeRow(r);
				}
				else 
					r = ds.PDXGruppe[0];

				r.Bezeichnung	= Bezeichnung;
                r.Reihenfolge   = Reihenfolge;
			}

			DataBase.Update(daPDxGruppe, ds);

			
			
			
		}






		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Aktualisiert eine PDxGruppe in der DB
		/// Die def muss korrekt ausgefüllt sein. Für neue Pdx muss die ID auch schon mit
		/// Guid.New belegt sein
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void PdxGruppeToDB(PDXGruppeDef def) 
		{
			PdxGruppeToDB(def,false);
		}


		public void PdxGruppeToDB(Guid IDAbteilung)
		{
			//dsPDxGruppe ds = new dsPDxGruppe();
			//daPDxGruppe.SelectCommand.Parameters[0].Value = IDAbteilung;		
			DataBase.Update(daPDxGruppe, dsPDxGruppe1);	
		}

		//----------------------------------------------------------------------------------------------
		/// <summary>
		/// Aktualiseren / Einfügen einer PDx
		/// </summary>
		//----------------------------------------------------------------------------------------------
		public void PdxToDB(PDXDef def) 
		{
			PdxToDB(def, false);
		}

		//----------------------------------------------------------------------------------------------
		/// <summary> 
		/// Dispose
		/// </summary>
		//----------------------------------------------------------------------------------------------
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
		/// Liefert true wenn der PDx Code bereits vergeben ist false sonst
		/// </summary> 
		//----------------------------------------------------------------------------
        public static bool PDXCodeExists(string sCode) 
		{
			try 
			{
                return DBUtil.PDXCodeExists(sCode);
			}
			catch(Exception ex) 
			{
				throw new Exception(ex.Message + " - PDx::IsPDxCodeInDatabase()");
			}

		}

        //Neu nach 05.05.2007 MDA
        //----------------------------------------------------------------------------------------------
        /// <summary>
        /// Liefert PDx mit zugehörigen gefundenen ID
        /// </summary>
        //----------------------------------------------------------------------------------------------
        public dsIDTextBezeichnung GetPDxByID(Guid IDPDx)
        {
            try
            {
                PMDS.db.Entities.PDX PDx = DBUtil.GetPDX(IDPDx);
                dsIDTextBezeichnung ds = new dsIDTextBezeichnung();
                dsIDTextBezeichnung._TableRow r = ds._Table.New_TableRow();
                r.ID = PDx .ID;
                r.Text = PDx.Klartext;
                r.Bezeichnung = PDx.Definition;
                ds._Table.Add_TableRow(r);
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - PDx::GetPDxByID()");
            }

        }

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBPDx));
            this.daPDx = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.dsPDx1 = new dsPDx();
            this.daPDxAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPDxGruppeAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection2 = new System.Data.OleDb.OleDbConnection();
            this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
            this.daPDXGruppeEintragAll = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand3 = new System.Data.OleDb.OleDbCommand();
            this.daPDxGruppe = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.dsPDxGruppe1 = new dsPDxGruppe();
            this.daPDxEintragZuordnungen = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxGruppe1)).BeginInit();
            // 
            // daPDx
            // 
            this.daPDx.DeleteCommand = this.oleDbDeleteCommand1;
            this.daPDx.InsertCommand = this.oleDbInsertCommand1;
            this.daPDx.SelectCommand = this.oleDbSelectCommand1;
            this.daPDx.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDX", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Klartext", "Klartext"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("ThematischeID", "ThematischeID"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Definition", "Definition"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("LokalisierungsTyp", "LokalisierungsTyp"),
                        new System.Data.Common.DataColumnMapping("WundeJN", "WundeJN"),
                        new System.Data.Common.DataColumnMapping("PDXKuerzel", "PDXKuerzel")})});
            this.daPDx.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = resources.GetString("oleDbDeleteCommand1.CommandText");
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Klartext", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Klartext", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Klartext", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Klartext", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Code", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Code", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ThematischeID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ThematischeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EntferntJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EntferntJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EntferntJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Definition", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Definition", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Definition", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Definition", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Gruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Gruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Gruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Gruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungsTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungsTyp", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_WundeJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WundeJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PDXKuerzel", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PDXKuerzel", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO [PDX] ([ID], [Klartext], [Code], [ThematischeID], [EntferntJN], [Defi" +
    "nition], [Gruppe], [LokalisierungsTyp], [WundeJN], [PDXKuerzel]) VALUES (?, ?, ?" +
    ", ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Klartext", System.Data.OleDb.OleDbType.VarChar, 0, "Klartext"),
            new System.Data.OleDb.OleDbParameter("Code", System.Data.OleDb.OleDbType.VarChar, 0, "Code"),
            new System.Data.OleDb.OleDbParameter("ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, "ThematischeID"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Definition", System.Data.OleDb.OleDbType.VarChar, 0, "Definition"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.Integer, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("LokalisierungsTyp", System.Data.OleDb.OleDbType.Integer, 0, "LokalisierungsTyp"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 0, "WundeJN"),
            new System.Data.OleDb.OleDbParameter("PDXKuerzel", System.Data.OleDb.OleDbType.VarChar, 0, "PDXKuerzel")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT     ID, Klartext, Code, ThematischeID, EntferntJN, Definition, Gruppe, Lok" +
    "alisierungsTyp, WundeJN,PDXKuerzel\r\nFROM         PDX\r\nWHERE     (ID = ?)";
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("Klartext", System.Data.OleDb.OleDbType.VarChar, 0, "Klartext"),
            new System.Data.OleDb.OleDbParameter("Code", System.Data.OleDb.OleDbType.VarChar, 0, "Code"),
            new System.Data.OleDb.OleDbParameter("ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, "ThematischeID"),
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("Definition", System.Data.OleDb.OleDbType.VarChar, 0, "Definition"),
            new System.Data.OleDb.OleDbParameter("Gruppe", System.Data.OleDb.OleDbType.Integer, 0, "Gruppe"),
            new System.Data.OleDb.OleDbParameter("LokalisierungsTyp", System.Data.OleDb.OleDbType.Integer, 0, "LokalisierungsTyp"),
            new System.Data.OleDb.OleDbParameter("WundeJN", System.Data.OleDb.OleDbType.Boolean, 0, "WundeJN"),
            new System.Data.OleDb.OleDbParameter("PDXKuerzel", System.Data.OleDb.OleDbType.VarChar, 0, "PDXKuerzel"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Klartext", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Klartext", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Klartext", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Klartext", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Code", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Code", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Code", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "ThematischeID", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_ThematischeID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ThematischeID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_EntferntJN", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "EntferntJN", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_EntferntJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "EntferntJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Definition", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Definition", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Definition", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Definition", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("IsNull_Gruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Gruppe", System.Data.DataRowVersion.Original, true, null),
            new System.Data.OleDb.OleDbParameter("Original_Gruppe", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Gruppe", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_LokalisierungsTyp", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "LokalisierungsTyp", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_WundeJN", System.Data.OleDb.OleDbType.Boolean, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "WundeJN", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_PDXKuerzel", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "PDXKuerzel", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPDx1
            // 
            this.dsPDx1.DataSetName = "dsPDx";
            this.dsPDx1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDx1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPDxAll
            // 
            this.daPDxAll.SelectCommand = this.oleDbCommand3;
            this.daPDxAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDX", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Klartext", "Klartext"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("ThematischeID", "ThematischeID"),
                        new System.Data.Common.DataColumnMapping("EntferntJN", "EntferntJN"),
                        new System.Data.Common.DataColumnMapping("Definition", "Definition"),
                        new System.Data.Common.DataColumnMapping("Gruppe", "Gruppe"),
                        new System.Data.Common.DataColumnMapping("LokalisierungsTyp", "LokalisierungsTyp"),
                        new System.Data.Common.DataColumnMapping("WundeJN", "WundeJN"),
                        new System.Data.Common.DataColumnMapping("PDXKuerzel", "PDXKuerzel")})});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = "SELECT     ID, Klartext, Code, ThematischeID, EntferntJN, Definition, Gruppe, Lok" +
    "alisierungsTyp, WundeJN,PDXKuerzel\r\nFROM         PDX\r\nORDER BY Klartext";
            this.oleDbCommand3.Connection = this.oleDbConnection1;
            // 
            // daPDxGruppeAll
            // 
            this.daPDxGruppeAll.DeleteCommand = this.oleDbDeleteCommand2;
            this.daPDxGruppeAll.InsertCommand = this.oleDbInsertCommand2;
            this.daPDxGruppeAll.SelectCommand = this.oleDbSelectCommand2;
            this.daPDxGruppeAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXGruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daPDxGruppeAll.UpdateCommand = this.oleDbUpdateCommand2;
            // 
            // oleDbDeleteCommand2
            // 
            this.oleDbDeleteCommand2.CommandText = resources.GetString("oleDbDeleteCommand2.CommandText");
            this.oleDbDeleteCommand2.Connection = this.oleDbConnection2;
            this.oleDbDeleteCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung1", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung1", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbConnection2
            // 
            this.oleDbConnection2.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initi" +
    "al Catalog=PMDSDev";
            // 
            // oleDbInsertCommand2
            // 
            this.oleDbInsertCommand2.CommandText = "INSERT INTO PDXGruppe(ID, IDAbteilung, Reihenfolge, Bezeichnung) VALUES (?, ?, ?," +
    " ?); SELECT ID, IDAbteilung, Reihenfolge, Bezeichnung FROM PDXGruppe WHERE (ID =" +
    " ?) ORDER BY Reihenfolge";
            this.oleDbInsertCommand2.Connection = this.oleDbConnection2;
            this.oleDbInsertCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Select_ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = "SELECT ID, IDAbteilung, Reihenfolge, Bezeichnung FROM PDXGruppe WHERE (IDAbteilun" +
    "g = ?) ORDER BY Reihenfolge";
            this.oleDbSelectCommand2.Connection = this.oleDbConnection2;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            // 
            // oleDbUpdateCommand2
            // 
            this.oleDbUpdateCommand2.CommandText = resources.GetString("oleDbUpdateCommand2.CommandText");
            this.oleDbUpdateCommand2.Connection = this.oleDbConnection2;
            this.oleDbUpdateCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Bezeichnung1", System.Data.OleDb.OleDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Bezeichnung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDAbteilung1", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDAbteilung", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Reihenfolge1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Reihenfolge", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Select_ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // daPDXGruppeEintragAll
            // 
            this.daPDXGruppeEintragAll.DeleteCommand = this.oleDbDeleteCommand3;
            this.daPDXGruppeEintragAll.InsertCommand = this.oleDbInsertCommand3;
            this.daPDXGruppeEintragAll.SelectCommand = this.oleDbSelectCommand3;
            this.daPDXGruppeEintragAll.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXGruppeEintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("IDPDXGruppe", "IDPDXGruppe")})});
            this.daPDXGruppeEintragAll.UpdateCommand = this.oleDbUpdateCommand3;
            // 
            // oleDbDeleteCommand3
            // 
            this.oleDbDeleteCommand3.CommandText = "DELETE FROM PDXGruppeEintrag WHERE (IDPDX = ?) AND (IDPDXGruppe = ?)";
            this.oleDbDeleteCommand3.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDXGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDXGruppe", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand3
            // 
            this.oleDbInsertCommand3.CommandText = "INSERT INTO PDXGruppeEintrag(IDPDX, IDPDXGruppe) VALUES (?, ?)";
            this.oleDbInsertCommand3.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPDXGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDPDXGruppe")});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = resources.GetString("oleDbSelectCommand3.CommandText");
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDXGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDPDXGruppe")});
            // 
            // oleDbUpdateCommand3
            // 
            this.oleDbUpdateCommand3.CommandText = "UPDATE PDXGruppeEintrag SET IDPDX = ?, IDPDXGruppe = ? WHERE (IDPDX = ?) AND (IDP" +
    "DXGruppe = ?)";
            this.oleDbUpdateCommand3.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPDX", System.Data.OleDb.OleDbType.Guid, 16, "IDPDX"),
            new System.Data.OleDb.OleDbParameter("IDPDXGruppe", System.Data.OleDb.OleDbType.Guid, 16, "IDPDXGruppe"),
            new System.Data.OleDb.OleDbParameter("Original_IDPDX", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDX", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_IDPDXGruppe", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IDPDXGruppe", System.Data.DataRowVersion.Original, null)});
            // 
            // daPDxGruppe
            // 
            this.daPDxGruppe.DeleteCommand = this.oleDbCommand5;
            this.daPDxGruppe.InsertCommand = this.oleDbCommand6;
            this.daPDxGruppe.SelectCommand = this.oleDbCommand7;
            this.daPDxGruppe.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDXGruppe", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge"),
                        new System.Data.Common.DataColumnMapping("Bezeichnung", "Bezeichnung")})});
            this.daPDxGruppe.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM PDXGruppe WHERE (ID = ?)";
            this.oleDbCommand5.Connection = this.oleDbConnection1;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO PDXGruppe(ID, IDAbteilung, Reihenfolge, Bezeichnung) VALUES (?, ?, ?," +
    " ?)";
            this.oleDbCommand6.Connection = this.oleDbConnection1;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT ID, IDAbteilung, Reihenfolge, Bezeichnung FROM PDXGruppe WHERE (ID = ?)";
            this.oleDbCommand7.Connection = this.oleDbConnection1;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE PDXGruppe SET ID = ?, IDAbteilung = ?, Reihenfolge = ?, Bezeichnung = ? WH" +
    "ERE (ID = ?)";
            this.oleDbCommand8.Connection = this.oleDbConnection1;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 16, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung"),
            new System.Data.OleDb.OleDbParameter("Reihenfolge", System.Data.OleDb.OleDbType.Integer, 4, "Reihenfolge"),
            new System.Data.OleDb.OleDbParameter("Bezeichnung", System.Data.OleDb.OleDbType.VarChar, 255, "Bezeichnung"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 16, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // dsPDxGruppe1
            // 
            this.dsPDxGruppe1.DataSetName = "dsPDxGruppe";
            this.dsPDxGruppe1.Locale = new System.Globalization.CultureInfo("de-DE");
            this.dsPDxGruppe1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPDxEintragZuordnungen
            // 
            this.daPDxEintragZuordnungen.SelectCommand = this.oleDbCommand4;
            this.daPDxEintragZuordnungen.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Eintrag", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDPDx", "IDPDx"),
                        new System.Data.Common.DataColumnMapping("TEXT", "TEXT"),
                        new System.Data.Common.DataColumnMapping("Definition", "Definition"),
                        new System.Data.Common.DataColumnMapping("IDPDXEintrag", "IDPDXEintrag"),
                        new System.Data.Common.DataColumnMapping("IDEintrag", "IDEintrag"),
                        new System.Data.Common.DataColumnMapping("IDAbteilung", "IDAbteilung"),
                        new System.Data.Common.DataColumnMapping("EintragGruppe", "EintragGruppe"),
                        new System.Data.Common.DataColumnMapping("EintragText", "EintragText"),
                        new System.Data.Common.DataColumnMapping("Warnhinweis", "Warnhinweis"),
                        new System.Data.Common.DataColumnMapping("Sicht", "Sicht"),
                        new System.Data.Common.DataColumnMapping("IDLinkDokument", "IDLinkDokument"),
                        new System.Data.Common.DataColumnMapping("OhneZeitBezug", "OhneZeitBezug")})});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.oleDbConnection1;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("EntferntJN", System.Data.OleDb.OleDbType.Boolean, 1, "EntferntJN"),
            new System.Data.OleDb.OleDbParameter("wundejn", System.Data.OleDb.OleDbType.Boolean, 1, "wundejn"),
            new System.Data.OleDb.OleDbParameter("IDAbteilung", System.Data.OleDb.OleDbType.Guid, 16, "IDAbteilung")});
            ((System.ComponentModel.ISupportInitialize)(this.dsPDx1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDxGruppe1)).EndInit();

		}
		#endregion
	}
}
