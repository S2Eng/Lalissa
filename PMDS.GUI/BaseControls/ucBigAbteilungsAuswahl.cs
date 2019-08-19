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
using VirtualKeyboard;
using PMDS.Global.db.Patient;

namespace PMDS.GUI.BaseControls
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// UserControl zur Auswahl einer Abteilung für den Touchscreen
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class ucBigAbteilungsAuswahl : QS2.Desktop.ControlManagment.BaseControl
    {

        public event EventHandler SelectionChanged;

        private int _ButtonHeight = 60;
        
        private Guid _AbteilungsID = Guid.Empty;
        private Guid _BereichsID = Guid.Empty;
        private bool _PreventClickSound = false;

        public Control cMain = null;

         

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDABTEILUNG
        {
            get { return _AbteilungsID; }
            set { _AbteilungsID = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDBEREICH
        {
            get { return _BereichsID; }
            set { _BereichsID = value; }
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

        public ucBigAbteilungsAuswahl()
        {
            InitializeComponent();
            if (!ENV.AppRunning)
                return;
            
        }

        public void DoPopup(int x, int y)
        {
            _PreventClickSound = true;
            ultraPopupControlContainer1.Show(new Point(x,y));
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
        /// Im Panel die Abteilungen als große Bereiche aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshAbteilungsListe(Guid[] aIDAbteilungen, bool loadDefaultKlinik)
        {
            int nMaxButt = 9;
            int anzAbt = 0;
            List<int> aAnzButtInAbteilung = new List<int>();

            Abteilung a = new Abteilung();
            anzAbt = a.ABTEILUNGLISTE.Rows.Count ;
            foreach (dsAbteilung.AbteilungRow r in a.ABTEILUNGLISTE)
            {
                if (!CheckAbteilung(r, aIDAbteilungen) || (r.ID == Guid.Empty))
                    continue;

                aAnzButtInAbteilung.Add(InsertBereichsButtons(null, r, true, aAnzButtInAbteilung, anzAbt, nMaxButt));
                anzAbt +=1;
            }

            //foreach (Control cFound in pnlAbtList.Controls)
            //{
            //    cFound.Visible = true;
            //}

            a = new Abteilung();
            int iAbteilung = 0;

            pnlAbtList.Controls.Clear();
            pnlAbtList.BackColor = Color.WhiteSmoke;
            pnlAbtList.BorderStyle = BorderStyle.FixedSingle;
            btnAbteilung.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Abteilung / Bereich \nwählen");
            int iContrlNr = 0;
            foreach (dsAbteilung.AbteilungRow r in a.ABTEILUNGLISTE)
            {
                if (!CheckAbteilung(r, aIDAbteilungen) || (r.ID == Guid.Empty))
                    continue;

                Panel p = null;
                iContrlNr += 1;
                p = new Panel();

                p.Width     = 120;
                p.Height = 300;
                p.Top = 0;
                p.Left      = GetNextLeft(pnlAbtList) + 8;
                p.BackColor = Color.Gray;
                p.BorderStyle = BorderStyle.FixedSingle;

                InsertAbteilungsButton(p, r, aAnzButtInAbteilung);
                int anzZeilen = InsertBereichsButtons(p, r, false, aAnzButtInAbteilung, iAbteilung, nMaxButt);
                //p.AutoScroll = false;

                //p.Width = (p.Width * anzZeilen) + 100;
                ResizePanel(p);
                pnlAbtList.Controls.Add(p);
                p.AutoScroll = true;
                iAbteilung += 1;
            }

            this.resizeAbteilungen();
            //pnlAbtListeGesamt.Width = this.cMain.Width;
            //pnlAbtListeGesamt.Height = this.cMain.Height - 120;

            //System.Drawing.Size siz = new System.Drawing.Size(this.cMain.Width, this.cMain.Height - 120);
            //this.ultraPopupControlContainer1.PreferredDropDownSize = siz;

            //pnlAbtListeGesamt.Width += 20;
            //pnlAbtListeGesamt.Height += 20;

            _AbteilungsID = Guid.Empty;
            _BereichsID = Guid.Empty;

            //pnlAbtListeGesamt.Top = 330;
            pnlAbtListeGesamt.AutoScroll = true;
            this.pnlKliniken.Visible = true;
            this.pnlAbtList.Visible = true;
        }
        public void resizeAbteilungen()
        {
            this.ResizePanelAll(pnlAbtListeGesamt, pnlAbtList);
            this.btnAbteilung.CloseUp();
            Application.DoEvents();
            this.btnAbteilung.DropDown();
        }
        public void OnValueChangedKlinik(object sender, EventArgs args)
        {
            this.refreshKlinik(true);
        }

        public List<Guid> refreshKlinik(bool refreshAbt)
        {
            Benutzer b = new Benutzer(ENV.USERID);
            dsAbteilung dsAbteilung1 = new dsAbteilung();
            PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
            DBAbteilung1.getAbteilungenByKlinik(ENV.IDKlinik, dsAbteilung1);
            List<Guid> al = new List<Guid>();
            foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
            {
                al.Add(rAbt.ID);
            }

            //List<Guid> al = new List<Guid>();
            //foreach (PMDS.Data.Global.dsBenutzerAbteilung.BenutzerAbteilungRow r in b.BenutzerAbteilung)
            //    al.Add(r.IDAbteilung);

            if (refreshAbt)
                this.RefreshAbteilungsListe(al.ToArray(), false);

            this.resizeAbteilungen();
            return al;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Den Abteilungsbutton erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InsertAbteilungsButton(Panel p, dsAbteilung.AbteilungRow r, List<int> aAnzButtInAbteilung)
        {
            UltraButton b                       = new UltraButton();
            b.Top                               = 0;
            b.Left                              = 0;
            b.Height                            = ButtonHeight;
            b.Width                             = p.Width;
            b.UseOsThemes                       = Infragistics.Win.DefaultableBoolean.False;
            b.ButtonStyle                       = Infragistics.Win.UIElementButtonStyle.Flat;
            b.Appearance.BackColor              = Color.WhiteSmoke;
            b.Appearance.FontData.SizeInPoints  = 12;
            b.Appearance.FontData.Bold          = Infragistics.Win.DefaultableBoolean.True;
            b.Appearance.BorderColor            = Color.Gray;
            b.Text                              = r.Bezeichnung;
            b.Tag                               = new AbtBereich(r.ID, Guid.Empty, r.Bezeichnung);
            b.Click += new EventHandler(b_Click);
            p.Controls.Add(b);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Bereichsbutton erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        private int  InsertBereichsButtons(Panel p, dsAbteilung.AbteilungRow rAbt, bool  nCount,
                    List<int> aAnzButtInAbteilung, int iAbteilung, int nMaxButt)
        {
            dsBereich.BereichDataTable dt = KlinikBereiche.ByAbteilung(rAbt.ID);
            if (nCount) 
            {
                return dt.Rows.Count;
            }
            int leftPos = 20;
            int lastPosTop = 70;
            int anzZeilen = 1;
            int i = 0;
            foreach (dsBereich.BereichRow r in dt)
            {
                if (i >=  nMaxButt)
                {
                    anzZeilen += 1;
                    i = 0;
                    lastPosTop = 70;
                }
             
                UltraButton b                       = new UltraButton();
                leftPos = (b.Width + 30) * (anzZeilen - 1) + 5;

                b.Height                            = ButtonHeight;
                b.Width                             = p.Width -20 ;         // Eingerückt links und rechts Platz
                b.Left = leftPos;
                b.Top = lastPosTop;          //GetNextTop(p);
                b.UseOsThemes                       = Infragistics.Win.DefaultableBoolean.False;
                b.ButtonStyle                       = Infragistics.Win.UIElementButtonStyle.Flat;
                b.Appearance.BorderColor            = Color.Black;
                b.Appearance.FontData.SizeInPoints  = 12;
                b.Appearance.FontData.Bold          = Infragistics.Win.DefaultableBoolean.True;
                b.Appearance.BackColor              = Color.WhiteSmoke;
                b.Text                              = r.Bezeichnung;
                b.Tag                               = new AbtBereich(rAbt.ID, r.ID, rAbt.Bezeichnung + "\n" + r.Bezeichnung);
                
                b.Click += new EventHandler(b_Click);
                p.Controls.Add(b);

                lastPosTop += b.Height + 5;
                
                i += 1;
            }
            return anzZeilen;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Korrigiert die Größe aufgrund des Inhaltes des Panels
        /// </summary>
        //----------------------------------------------------------------------------
        private void ResizePanel(Panel p)
        {
            int x = 0;
            int y = 0;
            foreach (Control c in p.Controls)
            {
                int iw = c.Left + c.Width;
                if (iw > x)
                    x = iw;

                int ih = c.Top + c.Height;
                if (ih > y)
                    y = ih;
            }

            p.Width = x + 7;
            p.Height = y +20;
        }
        private void ResizePanelAll(Panel pAll, Control pAbt)
        {
            int x = 0;
            int y = 0;
            foreach (Control c in pAbt.Controls)
            {
                int iw = c.Left + c.Width;
                if (iw > x)
                    x = iw;

                int ih = c.Top + c.Height;
                if (ih > y)
                    y = ih;
            }

            pAll.Width = x + 7;
            pAll.Height = y + 60;
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Ermittelt die nächste Top Position für den Bereich
        /// </summary>
        //----------------------------------------------------------------------------
        private int GetNextTopxy(Panel p)
        {
            int iMax = 0;
            foreach (Control c in p.Controls)
            {
                int iLast = c.Top + c.Height;
                if (iLast > iMax)
                    iMax = iLast;
            }

            return iMax + 20;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ermittelt die nächste Top Position für den Bereich
        /// </summary>
        //----------------------------------------------------------------------------
        private int GetNextLeft(Panel p)
        {
            int iMax = 0;
            foreach (Control c in p.Controls)
            {
                int iLast = c.Left + c.Width;
                if (iLast > iMax)
                    iMax = iLast;
            }

            return iMax;
        }

       
        //----------------------------------------------------------------------------
        /// <summary>
        /// Prüfen ob die Abteilung in der Liste enthalten ist
        /// </summary>
        //----------------------------------------------------------------------------
        private bool CheckAbteilung(dsAbteilung.AbteilungRow r, Guid[] aIDAbteilungen)
        {
            if (aIDAbteilungen == null)     // keine Einschränkuengen ohne Liste
                return true;
            foreach (Guid g in aIDAbteilungen) // wenn die Abteiluhng vorkommt dann fals esignalisieren 
                if (g == r.ID)
                    return true;
            return false;
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
            AbtBereich ab       = (AbtBereich)b.Tag;
            IDABTEILUNG         = ab._IDAbteilung;
            IDBEREICH           = ab._IDBereich;
            btnAbteilung.Text   = ab._Text;
            ultraPopupControlContainer1.Close();
            SignalSelectionChanged();
        }

        private void SignalSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);
        }

        private void ultraPopupControlContainer1_Opening(object sender, CancelEventArgs e)
        {
            if (!_PreventClickSound) 
                ucVKey.PlayKlick();
        }

        private void btnAbteilung_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
        }

        private void ultraPopupControlContainer1_Closed(object sender, EventArgs e)
        {
            _PreventClickSound = false;
        }

        private void neuLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.refreshKlinik(true);
        }

        private void ucBigComboBoxKliniken1_SelectionChanged(object sender, EventArgs e)
        {
            this.OnValueChangedKlinik( sender, e);
        }
    }

    public class AbtBereich
    {
        public Guid _IDAbteilung = Guid.Empty;
        public Guid _IDBereich = Guid.Empty;
        public string _Text;

        public AbtBereich(Guid IDAbteilung, Guid IDBereich, string sText)
        {
            _IDAbteilung    = IDAbteilung;
            _IDBereich      = IDBereich;
            _Text           = sText;
        }
    }
}
