using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Global;
using PMDS.BusinessLogic;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinExplorerBar;



namespace PMDS.GUI
{
    public partial class ucSiteMapPflegePlan2 : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {
        private bool _ContentChanged;
        private bool _ZusateintragChanged;
        private bool _ForceRefresh;

        public ucSiteMapPflegePlan2()
        {
            InitializeComponent();
            //ucPflegePlan21.ShowErledigteAtStartup = false;
            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);

            ENV.ZusatzeintragChanged += new ZusatzeintragChangedDelegate(ENV_ZusatzeintragChanged);
        }

        void ENV_ZusatzeintragChanged(bool changed)
        {
            if (!Visible) return;
            _ZusateintragChanged = changed;
            if (changed)
            {
               this.ucPflegeplan21.btnSavexyxyxy.Enabled = false;
               this.ucPflegeplan21.btnRefresh.Enabled = false;
            }
            else
            {
                this.ucPflegeplan21.btnSavexyxyxy.Enabled = _ContentChanged && ENV.HasRight(UserRights.PflegePlanungAendern);
                this.ucPflegeplan21.btnRefresh.Enabled = _ContentChanged;
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Modus für Wunddoku setzen
        /// </summary>
        //----------------------------------------------------------------------------
        public PflegePlanModus PFLEGEPLANMODUS
        {
            get { return ucPflegeplan21.PFLEGEPLANMODUS;}
            set { ucPflegeplan21.PFLEGEPLANMODUS = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Die ID des Patienten wurde von außen geändert ==> aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            AskforSave();
            if (this.Visible && ENV.CurrentAnsichtinfo.Ansichtsmodus == TerminlisteAnsichtsmodi.Klientanansicht)
            {
                _ForceRefresh = true;
                ucSiteMapPflegePlan2_VisibleChanged(this, EventArgs.Empty);
            }
        }




        //----------------------------------------------------------------------------
        /// <summary>
        /// Genereller Handler
        /// </summary>
        //----------------------------------------------------------------------------
        private void commonHandler(PMDSMenuEntry sender)
        {

        }
        #region IPMDSGUIObject Members


        //----------------------------------------------------------------------------
        /// <summary>
        /// Aufruf von außen verarbeiten
        /// </summary>
        //----------------------------------------------------------------------------
        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {
            // Do Nothing
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// CONTROL
        /// </summary>
        //----------------------------------------------------------------------------
        public Control CONTROL
        {
            get { return this; }
        }

        public void Undo()
        {
            ucPflegeplan21.Undo();
            this.ucPflegeplan21.btnSavexyxyxy.Enabled = false;
            this.ucPflegeplan21.btnRefresh.Enabled = false;
            _ContentChanged = false;
        }

        public bool Save()
        {
            return true;		// Do Nothing
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// AREA
        /// </summary>
        //----------------------------------------------------------------------------
        public string AREA
        {
            get { return ENV.String("GUI_AREA_SITEMAP_START"); }
        }

        private IPMDSMenuFramework _framework;

        //----------------------------------------------------------------------------
        /// <summary>
        /// FRAMEWORK
        /// </summary>
        //----------------------------------------------------------------------------
        public IPMDSMenuFramework FRAMEWORK
        {
            get { return _framework; }
            set { _framework = value; }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// in Framework einhängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void AttachFramework()
        {
            try
            {
                _framework.HEADER.action(false);
                _framework.HEADER.ShowOnlyHeader(true);
                ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                UpdateActions();
            }
            catch (Exception ex)
            {
                _framework.HEADER.ShowControlAndHeader(true);
                ENV.HandleException(ex);
            }
            finally
            {
                _framework.HEADER.action(true);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// aus Framework aushängen
        /// </summary>
        //----------------------------------------------------------------------------
        public void DetachFramework()
        {
            AskforSave();

            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);
        }




        /// <summary>
        /// Abfrage zum speichern bei Klientenwechsel über Patientpicker oder wechsel durch Headerbuttonklick
        /// </summary>
        private void AskforSave()
        {
            if (_ContentChanged)
            {
                if (PMDS.Global.historie.HistorieOn || !ENV.HasRight(UserRights.PflegePlanungAendern))
                {
                    Undo();
                    return;
                }
                else
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                                ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                                MessageBoxButtons.YesNo,
                                                                                                MessageBoxIcon.Question, true);      

                    if (res == DialogResult.Yes)
                    {
                        ProcessSave();
                        return;
                    }
                    if (res == DialogResult.No)
                    {
                        Undo();
                        return;
                    }
                }
            }
        }




        //----------------------------------------------------------------------------
        /// <summary>
        /// Keyboard Verarbeitung
        /// </summary>
        //----------------------------------------------------------------------------
        public void ProcessKeyEvent(KeyEventArgs e)
        {
            //			switch(e.KeyCode) 
            //			{
            //				case Keys.L:								
            //					HandleLabelEvent(SiteEvents.Terminliste);
            //					e.Handled = true;
            //					break;
            //			}
        }

        #endregion

        //----------------------------------------------------------------------------
        /// <summary>
        /// Aktionen aktualisieren weil sich ein Benutzer neu angemeldet hat
        /// </summary>
        //----------------------------------------------------------------------------
        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            UpdateActions();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// erlaubte Aktionen ein/ausblenden
        /// </summary>
        //----------------------------------------------------------------------------
        private void UpdateActions()
        {
            pnlNoRights.Visible = !ENV.HasRight(UserRights.PflegePlanungAnzeigen);
            pnlNoRights.Dock = DockStyle.Fill;
            ucPflegeplan21.Visible = ENV.HasRight(UserRights.PflegePlanungAnzeigen);
            ucPflegeplan21.ProcessRights();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegeplan aktualisieren bei Änderung
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshPflegePlan(bool bForce)
        {
            if (ENV.CurrentIDPatient == Guid.Empty)
                return;
            Patient pat = new Patient(ENV.CurrentIDPatient);
            Guid IDAufenthalt = pat.Aufenthalt.ID;

            //os: Refresh nur, wenn sich der Aufenthalt geändert hat oder bei Refresh-Button
            if (bForce || ucPflegeplan21.IDAUFENTHALT == null || ucPflegeplan21.IDAUFENTHALT != IDAufenthalt)
            {
                EnvPflegePlan.CurrentKlientenAbteilung = pat.Aufenthalt.Verlauf.IDAbteilung_Nach;
                ucPflegeplan21.IDAUFENTHALT = IDAufenthalt;
            }

            //TO DO:
            //if (Settings.IDPFLEGEPLAN != Guid.Empty)
            //    ucPflegeplan21.MarkAllPDxForIDPflegePlan(Settings.IDPFLEGEPLAN);
        }

        private void ProcessSave()
        {
            if (!ucPflegeplan21.Save()) return;
            this.ucPflegeplan21.btnSavexyxyxy.Enabled = false;
            this.ucPflegeplan21.btnRefresh.Enabled = false;
            _ContentChanged = false;
            ENV.SignalPflegePlanChanged(ucPflegeplan21.IDAUFENTHALT);
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            ProcessSave();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Undo();
        }

        public void planungÄndern(string typ)
        {
            if (typ == "Save")
            {
                this.ProcessSave();
            }
            else if (typ == "Refresh")
            {
                this.Undo();
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Wird aufgerufen wenn im Control was verändert wurde
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPflegeplan21_ValueChanged(object sender, EventArgs e)
        {
            _ContentChanged = true;

            if (_ZusateintragChanged) return;

            this.ucPflegeplan21.btnSavexyxyxy.Enabled = ENV.HasRight(UserRights.PflegePlanungAendern);
            this.ucPflegeplan21.btnRefresh.Enabled =  true;
        }

        private void ucSiteMapPflegePlan2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                RefreshPflegePlan(_ForceRefresh);
                _ForceRefresh = false;
            }
        }

        private void ucPflegeplan21_planungÄndern(string typ)
        {
            this.planungÄndern(typ);
        }

        private void ucPflegeplan21_Load(object sender, EventArgs e)
        {

        }
    }
}
