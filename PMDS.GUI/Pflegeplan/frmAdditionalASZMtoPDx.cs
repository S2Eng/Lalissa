using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class frmAdditionalASZMtoPDx : QS2.Desktop.ControlManagment.baseForm 
    {
        public event ASZMtoPDxDelegate  ASZMtoPDx;

        private KatalogEditModes        _mode;
        private Guid                    _IDPDx;
        private bool _cbPflegePlanVisible = true; //Neu nach 31.07.2007 MDA

        public frmAdditionalASZMtoPDx(KatalogEditModes mode, Guid IDPDx)
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
            _mode   = mode;
            _IDPDx  = IDPDx;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn in der Form eine ASZM hinzugefügt wurde, dann die Auswahlliste aktualisieren
        /// und auf die entsprechende Auswahl setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmASZM frm = new frmASZM(_mode);
            DialogResult res = frm.ShowDialog();
            if (frm.CURRENT_SELECTED == Guid.Empty)
                return;
            cbASZM.RefreshList(frm.CURRENT_SELECTED);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Load
        /// </summary>
        //----------------------------------------------------------------------------
        private void frmAdditionalASZMtoPDx_Load(object sender, EventArgs e)
        {
            cbASZM.GROUP = CURRENTGRUPPE;

            // Abteilungsliste aufbauen
            lbAbteilungen.Items.Add(new HelperIDText("für alle Abteilungen", Guid.Empty));

            //<20120127>
            /*
            foreach (dsAbteilung.AbteilungRow r in Klinik.Default().Abteilungen.Abteilungen)
            {
                if (r.ID.ToString() != "00000000-0000-0000-0000-000000000000") lbAbteilungen.Items.Add(new HelperIDText(r.Bezeichnung, r.ID));   
            }
            */
            lblAuswahlInfo.Text = ENV.String(_mode.ToString());
            PDx p = new PDx();
            dsPDx.PDXRow row = p.ReadOne(_IDPDx);
            lblMainInfo.Text = row.Definition;
            this.Text = row.Klartext;

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

        //----------------------------------------------------------------------------
        /// <summary>
        /// Feldprüfung durchführen
        /// </summary>
        //----------------------------------------------------------------------------
        private bool ValidateFieldsAndSignal()
        {
            // Abteilungsliste aufbauen
            List<Guid> aAbteilungen = new List<Guid>();
            bool bError = false;
            if (cbStandard.Checked)
            {
                foreach (HelperIDText h in lbAbteilungen.CheckedItems)
                    aAbteilungen.Add(h.ID);
                if (aAbteilungen.Count == 0)
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
                if (cbASZM.ID == Guid.Empty)
                {
                    bError = true;
                    errorProvider1.SetError(cbASZM, ENV.String("ERROR_MISSINGFIELDS"));
                }
                else
                {
                    errorProvider1.SetError(cbASZM, "");
                }
            }

            if (bError)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), "Error", 
                                                                        MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                return false;
            }

            if(ASZMtoPDx != null)
                ASZMtoPDx(_IDPDx, cbASZM.ID, CURRENTGRUPPE, cbStandard.Checked, aAbteilungen.ToArray());
            
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Verlassen: Zur Zeit soll es nur möglich sein einen einzigen zu melden
        /// Deshalb wird im Validate gleich signalisiert (lt. os)
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (cbPflegeplan.Checked)
            {
                if (!ValidateFieldsAndSignal())
                    return;
            }
            this.Close();
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