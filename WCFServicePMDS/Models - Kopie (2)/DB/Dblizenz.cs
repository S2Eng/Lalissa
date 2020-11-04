using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Dblizenz
    {
        public int Id { get; set; }
        public string Lizenz { get; set; }
        public Guid Idguid { get; set; }
    }
}