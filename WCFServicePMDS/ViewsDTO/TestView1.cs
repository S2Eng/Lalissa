using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TestView1
    {
        public TestView1()
        {

        }

        public Guid ID { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public string Benutzer { get; set; }
        public bool AktivJN { get; set; }

        public string Signatur { get; set; }
    }
}


// -------------------------------------------------------------------------------------------------------------
// in Klasse     public partial class PMDSDevContext : DbContext     >>>   integrieren in Klasse nach Model-Generierung:
//
//public virtual DbSet<TestView1> TestView1 { get; set; }
//public virtual DbSet<vInterventionen2> vInterventionen2 { get; set; }
//public virtual DbSet<vKlientenliste2> vKlientenliste2 { get; set; }
//public virtual DbSet<vÜbergabe2> vÜbergabe2 { get; set; }

