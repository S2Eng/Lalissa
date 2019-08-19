using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{


	public class ZusatzGruppe : BusinessBase, IBusinessBase
	{
		private DBZusatzGruppe _db = new DBZusatzGruppe();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public ZusatzGruppe()
		{
			New();
		}

		public ZusatzGruppe(string id)
		{
			Read(id);
		}

        public ZusatzGruppe(string id, bool useFilter)
        {
            _db.UseFilter = useFilter;
            Read(id);
        }

		public ZusatzGruppe(string id, Guid idFilter)
		{
			_db.Filter = idFilter;
			Read(id);
		}

		public ZusatzGruppe(string id, Guid idFilter, Guid idAbteilung)
		{
			_db.UseAbteilung= true;
			_db.Abteilung	= idAbteilung;
			_db.Filter		= idFilter;
			Read(id);
		}

		public dsZusatzGruppeEintrag.ZusatzGruppeEintragRow AddEntry()
		{
			return _db.NewEntry();
		}

		public dsZusatzGruppeEintrag.ZusatzGruppeEintragDataTable ZusatzEintraege
		{
			get	{	return _db.SUBITEMS;	}
		}

		#region Datenbank-Mapper
		protected dsZusatzGruppe.ZusatzGruppeRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region IBusinessBase Members

		DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

	}
}
