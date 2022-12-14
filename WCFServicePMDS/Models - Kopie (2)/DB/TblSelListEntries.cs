using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSelListEntries
    {
        public TblSelListEntries()
        {
            TblQueriesDef = new HashSet<TblQueriesDef>();
            TblSelListEntriesObj = new HashSet<TblSelListEntriesObj>();
            TblSelListEntriesSort = new HashSet<TblSelListEntriesSort>();
            TblStayAdditionsIdselListFirstNavigation = new HashSet<TblStayAdditions>();
            TblStayAdditionsIdselListNavigation = new HashSet<TblStayAdditions>();
        }

        public int Id { get; set; }
        public Guid Idguid { get; set; }
        public string Idressource { get; set; }
        public int? IdownInt { get; set; }
        public string IdownStr { get; set; }
        public int? Sort { get; set; }
        public bool IsMain { get; set; }
        public string TypeQry { get; set; }
        public string TypeStr { get; set; }
        public string Table { get; set; }
        public string FldShortColumn { get; set; }
        public byte[] Picture { get; set; }
        public int Idgroup { get; set; }
        public string CreatedUser { get; set; }
        public bool Private { get; set; }
        public string VersionNrFrom { get; set; }
        public string VersionNrTo { get; set; }
        public string Classification { get; set; }
        public DateTime? Created { get; set; }
        public string Sql { get; set; }
        public string Uitype { get; set; }
        public string Description { get; set; }
        public string Idparticipant { get; set; }
        public bool Extern { get; set; }
        public bool SubQuery { get; set; }
        public string LicenseKey { get; set; }
        public bool? Published { get; set; }

        public virtual TblSelListGroup IdgroupNavigation { get; set; }
        public virtual ICollection<TblQueriesDef> TblQueriesDef { get; set; }
        public virtual ICollection<TblSelListEntriesObj> TblSelListEntriesObj { get; set; }
        public virtual ICollection<TblSelListEntriesSort> TblSelListEntriesSort { get; set; }
        public virtual ICollection<TblStayAdditions> TblStayAdditionsIdselListFirstNavigation { get; set; }
        public virtual ICollection<TblStayAdditions> TblStayAdditionsIdselListNavigation { get; set; }
    }
}