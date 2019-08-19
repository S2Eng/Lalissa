using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;
using System.Linq;


namespace PMDS.BusinessLogic
{



	public class Einrichtung : AdresseKontaktBasis, IBusinessBase
	{
		private DBEinrichtung _db = new DBEinrichtung();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}

		public static dsGUIDListe.IDListeDataTable All(bool NotKrankenkasse)
		{
            if (NotKrankenkasse)
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tE = (from e in db.Einrichtung
                              where e.IstKrankenkasse == false
                              orderby e.Text ascending
                              select new
                              {
                                  ID = e.ID,
                                  Text = e.Text
                              });
                    dsGUIDListe.IDListeDataTable t = new dsGUIDListe.IDListeDataTable();
                    foreach (var r in tE)
                    {
                        dsGUIDListe.IDListeRow rNew = (dsGUIDListe.IDListeRow)t.NewRow();
                        rNew.ID = r.ID;
                        if (r.Text.Trim() != "")
                        {
                            rNew.TEXT = r.Text.Trim();
                        }
                        else
                        {
                            rNew.TEXT = QS2.Desktop.ControlManagment.ControlManagment.getRes("[Kein Name]");
                        }
                        t.Rows.Add(rNew);
                    }
                    t.AcceptChanges();
                    return t;
                }
            }
            else
            {
                return (dsGUIDListe.IDListeDataTable)new Einrichtung().AllEntries();
            }
		}

		public Einrichtung()
		{
			New();
		}

		public Einrichtung(Guid id)
		{
			Read(id);
		}
        
		#region Datenbank-Mapper
		protected dsEinrichtung.EinrichtungRow DB_ROW
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
			get	{	return DB_ROW.Text;	}
			set	{	DB_ROW.Text = value;}
		}
		public override Guid IDAdresse
		{
			get	{	return DB_ROW.IDAdresse;	}
			set	{	DB_ROW.IDAdresse = value;	}
		}
		public override Guid IDKontakt
		{
			get	{	return DB_ROW.IDKontakt;	}
			set	{	DB_ROW.IDKontakt = value;	}
		}

        public String ELGA_OID
        {
            get { return DB_ROW.ELGA_OID; }
            set { DB_ROW.ELGA_OID = value; }
        }
        public bool ELGAAbgeglichen
        {
            get { return DB_ROW.ELGAAbgeglichen; }
            set { DB_ROW.ELGAAbgeglichen = value; }
        }
        public bool IstKrankenkasse
        {
            get { return DB_ROW.IstKrankenkasse; }
            set { DB_ROW.IstKrankenkasse = value; }
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
