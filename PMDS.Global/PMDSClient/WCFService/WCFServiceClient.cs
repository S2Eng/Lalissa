using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.DB;
using PMDS.Global.db.ERSystem;
using PMDS.Global.PMDSClient;
using PMDS.Global.PMDSClient.WCFService;
using PMDS.GUI.ELGA;
using QS2.Desktop.ControlManagment;
using QS2.Desktop.ControlManagment.ServiceReference_01;
using WCFServicePMDS;


namespace PMDSClient.Sitemap
{

    public class WCFServiceClient
    {

        //public static string urlWCFServiceDefault2 = "http://localhost:8733/Design_Time_Addresses/WCFServicePMDS/Service1/";
        private static string urlWCFServiceDefault2 = "net.pipe://localhost/Design_Time_Addresses/WCFServicePMDS{0}/Service1";
        private static string urlGuid = System.Guid.NewGuid().ToString().Replace("-", "");






        public class cParsWCF
        {
            public string MachineName = "";
            public string LoginInNameFrei = "";
            public Guid gVersionNr;
        }

        private static bool _IsInitialized = false;

        public static bool IsInitialized
        {
            get => _IsInitialized;
            set => _IsInitialized = value;
        }

        public class ELGALogInDto
        {
            public bool LogInOK { get; set; }
            public ELGASessionDTO session { get; set; }
        }

        public class cSearchGdaFlds
        {
            public string NachnameFirma { get; set; }
            public string Vorname { get; set; }
            public string PLZ { get; set; }
            public string Ort { get; set; }
            public string Strasse { get; set; }
            public string StrasseNr { get; set; }
        }
        public class genCDARes
        {
            public bool bOK { get; set; }
            public string xml { get; set; }
            public byte[] bXml { get; set; }
        }

        public bool localWCFElgaYN = true;
        public static Guid IDClient;








