using PMDS.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public partial class frmDatenExport : Form
    {
        public bool bInit { get; set; }
        private Guid IDPatient = Guid.Empty;
        private TXTextControl.TextControl txtEditor = null;
        private System.Guid IDKlinik;
        public bool DocuSuccessfullyGenerated { get; set; }
        public string FileNamePDFDocument { get; set; } = "";
        private ENV.eKlientenberichtTyp KlientenberichtTyp;
        private ENV.eDatenexportTyp DatenexportTyp;

        public frmDatenExport()
        {
            InitializeComponent();
        }

        public bool Init(System.Guid IDPatient, TXTextControl.TextControl txtEditor, System.Guid IDKlinik, ENV.eKlientenberichtTyp KlientenberichtTyp, ENV.eDatenexportTyp DatenexportTyp)
        {
            try
            {
                if (bInit)
                {
                    return true;
                }

                this.IDPatient = IDPatient;
                this.txtEditor = txtEditor;
                this.IDKlinik = IDKlinik;
                this.KlientenberichtTyp = KlientenberichtTyp;
                this.DatenexportTyp = DatenexportTyp;


                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                this.Text = "Datenexport";

                if (this.KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention)
                {
                    this.Text += " (Blackout-Prävention)";
                    this.optDatenexportTyp.Items[0].CheckState = CheckState.Checked;
                    this.optDatenexportTyp.Enabled = false;
                }
                else
                {
                    this.optDatenexportTyp.Items[2].CheckState = CheckState.Checked;
                    this.optDatenexportTyp.Enabled = true;
                }

                this.lblTarget.Text = "Das Ergebnis wird im Archivpfad gespeichert: \n" + ENV.ArchivPath;
                this.RTFLog.Enabled = false;
                this.RTFLog.Text = "";
                this.bInit = true;

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception("PMDS.GUI.frmDatenExport.Init" + ex.ToString());
            }
        }

        private void btnArchivErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                ENV.IgnoreMaxIdleTime = true;    //Vorübergehend die Bildschirmsperre ausschalten, weil sonst die Verarbeitung unterbricht

                this.RTFLog.Enabled = true;
                bool res = GuiAction.Datenarchivierung(this.IDPatient, ref this.txtEditor, this.IDKlinik, out bool tmpDocuSuccessfullyGenerated, out string tmpFileNamePDFDocument, this.KlientenberichtTyp, this.DatenexportTyp, ref RTFLog);
                this.DocuSuccessfullyGenerated = tmpDocuSuccessfullyGenerated;
                this.FileNamePDFDocument = tmpFileNamePDFDocument;
            }
            catch (Exception ex)
            {
                throw new Exception("PMDS.GUI.frmDatenExport.btnArchivErstellen_Click" + ex.ToString());
            }
            finally
            {
                ENV.IgnoreMaxIdleTime = false;
            }
        }

        private void optDatenexportTyp_ValueChanged(object sender, EventArgs e)
        {
            if (this.optDatenexportTyp.CheckedIndex == 0)
                this.DatenexportTyp = ENV.eDatenexportTyp.aktiv;
            else if (this.optDatenexportTyp.CheckedIndex == 1)
                this.DatenexportTyp = ENV.eDatenexportTyp.entlassen;
            else if (this.optDatenexportTyp.CheckedIndex == 2)
                this.DatenexportTyp = ENV.eDatenexportTyp.alle;
        }
    }
}
