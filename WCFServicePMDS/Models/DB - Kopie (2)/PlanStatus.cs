// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class PlanStatus
    {
        public Guid Id { get; set; }
        public Guid Idplan { get; set; }
        public string MessageId { get; set; }
        public string Betreff { get; set; }
        public string Status { get; set; }
        public string Usr { get; set; }
        public DateTime Am { get; set; }
        public bool IsContact { get; set; }
    }
}