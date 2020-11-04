using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class FormularDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bezeichnung { get; set; }
        public string Blop { get; set; }
        public bool Gui { get; set; }
        public bool InNotfallAnzeigenJn { get; set; }
        //public byte[] PdfBlop { get; set; }
        public bool NeuanlageSperren { get; set; }
        public string LstIdberufsgruppe { get; set; }
    }

}

