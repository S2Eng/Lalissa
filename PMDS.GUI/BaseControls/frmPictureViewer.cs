using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PMDS.GUI.BaseControls
{

    public partial class frmPictureViewer : Form
    {

        public Bitmap bmpSlaced = null;
        public Image imgOrigLoaded = null;
        public string _PicToLoad = "";

        public bool abort = true;

        public PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new Global.db.ERSystem.PMDSBusinessUI();





        public frmPictureViewer()
        {
            InitializeComponent();
        }

        private void frmPictureViewer_Load(object sender, EventArgs e)
        {

        }


        public void initControl(string PicToLoad)
        {
            try
            {
                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);

                this._PicToLoad = PicToLoad;
                this.scalePicture();
            }
            catch (Exception ex)
            {
                throw new Exception("frmPictureViewer.initControl: " + ex.ToString());
            }
        }

        public void scalePicture()
        {
            try
            {
                using (Image img = Image.FromFile(this._PicToLoad))
                {
                    this.imgOrigLoaded = img;
                    double dWidth = System.Convert.ToDouble(this.numWidthHeight.Value);

                    this.bmpSlaced = null;
                    if (img.Height > img.Width)
                    {
                        if (img.Height <= (int)this.numWidthHeight.Value)
                        {
                            this.bmpSlaced = new Bitmap(img);
                        }
                        else
                        {
                            this.bmpSlaced = this.bUI.ResizePicByWidth(img, dWidth, false);
                        }
                    }
                    else
                    {
                        if (img.Width <= (int)this.numWidthHeight.Value)
                        {
                            this.bmpSlaced = new Bitmap(img);
                        }
                        else
                        {
                            this.bmpSlaced = this.bUI.ResizePicByWidth(img, dWidth, true);
                        }
                    }

                    this.picViewer.Image = this.bmpSlaced;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmPictureViewer.initControl: " + ex.ToString());
            }
        }


        private void btnScalePicture_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.scalePicture();

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
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = false;
                this.Close();

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
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

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

    }

}

