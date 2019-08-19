using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using PMDS.Global;

namespace EDIFact
{



    public partial class contEdiFactViewer : QS2.Desktop.ControlManagment.BaseControl
    {

        public frmEdiFactViewer MainWindow = null;
        public bool isInitialized = false;

        private Font printFont;
        private StreamReader streamToPrint;
        private string BefundFile = "";

        public string _BefundType = "";
        public string _sTxtBefundReady = "";
        public byte[] _sTxtByte;
        public bool _IsInForm = false;
        public bool _IsInitialized = false;
        public EDIFact.cBefund _Befund = null;

        public contEdiFactViewer()
        {
            System.Globalization.CultureInfo currentCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo;
        }
        
        private void EdiFactViewer_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("EDIFact.view: " + ex.ToString());
            }
        }
        public void initControl(string sTxtBefundReady, byte[] bByte, bool IsInForm, string BefundType,  EDIFact.cBefund Befund)
        {
            try
            {
                this._BefundType = BefundType;
                this._Befund = Befund;

                if (!this.isInitialized)
                {
                    this.btnOpenBefund.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Oeffnen, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnCopyText.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Kopieren, QS2.Resources.getRes.ePicTyp.ico);
                    this.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);

                    if (this.MainWindow != null)
                    {
                        this.MainWindow.CancelButton = this.btnClose;
                        this.btnClose.Visible = true;

                    }
                    else
                    {
                        this.btnClose.Visible = false;
                    }
                    this.isInitialized = true;
                }
                
                if (sTxtBefundReady.Trim() != "")
                {
                    this._sTxtBefundReady = sTxtBefundReady;
                    this._sTxtByte = null;
                }

                if (bByte != null)
                {
                    this._sTxtBefundReady = "";
                    this._sTxtByte = bByte;
                }


                if (!IsInForm)
                {
                    this.showBefund(this._BefundType, Befund);
                }

                this._IsInitialized = true; 

            }
            catch (Exception ex)
            {
                throw new Exception("EdiFactViewer.initControl: " + ex.ToString());
            }
        }

        private void btnOpenBefund_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EDIFact EDIFact1 = new EDIFact();
                EDIFact1.openBefund(ref this.textControl1);

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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.MainWindow != null)
                {
                    this.MainWindow.Close(); 
                }
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
        private void btnCopyText_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                System.Windows.Forms.Clipboard.SetDataObject(this.textControl1.Text.Trim());

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.textControl1.PrintPreview("");
                
                /*
                byte[] byteArray = Encoding.UTF8.GetBytes(this.textControl1.Text.Trim());
                MemoryStream stream = new MemoryStream(byteArray);
                streamToPrint = new StreamReader(stream);
                try
                {
                    printFont = new Font("lucida console", 9);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler (this.pd_PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                    //stream.Close();
                }
                */
            }
            catch (Exception ex)
            {
                throw new Exception(e.ToString());
            }

        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top / 2;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Print each line of the file. 
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page. 
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        private void contEdiFactViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this._IsInitialized)
            {
                this.showBefund(this._BefundType, this._Befund);
            }
        }

        public void showBefund(string BefundType, EDIFact.cBefund Befund)
        {

            if (Befund != null)
            {
                if (this._sTxtBefundReady.Trim() != "")
                {
                    EDIFact.show(this.textControl1, Befund);
                }
                else if (this._sTxtByte != null && BefundType.Equals(ENV.BefundTypText(eBefundTyp.PDF), StringComparison.CurrentCultureIgnoreCase))
                {
                    EDIFact.show(this.textControl1, Befund);
                }
                else if (this._sTxtByte != null && BefundType.Equals(ENV.BefundTypText(eBefundTyp.DICOM), StringComparison.CurrentCultureIgnoreCase))
                {
                    EDIFact.show(this.textControl1, Befund);
                }
            }
        }

    }
}
