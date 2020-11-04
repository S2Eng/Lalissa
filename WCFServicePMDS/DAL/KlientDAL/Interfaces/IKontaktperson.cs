using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IKontaktperson
    {
        List<KontaktpersonDTO> getKontaktpersonAll();
        List<KontaktpersonS1DTO> KontaktpersonS1(Guid idpatient);

    }


}
