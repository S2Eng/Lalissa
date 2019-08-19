using System;
using System.Collections;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{


	public class QuickFilterManager
	{

		private		DBQuickFilter	_db = new DBQuickFilter();



		public QuickFilterManager()
		{
		}

		// Liefert eine Guid[] aus einem durch , getrennten GUid string[]
		public static Guid[] GuidArrayFromString(string sArray)
		{
			string[] sa = sArray.Split(',');
			ArrayList al = new ArrayList();
			try 
			{
				foreach(string s in sa)
					al.Add(new Guid(s));
			}
			catch {}
			return (Guid[])al.ToArray(typeof(Guid));
		}

		// Liefert alle Filter in der DB: Alle der generellen Abteilung und 
		// alle der übergebenen Abteilung
        public dsQuickFilter.QuickFilterDataTable ReadAll(Guid IDAbteilung, Guid IDKlinik)
		{
            return _db.ReadAll(IDAbteilung, IDKlinik);
		}
        public dsQuickFilter.QuickFilterDataTable ReadAllNurGesHaus(Guid IDKlinik)
        {
            return _db.ReadAllNurGesHaus(IDKlinik);
        }
		// Liefert alle Filter in der DB: alle der übergebenen Abteilung
		public dsQuickFilter.QuickFilterSmallDataTable ReadAllAbteilung(Guid IDAbteilung)
		{
			return _db.ReadAllAbteilung(IDAbteilung);
		}

		public Guid AddNew(string sText, Guid IDAbteilung) 
		{
			dsQuickFilter.QuickFilterDataTable dt   = new dsQuickFilter.QuickFilterDataTable();
			dsQuickFilter.QuickFilterRow r          = dt.NewQuickFilterRow();
			r.ID = Guid.NewGuid();
			r.Bezeichnung		        = sText;
			r.AbwBerufstandJN	        = false;
			r.BezugspersonJN	        = false;
			r.MassnahmeJN		        = false;
			r.RueckgemeldeteTermineJN   = false;
			r.Tagenachher		        = 0;
			r.Tagevorher		        = 0;
			r.ZeitraumJN		        = false;
			r.Massnahmen		        = "";
			r.TypJN				        = false;
			r.EintragTyp		        = -1;
			r.Tooltip			        = "";
			r.IDAbteilung		        = IDAbteilung;
            r.BenutzenInEvaluierungJN   = false;
            r.BenutzenInInterventionJN  = false;
            r.OhneZeitBezug             = 2;
            r.Reihenfolge               = 0;
            r.KeyLayout = "";
            r.KeyQuickFilter = "";
            r.BereichIntervention = false;
            r.BereichÜbergabe = false;
            r.BenutzenInDekursJN = false;
            r.BereichDekurs = false;
            r.LstErstelltVonBerufgruppe = "";
            r.LstWichtigFürBerufsgruppe = "";
            r.ShowCC = 0;
            r.LstZusatzwerte = "";
            r.LstInterventionsTyp = "";
            r.AbzeichnenJN = -1;
            r.LstZeitbezug = "";
            r.LstHerkunftPlanungsEintrag = "";
            r.IsStandard = false;
            r.LstBSQuickfilter = "";

			dt.AddQuickFilterRow(r);
			Write(dt);
			return r.ID;
		}

		public dsQuickFilter.QuickFilterDataTable Read(Guid ID)
		{
			return _db.Read(ID);
		}

		public void Write(dsQuickFilter.QuickFilterDataTable dt)
		{
			_db.Write(dt);
		}

	}
}
