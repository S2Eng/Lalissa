using PMDS.Global.db.Patient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PMDS.BusinessLogic
{
    public class Arzt
    {
        private Guid _IDAdresse = Guid.Empty;
        private Guid _IDKontakt = Guid.Empty;
        private Guid _ID = Guid.Empty;
        private Adresse _Adresse;
        private Kontakt _Kontakt;
        private bool _deleted = false;

        public bool changedOnUI = false;




        public Arzt(Guid IDArzt, System.Data.EnumerableRowCollection<dsAdresse.AdresseRow> arrAdresse, System.Data.EnumerableRowCollection<dsKontakt.KontaktRow> arrKontakt)
        {
            _ID = IDArzt;
            if (arrAdresse.Count() > 0)
            {
                _IDAdresse = arrAdresse.First().ID;
                _Adresse = new Adresse();
                _Adresse._db.dsAdresse1.Adresse.Clear();
                dsAdresse.AdresseRow rNewAdress = (dsAdresse.AdresseRow)_Adresse._db.dsAdresse1.Adresse.NewRow();
                rNewAdress.ItemArray = arrAdresse.First().ItemArray;
                _Adresse._db.dsAdresse1.Adresse.AddAdresseRow(rNewAdress);
                _Adresse._db.dsAdresse1.AcceptChanges();
            }
            if (arrKontakt.Count() > 0)
            {
                _IDKontakt = arrKontakt.First().ID;
                _Kontakt = new Kontakt();
                _Kontakt._db.dsKontakt1.Kontakt.Clear();
                dsKontakt.KontaktRow rNewKontakt = (dsKontakt.KontaktRow)_Kontakt._db.dsKontakt1.Kontakt.NewRow();
                rNewKontakt.ItemArray = arrKontakt.First().ItemArray;
                _Kontakt._db.dsKontakt1.Kontakt.AddKontaktRow(rNewKontakt);
                _Kontakt._db.dsKontakt1.AcceptChanges();
            }
        }


        public Arzt(Guid ID, Guid IDAdresse, Guid IDKontakt)
        {
            _ID = ID;
            _IDAdresse = IDAdresse;
            _IDKontakt = IDKontakt;
            InitAdresse();
            InitKontakt();
        }

        public Arzt()
        {
            InitAdresse();
            InitKontakt();
        }

        private void InitAdresse()
        {
            if (_Adresse != null)
                return;

            if (IDAdresse == Guid.Empty)
            {
                _Adresse = new Adresse();
                _IDAdresse = _Adresse.ID;
            }
            else
            {
                _Adresse = new Adresse(IDAdresse);
            }
        }

        private void InitKontakt()
        {
            if (_Kontakt != null)
                return;

            if (IDKontakt == Guid.Empty)
            {
                _Kontakt = new Kontakt();
                _IDKontakt = _Kontakt.ID;
            }
            else
            {
                _Kontakt = new Kontakt(IDKontakt);
            }
        }
        public void Delete()
        {
            _deleted = true;
        }

        public bool DELETED
        {
            get { return _deleted; }
        }
        public Guid ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public Guid IDAdresse
        {
            get { return _IDAdresse; }
            set 
            {
                _IDAdresse = value;
                InitAdresse();
            }
        }

        public Guid IDKontakt
        {
            get { return _IDKontakt; }
            set 
            { 
                _IDKontakt = value;
                InitKontakt();
            }
        }
        public Adresse Adresse
        {
            get
            {
                InitAdresse();
                return _Adresse;
            }
        }
        public Kontakt Kontakt
        {
            get
            {
                InitKontakt();
                return _Kontakt;
            }
        }

    }
}
