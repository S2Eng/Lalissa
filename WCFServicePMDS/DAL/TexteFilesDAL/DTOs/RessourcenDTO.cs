using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class RessourcenDTO
    {
        public string Idres { get; set; }
        public string English { get; set; }
        public string German { get; set; }
        public string User { get; set; }
        public string IdlanguageUser { get; set; }
        public string Description { get; set; }
        public string Idapplication { get; set; }
        public string Idparticipant { get; set; }
        public string Type { get; set; }
        public string TypeSub { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileType { get; set; }
        public DateTime Created { get; set; }
        public string CreatedUser { get; set; }
        public Guid Idguid { get; set; }
        public string Image { get; set; }
        public int ImageWidth { get; set; }
        public int ImageHeigth { get; set; }
        public string Classification { get; set; }
        public DateTime LastChange { get; set; }
        public string ResGroup { get; set; }


    }

}

