using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IAdresse
    {
        List<AdresseDTO> getAdresseAll();
        AdresseDTO getAdress(Nullable<Guid> id);

        Task<ConcurrentBag<AdresseDTO>> getAllAsync(Guid IDClient);



    }


}
