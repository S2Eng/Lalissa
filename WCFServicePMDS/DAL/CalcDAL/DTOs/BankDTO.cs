using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class BankDTO
    {

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Kontonummer { get; set; }
        public int Blz { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public Guid? Idklinik { get; set; }

    }

}

