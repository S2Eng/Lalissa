using System;
using PMDS.Global;
using PMDS.DB;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{
	public class FormularManager
	{
        
		private		DBFormular	_db = new DBFormular();


		public FormularManager()
		{
		}

		/// Liefert alle Formulare in der DB
		public dsFormular.FormularDataTable Read()
		{
			return _db.Read();
		}
		public dsFormular.FormularDataTable Read(Guid ID)
		{
			return _db.Read(ID);
		}

		public void Delete(Guid ID)
		{
			dsFormular.FormularDataTable dt = _db.Read(ID);
			if(dt.Count == 0)
				return;
			dt[0].Delete();
			Write(dt);

		}

		public void Write(dsFormular.FormularDataTable dt)
		{
			_db.Write(dt);
		}

	}
}
