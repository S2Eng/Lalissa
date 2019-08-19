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



	public class UrlaubVerlauf : BusinessBase, IBusinessBase
	{
		private DBUrlaubVerlauf _db = new DBUrlaubVerlauf();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		// Alle Einträge mit dem zugehörigen Aufenthalt ermitteln
		public static dsUrlaubVerlauf.UrlaubVerlaufDataTable ByAufenthalt(Guid id)
		{
			return new DBUrlaubVerlauf().ByAufenthalt(id);
		}
        public static dsUrlaubVerlauf.UrlaubVerlaufDataTable alleUrlaube(Guid idPatient, DateTime von, DateTime bis)
        {
            return new DBUrlaubVerlauf().alleUrlaube(idPatient, von, bis);
        }


		public UrlaubVerlauf()
		{
			New();
		}

		public UrlaubVerlauf(Guid id)
		{
			Read(id);
		}

		#region Datenbank-Mapper
		protected dsUrlaubVerlauf.UrlaubVerlaufRow DB_ROW
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
		public Guid IDAufenthalt
		{
			get	{	return DB_ROW.IDAufenthalt;	}
			set	{	DB_ROW.IDAufenthalt = value;	}
		}
		public DateTime StartDatum
		{
			get	{	return DB_ROW.StartDatum;	}
			set	{	DB_ROW.StartDatum = value;	}
		}

		public string Text
		{
			get	{	return DB_ROW.Text;	}
			set	{	DB_ROW.Text = value;	}
		}
		public DateTime DatumErstellt
		{
			get	{	return DB_ROW.DatumErstellt;	}
			set	{	DB_ROW.DatumErstellt = value;	}
		}
		public DateTime DatumGeaendert
		{
			get	{	return DB_ROW.DatumGeaendert;	}
			set	{	DB_ROW.DatumGeaendert = value;	}
		}
		public Guid IDBenutzer_Erstellt
		{
			get	{	return DB_ROW.IDBenutzer_Erstellt;	}
			set	{	DB_ROW.IDBenutzer_Erstellt = value;	}
		}
		public Guid IDBenutzer_Geaendert
		{
			get	{	return DB_ROW.IDBenutzer_Geaendert;	}
			set	{	DB_ROW.IDBenutzer_Geaendert = value;	}
		}
		#endregion

		#region IBusinessBase Members

		DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion

		public override void Write()
		{
			IDBenutzer_Geaendert= ENV.USERID;
			DatumGeaendert		= DateTime.Now;

			if (DB_ROW.IsIDBenutzer_ErstelltNull())	IDBenutzer_Erstellt	= IDBenutzer_Geaendert;
			if (DB_ROW.IsDatumErstelltNull())		DatumErstellt		= DatumGeaendert;

			base.Write();
		}

	}
}
