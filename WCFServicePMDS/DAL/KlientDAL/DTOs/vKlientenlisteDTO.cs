using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{
    [Serializable()]
    public class vKlientenlisteDTO
    {
        public string PatientName { get; set; }
        public Nullable<DateTime> Geburtsdatum { get; set; }
        public string Klinik { get; set; }
        public string Abteilung { get; set; }
        public string Bereich { get; set; }
        public Nullable<int> MT1 { get; set; }
        public Nullable<int> MT2 { get; set; }
        public Nullable<int> MT3 { get; set; }
        public Nullable<int> MT4 { get; set; }
        public Nullable<int> MT5 { get; set; }
        public Nullable<int> MT6 { get; set; }
        public Nullable<int> MT7 { get; set; }
        public Nullable<int> MT8 { get; set; }
        public Nullable<int> MT9 { get; set; }
        public Nullable<int> MT10 { get; set; }
        public Nullable<int> MT11 { get; set; }
        public Nullable<int> MT12 { get; set; }
        public Nullable<int> MT13 { get; set; }
        public Nullable<int> MT14 { get; set; }
        public string NächsteEvaluierung { get; set; }
        public string Notfall { get; set; }
        public string Abwesenheit { get; set; }
        public string BezugspersonenIDs { get; set; }
        public Nullable<Guid> IDKlinik { get; set; }
        public Nullable<Guid> IDAbteilung { get; set; }
        public Nullable<Guid> IDBereich { get; set; }
        public Nullable<Guid> IDKlient { get; set; }
        public Nullable<Guid> IDAufenthalt { get; set; }
        public Nullable<int> GesamtesHausJN { get; set; }
        public Nullable<int> MT15 { get; set; }
        public Nullable<int> WundeJN { get; set; }
        public Nullable<DateTime> HAG_VoraussichtichesEnde { get; set; }
        public Nullable<int> DNR { get; set; }
        public Nullable<int> Verstorben { get; set; }
        public Nullable<DateTime> Todeszeitpunkt { get; set; }
        public Nullable<int> AbwesenheitBeendet { get; set; }
        public Nullable<int> Datenschutz { get; set; }
        public Nullable<int> Anatomie { get; set; }
        public Nullable<int> KZUeberlebender { get; set; }
        public Nullable<int> Palliativ { get; set; }

        [Key]
        public Guid IDKey { get; set; }


    }

}

