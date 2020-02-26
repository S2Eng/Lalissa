using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{
    

    public partial class frmAerzteEdit : QS2.Desktop.ControlManagment.baseForm 
    {

        public System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected2 = new List<PMDS.Global.UIGlobal.eSelectedNodes>();

        private bool _SaveChanges = true;
        private bool _CanClose = true;
        public bool _CanModify = true;



        public frmAerzteEdit()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen speichern Ja / Nein
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool SaveChanges
        {
            get { return _SaveChanges; }
            set{_SaveChanges = value;}
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Klasse Aerzte lesen / setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Aerzte CLASS_AERZTE
        {
            get { return ucArztEdit1.CLASS_AERZTE; }
            set {ucArztEdit1.CLASS_AERZTE = value;}
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// IDPatient lesen / setzen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return ucArztEdit1.IDPatient; }
            set { ucArztEdit1.IDPatient = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Spalte Auswahl anzeigen Ja \ Nein
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowAuswahlColumn
        {
            get { return ucArztEdit1.ShowAuswahlColumn; }
            set { ucArztEdit1.ShowAuswahlColumn = value;}
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// ID alle Ausgewählte Ärzte zurückgeben
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid[] Aerzte
        {
            get { return ucArztEdit1.Aerzte;}
            set { ucArztEdit1.Aerzte = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktuelle Arzt Datenzeile ermitteln
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsAerzte.AerzteRow CurrentArztRow
        {
            get {return ucArztEdit1.CurrentArztRow;}
        }

        public bool CanModify
        {
            get { return _CanModify; }
            set
            {
                _CanModify = value;
                ucArztEdit1.CanModify = _CanModify; ;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SaveChanges)
                ucArztEdit1.Write();

            _CanClose = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _CanClose = true;
        }

        private void frmAerzteEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_CanClose;
        }

        private void frmAerzteEdit_Load(object sender, EventArgs e)
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnKlientenMehrfachauswahl_Click(object sender, EventArgs e)
        {
            try
            {
                PMDS.GUI.GUI.Main.frmPatientenmehrfachauswahl frmPatientenmehrfachauswahl1 = new GUI.Main.frmPatientenmehrfachauswahl();
                frmPatientenmehrfachauswahl1.lstPatienteSelected = this.lstPatienteSelected2;
                frmPatientenmehrfachauswahl1.initControl();
                frmPatientenmehrfachauswahl1.ShowDialog(this);
                if (!frmPatientenmehrfachauswahl1.abort)
                {
                    this.lstPatienteSelected2 = frmPatientenmehrfachauswahl1.lstPatienteSelected;
                    this.btnKlientenMehrfachauswahl.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl") + " (" + this.lstPatienteSelected2.Count.ToString() + ")";
                    if (this.lstPatienteSelected2.Count > 0)
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Red;
                    }
                    else
                    {
                        this.btnKlientenMehrfachauswahl.Appearance.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("KlientenMehrfachauswahl: " + ex.ToString());
            }
        }
    }
}