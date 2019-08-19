using System;
using System.Collections.Generic;
using System.Text;
using PMDS.GUI.Klient;
using PMDS.Klient;

namespace PMDS.BusinessLogic
{
    public class Sachwalter
    {
        private DBSachwalter _db;
        private Guid _idSachwalter = Guid.NewGuid();

        private Adresse _adresse;
        private Kontakt _kontakt;
        private bool _deleted = false;

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public Sachwalter()
        {
            _db = new DBSachwalter();
            _adresse = new Adresse();
            _kontakt = new Kontakt();
            New();
            IDAdresse = _adresse.ID;
            IDKontakt = _kontakt.ID;
        }

        /// <summary>
        /// Konstruktor zum lesen eines bestimmten Eintrages
        /// </summary>
        public Sachwalter(Guid idSachwalter)
        {
            _db = new DBSachwalter();
            _idSachwalter = idSachwalter;
            _db.IDSachwalter = idSachwalter;
            Read();
            _adresse = new Adresse(IDAdresse);
            _kontakt = new Kontakt(IDKontakt);
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            _db.Read();
        }

        /// <summary>
        /// Neues Eintrag
        /// </summary>
        public void New()
        {
            _db.New();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            if (_deleted)
            {
                SACHWALTER_ROW.Delete();
                _db.Write();
                Adresse.Delete();
                Kontakt.Delete();
            }
            else
            {

                Adresse.Write();
                Kontakt.Write();
                _db.Write();
            }
            
        }

        /// <summary>
        /// Datensatz löschen
        /// </summary>
        public void Delete()
        {
            _deleted = true;
        }

        /// <summary>
        /// Sachwalter Daten
        /// </summary>
        public dsSachwalter DS_SACHWALTER
        {
            get { return _db.SACHWALTER; }
        }

        private dsSachwalter.SachwalterRow SACHWALTER_ROW
        {
            get { return _db.SACHWALTER.Sachwalter[0]; }
        }

        #region PROPERTIES
        public bool DELETED
        {
            get { return _deleted; }
        }

        public Adresse Adresse
        {
            get { return _adresse; }
        }

        public Kontakt Kontakt
        {
            get { return _kontakt; }
        }

        public Guid ID
        {
            get { return SACHWALTER_ROW.ID; }
            set { SACHWALTER_ROW.ID = value; }
        }

        public Guid IDPatient
        {
            get { return SACHWALTER_ROW.IDPatient; }
            set { SACHWALTER_ROW.IDPatient = value; }
        }

        public Guid IDAdresse
        {
            get { return SACHWALTER_ROW.IDAdresse; }
            set { SACHWALTER_ROW.IDAdresse = value; }
        }

        public Guid IDKontakt
        {
            get { return SACHWALTER_ROW.IDKontakt; }
            set { SACHWALTER_ROW.IDKontakt = value; }
        }

        public string Titel
        {
            get { return SACHWALTER_ROW.IsTitelNull() ? "" : SACHWALTER_ROW.Titel.Trim(); }
            set { SACHWALTER_ROW.Titel = value; }
        }

        public string Nachname
        {
            get { return SACHWALTER_ROW.IsNachnameNull() ? "" : SACHWALTER_ROW.Nachname.Trim(); }
            set { SACHWALTER_ROW.Nachname = value; }
        }

        public string Vorname
        {
            get { return SACHWALTER_ROW.IsVornameNull() ? "" : SACHWALTER_ROW.Vorname.Trim(); }
            set { SACHWALTER_ROW.Vorname = value; }
        }

        public bool SachwalterJN
        {
            get { return SACHWALTER_ROW.IsSachwalterJNNull() ? false : SACHWALTER_ROW.SachwalterJN; }
            set { SACHWALTER_ROW.SachwalterJN = value; }
        }

        public string Belange
        {
            get { return SACHWALTER_ROW.IsBelangeNull() ? "" : SACHWALTER_ROW.Belange.Trim(); }
            set { SACHWALTER_ROW.Belange = value; }
        }

        public object Von
        {
            get
            {
                if (SACHWALTER_ROW.IsVonNull())
                    return null;

                return SACHWALTER_ROW.Von;
            }

            set
            {
                if (value == null)
                    SACHWALTER_ROW.SetVonNull();
                else
                    SACHWALTER_ROW.Von = (DateTime)value;
            }
        }

        public object Bis
        {
            get
            {
                if (SACHWALTER_ROW.IsBisNull())
                    return null;

                return SACHWALTER_ROW.Bis;
            }

            set
            {
                if (value == null)
                    SACHWALTER_ROW.SetBisNull();
                else
                    SACHWALTER_ROW.Bis = (DateTime)value;
            }
        }

        public string Gericht
        {
            get { return SACHWALTER_ROW.IsGerichtNull() ? "" : SACHWALTER_ROW.Gericht.Trim(); }
            set { SACHWALTER_ROW.Gericht = value; }
        }

        public object BestimmtAm
        {
            get
            {
                if (SACHWALTER_ROW.IsBestimmtAmNull())
                    return null;

                return SACHWALTER_ROW.BestimmtAm;
            }

            set
            {
                if (value == null)
                    SACHWALTER_ROW.SetBestimmtAmNull();
                else
                    SACHWALTER_ROW.BestimmtAm = (DateTime)value;
            }
        }

        public string Bemerkung
        {
            get { return SACHWALTER_ROW.IsBemerkungNull() ? "" : SACHWALTER_ROW.Bemerkung.Trim(); }
            set { SACHWALTER_ROW.Bemerkung = value; }
        }
        #endregion
    }
}
