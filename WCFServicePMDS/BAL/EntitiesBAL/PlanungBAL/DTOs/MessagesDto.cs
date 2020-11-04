using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.Models.DB;

namespace WCFServicePMDS.BAL.DTO
{

    public class MessagesDto
    {
        public List<WCFServicePMDS.DAL.DTO.MessagesDTO> lMessages { get; set; }
        public List<WCFServicePMDS.DAL.DTO.MessagesToUsersDTO> lMessagesToUsers { get; set; }
    }

}

