// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class TblDokumenteneintragSchlagwörter
    {
        public Guid Id { get; set; }
        public Guid Idschlagwort { get; set; }
        public Guid Iddokumenteneintrag { get; set; }

        public virtual TblDokumenteintrag IddokumenteneintragNavigation { get; set; }
        public virtual TblSchlagwörter IdschlagwortNavigation { get; set; }
    }
}