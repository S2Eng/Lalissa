using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucAdditionalASZMToPDx : QS2.Desktop.ControlManagment.BaseControl
    {
        private KatalogEditModes _mode = KatalogEditModes.M;
        private dsEintrag.EintragDataTable _massnahmen = null;
        private Guid _IDPDx;
        public event ASZMtoPDxDelegate ASZMtoPDx;
        private List<Guid> _aAbteilungen = new List<Guid>();
        private bool _cbPflegePlanVisible = true; 

        public ucAdditionalASZMToPDx()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning) return;
            InitAbteilungen();
        }

        public void SetPDxAndMode(Guid IDPDX, KatalogEditModes mode)
        {
            _IDPDx = IDPDX;
            _mode = mode;
            InitErrorProvider();
            UpdateGUI();
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert den aktuelen Modus als Eintraggruppe
        /// </summary>
        //----------------------------------------------------------------------------
        private EintragGruppe CURRENTGRUPPE
        {
            get
            {
                return (EintragGruppe)Enum.Parse(typeof(EintragGruppe), _mode.ToString());
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Value
        /// </summary>
        //----------------------------------------------------------------------------
        private Guid Value
        {
            get { return ucPicker1.Value == null ? Guid.Empty : (Guid)ucPicker1.Value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Checkbox "in den Pflegeplan übernehmen" anzeigen oder verstecken
        /// </summary>
        //----------------------------------------------------------------------------
        public bool CbPflegeplanVisible
        {
            get { return _cbPflegePlanVisible; }
            set
            {
                _cbPflegePlanVisible = value;
                cbPflegeplan.Visible = value;
            }
        }

        public void UpdateGUI()
        {
            if (_IDPDx == Guid.Empty) return;
            PDx p = new PDx();
            dsPDx.PDXRow row = p.ReadOne(_IDPDx);
            tbText.Text = row.Klartext;
            tbDefinition.Text = row.Definition;
            _massnahmen = new PDx().KATALOGE[CURRENTGRUPPE.ToString()[0]].EINTRAEGE;
            ucPicker1.isEintragPicker = true;
            ucPicker1.DataSource = _massnahmen;
            ucPicker1.DisplayMember = "TextWarnhinweis";
            ucPicker1.ValueMember = "ID";

        }

        private void InitErrorProvider()
        {
            errorProvider1.SetError(lbAbteilungen, "");
            errorProvider1.SetError(ucPicker1, "");
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Feldprüfung durchführen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            // Abteilungsliste aufbauen
            _aAbteilungen.Clear();
            bool bError = false;
            if (cbStandard.Checked)
            {
                foreach (HelperIDText h in lbAbteilungen.CheckedItems)
                    _aAbteilungen.Add(h.ID);
                if (_aAbteilungen.Count == 0)
                {
                    errorProvider1.SetError(lbAbteilungen, ENV.String("ERROR_MISSINGFIELDS"));
                    bError = true;
                }
                else
                {
                    errorProvider1.SetError(lbAbteilungen, "");
                }
            }

            if (cbPflegeplan.Checked)
            {
                if (Value == Guid.Empty)
                {
                    bError = true;
                    errorProvider1.SetError(ucPicker1, ENV.String("ERROR_MISSINGFIELDS"));
                }
                else
                {
                    errorProvider1.SetError(ucPicker1, "");
                }
            }

            if (bError)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), "Error", MessageBoxButtons.OK, 
                                                                            MessageBoxIcon.Stop, true);
                return false;
            }

            return true;
        }

        private void InitAbteilungen()
        {
            // Abteilungsliste aufbauen
            lbAbteilungen.Items.Add(new HelperIDText("für alle Abteilungen", Guid.Empty));

            /*  //<210120127>
            foreach (dsAbteilung.AbteilungRow r in Klinik.Default().Abteilungen.Abteilungen)
            {
                if (r.ID.ToString() != "00000000-0000-0000-0000-000000000000") lbAbteilungen.Items.Add(new HelperIDText(r.Bezeichnung, r.ID)); 
            }
            */
        }



        private void ucAdditionalASZMToPDx_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                ucPicker1.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbPflegeplan.Checked)
            {
                if (!ValidateFields()) return;
                if (ASZMtoPDx != null)
                    ASZMtoPDx(_IDPDx, Value, CURRENTGRUPPE, cbStandard.Checked, _aAbteilungen.ToArray());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _aAbteilungen.Clear();
            if (ASZMtoPDx != null)
                ASZMtoPDx(_IDPDx, Guid.Empty, CURRENTGRUPPE, cbStandard.Checked, _aAbteilungen.ToArray());
        }

        private void ucPicker1_Selected(ucPicker.PickerSelectedArgs args)
        {
            if (cbPflegeplan.Checked)
            {
                if (!ValidateFields()) return;
                if (ASZMtoPDx != null)
                    ASZMtoPDx(_IDPDx, Value, CURRENTGRUPPE, cbStandard.Checked, _aAbteilungen.ToArray());
            }
        }


        public void setControlsAktivDisable(bool bOn)
        {
            //panelButtons.Visible = !bOn;
            //PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);

        }

        private void ucAdditionalASZMToPDx_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmASZM frm = new frmASZM(_mode);
            DialogResult res = frm.ShowDialog();
            if (frm.CURRENT_SELECTED == Guid.Empty)
                return;

            _massnahmen = new PDx().KATALOGE[CURRENTGRUPPE.ToString()[0]].EINTRAEGE;
            ucPicker1.DataSource = _massnahmen;


            ucPicker1.Value = frm.CURRENT_SELECTED;
        }

        private void cbStandard2_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void cbPflegeplan_CheckedChanged(object sender, EventArgs e)
        {
            cbStandard.Enabled = cbPflegeplan.Checked;
            lbAbteilungen.Enabled = cbPflegeplan.Checked;
        }

        private void cbStandard_CheckedChanged(object sender, EventArgs e)
        {
            lbAbteilungen.Enabled = cbStandard.Checked;
        }



    }
}
