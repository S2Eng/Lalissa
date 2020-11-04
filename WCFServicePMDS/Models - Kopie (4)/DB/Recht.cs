using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Recht
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public bool Elga { get; set; }
    }
}