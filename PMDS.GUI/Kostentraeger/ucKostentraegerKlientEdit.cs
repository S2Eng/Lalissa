using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using PMDS.BusinessLogic.Abrechnung;
using PMDS.Abrechnung.Global;
using Infragistics.Win.UltraWinGrid;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Global;

namespace PMDS.Calc.UI.Admin
{


    public partial class ucKostenträgerKlientEdit : QS2.Desktop.ControlManagment.BaseControl
    {

        private dsPatientKostentraeger.PatientKostentraegerDataTable _KostentraegerDataTable;
        private Patient _patient;


        private  dsPatientKostentraeger.PatientKostentraegerRow _PatientKostentraegerRow;
        private bool _ValueChangeEnabled = true;
        

        public frmKostenträger mainWindow;
        public bool neuanlage = false ;

        public ucKostenträger ucKostenträger2;
        



        public ucKostenträgerKlientEdit()
        {
            this.InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime || !ENV.AppRunning)
                return;
            this.initControl();

        }
        public void initControl()
        {
            this.ucKostenträger2 = new ucKostenträger();
            this.ucKostenträger2.Dock = DockStyle.Fill;
            this.panelKostnträger.Controls.Add(this.ucKostenträger2 );
            this.ucKostenträger2.ReadOnly  = false;
            this.ucKostenträger2.AddKlienten = false;
            this.ucKostenträger2.AssignToPatientKostenträger = true;

            this.ucKostenträger2.initControl();
            PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
            sitemap.fillEnumBillTyp(this.cboRechnungTyp, false, false  );
            this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp .Rechnung;

            InitListKostentraegerart();
            InitListBenutzer();


        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPatientKostentraeger.PatientKostentraegerRow PatientKostentraegerRow
        {
            get { return _PatientKostentraegerRow; }
            set
            {
                if (value == null)
                    return;
                _PatientKostentraegerRow = value;
                //ucKostentraeger1.IDPatient = _PatientKostentraegerRow.IDPatient;
                _ValueChangeEnabled = false;

                ucKostenträger2.loadForIDKlinik = true;
                ucKostenträger2.ForPatientExclusive = false;
                ucKostenträger2.ShowButtons = true;
                ucKostenträger2.TransferKostentraegerJN = _PatientKostentraegerRow.enumKostentraegerart == (int)Kostentraegerart.Transferleistung;
                ucKostenträger2.SelectKostentraeger(_PatientKostentraegerRow.IDKostentraeger);
                ucKostenträger2.SaveBeforSetFilter = true;

                SetReadOnly();
                _ValueChangeEnabled = true;
                UpdateGUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPatientKostentraeger.PatientKostentraegerDataTable KostentraegerDataTable
        {
            get { return _KostentraegerDataTable; }
            set { _KostentraegerDataTable = value; }
        }

        public void UpdateGUI()
        {
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.mainWindow .BackColor = System.Drawing.Color.Gainsboro;

            if(_PatientKostentraegerRow == null)
                return;
            _ValueChangeEnabled = false;
            dtGueltigAb.Value = _PatientKostentraegerRow.GueltigAb;
            if (!_PatientKostentraegerRow.IsGueltigBisNull())
                dtGueltigBis.Value = _PatientKostentraegerRow.GueltigBis;
            else
                dtGueltigBis.Value = null;

            cbVorauszahlungJN.Checked = _PatientKostentraegerRow.VorauszahlungJN;
            cbRechnungJN.Checked = _PatientKostentraegerRow.RechnungJN;
            this.panelRechnung.Visible = cbRechnungJN.Checked;

            cbKtrArt.Value = _PatientKostentraegerRow.enumKostentraegerart;
            cbBetragErrechnet.Checked = _PatientKostentraegerRow.BetragErrechnetJN;
            txtBetrag.Value = (decimal)_PatientKostentraegerRow.Betrag;

            this.cboRechnungTyp.Value = (int)_PatientKostentraegerRow.RechnungTyp;

            txtBetrag.Visible = !cbBetragErrechnet.Checked;
            lblBetrag.Visible = !cbBetragErrechnet.Checked;

            if (!_PatientKostentraegerRow.IsErfasstAmNull())
                dtpErfasstAm.Value = _PatientKostentraegerRow.ErfasstAm;

            if (!_PatientKostentraegerRow.IsIDBenutzerNull())
                cmbBenutzer.Value = _PatientKostentraegerRow.IDBenutzer;

            _ValueChangeEnabled = true;

            this.panelAuswahlRechnung.Visible = true;
            panelAuswahlRestzahler.Visible = true;

            if (this.neuanlage)
            {
                this.panelRechnung.Visible = true;
                cbRechnungJN.Checked = true;
                this.cboRechnungTyp.Value = 2;
            }
            this.ucKostenträger2.notEditable();

            if (_PatientKostentraegerRow.IDKostentraeger != System.Guid.Empty)
            {
                PMDS.DB.Global.DBKostentraeger kost = new PMDS.DB.Global.DBKostentraeger();
                dsKostentraeger.KostentraegerDataTable dtKost;
                dsKostentraeger.KostentraegerRow rKost;
                dtKost = kost.GetKostentraeger(_PatientKostentraegerRow.IDKostentraeger);
                rKost = dtKost[0];

                if (!rKost.PatientbezogenJN && !rKost.TransferleistungJN)
                {

                    bool sammRechJN = kost.sammelabrechnungJN(_PatientKostentraegerRow.IDKostentraeger);
                    if (sammRechJN)
                    {
                        this.panelRechnung.Visible = true;
                        this.cboRechnungTyp.Value = 2;
                    }
                    else
                    {
                        this.panelRechnung.Visible = true;
                        this.cboRechnungTyp.Value = 1;
                    }
                    cbVorauszahlungJN.Visible = false;
                    cbVorauszahlungJN.Checked = false;
                    cbKtrArt.Visible = false;
                    lblKostenträgerart.Visible = false;
                    txtBetrag.Visible = false;
                    txtBetrag.Value = 0;
                    cbBetragErrechnet.Checked = true;
                    lblBetrag.Visible = false;
                    txtBetrag.Visible = false;
                    txtBetrag.Value = 0;
                    cbRechnungJN.Checked = true;
                    panelAuswahlRechnung.Visible = true;
                    panelAuswahlRestzahler.Visible = false;
                    this.uGridBagLayoutPanelElemente.Height = 141;
                }
                else if (rKost.TransferleistungJN)
                {
                    cbVorauszahlungJN.Visible = false;
                    cbVorauszahlungJN.Checked = false;
                    this.panelAuswahlRechnung.Top = 53;
                    this.panelAuswahlRechnung.Left = 51;
                    cbBetragErrechnet.Checked = false;
                    panelAuswahlRestzahler.Visible = false;
                    txtBetrag.Value = 0;
                    this.uGridBagLayoutPanelElemente.Height = 115;
                    //this.mainWindow.Height = 500;

                    cbKtrArt.Visible = false;
                    lblKostenträgerart.Visible = false;
                }
            }
            else if (_PatientKostentraegerRow.enumKostentraegerart == (int)Kostentraegerart.Transferleistung)
            {
                cbVorauszahlungJN.Visible = false;
                cbVorauszahlungJN.Checked = false;
                this.panelAuswahlRechnung.Top  = 53;
                this.panelAuswahlRechnung.Left = 51;
                cbBetragErrechnet.Checked = false;
                panelAuswahlRestzahler.Visible = false;
                txtBetrag.Value = 0;
                this.uGridBagLayoutPanelElemente.Height = 115;
                //this.mainWindow .Height = 500;

                cbKtrArt.Visible = false;
                lblKostenträgerart.Visible = false;
            }

        }

        public void UpdateData()
        {
            ucKostenträger2.Save();
            if (_PatientKostentraegerRow == null)
                return;

            if (ucKostenträger2.ActivRow != null)
            {
                _PatientKostentraegerRow.IDKostentraeger = ucKostenträger2.ActivRow.ID;
                //if (ucKostentraeger1.ActivRow.TransferleistungJN)
                //    _PatientKostentraegerRow.RechnungJN = false;
                //else if(ucKostentraeger1.ActivRow.PatientbezogenJN)
                //    _PatientKostentraegerRow.RechnungJN = cbRechnungJN.Checked;
                //else
                //    _PatientKostentraegerRow.RechnungJN = true;
            }

            _PatientKostentraegerRow.RechnungJN = cbRechnungJN.Checked;

            _PatientKostentraegerRow.GueltigAb = (DateTime)dtGueltigAb.Value;


            if (ucKostenträger2.ActivRow != null)
            {
                if (!ucKostenträger2.ActivRow.PatientbezogenJN && !ucKostenträger2.ActivRow.TransferleistungJN)
                {
                    PMDS.DB.Global.DBKostentraeger kost = new PMDS.DB.Global.DBKostentraeger();
                    bool sammRechJN = kost.sammelabrechnungJN(_PatientKostentraegerRow.IDKostentraeger );
                    if (sammRechJN)
                    {
                        _PatientKostentraegerRow.RechnungTyp = (int )PMDS.Calc.Logic.eBillTyp.Beilage;
                    }
                    else
                        _PatientKostentraegerRow.RechnungTyp = (int)this.cboRechnungTyp.Value;
                }
                else
                {
                    _PatientKostentraegerRow.RechnungTyp = (int)this.cboRechnungTyp.Value;
                }
            }
            else
            {
                _PatientKostentraegerRow.RechnungTyp = (int)this.cboRechnungTyp.Value;
            }

            if (dtGueltigBis.Value != null)
                _PatientKostentraegerRow.GueltigBis = (DateTime)dtGueltigBis.Value;
            else
                _PatientKostentraegerRow.SetGueltigBisNull();

            _PatientKostentraegerRow.VorauszahlungJN = cbVorauszahlungJN.Checked;
            //_PatientKostentraegerRow.RechnungJN = cbRechnungJN.Checked;
            _PatientKostentraegerRow.enumKostentraegerart = Convert.ToInt32(cbKtrArt.Value);
            _PatientKostentraegerRow.BetragErrechnetJN = cbBetragErrechnet.Checked;
            _PatientKostentraegerRow.Betrag = (double)txtBetrag.Value;
            _PatientKostentraegerRow.ErfasstAm = (DateTime)dtpErfasstAm.Value;
            _PatientKostentraegerRow.IDBenutzer = (Guid)cmbBenutzer.Value;
       }

        private void SetReadOnly()
        {
            dtGueltigAb.ReadOnly = false ;
            cbKtrArt.ReadOnly = false;
            //txtBetrag.ReadOnly = false;
            dtpErfasstAm.ReadOnly = false;
            cmbBenutzer.ReadOnly = false;
        }

        public bool ValidateFields()
        {
            bool bError = false;

            string eMsg = ENV.String("GUI.E_NO_TEXT");

            bError = !ucKostenträger2.ValidateFields();

            //Kostenträger auswahl
            GuiUtil.ValidateField(ucKostenträger2, ucKostenträger2.ActivRow != null,
                                     QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte einen Kostenträger auswählen."), ref bError, false, null);
            
            DateTime t = new DateTime(1900, 1, 1);
            //Gültig ab
            GuiUtil.ValidateField(dtGueltigAb, dtGueltigAb.Value != null, eMsg, ref bError, true, errorProvider1);

            //Gültig bis
//            GuiUtil.ValidateField(dtGueltigBis, dtGueltigBis.Value != null, eMsg, ref bError, true, errorProvider1);

            //Gültig bis darf nicht kleiner als Gültig ab sein.
            if (!bError)
            {
                GuiUtil.ValidateField(dtGueltigBis, dtGueltigBis.Value == null || (dtGueltigBis.Value != null && (DateTime)dtGueltigBis.Value > (DateTime)dtGueltigAb.Value),
                              QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig bis darf nicht vor dem ") + ((DateTime)dtGueltigAb.Value).ToString("dd.MM.yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen."), ref bError, true, errorProvider1);

            }
            
            //Betrag
            //if(!cbBetragErrechnet.Checked)
            //    GuiUtil.ValidateField(txtBetrag, txtBetrag.Value != null, eMsg, ref bError, true, errorProvider1);

            //Erfasst am
            GuiUtil.ValidateField(dtpErfasstAm, dtpErfasstAm.Value != null, eMsg, ref bError, true, errorProvider1);

            //Benutzer
            GuiUtil.ValidateField(cmbBenutzer, cmbBenutzer.Value != null, eMsg, ref bError, true, errorProvider1);

            return !bError;
        }

        private void InitListKostentraegerart()
        {
            cbKtrArt.Items.Clear();

            // Siehe enum Kostentraegerart
            if (ucKostenträger2.ActivRow == null)
            {
                PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbKtrArt, true);
            }
            else if (ucKostenträger2.ActivRow.TransferleistungJN)
            {
                cbKtrArt.Items.Add((int)Kostentraegerart.Transferleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung"));
            }
            else
            {
                cbKtrArt.Items.Add((int)Kostentraegerart.Grundkosten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"));
                //cbKtrArt.Items.Add((int)Kostentraegerart.mwst, "Mehrwertsteuer");
                //cbKtrArt.Items.Add((int)Kostentraegerart.Investitionsbeitrag, "Investitionsbeitrag");

                if (ucKostenträger2.ActivRow.PatientbezogenJN)
                {
                    PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbKtrArt, false);
                }
            }

        }

        private void InitListBenutzer()
        {
            cmbBenutzer.Items.Clear();
            dsGUIDListe.IDListeDataTable t = Benutzer.All();
            foreach (dsGUIDListe.IDListeRow r in t.Rows)
                cmbBenutzer.Items.Add(r.ID, r.TEXT);
        }

        private void InitGui()
        {
            InitListKostentraegerart();

            if (ucKostenträger2.ActivRow.TransferleistungJN)
            {
                cbKtrArt.Value = (int)Kostentraegerart.Transferleistung;
                cbBetragErrechnet.Checked = false;
                txtBetrag.Value = 0;
                this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
                this.panelAuswahlRechnung.Visible = true;
                panelAuswahlRestzahler.Visible = false;
            }
            else
            {
                cbKtrArt.Value = PatientKostentraegerRow != null ? PatientKostentraegerRow.enumKostentraegerart : (int)Kostentraegerart.Grundkosten;
                cbVorauszahlungJN.Visible = ucKostenträger2.ActivRow.PatientbezogenJN;
                this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
                this.panelAuswahlRechnung.Visible = true;
                panelAuswahlRestzahler.Visible = false;
            }

            this.panelRechnung.Visible = true;
            this.cboRechnungTyp.Value = 1;

            cbVorauszahlungJN.Visible = true;
            cbVorauszahlungJN.Checked = false;
            cbKtrArt.Visible = true;
            lblKostenträgerart.Visible = true;
            txtBetrag.Visible = true;
            txtBetrag.Value = 0;
            cbBetragErrechnet.Checked = false ;
            lblBetrag.Visible = true;
            txtBetrag.Visible = true;
            txtBetrag.Value = 0;
            cbRechnungJN.Checked = true;
            panelAuswahlRechnung.Visible = true;
            panelAuswahlRestzahler.Visible = true;

            this.panelRechnung.Visible = true;
            cbRechnungJN.Checked = true;
            this.cboRechnungTyp.Value = 2;

            if (!ucKostenträger2.ActivRow.PatientbezogenJN && !ucKostenträger2.ActivRow.TransferleistungJN)
            {
                PMDS.DB.Global.DBKostentraeger kost = new PMDS.DB.Global.DBKostentraeger();
                bool sammRechJN = kost.sammelabrechnungJN(ucKostenträger2.ActivRow.ID);
                if (sammRechJN)
                {
                    this.panelRechnung.Visible = true;
                    this.cboRechnungTyp.Value = 2;
                }
                else
                {
                    this.panelRechnung.Visible = true;
                    this.cboRechnungTyp.Value = 1;
                }
                cbVorauszahlungJN.Visible = false;
                cbVorauszahlungJN.Checked = false;
                cbKtrArt.Visible = false;
                lblKostenträgerart.Visible = false;
                txtBetrag.Visible = false;
                txtBetrag.Value = 0;
                cbBetragErrechnet.Checked = true;
                lblBetrag.Visible = false;
                txtBetrag.Visible = false;
                txtBetrag.Value = 0;
                cbRechnungJN.Checked = true;
                panelAuswahlRechnung.Visible = false;
                panelAuswahlRestzahler.Visible = false;
                this.uGridBagLayoutPanelElemente.Height = 77;
                //this.mainWindow .Height = 300;
            }
            else if (ucKostenträger2.ActivRow.TransferleistungJN)
            {
                cbVorauszahlungJN.Visible = false;
                cbVorauszahlungJN.Checked = false;

                cbBetragErrechnet.Checked = false;
                panelAuswahlRestzahler.Visible = false;
                txtBetrag.Value = 0;
                //this.mainWindow.Height = 600;
                cbKtrArt.Visible = false;
                lblKostenträgerart.Visible = false;
            }
            else
            {
                //this.mainWindow.Height = 600;
                this.uGridBagLayoutPanelElemente.Height = 141;
            }
            //if (ucKostentraeger1.ActivRow != null)
            //    cbRechnungJN.Visible = ucKostentraeger1.ActivRow.PatientbezogenJN;
        }


        private void cbBetragErrechnet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBetragErrechnet.Focused )
            {
                if (cbBetragErrechnet.Checked)
                    txtBetrag.Value = 0;

                txtBetrag.Visible = !cbBetragErrechnet.Checked;
                lblBetrag.Visible = !cbBetragErrechnet.Checked;

                if (!_ValueChangeEnabled)
                    return;
            }
        }


        private void ucKostentraeger1_AfterRowActivate(object sender, EventArgs e)
        {
            InitGui();
        }
        private void cbRechnungJN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRechnungJN.Focused)
                panelRechnung.Visible = cbRechnungJN.Checked;
        }
    }
}
