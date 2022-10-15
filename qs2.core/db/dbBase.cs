using qs2.core.db.ERSystem;
using S2Extensions;
using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Common;
//using System.Data.SqlClient;
using System.Web;
using System.Windows.Forms;


namespace qs2.core
{



    public class dbBase
    {
        public static string Provider = "";
        public static string Database = "";
        public static string Server = "";
        public static string User = "";
        public static string PwdDecrypted = "";
        public static string PwdEncrypted = "";
        public static bool TrustedConnection = false;
        
        public static System.DateTime minDateTime = new System.DateTime(1900, 1, 1);
        public static string tableNameQueries = "Qry";
        public static string tableNameDsQueries = "ds";

        public static string prefixFunction = "fnc";

        public static string dbSchema = " qs2.";

        public enum DBTypeSqlServer
        {
            nvarchar = 80300,
            uniqueidentifier = 80301,
            bit = 80302,
            datetime = 80303,
            numeric = 80304,
            varchar = 80305,
            getdate = 80306,
            newid = 80307,
        }

        public static string typDecimal = "decimal";
        public static string typFloat = "float";
        public static string typInt = "int";
        public static string Yes = "yes";
        public static string No = "no";

        public enum TypeField
        {
            str = 200000,
            tbool = 200002,
            datetime = 200003,
            dec = 200004,
            tint = 200005,
            guid = 200006,
            image = 200007,
            varbinary = 200008,
            xml = 200009,
            DBNull = 200010
        }

        public enum eTypeInt
        {
            t_int = 0,
            t_dbl = 1,
            t_string = 2,
            t_DateTime = 3,
            t_Guid = 4,
            t_DBNull = 5,
            t_Binary = 6,
            t_Boolean = 7,
            none = -1
        }
        
        public static System.Data.SqlClient.SqlConnection _dbConnThreadMain = null;
        public static int _IDThreadMain = -999;

        public static System.Data.SqlClient.SqlConnection _dbConnThreadStayUI = null;
        public static int _IDThreadStayUI = -999;

        public static System.Data.SqlClient.SqlConnection _dbConnThreadDBOperations = null;
        public static int _IDThreadDBOperations = -999;

        public bool setConnectionDB2(bool DesignerMode, string DbConnStrStayUI, string Info)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(DbConnStrStayUI))
                {
                    qs2.core.ENV.connStr = DbConnStrStayUI;
                }

