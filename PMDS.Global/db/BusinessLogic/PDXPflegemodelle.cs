using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB;
using PMDS.Data.PflegePlan;
using PMDS.Global;



namespace PMDS.BusinessLogic
{
    public class PDXPflegemodelle
    {
        DBPDXPflegemodelle _db;



        public PDXPflegemodelle()
        {
            _db = new DBPDXPflegemodelle();
        }



        public void ReadOneByPDX(Guid IDPDX)
        {
            _db.ReadOneByPDX(IDPDX);
        }

        public void Write()
        {
            _db.Write();
        }

        public List<PDXPflegemodellDef> GetPflegemodelleToPDX()
        {
            return _db.GetPflegemodelleToPDX();
        }

        public void PDXPflegemodelleToDB(PDXDef def)
        {
            _db.PDXPflegemodelleToDB(def);
        }

    }
}
