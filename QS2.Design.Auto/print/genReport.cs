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
                                    ref string WhereClauselForSimpleFunctions, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    bool SqlForAdmin, bool CheckBrackets, ref bool BracketsOK)
        {
            try
            {
                bool noParticipant = this.noParticipant(infoQryRunPar.rSelListQry.Classification.Trim());
                infoQryRunPar.Sql = this.generateSql2(withParameters, lstMultiControl, lstReturnMultiGrids, infoQryRunPar, typRunQuery, false,
                                                        ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref lstParForExternFct, ref noParticipant, SqlForAdmin,
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
                                    ref string WhereClauselForSimpleFunctions, ref bool viewIsFunction,
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
                doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, infoQryRunPar.dsConditionsForQuery.tblQueriesDef, false, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), noParticipant, CheckBrackets, ref BracketsOK);
                bool BracketOKTmp = false;
                doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, infoQryRunPar, infoQryRunPar.dsParFctForQuery.tblQueriesDef, true, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), noParticipant, false, ref BracketOKTmp);
                doParameterForQuery.addColumnsToTableConditions(infoQryRunPar.dsParFctForQuery.tblQueriesDef);

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
                    doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, InfoQryRunParSub, InfoQryRunParSub.dsConditionsForQuery.tblQueriesDef, false, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), noParticipant, CheckBrackets, ref BracketsOKSub);
                    doParameterForQuery1.getParValues(lstMultiControl, lstReturnMultiGrids, InfoQryRunParSub, InfoQryRunParSub.dsParFctForQuery.tblQueriesDef, true, ref qs2.core.ENV.IsHeadquarter, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), noParticipant, false, ref BracketOKTmp);
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
                                                        ref lstParForExternFct, ref infoQryRunPar.sqlForAdmin, ref DataSql, ref sqlWhereAdminReturn);
                infoQryRunPar.SqlWhereFromSql = sqlWhereReturn;
                infoQryRunPar.WhereClauselForSimpleFunctions = WhereClauselForSimpleFunctions;

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

        public void openQuery(qs2.core.Enums.eTypRunQuery typRunQuery, qs2.ui.print.infoQry infoQryRunPar, bool dataSetViewer, 
                                ref bool viewIsFunction,
                                ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct, bool SqlForAdmin)
        {
            try
            {
                if (infoQryRunPar.Sql != "" || infoQryRunPar.IsVLAD)
                {
                    string datasetName = qs2.core.dbBase.tableNameDsQueries + infoQryRunPar.rSelListQry.IDRessource;
                    string tableName = qs2.core.dbBase.tableNameQueries + infoQryRunPar.rSelListQry.IDRessource;
                    string AllParametersAsTxtReturn = "";

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
                                frmTable1.contTable1.ProtocollText = protocol.Trim();
                                frmTable1.contTable1.ProtocollTitle = "Info: Problems with Query";
                                frmTable1.contTable1.lblProtocol.Text = "Errors"; //"Errors (" + counterErrors.ToString() + ")";
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
                    string fileToSaveXsd = Path.Combine(Path.GetFullPath(fileToSave), Path.GetFileNameWithoutExtension(fileToSave) + ".xsd");
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
