using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.ELGA
{


    public partial class contELGAKlient : UserControl
    {

        public ucKlient mainWindow = null;
        public bool IsInitialized = false;




        public contELGAKlient()
        {
            InitializeComponent();
        }
        private void contELGAKlient_Load(object sender, EventArgs e)
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
                throw new Exception("contELGAKlient.initControl: " + ex.ToString());
            }
        }


        public void loadData()
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.loadData: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {



                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }



                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAKlient.saveData: " + ex.ToString());
            }
        }

    }

}
