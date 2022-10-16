using System;
using System.Windows.Forms;

namespace qs2.sitemap
{
    public partial class comboApplication : UserControl
    {
        private qs2.core.license.doLicense doLicense1 = new qs2.core.license.doLicense();
        private bool _ownLabelVisible = true;
        private bool isLoaded;

        public event onChange evOnChange;
        public delegate void onChange(string selectedApplication);

        public comboApplication()
        {
            InitializeComponent();
        }


        public void initControlxy(bool showAlways)
        {
            try
            {
                if (!this.isLoaded)
                {
                    this.sqlAdmin1.initControl();
                    this.loadRes();
                    this.loadApplications(true);

                    if (!showAlways)
                    {
                        this.showUI(qs2.core.ENV.ApplicationSelection != 0);
                        this.extendedViewToolStripMenuItem.Checked = qs2.core.ENV.ApplicationSelection != 0;
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
                this.cboApplications.Refresh();
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
