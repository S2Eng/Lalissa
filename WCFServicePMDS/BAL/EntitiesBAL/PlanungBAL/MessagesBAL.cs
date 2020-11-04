using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using System.Collections.Concurrent;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.BAL
{

    public class MessagesBAL : ImessagesBAL
    {

        public MessagesBAL()
        {

        }



        public WCFServicePMDS.BAL.DTO.MessagesDto messagesSent( string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date 
                              orderby m.Created ascending
                              select m
                            ).ToList();

                    var aMIds = (from m in tM
                                 select (m.Id)).ToList();

                    var tMu = (from mu in _repo.dbcontext.MessagesToUsers
                               where aMIds.Contains(mu.Idmessages) && mu.Iduser == UserId
                               select mu
                             ).ToList();

                    //var tM = (from m in _repo.dbcontext.Messages
                    //          join mu in _repo.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                    //          where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                    //                   m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                    //          orderby m.Created ascending
                    //          select m
                    //    ).ToList();

                    WCFServicePMDS.BAL.DTO.MessagesDto dtoRet = new DTO.MessagesDto() { lMessages = new List<MessagesDTO>(), lMessagesToUsers = new List<MessagesToUsersDTO>() };
                    var lM = Mapping.MergeListData<MessagesDTO>(tM.Select(x => x as object).ToList());
                    if (lM.Count() > 0)
                        dtoRet.lMessages = lM;
                    var lMU = Mapping.MergeListData<MessagesToUsersDTO>(tMu.Select(x => x as object).ToList());
                    if (lMU.Count() > 0)
                        dtoRet.lMessagesToUsers = lMU;
                    return dtoRet;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesSent: " + ex.ToString());
            }
        }
        public WCFServicePMDS.BAL.DTO.MessagesDto messagesUnreadedUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              let actions = from mu in _repo.dbcontext.MessagesToUsers
                                            where mu.Idmessages == m.Id && mu.Iduser == UserId && !mu.Readed
                                            select mu
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && 
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date && actions.Count() > 0
                              orderby m.Created ascending
                              select m
                             ).ToList();

                    var aMIds = (from m in tM
                                 select (m.Id)).ToList();

                    var tMu = (from m in _repo.dbcontext.Messages
                               join mu in _repo.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                               where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && 
                                        m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date && mu.Iduser == UserId && !mu.Readed && aMIds.Contains(mu.Idmessages)
                               orderby m.Created ascending
                               select mu
                             ).ToList();

                    //var stud = _repo.dbcontext.Messages.Where(m => m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IdguidObject == UserId &&
                    //            m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date).OrderBy(o => o.Created)
                    //            .Select(m => new
                    //            {
                    //                Messages = m,
                    //                MessagesToUsers = m.MessagesToUsers
                    //            }).Select(m => m.MessagesToUsers)
                    //            .FirstOrDefault();

                    WCFServicePMDS.BAL.DTO.MessagesDto dtoRet = new DTO.MessagesDto() { lMessages = new List<MessagesDTO>(), lMessagesToUsers = new List<MessagesToUsersDTO>()};

                    var lM = Mapping.MergeListData<MessagesDTO>(tM.Select(x => x as object).ToList());
                    if (lM.Count() > 0)
                        dtoRet.lMessages = lM;
                    var lMU = Mapping.MergeListData<MessagesToUsersDTO>(tMu.Select(x => x as object).ToList());
                    if (lMU.Count() > 0)
                        dtoRet.lMessagesToUsers = lMU;

                    return dtoRet;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesUnreadedUsr: " + ex.ToString());
            }
        }
        public WCFServicePMDS.BAL.DTO.MessagesDto messagesAllUsr(string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp, Guid IDClient)
        {
            try
            {
                using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
                {
                    WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                    var tM = (from m in _repo.dbcontext.Messages
                              let actions = from mu in _repo.dbcontext.MessagesToUsers
                                            where mu.Idmessages == m.Id && mu.Iduser == UserId
                                            select mu
                              where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && 
                                       m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date && actions.Count() > 0
                              orderby m.Created ascending
                              select m
                             ).ToList();

                    var aMIds = (from m in tM
                                 select (m.Id)).ToList();

                    var tMu = (from m in _repo.dbcontext.Messages
                               join mu in _repo.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                               where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage &&
                                        m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date && mu.Iduser == UserId && aMIds.Contains(mu.Idmessages)
                               orderby m.Created ascending
                               select mu
                             ).ToList();

                    WCFServicePMDS.BAL.DTO.MessagesDto dtoRet = new DTO.MessagesDto() { lMessages = new List<MessagesDTO>(), lMessagesToUsers = new List<MessagesToUsersDTO>() };

                    var lM = Mapping.MergeListData<MessagesDTO>(tM.Select(x => x as object).ToList());
                    if (lM.Count() > 0)
                        dtoRet.lMessages = lM;
                    var lMU = Mapping.MergeListData<MessagesToUsersDTO>(tMu.Select(x => x as object).ToList());
                    if (tMu.Count() > 0)
                        dtoRet.lMessagesToUsers = lMU;

                    return dtoRet;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesAllUsr: " + ex.ToString());
            }
        }

        public MessagesDTO addMessage(Guid IDUser, string Username, string Title, string Message, string ClientsMessage, string TypeMessage, List<Guid> lUsersTo, Guid IDClient)
        {
            using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS(IDClient))
            {
                WCFServicePMDS.Repository.RepositoryWrapper _repo = new WCFServicePMDS.Repository.RepositoryWrapper(context);

                var m = newMessage(IDUser, Username);

                m.Id = System.Guid.NewGuid();
                m.Title = Title.Trim(); ;
                m.Text = Message.Trim();
                m.UserFrom = Username;
                m.Created = DateTime.Now;
                m.CreatedDay = DateTime.Now.Date;
                m.UserFromId = IDUser;
                m.ClientsMessage = ClientsMessage.ToString();
                m.TypeMessage = TypeMessage.ToString();
                m.Progress = "";
                m.Db = "";
                m.IdguidObject = IDUser;

                _repo.dbcontext.Messages.Add(m);
                _repo.dbcontext.SaveChanges();

                var rM = Mapping.MergeListData<MessagesDTO>(_repo.dbcontext.Messages.ToList().Select(x => x as object).ToList()).First();
                foreach (var usr in lUsersTo)
                {
                    var mu = newMessageToUser(usr, Username, m.Id);
                    _repo.dbcontext.MessagesToUsers.Add(mu);
                    _repo.dbcontext.SaveChanges();
                }

                return rM;
            }
        }

        private Messages newMessage(Guid IDUser, string Username)
        {
            var m = new Messages() { Id = System.Guid.NewGuid(), Classification = "", ClientsMessage = "", Progress = "", SKey = "", Text = "", Title = "", 
                                        Db = "", TypeMessage = "", UserFrom = "", UserFromId = IDUser, IdguidObject = IDUser, Created = DateTime.Now, 
                                        CreatedDay = DateTime.Now.Date };
            return m;
        }
        private MessagesToUsers newMessageToUser(Guid IDUser, string Username, Guid IdMessage)
        {
            var mu = new MessagesToUsers() { Id = System.Guid.NewGuid(), Idmessages = IdMessage, Iduser = IDUser, Readed = false, ReadedAt = null, Username = Username };
            return mu;
        }

    }

}
