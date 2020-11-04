using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class BarcodeQ
    {
        public string ScannerId { get; set; }
        public DateTime? ScanZeitpunkt { get; set; }
        public string Barcode { get; set; }
        public bool? FertigJn { get; set; }
        public Guid? IduserVerarbeitet { get; set; }
        public DateTime? DatumVerarbeitet { get; set; }
        public Guid? Idpflegeplan { get; set; }
        public Guid? IduserIdskipped { get; set; }
        public string ScannerZeitpunktChar { get; set; }
        public int Id { get; set; }
    }
}