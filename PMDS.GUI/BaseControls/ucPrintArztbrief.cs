using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



namespace PMDS.GUI.BaseControls
{
    
    public partial class ucPrintArztbrief : QS2.Desktop.ControlManagment.BaseControl
    {

        public PMDS.GUI.ucSiteMapKlientenDetails mainWindow = null;         //lthArztabrechnung

        


        public ucPrintArztbrief()
        {
            InitializeComponent();            
        }
        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Property für Checkbox Freiheitsbeschränkung visibility  {{{eng}}} 24.10.2007
        /// </summary>
        //-----------------------------------------------------------------------------------------------------
        public bool chkFreiHeitVisible
        {
            get { return true; }
            set
            {
                //lthArztabrechnung
            }           
        }                     
               
        private void btnPrintStammdaten_Click(object sender, EventArgs e)
        {
            //lthArztabrechnung
            btnPrintSettings.CloseUp();
            this.mainWindow.printArztbrief();
        }
       
    }
}
