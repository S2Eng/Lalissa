using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI
{
    public partial class frmPflegeplan2 : frmBase
    {
        public frmPflegeplan2()
        {
            InitializeComponent();
        }

        private void frmPflegeplan2_Load(object sender, EventArgs e)
        {
            ucPflegeplan21.IDAUFENTHALT = ENV.IDAUFENTHALT;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ucPflegeplan21.Save())
            {
                btnSave.Enabled = false;
                btnRefresh.Enabled = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ucPflegeplan21.Undo();
            btnSave.Enabled = false;
            btnRefresh.Enabled = false;
        }

        private void ucPflegeplan21_ValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
        }
    }
}