﻿using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;
using PMDS.Global.db.ERSystem;
using Patagames.Pdf.Net;
using Patagames.Pdf.Enums;
using System.Threading;
using PMDS.DB;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using QS2.Desktop.ControlManagment.ServiceReference_01;

namespace PMDS.DB
{
    
    public class PMDSBusinessComm
    {
        
        public static string uniqueIDMachine = "";
        public static Guid IDMachinesProtocoll = new Guid("00000001-0045-0000-0000-000000001111");

        public static bool threadsRunning = false;


        public enum eClientsMessage
        {
            MessageToAllClients = 0,

        }
        public enum eTypeMessage
        {
            ReloadRAMAll = 0,
            none = 1000
        }
        
        public static Thread threadLoadData = null;
        public static bool closeAllThreads = false;











        public bool startThreadCheckingData()
        {
            try
            {
                if (ENV.AsynCommCheckMessagesSeconds > 0 )
                {
                    PMDSBusinessComm.threadLoadData = new Thread(new ParameterizedThreadStart(this.threadCheckLoadingData));
                    object objThread = new object();
                    objThread = 0;
                    PMDSBusinessComm.threadLoadData.Start(objThread);
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.startThreadCheckingData: " + ex.ToString());
            }
        }
        public void threadCheckLoadingData(object obj)
        {
            int iFctCalled = (int)obj;
            try
            {
                DateTime lastStart = DateTime.Now;
                bool bEnd = false;
                while (!bEnd)
                {
                    try
                    {
                        System.TimeSpan datDiff = DateTime.Now - lastStart;
                        if (datDiff.TotalSeconds > ENV.AsynCommCheckMessagesSeconds)
                        {
                            PMDSBusinessComm.checkMessageForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);
                            Thread.Sleep(200);
                            PMDSBusinessComm.checkMessageForClient2();
                            lastStart = DateTime.Now;
                        }
                        Thread.Sleep(100);     //Thread.Sleep(5000);
                        if (PMDS.DB.PMDSBusinessComm.closeAllThreads)
                        {
                            bEnd = true;
                            //Thread.CurrentThread.Abort();
                        }
                              
                    }
                    catch (Exception ex3)
                    {
                        if ((PMDS.Global.ENV.checkExceptionPhysischeVerbindung(ex3.ToString()) || PMDS.Global.ENV.checkExceptionAbfragetimeout(ex3.ToString())) && iFctCalled < 4)
                        {
                            string sExcept = ex3.ToString();
                        }
                        else
                        {
                            string sExcept = "PMDSBusinessComm.threadCheckLoadingData - while: " + ex3.ToString();
                            throw new Exception(sExcept);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusinessComm.closeAllThreads)
                {
                    string sExcept = "PMDSBusinessComm.threadCheckLoadingData: " + "\r\n" + ex.ToString();
                    PMDS.Global.ENV.HandleException(new Exception(sExcept), "", false, false);
                    //Thread.CurrentThread.Abort();
                    //Thread.CurrentThread.Abort();
                }
                else
                {
                    string sExcept = "PMDSBusinessComm.threadCheckLoadingData: " + "\r\n" + ex.ToString();
                    PMDS.Global.ENV.HandleException(new Exception(sExcept), "", false, false);
                }
            }
        }



        public static void setUniqueIDMachine()
        {
            try
            {
                var macAddr =
                    (
                        from nic in NetworkInterface.GetAllNetworkInterfaces()
                        where nic.OperationalStatus == OperationalStatus.Up
                        select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();

                //if (macAddr == null || macAddr.ToString() == "")
                //{
                //    throw new Exception("PMDSBusinessComm.setUniqueIDMachine: macAddr is null or '' not allowed!");
                //}
                //os, 2018-06-13: Natürlich ist macAddr == "" erlaubt (wenn es keine Netzwerkverbindung gibt, ist das ein korrekter Zustand)
                if (macAddr == null || macAddr.ToString() == "")
                    macAddr = "not detected";

                if (Environment.MachineName == null || Environment.MachineName.Trim() == "")
                {
                    throw new Exception("PMDSBusinessComm.setUniqueIDMachine: Environment.MachineName is null or '' not allowed!");
                }

                PMDSBusinessComm.uniqueIDMachine = "__________" + Environment.MachineName.Trim() + "_" + PMDSBusinessComm.GetLocalIPAddress() + "_" + macAddr.ToString() + "__________";

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.loadDataStart: " + ex.ToString());
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("PMDSBusinessComm.GetLocalIPAddress: No network adapters with an IPv4 address in the system!");
        }
        public static void registerClient(string uniqueIDMachine)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                //{
                qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                sqlProtocoll.initControl();
                string CmdReturn = "";
                sqlProtocoll.getProtocol(PMDSBusinessComm.IDMachinesProtocoll, ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                qs2.core.vb.dsProtocol.ProtocolRow rNewProt = null;
                if (dsProtocol1.Protocol.Rows.Count == 0)
                {
                    rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                    rNewProt.IDGuid = PMDSBusinessComm.IDMachinesProtocoll;
                    rNewProt.Type = "AllMachines";
                    rNewProt.IDApplication = "PMDS";
                    rNewProt.Info = "";
                    rNewProt.Protocol = "";
                    rNewProt.Created = dNow;
                    rNewProt.CreatedDay = dNow.Date;
                    rNewProt.User = "System";

                    sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);
                }
                else if (dsProtocol1.Protocol.Rows.Count == 1)
                {
                    rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)dsProtocol1.Protocol.Rows[0];
                }
                else if (dsProtocol1.Protocol.Rows.Count > 1)
                {
                    throw new Exception("PMDSBusinessComm.registerClients: dsProtocol1.Protocol.Rows.Count > 1 not allowed!");
                }

                if (!rNewProt.Info.Contains(uniqueIDMachine.Trim()))
                {
                    rNewProt.Info += uniqueIDMachine.Trim();
                    sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);
                }
                //}

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw new System.Data.Entity.Validation.DbEntityValidationException(PMDS.DB.PMDSBusiness.getDbEntityValidationException2(ex, "PMDSBusinessRAM.registerClients()"));
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.registerClients: " + ex.ToString());
            }
        }
        public static void newMessageToClients(eClientsMessage ClientsMessage, eTypeMessage TypeMessage,  PMDS.db.Entities.ERModellPMDSEntities db, Nullable<Guid> FromIDUser = null,
                                                List<Guid> lstToUsers = null, string Title = "", string Message = "", Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                DateTime dNow = DateTime.Now;

                string CmdReturn = "";
                qs2.core.vb.dsProtocol dsProtocol1 = new qs2.core.vb.dsProtocol();
                qs2.core.vb.sqlProtocoll sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                sqlProtocoll.initControl();
                sqlProtocoll.getProtocol(PMDSBusinessComm.IDMachinesProtocoll, ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);
                if (dsProtocol1.Protocol.Rows.Count != 1)
                {
                    throw new Exception("PMDSBusinessComm.registerClients: dsProtocol1.Protocol.Rows.Count != 1 not allowed!");
                }
                qs2.core.vb.dsProtocol.ProtocolRow rProtAllMachines = (qs2.core.vb.dsProtocol.ProtocolRow)dsProtocol1.Protocol.Rows[0];
                string AllMachines = rProtAllMachines.Info.Trim();

                CmdReturn = "";
                dsProtocol1 = new qs2.core.vb.dsProtocol();
                sqlProtocoll = new qs2.core.vb.sqlProtocoll();
                sqlProtocoll.getProtocol(System.Guid.NewGuid(), ref dsProtocol1, qs2.core.vb.sqlProtocoll.eSelProtocoll.ID, "", System.Guid.NewGuid(), -1, "", "", null, null, "", ref CmdReturn);

                qs2.core.vb.dsProtocol.ProtocolRow rNewProt = (qs2.core.vb.dsProtocol.ProtocolRow)sqlProtocoll.newProtocol(ref dsProtocol1);
                rNewProt.IDGuid = System.Guid.NewGuid();
                rNewProt.Type = ClientsMessage.ToString();
                rNewProt.IDApplication = "PMDS";
                rNewProt.Info = AllMachines.Trim();
                rNewProt.sKey = TypeMessage.ToString();
                rNewProt.Created = dNow;
                rNewProt.CreatedDay = dNow.Date;
                rNewProt.User = "System";

                sqlProtocoll.daProtocol.Update(dsProtocol1.Protocol);

                DateTime dDat = DateTime.Now.AddMonths(-1).Date;
                string strSQlUpdate = "delete from qs2.Protocol where CreatedDay<=@CreatedDay and Type='" + ClientsMessage.ToString() + "'";
                System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand();
                cmdUpdate.CommandText = strSQlUpdate;
                cmdUpdate.Parameters.AddWithValue("@CreatedDay", dDat);
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdUpdate.Connection = RBU.DataBase.CONNECTIONSqlClient;
                cmdUpdate.CommandTimeout = 0;

                cmdUpdate.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusinessComm.newMessageToClients"))
                {
                    PMDSBusinessComm.newMessageToClients(ClientsMessage, TypeMessage, db, FromIDUser, lstToUsers, Title, Message, IDTime);
                }
                throw new Exception("PMDSBusinessComm.newMessageToClients: " + ex.ToString());
            }
        }
        public static void newMessageToClients2(eClientsMessage ClientsMessage, PMDS.db.Entities.ERModellPMDSEntities db, Nullable<Guid> FromIDUser = null,
                                            List<Guid> lstToUsers = null, string Title = "", string Message = "", Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                DateTime dNow = DateTime.Now;
                var rUserFrom = (from b in db.Benutzer
                                    where b.ID == FromIDUser.Value
                                    select new
                                    {
                                        IDBenutzer = b.ID,
                                        Benutzer = b.Benutzer1

                                    }).First();

                PMDSClient.Sitemap.WCFServiceClient wcf = new PMDSClient.Sitemap.WCFServiceClient();
                MessagesDTO1 lM = wcf.addMessage(rUserFrom.IDBenutzer, rUserFrom.Benutzer.Trim(), Title.Trim(), Message.Trim(), ClientsMessage.ToString(), "Message", lstToUsers.ToArray());

            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusinessComm.newMessageToClients2"))
                {
                    PMDSBusinessComm.newMessageToClients2(ClientsMessage, db, FromIDUser, lstToUsers, Title, Message, IDTime);
                }
                throw new Exception("PMDSBusinessComm.newMessageToClients2: " + ex.ToString());
            }
        }

        public static bool checkMessageForClient(eClientsMessage ClientsMessage, eTypeMessage TypeMessage)
        {
            try
            {
                DateTime dSince = DateTime.Now.AddDays(-14).Date;
                string strSQl = "";

                strSQl = "Select IDGuid, [Type], Info, progress, sKey, Created from qs2.Protocol where Type='" + ClientsMessage.ToString() + "' and sKey='" + TypeMessage.ToString() + "' and " +
                                "CreatedDay>=@CreatedDay and Info like '%" + PMDSBusinessComm.uniqueIDMachine.Trim() + "%' and (progress not like '%" + PMDSBusinessComm.uniqueIDMachine.Trim() + "%')";

                dsKlientenliste dsKlientenliste1 = new dsKlientenliste();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                cmd.CommandText = strSQl;
                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmd.Connection = RBU.DataBase.CONNECTIONSqlClient;
                cmd.CommandTimeout = 0;
                cmd.CommandTimeout = 0;
                da.SelectCommand = cmd;
                da.SelectCommand.Parameters.AddWithValue("@CreatedDay", dSince);
                da.Fill(dsKlientenliste1.tProtocol);

                if (dsKlientenliste1.tProtocol.Rows.Count > 0)
                {
                    eTypeMessage TypeMessageAction = eTypeMessage.none;
                    foreach (dsKlientenliste.tProtocolRow rProt in dsKlientenliste1.tProtocol)
                    {
                        TypeMessageAction = (eTypeMessage)PMDSBusinessComm.getEnumTypeMessage(rProt.sKey.Trim());
                        if (TypeMessageAction == eTypeMessage.ReloadRAMAll)
                        {
                            rProt.progress += PMDSBusinessComm.uniqueIDMachine.Trim();

                            string strSQlUpdate = "Update qs2.Protocol set progress = '" + rProt.progress + "' where IDGuid='" + rProt.IDGuid.ToString() + "'";
                            System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand();
                            cmdUpdate.CommandText = strSQlUpdate;
                            if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                                RBU.DataBase.CONNECTION.Open();
                            cmdUpdate.Connection = RBU.DataBase.CONNECTIONSqlClient;
                            cmdUpdate.CommandTimeout = 0;

                            cmdUpdate.ExecuteNonQuery();
                        }
                    }

                    if (TypeMessageAction == eTypeMessage.ReloadRAMAll)
                    {
                        PMDSBusinessRAM bRAm = new PMDSBusinessRAM();
                        bRAm.loadDataStart(false, true, true, false);
                    }
                    else
                    {
                        throw new Exception("PMDSBusinessComm.checkMessageForClient: TypeMessageAction - no action defined for TypeMessageAction '" + TypeMessageAction.ToString() + "'!");
                    }

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.checkMessageForClient: " + ex.ToString());
            }
        }
        public static bool checkMessageForClient2()
        {
            try
            {
                DateTime dSince = DateTime.Now.AddDays(-14).Date;

                //dsManage dsManage1 = new dsManage();
                //sqlManange sqlManange1 = new sqlManange();
                //sqlManange1.initControl();
                //sqlManange1.getMessage2(dsManage1, System.Guid.NewGuid(), sqlManange.eTypeMessages.MessagesUnreaded, ClientsMessage.ToString(), TypeMessage.ToString());

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tMUnreaded2 = from m in db.Messages
                                 join mu in (from o in db.MessagesToUsers
                                               where !o.Readed && o.IDUser == ENV.USERID
                                             select o)
                                    on m.ID equals mu.IDMessages
                                 select new { m.ID};

                    var tMU3 = tMUnreaded2.GroupBy(i => i.ID);

                    if (tMU3.Count() > 0)
                    {
                        eTypeMessage TypeMessageAction = eTypeMessage.none;
                        foreach (var rProt in tMU3)
                        {
                            //TypeMessageAction = (eTypeMessage)PMDSBusinessComm.getEnumTypeMessage(rProt.sKey.Trim());
                            //if (TypeMessageAction == eTypeMessage.ReloadRAMAll)
                            //{
                            //    rProt.Progress += PMDSBusinessComm.uniqueIDMachine.Trim();

                            //    //string strSQlUpdate = "Update dbo.Messages set Progress = '" + rProt.Progress + "' where ID='" + rProt.ID.ToString() + "'";
                            //    //System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand();
                            //    //cmdUpdate.CommandText = strSQlUpdate;
                            //    //if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                            //    //    RBU.DataBase.CONNECTION.Open();
                            //    //cmdUpdate.Connection = RBU.DataBase.CONNECTIONSqlClient;
                            //    //cmdUpdate.CommandTimeout = 0;

                            //    //cmdUpdate.ExecuteNonQuery();
                            //}
                        }

                        cParDelegSendMain ParDelegSendMain = new cParDelegSendMain();
                        ParDelegSendMain.foundUnreadedMessages = tMU3.Count();
                        ENV.SignalMainChanged(eSendMain.ShowMessagesUnread, ParDelegSendMain);

                        return true;
                    }
                    else
                    {
                        cParDelegSendMain ParDelegSendMain = new cParDelegSendMain();
                        ParDelegSendMain.foundUnreadedMessages = tMUnreaded2.Count();
                        ENV.SignalMainChanged(eSendMain.ShowMessagesUnread, ParDelegSendMain);

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.checkMessageForClient2: " + ex.ToString());
            }
        }

        public static int getEnumTypeMessage(string TypeToSearch)
        {
            try
            {
                foreach (int val in Enum.GetValues(typeof(eTypeMessage)))
                {
                    string sResTyp = Enum.GetName(typeof(eTypeMessage), val);
                    if (sResTyp.Trim().ToLower().Equals((TypeToSearch).Trim().ToLower()))
                    {
                        return val;
                    }
                }

                throw new Exception("PMDSBusinessComm.getEnumTypeMessage: TypeToSearch '" + TypeToSearch.ToString() + "' not found in Enum!");
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.getEnumTypeMessage: " + ex.ToString());
            }
        }

    }


}
