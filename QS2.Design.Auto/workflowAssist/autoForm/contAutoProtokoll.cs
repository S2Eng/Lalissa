using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using qs2.core.vb;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;




namespace qs2.sitemap.workflowAssist.form
{
    public partial class contAutoProtokoll : UserControl
    {
        public bool isLoaded = false;
        public qs2.core.vb.sqlAdmin sqlAdminWork = new sqlAdmin();
        public core.vb.dsAdmin dsAdminFunctions = new dsAdmin();

        public contAutoProtokoll()
        {
            InitializeComponent();
        }

        private void contAutoProtokoll_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (this.isLoaded) return;

                this.loadRes();
                this.sqlAdminWork.initControl();

                this.isLoaded = true;
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
                this.gridProtocoll.DisplayLayout.Bands[0].Columns[this.dsAdminFields.protokoll.TextSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Chapter");
                this.gridProtocoll.DisplayLayout.Bands[0].Columns[this.dsAdminFields.protokoll.TextControlColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Field");
                this.gridProtocoll.DisplayLayout.Bands[0].Columns[this.dsAdminFields.protokoll.TextMessageColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Message");
               
                this.gridProtocoll.DisplayLayout.GroupByBox.Prompt = qs2.core.language.sqlLanguage.getRes("DragAColumneTo") + " ...";

                this.gridProtocoll.DisplayLayout.Bands[0].Columns[this.dsAdminFields.protokoll.supressColumn.ColumnName].Hidden = true;
            }
            catch (Exception ex)
            {
                throw new Exception("contAutoProtokoll.loadRes: " + ex.ToString());
            }
        }
        public void addRow(string TextSub, string TextControl, string TextMessage, qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI, Enum pic,
                            bool sys, bool admin, bool MessageFromFunction, bool supressFldShort)
        {
            try
            {
                qs2.core.vb.dsAdmin.protokollRow rNewProt = null;
                if (sys)
                {
                    rNewProt = this.sqlAdminWork.getNewRowProtocol(this.dsAdminSys.protokoll);
                }
                else if (MessageFromFunction)
                {
                    rNewProt = this.sqlAdminWork.getNewRowProtocol(this.dsAdminFunctions.protokoll);
                }
                else
                {
                    rNewProt = this.sqlAdminWork.getNewRowProtocol(this.dsAdminFields.protokoll);
                }

                rNewProt.ID = System.Guid.NewGuid();
                rNewProt.TextSub = TextSub;
                if (supressFldShort)
                {
                    rNewProt.TextControl = "";
                }
                else
                {
                    rNewProt.TextControl = TextControl;
                }
                rNewProt.TextMessage = TextMessage;
                rNewProt.admin = admin;
                rNewProt.supress = supressFldShort;

                if (rAutoUI == null)
                {
                    rNewProt.SetrowAutoUINull(); 
                }
                else
                {
                    rNewProt.rowAutoUI = rAutoUI; 
                }
                rNewProt.sys = sys;

                if (!sys && !MessageFromFunction)
                {
                    UltraGridRow rowGrid = this.gridProtocoll.Rows.GetRowWithListIndex(this.dsAdminFields.protokoll.Rows.IndexOf(rNewProt));
                    rowGrid.RowSelectorAppearance.Image = QS2.Resources.getRes.getImage(pic, 32, 32);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw new Exception("contAutoProtokoll.addRow: " + ex.ToString());
            }
        }

        public void refreshProtokoll()
        {
            try
            {
                this.copyMessagesTableToGridDS(this.dsAdminSys, QS2.Resources.getRes.ePicture.ico_sys);
                this.copyMessagesTableToGridDS(this.dsAdminFunctions, QS2.Resources.getRes.ePicture.ico_Queries);
                
                this.gridProtocoll.Refresh();
                this.gridProtocoll.Text = qs2.core.language.sqlLanguage.getRes("PleaseProveMessages") + "! (" + this.dsAdminFields.protokoll.Rows.Count.ToString() + ")";

            }
            catch (Exception ex)
            {
                throw new Exception("contAutoProtokoll.refreshProtokoll: " + ex.ToString());
            }
        }

        public bool protocollExists()
        {
            if (this.dsAdminFields.protokoll.Rows.Count > 0 || this.dsAdminFunctions.protokoll.Rows.Count > 0 || this.dsAdminSys.protokoll.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void copyMessagesTableToGridDS(dsAdmin dsToCopy, QS2.Resources.getRes.ePicture ico)
        {
            try
            {
                foreach (dsAdmin.protokollRow rProtSys in dsToCopy.protokoll)
                {
                    dsAdmin.protokollRow rNewProt = this.sqlAdminWork.getNewRowProtocol(this.dsAdminFields.protokoll);
                    rNewProt.ItemArray = rProtSys.ItemArray;
                    rNewProt.ID = System.Guid.NewGuid();

                    UltraGridRow rowGrid = this.gridProtocoll.Rows.GetRowWithListIndex(this.dsAdminFields.protokoll.Rows.IndexOf(rNewProt));
                    rowGrid.RowSelectorAppearance.Image = QS2.Resources.getRes.getImage(ico, 32, 32);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("contAutoProtokoll.copyMessagesTableToGridDS: " + ex.ToString());
            }
        }
        public void ClearAll()
        {
            try
            {
                this.copyMessagesTableToGridDS(this.dsAdminSys, QS2.Resources.getRes.ePicture.ico_sys);
                this.copyMessagesTableToGridDS(this.dsAdminFunctions, QS2.Resources.getRes.ePicture.ico_Queries);

                System.Collections.ArrayList lstToDelete = new System.Collections.ArrayList();
                dsAdmin.protokollRow[] arrAutUINotAdmin = (dsAdmin.protokollRow[])this.dsAdminFields.protokoll.Select(this.dsAdminFields.protokoll.adminColumn.ColumnName + "=0", "");
                foreach (dsAdmin.protokollRow rAutoUI in arrAutUINotAdmin)
                {
                    lstToDelete.Add(rAutoUI);
                }
                foreach (dsAdmin.protokollRow rAutoUI in lstToDelete)
                {
                    rAutoUI.Delete();
                }
                //this.dsAdminFields.protokoll.Clear();
                //this.dsAdminFields.protokoll.Clear();
                this.gridProtocoll.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("contAutoProtokoll.ClearAll: " + ex.ToString());
            }
        }

        private void ultraGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.gridProtocoll.ActiveRow != null)
                {
                    if (!this.gridProtocoll.ActiveRow.IsGroupByRow && !this.gridProtocoll.ActiveRow.IsFilterRow)
                    {
                        DataRowView v = (DataRowView)this.gridProtocoll.ActiveRow.ListObject;
                        dsAdmin.protokollRow rProt = (dsAdmin.protokollRow)v.Row;

                        if (!rProt.IsrowAutoUINull())
                        {
                            string protocollForAdmin = "";
                            bool ProtocolWindow = false;
                            System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                            qs2.design.auto.ownMCRelationship.eTypAssignments TypAssignmentToCheck = design.auto.ownMCRelationship.eTypAssignments.none;

                            qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI = (qs2.core.vb.dsAdmin.dbAutoUIRow)rProt.rowAutoUI;
                            qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)rAutoUI.control;

                            qs2.core.generic.infoControl calculatedFormat1 = new qs2.core.generic.infoControl();
                            ownMultiControl1.doActionControl(design.auto.multiControl.ownMultiControl.eTypActionControl.showError, ref calculatedFormat1, false);
                            ownMultiControl1.doActionControl(design.auto.multiControl.ownMultiControl.eTypActionControl.setEditableAndFocus, ref calculatedFormat1, false);

                            if (protocollForAdmin.Trim() != "")
                            {
                                qs2.design.auto.multiControl.ownMCInfo.openProtocoll(ref protocollForAdmin);
                            }
                        }
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
    }
}
