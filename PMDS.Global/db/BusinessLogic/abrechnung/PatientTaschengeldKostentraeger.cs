using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Global.db.Global.ds_abrechnung;



namespace PMDS.BusinessLogic
{
    public class PatientTaschengeldKostentraeger
    {
        DBPatientTaschengeldKostentraeger _db = new DBPatientTaschengeldKostentraeger();

        public PatientTaschengeldKostentraeger() { }

        /// <summary>
        /// Alle Datenaätze
        /// </summary>
        /// <returns></returns>
        public dsPatientTaschengeldKostentraeger Read()
        {
            return _db.Read();
        }

        public dsPatientTaschengeldKostentraeger Read(Guid IDPatient)
        {
            return _db.Read(IDPatient);
        }

        public void Update(dsPatientTaschengeldKostentraeger ds)
        {
            _db.Update(ds);
        }

        public dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow New(dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerDataTable dt, Guid IDPatient)
        {
            dsPatientTaschengeldKostentraeger.PatientTaschengeldKostentraegerRow r = dt.AddPatientTaschengeldKostentraegerRow(Guid.NewGuid(), IDPatient, Guid.Empty, DateTime.Now.Date, DateTime.Now,
                                        0.0, DateTime.Now, ENV.USERID, DateTime.Now.Date);
            r.SetGueltigBisNull();
            r.SetAbgerechnetBisNull();
            return r;
        }
    }
}
