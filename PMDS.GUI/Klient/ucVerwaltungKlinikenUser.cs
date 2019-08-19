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




namespace PMDS.GUI.Klient
{


    public partial class ucVerwaltungKlinikenUser: UserControl
    {
        public bool abort = true;

        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();
        
        public frmVerwaltungKlinikenUser mainWindow = null;
        public bool _loadAllBenutzer = true;
        public bool _KlientenzuordnungChanged = false;

        public Nullable<Guid> SelectedIDKlinik = null;
        public Nullable<Guid> SelectedIDAbteilung = null;
        public Nullable<Guid> SelectedIDBereich = null;










        public ucVerwaltungKlinikenUser()
        {
            InitializeComponent();
        }

        private void ucVerwaltungKlinikenPatienten_Load(object sender, EventArgs e)
        {

        }
        


        public void initControl()
        {
            try
            {
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnClose.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Beenden, 32, 32);

                this.sqlManange1.initControl();
                this.loadKliniken();
                this.setKlientenOnOff(false);
                //this.lvKlienten.Visible = false;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.initControl: " + ex.ToString());
            }
        }

        public void setKlientenOnOff(bool bOn)
        {
            try
            {
                this.lvBenutzer.Items.Clear();
                this.lvBenutzer.Refresh();

                this.lblFoundKlienten.Text = "";
                this.lblFoundKlienten.Visible = bOn;

                if (!bOn)
                {
                    this.SelectedIDKlinik = null;
                    this.SelectedIDAbteilung = null;
                    this.SelectedIDBereich = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.selectKlienten: " + ex.ToString());
            }
        }
        public void selectKlienten(CheckState bOn)
        {
            try
            {
                foreach (UltraListViewItem listItem in this.lvBenutzer.Items)
                {
                    listItem.CheckState = bOn;
                }
                this.lvBenutzer.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.selectKlienten: " + ex.ToString());
            }
        }


        public bool loadKliniken()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.klinikBindingSource.Clear();
                    System.Linq.IQueryable<Klinik> tKliniken = this.b.loadAllKliniken(db);
                    //foreach (Klinik rKlinik in tKliniken)
                    //{
                    //    this.klinikBindingSource.Add(rKlinik);
                    //}
                    //this.gridKliniken.Refresh();
                    this.gridKliniken.DataSource = tKliniken.ToList();
                    this.gridKliniken.Refresh();
                }
                
