using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.Global.db.ERSystem
{



    public partial class FrmStatusAndProtocoll : Form
    {



        public FrmStatusAndProtocoll()
        {
            InitializeComponent();
        }


        private void FrmStatusAndProtocoll_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);
                this.lblStatus.Text = "";
            }
            catch(Exception ex)
            {
                ENV.HandleException(ex);
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
                ENV.HandleException(ex);
            }
        }


    }
}
