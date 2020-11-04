using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblRelationship
    {
        public string FldShortParent { get; set; }
        public string IdapplicationParent { get; set; }
        public string FldShortChild { get; set; }
        public string IdapplicationChild { get; set; }
        public string Conditions { get; set; }
        public string Type { get; set; }
        public string TypeSub { get; set; }
        public string ConditionsSub { get; set; }
        public string Idkey { get; set; }
        public Guid Idguid { get; set; }
        public int Sort { get; set; }

        public virtual TblCriteria TblCriteria { get; set; }
        public virtual TblCriteria TblCriteriaNavigation { get; set; }
    }
}