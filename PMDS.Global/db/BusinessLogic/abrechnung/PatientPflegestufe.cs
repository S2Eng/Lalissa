using System;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;
using PMDS.Global;
using System.Data.OleDb;



namespace PMDS.BusinessLogic.Abrechnung
{
	public class PatientPflegestufe
	{
		private DBPatientPflegestufe _db = new DBPatientPflegestufe();
		public PatientPflegestufe()
		{
		}

		public dsPatientPflegestufe.PatientPflegestufeDataTable Read(Guid IDPatient)
		{
			return _db.Read(IDPatient);
		}

        //Neu nach 24.10.2007 MDA
        public dsPatientPflegestufe.PatientPflegestufeDataTable ReadByPflegestufe(Guid IDPflegestufe)
        {
            return _db.ReadByPflegestufe(IDPflegestufe);
        }

        //Neu nach 05.02.2008 MDA
        public dsPatientPflegestufe.PatientPflegestufeRow ReadByID(Guid IDPatientPflegestufe)
        {
            return _db.ReadByID(IDPatientPflegestufe);
        }
		public void Update(dsPatientPflegestufe.PatientPflegestufeDataTable dt)
		{
			_db.Update(dt);
		}

		public dsPatientPflegestufe.PatientPflegestufeRow New(dsPatientPflegestufe.PatientPflegestufeDataTable dt, Guid IDPatient, Guid IDPflegegeldstufe, double dblBetragverwendbar)
		{
			dsPatientPflegestufe.PatientPflegestufeRow r = dt.AddPatientPflegestufeRow(Guid.NewGuid(), IDPatient, IDPflegegeldstufe, dblBetragverwendbar, 0, DateTime.Now.Date, DateTime.Now, ENV.USERID, DateTime.Now, Guid.Empty);
            r.SetAbgerechnetBisNull();
            return r;
		}

        //Neu nach 15.10.2007 MDA
        public void InitNewPatientPflegestufe(dsPatientPflegestufe.PatientPflegestufeRow r, Guid IDPatient)
        {
            r.ID = Guid.NewGuid();
            r.IDPatient = IDPatient;
            r.BetragVerwendbar = 0;
            r.GutschriftProTagAbwesend = 0;
            r.GueltigAb = DateTime.Now.Date;
        }


	}

    //--------------------------------------------------------------------------------
    /// <summary>
    /// Liefert zu dem Patienten die für Jahr/Monat angegebene Pflegegeldstufe
    /// </summary>
    //--------------------------------------------------------------------------------
    public class PatientPflegestufeInfo
    {
        private static DBPatientPflegestufe _dbpp = new DBPatientPflegestufe();
        private static DBPflegegeldstufe _dbps = new DBPflegegeldstufe();

        private dsPatientPflegestufe.PatientPflegestufeRow _ppr;
        private dsPflegegeldstufe.PflegegeldstufeRow _psr;

        public PatientPflegestufeInfo(Guid IDPatient, int jahr, int monat)
        {
            DateTime dt = new DateTime(jahr, monat, 1);
            foreach (dsPatientPflegestufe.PatientPflegestufeRow r in _dbpp.Read(IDPatient).Select("", "GueltigAb desc"))    // Den gültigen Eintrag finden
            {
                if (r.GueltigAb <= dt)
                {
                    _ppr = r;
                    break;
                }
            }

            if (_ppr != null)
            {
                //Änderung nach 23.10.2007 MDA
                dsPflegegeldstufe.PflegegeldstufeDataTable dt1 = _dbps.ReadByID(_ppr.IDPflegegeldstufe).Pflegegeldstufe;

                if(dt1.Count > 0)
                    _psr = dt1[0];
            }
        }

        public override string ToString()
        {
            return string.Format("Pflegegeldstufe {0}", _psr.StufeNr);
        }

        public bool HasPflegeGeldStufe
        {
            get
            {
                return _ppr != null;
            }
        }

        public double BetragVerwendbar
        {
            get
            {
                return _ppr.BetragVerwendbar;
            }
        }

        public int Divisor
        {
            get
            {
                if (_psr.Divisor == 0)
                    return 30;
                return _psr.Divisor;
            }
        }

        public double GutschritfProTagAbwesenheit
        {
            get
            {
                return _ppr.GutschriftProTagAbwesend;
            }
        }

        public Guid ID
        {
            get
            {
                return _ppr.ID;
            }
        }
    }
}
