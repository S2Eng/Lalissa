using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblObjectRel
    {
        public Guid Idguid { get; set; }
        public Guid IdguidObject { get; set; }
        public Guid IdguidObjectSub { get; set; }

        public virtual TblObject IdguidObjectNavigation { get; set; }
        public virtual TblObject IdguidObjectSubNavigation { get; set; }
    }
}