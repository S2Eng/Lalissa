using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using qs2.core;
using qs2.core.vb;
using System.Globalization;
using System.Web;
using System.IO;
using S2Extensions;

namespace qs2.sitemap.print
{


    public class genSql
    {
        
        public sqlAdmin sqlAdmin1;
        public dsAdmin dsAdmin1;

        //public qs2.core.generic generic1 { get; set; } = new qs2.core.generic();

        public enum eTypDoJoins
        {
            tableEntry = 0,
            fieldEntry = 1
        }

        public class sqlFix
        {
            public string SqlCommand = "";
            public bool sqlConditionExists = false;
            public System.Collections.Generic.List<string> lstSqlFixparameter = new System.Collections.Generic.List<string>();
        }
        public class subQuery
        {
            public dsAdmin.tblSelListEntriesRow rSelListQrySub = null;
            public dsAdmin.tblSelListEntriesObjRow rSelListQryObjSub = null;
            public dsAdmin.tblSelListEntriesRow rSelListReportSub = null;

            public dsAdmin.tblQueriesDefDataTable tQryConditionsSub = new dsAdmin.tblQueriesDefDataTable();
            public dsAdmin.tblQueriesDefDataTable tParFunctParSub = new dsAdmin.tblQueriesDefDataTable();
        }

        public class cDataSql
        {
            public System.Collections.Generic.List<cInnerJoin> lstInnerJoins = new List<cInnerJoin>();
        }

        public static int ParAliasNextNr = 0;
        public class cInnerJoin
        {
            public System.Collections.Generic.List<string> lstTablesForinnerJoin = new List<string>();
        }









