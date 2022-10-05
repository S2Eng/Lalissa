using System;
using System.ComponentModel;
using Infragistics.Win.Misc;
using Infragistics.Win;
using Infragistics.Win.UltraWinToolTip;
using S2Extensions;

namespace qs2.sitemap.ownControls.inherit_Infrag
{
    public class InfragButton : UltraButton
    {
        private Enum _ico;
        private string _icoTxt = "";
        private IContainer components;
        private qs2.core.Enums.eSize _size;
        private UltraToolTipInfo toolTipButton = new UltraToolTipInfo();
        private bool _autoTextYN = true;

        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;

        public InfragButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SuspendLayout();
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.AutoPopDelay = 0;
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.InitialDelay = 0;
            this.ResumeLayout(false);
            this.Appearance.ImageHAlign = HAlign.Right;
            this._size = core.Enums.eSize.big;
        }

        public void initControl()
        {
            this.ownAutoText();
        }

        public string OwnPictureTxt
        {
            get => this._icoTxt;
            set
            {
                this._icoTxt = value;
                if (!string.IsNullOrWhiteSpace(_icoTxt))
                {
                    this.Appearance.Image = this._icoTxt.Trim().Equals(QS2.Resources.getRes.ePicture.none.ToString(), StringComparison.OrdinalIgnoreCase) ? null : QS2.Resources.getRes.getImageFromTxt(_icoTxt, 32, 32);
                }
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") 
                    this.ownAutoText();
            }
        }
        
        public Enum OwnPicture
        {
            get => this._ico;
            set
            {
                if (value == null)
                {
                    this.Appearance.Image = null;
                    return;
                }

                this._ico = value;
                this.Appearance.Image = this._ico.ToString().Trim().Equals(QS2.Resources.getRes.ePicture.none.ToString(), StringComparison.OrdinalIgnoreCase) ? null : QS2.Resources.getRes.getImage(value, 32, 32);
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") 
                    this.ownAutoText();
            }
        }
        
        public bool  OwnAutoTextYN
        {
            get => this._autoTextYN;
            set
            {
                this._autoTextYN = value;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") 
                    this.ownAutoText();
            }
        }

        public void ownAutoText()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
            {
                return;
            }

            if (!(this._autoTextYN & this._size == core.Enums.eSize.big)) 
                return;
            
            if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Minus))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Delete");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Speichern))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Save");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Speichern))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("SaveAs");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Suche))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Search");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Rückgängig))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Reset");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Aktualisieren))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Refresh");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Drucken))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Print");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein2.ico_Ordner))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Open");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Plus))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Add");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein2.ico_Info))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("about");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.ePicture.ico_adjustments))  //Settings!
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("adjustments");
            }
            else if (this._ico.sEquals(QS2.Resources.getRes.Allgemein.ico_Bearbeiten))
            {
                this.Text = qs2.core.language.sqlLanguage.getRes("Edit");
            }
        }

        public qs2.core.Enums.eSize OwnSizeMode
        {
            get => this._size;
            set
            {
                this._size = value;
                switch (this._size)
                {
                    case core.Enums.eSize.big:
                        this.Appearance.ImageHAlign = HAlign.Right;
                        break;
                    case core.Enums.eSize.small:
                        this.Appearance.ImageHAlign = HAlign.Center;
                        break;
                }
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") 
                    this.ownAutoText();
            }
        }

        public string  OwnTooltipText
        {
            get => this.toolTipButton.ToolTipText;
            set
            {
                this.toolTipButton.ToolTipText = value;
                this.ultraToolTipManager1.SetUltraToolTip(this, this.toolTipButton);
           }
        }

        public string OwnTooltipTitle
        {
            get => this.toolTipButton.ToolTipTitle;
            set
            {
                this.toolTipButton.ToolTipTitle = value;
                this.ultraToolTipManager1.SetUltraToolTip(this, this.toolTipButton);
            }
        }
    }
}
