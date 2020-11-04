using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.BAL.Main.Interfaces
{

    public interface IStammdatenBAL
    {
        StammdatenDTO load(ref DateTime dFrom, Guid IDClient);


    }

}
