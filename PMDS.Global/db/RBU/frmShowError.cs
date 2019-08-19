using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RBU
{
    public partial class frmShowError : Form
    {
        public frmShowError(string sError)
        {
            InitializeComponent();
            tbError.Text = sError;
        }
    }
}
