using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QS2.Resources;



namespace QS2.Logging
{


    public partial class frmLogManager : Form
    {
        


        public frmLogManager()
        {
            InitializeComponent();
        }

        private void frmLogManag_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.CancelButton = this.contLogViewer1.btnClose2;
                this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_log, 32, 32);
                this.contLogViewer1.mainWindow = this;
                this.contLogViewer1.initControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
