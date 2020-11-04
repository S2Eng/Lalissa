using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class AufenthaltDTO
    {

        public Guid Id { get; set; }
        public Guid? Idpatient { get; set; }
        public Guid? Idabteilung { get; set; }
        public Guid? IdaufenthaltVerlauf { get; set; }
        public Guid IdbenutzerAufnahme { get; set; }
        public Guid? IdbenutzerEntlassung { get; set; }
        public Guid? IdeinrichtungAufnahme { get; set; }
        public Guid? IdeinrichtungEntlassung { get; set; }
        public DateTime? Aufnahmezeitpunkt { get; set; }
        public DateTime? Entlassungszeitpunkt { get; set; }
        public int? AufnahmeArt { get; set; }
        public string BegleitungVon { get; set; }
        public string Entlassungsbemerkung { get; set; }
        public string SomatischeAuff { get; set; }
        public string PsychischeAuff { get; set; }
        public string VerhaltenAufnahme { get; set; }
        public string SonstigeBesonderheiten { get; set; }
        public string SofortMassnahmen { get; set; }
        public Guid? Idurlaub { get; set; }
        public int BarcodeId { get; set; }
        public double? Fallnummer { get; set; }
        public string Gruppenkennzahl { get; set; }
        public DateTime? Verfuegungsdatum { get; set; }
        public string Bermerkung { get; set; }
        public string Besuchsregelung { get; set; }
        public string Postregelung { get; set; }
        public string SonstigeRegelung { get; set; }
        public string Erwartungen { get; set; }
        public Guid? Iderstkontakt { get; set; }
        public double? Gewicht { get; set; }
        public DateTime? NaechsteEvaluierung { get; set; }
        public string NaechsteEvaluierungBemerkung { get; set; }
        public double? TaschengeldSollstand { get; set; }
        public DateTime? TaschegeldVortragDatum { get; set; }
        public double? TaschengeldVortragBetrag { get; set; }
        public double Ausgleichszahlung { get; set; }
        public Guid? Idklinik { get; set; }
        public Guid? Idbereich { get; set; }
        public bool AbwesenheitBeendet { get; set; }
        //public string InfoDienstuebergabe { get; set; }
        public DateTime? ZeitpunktBlisterlisteAufnahme { get; set; }
        public DateTime? ZeitpunktBlisterlisteEntlassung { get; set; }
        public bool Elgasoojn { get; set; }
        public DateTime? Elgassoodatum { get; set; }
        public string Elgasooiduser { get; set; }
        public string Elgasoogrund { get; set; }
        public DateTime? Soozeitpunkt { get; set; }
        public string ElgacontactId { get; set; }

    }

}

