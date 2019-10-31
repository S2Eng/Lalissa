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

    public partial class frmCDAViewer : Form
    {



        public frmCDAViewer()
        {
            InitializeComponent();
        }


        private void FrmCDAViewer_Load(object sender, EventArgs e)
        {
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }

        public void initControl(string DocumentName, string ELGADocuUniqueId, string ClinicalDocumentSetID, string Xml, string typeFile, string Stylesheet, contCDAViewer.eTypeUI TypeUI)
        {
            this.contCDAViewer1.mainWindow = this;
            this.contCDAViewer1.initControl(DocumentName, ELGADocuUniqueId, ClinicalDocumentSetID, Xml, typeFile, Stylesheet, TypeUI);
        }


    }


}

