using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL;
using WCFServicePMDS.DAL.Interfaces;
using WCFServicePMDS.BAL.Interfaces;
using WCFServicePMDS.DAL.DTO;
using WCFServicePMDS.BAL.Main;
using System.Collections.Concurrent;

namespace WCFServicePMDS.BAL
{

    public class AufenthaltBAL : IAufenthaltBAL
    {

        public AufenthaltBAL()
        {

        }

        ///<summary>RAM-Function</summary>
        public static AufenthaltDTO aufenthaltActForPatient(Guid IdPatient)
        {
            ConcurrentBag<AufenthaltDTO> lAufenthalt = Lists.getFirstFromDictConcBag<AufenthaltDTO>(PatientMainDTO.Patient.lAufenthalt);
            List<AufenthaltDTO> lAuf = lAufenthalt.Where(o => o.Idpatient == IdPatient && o.Entlassungszeitpunkt == null).ToList();
            if (lAuf.Count() > 1)
                throw new Exception("aufenthaltActForPatient: more than one act. aufenthalt for IdPatient '" + IdPatient.ToString() + "'");
            return (lAuf.Count() == 1 ? lAuf.First() : null);
        }

    }

}
