using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class StandardProzedurenDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool ShowPrintDialog { get; set; }
        public bool NotfallJn { get; set; }
        public bool Unterdrücken { get; set; }

    }

}

