using System;
using System.ComponentModel;




namespace PMDS.Global
{

    public enum eTypeUIUnterbringung
    {
        Verlängern = 0,
        HistoryAnzeigen = 1,
        Aufheben = 2,
        AddUnterbringung = 3,

    }
    public enum eDekursherkunft
    {
        DekursAusIntervention = 0,
        DekursAusÜbergabe = 1,
        DekursAusMitBereich = 2,
        DekursAusMedDiagnosenPatient = 3,
        MassnahmenRückmeldungAusIntervention = 4,
        BedarfsmedikamentationAusIntervention = 5,
        UngeplanteMassnahmeRückmeldenAusIntervention = 6,
        DekursAusTermin = 7,

        none = -1
    }

    public enum eDekursDefaults
    {
        DekursMVB = 1,
        DekursIntervention = 2,
        DekursMedDiag = 3,
        DekursÜbergabe = 4,
        Einzelfallmedikation = 5,
        Intervention = 6,
        UngeplanteMaßnahme = 7,
        Medikation = 8,
        NeueWunde = 9,
        NeueWundtherapie = 10,
        NeuerWundeintrag = 11,
        NeuesAssessment = 12,
        BefundimportTermin = 13,
        MedikationÄnderung = 14
    }

    public enum eUITypeTermine
    {
        Interventionen = 0,
        Übergabe = 1,
        Dekurs = 2,
        None = 100
    }
    public enum eUITypeDekurs
    {
        MehereKlienten = 0,
        EinKlient = 1,
    }

    
    public enum eModusTermine
    {
        MitZeitbezug = 0,
        OhneZeitbezug = 1,
        MitPflegediagnoseAbzeichnen = 2,
        OhnePflegediagnoseAbzeichnen = 3
    }

    public enum MedizinischerTyp
    {
        [Description("Aktuelle Medizinische Diagnosen!")]
        AktuelleDiagnosen = 1,
        [Description("Medizinische Dauerdiagnosen!")]
        DauerDiagnosen = 2,
        [Description("Allergien")]
        Allergien = 3,
        [Description("Infektionen")]
        Infektionen = 4,
        [Description("Kostform")]
        Kostform = 5,
        [Description("Unverträglichkeiten")]
        Unvertraeglichkeiten = 6,
        [Description("Suchtmittel")]
        Suchtmittel = 7,
        [Description("Impfungen")]
        Impfungen = 8,
        [Description("Sonstige")]
        Sonstige = 9,
        [Description("Katheter / Sonden / Stomata")]
        KathederSondenStomata = 10,
        [Description("Implantate / Prothesen")]
        ImplentateProthesen = 11,
        [Description("Antikoagulation")]
        Antikoagulation = 12,
        [Description("Diabetes")]
        Diabetes = 13,
        [Description("Nüchtern")]
        Nuechtern = 14,
        [Description("Befunde")]
        Befunde = 15,

        [Description("Datenschutz")]
        Datenschutz = 101,
        [Description("DNR")]
        DNR = 102,
        [Description("Holocoust")]
        Holocoust = 103,
        [Description("Rezeptgebührenbefreit")]
        Rezeptgebührenbefreit = 104,
        [Description("AbwesenheitBeendet")]
        AbwesenheitBeendet = 105,
        [Description("Geburtstag")]
        Geburtstag = 106,
        [Description("Wunde")]
        Wunde = 107,
        [Description("Abwesenheit")]
        Abwesenheit = 108,
        [Description("Wichtige Information")]
        WichtigeInformation = 109,
    }


    public enum PDxLokalisierungsTypen
    {
        Kann = 0,
        Muss = 1,
        KannNicht = 2
    }



    //13.04.2007 von MDA erweitert
    public enum PflegeModelle
    {
        Orem = 0, 
        Krohwinkel,
        Juchli,
        Nanda,
        RAI,
        RT,
        Biografie = 10,
        POP = 11
    }

    //13.04.2007 MDA
    public enum OremModellgruppen
    {
        Luft = 1,
        Wasser,
        Nahrung,
        Ausscheidung,
        AktivitaetUndRuhe,
        AlleinseinUndSozialeInteraktion,
        AbwendenVonGefahren,
        IntegritaetDerPerson
    }


    //01.06.2011 os
    public enum POPModellgruppen
    {
        Luft = 1,
        Wasser,
        Nahrung,
        Ausscheidung,
        AktivitaetUndRuhe,
        AlleinseinUndSozialeInteraktion,
        AbwendenVonGefahren,
        IntegritaetDerPerson,
        SozialesUmfeld
    }

