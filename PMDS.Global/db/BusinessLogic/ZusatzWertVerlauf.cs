using System;

using PMDS.DB;
using PMDS.Global;
using System.Data;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{

    
	public class ZusatzWertVerlauf
	{
		private DBPrintZusatzwert	_db = new DBPrintZusatzwert();



		public ZusatzWertVerlauf()
		{
		}

		// Liefert die Zusatzwerte für einen einzelnen Aufenthalt hier aber nur diejenigen
		// Einträge welche Zahlentechnisch verarbeitbar sind. Der älteste wird zuerst geliefert
        public dsZusatzVerlauf.ZusatzWertDataTable ReadVerlauf(Guid IDAufenthalt, string IDZusatzeintrag, DateTime From, DateTime to) 
		{
            return _db.ReadVerlauf(IDAufenthalt, IDZusatzeintrag, From, to);
		}

		// Wert Spalte so aufbereiten dass entweder der Zahlenwert , der Listenwert oder der eigentliche Text drinnensteht
		private void CorrectWert(dsZusatzVerlaufAll.ZusatzWertDataTable dt)
		{
			foreach(dsZusatzVerlaufAll.ZusatzWertRow r in dt) 
			{
				string sWert = r.IsWertNull() ? "" : r.Wert;
				switch(r.Typ)
				{
					case (int)ZusatzEintragTyp.INT:
					case (int)ZusatzEintragTyp.FLOAT:
						double dblWert = 0;
						if(r.Typ == (int)ZusatzEintragTyp.FLOAT)
                            dblWert = Math.Round(r.ZahlenWert, 2, MidpointRounding.AwayFromZero);
						else
                            dblWert = Math.Round(r.ZahlenWert, 0, MidpointRounding.AwayFromZero);
						sWert = r.ZahlenWert == -1 ? "" : dblWert.ToString();
						if(!r.IsListenEintraegeNull() && r.ListenEintraege.Length > 0 && r.ZahlenWert > -1) 
						{
							string[] sa = r.ListenEintraege.Split('\n');
							if(r.ZahlenWert < sa.Length)
								sWert = sa[(int)r.ZahlenWert];
						}
						break;
				}
				r.Wert = sWert;
			}
		}

	}
}
