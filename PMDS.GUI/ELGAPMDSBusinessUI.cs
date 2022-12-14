using PMDS.db.Entities;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Configuration;
using System.Data;
using System.IO;
using PMDS.Global.db.Patient;
using System.Drawing;

using PMDS.Global.db.ERSystem;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.DB.Global;
using PMDS.DB;
using PMDS.Calc.UI.Admin;
using PMDS.GUI.ELGA;
using System.Text.RegularExpressions;
using PMDSClient.Sitemap;
using PMDS.DynReportsForms;
using WCFServicePMDS.BAL2.ELGABAL;

namespace PMDS.GUI
{

    public class ELGAPMDSBusinessUI
    {


        public void genCDA(Guid IDPatient, Guid IDAufenthalt, Nullable<Guid> IDUrlaub, WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA, bool verstorbenJN,
                           Nullable<Guid> IDEinrichtungEmpfänger = null, Nullable<Guid> IDDokumenteneintrag = null)
        {
            try
            {
                string FileType = ".xml";

                if (!ENV.lic_ELGA)
                {
                    return;
                }

                if (!ELGABusiness.checkELGASessionActive(true))
                {
                    return;
                }
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    ELGABusiness bElga = new ELGABusiness();
                    if (!bElga.ELGAIsActive(IDPatient, IDAufenthalt, false))
                    {
                        return;
                    }

                    var rAufenthalt = (from a in db.Aufenthalt
                                       join p in db.Patient on a.IDPatient equals p.ID
                                       join abt in db.Abteilung on a.IDAbteilung equals abt.ID
                                       join kli in db.Klinik on abt.IDKlinik equals kli.ID
                                   where a.ID == IDAufenthalt
                                   select new
                                   {
                                       IDAufenthalt = a.ID,
                                       a.ELGALocalID,
                                       a.ELGAKontaktbestätigungJN,
                                       a.ELGAKontaktbestätigungContactID,
                                       IDPatient = p. ID,
                                       p.Nachname,
                                       p.Vorname,
                                       p.ELGAAbgemeldet,
                                       Abteilung = abt.Bezeichnung,
                                       Klinik = kli.Bezeichnung
                                   }).First();

                    var rUser = (from ben in db.Benutzer
                                       where ben.ID == ENV.USERID
                                       select new
                                       {
                                           Nachname = ben.Nachname.Trim(),
                                           Vorname = ben.Vorname.Trim(),
                                           Benutzer = ben.Benutzer1.Trim()
                                       }).First();

                    WCFServiceClient wcf = new WCFServiceClient();
                    DateTime dNow = DateTime.Now;

                    string ClinicalDocumentSetID = System.Guid.NewGuid().ToString();
                    Guid IDDocument = System.Guid.NewGuid();
                    int VersionsNr = 0;

                    string Author = rAufenthalt.Klinik + " - " + rAufenthalt.Abteilung + ": " + rUser.Vorname + " " + rUser.Nachname;
                    string CreationTime = DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss");

                    if (CDAeTypeCDA == WCFServicePMDS.CDABAL.CDA.eTypeCDA.Entlassungsbrief)
                    {
                        string Documentname = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegerischer Entlassungsbrief");
                        string Stylesheet = "ELGA_Stylesheet_v1.0.xsl";
                        bool hasRight = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPflegerischerEntlassungsbrief, false);

                        this.prieviewSendSaveCDA(IDPatient, IDAufenthalt, IDUrlaub, CDAeTypeCDA, IDDocument, ClinicalDocumentSetID, VersionsNr, Documentname, Stylesheet, rAufenthalt.ELGALocalID.Trim(), db, dNow, hasRight,
                                                    IDEinrichtungEmpfänger, verstorbenJN, FileType, IDDokumenteneintrag, Author, CreationTime);

                        if (rAufenthalt.ELGAKontaktbestätigungJN)
                        {
                            try
                            {
                                ELGAParOutDto parOuot = wcf.ELGAAddContactDischarge(rAufenthalt.ELGALocalID.Trim());

                                string sProt = QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Kontakt für Patient {0} wurde beendet");
                                sProt = string.Format(sProt, rAufenthalt.Nachname + " " + rAufenthalt.Vorname);
                                ELGABusiness.saveELGAProtocoll(QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Kontakt beendet"), null,
                                                                ELGABusiness.eTypeProt.KontaktbestätigungStorno, ELGABusiness.eELGAFunctions.none, "", "", ENV.USERID, IDPatient, IDAufenthalt, sProt);

                                string msgOKEndContact = QS2.Desktop.ControlManagment.ControlManagment.getRes("Elga-Kontakt für Patient wurde erfolgreich beendet!");
                                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgOKEndContact, "", MessageBoxButtons.OK, true);

                            }
                            catch (Exception ex)
                            {
                                string sExcept = "ELGAPMDSBusinessUI.genCDA: Error ELGAAddContactDischarge for IDPatient='" + IDPatient.ToString() + "'" + "\r\n" + "\r\n" + ex.ToString();
                                ENV.HandleException(new Exception(sExcept));
                                //throw new Exception(sExcept);
                            }
                        }
                    }
                    else if (CDAeTypeCDA == WCFServicePMDS.CDABAL.CDA.eTypeCDA.Pflegesituationsbericht)
                    {
                        string Documentname = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegezustandsbericht");
                        string Stylesheet = "ELGA_Stylesheet_v1.0.xsl";
                        bool hasRight = ELGABusiness.HasELGARight(ELGABusiness.eELGARight.ELGAPflegezustandsbericht, false);

                        this.prieviewSendSaveCDA(IDPatient, IDAufenthalt, IDUrlaub, CDAeTypeCDA, IDDocument, ClinicalDocumentSetID, VersionsNr, Documentname, Stylesheet, rAufenthalt.ELGALocalID.Trim(), db, dNow, hasRight,
                                                    IDEinrichtungEmpfänger, verstorbenJN, FileType, IDDokumenteneintrag, Author, CreationTime);
                    }
                    else
                    {
                        throw new Exception("ELGAPMDSBusinessUI.genCDA: CDAeTypeCDA '" + CDAeTypeCDA.ToString() + "' not allowed!");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAPMDSBusinessUI.genCDA: " + ex.ToString());
            }
        }
        public void prieviewSendSaveCDA(Guid IDPatient, Guid IDAufenthalt, Nullable<Guid> IDUrlaub, WCFServicePMDS.CDABAL.CDA.eTypeCDA CDAeTypeCDA,
                                        Guid IDDocument, string ClinicalDocumentSetID, int VersionsNr,
                                        string Documentname, string Stylesheet, string PatientELGALocalID, PMDS.db.Entities.ERModellPMDSEntities db, DateTime dNow,
                                        bool hasRight, Nullable<Guid> IDEinrichtungEmpfänger, bool verstorbenJN, string FileType, Nullable<Guid> IDDokumenteneintrag, 
                                        string Author, string CreationTime)
        {
            try
            {
                WCFServiceClient wcf = new WCFServiceClient();
                ELGABusiness bElga = new ELGABusiness();

                string ArchivePath = "";
                Nullable<Guid> IDOrdnerArchiv = null;
                if (!bElga.checkArchivesystem(ref ArchivePath, ref IDOrdnerArchiv))
                {
                    throw new Exception("ELGAPMDSBusinessUI.prieviewSendSaveCDA: ArchivePath not correct!" + "\r\n" + "Please contact your Administrator!");
                }

                WCFServiceClient.genCDARes resCda = wcf.genCDA2(CDAeTypeCDA, IDEinrichtungEmpfänger, IDDocument, ClinicalDocumentSetID, VersionsNr, Stylesheet, IDPatient, IDAufenthalt, Documentname, IDDokumenteneintrag);

                Guid IDDocumenteneintrag = System.Guid.NewGuid();
                bool SavedToELGA = false;
                string msg1 = "";
                frmCDAViewer frmCDAViewer1 = new frmCDAViewer();

                string sFileXmlTmp = "";
                string sStylesheetTmp = bElga.getStylesheetAndXmlFromELGAXmlDocu(resCda.xml, ref sFileXmlTmp);

                frmCDAViewer1.initControl(Documentname, "", ClinicalDocumentSetID, sFileXmlTmp, CDAeTypeCDA.ToString(), sStylesheetTmp, contCDAViewer.eTypeUI.SaveToElga);
                frmCDAViewer1.contCDAViewer1.btnSaveDocuToELGA.Visible = !verstorbenJN;
                frmCDAViewer1.ControlBox = false;
                frmCDAViewer1.ShowDialog();
                if (frmCDAViewer1.contCDAViewer1.chkUploadToELGA.Checked)
                {
                    if (frmCDAViewer1.contCDAViewer1.saveToElgaClicked)
                    {
                        if (hasRight)
                        {
                            bool bSaveDocuOK = bElga.saveDocuToELGA(IDPatient, IDAufenthalt, IDUrlaub, Documentname, resCda.xml, resCda.bXml, Stylesheet, ClinicalDocumentSetID, CDAeTypeCDA, FileType, verstorbenJN);
                            string msgOK = QS2.Desktop.ControlManagment.ControlManagment.getRes("CDA-Dokument wurde erfolgreich generiert, nach ELGA hochgeladen und im Dokumentenarchiv gespeichert!");
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msgOK, "", MessageBoxButtons.OK, true);
                            SavedToELGA = true;
                        }
                        else
                        {
                            msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen, da Sie hierfür keine Rechte besitzen!");
                            bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, FileType, ref IDOrdnerArchiv, Author, CreationTime, CDAeTypeCDA.ToString(), db, ref dNow, ref wcf, IDAufenthalt,
                                                                    IDPatient, IDUrlaub, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), ref IDDocumenteneintrag, false, resCda.xml, true, 0);
                        }
                    }
                    else
                    {
                        msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen!");
                        bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, FileType, ref IDOrdnerArchiv, Author, CreationTime, CDAeTypeCDA.ToString(), db, ref dNow, ref wcf, IDAufenthalt,
                                                                    IDPatient, IDUrlaub, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), ref IDDocumenteneintrag, false, resCda.xml, true, 0);
                    }
                }
                else
                {
                    msg1 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Das ELGA-Dokument wurde nicht nach ELGA übertragen!");
                    bool bDocuOK = bElga.saveELGADocuToDB(ref ArchivePath, FileType, ref IDOrdnerArchiv, Author, CreationTime, CDAeTypeCDA.ToString(), db, ref dNow, ref wcf, IDAufenthalt,
                                                                    IDPatient, IDUrlaub, "", PatientELGALocalID.Trim(), Documentname.Trim(), Stylesheet.Trim(), ref IDDocumenteneintrag, false, resCda.xml, true, 0);
                }

                if (!SavedToELGA)
                {
                    string msg2 = QS2.Desktop.ControlManagment.ControlManagment.getRes("Es kann später jederzeit im Dokumentenarchiv nachübertragen werden!");
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(msg1 + "\r\n" + msg2, "", MessageBoxButtons.OK, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAPMDSBusinessUI.prieviewSendSaveCDA: " + ex.ToString());
            }
        }

        public void openELGADocuFromArchive(Nullable<Guid> IDDokumenteneintrag, bool bOpenInBrowser = true)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    var rDocuEintrag = (from de in db.tblDokumenteintrag
                                        where de.ID == IDDokumenteneintrag
                                        select new
                                        {
                                            de.Bezeichnung,
                                            de.IDAufenthalt,
                                            de.IDUrlaub,
                                            de.ID,
                                            de.IsELGADocu,
                                            de.ELGAUniqueID,
                                            de.ELGAÜbertragen,
                                            de.FileStylesheet
                                        }).First();

                    var rDocu = (from de in db.tblDokumente
                                 where de.IDDokumenteintrag == rDocuEintrag.ID
                                 select new
                                 {
                                     de.ID,
                                     de.DateinameTyp,
                                     de.IDDokumenteintrag,
                                     de.DateinameArchiv,
                                     de.Archivordner,
                                 }).First();

                    var rPfad = (from p in db.tblPfad
                                 select new
                                 {
                                     p.Archivpfad
                                 }).First();

                    string FileArchive = Path.Combine(rPfad.Archivpfad.Trim(), rDocu.Archivordner.Trim(), rDocu.DateinameArchiv.Trim());
                    using (MemoryStream msXML = new MemoryStream())
                    {
                        using (FileStream file = new FileStream(FileArchive, FileMode.Open, FileAccess.Read))
                        {
                            byte[] bytes = new byte[file.Length];
                            file.Read(bytes, 0, (int)file.Length);
                            msXML.Write(bytes, 0, (int)file.Length);
                            clsELGAPrint pr = new clsELGAPrint();
                            if (bOpenInBrowser)
                                pr.ShowXMLInBrowser(msXML, "", true);
                            else
                                pr.ConvertCDA2PDF(msXML, "");
                        }
                    }

                    //string xmlFile = "";
                    //using (StreamReader sr = File.OpenText(FileArchive))
                    //{
                    //    xmlFile = sr.ReadToEnd();
                    //}

                    //ELGABusiness bElga = new ELGABusiness();
                    //string sFileXmlTmp = "";
                    //string sStylesheetTmp = bElga.getStylesheetAndXmlFromELGAXmlDocu(xmlFile, ref sFileXmlTmp);

                    //frmCDAViewer frmCDAViewer1 = new frmCDAViewer();
                    //frmCDAViewer1.initControl(rDocuEintrag.Bezeichnung.Trim(), rDocuEintrag.ELGAUniqueID.Trim(), "", sFileXmlTmp, rDocu.DateinameTyp, sStylesheetTmp.Trim(), contCDAViewer.eTypeUI.saveToArchive);
                    //frmCDAViewer1.contCDAViewer1.btnSaveIntoArchive.Visible = false;
                    //frmCDAViewer1.contCDAViewer1.btnSaveDocuToELGA.Visible = false;
                    //frmCDAViewer1.contCDAViewer1.btnAbort.Visible = false;
                    //frmCDAViewer1.Show();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ELGAPMDSBusinessUI.openELGADocuFromArchive: " + ex.ToString());
            }
        }

    }

}
