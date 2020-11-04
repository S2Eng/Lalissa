using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class LayoutDTO
    {
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


    }

}

