using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PMDS.Data.Patient;
using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.Print;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using PMDS.Global.db.Patient;
using PMDS.DB;
using System.Linq;


namespace PMDS.GUI
{


    public partial class ucBewerber :   QS2.Desktop.ControlManagment.BaseControl
    {
        private PatientBewerber _patBewerber;
        private bool _btnSaershClicked = false;
        private Guid _IDBewerber = Guid.Empty;
        private bool _InProgress = false;

        public event PatientDetailsDelegate PatientDetailsDelegate;
        public event PatientDeletedDelegate PatientDeletedDelegate;
        public event BewerberChangedDelegate BewerberChangedDelegate;
        public event BewerberstatusChangedDelegate BewerberstatusChangedDelegate;

        public PMDSBusiness b = new PMDSBusiness();










        public ucBewerber()
        {
            InitializeComponent();

            if (!DesignMode && ENV.AppRunning)
            {
                _patBewerber = new PatientBewerber();
                UltraGridTools.AddAbteilungsValueList(dgBewerber2, "IDAbteilung");
                dgBewerber2.DataSource = _patBewerber.ListBewerber;
                this.loadComboAllKliniken();
                RefreshListAbteilungen();
            }
        }
        public void loadComboAllKliniken()
        {
            try
            {
                bool lstKlinikenLoaded = false;
                this.dsKlinik1.Klinik.Clear();
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                b.loadComboAllKliniken(this.cbKlinik, this.dsKlinik1.Klinik, ref lstKlinikenLoaded, false, true);
                this.loadBereich();
                this.cbAbteilung.Value = null;
                this.cboBereich.Value = null;
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerber.loadComboAllKliniken: " + ex.ToString());
            }
        }
        public void loadBereich()
        {
            try
            {
                if (this.cbAbteilung.Value != null)
                {
                    this.b.loadCboBereiche((Guid)this.cbAbteilung.Value, this.cboBereich, true);
                }
                else
                {
                    this.b.loadCboBereiche(null, this.cboBereich, true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerber.loadBereich: " + ex.ToString());
            }
        }

        public dsKlinik.KlinikRow getSelKlinik(bool withMsgBox)
        {
            try
            {
                if (this.cbKlinik.SelectedItem != null)
                {
                    Infragistics.Win.ValueListItem item = this.cbKlinik.SelectedItem;
                    return (dsKlinik.KlinikRow)item.Tag;
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucBewerber.getSelKlinik: " + ex.ToString());
                //return null;
            }
        }
        private void RefreshListAbteilungen(System.Guid IDKlinik)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = this.b.getBenutzerAbteilung(ENV.USERID, db);

                    cbAbteilung.Items.Clear();
                    cbAbteilung.Items.Add(Guid.Empty, QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abteilung"));
                    this.cboBereich.Clear();
                    this.cboBereich.Value = null;

                    PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                    dsAbteilung dsAbteilung1 = new dsAbteilung();
                    DBAbteilung1.getAbteilungenByKlinik(IDKlinik, dsAbteilung1);
                    foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                    {
                        if (IDKlinik.Equals(System.Guid.Empty))
                        {
                            cbAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung);
                        }
                        else
                        {
                            var tAbteilungRight = (from ba in tBenutzerAbteilung
                                                   where ba.IDAbteilung == rAbt.ID
                                                   select new
                                                   {
                                                       IDAbteilung = ba.IDAbteilung
                                                   });
                            if (tAbteilungRight.Count() > 0)
                            {
                                cbAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("RefreshListAbteilungen: " + ex.ToString());
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private dsPatientBewerber.PatientRow CurrentRow
        {
            get { return (dsPatientBewerber.PatientRow)UltraGridTools.CurrentSelectedRow(dgBewerber2); }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bewerbername
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Bewerbername
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Beweberdatum von
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime BewerberVon
        {
            get 
            {
                if (dtpBewVon.Text.Trim() != "")
                    return dtpBewVon.DateTime;
                else
                    return DateTime.MinValue;
            }
            set { dtpBewVon.Value = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Beweberdatum bis
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime BewerberBis
        {
            get
            {
                if (dtpBewBis.Text.Trim() != "")
                    return dtpBewBis.DateTime;
                else
                    return DateTime.MinValue;
            }
            set { dtpBewBis.Value = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einzugswunsch von
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EinzugswunschVon
        {
            get
            {
                if (dtpEinzVon.Text.Trim() != "")
                    return dtpEinzVon.DateTime;
                else
                    return DateTime.MinValue;
            }
            set { dtpEinzVon.Value = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Einzugswunsch bis
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime EinzugswunschBis
        {
            get
            {
                if (dtpEinzBis.Text.Trim() != "")
                    return dtpEinzBis.DateTime;
                else
                    return DateTime.MinValue;
            }
            set { dtpEinzVon.Value = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Priortät
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Prioritaet
        {
            get { return cmbPriortaet.Text.Trim(); }
            set { cmbPriortaet.Text = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegeart
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Pflegeart
        {
            get { return cmbPflegeart.Text.Trim(); }
            set { cmbPflegeart.Text = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Abteilung
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAbteilung
        {
            get { return cbAbteilung.Value != null ? (Guid)cbAbteilung.Value : Guid.Empty; }
            set { cbAbteilung.Value = value; }
        }

        public void RefreshControl()
        {
            _InProgress = true;
            btnBewDaten.Enabled = false;
            btnBewStatus.Enabled = false;
            btnDel.Enabled = false;

            Guid IDKlinik = System.Guid.Empty;
            if (this.cbKlinik.Value != null)
            {
                IDKlinik = (Guid)this.cbKlinik.Value;
            }

            Guid IDBereich = System.Guid.Empty;
            if (this.cboBereich.Value != null)
            {
                IDBereich = (Guid)this.cboBereich.Value;
            }
            string Konfession = "";
            if (this.cmbKonfession.Value != null)
            {
                Konfession = (String)this.cmbKonfession.Text;
            }
            string Sexus = "";
            if (this.cmbSexus.Value != null)
            {
                Sexus = (String)this.cmbSexus.Text;
            }

            if (_patBewerber == null)
                return;

            if (!_btnSaershClicked)
                _patBewerber.Read();
            else
                _patBewerber.ReadByFilter2(Bewerbername, BewerberVon, BewerberBis, EinzugswunschVon, EinzugswunschBis, Prioritaet, Pflegeart, IDAbteilung,
                                            Konfession.Trim(), Sexus.Trim(), IDBereich, IDKlinik);

            PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                foreach (UltraGridRow rowGrid in this.dgBewerber2.Rows)
                {
                    DataRowView v = (DataRowView)rowGrid.ListObject;
                    dsPatientBewerber.PatientRow rPatBewerber = (dsPatientBewerber.PatientRow)v.Row;

                    PMDS.db.Entities.Klinik rKlinik = PMDSBusiness1.getKlinikByAbteilung(rPatBewerber.IDAbteilung, db);

                    rowGrid.Cells["Klinik"].Value = rKlinik.Bezeichnung.Trim();
                    rowGrid.Cells["IDKlinik"].Value = rKlinik.ID;
                }
            }

            this.dgBewerber2.Refresh();

            RefreshName();
            
            SelectCurrentBewerber();
            _InProgress = false;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// AbteilungsauswahlListe neu aufbauen
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshListAbteilungen()
        {
            try
            {
                //foreach (dsAbteilung.AbteilungRow r in Klinik.Default().Abteilungen.Abteilungen)
                //    cbAbteilung.Items.Add(r.ID, r.Bezeichnung);

                cbAbteilung.Items.Clear();
                cbAbteilung.Items.Add(Guid.Empty, " ");

                PMDS.DB.DBAbteilung DBAbteilung1 = new PMDS.DB.DBAbteilung();
                dsAbteilung dsAbteilung1 = new dsAbteilung();
                DBAbteilung1.getAbteilungenByKlinik(ENV.IDKlinik, dsAbteilung1);
                foreach (dsAbteilung.AbteilungRow rAbt in dsAbteilung1.Abteilung)
                {
                    cbAbteilung.Items.Add(rAbt.ID, rAbt.Bezeichnung);
                }

            }
            catch (Exception e)
            {
                ENV.HandleException(e);
            }
        }

        public void SelectCurrentBewerber()
        {
            if (_IDBewerber == Guid.Empty)
                return;

            foreach (UltraGridRow r in dgBewerber2.Rows)
            {
                if ((Guid)r.Cells["ID"].Value == _IDBewerber)
                {
                    r.Selected = true;
                    dgBewerber2.ActiveRow = r;
                    break;
                }
            }

            if (CurrentRow == null && BewerberChangedDelegate != null)
                BewerberChangedDelegate(Guid.Empty);
        }

        public void SelectBewerber(Guid IDBewerber)
        {
            if (IDBewerber == Guid.Empty)
                return;

            foreach (UltraGridRow r in dgBewerber2.Rows)
            {
                if ((Guid)r.Cells["ID"].Value == IDBewerber)
                {
                    r.Selected = true;
                    dgBewerber2.ActiveRow = r;
                    break;
                }
            }
        }

        private void RefreshName()
        {
            //dgBewerber2.BeginUpdate();

            //foreach (UltraGridRow r in dgBewerber2.Rows)
            //{
            //    r.Cells["Name"].Value = r.Cells["Nachname"].Value.ToString() + " " + r.Cells["Vorname"].Value.ToString();
            //    r.Update();
            //}

            //dgBewerber2.EndUpdate();
        }

        private void BewerberDaten()
        {
            if (CurrentRow == null || PatientDetailsDelegate == null)
                return;
            _IDBewerber = CurrentRow.ID;
            PatientDetailsDelegate(CurrentRow.ID, true);
        }

        private void btnSearsh_Click(object sender, EventArgs e)
        {
            _btnSaershClicked = true;
            RefreshControl();
        }

        private void ucBewerber_Load(object sender, EventArgs e)
        {
            if (!DesignMode && ENV.AppRunning)
            {
                txtName.Text = "";
                dtpBewVon.Value = null;
                dtpBewBis.Value = null;
                dtpEinzVon.Value = null;
                dtpEinzBis.Value = null;
                cmbPflegeart.Text = "";
                cmbPriortaet.Text = "";
                RefreshControl();
                dgBewerber2.Select();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (CurrentRow == null)
                return;

            DialogResult res;
            dsAufenthalt.AufenthaltDataTable table = Aufenthalt.ByPatient(CurrentRow.ID);

            Guid idpatient = CurrentRow.ID;

            if (table.Count == 0)
            {
                res= QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen alle Daten von ") + CurrentRow.Nachname + " " + CurrentRow.Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wirklich gelöscht werden?"),
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Bewerber löschen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);
                if (res == DialogResult.Yes)
                {
                    //Änderung nach 23.05.2008 MDA
                    //Um einen Bewerber zu löschen, müssen vorher alle zuordnungen(Adresse, Kontakte, Ärzte...) gelöscht wewrden.
                    _patBewerber.Delete(CurrentRow); 
                }
            }
            else
            {
                res= QS2.Desktop.ControlManagment.ControlManagment.MessageBox(CurrentRow.Nachname + " " + CurrentRow.Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" hat bereits mindestens einen Aufenthalt und kann ") +
                          QS2.Desktop.ControlManagment.ControlManagment.getRes("daher nicht gelsöcht werden. Soll statt dessen der Bewerberstatus zurückgesetzt werden?"),
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Bewerberstatus zurücksetzen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);
                if (res == DialogResult.Yes)
                {
                    _patBewerber.InitBewerbungsdaten(CurrentRow);
                    _patBewerber.Write();
                }
            }


            RefreshControl();

            if (PatientDeletedDelegate != null)
                PatientDeletedDelegate(idpatient);
        }

        private void btnBewStatus_Click(object sender, EventArgs e)
        {
            if (CurrentRow == null)
                return;
            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Bewerberstatus des Bewerbers \"" + CurrentRow.Nachname + " " + CurrentRow.Vorname + "\" wirklich zurückgesetzt werde?",
                                            "Bewerberstatus zurücksetzen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
                return;
            _patBewerber.InitBewerbungsdaten(CurrentRow);
            _patBewerber.Write();

            ENV.SignalPatientDatenChanged(CurrentRow.ID);//Neu nach 03.07.2007 MDA

            if (BewerberstatusChangedDelegate != null)
                BewerberstatusChangedDelegate(CurrentRow.ID);

            RefreshControl();

            
        }

        private void btnBewDaten_Click(object sender, EventArgs e)
        {
            BewerberDaten();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// aktuell gefilterte Bewerberliste drucken  {{{eng}}} 28.09.2007
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnPrint_Click(object sender, EventArgs e)
        {
            object o = dgBewerber2.DataSource;
            PMDS.Print.frmPrintPreview.PrintBewerberliste(((dsPatientBewerber)o).Patient);
        }
       

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _btnSaershClicked = true;
                RefreshControl();
            }
        }




        private void dgBewerber2_AfterRowActivate(object sender, EventArgs e)
        {
            dgBewerber2.ActiveRow.Selected = true;

            bool enbled = CurrentRow != null;

            btnBewDaten.Enabled = enbled;
            btnBewStatus.Enabled = enbled;
            btnDel.Enabled = enbled;

            if (_InProgress)
                return;

            if (CurrentRow != null && CurrentRow.ID != _IDBewerber && BewerberChangedDelegate != null)
            {
                _IDBewerber = CurrentRow.ID;
                BewerberChangedDelegate(CurrentRow.ID);
            }
        }

        private void dgBewerber2_DoubleClick(object sender, EventArgs e)
        {
            BewerberDaten();
        }

        private void cbAbteilung_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cbAbteilung.Focused)
                {
                    this.loadBereich();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }

        private void cbKlinik_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbKlinik.Focused)
                {
                    dsKlinik.KlinikRow rKlinik = this.getSelKlinik(false);
                    if (rKlinik != null)
                    {
                        this.RefreshListAbteilungen(rKlinik.ID);
                    }
                    else
                    {
                        this.cbAbteilung.Items.Clear();
                        this.cboBereich.Items.Clear();
                        this.cbAbteilung.Value = null;
                        this.cboBereich.Value = null;
                    }
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}
