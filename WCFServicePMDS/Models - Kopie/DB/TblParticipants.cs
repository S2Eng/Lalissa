using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblParticipants
    {
        public Guid Idguid { get; set; }
        public string Participant { get; set; }
        public Guid? IdobjectGuid { get; set; }

        public virtual TblObject IdobjectGu { get; set; }
    }
}