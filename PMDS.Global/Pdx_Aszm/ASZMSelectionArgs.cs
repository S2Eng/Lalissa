using System;
using System.Collections.Generic;



namespace PMDS.Global
{


    public class ASZMSelectionArgs : ICloneable
    {
        public bool IsNew = false;
        public System.Guid IDUI = System.Guid.NewGuid();
        public bool IsEditedFromuser = false;
        public DateTime IsEditedFromUserTime = DateTime.Now;
        public bool HasDoubledEintrag = false;
        public bool IsLastEditDouble = false;
        public System.Collections.Generic.List<PMDS.DB.PMDSBusiness.cASZM> lstASZMDoubled = new List<DB.PMDSBusiness.cASZM>();
        
        private Guid _IDEintrag;
        private EintragGruppe _EintragGruppe;
        private String _Warnhinweis;
        private String _Text;
        private Guid _IDAbteilung;
        private Int32 _Intervall;
        private Int32 _WochenTage;
        private Int32 _IntervallTyp;
        private Int32 _EvalTage;
        private Guid _IDBerufsstand;
        private Boolean _ParalellJN;
        private Int32 _Dauer;
        private Boolean _LokalisierungJN;
        private Boolean _EinmaligJN;
        private Guid _IDPDXEintrag;
        private Guid _IDPDX = Guid.Empty;
        private String _Sicht;
        private String _Klartext;
        private DateTime _StartDatum = new DateTime(1900, 1, 1);
        private String _Lokalisierung;
        private String _LokalisierungSeite;
        private bool _bPDx = false;
        private bool _RMOptionalJN = false;
        private Guid _IDADependet = Guid.Empty;		            // ist belegt wenn dieser Eintrag von einer Ätiologie abhängig ist.
        private DateTime[] _aUntertaegig;					            // ist belegt wenn n Maßnahmen zu diesem Startdatum erzeugt werden sollen
        private bool _bUntertaegigBenutzerdefiniert;             // Ist true wenn die untertägige Maßnahme eine Benutzerdefineirte Eingabe erfordert
        private Guid _IDUntertaegigGruppe;			            // Eine ID für die in einem Rutsch erzeugten Untertägigen Maßnahmen
        private bool _SpenderAbgabeJN = false;		            // Ob es sich um eine Spenderabgabe handelt oder nicht
        private Guid _IDLinkDokument;                            // Das LinkDokument
        private DateTime _EvalStartDatum = new DateTime(1900, 1, 1);   // Das Evaluierungsstartdatum
        private string _EvalBemerkung = "";
        private string _Anmerkung = "";
        private string _resourceklient = ""; //Neu nach 11.05.2007 MDA

        //Neu nach 01.04.2008 MDA
        private string[] _aAnmerkung; // ist belegt wenn n Maßnahmen zu diesem Startdatum erzeugt werden sollen
        private bool _ErledigtJN = false;
        private Guid _IDAufenthaltPDX = Guid.Empty;
        private Guid _IDPflegePlan = Guid.Empty;

        //Neu nach 26.06.2008 MDA
        private bool _OhneZeitBezug = false;
        private Guid _IDZeitbereich = Guid.Empty;
        private DateTime _ZuErledigenBis = new DateTime(1900, 1, 1);
        private Guid[] _Zeitbereich;

        //Neu nach 12.09.2008 MDA
        private bool _WundeJN = false;
        private int _EintragFlag;

        public ASZMSelectionArgs()
        {

        }



        /// <summary>
        /// Guid.Empty wenn kein Dokument sonst ID des Dokumentes
        /// </summary>
        public Guid IDLinkDokument
        {
            get { return _IDLinkDokument; }
            set { _IDLinkDokument = value; }
        }


        /// <summary>
        /// Ist nicht Guid.Empty wenn es sich um eine von einer Ätiologie abhängigen Maßnahme handelt
        /// </summary>
        public Guid IDADependet
        {
            get
            {
                return _IDADependet;
            }
            set
            {
                _IDADependet = value;
            }
        }

        /// <summary>
        /// Eine ID für die in einem Rutsch erzeugten Untertägigen Maßnahmen
        /// </summary>
        public Guid IDUntertaegigGruppe
        {
            get
            {
                return _IDUntertaegigGruppe;
            }
            set
            {
                _IDUntertaegigGruppe = value;
            }
        }


        /// <summary>
        /// Ist belegt wenn die Maßnahme n-mal am Tag angelegt werden soll sonst null
        /// </summary>
        public DateTime[] UNTERTAEGIG
        {
            get
            {
                return _aUntertaegig;
            }
            set
            {
                _aUntertaegig = value;
            }
        }

        /// <summary>
        ///  Ist true wenn die untertägige Maßnahme eine Benutzerdefineirte Eingabe erfordert
        /// </summary>
        public bool UntertaegigBenutzerdefiniertJN
        {
            get
            {
                return _bUntertaegigBenutzerdefiniert;
            }
            set
            {
                _bUntertaegigBenutzerdefiniert = value;
            }
        }

