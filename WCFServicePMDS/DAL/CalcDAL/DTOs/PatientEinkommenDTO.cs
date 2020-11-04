using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientEinkommenDTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public string Bezeichnung { get; set; }
        public decimal? BetragVerwendbar { get; set; }
        public DateTime GueltigAb { get; set; }
        public DateTime? GueltigBis { get; set; }
        public bool TransferleistungJn { get; set; }
        public Guid? Idbankliste { get; set; }
        public Guid? Idkostentraeger { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public bool SelbstzahlerJn { get; set; }
        public int? Zahlart { get; set; }
        public bool RechnungJn { get; set; }
        public Guid? Idklinik { get; set; }

    }

}

