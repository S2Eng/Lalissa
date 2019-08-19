using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.Quickfilter
{

    public partial class contQuickfilter2 : UserControl
    {

        public bool abort = true;
        public frmQuickfilter2 mainWindow = null;

        public bool IsInitialized = false;






        public contQuickfilter2()
        {
            InitializeComponent();
        }

        private void contQuickfilter2_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {


                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contQuickfilter2.initControl: " + ex.ToString());
            }
        }


    }

}
