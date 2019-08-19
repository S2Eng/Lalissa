using System;
using PMDS.DB;
using System.Collections.Specialized;
using System.Collections;
using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{



	public class PDx
	{
		private KatalogCollection	_Kataloge = null;
		public DBPDx				_DBPDx = null;
		private DBPDxEintrag		_DBPDxEintrag = null;



		public PDx()
		{
			_DBPDx			= new DBPDx();
			_DBPDxEintrag	= new DBPDxEintrag();
		}

		public static EintragGruppe GetEintragGruppeFromChar(char sGroup) 
		{
			switch(sGroup) 
			{
				case 'A':
					return EintragGruppe.A;
				case 'S':
					return EintragGruppe.S;
                case 'R':
                    return EintragGruppe.R;
                case 'Z':
					return EintragGruppe.Z;
				case 'M':
					return EintragGruppe.M;
				case 'T':
					return EintragGruppe.T;
				default:
					throw new Exception("Group not defined - PDx.GetEintragGrupprFromChar()");

			}
		}

		public KatalogCollection KATALOGE 
		{
			get 
			{
				if(_Kataloge == null)
					_Kataloge = new KatalogCollection();
				return _Kataloge;
			}
		}

		public dsPDx.PDXDataTable PDXEINTRAEGE 
		{
			get 
			{
				return _DBPDx.PDXEINTRAEGE;
			}
		}

		public dsPDx.PDXRow ReadOne(Guid IDPDX)
		{
			return _DBPDx.ReadOne(IDPDX);
		}


		public dsPDxGruppe.PDXGruppeDataTable GetAllTopGruppen(Guid IDAbteilung)
		{
			return _DBPDx.GetAllTopGruppen(IDAbteilung);

		}
        
		public void UpdatePDXEintragZuordnung(Guid[] aIDEintrag, Guid IDAbteilung, Guid IDPDx) 
		{
			_DBPDxEintrag.UpdatePDXEintragZuordnung(aIDEintrag, IDAbteilung, IDPDx);
		}
		public void UpdatePDXGruppenEintrag(Guid[] aIDPDx, Guid IDPDxGruppe) 
		{
			_DBPDx.UpdatePDXGruppenEintrag(aIDPDx, IDPDxGruppe);
		}

		// Liefert die Zugeordneten Einträge zu einer bestimmten Abteilung
		public dsPDxEintrag.PDXEintragDataTable GetZuordnungen(Guid IDPDx, Guid IDAbteilung)
		{
			return GetZuordnungen(IDPDx, IDAbteilung, true);
		}

        // Liefert die Zugeordneten Einträge zu einer bestimmten Abteilung
        // bReadEntfernte = true: Alle Einträge werden gelesen
        // bReadEntfernte = false: Nur nicht entfernte Einträge werden gelesen
        public dsPDxEintrag.PDXEintragDataTable GetZuordnungen(Guid IDPDx, Guid IDAbteilung, bool bReadEntfernte)
        {
            _DBPDxEintrag.Read(IDPDx, IDAbteilung, bReadEntfernte);
            return _DBPDxEintrag.PDXEINTRAG;
        }


		/// Aktualisiert eine PDx in der DB
		/// Die def muss korrekt ausgefüllt sein. Für neue Pdx muss die ID auch schon mit
		/// Guid.New belegt sein
		public void PdxToDB(PDXDef def) 
		{
			_DBPDx.PdxToDB(def);
		}
	
	
		public void PdxGruppeToDB(Guid ID,Guid IDAbteilung,string text,int reihe, bool bdelete)
		{
			_DBPDx.PdxGruppeToDB(ID, IDAbteilung,text,reihe, bdelete);
		}

		/// Eine PDx wird mit der DB abgeglichen
		public void PdxToDB(PDXDef def, bool bDelete) 
		{
			_DBPDx.PdxToDB(def, bDelete);
		}

		// Liefert alle PDXGruppen (Top 10 Gruppen) einer bestimmten Abteilung
		public dsIDTextBezeichnung GetAllPDxGruppeFromAbteilung(Guid IDAbteilung,bool Pflegeplanmodus_Wunde)
		{
            return _DBPDx.GetAllPDxGruppeFromAbteilung(IDAbteilung, Pflegeplanmodus_Wunde);
		}

		// Liefert alle PDX zu einer bestimmten Gruppe
		public dsIDTextBezeichnung GetPDxFromPDxGruppeID(Guid IDPDxGruppe) 
		{
			return _DBPDx.GetPDxFromPDxGruppeID(IDPDxGruppe);
		}

        // Liefert alle PDX zu einer bestimmten Gruppe
        // modus = Normal: Werden nur normale PDx'en geliefert.
        // modus = Wunden: Werden nur Wunden bezeichnete PDx'en geliefert.
        public dsIDTextBezeichnung GetPDxFromPDxGruppeID(Guid IDPDxGruppe, PflegePlanModus modus)
        {
            return _DBPDx.GetPDxFromPDxGruppeID(IDPDxGruppe, modus);
        }

        public dsPDxEintraege GetPDxZuordnugenFromSearchText(string sSearchCriteria, SearchCondition condition, PflegePlanModus modus, Guid IDAbteilung, bool PDxEntferntJN)
        {
            if (sSearchCriteria.Trim().Length == 0)		
                sSearchCriteria = "%";
            return _DBPDx.GetPDxZuordnugenFromSearchText(sSearchCriteria, condition, modus, IDAbteilung, PDxEntferntJN);
        }

        //Neu nach 13.10.2008 MDA
        public dsPDxEintraege GetWundenZuordnugen(Guid IDAbteilung)
        {
            return _DBPDx.GetWundenZuordnugen(IDAbteilung);
        }

		/// Liefert alle PDX zu einer bestimmten Gruppe
		public  dsIDTextBezeichnung GetPDxFromSearchText(string sSearchCriteria, SearchCondition condition) 
		{
			if(sSearchCriteria.Trim().Length == 0)	
				sSearchCriteria = "%";
			return _DBPDx.GetPDxFromSearchText(sSearchCriteria, condition);
		}

        // Liefert alle Pdx mit zugehörigen gefundenen Suchtext
        // sSearchCriteria beinhalte die Suchwörter durch leerzeichen getrennt
        // modus = Normal: Werden nur normale PDx'en geliefert.
        // modus = Wunden: Werden nur Wunden bezeichnete PDx'en geliefert.
        public dsIDTextBezeichnung GetPDxFromSearchText(string sSearchCriteria, SearchCondition condition, PflegePlanModus modus, bool PDxEntferntJN)
        {
            if (sSearchCriteria.Trim().Length == 0)		
                sSearchCriteria = "%";
            return _DBPDx.GetPDxFromSearchText(sSearchCriteria, condition, modus, PDxEntferntJN);
        }

        public dsIDTextBezeichnung GetPDxWunden()
        {
            return _DBPDx.GetPDxWunden();
        }

		// Liefert alle Einträge ohne PDx zugehörigkeit wo der Suchtext und die Suchkriterien entsprechen.
		// Die Abteilung wird berücksichtigt
		public dsPDxEintrag.PDXEintragDataTable GetEintragFromSearchText(string sSearchCriteria, SearchCondition condition, bool bGeneral) 
		{
			if(sSearchCriteria.Trim().Length == 0)	
				sSearchCriteria = "%";
			return _DBPDx.GetEintragFromSearchText(sSearchCriteria, condition, bGeneral);
		}

		/// Liefert alle Einträge mit PDx zugehörigkeit wo der Suchtext und die Suchkriterien entsprechen.
		/// Die Abteilung wird berücksichtigt
		public dsPDxEintrag.PDXEintragDataTable GetPDxEintragFromSearchText(string sSearchCriteria, SearchCondition condition, Guid IDAbteilung) 
		{
			if(sSearchCriteria.Trim().Length == 0)			// nix da ==> alles lesen
				sSearchCriteria = "%";
			return _DBPDx.GetPDxEintragFromSearchText(sSearchCriteria, condition, IDAbteilung);
		}

        public dsIDTextBezeichnung GetPDxByID(Guid IDPDx)
        {
            return _DBPDx.GetPDxByID(IDPDx);
        }
		
        public void InsertPDXEintragZuordnung(Guid aIDEintrag, Guid[] IDAbteilungen, Guid IDPDx)
        {
            _DBPDxEintrag.InsertPDXEintragZuordnung(aIDEintrag, IDAbteilungen, IDPDx);
        }

	}
    	

}
