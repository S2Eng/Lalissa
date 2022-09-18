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
    public partial class frmPDFViewer : Form
    {
        public frmPDFViewer()
        {
            InitializeComponent();
        }

        private void frmPDFViewer_Load(object sender, EventArgs e)
        {
            Icon = getRes.getIcon(getRes.Allgemein2.ico_PDF, 32, 32);

            if (!qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS).bValue)
                Text = qs2.core.language.sqlLanguage.getRes("TrialVersion") + qs2.core.language.sqlLanguage.getRes("ValidTo") + " " + qs2.core.license.doLicense.GetLicense(qs2.core.Enums.eLicense.LIC_DOCUMENTS_VALID_DATE).dValue.ToString("dd.MM.yyyy");
            else
                Text = qs2.core.language.sqlLanguage.getRes("frmPDFViewer", "ALL", "ALL", false, true);
        }

        public bool Init(string rpt, qs2.ui.print.infoQry InfoQuery, qs2.ui.print.infoReport InfoReport)
        {
            contPDFViewer1.SetToolstrips(false, false, true, true);
            contPDFViewer1.Init(rpt, InfoQuery, InfoReport);
            return true;
        }
    }
}
