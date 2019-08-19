﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PMDS.GUI.GenericControls
{

    
    public partial class frmMessageBox : Form
    {
        public bool abort = true;



        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string sMessage)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

                this.txtMessage.Text = sMessage;

            }
            catch (Exception ex)
            {
                throw new Exception("frmMessageBox.initControl: " + ex.ToString());
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = false;
                this.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
