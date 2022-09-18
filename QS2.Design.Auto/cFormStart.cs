using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;





namespace qs2.design.auto
{


    public class cFormStart
    {
        public static Thread Startinfo = null;
        public static bool UnvisibleOnClose = false;
        public static qs2.design.auto.frmStart frmStart = null;
        public static int ThreadIDStartWindow = -999;









        public static void ThreadStartWindow()
        {
            try
            {
                cFormStart.ThreadIDStartWindow = System.Threading.Thread.CurrentThread.ManagedThreadId;
                
                cFormStart.Startinfo = new Thread(new ThreadStart(cFormStart.showStartWindow2));
                cFormStart.Startinfo.IsBackground = false;
                cFormStart.Startinfo.SetApartmentState(ApartmentState.STA);
                cFormStart.Startinfo.Start();
                //while (ms_frmSplash == null || ms_frmSplash.IsHandleCreated == false)
                //{
                //    System.Threading.Thread.Sleep(TIMER_INTERVAL);
                //}


            }
            catch (Exception ex)
            {
                throw new Exception("ThreadStartWindow: " + ex.ToString());
            }
        }
        public static void showStartWindow2()
        {
            try
            {
                cFormStart.frmStart = new design.auto.frmStart();
                //System.Windows.Forms.Application.DoEvents();
                cFormStart.frmStart.TopMost = true;
                cFormStart.frmStart.txtInfo.Text = "Initializing System";
                System.Windows.Forms.Application.Run(cFormStart.frmStart);

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public static void showTxtStartWindow2(string txt, bool closeWindow, bool IsExternProcess)
        {
            try
            {
                if (!IsExternProcess)
                {
                    qs2.design.auto.frmStart.txtStartinfo += txt.Trim() + "\r\n";
                    qs2.design.auto.frmStart.closeWindow = closeWindow;

                }

                if (closeWindow)
                {

                    cFormStart.frmStart = null;
                    //cFormStart.frmStart.Close();
                    cFormStart.Startinfo = null;
                
                }

            }
            catch (Exception ex)
            {
                throw new Exception("showTxtStartWindow: " + ex.ToString());
            }
        }
        public static void closeStartinfo(bool IsExternProcess)
        {
            try
            {
                qs2.design.auto.cFormStart.showTxtStartWindow2("", true, IsExternProcess);
                   
            }
            catch (Exception ex)
            {
                throw new Exception("closeStartinfo: " + ex.ToString());
            }
        }

    }


}
