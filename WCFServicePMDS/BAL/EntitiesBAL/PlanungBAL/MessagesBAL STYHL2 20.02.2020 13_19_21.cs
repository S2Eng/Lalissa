using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;


namespace WCFServicePMDS.BAL
{

    public class MessagesBAL : ImessagesBAL
    {

        public MessagesBAL()
        {

        }



        public void messagesSent( string ClientsMessage, string TypeMessage, Guid UserId, DateTime dFromTmp, DateTime dToTmp)
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
                              select new
                              {
                                  m.Id,
                                  m.IdguidObject,
                                  m.Progress,
                                  m.SKey,
                                  m.Text,
                                  m.Title,
                                  m.UserFromId,
                                  m.UserFrom,
                                  m.ClientsMessage,
                                  m.Db,
                                  m.CreatedDay,
                                  m.Created,
                                  m.Classification
                              });

                }

            }
            catch (Exception ex)
            {
                throw new Exception("WCFServicePMDS.BAL.MessagesBAL.messagesSent: " + ex.ToString());
            }

        }
        public void xy()
        {
            List<PflegePlan> tblPflegeplaene = (from pp in repo.dbcontext.PflegePlan
                                                join ppdx in repo.dbcontext.PflegePlanPdx on pp.Id equals ppdx.IdpflegePlan
                                                join pdx in repo.dbcontext.Pdx on ppdx.Idpdx equals pdx.Id
                                                join apdx in repo.dbcontext.AufenthaltPdx on ppdx.IdaufenthaltPdx equals apdx.Id
                                                where
                                                    pp.Idaufenthalt == rAufenthalt.Id &&
                                                    (pp.EintragGruppe == "A" || pp.EintragGruppe == "S" || pp.EintragGruppe == "R" || pp.EintragGruppe == "Z" || pp.EintragGruppe == "M") &&
                                                    pp.IduntertaegigeGruppe == ppdx.IduntertaegigeGruppe &&
                                                    apdx.Id == IDAufenthaltPDX &&
                                                    pdx.Id == IDPDX
                                                select pp)
                            .OrderBy(apdx => apdx.ErledigtJn)
                            .OrderBy(ppdx => ppdx.ErledigtJn)
                            .OrderBy(pp => pp.StartDatum)
                            .ToList();

            var tM = (from m in db.Messages
                      join mu in db.MessagesToUsers on m.ID equals mu.IDMessages
                      where m.ClientsMessage == ClientsMessage && m.TypeMessage == TypeMessage && m.IDGuidObject == ENV.USERID &&
                               m.CreatedDay >= dFromTmp.Date && m.CreatedDay <= dToTmp.Date
                      orderby m.Created ascending
                      select new
                      {
                          m.ID,
                          m.IDGuidObject,
                          m.MessagesToUsers,
                          m.Progress,
                          m.sKey,
                          m.Text,
                          m.Title,
                          m.UserFrom,
                          m.UserFromID,
                          m.ClientsMessage,
                          m.Db,
                          m.CreatedDay,
                          m.Created,
                          m.Classification
                      });

        }

        public MessagesDTO newMessage(Guid IDUser, string Username)
        {
            var m = new MessagesDTO() { Id = System.Guid.NewGuid(), Idmessages = System.Guid.NewGuid(), Iduser = IDUser, Readed = false, ReadedAt = null, Username = "" };
            return m;
        }

    }

}
