using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Launcher
{

    public class update
    {
        public static string StartFromShare = "";

        public static string ServerProgramPath = "";
        public static string ServerConfigPath = "";

        public static string ClientProgramPath = "";
        public static string ClientConfigPath = "";

        public static string ActualVersion = "";
        public static string UpdateVersion = "";
        public static string InfoUpdate = "";

        public static string copyFileType = "*.*";
        public static string logPathUpdate = "";
        public static string logPathPMDS = "";

        public config config1 = new config();


        //Launcher
        public static string sConfigPath = "";
        public static string sConfigFile = "";
        public static string sProgramPath = "";
        public static string sProgramFile = "";
        public static string sshowSplash = "0";

        public static SortedList<string, string> lstVersionsRemoveRoot = new SortedList<string, string>();
        public static SortedList<string, string> lstVersionsRemoveConfig = new SortedList<string, string>();

        public static string dirVersionInstalled_Root = "";
        public static string dirVersionInstalled_Config = "";

        public static string ClientProgramPath_Orig = "";
        public static string ClientConfigPath_Orig = "";

        public static string InstNext_Root = "";
        public static string InstNext_Config = "";

        public static bool thread_RemoveOldInst = true;
        public static bool thread_CopyNextInstReady = true;



        public bool run(string CommandLine, ref bool StartFromShareBack, bool WithMsgBox, ref bool abortBack, ref bool FirstInstallation)
        {
            string eExceptInfo = "Client: " + System.Environment.MachineName;
            try
            {
                update.thread_RemoveOldInst = true;
                update.thread_CopyNextInstReady = true;

                CfgFile ConfigFile = new CfgFile(Launcher.config.configFile);

                update.StartFromShare = ConfigFile.getValue("Main", "StartFromShare", false);
                if (!update.StartFromShare.Trim().Equals("0"))
                {
                    StartFromShareBack = true;
                    return true;
                }

                update.ServerProgramPath = ConfigFile.getValue("Main", "ServerProgramPath", false);
                update.logPathUpdate = Path.Combine(System.IO.Directory.GetParent(update.ServerProgramPath).FullName, "log");
                this.checkPath(update.logPathUpdate, "logPathUpdate is emtpy in launcher.config", false, true);

                update.ServerConfigPath = Path.Combine(ConfigFile.getValue("Main", "ServerConfigPath", false), "PMDS");
                update.ClientProgramPath = ConfigFile.getValue("Main", "ClientProgramPath", false);
                update.ClientConfigPath = Path.Combine(ConfigFile.getValue("Main", "ClientConfigPath", false), "PMDS");

                update.sshowSplash = ConfigFile.getValue("Main", "showSplash", false);

                update.ClientProgramPath_Orig = update.ClientProgramPath;
                update.ClientConfigPath_Orig = update.ClientConfigPath;

                update.lstVersionsRemoveRoot = new SortedList<string, string>();
                update.lstVersionsRemoveConfig = new SortedList<string, string>();
                string newMoveNextFolder = "";
                string LastMoveNextFolder = "";
                this.searchNewNextFolder(ref update.ClientProgramPath, ref update.ClientConfigPath, ref newMoveNextFolder, ref LastMoveNextFolder, ref update.lstVersionsRemoveRoot, ref update.lstVersionsRemoveConfig);

                update.InstNext_Root = Path.Combine(update.ClientProgramPath_Orig, newMoveNextFolder);
                update.InstNext_Config = Path.Combine(update.ClientConfigPath_Orig, newMoveNextFolder);

                string lastInstNext_Root = "";
                string lastInstNext_Config = "";
                if (LastMoveNextFolder.Trim() != "")
                {
                    lastInstNext_Root = Path.Combine(update.ClientProgramPath_Orig, LastMoveNextFolder);
                    lastInstNext_Config = Path.Combine(update.ClientConfigPath_Orig, LastMoveNextFolder);
                }

                update.logPathPMDS = Path.Combine(update.ServerConfigPath, "log");
                this.checkPath(update.logPathPMDS, "logPathPMDS is emtpy in launcher.config", false, true);
                update.logPathUpdate = update.logPathPMDS;

                update.ActualVersion = ConfigFile.getValue("Main", "ActualVersion", false);
                update.UpdateVersion = ConfigFile.getValue("Main", "UpdateVersion", false);
                update.InfoUpdate = ConfigFile.getValue("Main", "InfoUpdate", false);

                this.checkPath(update.ServerProgramPath, "ServerProgramPath not exists or is emtpy in launcher.config", true, false);
                this.checkPath(update.ServerConfigPath, "ServerConfigPath not exists or is emtpy in launcher.config", true, false);

                this.checkPath(update.ClientProgramPath, "ClientProgramPath  is emtpy in launcher.config", false, true);
                this.checkPath(update.ClientConfigPath, "ClientConfigPath  is emtpy in launcher.config", false, true);

                bool bDoUpdate = false;
                bool bShowInfoUpdate = true;
                string ActualVersionTmp = update.ActualVersion;
                if (update.UpdateVersion.Trim() != "")
                {
                    if (!update.InfoUpdate.Trim().Equals("1"))
                    {
                        bShowInfoUpdate = false;
                    }
                    update.ActualVersion = update.UpdateVersion.Trim();
                    bDoUpdate = true;
                }

                if (update.ActualVersion.Trim() == "")
                {
                    StartFromShareBack = false;
                    abortBack = true;
                    if (bShowInfoUpdate)
                    {
                        System.Windows.Forms.MessageBox.Show("Es steht keine Version zum Starten zur Verfügung!", "PMDS", MessageBoxButtons.OK);
                    }
                    return false;
                }

                bool installUpdate = true;
                bool bSwitchedBackToActualVersion = false;
                if (installUpdate)
                {
                    if (bDoUpdate)
                    {
                        if (lastInstNext_Root.Trim() == "" || !System.IO.Directory.Exists(lastInstNext_Root))
                        {
                            update.ActualVersion = ActualVersionTmp.Trim();
                            bDoUpdate = false;
                            bShowInfoUpdate = true;
                            bSwitchedBackToActualVersion = true;
                            FirstInstallation = true;
                        }
                        if (lastInstNext_Config.Trim() == "" || !System.IO.Directory.Exists(lastInstNext_Config))
                        {
                            update.ActualVersion = ActualVersionTmp.Trim();
                            bDoUpdate = false;
                            bShowInfoUpdate = true;
                            bSwitchedBackToActualVersion = true;
                            FirstInstallation = true;
                        }

                        if (!bSwitchedBackToActualVersion)
                        {
                            string InstPathRoot = Path.Combine(update.ClientProgramPath, update.ActualVersion.Trim());
                            string InstPathConfig = Path.Combine(update.ClientConfigPath, update.ActualVersion.Trim());

                            if (!System.IO.Directory.Exists(InstPathRoot.Trim()))
                            {
                                System.IO.Directory.Move(lastInstNext_Root, InstPathRoot);
                            }
                            else
                            {
                                bDoUpdate = false;
                            }

                            if (!System.IO.Directory.Exists(InstPathConfig.Trim()))
                            {
                                System.IO.Directory.Move(lastInstNext_Config, InstPathConfig);
                            }
                            else
                            {
                                bDoUpdate = false;
                            }
                        }
                    }

                    //install
                    int iCounterCopySuccessfull = 0;
                    int iCounterCopyError = 0;

                    Nullable<DateTime> dLastVersionFoundRoot = null;
                    string dirToInstallRoot = "";
                    bool ActualVersionFoundOnServerRoot = false;
                    this.searchLastVersionToInstall(update.ServerProgramPath, ref update.ClientProgramPath, ref dLastVersionFoundRoot, ref dirToInstallRoot, ref lstVersionsRemoveRoot, ref ActualVersionFoundOnServerRoot);

                    Nullable<DateTime> dLastVersionFoundConfig = null;
                    string dirToInstallConfig = "";
                    bool ActualVersionFoundOnServerConfig = false;
                    this.searchLastVersionToInstall(update.ServerConfigPath, ref update.ClientConfigPath, ref dLastVersionFoundConfig, ref dirToInstallConfig, ref lstVersionsRemoveConfig, ref ActualVersionFoundOnServerConfig);

                    if (!ActualVersionFoundOnServerRoot || !ActualVersionFoundOnServerConfig)
                    {
                        StartFromShareBack = false;
                        abortBack = true;
                        System.Windows.Forms.MessageBox.Show("Version '" + update.ActualVersion.Trim() + "' zum Starten am Server nicht gefunden!", "PMDS", MessageBoxButtons.OK);
                        return false;
                    }

                    bool bNewVersionRootInstalled = false;
                    bool bNewVersionConfigInstalled = false;
                    frmInstallingNewVersion frmSplash = null;
                    if (dLastVersionFoundRoot != null)
                    {
                        update.ClientProgramPath = Path.Combine(update.ClientProgramPath, dirToInstallRoot);
                        if (!System.IO.Directory.Exists(update.ClientProgramPath) || bDoUpdate)
                        {
                            this.showSplash(ref frmSplash, bShowInfoUpdate);
                            this.copyFolder_rek(Path.Combine(update.ServerProgramPath, dirToInstallRoot), ref update.ClientProgramPath, ref iCounterCopySuccessfull, ref iCounterCopyError);
                            bNewVersionRootInstalled = true;
                            log.writeLog("Update sucessfully installed on machine " + System.Environment.MachineName.Trim() + " (Version root: " + dirToInstallRoot + ", Files copied to client:" + iCounterCopySuccessfull.ToString() + ")!", false);
                            update.dirVersionInstalled_Root = update.ClientProgramPath;
                        }
                        if (bSwitchedBackToActualVersion)
                        {
                            update.dirVersionInstalled_Root = update.ClientProgramPath;
                        }
                    }

                    if (dLastVersionFoundConfig != null)
                    {
                        update.ClientConfigPath = Path.Combine(update.ClientConfigPath, dirToInstallConfig);
                        if (!System.IO.Directory.Exists(update.ClientConfigPath) || bDoUpdate)
                        {
                            this.showSplash(ref frmSplash, bShowInfoUpdate);
                            this.copyFolder_rek(Path.Combine(update.ServerConfigPath, dirToInstallConfig), ref update.ClientConfigPath, ref iCounterCopySuccessfull, ref iCounterCopyError);
                            bNewVersionConfigInstalled = true;
                            log.writeLog("Update sucessfully installed on machine " + System.Environment.MachineName.Trim() + " (Version config: " + dirToInstallRoot + ", Files copied to client:" + iCounterCopySuccessfull.ToString() + ")!", false);
                            update.dirVersionInstalled_Config = update.ClientConfigPath;
                        }
                        if (bSwitchedBackToActualVersion)
                        {
                            update.dirVersionInstalled_Config = update.ClientConfigPath;
                        }
                    }

                    if (bShowInfoUpdate && frmSplash != null)
                    {
                        frmSplash.Close();
                    }

                    update.sProgramPath = Path.Combine(update.ClientProgramPath, "bin");
                    update.sConfigPath = Path.Combine(update.ClientConfigPath, "Config");

                    if (iCounterCopyError > 0)
                    {
                        throw new Exception("Launcher.update.run: Error iCounterCopyError>0 - some files not correctly copied to client!");
                    }

                    if (bNewVersionRootInstalled || bNewVersionConfigInstalled)
                    {
                        if (WithMsgBox)
                        {
                            bool bAnyVersionInstalled = false;
                            string sInfoVersion = "";
                            if (bNewVersionRootInstalled)
                            {
                                sInfoVersion = "\r\n" + "Version: " + dLastVersionFoundRoot.Value.ToString("dd.MM.yyyy") + ", Root-Dir: " + dirToInstallRoot.Trim();
                                bAnyVersionInstalled = true;
                            }
                            if (bNewVersionConfigInstalled)
                            {
                                sInfoVersion += (sInfoVersion.Trim() == "" ? "\r\n" : "\r\n") + "Configuration: " + dLastVersionFoundConfig.Value.ToString("dd.MM.yyyy") + ", Config-Dir: " + dirToInstallConfig.Trim(); ;
                                bAnyVersionInstalled = true;
                            }

                            if (bAnyVersionInstalled)
                            {
                                sInfoVersion = "\r\n" + sInfoVersion;
                                if (bShowInfoUpdate)
                                {
                                    System.Windows.Forms.MessageBox.Show("Neue Version wurde installiert!" + sInfoVersion + "", "PMDS Update", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
                else
                {
                    update.sProgramPath = Path.Combine(update.ClientProgramPath, "bin");
                    update.sConfigPath = Path.Combine(update.ClientConfigPath, "Config");
                }

                if (update.dirVersionInstalled_Root.Trim() != "" && update.dirVersionInstalled_Config.Trim() != "")
                {
                    this.thStart_removePMDSInstallation();
                    this.thStart_CopyActInstToNext();
                }
                else
                {
                    update.thread_CopyNextInstReady = true;
                }

                return true;
            }
            catch (Exception ex)
            {
                log.writeLog(eExceptInfo + " - " + ex.ToString(), true);
                throw new Exception("Launcher.update.run: " + eExceptInfo + " - " + ex.ToString());
            }
        }

        public void searchLastVersionToInstall(string FolderFromTmp, ref string FolderToTmp, ref Nullable<DateTime> dVersionFoundBack, ref string dirToInstallBack,
                                                ref SortedList<string, string> lstVersionsRemove, ref bool ActualVersionFoundOnServer)
        {
            try
            {
                SortedList<string, string> lstVersionsFound = new SortedList<string, string>();
                System.IO.DirectoryInfo dirSearchInfoServer = new DirectoryInfo(FolderFromTmp);
                foreach (DirectoryInfo dirInfo in dirSearchInfoServer.GetDirectories())
                {
                    try
                    {
                        string dirInfoName = dirInfo.Name.Trim().ToLower();
                        if (dirInfoName.StartsWith(("recent.x86"))
                            && !dirInfoName.Contains("copy")
                            && !dirInfoName.Contains("kopie")
                            && dirInfoName.Equals(update.ActualVersion.Trim().ToLower()))
                        {
                            lstVersionsFound.Add(dirInfo.Name.Trim(), dirInfo.Name.Trim());
                            ActualVersionFoundOnServer = true;
                        }

                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("Launcher.update.searchLastVersionToInstall: Error foreach dirsFound - " + ex2.ToString());
                    }
                }

                System.IO.DirectoryInfo dirSearchInfoClient = new DirectoryInfo(FolderToTmp);
                foreach (DirectoryInfo dirInfo in dirSearchInfoClient.GetDirectories())
                {
                    try
                    {
                        string dirInfoName = dirInfo.Name.Trim().ToLower();
                        if (dirInfoName.StartsWith("recent.x86")
                            && !dirInfoName.Equals(update.ActualVersion.Trim().ToLower()))
                        {
                            lstVersionsRemove.Add(dirInfo.Name.Trim(), Path.Combine(FolderToTmp, dirInfo.Name.Trim()));
                        }

                    }
                    catch (Exception ex2)
                    {
                        throw new Exception("Launcher.update.searchLastVersionToInstall: Error foreach dirSearchInfoClient - " + ex2.ToString());
                    }
                }

                Nullable<DateTime> dLastVersion = null;
                string sDirToinstall = "";
                foreach (KeyValuePair<string, string> dirPair in lstVersionsFound)
                {
                    string dir = dirPair.Key.Trim();
                    string sDate = dirPair.Key.Split('.').Last().Trim();

                    string sYear = "20" + sDate.Substring(0, 2);
                    string sMonth = sDate.Substring(2, 2);
                    string sDay = sDate.Substring(4, 2);

                    DateTime dVersion = new DateTime(System.Convert.ToInt32(sYear), System.Convert.ToInt32(sMonth), System.Convert.ToInt32(sDay), 0, 0, 0);
                    if (dLastVersion == null)
                    {
                        dLastVersion = dVersion.Date;
                        sDirToinstall = dir;
                    }
                    else
                    {
                        if (dVersion.Date >= dLastVersion.Value.Date)
                        {
                            dLastVersion = dVersion.Date;
                            sDirToinstall = dir;
                        }
                    }
                }

                dVersionFoundBack = dLastVersion;
                dirToInstallBack = sDirToinstall.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.searchLastVersionToInstall: Folder search " + FolderFromTmp + " - " + "\r\n" + ex.ToString());
            }
        }
        public void searchNewNextFolder(ref string FolderRootToTmp, ref string FolderConfigToTmp, ref string newMoveNextFolder, ref string LastMoveNextFolder, ref SortedList<string,
                                        string> lstVersionsRemoveRootTmp, ref SortedList<string, string> lstVersionsRemoveConfigTmp)
        {
            try
            {
                int lastNrDirMoveNext = -1;
                SortedList<string, string> lstMoveNextDirs = new SortedList<string, string>();
                if (System.IO.Directory.Exists(FolderRootToTmp.Trim()))
                {
                    System.IO.DirectoryInfo dirSearchInfoServer = new DirectoryInfo(FolderRootToTmp);
                    foreach (DirectoryInfo dirInfo in dirSearchInfoServer.GetDirectories())
                    {
                        try
                        {
                            string dirInfoName = dirInfo.Name.Trim().ToLower();
                            if (dirInfoName.StartsWith("next.recent.x86.")
                                && !dirInfoName.Contains("copy")
                                && !dirInfoName.Contains("kopie"))
                            {
                                string dir = dirInfo.FullName.Trim();
                                int lastPoint = dir.Trim().LastIndexOf(".");
                                string sNrFold = dir.Trim().Substring(lastPoint + 1, dir.Trim().Length - lastPoint - 1);
                                int nNrFold = System.Convert.ToInt32(sNrFold.Trim());
                                if (nNrFold > lastNrDirMoveNext)
                                {
                                    lastNrDirMoveNext = nNrFold;
                                    LastMoveNextFolder = dirInfo.Name.Trim();
                                }

                                lstMoveNextDirs.Add(dirInfo.Name.Trim(), dirInfo.FullName.Trim());
                            }
                        }
                        catch (Exception ex2)
                        {
                            throw new Exception("Launcher.update.searchNewNextFolder: Error foreach searchNewNextFolder - " + ex2.ToString());
                        }
                    }
                }

                if (lastNrDirMoveNext == -1)
                {
                    lastNrDirMoveNext = 1;
                }
                else
                {
                    lastNrDirMoveNext += 1;
                }
                newMoveNextFolder = "Next.Recent.x86." + lastNrDirMoveNext.ToString();


                foreach (KeyValuePair<string, string> dirMoveNextPair in lstMoveNextDirs)
                {
                    lstVersionsRemoveRootTmp.Add(dirMoveNextPair.Key.Trim(), Path.Combine(FolderRootToTmp, dirMoveNextPair.Key.Trim()));
                    lstVersionsRemoveConfigTmp.Add(dirMoveNextPair.Key.Trim(), Path.Combine(FolderConfigToTmp, dirMoveNextPair.Key.Trim()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.searchNewNextFolder: " + "\r\n" + ex.ToString());
            }
        }

        public void copyFolder_rek(string FolderFromTmp, ref string FolderToTmp, ref int iCounterCopySuccessfull, ref int iCounterCopyError)
        {
            try
            {
                if (!System.IO.Directory.Exists(FolderToTmp))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(FolderToTmp);
                        var dirInfo = new DirectoryInfo(FolderToTmp);
                        dirInfo.Attributes = FileAttributes.Normal;

                    }
                    catch (Exception ex4)
                    {
                        throw new Exception("Launcher.update.copyFolder_rek: cannot create directory '" + FolderToTmp + "' on client '" + System.Environment.MachineName + "' for install new version!" + "\r\n" + "\r\n" + ex4.ToString());
                    }
                }

                string[] FilesFoundInDirectory = System.IO.Directory.GetFiles(FolderFromTmp, update.copyFileType, System.IO.SearchOption.TopDirectoryOnly);
                foreach (string FileInFolderFound in FilesFoundInDirectory)
                {
                    try
                    {
                        string onlyFileName = System.IO.Path.GetFileName(FileInFolderFound.Trim());
                        string OrigDirName = System.IO.Path.GetDirectoryName(FileInFolderFound.Trim());
                        this.CopyFile(ref OrigDirName, ref FolderToTmp, ref onlyFileName,
                                        ref iCounterCopySuccessfull, ref iCounterCopyError);
                    }
                    catch (Exception ex2)
                    {
                        iCounterCopyError += 1;
                        throw new Exception("Launcher.update.copyFolder_rek: Error foreach - " + ex2.ToString());
                    }
                }

                foreach (string SubFolder in System.IO.Directory.GetDirectories(FolderFromTmp, "*", System.IO.SearchOption.TopDirectoryOnly))
                {

                    string LastDir = new DirectoryInfo(SubFolder).Name.Trim().ToLower();
                    if (!LastDir.Equals("log") && !LastDir.Equals("hag_zertifikat"))
                    {
                        string FolderToTmpSub = System.IO.Path.Combine(FolderToTmp, LastDir);
                        this.copyFolder_rek(SubFolder, ref FolderToTmpSub, ref iCounterCopySuccessfull, ref iCounterCopyError);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.copyFolder_rek:" + ex.ToString());
            }
        }
        public void CopyFile(ref string FolderFromTmp, ref string FolderToTmp, ref string FileName,
                                ref int iCounterCopySuccessfull, ref int iCounterCopyError)
        {
            try
            {
                try
                {
                    string sFolderFromTmp = FolderFromTmp.Trim().ToLower();
                    string sFolderToTmp = FolderToTmp.Trim().ToLower();
                    string sFileName = FileName.Trim().ToLower();

                    if (sFolderFromTmp == "")
                    {
                        throw new Exception("Launcher.update.CopyFile: FolderFromTmp is empty");
                    }

                    if (sFolderToTmp == "")
                    {
                        throw new Exception("Launcher.update.CopyFile: FolderToTmp is empty");
                    }

                    if (FolderFromTmp.Equals(FolderToTmp))
                    {
                        throw new Exception("Launcher.update.CopyFile: Error FolderFromTmp = FolderToTmp !");
                    }

                    string fileFrom = "";
                    string fileTo = "";
                    fileFrom = Path.Combine(FolderFromTmp.Trim(), FileName.Trim());
                    System.IO.FileInfo FileInfoFrom = new System.IO.FileInfo(fileFrom);
                    FileInfoFrom.IsReadOnly = false;
                    fileTo = Path.Combine(FolderToTmp.Trim(), FileName.Trim());

                    if (System.IO.File.Exists(fileTo))
                    {
                        try
                        {
                            System.IO.File.Delete(fileTo);
                        }
                        catch (Exception ex4)
                        {
                            throw new Exception("Launcher.update.CopyFile: error delete file '" + fileTo + "' from client '" + System.Environment.MachineName + "' for install new one!" + "\r\n" + "\r\n" + ex4.ToString());
                        }
                    }

                    try
                    {
                        System.IO.File.Copy(fileFrom, fileTo, true);
                    }
                    catch (Exception ex5)
                    {
                        throw new Exception("Launcher.update.CopyFile: error copy file '" + fileTo + "' to client '" + System.Environment.MachineName + "' when install new version!" + "\r\n" + "\r\n" + ex5.ToString());
                    }
                    iCounterCopySuccessfull += 1;

                }
                catch (Exception ex)
                {
                    throw new Exception("Launcher.update.CopyFile:" + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                iCounterCopyError += 1;
                throw new Exception("Launcher.update.CopyFile:" + ex.ToString());
            }
        }

        public void thStart_removePMDSInstallation()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(this.th_removePMDSInstallation));
                t.Start();

            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.thStart_removePMDSInstallation:" + ex.ToString());
            }
        }
        public void th_removePMDSInstallation()
        {
            try
            {
                update.thread_RemoveOldInst = false;

                foreach (KeyValuePair<string, string> dirPairRoot in update.lstVersionsRemoveRoot)
                {
                    try
                    {
                        bool bClearInst = true;
                        try
                        {
                            string sCheckPMDSMainDir = Path.Combine(dirPairRoot.Value, "bin");
                            if (System.IO.Directory.Exists(sCheckPMDSMainDir))
                            {
                                string sExeFile = Path.Combine(sCheckPMDSMainDir, "PMDS.Main.exe");
                                System.IO.File.Delete(sExeFile.Trim());
                            }
                        }

                        catch (UnauthorizedAccessException ex)
                        {
                            bClearInst = false;
                        }

                        catch (Exception ex3)
                        {
                            throw new Exception("th_removePMDSInstallation: " + ex3.ToString());
                        }

                        if (bClearInst)
                        {
                            if (System.IO.Directory.Exists(dirPairRoot.Value))
                            {
                                this.DeleteDirectory(dirPairRoot.Value);
                            }

                            if (update.lstVersionsRemoveConfig.ContainsKey(dirPairRoot.Key))
                            {
                                string fullPathConfigToDelete = update.lstVersionsRemoveConfig[dirPairRoot.Key];
                                if (System.IO.Directory.Exists(fullPathConfigToDelete))
                                {
                                    this.DeleteDirectory(fullPathConfigToDelete);
                                }
                            }
                        }
                    }

                    catch (Exception ex45)
                    {
                        string sExcept45 = "Launcher.update.th_removePMDSInstallation:" + ex45.ToString();
                        log.writeLog(sExcept45, true);
                    }
                }
                update.thread_RemoveOldInst = true;

            }
            catch (Exception ex)
            {
                update.thread_RemoveOldInst = true;
                string sExcept5 = "Launcher.update.th_removePMDSInstallation:" + ex.ToString();
                log.writeLog(sExcept5, true);
                throw new Exception(sExcept5);
            }
        }

        public void thStart_CopyActInstToNext()
        {
            try
            {
                Thread t = new Thread(new ThreadStart(this.th_CopyActInstToNext));
                t.Start();
            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.thStart_CopyActInstToNext:" + ex.ToString());
            }
        }
        public void th_CopyActInstToNext()
        {
            try
            {
                update.thread_CopyNextInstReady = false;

                if (System.IO.Directory.Exists(update.InstNext_Root))
                {
                    this.DeleteDirectory(update.InstNext_Root);
                }

                if (System.IO.Directory.Exists(update.InstNext_Config))
                {
                    this.DeleteDirectory(update.InstNext_Config);
                }

                int iCounterCopySuccessfull = 0;
                int iCounterCopyError = 0;
                this.copyFolder_rek(update.dirVersionInstalled_Root.Trim(), ref update.InstNext_Root, ref iCounterCopySuccessfull, ref iCounterCopyError);

                iCounterCopySuccessfull = 0;
                iCounterCopyError = 0;
                this.copyFolder_rek(update.dirVersionInstalled_Config.Trim(), ref update.InstNext_Config, ref iCounterCopySuccessfull, ref iCounterCopyError);

                update.thread_CopyNextInstReady = true;
            }
            catch (Exception ex)
            {
                update.thread_CopyNextInstReady = true;
                string sExcept5 = "Launcher.update.th_CopyActInstToNext:" + ex.ToString();
                log.writeLog(sExcept5, true);
                throw new Exception(sExcept5);
            }
        }

        public void DeleteDirectory(string path)
        {
            try
            {
                var directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };
                foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
                {
                    info.Attributes = FileAttributes.Normal;
                }
                directory.Delete(true);
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteDirectory: " + ex.ToString());
            }
        }

        public void checkPMDSIsRunning(ref bool abort, ref bool installUpdate)
        {
            try
            {
                System.Collections.Generic.List<Process> lstPMDSRunning = new List<Process>();

                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.Trim().ToLower().Equals("pmds.main"))
                    {
                        lstPMDSRunning.Add(process);
                    }
                }

                if (lstPMDSRunning.Count > 0)
                {
                    DialogResult dialogRes = System.Windows.Forms.MessageBox.Show("Eine neue Version von PMDS wurde zur Installation gefunden!" + "\r\n" +
                                                                                    "Soll PMDS beendet werden und das Update durchgeführt werden?", "PMDS Update", MessageBoxButtons.YesNoCancel);
                    if (dialogRes == DialogResult.Yes)
                    {
                        foreach (Process process in lstPMDSRunning)
                        {
                            process.Kill();
                        }
                        installUpdate = true;
                    }
                    else if (dialogRes == DialogResult.Cancel)
                    {
                        installUpdate = false;
                        abort = true;
                    }
                    else
                    {
                        installUpdate = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.checkPMDSIsRunning:" + ex.ToString());
            }
        }
        public void checkPath(string sPath, string Excepinfo, bool checkPathExist, bool createPath)
        {
            try
            {
                if (sPath.Trim() == "")
                {
                    throw new Exception("Launcher.update.CopyFile: " + Excepinfo);
                }

                if (checkPathExist)
                {
                    if (!System.IO.Directory.Exists(sPath.Trim()))
                    {
                        throw new Exception("Launcher.update.CopyFile: path '" + sPath.Trim() + "' not exists!");
                    }
                }

                if (createPath)
                {
                    if (!System.IO.Directory.Exists(sPath.Trim()))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(sPath.Trim());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Launcher.update.CopyFile: can not create path '" + sPath.Trim() + "'!");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.checkPath:" + ex.ToString());
            }
        }

        public void showSplash(ref frmInstallingNewVersion frmSplash, bool bShowInfoUpdate)
        {
            try
            {
                if (bShowInfoUpdate && frmSplash == null)
                {
                    frmSplash = new frmInstallingNewVersion();
                    frmSplash.TopMost = true;
                    frmSplash.Show();
                    Application.DoEvents();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Launcher.update.showSplash:" + ex.ToString());
            }
        }

        public static void WaitMilli(int WaitMilliseconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitMilliseconds)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