        public static void init()
        {
            try
            {
                if (!PMDSClientWrapper.WCFServiceOnOff)
                {
                    return;
                }

                DateTime dNow = DateTime.Now;
                WCFServiceClient WCFServiceClientPMDS1 = new WCFServiceClient();
                cParsWCF ParsWCF = new cParsWCF();
                ParsWCF.MachineName = System.Environment.MachineName.Trim();
                ParsWCF.LoginInNameFrei = PMDSClientWrapper.LoginInNameFrei;
                ParsWCF.gVersionNr = PMDS.Global.ENV.VersionNr;
                Thread threadSendExcept = new Thread(WCFServiceClientPMDS1.thread_initWCFService);
                threadSendExcept.IsBackground = true;
                threadSendExcept.Start(ParsWCF);


                //QS2.Desktop.ControlManagment.WCFServicePMDS.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.WCFServicePMDS.Service1Client("BasicHttpBinding_IService1", ENV.UrlWCFServicePMDS.Trim());
                //bool bCheckOK = Service1Client1.TestService(System.Environment.MachineName.Trim(), ENV.LoginInNameFrei, ENV.VersionNr);
                //bool CallOK = true;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Wcf-Service initialisieren fehlgeschlagen!") + "WCFServiceClientPMDS.init: " + ex.ToString());
            }
        }

        
        public void thread_initWCFService(object pars)
        {
            try
            {
                if (PMDS.Global.ENV.WCFServicePMDSDebugPath.Trim() == "")
                {
                    PMDS.Global.ENV.WCFServicePMDSDebugPath = PMDS.Global.ENV.path_bin.Trim();
                }

                if (!PMDS.Global.ENV.WCFServiceDebugMode)
                {
                    //this.stopCheckWCFServiceLocal(false);

                    string urlWCFServiceBack = "";
                    if (!PMDS.Global.ENV.WCFServiceOnlyLocal)
                    {
                        bool bUrlFound = this.genUrlWCFService(ref urlWCFServiceBack);
                    }
                    else
                    {
                        urlWCFServiceDefault2 = string.Format(urlWCFServiceDefault2, urlGuid);
                        urlWCFServiceBack = urlWCFServiceDefault2.Trim();
                    }

                    PMDSClientWrapper.UrlWCFServicePMDS = urlWCFServiceBack.Trim();
                    string sWCFServiceName = @PMDS.Global.ENV.WCFServicePMDSDebugPath.Trim() + "\\" + @PMDS.Global.ENV.WCFHostManager.Trim() + ".exe";
                    //MessageBox.Show(sWCFServiceName + "\r\n" + urlWCFServiceBack);

                    Process proc = new Process();
                    proc.StartInfo.FileName = sWCFServiceName;
                    proc.StartInfo.UseShellExecute = true;
                    //proc.StartInfo.Verb = "runas";
                    proc.StartInfo.Arguments = "?typ=Background ?urlGuid=" + urlGuid + "";

                    proc.Start();
                    System.Threading.Thread.Sleep(500);
                    //System.Diagnostics.Process.Start(sWCFServiceName, "?typ=Background");
                }
                else
                {
                    urlWCFServiceDefault2 = string.Format(urlWCFServiceDefault2, "");
                }

                cParsWCF ParsWCF = (cParsWCF)pars;
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = WCFServiceClient.getWCFClient(true);
                
                string sConfigPathTmp = System.IO.Path.GetDirectoryName(PMDS.Global.ENV.sConfigFile.Trim());
                string sConfigFileTmp = System.IO.Path.GetFileName(PMDS.Global.ENV.sConfigFile.Trim());

                WCFServiceClient.IDClient = System.Guid.NewGuid();
                //QS2.Desktop.ControlManagment.ServiceReference_01.ENVClientDto ENVDto = new QS2.Desktop.ControlManagment.ServiceReference_01.ENVClientDto() { ConfigPathPMDSk__BackingField = sConfigPathTmp, ConfigFilePMDSk__BackingField = sConfigFileTmp, IDClientk__BackingField = WCFServiceClient.IDClient, Srvk__BackingField = RBU.DataBase.Srv, Usrk__BackingField = RBU.DataBase.m_sUser, Pwdk__BackingField = RBU.DataBase.m_sPassword, Dbk__BackingField = RBU.DataBase.m_Database, trustedk__BackingField = RBU.DataBase.IsTrusted };
                //bool bCheckOK = Service1Client1.initService(ParsWCF.MachineName, ParsWCF.LoginInNameFrei, false, ParsWCF.gVersionNr, ENVDto);
                //bool bRetTest = Service1Client1.TestWCFService();

                int iInitializeCounter = 0;
                bool bInitalized = false;
                while (!bInitalized)
                {
                    try
                    {
                        iInitializeCounter += 1;
                        QS2.Desktop.ControlManagment.ServiceReference_01.ENVClientDto ENVDto = new QS2.Desktop.ControlManagment.ServiceReference_01.ENVClientDto() { ConfigPathPMDSk__BackingField = sConfigPathTmp, ConfigFilePMDSk__BackingField = sConfigFileTmp, IDClientk__BackingField = WCFServiceClient.IDClient, Srvk__BackingField = RBU.DataBase.Srv, Usrk__BackingField = RBU.DataBase.m_sUser, Pwdk__BackingField = RBU.DataBase.m_sPassword, Dbk__BackingField = RBU.DataBase.m_Database, trustedk__BackingField = RBU.DataBase.IsTrusted };
                        bInitalized = Service1Client1.initService(ParsWCF.MachineName, ParsWCF.LoginInNameFrei, false, ParsWCF.gVersionNr, ENVDto, Process.GetCurrentProcess().Id);
                    }
                    catch (Exception ex)
                    {
                        System.Threading.Thread.Sleep(1000);
                        if (iInitializeCounter > 5)
                            throw new Exception("WCFServiceClient.thread_initWCFService: " + ex.ToString());
                    }
                }

                if (!PMDS.Global.ENV.WCFServiceDebugMode)
                {
                    //QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1ClientCentral = WCFServiceClient.getWCFClient(false);
                    //bool bCheckCentralOK = Service1ClientCentral.initService(ParsWCF.MachineName, ParsWCF.LoginInNameFrei, false, ParsWCF.gVersionNr, null);
                }

                //this.getAllStammdaten(ref Service1Client1);
                WCFServiceClient.IsInitialized = true;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex, "Exception", true, true, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wcf-Service per Thread initialisieren fehlgeschlagen!"));
            }
        }

