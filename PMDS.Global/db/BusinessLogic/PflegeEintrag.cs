using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;


namespace PMDS.BusinessLogic
{



	public class PflegeEintrag : BusinessBase, IBusinessBase, IZusatz
	{
		public object			_Tag;

		private DBPflegeEintrag _db = new DBPflegeEintrag();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

        // Liefert sämtliche zu einer Evaluierung gehörenden Pflegeeinträge eines Aufenthaltes
        public static dsPflegeEintrag AllAufenthaltEvaluierung(Guid IDAufenthalt, Guid IDPflegeplan)
        {
            DBPflegeEintrag db = new DBPflegeEintrag();
            return db.ByAufenthaltEvaluierung(IDAufenthalt, IDPflegeplan);
        }

		// Alle Einträge mit dem zugehörigen Aufenthalt ermitteln
		public static dsPflegeEintrag.PflegeEintragDataTable ByAufenthalt(Guid id)
		{
			return new DBPflegeEintrag().ByAufenthalt(id);
		}

        public static PflegeEintrag NewByAufenthalt(Guid idAufenthalt, string PflegeplanText, PflegeEintragTyp PflegeEintragTyp, string DekursText, bool GegenzeichnenJN)
		{
			PflegeEintrag pe = new PflegeEintrag();
            
			pe.IDBenutzer	= ENV.USERID;
			pe.IDBerufsstand= ENV.BERUFID;
			pe.IDAufenthalt	= idAufenthalt;
            pe.EintragsTyp = PflegeEintragTyp;
            pe.PflegeplanText = PflegeplanText.Trim();
            pe.Text = DekursText.Trim();
            pe.AbzeichnenJN = GegenzeichnenJN;
			return pe;
		}

		// Neuer Eintrag für Aufenthalt/Eintrag
		public static PflegeEintrag NewByMassnahme(Guid idAufenthalt, Guid idMassnahme)
		{
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, QS2.Desktop.ControlManagment.ControlManagment.getRes("Durchführungsnachweis"), PflegeEintragTyp.UNEXP_MASSNAHME, "", false);  

            if (idMassnahme != System.Guid.Empty)
                pe.IDEintrag = idMassnahme;
            pe.EintragsTyp = PflegeEintragTyp.UNEXP_MASSNAHME;
            return pe;
		}

		// Neuer Eintrag für Aufenthalt/Eintrag/Pflegeplan
		public static PflegeEintrag NewByPflegePlan(Guid idAufenthalt,
													Guid idPflegePlan, Guid idMassnahme,
													DateTime time, bool bEvaluierung)
		{
			PflegeEintrag pe = NewByMassnahme(idAufenthalt, idMassnahme);
			pe.IDPflegePlan	= idPflegePlan;
			pe.Zeitpunkt	= time;
            pe.EintragsTyp = PflegeEintragTyp.MASSNAHME;
			return pe;
		}

		// Neuer Eintrag für Termin
		public static PflegeEintrag NewByTermin(Guid idAufenthalt,Guid idPflegePlan,
												DateTime time, bool bEvaluierung)
		{
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Termin", PflegeEintragTyp.TERMIN, "", false);
			pe.IDPflegePlan	= idPflegePlan;
			pe.Zeitpunkt	= time;
            pe.EintragsTyp = PflegeEintragTyp.TERMIN;
            return pe;
		}

		// Neuer Eintrag für Medikament
		public static PflegeEintrag NewMedikament(Guid idAufenthalt,Guid idPflegePlan,
			DateTime time)
		{
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Dekurs", PflegeEintragTyp.DEKURS, "", false);
			pe.IDPflegePlan	= idPflegePlan;
			pe.Zeitpunkt	= time;
			pe.EintragsTyp	= PflegeEintragTyp.MEDIKAMENT;
            pe.PflegeplanText = "Medikation";			
			return pe;
		}

