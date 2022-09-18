using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QS2.Resources;



namespace qs2.ui
{


    public partial class contMainTop : UserControl
    {
        
        public contMain mainWindow = null;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();




        public contMainTop()
        {
            InitializeComponent();
        }

        private void contMainTop_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                this.btnSearch.Text = qs2.core.language.sqlLanguage.getRes("Patients");
                this.btnQueries.Text = qs2.core.language.sqlLanguage.getRes("Queries");
                this.btnReports.Text = qs2.core.language.sqlLanguage.getRes("Reports");
                this.btnDocuments.Text = qs2.core.language.sqlLanguage.getRes("Documents");

                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnSearch, qs2.core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnQueries, qs2.core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnReports, qs2.core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnDocuments, qs2.core.ui.eButtonType.Main);

                this.ColorSchemas1.setAppearanceUserControl(this, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeUserControl.MainTop, false);

                //this.ColorSchemas1.setAppearanceButton(this.btnSearch, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeButton.MainTop, false);
                //this.ColorSchemas1.setAppearanceButton(this.btnQueries, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeButton.MainTop, false);
                //this.ColorSchemas1.setAppearanceButton(this.btnReports, design.auto.workflowAssist.autoForm.ColorSchemas.eTypeButton.MainTop, false);

            }
            catch (Exception ex)
            {
                throw new Exception("initControl: " + ex.ToString());
            }
        }

        private void contMainTop_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {

                }
            }
            catch (Exception ex)
            {
                qs2.core.generic.getExep(ex.ToString(), ex.Message);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnDocuments, core.ui.eButtonType.Main);
                this.mainWindow.doControl(core.ENV.eTypApp.contSearch, "", "", "");
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
        private void btnQueries_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnDocuments, core.ui.eButtonType.Main);
                this.mainWindow.doControl(core.ENV.eTypApp.contQuerysRun, "", "", "");
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
        private void btnReports_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnDocuments, core.ui.eButtonType.Main);
                this.mainWindow.doControl(core.ENV.eTypApp.contReportsRun, "", "", "");
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

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnSearch, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnQueries, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonInaktiv(this.btnReports, core.ui.eButtonType.Main);
                qs2.design.auto.workflowAssist.autoForm.ColorSchemas.setButtonAktiv(this.btnDocuments, core.ui.eButtonType.Main);
                this.mainWindow.doControl(core.ENV.eTypApp.contDocumentsRun, "", "", "");
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
    }
}