                this.gridKliniken.Selected.Rows.Clear();
                this.gridKliniken.ActiveRow = null;
                this._KlientenzuordnungChanged = false;
                this.btnSave.Enabled = false;

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.loadKliniken: " + ex.ToString());
            }
        }
        public bool loadAbteilungen(Guid IDKlinik)
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.dsAbteilung.Clear();
                    this.gridBereiche.Refresh();
                    this.selectKlienten(CheckState.Unchecked);
                    this.setKlientenOnOff(false);

                    this.gridAbteilungen.Refresh();

                    System.Linq.IQueryable<Abteilung> tAbteilung = this.b.getAllAbteilungen(IDKlinik, db);
                    foreach (Abteilung rAbteilung in tAbteilung)
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNew = this.sqlManange1.getNewUI(ref this.dsAbteilung);
                        //PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)this.dsAbteilung.UI.NewRow();
                        rNew.ID = rAbteilung.ID;
                        rNew.Bezeichnung = rAbteilung.Bezeichnung.Trim();
                    }
                    this.gridAbteilungen.Refresh();
                    this.gridAbteilungen.Refresh();
                }
                
                this.gridAbteilungen.Selected.Rows.Clear();
                this.gridAbteilungen.ActiveRow = null;
                this._KlientenzuordnungChanged = false;
                this.btnSave.Enabled = false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.loadAbteilungen: " + ex.ToString());
            }
        }
        public bool loadBereiche(Guid IDAbteilung)
        {
            try
            {
                System.Linq.IQueryable<Bereich> tBereich = null;
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    this.selectKlienten(CheckState.Unchecked);
                    this.dsBereiche.Clear();
                    this.selectKlienten(CheckState.Unchecked);
                    this.setKlientenOnOff(false);

                    this.b.getAllBereichForAbteilung(IDAbteilung, ref tBereich, db);
                    foreach (Bereich rBereich in tBereich)
                    {
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNew = this.sqlManange1.getNewUI(ref this.dsBereiche);
                        //PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rNew = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)this.dsBereiche.UI.NewRow();
                        rNew.ID = rBereich.ID;
                        rNew.ID2 = (Guid)rBereich.IDAbteilung;
                        rNew.Bezeichnung = rBereich.Bezeichnung.Trim();
                    }
                    this.gridBereiche.Refresh();
                    //this.gridBereiche.DataSource = tBereich.ToList();
                }

                //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in this.gridBereiche.DisplayLayout.Bands[0].Columns)
                //{
                //    col.Hidden = true;
                //}
                //this.gridBereiche.DisplayLayout.Bands[0].Columns["Bezeichnung"].Hidden = false;
                //this.gridBereiche.Rows.ExpandAll(true);
                
                this.gridBereiche.Selected.Rows.Clear();
                this.gridBereiche.ActiveRow = null;
                this._KlientenzuordnungChanged = false;
                this.btnSave.Enabled = false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.loadBereiche: " + ex.ToString());
            }
        }
        public bool loadBenutzer(Guid IDAbteilung, Guid IDBereich, bool loadAllBenutzer)
        {
            try
            {
                this._KlientenzuordnungChanged = false;
                this.btnSave.Enabled = false;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Collections.Generic.List<Guid> lstBenutzerAll= new System.Collections.Generic.List<Guid>();
                    this.setKlientenOnOff(true);
                    System.Collections.Generic.List<Guid> lstBenutzerReturn = new List<Guid>();
                    IQueryable<PMDS.db.Entities.Benutzer> tBenutzer = this.b.getAllUsers(db,ref lstBenutzerReturn);
                    foreach (Benutzer rBenutzer in tBenutzer)
                    {

                        if ((bool)rBenutzer.AktivJN || cbNichtAktiveAnzeigen.Checked)
                        {
                            //UltraListViewItem listItem = new UltraListViewItem(rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + " (" + rBenutzer.Benutzer1.Trim() + ")", null, null);
                            UltraListViewItem listItem = new UltraListViewItem(rBenutzer.Benutzer1.Trim() + " - " + rBenutzer.Nachname.Trim() + " " + rBenutzer.Vorname.Trim() + "", null, null);
                            listItem.Key = System.Guid.NewGuid().ToString();
                            listItem.Tag = rBenutzer.ID;
                            listItem.CheckState = CheckState.Unchecked;
                            this.lvBenutzer.Items.Add(listItem);
                            lstBenutzerAll.Add(rBenutzer.ID);
                        }
                    }
                    this.lvBenutzer.Refresh();

                    System.Collections.Generic.List<Guid> lstBenutzerSelected = new System.Collections.Generic.List<Guid>();
                    this.b.getAllUsersAbteilungBereiche(IDAbteilung, IDBereich, db, ref lstBenutzerAll, ref lstBenutzerSelected);
                    foreach (Guid IDBenutzerSelected in lstBenutzerSelected)
                    {
                        foreach (UltraListViewItem listItem in this.lvBenutzer.Items)
                        {
                            Guid IDBenutzer = (Guid)listItem.Tag;
                            if (IDBenutzerSelected.Equals(IDBenutzer))
                            {
                                listItem.CheckState = CheckState.Checked;
                            }
                        }
                    }
                    
                    this.lblFoundKlienten.Text = "Gefunden: " + this.lvBenutzer.Items.Count.ToString();
                }
                
                this._loadAllBenutzer = loadAllBenutzer;

                UltraGridRow rGridSel = null;
                Klinik rKlinik = this.getSelectedRowKlinik(true, ref rGridSel);
                if (rKlinik == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.loadBenutzer: rKlinik=null not possible!");
                }
                PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIAbteilung = this.getSelectedRowAbteilung(true, ref rGridSel);
                if (rUIAbteilung == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.loadBenutzer: rUIAbteilung=null not possible!");
                }
                PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIBereich = this.getSelectedRowBereich(true, ref rGridSel);
                if (rUIBereich == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.loadBenutzer: rBereich=null not possible!");
                }

                this.SelectedIDKlinik = rKlinik.ID;
                this.SelectedIDAbteilung = rUIAbteilung.ID;
                this.SelectedIDBereich = rUIBereich.ID;

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.loadBenutzer: " + ex.ToString());
            }
        }

        public void checkChangedSelections()
        {
            try
            {
                if (this._KlientenzuordnungChanged)
                {
                    if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Änderungen speichern?", "Speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.saveData(true);
                    }
                    this._KlientenzuordnungChanged = false;
                    this.btnSave.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.checkChangedSelections: " + ex.ToString());
            }
        }
        public bool saveData(bool WithMsgBox)
        {
            try
            {
                if (this.SelectedIDKlinik == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.saveData: this.SelectedIDKlinik=null not possible!");
                }
                if (this.SelectedIDAbteilung == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.saveData: this.SelectedIDAbteilung=null not possible!");
                }
                if (this.SelectedIDBereich == null)
                {
                    throw new Exception("ucVerwaltungKlinikenUser.saveData: this.SelectedIDBereich=null not possible!");
                }

                int iCounterBenutzerChanged = 0;
                foreach (UltraListViewItem listItem in this.lvBenutzer.Items)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        bool AnyDataChanged = false;
                        bool AbteilungAdded = false;
                        Guid IDBenutzer = (Guid)listItem.Tag;
                        IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung = db.BenutzerAbteilung.Where(o => o.IDBenutzer == IDBenutzer && o.IDAbteilung == this.SelectedIDAbteilung);
                        if (tBenutzerAbteilung.Count() > 0)
                        {
                            if (listItem.CheckState != CheckState.Checked)
                            {
                                foreach (BenutzerAbteilung rBenutzerAbteilung in tBenutzerAbteilung)
                                {
                                    db.BenutzerAbteilung.Remove(rBenutzerAbteilung);
                                    AnyDataChanged = true;
                                }
                            }
                        }
                        else
                        {
                            if (listItem.CheckState == CheckState.Checked)
                            {
                                BenutzerAbteilung newBenutzerAbteilung = new BenutzerAbteilung();
                                newBenutzerAbteilung.ID = System.Guid.NewGuid();
                                newBenutzerAbteilung.IDBenutzer = IDBenutzer;
                                newBenutzerAbteilung.IDAbteilung = (Guid)this.SelectedIDAbteilung;
                                db.BenutzerAbteilung.Add(newBenutzerAbteilung);
                                AnyDataChanged = true;
                                AbteilungAdded = true;
                            }
                        }
                        IQueryable<PMDS.db.Entities.BereichBenutzer> tBereichBenutzer = db.BereichBenutzer.Where(o => o.IDBenutzer == IDBenutzer && o.IDBereich == (Guid)this.SelectedIDBereich);
                        if (tBereichBenutzer.Count() > 0)
                        {
                            if (listItem.CheckState != CheckState.Checked)
                            {
                                foreach (BereichBenutzer rBereichBenutzer in tBereichBenutzer)
                                {
                                    db.BereichBenutzer.Remove(rBereichBenutzer);
                                    AnyDataChanged = true;
                                }
                            }
                        }
                        else
                        {
                            if (listItem.CheckState == CheckState.Checked)
                            {
                                BereichBenutzer newBereichBenutzer = new BereichBenutzer();
                                newBereichBenutzer.IDBenutzer = IDBenutzer;
                                newBereichBenutzer.IDBereich = (Guid)this.SelectedIDBereich;
                                newBereichBenutzer.Info = "";
                                db.BereichBenutzer.Add(newBereichBenutzer);

                                //IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilung2 = db.BenutzerAbteilung.Where(o => o.IDBenutzer == IDBenutzer && o.IDAbteilung == rAbteilung.ID);
                                //if (tBenutzerAbteilung2.Count() == 0 && !AbteilungAdded)
                                //{
                                //    BenutzerAbteilung newBenutzerAbteilung = new BenutzerAbteilung();
                                //    newBenutzerAbteilung.ID = System.Guid.NewGuid();
                                //    newBenutzerAbteilung.IDBenutzer = IDBenutzer;
                                //    newBenutzerAbteilung.IDAbteilung = rAbteilung.ID;
                                //    db.BenutzerAbteilung.Add(newBenutzerAbteilung);
                                //    AnyDataChanged = true;
                                //}

                                AnyDataChanged = true;
                            }
                        }

                        if (AnyDataChanged)
                        {
                            db.SaveChanges();
                            iCounterBenutzerChanged += 1;
                        }
                    }
                }

                bool AnyDataChanged2 = false;
                foreach (UltraListViewItem listItem in this.lvBenutzer.Items)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        foreach (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUI in this.dsBereiche.UI)
                        {
                            Guid IDBenutzer = (Guid)listItem.Tag;
                            IQueryable<PMDS.db.Entities.BereichBenutzer> tBereich = db.BereichBenutzer.Where(o => o.IDBenutzer == IDBenutzer && o.IDBereich == rUI.ID);
                            if (tBereich.Count() > 0)
                            {
                                IQueryable<PMDS.db.Entities.BenutzerAbteilung> tBenutzerAbteilungCheck = db.BenutzerAbteilung.Where(o => o.IDBenutzer == IDBenutzer && o.IDAbteilung == rUI.ID2);
                                if (tBenutzerAbteilungCheck.Count() == 0)
                                {
                                    BenutzerAbteilung newBenutzerAbteilung = new BenutzerAbteilung();
                                    newBenutzerAbteilung.ID = System.Guid.NewGuid();
                                    newBenutzerAbteilung.IDBenutzer = IDBenutzer;
                                    newBenutzerAbteilung.IDAbteilung = (Guid)rUI.ID2;
                                    db.BenutzerAbteilung.Add(newBenutzerAbteilung);

                                    db.SaveChanges();
                                    AnyDataChanged2 = true;
                                }
                            }
                        }
                    }
                }

                if (WithMsgBox)
                {
                    string sMsgBoxTranslate = "{0}. Benutzer neu zu Abteilungen und Bereichen zugeordnet!";
                    sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, iCounterBenutzerChanged.ToString());
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "PMDS", MessageBoxButtons.OK);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucVerwaltungKlinikenUser.saveData: " + ex.ToString());
            }
        }







        public Klinik getSelectedRowKlinik(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridKliniken.ActiveRow != null)
                {
                    if (this.gridKliniken.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einrichtung ausgewählt!");
                        return null;
                    }
                    else
                    {
                        Klinik rKlinik = (Klinik)this.gridKliniken.ActiveRow.ListObject;
                        gridRow = this.gridKliniken.ActiveRow;
                        return rKlinik;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einrichtung ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.getSelectedRowKlinik: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsKlientenliste.UIRow getSelectedRowAbteilung(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridAbteilungen.ActiveRow != null)
                {
                    if (this.gridAbteilungen.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abteilung ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridAbteilungen.ActiveRow.ListObject;
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rSelRow = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)v.Row;
                        gridRow = this.gridAbteilungen.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abteilung ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.getSelectedRowAbteilung: " + ex.ToString());
            }
        }
        public PMDS.Global.db.ERSystem.dsKlientenliste.UIRow getSelectedRowBereich(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridBereiche.ActiveRow != null)
                {
                    if (this.gridBereiche.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Bereich ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridBereiche.ActiveRow.ListObject;
                        PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rSelRow = (PMDS.Global.db.ERSystem.dsKlientenliste.UIRow)v.Row;
                        gridRow = this.gridBereiche.ActiveRow;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Bereich ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucÄrzteMergen.getSelectedRowBereich: " + ex.ToString());
            }
        }





        private void gridKliniken_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridKliniken))
                {
                    UltraGridRow rGridSel = null;
                    Klinik rKlinik = this.getSelectedRowKlinik(false, ref rGridSel);
                    if (rKlinik != null)
                    {
                        this.checkChangedSelections();
                        this.loadAbteilungen(rKlinik.ID);
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
        private void gridKliniken_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridKliniken))
                {

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
        private void gridAbteilungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridAbteilungen))
                {
                    UltraGridRow rGridSel = null;
                    PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIAbteilung = this.getSelectedRowAbteilung(false, ref rGridSel);
                    if (rUIAbteilung != null)
                    {
                        this.checkChangedSelections();
                        this.loadBereiche(rUIAbteilung.ID);
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
        private void gridAbteilungen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridAbteilungen))
                {

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
        private void gridBereiche_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridBereiche))
                {
                    UltraGridRow rGridSel = null;
                    PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIBereich = this.getSelectedRowBereich(false, ref rGridSel);
                    if (rUIBereich != null)
                    {
                        this.checkChangedSelections();
                        this.loadBenutzer((Guid)rUIBereich.ID2, rUIBereich.ID, this._loadAllBenutzer);
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
        private void gridBereiche_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridBereiche))
                {

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

        private void lvKlienten_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

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
        private void lvBenutzer_ItemCheckStateChanging(object sender, ItemCheckStateChangingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

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
        private void lvKlienten_ItemCheckStateChanged(object sender, Infragistics.Win.UltraWinListView.ItemCheckStateChangedEventArgs e)
        {
            try
            {
                if (this.lvBenutzer.Focused)
                {
                    this._KlientenzuordnungChanged = true;
                    this.btnSave.Enabled = true;
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

                if (this.saveData(true))
                {
                    this.loadBenutzer((Guid)this.SelectedIDAbteilung, (Guid)this.SelectedIDBereich, true);
                    this.abort = false;
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.mainWindow.Close();
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


        private void lblKlinikenVerwalten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

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
        private void lblAbteilungenVerwalten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                Klinik rKlinik = this.getSelectedRowKlinik(true, ref rGridSel);
                if (rKlinik != null)
                {
                    frmAbteilungen frmAbteilungen1 = new frmAbteilungen();
                    frmAbteilungen1.initControl(rKlinik.ID);
                    frmAbteilungen1.ShowDialog(this);
                    if (!frmAbteilungen1.ucAbteilungen2.abort)
                    {
                        this.loadAbteilungen(rKlinik.ID);
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
        private void lblBereicheVerwalten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIAbteilung = this.getSelectedRowAbteilung(true, ref rGridSel);
                if (rUIAbteilung != null)
                {
                    frmBereiche frmBereiche1 = new frmBereiche();
                    frmBereiche1.initControl(rUIAbteilung.ID);
                    frmBereiche1.ShowDialog(this);
                    if (!frmBereiche1.ucBereiche1.abort)
                    {
                        this.loadBereiche(rUIAbteilung.ID);
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
        private void lblBenutzerVerwalten_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIBereich = this.getSelectedRowBereich(true, ref rGridSel);
                if (rUIBereich != null)
                {
                    GuiAction.BenutzerVerwaltung(true);
                    this.loadBenutzer((Guid)this.SelectedIDAbteilung, (Guid)this.SelectedIDBereich, true);
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

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectKlienten(CheckState.Checked);


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
        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.selectKlienten(CheckState.Unchecked);

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

        private void cbNichtAktiveAnzeigen_CheckedValueChanged(object sender, EventArgs e)
        {
            UltraGridRow rGridSel = null;
            PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUIBereich = this.getSelectedRowBereich(false, ref rGridSel);
            if (rUIBereich != null)
            {
                this.checkChangedSelections();
                this.loadBenutzer((Guid)rUIBereich.ID2, rUIBereich.ID, this._loadAllBenutzer);
            }
        }
    }
}
