using System;
using System.Collections.Generic;

namespace WCFServicePMDS.Models.DB
{
    public partial class Benutzer
    {
        public Benutzer()
        {
            AnamneseOrem = new HashSet<AnamneseOrem>();
            Arztabrechnung = new HashSet<Arztabrechnung>();
            AufenthaltIdbenutzerAufnahmeNavigation = new HashSet<Aufenthalt>();
            AufenthaltIdbenutzerEntlassungNavigation = new HashSet<Aufenthalt>();
            AufenthaltVerlauf = new HashSet<AufenthaltVerlauf>();
            BenutzerEinrichtung = new HashSet<BenutzerEinrichtung>();
            BenutzerRechte = new HashSet<BenutzerRechte>();
            BereichBenutzer = new HashSet<BereichBenutzer>();
            DokumenteIdbenutzerErstelltNavigation = new HashSet<Dokumente>();
            DokumenteIdbenutzerGeaendertNavigation = new HashSet<Dokumente>();
            Elgaprotocoll = new HashSet<Elgaprotocoll>();
            GegenstaendeIdbenutzerausgegebenNavigation = new HashSet<Gegenstaende>();
            GegenstaendeIdbenutzerzurueckNavigation = new HashSet<Gegenstaende>();
            MedizinischeDaten = new HashSet<MedizinischeDaten>();
            Patient = new HashSet<Patient>();
            PatientenBemerkung = new HashSet<PatientenBemerkung>();
            PflegeEintrag = new HashSet<PflegeEintrag>();
            PflegeEintragEntwurf = new HashSet<PflegeEintragEntwurf>();
            PflegePlanHIdbenutzerErstelltNavigation = new HashSet<PflegePlanH>();
            PflegePlanHIdbenutzerGeaendertNavigation = new HashSet<PflegePlanH>();
            PflegePlanIdbenutzerErstelltNavigation = new HashSet<PflegePlan>();
            PflegePlanIdbenutzerGeaendertNavigation = new HashSet<PflegePlan>();
            PflegePlanPdxIdbenutzerBeendetNavigation = new HashSet<PflegePlanPdx>();
            PflegePlanPdxIdbenutzerErstelltNavigation = new HashSet<PflegePlanPdx>();
            SpIdbenutzerErstelltNavigation = new HashSet<Sp>();
            SpIdbenutzerGeaendertNavigation = new HashSet<Sp>();
            SpposIdbenutzerErstelltNavigation = new HashSet<Sppos>();
            SpposIdbenutzerGeaendertNavigation = new HashSet<Sppos>();
            Taschengeld = new HashSet<Taschengeld>();
            TblFortbildungBenutzer = new HashSet<TblFortbildungBenutzer>();
            VoBestelldaten = new HashSet<VoBestelldaten>();
            VoMedizinischeDatenIdbenutzerErstelltNavigation = new HashSet<VoMedizinischeDaten>();
            VoMedizinischeDatenIdbenutzerGeaendertNavigation = new HashSet<VoMedizinischeDaten>();
            VoPflegeplanPdxIdbenutzerErstelltNavigation = new HashSet<VoPflegeplanPdx>();
            VoPflegeplanPdxIdbenutzerGeaendertNavigation = new HashSet<VoPflegeplanPdx>();
            VoWundeIdbenutzerErstelltNavigation = new HashSet<VoWunde>();
            VoWundeIdbenutzerGeaendertNavigation = new HashSet<VoWunde>();
        }

        public Guid Id { get; set; }
        public Guid? Idadresse { get; set; }
        public Guid? Idkontakt { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Benutzer1 { get; set; }
        public string Passwort { get; set; }
        public bool? AktivJn { get; set; }
        public bool? PflegerJn { get; set; }
        public Guid? Idberufsstand { get; set; }
        public int BarcodeId { get; set; }
        public DateTime? Eintrittsdatum { get; set; }
        public DateTime? Austrittsdatum { get; set; }
        public string SmtpSrv { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpAbsender { get; set; }
        public string SmtpPwd { get; set; }
        public bool SmtpAuthentStandard { get; set; }
        public bool IsGeneric { get; set; }
        public Guid? Idarzt { get; set; }
        public bool ArztabrechnungJn { get; set; }
        public string Signatur { get; set; }
        public string Elgauser { get; set; }
        public string ElgapatId { get; set; }
        public bool Elgaactive { get; set; }
        public bool ElgaautoLogin { get; set; }
        public bool ElgaautostartSession { get; set; }
        public DateTime? ElgavalidTrough { get; set; }
        public string ElgaAuthorSpeciality { get; set; }
        public string Elgapwd { get; set; }
        public DateTime? ElgapwdLastChange { get; set; }

        public virtual Adresse IdadresseNavigation { get; set; }
        public virtual AuswahlListe IdberufsstandNavigation { get; set; }
        public virtual Kontakt IdkontaktNavigation { get; set; }
        public virtual ICollection<AnamneseOrem> AnamneseOrem { get; set; }
        public virtual ICollection<Arztabrechnung> Arztabrechnung { get; set; }
        public virtual ICollection<Aufenthalt> AufenthaltIdbenutzerAufnahmeNavigation { get; set; }
        public virtual ICollection<Aufenthalt> AufenthaltIdbenutzerEntlassungNavigation { get; set; }
        public virtual ICollection<AufenthaltVerlauf> AufenthaltVerlauf { get; set; }
        public virtual ICollection<BenutzerEinrichtung> BenutzerEinrichtung { get; set; }
        public virtual ICollection<BenutzerRechte> BenutzerRechte { get; set; }
        public virtual ICollection<BereichBenutzer> BereichBenutzer { get; set; }
        public virtual ICollection<Dokumente> DokumenteIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<Dokumente> DokumenteIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<Elgaprotocoll> Elgaprotocoll { get; set; }
        public virtual ICollection<Gegenstaende> GegenstaendeIdbenutzerausgegebenNavigation { get; set; }
        public virtual ICollection<Gegenstaende> GegenstaendeIdbenutzerzurueckNavigation { get; set; }
        public virtual ICollection<MedizinischeDaten> MedizinischeDaten { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<PatientenBemerkung> PatientenBemerkung { get; set; }
        public virtual ICollection<PflegeEintrag> PflegeEintrag { get; set; }
        public virtual ICollection<PflegeEintragEntwurf> PflegeEintragEntwurf { get; set; }
        public virtual ICollection<PflegePlanH> PflegePlanHIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<PflegePlanH> PflegePlanHIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<PflegePlan> PflegePlanIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<PflegePlan> PflegePlanIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<PflegePlanPdx> PflegePlanPdxIdbenutzerBeendetNavigation { get; set; }
        public virtual ICollection<PflegePlanPdx> PflegePlanPdxIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<Sp> SpIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<Sp> SpIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<Sppos> SpposIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<Sppos> SpposIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<Taschengeld> Taschengeld { get; set; }
        public virtual ICollection<TblFortbildungBenutzer> TblFortbildungBenutzer { get; set; }
        public virtual ICollection<VoBestelldaten> VoBestelldaten { get; set; }
        public virtual ICollection<VoMedizinischeDaten> VoMedizinischeDatenIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<VoMedizinischeDaten> VoMedizinischeDatenIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<VoPflegeplanPdx> VoPflegeplanPdxIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<VoPflegeplanPdx> VoPflegeplanPdxIdbenutzerGeaendertNavigation { get; set; }
        public virtual ICollection<VoWunde> VoWundeIdbenutzerErstelltNavigation { get; set; }
        public virtual ICollection<VoWunde> VoWundeIdbenutzerGeaendertNavigation { get; set; }
    }
}