using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblUidefinitions
    {
        public Guid Id { get; set; }
        public string Uitype { get; set; }
        public string ElementType { get; set; }
        public string DataType { get; set; }
        public string LabelTxt { get; set; }
        public bool IsGroupHeader { get; set; }
        public string DbTable { get; set; }
        public string DbColumn { get; set; }
        public int ElementHeigth { get; set; }
        public int ElementWidth { get; set; }
        public int Sort { get; set; }
    }
}