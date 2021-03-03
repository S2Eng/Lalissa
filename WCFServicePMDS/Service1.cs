using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServicePMDS.Models.DB;
using WCFServicePMDS;
using WCFServicePMDS.BAL.Main;
using WCFServicePMDS.TestUnits;
using WCFServicePMDS.BAL.Main.Interfaces;
using WCFServicePMDS.DatenExportXMLBAL;
//using WCFServicePMDS.DynReportsBAL;
using WCFServicePMDS.BAL.Interfaces;
using System.Collections.Concurrent;
using static WCFServicePMDS.TestUnits.TestDTO;
using System.Xml.Serialization;
using System.IO;
using WCFServicePMDS.DAL.DTO;
using System.Threading.Tasks;
using WCFServicePMDS.BAL2.ELGABAL;
using static WCFServicePMDS.ELGABAL;
using Elga.core.ServiceReferenceELGA;
using WCFServicePMDS.BAL;


namespace WCFServicePMDS
{


    public class Service1
    {


        public bool initService(string client, string user, bool checkVersion, Guid VersionNrClient, ENVClientDto clientVars, int ClientProcessId)
        {
            try
            {
                if (checkVersion && !VersionNrClient.Equals(WCFServicePMDS.ENV.VersionNr))
                {
                    throw new Exception("WCFServicePMDS.Service1.CheckService: VersionClient<>VersionWCFService!");
                }

                if (client == null) client = Environment.MachineName;
                if (user == null) user = "AutoUser";

                ENV.init2(client, user, clientVars, ClientProcessId);
                //WCFServicePMDS.DAL.dbBase.checkEFCore();
                //loadStammdaten();

                return true;
            }
            catch (AggregateException ex)
            {
                throw new Exception("WCFServicePMDS.Service1.CheckService: " + ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.CheckService: " + ex.ToString());
            }
        }
        public void testRep(Guid IDClient)
        {
            try
            {
                WCFServicePMDS.TestUnits.TestsDevelop.runRepository1(IDClient);
                WCFServicePMDS.TestUnits.TestsDevelop.runRepository2(IDClient);
                WCFServicePMDS.TestUnits.TestsDevelop.runTestRepositoryAsync(IDClient);

                //System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.testRep: " + ex.ToString());
            }
        }
        public bool sendExceptionAsSMTPEMail(string except, string client, string User, DateTime dAt)
        {
            try
            {
                if (!Environment.MachineName.Trim().ToLower().Equals(("styhl2").Trim().ToLower()))
                {
                    return EMail.sendExceptionAsSMTPEMail(except, client, User, dAt);
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }






        public List<byte[]> getDataSerialized()
        {
            try
            {
                //WCFServicePMDS.TestUnits.TestDTO.BenutzerDt BenutzerDt1 = new TestDTO.BenutzerDt() { IDBenutzer = "", lBereich = new List<TestDTO.AerztDt>(), aerzt = new TestDTO.AerztDt() { DtoFrom = DateTime.Now } };
                //List<WCFServicePMDS.TestUnits.TestDTO.BenutzerDt> lBen = new List<TestDTO.BenutzerDt>();
                //lBen.Add(BenutzerDt1);

                //string strSer = WCFServicePMDS.Repository.serialize.Serialize<List<WCFServicePMDS.TestUnits.TestDTO.BenutzerDt>>(lBen);
                //List<WCFServicePMDS.TestUnits.TestDTO.BenutzerDt> lBenDes = WCFServicePMDS.Repository.serialize.Deserialize<List<WCFServicePMDS.TestUnits.TestDTO.BenutzerDt>>(strSer);
                ////return strSer;

                StammdatenDTO st = new StammdatenBAL().getLastStammdaten();

                List<byte[]> lRet = new List<byte[]>();
                lRet.Add(StammdatenDTO.lastSDSerB);
                lRet.Add(BenutzerMainDTO.lastBenListSerB);
                lRet.Add(BenutzerMainDTO.lastBenTablesSerB);
                lRet.Add(PatientMainDTO.lastPatListSerB);
                lRet.Add(PatientMainDTO._lastPatTablesSerB);

                return lRet;



                //StammdatenDTO st = new StammdatenBAL().getLastStammdaten();

                //var dBen = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
                //List<BenutzerMainDTO.BenutzerDt> ben = dBen.Value;

                ////var dPat = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
                ////List<PatientMainDTO.PatientDt> pat = dPat.Value;

                //var aSerializer = new XmlSerializer(typeof(List<BenutzerMainDTO.BenutzerDt>));
                //StringBuilder sb = new StringBuilder();
                //StringWriter sw = new StringWriter(sb);
                //aSerializer.Serialize(sw, ben);


                //string xmlResult = sw.GetStringBuilder().ToString();
                //string benSer = WCFServicePMDS.Repository.serialize.Serialize<List<BenutzerMainDTO.BenutzerDt>>(ben);
                //List<BenutzerMainDTO.BenutzerDt> benDes = WCFServicePMDS.Repository.serialize.Deserialize<List<BenutzerMainDTO.BenutzerDt>>(xmlResult);

                //int sizeOfVariable = System.Text.ASCIIEncoding.Unicode.GetByteCount(xmlResult);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.getDataSerialized: " + ex.ToString());
            }
        }
        public StammdatenDTO getLastStammdaten()
        {
            try
            {
                return new StammdatenBAL().getLastStammdaten();
                //new TestsDevelop().load();
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.loadStammdaten: " + ex.ToString());
            }
        }
        public List<BenutzerMainDTO.BenutzerDt> getLastBenutzer()
        {
            try
            {
                DateTime dFrom = DateTime.Now;

                var valPair = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
                return valPair.Value;

                //if (BenutzerMainDTO.lastBenList != null)
                //{
                //    return BenutzerMainDTO.lastBenList;
                //}
                //else
                //{
                //    var valPair = BenutzerMainDTO.lAll.OrderByDescending(v => v.Key).First();
                //    BenutzerMainDTO.lastBenList = valPair.Value;
                //    return valPair.Value;
                //}

                //return  new BenutzerMainBAL().load(ref dFrom);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.getLastBenutzer: " + ex.ToString());
            }
        }
        public List<PatientMainDTO.PatientDt> getLastPatienten()
        {
            try
            {
                DateTime dFrom = DateTime.Now;

                var valPair = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
                return valPair.Value;

                //if (PatientMainDTO.lPatList != null)
                //{
                //    return PatientMainDTO.lPatList;
                //}
                //else
                //{
                //    var valPair = PatientMainDTO.lAllAct.OrderByDescending(v => v.Key).First();
                //    PatientMainDTO.lPatList = valPair.Value;
                //    return valPair.Value;
                //}
                //return new BAL.Main.PatientMainBAL().load(ref dFrom);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.getLastPatienten: " + ex.ToString());
            }
        }






        public bool ELGALogInHCP(string usr, string pwd, string NameGDA, string Rolle, Guid IDKlinik, ref BAL2.ELGABAL.ELGASessionDTO session, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.ELGALogInHCP(usr, pwd, NameGDA, Rolle, IDKlinik, ref session, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGALogIn: " + ex.ToString());
            }
        }
        public bool ELGALogOut(ref BAL2.ELGABAL.ELGASessionDTO session, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.ELGALogOut(ref session, ELGAUrl);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGALogOut: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAQueryPatients(ref ELGAParInDto parsIn, eTypeQueryPatients TypeQueryPatients, bool checkOneRowMustFound, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();

                ehrPatientClientDto ehrPatientClientDtoBack = null;
                return elga.queryPatients(ref parsIn, TypeQueryPatients, ref ehrPatientClientDtoBack, checkOneRowMustFound, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAQueryPatients: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAinsertPatient(ref ELGAParInDto parsIn, eTypeUpdatePatients TypeUpdatePatients, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.insertPatient(ref parsIn, TypeUpdatePatients, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAinsertPatient: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAUpdatePatient(ref ELGAParInDto parsIn, eTypeUpdatePatients TypeUpdatePatients, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.updatePatient(ref parsIn, TypeUpdatePatients, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.updatePatient: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAAddContactAdmission(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.addContactAdmission(ref parsIn, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAAddContactAdmission: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAInvalidateContact(ref ELGAParInDto parsIn, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.invalidateContact(ref parsIn, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAInvalidateContact: " + ex.ToString());
            }
        }
        
        public ELGAParOutDto ELGAAddContactDischarge(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.addContactDischarge(ref parsIn, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAAddContactDischarge: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAListContacts(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.listContacts(ref parsIn, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAListContacts: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGADelegateContact(ref ELGAParInDto parsIn, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.delegateContact(ref parsIn, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGADelegateContact: " + ex.ToString());
            }
        }

        public ELGAParOutDto ELGAQueryGDAs(ref ELGAParInDto parsIn, string ELGAUrlGDAIndex)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.queryGDAs(ref parsIn, ELGAUrlGDAIndex);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAQueryGDAs: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAQueryDocuments(ref ELGAParInDto parsIn, bool OnlyOneDoc, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();

                documentClientDto documentClientDtoBack = null;
                submissionSetClientDto submissionSet = null;
                return elga.queryDocuments(ref parsIn, OnlyOneDoc, UniqueId, ref documentClientDtoBack, ref submissionSet, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAQueryDocuments: " + ex.ToString());
            }
        }
        public ELGAParOutDto queryPatientContent(ref ELGAParInDto parsIn, bool OnlyOneDoc, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();

                documentClientDto documentClientDtoBack = null;
                submissionSetClientDto submissionSet = null;
                return elga.queryPatientContent(ref parsIn, OnlyOneDoc, UniqueId, ref documentClientDtoBack, ref submissionSet, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.queryPatientContent: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGARetrieveDocument(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.retrieveDocument(ref parsIn, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGARetrieveDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAAddDocument(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.addDocument(ref parsIn, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAAddDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto ELGAUpdateDocument(ref ELGAParInDto parsIn, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.updateDocument(ref parsIn, UniqueId, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ELGAUpdateDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto ElgaDeprecateDocument(ref ELGAParInDto parsIn, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                WCFServicePMDS.ELGABAL elga = new WCFServicePMDS.ELGABAL();
                return elga.deprecateDocument(ref parsIn, UniqueId, authUniversalID, ELGAUrl);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.ElgaDeprecateDocument: " + ex.ToString());
            }
        }

        public CDABAL.CDA.CDABack genCDA(CDABAL.CDA.CDAIN vars)
        {
            try
            {
                return new CDABAL.CDA().gen(vars);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.genCDA: " + ex.ToString());
            }
        }






        public bool Export(Guid IDClient, System.Guid IDPatient, ref string ArchivPath, out string FileNameXMLDocumentBack, bool IsTest = true)
        {
            try
            {
                IsTest = true;
                IDatenExportXML export = new DatenExportXML();
                return export.Export(IDPatient, ref ArchivPath, out FileNameXMLDocumentBack, IsTest, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.Export: " + ex.ToString());
            }
        }
        public bool DynReportsInitStructure(ref string RootPath, Guid IDClient)
        {
            try
            {
                //IsTest = true;
                IDynReportsInitStructure dynrepinitstruct = new DynReportsBAL.DynReportsInitStructure();
                RootPath = @"C:\PMDS\PMDS_Root\Recent.x86";
                return dynrepinitstruct.DynReportsInitStruct(ref RootPath, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.DynReportsInitStructure: " + ex.ToString());
            }
        }








        public List<byte[]> getvKlientenliste(Guid IDClient)
        {
            Task<ConcurrentBag<vKlientenlisteDTO>> t = new PatientMainBAL().getvKlientenliste(IDClient);
            t.Wait();

            StammdatenDTO.lastStammdaten sdDes2 = (StammdatenDTO.lastStammdaten)WCFServicePMDS.Repository.serialize.BinaryDeserialize(StammdatenDTO.lastSDSerB);

            List<byte[]> lRet = new List<byte[]>();
            lRet.Add(StammdatenDTO.lastSDSerB);

            return lRet;
        }
        public void testPDFIum()
        {
            try
            {
                new TestsDevelop().testPDFIum();
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.testtestPDFIumRep: " + ex.ToString());
            }
        }





        public WCFServicePMDS.BAL.DTO.MessagesDto messagesSent(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                return new MessagesBAL().messagesSent(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.messagesSent: " + ex.ToString());
            }
        }
        public WCFServicePMDS.BAL.DTO.MessagesDto messagesUnreadedUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                return new MessagesBAL().messagesUnreadedUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.messagesUnreadedUsr: " + ex.ToString());
            }
        }
        public WCFServicePMDS.BAL.DTO.MessagesDto messagesAllUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                return new MessagesBAL().messagesAllUsr(ClientsMessage, TypeMessage, UserId, dFromTmp, dToTmp, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.messagesAllUsr: " + ex.ToString());
            }
        }

        public MessagesDTO addMessage(Guid IDUser, string Username, string Title, string Message, string ClientsMessage, string TypeMessage, List<Guid> lUsersTo, Guid IDClient)
        {
            try
            {
                return new MessagesBAL().addMessage(IDUser, Username, Title, Message, ClientsMessage, TypeMessage, lUsersTo, IDClient);

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.addMessage: " + ex.ToString());
            }
        }

        public void StopWCFService()
        {
            try
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.StopWCFService: " + ex.ToString());
            }
        }
        public bool CheckWCFServiceIsRunning()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.CheckWCFServiceIsRunning: " + ex.ToString());
            }
        }



        public bool TestWCFService()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.Service1.TestWCFService: " + ex.ToString());
            }
        }

    }

}

