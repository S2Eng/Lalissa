//----------------------------------------------------------------------------
/// <summary>
///	ucBigAbteilungsAuswahl.cs
/// Erstellt am:	29.4.2008
/// Erstellt von:   RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using Infragistics.Win.Misc;
using PMDS.Global.db.Patient;

namespace PMDS.GUI.BaseControls
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// UserControl zur Auswahl einer Abteilung für den Touchscreen
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class ucBigBereichsAuswahl : QS2.Desktop.ControlManagment.BaseControl
    {

        public event EventHandler SelectionChanged;

        private int _ButtonHeight = 40;
        private Guid _IDBereich = Guid.Empty;

         

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDBEREICH
        {
            get { return _IDBereich; }
            set { _IDBereich = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die höhe der Buttons zur Abteilungswahl
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ButtonHeight
        {
            get { return _ButtonHeight; }
            set { _ButtonHeight = value; }
        }

        public ucBigBereichsAuswahl()
        {
            InitializeComponent();
            if (!ENV.AppRunning)
                return;
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Initialisierungsroutine
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitControl(int iButtonHeight)
        {
            ButtonHeight = iButtonHeight;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Im Panel die Abteilungen als große Buttons aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshBereichsListe(Guid IDAbteilung)
        {
            pnlAbtList.Controls.Clear();
            pnlAbtList.BackColor    = Color.WhiteSmoke;
            pnlAbtList.BorderStyle  = BorderStyle.FixedSingle;
            IDBEREICH               = Guid.Empty;
            btnBereich.Text         = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereich wählen");

            dsBereich.BereichDataTable dt = KlinikBereiche.ByAbteilung(IDAbteilung);
            
            int height = 0;
            foreach (dsBereich.BereichRow r in dt)
            {
                UltraButton b           = new UltraButton();
                b.Height                = ButtonHeight;
                b.Width                 = pnlAbtList.Width - b.Margin.Left - b.Margin.Right;
                b.UseOsThemes           = Infragistics.Win.DefaultableBoolean.False ;
                b.ButtonStyle           = Infragistics.Win.UIElementButtonStyle.VisualStudio2005Button;
                b.Appearance.BackColor  = Color.WhiteSmoke;
                b.Text                  = r.Bezeichnung;
                b.Tag                   = r.ID;
                
                b.Click += new EventHandler(b_Click);
                pnlAbtList.Controls.Add(b);
                height += ButtonHeight + b.Margin.Top + b.Margin.Bottom;
            }

            pnlAbtList.Height = height;             // Höhe gemäß Einstellungen anpassen
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Handler für die Button Clicks
        /// </summary>
        //----------------------------------------------------------------------------
        void b_Click(object sender, EventArgs e)
        {
            UltraButton b   = ((UltraButton)sender);
            IDBEREICH       = (Guid)b.Tag;
            btnBereich.Text = b.Text;
            ultraPopupControlContainer1.Close();
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }
    }
}
