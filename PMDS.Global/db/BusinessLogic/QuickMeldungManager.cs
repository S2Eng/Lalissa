using System;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
	public class QuickMeldungManager
	{
        
		private		DBQuickMeldung	_db = new DBQuickMeldung();



		public QuickMeldungManager()
		{
		}



		// Liefert alle QuickMeldungen in der DB: Alle der generellen und alle der übergebenen Abteilung
		public dsQuickMeldung.QuickMeldungDataTable ReadAll(Guid IDAbteilung)
		{
			return _db.ReadAll(IDAbteilung);
		}

		// Liefert alle QuickMeldungen in der DB: alle der übergebenen Abteilung
		public dsQuickMeldung.QuickMeldungDataTable ReadAllAbteilung(Guid IDAbteilung)
		{
			return _db.ReadAllAbteilung(IDAbteilung);
		}

		// Fügt eine neue RM hinzu und liefert die ID
		public Guid AddNew(string sText, Guid IDAbteilung) 
		{
			dsQuickMeldung.QuickMeldungDataTable dt = new dsQuickMeldung.QuickMeldungDataTable();
			dsQuickMeldung.QuickMeldungRow r = dt.NewQuickMeldungRow();
			r.ID = Guid.NewGuid();
			r.Bezeichnung		= sText;
			r.IDAbteilung		= IDAbteilung;
			dt.AddQuickMeldungRow(r);
			Write(dt);
			return r.ID;
		}

		public dsQuickMeldung.QuickMeldungDataTable Read(Guid ID)
		{
			return _db.Read(ID);
		}

		public void Delete(Guid ID)
		{
			dsQuickMeldung.QuickMeldungDataTable dt = _db.Read(ID);
			if(dt.Count == 0)
				return;
			dt[0].Delete();
			Write(dt);

		}
		public void Write(dsQuickMeldung.QuickMeldungDataTable dt)
		{
			_db.Write(dt);
		}

	}
}
