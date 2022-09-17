using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace QS2.Logging.Win
{

    public partial class frmErrorDetail : Form
    {

        

        public frmErrorDetail()
        {
            InitializeComponent();
        }

        private void frmErrorDetail_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.CancelButton = this.btnClose;

            }
            catch (Exception ex)
            {
                throw new Exception("frmErrorDetail.initControl: " + ex.ToString());
            }
        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.ToString());
            }
        }
    }

}
