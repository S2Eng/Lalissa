using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using Infragistics.Win.Misc;
using VirtualKeyboard;
using PMDS.Global;
using PMDS.DB;
using PMDS.Global.db.Patient;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigKlientenSelector : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDAbteilung;
        private Guid _IDBereich;
        private Guid _IDKlient;
        private int _X = 0;
        private int _Y = 0;
        private int _WIDTH = 800;
        private int _HEIGHT = 600;

        private ucClickableImage lastSelectedImg;

        private bool _PreventClickSound = false;
        private bool _openinghandled = false;

        public event EventHandler SelectionChanged;

        private bool _RefreshNeeded = false;



        public ucBigKlientenSelector()
        {
            InitializeComponent();
            
        }
        
        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liste entfernen
        /// </summary>
        //----------------------------------------------------------------------------
        public void ClearKlientenList()
        {
            _IDKlient = Guid.Empty;
            // this.pnlKlienten.Controls.Clear();
            foreach (object contImg in pnlKlienten.Controls)
            {
                if (contImg.GetType().ToString() == "PMDS.GUI.BaseControls.ucClickableImage")
                {
                    ((ucClickableImage)contImg).Visible = false;
                }
            }

            this.btnKlient.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten wählen");
            btnKlient.Appearance.Image = null;
            _RefreshNeeded = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Filterauswahl setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void SetParams(Guid IDAbteilung, Guid IDBereich)
        {
            _IDAbteilung    = IDAbteilung;
            _IDBereich      = IDBereich;
            _RefreshNeeded  = true;
        }

        public void DoPopup()
        {
            _PreventClickSound = true;
            ultraPopupControlContainer1.Show();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Kilentenliste aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshKlientenList()
        {
            if (!_RefreshNeeded)
                return;
            Cursor.Current = Cursors.WaitCursor;
            // pnlKlienten.Controls.Clear();

            foreach (object contImg in pnlKlienten.Controls)
            {
                if (contImg.GetType().ToString() == "PMDS.GUI.BaseControls.ucClickableImage")
                {
                    ((ucClickableImage)contImg).Visible = false;
                }
            }

            List<Guid> al = new List<Guid>();
            if (_IDAbteilung != Guid.Empty)
                al.Add(_IDAbteilung);

            dsPatientStation.PatientDataTable t = Patient.ByFilter("", false, al.ToArray(), _IDBereich, false, PMDS.Global.ENV.IDKlinik);
            Patient p = new Patient();
            int iCount = 0;

            //Screen.PrimaryScreen.Bounds.Width 
            //Screen.PrimaryScreen.Bounds.Width 

            pnlKlienten.AutoScroll = true;
            int lastIndex = 1;
            int maxIndex = pnlKlienten.Controls.Count ;
            bool bfirstButt = true;
            
            foreach (dsPatientStation.PatientRow r in t)
            {
                Image img = null;

                if (lastIndex <= maxIndex - 1)
                {
                    ucClickableImage uc = (ucClickableImage)pnlKlienten.Controls[lastIndex];
                    if (r.ID != (System.Guid )uc.Tag)
                    {
                        byte[] ba = p.GetFoto(r.ID);
                        if (ba != null)
                            img = BUtil.ImageFromArray(ba, false);
                        else
                            img = new Bitmap(10, 10);

                        uc.Tag = r.ID;
                        uc.setData(img, r.Name, r.Name, iCount, true);
                    }
                    else
                    {
                        uc.Tag = r.ID;
                        uc.setData(img, r.Name, r.Name, iCount, false);
                    }

                    uc.Visible = true;
                    iCount++;
                    lastIndex += 1;
                    if (bfirstButt) this.lastSelectedImg = uc;
                }
                else
                {
                    byte[] ba = p.GetFoto(r.ID);
                    if (ba != null)
                        img = BUtil.ImageFromArray(ba, false);
                    //else
                    //    img = new Bitmap(10, 10);

                    ucClickableImage uc = new ucClickableImage(img, r.Name, r.Name, iCount);
                    uc.BORDER           = true;
                    uc.Tag              = r.ID;
                    uc.Height = 220;
                    uc.Width = 162;
                    uc.Click            += new EventHandler(uc_Click);
                    pnlKlienten.Controls.Add(uc);
                    iCount++;
                    if (bfirstButt) this.lastSelectedImg = uc;
                }
                bfirstButt = false;
            }
       }

        private void RefreshColors()
        {
            //List<Guid> alpOpen = PflegePlan.GetKlientenMitOffenenAufgabenBisJetzt();
            foreach (object uc in pnlKlienten.Controls)
            {
                if (uc.GetType().ToString() == "PMDS.GUI.BaseControls.ucClickableImage")
                {
                    Guid id = (Guid)((ucClickableImage)uc).Tag;
                    
                    DateTime dNow = DateTime.Now;
                    PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();

                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        //os191224
                        //db.Entities.Patient rPatient = PMDSBusiness1.getPatient(id, db);
                        db.Entities.Aufenthalt rAufenthalt = PMDSBusiness1.getAktuellerAufenthaltPatient(id, false, null);
                        PMDS.DB.PMDSBusiness.retBusiness resCheck = PMDSBusiness1.getOpenTermine(id, rAufenthalt.ID, dNow, ENV.IDKlinik);
                        if (resCheck.tInerventionen.Rows.Count > 0)
                        {
                            ((ucClickableImage)uc).BACKCOLOR = REDCOLOR;
                        }
                        else
                        {
                            ((ucClickableImage)uc).BACKCOLOR = GREEENCOLOR;
                        }
                        //bool bFound = false;
                        //foreach (Guid g in alpOpen)
                        //{
                        //    if (g == id)
                        //    {
                        //        bFound = true;
                        //        break;
                        //    }
                        //}
                        //((ucClickableImage)uc).BACKCOLOR = Color.Beige ; // System.Color bFound ? REDCOLOR : GREEENCOLOR;
                    }

                }
            }

        }

        public Color REDCOLOR
        {
            get
            {
                return Color.FromArgb(255, 192, 192);
            }
        }

        public Color GREEENCOLOR
        {
            get
            {
                return Color.FromArgb(192, 255, 192);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Click handler der Images
        /// </summary>
        //----------------------------------------------------------------------------
        void uc_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            ucClickableImage uc         = (ucClickableImage)sender;
            btnKlient.Appearance.Image  = uc.IMAGE;
            btnKlient.Text              = uc.LabelText;
            _IDKlient                   = (Guid)uc.Tag;
            ultraPopupControlContainer1.Close();
            if (SelectionChanged != null)
                SelectionChanged(this, EventArgs.Empty);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Refresh when needed
        /// </summary>
        //----------------------------------------------------------------------------
        private void ultraPopupControlContainer1_Opening(object sender, CancelEventArgs e)
        {
            if (_openinghandled)
            {
                RefreshColors();
                return;
            }
            if (!_PreventClickSound)
                ucVKey.PlayKlick();
            _openinghandled = true;
            RefreshKlientenList();
            RefreshColors();
            pnlKlienten.Width = _WIDTH;
            pnlKlienten.Height = _HEIGHT;
            pnlKlienten.BackColor = Color.White;
            pnlKlienten.BorderStyle = BorderStyle.FixedSingle;
            ultraPopupControlContainer1.Show(new Point(_X, _Y));
            e.Cancel = true;

            if (lastSelectedImg != null) lastSelectedImg.btnFocus.Focus();
            //btnFocus.Focus();
            //btnFocus.Visible = true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die region des Popups setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public void SetPopupRegion(int x, int y, int width, int height)
        {
            _X      = x;
            _Y      = y;
            _WIDTH  = width;
            _HEIGHT = height;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert die aktuell gewählte ID des Klienten
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid IDPATIENT
        {
            get
            {
                return _IDKlient;
            }
        }

        private void ultraPopupControlContainer1_Closed(object sender, EventArgs e)
        {
            _openinghandled = false;
            _PreventClickSound = false;
        }

        private void pnlKlienten_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKlient_Click(object sender, EventArgs e)
        {

        }
      
    }
}
