using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.STAMP
{
    public partial class frmSTAMP : Form
    {
        public frmSTAMP()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!PMDS.Global.ENV.lic_STAMP)
            {
                rtbLog.Text = "Sie haben keine Lizenz für diese Funktion.";
                return;
            }
            rtbLog.Text = "";
            //rtbTxt.Text = "";

            PMDS.Global.db.cSTAMPInterfaceDB STAMP = new PMDS.Global.db.cSTAMPInterfaceDB();
            STAMP.init(DateTime.Now);
        }
    }
}
