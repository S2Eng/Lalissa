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


	public class AuswahlGruppe : BusinessBase, IBusinessBase
	{
		public DBAuswahlGruppe _db = new DBAuswahlGruppe();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public AuswahlGruppe()
		{
			New();
		}

		public AuswahlGruppe(string id)
		{
            if ( ENV.AppRunning)
			        Read(id);
		}

		public dsAuswahlGruppe.AuswahlListeRow AddEntry()
		{
			return _db.NewEntry();
		}

		public dsAuswahlGruppe.AuswahlListeDataTable AuswahlListe
		{
			get	{	return _db.SUBITEMS;	}
		}

		#region Datenbank-Mapper
		protected dsAuswahlGruppe.AuswahlListeGruppeRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES
		public string ID
		{
			get	{	return DB_ROW.ID;		}
			set	{	DB_ROW.ID = value;	}
		}
		public String Bezeichnung
		{
			get	{	return DB_ROW.Bezeichnung;	}
			set	{	DB_ROW.Bezeichnung = value;	}
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
