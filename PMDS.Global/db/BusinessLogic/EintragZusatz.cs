using System;
using PMDS.DB;
using PMDS.Global;
using PMDS.Data.Patient;
using PMDS.Data.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{

	public class EintragZusatz
	{
		private DBEintragZusatz			_DBEintragZusatz;

		public EintragZusatz()
		{
			_DBEintragZusatz = new DBEintragZusatz();
		}

		
		public void Read( Guid IDEintrag)
		{
			_DBEintragZusatz.Read(IDEintrag);
		}


		/// Liest den Zusatzeintrage für alle bestimmte Abteilungen zu dem übergebenen Eintrag
		public dsEintragZusatz.EintragZusatzRow Read(Guid IDEintrag, Guid IDAbteilung)
		{
			return _DBEintragZusatz.Read(IDEintrag, IDAbteilung);
		}

		/// Fügt einen neuen Datensatz mit einer bestimmten Abteilung
		/// der Eintragstabelle hinzu
		public void AddNew(Guid IDAbteilung)
		{
			dsEintragZusatz.EintragZusatzRow r = _DBEintragZusatz.AddNew(IDAbteilung);	
		}
        		
	
		public void Save() 
		{
			_DBEintragZusatz.Write();
		}

		/// Liefert einen Eintragzusatz Datatable mit immer einer enthaltenen Row
		public dsEintragZusatz.EintragZusatzDataTable	EINTRAGZUSATZ
		{
			get 
			{
				return _DBEintragZusatz.ZUSATZEINTRAG;
			}
		}

	}
}
