using PMDS.BusinessLogic;
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

                Guid IDPatient = Guid.Empty;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
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

                    if (pat.Vorname != null) frmPDF.SetValue("#KLIENTVORNAME#", pat.Vorname);
                    if (p.Nachname != null) frmPDF.SetValue("#KLIENTNACHNAME#", p.Nachname);
                    if ((p.Vorname != null) && (p.Nachname != null)) frmPDF.SetValue("#KLIENT#", p.Nachname + " " + p.Vorname);
                    if (p.Anrede != null) frmPDF.SetValue("#KLIENTANREDE#", p.Anrede);

                    if (p.Geburtsdatum != null) frmPDF.SetValue("#KLIENTGEBDAT#", System.Convert.ToDateTime(p.Geburtsdatum).ToShortDateString());
                    if (p.SterbeDatum != null) frmPDF.SetValue("#KLIENTSTERBEDATUM#", System.Convert.ToDateTime(p.SterbeDatum).ToShortDateString());
                    frmPDF.SetValue("#KLIENTVERSTORBEN#", (p.Verstorben == true) ? "J" : "N");
                    if (p.Klientennummer != null) frmPDF.SetValue("#KLIENTNUMMER#", p.Klientennummer);
                    if (p.Titel != null) frmPDF.SetValue("#KLIENTTITEL#", p.Titel);
                    if (p.Kosename != null) frmPDF.SetValue("#KLIENTKOSENAME#", p.Kosename);

                    if (p.Sexus != null) frmPDF.SetValue("#KLIENTGESCHLECHT#", p.Sexus);
                    if (p.Familienstand != null) frmPDF.SetValue("#KLIENTFAMILIENSTAND#", p.Familienstand);
                    if (p.Staatsb != null) frmPDF.SetValue("#KLIENTSTAATSBUERGERSCHAFT#", p.Staatsb);
                    if (p.Klasse != null) frmPDF.SetValue("#KLIENTVERSICHERUNGKLASSE#", p.Klasse);
                    if (p.KrankenKasse != null) frmPDF.SetValue("#KLIENTKRANKENKASSE#", p.KrankenKasse);
                    if (p.BlutGruppe != null) frmPDF.SetValue("#KLIENTBLUTGRUPPE#", p.BlutGruppe);
                    if (p.Resusfaktor != null) frmPDF.SetValue("#KLIENTRHESUSFAKTOR#", p.Resusfaktor);
                    if (p.LedigerName != null) frmPDF.SetValue("#KLIENTLEDIGERNAME#", p.LedigerName);
                    if (p.Geburtsort != null) frmPDF.SetValue("#KLIENTGEBORT#", p.Geburtsort);
                    if (p.VersicherungsNr != null) frmPDF.SetValue("#KLIENTSVNR#", p.VersicherungsNr);
                    if (p.Privatversicherung != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNG#", p.Privatversicherung);
                    if (p.PrivPolNr != null) frmPDF.SetValue("#KLIENTPRIVATVERSICHERUNGPOLNR#", p.PrivPolNr);

                    if (p.ErlernterBeruf != null) frmPDF.SetValue("#KLIENTERLERNTERBERUF#", p.ErlernterBeruf);
                    if (p.Besonderheit != null) frmPDF.SetValue("#KLIENTBESONDERHEIT#", p.Besonderheit);
                    if (p.SterbeRegel != null) frmPDF.SetValue("#KLIENTSTERBEREGELUNG#", p.SterbeRegel);
                    frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAG#", (p.PflegegeldantragJN == true) ? "J" : "N");
                    if (p.DatumPflegegeldantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPflegegeldantrag).ToShortDateString());
                    frmPDF.SetValue("#KLIENTPENSIONSTEILUNGSANTRAG#", (p.PensionsteilungsantragJN == true) ? "J" : "N");
                    if (p.DatumPensionsteilungsantrag != null) frmPDF.SetValue("#KLIENTPFLEGEGELDANTRAGDATUM#", System.Convert.ToDateTime(p.DatumPensionsteilungsantrag).ToShortDateString());
                    if (p.Konfision != null) frmPDF.SetValue("#KLIENTKONFESSION#", p.Konfision);
                    frmPDF.SetValue("#KLIENTANATOMIE#", (p.Anatomie == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTDNR#", (p.DNR == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTPALLIATIV#", (p.Palliativ == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTHOLOCAUST#", (p.KZUeberlebender == true) ? "J" : "N");
                    if (p.PatientenverfuegungJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNG#", (p.PatientenverfuegungJN == true) ? "J" : "N");
                    if (p.PatientenverfuegungBeachtlichJN != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGBEACHTLICH#", (p.PatientenverfuegungBeachtlichJN == true) ? "J" : "N");
                    if (p.PatientverfuegungDatum != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGDATUM#", System.Convert.ToDateTime(p.PatientverfuegungDatum).ToShortDateString());
                    if (p.PatientverfuegungAnmerkung != null) frmPDF.SetValue("#KLIENTPATIENTENVERFÜGUNGANMERKUNG#", p.PatientverfuegungAnmerkung);

                    frmPDF.SetValue("#KLIENTMILIEUBETREUUNG#", (p.Milieubetreuung == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTDATENSCHUTZ#", (p.Datenschutz == true) ? "J" : "N");
                    if (p.lstSprachen != null) frmPDF.SetValue("#KLIENTSPRACHEN#", p.lstSprachen);

                    if (p.Haarfarbe != null) frmPDF.SetValue("#KLIENTHAARFARBE#", p.Haarfarbe);
                    if (p.Augenfarbe != null) frmPDF.SetValue("#KLIENTAUGENFARBE#", p.Augenfarbe);
                    if (p.Groesse != null) frmPDF.SetValue("#KLIENTGROESSE#", p.Groesse.ToString());
                    if (p.Statur != null) frmPDF.SetValue("#KLIENTSTATUR#", p.Statur.ToString());

                    frmPDF.SetValue("#KLIENTAMPUTATIONPROZENT#", p.Amputation_Prozent.ToString());
                    if (p.Kennwort != null) frmPDF.SetValue("#KLIENTKENNWORT#", p.Kennwort);

                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNG#", (p.RezeptgebuehrbefreiungJN == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGO#", (p.RezGebBef_RegoJN == true) ? "J" : "N");
                    if (p.RezGebBef_RegoAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOAB#", System.Convert.ToDateTime(p.RezGebBef_RegoAb).ToShortDateString());
                    if (p.RezGebBef_RegoBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGREGOBIS#", System.Convert.ToDateTime(p.RezGebBef_RegoBis).ToShortDateString());
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTET#", (p.RezGebBef_BefristetJN == true) ? "J" : "N");
                    if (p.RezGebBef_BefristetAb != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETAB#", System.Convert.ToDateTime(p.RezGebBef_BefristetAb).ToShortDateString());
                    if (p.RezGebBef_BefristetBis != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGBEFRISTETBIS#", System.Convert.ToDateTime(p.RezGebBef_BefristetBis).ToShortDateString());
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGUNBEFRISTET#", (p.RezGebBef_UnbefristetJN == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUF#", (p.RezGebBef_WiderrufJN == true) ? "J" : "N");
                    if (p.RezGebBef_WiderrufGrund != null) frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGWIDERRUFGRUND#", p.RezGebBef_WiderrufGrund);
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGSACHWALTER#", (p.RezGebBef_SachwalterJN == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTREZEPTGEBUEHRENBEFREIUNGANMERKUNG#", p.RezGebBef_Anmerkung);

                    if (p.Betreuungsstufe != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFE#", p.Betreuungsstufe);
                    if (p.BetreuungsstufeAb != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEAB#", System.Convert.ToDateTime(p.BetreuungsstufeAb).ToShortDateString());
                    if (p.BetreuungsstufeBis != null) frmPDF.SetValue("#KLIENTBETREUUNGSSTUFEBIS#", System.Convert.ToDateTime(p.BetreuungsstufeBis).ToShortDateString());
                    frmPDF.SetValue("#KLIENTSOZIALCARD#", (p.Sozialcard == true) ? "J" : "N");
                    frmPDF.SetValue("#KLIENTBEHINDERTENAUSWEIS#", (p.Behindertenausweis == true) ? "J" : "N");

                    frmPDF.SetValue("#KLIENTWOHNUNGABGEMELDET#", (pat.WohnungAbgemeldetJN == true) ? "J" : "N");

                    kli = PMDSBusiness1.getKlinik(pat.Aufenthalt.IDKlinik != null ? pat.Aufenthalt.IDKlinik : Guid.Empty, db);
                    if (!pat.WohnungAbgemeldetJN)
                    {
                        adr = PMDSBusiness1.getAdresse2(pat.Adresse.ID != null ? pat.IDAdresse : Guid.Empty, db);
                    }                        
                    else
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                    }
                    if (adr.Strasse != null) frmPDF.SetValue("#KLIENTADRESSESTRASSE#", adr.Strasse);
                    if (adr.Plz != null) frmPDF.SetValue("#KLIENTADRESSEPLZ#", adr.Plz);
                    if (adr.Ort != null) frmPDF.SetValue("#KLIENTADRESSEORT#", adr.Ort);
                    if (adr.LandKZ != null) frmPDF.SetValue("#KLIENTADRESSELAND#", adr.LandKZ);

                    if (pat.Aufenthalt.ID != null)
                    {
                        if (a.Aufnahmezeitpunkt != null) frmPDF.SetValue("#AUFENTHALTAUFNAHMEDATUM#", Convert.ToDateTime(a.Aufnahmezeitpunkt).ToShortDateString());
                        if (a.Fallnummer != null) frmPDF.SetValue("#AUFENTHALTFALLNUMMER#", a.Fallnummer.ToString());
                        if (a.Gruppenkennzahl != null) frmPDF.SetValue("#AUFENTHALTGRUPPENKENNZAHL#", a.Gruppenkennzahl);
                        if (a.Postregelung != null) frmPDF.SetValue("#AUFENTHALTPOSTREGELUNG#", a.Postregelung);
                    }

                    if (pat.Aufenthalt.IDKlinik != null)
                    {
                        adr = PMDSBusiness1.getAdresse2(kli.IDAdresse != null ? (Guid)kli.IDAdresse : Guid.Empty, db);
                        if (adr.Strasse != null) frmPDF.SetValue("#EINRICHTUNGADRESSESTRASSE#", adr.Strasse);
                        if (adr.Plz != null) frmPDF.SetValue("#EINRICHTUNGADRESSEPLZ#", adr.Plz);
                        if (adr.Ort != null) frmPDF.SetValue("#EINRICHTUNGADRESSEORT#", adr.Ort);
                        if (adr.LandKZ != null) frmPDF.SetValue("#EINRICHTUNGADRESSELAND#", adr.LandKZ);
                            
                        if (kli.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTEINRICHTUNG#", kli.Bezeichnung);
                        if (kli.Bezeichnung != null) frmPDF.SetValue("#EINRICHTUNGNAME#", kli.Bezeichnung);
                    }

                    if (pat.Aufenthalt.IDAbteilung != null)
                    {
                        abt = PMDSBusiness1.getAbteilung(pat.Aufenthalt.IDAbteilung, db);
                        if (abt.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTABTEILUNG#", abt.Bezeichnung);
                    }

                    if (pat.Aufenthalt.IDBereich != null)
                    {
                        ber = PMDSBusiness1.getBereich(pat.Aufenthalt.IDBereich, db);
                        if (ber.Bezeichnung != null) frmPDF.SetValue("#AUFENTHALTBEREICH#", ber.Bezeichnung);
                    }

                    //Zusätzliche freie Felder füllen
                    foreach (FreeFields f in lstFreeFields)
                    {
                        frmPDF.SetValue(f.FieldName, f.FieldValue);
                    }
                }
                
                frmPDF.Show();
            }
            else
            {
                MessageBox.Show(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei nicht gefunden."));
            }
        }
    }
}
