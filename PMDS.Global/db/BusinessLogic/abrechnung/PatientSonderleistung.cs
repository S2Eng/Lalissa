using System;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;
using System.Data.OleDb;
using System.Data;

namespace PMDS.BusinessLogic.Abrechnung
{


	public class PatientSonderleistung
	{


		private DBPatientSonderleistung _db = new DBPatientSonderleistung();
		

		public PatientSonderleistung()
		{

		}

        public dsPatientSonderleistung.PatientSonderleistungDataTable Readxy(Guid IDPatient, Guid IDKlinik)
		{
            return _db.Read(IDPatient, IDKlinik);
		}

		public void Update(dsPatientSonderleistung.PatientSonderleistungDataTable dt)
		{
			_db.Update(dt);
		}

        public bool deletePatientSonderleistung(Guid IDSonderleistungskatalog, Guid IDKlinik)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            cmd.Connection = RBU.DataBase.CONNECTION;
            cmd.CommandText = " Delete from  PatientSonderleistung  WHERE IDSonderleistungskatalog = ? and IDKlinik = ? ";
            cmd.Parameters.Add("IDSonderleistungskatalog", System.Data.OleDb.OleDbType.Guid, 16, "IDSonderleistungskatalog").Value = IDSonderleistungskatalog;
            cmd.Parameters.Add("IDKlinik", System.Data.OleDb.OleDbType.Guid, 16, "IDKlinik").Value = IDKlinik;
            cmd.ExecuteNonQuery();
            return true;
        }

		public dsPatientSonderleistung.PatientSonderleistungRow New(dsPatientSonderleistung.PatientSonderleistungDataTable dt, Guid IDPatient, Guid IDSonderleistungsKatalog,string Belegnummer)
		{
			dsPatientSonderleistung.PatientSonderleistungRow r;

			if(IDSonderleistungsKatalog == Guid.Empty) 
			{
				r = dt.AddPatientSonderleistungRow(Guid.NewGuid(), IDPatient, "", 1, 0, 20, DateTime.Now.Date, false, IDSonderleistungsKatalog, Belegnummer, 1900,1, 0, new DateTime(DateTime.Now.Year , DateTime.Now.Month , 1).Date, System.Guid.Empty);
			}
			else 
			{
				SonderleistungsKatalog k = new SonderleistungsKatalog();
				dsSonderleistungsKatalog.SonderleistungsKatalogRow rk = k.ReadByID(IDSonderleistungsKatalog);
                r = dt.AddPatientSonderleistungRow(Guid.NewGuid(), IDPatient, rk.Bezeichnung, 1, System.Convert.ToDecimal(rk.Betrag), rk.Mwst, DateTime.Now.Date, false, IDSonderleistungsKatalog, Belegnummer, 1900, 1, 0, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).Date, System.Guid.Empty);
			}

            if (IDSonderleistungsKatalog == Guid.Empty)
                r.SetIDSonderleistungskatalogNull();

            r.SetJahrAbrechnungNull();
            r.SetMonatAbrechnungNull();
            r.SetEinzelPreisNull();
			return r;
		}


	}
}
