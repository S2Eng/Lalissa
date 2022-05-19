using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.IO;

using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Global.db.Global;
using System.Collections.Generic;
using System.Linq;

namespace PMDS.GUI
{   
	public class ucSiteMapTermine :  IPMDSGUIObject
	{
        public static bool FirstCallDoRefreshKlienten { get; set; } = true;
        public bool FirstCallRefresh = true;
        public ucTermineEx _TermineEx;
        public TerminlisteAnsichtsmodi _ansichtmodi = TerminlisteAnsichtsmodi.none;
        public PMDS.Global.eUITypeTermine _UITypeTermine = eUITypeTermine.None;

        private Guid LastSelectedPatient = Guid.Empty;
        private string _AREA = ENV.String("GUI_AREA_TERMINLISTE");
       
        public delegate void PatientSelectionChangedDelegate(Guid IDPatient, Guid IDAufenthalt);
        public event PatientSelectionChangedDelegate PatientSelectionChanged;

        public void initControl()
		{
            try
            {
                ucTermineEx TermineExTmp = this.getTermineEx();

                if (this._ansichtmodi == Global.TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    if (this._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                    }
                    else if (this._UITypeTermine == eUITypeTermine.Übergabe)
                    {
                    }
                    else if (this._UITypeTermine == eUITypeTermine.Dekurs)
                    {
                    }
                    else
                    {
                        throw new Exception("ucSiteMapTermine: UITypeTermine'" + this._UITypeTermine.ToString() + "' for TerminlisteAnsichtsmodi '" + this._ansichtmodi.ToString() + "' not allowed!");
                    }
                }
                else if (this._ansichtmodi == Global.TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    if (this._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                    }
                    else if (this._UITypeTermine == eUITypeTermine.Übergabe)
                    {
                    }
                    else if (this._UITypeTermine == eUITypeTermine.Dekurs)
                    {
                    }
                    else
                    {
                        throw new Exception("ucSiteMapTermine: UITypeTermine'" + this._UITypeTermine.ToString() + "' for TerminlisteAnsichtsmodi '" + this._ansichtmodi.ToString() + "' not allowed!");
                    }
                }

                TermineExTmp.imageList1.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Zurueck, 32, 32));
                TermineExTmp.imageList1.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Vorwaerts, 32, 32));
                TermineExTmp.imageList1.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32));
                TermineExTmp.imageList1.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Klientenakt.ico_Patient, 32, 32));
                TermineExTmp.btnBedarfsmedikation.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS_Intervention.ico_Einzelverordnung, 32, 32);

                QS2.Desktop.ControlManagment.BaseGrid gridBase = (QS2.Desktop.ControlManagment.BaseGrid)TermineExTmp.dgTermine;
                gridBase.AutoWork = false;

                TermineExTmp.initControl();

                TermineExTmp.ucTerminFilterPicker1.panelAktualisieren.Visible = true;
                TermineExTmp.ucTerminFilterPicker1.panelClose.Visible = false;

                TermineExTmp.ucTerminTimePicker1.panelAktualisieren.Visible = true;
                TermineExTmp.ucTerminTimePicker1.panelClose.Visible = false;

                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnSchnellrückmeldung, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnUngeplMaßnahmenRückemelden, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnFreierBericht, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnFreierBericht2, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnBedarfsmedikation, false);

                //this.setStyleButton(this._termine.uButtonAlleAuswählen);

                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnAlleAuswählen, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnOpenBefundIntervention, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnPDxRückmelden, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnLesenInterventionen, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnOpenBefundÜbergabe, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnGegenzeichnen, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnLesenÜbergabeDekurs, false);
                
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnSonderterminBearbeiten, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnSonderterminBeenden, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnSonderterminErstellen, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnSonderterminLöschen, false);

                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.uDropDownSondertermine, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.uDropDownDekursEntwürfe, false);
                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.uDropDownDrucken, false);

                PMDS.Global.UIGlobal.setUIButton(TermineExTmp.btnEndTask1, false);


                TermineExTmp.TerminSelected += new EventHandler(_termine_TerminSelected);
                TermineExTmp.TerminDoubleClick += new EventHandler(_termine_TerminDoubleClick);

                ENV.ENVPatientIDChanged             += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                this._TermineEx.ucTerminTimePicker1.mainWindowxy = this._TermineEx;
                this._TermineEx.ucTerminFilterPicker1.mainWindowxy = this._TermineEx;

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.initControl: " + ex.ToString());
            }
		}
        public ucTermineEx getTermineEx()
        {
            return this._TermineEx;
        }

        private void SetUIxy()
        {
            try
            {
                ucTermineEx TermineExTmp = this.getTermineEx();

                bool HasRightRueckmelden = false;
                if (ENV.HasRight(UserRights.Rueckmelden))
                {
                    HasRightRueckmelden = true;
                }
                else
                {
                    HasRightRueckmelden = false;
                }

                //TermineExTmp.btnSchnellrückmeldung.Visible = HasRightRueckmelden && !PMDS.Global.historie.HistorieOn;
                TermineExTmp.btnUngeplMaßnahmenRückemelden.Visible = HasRightRueckmelden && !PMDS.Global.historie.HistorieOn;
                TermineExTmp.btnBedarfsmedikation.Visible = HasRightRueckmelden && !PMDS.Global.historie.HistorieOn;
                TermineExTmp.btnFreierBericht.Visible = HasRightRueckmelden;
                bool HasRightTermineVerwalten = ENV.HasRight(UserRights.TermineVerwalten);
                TermineExTmp.uDropDownSondertermine.Visible = ((HasRightTermineVerwalten && !PMDS.Global.historie.HistorieOn) ? true : false);

                if (PMDS.Global.historie.HistorieOn)
                {
                    //TermineExTmp.panelButtonsÜbergabe.Visible = true;
                    //TermineExTmp.panelButtonsIntervention.Visible = false;
                    TermineExTmp.uDropDownDrucken.Visible = false;
                }
                else
                {
                    if (this._UITypeTermine == eUITypeTermine.Interventionen)
                    {
                        TermineExTmp.uDropDownDrucken.Visible = true;
                        TermineExTmp.panelStuhlbuttonsFläche.Visible = !PMDS.Global.historie.HistorieOn;
                        if (!PMDS.Global.historie.HistorieOn && this._ansichtmodi != TerminlisteAnsichtsmodi.Bereichsansicht)
                        {
                            this.Quickmeldungen();
                        }
                    }
                    else if (this._UITypeTermine == eUITypeTermine.Übergabe || this._UITypeTermine == eUITypeTermine.Dekurs)
                    {
                        TermineExTmp.uDropDownDrucken.Visible = false;
                        TermineExTmp.panelStuhlbuttonsFläche.Visible = false;
                    }
                }

                bool HasRightschnellrückmeldungIntervention = ENV.HasRight(UserRights.schnellrückmeldungIntervention);
                TermineExTmp.btnSchnellrückmeldung.Visible = HasRightschnellrückmeldungIntervention && !PMDS.Global.historie.HistorieOn;
                //this._framework.setHistorieUI(PMDS.Global.historie.HistorieOn, _currentMode);
                
                TermineExTmp.panelButtonsAlleKeine.Visible = true;

                TermineExTmp.btnFreierBericht2.Visible = true;
                TermineExTmp.ultraDropDownButtonTermine.Visible = ((HasRightTermineVerwalten && !PMDS.Global.historie.HistorieOn) ? true : false);
                TermineExTmp.btnGegenzeichnen .Visible = !PMDS.Global.historie.HistorieOn;

                //if (ENV.AnsichtsModus == TerminlisteAnsichtsmodi.Bereichsansicht && this._UITypeTermine == eUITypeTermine.Dekurs)
                //{
                //}
                //else
                //{
                //}

                if (this._UITypeTermine != eUITypeTermine.Interventionen)
                {
                    this._TermineEx.btnSonderterminLöschen.Visible = false;
                    this._TermineEx.btnSonderterminBeenden.Visible = false;
                    this._TermineEx.btnSonderterminBearbeiten.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.SetUI: " + ex.ToString());
            }
        }

        public void SetUIForTerminIsSelected(bool refreshStuhlButtons)
        {
            try
            {
                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {

                }
                else if (this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht && this._UITypeTermine != eUITypeTermine.Dekurs)
                {
                    if (IDPatient == Guid.Empty)
                    {
                        FRAMEWORK.HEADER.RIGHTINFO = "";
                        //this._termine.clearQuickhButtons ();
                    }
                    else
                    {
                        Patient pat = new Patient(IDPatient);
                        string format = ENV.String("PATIENT.INFO2");
                        FRAMEWORK.HEADER.RIGHTINFO = pat.FullInfoWithFormat(format);
                    }

                    // Patientenänderung signalisieren
                    if (IDPatient != this.LastSelectedPatient || IDPatient == Guid.Empty)
                    {
                        if (this._UITypeTermine == eUITypeTermine.Interventionen)
                        {
                            if (IDPatient == Guid.Empty)
                            {
                                this._TermineEx.ClearMedizinischeButtons();
                            }
                            else
                            {
                                if (refreshStuhlButtons)
                                {
                                    this.Quickmeldungen();
                                }
                            }
                        }
                        else if (this._UITypeTermine == eUITypeTermine.Dekurs || this._UITypeTermine == eUITypeTermine.Übergabe)
                        {
                            this._TermineEx.ClearMedizinischeButtons();
                        }

                        SignalPatientSelectionChanged();
                        this.LastSelectedPatient = IDPatient;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.SetUIForTerminIsSelected: " + ex.ToString());
            }
        }


        public void initTermin(ref PMDS.Global.eUITypeTermine UITypeTermine, TerminlisteAnsichtsmodi ansichtmodi)
        {
            try
            {
                this._UITypeTermine = UITypeTermine;
                this._ansichtmodi = ansichtmodi;
                this._TermineEx = new ucTermineEx();

                this.initControl();
                ucTermineEx TermineExTmp = this.getTermineEx();
                TermineExTmp.ucSiteMapTermine1 = this;
                TermineExTmp.UITypeTermine = UITypeTermine;

                TermineExTmp.SetControlNameGrid(ref UITypeTermine);

                this._TermineEx.ucTerminTimePicker1.initControl();
                this._TermineEx.ucTerminFilterPicker1.initControl(false, UITypeTermine, true);

                //if (PMDS.Global.historie.HistorieOn)
                //{
                //     //this._TermineEx.actualSettings = TermineExTmp.loadZeitfiltersHistorieNachEntlassung(this._TermineEx.actualSettings, false);
                //}
                //else
                //{
                //    if (UITypeTermine == eUITypeTermine.Interventionen)
                //    {
                //    }
                //    else if (UITypeTermine == eUITypeTermine.Übergabe)
                //    {
                //        //int UWeekEnd = (int)ENV.ConfigFile.GetDoubleValue("UEBERGABE_WEEKEND");
                //        //int UNormal = (int)ENV.ConfigFile.GetDoubleValue("UEBERGABE_NORMAL");
                //        //if (UWeekEnd == 0) UWeekEnd = 72;
                //        //if (UNormal == 0) UNormal = 24;

                //        //s.Mode = EFilter.INTERVALL;
                //        //s.To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                //        //DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                //        //if (s.To.DayOfWeek == DayOfWeek.Monday || s.To.DayOfWeek == DayOfWeek.Tuesday)  //<20120417>
                //        //    s.From = from.AddHours(-UWeekEnd);
                //        //else
                //        //    s.From = from.AddHours(-UNormal);
                //        //s.Done = true;
                //    }
                //    else if (UITypeTermine == eUITypeTermine.Dekurs)
                //    {
                //    }
                //}

                this.initTermine2(ref UITypeTermine, ref TermineExTmp);
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.initTermin: " + ex.ToString());
            }
        }

        private void initTermine2(ref PMDS.Global.eUITypeTermine UITypeTermine, ref ucTermineEx TermineExTmp)
        {
            try
            {
                if (UITypeTermine == eUITypeTermine.Interventionen)
                {
                    TermineExTmp.panelButtonsÜbergabe.Visible = false;
                    TermineExTmp.panelButtonsIntervention.Visible = true;
                    TermineExTmp.panelStuhlbuttonsFläche.Visible = true;
                    TermineExTmp.btnAlleAuswählen.Visible = true;

                    TermineExTmp.pButtonsAll.Height = 55;
                    TermineExTmp.pButtonsAllDyn.Height = 23;
                    this._TermineEx.btnOpenBefundIntervention.Visible = false;
                }
                else if (UITypeTermine == eUITypeTermine.Übergabe ||
                         UITypeTermine == eUITypeTermine.Dekurs)
                {
                    TermineExTmp.panelButtonsÜbergabe.Visible = true;
                    TermineExTmp.panelButtonsIntervention.Visible = false;
                    TermineExTmp.panelStuhlbuttonsFläche.Visible = false;
                    TermineExTmp.btnAlleAuswählen.Visible = true;
                    TermineExTmp.pButtonsAll.Height = 33;
                    TermineExTmp.pButtonsAllDyn.Height = 23;
                    this._TermineEx.btnOpenBefundÜbergabe.Visible = false;
                }

                TermineExTmp.ClearMedizinischeButtons();
                if (UITypeTermine == eUITypeTermine.Interventionen)
                {
                    this.Quickmeldungen();
                }
                //else if (UITypeTermine == eUITypeTermine.Übergabe ||
                //         UITypeTermine == eUITypeTermine.Dekurs)
                //{

                //}

                //if (UITypeTermine == eUITypeTermine.Dekurs)
                //{
                //    if (this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                //    {
                //    }
                //    else
                //    {
                //    }
                //}
                //else
                //{
                //}

                TermineExTmp.btnAlleAuswählen.Tag = "0";
                TermineExTmp.btnAlleAuswählen.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");

                this.SetUIxy();
                this.RefreshButtons();

                TermineExTmp.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                //TermineExTmp.EnableBezugspflegePersonFilter(this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht);

                TermineExTmp._idPatient = System.Guid.Empty;
                TermineExTmp._idAbteilungxy = System.Guid.Empty;
                TermineExTmp._idBereich = System.Guid.Empty;

                this.LastSelectedPatient = Guid.NewGuid();

                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    
                }
                else
                {
                }
                //_framework.setHistorieUI(PMDS.Global.historie.HistorieOn, _currentMode);
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.initTermine2: " + ex.ToString());
            }
        }
        
        public void RefreshTermin(bool LoadDataFromDB)
        {
            try
            {
                this.clearGrid();

                ucTermineEx TermineExTmp = this.getTermineEx();

                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    if (this.IDPatient == this.LastSelectedPatient && !this.FirstCallRefresh)
                    {
                        //return;
                    }

                    this._TermineEx._idBereich = Guid.Empty;
                    this._TermineEx._idAbteilungxy = Guid.Empty;
                    this._TermineEx._idPatient = ENV.CurrentIDPatient;
                }
                else
                {
                    this._TermineEx._idBereich = ENV.CurrentAnsichtinfo.IDBereich;              //ENV.CurrentIDBereich;
                    this._TermineEx._idAbteilungxy = ENV.CurrentAnsichtinfo.IDAbteilung;        //ENV.CurrentIDAbteilung;
                    this._TermineEx._idPatient = Guid.Empty;

                    if (this._UITypeTermine == eUITypeTermine.Interventionen ||
                        this._UITypeTermine == eUITypeTermine.Übergabe)
                    {
                        ENV.doPatientFromTermineBereich = true;
                    }
                }

                this.SetUIxy();
                TermineExTmp.SetSourceToGrid();

                if (this._UITypeTermine == eUITypeTermine.Interventionen ||
                    this._UITypeTermine == eUITypeTermine.Übergabe)
                {
                    GuiWorkflow._guiworkflow._framework.HEADER.action(false);
                    GuiWorkflow._guiworkflow._framework.HEADER.ShowOnlyHeader(true);
                    FRAMEWORK.BringOnTop(this);
                    GuiWorkflow._guiworkflow._framework.HEADER.action(true);
                    //Application.DoEvents();
                }

                if (this._TermineEx.IDKlinikLast != null && this._TermineEx.IDKlinikLast != ENV.IDKlinik)
                {
                    this.RefreshButtons();
                }
                if (this._TermineEx.IDAbteilungLast != null && this._TermineEx.IDAbteilungLast != ENV.CurrentIDAbteilung)
                {
                    this.RefreshButtons();
                }

                //if (LoadDataFromDB || !this.FirstCallRefresh)
                //{
                bool LayoutFound = false;
                    PMDS.Global.db.ERSystem.dsTermine ds = new Global.db.ERSystem.dsTermine();
                    this._TermineEx.getTermine(this._UITypeTermine, ref LayoutFound, false);
                //}
                    if (ucSiteMapTermine.FirstCallDoRefreshKlienten && this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                    {
                        this._TermineEx._idPatient = Guid.Empty;
                        if (this._UITypeTermine == eUITypeTermine.Interventionen)
                        {
                            this.SetUIForTerminIsSelected(true);
                        }
                        else if (this._UITypeTermine == eUITypeTermine.Dekurs || this._UITypeTermine == eUITypeTermine.Übergabe)
                        {
                            this.SetUIForTerminIsSelected(false);
                        }
                        ucSiteMapTermine.FirstCallDoRefreshKlienten = false;
                    }

                if (this._UITypeTermine == eUITypeTermine.Interventionen ||
                    this._UITypeTermine == eUITypeTermine.Übergabe)
                {
                    if (this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                        GuiWorkflow.mainWindow.ucHeader1.setUIHeaderTextBreichsansicht(true, TermineExTmp._idAbteilungxy, TermineExTmp._idBereich);
                    else
                        GuiWorkflow.mainWindow.ucHeader1.setUIHeaderTextBreichsansicht(false, TermineExTmp._idAbteilungxy, TermineExTmp._idBereich);
                }

                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    this.LastSelectedPatient = this.IDPatient;
                }
                else
                {
                    this.LastSelectedPatient = this.IDPatient;
                }
                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Bereichsansicht)
                {
                    TermineExTmp._idPatient = System.Guid.Empty;
                    this.LastSelectedPatient = Guid.NewGuid();
                    this.SetUIForTerminIsSelected(true);
                }

                this._TermineEx.panelTop.ContextMenuStrip = this._TermineEx.contextMenuStripSys;
                this.FirstCallRefresh = false;

            }
            catch (Exception ex)
            {
                GuiWorkflow._guiworkflow._framework.HEADER.ShowControlAndHeader(true);
                throw new Exception("ucSiteMapTermine.RefreshTermin: " + ex.ToString());
            }
            finally
            {
                //GuiWorkflow._guiworkflow._framework.HEADER.action(true);
            }
        }

        public void clearGrid()
        {
            try
            {
                if (this._TermineEx.UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (this._TermineEx._ds != null)
                    {
                        this._TermineEx._ds.vInterventionen.Clear();
                        this._TermineEx.dgTermine.Refresh();
                    }
                }
                else if (this._TermineEx.UITypeTermine == eUITypeTermine.Übergabe || this._TermineEx.UITypeTermine == eUITypeTermine.Dekurs)
                {
                    if (this._TermineEx._ds != null)
                    {
                        this._TermineEx._ds.vÜbergabe.Clear();
                        this._TermineEx.dgTermine.Refresh();
                    }
                }
                else
                {
                    throw new Exception("ucTermine.clearGrid: UITypeTermine '" + this._TermineEx.UITypeTermine.ToString() + "' not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.clearGrid: " + ex.ToString());
            }
        }

        public QS2.Desktop.ControlManagment.doBaseElements.cInfoControl.retGetQuickfilter getLastClickedQuickfilter()
        {
            try
            {
                QS2.Desktop.ControlManagment.doBaseElements.cInfoControl.retGetQuickfilter ret = new QS2.Desktop.ControlManagment.doBaseElements.cInfoControl.retGetQuickfilter();

                ucTermineEx TermineExTmp = this.getTermineEx();
                if (TermineExTmp.quickFilterButtons1.QButtonClicked != null)
                {
                    PMDS.GUI.BaseControls.QuickFilterButtonArgs args = (PMDS.GUI.BaseControls.QuickFilterButtonArgs)TermineExTmp.quickFilterButtons1.QButtonClicked.Tag;
                    if (args.rQuickFilter.KeyLayout.Trim() != "")
                    {
                        ret.LastClickedQuickfilter = args.rQuickFilter.KeyLayout;
                    }
                    else
                    {
                        ret.LastClickedQuickfilter = args.rQuickFilter.KeyQuickFilter;
                    }
                    ret.NameDefaultQuickfilter = QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickfilter ") + args.rQuickFilter.Bezeichnung.Trim();
                    ret.IDQuickFilterToSave = args.rQuickFilter.ID;
                    
                    return ret;
                }
                else
                {
                    return ret;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.getLastClickedQuickfilter: " + ex.ToString());
            }
        }
     
        public void RefreshButtons()
        {
            try
            {
                this._TermineEx.quickFilterButtons1._UITypeTermine = this._UITypeTermine;
                this._TermineEx.quickFilterButtons1.drawButtons(this._TermineEx.dgTermine, this._TermineEx, ref  this._UITypeTermine);
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.RefreshButtons: " + ex.ToString());
            }
        }

        public void Quickmeldungen()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = DB.PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstIDQuickButtonsAdded = new System.Collections.Generic.List<Guid>();
                    ucTermineEx TermineExTmp = this.getTermineEx();
                    TermineExTmp.ClearMedizinischeButtons();

                    int anz = 0;
                    QuickMeldungManager m = new QuickMeldungManager();
                    foreach (dsQuickMeldung.QuickMeldungRow r in m.ReadAll(ENV.ABTEILUNG))
                    {
                        this.addQuickmeldungen(ref anz, r.IDEintrag, TermineExTmp, r.Bezeichnung.Trim(), r.ID, ref lstIDQuickButtonsAdded);
                    }

                    PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                    System.Collections.Generic.List<PMDS.db.Entities.QuickMeldung> lstQuickmeldungenBasisAbteilung = b.getQuickbuttonsBasisabteilung(ENV.IDKlinik, db);
                    foreach (PMDS.db.Entities.QuickMeldung rBasisAbt in lstQuickmeldungenBasisAbteilung)
                    {
                        bool bExists = false;
                        foreach (Guid IDGuidQuickButton in lstIDQuickButtonsAdded)
                        {
                            if (rBasisAbt.ID == IDGuidQuickButton)
                            {
                                bExists = true;
                            }
                        }

                        if (!bExists)
                        {
                            this.addQuickmeldungen(ref anz, rBasisAbt.IDEintrag.Value, TermineExTmp, rBasisAbt.Bezeichnung.Trim(), rBasisAbt.ID, ref lstIDQuickButtonsAdded);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.Quickmeldungen: " + ex.ToString());
            }
        }

        public void addQuickmeldungen(ref int anz, Guid IDEintrag, ucTermineEx TermineExTmp, string Bezeichnung, Guid IDQuickMeldung,
                                        ref System.Collections.Generic.List<Guid> lstIDQuickbuttonsAdded)
        {
            try
            {
                PMDSMenuEntry menu = new PMDSMenuEntry(SiteGroups.Termine, SiteEvents.QuickMeldungEvent, Bezeichnung, null, "PMDS.Global.Resources.Quickbutton.ico");
                menu.Tag = IDEintrag;

                Infragistics.Win.Misc.UltraButton b;
                Panel pnl;
                if (anz < TermineExTmp.panelStuhlbuttons.Controls.Count)
                {
                    b = (Infragistics.Win.Misc.UltraButton)TermineExTmp.panelStuhlbuttons.Controls[anz];
                    pnl = (System.Windows.Forms.Panel)TermineExTmp.panelStuhlbuttons.Controls[anz + 1];
                }
                else
                {
                    b = new QS2.Desktop.ControlManagment.BaseButton();
                    b.Appearance.ImageHAlign = Infragistics.Win.HAlign.Right;
                    b.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                    b.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                    b.Dock = System.Windows.Forms.DockStyle.Left;
                    b.Location = new System.Drawing.Point(180, 0);
                    b.Appearance.Image = menu.bmp;
                    b.AutoSize = true;

                    PMDS.Global.UIGlobal.setUIButton(b, false);
                    b.Click += new System.EventHandler(this.stuhlbuttons_click);
                    TermineExTmp.panelStuhlbuttons.Controls.Add(b);

                    pnl = new QS2.Desktop.ControlManagment.BasePanel
                    {
                        Name = "pnl_" + anz.ToString(),
                        Size = new System.Drawing.Size(2, 23),
                        Dock = System.Windows.Forms.DockStyle.Left
                    };
                    TermineExTmp.panelStuhlbuttons.Controls.Add(pnl);
                }

                PMDS.Global.UIGlobal.setUIButton(b, false);

                b.Tag = menu;
                b.Name = "stuhlButt_" + anz.ToString();
                b.TabIndex = anz;
                b.Text = Bezeichnung;
                b.Visible = true;
                Infragistics.Win.UltraWinToolTip.UltraToolTipInfo tipp = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo();
                tipp.ToolTipTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickmaßnahme ") + Bezeichnung;
                tipp.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickmaßnahme '") + Bezeichnung + QS2.Desktop.ControlManagment.ControlManagment.getRes("' abzeichnen!");
                TermineExTmp.ultraToolTipManager1.SetUltraToolTip(b, tipp);

                pnl.Visible = true;
                anz += 2;

                lstIDQuickbuttonsAdded.Add(IDQuickMeldung);
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine.addQuickmeldungen: " + ex.ToString());
            }
        }

        private Guid IDPatient
        {
            get
            {
                ucTermineEx TermineExTmp = this.getTermineEx();
                return TermineExTmp.IDPatient;
            }
        }

        private Guid IDAufenthalt
        {
            get
            {
                ucTermineEx TermineExTmp = this.getTermineEx();
                return TermineExTmp.IDAufenthalt;
            }
        }

     
        private void SignalPatientSelectionChanged()
        {
            if (PatientSelectionChanged != null)
                PatientSelectionChanged(IDPatient, IDAufenthalt);
        }
        private void _termine_TerminSelected(object sender, EventArgs e)
        {
            ucTermineEx TermineExTmp = this.getTermineEx();
            if (TermineExTmp.UITypeTermine == PMDS.Global.eUITypeTermine.Interventionen)
            {
                this.SetUIForTerminIsSelected(true);
            }
            else
            {
                this.SetUIForTerminIsSelected(false);
            }
        }

        private void _termine_TerminDoubleClick(object sender, EventArgs e)
        {
            try
            {
                ucTermineEx TermineExTmp = this.getTermineEx();
                if (this._UITypeTermine == eUITypeTermine.Interventionen)
                {
                    if (this._TermineEx.CurTerminRowIntervention != null)
                    {
                        if (GuiAction.PatientRueckmeldung(this._TermineEx.CurTerminRowIntervention,  null,
                                                            TermineExTmp.UITypeTermine, TermineExTmp.dgTermine, TermineExTmp.imageList1.Images[2],
                                                            this, false))
                        {
                            this.RefreshTermin(true);
                        }
                    }
                }
                else
                {
                    if (this._TermineEx.CurTerminRowÜbergabe != null)
                    {
                        if (new List<PflegeEintragTyp>(){ PMDS.Global.PflegeEintragTyp.EVALUIERUNG,
                                                          PMDS.Global.PflegeEintragTyp.PLANUNG,
                                                          PMDS.Global.PflegeEintragTyp.MEDIKAMENT,
                                                          PMDS.Global.PflegeEintragTyp.NONE,
                                                          PMDS.Global.PflegeEintragTyp.NOTFALL,
                                                          PMDS.Global.PflegeEintragTyp.WUNDEN,
                                                          PMDS.Global.PflegeEintragTyp.Klient
                                                        }.Any(p => (int)p == this._TermineEx.CurTerminRowÜbergabe.Eintragstyp))
                        {
                            return;
                        }

                        if (new List<PflegeEintragTyp>() { PMDS.Global.PflegeEintragTyp.DEKURS,
                                                           PMDS.Global.PflegeEintragTyp.MASSNAHME,
                                                           PMDS.Global.PflegeEintragTyp.TERMIN
                                                         }.Any(p => (int)p == this._TermineEx.CurTerminRowÜbergabe.Eintragstyp) || 
                            this._TermineEx.CurTerminRowÜbergabe.IsIDPflegeplanNull())
                        {
                            using (frmPflegeEintragSmall frm = new frmPflegeEintragSmall())
                            {
                                frm.InitControl();
                                frm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                                frm._rvÜbergabe = this._TermineEx.CurTerminRowÜbergabe;

                                frm.IsDekurs = this._TermineEx.CurTerminRowÜbergabe.Eintragstyp == 0;
                                frm.ShowDialog();
                                if (!frm.abort)
                                {
                                    this.RefreshTermin(true);
                                }
                            }
                        }
                        else
                        {
                            if (GuiAction.PatientRueckmeldung(null, this._TermineEx.CurTerminRowÜbergabe,  TermineExTmp.UITypeTermine,
                                                                TermineExTmp.dgTermine, TermineExTmp.imageList1.Images[2], this, false))
                            {
                                this.RefreshTermin(false); 
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("ucSiteMapTermine._termine_TerminDoubleClick: " + ex.ToString());
            }
        }

        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            if (typ == eCurrentPatientChange.PickerLinksOben)
            {
                if (this._ansichtmodi == TerminlisteAnsichtsmodi.Klientanansicht)
                {
                    ucTermineEx TermineExTmp = this.getTermineEx();
                    if (!TermineExTmp.Visible)
                    {
                        return;
                    }

                    this._TermineEx._idPatient = IDPatient;
                    this.RefreshTermin(true);
                }
            }
        }

        private void stuhlbuttons_click(object sender, EventArgs e)
        {
            try
            {
                ucTermineEx TermineExTmp = this.getTermineEx();
                PMDSMenuEntry m = (PMDSMenuEntry)((Infragistics.Win.Misc.UltraButton)sender).Tag;
                if (!TermineExTmp.IsPatientSelected(true)) return;
                GuiAction.PatientRueckmeldung(IDPatient, (Guid)m.Tag, IDAufenthalt, true, false, TermineExTmp.UITypeTermine, null, 
                                            TermineExTmp.imageList1.Images[2], this, false);

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

        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            this.RefreshTermin(true);
        }
               

		#region IPMDSGUIObject Members

		public Control CONTROL	 
		{	
			get
            {
                return this.getTermineEx();;
            }	
		}
		public void Undo() 
		{
		}			
		public bool Save() 
		{
			return true;
		}
		public string AREA		
		{	
			get	{	return _AREA;	}
		}
		private IPMDSMenuFramework	_framework;
		public IPMDSMenuFramework FRAMEWORK
		{
			get	{	return _framework;	}
			set	{	_framework = value;	}
		}
		public void AttachFramework()
		{
            try
            {

            }
            catch (Exception ex)
            {
                _framework.HEADER.action(true );
                ENV.HandleException(ex);
            }
            finally
            {
            }
		}
		public void DetachFramework()
		{
		}
		public void ProcessKeyEvent(KeyEventArgs e)
		{
		}

		#endregion


	}

}