        /// <summary>
        ///  Ist true wenn es sich um eine Maßnahme handelt welche für die Spendervorbereitung genutzt wird
        /// </summary>
        public bool SpenderAbgabgeJN
        {
            get
            {
                return _SpenderAbgabeJN;
            }
            set
            {
                _SpenderAbgabeJN = value;
            }
        }

        public bool RMOptionalJN
        {
            get
            {
                return _RMOptionalJN;
            }
            set
            {
                _RMOptionalJN = value;
            }
        }

        public bool ISPDX
        {
            get
            {
                return _bPDx;
            }
            set
            {
                _bPDx = value;
            }
        }

        public Guid IDEintrag
        {
            get
            {
                return _IDEintrag;
            }
            set
            {
                _IDEintrag = value;
            }
        }
        public EintragGruppe EintragGruppe
        {
            get
            {
                return _EintragGruppe;
            }
            set
            {
                _EintragGruppe = value;
            }
        }
        public String Warnhinweis
        {
            get
            {
                return _Warnhinweis;
            }
            set
            {
                _Warnhinweis = value;
            }
        }
        public String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }
        public Guid IDAbteilung
        {
            get
            {
                return _IDAbteilung;
            }
            set
            {
                _IDAbteilung = value;
            }
        }
        public Int32 Intervall
        {
            get
            {
                return _Intervall;
            }
            set
            {
                _Intervall = value;
            }
        }
        public Int32 WochenTage
        {
            get
            {
                return _WochenTage;
            }
            set
            {
                _WochenTage = value;
            }
        }
        public Int32 IntervallTyp
        {
            get
            {
                return _IntervallTyp;
            }
            set
            {
                _IntervallTyp = value;
            }
        }
        public Int32 EvalTage
        {
            get
            {
                return _EvalTage;
            }
            set
            {
                _EvalTage = value;
            }
        }
        public Guid IDBerufsstand
        {
            get
            {
                return _IDBerufsstand;
            }
            set
            {
                _IDBerufsstand = value;
            }
        }
        public Boolean ParalellJN
        {
            get
            {
                return _ParalellJN;
            }
            set
            {
                _ParalellJN = value;
            }
        }
        public Int32 Dauer
        {
            get
            {
                return _Dauer;
            }
            set
            {
                _Dauer = value;
            }
        }
        public Boolean LokalisierungJN
        {
            get
            {
                return _LokalisierungJN;
            }
            set
            {
                _LokalisierungJN = value;
            }
        }
        public Boolean EinmaligJN
        {
            get
            {
                return _EinmaligJN;
            }
            set
            {
                _EinmaligJN = value;
            }
        }
        public Guid IDPDXEintrag
        {
            get
            {
                return _IDPDXEintrag;
            }
            set
            {
                _IDPDXEintrag = value;
            }
        }
        public Guid IDPDX
        {
            get
            {
                return _IDPDX;
            }
            set
            {
                _IDPDX = value;
            }
        }
        public String Sicht
        {
            get
            {
                return _Sicht;
            }
            set
            {
                _Sicht = value;
            }
        }
        public String Klartext
        {
            get
            {
                return _Klartext;
            }
            set
            {
                _Klartext = value;
            }
        }
        public DateTime StartDatum
        {
            get
            {
                return _StartDatum;
            }
            set
            {
                _StartDatum = value;
            }
        }
        public String Lokalisierung
        {
            get
            {
                return _Lokalisierung;
            }
            set
            {
                _Lokalisierung = value;
            }
        }
        public String LokalisierungSeite
        {
            get
            {
                return _LokalisierungSeite;
            }
            set
            {
                _LokalisierungSeite = value;
            }
        }

        public DateTime EvalStartDatum
        {
            get
            {
                return _EvalStartDatum;
            }
            set
            {
                _EvalStartDatum = value;
            }
        }

        public string EvalBemerkung
        {
            get { return _EvalBemerkung; }
            set { _EvalBemerkung = value; }
        }

        public string Anmerkung
        {
            get { return _Anmerkung; }
            set { _Anmerkung = value; }
        }

        //Neu nach 11.05.2007 MDA
        public String Resourceklient
        {
            get { return _resourceklient; }
            set { _resourceklient = value; }
        }

        //Neu nach 01.04.2008 MDA
        /// <summary>
        /// Ist belegt wenn die Maßnahme n-mal am Tag angelegt werden soll sonst null
        /// </summary>
        public String[] ANMERKUNG
        {
            get { return _aAnmerkung; }
            set { _aAnmerkung = value; }
        }

        public bool ErledigtJN
        {
            get
            {
                return _ErledigtJN;
            }
            set
            {
                _ErledigtJN = value;
            }
        }

        public Guid IDAufenthaltPDX
        {
            get
            {
                return _IDAufenthaltPDX;
            }
            set
            {
                _IDAufenthaltPDX = value;
            }
        }

