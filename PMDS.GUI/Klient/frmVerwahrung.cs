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


    public partial class frmVerwahrung : QS2.Desktop.ControlManagment.baseForm 
    {

        private dsGegenstaende.GegenstaendeRow _row;
        




        public frmVerwahrung()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }


            Init();
            RequiredFields();

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);
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

        private void SetColorBenutzer(QS2.Desktop.ControlManagment.BaseComboEditor cb)
        {
            foreach (Infragistics.Win.ValueListItem valList in cb.Items)
            {
                Benutzer ben2 = new Benutzer((Guid)valList.DataValue);
                if (ben2.AktivJN)
                {
                    valList.Appearance.ForeColor = Color.DarkGreen;
                }
                else
                {
                    valList.Appearance.ForeColor = Color.DarkRed;
                }
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
            SetColorBenutzer(cmbAusgegebenVon);
            SetColorBenutzer(cmbRuecknahme);

            dtpVon.Value = null;
            dtpBis.Value = null;
            cmbAusgegebenVon.Value = null;
            cmbRuecknahme.Value = null;
        }

        public void UpdateGUI()
        {
            if (_row != null)
            {
                if (!_row.IsBeschreibungNull())
                {
                    if (_row.Beschreibung.Trim() != "")
                    {
                        this.tbBeschreibungOrig.Text = _row.Beschreibung.Trim();
                    }
                    BESCHREIBUNGxy = "";
                }
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
            }
        }

        public void AllowEdit(bool bSwitch)
        {
            this.btnOK.Enabled = bSwitch;
        }

        public void UpdateData()
        {
            if (_row != null)
            {
                PMDS.BusinessLogic.Benutzer ben = new Benutzer(ENV.USERID);
                if (this.tbBeschreibungOrig.Text.Trim() != "")
                {
                    _row.Beschreibung = ben.FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ") + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\r\n" + BESCHREIBUNGxy + "\r\n" + " ------------------------------------------------------------------------------------------------" + "\r\n" + this.tbBeschreibungOrig.Text.Trim();
                }
                else
                {
                    if (BESCHREIBUNGxy.Trim() != "")
                    {
                        _row.Beschreibung = ben.FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ") + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "\r\n" + BESCHREIBUNGxy.Trim();
                    }
                }
                
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
            }
        }

        public bool ValidateFields()
        {
            return true;
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
        public string BESCHREIBUNGxy
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

        private void frmVerwahrung_Load(object sender, EventArgs e)
        {

        }

        private void baseLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}