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

        public static string urlWCFServiceDefault = "http://localhost:8733/Design_Time_Addresses/WCFServicePMDS/Service1/";

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




        



        public static void init()
        {
            try
            {
                if (!PMDSClientWrapper.WCFServiceOnOff)
                {
                    return;
                }

                string strCmdText;
                strCmdText = "";
                
                string sWCFServiceName = "";
                if (PMDS.Global.ENV.WCFServicePMDSAsConsole)
                {
                    //sWCFServiceName = @PMDS.Global.ENV.WCFServicePMDSDebugPath.Trim() + @"\WCFServicePMDS.exe";
                    //System.Diagnostics.Process.Start(sWCFServiceName, strCmdText);
                }
                else
                {

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
                throw new Exception("WCFServiceClientPMDS.init: " + ex.ToString());
            }
        }

        public void thread_initWCFService(object pars)
        {
            try
            {
               if (PMDSClientWrapper.UrlWCFServicePMDS.Trim() == "")
                {
                    string urlWCFServiceBack = "";
                    bool bUrlFound = this.genUrlWCFService(ref urlWCFServiceBack);
                    PMDSClientWrapper.UrlWCFServicePMDS = urlWCFServiceBack.Trim();
                }
                
                cParsWCF ParsWCF = (cParsWCF)pars;
                //QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client("BasicHttpBinding_Service1", ENV.UrlWCFServicePMDS.Trim());
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = WCFServiceClient.getWCFClient();
                bool bCheckOK = Service1Client1.initService(ParsWCF.MachineName, ParsWCF.LoginInNameFrei, false, ParsWCF.gVersionNr, null);
                this.getAllStammdaten(ref Service1Client1);
                WCFServiceClient.IsInitialized = true;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex, "Exception", true);
            }
        }
        public static QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client getWCFClient()
        {
            try
            {
                TimeSpan t10 = new TimeSpan(10, 0, 0);
                TimeSpan t24 = new TimeSpan(23, 59, 59);

                if (PMDSClientWrapper.UrlWCFServicePMDS.Trim().ToLower().StartsWith(("http://").Trim().ToLower()))
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
                    var endpoint = new EndpointAddress(PMDSClientWrapper.UrlWCFServicePMDS.Trim());
                    QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client(binding, endpoint);
                    //client.WSFunctionCompleted += (object sender, WSFunctionCompletedEventArgs e) => { };
                    return client;

                    //QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client Service1Client1 = new QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client("BasicHttpBinding_Service1", ENV.UrlWCFServicePMDS.Trim());
                }
                else if (PMDSClientWrapper.UrlWCFServicePMDS.Trim().ToLower().StartsWith(("net.tcp://").Trim().ToLower()))
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
                    var endpoint = new EndpointAddress(PMDSClientWrapper.UrlWCFServicePMDS.Trim());
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
                throw new Exception("WCFServiceClientPMDS.getWCFClient: " + ex.ToString());
            }
        }

        public void getAllStammdaten(ref QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client serv)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient();
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
                throw new Exception("WCFServiceClientPMDS.getAllStammdaten: " + ex.ToString());
            }
        }

        public bool ELGALogOut(Guid IDUser, bool lic_ELGA)
        {
            try
            {
                if (lic_ELGA)
                {
                    ELGABusiness elga = new ELGABusiness();
                    ELGABusiness.BenutzerDTOS1 ben = elga.getELGASettingsForUser(IDUser);
                    if (ben.Elgaactive && !ben.IsGeneric)
                    {
                        QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient();
                        ELGASessionDTO session = new ELGASessionDTO();
                        session.IDUserk__BackingField = IDUser;
                        client.ELGALogOut(ref session);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.ELGALogOut: " + ex.ToString());
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
                        
                        urlWCFServiceBack = WCFServiceClient.urlWCFServiceDefault;
                        urlWCFServiceBack = urlWCFServiceBack.Replace("http://localhost:8733", rRedist.WCFUrl);
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
                throw new Exception("WCFServiceClientPMDS.genUrlWCFService: " + ex.ToString());
            }
        }

        public static void sendExceptionAsSMTPEMail(string except, string client, string User, string Haus, DateTime At)
        {
            try
            {
                QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client clientWcf = WCFServiceClient.getWCFClient();
                clientWcf.sendExceptionAsSMTPEMail(except, client, (Haus.Trim() == "" ? "" : Haus + "::") + User, At);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }


        public void genCDA(CDAeTypeCDA CDAeTypeCDA, Guid IDEinrichtungEmpfänger, Guid IDDocument, Guid IDSet, int VersionsNr)
        {
            this.TgenCDA(CDAeTypeCDA, IDEinrichtungEmpfänger, IDDocument, IDSet, VersionsNr);
            //Task t = genCDA3(CDAeTypeCDA, IDEinrichtungEmpfänger);
            //t.Start();
        }

        private async Task TgenCDA(CDAeTypeCDA CDAeTypeCDA, Guid IDEinrichtungEmpfänger, Guid IDDocument, Guid IDSet, int VersionsNr)
        {
            try
            {
                string xml = "";
                await Task.Run(() =>
                {
                    try
                    {
                        QS2.Desktop.ControlManagment.ServiceReference_01.Service1Client client = WCFServiceClient.getWCFClient();
                        //Thread.Sleep(5000);
                        CDACDAIN vars = new CDACDAIN()
                        {
                            IDDocument = IDDocument,
                            IDSet = IDSet,
                            VersionsNr = VersionsNr,
                            IDAufenthalt = PMDSClientWrapper.IDAUFENTHALT,
                            IDBenutzer = PMDSClientWrapper.USERID,
                            IDEinrichtungEmpfänger = IDEinrichtungEmpfänger,
                            IDBenutzerVidierung = PMDSClientWrapper.USERID,
                            TypeCDA = CDAeTypeCDA
                        };
                        CDACDABack b = client.genCDA(vars);
                        xml = (string)WCFServicePMDS.Repository.serialize.BinaryDeserialize(b.docu);
                        //xml = System.Text.UTF8Encoding.UTF8.GetString(bXml);
                        bool isReady = true;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("TgenCDA: Task => " + ex.ToString());
                    }

                }).ContinueWith((t) =>
                {
                    if (t.IsFaulted) throw t.Exception;
                    if (t.IsCompleted) { }
                });

                this.openCDAViewer(xml, CDAeTypeCDA.ToString());
            }
            catch (Exception ex)
            {
                Exception exTmp = new Exception("TgenCDA - " + ex.ToString());
                PMDS.Global.ENV.HandleException(exTmp, "WCFException");
            }
        }
        private void openCDAViewer(string xml, string typeFile)
        {
            frmCDAViewer frm = new frmCDAViewer();
            frm.initControl(xml, typeFile);
            frm.ShowDialog();
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

