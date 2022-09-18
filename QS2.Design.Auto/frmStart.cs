using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QS2.Resources;





namespace qs2.design.auto
{


    public partial class frmStart : Form
    {

        public static string txtStartinfo = "";
        public static bool closeWindow = false;

    








        public frmStart()
        {
            InitializeComponent();

            this.pictureBoxLogIn.Image = getRes.getImage(QS2.Resources.getRes.ePicture.QS2_10cm_RGB, getRes.ePicTyp.jpg);
            Application.DoEvents();
            this.timer1.Start();
        }


        private void frmStart_Load(object sender, EventArgs e)
        {
            
        }

        private void ultraActivityIndicator1_Click(object sender, EventArgs e)
        {

        }

        private void ultraLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txtInfo.Text = frmStart.txtStartinfo.Trim();
            if (frmStart.closeWindow)
            {
                this.timer1.Stop();
                this.Visible = false;
                Application.DoEvents();
            }
            //Application.DoEvents();
        }

        private void frmStart_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                qs2.core.ui.doForegroundWindow(this);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
    }
}
