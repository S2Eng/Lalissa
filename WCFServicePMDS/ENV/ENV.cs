using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.BAL.Main;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;

namespace WCFServicePMDS
{

    public class ENV
    {
        public static bool Testmodus2 { get; set; }
        public static Guid VersionNr = new Guid("10000000-1009-1000-0000-000000000001");

        public static bool IsInitialized { get; set; }


        public static ENVWCFDto _ENVWcf;
        public static ENVLauncherDto _ENVLauncher;
        public static ENVPMDSDto _ENVPMDS;
        public static ENVClientDto _ENVClient;
        private static ConcurrentDictionary<Guid, ENVClientDto> _dicENVClientDto;
        private static int _CurrentProcessId;



        public static ENVWCFDto ENVWcf
        {
            get { return _ENVWcf; }
            set { _ENVWcf = value; }
        }
        public static ENVLauncherDto ENVLauncher
        {
            get { return _ENVLauncher; }
            set { _ENVLauncher = value; }
        }
        public static ENVPMDSDto ENVPMDS
        {
            get { return _ENVPMDS; }
            set { _ENVPMDS = value; }
        }
        public static ENVClientDto ENVClient
        {
            get { return _ENVClient; }
            set { _ENVClient = value; }
        }
        public static ConcurrentDictionary<Guid, ENVClientDto> dicENVClientDto
        {
            get => _dicENVClientDto;
            set => _dicENVClientDto = value;
        }
        public static int CurrentProcessId
        {
            get => _CurrentProcessId;
            set => _CurrentProcessId = value;
        }






        public static void init2(string client, string user, ENVClientDto clientVars, int ClientProcessId)
        {
            try
            {
                if (!IsInitialized)
                {
                    ENVWcf = new ENVWCFDto();

                    ENVClient = clientVars;
                    ENVWcf.BinPath = AppDomain.CurrentDomain.BaseDirectory;
                    DirectoryInfo dirInfoBinPath = new DirectoryInfo(ENVWcf.BinPath);
                    ENVWcf.RootPath = dirInfoBinPath.Parent.FullName;
                    ENVWcf.LogPath = clientVars.LogPathPMDS;

                    ENVWcf.ConfigPath = clientVars.ConfigPathPMDS;
                    ENVWcf.ConfigFile = clientVars.ConfigFilePMDS;  //Path.Combine(ENVWcf.ConfigPath, "PMDS.config");
                    ENVWcf.TempPathWin = Path.Combine(System.IO.Path.GetTempPath(), "PMDSWCFService");
                    ENVWcf.ReportPath = Path.Combine(ENVWcf.RootPath, "Reports");

                    //System.Windows.Forms.MessageBox.Show("ReportPath = " + Path.Combine(ENVWcf.RootPath, "Reports"));
                    //System.Windows.Forms.MessageBox.Show("TempPath = " + Path.Combine(System.IO.Path.GetTempPath(), "PMDSWCFService"));

                    ENV.checkDirectory(ENVWcf.LogPath);
                    //ENV.checkDirectory(ENVWcf.ReportPath);
                    ENV.checkDirectory(ENVWcf.TempPathWin);

                    ENV.CurrentProcessId = ClientProcessId;
                    WCFServicePMDS.Hosts.CheckClientRunning CheckClientRunning1 = new Hosts.CheckClientRunning();
                    CheckClientRunning1.start();

                    ENV.initPDFIum();
                    ENV.readConfig<ENVWCFDto>(clientVars.ConfigFilePMDS, ENVWcf);

                    DateTime dFrom = DateTime.Now;

                    Log.write("Client: " + client + (user.Trim() != "" ? ", User: " + user + "" : "") + "\r\n" + "Service sucessfull initialized!", false, 0);

                    IsInitialized = true;
                }


                if (dicENVClientDto == null)
                    dicENVClientDto = new ConcurrentDictionary<Guid, ENVClientDto>();
                dicENVClientDto.TryAdd(clientVars.IDClient, clientVars);

                //ENV.loadDataStartUp(DateTime.Now, clientVars.IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.ENV.init2: " + ex.ToString());
            }
        }


        public static ENVClientDto getClientDtoFromDict(Guid IDClient)
        {
            var valPair = ENV.dicENVClientDto.Where(o => o.Key == IDClient).First();
            return valPair.Value;
        }

