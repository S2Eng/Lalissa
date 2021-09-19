/// Erstellt von mda
using System;
using System.Collections.Generic;
using System.Text;


namespace PMDS.Global
{

    public class PDxSelectionArgs
    {

        private Guid _IDPDX = Guid.Empty;
        private String _Klartext;
        private int _PDXGruppe;
        private String _Text;
        private DateTime _StartDatum = new DateTime(1900, 1, 1);
        private Boolean _LokalisierungJN;
        private String _Lokalisierung;
        private String _LokalisierungSeite;
        private DateTime _EvalStartDatum = new DateTime(1900, 1, 1);   // Das Evaluierungsstartdatum
        private PDxLokalisierungsTypen _lokalisierungsTyp;
        private ASZMSelectionArgs[] _args;
        private bool _pdx_EntferntJN;
        string _code = "";
        private string _resourceklient = "";
        private Guid _IDAufenthaltPDX = Guid.Empty;
        private bool _ErledigtJN;
        private bool _WundeJN;
        public bool IsEditedFromuser { get; set; }

        
        public PDxSelectionArgs()
        {

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

        //Neu nach 23.04.2008 MDA
        public Guid IDAufenthaltPDX
        {
            get { return _IDAufenthaltPDX; }
            set { _IDAufenthaltPDX = value; }
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

        public int PDXGruppe
        {
            get
            {
                return _PDXGruppe;
            }
            set
            {
                _PDXGruppe = value;
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

        public PDxLokalisierungsTypen LokalisierungsTyp
        {
            get { return _lokalisierungsTyp; }
            set { _lokalisierungsTyp = value; }

        }

        public ASZMSelectionArgs[] ARGS
        {
            get{return _args;}
            set{_args = value;}
        }

        //Neu nach 10.05.2007 MDA
        public String Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public String Resourceklient
        {
            get{return _resourceklient;}
            set{_resourceklient = value;}
        }

        //Neu nach 12.09.2008 MDA
        public bool WundeJN
        {
            get { return _WundeJN; }
            set { _WundeJN = value; }
        }

        public bool pdx_EntferntJN
        {
            get { return _pdx_EntferntJN; }
            set { _pdx_EntferntJN = value; }
        }


        #region ICloneable Member

        public PDxSelectionArgs CloneByType()
        {
            PDxSelectionArgs arg = new PDxSelectionArgs
            {
                _IDPDX = _IDPDX,
                _Klartext = _Klartext,
                _Text = _Text,
                _PDXGruppe = _PDXGruppe,
                _StartDatum = _StartDatum,
                _LokalisierungJN = _LokalisierungJN,
                _Lokalisierung = _Lokalisierung,
                _LokalisierungSeite = _LokalisierungSeite,
                _EvalStartDatum = _EvalStartDatum,
                _lokalisierungsTyp = _lokalisierungsTyp,
                _code = _code,
                _resourceklient = _resourceklient,
                _IDAufenthaltPDX = _IDAufenthaltPDX,
                _ErledigtJN = _ErledigtJN,
                _WundeJN = _WundeJN
            };

            List<ASZMSelectionArgs> list = new List<ASZMSelectionArgs>();
            ASZMSelectionArgs a;

            if (_args != null)
            {
                foreach (ASZMSelectionArgs sa in _args)
                {
                    a = (ASZMSelectionArgs)sa.Clone();
                    list.Add(a);
                }
            }
            arg._args = list.ToArray();

            return arg;
        }

        public object Clone()
        {
            return CloneByType();
        }

        #endregion

    }
}
