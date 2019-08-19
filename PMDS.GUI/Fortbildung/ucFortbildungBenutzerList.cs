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


    public partial class ucFortbildungBenutzerList : UserControl
    {

        public Nullable<Guid> _IDFortbildung;
        public Nullable<Guid> _IDBenutzer;
        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public bool Isinitialized = false;

        public ucFortbildungenMain mainWindow = null;

        public eTypeFortbildungenUI _TypeFortbildungenUI;









        public ucFortbildungBenutzerList()
        {
            InitializeComponent();
        }

        private void ucFortbildungBenutzerList_Load(object sender, EventArgs e)
        {

        }

        public void initControl2()
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Minus, 32, 32);

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.initControl: " + ex.ToString());
            }
        }
        public void clearUI()
        {
            try
            {
                this.lvBenutzer.Items.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.clearUI: " + ex.ToString());
            }
        }
        public void loadUsers(Nullable<Guid> IDFortbildung, eTypeFortbildungenUI TypeFortbildungenUI, Nullable<Guid> IDBenutzer)
        {
            try
            {
                this._IDFortbildung = IDFortbildung;
                this._IDBenutzer = IDBenutzer;
                this._TypeFortbildungenUI = TypeFortbildungenUI;

                this.mainWindow.ucFortbildungBenutzerDetails1.clearUI2();
                this.mainWindow.ucFortbildungBenutzerDetails1.Visible = false;
       
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstUsersInList = new List<Guid>();
                    this.lvBenutzer.Items.Clear();
                    System.Linq.IQueryable<tblFortbildungBenutzer> tFortbildungBenutzer = this.b.loadFortbildungBenutzer(IDFortbildung, db);
                    foreach (tblFortbildungBenutzer rFortbildungBenutzer in tFortbildungBenutzer)
                    {
                        //bool bUserExists = false;
                        //foreach (Guid IDUserExistsInList in lstUsersInList)
                        //{
                        //    if (IDUserExistsInList.Equals(rFortbildungBenutzer.IDBenutzer))
                        //    {
                        //        bUserExists = true;
                        //    }
                        //}
                        //if (!bUserExists)
                        //{
                        System.Linq.IQueryable<Benutzer> tBenutzer = db.Benutzer.Where(p => p.ID == rFortbildungBenutzer.IDBenutzer);
                        if (this._IDBenutzer == null || (this._IDBenutzer != null && this._IDBenutzer.Equals(rFortbildungBenutzer.IDBenutzer)))
                        {
                            Benutzer rBenutzer = tBenutzer.First();
                            //}                            Benutzer rBenutzer = tBenutzer.First();
                            string sAnmeldedatum = "";
                            if (rFortbildungBenutzer.Anmeldedatum != null)
                            {
                                sAnmeldedatum = ", " + rFortbildungBenutzer.Anmeldedatum.Value.ToString("dd.MM.yyyy") + "";
                            }
                            UltraListViewItem listItem = new UltraListViewItem(rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + sAnmeldedatum, null, null);
                            listItem.Key = rFortbildungBenutzer.ID.ToString();
                            listItem.Tag = rFortbildungBenutzer.ID;
                            listItem.CheckState = CheckState.Unchecked;
                            this.lvBenutzer.Items.Add(listItem);
                            lstUsersInList.Add(rBenutzer.ID);
                        }


                    }

                    this.lvBenutzer.Refresh();

                    this.lvBenutzer.SelectedItems.Clear();
                    this.lvBenutzer.ActiveItem = null;

                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.loadUsers: " + ex.ToString());
            }
        }
        public void selectItem(Guid IDFortbildungBenutzerSelect)
        {
            try
            {
                foreach (UltraListViewItem itm in this.lvBenutzer.Items)
                {
                    if (itm.Tag.Equals(IDFortbildungBenutzerSelect))
                    {
                        this.lvBenutzer.ActiveItem = itm;
                        this.loadForttbildungBenutzer(IDFortbildungBenutzerSelect, null, false);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.selectItem: " + ex.ToString());
            }
        }
        public Nullable<Guid> getSelectedItem(bool WithMsgBox)
        {
            try
            {
                if (this.lvBenutzer.ActiveItem != null)
                {
                    Guid IDFortbildungBenutzer = new Guid(this.lvBenutzer.ActiveItem.Tag.ToString().Trim());
                    return IDFortbildungBenutzer;
                }
                else
                {
                    if (WithMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Benutzer ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.getSelectedItem: " + ex.ToString());
            }
        }
        public void loadForttbildungBenutzer(Nullable<Guid> IDFortbildungBenutzer, Nullable<Guid> IDSelUser, bool IsNew)
        {
            try
            {
                if (IDFortbildungBenutzer != null)
                {
                    Guid IDBenutzer;
                    Guid IDFortbildung;
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        IQueryable<PMDS.db.Entities.tblFortbildungBenutzer> tFortbildungBenutzer = db.tblFortbildungBenutzer.Where(b => b.ID == IDFortbildungBenutzer);
                        tblFortbildungBenutzer rFortbildungBenutzer = tFortbildungBenutzer.First();
                        IDBenutzer = rFortbildungBenutzer.IDBenutzer;
                        IDFortbildung = rFortbildungBenutzer.IDFortbildung;
                    }
                    this.mainWindow.ucFortbildungBenutzerDetails1.Visible = true;
                    this.mainWindow.ucFortbildungBenutzerDetails1.loadData(IDFortbildungBenutzer, IDFortbildung, IDBenutzer, IsNew, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI,
                                                                            this.mainWindow.mainWindow.ucFortbildungenList1.IsReadOnly());
                }
                else
                {
                    this.mainWindow.ucFortbildungBenutzerDetails1.Visible = true;
                    this.mainWindow.ucFortbildungBenutzerDetails1.loadData(null, (Guid)this._IDFortbildung, (Guid)IDSelUser, IsNew, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI,
                                                                            this.mainWindow.mainWindow.ucFortbildungenList1.IsReadOnly());
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.loadForttbildungBenutzer: " + ex.ToString());
            }
        }

        private void lvBenutzer_Click(object sender, EventArgs e)
        {
            try
            {
                Nullable<Guid> IDFortbildungBenutzer = this.getSelectedItem(true);
                if (IDFortbildungBenutzer != null)
                {
                    this.loadForttbildungBenutzer(IDFortbildungBenutzer, null, false);
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }

        public void add()
        {
            try
            {
                DateTime dNow = DateTime.Now;

                frmSelectBenutzer3 frmSelectBenutzer31 = new frmSelectBenutzer3();
                frmSelectBenutzer31.initControl();
                frmSelectBenutzer31.ShowDialog(this);
                if (!frmSelectBenutzer31.abort)
                {
                    foreach (Guid IDUsrSelected in frmSelectBenutzer31.lstUsersSelected)
                    {
                        this.mainWindow.ucFortbildungBenutzerDetails1.Visible = true;
                        this.mainWindow.ucFortbildungBenutzerDetails1.loadData(null, (Guid)this._IDFortbildung, IDUsrSelected, true, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI,
                                                                                this.mainWindow.mainWindow.ucFortbildungenList1.IsReadOnly());

                        this.mainWindow.ucFortbildungBenutzerDetails1.uceAnmeldedatum.DateTime = dNow.Date;
                        this.mainWindow.ucFortbildungBenutzerDetails1.saveData();
                    }

                    this.loadUsers(this._IDFortbildung, this._TypeFortbildungenUI, null);
                }

                //frmSelectBenutzer frmSelectBenutzer1 = new frmSelectBenutzer();
                //frmSelectBenutzer1.initControl();
                //frmSelectBenutzer1.loadUsers();
                //frmSelectBenutzer1.ShowDialog(this);
                //if (!frmSelectBenutzer1.abort)
                //{
                //    this.loadForttbildungBenutzer(null, (Guid)frmSelectBenutzer1.IDSelUser, true);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.add: " + ex.ToString());
            }
        }
        public void delete(Guid IDFortbildungBenutzer)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Fortbildung für den Benutzer wirklich löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<tblFortbildungBenutzer> tFortbildungBenutzer = db.tblFortbildungBenutzer.Where(p => p.ID == IDFortbildungBenutzer);
                        tblFortbildungBenutzer rFortbildungBenutzer = tFortbildungBenutzer.First();
                        db.tblFortbildungBenutzer.Remove(rFortbildungBenutzer);
                        db.SaveChanges();

                        this.mainWindow.ucFortbildungBenutzerDetails1.clearUI2();
                        this.mainWindow.ucFortbildungBenutzerDetails1.Visible = false;
                        this.loadUsers(this._IDFortbildung, this.mainWindow.mainWindow.ucVeranstalter1._TypeFortbildungenUI, this._IDBenutzer);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucFortbildungBenutzerList.delete: " + ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.add();

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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Nullable<Guid> IDFortbildungBenutzer = this.getSelectedItem(true);
                if (IDFortbildungBenutzer != null)
                {
                    this.delete((Guid)IDFortbildungBenutzer);
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
