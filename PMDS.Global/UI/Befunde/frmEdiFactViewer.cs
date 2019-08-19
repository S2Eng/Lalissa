using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace EDIFact
{


    public partial class frmEdiFactViewer : Form
    {

        public frmEdiFactViewer()
        {
            InitializeComponent();
        }


        private void frmImportBefunde1_Load(object sender, EventArgs e)
        {

        }

        public void initControl(string File, string Dummy, string Dummy2)
        {
            try
            {
                EDIFact.cBefund Befund = EDIFact.ReadBefundFile(File, false);
                initControl1(Befund.txtEdiFactFilePrintable, Befund);
            }
            catch (Exception ex)
            {
                throw new Exception("frmImportBefunde.initControl: " + ex.ToString());
            }
        }

        public void initControl1(string sTxtBefundReady, EDIFact.cBefund Befund )
        {
            try
            {
                string Absender = Befund.Absender;
                string BefundType = Befund.DateiType;
                byte[] bByte = Befund.byteEdiFactFile;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32);

                this.contEdiFactViewer1.MainWindow = this;
                this.contEdiFactViewer1.initControl(sTxtBefundReady, bByte, true, BefundType, Befund);
            }
            catch (Exception ex)
            {
                throw new Exception("frmImportBefunde.initControl1: " + ex.ToString());
            }
        }


    }
}
