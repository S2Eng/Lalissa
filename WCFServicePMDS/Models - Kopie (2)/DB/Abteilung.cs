using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Abteilung
    {
        public Abteilung()
        {
            Aufenthalt = new HashSet<Aufenthalt>();
            AufenthaltVerlaufIdabteilungNachNavigation = new HashSet<AufenthaltVerlauf>();
            AufenthaltVerlaufIdabteilungVonNavigation = new HashSet<AufenthaltVerlauf>();
            Belegung = new HashSet<Belegung>();
            Bereich = new HashSet<Bereich>();
            Pdxeintrag = new HashSet<Pdxeintrag>();
            Pdxgruppe = new HashSet<Pdxgruppe>();
            PflegeEintrag = new HashSet<PflegeEintrag>();
            PflegeEintragEntwurf = new HashSet<PflegeEintragEntwurf>();
        }

        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idklinik { get; set; }
        public Guid? Idkontakt { get; set; }
        public bool RmoptionalJn { get; set; }
        public int Reihenfolge { get; set; }
        public bool Basisabteilung { get; set; }

        public virtual Klinik IdklinikNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<Aufenthalt> Aufenthalt { get; set; }
        public virtual ICollection<AufenthaltVerlauf> AufenthaltVerlaufIdabteilungNachNavigation { get; set; }
        public virtual ICollection<AufenthaltVerlauf> AufenthaltVerlaufIdabteilungVonNavigation { get; set; }
        public virtual ICollection<Belegung> Belegung { get; set; }
        public virtual ICollection<Bereich> Bereich { get; set; }
        public virtual ICollection<Pdxeintrag> Pdxeintrag { get; set; }
        public virtual ICollection<Pdxgruppe> Pdxgruppe { get; set; }
        public virtual ICollection<PflegeEintrag> PflegeEintrag { get; set; }
        public virtual ICollection<PflegeEintragEntwurf> PflegeEintragEntwurf { get; set; }
    }
}