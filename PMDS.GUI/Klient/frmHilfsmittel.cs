using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Klient;
using PMDS.GUI.Klient;



namespace PMDS.GUI
{
    public partial class frmHilfsmittel : QS2.Desktop.ControlManagment.baseForm 
    {
        private dsGegenstaende.GegenstaendeRow _row;

        public frmHilfsmittel()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            Init();
            RequiredFields();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsGegenstaende.GegenstaendeRow GEGENSTAENDE_ROW
        {
            get
            {
                return _row;
            }

            set
            {
                _row = value;
                UpdateGUI();
            }
        }

        private void Init()
        {
            cmbAusgegebenVon.Items.Clear();
            cmbRuecknahme.Items.Clear();

            foreach (DataRow r in Benutzer.All().Rows)
            {
                cmbAusgegebenVon.Items.Add(r["ID"], (string)r["TEXT"]);
                cmbRuecknahme.Items.Add(r["ID"], (string)r["TEXT"]);
            }

            dtpVon.Value = null;
            dtpBis.Value = null;
            cmbAusgegebenVon.Value = null;
            cmbRuecknahme.Value = null;

            chkEigentumKlinikJN.Checked = false;
            chkEigentumKlientJN.Checked = false;
            chkMieteJN.Checked = false;
            dtLetzteUeberpruefungAm.Value = null;
            dtNaechsteUeberpruefungAm.Value = null;
            tbEigentuemer.Value = "";

        }

        public void UpdateGUI()
        {
            if (_row != null)
            {
                if (!_row.IsBeschreibungNull())
                    BESCHREIBUNG = _row.Beschreibung.Trim();

                if (!_row.IsNrNull())
                    NUMMER = _row.Nr.Trim();

                if (!_row.IsVonNull())
                    VON = _row.Von;

                if (!_row.IsBisNull())
                    BIS = _row.Bis;

                if (!_row.IsIDBenutzerausgegebenNull())
                    BENUTZER_AUSGEGEBEN = _row.IDBenutzerausgegeben;

                if (!_row.IsIDBenutzerzurueckNull())
                    BENUTZER_ZURUECK = _row.IDBenutzerzurueck;

                if (!_row.IsEigentumKlinikJNNull())
                    EIGENTUMKLINIKJN = _row.EigentumKlinikJN;

                if (!_row.IsEigentumKlientJNNull())
                    EIGENTUMKLIENTJN = _row.EigentumKlientJN;

                if (!_row.IsMieteJNNull())
                    MIETEJN = _row.MieteJN;

                if (!_row.IsEigentuemerNull())
                    EIGENTUEMER = _row.Eigentuemer;

                if (!_row.IsLetzteUeberpruefungAmNull())
                    LETZTEUEBERPRUEFUNGAM = _row.LetzteUeberpruefungAm;

                if (!_row.IsNaechsteUeberpruefungAmNull())
                    NAECHSTEUEBERPRUEFUNGAM = _row.NaechsteUeberpruefungAm;

            }
        }

        public void UpdateData()
        {
            if (_row != null)
            {
                _row.Beschreibung = BESCHREIBUNG;

                _row.Nr = NUMMER;

                if (VON != DateTime.MinValue)
                    _row.Von = VON;
                else
                    _row.SetVonNull();

                if (BIS != DateTime.MinValue)
                    _row.Bis = BIS;

                if (BENUTZER_AUSGEGEBEN != null)
                    _row.IDBenutzerausgegeben = new Guid(BENUTZER_AUSGEGEBEN.ToString());

                if (BENUTZER_ZURUECK != null)
                    _row.IDBenutzerzurueck = new Guid(BENUTZER_ZURUECK.ToString());

                _row.EigentumKlinikJN = EIGENTUMKLINIKJN;

                _row.EigentumKlientJN = EIGENTUMKLIENTJN;

                _row.MieteJN = MIETEJN;

                if (EIGENTUEMER != null)
                    _row.Eigentuemer = EIGENTUEMER;

                if (LETZTEUEBERPRUEFUNGAM != DateTime.MinValue)
                    _row.LetzteUeberpruefungAm = LETZTEUEBERPRUEFUNGAM;
                else
                    _row.SetLetzteUeberpruefungAmNull();

                if (NAECHSTEUEBERPRUEFUNGAM != DateTime.MinValue)
                    _row.NaechsteUeberpruefungAm = NAECHSTEUEBERPRUEFUNGAM;
                else
                    _row.SetNaechsteUeberpruefungAmNull();

            }
        }

