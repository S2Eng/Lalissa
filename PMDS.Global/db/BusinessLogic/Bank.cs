using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PMDS.Global;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


    public class Bank : BusinessBase, IBusinessBase
    {
        private DBBank _db = new DBBank();
        

        public Bank()
        {
            New();
        }

		public Bank(Guid id)
		{
			Read(id);
		}

        protected override IDBBase DBInterface
        {
            get { return (IDBBase)_db; }
        }

        #region Datenbank-Mapper
		protected dsBank.BankRow DB_ROW
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
        
        #region PROPERTIES
		public Guid ID
		{
			get	{	return DB_ROW.ID;	}
			set	{	DB_ROW.ID = value;	}
		}
		public String Bezeichnung
		{
			get	{	return DB_ROW.Bezeichnung;	}
			set	{	DB_ROW.Bezeichnung = value;	}
		}
		public int Kontonummer
		{
			get	{	return DB_ROW.Kontonummer;	}
			set	{	DB_ROW.Kontonummer = value;	}
		}
		public int BLZ
		{
			get	{	return DB_ROW.BLZ;	}
			set	{	DB_ROW.BLZ = value;	}
		}

		public String IBAN
		{
			get	{	return DB_ROW.IsIBANNull() ? "" : DB_ROW.IBAN;	}
			set	{	DB_ROW.IBAN = value;	}
		}
		public String BIC
		{
			get	{	return DB_ROW.IsBICNull() ? "" : DB_ROW.BIC;	}
			set	{	DB_ROW.BIC = value;	}
		}
        public Guid IDKlinik
        {
            get { return DB_ROW.IDKlinik; }
            set { DB_ROW.IDKlinik = value; }
        }
		#endregion

    }
}
