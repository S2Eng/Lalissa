using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Elgadocuments
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Docu { get; set; }
        public bool Vidiert { get; set; }
        public DateTime? VidiertAt { get; set; }
        public string VidiertFrom { get; set; }
        public bool Sended { get; set; }
        public DateTime? SendetAt { get; set; }
        public string SendetFrom { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedFrom { get; set; }
        public string Idelga { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idaufenthalt { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}