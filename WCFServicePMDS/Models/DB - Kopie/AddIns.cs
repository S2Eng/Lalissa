using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class AddIns
    {
        public Guid Id { get; set; }
        public bool Activated { get; set; }
        public string AddInName { get; set; }
        public string Dll { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Place { get; set; }
        public DateTime? ActivatedAt { get; set; }
        public string ActivatedFrom { get; set; }
    }
}