using System.ComponentModel;
using System.Threading;






namespace qs2.core
{



    public class threadStayUI
    {
        public static Thread threadWorkerStayUI = null;
        public static bool StayUIIsinitialized = false;
                
        public delegate void dCallthreadWorkerStayUI(eTypeCallThreadWorkerStayUI TypeFunction, cParsThreadWorkerStayUI pars, ref bool OpendFromEvaluation);
        public enum eTypeCallThreadWorkerStayUI
        {
            initStay = 0,
            loadStay = 1,
            abortThread
        }
        public class cParsThreadWorkerStayUI
        {
            public System.Guid IDStayGuid;
            public string IDApplication = "";
            public string IDParticipant = "";
            public bool ShowAllStayTypes = false;
            public bool runAsSystemuser = false;
            public int runAsUser = -999;
            public eTypeCallThreadWorkerStayUI TypeCallThreadWorkerStayUI;
            public bool newStay = false;
            public qs2.core.Enums.eStayTyp StayTyp;
            public bool OpenFromEvaluation = false;
        }
        
        public static EventWaitHandle _ready = new AutoResetEvent(false);
        public static EventWaitHandle _go = new AutoResetEvent(false);
        public static readonly object _locker = new object();
        public static cParsThreadWorkerStayUI _message;

        public static bool QS2ClosedByUser = false;
        public static bool StaySaveWasClicked = false;
        public static bool StayIsClosed = true;
        public static bool UserHasDoubleClickedOpenStay = false;
        public static bool StaySaveInProgress = false;
        public static int StayDoubleClickCounter = 0;










        public static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            if (e.Argument != null)
            {
                DoWorkEventArgs args = (DoWorkEventArgs)e.Argument;
            }

            //e.Result = BackgroundProcessLogicMethod(helperBW, arg);
            //if (helperBW.CancellationPending)
            //{
            //    e.Cancel = true;
            //}
        }
        public static void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int iStatus = e.ProgressPercentage;
            if (iStatus == 1)
            {
                threadStayUI.StayUIIsinitialized = true; 
            }

        }
        public static void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Asynchroner Thread kam bis zum Wert: " + e.Result.ToString());
            //btnStartEnd.Text = "Starten";
        }

    }


}
