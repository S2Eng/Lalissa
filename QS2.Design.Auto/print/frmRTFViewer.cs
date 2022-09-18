using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QS2.Resources;


namespace qs2.design.auto.print
{
    public partial class frmRTFViewer : Form
    {
        private string Rpt;
        private qs2.ui.print.infoQry InfoQuery;
        private qs2.ui.print.infoReport InfoReport;

        public frmRTFViewer()
        {
            InitializeComponent();
        }

        private void contRTFViewer1_Load(object sender, EventArgs e)
        {
            Icon = getRes.getIcon(getRes.Allgemein2.ico_Winword, 32, 32);
            Text = qs2.core.language.sqlLanguage.getRes("frmRTFViewer", "ALL", "ALL", false, true);
        }

        public void Init(string InRpt, qs2.ui.print.infoQry InInfoQuery, qs2.ui.print.infoReport InInfoReport)
        {
            Rpt = InRpt;
            InfoQuery = InInfoQuery;
            InfoReport = InInfoReport;
            contRTFViewer1.Init();
        }

        private void frmRTFViewer_Shown(object sender, EventArgs e)
        {
            contRTFViewer1.LoadDocument(Rpt, InfoQuery, InfoReport);
        }
    }
}
