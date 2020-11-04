using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class LinkDokumenteDTO
    {
        public Guid Id { get; set; }
        public string Beschreibung { get; set; }
        public string LinkName { get; set; }
        //public byte[] Dokument { get; set; }
        public string Gruppe { get; set; }
        public DateTime Erstellungsdatum { get; set; }
        public DateTime Aenderungsdatum { get; set; }
        public Guid IdbenutzerErstellt { get; set; }
        public Guid IdbenutzerGeaendert { get; set; }


    }

}