    public enum eSendMain
    {
        medizinDataChanged = 1,
        abrechnung   = 2,
        intervention = 3,
        historieOnOff = 4,
        checkEdited = 5,
        singleElementActivated = 6,
        setIDSingleElement = 7,
        setIDMultiElement = 8,
        ShowMessagesUnread = 9
    }

    public enum KrohwinkelModellgruppen
    {
        Kommunizieren = 1,
        SichBewegen,
        VitaleFunktionenAufrechterhalten,
        SichPflegen,
        EssenUndTrinken,
        Ausscheiden,
        Sichkleiden,
        RuhenUndSchlafen,
        SichBeschaeftigen,
        SichAlsMannFrauFuehlen,
        FuerEineSichereUmgebungSorgen,
        SozialeBereicheDesLebensSichern,
        MitExistentiellenErfahrungenDesLebensUmgehen,
        Biographie
    }

    public enum PflegePlanModi
    {
        PflegePlan,
        Evaluierung
    }

    /// <summary>
    /// Legt fest wie das gesamtsystem zu evaluieren ist entweder der gesamte Klient wird fr alle seine ASZM evaluiert, oder jede einzelne PDx oder Ziel
    /// kann einzeln evaluiert werden
    /// </summary>
    public enum EvaluierungsTypen
    {
        Klient,
        PDX,
        Ziel
    }
    
    public enum KatalogEditModes
    {
        A,
        S,
        Z,
        M,
        R,
        All
    }

	public enum SpenderTyp 
	{
		Einzelspender = 0,
		Tagesspender = 1,
		Wochenspender = 2,
		KeinSpender = -1
	}


	public enum EintragGruppe 
	{
		A,	// Ätiologie
		S,	// Symptome
        R,   // Ressourcen
		Z,	// Ziele 
		M,	// Maßnahmen
		T,	// Termine
		X  // Spenderabgabe

	}

	public enum ZusatzEintragTyp
	{
		TEXT = 0,
		INT = 1,
		BIG_TEXT = 2,
		LABEL = 3,
		IMAGE = 4,
		FLOAT = 5
	}

	public enum AufnahmeArt
	{
		RETTUNG = 0,
		POLIZEI = 1,
		PRIVAT = 2
	}

	public enum TerminTyp
	{
		NONE			= 0x00,
		AKTIVE			= 0x01,
		UEBERFAELLIG	= 0x02,
		DONE			= 0x04,

		EVALUIERUNG		= 0x10,
		EINMALIG		= 0x20,
		NMALIG			= 0x40,

		VERMERK			= 0x100,
		UNEXP_MASSNAHME	= 0x200,

		ALL_ZEITLICH	= (AKTIVE | UEBERFAELLIG | DONE),
		ALL_TYP			= (EVALUIERUNG | EINMALIG | NMALIG),
		ALL_SPECIAL		= (VERMERK | UNEXP_MASSNAHME),
		ALL				= (ALL_ZEITLICH | ALL_TYP | ALL_SPECIAL)
	}

	public enum WeekDay
	{
		MO	= 0x01,
		DI	= 0x02,
		MI	= 0x04,
		DO	= 0x08,
		FR	= 0x10,
		SA	= 0x20,
		SO	= 0x40,

		WORK	= (MO | DI | MI | DO | FR),
		WEEKEND = (SA | SO),
		ALL		= (WORK | WEEKEND)
	}

	public enum PflegeEintragTyp
	{
		NONE			= -1,
		DEKURS			= 0, 
		MASSNAHME		= 1,
		EVALUIERUNG		= 2,
		UNEXP_MASSNAHME	= 3,
		TERMIN			= 4,
		MEDIKAMENT		= 5,
        NOTFALL         = 6,
        PLANUNG         = 7,
        WUNDEN          = 8,
        Klient = 9,
        Assessment = 10,
        Verordnungen = 11,
        Wundverlauf = 12,
        Wundtherapie = 13,
        MedikamentÄnderung = 14
    }

	public enum PflegeEintragWichtig
	{
		NONE			= 0,
		PFLEGER			= 1,
		PFLEGER_ARZT	= 2
	}

	public enum SearchCondition
	{
		AND = 0,
		OR	= 1
	}

	public enum EChanges
	{
		NONE = 0,
		COLORS,
		LOGIN,
		USER,
		AUSWAHL,
		KLINIK,
		PATIENT,
		RECHT,
		ASZM
	}

