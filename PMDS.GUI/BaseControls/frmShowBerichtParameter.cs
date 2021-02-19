using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;

namespace PMDS.GUI.BaseControls
{
    public partial class frmShowBerichtParameter : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmShowBerichtParameter(List<PMDS.Print.CR.BerichtParameter> lb)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }

            foreach (PMDS.Print.CR.BerichtParameter p in lb)
            {
                ListViewItem i = lvMain.Items.Add(p.Name);
                i.SubItems.Add(p.Value.ToString());
            }
        }

        private void lvMain_ItemActivated(object sender, Infragistics.Win.UltraWinListView.ItemActivatedEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}