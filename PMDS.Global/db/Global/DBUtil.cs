//----------------------------------------------------------------------------
/// <summary>
///	DBUtil.cs
/// Erstellt am:	22.9.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

using RBU;
using PMDS.Global;


namespace PMDS.DB
{
	//----------------------------------------------------------------------------
	/// <summary>
	/// Nützliche Utilities für die DB
	/// </summary>
	//----------------------------------------------------------------------------
	public class DBUtil
	{

        public static bool  stopCheckDB = false ;
        public static PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
 

        public static PMDS.db.Entities.PDX GetPDX(Guid IDPDx)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.db.Entities.PDX rPDx = PMDSBusiness1.getPDX(IDPDx, db);
                return rPDx;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetPDX()");
            }
        }

        public static PMDS.db.Entities.Eintrag GetEintrag(Guid IDEintrag)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.db.Entities.Eintrag rEintrag = PMDSBusiness1.GetEintrag(db, IDEintrag);
                return rEintrag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetEintrag()");
            }
        }

        public static PMDS.db.Entities.Aerzte GetArzt(Guid IDArzt)
        {
            try
            {
                PMDS.db.Entities.Aerzte Arzt = new db.Entities.Aerzte();
                Arzt.ID = System.Guid.Empty;
                Arzt.Nachname = "";
                Arzt.Vorname = "";

                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();

                System.Linq.IQueryable<PMDS.db.Entities.Aerzte> tAerzte = null;
                PMDSBusiness1.getAllÄrzte(db, ref tAerzte);
                foreach (PMDS.db.Entities.Aerzte rArzt in tAerzte)
                {
                    if (rArzt.ID == IDArzt)
                        Arzt = rArzt;
                }
                return Arzt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetEintrag()");
            }
        }
        
        public static PMDS.db.Entities.DBVersion GetDBVersion()
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.db.Entities.DBVersion rDBVersion = PMDSBusiness1.GetDBVersion(db);
                return rDBVersion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetDBVersion()");
            }
        }

        public static PMDS.db.Entities.DBLizenz GetDBLizenz()
        {
            try
            {
                PMDS.db.Entities.DBLizenz rDBLizenz;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    rDBLizenz = PMDSBusiness1.GetDBLizenz(db);

                }
                return rDBLizenz;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetDBLizenz()");
            }
        }

        public static PMDS.db.Entities.SPPE GetSPPE(Guid IDPE)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                PMDS.db.Entities.SPPE rSPPE = PMDSBusiness1.GetSPPE(db, IDPE);
                return rSPPE;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::GetSPPE()");
            }
        }

        public static bool PDXCodeExists(string PDXCode)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                return PMDSBusiness1.PDXCodeExists(db, PDXCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::PDXCodeExists()");
            }
        }

        public static bool ZusatzEintragExists(string ID)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                return PMDSBusiness1.ZusatzEintragExists(db, ID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::ZusatzEintragExists");
            }
        }

        public static bool MedikamentUsed(Guid IDMedikament)
        {
            try
            {
                PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                return PMDSBusiness1.MedikamentUsed(db, IDMedikament);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - DBUtil::MedikamentUsed");
            }
        }

        public static Nullable<Guid> getIDBerufsstand(PMDS.Global.eBerufsstand Berufsstand)
        {
            try
            {
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.AuswahlListe rAuswahliste = null;
                    if (Berufsstand == eBerufsstand.Arzt)
                    {
                        rAuswahliste = PMDSBusiness1.GetAuswahlliste(db, "BER", PMDS.Global.ENV.BerufsstandArzt);
                    }
                    else if (Berufsstand == eBerufsstand.Pflege)
                    {
                        rAuswahliste = PMDSBusiness1.GetAuswahlliste(db, "BER", PMDS.Global.ENV.BerufsstandPflege);
                    }
                    else if (Berufsstand == eBerufsstand.Therapie)
                    {
                        rAuswahliste = PMDSBusiness1.GetAuswahlliste(db, "BER", PMDS.Global.ENV.BerufsstandTherapie);
                    }

                    
                    if (rAuswahliste != null)
                    {
                        return rAuswahliste.ID;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.DB.DBUtil.getIDBerufsstand: " + ex.ToString());
            }
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
		/// Genau eine Datenzeile zurückliefern
		/// </summary>
		//----------------------------------------------------------------------------
		public static void OneRowByID(object owner, DataTable t, OleDbDataAdapter da)
		{

            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
            {
                // Daten erfolgreich gelesen ?
                if (DataBase.Fill(da, t) != 1)
                {
                    string ID = da.SelectCommand.Parameters[0].Value.ToString();
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ein eindeutiger Eintrag aus der Liste " + ID + " konnte nicht gefunden werden!", "ACHTUNG - Fehlerhafte Verarbeitung!", System.Windows.Forms.MessageBoxButtons.OK);
                    return;

                    //throw new DBException(Settings.String("DB.E_ID_NOT_FOUND", owner.GetType().ToString(), da.SelectCommand.Parameters[0].Value.ToString()));
                } 
            }
	    }

		//----------------------------------------------------------------------------
		/// <summary>
		/// Exception Ursache ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static string ExceptionMessage(OleDbException e)
		{
			string s= null;
			foreach(OleDbError error in e.Errors)
			{
				if (s == null)	s = FindFK_Exception(error.Message);
				if (s == null)	s = Findui_Exception(error.Message);
				if (s != null)	break;
			}
			return s;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Exception Ursache bei 'FK_...' ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static string FindFK_Exception(string text)
		{
			Regex r = new Regex(@"'FK_(?<P1>[^_]+)_(?<P2>[^']+)", RegexOptions.IgnoreCase);
			Match m = r.Match(text);
			if (m.Success)
			{
				return string.Format("{0} <-> {1}", m.Groups["P1"].Value, m.Groups["P2"].Value);
			}
			return null;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Exception Ursache bei 'ui...' ermitteln
		/// </summary>
		//----------------------------------------------------------------------------
		public static string Findui_Exception(string text)
		{
			Regex r = new Regex(@"'ui(?<P1>[^']+)", RegexOptions.IgnoreCase);
			Match m = r.Match(text);
			if (m.Success)
			{
				return string.Format("{0}", m.Groups["P1"].Value);
			}
			return null;
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Iterator für Row-Abarbeitung (ohne Seiteneffekt) in bezug auf
		/// das löschen von Rows.
		/// </summary>
		//----------------------------------------------------------------------------
		public static System.Collections.IEnumerable CurrentRows(DataTable t) 
		{
			return t.Select("","", DataViewRowState.CurrentRows);
		}
	}
}
