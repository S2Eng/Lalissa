using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class BenutzerDTO
    {
        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Benutzer1 { get; set; }
        public string Passwort { get; set; }
        public bool? AktivJn { get; set; }
        public bool? PflegerJn { get; set; }
        public Guid? Idberufsstand { get; set; }
        public int BarcodeId { get; set; }
        public DateTime? Eintrittsdatum { get; set; }
        public DateTime? Austrittsdatum { get; set; }
        public string SmtpSrv { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpAbsender { get; set; }
        public string SmtpPwd { get; set; }
        public bool SmtpAuthentStandard { get; set; }
        public bool IsGeneric { get; set; }
        public Guid? Idarzt { get; set; }
        public bool ArztabrechnungJn { get; set; }
        //public string Signatur { get; set; }
        public string Elgauser { get; set; }
        public string ElgapatId { get; set; }
        public bool Elgaactive { get; set; }
        public bool ElgaautoLogin { get; set; }
        public bool ElgaautostartSession { get; set; }
        public DateTime? ElgavalidTrough { get; set; }

    }

    public class BenutzerSTOS1
    {
        public Guid Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Benutzer1 { get; set; }
       
    }

}

