using System;
using System.Collections.Generic;
using qs2.core.vb;
using System.Globalization;
using System.Web;
using S2Extensions;

namespace qs2.sitemap.print
{
    public class genSql
    {
        public sqlAdmin sqlAdmin1;
        public dsAdmin dsAdmin1;

        public enum eTypDoJoins
        {
            tableEntry = 0,
            fieldEntry = 1
        }

        public class sqlFix
        {
            public System.Collections.Generic.List<string> lstSqlFixparameter = new System.Collections.Generic.List<string>();
        }

        public class subQuery
        {
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
                }

                string sqlParameterFunction = "";
                string sqlWhereConditions = "";
                string sqlWhereConditionsSubQuery = "";
                string WhereClauselForSimpleFunctions = "";
                string SqlWhereAdmin = "";
                this.doSqlConditions(tConditions, tParFct, ref prot, withParameters, parametersSql, false,
                                        ref sqlParameterFunction, rSelListQry, true, ref lstSqlFix, ref sqlWhereConditions,
                                        ref WhereClauselForSimpleFunctions, false, false, ref SqlWhereAdmin, ref DataSql);

                
                foreach (qs2.sitemap.print.genSql.subQuery subQuery in lstSubQueries)
                {
                    this.doSqlConditions(subQuery.tQryConditionsSub, subQuery.tParFunctParSub, ref prot, 
                                        withParameters, parametersSql, false, ref sqlParameterFunction, rSelListQry, false,
                                        ref lstSqlFix, ref sqlWhereConditionsSubQuery,
                                        ref WhereClauselForSimpleFunctions, true, false, ref SqlWhereAdmin, ref DataSql);
                }  

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
                                ref WhereClauselForSimpleFunctions, ref viewIsFunction, ref SqlWhereNoParFunct,
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
                                                false, ref lstSqlFix, ref sqlWhere, ref dummyWhereNotUsed, false, true, ref SqlWhereNoParFunct, ref DataSql);

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

                    // check for duplicte fields
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
                        bool doSqlSrvField = false;
                        if (rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleView) ||
                            rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleFunction))
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

                    sql = qs2.core.sqlTxt.select + sql;
                    return (sql + " ");
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                throw new Exception("genSql.doSqlFields:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
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
                                    bool IsIsSubQuery, 
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
                            bool doSqlSrvField = false;
                            bool doWhereClauselForSimpleFunctions = false;
                            if (rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleView) ||
                                rSelListQry.TypeQry.sEquals(qs2.core.print.print.eQueryType.SimpleFunction))
                            {
                                doSqlSrvField = true;
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
                                    ref iCounterConditions, ref SqlWhereAdmin);

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
                                                            ref iCounterConditions, ref SqlWhereAdmin);

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
                        if (SqlFixSub.sEquals("Var=", Enums.eCompareMode.StartsWith))
                        {
                            sqlFix.lstSqlFixparameter.Add(SqlFixSub.Trim().Substring(4, SqlFixSub.Trim().Length - 4));
                            nextSqlFix = false;
                        }
                        else if (SqlFixSub.sEquals("Sql=", Enums.eCompareMode.StartsWith))
                        {
                            nextSqlFix = true;
                            lstSqlFix.Add(sqlFix);
                        }
                    }
                }
            }
        }
    
        public string getCondition(qs2.core.vb.dsAdmin.tblQueriesDefRow rQry, 
                                    string table, string ControlType,
                                    ref System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parametersSql, bool withParameters,
                                    bool doFunctionParameters, ref string sqlParameterFunction,
                                    ref string WhereClauselForSimpleFunctions, ref bool doWhereClauselForSimpleFunctions, 
                                    ref dsAdmin.tblSelListEntriesRow rSelListQry,  ref int iCounterConditions,
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
                                                        ref controlType, ref ValueMinTxtForSql, ref ReturnValue, ref doLike, ref noInput, rQry.QryColumn.Trim());
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
                    if (ControlType.sEquals(core.Enums.eControlType.DateTime) ||
                        ControlType.sEquals(core.Enums.eControlType.DateTimeNoDb) ||
                        ControlType.sEquals(core.Enums.eControlType.Date) ||
                        ControlType.sEquals(core.Enums.eControlType.DateNoDb) ||
                        ControlType.sEquals(core.Enums.eControlType.Time) ||
                        ControlType.sEquals(core.Enums.eControlType.TimeNoDb))
                    {
                        if (!sValueMin.sEquals("null") && !String.IsNullOrWhiteSpace(sValueMin))
                        {
                            DateTime dValueMin = new DateTime();
                            bool IsNull = false;
                            this.getDateFromStrings(sValueMin, ref dValueMin, ref IsNull);
                            if (!IsNull)
                            {
                                sValueMinTmp = qs2.core.vb.dbBase.getDateConvertSql(dValueMin);
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

                DateTime dTmp = new DateTime(System.Convert.ToInt32(sYears.Trim()), System.Convert.ToInt32(sMonth.Trim()), System.Convert.ToInt32(sDays.Trim()),
                        System.Convert.ToInt32(sHours.Trim()), System.Convert.ToInt32(sMinutes.Trim()), System.Convert.ToInt32(sSeconds.Trim()));
                dDatReturn = dTmp;
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
                sCombination = sCombination.ToLower().Replace(("or"), "");
                sCombination = sCombination.ToLower().Replace(("and"), "");
            }
            return sCombination;
        }

        public void getValueForFct(string table, bool doFunctionParameters, ref string sqlParameterFunction,
                                ref bool doWhereClauselForSimpleFunctions,
                                ref dsAdmin.tblSelListEntriesRow rSelListQryxy,
                                ref core.Enums.eControlType controlType, ref string ValueMinTxtForSql, ref string ReturnValue,
                                ref bool doLike, ref bool noInput,
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
            }
        }
      
        public bool controlIsDbDataControl(string controlType)
        {
            return (controlType.sEquals(new List<object>
            {
                core.Enums.eControlType.Textfield,
                core.Enums.eControlType.TextfieldMulti,
                core.Enums.eControlType.Integer,
                core.Enums.eControlType.Numeric,
                core.Enums.eControlType.Date,
                core.Enums.eControlType.DateTime,
                core.Enums.eControlType.Time,
                core.Enums.eControlType.CheckBox,
                core.Enums.eControlType.ThreeStateCheckBox,
                core.Enums.eControlType.ComboBox
            }));
        }

        public void addProtEntry(string txt, ref string prot)
        {
            prot += txt + qs2.core.generic.lineBreak;
        }

    }
}