        public bool ValidateFields()
        {
            return true;
        }

        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Benötigte Felder setzen
        /// </summary>
        //----------------------------------------------------------------------------
        protected void RequiredFields()
        {

        }

        #region Properties
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BESCHREIBUNG
        {
            get
            {
                return tbBeschreibung.Text.Trim();
            }

            set
            {
                tbBeschreibung.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NUMMER
        {
            get
            {
                return tbNr.Text.Trim();
            }

            set
            {
                tbNr.Text = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime VON
        {
            get
            {
                if (dtpVon.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpVon.DateTime;
            }

            set
            {
                dtpVon.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime BIS
        {
            get
            {
                if (dtpBis.Value == null)
                    return DateTime.MinValue;
                else
                    return dtpBis.DateTime;
            }

            set
            {
                dtpBis.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object BENUTZER_AUSGEGEBEN
        {
            get
            {
                return cmbAusgegebenVon.Value;
            }

            set
            {
                cmbAusgegebenVon.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object BENUTZER_ZURUECK
        {
            get
            {
                return cmbRuecknahme.Value;
            }

            set
            {
                cmbRuecknahme.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EIGENTUMKLINIKJN
        {
            get
            {
                return chkEigentumKlinikJN.Checked;
            }

            set
            {
                chkEigentumKlinikJN.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EIGENTUMKLIENTJN
        {
            get
            {
                return chkEigentumKlientJN.Checked;
            }

            set
            {
                chkEigentumKlientJN.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool MIETEJN
        {
            get
            {
                return chkMieteJN.Checked;
            }

            set
            {
                chkMieteJN.Checked = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string EIGENTUEMER
        {
            get
            {
                return tbEigentuemer.Text.Trim();
            }

            set
            {
                tbEigentuemer.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime LETZTEUEBERPRUEFUNGAM
        {
            get
            {
                if (dtLetzteUeberpruefungAm.Value == null)
                    return DateTime.MinValue;
                else
                    return dtLetzteUeberpruefungAm.DateTime;
            }

            set
            {
                dtLetzteUeberpruefungAm.Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime NAECHSTEUEBERPRUEFUNGAM
        {
            get
            {
                if (dtNaechsteUeberpruefungAm.Value == null)
                    return DateTime.MinValue;
                else
                    return dtNaechsteUeberpruefungAm.DateTime;
            }

            set
            {
                dtNaechsteUeberpruefungAm.Value = value;
            }
        }
        #endregion




        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }
            base.OnKeyDown(e);
        }

        private void chkEigentumKlinikJN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEigentumKlinikJN.Checked)
            {
                chkEigentumKlientJN.Checked = false;
                chkMieteJN.Checked = false;
                tbEigentuemer.Text = "";
                tbEigentuemer.Visible = false;
            }
        }

        private void chkEigentumKlientJN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEigentumKlientJN.Checked)
            {
                chkEigentumKlinikJN.Checked = false;
                chkMieteJN.Checked = false;
                tbEigentuemer.Text = "";
                tbEigentuemer.Visible = false;
            }
        }

        private void chkMieteJN_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMieteJN.Checked == true)
            {
                chkEigentumKlinikJN.Checked = false;
                chkEigentumKlientJN.Checked = false;
                tbEigentuemer.Visible = true;
            }
        }

        private void CheckEigentum()
        {
            //Es darf nur eine der drei Checkboxen angehakt sein

            if (EIGENTUMKLINIKJN == true)
            {
                chkEigentumKlientJN.Checked = false;
                chkMieteJN.Checked = false;
                tbEigentuemer.Text = "";
                tbEigentuemer.Visible = false;
            }
            else if (EIGENTUMKLIENTJN == true)
            {
                chkEigentumKlinikJN.Checked = false;
                chkMieteJN.Checked = false;
                tbEigentuemer.Text = "";
                tbEigentuemer.Visible = false;
            }
            else if (MIETEJN == true)
            {
                chkEigentumKlinikJN.Checked = false;
                chkEigentumKlientJN.Checked = false;
                tbEigentuemer.Visible = true;
            }


            int i = 1; 


        }

    }
}