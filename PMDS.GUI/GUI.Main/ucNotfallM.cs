//----------------------------------------------------------------------------
/// <summary>
///	ucNotfallM.cs
/// Erstellt am:	12.12.2007
/// Erstellt von:	RBU
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Data.Global;
using PMDS.Global.db.Pflegeplan;
using PMDS.DB;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    //----------------------------------------------------------------------------
    /// <summary>
    /// Darstellung einer Notfamm maßnahme inkl. Zusatzwerte
    /// </summary>
    //----------------------------------------------------------------------------
    public partial class ucNotfallM : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDEintrag;
        private PflegeEintrag _eintrag;
        private Guid _IDAufenthalt;
        private Guid _IDUser;
        private Guid _IDBerufstand;
        private ContextMenu _timemenu = null;
        private bool _Medikation = false;
        private bool _MedikamentListInit = false;

        public event EventHandler NaechterZeitpunktChanged;         // signalisiert dass sich der nächste Zeitpunkt geändert hat

        public ucNotfallM()
        {
            InitializeComponent();
            chkDone.Checked = false;
            chkDone_CheckedChanged(this, EventArgs.Empty);
            this.auswahlGruppeComboMulti1.initControl(BaseControls.AuswahlGruppeComboMulti.eTypeMulti.Berufsgruppe, eUITypeTermine.None, true, -1, 0, true);

        }

        private void pnlZusatz_VisibleChanged(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Neuberechnung der höhe
        /// </summary>
        //----------------------------------------------------------------------------
        private void ResizeThis()
        {
            int heigth = pnlTopLeft.Height;
            if (chkDone.Checked)
            {
                heigth += pnlTopRight.Height;
                heigth += pnlTop2.Height;
            }

            if (pnlZusatz.Visible)
                heigth += ucZusatzWert1.ITEMCount * pnlTop2.Height;

            this.Height = heigth;
        }

        public Guid IDAUFENTHALT { get { if (_IDAufenthalt == Guid.Empty) return ENV.IDAUFENTHALT; else return _IDAufenthalt; } set { _IDAufenthalt = value; } }
        public Guid IDUSER { get { if (_IDUser == Guid.Empty) return ENV.USERID; else return _IDUser; } set { _IDUser = value; } }
        public Guid IDBERUFSTAND { get { if (_IDBerufstand == Guid.Empty) return ENV.BERUFID; else return _IDBerufstand; } set { _IDBerufstand = value; } }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Eintrag auf Basis der IDEintrag erzeugen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDEintrag
        {
            get
            {
                return _IDEintrag;
            }
            set
            {

                _IDEintrag = value;

                if (value == Guid.Empty)
                    return;

                PflegeEintrag eintrag = new PflegeEintrag();
                eintrag.IDEintrag = _IDEintrag;
                eintrag.DurchgefuehrtJN = true;
                eintrag.EintragsTyp = PflegeEintragTyp.UNEXP_MASSNAHME;

                eintrag.DatumErstellt = DateTime.Now;
                eintrag.Zeitpunkt = DateTime.Now;
                eintrag.IDAufenthalt = IDAUFENTHALT;
                eintrag.IDBenutzer = IDUSER;
                eintrag.IDBerufsstand = IDBERUFSTAND;

                // Text der M lesen
                Eintrag e = new Eintrag();
                dsEintrag.EintragRow r = (dsEintrag.EintragRow)e.Read(_IDEintrag).Rows[0];
                txtM.Text = r.Text;
                toolTip1.SetToolTip(txtM, r.Text);
                eintrag.PflegeplanText = r.Text;

                // Letztes Datum lesen
                dsPflegeEintrag.PflegeEintragRow rpe = PflegeEintrag.GetLastByAufenthalt(IDAUFENTHALT, _IDEintrag);
                if (rpe == null)
                    lblLast.Text = "";
                else
                    lblLast.Text = rpe.Zeitpunkt.ToShortDateString() + " " + rpe.Zeitpunkt.ToShortTimeString();

                Eintrag = eintrag;

                CheckBedarfsMedikation();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Überprüft ob die zu Meldende M eine M ist welche Bedarfsmedikamentenrelevant
        /// ist und manipuliert die Oberfläche entsprechend
        /// </summary>
        //----------------------------------------------------------------------------
        private void CheckBedarfsMedikation()
        {
            _Medikation = DBUtil.GetEintrag(_IDEintrag).BedarfsMedikationJN;

            if (!_MedikamentListInit)
                cbBedarfsMedikament.RefreshList(Eintrag.IDAufenthalt);
            _MedikamentListInit = true;

            cbBedarfsMedikament.Visible = _Medikation;
            lblMedikation.Visible = _Medikation;
        }



        //----------------------------------------------------------------------------
        /// <summary>
        /// PflegeEintrag setzen/auslesen
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private PflegeEintrag Eintrag
        {
            get
            {
                return _eintrag;
            }

            set
            {
                if (value == null)
                    throw new ArgumentNullException("Eintrag");

                _eintrag = value;
                UpdateGUI();
                ResizeThis();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Der erzeugte Pflegeeintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public Guid IDPflegeEintrag
        {
            get
            {
                return Eintrag.ID;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liefert true wenn die M ausgewählt ist
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CHK_DONE
        {
            get
            {
                return chkDone.Checked;
            }
            set
            {
                chkDone.Checked = value;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten nach GUI übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        public virtual void UpdateGUI()
        {
            ucZusatzWert1.IDAufenthalt = ENV.IDAUFENTHALT;
            ucZusatzWert1.IZusatz = (IZusatz)Eintrag;

            dtpZeitpunkt.Value = Eintrag.Zeitpunkt;
            txtIstDauer.Value = Eintrag.IstDauer.ToString();
            txtBeschreibung.Text = Eintrag.Text;
            cbImportant.ID = Eintrag.IDWichtig;

            CheckZusatzVisibility();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// GUI nach Daten übertragen
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateDATA()
        {
            ucZusatzWert1.UpdateDATA();
            
            Eintrag.Zeitpunkt = (DateTime)dtpZeitpunkt.Value;
            Eintrag.DurchgefuehrtJN = true;
            Eintrag.IstDauer = Convert.ToInt32(txtIstDauer.Value);
            Eintrag.Text = _Medikation && cbBedarfsMedikament.Text.Trim().Length > 0 ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ") + cbBedarfsMedikament.Text + Environment.NewLine + txtBeschreibung.Text : txtBeschreibung.Text;
            Eintrag.IDWichtig = cbImportant.ID;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Felder validieren
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {
            if (!chkDone.Checked)               // nichts angehakt ==> nichts zu überprüfen
                return true;

            bool bError = false;
            bool bInfo = true;

            GuiUtil.ValidateField(dtpZeitpunkt, (dtpZeitpunkt.Text.Length > 0), ENV.String("GUI.E_NO_TEXT"), ref bError, bInfo, errorProvider1);
            GuiUtil.ValidateField(dtpZeitpunkt, dtpZeitpunkt.DateTime <= DateTime.Now, ENV.String("GUI.E_NO_FUTURE_ZEITPUNKT"), ref bError, bInfo, errorProvider1);


            // Zusatzwerte überprüfen
            if (!bError && !ucZusatzWert1.ValidateFields())
                bError = true;



            return !bError;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einen Pflegeeintrag mit evtl. Zusatzwerten schreiben
        /// </summary>
        //----------------------------------------------------------------------------
        public void Write()
        {
            if (!chkDone.Checked)               // nichts angehakt ==> nichts zu überprüfen
                return;
            UpdateDATA();
            Eintrag.Write();
            ucZusatzWert1.Write();

            dsSP.SPPOSRow r = (dsSP.SPPOSRow)Tag;               // Nächstesmal wieder verspeichern
            if (dtpNaechterZeitpunkt.Value == null)
                r.SetwiederumamNull();
            else
                r.wiederumam = dtpNaechterZeitpunkt.DateTime;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Im Tag steht die verbundene Row
        /// </summary>
        //----------------------------------------------------------------------------
        public new object Tag
        {
            set
            {
                base.Tag = value;
                if (value == null)
                    return;
                dsSP.SPPOSRow r = (dsSP.SPPOSRow)value;
                if (r.IswiederumamNull())
                    dtpNaechterZeitpunkt.Value = null;
                else
                    dtpNaechterZeitpunkt.DateTime = r.wiederumam;
            }
            get
            {
                return base.Tag;
            }
        }

        private void CheckZusatzVisibility()
        {
            if (ucZusatzWert1.HAS_ADDITIONAL_VALUES)
                pnlZusatz.Visible = true && chkDone.Checked;
            else
                pnlZusatz.Visible = false;
        }

        private void chkDone_CheckedChanged(object sender, EventArgs e)
        {
            pnlTopRight.Visible = chkDone.Checked;
            pnlZusatz.Visible = chkDone.Checked;
            pnlTop2.Visible = chkDone.Checked;

            CheckZusatzVisibility();
            InitTimeContextMenu();
            ResizeThis();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Dropdownbutton Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            _timemenu.Show(this, new Point(btnTimes.Left, btnTimes.Top + btnTimes.Height));
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Initialisieren des Zeitauswahl Menüs.
        /// Je nach Abteilung sind unterschiedliche Dienstzeiten möglich
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitTimeContextMenu()
        {
            if (_timemenu != null)     // für die Abteilung bereits initialisert
                return;

            _timemenu = new ContextMenu();
            MenuItem item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("kein nächster Zeitpunkt"));
            item.Tag = new timehelper(new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));
            item.Click += new EventHandler(Timeitem_Click);

            _timemenu.MenuItems.Add("-");

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 10 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(10));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 15 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(15));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 20 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(20));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 30 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(30));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 45 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(45));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 60 Minuten"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddMinutes(60));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 2 Stunden"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddHours(2));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 4 Stunden"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddHours(4));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 8 Stunden"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddHours(8));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 16 Stunden"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddHours(16));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 1 Tag"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddDays(1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 2 Tage"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.AddDays(2));
            item.Click += new EventHandler(Timeitem_Click);


        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Ein Eintrag in dem Zeitenmenü wurde gewählt - die Zeiten setzen
        /// </summary>
        //----------------------------------------------------------------------------
        void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            timehelper h = (timehelper)item.Tag;

            if (h._to.Year == 1900)
                dtpNaechterZeitpunkt.Value = null;
            else
                dtpNaechterZeitpunkt.DateTime = h._to;

        }

        private void pnlZusatz_Paint(object sender, PaintEventArgs e)
        {

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wenn sich der nächste Zeitpunkt ändert, dann die SP/NF offen lassen
        /// vormarkieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void dtpNaechterZeitpunkt_ValueChanged(object sender, EventArgs e)
        {
            if (NaechterZeitpunktChanged == null)
                return;

            NaechterZeitpunktChanged(dtpNaechterZeitpunkt, EventArgs.Empty);
        }

        private void auswahlGruppeComboMulti1_AfterCheck(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Guid> lstSelectedCC = new System.Collections.Generic.List<Guid>();
            System.Collections.Generic.List<int> lstIntSelected = new System.Collections.Generic.List<int>();
            System.Collections.Generic.List<string> lstStringSelected = new System.Collections.Generic.List<string>();
            this.auswahlGruppeComboMulti1.getSelected(ref lstSelectedCC, ref lstIntSelected, ref lstStringSelected);

            if (lstSelectedCC.Count > 0)  //
            {
                txtBeschreibung.Enabled = true;
            }
            else
            {

                if (txtBeschreibung.Text.Trim() != "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben alle Einträge in 'Wichtig für' zurückgesetzt. Ihre Änderungen im Dekurs werden ebenfalls zurückgesetzt.");
                    txtBeschreibung.Text = "";
                }

                txtBeschreibung.Enabled = false;
            }
        }

    }
}