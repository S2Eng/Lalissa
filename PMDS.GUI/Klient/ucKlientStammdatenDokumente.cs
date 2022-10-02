using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace PMDS.GUI.Klient
{


    public partial class ucKlientStammdatenDokumente : UserControl
    {
        public ucKlientStammdatenDokumente()
        {
            InitializeComponent();
        }

        private void ucKlientStammdatenDokumente_Load(object sender, EventArgs e)
        {
            this.ucKlientStammdatenDokument1.mainWindow = this;
        }

        public void ShowPDFViewer( byte[] byt)
        {

            PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();
            if (frmPDF.OpenPDFFromByte(byt))
            {
                frmPDF.SetCaption = "";
                frmPDF.ShowBookmarks = false;
                frmPDF.ShowOpenDialog = false;
                frmPDF.ShowPrintDialog = true;
                frmPDF.Show();
            }
        }
        public void DisablePDFViewer()
        {
            //this.pdfViewer.Document.Dispose();
            //pdfViewer.Visible = false;
            //pdfToolStripZoom.Visible = false;
        }
    }
}
