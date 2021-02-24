using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using WCFServicePMDS.BAL2.ELGABAL;
using System.Collections.Concurrent;
using Elga.core.ServiceReferenceELGA;


namespace WCFServicePMDS
{

    public class ELGABAL
    {

       
        private static int GdaMaxResults = 100;

        public enum eTypeQueryPatients
        {
            SozVersNr = 0,
            LocalID = 1
        }
        public enum eTypeUpdatePatients
        {
            CreateLocalPatientID = 0,
            UpdatePatientData = 1
        }





        public bool ELGALogInHCP(string usr, string pwd, string NameGDA, string Rolle, Guid IDKlinik, ref ELGASessionDTO session, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                session.ELGAStateID = "";
                new ELGAChache().clearEhrPatientUsr(session);

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);
                spiritHCPLoginRequest req = new spiritHCPLoginRequest
                {
                    user = usr,
                    pwd = pwd,
                    userName = usr.Trim(),        
                    org = NameGDA,
                    role = Rolle                   //"Pflegeeinrichtung";
                };

                spiritUserResponse rsp = new spiritUserResponse();
                try
                {
                    rsp = objWsLogin.loginHCP(req);
                }
                catch (System.ServiceModel.EndpointNotFoundException ex)
                {
                    session.ELGAStateID = "";
                    return false;
                }

                if (rsp.responseDetail.listError != null && rsp.responseDetail.listError.Count() > 0)
                {
                    foreach (string err in rsp.responseDetail.listError)
                    {
                        session.Errors += err + "\r\n";
                    }
                }

