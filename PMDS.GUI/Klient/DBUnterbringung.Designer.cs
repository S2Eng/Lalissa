using PMDS.GUI.Klient;
namespace PMDS.Klient
{
    partial class DBUnterbringung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBUnterbringung));
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.daUnterbringung = new System.Data.OleDb.OleDbDataAdapter();
            this.dsUnterbringung1 = new PMDS.GUI.Klient.dsUnterbringung();
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringung1)).BeginInit();
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=SQLNCLI11;Data Source=stysrv02v\\sql2012;Integrated Security=SSPI;Initial" +
    " Catalog=PMDSDev";
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = resources.GetString("oleDbSelectCommand1.CommandText");
            this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
            this.oleDbSelectCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 16, "IDAufenthalt")});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = resources.GetString("oleDbInsertCommand1.CommandText");
            this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("Beginn", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Beginn"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, "AngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("AngeordnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AngeordnetAm"),
            new System.Data.OleDb.OleDbParameter("AufgehobenAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AufgehobenAm"),
            new System.Data.OleDb.OleDbParameter("GefahrFuerLebenGesundheitJN", System.Data.OleDb.OleDbType.Boolean, 0, "GefahrFuerLebenGesundheitJN"),
            new System.Data.OleDb.OleDbParameter("EingriffUnerlaesslichJN", System.Data.OleDb.OleDbType.Boolean, 0, "EingriffUnerlaesslichJN"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVon", System.Data.OleDb.OleDbType.VarChar, 0, "AufgehobenVon"),
            new System.Data.OleDb.OleDbParameter("TatsaechlicheEnde", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "TatsaechlicheEnde"),
            new System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"),
            new System.Data.OleDb.OleDbParameter("VoraussichtlicheDauer", System.Data.OleDb.OleDbType.Integer, 0, "VoraussichtlicheDauer"),
            new System.Data.OleDb.OleDbParameter("Zeitraum", System.Data.OleDb.OleDbType.VarChar, 0, "Zeitraum"),
            new System.Data.OleDb.OleDbParameter("PsychischekrankheitJN", System.Data.OleDb.OleDbType.Boolean, 0, "PsychischekrankheitJN"),
            new System.Data.OleDb.OleDbParameter("GeistigeBehinderungJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeistigeBehinderungJN"),
            new System.Data.OleDb.OleDbParameter("MedDiagnICD", System.Data.OleDb.OleDbType.VarChar, 0, "MedDiagnICD"),
            new System.Data.OleDb.OleDbParameter("MedizinischeDiagnose", System.Data.OleDb.OleDbType.VarWChar, 0, "MedizinischeDiagnose"),
            new System.Data.OleDb.OleDbParameter("ErheblicheSelbstgefaehrdungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErheblicheSelbstgefaehrdungJN"),
            new System.Data.OleDb.OleDbParameter("ErheblicheFremdgefaehrdungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErheblicheFremdgefaehrdungJN"),
            new System.Data.OleDb.OleDbParameter("EingriffUnerlaesslichBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "EingriffUnerlaesslichBeschreibung"),
            new System.Data.OleDb.OleDbParameter("Einrichtungsleiter", System.Data.OleDb.OleDbType.VarChar, 0, "Einrichtungsleiter"),
            new System.Data.OleDb.OleDbParameter("ElektronischesUeberwachungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ElektronischesUeberwachungJN"),
            new System.Data.OleDb.OleDbParameter("ZurueckhaltensandrohungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZurueckhaltensandrohungJN"),
            new System.Data.OleDb.OleDbParameter("VerschlosseneTuerJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerschlosseneTuerJN"),
            new System.Data.OleDb.OleDbParameter("DrehknopfJN", System.Data.OleDb.OleDbType.Boolean, 0, "DrehknopfJN"),
            new System.Data.OleDb.OleDbParameter("CodierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "CodierungJN"),
            new System.Data.OleDb.OleDbParameter("LabyrinthJN", System.Data.OleDb.OleDbType.Boolean, 0, "LabyrinthJN"),
            new System.Data.OleDb.OleDbParameter("BaulicheMassnahmen", System.Data.OleDb.OleDbType.VarWChar, 0, "BaulicheMassnahmen"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhTischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhTischJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhTherapietischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhTherapietischJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhl", System.Data.OleDb.OleDbType.VarChar, 0, "HindernRollstuhl"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelTischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelTischJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelTherapietischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelTherapietischJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelegenheit", System.Data.OleDb.OleDbType.VarWChar, 0, "HindernSitzgelegenheit"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettSeitenteilenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettSeitenteilenJN"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernBettVerlassen", System.Data.OleDb.OleDbType.VarWChar, 0, "HindernBettVerlassen"),
            new System.Data.OleDb.OleDbParameter("MedikFreihBeschraenkungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MedikFreihBeschraenkungJN"),
            new System.Data.OleDb.OleDbParameter("MedikBezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "MedikBezeichnung"),
            new System.Data.OleDb.OleDbParameter("GesendetAnBewohnervertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnBewohnervertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnGesetzVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnGesetzVertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnSelbstGewVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnSelbstGewVertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnVertrauenspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnVertrauenspersonJN"),
            new System.Data.OleDb.OleDbParameter("KlientZustimmungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KlientZustimmungJN"),
            new System.Data.OleDb.OleDbParameter("AufgehobeneMassnahmeInfo", System.Data.OleDb.OleDbType.Integer, 0, "AufgehobeneMassnahmeInfo"),
            new System.Data.OleDb.OleDbParameter("Berufsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Berufsgruppe"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ENDEBerufsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "ENDEBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("ENDEAngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, "ENDEAngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnBewohnervertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnBewohnervertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnGesetzVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnGesetzVertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnSelbstGewVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnSelbstGewVertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnVertrauenspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnVertrauenspersonJN"),
            new System.Data.OleDb.OleDbParameter("VoraussichtlichesEnde", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "VoraussichtlichesEnde"),
            new System.Data.OleDb.OleDbParameter("Info", System.Data.OleDb.OleDbType.Integer, 0, "Info"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArt", System.Data.OleDb.OleDbType.Integer, 0, "AerztlDokumentArt"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArzt", System.Data.OleDb.OleDbType.VarChar, 0, "AerztlDokumentArzt"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AerztlDokumentDatum"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlBremsenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlBremsenJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlSitzhoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlSitzhoseJN"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettHandmanschettenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettHandmanschettenJN"),
            new System.Data.OleDb.OleDbParameter("TatsaechlicheEndeGrund", System.Data.OleDb.OleDbType.Integer, 0, "TatsaechlicheEndeGrund"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArztTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AerztlDokumentArztTitel"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArztVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AerztlDokumentArztVorname"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVonTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AngeordnetVonTitel"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVonVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AngeordnetVonVorname"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVonTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AufgehobenVonTitel"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVonVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AufgehobenVonVorname"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelSitzhoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelSitzhoseJN"),
            new System.Data.OleDb.OleDbParameter("EDI_Datum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EDI_Datum"),
            new System.Data.OleDb.OleDbParameter("EDI_Benutzer", System.Data.OleDb.OleDbType.Guid, 0, "EDI_Benutzer"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterTitel"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterVorname"),
            new System.Data.OleDb.OleDbParameter("EDI_Protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "EDI_Protokoll"),
            new System.Data.OleDb.OleDbParameter("AnmerkungGutachten_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "AnmerkungGutachten_2016"),
            new System.Data.OleDb.OleDbParameter("AnmerkungVerhalten_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "AnmerkungVerhalten_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettHandArmgurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernVerlassenBettHandArmgurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettFussBeingurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernVerlassenBettFussBeingurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettBauchgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettBauchgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettElektronischJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettElektronischJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelHandArmgurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernSitzgelHandArmgurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelFussBeingurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernSitzgelFussBeingurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelBauchgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelBauchgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelBrustgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelBrustgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichFesthaltenJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichFesthaltenJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichBarriereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichBarriereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichVersperrterBereichJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichVersperrterBereichJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichVersperrtesZimmerJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichVersperrtesZimmerJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichHinderAmFortbewegenJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichHinderAmFortbewegenJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("EinzelfallmedikationJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "EinzelfallmedikationJN_2016"),
            new System.Data.OleDb.OleDbParameter("Einzelfallmedikation_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "Einzelfallmedikation_2016"),
            new System.Data.OleDb.OleDbParameter("DauermedikationJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "DauermedikationJN_2016"),
            new System.Data.OleDb.OleDbParameter("Dauermedikation_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "Dauermedikation_2016")});
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = resources.GetString("oleDbUpdateCommand1.CommandText");
            this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("ID", System.Data.OleDb.OleDbType.Guid, 0, "ID"),
            new System.Data.OleDb.OleDbParameter("IDAufenthalt", System.Data.OleDb.OleDbType.Guid, 0, "IDAufenthalt"),
            new System.Data.OleDb.OleDbParameter("Grund", System.Data.OleDb.OleDbType.VarChar, 0, "Grund"),
            new System.Data.OleDb.OleDbParameter("Beginn", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "Beginn"),
            new System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, "AngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("AngeordnetAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AngeordnetAm"),
            new System.Data.OleDb.OleDbParameter("AufgehobenAm", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AufgehobenAm"),
            new System.Data.OleDb.OleDbParameter("GefahrFuerLebenGesundheitJN", System.Data.OleDb.OleDbType.Boolean, 0, "GefahrFuerLebenGesundheitJN"),
            new System.Data.OleDb.OleDbParameter("EingriffUnerlaesslichJN", System.Data.OleDb.OleDbType.Boolean, 0, "EingriffUnerlaesslichJN"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVon", System.Data.OleDb.OleDbType.VarChar, 0, "AufgehobenVon"),
            new System.Data.OleDb.OleDbParameter("TatsaechlicheEnde", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "TatsaechlicheEnde"),
            new System.Data.OleDb.OleDbParameter("Aktion", System.Data.OleDb.OleDbType.VarChar, 0, "Aktion"),
            new System.Data.OleDb.OleDbParameter("VoraussichtlicheDauer", System.Data.OleDb.OleDbType.Integer, 0, "VoraussichtlicheDauer"),
            new System.Data.OleDb.OleDbParameter("Zeitraum", System.Data.OleDb.OleDbType.VarChar, 0, "Zeitraum"),
            new System.Data.OleDb.OleDbParameter("PsychischekrankheitJN", System.Data.OleDb.OleDbType.Boolean, 0, "PsychischekrankheitJN"),
            new System.Data.OleDb.OleDbParameter("GeistigeBehinderungJN", System.Data.OleDb.OleDbType.Boolean, 0, "GeistigeBehinderungJN"),
            new System.Data.OleDb.OleDbParameter("MedDiagnICD", System.Data.OleDb.OleDbType.VarChar, 0, "MedDiagnICD"),
            new System.Data.OleDb.OleDbParameter("MedizinischeDiagnose", System.Data.OleDb.OleDbType.VarWChar, 0, "MedizinischeDiagnose"),
            new System.Data.OleDb.OleDbParameter("ErheblicheSelbstgefaehrdungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErheblicheSelbstgefaehrdungJN"),
            new System.Data.OleDb.OleDbParameter("ErheblicheFremdgefaehrdungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ErheblicheFremdgefaehrdungJN"),
            new System.Data.OleDb.OleDbParameter("EingriffUnerlaesslichBeschreibung", System.Data.OleDb.OleDbType.VarChar, 0, "EingriffUnerlaesslichBeschreibung"),
            new System.Data.OleDb.OleDbParameter("Einrichtungsleiter", System.Data.OleDb.OleDbType.VarChar, 0, "Einrichtungsleiter"),
            new System.Data.OleDb.OleDbParameter("ElektronischesUeberwachungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ElektronischesUeberwachungJN"),
            new System.Data.OleDb.OleDbParameter("ZurueckhaltensandrohungJN", System.Data.OleDb.OleDbType.Boolean, 0, "ZurueckhaltensandrohungJN"),
            new System.Data.OleDb.OleDbParameter("VerschlosseneTuerJN", System.Data.OleDb.OleDbType.Boolean, 0, "VerschlosseneTuerJN"),
            new System.Data.OleDb.OleDbParameter("DrehknopfJN", System.Data.OleDb.OleDbType.Boolean, 0, "DrehknopfJN"),
            new System.Data.OleDb.OleDbParameter("CodierungJN", System.Data.OleDb.OleDbType.Boolean, 0, "CodierungJN"),
            new System.Data.OleDb.OleDbParameter("LabyrinthJN", System.Data.OleDb.OleDbType.Boolean, 0, "LabyrinthJN"),
            new System.Data.OleDb.OleDbParameter("BaulicheMassnahmen", System.Data.OleDb.OleDbType.VarWChar, 0, "BaulicheMassnahmen"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhTischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhTischJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhTherapietischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhTherapietischJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhl", System.Data.OleDb.OleDbType.VarChar, 0, "HindernRollstuhl"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelTischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelTischJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelTherapietischJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelTherapietischJN"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelegenheit", System.Data.OleDb.OleDbType.VarWChar, 0, "HindernSitzgelegenheit"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettSeitenteilenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettSeitenteilenJN"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettGurtenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettGurtenJN"),
            new System.Data.OleDb.OleDbParameter("HindernBettVerlassen", System.Data.OleDb.OleDbType.VarWChar, 0, "HindernBettVerlassen"),
            new System.Data.OleDb.OleDbParameter("MedikFreihBeschraenkungJN", System.Data.OleDb.OleDbType.Boolean, 0, "MedikFreihBeschraenkungJN"),
            new System.Data.OleDb.OleDbParameter("MedikBezeichnung", System.Data.OleDb.OleDbType.VarChar, 0, "MedikBezeichnung"),
            new System.Data.OleDb.OleDbParameter("GesendetAnBewohnervertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnBewohnervertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnGesetzVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnGesetzVertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnSelbstGewVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnSelbstGewVertreterJN"),
            new System.Data.OleDb.OleDbParameter("GesendetAnVertrauenspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "GesendetAnVertrauenspersonJN"),
            new System.Data.OleDb.OleDbParameter("KlientZustimmungJN", System.Data.OleDb.OleDbType.Boolean, 0, "KlientZustimmungJN"),
            new System.Data.OleDb.OleDbParameter("AufgehobeneMassnahmeInfo", System.Data.OleDb.OleDbType.Integer, 0, "AufgehobeneMassnahmeInfo"),
            new System.Data.OleDb.OleDbParameter("Berufsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "Berufsgruppe"),
            new System.Data.OleDb.OleDbParameter("Anmerkung", System.Data.OleDb.OleDbType.VarChar, 0, "Anmerkung"),
            new System.Data.OleDb.OleDbParameter("ENDEBerufsgruppe", System.Data.OleDb.OleDbType.Integer, 0, "ENDEBerufsgruppe"),
            new System.Data.OleDb.OleDbParameter("ENDEAngeordnetVon", System.Data.OleDb.OleDbType.VarChar, 0, "ENDEAngeordnetVon"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnBewohnervertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnBewohnervertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnGesetzVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnGesetzVertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnSelbstGewVertreterJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnSelbstGewVertreterJN"),
            new System.Data.OleDb.OleDbParameter("ENDEGesendetAnVertrauenspersonJN", System.Data.OleDb.OleDbType.Boolean, 0, "ENDEGesendetAnVertrauenspersonJN"),
            new System.Data.OleDb.OleDbParameter("VoraussichtlichesEnde", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "VoraussichtlichesEnde"),
            new System.Data.OleDb.OleDbParameter("Info", System.Data.OleDb.OleDbType.Integer, 0, "Info"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArt", System.Data.OleDb.OleDbType.Integer, 0, "AerztlDokumentArt"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArzt", System.Data.OleDb.OleDbType.VarChar, 0, "AerztlDokumentArzt"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentDatum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "AerztlDokumentDatum"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlBremsenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlBremsenJN"),
            new System.Data.OleDb.OleDbParameter("HindernRollstuhlSitzhoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernRollstuhlSitzhoseJN"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettHandmanschettenJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettHandmanschettenJN"),
            new System.Data.OleDb.OleDbParameter("TatsaechlicheEndeGrund", System.Data.OleDb.OleDbType.Integer, 0, "TatsaechlicheEndeGrund"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArztTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AerztlDokumentArztTitel"),
            new System.Data.OleDb.OleDbParameter("AerztlDokumentArztVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AerztlDokumentArztVorname"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVonTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AngeordnetVonTitel"),
            new System.Data.OleDb.OleDbParameter("AngeordnetVonVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AngeordnetVonVorname"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVonTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "AufgehobenVonTitel"),
            new System.Data.OleDb.OleDbParameter("AufgehobenVonVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "AufgehobenVonVorname"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelSitzhoseJN", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelSitzhoseJN"),
            new System.Data.OleDb.OleDbParameter("EDI_Datum", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EDI_Datum"),
            new System.Data.OleDb.OleDbParameter("EDI_Benutzer", System.Data.OleDb.OleDbType.Guid, 0, "EDI_Benutzer"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterTitel", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterTitel"),
            new System.Data.OleDb.OleDbParameter("EinrichtungsleiterVorname", System.Data.OleDb.OleDbType.VarWChar, 0, "EinrichtungsleiterVorname"),
            new System.Data.OleDb.OleDbParameter("EDI_Protokoll", System.Data.OleDb.OleDbType.LongVarWChar, 0, "EDI_Protokoll"),
            new System.Data.OleDb.OleDbParameter("AnmerkungGutachten_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "AnmerkungGutachten_2016"),
            new System.Data.OleDb.OleDbParameter("AnmerkungVerhalten_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "AnmerkungVerhalten_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettHandArmgurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernVerlassenBettHandArmgurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettFussBeingurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernVerlassenBettFussBeingurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettBauchgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettBauchgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernVerlassenBettElektronischJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernVerlassenBettElektronischJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelHandArmgurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernSitzgelHandArmgurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelFussBeingurte_2016", System.Data.OleDb.OleDbType.Integer, 0, "HindernSitzgelFussBeingurte_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelBauchgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelBauchgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernSitzgelBrustgurtJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernSitzgelBrustgurtJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichFesthaltenJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichFesthaltenJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichBarriereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichBarriereJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichVersperrterBereichJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichVersperrterBereichJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichVersperrtesZimmerJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichVersperrtesZimmerJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichHinderAmFortbewegenJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichHinderAmFortbewegenJN_2016"),
            new System.Data.OleDb.OleDbParameter("HindernBereichAndereJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "HindernBereichAndereJN_2016"),
            new System.Data.OleDb.OleDbParameter("EinzelfallmedikationJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "EinzelfallmedikationJN_2016"),
            new System.Data.OleDb.OleDbParameter("Einzelfallmedikation_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "Einzelfallmedikation_2016"),
            new System.Data.OleDb.OleDbParameter("DauermedikationJN_2016", System.Data.OleDb.OleDbType.Boolean, 0, "DauermedikationJN_2016"),
            new System.Data.OleDb.OleDbParameter("Dauermedikation_2016", System.Data.OleDb.OleDbType.VarWChar, 0, "Dauermedikation_2016"),
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM [Unterbringung] WHERE (([ID] = ?))";
            this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("Original_ID", System.Data.OleDb.OleDbType.Guid, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "ID", System.Data.DataRowVersion.Original, null)});
            // 
            // daUnterbringung
            // 
            this.daUnterbringung.DeleteCommand = this.oleDbDeleteCommand1;
            this.daUnterbringung.InsertCommand = this.oleDbInsertCommand1;
            this.daUnterbringung.SelectCommand = this.oleDbSelectCommand1;
            this.daUnterbringung.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Unterbringung", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("IDAufenthalt", "IDAufenthalt"),
                        new System.Data.Common.DataColumnMapping("Grund", "Grund"),
                        new System.Data.Common.DataColumnMapping("Beginn", "Beginn"),
                        new System.Data.Common.DataColumnMapping("Dauer", "Dauer"),
                        new System.Data.Common.DataColumnMapping("AngeordnetVon", "AngeordnetVon"),
                        new System.Data.Common.DataColumnMapping("AngeordnetAm", "AngeordnetAm"),
                        new System.Data.Common.DataColumnMapping("AufgehobenAm", "AufgehobenAm"),
                        new System.Data.Common.DataColumnMapping("GefahrFuerLebenGesundheitJN", "GefahrFuerLebenGesundheitJN"),
                        new System.Data.Common.DataColumnMapping("EingriffUnerlaesslichJN", "EingriffUnerlaesslichJN"),
                        new System.Data.Common.DataColumnMapping("AufgehobenVon", "AufgehobenVon"),
                        new System.Data.Common.DataColumnMapping("TatsaechlicheEnde", "TatsaechlicheEnde"),
                        new System.Data.Common.DataColumnMapping("Aktion", "Aktion"),
                        new System.Data.Common.DataColumnMapping("VoraussichtlicheDauer", "VoraussichtlicheDauer"),
                        new System.Data.Common.DataColumnMapping("Zeitraum", "Zeitraum"),
                        new System.Data.Common.DataColumnMapping("PsychischekrankheitJN", "PsychischekrankheitJN"),
                        new System.Data.Common.DataColumnMapping("GeistigeBehinderungJN", "GeistigeBehinderungJN"),
                        new System.Data.Common.DataColumnMapping("MedDiagnICD", "MedDiagnICD"),
                        new System.Data.Common.DataColumnMapping("MedizinischeDiagnose", "MedizinischeDiagnose"),
                        new System.Data.Common.DataColumnMapping("ErheblicheSelbstgefaehrdungJN", "ErheblicheSelbstgefaehrdungJN"),
                        new System.Data.Common.DataColumnMapping("ErheblicheFremdgefaehrdungJN", "ErheblicheFremdgefaehrdungJN"),
                        new System.Data.Common.DataColumnMapping("EingriffUnerlaesslichBeschreibung", "EingriffUnerlaesslichBeschreibung"),
                        new System.Data.Common.DataColumnMapping("Einrichtungsleiter", "Einrichtungsleiter"),
                        new System.Data.Common.DataColumnMapping("ElektronischesUeberwachungJN", "ElektronischesUeberwachungJN"),
                        new System.Data.Common.DataColumnMapping("ZurueckhaltensandrohungJN", "ZurueckhaltensandrohungJN"),
                        new System.Data.Common.DataColumnMapping("VerschlosseneTuerJN", "VerschlosseneTuerJN"),
                        new System.Data.Common.DataColumnMapping("DrehknopfJN", "DrehknopfJN"),
                        new System.Data.Common.DataColumnMapping("CodierungJN", "CodierungJN"),
                        new System.Data.Common.DataColumnMapping("LabyrinthJN", "LabyrinthJN"),
                        new System.Data.Common.DataColumnMapping("BaulicheMassnahmen", "BaulicheMassnahmen"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhlGurtenJN", "HindernRollstuhlGurtenJN"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhTischJN", "HindernRollstuhTischJN"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhTherapietischJN", "HindernRollstuhTherapietischJN"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhl", "HindernRollstuhl"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelGurtenJN", "HindernSitzgelGurtenJN"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelTischJN", "HindernSitzgelTischJN"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelTherapietischJN", "HindernSitzgelTherapietischJN"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelegenheit", "HindernSitzgelegenheit"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettSeitenteilenJN", "HindernVerlassenBettSeitenteilenJN"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettGurtenJN", "HindernVerlassenBettGurtenJN"),
                        new System.Data.Common.DataColumnMapping("HindernBettVerlassen", "HindernBettVerlassen"),
                        new System.Data.Common.DataColumnMapping("MedikFreihBeschraenkungJN", "MedikFreihBeschraenkungJN"),
                        new System.Data.Common.DataColumnMapping("MedikBezeichnung", "MedikBezeichnung"),
                        new System.Data.Common.DataColumnMapping("GesendetAnBewohnervertreterJN", "GesendetAnBewohnervertreterJN"),
                        new System.Data.Common.DataColumnMapping("GesendetAnGesetzVertreterJN", "GesendetAnGesetzVertreterJN"),
                        new System.Data.Common.DataColumnMapping("GesendetAnSelbstGewVertreterJN", "GesendetAnSelbstGewVertreterJN"),
                        new System.Data.Common.DataColumnMapping("GesendetAnVertrauenspersonJN", "GesendetAnVertrauenspersonJN"),
                        new System.Data.Common.DataColumnMapping("KlientZustimmungJN", "KlientZustimmungJN"),
                        new System.Data.Common.DataColumnMapping("AufgehobeneMassnahmeInfo", "AufgehobeneMassnahmeInfo"),
                        new System.Data.Common.DataColumnMapping("Berufsgruppe", "Berufsgruppe"),
                        new System.Data.Common.DataColumnMapping("Anmerkung", "Anmerkung"),
                        new System.Data.Common.DataColumnMapping("ENDEBerufsgruppe", "ENDEBerufsgruppe"),
                        new System.Data.Common.DataColumnMapping("ENDEAngeordnetVon", "ENDEAngeordnetVon"),
                        new System.Data.Common.DataColumnMapping("ENDEGesendetAnBewohnervertreterJN", "ENDEGesendetAnBewohnervertreterJN"),
                        new System.Data.Common.DataColumnMapping("ENDEGesendetAnGesetzVertreterJN", "ENDEGesendetAnGesetzVertreterJN"),
                        new System.Data.Common.DataColumnMapping("ENDEGesendetAnSelbstGewVertreterJN", "ENDEGesendetAnSelbstGewVertreterJN"),
                        new System.Data.Common.DataColumnMapping("ENDEGesendetAnVertrauenspersonJN", "ENDEGesendetAnVertrauenspersonJN"),
                        new System.Data.Common.DataColumnMapping("VoraussichtlichesEnde", "VoraussichtlichesEnde"),
                        new System.Data.Common.DataColumnMapping("Info", "Info"),
                        new System.Data.Common.DataColumnMapping("AerztlDokumentArt", "AerztlDokumentArt"),
                        new System.Data.Common.DataColumnMapping("AerztlDokumentArzt", "AerztlDokumentArzt"),
                        new System.Data.Common.DataColumnMapping("AerztlDokumentDatum", "AerztlDokumentDatum"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhlBremsenJN", "HindernRollstuhlBremsenJN"),
                        new System.Data.Common.DataColumnMapping("HindernRollstuhlSitzhoseJN", "HindernRollstuhlSitzhoseJN"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettHandmanschettenJN", "HindernVerlassenBettHandmanschettenJN"),
                        new System.Data.Common.DataColumnMapping("TatsaechlicheEndeGrund", "TatsaechlicheEndeGrund"),
                        new System.Data.Common.DataColumnMapping("AerztlDokumentArztTitel", "AerztlDokumentArztTitel"),
                        new System.Data.Common.DataColumnMapping("AerztlDokumentArztVorname", "AerztlDokumentArztVorname"),
                        new System.Data.Common.DataColumnMapping("AngeordnetVonTitel", "AngeordnetVonTitel"),
                        new System.Data.Common.DataColumnMapping("AngeordnetVonVorname", "AngeordnetVonVorname"),
                        new System.Data.Common.DataColumnMapping("AufgehobenVonTitel", "AufgehobenVonTitel"),
                        new System.Data.Common.DataColumnMapping("AufgehobenVonVorname", "AufgehobenVonVorname"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelSitzhoseJN", "HindernSitzgelSitzhoseJN"),
                        new System.Data.Common.DataColumnMapping("EDI_Datum", "EDI_Datum"),
                        new System.Data.Common.DataColumnMapping("EDI_Benutzer", "EDI_Benutzer"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterTitel", "EinrichtungsleiterTitel"),
                        new System.Data.Common.DataColumnMapping("EinrichtungsleiterVorname", "EinrichtungsleiterVorname"),
                        new System.Data.Common.DataColumnMapping("EDI_Protokoll", "EDI_Protokoll"),
                        new System.Data.Common.DataColumnMapping("AnmerkungGutachten_2016", "AnmerkungGutachten_2016"),
                        new System.Data.Common.DataColumnMapping("AnmerkungVerhalten_2016", "AnmerkungVerhalten_2016"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettHandArmgurte_2016", "HindernVerlassenBettHandArmgurte_2016"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettFussBeingurte_2016", "HindernVerlassenBettFussBeingurte_2016"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettAndereJN_2016", "HindernVerlassenBettAndereJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettBauchgurtJN_2016", "HindernVerlassenBettBauchgurtJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernVerlassenBettElektronischJN_2016", "HindernVerlassenBettElektronischJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelHandArmgurte_2016", "HindernSitzgelHandArmgurte_2016"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelFussBeingurte_2016", "HindernSitzgelFussBeingurte_2016"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelAndereJN_2016", "HindernSitzgelAndereJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelBauchgurtJN_2016", "HindernSitzgelBauchgurtJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernSitzgelBrustgurtJN_2016", "HindernSitzgelBrustgurtJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichFesthaltenJN_2016", "HindernBereichFesthaltenJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichBarriereJN_2016", "HindernBereichBarriereJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichVersperrterBereichJN_2016", "HindernBereichVersperrterBereichJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichVersperrtesZimmerJN_2016", "HindernBereichVersperrtesZimmerJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichHinderAmFortbewegenJN_2016", "HindernBereichHinderAmFortbewegenJN_2016"),
                        new System.Data.Common.DataColumnMapping("HindernBereichAndereJN_2016", "HindernBereichAndereJN_2016"),
                        new System.Data.Common.DataColumnMapping("EinzelfallmedikationJN_2016", "EinzelfallmedikationJN_2016"),
                        new System.Data.Common.DataColumnMapping("Einzelfallmedikation_2016", "Einzelfallmedikation_2016"),
                        new System.Data.Common.DataColumnMapping("DauermedikationJN_2016", "DauermedikationJN_2016"),
                        new System.Data.Common.DataColumnMapping("Dauermedikation_2016", "Dauermedikation_2016")})});
            this.daUnterbringung.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // dsUnterbringung1
            // 
            this.dsUnterbringung1.DataSetName = "dsUnterbringung";
            this.dsUnterbringung1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            ((System.ComponentModel.ISupportInitialize)(this.dsUnterbringung1)).EndInit();

        }

        #endregion

        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        public System.Data.OleDb.OleDbDataAdapter daUnterbringung;
        public dsUnterbringung dsUnterbringung1;
    }
}