        public Guid IDPflegePlan
        {
            get
            {
                return _IDPflegePlan;
            }
            set
            {
                _IDPflegePlan = value;
            }
        }

        public bool OhneZeitBezug
        {
            get
            {
                return _OhneZeitBezug;
            }
            set
            {
                _OhneZeitBezug = value;
            }
        }

        public Guid IDZeitbereich
        {
            get
            {
                return _IDZeitbereich;
            }
            set
            {
                _IDZeitbereich = value;
            }
        }

        public DateTime ZuErledigenBis
        {
            get
            {
                return _ZuErledigenBis;
            }
            set
            {
                _ZuErledigenBis = value;
            }
        }

        /// <summary>
        /// Ist belegt wenn die Maßnahme n-mal am Tag angelegt werden soll sonst null
        /// </summary>
        public Guid[] ZEITBEREICH
        {
            get
            {
                return _Zeitbereich;
            }
            set
            {
                _Zeitbereich = value;
            }
        }

        //Neu nach 12.09.2008 MDA
        public bool WundeJN
        {
            get { return _WundeJN; }
            set { _WundeJN = value; }
        }
        public int EintragFlag
        {
            get { return _EintragFlag; }
            set { _EintragFlag = value; }
        }



        #region ICloneable Member

        public ASZMSelectionArgs CloneByType()
        {
            ASZMSelectionArgs arg = new ASZMSelectionArgs();
            arg._aUntertaegig = _aUntertaegig == null ? null : (DateTime[])_aUntertaegig.Clone();
            arg._bPDx = _bPDx;
            arg._bUntertaegigBenutzerdefiniert = _bUntertaegigBenutzerdefiniert;
            arg._Dauer = _Dauer;
            arg._EinmaligJN = _EinmaligJN;
            arg._EintragGruppe = _EintragGruppe;
            arg._EvalStartDatum = _EvalStartDatum;
            arg._EvalBemerkung = _EvalBemerkung;
            arg._EvalTage = _EvalTage;
            arg._IDAbteilung = _IDAbteilung;
            arg._IDADependet = _IDADependet;
            arg._IDBerufsstand = _IDBerufsstand;
            arg._IDEintrag = _IDEintrag;
            arg._IDLinkDokument = _IDLinkDokument;
            arg._IDPDX = _IDPDX;
            arg._IDPDXEintrag = _IDPDXEintrag;
            arg._IDUntertaegigGruppe = _IDUntertaegigGruppe;
            arg._Intervall = _Intervall;
            arg._IntervallTyp = _IntervallTyp;
            arg._Klartext = _Klartext;
            arg._Lokalisierung = _Lokalisierung;
            arg._LokalisierungJN = _LokalisierungJN;
            arg._LokalisierungSeite = _LokalisierungSeite;
            arg._ParalellJN = _ParalellJN;
            arg._RMOptionalJN = _RMOptionalJN;
            arg._Sicht = _Sicht;
            arg._SpenderAbgabeJN = _SpenderAbgabeJN;
            arg._StartDatum = _StartDatum;
            arg._Text = _Text;
            arg._Warnhinweis = _Warnhinweis;
            arg._WochenTage = _WochenTage;
            arg._EvalBemerkung = _EvalBemerkung;
            arg._Anmerkung = _Anmerkung;
            arg._resourceklient = _resourceklient;

            //Neu nach 01.04.2008 MDA
            arg._aAnmerkung = _aAnmerkung;
            arg._ErledigtJN = _ErledigtJN;
            arg._IDAufenthaltPDX = _IDAufenthaltPDX;
            arg._IDPflegePlan = _IDPflegePlan;
            arg._OhneZeitBezug = _OhneZeitBezug;
            arg._IDZeitbereich = _IDZeitbereich;
            arg._ZuErledigenBis = _ZuErledigenBis;
            arg._Zeitbereich = _Zeitbereich == null ? null : (Guid[])_Zeitbereich.Clone();
            arg._WundeJN = _WundeJN;
            arg.EintragFlag = _EintragFlag;
            return arg;
        }

        public object Clone()
        {
            return CloneByType();
        }

        #endregion

        //Neu nach 28.08.2008 MDA
        /// <summary>
        /// Liste nach Text sortieren
        /// </summary>
        public static void Sort(List<ASZMSelectionArgs> list)
        {
            list.Sort(new ASZMSelectionArgsComparer());
        }
        /// <summary>
        /// Wird benötigt zur Sortierung von Listen der Typ ASZMSelectionArgs
        /// Sortierung nach Text
        /// </summary>
        private class ASZMSelectionArgsComparer : IComparer<ASZMSelectionArgs>
        {
            public int Compare(ASZMSelectionArgs arg1, ASZMSelectionArgs arg2)
            {
                return arg1.Text.CompareTo(arg2.Text);
            }
        }

    }
}
