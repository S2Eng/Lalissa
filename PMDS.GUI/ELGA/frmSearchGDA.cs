using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.ELGA
{

    public partial class frmSearchGDA : Form
    {

        public bool IsInitialized = false;



        public frmSearchGDA()
        {
            InitializeComponent();
        }

        private void FrmSearchGDA_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("frmSearchGDA.contELGARights: " + ex.ToString());
            }
        }

    }
}
