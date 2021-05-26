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
using WCFServicePMDS;
using WCFServicePMDS.BAL.DTO;
using WCFServicePMDS.BAL2.ELGABAL;

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
            public bool bSearchEinrichtung { get; set; }
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
                //System.Windows.Forms.MessageBox.Show("0.0.1");

                if (!PMDSClientWrapper.WCFServiceOnOff)
                {
                    return;
                }
                //System.Windows.Forms.MessageBox.Show("0.0.2");

                DateTime dNow = DateTime.Now;
                WCFServiceClient WCFServiceClientPMDS1 = new WCFServiceClient();
                cParsWCF ParsWCF = new cParsWCF();
                ParsWCF.MachineName = System.Environment.MachineName.Trim();
                ParsWCF.LoginInNameFrei = PMDSClientWrapper.LoginInNameFrei;
                ParsWCF.gVersionNr = PMDS.Global.ENV.VersionNr;
                //System.Windows.Forms.MessageBox.Show("0.0.3");
                Thread threadSendExcept = new Thread(WCFServiceClientPMDS1.thread_initWCFService);
                threadSendExcept.IsBackground = true;
                //System.Windows.Forms.MessageBox.Show("0.0.4");
                threadSendExcept.Start(ParsWCF);

                //System.Windows.Forms.MessageBox.Show("0.0.6");

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
                cParsWCF ParsWCF = (cParsWCF)pars;               
                string sConfigPathTmp = System.IO.Path.GetDirectoryName(PMDS.Global.ENV.sConfigFile.Trim());

                WCFServiceClient.IDClient = System.Guid.NewGuid();
                ENVClientDto ENVDto = new ENVClientDto() { ConfigPathPMDS = sConfigPathTmp, ConfigFilePMDS = PMDS.Global.ENV.sConfigFile, IDClient = WCFServiceClient.IDClient, Srv = RBU.DataBase.Srv, 
                                                            Usr = RBU.DataBase.m_sUser, Pwd = RBU.DataBase.m_sPassword, Db = RBU.DataBase.m_Database, trusted = RBU.DataBase.IsTrusted,
                                                            LogPathPMDS = PMDS.Global.ENV.LOGPATH, ReportPathPMDS = PMDS.Global.ENV.ReportPath };

                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                bool bCheckOK = s1.initService(ParsWCF.MachineName, ParsWCF.LoginInNameFrei, false, ParsWCF.gVersionNr, ENVDto, Process.GetCurrentProcess().Id);
                WCFServiceClient.IsInitialized = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex, "Exception", true, true, QS2.Desktop.ControlManagment.ControlManagment.getRes("Wcf-Service per Thread initialisieren fehlgeschlagen!"), false);
            }
        }

        public void getAllStammdatenxy()
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                var res = s1.getDataSerialized();

                DateTime dNow = DateTime.Now;
                WcfDTOs.sd.TryAdd(dNow, (WCFServicePMDS.BAL.Main.StammdatenDTO.lastStammdaten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[0]));
                WcfDTOs.ben.TryAdd(dNow, (List<WCFServicePMDS.BAL.Main.BenutzerMainDTO.BenutzerDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[1]));
                WcfDTOs.benTables = (WCFServicePMDS.BAL.Main.BenutzerMainDTO.lastBenutzer)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[2]);
                WcfDTOs.pat.TryAdd(dNow, (List<WCFServicePMDS.BAL.Main.PatientMainDTO.PatientDt>)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[3]));
                WcfDTOs.patTables = (WCFServicePMDS.BAL.Main.PatientMainDTO.lastPatienten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(res[4]);
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                s1.sendExceptionAsSMTPEMail(except, client, (String.IsNullOrWhiteSpace(Haus) ? "" : Haus + "::") + User, At);
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

                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                //Thread.Sleep(5000);
                ELGASessionDTO session = new ELGASessionDTO();
                session.IDUser = IDUser;
                ELGALogInDto1.LogInOK = s1.ELGALogInHCP(PMDS.Global.ENV.ELGAUser.Trim(), PMDS.Global.ENV.ELGAPwd.Trim(), NameGDA.Trim(), Rolle.Trim(), IDKlinik, ref session, PMDS.Global.ENV.ELGAUrl);

                //direkt ohne WCFService-Schicht
                //ELGASessionDTO session = new ELGASessionDTO();
                //WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                //session.IDUser = IDUser;
                //ELGALogInDto1.LogInOK = elga.ELGALogInHCP(PMDS.Global.ENV.ELGAUser.Trim(), PMDS.Global.ENV.ELGAPwd.Trim(), NameGDA.Trim(), Rolle.Trim(), IDKlinik, ref session, PMDS.Global.ENV.ELGAUrl);

                //if (session.Errors != null)
                //{
                //    throw new Exception("WCFServiceClientPMDS.ELGALogInHCP: Error ELGA-LogIn - " + "\r\n" + "\r\n" + ELGALogInDto1.session.Errors.Trim());
                //}
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
                    ELGABusiness elgaBusiness = new ELGABusiness();
                    ELGABusiness.BenutzerDTOS1 ben = elgaBusiness.getELGASettingsForUser(IDUser);
                    if (ben.Elgaactive && !ben.IsGeneric)
                    {
                        WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                        if (ELGABusiness.ELGAStatusbarStatus != null && ELGABusiness.ELGAStatusbarStatus.ELGALogInDto != null)
                        {
                            ELGASessionDTO session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                            session.IDUser = IDUser;
                            s1.ELGALogOut(ref session, PMDS.Global.ENV.ELGAUrl);
                        }

                        //Direkt ohne WCFService-Schicht
                        //if (ELGABusiness.ELGAStatusbarStatus != null && ELGABusiness.ELGAStatusbarStatus.ELGALogInDto != null)
                        //{
                        //    ELGASessionDTO session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                        //    WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                        //    session.IDUser = IDUser;
                        //    elga.ELGALogOut(ref session, PMDS.Global.ENV.ELGAUrl);
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

        public ELGAParOutDto ELGAQueryPatients(string SozVersNrLocalPatID, WCFServicePMDS.ELGABAL.eTypeQueryPatients ELGABALeTypeQueryPatients, bool checkOneRowMustFound)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = SozVersNrLocalPatID.Trim(), NachNameFirma = "", Vorname = "", 
                                                                    Zip = "", City = "", Street = "", StreetNr = "" };
                ELGAParOutDto parOutDto = s1.ELGAQueryPatients(ref parsIn, ELGABALeTypeQueryPatients, checkOneRowMustFound, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAQueryPatients");
                    throw new Exception("WCFServiceClientPMDS.ELGAQueryPatients: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOK)
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

        public ELGAParOutDto ELGAInsertPatient(Guid IDPatientInternWcf, string LocalPatientIDWrite, string authUniversalID, WCFServicePMDS.ELGABAL.eTypeUpdatePatients ELGABALeTypeUpdatePatients)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.IDPatientIntern = IDPatientInternWcf;
                parsIn.LocalPatientID = LocalPatientIDWrite;
                parsIn.authUniversalID = authUniversalID.Trim();
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = LocalPatientIDWrite.Trim() };
                ELGAParOutDto parOutDto = s1.ELGAinsertPatient(ref parsIn, ELGABALeTypeUpdatePatients, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAInsertPatient");
                    throw new Exception("WCFServiceClientPMDS.ELGAInsertPatient: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOK)
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
        public ELGAParOutDto ELGAUpdatePatient(Guid IDPatientInternWcf, string LocalPatientIDWrite, WCFServicePMDS.ELGABAL.eTypeUpdatePatients ELGABALeTypeUpdatePatients)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.IDPatientIntern = IDPatientInternWcf;
                parsIn.LocalPatientID = LocalPatientIDWrite;
                parsIn.sObjectDto = new ObjectDTO() {SozVersNrLocalPatID = LocalPatientIDWrite.Trim()};
                ELGAParOutDto parOutDto = s1.ELGAUpdatePatient(ref parsIn, ELGABALeTypeUpdatePatients, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAUpdatePatient");
                    throw new Exception("WCFServiceClientPMDS.ELGAUpdatePatient: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = LocalPatientID.Trim() };
                ELGAParOutDto parOutDto = s1.ELGAAddContactAdmission(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAUddContactAdmission");
                    throw new Exception("WCFServiceClientPMDS.ELGAAddContactAdmission: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }

                if (parOutDto.bOK)
                {
                    if (parOutDto.ContactExists)
                    {
                        return parOutDto;
                    }
                    else
                    {
                        if (parOutDto.ContactID != null && parOutDto.ContactID.Trim() == "")
                        {
                            throw new Exception("WCFServiceClientPMDS.ELGAAddContactAdmission: parOutDto.ContactID='" + parOutDto.ContactID.ToString() + "' not allowed!");
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

        public ELGAParOutDto ELGAInvalidateContact(string LocalPatientID, string ELGAContactID)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.ContactID = ELGAContactID;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = LocalPatientID };
                ELGAParOutDto parOutDto = new ELGAParOutDto();

                /*
                //Behandlungs-ID (Contact-ID) holen
                ELGAParOutDto parOutContacts = this.ELGAListContacts(LocalPatientID.Trim());

                bool bContactFound = false;                
                foreach(ELGAContactsDto contactsDto in parOutContacts.lContacts)
                {
                    if (PMDS.Global.generic.sEquals(contactsDto.status,"aktiv") &&                      //Status überprüfen?
                        PMDS.Global.generic.sEquals(contactsDto.GdaID, parsIn.authUniversalID))         //authUniversalID oder ELGA_OID?
                    {
                        parsIn.ContactID = contactsDto.TreatmentID;
                        bContactFound = true;
                        break;
                    }
                }

                if (!bContactFound)
                {
                    parOutDto.bErrorsFound = true;
                    ELGAErrorDTO rError = new ELGAErrorDTO();
                    rError.errTxt = "Keine passende Kontaktbestätigung gefunden.";
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAInvalidateContact");
                    return parOutDto;
                }
                */


                parOutDto = s1.ELGAInvalidateContact(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    parOutDto.bOK = false;
                    parOutDto.bErrorsFound = true;
                    parOutDto.Errors = this.getELGAErrors(parOutDto, "ELGAInvalidateContact");
                    return parOutDto;
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID= LocalPatientID.Trim() };
                ELGAParOutDto parOutDto = s1.ELGAAddContactDischarge(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAAddContactDischarge");
                    return parOutDto;
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session= ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() {  SozVersNrLocalPatID = LocalPatientID.Trim()};
                ELGAParOutDto parOutDto = s1.ELGAListContacts(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAListContacts");
                    return parOutDto;
                    //throw new Exception("WCFServiceClientPMDS.ELGAListContacts: ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
                }
                else if (parOutDto.bOK)
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

        public ELGAParOutDto ELGADelegateContact(string LocalPatientID, string OrganisationIdToDelegateTo)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.LocalPatientID = LocalPatientID.Trim();
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = LocalPatientID.Trim() };
                parsIn.sOrganistaionIdToDelegateTo = OrganisationIdToDelegateTo;
                parsIn.authUniversalID = PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik);
                parsIn.ELGA_OrganizationOID = PMDSBusiness.getKlinikELGA_OrganizationOID(PMDS.Global.ENV.IDKlinik);
                ELGAParOutDto parOutDto = s1.ELGADelegateContact(ref parsIn, PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGADelegateContact");
                    return parOutDto;
                }
                else if (parOutDto.bOK)
                {

                    if (parOutDto.ContactID != null && String.IsNullOrWhiteSpace(parOutDto.ContactID))
                    {
                        throw new Exception("WCFServiceClientPMDS.ELGADelegateContact: parOutDto.ContactID='" + parOutDto.ContactID.ToString() + "' not allowed!");
                    }
                    return parOutDto;
                }
                else
                {
                    throw new Exception("WCFServiceClientPMDS.ELGADelegateContact: parOutDto.bOK is not true - Error ELGA-Functions or WCF-Service!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Kontaktdelegation fehlgeschlagen!") + "WCFServiceClientPMDS.ELGAAddContactAdmission: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAQueryGDAs(cSearchGdaFlds SearchGdaFlds)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;

                parsIn.sObjectDto = new ObjectDTO()
                {
                    SozVersNrLocalPatID = "",
                    NachNameFirma = SearchGdaFlds.NachnameFirma.Trim(),
                    Vorname = SearchGdaFlds.Vorname.Trim(),
                    Zip = SearchGdaFlds.PLZ.Trim(),
                    City = SearchGdaFlds.Ort.Trim(),
                    Street = SearchGdaFlds.Strasse.Trim(),
                    StreetNr = SearchGdaFlds.StrasseNr.Trim()
                };

                ELGAParOutDto parOutDto = s1.ELGAQueryGDAs(ref parsIn, SearchGdaFlds.bSearchEinrichtung, PMDS.Global.ENV.ELGAUrlGDAIndex);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAQueryGDAs");
                    return parOutDto;
                }
                else if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDto = new DocumentSearchDto() {  CreatedFrom = dCreatedFrom, CreatedTo = dCreatedTo};

                ELGAParOutDto parOutDto = s1.ELGAQueryDocuments(ref parsIn, OnlyOneDoc, UniqueId, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    string sElgaErrors = this.getELGAErrors(parOutDto, "ELGAQueryDocuments");
                    return parOutDto;
                    //throw new Exception("WCFServiceClientPMDS.ELGAQueryDocuments: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errors.Trim());
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDto = new DocumentSearchDto() { UniqueID = UniqueID.Trim() };

                ELGAParOutDto parOutDto = s1.ELGARetrieveDocument(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGARetrieveDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errors.Trim());
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = ELGAPatientLocalID.Trim() };
                parsIn.DocumentAdd = new DocumentAddDto()
                {
                    KlinikName = KlinikName.Trim(),
                    KlinikOrganisationID = KlinikOrganisationOID.Trim(),
                    Author = Author.Trim(),
                    Documentname  = DocumentName.Trim(),
                    bDocument = bDocu,
                    Person = Person.Trim(),
                    Description = Description.Trim(),
                    IDCDA = IDCA.Trim(),
                    ClinicalDocumentSetID = ClinicalDocumentSetID.Trim()
                };

                ELGAParOutDto parOutDto = s1.ELGAAddDocument(ref parsIn, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    throw new Exception("WCFServiceClientPMDS.ELGAAddDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errors.Trim());
                }

                if (parOutDto.bOK)
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                ELGAParInDto parsIn = new ELGAParInDto();
                parsIn.session = ELGABusiness.ELGAStatusbarStatus.ELGALogInDto.session;
                parsIn.sObjectDto = new ObjectDTO() { SozVersNrLocalPatID = ELGAPatientLocalID.Trim() };
                parsIn.sDocumentsDto = new DocumentSearchDto()
                {
                    UniqueID = DocuUniqueId, Documentname = "",  Author = "", CreatedFrom = null, CreatedTo = null,
                    DocumentStatus = ""
                };
                parsIn.DocumentAdd = new DocumentAddDto()
                {
                    KlinikName = KlinikName.Trim(),
                    KlinikOrganisationID = KlinikOrganisationOID.Trim()
                };

                ELGAParOutDto parOutDto = s1.ElgaDeprecateDocument(ref parsIn, DocuUniqueId, PMDSBusiness.getKlinikAuthUniversalID(PMDS.Global.ENV.IDKlinik), PMDS.Global.ENV.ELGAUrl);

                if (parOutDto.bErrorsFound)
                {
                    throw new Exception("WCFServiceClientPMDS.ElgaDeprecateDocument: ELGA-Error - " + "\r\n" + "\r\n" + parOutDto.Errors.Trim());
                }

                if (parOutDto.bOK)
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
        public genCDARes genCDA2(WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
                                    Guid IDPatient, Guid IDAufenthalt, string Documentname, Nullable<Guid> IDDokumenteneintrag)
        {
            genCDARes res = new genCDARes();
            try
            {
                string xml = "";
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                //Thread.Sleep(5000);
                WCFServicePMDS.CDABAL.CDA.CDAIN vars = new WCFServicePMDS.CDABAL.CDA.CDAIN()
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

                WCFServicePMDS.CDABAL.CDA.CDABack b = s1.genCDA(vars);

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
                foreach (ELGAErrorDTO rError in parOutDto.lstErrors)
                {
                    sElgaErrors += "errTxt: " + rError.errTxt + ", Code: " + rError.code + ", Location: " + rError.location + ", TypeCode: " +
                                        rError.typeCode + ", ClassCode: " + rError.classCode + ", MoodCode" + rError.moodCode + ", queryResponseCode: " +
                                        rError.queryResponseCode + "" +
                                        "\r\n" + "\r\n";
                }
                return sElgaErrors;
                //throw new Exception("WCFServiceClientPMDS." + functionName.Trim() + ": ELGA-Error - " + "\r\n" + "\r\n" + sElgaErrors.Trim());
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
                //WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                //s1.StopWCFService();

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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                bool bIsRunning = s1.CheckWCFServiceIsRunning();
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                MessagesDto tM = s1.messagesSent(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                MessagesDto tM = s1.messagesUnreadedUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
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
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();

                MessagesDto tM = s1.messagesAllUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, WCFServiceClient.IDClient);
                return tM;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Alle Nachrichten Benutzer lesen fehlgeschlagen!") + "WCFServiceClientPMDS.messagesAllUsr" + ex.ToString());
            }
        }

        public WCFServicePMDS.DAL.DTO.MessagesDTO addMessage(Guid IDUser, string Username, string Title, string Message, string ClientsMessage, string TypeMessage, System.Collections.Generic.List<Guid> lUsersTo)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                WCFServicePMDS.DAL.DTO.MessagesDTO m = s1.addMessage(IDUser, Username, Title, Message, ClientsMessage, TypeMessage, lUsersTo, WCFServiceClient.IDClient);
                return m;
            }
            catch (Exception ex)
            {
                throw new Exception(PMDS.Global.ENV.getTitleExcept("Nachrichten hinzufügen!") + "WCFServiceClientPMDS.addMessage" + ex.ToString());
            }
        }



































        public genCDARes genCDA_old(WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
                        Guid IDPatient, Guid IDAufenthalt, string Documentname)
        {
            var res = this.TgenCDA_old(CDAeTypeCDA, IDEinrichtungEmpfänger, IDDocument, IDSet, VersionsNr, Stylesheet, IDPatient, IDAufenthalt, Documentname);
            return res.Result;

            //Task t = genCDA3(CDAeTypeCDA, IDEinrichtungEmpfänger);
            //t.Start();
        }
        private async Task<genCDARes> TgenCDA_old(WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA, Nullable<Guid> IDEinrichtungEmpfänger, Guid IDDocument, string IDSet, int VersionsNr, string Stylesheet,
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
                        WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                        //Thread.Sleep(5000);
                        WCFServicePMDS.CDABAL.CDA.CDAIN vars = new WCFServicePMDS.CDABAL.CDA.CDAIN()
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

                        WCFServicePMDS.CDABAL.CDA.CDABack b = s1.genCDA(vars);

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
        public async Task genCDA_old(WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA, Guid IDEinrichtungEmpfänger)
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

