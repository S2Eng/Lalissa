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
    public partial class ucSachwalter : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private Sachwalter _sachwalter;
        //Neu nach 26.04.2007 MDA
        private bool _readOnly = false;

        public ucSachwalter()
        {
            InitializeComponent();
            RequiredFields();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Sachwalter setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Sachwalter Sachwalter
        {
            get { return _sachwalter; }
            set
            {
                _sachwalter = value;
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
            txtVorname.Text = Sachwalter.Vorname;
            txtNachname.Text = Sachwalter.Nachname;
            cmbAkdGrad.Text = Sachwalter.Titel;
            SachwalterJN.Checked = Sachwalter.SachwalterJN;
            txtBelange.Text = Sachwalter.Belange;
            Von.Value = Sachwalter.Von;
            Bis.Value = Sachwalter.Bis;
            txtGericht.Text = Sachwalter.Gericht;
            BestimmtAm.Value = Sachwalter.BestimmtAm;
            txtBemerkung.Text = Sachwalter.Bemerkung;
            txtStrasse.Text = Sachwalter.Adresse.Strasse.Trim();
            txtPLZ.Text = Sachwalter.Adresse.Plz.Trim();
            txtOrt.Text = Sachwalter.Adresse.Ort.Trim();
            txtLand.Text = Sachwalter.Adresse.LandKZ.Trim();
            txtTelefon.Text = Sachwalter.Kontakt.Tel.Trim();
            txtMobil.Text = Sachwalter.Kontakt.Mobil.Trim();
            txtFax.Text = Sachwalter.Kontakt.Fax.Trim();
            txtEmail.Text = Sachwalter.Kontakt.Email.Trim();
            txtAndere.Text = Sachwalter.Kontakt.Andere.Trim();
            txtAnspPerson.Text = Sachwalter.Kontakt.Ansprechpartner.Trim();
            txtZusats1.Text = Sachwalter.Kontakt.Zusatz1.Trim();
            txtZusats2.Text = Sachwalter.Kontakt.Zusatz2.Trim();
            txtZusats3.Text = Sachwalter.Kontakt.Zusatz3.Trim();
        }

        /// <summary>
        /// Aktualisiert die Gui Daten über das Businessobject in die Datenbank.
        /// </summary>
        public void UpdateDATA()
        {
            Sachwalter.Vorname = txtVorname.Text.Trim();
            Sachwalter.Nachname = txtNachname.Text.Trim();
            Sachwalter.Titel = cmbAkdGrad.Text.Trim();
            Sachwalter.SachwalterJN = SachwalterJN.Checked;
            Sachwalter.Belange = txtBelange.Text.Trim();
            Sachwalter.Von = Von.Value;
            Sachwalter.Bis = Bis.Value;
            Sachwalter.Gericht = txtGericht.Text.Trim();
            Sachwalter.BestimmtAm = BestimmtAm.Value;
            Sachwalter.Bemerkung = txtBemerkung.Text.Trim();
            Sachwalter.Adresse.Strasse = txtStrasse.Text.Trim();
            Sachwalter.Adresse.Plz = txtPLZ.Text.Trim();
            Sachwalter.Adresse.Ort = txtOrt.Text.Trim();
            Sachwalter.Adresse.LandKZ = txtLand.Text.Trim();
            Sachwalter.Kontakt.Tel = txtTelefon.Text.Trim();
            Sachwalter.Kontakt.Mobil = txtMobil.Text.Trim();
            Sachwalter.Kontakt.Fax = txtFax.Text.Trim();
            Sachwalter.Kontakt.Email = txtEmail.Text.Trim();
            Sachwalter.Kontakt.Andere = txtAndere.Text.Trim();
            Sachwalter.Kontakt.Ansprechpartner = txtAnspPerson.Text.Trim();
            Sachwalter.Kontakt.Zusatz1 = txtZusats1.Text.Trim();
            Sachwalter.Kontakt.Zusatz2 = txtZusats2.Text.Trim();
            Sachwalter.Kontakt.Zusatz3 = txtZusats3.Text.Trim();
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

        //Neu nach 27.04.2007 MDA
        private void SetReadOnly()
        {
            txtVorname.ReadOnly = ReadOnly;
            txtNachname.ReadOnly = ReadOnly;
            cmbAkdGrad.ReadOnly = ReadOnly;
            SachwalterJN.Enabled = !ReadOnly;
            txtBelange.ReadOnly = ReadOnly;
            Von.ReadOnly = ReadOnly;
            Bis.ReadOnly = ReadOnly;
            txtGericht.ReadOnly = ReadOnly;
            BestimmtAm.ReadOnly = ReadOnly;
            txtBemerkung.ReadOnly = ReadOnly;
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
