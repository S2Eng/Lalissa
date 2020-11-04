using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Layout
    {
        public Layout()
        {
            LayoutGrids = new HashSet<LayoutGrids>();
        }

        public Guid Idguid { get; set; }
        public string LayoutName { get; set; }
        public bool AllUsers { get; set; }
        public string CreateFrom { get; set; }
        public DateTime CreateAt { get; set; }
        public string Key { get; set; }
        public int GridRowMinHeigth { get; set; }
        public int GridRowMaxHeigth { get; set; }
        public string AutoFitStyleGrid { get; set; }
        public bool GridAutoNewline { get; set; }
        public bool ShowAlwaysGroupBy { get; set; }
        public bool CaptionVisible { get; set; }
        public bool AutoSizeWidthColumns { get; set; }

        public virtual ICollection<LayoutGrids> LayoutGrids { get; set; }
    }
}