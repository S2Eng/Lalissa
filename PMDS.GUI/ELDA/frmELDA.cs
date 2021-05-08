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

            }
        }

        private void CheckStartable()
        {
            try
            {
                if (File.Exists(txtXlsx.Text) && CheckDirWritable(txtTxt.Text))
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

            }

        }

        private bool CheckDirWritable (string filename)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(filename))
                    return false;

                PermissionSet permissionSet = new PermissionSet(PermissionState.None);
                FileIOPermission writePermission = new FileIOPermission(FileIOPermissionAccess.Write, Path.GetDirectoryName(filename));
                permissionSet.AddPermission(writePermission);
                return permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);
            }
            catch (Exception ex)
            {
                return false;
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
            OpenFileDialog1.Filter = "Excel Dateien |*.xlsx";
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
            List<string> res = new List<string>();

            PMDS.Global.db.cELDAInterfaceDB ELDA = new PMDS.Global.db.cELDAInterfaceDB();
            if (ELDA.Init(txtXlsx.Text, txtTxt.Text, ref res))
            {
                rtbLog.Text = res[1];
                rtbTxt.Text = res[0];
            }
            else
            {
                rtbTxt.Text = "";
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
