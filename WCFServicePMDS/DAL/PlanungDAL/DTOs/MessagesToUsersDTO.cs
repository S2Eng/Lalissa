using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    public class MessagesToUsersDTO
    {
        public Guid Id { get; set; }
        public Guid Idmessages { get; set; }
        public bool Readed { get; set; }
        public DateTime? ReadedAt { get; set; }
        public Guid Iduser { get; set; }
        public string Username { get; set; }

    }

}

