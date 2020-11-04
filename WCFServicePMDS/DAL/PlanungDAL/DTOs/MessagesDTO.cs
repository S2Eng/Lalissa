using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    public class MessagesDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UserFrom { get; set; }
        public DateTime Created { get; set; }
        public Guid UserFromId { get; set; }
        public string ClientsMessage { get; set; }
        public string TypeMessage { get; set; }
        public string Progress { get; set; }
        public string Db { get; set; }
        public Guid? IdguidObject { get; set; }
        public string Classification { get; set; }
        public string SKey { get; set; }
        public DateTime CreatedDay { get; set; }

        public List<MessagesToUsersDTO> lMessagesToUsers;

    }

}

