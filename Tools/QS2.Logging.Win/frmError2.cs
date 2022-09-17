using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace QS2.Logging
{
    public partial class frmError2 : Form
    {


        public frmError2()
        {
            InitializeComponent();
            this.CancelButton = this.ucError21.btnSend;
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            this.ucError21.modalWindow = this;
        }

        public void setData(string title, string exep, string usr)
        {
            this.ucError21.modalWindow = this;
            this.ucError21.setData(title, exep, usr);
        }
    }
}
