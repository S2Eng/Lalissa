using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;

using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.GUI.BaseControls;
using Infragistics.Win;
using System.IO;
using PMDS.Global.db.Global;





namespace PMDS.GUI
{

    public partial class ucDatenErhebungMain : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {

        public bool IsInit = false;








        public ucDatenErhebungMain()
        {
            InitializeComponent();
        }


        private void ucDatenErhebungMain_Load(object sender, EventArgs e)
        {
            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);

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

        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshTree, bool clickGridTermine)
        {
            try
            {
                this.initDynReports(ENV.ReportPathDatenerhebung);

            }
            catch (Exception ex)
            {
                throw new Exception("ENV_ENVPatientIDChanged: " + ex.ToString());
            }
        }

        public void initDynReports(string Path)
        {
            try
            {
                if (!this.IsInit)
                {
                    this.ucDynReports1.Init(Path);
                    this.IsInit = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("initDynReports: " + ex.ToString());
            }
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
            set
            {
                _framework = value;
                this.ucDatenErhebung1.FRAMEWORK = this.FRAMEWORK;
            }
        }
        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {

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
                if (ENV.CurrentIDPatient != null)
                {
                    _framework.HEADER.action(false);
                    _framework.HEADER.ShowOnlyHeader(true);
                    ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                    //if (ENV.CurrentIDPatient  != System.Guid.Empty && this.Visible && ENV.AnsichtsModus == TerminlisteAnsichtsmodi .Bereichsansicht ) 
                    //            this.loadMainSite();
                }

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


        public void loadMainSite()
        {
            try
            {

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
            //AskForSave();

            //ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);
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


    }
}
