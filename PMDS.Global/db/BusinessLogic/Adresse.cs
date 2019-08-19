using System;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.BusinessLogic
{


    public class Adresse : BusinessBase, IBusinessBase
    {
        public DBAdresse _db = new DBAdresse();

       




        protected override IDBBase DBInterface
        {
            get { return (IDBBase)_db; }
        }

        public Adresse()
        {
            New();
        }





        public Adresse(Guid id)
        {
            Read(id);
        }

        #region Datenbank-Mapper
        protected dsAdresse.AdresseRow DB_ROW
        {
            get { return _db.ITEM[0]; }
        }
        #endregion

        #region PROPERTIES
        public Guid ID
        {
            get { return DB_ROW.ID; }
            set { DB_ROW.ID = value; }
        }
        public String Strasse
        {
            get { return DB_ROW.Strasse; }
            set { DB_ROW.Strasse = value; }
        }
        public String Plz
        {
            get { return DB_ROW.Plz; }
            set { DB_ROW.Plz = value; }
        }
        public String Ort
        {
            get { return DB_ROW.Ort; }
            set { DB_ROW.Ort = value; }
        }
        public String Region
        {
            get { return DB_ROW.Region; }
            set { DB_ROW.Region = value; }
        }
        public String LandKZ
        {
            get { return DB_ROW.LandKZ; }
            set { DB_ROW.LandKZ = value; }
        }
        #endregion

        #region IBusinessBase Members

        DataRow IBusinessBase.ROW
        {
            get { return DB_ROW; }
        }

        #endregion
    }
}
