using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI
{
    public partial class ucWarnung : QS2.Desktop.ControlManagment.BaseControl
    {
        public ucWarnung()
        {
            InitializeComponent();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void ClearInfos()
        {
            lbInfo.Items.Clear();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        public void AddInfo(string infoText)
        {
            lbInfo.Items.Add(infoText);
            this.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
