using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblSideLogic
    {
        public Guid Idguid { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string FldShort { get; set; }
        public string Chapter { get; set; }
        public string Idapplication { get; set; }
        public int? Id { get; set; }
    }
}