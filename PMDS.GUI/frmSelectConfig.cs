using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PMDS.GUI
{

    public partial class frmSelectConfig : Form
    {
        public Global.db.ERSystem.PMDSBusinessUI.cItmTg cItmTg_SelectedConfig = null;
        //public cItmTg cItmTg_SelectedDatabase = null;

        public bool abort = true;
        public string _ConfigPath = "";
        public string _ConfigFileDefault = "";
        public bool _runWithDefaultConfigFile = false;
        public string lastSelectedFile = "";
        public PMDS.Global.db.ERSystem.PMDSBusinessUI bUI = new PMDS.Global.db.ERSystem.PMDSBusinessUI();

        public frmSelectConfig()
        {
            InitializeComponent();
        }

        private void frmSelectConfig_Load(object sender, EventArgs e)
        {

        }


        public void initControl(string ConfigPath, string ConfigFileDefault, bool HideButtonOK)
        {
            try
            {
                this._ConfigPath = ConfigPath;
                this._ConfigFileDefault = ConfigFileDefault;

                this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, QS2.Resources.getRes.ePicTyp.ico);
                this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);

                if (HideButtonOK)
                {
                    this.btnOK.Visible = false;
                }

                this.AcceptButton = this.btnOK;
                this.CancelButton = this.btnAbort;

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.initControl: " + ex.ToString());
            }
        }


        public void loadData(bool FirstLoad)
        {
            try
            {
                this.txtConfigPath.Text = this._ConfigPath;
                this.searchDirForConfigs(FirstLoad);

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.loadData: " + ex.ToString());
            }
        }

        public void searchDirForConfigs(bool FirstLoad)
        {
            try
            {
                this.cItmTg_SelectedConfig = null;
                //this.cItmTg_SelectedDatabase = null;

                this.cboConfigFiles.Items.Clear();
                this.txtConfigFile.Text = "";

                Infragistics.Win.ValueListItem itmSel = null;
                int iCounter = 0;
                bool runWithDefaultConfigFile = false;
                int iCounterConfigsFound = 0;
                this.bUI.searchConfigDirForConfigs(FirstLoad, this._ConfigPath, this.cboConfigFiles, this._ConfigFileDefault, ref runWithDefaultConfigFile, ref this.lastSelectedFile, ref iCounterConfigsFound, ref itmSel);
                //if (runWithDefaultConfigFile)
                //{
                //    this.abort = true;
                //    this.Close();
                //}

                if (itmSel != null)
                {
                    this.cboConfigFiles.SelectedItem = itmSel;
                    Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTg = (Global.db.ERSystem.PMDSBusinessUI.cItmTg)this.cboConfigFiles.SelectedItem.Tag;
                    this.searchDatabasesInConfig(ItmTg);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.searchDirForConfigs_rek:" + ex.ToString());
            }
        }
        public void searchDatabasesInConfig(Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgConfig)
        {
            try
            {
                this.txtConfigFile.Text = File.ReadAllText(ItmTgConfig.fileNameFull);
                this.lastSelectedFile = ItmTgConfig.fileNameOnly.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.searchDatabasesInConfig:" + ex.ToString());
            }
        }


        public bool checkSelectedData()
        {
            try
            {
                if (this.cboConfigFiles.SelectedItem == null)
                {
                    System.Windows.Forms.MessageBox.Show("Config.-File: selection required!", "PMDS", MessageBoxButtons.OK);
                    this.cboConfigFiles.Focus();
                    return false;
                }
                this.cItmTg_SelectedConfig = (Global.db.ERSystem.PMDSBusinessUI.cItmTg)this.cboConfigFiles.SelectedItem.Tag;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.checkSelectedData: " + ex.ToString());
            }
        }

        public void openConfigInEditor(Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgSel)
        {
            try
            {
                Process.Start(@ItmTgSel.fileNameFull.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.openConfigInEditor: " + ex.ToString());
            }
        }
        public void openQS2ConfigInEditor()
        {
            try
            {
                string qs2Config = System.IO.Path.Combine(_ConfigPath, "qs2.config");
                if (System.IO.File.Exists(@qs2Config.Trim()))
                {
                    Process.Start(qs2Config);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("QS2-Config.-File not exists in Path '" + this._ConfigPath + "'!", "PMDS", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.openQS2ConfigInEditor: " + ex.ToString());
            }
        }

        public void saveFile(Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgSel)
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("frmSelectConfig.saveFile: " + ex.ToString());
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.checkSelectedData())
                {
                    this.abort = false;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.abort = true;
                this.Close();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void cboConfigFiles_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (cboConfigFiles.Focused)
                {
                    if (this.cboConfigFiles.SelectedItem != null)
                    {
                        Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTg = (Global.db.ERSystem.PMDSBusinessUI.cItmTg)this.cboConfigFiles.SelectedItem.Tag;
                        this.searchDatabasesInConfig(ItmTg);
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lblOpenConfig_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboConfigFiles.SelectedItem != null)
                {
                    Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgSel = (Global.db.ERSystem.PMDSBusinessUI.cItmTg)this.cboConfigFiles.SelectedItem.Tag;
                    this.openConfigInEditor(ItmTgSel);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No config.-File: selected!", "PMDS", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData(false);

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void frmSelectConfig_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    this.loadData(true);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboConfigFiles.SelectedItem != null)
                {
                    Global.db.ERSystem.PMDSBusinessUI.cItmTg ItmTgSel = (Global.db.ERSystem.PMDSBusinessUI.cItmTg)this.cboConfigFiles.SelectedItem.Tag;
                    this.saveFile(ItmTgSel);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No config.-File: selected!", "PMDS", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void lblOpenQS2Config_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.openQS2ConfigInEditor();

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

    }

}
