using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.Messenger
{


    public partial class frmMessenger : Form
    {

        public frmMessenger()
        {
            InitializeComponent();
        }

        private void frmMessenger_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32);

                this.contMessenger1.mainWindow = this;
                this.contMessenger1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmMessenger.initControl: " + ex.ToString());
            }
        }




        private void frmMessenger_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

    }
}