        public static QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client getWCFClient(bool localService)
        {
            try
            {
                if (PMDS.Global.ENV.WCFServiceDebugMode)
                {
                    localService = true;
                }
                string UrlTmp = "";
                if (localService)
                {
                    UrlTmp = urlWCFServiceDefault2.Trim();
                }
                else
                {
                    UrlTmp = PMDSClientWrapper.UrlWCFServicePMDS.Trim();
                }

                TimeSpan t10 = new TimeSpan(10, 0, 0);
                TimeSpan t24 = new TimeSpan(23, 59, 59);

                if (UrlTmp.Trim().ToLower().StartsWith(("http://").Trim().ToLower()))
                {
                    var binding = new BasicHttpBinding()
                    {
                        Name = "BasicHttpBinding_PMDSService1",
                        MaxBufferSize = 2147483647,
                        MaxBufferPoolSize = 2147483647,
                        MaxReceivedMessageSize = 2147483647,
                        ReceiveTimeout = t10,
                        SendTimeout = t24
                    };
                    var endpoint = new EndpointAddress(UrlTmp);
                    QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client(binding, endpoint);
                    //client.WSFunctionCompleted += (object sender, WSFunctionCompletedEventArgs e) => { };
                    return client;

                    //QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client("BasicHttpBinding_Service1", ENV.UrlWCFServicePMDS.Trim());
                }
                else if (UrlTmp.Trim().ToLower().StartsWith(("net.tcp://").Trim().ToLower()))
                {
                    var binding = new NetTcpBinding()
                    {
                        Name = "NetTcpBinding_PMDSService1",
                        MaxBufferSize = 2147483647,
                        MaxBufferPoolSize = 2147483647,
                        MaxReceivedMessageSize = 2147483647,
                        ReceiveTimeout = t10,
                        SendTimeout = t24
                    };

                    var endpoint = new EndpointAddress(UrlTmp);
                    QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client(binding, endpoint);
                    //client.WSFunctionCompleted += (object sender, WSFunctionCompletedEventArgs e) => { };
                    return client;
                }
                else if (UrlTmp.Trim().ToLower().StartsWith(("net.pipe://").Trim().ToLower()))
                {
                    var binding = new NetNamedPipeBinding()
                    {
                        Name = "NetPipeBinding_PMDSService1",
                        MaxBufferSize = 2147483647,
                        MaxBufferPoolSize = 2147483647,
                        MaxReceivedMessageSize = 2147483647,
                        ReceiveTimeout = t10,
                        SendTimeout = t24
                    };

                    var endpoint = new EndpointAddress(UrlTmp);
                    QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client(binding, endpoint);
                    //client.WSFunctionCompleted += (object sender, WSFunctionCompletedEventArgs e) => { };
                    return client;
                }
                else
                {
                    throw new Exception("getWCFClient: Only http- or net.tcp-calls allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Wcf-Client-Objekt erstellen fehlgeschlagen!") + "WCFServiceClientPMDS.getWCFClient: " + ex.ToString());
            }
        }

        public void getAllStammdatenxy(ref QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client serv)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);
                //client.WSFunctionCompleted += (object sender, WSFunctionCompletedEventArgs e) => { };

                //var res = client.getDataSerialized();
                var res = client.getDataSerialized();

