﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class ZusatzGruppeEintrag
    {
        public ZusatzGruppeEintrag()
        {
            ZusatzWert = new HashSet<ZusatzWert>();
        }

        public Guid Id { get; set; }
        public string IdzusatzGruppe { get; set; }
        public string IdzusatzEintrag { get; set; }
        public Guid? Idobjekt { get; set; }
        public Guid? Idfilter { get; set; }
        public bool? OptionalJn { get; set; }
        public bool? DruckenJn { get; set; }
        public int? Reihenfolge { get; set; }

        public virtual ZusatzEintrag IdzusatzEintragNavigation { get; set; }
        public virtual ZusatzGruppe IdzusatzGruppeNavigation { get; set; }
        public virtual ICollection<ZusatzWert> ZusatzWert { get; set; }
    }
}