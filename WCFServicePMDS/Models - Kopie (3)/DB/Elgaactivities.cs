using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Elgaactivities
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime? EntlassenAm { get; set; }
        public string Entalssungsgrund { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public Guid? Idpatient { get; set; }
        public DateTime? Created { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? ElgaactivityAt { get; set; }
        public string ElgaactivityFrom { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Patient IdpatientNavigation { get; set; }
    }
}