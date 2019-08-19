using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using PMDS.Data.Global;
using System.IO;
using PMDS.GUI.BaseControls;
using PMDS.Print;
using PMDS.Data.Patient;
using PMDS.DB;
using PMDS.Global.db.Patient;
using System.Linq;
using PMDS.Global.db.Global;


namespace PMDS.GUI
{

    public partial class ucMed23VorbereitenVerabreichen : QS2.Desktop.ControlManagment.BaseControl, ISave, IAufenthalt
    {
        private Guid                 _IDAufenthalt      = Guid.Empty;
        private Medikation           _Medikation        = null;  
        private bool                 _InitInProgress    = true;
        private MedikationListenMode _mode = MedikationListenMode.Vorbereitung;
        private ContextMenu          _timemenu = null;
        private Guid                 _IDAbteilung = Guid.Empty;                     

        private bool                _lastvisible = false;
        private bool                IsInitialized = false;

        public class cMedAufenthaltPatient
        {
            public string sTxtPE = "";
            public Guid IDPatient = System.Guid.Empty;
            public Guid IDAufenthalt = System.Guid.Empty;
        }

        public ucMedikamenteMain ucMedikamenteStammdatenMain = null;

        public PMDSBusiness b = new PMDSBusiness();








        public ucMed23VorbereitenVerabreichen()
        {
            InitializeComponent();
            dtpFrom.Value           = DateTime.Now.Date;
            dtpTo.Value             = DateTime.Now.Date.AddDays(1).AddMinutes(-1);

            UltraGridTools.AddHerrichtenValueList(dgMain, "Herrichten");            
            UltraGridTools.AddVerabreichungValueList(dgMain, "Verabreichungsart");     

            PrepareForMode();

            InitTimeContextMenu();

            _InitInProgress     = false;

            if (DesignMode || !ENV.AppRunning) return;

            HideOrShowGropMehrauswahl();

            if (ENV.MedikamenteAbgebenTabText != "Medikamente verabreichen")
            {
                btnMark.Text = ENV.MedikamenteAbgebenTabText;
                cbShowAbgegebene.Text = "bereitgestellte zeigen";
            }

        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MedikationListenMode MODE
        {
            get { return _mode;  }
            set { _mode = value; PrepareForMode(); }
        }

        public void InitControl()
        {
            if (!this.IsInitialized)
            {
                string defaultLayoutName = "";
                if (_mode == MedikationListenMode.Abgabe)
                {
                    defaultLayoutName = "Medikamente verabreichen";
                    this.dgMain.Name = "gridMedikamenteVerabreichen";
                }
                else if (_mode == MedikationListenMode.Vorbereitung)
                {
                    defaultLayoutName = "Medikamente vorbereiten";
                    this.dgMain.Name = "gridMedikamenteVorbereiten";
                }
                QS2.Desktop.ControlManagment.BaseGrid baseGrid = (QS2.Desktop.ControlManagment.BaseGrid)this.dgMain;
                baseGrid.doBaseElements1.runControlManagmentBaseGridManual(baseGrid, defaultLayoutName);

                this.IsInitialized = true;
            }
        }

        private void PrepareForMode()
        {
            dgMain.DisplayLayout.Bands[0].Columns["Selected"].Hidden            = _mode == MedikationListenMode.Vorbereitung;
            dgMain.DisplayLayout.Bands[0].Columns["Applikationsform"].Hidden    = _mode == MedikationListenMode.Vorbereitung;
            dgMain.DisplayLayout.Bands[0].Columns["Herrichten"].Hidden          = _mode == MedikationListenMode.Abgabe;
            dgMain.DisplayLayout.Bands[0].Columns["Verabreichungsart"].Hidden   = _mode == MedikationListenMode.Abgabe;
            
            cbLangfristig.Checked       = true;
            cbKurzfristig.Checked       = true;
            cbNein.Checked              = _mode == MedikationListenMode.Abgabe;
            cbAerztlich.Checked         = _mode == MedikationListenMode.Abgabe;
            cbSuchtgift.Checked         = _mode == MedikationListenMode.Abgabe;
            cbShowAbgegebene.Visible    = _mode == MedikationListenMode.Abgabe;
            cbAbwesenheit.Visible       = _mode == MedikationListenMode.Abgabe;
            pnlTopMiddle.Visible        = _mode == MedikationListenMode.Abgabe;           
            pnlAusgabe.Visible          = _mode == MedikationListenMode.Abgabe;
            pnlVorbereitung.Visible     = _mode == MedikationListenMode.Vorbereitung;     
            
            dgMain.DisplayLayout.Bands[0].Columns["ZeitenText"].Header.Caption = _mode == MedikationListenMode.Abgabe ? QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeiten"): QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeiten");
            
        }

