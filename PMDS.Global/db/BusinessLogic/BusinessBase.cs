using System;
using System.Data;

using PMDS.Global;
using PMDS.DB;

namespace PMDS.BusinessLogic
{

	public abstract class BusinessBase : IBusinessBase
	{

		public BusinessBase()
		{
		}


		protected abstract IDBBase DBInterface
		{
			get;
		}

		public virtual DataTable AllEntries()
		{
			return DBInterface.All();
		}

		public virtual void New()
		{
			DBInterface.New();
		}

		public virtual void Read(object id)
		{

                DBInterface.ID = id;
                Read();


		}

		public virtual void Read()
		{
			DBInterface.Read();
		}

		public virtual void Write( )
		{
			DBInterface.Write();
		}

		public virtual void Delete()
		{
			// alle Einträge löschen
			foreach(DataRow r in DBUtil.CurrentRows(DBInterface.ITEM))
				r.Delete();

			Write();
		}

		#region IBusinessBase Members

		DataRow IBusinessBase.ROW
		{
			get
			{	
				throw new NotSupportedException("IBusinessBase.ROW");
			}
		}

		#endregion

	}
}
