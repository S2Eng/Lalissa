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

                var files = Directory.EnumerateFiles(ENV.ReportPath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase) || s.EndsWith(".rtf", StringComparison.CurrentCultureIgnoreCase));
                foreach (string f in files)
                {
                    System.IO.FileInfo fi = new FileInfo(f);
                    if (fi.Name.StartsWith("Heimvertrag", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Infragistics.Win.ValueListItem itm = cbo.Items.Add(fi.FullName, fi.Name);
                        itm.Tag = fi.FullName;
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
                                    bool bBefristet, bool bUnterzeichnenderSelection, bool bVertrauenspersonSelection)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                string NameDocument = System.IO.Path.GetFileNameWithoutExtension(fileFullName);  //MenüKey.Trim().Substring(14, MenüKey.Trim().Length - 14);

                if (ENV.CurrentIDPatient == null || ENV.CurrentIDPatient == System.Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Klient ausgewählt!", "", System.Windows.Forms.MessageBoxButtons.OK);
                    return false;
                }


                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;

                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

                        var rPatInfo = (from p in db.Patient
                                        where p.ID == ENV.CurrentIDPatient
                                        select new
                                        { p.ID, 
                                            p.Nachname, 
                                            p.Vorname,
                                            p.WohnungAbgemeldetJN,
                                            p.IDAdresse,
                                            p.IDKontakt,
                                            p.Geburtsdatum,
                                            p.Geburtsort}
                                       ).First();

                    //PMDS.db.Entities.Patient rPatient = b.getPatient(ENV.CurrentIDPatient, db);
                    PMDS.db.Entities.Aufenthalt rActAufenthalt = b.getAktuellerAufenthaltPatient(rPatInfo.ID, false, db);

                    string sPatientStraßeGassePlatzNrStgTür = "";
                    string sPatientPLZOrt = "";
                    string sPatientTelefon = "";

                    if (rPatInfo.WohnungAbgemeldetJN != null && rPatInfo.WohnungAbgemeldetJN.Value == true)
                    {
                        PMDS.db.Entities.Klinik rKlinik = b.getKlinik(ENV.IDKlinik, db);
                        PMDS.db.Entities.Adresse rKlinikAdress = null;
                        PMDS.db.Entities.Kontakt rKlinikKontakt = null;
                        if (rKlinik.IDAdresse != null)
                        {
                            rKlinikAdress = b.getAdresse2(rKlinik.IDAdresse.Value, db);
                            sPatientStraßeGassePlatzNrStgTür = rKlinikAdress.Strasse.Trim();
                            sPatientPLZOrt = rKlinikAdress.Plz.Trim() + " " + rKlinikAdress.Ort.Trim();
                        }
                        if (rKlinik.IDKontakt != null)
                        {
                            rKlinikKontakt = b.getKontakt(rKlinik.IDKontakt.Value, db);
                            sPatientTelefon = rKlinikKontakt.Tel.Trim();
                        }
                    }
                    else
                    {
                        PMDS.db.Entities.Adresse rAdressPatient = b.getAdresse2(rPatInfo.IDAdresse.Value, db);
                        if (rAdressPatient != null)
                        {
                            sPatientStraßeGassePlatzNrStgTür = rAdressPatient.Strasse.Trim();
                            sPatientPLZOrt = rAdressPatient.Plz.Trim() + " " + rAdressPatient.Ort.Trim();
                        }
                        if (rPatInfo.IDKontakt != null)
                        {
                            PMDS.db.Entities.Kontakt rPatientKontakt = null;
                            rPatientKontakt = b.getKontakt(rPatInfo.IDKontakt.Value, db);
                            sPatientTelefon = rPatientKontakt.Tel.Trim();
                        }
                    }

                    string sNachname = "";
                    string sVorname = "";
                    string sVertretungStrasse = "";
                    string sVertretungPlz = "";
                    string sVertretungFax = "";
                    string sVertretungOrt = "";
                    string sVertretungTel = "";
                    string sVertretungEMail = "";

                    Guid IDVertrauenspersonAdress2 = System.Guid.NewGuid();
                    Guid IDVertrauenspersonKontakt2 = System.Guid.NewGuid();
                    if (bUnterzeichnenderSelection)
                    {
                        if (bIsSachwalter)
                        {
                            Sachwalter rSachwalter = b.getSachwalter(IDVertreter, db);
                            sNachname = rSachwalter.Nachname.Trim();
                            sVorname = rSachwalter.Vorname.Trim();
                            IDVertrauenspersonAdress2 = rSachwalter.IDAdresse.Value;
                            if (rSachwalter.IDAdresse != null)
                                IDVertrauenspersonAdress2 = rSachwalter.IDAdresse.Value;
                            if (rSachwalter.IDKontakt != null)
                                IDVertrauenspersonKontakt2 = rSachwalter.IDKontakt.Value;
                        }
                        else
                        {
                            Kontaktperson rVertrauensperson = b.getKontaktperson(IDVertreter, db);
                            sNachname = rVertrauensperson.Nachname.Trim();
                            sVorname = rVertrauensperson.Vorname.Trim();
                            if (rVertrauensperson.IDAdresse != null)
                            {
                                IDVertrauenspersonAdress2 = rVertrauensperson.IDAdresse.Value;
                            }
                            if (rVertrauensperson.IDKontakt != null)
                            {
                                IDVertrauenspersonKontakt2 = rVertrauensperson.IDKontakt.Value;
                            }
                        }

                        Adresse rVertrauenspersonAdress = b.getAdresse2(IDVertrauenspersonAdress2, db);
                        Kontakt rVertrauenspersonKontakt = b.getKontakt(IDVertrauenspersonKontakt2, db);

                        sVertretungStrasse = rVertrauenspersonAdress.Strasse.Trim();
                        sVertretungPlz = rVertrauenspersonAdress.Plz.Trim();
                        sVertretungOrt = rVertrauenspersonAdress.Ort.Trim();
                        sVertretungTel = rVertrauenspersonKontakt.Tel.Trim();
                        sVertretungFax = rVertrauenspersonKontakt.Fax.Trim();
                        sVertretungEMail = rVertrauenspersonKontakt.Email.Trim();
                    }

                    string sPatientVornameNachname = rPatInfo.Vorname.Trim() + " " + rPatInfo.Nachname.Trim();

                    DateTime dAm = DateTime.Now.Date;

                    string sVertretungStraßeGassePlatzNrStgTür = "";
                    sVertretungStraßeGassePlatzNrStgTür = sVertretungStrasse.Trim();

                    string VertrPerVorname = "";
                    string VertrPerNachname = "";
                    string VertrPerStrasse = "";
                    string VertrPerPlz = "";
                    string VertrPerOrt = "";
                    string VertrPerTel = "";
                    string VertrPerFax = "";
                    string VertrPerEmail = "";
                    if (bVertrauenspersonSelection)
                    {
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

                        VertrPerVorname = rKontaktpersonOther.Vorname.Trim();
                        VertrPerNachname = rKontaktpersonOther.Nachname.Trim();
                        VertrPerStrasse = rKontaktpersonOtherAdress.Strasse.Trim();
                        VertrPerPlz = rKontaktpersonOtherAdress.Plz.Trim();
                        VertrPerOrt = rKontaktpersonOtherAdress.Ort.Trim();
                        VertrPerTel = rKontaktpersonOtherKontakt.Tel.Trim();
                        VertrPerFax = rKontaktpersonOtherKontakt.Fax.Trim();
                        VertrPerEmail = rKontaktpersonOtherKontakt.Email.Trim();
                    }

                    //PDF-Ausgabe
                    PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
                    byte[] bPDF;
                    if (frmPDF.OpenPDF(fileFullName, out bPDF))
                    {
                        frmPDF.SetValue("PatientVorname", rPatInfo.Vorname, frmPDF.form);
                        frmPDF.SetValue("PatientNachname", rPatInfo.Nachname, frmPDF.form);
                        if (rPatInfo.Geburtsdatum != null)
                            frmPDF.SetValue("PatientGeburtsdatum", rPatInfo.Geburtsdatum.Value.ToString("dd.MM.yyyy") ?? "", frmPDF.form);
                        frmPDF.SetValue("PatientGeburtsort", rPatInfo.Geburtsort, frmPDF.form);
                        frmPDF.SetValue("PatientStraßeGassePlatzNrStgTür", sPatientStraßeGassePlatzNrStgTür, frmPDF.form);
                        frmPDF.SetValue("PatientPLZOrt", sPatientPLZOrt, frmPDF.form);
                        frmPDF.SetValue("PatientTelefon", sPatientTelefon, frmPDF.form);

                        frmPDF.SetValue("Am", dAm.ToString("dd.MM.yyyy"), frmPDF.form);
                        if (dVertragVon != null)
                            frmPDF.SetValue("VertragBeginn", dVertragVon.Value.ToString("dd.MM.yyyy"), frmPDF.form);
                        if (dVertragBis != null)
                            frmPDF.SetValue("VertragEnde", dVertragBis.Value.ToString("dd.MM.yyyy"), frmPDF.form);

                        frmPDF.SetValue("VertretungVorname", sVorname, frmPDF.form);
                        frmPDF.SetValue("VertretungNachname", sNachname, frmPDF.form);
                        frmPDF.SetValue("VertretungStraßeGassePlatzNrStgTür", sVertretungStraßeGassePlatzNrStgTür, frmPDF.form);
                        frmPDF.SetValue("VertretungPLZ", sVertretungPlz, frmPDF.form);
                        frmPDF.SetValue("VertretungOrt", sVertretungOrt, frmPDF.form);
                        frmPDF.SetValue("VertretungTelefon", sVertretungTel, frmPDF.form);
                        frmPDF.SetValue("VertretungFax", sVertretungFax, frmPDF.form);
                        frmPDF.SetValue("VertretungEMail", sVertretungEMail, frmPDF.form);

                        frmPDF.SetValue("VertrPerVorname", VertrPerVorname, frmPDF.form);
                        frmPDF.SetValue("VertrPerNachname", VertrPerNachname, frmPDF.form);
                        frmPDF.SetValue("VertrPerStraßeGassePlatzNrStgTür", VertrPerStrasse, frmPDF.form);
                        frmPDF.SetValue("VertrPerPLZ", VertrPerPlz, frmPDF.form);
                        frmPDF.SetValue("VertrPerOrt", VertrPerOrt, frmPDF.form);
                        frmPDF.SetValue("VertrPerTelefon", VertrPerTel, frmPDF.form);
                        frmPDF.SetValue("VertrPerFax", VertrPerFax, frmPDF.form);
                        frmPDF.SetValue("VertrPerEMail", VertrPerEmail, frmPDF.form);

                        if (optVertretenDurch.Trim().ToLower().Equals("SachwalterUrkunde".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "1", frmPDF.form);
                        else if (optVertretenDurch.Trim().ToLower().Equals("EinstweiligerSachwalter".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "2", frmPDF.form);
                        else if (optVertretenDurch.Trim().ToLower().Equals("SchriftlichBevollmächtigter".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "3", frmPDF.form);
                        else if (optVertretenDurch.Trim().ToLower().Equals("MündlichBevollmächtigter".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "4", frmPDF.form);
                        else if (optVertretenDurch.Trim().ToLower().Equals("GeschäftsführerOhneAuftrag".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "5", frmPDF.form);
                        else if (optVertretenDurch.Trim().ToLower().Equals("Eigenberechtigt".Trim().ToLower()))
                            frmPDF.SetValue("VertretenDurch", "6", frmPDF.form);

                        frmPDF.ShowBookmarks = false;
                        frmPDF.ShowOpenDialog = false;
                        frmPDF.ShowPrintDialog = true;
                        frmPDF.SetCaption = QS2.Desktop.ControlManagment.ControlManagment.getRes("Heimvertrag");
                        frmPDF.Show();
                    }
                    else if (System.IO.Path.GetExtension(fileFullName).Equals(".RTF", StringComparison.CurrentCultureIgnoreCase))
                    {
                        TXTextControl.ServerTextControl editor = new TXTextControl.ServerTextControl();
                        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
                        editor.Create();
                        editor.InitializeLifetimeService();
                        TXTextControl.LoadSettings settings = new TXTextControl.LoadSettings();
                        editor.Load(fileFullName, TXTextControl.StreamType.RichTextFormat, settings);

                        this.setTextFrame("[PatientVorname]", rPatInfo.Vorname.Trim(), editor);
                        this.setTextFrame("[PatientNachname]", rPatInfo.Nachname.Trim(), editor);
                        if (rPatInfo.Geburtsdatum != null)
                            this.setTextFrame("[PatientGeburtsdatum]", rPatInfo.Geburtsdatum.Value.ToString("dd.MM.yyyy"), editor);
                        else
                            this.setTextFrame("[PatientGeburtsdatum]", "", editor);
                        this.setTextFrame("[PatientGeburtsort]", rPatInfo.Geburtsort.Trim(), editor);
                        this.setTextFrame("[PatientStraßeGassePlatzNrStgTür]", sPatientStraßeGassePlatzNrStgTür, editor);
                        this.setTextFrame("[PatientPLZOrt]", sPatientPLZOrt.Trim(), editor);
                        this.setTextFrame("[PatientTelefon]", sPatientTelefon.Trim(), editor);

                        if (dVertragVon != null)
                            this.setTextFrame("[VertragBeginn]", dVertragVon.Value.ToString("dd.MM.yyyy"), editor);
                        else
                            this.setTextFrame("[VertragBeginn]", "", editor);

                        if (dVertragBis != null)
                            this.setTextFrame("[VertragEnde]", dVertragBis.Value.ToString("dd.MM.yyyy"), editor);
                        else
                            this.setTextFrame("[VertragEnde]", "", editor);

                        this.setTextFrame("[Am]", dAm.ToString("dd.MM.yyyy"), editor);

                        this.setTextFrame("[VertretungVorname]", sVorname.Trim(), editor);
                        this.setTextFrame("[VertretungNachname]", sNachname.Trim(), editor);
                        this.setTextFrame("[VertretungStraßeGassePlatzNrStgTür]", sVertretungStraßeGassePlatzNrStgTür.Trim(), editor);
                        this.setTextFrame("[VertretungPLZ]", sVertretungPlz.Trim(), editor);
                        this.setTextFrame("[VertretungOrt]", sVertretungOrt.Trim(), editor);
                        this.setTextFrame("[VertretungTelefon]", sVertretungTel.Trim(), editor);
                        this.setTextFrame("[VertretungFax]", sVertretungFax.Trim(), editor);
                        this.setTextFrame("[VertretungEMail]", sVertretungEMail.Trim(), editor);

                        this.setTextFrame("[VertrPerVorname]", VertrPerVorname, editor);
                        this.setTextFrame("[VertrPerNachname]", VertrPerNachname, editor);
                        this.setTextFrame("[VertrPerStraßeGassePlatzNrStgTür]", VertrPerStrasse, editor);
                        this.setTextFrame("[VertrPerPLZ]", VertrPerPlz, editor);
                        this.setTextFrame("[VertrPerOrt]", VertrPerOrt, editor);
                        this.setTextFrame("[VertrPerTelefon]", VertrPerTel, editor);
                        this.setTextFrame("[VertrPerFax]", VertrPerFax, editor);
                        this.setTextFrame("[VertrPerEMail]", VertrPerEmail, editor);

                        this.setTextFrame("[VertrPerStraßeGassePlatzNrStgTür]", "", editor);
                        this.setTextFrame("[VertrPerPLZ]", "", editor);
                        this.setTextFrame("[VertrPerOrt]", "", editor);

                        if (optVertretenDurch.Trim().ToLower().Equals("SachwalterUrkunde".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓1]", "X", editor);       //✓
                            this.removeTextFrame("[✓2]", editor);
                            this.removeTextFrame("[✓3]", editor);
                            this.removeTextFrame("[✓4]", editor);
                            this.removeTextFrame("[✓5]", editor);
                            this.removeTextFrame("[✓6]", editor);
                        }
                        else if (optVertretenDurch.Trim().ToLower().Equals("EinstweiligerSachwalter".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓2]", "X", editor);
                            this.removeTextFrame("[✓1]", editor);
                            this.removeTextFrame("[✓3]", editor);
                            this.removeTextFrame("[✓4]", editor);
                            this.removeTextFrame("[✓5]", editor);
                            this.removeTextFrame("[✓6]", editor);
                        }
                        else if (optVertretenDurch.Trim().ToLower().Equals("SchriftlichBevollmächtigter".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓3]", "X", editor);
                            this.removeTextFrame("[✓1]", editor);
                            this.removeTextFrame("[✓2]", editor);
                            this.removeTextFrame("[✓4]", editor);
                            this.removeTextFrame("[✓5]", editor);
                            this.removeTextFrame("[✓6]", editor);
                        }
                        else if (optVertretenDurch.Trim().ToLower().Equals("MündlichBevollmächtigter".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓4]", "X", editor);
                            this.removeTextFrame("[✓1]", editor);
                            this.removeTextFrame("[✓2]", editor);
                            this.removeTextFrame("[✓3]", editor);
                            this.removeTextFrame("[✓5]", editor);
                            this.removeTextFrame("[✓6]", editor);
                        }
                        else if (optVertretenDurch.Trim().ToLower().Equals("GeschäftsführerOhneAuftrag".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓5]", "X", editor);
                            this.removeTextFrame("[✓1]", editor);
                            this.removeTextFrame("[✓2]", editor);
                            this.removeTextFrame("[✓3]", editor);
                            this.removeTextFrame("[✓4]", editor);
                            this.removeTextFrame("[✓6]", editor);
                        }
                        else if (optVertretenDurch.Trim().ToLower().Equals("Eigenberechtigt".Trim().ToLower()))
                        {
                            this.setTextFrame("[✓6]", "X", editor);
                            this.removeTextFrame("[✓1]", editor);
                            this.removeTextFrame("[✓2]", editor);
                            this.removeTextFrame("[✓3]", editor);
                            this.removeTextFrame("[✓4]", editor);
                            this.removeTextFrame("[✓5]", editor);
                        }
                        else
                        {
                            throw new Exception("openDocument: optVertretenDurch '" + optVertretenDurch.Trim() + "' not allowed!");
                        }

                        byte[] txtOrigIntFormat = null;
                        editor.Save(out txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);

                        QS2.Desktop.Txteditor.doEditor doEditor1 = new QS2.Desktop.Txteditor.doEditor();
                        QS2.Desktop.Txteditor.frmTxtEditor frmEditor = new QS2.Desktop.Txteditor.frmTxtEditor();
                        frmEditor.fFelderEinAus = false;
                        frmEditor.ContTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all;
                        frmEditor.ContTxtEditor1.LinealeOnOff(false);
                        frmEditor.ContTxtEditor1.textControl1.EditMode = TXTextControl.EditMode.Edit;
                        frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                        frmEditor.ContTxtEditor1.textControl1.IsSpellCheckingEnabled = false;
                        frmEditor.Show();
                        frmEditor.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Heimvertrag");

                        frmEditor.ContTxtEditor1.textControl1.ViewMode = TXTextControl.ViewMode.PageView;
                        frmEditor.ContTxtEditor1.textControl1.Load(txtOrigIntFormat, TXTextControl.BinaryStreamType.InternalFormat);
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.openPDF:" + ex.ToString());
            }
        }

        public void setTextFrame(string sKey, string Txt, TXTextControl.ServerTextControl editor)
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
                    txtFrame.BorderWidth = 0;
                    txtFrame.Transparency = 100;
                }

                if (!bFrameFound)
                {
                    //throw new Exception("setTextFrame: Frame '" + sKey.Trim() + "' not found in Document '" + Document.Trim() + "'!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.setTextFrame:" + ex.ToString());
            }
        }
        public void removeTextFrame(string sKey, TXTextControl.ServerTextControl editor)
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
                    //throw new Exception("removeTextFrame: Frame '" + sKey.Trim() + "' not found in Document '" + Document.Trim() + "'!");
                }

                if (txtFrameFound != null)
                {
                    //txtFrameFound.BorderWidth = 0;
                    //txtFrameFound.Transparency = 100;
                    editor.TextFrames.Remove(txtFrameFound);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("cHeimverträge.removeTextFrame:" + ex.ToString());
            }
        }
    }

}