        public static void loadDataStartUp(DateTime dFrom, Guid IDClient)
        {
            using (WCFServicePMDS.Repository.RepositoryWrapper repoWrapper = new Repository.RepositoryWrapper(IDClient))
            {
                ItblPfad dtotblPfad = new ItblPfadDAL(repoWrapper);
              ConcurrentBag<tblPfadDTO> l = dtotblPfad.getAll();
            }

            //var tasks = new[]
            //{
            //    Task.Run(() => new StammdatenBAL().loadAll(dFrom)),
            //    Task.Run(() => new BenutzerMainBAL().loadAll(dFrom)),
            //    Task.Run(() => new PatientMainBAL().loadAll(dFrom))
            //};
            //Task.WaitAll(tasks);

            //var tasks1 = new[]
            //{
            //    Task.Run(() => KlinikMainBAL.loadAllKlinik(dFrom)),
            //    Task.Run(() => new BenutzerMainBAL().loadBen(dFrom)),
            //    Task.Run(() => new PatientMainBAL().loadAllPatient(dFrom))
            //};
            //Task.WaitAll(tasks1);



            var tBen = new Task(() =>
            {
                new BenutzerMainBAL().loadAll(dFrom, IDClient);
            });
            var tPat = new Task(() =>
            {
                new PatientMainBAL().loadAll(dFrom.Date, IDClient);
            });
            var tKlin = new Task(() =>
            {
                new StammdatenBAL().loadAll(dFrom, IDClient);
            });
            var tvKlienten = new Task(() =>
            {
                Task<ConcurrentBag<vKlientenlisteDTO>> t = new PatientMainBAL().getvKlientenliste(IDClient);
            });
            tBen.Start();
            tPat.Start();
            tKlin.Start();
            tvKlienten.Start();
            Task.WaitAll(tBen, tPat, tKlin, tvKlienten);
            Exceptions.checkFault(new List<Task>() { tBen, tPat, tKlin, tvKlienten });


            BenutzerMainBAL.ready = false;
            var tKlin2 = new Task(() =>
            {
                KlinikMainBAL.loadAllKlinik(dFrom);
            });
            var tBen2 = new Task(() =>
            {
                new BenutzerMainBAL().loadBen(dFrom);
            });
            var tPat2 = new Task(() =>
            {
                new PatientMainBAL().loadAllPatient(dFrom);
            });
            tBen2.Start();
            tPat2.Start();
            tKlin2.Start();
            Task.WaitAll(tBen2, tPat2, tKlin2);
            while (!BenutzerMainBAL.ready) { bool bNoTReady = true; }
            Exceptions.checkFault(new List<Task>() { tBen2, tPat2, tKlin2 });

        }
     

        public static bool readConfig<T>(string configFile, T env)
        {
            try
            {
                qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

                System.IO.StreamReader str = new System.IO.StreamReader(configFile);
                while (str.Peek() >= 0)
                {
                    string line = str.ReadLine().Trim();
                    if (line.Length > 2 && !line.StartsWith("//"))
                    {
                        int index = line.IndexOf('=');
                        if (index > 0)
                        {
                            string sVar = line.Substring(0, index).Trim();
                            string sValue = line.Substring(index + 1).Trim();
                            bool decrypt = (sVar.Equals("ExchangePwd", StringComparison.CurrentCultureIgnoreCase) || sVar.Equals("SmtpPwd", StringComparison.CurrentCultureIgnoreCase)) ? true : false;
                            Mapping.setValProp<T>(env, sVar, sValue, decrypt);
                        }
                    }
                }
                str.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.ENV.readConfig: " + ex.ToString());
            }
        }

        public static void checkDirectory(string dir)
        {
            try
            {
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.ENV.checkDirectory: " + ex.ToString());
            }
        }

        public static void initPDFIum()
        {
            Patagames.Pdf.Net.PdfCommon.Initialize("52433553494d50032923be84e16cd6ae0bce153446af7918d52303038286fd2b0597de34bf5bb65e2a161a268e74107bd7da7c1adb202edff3e8c55a13bff7afa38569c96e45ff0cdef48e36b8df77e907676788cae00126f52c5eaadbb3c424062e8e0e5feb6faf89900306ee469aa40664bdf84b2e4fce7497c19f3f9d2d877dc1be192cb695f4");
        }


        

        public static void initServiceStarter(ref Dictionary<string, string> lHosts, ref string configFileBack, ref bool StartFirstHostAuto, bool sameDirAsExe)
        {
            try
            {
                string BinPathTmp = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo dirInfoBinPath = new DirectoryInfo(BinPathTmp);

                string LogPathTmp = "";
                string ConfigPathTmp = "";
                if (sameDirAsExe)
                {
                    LogPathTmp = BinPathTmp;
                    ConfigPathTmp = BinPathTmp;
                }
                else
                {
                    string RootPathTmp = dirInfoBinPath.Parent.FullName;
                    LogPathTmp = Path.Combine(RootPathTmp, "log");
                    ConfigPathTmp = Path.Combine(RootPathTmp, "config");
                }

                ENV.checkDirectory(LogPathTmp);
                ENV.checkDirectory(ConfigPathTmp);

                string fileHosts = Path.Combine(ConfigPathTmp, "hosts.config");
                if (System.IO.File.Exists(fileHosts))
                {
                    readHosts(fileHosts, ref lHosts, ref StartFirstHostAuto);
                }
                configFileBack = fileHosts;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.ENV.getHosts: " + ex.ToString());
            }
        }
        public static bool readHosts(string hostsFile, ref Dictionary<string, string> lHosts, ref bool StartFirstHostAuto)
        {
            try
            {
                qs2.license.core.Encryption Encryption1 = new qs2.license.core.Encryption();

                System.IO.StreamReader str = new System.IO.StreamReader(hostsFile);
                while (str.Peek() >= 0)
                {
                    string line = str.ReadLine().Trim();
                    if (line.Length > 2 && !line.StartsWith("//"))
                    {
                        int index = line.IndexOf('=');
                        if (index > 0)
                        {
                            string sVar = line.Substring(0, index).Trim();
                            string sValue = line.Substring(index + 1).Trim();
                            if (sVar.Trim().ToLower().StartsWith(("host").Trim().ToLower()) )
                            {
                                lHosts.Add(sVar, sValue);
                            }
                            else
                            {
                                if (sVar.Equals("startFirstHostAuto", StringComparison.InvariantCultureIgnoreCase) && sValue.Trim().Equals(("1")))
                                {
                                    StartFirstHostAuto = true;
                                }
                            }
                        }
                    }
                }
                str.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.ENV.readHosts: " + ex.ToString());
            }
        }

    }

}
