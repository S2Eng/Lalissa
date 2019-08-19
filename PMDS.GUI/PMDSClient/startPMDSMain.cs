using PMDSClient.Sitemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace PMDS.GUI.PMDSClient
{


    public class startPMDSMain
    {



        public void run()
        {
            try
            {
                while (!WCFServiceClient.IsInitialized)
                {
                }

                Task t = init();

                Thread th = new Thread(new ParameterizedThreadStart(LogIn));
                th.SetApartmentState(ApartmentState.STA);
                th.Start("");

                //PMDSClient.frmPMDSMain frmMain = new frmPMDSMain();
                //frmMain.initControl();
                //System.Threading.Thread.Sleep(20000);

                while (th.IsAlive)
                {
                }
                t.Wait();


                //System.Windows.Forms.Application.Run(frmMain);

            }
            catch (Exception ex)
            {
                Exception exTmp = new Exception("startPMDSMain.run: " + ex.ToString());
                PMDSClientWrapper.doExcept(exTmp);
            }
        }

        private async Task init()
        {
            try
            {


            }
            catch (Exception ex)
            {
                Exception exTmp = new Exception("startPMDSMain.init: " + ex.ToString());
                PMDSClientWrapper.doExcept(exTmp);
            }
        }

        private void LogIn(object arg)
        {
            try
            {
                //PMDS.GUI.PMDSClient.frmLogin logIn = new PMDS.GUI.PMDSClient.frmLogin();
                //logIn.initControl();
                //logIn.TopMost = true;
                //logIn.ShowDialog();
                //if (!logIn.abort)
                //{

                //}
                //else
                //{

                //}

            }
            catch (Exception ex)
            {
                Exception exTmp = new Exception("startPMDSMain.LogIn: " + ex.ToString());
                PMDSClientWrapper.doExcept(exTmp);
            }
        }


    }

}