	public class SiteEventArgs
	{
        public SiteEventArgs() { IDPatient = Guid.Empty; IDAufenthalt = Guid.Empty; IDLinkDokument = Guid.Empty; }
		public Guid IDPatient;
		public Guid IDAufenthalt;
		public Guid IDPflegeplan;
        public Guid IDLinkDokument; //Neu nach 09.10.2008 MDA
	}

	public enum SiteEvents 
	{
		NONE = 0,
		Terminliste = 1,
        Terminplan = 2,
        Uebergabe = 3,
        Aufnahme = 4,
		Patient = 5,
		ASZMVerwaltung = 7,
		AVerwaltung = 8,
		SVerwaltung = 9,
        RVerwaltung = 10,
		ZVerwaltung = 11,
		MVerwaltung = 12,
		AMZuordnung = 13,
        PDXZuordnung = 14,
		Top10 = 15,
		KlinikVerwaltung = 16,
		AbteilungenVerwaltung = 17,
		BereicheVerwaltung = 18,
		EinrichtungenVerwaltung = 19,
		BenutzerVerwaltung = 20,
		Gruppenrechte = 21,
		Benutzerrechte = 22,
		Auswahllisten = 23,
		Zusatzeintraege = 24,
		ZusatzeintraegeZuordnung = 25,
		Entlassen = 26,
		Versetzen = 27,
		Historie = 29,
		Bemerkung = 30,
		Urlaub = 31,
		Bezugsperson = 32,
		DruckenPflegeplan = 33,
		DruckenPflegeplanOnlyOpen = 34,
		DruckenPflegeplanPDx = 35,
		DruckenPflegeplanPDxOnlyOpen = 36,
		Fill1 = 38,
		Fill2 = 39,
		Fill3 = 40,
		Fill4 = 41,
		Fill5 = 42,
		About = 43,
        Home = 44,
        Lock = 45,
        End = 46,
        LogOn = 47,
        Password = 48,
        Neuaufnahme = 49,
		Refresh = 50,
        Vermerk = 51,
        Massnahme = 52,
        MeldungM = 53,
        MeldungT = 54,
        MeldungS = 55,
        MeldungE = 56,
        MeldungShow = 57,
        MeldungBulk = 58,
        PrintBrief = 59,
        PrintAufgaben = 60,
        PrintTerminListe = 61,
        PrintTerminListeBarcode = 62,
        PrintTerminListeBarcodeUnregelmaessig = 63,
        TerminNew = 64,
        TerminEdit = 65,
        TerminDelete = 66,
        TerminEnd = 67,
        MedikamenteVerwalten = 68,
        MedikamentHinzufuegen = 69,
        MedikamentLoeschen = 70,
        Tabellenansicht = 71,
        Einzelansicht = 72,
		MedikamentenVerwaltungBeenden = 73,
        Massnahmenserien = 74,
		MedikamenteVorbereiten = 75,
		RezepteVerwalten = 76,
		QuickFilter = 79,
		QuickMeldung = 80,
        QuickMeldungEvent = 81,							// Eine Quickmeldung wurde ausgewählt - im Tag ist die ID derjenigen Maßnahme versteckt welche Rückgemeldet werden soll
        DienstZeiten = 82,
        ShowEmptyEntries = 83,
        HideEmptyEntries = 84,
        Klientenuebersicht = 86,
        KlientenDetails = 87,
        KlientenDetailsLastSelectedGroup = 88,           // Es soll die zuletzt ausgewählte Gruppe (Anamnese etc angezeit werden und nicht die akte)
        Stammdaten = 89,
        Bereichsansicht = 90,
        PrintPflegeBegleitschreiben = 91,
        MedizinischetypenVerwaltung = 92,
        LinkDokumenteVerwaltung = 93,
        BedarfsMedikationMelden = 94,
        SchnellRueckmeldung = 95,
        AlleMarkieren = 96,
        KeineMarkieren = 97,
        PrintNotfall = 98,
        PrintPflegestandard = 99,  //Neu nach 09.10.2008 MDA
        Zeitbereich = 100,
        Zeitbereichserien = 101,
        archivTerminMailKlient = 102,
        bewerberverwaltung = 103,
        BereichsauswahlKlientenliste = 104,
        KlientenauswahlKlientenliste = 105,
        listeOffeneTermine = 106,
        abrech_patient = 107,
        abrech_sammelabrechnung = 108,
        abrech_sammelabrechnung2 = 109,
        abrech_buchhaltung = 110,
        abrech_stammdten = 111,
        abrech_berichte = 112,
        abrech_Depotgeld = 113,
        aszm_äthologien = 114,
        aszm_sympthome = 115,
        aszm_ressourcen = 116,
        aszm_ziele = 117,
        aszm_maßnahmen = 118,
        TextVerschluesseln = 119

	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Alle möglichen Gruppen
	/// </summary>
	//----------------------------------------------------------------------------
	public enum SiteGroups
	{
		NONE = 0,
		Prog,
		Patient,
		Termine,
		Termine2,
		Print,
		Medikamente,
		MedikamenteTabelle,
		MedikamentenVerwaltung,
		Assessment,
        Stammdaten,
        Markieren,
        historieRefresh,
        Krohwinkel,
        OREM,
        POP
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Die möglichen Aktionen im Falle eines Verarbeitungsfehlers
	/// </summary>
	//----------------------------------------------------------------------------
	public enum BarcodeProcessAction 
	{
		Skip,
		Cancel,
		Continue
	}
    
