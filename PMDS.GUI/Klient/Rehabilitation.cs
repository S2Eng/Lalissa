using System;
using System.Collections.Generic;
using System.Text;
using PMDS.GUI.Klient;
using PMDS.Klient;

namespace PMDS.BusinessLogic
{
    public class Rehabilitation
    {
        private DBRehabilitation _db;
        private Guid _idPatient = Guid.NewGuid();

        public Rehabilitation()
        {
            _db = new DBRehabilitation();
            _db.IDPatient = _idPatient;
        }

        public Rehabilitation(Guid idPatient)
        {
            _idPatient = idPatient;
            _db = new DBRehabilitation();
            _db.IDPatient = _idPatient;
            Read();
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set
            {
                _idPatient = value;
                _db.IDPatient = value;
                Read();
            }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsRehabilitation ALL
        {
            get { return _db.ALL; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            _db.Read();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            _db.Write();
        }

        /// <summary>
        /// Neue Rehabilitation einfügen
        /// </summary>
        public void New(bool maßnahmeJN, object Von, object Bis, string Beschreibung, string Ziel, string Institution,
                        string EndeGrund, string Bemerkung)
        {
            _db.New(maßnahmeJN, Von, Bis, Beschreibung, Ziel, Institution, EndeGrund, Bemerkung);
        }
    }
}
