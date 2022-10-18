using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;

namespace PMDS.DB
{
    public class PMDSBusinessComm
    {
        public static string uniqueIDMachine = "";
        public static bool threadsRunning = false;
        public static Thread threadLoadData = null;
        public static bool closeAllThreads = false;

        public enum eClientsMessage
        {
            MessageToAllClients = 0,
        }

        public enum eTypeMessage
        {
            ReloadRAMAll = 0
        }
       
        public void startThreadCheckingData()
        {
            try
            {
                if (ENV.AsynCommCheckMessagesSeconds > 0 )
                {
                    PMDSBusinessComm.threadLoadData = new Thread(new ParameterizedThreadStart(this.threadCheckLoadingData));
                    object objThread = new object();
                    objThread = 0;
                    PMDSBusinessComm.threadLoadData.Start(objThread);
                }
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
                            PMDSBusinessComm.checkCommAsyncForClient(PMDSBusinessComm.eClientsMessage.MessageToAllClients, PMDSBusinessComm.eTypeMessage.ReloadRAMAll);
                            Thread.Sleep(800);
                            PMDSBusinessComm.checkMessageForClient2();
                            lastStart = DateTime.Now;
                        }
                        Thread.Sleep(10000);  
                        if (PMDS.DB.PMDSBusinessComm.closeAllThreads)
                        {
                            bEnd = true;
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
                string sExcept = "PMDSBusinessComm.threadCheckLoadingData: " + "\r\n" + ex.ToString();
                PMDS.Global.ENV.HandleException(new Exception(sExcept), "", false, false);
            }
        }

        public static void setUniqueIDMachine()
        {
            try
            {
                if (string.IsNullOrEmpty(Environment.MachineName))
                {
                    throw new Exception("PMDSBusinessComm.setUniqueIDMachine: Environment.MachineName is null or '' not allowed!");
                }

                var macAddr =
                    (
                        from nic in NetworkInterface.GetAllNetworkInterfaces()
                        where nic.OperationalStatus == OperationalStatus.Up
                        select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();

                if (string.IsNullOrEmpty(macAddr))
                    macAddr = "not detected";

                string LocalIPAdress = "";
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    LocalIPAdress = endPoint.Address.ToString();
                }
/*  Uses just first active IP-Address
                foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        LocalIPAdress = ip.ToString();
                    }
                }
*/
                PMDSBusinessComm.uniqueIDMachine = Environment.MachineName + "_" + LocalIPAdress + "_" + macAddr;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.loadDataStart: " + ex);
            }
        }

