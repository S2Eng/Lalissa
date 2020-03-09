using PMDS.Global.db.Pflegeplan;

namespace PMDS.DB.Patient
{
    partial class DBAnamneseBiografie
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBAnamneseBiografie));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.dsPDXByPflegeModell1 = new PMDS.Data.Patient.dsPDXByPflegeModell();
            this.daPDXByPflegemodell = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
            this.dsPflegemodelle1 = new dsPflegemodelle();
            this.daPflegeModell = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbSelectCommand3 = new System.Data.OleDb.OleDbCommand();
            this.dsAnamneseBiografie1 = new PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2();
            this.daAnamneseBiografie = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXByPflegeModell1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegemodelle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAnamneseBiografie1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=STYSRV02v\\SQL2008R2;Integrated Security=SSPI;Initial Catalog=PMDSDev";
            // 
            // dsPDXByPflegeModell1
            // 
            this.dsPDXByPflegeModell1.DataSetName = "dsPDXByPflegeModell";
            this.dsPDXByPflegeModell1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPDXByPflegemodell
            // 
            this.daPDXByPflegemodell.SelectCommand = this.oleDbSelectCommand2;
            this.daPDXByPflegemodell.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "PDX", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("IDPDX", "IDPDX"),
                        new System.Data.Common.DataColumnMapping("Klartext", "Klartext"),
                        new System.Data.Common.DataColumnMapping("Code", "Code"),
                        new System.Data.Common.DataColumnMapping("LokalisierungsTyp", "LokalisierungsTyp"),
                        new System.Data.Common.DataColumnMapping("IDPflegemodelle", "IDPflegemodelle"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("Modellgruppe", "Modellgruppe"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            // 
            // oleDbSelectCommand2
            // 
            this.oleDbSelectCommand2.CommandText = resources.GetString("oleDbSelectCommand2.CommandText");
            this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.Char, 50, "Modell")});
            // 
            // dsPflegemodelle1
            // 
            this.dsPflegemodelle1.DataSetName = "dsPflegemodelle";
            this.dsPflegemodelle1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daPflegeModell
            // 
            this.daPflegeModell.SelectCommand = this.oleDbSelectCommand3;
            this.daPflegeModell.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Pflegemodelle", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("Modell", "Modell"),
                        new System.Data.Common.DataColumnMapping("ModellgruppeKlartext", "ModellgruppeKlartext"),
                        new System.Data.Common.DataColumnMapping("Modellgruppe", "Modellgruppe"),
                        new System.Data.Common.DataColumnMapping("Reihenfolge", "Reihenfolge")})});
            // 
            // oleDbSelectCommand3
            // 
            this.oleDbSelectCommand3.CommandText = "SELECT     ID, Modell, ModellgruppeKlartext,Modellgruppe, Reihenfolge\r\nFROM      " +
                "   Pflegemodelle\r\nWHERE     (Modell = ?)\r\nORDER BY Reihenfolge";
            this.oleDbSelectCommand3.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Modell", System.Data.OleDb.OleDbType.Char, 50, "Modell")});
            // 
            // dsAnamneseBiografie1
            // 
            this.dsAnamneseBiografie1.DataSetName = "dsAnamneseKrohwinkel";
            this.dsAnamneseBiografie1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // daAnamneseBiografie
            // 
            this.daAnamneseBiografie.DeleteCommand = this.oleDbDeleteCommand1;
            this.daAnamneseBiografie.InsertCommand = this.oleDbInsertCommand1;
            this.daAnamneseBiografie.SelectCommand = this.oleDbSelectCommand1;
            this.daAnamneseBiografie.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Anamnese_Krohwinkel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDPatient", "IDPatient"),
                        new System.Data.Common.DataColumnMapping("IDBenutzer", "IDBenutzer"),
                        new System.Data.Common.DataColumnMapping("ErstelltAm", "ErstelltAm"),
                        new System.Data.Common.DataColumnMapping("BrilleJN", "BrilleJN"),
                        new System.Data.Common.DataColumnMapping("HoergeraetJN", "HoergeraetJN"),
                        new System.Data.Common.DataColumnMapping("KannMitteilenJN", "KannMitteilenJN"),
                        new System.Data.Common.DataColumnMapping("KommunizierenTagesstuktur", "KommunizierenTagesstuktur"),
                        new System.Data.Common.DataColumnMapping("KommunizierenPflegeplanung", "KommunizierenPflegeplanung"),
                        new System.Data.Common.DataColumnMapping("Wuensche", "Wuensche"),
                        new System.Data.Common.DataColumnMapping("SchwerhoerigTaubStummBlind", "SchwerhoerigTaubStummBlind"),
                        new System.Data.Common.DataColumnMapping("HoergeraetNichtHandhaben", "HoergeraetNichtHandhaben"),
                        new System.Data.Common.DataColumnMapping("Sprachstoerungen", "Sprachstoerungen"),
                        new System.Data.Common.DataColumnMapping("Sichtfeldeinschraenkungen", "Sichtfeldeinschraenkungen"),
                        new System.Data.Common.DataColumnMapping("IstZeitloertlSituativZurPersonNichtOrientiert", "IstZeitloertlSituativZurPersonNichtOrientiert"),
                        new System.Data.Common.DataColumnMapping("KannSelbstBewegenJN", "KannSelbstBewegenJN"),
                        new System.Data.Common.DataColumnMapping("GehentJN", "GehentJN"),
                        new System.Data.Common.DataColumnMapping("StehenJN", "StehenJN"),
                        new System.Data.Common.DataColumnMapping("SitzenJN", "SitzenJN"),
                        new System.Data.Common.DataColumnMapping("TreppenSteigenJN", "TreppenSteigenJN"),
                        new System.Data.Common.DataColumnMapping("LaufenJN", "LaufenJN"),
                        new System.Data.Common.DataColumnMapping("HinsetzenJN", "HinsetzenJN"),
                        new System.Data.Common.DataColumnMapping("HinlegenJN", "HinlegenJN"),
                        new System.Data.Common.DataColumnMapping("HilfsmittelBenutzenJN", "HilfsmittelBenutzenJN"),
                        new System.Data.Common.DataColumnMapping("SpatzierenGehenJN", "SpatzierenGehenJN"),
                        new System.Data.Common.DataColumnMapping("WannWieOftSpatzieren", "WannWieOftSpatzieren"),
                        new System.Data.Common.DataColumnMapping("KoerperlicheaktivitaetenJN", "KoerperlicheaktivitaetenJN"),
                        new System.Data.Common.DataColumnMapping("AktivitaetenBeschreibung", "AktivitaetenBeschreibung"),
                        new System.Data.Common.DataColumnMapping("BewegenTagesstrukturJN", "BewegenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("BewegenPflegeplanung", "BewegenPflegeplanung"),
                        new System.Data.Common.DataColumnMapping("KontrakturenvorhandenJN", "KontrakturenvorhandenJN"),
                        new System.Data.Common.DataColumnMapping("SpitzfussstellungJN", "SpitzfussstellungJN"),
                        new System.Data.Common.DataColumnMapping("MaxGebEllenbogenJN", "MaxGebEllenbogenJN"),
                        new System.Data.Common.DataColumnMapping("KniegelenkJN", "KniegelenkJN"),
                        new System.Data.Common.DataColumnMapping("GefausteteHandJN", "GefausteteHandJN"),
                        new System.Data.Common.DataColumnMapping("KontrakturenBeschreibung", "KontrakturenBeschreibung"),
                        new System.Data.Common.DataColumnMapping("DekubitusVorhandenJN", "DekubitusVorhandenJN"),
                        new System.Data.Common.DataColumnMapping("DekubitusBeschreibung", "DekubitusBeschreibung"),
                        new System.Data.Common.DataColumnMapping("SturtzgefahrJN", "SturtzgefahrJN"),
                        new System.Data.Common.DataColumnMapping("Bewegungseinschraenkung", "Bewegungseinschraenkung"),
                        new System.Data.Common.DataColumnMapping("KannNichtAlleinGehen", "KannNichtAlleinGehen"),
                        new System.Data.Common.DataColumnMapping("KannNichtAlleinLageImBettVeraendern", "KannNichtAlleinLageImBettVeraendern"),
                        new System.Data.Common.DataColumnMapping("IstBettlaegerig", "IstBettlaegerig"),
                        new System.Data.Common.DataColumnMapping("TransferAufstehenHinlegen", "TransferAufstehenHinlegen"),
                        new System.Data.Common.DataColumnMapping("BlutdruckZuckerRegelmaessigGemessenJN", "BlutdruckZuckerRegelmaessigGemessenJN"),
                        new System.Data.Common.DataColumnMapping("KompressionsstruempfeJN", "KompressionsstruempfeJN"),
                        new System.Data.Common.DataColumnMapping("Zimmertemperatur", "Zimmertemperatur"),
                        new System.Data.Common.DataColumnMapping("MedikamenteRegelmaessigJN", "MedikamenteRegelmaessigJN"),
                        new System.Data.Common.DataColumnMapping("Medikamente", "Medikamente"),
                        new System.Data.Common.DataColumnMapping("VitaleFunkTagesstrukturJN", "VitaleFunkTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("VitaleFunkPflegeplanungJN", "VitaleFunkPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("ErhoehteErnidriegteBlutdruck", "ErhoehteErnidriegteBlutdruck"),
                        new System.Data.Common.DataColumnMapping("Durchblutungsstoerungen", "Durchblutungsstoerungen"),
                        new System.Data.Common.DataColumnMapping("FriertLeicht", "FriertLeicht"),
                        new System.Data.Common.DataColumnMapping("DiabetesUnterUeberZucker", "DiabetesUnterUeberZucker"),
                        new System.Data.Common.DataColumnMapping("Sauerstoffmangel", "Sauerstoffmangel"),
                        new System.Data.Common.DataColumnMapping("BronchialsekretSchlechtAbhusten", "BronchialsekretSchlechtAbhusten"),
                        new System.Data.Common.DataColumnMapping("StarkeAuswurf", "StarkeAuswurf"),
                        new System.Data.Common.DataColumnMapping("AtemnotleichterAnstrengung", "AtemnotleichterAnstrengung"),
                        new System.Data.Common.DataColumnMapping("HilfeMedikamentenversorgung", "HilfeMedikamentenversorgung"),
                        new System.Data.Common.DataColumnMapping("WieHandhabenMitDuschenBaden", "WieHandhabenMitDuschenBaden"),
                        new System.Data.Common.DataColumnMapping("Koerperpflegemittel", "Koerperpflegemittel"),
                        new System.Data.Common.DataColumnMapping("KoerperpflegemittelVersorger", "KoerperpflegemittelVersorger"),
                        new System.Data.Common.DataColumnMapping("Rasieren", "Rasieren"),
                        new System.Data.Common.DataColumnMapping("Haarpflege", "Haarpflege"),
                        new System.Data.Common.DataColumnMapping("ZahnFusspflegeHilfeJN", "ZahnFusspflegeHilfeJN"),
                        new System.Data.Common.DataColumnMapping("SchminkenJN", "SchminkenJN"),
                        new System.Data.Common.DataColumnMapping("SichPflegenTagesstrukturJN", "SichPflegenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SichPflegenPflegeplanungJN", "SichPflegenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("HilfebWaschenDuschenBaden", "HilfebWaschenDuschenBaden"),
                        new System.Data.Common.DataColumnMapping("HilfebHaareOberUnterkoerper", "HilfebHaareOberUnterkoerper"),
                        new System.Data.Common.DataColumnMapping("HilfebRasur", "HilfebRasur"),
                        new System.Data.Common.DataColumnMapping("HilfebFussFingernagelpflege", "HilfebFussFingernagelpflege"),
                        new System.Data.Common.DataColumnMapping("HilfebIntimpflege", "HilfebIntimpflege"),
                        new System.Data.Common.DataColumnMapping("HilfebHautGesichtspflege", "HilfebHautGesichtspflege"),
                        new System.Data.Common.DataColumnMapping("HilfebOhrenNasenAugenpflege", "HilfebOhrenNasenAugenpflege"),
                        new System.Data.Common.DataColumnMapping("HilfebMundZahnpflege", "HilfebMundZahnpflege"),
                        new System.Data.Common.DataColumnMapping("HilfebHautdefekte", "HilfebHautdefekte"),
                        new System.Data.Common.DataColumnMapping("Starkschwitzen", "Starkschwitzen"),
                        new System.Data.Common.DataColumnMapping("SpeisenGetraenke", "SpeisenGetraenke"),
                        new System.Data.Common.DataColumnMapping("SpeisenGetraenkeAblehnen", "SpeisenGetraenkeAblehnen"),
                        new System.Data.Common.DataColumnMapping("AnzahlLiterTrinken", "AnzahlLiterTrinken"),
                        new System.Data.Common.DataColumnMapping("MahlzeitInDerGemeinschaftJN", "MahlzeitInDerGemeinschaftJN"),
                        new System.Data.Common.DataColumnMapping("FruehstueckSpaetFruehEinnehmen", "FruehstueckSpaetFruehEinnehmen"),
                        new System.Data.Common.DataColumnMapping("DiatSchonkostSondenernaehrung", "DiatSchonkostSondenernaehrung"),
                        new System.Data.Common.DataColumnMapping("AnzahlMalzeiten", "AnzahlMalzeiten"),
                        new System.Data.Common.DataColumnMapping("EssenTrinkenTagesstrukturJN", "EssenTrinkenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("EssenTrinkenPflegeplanungJN", "EssenTrinkenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("NotwendigkeitEsssenTrinken", "NotwendigkeitEsssenTrinken"),
                        new System.Data.Common.DataColumnMapping("NotwendigkeitDiaet", "NotwendigkeitDiaet"),
                        new System.Data.Common.DataColumnMapping("KauSchluckstoerungen", "KauSchluckstoerungen"),
                        new System.Data.Common.DataColumnMapping("IsstSehrlangsamm", "IsstSehrlangsamm"),
                        new System.Data.Common.DataColumnMapping("NahrungMundgerechtZubereiten", "NahrungMundgerechtZubereiten"),
                        new System.Data.Common.DataColumnMapping("MahlzeiteinnahmeHilfestellung", "MahlzeiteinnahmeHilfestellung"),
                        new System.Data.Common.DataColumnMapping("SondePEGKomplett", "SondePEGKomplett"),
                        new System.Data.Common.DataColumnMapping("SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme", "SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme"),
                        new System.Data.Common.DataColumnMapping("UnterstuezungUeberwachungFluessigkeitsaufnahme", "UnterstuezungUeberwachungFluessigkeitsaufnahme"),
                        new System.Data.Common.DataColumnMapping("HaufigErbrechen", "HaufigErbrechen"),
                        new System.Data.Common.DataColumnMapping("KannBlaseDarmKontrollierenJN", "KannBlaseDarmKontrollierenJN"),
                        new System.Data.Common.DataColumnMapping("ZeitenToiletteAufsuchen", "ZeitenToiletteAufsuchen"),
                        new System.Data.Common.DataColumnMapping("ToilettengangHilfeJN", "ToilettengangHilfeJN"),
                        new System.Data.Common.DataColumnMapping("ToilettenHilfsmittel", "ToilettenHilfsmittel"),
                        new System.Data.Common.DataColumnMapping("MedikamenteBlasenDarmfunktion", "MedikamenteBlasenDarmfunktion"),
                        new System.Data.Common.DataColumnMapping("AusscheidenTagesstrukturJN", "AusscheidenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("AusscheidenPflegeplanungJN", "AusscheidenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("IstZeitweiseUrinStuhlinkontinent", "IstZeitweiseUrinStuhlinkontinent"),
                        new System.Data.Common.DataColumnMapping("UrinStuhlKrankheit", "UrinStuhlKrankheit"),
                        new System.Data.Common.DataColumnMapping("ZeitlUrinStuhlKrankheit", "ZeitlUrinStuhlKrankheit"),
                        new System.Data.Common.DataColumnMapping("VerstopfungenDurchfaellen", "VerstopfungenDurchfaellen"),
                        new System.Data.Common.DataColumnMapping("VerstopfungDurchfallKrakheit", "VerstopfungDurchfallKrakheit"),
                        new System.Data.Common.DataColumnMapping("ZeitlVerstopfungDurchfallKrakheit", "ZeitlVerstopfungDurchfallKrakheit"),
                        new System.Data.Common.DataColumnMapping("DauerSuprapubischenkatheter", "DauerSuprapubischenkatheter"),
                        new System.Data.Common.DataColumnMapping("NeigtZuInfektionen", "NeigtZuInfektionen"),
                        new System.Data.Common.DataColumnMapping("HatAnusPraeter", "HatAnusPraeter"),
                        new System.Data.Common.DataColumnMapping("KannToiletteNichtSelbstaendigBenutzen", "KannToiletteNichtSelbstaendigBenutzen"),
                        new System.Data.Common.DataColumnMapping("UnterstuetzungEinnahmeAbfuehrmittel", "UnterstuetzungEinnahmeAbfuehrmittel"),
                        new System.Data.Common.DataColumnMapping("Kleidung", "Kleidung"),
                        new System.Data.Common.DataColumnMapping("Waeschewechsel", "Waeschewechsel"),
                        new System.Data.Common.DataColumnMapping("SichKleidenTagesstrukturJN", "SichKleidenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SichKleidenPflegeplanungJN", "SichKleidenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("KleiderauswahlHilfe", "KleiderauswahlHilfe"),
                        new System.Data.Common.DataColumnMapping("WegenDesoriontiertheitOefterAusziehen", "WegenDesoriontiertheitOefterAusziehen"),
                        new System.Data.Common.DataColumnMapping("FehlendeEinsichtFuerAngemesseneKleidung", "FehlendeEinsichtFuerAngemesseneKleidung"),
                        new System.Data.Common.DataColumnMapping("FehlendeEinsichtFuerNotwendigeWaeschewechsel", "FehlendeEinsichtFuerNotwendigeWaeschewechsel"),
                        new System.Data.Common.DataColumnMapping("KannVerschluesseNichtHandhaben", "KannVerschluesseNichtHandhaben"),
                        new System.Data.Common.DataColumnMapping("KannNichtKleidungUeberKopfAusziehen", "KannNichtKleidungUeberKopfAusziehen"),
                        new System.Data.Common.DataColumnMapping("KannNichtKleidungUeberFusseAnziehen", "KannNichtKleidungUeberFusseAnziehen"),
                        new System.Data.Common.DataColumnMapping("SchlafenVonBis", "SchlafenVonBis"),
                        new System.Data.Common.DataColumnMapping("MittagsschlafJN", "MittagsschlafJN"),
                        new System.Data.Common.DataColumnMapping("NachtsNachschauenJN", "NachtsNachschauenJN"),
                        new System.Data.Common.DataColumnMapping("SchlafBesonderheiten", "SchlafBesonderheiten"),
                        new System.Data.Common.DataColumnMapping("SchlafMedikamente", "SchlafMedikamente"),
                        new System.Data.Common.DataColumnMapping("SchlafGewohnheiten", "SchlafGewohnheiten"),
                        new System.Data.Common.DataColumnMapping("SchlafTagesstrukturJN", "SchlafTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SchlafPflegeplanungJN", "SchlafPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("HateinschlafDurchschlafstoerungen", "HateinschlafDurchschlafstoerungen"),
                        new System.Data.Common.DataColumnMapping("HatPsychischeKrankheitsbedingteSchlafstoerungen", "HatPsychischeKrankheitsbedingteSchlafstoerungen"),
                        new System.Data.Common.DataColumnMapping("HatGestoertenTagNachtrhytmus", "HatGestoertenTagNachtrhytmus"),
                        new System.Data.Common.DataColumnMapping("Beruf", "Beruf"),
                        new System.Data.Common.DataColumnMapping("GerneBeschaeftigtMit", "GerneBeschaeftigtMit"),
                        new System.Data.Common.DataColumnMapping("Tagsablauf", "Tagsablauf"),
                        new System.Data.Common.DataColumnMapping("TagesablaufsgestaltungHilfeJN", "TagesablaufsgestaltungHilfeJN"),
                        new System.Data.Common.DataColumnMapping("TagesablaufsgestaltungHilfe", "TagesablaufsgestaltungHilfe"),
                        new System.Data.Common.DataColumnMapping("SichBeschaeftigenTagesstrukturJN", "SichBeschaeftigenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SichBeschaeftigenPflegeplanungJN", "SichBeschaeftigenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("TagesablaufNachFrueherenGewohnheiten", "TagesablaufNachFrueherenGewohnheiten"),
                        new System.Data.Common.DataColumnMapping("ZeitpunktAufstehenBettGehenAbstimmen", "ZeitpunktAufstehenBettGehenAbstimmen"),
                        new System.Data.Common.DataColumnMapping("IntegrationInTaeglicheAblaufe", "IntegrationInTaeglicheAblaufe"),
                        new System.Data.Common.DataColumnMapping("MaennlicheWeiblichePflegeperson", "MaennlicheWeiblichePflegeperson"),
                        new System.Data.Common.DataColumnMapping("MakeUpSchmuck", "MakeUpSchmuck"),
                        new System.Data.Common.DataColumnMapping("HaarBarttracht", "HaarBarttracht"),
                        new System.Data.Common.DataColumnMapping("SichFuehlenTagesstrukturJN", "SichFuehlenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SichFuehlenpflegeplanungJN", "SichFuehlenpflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("SchagefuehlIntimepflegeBeruecksichtigen", "SchagefuehlIntimepflegeBeruecksichtigen"),
                        new System.Data.Common.DataColumnMapping("WuenschtMaennlicheWeiblicheBestimmtePflegeperson", "WuenschtMaennlicheWeiblicheBestimmtePflegeperson"),
                        new System.Data.Common.DataColumnMapping("KannFrisurNichtSelbstHerrichten", "KannFrisurNichtSelbstHerrichten"),
                        new System.Data.Common.DataColumnMapping("KannSchmuckNichtSelbstAnlegen", "KannSchmuckNichtSelbstAnlegen"),
                        new System.Data.Common.DataColumnMapping("HilfsmittelZurMobilitaetJN", "HilfsmittelZurMobilitaetJN"),
                        new System.Data.Common.DataColumnMapping("BettgitterJN", "BettgitterJN"),
                        new System.Data.Common.DataColumnMapping("ZimmerVerschlossen", "ZimmerVerschlossen"),
                        new System.Data.Common.DataColumnMapping("HilfeHerbeirufenJN", "HilfeHerbeirufenJN"),
                        new System.Data.Common.DataColumnMapping("OhneHilfeZurechtJN", "OhneHilfeZurechtJN"),
                        new System.Data.Common.DataColumnMapping("UmgebungTagesstrukturJN", "UmgebungTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("UmgebungPflegeplanungJN", "UmgebungPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("KannGefahrenNichtEinschaetzen", "KannGefahrenNichtEinschaetzen"),
                        new System.Data.Common.DataColumnMapping("InDerEinrichtungVerirrn", "InDerEinrichtungVerirrn"),
                        new System.Data.Common.DataColumnMapping("Sicherheit", "Sicherheit"),
                        new System.Data.Common.DataColumnMapping("MedikamenteneinnahmeUeberwachen", "MedikamenteneinnahmeUeberwachen"),
                        new System.Data.Common.DataColumnMapping("Kontakte", "Kontakte"),
                        new System.Data.Common.DataColumnMapping("Keinekontakte", "Keinekontakte"),
                        new System.Data.Common.DataColumnMapping("ZeitKeineBesuche", "ZeitKeineBesuche"),
                        new System.Data.Common.DataColumnMapping("AndereKontakte", "AndereKontakte"),
                        new System.Data.Common.DataColumnMapping("KontakteSelbsstaendigHerstellenJN", "KontakteSelbsstaendigHerstellenJN"),
                        new System.Data.Common.DataColumnMapping("SozialeTagesstrukturJN", "SozialeTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("SozialePflegeplanungJN", "SozialePflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("BewohnerBenoetigtAktivierung", "BewohnerBenoetigtAktivierung"),
                        new System.Data.Common.DataColumnMapping("HilfeBeiDerKontakpflege", "HilfeBeiDerKontakpflege"),
                        new System.Data.Common.DataColumnMapping("InBetreuungImHausIntegrieren", "InBetreuungImHausIntegrieren"),
                        new System.Data.Common.DataColumnMapping("SterbephaseBetreuung", "SterbephaseBetreuung"),
                        new System.Data.Common.DataColumnMapping("Versorger", "Versorger"),
                        new System.Data.Common.DataColumnMapping("ErfahrungenTagesstrukturJN", "ErfahrungenTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("ErfahrungenPflegeplanungJN", "ErfahrungenPflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("KannKrankheitBehinderungNichtAkzeptieren", "KannKrankheitBehinderungNichtAkzeptieren"),
                        new System.Data.Common.DataColumnMapping("LeidetAnVerlust", "LeidetAnVerlust"),
                        new System.Data.Common.DataColumnMapping("LeidetAnVerlustVon", "LeidetAnVerlustVon"),
                        new System.Data.Common.DataColumnMapping("IstMisstraurisch", "IstMisstraurisch"),
                        new System.Data.Common.DataColumnMapping("IstMisstraurischGegen", "IstMisstraurischGegen"),
                        new System.Data.Common.DataColumnMapping("HatSchmerzen", "HatSchmerzen"),
                        new System.Data.Common.DataColumnMapping("Schmerzen", "Schmerzen"),
                        new System.Data.Common.DataColumnMapping("HatAngst", "HatAngst"),
                        new System.Data.Common.DataColumnMapping("AngstVon", "AngstVon"),
                        new System.Data.Common.DataColumnMapping("Biographie", "Biographie"),
                        new System.Data.Common.DataColumnMapping("BiographieTagesstrukturJN", "BiographieTagesstrukturJN"),
                        new System.Data.Common.DataColumnMapping("BiographiePflegeplanungJN", "BiographiePflegeplanungJN"),
                        new System.Data.Common.DataColumnMapping("UnbewaeltigtenLebenserfahrungen", "UnbewaeltigtenLebenserfahrungen"),
                        new System.Data.Common.DataColumnMapping("Vermisst", "Vermisst"),
                        new System.Data.Common.DataColumnMapping("VermisstBeschreibung", "VermisstBeschreibung"),
                        new System.Data.Common.DataColumnMapping("HatSorge", "HatSorge"),
                        new System.Data.Common.DataColumnMapping("SorgeUm", "SorgeUm")})});
            this.daAnamneseBiografie.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Anamnese_Krohwinkel] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"),
            new System.Data.OleDb.OleDbParameter("BrilleJN", System.Data.OleDb.OleDbType.Boolean, 0, "BrilleJN"),
            new System.Data.OleDb.OleDbParameter("HoergeraetJN", System.Data.OleDb.OleDbType.Boolean, 0, "HoergeraetJN"),
            new System.Data.OleDb.OleDbParameter("KannMitteilenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannMitteilenJN"),
            new System.Data.OleDb.OleDbParameter("KommunizierenTagesstuktur", System.Data.OleDb.OleDbType.Integer, 0, "KommunizierenTagesstuktur"),
            new System.Data.OleDb.OleDbParameter("KommunizierenPflegeplanung", System.Data.OleDb.OleDbType.Integer, 0, "KommunizierenPflegeplanung"),
            new System.Data.OleDb.OleDbParameter("Wuensche", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wuensche"),
            new System.Data.OleDb.OleDbParameter("SchwerhoerigTaubStummBlind", System.Data.OleDb.OleDbType.Integer, 0, "SchwerhoerigTaubStummBlind"),
            new System.Data.OleDb.OleDbParameter("HoergeraetNichtHandhaben", System.Data.OleDb.OleDbType.Integer, 0, "HoergeraetNichtHandhaben"),
            new System.Data.OleDb.OleDbParameter("Sprachstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "Sprachstoerungen"),
            new System.Data.OleDb.OleDbParameter("Sichtfeldeinschraenkungen", System.Data.OleDb.OleDbType.Integer, 0, "Sichtfeldeinschraenkungen"),
            new System.Data.OleDb.OleDbParameter("IstZeitloertlSituativZurPersonNichtOrientiert", System.Data.OleDb.OleDbType.Integer, 0, "IstZeitloertlSituativZurPersonNichtOrientiert"),
            new System.Data.OleDb.OleDbParameter("KannSelbstBewegenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannSelbstBewegenJN"),
            new System.Data.OleDb.OleDbParameter("GehentJN", System.Data.OleDb.OleDbType.Boolean, 0, "GehentJN"),
            new System.Data.OleDb.OleDbParameter("StehenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StehenJN"),
            new System.Data.OleDb.OleDbParameter("SitzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SitzenJN"),
            new System.Data.OleDb.OleDbParameter("TreppenSteigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "TreppenSteigenJN"),
            new System.Data.OleDb.OleDbParameter("LaufenJN", System.Data.OleDb.OleDbType.Boolean, 0, "LaufenJN"),
            new System.Data.OleDb.OleDbParameter("HinsetzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HinsetzenJN"),
            new System.Data.OleDb.OleDbParameter("HinlegenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HinlegenJN"),
            new System.Data.OleDb.OleDbParameter("HilfsmittelBenutzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfsmittelBenutzenJN"),
            new System.Data.OleDb.OleDbParameter("SpatzierenGehenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpatzierenGehenJN"),
            new System.Data.OleDb.OleDbParameter("WannWieOftSpatzieren", System.Data.OleDb.OleDbType.LongVarChar, 0, "WannWieOftSpatzieren"),
            new System.Data.OleDb.OleDbParameter("KoerperlicheaktivitaetenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KoerperlicheaktivitaetenJN"),
            new System.Data.OleDb.OleDbParameter("AktivitaetenBeschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "AktivitaetenBeschreibung"),
            new System.Data.OleDb.OleDbParameter("BewegenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewegenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("BewegenPflegeplanung", System.Data.OleDb.OleDbType.Boolean, 0, "BewegenPflegeplanung"),
            new System.Data.OleDb.OleDbParameter("KontrakturenvorhandenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KontrakturenvorhandenJN"),
            new System.Data.OleDb.OleDbParameter("SpitzfussstellungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpitzfussstellungJN"),
            new System.Data.OleDb.OleDbParameter("MaxGebEllenbogenJN", System.Data.OleDb.OleDbType.Boolean, 0, "MaxGebEllenbogenJN"),
            new System.Data.OleDb.OleDbParameter("KniegelenkJN", System.Data.OleDb.OleDbType.Boolean, 0, "KniegelenkJN"),
            new System.Data.OleDb.OleDbParameter("GefausteteHandJN", System.Data.OleDb.OleDbType.Boolean, 0, "GefausteteHandJN"),
            new System.Data.OleDb.OleDbParameter("KontrakturenBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "KontrakturenBeschreibung"),
            new System.Data.OleDb.OleDbParameter("DekubitusVorhandenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DekubitusVorhandenJN"),
            new System.Data.OleDb.OleDbParameter("DekubitusBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "DekubitusBeschreibung"),
            new System.Data.OleDb.OleDbParameter("SturtzgefahrJN", System.Data.OleDb.OleDbType.Boolean, 0, "SturtzgefahrJN"),
            new System.Data.OleDb.OleDbParameter("Bewegungseinschraenkung", System.Data.OleDb.OleDbType.Integer, 0, "Bewegungseinschraenkung"),
            new System.Data.OleDb.OleDbParameter("KannNichtAlleinGehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtAlleinGehen"),
            new System.Data.OleDb.OleDbParameter("KannNichtAlleinLageImBettVeraendern", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtAlleinLageImBettVeraendern"),
            new System.Data.OleDb.OleDbParameter("IstBettlaegerig", System.Data.OleDb.OleDbType.Integer, 0, "IstBettlaegerig"),
            new System.Data.OleDb.OleDbParameter("TransferAufstehenHinlegen", System.Data.OleDb.OleDbType.Integer, 0, "TransferAufstehenHinlegen"),
            new System.Data.OleDb.OleDbParameter("BlutdruckZuckerRegelmaessigGemessenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BlutdruckZuckerRegelmaessigGemessenJN"),
            new System.Data.OleDb.OleDbParameter("KompressionsstruempfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "KompressionsstruempfeJN"),
            new System.Data.OleDb.OleDbParameter("Zimmertemperatur", System.Data.OleDb.OleDbType.Integer, 0, "Zimmertemperatur"),
            new System.Data.OleDb.OleDbParameter("MedikamenteRegelmaessigJN", System.Data.OleDb.OleDbType.Boolean, 0, "MedikamenteRegelmaessigJN"),
            new System.Data.OleDb.OleDbParameter("Medikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "Medikamente"),
            new System.Data.OleDb.OleDbParameter("VitaleFunkTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "VitaleFunkTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("VitaleFunkPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "VitaleFunkPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("ErhoehteErnidriegteBlutdruck", System.Data.OleDb.OleDbType.Integer, 0, "ErhoehteErnidriegteBlutdruck"),
            new System.Data.OleDb.OleDbParameter("Durchblutungsstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "Durchblutungsstoerungen"),
            new System.Data.OleDb.OleDbParameter("FriertLeicht", System.Data.OleDb.OleDbType.Integer, 0, "FriertLeicht"),
            new System.Data.OleDb.OleDbParameter("DiabetesUnterUeberZucker", System.Data.OleDb.OleDbType.Integer, 0, "DiabetesUnterUeberZucker"),
            new System.Data.OleDb.OleDbParameter("Sauerstoffmangel", System.Data.OleDb.OleDbType.Integer, 0, "Sauerstoffmangel"),
            new System.Data.OleDb.OleDbParameter("BronchialsekretSchlechtAbhusten", System.Data.OleDb.OleDbType.Integer, 0, "BronchialsekretSchlechtAbhusten"),
            new System.Data.OleDb.OleDbParameter("StarkeAuswurf", System.Data.OleDb.OleDbType.Integer, 0, "StarkeAuswurf"),
            new System.Data.OleDb.OleDbParameter("AtemnotleichterAnstrengung", System.Data.OleDb.OleDbType.Integer, 0, "AtemnotleichterAnstrengung"),
            new System.Data.OleDb.OleDbParameter("HilfeMedikamentenversorgung", System.Data.OleDb.OleDbType.Integer, 0, "HilfeMedikamentenversorgung"),
            new System.Data.OleDb.OleDbParameter("WieHandhabenMitDuschenBaden", System.Data.OleDb.OleDbType.LongVarChar, 0, "WieHandhabenMitDuschenBaden"),
            new System.Data.OleDb.OleDbParameter("Koerperpflegemittel", System.Data.OleDb.OleDbType.LongVarChar, 0, "Koerperpflegemittel"),
            new System.Data.OleDb.OleDbParameter("KoerperpflegemittelVersorger", System.Data.OleDb.OleDbType.VarChar, 0, "KoerperpflegemittelVersorger"),
            new System.Data.OleDb.OleDbParameter("Rasieren", System.Data.OleDb.OleDbType.LongVarChar, 0, "Rasieren"),
            new System.Data.OleDb.OleDbParameter("Haarpflege", System.Data.OleDb.OleDbType.LongVarChar, 0, "Haarpflege"),
            new System.Data.OleDb.OleDbParameter("ZahnFusspflegeHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZahnFusspflegeHilfeJN"),
            new System.Data.OleDb.OleDbParameter("SchminkenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchminkenJN"),
            new System.Data.OleDb.OleDbParameter("SichPflegenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichPflegenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichPflegenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichPflegenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("HilfebWaschenDuschenBaden", System.Data.OleDb.OleDbType.Integer, 0, "HilfebWaschenDuschenBaden"),
            new System.Data.OleDb.OleDbParameter("HilfebHaareOberUnterkoerper", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHaareOberUnterkoerper"),
            new System.Data.OleDb.OleDbParameter("HilfebRasur", System.Data.OleDb.OleDbType.Integer, 0, "HilfebRasur"),
            new System.Data.OleDb.OleDbParameter("HilfebFussFingernagelpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebFussFingernagelpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebIntimpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebIntimpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebHautGesichtspflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHautGesichtspflege"),
            new System.Data.OleDb.OleDbParameter("HilfebOhrenNasenAugenpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebOhrenNasenAugenpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebMundZahnpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebMundZahnpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebHautdefekte", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHautdefekte"),
            new System.Data.OleDb.OleDbParameter("Starkschwitzen", System.Data.OleDb.OleDbType.Integer, 0, "Starkschwitzen"),
            new System.Data.OleDb.OleDbParameter("SpeisenGetraenke", System.Data.OleDb.OleDbType.LongVarChar, 0, "SpeisenGetraenke"),
            new System.Data.OleDb.OleDbParameter("SpeisenGetraenkeAblehnen", System.Data.OleDb.OleDbType.LongVarChar, 0, "SpeisenGetraenkeAblehnen"),
            new System.Data.OleDb.OleDbParameter("AnzahlLiterTrinken", System.Data.OleDb.OleDbType.Double, 0, "AnzahlLiterTrinken"),
            new System.Data.OleDb.OleDbParameter("MahlzeitInDerGemeinschaftJN", System.Data.OleDb.OleDbType.Boolean, 0, "MahlzeitInDerGemeinschaftJN"),
            new System.Data.OleDb.OleDbParameter("FruehstueckSpaetFruehEinnehmen", System.Data.OleDb.OleDbType.VarChar, 0, "FruehstueckSpaetFruehEinnehmen"),
            new System.Data.OleDb.OleDbParameter("DiatSchonkostSondenernaehrung", System.Data.OleDb.OleDbType.LongVarChar, 0, "DiatSchonkostSondenernaehrung"),
            new System.Data.OleDb.OleDbParameter("AnzahlMalzeiten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlMalzeiten"),
            new System.Data.OleDb.OleDbParameter("EssenTrinkenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "EssenTrinkenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("EssenTrinkenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "EssenTrinkenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("NotwendigkeitEsssenTrinken", System.Data.OleDb.OleDbType.Integer, 0, "NotwendigkeitEsssenTrinken"),
            new System.Data.OleDb.OleDbParameter("NotwendigkeitDiaet", System.Data.OleDb.OleDbType.Integer, 0, "NotwendigkeitDiaet"),
            new System.Data.OleDb.OleDbParameter("KauSchluckstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "KauSchluckstoerungen"),
            new System.Data.OleDb.OleDbParameter("IsstSehrlangsamm", System.Data.OleDb.OleDbType.Integer, 0, "IsstSehrlangsamm"),
            new System.Data.OleDb.OleDbParameter("NahrungMundgerechtZubereiten", System.Data.OleDb.OleDbType.Integer, 0, "NahrungMundgerechtZubereiten"),
            new System.Data.OleDb.OleDbParameter("MahlzeiteinnahmeHilfestellung", System.Data.OleDb.OleDbType.Integer, 0, "MahlzeiteinnahmeHilfestellung"),
            new System.Data.OleDb.OleDbParameter("SondePEGKomplett", System.Data.OleDb.OleDbType.Integer, 0, "SondePEGKomplett"),
            new System.Data.OleDb.OleDbParameter("SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme", System.Data.OleDb.OleDbType.Integer, 0, "SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme"),
            new System.Data.OleDb.OleDbParameter("UnterstuezungUeberwachungFluessigkeitsaufnahme", System.Data.OleDb.OleDbType.Integer, 0, "UnterstuezungUeberwachungFluessigkeitsaufnahme"),
            new System.Data.OleDb.OleDbParameter("HaufigErbrechen", System.Data.OleDb.OleDbType.Integer, 0, "HaufigErbrechen"),
            new System.Data.OleDb.OleDbParameter("KannBlaseDarmKontrollierenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannBlaseDarmKontrollierenJN"),
            new System.Data.OleDb.OleDbParameter("ZeitenToiletteAufsuchen", System.Data.OleDb.OleDbType.LongVarChar, 0, "ZeitenToiletteAufsuchen"),
            new System.Data.OleDb.OleDbParameter("ToilettengangHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "ToilettengangHilfeJN"),
            new System.Data.OleDb.OleDbParameter("ToilettenHilfsmittel", System.Data.OleDb.OleDbType.LongVarChar, 0, "ToilettenHilfsmittel"),
            new System.Data.OleDb.OleDbParameter("MedikamenteBlasenDarmfunktion", System.Data.OleDb.OleDbType.LongVarChar, 0, "MedikamenteBlasenDarmfunktion"),
            new System.Data.OleDb.OleDbParameter("AusscheidenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "AusscheidenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("AusscheidenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AusscheidenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("IstZeitweiseUrinStuhlinkontinent", System.Data.OleDb.OleDbType.Integer, 0, "IstZeitweiseUrinStuhlinkontinent"),
            new System.Data.OleDb.OleDbParameter("UrinStuhlKrankheit", System.Data.OleDb.OleDbType.Integer, 0, "UrinStuhlKrankheit"),
            new System.Data.OleDb.OleDbParameter("ZeitlUrinStuhlKrankheit", System.Data.OleDb.OleDbType.Integer, 0, "ZeitlUrinStuhlKrankheit"),
            new System.Data.OleDb.OleDbParameter("VerstopfungenDurchfaellen", System.Data.OleDb.OleDbType.Integer, 0, "VerstopfungenDurchfaellen"),
            new System.Data.OleDb.OleDbParameter("VerstopfungDurchfallKrakheit", System.Data.OleDb.OleDbType.Integer, 0, "VerstopfungDurchfallKrakheit"),
            new System.Data.OleDb.OleDbParameter("ZeitlVerstopfungDurchfallKrakheit", System.Data.OleDb.OleDbType.Integer, 0, "ZeitlVerstopfungDurchfallKrakheit"),
            new System.Data.OleDb.OleDbParameter("DauerSuprapubischenkatheter", System.Data.OleDb.OleDbType.Integer, 0, "DauerSuprapubischenkatheter"),
            new System.Data.OleDb.OleDbParameter("NeigtZuInfektionen", System.Data.OleDb.OleDbType.Integer, 0, "NeigtZuInfektionen"),
            new System.Data.OleDb.OleDbParameter("HatAnusPraeter", System.Data.OleDb.OleDbType.Integer, 0, "HatAnusPraeter"),
            new System.Data.OleDb.OleDbParameter("KannToiletteNichtSelbstaendigBenutzen", System.Data.OleDb.OleDbType.Integer, 0, "KannToiletteNichtSelbstaendigBenutzen"),
            new System.Data.OleDb.OleDbParameter("UnterstuetzungEinnahmeAbfuehrmittel", System.Data.OleDb.OleDbType.Integer, 0, "UnterstuetzungEinnahmeAbfuehrmittel"),
            new System.Data.OleDb.OleDbParameter("Kleidung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kleidung"),
            new System.Data.OleDb.OleDbParameter("Waeschewechsel", System.Data.OleDb.OleDbType.LongVarChar, 0, "Waeschewechsel"),
            new System.Data.OleDb.OleDbParameter("SichKleidenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichKleidenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichKleidenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichKleidenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KleiderauswahlHilfe", System.Data.OleDb.OleDbType.Integer, 0, "KleiderauswahlHilfe"),
            new System.Data.OleDb.OleDbParameter("WegenDesoriontiertheitOefterAusziehen", System.Data.OleDb.OleDbType.Integer, 0, "WegenDesoriontiertheitOefterAusziehen"),
            new System.Data.OleDb.OleDbParameter("FehlendeEinsichtFuerAngemesseneKleidung", System.Data.OleDb.OleDbType.Integer, 0, "FehlendeEinsichtFuerAngemesseneKleidung"),
            new System.Data.OleDb.OleDbParameter("FehlendeEinsichtFuerNotwendigeWaeschewechsel", System.Data.OleDb.OleDbType.Integer, 0, "FehlendeEinsichtFuerNotwendigeWaeschewechsel"),
            new System.Data.OleDb.OleDbParameter("KannVerschluesseNichtHandhaben", System.Data.OleDb.OleDbType.Integer, 0, "KannVerschluesseNichtHandhaben"),
            new System.Data.OleDb.OleDbParameter("KannNichtKleidungUeberKopfAusziehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtKleidungUeberKopfAusziehen"),
            new System.Data.OleDb.OleDbParameter("KannNichtKleidungUeberFusseAnziehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtKleidungUeberFusseAnziehen"),
            new System.Data.OleDb.OleDbParameter("SchlafenVonBis", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafenVonBis"),
            new System.Data.OleDb.OleDbParameter("MittagsschlafJN", System.Data.OleDb.OleDbType.Boolean, 0, "MittagsschlafJN"),
            new System.Data.OleDb.OleDbParameter("NachtsNachschauenJN", System.Data.OleDb.OleDbType.Boolean, 0, "NachtsNachschauenJN"),
            new System.Data.OleDb.OleDbParameter("SchlafBesonderheiten", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SchlafMedikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafMedikamente"),
            new System.Data.OleDb.OleDbParameter("SchlafGewohnheiten", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafGewohnheiten"),
            new System.Data.OleDb.OleDbParameter("SchlafTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchlafTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SchlafPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchlafPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("HateinschlafDurchschlafstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "HateinschlafDurchschlafstoerungen"),
            new System.Data.OleDb.OleDbParameter("HatPsychischeKrankheitsbedingteSchlafstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "HatPsychischeKrankheitsbedingteSchlafstoerungen"),
            new System.Data.OleDb.OleDbParameter("HatGestoertenTagNachtrhytmus", System.Data.OleDb.OleDbType.Integer, 0, "HatGestoertenTagNachtrhytmus"),
            new System.Data.OleDb.OleDbParameter("Beruf", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beruf"),
            new System.Data.OleDb.OleDbParameter("GerneBeschaeftigtMit", System.Data.OleDb.OleDbType.LongVarChar, 0, "GerneBeschaeftigtMit"),
            new System.Data.OleDb.OleDbParameter("Tagsablauf", System.Data.OleDb.OleDbType.LongVarChar, 0, "Tagsablauf"),
            new System.Data.OleDb.OleDbParameter("TagesablaufsgestaltungHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "TagesablaufsgestaltungHilfeJN"),
            new System.Data.OleDb.OleDbParameter("TagesablaufsgestaltungHilfe", System.Data.OleDb.OleDbType.LongVarChar, 0, "TagesablaufsgestaltungHilfe"),
            new System.Data.OleDb.OleDbParameter("SichBeschaeftigenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichBeschaeftigenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichBeschaeftigenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichBeschaeftigenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("TagesablaufNachFrueherenGewohnheiten", System.Data.OleDb.OleDbType.Integer, 0, "TagesablaufNachFrueherenGewohnheiten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktAufstehenBettGehenAbstimmen", System.Data.OleDb.OleDbType.Integer, 0, "ZeitpunktAufstehenBettGehenAbstimmen"),
            new System.Data.OleDb.OleDbParameter("IntegrationInTaeglicheAblaufe", System.Data.OleDb.OleDbType.Integer, 0, "IntegrationInTaeglicheAblaufe"),
            new System.Data.OleDb.OleDbParameter("MaennlicheWeiblichePflegeperson", System.Data.OleDb.OleDbType.LongVarChar, 0, "MaennlicheWeiblichePflegeperson"),
            new System.Data.OleDb.OleDbParameter("MakeUpSchmuck", System.Data.OleDb.OleDbType.LongVarChar, 0, "MakeUpSchmuck"),
            new System.Data.OleDb.OleDbParameter("HaarBarttracht", System.Data.OleDb.OleDbType.LongVarChar, 0, "HaarBarttracht"),
            new System.Data.OleDb.OleDbParameter("SichFuehlenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichFuehlenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichFuehlenpflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichFuehlenpflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("SchagefuehlIntimepflegeBeruecksichtigen", System.Data.OleDb.OleDbType.Integer, 0, "SchagefuehlIntimepflegeBeruecksichtigen"),
            new System.Data.OleDb.OleDbParameter("WuenschtMaennlicheWeiblicheBestimmtePflegeperson", System.Data.OleDb.OleDbType.Integer, 0, "WuenschtMaennlicheWeiblicheBestimmtePflegeperson"),
            new System.Data.OleDb.OleDbParameter("KannFrisurNichtSelbstHerrichten", System.Data.OleDb.OleDbType.Integer, 0, "KannFrisurNichtSelbstHerrichten"),
            new System.Data.OleDb.OleDbParameter("KannSchmuckNichtSelbstAnlegen", System.Data.OleDb.OleDbType.Integer, 0, "KannSchmuckNichtSelbstAnlegen"),
            new System.Data.OleDb.OleDbParameter("HilfsmittelZurMobilitaetJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfsmittelZurMobilitaetJN"),
            new System.Data.OleDb.OleDbParameter("BettgitterJN", System.Data.OleDb.OleDbType.Boolean, 0, "BettgitterJN"),
            new System.Data.OleDb.OleDbParameter("ZimmerVerschlossen", System.Data.OleDb.OleDbType.LongVarChar, 0, "ZimmerVerschlossen"),
            new System.Data.OleDb.OleDbParameter("HilfeHerbeirufenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfeHerbeirufenJN"),
            new System.Data.OleDb.OleDbParameter("OhneHilfeZurechtJN", System.Data.OleDb.OleDbType.Boolean, 0, "OhneHilfeZurechtJN"),
            new System.Data.OleDb.OleDbParameter("UmgebungTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmgebungTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("UmgebungPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmgebungPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KannGefahrenNichtEinschaetzen", System.Data.OleDb.OleDbType.Integer, 0, "KannGefahrenNichtEinschaetzen"),
            new System.Data.OleDb.OleDbParameter("InDerEinrichtungVerirrn", System.Data.OleDb.OleDbType.Integer, 0, "InDerEinrichtungVerirrn"),
            new System.Data.OleDb.OleDbParameter("Sicherheit", System.Data.OleDb.OleDbType.Integer, 0, "Sicherheit"),
            new System.Data.OleDb.OleDbParameter("MedikamenteneinnahmeUeberwachen", System.Data.OleDb.OleDbType.Integer, 0, "MedikamenteneinnahmeUeberwachen"),
            new System.Data.OleDb.OleDbParameter("Kontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kontakte"),
            new System.Data.OleDb.OleDbParameter("Keinekontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "Keinekontakte"),
            new System.Data.OleDb.OleDbParameter("ZeitKeineBesuche", System.Data.OleDb.OleDbType.VarChar, 0, "ZeitKeineBesuche"),
            new System.Data.OleDb.OleDbParameter("AndereKontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "AndereKontakte"),
            new System.Data.OleDb.OleDbParameter("KontakteSelbsstaendigHerstellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KontakteSelbsstaendigHerstellenJN"),
            new System.Data.OleDb.OleDbParameter("SozialeTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialeTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SozialePflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialePflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("BewohnerBenoetigtAktivierung", System.Data.OleDb.OleDbType.Integer, 0, "BewohnerBenoetigtAktivierung"),
            new System.Data.OleDb.OleDbParameter("HilfeBeiDerKontakpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfeBeiDerKontakpflege"),
            new System.Data.OleDb.OleDbParameter("InBetreuungImHausIntegrieren", System.Data.OleDb.OleDbType.Integer, 0, "InBetreuungImHausIntegrieren"),
            new System.Data.OleDb.OleDbParameter("SterbephaseBetreuung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbephaseBetreuung"),
            new System.Data.OleDb.OleDbParameter("Versorger", System.Data.OleDb.OleDbType.LongVarChar, 0, "Versorger"),
            new System.Data.OleDb.OleDbParameter("ErfahrungenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErfahrungenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("ErfahrungenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErfahrungenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KannKrankheitBehinderungNichtAkzeptieren", System.Data.OleDb.OleDbType.Integer, 0, "KannKrankheitBehinderungNichtAkzeptieren"),
            new System.Data.OleDb.OleDbParameter("LeidetAnVerlust", System.Data.OleDb.OleDbType.Integer, 0, "LeidetAnVerlust"),
            new System.Data.OleDb.OleDbParameter("LeidetAnVerlustVon", System.Data.OleDb.OleDbType.LongVarChar, 0, "LeidetAnVerlustVon"),
            new System.Data.OleDb.OleDbParameter("IstMisstraurisch", System.Data.OleDb.OleDbType.Integer, 0, "IstMisstraurisch"),
            new System.Data.OleDb.OleDbParameter("IstMisstraurischGegen", System.Data.OleDb.OleDbType.LongVarChar, 0, "IstMisstraurischGegen"),
            new System.Data.OleDb.OleDbParameter("HatSchmerzen", System.Data.OleDb.OleDbType.Integer, 0, "HatSchmerzen"),
            new System.Data.OleDb.OleDbParameter("Schmerzen", System.Data.OleDb.OleDbType.LongVarChar, 0, "Schmerzen"),
            new System.Data.OleDb.OleDbParameter("HatAngst", System.Data.OleDb.OleDbType.Integer, 0, "HatAngst"),
            new System.Data.OleDb.OleDbParameter("AngstVon", System.Data.OleDb.OleDbType.LongVarChar, 0, "AngstVon"),
            new System.Data.OleDb.OleDbParameter("Biographie", System.Data.OleDb.OleDbType.LongVarChar, 0, "Biographie"),
            new System.Data.OleDb.OleDbParameter("BiographieTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "BiographieTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("BiographiePflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BiographiePflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("UnbewaeltigtenLebenserfahrungen", System.Data.OleDb.OleDbType.Integer, 0, "UnbewaeltigtenLebenserfahrungen"),
            new System.Data.OleDb.OleDbParameter("Vermisst", System.Data.OleDb.OleDbType.Integer, 0, "Vermisst"),
            new System.Data.OleDb.OleDbParameter("VermisstBeschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "VermisstBeschreibung"),
            new System.Data.OleDb.OleDbParameter("HatSorge", System.Data.OleDb.OleDbType.Integer, 0, "HatSorge"),
            new System.Data.OleDb.OleDbParameter("SorgeUm", System.Data.OleDb.OleDbType.LongVarChar, 0, "SorgeUm")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 16, "IDPatient")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDPatient", System.Data.OleDb.OleDbType.Guid, 0, "IDPatient"),
            new System.Data.OleDb.OleDbParameter("IDBenutzer", System.Data.OleDb.OleDbType.Guid, 0, "IDBenutzer"),
            new System.Data.OleDb.OleDbParameter("ErstelltAm", System.Data.OleDb.OleDbType.Date, 16, "ErstelltAm"),
            new System.Data.OleDb.OleDbParameter("BrilleJN", System.Data.OleDb.OleDbType.Boolean, 0, "BrilleJN"),
            new System.Data.OleDb.OleDbParameter("HoergeraetJN", System.Data.OleDb.OleDbType.Boolean, 0, "HoergeraetJN"),
            new System.Data.OleDb.OleDbParameter("KannMitteilenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannMitteilenJN"),
            new System.Data.OleDb.OleDbParameter("KommunizierenTagesstuktur", System.Data.OleDb.OleDbType.Integer, 0, "KommunizierenTagesstuktur"),
            new System.Data.OleDb.OleDbParameter("KommunizierenPflegeplanung", System.Data.OleDb.OleDbType.Integer, 0, "KommunizierenPflegeplanung"),
            new System.Data.OleDb.OleDbParameter("Wuensche", System.Data.OleDb.OleDbType.LongVarChar, 0, "Wuensche"),
            new System.Data.OleDb.OleDbParameter("SchwerhoerigTaubStummBlind", System.Data.OleDb.OleDbType.Integer, 0, "SchwerhoerigTaubStummBlind"),
            new System.Data.OleDb.OleDbParameter("HoergeraetNichtHandhaben", System.Data.OleDb.OleDbType.Integer, 0, "HoergeraetNichtHandhaben"),
            new System.Data.OleDb.OleDbParameter("Sprachstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "Sprachstoerungen"),
            new System.Data.OleDb.OleDbParameter("Sichtfeldeinschraenkungen", System.Data.OleDb.OleDbType.Integer, 0, "Sichtfeldeinschraenkungen"),
            new System.Data.OleDb.OleDbParameter("IstZeitloertlSituativZurPersonNichtOrientiert", System.Data.OleDb.OleDbType.Integer, 0, "IstZeitloertlSituativZurPersonNichtOrientiert"),
            new System.Data.OleDb.OleDbParameter("KannSelbstBewegenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannSelbstBewegenJN"),
            new System.Data.OleDb.OleDbParameter("GehentJN", System.Data.OleDb.OleDbType.Boolean, 0, "GehentJN"),
            new System.Data.OleDb.OleDbParameter("StehenJN", System.Data.OleDb.OleDbType.Boolean, 0, "StehenJN"),
            new System.Data.OleDb.OleDbParameter("SitzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SitzenJN"),
            new System.Data.OleDb.OleDbParameter("TreppenSteigenJN", System.Data.OleDb.OleDbType.Boolean, 0, "TreppenSteigenJN"),
            new System.Data.OleDb.OleDbParameter("LaufenJN", System.Data.OleDb.OleDbType.Boolean, 0, "LaufenJN"),
            new System.Data.OleDb.OleDbParameter("HinsetzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HinsetzenJN"),
            new System.Data.OleDb.OleDbParameter("HinlegenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HinlegenJN"),
            new System.Data.OleDb.OleDbParameter("HilfsmittelBenutzenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfsmittelBenutzenJN"),
            new System.Data.OleDb.OleDbParameter("SpatzierenGehenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpatzierenGehenJN"),
            new System.Data.OleDb.OleDbParameter("WannWieOftSpatzieren", System.Data.OleDb.OleDbType.LongVarChar, 0, "WannWieOftSpatzieren"),
            new System.Data.OleDb.OleDbParameter("KoerperlicheaktivitaetenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KoerperlicheaktivitaetenJN"),
            new System.Data.OleDb.OleDbParameter("AktivitaetenBeschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "AktivitaetenBeschreibung"),
            new System.Data.OleDb.OleDbParameter("BewegenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "BewegenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("BewegenPflegeplanung", System.Data.OleDb.OleDbType.Boolean, 0, "BewegenPflegeplanung"),
            new System.Data.OleDb.OleDbParameter("KontrakturenvorhandenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KontrakturenvorhandenJN"),
            new System.Data.OleDb.OleDbParameter("SpitzfussstellungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SpitzfussstellungJN"),
            new System.Data.OleDb.OleDbParameter("MaxGebEllenbogenJN", System.Data.OleDb.OleDbType.Boolean, 0, "MaxGebEllenbogenJN"),
            new System.Data.OleDb.OleDbParameter("KniegelenkJN", System.Data.OleDb.OleDbType.Boolean, 0, "KniegelenkJN"),
            new System.Data.OleDb.OleDbParameter("GefausteteHandJN", System.Data.OleDb.OleDbType.Boolean, 0, "GefausteteHandJN"),
            new System.Data.OleDb.OleDbParameter("KontrakturenBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "KontrakturenBeschreibung"),
            new System.Data.OleDb.OleDbParameter("DekubitusVorhandenJN", System.Data.OleDb.OleDbType.Boolean, 0, "DekubitusVorhandenJN"),
            new System.Data.OleDb.OleDbParameter("DekubitusBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "DekubitusBeschreibung"),
            new System.Data.OleDb.OleDbParameter("SturtzgefahrJN", System.Data.OleDb.OleDbType.Boolean, 0, "SturtzgefahrJN"),
            new System.Data.OleDb.OleDbParameter("Bewegungseinschraenkung", System.Data.OleDb.OleDbType.Integer, 0, "Bewegungseinschraenkung"),
            new System.Data.OleDb.OleDbParameter("KannNichtAlleinGehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtAlleinGehen"),
            new System.Data.OleDb.OleDbParameter("KannNichtAlleinLageImBettVeraendern", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtAlleinLageImBettVeraendern"),
            new System.Data.OleDb.OleDbParameter("IstBettlaegerig", System.Data.OleDb.OleDbType.Integer, 0, "IstBettlaegerig"),
            new System.Data.OleDb.OleDbParameter("TransferAufstehenHinlegen", System.Data.OleDb.OleDbType.Integer, 0, "TransferAufstehenHinlegen"),
            new System.Data.OleDb.OleDbParameter("BlutdruckZuckerRegelmaessigGemessenJN", System.Data.OleDb.OleDbType.Boolean, 0, "BlutdruckZuckerRegelmaessigGemessenJN"),
            new System.Data.OleDb.OleDbParameter("KompressionsstruempfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "KompressionsstruempfeJN"),
            new System.Data.OleDb.OleDbParameter("Zimmertemperatur", System.Data.OleDb.OleDbType.Integer, 0, "Zimmertemperatur"),
            new System.Data.OleDb.OleDbParameter("MedikamenteRegelmaessigJN", System.Data.OleDb.OleDbType.Boolean, 0, "MedikamenteRegelmaessigJN"),
            new System.Data.OleDb.OleDbParameter("Medikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "Medikamente"),
            new System.Data.OleDb.OleDbParameter("VitaleFunkTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "VitaleFunkTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("VitaleFunkPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "VitaleFunkPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("ErhoehteErnidriegteBlutdruck", System.Data.OleDb.OleDbType.Integer, 0, "ErhoehteErnidriegteBlutdruck"),
            new System.Data.OleDb.OleDbParameter("Durchblutungsstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "Durchblutungsstoerungen"),
            new System.Data.OleDb.OleDbParameter("FriertLeicht", System.Data.OleDb.OleDbType.Integer, 0, "FriertLeicht"),
            new System.Data.OleDb.OleDbParameter("DiabetesUnterUeberZucker", System.Data.OleDb.OleDbType.Integer, 0, "DiabetesUnterUeberZucker"),
            new System.Data.OleDb.OleDbParameter("Sauerstoffmangel", System.Data.OleDb.OleDbType.Integer, 0, "Sauerstoffmangel"),
            new System.Data.OleDb.OleDbParameter("BronchialsekretSchlechtAbhusten", System.Data.OleDb.OleDbType.Integer, 0, "BronchialsekretSchlechtAbhusten"),
            new System.Data.OleDb.OleDbParameter("StarkeAuswurf", System.Data.OleDb.OleDbType.Integer, 0, "StarkeAuswurf"),
            new System.Data.OleDb.OleDbParameter("AtemnotleichterAnstrengung", System.Data.OleDb.OleDbType.Integer, 0, "AtemnotleichterAnstrengung"),
            new System.Data.OleDb.OleDbParameter("HilfeMedikamentenversorgung", System.Data.OleDb.OleDbType.Integer, 0, "HilfeMedikamentenversorgung"),
            new System.Data.OleDb.OleDbParameter("WieHandhabenMitDuschenBaden", System.Data.OleDb.OleDbType.LongVarChar, 0, "WieHandhabenMitDuschenBaden"),
            new System.Data.OleDb.OleDbParameter("Koerperpflegemittel", System.Data.OleDb.OleDbType.LongVarChar, 0, "Koerperpflegemittel"),
            new System.Data.OleDb.OleDbParameter("KoerperpflegemittelVersorger", System.Data.OleDb.OleDbType.VarChar, 0, "KoerperpflegemittelVersorger"),
            new System.Data.OleDb.OleDbParameter("Rasieren", System.Data.OleDb.OleDbType.LongVarChar, 0, "Rasieren"),
            new System.Data.OleDb.OleDbParameter("Haarpflege", System.Data.OleDb.OleDbType.LongVarChar, 0, "Haarpflege"),
            new System.Data.OleDb.OleDbParameter("ZahnFusspflegeHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZahnFusspflegeHilfeJN"),
            new System.Data.OleDb.OleDbParameter("SchminkenJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchminkenJN"),
            new System.Data.OleDb.OleDbParameter("SichPflegenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichPflegenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichPflegenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichPflegenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("HilfebWaschenDuschenBaden", System.Data.OleDb.OleDbType.Integer, 0, "HilfebWaschenDuschenBaden"),
            new System.Data.OleDb.OleDbParameter("HilfebHaareOberUnterkoerper", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHaareOberUnterkoerper"),
            new System.Data.OleDb.OleDbParameter("HilfebRasur", System.Data.OleDb.OleDbType.Integer, 0, "HilfebRasur"),
            new System.Data.OleDb.OleDbParameter("HilfebFussFingernagelpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebFussFingernagelpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebIntimpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebIntimpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebHautGesichtspflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHautGesichtspflege"),
            new System.Data.OleDb.OleDbParameter("HilfebOhrenNasenAugenpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebOhrenNasenAugenpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebMundZahnpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfebMundZahnpflege"),
            new System.Data.OleDb.OleDbParameter("HilfebHautdefekte", System.Data.OleDb.OleDbType.Integer, 0, "HilfebHautdefekte"),
            new System.Data.OleDb.OleDbParameter("Starkschwitzen", System.Data.OleDb.OleDbType.Integer, 0, "Starkschwitzen"),
            new System.Data.OleDb.OleDbParameter("SpeisenGetraenke", System.Data.OleDb.OleDbType.LongVarChar, 0, "SpeisenGetraenke"),
            new System.Data.OleDb.OleDbParameter("SpeisenGetraenkeAblehnen", System.Data.OleDb.OleDbType.LongVarChar, 0, "SpeisenGetraenkeAblehnen"),
            new System.Data.OleDb.OleDbParameter("AnzahlLiterTrinken", System.Data.OleDb.OleDbType.Double, 0, "AnzahlLiterTrinken"),
            new System.Data.OleDb.OleDbParameter("MahlzeitInDerGemeinschaftJN", System.Data.OleDb.OleDbType.Boolean, 0, "MahlzeitInDerGemeinschaftJN"),
            new System.Data.OleDb.OleDbParameter("FruehstueckSpaetFruehEinnehmen", System.Data.OleDb.OleDbType.VarChar, 0, "FruehstueckSpaetFruehEinnehmen"),
            new System.Data.OleDb.OleDbParameter("DiatSchonkostSondenernaehrung", System.Data.OleDb.OleDbType.LongVarChar, 0, "DiatSchonkostSondenernaehrung"),
            new System.Data.OleDb.OleDbParameter("AnzahlMalzeiten", System.Data.OleDb.OleDbType.Integer, 0, "AnzahlMalzeiten"),
            new System.Data.OleDb.OleDbParameter("EssenTrinkenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "EssenTrinkenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("EssenTrinkenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "EssenTrinkenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("NotwendigkeitEsssenTrinken", System.Data.OleDb.OleDbType.Integer, 0, "NotwendigkeitEsssenTrinken"),
            new System.Data.OleDb.OleDbParameter("NotwendigkeitDiaet", System.Data.OleDb.OleDbType.Integer, 0, "NotwendigkeitDiaet"),
            new System.Data.OleDb.OleDbParameter("KauSchluckstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "KauSchluckstoerungen"),
            new System.Data.OleDb.OleDbParameter("IsstSehrlangsamm", System.Data.OleDb.OleDbType.Integer, 0, "IsstSehrlangsamm"),
            new System.Data.OleDb.OleDbParameter("NahrungMundgerechtZubereiten", System.Data.OleDb.OleDbType.Integer, 0, "NahrungMundgerechtZubereiten"),
            new System.Data.OleDb.OleDbParameter("MahlzeiteinnahmeHilfestellung", System.Data.OleDb.OleDbType.Integer, 0, "MahlzeiteinnahmeHilfestellung"),
            new System.Data.OleDb.OleDbParameter("SondePEGKomplett", System.Data.OleDb.OleDbType.Integer, 0, "SondePEGKomplett"),
            new System.Data.OleDb.OleDbParameter("SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme", System.Data.OleDb.OleDbType.Integer, 0, "SondenernaehrungKombinationmitOralerFluessigkeitsaufnahme"),
            new System.Data.OleDb.OleDbParameter("UnterstuezungUeberwachungFluessigkeitsaufnahme", System.Data.OleDb.OleDbType.Integer, 0, "UnterstuezungUeberwachungFluessigkeitsaufnahme"),
            new System.Data.OleDb.OleDbParameter("HaufigErbrechen", System.Data.OleDb.OleDbType.Integer, 0, "HaufigErbrechen"),
            new System.Data.OleDb.OleDbParameter("KannBlaseDarmKontrollierenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KannBlaseDarmKontrollierenJN"),
            new System.Data.OleDb.OleDbParameter("ZeitenToiletteAufsuchen", System.Data.OleDb.OleDbType.LongVarChar, 0, "ZeitenToiletteAufsuchen"),
            new System.Data.OleDb.OleDbParameter("ToilettengangHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "ToilettengangHilfeJN"),
            new System.Data.OleDb.OleDbParameter("ToilettenHilfsmittel", System.Data.OleDb.OleDbType.LongVarChar, 0, "ToilettenHilfsmittel"),
            new System.Data.OleDb.OleDbParameter("MedikamenteBlasenDarmfunktion", System.Data.OleDb.OleDbType.LongVarChar, 0, "MedikamenteBlasenDarmfunktion"),
            new System.Data.OleDb.OleDbParameter("AusscheidenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "AusscheidenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("AusscheidenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "AusscheidenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("IstZeitweiseUrinStuhlinkontinent", System.Data.OleDb.OleDbType.Integer, 0, "IstZeitweiseUrinStuhlinkontinent"),
            new System.Data.OleDb.OleDbParameter("UrinStuhlKrankheit", System.Data.OleDb.OleDbType.Integer, 0, "UrinStuhlKrankheit"),
            new System.Data.OleDb.OleDbParameter("ZeitlUrinStuhlKrankheit", System.Data.OleDb.OleDbType.Integer, 0, "ZeitlUrinStuhlKrankheit"),
            new System.Data.OleDb.OleDbParameter("VerstopfungenDurchfaellen", System.Data.OleDb.OleDbType.Integer, 0, "VerstopfungenDurchfaellen"),
            new System.Data.OleDb.OleDbParameter("VerstopfungDurchfallKrakheit", System.Data.OleDb.OleDbType.Integer, 0, "VerstopfungDurchfallKrakheit"),
            new System.Data.OleDb.OleDbParameter("ZeitlVerstopfungDurchfallKrakheit", System.Data.OleDb.OleDbType.Integer, 0, "ZeitlVerstopfungDurchfallKrakheit"),
            new System.Data.OleDb.OleDbParameter("DauerSuprapubischenkatheter", System.Data.OleDb.OleDbType.Integer, 0, "DauerSuprapubischenkatheter"),
            new System.Data.OleDb.OleDbParameter("NeigtZuInfektionen", System.Data.OleDb.OleDbType.Integer, 0, "NeigtZuInfektionen"),
            new System.Data.OleDb.OleDbParameter("HatAnusPraeter", System.Data.OleDb.OleDbType.Integer, 0, "HatAnusPraeter"),
            new System.Data.OleDb.OleDbParameter("KannToiletteNichtSelbstaendigBenutzen", System.Data.OleDb.OleDbType.Integer, 0, "KannToiletteNichtSelbstaendigBenutzen"),
            new System.Data.OleDb.OleDbParameter("UnterstuetzungEinnahmeAbfuehrmittel", System.Data.OleDb.OleDbType.Integer, 0, "UnterstuetzungEinnahmeAbfuehrmittel"),
            new System.Data.OleDb.OleDbParameter("Kleidung", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kleidung"),
            new System.Data.OleDb.OleDbParameter("Waeschewechsel", System.Data.OleDb.OleDbType.LongVarChar, 0, "Waeschewechsel"),
            new System.Data.OleDb.OleDbParameter("SichKleidenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichKleidenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichKleidenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichKleidenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KleiderauswahlHilfe", System.Data.OleDb.OleDbType.Integer, 0, "KleiderauswahlHilfe"),
            new System.Data.OleDb.OleDbParameter("WegenDesoriontiertheitOefterAusziehen", System.Data.OleDb.OleDbType.Integer, 0, "WegenDesoriontiertheitOefterAusziehen"),
            new System.Data.OleDb.OleDbParameter("FehlendeEinsichtFuerAngemesseneKleidung", System.Data.OleDb.OleDbType.Integer, 0, "FehlendeEinsichtFuerAngemesseneKleidung"),
            new System.Data.OleDb.OleDbParameter("FehlendeEinsichtFuerNotwendigeWaeschewechsel", System.Data.OleDb.OleDbType.Integer, 0, "FehlendeEinsichtFuerNotwendigeWaeschewechsel"),
            new System.Data.OleDb.OleDbParameter("KannVerschluesseNichtHandhaben", System.Data.OleDb.OleDbType.Integer, 0, "KannVerschluesseNichtHandhaben"),
            new System.Data.OleDb.OleDbParameter("KannNichtKleidungUeberKopfAusziehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtKleidungUeberKopfAusziehen"),
            new System.Data.OleDb.OleDbParameter("KannNichtKleidungUeberFusseAnziehen", System.Data.OleDb.OleDbType.Integer, 0, "KannNichtKleidungUeberFusseAnziehen"),
            new System.Data.OleDb.OleDbParameter("SchlafenVonBis", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafenVonBis"),
            new System.Data.OleDb.OleDbParameter("MittagsschlafJN", System.Data.OleDb.OleDbType.Boolean, 0, "MittagsschlafJN"),
            new System.Data.OleDb.OleDbParameter("NachtsNachschauenJN", System.Data.OleDb.OleDbType.Boolean, 0, "NachtsNachschauenJN"),
            new System.Data.OleDb.OleDbParameter("SchlafBesonderheiten", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafBesonderheiten"),
            new System.Data.OleDb.OleDbParameter("SchlafMedikamente", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafMedikamente"),
            new System.Data.OleDb.OleDbParameter("SchlafGewohnheiten", System.Data.OleDb.OleDbType.LongVarChar, 0, "SchlafGewohnheiten"),
            new System.Data.OleDb.OleDbParameter("SchlafTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchlafTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SchlafPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SchlafPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("HateinschlafDurchschlafstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "HateinschlafDurchschlafstoerungen"),
            new System.Data.OleDb.OleDbParameter("HatPsychischeKrankheitsbedingteSchlafstoerungen", System.Data.OleDb.OleDbType.Integer, 0, "HatPsychischeKrankheitsbedingteSchlafstoerungen"),
            new System.Data.OleDb.OleDbParameter("HatGestoertenTagNachtrhytmus", System.Data.OleDb.OleDbType.Integer, 0, "HatGestoertenTagNachtrhytmus"),
            new System.Data.OleDb.OleDbParameter("Beruf", System.Data.OleDb.OleDbType.LongVarChar, 0, "Beruf"),
            new System.Data.OleDb.OleDbParameter("GerneBeschaeftigtMit", System.Data.OleDb.OleDbType.LongVarChar, 0, "GerneBeschaeftigtMit"),
            new System.Data.OleDb.OleDbParameter("Tagsablauf", System.Data.OleDb.OleDbType.LongVarChar, 0, "Tagsablauf"),
            new System.Data.OleDb.OleDbParameter("TagesablaufsgestaltungHilfeJN", System.Data.OleDb.OleDbType.Boolean, 0, "TagesablaufsgestaltungHilfeJN"),
            new System.Data.OleDb.OleDbParameter("TagesablaufsgestaltungHilfe", System.Data.OleDb.OleDbType.LongVarChar, 0, "TagesablaufsgestaltungHilfe"),
            new System.Data.OleDb.OleDbParameter("SichBeschaeftigenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichBeschaeftigenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichBeschaeftigenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichBeschaeftigenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("TagesablaufNachFrueherenGewohnheiten", System.Data.OleDb.OleDbType.Integer, 0, "TagesablaufNachFrueherenGewohnheiten"),
            new System.Data.OleDb.OleDbParameter("ZeitpunktAufstehenBettGehenAbstimmen", System.Data.OleDb.OleDbType.Integer, 0, "ZeitpunktAufstehenBettGehenAbstimmen"),
            new System.Data.OleDb.OleDbParameter("IntegrationInTaeglicheAblaufe", System.Data.OleDb.OleDbType.Integer, 0, "IntegrationInTaeglicheAblaufe"),
            new System.Data.OleDb.OleDbParameter("MaennlicheWeiblichePflegeperson", System.Data.OleDb.OleDbType.LongVarChar, 0, "MaennlicheWeiblichePflegeperson"),
            new System.Data.OleDb.OleDbParameter("MakeUpSchmuck", System.Data.OleDb.OleDbType.LongVarChar, 0, "MakeUpSchmuck"),
            new System.Data.OleDb.OleDbParameter("HaarBarttracht", System.Data.OleDb.OleDbType.LongVarChar, 0, "HaarBarttracht"),
            new System.Data.OleDb.OleDbParameter("SichFuehlenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichFuehlenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SichFuehlenpflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SichFuehlenpflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("SchagefuehlIntimepflegeBeruecksichtigen", System.Data.OleDb.OleDbType.Integer, 0, "SchagefuehlIntimepflegeBeruecksichtigen"),
            new System.Data.OleDb.OleDbParameter("WuenschtMaennlicheWeiblicheBestimmtePflegeperson", System.Data.OleDb.OleDbType.Integer, 0, "WuenschtMaennlicheWeiblicheBestimmtePflegeperson"),
            new System.Data.OleDb.OleDbParameter("KannFrisurNichtSelbstHerrichten", System.Data.OleDb.OleDbType.Integer, 0, "KannFrisurNichtSelbstHerrichten"),
            new System.Data.OleDb.OleDbParameter("KannSchmuckNichtSelbstAnlegen", System.Data.OleDb.OleDbType.Integer, 0, "KannSchmuckNichtSelbstAnlegen"),
            new System.Data.OleDb.OleDbParameter("HilfsmittelZurMobilitaetJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfsmittelZurMobilitaetJN"),
            new System.Data.OleDb.OleDbParameter("BettgitterJN", System.Data.OleDb.OleDbType.Boolean, 0, "BettgitterJN"),
            new System.Data.OleDb.OleDbParameter("ZimmerVerschlossen", System.Data.OleDb.OleDbType.LongVarChar, 0, "ZimmerVerschlossen"),
            new System.Data.OleDb.OleDbParameter("HilfeHerbeirufenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HilfeHerbeirufenJN"),
            new System.Data.OleDb.OleDbParameter("OhneHilfeZurechtJN", System.Data.OleDb.OleDbType.Boolean, 0, "OhneHilfeZurechtJN"),
            new System.Data.OleDb.OleDbParameter("UmgebungTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmgebungTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("UmgebungPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "UmgebungPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KannGefahrenNichtEinschaetzen", System.Data.OleDb.OleDbType.Integer, 0, "KannGefahrenNichtEinschaetzen"),
            new System.Data.OleDb.OleDbParameter("InDerEinrichtungVerirrn", System.Data.OleDb.OleDbType.Integer, 0, "InDerEinrichtungVerirrn"),
            new System.Data.OleDb.OleDbParameter("Sicherheit", System.Data.OleDb.OleDbType.Integer, 0, "Sicherheit"),
            new System.Data.OleDb.OleDbParameter("MedikamenteneinnahmeUeberwachen", System.Data.OleDb.OleDbType.Integer, 0, "MedikamenteneinnahmeUeberwachen"),
            new System.Data.OleDb.OleDbParameter("Kontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "Kontakte"),
            new System.Data.OleDb.OleDbParameter("Keinekontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "Keinekontakte"),
            new System.Data.OleDb.OleDbParameter("ZeitKeineBesuche", System.Data.OleDb.OleDbType.VarChar, 0, "ZeitKeineBesuche"),
            new System.Data.OleDb.OleDbParameter("AndereKontakte", System.Data.OleDb.OleDbType.LongVarChar, 0, "AndereKontakte"),
            new System.Data.OleDb.OleDbParameter("KontakteSelbsstaendigHerstellenJN", System.Data.OleDb.OleDbType.Boolean, 0, "KontakteSelbsstaendigHerstellenJN"),
            new System.Data.OleDb.OleDbParameter("SozialeTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialeTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("SozialePflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "SozialePflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("BewohnerBenoetigtAktivierung", System.Data.OleDb.OleDbType.Integer, 0, "BewohnerBenoetigtAktivierung"),
            new System.Data.OleDb.OleDbParameter("HilfeBeiDerKontakpflege", System.Data.OleDb.OleDbType.Integer, 0, "HilfeBeiDerKontakpflege"),
            new System.Data.OleDb.OleDbParameter("InBetreuungImHausIntegrieren", System.Data.OleDb.OleDbType.Integer, 0, "InBetreuungImHausIntegrieren"),
            new System.Data.OleDb.OleDbParameter("SterbephaseBetreuung", System.Data.OleDb.OleDbType.LongVarChar, 0, "SterbephaseBetreuung"),
            new System.Data.OleDb.OleDbParameter("Versorger", System.Data.OleDb.OleDbType.LongVarChar, 0, "Versorger"),
            new System.Data.OleDb.OleDbParameter("ErfahrungenTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErfahrungenTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("ErfahrungenPflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErfahrungenPflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("KannKrankheitBehinderungNichtAkzeptieren", System.Data.OleDb.OleDbType.Integer, 0, "KannKrankheitBehinderungNichtAkzeptieren"),
            new System.Data.OleDb.OleDbParameter("LeidetAnVerlust", System.Data.OleDb.OleDbType.Integer, 0, "LeidetAnVerlust"),
            new System.Data.OleDb.OleDbParameter("LeidetAnVerlustVon", System.Data.OleDb.OleDbType.LongVarChar, 0, "LeidetAnVerlustVon"),
            new System.Data.OleDb.OleDbParameter("IstMisstraurisch", System.Data.OleDb.OleDbType.Integer, 0, "IstMisstraurisch"),
            new System.Data.OleDb.OleDbParameter("IstMisstraurischGegen", System.Data.OleDb.OleDbType.LongVarChar, 0, "IstMisstraurischGegen"),
            new System.Data.OleDb.OleDbParameter("HatSchmerzen", System.Data.OleDb.OleDbType.Integer, 0, "HatSchmerzen"),
            new System.Data.OleDb.OleDbParameter("Schmerzen", System.Data.OleDb.OleDbType.LongVarChar, 0, "Schmerzen"),
            new System.Data.OleDb.OleDbParameter("HatAngst", System.Data.OleDb.OleDbType.Integer, 0, "HatAngst"),
            new System.Data.OleDb.OleDbParameter("AngstVon", System.Data.OleDb.OleDbType.LongVarChar, 0, "AngstVon"),
            new System.Data.OleDb.OleDbParameter("Biographie", System.Data.OleDb.OleDbType.LongVarChar, 0, "Biographie"),
            new System.Data.OleDb.OleDbParameter("BiographieTagesstrukturJN", System.Data.OleDb.OleDbType.Boolean, 0, "BiographieTagesstrukturJN"),
            new System.Data.OleDb.OleDbParameter("BiographiePflegeplanungJN", System.Data.OleDb.OleDbType.Boolean, 0, "BiographiePflegeplanungJN"),
            new System.Data.OleDb.OleDbParameter("UnbewaeltigtenLebenserfahrungen", System.Data.OleDb.OleDbType.Integer, 0, "UnbewaeltigtenLebenserfahrungen"),
            new System.Data.OleDb.OleDbParameter("Vermisst", System.Data.OleDb.OleDbType.Integer, 0, "Vermisst"),
            new System.Data.OleDb.OleDbParameter("VermisstBeschreibung", System.Data.OleDb.OleDbType.LongVarChar, 0, "VermisstBeschreibung"),
            new System.Data.OleDb.OleDbParameter("HatSorge", System.Data.OleDb.OleDbType.Integer, 0, "HatSorge"),
            new System.Data.OleDb.OleDbParameter("SorgeUm", System.Data.OleDb.OleDbType.LongVarChar, 0, "SorgeUm"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            ((System.ComponentModel.ISupportInitialize)(this.dsPDXByPflegeModell1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPflegemodelle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsAnamneseBiografie1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private PMDS.Data.Patient.dsPDXByPflegeModell dsPDXByPflegeModell1;
        private System.Data.OleDb.OleDbDataAdapter daPDXByPflegemodell;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
        private dsPflegemodelle dsPflegemodelle1;
        private System.Data.OleDb.OleDbDataAdapter daPflegeModell;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand3;
        private PMDS.GUI.Datenerhebung.AnamneseBiografie.dsAnamneseBiografie2 dsAnamneseBiografie1;
        private System.Data.OleDb.OleDbDataAdapter daAnamneseBiografie;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
    }
}