        public void initControl()
        {
            try
            {
                this.sqlAdmin1 = new sqlAdmin();
                this.sqlAdmin1.initControl();
                this.dsAdmin1 = new dsAdmin();
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        
        public string doSql(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tFields,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tParFct,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tInputFieldsxy,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tJoins, ref string prot,
                                    bool withParameters,
                                    System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                    ref System.Collections.Generic.List<qs2.sitemap.print.genSql.subQuery> lstSubQueries,
                                    dsAdmin.tblSelListEntriesRow rSelListQry,
                                    ref System.Collections.Generic.List<sqlFix> lstSqlFix,
                                    ref string sqlWhereReturn, ref string WhereClauselForSimpleFunctionsReturn, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    ref string sqlForAdmin, ref cDataSql DataSql, ref string sqlWhereAdminReturn)
        {
            try
            {
                genSql.ParAliasNextNr = 0;
                this.initControl();

                int Sort = 0;

                //CheckSchalter: 1. richige Sql-Felder für SimpleFct oder SimpleViews
                string sqlFields = this.doSqlFields(tFields, null, null, ref prot, false, ref Sort, ref rSelListQry);

                //CheckSchalter: 2. no Joins for SimpleFct oder SimpleViews
                string sqlWhereJoins = "";
                //bool doSqlSrvField = false;
                if (rSelListQry.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.FullMode.ToString().ToLower()))
                {
                    throw new Exception("doSql: eQueryType.FullMode not allowed!");
                    //sqlWhereJoins = this.doJoins(tJoins, ref prot);
                }
                
                //string sqlStandardFields = this.doSqlAddStandardFields_tblStay(tFields, ref tables, ref prot);
                //sqlFields += (sqlFields.Trim().Equals("") ? sqlStandardFields : ", " + sqlStandardFields);
                //if (sqlFields.Equals(""))
                //    sqlFields = qs2.core.sqlTxt.select + " * ";

                string sqlParameterFunction = "";
                string sqlWhereConditions = "";
                string sqlWhereConditionsSubQuery = "";
                string WhereClauselForSimpleFunctions = "";
                string SqlWhereAdmin = "";
                this.doSqlConditions(tConditions, tParFct, ref prot, withParameters, parametersSql, false,
                                        ref sqlParameterFunction, rSelListQry, true, ref lstSqlFix, ref sqlWhereConditions,
                                        ref WhereClauselForSimpleFunctions, false, ref lstParForExternFct, false, ref SqlWhereAdmin, ref DataSql);
                //CheckSchalter: 3. if SimpleFct -> WhereClauselForSimpleFunctions -> one Where-String for doTables 

                
                foreach (qs2.sitemap.print.genSql.subQuery subQuery in lstSubQueries)
                {
                    if (!rSelListQry.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.FullMode.ToString().ToLower()))
                    {
                        //lthxy
                        //foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in subQuery.tQryConditionsSub)
                        //{
                        //    rQry.QryTable = rSelListQry._Table;
                        //}
                        //foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in subQuery.tParFunctParSub)
                        //{
                        //    rQry.QryTable = rSelListQry._Table;
                        //}
                    }

                    //bool SubQueryIsOK = false;
                    qs2.sitemap.print.print print1 = new qs2.sitemap.print.print();
                    qs2.core.Enums.eStayTyp StayTypeMainQuery = print1.getTypeQuery(rSelListQry.Classification.Trim());
                    qs2.core.Enums.eStayTyp StayTypeSubQuery = print1.getTypeQuery(subQuery.rSelListQrySub.Classification.Trim());

                    //if (StayTypeSubQuery == StayTypeMainQuery &&
                    //    rSelListQry.Classification != "" &&
                    //    rSelListQry.Classification != "")
                    //{
                    //    SubQueryIsOK = true;
                    //}

                    //if (!SubQueryIsOK)
                    //{
                    //    throw new Exception("genSql.doSql: SubQuery '" + subQuery.rSelListQrySub.IDRessource + "' has an other Classification-Type as the MainQUery '" + rSelListQry.IDRessource + "'!");
                    //}
                    //else
                    //{
                    //    string xy = "";
                    //}
                    this.doSqlConditions(subQuery.tQryConditionsSub, subQuery.tParFunctParSub, ref prot, 
                                        withParameters, parametersSql, false, ref sqlParameterFunction, rSelListQry, false,
                                        ref lstSqlFix, ref sqlWhereConditionsSubQuery,
                                        ref WhereClauselForSimpleFunctions, true, ref lstParForExternFct, false, ref SqlWhereAdmin, ref DataSql);
                }  

                //string sqlWhereStays = this.doSqlConditions(null, false, ref tables, ref prot, true, null, withParameters, null);
                //sqlWhere += this.doSqlConditions(tInputFields, true, ref tables, ref prot, false, sqlWhere, tQryPar, withParameters);
                
                System.Collections.Generic.List<string> tables = new System.Collections.Generic.List<string>();
                this.saveTables(ref tFields, ref tables);
                this.saveTables(ref tConditions, ref tables);
                this.saveTables(ref tJoins, ref tables);
                foreach (qs2.sitemap.print.genSql.subQuery subQuery in lstSubQueries)
                {
                    this.saveTables(ref subQuery.tQryConditionsSub, ref tables);
                }

                string sqlParameterFunctionTables = "";
                string sqlTables = "";
                string SqlWhereNoParFunct = "";
                this.doTables2(ref tables, tConditions, tParFct, ref prot, withParameters, parametersSql, 
                                ref sqlParameterFunctionTables, rSelListQry, ref lstSqlFix, ref sqlTables,
                                ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref lstParForExternFct, ref SqlWhereNoParFunct,
                                ref DataSql);
                
                sqlTables = (!sqlTables.Trim().Equals("") ? qs2.core.sqlTxt.from + sqlTables : "");

                sqlWhereConditions = (sqlWhereConditions.Trim() != "" ? qs2.core.generic.lineBreak + (sqlWhereJoins.Trim() == "" ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + sqlWhereConditions : "");
                                sqlWhereConditions = sqlWhereConditions.Trim();
                if (sqlWhereConditionsSubQuery.Trim() != "")
                {
                    if (sqlWhereConditions.Trim() == "")
                        sqlWhereConditionsSubQuery = (sqlWhereConditionsSubQuery.Trim() != "" ? qs2.core.generic.lineBreak + (sqlWhereJoins.Trim() == "" ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + sqlWhereConditionsSubQuery : "");
                    else
                        sqlWhereConditionsSubQuery = qs2.core.sqlTxt.and + sqlWhereConditionsSubQuery;
                }
                
                string sqlWhereConditionsEnd  = sqlWhereJoins + sqlWhereConditions + sqlWhereConditionsSubQuery;
                if (sqlWhereConditionsEnd != "")
                {
                    if (sqlWhereConditionsEnd.Length > 3)
                    {
                        if (sqlWhereConditionsEnd.Substring(0, 3).ToLower() == ("and").ToLower())
                        {
                            sqlWhereConditionsEnd = sqlWhereConditionsEnd.Substring(3, sqlWhereConditionsEnd.Length - 3);
                            sqlWhereConditionsEnd = " where " + sqlWhereConditionsEnd + " ";
                        }
                    }
                    if (sqlWhereConditionsEnd.Length > 2)
                    {
                        if (sqlWhereConditionsEnd.Substring(0, 2).ToLower() == ("OR").ToLower())
                        {
                            sqlWhereConditionsEnd = sqlWhereConditionsEnd.Substring(2, sqlWhereConditionsEnd.Length - 2);
                            sqlWhereConditionsEnd = " where " + sqlWhereConditionsEnd + " ";
                        }
                    }
                }

                string sqlInnerJoins = "";
                this.genInnerJoin(ref DataSql, ref rSelListQry, ref sqlInnerJoins, ref sqlWhereConditionsEnd, ref SqlWhereAdmin);

                string sql = sqlFields + qs2.core.generic.lineBreak + sqlTables + sqlWhereConditionsEnd;
                sqlWhereReturn = sqlWhereConditionsEnd;
                WhereClauselForSimpleFunctionsReturn = WhereClauselForSimpleFunctions;      //+ sqlInnerJoins;
                sqlWhereAdminReturn = SqlWhereAdmin;
                sqlForAdmin = sqlFields + qs2.core.generic.lineBreak + sqlTables + qs2.core.generic.lineBreak + SqlWhereAdmin;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doSql:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }
        public void genInnerJoin(ref cDataSql DataSql, ref dsAdmin.tblSelListEntriesRow rSelListQry,
 
        ref string sqlInnerJoins, ref string sqlWhereConditionsEnd, ref string SqlWhereAdmin)
        {
            try
            {
                if (DataSql.lstInnerJoins.Count > 0)
                {
                    foreach (cInnerJoin InnerJoin in DataSql.lstInnerJoins)
                    {
                        string MainTable = "";
                        System.Collections.Generic.List<string> lstSubTables = new List<string>();
                        foreach (string TableForInnerJoin in InnerJoin.lstTablesForinnerJoin)
                        {
                            if (rSelListQry._Table.Trim().ToLower().Equals(TableForInnerJoin.Trim().ToLower()))
                            {
                                MainTable = TableForInnerJoin.Trim();
                            }
                            else
                            {
                                lstSubTables.Add(TableForInnerJoin.Trim());
                            }
                        }
                        if (MainTable.Trim() == "")
                        {
                            throw new Exception("genSql.doSql: MainTable='' not possible for Query ''!");
                        }
                        foreach (string SubTable in lstSubTables)
                        {
                            sqlInnerJoins += (sqlInnerJoins.Trim() == "" ? "" : " and ") + " " + SubTable.Trim() + ".IDGuid=" + MainTable.Trim() + ".IDGuid ";
                        }

                        if (sqlWhereConditionsEnd.Trim() != "" && sqlWhereConditionsEnd.Trim().ToLower().Contains(("where").Trim().ToLower()))
                        {
                            sqlWhereConditionsEnd += " and " + sqlInnerJoins;
                        }
                        else
                        {
                            sqlWhereConditionsEnd += " where " + sqlInnerJoins;
                        }
                        if (SqlWhereAdmin.Trim() != "" && SqlWhereAdmin.Trim().ToLower().Contains(("where").Trim().ToLower()))
                        {
                            SqlWhereAdmin += " and " + sqlInnerJoins;
                        }
                        else
                        {
                            SqlWhereAdmin += " where " + sqlInnerJoins;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.genInnerJoin:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }


        public bool calcJoinStandard(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tFields,
                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions,
                    ref qs2.core.vb.dsAdmin dsJoinsResult,
                    ref string prot, ref dsAdmin.tblSelListEntriesRow rSelListEntry)
        {
            try
            {
                this.initControl();
                dsObjects dsObjTemp = new dsObjects();

                qs2.core.vb.dsAdmin dsJoinsAllFields = new qs2.core.vb.dsAdmin();
                dsJoinsAllFields.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameIDJoin, typeof(System.Guid));
                dsJoinsAllFields.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameType, typeof(string));

                qs2.core.vb.dsAdmin dsJoinsOnlyTables = new qs2.core.vb.dsAdmin();
                dsJoinsOnlyTables.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameIDJoin, typeof(System.Guid));
                dsJoinsOnlyTables.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameType, typeof(string));

                int Sort = 0;
                //dsObjects.tblStayDataTable tStay = new dsObjects.tblStayDataTable();
                //System.Guid IDJoin = System.Guid.NewGuid();
                //IDJoin = this.addQry("", tStay.TableName, "", "", ref Sort, dsJoinsOnlyTables, eTypDoJoins.tableEntry, IDJoin);
                //this.addQry("", tStay.TableName, tStay.IDColumn.ColumnName, "", ref Sort, dsJoinsAllFields, eTypDoJoins.fieldEntry, IDJoin);

                this.doSqlFields(tFields, dsJoinsOnlyTables, dsJoinsAllFields, ref prot, true, ref Sort, ref rSelListEntry);
                this.doTablesConditions(tConditions, dsJoinsOnlyTables, dsJoinsAllFields, ref Sort, ref prot);

                // build Conditions
                int SortNeu = -1;
                string sID = dsObjTemp.tblStay.IDColumn.ColumnName;
                string sIDParticipant = dsObjTemp.tblStay.IDParticipantColumn.ColumnName;
                string sIDApplication = dsObjTemp.tblStay.IDApplicationColumn.ColumnName;

                // Search for tblStay and when exists -> Build Conditions
                dsAdmin.tblQueriesDefRow[] arrQryTablesStayFound = (dsAdmin.tblQueriesDefRow[])dsJoinsOnlyTables.tblQueriesDef.Select(dsJoinsOnlyTables.tblQueriesDef.QryTableColumn.ColumnName + qs2.core.sqlTxt.like + "'" + dsObjTemp.tblStay.TableName + qs2.core.sqlTxt.likePercEnd);
                if (arrQryTablesStayFound.Length > 0)
                {
                    foreach (dsAdmin.tblQueriesDefRow rQryTable in arrQryTablesStayFound)
                    {
                        if (rQryTable.QryTable != dsObjTemp.tblStay.TableName && arrQryTablesStayFound.Length > 0)
                        {
                            if (rQryTable.QryTable != dsObjTemp.tblStay.TableName && rQryTable.QryTable != dsJoinsResult.tblStayAdditions.TableName)
                            {
                                SortNeu += 1;
                                string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sID, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, sID, "", ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sIDParticipant, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, sIDParticipant, "", ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sIDApplication, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, sIDApplication, "", ref SortNeu, ref dsJoinsResult);
                            }
                            else if (rQryTable.QryTable != dsObjTemp.tblStay.TableName && rQryTable.QryTable == dsJoinsResult.tblStayAdditions.TableName)
                            {
                                SortNeu += 1;
                                string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sID, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, dsJoinsResult.tblStayAdditions.IDStayParentColumn.ColumnName, "", ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sIDParticipant, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, dsJoinsResult.tblStayAdditions.IDParticipantStayParentColumn.ColumnName, "", ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sIDApplication, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                SortNeu += 1;
                                this.addNewJoinDsResult("", rQryTable.QryTable, dsJoinsResult.tblStayAdditions.IDApplicationStayParentColumn.ColumnName, "", ref SortNeu, ref dsJoinsResult);
                            }
                        }
                        else
                        {
                            //SortNeu += 1;
                            //string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                            //this.addNewJoinDsResult(nextCombonation, dsObjTemp.tblStay.TableName, sID, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);
                        }
                    }
                }

                // Search for Tables(Not Table Stays) and build Conditions
                dsAdmin.tblQueriesDefRow[] arrQryTablesFound = (dsAdmin.tblQueriesDefRow[])dsJoinsOnlyTables.tblQueriesDef.Select(dsJoinsOnlyTables.tblQueriesDef.QryTableColumn.ColumnName + qs2.core.sqlTxt.not + qs2.core.sqlTxt.like + "'" + dsObjTemp.tblStay.TableName + qs2.core.sqlTxt.likePercEnd);
                if (arrQryTablesFound.Length > 0)
                {
                    foreach (dsAdmin.tblQueriesDefRow rQryTable in arrQryTablesFound)
                    {
                        // Auto-Join Object.id-Stay.IDPatient
                        if (rQryTable.QryTable == dsObjTemp.tblObject.TableName)
                        {
                            SortNeu += 1;
                            string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                            this.addNewJoinDsResult(nextCombonation, rQryTable.QryTable, sID, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                            dsAdmin.tblQueriesDefRow[] arrQryTablesFoundStays = (dsAdmin.tblQueriesDefRow[])dsJoinsResult.tblQueriesDef.Select(dsJoinsResult.tblQueriesDef.QryTableColumn.ColumnName + qs2.core.sqlTxt.equals + "'" + dsObjTemp.tblStay.TableName + "'");
                            if (arrQryTablesFound.Length > 0)
                            {
                                SortNeu += 1;    //lthGuid
                                this.addNewJoinDsResult("", dsObjTemp.tblStay.TableName, dsObjTemp.tblStay.PatIDGuidColumn.ColumnName, "", ref SortNeu, ref dsJoinsResult);
                            }
                        }
                        else
                        {
                            // Auto-Join Adress.idObject-Object.id
                            if (rQryTable.QryTable == dsObjTemp.tblAdress.TableName)
                            {
                                SortNeu += 1;
                                string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);    //lthGuid
                                this.addNewJoinDsResult(nextCombonation, rQryTable.QryTable, dsObjTemp.tblAdress.IDGuidObjectColumn.ColumnName, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                                dsAdmin.tblQueriesDefRow[] arrQryTablesFoundStays = (dsAdmin.tblQueriesDefRow[])dsJoinsResult.tblQueriesDef.Select(dsJoinsResult.tblQueriesDef.QryTableColumn.ColumnName + qs2.core.sqlTxt.equals + "'" + dsObjTemp.tblObject.TableName + "'");
                                if (arrQryTablesFound.Length > 0)
                                {
                                    SortNeu += 1;
                                    this.addNewJoinDsResult("", dsObjTemp.tblObject.TableName, dsObjTemp.tblObject.IDColumn.ColumnName, "", ref SortNeu, ref dsJoinsResult);
                                }
                            }
                            else
                            {
                                SortNeu += 1;
                                string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                                this.addNewJoinDsResult(nextCombonation, rQryTable.QryTable, sID, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);
                            }
                        }
                    }
                }

                foreach (dsAdmin.tblQueriesDefRow rQryTable in dsJoinsResult.tblQueriesDef)
                {
                    rQryTable.SetControlTypeNull();
                    rQryTable.Typ = core.Enums.eTypQueryDef.Joins.ToString();
                    rQryTable.IDSelList = rSelListEntry.ID;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.calcJoinStandard:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        public bool calcJoinTable(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tFields,
                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions,
                    ref qs2.core.vb.dsAdmin dsJoinsResult,
                    ref string prot, ref dsAdmin.tblSelListEntriesRow rSelListEntry)
        {
            try
            {
                this.initControl();
                dsObjects dsObjTemp = new dsObjects();

                qs2.core.vb.dsAdmin dsJoinsAllFields = new qs2.core.vb.dsAdmin();
                dsJoinsAllFields.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameIDJoin, typeof(System.Guid));
                dsJoinsAllFields.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameType, typeof(string));

                qs2.core.vb.dsAdmin dsJoinsOnlyTables   = new qs2.core.vb.dsAdmin();
                dsJoinsOnlyTables.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameIDJoin, typeof(System.Guid));
                dsJoinsOnlyTables.tblQueriesDef.Columns.Add(qs2.core.generic.columnNameType, typeof(string));

                this.sqlAdmin1.getQueryJoinsTemp(System.Guid.Empty, dsJoinsResult, sqlAdmin.eTypSelQueryJoinsTemp.all);
                //dsJoinsResult.tblQueryJoinsTemp.Columns.Add(qs2.core.generic.columnUsed, typeof(bool));
                //dsJoinsResult.tblQueryJoinsTemp.Columns.Add(qs2.core.generic.columnNameType, typeof(string));
                
                int SortNeu = -1;
                int Sort = 0;
                this.doSqlFields(tFields, dsJoinsOnlyTables, dsJoinsAllFields, ref prot, true, ref Sort, ref rSelListEntry);
                this.doTablesConditions(tConditions, dsJoinsOnlyTables, dsJoinsAllFields, ref Sort, ref prot);

                System.Collections.Generic.List<dsAdmin.tblQueryJoinsTempRow> arrJoinsFound = new System.Collections.Generic.List<dsAdmin.tblQueryJoinsTempRow>();
                this.getJoinsFromTemp(dsJoinsResult.tblQueryJoinsTemp, ref arrJoinsFound, dsJoinsOnlyTables);
                foreach (dsAdmin.tblQueryJoinsTempRow rJoinTempFrom in arrJoinsFound)
                {
                    SortNeu += 1;
                    string nextCombonation = (SortNeu == 0 ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                    this.addNewJoinDsResult(nextCombonation, rJoinTempFrom.FromTable, rJoinTempFrom.FromColumn, qs2.core.sqlTxt.equals, ref SortNeu, ref dsJoinsResult);

                    SortNeu += 1;
                    this.addNewJoinDsResult("", rJoinTempFrom.ToTable, rJoinTempFrom.ToColumn, "", ref SortNeu, ref dsJoinsResult);
                }

                foreach (dsAdmin.tblQueriesDefRow rQryTable in dsJoinsResult.tblQueriesDef)
                {
                    rQryTable.SetControlTypeNull();
                    rQryTable.Typ = core.Enums.eTypQueryDef.Joins.ToString();
                    rQryTable.IDSelList = rSelListEntry.ID;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.calcJoinTable:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        public void getJoinsFromTemp(dsAdmin.tblQueryJoinsTempDataTable tblQueryJoinsTemp, 
                                    ref System.Collections.Generic.List<dsAdmin.tblQueryJoinsTempRow> arrJoinTempFound,
                                    qs2.core.vb.dsAdmin dsJoinsOnlyTables)
        {
            foreach (dsAdmin.tblQueryJoinsTempRow rJoinTemp in tblQueryJoinsTemp)
            {
                //if (rJoinTemp.alwaysDoJoin)
                //{
                //}

                bool tableFoundFrom = false;
                bool tableFoundTo = false;
                foreach (dsAdmin.tblQueriesDefRow rQryTable in dsJoinsOnlyTables.tblQueriesDef)
                {
                    if (rJoinTemp.FromTable.Trim() == rQryTable.QryTable.Trim())
                    {
                        tableFoundFrom = true;
                    }
                }
                foreach (dsAdmin.tblQueriesDefRow rQryTable in dsJoinsOnlyTables.tblQueriesDef)
                {
                    if (rJoinTemp.ToTable.Trim() == rQryTable.QryTable.Trim())
                    {
                        tableFoundTo = true;
                    }
                }
                if ((tableFoundFrom && tableFoundTo) || (tableFoundFrom && rJoinTemp.alwaysDoJoin))
                {
                    arrJoinTempFound.Add(rJoinTemp);
                }
             }
        }


        public bool addNewJoinDsResult(string Combination, string table, string column,
                                        string condition, ref int Sort, ref dsAdmin dsJoinsResult)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblQueriesDefRow rNewJoin = this.sqlAdmin1.addRowQueriesDef(dsJoinsResult.tblQueriesDef);
                rNewJoin.Combination = Combination;
                rNewJoin.QryTable = table;
                rNewJoin.QryColumn = column;
                rNewJoin.Condition = condition;
                rNewJoin.Sort = Sort;   

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.addNewJoinDsResult:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return false;
            }
        }

        public dsAdmin.tblQueriesDefRow getRowTableStay(dsAdmin dsJoinsOnlyTables)
        {
            try
            {
                dsObjects dsObjTemp = new dsObjects();
                dsAdmin.tblQueriesDefRow[] arrQryTablesFound = (dsAdmin.tblQueriesDefRow[])dsJoinsOnlyTables.tblQueriesDef.Select(dsJoinsOnlyTables.tblQueriesDef.QryTableColumn.ColumnName + qs2.core.sqlTxt.equals + "'" + dsObjTemp.tblStay.TableName + "'");
                if (arrQryTablesFound.Length > 0)
                    return arrQryTablesFound[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getRowTableStay:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }

        public void saveTables(ref qs2.core.vb.dsAdmin.tblQueriesDefDataTable tJoins, ref System.Collections.Generic.List<string> tables)
        {
            try
            {
                foreach (dsAdmin.tblQueriesDefRow rQryTable in tJoins)
                {
                    bool exists = false;
                    foreach(string tableExists in tables)
                    {
                        if (rQryTable.QryTable.Trim() == tableExists.Trim())
                            exists = true;
                    }
                    if (!exists && !rQryTable.Placeholder)
                        tables.Add(rQryTable.QryTable);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.saveTables:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        
        public void doTables2(ref System.Collections.Generic.List<string> tables, 
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tParFct,
                                    ref string prot,
                                    bool withParameters,
                                    System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                    ref string sqlParameterFunctionxy,
                                    dsAdmin.tblSelListEntriesRow rSelListQry,
                                    ref System.Collections.Generic.List<sqlFix> lstSqlFix,
                                    ref string sqlTables, ref string WhereClauselForSimpleFunctions, ref bool viewIsFunction,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    ref string SqlWhereNoParFunct, ref cDataSql DataSql)
        {
            try
            {
                if (tables.Count > 1)
                {
                    cInnerJoin newInnerJoin = new cInnerJoin();
                    newInnerJoin.lstTablesForinnerJoin = tables;
                    DataSql.lstInnerJoins.Add(newInnerJoin);
                }

                foreach (string tableFound in tables)
                {
                    string sqlParameterFunctionTmp = "";
                    sqlTables += (sqlTables == "" ? "" : ", ");
                    if (qs2.core.dbBase.viewIsFunction2(tableFound))
                    {
                        viewIsFunction = true;
                        string sqlWhere = "";
                        sqlTables += qs2.core.dbBase.getFunctionName(tableFound);

                        string dummyWhereNotUsed = "";
                        this.doSqlConditions(tConditions, tParFct, ref prot, true, parametersSql,  true, ref sqlParameterFunctionTmp, rSelListQry,
                                                false, ref lstSqlFix, ref sqlWhere, ref dummyWhereNotUsed, false, ref lstParForExternFct, true, ref SqlWhereNoParFunct, ref DataSql);

                        //CheckSchalter: 8. WhereClauselForSimpleFunctions (wenn leer dann leerstring mit '') integrieren mit '' dazwischen + Parameter wie immer mit neuem Datumsformat übergeben

                        string sqlParameterFunctionSum = "";
                        if (WhereClauselForSimpleFunctions.Trim() == "")
                        {
                            sqlParameterFunctionSum = "''";
                        }
                        else
                        {
                            sqlParameterFunctionSum =  "'" + WhereClauselForSimpleFunctions.Trim() + "'";
                        }
                        if (sqlParameterFunctionTmp.Trim() != "")
                        {
                            sqlParameterFunctionSum += sqlParameterFunctionTmp.Trim();
                        }
                        
                        sqlTables += "(" + sqlParameterFunctionSum.Trim() + ") ";
                    }
                    else
                    {
                        sqlTables += tableFound; 
                    }
                }
                //sqlTables = (!sqlTables.Trim().Equals("") ? qs2.core.sqlTxt.from + sqlTables : "");
                sqlTables += " ";
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doTables:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
    

        public System.Guid addQry(string Combination, string table, string Column, string Condition, string CombinationEnd, ref int Sort,
                            dsAdmin dsQry, eTypDoJoins typDoJoins, System.Guid IDJoin)
        {
            try
            {
                if (typDoJoins == eTypDoJoins.tableEntry)
                {
                    qs2.core.vb.dsAdmin.tblQueriesDefRow[] arrQryCheck = (qs2.core.vb.dsAdmin.tblQueriesDefRow[])dsQry.tblQueriesDef.Select(dsQry.tblQueriesDef.QryTableColumn.ColumnName + "='" + table.Trim() + "'");
                    if (arrQryCheck.Length == 1)
                    {
                        return (System.Guid)arrQryCheck[0][qs2.core.generic.columnNameIDJoin]; 
                    }
                    else if (arrQryCheck.Length == 0)
                    {
                        IDJoin = System.Guid.NewGuid();
                    }
                    else if (arrQryCheck.Length > 1)
                    {
                        throw new Exception("addQry: IDJoin for Table-Join more than in one Row!");
                    }
                }

                qs2.core.vb.dsAdmin.tblQueriesDefRow rNewEdit = this.sqlAdmin1.addRowQueriesDef(dsQry.tblQueriesDef);
                rNewEdit.Typ = qs2.core.Enums.eTypQueryDef.Joins.ToString();
                
                rNewEdit.Combination = Combination;
                rNewEdit.QryTable = table;
                rNewEdit.QryColumn = Column;
                rNewEdit.Condition = Condition;
                rNewEdit.CombinationEnd = CombinationEnd;

                rNewEdit.Sort = Sort;
                rNewEdit[qs2.core.generic.columnNameIDJoin] = IDJoin;
                rNewEdit[qs2.core.generic.columnNameType] = typDoJoins.ToString();

                return System.Guid.NewGuid();
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.addQry:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return System.Guid.NewGuid();
            }
        }

        public string doSqlFields(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tFields, qs2.core.vb.dsAdmin dsJoinsOnlyTables, qs2.core.vb.dsAdmin dsJoinsAllFields,
                                ref string prot, bool doTables, ref int Sort, ref dsAdmin.tblSelListEntriesRow rSelListQry)
        {
            try
            {
                if (!tFields.Columns.Contains(qs2.core.generic.columnNewName))
                {
                    tFields.Columns.Add(qs2.core.generic.columnNewName, typeof(string));
                }

                string sql = "";
                dsAdmin.tblQueriesDefRow[] arrQueries = (dsAdmin.tblQueriesDefRow[])tFields.Select("", tFields.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueries.Length > 0)
                {
                    foreach (dsAdmin.tblQueriesDefRow rQueryClear in arrQueries)
                    {
                        rQueryClear[qs2.core.generic.columnNewName] = "";
                    }

                    // check for double-Fields
                    foreach (dsAdmin.tblQueriesDefRow rQueryOrig in arrQueries)
                    {
                        int counterDoubleField = 0;
                        foreach (dsAdmin.tblQueriesDefRow rQueryCheck in arrQueries)
                        {
                            if (rQueryCheck.QryColumn.Equals(rQueryOrig.QryColumn))
                            {
                                if (counterDoubleField > 0 && rQueryOrig[qs2.core.generic.columnNewName].ToString().Trim() == "")
                                    rQueryCheck[qs2.core.generic.columnNewName] = rQueryCheck.QryColumn + counterDoubleField.ToString();
                                counterDoubleField += 1;
                            }
                        }
                    }

                    string sGrpTabblePrefix = "";
                    foreach (dsAdmin.tblQueriesDefRow rQuery in arrQueries)
                    {
                        //CheckSchalter: 2. richige Sql-Felder für SimpleFct oder SimpleViews
                        bool doSqlSrvField = false;
                        if (rSelListQry.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleView.ToString().ToLower()) ||
                            rSelListQry.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower()))
                        {
                            doSqlSrvField = true;
                        }
                        else if (rQuery.IsSQLServerField)
                        {
                            doSqlSrvField = true;
                        }

                        if (rQuery.Placeholder)
                        {
                            sql += (String.IsNullOrWhiteSpace(sql) ? "" : ", ");
                            sql += "'' as [" + rQuery.QryColumn + "]";
                        }
                        else
                        {
                            if (doSqlSrvField)
                            {
                                sql += (String.IsNullOrWhiteSpace(sql) ? "" : ", ");
                                if (qs2.core.dbBase.viewIsFunction2(rQuery.QryTable))
                                {
                                    if (rQuery[qs2.core.generic.columnNewName].ToString().Trim().Length > 0)
                                        sql += qs2.core.dbBase.getFunctionName(rQuery.QryTable) + ".[" + rQuery.QryColumn + "] as [" + rQuery[qs2.core.generic.columnNewName].ToString().Trim() + "]";
                                    else
                                        sql += qs2.core.dbBase.getFunctionName(rQuery.QryTable) + ".[" + rQuery.QryColumn + "]";
                                }
                                else
                                {
                                    if (rQuery[qs2.core.generic.columnNewName].ToString().Trim().Length > 0)
                                        sql += rQuery.QryTable + ".[" + rQuery.QryColumn + "] as [" + rQuery[qs2.core.generic.columnNewName].ToString().Trim() + "]";
                                    else
                                        sql += rQuery.QryTable + ".[" + rQuery.QryColumn + "]";
                                }
                                sGrpTabblePrefix = rQuery.QryTable;
                                if (doTables)
                                {
                                    System.Guid IDJoin = System.Guid.NewGuid();
                                    IDJoin = this.addQry("", rQuery.QryTable.Trim(), "", "", "", ref Sort, dsJoinsOnlyTables, eTypDoJoins.tableEntry, IDJoin);
                                    this.addQry("", rQuery.QryTable.Trim(), rQuery.QryColumn, "", "", ref Sort, dsJoinsAllFields, eTypDoJoins.fieldEntry, IDJoin);
                                    Sort += 1;
                                }
                            }
                            else
                            {
                                qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = this.getCriteria(rQuery.CriteriaFldShort, rQuery.CriteriaApplication, ref prot);
                                if (rCriteria != null)
                                {
                                    if (rCriteria.SourceTable.Trim() == "")
                                        this.addProtEntry(qs2.core.sqlTxt.errTxtNoCriteriaSourceTable + rQuery.CriteriaFldShort, ref prot);

                                    sql += (sql == "" ? "" : ", ");
                                    if (qs2.core.dbBase.viewIsFunction2(rQuery.QryTable))
                                    {
                                        if (rQuery[qs2.core.generic.columnNewName].ToString().Trim() != "")
                                            sql += qs2.core.dbBase.getFunctionName(rQuery.QryTable) + ".[" + rQuery[qs2.core.generic.columnNewName].ToString().Trim() + "]";
                                        else
                                            sql += qs2.core.dbBase.getFunctionName(rQuery.QryTable) + ".[" + rQuery.QryColumn + "]";
                                    }
                                    else
                                    {
                                        if (rQuery[qs2.core.generic.columnNewName].ToString().Trim() != "")
                                            sql += rQuery.QryTable + ".[" + rQuery.QryColumn + "] as [" + rQuery[qs2.core.generic.columnNewName].ToString().Trim() + "]";
                                        else
                                            sql += rQuery.QryTable + ".[" + rQuery.QryColumn + "]";
                                    }
                                    sGrpTabblePrefix = rQuery.QryTable;
                                    if (doTables)
                                    {
                                        System.Guid IDJoin = System.Guid.NewGuid();
                                        IDJoin = this.addQry("", rCriteria.SourceTable.Trim(), "", "", "", ref Sort, dsJoinsOnlyTables, eTypDoJoins.tableEntry, IDJoin);
                                        this.addQry("", rCriteria.SourceTable.Trim(), rCriteria.FldShort, "", "", ref Sort, dsJoinsAllFields, eTypDoJoins.fieldEntry, IDJoin);
                                        Sort += 1;
                                    }
                                }
                            }
                        }
                    }

                    this.checkIDGuidStay(ref sql, ref sGrpTabblePrefix);
                    sql = qs2.core.sqlTxt.select + sql;
                    return (sql + " ");
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doSqlFields:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }
        public void checkIDGuidStay(ref string sql, ref string sTable)
        {
            try
            {
                if (!qs2.core.license.doLicense.rApplication.IDApplication.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim().ToLower()))
                {
                    if (sql.Trim() != "" && sTable.Trim() != "")
                    {
                        string FieldIDGuidStay = sTable.Trim() + ".[IDGuid]";
                        if (!sql.Trim().ToLower().Contains(FieldIDGuidStay.Trim().ToLower()))
                        {
                            sql += ", " + FieldIDGuidStay.Trim() + " ";
                            //string xy = "";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.checkIDGuidStay: IDGuid for Table '" + sTable.Trim() + "' not exists in DB-Schema" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public string doSqlAddStandardFields_tblStayxy(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tFields, ref System.Collections.Generic.List<string> tables, ref string prot)
        {
            try
            {
                string sql = "";
                dsObjects.tblStayDataTable tStay = new  dsObjects.tblStayDataTable ();
                sql += tStay.TableName + "." + tStay.PatIDGuidColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.PatExtIDColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.PatIDGuidColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.CreatedDtColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.StayTypColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.OPTypColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.IDColumn.ColumnName;
                sql += ", " + tStay.TableName + "." + tStay.MedRecNColumn.ColumnName;

                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doSqlAddStandardFields_tblStay:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }
        
        public string doJoinsxy(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tJoins,  ref string prot)
        {
            try
            {
                string sql = "";
                dsAdmin.tblQueriesDefRow[] arrQueries = (dsAdmin.tblQueriesDefRow[])tJoins.Select("", tJoins.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueries.Length > 0)
                {
                    bool nextEquals = false;
                    foreach (dsAdmin.tblQueriesDefRow rQuery in arrQueries)
                    {
                        if (!rQuery.freeSql.Trim().Equals(""))
                            nextEquals = false;

                        string tableCorrected = rQuery.QryTable;
                        if (qs2.core.dbBase.viewIsFunction2(tableCorrected))
                            tableCorrected = qs2.core.dbBase.getFunctionName(tableCorrected);


                        if (!nextEquals)
                        {
                            sql += rQuery.Combination + " " + tableCorrected + "." + rQuery.QryColumn + rQuery.Condition + rQuery.freeSql.Trim();
                        }
                        else
                        {
                            sql += tableCorrected + "." + rQuery.QryColumn + " " + rQuery.CombinationEnd;
                        }
                        nextEquals = !nextEquals;
                    }
                    return (sql + " ");
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doJoins:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }

        public void doSqlConditions(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions,
                                    qs2.core.vb.dsAdmin.tblQueriesDefDataTable tParFct, ref string prot,
                                    bool withParameters,
                                    System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                    bool doFunctionParameters, ref string sqlParameterFunction,
                                    dsAdmin.tblSelListEntriesRow rSelListQry, bool doFixSql,
                                    ref System.Collections.Generic.List<sqlFix> lstSqlFix,
                                    ref string sqlWhere,
                                    ref string WhereClauselForSimpleFunctions,
                                    bool IsIsSubQuery, ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    bool IsFunction, ref string SqlWhereAdmin, ref cDataSql DataSql)
        {
            try
            {
                if (doFixSql)
                {
                    this.getListSqlFix(rSelListQry, ref lstSqlFix);
                }

                dsAdmin.tblQueriesDefRow[] arrQueries = null;
                if (!doFunctionParameters)
                {
                    arrQueries = (dsAdmin.tblQueriesDefRow[])tConditions.Select("", tConditions.SortColumn.ColumnName + qs2.core.sqlTxt.asc);  
                }
                else
                {
                    arrQueries = (dsAdmin.tblQueriesDefRow[])tParFct.Select("", tParFct.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                }

                if (arrQueries.Length > 0)
                {
                    int iCounterConditions = 0;
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in arrQueries)
                    {

                        if (rQry.ControlType.sEquals("TextField") || rQry.ControlType.sEquals( "TextFieldMulti"))
                        {
                            rQry.ValueMin = HttpUtility.HtmlEncode(rQry.ValueMin);
                        }

                        if ((bool)rQry[qs2.core.generic.columnRemoved] == false)
                        {
                            //CheckSchalter: 4. if SimpleFct -> WhereClauselForSimpleFunctions -> one Where-String for doTables -> doWhereClauselForSimpleFunctions = true;
                            //CheckSchalter: 5. if SimpleView -> wie IsSQLServerField -> mit normalen Ds-Parameters für Sql-Client
                            bool doSqlSrvField = false;
                            bool doWhereClauselForSimpleFunctions = false;
                            if (rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleView) ||
                                rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleFunction))
                            {
                                doSqlSrvField = true;
                                if (rSelListQry.TypeQry.Trim().ToLower().Equals(qs2.core.print.print.eQueryType.SimpleFunction.ToString().ToLower()) && doFunctionParameters)
                                {
                                    //doWhereClauselForSimpleFunctions = true;
                                }
                            }
                            else if (rQry.IsSQLServerField)
                            {
                                doSqlSrvField = true;
                            }

                            if (doSqlSrvField)
                            {
                                string tableCorrected = rQry.QryTable;
                                if (doFunctionParameters && qs2.core.dbBase.viewIsFunction2(tableCorrected))
                                    tableCorrected = qs2.core.dbBase.getFunctionName(tableCorrected);

                                if (!String.IsNullOrWhiteSpace(rQry.freeSql))
                                {
                                    if (iCounterConditions == 0 && string.IsNullOrEmpty(sqlWhere))
                                    {
                                        rQry.Combination = this.checkFirstCombination(rQry.Combination, ref iCounterConditions, true);
                                    }
                                    string CombinationTmp = "";
                                    if (String.IsNullOrWhiteSpace(SqlWhereAdmin))
                                    {
                                        CombinationTmp = " where ";
                                    }   
                                    
                                    if (iCounterConditions == 0 && !String.IsNullOrWhiteSpace(SqlWhereAdmin) && String.IsNullOrWhiteSpace(rQry.Combination))
                                        CombinationTmp = " and ";

                                    sqlWhere = sqlWhere + qs2.core.generic.lineBreak + " " + rQry.Combination + " " + rQry.freeSql.Trim() + " " + rQry.CombinationEnd;
                                    SqlWhereAdmin += CombinationTmp + " " + rQry.Combination + " " + rQry.freeSql.Trim() + " " + rQry.CombinationEnd;
                                    iCounterConditions += 1;
                                }
                                else
                                {
                                    string conditionToAdd = "";
                                    conditionToAdd = this.getCondition(rQry, tableCorrected, rQry.ControlType, ref parametersSql, withParameters,
                                    doFunctionParameters, ref sqlParameterFunction,
                                    ref WhereClauselForSimpleFunctions, ref doWhereClauselForSimpleFunctions, ref rSelListQry,
                                    ref iCounterConditions, ref lstParForExternFct, ref SqlWhereAdmin);

                                    if (!String.IsNullOrWhiteSpace(conditionToAdd))
                                    {
                                        if (String.IsNullOrWhiteSpace(sqlWhere) && iCounterConditions == 0)
                                        {
                                            rQry.Combination = this.checkFirstCombination(rQry.Combination, ref iCounterConditions, true);
                                        }
                                        sqlWhere = sqlWhere + qs2.core.generic.lineBreak + rQry.Combination + conditionToAdd + rQry.CombinationEnd;
                                    }
                                }
                                //note: bei SimpleFunction -> WhereClauselForSimpleFunctions befüllen statt normale parameter, bei SimpleView bleibts wies ist (pre-Sql)
                            }
                            else
                            {
                                qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = this.getCriteria(rQry.CriteriaFldShort, rQry.CriteriaApplication, ref prot);
                                if (rCriteria == null)
                                {
                                    this.addProtEntry(qs2.core.sqlTxt.errTxtNoCriteriaRow + rQry.CriteriaFldShort, ref prot);
                                }
                                else
                                {
                                    string tableCorrected = "";             //rCriteria.SourceTable;
                                    if (String.IsNullOrWhiteSpace(rCriteria.SourceTable))
                                    {
                                        if (this.controlIsDbDataControl(rCriteria.ControlType))
                                        {
                                            this.addProtEntry(qs2.core.sqlTxt.errTxtNoCriteriaSourceTable + rQry.CriteriaFldShort, ref prot);
                                        }
                                    }
                                    tableCorrected = rCriteria.SourceTable;

                                    if (doFunctionParameters && qs2.core.dbBase.viewIsFunction2(tableCorrected))
                                        tableCorrected = qs2.core.dbBase.getFunctionName(tableCorrected);

                                    string conditionToAdd = this.getCondition(rQry, tableCorrected, rCriteria.ControlType, ref parametersSql,
                                                            withParameters, doFunctionParameters, ref sqlParameterFunction,
                                                            ref WhereClauselForSimpleFunctions, ref doWhereClauselForSimpleFunctions, ref rSelListQry,
                                                            ref iCounterConditions, ref lstParForExternFct, ref SqlWhereAdmin);

                                    // add Combination and Condition to Sql
                                    if (!String.IsNullOrWhiteSpace(conditionToAdd))
                                    {
                                        sqlWhere = (String.IsNullOrWhiteSpace(sqlWhere) ? conditionToAdd : sqlWhere + qs2.core.generic.lineBreak + rQry.Combination + conditionToAdd + rQry.CombinationEnd);
                                    }
                                    //}
                                }
                            }
                            iCounterConditions += 1;
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doSqlConditions:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public void setParametersListSqlFix(ref System.Collections.Generic.List<sqlFix> lstSqlFix, ref string sql, string fieldInfo, string valueUsr)
        {
            if (valueUsr.Trim() == "")
                return;
            
            if (lstSqlFix.Count > 0)
            {
                bool firstSubSqlFix = true;
                foreach (sqlFix sqlFix in lstSqlFix)
                {
                    if (sqlFix.SqlCommand.Trim() != "")
                    {
                        string sqlCondition = "";
                        if (firstSubSqlFix)
                        {
                            sqlCondition = (!sqlFix.sqlConditionExists ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and);
                        }
                        else
                        {
                            sqlCondition = qs2.core.sqlTxt.and;
                        }

                        string sqlToAdd = "";
                        if (sqlFix.lstSqlFixparameter.Count > 0)
                        {
                            int parNr = 0;
                            foreach (string par in sqlFix.lstSqlFixparameter)
                            {
                                if (fieldInfo.Trim().ToLower() == par.Trim().ToLower())
                                {
                                    sqlToAdd = sqlFix.SqlCommand.Trim().Replace("{" + parNr.ToString() + "}", valueUsr);
                                    parNr += 1;
                                }
                            }
                        }

                        sql += sqlCondition + sqlToAdd;
                        firstSubSqlFix = false;
                    }
                }
            }
        }
        public void getListSqlFix(dsAdmin.tblSelListEntriesRow rSelListQry, ref System.Collections.Generic.List<sqlFix> lstSqlFix)
        {
            if (rSelListQry.Sql.Trim() != "")
            {
                System.Collections.Generic.List<string> lstSqlFound = qs2.core.generic.readStrVariables(rSelListQry.Sql.Trim());
                sqlFix sqlFix = new sqlFix();
                bool nextSqlFix = true;
                foreach (string SqlFixSub in lstSqlFound)
                {
                    if (SqlFixSub.ToLower().Trim().Length > 4)
                    {
                        if (nextSqlFix)
                        {
                            sqlFix = new sqlFix();
                        }
                        if (SqlFixSub.ToLower().Trim().StartsWith(("Var=").Trim().ToLower()))
                        {
                            sqlFix.lstSqlFixparameter.Add(SqlFixSub.Trim().Substring(4, SqlFixSub.Trim().Length - 4));
                            nextSqlFix = false;
                        }
                        else if (SqlFixSub.ToLower().Trim().StartsWith(("Sql=").Trim().ToLower()))
                        {
                            sqlFix.SqlCommand = SqlFixSub.Trim().Substring(4, SqlFixSub.Trim().Length - 4);
                            nextSqlFix = true;
                            lstSqlFix.Add(sqlFix);
                        }
                    }
                }
            }
        }
    
        public void doTablesConditions(qs2.core.vb.dsAdmin.tblQueriesDefDataTable tConditions, dsAdmin dsJoinsOnlyTables, dsAdmin dsJoinsAllFields, 
                                        ref int Sort, ref string prot)
        {
            try
            {
                //foreach (string table in tables)
                //{
                //    if (table.Trim() != tStay.TableName)
                //    {
                //        sql += (sql == "" ? "" : qs2.core.sqlTxt.and);
                //        sql += tStay.TableName + ".ID = " + table + ".ID";
                //    }
                //}
                //sql = (sql.Trim() == "" ? "" : qs2.core.sqlTxt.where + sql);

                dsAdmin.tblQueriesDefRow[] arrQueries = (dsAdmin.tblQueriesDefRow[])tConditions.Select("", tConditions.SortColumn.ColumnName + qs2.core.sqlTxt.asc);
                if (arrQueries.Length > 0)
                {
                    foreach (qs2.core.vb.dsAdmin.tblQueriesDefRow rQry in arrQueries)
                    {
                        if (rQry.IsSQLServerField)
                        {
                            System.Guid IDJoin = System.Guid.NewGuid();
                            IDJoin = this.addQry("", rQry.QryTable, "", "", "", ref Sort, dsJoinsOnlyTables, eTypDoJoins.tableEntry, IDJoin);
                            this.addQry("", rQry.QryTable, rQry.QryColumn, "", "", ref Sort, dsJoinsAllFields, eTypDoJoins.fieldEntry, IDJoin);
                            Sort += 1;
                        }
                        else
                        {
                            qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = this.getCriteria(rQry.CriteriaFldShort, rQry.CriteriaApplication, ref prot);
                            if (rCriteria == null)
                            {
                                this.addProtEntry(qs2.core.sqlTxt.errTxtNoCriteriaRow + rQry.CriteriaFldShort, ref prot);
                            }
                            else
                            {
                                if (rCriteria.SourceTable.Trim() == "")
                                    this.addProtEntry(qs2.core.sqlTxt.errTxtNoCriteriaSourceTable + rQry.CriteriaFldShort, ref prot);
                                else
                                {
                                    System.Guid IDJoin = System.Guid.NewGuid();
                                    IDJoin = this.addQry("", rCriteria.SourceTable.Trim(), "", "", "", ref Sort, dsJoinsOnlyTables, eTypDoJoins.tableEntry, IDJoin);
                                    this.addQry("", rCriteria.SourceTable.Trim(), rCriteria.FldShort, "", "", ref Sort, dsJoinsAllFields, eTypDoJoins.fieldEntry, IDJoin);
                                    Sort += 1;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doTablesConditions:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public string getCondition(qs2.core.vb.dsAdmin.tblQueriesDefRow rQry, 
                                    string table, string ControlType,
                                    ref System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql, bool withParameters,
                                    bool doFunctionParameters, ref string sqlParameterFunction,
                                    ref string WhereClauselForSimpleFunctions, ref bool doWhereClauselForSimpleFunctions, 
                                    ref dsAdmin.tblSelListEntriesRow rSelListQry,  ref int iCounterConditions,
                                    ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                    ref string SqlWhereAdmin)
        {
            try
            {
                string ValueMinTxtForSql = rQry.ValueMin.Trim();
                string MaxForSql = rQry.Max.Trim();
                bool IsCRParameter = false;

                if (rQry.Typ == core.Enums.eTypQueryDef.InputParameters.ToString())
                {
                    if (!rQry.FunctionPar)
                    {
                        IsCRParameter = true;  
                    }
                }

                // Generate Condition + SqlParameters
                qs2.core.Enums.eControlType controlType = qs2.core.generic.searchEnumControlType(ControlType);

                if ((bool)rQry[qs2.core.generic.columnRemoved] == false)
                {
                    if (!IsCRParameter)
                    {
                        if (!doFunctionParameters && !doWhereClauselForSimpleFunctions)
                        {
                            //FullMode
                            string conditionToAdd = "";
                            if (ValueMinTxtForSql.Trim() != "" && rQry.Condition.Trim() != qs2.core.sqlTxt.isNull.Trim() && rQry.Condition.Trim() != qs2.core.sqlTxt.isNotNull.Trim())
                            {
                                if ((rQry.Condition.Trim() == qs2.core.sqlTxt.between.Trim()) || (rQry.Condition.Trim() == qs2.core.sqlTxt.notBetween.Trim()))
                                {
                                    int nextNr = 0;
                                    string ParameterNameMonkeyFrom = rQry.QryColumn.Trim() + "From";
                                    this.checkParameterSqlExists(ref ParameterNameMonkeyFrom, parametersSql, ref nextNr);

                                    nextNr = 0;
                                    string ParameterNameMonkeyTo = rQry.QryColumn.Trim() + "To";
                                    this.checkParameterSqlExists(ref ParameterNameMonkeyTo, parametersSql, ref nextNr);

                                    // between
                                    conditionToAdd += "(" + qs2.core.sqlTxt.getColWhereBetween(rQry.QryColumn.Trim(), table.Trim(), rQry.Condition.Trim(), ParameterNameMonkeyFrom, ParameterNameMonkeyTo) + " )";
                                    System.Data.SqlClient.SqlParameter newParSql1 = this.getParameterSql(ParameterNameMonkeyFrom, ValueMinTxtForSql, controlType, parametersSql);
                                    parametersSql.Add(newParSql1);
                                    System.Data.SqlClient.SqlParameter newParSql2 = this.getParameterSql(ParameterNameMonkeyTo, (MaxForSql.Trim() != "" ? MaxForSql : ValueMinTxtForSql), controlType, parametersSql);
                                    parametersSql.Add(newParSql2);

                                    this.getSqlValue(ValueMinTxtForSql.Trim(), ValueMinTxtForSql.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, false, true, ref SqlWhereAdmin, false);
                                }
                                else if ((rQry.Condition.Trim() == qs2.core.sqlTxt.isNull.Trim()) || (rQry.Condition.Trim() == qs2.core.sqlTxt.isNotNull.Trim()))
                                {
                                    // is null
                                    conditionToAdd += " " + table.Trim() + "." + rQry.QryColumn.Trim() + " " + rQry.Condition.Trim();
                                    this.getSqlValue(ValueMinTxtForSql.Trim(), ValueMinTxtForSql.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, true, false, ref SqlWhereAdmin, false);
                                }
                                else if ((rQry.Condition.Trim() == qs2.core.sqlTxt.In.Trim()) || (rQry.Condition.Trim() == qs2.core.sqlTxt.NotIn.Trim()))
                                {
                                    // In  or  not in
                                    if (rQry.ControlType.sEquals(core.Enums.eControlType.DateTime) ||
                                        rQry.ControlType.sEquals(core.Enums.eControlType.Date) ||
                                        rQry.ControlType.sEquals(core.Enums.eControlType.Time))
                                    {
                                        System.Collections.Generic.List<string> lstDats = new List<string>();
                                        string sValueMinTmp = rQry.ValueMin.Trim();
                                        if (sValueMinTmp.Trim().StartsWith(("(")))
                                        {
                                            sValueMinTmp = sValueMinTmp.Trim().Substring(1, sValueMinTmp.Trim().Length - 1);
                                        }
                                        if (sValueMinTmp.Trim().EndsWith((")")))
                                        {
                                            sValueMinTmp = sValueMinTmp.Trim().Substring(0, sValueMinTmp.Trim().Length - 1);
                                        }
                                        string[] sVarsDat = sValueMinTmp.Trim().Trim().Split(',');
                                        if (sVarsDat.Length > 0)
                                        {
                                            for (int i = 0; i < sVarsDat.Length; i++)
                                            {
                                                string sVar = sVarsDat[i];
                                                if (sVar.Trim() != "")
                                                {
                                                    if (sVar.Trim().StartsWith(("'")))
                                                    {
                                                        sVar = sVar.Trim().Substring(1, sVar.Trim().Length - 1);
                                                    }
                                                    if (sVar.Trim().EndsWith(("'")))
                                                    {
                                                        sVar = sVar.Trim().Substring(0, sVar.Trim().Length - 1);
                                                    }

                                                    lstDats.Add(sVar.Trim());
                                                }
                                            }
                                        }

                                        string sSqlValueMin = "";
                                        if (lstDats.Count > 0)
                                        {
                                            int iCounter = 0;
                                            sSqlValueMin += "(";
                                            foreach (string sDat in lstDats)
                                            {
                                                CultureInfo Invc = CultureInfo.InvariantCulture;
                                                DateTime datMinValue = DateTime.Parse(sDat.Trim());
                                                string sqlDat = qs2.core.vb.dbBase.getDateConvertSqlFromQS2Service(datMinValue);
                                                if (iCounter < (lstDats.Count - 1))
                                                {
                                                    sSqlValueMin += sqlDat.Trim() + ",";
                                                }
                                                else
                                                {
                                                    sSqlValueMin += sqlDat.Trim();
                                                }
                                                iCounter += 1;
                                            }
                                            sSqlValueMin += ")";
                                        }

                                        conditionToAdd += " " + table.Trim() + "." + rQry.QryColumn.Trim() + " " + rQry.Condition.Trim() + " " + sSqlValueMin.Trim() + " ";
                                        this.getSqlValue(sSqlValueMin.Trim(), sSqlValueMin.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), 
                                                        table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, 
                                                        true, false, ref SqlWhereAdmin, true);
                                    }
                                    else
                                    {
                                        conditionToAdd += " " + table.Trim() + "." + rQry.QryColumn.Trim() + " " + rQry.Condition.Trim() + " " + rQry.ValueMin.Trim() + " ";
                                        this.getSqlValue(ValueMinTxtForSql.Trim(), ValueMinTxtForSql.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), 
                                                        table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, 
                                                        true, false, ref SqlWhereAdmin, false);
                                    }
                                }
                                else
                                {
                                    int nextNr = 0;
                                    string ParameterNameMonkey = rQry.QryColumn.Trim();
                                    this.checkParameterSqlExists(ref ParameterNameMonkey, parametersSql, ref nextNr);

                                    conditionToAdd += qs2.core.sqlTxt.getColWhere(rQry.QryColumn.Trim(), table.Trim(), rQry.Condition.Trim(), ParameterNameMonkey);
                                    System.Data.SqlClient.SqlParameter newParSql1 = this.getParameterSql(ParameterNameMonkey, ValueMinTxtForSql, controlType, parametersSql);

                                    if (rQry.Condition.Trim().ToLower() == qs2.core.sqlTxt.like.Trim().ToLower())
                                    {
                                        newParSql1.Value = "%" + newParSql1.Value + "%";
                                    }

                                    parametersSql.Add(newParSql1);

                                    this.getSqlValue(ValueMinTxtForSql.Trim(), ValueMinTxtForSql.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), 
                                                    table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, 
                                                    false, false, ref SqlWhereAdmin, false);
                                }
                            }
                            else if ((rQry.Condition.Trim() == qs2.core.sqlTxt.isNull.Trim()) || (rQry.Condition.Trim() == qs2.core.sqlTxt.isNotNull.Trim()))
                            {
                                // is null
                                conditionToAdd += " " + table.Trim() + "." + rQry.QryColumn.Trim() + " " + rQry.Condition.Trim();
                                this.getSqlValue(ValueMinTxtForSql.Trim(), ValueMinTxtForSql.Trim(), MaxForSql.Trim(), MaxForSql.Trim(), rQry.QryColumn.Trim(), 
                                                    table.Trim(), rQry.Combination.Trim(), rQry.Condition.Trim(), rQry.CombinationEnd.Trim(), rQry.ControlType, 
                                                    true, false, ref SqlWhereAdmin, false);
                            }

                            return conditionToAdd;
                        }
                        else
                        {
                            if (doWhereClauselForSimpleFunctions)
                            {
                                throw new Exception("doWhereClauselForSimpleFunctions=1 not allowed! Functions has normal Parameters!");
                            }
                            else
                            {
                                bool noInput = false;
                                bool doLike = false;
                                string ReturnValue = "";
                                this.getValueForFct(table, doFunctionParameters, ref sqlParameterFunction, ref doWhereClauselForSimpleFunctions, ref rSelListQry,
                                                        ref controlType, ref ValueMinTxtForSql, ref ReturnValue, ref doLike, ref noInput, ref lstParForExternFct, rQry.QryColumn.Trim());
                                sqlParameterFunction += (sqlParameterFunction.Trim().Equals("") ? "," + ReturnValue : "," + ReturnValue);
                            }
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getCondition:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }

        public void getSqlValue(string sValueMin, object oValueMin, string sValueMax, object oValueMax, string ColumnName,
                                string TableName, string Combination, string Condition, string CombinationEnd, string ControlType, bool isNull, bool isBetween,
                                ref string SqlWhereAdmin, bool IsInDateTime)
        {
            try
            {
                string CombinationTmp = "";
                if (SqlWhereAdmin.Trim() == "")
                {
                    if (Combination.Trim().Contains(("(")))
                    {
                        CombinationTmp = " where (";
                    }
                    else
                    {
                        CombinationTmp = " where ";
                    }
                }
                else
                {
                    CombinationTmp = Combination.Trim();
                }
                string CombinationEndTmp = (SqlWhereAdmin.Trim() == "" ? "" : CombinationEnd.Trim());

                string sValueMinTmp = "";
                string sValueMaxTmp = "";

                if (IsInDateTime)
                {
                    sValueMinTmp = sValueMin.Trim();
                    sValueMaxTmp = sValueMax.Trim();
                }
                else
                {
                    if (ControlType.Trim().ToLower() == core.Enums.eControlType.DateTime.ToString().Trim().ToLower() ||
                        ControlType.Trim().ToLower() == core.Enums.eControlType.DateTimeNoDb.ToString().Trim().ToLower() ||
                        ControlType.Trim().ToLower() == core.Enums.eControlType.Date.ToString().Trim().ToLower() ||
                        ControlType.Trim().ToLower() == core.Enums.eControlType.DateNoDb.ToString().Trim().ToLower() ||
                        ControlType.Trim().ToLower() == core.Enums.eControlType.Time.ToString().Trim().ToLower() ||
                        ControlType.Trim().ToLower() == core.Enums.eControlType.TimeNoDb.ToString().Trim().ToLower())
                    {
                        if (!sValueMin.Trim().ToLower().Equals(("null").Trim().ToLower()) && !sValueMin.Trim().ToLower().Equals(("").Trim().ToLower()))
                        {
                            //DateTime dValueMin = DateTime.Parse(sValueMin.Trim());
                            //DateTime dValueMin = DateTime.ParseExact(sValueMin.Trim(), "MM-dd-yyyy HH:mm:ss", null);
                            DateTime dValueMin = new DateTime();
                            bool IsNull = false;
                            this.getDateFromStrings(sValueMin, ref dValueMin, ref IsNull);
                            if (!IsNull)
                            {
                                sValueMinTmp = qs2.core.vb.dbBase.getDateConvertSql(dValueMin);
                            }
                            else
                            {
                                //string xyxy = "";
                            }
                        }
                        if (!sValueMax.Trim().ToLower().Equals(("null").Trim().ToLower()) && isBetween && !sValueMax.Trim().ToLower().Equals(("").Trim().ToLower()))
                        {
                            DateTime dValueMax = new DateTime();
                            bool IsNull = false;
                            this.getDateFromStrings(sValueMax, ref dValueMax, ref IsNull);
                            if (!IsNull)
                            {
                                sValueMaxTmp = qs2.core.vb.dbBase.getDateConvertSql(dValueMax);
                            }
                            else
                            {
                                //string xyxy = "";
                            }
                        }
                    }
                    else if (ControlType.sEquals( new List<object> { core.Enums.eControlType.Textfield, 
                                                                            core.Enums.eControlType.TextfieldMulti, 
                                                                            core.Enums.eControlType.TextfieldNoDb, 
                                                                            core.Enums.eControlType.TextfieldMultiNoDb }))
                    {
                        if (!Condition.sEquals( "in"))
                        {
                            sValueMinTmp = "'" + sValueMin.Trim() + "'";
                            sValueMaxTmp = "'" + sValueMax.Trim() + "'";
                        }
                        else
                        {
                            sValueMinTmp += sValueMin.Trim();
                            sValueMaxTmp += sValueMax.Trim();
                        }
                    }
                    else if (ControlType.sEquals(core.Enums.eControlType.ComboBox) ||
                             ControlType.sEquals(core.Enums.eControlType.ComboBoxNoDb) ||
                             ControlType.sEquals(core.Enums.eControlType.ComboBoxAsDropDown))
                    {
                        int iValueTmp = -999;
                        bool resultParseOKInt = System.Int32.TryParse(sValueMin.Trim(), out iValueTmp);
                        if (resultParseOKInt)
                        {
                            sValueMinTmp = sValueMin.Trim();
                        }
                        else
                        {
                            sValueMinTmp = "'" + sValueMin.Trim() + "'";
                        }

                        if (sValueMax.Trim() != "")
                        {
                            resultParseOKInt = System.Int32.TryParse(sValueMax.Trim(), out iValueTmp);
                            if (resultParseOKInt)
                            {
                                sValueMaxTmp = sValueMax.Trim();
                            }
                            else
                            {
                                sValueMaxTmp = "'" + sValueMax.Trim() + "'";
                            }
                        }
                    }
                    else
                    {
                        sValueMinTmp = sValueMin.Trim();
                        sValueMaxTmp = sValueMax.Trim();
                    }

                }

                if (isBetween)
                {
                    SqlWhereAdmin += "\r\n" + CombinationTmp + " " + TableName.Trim() + "." + ColumnName.Trim() + " " + Condition.Trim() + " " + sValueMinTmp.Trim() + " and " + sValueMaxTmp.Trim() + " " + CombinationEndTmp + " ";
                }
                else
                {
                    SqlWhereAdmin += "\r\n" + CombinationTmp + " " + TableName.Trim() + "." + ColumnName.Trim() + " " + Condition.Trim() + " " + sValueMinTmp.Trim() + " " + CombinationEndTmp + " ";
                }

                //string xy = "";            

                //if (oValue == null)
                //{
                //    sqlValue = "null";
                //}
                //else
                //{
                //    if (oValue == System.DBNull.Value)
                //    {
                //        sqlValue = "null";
                //    }
                //    else
                //    {
                //        if (oValue.GetType().Equals(typeof(string)) || oValue.GetType().Equals(typeof(string)) || oValue.GetType().Equals(typeof(string)))
                //        {
                //            string SqlValueTmp = "";
                //            string sValue = oValue.ToString();
                //            sValue = sValue.Replace("'", "''");
                //            //string sValuexy = @sValue.Replace("'", "''");
                //            //string quote2 = "\"";
                //            //char dc = (char)34;
                //            //string x = "\'";

                //            SqlValueTmp = "'" + sValue + "'";
                //            sqlValue += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(Int32)) || oValue.GetType().Equals(typeof(Int16)) || oValue.GetType().Equals(typeof(Int32)))
                //        {
                //            string SqlValueTmp = "";
                //            int iValue = System.Convert.ToInt32(oValue);
                //            SqlValueTmp = iValue.ToString();
                //            sqlValue += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(decimal)) || oValue.GetType().Equals(typeof(double)) || oValue.GetType().Equals(typeof(Double)) || oValue.GetType().Equals(typeof(Decimal)))
                //        {
                //            string SqlValueTmp = "";
                //            double dValue = System.Convert.ToDouble(oValue);
                //            SqlValueTmp = dValue.ToString();
                //            sqlValue += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(bool)) || oValue.GetType().Equals(typeof(Boolean)))
                //        {
                //            string SqlValueTmp = "";
                //            bool bValue = (bool)oValue;
                //            if (bValue)
                //            {
                //                SqlValueTmp = "1";
                //            }
                //            else
                //            {
                //                SqlValueTmp = "0";
                //            }
                //            SqlValueTmp += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(DateTime)))
                //        {
                //            string SqlValueTmp = "";
                //            DateTime dat = (DateTime)oValue;
                //            string sDate = dbBase.getDateConvertSql(dat);
                //            SqlValueTmp = sDate.ToString();
                //            SqlValueTmp += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(Guid)))
                //        {
                //            string SqlValueTmp = "";
                //            Guid gValue = new Guid(oValue.ToString());
                //            SqlValueTmp = "'" + gValue.ToString() + "'";
                //            SqlValueTmp += SqlValueTmp;
                //        }
                //        else if (oValue.GetType().Equals(typeof(Byte[])))
                //        {
                //            string SqlValueTmp = "";
                //            byte[] bValue = (byte[])oValue;
                //            //string sValue = Encoding.UTF8.GetString(bValue, 0, bValue.Length);
                //            //var sValue = System.Text.Encoding.Default.GetString(bValue);
                //            string sValue = BitConverter.ToString(bValue);
                //            sValue = "0x" + sValue.Replace("-", "");
                //            SqlValueTmp = "" + sValue.ToString() + "";
                //            SqlValueTmp += SqlValueTmp;
                //        }
                //        else
                //        {
                //            throw new Exception("getSqlValue: Type '" + oValue.GetType().ToString() + "' not allowed!");
                //        }

                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getSqlValue: " + ex.ToString());
            }
        }
        public void getDateFromStrings(string sDate, ref DateTime dDatReturn, ref bool IsNull)
        {
            try
            {
                string sMonth = sDate.Trim().Substring(0, 2);
                string sDays = sDate.Trim().Substring(3, 2);
                string sYears = sDate.Trim().Substring(6, 4);
                string sHours = sDate.Trim().Substring(11, 2);
                string sMinutes = sDate.Trim().Substring(14, 2);
                string sSeconds = sDate.Trim().Substring(17, 2);

                //if (sYears.Trim().Equals("01") && sMonth.Trim().Equals("01") && sDays.Trim().Equals("01"))
                //{
                //    IsNull = true;
                //}
                //else
                //{
                    DateTime dTmp = new DateTime(System.Convert.ToInt32(sYears.Trim()), System.Convert.ToInt32(sMonth.Trim()), System.Convert.ToInt32(sDays.Trim()),
                            System.Convert.ToInt32(sHours.Trim()), System.Convert.ToInt32(sMinutes.Trim()), System.Convert.ToInt32(sSeconds.Trim()));
                    dDatReturn = dTmp;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getDateFromStrings: " + ex.ToString());
            }
        }

        public string checkFirstCombination(string sCombination, ref int iCounterConditions, bool addWhere)
        {
            if (iCounterConditions == 0)
            {
                sCombination = sCombination.Trim().ToLower().Replace(("or").Trim().ToLower(), "");
                sCombination = sCombination.Trim().ToLower().Replace(("AND").Trim().ToLower(), "");

                //if (addWhere)
                    //sCombination = " where " + sCombination;
            }
            return sCombination;
        }

        public string getCombination(string CombinationFromQuery)
        {
            if (CombinationFromQuery.Trim() == "")
            {
                return " and ";
            }
            else
            {
                return " " + CombinationFromQuery.Trim() + " ";
            }
        }
        public string checkCombinationEnd(string CombinationEndFromQuery)
        {
            if (CombinationEndFromQuery.Trim() == "")
            {
                return "";
            }
            else
            {
                return " " + CombinationEndFromQuery.Trim() + " ";
            }
        }

        public void getValueForFct(string table, bool doFunctionParameters, ref string sqlParameterFunction,
                                ref bool doWhereClauselForSimpleFunctions,
                                ref dsAdmin.tblSelListEntriesRow rSelListQryxy,
                                ref core.Enums.eControlType controlType, ref string ValueMinTxtForSql, ref string ReturnValue,
                                ref bool doLike, ref bool noInput,
                                ref System.Collections.Generic.List<qs2.core.vb.QS2Service1.cSqlParameter> lstParForExternFct,
                                string ParName)
        {
            try
            {
                string sDelimiter = "###";  // "###";     //System.Convert.ToString((char)34);
                qs2.core.generic.retValue retValue1 = qs2.core.generic.getValue(controlType, ValueMinTxtForSql,
                                                                            Infragistics.Win.UltraWinEditors.NumericType.Integer, false,
                                                                            false);
                if (retValue1.valueObj == null)
                {
                    if (controlType == core.Enums.eControlType.Textfield ||
                            controlType == core.Enums.eControlType.TextfieldNoDb ||
                            controlType == core.Enums.eControlType.TextfieldMulti ||
                            controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                    {
                        if (doWhereClauselForSimpleFunctions)
                        {
                            ReturnValue = sDelimiter + "" + sDelimiter;
                        }
                        else
                        {
                            ReturnValue = "''";  
                        }
                        noInput = true;
                    }
                    else if (controlType == core.Enums.eControlType.DateTime ||
                            controlType == core.Enums.eControlType.DateTimeNoDb ||
                            controlType == core.Enums.eControlType.Date ||
                            controlType == core.Enums.eControlType.DateNoDb ||
                            controlType == core.Enums.eControlType.Time ||
                            controlType == core.Enums.eControlType.TimeNoDb)
                    {
                        DateTime datEmpty = new DateTime(1900, 1, 1, 0, 0, 0);
                        if (doWhereClauselForSimpleFunctions)
                        {
                            ReturnValue = qs2.core.vb.dbBase.getDateConvertSqlSimpleWithDelimiter(datEmpty, sDelimiter) + "";
                        }
                        else
                        {
                            ReturnValue = qs2.core.vb.dbBase.getDateConvertSqlSimple(datEmpty) + "";
                        }
                        noInput = true;
                    }
                    else if (controlType == core.Enums.eControlType.Integer ||
                            controlType == core.Enums.eControlType.IntegerNoDb)
                    {
                        ReturnValue = "-1";
                        noInput = true;
                    }
                    else if (controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                    {
                        ReturnValue = "-1";
                    }
                    else if (controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                    {
                        ReturnValue = "-1";
                    }
                    else if (controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                    {
                        ReturnValue = "-1";
                    }
                    else if (controlType == core.Enums.eControlType.Numeric ||
                            controlType == core.Enums.eControlType.NumericNoDb)
                    {
                        ReturnValue = "0";
                        noInput = true;
                    }
                    else if (controlType == core.Enums.eControlType.ComboBox ||
                            controlType == core.Enums.eControlType.ComboBoxNoDb)
                    {
                        ReturnValue = "-1";
                        noInput = true;
                    }
                    else
                    {
                        throw new Exception("genSql.getValueForFct: Type '" + retValue1.valueObj.GetType().Name + "' not allowed for Function-Parameter!");
                    }
                }
                else
                {
                    if (retValue1.valueObj.GetType().Equals(typeof(string)))
                    {
                        if (retValue1.valueStr.Trim() == "")
                        {
                            if (doWhereClauselForSimpleFunctions)
                            {
                                ReturnValue = sDelimiter + "" + sDelimiter;
                            }
                            else
                            {
                                ReturnValue = "''";
                            }
                            noInput = true;
                        }
                        else
                        {
                            if (doLike)
                            {
                                if (doWhereClauselForSimpleFunctions)
                                {
                                    ReturnValue = sDelimiter + "%" + retValue1.valueStr + "%" + sDelimiter;
                                }
                                else
                                {
                                    ReturnValue = "'%" + retValue1.valueStr + "%'";
                                }
                            }
                            else
                            {
                                if (doWhereClauselForSimpleFunctions)
                                {
                                    ReturnValue = sDelimiter + "" + retValue1.valueStr + "" + sDelimiter;
                                }
                                else
                                {
                                    ReturnValue = "'" + retValue1.valueStr + "'";
                                }
                            }
                        }
                    }
                    else if (retValue1.valueObj.GetType().Equals(typeof(DateTime)))
                    {
                        if (doWhereClauselForSimpleFunctions)
                        {
                            ReturnValue = qs2.core.vb.dbBase.getDateConvertSqlWithDelimiter((DateTime)retValue1.valueObj, sDelimiter) + "";
                        }
                        else
                        {
                            ReturnValue = qs2.core.vb.dbBase.getDateConvertSql((DateTime)retValue1.valueObj) + "";
                        }
                    }
                    else if (retValue1.valueObj.GetType().Equals(typeof(int)) ||
                                retValue1.valueObj.GetType().Equals(typeof(double)) || retValue1.valueObj.GetType().Equals(typeof(decimal)))
                    {
                        ReturnValue = retValue1.valueStr;
                    }
                    else if (retValue1.valueObj.GetType().Equals(typeof(bool)))
                    {
                        ReturnValue = retValue1.valueStr;
                    }
                    else
                    {
                        throw new Exception("genSql.getValueForFct: Type '" + retValue1.valueObj.GetType().Name + "' not allowed for Function-Parameter!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getValueForFct:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public System.Data.SqlClient.SqlParameter getParameterSql(string ParameterName, string valueStr, 
                                                                qs2.core.Enums.eControlType controlType,
                                                                 System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql)
        {
            try
            {
                System.Data.SqlClient.SqlParameter newParSql = new System.Data.SqlClient.SqlParameter();  //qs2.core.generic.searchEnumControlType(rParFound[qs2.core.generic.columnNameVal].ToString())
                qs2.core.generic.retValue retValue1 = qs2.core.generic.getValue(controlType, valueStr, Infragistics.Win.UltraWinEditors.NumericType.Integer, false);

                newParSql.SourceColumn = ParameterName;
                newParSql.ParameterName = qs2.core.sqlTxt.getColPar(ParameterName);
                newParSql.Value = retValue1.valueObj;
                
                return newParSql;

            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getParameterSql:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }
        public void checkParameterSqlExists(ref string ParameterName,
                                    System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql,
                                    ref int NextNrxy)
        {
            try
            {
                foreach (System.Data.SqlClient.SqlParameter SqlParameter1 in parametersSql)
                {
                    if (SqlParameter1.ParameterName.Substring(1, SqlParameter1.ParameterName.Length - 1) == ParameterName)
                    {
                        genSql.ParAliasNextNr += 1;
                        ParameterName += genSql.ParAliasNextNr.ToString();
                        this.checkParameterSqlExists(ref ParameterName, parametersSql, ref genSql.ParAliasNextNr);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.checkParameterSqlExists:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public void checkParameterSqlExistsxyxy(ref string ParameterName, 
                                            System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql, 
                                            ref int NextNr)
        {
            try
            {
                foreach (System.Data.SqlClient.SqlParameter SqlParameter1 in parametersSql)
                {
                    if (SqlParameter1.ParameterName.Substring(1, SqlParameter1.ParameterName.Length - 1) == ParameterName)
                    {
                        NextNr += 1;
                        ParameterName += NextNr.ToString();
                        this.checkParameterSqlExists(ref ParameterName, parametersSql, ref NextNr);
                    }
                 }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.checkParameterSqlExists:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public bool checkSysColumnExists(string columnName, string tableName, ref core.Enums.eTypQueryDef TypQueryDef, string TypeQry,
                                        ref dsAdmin.tblQueriesDefRow rSelQuery)
        {
            qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(tableName.Trim(), columnName.Trim(),
                                                        qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);
            if (rColSys != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public qs2.core.vb.dsAdmin.tblCriteriaRow getCriteria(string FldShort, string Application, ref string prot)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteria = this.sqlAdmin1.getCriterias(this.dsAdmin1, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam,
                                                                                                FldShort, Application, false, false, false, "", "", false);
                if (arrCriteria.Length == 1)
                {
                    qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteria[0];
                    return rCriteria;
                }
                else
                {
                    throw new Exception("genSql.getCriteria: Not Criteria-Entry found for Field '" + FldShort + "' in Application '" + Application + "'");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getCriteria:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return null;
            }
        }
      
        public string getValueSqlxy(qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria, string value)
        {
            try
            {
                //string ValueSql = "";
                if (rCriteria.ControlType.Trim().ToLower() == core.Enums.eControlType.Textfield.ToString().Trim().ToLower() ||
                    rCriteria.ControlType.Trim().ToLower() == core.Enums.eControlType.TextfieldMulti.ToString().Trim().ToLower() ||
                    rCriteria.ControlType.Trim().ToLower() == core.Enums.eControlType.DateTime.ToString().Trim().ToLower() ||
                    rCriteria.ControlType.Trim().ToLower() == core.Enums.eControlType.Date.ToString().Trim().ToLower() ||
                    rCriteria.ControlType.Trim().ToLower() == core.Enums.eControlType.Time.ToString().Trim().ToLower())
                {
                    return "";
                    //CAST('01.01.2010 12:23:02' AS datetime) AS Expr1
                }
                else
                {
                    return "";
                }

                //return ValueSql;
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.getValueSqlxy:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                //return "";
            }
        }
        public bool controlIsDbDataControl(string controlType)
        {
            if (controlType.Trim().ToLower() == core.Enums.eControlType.Textfield.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.TextfieldMulti.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.Integer.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.Numeric.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.Date.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.DateTime.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.Time.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.CheckBox.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.ThreeStateCheckBox.ToString().Trim().ToLower() ||
                controlType.Trim().ToLower() == core.Enums.eControlType.ComboBox.ToString().Trim().ToLower())
            {
                return true;
            }
            else
                return false;
        }

        public void addProtEntry(string txt, ref string prot)
        {
            prot += txt + qs2.core.generic.lineBreak;
        }

    }
}
