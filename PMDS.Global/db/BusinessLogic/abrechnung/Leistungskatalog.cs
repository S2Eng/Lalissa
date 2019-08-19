using System;
using PMDS.Calc.Admin.DB;
using PMDS.Abrechnung.Global;
using PMDS.Global;

namespace PMDS.BusinessLogic.Abrechnung
{
	public class LeistungsKatalog
	{
		private DBLeistungskatalog _db = new DBLeistungskatalog();
      



		public LeistungsKatalog()
		{
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Eine Bestimmte Leistungsgruppe lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog Read(int Leistungsgruppe)
		{
			return _db.Read(Leistungsgruppe);
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Alle Einträge lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog.LeistungskatalogDataTable ReadAll()
		{
			return _db.ReadAll();
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Einen bestimmten Eintrag inkl. Childs lesen
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog ReadByID(Guid IDLeistungskatalog)
		{
			return _db.ReadByID(IDLeistungskatalog);
		}

		

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Änderungen updaten
		/// </summary>
		//--------------------------------------------------------------------------------
		public void Update(dsLeistungskatalog ds, bool bDelete)
		{
			_db.Update(ds, bDelete);
		}

        //Neu nach 02.01.2008 MDA
        public void Update(dsLeistungskatalog ds)
        {
            //Alle automatisch(durch löschen eine Leistungskatalog) gelöschte Rows in dsLeistungskatalog.LeistungskatalogGueltig entfernen
            //Sie werden mit Cascade gelöscht.
            dsLeistungskatalog.LeistungskatalogRow[] rows = (dsLeistungskatalog.LeistungskatalogRow[])ds.Leistungskatalog.Select("", "", System.Data.DataViewRowState.Deleted);
            dsLeistungskatalog.LeistungskatalogGueltigRow[] gRows;
            foreach (dsLeistungskatalog.LeistungskatalogRow r in rows)
            {
                r.RejectChanges();
                gRows = (dsLeistungskatalog.LeistungskatalogGueltigRow[])ds.LeistungskatalogGueltig.Select("IDLeistungskatalog = '" + r.ID.ToString() + "'", "", System.Data.DataViewRowState.Deleted);

                foreach (dsLeistungskatalog.LeistungskatalogGueltigRow rr in gRows)
                    ds.LeistungskatalogGueltig.RemoveLeistungskatalogGueltigRow(rr);
                r.Delete();
            }

            _db.Update(ds, false);
        }

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Neue Kopf ROW
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog.LeistungskatalogRow NewLeistungskatalog(dsLeistungskatalog.LeistungskatalogDataTable dt, int Leistungsgruppe)
		{
            dsLeistungskatalog.LeistungskatalogRow rNew = dt.AddLeistungskatalogRow(Guid.NewGuid(), "", "", "", Leistungsgruppe, 30, true, false, 128, true, System.Guid.Empty);
            rNew.SetIDKlinikNull();
            return rNew;
		}

		//--------------------------------------------------------------------------------
		/// <summary>
		/// Neue pos Row
		/// </summary>
		//--------------------------------------------------------------------------------
		public dsLeistungskatalog.LeistungskatalogGueltigRow NewLeistungsgruppeGueltig(dsLeistungskatalog ds, Guid IDLeistungskatalog)
		{

			dsLeistungskatalog.LeistungskatalogRow r =  ds.Leistungskatalog.FindByID(IDLeistungskatalog);
            DateTime datNew = new DateTime(DateTime.Now.Year, DateTime.Now.Month,1 );
            return ds.LeistungskatalogGueltig.AddLeistungskatalogGueltigRow(Guid.NewGuid(), r, datNew.Date  , 0, 20, 0, false);
		}

	}

    //--------------------------------------------------------------------------------
    /// <summary>
    /// Ein Eintrag im Leistungskatalog mit der richtigen Gültigkeitszeile
    /// </summary>
    //--------------------------------------------------------------------------------
    public class LeistungsKatalogInfo
    {
        private static DBLeistungskatalog _db = new DBLeistungskatalog();
        private dsLeistungskatalog.LeistungskatalogRow _lr;
        public dsLeistungskatalog.LeistungskatalogGueltigRow _lgr;
        private string _Addtext = "";
        private double _OriginalBetrag = 0;
        public double betragTagsatz = 0;

        public double OriginalBetrag
        {
            get { return _OriginalBetrag; }
            set { _OriginalBetrag = value; }
        }

        public string ADDTEXT
        {
            get { return _Addtext; }
            set { _Addtext = value; }
        }

        public dsLeistungskatalog.LeistungskatalogRow LEISTUNGSKATALOG
        {
            get { return _lr; }
        }
       
        public dsLeistungskatalog.LeistungskatalogGueltigRow LEISTUNGSKATALOGGUELTIG
        {
            get { return _lgr; }
        }

        public LeistungsKatalogInfo(Guid IDLeistungskatalog, int jahr, int monat)
        {
            DateTime dt = new DateTime(jahr, monat, 1);
            dsLeistungskatalog ds = _db.ReadByID(IDLeistungskatalog);
            _lr = ds.Leistungskatalog[0];
            _lgr = null;
            foreach (dsLeistungskatalog.LeistungskatalogGueltigRow rg in ds.LeistungskatalogGueltig.Select("", "Gueltigab desc"))
            {
                
                if (rg.GueltigAb.Date <= dt)
                {
                    _lgr = rg;
                    break;
                }
            }

            // Keine gültigen Einträge vorhanden ==> Dummy erstellen
            if (_lgr == null)
                _lgr = ds.LeistungskatalogGueltig.AddLeistungskatalogGueltigRow(Guid.NewGuid(), _lr, DateTime.Now, 0, 0, 0, false);
            
            OriginalBetrag = _lgr.Betrag;           // Original Betrag verspeichern (in _lgr wird bei nicht Monatsleistung der errechnete verspeichert

            // Wenn keine Monatsleistung dann ist der Betrag aufs Monat bezogen taggenau zu rechnen (nur für Wohn und Pflegekomponente gültig)
            //if (!_lr.MonatsleistungJN && (_lr.enumLeistungsgruppe == (int)Leistungsgruppe.Pflegekomponente || _lr.enumLeistungsgruppe == (int)Leistungsgruppe.Wohnkomponente))

            //Änderung nach 23.05.2008 MDA: Monatsleistung wir für alle Leistungsgruppen berücksichtigt. (anordnung von OS)
            if (!_lr.MonatsleistungJN)
            {
                //DateTime v = new DateTime(jahr, monat, 1);
                //DateTime b = v.AddMonths(1).AddDays(-1);
                //TimeSpan s = b - v;
                //int Days = s.Days + 1;      // Starttag mitzählen
                this.betragTagsatz = _lgr.Betrag;
                //ADDTEXT = string.Format("{0} Tage á {1:C}", Days, _lgr.Betrag);
                //_lgr.Betrag = _lgr.Betrag * Days;
            }
        }

        public double GetBetragForDays(int iDays)
        {
            if (_lr.MonatsleistungJN)       
            {
                double idiv = _lr.DivisorFuerMonatsleistung == 0 ? 30 : _lr.DivisorFuerMonatsleistung;
                return Math.Round(_lgr.Betrag * (double)iDays / idiv, 2);
            }
            else
            {
                return Math.Round(OriginalBetrag * (double)iDays, 2);
            }
            
        }

       
    }
}
