using PMDSClient.Sitemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.Global.PMDSClient
{

    public class PMDSClientWrapper
    {

        public static bool _WCFServiceOnOff = false;
        public static string _LoginInNameFrei = "";
        public static string _UrlWCFServicePMDS = "";
        public static Guid _IDAUFENTHALT;
        public static Guid _USERID;


        


        public static bool WCFServiceOnOff
        {
            get
            {
                _WCFServiceOnOff = ENV.WCFServiceOnOff;
                return _WCFServiceOnOff;
            }
            set
            {
                _WCFServiceOnOff = value;
                ENV.WCFServiceOnOff = _WCFServiceOnOff;
                _WCFServiceOnOff = value;
            }
        }
        public static string LoginInNameFrei
        {
            get
            {
                _LoginInNameFrei = ENV.LoginInNameFrei;
                return _LoginInNameFrei;
            }
            set
            {
                _LoginInNameFrei = value;
                ENV.LoginInNameFrei = _LoginInNameFrei;
                _LoginInNameFrei = value;
            }
        }
        public static string UrlWCFServicePMDS
        {
            get
            {
                return _UrlWCFServicePMDS;
            }
            set
            {
                _UrlWCFServicePMDS = value;
            }
        }
        public static Guid IDAUFENTHALT
        {
            get
            {
                _IDAUFENTHALT = ENV.IDAUFENTHALT;
                return _IDAUFENTHALT;
            }
            set
            {
                _IDAUFENTHALT = value;
                ENV.setIDAUFENTHALT = _IDAUFENTHALT;
                _IDAUFENTHALT = value;
            }
        }
        public static Guid USERID
        {
            get
            {
                _USERID = ENV.USERID;
                return _USERID;
            }
            set
            {
                _USERID = value;
                ENV.setUSERID = _USERID;
                _USERID = value;
            }
        }



        public static void init()
        {
            try
            {
                WCFServiceClient.init();

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.init: " + ex.ToString());
            }
        }
        public static void sendExceptionAsSMTPEMail(string except, string client, string User, string Haus, DateTime At)
        {
            try
            {
                WCFServicePMDS.Service1 s1 = new WCFServicePMDS.Service1();
                s1.sendExceptionAsSMTPEMail(except, client, (Haus.Trim() == "" ? "" : Haus + "::") + User, At);
            }
            catch (Exception ex)
            {
                throw new Exception("WCFServiceClientPMDS.sendExceptionAsSMTPEMail: " + ex.ToString());
            }
        }


    }

}
