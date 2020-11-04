using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Dbversion
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string ScriptVersion { get; set; }
    }
}