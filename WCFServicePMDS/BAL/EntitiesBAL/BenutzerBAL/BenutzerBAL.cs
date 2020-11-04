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

    public class BenutzerBAL : IBenutzerBAL
    {

        public BenutzerBAL()
        {

        }



        public List<BenutzerDTO> getBenutzerAll(Guid IDClient)
        {
            IBenutzerDAL _benDAL = new BenutzerDAL(new WCFServicePMDS.Repository.RepositoryWrapper(IDClient));
            return _benDAL.getBenutzerAll();

            //using (Models.DB.PMDSDevContext context = DAL.dbBase.CreateContextEFCorePMDS())
            //{
            //    IBenutzerDAL _benDAL = new BenutzerDAL(new WCFServicePMDS.Repository.RepositoryWrapper(context));
            //    return _benDAL.getBenutzerAll();
            //}
        }

    }

}
