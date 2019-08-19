using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;



namespace PMDS.Klient
{
    public partial class DBGegenstaende : Component
    {
        private Guid _idAufenthalt = Guid.NewGuid();

        public DBGegenstaende()
        {
            InitializeComponent();
        }

        public DBGegenstaende(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set { _idAufenthalt = value; }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen
        /// </summary>
        public dsGegenstaende ALL
        {
            get { return dsGegenstaende1; }
        }

        /// <summary>
        /// Alle Patien Rehabilitationen einlesen
        /// </summary>
        public void Read()
        {
            dsGegenstaende1.Gegenstaende.Clear();
            daGegenstaende.SelectCommand.Parameters[0].Value = _idAufenthalt;
            RBU.DataBase.Fill(daGegenstaende, dsGegenstaende1);
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daGegenstaende, dsGegenstaende1);
        }

        /// <summary>
        /// Neue Rehabilitation einfügen
        /// </summary>
        public void New(bool hilfsmittelJN, string beschreibung, string nummer, DateTime von, DateTime bis,
                        object IDBenutzerAusgegeben, object IDBenutzerZurueckgegeben, 
                        bool EigentumKlinikJN, bool EigentumKlientJN, bool MieteJN, string Eigentuemer,
                        DateTime LetzteUeberpruefungAm, DateTime NaechsteUeberpruefungAm)
        {
            dsGegenstaende.GegenstaendeRow r = dsGegenstaende1.Gegenstaende.NewGegenstaendeRow();
            r.ID = Guid.NewGuid();
            r.IDAufenthalt = IDAufenthalt;

            if (IDBenutzerAusgegeben != null)
                r.IDBenutzerausgegeben = new Guid(IDBenutzerAusgegeben.ToString());

            if (IDBenutzerZurueckgegeben != null)
                r.IDBenutzerzurueck = new Guid(IDBenutzerZurueckgegeben.ToString());

            if (beschreibung != "")
                r.Beschreibung = beschreibung;

            if (nummer != "")
                r.Nr = nummer;

            if (von != DateTime.MinValue)
                r.Von = von;

            if (bis != DateTime.MinValue)
                r.Bis = bis;
            
            r.HilfesmittelJN = hilfsmittelJN;
            dsGegenstaende1.Gegenstaende.AddGegenstaendeRow(r);

            r.EigentumKlinikJN = EigentumKlinikJN;

            r.EigentumKlientJN = EigentumKlientJN;

            r.MieteJN = MieteJN;

            if (Eigentuemer != "")
                r.Eigentuemer = Eigentuemer;

            if (LetzteUeberpruefungAm != DateTime.MinValue)
                r.LetzteUeberpruefungAm = LetzteUeberpruefungAm;

            if (NaechsteUeberpruefungAm != DateTime.MinValue)
                r.NaechsteUeberpruefungAm = NaechsteUeberpruefungAm;

        }
    }
}
