using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using Infragistics.Win.Misc;
using Infragistics.Win;

using Infragistics.Win.UltraWinToolTip;
using QS2.Resources;
using System.Reflection.Emit;




namespace qs2.sitemap.ownControls.inherit_Infrag
{
    
    
    public class InfragButton : UltraButton
    {

        public Enum _ico = null;
        public string _icoTxt = "";
        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private IContainer components;
        public qs2.core.Enums.eSize _size = new qs2.core.Enums.eSize();
        public UltraToolTipInfo toolTipButton = new UltraToolTipInfo();
        public bool _autoTextYN = true;







        public InfragButton()
        {
            InitializeComponent();
            //if (this.DesignMode)
            //{
            //    qs2.core.logIn.connectDesignMode();
            //} 
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
            get
            {
                return this._icoTxt;
            }
            set
            {
                this._icoTxt = value;
                if (this._icoTxt.Trim() != "")
                {
                    if (this._icoTxt.Trim().Equals(QS2.Resources.getRes.ePicture.none.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        this.Appearance.Image = null; 
                    }
                    else
                    {
                        this.Appearance.Image = QS2.Resources.getRes.getImageFromTxt(this._icoTxt, 32, 32);
                    }
                }
                if (this.DesignMode) this.ownAutoText();
            }
        }

        
        public Enum OwnPicture
        {
            get
            {
                return this._ico;
            }
            set
            {
                if (value == null)
                {
                    this.Appearance.Image = null;
                    return;
                }

                this._ico = value;
                if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.ePicture.none.ToString(), StringComparison.OrdinalIgnoreCase))
                    this.Appearance.Image = null;
                else
                {
                    this.Appearance.Image = QS2.Resources.getRes.getImage(value, 32, 32);
                }
                if (this.DesignMode) this.ownAutoText();
            }
        }
        
        public bool  OwnAutoTextYN
        {
            get
            {
                return this._autoTextYN;
            }
            set
            {
                this._autoTextYN = value;
                if (this.DesignMode) this.ownAutoText();
            }
        }

        public void ownAutoText()
        {
            if (this._autoTextYN & this._size == core.Enums.eSize.big)
            {
                if (this.DesignMode)
                {
                    return;
                } 

                if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Minus.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Delete");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Speichern.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Save");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Speichern.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("SaveAs");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Suche.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Search");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Rückgängig.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Reset");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Aktualisieren.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Refresh");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Drucken.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Print");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein2.ico_Ordner.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Open");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Plus.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Add");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein2.ico_Info.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("about");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.ePicture.ico_adjustments.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("adjustments");
                }
                else if (this._ico.ToString().Trim().Equals(QS2.Resources.getRes.Allgemein.ico_Bearbeiten.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    this.Text = qs2.core.language.sqlLanguage.getRes("Edit");
                }
            }
        }

        public qs2.core.Enums.eSize OwnSizeMode
        {
            get
            {
                return this._size;
            }
            set
            {
                this._size = value;
                if (this._size == core.Enums.eSize.big )
                {
                    this.Appearance.ImageHAlign = HAlign.Right;
                }
                else if (this._size == core.Enums.eSize.small )
                {
                    this.Appearance.ImageHAlign = HAlign.Center;
                }
                if (this.DesignMode) this.ownAutoText();
            }
        }

        public string  OwnTooltipText
        {
            get
            {
                return this.toolTipButton.ToolTipText;
            }
            set
            {
                this.toolTipButton.ToolTipText = value;
                this.ultraToolTipManager1.SetUltraToolTip(this, this.toolTipButton);
           }
        }

        public string OwnTooltipTitle
        {
            get
            {
                return this.toolTipButton.ToolTipTitle;
            }
            set
            {
                this.toolTipButton.ToolTipTitle = value;
                this.ultraToolTipManager1.SetUltraToolTip(this, this.toolTipButton);
            }
        }

        public Infragistics.Win.UltraWinToolTip.UltraToolTipManager OwnUltraToolTipManager
        {
            get
            {
                return this.ultraToolTipManager1;
            }
            set
            {
                this.ultraToolTipManager1 = value;
            }
        }

    }

}
