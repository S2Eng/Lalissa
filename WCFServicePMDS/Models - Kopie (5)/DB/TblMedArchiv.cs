using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblMedArchiv
    {
        public Guid Idguid { get; set; }
        public Guid? IdstayGuid { get; set; }
        public Guid? IdguidObject { get; set; }
        public string Document64 { get; set; }
        public DateTime? SendDate { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public string FileName { get; set; }
        public string DocName { get; set; }
        public string DocId { get; set; }
        public byte[] DocumentByte { get; set; }
        public int DocumentVersion { get; set; }
        public string DocumentInfoHl7 { get; set; }
        public string Application { get; set; }
        public string Participant { get; set; }
        public int? Idstay { get; set; }
        public string Idparticipant { get; set; }
        public string Idapplication { get; set; }
        public Guid? IdobjectGuid { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }

        public virtual TblObject IdguidObjectNavigation { get; set; }
        public virtual TblStay IdstayGu { get; set; }
    }
}