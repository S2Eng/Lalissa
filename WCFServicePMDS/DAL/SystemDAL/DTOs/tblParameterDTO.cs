using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblParameterDTO
    {
        public string Bezeichnung { get; set; }
        public string SqlParameter { get; set; }
        public bool TextParameter { get; set; }


    }

}

