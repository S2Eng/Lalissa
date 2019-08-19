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
    public partial class ucSiteMapEvaluierung1 : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {
        private bool _ContentChanged    = false;
        private Guid _CurrentIDPatient  = Guid.Empty;

        public ucSiteMapEvaluierung1()
        {
            InitializeComponent();
            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            ENV.PflegePlanChanged   += new PflegePlanChangedDelegate(ENV_PflegePlanChanged);
        }

        void ENV_PflegePlanChanged(Guid IDAufenthalt)
        {
            RefreshContent();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Die ID des Patienten wurde von außen geändert ==> aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            _CurrentIDPatient = IDPatient;
            if (this.Visible)
                RefreshContent();
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
            // Do Nothing
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
            if (_ContentChanged)
            {
                if (PMDS.Global.historie.HistorieOn)
                {
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
                        return;
                }

            }

            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);
            ENV.CurrentIDEvaluierung = Guid.Empty;
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
            pnlNoRights.Visible = !ENV.HasRight(UserRights.EvaluierungAnzeigen);
            pnlNoRights.Dock = DockStyle.Fill;
            this.ucZielEvaluierung1.gbEvaluierung.Visible = ENV.HasRight(UserRights.EvaluierungDurchfuehren);
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Pflegeplan aktualisieren bei Änderung
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshContent()
        {
            if (ENV.CurrentIDPatient == Guid.Empty)
            {
                ucZielEvaluierung1.RefreshContent(Guid.Empty);
                return;
            }
            Patient pat = new Patient(ENV.CurrentIDPatient);
            Guid IDAufenthalt = pat.Aufenthalt.ID;
            ucZielEvaluierung1.RefreshContent(IDAufenthalt);           
        }

        
        //----------------------------------------------------------------------------
        /// <summary>
        /// Änderungen festschreiben
        /// </summary>
        //----------------------------------------------------------------------------
        private void ProcessSave()
        {

           
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Sichtbarkeit ändert sich
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucSiteMapEvaluierung1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                RefreshContent();
        }

        private void ucZielEvaluierung1_Load(object sender, EventArgs e)
        {

        }

        

        
        
    }
}
