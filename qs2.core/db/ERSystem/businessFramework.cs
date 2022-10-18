using PMDS.db.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using S2Extensions;

namespace qs2.core.db.ERSystem
{
    public class businessFramework
    {
        public List<Guid> GetSelListDocuments(string IDApplication, string IDParticipant)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    return (from s in db.tblSelListEntries
                            join g in db.tblSelListGroup on s.IDGroup equals g.ID
                            join sobj in db.tblSelListEntriesObj on s.ID equals sobj.IDSelListEntrySublist
                            where g.IDGroupStr == "Documents" && (g.IDApplication == IDApplication || g.IDApplication == "ALL") &&
                            g.IDParticipant == "ALL" && (s.IDParticipant == IDParticipant || s.IDParticipant == "ALL") &&
                            sobj.typIDGroup == "Queries"
                            select (Guid)sobj.IDGuid).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkUsercode: " + ex.ToString());
            }
        }

        public bool checkDBVersion(string ThisExeVersion, ref string DBExeVersion)
        {
            try
            {
                DBExeVersion = "";
                using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                {
                    System.Linq.IQueryable<tblDBVersion> tDBVersion = db.tblDBVersion.OrderByDescending(x => x.Description);

                    if (tDBVersion.Count() == 0)        // Wenn nichts in der DB eingetragen ist, keine Prüfung, sonst den letzten Eintrag vergleichen
                    {
                        return true;
                    }
                    else
                    {
                        tblDBVersion rDBVersion = tDBVersion.First();
                        DBExeVersion = rDBVersion.Description.Trim();
                    }
                    return CompareVersionStrings(ThisExeVersion, DBExeVersion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkDBVersion: " + ex.ToString());
            }
        }

        public bool checkReferenzVersion(string ThisExeVersion, string PathReferenzExe, ref string ReferenzExeVersion)
        {
            try
            {
                if (PathReferenzExe.Trim().Length == 0)    // Wenn keine Referenz-Exe angegeben ist, keine Prüfung
                    return true;

                if (System.IO.File.Exists(PathReferenzExe))
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(PathReferenzExe);
                    ReferenzExeVersion = versionInfo.ProductVersion; 
                }
                else
                {
                    ReferenzExeVersion = "Reference not found";
                    return false;
                }
                return CompareVersionStrings(ThisExeVersion, ReferenzExeVersion);
            }

            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkReferenzVersion: " + ex.ToString());
            }
        }

        public bool CompareVersionStrings(string strA, string strB)
        {
            try
            {
                //Version liegt im Format xxx.xxx.xxx.xxx vor
                string[] vExe = strA.Split(new Char[] { '.' });
                string[] vDB = strB.Split(new Char[] { '.' });

                if (vExe.Length != vDB.Length)
                {
                    return false;
                    //throw new Exception("VersionCheck (format) failed. Please contact your Admin.");
                }

                for (int i = 0; i <= vExe.Length - 1; i++)
                {
                    string a = vExe[i];
                    string b = vDB[i];
                    int ia = 0;
                    int ib = 0;

                    bool aIsNumeric = Int32.TryParse(a, out ia);
                    bool bIsNumeric = Int32.TryParse(b, out ib);

                    if (aIsNumeric && bIsNumeric)
                    {
                        if (ia > ib)            //Wenn ein Nummernblock größer ist als der andere -> Prüfung positiv abbrechen
                            return true;

                        if (ia < ib)
                            return false;       
                    }
                    else
                    {
                        return false;
                        //throw new Exception("VersionCheck (numeric) failed. Please contact your Admin.");
                    }
                }
                return true;        //Alle Nummernblöcke sind gleich

            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.CompareVersionStrings: " + ex.ToString());
            }
        }

        public bool checkLicenseKey(System.Collections.Generic.List<string> lstLicenseKeys, string FldShort, string Application)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.checkLicenseKey - FldShort:" + FldShort.Trim() + ", Application:" + Application.Trim() + "\r\n" + ex.ToString());
            }
        }

        public static PMDS.db.Entities.ERModellPMDSEntities getDBContext()
        {
            try
            {               
                PMDS.db.Entities.ERModellPMDSEntities DBContext = new PMDS.db.Entities.ERModellPMDSEntities();
                businessFramework.setERConnectionSqlDb(ref DBContext);
                return DBContext;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.getDBContext: " + ex.ToString());
            }
        }

        public static void setERConnectionSqlDb(ref PMDS.db.Entities.ERModellPMDSEntities DBContext)
        {
            try
            {
                SqlConnectionStringBuilder sqlDBBuilder = new SqlConnectionStringBuilder();
                System.Data.Common.DbConnectionStringBuilder SqlDBBuilder = new System.Data.Common.DbConnectionStringBuilder();
                sqlDBBuilder.DataSource = dbBase.Server;
                sqlDBBuilder.InitialCatalog = dbBase.Database;
                sqlDBBuilder.PersistSecurityInfo = true;
                sqlDBBuilder.MultipleActiveResultSets = true;
                if (!string.IsNullOrWhiteSpace(dbBase.User) && !string.IsNullOrWhiteSpace(dbBase.PwdDecrypted))
                {
                        sqlDBBuilder.UserID = dbBase.User;
                        sqlDBBuilder.Password = dbBase.PwdDecrypted;
                }
                else
                {
                    sqlDBBuilder.IntegratedSecurity = true;
                }

                DBContext.Database.Connection.ConnectionString = sqlDBBuilder.ConnectionString;
                DBContext.Database.Connection.Open();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFramework.setConnection: " + ex.ToString());
            }
        }

        public static bool WriteERConnectionStringSqlDb()
        {
            try
            {
                string ConnectionName = "ERModellPMDSEntities";
                string providerName = "System.Data.SqlClient";
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connection = config.ConnectionStrings.ConnectionStrings[ConnectionName];

                //Wenn es die Connection schon gibt, prüfen, ob die richtige DB und der richtige Server eingetragen sind
                if (connection != null && connection.ConnectionString.sContains(dbBase.Database) &&
                    connection.ConnectionString.sContains(dbBase.Server))
                {
                    return true;
                }

                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = dbBase.Server,
                    InitialCatalog = dbBase.Database,
                    ApplicationName = "EntityFramework",
                    MultipleActiveResultSets = true
                };

                if (dbBase.User != null)
                {
                    if (!string.IsNullOrWhiteSpace(dbBase.User))
                    {
                        sqlBuilder.UserID = dbBase.User;
                        sqlBuilder.Password = dbBase.PwdDecrypted;
                    }
                }
                else
                {
                    sqlBuilder.IntegratedSecurity = true;
                }

                ConnectionStringsSection csSection = config.ConnectionStrings;
                ConnectionStringSettingsCollection csCollection = csSection.ConnectionStrings;
                ConnectionStringSettings cs = csCollection[ConnectionName];
                if (cs != null)
                {
                    csCollection.RemoveAt(csCollection.IndexOf(cs));
                    ConfigurationManager.RefreshSection("connectionStrings");
                }

                Configuration configNew = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                csSection.ConnectionStrings.Add(
                    new ConnectionStringSettings(ConnectionName,
                        sqlBuilder.ConnectionString,
                        providerName));

                configNew.Save(ConfigurationSaveMode.Modified, false);
                ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("businessFranmework.WriteERConnectionStringSqlDb: " + ex.ToString());

            }
        }
    }
}
