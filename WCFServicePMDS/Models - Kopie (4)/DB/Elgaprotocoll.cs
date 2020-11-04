using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Elgaprotocoll
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Protocoll { get; set; }
        public string Elgafunctions { get; set; }
        public string Elgaerrors { get; set; }
        public string Characteristics { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedUser { get; set; }
    }
}