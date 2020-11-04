using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Protocol
    {
        public Guid Idguid { get; set; }
        public string Protocol1 { get; set; }
        public string Info { get; set; }
        public string Type { get; set; }
        public Guid? IdguidObject { get; set; }
        public int? Idstay { get; set; }
        public string Idparticipant { get; set; }
        public string IdstayApplication { get; set; }
        public string SKey { get; set; }
        public string Idapplication { get; set; }
        public string Classification { get; set; }
        public string User { get; set; }
        public DateTime Created { get; set; }
        public string Sql { get; set; }
        public string InfoFile { get; set; }
        public string Db { get; set; }
        public DateTime CreatedDay { get; set; }
        public string Progress { get; set; }
        public string Patient { get; set; }
        public string MedRecNr { get; set; }
    }
}