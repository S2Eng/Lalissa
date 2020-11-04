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

    public class UrlaubVerlaufBAL : IUrlaubVerlaufBAL
    {

        public UrlaubVerlaufBAL()
        {

        }


        //public static UrlaubVerlaufDTO aufenthaltActForPatient(Guid IdPatient)
        //{
        //    List<UrlaubVerlaufDTO> lUrlaubVerlauf = Lists.getFirstFromDict<UrlaubVerlaufDTO>(PatientMainBAL.Patient.lAufenthalt);
        //    List<UrlaubVerlaufDTO> lAuf = lAufenthalt.Where(o => o.Idpatient == IdPatient && o.Entlassungszeitpunkt == null).ToList();
        //    if (lAuf.Count() > 1)
        //        throw new Exception("aufenthaltActForPatient: more than one act. aufenthalt for IdPatient '" + IdPatient.ToString() + "'");
        //    return (lAuf.Count() == 1 ? lAuf.First() : null);
        //}

    }

}