	//----------------------------------------------------------------------------
	/// <summary>
	/// Alle möglichen Fehler die bei der Verarbeitung auftreten können
	/// </summary>
	//----------------------------------------------------------------------------
	public enum BarcodeProcessErrors
	{
		TicketWithoutUser,
		UnknownTicket
	}

	//----------------------------------------------------------------------------
	/// <summary>
	/// Alle möglichen Aktionen welche der Benutzer während der Verarbeitung 
	/// durchführen muss. 
	/// </summary>
	//----------------------------------------------------------------------------
	public enum BarcodeUserActions 
	{
		UngeplanteMassnahme = 0,			// Benutzer muss eine Ungeplante Massnahme melden
		Bemerkung,							// Benutzer muss eine Bemerkung zur Massnahme erfassen
		Zusatzwerte,						// Benutzer muss Zusatzwete zur Massnahme erfassen.
		OffeneRueckmeldungen				// Benutzer muss offene Rückmeldungen gegenzeichnen.
	}
	
	public enum ProtocolGroups 
	{
		BAR,					// Barcode
		GEN						// Genereller Error
	}
     
    //----------------------------------------------------------------------------
    /// <summary>
    /// Die möglichen unterschiedlichen Anzeigemodi
    /// </summary>
    //----------------------------------------------------------------------------
    public enum TerminlisteAnsichtsmodi
    {
        Klientanansicht,
        Bereichsansicht,
        none
    }
    
    public enum Archivtype
    {
        Suchen = 0,
        Ablegen = 1,
        GesamtSystem = 2
    }



    //----------------------------------------------------------------------------
    /// <summary>
    /// Klassifiziert eine PDx in eine Gruppe
    /// </summary>
    //----------------------------------------------------------------------------
    public enum ePDXGruppe
    {
        Pflegediagnose = 0,
        Risikodiagnose = 1,
        Wellnessdiagnose = 2,
        KeineDiagnose = 3,
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// Klassifiziert eine Ätiologie in untergruppen
    /// </summary>
    //----------------------------------------------------------------------------
    public enum EintragFlag
    {
        //Aetiologie = 0,
        //Voraussetzung = 1,
        //Risiko = 2,
        Einzelabzeichnung = 3,
        MitPflegediagnose = 4,
        Hauptabzeichnung = 5
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// Die möglichen Stati bei der Evaluierung von Zielen
    /// </summary>
    //----------------------------------------------------------------------------
    public enum ZielEvaluierungsStatus
    {
        Erreicht_ASZMaendern = 101,
        Erreicht_weiterwiebisher = 102,
        Erreicht_PDxbeenden =103,
        
        TeilweiseErreicht_ASZMaendern = 201,
        TeilweiseErreicht_weiterwiebisher = 202,
        TeilweiseErreicht_PDxbeenden = 203,

        NichtErreicht_ASZMaendern = 301,
        NichtErreicht_weiterwiebisher = 302,
        NichtErreicht_PDxbeenden = 303,
        
    }

    //----------------------------------------------------------------------------
    /// <summary>
    /// enumerations für die Medikation
    /// </summary>
    //----------------------------------------------------------------------------
    public enum medWiederholungstypen
    {
        taeglich=0,
        alle_x_Tage_Wochen=1,
        jeden_xten_desMonat=2
    }

    public enum medWiederholungseinheiten
    {
        tage=0,
        Wochen=1,
        Monate=2
    }

