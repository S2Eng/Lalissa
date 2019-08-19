using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB;
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Data.Global;
using System.Drawing;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


    public class QM
    {
        public static Rectangle _LastFormViewArea = new Rectangle(0,0,0,0);
        private DBQM _db = new DBQM();


        //	Liefert die Zusatzeinträge zu einem Eintrag
        public static void FillZusatzRows(Guid IDEintrag, QMEintrag QMe)
        {
            QMe._zusatzrows.Clear();
            DBQM db = new DBQM();
            dsZusatzwerteForEintrag.ZusatzEintragDataTable dt = db.GetZusatzwerte(IDEintrag, ENV.ABTEILUNG);
            foreach (dsZusatzwerteForEintrag.ZusatzEintragRow r in dt)
                QMe._zusatzrows.Add(r);
        }

        //	Liefert auf basis des letzten gemeldeten den nächten zu meldenden
        // berücksichtigt bei bedarf das zuerledigen bis
        public static DateTime GetNextPflegeEintragTime(dsPflegePlan.PflegePlanRow r, bool bUseZuerledigenBis)
        {
            DateTime time = r.IsLetztesDatumNull() ? r.StartDatum : r.LetztesDatum;		// Wenn noch kein Letztes Datum gesetzt dann startdatum ohne Intervall nehmen
            if (!r.IsLetztesDatumNull())
                time = time.AddHours(r.Intervall);
            if (bUseZuerledigenBis && !r.IsZuErledigenBisNull())
                time = new DateTime(time.Year, time.Month, time.Day, r.ZuErledigenBis.Hour, r.ZuErledigenBis.Minute,0);

                //Wenn der Zeitanteil in ZuErledigenBis < ist als der Zeitanteil im Zeitpunkt handelt es sich um den Folgetag
                DateTime t1 = new DateTime(2000, 1, 1, time.Hour, time.Minute, 0);
                DateTime t2 = new DateTime(2000, 1, 1, r.ZuErledigenBis.Hour, r.ZuErledigenBis.Minute, 0);
                if (t2 < t1) time = time.AddDays(1);

            return time;
        }

        public static void  WriteZusatzWerte(dsZusatzWert.ZusatzWertDataTable dt)
        {
            DBQM db = new DBQM();
            db.WriteZusatzWerte(dt);
        }

    }

    //	Repräsentiert einen QM Button 
    public class QMEintrag : IComparable
    {
        public Guid                             IDEintrag;  // Die M bzw bei terminen immer Guid.Empty
        public string                           Firsttext;  // Der erste Text (könnte bei Untertägigen unterschiedlich sein) - bei Terminen der Termintext
        public List<cPflegepläneProButton> _pprows = new List<cPflegepläneProButton>();
        public List<dsZusatzwerteForEintrag.ZusatzEintragRow>   _zusatzrows     = new List<dsZusatzwerteForEintrag.ZusatzEintragRow>();

        public class cPflegepläneProButton
        {
            public dsPflegePlan.PflegePlanRow r = null;
            public PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention = null;
        }

        //	Liefert die Anzahl der Untertägigen oder 1 bei nicht untertägigen
        public int COUNT
        {
            get
            {
                return _pprows.Count;
            }
        }

        public bool HasZusatz { get { return _zusatzrows.Count > 0; } }     // Liefert true wenn es Zusatzwerte gibt

        //	Liefert true wenn zwingend ein Dialog aufgehen muss
        public bool MeldungZwingend
        {
            get
            {
                if(_pprows[0].r.RMOptionalJN == false && ENV.ABTEILUNG_RMOPTIONAL==false)
                    return true;

                bool bRet = false;
                foreach (dsZusatzwerteForEintrag.ZusatzEintragRow r in _zusatzrows)
                {
                    if (!r.OptionalJN)
                    {
                        bRet = true;
                        break;
                    }
                }
                return bRet;
            }
        }

        public override string ToString()
        {
            return Firsttext;
        }

        #region IComparable Member

        public int CompareTo(object obj)
        {
            return string.Compare(Firsttext, obj.ToString());
        }

        #endregion

    }

    
}
