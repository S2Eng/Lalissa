using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    public class PflegePlanDTO
    {

        public Guid Id { get; set; }
        public Guid Idaufenthalt { get; set; }
        public Guid? Ideintrag { get; set; }
        public Guid? IdbenutzerErstellt { get; set; }
        public Guid? IdbenutzerGeaendert { get; set; }
        public bool? OriginalJn { get; set; }
        public Nullable<DateTime> DatumErstellt { get; set; }
        public DateTime? DatumGeaendert { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EndeDatum { get; set; }
        public DateTime? LetztesDatum { get; set; }
        public DateTime? LetzteEvaluierung { get; set; }
        public string Warnhinweis { get; set; }
        public string Anmerkung { get; set; }
        public string ErledigtGrund { get; set; }
        public string Text { get; set; }
        public int? Intervall { get; set; }
        public int? WochenTage { get; set; }
        public int? IntervallTyp { get; set; }
        public int? EvalTage { get; set; }
        public Guid? Idberufsstand { get; set; }
        public bool? ParalellJn { get; set; }
        public int? Dauer { get; set; }
        public bool? LokalisierungJn { get; set; }
        public bool? EinmaligJn { get; set; }
        public bool? ErledigtJn { get; set; }
        public bool? GeloeschtJn { get; set; }
        public string Lokalisierung { get; set; }
        public string LokalisierungSeite { get; set; }
        public string EintragGruppe { get; set; }
        public bool? Pdxjn { get; set; }
        public bool RmoptionalJn { get; set; }
        public bool UntertaegigeJn { get; set; }
        public bool SpenderAbgabeJn { get; set; }
        public Guid? IduntertaegigeGruppe { get; set; }
        public int BarcodeId { get; set; }
        public Guid? IdlinkDokument { get; set; }
        public DateTime? NaechsteEvaluierung { get; set; }
        public string NaechsteEvaluierungBemerkung { get; set; }
        public bool OhneZeitBezug { get; set; }
        public Guid? Idzeitbereich { get; set; }
        public DateTime? ZuErledigenBis { get; set; }
        public bool Wundejn { get; set; }
        public int EintragFlag { get; set; }
        public DateTime? NächstesDatum { get; set; }
        public Guid? Iddekurs { get; set; }
        public bool PrivatJn { get; set; }
        public Guid? Idextern { get; set; }
        public DateTime? StartdatumNeu { get; set; }
        public string LstIdpdx { get; set; }
        public string LstPdxBezeichnung { get; set; }
        public string AnmerkungRtf { get; set; }
        public Guid? Idbefund { get; set; }
        public string Verordnungen { get; set; }
        public string LogInNameFrei { get; set; }


    }

}

