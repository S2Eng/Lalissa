using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.DAL.Interfaces
{


    public interface IPatient
    {
        List<PatientDTO> getPatientAll();
        PatientS1DTO PatientS1(Guid ID);
        PatientDTO getPatientByID(Guid Id);

    }


}
