using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace qs2.design.auto.print
{
    public partial class frmQryAdminSelectChapter : Form
    {


        public frmQryAdminSelectChapter()
        {
            InitializeComponent();
        }


        private void frmQryAdminSelectChapter_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string Chapters, string Chapter, string IDApplication)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_QS2, 32, 32);
                this.Text = qs2.core.language.sqlLanguage.getRes("SelectChapter");

                this.contQryAdminSelectChapter1.mainWindow = this;
                this.contQryAdminSelectChapter1.initControl(Chapters, Chapter, IDApplication);

            }
            catch (Exception ex)
            {
                throw new Exception("frmQryAdminSelectChapter.initControl: " + ex.ToString());
            }
        }

    }

}

