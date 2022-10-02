using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace QS2.functions.cs
{

    public class EMail
    {
        
        public static string EMailService { get; set; }= "ServiceCenter@s2-engineering.com";



        public void sendEMail(string sTitle, string sText, string sTo)
        {
            string sParam = "";
            if (sTitle.Length > 0)
            {
                this.addMailParam(ref sParam, "subject=" + sTitle);
            }
            if (sTitle.Length > 0)
            {
                string sTxtNew = sText.Replace(Convert.ToChar(10).ToString(), "%0d");
                sTxtNew = sText.Replace(Convert.ToChar(13).ToString(), "%0a");
                this.addMailParam(ref sParam, "body=" + sTxtNew);
            }

            System.Diagnostics.Process.Start("mailto: " + sTo + sParam);
        }
        public void addMailParam(ref string sAllParam, string sParam)
        {
            if (sAllParam == string.Empty)
            {
                sAllParam += "?" + sParam;
            }
            else
            {
                sAllParam += "&" + sParam;
            }
        }


    }


}
