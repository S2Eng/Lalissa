using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.PflegePlan;
using PMDS.DB.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{
    public class EintragStandardprozeduren
    {
        private DBEintragStandardprozeduren _db;




        public EintragStandardprozeduren()
        {
            _db = new DBEintragStandardprozeduren();
        }

        public EintragStandardprozeduren(Guid IDEintrag)
        {
            _db = new DBEintragStandardprozeduren();
            _db.Read(IDEintrag);
        }

        public dsEintragStandardprozeduren.EintragStandardprozedurenDataTable EintragStProzeduren
        {
            get { return _db.EintragStProzeduren; }
        }

        public dsEintragStandardprozeduren.EintragStandardprozedurenDataTable EintragStdProzedurenByIDStdProz
        {
            get { return _db.EintragStdProzedurenByIDStdProz; }
        }

        public void ReadByStandardprozedur(Guid IDStandardProzedur)
        {
            _db.ReadByStandardprozedur(IDStandardProzedur);
        }

        public void UpdateZuordnungen(Guid IDEintrag, Guid[] IDStandardProzeduren)
        {
            _db.DeleteZuordnungen();
            _db.Read(IDEintrag);

            foreach (Guid id in IDStandardProzeduren)
                _db.New(IDEintrag, id);

            Write();
        }

        public void Write()
        {
            _db.Write();
        }

    }
}
