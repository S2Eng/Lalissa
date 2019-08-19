﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;





namespace PMDS.GUI.GUI.Main
{



    public partial class frmLogInAnonym : Form
    {


        public frmLogInAnonym()
        {
            InitializeComponent();
        }

        private void frmLogInAnonym_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }
        
        public void initControl()
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);

                this.ucLogInAnonym1.mainWindow = this;
                this.ucLogInAnonym1.initControl();

            }
            catch (Exception ex)
            {
                throw new Exception("frmLogInAnonym.initControl: " + ex.ToString());
            }
        }

    }

}
