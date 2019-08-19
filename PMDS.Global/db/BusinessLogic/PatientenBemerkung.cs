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


	public class PatientenBemerkung : BusinessBase, IBusinessBase
	{
		private DBPatientenBemerkung _db = new DBPatientenBemerkung();

        
		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}


		public PatientenBemerkung()
		{
			New();
		}

		public PatientenBemerkung(Guid id)
		{
			Read(id);
		}

		#region Datenbank-Mapper
		protected dsPatientenBemerkung.PatientenBemerkungRow DB_ROW
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
		public Guid IDPatient
		{
			get	{	return DB_ROW.IDPatient;	}
			set	{	DB_ROW.IDPatient = value;	}
		}
		public Guid IDBenutzer
		{
			get	{	return DB_ROW.IDBenutzer;	}
			set	{	DB_ROW.IDBenutzer = value;	}
		}
		public string Bemerkung
		{
			get	{	return DB_ROW.Bemerkung;	}
			set	{	DB_ROW.Bemerkung = value;	}
		}
        public bool  IstDekurs
        {
            get { return DB_ROW.IstDekurs ; }
            set { DB_ROW.IstDekurs = value; }
        }
		public DateTime Datum
		{
			get	{	return DB_ROW.Datum;		}
			set	{	DB_ROW.Datum = value;		}
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
