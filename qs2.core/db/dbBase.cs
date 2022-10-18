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
        
        private static System.Data.SqlClient.SqlConnection _dbConnThreadMain;

        public bool setConnectionDB2()
        {
            try
            {
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
    }
}
