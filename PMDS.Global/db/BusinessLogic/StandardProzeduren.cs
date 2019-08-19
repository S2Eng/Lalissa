using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;



namespace PMDS.BusinessLogic
{
    public class StandardProzeduren
    {
        private DBStandardProzeduren _db;


        public StandardProzeduren()
        {
            _db = new DBStandardProzeduren();
        }


        /// Liefert alle Standardprozeduren sowie die DynRep Verknüpfungen dazu
        public dsStandardProzeduren ALL
        {
            get { return _db.ALL; }
        }
        public dsStandardProzeduren Read()
        {
            return _db.Read();
        }

        public dsStandardProzeduren.StandardProzedurenRow New()
        {
            return _db.New();
        }

        public void Write()
        {
           _db.Write();
        }

        public void Delete(Guid IDStandardprozeduren)
        {
            List<dsStandardProzeduren.SPDynRepRow> al = new List<dsStandardProzeduren.SPDynRepRow>();
            foreach (dsStandardProzeduren.SPDynRepRow r in ALL.SPDynRep.Rows)
            {
                if (r.RowState == System.Data.DataRowState.Deleted)
                    continue;
                if (r.IDStandardProzeduren == IDStandardprozeduren)
                    al.Add(r);
            }

            foreach (dsStandardProzeduren.SPDynRepRow rdel in al)
                rdel.Delete();

            ALL.StandardProzeduren.FindByID(IDStandardprozeduren).Delete();
        }

        /// Liefert den verspeicherten Pfad der SP
        public static string GetReportPath(Guid IDStandardProzedur)
        {
            return DBStandardProzeduren.GetReportPath(IDStandardProzedur);
        }
        public static string GetBezeichnung(Guid IDStandardProzedur)
        {
            return DBStandardProzeduren.GetBezeichnung(IDStandardProzedur);
        }
        public static bool GetNotfallFlag(Guid IDStandardProzedur)
        {
            return DBStandardProzeduren.GetNotfallFlag(IDStandardProzedur);
        }

    }
}
