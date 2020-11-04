using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblObjectApplications
    {
        public Guid Id { get; set; }
        public Guid IdobjectGuid { get; set; }
        public string Idapplication { get; set; }

        public virtual TblObject IdobjectGu { get; set; }
    }
}