        // Neuer Eintrag für MedikamentAbgabeAbzeichnen
        public static void NewMedikamentVorbereitenAbzeichnenEinfuegen(Guid idAufenthalt, DateTime time, Guid IDBenutzer)
        {
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Dekurs", PflegeEintragTyp.DEKURS, "", false);
            pe.Zeitpunkt        = time;
            pe.EintragsTyp      = PflegeEintragTyp.MEDIKAMENT;
            pe.PflegeplanText = "Medikation";
            pe.Text             = "Medikament(e) vorbereitet";
            pe.IDBenutzer       = IDBenutzer;

            pe.Write();
        }

        // Neuer Eintrag für Rezeptänderung
        public static void NewRezeptAenderungEinfuegen(Guid idAufenthalt, DateTime time, Guid IDMedikament, string Aktion, bool GegenzeichnenJN, Guid IDWichtigFür,
                                                        bool HAGPflichtigJN)
        {
            PMDS.DB.PMDSBusiness b = new PMDSBusiness();

            PMDS.DB.DBMedikament medik = new PMDS.DB.DBMedikament();
            PMDS.Global.db.Patient.dsMedikament.MedikamentDataTable dtMed = medik.ReadMedikament(IDMedikament);
            string Medikament = ((PMDS.Global.db.Patient.dsMedikament.MedikamentRow)dtMed.Rows[0]).Bezeichnung.Trim();

            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Dekurs", PflegeEintragTyp.DEKURS, "", false);
            pe.Zeitpunkt = time;
            db.Entities.Benutzer rusrLoggedOn = b.LogggedOnUser();
            if (rusrLoggedOn.IDBerufsstand != null)
                pe.IDBerufsstand = ENV.BERUFID;
            pe.EintragsTyp = PflegeEintragTyp.MEDIKAMENT;
            pe.PflegeplanText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikation"); ;
            pe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikation") + " " + Medikament + " " + Aktion;
            if (IDWichtigFür != System.Guid.Empty)
                pe.IDWichtig = IDWichtigFür;
            pe.AbzeichnenJN = GegenzeichnenJN;
            pe.HAGPflichtigJN = HAGPflichtigJN;
            pe.Write();

            Guid IDGruppe = System.Guid.NewGuid();

            System.Collections.Generic.List<Guid> lstWichtigFuer = PMDS.Global.Tools.GetWichtigFuerDefaults(eDekursDefaults.Medikation.ToString());
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                System.Collections.Generic.List<Guid> lstPEToCopy = new System.Collections.Generic.List<Guid>();
                b.CopyAndAddPflegeeinträgeCC(db, pe.ID, ref lstWichtigFuer, false, true, GegenzeichnenJN, IDWichtigFür, ref lstPEToCopy, false, ref IDGruppe);
            }

        }

        public static void InsertPflegeeintrag(Guid idAufenthalt, DateTime time, string Txt, PflegeEintragTyp PflegeEintragTyp, string PflegePlanText)
        {
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, PflegePlanText, PflegeEintragTyp, "", false);
            pe.Zeitpunkt = time;
            pe.IDBerufsstand = ENV.BERUFID;
            pe.EintragsTyp = PflegeEintragTyp;
            pe.PflegeplanText = PflegePlanText.Trim();
            pe.Text = Txt.Trim();
            pe.Write();
        }

        // Neuer Eintrag fürNotfall
        public static Guid NewNotfallBerichtEinfuegen(Guid idAufenthalt, DateTime time, string sText, Guid IDWichtig)
        {
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Dekurs", PflegeEintragTyp.DEKURS, "", false);
            pe.Zeitpunkt = time;
            pe.IDBerufsstand = ENV.BERUFID;
            pe.EintragsTyp = PflegeEintragTyp.DEKURS;
            pe.PflegeplanText = "Dekurs zu Notfall";
            pe.Text = sText;
            if (IDWichtig != Guid.Empty)
                pe.IDWichtig = IDWichtig;
            pe.Write();
            return pe.ID;
        }

        // Neuer Eintrag für FeienBericht
        public static Guid NewFreienBerichtEinfuegen(Guid idAufenthalt, DateTime time, string sText, Guid IDWichtig)
        {
            PflegeEintrag pe = NewByAufenthalt(idAufenthalt, "Dekurs", PflegeEintragTyp.DEKURS, "", false);
            pe.Zeitpunkt = time;
            pe.IDBerufsstand = ENV.BERUFID;
            pe.EintragsTyp = PflegeEintragTyp.DEKURS;
            pe.PflegeplanText = "Dekurs";
            pe.Text = sText;
            if (IDWichtig != Guid.Empty)
                pe.IDWichtig = IDWichtig;
            pe.Write();
            return pe.ID;
        }

		public PflegeEintrag()
		{
			New();
		}
		public PflegeEintrag(Guid id)
		{
			Read(id);
		}

		#region Datenbank-Mapper
		protected dsPflegeEintrag.PflegeEintragRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
		public Guid ID
		{
			get	{	return DB_ROW.ID;		}
			set	{	DB_ROW.ID = value;		}
		}
		public Guid IDAufenthalt
		{
			get	{	return DB_ROW.IDAufenthalt;		}
			set	{	DB_ROW.IDAufenthalt = value;	}
		}
		public Guid IDPflegePlan
		{
			get	
			{
				if (DB_ROW.IsIDPflegePlanNull())
					return Guid.Empty;

				return DB_ROW.IDPflegePlan;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDPflegePlanNull();
				else
					DB_ROW.IDPflegePlan = value;
			}
		}
		public Guid IDEintrag
		{
			get	
			{
				if (DB_ROW.IsIDEintragNull())
					return Guid.Empty;

				return DB_ROW.IDEintrag;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDEintragNull();
				else
					DB_ROW.IDEintrag = value;
			}
		}
        public Guid IDExtern
        {
            get
            {
                if (DB_ROW.IsIDExternNull())
                    return Guid.Empty;

                return DB_ROW.IDExtern;
            }

            set
            {
                if (value == Guid.Empty)
                    DB_ROW.SetIDExternNull();
                else
                    DB_ROW.IDExtern = value;
            }
        }
		public Guid IDBenutzer
		{
			get	{	return DB_ROW.IDBenutzer;	}
			set	{	DB_ROW.IDBenutzer = value;	}
		}
		public Guid IDBerufsstand
		{
			get	{	return DB_ROW.IDBerufsstand;	}
			set	
            {
                if (value == Guid.Empty)
                    DB_ROW.SetIDBerufsstandNull();
                else
                    DB_ROW.IDBerufsstand = value;	
            }
		}
		public DateTime DatumErstellt
		{
			get	{	return DB_ROW.DatumErstellt;	}
			set	{	DB_ROW.DatumErstellt = value;	}
		}
		public DateTime Zeitpunkt
		{
			get	{	return DB_ROW.Zeitpunkt;	}
			set	{	DB_ROW.Zeitpunkt = value;	}
		}
        public string LogInNameFrei
		{
            get { return DB_ROW.LogInNameFrei; }
            set { DB_ROW.LogInNameFrei = value; }
		}
        public Guid IDBefund
        {
            get { return DB_ROW.IDBefund; }
            set
            {
                if (value == Guid.Empty)
                    DB_ROW.SetIDBefundNull();
                else
                    DB_ROW.IDBefund = value;
            }
        }
        
		public string PflegeplanText
        {
            get { return DB_ROW.PflegeplanText; }
            set { DB_ROW.PflegeplanText = value; }
        }
        public string Text
		{
			get	{	return DB_ROW.Text;	}
			set	{	DB_ROW.Text = value;}
		}
        public string TextRtf
        {
            get { return DB_ROW.TextRtf; }
            set { DB_ROW.TextRtf = value; }
        }
		public int IstDauer
		{
			get	{	return DB_ROW.IstDauer;	}
			set	{	DB_ROW.IstDauer = value;}
		}
		public bool DurchgefuehrtJN
		{
			get	{	return DB_ROW.DurchgefuehrtJN;	}
			set	{	DB_ROW.DurchgefuehrtJN = value;}
		}
		public PflegeEintragTyp EintragsTyp
		{
			get	{	return (PflegeEintragTyp)DB_ROW.EintragsTyp;	}
			set	{	DB_ROW.EintragsTyp = (int)value;				}
		}
		public PflegeEintragWichtig Wichtig
		{
			get	{	return (PflegeEintragWichtig)DB_ROW.Wichtig;	}
			set	{	DB_ROW.Wichtig = (int)value;				}
		}
		
        public Guid IDWichtig
		{
			get	
			{
				if (DB_ROW.IsIDWichtigNull())
					return Guid.Empty;

				return DB_ROW.IDWichtig;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDWichtigNull();
				else
					DB_ROW.IDWichtig = value;
			}
		}
        public PMDS.Global.eDekursherkunft Dekursherkunft
        {
            get 
            {
                return (PMDS.Global.eDekursherkunft)DB_ROW.Dekursherkunft;
            }
            set
            {
                DB_ROW.Dekursherkunft = (int)value;
            }
        }
        public bool AbzeichnenJN
        {
            get
            {
                return DB_ROW.AbzeichnenJN;
            }
            set
            {
                DB_ROW.AbzeichnenJN = value;
            }
        }
        public bool HAGPflichtigJN
        {
            get
            {
                return DB_ROW.HAGPflichtigJN;
            }
            set
            {
                DB_ROW.HAGPflichtigJN = value;
            }
        }
        public Guid IDEvaluierung
        {
            get
            {
                if (DB_ROW.IsIDEvaluierungNull())
                    return Guid.Empty;

                return DB_ROW.IDEvaluierung;
            }

            set
            {
                if (value == Guid.Empty)
                    DB_ROW.SetIDEvaluierungNull();
                else
                    DB_ROW.IDEvaluierung = value;
            }
        }

        public ZielEvaluierungsStatus EvalStatus
        {
            get { return (ZielEvaluierungsStatus)DB_ROW.EvalStatus; }
            set { DB_ROW.EvalStatus = (int)value; }
        }
		#endregion

		#region IBusinessBase Members

		DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		#region IZusatz Members

		/// Zusatzwerte anhand der Abteilung für den aktuellen PflegeEintrag ermitteln 
		object IZusatz.ZusatzWertForAbteilung(Guid idAbteilung)
		{
			if (IsMassnahme() || IsUnexpMassnahme())
				return new ZusatzWert("MASS", idAbteilung, ID, IDEintrag);
			else
				return new ZusatzWert();
		}

		#endregion

		public bool IsEvaluierung()
		{
			return (EintragsTyp == PflegeEintragTyp.EVALUIERUNG);
		}

		public bool IsMassnahme()
		{
			return (EintragsTyp == PflegeEintragTyp.MASSNAHME);
		}
		public bool IsPflegePlan()
		{
			return (IsEvaluierung() || IsMassnahme());
		}
		public bool IsUnexpMassnahme()
		{
			return (EintragsTyp == PflegeEintragTyp.UNEXP_MASSNAHME);
		}
        public bool IsDekurs()
		{
            return (EintragsTyp == PflegeEintragTyp.DEKURS);
		}
		public bool IsTermin()
		{
			return (EintragsTyp == PflegeEintragTyp.TERMIN);
		}
		public bool IsMedikament()
		{
			return (EintragsTyp == PflegeEintragTyp.MEDIKAMENT);
		}
        
        // Liefert zu einem bestimmten Aufenthalt und eintrag ein letztes Durchführungsdatum oder null wenn kein Eintrag gefunden wurde
        public static dsPflegeEintrag.PflegeEintragRow GetLastByAufenthalt(Guid IDAufenthalt, Guid IDEintrag)
        {
            return DBPflegeEintrag.GetLastByAufenthalt(IDAufenthalt, IDEintrag);
        }

	}
}
