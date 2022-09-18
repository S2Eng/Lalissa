using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Infragistics.Win.UltraWinGrid;
using qs2.core.vb;
using qs2.ui.pint;




namespace qs2.ui.print
{



    public class infoReport
    {
        
        public string Application = "";
        public string Participant = "";

        public dsAdmin.tblSelListEntriesRow rSelListReport;
        //public System.Collections.Generic.List<qs2.core.print.dsQryAuto> listDatabasesxyxy = new System.Collections.Generic.List<qs2.core.print.dsQryAuto>();

        public qs2.sitemap.workflowAssist.contListAssistentElem reportButt = null;

        public void newRun()
        {
            try
            {
                //this.listDatabases = new System.Collections.Generic.List<qs2.core.print.dsQryAuto>();
            }
            catch (Exception ex)
            {
                throw new Exception("infoReport.newRun:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

    }

}
