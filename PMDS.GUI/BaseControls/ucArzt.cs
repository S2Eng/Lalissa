using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucArzt : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private Arzt _Arzt;
        private dsAerzte.AerzteRow _AerzteRow;

        //Neu 26.04.2007 MDA
        private bool _readOnly = false;

        public ucArzt()
        {
            InitializeComponent();
            RequiredFields();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Arzt setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Arzt Arzt
        {
            get { return _Arzt; }
            set
            {
                _Arzt = value;
                UpdateGUI();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AerzteRow setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsAerzte.AerzteRow AerzteRow
        {
            get { return _AerzteRow; }
            set
            {
                _AerzteRow = value;
                UpdateGUI();
            }
        }
             
        //Neu nach 26.04.2007
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
            if (Arzt == null || AerzteRow == null)
                return;

            if(!AerzteRow.IsVornameNull())
                txtVorname.Text = AerzteRow.Vorname.Trim();

            if(!AerzteRow.IsNachnameNull())
                txtNachname.Text = AerzteRow.Nachname.Trim();

            if(!AerzteRow.IsTitelNull())
                cmbAkdGrad.Text = AerzteRow.Titel.Trim();

            if(!AerzteRow.IsFachrichtungNull())
                cbFachrichtung.Text = AerzteRow.Fachrichtung.Trim();

            txtStrasse.Text = Arzt.Adresse.Strasse.Trim();
            txtPLZ.Text = Arzt.Adresse.Plz.Trim();
            txtOrt.Text = Arzt.Adresse.Ort.Trim();
            txtLand.Text = Arzt.Adresse.LandKZ.Trim();
            txtTelefon.Text = Arzt.Kontakt.Tel.Trim();
            txtMobil.Text = Arzt.Kontakt.Mobil.Trim();
            txtFax.Text = Arzt.Kontakt.Fax.Trim();
            txtEmail.Text = Arzt.Kontakt.Email.Trim();
            txtAndere.Text = Arzt.Kontakt.Andere.Trim();
            txtAnspPerson.Text = Arzt.Kontakt.Ansprechpartner.Trim();
            txtZusats1.Text = Arzt.Kontakt.Zusatz1.Trim();
            txtZusats2.Text = Arzt.Kontakt.Zusatz2.Trim();
            txtZusats3.Text = Arzt.Kontakt.Zusatz3.Trim();
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            AerzteRow.Vorname = txtVorname.Text.Trim();
            AerzteRow.Nachname = txtNachname.Text.Trim();
            AerzteRow.Titel = cmbAkdGrad.Text.Trim();
            AerzteRow.Fachrichtung = cbFachrichtung.Text.Trim();
            Arzt.Adresse.Strasse = txtStrasse.Text.Trim();
            Arzt.Adresse.Plz = txtPLZ.Text.Trim();
            Arzt.Adresse.Ort = txtOrt.Text.Trim();
            Arzt.Adresse.LandKZ = txtLand.Text.Trim();
            Arzt.Kontakt.Tel = txtTelefon.Text.Trim();
            Arzt.Kontakt.Mobil = txtMobil.Text.Trim();
            Arzt.Kontakt.Fax = txtFax.Text.Trim();
            Arzt.Kontakt.Email = txtEmail.Text.Trim();
            Arzt.Kontakt.Andere = txtAndere.Text.Trim();
            Arzt.Kontakt.Ansprechpartner = txtAnspPerson.Text.Trim();
            Arzt.Kontakt.Zusatz1 = txtZusats1.Text.Trim();
            Arzt.Kontakt.Zusatz2 = txtZusats2.Text.Trim();
            Arzt.Kontakt.Zusatz3 = txtZusats3.Text.Trim();
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

            string MsgTxt2 = "";
            bool cbLandOK = PMDSBusinessUI.checkCboBox(this.txtLand, QS2.Desktop.ControlManagment.ControlManagment.getRes("Land"), true, ref MsgTxt2);
            if (!cbLandOK)
            {
                bError = true;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(MsgTxt2, QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern"), MessageBoxButtons.OK);
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

        //Neu nach 26.04.2007 MDA
        private void SetReadOnly()
        {
            txtVorname.ReadOnly = ReadOnly;
            txtNachname.ReadOnly = ReadOnly;
            cmbAkdGrad.ReadOnly = ReadOnly;
            cbFachrichtung.ReadOnly = ReadOnly;
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
    }
}
