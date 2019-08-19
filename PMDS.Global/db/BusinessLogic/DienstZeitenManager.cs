using System;
using System.Collections;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;



namespace PMDS.BusinessLogic
{
	public class DienstZeitenManager
	{

		private		DBDienstZeiten	_db = new DBDienstZeiten();

		public DienstZeitenManager()
		{
		}

		
		public dsDienstZeiten.DienstzeitenDataTable ReadAll(Guid IDAbteilung)
		{
			return _db.ReadAll(IDAbteilung);
		}

		public dsDienstZeiten.DienstzeitenDataTable  ReadAllAbteilung(Guid IDAbteilung)
		{
			return _db.ReadAllAbteilung(IDAbteilung);
		}

		public Guid AddNew(string sText, Guid IDAbteilung) 
		{
			dsDienstZeiten.DienstzeitenDataTable  dt = new dsDienstZeiten.DienstzeitenDataTable();
			dsDienstZeiten.DienstzeitenRow r = dt.NewDienstzeitenRow();
			r.ID = Guid.NewGuid();
			r.Bezeichnung		= sText;
			r.IDAbteilung		= IDAbteilung;
			r.Von				= new DateTime(1900,1,1, 8, 0,0);
			r.Bis				= new DateTime(1900,1,1, 18, 0,0);
            r.Reihenfolge       = 0;
            r.VerwendenIn = "";

			dt.AddDienstzeitenRow(r);
			Write(dt);
			return r.ID;
		}

		public dsDienstZeiten.DienstzeitenDataTable Read(Guid ID)
		{
			return _db.Read(ID);
		}

		public void Delete(Guid ID)
		{
			dsDienstZeiten.DienstzeitenDataTable dt = _db.Read(ID);
			if(dt.Count == 0)
				return;
			dt[0].Delete();
			Write(dt);

		}

		public void Write(dsDienstZeiten.DienstzeitenDataTable dt)
		{
			_db.Write(dt);
		}

	}
}
