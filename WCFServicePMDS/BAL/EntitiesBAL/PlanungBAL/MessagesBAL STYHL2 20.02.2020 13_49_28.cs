using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using PMDS.db.Entities;
using System.Collections.Concurrent;

namespace WCFServicePMDS.BAL
{

    public class MessagesBAL : ImessagesBAL
    {

        public MessagesBAL()
        {

        }



        public List<MessagesDTO> messagesSent( string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS())
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              join mu in _repo.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                              orderby m.Created ascending
                              select m
                        ).ToList();

                    return Mapping.MergeListData<List<MessagesDTO>>(tM.Select(x => x as object).ToList()).First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesSent: " + ex.ToString());
            }
        }
        public List<MessagesDTO> messagesInputNotReadedUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS())
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              let actions = from mu in _repo.dbcontext.MessagesToUsers
                                            where mu.Idmessages == m.Id && mu.Iduser == UserId && !mu.Readed
                                            select mu
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                              orderby m.Created ascending
                              select m
                             ).ToList();

                    //var tM = (from m in _repo.dbcontext.Messages
                    //          join mu in _repo.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                    //          where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                    //                   m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date && mu.Iduser == UserId && !mu.Readed 
                    //          orderby m.Created ascending
                    //          select m
                    //    ).ToList();

                    return Mapping.MergeListData<List<MessagesDTO>>(tM.Select(x => x as object).ToList()).First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesInputNotReadedUsr: " + ex.ToString());
            }
        }
        public List<MessagesDTO> messagesInputAllUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS())
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              let actions = from mu in _repo.dbcontext.MessagesToUsers
                                            where mu.Idmessages == m.Id && mu.Iduser == UserId
                                            select mu
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                              orderby m.Created ascending
                              select m
                             ).ToList();

                    return Mapping.MergeListData<List<MessagesDTO>>(tM.Select(x => x as object).ToList()).First();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesInputAllUsr: " + ex.ToString());
            }
        }

        public MessagesDTO newMessage(Guid IDUser, string Username)
        {
            var m = new MessagesDTO() { Id = System.Guid.NewGuid(), Idmessages = System.Guid.NewGuid(), Iduser = IDUser, Readed = false, ReadedAt = null, Username = "" };
            return m;
        }

    }

}
