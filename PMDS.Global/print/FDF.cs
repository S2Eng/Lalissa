using Patagames.Pdf.Net;
using PMDS.BusinessLogic;
using PMDS.GUI.BaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMDS.Global.print
{
    public class FDF
    {
        public bool _ShowBookmarks = true;
        public bool _ShowOpenFileDialog = false;
        public bool _ShowPrintDialog = true;


        public struct FreeFields
        {
            public string FieldName;
            public string FieldValue;
        };

        public List<FreeFields> lstFreeFields = new List<FreeFields>();

        public void SetAllFDFFields(Guid? IDAufenthalt, PdfForms form)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    frmPDF frmPDF = new frmPDF();
                    Guid IDPatient = Guid.Empty;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                    PMDS.db.Entities.Patient p = new PMDS.db.Entities.Patient();
                    PMDS.db.Entities.Aufenthalt a = new PMDS.db.Entities.Aufenthalt();
                    PMDS.db.Entities.Adresse adr = new PMDS.db.Entities.Adresse();
                    PMDS.db.Entities.Klinik kli = new PMDS.db.Entities.Klinik();
                    PMDS.db.Entities.Abteilung abt = new PMDS.db.Entities.Abteilung();
                    PMDS.db.Entities.Bereich ber = new PMDS.db.Entities.Bereich();

                    if (IDAufenthalt == null)
                    {
                        IDPatient = ENV.CurrentIDPatient;
                    }
                    else
                    {
                        a = PMDSBusiness1.getAufenthalt((Guid)IDAufenthalt, db);
                        IDPatient = (Guid)a.IDPatient;
                    }

                    p = PMDSBusiness1.getPatient(IDPatient, db);
                    Patient pat = new Patient(IDPatient);
                    a = PMDSBusiness1.getAufenthalt(pat.Aufenthalt.ID, db);

                    if (pat.Vorname != null) frmPDF.SetValue("#KLIENTVORNAME#", pat.Vorname, form);
                    if (p.Nachname != null) frmPDF.SetValue("#KLIENTNACHNAME#", p.Nachname, form);
                    if ((p.Vorname != null) && (p.Nachname != null)) frmPDF.SetValue("#KLIENT#", p.Nachname + " " + p.Vorname, form);
                    if (p.Anrede != null) frmPDF.SetValue("#KLIENTANREDE#", p.Anrede, form);

                    if (p.Geburtsdatum != null) frmPDF.SetValue("#KLIENTGEBDAT#", System.Convert.ToDateTime(p.Geburtsdatum).ToShortDateString(), form);
                    if (p.SterbeDatum != null) frmPDF.SetValue("#KLIENTSTERBEDATUM#", System.Convert.ToDateTime(p.SterbeDatum).ToShortDateString(), form);
                    frmPDF.SetValue("#KLIENTVERSTORBEN#", (p.Verstorben == true) ? "J" : "N", form);
                    if (p.Klientennummer != null) frmPDF.SetValue("#KLIENTNUMMER#", p.Klientennummer, form);
                    if (p.Titel != null) frmPDF.SetValue("#KLIENTTITEL#", p.Titel, form);
                    if (p.Kosename != null) frmPDF.SetValue("#KLIENTKOSENAME#", p.Kosename, form);

                    if (p.Sexus != null) frmPDF.SetValue("#KLIENTGESCHLECHT#", p.Sexus, form);
                    if (p.Familienstand != null) frmPDF.SetValue("#KLIENTFAMILIENSTAND#", p.Familienstand, form);
                    if (p.Staatsb != null) frmPDF.SetValue("#KLIENTSTAATSBUERGERSCHAFT#", p.Staatsb, form);
                    if (p.Klasse != null) frmPDF.SetValue("#KLIENTVERSICHERUNGKLASSE#", p.Klasse, form);
                    if (p.KrankenKasse != null) frmPDF.SetValue("#KLIENTKRANKENKASSE#", p.KrankenKasse, form);
                    if (p.BlutGruppe != null) frmPDF.SetValue("#KLIENTBLUTGRUPPE#", p.BlutGruppe, form);
                    if (p.Resusfaktor != null) frmPDF.SetValue("#KLIENTRHESUSFAKTOR#", p.Resusfaktor, form);
                    if (p.LedigerName != null) frmPDF.SetValue("#KLIENTLEDIGERNAME#", p.LedigerName, form);
                    if (p.Geburtsort != null) frmPDF.SetValue("#KLIENTGEBORT#", p.Geburtsort, form);
                    if (p.VersicherungsNr != null) frmPDF.SetValue("#KLIENTSVNR#", p.VersicherungsNr, form);
                    if (p.Privatversicherung != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNG#", p.Privatversicherung, form);
                    if (p.PrivPolNr != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNGPOLNR#", p.PrivPolNr, form);

                    if (p.ErlernterBeruf != null) frmPDF.SetValue("#KLIENTERLERNTERBERUF#", p.ErlernterBeruf, form);
                    if (p.Besonderheit != null) frmPDF.SetValue("#KLIENTBESONDERHEIT#", p.Besonderheit, form);
                    if (p.SterbeRegel != null) frmPDF.SetValue("#KLIENTSTERBEREGELUNG#", p.SterbeRegel, form);
                    frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAG#", (p.PflegegeldantragJN == true) ? "J" : "N", form);
                    if (p.DatumPflegegeldantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPflegegeldantrag).ToShortDateString(), form);
                    frmPDF.SetValue("#KLIENTPENSIONSTEILUNGSANTRAG#", (p.PensionsteilungsantragJN == true) ? "J" : "N", form);
                    if (p.DatumPensionsteilungsantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPensionsteilungsantrag).ToShortDateString(), form);
                    if (p.Konfision != null) frmPDF.SetValue("#KLIENTKONFESSION#", p.Konfision, form);
                    frmPDF.SetValue("#KLIENTANATOMIE#", (p.Anatomie == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTDNR#", (p.DNR == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTPALLIATIV#", (p.Palliativ == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTHOLOCAUST#", (p.KZUeberlebender == true) ? "J" : "N", form);
                    if (p.PatientenverfuegungJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNG#", (p.PatientenverfuegungJN == true) ? "J" : "N", form);
                    if (p.PatientenverfuegungBeachtlichJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGBEACHTLICH#", (p.PatientenverfuegungBeachtlichJN == true) ? "J" : "N", form);
                    if (p.PatientverfuegungDatum != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGDATUM#", System.Convert.ToDateTime(p.PatientverfuegungDatum).ToShortDateString(), form);
                    if (p.PatientverfuegungAnmerkung != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGANMERKUNG#", p.PatientverfuegungAnmerkung, form);

                    frmPDF.SetValue("#KLIENTMILIEUBETREUUNG#", (p.Milieubetreuung == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTDATENSCHUTZ#", (p.Datenschutz == true) ? "J" : "N", form);
                    if (p.lstSprachen != null) frmPDF.SetValue("#KLIENTSPRACHEN#", p.lstSprachen, form);

                    if (p.Haarfarbe != null) frmPDF.SetValue("#KLIENTHAARFARBE#", p.Haarfarbe, form);
                    if (p.Augenfarbe != null) frmPDF.SetValue("#KLIENTAUGENFARBE#", p.Augenfarbe, form);
                    if (p.Groesse != null) frmPDF.SetValue("#KLIENTGROESSE#", p.Groesse.ToString(), form);
                    if (p.Statur != null) frmPDF.SetValue("#KLIENTSTATUR#", p.Statur.ToString(), form);

                    frmPDF.SetValue("#KLIENTAMPUTATIONPROZENT#", p.Amputation_Prozent.ToString(), form);
                    if (p.Kennwort != null) frmPDF.SetValue("#KLIENTKENNWORT#", p.Kennwort, form);

                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNG#", (p.RezeptgebuehrbefreiungJN == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGO#", (p.RezGebBef_RegoJN == true) ? "J" : "N", form);
                    if (p.RezGebBef_RegoAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOAB#", System.Convert.ToDateTime(p.RezGebBef_RegoAb).ToShortDateString(), form);
                    if (p.RezGebBef_RegoBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOBIS#", System.Convert.ToDateTime(p.RezGebBef_RegoBis).ToShortDateString(), form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTET#", (p.RezGebBef_BefristetJN == true) ? "J" : "N", form);
                    if (p.RezGebBef_BefristetAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETAB#", System.Convert.ToDateTime(p.RezGebBef_BefristetAb).ToShortDateString(), form);
                    if (p.RezGebBef_BefristetBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETBIS#", System.Convert.ToDateTime(p.RezGebBef_BefristetBis).ToShortDateString(), form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGUNBEFRISTET#", (p.RezGebBef_UnbefristetJN == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUF#", (p.RezGebBef_WiderrufJN == true) ? "J" : "N", form);
                    if (p.RezGebBef_WiderrufGrund != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUFGRUND#", p.RezGebBef_WiderrufGrund, form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGSACHWALTER#", (p.RezGebBef_SachwalterJN == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGANMERKUNG#", p.RezGebBef_Anmerkung, form);

                    if (p.Betreuungsstufe != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFE#", p.Betreuungsstufe, form);
                    if (p.BetreuungsstufeAb != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEAB#", System.Convert.ToDateTime(p.BetreuungsstufeAb).ToShortDateString(), form);
                    if (p.BetreuungsstufeBis != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEBIS#", System.Convert.ToDateTime(p.BetreuungsstufeBis).ToShortDateString(), form);
                    frmPDF.SetValue("#KLIENTSOZIALCARD#", (p.Sozialcard == true) ? "J" : "N", form);
                    frmPDF.SetValue("#KLIENTBEHINDERTENAUSWEIS#", (p.Behindertenausweis == true) ? "J" : "N", form);

                    frmPDF.SetValue("#KLIENTWOHNUNGABGEMELDET#", (pat.WohnungAbgemeldetJN == true) ? "J" : "N", form);

                    kli = PMDSBusiness1.getKlinik(pat.Aufenthalt.IDKlinik != null ? pat.Aufenthalt.IDKlinik : Guid.Empty, db);
                    if (!pat.WohnungAbgemeldetJN)
                    {
                        adr = PMDSBusiness1.getAdresse2(pat.Adresse.ID != null ? pat.IDAdresse : Guid.Empty, db);
                    }
                    else
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                    }
                    if (adr.Strasse != null) frmPDF.SetValue("#KLIENTADRESSESTRASSE#", adr.Strasse, form);
                    if (adr.Plz != null) frmPDF.SetValue("#KLIENTADRESSEPLZ#", adr.Plz, form);
                    if (adr.Ort != null) frmPDF.SetValue("#KLIENTADRESSEORT#", adr.Ort, form);
                    if (adr.LandKZ != null) frmPDF.SetValue("#KLIENTADRESSELAND#", adr.LandKZ, form);

                    if (pat.Aufenthalt.ID != null)
                    {
                        if (a.Aufnahmezeitpunkt != null) frmPDF.SetValue("#AUFENTHALTAUFNAHMEDATUM#", Convert.ToDateTime(a.Aufnahmezeitpunkt).ToShortDateString(), form);
                        if (a.Fallnummer != null) frmPDF.SetValue("#AUFENTHALTFALLNUMMER#", a.Fallnummer.ToString(), form);
                        if (a.Gruppenkennzahl != null) frmPDF.SetValue("#AUFENTHALTGRUPPENKENNZAHL#", a.Gruppenkennzahl, form);
                        if (a.Postregelung != null) frmPDF.SetValue("#AUFENTHALTPOSTREGELUNG#", a.Postregelung, form);
                    }

                    if (pat.Aufenthalt.IDKlinik != null)
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                        if (adr.Strasse != null) frmPDF.SetValue("#EINRICHTUNGADRESSESTRASSE#", adr.Strasse, form);
                        if (adr.Plz != null) frmPDF.SetValue("#EINRICHTUNGADRESSEPLZ#", adr.Plz, form);
                        if (adr.Ort != null) frmPDF.SetValue("#EINRICHTUNGADRESSEORT#", adr.Ort, form);
                        if (adr.LandKZ != null) frmPDF.SetValue("#EINRICHTUNGADRESSELAND#", adr.LandKZ, form);

                        if (kli.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTEINRICHTUNG#", kli.Bezeichnung, form);
                        if (kli.Bezeichnung != null) frmPDF.SetValue("#EINRICHTUNGNAME#", kli.Bezeichnung, form);
                    }

                    if (pat.Aufenthalt.IDAbteilung != null)
                    {
                        abt = PMDSBusiness1.getAbteilung(pat.Aufenthalt.IDAbteilung, db);
                        if (abt.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTABTEILUNG#", abt.Bezeichnung, form);
                    }

                    if (pat.Aufenthalt.IDBereich != null)
                    {
                        ber = PMDSBusiness1.getBereich(pat.Aufenthalt.IDBereich, db);
                        if (ber.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTBEREICH#", ber.Bezeichnung, form);
                    }

                    //Zusätzliche freie Felder füllen
                    foreach (FreeFields f in lstFreeFields)
                    {
                        frmPDF.SetValue(f.FieldName, f.FieldValue, form);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in FDF.SetAllFDFFields:" + ex.ToString());
            }
        }

        public void Print(string ReportFile, Guid? IDAufenthalt)
        {
            PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
            byte[] bPDF;
            if (frmPDF.OpenPDF(ReportFile, out bPDF))
            {
                frmPDF.SetCaption = System.IO.Path.GetFileNameWithoutExtension(ReportFile);
                frmPDF.ShowBookmarks = _ShowBookmarks;
                frmPDF.ShowOpenDialog = _ShowOpenFileDialog;
                frmPDF.ShowPrintDialog = _ShowPrintDialog;


                //using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                //{
                //    Guid IDPatient = Guid.Empty;
                //    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                //    PMDS.db.Entities.Patient p = new PMDS.db.Entities.Patient();
                //    PMDS.db.Entities.Aufenthalt a = new PMDS.db.Entities.Aufenthalt();
                //    PMDS.db.Entities.Adresse adr = new PMDS.db.Entities.Adresse();
                //    PMDS.db.Entities.Klinik kli = new PMDS.db.Entities.Klinik();
                //    PMDS.db.Entities.Abteilung abt = new PMDS.db.Entities.Abteilung();
                //    PMDS.db.Entities.Bereich ber = new PMDS.db.Entities.Bereich();

                //    if (IDAufenthalt == null)
                //    {
                //        IDPatient = ENV.CurrentIDPatient;
                //    }
                //    else
                //    {
                //        a = PMDSBusiness1.getAufenthalt((Guid)IDAufenthalt, db);
                //        IDPatient = (Guid)a.IDPatient;
                //    }

                //    p = PMDSBusiness1.getPatient(IDPatient, db);
                //    Patient pat = new Patient(IDPatient);
                //    a = PMDSBusiness1.getAufenthalt(pat.Aufenthalt.ID, db);

                //    if (pat.Vorname != null) frmPDF.SetValue("#KLIENTVORNAME#", pat.Vorname, frmPDF.form);
                //    if (p.Nachname != null) frmPDF.SetValue("#KLIENTNACHNAME#", p.Nachname, frmPDF.form);
                //    if ((p.Vorname != null) && (p.Nachname != null)) frmPDF.SetValue("#KLIENT#", p.Nachname + " " + p.Vorname, frmPDF.form);
                //    if (p.Anrede != null) frmPDF.SetValue("#KLIENTANREDE#", p.Anrede, frmPDF.form);

                //    if (p.Geburtsdatum != null) frmPDF.SetValue("#KLIENTGEBDAT#", System.Convert.ToDateTime(p.Geburtsdatum).ToShortDateString(), frmPDF.form);
                //    if (p.SterbeDatum != null) frmPDF.SetValue("#KLIENTSTERBEDATUM#", System.Convert.ToDateTime(p.SterbeDatum).ToShortDateString(), frmPDF.form);
                //    frmPDF.SetValue("#KLIENTVERSTORBEN#", (p.Verstorben == true) ? "J" : "N", frmPDF.form);
                //    if (p.Klientennummer != null) frmPDF.SetValue("#KLIENTNUMMER#", p.Klientennummer, frmPDF.form);
                //    if (p.Titel != null) frmPDF.SetValue("#KLIENTTITEL#", p.Titel, frmPDF.form);
                //    if (p.Kosename != null) frmPDF.SetValue("#KLIENTKOSENAME#", p.Kosename, frmPDF.form);

                //    if (p.Sexus != null) frmPDF.SetValue("#KLIENTGESCHLECHT#", p.Sexus, frmPDF.form);
                //    if (p.Familienstand != null) frmPDF.SetValue("#KLIENTFAMILIENSTAND#", p.Familienstand, frmPDF.form);
                //    if (p.Staatsb != null) frmPDF.SetValue("#KLIENTSTAATSBUERGERSCHAFT#", p.Staatsb, frmPDF.form);
                //    if (p.Klasse != null) frmPDF.SetValue("#KLIENTVERSICHERUNGKLASSE#", p.Klasse, frmPDF.form);
                //    if (p.KrankenKasse != null) frmPDF.SetValue("#KLIENTKRANKENKASSE#", p.KrankenKasse, frmPDF.form);
                //    if (p.BlutGruppe != null) frmPDF.SetValue("#KLIENTBLUTGRUPPE#", p.BlutGruppe, frmPDF.form);
                //    if (p.Resusfaktor != null) frmPDF.SetValue("#KLIENTRHESUSFAKTOR#", p.Resusfaktor, frmPDF.form);
                //    if (p.LedigerName != null) frmPDF.SetValue("#KLIENTLEDIGERNAME#", p.LedigerName, frmPDF.form);
                //    if (p.Geburtsort != null) frmPDF.SetValue("#KLIENTGEBORT#", p.Geburtsort, frmPDF.form);
                //    if (p.VersicherungsNr != null) frmPDF.SetValue("#KLIENTSVNR#", p.VersicherungsNr, frmPDF.form);
                //    if (p.Privatversicherung != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNG#", p.Privatversicherung, frmPDF.form);
                //    if (p.PrivPolNr != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNGPOLNR#", p.PrivPolNr, frmPDF.form);

                //    if (p.ErlernterBeruf != null) frmPDF.SetValue("#KLIENTERLERNTERBERUF#", p.ErlernterBeruf, frmPDF.form);
                //    if (p.Besonderheit != null) frmPDF.SetValue("#KLIENTBESONDERHEIT#", p.Besonderheit, frmPDF.form);
                //    if (p.SterbeRegel != null) frmPDF.SetValue("#KLIENTSTERBEREGELUNG#", p.SterbeRegel, frmPDF.form);
                //    frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAG#", (p.PflegegeldantragJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.DatumPflegegeldantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPflegegeldantrag).ToShortDateString(), frmPDF.form);
                //    frmPDF.SetValue("#KLIENTPENSIONSTEILUNGSANTRAG#", (p.PensionsteilungsantragJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.DatumPensionsteilungsantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPensionsteilungsantrag).ToShortDateString(), frmPDF.form);
                //    if (p.Konfision != null) frmPDF.SetValue("#KLIENTKONFESSION#", p.Konfision, frmPDF.form);
                //    frmPDF.SetValue("#KLIENTANATOMIE#", (p.Anatomie == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTDNR#", (p.DNR == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTPALLIATIV#", (p.Palliativ == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTHOLOCAUST#", (p.KZUeberlebender == true) ? "J" : "N", frmPDF.form);
                //    if (p.PatientenverfuegungJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNG#", (p.PatientenverfuegungJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.PatientenverfuegungBeachtlichJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGBEACHTLICH#", (p.PatientenverfuegungBeachtlichJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.PatientverfuegungDatum != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGDATUM#", System.Convert.ToDateTime(p.PatientverfuegungDatum).ToShortDateString(), frmPDF.form);
                //    if (p.PatientverfuegungAnmerkung != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGANMERKUNG#", p.PatientverfuegungAnmerkung, frmPDF.form);

                //    frmPDF.SetValue("#KLIENTMILIEUBETREUUNG#", (p.Milieubetreuung == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTDATENSCHUTZ#", (p.Datenschutz == true) ? "J" : "N", frmPDF.form);
                //    if (p.lstSprachen != null) frmPDF.SetValue("#KLIENTSPRACHEN#", p.lstSprachen, frmPDF.form);

                //    if (p.Haarfarbe != null) frmPDF.SetValue("#KLIENTHAARFARBE#", p.Haarfarbe, frmPDF.form);
                //    if (p.Augenfarbe != null) frmPDF.SetValue("#KLIENTAUGENFARBE#", p.Augenfarbe, frmPDF.form);
                //    if (p.Groesse != null) frmPDF.SetValue("#KLIENTGROESSE#", p.Groesse.ToString(), frmPDF.form);
                //    if (p.Statur != null) frmPDF.SetValue("#KLIENTSTATUR#", p.Statur.ToString(), frmPDF.form);

                //    frmPDF.SetValue("#KLIENTAMPUTATIONPROZENT#", p.Amputation_Prozent.ToString(), frmPDF.form);
                //    if (p.Kennwort != null) frmPDF.SetValue("#KLIENTKENNWORT#", p.Kennwort, frmPDF.form);

                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNG#", (p.RezeptgebuehrbefreiungJN == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGO#", (p.RezGebBef_RegoJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.RezGebBef_RegoAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOAB#", System.Convert.ToDateTime(p.RezGebBef_RegoAb).ToShortDateString(), frmPDF.form);
                //    if (p.RezGebBef_RegoBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOBIS#", System.Convert.ToDateTime(p.RezGebBef_RegoBis).ToShortDateString(), frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTET#", (p.RezGebBef_BefristetJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.RezGebBef_BefristetAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETAB#", System.Convert.ToDateTime(p.RezGebBef_BefristetAb).ToShortDateString(), frmPDF.form);
                //    if (p.RezGebBef_BefristetBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETBIS#", System.Convert.ToDateTime(p.RezGebBef_BefristetBis).ToShortDateString(), frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGUNBEFRISTET#", (p.RezGebBef_UnbefristetJN == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUF#", (p.RezGebBef_WiderrufJN == true) ? "J" : "N", frmPDF.form);
                //    if (p.RezGebBef_WiderrufGrund != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUFGRUND#", p.RezGebBef_WiderrufGrund, frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGSACHWALTER#", (p.RezGebBef_SachwalterJN == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGANMERKUNG#", p.RezGebBef_Anmerkung, frmPDF.form);

                //    if (p.Betreuungsstufe != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFE#", p.Betreuungsstufe, frmPDF.form);
                //    if (p.BetreuungsstufeAb != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEAB#", System.Convert.ToDateTime(p.BetreuungsstufeAb).ToShortDateString(), frmPDF.form);
                //    if (p.BetreuungsstufeBis != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEBIS#", System.Convert.ToDateTime(p.BetreuungsstufeBis).ToShortDateString(), frmPDF.form);
                //    frmPDF.SetValue("#KLIENTSOZIALCARD#", (p.Sozialcard == true) ? "J" : "N", frmPDF.form);
                //    frmPDF.SetValue("#KLIENTBEHINDERTENAUSWEIS#", (p.Behindertenausweis == true) ? "J" : "N", frmPDF.form);

                //    frmPDF.SetValue("#KLIENTWOHNUNGABGEMELDET#", (pat.WohnungAbgemeldetJN == true) ? "J" : "N", frmPDF.form);

                //    kli = PMDSBusiness1.getKlinik(pat.Aufenthalt.IDKlinik != null ? pat.Aufenthalt.IDKlinik : Guid.Empty, db);
                //    if (!pat.WohnungAbgemeldetJN)
                //    {
                //        adr = PMDSBusiness1.getAdresse2(pat.Adresse.ID != null ? pat.IDAdresse : Guid.Empty, db);
                //    }                        
                //    else
                //    {
                //        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                //    }
                //    if (adr.Strasse != null) frmPDF.SetValue("#KLIENTADRESSESTRASSE#", adr.Strasse, frmPDF.form);
                //    if (adr.Plz != null) frmPDF.SetValue("#KLIENTADRESSEPLZ#", adr.Plz, frmPDF.form);
                //    if (adr.Ort != null) frmPDF.SetValue("#KLIENTADRESSEORT#", adr.Ort, frmPDF.form);
                //    if (adr.LandKZ != null) frmPDF.SetValue("#KLIENTADRESSELAND#", adr.LandKZ, frmPDF.form);

                //    if (pat.Aufenthalt.ID != null)
                //    {
                //        if (a.Aufnahmezeitpunkt != null) frmPDF.SetValue("#AUFENTHALTAUFNAHMEDATUM#", Convert.ToDateTime(a.Aufnahmezeitpunkt).ToShortDateString(), frmPDF.form);
                //        if (a.Fallnummer != null) frmPDF.SetValue("#AUFENTHALTFALLNUMMER#", a.Fallnummer.ToString(), frmPDF.form);
                //        if (a.Gruppenkennzahl != null) frmPDF.SetValue("#AUFENTHALTGRUPPENKENNZAHL#", a.Gruppenkennzahl, frmPDF.form);
                //        if (a.Postregelung != null) frmPDF.SetValue("#AUFENTHALTPOSTREGELUNG#", a.Postregelung, frmPDF.form);
                //    }

                //    if (pat.Aufenthalt.IDKlinik != null)
                //    {
                //        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                //        if (adr.Strasse != null) frmPDF.SetValue("#EINRICHTUNGADRESSESTRASSE#", adr.Strasse, frmPDF.form);
                //        if (adr.Plz != null) frmPDF.SetValue("#EINRICHTUNGADRESSEPLZ#", adr.Plz, frmPDF.form);
                //        if (adr.Ort != null) frmPDF.SetValue("#EINRICHTUNGADRESSEORT#", adr.Ort, frmPDF.form);
                //        if (adr.LandKZ != null) frmPDF.SetValue("#EINRICHTUNGADRESSELAND#", adr.LandKZ, frmPDF.form);
                            
                //        if (kli.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTEINRICHTUNG#", kli.Bezeichnung, frmPDF.form);
                //        if (kli.Bezeichnung != null) frmPDF.SetValue("#EINRICHTUNGNAME#", kli.Bezeichnung, frmPDF.form);
                //    }

                //    if (pat.Aufenthalt.IDAbteilung != null)
                //    {
                //        abt = PMDSBusiness1.getAbteilung(pat.Aufenthalt.IDAbteilung, db);
                //        if (abt.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTABTEILUNG#", abt.Bezeichnung, frmPDF.form);
                //    }

                //    if (pat.Aufenthalt.IDBereich != null)
                //    {
                //        ber = PMDSBusiness1.getBereich(pat.Aufenthalt.IDBereich, db);
                //        if (ber.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTBEREICH#", ber.Bezeichnung, frmPDF.form);
                //    }

                //    //Zusätzliche freie Felder füllen
                //    foreach (FreeFields f in lstFreeFields)
                //    {
                //        frmPDF.SetValue(f.FieldName, f.FieldValue, frmPDF.form);
                //    }
                //}
                
                frmPDF.Show();
            }
            else
            {
                MessageBox.Show(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei nicht gefunden."));
            }
        }
    }
}
