using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    


    public class Belegung
    {
        private DBBelegung _db = new DBBelegung();
        private dsBelegung.BelegungDataTable _dt = new dsBelegung.BelegungDataTable();



        public void Read(Guid IDAbteilung, DateTime von, DateTime bis)
        {
            _dt = _db.Read(IDAbteilung, von, bis);
        }

        public dsBelegung.BelegungDataTable BELEGUNG_DATATABLE
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

        public void Auffuellen(Guid IDAbteilung, DateTime von, DateTime bis, int AnzahlBetten)
        {
            Ausfuellen(IDAbteilung, von, bis, AnzahlBetten, false);
        }

        public void Ueberschreiben(Guid IDAbteilung, DateTime von, DateTime bis, int AnzahlBetten)
        {
            Ausfuellen(IDAbteilung, von, bis, AnzahlBetten, true);
        }

        private void Ausfuellen(Guid IDAbteilung, DateTime von, DateTime bis, int AnzahlBetten, bool bOverwrite)
        {
            DateTime dtstart = von.Date;
            DateTime dtend = bis.Date.AddDays(1);

            while (dtend > dtstart)
            {
                dsBelegung.BelegungRow rn;
                dsBelegung.BelegungRow rf = FindRow(IDAbteilung, dtstart);
                if (rf == null)
                    rn = _dt.NewBelegungRow();
                else
                    rn = rf;

                if (rf == null || bOverwrite)
                {
                    rn.AnzahlBetten = AnzahlBetten;
                    if (rf == null)
                    {
                        rn.ID           = Guid.NewGuid();
                        rn.IDAbteilung  = IDAbteilung;
                        rn.Tag          = dtstart.Date;
                        rn.Belegung     = 0;
                        rn.AnzahlBetten = AnzahlBetten;
                        _dt.AddBelegungRow(rn);
                    }
                }

                dtstart = dtstart.AddDays(1);
            }
        }

        private dsBelegung.BelegungRow FindRow(Guid IDAbteilung, DateTime dtdate)
        {
            foreach (dsBelegung.BelegungRow r in _dt)
                if (r.IDAbteilung == IDAbteilung && r.Tag == dtdate)
                    return r;
            return null;
        }

        public static int AnzahlBettenTag(DateTime dtDay)
        {
            return DBBelegung.AnzahlBettenTag(dtDay);
        }

        public static void BelegungTag(DateTime dtday, out int iBelegung, out int iUrlaube)
        {
            iBelegung = 0;
            iUrlaube = 0;
            DBBelegung.BelegungTag(dtday, out iBelegung, out iUrlaube);
        }
    }
}
