using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using qs2.core;
using qs2.core.vb;
using qs2.design.auto.print.KaplanMeier;




namespace qs2.AddIn.Report.db
{


    public class runAddIn
    {
    
        public enum eTypReportAddIn
        {
            KaplanMeier = 0,

        }
        public class cReturnAddInReport
        {
            public dsResult dsResult = new dsResult();
            public System.Drawing.Color foreColorChart = System.Drawing.Color.Red;   // -> spez. Oberfläche aus Business-Logic

        }




        public cReturnAddInReport run(eTypReportAddIn typReport, ref System.Collections.Generic.List<DataSet> arrFromQueries,
                                        qs2.core.license.doLicense.eApp Application)
        {
            try
            {
                cReturnAddInReport ret = new cReturnAddInReport();
                if (typReport == eTypReportAddIn.KaplanMeier && Application == core.license.doLicense.eApp.VASCULAR)
                {
                    KaplanMeier KaplanMeier1 = new KaplanMeier();
                    KaplanMeier1.run(typReport, ref arrFromQueries, Application);
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("runAddIn.run: " + "\r\n" + ex.ToString());
            }
        }



    }


}
