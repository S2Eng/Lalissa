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

    public partial class frmLogManager2 : Form
    {

        

        public frmLogManager2()
        {
            InitializeComponent();
        }

        private void frmLogManager2_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                this.contLogManager21.mainWindow = this;
                this.contLogManager21.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmLogManager2.initControl: " + ex.ToString());
            }
        }

    }

}
