using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{
    public class SP
    {
        private DBSP    _db = new DBSP();



        public SP()
        {
        }



        public dsSP Read(Guid IDSP)
        {
            return _db.Read(IDSP);
        }

        public void Write(dsSP ds)
        {
            _db.Write(ds);
        }

        //	Erzeugt eine neue Struktur für die Weiterverarbeitung in zB ucNotfall
        public dsSP NewFromStandardProzedur(Guid IDStandardProzedur, Guid IDAufenthalt, Guid IDBenutzer)
        {
            EintragStandardprozeduren esp = new EintragStandardprozeduren();
            esp.ReadByStandardprozedur(IDStandardProzedur);                     // Alle einträge zur SP lesen

            dsSP ds = new dsSP();
            // Grundelement erzeugen (SP)
            Guid IDSP = Guid.NewGuid();
            ds.SP.AddSPRow(IDSP, DateTime.Now, IDStandardProzedur, "", IDBenutzer, IDBenutzer, DateTime.Now, DateTime.Now, false, IDAufenthalt, new DateTime(1900,1,1));

            // für jeden Eintrag einen DS in SPPOS erzeugen
            foreach (dsEintragStandardprozeduren.EintragStandardprozedurenRow r in esp.EintragStdProzedurenByIDStdProz)
            {
                dsSP.SPPOSRow rn = ds.SPPOS.AddSPPOSRow(Guid.NewGuid(), IDSP, r.IDEintrag, false, "", IDBenutzer, IDBenutzer, DateTime.Now, DateTime.Now, false, DateTime.Now);
                rn.SetwiederumamNull();
            }

            return ds;
        }

        //	Liefert einen Formatierten String zum Vorfall
        public static string ToStringFromRow(dsSP.SPRow r)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(StandardProzeduren.GetBezeichnung(r.IDStandardProzeduren));
            sb.Append(" vom ");
            sb.Append(r.EreignisZeitpunkt.ToShortDateString());
            sb.Append(" ");
            sb.Append(r.EreignisZeitpunkt.ToShortTimeString());
            sb.Append(": ");
            sb.Append(r.Anmerkung.Trim());
            return sb.ToString();
        }

        //	Liefert einen Formatierten String zum Vorfall
        public static bool NotfallJN(dsSP.SPRow r)
        {
            return StandardProzeduren.GetNotfallFlag(r.IDStandardProzeduren);
        }

        //	Liefert zum aufenthalt alle offenen SPs
        public dsSP.SPDataTable AllOpen(Guid IDAufenthalt)
        {
            return _db.ReadAllOpen(IDAufenthalt);
        }

        //	Liefert zum aufenthalt ob SP offen oder nicht
        public bool HasOpen(Guid IDAufenthalt)
        {
            return _db.HasOpenFromAufenthalt(IDAufenthalt);
        }

        //	Liefert Alle M mit nächtem Datum wenn SPPOS = offen
        public static List<SPNextHelper> AllOpenSPPos(Guid IDSP)
        {
            return DBSP.AllOpenSPPos(IDSP);
        }
    }

   
}
