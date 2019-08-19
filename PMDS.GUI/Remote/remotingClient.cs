using PMDS.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.Global.Remote
{

    public class remotingClient
    {

        public static string Port = "";
        public static string objectURI = "";

        public static ICommunicationService.eTypeFct TypeFct;
        public static cParComm ParComm = null;
        public static cCallFctReturn CallFctReturn = null;

        public static IpcClientChannel IpcClientChannel1 = null;
        public static bool IpcClientChannelIsRegistered = false;


        public class cCallFctReturn
        {
            public bool bOK = false;
        }

        public static PMDS.GUI.Remote.frmMainFormIPCClient frmMainFormIPCClient1 = null;

        public static frmPatientRueckmeldungLine frmRueckmedlungLine = null;
        public static PMDS.GUI.GUI.Main.frmLoadingWait frmLoadingWait1 = null;








        public bool callFct(ICommunicationService.eTypeCallTo TypeCallTo, ICommunicationService.eTypeFct TypeFct, cParComm ParComm, ref cCallFctReturn CallFctReturn)
        {
            try
            {
                if (TypeCallTo == ICommunicationService.eTypeCallTo.MainPMDS)
                {
                    remotingClient.objectURI = remotingSrv.UriMainPMDS;
                    remotingClient.Port = remotingSrv.PortMainPMDS;
                }
                else if (TypeCallTo == ICommunicationService.eTypeCallTo.ClientPMDS)
                {
                    remotingClient.objectURI = remotingSrv.varsToCall.UriClientUIQS2;
                    remotingClient.Port = remotingSrv.varsToCall.PortClientUIQS2;
                }

                remotingClient.TypeFct = TypeFct;
                remotingClient.ParComm = ParComm;
                remotingClient.CallFctReturn = new cCallFctReturn();

                this.startcallFct();
                CallFctReturn = remotingClient.CallFctReturn;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("remotingClient.callFct: " + ex.ToString());
            }
        }

        public void startcallFct()
        {
            try
            {
                if (!remotingClient.IpcClientChannelIsRegistered)
                {
                    IpcChannel ipcCh = new IpcChannel("Client_" + remotingClient.Port);
                    ChannelServices.RegisterChannel(ipcCh);
                    remotingClient.IpcClientChannelIsRegistered = true;
                }

                ICommunicationService obj = (ICommunicationService)Activator.GetObject(typeof(ICommunicationService), "ipc://" + remotingClient.Port + "/" + remotingClient.objectURI + "");

                //if (!remotingClient.IpcClientChannelIsRegistered)
                //{
                //    remotingClient.IpcClientChannel1 = new IpcClientChannel();
                //    ChannelServices.RegisterChannel(remotingClient.IpcClientChannel1, true);
                //    remotingClient.IpcClientChannelIsRegistered = true;
                //}

                ////ICommunicationService obj = TryCast(Activator.GetObject(GetType(ICommunicationService), "ipc://" + objectURI.Trim() + "/" + Port.ToString().Trim() + ""), ICommunicationService)
                //string IPCToCall = "ipc://" + objectURI.Trim() + "/" + Port.ToString().Trim() + "";
                //remotingSrv.showMsgBoxTestmodus("Call '" + TypeFct.ToString() + "' to ipc channel '" + IPCToCall + "'!");
                //ICommunicationService obj = (ICommunicationService)Activator.GetObject(typeof(ICommunicationService), IPCToCall);


                if (TypeFct == ICommunicationService.eTypeFct.LogIn)
                {
                    remotingClient.CallFctReturn.bOK = obj.LogIn();
                }
                else if (TypeFct == ICommunicationService.eTypeFct.TestCallToClient)
                {
                    remotingClient.CallFctReturn.bOK = obj.TestCallToClient();
                }
                else if (TypeFct == ICommunicationService.eTypeFct.LogInFinished)
                {
                    remotingClient.CallFctReturn.bOK = obj.LogInFinished();
                }
                else if (TypeFct == ICommunicationService.eTypeFct.StartSchnellrückmeldung)
                {
                    remotingClient.CallFctReturn.bOK = obj.StartSchnellrückmeldung(ref remotingClient.ParComm.lstInterventionen, -1, -1, -1, -1);
                }
                else if (TypeFct == ICommunicationService.eTypeFct.RefreshInterventionen)
                {
                    remotingClient.CallFctReturn.bOK = obj.RefreshInterventionen();
                }
                else if (TypeFct == ICommunicationService.eTypeFct.CloseIPCClient)
                {
                    try
                    {
                        obj.CloseIPCClient();
                    }
                    catch (Exception ex66)
                    {
                        string sExcept = ex66.ToString();
                    }
                }
                else
                {
                    throw new Exception("remotingClient.startcallFct: TypeFct '" + TypeFct.ToString() + "' not defined!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("remotingClient.startcallFct: " + ex.ToString());
            }
        }

    }

}
