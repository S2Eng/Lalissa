using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL
{


    public class dbBase
    {
        public static System.Data.SqlClient.SqlConnection _dbConn = null;

        public static string Database = "";
        public static string Server = "";
        public static string User = "";
        public static string PwdDecrypted = "";
        public static string PwdEncrypted = "";
        public static bool TrustedConnection = false;

        public static string connStr = "";
        public static System.DateTime minDateTime = new System.DateTime(1900, 1, 1);
        public static int _counterReconnect = 0;
        public static int CommandTimeOutEFCore = 720;

        public static System.Data.SqlClient.SqlConnection dbConn
        {
            get
            {
                throw new Exception("WCFServicePMDS.DAL.dbBase.dbConn: Function not allowed!");

                if (dbBase._dbConn.State != System.Data.ConnectionState.Open)
                {
                    System.Threading.Thread.Sleep(5 * 1000);
                    dbBase.reconnect(dbBase._counterReconnect);
                }
                return dbBase._dbConn;
            }
            set
            {
                dbBase._dbConn = value;
            }
        }

        public static bool reconnect(int counterReconnect)
        {
            try
            {
                throw new Exception("WCFServicePMDS.DAL.dbBase.reconnect: Function not allowed!");

                dbBase._counterReconnect += 1;

                dbBase._dbConn = new System.Data.SqlClient.SqlConnection(dbBase.connStr);
                dbBase._dbConn.Open();
                //dbBase.getDBContext();

                return true;
            }
            catch (Exception ex)
            {
                if (dbBase._counterReconnect <= 20)
                {
                    generic.waitMS(20);
                    return dbBase.reconnect(dbBase._counterReconnect);
                }
                else
                {
                    string eExcep = "Can not connect to Database!" + "\r\n" + "\r\n" + "dbBase.reconnect: " + ex.ToString();
                    throw new Exception("WCFServicePMDS.DAL.dbBase.reconnect: " + eExcep);
                }
            }
        }

        public static System.Data.Common.DbConnectionStringBuilder getVarConnStr(string ConnectionStr)
        {
            try
            {
                QS2.functions.vb.Encryption Encryption1 = new QS2.functions.vb.Encryption();
                System.Data.Common.DbConnectionStringBuilder OLEDBBuilder = new System.Data.Common.DbConnectionStringBuilder();
                OLEDBBuilder.ConnectionString = ConnectionStr.Trim();

                if (OLEDBBuilder.ContainsKey("Provider"))
                {
                    dbBase.Database = OLEDBBuilder["Initial Catalog"].ToString();
                    dbBase.Server = OLEDBBuilder["Data Source"].ToString();

                    if (OLEDBBuilder.ContainsKey("User ID") && OLEDBBuilder.ContainsKey("Password"))
                    {
                        dbBase.User = OLEDBBuilder["User ID"].ToString();
                        string PwdDecrypted = Encryption1.StringDecrypt(OLEDBBuilder["Password"].ToString().Trim(), QS2.functions.vb.Encryption.keyForEncryptingStrings);
                        dbBase.PwdDecrypted = PwdDecrypted;
                        dbBase.TrustedConnection = false;
                    }
                    else
                    {
                        dbBase.TrustedConnection = true;
                    }
                }
                else
                {
                    System.Data.SqlClient.SqlConnectionStringBuilder sqlBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionStr.Trim());
                    dbBase.Database = sqlBuilder.InitialCatalog;
                    dbBase.Server = sqlBuilder.DataSource;

                    if (!sqlBuilder.IntegratedSecurity)
                    {
                        dbBase.User = sqlBuilder.UserID;
                        string PwdDecrypted = Encryption1.StringDecrypt(sqlBuilder.Password.Trim(), QS2.functions.vb.Encryption.keyForEncryptingStrings);
                        dbBase.PwdDecrypted = PwdDecrypted;
                        dbBase.TrustedConnection = false;
                    }
                    else
                    {
                        dbBase.TrustedConnection = true;
                    }
                }

                return OLEDBBuilder;
            }

            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.DAL.dbBase.getVarConnStr: " + ex.ToString());
            }
        }


        public string getDbEntityValidationException(System.Data.Entity.Validation.DbEntityValidationException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var failure in ex.EntityValidationErrors)
            {
                sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors)
                {
                    sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    sb.AppendLine();
                }
            }
            return "Entity Validation Failed - errors follow:\n" + sb.ToString();
        }

        public static string getDbEntityValidationException2(System.Data.Entity.Validation.DbEntityValidationException ex, string NameFct)
        {
            dbBase dbBase1 = new dbBase();
            string sExcept = dbBase1.getDbEntityValidationException(ex);
            sExcept = "Function: " + NameFct + "\r\n" + sExcept;
            return sExcept;
        }


        public static void setConnection(ref System.Data.SqlClient.SqlDataAdapter da)
        {
            if (da.SelectCommand != null)
            {
                da.SelectCommand.Connection = dbBase.dbConn;
            }
            if (da.InsertCommand != null)
            {
                da.InsertCommand.Connection = dbBase.dbConn;
            }
            if (da.UpdateCommand != null)
            {
                da.UpdateCommand.Connection = dbBase.dbConn;
            }
            if (da.DeleteCommand != null)
            {
                da.DeleteCommand.Connection = dbBase.dbConn;
            }
        }





        public static void checkEFCorexy()
        {
            try
            {
                //using (var context = dbBase.CreateContextEFCorePMDS())
                //{
                //    var t = (from a in context.Abteilung
                //            select new { ID = a.Id });
                //    int c = t.Count();
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("dbBase.checkEFCore: " + ex.ToString());
            }
        }

        public static PMDSDevContext CreateContextEFCorePMDS(Guid IDClient)
        {
            try
            {
                string sConnStr = ""
;                //sConnStr = "Data Source=STY041;Initial Catalog=pmds_DemoGross;Integrated Security=SSPI;";
                ENVClientDto clientDto = ENV.getClientDtoFromDict(IDClient);
                var optionsBuilder = new DbContextOptionsBuilder<PMDSDevContext>();
                
                if (!clientDto.trusted)
                {
                    sConnStr = "Server=" + clientDto.Srv.Trim() + "; Database=" + clientDto.Db.Trim() + ";User ID=" + clientDto.Usr.Trim() + ";Password=" + clientDto.Pwd.Trim() + ";Trusted_Connection=False;";
                }
                else
                {
                    sConnStr = "Server=" + clientDto.Srv.Trim() + "; Database=" + clientDto.Db.Trim() + ";Trusted_Connection=True;";
                }
                

                optionsBuilder.UseSqlServer(sConnStr, options => options.EnableRetryOnFailure());

                PMDSDevContext context = new PMDSDevContext(optionsBuilder.Options);
                context.Database.SetCommandTimeout(dbBase.CommandTimeOutEFCore);
                return new PMDSDevContext(optionsBuilder.Options);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CreateContextEFCorePMDS: " + ex.ToString());
            }
        }
        public static PMDSDevContext CreateContextEFCorePMDS_orig()
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<PMDSDevContext>();
                string sConnStr = "";
                if (!dbBase.TrustedConnection)
                {
                    sConnStr = "Server=" + dbBase.Server.Trim() + "; Database=" + dbBase.Database.Trim() + ";User ID=" + dbBase.User.Trim() + ";Password=" + dbBase.PwdDecrypted.Trim() + ";Trusted_Connection=False;";
                }
                else
                {
                    sConnStr = "Server=" + dbBase.Server.Trim() + "; Database=" + dbBase.Database.Trim() + ";Trusted_Connection=True;";
                }
            
                optionsBuilder.UseSqlServer(sConnStr, options => options.EnableRetryOnFailure());

                PMDSDevContext context = new PMDSDevContext(optionsBuilder.Options);
                context.Database.SetCommandTimeout(dbBase.CommandTimeOutEFCore);
                return new PMDSDevContext(optionsBuilder.Options);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.CreateContextEFCorePMDS: " + ex.ToString());
            }
        }

    }

}
