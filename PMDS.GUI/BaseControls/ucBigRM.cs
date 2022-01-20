//----------------------------------------------------------------------------
/// <summary>
///	ucBigRM.cs
/// Erstellt am:	16.5.2008
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
using PMDS.Data.PflegePlan;
using PMDS.Global;
using PMDS.Data.Global;
using Infragistics.Win;
using System.Threading;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;
using PMDS.DB;

namespace PMDS.GUI.BaseControls
{
    public partial class ucBigRM : QS2.Desktop.ControlManagment.BaseControl
    {
        private BigRMModes                  _mode = BigRMModes.Normal;
        private PflegeEintrag               _pe;
        private dsPflegePlan.PflegePlanRow  _row;
        private QMEintrag                   _QMe;

        public static dsEintrag.EintragDataTable   _massnahmen = null;
        private static DateTime                     _LastMRefresh = new DateTime(1900,1,1);

        public ucBigRM()
        {
            InitializeComponent();
            tbStunde.InitControl(BigNumberSelectorTypes.Int, "nn", "", 0, 23, 1, 12, null, null);
            tbMinuten.InitControl(BigNumberSelectorTypes.Int, "nn", "", 0, 59, 1, 10, null, null);
            tbDauer.InitControl(BigNumberSelectorTypes.Int, "nnn", "", 0, 120, 1, 10, 5, 40);


            if (!ENV.AppRunning)
                return;

            _pe = new PflegeEintrag();
            InitWichtigCombo();

            cbMassnahme.SearchClicked       += new EventHandler(cbMassnahme_SearchClicked);
            cbMassnahme.SelectionChanged    += new EventHandler(cbMassnahme_SelectionChanged);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Kommt nur bei Bedarfsmedikation vor hier gibt es eine Liste der
        /// möglichen Bedarfsmedikationsm. Bei Auswahl sind die Zusatzwerte zu aktuualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        void cbMassnahme_SelectionChanged(object sender, EventArgs e)
        {
            if (_mode != BigRMModes.Bedarfsmedikation)
                return;

            Guid IDEintrag = cbMassnahme.ID;
            if (IDEintrag == Guid.Empty)
                return;

            QM.FillZusatzRows(IDEintrag, _QMe);
            PrepareZusatz();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die M soll gesucht werden
        /// </summary>
        //----------------------------------------------------------------------------
        void cbMassnahme_SearchClicked(object sender, EventArgs e)
        {
            
            InitMDataTable();
            frmBigPicker frm = new frmBigPicker(QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme suchen"), _massnahmen, "Text", "ID");
            //frm.StartPosition = FormStartPosition.Manual;
            //frm.Top     = QM._LastFormViewArea.Y;
            //frm.Left    = QM._LastFormViewArea.X;
            //frm.Width   = QM._LastFormViewArea.Width;
            //frm.Height  = QM._LastFormViewArea.Height;
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            Guid IDEintrag = (Guid)frm.Value;
            FillComboWithEintrag(IDEintrag);

            bool bMed =  DBUtil.GetEintrag(IDEintrag).BedarfsMedikationJN;
            cbMedikament.Visible    = bMed;
            lblMedikament.Visible   = bMed;
            if (bMed)
                RefreshMedikamente();

            QM.FillZusatzRows(IDEintrag, _QMe);
            PrepareZusatz();

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Den M Datatable gemäß Caching vorgaben initialisieren und ggf. aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public static void InitMDataTable()
        {
            TimeSpan s = DateTime.Now - _LastMRefresh;
            if (_massnahmen == null || s.TotalMinutes > 60)             // Caching
            {
                _massnahmen = new PDx().KATALOGE['M'].EINTRAEGE;
                _LastMRefresh = DateTime.Now;
            }
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        ///	Init
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitControl(dsPflegePlan.PflegePlanRow row, BigRMModes mode,QMEintrag QMe)
        {
            _mode = mode;
            _row = row;
            _QMe = QMe;

            InitControl(mode, Guid.Empty);
            InitMComboNormal();
            
            DateTime dt         = QM.GetNextPflegeEintragTime(row, false);
            dtpZeitpunkt.Value  = DateTime.Now.Date;
            tbStunde.Value      = dt.Hour;
            tbMinuten.Value     = dt.Minute;

            if (row.OhneZeitBezug)                          // Maßnahmen ohne Zeitbezug sind immer mit jetzt zu melden
            {
                tbStunde.Value  = DateTime.Now.Hour;
                tbMinuten.Value = DateTime.Now.Minute;
            }
            
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Initialisierung
        /// </summary>
        //----------------------------------------------------------------------------
        public void InitControl(BigRMModes mode, Guid IDEintrag)
        {
            _mode = mode;
            DateTime dt         = DateTime.Now;
            dtpZeitpunkt.Value  = DateTime.Now.Date;
            tbStunde.Value      = dt.Hour;
            tbMinuten.Value     = dt.Minute;

            switch (mode)
            {
                case BigRMModes.Normal:
                    _pe = PflegeEintrag.NewByPflegePlan(ENV.IDAUFENTHALT, _row.ID, _row.IDEintrag, DateTime.Now, false);
                    _pe.IDAufenthalt    = ENV.IDAUFENTHALT;
                    _pe.IDBenutzer      = ENV.USERID;
                    _pe.IDPflegePlan    = _row.ID;
                    break;
                case BigRMModes.UgeplanteM:
                    _QMe = new QMEintrag();
                    FillComboWithEintrag(IDEintrag);
                    break;
                case BigRMModes.FreierBericht:
                    _QMe = new QMEintrag();
                    break;
                case BigRMModes.Bedarfsmedikation:
                    _QMe = new QMEintrag();
                    FillComboWithEintrag(IDEintrag);
                    RefreshMedikamente();
                    RefreshMassnahmeMedikationOnly();
                    break;
                default:
                    break;
            }

            RequiredFields();
            PrepareForMode();
            PrepareZusatz();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshMassnahmeMedikationOnly()
        {
            cbMassnahme.Items.Clear();

            try
            {
                InitMDataTable();
                foreach (dsEintrag.EintragRow kr in _massnahmen)
                    if (kr.BedarfsMedikationJN)
                        cbMassnahme.Items.Add(kr.ID, kr.Text);
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert einen Datatable mit den neuen Zusatzwerten
        /// </summary>
        //----------------------------------------------------------------------------
        public dsZusatzWert.ZusatzWertDataTable GetZusatzWerteForDB(Guid IDPflegeEintrag)
        {
            dsZusatzWert.ZusatzWertDataTable dt = new dsZusatzWert.ZusatzWertDataTable();
            foreach (ucBigZRM uc in this.pnlZusatz.Controls)
                uc.AddToZusatzWertTable(dt, IDPflegeEintrag);
            return dt;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Zusatzwerte generieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void PrepareZusatz()
        {
            pnlZusatz.Controls.Clear();
            if (!_QMe.HasZusatz)
            {
                pnlZusatz.Visible       = false;
                lblZusatzWerte.Visible  = false;
                return;
            }

            pnlZusatz.Visible       = true;
            lblZusatzWerte.Visible  = true;
            foreach (dsZusatzwerteForEintrag.ZusatzEintragRow r in _QMe._zusatzrows)
            {
                ucBigZRM uc = new ucBigZRM();
                uc.Tag      = r;
                uc.InitControl(r);
                pnlZusatz.Controls.Add(uc);
            }

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Je nach Modus die Combo mit werten belegen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitMComboNormal()
        {
            cbMassnahme.Items.Clear();
            cbMassnahme.Items.Add(_row.IDEintrag, _row.Text);
            cbMassnahme.ID      = _row.IDEintrag;
        }

        private void FillComboWithEintrag(Guid IDEintrag)
        {
            cbMassnahme.Items.Clear();

            if (IDEintrag == Guid.Empty)
                return;
            Eintrag e = new Eintrag();
            dsEintrag.EintragDataTable dt = e.Read(IDEintrag);
            cbMassnahme.Items.Add(IDEintrag, dt[0].Text);
            cbMassnahme.ID = IDEintrag;
        }

        

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Je nach Modus die Dinge initialisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void PrepareForMode()
        {
            bool bMed = _mode == BigRMModes.Normal ? DBUtil.GetEintrag(_row.IDEintrag).BedarfsMedikationJN : false;        // Bedarfsmedikation Init
            cbMassnahme.ShowSearchButton = false;

            if (bMed)
                RefreshMedikamente();

            switch (_mode)
            {
                case BigRMModes.Normal:
                    cbMassnahme.Visible = true;
                    cbMassnahme.Enabled     = false;
                    cbMedikament.Visible    = bMed;
                    lblMedikament.Visible   = bMed;
                    break;
                case BigRMModes.UgeplanteM:
                    cbMassnahme.Visible = true;
                    cbMassnahme.ShowSearchButton = true;
                    break;
                case BigRMModes.FreierBericht:
                    cbMassnahme.Visible     = false;
                    lblMassnahme.Visible    = false;
                    cbMedikament.Visible    = false;
                    lblMedikament.Visible   = false;
                    break;
                case BigRMModes.Bedarfsmedikation:
                    cbMassnahme.Visible     = true;
                    lblMassnahme.Visible    = true;
                    cbMedikament.Visible    = true;
                    lblMedikament.Visible   = true;
                    break;
                default:
                    break;
            }

           
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Wichtig für vorbelegen
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitWichtigCombo()
        {
            cbWichtig.Items.Clear();
            cbWichtig.Items.Add(Guid.Empty, " ");
            try
            {
                foreach (dsAuswahlGruppe.AuswahlListeRow r in new AuswahlGruppe("BER").AuswahlListe)
                    cbWichtig.Items.Add(r.ID, r.Bezeichnung);
            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        private bool IsOptional 
        { 
            get 
            {
                switch (_mode)
                {
                    case BigRMModes.Normal:
                        return _row.RMOptionalJN || ENV.ABTEILUNG_RMOPTIONAL; 
                    case BigRMModes.UgeplanteM:
                        return false;
                    case BigRMModes.FreierBericht:
                        return false;
                    case BigRMModes.Bedarfsmedikation:
                        return true;
                }
                return true;
            } 
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Pflichtfelder markieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RequiredFields()
        {
            txtBeschreibung.BackColor = IsOptional ? Color.White : Color.LightYellow;

            if (_mode == BigRMModes.UgeplanteM)
            {
                cbMassnahme.BackColor = Color.LightYellow;
            }

            if (_mode == BigRMModes.Bedarfsmedikation)
            {
                cbMassnahme.BackColor = Color.LightYellow;
                cbMedikament.BackColor = Color.LightYellow;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert true wenn alle Muss felder befüllt sind
        /// </summary>
        //----------------------------------------------------------------------------
        public bool ValidateFields()
        {

            if (_mode == BigRMModes.UgeplanteM)
            {
                if (cbMassnahme.ID == Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK, this, false);
                    cbMassnahme.Focus();
                    return false;
                }
            }

            if (_mode == BigRMModes.Bedarfsmedikation)
            {
                if (cbMassnahme.ID == Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK, this, false);
                    cbMassnahme.Focus();
                    return false;
                }
                if (cbMedikament.ID == Guid.Empty)
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Medikament auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Medikament auswählen", "Fehlende Eingabe", MessageBoxButtons.OK, this, false);
                    cbMedikament.Focus();
                    return false;
                }
            }

            if (!IsOptional)
            {
                if (txtBeschreibung.Text.Trim() == "")
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beschreibung fehlt", "Fehlende Eingabe", MessageBoxButtons.OK);
                    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beschreibung fehlt", "Fehlende Eingabe", MessageBoxButtons.OK, this, false);
                    txtBeschreibung.Focus();
                    return false;
                }
            }

            foreach (ucBigZRM uc in pnlZusatz.Controls)
            {
                if (!uc.Validate())             // Keine Messagebox notwendig (wird in Validate des Controls erledigt)
                    return false;
            }
            //  +		ZEITPUNKT	{01.01.1753 08:00:00}	System.DateTime

            ////[lth] Autom. Setzung Datum bei Fehlangebe in die Zukunft
            //if (ZEITPUNKT > DateTime.Now || DBNull.Value.Equals(ZEITPUNKT) ||  ZEITPUNKT.Year < 1990   )
            //{
            //    this.tbStunde.Value = DateTime.Now.Hour;
            //    this.tbMinuten.Value = DateTime.Now.Minute;
            //    //DateTime dat   = new   DateTime (DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day ,(int) this.tbStunde.Value,  (int)this.tbMinuten.Value, 0);
            //    DateTime dat2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            //    this.dtpZeitpunkt.DateTime = dat2;
            //}

            //if (ZEITPUNKT > DateTime.Now)
            //{
            //    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Rückmeldezeitpunkt darf nicht in der Zukunft liegen", "Falscher Rückmeldezeitpunkt", MessageBoxButtons.OK);
            //    //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Rückmeldezeitpunkt darf nicht in der Zukunft liegen", "Falscher Rückmeldezeitpunkt", MessageBoxButtons.OK, this, false);
            //    tbStunde.Focus();
            //    return false;
            //}

            PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
            bool DatOK = b.checkDateRückmeldung(ZEITPUNKT, PflegeEintragTyp.NONE);    //lthok
            if (!DatOK)
            {
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Die Werte abzeichnen
        /// </summary>
        //----------------------------------------------------------------------------
        public bool Abzeichnen()
        {
            if (!ValidateFields())
                return false;

            switch (_mode)
            {
                case BigRMModes.Normal:
                    UpdateData();
                    WritePE();
                    break;
                case BigRMModes.UgeplanteM:
                    _pe = PflegeEintrag.NewByMassnahme(ENV.IDAUFENTHALT, cbMassnahme.ID);
                    UpdateData();
                    WritePE();
                    break;
                case BigRMModes.FreierBericht:
                    PflegeEintrag.NewFreienBerichtEinfuegen(ENV.IDAUFENTHALT, ZEITPUNKT, txtBeschreibung.Text.Trim(), cbWichtig.ID);
                    break;
                case BigRMModes.Bedarfsmedikation:
                    _pe = PflegeEintrag.NewByMassnahme(ENV.IDAUFENTHALT, cbMassnahme.ID);
                    UpdateData();
                    WritePE();
                    break;
                default:
                    break;
            }

            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert das zugehörige BO PflegeEintrag
        /// </summary>
        //----------------------------------------------------------------------------
        public PflegeEintrag Eintrag
        {
            get
            {
                return _pe;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        private void WritePE()
        {
            _pe.Write();                        // PE schreiben
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Liefert den Zeitpunkt aus den Eingabefeldern
        /// </summary>
        //----------------------------------------------------------------------------
        private DateTime ZEITPUNKT
        {
            get
            {
                return dtpZeitpunkt.DateTime.AddHours(Convert.ToInt32(tbStunde.Value.ToString().Trim() == "" ? "0" : tbStunde.Value)).AddMinutes(Convert.ToInt32(tbMinuten.Value.ToString().Trim() == "" ? "0" : tbMinuten.Value));
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Gui nach BO
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateData()
        {
            
            _pe.Zeitpunkt           = ZEITPUNKT;
            _pe.DurchgefuehrtJN     = true;
            _pe.IstDauer            = Convert.ToInt32(tbDauer.Value.ToString().Trim() == "" ? "0" : tbDauer.Value);

            if (cbMedikament.Visible && cbMedikament.ID != Guid.Empty)
            {
                if (cbMedikament.Text.Contains(";"))
                {
                    _pe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ") + cbMedikament.Text.Remove(cbMedikament.Text.IndexOf(";")) + Environment.NewLine + txtBeschreibung.Text;

                }
                else
                {
                    _pe.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ") + cbMedikament.Text + Environment.NewLine + txtBeschreibung.Text;
                }
            }
            else
            {
                _pe.Text = txtBeschreibung.Text;
            }
            _pe.IDWichtig           = cbWichtig.ID;
            _pe.IDEintrag           = cbMassnahme.ID;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AuswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        public void RefreshMedikamente()
        {
            cbMedikament.Items.Clear();

            try
            {
                dsGUIDListe.IDListeDataTable dt = Rezept.GetBedarfsMedikamente(ENV.IDAUFENTHALT, DateTime.Now);
                cbMedikament.Items.Add(Guid.Empty, " ");
                foreach (dsGUIDListe.IDListeRow r in dt.Rows)
                {
                    string[] sa = r.TEXT.Split(new string[] { "||" }, StringSplitOptions.None);
                    ValueListItem item = cbMedikament.Items.Add(r.ID, sa[0]);
                    item.Tag = sa[1];
                }

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die Auswahlliste wurde geschlossen
        /// </summary>
        //----------------------------------------------------------------------------
        private void cbMedikament_AfterCloseUp(object sender, EventArgs e)
        {
            if (cbMedikament.SelectedItem == null || (Guid)cbMedikament.SelectedItem.DataValue == Guid.Empty)
                return;

            string sText = cbMedikament.SelectedItem.Tag.ToString().Trim();
            if (sText.Length == 0)
                return;
            QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamentenwarnung"), MessageBoxButtons.OK, true);
            //frmBigQS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, "Medikamentenwarnung", MessageBoxButtons.OK, this, true);
        }

        private void tbStunde_Leave(object sender, EventArgs e)
        {
            if (tbStunde.Value.ToString().Length == 1)
                tbStunde.Value = "0" + tbStunde.Value.ToString();
        }

        private void tbMinuten_Leave(object sender, EventArgs e)
        {
            if (tbMinuten.Value.ToString().Length == 1)
                tbMinuten.Value = "0" + tbMinuten.Value.ToString();
        }

        private void ucDateSelect1_delRefresh(DateTime dat)
        {
            this.ucDateSelect1.Enabled = true;
        }

        private void ucDateSelect1_Load(object sender, EventArgs e)
        {
            this.ucDateSelect1.initToolbar(true);
        }

        private void dtpZeitpunkt_ValueChanged(object sender, EventArgs e)
        {
            this.changeDatTime();
        }
                
        private void ucDateSelect1_delRefresh(object val)
        {
            DateTime dat = (DateTime)val;
            this.dtpZeitpunkt.DateTime = dat;
            //this.ucDateSelect1._datAct = dat;
            this.tbStunde.Value = dat.Hour;
            this.tbMinuten.Value = dat.Minute ;
        }

        private void tbStunde_delRefresh(object val)
        {
            this.changeDatTime( );
        }

        private void tbMinuten_delRefresh(object val)
        {
            this.changeDatTime( );
        }

        private void changeDatTime( )
        {
            //DateTime dat = new DateTime(this.dtpZeitpunkt.DateTime.Year, this.dtpZeitpunkt.DateTime.Month, this.dtpZeitpunkt.DateTime.Day, (int)this.tbStunde.Value, (int)this.tbMinuten.Value, 0);
            //this.ucDateSelect1._datAct = dat;
        }

        private void tbMinuten_Load(object sender, EventArgs e)
        {

        }
        public void clearContrl()
        {
            this.cbMassnahme.Text = "";
            this.cbWichtig .Text = "";
            this.cbMedikament .Text = "";
            this.txtBeschreibung .Text = "";
            this.tbDauer.Value = System.DBNull.Value ;

        }
        private void ucBigRM_Load(object sender, EventArgs e)
        {

        }

        private void cbWichtig_Load(object sender, EventArgs e)
        {

        }

    }

    public enum BigRMModes 
    {
        Normal,
        UgeplanteM,
        FreierBericht,
        Bedarfsmedikation
    }
}
