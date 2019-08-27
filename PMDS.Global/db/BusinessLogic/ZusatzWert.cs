using System;
using System.Data;
using System.Collections;

using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{


	public class ZusatzWert : BusinessBase
	{
		private DBZusatzWert _db = new DBZusatzWert();
		private ZusatzGruppe _gruppe = new ZusatzGruppe();



		protected override IDBBase DBInterface
		{
			get	{	return (IDBBase)_db;	}
		}


		public static void AllZusatzWerte(IZusatz zusatz, out ZusatzWert zwDefault, out ZusatzWert zwENVAbt)
		{
			Guid idDefault = KlinikAbteilungen.DefaultID();
			Guid idAbteilung = ENV.ABTEILUNG;

			zwDefault	= (ZusatzWert)zusatz.ZusatzWertForAbteilung(idDefault);
			if (idDefault == idAbteilung)
				zwENVAbt = new ZusatzWert();
			else
				zwENVAbt = (ZusatzWert)zusatz.ZusatzWertForAbteilung(idAbteilung);
		}

		public ZusatzWert()
		{
		}

		public ZusatzWert(string gruppe, Guid idAbteilung, Guid idObject)
		{
			_db.Gruppe		= gruppe;
			_db.Abteilung	= idAbteilung;

			Read(idObject);
		}

		public ZusatzWert(string gruppe, Guid idAbteilung, Guid idObject, Guid idFilter)
		{
			_db.Gruppe		= gruppe;
			_db.Abteilung	= idAbteilung;
			_db.Filter		= idFilter;

			Read(idObject);
		}
		public override void Read()
		{
			base.Read();
			_gruppe = new ZusatzGruppe(_db.Gruppe, _db.Filter, _db.Abteilung);			
		}

		public dsZusatzWert.ZusatzWertDataTable ZusatzWerte
		{
			get	{	return _db.ITEM;	}
		}
		public ZusatzWertPara[] ParameterListe()
		{
			ZusatzEintrag ze;
			ZusatzWertPara def;
			ArrayList al = new ArrayList();

			// für alle ZusatzGruppenEinträge einen Eintrag erzeugen
			foreach(dsZusatzGruppeEintrag.ZusatzGruppeEintragRow r in _gruppe.ZusatzEintraege.OrderBy(g => g.Reihenfolge))
			{
                if (r.AktivJN)
                {
                    ze = new ZusatzEintrag(r.IDZusatzEintrag);

                    def = new ZusatzWertPara(r.ID);
                    def.IsOptional = r.OptionalJN;
                    def.IsPrintable = r.DruckenJN;
                    def.Bezeichnung = ze.Bezeichnung;
                    def.Type = (ZusatzEintragTyp)ze.Typ;
                    def.Liste = ze.Liste;
                    def.MinValue = ze.MinValue;
                    def.MaxValue = ze.MaxValue;

                    // Element einhängen
                    al.Add(def);
                }
            }

			return (ZusatzWertPara[])al.ToArray(typeof(ZusatzWertPara));
		}

		public ZusatzWertPara[] PrintableValues()
		{
			ZusatzWertPara[] values = ParameterListe();

			// hashtable erzeugen
			Hashtable index = new Hashtable();
			foreach(ZusatzWertPara para in values)
				index.Add(para.ID, para);

			// Parameter-Liste um darzustellenden Wert korrigieren
			foreach(dsZusatzWert.ZusatzWertRow r in ZusatzWerte)
			{
				ZusatzWertPara para = (ZusatzWertPara)index[r.IDZusatzGruppeEintrag];
				if (para != null)
				{
					switch(para.Type)
					{
						case ZusatzEintragTyp.TEXT:
						case ZusatzEintragTyp.BIG_TEXT:
						case ZusatzEintragTyp.IMAGE:
							para.Value = r.Wert;
							break;

						case ZusatzEintragTyp.INT:
							if (r.ZahlenWert != -1)
							{
								if (r.ZahlenWert < para.Liste.Count)
									para.Value = para.Liste[r.ZahlenWert].TEXT;
								else
									para.Value = r.ZahlenWert.ToString();
							}
							break;

						case ZusatzEintragTyp.FLOAT:
							if (r.ZahlenWertFloat != -1.0)
                                para.Value = Math.Round(r.ZahlenWertFloat, 2, MidpointRounding.AwayFromZero).ToString();
							break;

						default:
							break;
					}
				}
			}

			return values;
		}
	}

	public class ZusatzWertPara
	{

		public ZusatzWertPara(Guid id)
		{
			ID = id;
		}

		public Guid							ID			= Guid.Empty;
		public bool							IsOptional	= true;
		public bool							IsPrintable = true;
		public string						Bezeichnung = "";
		public ZusatzEintragTyp				Type		= ZusatzEintragTyp.TEXT;
		public dsINTListe.INTListeDataTable	Liste		= null;
		public string						Value		= "";
		public double						MinValue	= 0.0;
		public double						MaxValue	= 0.0;
        public Nullable<Guid> IDZusatzwert = null;

    }

}
