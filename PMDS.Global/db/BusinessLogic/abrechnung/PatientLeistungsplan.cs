using System;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;
using PMDS.Global;
using System.Data.OleDb;
using System.Data;

namespace PMDS.BusinessLogic.Abrechnung
{


	public class PatientLeistungsplan
	{
        
		private DBPatientLeistungsplan		 _db = new DBPatientLeistungsplan();




		public PatientLeistungsplan()
		{
		}

        public dsPatientLeistungsplan.PatientLeistungsplanDataTable Read(Guid IDPatient, System.Guid IDKlinik)
		{
            return _db.Read(IDPatient, IDKlinik);
		}

		public void Update(dsPatientLeistungsplan.PatientLeistungsplanDataTable dt)
		{
			_db.Update(dt);
		}

		public dsPatientLeistungsplan.PatientLeistungsplanRow New(dsPatientLeistungsplan.PatientLeistungsplanDataTable dt, Guid IDPatient, 
                                                            Guid IDLeistungskatalog, System.Guid IDKlinik)
		{
			dsPatientLeistungsplan.PatientLeistungsplanRow r = dt.AddPatientLeistungsplanRow(Guid.NewGuid(), IDPatient, IDLeistungskatalog, true, DateTime.Now.Date, DateTime.Now.Date, DateTime.Now, ENV.USERID, DateTime.Now.Date, false, System.Guid.Empty);
            r.IDKlinik = IDKlinik;
            r.SetGueltigBisNull();
            r.SetAbgerechnetBisNull();
			return r;
		}
        public bool deletePatientLeistungsplanxy(Guid IDLeistungskatalog, Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = " Delete from  PatientLeistungsplan  WHERE IDLeistungskatalog = ? and IDKlinik = ? ";
            cmd.Parameters.Add("IDLeistungskatalog", System.Data.OleDb.OleDbType.Guid, 16, "IDLeistungskatalog").Value = IDLeistungskatalog;
            cmd.Parameters.Add("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik").Value = IDKlinik;
            cmd.ExecuteNonQuery();
            return true;
        }


	}
}
