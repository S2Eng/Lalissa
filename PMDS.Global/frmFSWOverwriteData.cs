using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace PMDS.Global
{
    public partial class frmFSWOverwriteData : Form
    {
        public string ID { get; set; }
        public string sTitle { get; set; }
        public decimal dPflegeNetto { get; set; }
        public int iPflegeTage { get; set; }
        public decimal dBWNetto  { get; set; }
        public int iBWTage { get; set; }
        public decimal dGesamtNetto { get; set; }
        public int iOverrideDays { get; set; }
        public int iBWOverrideDays { get; set; }
        public DateTime dtMonth { get; set; }
        public bool isValid { get; set; }

        private bool canClose { get; set; }
        private string sInfoTextDefault;
        private int iMaxDaysInMonth = 0;
        private string FileKorr = "";
        private int iDaysTotalInit = 0;

        private Pars cPars = new Pars();

        public frmFSWOverwriteData()
        {
            InitializeComponent();
        }

        public class Pars
        {
            public decimal dPflegeNetto;
            public int iPflegeTage;
            public decimal dBWNetto;
            public int iBWTage;
            public DateTime Timestamp;
            public string Description;
            public DateTime Abrechungsmonat;
        }

        public void Init (string inID, string insTitle, decimal indPflegeNetto, int iniPflegeTage, decimal indBWNetto, int iniBWTage, decimal indGesamtNetto, DateTime indtMonth) 
        {

            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            sInfoTextDefault = "Es wurde eine Abweichung erkannt, die nicht automatisch behoben werden kann.\n";
            sInfoTextDefault += "Ursachen dafür können Selbstzahler und FSW-Leistungen innerhalb eines Monats oder wechselnde Zahler / Leistungen innerhalb eines Monats sein.\n\n";
            sInfoTextDefault += "Bitte korrigieren Sie die Nettobeträge für die jeweilige Leistung im Monat, die an den FSW verrechnet werden sollen.";
            sTitle = "FSW-eZAUFF: Manuelle Korrektur erforderlich für " + insTitle;

            iDaysTotalInit = iniPflegeTage + iniBWTage;
            dPflegeNetto = indPflegeNetto;
            iPflegeTage = iniPflegeTage;
            dBWNetto = indBWNetto;
            iBWTage = iniBWTage;
            dGesamtNetto = indGesamtNetto;
            dtMonth = indtMonth;
            iMaxDaysInMonth = System.DateTime.DaysInMonth(dtMonth.Year, dtMonth.Month);
            FileKorr = Path.Combine(ENV.FSW_EZAUF, inID + ".FSWKorrData");

            //Suche, ob es für die ID schon erfasste Werte gibt und einlesen (statt jedesmal erneut eingeben)
            if (File.Exists(FileKorr))
            {
                TextReader reader = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(Pars));
                    reader = new StreamReader(FileKorr);
                    cPars = (Pars)serializer.Deserialize(reader);
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

                lblSavedData.Text = "Gespeicherte Daten von " + cPars.Timestamp.ToString("dd.MM.yyyy HH:mm");
                lblSavedData.Visible = true;
                dPflegeNetto = cPars.dPflegeNetto;
                iPflegeTage = cPars.iPflegeTage;
                dBWNetto = cPars.dBWNetto;
                iBWTage = cPars.iBWTage;
            }
 
            this.Text = sTitle;
            lblInfoText.Text = sInfoTextDefault;

            numdPflegeErrechnet.Value = dPflegeNetto;
            numdBWErrechnet.Value = dBWNetto;
            numdNettoGesamtErrechnet.Value = dGesamtNetto;

            numdPflegeNettoSoll.Value = dPflegeNetto;
            numiDays.Value = iPflegeTage;
            numdBWNettoSoll.Value = dBWNetto;
            numiBWDays.Value = iBWTage;
            numdNettoGesamtSoll.Value = dPflegeNetto + dBWNetto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Es werden die berechneten (wahrscheinlich falschen)  Werte verwendet.\nWollen Sie trotzdem fortsetzen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            dPflegeNetto = Convert.ToDecimal(numdPflegeNettoSoll.Value);
            dBWNetto = Convert.ToDecimal(numdBWNettoSoll.Value);

            string sMsg = "";

            if (iPflegeTage + iBWTage == iDaysTotalInit)
            {
                sMsg += "Die Anzahl der Tage ist unverändert.\n\n";
            }

            if ((int)numiDays.Value + (int)numiBWDays.Value < 1 ||(int)numiDays.Value + (int)numiBWDays.Value  > iMaxDaysInMonth)
            {
                sMsg += "Die Anzahl der Tage muss zwischen 1 und " + iMaxDaysInMonth.ToString() + " liegen.\n\n";
            }

            if (dPflegeNetto + dBWNetto != dGesamtNetto)
            {
                sMsg += "Die Summe der manuell erfassten Beträge unterscheidet sich von der berechneten Netto-Gesamtsumme.\n\n";
            }

            if (!String.IsNullOrWhiteSpace(sMsg))
            {
                DialogResult res = MessageBox.Show(sMsg +"Wollen Sie trotzdem fortsetzen?", "Hinweis", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                //Werte für später sichern
                cPars.dPflegeNetto = dPflegeNetto;
                cPars.iPflegeTage = iPflegeTage;
                cPars.dBWNetto = dBWNetto;
                cPars.iBWTage = iBWTage;
                cPars.Timestamp = DateTime.Now;
                cPars.Description = this.sTitle;
                cPars.Abrechungsmonat = dtMonth;

                TextWriter writer = null;
                try
                {
                    var serializer = new XmlSerializer(typeof(Pars));
                    writer = new StreamWriter(FileKorr);
                    serializer.Serialize(writer, cPars);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
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

        private void numiDays_ValueChanged(object sender, EventArgs e)
        {
            iPflegeTage = Convert.ToInt32(numiDays.Value);
            iOverrideDays = iPflegeTage;
        }

        private void numiBWDays_ValueChanged(object sender, EventArgs e)
        {
            iBWTage = Convert.ToInt32(numiBWDays.Value);
            iBWOverrideDays = iBWTage;
        }
    }
}
