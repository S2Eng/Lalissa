// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class CommAsyncClients
    {
        public Guid Id { get; set; }
        public Guid IdcommAsync { get; set; }
        public string Idclient { get; set; }
        public bool Done { get; set; }
        public DateTime? DoneAt { get; set; }

        public virtual CommAsync IdcommAsyncNavigation { get; set; }
    }
}