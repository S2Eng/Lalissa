//----------------------------------------------------------------------------------------------
//  Erstellt am:	24.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTabControl;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.PflegePlan;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.GUI
{
    public partial class ucPdx2 : QS2.Desktop.ControlManagment.BaseControl
    {
        public event ZuordnungUpdateDelegate ZuordnungChanged;
        private PDXPflegemodelle _pflegemodelle;
        private bool _ContentChanged = false;
        private PDx _PDx;					// PDx Zugriff
        private Katalog _Katalog;
        private Guid _IDPdx;
        private String _PdxName;
        private bool _addASZMToPdx = false; // wenn aus dem ucASZMSearchSelector gestartet --> true
        private Guid _aktuellPDx;
        private PDx _Pdx = new PDx();
        private dsAbteilung.AbteilungDataTable _Table;
        private List<ucPdxVerwaltung> _ListPdxVerwaltungControls = new List<ucPdxVerwaltung>();








        public ucPdx2()
        {
            InitializeComponent();
            UpdateLegend();
            tabPDX.Tabs[0].Tag = ucPdxVerwAlgemein;
            _ListPdxVerwaltungControls.Add(ucPdxVerwAlgemein);
        }

        public bool CONTENT_CHANGED
        {
            get
            {
                return _ContentChanged;
            }
        }

        private void UpdateLegend()
        {
            legA.COLOR = ENVCOLOR.GetColorForGroup('A');
            legS.COLOR = ENVCOLOR.GetColorForGroup('S');
            legZ.COLOR = ENVCOLOR.GetColorForGroup('Z');
            legM.COLOR = ENVCOLOR.GetColorForGroup('M');
        }

        public Guid IDPDX
        {
            get
            {
                return _IDPdx;
            }
            set
            {
                _IDPdx = value;
            }
        }

        public String PDXNAME
        {
            get
            {
                return _PdxName;
            }
            set
            {
                _PdxName = value;
            }
        }

        public bool ADDASZMTOPDX
        {
            get
            {
                return _addASZMToPdx;
            }
            set
            {
                _addASZMToPdx = value;
            }
        }

        private void ucPdx2_Load(object sender, EventArgs e)
        {
            try
            {
                if (ENV.AppRunning)
                {
                    this.Show();												// Sonst wird Cursor nicht dargestellt
                    this.Cursor = Cursors.WaitCursor;
                    _PDx = new PDx();
                    _Katalog = _PDx.KATALOGE['M'];//Maßnahmen
                    _pflegemodelle = new PDXPflegemodelle();

                    this.loadTree();

                    if (_addASZMToPdx == true)
                        AddASZMToIdPdx();

                    Abteilung a = new Abteilung();
                    _Table = a.ABTEILUNGLISTE;

                    ucPdxVerwAlgemein.IDAbteilung = Guid.Empty;
                    ucPdxVerwAlgemein.KATALOG = _Katalog;
                    AddAbteilungenTabs();
                }
            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void loadTree()
        {
            try
            {
                cbPDX.Items.Clear();
                System.Collections.Generic.List<dsPDx.PDXRow> lstToDelete = new List<dsPDx.PDXRow>();
                foreach (dsPDx.PDXRow r in _Pdx.PDXEINTRAEGE)
                {
                    bool bShow = false;
                    int _TypeActivePdxShow = System.Convert.ToInt32(this.optActiveJN.Value);
                    if (_TypeActivePdxShow == 0)
                    {
                        if (!r.EntferntJN)
                        {
                            lstToDelete.Add(r);
                        }
                        else
                        {
                            bShow = true;
                        }
                    }
                    else if (_TypeActivePdxShow == 1)
                    {
                        if (r.EntferntJN)
                        {
                            lstToDelete.Add(r);
                        }
                        else
                        {
                            bShow = true;
                        }
                    }
                    else if (_TypeActivePdxShow == -1)
                    {
                        bShow = true;
                    }
                    else
                    {
                        throw new Exception("LoadTree: this._TypeActivePdxShow  '" + _TypeActivePdxShow.ToString() + "' not allowed!");
                    }

                    if (bShow)
                        cbPDX.Items.Add(r.ID, r.Klartext);
                    else
                        lstToDelete.Add(r);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("loadTree: " + ex.ToString());
            }
        }

        private void AddAbteilungenTabs()
        {
            Infragistics.Win.Appearance appearance = new Infragistics.Win.Appearance();
            appearance.FontData.BoldAsString = "True";
            //appearance.ForeColor = System.Drawing.Color.CornflowerBlue;
            Infragistics.Win.UltraWinTabControl.UltraTabPageControl tabPage;
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab;

            ucPdxVerwaltung uc;

            foreach (dsAbteilung.AbteilungRow r in _Table)
            {
                if (r.ID == Guid.Empty)
                    continue;

                tabPage = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
                uc = new ucPdxVerwaltung();
                tabPDX.Controls.Add(tabPage);

                ultraTab = tabPage.Tab;
                ultraTab.ActiveAppearance = appearance;
                ultraTab.Key = r.Bezeichnung;
                ultraTab.TabPage = tabPage;
                ultraTab.Tag = uc;
                ultraTab.Text = r.Bezeichnung;
                ultraTab.Visible = false;
                
                // 
                // tabPage
                // 
                tabPage.Controls.Add(uc);
                tabPage.Location = new System.Drawing.Point(1, 23);
                tabPage.Name = r.Bezeichnung;
                tabPage.Size = new System.Drawing.Size(1012, 577);

                // 
                // ucPdxVerwaltung
                //
                uc.Dock = System.Windows.Forms.DockStyle.Fill;
                uc.Location = new System.Drawing.Point(0, 0);
                uc.Name = "ucPdxVerw" + r.ID.ToString();
                uc.Size = new System.Drawing.Size(1012, 577);
                uc.TabIndex = 0;
                uc.IDAbteilung = r.ID;
                uc.KATALOG = _Katalog;
                uc.ZuordnungChanged += new ZuordnungUpdateDelegate(ucPdxVerwaltung_ZuordnungChanged);
                uc.ASZMtoPDx += new ASZMtoPDxDelegate(ucPdxVerwaltung_ASZMtoPDx);
                uc.ValueChanged += new EventHandler(ucPdxVerwaltung_ValueChanged);
                _ListPdxVerwaltungControls.Add(uc);
            }
        }

        private PDXDef ACTIVE_PDXDEF
        {
            get
            {
                    if (cbPDX.SelectedItem != null)
                    {
                        PDXDef def = new PDXDef();
                        dsPDx.PDXRow r = _PDx.ReadOne((Guid)cbPDX.SelectedItem.DataValue);
                        def.ID = (Guid)(r.ID);
                        def.Klartext = r.Klartext;
                        def.Code = r.Code;
                        def.Definition = r.Definition;
                        def.EntferntJN = r.EntferntJN;
                        def.ThematischeID = r.ThematischeID;
                        //if (!r.IsGruppeNull())
                        def.PDXGruppe = (PDXGruppe)r.Gruppe;
                        def.PDXLokalisierungsTyp = (PDxLokalisierungsTypen)r.LokalisierungsTyp;

                        //Liste alle zugeordnete Pflegemodelle
                        _pflegemodelle.ReadOneByPDX(def.ID);
                        def.PDXPflegemodelle = _pflegemodelle.GetPflegemodelleToPDX();

                        //Neu nach 15.09.2008 MDA
                        def.WundeJN = r.WundeJN;
                        def.PDXKuerzel = r.PDXKuerzel;
                        return def;
                    }
                    else return null;
            }
        }

        public void Save()
        {
            ProcessSave();
        }

        private void ProcessSave()
        {
            
            _aktuellPDx = (Guid)cbPDX.SelectedItem.DataValue;

            ArrayList al;
            foreach (ucPdxVerwaltung uc in _ListPdxVerwaltungControls)
            {
                uc.Save();
                al = new ArrayList();

                foreach (dsPDxEintrag.PDXEintragRow r in uc.PDXEintrag)
                {
                    if(r.RowState != DataRowState.Deleted)
                        al.Add(r.IDEintrag);
                }

                _PDx.UpdatePDXEintragZuordnung((Guid[])al.ToArray(typeof(Guid)), uc.IDAbteilung, _aktuellPDx);
            }

            
            _ContentChanged = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;

            RefreshControls();
        }

        public void RefreshcbPDX()
        {
            cbPDX.Items.Clear();

            foreach (dsPDx.PDXRow r in _Pdx.PDXEINTRAEGE)
            {
                cbPDX.Items.Add(r.ID, r.Klartext);
            }
        }

        private void AddASZMToIdPdx()
        {
            _addASZMToPdx = true;
            Pdxbearbeiten("byPflegeplan");
        }

        private void Pdxbearbeiten(String origin)
        {

            if (origin.Equals("byPflegeplan")) // PdxVerwaltung wird über Pflegeplan aufgerufen
            {
                foreach (ValueListItem it in cbPDX.Items)
                {
                    if (it.DataValue.Equals(IDPDX))
                    {
                        cbPDX.SelectedItem = it;
                        break;
                    }
                }
            }
        }

        private void cbPDX_ValueChanged(object sender, EventArgs e)
        {
            PDxSelected();
        }

        private void PDxSelected()
        {
            //Änderung nach 25.09.2008 MDA
            if (cbPDX.SelectedItem != null && (Guid)cbPDX.SelectedItem.DataValue == _aktuellPDx)
                return;

            if (btnSave.Enabled == true)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNoCancel,
                                                                                            MessageBoxIcon.Question, true);          
                if (res == DialogResult.No)
                    SetPDxDefForAbteilungen();

                if (res == DialogResult.Yes)
                {
                    UltraTab tab = tabPDX.ActiveTab;
                    //Änderungen nach 27.08.2008 MDA
                    ucPdxVerwaltung uc = (ucPdxVerwaltung)tab.Tag;
                    if (uc.ValidateFields())
                        ProcessSave();
                    else
                    {
                        cbPDX.Value = _aktuellPDx;
                        return;
                    }
                }

               if (res == DialogResult.Cancel)
               {
                   cbPDX.Value = _aktuellPDx;
                   return;
               }
            }

            _aktuellPDx = cbPDX.SelectedItem != null ? (Guid)cbPDX.SelectedItem.DataValue : Guid.Empty;
            RefreshControls();
        }

        private void RefreshControls()
        {
            _ContentChanged = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;


            _PDx = new PDx();
            _Katalog = _PDx.KATALOGE['M'];//Maßnahmen

            if (cbPDX.SelectedItem == null)
            {
                ucPdxVerwAlgemein.Def = ACTIVE_PDXDEF;
                SetPDxDefForAbteilungen();
                
                btnDel.Visible = false;
                btnUpdate.Visible = false;
                tabPDX.Visible = false;
                btnAddASZM.Visible = false;
                btnDelASZM.Visible = false;
            }
            else
            {
                tabPDX.Visible = true;
                ucPdxVerwAlgemein.Def = ACTIVE_PDXDEF;
                SetPDxDefForAbteilungen();
                
                btnDel.Visible = true;
                btnUpdate.Visible = true;
            }

            //Nach löschen ist cbPDX.SelectedItem null
            if (cbPDX.SelectedItem != null)
                _aktuellPDx = (Guid)cbPDX.SelectedItem.DataValue;
        }

        private void SetPDxDefForAbteilungen()
        {
            bool showBtnASZM = false;
            UltraTab tab;
            foreach (ucPdxVerwaltung uc in _ListPdxVerwaltungControls)
            {
                foreach (dsAbteilung.AbteilungRow r in _Table)
                {
                    if (uc.IDAbteilung == r.ID)
                    {
                        uc.Def = ACTIVE_PDXDEF;
                        tab = GetTab(r.ID);

                        if(uc != ucPdxVerwAlgemein)
                            tab.Visible = (uc.PDXEintrag.Count > 0);

                        if (!showBtnASZM && tab.Visible)
                            showBtnASZM = true;

                        break;
                    }
                }
            }
 
            if (showBtnASZM)
            {
                btnAddASZM.Visible = true;
                btnDelASZM.Visible = true;
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!_ContentChanged)
                return;

            UltraTab tab = tabPDX.ActiveTab;
            //Änderungen nach 27.08.2008 MDA
            ucPdxVerwaltung uc = (ucPdxVerwaltung)tab.Tag;
            if (uc.ValidateFields())
            {
                ProcessSave();
                Zuordnungneu();
            }
        }

        private void Zuordnungneu()
        {
            if (ZuordnungChanged != null)
                ZuordnungChanged();
        }

        private void cbPDX_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (e.Button.Key == "Search")
            {
                frmPicker picker = new frmPicker(_PDx.PDXEINTRAEGE, "Klartext", "ID", System.Convert.ToInt32(this.optActiveJN.Value), true);
                picker.Text = QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegediagnose suchen");
                if (picker.ShowDialog() == DialogResult.OK)
                {
                    cbPDX.Value = picker.Value;  // Gernot%%
                }
            }
            
            if (e.Button.Key == "btnDel")
            {
                ProcessDelete();
            }

            if (e.Button.Key == "btnNew")
            {
                ProcessAddNew();
            }
        }

        private void ProcessDelete()
        {
            if (cbPDX.SelectedItem == null)
                return;


            if (QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEPDX", cbPDX.SelectedItem.DisplayText), ENV.String("DIALOGTITLE_DELETEPDX"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true) != DialogResult.Yes)
                return;

            //Prüfen ob PDX in Anamnesen verwendet wird.
            PDXAnamnese pdxAnamnese = new PDXAnamnese();
            pdxAnamnese.Read();

            if (pdxAnamnese.FindPDX(ACTIVE_PDXDEF.ID))
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Die PDx \"") + ACTIVE_PDXDEF.Klartext + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" kann nicht gelöscht werden, wurde in Pflegeanamnesen verwendet."), true);
            }
            else
            {

                _PDx.PdxToDB(ACTIVE_PDXDEF, true);
                cbPDX.Items.Remove(cbPDX.SelectedItem);
                PDxSelected();
                btnUndo.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        private void btnUndo_Click(object sender, System.EventArgs e)
        {
            RefreshControls();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditAvtivePDX();
        }

        private void EditAvtivePDX()
        {
            if (cbPDX.SelectedItem == null)
                return;

            PDXDef def = new PDXDef();
            def = ACTIVE_PDXDEF;

            //mit frmEditPDx1 können Pflegemodelle zugefügt werden
            frmEditPDx1 frm = new frmEditPDx1(false, ref def);
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            _PDx.PdxToDB(def);

            //Liste der zugeordneten Pflegemodelle speichern
            _pflegemodelle.PDXPflegemodelleToDB(def);
        }

        private void ProcessAddNew()
        {
            PDXDef def = new PDXDef();
            def.ID = Guid.NewGuid();
            
            //mit frmEditPDx1 können Pflegemodelle zugefügt werden
            frmEditPDx1 frm = new frmEditPDx1(true, ref def);
            frm.Text = "Neue PDX erfassen";
            DialogResult res = frm.ShowDialog();
            if (res != DialogResult.OK)
                return;

            // Neuen EIntrag in die DB speichern
            _PDx.PdxToDB(def);

            //Liste der zugeordneten Pflegemodelle speichern
            _pflegemodelle.PDXPflegemodelleToDB(def);

            // Neuer comboEintrag
            cbPDX.Items.Add(def.ID, def.Klartext);

            foreach (ValueListItem i in cbPDX.Items)
                if (i.DataValue.Equals(def.ID))
                    cbPDX.Value = def.ID;
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNoCancel,
                                                                                            MessageBoxIcon.Question, true);           

                if (res == DialogResult.Yes)
                    ProcessSave();
            }
        }

        private void AddASZMToAbteilung()
        {
            frmASZMZuordnung frm = new frmASZMZuordnung();
            frm.IDAbteilungVon = ((ucPdxVerwaltung)tabPDX.SelectedTab.Tag).IDAbteilung;
            frm.Bezeichnung = tabPDX.SelectedTab.Text;
            dsAbteilung.AbteilungDataTable table = new dsAbteilung.AbteilungDataTable();
            dsAbteilung.AbteilungRow row;
            foreach (UltraTab tab in tabPDX.Tabs)
            {
                foreach (dsAbteilung.AbteilungRow r in _Table)
                {
                    if (tab.Tag is ucPdxVerwaltung && ((ucPdxVerwaltung)tab.Tag).IDAbteilung == r.ID && !tab.Visible)
                    {
                        row = table.NewAbteilungRow();
                        row.ItemArray = r.ItemArray;
                        table.AddAbteilungRow(row);
                        break;
                    }
                }
            }

            frm.Abteilungen = table;

            DialogResult res = frm.ShowDialog();

            if (res == DialogResult.OK)
            {
                ucPdxVerwaltung ucVon = (ucPdxVerwaltung)tabPDX.SelectedTab.Tag;
                UltraTab tab = GetTab(frm.IDAbteilungFuer);
                if (tab == null)
                    return;

                ucPdxVerwaltung ucNach = (ucPdxVerwaltung)tab.Tag;
                tab.Visible = true;
                tabPDX.SelectedTab = tab;

                if (!frm.LEERE_ASZMZuordnung)
                {
                    CopyPDXEintrag(ucVon, ucNach);
                    btnUndo.Enabled = true;
                    btnSave.Enabled = true;
                    _ContentChanged = true;
                }
            }

        }

        private void CopyPDXEintrag(ucPdxVerwaltung von, ucPdxVerwaltung nach)
        {
            nach.Def = von.Def;

            dsPDxEintrag.PDXEintragDataTable table = new dsPDxEintrag.PDXEintragDataTable();
            dsPDxEintrag.PDXEintragRow row;
            foreach (dsPDxEintrag.PDXEintragRow r in von.PDXEintrag)
            {
                row = table.NewPDXEintragRow();
                row.ItemArray = r.ItemArray;
                row.IDAbteilung = nach.IDAbteilung;
                table.AddPDXEintragRow(row);
            }

            nach.PDXEintrag = table;
        }

        private UltraTab GetTab(Guid idAbteilung)
        {
            foreach (UltraTab tab in tabPDX.Tabs)
            {
                if (tab.Tag is ucPdxVerwaltung && ((ucPdxVerwaltung)tab.Tag).IDAbteilung == idAbteilung)
                    return tab;
            }

            return null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcessAddNew();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProcessDelete();
        }


        private void btnAddASZM_Click(object sender, EventArgs e)
        {
            AddASZMToAbteilung();
        }

        private void btnDelASZM_Click(object sender, EventArgs e)
        {
            UltraTab tab = tabPDX.SelectedTab;

            DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Zuordnung für \"") + tab.Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" wirklich löschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("ASZM Zuordnung löschen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);

            if (res == DialogResult.No)
                return;
            
            ucPdxVerwaltung uc = (ucPdxVerwaltung)tab.Tag;
            dsPDxEintrag.PDXEintragDataTable table = uc.PDXEintrag;
            
            table.Clear();
            uc.PDXEintrag = table; //Liste im TreeView aktualisieren
            
            if(tab.Key != "AlleAbteilungen")//Tab Alle Abteilung immer anzeigen
                tab.Visible = false;
            tabPDX.SelectedTab = tabPDX.Tabs[0];
            _ContentChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void ucPdxVerwaltung_ZuordnungChanged()
        {
            _ContentChanged = true;
            btnUndo.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void ucPdxVerwaltung_ASZMtoPDx(Guid IDPdx, Guid IDEintrag, EintragGruppe gruppe, bool demStandardHinzufuegen, Guid[] IDAbteilungen)
        {
            ucPdxVerwaltung uc;
            foreach (Guid id in IDAbteilungen)
            {
                ((ucPdxVerwaltung)tabPDX.ActiveTab.Tag).AddASZMtoPDx(IDPdx, IDEintrag);
                foreach (UltraTab tab in tabPDX.Tabs)
                {
                    if (tab == tabPDX.ActiveTab)
                        continue;
                    uc = (ucPdxVerwaltung)tab.Tag;
                    if (uc.IDAbteilung == id)
                    {
                        uc.AddASZMtoPDx(IDPdx, IDEintrag);
                        tab.Visible = true;
                        break;
                    }
                }
            }
        }

        private void ucPdxVerwaltung_ValueChanged(object sender, EventArgs e)
        {
            ucPdxVerwaltung_ZuordnungChanged();
        }

        private void tabPDX_ActiveTabChanging(object sender, ActiveTabChangingEventArgs e)
        {
            UltraTab tab = tabPDX.ActiveTab;
            if (tab != null)
            {
                //Änderungen nach 27.08.2008 MDA
                ucPdxVerwaltung uc = (ucPdxVerwaltung)tab.Tag;
                if (uc.ValidateFields())
                    uc.AcceptChanges();
                else
                    e.Cancel = true;
            }

        }

        private void tabPDX_ActiveTabChanged(object sender, ActiveTabChangedEventArgs e)
        {
            UltraTab tab = tabPDX.ActiveTab;

            ((ucPdxVerwaltung)tab.Tag).RefreshGUI();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditAvtivePDX();
        }

        private void optActiveJN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.optActiveJN.Focused)
                {
                    this.loadTree();
                }

            }
            catch (Exception ex)
            {
                ENV.HandleException(ex);
            }
        }
    }
}
