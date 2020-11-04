using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IAerzte
    {
        List<AerzteDTO> getAerzteAll();
        List<AerzteDTO> AerzteS1(Guid id);

        List<AerzteDTO> AerzteS1ByELGAHausarzt(Guid Idpatient);

    }


}
