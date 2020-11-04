using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface ISachwalter
    {
        List<SachwalterDTO> getSachwalterAll();
        List<SachwalterS1DTO> SachwalterS1(Guid idpatient, DateTime d);

    }


}
