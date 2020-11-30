﻿using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class FormularDaten
    {
        public FormularDaten()
        {
            FormularDatenFelder = new HashSet<FormularDatenFelder>();
        }

        public Guid Id { get; set; }
        public Guid Idref { get; set; }
        public string FormularName { get; set; }
        public string Blop { get; set; }
        public DateTime Datumerstellt { get; set; }
        public DateTime DatumGeaendert { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }
        public byte[] PdfBlop { get; set; }

        public virtual ICollection<FormularDatenFelder> FormularDatenFelder { get; set; }
    }
}