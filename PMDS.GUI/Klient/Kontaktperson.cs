using System;
using System.Collections.Generic;
using System.Text;
using PMDS.GUI.Klient;
using PMDS.Klient;

namespace PMDS.BusinessLogic
{
    public class Kontaktperson
    {
        private DBKontaktperson _db;
        private Guid _idKontaktperson = Guid.NewGuid();

        private Adresse _adresse;
        private Kontakt _kontakt;
        private bool _deleted = false;

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public Kontaktperson()
        {
            _db = new DBKontaktperson();
            _adresse = new Adresse();
            _kontakt = new Kontakt();
            New();
            IDAdresse = _adresse.ID;
            IDKontakt = _kontakt.ID;
        }

        /// <summary>
        /// Konstruktor zum lesen eines bestimmten Eintrages
        /// </summary>
        public Kontaktperson(Guid idKontaktperson)
        {
            _db = new DBKontaktperson();
            _idKontaktperson = idKontaktperson;
            _db.IDKontaktperson = _idKontaktperson;
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
                KONTAKTPERSON_ROW.Delete();
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
        /// Kontaktperson Daten
        /// </summary>
        public dsKontaktperson DS_KONTAKTPERSON
        {
            get { return _db.KOTAKTPERSON; }
        }

        private dsKontaktperson.KontaktpersonRow KONTAKTPERSON_ROW
        {
            get { return _db.KOTAKTPERSON.Kontaktperson[0]; }
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
            get { return KONTAKTPERSON_ROW.ID; }
            set { KONTAKTPERSON_ROW.ID = value; }
        }

        public Guid IDPatient
        {
            get { return KONTAKTPERSON_ROW.IDPatient; }
            set { KONTAKTPERSON_ROW.IDPatient = value; }
        }

        public Guid IDAdresse
        {
            get { return KONTAKTPERSON_ROW.IDAdresse; }
            set { KONTAKTPERSON_ROW.IDAdresse = value; }
        }

        public Guid IDKontakt
        {
            get { return KONTAKTPERSON_ROW.IDKontakt; }
            set { KONTAKTPERSON_ROW.IDKontakt = value; }
        }

        public string Titel
        {
            get { return KONTAKTPERSON_ROW.IsTitelNull() ? "" : KONTAKTPERSON_ROW.Titel.Trim(); }
            set { KONTAKTPERSON_ROW.Titel = value; }
        }

        public string Nachname
        {
            get { return KONTAKTPERSON_ROW.IsNachnameNull() ? "" : KONTAKTPERSON_ROW.Nachname.Trim(); }
            set { KONTAKTPERSON_ROW.Nachname = value; }
        }

        public string Vorname
        {
            get { return KONTAKTPERSON_ROW.IsVornameNull() ? "" : KONTAKTPERSON_ROW.Vorname.Trim(); }
            set { KONTAKTPERSON_ROW.Vorname = value; }
        }

        public bool VerstaendigenJN
        {
            get { return KONTAKTPERSON_ROW.IsVerstaendigenJNNull() ? false : KONTAKTPERSON_ROW.VerstaendigenJN; }
            set { KONTAKTPERSON_ROW.VerstaendigenJN = value; }
        }

        public string Kontaktart
        {
            get { return KONTAKTPERSON_ROW.IsKontaktartNull() ? "" : KONTAKTPERSON_ROW.Kontaktart.Trim(); }
            set { KONTAKTPERSON_ROW.Kontaktart = value; }
        }

        public string Verwandschaft
        {
            get { return KONTAKTPERSON_ROW.IsVerwandtschaftNull() ? "" : KONTAKTPERSON_ROW.Verwandtschaft.Trim(); }
            set { KONTAKTPERSON_ROW.Verwandtschaft = value; }
        }

        public bool ExternerDienstleisterJN
        {
            get { return KONTAKTPERSON_ROW.IsExternerDienstleisterJNNull() ? false : KONTAKTPERSON_ROW.ExternerDienstleisterJN; }
            set { KONTAKTPERSON_ROW.ExternerDienstleisterJN = value; }
        }
        #endregion
    }
}
