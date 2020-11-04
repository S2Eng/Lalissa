using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblSelListGroupDTO
    {

        public int Id { get; set; }
        public Guid Idguid { get; set; }
        public string IdgroupStr { get; set; }
        public string Idapplication { get; set; }
        public string Idparticipant { get; set; }
        public string Idressource { get; set; }
        public string VersionNrFrom { get; set; }
        public string VersionNrTo { get; set; }
        public bool Sys { get; set; }
        public string Sublist { get; set; }
        public string TypeEnum { get; set; }
        public string SortColumn { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }


    }

}

