using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using System.Collections.Generic;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


	public class Gruppe : BusinessBase, IBusinessBase
	{
		private DBGruppe _db = new DBGruppe();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}


		public static dsGUIDListe.IDListeDataTable All()
		{

            if (ENV.AppRunning)
            {
                return (dsGUIDListe.IDListeDataTable)new Gruppe().AllEntries();
            }
            else
            {
                return new dsGUIDListe.IDListeDataTable();
            }
		}

		public static dsINTListe.INTListeDataTable AlleRechte()
		{
			return new DBGruppe().AlleRechte();
		}

        public static List<Guid> GetAllBenutzer(Guid IDGruppe)
        {
            return DBGruppe.GetAllBenutzer(IDGruppe);
        }

        public static PMDS.Global.db.Patient.dsGruppe ByBenutzer(Guid id)
		{
			return new DBGruppe().ByBenutzer(id);
		}

		public Gruppe()
		{
			New();
		}

		public Gruppe(Guid id)
		{
			Read(id);
		}

		public dsGruppenRecht.GruppenRechtRow AddRecht(int idRecht)
		{
			dsGruppenRecht.GruppenRechtRow r = _db.NewEntry();
			r.IDGruppe = ID;
			r.IDRecht = idRecht;
			return r;
		}

		public dsGruppenRecht.GruppenRechtDataTable GruppenRechte
		{
			get	{	return _db.SUBITEMS;	}
		}

		#region Datenbank-Mapper
        protected PMDS.Global.db.Patient.dsGruppe.GruppeRow DB_ROW
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
		public String Bezeichnung
		{
			get	{	return DB_ROW.Bezeichnung;	}
			set	{	DB_ROW.Bezeichnung = value;}
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
