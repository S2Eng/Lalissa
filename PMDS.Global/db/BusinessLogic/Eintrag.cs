using System;
using PMDS.DB;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;


namespace PMDS.BusinessLogic
{


	public class Eintrag
	{

		public Eintrag()
		{
			
		}


		public static string GetText(Guid IDEintrag) 
		{
			return DBEintrag.GetText(IDEintrag);
		}


        public dsEintrag.EintragDataTable Read(Guid IDEintrag)
        {
            return new DBEintrag().Read(IDEintrag);
        }

	}
}
