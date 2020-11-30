﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSelListEntriesObj
    {
        public Guid Idguid { get; set; }
        public string FldShort { get; set; }
        public string Idapplication { get; set; }
        public int? Idobject { get; set; }
        public int? IdselListEntrySublist { get; set; }
        public int IdselListEntry { get; set; }
        public int? Idstay { get; set; }
        public string IdparticipantStay { get; set; }
        public string IdapplicationStay { get; set; }
        public string TypIdgroup { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Idclassification { get; set; }
        public int? IdownInt { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public bool IsMain { get; set; }
        public bool Active { get; set; }
        public string Idparticipant { get; set; }
        public Guid? IdobjectGuid { get; set; }
        public DateTime? Transfered { get; set; }
        public int NVisible { get; set; }

        public virtual TblStay Id { get; set; }
        public virtual TblObject IdobjectNavigation { get; set; }
        public virtual TblSelListEntries IdselListEntrySublistNavigation { get; set; }
        public virtual TblCriteria TblCriteria { get; set; }
    }
}