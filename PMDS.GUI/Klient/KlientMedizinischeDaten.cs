using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Klient;
using PMDS.GUI;
using PMDS.GUI.Klient;

namespace PMDS.BusinessLogic
{
    public class KlientMedizinischeDaten
    {
        private DBMedizinischeDaten _db;
        private Guid _idPatient = Guid.NewGuid();
        private Guid _idBenutzer = Guid.NewGuid();

        private dsMedizinischeDaten _dsKostform = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsInfektion = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsDiabetes = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsAntikoa = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsAllergien = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsUnvertraeglichkeiten = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsDiagn = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsDauerDiagn = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsImplantate = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsKatheder = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsImpfung = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsSuchtm = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsSonst = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsNuecht = new dsMedizinischeDaten();
        private dsMedizinischeDaten _dsBefunde = new dsMedizinischeDaten();

        /// <summary>
        /// Default Konstruktor
        /// </summary>
        public KlientMedizinischeDaten()
        {
            _db = new DBMedizinischeDaten();
        }

        /// <summary>
        /// Konstruktor zum lesen eines bestimmten Eintrages
        /// </summary>
        public KlientMedizinischeDaten(Guid idPatient, Guid idBenutzer)
        {
            _db = new DBMedizinischeDaten();
            _idPatient = idPatient;
            _idBenutzer = idBenutzer;
            _db.IDPatient = idPatient;
            _db.IDBenutzer = idBenutzer;
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

        public Guid IDBenutzer
        {
            get { return _idBenutzer; }
            set
            {
                _idBenutzer = value;
                _db.IDBenutzer = value;
            }
        }

        /// <summary>
        /// Alle Medizinische Daten (Medizinischetyp: Kostform) eines Klients
        /// </summary>
        public dsMedizinischeDaten ALL
        {
            get { return _db.ALL; }
        }

        public dsMedizinischeDaten KOSTFORM
        {
            get { return _dsKostform; }
        }

        public dsMedizinischeDaten INFEKTIONEN
        {
            get { return _dsInfektion; }
        }

        public dsMedizinischeDaten DIABETES
        {
            get { return _dsDiabetes; }
        }

        public dsMedizinischeDaten ANTIKOAGOLATION
        {
            get { return _dsAntikoa; }
        }

        public dsMedizinischeDaten ALLERGIEN
        {
            get { return _dsAllergien; }
        }

        public dsMedizinischeDaten UNVERTRAEGLICHKEITEN
        {
            get { return _dsUnvertraeglichkeiten; }
        }

        public dsMedizinischeDaten DIAGNOSEN
        {
            get { return _dsDiagn; }
        }

        public dsMedizinischeDaten DAUERDIAGNOSEN
        {
            get { return _dsDauerDiagn; }
        }

        public dsMedizinischeDaten IMPLENTATE
        {
            get { return _dsImplantate; }
        }

        public dsMedizinischeDaten KATHEDER
        {
            get { return _dsKatheder; }
        }

        public dsMedizinischeDaten IMPFUNGEN
        {
            get { return _dsImpfung; }
        }

        public dsMedizinischeDaten SUCHTMITTEL
        {
            get { return _dsSuchtm; }
        }

        public dsMedizinischeDaten SONSTIGE
        {
            get { return _dsSonst; }
        }
        public dsMedizinischeDaten Befunde
        {
            get { return _dsBefunde; }
        }
        public dsMedizinischeDaten NUECHTERN
        {
            get { return _dsNuecht; }
        }

        /// <summary>
        /// Daten lesen
        /// </summary>
        public void Read()
        {
            _db.Read();
            InitMedDatenByTypen();
        }

        /// <summary>
        /// Daten schreiben
        /// </summary>
        public void Write()
        {
            _db.Write();
        }

        /// <summary>
        /// Neue Medizinische Daten einfügen
        /// </summary>
        public void New(MedizinischerTyp medTyp, DateTime von, DateTime bis, string beschreibung, string bemerkung,
                       string beendigungsgrund, DateTime letzteVersorgung, DateTime naechsteVersorgung, string modell, string handling,
                       string therapie, string ICDCode, bool aufnahmeDiagnose, bool antikoaguliert, string Typ, double anzahl, bool nuechtern, string groesse, 
                        Guid IDMedDatenNew, string xy, bool SetRowUnmodified)
        {
            _db.New(medTyp, von, bis, beschreibung, bemerkung,beendigungsgrund,
                       letzteVersorgung, naechsteVersorgung, modell, handling,
                       therapie, ICDCode, aufnahmeDiagnose, antikoaguliert,Typ, anzahl, nuechtern, groesse,
                       IDMedDatenNew, xy, SetRowUnmodified);

            Refresh(medTyp);

        }

        /// <summary>
        /// Eine MedizinischeDatenRow beenden
        /// </summary>
        public void CloseMedDaten(Guid id, MedizinischerTyp medTyp, DateTime bis, string beendigungsgrund)
        {
            foreach (dsMedizinischeDaten.MedizinischeDatenRow row in ALL.MedizinischeDaten)
            {
                if (row.RowState != DataRowState.Deleted && row.ID == id)
                {
                    if (bis > DateTime.MinValue && bis < DateTime.MaxValue)
                        row.Bis = bis;

                    if (medTyp != MedizinischerTyp.Nuechtern)
                        row.Beendigungsgrund = beendigungsgrund;

                    Refresh(medTyp);
                    break;
                }
            }
        }

        /// <summary>
        /// Eine MedizinischeDatenRow ändern
        /// </summary>
        public void UpdateMedDatenRow(Guid id, MedizinischerTyp medTyp, DateTime von, DateTime bis, string beschreibung, string bemerkung,
                       string beendigungsgrund, DateTime letzteVersorgung, DateTime naechsteVersorgung, string modell, string handling,
                       string therapie, string ICDCode, bool aufnahmeDiagnose, bool antikoaguliert, string Typ, double anzahl, bool nuechtern, string groesse, string lstRezepteinträge, int NumberRezepteinträge)
        {

            foreach (dsMedizinischeDaten.MedizinischeDatenRow row in ALL.MedizinischeDaten)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row.ID == id)
                    {
                        if (von > DateTime.MinValue && von < DateTime.MaxValue)
                            row.Von = von;
                        else
                            row.SetVonNull();

                        if (bis > DateTime.MinValue && bis < DateTime.MaxValue)
                            row.Bis = bis;
                        else
                            row.SetBisNull();

                        row.Beschreibung = beschreibung;
                        row.Bemerkung = bemerkung;

                        if (medTyp != MedizinischerTyp.Impfungen)
                            row.Beendigungsgrund = beendigungsgrund;
                        else
                            row.SetBeendigungsgrundNull();

                        if (letzteVersorgung > DateTime.MinValue && letzteVersorgung < DateTime.MaxValue)
                            row.LetzteVersorgung = letzteVersorgung;
                        else
                            row.SetLetzteVersorgungNull();

                        if (naechsteVersorgung > DateTime.MinValue && naechsteVersorgung < DateTime.MaxValue)
                            row.NaechsteVersorgung = naechsteVersorgung;
                        else
                            row.SetNaechsteVersorgungNull();


                        if (medTyp == MedizinischerTyp.ImplentateProthesen || medTyp != MedizinischerTyp.KathederSondenStomata)
                            row.Modell = modell;
                        else
                            row.SetModellNull();

                        row.Handling = handling;

                        row.Therapie = therapie;

                        row.ICDCode = ICDCode;

                        if (medTyp == MedizinischerTyp.AktuelleDiagnosen || medTyp == MedizinischerTyp.DauerDiagnosen)
                            row.AufnahmediagnoseJN = aufnahmeDiagnose;

                        if (medTyp == MedizinischerTyp.Antikoagulation)
                            row.AntikoaguliertJN = antikoaguliert;

                        row.Typ = Typ;

                        if (medTyp == MedizinischerTyp.Suchtmittel && anzahl != -1)
                            row.Anzahl = anzahl;
                        else
                            row.SetAnzahlNull();

                        if (medTyp == MedizinischerTyp.Nuechtern)
                            row.NuechternJN = nuechtern;

                        row.Groesse = groesse;

                        row.lstRezepteinträge = lstRezepteinträge;
                        row.NumberRezepteinträge = NumberRezepteinträge;

                        Refresh(medTyp);
                        break;
                    }
                }
                else
                {
                    bool bIsDeleted = true;
                }
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Löscht Datensatz
        /// </summary>
        //----------------------------------------------------------------------------
        public void Delete(MedDatenArgs[] args)
        {
            if (args.Length == 0)
                return;

            List<MedizinischerTyp> list = new List<MedizinischerTyp>();
            int medTyp = 0;

            foreach (MedDatenArgs arg in args)
            {
                if (medTyp != arg.MedTyp)
                {
                    medTyp = arg.MedTyp;
                    list.Add((MedizinischerTyp)Enum.Parse(typeof(MedizinischerTyp), arg.MedTyp.ToString()));
                }

                foreach (dsMedizinischeDaten.MedizinischeDatenRow row in ALL.MedizinischeDaten)
                {
                    if (row.RowState != DataRowState.Deleted && row.ID == arg.ID)
                    {
                        row.Delete();
                        break;
                    }
                }
            }
            foreach(MedizinischerTyp typ in list)
                Refresh(typ);
        }
        
