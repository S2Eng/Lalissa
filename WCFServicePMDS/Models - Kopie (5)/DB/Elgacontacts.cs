using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Elgacontacts
    {
        public Guid Id { get; set; }
        public string ElgacontactId { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idarzt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedFrom { get; set; }

        public virtual Aerzte IdarztNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}