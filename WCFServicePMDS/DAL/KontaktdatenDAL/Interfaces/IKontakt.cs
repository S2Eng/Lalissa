using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IKontakt
    {
        List<KontaktDTO> getKontaktAll();
        KontaktDTO getKontakt(Nullable<Guid> id);

        Task<ConcurrentBag<KontaktDTO>> getAllAsync(Guid IDClient);


    }


}
