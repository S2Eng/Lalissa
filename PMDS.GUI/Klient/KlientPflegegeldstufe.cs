using System;
using System.Collections.Generic;
using System.Text;
using PMDS.GUI.Klient;
using PMDS.Klient;

namespace PMDS.BusinessLogic
{
    public class KlientPflegegeldstufe
    {
        private DBKlientPflegegeldstufe _db;

        public KlientPflegegeldstufe()
        {
            _db = new DBKlientPflegegeldstufe();
            Read();
        }

        /// <summary>
        /// Alle Pflegegeldstufen
        /// </summary>
        public dsKlientPflegegeldstufe ALL
        {
            get { return _db.ALL; }
        }

        /// <summary>
        /// Alle Pflegegeldstufen einlesen
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
        /// Neue Pflegegeldstufe einfügen
        /// </summary>
        public void New()
        {
            _db.New();
        }
    }
}
