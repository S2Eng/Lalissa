using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using QS2.Resources;




namespace qs2.design.auto.print
{


    public partial class frmSqlConsoleForAdmin : Form
    {
        


        public frmSqlConsoleForAdmin()
        {
            InitializeComponent();
        }

        private void frmSqlConsoleForAdmin_Load(object sender, EventArgs e)
        {

        }


        public void initControlxy(string sqlCommandForAdmin, qs2.ui.print.infoQry infoQryRunPar)
        {
            try
            {
                this.Icon = getRes.getIcon(QS2.Resources.getRes.ePicture.ico_Queries, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("SqlConsoleForAdmin");

                this.contSqlConsoleForAdmin1.mainForm = this;
                this.contSqlConsoleForAdmin1.initControl(sqlCommandForAdmin, infoQryRunPar, true);

            }
            catch (Exception ex)
            {
                throw new Exception("frmSqlConsoleForAdmin.initControl: " + ex.ToString());
            }
        }


    }
}
