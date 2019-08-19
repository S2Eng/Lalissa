using System;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
	public class FormularDatenManager
	{

		private		DBFormularData	_db = new DBFormularData();

		public FormularDatenManager()
		{
		}

		public dsFormularDaten.FormularDatenDataTable Read(Guid IDRef) 
		{
			return _db.Read(IDRef);
		}


		// Liefert alle Formularedaten zur Referenz in der DB gefiltert auf ein bestimmtes Formular
		public dsFormularDaten.FormularDatenDataTable Read(Guid IDRef, string Formularname) 
		{
			return _db.Read(IDRef, Formularname);
		}

		public void Write(dsFormularDaten.FormularDatenDataTable dt)
		{
			_db.Write(dt);
		}
        
	}
}
