using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using PMDS.Global;
using PMDS.GUI.Klient;
using System.Data;

namespace PMDS.Klient
{

    public partial class DBMedizinischeDaten : Component
    {


        private Guid _idPatient = Guid.NewGuid();
        private Guid _idBenutzer = Guid.NewGuid();

        public DBMedizinischeDaten()
        {
            InitializeComponent();
        }

        public DBMedizinischeDaten(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }





        public Guid IDPatient
        {
            get { return _idPatient; }
            set { _idPatient = value; }
        }

        public Guid IDBenutzer
        {
            get { return _idBenutzer; }
            set { _idBenutzer = value; }
        }

        /// <summary>
        /// Alle Medizinische Daten (Medizinischetyp: Kostform) eines Klients
        /// </summary>
        public dsMedizinischeDaten ALL
        {
            get { return dsMedizinischeDaten1; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            ReadMedDatenByPatient();
        }

        /// <summary>
        /// Alle Medizinische Daten eines Klients lesen
        /// </summary>
        private void ReadMedDatenByPatient()
        {
            daMeDatenByPatient.SelectCommand.Parameters["IDPatient"].Value = IDPatient;
            dsMedizinischeDaten1.MedizinischeDaten.Rows.Clear();
            RBU.DataBase.Fill(daMeDatenByPatient, dsMedizinischeDaten1.MedizinischeDaten);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert einen Datatable mit einem neuen MedizinischeDaten Eintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public void New(MedizinischerTyp medTyp, DateTime von, DateTime bis, string beschreibung, string bemerkung,
                       string beendigungsgrund, DateTime letzteVersorgung, DateTime naechsteVersorgung, string modell, string handling,
                       string therapie, string ICDCode, bool aufnahmeDiagnose, bool antikoaguliert, string Typ, double anzahl, bool nuechtern, string groesse,
                       Guid IDMedDatenNew, string xy, bool SetRowUnmodified)
        {
            dsMedizinischeDaten.MedizinischeDatenRow r = dsMedizinischeDaten1.MedizinischeDaten.NewMedizinischeDatenRow();
            r.ID = IDMedDatenNew;
            r.IDPatient = IDPatient;
            r.IDBenutzergeaendert = IDBenutzer;
            r.MedizinischerTyp = (int)medTyp;
            
            //Beschreibung
            r.Beschreibung = beschreibung;
            
            //ICDCode
            if (medTyp == MedizinischerTyp.AktuelleDiagnosen || medTyp == MedizinischerTyp.DauerDiagnosen)
                r.ICDCode = ICDCode;
            else
                r.SetICDCodeNull();

            //Von
            if (von > DateTime.MinValue && von < DateTime.MaxValue)
                r.Von = von;
            else
                r.SetVonNull();

            //Bis
            if (bis > DateTime.MinValue && bis < DateTime.MaxValue)
                r.Bis = bis;
            else
                r.SetBisNull();
            

            //Beendigungsgrund
            if (medTyp != MedizinischerTyp.Impfungen)
                r.Beendigungsgrund = beendigungsgrund;
            else
                r.SetBeendigungsgrundNull();

            //AufnahmediagnoseJN
            if (medTyp == MedizinischerTyp.AktuelleDiagnosen || medTyp == MedizinischerTyp.DauerDiagnosen)
                r.AufnahmediagnoseJN = aufnahmeDiagnose;
            else
                r.SetAufnahmediagnoseJNNull();

            //Bemerkung
            r.Bemerkung = bemerkung;
                

            //Therapie
            r.Therapie = therapie;
            
            //Anzahl
            if (medTyp == MedizinischerTyp.Suchtmittel)
                r.Anzahl = anzahl;
            else
                r.SetAnzahlNull();

            //AntikoaguliertJN
            if (medTyp == MedizinischerTyp.Antikoagulation)
                r.AntikoaguliertJN = antikoaguliert;
            else
                r.SetAntikoaguliertJNNull();

            //Typ
            r.Typ = Typ;
            
            //Handling
            r.SetHandlingNull();
            if (medTyp == MedizinischerTyp.KathederSondenStomata)
                r.Handling = handling;

            //LetzteVersorgung - NaechsteVersorgung
            if (medTyp == MedizinischerTyp.ImplentateProthesen || medTyp == MedizinischerTyp.KathederSondenStomata)
            {
                if (letzteVersorgung > DateTime.MinValue && letzteVersorgung < DateTime.MaxValue)
                    r.LetzteVersorgung = letzteVersorgung;
                else
                    r.SetLetzteVersorgungNull();

                if (naechsteVersorgung > DateTime.MinValue && naechsteVersorgung < DateTime.MaxValue)
                    r.NaechsteVersorgung = naechsteVersorgung;
                else
                    r.SetNaechsteVersorgungNull();
            }
            else
            {
                r.SetLetzteVersorgungNull();
                r.SetNaechsteVersorgungNull();
            }

            //Model
            r.SetModellNull();
            if (medTyp == MedizinischerTyp.ImplentateProthesen || medTyp == MedizinischerTyp.KathederSondenStomata ||
                medTyp == MedizinischerTyp.Impfungen)
            {
                r.Modell = modell;
            }

            //NuechternJN
            if (medTyp == MedizinischerTyp.Nuechtern)
                r.NuechternJN = nuechtern;
            else
                r.SetNuechternJNNull();

            r.Groesse = "";
            r.SetIDBefundNull();
            r.Verordnungen = "";
            r.lstRezepteinträge = "";
            r.NumberRezepteinträge = 0;

            dsMedizinischeDaten1.MedizinischeDaten.AddMedizinischeDatenRow(r);
            if (SetRowUnmodified)
                r.AcceptChanges();
        }

        public bool getMedDatenByID(Guid IDMedDaten, dsMedizinischeDaten ds)
        {
            this.daMedizinischeDatenByID.SelectCommand.Parameters[0].Value = IDMedDaten;
            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                RBU.DataBase.CONNECTION.Open();
            this.daMedizinischeDatenByID.SelectCommand.Connection = RBU.DataBase.CONNECTION;
            this.daMedizinischeDatenByID.Fill(ds.MedizinischeDaten);
            return true;
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            RBU.DataBase.Update(daMeDatenByPatient, dsMedizinischeDaten1);
        }
    }
}