        private void InitMedDatenByTypen()
        {
            InitKostform();
            InitInfektionen();
            InitDiabetes();
            InitAntikoagulation();
            InitAllergien();
            InitUnvertraeglichkeiten();
            InitDiagnosen();
            InitDauerDiagnosen();
            InitImplantate();
            InitKatheder();
            InitImpfung();
            InitSuchtmittel();
            InitSonstige();
            InitNuechtern();
            this.InitBefunde();
        }

        public void Refresh(MedizinischerTyp medTyp)
        {
            switch (medTyp)
            {
                case MedizinischerTyp.AktuelleDiagnosen:
                    _dsDiagn.MedizinischeDaten.Clear();
                    break;

                case MedizinischerTyp.DauerDiagnosen:
                    _dsDauerDiagn.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Allergien:
                    _dsAllergien.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Antikoagulation:
                    _dsAntikoa.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Unvertraeglichkeiten:
                    _dsUnvertraeglichkeiten.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Diabetes:
                    _dsDiabetes.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Impfungen:
                    _dsImpfung.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.ImplentateProthesen:
                    _dsImplantate.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Infektionen:
                    _dsInfektion.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.KathederSondenStomata:
                    _dsKatheder.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Kostform:
                    _dsKostform.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Nuechtern:
                    _dsNuecht.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Sonstige:
                    _dsSonst.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Suchtmittel:
                    _dsSuchtm.MedizinischeDaten.Clear();
                    break;
                case MedizinischerTyp.Befunde:
                    this._dsBefunde.MedizinischeDaten.Clear();
                    break;
            }

            string where, orderBy;


                where = "MedizinischerTyp=" + ((int)medTyp).ToString();
                orderBy = "Von DESC, Bis DESC";


            dsMedizinischeDaten.MedizinischeDatenRow[] list = (dsMedizinischeDaten.MedizinischeDatenRow[])ALL.MedizinischeDaten.Select(where, orderBy);

            foreach (dsMedizinischeDaten.MedizinischeDatenRow r in list)
            {
                switch (medTyp)
                {
                    case MedizinischerTyp.AktuelleDiagnosen:
                        _dsDiagn.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.DauerDiagnosen:
                        _dsDauerDiagn.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Allergien:
                        _dsAllergien.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Antikoagulation:
                        _dsAntikoa.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Unvertraeglichkeiten:
                        _dsUnvertraeglichkeiten.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Diabetes:
                        _dsDiabetes.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Impfungen:
                        _dsImpfung.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.ImplentateProthesen:
                        _dsImplantate.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Infektionen:
                        _dsInfektion.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.KathederSondenStomata:
                        _dsKatheder.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Kostform:
                        _dsKostform.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Nuechtern:
                        _dsNuecht.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Sonstige:
                        _dsSonst.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Suchtmittel:
                        _dsSuchtm.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                    case MedizinischerTyp.Befunde:
                        this._dsBefunde.MedizinischeDaten.Rows.Add(r.ItemArray);
                        break;
                }
            }
        }

