//----------------------------------------------------------------------------
/// <summary>
///	ucBigBenutzerAuswahl.cs
/// Erstellt am:	30.4.2008
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
using PMDS.Data.Global;
using VirtualKeyboard;
using PMDS.Global.db.Global;

namespace PMDS.GUI.BaseControls
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// UserControl zur Auswahl einer Abteilung für den Touchscreen
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class ucBigBenutzerAuswahl : QS2.Desktop.ControlManagment.BaseControl
    {

        private UltraButton _selectedButton = null;

        public event EventHandler SelectionChanged;
        public event CancelEventHandler DroppingDown;

        private int     _ButtonHeight = 40;
        private int     _ButtonWidth = 160;
        private Guid    _IDBenutzer = Guid.Empty;

        private int _X = 0;
        private int _Y = 0;
        private int _WIDTH = 800;
        private int _HEIGHT = 600;
        private bool _openinghandled = false;


         

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDBENUTZER
        {
            get { return _IDBenutzer; }
            set { _IDBenutzer = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die höhe der Buttons zur Benutzerwahl
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ButtonHeight
        {
            get { return _ButtonHeight; }
            set { _ButtonHeight = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die breite  der Buttons zur Benutzerwahl
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int ButtonWidth
        {
            get { return _ButtonWidth; }
            set { _ButtonWidth = value; }
        }

        public ucBigBenutzerAuswahl()
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
        public void InitControl(int iButtonHeight, int iButtonWidth)
        {
            ButtonHeight = iButtonHeight;
            ButtonWidth = iButtonWidth;
            RefreshBenutzerListe(Guid.Empty);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Im Panel die Abteilungen als große Buttons aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshBenutzerListe(Guid IDAbteilung)
        {
            pnlBenutzer.Controls.Clear();
            pnlBenutzer.BackColor = Color.WhiteSmoke;
            pnlBenutzer.BorderStyle = BorderStyle.FixedSingle;
            btnBenutzer.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pfleger wählen");

            dsGUIDListe.IDListeDataTable dt;
            
            if (IDAbteilung != Guid.Empty)
                dt = Benutzer.AllPfleger(IDAbteilung);
            else
                dt = Benutzer.AllPfleger();

            PMDS.DB.PMDSBusiness PMDSBusiness1 = new PMDS.DB.PMDSBusiness();
            int height = 0;
            foreach (dsGUIDListe.IDListeRow r in dt)
            {
                PMDS.db.Entities.Benutzer rUsr = PMDSBusiness1.getUser(r.ID);
                if (rUsr.AktivJN != null && (bool)rUsr.AktivJN)
                {
                    UltraButton b = new UltraButton();
                    b.Height = ButtonHeight;
                    b.Width = ButtonWidth;
                    b.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
                    b.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat;
                    b.Appearance.BackColor = Color.WhiteSmoke;
                    b.Appearance.BorderColor = Color.Gray;
                    b.Appearance.FontData.SizeInPoints = 11;
                    b.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    b.Text = r.TEXT;
                    b.Tag = r.ID;

                    b.Click += new EventHandler(b_Click);
                    pnlBenutzer.Controls.Add(b);
                    height += ButtonHeight + b.Margin.Top + b.Margin.Bottom;
                }
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Handler für die Button Clicks
        /// </summary>
        //----------------------------------------------------------------------------
        void b_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            UltraButton b       = ((UltraButton)sender);
            ResetButtonColors();
            b.Appearance.BackColor = Color.Blue;
            b.Appearance.ForeColor = Color.White;
            _selectedButton = b;
            tbKennwort.Focus();
           
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Farben der Buttons rücksetzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ResetButtonColors()
        {
            foreach (Control c in pnlBenutzer.Controls)
            {
                UltraButton br = (UltraButton)c;
                br.Appearance.BackColor = Color.WhiteSmoke;
                br.Appearance.ForeColor = Color.Black;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die region des Popups setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void SetPopupRegion(int x, int y, int width, int height)
        {
            _X = x;
            _Y = y;
            _WIDTH = width;
            _HEIGHT = height;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Popupbereich setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ultraPopupControlContainer1_Opening(object sender, CancelEventArgs e)
        {
            tbKennwort.Text = "";
            ResetButtonColors();
            _selectedButton = null;
            if (_openinghandled)
                return;

            ucVKey.PlayKlick();
            _openinghandled = true;
            pnlAbtList.Width = _WIDTH;
            pnlAbtList.Height = _HEIGHT;
            pnlAbtList.BackColor = Color.White;
            pnlAbtList.BorderStyle = BorderStyle.FixedSingle;
            ultraPopupControlContainer1.Show(new Point(_X, _Y));
            e.Cancel = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Handler
        /// </summary>
        //----------------------------------------------------------------------------
        private void ultraPopupControlContainer1_Closed(object sender, EventArgs e)
        {
            _openinghandled = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Gelb bei betreten des Feldes
        /// </summary>
        //----------------------------------------------------------------------------
        private void tbKennwort_Enter(object sender, EventArgs e)
        {
            tbKennwort.Appearance.BackColor = Color.Yellow;
            if(!ucVKeyboardUniversal1.Enabled )
                ucVKeyboardUniversal1.Enabled = true;
            btnAnmelden.Enabled = true;
            btnKorrektur.Enabled = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Weiß bei verlassen des Feldes
        /// </summary>
        //----------------------------------------------------------------------------
        private void tbKennwort_Leave(object sender, EventArgs e)
        {
            tbKennwort.Appearance.BackColor = Color.White;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Anmelden
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnAnmelden_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            // Login durchführen und ggf. Meldung bei Fehler
            if (_selectedButton == null)
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte einen Benutzer auswählen", "Benutzer wählen", MessageBoxButtons.OK);
                //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte einen Benutzer auswählen", "Benutzer wählen", MessageBoxButtons.OK, this, false);
                return;
            }

            Benutzer ben = new Benutzer((Guid)_selectedButton.Tag);
            if (!ben.HasPasswort(tbKennwort.Text.Trim()))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Kennwort", "Falsches Kennwort", MessageBoxButtons.OK);
                //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Kennwort", "Falsches Kennwort", MessageBoxButtons.OK, this, false);
                return;
            }
            if (!ben.HasRight(UserRights.Rueckmelden))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Benutzer verfügt nicht über das notwendige Recht um Massnahmen zu melden", "Ungenügende Rechte", MessageBoxButtons.OK);
                //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Benutzer verfügt nicht über das notwendige Recht um Massnahmen zu melden", "Ungenügende Rechte", MessageBoxButtons.OK, this, false);
                return;
            }

            _IDBenutzer = (Guid)_selectedButton.Tag;
            btnBenutzer.Text = _selectedButton.Text;
            ultraPopupControlContainer1.Close();
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
           
        }

        private void btnKorrektur_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            tbKennwort.Text = "";
            tbKennwort.Focus();
        }

        private void btnBenutzer_DroppingDown(object sender, CancelEventArgs e)
        {
            btnBenutzer.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pfleger wählen");
            if (DroppingDown != null)
                DroppingDown(sender, e);
        }
    }
}
