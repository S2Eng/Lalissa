using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Plan
    {
        public Plan()
        {
            PlanAnhang = new HashSet<PlanAnhang>();
            PlanObject = new HashSet<PlanObject>();
        }

        public Guid Id { get; set; }
        public string Betreff { get; set; }
        public DateTime? BeginntAm { get; set; }
        public DateTime? FälligAm { get; set; }
        public int? Idart { get; set; }
        public string Priorität { get; set; }
        public string Status { get; set; }
        public bool? Readed { get; set; }
        public bool Deleted { get; set; }
        public bool Design { get; set; }
        public string Text { get; set; }
        public string Zusatz { get; set; }
        public string MailFrom { get; set; }
        public string MailAn { get; set; }
        public string MailCc { get; set; }
        public string MailBcc { get; set; }
        public bool Html { get; set; }
        public string Für { get; set; }
        public DateTime? GesendetAm { get; set; }
        public DateTime? EmpfangenAm { get; set; }
        public bool Wichtig { get; set; }
        public bool RemembJn { get; set; }
        public int? RemembMinut { get; set; }
        public string Teilnehmer { get; set; }
        public string ErstelltVon { get; set; }
        public DateTime ErstelltAm { get; set; }
        public Guid? Idactivity { get; set; }
        public string Idstatus { get; set; }
        public string Idtyp { get; set; }
        public string KommStatus { get; set; }
        public byte[] Db { get; set; }
        public Guid? IduserAccount { get; set; }
        public string MessageId { get; set; }
        public string DetailsMime { get; set; }
        public Guid? IdplanMain { get; set; }
        public string AwaitingResponse { get; set; }
        public string ReplyTxt { get; set; }
        public bool IsOwner { get; set; }
        public int? Idfolder { get; set; }
        public Guid? Id1tmp { get; set; }
        public Guid? Id2tmp { get; set; }
        public Guid? Id3tmp { get; set; }
        public bool SendWithPostOfficeBoxForAll { get; set; }
        public bool OutlookApi { get; set; }
        public string ConversationId { get; set; }
        public string Idoutlook { get; set; }
        public string IdoutlookTicks { get; set; }
        public string Category { get; set; }
        public string Folder { get; set; }
        public DateTime? LastChangeItscont { get; set; }
        public DateTime? LastSyncToExchange { get; set; }
        public string Wochentage { get; set; }
        public int? NTenMonat { get; set; }
        public string SerienterminType { get; set; }
        public Guid? Idserientermin { get; set; }
        public string TagWochenMonat { get; set; }
        public int? WiedWertJeden { get; set; }
        public DateTime? EndetAm { get; set; }
        public int Dauer { get; set; }
        public bool GanzerTag { get; set; }
        public bool IsSerientermin { get; set; }
        public DateTime? SerienterminEndetAm { get; set; }
        public Guid Idklinik { get; set; }

        public virtual TblUserAccounts IduserAccountNavigation { get; set; }
        public virtual ICollection<PlanAnhang> PlanAnhang { get; set; }
        public virtual ICollection<PlanObject> PlanObject { get; set; }
    }
}