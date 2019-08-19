using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Klient;
using PMDS.GUI.Klient;

namespace PMDS.BusinessLogic
{
    public class KlientPflegestufe
    {
        private DBKlientPflegestufe _db;
        private Guid _idPatient = Guid.NewGuid();

        public KlientPflegestufe()
        {
            _db = new DBKlientPflegestufe();
            _db.IDpatient = _idPatient;
            Read();
        }

        public KlientPflegestufe(Guid idPatient)
        {
            _db = new DBKlientPflegestufe();
            _idPatient = idPatient;
            _db.IDpatient = idPatient;
            Read();
        }

        public Guid IDpatient
        {
            get { return _idPatient; }
            set 
            { 
                _idPatient = value; 
                _db.IDpatient = value;
                Read();
            }
        }

        /// <summary>
        /// Alle Patien Pflegestufen
        /// </summary>
        public dsKlientPflegestufe ALL
        {
            get { return _db.ALL; }
        }

        /// <summary>
        /// Alle patien Pflegestufen einlesen
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
        /// Neue PatienPflegegeldstufe einfügen
        /// </summary>
        public void New(object pflegestufe, DateTime gueltigAb, DateTime antragsdatum, object beantragtePflagestufe,
                        DateTime bescheiddatum)
        {
            _db.New(pflegestufe, gueltigAb, antragsdatum, beantragtePflagestufe, bescheiddatum);
        }
    }
}
