using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.Abrechnung.Global;
using PMDS.Data.Patient;
using PMDS.GUI;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global.ds_abrechnung;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Global;

namespace PMDS.Calc.UI.Admin
{


    public partial class frmKostenträgerKlienten : QS2.Desktop.ControlManagment.baseForm 
    {

        private bool _bCanclose = false;
        private dsKostentraeger.KostentraegerRow _KostentraegerRow;
        private dsPatientKostentraeger.PatientKostentraegerRow _PatientKostentraegerRow;
        private bool _ValueChangeEnabled = true;

        private dsPatientKostentraeger.PatientKostentraegerDataTable _KostentraegerDataTable;
        private Patient _patient;
        public System.Guid IDKlient;

        public bool neuanlage = false ;
        public bool IDKlientNotInList = false;

        public  dsKlinik.KlinikRow rKlinikActuell = null;

        public bool isLoaded = false;






        public frmKostenträgerKlienten()
        {
            InitializeComponent();
        }

        public void initControl(DataTable source, string displayMember, string valueMember)
        {
            if (this.isLoaded)
                return;
            
            this.lblFound.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ") + source.Rows.Count.ToString();
            ucPicker1.DataSource = source;
            ucPicker1.DisplayMember = displayMember;
            ucPicker1.ValueMember = valueMember;
            InitListBenutzer();

            PMDS.UI.Sitemap.UIFct sitemap = new PMDS.UI.Sitemap.UIFct();
            sitemap.fillEnumBillTyp(this.cboRechnungTyp, false, false);
            this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;

            if (this.rKlinikActuell != null)
            {
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient zu Kostenträger zuordnen für ") + this.rKlinikActuell.Bezeichnung.Trim() + "";
            }
            else
            {
                this.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient zu Kostenträger (Klienten aller Einrichtungen)");
            }

            this.isLoaded = true;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsKostentraeger.KostentraegerRow KostentraegerRow
        {
            get { return _KostentraegerRow; }
            set 
            { 
                _KostentraegerRow = value;
                lblKostentraeger.Text = _KostentraegerRow.Name.Trim();
                InitListKostentraegerart();
                InitGui();
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsPatientKostentraeger.PatientKostentraegerRow PatientKostentraegerRow
        {
            get { return _PatientKostentraegerRow; }
            set 
            { 
                _PatientKostentraegerRow = value;

                if (_PatientKostentraegerRow.IDPatient != Guid.Empty)
                    _patient = new Patient(_PatientKostentraegerRow.IDPatient);
                
                SetReadOnly();
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ReadOnly
        {
            get { return ucPicker1.ReadOnly; }
            set { ucPicker1.ReadOnly = value; }
        }

        /// <summary>
        /// Nach Eingabe von DataSource, kann der Filter eingesetzt werden.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Filter
        {
            get { return ucPicker1.Filter; }
            set { ucPicker1.Filter = value; }
        }


        private void InitListBenutzer()
        {
            cmbBenutzer.Items.Clear();
            dsGUIDListe.IDListeDataTable t = Benutzer.All();
            foreach (dsGUIDListe.IDListeRow r in t.Rows)
            {
                cmbBenutzer.Items.Add(r.ID, r.TEXT);
            }
        }

        private void InitGui()
        {
            if (KostentraegerRow.TransferleistungJN)
            {
                cbKtrArt.Value = (int)Kostentraegerart.Transferleistung;
                cbBetragErrechnet.Checked = false;
                txtBetrag.Value = 0;
                this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
            }
            else
            {
                cbKtrArt.Value = PatientKostentraegerRow != null ? PatientKostentraegerRow.enumKostentraegerart : (int)Kostentraegerart.Grundkosten;
                cbVorauszahlungJN.Visible = KostentraegerRow.PatientbezogenJN;
                this.cboRechnungTyp.Value = (int)PMDS.Calc.Logic.eBillTyp.Rechnung;
            }
        }

        private void SetReadOnly()
        {
            ucPicker1.ReadOnly = false ;
            dtGueltigAb.ReadOnly = false;
            cbKtrArt.ReadOnly = false;
            //txtBetrag.ReadOnly = false;
            dtpErfasstAm.ReadOnly = false;
            cmbBenutzer.ReadOnly = false;
        }

        public void UpdateGUI()
        {
            if (_PatientKostentraegerRow == null)
                return;
            _ValueChangeEnabled = false;
            ucPicker1.Value = _PatientKostentraegerRow.IDPatient;
            dtGueltigAb.Value = _PatientKostentraegerRow.GueltigAb;
            if (!_PatientKostentraegerRow.IsGueltigBisNull())
                dtGueltigBis.Value = _PatientKostentraegerRow.GueltigBis;
            cbVorauszahlungJN.Checked = _PatientKostentraegerRow.VorauszahlungJN;
            cbRechnungJN.Checked = _PatientKostentraegerRow.RechnungJN;
            panelRechnung.Visible = cbRechnungJN.Checked;

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

            if (this.neuanlage)
            {
                this.cboRechnungTyp.Value = 1;
                this.panelRechnung.Visible = true;
                this.cbRechnungJN.Checked = true;
            }

            if (!KostentraegerRow.TransferleistungJN && !KostentraegerRow.PatientbezogenJN)
            {
                PMDS.DB.Global.DBKostentraeger kost = new PMDS.DB.Global.DBKostentraeger();
                bool sammRechJN = kost.sammelabrechnungJN(KostentraegerRow.ID);
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
                this.panelDetail2.Visible = false;
                this.Height = 405;
            }
            else if (KostentraegerRow.TransferleistungJN  )
            {
                cbVorauszahlungJN.Visible = false;
                cbVorauszahlungJN.Checked = false;

                cbBetragErrechnet.Checked = false ;
                panelAuswahlRestzahler.Visible = false;
                txtBetrag.Value = 0;
                this.panelDetail2.Height = 48;
                this.Height = 455;

                this.panelAuswahlRechnung.Left = 56;

                lblKostenträgerart.Visible = false;
                cbKtrArt.Visible = false;
            }

            _ValueChangeEnabled = true;
        }

        public void UpdateData()
        {
            if (_PatientKostentraegerRow == null)
                return;

            if (this.IDKlientNotInList  )
            {
                _PatientKostentraegerRow.IDPatient = this.IDKlient;
            }
            else
            {
                _PatientKostentraegerRow.IDPatient = (Guid)ucPicker1.Value;
            }
            
            _PatientKostentraegerRow.GueltigAb = (DateTime)dtGueltigAb.Value;

            if (dtGueltigBis.Value != null)
                _PatientKostentraegerRow.GueltigBis = (DateTime)dtGueltigBis.Value;
            else
                _PatientKostentraegerRow.SetGueltigBisNull();

            _PatientKostentraegerRow.VorauszahlungJN = cbVorauszahlungJN.Checked;
            _PatientKostentraegerRow.RechnungJN = cbRechnungJN.Checked;
            _PatientKostentraegerRow.enumKostentraegerart = Convert.ToInt32(cbKtrArt.Value);
            _PatientKostentraegerRow.BetragErrechnetJN = cbBetragErrechnet.Checked;
            _PatientKostentraegerRow.Betrag = (double)txtBetrag.Value;
            _PatientKostentraegerRow.ErfasstAm = (DateTime)dtpErfasstAm.Value;
            _PatientKostentraegerRow.IDBenutzer = (Guid)cmbBenutzer.Value;
            _PatientKostentraegerRow.RechnungTyp = (int)this.cboRechnungTyp.Value;
        }

        public bool ValidateFields()
        {
            bool bError = false;

            string eMsg = ENV.String("GUI.E_NO_TEXT");

            if (ucPicker1.Value == null && !this.neuanlage)
            {
                bool bFound = false;
                foreach (DataRow r in ((System.Data.DataTable)ucPicker1.DataSource).Rows)
                {
                    if (r.ToString() == this.IDKlient.ToString())
                    {
                        bFound = true;
                    }
                    this.IDKlientNotInList = !bFound;
                }
            }
            else
            {
                GuiUtil.ValidateField(ucPicker1, ucPicker1.Value != null,
                                     QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte einen Klienten auswählen."), ref bError, false, null);
            }

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
            if (KostentraegerRow == null)
            {
                PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbKtrArt, true );
            }
            else if (KostentraegerRow.TransferleistungJN)
            {
                cbKtrArt.Items.Add((int)Kostentraegerart.Transferleistung, QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung"));
            }
            else
            {
                cbKtrArt.Items.Add((int)Kostentraegerart.Grundkosten, QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"));
                //cbKtrArt.Items.Add((int)Kostentraegerart.mwst, "Mehrwertsteuer");
                //cbKtrArt.Items.Add((int)Kostentraegerart.Investitionsbeitrag, "Investitionsbeitrag");

                if (KostentraegerRow.PatientbezogenJN)
                {
                    PMDS.Calc.UI.Admin.GuiTools.AddKostentraegerArtCombo(cbKtrArt, false );

                }
            }
 
        }

        private void ucPicker1_SelectionChanged(object sender, EventArgs e)
        {
            //btnOK.Enabled = ((ucPicker1.Count != 0) && (ucPicker1.Value != null));

            //if (_patient != null && ucPicker1.Value != null && ucPicker1.Value is Guid && (Guid)ucPicker1.Value == _patient.ID) return;

            if (ucPicker1.Value != null && ucPicker1.Value is Guid)
                _patient = new Patient((Guid)ucPicker1.Value);
            else
                _patient = null;

            //foreach (Guid id in _lAbrechnungen2)
            //{
            //    if (_lAbrechnungen.IndexOf(id) == -1)
            //        _lAbrechnungen.Remove(id);
            //}

            //if (_patient == null || _PatientKostentraegerRow == null) return;
            //_PatientKostentraegerRow.IDPatient = _patient.ID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _bCanclose = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.IDKlientNotInList = false;
            if (ValidateFields())
            {
                _bCanclose = true;
                UpdateData();
                Close();
            }
            else
                _bCanclose = false;
        }

        private void frmKostentraegerKlienten_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_bCanclose;
        }

        private void cbBetragErrechnet_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBetragErrechnet.Focused)
            {
                if (cbBetragErrechnet.Checked)
                    txtBetrag.Value = 0;

                txtBetrag.Visible = !cbBetragErrechnet.Checked;
                lblBetrag.Visible = !cbBetragErrechnet.Checked;

                if (!_ValueChangeEnabled)
                    return;
            }

        }

        private void frmKostentraegerKlienten_Load(object sender, EventArgs e)
        {

        }

        private void cbRechnungJN_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRechnungJN.Focused )
                panelRechnung.Visible = cbRechnungJN.Checked;
        }

        private void dtGueltigAb_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
