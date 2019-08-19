using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win;




namespace PMDS.GUI.BaseControls
{
    public partial class ucClickableImage : QS2.Desktop.ControlManagment.BaseControl
    {
        private int     _index      = -1;
        private bool    _Selected   = false;
        public Nullable<Guid> _IDFormular = null;
        public string txtOriginal = "";
        public string XMLFile = "";






        public int Index
        {
            get { return _index; }
        }

        public string LabelText
        {
            get
            {
                return lblInfo.Text;
            }
        }

        public Image IMAGE
        {
            get
            {
                //return (Image)pbMain.Image;
                return QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenliste.ico_Klientenakt, QS2.Resources.getRes.ePicTyp.ico);
            }
        }

        public ucClickableImage()
        {
            InitializeComponent();
        }

        public ucClickableImage(String sFile, string sText, string sToolTip, int iIndex, Color LabelBackgroundColor)
        {
            InitializeComponent();
            lblInfo.Text = sText;
            lblInfo.Appearance.BackColor = LabelBackgroundColor;
            if (sToolTip != "")
            {
                UltraToolTipInfo info = new UltraToolTipInfo(sToolTip, Infragistics.Win.ToolTipImage.Info, "", Infragistics.Win.DefaultableBoolean.True);
                ultraToolTipManager1.SetUltraToolTip(pbMain, info);
            }
            RefreshImage(sFile);
            _index = iIndex;
        }

        public ucClickableImage(Image image, string sText, string sToolTip, int iIndex)
        {
            InitializeComponent();
            this.setData(image, sText, sToolTip, iIndex, true);
        }
        public void  setData(Image image, string sText, string sToolTip, int iIndex, bool  doImg)
        {
            lblInfo.Text = sText;
            if (sToolTip != "")
            {
                UltraToolTipInfo info = new UltraToolTipInfo(sToolTip, Infragistics.Win.ToolTipImage.Info, "", Infragistics.Win.DefaultableBoolean.True);
                ultraToolTipManager1.SetUltraToolTip(pbMain, info);
            }
            if (doImg)  pbMain.Image = image;
            _index = iIndex;

        }

        public bool Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        private void RefreshImage(Image image)
        {
            pbMain.Image = null;
            pbMain.Image = image;
        }

        private void RefreshImage(String sFile)
        {
            try
            {
                pbMain.Image = null;

                if (!File.Exists(sFile))
                {
                    UltraToolTipInfo info = new UltraToolTipInfo(sFile, Infragistics.Win.ToolTipImage.Error, "", Infragistics.Win.DefaultableBoolean.True);
                    ultraToolTipManager1.SetUltraToolTip(pbMain, info);
                    return;
                }

                using (FileStream fs = new FileStream(sFile, FileMode.Open, FileAccess.Read))
                {
                    pbMain.Image = Image.FromStream(fs);
                    fs.Close();
                }
            }
            catch 
            {
                lblInfo.Text = "Error:" + sFile;
            }
        }

        public bool BORDER
        {
            set
            {
                pbMain.BorderStyle          = value ? UIElementBorderStyle.Solid : UIElementBorderStyle.None;
                lblInfo.BorderStyleOuter    = value ? UIElementBorderStyle.Solid : UIElementBorderStyle.None;
            }
        }

        public Color BACKCOLOR
        {
            set
            {
                pbMain.BackColor = value;
            }
            get
            {
                return pbMain.BackColor;
            }
        }

        private void lblInfo_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(EventArgs.Empty);
        }

        private void pbMain_Click(object sender, EventArgs e)
        {
            this.setOnOff(true);
            Application.DoEvents();
            OnClick(EventArgs.Empty);
        }

        private void pbMain_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void pbMain_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public  void setOnOff(bool bOn)
        {
            if (bOn)
            {
                ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.RoyalBlue;
                this.BorderStyle = BorderStyle.None;
            }

            else
            {
                ultraGridBagLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
                this.BorderStyle = BorderStyle.None;
            }


        }
       
    }
}
