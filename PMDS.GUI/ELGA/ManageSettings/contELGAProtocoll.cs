using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PMDS.DB;
using Infragistics.Win.UltraWinGrid;
using PMDS.Global;

namespace PMDS.GUI.ELGA
{


    public partial class contELGAProtocoll : UserControl
    {

        public ucBenutzerEdit mainWindow = null;
        public bool IsInitialized = false;

        public PMDS.db.Entities.ERModellPMDSEntities _db = null;
        public PMDSBusiness b = new PMDSBusiness();

        public Nullable<Guid> _IDUser = System.Guid.Empty;
        public bool _IsNew = false;
        public bool _Editable = false;

        public string colSelect = "Select";

        public UIGlobal UIGlobal1 = new UIGlobal();






        public contELGAProtocoll()
        {
            InitializeComponent();
        }

        private void contELGAProtocoll_Load(object sender, EventArgs e)
        {

        }


        public void initControl()
        {
            try
            {
                if (!this.IsInitialized)
                {
                    this.btnSearch.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);

                    this.sqlManange1.initControl();
                    this._db = PMDSBusiness.getDBContext();
                    this.clearUI();

                    this.udteFrom.DateTime = DateTime.Now.AddMonths(-6);
                    this.udteTo.DateTime = DateTime.Now;

                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAProtocoll.initControl: " + ex.ToString());
            }
        }
        public void clearUI()
        {
            try
            {
                this._IDUser = null;
                this._IsNew = false;

                this.dsKlientenliste1.Clear();
                this.gridRights.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAProtocoll.clearUI: " + ex.ToString());
            }
        }

        public void loadData(Nullable<Guid> IDUser, bool isNew, bool editable)
        {
            try
            {
                this._IDUser = IDUser;
                this._IsNew = isNew;
                this._Editable = editable;

                Nullable<DateTime> dFrom = null;
                if (this.udteFrom.Value != null)
                {
                    dFrom = this.udteFrom.DateTime.Date;
                }
                Nullable<DateTime> dTo = null;
                if (this.udteTo.Value != null)
                {
                    dTo = this.udteTo.DateTime.Date;
                }

                this.dsKlientenliste1.Clear();
                this.sqlManange1.getELGAProtocoll(this.dsKlientenliste1, this._IDUser.Value, dFrom, dTo, Global.db.ERSystem.sqlManange.eTypeELGAProtocoll.AllForUser);
                this.gridRights.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("contELGAProtocoll.loadData: " + ex.ToString());
            }
        }



        private void GridRights_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.IsFilterRowCell || e.Cell.Row.IsGroupByRow)
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    if (e.Cell.Column.ToString().Trim().ToLower().Equals((this.colSelect.Trim()).Trim().ToLower()))
                    {
                        e.Cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        e.Cell.Activation = Activation.NoEdit;
                        e.Cell.Row.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            try
            {
                e.DisplayPromptMsg = false;
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRights))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void GridRights_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridRights))
                {
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void MarkierteZelleKopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gridRights.ActiveCell != null)
                {
                    if (this.gridRights.ActiveCell.Value != null)
                    {
                        Clipboard.SetDataObject(this.gridRights.ActiveCell.Value.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.loadData(this._IDUser, this._IsNew, this._Editable);

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
