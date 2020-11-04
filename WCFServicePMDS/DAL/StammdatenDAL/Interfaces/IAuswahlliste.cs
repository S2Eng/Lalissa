using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IAuswahlliste
    {
        List<AuswahlListeDTO> getAuswahlListeAll();
        Task<ConcurrentBag<AuswahlListeDTO>> getAllAsync(Guid IDClient);

        AuswahlListeS1DTO AuswahlListeS1(string ElgaCode, string IdauswahlListeGruppe);
    }


}
