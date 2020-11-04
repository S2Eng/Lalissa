using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServicePMDS.BAL2.ELGABAL
{

    [Serializable()]
    public class ELGAPatientDTO
    {
        public Guid ID { get; set; }
        public Nullable<Guid> IDPatientDB { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
        public string middleName { get; set; }
        public string birthdate { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string streetAddress { get; set; }
        public string country { get; set; }
        public string nationality { get; set; }
        public string sex { get; set; }
        public string citizenship { get; set; }
        public string city { get; set; }
        public string deathdate { get; set; }
        public string emailHome { get; set; }
        public string emailBusiness { get; set; }
        public string ethnicGroup { get; set; }
        public string homePhone { get; set; }
        public string businessPhone { get; set; }
        public string degree { get; set; }
        public string maritalStatus { get; set; }
        public string secondFamilyName { get; set; }
        public string secondGivenName { get; set; }
        public string secondMiddleName { get; set; }
        public string nameTypeCode { get; set; }
        public bool lastUpdtateTimeSpecified { get; set; }
        public Nullable<DateTime> lastUpdtateTime { get; set; }

        public List<ELGAPidsDTO> ELGAPids { get; set; }
        public List<ELGADocumentsDTO> ELGADocuments { get; set; }
    }

}

