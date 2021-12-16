using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using PMDS.GUI.Klient;
using PMDS.DB;
using S2Extensions;

namespace PMDS.GUI
{
    public partial class ucRegelungen : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private KlientDetails _klient;
        public event EventHandler ValueChanged;

        private bool _lockValueChanges = false;
        private bool _readOnly = false;
        public ucSiteMapKlientenDetails ucSiteMapKlientenDetailsMain = null;

        private PMDSBusiness b = new PMDSBusiness();





        public ucRegelungen()
        {
            InitializeComponent();
            if (!DesignMode && ENV.AppRunning)
                RefreshValueList();
        }

        private void RefreshValueList()
        {
            UltraGridTools.AddGuidTextValuListFromAuswahlGruppe("UNA", gridUnterbringung, "Anmerkung", false, -100000, false);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Klient setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public KlientDetails Klient
        {
            get
            {
                if (_klient == null)
                    _klient = new KlientDetails();
                return _klient;
            }

            set
            {
                _klient = value;
                UpdateGUI();
                HideOrShowControls();
            }
        }

        //Neu nach 27.04.2007
        //----------------------------------------------------------------------------
        /// <summary>
        /// ReadOnly setzen / auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                SetReadOnly();
            }
        }

        //
        //lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        public void UpdateGUI()
        {
            this._lockValueChanges = true;

            cbpatVerf.Checked               = Klient.PatientenverfuegungJN;
            dtPatVerf.Value                 = Klient.PatientverfuegungDatum;
            this.optBeachtlich.Value        =   (Klient.PatientenverfuegungBeachtlichJN ? true: false);
            txtVerfAnmerkung.Text           = Klient.PatientverfuegungAnmerkung.Trim();
            cbKommunion.Checked             = Klient.KommunionJN;
            cbkrakSalbung.Checked           = Klient.KrankensalbungJN;
            txtReligioneWuen.Text           = Klient.ReligionWunsch;
            txtSterbeRegelung.Text          = Klient.SterbeRegel;
            txtBesRegelung.Text             = Klient.Aufenthalt == null ? "" : Klient.Aufenthalt.Besuchsregelung.Trim();
            cmbPostregel.Text               = Klient.Aufenthalt == null ? "" : Klient.Aufenthalt.Postregelung.Trim();
            txtSonstRegel.Text              = Klient.Aufenthalt == null ? "" : Klient.Aufenthalt.SonstigeRegelung.Trim();
            gridUnterbringung.DataSource    = Klient.UNTERBRINGUNG.ALL ;


            foreach (UltraGridRow rGrid in this.gridUnterbringung.Rows)
            {
                DataRowView v = (DataRowView)rGrid.ListObject;
                dsUnterbringung.UnterbringungRow rUnterb = (dsUnterbringung.UnterbringungRow)v.Row;
                if (!rUnterb.IsEDI_BenutzerNull())
                    rGrid.Cells["EDI_BenutzerGesendet"].Value = b.getUser(rUnterb.EDI_Benutzer).Nachname + " " + b.getUser(rUnterb.EDI_Benutzer).Vorname;
            }

            if (Klient.UNTERBRINGUNG.ALL.Unterbringung.Rows.Count == 0)
            {
                btnDelUnterbringung.Enabled = false;
                btnVerlaeng.Enabled = false;
                btnHistorie.Enabled = false;
                btnPreview.Enabled = false;
                this.btnSendenUnterbringung.Enabled = true;
            }
            else
            {
                btnHistorie.Enabled = true;
                btnPreview.Enabled = true;
                this.btnSendenUnterbringung.Enabled = true;
            }

            this._lockValueChanges = false;
        }

        //
        //Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        public void UpdateDATA()
        {
            Klient.PatientenverfuegungJN            = cbpatVerf.Checked;
            Klient.PatientverfuegungDatum           = dtPatVerf.Value;
            Klient.PatientenverfuegungBeachtlichJN  = (bool)this.optBeachtlich.Value;
            Klient.PatientverfuegungAnmerkung       = txtVerfAnmerkung.Text.Trim();
            Klient.KommunionJN                      = cbKommunion.Checked;
            Klient.KrankensalbungJN                 = cbkrakSalbung.Checked;
            Klient.ReligionWunsch                   = txtReligioneWuen.Text;
            Klient.SterbeRegel                      = txtSterbeRegelung.Text.Trim();
            if(Klient.Aufenthalt != null)
                Klient.Aufenthalt.Besuchsregelung = txtBesRegelung.Text.Trim();

            if(Klient.Aufenthalt != null)
                Klient.Aufenthalt.Postregelung = cmbPostregel.Text.Trim();

            if(Klient.Aufenthalt != null)
                Klient.Aufenthalt.SonstigeRegelung = txtSonstRegel.Text.Trim();


            if (gridUnterbringung.ActiveRow != null)
                btnPreview.Enabled = true;

            EnableDisableButtons();
        }

        //
        //prüft ob alle Eingaben richtig sind.
        public bool ValidateFields()
        {
            return true;
        }

        


        private bool AddUnterbringung()
        {
            try
            {
//                frmUnterbringung2016 frm = new frmUnterbringung2016(Unterbringungsaktion.Beginn, Klient);
                frmUnterbringung frm = new frmUnterbringung(Unterbringungsaktion.Beginn, Klient);
                frm.TypeUIUnterbringung = eTypeUIUnterbringung.AddUnterbringung;
                frm.mainWindow = this;
                //frm.Show();

                frm.Show();

                return true;
            }

            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
        public bool AddUnterbringung_Click(frmUnterbringung frm)
        {
            try
            {
                if (frm.Beginn >= new DateTime(2016, 1, 11, 0, 0, 0))
                {
                    string txt = "Mit diesem Formular können keine freiheitsbeschränkenden Maßnahmen gemeldet werden, die nach dem 11.1.2016 beginnen.";
                    txt += "\n\rBitte warten Sie und erstellen Sie die Meldung am 11.1.2016 noch einmal mit dem neuen Formular.";
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Achtung: Geänderte Meldestruktur ab dem 11.1.2016", MessageBoxButtons.OK);
                    return false;
                }
                else
                {
                    Klient.UNTERBRINGUNG.New(frm.Grund, frm.Beginn, frm.Berufsgruppe,
                                            frm.AngeordnetVon, DateTime.Now, frm.Ende, frm.EingriffUnerlaesslichJN, frm.AbwehrBeschreibung, frm.VoraussichtlicheDauer, frm.VoraussichtlicheDauer2010,
                                            frm.DauerZeitraum, frm.KlientZustimmungJN, frm.PsychischeKrankheitJN, frm.GeistigeBehinderungJN, frm.MedDiagnoseICD,
                                            frm.MedDiagnose, frm.SelbstgefaehrdungJN, frm.FremdgefaehrdungJN, frm.Einrichtungsleiter,
                                            frm.ElektronischeUeberwachungJN, frm.ZurueckhaltensandrohungJN, frm.VerschlosseneTuerJN,
                                            frm.DrehknopfJN, frm.CodierungJN, frm.LabyrinthJN, frm.BaulicheMassnahme, frm.HindernRollstuhlGurtenJN,
                                            frm.HindernRollstuhlTischJN, frm.HindernRollstuhlTherapietischJN, frm.HindernRollstuhlBeschr,
                                            frm.HindernSitzgelgGurtenJN, frm.HindernSitzgelgTischJN, frm.HindernSitzgelgTherapietischJN,
                                            frm.HindernSitzgelgBeschr, frm.HindernBettVerlSeitenteilenJN, frm.HindernBettVerlGurtenJN,
                                            frm.HindernBettVerlBeschr, frm.MedikFreihBeschraenkungJN, frm.MedikBezDosierung, frm.GesendetAnBewohnervertrJN,
                                            frm.GesendetAnGestzVertrJN, frm.GesendetAnSelbstgewVertrJN, frm.GesendetAnVertrauenspersJN, frm.VoraussichtlichesEnde,
                                            frm.BettHandmanschettenJN, frm.RollstuhlBremsenJN, frm.RollstuhlSitzhoseJN,
                                            frm.AerztlDokumentArt, frm.AerztlDokumentArzt, frm.AerztlDokumentDatum,
                                            frm.TatsaechlicheEndeGrund,
                                            frm.AerztlDokumentArztTitel, frm.AerztlDokumentArztVorname,
                                            frm.EinrichtungsleiterTitel, frm.EinrichtungsleiterVorname, frm.Einrichtungsleiter,
                                            frm.AngeordnetVonTitel, frm.AngeordnetVonVorname,
                                            frm.EndeAngeordnetVonTitel, frm.EndeAngeordnetVonVorname,
                                            frm.HindernSitzgelgSitzhoseJN);

                    this.SaveUnterbringungAndRefresh();

                    EnableDisableButtons();
                    btnHistorie.Enabled = true;

                    object sender = new object();
                    EventArgs e = new EventArgs();
                    ValueChanged(sender, e);

                    return true;
                }
            }

            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        public void SaveUnterbringungAndRefresh()
        {
            Klient._unterbringung.Write();
            this.ucSiteMapKlientenDetailsMain._ContentChanged = false;
            this.ucSiteMapKlientenDetailsMain.Undo();
        }


        private bool AddUnterbringung2016()
        {
            try
            {
                frmUnterbringung2016 frm = new frmUnterbringung2016(Unterbringungsaktion.Beginn, Klient);
                frm.TypeUIUnterbringung = eTypeUIUnterbringung.AddUnterbringung;
                frm.mainWindow = this;
                frm.Show();

                return true;
            }

            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
        public bool AddUnterbringung2016_Click(frmUnterbringung2016 frm)
        {
            try
            {
                Klient.UNTERBRINGUNG.New2016(frm.Beginn, frm.Dauer, frm.VoraussichtlichesEnde, frm.Berufsgruppe, frm.AngeordnetVonTitel, frm.AngeordnetVonVorname,
                                            frm.AngeordnetVon, frm.Ende, frm.TatsaechlicheEndeGrund, frm.EndeBerufsgruppe, frm.EndeAngeordnetVonTitel,
                                            frm.EndeAngeordnetVonVorname, frm.EndeAngeordnetVon, frm.KlientZustimmungJN, frm.PsychischeKrankheitJN, frm.GeistigeBehinderungJN,
                                            frm.MedizinischeDiagnose, frm.SelbstgefaehrdungJN, frm.FremdgefaehrdungJN, frm.AnmerkungVerhalten_2016, frm.AnmerkungGutachten_2016,
                                            frm.EinzelfallmedikationJN_2016, frm.Einzelfallmedikation_2016, frm.DauermedikationJN_2016, frm.Dauermedikation_2016,
                                            frm.HindernVerlassenBettSeitenteilenJN, frm.HindernVerlassenBettBauchgurtJN_2016, frm.HindernVerlassenBettElektronischJN_2016,
                                            frm.HindernVerlassenBettHandArmgurte_2016, frm.HindernVerlassenBettFussBeingurte_2016, frm.HindernVerlassenBettAndereJN_2016,
                                            frm.HindernVerlassenBett, frm.HindernSitzgelSitzhoseJN, frm.HindernSitzgelBauchgurtJN_2016, frm.HindernSitzgelBrustgurtJN_2016,
                                            frm.HindernSitzgelHandArmgurte_2016, frm.HindernSitzgelTischJN, frm.HindernSitzgelTherapietischJN, frm.HindernSitzgelFussBeingurte_2016,
                                            frm.HindernSitzgelAndereJN_2016, frm.HindernSitzgelBeschr, frm.ZurueckhaltensandrohungJN, frm.HindernBereichFesthaltenJN_2016,
                                            frm.HindernBereichVersperrterBereichJN_2016, frm.HindernBereichBarriereJN_2016, frm.ElektronischeUeberwachungJN,
                                            frm.HindernBereichVersperrtesZimmerJN_2016, frm.HindernBereichHinderAmFortbewegenJN_2016, frm.HindernBereichAndereJN_2016,
                                            frm.BaulicheMassnahmen, frm.EinrichtungsleiterTitel, frm.EinrichtungsleiterVorname, frm.Einrichtungsleiter);

                this.SaveUnterbringungAndRefresh();

                EnableDisableButtons();
                btnHistorie.Enabled = true;

                object sender = new object();
                EventArgs e = new EventArgs();
                ValueChanged(sender, e);

                return true;

            }

            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        private bool Aufheben2016()
        {
            try
            {
                dsUnterbringung.UnterbringungRow r = GetAktivRow();

                if (r.Beginn < new DateTime(2016, 1, 11))
                {
                    frmUnterbringung frm = new frmUnterbringung(Unterbringungsaktion.Ende, Klient);
                    frm.TypeUIUnterbringung = eTypeUIUnterbringung.Aufheben;
                    frm.mainWindow = this;
                    frm.UNTERBRINGUNG_ROW = GetAktivRow();
                    frm.Show();
                    frm.UNTERBRINGUNG_ROW.Aktion = "Aufhebung";
                    frm.UNTERBRINGUNG_ROW.SetEDI_DatumNull();
                    frm.UNTERBRINGUNG_ROW.SetEDI_BenutzerNull();
                }
                else
                {
                    frmUnterbringung2016 frm2016 = new frmUnterbringung2016(Unterbringungsaktion.Ende, Klient);
                    frm2016.TypeUIUnterbringung = eTypeUIUnterbringung.Aufheben;
                    frm2016.mainWindow = this;
                    frm2016.UNTERBRINGUNG_ROW = GetAktivRow();
                    frm2016.Show();
                    frm2016.UNTERBRINGUNG_ROW.Aktion = "Aufhebung";
                    frm2016.UNTERBRINGUNG_ROW.SetEDI_DatumNull();
                    frm2016.UNTERBRINGUNG_ROW.SetEDI_BenutzerNull();
                }

                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }            
        }
        public bool Aufheben2016_Click()
        {
            try
            {
                this.SaveUnterbringungAndRefresh();

                object sender = new object();
                EventArgs e = new EventArgs();
                ValueChanged(sender, e);
                ENV.SignalKlientChanged();

                return true;
           }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }

        private bool Verlaengern2016()
        {
            try
            {
                DialogResult res = new DialogResult();
                dsUnterbringung.UnterbringungRow        r       = GetAktivRow();
                dsUnterbringung.UnterbringungRow        rnew    = dsUnterbringung.Unterbringung.NewUnterbringungRow();

                rnew.ItemArray = r.ItemArray;
                rnew.ID = Guid.NewGuid();
                rnew.SetAufgehobenAmNull();
                rnew.Aktion = "Verlaengerung";
                rnew.SetEDI_DatumNull();
                rnew.SetEDI_BenutzerNull();
                rnew.GesendetAnBewohnervertreterJN = false;
                rnew.GesendetAnGesetzVertreterJN = false;
                rnew.GesendetAnSelbstGewVertreterJN = false;
                rnew.GesendetAnVertrauenspersonJN = false;

                if (r.Beginn < new DateTime(2016,1,11))
                {
                    frmUnterbringung frm = new frmUnterbringung(Unterbringungsaktion.Verlaengerung, Klient);
                    frm.TypeUIUnterbringung = eTypeUIUnterbringung.Verlängern;
                    frm.rnew = rnew;
                    frm.r = r;
                    frm.mainWindow = this;
                    frm.UNTERBRINGUNG_ROW = rnew;
                    frm.Show();
                }
                else
                {
                    frmUnterbringung2016 frm2016 = new frmUnterbringung2016(Unterbringungsaktion.Verlaengerung, Klient);
                    frm2016.TypeUIUnterbringung = eTypeUIUnterbringung.Verlängern;
                    frm2016.rnew = rnew;
                    frm2016.r = r;
                    frm2016.mainWindow = this;
                    frm2016.UNTERBRINGUNG_ROW = rnew;
                    frm2016.Show();
                }

                //if (res != DialogResult.OK)
                //    return false;

                ////Aktuelle Unterbringung automatisch beenden.
                //SetUnterbringungsEnde(r);

                //Klient.UNTERBRINGUNG.Add(rnew);
                //this.SaveUnterbringungAndRefresh();

                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }
        public bool Verlaengern2016_OKClick(dsUnterbringung.UnterbringungRow rnew, dsUnterbringung.UnterbringungRow r)
        {
            try
            {
                SetUnterbringungsEnde(r);

                Klient.UNTERBRINGUNG.Add(rnew);
                this.SaveUnterbringungAndRefresh();

                object sender = new object();
                EventArgs e = new EventArgs();
                ValueChanged(sender, e);
                ENV.SignalKlientChanged();

                return true;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
                return false;
            }
        }


        private void SetUnterbringungsEnde(dsUnterbringung.UnterbringungRow r)
        {

            try
            {
                dsUnterbringung.UnterbringungDataTable dt = Klient.UNTERBRINGUNG._db.dsUnterbringung1.Unterbringung;
                dsUnterbringung.UnterbringungRow dr = dt.FindByID(r.ID);
                if (dr != null)
                {
                    r.AufgehobenAm = DateTime.Now;
                    r.SetTatsaechlicheEndeNull();
                    r.TatsaechlicheEndeGrund = 3;
                    if (!r.IsAnmerkungNull() && r.Anmerkung.Trim() == "")
                        r.Anmerkung += "\n\r";
                    else
                        r.Anmerkung = "";
                    r.Anmerkung += QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlängerung am ") + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss");
                    Klient.UNTERBRINGUNG.Write();
                    
                }
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        private void HistorieAnzeigen2016()
        {
            try
            {
                //DialogResult res = new DialogResult();
                dsUnterbringung.UnterbringungRow r = GetAktivRow();
                if (r.Beginn < new DateTime(2016,1,11))
                {
                    frmUnterbringung frm = new frmUnterbringung(Unterbringungsaktion.Historie, Klient);
                    frm.TypeUIUnterbringung = eTypeUIUnterbringung.HistoryAnzeigen;
                    frm.mainWindow = this;
                    frm.UNTERBRINGUNG_ROW = r;
                    frm.Show();
                }
                else
                {
                    frmUnterbringung2016 frm2016 = new frmUnterbringung2016(Unterbringungsaktion.Historie, Klient);
                    frm2016.TypeUIUnterbringung = eTypeUIUnterbringung.HistoryAnzeigen;
                    frm2016.mainWindow = this;
                    frm2016.UNTERBRINGUNG_ROW = r;
                    frm2016.Show();
                }
                return;
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        private dsUnterbringung.UnterbringungRow GetAktivRow()
        {
            return (dsUnterbringung.UnterbringungRow)UltraGridTools.CurrentSelectedRow(gridUnterbringung);
        }

        private bool DeleteUnterbringungen()
        {
            UltraGridRow[] rows = UltraGridTools.GetAllRowsFromGroupedUltraGrid(gridUnterbringung, true);

            if (rows.Length > 0 && ENV.HasRight(UserRights.PatientenVerwalten))
            {
                //
                //Sicherheitfrage
                
                DialogResult res;
                if (rows.Length > 1)
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                else
                    res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);

                if (res == DialogResult.Yes)
                {
                    foreach (UltraGridRow r in rows)
                        if(r.Selected)
                            r.Delete(false);
                    return true;
                }
            }

            return false;
        }

        private void SetReadOnly()     //lth29
        {
            if (Klient.UNTERBRINGUNG.ALL.Unterbringung.Rows.Count == 0)
            {
                btnDelUnterbringung.Enabled = false;
                btnVerlaeng.Enabled = false;
                btnHistorie.Enabled = false;
                btnPreview.Enabled = false;
                this.btnSendenUnterbringung.Enabled = true;
            }
            else
            {
                btnHistorie.Enabled = true;
                btnPreview.Enabled = true;
            }


            cbpatVerf.Enabled = !ReadOnly;
            dtPatVerf.ReadOnly = ReadOnly;
            this.optBeachtlich.Enabled = !ReadOnly;
            txtVerfAnmerkung.ReadOnly = ReadOnly; ;
            cbKommunion.Enabled = !ReadOnly;
            cbkrakSalbung.Enabled = !ReadOnly;
            txtReligioneWuen.ReadOnly = ReadOnly;
            txtSterbeRegelung.ReadOnly = ReadOnly;
            txtBesRegelung.ReadOnly = ReadOnly;
            cmbPostregel.ReadOnly = ReadOnly;
            txtSonstRegel.ReadOnly = ReadOnly;
            btnAddUnterbringung.Enabled = !ReadOnly;

            if(btnDelUnterbringung.Enabled)
                btnDelUnterbringung.Enabled = !ReadOnly;
            if(btnVerlaeng.Enabled)
                btnVerlaeng.Enabled = !ReadOnly;

            btnSendenUnterbringung.Visible = !ReadOnly;

            if(btnHistorie.Enabled)
                btnHistorie.Enabled = !ReadOnly;
        }

        //Neu nach 29.06.2007 MDA
        private void HideOrShowControls()
        {
            grpHeimaufenthaltsges.Visible = Klient.Aufenthalt != null;
            grpRegelungen.Visible = Klient.Aufenthalt != null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void OnValueChanged(object sender, EventArgs e)
        {
            if (this._lockValueChanges) return;
            ValueChanged(sender, e);

            dtPatVerf.Enabled = cbpatVerf.Checked;

            //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            if (!ReadOnly)
            {
                this.optBeachtlich.Enabled = cbpatVerf.Checked;
                txtVerfAnmerkung.Enabled = true;
            }
        }

        private void btnAddUnterbringung_Click(object sender, EventArgs e)
        {

            //Nach dem 11.1.2016 die neue Version öffnen
            if (DateTime.Now >= new DateTime(2016,1,11))
            {
                if (AddUnterbringung2016())
                {
                    //EnableDisableButtons();
                    //btnHistorie.Enabled = true;
                    //ValueChanged(sender, e);
                }
            }
            else
            {
                if (AddUnterbringung())
                {
                    //EnableDisableButtons();
                    //btnHistorie.Enabled = true;
                    //ValueChanged(sender, e);
                }
            }
        }

        private void btnVerlaeng_Click(object sender, EventArgs e)
        {

            if (Verlaengern2016())
            {
                //ValueChanged(sender, e);
                //ENV.SignalKlientChanged();
            }


        }

        private void gridUnterbringung_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;

            //Abhängig von der Version entweder 2010 oder 2016 anzeigen. Offen
            HistorieAnzeigen2016();
        }

        private void btnHistorie_Click(object sender, EventArgs e)
        {
            HistorieAnzeigen2016();
        }

        private void gridUnterbringung_AfterRowActivate(object sender, EventArgs e)
        {

            //if (PMDS.Global.historie.HistorieOn) return;
            if (ReadOnly)    //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
                return;

            EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            if (gridUnterbringung.ActiveRow != null)
            {
                dsUnterbringung.UnterbringungRow row = GetAktivRow();
                btnDelUnterbringung.Enabled = row != null && row.IsAufgehobenAmNull();
                btnVerlaeng.Enabled = row != null && row.IsAufgehobenAmNull();
                btnPreview.Enabled = row != null && (row.RowState != DataRowState.Added);

                this.btnSendenUnterbringung.Enabled = true;     // row != null && (row.RowState != DataRowState.Added) && row.IsEDI_DatumNull(); 
            }
        }

        private void gridUnterbringung_KeyDown(object sender, KeyEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.D && !ReadOnly && ENV.adminSecure) //Neu nach 27.04.2007: Wenn ReadOnly Event sperren
            {
                if (DeleteUnterbringungen() && ValueChanged != null)
                {
                    ValueChanged(sender, e);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Guid IDKlinik_current = ENV.IDKlinik;
                KlientGuiAction.PrintDynamicReport(GetAktivRow(), IDKlinik_current);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void gridUnterbringung_AfterCellUpdate(object sender, CellEventArgs e)
        {
            
        }

        private void gridUnterbringung_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void gridUnterbringung_CellChange(object sender, CellEventArgs e)
        {
            if (PMDS.Global.historie.HistorieOn) return;
            ValueChanged(sender, EventArgs.Empty);
        }

        private void ucRegelungen_Load(object sender, EventArgs e)
        {

        }
        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(grpPatientverfügung, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxRelgiöseWünsche, bOn);
            PMDS.GUI.BaseControls.historie.OnOffControls(grpRegelungen, bOn);
            
            panelButtons.Visible = !bOn || ENV.HasRight(UserRights.HAGMeldungen);
        }

        private void btnDelUnterbringung_Click(object sender, EventArgs e)
        {


            if (Aufheben2016())
            {
                //ValueChanged(sender, e);
                //ENV.SignalKlientChanged();
            }

        }

        private void btnSendenUnterbringung_Click(object sender, EventArgs e)
        {
            try
            {
                dsUnterbringung.UnterbringungRow rUnterbringung = GetAktivRow();
                if (rUnterbringung != null)
                {
                    if (rUnterbringung.RowState == DataRowState.Added || rUnterbringung.RowState == DataRowState.Modified || rUnterbringung.RowState == DataRowState.Deleted)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Freiheitsbeschränkende Maßnahme bitte vor dem Senden speichern!", "Senden", MessageBoxButtons.OK);
                        return;
                    }

                    bool bSent = !rUnterbringung.IsEDI_DatumNull() && rUnterbringung.Aktion.Trim() != "";
                    DialogResult res = new DialogResult();

                    if (bSent) 
                        res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die freiheitsbeschränkende Maßnahme wurde bereits einmal gesendet. Wollen Sie sie erneut senden?", "Hinweis", MessageBoxButtons.YesNo);
                    else
                        res = (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Daten für die freiheitsbeschränkende Maßnahme jetzt senden?", "Senden", MessageBoxButtons.YesNo));


                    if (res == DialogResult.Yes)
                    {
                        PMDS.Global.db.ERSystem.SendUnterbringung SendUnterbringung1 = new Global.db.ERSystem.SendUnterbringung();
                        PMDS.Global.db.ERSystem.SendUnterbringung.retSendUnterbringung retSendUnterbringung1 = new Global.db.ERSystem.SendUnterbringung.retSendUnterbringung();

                        PMDS.Global.db.ERSystem.SendUnterbringung.eMeldungstyp Meldungstyp = new Global.db.ERSystem.SendUnterbringung.eMeldungstyp();
                        if (rUnterbringung.Aktion.sEquals("Vornahme"))
                        {
                            Meldungstyp = Global.db.ERSystem.SendUnterbringung.eMeldungstyp.Vornahme;
                        }
                        else if (rUnterbringung.Aktion.sEquals("Verlaengerung"))
                        {
                            Meldungstyp = Global.db.ERSystem.SendUnterbringung.eMeldungstyp.Verlaengerung;
                        }
                        else if (rUnterbringung.Aktion.sEquals("Aufhebung"))
                        {
                            Meldungstyp = Global.db.ERSystem.SendUnterbringung.eMeldungstyp.Aufhebung;
                        }
                        else
                        {
                            throw new Exception("ucRegelungen.btnSendenUnterbringung_Click: rUnterbringung.Aktion '" + rUnterbringung.Aktion.ToString() + "' not allowed!");
                        }

                        PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext();
                        PMDS.db.Entities.Unterbringung rUnterbringungFromService = null;

                        if (rUnterbringung.Beginn >= new DateTime(2016,1,11))
                            SendUnterbringung1.Send2016(rUnterbringung.ID, ref retSendUnterbringung1, ref Meldungstyp, ref rUnterbringungFromService, ref db);
                        else
                            SendUnterbringung1.Send(rUnterbringung.ID, ref retSendUnterbringung1, ref Meldungstyp, ref rUnterbringungFromService, ref db);

                        if (retSendUnterbringung1.OK)
                        {
                            rUnterbringung.EDI_Benutzer = (Guid)rUnterbringungFromService.EDI_Benutzer;
                            rUnterbringung.EDI_Datum = (DateTime)rUnterbringungFromService.EDI_Datum;

                            if (rUnterbringung.Aktion.Trim() == "Aufhebung" || rUnterbringung.Aktion.Trim() == "Verlaengerung")
                                    rUnterbringung.EDI_Protokoll += "\r\n";

                            rUnterbringung.EDI_Protokoll += (rUnterbringung.EDI_Protokoll.Length > 0 ? "\n" : "") +  rUnterbringung.Aktion.Trim() + " (" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "): " + retSendUnterbringung1.ResultXML.ToString();
                            db.SaveChanges();

                            Klient._unterbringung.Write();
                            this.ucSiteMapKlientenDetailsMain._ContentChanged = false;
                            this.ucSiteMapKlientenDetailsMain.Undo();
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten für die freiheitsbeschränkende Maßnahme wurden erfolgreich versendet.\nDer Code ist " + retSendUnterbringung1.ResultXML.ToString(), "Senden", MessageBoxButtons.OK);
                        }
                        else
                        {
                            QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beim Versenden der Daten für die freiheitsbeschränkende Maßnahme ist ein Fehler aufgetreten. Bitte kontaktieren Sie Ihren Administrator." + "\r\n\r\n" +
                                                "Fehlerbeschreibung:" + retSendUnterbringung1.ErrorTxt, "Senden", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Maßnahme ausgewählt!", "Senden", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}
