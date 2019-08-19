using System;
using Infragistics.Win.UltraWinGrid;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;

namespace PMDS.GUI
{
	/// <summary>
	/// Summary description for StaticClasses.
	/// </summary>
	public class SF
	{
		public SF()
		{
		}

		public static bool IsTerminRueckgemeldet(Guid IDAufenthalt, Guid IDPflegePlan) 
		{
            PMDS.BusinessLogic.PflegePlan pp = new PMDS.BusinessLogic.PflegePlan(IDAufenthalt);
			dsPflegePlan.PflegePlanRow r = pp.GetRowByID(IDPflegePlan);			
			if(!r.IsLetztesDatumNull())
				return true;
			else
				return false;
		}

		
	}
}
