using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblCriteriaOpt
    {
        public string FldShort { get; set; }
        public string Idapplication { get; set; }
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Referenze { get; set; }
        public string VersionNrFrom { get; set; }
        public string VersionNrTo { get; set; }

        public virtual TblCriteria TblCriteria { get; set; }
    }
}