using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class UrlaubVerlaufDTO
    {
        public Guid Id { get; set; }
        public Guid? Idaufenthalt { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EndeDatum { get; set; }
        public string Text { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public DateTime? DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? ZeitpunktBlisterlisteBeginn { get; set; }
        public DateTime? ZeitpunktBlisterlisteEnde { get; set; }

    }

}

