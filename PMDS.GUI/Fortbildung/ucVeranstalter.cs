using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PMDS.Global;
using PMDS.Global.db.Global;
using PMDS.db.Entities;
using PMDS.DB;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinListView;




namespace PMDS.GUI.Fortbildung
{


    public partial class ucVeranstalter : UserControl
    {
        public eTypeFortbildungenUI _TypeFortbildungenUI;

        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public bool Isinitialized = false;

        public ucVerwaltungFortbildungen mainWindow = null;
       







        public ucVeranstalter()
        {
            InitializeComponent();
        }

        private void ucVeranstalter_Load(object sender, EventArgs e)
        {

        }

        public void initControl()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this._TypeFortbildungenUI = eTypeFortbildungenUI.Veranstalter;
                    this.loadComboVeranstalter();
                    this.loadUsers();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.initControl: " + ex.ToString());
            }
        }

        public void loadUsers()
        {
            try
            {
                this.cboUsers.Items.Clear();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll = new System.Collections.Generic.List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db, ref lstBenutzerAll);
                    foreach (PMDS.db.Entities.Benutzer rBenutzer in tBenutzer)
                    {
                        Infragistics.Win.ValueListItem itm = this.cboUsers.Items.Add(rBenutzer.ID, rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "");
                        itm.Appearance.FontData.SizeInPoints = 10;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.loadUsers: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.cboVeranstalter.Items.Clear();
                this.cboVeranstalter.Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.clearUI: " + ex.ToString());
            }
        }
        public void loadComboVeranstalter()
        {
            try
            {
                this.mainWindow.ucFortbildungenList1.clearUI();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungDetails1.clearUI();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerList1.clearUI();
                this.mainWindow.ucFortbildungenMain1.ucFortbildungBenutzerDetails1.clearUI2();

                this.mainWindow.ucFortbildungenList1.Visible = false;
                this.mainWindow.ucFortbildungenMain1.Visible = false;
                this.cboVeranstalter.UseAppStyling = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.cboVeranstalter.Items.Clear();
                    System.Linq.IQueryable <tblVeranstalter> tVeranstalter = this.b.loadAllVeranstalter(db);
                    foreach (tblVeranstalter rVeranstalter in tVeranstalter)
                    {
                        Infragistics.Win.ValueListItem itm = this.cboVeranstalter.Items.Add(rVeranstalter.ID, rVeranstalter.Bezeichnung.Trim());
                        itm.Appearance.FontData.SizeInPoints = 11;
                    }                  
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.loadComboVeranstalter: " + ex.ToString());
            }
        }
        public void selectVeranstalterInCbo(Guid IDVeranstalter)
        {
            try
            {
                foreach (Infragistics.Win.ValueListItem itm in this.cboVeranstalter.Items)
                {
                    if (IDVeranstalter.Equals(itm.DataValue))
                    {
                        this.cboVeranstalter.SelectedItem = itm;
                        this.mainWindow.ucFortbildungenList1.Visible = true;
                        this.mainWindow.ucFortbildungenList1.loadData(IDVeranstalter, null , this._TypeFortbildungenUI, null);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.selectVeranstalterInCbo: " + ex.ToString());
            }
        }
        public void setUI(int Modus)
        {
            try
            {
                if (Modus == 1)
                {
                    this.lblBenutzer.Visible = false;
                    this.cboUsers.Visible = false;
                    this.panelVeranstalter.Visible = true;
                    this._TypeFortbildungenUI = eTypeFortbildungenUI.Veranstalter;
                    this.loadComboVeranstalter();
                    this.mainWindow.ucFortbildungenList1.btnAdd.Visible = true;
                    this.mainWindow.ucFortbildungenList1.clearUI();
                }
                else if (Modus == 0)
                {
                    this.lblBenutzer.Visible = false;
                    this.cboUsers.Visible = false;
                    this.panelVeranstalter.Visible = false;
                    this._TypeFortbildungenUI = eTypeFortbildungenUI.AlleFortbildungenxy;
                    this.mainWindow.ucFortbildungenList1.btnAdd.Visible = false;
                    this.clearUI();
                    this.mainWindow.ucFortbildungenList1.Visible = true;
                    this.mainWindow.ucFortbildungenList1.loadData(null, null, eTypeFortbildungenUI.AlleFortbildungenxy, null);
                }
                else if (Modus == 2)
                {
                    this.lblBenutzer.Visible = true;
                    this.cboUsers.Visible = true;
                    this.panelVeranstalter.Visible = false;
                    this._TypeFortbildungenUI = eTypeFortbildungenUI.Benutzer;
                    this.mainWindow.ucFortbildungenList1.btnAdd.Visible = false;
                    this.clearUI();
                    this.mainWindow.ucFortbildungenList1.Visible = true;
                    this.mainWindow.ucFortbildungenList1.loadData(null, this.getSelectedUser() , eTypeFortbildungenUI.Benutzer, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.setUI: " + ex.ToString());
            }
        }
        public void edit(bool IsNew, Nullable<Guid> IDVeranstalter)
        {
            try
            {
                frmVeranstalterDetail frm = new frmVeranstalterDetail();
                frm.initControl();
                frm.loadData(IDVeranstalter, IsNew);
                frm.ShowDialog(this);
                if (!frm.abort)
                {
                    this.loadComboVeranstalter();
                    this.selectVeranstalterInCbo(frm.rVeranstalter.ID);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.edit: " + ex.ToString());
            }
        }
        public Nullable<Guid> getSelectedUser()
        {
            try
            {
                if (this.cboUsers.Value == null)
                {
                    return null;
                }
                else
                {
                    return (Guid)this.cboUsers.Value;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.getSelectedUser: " + ex.ToString());
            }
        }
        public bool delete(Guid IDVeranstalter)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Veranstalter wirklich löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<tblVeranstalter> tVeranstalter = db.tblVeranstalter.Where(p => p.ID == IDVeranstalter);
                        tblVeranstalter rVeranstalter = tVeranstalter.First();
                        db.tblVeranstalter.Remove(rVeranstalter);
                        db.SaveChanges();
                        this.loadComboVeranstalter();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.delete: " + ex.ToString());
            }
        }

        public Nullable<Guid> getSelectedVeranstalter(bool withMsgBox)
        {
            try
            {
                if (this.cboVeranstalter.Value != null)
                {
                    Guid IDVeranstalterSel = (Guid)this.cboVeranstalter.Value;
                    return IDVeranstalterSel;
                }
                else
                {
                    if (withMsgBox)
                    {
                        QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Veranstalter ausgewählt!");
                    }
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("ucVeranstalter.getSelectedVeranstalter: " + ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.edit(true, null);
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDVeranstalter = this.getSelectedVeranstalter(true);
                if (IDVeranstalter != null)
                {
                    this.edit(false, IDVeranstalter);
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDVeranstalter = this.getSelectedVeranstalter(true);
                if (IDVeranstalter != null)
                {
                    this.delete((Guid)IDVeranstalter);
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

        private void optErfolg_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.optErfolg.Focused)
                {
                    this.setUI((int)this.optErfolg.Value);
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

        private void cboVeranstalter_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboVeranstalter.Focused)
                {
                    //this.setUI(1);
                    this.mainWindow.ucFortbildungenList1.Visible = true;
                    this.mainWindow.ucFortbildungenList1.loadData((Guid)cboVeranstalter.Value, this.getSelectedUser(), eTypeFortbildungenUI.Veranstalter, null);
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

        private void cboUsers_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.cboUsers.Focused)
                {
                    if (this.cboUsers.Value != null && this.cboUsers.Value.GetType().Equals(typeof(Guid)))
                    {
                        Nullable<Guid> IDUserSelected = this.getSelectedUser();
                        this.mainWindow.ucFortbildungenList1.loadData(null, IDUserSelected, eTypeFortbildungenUI.Benutzer, null);
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
    }
}
