using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
    public class LinkDokumente
    {
        private DBLinkDokumente _db = new DBLinkDokumente();




        public dsLinkDokumente.LinkDokumenteDataTable ALL
        {
            get
            {
                return _db.ALL;
            }
        }

        public dsGUIDListe.IDListeDataTable ALL_IDLISTE
        {
            get
            {
                return _db.ALL_IDLISTE;
            }
        }

        public dsLinkDokumente.LinkDokumenteRow NewRow(dsLinkDokumente.LinkDokumenteDataTable dt)
        {
            dsLinkDokumente.LinkDokumenteRow r = dt.NewLinkDokumenteRow();
            r.ID                    = Guid.NewGuid();
            r.Beschreibung          = "";
            r.LinkName              = "";
            r.Gruppe                = "PST";            // zur Zeit nur Pflegestandards
            r.Erstellungsdatum      = DateTime.Now;
            r.Aenderungsdatum       = DateTime.Now;
            r.IDBenutzer_Erstellt   = ENV.USERID;
            r.IDBenutzer_Geaendert  = ENV.USERID;
            dt.AddLinkDokumenteRow(r);
            return r;
        }

        public dsLinkDokumente.LinkDokumenteDataTable GetByID(Guid ID)
        {
            return _db.GetByID(ID);
        }

        public void Update(dsLinkDokumente.LinkDokumenteDataTable dt)
        {
            foreach (dsLinkDokumente.LinkDokumenteRow r in dt.Rows)
            {
                if (r.RowState == System.Data.DataRowState.Modified)
                {
                    r.IDBenutzer_Geaendert = ENV.USERID;
                    r.Aenderungsdatum = DateTime.Now;
                }
            }
            _db.Update(dt);
        }

    }
}
