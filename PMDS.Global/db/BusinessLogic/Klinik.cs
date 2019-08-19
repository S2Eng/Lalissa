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


    public class Klinik : AdresseKontaktBasis, IBusinessBase, IZusatz
    {
        private DBKlinik _db = new DBKlinik();
        private Bank _Bank;



        protected override IDBBase DBInterface
        {
            get { return (IDBBase)_db; }
        }


        public static Klinik Default()
        {
            return new Klinik(DefaultID());
        }

        public static Guid DefaultID()
        {
            return System.Guid.Empty;
        }

        public Klinik()
        {
            New();
        }

        public Klinik(Guid id)
        {
            Read(id);
        }

        public KlinikAbteilungen Abteilungen
        {
            get { return new KlinikAbteilungen(ID); }
        }
        public KlinikBereiche Bereiche
        {
            get { return new KlinikBereiche(ID); }
        }

        public Bank Bank
        {
            get
            {
                InitBank();
                return _Bank;
            }
        }

        private void InitBank()
        {
            // Adresse bereits vorhanden
            if (_Bank != null)
                return;

            // neue Adresse ?
            if (IDBank == Guid.Empty)
            {
                _Bank = new Bank();
                IDBank = _Bank.ID;
            }
            else
            {
                _Bank = new Bank(IDBank);
            }
        }

        public override void Write()
        {
            Bank.Write();
            base.Write();
        }


        #region Datenbank-Mapper
        public dsKlinik.KlinikRow DB_ROW
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
        public String Bezeichnung
        {
            get { return DB_ROW.Bezeichnung; }
            set { DB_ROW.Bezeichnung = value; }
        }
        public override Guid IDAdresse
        {
            get { return DB_ROW.IDAdresse; }
            set { DB_ROW.IDAdresse = value; }
        }
        public override Guid IDKontakt
        {
            get { return DB_ROW.IDKontakt; }
            set { DB_ROW.IDKontakt = value; }
        }

        public Guid IDBank
        {
            get { return DB_ROW.IsIDBankNull() ? Guid.Empty : DB_ROW.IDBank; }
            set { DB_ROW.IDBank = value; }
        }

        public String ZVR
        {
            get { return DB_ROW.IsZVRNull() ? "" : DB_ROW.ZVR; }
            set { DB_ROW.ZVR = value; }
        }
        #endregion

        #region IBusinessBase Members

        DataRow IBusinessBase.ROW
        {
            get { return DB_ROW; }
        }

        #endregion

        #region IZusatz Members
        object IZusatz.ZusatzWertForAbteilung(Guid idAbteilung)
        {
            return new ZusatzWert("KLI", idAbteilung, ID);
        }

        #endregion

    }
}