        public bool Save()
        {
            return true;
        }

        public void Undo()
        {
        }

        public bool IsChanged
        {
            get { return false; }
        }

        public bool ValidateFields()
        {
            return true;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAufenthalt
        {
            get
            {
                return _IDAufenthalt;
            }
            set
            {
                if (value == Guid.Empty || PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl)
                    return;

                //if (value != _IDAufenthalt)
                //{
                    _IDAufenthalt = value;
                    Aufenthalt a = new Aufenthalt(_IDAufenthalt);
                    RefreshControl();
                    InitTimeContextMenu();
                //}
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_InitInProgress)
                    return;
                RefreshMedikation();

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshMedikation()
        {
            try
            {
                this.InitControl();

                if (this.MODE == MedikationListenMode.Abgabe)
                {
                    if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        this.cbAbwesenheit.Checked = false;
                        this.cbAbwesenheit.Visible = false;
                    }
                    else
                    {
                        this.cbAbwesenheit.Checked = false;
                        this.cbAbwesenheit.Visible = true;
                    }
                }
                else
                {
                    this.cbAbwesenheit.Checked = false;
                    this.cbAbwesenheit.Visible = false;
                }

                if (_Medikation == null)
                    _Medikation = new Medikation();

                dgMain.DataMember = "";
                dgMain.DataSource = _Medikation.GetAlleAufbereiteten(dtpFrom.Value.Date, dtpTo.Value, PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt, _mode);
               
                RefreshFilter(false);
                PrepareTimeColumns();

                UltraGridTools.AddMedikationPatientenValueList((dsMedikationVonBis.MedikationDataTable)dgMain.DataSource, dgMain, "IDPatient");
                dgMain.PerformAction(UltraGridAction.FirstRowInGrid);

                if(dgMain.Rows.Count > 0)
                    dgMain.ActiveRowScrollRegion.FirstRow = dgMain.Rows[0];

                if (PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl && dgMain.Rows.Count == 0)
                {
                    //ENV.IDAUFENTHALT = System.Guid.Empty;
                    //ENV.CurrentIDPatient = Guid.Empty;
                    //ENV.sendPatientChanged(eCurrentPatientChange.keiner);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed23VorbereitenVerabreichen.RefreshMedikation: " + ex.ToString());
            } 
        }

        private void PrepareTimeColumns()
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false))
            {
                if (_mode == MedikationListenMode.Abgabe)                               // Bei Abgabe muss der Wert belegt werden (1 bei Tagesspender und bei einzelabgabe die Zeit 0)
                {
                    r.Cells["AnzahlText"].Value = r.Cells["ZP0"].Value.ToString();
                    r.Update();
                    continue;
                }

                bool bnuechtern = false;
                
                bool bstandardzeiten = (bool)r.Cells["StandardzeitenJN"].Value;

                if(bstandardzeiten)
                    bnuechtern = ((double)r.Cells["ZP0"].Value != 0);

                if (!bstandardzeiten || bnuechtern)
                {
                    r.Cells["AnzahlText"].Value = r.Cells["ZP0"].Value.ToString();
                    r.Update();
                    continue;
                }
                r.Cells["Z0"].Value = r.Cells["ZP0"].Value;
                r.Cells["Z1"].Value = r.Cells["ZP1"].Value;
                r.Cells["Z2"].Value = r.Cells["ZP2"].Value;
                r.Cells["Z3"].Value = r.Cells["ZP3"].Value;
                r.Cells["Z4"].Value = r.Cells["ZP4"].Value;
                r.Update();
            }
        }