    public enum medHerrichten
    {
        nein=0,
        kurzfristig=1,
        langfristig=2,
        beiBedarf=3,
        aerztlich=4,
        suchtgift=5
    }

    public enum medVerabreichung
    {
        wieHergerichtet=0,
        einzeln=1
    }

    public enum Wochentage
    {
        Sonntag=0,
        Montag=1,
        Dienstag=2,
        Mittwoch=3,
        Donnertag=4,
        Freitag=5,
        Samstag=6
    }

    public enum BearbeitungsModus
    {
        neu = 0,
        edit
    }
        
    public enum ErfassungMode
    {
        AbrechnungsdatenKlient = 0,
        LeistungenKlient = 1,
        AbwesenheitKlient = 2,
        manBuchungen = 3,
        Transferzahlungen = 4,
        freieRechnungen = 5,
        RechnungenKlient = 6,
        Klientenakt = 7,
    }
    
    public enum SearchIN
    {
        Pflegediagnosen = 0,
        ZugeordneteASZM = 1
    }
    public enum PDXSuchArt
    {
        Favoriten = 0,
        AllgemeineFavoriten = 1,
        Pflegeanamnesen = 2,
        Suchen = 3
    }
    
    public enum PflegePlanModus
    {
        Normal,
        Wunde  //,
        //NormalAktiv,
        //NormalEntfernt,
        //WundeAktiv,
        //WundeEntfernt
    }

    public enum _typBemerkung
    {
        bemerkung = 0,
        dekurs = 1
    }

    public enum eOrderBy
    {
        name = 0,
        aufnahmedatum = 1
    }

    public enum eBerufsstand
    {
        Pflege = 0,
        Arzt = 1,
        Therapie = 2
    }


    public enum eAbwesenheitsart
    {
        Nein = 0,
        Abwesenheit = 1,
        Entlassung = 2
    }


    public enum PasswordScore
    {
        Blank = 0,
        VeryWeak = 1,
        Weak = 2,
        Medium = 3,
        Strong = 4,
        VeryStrong = 5
    }

    public enum eBefundTyp
    {
        BEFUND = 0,
        PDF = 1,
        DICOM = 2,
        ZIP = 3,
        LABOR = 4,
        DICOMDIR = 5
    }

    public enum eTypeFortbildungenUI
    {
        Veranstalter = 0,
        AlleFortbildungenxy = 1,
        Benutzer = 2
    }

    public enum eTypePatientenUserPickerChanged
    {
        MainPickerLeftTop = 0,
        ReportSelection = 1,
        none = 100
    }

    public class Enums
    {
        public enum eCompareMode
        {
            Equals = 1,
            StartsWith = 2,
            Contains = 3,
            EndsWith = 4
        }

        public static PflegeEintragTyp searchEnumPflegeEintragTyp(int keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(PflegeEintragTyp)))
            {
                string sResTyp = Enum.GetName(typeof(PflegeEintragTyp), val);
                if (val == keyToSearch)
                    return (PflegeEintragTyp)val;

                //if (keyToSearch == sResTyp)
                //    return (PflegeEintragTyp)val;
            }
            throw new Exception("Enums.searchEnumPflegeEintragTyp: key '" + keyToSearch + "' not found!");
        }

        public static PflegeEintragWichtig searchEnumPflegeEintragWichtig(int keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(PflegeEintragWichtig)))
            {
                string sResTyp = Enum.GetName(typeof(PflegeEintragWichtig), val);
                if (val == keyToSearch)
                    return (PflegeEintragWichtig)val;
            }
            throw new Exception("Enums.searchEnumPflegeEintragWichtig: key '" + keyToSearch + "' not found!");
        }

        public static eDekursherkunft searchEnumDekursherkunft(int keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(eDekursherkunft)))
            {
                string sResTyp = Enum.GetName(typeof(eDekursherkunft), val);
                if (val == keyToSearch)
                    return (eDekursherkunft)val;
            }
            throw new Exception("Enums.searchEnumDekursherkunft: key '" + keyToSearch + "' not found!");
        }

        public static ZielEvaluierungsStatus searchEnumZielEvaluierungsStatus(int keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(ZielEvaluierungsStatus)))
            {
                string sResTyp = Enum.GetName(typeof(ZielEvaluierungsStatus), val);
                if (val == keyToSearch)
                    return (ZielEvaluierungsStatus)val;
            }
            throw new Exception("Enums.searchEnumZielEvaluierungsStatus: key '" + keyToSearch + "' not found!");
        }
        
    }


}
