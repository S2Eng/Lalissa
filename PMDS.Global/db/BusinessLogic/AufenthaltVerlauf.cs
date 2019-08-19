using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{

	public class AufenthaltVerlauf : BusinessBase, IBusinessBase
	{
		private DBAufenthaltVerlauf _db = new DBAufenthaltVerlauf();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsAufenthaltVerlauf.AufenthaltVerlaufDataTable ByAufenthalt(Guid id)
		{
			return new DBAufenthaltVerlauf().ByAufenthalt(id);
		}
		public static dsAufenthaltVerlauf.VersetzungenDataTable VersetzungByAufenthalt(Guid id)
		{
			return new DBAufenthaltVerlauf().VersetzungByAufenthalt(id);
		}
		public static Guid FirsByAufenthalt(Guid id)
		{
			return ByAufenthalt(id)[0].ID;
		}

		public AufenthaltVerlauf()
		{
			New();
		}

		public AufenthaltVerlauf(Guid id)
		{
			Read(id);
		}
		public dsBenutzerBezug.BenutzerBezugRow AddBenutzer(Guid idBenutzer)
		{
			dsBenutzerBezug.BenutzerBezugRow r = _db.NewEntry();
			r.IDAufenthaltVerlauf = ID;
			r.IDBenutzer = idBenutzer;
			return r;
		}
		public dsBenutzerBezug.BenutzerBezugDataTable BenutzerBezug
		{
			get	{	return _db.SUBITEMS;	}
		}

		#region Datenbank-Mapper
		protected dsAufenthaltVerlauf.AufenthaltVerlaufRow DB_ROW
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
		public Guid IDBenutzer
		{
			get	{	return DB_ROW.IDBenutzer;	}
			set	{	DB_ROW.IDBenutzer = value;	}
		}
		public Guid IDAbteilung_Von
		{
			get	
			{
				if (DB_ROW.IsIDAbteilung_VonNull())
					return Guid.Empty;

				return DB_ROW.IDAbteilung_Von;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDAbteilung_VonNull();
				else
					DB_ROW.IDAbteilung_Von = value;
			}
		}
		public Guid IDAbteilung_Nach
		{
			get	
			{
				if (DB_ROW.IsIDAbteilung_NachNull())
					return Guid.Empty;

				return DB_ROW.IDAbteilung_Nach;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDAbteilung_NachNull();
				else
					DB_ROW.IDAbteilung_Nach = value;
			}
		}
		public Guid IDBereich
		{
			get	
			{
				if (DB_ROW.IsIDBereichNull())
					return Guid.Empty;

				return DB_ROW.IDBereich;
			}

			set
			{
				if (value == Guid.Empty)
					DB_ROW.SetIDBereichNull();
				else
					DB_ROW.IDBereich = value;
			}
		}
		public string Bemerkung
		{
			get	{	return DB_ROW.Bemerkung;	}
			set	{	DB_ROW.Bemerkung = value;	}
		}
		public DateTime Datum
		{
			get	{	return DB_ROW.Datum;	}
			set	{	DB_ROW.Datum = value;	}
		}
		public string ZuweisenderArzt
		{
			get	{	return DB_ROW.ZuweisenderArzt;	}
			set	{	DB_ROW.ZuweisenderArzt = value;	}
		}
		public string AufnahmeArzt
		{
			get	{	return DB_ROW.AufnahmeArzt;	}
			set	{	DB_ROW.AufnahmeArzt = value;	}
		}
		public string Aufnahmegespraech
		{
			get	{	return DB_ROW.Aufnahmegespraech;	}
			set	{	DB_ROW.Aufnahmegespraech = value;	}
		}
		public string Abschlussbemerkung
		{
			get	{	return DB_ROW.Abschlussbemerkung;	}
			set	{	DB_ROW.Abschlussbemerkung = value;	}
		}
		public string AufnahmeStatus
		{
			get	{	return DB_ROW.AufnahmeStatus;	}
			set	{	DB_ROW.AufnahmeStatus = value;	}
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