        private void RefreshFilter(bool bHandleBedinEndUpdate)
        {
            //if (bHandleBedinEndUpdate)
            dgMain.BeginUpdate();
            dgMain.SuspendLayout();
            //dgMain.Visible = false;

            Global.db.ERSystem.dsKlientenliste dsKlientenliste1 = new Global.db.ERSystem.dsKlientenliste();
            PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
            sqlManange1.initControl();
            sqlManange1.getPatientenStart(System.Guid.Empty, 0, System.Guid.Empty, ref dsKlientenliste1, System.Guid.Empty, System.Guid.Empty, System.Guid.Empty);

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                int iCounter = 0;
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                UltraGridRow[] arrGrid = UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false);
                foreach (UltraGridRow r in arrGrid)
                {
                    //dsKlientenliste1.vKlientenliste.Clear();
                    DataRowView v = (DataRowView)r.ListObject;
                    dsMedikationVonBis.MedikationRow rActMedikation = (dsMedikationVonBis.MedikationRow)v.Row;
                    iCounter += 1;

                    bool PatientIstAbwesend = false;
                    bool bAbgegeben = false;
                    bool bAbgabeWaehrendAbwesenheit = false;

                    if (this._mode == MedikationListenMode.Abgabe)
                    {
                        Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow[] arrKlient = (Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow[])dsKlientenliste1.vKlientenliste.Select("IDKlient='" + rActMedikation.IDPatient.ToString()  + "'", "");
                        Global.db.ERSystem.dsKlientenliste.vKlientenlisteRow rKlient = arrKlient[0];

                        if (rKlient.Abwesenheit.Trim() != "")
                        {
                            PatientIstAbwesend = true;
                        }

                        // Abgegebene markieren
                        bAbgegeben = (bool)r.Cells["Abgegeben"].Value;

                        if (this.cbAbwesenheit.Checked)
                        {
                            //Zeilen während Abwesenheiten markieren
                            var tPatientAbwesenheiten = (from uv in db.UrlaubVerlauf
                                                         join a in db.Aufenthalt on uv.IDAufenthalt equals a.ID
                                                         join p in db.Patient on a.IDPatient equals p.ID
                                                         where p.ID == rKlient.IDKlient &&
                                                            uv.StartDatum <= dtpTo.Value &&
                                                            (uv.EndeDatum >= dtpFrom.Value || uv.EndeDatum == null)
                                                         orderby uv.StartDatum ascending
                                                         select new
                                                         {
                                                             uv.StartDatum,
                                                             uv.EndeDatum
                                                         });

                            foreach (var ruv in tPatientAbwesenheiten)
                            {
                                DateTime dtZeitpunkt = (DateTime)r.Cells["MedikationDatum"].Value;
                                if (dtZeitpunkt >= ruv.StartDatum && (ruv.EndeDatum == null || dtZeitpunkt <= ruv.EndeDatum))
                                {
                                    bAbgabeWaehrendAbwesenheit = true;
                                    break;
                                }
                            }
                        }
                        //Zeilen enfärben
                        if (bAbgegeben)
                            UltraGridTools.SetColors(r, Color.Black, Color.LightGreen);
                        else if (bAbgabeWaehrendAbwesenheit)
                            UltraGridTools.SetColors(r, Color.Black, Color.LightBlue);
                        else
                            UltraGridTools.ResetColors(r);
                    }

                    r.Hidden = true;

                    bool bUntertaegig = (bool)r.Cells["UntertaegigJN"].Value;
                    DateTime dtCurrent = (DateTime)r.Cells["MedikationDatum"].Value;

                    if (!(dtCurrent >= dtpFrom.Value && dtCurrent <= dtpTo.Value) && !bUntertaegig)  // Zeiten berücksichtigen
                        continue;

                    if (!cbShowAbgegebene.Checked && bAbgegeben)
                        continue;

                    int i = (int)r.Cells["Herrichten"].Value;
                    if ((cbLangfristig.Checked && i == (int)medHerrichten.langfristig) ||
                        (cbKurzfristig.Checked && i == (int)medHerrichten.kurzfristig) ||
                        (cbNein.Checked && i == (int)medHerrichten.nein) ||
                        (cbAerztlich.Checked && i == (int)medHerrichten.aerztlich) ||
                        (cbSuchtgift.Checked && i == (int)medHerrichten.suchtgift)                    
                        )
                    {
                        r.Hidden = false;
                    }

                    if (PatientIstAbwesend)
                    {
                        r.Hidden = true;
                    }
                }
            }

            // Workaround weil Infragistic im Gruppierungsmodus beim Ändern des Filters Probleme macht
            // Wenn keine Zeilen da waren, kommen keine mehr....
            if (bHandleBedinEndUpdate)
            {
                List<helper> al = new List<helper>();
                foreach (UltraGridColumn c in dgMain.DisplayLayout.Bands[0].SortedColumns)
                    al.Add(new helper(c, c.IsGroupByColumn, c.SortIndicator == SortIndicator.Descending));

                dgMain.DisplayLayout.Bands[0].SortedColumns.Clear();
                foreach (helper h in al)
                    dgMain.DisplayLayout.Bands[0].SortedColumns.Add(h._c, h._desc, h._groupby);
            }

            dgMain.EndUpdate();
            dgMain.PerformLayout();
        }

        private void ucMedikation_VisibleChanged(object sender, EventArgs e)
        {
            HideOrShowGropMehrauswahl();

            if (_lastvisible == this.Visible)       // 17.9.2008 RBU: Problem dass der Event mehrfach aufgerufen wird ohne das sich visible ändert.....
                return;

            _lastvisible = this.Visible;

            if (this.Visible)
            {
                pnlEmpty.Visible = ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht ? true : false;
                RefreshMedikation();
            }
        }

        private void cbLangfristig_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_InitInProgress)
                    return;
                bool b = !((_mode == MedikationListenMode.Abgabe) && cbShowAbgegebene.Checked);
                dgMain.DisplayLayout.Bands[0].Columns["Abgegeben"].Hidden = b;
                dgMain.DisplayLayout.Bands[0].Columns["AbgegebenVon"].Hidden = b;
                RefreshFilter(true);

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SetSelected(true);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void SetSelected(bool bSelected)
        {
            foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false))
            {
                if (r.Hidden)
                    continue;
                r.Cells["Selected"].Value = bSelected;
                r.Update();
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                SetSelected(false);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnMark_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string sProt = "";
                DateTime dNow = DateTime.Now;
                System.Collections.Generic.List<cMedAufenthaltPatient> lstMedAufenthaltPatient = new List<cMedAufenthaltPatient>();
                UltraGridTools.EndCurrentEdit(dgMain);

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    db.Configuration.LazyLoadingEnabled = false;
                    PMDS.db.Entities.Benutzer rUserLoggedOn = this.b.LogggedOnUser(db);

                    //Medikamentenabgabe nicht mehr als 24 Stunden vordatieren
                    if (this.dtpTo.Value > dNow.AddHours(24))
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Abgabe darf nicht mehr als 24 Stunden vor dem geplanten Zeitpunkt gemeldet werden!", "PMDS", MessageBoxButtons.OK);
                        return;
                    }

                    //Count checked rows. If > 500 message -> return.
                    int iCheckedRows = 0;
                    foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false))
                    {
                        if (r.Hidden)
                            continue;

                        Guid IDRezepteintrag = (Guid)r.Cells["ID"].Value;
                        DateTime Zeitpunkt = (DateTime)r.Cells["MedikationDatum"].Value;
                        if ((bool)r.Cells["Selected"].Value)
                        {
                            iCheckedRows++;
                        }
                    }

                    if (iCheckedRows > 500)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie dürfen nicht mehr als 500 Abgaben auf einmal markieren!", "PMDS", MessageBoxButtons.OK);
                        return;
                    }

                    foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false))
                    {
                        if (r.Hidden)
                            continue;

                        if ((bool)r.Cells["Selected"].Value && !((bool)r.Cells["Abgegeben"].Value))
                        {
                            Guid IDPatient = (Guid)r.Cells["IDPatient"].Value;
                            Guid IDAufenthalt = Aufenthalt.LastByPatient(IDPatient);

                            string MedikamentText = (string)r.Cells["Bezeichnung"].Value;
                            if (MedikamentText.Length > 2048)
                                MedikamentText = MedikamentText.Substring(0, 2000);
                            bool TagesspenderJN = (string)r.Cells["Einheit"].Value == "Tagesspender" ? true : false;

                            Guid IDRezepteintrag = (Guid)r.Cells["ID"].Value;
                            DateTime Zeitpunkt = (DateTime)r.Cells["MedikationDatum"].Value;
                            if (!this.b.checkMedikationAbgabeExists(IDRezepteintrag, IDAufenthalt, Zeitpunkt, db))
                            {
                                Medikation.InsertMedikationAbgabe(IDRezepteintrag, Zeitpunkt, (Guid)ENV.USERID, MedikamentText, IDAufenthalt, TagesspenderJN);

                                cMedAufenthaltPatient AufPatAct = null;
                                bool bAufFound = false;
                                foreach (cMedAufenthaltPatient MedPatient in lstMedAufenthaltPatient)
                                {
                                    if (MedPatient.IDAufenthalt == IDAufenthalt)
                                    {
                                        AufPatAct = MedPatient;
                                        bAufFound = true;
                                    }
                                }
                                if (!bAufFound)
                                {
                                    AufPatAct = new cMedAufenthaltPatient();
                                    AufPatAct.IDAufenthalt = IDAufenthalt;
                                    AufPatAct.IDPatient = IDPatient;
                                    AufPatAct.sTxtPE = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament(e) abgegeben:") + "\r\n";
                                    lstMedAufenthaltPatient.Add(AufPatAct);
                                }
                                AufPatAct.sTxtPE += ((DateTime)r.Cells["MedikationDatum"].Value).ToString("dd.MM.yyyy HH:mm:ss") + ": " + MedikamentText.Trim() + "\r\n";


                                r.Cells["Abgegeben"].Value = true;
                            }
                            else
                            {
                                string InfoPatient = this.b.getPatientInfoFromIDAufenthalt(IDAufenthalt, db);
                                string InfoMedikament = this.b.getMedikemantInfoFromIDRezepteintrag(IDRezepteintrag, db);
                                string sMsgTrans = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dem Klienten {0} wurde am {1} das Medikament {2} bereits verabreicht!" + "\r\n" + "Das Medikament wird daher nicht verabreicht!");
                                sMsgTrans = string.Format(sMsgTrans, InfoPatient, Zeitpunkt.ToString("dd.MM.yyyy HH:mm:ss"), InfoMedikament) + "\r\n";
                                sProt += "" + sMsgTrans + "\r\n";
                            }
                        }

                        r.Cells["Selected"].Value = false;
                        r.Cells["AbgegebenVon"].Value = rUserLoggedOn.Nachname.Trim() + " " + rUserLoggedOn.Vorname.Trim();
                        r.Update();
                    }
                }

                if (lstMedAufenthaltPatient.Count > 0)
                {
                    foreach (cMedAufenthaltPatient MedAufenthaltPatient in lstMedAufenthaltPatient)
                    {
                        PflegeEintrag.InsertPflegeeintrag(MedAufenthaltPatient.IDAufenthalt, dNow, MedAufenthaltPatient.sTxtPE.Trim(), PflegeEintragTyp.MEDIKAMENT, "Medikation");
                    }
                    RefreshFilter(true);
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Medikamente ausgewählt!", "Medikamente verabreichen", MessageBoxButtons.OK);
                }

                if (sProt.Trim() != "")
                {
                    qs2.core.vb.frmProtocol frmProt = new qs2.core.vb.frmProtocol();
                    frmProt.initControl();
                    frmProt.Show();
                    frmProt.ContProtocol1.setText(sProt.Trim());
                    frmProt.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll Medikamente verabreichen");
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                object[] iVorberArry = { 9, 9, 9, 9, 9, 9, 0 };
                if (cbNein.Checked) iVorberArry[0] = medHerrichten.nein;
                if (cbKurzfristig.Checked) iVorberArry[1] = medHerrichten.kurzfristig;
                if (cbLangfristig.Checked) iVorberArry[2] = medHerrichten.langfristig;
                if (cbBedarf.Checked) iVorberArry[3] = medHerrichten.beiBedarf;
                if (cbAerztlich.Checked) iVorberArry[4] = medHerrichten.aerztlich;
                if (cbSuchtgift.Checked) iVorberArry[5] = medHerrichten.suchtgift;

                bool bAnmerkungJN = cbAnmerkung.Checked;
                bool bKlientenansichtJN;
                if (ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Klientanansicht)
                    bKlientenansichtJN = true;
                else bKlientenansichtJN = false;
              
                dsMedikationVonBis.MedikationDataTable tMedikationVonBisGridTmp = (dsMedikationVonBis.MedikationDataTable)this.dgMain.DataSource;
                System.Collections.Generic.List<Guid> lstPatientsTmp = new List<Guid>();
                foreach (dsMedikationVonBis.MedikationRow rMed in tMedikationVonBisGridTmp)
                {
                    if (!rMed.IsIDPatientNull())
                    {
                        if (!lstPatientsTmp.Contains(rMed.IDPatient))
                        {
                            lstPatientsTmp.Add(rMed.IDPatient);
                        }
                    }
                }

                string lstPatients = "";
                foreach (Guid IDPatient in lstPatientsTmp)
                {
                    lstPatients += IDPatient.ToString() + ";";
                }

                Guid IDAufenthaltAct = Aufenthalt.LastByPatient(PMDS.Global.ENV.CurrentIDPatient);
                PMDS.Print.ReportManager.PrintMedvorbereitung(bKlientenansichtJN, ENV.CurrentIDAbteilung, ENV.CurrentIDBereich, IDAufenthaltAct, dtpFrom.Value, dtpTo.Value, (int)iVorberArry[0], (int)iVorberArry[1], 
                                                                (int)iVorberArry[2], (int)iVorberArry[3], (int)iVorberArry[4], (int)iVorberArry[5], bAnmerkungJN, lstPatients);
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }       

        private void btnPrintMedAusgabe_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ProcessPrint();
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
        }

        private void ProcessPrint()
        {
            List<Guid> al = new List<Guid>();
            al.Add(IDAufenthalt);

            if (ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Bereichsansicht)            // In der Bereichsansicht alle gelisteten hinzufügen
                al = GuiUtil.GetIDAbteilungenforCurrentSelection(false, true, PMDS.Global.ENV.IDKlinik);

            dsMedikationVonBis.MedikationDataTable dtres    = new dsMedikationVonBis.MedikationDataTable();
            dsMedikationVonBis.MedikationDataTable dt       =  _Medikation.GetAlleAufbereiteten(dtpFrom.Value.Date, dtpTo.Value, al, _mode);
            AddWithFilter(dtres, dt);

            PMDS.Print.frmPrintPreview.PreviewMedikamentenAusgabe(dtres);
        }

        private void AddWithFilter(dsMedikationVonBis.MedikationDataTable dtres, dsMedikationVonBis.MedikationDataTable dt)
        {
            foreach (dsMedikationVonBis.MedikationRow r in dt)
            {
                bool bUntertaegig = r.UntertaegigJN;
                DateTime dtCurrent = r.MedikationDatum;
                
                bool bAbgegeben = false;
                
                if (_mode == MedikationListenMode.Abgabe)
                    bAbgegeben = r.Abgegeben;
                
                if (!(dtCurrent >= dtpFrom.Value && dtCurrent <= dtpTo.Value) && !bUntertaegig)  // Zeiten berücksichtigen nicht innerhalb der Zeit ==> nicht anfügen
                    continue;

                if (!cbShowAbgegebene.Checked && bAbgegeben)
                    continue;

                int i = r.Herrichten;
                if ((cbLangfristig.Checked && i == (int)medHerrichten.langfristig) ||
                    (cbKurzfristig.Checked && i == (int)medHerrichten.kurzfristig) ||
                    (cbNein.Checked && i == (int)medHerrichten.nein) ||
                    (cbAerztlich.Checked && i == (int)medHerrichten.aerztlich) ||
                    (cbSuchtgift.Checked && i == (int)medHerrichten.suchtgift)
                   )
                {
                    dtres.Rows.Add(r.ItemArray);                                             
                }
            }
        }

        public void setControlsAktivDisable(bool bOn)
        {
            //PMDS.GUI.BaseControls.historie.OnOffControls(this, bOn);        //cbMehrfach
            ultraGroupBoxHandzeichen.Visible = !bOn;
            gbAbzeichnen.Visible = !bOn;

        }
        //Neu nach 25.01.2008 MDA
        private void HideOrShowGropMehrauswahl()
        {
            this.pnlEmpty .Visible = ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht;
        }

        public void RefreshControl()
        {
            if (Visible)
            {
                RefreshMedikation();

                bool LayoutFound = false;
                qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                compLayout1.initControl();
                compLayout1.doLayoutGrid(this.dgMain, this.dgMain.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                QS2.Desktop.ControlManagment.BaseGrid.doFormatDateTime(this.dgMain);
            }  
        }
        
        private void btnAbzeichnen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Guid idBenutzer = ENV.USERID;

                if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht && PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl)
                {
                    UltraGridTools.EndCurrentEdit(dgMain);
                    List<Guid> lID = new List<Guid>();
                    Patient p;
                    foreach (UltraGridRow r in UltraGridTools.GetAllRowsFromGroupedUltraGrid(dgMain, false))
                    {
                        if (r.Hidden)
                            continue;
                        p = new Patient((Guid)r.Cells["IDPatient"].Value);
                        if (lID.IndexOf(p.Aufenthalt.ID) == -1)
                        {
                            lID.Add(p.Aufenthalt.ID);
                            PflegeEintrag.NewMedikamentVorbereitenAbzeichnenEinfuegen(p.Aufenthalt.ID, DateTime.Now, idBenutzer);
                        }
                    }
                    lID.Clear();    
                }
                else
                {
                    Guid IDAufenthalt = Aufenthalt.LastByPatient(PMDS.Global.ENV.CurrentIDPatient);
                    if (IDAufenthalt != System.Guid.Empty)
                    {
                        PflegeEintrag.NewMedikamentVorbereitenAbzeichnenEinfuegen(IDAufenthalt, DateTime.Now, idBenutzer);
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Vorbereitung wurde abgezeichnet", "Vorbereitung wurde abgezeichnet", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Aufenthalt ausgewählt!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnTimes_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _timemenu.Show(this, new Point(btnTimes.Left, btnTimes.Top + btnTimes.Height));

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void InitTimeContextMenu()
        {
            if (_timemenu != null && ENV.ABTEILUNG == _IDAbteilung)     // für die Abteilung bereits initialisert
                return;

            _IDAbteilung = ENV.ABTEILUNG;

            if (_timemenu != null)
                _timemenu.Dispose();

            _timemenu = new ContextMenu();
            
            MenuItem item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Heute"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.Date.AddDays(1).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Morgen"));
            item.Tag = new timehelper(DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(2).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Woche ab Heute"));
            item.Tag = new timehelper(DateTime.Now.Date, DateTime.Now.Date.AddDays(7).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Woche ab Morgen"));
            item.Tag = new timehelper(DateTime.Now.Date.AddDays(1), DateTime.Now.Date.AddDays(8).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächster ") + (Wochentage)((int)(DateTime.Now.Date.DayOfWeek)));
            item.Tag = new timehelper(DateTime.Now.Date.AddDays(7), DateTime.Now.Date.AddDays(8).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);

            item = _timemenu.MenuItems.Add(QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächster ") + (Wochentage)((int)(DateTime.Now.Date.AddDays(1).DayOfWeek)));
            item.Tag = new timehelper(DateTime.Now.Date.AddDays(8), DateTime.Now.Date.AddDays(9).AddMinutes(-1));
            item.Click += new EventHandler(Timeitem_Click);
          
            _timemenu.MenuItems.Add("-");

            // Dienstzeiten reinhängen
            DienstZeitenManager manager = new DienstZeitenManager();
             
            dsDienstZeiten.DienstzeitenDataTable dt = manager.ReadAll(_IDAbteilung);
            foreach (dsDienstZeiten.DienstzeitenRow r in dt)
            {
                if (r.VerwendenIn.Trim() != "NA" && (r.VerwendenIn.Trim().Equals(("")) || r.VerwendenIn.Trim().ToLower().Equals(("M").Trim().ToLower()) || r.VerwendenIn.Trim().ToLower().Equals(("IM").Trim().ToLower())))
                {
                    item = _timemenu.MenuItems.Add(r.Bezeichnung);
                    DateTime dtfrom = DateTime.Now.Date.AddHours(r.Von.Hour).AddMinutes(r.Von.Minute);
                    DateTime dtto = DateTime.Now.Date.AddHours(r.Bis.Hour).AddMinutes(r.Bis.Minute);
                    if (r.Bis.Hour < r.Von.Hour)
                        dtto = dtto.AddDays(1);
                    item.Tag = new timehelper(dtfrom, dtto);
                    item.Click += new EventHandler(Timeitem_Click);
                }
            }
        }

        void Timeitem_Click(object sender, EventArgs e)
        {
            MenuItem item   = (MenuItem)sender;
            timehelper h    = (timehelper)item.Tag;
            _InitInProgress = true;
            dtpFrom.Value   = h._from;
            dtpTo.Value     = h._to;
            _InitInProgress = false;
            
            RefreshMedikation();
        }

        private void ucMedikation_Load(object sender, EventArgs e)
        {
            if (DesignMode || !ENV.AppRunning) return;

        }

        private void dgMain_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                if (dgMain.Focused)
                {
                    if (PMDS.Global.historie.HistorieOn) return;
                    if (dgMain.ActiveRow.IsGroupByRow) 
                        return;

                    if (dgMain.ActiveRow.Cells["Abgegeben"].Value != DBNull.Value && (bool)dgMain.ActiveRow.Cells["Abgegeben"].Value == true)
                    {
                        dgMain.ActiveRow.Activation = Activation.NoEdit;
                    }
                    else
                        dgMain.ActiveRow.Activation = Activation.AllowEdit;

                    //if (PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl)
                    //{
                    //    //ENV.IDAUFENTHALT = Aufenthalt.LastByPatient((Guid)dgMain.ActiveRow.Cells["IDPatient"].Value);
                    //    //ENV.CurrentIDPatient = (Guid)dgMain.ActiveRow.Cells["IDPatient"].Value;
                    //    //ENV.sendPatientChanged(eCurrentPatientChange.keiner);

                    //    //this.ucMedikamenteStammdatenMain.ucMedikamenteMainPickerMain.SelectPatientInTree(ENV.CurrentIDPatient);
                    //}
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }   
        }

        private void gbPrintAusgabe_Click(object sender, EventArgs e)
        {

        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dgMain_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void btnTerminErstellen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!PMDS.GUI.Medikament.cMedListKlienten._Mehrfachauswahl)
                {
                    if (PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Count != 1)
                    {
                        throw new Exception("btnTerminErstellen_Click: PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt.Count!=1 not allowed!");
                    }
                    Guid IDAufenthaltAct = PMDS.GUI.Medikament.cMedListKlienten._lIDAufenthalt[0];
                    GuiAction.InsertTermin(IDAufenthaltAct, false, (Form)GuiWorkflow.mainWindow, null, null, null);
                }
                else
                {
                    Infragistics.Win.UltraWinGrid.UltraGridRow gridRow = null;
                    dsMedikationVonBis.MedikationRow rSelRow = this.getSelectedRow(true, ref gridRow);
                    if (rSelRow != null)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(rSelRow.IDPatient, false, db);
                            GuiAction.InsertTermin(rAufenthalt.ID, false, (Form)GuiWorkflow.mainWindow, null, null, null);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public dsMedikationVonBis.MedikationRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.dgMain.ActiveRow != null)
                {
                    if (this.dgMain.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.dgMain.ActiveRow.ListObject;
                        dsMedikationVonBis.MedikationRow  rSelRow = (dsMedikationVonBis.MedikationRow)v.Row;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucMed23VorbereitenVerabreichen.getSelectedRow: " + ex.ToString());
            }

        }

    }

}

