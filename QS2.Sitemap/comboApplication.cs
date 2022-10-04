using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;





namespace qs2.sitemap
{



    public partial class comboApplication : UserControl
    {

        public string defaultApplication = core.license.doLicense.eApp.ALL.ToString();
        //public string defaultParticipant = "";
        public qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();

        public event onChange evOnChange;
        public delegate void onChange(string selectedApplication);

        public bool _ownLabelVisible = true;
        public bool isLoaded = false;

        public bool IsMainApplicationComboBox = false;
        public bool _OnlyLicensedProducts = false;
        public bool _ShowAll  = false;
        public businessFramework b = new businessFramework();


        




        public comboApplication()
        {
            InitializeComponent();
        }


        public void initControlxy(bool showAlways, bool OnlyLicensedProducts, bool ShowAll)
        {
            try
            {
                if (!this.isLoaded)
                {
                    this.sqlAdmin1.initControl();
                    this.loadRes();
                    this._OnlyLicensedProducts = OnlyLicensedProducts;
                    this._ShowAll = ShowAll;

                    this.loadApplications(true);

                    if (!showAlways)
                    {
                        if (qs2.core.ENV.ApplicationSelection == 0)
                        {
                            this.showUI(false);
                            this.extendedViewToolStripMenuItem.Checked = false;
                        }
                        else
                        {
                            this.showUI(true);
                            this.extendedViewToolStripMenuItem.Checked = true;
                        }
                    }
                    else
                    {
                        this.showUI(true);
                        this.extendedViewToolStripMenuItem.Checked = true;
                    }

                    this.isLoaded = true;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadRes()
        {
            try
            {
                this.lblApplication.Text = qs2.core.language.sqlLanguage.getRes("Application");
                this.extendedViewToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ExtendedViewApplicationSelection");
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void setUI()
        {
            try
            {
                if (this._ownLabelVisible)
                {
                    this.lblApplication.Visible = true;
                    this.cboApplications.Dock = DockStyle.Right;
                    this.cboApplications.Width = this.Width - this.lblApplication.Width - 10;

                }
                else
                {
                    this.lblApplication.Visible = false;
                    this.cboApplications.Dock = DockStyle.Fill;
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }
        public void loadApplications(bool setDefault)
        {
            try
            {
                this.dsLicense1.Applications.Clear();
                this.doLicense1.FillTableApplications(this.dsLicense1);

                bool ApplicationOK = true;
                if (qs2.core.license.doLicense.rApplication != null)
                {
                    if (qs2.core.license.doLicense.rApplication.IDApplication.Trim().Equals(qs2.core.license.doLicense.eApp.PMDS.ToString().Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        ApplicationOK = false;
                    }
                }

                if (ApplicationOK)
                {
                    if (!qs2.core.ENV.VSDesignerMode)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = qs2.core.db.ERSystem.businessFramework.getDBContext())
                        {
                            IQueryable<PMDS.db.Entities.tblObjectApplications> tObjectApplications = this.b.getProductsForUser(actUsr.rUsr.IDGuid, db);
                            if (!qs2.core.ENV.developModus && tObjectApplications.Count() > 0)
                            {
                                System.Collections.Generic.List<qs2.core.license.dsLicense.ApplicationsRow> lstAppLicensed = new List<core.license.dsLicense.ApplicationsRow>();
                                foreach (qs2.core.license.dsLicense.ApplicationsRow rAppLic in this.dsLicense1.Applications)
                                {
                                    bool bAppExists = false;
                                    foreach (PMDS.db.Entities.tblObjectApplications rApp in tObjectApplications)
                                    {
                                        if (rApp.IDApplication.Trim().ToLower().Equals(rAppLic.Name.ToLower()))
                                        {
                                            bAppExists = true;
                                        }
                                    }
                                    if (!bAppExists)
                                    {
                                        lstAppLicensed.Add(rAppLic);
                                    }
                                }

                                foreach (qs2.core.license.dsLicense.ApplicationsRow rAppLic in lstAppLicensed)
                                {
                                    if (this._ShowAll)
                                    {
                                        if (!rAppLic.ID.Trim().ToLower().Equals(("ALL").Trim().ToLower()))
                                        {
                                            rAppLic.Delete();
                                        }
                                    }
                                    else
                                    {
                                        rAppLic.Delete();
                                    }
                                }
                                this.dsLicense1.AcceptChanges();
                            }
                        }


                    }
                    this.cboApplications.Refresh();

                    //if (setDefault)
                    //    this.cboApplications.Value = this.defaultApplication.ToString();
                }
                else
                {
                    this.cboApplications.Refresh();
                }

            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        public core.license.doLicense.eApp getSelectedApplication()
        {
            try
            {
                core.license.doLicense.eApp enumAppFound = core.license.doLicense.eApp.ALL;
                if (this.cboApplications.Value != null)
                {
                    enumAppFound = qs2.core.generic.searchEnumApplication((String)this.cboApplications.Value);
                }

                return enumAppFound;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
                return core.license.doLicense.eApp.ALL;
            }
        }

        public void showUI(bool bOn)
        {
            this.lblApplication.Visible = bOn;
            this.cboApplications.Visible = bOn;
            if (!this.OwnLabelVisible && bOn)
            {
                this.lblApplication.Visible = false; 
            }
        }

        private void cboApplications_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.cboApplications.Focused)
                {
                    if (this.IsMainApplicationComboBox)
                    {
                        qs2.core.ENV.IDApplicationActiveFromUser = this.getSelectedApplication().ToString();
                        //qs2.core.license.doLicense.GetLicense() 

                    }
                    if (this.evOnChange != null)
                    {
                        this.evOnChange.Invoke(this.getSelectedApplication().ToString());
                    } 
                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void comboApplication_Load(object sender, EventArgs e)
        {

        }
        public bool OwnLabelVisible
        {
            get
            {
                return this._ownLabelVisible;
            }
            set
            {
                this._ownLabelVisible = value;
                this.setUI();
            }
        }
        public void setApplication(string Application)
        {
            try
            {
                this.cboApplications.Value = Application;
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void extendedViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.showUI(this.extendedViewToolStripMenuItem.Checked);
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void cboApplications_KeyDown(object sender, KeyEventArgs e)
        {

        }

    }
}
