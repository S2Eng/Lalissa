 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL
{

    public class MessagesDAL : IMessages
    {

        private WCFServicePMDS.Repository.RepositoryWrapper _repoWrapper;


        public MessagesDAL(WCFServicePMDS.Repository.RepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public MessagesDTO MessagesById(Guid Id)
        {
            List<Messages> t = (from o in this._repoWrapper.dbcontext.Messages
                                where o.Id == Id
                                   select o).ToList();
            return Mapping.MergeListData<MessagesDTO>(t.Select(x => x as object).ToList()).First();
        }
        public MessagesDTO MessagesBy(bool readed, List<Guid> lUsers)
        {
            List<Messages> t = (from m in this._repoWrapper.dbcontext.Messages
                              join mu in this._repoWrapper.dbcontext.MessagesToUsers on m.Id equals mu.Idmessages
                              where mu.Readed == readed
                              select m).ToList();
            return Mapping.MergeListData<MessagesDTO>(t.Select(x => x as object).ToList()).First();
        }

    }

}

