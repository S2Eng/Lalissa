using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    public class ENVWCFDto
    {

        public string db { get; set; }
        public string PathLauncher { get; set; }

    


        public string RootPath { get; set; }
        public string LogPath { get; set; }
        public string BinPath { get; set; }
        public string ReportPath { get; set; }
        public string ConfigPath { get; set; }
        public string ConfigFile { get; set; }
        public string TempPathWin { get; set; }

        public int ConnectTimeout { get; set; }

        public string OIDGDA { get; set; }


        //E-Mail-vars
        public string AdressTo { get; set; }
        public string ExchangeUrl { get; set; }
        public string ExchangeUsr { get; set; }
        public string ExchangePwd { get; set; }
        public string ExchangeAdressFrom { get; set; }
        public string SmtpAdressFrom { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpUsr { get; set; }
        public string SmtpPwd { get; set; }
        public int SmtpPort { get; set; }
        public bool SmtpSSL { get; set; }

    }

}

