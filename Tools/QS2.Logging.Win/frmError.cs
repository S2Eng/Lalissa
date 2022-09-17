using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace QS2.Logging
{
    public partial class frmError : Form
    {


        public frmError()
        {
            InitializeComponent();
            this.CancelButton = this.ucError1.btnClose2;
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            this.ucError1.modalWindow = this;
        }

        public void setData(string title, string exep, string usr, bool WriteDataToXML)
        {
            this.ucError1.modalWindow = this;
            this.ucError1.setData(title, exep, usr, WriteDataToXML);
        }
    }
}