        private void InitKostform()
        {
            Refresh(MedizinischerTyp.Kostform);
        }

        private void InitInfektionen()
        {
            Refresh(MedizinischerTyp.Infektionen);
        }

        private void InitDiabetes()
        {
            Refresh(MedizinischerTyp.Diabetes);
        }

        private void InitAntikoagulation()
        {
            Refresh(MedizinischerTyp.Antikoagulation);
        }

        private void InitAllergien()
        {
            Refresh(MedizinischerTyp.Allergien);
        }

        private void InitUnvertraeglichkeiten()
        {
            Refresh(MedizinischerTyp.Unvertraeglichkeiten);
        }

        private void InitDiagnosen()
        {
            Refresh(MedizinischerTyp.AktuelleDiagnosen);
        }

        private void InitDauerDiagnosen()
        {
            Refresh(MedizinischerTyp.DauerDiagnosen);
        }

        private void InitImplantate()
        {
            Refresh(MedizinischerTyp.ImplentateProthesen);
        }

        private void InitKatheder()
        {
            Refresh(MedizinischerTyp.KathederSondenStomata);
        }

        private void InitImpfung()
        {
            Refresh(MedizinischerTyp.Impfungen);
        }

        private void InitSuchtmittel()
        {
            Refresh(MedizinischerTyp.Suchtmittel);
        }

        private void InitSonstige()
        {
            Refresh(MedizinischerTyp.Sonstige);
        }

        private void InitNuechtern()
        {
            Refresh(MedizinischerTyp.Nuechtern);
        }
        private void InitBefunde()
        {
            Refresh(MedizinischerTyp.Befunde);
        }

        public dsMedizinischeDaten.MedizinischeDatenRow GetMedDatenRow(Guid idMedDaten)
        {
            dsMedizinischeDaten.MedizinischeDatenRow row = null;

            foreach (dsMedizinischeDaten.MedizinischeDatenRow r in ALL.MedizinischeDaten)
            {
                if (r.RowState != DataRowState.Deleted && r.ID == idMedDaten)
                {
                    row = r;
                    break;
                }
            }

            return row;
        }
    }
}
