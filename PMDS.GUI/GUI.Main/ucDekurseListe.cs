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

using PMDS.BusinessLogic;
using PMDS.Global;
using PMDS.GUI.Engines;




namespace PMDS.GUI.GUI.Main
{


    public partial class ucDekurseListe : UserControl
    {
        
        public bool Isinitialized = false;

        public PMDS.DB.PMDSBusiness b = new PMDSBusiness();
        public qs2.core.vb.funct funct1 = new qs2.core.vb.funct();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            All = 0,
            Alias = 1
        }

        public Nullable<Guid> _IDBenutzerAlias = null;









        public ucDekurseListe()
        {
            InitializeComponent();
        }

        private void ucDekurseListe_Load(object sender, EventArgs e)
        {

        }


        public void initControl(eTypeUI TypeUI, Nullable<Guid> IDBenutzerAlias)
        {
            try
            {
                if (!this.Isinitialized)
                {
                    this._TypeUI = TypeUI;
                    this._IDBenutzerAlias = IDBenutzerAlias;

                    this.btnAdd.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                    this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                    this.btnRefresh.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Aktualisieren, 32, 32);
                    this.btnPrint.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32);

                    //foreach (UltraGridColumn col in this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns)
                    //{
                    //    col.Hidden = true;
                    //}

                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.ZeitpunktColumn.ColumnName].Hidden = false;
                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.ZeitpunktColumn.ColumnName].Header.VisiblePosition = 0;

                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.PatientColumn.ColumnName].Hidden = false;
                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.PatientColumn.ColumnName].Header.VisiblePosition = 1;

                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.ErstelltVonColumn.ColumnName].Hidden = false;
                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.ErstelltVonColumn.ColumnName].Header.VisiblePosition = 2;

                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.DatumErstelltColumn.ColumnName].Hidden = false;
                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.DatumErstelltColumn.ColumnName].Header.VisiblePosition = 3;

                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.DekursColumn.ColumnName].Hidden = false;
                    //this.gridDekurseEntwürfe.DisplayLayout.Bands[0].Columns[this.dsKlientenliste1.DekurseEntwürfe.DekursColumn.ColumnName].Header.VisiblePosition = 4;

                    this.clearUI();
                    this.loadData();

                    this.Isinitialized = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.initControl: " + ex.ToString());
            }
        }

        public void clearUI()
        {
            try
            {
                this.dsKlientenliste1.Clear();
                this.gridDekurseEntwürfe.Refresh();

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.clearUI: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.clearUI();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    System.Linq.IQueryable<PflegeEintragEntwurf> tPflegeEintragEntwurf = null;
                    if (this._TypeUI == eTypeUI.All)
                    {
                        tPflegeEintragEntwurf = this.b.getPflegeEintragEntwürf(this.b.LogggedOnUser(db).ID, db);
                    }
                    else if (this._TypeUI == eTypeUI.Alias)
                    {
                        tPflegeEintragEntwurf = this.b.getPflegeEintragEntwürf(this._IDBenutzerAlias.Value, db);
                    }
                    else
                    {
                        throw new Exception("ucDekurseListe.loadData: this._TypeUI '" + this._TypeUI.ToString() + "' not allowed!");
                    }

                    foreach (PflegeEintragEntwurf rPflegeEintragEntwurf in tPflegeEintragEntwurf)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAufenthalt(rPflegeEintragEntwurf.IDAufenthalt, db);

                        //os191224
                        Guid IDPatient = new Guid(rAufenthalt.IDPatient.Value.ToString());
                        var rPatInfo = (from p in db.Patient
                                        where p.ID == IDPatient
                                        select new
                                        { p.Nachname, p.Vorname }
                                           ).First();
                        //PMDS.db.Entities.Patient rPatient = this.b.getPatient(rAufenthalt.IDPatient.Value, db);

                        PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rNewDekursEntwurf = this.sqlManange1.getNewDekursEntwürfe(ref this.dsKlientenliste1);
                        rNewDekursEntwurf.IDPEEntwurf = rPflegeEintragEntwurf.ID;
                        if (rPflegeEintragEntwurf.Zeitpunkt != null)
                        {
                            rNewDekursEntwurf.Zeitpunkt = rPflegeEintragEntwurf.Zeitpunkt.Value;
                        }
                        rNewDekursEntwurf.IDAufenthalt = rAufenthalt.ID;
                        rNewDekursEntwurf.Patient = rPatInfo.Nachname.Trim() + " " + rPatInfo.Vorname.Trim();
                        rNewDekursEntwurf.DatumErstellt = rPflegeEintragEntwurf.DatumErstellt.Value;
                        PMDS.db.Entities.Benutzer rBenutzer = this.b.getUser(rPflegeEintragEntwurf.IDBenutzer.Value, db);
                        rNewDekursEntwurf.ErstelltVon = rBenutzer.Benutzer1.Trim();
                        if (rPflegeEintragEntwurf.IDPflegePlan != null)
                        {
                            PMDS.db.Entities.PflegePlan rPflegePlan = this.b.getPflegeplan(rPflegeEintragEntwurf.IDPflegePlan.Value, db);
                            rNewDekursEntwurf.IDPflegePlan = rPflegePlan.ID;
                        }
                        rNewDekursEntwurf.Dekurs = rPflegeEintragEntwurf.Text;

                        PMDS.db.Entities.Abteilung rAbteilung = this.b.getAbteilung(rAufenthalt.IDAbteilung.Value, db);
                        rNewDekursEntwurf.Abteilung = rAbteilung.Bezeichnung.Trim();
                        PMDS.db.Entities.Klinik rKlinik = this.b.getKlinik(rAbteilung.IDKlinik.Value, db);
                        rNewDekursEntwurf.Klinik = rKlinik.Bezeichnung.Trim();

                        if (rPflegeEintragEntwurf.FuerUserErstellt != null)
                        {
                            PMDS.db.Entities.Benutzer rBenutzerFür = this.b.getUser(rPflegeEintragEntwurf.FuerUserErstellt.Value, db);
                            rNewDekursEntwurf.IDFuerUserErstellt = rPflegeEintragEntwurf.FuerUserErstellt.Value;
                            rNewDekursEntwurf.FuerUserErstellt = rBenutzerFür.Nachname.Trim() + " " + rBenutzerFür.Vorname.Trim();
                        }

                    }
                }

                this.gridDekurseEntwürfe.Refresh();
                this.gridDekurseEntwürfe.DisplayLayout.Bands[0].SortedColumns.Clear();
                this.gridDekurseEntwürfe.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.DekurseEntwürfe.ZeitpunktColumn.ColumnName, true);
                this.gridDekurseEntwürfe.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.DekurseEntwürfe.PatientColumn.ColumnName, false);

                this.gridDekurseEntwürfe.ActiveRow = null;

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.loadData: " + ex.ToString());
            }
        }


        public PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow getSelectedRow(bool withMsgBox, ref Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            try
            {
                if (this.gridDekurseEntwürfe.ActiveRow != null)
                {
                    if (this.gridDekurseEntwürfe.ActiveRow.IsGroupByRow)
                    {
                        if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Dekurs-Entwurf ausgewählt!");
                        return null;
                    }
                    else
                    {
                        DataRowView v = (DataRowView)this.gridDekurseEntwürfe.ActiveRow.ListObject;
                        PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rSelRow = (PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow)v.Row;
                        return rSelRow;
                    }
                }
                else
                {
                    if (withMsgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Dekurs-Entwurf ausgewählt!");
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.getSelectedRow: " + ex.ToString());
            }
        }
        
        public void add(Guid IDPatient)
        {
            try
            {
                if (PMDS.Global.ENV.CurrentIDPatient != System.Guid.Empty)
                {
                    if (GuiAction.PatientVermerk(IDPatient, null, eDekursherkunft.DekursAusIntervention, "", false, true, null, false, "Dekurs-Liste > Fct. add()", false, ""))
                    {
                        this.loadData();
                    }
                }
                else
                {
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Patient ausgewählt!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.add: " + ex.ToString());
            }
        }

        public void delete(PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rDekurseEntwürf)
        {
            try
            {
                if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Dekurs-Entwurf wirklich löschen?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PflegeEintragEntwurf> tPflegeEintragEntwurf = db.PflegeEintragEntwurf.Where(p => p.ID == rDekurseEntwürf.IDPEEntwurf);
                        PflegeEintragEntwurf rPflegeEintragEntwurf = tPflegeEintragEntwurf.First();
                        db.PflegeEintragEntwurf.Remove(rPflegeEintragEntwurf);
                        db.SaveChanges();
                        this.loadData();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDekurseListe.delete: " + ex.ToString());
            }
        }



        private void gridFortbildungen_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(("xy").Trim().ToLower()))
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridFortbildungen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDekurseEntwürfe))
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
        private void gridFortbildungen_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridDekurseEntwürfe))
                {
                    UltraGridRow rGridSel = null;
                    PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rDekursEntwurf = this.getSelectedRow(false, ref rGridSel);
                    if (rDekursEntwurf != null)
                    {
                        Guid IDPatientTmp;
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAufenthalt(rDekursEntwurf.IDAufenthalt, db);
                            IDPatientTmp = rAufenthalt.IDPatient.Value;
                        }

                        bool ErstellenAls = false;
                        if (!rDekursEntwurf.IsIDFuerUserErstelltNull())
                        {
                            ErstellenAls = true;
                        }
                        if (GuiAction.PatientVermerk(IDPatientTmp, null, eDekursherkunft.DekursAusIntervention, "", false, true, rDekursEntwurf.IDPEEntwurf, false, "ucDekursListe.gridFortbildungen_DoubleClick()", ErstellenAls, ""))
                        {
                            this.loadData();
                        }
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
        private void gridFortbildungen_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = true;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Infragistics.Win.UltraWinGrid.UltraGridRow rSelGridRow = null;
                PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rSelDekursEntwürfe = this.getSelectedRow(false, ref rSelGridRow);
                if (rSelDekursEntwürfe != null)
                {
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<db.Entities.Aufenthalt> tAufenthalt = db.Aufenthalt.Where(p => p.ID == rSelDekursEntwürfe.IDAufenthalt);
                        db.Entities.Aufenthalt rAufenthalt = tAufenthalt.First();
                        this.add(rAufenthalt.IDPatient.Value);
                    }
                }
                else
                {
                    this.add(PMDS.Global.ENV.CurrentIDPatient);
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
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UltraGridRow rGridSel = null;
                PMDS.Global.db.ERSystem.dsKlientenliste.DekurseEntwürfeRow rSelRow = this.getSelectedRow(true, ref rGridSel);
                if (rSelRow != null)
                {
                    this.delete(rSelRow);
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
                this.loadData();

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.ultraGridPrintDocument1.Grid = this.gridDekurseEntwürfe;
                this.UltraPrintPreviewDialog1.Document = this.ultraGridPrintDocument1;
                this.UltraPrintPreviewDialog1.ShowDialog(this);
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
