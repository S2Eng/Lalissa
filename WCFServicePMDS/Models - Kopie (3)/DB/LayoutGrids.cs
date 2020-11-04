using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class LayoutGrids
    {
        public Guid Idguid { get; set; }
        public string GridName { get; set; }
        public int Band { get; set; }
        public string ColumnName { get; set; }
        public int ColumnWith { get; set; }
        public bool Visible { get; set; }
        public bool OrderBy { get; set; }
        public bool Desc { get; set; }
        public bool GroupBy { get; set; }
        public int Sort { get; set; }
        public Guid Idlayout { get; set; }
        public bool GridAutoNewline { get; set; }
        public string TypeCol { get; set; }
        public bool AutoSizeHeigthColumn { get; set; }
        public int ColMinHeigth { get; set; }
        public int ColMaxHeigth { get; set; }
        public string ColumnCaption { get; set; }
        public int? TypeUi { get; set; }

        public virtual Layout IdlayoutNavigation { get; set; }
    }
}