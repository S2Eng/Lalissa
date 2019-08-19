//----------------------------------------------------------------------------
/// <summary>
/// Usercontrol zur Anzeige von Images mit Klickreaktion
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Global;
using PMDS.BusinessLogic;


namespace PMDS.GUI.BaseControls
{
    public partial class ucClickableImages : QS2.Desktop.ControlManagment.BaseControl
    {
        public new event ClickableImagesClickDelegate DoubleClick;          // Wird ausgelöst wenn ein Image doppelt geklickt wird
        public new event ClickableImagesClickDelegate Click;                // Wird ausgelöst wenn ein Image angeklickt wird

        private Size _pictureSize   = new Size(150, 250);                   // Default ca. A4 Hoch
        private bool _Hoover        = true;




        public Size PictureSize
        {
            get { return _pictureSize; }
            set { _pictureSize = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Hoover JN
        /// </summary>
        //----------------------------------------------------------------------------
        public bool Hoover
        {
            get { return _Hoover; }
            set { _Hoover = value;}
        }

        public ucClickableImages()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// fügt ein Clickable Image auf Basis eines Image
        /// </summary>
        //----------------------------------------------------------------------------
        public void AddFromZusatzwert(Image image, string sText, string sToolTip, object Tag, int iIndex)
        {
            ucClickableImage img = new ucClickableImage(image, sText, sToolTip, iIndex);

            img.Tag             = Tag;
            img.DoubleClick     += new EventHandler(img_DoubleClick);
            img.Click           += new EventHandler(img_Click);
            img.MouseEnter      += new EventHandler(img_MouseEnter);
            img.MouseLeave      += new EventHandler(img_MouseLeave);
            img.Width           = _pictureSize.Width;
            img.Height          = _pictureSize.Height;
            img.BORDER          = _Hoover ? false : true;
            img.Selected        = false;
            pnlMain.Controls.Add(img);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// fügt ein Clickable Image auf Basis einer Datei ein
        /// </summary>
        //----------------------------------------------------------------------------
        public ucClickableImage AddFromFile(String sFile, string sText, string sToolTip, object Tag, int iIndex, Color LabelBackgroundColor, Nullable<Guid> IDFormular, string XMLFile)
        {
            ucClickableImage img = new ucClickableImage(sFile, sText, sToolTip, iIndex, LabelBackgroundColor);
            img._IDFormular = IDFormular;

            img.Tag = Tag;
            img.DoubleClick     += new EventHandler(img_DoubleClick);
            img.Click           += new EventHandler(img_Click);
            img.MouseEnter      += new EventHandler(img_MouseEnter);
            img.MouseLeave      += new EventHandler(img_MouseLeave);
            img.Width           = _pictureSize.Width;
            img.Height          = _pictureSize.Height;
            img.BORDER          = _Hoover ? false : true;
            img.Selected        = false;
            img.txtOriginal = sText.Trim();
            img.XMLFile = XMLFile;
            pnlMain.Controls.Add(img);

            return img;
        }

        void img_MouseLeave(object sender, EventArgs e)
        {
            if (!Hoover)
                return;
            ucClickableImage i = (ucClickableImage)sender;
            if (i.Selected)
                return;
            i.BORDER = false;
        }

        void img_MouseEnter(object sender, EventArgs e)
        {
            if (!_Hoover)
                return;
            ucClickableImage i = (ucClickableImage)sender;
            if (i.Selected)
                return;
            i.BORDER = true;
        }

        

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle Images entfernen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RemoveAll()
        {
            this.pnlMain.Controls.Clear();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Doppelklick weiterleiten
        /// </summary>
        //----------------------------------------------------------------------------
        void img_DoubleClick(object sender, EventArgs e)
        {
            if (DoubleClick == null)
                return;
            ucClickableImage uc = (ucClickableImage)sender;
            SetSelected(uc);
            DoubleClick(uc.Index, uc.Tag, uc.XMLFile);
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Click weiterleiten
        /// </summary>
        //----------------------------------------------------------------------------
        void img_Click(object sender, EventArgs e)
        {
            if (Click == null)
                return;
            ucClickableImage uc = (ucClickableImage)sender;
            SetSelected(uc);
            Click(uc.Index, uc.Tag, uc.XMLFile);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Alle deselektieren und das übergebene Selektieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetSelected(ucClickableImage uc)
        {
            foreach (ucClickableImage img in pnlMain.Controls)
            {
                if (uc.Equals(img))
                {
                    img.BORDER = true;
                    img.Selected = true;
                    img.setOnOff(true);
                }
                else if (img.Selected)
                {
                    img.BORDER = false;
                    img.Selected = false;
                    img.setOnOff(false);
                }
            }
        }

    }

    public delegate void ClickableImagesClickDelegate(int index, object Tag, string XMLFile);
}
