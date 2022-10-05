using System;
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
                var dsAdmin1 = new dsAdmin();
                var sqlAdmin1 = new sqlAdmin();
                sqlAdmin1.initControl();

                var tgButt = (qs2.ui.pint.contQryRun.tgReportButton)contReportButt.Tag;

                tgButt.rSelListsQry.Clear();
                tgButt.rSelListObjs.Clear();
                tgButt.rSelListsReports = rSelListEntryFound;
                
                dsAdmin1.tblSelListEntriesObj.Clear();
                sqlAdmin1.getSelListEntrysObj(rSelListEntryFound.ID, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "Queries", dsAdmin1, core.vb.sqlAdmin.eTypAuswahlObj.sellist, Application);
                foreach (var rObjQry in dsAdmin1.tblSelListEntriesObj)
                {
                    var rSelListEntryQueryFound = sqlAdmin1.getSelListEntrysRow("", sqlAdmin.eTypAuswahlList.id, qs2.core.license.doLicense.eApp.ALL.ToString(), Application, "", 0, "", rObjQry.IDSelListEntry);
                    tgButt.rSelListsQry.Add(rSelListEntryQueryFound);
                    tgButt.rSelListObjs.Add(rObjQry);
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
                foreach (var rObjQry in tgButt.rSelListObjs)
                {
                    if (infoQry1.rSelListQry != null)
                    {
                        if (infoQry1.rSelListQry.ID.Equals(rObjQry.IDSelListEntry))
                        {
                            infoQry1.rSelListQryObj = rObjQry;
                            if (!string.IsNullOrWhiteSpace(rObjQry.IDClassification))
                                infoQry1.typSubreport = qs2.core.generic.searchEnumTypSubReport(rObjQry.IDClassification);
                            return; 
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
