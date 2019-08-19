using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.GUI.Klient;





namespace PMDS.Klient
{
    public partial class DBKlient : Component
    {
        private Guid _idPatient = Guid.NewGuid();
        private Guid _idAufenthalt = Guid.NewGuid();

        public DBKlient()
        {
            InitializeComponent();
        }

        public DBKlient(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public Guid IDPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public Guid IDAufenthalt
        {
            get { return _idAufenthalt; }
            set { _idAufenthalt = value; }
        }

        public dsKlient KLIENT
        {
            get { return dsKlient1; }
        }

        /// <summary>
        /// Alle Kontaktpersonen eines Klients
        /// </summary>
        public dsKontaktperson KOTAKTPERSONEN
        {
            get { return dsKontaktperson1; }
        }

        /// <summary>
        /// Alle Kontaktpersonen eines Klients
        /// </summary>
        public dsKontaktpersonen KLIENT_KONTAKTPERSONEN
        {
            get { return dsKontaktpersonen; }
        }

        /// <summary>
        /// Alle Dienstleiste eines Klients
        /// </summary>
        public dsKontaktpersonen KLIENT_DIENSTLEISTER
        {
            get { return dsDienstleister; }
        }

        /// <summary>
        /// Alle Sachwalter eines Klients
        /// </summary>
        public dsSachwalter SACHWALTER
        {
            get { return dsSachwalter1; }
        }

        /// <summary>
        /// Alle Sachwalter eines Klients
        /// </summary>
        public dsKlientSachwalter KLIENT_SACHWALTER
        {
            get { return dsKlientSachwalter1; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            KlientByFilter();
            KontaktpersonenByPatient();
            SachwalterByPatient();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daPatient, dsKlient1.Klient); 
            
        }

        /// <summary>
        /// Daten eines Klienten lesen
        /// </summary>
        private void KlientByFilter()
        {
            daPatient.SelectCommand.Parameters["ID"].Value = IDPatient;
            dsKlient1.Klient.Rows.Clear();
            RBU.DataBase.Fill(daPatient, dsKlient1.Klient);
        }

        /// <summary>
        /// Alle Kontaktpersonen eines Klientes lesen
        /// </summary>
        private void KontaktpersonenByPatient()
        {
            daKontaktPBypatient.SelectCommand.Parameters["IDPatient"].Value = IDPatient;
            dsKontaktperson1.Kontaktperson.Rows.Clear();
            RBU.DataBase.Fill(daKontaktPBypatient, dsKontaktperson1.Kontaktperson);
        }

        /// <summary>
        /// Alle Sachwalter eines Klientes lesen
        /// </summary>
        private void SachwalterByPatient()
        {
            daSachwalterByPatient.SelectCommand.Parameters["IDPatient"].Value = IDPatient;
            dsSachwalter1.Sachwalter.Rows.Clear();
            RBU.DataBase.Fill(daSachwalterByPatient, dsSachwalter1.Sachwalter);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit einem neuen Medikamenten Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public void New()
        {
            dsKlient1.Klient.Rows.Clear();
            dsKlient.KlientRow r = dsKlient1.Klient.NewKlientRow();
            r.ID = Guid.NewGuid();
            r.RezeptgebuehrbefreiungJN = false;
            r.PflegegeldantragJN = false;
            r.PensionsteilungsantragJN = false;
            r.Verstorben = false;
            r.SetTodeszeitpunktNull();
            r.DNR = false;
            r.Milieubetreuung = false;
            r.KZUeberlebender = false;
            r.Anatomie = false;
            r.Einzelzimmer = false;
            r.Selbstzahler = false;
            r.abwesenheitenHändBerech = false;
            r.Sollstand = 0;
            r.minSaldo = 0;
            r.EinverständniserklärungFileType = "";
            r.KürzungLetzterTagAnwesenheit = false;
            r.Behindertenausweis = false;
            r.Sozialcard = false;
            r.SetIDAdresseSubNull();
            r.SetIDBereichNull();
            r.Kennwort = "";

            dsKlient1.Klient.AddKlientRow(r);
        }
    }
}
