using PMDS.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.Global.Remote
{


    public class cParComm
    {
        public List<Guid> lstInterventionen = null;
    }

    public class SelfSponsor : ISponsor
    {
        public System.TimeSpan Renewal(ILease lease)
        {
            return lease.RenewOnCallTime;
        }
    }





    public class ICommunicationService: MarshalByRefObject
    {


        public enum eTypeFct
        {
            LogIn = 0,
            LogInFinished = 1,
            StartSchnellrückmeldung = 2,
            RefreshInterventionen = 3,
            TestCallToClient = 4,
            CloseIPCClient = 5
        }

        public enum eTypeCallTo
        {
            MainPMDS = 0,
            ClientPMDS = 1
        }

        


        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();

            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.InitialLeaseTime = TimeSpan.FromSeconds(25);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(25);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(20);
            }
            return lease;
        }


        //public void SponsorYourself()
        //{
        //    SelfSponsor Sponsor = new SelfSponsor();
        //    //DirectCast(GetLifetimeService(), ILease).Register(Sponsor);
        //}
        //public void UnSponsorYourself()
        //{
        //    //DirectCast(GetLifetimeService(), ILease).Unregister(Sponsor)
        //}
        



        public bool LogIn()
        {
            try
            {


                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ICommunicationService.LogIn: " + ex.ToString());
            }
        }
        public bool TestCallToClient()
        {
            try
            {
                remotingSrv.showMsgBoxTestmodus("Test-Call to client is sucessfull!");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ICommunicationService.TestCallToClient: " + ex.ToString());
            }
        }

        public bool LogInFinished()
        {
            try
            {
                remotingSrv.LoggedIn2 = true;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ICommunicationService.LogInFinished: " + ex.ToString());
            }
        }

        public bool StartSchnellrückmeldung(ref List<Guid> lstInverventionen, int MainWindowLeft, int MainWindowTop, int MainWindowWidth, int MainWindowHeight)
        {
            try
            {
                string txtinfo = "Client begins to start Schnellrückmeldung: List - Count interventionen: " + lstInverventionen.Count.ToString() + "";

                PMDSBusiness b = new PMDSBusiness();
                PMDS.Global.db.ERSystem.dsTermine dsTermine = null;
                b.getInterventionenByIDs(ref lstInverventionen, false, ref dsTermine);

                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = true;
                List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> arInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();
                foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rI in dsTermine.vInterventionen)
                {
                    arInterventionen.Add(rI);
                }
                remotingSrv.showMsgBoxTestmodus("rarInterventionenI.Count() for open UI: " + arInterventionen.Count().ToString());

                //remotingClient.frmMainFormIPCClient1.arInterventionen = arInterventionen;
                //remotingClient.frmMainFormIPCClient1.openFormRückmeldung = true;
                //remotingClient.frmMainFormIPCClient1.timerOpenUI.Enabled = true;
                //remotingClient.frmMainFormIPCClient1.timerOpenUI.Start();

                //frmInfo infoStartMain = new frmInfo();
                //infoStartMain.TopMost = true;
                //infoStartMain.closeIfVisible = true;
                //infoStartMain.ShowInTaskbar = false;
                //infoStartMain.StartPosition = FormStartPosition.CenterScreen;
                //infoStartMain.ShowDialog();

                //return true;

                remotingClient.frmRueckmedlungLine.SetData(arInterventionen);
                remotingClient.frmRueckmedlungLine.StartPosition = FormStartPosition.CenterScreen;
                remotingClient.frmRueckmedlungLine.TopMost = true;
                remotingClient.frmRueckmedlungLine.Left = MainWindowLeft + (MainWindowWidth/2) + (remotingClient.frmRueckmedlungLine.Width/2);
                remotingClient.frmRueckmedlungLine.Top = MainWindowTop + (MainWindowHeight/2) + (remotingClient.frmRueckmedlungLine.Height / 2);

                //remotingClient.frmRueckmedlungLine.Show();
                //return true;
                DialogResult ret = remotingClient.frmRueckmedlungLine.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    //remotingClient remotingClient1 = new remotingClient();
                    //cParComm cParComm1 = new cParComm();
                    //remotingClient.cCallFctReturn CallFctReturn = null;
                    //remotingClient1.callFct(ICommunicationService.eTypeCallTo.MainPMDS, ICommunicationService.eTypeFct.RefreshInterventionen, cParComm1, ref CallFctReturn);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                remotingClient.frmLoadingWait1.Visible = false;
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = false;
                throw new Exception("ICommunicationService.StartSchnellrückmeldung: " + ex.ToString());
            }
        }
        public bool RefreshInterventionen()
        {
            try
            {
                //if (remotingClient.CallFctReturn.bOK)
                //{
                //    if (remotingSrv.SiteMap != null)
                //    {
                //        remotingSrv.SiteMap.RefreshTermin(false);
                //    }
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ICommunicationService.RefreshInterventionen: " + ex.ToString());
            }
        }

        public void CloseIPCClient()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                currentProcess.Kill();

            }
            catch (Exception ex)
            {
                string sExcept = "ICommunicationService.CloseIPCClient: " + ex.ToString();
                throw new Exception(sExcept);
            }
        }

    }

}
