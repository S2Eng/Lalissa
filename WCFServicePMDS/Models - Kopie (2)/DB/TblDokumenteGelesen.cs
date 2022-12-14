using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblDokumenteGelesen
    {
        public Guid Id { get; set; }
        public Guid Iddokumenteneintrag { get; set; }
        public bool Gelesen { get; set; }
        public int AnzahlBenachrichtigt { get; set; }

        public virtual TblDokumenteintrag IddokumenteneintragNavigation { get; set; }
    }
}