                dbBase.getVarConnStr(qs2.core.ENV.connStr);
                dbBase._dbConnThreadMain = new System.Data.SqlClient.SqlConnection(qs2.core.ENV.connStr);
                dbBase._dbConnThreadMain.Open();        

                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    qs2.core.db.ERSystem.businessFramework.getDBContext();
                }
                return true;
            }
            catch (Exception ex)
            {
                string eExcep = "Cann't connect to database!" + "\r\n" + "\r\n" + "setConnectionDB: " + ex.ToString();
                MessageBox.Show(ex.ToString());
                Process currentProcess = Process.GetCurrentProcess();
                currentProcess.Kill();
                throw new Exception(eExcep);
            }
        }

        public static System.Data.SqlClient.SqlConnection dbConn
        {
            get
            {
                if (dbBase._dbConnThreadMain.State != System.Data.ConnectionState.Open)
                {
                    dbBase._dbConnThreadMain.Close();
                    dbBase._dbConnThreadMain.Open();
                }
                return dbBase._dbConnThreadMain;
            }
        }

        public static void getVarConnStr(string ConnectionStr)
        {
            try
            {
                SqlConnectionStringBuilder SqlBuilder = new SqlConnectionStringBuilder(ConnectionStr.Trim());

                dbBase.Server = SqlBuilder.DataSource;
                dbBase.Database = SqlBuilder.InitialCatalog;
                dbBase.TrustedConnection = SqlBuilder.IntegratedSecurity;

                if (SqlBuilder.IntegratedSecurity)
                    return;

                dbBase.User = SqlBuilder.UserID;
                dbBase.PwdDecrypted = SqlBuilder.Password;
            }

            catch (Exception ex)
            {
                throw new Exception("dbBase.getVarConnStr: " + ex.ToString());
            }       
        }

        public static void setConnection2(System.Data.SqlClient.SqlDataAdapter da)
        {
            dbBase.setConnection(ref da);
        }

        public static void setConnection(ref System.Data.SqlClient.SqlDataAdapter da)
        {
            if (da.SelectCommand != null)
            {
                da.SelectCommand.Connection = qs2.core.dbBase.dbConn;  
            } 

            if (da.InsertCommand != null)
            {
                da.InsertCommand.Connection = qs2.core.dbBase.dbConn;
            }

            if (da.UpdateCommand != null)
            {
                da.UpdateCommand.Connection = qs2.core.dbBase.dbConn;
            }

            if (da.DeleteCommand != null)
            {
                da.DeleteCommand.Connection = qs2.core.dbBase.dbConn;
            }  
        }

        public static void generateDeleteCommandGuid(string table, string columnWhere, string  value, ref string cmdDelete)
        {
            cmdDelete += sqlTxt.delete + table + sqlTxt.where + columnWhere + "='" + value.ToString() + "'" + ";";
        }

        public static bool executeCommand(string sqlCommand)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sqlCommand;
            cmd.Connection = qs2.core.dbBase.dbConn;
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            return true;
        }

        public static bool fillDataSet(string sqlCommand, System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> parameters,
                                        ref System.Data.DataSet dsQryAuto1, string tableName, string datasetName,
                                        ref string AllParametersAsTxtReturn, bool isFunction)
        {
            try
            {
                dsQryAuto1 = new System.Data.DataSet();
                dsQryAuto1.DataSetName = datasetName;
                System.Data.DataTable DataTable1 = new System.Data.DataTable();
                DataTable1.TableName = tableName;                               // qs2.core.dbBase.tableNameQueries;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                da.SelectCommand = cmd;

                cmd.CommandText = sqlCommand;
                cmd.Connection = qs2.core.dbBase.dbConn;
                if (parameters.Count > 0)
                {
                    foreach (System.Data.SqlClient.SqlParameter par in parameters)
                    {
                        cmd.Parameters.Add(par);
                        AllParametersAsTxtReturn += par.ParameterName + "= " + par.Value.ToString() + "\r\n";
                    }
                }
                else
                {
                    string xy = "";
                }
                cmd.CommandText = HttpUtility.HtmlDecode(cmd.CommandText);

                da.SelectCommand.CommandTimeout = 0;
                da.Fill(DataTable1);
                dsQryAuto1.Tables.Add(DataTable1);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.fillDataSet:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static bool fillDataSet(string sqlCommand, ref System.Data.DataSet dsResult, string tableName, string datasetName)
        {
            try
            {

                dsResult = new System.Data.DataSet(datasetName);
                System.Data.DataTable DataTable1 = new System.Data.DataTable(tableName);

                //NICHT LÖSCHEN  ------------- Für MSOLEDBSQL statt SQLNativeClient ---------------- NICHT LÖSCHEN!!!!
                //OleDbConnectionStringBuilder oleDBSB = new OleDbConnectionStringBuilder(qs2.core.dbBase.dbConn.ConnectionString);
                //if (String.IsNullOrWhiteSpace(oleDBSB.Provider))
                //{
                //    oleDBSB.Provider = "MSOLEDBSQL";
                //}

                //using (OleDbConnection conn = new OleDbConnection(oleDBSB.ConnectionString))
                //{
                //    conn.Open();
                //    using (OleDbDataAdapter da = new OleDbDataAdapter(sqlCommand, conn))
                //    {
                //        da.Fill(DataTable1);
                //    }
                //    dsResult.Tables.Add(DataTable1);
                //}

                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(qs2.core.dbBase.dbConn.ConnectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlCommand, conn))
                    {
                        da.Fill(DataTable1);
                    }
                    dsResult.Tables.Add(DataTable1);
                }

                int rCount = 0;
                foreach (System.Data.DataRow r in DataTable1.Rows)
                {
                    int cCount = 0;
                    foreach (System.Data.DataColumn c in DataTable1.Columns)
                    {
                        if (c.DataType.FullName == "System.String")
                        {
                            r[c.ColumnName] = HttpUtility.HtmlDecode( DataTable1.Rows[rCount].ItemArray[cCount].ToString()).Replace("<br/>", "\n");
                        }
                        cCount++;
                    }
                    rCount++;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.fillDataSet:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static System.Data.DataTable buildSelectCommand(string TableName,
                                                                System.Collections.Generic.List<qs2.core.generic.retValue> columnsSelect,
                                                                System.Collections.Generic.List<qs2.core.generic.retValue> columnsWhere,
                                                                bool AddSchema)
        {
            string sqlCommand = "";
            string sqlColumns = "";
            string sqlWhere = "";
            foreach (qs2.core.generic.retValue colSelect in columnsSelect)
            {
                string sqlTemp = colSelect.fieldInfo.Trim();
                sqlColumns += (sqlColumns.Trim() == "" ? "" : ",") + sqlTemp.Trim();
            }
            foreach (qs2.core.generic.retValue colWhere in columnsWhere)
            {
                string sqlTemp = colWhere.fieldInfo.Trim() + "=" + colWhere.valueStr.Trim() + " ";
                sqlWhere += (sqlWhere.Trim() == "" ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + sqlTemp.Trim();
            }
            sqlCommand = sqlTxt.select + sqlColumns + sqlTxt.from + (AddSchema == true ? dbBase.dbSchema : "") + TableName + sqlWhere;

            System.Data.DataTable DataTableResult = new System.Data.DataTable();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            da.SelectCommand = cmd;
            cmd.CommandText = sqlCommand;
            cmd.Connection = qs2.core.dbBase.dbConn;
            da.SelectCommand.CommandTimeout = 0;
            da.Fill(DataTableResult);
            return DataTableResult;
        }

        public static bool buildUpdateCommand(string TableName, System.Collections.Generic.List<qs2.core.generic.retValue> columnToUpdate,
                                                System.Collections.Generic.List<qs2.core.generic.retValue> columnsWhere,
                                                bool SchemaIncluded)
        {
            string sqlCommand = "";
            try
            {
                string sqlColumnsWithValues = "";
                string sqlWhere = "";
                foreach (qs2.core.generic.retValue col in columnToUpdate)
                {
                    string sqlTemp = col.fieldInfo.Trim() + "=" + col.valueStr;
                    sqlColumnsWithValues += (sqlColumnsWithValues.Trim() == "" ? "" : ",") + sqlTemp.Trim();
                }
                foreach (qs2.core.generic.retValue colWhere in columnsWhere)
                {
                    string sqlTemp = colWhere.fieldInfo.Trim() + "=" + colWhere.valueStr.Trim() + " ";
                    sqlWhere += (sqlWhere.Trim() == "" ? qs2.core.sqlTxt.where : qs2.core.sqlTxt.and) + sqlTemp.Trim();
                }

                if (SchemaIncluded)
                {
                    sqlCommand = " Update " +  dbBase .dbSchema + TableName + " set " + sqlColumnsWithValues + sqlWhere;
                }
                else
                {
                    sqlCommand = " Update " + dbBase.dbSchema + qs2.core.dbBase.dbSchema + TableName + " set " + sqlColumnsWithValues + sqlWhere;
                }
                
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sqlCommand;
                cmd.Connection = qs2.core.dbBase.dbConn;
                cmd.CommandTimeout = 0;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Sql-Command '" + sqlCommand.Trim() + "' is wrong!" + "\r\n" + ex.ToString());
            }
        }

        public static qs2.core.generic.retValue getDefaultDBValue(ref qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys, 
                                                            bool onlyDateTimeWithoutDefaultValue,
                                                            System.Collections.Generic.List<string> lstTablesNoDateTimeCheck,
                                                            ref bool NoDefaultValuePossible)
        {
            try
            {
                string ExceptionStrDefault = "dbBase.getDefaultDBValue: '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "': ";

                qs2.core.generic.retValue ret = new qs2.core.generic.retValue();
                int startIndex = 0;
                qs2.core.dbBase.setResultDbNull(ref ret);

                if (rColSys.IsIS_NULLABLENull())
                {
                    throw new Exception(ExceptionStrDefault + "rColSys.IsIS_NULLABLENull()=True");
                    //qs2.core.dbBase.setResultDbNull(ref ret);
                }
                else
                {
                    if (rColSys.IS_NULLABLE.ToLower() == qs2.core.dbBase.Yes.ToLower())
                    {
                        qs2.core.dbBase.setResultDbNull(ref ret);
                        if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.datetime.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            qs2.core.dbBase.getDefaultDBValueDateTime(ref rColSys, onlyDateTimeWithoutDefaultValue, ref ret);
                        }
                    }
                    else
                    {
                        if (rColSys.IsCOLUMN_DEFAULTNull())
                        {
                            if (onlyDateTimeWithoutDefaultValue)
                            {
                                if (!rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.datetime.ToString(), StringComparison.OrdinalIgnoreCase))
                                {
                                    bool noCheck = false;
                                    foreach (string tableNameNoCheck in lstTablesNoDateTimeCheck)
                                    {
                                        if (tableNameNoCheck.Equals(rColSys.TABLE_NAME))
                                        {
                                            NoDefaultValuePossible = true;
                                            noCheck = true;
                                        }    
                                    }
                                    if (!noCheck)
                                    {
                                        //throw new Exception(ExceptionStrDefault + "rColSys.IsCOLUMN_DEFAULTNull()=True");    //lth
                                    }
                                }
                            }
                            qs2.core.dbBase.setResultDbNull(ref ret);
                        }
                        else
                        {
                            if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.bit.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                if (rColSys.COLUMN_DEFAULT.Contains("0"))
                                {
                                    ret.valueObj = false;
                                    ret.valueStr = "0";
                                }
                                else if (rColSys.COLUMN_DEFAULT.Contains("1"))
                                {
                                    ret.valueObj = true;
                                    ret.valueStr = "1";
                                }
                            }
                            else if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.datetime.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                qs2.core.dbBase.getDefaultDBValueDateTime(ref rColSys, onlyDateTimeWithoutDefaultValue, ref ret);
                            }
                            else if (rColSys.DATA_TYPE.ToLower() == qs2.core.dbBase.typInt.ToLower())
                            {
                                ret.valueStr = qs2.core.generic.readStrBetween(rColSys.COLUMN_DEFAULT, ref startIndex, "(", ")", true, true, true);
                                ret.valueObj = System.Convert.ToInt32(ret.valueStr);
                            }
                            else if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.typFloat, StringComparison.OrdinalIgnoreCase) || rColSys.DATA_TYPE.Equals(qs2.core.dbBase.typDecimal, StringComparison.OrdinalIgnoreCase) || rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.numeric.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                ret.valueStr = qs2.core.generic.readStrBetween(rColSys.COLUMN_DEFAULT, ref startIndex, "(", ")", true, true, true);
                                ret.valueStr = ret.valueStr.ToString().Replace(",", ".");
                                double dbl = Convert.ToDouble(ret.valueStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                                ret.valueObj = dbl;
                            }
                            else if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.nvarchar.ToString(), StringComparison.OrdinalIgnoreCase) || rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.varchar.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                if (rColSys.COLUMN_DEFAULT.Contains("''"))
                                {
                                    ret.valueStr = "";
                                    ret.valueObj = "";
                                }
                                else
                                {
                                    ret.valueStr = qs2.core.generic.readStrBetween(rColSys.COLUMN_DEFAULT, ref startIndex, "'", "", true, true, true);
                                    ret.valueObj = ret.valueStr;
                                }
                            }
                            else if (rColSys.DATA_TYPE.Equals(qs2.core.dbBase.DBTypeSqlServer.uniqueidentifier.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                if (rColSys.COLUMN_DEFAULT.Contains(qs2.core.dbBase.DBTypeSqlServer.newid.ToString()))
                                {
                                    ret.valueStr = System.Guid.NewGuid().ToString();
                                    ret.valueObj = ret.valueStr;
                                }
                                else
                                {
                                    if (rColSys.COLUMN_DEFAULT.Contains("''"))
                                    {
                                        ret.valueStr = "";
                                        ret.valueObj = "";
                                    }
                                    else
                                    {
                                        ret.valueStr = qs2.core.generic.readStrBetween(rColSys.COLUMN_DEFAULT, ref startIndex, "'", "", true, true, true);
                                        ret.valueObj = new System.Guid(ret.valueStr);
                                    }
                                }
                            }
                        }
                    }
                }

                return ret;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep("dbBase.getDefaultDBValue:" + ex.ToString(), ex.Message, "Fkt. getDefaultDBValue '" + rColSys.TABLE_NAME + "." + rColSys.COLUMN_NAME + "'  ");
                qs2.core.generic.retValue ret = new qs2.core.generic.retValue();
                return ret;
            }
        }

        public static bool checkColSysNullable(ref qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys)
        {
            try
            {
                if (rColSys.IsIS_NULLABLENull())
                {
                    throw new Exception("dbBase.checkColSysNullable: rColSys.IsIS_NULLABLENull()=True");
                    //qs2.core.dbBase.setResultDbNull(ref ret);
                }
                else
                {
                    if (rColSys.IS_NULLABLE.ToLower() == qs2.core.dbBase.Yes.ToLower())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.checkColSysNullable: " + ex.ToString());
                return false;
            }
        }
        
        public static void getDefaultDBValueDateTime(ref qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys, bool onlyDateTimeWithoutDefaultValue, 
                                                                    ref qs2.core.generic.retValue ret)
        {
            if (!rColSys.IsCOLUMN_DEFAULTNull())
            {
                int startIndex = 0;
                if (rColSys.COLUMN_DEFAULT.Contains(qs2.core.dbBase.DBTypeSqlServer.getdate.ToString()))
                {
                    DateTime dateTime = System.DateTime.Now.Date;
                    ret.valueStr = dateTime.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                    ret.valueObj = dateTime;
                }
                else
                {
                    ret.valueStr = qs2.core.generic.readStrBetween(rColSys.COLUMN_DEFAULT, ref startIndex, "'", "", true, true, true);
                    DateTime dateTimeFound = System.Convert.ToDateTime(ret.valueStr, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                    ret.valueObj = dateTimeFound;
                }
            }
        }

        public static void setResultDbNull(ref qs2.core.generic.retValue retValueToSet)
        {
            retValueToSet.valueObj = System.DBNull.Value;
            retValueToSet.valueStr = "";
        }

        public static void initRow(System.Data.DataRow r, int id, bool doID)
        {
            foreach (System.Data.DataColumn col in r.Table.Columns)
            {
                if (col.ColumnName.Equals(qs2.core.sqlTxt.columnID) && doID)
                {
                     r[qs2.core.sqlTxt.columnID] = id;
                }
                else
                {
                    qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(r.Table.TableName, col.ColumnName, qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);
                    if (rColSys != null)
                    {
                        bool NoDefaultValuePossible = false;
                        System.Collections.Generic.List<string> lstTablesNoDateTimeCheck = new System.Collections.Generic.List<string>();
                        qs2.core.generic.retValue retValue1 = qs2.core.dbBase.getDefaultDBValue(ref rColSys, true, lstTablesNoDateTimeCheck, ref NoDefaultValuePossible);
                        r[col.ColumnName] = retValue1.valueObj;
                    }
                    else
                    {
                        qs2.core.dbBase.initColumnManuell(ref r, col);
                    }
                }
            }
        }

        public static void initColumnManuell(ref System.Data.DataRow r, System.Data.DataColumn col)
        {
            if (col.DataType.FullName.ToString().Equals(typeof(System.Boolean).FullName))
            {
                r[col.ColumnName] = false;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.String).FullName))
            {
                r[col.ColumnName] = "";
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.Double).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Decimal).FullName))
            {
                r[col.ColumnName] = 0;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.Int32).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Int16).FullName) ||
                        col.DataType.FullName.ToString().Equals(typeof(System.Int64).FullName))
            {
                r[col.ColumnName] = -1;
            }
            else if (col.DataType.FullName.ToString().Equals(typeof(System.DateTime).FullName))
            {
                r[col.ColumnName] = System.DBNull.Value;
            }
        }

        public static void initRowStayxy(System.Data.DataRow r, int id)
        {
            foreach (System.Data.DataColumn col in r.Table.Columns )
            {
                if (col.DataType.FullName.ToString().Equals(typeof(System.Boolean).FullName))
                {
                    r[col.ColumnName] = false;
                }
                else if (col.DataType.FullName.ToString().Equals(typeof(System.String).FullName))
                {
                    r[col.ColumnName] = "";
                }
                else if (   col.DataType.FullName.ToString().Equals(typeof(System.Double).FullName) ||
                            col.DataType.FullName.ToString().Equals(typeof(System.Decimal).FullName))
                {
                    r[col.ColumnName] = 0;
                }
                else if (col.DataType.FullName.ToString().Equals(typeof(System.Int32).FullName) ||
                            col.DataType.FullName.ToString().Equals(typeof(System.Int16).FullName) ||
                            col.DataType.FullName.ToString().Equals(typeof(System.Int64).FullName))
                {
                    r[col.ColumnName] = -1;
                }
                else if (col.DataType.FullName.ToString().Equals(typeof(System.DateTime).FullName))
                {
                    r[col.ColumnName] = System.DBNull.Value;
                }
            }

            r[qs2.core.sqlTxt.columnID] = id;
        }

        public static bool setRowDateTimeNullxy(DateTime dateTimeValue)
        {
            if (dateTimeValue.Year.Equals(dbBase.minDateTime))
                return true;
            else
                return false;
        }

        public static void setRowDateTimeTo1900ForWorkingxy(System.Data.DataSet ds)
        {
            foreach (System.Data.DataTable table in ds.Tables)
            {
                foreach (System.Data.DataRow row in table.Rows)
                {
                    foreach (System.Data.DataColumn col in row.Table.Columns)
                    {
                        if (col.ColumnName == "Dis2MortDt30Day")
                        {
                            string xy = "";
                        }
                        if (col.DataType.Equals(typeof(System.DateTime)))
                        {
                            if (row[col.ColumnName].GetType().Equals(typeof(System.DBNull)))
                            {
                                if (row[col.ColumnName] == System.DBNull.Value)
                                {
                                    row[col.ColumnName] = qs2.core.dbBase.minDateTime;
                                }
                            }
                        }
                    }

                }
            }
        }

        public static void registerColumnChangingxyxxy(System.Data.DataSet ds, bool register )
        {
            foreach (System.Data.DataTable table in ds.Tables)
            {
                if (register)
                    table.ColumnChanging += new System.Data.DataColumnChangeEventHandler(qs2.core.dbBase.ColumnChanging);
                else
                    table.ColumnChanging -= new System.Data.DataColumnChangeEventHandler(qs2.core.dbBase.ColumnChanging);
            }
        }

        public static void ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (e.Column.DataType.Equals(typeof(System.DateTime)))
            {
                if (e.Row[e.Column].Equals(System.DBNull.Value))
                {
                    e.Row[e.Column] = qs2.core.dbBase.minDateTime;
                }

            }
        }

        public static bool viewIsFunction2(string viewName)
        {
            try
            {
                if (viewName.Trim().Equals(""))
                    return false;

                if (viewName.Substring(0, 3).Trim().ToLower() == qs2.core.dbBase.prefixFunction.Trim().ToLower())
                {
                    return true; 
                }
                else if (viewName.Trim().ToLower().Contains(".fnc"))
                {
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.viewIsFunction:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return false;
            }
        }

        public static string getFunctionName(string viewName)
        {
            try
            {
                return viewName;            //viewName.Substring(4, viewName.Length - 4);
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.getFunctionName:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return "";
            }
        }


        public static void getOleDbException(OleDbException e)
        {
            string errorMessages = "";
            for (int i = 0; i < e.Errors.Count; i++)
            {
                errorMessages += "Index #" + i + "\n" +
                                 "Message: " + e.Errors[i].Message + "\n" +
                                 "NativeError: " + e.Errors[i].NativeError + "\n" +
                                 "Source: " + e.Errors[i].Source + "\n" +
                                 "SQLState: " + e.Errors[i].SQLState + "\n";
            }

            string txtLog = DateTime.Now.ToString() + " getOleDbException: Error - " + "\r\n" + "\r\n" + errorMessages + "\r\n" + "\r\n" + e.ToString();
            //return txtLog.Trim();
            throw new Exception(txtLog);
        }


        public static dbBase.eTypeInt getType(Type DataType)
        {
            try
            {
                dbBase.eTypeInt typeRet = dbBase.eTypeInt.none;
                if (DataType.Equals(typeof(string)))
                {
                    typeRet = dbBase.eTypeInt.t_string;
                }
                else if (DataType.Equals(typeof(int)) || DataType.Equals(typeof(Int32)) ||
                        DataType.Equals(typeof(Int16)) || DataType.Equals(typeof(Int64)))
                {
                    typeRet = dbBase.eTypeInt.t_int;
                }
                else if (DataType.Equals(typeof(Double)) || DataType.Equals(typeof(Decimal)))
                {
                    typeRet = dbBase.eTypeInt.t_dbl;
                }
                else if (DataType.Equals(typeof(DateTime)))
                {
                    typeRet = dbBase.eTypeInt.t_DateTime;
                }
                else if (DataType.Equals(typeof(System.DBNull)))
                {
                    typeRet = dbBase.eTypeInt.t_DBNull;
                }
                else if (DataType.Equals(typeof(System.Guid)))
                {
                    typeRet = dbBase.eTypeInt.t_Guid;
                }
                else if (DataType.Equals(typeof(System.Byte[])))
                {
                    typeRet = dbBase.eTypeInt.t_Binary;
                }
                else if (DataType.Equals(typeof(System.Boolean)))
                {
                    typeRet = dbBase.eTypeInt.t_Boolean;
                }
                else if (DataType.Equals(typeof(Nullable)))
                {
                    throw new Exception("getType: rColKeysDBDev.DataType '" + DataType.ToString() + "' not possible!");
                }
                else
                {
                    throw new Exception("getType: rColKeysDBDev.DataType '" + DataType.ToString() + "' not possible!");
                }

                return typeRet;
            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.getType: " + ex.ToString());
            }
        }

        public static void checkConnectedOnDesignerDB()
        {
            try
            {
                if (qs2.core.dbBase.Database.Trim().ToLower().Equals(("QS2_DEV").Trim().ToLower()))
                {
                    qs2.core.ENV.ConnectedOnDesignerDB_QS2_Dev = true;
                    qs2.core.ENV.ExtendedUI = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("logIn.checkDesignerDB: " + ex.ToString());
            }

        }

    }

}
