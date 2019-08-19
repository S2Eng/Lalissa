using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Klient;
using PMDS.GUI.Klient;



namespace PMDS.BusinessLogic
{
    public class Gegenstaende
    {
        private DBGegenstaende _db;
        private Guid _idAufenthalt = Guid.NewGuid();

        public Gegenstaende()
        {
            _db = new DBGegenstaende();
            _db.IDAufenthalt = _idAufenthalt;
        }

        public Gegenstaende(Guid idAufenthalt)
        {
            _idAufenthalt = idAufenthalt;
            _db = new DBGegenstaende();
            _db.IDAufenthalt = _idAufenthalt;
            Read();
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set
            {
                _idAufenthalt = value;
                _db.IDAufenthalt = value;
                Read();
            }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsGegenstaende ALL
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
        public void New(bool hilfsmittelJN, string beschreibung, string nummer, DateTime von, DateTime bis,
                        object IDBenutzerAusgegeben, object IDBenutzerZurueckgegeben,
                        bool EigentumKlinikJN, bool EigentumKlientJN, bool MieteJN, string Eigentuemer,
                        DateTime LetzteUeberpruefungAm, DateTime NaechsteUeberpruefungAm)
        {
            _db.New(hilfsmittelJN, beschreibung, nummer, von, bis, IDBenutzerAusgegeben, IDBenutzerZurueckgegeben, 
                        EigentumKlinikJN, EigentumKlientJN, MieteJN, Eigentuemer, LetzteUeberpruefungAm, NaechsteUeberpruefungAm);
        }
    }
}
