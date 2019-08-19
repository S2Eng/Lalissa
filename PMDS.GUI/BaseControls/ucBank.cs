using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBank : QS2.Desktop.ControlManagment.BaseControl
    {
        private Bank _bank;
        public event EventHandler ValueChanged;
        private bool _valueChangeEnabled = true;

        public ucBank()
        {
            InitializeComponent();
            RequiredFields();
            if (DesignMode || !ENV.AppRunning) return;
            Init();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialisierung
        /// </summary>
        //----------------------------------------------------------------------------
        private void Init()
        {
            Bank = new Bank();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ADRESSE setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Bank Bank
        {
            get
            {
                return _bank;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Bank");
                _valueChangeEnabled = false;
                _bank = value;
                UpdateGUI();
                _valueChangeEnabled = true;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateGUI()
        {
            txtName.Text     = Bank.Bezeichnung.Trim();
            txtIBAN.Text = Bank.IBAN.Trim();
            txtBIC.Text = Bank.BIC.Trim();
            if (Bank.Kontonummer == 0)
                txtKontoNr.Value = DBNull.Value;
            else
                txtKontoNr.Value = Bank.Kontonummer;

            if (Bank.BLZ == 0)
                txtBLZ.Value = DBNull.Value;
            else
                txtBLZ.Value     = Bank.BLZ;
        }
        public void clearUI()
        {
            txtName.Text = "";
            txtKontoNr.Value = DBNull.Value;
            txtBLZ.Value = DBNull.Value;
            txtIBAN.Text = "";
            txtBIC.Text =  "";
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI nach Daten übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public void UpdateDATA()
        {
            Bank.Bezeichnung = txtName.Text.Trim();
            Bank.IBAN = txtIBAN.Text.Trim();
            Bank.BIC = txtBIC.Text.Trim();
            Bank.Kontonummer = (int)txtKontoNr.Value;
            Bank.BLZ         = (int)txtBLZ.Value;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // txtName
            GuiUtil.ValidateField(txtName, (txtName.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            
            /*
            os-170709 Kontonummer und Bankleitzahl sind keine Pflichtfelder mehr, dafür IBAN und BIC
            // txtName
            GuiUtil.ValidateField(txtKontoNr, (txtKontoNr.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // txtName
            GuiUtil.ValidateField(txtBLZ, (txtBLZ.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            */

            GuiUtil.ValidateField(txtIBAN, (txtIBAN.Text.Length > 0),
                ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            // txtName
            GuiUtil.ValidateField(txtBIC, (txtBIC.Text.Length > 0),
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
            GuiUtil.ValidateRequired(txtName);
            GuiUtil.ValidateRequired(txtIBAN);
            GuiUtil.ValidateRequired(txtBIC);
            //GuiUtil.ValidateRequired(txtKontoNr);
            //GuiUtil.ValidateRequired(txtBLZ);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderungs signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (_valueChangeEnabled && ValueChanged != null)
                ValueChanged(sender, args);
        }

    }
}
