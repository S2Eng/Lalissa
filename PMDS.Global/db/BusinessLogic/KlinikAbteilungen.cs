using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{



	public class KlinikAbteilungen : BusinessBase
	{
		private DBKlinikAbteilungen _db = new DBKlinikAbteilungen();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsGUIDListe.IDListeDataTable All()
		{
			return (dsGUIDListe.IDListeDataTable)new KlinikAbteilungen().AllEntries();
		}

		public static Guid DefaultID()
		{
			return Guid.Empty;
		}
		public KlinikAbteilungen()
		{
			New();
		}

		public KlinikAbteilungen(Guid klinikID)
		{
			Read(klinikID);
		}

		public static bool IsAbteilungRMOptional(Guid IDAbteilung) 
		{
			KlinikAbteilungen k = new KlinikAbteilungen(KlinikAbteilungen.DefaultID());
			dsAbteilung.AbteilungRow r = k.Abteilungen.FindByID(IDAbteilung);
			if(r!=null)
				return r.RMOptionalJN;
			else
				return false;
		}

		public dsAbteilung.AbteilungRow AddAbteilung()
		{
			return _db.AddEntry();
		}

		public dsAbteilung.AbteilungDataTable Abteilungen
		{
			get	{	return _db.ITEM;	}
		}

	}
}
