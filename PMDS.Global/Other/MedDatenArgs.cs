using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public class MedDatenArgs
    {
        Guid _id = Guid.Empty;
        int _medTyp;
        DateTime _von;
        DateTime _bis;
        string _beschreibung;
        string _bemerkung;
        string _beendigungsgrund;
        DateTime _letzteVersorgung;
        DateTime _naechsteVersorgung; 
        string _modell;
        string _handling;
        string _therapie;
        string _ICDCode;
        bool _aufnahmeDiagnose;
        bool _antikoaguliert; 
        string _Typ; 
        double _anzahl;
        bool _nuechtern;
        string _groesse;
        public string _lstRezepteinträge = "";
        public int _NumberRezepteinträge = 0;

 

        public MedDatenArgs() {}

        public MedDatenArgs(Guid id, int medTyp, DateTime von, DateTime bis, string beschreibung, string bemerkung,
                       string beendigungsgrund, DateTime letzteVersorgung, DateTime naechsteVersorgung, string modell, string handling,
                       string therapie, string ICDCode, bool aufnahmeDiagnose, bool antikoaguliert, string Typ, double anzahl, bool nuechtern, string groesse, string lstRezepteinträge, int NumberRezepteinträge) 
        {
            _id = id;
            _medTyp = medTyp;
            _von = von;
            _bis = bis;
            _beschreibung = beschreibung;
            _bemerkung = bemerkung;
            _beendigungsgrund = beendigungsgrund;
            _letzteVersorgung = letzteVersorgung;
            _naechsteVersorgung = naechsteVersorgung;
            _modell = modell;
            _handling = handling;
            _therapie = therapie;
            _ICDCode = ICDCode;
            _aufnahmeDiagnose = aufnahmeDiagnose;
            _antikoaguliert = antikoaguliert;
            _Typ = Typ;
            _anzahl = anzahl;
            _nuechtern = nuechtern;
            _groesse = groesse;
            _lstRezepteinträge = lstRezepteinträge;
            _NumberRezepteinträge = NumberRezepteinträge;
        }

        public Guid ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int MedTyp
        {
            get { return _medTyp; }
            set { _medTyp = value; }
        }
        public DateTime Von
        {
            get { return _von; }
            set { _von = value; }
        }

        public DateTime Bis
        {
            get { return _bis; }
            set { _bis = value; }
        }

        public string Beschreibung
        {
            get { return _beschreibung; }
            set { _beschreibung = value; }
        }

        public string Bemerkung
        {
            get { return _bemerkung; }
            set { _bemerkung = value; }
        }

        public string Beendigungsgrund
        {
            get { return _beendigungsgrund; }
            set { _beendigungsgrund = value; }
        }

        public DateTime LetzteVersorgung
        {
            get { return _letzteVersorgung; }
            set { _letzteVersorgung = value; }
        }

        public DateTime NaechsteVersorgung
        {
            get { return _naechsteVersorgung; }
            set { _naechsteVersorgung = value; }
        }

        public string Modell
        {
            get { return _modell; }
            set { _modell = value; }
        }

        public string Handling
        {
            get { return _handling; }
            set { _handling = value; }
        }

        public string Therapie
        {
            get { return _therapie; }
            set { _therapie = value; }
        }

        public string ICDCode
        {
            get { return _ICDCode; }
            set { _ICDCode = value; }
        }

        public bool AufnahmeDiagnoseJN
        {
            get { return _aufnahmeDiagnose; }
            set { _aufnahmeDiagnose = value; }
        }

        public bool AntikoaguliertJN
        {
            get { return _antikoaguliert; }
            set { _antikoaguliert = value; }
        }

        public string Typ
        {
            get { return _Typ; }
            set { _Typ = value; }
        }

        public double Anzahl
        {
            get { return _anzahl; }
            set { _anzahl = value; }
        }

        public bool NuechternJN
        {
            get { return _nuechtern; }
            set { _nuechtern = value; }
        }

        public string Groesse
        {
            get { return _groesse; }
            set { _groesse = value; }
        }
    }
}
