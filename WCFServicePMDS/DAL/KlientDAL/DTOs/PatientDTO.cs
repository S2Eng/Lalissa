using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServicePMDS.Models.DB;


namespace WCFServicePMDS.DAL.DTO
{

    [Serializable()]
    public class PatientDTO
    {

        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Titel { get; set; }
        public string Sexus { get; set; }
        public string Konfision { get; set; }
        public string Familienstand { get; set; }
        public string Staatsb { get; set; }
        public string Klasse { get; set; }
        public string KrankenKasse { get; set; }
        public string BlutGruppe { get; set; }
        public string Resusfaktor { get; set; }
        public string LedigerName { get; set; }
        public string Geburtsort { get; set; }
        public string Voraufenthalt { get; set; }
        public string Angehörige { get; set; }
        public string VersicherungsNr { get; set; }
        public string ArbeitslosBezSeit { get; set; }
        public string KrankengeldSeit { get; set; }
        public string Hauptversicherung { get; set; }
        public string ErlernterBeruf { get; set; }
        public string Besonderheit { get; set; }
        public string Betreuer { get; set; }
        public string Sachwalter { get; set; }
        public string SachWalterBelange { get; set; }
        public DateTime? SachWalterVon { get; set; }
        public DateTime? SachWalterBis { get; set; }
        public string SterbeRegel { get; set; }
        public string Depotinjektion { get; set; }
        public string Hausarzt { get; set; }
        public string Vermerk { get; set; }
        public DateTime? SterbeDatum { get; set; }
        public string AktuellerDienstgeber { get; set; }
        public string DerzeitigerBeruf { get; set; }
        public bool RezeptgebuehrbefreiungJn { get; set; }
        public bool PflegegeldantragJn { get; set; }
        public DateTime? DatumPflegegeldantrag { get; set; }
        public bool PensionsteilungsantragJn { get; set; }
        public DateTime? DatumPensionsteilungsantrag { get; set; }
        public string Fibukonto { get; set; }
        public DateTime? RollungVon { get; set; }
        public DateTime? RollungBis { get; set; }
        public string Adelstitel { get; set; }
        public string Anrede { get; set; }
        public string Initialberuehrung { get; set; }
        public string Klingeln { get; set; }
        public string Wohnsituation { get; set; }
        public string Haustier { get; set; }
        public bool? LiftJn { get; set; }
        public bool? WohnungAbgemeldetJn { get; set; }
        public string Haarfarbe { get; set; }
        public string Augenfarbe { get; set; }
        public string BesondereAeusserlicheKennzeichen { get; set; }
        public bool? FernsehgebuehrbefreiungJn { get; set; }
        public bool? TelefongebuehrbefreiungJn { get; set; }
        public bool? BewerberJn { get; set; }
        public bool? BewerbungaktivJn { get; set; }
        public string PflegeArt { get; set; }
        public DateTime? BewerbungDatum { get; set; }
        public DateTime? EinzugswunschDatum { get; set; }
        public DateTime? AuszugswunschDatum { get; set; }
        public string Zimmerwunsch { get; set; }
        public string Stationswunsch { get; set; }
        public string SonstigeWuensche { get; set; }
        public string BewerbungsGrund { get; set; }
        public string Prioritaet { get; set; }
        public string ReligionWunsch { get; set; }
        public bool? KommunionJn { get; set; }
        public bool? KrankensalbungJn { get; set; }
        public string BewerberBemerkung { get; set; }
        public string WaescheMarkiert { get; set; }
        public string WaescheWaschen { get; set; }
        public string ZustaendigeStelle { get; set; }
        public int? Groesse { get; set; }
        public string Statur { get; set; }
        public DateTime? Namenstag { get; set; }
        public string Kosename { get; set; }
        public string Privatversicherung { get; set; }
        public string PrivPolNr { get; set; }
        public Guid? Idbenutzer { get; set; }
        public bool? PatientenverfuegungJn { get; set; }
        public bool? PatientenverfuegungBeachtlichJn { get; set; }
        public DateTime? PatientverfuegungDatum { get; set; }
        public string PatientverfuegungAnmerkung { get; set; }
        public string Klientennummer { get; set; }
        public Guid? Idabteilung { get; set; }
        public bool AbwesenheitenHändBerech { get; set; }
        public decimal Sollstand { get; set; }
        public decimal MinSaldo { get; set; }
        public string Kennwort { get; set; }
        //public byte[] BlobEinverständniserklärung { get; set; }
        public string EinverständniserklärungFileType { get; set; }
        //public byte[] JpgEinverständniserklärung { get; set; }
        public bool Verstorben { get; set; }
        public DateTime? Todeszeitpunkt { get; set; }
        public bool Dnr { get; set; }
        public bool Milieubetreuung { get; set; }
        public bool Kzueberlebender { get; set; }
        public bool Anatomie { get; set; }
        public bool Einzelzimmer { get; set; }
        public bool Selbstzahler { get; set; }
        public Guid? Idbereich { get; set; }
        public bool KürzungLetzterTagAnwesenheit { get; set; }
        public bool Behindertenausweis { get; set; }
        public bool Sozialcard { get; set; }
        public Guid? IdadresseSub { get; set; }
        public Guid? IdkontaktSub { get; set; }
        public string Betreuungsstufe { get; set; }
        public DateTime? BetreuungsstufeAb { get; set; }
        public DateTime? BetreuungsstufeBis { get; set; }
        public string LstSprachen { get; set; }
        public DateTime? RezGebBefRegoAb { get; set; }
        public DateTime? RezGebBefRegoBis { get; set; }
        public bool RezGebBefUnbefristetJn { get; set; }
        public bool RezGebBefBefristetJn { get; set; }
        public DateTime? RezGebBefBefristetBis { get; set; }
        public bool RezGebBefWiderrufJn { get; set; }
        public string RezGebBefWiderrufGrund { get; set; }
        public bool RezGebBefRegoJn { get; set; }
        public DateTime? RezGebBefBefristetAb { get; set; }
        public bool RezGebBefSachwalterJn { get; set; }
        public bool Datenschutz { get; set; }
        public bool Palliativ { get; set; }
        public int AmputationProzent { get; set; }
        public int TageAbweseneheitOhneKuerzung { get; set; }
        public string RezGebBefAnmerkung { get; set; }

        public string SozVersStatus { get; set; }
        public string SozVersLeerGrund { get; set; }
        public string SozVersMitversichertBei { get; set; }
        public string TitelPost { get; set; }
        public string BPk { get; set; }
    }

    public class PatientS1DTO
    {
        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Titel { get; set; }
        public string VersicherungsNr { get; set; }
        public string Sexus { get; set; }
        public DateTime? Geburtsdatum { get; set; }
        public string Familienstand { get; set; }
        public bool? WohnungAbgemeldetJn { get; set; }
        public string Konfision { get; set; }
        public string LstSprachen { get; set; }
        public string KrankenKasse { get; set; }
        public string SozVersStatus { get; set; }
        public string SozVersLeerGrund { get; set; }
        public string SozVersMitversichertBei { get; set; }
        public string BPk { get; set; }
    }

}

