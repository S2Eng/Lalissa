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


    public class KaplanMeier
    {



        public runAddIn.cReturnAddInReport run(runAddIn.eTypReportAddIn typReport, ref System.Collections.Generic.List<DataSet> arrFromQueries,
                                qs2.core.license.doLicense.eApp Application)
        {
            qs2.core.vb.dsStaysQTH dsStaysQTH1 = new qs2.core.vb.dsStaysQTH();
            qs2.core.vb.sqlStaysQTH sqlStaysQTH1 = new qs2.core.vb.sqlStaysQTH();

            runAddIn.cReturnAddInReport ret = new runAddIn.cReturnAddInReport();

            if (typReport == runAddIn.eTypReportAddIn.KaplanMeier && Application == core.license.doLicense.eApp.VASCULAR)
            {
            }

            dsStaysQTH1.Clear();

            System.Guid MyIDStay = new System.Guid();
            //sqlStaysQTH1.getStays(this.dsStaysQTH1, MyIDStay);  --> Hannes erweiterung für Sql Parametrisierungen

            dsObjects dsObjectsPatients = new dsObjects();
            sqlObjects sqlObjectsRead = new sqlObjects();
            sqlObjectsRead.initControl();
            sqlObjectsRead.getObject(-99, ref dsObjectsPatients, sqlObjects.eTypSelObj.AllUser, sqlObjects.eTypObj.IsPatient);

            foreach (DataSet dsQuery in arrFromQueries)
            {
                // dsQuery aus jeder abgefeuerten Query
            }

            foreach (dsStaysQTH.tblStay_QTH_01Row rStay_QTH_01 in dsStaysQTH1.tblStay_QTH_01)
            {
                // datenaufbereitung
                if (rStay_QTH_01.fldDIS_ICUStay == 0)
                {
                    dsResult.KaplanMeierRow rKaplanMeier = (dsResult.KaplanMeierRow)ret.dsResult.KaplanMeier.Rows[0];
                }

            }

            return ret;
        }


    }


}