        public static void registerClient(string uniqueIDMachine)
        {
            try
            {

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

        public static void newCommAsyncToClients(eClientsMessage ClientsMessage, eTypeMessage TypeMessage,  PMDS.db.Entities.ERModellPMDSEntities db, Nullable<Guid> FromIDUser = null,
                                                List<Guid> lstToUsers = null, string Title = "", string Message = "", Nullable<DateTime> IDTimeRepeat = null)
        {
            Nullable<DateTime> IDTime = null;
            if (IDTimeRepeat != null)
            {
                IDTime = IDTimeRepeat;
            }
            try
            {
                CommAsync newComm = new CommAsync();
                newComm.ID = System.Guid.NewGuid();
                newComm.Info = "";
                newComm.UserFrom = "";
                newComm.UserFromID = ENV.USERID; 
                newComm.ClientsMessage = ClientsMessage.ToString();
                newComm.TypeMessage = TypeMessage.ToString();
                newComm.Created = DateTime.Now;
                newComm.CreatedDay = DateTime.Now.Date;

                db.CommAsync.Add(newComm);
                db.SaveChanges();

                DateTime dDat = DateTime.Now.AddDays(-5).Date;
                string strSQlUpdate = "DELETE FROM CommAsync WHERE CreatedDay <= @CreatedDay and ClientsMessage = @ClientMessage";
                System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand();
                cmdUpdate.CommandText = strSQlUpdate;
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@CreatedDay", SqlDbType = SqlDbType.Date, Value = dDat });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@ClientMessage", SqlDbType = SqlDbType.VarChar, Value = ClientsMessage.ToString() });

                if (RBU.DataBase.CONNECTION.State == ConnectionState.Closed)
                    RBU.DataBase.CONNECTION.Open();
                cmdUpdate.Connection = RBU.DataBase.CONNECTIONSqlClient;
                cmdUpdate.CommandTimeout = 0;
                cmdUpdate.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (PMDS.DB.PMDSBusiness.handleExceptionsServerNotReachable(ref IDTime, ex, "PMDSBusinessComm.newCommAsyncToClients"))
                {
                    PMDSBusinessComm.newCommAsyncToClients(ClientsMessage, TypeMessage, db, FromIDUser, lstToUsers, Title, Message, IDTime);
                }
                throw new Exception("PMDSBusinessComm.newCommAsyncToClients: " + ex.ToString());
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
                WCFServicePMDS.DAL.DTO.MessagesDTO lM = wcf.addMessage(rUserFrom.IDBenutzer, rUserFrom.Benutzer.Trim(), Title.Trim(), Message.Trim(), ClientsMessage.ToString(), "Message", lstToUsers);

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

        public static void checkCommAsyncForClient(eClientsMessage ClientsMessage, eTypeMessage TypeMessage)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    string sClientsMessage = ClientsMessage.ToString();
                    string sTypeMessage = TypeMessage.ToString();

                    var rComm = (from c in db.CommAsync
                        where c.ClientsMessage == sClientsMessage && c.TypeMessage == sTypeMessage
                        orderby c.Created descending
                        select new {c.ID}).FirstOrDefault();

                    if (rComm != null)
                    {
                        var rCommClients = (from cc in db.CommAsyncClients
                            where cc.IDCommAsync == rComm.ID &&
                                  cc.IDClient == PMDSBusinessComm.uniqueIDMachine.Trim() && cc.Done
                            select new
                                {cc.ID}).FirstOrDefault();
                        if (rCommClients == null)
                        {
                            CommAsyncClients newCommClients = new CommAsyncClients();
                            newCommClients.ID = System.Guid.NewGuid();
                            newCommClients.IDCommAsync = rComm.ID;
                            newCommClients.IDClient = PMDSBusinessComm.uniqueIDMachine.Trim();
                            newCommClients.Done = true;
                            newCommClients.DoneAt = DateTime.Now;
                            db.CommAsyncClients.Add(newCommClients);
                            db.SaveChanges();

                            if (TypeMessage == eTypeMessage.ReloadRAMAll)
                            {
                                PMDSBusinessRAM bRAm = new PMDSBusinessRAM();
                                bRAm.loadDataStart(false, true, true, false);
                            }
                            else
                            {
                                throw new Exception(
                                    "PMDSBusinessComm.checkCommAsyncForClient: TypeMessage - no action defined for TypeMessage '" +
                                    TypeMessage.ToString() + "'!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.checkCommAsyncForClient: " + ex.ToString());
            }
        }

        public static void checkMessageForClient2()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    var tMUnreaded2 = from m in db.Messages
                                 join mu in (from o in db.MessagesToUsers
                                               where !o.Readed && o.IDUser == ENV.USERID
                                             select o)
                                    on m.ID equals mu.IDMessages
                                 select new { m.ID};

                    var tMU3 = tMUnreaded2.GroupBy(i => i.ID);

                    if (tMU3.Any())
                    {
                        cParDelegSendMain ParDelegSendMain = new cParDelegSendMain();
                        ParDelegSendMain.foundUnreadedMessages = tMU3.Count();
                        ENV.SignalMainChanged(eSendMain.ShowMessagesUnread, ParDelegSendMain);
                    }
                    else
                    {
                        cParDelegSendMain ParDelegSendMain = new cParDelegSendMain();
                        ParDelegSendMain.foundUnreadedMessages = tMUnreaded2.Count();
                        ENV.SignalMainChanged(eSendMain.ShowMessagesUnread, ParDelegSendMain);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("PMDSBusinessComm.checkMessageForClient2: " + ex.ToString());
            }
        }
    }
}
