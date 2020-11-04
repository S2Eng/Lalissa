using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class DocumentSearchDto
    {
        public string Documentname { get; set; }
        public Nullable<DateTime> CreatedFrom { get; set; }
        public Nullable<DateTime> CreatedTo { get; set; }
        public string Author { get; set; }
        public string DocumentStatus { get; set; }
        public string UniqueID { get; set; }
    }

    [Serializable()]
    public class DocumentAddDto
    {
        public string Documentname { get; set; }
        public byte[] bDocument { get; set; }

        public string Author { get; set; }
        public string Person { get; set; }

        public string KlinikName { get; set; }
        public string KlinikOID { get; set; }
        public string KlinikOrganisationID { get; set; }

        public string Description { get; set; }


        public string IDCDA { get; set; }
        public string ClinicalDocumentSetID { get; set; }
    }

    [Serializable()]
    public class ELGADocumentsDTO
    {
        public string UUID { get; set; }
        public string UniqueId { get; set; }
        public string LogicalId { get; set; }

        public string Documentname { get; set; }
        public string TypeFile { get; set; }
        public string Author { get; set; }
        public string CreationTime { get; set; }
        public string Description { get; set; }
        public string DocStatus { get; set; }
        public int Size { get; set; }
        public string Version { get; set; }

        public List<String> ReferenceIdList { get; set; }


        public byte[] bdocument { get; set; }
        
    }



}

