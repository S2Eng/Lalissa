using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{


    public class generic
    {

        public static bool bStopService = false;
        public static StringComparison ignore = StringComparison.CurrentCultureIgnoreCase;



        public static void waitMS(int WaitMilliseconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitMilliseconds)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }

        }

        public static void WaitSec(int WaitSeconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitSeconds * 1000)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }
        }

        public static string searchKeyArg(string keySearch, string[] args)
        {

            foreach (string sParam in args)
            {
                string[] aParam = sParam.Split(new char[] { '=' }, 2);
                if (aParam[0].Replace("?", "").Trim().Equals(keySearch, StringComparison.CurrentCultureIgnoreCase))
                    return aParam.Length > 1 ? aParam[1] : "";
            }
            return "";
        }

    }
}
