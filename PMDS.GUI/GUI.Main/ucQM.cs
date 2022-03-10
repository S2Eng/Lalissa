//----------------------------------------------------------------------------
/// <summary>
///	ucGruppe.cs
/// Erstellt am:	17.4.2008
/// Erstellt von:	RBU
/// Control zur darstellung und Verarbeitung der QuickMeldungen
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
using PMDS.Data.Patient;
using Infragistics.Win.Misc;
using PMDS.Global;
using PMDS.Data.Global;
using PMDS.GUI.BaseControls;
using VirtualKeyboard;
using PMDS.Data.PflegePlan;
using PMDS.DB;
using PMDS.Global.db.Pflegeplan;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucQM : QS2.Desktop.ControlManagment.BaseControl
    {
        private bool    _initInProgress = true;
        private QM      _QM;

        public ucQMButton  lastMassClicked;

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucQM()
        {
            try
            {

                InitializeComponent();
                if (!ENV.AppRunning)
                    return;
                _QM = new QM();

                this.ucBigAbteilungsAuswahl1.cMain = this;

                ucBigAbteilungsAuswahl1.InitControl(60);
                ucBigBenutzerAuswahl1.InitControl(100, 100);
                ucBigBenutzerAuswahl1.DroppingDown += new CancelEventHandler(ucBigBenutzerAuswahl1_DroppingDown);

                _initInProgress = false;
            }
            catch (Exception exch)
            {
                ENV.HandleException(exch);
            }
            finally
            {
            }
       }

        void ucBigBenutzerAuswahl1_DroppingDown(object sender, CancelEventArgs e)
        {
            ucBigKlientenSelector1.Visible = false;
            ucBigAbteilungsAuswahl1.Visible = false;
            ClearKlientenList();   
        }

        public void MyLocationChanged()
        {
            SetNewPopupRegionForKlientSelector();
        }
        

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klienten aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshKlienten()
        {
            if (_initInProgress)
                return;

            
            RefreshButtons();
        }


        private Guid CURRENT_IDPATIENT
        {
            get
            {
                return ucBigKlientenSelector1.IDPATIENT;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Knöpfe aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshButtons()
        {
            if (_initInProgress)
                return;

            try
            {
                this.ucBigRMMain1.Visible = false;
                pnlBottom.Visible = false;
                pnlButtons.Visible = false;
                //pnlButtons.Controls.Clear();
                foreach (object  contButt in pnlButtons.Controls)
                {
                    if (contButt.GetType().ToString() == "PMDS.GUI.ucQMButton")
                    {
                        ((ucQMButton)contButt).Visible = false;
                    }
                }

                if (CURRENT_IDPATIENT == Guid.Empty)
                    return;

                int lastIndex = 1;
                int maxIndex = pnlButtons.Controls.Count;
                bool firstButt = true;
                pnlBottom.Visible = true;

                SortedDictionary<string, QMEintrag> al = new SortedDictionary<string, QMEintrag>();
                Guid IDLastUntertaegigeGruppe = Guid.Empty;
                
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.db.Entities.Aufenthalt rAufenthalt = PMDSBusiness1.getAktuellerAufenthaltPatient(CURRENT_IDPATIENT, true, null);
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    int iCounter = 0;
                    PMDS.Global.db.ERSystem.dsTermine dsTermine1 = new Global.db.ERSystem.dsTermine();
                    this.getTermine(rAufenthalt.ID, (Guid)rAufenthalt.IDAbteilung, (Guid)rAufenthalt.IDBereich, dsTermine1, db);

                    bool IsAbwesend = false;
                    PMDSBusiness1.getOffenenUrlaub(db, rAufenthalt.ID, ref IsAbwesend);
                    if (!IsAbwesend)
                    {
                        QMEintrag Aktuellereintrag = new QMEintrag();
                        PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow[] arrInterv = (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow[])dsTermine1.vInterventionen.Select("TerminJN=0 AND UrlaubJN=0 AND EntlassenJN=0  AND ErledigtJN=0 AND GelöschtJN=0 AND AbgesetztJN=0", dsTermine1.vInterventionen.IDUntertaegigeGruppeColumn.ColumnName + " asc, " + dsTermine1.vInterventionen.vonColumn.ColumnName + " asc ");
                        foreach (PMDS.Global.db.ERSystem.dsTermine.vInterventionenRow rIntervention in arrInterv)
                        {
                            if (!rIntervention.IsIDEintragNull())
                            {
                                DBPflegePlan DBPflegePlan1 = new DBPflegePlan();

                                //Prüfung auf besonderen Berufsstand zur Rückmeldung
                                if (!PMDSBusiness1.UserCanSign(rIntervention.IDBerufsstand))
                                {
                                    //System.Windows.Forms.QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rückmelden nicht möglich: Qualifikation nicht ausreichend, falscher Berufsstand oder kein Recht."); Maßnahme unterdrücken
                                    continue;
                                }
                                DBPflegePlan1.ReadOnce(rIntervention.IDPflegeplan);
                                dsPflegePlan.PflegePlanRow rPP = (dsPflegePlan.PflegePlanRow)DBPflegePlan1.dsPflegePlan1.PflegePlan.Rows[0];
                                PMDS.db.Entities.Eintrag rEintrag = PMDSBusiness1.GetEintrag(db, rIntervention.IDEintrag);

                                if (rIntervention.IDUntertaegigeGruppe != IDLastUntertaegigeGruppe)                   // Gruppenwechsel
                                {
                                    Aktuellereintrag = new QMEintrag();
                                    FillZusatzRows(rEintrag.ID, Aktuellereintrag);
                                    al.Add(rIntervention.Maßnahme.Trim() + "_" + rIntervention.IDUntertaegigeGruppe.ToString(), Aktuellereintrag);
                                    iCounter = 0;
                                }

                                if (iCounter == 0)
                                {
                                    Aktuellereintrag.Firsttext = (rIntervention.Maßnahme.Trim() + "\n" + rIntervention.Anmerkung_und_Hinweis).Trim();         //rEintrag.Text;
                                    Aktuellereintrag.IDEintrag = rEintrag.ID;
                                }
                                QMEintrag.cPflegepläneProButton PflegepläneProButton = new QMEintrag.cPflegepläneProButton();
                                PflegepläneProButton.r = rPP;
                                PflegepläneProButton.rIntervention = rIntervention;
                                Aktuellereintrag._pprows.Add(PflegepläneProButton);

                                IDLastUntertaegigeGruppe = rIntervention.IDUntertaegigeGruppe;
                                iCounter++;
                            }
                        } 
                    }
                }
               
                //List<QMEintrag> al = _QM.GetAllMxy(Aufenthalt.LastByPatient(CURRENT_IDPATIENT));
                foreach (KeyValuePair<string, QMEintrag> pairValue in al)
                {
                    ucQMButton btnAct = null;
                    if (lastIndex <= maxIndex - 1)
                    {
                        ucQMButton btn = (ucQMButton)pnlButtons.Controls[lastIndex];
                        btnAct = btn;
                        btn._QMEintrag = pairValue.Value;
                        btn.RefreshControl();
                        btn.Visible = true;
                        lastIndex += 1;
                        if (firstButt) this.lastMassClicked = btn;
                    }
                    else
                    {
                        ucQMButton btn = new ucQMButton(pairValue.Value);
                        btnAct = btn;
                        btn.BorderStyle = BorderStyle.FixedSingle;
                        btn.Click += new QMButtonClickDelegate(btn_Click);
                        btn.modalWIndow = this;
                        pnlButtons.AutoScroll = true;
                        pnlButtons.Controls.Add(btn);
                        if (firstButt) this.lastMassClicked = btn;
                    }

                    firstButt = false;
                }

                string xy = "";
            }
            finally
            {
                pnlButtons.Visible = true;
                if (lastMassClicked != null ) this.lastMassClicked.btnFocus.Focus();
            }
        }
        public void getTermine(Guid IDAufenthalt, Guid IDAbteilung, Guid IDBereich, PMDS.Global.db.ERSystem.dsTermine ds,
                                PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {         
                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDS.DB.DBTerminePara dbPar = new PMDS.DB.DBTerminePara();

                DateTime dNow = DateTime.Now;
                dbPar.From = dNow.Date;                     //new DateTime(1900, 1, 1);
                dbPar.To = new DateTime(3000, 1, 1);            // new DateTime(dNow.Year, dNow.Month, dNow.Day, 23, 59, 59);

                dbPar.IDAufenthalt = IDAufenthalt;
                //dbPar.IDAbteilung = IDAbteilung;
                //dbPar.IDBereich = IDBereich;

                TerminlisteAnsichtsmodi Ansichtsmodi = TerminlisteAnsichtsmodi.Klientanansicht;
                dbPar.ansicht = TerminlisteAnsichtsmodi.Klientanansicht;
                PMDS.Global.eUITypeTermine UITypeTermine = eUITypeTermine.Interventionen;
                string _SqlCommand = "";
                List<Guid> lstTmpKlienten = null;
                PMDSBusiness1.getTermine(ref UITypeTermine, ENV.IDKlinik, ref Ansichtsmodi,
                                            ref dbPar, ref ds, ref _SqlCommand, ref ucTermine.dsKlientenlisteStartGrid, ref lstTmpKlienten);

            }
            catch (Exception ex)
            {
                throw new Exception("ucQm.getTermine: " + ex.ToString());
            }
        }
        public void FillZusatzRows(Guid IDEintrag, QMEintrag QMe)
        {
            QMe._zusatzrows.Clear();
            DBQM db = new DBQM();
            dsZusatzwerteForEintrag.ZusatzEintragDataTable dt = db.GetZusatzwerte(IDEintrag, ENV.ABTEILUNG);
            foreach (dsZusatzwerteForEintrag.ZusatzEintragRow r in dt)
                QMe._zusatzrows.Add(r);
        }
      
        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf eine M
        /// </summary>
        //----------------------------------------------------------------------------
        void btn_Click(QMEintrag.cPflegepläneProButton PflegepläneProButton, QMEintrag QMe)
        {
            this.lastMassClicked.btnFocus.Focus();
            this.ucBigRMMain1.Visible = false;
            if (QMe.MeldungZwingend)         // Prüfen ob Dialog zwingend erforderlich ist wenn Ja dann BigRM öffnen und raus
            {
                ShowBigRM(PflegepläneProButton.r, QMe, BigRMModes.Normal);
                return;
            }

            // Abfragedialog öffnen und je nach Action handeln
            string sTimeText;

            if (!PflegepläneProButton.r.IsIDZeitbereichNull())
                sTimeText = Zeitbereich.GetText(PflegepläneProButton.r.IDZeitbereich);
            else
                sTimeText = PflegepläneProButton.r.StartDatum.ToShortTimeString();

            if (PflegepläneProButton.r.OhneZeitBezug)
                sTimeText = "";

            frmBigAbzeichnenFrage2 frm = new frmBigAbzeichnenFrage2(PflegepläneProButton.r.Text + "\r\n\r\n" + sTimeText);
            if (QMe._pprows.Count > 0 && (QMe._pprows[0].r.OhneZeitBezug || QMe._pprows[0].r.Intervall == 24))
                frm.HideMorgenwieder();

            frm.ShowDialog();
            BigAbzeichnenActions res = frm.DialogResult;

            switch (res)
            {
                case BigAbzeichnenActions.Abzeichnen:
                    Abzeichnen(PflegepläneProButton.r, false);
                    break;
                case BigAbzeichnenActions.Morgen:
                    Abzeichnen(PflegepläneProButton.r, true);
                    break;
                case BigAbzeichnenActions.Dialog:
                    ShowBigRM(PflegepläneProButton.r, QMe, BigRMModes.Normal);
                    break;
                case BigAbzeichnenActions.Abbrechen:
                    return;
                default:
                    break;
            }
           
            
        }

        private void Abzeichnen(dsPflegePlan.PflegePlanRow pprow, bool bMorgenWieder)
        {
            Cursor.Current = Cursors.WaitCursor;

            PflegeEintrag pe    = PflegeEintrag.NewByPflegePlan(ENV.IDAUFENTHALT, pprow.ID, pprow.IDEintrag, DateTime.Now, false);
            pe.IDAufenthalt     = ENV.IDAUFENTHALT;
            pe.IDBenutzer       = ENV.USERID;
            pe.IDPflegePlan     = pprow.ID;
            pe.Zeitpunkt        = DateTime.Now;
            pe.DurchgefuehrtJN  = true;
            pe.IstDauer         = 0;
            pe.Text             = "";
            pe.IDWichtig        = Guid.Empty;
            pe.IDEintrag        = pprow.IDEintrag;

            //PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
            //bool DatOK = b.checkDateRückmeldung(ZEITPUNKT);    //lthok
            //if (!DatOK)
            //{
            //    return false;
            //}

            pe.Write();
            //BUtil.UpdatePflegePlan(pe, pprow.EinmaligJN, bMorgenWieder);
                
            DateTime NächstesDatum = DateTime.MinValue;
            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
            {
                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();    //lthok
                PMDS.db.Entities.PflegePlan rPflegeplan = null;
                b.UpdatePflegePlanBeiRückmeldung(pe.IDPflegePlan, db, ref  NächstesDatum, rPflegeplan, false, pe.Zeitpunkt, true);
                //uc.auswahlGruppeComboMulti1.AddCC(pe.ID, true);
            }

            if (this.lastMassClicked != null)
            {
                this.lastMassClicked.RefreshControl();
                this.lastMassClicked.btnFocus.Focus();
            }
            

           // RefreshButtons();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf eine M
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowBigRM(PMDS.Data.PflegePlan.dsPflegePlan.PflegePlanRow pprow, QMEintrag QMe, BigRMModes mode)
        {
            this.ucBigRMMain1 .clearContrl();
            this.ucBigRMMain1.InitControl(pprow, BigRMModes.Normal, QMe);
            ProcessBigRMFrm(this.ucBigRMMain1);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Ungeplante M soll gemeldet werden
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowBigUngeplantRM(Guid IDEintrag)
        {
            this.ucBigRMMain1.clearContrl();
            this.ucBigRMMain1.InitControl(BigRMModes.UgeplanteM, IDEintrag);
            ProcessBigRMFrm(this.ucBigRMMain1);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Bedarfsmedikation soll gemeldet werden
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowBigBedarfsMedikationRM()
        {
            this.ucBigRMMain1.clearContrl();
            this.ucBigRMMain1.InitControlBedarfsMediaktion();
            ProcessBigRMFrm(this.ucBigRMMain1);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Dekurs soll gemeldet werden
        /// </summary>
        //----------------------------------------------------------------------------
        private void ShowBigFreierBerichtRM()
        {
            this.ucBigRMMain1.clearContrl();
            this.ucBigRMMain1.InitControlFreierBericht();
            ProcessBigRMFrm(this.ucBigRMMain1);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Aufruf des Rückmeldefensters
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessBigRMFrm(ucBigRMMain frm)
        {
            //frm.StartPosition = FormStartPosition.Manual;
            //Point p = PointToScreen(new Point(0, ucBigBenutzerAuswahl1.Top + ucBigBenutzerAuswahl1.Height + 2));
            //frm.Top = p.Y;
            //frm.Left = p.X;
            //frm.Width = this.Width;
            //frm.Height = this.Height - ucBigBenutzerAuswahl1.Top - ucBigBenutzerAuswahl1.Height;

            //QM._LastFormViewArea = new Rectangle(frm.Left, frm.Top, frm.Width, frm.Height);

            this.ucBigRMMain1.bOK = false;
            this.ucBigRMMain1.Visible = true;
            while (this.ucBigRMMain1.Visible)
            {
                Application .DoEvents ();
            }
            if (frm.bOK )
            {
                if (this.lastMassClicked != null)
                {
                    this.ucBigRMMain1.bOK = false;
                    this.lastMassClicked.RefreshControl();
                    this.lastMassClicked.btnFocus.Focus();
                }
            }
        }

        

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Abteilung hat sich geändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucBigAbteilungsAuswahl1_SelectionChanged(object sender, EventArgs e)
        {
            ucBigKlientenSelector1.Visible = true;
            ClearKlientenList();

            ucBigKlientenSelector1.SetParams(ucBigAbteilungsAuswahl1.IDABTEILUNG, ucBigAbteilungsAuswahl1.IDBEREICH);
            if(!_initInProgress)
                ucBigKlientenSelector1.DoPopup();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klientenliste löschen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ClearKlientenList()
        {
            ucBigKlientenSelector1.ClearKlientenList();
            RefreshButtons();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Load event
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucQM_Load(object sender, EventArgs e)
        {
            ucBigKlientenSelector1.ClearKlientenList();
            SetNewPopupRegionForKlientSelector();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Popup setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void SetNewPopupRegionForKlientSelector()
        {
            Point w = PointToScreen(new Point(this.Left, this.Top));
            ucBigKlientenSelector1.SetPopupRegion(w.X, w.Y + pnlBereich.Height, this.Width, this.Height-pnlBereich.Height);
            ucBigBenutzerAuswahl1.SetPopupRegion(w.X, w.Y + pnlBereich.Height, this.Width, this.Height - pnlBereich.Height);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klient hat sich geändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucBigKlientenSelector1_SelectionChanged(object sender, EventArgs e)
        {
            ENV.setIDAUFENTHALT = Guid.Empty;
            
            if(CURRENT_IDPATIENT != Guid.Empty)
                ENV.setIDAUFENTHALT = Aufenthalt.LastByPatient(CURRENT_IDPATIENT);

            ENV.setCurrentIDPatient = CURRENT_IDPATIENT;
            ENV.sendPatientChanged(eCurrentPatientChange.keiner, true, false);

            Patient p       = new Patient(ENV.CurrentIDPatient);
            ENV.ABTEILUNG   = p.Aufenthalt.Verlauf.IDAbteilung_Nach;
            ENV.ABTEILUNG_RMOPTIONAL = KlinikAbteilungen.IsAbteilungRMOptional(ENV.ABTEILUNG);

            RefreshButtons();

            dsGUIDListe.IDListeDataTable dt = Rezept.GetBedarfsMedikamente(ENV.IDAUFENTHALT, DateTime.Now);
            btnBedarfsM.Visible = dt.Count > 0;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Änderung ==> Popup anpassen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucQM_Resize(object sender, EventArgs e)
        {
            SetNewPopupRegionForKlientSelector();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Beim Visiblechanged die Popupregion setzen
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucQM_VisibleChanged(object sender, EventArgs e)
        {
            SetNewPopupRegionForKlientSelector();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Benutzerauswahl hat sich geändert
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucBigBenutzerAuswahl1_SelectionChanged(object sender, EventArgs e)
        {
            Guid IDUser = ucBigBenutzerAuswahl1.IDBENUTZER;
            ENV.setUSERID = IDUser;

            if (IDUser == Guid.Empty)
            {
                ucBigAbteilungsAuswahl1.Visible = false;
                ucBigKlientenSelector1.Visible = false;
                ucBigKlientenSelector1.ClearKlientenList();
                return;
            }

            ucBigAbteilungsAuswahl1.Visible = true;
            Benutzer b = new Benutzer(IDUser);
            PMDS.DB.PMDSBusiness b2 = new DB.PMDSBusiness();
            b2.initUserCanSign();

            ENV.UserWithAbteilungLoggedOn(b.ID, b.IDBerufsstand, Gruppe.ByBenutzer(b.ID), b.PflegerJN);

            this.ucBigAbteilungsAuswahl1.ucBigComboBoxKliniken1.loadComboKlinikenUsr();
            List<Guid> al = ucBigAbteilungsAuswahl1.refreshKlinik(false);
            //foreach (dsBenutzerAbteilung.BenutzerAbteilungRow r in b.BenutzerAbteilung)
            //    al.Add(r.IDAbteilung);
            ucBigAbteilungsAuswahl1.RefreshAbteilungsListe(al.ToArray(), true);
            ucBigKlientenSelector1.ClearKlientenList();
            RefreshButtons();

            Point w = PointToScreen(new Point(ucBigAbteilungsAuswahl1.Left, ucBigAbteilungsAuswahl1.Top + ucBigAbteilungsAuswahl1.Height));
            ucBigAbteilungsAuswahl1.DoPopup(w.X, w.Y);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf UngeplanteM
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnUngeplM_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            Guid IDEintrag = Guid.Empty;
            ShowBigUngeplantRM(IDEintrag);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf Bedarfsmedikation
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnBedarfsM_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            ShowBigBedarfsMedikationRM();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        ///	Klick auf Dekurs
        /// </summary>
        //----------------------------------------------------------------------------
        private void btnFreierBericht_Click(object sender, EventArgs e)
        {
            ucVKey.PlayKlick();
            ShowBigFreierBerichtRM();
        }

        private void ucBigAbteilungsAuswahl1_Load(object sender, EventArgs e)
        {

        }

        private void btnFocus_Click(object sender, EventArgs e)
        {

        }

        private void ucBigBenutzerAuswahl1_Load(object sender, EventArgs e)
        {

        }

        private void ucBigKlientenSelector1_Load(object sender, EventArgs e)
        {

        }
    }
}
