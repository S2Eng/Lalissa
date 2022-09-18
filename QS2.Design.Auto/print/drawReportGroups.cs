using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using qs2.core.vb;






namespace qs2.ui
{


    public class drawReportGroups
    {




        public void loadButtonDataReports(qs2.sitemap.workflowAssist.contListAssistentElem contReportButt,
                                dsAdmin.tblSelListEntriesRow rSelListEntryFound, string Application)
        {
            try
            {
                dsAdmin dsAdmin1 = new dsAdmin();
                sqlAdmin sqlAdmin1 = new sqlAdmin();
                dsAdmin1 = new dsAdmin();
                sqlAdmin1 = new sqlAdmin();
                sqlAdmin1.initControl();

                qs2.ui.pint.contQryRun.tgReportButton tgButt = (qs2.ui.pint.contQryRun.tgReportButton)contReportButt.Tag;

                tgButt.rSelListsQry.Clear();
                tgButt.rSelListObjs.Clear();
                tgButt.rSelListsReports = rSelListEntryFound;
                
                dsAdmin1.tblSelListEntriesObj.Clear();
                sqlAdmin1.getSelListEntrysObj(rSelListEntryFound.ID, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "Queries", dsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.sellist, Application);
                foreach (dsAdmin.tblSelListEntriesObjRow rObjQry in dsAdmin1.tblSelListEntriesObj)
                {
                    dsAdmin.tblSelListEntriesRow rSelListEntryQueryFound = sqlAdmin1.getSelListEntrysRow("", sqlAdmin.eTypAuswahlList.id, qs2.core.license.doLicense.eApp.ALL.ToString(), Application, "", 0, "", rObjQry.IDSelListEntry);
                    tgButt.rSelListsQry.Add(rSelListEntryQueryFound);
                    //tgButt.rSelListGroups.Add(rSelListGroup);
                    tgButt.rSelListObjs.Add(rObjQry);
                    
                    //qs2.core.Enums.eTypSubReport typSubreport = core.Enums.eTypSubReport.MainReport;
                    //if (!rObjQry.IDClassification.Trim().Equals(""))
                    //    typSubreport = qs2.core.generic.searchEnumTypSubReport(rObjQry.IDClassification);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("drawReportGroups.loadButtonDataReports:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void getQryObjForReport(ref qs2.ui.print.infoQry infoQry1, ref qs2.ui.pint.contQryRun.tgReportButton tgButt)
        {
            try
            {
                //if (infoQry1.rSelListQry == null)
                //    return;

                int objEntriesFound = 0;
                //foreach (dsAdmin.tblSelListEntriesObjRow rObjQry in tgButt.rSelListObjs)
                //{
                //    if (infoQry1.rSelListQry != null)
                //    {
                //        if (infoQry1.rSelListQry.ID.Equals(rObjQry.IDSelListEntry))
                //        {
                //            objEntriesFound += 1;

                //        }
                //    }
                //}
                //if (objEntriesFound == 0)
                //    throw new Exception("loadQryRepPar: No rSelListObjRow or more than 1 rSelListObjRow found for infoQryRunParNew.rSelListQry.ID!");

                objEntriesFound = 0;
                foreach (dsAdmin.tblSelListEntriesObjRow rObjQry in tgButt.rSelListObjs)
                {
                    if (infoQry1.rSelListQry != null)
                    {
                        if (infoQry1.rSelListQry.ID.Equals(rObjQry.IDSelListEntry))
                        {
                            objEntriesFound += 1;
                            infoQry1.rSelListQryObj = rObjQry;
                            if (!rObjQry.IDClassification.Trim().Equals(""))
                                infoQry1.typSubreport = qs2.core.generic.searchEnumTypSubReport(rObjQry.IDClassification);

                            return;   //lthxy
                        }  
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("drawReportGroups.getQryObjForReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

    }
}
