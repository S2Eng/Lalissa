using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using qs2.core.vb;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;
using System.Data;
using System.Globalization;

using System.IO;
using qs2.design.auto.print;
using Infragistics.Documents.Reports.RTF;
using System.Web;

namespace qs2.print
{
    

    public class genReport
    {
        
        public qs2.sitemap.print.genSql genSql1 = new qs2.sitemap.print.genSql();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public qs2.core.generic generic1 = new qs2.core.generic();
        public qs2.design.auto.print.translateQuery translateQuery1 = null;
        private static CultureInfo ci { get; } = new CultureInfo("", false);

        public void initControl()
        {
            try
            {
                this.translateQuery1 = new qs2.design.auto.print.translateQuery();
                genSql1.initControl();
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.initControl:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public string runQueryReport2(bool withParameters, System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                    ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids,
                                    qs2.core.Enums.eTypRunQuery typRunQuery,
                                    qs2.ui.print.infoQry infoQryRunPar,
                                    ref string WhereClauselForSimpleFunctions, bool bExtern, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    bool SqlForAdmin, bool CheckBrackets, ref bool BracketsOK)
        {
            try
            {
                bool noParticipant = this.noParticipant(infoQryRunPar.rSelListQry.Classification.Trim());
                infoQryRunPar.Sql = this.generateSql2(withParameters, lstMultiControl, lstReturnMultiGrids, infoQryRunPar, typRunQuery, false,
                                                        ref WhereClauselForSimpleFunctions, bExtern, ref viewIsFunction, ref lstParForExternFct, ref noParticipant, SqlForAdmin,
                                                        CheckBrackets, ref BracketsOK, ref infoQryRunPar.SqlWhereAdmin);
                return infoQryRunPar.Sql;
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.runQueryReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }

        public string generateSql2(bool withParameters,
                                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl,
                                    System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiGridSelList> lstReturnMultiGrids, 
                                    qs2.ui.print.infoQry infoQryRunPar,
                                    qs2.core.Enums.eTypRunQuery typRunQuery, bool saveResult,
                                    ref string WhereClauselForSimpleFunctions, bool Extern, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    ref bool noParticipant, bool SqlForAdmin, bool CheckBrackets, ref bool BracketsOK, ref string sqlWhereAdminReturn)
        {
            try
            {
                infoQryRunPar.NewDssCopy();
                infoQryRunPar.CopyDSs();
                //doParameterForQuery.addColumnsToTableConditions(infoQryRunPar.dsConditionsUI.tblQueriesDef);
                doParameterForQuery.addColumnsToTableConditions(infoQryRunPar.dsConditionsForQuery.tblQueriesDef);
                doParameterForQuery.addColumnsToTableConditions(infoQryRunPar.dsParFctForQuery.tblQueriesDef);

                if (infoQryRunPar.rSelListQry.IDRessource.Trim().ToLower().EndsWith("vlad"))
                {
                    infoQryRunPar.IsVLAD = true;
                }

                string protokoll = "";
                infoQryRunPar.parametersSql = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();
                doParameterForQuery doParameterForQuery1 = new doParameterForQuery();
                doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, infoQryRunPar.dsConditionsForQuery.tblQueriesDef, false, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), Extern, noParticipant, CheckBrackets, ref BracketsOK);
                bool BracketOKTmp = false;
                doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, infoQryRunPar.dsParFctForQuery.tblQueriesDef, true, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), Extern, noParticipant, false, ref BracketOKTmp);
                doParameterForQuery.addColumnsToTableConditions(infoQryRunPar.dsParFctForQuery.tblQueriesDef);

                if (Extern)
                {
                    doParameterForQuery1.deleteFieldsForExternQuery(lstMultiControl, infoQryRunPar); 
                }

                if (infoQryRunPar.rSelListQry.IDRessource.Trim().ToLower().EndsWith("vlad"))
                {
                    infoQryRunPar.IsVLAD = true;
                }

                System.Collections.Generic.List<qs2.sitemap.print.genSql.subQuery> lstSubQueries = new System.Collections.Generic.List<qs2.sitemap.print.genSql.subQuery>();
                foreach (qs2.ui.print.infoQry InfoQryRunParSub in infoQryRunPar.lstInfoQryRunParSub)
                {
                    qs2.sitemap.print.genSql.subQuery subQuery = new qs2.sitemap.print.genSql.subQuery();
                    InfoQryRunParSub.parametersSql = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();

                    InfoQryRunParSub.NewDssCopy();
                    InfoQryRunParSub.CopyDSs();
                    //doParameterForQuery.addColumnsToTableConditions(InfoQryRunParSub.dsConditionsUI.tblQueriesDef);
                    doParameterForQuery.addColumnsToTableConditions(InfoQryRunParSub.dsConditionsForQuery.tblQueriesDef);
                    doParameterForQuery.addColumnsToTableConditions(InfoQryRunParSub.dsParFctForQuery.tblQueriesDef);

                    bool BracketsOKSub = false;
                    doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, InfoQryRunParSub, InfoQryRunParSub.dsConditionsForQuery.tblQueriesDef, false, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), Extern, noParticipant, CheckBrackets, ref BracketsOKSub);
                    doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, InfoQryRunParSub, InfoQryRunParSub.dsParFctForQuery.tblQueriesDef, true, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), Extern, noParticipant, false, ref BracketOKTmp);
                    infoQryRunPar.SqlWhereInfo += "\r\n" + InfoQryRunParSub.SqlWhereInfo;

                    if (!BracketsOKSub)
                    {
                        BracketsOK = false;
                    }

                    subQuery.rSelListQrySub = InfoQryRunParSub.rSelListQry;
                    subQuery.rSelListQryObjSub = InfoQryRunParSub.rSelListQryObj;
                    subQuery.rSelListReportSub = null;
                    subQuery.rSelListQrySub = InfoQryRunParSub.rSelListQry;
                    subQuery.tQryConditionsSub = InfoQryRunParSub.dsConditionsForQuery.tblQueriesDef;
                    subQuery.tParFunctParSub = InfoQryRunParSub.dsParFctForQuery.tblQueriesDef;

                    lstSubQueries.Add(subQuery);
                }

                qs2.sitemap.print.genSql.cDataSql DataSql = new sitemap.print.genSql.cDataSql();
                string sqlWhereReturn = "";
                System.Collections.Generic.List<qs2.sitemap.print.genSql.sqlFix> lstSqlFix = new System.Collections.Generic.List<qs2.sitemap.print.genSql.sqlFix>();
                infoQryRunPar.Sql = this.genSql1.doSql(infoQryRunPar.dsFieldsForQuery.tblQueriesDef, infoQryRunPar.dsConditionsForQuery.tblQueriesDef,
                                                        infoQryRunPar.dsParFctForQuery.tblQueriesDef, infoQryRunPar.dsInputFieldsForQuery.tblQueriesDef,
                                                        infoQryRunPar.dsJoinsForQuery.tblQueriesDef, ref protokoll, 
                                                        withParameters, infoQryRunPar.parametersSql, ref  lstSubQueries,
                                                        infoQryRunPar.rSelListQry, ref lstSqlFix,
                                                        ref sqlWhereReturn, ref WhereClauselForSimpleFunctions, ref viewIsFunction,
                                                        ref lstParForExternFct, ref Extern, ref infoQryRunPar.sqlForAdmin, ref DataSql, ref sqlWhereAdminReturn);
                infoQryRunPar.SqlWhereFromSql = sqlWhereReturn;
                infoQryRunPar.WhereClauselForSimpleFunctions = WhereClauselForSimpleFunctions;
                if (infoQryRunPar.IsVLAD)
                {
                    this.doVLAD(typRunQuery, infoQryRunPar, false, false, ref infoQryRunPar.Sql);
                }

                //this.contFields.rSelList.Sql = sql.Trim();
                //this.txtSQL.Text = sql.Trim();
                //dsAdmin.tblSelListEntriesRow[] arrSelListEntry = new dsAdmin.tblSelListEntriesRow[1];
                //arrSelListEntry.SetValue(this.contFields.rSelList, 0);
                //this.sqlAdmin1.daSelListEntrys.Update(arrSelListEntry);

                //if (infoQryRunPar.ownMultiGridSelListQuery != null)
                //{
                //    System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput = new List<core.generic.retValue>();
                //    infoQryRunPar.ownMultiGridSelListQuery.getSelListsAdded(lstUserInput);
                //    //qs2.design.auto.ui ui = new qs2.design.auto.ui();
                //    //System.Collections.Generic.List<qs2.core.generic.retValue> lstUserInput = ui.getControlValues(infoQryRunPar.ownMultiGridSelList1);
                //    if (lstUserInput.Count > 0)
                //    {
                //        string sqlWhereMultiGrid = "";
                //        foreach (qs2.core.generic.retValue vParToSet in lstUserInput)
                //        {
                //            if (sqlWhereMultiGrid.Trim() != "")
                //            {
                //                sqlWhereMultiGrid += qs2.core.sqlTxt.and;
                //            }
                //            sqlWhereMultiGrid += " CongenitalData like " + vParToSet.valueStr.Trim() + " ";
                //            //this.genSql1.setParametersListSqlFix(ref lstSqlFix, ref  infoQryRunPar.Sql, vParToSet.fieldInfo, vParToSet.valueStr);
                //        }
                //        sqlWhereMultiGrid = " ( " + sqlWhereMultiGrid + " ) ";
                //        infoQryRunPar.Sql += (!infoQryRunPar.Sql.Contains(qs2.core.sqlTxt.where.Trim()) ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + " " + sqlWhereMultiGrid;
                //    }
                //}runQuery

                if (!protokoll.Trim().Equals(""))
                {
                    qs2.core.vb.frmProtocol frmProtokoll1 = new qs2.core.vb.frmProtocol();
                    frmProtokoll1.initControl();
                    frmProtokoll1.doTitle(qs2.core.language.sqlLanguage.getRes("SqlForQuery"));
                    qs2.core.ENV.lstOpendChildForms.Add(frmProtokoll1);
                    frmProtokoll1.Show();
                    frmProtokoll1.ContProtocol1.setText(protokoll);
                }

                if (saveResult)
                {
                    this.saveQueryToXML(infoQryRunPar.Sql, infoQryRunPar.parametersSql, infoQryRunPar.Application, infoQryRunPar.Participant, typRunQuery,
                                        infoQryRunPar, viewIsFunction);
                }

                return infoQryRunPar.Sql;
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.generateSql:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }

        public void openQuery(qs2.core.Enums.eTypRunQuery typRunQuery, qs2.ui.print.infoQry infoQryRunPar, bool dataSetViewer, bool Extern, 
                                ref bool viewIsFunction,
                                ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct, bool SqlForAdmin, bool OLAP)
        {
            try
            {
                if (infoQryRunPar.Sql != "" || infoQryRunPar.IsVLAD)
                {
                    //System.Data.DataSet dsQryAuto1 = new System.Data.DataSet();
                    string datasetName = qs2.core.dbBase.tableNameDsQueries + infoQryRunPar.rSelListQry.IDRessource;
                    string tableName = qs2.core.dbBase.tableNameQueries + infoQryRunPar.rSelListQry.IDRessource;
                    string AllParametersAsTxtReturn = "";

                    if (!Extern && !infoQryRunPar.IsVLAD)
                    {
                        if (!qs2.core.dbBase.fillDataSet(infoQryRunPar.Sql, infoQryRunPar.parametersSql,
                                ref infoQryRunPar.dsQryResult, tableName, datasetName, ref AllParametersAsTxtReturn, viewIsFunction))
                        {
                            this.doErrorExecuteSql(infoQryRunPar.Sql, infoQryRunPar.parametersSql, infoQryRunPar.rSelListQry.IDRessource);
                            return;
                        }
                        else
                        {

                            int rCount = 0;
                            foreach (System.Data.DataRow r in infoQryRunPar.dsQryResult.Tables[tableName].AsEnumerable())
                            {
                                int cCount = 0;
                                foreach (System.Data.DataColumn c in infoQryRunPar.dsQryResult.Tables[tableName].Columns)
                                {
                                    if (c.DataType.FullName == "System.String")
                                    {
                                        r[c.ColumnName] = HttpUtility.HtmlDecode(infoQryRunPar.dsQryResult.Tables[tableName].Rows[rCount].ItemArray[cCount].ToString()).Replace("<br/>", "\n");
                                    }
                                    cCount++;
                                }
                                rCount++;
                            }
                        }
                    }
                    else if (Extern && !infoQryRunPar.IsVLAD)
                    {
                        cServiceQS2 ServiceQS2 = new cServiceQS2();
                        qs2.core.vb.QS2Service1.cServiceResult ServiceResult = ServiceQS2.fillDataSetExtern(ref infoQryRunPar.Sql, infoQryRunPar.parametersSql,
                                                                                                        ref infoQryRunPar.dsQryResult, tableName, datasetName,
                                                                                                        ref AllParametersAsTxtReturn, ref viewIsFunction,
                                                                                                        ref lstParForExternFct);

                        if (!ServiceResult.OK)
                        {
                            this.doErrorExecuteSql(infoQryRunPar.Sql, infoQryRunPar.parametersSql, infoQryRunPar.rSelListQry.IDRessource);
                            return;
                        }
                    }

                    this.addStandardTablesToDs(infoQryRunPar.dsQryResult, typRunQuery, infoQryRunPar);

                    string protocol = "";
                    if (SqlForAdmin)
                    {
                        this.openSqlCommandInConsoleForAdmin(infoQryRunPar.sqlForAdmin, infoQryRunPar);
                    }
                    else
                    {
                        if (!dataSetViewer)
                        {
                            qs2.ui.print.frmTable frmTable1 = new qs2.ui.print.frmTable();
                            frmTable1.contTable1.infoQryRunPar = infoQryRunPar;
                            if (!string.IsNullOrWhiteSpace(protocol))
                            {
                                frmTable1.contTable1.lblProtocol.Visible = true;
                                //frmTable1.contTable1.ProtocollCounter = counterErrors;
                                frmTable1.contTable1.ProtocollText = protocol.Trim();
                                frmTable1.contTable1.ProtocollTitle = "Info: Problems with Query";
                                frmTable1.contTable1.lblProtocol.Text = "Errors"; //"Errors (" + counterErrors.ToString() + ")";
                                                                                    //frmTable1.contTable1.lblProtocol.Appearance.ForeColor = System.Drawing.Color.DarkRed;
                                                                                    //frmTable1.contTable1.lblProtocol.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            }
                            frmTable1.IDRessourceTitle = infoQryRunPar.rSelListQry.IDRessource;
                            frmTable1.defaultDs = infoQryRunPar.dsQryResult;
                            frmTable1.IDParticipant = infoQryRunPar.Participant;
                            frmTable1.IDApplication = infoQryRunPar.Application;
                            frmTable1.defaultTableNameDataMember = tableName;
                            frmTable1.contTable1.Sql = infoQryRunPar.Sql;
                            frmTable1.contTable1.parameters = infoQryRunPar.parametersSql;
                            frmTable1.contTable1.AllParametersAsTxtFromSqlCommand = AllParametersAsTxtReturn;
                            frmTable1.contTable1.doUnvisibleGuid = true;
                            frmTable1.initControl(qs2.ui.print.contTable.eTypeUI.Query, ref protocol, false);
                            qs2.core.ENV.lstOpendChildForms.Add(frmTable1);
                                frmTable1.Show();
                        }
                        else
                        {
                            qs2.ui.print.frmTable frmTable1 = new qs2.ui.print.frmTable();
                            if (protocol.Trim() != "")
                            {
                                frmTable1.contTable1.lblProtocol.Visible = true;
                                //frmTable1.contTable1.ProtocollCounter = counterErrors;
                                frmTable1.contTable1.ProtocollText = protocol.Trim();
                                frmTable1.contTable1.ProtocollTitle = "Info: Problems with Query";
                                frmTable1.contTable1.lblProtocol.Text = "Errors"; //"Errors (" + counterErrors.ToString() + ")";
                                //frmTable1.contTable1.lblProtocol.Appearance.ForeColor = System.Drawing.Color.DarkRed;
                                //frmTable1.contTable1.lblProtocol.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            }
                            frmTable1.contTable1.infoQryRunPar = infoQryRunPar;
                            string isChart = infoQryRunPar.rSelListQry.IDOwnStr;
                            frmTable1.selectDatasets = true;
                            System.Collections.ArrayList lstDatasets = new System.Collections.ArrayList();
                            lstDatasets.Add(infoQryRunPar.dsQryResult);
                            frmTable1.lstDatasets = lstDatasets;
                            frmTable1.IDParticipant = infoQryRunPar.Participant;
                            frmTable1.IDApplication = infoQryRunPar.Application;
                            frmTable1.initControl(qs2.ui.print.contTable.eTypeUI.Query, ref protocol, false);
                            qs2.core.ENV.lstOpendChildForms.Add(frmTable1);
                            frmTable1.Show();
                        }
                    }
                    //if (protocol.Trim() != "")
                    //{
                    //    qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                    //    frmProt.initControl();
                    //    frmProt.Text = "Info: Problems with Query";
                    //    frmProt.ContProtocol1.txtProtokoll.Text = protocol.Trim();
                    //    frmProt.Show();
                    //}
                }
                else
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoSqlExists") + "!", MessageBoxButtons.OK, "");

            }
            catch (Exception ex)
            {
                throw new Exception("genReport.openQuery:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void openSqlCommandInConsoleForAdmin(string sqlCommandForAdmin, qs2.ui.print.infoQry infoQryRunPar)
        {
            try
            {
                qs2.design.auto.print.frmSqlConsoleForAdmin frmSqlConsoleForAdmin1 = new design.auto.print.frmSqlConsoleForAdmin();
                frmSqlConsoleForAdmin1.initControlxy(sqlCommandForAdmin, infoQryRunPar);
                frmSqlConsoleForAdmin1.Show();

            }
            catch (Exception ex)
            {
                throw new Exception("genReport.openSqlCommandInConsoleForAdmin:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void doVLAD(qs2.core.Enums.eTypRunQuery typRunQuery, qs2.ui.print.infoQry infoQryRunPar, bool dataSetViewer, 
                            bool Extern, ref string sqlVLADReturn)
        {
            try
            {
                dsCARDIAC dsStatisticsVLAD = new dsCARDIAC();
                DataTableCollection dtColl = dsStatisticsVLAD.Tables;

                if (dtColl.Contains("VLADCARDIAC_STAYS") && dtColl.CanRemove(dtColl["VLADCARDIAC_STAYS"]))
                    dtColl.Remove("VLADCARDIAC_STAYS");
                
                doCARDIAC_Statistik doCARDIAC_Statistik1 = new doCARDIAC_Statistik();

                qs2.core.Enums.iEuroSCOREVersion iEuroSCOREVersion = core.Enums.iEuroSCOREVersion.EuroSCOREII;
                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQryParFound in infoQryRunPar.dsParFctForQuery.tblQueriesDef)
                {
                    if (rQryParFound.ValueMin.Trim() != "" && (bool)rQryParFound[qs2.core.generic.columnRemoved] == false)
                    {
                        if (rQryParFound.QryColumn.Trim().ToLower().Contains("rptcardiac_euroscoreversion"))
                        {
                            System.Collections.Generic.List<string> lstValues = qs2.core.generic.readStrVariables(rQryParFound.ValueMin.Trim());
                            if (lstValues.Count > 0)
                            {
                                iEuroSCOREVersion = (qs2.core.Enums.iEuroSCOREVersion)System.Convert.ToInt32((lstValues[0].ToString().Trim()));
                            }
                        }
                    }
                }

                string sqlWhereAdmin = "";
                int iPosWhere = infoQryRunPar.sqlForAdmin.IndexOf("where");
                if (iPosWhere != -1)
                {
                    sqlWhereAdmin = infoQryRunPar.sqlForAdmin.Substring(iPosWhere, infoQryRunPar.sqlForAdmin.Length - iPosWhere);
                }

                doCARDIAC_Statistik1.calcVLAD(sqlWhereAdmin, iEuroSCOREVersion, ref sqlVLADReturn , ref dsStatisticsVLAD );
                dsStatisticsVLAD.tblStatistics.TableName = "Qry" + infoQryRunPar.rSelListQry.IDRessource.Trim();
                infoQryRunPar.dsQryResult = dsStatisticsVLAD.Copy();
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doVLAD:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

   

        public void doErrorExecuteSql(string Sql, System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                        string QueryName)
        {
            try
            {
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ErrorExecuteSql") + "!", MessageBoxButtons.OK, "");
                if (qs2.core.ENV.adminSecure && qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                {
                    if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("OpenSqlFileYN") + "?", MessageBoxButtons.YesNo, "") == DialogResult.Yes)
                    {
                        string parameters = this.getParametersStr(parametersSql);
                        this.openSQLStatment(QueryName + ":\r\n" + "\r\n" + Sql + parameters, "Sql");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doErrorExecuteSql:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void openReport(System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar, qs2.ui.print.infoReport infoReport, 
                                qs2.core.Enums.eTypRunQuery typRunQuery, bool message, bool datasetViewer,
                                ref string SqlWhereInfoTotal, bool bExtern, ref bool viewIsFunction,
                                ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct, 
                                bool SqlForAdmin, bool FRDesignMode)
        {
            try
            {
                string protocol = "";
                foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                {
                    if (!String.IsNullOrWhiteSpace(infoQry1.Sql))
                    {
                        string dataTableName = qs2.core.dbBase.tableNameQueries + infoQry1.rSelListQry.IDRessource;
                        string dataSetName = qs2.core.dbBase.tableNameDsQueries + infoQry1.rSelListQry.IDRessource;
                        string AllParametersAsTxt = "";

                        if (!bExtern)
                        {
                            if (!infoQry1.IsVLAD)
                            {
                                if (!qs2.core.dbBase.fillDataSet(infoQry1.Sql, infoQry1.parametersSql, ref infoQry1.dsQryResult,
                                dataTableName, dataSetName, ref AllParametersAsTxt, viewIsFunction))
                                {
                                    this.doErrorExecuteSql(infoQry1.Sql, infoQry1.parametersSql, infoQry1.rSelListQry.IDRessource);
                                    return;

                                }
                            }
                        }
                        else
                        {
                            if (!infoQry1.IsVLAD)
                            {
                                cServiceQS2 ServiceQS2 = new cServiceQS2();
                                qs2.core.vb.QS2Service1.cServiceResult ServiceResult = ServiceQS2.fillDataSetExtern(ref infoQry1.Sql, infoQry1.parametersSql,
                                                                                                                ref infoQry1.dsQryResult, dataTableName, dataSetName,
                                                                                                                ref AllParametersAsTxt, ref viewIsFunction,
                                                                                                                ref lstParForExternFct);

                                if (!ServiceResult.OK)
                                {
                                    this.doErrorExecuteSql(infoQry1.Sql, infoQry1.parametersSql, infoQry1.rSelListQry.IDRessource);
                                    return;
                                }
                            }
                        }

                        this.addStandardTablesToDs(infoQry1.dsQryResult, typRunQuery, infoQry1);
                        this.doTableParameters(infoQry1);
                        System.Data.DataTable dtReturn = this.translateQuery1.translateSelList(infoQry1.dsQryResult.Tables[dataTableName], null, infoQry1.Application, ref protocol, true);
                        if (dtReturn == null)
                            return;
                        this.doAutoWhereClasuselForCRParameterFromUI(lstInfoQryRunPar, infoReport, typRunQuery, message, datasetViewer, 
                                                                        ref SqlWhereInfoTotal, ref infoQry1.Sql, ref AllParametersAsTxt);

                        System.Data.DataSet dsNew = new System.Data.DataSet();
                        dsNew.DataSetName = infoQry1.dsQryResult.DataSetName;
                        foreach (System.Data.DataTable dtExist in infoQry1.dsQryResult.Tables)
                        {
                            if (dataTableName.Trim().Equals(dtExist.TableName, StringComparison.OrdinalIgnoreCase))
                            {
                                dsNew.Tables.Add(dtReturn);
                            }
                            else
                            {
                                System.Data.DataTable dtNew = new System.Data.DataTable();
                                dtNew = dtExist.Copy();
                                dsNew.Tables.Add(dtNew);
                            }
                        }
                        infoQry1.dsQryResult = dsNew;
                    }
                    else
                    {
                        if (!infoQry1.isSubQuery)
                        {
                            string dataTableName = qs2.core.dbBase.tableNameQueries + infoQry1.rSelListQry.IDRessource;
                            string AllParametersAsTxt = "";
                            this.addStandardTablesToDs(infoQry1.dsQryResult, typRunQuery, infoQry1);
                            this.doTableParameters(infoQry1);
                            System.Data.DataTable dtReturn = this.translateQuery1.translateSelList(infoQry1.dsQryResult.Tables[dataTableName], null, infoQry1.Application, ref protocol, true);
                            if (dtReturn == null)
                                return;
                            this.doAutoWhereClasuselForCRParameterFromUI(lstInfoQryRunPar, infoReport, typRunQuery, message, datasetViewer,
                            ref SqlWhereInfoTotal, ref infoQry1.Sql, ref AllParametersAsTxt);

                            if (message)
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoSqlExists") + "!", MessageBoxButtons.OK, "");
                        }
                    } 
                }

                if (!datasetViewer)
                {
                    string DocFile = "";
                    bool DocFound = false;
                    bool SearchError = false;

                    using (QS2.db.Entities.ERModellQS2Entities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                    {
                        //Search first in Product-Directories and then in "ALL"-directory 
                        var rSelListDocDirsProduct = (from s in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries
                                                      join g in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup on s.IDGroup equals g.ID
                                                      join usort in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntriesSort on s.ID equals usort.IDSelListEntry
                                                      into res
                                                      from subpet in res.DefaultIfEmpty()
                                                      where g.IDGroupStr == "DocumentDirectories" && g.IDApplication == infoReport.Application
                                                      orderby g.IDApplication descending
                                                      orderby subpet?.Sort ?? 0
                                                      select new { s.IDRessource, s.ID, s.IDOwnStr }).ToList();

                        var rSelListDocDirsALL = (from s in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries
                                                  join g in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup on s.IDGroup equals g.ID
                                                  join usort in qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntriesSort on s.ID equals usort.IDSelListEntry
                                                  into res
                                                  from subpet in res.DefaultIfEmpty()
                                                  where g.IDGroupStr == "DocumentDirectories" && g.IDApplication == "ALL"
                                                  orderby g.IDApplication descending
                                                  orderby subpet?.Sort ?? 0
                                                  select new { s.IDRessource, s.ID, s.IDOwnStr }).ToList();

                        var rSelListCombined = rSelListDocDirsProduct.Union(rSelListDocDirsALL);

                        foreach (var DocumentDirectory in rSelListCombined)
                        {
                            DocFound = CheckDocumentFile(DocumentDirectory.IDRessource, infoReport.rSelListReport.IDRessource, out DocFile, out SearchError);

                            if (SearchError)
                                return;

                            if (DocFound)
                                break;
                        }

                        if (!DocFound)              //Search in Default-ReportPath (no translation)
                        {
                            DocFound = CheckDocumentFile(System.IO.Path.Combine(qs2.core.ENV.path_reports, infoReport.Application), infoReport.rSelListReport.IDRessource, out DocFile, out SearchError);

                            if (SearchError)
                                return;
                        }
                    }

                    if (DocFound)
                    {
                        if (System.IO.File.Exists(DocFile + qs2.core.vb.funct.fileTypeFastReport)) //use Fast-Report 
                        {
                            if (lstInfoQryRunPar[0].dsQryResult.Tables[0].Rows.Count > 0 || FRDesignMode)
                            {
                                qs2.design.auto.print.FReport FR2 = new qs2.design.auto.print.FReport();
                                if (FRDesignMode)
                                    FR2.Init(DocFile + qs2.core.vb.funct.fileTypeFastReport, lstInfoQryRunPar[0], infoReport, FRDesignMode).Design();
                                else
                                    FR2.Init(DocFile + qs2.core.vb.funct.fileTypeFastReport, lstInfoQryRunPar[0], infoReport, FRDesignMode).Show(false);
                                #region FastReport als Thread
                                /*
                                //Anklickbare Berichte(die einen Stay öffnen können) müssen modal aufgehen, die anderen können als Thread starten
                                if (infoReport.rSelListReport.Classification.ToUpper().Contains("MODAL;"))
                                {
                                    qs2.design.auto.print.FReport FR = new qs2.design.auto.print.FReport();
                                    FR.Init(RepFile + qs2.core.vb.funct.fileTypeFastReport, lstInfoQryRunPar[0], infoReport, FRDesignMode);
                                }
                                else
                                {
                                    qs2.design.auto.print.FReport FR = new qs2.design.auto.print.FReport();
                                    Thread thread1 = new Thread(delegate () { FR.Init(RepFile + qs2.core.vb.funct.fileTypeFastReport, lstInfoQryRunPar[0], infoReport, FRDesignMode); });
                                    thread1.SetApartmentState(ApartmentState.STA);
                                    thread1.Start();
                                }
                                */
                                #endregion
                            }
                            else
                            {
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecords"), MessageBoxButtons.OK, "");
                            }
                        }
                        #region CrystalReport - obsolet
                        //else if (System.IO.File.Exists(RepFile + qs2.core.vb.funct.fileTypeFastReport)) //use CrystalReports
                        //{
                        //    qs2.ui.print.frmCryCrystRepViewer frmCryCrystRepViewer1 = new qs2.ui.print.frmCryCrystRepViewer();
                        //    if (!string.IsNullOrWhiteSpace(protocol))
                        //    {
                        //        frmCryCrystRepViewer1.contQryCrystRepViewer1.lblProtocol.Visible = true;
                        //        frmCryCrystRepViewer1.contQryCrystRepViewer1.ProtocollText = protocol.Trim();
                        //        frmCryCrystRepViewer1.contQryCrystRepViewer1.ProtocollTitle = "Info: Problems with Report";
                        //        frmCryCrystRepViewer1.contQryCrystRepViewer1.lblProtocol.Text = "Errors"; //"Errors (" + counterErrors.ToString() + ")";
                        //    }
                        //    frmCryCrystRepViewer1.contQryCrystRepViewer1.lstInfoQryRunPar = lstInfoQryRunPar;
                        //    frmCryCrystRepViewer1.contQryCrystRepViewer1.infoReport = infoReport;

                        //    frmCryCrystRepViewer1.initControl();
                        //    qs2.core.ENV.lstOpendChildForms.Add(frmCryCrystRepViewer1);
                        //    frmCryCrystRepViewer1.Show();
                        //}
                        #endregion
                        
                        else if (System.IO.File.Exists(DocFile + qs2.core.vb.funct.fileTypePDF)) //PDF 
                        {
                            PrintPDF(lstInfoQryRunPar[0], infoReport, DocFile);

                        }
                        
                        else if (System.IO.File.Exists(DocFile + qs2.core.vb.funct.fileTypeRTF)) //RTF
                        {
                            if (lstInfoQryRunPar[0].dsQryResult.Tables[0].Rows.Count > 0)
                            {
                                cRTFDocuments cRTFDoks = new cRTFDocuments();
                                List<byte[]> ListOfDocuments = cRTFDoks.CreateDocuments(DocFile + qs2.core.vb.funct.fileTypeRTF, lstInfoQryRunPar[0], infoReport, true);

                                QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                                QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                                frmEditor.fFelderEinAus = true;
                                frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                                frmEditor.ContTxtEditor1.LinealeOnOff(false);
                                frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                                frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                                frmEditor.Show();

                                TXTextControl.AppendSettings appSettings = new TXTextControl.AppendSettings();
                                foreach (byte[] Document in ListOfDocuments)
                                {
                                    frmEditor.ContTxtEditor1.textControl1.Append(Document, TXTextControl.BinaryStreamType.InternalFormat, TXTextControl.AppendSettings.StartWithNewSection);
                                }
                                frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                                frmEditor.ContTxtEditor1.textControl1.StatusBar.ShowSection = false;
                                frmEditor.ContTxtEditor1.textControl1.StatusBar.ShowSectionCounter = false;

                                frmEditor.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_QS2, 32, 32);
                                frmEditor.Text = "";
                                if (!qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS).bValue)
                                    frmEditor.Text = qs2.core.language.sqlLanguage.getRes("TrialVersion") + qs2.core.language.sqlLanguage.getRes("ValidTo") + " " + qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS_VALID_DATE).dValue.ToString("dd.MM.yyyy - ");
                                
                                frmEditor.Text += System.IO.Path.GetFileNameWithoutExtension(DocFile) + " (" + ListOfDocuments.Count().ToString() + ")";
                                Application.DoEvents();
                            }
                            else
                            {
                                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecords"), MessageBoxButtons.OK, "");
                            }
                        }
                        else
                        {
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NeitherFastReportNorCrystalReportsOrPDFAvailable"), MessageBoxButtons.OK, "");
                        }
                    }
                    else
                    {
                        qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NeitherFastReportNorCrystalReportsOrPDFAvailable"), MessageBoxButtons.OK, "");
                    }                    
                }
                else
                {
                    qs2.ui.print.frmTable frmTable1 = new qs2.ui.print.frmTable();
                    if (!string.IsNullOrWhiteSpace(protocol))
                    {
                        frmTable1.contTable1.lblProtocol.Visible = true;
                        frmTable1.contTable1.ProtocollText = protocol.Trim();
                        frmTable1.contTable1.ProtocollTitle = "Info: Problems with Query";
                        frmTable1.contTable1.lblProtocol.Text = "Errors"; //"Errors (" + counterErrors.ToString() + ")";
                    }
                    frmTable1.selectDatasets = true;
                    System.Collections.ArrayList lstDatasets = new System.Collections.ArrayList();
                    foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                    {
                        lstDatasets.Add(infoQry1.dsQryResult);
                    }
                    frmTable1.contTable1.doTranslateQuery = false;
                    frmTable1.lstDatasets = lstDatasets;
                    frmTable1.IDParticipant = infoReport.Participant;
                    frmTable1.IDApplication = infoReport.Application;
                    frmTable1.initControl(qs2.ui.print.contTable.eTypeUI.Query, ref protocol, false);
                    qs2.core.ENV.lstOpendChildForms.Add(frmTable1);
                    frmTable1.Show();
                }

                //if (protocol.Trim() != "")
                //{
                //    frmProtocol frmProt = new frmProtocol();
                //    frmProt.initControl();
                //    frmProt.Text = "Info: Problems with Report";
                //    frmProt.ContProtocol1.txtProtokoll.Text = protocol.Trim();
                //    frmProt.Show();
                //}

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(qs2.core.Exceptions.ExceptionHand.GetStackTraceForException(ex).ToString(), ex.Message);
                //throw new Exception("genReport.openReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


        private bool CheckDocumentFile(string sPath, string sFile, out string DocFile, out bool SearchError)
        {
            DocFile = "";
            SearchError = false;

            if (sPath.StartsWith("auto_"))
                sPath = qs2.core.language.sqlLanguage.getRes(sPath);

            if (sFile.StartsWith("auto_"))
                sFile = qs2.core.language.sqlLanguage.getRes(sFile);
                
            if (!qs2.core.generic.CheckIllegalCharacter(sPath, true))
            {
                SearchError = true;
                return false;
            }

            if (!qs2.core.generic.CheckIllegalCharacter(sFile, false))
            {
                SearchError = true;
                return false;
            }

            string DocFileTmp = System.IO.Path.Combine(sPath, sFile);
            if (System.IO.File.Exists(DocFileTmp + qs2.core.vb.funct.fileTypeFastReport))
            {
                DocFile = DocFileTmp;
                if (qs2.core.generic.CheckOpenFile(DocFile + qs2.core.vb.funct.fileTypeFastReport))
                {
                    return true;
                }
                else
                {
                    SearchError = true;
                    return false;
                }
            }

            else if (System.IO.File.Exists(DocFileTmp + qs2.core.vb.funct.fileTypePDF))
            {
                DocFile = DocFileTmp;
                if (qs2.core.generic.CheckOpenFile(DocFile + qs2.core.vb.funct.fileTypePDF))
                {
                    return true;
                }
                else
                {
                    SearchError = true;
                    return false;
                }
            }

            else if (System.IO.File.Exists(DocFileTmp + qs2.core.vb.funct.fileTypeRTF))
            {
                DocFile = DocFileTmp;
                if (qs2.core.generic.CheckOpenFile(DocFile + qs2.core.vb.funct.fileTypeRTF))
                {
                    return true;
                }
                else
                {
                    SearchError = true;
                    return false;
                }
            }

            return false;
        }

        private static void PrintPDF(ui.print.infoQry infoQry,  ui.print.infoReport infoRpt, string DocFile)
        {
            if (infoQry.dsQryResult.Tables[0].Rows.Count > 0)
            {
                if (infoQry.dsQryResult.Tables[0].Rows.Count > 500)
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("MaxRecords500"), MessageBoxButtons.OK, "");
                    return;
                }
                qs2.design.auto.print.frmPDFViewer frmPDF = new qs2.design.auto.print.frmPDFViewer();
                frmPDF.Init(DocFile + qs2.core.vb.funct.fileTypePDF, infoQry, infoRpt);
                frmPDF.Show();
            }
            else
            {
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoRecords"), MessageBoxButtons.OK, "");
                return;
            }
        }

        public void doAutoWhereClasuselForCRParameterxyxyxyxy(System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar,
                        qs2.ui.print.infoReport infoReport,
                        qs2.core.Enums.eTypRunQuery typRunQuery, bool message, bool datasetViewer,
                        ref qs2.core.vb.dsAdmin.tblQueriesDefDataTable tAllParametersForReport,
                        ref string sqlWhereReturn, ref string WhereClauselForSimpleFunctions)
        {
            try
            {
                //if (sqlWhereReturn.Trim() != "" || WhereClauselForSimpleFunctions.Trim() != "")
                //{
                //    string WhereClauselForSimpleFunctionsTranslated = "";
                //    if (WhereClauselForSimpleFunctions.Trim() != "")
                //    {
                //        this.translateSqlWhere(ref WhereClauselForSimpleFunctions, ref WhereClauselForSimpleFunctionsTranslated, ref infoReport.Application, ref infoReport.Participant);
                //    }
                //    string sqlWhereReturnTranslated = "";
                //    if (sqlWhereReturn.Trim() != "")
                //    {
                //        this.translateSqlWhere(ref sqlWhereReturn, ref sqlWhereReturnTranslated, ref infoReport.Application, ref infoReport.Participant);
                //    }
                  
                //    foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                //    {
                //        sqlAdmin sqlAdminTmp = new sqlAdmin();
                //        dsAdmin.tblQueriesDefRow rNewQueriesDef = sqlAdminTmp.addRowQueriesDef(infoQry1.tQryParForQueryxy);
                //        rNewQueriesDef.Typ = core.Enums.eTypQueryDef.InputParameters.ToString();
                //        rNewQueriesDef.QryColumn = "SqlWhere";

                //        string CombinationWhere = "";
                //        if (sqlWhereReturnTranslated.Trim() != "" && WhereClauselForSimpleFunctionsTranslated.Trim() != "")
                //        {
                //            CombinationWhere = "\r\n";
                //        }
                //        foreach(System.Data.SqlClient.SqlParameter parSql  in infoQry1.parametersSql)
                //        {
                //            sqlWhereReturnTranslated = sqlWhereReturnTranslated.Replace(parSql.ParameterName, parSql.Value.ToString());
                //        }
                //        rNewQueriesDef[qs2.core.generic.columnNameVal] = WhereClauselForSimpleFunctionsTranslated.Trim() + CombinationWhere + sqlWhereReturnTranslated.Trim();
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doAutoWhereClasuselForCRParameter:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void doAutoWhereClasuselForCRParameterFromUI(System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar,
                                                            qs2.ui.print.infoReport infoReport,
                                                            qs2.core.Enums.eTypRunQuery typRunQuery, bool message, bool datasetViewer,
                                                            ref string sqlWhereToAdd, ref string Sql, ref string AllParametersAsTxt)
        {
            try
            {
                foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                {
                    sqlAdmin sqlAdminTmp = new sqlAdmin();
                    dsAdmin.tblQueriesDefRow rNewQueriesDef = sqlAdminTmp.addRowQueriesDef(infoQry1.dsParFctForQuery.tblQueriesDef);
                    rNewQueriesDef.Typ = core.Enums.eTypQueryDef.InputParameters.ToString();
                    rNewQueriesDef.QryColumn = "SqlWhere";

                    rNewQueriesDef.ValueMin = sqlWhereToAdd.Trim();

                    rNewQueriesDef = sqlAdminTmp.addRowQueriesDef(infoQry1.dsParFctForQuery.tblQueriesDef);
                    rNewQueriesDef.Typ = core.Enums.eTypQueryDef.InputParameters.ToString();
                    rNewQueriesDef.QryColumn = "Sql";

                    rNewQueriesDef.ValueMin = Sql.Trim() + "\r\n" + "\r\n" + AllParametersAsTxt.Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doAutoWhereClasuselForCRParameterFromUI:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void translateSqlWherexyxy(ref string SqlWhereToTranslate, ref string SqlWhereTranslated, 
                                        ref string Application, ref string Participant)
        {
            try
            {
                //SqlWhereTranslated = SqlWhereToTranslate;
                //string SqlWhereTranslatedTmp = SqlWhereToTranslate;
                //int iPosEmptySignPrev = 0;
                //int pos = 0;
                //while (pos < SqlWhereTranslatedTmp.Length) 
                //{
                //    int iNextPosEmpty = SqlWhereTranslatedTmp.IndexOf(" ", pos);
                //    if(iNextPosEmpty != -1)
                //    {
                //        string sWord = SqlWhereTranslatedTmp.Substring(iPosEmptySignPrev, iNextPosEmpty - iPosEmptySignPrev);
                //        if (sWord.Trim() != "")
                //        {
                //            string sWordTmp = qs2.core.language.sqlLanguage.checkComma(sWord);
                //            if (sWordTmp.Trim() == "")
                //            {
                //                sWordTmp = sWord;
                //            }
                //            string sWordTranslated = qs2.core.language.sqlLanguage.getResAllProdukts(sWordTmp.Trim(), Participant, Application, true);
                //            if (sWordTranslated.Trim() != "")
                //            {
                //                SqlWhereTranslated = SqlWhereTranslated.Replace(sWord.Trim(), "" + sWordTranslated.Trim() + "");
                //            }
                //            iPosEmptySignPrev = iNextPosEmpty;
                //        }

                //    }
                //    pos += 1;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.translateSqlWhere:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void addStandardTablesToDs(System.Data.DataSet dsQryResult, qs2.core.Enums.eTypRunQuery typRunQuery, qs2.ui.print.infoQry infoQry1)
        {
            try
            {

                int IDUser = qs2.core.vb.actUsr.rUsr.ID; 
                
                qs2.core.print.dsQryAuto.picturesDataTable tPictures = new qs2.core.print.dsQryAuto.picturesDataTable();
                dsQryResult.Tables.Add(tPictures);

                qs2.core.print.dsQryAuto.ParametersDataTable tParameters = new qs2.core.print.dsQryAuto.ParametersDataTable();
                dsQryResult.Tables.Add(tParameters);

                dsObjects.tblObjectDataTable tObject = new dsObjects.tblObjectDataTable();
                dsObjects.tblStayDataTable tStay = new dsObjects.tblStayDataTable();
                qs2.core.vb.doDB.addObjectTablesToDataset(dsQryResult, qs2.core.vb.doDB.tableNameUser, qs2.core.vb.doDB.tableNameUserAdress, false);              
                qs2.core.vb.doDB.addObjectDataToDataset(dsQryResult, IDUser, qs2.core.vb.doDB.tableNameUser, qs2.core.vb.doDB.tableNameUserAdress, false);
                qs2.core.vb.doDB.addParticipantTableToDataset(dsQryResult);
                qs2.core.vb.doDB.addParticipantDataToDataset(dsQryResult);

                qs2.core.vb.dsAdmin.tblQueriesDefDataTable tAllParametersForReportNew = new qs2.core.vb.dsAdmin.tblQueriesDefDataTable();
                tAllParametersForReportNew = (qs2.core.vb.dsAdmin.tblQueriesDefDataTable)infoQry1.dsConditionsForQuery.tblQueriesDef.Copy();
                tAllParametersForReportNew.Columns.Remove(qs2.core.generic.columnMultiControl);
                tAllParametersForReportNew.TableName = "Parameters_UI";
                dsQryResult.Tables.Add(tAllParametersForReportNew);
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.addStandardTablesToDs:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void saveQueryToXML(string Sql, System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                    string Application, string Participant, qs2.core.Enums.eTypRunQuery typRunQuery, qs2.ui.print.infoQry infoQry1,
                                    bool ViewIsFunction)
        {
            try
            {
                string fileNameDefault = "";
                string protocol = "";
                System.Data.DataSet dsQryResult = new System.Data.DataSet();
                if (!String.IsNullOrWhiteSpace(Sql)  && !infoQry1.IsVLAD)
                {
                    string dataSetName = qs2.core.dbBase.tableNameDsQueries + infoQry1.rSelListQry.IDRessource;
                    string AllParametersAsTxtReturn = "";
                    fileNameDefault = qs2.core.dbBase.tableNameQueries + infoQry1.rSelListQry.IDRessource;
                    if (!qs2.core.dbBase.fillDataSet(Sql, parametersSql, ref dsQryResult, fileNameDefault, dataSetName, ref AllParametersAsTxtReturn, ViewIsFunction))
                    {
                        this.doErrorExecuteSql(Sql, parametersSql, infoQry1.rSelListQry.IDRessource);
                        return;
                    }

                    this.addStandardTablesToDs(dsQryResult, typRunQuery, infoQry1);

                    string TableName = "Qry" + infoQry1.rSelListQry.IDRessource;
                    System.Data.DataTable dtReturn = this.translateQuery1.translateSelList(dsQryResult.Tables[TableName], null, infoQry1.Application, ref protocol, true);
                    if (dtReturn == null)
                        return;
                    dsQryResult.Tables.Remove(TableName);
                    dsQryResult.Tables.Add(dtReturn);
                }
                else if (String.IsNullOrWhiteSpace(Sql) && !infoQry1.IsVLAD)
                {
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoSqlExists") + "!", MessageBoxButtons.OK, "");
                    return;
                }
                else if (infoQry1.IsVLAD)
                {
                    dsQryResult = infoQry1.dsQryResult;
                    fileNameDefault = qs2.core.dbBase.tableNameQueries + infoQry1.rSelListQry.IDRessource;
                    this.addStandardTablesToDs(dsQryResult, typRunQuery, infoQry1);
                }

                string fileToSave = this.funct1.saveFile(false, qs2.core.vb.funct.xmlFileType, fileNameDefault, System.IO.Path.Combine(qs2.core.ENV.path_reports, Application));
                if (fileToSave != null)
                {
                    string fileToSaveXsd = Path.Combine(Path.GetFullPath(fileToSave), Path.GetFileNameWithoutExtension(fileToSave), ".xsd");
                    if (System.IO.File.Exists(fileToSave))
                        System.IO.File.Delete(fileToSave);
                    if (System.IO.File.Exists(fileToSaveXsd))
                        System.IO.File.Delete(fileToSaveXsd);
                    dsQryResult.WriteXml(fileToSave, System.Data.XmlWriteMode.WriteSchema);
                    dsQryResult.WriteXmlSchema(fileToSaveXsd);
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ResultSaved") + "!", MessageBoxButtons.OK, "");
                }

                if (!String.IsNullOrWhiteSpace(protocol))
                {
                    frmProtocol frmProt = new frmProtocol();
                    frmProt.initControl();
                    frmProt.Text = "Info: Problems with Query";
                    qs2.core.ENV.lstOpendChildForms.Add(frmProt);
                    frmProt.Show();
                    frmProt.ContProtocol1.setText(protocol.Trim());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.saveQueryToXML:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void openSQLStatment(string sql, string title)
        {
            try
            {
                string fileToOpen = this.funct1.saveFileFromString(qs2.core.ENV.path_temp, title, qs2.core.vb.funct.fileTypeTxt, sql);
                this.funct1.openFile(fileToOpen, "", false);
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.openSQLStatment:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public string getParametersStr(System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters)
        {
            try
            {
                string resultPar = "";
                if (parameters.Count > 0)
                {
                    resultPar = qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + "Parameters:" + qs2.core.generic.lineBreak;
                    foreach (System.Data.SqlClient.SqlParameter par in parameters)
                        resultPar += par.ParameterName + " = " + (par.Value == null ? "null" : par.Value.ToString()) + qs2.core.generic.lineBreak;
                }

                return resultPar; 
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.getParametersStr:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
         
        public void infoQueries(string IDResQueries, string title)
        {
            try
            {
                string txt = qs2.core.language.sqlLanguage.getRes("AssignedQueries") + ":" + qs2.core.generic.lineBreak + "     " + IDResQueries;

                string fileToOpen = this.funct1.saveFileFromString(qs2.core.ENV.path_temp, title, qs2.core.vb.funct.fileTypeTxt, txt);
                this.funct1.openFile(fileToOpen, "", false);
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.infoQueries:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool LogOnCrystReport(ReportDocument ReportDocument1, System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar,
                                        bool SetDataTableSourceToSubreports)
        {
            try
            {
                TableLogOnInfo info = new TableLogOnInfo();
                info.ConnectionInfo.DatabaseName = qs2.core.ENV.Database;

                if (!qs2.core.ENV.TrustedConnection)
                {
                    info.ConnectionInfo.UserID = qs2.core.ENV.userDb;
                    info.ConnectionInfo.Password = qs2.core.ENV.pwdDbDecrypted;
                }
                else
                {
                    info.ConnectionInfo.IntegratedSecurity = true;
                    info.ConnectionInfo.Password = string.Empty;
                    info.ConnectionInfo.UserID = string.Empty;
                }

                info.ConnectionInfo.ServerName = qs2.core.ENV.Server;

                foreach (Table t in ReportDocument1.Database.Tables)
                {
                    t.ApplyLogOnInfo(info);
                }

                qs2.ui.print.infoQry infoQry1 = this.getDBForSubreport(lstInfoQryRunPar, "");
                if (infoQry1 != null)
                    ReportDocument1.SetDataSource(infoQry1.dsQryResult);

                foreach (CrystalDecisions.CrystalReports.Engine.Section s in ReportDocument1.ReportDefinition.Sections)
                {
                    foreach (ReportObject o in s.ReportObjects)
                    {
                        if (o.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject so = (SubreportObject)o;
                            ReportDocument doc = so.OpenSubreport(so.SubreportName);
                            foreach (Table t in doc.Database.Tables)
                            {
                                t.ApplyLogOnInfo(info);
                            }
                            if (SetDataTableSourceToSubreports)
                            {
                                qs2.ui.print.infoQry infoQrySub = this.getDBForSubreport(lstInfoQryRunPar, so.SubreportName);
                                if (infoQrySub != null)
                                {
                                    doc.SetDataSource(infoQrySub.dsQryResult); 
                                }
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.LogOnCrystReport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool noParticipant(string Classification)
        {
            try
            {
                return ci.CompareInfo.IndexOf(Classification, "Participant=None", CompareOptions.IgnoreCase) >= 0;
            }
            catch (Exception ex)
            {
                throw new Exception("noParticipant: " + ex.ToString());
            }
        }

        public qs2.ui.print.infoQry getDBForSubreport(System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar, 
                                                      string nameSubreport)
        {
            try
            {
                qs2.ui.print.infoQry infoQryReturn = null;
                foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                {
                    if (String.IsNullOrWhiteSpace(nameSubreport) && infoQry1.typSubreport == core.Enums.eTypSubReport.MainReport)
                    {
                        infoQryReturn = infoQry1;
                        return infoQryReturn;
                    }
                    else if (!String.IsNullOrWhiteSpace(nameSubreport) && infoQry1.typSubreport == core.Enums.eTypSubReport.SubReport && infoQry1.rSelListQry.IDRessource.Trim() == nameSubreport.Trim())
                    {
                        infoQryReturn = infoQry1;
                        return infoQryReturn;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.getDBForSubreport:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void doTableParameters(qs2.ui.print.infoQry infoQry1)
        {
            try
            {
                qs2.core.print.dsQryAuto dsQryAutoTemp = new qs2.core.print.dsQryAuto();

                dsAdmin.tblQueriesDefRow[] arrQueriesDefPar = (dsAdmin.tblQueriesDefRow[])infoQry1.dsParFctForQuery.tblQueriesDef.Select(infoQry1.dsConditionsForQuery.tblQueriesDef.TypColumn.ColumnName + "='" + core.Enums.eTypQueryDef.InputParameters.ToString() + "'", infoQry1.dsParFctForQuery.tblQueriesDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueriesDefPar.Length > 0)
                {
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in arrQueriesDefPar)
                    {
                        this.setValueParameter(infoQry1.dsQryResult.Tables[dsQryAutoTemp.Parameters.TableName], rQry);
                    }
                }

                // No Userinput
                dsAdmin.tblQueriesDefRow[] arrQueriesDefInputFields = (dsAdmin.tblQueriesDefRow[])infoQry1.dsInputFieldsForQuery.tblQueriesDef.Select(infoQry1.dsParFctForQuery.tblQueriesDef.TypColumn.ColumnName + "='" + core.Enums.eTypQueryDef.InputParameters.ToString() + "'", infoQry1.dsParFctForQuery.tblQueriesDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueriesDefInputFields.Length > 0)
                {
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in arrQueriesDefInputFields)
                    {
                        this.setValueParameter(infoQry1.dsQryResult.Tables[dsQryAutoTemp.Parameters.TableName], rQry);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doTableParameters:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void setValueParameter(System.Data.DataTable tablePar, qs2.core.vb.dsAdmin.tblQueriesDefRow rQry)
        {
            try
            {
                string parNameQry = !String.IsNullOrWhiteSpace(rQry.Label) ? rQry.Label.Trim() : rQry.QryColumn.Trim();
                qs2.core.print.dsQryAuto dsQryAutoTemp = new qs2.core.print.dsQryAuto();
                qs2.core.print.dsQryAuto.ParametersRow rParNew = (qs2.core.print.dsQryAuto.ParametersRow)tablePar.NewRow();
                rParNew.ParID = parNameQry;
                rParNew.ParValueStr = rQry.ValueMin.Trim();
                tablePar.Rows.Add(rParNew);
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.setValueParameter:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        
        public void doParametersCrystRep(System.Collections.Generic.List<qs2.ui.print.infoQry> lstInfoQryRunPar, ReportDocument report)
        {
            try
            {
                foreach (qs2.ui.print.infoQry infoQry1 in lstInfoQryRunPar)
                {
                    dsAdmin.tblQueriesDefRow[] arrQueriesDef = (dsAdmin.tblQueriesDefRow[])infoQry1.dsParFctForQuery.tblQueriesDef.Select(infoQry1.dsParFctForQuery.tblQueriesDef.TypColumn.ColumnName + "='" + core.Enums.eTypQueryDef.InputParameters.ToString() + "'", infoQry1.dsParFctForQuery.tblQueriesDef.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                    if (arrQueriesDef.Length > 0)
                    {
                        foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in arrQueriesDef)
                        {
                            if (!rQry.FunctionPar)
                            {
                                foreach (ParameterField parCrystRep in report.ParameterFields)
                                {
                                    string parNameQry = !String.IsNullOrWhiteSpace(rQry.Label) ? rQry.Label.Trim() : rQry.QryColumn.Trim();

                                    if (parCrystRep.Name.Trim().Equals(parNameQry.Trim(), StringComparison.OrdinalIgnoreCase))
                                    {
                                        report.SetParameterValue(parCrystRep.Name, rQry.ValueMin.Trim());
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genReport.doParametersCrystRep:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void AddCrystalParameter(ReportDocument crReport, string ParameterName, string ParameterValue)
        {
            ParameterFieldDefinitions crParameterFieldDefinitions = crReport.DataDefinition.ParameterFields;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterFieldDefinition param = crParameterFieldDefinitions[ParameterName];
            crParameterValues = param.CurrentValues;
            ParameterDiscreteValue param_Val = new ParameterDiscreteValue();
            param_Val.Value = ParameterValue;
            crParameterValues.Add(param_Val);
            param.ApplyCurrentValues(crParameterValues);
        }

        public void saveProtocol(string infoQuery, string titleTranlated, Protocol.eTypeProtocoll typeToSave, 
                                    qs2.ui.print.infoReport infoReport, string SQLResult,
                                    core.Enums.eTypRunQuery TypRunQuery)
        {
            using (Protocol ProtocollManager = new Protocol())
            {
                string info = "Query: " + infoQuery + "\r\n" +
                    "Translation Title Query: " + titleTranlated.Trim() + "\r\n" +
                    "Sql-Command: " + "\r\n" + SQLResult;
                ProtocollManager.save2(typeToSave, System.Guid.Empty, qs2.core.generic.idMinus,
                                qs2.core.license.doLicense.rParticipant.IDParticipant, infoReport.Application, "", info,
                                Protocol.eActionProtocol.AddNew, "", "");
            }
        }

        public void showProtocol(string info, qs2.ui.print.infoReport infoReport, sqlProtocoll.eSelProtocoll typeSelect, string IDRessourceTitle)
        {
            dsProtocol dsProtocollRead = new dsProtocol();
            string sAdditionalText = info;
            qs2.core.vb.sqlProtocoll sqlProtocollRead = new  qs2.core.vb.sqlProtocoll();
            sqlProtocollRead.initControl();
            string SqlCommand = "";
            sqlProtocollRead.getProtocol(System.Guid.Empty, ref dsProtocollRead, typeSelect, "", System.Guid .Empty, qs2.core.generic.idMinus, "", "", null, null, "", ref SqlCommand, true);
            qs2.design.auto.ui.openTableViewer(dsProtocollRead, IDRessourceTitle, sAdditionalText, 
                                                infoReport.Participant, infoReport.Application, dsProtocollRead.Protocol.TableName, 
                                                ui.print.contTable.eTypeUI.History, false);
        }
    }
}
