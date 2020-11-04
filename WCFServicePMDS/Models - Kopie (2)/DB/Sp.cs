using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Sp
    {
        public Sp()
        {
            Sppe = new HashSet<Sppe>();
            Sppos = new HashSet<Sppos>();
            TblSturzprotokoll = new HashSet<TblSturzprotokoll>();
        }

        public Guid Id { get; set; }
        public DateTime Zeitpunkt { get; set; }
        public Guid IdstandardProzeduren { get; set; }
        public string Anmerkung { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public bool OffenJn { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? EreignisZeitpunkt { get; set; }

        public virtual Aufenthalt IdaufenthaltNavigation { get; set; }
        public virtual Benutzer IdbenutzerErstelltNavigation { get; set; }
        public virtual Benutzer IdbenutzerGeaendertNavigation { get; set; }
        public virtual StandardProzeduren IdstandardProzedurenNavigation { get; set; }
        public virtual ICollection<Sppe> Sppe { get; set; }
        public virtual ICollection<Sppos> Sppos { get; set; }
        public virtual ICollection<TblSturzprotokoll> TblSturzprotokoll { get; set; }
    }
}