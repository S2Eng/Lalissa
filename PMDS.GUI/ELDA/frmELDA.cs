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
using System.Security;
using System.Security.Permissions;

namespace PMDS.GUI.ELDA
{
    public partial class frmELDA : Form
    {
        public frmELDA()
        {
            InitializeComponent();
        }

        private void txtXlsx_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckStartable();
            }
            catch (Exception ex)
            {
                //Nichts tun.
            }
        }

        private void CheckStartable()
        {
            try
            {
                if (File.Exists(txtXlsx.Text) && PMDS.Global.generic.CheckDirWritable(txtTxt.Text))
                {
                    btnStart.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //Nichts tun.
            }
        }

        private void btnPickTxt_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.DefaultExt = ".txt";
            SaveFileDialog1.Filter = "Text Dateien|*.txt";
            SaveFileDialog1.InitialDirectory = PMDS.Global.ENV.ELDA_Pfad;
            DialogResult resSave = SaveFileDialog1.ShowDialog();
            if (resSave == DialogResult.OK)
            {
                txtTxt.Text = SaveFileDialog1.FileName;
            }
        }

        private void btnPickXlsx_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            OpenFileDialog1.Filter = "Excel Dateien|*.xlsx;*.xlsm";
            OpenFileDialog1.InitialDirectory = PMDS.Global.ENV.ELDA_Pfad;
            DialogResult res = OpenFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtXlsx.Text = OpenFileDialog1.FileName;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!PMDS.Global.ENV.lic_ELDA)
            {
                rtbLog.Text = "Sie haben keine Lizenz für diese Funktion.";
                return;
            }

            if (!PMDS.Global.ENV.HasRight(PMDS.Global.UserRights.AbrechnungInkoProdukte))
            {
                rtbLog.Text = "Sie haben kein Recht für diese Funktion.";
                return;
            }

            rtbLog.Text = "";
            rtbTxt.Text = "";

            PMDS.Global.db.cELDAInterfaceDB ELDA = new PMDS.Global.db.cELDAInterfaceDB();
            if (ELDA.Init(txtXlsx.Text, txtTxt.Text, out List<string> res))
            {
                if (res.Count == 2)
                {
                    rtbLog.Text = res[1];
                    rtbTxt.Text = res[0];
                }
                else
                {
                    rtbLog.Text = "Es ist ein Fehler bei der Erstellung der ELDA-Datei aufgetreten.";
                }
            }
        }

        private void txtTxt_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckStartable();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
