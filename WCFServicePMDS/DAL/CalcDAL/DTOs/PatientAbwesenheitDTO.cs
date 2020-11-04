using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientAbwesenheitDTO
    {

        public Guid Id { get; set; }
        public Guid Idpatient { get; set; }
        public DateTime Von { get; set; }
        public DateTime? Bis { get; set; }
        public bool BetrifftPflegegeldJn { get; set; }
        public int AbTagN { get; set; }
        public string Grund { get; set; }
        public DateTime? ErfasstAm { get; set; }
        public Guid? Idbenutzer { get; set; }
        public DateTime? AbgerechnetBis { get; set; }
        public string Idüber { get; set; }
        public bool Übersp { get; set; }
        public Guid? Idklinik { get; set; }

    }

}

