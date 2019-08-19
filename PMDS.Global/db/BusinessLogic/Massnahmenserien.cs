using System;
using System.Data;
using System.Text;
using PMDS.DB;
using PMDS.Global;
using System.Collections;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;

namespace PMDS.BusinessLogic
{

    
	public class Massnahmenserien : BusinessBase
	{
		private DBMassnahmenserien _db = new DBMassnahmenserien();



		public static Massnahmenserien AllWithoutUserDefined()
		{
			Massnahmenserien m = new Massnahmenserien(System.Guid.Empty);
			m.RemoveUserDefined();
			return m;
		}

		public static Massnahmenserien Default()
		{
            return new Massnahmenserien(System.Guid.Empty);
		}


		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public Massnahmenserien()
		{
			New();
		}

		public Massnahmenserien(Guid klinikID)
		{
			Read();
		}

		public dsMassnahmenserien.MassnahmenserienRow AddSerie()
		{
			return _db.AddEntry();
		}
		public dsMassnahmenserien.MassnahmenserienDataTable Serien
		{
			get	{	return _db.ITEM;	}
		}

		/// Benutzerdefinierte Serie entfernen
		private void RemoveUserDefined()
		{
			DataRow r = Serien.Rows.Find(DBMassnahmenserien.UserDefinedID());
			if (r != null)
			{
				r.Delete();
				r.AcceptChanges();
			}
		}

		/// Alle Zeitpunkte zu einer bestimmten Maﬂnahmenserie liefern
		public DateTime[] GetPoints(Guid IDMassnahmenserie)
		{
			ArrayList al = new ArrayList();
			dsMassnahmenserien.MassnahmenserienRow r = (dsMassnahmenserien.MassnahmenserienRow)Serien.Rows.Find(IDMassnahmenserie);
			if (r != null)
			{
				foreach(DataColumn c in Serien.Columns)
					if(c.ColumnName.StartsWith("Z"))
						if(!r.IsNull(c))
							al.Add((DateTime) r[c.ColumnName]);
			}

			return (DateTime[])al.ToArray(typeof(DateTime));
		}

	}
}
