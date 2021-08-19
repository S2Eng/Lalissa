using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    public class ENVPMDSDto
    {

        public bool adminSecure { get; set; }
        public string License { get; set; }
        public string ActivateVerordnungen { get; set; }
        public string SchnellrueckmeldungAsProcess { get; set; }
        public string TypeRessourcesRun { get; set; }
        public string APVDA { get; set; }          //lth open
        public string ftpFileImportMedikamente { get; set; }
        public string ftpUserName { get; set; }
        public string ftpPassword { get; set; }
        public bool ProxyJN { get; set; }
        public string ProxyDomain { get; set; }
        public string ProxyHost { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyAuthentication { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }
        public string ImportBefundeVerzeichnis { get; set; }
        public string ImportBefundeArchivOrdner { get; set; }
        public string eMailStammdaten { get; set; }
        public string DekursRegex { get; set; }
        public string DekursRegexBeschreibung { get; set; }
        public bool FullEditMode { get; set; }
        public bool SpellCheckerOn { get; set; }
        public bool UseDekursKopieren { get; set; }
        public int PasswordStrength { get; set; }
        //public string MaxPasswortAge { get; set; }
        public int MaxIdleTime { get; set; }
        public int ToleranzIntervall { get; set; }
        public bool AbwesenheitenMinimalUI { get; set; }
        public bool DicomViewerFileOnly { get; set; }
        public bool WundtherapieVidieren { get; set; }
        public int WundbildModifyTime { get; set; }
        public int WundtherapieModifyTime { get; set; }
        public int WundverlaufModifyTime { get; set; }
        public string HAG_Url { get; set; }
        public string HAG_Zertifikat { get; set; }

        public string HAG_User { get; set; }
        public string HAG_Password { get; set; }
        public string LOGPATH { get; set; }
        public string ARCHIVPATH { get; set; }
        public string RPTCONFIGPATH { get; set; }
        public string PathDokumente { get; set; }
        public string PFLEGEMODELLE { get; set; }   //lth open
        public string SHOW_PP_TOOLTIP { get; set; }  //lth open
        public int RezepteDrucken { get; set; }
        public int IQuickNurAbt { get; set; }   //lth wird das noch benötigt
        public bool BezugspersonenJN { get; set; }
        public bool OnlyOneFavoritenComboInPlanung { get; set; }
        public int RezeptDruck { get; set; }
        public int RezeptBestellModus { get; set; }
        public int ANAMNESE_ABLAUF { get; set; }   //lth wird das noch benötigt
        public int UEBERGABE_WEEKEND { get; set; } //lth wird das noch benötigt
        public string UEBERGABE_NORMAL { get; set; } //lth wird das noch benötigt
        public int NOTFALLREFRESHINTERVALL { get; set; }
        public bool SHOW_AUFNAHMEBUTTON { get; set; }
        public int AssessmentModifyTime { get; set; }
        public bool bookingJN { get; set; }
        public bool RechnungKopfzeileEin { get; set; }
        public bool RechFloskel { get; set; }
        public bool KuerzungGrundleistungLetzterTag { get; set; }
        public int TageOhneKuerzungGrundleistung { get; set; }
        public string ZAHLUNG_TAGE { get; set; }
        public string GSBGTxt { get; set; }
        public string TransferTxt { get; set; }
        public string DepotgeldKontoTXT { get; set; }
        public bool RechErwAbwesenheit { get; set; }
        public bool SrErwAbwesenheit { get; set; }
        public bool AbwesenheitenAnzeigen { get; set; }
        public string ZahlKondBankeinzug { get; set; }
        public string ZahlKondErlagschein { get; set; }
        public string ZahlKondÜberweisung { get; set; }
        public string ZahlKondBar { get; set; }
        public string ZahlKondFSW { get; set; }

        public string CalcÜberst { get; set; } //lth wird das noch benötigt
        public string SMTPFrom { get; set; }
        public string SMTPTo { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPLoginUsr { get; set; }
        public string SMTPLoginPwd { get; set; }
        public int SMTPPort { get; set; }
        public bool WCFServiceOnOff { get; set; }

    }

}

