using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ELGASessionDTO
    {
        public Guid IDUser { get; set; }

        public string ELGAStateID { get; set; }

        public string Errors { get; set; }

    }

    [Serializable()]
    public class ELGAParInDto
    {
        public ELGASessionDTO session { get; set; }
        public Guid IDPatientIntern { get; set; }
        public string LocalPatientID { get; set; }
        public string ContactID { get; set; }
        public Guid IDDocuIntern { get; set; }

        public ObjectDTO sObjectDto { get; set; }
        public DocumentSearchDto sDocumentsDto { get; set; }
        public DocumentAddDto DocumentAdd { get; set; }
        public string authUniversalID { get; set; }

    }

    [Serializable()]
    public class ELGAParOutDto
    {
        public bool bOK { get; set; }
        public int iRowsFound { get; set; }

        public bool bErrorsFound { get; set; }
        public string MessageException { get; set; }
        public int MessageExceptionNr { get; set; }

        public string ContactID { get; set; }
        public List<ELGAPatientDTO> lPatients { get; set; }
        public List<ObjectDTO> lGDAs { get; set; }
        public List<ELGAContactsDto> lContacts { get; set; }
        public List<ELGADocumentsDTO> lDocuments { get; set; }
        public string DocuUniqueId { get; set; }

        public List<ELGAErrorDTO> lstErrors { get; set; }
        public string Errors { get; set; }
        public bool ContactExists { get; set; }
    }

}

