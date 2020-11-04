using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientPflegestufeDTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public Guid Idpflegegeldstufe { get; set; }
        public decimal? BetragVerwendbar { get; set; }
        public decimal? GutschriftProTagAbwesend { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? AenderungsantragDatum { get; set; }
        public Guid? IdpflegegeldstufeAntrag { get; set; }
        public DateTime? GenehmigungDatum { get; set; }
        public Guid? IdpflegegeldstufeGenehmigt { get; set; }
        public Guid? Idkostentraeger { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public DateTime? GueltigBis { get; set; }

    }

}

