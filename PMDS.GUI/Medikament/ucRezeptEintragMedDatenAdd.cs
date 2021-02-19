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
using PMDS.Global.db.ERSystem;



namespace PMDS.GUI.Medikament
{


    public partial class ucRezeptEintragMedDatenAdd : UserControl
    {
        public Guid _IDRezeptEintragMedDatenWundePos;
        public Guid _IDPatient;
        public ucRezeptEintragMedDaten.eTypeUI _TypeUI;
        public bool abort = true;

        public ucRezeptEintragMedDaten mainWindow = null;
        public PMDSBusiness b = new PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public string colSelect = "Select";
        public PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();

        public frmRezeptEintragMedDatenAdd2 mainWindowFrm = null;







        public ucRezeptEintragMedDatenAdd()
        {
            InitializeComponent();
        }

        private void frmRezeptEintragMedDatenAdd_Load(object sender, EventArgs e)
        {

        }


        public void initControl(Guid IDRezeptEintragMedDatenWundePos, Guid IDPatient, ucRezeptEintragMedDaten.eTypeUI TypeUI)
        {
            try
            {
                this._IDRezeptEintragMedDatenWundePos = IDRezeptEintragMedDatenWundePos;
                this._IDPatient = IDPatient;
                this._TypeUI = TypeUI;

                this.mainWindowFrm.AcceptButton = this.btnOK;
                this.mainWindowFrm.CancelButton = this.btnAbort;
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                
                if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridMedDatenAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = false;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, true, false);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinsche Daten zu Medikament");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridRezepteintragAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = true;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, false, false);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zu medizinschen Daten");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridRezepteintragWundeAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = true;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, false, false);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zur Wunde");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridRezepteintrag2WundeAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = false;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, false, true);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden zu Medikament");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridVORezepteintragAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = true;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, false, false);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zur Verordnung");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridVOMedDatenAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = false;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, true, false);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinische Daten zur Verordnung");
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                {
                    this.gridMedDatenRezepteintrag.Name = "gridVOWundeAdd";
                    this.gridMedDatenRezepteintrag.IDRes = this.gridMedDatenRezepteintrag.Name;
                    this.chkAbgesetzteAnzeigen.Visible = false;
                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, this.colSelect, this.dsKlientenliste1, false, true);
                    this.mainWindowFrm.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden zur Verordnung");
                }

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsKlientenliste1.Clear();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.IDPatient == this._IDPatient);
                        foreach (PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten in tMedizinischeDaten)
                        {
                            this.loadDataMedDatenDetail(rMedizinischeDaten, null, db);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BeschreibungColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.VonColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BisColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);

                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.IDAufenthalt == rAufenthalt.ID);
                        foreach (PMDS.db.Entities.RezeptEintrag rRezeptEintrag in tRezeptEintrag)
                        {
                            this.loadDataRezeptEintragDetail(rRezeptEintrag, null, db, false);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);

                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.IDAufenthalt == rAufenthalt.ID);
                        foreach (PMDS.db.Entities.RezeptEintrag rRezeptEintrag in tRezeptEintrag)
                        {
                            this.loadDataRezeptEintragDetail(rRezeptEintrag, null, db, true);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf)
                    {
                        this.loadDataWunden(db);
                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente)
                    {
                        PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);

                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.IDAufenthalt == rAufenthalt.ID);
                        foreach (PMDS.db.Entities.RezeptEintrag rRezeptEintrag in tRezeptEintrag)
                        {
                            this.loadDataRezeptEintragDetail(rRezeptEintrag, null, db, false);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.IDPatient == this._IDPatient);
                        foreach (PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten in tMedizinischeDaten)
                        {
                            this.loadDataMedDatenDetail(rMedizinischeDaten, null, db);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BeschreibungColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.VonColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BisColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                        this.loadDataWunden(db);
                        this.gridMedDatenRezepteintrag.Refresh();
                        
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                }

                this.DoLayout(this._TypeUI);

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.loadData: " + ex.ToString());
            }
        }
        public void DoLayout(ucRezeptEintragMedDaten.eTypeUI TypeUI)
        {
            try
            { 
                if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime && ENV.AppRunning)
                {
                    qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                    compLayout1.initControl();
                    bool LayoutFound = false;

                    if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2 || TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente || TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten || TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2)
                    {
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf)
                    {
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.DoLayout: " + ex.ToString());
            }
        }


        public void loadDataRezeptEintragDetail(PMDS.db.Entities.RezeptEintrag rRezeptEintrag, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db, bool IsWunde)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.Medikament> tMedikament = db.Medikament.Where(o => o.ID == rRezeptEintrag.IDMedikament);
                PMDS.db.Entities.Medikament rMedikament = tMedikament.First();

                if (this.PMDSBusinessUI2.abgesetzteAnzeigenJN(rRezeptEintrag, this.chkAbgesetzteAnzeigen.Checked, db))
                {
                    if (rUINew == null)
                    {
                        rUINew = sqlManange1.getNewUI(ref this.dsKlientenliste1);
                    }
                    
                    rUINew.Rezepteintrag = rMedikament.Bezeichnung.Trim();
                    rUINew.Von = rRezeptEintrag.AbzugebenVon;
                    if (rRezeptEintrag.AbzugebenBis.Date.Year == 3000)
                    {
                        rUINew.SetBisNull();
                    }
                    else
                    {
                        rUINew.Bis = rRezeptEintrag.AbzugebenBis;
                    }

                    rUINew.Dosierung = rRezeptEintrag.DosierungASString.Trim();
                    rUINew.IDRezeptEintrag = rRezeptEintrag.ID;
                    if (!IsWunde)
                    {
                        rUINew.IDMedDatenWundeKopf = this._IDRezeptEintragMedDatenWundePos;
                    }
                    else
                    {
                        rUINew.IDMedDatenWundeKopf = this._IDRezeptEintragMedDatenWundePos;
                    }

                    if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                       rUINew.IDVerordnung = this._IDRezeptEintragMedDatenWundePos;
                    }

                    rUINew.Herrichten = PMDS.DynReportsForms.MedikamentenBlattDataSource.orderByHerrichten(rRezeptEintrag.Herrichten);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.loadDataRezeptEintragDetail: " + ex.ToString());
            }
        }
        public void loadDataWunden(PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(this._IDPatient, false, db);
                var tJoinWundeKopf = (from wk in db.WundeKopf
                                      join apx in db.AufenthaltPDx on wk.IDAufenthaltPDx equals apx.ID
                                      join pdx in db.PDX on apx.IDPDX equals pdx.ID
                                      where apx.IDAufenthalt == rAufenthalt.ID
                                      select new
                                      {
                                          PDXKlartext = pdx.Klartext,
                                          Lokalisierung = apx.Lokalisierung,
                                          LokalisierungSeite = apx.LokalisierungSeite,
                                          WKDatumErstellt = wk.DatumErstellt,
                                          ID = wk.ID
                                      });

                foreach (var r in tJoinWundeKopf)
                {
                    string sTmpErstellt = "";
                    if (r.WKDatumErstellt != null)
                    {
                        sTmpErstellt = ", " + r.WKDatumErstellt.Value.ToString("dd.MM.yyyy") + "";
                    }
                    string lstWundeTmp = "Wunde:" + r.PDXKlartext.Trim() + " (" + r.Lokalisierung.Trim() + ", " + r.LokalisierungSeite.Trim() + sTmpErstellt + ")" + "\r\n";

                    PMDS.Global.db.ERSystem.dsKlientenliste.UIRow rUINew = sqlManange1.getNewUI(ref this.dsKlientenliste1);

                    rUINew.Bezeichnung = lstWundeTmp.Trim();
                    rUINew.IDMedDatenWundeKopf = r.ID;
                    rUINew.IDVerordnung = this._IDRezeptEintragMedDatenWundePos;
                    if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf)
                    {
                        rUINew.IDRezeptEintrag = this._IDRezeptEintragMedDatenWundePos;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.loadDataRezeptEintragDetail: " + ex.ToString());
            }
        }

        public void loadDataMedDatenDetail(PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                string sMedTyp = "";
                System.Linq.IQueryable<PMDS.db.Entities.MedizinischeTypen> tMedizinischeTypen = null;
                if (rMedizinischeDaten.MedizinischerTyp != null)
                {
                    tMedizinischeTypen = db.MedizinischeTypen.Where(o => o.MedizinischerTyp == rMedizinischeDaten.MedizinischerTyp);
                    PMDS.db.Entities.MedizinischeTypen rMedizinischeTypen = tMedizinischeTypen.First();
                    sMedTyp = rMedizinischeTypen.Beschreibung.Trim();
                }

                if (rUINew == null)
                {
                    rUINew = sqlManange1.getNewUI(ref this.dsKlientenliste1);
                }

                rUINew.MedizinischerTyp = sMedTyp.Trim();
                rUINew.Beschreibung = rMedizinischeDaten.Beschreibung.Trim();
                if (rMedizinischeDaten.Von != null)
                {
                    rUINew.Von = rMedizinischeDaten.Von.Value;
                }
                else
                {
                    rUINew.SetVonNull();
                }
                if (rMedizinischeDaten.Bis != null)
                {
                    rUINew.Bis = rMedizinischeDaten.Bis.Value;
                }
                else
                {
                    rUINew.SetBisNull();
                }
                rUINew.Bemerkung = rMedizinischeDaten.Bemerkung.Trim();
                rUINew.Therapie = rMedizinischeDaten.Therapie.Trim();
                if (rMedizinischeDaten.Beendigungsgrund != null)
                {
                    rUINew.Beendigungsgrund = rMedizinischeDaten.Beendigungsgrund;
                }
                rUINew.IDRezeptEintrag = this._IDRezeptEintragMedDatenWundePos;
                rUINew.IDMedDatenWundeKopf = rMedizinischeDaten.ID;
                if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                {
                    rUINew.IDVerordnung = this._IDRezeptEintragMedDatenWundePos;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.loadDataMedDatenDetail: " + ex.ToString());
            }
        }

        public bool validateData()
        {
            try
            {
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.validateData: " + ex.ToString());
            }
        }
        public bool saveData()
        {
            try
            {
                if (!this.validateData())
                {
                    return false;
                }

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    bool DataChanged = false;
                    foreach (UltraGridRow rGridRow in this.gridMedDatenRezepteintrag.Rows)
                    {
                        if (rGridRow.IsGroupByRow)
                        {
                            this.saveDoGrodRow_rek(rGridRow, db, ref DataChanged);
                        }
                        else
                        {
                            this.saveDoGrodRow(rGridRow, db, ref DataChanged);
                        }
                    }

                    if (DataChanged)
                    {
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.saveData: " + ex.ToString());
            }
        }
        public void saveDoGrodRow_rek(UltraGridRow rFoundInGridParent, PMDS.db.Entities.ERModellPMDSEntities db, ref bool DataChanged)
        {
            try
            {
                foreach (UltraGridChildBand actUltraGridChildBand in rFoundInGridParent.ChildBands)
                {
                    foreach (UltraGridRow rFoundInGrid in actUltraGridChildBand.Rows)
                    {
                        if (rFoundInGrid.IsGroupByRow && rFoundInGrid.Expanded && !rFoundInGrid.IsFilteredOut)
                        {
                            this.saveDoGrodRow_rek(rFoundInGrid, db, ref DataChanged);
                        }
                        else
                        {
                            this.saveDoGrodRow(rFoundInGrid, db, ref DataChanged);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.saveDoGrodRow_rek: " + ex.ToString());
            }
        }
        public void saveDoGrodRow(UltraGridRow rFoundInGrid, PMDS.db.Entities.ERModellPMDSEntities db, ref bool DataChanged)
        {
            try
            {
                DateTime dNow = DateTime.Now;
                PMDS.db.Entities.Benutzer rBenutzer = this.b.LogggedOnUser(db);

                DataRowView v = (DataRowView)rFoundInGrid.ListObject;
                dsKlientenliste.UIRow rUIRow = (dsKlientenliste.UIRow)v.Row;

                if ((bool)rFoundInGrid.Cells[this.colSelect.Trim()].Value == true)
                {
                    if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                    {
                        PMDS.db.Entities.VO_MedizinischeDaten rVO_MedizinischeDaten = new VO_MedizinischeDaten();
                        rVO_MedizinischeDaten.ID = System.Guid.NewGuid();
                        rVO_MedizinischeDaten.IDVerordnung = rUIRow.IDVerordnung;
                        rVO_MedizinischeDaten.IDMedizinischeDaten = rUIRow.IDMedDatenWundeKopf;

                        rVO_MedizinischeDaten.DatumErstellt = dNow;
                        rVO_MedizinischeDaten.DatumGeaendert = dNow;
                        rVO_MedizinischeDaten.IDBenutzerErstellt = rBenutzer.ID;
                        rVO_MedizinischeDaten.IDBenutzerGeaendert = rBenutzer.ID;
                        rVO_MedizinischeDaten.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        rVO_MedizinischeDaten.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                        db.VO_MedizinischeDaten.Add(rVO_MedizinischeDaten);
                        DataChanged = true;
                    }
                    else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                        PMDS.db.Entities.VO_Wunde rVO_Wunde = new VO_Wunde();
                        rVO_Wunde.ID = System.Guid.NewGuid();
                        rVO_Wunde.IDVerordnung = rUIRow.IDVerordnung;
                        rVO_Wunde.IDWundeKopf = rUIRow.IDMedDatenWundeKopf;

                        rVO_Wunde.DatumErstellt = dNow;
                        rVO_Wunde.DatumGeaendert = dNow;
                        rVO_Wunde.IDBenutzerErstellt = rBenutzer.ID;
                        rVO_Wunde.IDBenutzerGeaendert = rBenutzer.ID;
                        rVO_Wunde.LoginNameFreiErstellt = PMDS.Global.ENV.LoginInNameFrei.Trim();
                        rVO_Wunde.LoginNameFreiGeaendert = PMDS.Global.ENV.LoginInNameFrei.Trim();

                        db.VO_Wunde.Add(rVO_Wunde);
                        DataChanged = true;
                    }
                    else
                    {
                        PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten = new RezeptEintragMedDaten();
                        rRezeptEintragMedDaten.ID = System.Guid.NewGuid();
                        if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2 || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2)
                        {
                            rRezeptEintragMedDaten.IDRezepteintrag = rUIRow.IDRezeptEintrag;
                            rRezeptEintragMedDaten.IDMedDaten = rUIRow.IDMedDatenWundeKopf;
                        }
                        else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf)
                        {
                            rRezeptEintragMedDaten.IDRezepteintrag = rUIRow.IDRezeptEintrag;
                            rRezeptEintragMedDaten.IDWundeKopf = rUIRow.IDMedDatenWundeKopf;
                        }
                        else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf)
                        {
                            rRezeptEintragMedDaten.IDRezepteintrag = rUIRow.IDRezeptEintrag;
                            rRezeptEintragMedDaten.IDWundeKopf = rUIRow.IDMedDatenWundeKopf;
                        }
                        else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente)
                        {
                            rRezeptEintragMedDaten.IDVerordnung = rUIRow.IDVerordnung;
                            rRezeptEintragMedDaten.IDRezepteintrag = rUIRow.IDRezeptEintrag;
                        }
                        else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                        {
                            rRezeptEintragMedDaten.IDVerordnung = rUIRow.IDVerordnung;
                            rRezeptEintragMedDaten.IDWundeKopf = rUIRow.IDMedDatenWundeKopf;
                        }

                        db.RezeptEintragMedDaten.Add(rRezeptEintragMedDaten);
                        DataChanged = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.saveDoGrodRow: " + ex.ToString());
            }
        }

        public void OpenForm(Global.db.ERSystem.dsKlientenliste.UIRow rSelRow)
        {
            try
            {
                if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2 || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                {
                    this.PMDSBusinessUI2.OpenFormMedDaten(rSelRow.IDMedDatenWundeKopf);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == rSelRow.IDMedDatenWundeKopf);
                        PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

                        this.loadDataMedDatenDetail(rMedizinischeDaten, rSelRow, db);
                    }
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2 || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente)
                {
                    this.PMDSBusinessUI2.OpenFormRezeptEintrag(rSelRow.IDRezeptEintrag);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == rSelRow.IDRezeptEintrag);
                        PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();

                        this.loadDataRezeptEintragDetail(rRezeptEintrag, rSelRow, db, false);
                    }
                }
                else if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                {
                    this.PMDSBusinessUI2.OpenFormRezeptEintrag(rSelRow.IDRezeptEintrag);
                    using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == rSelRow.IDRezeptEintrag);
                        PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();

                        this.loadDataRezeptEintragDetail(rRezeptEintrag, rSelRow, db, true);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.OpenForm: " + ex.ToString());
            }
        }


        private void gridMedDatenRezepteintrag_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(this.colSelect.Trim().ToLower()))
                {
                    e.Cell.Activation = Activation.AllowEdit;
                }
                else
                {
                    e.Cell.Activation = Activation.NoEdit;
                }

            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }
        private void gridMedDatenRezepteintrag_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMedDatenRezepteintrag))
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
        private void gridMedDatenRezepteintrag_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.UIGlobal1.evDoubleClickOK(ref sender, ref e, (Infragistics.Win.UltraWinGrid.UltraGrid)this.gridMedDatenRezepteintrag))
                {
                    UltraGridRow rGridSel = null;
                    Global.db.ERSystem.dsKlientenliste.UIRow rSelRow = this.PMDSBusinessUI2.getSelectedRow(false, ref rGridSel, this.gridMedDatenRezepteintrag);
                    if (rSelRow != null)
                    {
                        this.OpenForm(rSelRow);
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


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.saveData())
                {
                    this.abort = false;
                    this.mainWindowFrm.Close();
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
                this.mainWindowFrm.Close();

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

        private void chkAbgesetzteAnzeigen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.chkAbgesetzteAnzeigen.Focused)
                {
                    this.loadData();
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
