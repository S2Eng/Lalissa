using System;
using System.Collections.Generic;
namespace PMDS.Global
{
	public class PDxLokalisiert
	{
		public Guid		_IDAufenthaltPDx		= Guid.Empty;
		public Guid		_IDPDx					= Guid.Empty;
		public string	_Lokalisierung			= "";
		public string	_LokalisierungSeite		= "";

		public PDxLokalisiert(){}
	}

	public class ASZMLokalisiert
	{
		public Guid		_IDEintrag			= Guid.Empty;
		public string	_Lokalisierung		= "";
		public string	_LokalisierungSeite	= "";
		public Guid		_IDPflegePlanPDx	= Guid.Empty;
		public Guid		_IDPflegePlan		= Guid.Empty;
		public bool		_bCanPPFinished		= false;
		public Guid		_IDPDx				= Guid.Empty;
		public string	_Text				= "";
		public string	_Gruppe				= "";
		public string	_PDXText			= "";
		public Guid		_IDUntertaegigGruppe = Guid.Empty;

		public ASZMLokalisiert(Guid IDEintrag, string sLokalisierung, string sLokalisierungSeite, Guid IDPflegePlanPDx, bool bCanPPFinished, Guid IDPflegePlan, Guid IDPDx, string PDXText)
		{
			_IDEintrag			= IDEintrag;
			_Lokalisierung		= sLokalisierung;
			_LokalisierungSeite = sLokalisierungSeite;
			_IDPflegePlanPDx	= IDPflegePlanPDx;
			_IDPflegePlan		= IDPflegePlan;
			_bCanPPFinished		= bCanPPFinished;
			_IDPDx				= IDPDx;
			_PDXText			= PDXText;

		}

		public override string ToString()
		{
			return _Gruppe + " - " + _Text + " (" + _PDXText + " " + _Lokalisierung + " " + _LokalisierungSeite + ")";
		}

	}


	public class PDXDef
	{
		private Guid      			    _ID;
		private String    			    _Klartext;
		private String    			    _Code;
		private Int32     			    _ThematischeID;
		private Boolean   			    _EntferntJN;
		private String    			    _Definition;
		private object    			    _Tag;
		private bool      			    _Changed;
        private PDXGruppe               _PDXGruppe              = PDXGruppe.Pflegediagnose;
        private PDxLokalisierungsTypen  _PDXLokalisierungsTyp   = PDxLokalisierungsTypen.Kann;

        //MDA am 13.04.2007
        //Liste alle zugeordnete Pflegemodelle
        private List<PDXPflegemodellDef> _PDXPflegemodelle              = new List<PDXPflegemodellDef>();
        
        //Neu nach 15.09.2008 MDA
        private bool _WundeJN = false;
        private string _PDXKuerzel;  //Gernot%%

		public PDXDef()
		{
		}

        public PDxLokalisierungsTypen PDXLokalisierungsTyp
        {
            get { return _PDXLokalisierungsTyp; }
            set { _PDXLokalisierungsTyp = value; }
        }

        public PDXGruppe PDXGruppe
        {
            get { return _PDXGruppe; }
            set { _PDXGruppe = value; }
        }



		public Guid ID
		{
			get
			{
				return _ID;
			}
			set
			{
				_ID = value;
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
		public String Code
		{
			get
			{
				return _Code;
			}
			set
			{
				_Code = value;
			}
		}
		public Int32 ThematischeID
		{
			get
			{
				return _ThematischeID;
			}
			set
			{
				_ThematischeID = value;
			}
		}
		public Boolean EntferntJN
		{
			get
			{
				return _EntferntJN;
			}
			set
			{
				_EntferntJN = value;
			}
		}
		public String Definition
		{
			get
			{
				return _Definition;
			}
			set
			{
				_Definition = value;
			}
		}
		public object Tag
		{
			get
			{
				return _Tag;
			}
			set
			{
				_Tag = value;
			}
		}
		public bool Changed
		{
			get
			{
				return _Changed;
			}
			set
			{
				_Changed = value;
			}
		}

        public List<PDXPflegemodellDef> PDXPflegemodelle
        {
            get { return _PDXPflegemodelle; }
            set { _PDXPflegemodelle = value; }
        }

        //Neu nach 15.09.2008 MDA
        public bool WundeJN
        {
            get
            {
                return _WundeJN;
            }
            set
            {
                _WundeJN = value;
            }
        }

        public string PDXKuerzel   //Gernot%%
        {
            get
            {
                return _PDXKuerzel;
            }
            set
            {
                _PDXKuerzel = value;
            }
        }     
	}
}
