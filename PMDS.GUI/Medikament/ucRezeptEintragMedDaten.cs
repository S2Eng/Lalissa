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
using Infragistics.Win.UltraWinToolTip;
using PMDS.Data.Global;
using PMDS.BusinessLogic;



namespace PMDS.GUI.Medikament
{
    
    public partial class ucRezeptEintragMedDaten : UserControl
    {

        public Guid _IDRezeptEintragMedDatenWundePos;
        public bool abort = true;

        public frmRezeptEintragMedDaten mainWindow = null;
        public PMDSBusiness b = new PMDSBusiness();
        public UIGlobal UIGlobal1 = new UIGlobal();

        public eTypeUI _TypeUI;
        public enum eTypeUI
        {
            RezeptEintrag2 = 0,
            MedDaten2 = 1,
            WundeKopf = 2,
            RezeptEintragShowWundKopf = 3,
            VOToMedikamente = 4,
            VOToMedDaten = 5,
            VOToWunde = 6
        }

        public PMDS.Global.db.ERSystem.PMDSBusinessUI PMDSBusinessUI1 = new Global.db.ERSystem.PMDSBusinessUI();
        public PMDS.GUI.PMDSBusinessUI PMDSBusinessUI2 = new PMDSBusinessUI();
        public PMDS.Global.db.ERSystem.sqlManange sqlManange1 = new Global.db.ERSystem.sqlManange();
        public PMDSBusinessUI b2 = new PMDSBusinessUI();








        public ucRezeptEintragMedDaten()
        {
            InitializeComponent();
        }

        private void ucRezeptEintragMedDaten_Load(object sender, EventArgs e)
        {

        }
        
