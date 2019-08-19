using System;
using System.Data;
using System.Collections;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;



namespace PMDS.BusinessLogic
{


	public class ZusatzEintrag : BusinessBase, IBusinessBase
	{
		public static string	Delimter = "\n";
		private DBZusatzEintrag	_db = new DBZusatzEintrag();
		private dsINTListe		_liste = new dsINTListe();


		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsIDListe.IDListeDataTable All()
		{
			return (dsIDListe.IDListeDataTable)new ZusatzEintrag().AllEntries();
		}

		public static bool HasList(ZusatzEintragTyp typ)
		{
			// BIG_TEXT/IMAGE haben keine Liste
			switch((ZusatzEintragTyp)typ)
			{
				case ZusatzEintragTyp.BIG_TEXT:
				case ZusatzEintragTyp.IMAGE:
				case ZusatzEintragTyp.FLOAT:
					return false;

				default:
					return true;
			}
		}

		public static bool HasMinMax(ZusatzEintragTyp typ)
		{
			return (ZusatzEintragTyp.FLOAT == typ);
		}

		public ZusatzEintrag()
		{
			New();
		}

		public ZusatzEintrag(string id)
		{
			Read(id);
		}
		public override void Read()
		{
			base.Read();
			GetListe();
		}
		public override void Write()
		{
			if (DB_ROW.RowState != DataRowState.Deleted)
			{
				if (ZusatzEintrag.HasList((ZusatzEintragTyp)Typ))
					SetListe();
				else
					DB_ROW.ListenEintraege = "";
			}

			base.Write();
		}

		public dsINTListe.INTListeRow AddEntry()
		{
			return Liste.AddINTListeRow(Liste.Rows.Count, "");
		}

		// String-DS in Zusatz-Eintrags-Liste konvertieren
		protected void GetListe()
		{
			Liste.Clear();
            if (!DB_ROW.IsListenEintraegeNull() && DB_ROW.ListenEintraege.Trim() != "")
            {
                foreach (string str in DB_ROW.ListenEintraege.Split(Delimter.ToCharArray()))
                {
                    if (str != "")
                        Liste.AddINTListeRow(Liste.Rows.Count, str);
                }
            }
		}

		// Zusatz-Eintrags-Liste in String-DS konvertieren
		protected void SetListe()
		{
			ArrayList al = new ArrayList();
			foreach(dsINTListe.INTListeRow r in Liste.Rows)
			{
				if (r.TEXT != "")
					al.Add(r.TEXT);
			}
				
			DB_ROW.ListenEintraege = string.Join(Delimter, (string[])al.ToArray(typeof(string)));
		}

		#region Datenbank-Mapper
		protected dsZusatzEintrag.ZusatzEintragRow DB_ROW
		{
			get	{	return _db.ITEM[0];	}
		}
		#endregion

		#region PROPERTIES

		public string ID
		{
			get	{	return DB_ROW.ID;	}
			set	{	DB_ROW.ID = value;	}
		}

		public string Bezeichnung
		{
			get	{	return DB_ROW.Bezeichnung;	}
			set	{	DB_ROW.Bezeichnung = value;	}
		}

		public int Typ
		{
			get	{	return DB_ROW.Typ;	}
			set	{	DB_ROW.Typ = value;	}
		}

		public dsINTListe.INTListeDataTable Liste
		{
			get	{	return _liste.INTListe;		}
			set	{	/* not operation required */}
		}

		public string ListeText
		{
			get	{	return DB_ROW.ListenEintraege;	}
		}

		public double MinValue
		{
			get	{	return DB_ROW.MinValue;	}
			set	{	DB_ROW.MinValue = value;	}
		}

		public double MaxValue
		{
			get	{	return DB_ROW.MaxValue;	}
			set	{	DB_ROW.MaxValue = value;	}
		}

        public int FeldNr
        {
            get { return DB_ROW.FeldNr; }
            set { DB_ROW.FeldNr = value; }
        }
        public int ELGA_ID
        {
            get { return DB_ROW.ELGA_ID; }
            set { DB_ROW.ELGA_ID = value; }
        }
        public string ELGA_Code
        {
            get { return DB_ROW.ELGA_Code; }
            set { DB_ROW.ELGA_Code = value; }
        }
        public string ELGA_CodeSystem
        {
            get { return DB_ROW.ELGA_CodeSystem; }
            set { DB_ROW.ELGA_CodeSystem = value; }
        }
        public string ELGA_DisplayName
        {
            get { return DB_ROW.ELGA_DisplayName; }
            set { DB_ROW.ELGA_DisplayName = value; }
        }
        public string ELGA_Unit
        {
            get { return DB_ROW.ELGA_Unit; }
            set { DB_ROW.ELGA_Unit = value; }
        }
        public string ELGA_Version
        {
            get { return DB_ROW.ELGA_Version; }
            set { DB_ROW.ELGA_Version = value; }
        }
        #endregion

        #region IBusinessBase Members
        DataRow IBusinessBase.ROW
		{
			get	{	return DB_ROW;	}
		}

		#endregion
		public bool Exist(string idEntry)
		{
			return _db.Exist(idEntry);
		}

	}
}
