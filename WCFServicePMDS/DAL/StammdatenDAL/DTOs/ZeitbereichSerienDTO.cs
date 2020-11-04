using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class ZeitbereichSerienDTO
    {
        public Guid Id { get; set; }
        public string Bezeichnung { get; set; }
        public Guid? Idzeitbereich0 { get; set; }
        public Guid? Idzeitbereich1 { get; set; }
        public Guid? Idzeitbereich2 { get; set; }
        public Guid? Idzeitbereich3 { get; set; }
        public Guid? Idzeitbereich4 { get; set; }
        public Guid? Idzeitbereich5 { get; set; }
        public Guid? Idzeitbereich6 { get; set; }
        public Guid? Idzeitbereich7 { get; set; }



    }

}

