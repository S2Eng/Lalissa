//----------------------------------------------------------------------------
/// <summary>
///	GuiAction.cs
/// Erstellt am:	16.11.2004
/// Erstellt von:	EHO
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Text;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;



namespace PMDS.GUI
{


    public static class GuiActionPflegePlan
    {



        //----------------------------------------------------------------------------
        /// <summary>
        /// Drucken des Pflegeplanes PDX orientiert
        /// </summary>
        //----------------------------------------------------------------------------
        public static void PrintPflegePlanPDxOrientated(Guid IDAufenthalt, bool bBeendeteAnzeigen)
        {
            PMDS.Print.ReportManager.PrintPflegePlanPDxOrientated(IDAufenthalt, bBeendeteAnzeigen);
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Berichte
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool BerichteWunde()
        {
            frmDynReports frm = new frmDynReports(ENV.DynReportWundePath);
            frm.Show();
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf der einzelnen Dialoge ohne Parameter
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ActionFromEvent(SiteEvents e)
        {
            return ActionFromEvent(e, new SiteEventArgs());
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf der einzelnen Dialoge 
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ActionFromEvent(SiteEvents e, SiteEventArgs args)
        {
            switch (e)
            {
                
                case SiteEvents.ASZMVerwaltung: return GuiActionPflegePlan.ASZMVerwaltung();            
                

                // TBD nicht verwendete SiteEvents
                default:
                    throw new Exception("Event: " + e.ToString() + " nicht definiert");
                    //break;
            }

            //return false;
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// ASZM Verwaltung
        /// </summary>
        //----------------------------------------------------------------------------
        public static bool ASZMVerwaltung()
        {
            // *** TBD **** Komplette Verwaltung umstricken..... 
            new frmASZM().ShowDialog();
            return true;
        }
        
    }

}