                DateTime dNow = DateTime.Now;
                WcfDTOs.sd.TryAdd(dNow, (WCFServicePMDS.BAL.Main.StammdatenDTO.lastStammdaten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[0]));
                WcfDTOs.ben.TryAdd(dNow, (List<WCFServicePMDS.BAL.Main.BenutzerMainDTO.BenutzerDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[1]));
                WcfDTOs.benTables = (WCFServicePMDS.BAL.Main.BenutzerMainDTO.lastBenutzer)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[2]);
                WcfDTOs.pat.TryAdd(dNow, (List<WCFServicePMDS.BAL.Main.PatientMainDTO.PatientDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[3]));
                WcfDTOs.patTables = (WCFServicePMDS.BAL.Main.PatientMainDTO.lastPatienten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[4]);

                //var rSd = client.getLastStammdaten();

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Stammdaten vom Wcf-Service abholen fehlgeschlagen!") + "WCFServiceClientPMDS.getAllStammdaten: " + ex.ToString());
            }
        }

        public bool genUrlWCFService(ref string urlWCFServiceBack)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tRedist = (from r in db.tblRedist
                               where r.VersionsNr == PMDS.Global.ENV.VersionNr && r.InUse == true 
                               select new
                               {
                                   ID = r.ID,
                                   VersionsNr = r.VersionsNr,
                                   WCFUrl = r.WCFUrl,
                                   ServiceName = r.ServiceName,
                                   PortNr = r.PortNr,
                                   lastActivation = r.lastActivation,
                                   InUse = r.InUse
                               });

                    if (tRedist.Count() == 1)
                    {
                        var rRedist = tRedist.First();
                        
                        urlWCFServiceBack = WCFServiceClient.urlWCFServiceDefault2;
                        urlWCFServiceBack = urlWCFServiceBack.Replace("net.pipe://localhost", rRedist.WCFUrl);
                        return true;
                    }
                    else if(tRedist.Count() == 0)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("WCF-Service für Version '" + PMDS.Global.ENV.VersionNr.ToString() +"' ist nicht installiert!" + "\r\n" +
                                                                                    "Bitte Administrator kontaktieren." + "\r\n" + 
                                                                                    "PMDS wird beendet!");
                        Process currentProcess = Process.GetCurrentProcess();
                        currentProcess.Kill();
                        return false;
                    }
                    else 
                    {
                        throw new Exception("genUrlWCFService: tRedist.Count()>1 for gVersion '" + PMDS.Global.ENV.VersionNr.ToString() + "' not allowed!");
                        //Process currentProcess = Process.GetCurrentProcess();
                        //currentProcess.Kill();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Url für WCF-Service generieren fehlgeschlagen!") + "WCFServiceClientPMDS.genUrlWCFService: " + ex.ToString());
            }
        }

        public static void sendExceptionAsSMTPEMail(string except, string client, string User, string Haus, DateTime At)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client clientWcf = WCFServiceClient.getWCFClient(true);
                clientWcf.sendExceptionAsSMTPEMail(except, client, (Haus.Trim() == "" ? "" : Haus + "::") + User, At);
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Exception per Wcf-Service versenden fehlgeschlagen!") + "WCFServiceClientPMDS.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }






        public ELGALogInDto ELGALogInHCP(Guid IDUser, String OIDGDA, Guid IDKlinik, string NameGDA, string Rolle)
        {
            try
            {
                ELGALogInDto ELGALogInDto1 = new ELGALogInDto();

                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                //Thread.Sleep(5000);
                ELGASessionDTO session = new ELGASessionDTO();
                session.IDUserk__BackingField = IDUser;
                ELGALogInDto1.LogInOK = client.ELGALogInHCP(PMDS.Global.ENV.ELGAUser.Trim(), PMDS.Global.ENV.ELGAPwd.Trim(), NameGDA.Trim(), Rolle.Trim(), IDKlinik, ref session);
                if (session.Errorsk__BackingField != null)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGALogInHCP: Error ELGA-LogIn - " + "\r\n" + "\r\n" + ELGALogInDto1.session.Errorsk__BackingField.Trim());
                }
                ELGALogInDto1.session = session;

                return ELGALogInDto1;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Login ELGA fehlgeschlagen!") + "WCFServiceClientPMDS.ELGALogInHCP: " + ex.ToString());
            }
        }
        public bool ELGALogOut(Guid IDUser, bool lic_ELGA)
        {
            try
            {
                if (lic_ELGA && PMDSClientWrapper.WCFServiceOnOff)
                {
                    ELGABusiness elga = new ELGABusiness();
                    ELGABusiness.BenutzerDTOS1 ben = elga.getELGASettingsForUser(IDUser);
                    if (ben.Elgaactive && !ben.IsGeneric)
                    {
                        QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                        if (ELGABusiness.ELGAStatusbarStatus != null && ELGABusiness.ELGAStatusbarStatus.ELGALogInDto != null)
                        {
                            ELGASessionDTO session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                            client.ELGALogOut(ref session);
                        }
                        //else
                        //{
                        //    ELGASessionDTO session = new ELGASessionDTO();
                        //    session.IDUserk__BackingField = IDUser;
                        //    client.ELGALogOut(ref session);
                        //}
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Logout ELGA fehlgeschlagen!") + "WCFServiceClientPMDS.ELGALogOut: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAQueryPatients(string SozVersNrLocalPatID, ELGABALeTypeQueryPatients ELGABALeTypeQueryPatients, bool checkOneRowMustFound)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = SozVersNrLocalPatID.Trim(), NachNameFirmak__BackingField = "", Vornamek__BackingField = "", 
                                                                    Zipk__BackingField = "", Cityk__BackingField = "", Streetk__BackingField = "", StreetNrk__BackingField = "" };
                ELGAParOutDto parOutDto = client.ELGAQueryPatients(ref parsIn, ELGABALeTypeQueryPatients, checkOneRowMustFound);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAQueryPatients");
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryPatients: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryPatients: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Suche Patienten in ELGA fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAQueryPatients: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAInsertPatient(Guid IDPatientInternWcf, string LocalPatientIDWrite, string authUniversalID, ELGABALeTypeUpdatePatients ELGABALeTypeUpdatePatients)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.IDPatientInternk__BackingField = IDPatientInternWcf;
                parsIn.LocalPatientIDk__BackingField = LocalPatientIDWrite;
                parsIn.authUniversalIDk__BackingField = authUniversalID.Trim();
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = LocalPatientIDWrite.Trim() };
                ELGAParOutDto parOutDto = client.ELGAinsertPatient(ref parsIn, ELGABALeTypeUpdatePatients);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAInsertPatient");
                    throw new Exception("WCFServiceClientPMDS.ELGAInsertPatient: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAInsertPatient: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patient in ELGA einfügen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAInsertPatient: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAUpdatePatient(Guid IDPatientInternWcf, string LocalPatientIDWrite, ELGABALeTypeUpdatePatients ELGABALeTypeUpdatePatients)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.IDPatientInternk__BackingField = IDPatientInternWcf;
                parsIn.LocalPatientIDk__BackingField = LocalPatientIDWrite;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() {SozVersNrLocalPatIDk__BackingField = LocalPatientIDWrite.Trim()};
                ELGAParOutDto parOutDto = client.ELGAUpdatePatient(ref parsIn, ELGABALeTypeUpdatePatients);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAUpdatePatient");
                    throw new Exception("WCFServiceClientPMDS.ELGAUpdatePatient: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAUpdatePatient: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patient in ELGA updaten fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAUpdatePatient: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAAddContactAdmission(string LocalPatientID)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = LocalPatientID.Trim() };
                ELGAParOutDto parOutDto = client.ELGAAddContactAdmission(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAUddContactAdmission");
                    throw new Exception("WCFServiceClientPMDS.ELGAAddContactAdmission: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    if (parOutDto.ContactExistsk__BackingField)
                    {
                        return parOutDto;
                    }
                    else
                    {
                        if (parOutDto.ContactIDk__BackingField != null && parOutDto.ContactIDk__BackingField.Trim() == "")
                        {
                            throw new Exception("WCFServiceClientPMDS.ELGAAddContactAdmission: parOutDto.ContactID='" + parOutDto.ContactIDk__BackingField.ToString() + "' not allowed!");
                        }
                    }
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAAddContactAdmission: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patientenkontakt in ELGA hinzufügen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAAddContactAdmission: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAInvalidateContact(string ContactID)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.ContactIDk__BackingField = ContactID.Trim();
                ELGAParOutDto parOutDto = client.ELGAInvalidateContact(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAInvalidateContact");
                    throw new Exception("WCFServiceClientPMDS.ELGAInvalidateContact: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAInvalidateContact: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patientenkontakt aus ELGA löschen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAInvalidateContact: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAAddContactDischarge(string LocalPatientID)
        {
            try
            {
                //Entlassung
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = LocalPatientID.Trim() };
                ELGAParOutDto parOutDto = client.ELGAAddContactDischarge(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAAddContactDischarge");
                    throw new Exception("WCFServiceClientPMDS.ELGAAddContactDischarge: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAAddContactDischarge: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patientenkontakt in ELGA deaktivieren fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAAddContactDischarge: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAListContacts(string LocalPatientID)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() {  SozVersNrLocalPatIDk__BackingField = LocalPatientID.Trim()};
                ELGAParOutDto parOutDto = client.ELGAListContacts(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAListContacts");
                    throw new Exception("WCFServiceClientPMDS.ELGAListContacts: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAListContacts: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Patientenkontakte aus ELGA abfragen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAListContacts: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAQueryGDAs(cSearchGdaFlds SearchGdaFlds)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;

                parsIn.sObjectDtok__BackingField = new ObjectDTO()
                {
                    SozVersNrLocalPatIDk__BackingField = "",
                    NachNameFirmak__BackingField = SearchGdaFlds.NachnameFirma.Trim(),
                    Vornamek__BackingField = SearchGdaFlds.Vorname.Trim(),
                    Zipk__BackingField = SearchGdaFlds.PLZ.Trim(),
                    Cityk__BackingField = SearchGdaFlds.Ort.Trim(),
                    Streetk__BackingField = SearchGdaFlds.Strasse.Trim(),
                    StreetNrk__BackingField = SearchGdaFlds.StrasseNr.Trim()
                };

                ELGAParOutDto parOutDto = client.ELGAQueryGDAs(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAQueryGDAs");
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryGDAs: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryGDAs: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Suche GDA in ELGA fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAQueryGDAs: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAQueryDocuments(string ELGAPatientLocalID, Nullable<DateTime> dCreatedFrom, Nullable<DateTime> dCreatedTo, bool OnlyOneDoc, string UniqueId)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDtok__BackingField = new DocumentSearchDto() {  CreatedFromk__BackingField = dCreatedFrom, CreatedTok__BackingField = dCreatedTo};

                ELGAParOutDto parOutDto = client.ELGAQueryDocuments(ref parsIn, OnlyOneDoc, UniqueId);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryDocuments: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errorsk__BackingField.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryDocuments: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Suche Dokumente in ELGA fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAQueryDocuments: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGARetrieveDocument(string ELGAPatientLocalID, string UniqueID)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDtok__BackingField = new DocumentSearchDto() { UniqueIDk__BackingField = UniqueID.Trim() };

                ELGAParOutDto parOutDto = client.ELGARetrieveDocument(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGARetrieveDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errorsk__BackingField.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGARetrieveDocument: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Dokumentinhalt aus ELGA abholen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGARetrieveDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAAddDocument(string ELGAPatientLocalID, string KlinikName, string KlinikOrganisationOID, string Author, string DocumentName, Byte[] bDocu, string Person, string Description,
                                                string IDCA, string ClinicalDocumentSetID)
        {
            try
            {
                //IDCA = ID aus PMDS-DB, eigenen IDDocument     ClinicalDocumentSetID = Kommt aus DCA-Dokdument
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = ELGAPatientLocalID.Trim() };
                parsIn.DocumentAddk__BackingField = new DocumentAddDto()
                {
                    KlinikNamek__BackingField = KlinikName.Trim(),
                    KlinikOrganisationIDk__BackingField = KlinikOrganisationOID.Trim(),
                    Authork__BackingField = Author.Trim(),
                    Documentnamek__BackingField  = DocumentName.Trim(),
                    bDocumentk__BackingField = bDocu,
                    Personk__BackingField = Person.Trim(),
                    Descriptionk__BackingField = Description.Trim(),
                    IDCDAk__BackingField = IDCA.Trim(),
                    ClinicalDocumentSetIDk__BackingField = ClinicalDocumentSetID.Trim()
                };

                ELGAParOutDto parOutDto = client.ELGAAddDocument(ref parsIn);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAAddDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errorsk__BackingField.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAAddDocument: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Dokument in ELGA ablegen fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAAddDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto ElgaDeprecateDocument(string ELGAPatientLocalID, string DocuUniqueId, string KlinikName, string KlinikOrganisationOID)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.sessionk__BackingField = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDtok__BackingField = new ObjectDTO() { SozVersNrLocalPatIDk__BackingField = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDtok__BackingField = new DocumentSearchDto()
                {
                    UniqueIDk__BackingField = DocuUniqueId, Documentnamek__BackingField = "",  Authork__BackingField = "", CreatedFromk__BackingField = null, CreatedTok__BackingField = null,
                    DocumentStatusk__BackingField = ""
                };
                parsIn.DocumentAddk__BackingField = new DocumentAddDto()
                {
                    KlinikNamek__BackingField = KlinikName.Trim(),
                    KlinikOrganisationIDk__BackingField = KlinikOrganisationOID.Trim()
                };

                ELGAParOutDto parOutDto = client.ElgaDeprecateDocument(ref parsIn, DocuUniqueId);

                if (parOutDto.bErrorsFoundk__BackingField)
                {
                    throw new Exception("WCFServiceClientPMDS.ElgaDeprecateDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errorsk__BackingField.Trim());
                }

                if (parOutDto.bOKk__BackingField)
                {
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ElgaDeprecateDocument: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Dokument in ELGA stornieren fehlgeschlagen!") + "WCFServiceClientPMDS.ElgaDeprecateDocument: " + ex.ToString());
            }
        }
        public genCDARes genCDA2(CDAeTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
                                    Guid IDPatient, Guid IDAufenthalt, string Documentname, Nullable<Guid> IDDokumenteneintrag)
        {
            genCDARes res = new genCDARes();
            try
            {
                string xml = "";
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                //Thread.Sleep(5000);
                CDACDAIN vars = new CDACDAIN()
                {
                    IDDocument = IDDocument,
                    IDSet = IDSet,
                    VersionsNr = VersionsNr,
                    IDAufenthalt = IDAufenthalt,
                    IDBenutzer = PMDS.Global.ENV.USERID,
                    IDEinrichtungEmpfänger = IDEinrichtungEmpfänger,
                    IDBenutzerVidierung = PMDS.Global.ENV.USERID,
                    TypeCDA = CDAeTypeCDA,
                    Documentname = Documentname.Trim(),
                    Stylesheet = Stylesheet.Trim(),
                    IDClient = WCFServiceClient.IDClient,
                    IDDokumenteneintrag = IDDokumenteneintrag
                };

                CDACDABack b = client.genCDA(vars);

                xml = (string)WCFServicePMDS.Repository.serialize.BinaryDeserialize(b.docu);
                //xml = System.Text.UTF8Encoding.UTF8.GetString(bXml);
                res.xml = xml;
                res.bXml = b.docu;
                res.bOK = true;

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("CDA-Dokument generieren fehlgeschlagen!") + "WCFServiceClientPMDS.genCDA2" + ex.ToString());
            }
        }

        public string getELGAErrors(ELGAParOutDto parOutDto, string functionName)
        {
            try
            {
                string sElgaErrors = "";
                foreach (ELGAErrorDTO rError in parOutDto.lstErrorsk__BackingField)
                {
                    sElgaErrors += "errTxt: " + rError.errTxtk__BackingField + ", Code: " + rError.codek__BackingField + ", Location: " + rError.locationk__BackingField + ", TypeCode: " +
                                        rError.typeCodek__BackingField + ", ClassCode: " + rError.classCodek__BackingField + ", MoodCode" + rError.moodCodek__BackingField + ", queryResponseCode: " +
                                        rError.queryResponseCodek__BackingField + "" +
                                        "\r\n" + "\r\n";
                }

                throw new Exception("WCFServiceClientPMDS." + functionName.Trim() + ": ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.getELGAErrors: " + ex.ToString());
            }
        }

        public void stopCheckWCFServiceLocal(bool onlyCheckIsRunning)
        {
            try
            {
                System.Collections.Generic.List<Process> lstWCFSServiceRunning = new List<Process>();

                bool WCFServiceIsRunningTmp = false;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.Trim().ToLower().Equals(@PMDS.Global.ENV.WCFHostManager.Trim().Trim().ToLower()))
                    {
                        WCFServiceIsRunningTmp = true;
                        lstWCFSServiceRunning.Add(process);
                    }
                }

                int iPMDSRunning = this.checkPMDSRunning();
                if (onlyCheckIsRunning)
                {
                    try
                    {
                        this.checkWCFServiceIsRunning();
                        return;
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
                else
                {
                    try
                    {
                        if (!PMDS.Global.ENV.WCFServiceDebugMode)
                        {
                            this.StopLocalWCFService();
                        }
                        return;
                    }
                    catch (Exception ex)
                    {
                        //System.Windows.Forms.MessageBox.Show(ex.ToString());
                        return;
                    }


                    //if (!onlyCheckIsRunning && iPMDSRunning <= 1 && lstWCFSServiceRunning.Count > 0)
                    //{
                    //    try
                    //    {
                    //        this.StopLocalWCFService();
                    //        return;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        return;
                    //    }
                    //    foreach (Process process in lstWCFSServiceRunning)
                    //    {
                    //        process.Kill();
                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Lokales WCF-Service beenden fehlgeschlagen!") + "WCFServiceClientPMDS.stopCheckWCFServiceLocal: " + ex.ToString());
            }
        }
        public int checkPMDSRunning()
        {
            try
            {
                int iPMDSRunning = 0;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.Trim().ToLower().Equals(("PMDS.Main").Trim().Trim().ToLower()))
                    {
                        iPMDSRunning += 1;
                    }
                }

                return iPMDSRunning;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.checkPMDSRunning: " + ex.ToString());
            }
        }
        public void StopLocalWCFService()
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);
                client.StopWCFService();

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.StopLocalWCFService" + ex.ToString());
            }
        }
        public bool checkWCFServiceIsRunning()
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);
                bool bIsRunning = client.CheckWCFServiceIsRunning();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.checkWCFServiceIsRunning" + ex.ToString());
            }
        }






        public MessagesDto messagesSent(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);

                MessagesDto tM = client.messagesSent(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
                return tM;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Nachrichten senden fehlgeschlagen!") + "WCFServiceClientPMDS.messagesSent" + ex.ToString());
            }
        }
        public MessagesDto messagesUnreadedUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);

                MessagesDto tM = client.messagesUnreadedUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
                return tM;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Ungelesene Nachrichten Benutzer lesen fehlgeschlagen!") + "WCFServiceClientPMDS.messagesUnreadedUsr" + ex.ToString());
            }
        }
        public MessagesDto messagesAllUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);

                MessagesDto tM = client.messagesAllUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
                return tM;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Alle Nachrichten Benutzer lesen fehlgeschlagen!") + "WCFServiceClientPMDS.messagesAllUsr" + ex.ToString());
            }
        }

        public MessagesDTO1 addMessage(Guid IDUser, string Username, string Title, string Message, string ClientsMessage, string TypeMessage, Guid[] lUsersTo)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(true);
                MessagesDTO1 m = client.addMessage(IDUser, Username, Title, Message, ClientsMessage, TypeMessage, lUsersTo, WCFServiceClient.IDClient);
                return m;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Nachrichten hinzufügen!") + "WCFServiceClientPMDS.addMessage" + ex.ToString());
            }
        }



































        public genCDARes genCDA_old(CDAeTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
                        Guid IDPatient, Guid IDAufenthalt, string Documentname)
        {
            var res = this.TgenCDA_old(CDAeTypeCDA, IDEinrichtungEmpfänger, IDDocument, IDSet, VersionsNr, Stylesheet, IDPatient, IDAufenthalt, Documentname);
            return res.Result;

            //Task t = genCDA3(CDAeTypeCDA, IDEinrichtungEmpfänger);
            //t.Start();
        }
        private async Task<genCDARes> TgenCDA_old(CDAeTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
                                                Guid IDPatient, Guid IDAufenthalt, string Documentname)
        {
            genCDARes res = new genCDARes();
            try
            {
                string xml = "";
                await Task.Run(() =>
                {
                    try
                    {
                        QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient(localWCFElgaYN);
                        //Thread.Sleep(5000);
                        CDACDAIN vars = new CDACDAIN()
                        {
                            IDDocument = IDDocument,
                            IDSet = IDSet,
                            VersionsNr = VersionsNr,
                            IDAufenthalt = IDAufenthalt,
                            IDBenutzer = PMDS.Global.ENV.USERID,
                            IDEinrichtungEmpfänger = IDEinrichtungEmpfänger,
                            IDBenutzerVidierung = PMDS.Global.ENV.USERID,
                            TypeCDA = CDAeTypeCDA,
                            Documentname = Documentname.Trim(),
                            Stylesheet = Stylesheet.Trim(),
                            IDClient = WCFServiceClient.IDClient
                        };

                        CDACDABack b = client.genCDA(vars);

                        xml = (string)WCFServicePMDS.Repository.serialize.BinaryDeserialize(b.docu);
                        //xml = System.Text.UTF8Encoding.UTF8.GetString(bXml);
                        res.xml = xml;
                        res.bXml = b.docu;
                        res.bOK = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("TgenCDA: Task => " + ex.ToString());
                    }

                }).ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        PMDS.Global.ENV.HandleException(t.Exception, "WCFException - TgenCDA");
                        //throw new Exception(t.ToString());
                    }
                    if (t.IsCompleted) { }
                });

                return res;
            }
            catch (Exception ex)
            {
                Exception exTmp = new Exception("WCFServiceClientPMDS.TgenCDA - " + ex.ToString());
                PMDS.Global.ENV.HandleException(exTmp, "WCFException");
                return res;
            }
        }
        public async Task genCDA_old(CDAeTypeCDA CDAeTypeCDA, Guid IDEinrichtungEmpfänger)
        {
            try
            {
                //string xml = "";
                //async Task<string> genCDA2(int number)
                //{
                //    QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client("BasicHttpBinding_IService1", ENV.UrlWCFServicePMDS.Trim());
                //    //xml = Service1Client1.genCDA(ENV.IDAUFENTHALT, ENV.USERID, IDEinrichtungEmpfänger, ENV.USERID, CDAeTypeCDA);
                //    bool isReady = true;
                //    Task.Delay(49000);
                //    return "";
                //}


                //frmCDAViewer frm = new frmCDAViewer();
                //frm.initControl(xml);
                //frm.ShowDialog();

                string xml = "";
                var t = new Task(() =>
                {
                    //QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client("BasicHttpBinding_IService1", ENV.UrlWCFServicePMDS.Trim());
                    //xml = Service1Client1.genCDA(ENV.IDAUFENTHALT, ENV.USERID, IDEinrichtungEmpfänger, ENV.USERID, CDAeTypeCDA);
                    Thread.Sleep(5000);
                    bool isReady = true;
                });
                t.Start();
                Exceptions.checkFault(new List<Task>() { t });
                t.Wait();

                //frmCDAViewer frm = new frmCDAViewer();
                //frm.initControl(xml);
                //frm.ShowDialog();

                //var t2 = t.ContinueWith((i) => 
                //{
                //    Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => myUIProperty = "Update UI!"));


                //    frmCDAViewer frm = new frmCDAViewer();
                //    frm.initControl(xml);
                //    frm.ShowDialog();
                //});



                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //{
                //    db.Configuration.LazyLoadingEnabled = false;
                //    var tVO = (from v in db.Aufenthalt
                //               join vm in db.VO_MedizinischeDaten on v.ID equals vm.IDVerordnung
                //               join m in db.Medikament on v.IDMedikament equals m.ID
                //               where vm.IDMedizinischeDaten == IDMedDaten
                //               select new
                //               {
                //                   ID = v.ID,
                //                   IDMedikament = v.IDMedikament,
                //                   Medikament = m.Bezeichnung,
                //                   DatumVerordnetAb = v.DatumVerordnetAb,
                //                   DatumVerordnetBis = v.DatumVerordnetBis,
                //                   Einheit = v.Einheit,
                //               });

                //    db.Configuration.LazyLoadingEnabled = true;
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.genCDA: " + ex.ToString());
            }
        }


    }

}

