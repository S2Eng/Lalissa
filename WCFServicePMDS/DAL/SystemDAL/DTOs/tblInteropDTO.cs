using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class tblInteropDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DoAt { get; set; }
        public string TypAction { get; set; }
        public string FromUser { get; set; }
        public string FromClient { get; set; }
        public string DbPar { get; set; }
        public bool Done { get; set; }
        public DateTime? DoneAt { get; set; }
        public bool ReplyToUser { get; set; }
        public string ReplyTxt { get; set; }
        public string ReplyTxtDetail { get; set; }
        public string ReplyError { get; set; }
        public bool Deleted { get; set; }


    }

}

