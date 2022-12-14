using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblCriteria
    {
        public TblCriteria()
        {
            TblCriteriaOpt = new HashSet<TblCriteriaOpt>();
            TblQueriesDef = new HashSet<TblQueriesDef>();
            TblRelationshipTblCriteria = new HashSet<TblRelationship>();
            TblRelationshipTblCriteriaNavigation = new HashSet<TblRelationship>();
            TblSelListEntriesObj = new HashSet<TblSelListEntriesObj>();
        }

        public string FldShort { get; set; }
        public string Idapplication { get; set; }
        public string ControlType { get; set; }
        public string SqlvalueListSelect { get; set; }
        public string AliasFldShort { get; set; }
        public string SourceTable { get; set; }
        public string ControlPattern { get; set; }
        public string MaskInput { get; set; }
        public string ControlMinVal { get; set; }
        public string ControlMaxVal { get; set; }
        public int ControlMinLength { get; set; }
        public int ControlMaxLength { get; set; }
        public bool Used { get; set; }
        public bool Validate { get; set; }
        public bool? Editable { get; set; }
        public bool UserDefined { get; set; }
        public bool? UseInQueries { get; set; }
        public string LicenseKey { get; set; }
        public string Description { get; set; }
        public string ShowAt { get; set; }
        public bool? Prefered { get; set; }
        public string Classification { get; set; }
        public string DefaultValues { get; set; }
        public string DefaultValuesCustomer { get; set; }
        public bool UsedCustomer { get; set; }

        public virtual ICollection<TblCriteriaOpt> TblCriteriaOpt { get; set; }
        public virtual ICollection<TblQueriesDef> TblQueriesDef { get; set; }
        public virtual ICollection<TblRelationship> TblRelationshipTblCriteria { get; set; }
        public virtual ICollection<TblRelationship> TblRelationshipTblCriteriaNavigation { get; set; }
        public virtual ICollection<TblSelListEntriesObj> TblSelListEntriesObj { get; set; }
    }
}