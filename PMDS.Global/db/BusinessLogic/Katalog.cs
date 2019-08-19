using System;
using PMDS.DB;
using System.Collections.Specialized;
using System.Collections;
using RBU;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;



namespace PMDS.BusinessLogic
{


	public class KatalogCollection : Hashtable 
	{
    
        public KatalogCollection() 
		{
			this.Add('A', new Katalog('A'));
			this.Add('S', new Katalog('S'));
            this.Add('R', new Katalog('R'));
            this.Add('Z', new Katalog('Z'));
			this.Add('M', new Katalog('M'));
		}

		public Katalog this[char chGroup]
		{
			get
			{
				return (Katalog)base[chGroup];
			}
		}

	}

	
	public class Katalog 
	{
		private DBEintrag			_DBEintrag;
		private char				_Group;
		private bool				bReaded = false;
        public bool AlleEinträge = false;



        public Katalog(char Group) 
		{
			_DBEintrag	= new DBEintrag();
			_Group		= Group;

		}

		public void AddNew() 
		{
			_DBEintrag.AddNew();
		}

		public char GROUP
		{
			get 
			{
				return _Group;
			}
		}

		public void Read(bool Alle) 
		{
			_DBEintrag.Read(_Group, Alle);
		}

		public dsEintrag.EintragDataTable ReadQuery(string tbASZMText,string cbSichtText,string tbWarnhinweisText)
		{
			return _DBEintrag.ReadQuery(tbASZMText,cbSichtText,tbWarnhinweisText,_Group);
		}

		public void writeQuery(dsEintrag.EintragDataTable querytable)
		{
			_DBEintrag.writeQuery(querytable);
		}

		public void Clearxy() 
		{
			bReaded = false;
		}

		public void Write() 
		{
			_DBEintrag.Write();
		}

    	public string KatalogTitel 
		{
			get 
			{
				switch(GROUP)
				{
					case 'A':
						return ENV.String("A");
					case 'S':
						return ENV.String("S");
                    case 'R':
                        return ENV.String("R");
                    case 'Z':
						return ENV.String("Z");
					case 'M':
						return ENV.String("M");
					case 'X':
						return ENV.String("X");
				}
				return "Unknown Catalog Type";
			}
		}

        public dsEintrag.EintragDataTable EINTRAEGE
		{
			get 
			{
                if (!bReaded)
                {
                    Read(this.AlleEinträge);
                    bReaded = true;
                }
				return _DBEintrag.EINTRAEGE;
			}
		}

        // Liefert alle Zugeoerdnete Pflegedefinitionen
        public dsPDx.PDXDataTable GetPDxZuordnungen(Guid IDEintrag)
        {
            return _DBEintrag.GetPDxZuordnungen(IDEintrag);
        }

	}

}
