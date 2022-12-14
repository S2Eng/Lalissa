using PMDS.Global;
using PMDS.Global.db.Patient;
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
        private System.Guid IDKlinik;
        public bool DocuSuccessfullyGenerated { get; set; }
        public string FileNamePDFDocument { get; set; } = "";
        private ENV.eKlientenberichtTyp KlientenberichtTyp;
        private ENV.eDatenexportTyp DatenexportTyp;


        public frmDatenExport()
        {
            InitializeComponent();
        }

        public bool Init(System.Guid IDPatient, System.Guid IDKlinik, ENV.eKlientenberichtTyp KlientenberichtTyp, ENV.eDatenexportTyp DatenexportTyp)
        {
            try
            {
                this.IDPatient = IDPatient;
                this.IDKlinik = IDKlinik;
                this.KlientenberichtTyp = KlientenberichtTyp;
                this.DatenexportTyp = DatenexportTyp;


                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_Klientenakt.ico_ArchivTerminemail, 32, 32);
                this.Text = "Datenexport";

                this.chkPDFExport.Checked = true;
                this.chkPDFExport.Enabled = true;
                this.chkXMLExport.Checked = true;
                this.chkXMLExport.Enabled = true;

                if (this.KlientenberichtTyp == ENV.eKlientenberichtTyp.blackoutprevention)
                {
                    this.Text += " (Blackout-Prävention)";
                    this.optDatenexportTyp.Items[0].CheckState = CheckState.Checked;
                    this.optDatenexportTyp.Enabled = false;
                    this.chkXMLExport.Checked = false;
                    this.chkXMLExport.Enabled = false;
                }
                else
                {
                    this.optDatenexportTyp.Items[2].CheckState = CheckState.Checked;
                    this.optDatenexportTyp.Enabled = true;
                }

                if (IDPatient != Guid.Empty)
                {
                    this.optDatenexportTyp.Visible = false;                    
                }
                else
                {
                    this.optDatenexportTyp.Visible = true;
                    //Kein PDFA-Export bei Massenexport
                    this.chkPDFA.Checked = false;
                    this.chkPDFA.Visible = false;
                }

                this.lblTarget.Text = "Das Ergebnis wird im Archivpfad gespeichert: " + ENV.ArchivPath;
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
                bool res = GuiAction.Datenarchivierung(this.IDPatient, this.IDKlinik,
                                                        out bool tmpDocuSuccessfullyGenerated, out string tmpFileNamePDFDocument,
                                                        this.KlientenberichtTyp, this.DatenexportTyp, ref RTFLog,
                                                        this.chkPDFExport.Checked, this.chkXMLExport.Checked, this.chkPDFA.Checked,
                                                        ref this.lblKlient);

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

        private void RTFLog_TextChanged(object sender, EventArgs e)
        {
            //Ans Ende scrollen
            RTFLog.SelectionStart = RTFLog.Text.Length;
            RTFLog.ScrollToCaret();
        }

        private void chkPDFExport_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkPDFExport.Checked)
            {
                this.chkPDFA.Checked = false;
                this.chkPDFA.Enabled = false;
            }
            else
            {
                this.chkPDFA.Enabled = true;
            }
        }
    }
}
