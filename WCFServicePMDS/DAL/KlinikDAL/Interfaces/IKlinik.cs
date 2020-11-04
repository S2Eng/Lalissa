using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IKlinik
    {
        List<KlinikDTO> getKlinikAll();
        Task<ConcurrentBag<KlinikDTO>> getAllAsync(Guid IDClient);
        KlinikS1DTO KlinikS1(Guid ID);
        KlinikDTO KlinikByIdAufenthalt(Guid IDAufenthalt);

    }


}
