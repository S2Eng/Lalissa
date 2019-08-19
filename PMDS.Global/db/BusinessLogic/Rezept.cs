using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


	public class Rezept 
	{
		private DBRezept _db = new DBRezept();


        public Rezept()
        {
        }


        // Liefert true wenn das angegebene Medikament in Verwendung ist
        public static bool IsMedikamentInUse(Guid IDMedikament)
        {
            return DBRezept.IsMedikamentInUse(IDMedikament);
        }

	    // Alle RezeptEinträge lesen
        public dsRezeptEintrag.RezeptEintragDataTable Read(Guid IDAufenthalt)
        {
            return _db.Read(IDAufenthalt);
        }

        public void Update(dsRezeptEintrag.RezeptEintragDataTable dt)
        {
            // RezeptEintraege korrigieren (nur geänderte und neue)
            foreach (dsRezeptEintrag.RezeptEintragRow r in dt.Select("", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Added))
            {
                if (r.IDBenutzer_Erstellt == Guid.Empty)
                {
                    r.IDBenutzer_Erstellt = r.IDBenutzer_Erstellt;
                    r.DatumErstellt = r.DatumGeaendert;
                }
            }
            _db.Update(dt);
        }

        public static dsRezeptEintrag.RezeptEintragRow InitRezeptEintrag(dsRezeptEintrag.RezeptEintragRow row, Guid IDAufenthalt)
        {
            TimeSpan ts = new TimeSpan(23, 23, 59);
            row.ID                  = Guid.NewGuid();
            row.StandardzeitenJN    = true;
            row.AbzugebenBis        = DateTime.Now.Date.Add(ts);    // Tagesende
            row.AbzugebenVon        = DateTime.Now.Date;            // Tagesanfang
            row.IDAufenthalt        = IDAufenthalt;
            row.IDAerzte            = Guid.Empty;
            row.ZP0                 = 0;
            row.ZP1                 = 0;
            row.ZP2                 = 0;
            row.ZP3                 = 0;
            row.ZP4                 = 0;
            row.ZP5                 = 0;
            row.ZP6                 = 0;
            row.Intervall           = 0;
            row.DatumErstellt       = DateTime.Now;
            row.DatumGeaendert      = DateTime.Now;
            row.Wiederholungseinheit = 0;
            row.Wiederholungstyp    = 0;
            row.Wiederholungswert   = 0;
            row.Wochentage          = 0;
            row.Verabreichungsart   = 0;
            row.BestellenJN         = false;
            row.Packunggroesse = 0;
            row.Packungsanzahl = 1;
            row.SetIDAerzteGeaendertNull();
            row.SetIDArztAbgesetztNull();
            row.HAGPflichtigJN = false;
            row.lstMedDaten = "";
            row.NumberMedDaten = 0;
            row.lstWunden = "";
            row.NumberWunden = 0;

            return row;
        }

        /// Alle Patienten die ein bestimmtes Medikamnet verschriebn haben anzeigen
        public dsKlientenListeByMedikament.PatientDataTable KlientenListeByMedikament(Guid IDMedikament, Guid IDAufenthalt)
        {
            return _db.KlientenListeByMedikament(IDMedikament,IDAufenthalt);
        }
        
        // Liefert alle Bedarfsmedikamente des Aufentahltes eines Klienten welche zum angegebenen Tag gültig sind
        // Textspalte: [Medikamentbezeichnung||Bemerkung zum Medikament]
        public static dsGUIDListe.IDListeDataTable GetBedarfsMedikamente(Guid IDAufenthalt, DateTime Tag)
        {
            return DBRezept.GetBedarfsMedikamente(IDAufenthalt, Tag);
        }

        
    }
}
