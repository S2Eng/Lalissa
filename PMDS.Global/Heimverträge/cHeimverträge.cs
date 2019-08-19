using PMDS.db.Entities;
using PMDS.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace PMDS.Global.Heimverträge
{


    public class cHeimverträge
    {


        public bool loadMenü(Infragistics.Win.UltraWinToolbars.PopupMenuTool popUpHeimverträge, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            try
            {
                cbo.Items.Clear();
                DirectoryInfo d = new DirectoryInfo(ENV.ReportPath);
                foreach (System.IO.FileInfo fileInfo in d.GetFiles("*.rtf"))
                {
                    if (fileInfo.Name.Trim().ToLower().StartsWith(("Heimvertrag").Trim().ToLower()))
                    {
                        string NameHeimvertrag = fileInfo.Name.Trim().Substring(11, fileInfo.Name.Trim().Length - 11 - 4);
                        string key = "btnHeimvertrag" + NameHeimvertrag.Trim();
                        Infragistics.Win .ValueListItem itm = cbo.Items.Add(key.Trim(), NameHeimvertrag.Trim());
                        itm.Tag = fileInfo.FullName;

                        //string NameHeimvertrag = fileInfo.Name.Trim().Substring(11, fileInfo.Name.Trim().Length - 11 - 4);
                        //Infragistics.Win.UltraWinToolbars.ButtonTool btnHeimvertragTest = new Infragistics.Win.UltraWinToolbars.ButtonTool("btnHeimvertrag" + NameHeimvertrag.Trim());
                        //btnHeimvertragTest.SharedPropsInternal.Caption = NameHeimvertrag.Trim();
                        //btnHeimvertragTest.SharedProps.Tag = fileInfo.FullName;
                        //popUpHeimverträge.ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnHeimvertragTest });
                        //popUpHeimverträge.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] { btnHeimvertragTest });
                    }
                }


                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.loadMenü:" + ex.ToString());
            }
        }

        public bool openDocument(string MenüKey, string fileFullName, System.Guid IDVertreter, bool bIsSachwalter, System.Guid IDVertrauensperson,
                                    string optVertretenDurch, Nullable<DateTime> dVertragVon, Nullable<DateTime> dVertragBis,
                                    bool bBefristet)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                string NameDocument = MenüKey.Trim().Substring(14, MenüKey.Trim().Length - 14);

                if (ENV.CurrentIDPatient == null || ENV.CurrentIDPatient == System.Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Patient ausgewählt!", "", System.Windows.Forms.MessageBoxButtons.OK);
                    return false;
                }
                
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    TXTextControl.ServerTextControl editor = new TXTextControl.ServerTextControl();
                    editor.Create();
                    editor.InitializeLifetimeService();
                    TXTextControl.LoadSettings settings = new TXTextControl.LoadSettings();
                    editor.Load(fileFullName, TXTextControl.StreamType.RichTextFormat, settings);
                    
                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    PMDS.db.Entities.Patient rPatient = b.getPatient(ENV.CurrentIDPatient, db);
                    PMDS.db.Entities.Aufenthalt rActAufenthalt = b.getAktuellerAufenthaltPatient(rPatient.ID, false, db);

                    string sPatientStraßeGassePlatzNrStgTür = "";
                    string sPatientPLZOrt = "";
                    if (rPatient.WohnungAbgemeldetJN != null && rPatient.WohnungAbgemeldetJN.Value == true)
                    {
                        PMDS.db.Entities.Klinik rKlinik = b.getKlinik(ENV.IDKlinik, db);
                        PMDS.db.Entities.Adresse rKlinikAdress = null;
                        if (rKlinik.IDAdresse != null)
                        {
                            rKlinikAdress = b.getAdresse2(rKlinik.IDAdresse.Value, db);
                            sPatientStraßeGassePlatzNrStgTür = rKlinikAdress.Strasse.Trim();
                            sPatientPLZOrt = rKlinikAdress.Plz.Trim() + " " + rKlinikAdress.Ort.Trim();
                        }
                    }
                    else
                    {
                        PMDS.db.Entities.Adresse rAdressPatient = b.getAdresse2(rPatient.IDAdresse.Value, db);
                        if (rAdressPatient != null)
                        {
                            sPatientStraßeGassePlatzNrStgTür = rAdressPatient.Strasse.Trim();
                            sPatientPLZOrt = rAdressPatient.Plz.Trim() + " " + rAdressPatient.Ort.Trim();
                        }
                    }

                    string sNachname = "";
                    string sVorname = "";
                    Guid IDVertrauenspersonAdress = System.Guid.NewGuid();
                    Guid IDVertrauenspersonKontakt = System.Guid.NewGuid();
                    if (bIsSachwalter)
                    {
                        Sachwalter rSachwalter = b.getSachwalter(IDVertreter, db);
                        sNachname = rSachwalter.Nachname.Trim();
                        sVorname = rSachwalter.Vorname.Trim();
                        IDVertrauenspersonAdress = rSachwalter.IDAdresse.Value;
                        if (rSachwalter.IDAdresse != null)
                        {
                            IDVertrauenspersonAdress = rSachwalter.IDAdresse.Value;
                        }
                        if (rSachwalter.IDKontakt != null)
                        {
                            IDVertrauenspersonKontakt = rSachwalter.IDKontakt.Value;
                        }
                    }
                    else
                    {
                        Kontaktperson rVertrauensperson = b.getKontaktperson(IDVertreter, db);
                        sNachname = rVertrauensperson.Nachname.Trim();
                        sVorname = rVertrauensperson.Vorname.Trim();
                        if (rVertrauensperson.IDAdresse != null)
                        {
                            IDVertrauenspersonAdress = rVertrauensperson.IDAdresse.Value;
                        }
                        if (rVertrauensperson.IDKontakt != null)
                        {
                            IDVertrauenspersonKontakt = rVertrauensperson.IDKontakt.Value;
                        }
                    }
                    
                    Adresse rVertrauenspersonAdress = b.getAdresse2(IDVertrauenspersonAdress, db);
                    Kontakt rVertrauenspersonKontakt = b.getKontakt(IDVertrauenspersonKontakt, db);

                    string sPatientVornameNachname = rPatient.Vorname.Trim() + " " + rPatient.Nachname.Trim();
                    this.setTextFrame("[PatientVornameNachname]", sPatientVornameNachname.Trim(), editor, NameDocument);
                    if (rPatient.Geburtsdatum != null)
                    {
                        this.setTextFrame("[PatientGeburtsdatum]", rPatient.Geburtsdatum.Value.ToString("dd.MM.yyyy"), editor, NameDocument);
                    }
                    else
                    {
                        this.setTextFrame("[PatientGeburtsdatum]", "", editor, NameDocument);
                    }

                    this.setTextFrame("[PatientStraßeGassePlatzNrStgTür]", sPatientStraßeGassePlatzNrStgTür, editor, NameDocument);
                    this.setTextFrame("[PatientPLZOrt]", sPatientPLZOrt.Trim(), editor, NameDocument);

                    if (dVertragVon != null)
                    {
                        this.setTextFrame("[VertragBeginn]", dVertragVon.Value.ToString("dd.MM.yyyy"), editor, NameDocument);
                    }
                    else
                    {
                        this.setTextFrame("[VertragBeginn]", "", editor, NameDocument);
                    }

                    if (dVertragBis != null)
                    {
                        this.setTextFrame("[VertragEnde]", dVertragBis.Value.ToString("dd.MM.yyyy"), editor, NameDocument);
                    }
                    else
                    {
                        this.setTextFrame("[VertragEnde]", "", editor, NameDocument);
                    }

                    DateTime dAm = DateTime.Now.Date;
                    this.setTextFrame("[Am]", dAm.ToString("dd.MM.yyyy"), editor, NameDocument);

                    bool VertretungAdressFound = false;
                    bool VertretungKontaktFound = false;

                    this.setTextFrame("[VertretungVorname]", sVorname.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertretungNachname]", sNachname.Trim(), editor, NameDocument);
                    
                    string sVertretungStraßeGassePlatzNrStgTür = "";
                    sVertretungStraßeGassePlatzNrStgTür = rVertrauenspersonAdress.Strasse.Trim();
                    this.setTextFrame("[VertretungStraßeGassePlatzNrStgTür]", sVertretungStraßeGassePlatzNrStgTür.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertretungPLZ]", rVertrauenspersonAdress.Plz.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertretungOrt]", rVertrauenspersonAdress.Ort.Trim(), editor, NameDocument);
                    VertretungAdressFound = true;
                    
                    this.setTextFrame("[VertretungTelefon]", rVertrauenspersonKontakt.Tel.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertretungFax]", rVertrauenspersonKontakt.Fax.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertretungEMail]", rVertrauenspersonKontakt.Email.Trim(), editor, NameDocument);
                    VertretungKontaktFound = true;
                    
                    if (!VertretungAdressFound)
                    {
                        this.setTextFrame("[VertretungStraßeGassePlatzNrStgTür]", "", editor, NameDocument);
                        this.setTextFrame("[VertretungPLZ]", "", editor, NameDocument);
                        this.setTextFrame("[VertretungOrt]", "", editor, NameDocument);
                    }
                    if (!VertretungKontaktFound)
                    {
                        this.setTextFrame("[VertretungTelefon]", "", editor, NameDocument);
                        this.setTextFrame("[VertretungFax]", "", editor, NameDocument);
                        this.setTextFrame("[VertretungEMail]", "", editor, NameDocument);
                    }


                    Kontaktperson rKontaktpersonOther = b.getKontaktperson(IDVertrauensperson, db);
                    Adresse rKontaktpersonOtherAdress = null;
                    Kontakt rKontaktpersonOtherKontakt = null;
                    if (rKontaktpersonOther.IDAdresse != null)
                    {
                        rKontaktpersonOtherAdress = b.getAdresse2(rKontaktpersonOther.IDAdresse.Value, db);
                    }
                    if (rKontaktpersonOther.IDKontakt != null)
                    {
                        rKontaktpersonOtherKontakt = b.getKontakt(rKontaktpersonOther.IDKontakt.Value, db);
                    }

                    bool KontaktpersonOtherAdressFound = false;
                    bool KontaktpersonOtherKontaktFound = false;
                    this.setTextFrame("[VertrPerVorname]", rKontaktpersonOther.Vorname.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertrPerNachname]", rKontaktpersonOther.Nachname.Trim(), editor, NameDocument);

                    string sVertrPerStraßeGassePlatzNrStgTür = rKontaktpersonOtherAdress.Strasse.Trim();
                    this.setTextFrame("[VertrPerStraßeGassePlatzNrStgTür]", sVertrPerStraßeGassePlatzNrStgTür.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertrPerPLZ]", rKontaktpersonOtherAdress.Plz.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertrPerOrt]", rKontaktpersonOtherAdress.Ort.TrimEnd(), editor, NameDocument);
                    KontaktpersonOtherAdressFound = true;

                    this.setTextFrame("[VertrPerTelefon]", rKontaktpersonOtherKontakt.Tel.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertrPerFax]", rKontaktpersonOtherKontakt.Fax.Trim(), editor, NameDocument);
                    this.setTextFrame("[VertrPerEMail]", rKontaktpersonOtherKontakt.Email.Trim(), editor, NameDocument);
                    KontaktpersonOtherKontaktFound = true;
                    
                    if (!KontaktpersonOtherAdressFound)
                    {
                        this.setTextFrame("[VertrPerStraßeGassePlatzNrStgTür]", "", editor, NameDocument);
                        this.setTextFrame("[VertrPerPLZ]", "", editor, NameDocument);
                        this.setTextFrame("[VertrPerOrt]", "", editor, NameDocument);
                    }
                    if (!KontaktpersonOtherKontaktFound)
                    {
                        this.setTextFrame("[VertrPerTelefon]", "", editor, NameDocument);
                        this.setTextFrame("[VertrPerFax]", "", editor, NameDocument);
                        this.setTextFrame("[VertrPerEMail]", "", editor, NameDocument);
                    }

                    if (optVertretenDurch.Trim().ToLower().Equals("SachwalterUrkunde".Trim().ToLower()))
                    {
                        this.setTextFrame("[✓1]", "X", editor, NameDocument);       //✓
                        this.removeTextFrame("[✓2]", editor, NameDocument);
                        this.removeTextFrame("[✓3]", editor, NameDocument);
                        this.removeTextFrame("[✓4]", editor, NameDocument);
                        this.removeTextFrame("[✓5]", editor, NameDocument);
                    }
                    else if (optVertretenDurch.Trim().ToLower().Equals("EinstweiligerSachwalter".Trim().ToLower()))
                    {
                        this.setTextFrame("[✓2]", "X", editor, NameDocument);
                        this.removeTextFrame("[✓1]", editor, NameDocument);
                        this.removeTextFrame("[✓3]", editor, NameDocument);
                        this.removeTextFrame("[✓4]", editor, NameDocument);
                        this.removeTextFrame("[✓5]", editor, NameDocument);
                    }
                    else if (optVertretenDurch.Trim().ToLower().Equals("SchriftlichBevollmächtigter".Trim().ToLower()))
                    {
                        this.setTextFrame("[✓3]", "X", editor, NameDocument);
                        this.removeTextFrame("[✓1]", editor, NameDocument);
                        this.removeTextFrame("[✓2]", editor, NameDocument);
                        this.removeTextFrame("[✓4]", editor, NameDocument);
                        this.removeTextFrame("[✓5]", editor, NameDocument);
                    }
                    else if (optVertretenDurch.Trim().ToLower().Equals("MündlichBevollmächtigter".Trim().ToLower()))
                    {
                        this.setTextFrame("[✓4]", "X", editor, NameDocument);
                        this.removeTextFrame("[✓1]", editor, NameDocument);
                        this.removeTextFrame("[✓2]", editor, NameDocument);
                        this.removeTextFrame("[✓3]", editor, NameDocument);
                        this.removeTextFrame("[✓5]", editor, NameDocument);
                    }
                    else if (optVertretenDurch.Trim().ToLower().Equals("GeschäftsführerOhneAuftrag".Trim().ToLower()))
                    {
                        this.setTextFrame("[✓5]", "X", editor, NameDocument);
                        this.removeTextFrame("[✓1]", editor, NameDocument);
                        this.removeTextFrame("[✓2]", editor, NameDocument);
                        this.removeTextFrame("[✓3]", editor, NameDocument);
                        this.removeTextFrame("[✓4]", editor, NameDocument);
                    }
                    else
                    {
                        throw new Exception("openDocument: optVertretenDurch '" + optVertretenDurch.Trim() + "' not allowed!");
                    }

                    TXTextControl.SaveSettings saveSettings = new TXTextControl.SaveSettings();
                    string pathSaveDocu = Path.GetTempPath();                       //Environment.GetFolderPath(Environment.SpecialFolder.);
                    string NameDocuSave = NameDocument.Trim() + "_" + System.Guid.NewGuid().ToString();
                    string FillNameDocuSave = pathSaveDocu + "\\" + NameDocuSave + ".pdf";
                    editor.Save(FillNameDocuSave, TXTextControl.StreamType.AdobePDF, saveSettings);

                    qs2.core.vb.funct f = new qs2.core.vb.funct();
                    f.openFile(FillNameDocuSave, "", false);

                    //QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                    //QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                    //frmEditor.fFelderEinAus = false;
                    //frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                    //frmEditor.ContTxtEditor1.LinealeOnOff(false);
                    //frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                    //frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                    //frmEditor.Show();
                    //frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Heimvertrag");
                    //frmEditor.openDokument(FillNameDocuSave, TXTextControl.StreamType.AdobePDF, false);

                    //byte[] b = null;
                    //doEditor1.showFile(FillNameDocuSave, TXTextControl.StreamType.AdobePDF, frmEditor.ContTxtEditor1.textControl1);
                }
                return true;


                //string txtBeschreibungRtfNew = this.doEditor1.getText(TXTextControl.StringStreamType.RichTextFormat, this.contTXTFieldBeschreibung.TXTControlField);

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.openPDF:" + ex.ToString());
            }
        }

        public void setTextFrame(string sKey, string Txt, TXTextControl.ServerTextControl editor, string Document)
        {
            try
            {
                bool bFrameFound = false;
                foreach (TXTextControl.TextFrame txtFrame in editor.TextFrames)
                {
                    txtFrame.Selection.Start = 0;
                    txtFrame.Selection.Length = 100;
                    string selTxt= txtFrame.Selection.Text.Trim();
                    
                    if (selTxt.Trim().ToLower().Equals(sKey.Trim().ToLower()))
                    {
                        txtFrame.Selection.Text = Txt.Trim();           //txtFrame.Selection.Text.Replace(sKey.Trim(), Txt.Trim());
                        bFrameFound = true;
                    }
                }

                if (!bFrameFound)
                {
                    throw new Exception("setTextFrame: Frame '" + sKey.Trim() + "' not found in Document '" + Document.Trim() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.setTextFrame:" + ex.ToString());
            }
        }
        public void removeTextFrame(string sKey, TXTextControl.ServerTextControl editor, string Document)
        {
            try
            {
                bool bFrameFound = false;
                TXTextControl.TextFrame txtFrameFound = null;
                foreach (TXTextControl.TextFrame txtFrame in editor.TextFrames)
                {
                    txtFrame.Selection.Start = 0;
                    txtFrame.Selection.Length = 100;
                    string selTxt = txtFrame.Selection.Text.Trim();

                    if (!bFrameFound && selTxt.Trim().ToLower().Equals(sKey.Trim().ToLower()))
                    {
                        txtFrameFound = txtFrame;
                        bFrameFound = true;
                    }
                }

                if (!bFrameFound)
                {
                    throw new Exception("removeTextFrame: Frame '" + sKey.Trim() + "' not found in Document '" + Document.Trim() + "'!");
                }

                editor.TextFrames.Remove(txtFrameFound);

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.removeTextFrame:" + ex.ToString());
            }
        }
    }

}