                session.ELGAStateID = rsp.stateID;
                return true;

            }
            catch (Exception ex)
            {
                session.ELGAStateID = "";
                throw new Exception("ELGABAL.ELGALogInHCP: " + ex.ToString());
            }
        }
        public bool ELGALogOut(ref ELGASessionDTO session, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                if (session.ELGAStateID != null && session.ELGAStateID.Trim() != "")
                {
                    EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                    ehrWsEmptyReq ehrWsEmptyReq1 = new ehrWsEmptyReq();
                    ehrWsEmptyReq1.stateID = session.ELGAStateID;
                    objWsLogin.usrLogout(ehrWsEmptyReq1);

                    session.ELGAStateID = "";
                    session.ELGAStateID = "";
                    new ELGAChache().clearEhrPatientUsr(session);

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                if (ex.ToString().Trim().ToLower().Contains(("ession").Trim().ToLower()) && ex.ToString().Trim().ToLower().Contains(("does not exist").Trim().ToLower()))
                {
                    session.ELGAStateID = "";
                    bool SessionNotExists = true;
                }
                else
                {
                    session.ELGAStateID = "";
                }
                throw new Exception("ELGABAL.ELGALogOut: " + ex.ToString());
            }
        }

        public ELGAParOutDto queryPatients(ref ELGAParInDto parsIn, eTypeQueryPatients TypeQueryPatients, ref ehrPatientClientDto ehrPatientClientDtoBack, 
                                            bool checkOneRowMustFound, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                new ELGAChache().clearEhrPatientUsr(parsIn.session);
                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                ehrPatientRq ehrPatientRq1 = new ehrPatientRq();
                ehrPatientRq1.stateID = parsIn.session.ELGAStateID;
                ehrPatientRq1.requestData = new ehrPatientClientDto();
                ehrPatientRq1.requestData.familyName = this.checkFieldNull(parsIn.sObjectDto.NachNameFirma);
                ehrPatientRq1.requestData.givenName = this.checkFieldNull(parsIn.sObjectDto.Vorname);
                ehrPatientRq1.requestData.zip = this.checkFieldNull(parsIn.sObjectDto.Zip);
                ehrPatientRq1.requestData.city = this.checkFieldNull(parsIn.sObjectDto.City);
                ehrPatientRq1.requestData.streetAddress = this.checkFieldNull(parsIn.sObjectDto.Street);
                if (parsIn.sObjectDto.birthdate != null)
                {
                    ehrPatientRq1.requestData.birthdate = parsIn.sObjectDto.birthdate.ToString();
                }
                //ehrPatientRq1.requestData.ssnNumber = ;

                if (TypeQueryPatients == eTypeQueryPatients.SozVersNr)
                {
                    ehrPatientRq1.requestData.pid = new ehrPIDClientDto[1];
                    ehrPIDClientDto ehrPIDClientDto1 = new ehrPIDClientDto();
                    ehrPIDClientDto1.patientID = parsIn.sObjectDto.SozVersNrLocalPatID.Trim();
                    ehrPIDClientDto1.domain = new ehrDomainClientDto() { authUniversalID = "1.2.40.0.10.1.4.3.1" };
                    ehrPatientRq1.requestData.pid[0] = ehrPIDClientDto1;
                }
                else if (TypeQueryPatients == eTypeQueryPatients.LocalID)
                {
                    if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                    {
                        throw new Exception("ELGABAL.queryPatients: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                    }

                    ehrPatientRq1.requestData.pid = new ehrPIDClientDto[1];
                    ehrPIDClientDto ehrPIDClientDto1 = new ehrPIDClientDto();
                    ehrPIDClientDto1.patientID = parsIn.sObjectDto.SozVersNrLocalPatID.Trim();
                    ehrPIDClientDto1.domain = new ehrDomainClientDto() { authUniversalID = authUniversalID };
                    //ehrPIDClientDto1.domain = new ehrDomainClientDto() { authUniversalID = "1.2.40.0.34.99.10.2.1.1.13593.1" };
                    ehrPatientRq1.requestData.pid[0] = ehrPIDClientDto1;
                }
                else
                {
                    throw new Exception("ELGABAL.queryPatients: TypeQueryPatients '" + TypeQueryPatients.ToString() + "' not allowed!");
                }

                ehrPatientRsp ehrPatientRsp1 = objWsLogin.queryPatients(ehrPatientRq1);
                if (ehrPatientRsp1.queryError == null)
                {
                    if (ehrPatientRsp1.responseData != null)
                    {
                        foreach (ehrPatientClientDto elgaPatient in ehrPatientRsp1.responseData)
                        {
                            this.setELGAPatients(elgaPatient, parsIn.session, retDto);
                            ehrPatientClientDtoBack = elgaPatient;
                        }
                        if (checkOneRowMustFound)
                        {
                            if (retDto.iRowsFound != 1)
                            {
                                throw new Exception("ELGABAL.queryPatients: retDto.iRowsFound!=1 not allowed for parsIn.sObjectDto.SozVersNrLocalPatID '" + parsIn.sObjectDto.SozVersNrLocalPatID.Trim() + "'!");
                            }
                        }
                    }
                    else
                    {
                        bool bNoDataFound = true;
                    }
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getELGAErrors2(ehrPatientRsp1, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.queryPatients: " + ex.ToString());
            }
        }
        public ELGAParOutDto insertPatient(ref ELGAParInDto parsIn, eTypeUpdatePatients TypeUpdatePatients, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                ehrPatientRq ehrPatientRq1 = new ehrPatientRq();
                ehrPatientRq1.stateID = parsIn.session.ELGAStateID;

                if (TypeUpdatePatients == eTypeUpdatePatients.CreateLocalPatientID)
                {
                    ehrPatientRq1.requestData = new ELGAChache().getEhrPatient(parsIn.IDPatientIntern);

                    ehrWsEmptyReq ehrWsEmptyReq1 = new ehrWsEmptyReq();
                    ehrWsEmptyReq1.stateID = parsIn.session.ELGAStateID;
                    ehrPatIdRsp ehrPatIdRsp1 = objWsLogin.createLocalPID(ehrWsEmptyReq1);
                    ehrPIDClientDto ehrPIDClientDto1 = ehrPatIdRsp1.responseData[0];
                    ehrPIDClientDto1.patientID = parsIn.LocalPatientID.ToString();

                    ehrPIDClientDto[] arrEhrPIDClientDto1 = ehrPatientRq1.requestData.pid;
                    Array.Resize(ref arrEhrPIDClientDto1, arrEhrPIDClientDto1.Length + 1);
                    arrEhrPIDClientDto1[arrEhrPIDClientDto1.Length - 1] = ehrPIDClientDto1;
                    ehrPatientRq1.requestData.pid = arrEhrPIDClientDto1;
                }
                else if (TypeUpdatePatients == eTypeUpdatePatients.UpdatePatientData)
                {
                    if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                    {
                        throw new Exception("ELGABAL.updatePatient: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                    }
                    ehrPatientClientDto ehrPatientClientDtoBack = null;
                    this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                    ehrPatientRq1.requestData = ehrPatientClientDtoBack;            //new ELGAChache().getEhrPatient(parsIn.IDPatientIntern);

                    if (parsIn.sObjectDto.NachNameFirma.Trim() != "")
                        ehrPatientRq1.requestData.familyName = parsIn.sObjectDto.NachNameFirma.Trim();
                    if (parsIn.sObjectDto.Vorname.Trim() != "")
                        ehrPatientRq1.requestData.givenName = parsIn.sObjectDto.Vorname.Trim();
                    if (parsIn.sObjectDto.City.Trim() != "")
                        ehrPatientRq1.requestData.city = parsIn.sObjectDto.City.Trim();
                    if (parsIn.sObjectDto.Zip.Trim() != "")
                        ehrPatientRq1.requestData.zip = parsIn.sObjectDto.Zip.Trim();
                    if (parsIn.sObjectDto.Street.Trim() != "")
                        ehrPatientRq1.requestData.streetAddress = parsIn.sObjectDto.Street.Trim();
                    if (parsIn.sObjectDto.Country.Trim() != "")
                        ehrPatientRq1.requestData.country = parsIn.sObjectDto.Country.Trim();
                }
                else
                {
                    throw new Exception("ELGABAL.insertPatient: TypeUpdatePatients '" + TypeUpdatePatients.ToString() + "' not allowed!");
                }

                ehrPatientRsp ehrPatientRsp1 = objWsLogin.insertPatient(ehrPatientRq1);


                if (ehrPatientRsp1.queryError == null)
                {
                    if (ehrPatientRsp1.responseData != null)
                    {
                        foreach (ehrPatientClientDto elgaPatient in ehrPatientRsp1.responseData)
                        {
                            this.setELGAPatients(elgaPatient, parsIn.session, retDto);
                        }
                        if (retDto.iRowsFound != 1)
                        {
                            throw new Exception("ELGABAL.insertPatient: retDto.iRowsFound!=1 not allowed for parsIn.sObjectDto.SozVersNrLocalPatID '" + parsIn.sObjectDto.SozVersNrLocalPatID.Trim() + "'!");
                        }

                        string patLocalID = "";
                        foreach (var rPid in retDto.lPatients[0].ELGAPids)
                        {
                            if (rPid.patientID.Trim().ToLower().Equals(parsIn.LocalPatientID.Trim().ToLower()) && rPid.authUniversalID.Trim().Equals((parsIn.authUniversalID).Trim()))
                            {
                                patLocalID = rPid.patientID.Trim();
                            }
                        }

                        if (patLocalID.Trim() == "")
                        {
                            throw new Exception("ELGABAL.insertPatient: patLocalID='' not allowed!");
                        }
                        ehrPatientClientDto ehrPatientClientDtoBackQuery = null;
                        parsIn.LocalPatientID = patLocalID;
                        return this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBackQuery, true, authUniversalID, ELGAUrl);
                    }
                    else
                    {
                        bool bNoDataFound = true;
                        throw new Exception("ELGABAL.insertPatient: no patient found in response-data! (ehrPatientRsp1.responseData=null)");
                    }
                }
                else
                {
                    this.getELGAErrors2(ehrPatientRsp1, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.insertPatient: " + ex.ToString());
            }
        }
        public ELGAParOutDto updatePatient(ref ELGAParInDto parsIn, eTypeUpdatePatients TypeUpdatePatients, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                ehrPatientRq ehrPatientRq1 = new ehrPatientRq();
                ehrPatientRq1.stateID = parsIn.session.ELGAStateID;

                if (TypeUpdatePatients == eTypeUpdatePatients.CreateLocalPatientID)
                {
                    ehrPatientRq1.requestData = new ELGAChache().getEhrPatient(parsIn.IDPatientIntern);

                    ehrWsEmptyReq ehrWsEmptyReq1 = new ehrWsEmptyReq();
                    ehrWsEmptyReq1.stateID = parsIn.session.ELGAStateID;
                    ehrPatIdRsp ehrPatIdRsp1 = objWsLogin.createLocalPID(ehrWsEmptyReq1);
                    ehrPIDClientDto ehrPIDClientDto1 = ehrPatIdRsp1.responseData[0];
                    ehrPIDClientDto1.patientID = parsIn.LocalPatientID.ToString();

                    ehrPIDClientDto[] arrEhrPIDClientDto1 = ehrPatientRq1.requestData.pid;
                    Array.Resize(ref arrEhrPIDClientDto1, arrEhrPIDClientDto1.Length + 1);
                    arrEhrPIDClientDto1[arrEhrPIDClientDto1.Length - 1] = ehrPIDClientDto1;
                    ehrPatientRq1.requestData.pid = arrEhrPIDClientDto1;
                }
                else if (TypeUpdatePatients == eTypeUpdatePatients.UpdatePatientData)
                {
                    if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                    {
                        throw new Exception("ELGABAL.updatePatient: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                    }
                    ehrPatientClientDto ehrPatientClientDtoBack = null;
                    this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                    ehrPatientRq1.requestData = ehrPatientClientDtoBack;            //new ELGAChache().getEhrPatient(parsIn.IDPatientIntern);

                    if (parsIn.sObjectDto.NachNameFirma.Trim() != "")
                        ehrPatientRq1.requestData.familyName = parsIn.sObjectDto.NachNameFirma.Trim();
                    if (parsIn.sObjectDto.Vorname.Trim() != "")
                        ehrPatientRq1.requestData.givenName = parsIn.sObjectDto.Vorname.Trim();
                    if (parsIn.sObjectDto.City.Trim() != "")
                        ehrPatientRq1.requestData.city = parsIn.sObjectDto.City.Trim();
                    if (parsIn.sObjectDto.Zip.Trim() != "")
                        ehrPatientRq1.requestData.zip = parsIn.sObjectDto.Zip.Trim();
                    if (parsIn.sObjectDto.Street.Trim() != "")
                        ehrPatientRq1.requestData.streetAddress = parsIn.sObjectDto.Street.Trim();
                    if (parsIn.sObjectDto.Country.Trim() != "")
                        ehrPatientRq1.requestData.country = parsIn.sObjectDto.Country.Trim();
                }
                else
                {
                    throw new Exception("ELGABAL.updatePatient: TypeUpdatePatients '" + TypeUpdatePatients.ToString() + "' not allowed!");
                }

                ehrPatientRsp ehrPatientRsp1 = objWsLogin.updatePatient(ehrPatientRq1);


                if (ehrPatientRsp1.queryError == null)
                {
                    if (ehrPatientRsp1.responseData != null)
                    {
                        foreach (ehrPatientClientDto elgaPatient in ehrPatientRsp1.responseData)
                        {
                            this.setELGAPatients(elgaPatient, parsIn.session, retDto);
                        }
                        if (retDto.iRowsFound != 1)
                        {
                            throw new Exception("ELGABAL.updatePatient: retDto.iRowsFound!=1 not allowed for parsIn.sObjectDto.SozVersNrLocalPatID '" + parsIn.sObjectDto.SozVersNrLocalPatID.Trim() + "'!");
                        }
                    }
                    else
                    {
                        bool bNoDataFound = true;
                        throw new Exception("ELGABAL.updatePatient: npatient found in response-data! (ehrPatientRsp1.responseData=null)");
                    }
                    return retDto;
                }
                else
                {
                    this.getELGAErrors2(ehrPatientRsp1, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.updatePatient: " + ex.ToString());
            }
        }
        public ELGAParOutDto addContactAdmission(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            ELGAParOutDto retDto = this.initParOut();
            try
            {
                //EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort");
                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.addContactAdmission: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                trsClientAddContactRq trsClientAddContactRq1 = new trsClientAddContactRq();
                trsClientAddContactRq1.stateID = parsIn.session.ELGAStateID;
                trsClientAddContactRq1.patient = ehrPatientClientDtoBack;           //new ELGAChache().getEhrPatient(parsIn.LocalPatientID);
                //trsClientAddContactRq1.contactType = "";
                trsClientAddContactRsp trsClientAddContactRsp = objWsLogin.addContactAdmission(trsClientAddContactRq1);
                //trsClientAddContactRsp trsClientAddContactRsp = objWsLogin.addContact(trsClientAddContactRq1);
                

                if (trsClientAddContactRsp.responseDetail.listError == null || trsClientAddContactRsp.responseDetail.listError.Count() == 0)
                {
                    retDto.ContactID = trsClientAddContactRsp.contactID;
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(trsClientAddContactRsp.responseDetail.listError, ref retDto);
                    return retDto;
                }

                // https://termpub.gesundheit.gv.at/TermBrowser/gui/main/main.zul
                // ELGA_KontaktTypen
                //      Stationär K101  >> addContactAdmission()
                //      Ambulant K102
                //      Entlassung K103 >> addContactDischarge()
                //      Delegiert K104
            }
            catch (Exception ex)
            {
                string sExceptCheck = "Stat. Aufnahme auf bereits erfolgte stat. Aufnahme";
                if (ex.ToString().Trim().ToLower().Contains(sExceptCheck.Trim().ToLower()))
                {
                    retDto.ContactExists = true;
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    throw new Exception("ELGABAL.addContactAdmission: " + ex.ToString());
                }
            }
        }
        public ELGAParOutDto invalidateContact(ref ELGAParInDto parsIn, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                trsClientInvalidateContactRq trsClientInvalidateContactRq1 = new trsClientInvalidateContactRq();
                trsClientInvalidateContactRq1.stateID = parsIn.session.ELGAStateID;
                trsClientInvalidateContactRq1.treatmentID = parsIn.ContactID;

                trsClientInvalidateContactRsp trsClientInvalidateContactRsp = objWsLogin.invalidateContact(trsClientInvalidateContactRq1);

                if (trsClientInvalidateContactRsp.responseDetail.listError.Count() == 0)
                {
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(trsClientInvalidateContactRsp.responseDetail.listError, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.invalidateContact: " + ex.ToString());
            }
        }
        public ELGAParOutDto addContactDischarge(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                //Entlassung
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.addContactDischarge: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                trsClientAddContactRq trsClientAddContactRq1 = new trsClientAddContactRq();
                trsClientAddContactRq1.stateID = parsIn.session.ELGAStateID;
                trsClientAddContactRq1.patient = ehrPatientClientDtoBack;

                trsClientAddContactRsp trsClientAddContactRsp = objWsLogin.addContactDischarge(trsClientAddContactRq1);

                if (trsClientAddContactRsp.responseDetail.listError == null || trsClientAddContactRsp.responseDetail.listError.Count() == 0)
                {
                    retDto.ContactID = trsClientAddContactRsp.contactID;
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(trsClientAddContactRsp.responseDetail.listError, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.addContactDischarge: " + ex.ToString());
            }
        }
        public ELGAParOutDto listContacts(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.listContacts: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                trsClientListContactsRq trsClientListContactsRq1 = new trsClientListContactsRq();
                trsClientListContactsRq1.stateID = parsIn.session.ELGAStateID;
                trsClientListContactsRq1.patient = ehrPatientClientDtoBack;

                trsClientListContactsRsp trsClientListContactsRsp1 = objWsLogin.listContacts(trsClientListContactsRq1);

                if (trsClientListContactsRsp1.responseDetail.listError.Count() == 0)
                {
                    if (trsClientListContactsRsp1.contacts != null)
                    {
                        foreach (treatmentData treat in trsClientListContactsRsp1.contacts)
                        {
                            ELGAContactsDto contact = new ELGAContactsDto();
                            contact.IDElga =  this.checkFieldNull(treat.ID);
                            contact.PatientID = this.checkFieldNull(treat.patientId);
                            contact.creationDate = this.checkFieldNull(treat.creationDate);
                            contact.status = this.checkFieldNull(treat.status);
                            contact.type = this.checkFieldNull(treat.type);

                            retDto.lContacts.Add(contact);
                        }
                    }

                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(trsClientListContactsRsp1.responseDetail.listError, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.listContacts: " + ex.ToString());
            }
        }


        public ELGAParOutDto queryGDAs(ref ELGAParInDto parsIn, string ELGAUrlGDAIndex)
        {
            ELGAParOutDto retDto = this.initParOut();
            try
            {
                GdaIndexWs GdaIndexWs1 = new GdaIndexWs();            
                GdaIndexWs1.Url = ELGAUrlGDAIndex;
                
                GdaIndexRequestPerson inpGda1 = new GdaIndexRequestPerson();
                InstanceIdentifierPerson iGDAPers = new InstanceIdentifierPerson();
                iGDAPers.surname = parsIn.sObjectDto.NachNameFirma.Trim();            //  Lettner*   R-min. 2 letters             
                iGDAPers.firstname = parsIn.sObjectDto.Vorname.Trim();
                iGDAPers.rolecode = "";
                iGDAPers.gdaStatus = gdastat.aktiv;             //R

                iGDAPers.postcode = parsIn.sObjectDto.Zip.Trim();
                iGDAPers.city = parsIn.sObjectDto.City.Trim();
                iGDAPers.streetName = parsIn.sObjectDto.Street.Trim();
                iGDAPers.streetNumber = parsIn.sObjectDto.StreetNr.Trim();

                iGDAPers.maxResults = GdaMaxResults.ToString();                    //R
                
                inpGda1.hcIdentifierPerson = iGDAPers;
                ListResponse[] retGda1 = new ListResponse[0];

                try
                {
                    retGda1 = GdaIndexWs1.GdaIndexPersonenSuche(inpGda1);
                }                
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                        retDto.MessageException = ex.Message;
                        retDto.MessageExceptionNr = 0;
                        retDto.bOK = true;
                        return retDto;
                }

                if (retGda1.Length > 0)
                {
                    retDto.Errors = "";
                    foreach (var respItm in retGda1)
                    {
                        if (!String.IsNullOrEmpty(respItm.error))
                        {
                            if (retDto.Errors.Trim() == "")
                                retDto.Errors += "Errors:" + "\r\n";
                            retDto.Errors += respItm.error + "\r\n";
                        }

                        var rGda = respItm.gda;
                        ObjectDTO newGda = new ObjectDTO() { NachNameFirma = "", Vorname = "", Title = "", IDELgaGda = "", isOrganisation = false };

                        newGda.NachNameFirma = this.checkFieldNull(rGda.surname);
                        newGda.Vorname = this.checkFieldNull(rGda.firstname);
                        newGda.Title = this.checkFieldNull(rGda.title);
                        newGda.IDELgaGda = this.checkFieldNull(rGda.gdaId.id);
                        newGda.isOrganisation = rGda.isOrganisation;
                        newGda.Fachrichtung = rGda.otherRoles[0].id;

                        if (rGda.addresses != null)
                        {
                            foreach (var rGdaAdress in rGda.addresses)
                            {
                                AdressDto newAdress = new AdressDto() { Zip = "", City = "", Country = "", Street = "", StreetNr = "", Status = "", State = "" };
                                newGda.lAdresses = new List<AdressDto>();
                                newGda.lAdresses.Add(newAdress);

                                newAdress.Zip = this.checkFieldNull(rGdaAdress.zip);
                                newAdress.City = this.checkFieldNull(rGdaAdress.city);
                                newAdress.Country = this.checkFieldNull(rGdaAdress.country);
                                newAdress.Street = this.checkFieldNull(rGdaAdress.streetName);
                                newAdress.StreetNr = this.checkFieldNull(rGdaAdress.streetNumber);
                                newAdress.Status = this.checkFieldNull(rGdaAdress.status);
                                newAdress.State = this.checkFieldNull(rGdaAdress.state);
                                newAdress.Country = rGdaAdress.country;

                                retDto.iRowsFound += 1;
                            }
                        }
                        retDto.lGDAs.Add(newGda);
                    }
                }

                if (retDto.Errors.Trim() == "")
                {
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    retDto.bErrorsFound = true;
                    return retDto;
                }

                //GetGdaDescriptors inpGda0 = new GetGdaDescriptors();
                //InstanceIdentifier iif = new InstanceIdentifier();

                //inpGda0.hcIdentifier = iif;
                //GdaIndexResponse retGda0 = GdaIndexWs1.GdaIndexSuche(inpGda0);

                //InstanceIdentifier[] inpGda2 = new InstanceIdentifier[1];
                //ListResponse[] retGd2a = GdaIndexWs1.GdaIndexListenSuche(inpGda2);
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.queryGDAs: " + ex.ToString());            
            }
        }
        public ELGAParOutDto queryDocuments(ref ELGAParInDto parsIn, bool OnlyOneDoc, string UniqueId, ref documentClientDto documentClientDtoBack, ref submissionSetClientDto submissionSet,
                                                string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();
                retDto.lDocuments = new List<ELGADocumentsDTO>();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);
                xdsQArgsDocument qArgs = new xdsQArgsDocument();

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.queryDocuments: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                if (parsIn.sDocumentsDto != null)
                {
                    if (parsIn.sDocumentsDto.Author != null && parsIn.sDocumentsDto.Author.Trim() != "")
                    {
                        string[] arrAuthors = new string[1] { parsIn.sDocumentsDto.Author.Trim() };
                        qArgs.authorPersons = arrAuthors;
                    }
                    if (parsIn.sDocumentsDto.DocumentStatus != null && parsIn.sDocumentsDto.DocumentStatus.Trim() != "")
                    {
                        string[] arrDocumentStatus = new string[1] { parsIn.sDocumentsDto.DocumentStatus.Trim() };
                        qArgs.documentStatus = arrDocumentStatus;
                    }
                    if (parsIn.sDocumentsDto.CreatedFrom != null && parsIn.sDocumentsDto.CreatedFrom != null)
                    {
                        qArgs.creationDateFrom = parsIn.sDocumentsDto.CreatedFrom.Value;
                    }
                    if (parsIn.sDocumentsDto.CreatedTo != null && parsIn.sDocumentsDto.CreatedTo != null)
                    {
                        qArgs.creationDateTo = parsIn.sDocumentsDto.CreatedTo.Value;
                    }
                }

                ehrXdsQDocumentRq ehrXdsQDocumentRq1 = new ehrXdsQDocumentRq();
                ehrXdsQDocumentRq1.stateID = parsIn.session.ELGAStateID;
                ehrXdsQDocumentRq1.xdsQArgsDocument = qArgs;
                ehrXdsQDocumentRq1.requestData = ehrPatientClientDtoBack.pid;
                
                ehrXdsQRsp ehrXdsQRsp1 = objWsLogin.queryDocuments(ehrXdsQDocumentRq1);

                return this.setELGADocu(ref ehrXdsQRsp1, ref parsIn, ref retDto, ref documentClientDtoBack, OnlyOneDoc, UniqueId, ref submissionSet);

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.queryDocuments: " + ex.ToString());
            }
        }
        public ELGAParOutDto queryPatientContent(ref ELGAParInDto parsIn, bool OnlyOneDoc, string UniqueId, ref documentClientDto documentClientDtoBack, ref submissionSetClientDto submissionSet,
                                                string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();
                retDto.lDocuments = new List<ELGADocumentsDTO>();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);
                xdsQArgsDocument qArgs = new xdsQArgsDocument();

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.queryPatientContent: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                ehrXdsQGetAllRq ehrXdsQGetAllRq1 = new ehrXdsQGetAllRq();
                ehrXdsQGetAllRq1.stateID = parsIn.session.ELGAStateID;
                ehrXdsQGetAllRq1.requestData = ehrPatientClientDtoBack.pid;

                ehrXdsQRsp ehrXdsQRsp1 = objWsLogin.queryPatientContent(ehrXdsQGetAllRq1);

                return this.setELGADocu(ref ehrXdsQRsp1, ref parsIn, ref retDto, ref documentClientDtoBack, OnlyOneDoc, UniqueId, ref submissionSet);

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.queryPatientContent: " + ex.ToString());
            }
        }
        public ELGAParOutDto retrieveDocument(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();
                retDto.lDocuments = new List<ELGADocumentsDTO>();

                if (parsIn.sDocumentsDto.UniqueID.Trim() == "")
                {
                    throw new Exception("ELGABAL.retrieveDocument: parsIn.sDocumentsDto.UniqueID='' not allowed!");
                }

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);
                //WSHttpBinding http = new WSHttpBinding() { MaxReceivedMessageSize = 2147483647, MessageEncoding = WSMessageEncoding.Mtom };
                //EndpointAddress addr = new EndpointAddress("http://hnelga01.tiani-spirit.com:8181/SpiritEhrWsRemoting/EhrWSRemoting");
                //EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient(http, addr);

                ehrXdsRetrReq ehrXdsRetrReq1 = new ehrXdsRetrReq();
                ehrXdsRetrReq1.stateID = parsIn.session.ELGAStateID;

                documentClientDto documentClientDtoBack = null;
                submissionSetClientDto submissionSet = null;
                this.queryDocuments(ref parsIn, true, parsIn.sDocumentsDto.UniqueID.Trim(), ref documentClientDtoBack, ref submissionSet, authUniversalID, ELGAUrl);
                ehrXdsRetrReq1.requestData = documentClientDtoBack;

                ehrXdsRetrRsp ehrXdsRetrRsp1 = objWsLogin.retrieveDocument(ehrXdsRetrReq1);

                if (ehrXdsRetrRsp1.partialErros == null)
                {
                    ELGADocumentsDTO newELGADocument = this.initDocu();
                    retDto.lDocuments.Add(newELGADocument);
                    newELGADocument.UniqueId = this.checkFieldNull(ehrXdsRetrRsp1.documentUniqueId);
                    newELGADocument.bdocument = ehrXdsRetrRsp1.document;

                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    foreach (xdsQPartialError errDocument in ehrXdsRetrRsp1.partialErros)
                    {
                        retDto.Errors += "errorCode: " + errDocument.errorCode + "\r\n";
                    }
                    retDto.bErrorsFound = true;
                    return retDto;
                }



                //EnvelopeVersion envS11 = EnvelopeVersion.Soap12;
                //string nextDestS11 = envS11.NextDestinationActorValue;
                //string[] ultDestsS11 = envS11.GetUltimateDestinationActorValues();
                //string ultS11 = ultDestsS11[0];
                //string toStrS11 = envS11.ToString();
                //EnvelopeVersion envS12 = EnvelopeVersion.Soap12;
                //EnvelopeVersion envNotSOAP = EnvelopeVersion.None;
                //string nextDestS12 = envS12.NextDestinationActorValue;
                //string[] ultDestsS12 = envS12.GetUltimateDestinationActorValues();


                //BasicHttpBinding http = new BasicHttpBinding();
                //http.MaxReceivedMessageSize = 2147483647;
                //http.UseDefaultWebProxy = true;
                //http.ReaderQuotas.MaxStringContentLength = 2147483647;
                //http.ReaderQuotas.MaxBytesPerRead = 2147483647;
                //http.ReaderQuotas.MaxArrayLength = 2147483647;
                //http.ReaderQuotas.MaxDepth = 2147483647;
                //http.ReaderQuotas.MaxNameTableCharCount = 2147483647;
                //http.ReceiveTimeout = new TimeSpan(0, 30, 0);
                //http.Name = "VaultBasicHttpBinding";

                //http.MaxBufferSize = 2147483647;
                //http.MaxBufferPoolSize = 2147483647;
                //http.ReceiveTimeout = new TimeSpan(0, 30, 0);
                //http.TransferMode = TransferMode.Streamed;
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.retrieveDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto addDocument(ref ELGAParInDto parsIn, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.addDocument: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);


                submissionSetClientDto submissionSet = new submissionSetClientDto();
                authorMetadataClientDto submissionSetAuthorMetadata = new authorMetadataClientDto();
                string[] arrInst = new string[1] { "" + parsIn.DocumentAdd.KlinikName.Trim() + "^^^^^^^^^" + "urn:oid:" + parsIn.DocumentAdd.KlinikOrganisationID.Trim() + "" };
                submissionSetAuthorMetadata.institution = arrInst;

                submissionSetAuthorMetadata.person = parsIn.DocumentAdd.Author.Trim();
                authorMetadataClientDto[] arrSubmissionSetAuthorMetadata = new authorMetadataClientDto[1] { submissionSetAuthorMetadata };
                submissionSet.author = arrSubmissionSetAuthorMetadata;
                submissionSet.name = parsIn.DocumentAdd.Documentname.Trim();
                submissionSet.description = parsIn.DocumentAdd.Description.Trim();

                ehrPIDClientDto ehrXdsPatientPid = null;
                foreach (ehrPIDClientDto pid in ehrPatientClientDtoBack.pid)
                {
                    if ((pid.ehrPIDType & 16) == 16)
                    {
                        ehrXdsPatientPid = pid;        // CommunityID - Extract the current PID as LocalXdsPid
                        break;
                    }
                }
                if (ehrXdsPatientPid == null)
                {
                    foreach (ehrPIDClientDto pid in ehrPatientClientDtoBack.pid)
                    {
                        if ((pid.ehrPIDType & 8) == 8)
                        {
                            ehrXdsPatientPid = pid;
                            break;
                        }
                    }
                }

                if (ehrXdsPatientPid == null)
                {
                    throw new Exception("ELGABAL.addDocument: xdsPatientPid == null not allowed!");
                }

                String xdsPatientPid = ehrXdsPatientPid.patientID + "^^^&" + ehrXdsPatientPid.domain.authUniversalID + "&" + ehrXdsPatientPid.domain.authUniversalIDType;    // Build the HL7 format (PatientID^^^&AuthUniversalID&AuthUniversalIDType)

                submissionSet.patientId = xdsPatientPid;

                documentClientDto submittingDocument = new documentClientDto();
                submittingDocument.bytes = parsIn.DocumentAdd.bDocument;
                submittingDocument.patientId = xdsPatientPid;
                submittingDocument.author = arrSubmissionSetAuthorMetadata;
                //submittingDocument.logicalId = ehrPatIdRsp_LocalID.stateID;

                authorMetadataClientDto submittingDocumentAuthorMetadata = new authorMetadataClientDto();
                submittingDocumentAuthorMetadata.person = parsIn.DocumentAdd.Person.Trim();
                submittingDocument.author = arrSubmissionSetAuthorMetadata;
                submittingDocument.legalAuthenticator = "document.legalAuthenticator";
                //submittingDocument.languageCode = "DE-TI";
                submittingDocument.description = parsIn.DocumentAdd.Description.Trim();
                submittingDocument.name = parsIn.DocumentAdd.Documentname.Trim();
                submittingDocument.mimeType = "text/xml";               //MIMEType of the submitFile (e.g. "application/pdf", "image/jpeg")

                // ------------------------------------------------------------------------------------------------------------------------------------------------
                // OnDocumentSetID muss ich in CDA Document mit reingeben und in unserer DB speichern zum Dokument um das Dokument später wieder zu identifizieren
                // Eigene ID = Guid (Kommt aus CDA), ClinicalDocumentSetID = Eindeutig (Kommt aus CDA Erstellung)
                // ------------------------------------------------------------------------------------------------------------------------------------------------
                string OnDocumentSetID = "" + parsIn.DocumentAdd.IDCDA.Trim() + "^^^&" + parsIn.DocumentAdd.ClinicalDocumentSetID.Trim() + "&ISO^urn:elga:iti:xds:2014:ownDocument_setId";
                submittingDocument.referenceIdList = new string[1] { OnDocumentSetID };

                //documentClientDtoEntry docuClientEntry = new documentClientDtoEntry() { key = "urn:ihe:iti:xds:2013:referenceIdList", value = OnDocumentSetID };
                //documentClientDtoEntry[] arrDocuClientEntry = new documentClientDtoEntry[1] { docuClientEntry };
                //submittingDocument.customSlotMap = arrDocuClientEntry;

                this.setIheClassificationForDocument(ref submittingDocument, ref submissionSet);

                sourceSubmissionClientDto sourceSubmission = new sourceSubmissionClientDto();
                documentClientDto[] arrDsubmittingDocument = new documentClientDto[] { submittingDocument };
                sourceSubmission.documents = arrDsubmittingDocument;

                //if (folderName.Trim() != "")
                //{
                //    folderClientDto submittingFolder = new folderClientDto();

                //    submittingFolder.name = folderName;
                //    submittingFolder.description = folderDescription;
                //    submittingFolder.createFolder = true;

                //    iheClassificationClientDto folderCodeList = new iheClassificationClientDto();
                //    folderCodeList.nodeRepresentation = AlergyTreatments;
                //    folderCodeList.value = "Alergy Treatments";
                //    string[] arrScheam = new string[1] { "Connect-a-thon folderCodeList" };
                //    folderCodeList.schema = arrScheam;

                //    iheClassificationClientDto[] arrFolderCodeList = new iheClassificationClientDto[] { folderCodeList };
                //    submittingFolder.codeList = arrFolderCodeList;

                //    sourceSubmission.folder = submittingFolder;
                //}
                //if (folder != null)
                //{
                //    sourceSubmission.folder = folder;
                //}

                sourceSubmission.submissionSet = submissionSet;
                xdsSrcSubmitReq xdsSrcSubmitRequest = new xdsSrcSubmitReq();
                xdsSrcSubmitRequest.stateID = parsIn.session.ELGAStateID;
                xdsSrcSubmitRequest.patient = ehrPatientClientDtoBack;
                xdsSrcSubmitRequest.srcSubmission = sourceSubmission;
                xdsSrcSubmitRequest.srcSubmission.documents[0].languageCode = "de-AT";
                //xdsSrcSubmitRequest.createDocumentUniqueID = false;

                xdsSrcSubmitRsp xdsSrcSubmitRsp1 = objWsLogin.submit(xdsSrcSubmitRequest);
                //xdsSrcSubmitRsp1.documentList[0].repositoryUniqueId;          //> Ist ev. schon die fertige DocumentID (=ReferenceList) die wir als Key in PMDS Datenabnak speichern sollen und auch wieder zur Suche verwenden

                if (xdsSrcSubmitRsp1.responseDetail.listError == null || xdsSrcSubmitRsp1.responseDetail.listError.Count() == 0)
                {
                    retDto.DocuUniqueId = xdsSrcSubmitRsp1.documentList[0].uniqueId.Trim();           //retDto.DocuUniqueId = xdsSrcSubmitRsp1.documentList[0].repositoryUniqueId.Trim();
                    retDto.bOK = true;
                    return retDto;

                    //if (xdsSrcSubmitRsp1.responseData != null)
                    //{
                    //    ehrPatientClientDto patientContentClientDto1 = xdsSrcSubmitRsp1.responseData;
                    //    if (patientContentClientDto1.do != null)
                    //    {
                    //        foreach (documentClientDto documentClientDto1 in patientContentClientDto1.documents)
                    //        {
                    //            ELGADocumentsDTO newELGADocuments = this.initDocu();
                    //            retDto.lDocuments.Add(newELGADocuments);
                    //            newELGADocuments.UUID = this.checkFieldNull(documentClientDto1.UUID);
                    //            patientContentClientDto patientContentClientDtoSaved = xdsSrcSubmitRsp1.responseData;
                    //        }
                    //    }
                    //}

                    //parsIn.sObjectDto.SozVersNrLocalPatID = xdsSrcSubmitRsp1
                    //documentClientDto documentClientDtoBack = null;
                    //this.queryDocumentsByUid(ref parsIn, ref documentClientDtoBack);
                }
                else
                {

                    this.getErrosElgaFct(xdsSrcSubmitRsp1.responseDetail.listError, ref retDto);
                    return retDto;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.addDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto updateDocument(ref ELGAParInDto parsIn, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                throw new Exception("ELGABAL.updateDocument: Function not activated!");

                //documentClientDto changedDocument

                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.updateDocument: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                //changedDocument.bytes = documentBytesToSubmit;

                string[] arrInst = new string[1] { "" + parsIn.DocumentAdd.KlinikName.Trim() + "^^^^^^^^^" + "urn:oid:" + parsIn.DocumentAdd.KlinikOrganisationID.Trim() + "" };

                // Create a SubmissionSet (because every XDS-action needs a new own one, e.g. for our updateDocument)
                submissionSetClientDto submissionSet2 = new submissionSetClientDto();

                authorMetadataClientDto submissionSetAuthorMetadata2 = new authorMetadataClientDto();
                submissionSetAuthorMetadata2.person = parsIn.DocumentAdd.Author.Trim();
                submissionSetAuthorMetadata2.institution = arrInst;
                authorMetadataClientDto[] arrSubmissionSetAuthorMetadata2 = new authorMetadataClientDto[1] { submissionSetAuthorMetadata2 };

                submissionSet2.author = arrSubmissionSetAuthorMetadata2;
                submissionSet2.name = parsIn.DocumentAdd.Documentname.Trim();
                submissionSet2.description = parsIn.DocumentAdd.Description.Trim();



                //New Document
                documentClientDto NewDocument = new documentClientDto();

                authorMetadataClientDto newDocumentAuthorMetadata = new authorMetadataClientDto();
                newDocumentAuthorMetadata.person = parsIn.DocumentAdd.Author.Trim();

                newDocumentAuthorMetadata.institution = arrInst;
                authorMetadataClientDto[] arrSubmissionSetAuthorMetadata2New = new authorMetadataClientDto[1] { newDocumentAuthorMetadata };
                NewDocument.author = arrSubmissionSetAuthorMetadata2New;

                NewDocument.name = parsIn.DocumentAdd.Documentname.Trim();
                NewDocument.description = parsIn.DocumentAdd.Description.Trim();
                NewDocument.bytes = parsIn.DocumentAdd.bDocument;
                //submittingDocument.patientId = xdsPatientPid;
                //submittingDocument.logicalId = ehrPatIdRsp_LocalID.stateID;
                NewDocument.legalAuthenticator = "document.legalAuthenticator";
                NewDocument.languageCode = "DE-TI";
                NewDocument.mimeType = "text/xml";

                this.setIheClassificationForDocument(ref NewDocument, ref submissionSet2);

                sourceSubmissionClientDto sourceSubmission = new sourceSubmissionClientDto();
                documentClientDto[] arrDsubmittingDocument = new documentClientDto[] { NewDocument };
                sourceSubmission.documents = arrDsubmittingDocument;
                sourceSubmission.submissionSet = submissionSet2;

                xdsSrcApRpReq request = new xdsSrcApRpReq();
                request.patient = ehrPatientClientDtoBack;
                request.stateID = parsIn.session.ELGAStateID;
                //request.oldDocument = changedDocument;
                request.srcSubmission = sourceSubmission;

                xdsSrcSubmitRsp xdsSrcSubmitRsp1 = objWsLogin.replace(request);

                if (xdsSrcSubmitRsp1.responseDetail.listError.Count() == 0)
                {
                    documentClientDto documentClientDtoBack = null;
                    submissionSetClientDto submissionSet = null;
                    this.queryDocuments(ref parsIn, true, UniqueId, ref documentClientDtoBack, ref submissionSet, authUniversalID, ELGAUrl);
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(xdsSrcSubmitRsp1.responseDetail.listError, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.updateDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto deprecateDocument(ref ELGAParInDto parsIn, string UniqueId, string authUniversalID, System.ServiceModel.EndpointAddress ELGAUrl)
        {
            try
            {
                ELGAParOutDto retDto = this.initParOut();

                EhrWSRemotingClient objWsLogin = new EhrWSRemotingClient("EhrWSRemotingPort", ELGAUrl);
                xdsQArgsDocument qArgs = new xdsQArgsDocument();

                if (parsIn.sObjectDto.SozVersNrLocalPatID.Trim() == "")
                {
                    throw new Exception("ELGABAL.deprecateDocument: parsIn.sObjectDto.SozVersNrLocalPatID='' not allowed!");
                }
                ehrPatientClientDto ehrPatientClientDtoBack = null;
                this.queryPatients(ref parsIn, eTypeQueryPatients.LocalID, ref ehrPatientClientDtoBack, true, authUniversalID, ELGAUrl);

                submissionSetClientDto submissionSet2 = new submissionSetClientDto();
                ehrPIDClientDto ehrXdsPatientPid = null;
                foreach (ehrPIDClientDto pid in ehrPatientClientDtoBack.pid)
                {
                    if ((pid.ehrPIDType & 16) == 16)
                    {
                        ehrXdsPatientPid = pid;        // CommunityID - Extract the current PID as LocalXdsPid
                        break;
                    }
                }
                if (ehrXdsPatientPid == null)
                {
                    foreach (ehrPIDClientDto pid in ehrPatientClientDtoBack.pid)
                    {
                        if ((pid.ehrPIDType & 8) == 8)
                        {
                            ehrXdsPatientPid = pid;
                            break;
                        }
                    }
                }

                if (ehrXdsPatientPid == null)
                {
                    throw new Exception("ELGABAL.deprecateDocument: xdsPatientPid == null not allowed!");
                }

                String xdsPatientPid = ehrXdsPatientPid.patientID + "^^^&" + ehrXdsPatientPid.domain.authUniversalID + "&" + ehrXdsPatientPid.domain.authUniversalIDType;    // Build the HL7 format (PatientID^^^&AuthUniversalID&AuthUniversalIDType)

                submissionSet2.patientId = xdsPatientPid;

                authorMetadataClientDto submissionSetAuthorMetadata = new authorMetadataClientDto();
                string[] arrInst = new string[1] { "" + parsIn.DocumentAdd.KlinikName.Trim() + "^^^^^^^^^" + "urn:oid:" + parsIn.DocumentAdd.KlinikOrganisationID.Trim() + "" };
                submissionSetAuthorMetadata.institution = arrInst;
                
                //submissionSetAuthorMetadata.person = parsIn.DocumentAdd.Author.Trim();
                authorMetadataClientDto[] arrSubmissionSetAuthorMetadata = new authorMetadataClientDto[1] { submissionSetAuthorMetadata };
                submissionSet2.author = arrSubmissionSetAuthorMetadata;
                //submissionSet2.name = parsIn.DocumentAdd.Documentname.Trim();
                //submissionSet2.description = parsIn.DocumentAdd.Description.Trim();


                iheClassificationClientDto contentTypeCode2 = new iheClassificationClientDto();
                contentTypeCode2.nodeRepresentation = "28651-8";
                contentTypeCode2.value = "Pflegesituationsbericht";
                string[] arrSchema_contentTypeCode2 = new string[1] { "2.16.840.1.113883.6.1" };
                contentTypeCode2.schema = arrSchema_contentTypeCode2;
                submissionSet2.contentTypeCode = contentTypeCode2;

                submissionSetClientDto submissionSetTmp = new submissionSetClientDto();
                documentClientDto documentClientDtoBack = null;
                this.queryPatientContent(ref parsIn, true, parsIn.sDocumentsDto.UniqueID.Trim(), ref documentClientDtoBack, ref submissionSetTmp, authUniversalID, ELGAUrl);

                xdsSrcDeprecateReq xdsSrcDeprecateReq1 = new xdsSrcDeprecateReq();
                xdsSrcDeprecateReq1.document = documentClientDtoBack;
                xdsSrcDeprecateReq1.stateID = parsIn.session.ELGAStateID;
                xdsSrcDeprecateReq1.patient = ehrPatientClientDtoBack;
                xdsSrcDeprecateReq1.submission = submissionSet2;

                xdsSrcSubmitRsp xdsSrcSubmitRsp1 = objWsLogin.deprecate(xdsSrcDeprecateReq1);
                if (xdsSrcSubmitRsp1.responseDetail.listError == null || xdsSrcSubmitRsp1.responseDetail.listError.Count() == 0)
                {
                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    this.getErrosElgaFct(xdsSrcSubmitRsp1.responseDetail.listError, ref retDto);
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.deprecateDocument: " + ex.ToString());
            }
        }




        public void setELGAPatients(ehrPatientClientDto elgaPatient, ELGASessionDTO session, ELGAParOutDto retDto)
        {
            try
            {
                ELGAPatientDTO newELGAPatients = this.newRowELGAPatients(retDto.lPatients);

                newELGAPatients.familyName = this.checkFieldNull(elgaPatient.familyName);
                newELGAPatients.givenName = this.checkFieldNull(elgaPatient.givenName);
                newELGAPatients.middleName = this.checkFieldNull(elgaPatient.middleName);
                newELGAPatients.birthdate = this.checkFieldNull(elgaPatient.birthdate);
                newELGAPatients.zip = this.checkFieldNull(elgaPatient.zip);
                newELGAPatients.state = this.checkFieldNull(elgaPatient.state);
                newELGAPatients.streetAddress = this.checkFieldNull(elgaPatient.streetAddress);
                newELGAPatients.country = this.checkFieldNull(elgaPatient.country);
                newELGAPatients.nationality = this.checkFieldNull(elgaPatient.nationality);
                newELGAPatients.sex = this.checkFieldNull(elgaPatient.sex);
                newELGAPatients.citizenship = this.checkFieldNull(elgaPatient.citizenship);
                newELGAPatients.city = this.checkFieldNull(elgaPatient.city);
                newELGAPatients.deathdate = this.checkFieldNull(elgaPatient.deathdate);
                newELGAPatients.emailHome = this.checkFieldNull(elgaPatient.emailHome);
                newELGAPatients.emailBusiness = this.checkFieldNull(elgaPatient.emailBusiness);
                newELGAPatients.ethnicGroup = this.checkFieldNull(elgaPatient.ethnicGroup);
                newELGAPatients.homePhone = this.checkFieldNull(elgaPatient.homePhone);
                newELGAPatients.businessPhone = this.checkFieldNull(elgaPatient.businessPhone);
                newELGAPatients.degree = this.checkFieldNull(elgaPatient.degree);
                newELGAPatients.maritalStatus = this.checkFieldNull(elgaPatient.maritalStatus);
                newELGAPatients.secondFamilyName = this.checkFieldNull(elgaPatient.secondFamilyName);
                newELGAPatients.secondGivenName = this.checkFieldNull(elgaPatient.secondGivenName);
                newELGAPatients.secondMiddleName = this.checkFieldNull(elgaPatient.secondMiddleName);
                newELGAPatients.nameTypeCode = this.checkFieldNull(elgaPatient.nameTypeCode);
                newELGAPatients.lastUpdtateTimeSpecified = elgaPatient.lastUpdtateTimeSpecified;
                newELGAPatients.lastUpdtateTime = elgaPatient.lastUpdtateTime;
                
                foreach (ehrPIDClientDto ehrPID in elgaPatient.pid)
                {
                    ELGAPidsDTO newELGAPids = this.newRowELGAPids(newELGAPatients, newELGAPatients.ID);
                    newELGAPids.patientID = this.checkFieldNull(ehrPID.patientID);
                    newELGAPids.ehrPIDType = ehrPID.ehrPIDType;
                    newELGAPids.patientIDType = this.checkFieldNull(ehrPID.patientIDType);

                    if (ehrPID.domain != null)
                    {
                        newELGAPids.authUniversalID = this.checkFieldNull(ehrPID.domain.authUniversalID);
                    }
                }

                ELGAChache elgaChache = new ELGAChache();
                elgaChache.addPatientToChache(newELGAPatients.ID, session, elgaPatient);
                retDto.iRowsFound += 1;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.setELGAPatients: " + ex.ToString());
            }
        }
        public ELGAParOutDto setELGADocu(ref ehrXdsQRsp ehrXdsQRsp1, ref ELGAParInDto parsIn, ref ELGAParOutDto retDto, ref documentClientDto documentClientDtoBack, bool OneDocuMustFound, string UniqueId,
                                         ref submissionSetClientDto submissionSet)
        {
            try
            {
                if (ehrXdsQRsp1.partialErros == null)
                {
                    if (ehrXdsQRsp1.responseData != null)
                    {
                        patientContentClientDto patientContentClientDto1 = ehrXdsQRsp1.responseData;
                        if (patientContentClientDto1.documents != null)
                        {
                            foreach (documentClientDto documentClientDto1 in patientContentClientDto1.documents)
                            {
                                bool AddDocu = false;
                                if (OneDocuMustFound)
                                {
                                    //Hier wird die Unique-ID des Documents von ELGA mit der internen GUID des lokalen CDAs verglichen -> Funktioniert nicht
                                    if (documentClientDto1.uniqueId.Trim().ToLower().Equals(UniqueId.Trim().ToLower()))  
                                    {
                                        AddDocu = true;
                                    }
                                }
                                else
                                {
                                    AddDocu = true;
                                }

                                bool TypeOK = false;
                                string sTypeFileSave = "";
                                string sTypeFileELGA = this.checkFieldNull(documentClientDto1.mimeType);
                                if (sTypeFileELGA.Trim().ToLower().Contains(("xml").Trim().ToLower()))
                                {
                                    sTypeFileSave = ".xml";
                                    TypeOK = true;
                                }

                                if (AddDocu && TypeOK)
                                {
                                    ELGADocumentsDTO newELGADocuments = this.initDocu();
                                    retDto.lDocuments.Add(newELGADocuments);

                                    newELGADocuments.UUID = this.checkFieldNull(documentClientDto1.UUID);
                                    newELGADocuments.UniqueId = this.checkFieldNull(documentClientDto1.uniqueId);
                                    newELGADocuments.LogicalId = this.checkFieldNull(documentClientDto1.logicalId);
                                    newELGADocuments.Documentname = this.checkFieldNull(documentClientDto1.name);
                                    newELGADocuments.TypeFile = sTypeFileSave.Trim();                   //this.checkFieldNull(documentClientDto1.mimeType);
                                    if (documentClientDto1.author.Count() > 0)
                                    {
                                        newELGADocuments.Author = this.checkFieldNull(documentClientDto1.author[0].institution[0]).Split(new char[] { '^' })[0] + " - " + this.checkFieldNull(documentClientDto1.author[0].person);
                                    }
                                    newELGADocuments.Description = this.checkFieldNull(documentClientDto1.description);
                                    newELGADocuments.DocStatus = this.checkFieldNull(documentClientDto1.docStatus);
                                    newELGADocuments.Version = this.checkFieldNull(documentClientDto1.version);
                                    newELGADocuments.Size = documentClientDto1.size;
                                    if (documentClientDto1.creationTime != null && documentClientDto1.creationTime.Trim() != "")
                                    {
                                        DateTime dtCreationTime = DateTime.ParseExact(documentClientDto1.creationTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                        newELGADocuments.CreationTime = dtCreationTime.ToString("dd.MM.yyyy HH:mm:ss");
                                    }

                                    foreach (string referenceId in documentClientDto1.referenceIdList)
                                    {
                                        newELGADocuments.ReferenceIdList.Add(referenceId);
                                    }

                                    submissionSet = documentClientDto1.submissionSet;

                                    //ELGAChache elgaChache = new ELGAChache();
                                    //elgaChache.addDocuToChache(parsIn.IDDocuIntern, parsIn.session, documentClientDto1);
                                    retDto.iRowsFound += 1;

                                    documentClientDtoBack = documentClientDto1;

                                    //docStatus bei Suche Dokumente:
                                    //      urn:oasis: names: tc: ebxml - regrep:StatusType: Approved >> Gültige Version
                                    //      urn:oasis: names: tc: ebxml - regrep:StatusType: Deprecated >> Alte Dokumentenversion

                                    // documentClientDto1.referenceIdList > Eindeutige Set-IDDocument (Liefert alle Versionen für Document, die MUSS beim generieren von CDA Dokumenten ausgefüllt werden und 
                                    //                                      hier somit direkt über den XML-Stream wieder gefunden werden)
                                    //                                      Bsp CDAKey: 2ff0849e-ddb4-4562-b1d7-20adcb22b4fc^^^&&ISO^urn:elga:iti:xds:2014:ownDocument_setId^&1.3.6.1.4.1.48288.2.990.2.1.1.21&ISO
                                }
                            }
                        }
                    }
                    else
                    {
                        bool bNoDataFound = true;
                    }

                    if (OneDocuMustFound)
                    {
                        if (retDto.iRowsFound != 1)
                        {
                            throw new Exception("ELGABAL.setELGADocu: retDto.iRowsFound <> 1 for Document.UniqueID '" + parsIn.sDocumentsDto.UniqueID.Trim() + "'!");
                        }
                    }

                    retDto.bOK = true;
                    return retDto;
                }
                else
                {
                    foreach (xdsQPartialError errDocument in ehrXdsQRsp1.partialErros)
                    {
                        retDto.Errors += "errorCode: " + errDocument.errorCode + "\r\n";
                    }
                    retDto.bErrorsFound = true;
                    return retDto;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.setELGADocu: " + ex.ToString());
            }
        }
        public void setIheClassificationForDocument(ref documentClientDto submittingDocument, ref submissionSetClientDto submissionSet)
        {
            try
            {
                // Value Sets
                iheClassificationClientDto formatCode = new iheClassificationClientDto();
                formatCode.nodeRepresentation = "urn:elga:nurse-tf:2015-v2.06:EIS_FullSupport";
                formatCode.value = "ELGA Pflegesituationsbericht, EIS Full Support v2.06";
                string[] arrSchema_formatCode = new string[1] { "1.2.40.0.34.5.37" };
                formatCode.schema = arrSchema_formatCode;
                submittingDocument.formatCode = formatCode;

                iheClassificationClientDto contentTypeCode2 = new iheClassificationClientDto();
                contentTypeCode2.nodeRepresentation = "28651-8";
                contentTypeCode2.value = "Pflegesituationsbericht";
                string[] arrSchema_contentTypeCode2 = new string[1] { "2.16.840.1.113883.6.1" };
                contentTypeCode2.schema = arrSchema_contentTypeCode2;
                submissionSet.contentTypeCode = contentTypeCode2;

                iheClassificationClientDto classCode = new iheClassificationClientDto();
                classCode.nodeRepresentation = "18842-5";
                classCode.value = "Entlassungsbrief";
                string[] arrSchema_classCode = new string[1] { "2.16.840.1.113883.6.1" };
                classCode.schema = arrSchema_classCode;
                submittingDocument.classCode = classCode;

                iheClassificationClientDto typeCode = new iheClassificationClientDto();
                typeCode.nodeRepresentation = "60591-5";
                typeCode.value = "Patient Summary";
                string[] arrSchema_typeCode = new string[1] { "2.16.840.1.113883.6.1" };
                typeCode.schema = arrSchema_typeCode;
                submittingDocument.typeCode = typeCode;

                iheClassificationClientDto confidentialityCode = new iheClassificationClientDto();
                confidentialityCode.nodeRepresentation = "N";
                confidentialityCode.value = "Normal";
                string[] arrSchema_confidentialityCode = new string[1] { "confidentialityCodes" };
                confidentialityCode.schema = arrSchema_confidentialityCode;
                iheClassificationClientDto[] arrConfidentialityCode = new iheClassificationClientDto[1] { confidentialityCode };
                submittingDocument.confidentialityCode = arrConfidentialityCode;

                iheClassificationClientDto healthcareFacilityCode = new iheClassificationClientDto();
                healthcareFacilityCode.nodeRepresentation = "305";
                healthcareFacilityCode.value = "Pflegeeinrichtung";
                string[] arrSchema_healthcareFacilityCode = new string[1] { "1.2.40.0.34.5.2" };
                healthcareFacilityCode.schema = arrSchema_healthcareFacilityCode;
                submittingDocument.healthcareFacilityCode = healthcareFacilityCode;

                iheClassificationClientDto practiceSettingCode = new iheClassificationClientDto();
                practiceSettingCode.nodeRepresentation = "F057";
                practiceSettingCode.value = "Gesundheits- und Krankenpflege";
                string[] arrSchema_practiceSettingCode = new string[1] { "1.2.40.0.34.5.12" };
                practiceSettingCode.schema = arrSchema_practiceSettingCode;
                submittingDocument.practiceSettingCode = practiceSettingCode;

                //iheClassificationClientDto eventCode = new iheClassificationClientDto();
                //eventCode.nodeRepresentation = "1.2.3.4.5.6";
                //eventCode.value = "CustomEvent";
                //string[] arrSchema_eventCode = new string[1] { "XDS Affinity Domain specific codeschema" };
                //eventCode.schema = arrSchema_eventCode;
                //iheClassificationClientDto[] arrEventCode = new iheClassificationClientDto[1] { eventCode };
                //submittingDocument.eventCode = arrEventCode;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.setIheClassificationForDocument: " + ex.ToString());
            }
        }
        public ELGAParOutDto initParOut()
        {
            try
            {
                ELGAParOutDto retDto = new ELGAParOutDto() { bOK = false, bErrorsFound = false, iRowsFound = 0, lPatients = new List<ELGAPatientDTO>(), lGDAs = new List<ObjectDTO>(), lstErrors = new List<ELGAErrorDTO>() };
                return retDto;
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.initParOut: " + ex.ToString());
            }
        }
        public ELGADocumentsDTO initDocu()
        {
            try
            {
                ELGADocumentsDTO newELGADocuments = new ELGADocumentsDTO() { Documentname = "", Author = "", Description = "", DocStatus = "", UUID = "", Version = "", LogicalId = "", 
                                                                            UniqueId = "", CreationTime = "", Size = 0, TypeFile = "", ReferenceIdList = new List<string>() };
                return newELGADocuments;
            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.ínitDocu: " + ex.ToString());
            }
        }
        public void getELGAErrors2(ehrPatientRsp ehrPatientRsp1, ref ELGAParOutDto retDto)
        {
            try
            {
                if (ehrPatientRsp1.queryError.acknowledgementDetail.Length == 0)
                {
                    throw new Exception("ELGABAL.getELGAErrors: ehrPatientRsp1.queryError.acknowledgementDetail.Length=0 not allowed!");
                }

                foreach (acknowledgementDetail errDetail in ehrPatientRsp1.queryError.acknowledgementDetail)
                {
                    ELGAErrorDTO ELGAError = new ELGAErrorDTO();
                    ELGAError.errTxt = this.checkFieldNull(errDetail.text);
                    ELGAError.code = this.checkFieldNull(errDetail.code);
                    ELGAError.location = this.checkFieldNull(errDetail.location);
                    ELGAError.typeCode = this.checkFieldNull(errDetail.typeCode);
                    ELGAError.classCode = this.checkFieldNull(ehrPatientRsp1.queryError.classCode);
                    ELGAError.moodCode = this.checkFieldNull(ehrPatientRsp1.queryError.moodCode);
                    ELGAError.QueryResponseCode = this.checkFieldNull(ehrPatientRsp1.queryError.queryResponseCode);

                    retDto.lstErrors.Add(ELGAError);
                }

                retDto.bErrorsFound = true;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.getELGAErrors2: " + ex.ToString());
            }
        }
        public void getErrosElgaFct(string[] lstErrors, ref ELGAParOutDto retDto)
        {
            try
            {
                foreach (string sError in lstErrors)
                {
                    retDto.Errors += "Error: " + sError + "\r\n";
                }
                retDto.bErrorsFound = true;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.getErrosElgaFct: " + ex.ToString());
            }
        }

        public ELGAPatientDTO newRowELGAPatients(List<ELGAPatientDTO> t)
        {
            try
            {
                ELGAPatientDTO newElgaPat = new ELGAPatientDTO()
                {
                    ID = System.Guid.NewGuid(),
                    IDPatientDB = null,
                    familyName = "",
                    givenName = "",
                    middleName = "",
                    birthdate = null,
                    zip = "",
                    state = "",
                    streetAddress = "",
                    country = "",
                    nationality = "",
                    sex = "",
                    citizenship = "",
                    city = "",
                    deathdate = "",
                    emailHome = "",
                    emailBusiness = "",
                    ethnicGroup = "",
                    homePhone = "",
                    businessPhone = "",
                    degree = "",
                    maritalStatus = "",
                    secondFamilyName = "",
                    secondGivenName = "",
                    secondMiddleName = "",
                    nameTypeCode = "",
                    lastUpdtateTimeSpecified = false,
                    lastUpdtateTime = null
                };
                if (t == null)
                    t = new List<ELGAPatientDTO>();
                t.Add(newElgaPat);
                return newElgaPat;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.newRowELGAPatients: " + ex.ToString());
            }
        }
        public ELGAPidsDTO newRowELGAPids(ELGAPatientDTO pat, Guid IDELGAPatients)
        {
            try
            {
                ELGAPidsDTO newELGAPids = new ELGAPidsDTO() { ID = System.Guid.NewGuid(), patientID = "", ehrPIDType = -1, patientIDType = "" , authUniversalID = ""};
                if (pat.ELGAPids == null)
                    pat.ELGAPids = new List<ELGAPidsDTO>();
                pat.ELGAPids.Add(newELGAPids);
                return newELGAPids;

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.newRowELGAPids: " + ex.ToString());
            }
        }
        public string checkFieldNull(object oValueField)
        {
            try
            {
                if (oValueField == null)
                {
                    return "";
                }
                else
                {
                    return oValueField.ToString().Trim();

                    //if (oValueField.GetType().Equals(typeof(string)))
                    //{
                    //    return oValueField.ToString().Trim();
                    //}
                    //else if (oValueField.GetType().Equals(typeof(DateTime)))
                    //{
                    //    return System.Convert.ToDateTime(oValueField.ToString().Trim());
                    //}
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGABAL.checkFieldNull: " + ex.ToString());
            }
        }
    }
}

