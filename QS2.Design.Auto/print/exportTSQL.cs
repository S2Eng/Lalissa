using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace qs2.print
{



    public class exportTSQL
    {

        public qs2.core.vb.sqlAdmin sqlAdminWork = new qs2.core.vb.sqlAdmin();
        public bool initialized = false;
        public static string sLine = "-- -------------------------------------------------------------------------------------------------------------------------------------------------";
        




        public void init()
        {
            if (this.initialized)
                return;

            this.sqlAdminWork.initControl();

            this.initialized = true;
        }

        public bool ExportQueries(ref System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblSelListEntriesRow> lstSelLists, string Application)
        {
            try
            {
                this.init();

                int counter = 0;
                StringBuilder sbResultSkript = new StringBuilder();
                this.AppendTitle(sbResultSkript);
                foreach(qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToExport in lstSelLists)
                {
                    counter += 1;
                    sbResultSkript.AppendLine("");
                    this.ExportQuery(rQueryToExport, Application, ref sbResultSkript, (counter == lstSelLists.Count ? true : false), ref counter);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.ExportQueries:" + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        public bool ExportQuery(qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToExport, string Application, ref StringBuilder sbResultSkript,
                                        bool SaveSqlFile, ref int counter)
        {
            try
            {
                StringBuilder sbResultSkriptTmp = new StringBuilder();
                this.init();

                StringBuilder sbInfoQuery = new StringBuilder();

                qs2.core.vb.dsAdmin dsAdminFields = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork.getQueriesDef(rQueryToExport.ID, dsAdminFields, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.SelectFields, qs2.core.license.doLicense.eApp.ALL.ToString(), Application);

                qs2.core.vb.dsAdmin dsAdminWhere = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork.getQueriesDef(rQueryToExport.ID, dsAdminWhere, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.WhereConditions, qs2.core.license.doLicense.eApp.ALL.ToString(), Application);

                qs2.core.vb.dsAdmin dsAdminJoins = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork.getQueriesDef(rQueryToExport.ID, dsAdminJoins, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.Joins, qs2.core.license.doLicense.eApp.ALL.ToString(), Application);

                qs2.core.vb.dsAdmin dsAdminInputParameters = new qs2.core.vb.dsAdmin();
                this.sqlAdminWork.getQueriesDef(rQueryToExport.ID, dsAdminInputParameters, core.vb.sqlAdmin.eTypSelQueryDef.typ, core.Enums.eTypQueryDef.InputParameters, qs2.core.license.doLicense.eApp.ALL.ToString(), Application);

                sbResultSkriptTmp.AppendLine(exportTSQL.sLine);
                sbResultSkriptTmp.AppendLine("-- Automatic-Script for QUERY: '" + rQueryToExport.IDRessource + "'! (Application '" + Application + "')");
                sbResultSkriptTmp.AppendLine(exportTSQL.sLine);

                this.genTSQLDeleteIDSelList(ref rQueryToExport, Application, ref sbResultSkriptTmp);
                this.genQueryAndReportIcons(ref rQueryToExport, Application, ref sbResultSkriptTmp, ref sbInfoQuery);

                sbResultSkriptTmp.AppendLine("-- Query: '" + rQueryToExport.IDRessource + "' -- Insert QueriesDefs! (Application '" + Application + "')");
                if (counter == 1)
                {
                    sbResultSkriptTmp.AppendLine("DECLARE @IDQuery int=" + rQueryToExport.ID.ToString() + "");
                }
                else
                {
                    sbResultSkriptTmp.AppendLine("Set @IDQuery=" + rQueryToExport.ID.ToString() + "");
                }
                this.genQueryDef(ref rQueryToExport, Application, core.Enums.eTypQueryDef.SelectFields, ref dsAdminFields, ref sbResultSkriptTmp);
                this.genQueryDef(ref rQueryToExport, Application, core.Enums.eTypQueryDef.WhereConditions, ref dsAdminWhere, ref sbResultSkriptTmp);
                this.genQueryDef(ref rQueryToExport, Application, core.Enums.eTypQueryDef.Joins, ref dsAdminJoins, ref sbResultSkriptTmp);
                this.genQueryDef(ref rQueryToExport, Application, core.Enums.eTypQueryDef.InputParameters, ref dsAdminInputParameters, ref sbResultSkriptTmp);
                
                if (sbInfoQuery.Length > 0)
                {
                    sbResultSkript.AppendLine(sbInfoQuery.ToString()); 
                }
                sbResultSkript.AppendLine(sbResultSkriptTmp.ToString()); 

                if (SaveSqlFile)
                {
                    this.saveTSQLFile(ref rQueryToExport, Application, ref sbResultSkript);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.ExportQuery:" + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        public void genQueryAndReportIcons(ref qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToExport, string IDApplication,
                ref StringBuilder sbResultSkript, ref StringBuilder sbInfoQuery)
        {
            try
            {
                sbResultSkript.AppendLine("-- Query: '" + rQueryToExport.IDRessource + "' -- Insert Query and Report-Icons! (Application '" + IDApplication + "')");

                // Insert Query and Query-Ressource (Delete if exists)
                this.genTSQLInsertSelList(rQueryToExport, IDApplication, ref sbResultSkript, true, false, "Insert Query '" + rQueryToExport.IDRessource + "'!" );
                this.checkGenRessource(rQueryToExport.IDRessource, IDApplication, ref sbResultSkript, ref sbInfoQuery, true);

                // check all Queries-Groups
                qs2.core.vb.dsAdmin dsAdminTmp = new qs2.core.vb.dsAdmin();
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                this.sqlAdminWork.getSelListEntrys(ref Parameters, qs2.core.Enums.eTypRunQuery.QueryGroups.ToString(),
                                                    qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication, ref dsAdminTmp, 
                                                    core.vb.sqlAdmin.eTypAuswahlList.group);
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListQueryGroup in dsAdminTmp.tblSelListEntries)
                {
                    this.sqlAdminWork.getSelListEntrysObj(rSelListQueryGroup.ID, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "Queries", dsAdminTmp, core.vb.sqlAdmin.eTypAuswahlObj.sellist, IDApplication);
                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rObjQueryInQueryGroups in dsAdminTmp.tblSelListEntriesObj)
                    {
                        if (rObjQueryInQueryGroups.IDSelListEntry.Equals(rQueryToExport.ID))
                        {
                            // Insert Query-Group and Query-Group-Ressource if not exists
                            this.genTSQLInsertSelList(rSelListQueryGroup, IDApplication, ref sbResultSkript, false, true, "Insert Query-Group '" + rSelListQueryGroup.IDRessource + "'!");
                            this.checkGenRessource(rSelListQueryGroup.IDRessource, IDApplication, ref sbResultSkript, ref sbInfoQuery, true);
                            
                            // Insert Query-Group to Query
                            this.genTSQLInsertSelListObj(rObjQueryInQueryGroups, IDApplication, ref sbResultSkript, false, 
                                                        "Delete and Insert Query to QueryGroup '" + rSelListQueryGroup.IDRessource + "'!", true);

                        }
                    }
                }

                // check all Reports
                qs2.core.vb.dsAdmin.tblSelListEntriesDataTable tSelListReports = new qs2.core.vb.dsAdmin.tblSelListEntriesDataTable();
                dsAdminTmp.Clear();
                Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                this.sqlAdminWork.getSelListEntrys(ref Parameters, "Reports",
                                                    qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication, ref dsAdminTmp,
                                                    core.vb.sqlAdmin.eTypAuswahlList.group);
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListReport in dsAdminTmp.tblSelListEntries)
                {
                    // check all Queries to Reports
                    qs2.core.vb.dsAdmin dsAdminTmp2 = new qs2.core.vb.dsAdmin();
                    this.sqlAdminWork.getSelListEntrysObj(rSelListReport.ID, core.vb.sqlAdmin.eDbTypAuswObj.SubSelList, "Queries", dsAdminTmp2, core.vb.sqlAdmin.eTypAuswahlObj.sellist, core.license.doLicense.eApp.ALL.ToString());
                    foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rObjQueryToReports in dsAdminTmp2.tblSelListEntriesObj)
                    {
                        if (rObjQueryToReports.IDSelListEntry.Equals(rQueryToExport.ID))
                        {
                            // Insert Report and Report-Ressource if not exists
                            this.genTSQLInsertSelList(rSelListReport, IDApplication, ref sbResultSkript, false, true, "Insert Report '" + rSelListReport.IDRessource + "'!");
                            this.checkGenRessource(rSelListReport.IDRessource, IDApplication, ref sbResultSkript, ref sbInfoQuery, true);
                            
                            this.genTSQLInsertSelListObj(rObjQueryToReports, IDApplication, ref sbResultSkript, true,
                                                        "Delete and Insert Query to Report '" + rSelListReport.IDRessource + "'!", false);
                            qs2.core.vb.dsAdmin.tblSelListEntriesRow rNewReport = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)tSelListReports.NewRow();
                            rNewReport.ItemArray = rSelListReport.ItemArray;
                            tSelListReports.Rows.Add(rNewReport);
                        }
                    }
                }

                // check all Reports-Groups
                dsAdminTmp.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genQueryAndReportIcons:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void genQueryDef(ref qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToExport, string Application,
                                core.Enums.eTypQueryDef TypQueryDef, ref qs2.core.vb.dsAdmin ds,
                                ref StringBuilder sbResultSkript)
        {
            try
            {
                sbResultSkript.AppendLine("--                                             Type QueryDef=" + TypQueryDef.ToString() + "");
                qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQuerDef = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])ds.tblQueriesDef.Select("", ds.tblQueriesDef.SortColumn.ColumnName + " asc");
                foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQueryDefFound in arrQuerDef)
                {
                    this.genTSQLInsertQueryDef(rQueryDefFound, Application, ref sbResultSkript);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genQueryDef:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void saveTSQLFile(ref qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToExport, string Application,
                                ref StringBuilder sbResultSkript)
        {
            try
            {
                qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
                string fileName = funct1.saveFile(false, qs2.core.vb.funct.sqlFileType, "", qs2.core.vb.funct.getFolder(Environment.SpecialFolder.DesktopDirectory));
                if (fileName != null)
                {

                    System.IO.FileStream csFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
                    System.IO.StreamWriter csFileStreamWriter = new System.IO.StreamWriter(csFileStream, System.Text.Encoding.Default);
                    csFileStreamWriter.Write(sbResultSkript.ToString());
                    csFileStreamWriter.Close();
                    csFileStream.Close();

                    if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FileWasSaved") + "!" + "\r\n" + qs2.core.language.sqlLanguage.getRes("OpenFileYN") + "?", System.Windows.Forms.MessageBoxButtons.YesNo, "") == System.Windows.Forms.DialogResult.Yes)
                        funct1.openFile(fileName, "", false);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.saveTSQLFile:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        


        public void genTSQLInsertSelList(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListToInsert, string Application,
                                            ref StringBuilder sbResultSkript, bool genDeleteCommand, bool CheckIfRowExists ,
                                            string DescriptionTSQL)
        {
            try
            {
                if (DescriptionTSQL.Trim() != "")
                {
                    sbResultSkript.AppendLine("-- " + DescriptionTSQL.Trim());
                }

                string sIDOwnInt = "";
                if (rSelListToInsert.IsIDOwnIntNull())
                {
                    sIDOwnInt = "NULL";
                }
                else
                {
                    sIDOwnInt = "" + rSelListToInsert.IDOwnInt + "";
                }

                string sSort = "";
                if (rSelListToInsert.IssortNull())
                {
                    sSort = "NULL";
                }
                else
                {
                    sSort = "" + rSelListToInsert.sort + "";
                }

                string sPicture = "";
                if (rSelListToInsert.IspictureNull())
                {
                    sPicture = "NULL";
                }
                else
                {
                    sPicture = "'" + rSelListToInsert.picture + "'";
                }

                string sCreated = "";
                if (rSelListToInsert.IsCreatedNull())
                {
                    sCreated = "NULL";
                }
                else
                {
                    sCreated = "" + qs2.core.vb.dbBase.getDateConvertSql(rSelListToInsert.Created) + "";
                }

                string sTSQLTmp = "";
                if (genDeleteCommand)
                {
                    sTSQLTmp = "Delete from " + qs2.core.dbBase.dbSchema + "[tblSelListEntries] where ID=" + rSelListToInsert.ID.ToString() + "";
                    sbResultSkript.AppendLine(sTSQLTmp.ToString());
                }
                sTSQLTmp = "";
                if (CheckIfRowExists)
                {
                    sTSQLTmp += "If ((Select Count(*) as Count from " + qs2.core.dbBase.dbSchema + "[tblSelListEntries] where ID=" + rSelListToInsert.ID.ToString() + ") = 0)" + "\r\n";
                    sTSQLTmp += "BEGIN" + "\r\n";
                }
                sTSQLTmp += "INSERT INTO " + qs2.core.dbBase.dbSchema + "[tblSelListEntries]";
                sTSQLTmp += "([ID] ,[IDGuid],[IDRessource],";
                sTSQLTmp += "[IDOwnInt],[IDOwnStr],[sort],";
                sTSQLTmp += "[IsMain],[TypeStr],[Table],[FldShortColumn],";
                sTSQLTmp += "[picture],[IDGroup],[CreatedUser],[Private],";
                sTSQLTmp += "[VersionNrFrom],[VersionNrTo],";
                sTSQLTmp += "[Classification],[Created],";
                sTSQLTmp += "[Sql],[TypeQry],[UIType],[Description],[IDParticipant],[Extern],[SubQuery])";
                sTSQLTmp += "VALUES";
                sTSQLTmp += "(" + rSelListToInsert.ID.ToString() + ",'" + rSelListToInsert.IDGuid.ToString() + "','" + rSelListToInsert.IDRessource + "',";
                sTSQLTmp += "" + sIDOwnInt + ",'" + rSelListToInsert.IDOwnStr + "'," + sSort + ",";
                sTSQLTmp += "" + this.getStrBool(rSelListToInsert.IsMain) + ",'" + rSelListToInsert.TypeStr + "','" + rSelListToInsert._Table + "','" + rSelListToInsert.FldShortColumn + "',";
                sTSQLTmp += "" + sPicture + "," + rSelListToInsert.IDGroup.ToString() + ",'" + rSelListToInsert.CreatedUser + "'," + this.getStrBool(rSelListToInsert._Private) + ",";
                sTSQLTmp += "'" + rSelListToInsert.VersionNrFrom + "','" + rSelListToInsert.VersionNrTo + "',";
                sTSQLTmp += "'" + rSelListToInsert.Classification + "'," + sCreated + ",";
                sTSQLTmp += "'" + rSelListToInsert.Sql + "','" + rSelListToInsert.TypeQry + "','" + rSelListToInsert.UIType + "','" + rSelListToInsert.Description + "','" + rSelListToInsert.IDParticipant + "'," + this.getStrBool(rSelListToInsert.Extern) + "," + this.getStrBool(rSelListToInsert.SubQuery) + ")";
                if (CheckIfRowExists)
                {
                    sTSQLTmp += "\r\n" + "END";
                }

                sbResultSkript.AppendLine(sTSQLTmp.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genTSQLInsertSelList:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void genTSQLInsertSelListObj(qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rSelListObjToInsert, string Application,
                                            ref StringBuilder sbResultSkript, bool genDeleteCommand,
                                            string DescriptionTSQL, bool CheckIfRowExists)
        {
            try
            {
                if (DescriptionTSQL.Trim() != "")
                {
                    sbResultSkript.AppendLine("-- " + DescriptionTSQL.Trim());
                }

                string sFldShort = "";
                if (rSelListObjToInsert.IsFldShortNull())
                {
                    sFldShort = "NULL";
                }
                else
                {
                    sFldShort = "'" + rSelListObjToInsert.FldShort + "'";
                }

                string sIDApplication = "";
                if (rSelListObjToInsert.IsIDApplicationNull())
                {
                    sIDApplication = "NULL";
                }
                else
                {
                    sIDApplication = "'" + rSelListObjToInsert.IDApplication + "'";
                }

                string sIDObject = "";
                if (rSelListObjToInsert.IsIDObjectNull())
                {
                    sIDObject = "NULL";
                }
                else
                {
                    sIDObject = "" + rSelListObjToInsert.IDObject + "";
                }

                string sIDSelListEntrySublist = "";
                if (rSelListObjToInsert.IsIDSelListEntrySublistNull())
                {
                    sIDSelListEntrySublist = "NULL";
                }
                else
                {
                    sIDSelListEntrySublist = "" + rSelListObjToInsert.IDSelListEntrySublist.ToString() + "";
                }

                string sIDStay = "";
                if (rSelListObjToInsert.IsIDStayNull())
                {
                    sIDStay = "NULL";
                }
                else
                {
                    sIDStay = "" + rSelListObjToInsert.IDStay.ToString() + "";
                }
                string sIDParticipantStay = "";
                if (rSelListObjToInsert.IsIDParticipantStayNull())
                {
                    sIDParticipantStay = "NULL";
                }
                else
                {
                    sIDParticipantStay = "'" + rSelListObjToInsert.IDParticipantStay.ToString() + "'";
                }
                string sIDApplicationStay = "";
                if (rSelListObjToInsert.IsIDApplicationStayNull())
                {
                    sIDApplicationStay = "NULL";
                }
                else
                {
                    sIDApplicationStay = "'" + rSelListObjToInsert.IDApplicationStay.ToString() + "'";
                }

                string sFrom = "";
                if (rSelListObjToInsert.IsFromNull())
                {
                    sFrom = "NULL";
                }
                else
                {
                    sFrom = "" + qs2.core.vb.dbBase.getDateConvertSql(rSelListObjToInsert.From) + "";
                }
                string sTo = "";
                if (rSelListObjToInsert.Is_ToNull())
                {
                    sTo = "NULL";
                }
                else
                {
                    sTo = "" + qs2.core.vb.dbBase.getDateConvertSql(rSelListObjToInsert._To) + "";
                }

                string sIDOwnInt = "";
                if (rSelListObjToInsert.IsIDOwnIntNull())
                {
                    sIDOwnInt = "NULL";
                }
                else
                {
                    sIDOwnInt = "" + rSelListObjToInsert.IDOwnInt.ToString() + "";
                }

                string sCreated = "" + qs2.core.vb.dbBase.getDateConvertSql(rSelListObjToInsert.Created) + "";
                string sModified = "" + qs2.core.vb.dbBase.getDateConvertSql(rSelListObjToInsert.Modified) + "";

                string sTSQLTmp = "";
                if (genDeleteCommand)
                {
                    sTSQLTmp = "Delete from " + qs2.core.dbBase.dbSchema  + "[tblSelListEntriesObj] where IDGuid='" + rSelListObjToInsert.IDGuid.ToString() + "'";
                    sbResultSkript.AppendLine(sTSQLTmp.ToString());
                }
                sTSQLTmp = "";
                if (CheckIfRowExists)
                {
                    sTSQLTmp += "If ((Select Count(*) as count from " + qs2.core.dbBase.dbSchema + "[tblSelListEntriesObj] where IDGuid='" + rSelListObjToInsert.IDGuid.ToString() + "') = 0)" + "\r\n";
                    sTSQLTmp += "BEGIN" + "\r\n";
                }

                string sqlIDObjectGuid = "";
                if (rSelListObjToInsert.IsIDObjectGuidNull())
                {
                    sqlIDObjectGuid = "null";
                }
                else
                {
                    sqlIDObjectGuid = "'" + rSelListObjToInsert.IDObjectGuid.ToString() + "'";
                }

                sTSQLTmp += "INSERT INTO " + qs2.core.dbBase.dbSchema + "[tblSelListEntriesObj]";
                sTSQLTmp += "([IDGuid],[FldShort],[IDApplication],[IDObject],";
                sTSQLTmp += "[IDSelListEntrySublist],[IDSelListEntry],";
                sTSQLTmp += "[IDStay],[IDParticipantStay] ,[IDApplicationStay],";
                sTSQLTmp += "[typIDGroup],[From],[To],";
                sTSQLTmp += "[IDClassification],[IDOwnInt],[Created],[CreatedBy],";
                sTSQLTmp += "[Modified],[ModifiedBy],[Description],";
                sTSQLTmp += "[Sort],[IsMain],[Active],[IDParticipant],[IDObjectGuid])";
                sTSQLTmp += "VALUES";
                sTSQLTmp += "('" + rSelListObjToInsert.IDGuid.ToString() + "'," + sFldShort + "," + sIDApplication + "," + sIDObject + ",";
                sTSQLTmp += "" + sIDSelListEntrySublist + "," + rSelListObjToInsert.IDSelListEntry.ToString() + ",";
                sTSQLTmp += "" + sIDStay + "," + sIDParticipantStay + "," + sIDApplicationStay + ",";
                sTSQLTmp += "'" + rSelListObjToInsert.typIDGroup + "'," + sFrom + "," + sTo + ",";
                sTSQLTmp += "'" + rSelListObjToInsert.IDClassification + "'," + sIDOwnInt + "," + sCreated + ",'"  + rSelListObjToInsert.CreatedBy + "',";
                sTSQLTmp += "" + sModified + ",'" + rSelListObjToInsert.ModifiedBy + "','" + rSelListObjToInsert.Description + "',";
                sTSQLTmp += "" + rSelListObjToInsert.Sort.ToString() + "," + this.getStrBool(rSelListObjToInsert.IsMain) + "," + this.getStrBool(rSelListObjToInsert.Active) + ",'" + rSelListObjToInsert.IDParticipant + "'," + sqlIDObjectGuid + ")";
                if (CheckIfRowExists)
                {
                    sTSQLTmp += "\r\n" + "END";
                }
                sbResultSkript.AppendLine(sTSQLTmp.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genTSQLInsertSelListObj:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
     
        public void genTSQLInsertQueryDef(qs2.core.vb.dsAdmin.tblQueriesDefRow rQueryDef, 
                                            string Application,
                                            ref StringBuilder sbResultSkript)
        {
            try
            {
                    string sTSQLTmp = "";

                    sTSQLTmp += "INSERT INTO " + qs2.core.dbBase.dbSchema + "[tblQueriesDef] ";
                    sTSQLTmp += "([IDGuid],[UserInput],[FunctionPar],[Combination],[QryTable],[QryColumn],";
                    sTSQLTmp += "[CriteriaFldShort],[CriteriaApplication],";
                    sTSQLTmp += "[IsSQLServerField],[Label],[ControlType],[Typ],[Condition],[ValueMin],[Max],";
                    sTSQLTmp += "[ValueMinIDRes],[MaxIDRes],[CombinationEnd],";
                    sTSQLTmp += "[freeSql],[Sort],[IDSelList],[ApplicationOwn],[ParticipantOwn],";
                    sTSQLTmp += "[All],[SpecialDefinition],[ComboAsDropDown],[ComboAsDropDownCondition],[SpecialDefinitionMax])";
                    sTSQLTmp += "VALUES";
                    sTSQLTmp += "('" + rQueryDef.IDGuid.ToString() + "'," + this.getStrBool(rQueryDef.UserInput) + "," + this.getStrBool(rQueryDef.FunctionPar) + ",'" + rQueryDef.Combination + "','" + rQueryDef.QryTable + "','" + rQueryDef.QryColumn + "',";

                    string sTmpCriteriaFldShort = "";
                    if (rQueryDef.IsCriteriaFldShortNull())
                    {
                        sTmpCriteriaFldShort = "NULL";
                    }
                    else
                    {
                        sTmpCriteriaFldShort = "'" + rQueryDef.CriteriaFldShort + "'";
                    }

                    string sTmpCriteriaApplication = "";
                    if (rQueryDef.IsCriteriaApplicationNull())
                    {
                        sTmpCriteriaApplication = "NULL";
                    }
                    else
                    {
                        sTmpCriteriaApplication = "'" + rQueryDef.CriteriaApplication + "'";
                    }

                    string sTmpControlType = "";
                    if (rQueryDef.IsControlTypeNull())
                    {
                        sTmpControlType = "NULL";
                    }
                    else
                    {
                        sTmpControlType = "'" + rQueryDef.ControlType + "'";
                    }
                    
                    sTSQLTmp += "" + sTmpCriteriaFldShort + "," + sTmpCriteriaApplication + ",";
                    sTSQLTmp += "" + this.getStrBool(rQueryDef.IsSQLServerField) + ",'" + rQueryDef.Label + "'," + sTmpControlType + ",'" + rQueryDef.Typ + "','" + rQueryDef.Condition + "','" + rQueryDef.ValueMin + "','" + rQueryDef.Max + "',";
                    sTSQLTmp += "'" + rQueryDef.ValueMinIDRes + "','" + rQueryDef.MaxIDRes + "','" + rQueryDef.CombinationEnd + "',";
                    sTSQLTmp += "'" + rQueryDef.freeSql + "'," + rQueryDef.Sort.ToString() + ",@IDQuery ,'" + rQueryDef.ApplicationOwn + "','" + rQueryDef.ParticipantOwn + "',";
                    sTSQLTmp += "" + this.getStrBool(rQueryDef.All) + ",'" + rQueryDef.SpecialDefinition.ToString() + "'," + this.getStrBool(rQueryDef.ComboAsDropDown) + ",'" + rQueryDef.ComboAsDropDownCondition + "','" + rQueryDef.SpecialDefinitionMax + "')";

                    sbResultSkript.AppendLine(sTSQLTmp.Trim());
                    
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genTSQLInsertQueryDef:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void genTSQLDeleteIDSelList(ref qs2.core.vb.dsAdmin.tblSelListEntriesRow rQueryToDelete, string Application,
                                            ref StringBuilder sbResultSkript)
        {
            try
            {
                string sTSQLTmp = "";
                sTSQLTmp = "Delete from " + qs2.core.dbBase.dbSchema + "[tblQueriesDef] where [IDSelList]=" + rQueryToDelete.ID.ToString() + "";
                sbResultSkript.AppendLine(sTSQLTmp.Trim());

                sTSQLTmp = "DELETE FROM " + qs2.core.dbBase.dbSchema + "tblSelListEntriesObj WHERE IDSelListEntry=" + rQueryToDelete.ID.ToString() + "";
                sbResultSkript.AppendLine(sTSQLTmp.Trim());

                sTSQLTmp = "DELETE FROM " + qs2.core.dbBase.dbSchema + "tblSelListEntriesObj WHERE IDSelListEntrySublist=" + rQueryToDelete.ID.ToString() + "";
                sbResultSkript.AppendLine(sTSQLTmp.Trim());

                sTSQLTmp = "DELETE FROM " + qs2.core.dbBase.dbSchema + "tblSelListEntries WHERE ID=" + rQueryToDelete.ID.ToString() + "";
                sbResultSkript.AppendLine(sTSQLTmp.Trim());

                //sbResultSkript.AppendLine("");
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genTSQLDeleteIDSelList:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void checkGenRessource(string IDRessource, string IDApplication, ref StringBuilder sbResultSkript, ref StringBuilder sbInfoQuery, bool genDeleteCommand)
        {
            try
            {
                qs2.core.language.dsLanguage.RessourcenRow rResFound = qs2.core.language.sqlLanguage.getResRow(IDRessource, core.Enums.eResourceType.Label,
                                                    qs2.core.license.doLicense.eApp.ALL.ToString(), IDApplication);
                if (rResFound != null)
                {
                    this.genTSQLInsertRessource(rResFound, ref sbResultSkript, true);
                }
                else
                {
                    rResFound = qs2.core.language.sqlLanguage.getResRow(IDRessource, core.Enums.eResourceType.Label,
                                    qs2.core.license.doLicense.eApp.ALL.ToString(), qs2.core.license.doLicense.eApp.ALL.ToString());
                    if (rResFound != null)
                    {
                        this.genTSQLInsertRessource(rResFound, ref sbResultSkript, true);
                    }
                    else
                    {
                        //this.genTSQLInsertRessource(rResFound, ref sbResultSkript, false);
                        string sInfo = "-- Info '" + IDRessource + "': No Translation found for IDRessource!";
                        sbInfoQuery.AppendLine(sInfo);
                        //throw new Exception(sInfo);  
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.checkGenRessource:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void genTSQLInsertRessource(qs2.core.language.dsLanguage.RessourcenRow rResFound, 
                                            ref StringBuilder sbResultSkript, bool genDeleteCommand)
        {
            try
            {
                string sFileByte = "";
                if (rResFound.IsfileBytesNull())
                {
                    sFileByte = "null";
                }
                else
                {
                    sFileByte = "'" + rResFound.fileBytes.ToString() + "'";
                }
                string sCreated = "" + qs2.core.vb.dbBase.getDateConvertSql(rResFound.Created) + "";
                string sLastChange = "" + qs2.core.vb.dbBase.getDateConvertSql(rResFound.LastChange) + "";

                string sTSQLTmp = "";
                if (genDeleteCommand)
                {
                    sTSQLTmp = "Delete from " + qs2.core.dbBase.dbSchema + "[Ressourcen] where IDRes='" + rResFound.IDRes + "' and IDLanguageUser='" + rResFound.IDLanguageUser + "' and ";
                    sTSQLTmp += "IDApplication='" + rResFound.IDApplication + "' and IDParticipant='" + rResFound.IDParticipant + "' and Type='" + rResFound.Type + "'";
                    sTSQLTmp += "\r\n";
                }

                sTSQLTmp += "INSERT INTO " + qs2.core.dbBase.dbSchema + "[Ressourcen]";
                sTSQLTmp += "([IDRes],[English],[German],[User],";
                sTSQLTmp += "[IDLanguageUser],[Description],[IDApplication],[IDParticipant],";
                sTSQLTmp += "[Type],[TypeSub],[fileBytes],[fileType],[Created],[CreatedUser],[IDGuid],";
                sTSQLTmp += "[Image],[ImageWidth],[ImageHeigth],[Classification],[LastChange],[ResGroup])";
                sTSQLTmp += " VALUES";
                sTSQLTmp += "('" + rResFound.IDRes + "','" + rResFound.English + "','" + rResFound.German + "','" + rResFound.User + "',";
                sTSQLTmp += "'" + rResFound.IDLanguageUser + "','" + rResFound.Description + "','" + rResFound.IDApplication + "','" + rResFound.IDParticipant + "',";
                sTSQLTmp += "'" + rResFound.Type + "','" + rResFound.TypeSub + "'," + sFileByte + ",'" + rResFound.fileType + "'," + sCreated + ",'" + rResFound.CreatedUser + "','" + rResFound.IDGuid.ToString() + "',";
                sTSQLTmp += "'" + rResFound.Image + "'," + rResFound.ImageWidth + "," + rResFound.ImageHeigth + ",'" + rResFound.Classification + "'," + sLastChange + ",'" + rResFound.ResGroup + "')";
               
                sbResultSkript.AppendLine(sTSQLTmp.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("exportTSQL.genTSQLInsertRessource:" + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
      



        public string getStrBool(bool boolValue)
        {
            if (boolValue)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public void AppendTitle(StringBuilder sb)
        {
            sb.AppendLine("-- AUTO-SKRIPT QS2 for Queries and Reports from '" + DateTime.Now.ToString() + "', User: " + qs2.core.vb.actUsr.rUsr.UserName + ", from Db:" + qs2.core.ENV.Server + ":" + qs2.core.ENV.Database + "");
            sb.AppendLine(exportTSQL.sLine);
        }

    }
}
