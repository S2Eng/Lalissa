using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface ItblSelListGroup
    {
        List<tblSelListGroupDTO> getTblSelListGroupAll();
        Task<ConcurrentBag<tblSelListGroupDTO>> getAllAsync(Guid IDClient);
    }


}
