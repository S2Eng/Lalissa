using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace PMDS.Global.UI
{
    



    public partial class frmPictureViewer : Form
    {




        public frmPictureViewer()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }


        private void frmPictureViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        private void frmPictureViewer_Load(object sender, EventArgs e)
        {
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
                {
                    QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                    ControlManagment1.autoTranslateForm(this);
                }

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_NeuesDokument, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, QS2.Resources.getRes.ePicTyp.ico);
                this.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, QS2.Resources.getRes.ePicTyp.ico);

                this.lblInfoPixel.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Breite")  + ": " + this.pictureBox1.Image.Width.ToString() + ", " + QS2.Desktop.ControlManagment.ControlManagment.getRes("Höhe")  +  ": " + this.pictureBox1.Image.Height.ToString() + " (In Pixel)";

            }
            catch (Exception ex)
            {
                throw new Exception("frmPictureViewer_Load: " + ex.ToString());
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.Print();

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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Byte[] imgBytes = null;
                //ImageConverter imgConverter = new ImageConverter();
                //imgBytes = (System.Byte[])imgConverter.ConvertTo(this.pictureBox1.Image, Type.GetType("System.Byte[]"));
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(imgBytes);
                //Image returnImage = Image.FromStream(ms);

                //e.Graphics.DrawImage(returnImage, 0, 0);

                e.Graphics.DrawImage(this.pictureBox1.Image, 0, 0);
            }
            catch (Exception ex)
            {
                throw new Exception("frmPictureViewer.printDocument1_PrintPage: " + ex.ToString());
            }
        }

        private void frmPictureViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            pictureBox1.Image.Dispose();    //os: 160424 - Dispose zum freigeben des extern allokierten Speichers (von ucWundDoku)
            e.Cancel = false;
        }
    }

}
