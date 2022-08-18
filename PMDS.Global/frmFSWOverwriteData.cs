using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.Global
{
    public partial class frmFSWOverwriteData : Form
    {

        public string sTitle { get; set; }
        public decimal dPflegeNetto { get; set; }
        public decimal dBWNetto  { get; set; }
        public decimal dGesamtNetto { get; set; }
        public bool isValid { get; set; }
        private bool canClose { get; set; }

        private string sInfoTextDefault;

        public frmFSWOverwriteData()
        {
            InitializeComponent();
        }

        public void Init (string insTitle, decimal indPflegeNetto, decimal indBWNetto, decimal indGesamtNetto) 
        {

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

            sInfoTextDefault = "Es wurde eine Abweichung erkannt, die nicht automatisch behoben werden kann.\n";
            sInfoTextDefault += "Ursachen dafür können Selbstzahler und FSW-Leistungen innerhalb eines Monats oder wechslende Zahler / Leistungen innerhalb eines Monats sein.\n\n";
            sInfoTextDefault += "Bitte korrigieren Sie die Nettobeträge für die jeweilige Leistung im Monat, die an den FSW verrechnet werden sollen.";
            sTitle = "FSW-eZAUFF: Manuelle Korrektur erforderlich für " + insTitle;
            dPflegeNetto = indPflegeNetto;
            dBWNetto = indBWNetto;
            dGesamtNetto = indGesamtNetto;

            this.Text = sTitle;
            lblInfoText.Text = sInfoTextDefault;

            numdPflegeErrechnet.Value = dPflegeNetto;
            numdBWErrechnet.Value = dBWNetto;
            numdNettoGesamtErrechnet.Value = dGesamtNetto;

            numdPflegeNettoSoll.Value = dPflegeNetto;
            numdPflegeNettoSoll.Value = dBWNetto;
            numdNettoGesamtSoll.Value = dPflegeNetto + dBWNetto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Es werden die berechneten Werte (wahrscheinlich falschen) verwendet.\nWollen Sie trotzdem fortsetzen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                isValid = false;
                canClose = true;
            }
            else
            {
                canClose = false;
            }
        }

        private void baseButton2_Click(object sender, EventArgs e)
        {
            dPflegeNetto = Convert.ToDecimal(numdPflegeNettoSoll.Value);
            dBWNetto = Convert.ToDecimal(numdBWNettoSoll.Value);

            if (dPflegeNetto + dBWNetto != dGesamtNetto)
            {
                DialogResult res = MessageBox.Show("Die Summe der manuell erfassten Positionen unterscheidet sich von der berechneten Netto-Gesamtsumme.\nWollen Sie trotzdem fortsetzen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    isValid = false;
                    canClose = true;
                }
                else
                {
                    canClose = false;
                }
            }
            else
            {
                isValid = true;
                canClose = true;
            }
        }

        private void numdPflegeNettoSoll_ValueChanged(object sender, EventArgs e)
        {
            UpdateCalc();
        }

        private void UpdateCalc()
        {
             numdNettoGesamtSoll.Value = Convert.ToDecimal(numdPflegeNettoSoll.Value) + Convert.ToDecimal(numdBWNettoSoll.Value);
        }

        private void numdBWNettoSoll_ValueChanged(object sender, EventArgs e)
        {
            UpdateCalc();
        }

        private void frmFSWOverwriteData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !canClose;
        }
    }
}
