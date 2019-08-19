using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{
    public partial class ucFormAsses : QS2.Desktop.ControlManagment.BaseControl
    {

        public event Infragistics.Win.UltraWinExplorerBar.ItemClickEventHandler   evClickEvent;



        public ucFormAsses()
        {
            InitializeComponent();
        }

        private void ucFormAsses_Load(object sender, EventArgs e)
        {

        }

        private void ubMain_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            this.evClickEvent(sender, e);
        }
    }
}
