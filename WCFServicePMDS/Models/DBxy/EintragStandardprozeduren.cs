﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class EintragStandardprozeduren
    {
        public Guid Id { get; set; }
        public Guid Ideintrag { get; set; }
        public Guid IdstandardProzeduren { get; set; }
        public int Reihenfolge { get; set; }

        public virtual Eintrag IdeintragNavigation { get; set; }
        public virtual StandardProzeduren IdstandardProzedurenNavigation { get; set; }
    }
}