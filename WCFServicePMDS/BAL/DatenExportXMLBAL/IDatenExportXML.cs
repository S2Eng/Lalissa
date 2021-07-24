using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.DAL.DTO;

namespace WCFServicePMDS.BAL.Interfaces
{

    public interface IDatenExportXML
    {
       bool Export(Guid IDClient, System.Guid IDPatient, ref string ArchivPath, out string FileNameXMLDocumentBack, bool IsTest);
    }
}
