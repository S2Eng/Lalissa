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



	public class Kontakt : BusinessBase, IBusinessBase
	{
		public DBKontakt _db = new DBKontakt();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public Kontakt()
		{
			New();
		}

		public Kontakt(Guid id)
		{
			Read(id);
		}

		#region Datenbank-Mapper
		protected dsKontakt.KontaktRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
		public Guid ID
		{
			get	{	return DB_ROW.ID;	}
			set	{	DB_ROW.ID = value;	}
		}
		public String Tel
		{
			get	{	return DB_ROW.Tel;	}
			set	{	DB_ROW.Tel = value;	}
		}
		public String Fax
		{
			get	{	return DB_ROW.Fax;	}
			set	{	DB_ROW.Fax = value;	}
		}
		public String Mobil
		{
			get	{	return DB_ROW.Mobil;		}
			set	{	DB_ROW.Mobil = value;	}
		}
		public String Andere
		{
			get	{	return DB_ROW.Andere;	}
			set	{	DB_ROW.Andere = value;	}
		}
		public String Email
		{
			get	{	return DB_ROW.Email;		}
			set	{	DB_ROW.Email = value;	}
		}
		public String Ansprechpartner
		{
			get	{	return DB_ROW.Ansprechpartner;	}
			set	{	DB_ROW.Ansprechpartner = value;	}
		}
		public String Zusatz1
		{
			get	{	return DB_ROW.Zusatz1;	}
			set	{	DB_ROW.Zusatz1 = value;	}
		}
		public String Zusatz2
		{
			get	{	return DB_ROW.Zusatz2;	}
			set	{	DB_ROW.Zusatz2 = value;	}
		}
		public String Zusatz3
		{
			get	{	return DB_ROW.Zusatz3;	}
			set	{	DB_ROW.Zusatz3 = value;	}
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
