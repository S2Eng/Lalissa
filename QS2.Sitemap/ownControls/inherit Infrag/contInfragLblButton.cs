using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win;

using Infragistics.Win.UltraWinToolTip;
using qs2.core.vb;



namespace qs2.sitemap.ownControls.inherit_Infrag
{
    

    public partial class contInfragLblButton : UserControl
    {

        private QS2.Resources.getRes.ePicture _ico = new QS2.Resources.getRes.ePicture();
        private UltraToolTipInfo _toolTipButton = new UltraToolTipInfo();
        private bool _autoTextYN = true;
        private string _IDRessourceText = "";
        private string _IDRessourceToolTipTitle = "";
        private string _IDRessourceToolTipText = "";

        public event EventHandler LabelCLicked;
        private Color _LblForeColor = Color.RoyalBlue;
        private HAlign _TextHAlign = HAlign.Left;





        public contInfragLblButton()
        {
            InitializeComponent();
            this.OwnPicture = QS2.Resources.getRes.ePicture.none;
        }

        private void contInfragLblButton_Load(object sender, EventArgs e)
        {

        }

        
        public void initControl()
        {

        }

        public void doAutoText()
        {
            if (this._autoTextYN)
            {
                if (this.DesignMode)
                    return;

                if (this.DesignMode)
                    qs2.core.logIn.connectDesignMode();

                if (this._IDRessourceText.Trim() != "")
                {
                    this.lblButton.Text = qs2.core.language.sqlLanguage.getRes(this._IDRessourceText);
                }
                else
                {
                    this.lblButton.Text = "";
                }

                if (this.OwnIDRessourceToolTipTitle.Trim() != "")
                {
                    this._toolTipButton.ToolTipTitle = qs2.core.language.sqlLanguage.getRes(this.OwnIDRessourceToolTipTitle);
                }
                else
                {
                    this._toolTipButton.ToolTipTitle = "";
                }
                if (this.OwnIDRessourceToolTipText.Trim() != "")
                {
                    this._toolTipButton.ToolTipText = qs2.core.language.sqlLanguage.getRes(this.OwnIDRessourceToolTipText);
                }
                else
                {
                    this._toolTipButton.ToolTipText = "";
                }
                this.ultraToolTipManager1.SetUltraToolTip(this.lblButton, this._toolTipButton);
            }
            else
            {
                this.lblButton.Text = this._IDRessourceText;
            }
        }

        public string OwnIDRessourceText
        {
            get
            {
                return this._IDRessourceText;
            }
            set
            {
                this._IDRessourceText = value;
                this.doAutoText();
            }
        }
        public string OwnIDRessourceToolTipTitle
        {
            get
            {
                return this._IDRessourceToolTipTitle;
            }
            set
            {
                this._IDRessourceToolTipTitle = value;
                this.doAutoText();
            }
        }
        public string OwnIDRessourceToolTipText
        {
            get
            {
                return this._IDRessourceToolTipText;
            }
            set
            {
                this._IDRessourceToolTipText = value;
                this.doAutoText();
            }
        }
        public bool OwnAutoTextYN
        {
            get
            {
                return this._autoTextYN;
            }
            set
            {
                this._autoTextYN = value;
                this.doAutoText();
            }
        }
        public QS2.Resources.getRes.ePicture OwnPicture
        {
            get
            {
                return this._ico;
            }
            set
            {
                this._ico = value;
                if (this._ico == QS2.Resources.getRes.ePicture.none)
                    this.lblButton.Appearance.Image = null;
                else
                {
                    this.lblButton.Appearance.Image = QS2.Resources.getRes.getImage(value, 32, 32 );
                }
                //if (this.DesignMode) this.ownAutoText();
            }
        }

        private void lblButton_Click(object sender, EventArgs e)
        {
            //if (this.LabelCLicked != null)
            //{
                this.LabelCLicked.Invoke(sender, e); 
            //}
        }

        public Color OwnForeColorLabel
        {
            get
            {
                return this._LblForeColor;
            }
            set
            {
                this._LblForeColor  = value;
                this.lblButton.Appearance.ForeColor = this._LblForeColor;
             }
        }
        public HAlign OwnTextHAlign
        {
            get
            {
                return this._TextHAlign;
            }
            set
            {
                this._TextHAlign = value;
                this.lblButton.Appearance.TextHAlign = this._TextHAlign;

            }
        }
    }
}
