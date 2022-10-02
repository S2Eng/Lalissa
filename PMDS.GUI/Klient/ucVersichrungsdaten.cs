using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Klient;
using System.Linq;
using PMDS.DB;


namespace PMDS.GUI
{
    public partial class ucVersichrungsdaten : QS2.Desktop.ControlManagment.BaseControl, IWizardPage, IReadOnly
    {
        private KlientDetails _klient;
        private bool _valueChangeEnabled = true;
        public event EventHandler ValueChanged;
        public event EventHandler KrankenkasseChanged;
        public event EventHandler SVNrChanged;
        public event EventHandler KlasseChanged;
        public event EventHandler PrivatversicherungChanged;
        public event EventHandler PolNrChanged;

        private bool _readOnly = false;
        private bool _lockValueChanges = false;

        public bool isInitialized = false;



        


        public ucVersichrungsdaten()
        {
            InitializeComponent();
        }



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
                _valueChangeEnabled = false;
                this.initControl();
                _klient = value;
                InitFields();
                UpdateGUI();
                _valueChangeEnabled = true;
            }
        }
        public void initNoKlient()
        {
            _valueChangeEnabled = false;
            this.initControl();
            InitFields();

            this._lockValueChanges = true;

            this.cboEinrichtungen.Text = "";
            txtVersNr.Text = "";
            cmbKlasse.Text = "";
            txtPrivatVers.Text = "";
            txtPolzNr.Text = "";

            this._lockValueChanges = false;

            _valueChangeEnabled = true;
        }

        public void initControl()
        {
            if (!this.isInitialized)
            {

                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    this.cboEinrichtungen.Items.Clear();
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        var tE = (from e in db.Einrichtung
                                  where e.IstKrankenkasse == true
                                  orderby e.Text ascending
                                  select new
                                  {
                                      ID = e.ID,
                                      Text = e.Text
                                  });

                        foreach (var r in tE)
                        {
                            if (!String.IsNullOrWhiteSpace(r.Text))
                            {
                                this.cboEinrichtungen.Items.Add(r.ID, r.Text.Trim());
                            }
                            else
                            {
                                this.cboEinrichtungen.Items.Add(r.ID, QS2.Desktop.ControlManagment.ControlManagment.getRes("[Kein Name]"));
                            }
                        }
                    }
                }
                this.isInitialized = true;
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            PMDS.GUI.BaseControls.historie.OnOffControls(ultraGroupBoxVersicherungsdaten, bOn);

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Krankenkasse
        {
            get
            {
                return this.cboEinrichtungen.Text.Trim();
            }

            set
            {
                this.cboEinrichtungen.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string VersicherungsNr
        {
            get
            {
                return txtVersNr.Text.Trim();
            }

            set
            {
                txtVersNr.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Klasse
        {
            get
            {
                return cmbKlasse.Text.Trim();
            }

            set
            {
                cmbKlasse.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Privatversicherung
        {
            get
            {
                return txtPrivatVers.Text.Trim();
            }

            set
            {
                txtPrivatVers.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PrivPolNr
        {
            get
            {
                return txtPolzNr.Text.Trim();
            }

            set
            {
                txtPolzNr.Text = value;
            }
        }

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

        public void UpdateGUI()
        {
            this._lockValueChanges = true;

            this.cboEinrichtungen.Text = Klient.Krankenkasse;
            txtVersNr.Text = Klient.VersicherungsNr.Replace(" ", "");
            cmbKlasse.Text = Klient.Klasse;
            txtPrivatVers.Text = Klient.Privatversicherung;
            txtPolzNr.Text = Klient.PrivPolNr;

            //this.setUIVersNr(txtVersNr.Text.Trim());

            this._lockValueChanges = false;
        }

        public void UpdateDATA()
        {
            Klient.Krankenkasse = this.cboEinrichtungen.Text.Trim();
            Klient.VersicherungsNr = txtVersNr.Text.Trim().Replace(" ", "");
            Klient.Klasse = cmbKlasse.Text.Trim();
            Klient.Privatversicherung = txtPrivatVers.Text.Trim();
            Klient.PrivPolNr = txtPolzNr.Text.Trim();
        }

        private void InitFields()
        {
            errorProvider1.SetError(txtVersNr, "");
        }

        public bool ValidateFields()
        {
            bool bError = false;
            bool bInfo = true;

            // Sv-NR
            //GuiUtil.ValidateField(txtVersNr, (txtVersNr.Text.Length > 0),
            //    Settings.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);

            return bError;
        }

        private void SetReadOnly()
        {
            this.cboEinrichtungen.ReadOnly = ReadOnly;
            txtVersNr.ReadOnly = ReadOnly;
            cmbKlasse.ReadOnly = ReadOnly;
            txtPrivatVers.ReadOnly = ReadOnly;
            txtPolzNr.ReadOnly = ReadOnly;

            if (!ReadOnly)
                RequiredFields();
        }

        protected void RequiredFields()
        {
            GuiUtil.ValidateRequired(txtVersNr);
        }

        protected void OnValueChanged(object sender, EventArgs args)
        {
            if (this._lockValueChanges) return;

            if (_valueChangeEnabled)
            {
                if (ValueChanged != null)
                    ValueChanged(sender, args);

                switch (((Control)sender).Name)
                {
                    case "cmbKrankenkasse":
                        KrankenkasseChanged(sender, args);
                        break;
                    case "txtVersNr":
                        SVNrChanged(sender, args);
                        break;
                    case "cmbKlasse":
                        KlasseChanged(sender, args);
                        break;
                    case "txtPrivatVers":
                        PrivatversicherungChanged(sender, args);
                        break;
                    case "txtPolzNr":
                        PolNrChanged(sender, args);
                        break;
                }
            }
        }


        public bool validateVerNr(string VersNr, bool WithMsgBox)
        {
            try
            { 
                if (VersNr.Trim() != "")
                {
                    if (VersNr.Trim().Length != 10)
                    {
                        if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV-Nr. muss 10-stellig oder leer sein!", "Speichern");
                        return false;
                    }
                    else
                    {
                        string sGebDate = VersNr.Trim().Substring(4, 6);
                        if (sGebDate.Trim().Length == 6)
                        {
                            string sTag = sGebDate.Trim().Substring(0, 2);
                            string sMonat = sGebDate.Trim().Substring(2, 2);
                            string sJahr = sGebDate.Trim().Substring(4, 2);
                            try
                            {
                                if (System.Convert.ToInt32(sJahr) > DateTime.Now.Year)
                                    sJahr = "20" + sJahr;
                                else
                                    sJahr = "19" + sJahr;

                                if (sMonat.Trim() == "13")
                                    sMonat = "12";
                                DateTime dGebDatum = new DateTime(System.Convert.ToInt32(sJahr), System.Convert.ToInt32(sMonat), System.Convert.ToInt32(sTag), 0, 0, 0);
                                return true;
                            }
                            catch (Exception ex3)
                            {
                                if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV-Nr.: Die letzten 6 Stellen müssen das Geburtsdatum im Format TTMMJJ sein!", "Speichern");
                                return false;
                            }
                        }
                        else
                        {
                            if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV-Nr. muss 10-stellig oder leer sein!", "Speichern");
                            return false;
                        }
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVersicherungsdaten.validateVerNr: " + ex.ToString());
            }
        }
        public void setUIVersNr(string VersNr)
        {
            try
            {
                bool VersNrOK = this.validateVerNr(VersNr.Trim(), false);
                if (VersNrOK && VersNr.Trim() != "")
                {
                    this.cboEinrichtungen.Visible = true;
                    this.lblKrankenkasse.Visible = true;
                    this.cmbKlasse.Visible = true;
                    this.lblKasse.Visible = true;
                    this.cboSozVersStatus.Visible = true;
                    this.lblSozVersStatus.Visible = true;
                    this.cboSozVersLeerGrund.Visible = true;
                    this.lblSozVersLeerGrund.Visible = true;
                }
                else
                {
                    this.cboEinrichtungen.Visible = false;
                    this.lblKrankenkasse.Visible = false;
                    this.cmbKlasse.Visible = false;
                    this.lblKasse.Visible = false;
                    this.cboSozVersStatus.Visible = false;
                    this.lblSozVersStatus.Visible = false;
                    this.cboSozVersLeerGrund.Visible = false;
                    this.lblSozVersLeerGrund.Visible = false;
                }

                if (VersNrOK && VersNr.Trim() != "")
                {
                    this.cboSozVersLeerGrund.Visible = false;
                    this.lblSozVersLeerGrund.Visible = false;
                }
                else if (VersNrOK && VersNr.Trim() == "")
                {
                    this.cboSozVersLeerGrund.Visible = true;
                    this.lblSozVersLeerGrund.Visible = true;
                }
                else
                {
                    //this.cboSozVersStatus.Text = "";
                    this.cboSozVersLeerGrund.Visible = false;
                    this.lblSozVersLeerGrund.Visible = false;
                    this.txtSozVersMitversichertBei.Text = "";
                    this.setUIMitversichertBei(this.txtSozVersMitversichertBei.Text);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVersicherungsdaten.setUIVersNr: " + ex.ToString());
            }
        }
        public void setUIMitversichertBei(string SozialversStatus)
        {
            try
            {
                if (SozialversStatus.Trim().ToLower().Equals(("mitversichert").Trim().ToLower()))
                {
                    this.txtSozVersMitversichertBei.Visible = true;
                    this.lblSozVersMitversichertBei.Visible = true;
                }
                else if (SozialversStatus.Trim().ToLower().Equals(("selbstversichert").Trim().ToLower()))
                {
                    this.txtSozVersMitversichertBei.Visible = false;
                    this.lblSozVersMitversichertBei.Visible = false;
                }
                else
                {
                    this.txtSozVersMitversichertBei.Visible = false;
                    this.lblSozVersMitversichertBei.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVersicherungsdaten.setUIMitversichertBei: " + ex.ToString());
            }
        }

        private void TxtVersNr_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.txtVersNr.Focused)
                {
                    OnValueChanged(sender, e);
                    this.setUIVersNr(this.txtVersNr.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void TxtSozVersMitversichertBei_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.txtSozVersMitversichertBei.Focused)
                {

                    OnValueChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void CboSozVersStatus_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboSozVersStatus.Focused)
                {
                    OnValueChanged(sender, e);
                    this.setUIMitversichertBei(this.cboSozVersStatus.Text.Trim());
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void CboSozVersLeerGrund_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboSozVersLeerGrund.Focused)
                {

                    OnValueChanged(sender, e);
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LblPrivatversicherung_Click(object sender, EventArgs e)
        {

        }

        private void TxtVersNr_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.txtVersNr.Focused)
                {
                    if (e.KeyChar != '\b' && e.KeyChar != ',')
                    {
                        if (Char.IsControl((e.KeyChar)))
                        {
                        }
                        else if (!Char.IsDigit(e.KeyChar))
                        {
                            e.Handled = true;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

    }

}