        public void initControl(Guid IDRezeptEintragMedDatenWundePos, eTypeUI TypeUI)
        {
            try
            {
                this._IDRezeptEintragMedDatenWundePos = IDRezeptEintragMedDatenWundePos;
                this._TypeUI = TypeUI;

                this.mainWindow.AcceptButton = this.btnSave;
                this.mainWindow.CancelButton = this.btnAbort;
                this.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32);
                this.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32);
                this.btnAddVerknüpfung.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.PMDS2.ico_Verknüpfen_03, 32, 32);
                this.btnAddMedikament.Appearance.Image =  QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                this.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);

                UltraToolTipInfo info2 = new UltraToolTipInfo();
                info2.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Verknüpfung hinzufügen");
                this.ultraToolTipManager1.SetUltraToolTip(this.btnAddVerknüpfung, info2);
                this.btnAddMedikament.Visible = false;

                info2 = new UltraToolTipInfo();
                info2.ToolTipText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament hinzufügen");
                this.ultraToolTipManager1.SetUltraToolTip(this.btnAddMedikament, info2);
                this.btnAddMedikament.Visible = false;
               
                if (this._TypeUI == eTypeUI.RezeptEintrag2)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = false;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, true, false);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete medizinsche Daten zu Medikament");
                }
                else if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = false;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, false, true);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Wunden zu Medikament");
                }
                else if (this._TypeUI == eTypeUI.MedDaten2)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = true;
                    this.btnAddMedikament.Visible = true;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, false, false);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu medizinschen Daten");
                }
                else if (this._TypeUI == eTypeUI.WundeKopf)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = true;
                    this.btnAddMedikament.Visible = true;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, false, false);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu Wunde");
                }
                else if (this._TypeUI == eTypeUI.VOToMedikamente)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = false;
                    this.btnAddMedikament.Visible = true;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, false, false);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zur Verordnung");
                }
                else if (this._TypeUI == eTypeUI.VOToMedDaten)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = false;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, true, false);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete medizinischen Daten zur Verordnung");
                }
                else if (this._TypeUI == eTypeUI.VOToWunde)
                {
                    this.btnSave.Visible = false;
                    this.btnAbort.Visible = false;
                    this.btnAddVerknüpfung.Visible = true;
                    this.btnDel.Visible = true;
                    this.chkAbgesetzteAnzeigen.Visible = false;

                    this.PMDSBusinessUI1.initGridRowsRezeptEintragMedDaten2(this.gridMedDatenRezepteintrag, "", this.dsKlientenliste1, false, true);
                    this.mainWindow.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Wunden zur Verordnung");
                }

                this.loadData();

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.initControl: " + ex.ToString());
            }
        }

        public void loadData()
        {
            try
            {
                this.dsKlientenliste1.Clear();

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._TypeUI == eTypeUI.RezeptEintrag2)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == this._IDRezeptEintragMedDatenWundePos && o.IDVerordnung == null);
                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten in tRezeptEintragMedDaten)
                        {
                            if (rRezeptEintragMedDaten.IDMedDaten != null)
                            {
                                this.loadDataDetailMedDaten(rRezeptEintragMedDaten, null, db);
                            }
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BeschreibungColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.VonColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BisColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == eTypeUI.MedDaten2 || this._TypeUI == eTypeUI.WundeKopf)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = null;
                        if (this._TypeUI == eTypeUI.MedDaten2)
                        {
                            tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == this._IDRezeptEintragMedDatenWundePos && o.IDVerordnung == null);
                        }
                        else if (this._TypeUI == eTypeUI.WundeKopf)
                        {
                            tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDWundeKopf == this._IDRezeptEintragMedDatenWundePos && o.IDVerordnung == null);
                        }
                        
                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten in tRezeptEintragMedDaten)
                        {
                            this.loadDataDetailRezeptEintrag(rRezeptEintragMedDaten, null, db, (this._TypeUI == eTypeUI.WundeKopf ? true:false));
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == this._IDRezeptEintragMedDatenWundePos && o.IDVerordnung == null);
                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten in tRezeptEintragMedDaten)
                        {
                            if (rRezeptEintragMedDaten.IDWundeKopf != null)
                            {
                                this.loadDataWunden(rRezeptEintragMedDaten, null, db, null);
                            }
                        }
                        
                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BezeichnungColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == eTypeUI.VOToMedikamente)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDVerordnung == this._IDRezeptEintragMedDatenWundePos && o.IDRezepteintrag != null && o.IDMedDaten == null && o.IDWundeKopf == null);
                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten in tRezeptEintragMedDaten)
                        {
                            this.loadDataDetailRezeptEintrag(rRezeptEintragMedDaten, null, db, false);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.HerrichtenColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.RezepteintragColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == eTypeUI.VOToMedDaten)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.VO_MedizinischeDaten> tVO_MedizinischeDaten = db.VO_MedizinischeDaten.Where(o => o.IDVerordnung == this._IDRezeptEintragMedDatenWundePos);
                        foreach (PMDS.db.Entities.VO_MedizinischeDaten rVO_MedizinischeDaten in tVO_MedizinischeDaten)
                        {
                            this.loadDataDetailMedDaten2(rVO_MedizinischeDaten, null, db);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.MedizinischerTypColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BeschreibungColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.VonColumn.ColumnName, false);
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BisColumn.ColumnName, false);
                    }
                    else if (this._TypeUI == eTypeUI.VOToWunde)
                    {
                        System.Linq.IQueryable<PMDS.db.Entities.VO_Wunde> tVO_Wunde = db.VO_Wunde.Where(o => o.IDVerordnung == this._IDRezeptEintragMedDatenWundePos);
                        foreach (PMDS.db.Entities.VO_Wunde rVO_Wunde in tVO_Wunde)
                        {
                            this.loadDataWunden(null, null, db, rVO_Wunde);
                        }

                        this.gridMedDatenRezepteintrag.Refresh();

                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Clear();
                        this.gridMedDatenRezepteintrag.DisplayLayout.Bands[0].SortedColumns.Add(this.dsKlientenliste1.UI.BezeichnungColumn.ColumnName, false);
                    }

                }

                this.DoLayout(this._TypeUI);

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.loadData: " + ex.ToString());
            }
        }
        public void loadDataDetailMedDaten(PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == rRezeptEintragMedDaten.IDMedDaten);
                PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

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
                rUINew.Beendigungsgrund = rMedizinischeDaten.Beendigungsgrund.Trim();
                rUINew.IDRezeptEintrag = this._IDRezeptEintragMedDatenWundePos;
                rUINew.IDMedDatenWundeKopf = rMedizinischeDaten.ID;
                rUINew.ID = rRezeptEintragMedDaten.ID;

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.loadDataDetailMedDaten: " + ex.ToString());
            }
        }
        public void loadDataDetailMedDaten2(PMDS.db.Entities.VO_MedizinischeDaten rVO_MedizinischeDaten, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.MedizinischeDaten> tMedizinischeDaten = db.MedizinischeDaten.Where(o => o.ID == rVO_MedizinischeDaten.IDMedizinischeDaten);
                PMDS.db.Entities.MedizinischeDaten rMedizinischeDaten = tMedizinischeDaten.First();

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
                rUINew.Beendigungsgrund = rMedizinischeDaten.Beendigungsgrund.Trim();
                rUINew.IDRezeptEintrag = this._IDRezeptEintragMedDatenWundePos;
                rUINew.IDMedDatenWundeKopf = rMedizinischeDaten.ID;
                rUINew.ID = rVO_MedizinischeDaten.ID;

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.loadDataDetailMedDaten: " + ex.ToString());
            }
        }
        public void loadDataDetailRezeptEintrag(PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db, bool IsWundeKopf)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.RezeptEintrag> tRezeptEintrag = db.RezeptEintrag.Where(o => o.ID == rRezeptEintragMedDaten.IDRezepteintrag);
                PMDS.db.Entities.RezeptEintrag rRezeptEintrag = tRezeptEintrag.First();

                if (this.PMDSBusinessUI2.abgesetzteAnzeigenJN(rRezeptEintrag, this.chkAbgesetzteAnzeigen.Checked, db))
                {
                    System.Linq.IQueryable<PMDS.db.Entities.Medikament> tMedikament = db.Medikament.Where(o => o.ID == rRezeptEintrag.IDMedikament);
                    PMDS.db.Entities.Medikament rMedikament = tMedikament.First();

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

                    if (this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten || this._TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                        rUINew.IDVerordnung = rRezeptEintragMedDaten.IDVerordnung.Value;
                        rUINew.IDMedDatenWundeKopf = rRezeptEintragMedDaten.IDVerordnung.Value;
                    }
                    else
                    {
                        if (!IsWundeKopf)
                        {
                            rUINew.IDMedDatenWundeKopf = rRezeptEintragMedDaten.IDMedDaten.Value;
                        }
                        else
                        {
                            rUINew.IDMedDatenWundeKopf = rRezeptEintragMedDaten.IDWundeKopf.Value;
                        }
                    }

                    rUINew.Herrichten = PMDS.DynReportsForms.MedikamentenBlattDataSource.orderByHerrichten(rRezeptEintrag.Herrichten);
                    rUINew.ID = rRezeptEintragMedDaten.ID;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.loadDataDetailRezeptEintrag: " + ex.ToString());
            }
        }
        public void loadDataWunden(PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten, dsKlientenliste.UIRow rUINew, PMDS.db.Entities.ERModellPMDSEntities db, PMDS.db.Entities.VO_Wunde rVO_Wunde)
        {
            try
            {
                System.Linq.IQueryable<PMDS.db.Entities.WundeKopf> tWundeKopf = null;
                PMDS.db.Entities.WundeKopf rWundeKopf = null;

                if (rRezeptEintragMedDaten == null)
                {
                    tWundeKopf = db.WundeKopf.Where(o => o.ID == rVO_Wunde.IDWundeKopf);
                    rWundeKopf = tWundeKopf.First();
                }
                else
                {
                    tWundeKopf = db.WundeKopf.Where(o => o.ID == rRezeptEintragMedDaten.IDWundeKopf);
                    rWundeKopf = tWundeKopf.First();
                }

                var tJoinWundeKopf = (from wk in db.WundeKopf
                                      join apx in db.AufenthaltPDx on wk.IDAufenthaltPDx equals apx.ID
                                      join pdx in db.PDX on apx.IDPDX equals pdx.ID
                                      where wk.ID == rWundeKopf.ID
                                      select new
                                      {
                                          PDXKlartext = pdx.Klartext,
                                          Lokalisierung = apx.Lokalisierung,
                                          LokalisierungSeite = apx.LokalisierungSeite,
                                          WKDatumErstellt = wk.DatumErstellt
                                      });

                string lstWundeTmp = "";
                foreach (var r in tJoinWundeKopf)
                {
                    string sTmpErstellt = "";
                    if (r.WKDatumErstellt != null)
                    {
                        sTmpErstellt = ", " + r.WKDatumErstellt.Value.ToString("dd.MM.yyyy") + "";
                    }
                    lstWundeTmp += "Wunde:" + r.PDXKlartext.Trim() + " (" + r.Lokalisierung.Trim() + ", " + r.LokalisierungSeite.Trim() + sTmpErstellt + ")" + "\r\n";
                }

                if (rUINew == null)
                {
                    rUINew = sqlManange1.getNewUI(ref this.dsKlientenliste1);
                }

                rUINew.Bezeichnung = lstWundeTmp.Trim();

                if (this._TypeUI == eTypeUI.VOToWunde)
                {
                    rUINew.IDVerordnung = this._IDRezeptEintragMedDatenWundePos;
                }
                else
                {
                    rUINew.IDRezeptEintrag = this._IDRezeptEintragMedDatenWundePos;
                }
                rUINew.IDMedDatenWundeKopf = rWundeKopf.ID;
                if (rRezeptEintragMedDaten == null)
                {
                    rUINew.ID = rVO_Wunde.ID;
                }
                else
                {
                    rUINew.ID = rRezeptEintragMedDaten.ID;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.loadDataWunden: " + ex.ToString());
            }
        }

        public void DoLayout(ucRezeptEintragMedDaten.eTypeUI TypeUI)
        {
            try
            {
                if (!DesignMode && ENV.AppRunning)
                {
                    qs2.core.vb.compLayout compLayout1 = new qs2.core.vb.compLayout();
                    compLayout1.initControl();
                    bool LayoutFound = false;

                    if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintrag2)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridMedDatenShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.RezeptEintragShowWundKopf)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridWundenShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.MedDaten2)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridRezepteintragShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.WundeKopf)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridRezepteintragWundeShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedikamente)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridVORezepteintragShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToMedDaten)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridVOMedDateShown";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                    else if (TypeUI == ucRezeptEintragMedDaten.eTypeUI.VOToWunde)
                    {
                        this.gridMedDatenRezepteintrag.Name = "gridVOWundeShow";
                        compLayout1.doLayoutGrid(this.gridMedDatenRezepteintrag, this.gridMedDatenRezepteintrag.Name.Trim(), null, ref LayoutFound, true, !PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("frmRezeptEintragMedDatenAdd.DoLayout: " + ex.ToString());
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
                throw new Exception("ucRezeptEintragMedDaten.validateData: " + ex.ToString());
            }
        }
        public bool saveDataxy()
        {
            try
            {
                throw new Exception("ucRezeptEintragMedDaten.saveData: Function saveData not activated!");
                //if (!this.validateData())
                //{
                //    return false;
                //}


                //return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.saveData: " + ex.ToString());
            }
        }

        public void addRow()
        {
            try
            {
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    if (this._TypeUI == eTypeUI.RezeptEintrag2 || this._TypeUI == eTypeUI.VOToMedikamente || this._TypeUI == eTypeUI.VOToMedDaten || this._TypeUI == eTypeUI.VOToWunde)
                    {
                        frmRezeptEintragMedDatenAdd2 frmRezeptEintragMedDatenAdd1 = new frmRezeptEintragMedDatenAdd2();
                        frmRezeptEintragMedDatenAdd1.initControl(this._IDRezeptEintragMedDatenWundePos, ENV.CurrentIDPatient, this._TypeUI);
                        frmRezeptEintragMedDatenAdd1.ShowDialog(this);
                        if (!frmRezeptEintragMedDatenAdd1.ucRezeptEintragMedDatenAdd1.abort)
                        {
                            this.abort = false;
                            this.loadData();
                        }
                    }
                    else if (this._TypeUI == eTypeUI.MedDaten2)
                    {
                        frmRezeptEintragMedDatenAdd2 frmRezeptEintragMedDatenAdd1 = new frmRezeptEintragMedDatenAdd2();
                        frmRezeptEintragMedDatenAdd1.initControl(this._IDRezeptEintragMedDatenWundePos, ENV.CurrentIDPatient, this._TypeUI);
                        frmRezeptEintragMedDatenAdd1.ShowDialog(this);
                        if (!frmRezeptEintragMedDatenAdd1.ucRezeptEintragMedDatenAdd1.abort)
                        {
                            this.abort = false;
                            this.loadData();
                        }
                    }
                    else if (this._TypeUI == eTypeUI.WundeKopf)
                    {
                        frmRezeptEintragMedDatenAdd2 frmRezeptEintragMedDatenAdd1 = new frmRezeptEintragMedDatenAdd2();
                        frmRezeptEintragMedDatenAdd1.initControl(this._IDRezeptEintragMedDatenWundePos, ENV.CurrentIDPatient, this._TypeUI);
                        frmRezeptEintragMedDatenAdd1.ShowDialog(this);
                        if (!frmRezeptEintragMedDatenAdd1.ucRezeptEintragMedDatenAdd1.abort)
                        {
                            this.abort = false;
                            this.loadData();
                        }
                    }
                    else if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                    {
                        frmRezeptEintragMedDatenAdd2 frmRezeptEintragMedDatenAdd1 = new frmRezeptEintragMedDatenAdd2();
                        frmRezeptEintragMedDatenAdd1.initControl(this._IDRezeptEintragMedDatenWundePos, ENV.CurrentIDPatient, this._TypeUI);
                        frmRezeptEintragMedDatenAdd1.ShowDialog(this);
                        if (!frmRezeptEintragMedDatenAdd1.ucRezeptEintragMedDatenAdd1.abort)
                        {
                            this.abort = false;
                            this.loadData();
                        }
                    }
                    else if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                    {
                        throw new Exception("addRow: for this._TypeUI == eTypeUI.RezeptEintragShowWundKopf not allowed!");
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.addRow: " + ex.ToString());
            }
        }
        public void delRow()
        {
            try
            {
                DialogResult res = DialogResult.Yes;
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Aktivität wirklich durchführen?", "", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }

                if (res == DialogResult.Yes)
                {
                    UltraGridRow[] arrSelected = PMDS.GUI.UltraGridTools.GetAllRowsFromGroupedUltraGrid(this.gridMedDatenRezepteintrag, true);
                    if (arrSelected.Length > 0)
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            int anzDel = 0;
                            foreach (UltraGridRow rToDel in arrSelected)
                            {
                                dsKlientenliste.UIRow r2 = (dsKlientenliste.UIRow)((System.Data.DataRowView)rToDel.ListObject).Row;
                                
                                string lstMedDaten = "";
                                int NumberMedDaten = 0;
                                string lstWunden = "";
                                int NumberWunden = 0;

                                Guid IDRezeptEintragTmp = r2.IDRezeptEintrag;
                                Guid IDMedDatenWundeKopfTmp = r2.IDMedDatenWundeKopf;

                                if (this._TypeUI == eTypeUI.VOToMedDaten)
                                {
                                    this.sqlManange1.deleteVO_MedizinischeDaten(r2.ID);
                                }
                                else if (this._TypeUI == eTypeUI.VOToWunde)
                                {
                                    this.sqlManange1.deleteVO_Wunde(r2.ID);
                                }
                                else
                                {
                                    this.sqlManange1.deleteRezeptEintragMedDaten(r2.ID);
                                }

                                if (this._TypeUI != eTypeUI.VOToMedikamente && this._TypeUI != eTypeUI.VOToMedDaten  && this._TypeUI != eTypeUI.VOToWunde)
                                {
                                    this.b2.saveAnzeigeGridRezeptEintrag(IDRezeptEintragTmp, db, ref lstMedDaten, ref NumberMedDaten, ref lstWunden, ref NumberWunden);
                                    db.SaveChanges();

                                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten2 = db.RezeptEintragMedDaten.Where(o => o.IDRezepteintrag == IDRezeptEintragTmp);
                                    if (tRezeptEintragMedDaten2.Count() > 0)
                                    {
                                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten2)
                                        {
                                            if (rRezeptEintragMedDaten2.IDMedDaten != null)
                                            {
                                                int NumberRezepteinträge2 = 0;
                                                string lstRezepteinträge2 = "";
                                                this.b2.saveAnzeigeGridMedDaten(rRezeptEintragMedDaten2.IDMedDaten.Value, db, ref lstRezepteinträge2, ref NumberRezepteinträge2);
                                            }
                                        }
                                        db.SaveChanges();
                                    }
                                }

                                if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                                {
                                    string lstMedDaten3 = "";
                                    int NumberMedDaten3 = 0;
                                    string lstWunden3 = "";
                                    int NumberWunden3 = 0;
                                    this.b2.saveAnzeigeGridRezeptEintrag(IDRezeptEintragTmp, db, ref lstMedDaten3, ref NumberMedDaten3, ref lstWunden3, ref NumberWunden3, true);
                                    db.SaveChanges();
                                }

                                string lstRezepteinträge = "";
                                int NumberRezepteinträge = 0;

                                if (this._TypeUI == eTypeUI.MedDaten2)
                                {
                                    this.b2.saveAnzeigeGridMedDaten(IDMedDatenWundeKopfTmp, db, ref lstRezepteinträge, ref NumberRezepteinträge);
                                    db.SaveChanges();

                                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == IDMedDatenWundeKopfTmp && o.IDRezepteintrag != null && o.IDVerordnung == null);
                                    if (tRezeptEintragMedDaten.Count() > 0)
                                    {
                                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                                        {
                                            string lstMedDaten3 = "";
                                            int NumberMedDaten3 = 0;
                                            string lstWunden3 = "";
                                            int NumberWunden3 = 0;
                                            this.b2.saveAnzeigeGridRezeptEintrag(rRezeptEintragMedDaten2.IDRezepteintrag.Value, db, ref lstMedDaten3, ref NumberMedDaten3, ref lstWunden3, ref NumberWunden3);
                                        }
                                        db.SaveChanges();
                                    }

                                    anzDel += 1;
                                }
                                else if(this._TypeUI == eTypeUI.WundeKopf)
                                {
                                    System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.IDMedDaten == IDMedDatenWundeKopfTmp && o.IDRezepteintrag != null && o.IDVerordnung == null);
                                    if (tRezeptEintragMedDaten.Count() > 0)
                                    {
                                        foreach (PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten2 in tRezeptEintragMedDaten)
                                        {
                                            string lstMedDaten3 = "";
                                            int NumberMedDaten3 = 0;
                                            string lstWunden3 = "";
                                            int NumberWunden3 = 0;
                                            this.b2.saveAnzeigeGridRezeptEintrag(rRezeptEintragMedDaten2.IDRezepteintrag.Value, db, ref lstMedDaten3, ref NumberMedDaten3, ref lstWunden3, ref NumberWunden3);
                                        }
                                        db.SaveChanges();
                                    }
                                    anzDel += 1;
                                }
                            }

                            this.loadData();
                            this.abort = false;
                        }
                        //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(anzDel.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(". Zeile/n gelöscht!"), "", MessageBoxButtons.OK, true);
                    }
                }
         
            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.delRow: " + ex.ToString());
            }
        }


        public void OpenForm(Global.db.ERSystem.dsKlientenliste.UIRow rSelRow)
        {
            try
            {
                if (this._TypeUI == eTypeUI.RezeptEintrag2 || this._TypeUI == eTypeUI.VOToMedDaten)
                {
                    if (this.PMDSBusinessUI2.OpenFormMedDaten(rSelRow.IDMedDatenWundeKopf))
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.ID == rSelRow.ID);
                            PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten = tRezeptEintragMedDaten.First();

                            this.loadDataDetailMedDaten(rRezeptEintragMedDaten, rSelRow, db);
                        }
                    }
                }
                else if (this._TypeUI == eTypeUI.MedDaten2 || this._TypeUI == eTypeUI.VOToMedikamente)
                {
                    if (this.PMDSBusinessUI2.OpenFormRezeptEintrag(rSelRow.IDRezeptEintrag))
                    {
                        using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                        {
                            System.Linq.IQueryable<PMDS.db.Entities.RezeptEintragMedDaten> tRezeptEintragMedDaten = db.RezeptEintragMedDaten.Where(o => o.ID == rSelRow.ID);
                            PMDS.db.Entities.RezeptEintragMedDaten rRezeptEintragMedDaten = tRezeptEintragMedDaten.First();

                            this.loadDataDetailRezeptEintrag(rRezeptEintragMedDaten, rSelRow, db, (this._TypeUI == eTypeUI.WundeKopf ? true : false));
                        }
                    }
                }
                else if (this._TypeUI == eTypeUI.RezeptEintragShowWundKopf)
                {
                    //throw new Exception("OpenForm: for this._TypeUI == eTypeUI.RezeptEintragShowWundKopf not allowed!");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucRezeptEintragMedDaten.OpenForm: " + ex.ToString());
            }
        }


        private void gridMedDatenRezepteintrag_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.ToString().Trim().ToLower().Equals(("xyxy").Trim().ToLower()))
                {
                    e.Cell.Activation = Activation.NoEdit;
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
                    UltraGridRow rGridSel = null;
                    Global.db.ERSystem.dsKlientenliste.UIRow rSelRow = this.PMDSBusinessUI2.getSelectedRow(false, ref rGridSel, this.gridMedDatenRezepteintrag);
                    if (rSelRow != null)
                    {

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
        


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.addRow();

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
                this.delRow();

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //if (this.saveData())
                //{
                //    this.abort = false;
                //    this.mainWindow.Close();
                //}

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

        private void btnOK_Click(object sender, EventArgs e)
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

        private void btnAddMedikament_Click(object sender, EventArgs e)
        {
            try 
            {
                this.Cursor = Cursors.WaitCursor;

                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
                {
                    PMDS.db.Entities.Aufenthalt rAufenthalt = this.b.getAktuellerAufenthaltPatient(ENV.CurrentIDPatient, false, db);

                    dsRezeptEintrag.RezeptEintragDataTable tRezeptEintrag = new dsRezeptEintrag.RezeptEintragDataTable();
                    dsRezeptEintrag.RezeptEintragRow row = tRezeptEintrag.NewRezeptEintragRow();
                    PMDS.BusinessLogic.Rezept.InitRezeptEintrag(row, rAufenthalt.ID);

                    frmRezeptEintrag frm = new frmRezeptEintrag(row, BearbeitungsModus.neu);
                    DialogResult res = frm.ShowDialog();

                    if (res == DialogResult.OK)
                    {
                        tRezeptEintrag.Rows.Add(row);
                        Rezept rez = new Rezept();
                        foreach (dsRezeptEintrag.RezeptEintragRow r in tRezeptEintrag.Rows)
                            if (r.RowState == DataRowState.Added)
                                r.DosierungASString = PMDS.BusinessLogic.Tools.ToStringFromRezepteintragRow(r);

                        rez.Update(tRezeptEintrag);
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
