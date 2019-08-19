using System;
using PMDS.Abrechnung.Global;
using PMDS.Calc.Admin.DB;


namespace PMDS.BusinessLogic.Abrechnung
{
	public class SonderleistungsKatalog
	{
		private DBSonderleistungsKatalog	 _db = new DBSonderleistungsKatalog();
		public SonderleistungsKatalog()
		{
		}

		public dsSonderleistungsKatalog.SonderleistungsKatalogDataTable Read()
		{
			return _db.Read();
		}

		public void Update(dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt)
		{
			_db.Update(dt);	
		}
		
		public dsSonderleistungsKatalog.SonderleistungsKatalogRow New(dsSonderleistungsKatalog.SonderleistungsKatalogDataTable dt)
		{
            dsSonderleistungsKatalog.SonderleistungsKatalogRow rNew = dt.AddSonderleistungsKatalogRow(Guid.NewGuid(), "", 0, 20, System.Guid.Empty, "");
            rNew.SetIDKlinikNull();
            return rNew;
		}

		public dsSonderleistungsKatalog.SonderleistungsKatalogRow ReadByID(Guid IDSonderleistungsKatalog)
		{
			return _db.ReadByID(IDSonderleistungsKatalog);
		}
	}
}
