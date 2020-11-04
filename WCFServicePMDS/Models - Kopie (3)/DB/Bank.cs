using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Bank
    {
        public Bank()
        {
            Klinik = new HashSet<Klinik>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Kontonummer { get; set; }
        public int Blz { get; set; }
        public string Iban { get; set; }
        public string Bic { get; set; }
        public Guid? Idklinik { get; set; }

        public virtual ICollection<Klinik> Klinik { get; set; }
    }
}