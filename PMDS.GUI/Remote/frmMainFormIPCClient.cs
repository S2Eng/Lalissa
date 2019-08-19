using PMDS.Global.Remote;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace PMDS.GUI.Remote
{

    public partial class frmMainFormIPCClient : Form
    {
        public bool IsLoaded = false;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public bool bWindowSetToForeground = false;
        public List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow> arInterventionen = new List<PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow>();

        public bool FormRückmeldungIsInitialized = false;
        public bool openFormRückmeldung = false;

        public bool TimerRestarted = false;






        public frmMainFormIPCClient()
        {
            InitializeComponent();
        }


        private void frmMainFormIPCClient_Load(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Point p = new Point(-300, -300);
                this.Location = p;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.IsLoaded = true;

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


        private void timerOpenUI_Tick(object sender, EventArgs e)
        {
            try
            {
                //System.Windows.Forms.MessageBox.Show("timerOpenUI_Tick");

                if (!this.FormRückmeldungIsInitialized)
                {
                    remotingClient.frmRueckmedlungLine = new frmPatientRueckmeldungLine();
                    this.FormRückmeldungIsInitialized = true;

                    remotingClient.frmLoadingWait1 = new GUI.Main.frmLoadingWait();
                    remotingClient.frmLoadingWait1.initControl();
                    remotingClient.frmLoadingWait1.TopMost = true;
                }

                if (!this.TimerRestarted)
                {
                    this.timerOpenUI.Enabled = false;
                    this.timerOpenUI.Stop();

                    this.timerOpenUI.Interval = 10;
                    this.timerOpenUI.Enabled = true;
                    this.timerOpenUI.Start();

                    this.TimerRestarted = true;
                }

                //remotingSrv remotingSrv1 = new remotingSrv();
                //remotingSrv1.run(remotingSrv.varsToCallIPCServer.PortClientUIQS2.Trim(), remotingSrv.varsToCallIPCServer.UriClientUIQS2.Trim(), remotingSrv.varsToCallIPCServer.SrvNr, true, false);
                //MessageBox.Show("5 sek check connection");

                if (!remotingSrv.IsCheckingSchnellrückmeldungen)
                {
                    remotingSrv.checkSchnellrückmeldung();
                }
                

                //if (this.openFormRückmeldung)
                //{
                //    //System.Windows.Forms.MessageBox.Show("openFormRückmeldung");

                //    //PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = true;
                //    //remotingClient.frmRueckmedlungLine._ar = this.arInterventionen;
                //    //remotingClient.frmRueckmedlungLine.StartPosition = FormStartPosition.CenterScreen;
                //    //remotingClient.frmRueckmedlungLine.TopMost = true;

                //    //DialogResult ret = remotingClient.frmRueckmedlungLine.ShowDialog();
                //    //if (ret == DialogResult.OK)
                //    //{
                //    //    remotingClient remotingClient1 = new remotingClient();
                //    //    cParComm cParComm1 = new cParComm();
                //    //    remotingClient.cCallFctReturn CallFctReturn = null;
                //    //    remotingClient1.callFct(ICommunicationService.eTypeCallTo.MainPMDS, ICommunicationService.eTypeFct.RefreshInterventionen, cParComm1, ref CallFctReturn);
                //    //}
                //    //else
                //    //{

                //    //}
                //}

            }
            catch (Exception ex)
            {
                PMDS.GUI.frmPatientRueckmeldungLine.IsSchnellrückmeldung = false;
                PMDS.Global.ENV.HandleException(ex);
            }
        }

    }
}
