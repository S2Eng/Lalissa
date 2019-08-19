using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    

    public class Essen
    {
        private DBEssen                 _db = new DBEssen();
        private dsEssen.EssenDataTable  _dt = new dsEssen.EssenDataTable();



        public void Read(DateTime von, DateTime bis)
        {
            _dt.Clear();
            _dt = _db.Read(von, bis);
            Ausfuellen(von, bis);
        }

        // Alle nicht vorhandenen tage erzeugen und die Bettenbelegung und die Anzahlbetten aktualisieren
        private void Ausfuellen(DateTime von, DateTime bis)
        {
            DateTime dtstart    = von.Date;
            DateTime dtend      = bis.Date.AddDays(1);

            while (dtend > dtstart)
            {
                dsEssen.EssenRow rn;
                dsEssen.EssenRow rf = FindRow(dtstart);
                if (rf == null)
                    rn = _dt.NewEssenRow();
                else
                    rn = rf;

                int iBelegung   = 0;
                int iUrlaube    = 0;
                Belegung.BelegungTag(dtstart, out iBelegung, out iUrlaube);                 // Die Belegung und die Anzahl verfügbare Betten immer aktualisieren
                rn.Belegung     = iBelegung;
                rn.Urlaube      = iUrlaube;
                rn.AnzahlBetten = Belegung.AnzahlBettenTag(dtstart);
                    
                if (rf == null)
                {
                    rn.ID               = Guid.NewGuid();
                    rn.Tag              = dtstart.Date;
                    rn.EssenGaeste      = 0;
                    rn.EssenPersonal    = 0;
                    _dt.AddEssenRow(rn);
                }


                dtstart = dtstart.AddDays(1);
                if (dtstart > DateTime.Now)
                    break;
            }
        }

        private dsEssen.EssenRow FindRow(DateTime dtdate)
        {
            foreach (dsEssen.EssenRow r in _dt)
                if (r.Tag == dtdate)
                    return r;
            return null;
        }

        public dsEssen.EssenDataTable ESSEN_DATATABLE
        {
            get
            {
                return _dt;
            }
        }

        public void Write()
        {
            _db.Write(_dt);
        }

    }
}
