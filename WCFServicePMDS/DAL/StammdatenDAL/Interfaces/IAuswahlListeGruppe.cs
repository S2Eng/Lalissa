using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IAuswahlListeGruppe
    {
        List<AuswahlListeGruppeDTO> getAuswahlGruppeAll();
        Task<ConcurrentBag<AuswahlListeGruppeDTO>> getAllAsync(Guid IDClient);
    }


}
