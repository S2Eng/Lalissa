using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;

namespace PMDS.BusinessLogic
{

	public class KlinikBereiche : BusinessBase
	{
		private DBKlinikBereiche _db = new DBKlinikBereiche();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsBereich.BereichDataTable ByAbteilung(Guid id)
		{
			return new DBKlinikBereiche().ByAbteilung(id);
		}

		public KlinikBereiche()
		{
			New();
		}

		public KlinikBereiche(Guid klinikID)
		{
			Read(klinikID);
		}

		public dsBereich.BereichRow AddBereichxy()
		{
			return _db.AddEntryxy();
		}

		public dsBereich.BereichDataTable Bereiche
		{
			get	{	return _db.ITEM;	}
		}

	}
}
