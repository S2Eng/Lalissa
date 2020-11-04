using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblUserAccounts
    {
        public TblUserAccounts()
        {
            Plan = new HashSet<Plan>();
        }

        public Guid Id { get; set; }
        public string Usr { get; set; }
        public string Typ { get; set; }
        public string Name { get; set; }
        public string AdrFrom { get; set; }
        public string AdrTo { get; set; }
        public string Server { get; set; }
        public string UsrAuthentication { get; set; }
        public string PwdAuthentication { get; set; }
        public string Port { get; set; }
        public bool Ssl { get; set; }
        public Guid? Idaccount { get; set; }
        public DateTime? LastReceive { get; set; }
        public bool PostOfficeBoxForAll { get; set; }
        public bool PreferPostOfficeBoxForAll { get; set; }
        public bool OutlookWebApi { get; set; }

        public virtual ICollection<Plan> Plan { get; set; }
    }
}