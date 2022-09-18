using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace qs2.design.auto
{
    
    public partial class frmTestColors : Form
    {



        public frmTestColors()
        {
            InitializeComponent();
        }

        private void frmTestColors_Load(object sender, EventArgs e)
        {
            try
            {
                ultraComboEditor1.Items.Add("1", "Text1 aaa");
                ultraComboEditor1.Items.Add("2", "Text2 bbb");
                ultraComboEditor1.Items.Add("3", "Text3 ccc");
                ultraComboEditor1.Items.Add("4", "Text4 ddd");
                ultraComboEditor1.Items.Add("5", "Text5 eee");
                ultraComboEditor1.Items.Add("6", "Text6 fff");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error. " + ex.ToString());
            }
        }

        


        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void ultraComboEditor1_AfterCloseUp(object sender, EventArgs e)
        {

        }
        private void ultraComboEditor1_AfterDropDown(object sender, EventArgs e)
        {

        }

    }
}
