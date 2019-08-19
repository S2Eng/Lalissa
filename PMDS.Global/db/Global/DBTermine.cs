using System;
using System.Data;
using System.Data.OleDb;
using System.Text;

using PMDS.Global;
using PMDS.Data.Global;
using RBU;
using PMDS.Global.db.Global;
using PMDS.db.Entities;





namespace PMDS.DB
{

    public enum eTypeGenerate
    {
        Grid = 0,
        FromTo = 1


    }

	public class DBTerminePara
	{
		public	DateTime	From		=  DateTime.MinValue;
		public	DateTime	To			= DateTime.MaxValue;
        
		public	Guid		IDKlinik	= Guid.Empty;
		public	Guid		IDAbteilung	= Guid.Empty;
		public	Guid		IDBereich	= Guid.Empty;
		public	Guid		IDAufenthalt= Guid.Empty;

        public bool         OnlyIDPflegePlan = false;
		public	Guid		IDPflegePlan= Guid.Empty;

        public bool         BezugJN = false;
        public Guid         IDBezug = Guid.Empty;

        public Guid[]       aIDMa�nahme = { };
		public	Guid		IDMa�nahme	= Guid.Empty;

        public bool BerufsstandJN = false;
        public System.Collections.Generic.List<Guid> Berufsstand = new System.Collections.Generic.List<Guid>();

        public bool WichtigF�rJN = false;
        public System.Collections.Generic.List<Guid> WichtigF�r = new System.Collections.Generic.List<Guid>();

        public bool ShowOhneZeitbezugOhneUI = true;
        public bool Show�berf�llige = true;

        public TerminlisteAnsichtsmodi ansicht = TerminlisteAnsichtsmodi.none;

        public int ShowCC = -1;
        public int Abzeichnen = -1;

        public bool ZeitbezugJN = false;
        public System.Collections.Generic.List<int> Zeitbezug = new System.Collections.Generic.List<int>();

        public bool PlanungsEintr�geJN = false;
        public System.Collections.Generic.List<int> PlanungsEintr�ge = new System.Collections.Generic.List<int>();

        public bool ZusatzwerteJN = false;
        public System.Collections.Generic.List<string> Zusatzwerte = new System.Collections.Generic.List<string>();

        public bool HerkunftPlanungsEintragJN = false;
        public System.Collections.Generic.List<int> HerkunftPlanungsEintrag = new System.Collections.Generic.List<int>();

	}

}
