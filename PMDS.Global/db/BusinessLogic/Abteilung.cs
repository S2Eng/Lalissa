using System;
using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;



namespace PMDS.BusinessLogic
{



	public class Abteilung
	{
		private DBAbteilung			_Abteilung;

		public Abteilung()
		{
			_Abteilung = new DBAbteilung();
		}

		public dsAbteilung.AbteilungDataTable	ABTEILUNGLISTE 
		{
			get 
			{
				return _Abteilung.ABTEILUNGLISTE;
			}
		}

        public string GetAbteilungstext(Guid IDAbteilung)
        {
            foreach (dsAbteilung.AbteilungRow r in ABTEILUNGLISTE)
            {
                if (r.ID == IDAbteilung)
                    return r.Bezeichnung.Trim();
            }

            return "";
        }

	}
}
