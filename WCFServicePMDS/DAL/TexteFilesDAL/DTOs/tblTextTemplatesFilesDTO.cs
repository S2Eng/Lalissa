using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblTextTemplatesFilesDTO
    {

        public Guid Id { get; set; }
        public Guid IdtextTemplate { get; set; }
        public byte[] Docu { get; set; }
        public string Bezeichnung { get; set; }
        public string FileType { get; set; }

    }

}

