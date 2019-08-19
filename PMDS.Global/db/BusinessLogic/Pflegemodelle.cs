using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Data.PflegePlan;
using PMDS.DB;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{


    public class Pflegemodelle
    {
        private DBPflegemodelle _db;



        public Pflegemodelle()
        {
            _db = new DBPflegemodelle();
        }


        public dsPflegemodelle.PflegemodelleDataTable PflegemodelleDataTable
        {
            get { return _db.Pflegemodelle; }
        }

        public void Read()
        {
            _db.Read();
        }

        public dsPflegemodelle.PflegemodelleRow[] GetAllModelle()
        {
            return _db.GetAllModelle();
        }

        public dsPflegemodelle.PflegemodelleRow[] GetAllModellegruppenToModel(string modell)
        {
            return _db.GetAllModellegruppenToModel(modell);
        }
    }
}
