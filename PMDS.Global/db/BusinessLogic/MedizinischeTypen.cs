using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.Global;
using PMDS.DB.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


    public class MedizinischeTypen
    {
        private DBMedizinischeTypen _db = new DBMedizinischeTypen();
         
        public dsMedizinischeTypen.MedizinischeTypenDataTable ALL
        {
            get
            {
                return _db.ALL;
            }
        }

        public dsMedizinischeTypen.MedizinischeTypenRow GetFromTyp(int MedizinischerTyp)
        {
            return _db.GetFromTyp(MedizinischerTyp);
        }

        public void Update(dsMedizinischeTypen.MedizinischeTypenDataTable dt)
        {
            _db.Update(dt);
        }

    }
}
