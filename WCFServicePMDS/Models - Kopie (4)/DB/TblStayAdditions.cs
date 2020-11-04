using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblStayAdditions
    {
        public Guid Idguid { get; set; }
        public int IdstayParent { get; set; }
        public string IdapplicationStayParent { get; set; }
        public string IdparticipantStayParent { get; set; }
        public int? IdstayChild { get; set; }
        public string IdapplicationStayChild { get; set; }
        public string IdparticipantStayChild { get; set; }
        public int? IdselList { get; set; }
        public string Typ { get; set; }
        public int Sort { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public int? IdselListFirst { get; set; }
        public Guid? Idpatient { get; set; }
        public int? Idobject { get; set; }
        public string Idapplication { get; set; }

        public virtual TblStay Id { get; set; }
        public virtual TblSelListEntries IdselListFirstNavigation { get; set; }
        public virtual TblSelListEntries IdselListNavigation { get; set; }
    }
}