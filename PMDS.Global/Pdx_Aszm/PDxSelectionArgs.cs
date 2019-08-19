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
        private String _Text;
        private DateTime _StartDatum = new DateTime(1900, 1, 1);
        private Boolean _LokalisierungJN;
        private String _Lokalisierung;
        private String _LokalisierungSeite;
        private DateTime _EvalStartDatum = new DateTime(1900, 1, 1);   // Das Evaluierungsstartdatum
        private PDxLokalisierungsTypen _lokalisierungsTyp;
        private ASZMSelectionArgs[] _args;
        private bool _pdx_EntferntJN = false;
        //Neu nach 10.05.2007 MDA
        string _code = "";
        private string _resourceklient = "";
        //Neu nach 23.04.2008 MDA
        private Guid _IDAufenthaltPDX = Guid.Empty;
        private bool _ErledigtJN = false;

        public bool IsEditedFromuser = false;

        //Neu nach 12.09.2008 MDA
        private bool _WundeJN = false;
        
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
            PDxSelectionArgs arg = new PDxSelectionArgs();
            arg._IDPDX = _IDPDX;
            arg._Klartext = _Klartext;
            arg._Text = _Text;
            arg._StartDatum = _StartDatum;
            arg._LokalisierungJN = _LokalisierungJN;
            arg._Lokalisierung = _Lokalisierung;
            arg._LokalisierungSeite = _LokalisierungSeite;
            arg._EvalStartDatum = _EvalStartDatum;
            arg._lokalisierungsTyp = _lokalisierungsTyp;
            arg._code = _code;
            arg._resourceklient = _resourceklient; //Neu nach 10.05.2007 MDA
            //Neu nach 23.04.2008 MDA
            arg._IDAufenthaltPDX = _IDAufenthaltPDX;
            arg._ErledigtJN = _ErledigtJN;
            arg._WundeJN = _WundeJN;

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
