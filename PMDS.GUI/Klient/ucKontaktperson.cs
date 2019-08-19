using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Klient;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class ucKontaktperson : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private Kontaktperson _kontaktperson;
        //Neu nach 26.04.2007 MDA
        private bool _readOnly = false;

        public ucKontaktperson()
        {
            InitializeComponent();
            RequiredFields();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Kontaktperson setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Kontaktperson Kontaktperson
        {
            get { return _kontaktperson; }
            set 
            { 
                _kontaktperson = value;
                UpdateGUI();
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

        /// <summary>
        /// lädt die Daten aus einem Businessobject und aktualisiert die GUI.
        /// </summary>
        public void UpdateGUI()
        {
            txtVorname.Text = Kontaktperson.Vorname.Trim();
            txtNachname.Text = Kontaktperson.Nachname.Trim();
            cmbAkdGrad.Text = Kontaktperson.Titel.Trim();
            cbKontaktart.Text = Kontaktperson.Kontaktart.Trim();
            cboVerwandschaft.Text = Kontaktperson.Verwandschaft.Trim();
            verschtaendigenJN.Checked = Kontaktperson.VerstaendigenJN;
            VersicherterJN.Checked = Kontaktperson.ExternerDienstleisterJN;
            txtStrasse.Text = Kontaktperson.Adresse.Strasse.Trim();
            txtPLZ.Text = Kontaktperson.Adresse.Plz.Trim();
            txtOrt.Text = Kontaktperson.Adresse.Ort.Trim();
            txtLand.Text = Kontaktperson.Adresse.LandKZ.Trim();
            txtTelefon.Text = Kontaktperson.Kontakt.Tel.Trim();
            txtMobil.Text = Kontaktperson.Kontakt.Mobil.Trim();
            txtFax.Text = Kontaktperson.Kontakt.Fax.Trim();
            txtEmail.Text = Kontaktperson.Kontakt.Email.Trim();
            txtAndere.Text = Kontaktperson.Kontakt.Andere.Trim();
            txtAnspPerson.Text = Kontaktperson.Kontakt.Ansprechpartner.Trim();
            txtZusats1.Text = Kontaktperson.Kontakt.Zusatz1.Trim();
            txtZusats2.Text = Kontaktperson.Kontakt.Zusatz2.Trim();
            txtZusats3.Text = Kontaktperson.Kontakt.Zusatz3.Trim();
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            Kontaktperson.Vorname = txtVorname.Text.Trim();
            Kontaktperson.Nachname = txtNachname.Text.Trim();
            Kontaktperson.Titel = cmbAkdGrad.Text.Trim();
            Kontaktperson.Kontaktart = cbKontaktart.Text.Trim();
            Kontaktperson.Verwandschaft = this.cboVerwandschaft.Text.Trim();
            Kontaktperson.VerstaendigenJN = verschtaendigenJN.Checked;
            Kontaktperson.ExternerDienstleisterJN = VersicherterJN.Checked;
            Kontaktperson.Adresse.Strasse = txtStrasse.Text.Trim();
            Kontaktperson.Adresse.Plz = txtPLZ.Text.Trim();
            Kontaktperson.Adresse.Ort = txtOrt.Text.Trim();
            Kontaktperson.Adresse.LandKZ = txtLand.Text.Trim();
            Kontaktperson.Kontakt.Tel = txtTelefon.Text.Trim();
            Kontaktperson.Kontakt.Mobil = txtMobil.Text.Trim();
            Kontaktperson.Kontakt.Fax = txtFax.Text.Trim();
            Kontaktperson.Kontakt.Email = txtEmail.Text.Trim();
            Kontaktperson.Kontakt.Andere = txtAndere.Text.Trim();
            Kontaktperson.Kontakt.Ansprechpartner = txtAnspPerson.Text.Trim();
            Kontaktperson.Kontakt.Zusatz1 = txtZusats1.Text.Trim();
            Kontaktperson.Kontakt.Zusatz2 = txtZusats2.Text.Trim();
            Kontaktperson.Kontakt.Zusatz3 = txtZusats3.Text.Trim();
        }

        /// <summary>
        /// prüft ob alle Eingaben richtig sind.
        /// </summary>
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // txtNachname
            GuiUtil.ValidateField(txtNachname, (txtNachname.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // txtVorname
            GuiUtil.ValidateField(txtVorname, (txtVorname.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);


            if (this.cbKontaktart.Text.Trim() == "")
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kontaktart: Angabe erforderlich!", "Speichern", MessageBoxButtons.OK);
                this.cbKontaktart.Focus();
                bError = true;
            }

            string MsgTxt = "";
            bool cbAkdGradOK = PMDSBusinessUI.checkCboBox(this.cmbAkdGrad, QS2.Desktop.ControlManagment.ControlManagment.getRes("Akad. Grad"), true, ref MsgTxt);
            bool cbVerwandschaftOK = PMDSBusinessUI.checkCboBox(this.cboVerwandschaft, QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwand.-verhältnis"), true, ref MsgTxt);
            bool cbKontaktartOK = PMDSBusinessUI.checkCboBox(this.cbKontaktart, QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktart"), true, ref MsgTxt);
            bool cbLandOK = PMDSBusinessUI.checkCboBox(this.txtLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt);
            if (!cbAkdGradOK || !cbVerwandschaftOK || !cbKontaktartOK || !cbLandOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
            }

            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(txtNachname);
            GuiUtil.ValidateRequired(txtVorname);
        }

        //Änderung am 26.04.2007 MDA
        private void SetReadOnly()
        {
            txtVorname.ReadOnly = ReadOnly;
            txtNachname.ReadOnly = ReadOnly;
            cmbAkdGrad.ReadOnly = ReadOnly;
            cbKontaktart.ReadOnly = ReadOnly;
            cboVerwandschaft.ReadOnly = ReadOnly;
            verschtaendigenJN.Enabled = !ReadOnly;
            VersicherterJN.Enabled = !ReadOnly;
            txtStrasse.ReadOnly = ReadOnly;
            txtPLZ.ReadOnly = ReadOnly;
            txtOrt.ReadOnly = ReadOnly;
            txtLand.ReadOnly = ReadOnly;
            txtTelefon.ReadOnly = ReadOnly;
            txtMobil.ReadOnly = ReadOnly;
            txtFax.ReadOnly = ReadOnly;
            txtEmail.ReadOnly = ReadOnly;
            txtAndere.ReadOnly = ReadOnly;
            txtAnspPerson.ReadOnly = ReadOnly;
            txtZusats1.ReadOnly = ReadOnly;
            txtZusats2.ReadOnly = ReadOnly;
            txtZusats3.ReadOnly = ReadOnly;

            if (!ReadOnly)
                RequiredFields();
        }

        private void extDienstleisterJN_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void verschtaendigenJN_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
