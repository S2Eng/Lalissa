//MDA 10.04.2007
//Änderungen: Die Liste der Anamnesen wird in ein ComboBox Statt TabControl angezeigt
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinTabControl;

using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using PMDS.Data.Patient;
using PMDS.GUI.BaseControls;
using Infragistics.Win;
using System.IO;
using PMDS.Global.db.Global;
using PMDS.DB;
using System.Linq;
using System.Linq.Expressions;




namespace PMDS.GUI
{

    public enum Modus
    {
        Anlegen = 0,
        Bearbeiten
    }
    public delegate void DataChangedDelegate(bool isDataChanged);
    


    public partial class ucDatenErhebung : QS2.Desktop.ControlManagment.BaseControl, IPMDSGUIObject
    {
        private bool _bForceRefresh;
        private bool _ContentChanged;
        private ArrayList _aAssenementMenu = new ArrayList();
        private ucClickableImages _clickableimages;

        private bool mnuIsLoaded;

        public bool IsExternControl = false;
        public System.Collections.Generic.List<string> lstFormulare = new List<string>();
        public System.Collections.Generic.List<ucClickableImage> lstCounterClickableImages = new List<ucClickableImage>();

        public bool IsInitialized = false;
        public ucNotfall mainWindowNotfall = null;
        public PMDS.GUI.Datenerhebung.ucDatenErhebungExtern mainWindowDatenerhebnungExtern = null;

        public ucAnamneseOrem ucAnamneseOrem2 = null;
        public bool IsInitializedOrem = false;

        public ucAnamneseKrohwinkel ucAnamneseKrohwinkel2 = null;
        public bool IsInitializedKrohwinkel = false;

        public PMDS.GUI.ucAnamnesePOP ucAnamnesePOP2 = null;
        public bool IsInitializedPOP = false;

        public ucAnamneseBase ucAnamneseBasePanelLastSelected = null;

        public static bool AssesstmensHasChanged = false;
        public int FormulareCountedLast = -1;
        public PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();

        public ucDatenErhebung()
        {
            InitializeComponent();
            ENV.ENVPatientIDChanged += new ENVPatientIDChangedDelegate(ENV_ENVPatientIDChanged);
            this.ucAnamneseBiografie1.Dock = DockStyle.Fill;
        }

        public void ENV_ENVPatientIDChanged(Guid IDPatient, eCurrentPatientChange typ, bool refreshPicker, bool clickGridTermine)
        {
            AskForSave();
            if (IDPatient != System.Guid.Empty && this.Visible)
            {
                _bForceRefresh = true;
                this.loadMainSite();
            }
        }

        private void RefreshAllAnamnesen()
        {
            ucAnamneseBase control;

            foreach (Control c in pnlPflegeAnamnese.Controls)
            {
                if (c is ucAnamneseBase)
                {
                    control = (ucAnamneseBase)c;

                    if (IsPflegeModellVisible(control.Modell))
                        control.IDPatient = ENV.CurrentIDPatient;
                }
            }
        }

        private bool IsPflegeModellVisible(PflegeModelle modell)
        {

            bool visible = false;
            foreach (PflegeModelle pfM in ENV.PflegeModell)
            {
                if (pfM == modell)
                {
                    visible = true;
                    break;
                }
            }

            return visible;
        }

        private bool ISAssessementChanged()
        {
            foreach (Control c in pnlPflegeAnamnese.Controls)
            {
                if (c is ucAssessement)
                {
                    ucAssessement uc = (ucAssessement)c;

                    if (uc.ISFORMULARTOSAVE)
                        return true;
                }
            }

            return false;
        }

        private void ResetAssessmentSave()
        {
            foreach (Control c in pnlPflegeAnamnese.Controls)
            {
                if (c is ucAssessement)
                {
                    ucAssessement uc = (ucAssessement)c;
                    uc.ProcessUndo();
                }
            }

        }

        private void ProcessSave(bool save)
        {
            foreach (Control c in pnlPflegeAnamnese.Controls)
            {

                if (!c.Visible)
                    continue;
                if (c is ucAnamneseBase && !(c is ucAnamneseBiografie))
                {
                    if (((ucAnamneseBase)c).ISTOSAVE)
                    {
                        if (save)
                            ((ucAnamneseBase)c).Save();
                        else
                            ((ucAnamneseBase)c).Undo();
                    }
                }
                else if (c is ucAssessement && ((ucAssessement)c).ISFORMULARTOSAVE)
                {
                    if (save)
                        ((ucAssessement)c).ProcessSave(true);
                }
                else if (c is ucAnamneseBiografie)
                {
                    if (save)
                        ucAnamneseBiografie1.Save();
                }
            }

            _ContentChanged = false;
        }

        private void AskForSave()
        {
            if (_ContentChanged || ISAssessementChanged() || ucAnamneseBiografie1.ISTOSAVE)
            {
                if (PMDS.Global.historie.HistorieOn)
                {
                    ProcessSave(false);
                }
                else
                {
                    DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"),
                                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"),
                                                                                            MessageBoxButtons.YesNo,
                                                                                            MessageBoxIcon.Question, true);

                    if (res == DialogResult.Yes)
                        ProcessSave(true);

                    else if (res == DialogResult.No)
                        ProcessSave(false);
                }
            }
            _ContentChanged = false;
            ucAnamneseBiografie1.ISTOSAVE = false;

            ResetAssessmentSave();
        }

        #region IPMDSGUIObject Members


        public void ExternSiteMapEventHandler(SiteEvents e, ref bool used)
        {

        }

        public Control CONTROL
        {
            get { return this; }
        }

        public void Undo()
        {

        }

        public bool Save()
        {
            return true;		
        }

        public string AREA
        {
            get { return ENV.String("GUI_AREA_SITEMAP_START"); }
        }

        private IPMDSMenuFramework _framework;

        public IPMDSMenuFramework FRAMEWORK
        {
            get { return _framework; }
            set { _framework = value; }
        }

        public void AttachFramework()
        {
            try
            {
                if (ENV.CurrentIDPatient != null && !this.IsExternControl)
                {
                    _framework.HEADER.action(false);
                    _framework.HEADER.ShowOnlyHeader(true);
                    ENV.UserLoggedOn += new EventHandler(ENV_UserLoggedOn);

                    //if (ENV.CurrentIDPatient  != System.Guid.Empty && this.Visible && ENV.AnsichtsModus == TerminlisteAnsichtsmodi .Bereichsansicht ) 
                    //            this.loadMainSite();
                }

            }
            catch (Exception ex)
            {
                if (!this.IsExternControl)
                {
                    _framework.HEADER.ShowControlAndHeader(true);
                }
                ENV.HandleException(ex);
            }
            finally
            {
                if (!this.IsExternControl)
                {
                    _framework.HEADER.action(true);
                }
            }
        }

        public void loadMainSite()
        {
            try
            {
                if (_bForceRefresh)
                {
                    lstCounterClickableImages.Clear();

                    if (this.IsExternControl)
                    {
                        if (this.mainWindowNotfall != null)
                        {
                            this.mainWindowNotfall.SetUIDatenerhebung(false);
                        }
                        if (this.mainWindowDatenerhebnungExtern != null)
                        {
                        }
                    }
                    this.UpdateActions();
                    this.loadAuswahl();
                    this.RefreshAllAnamnesen();

                    this.ucAnamneseBiografie1.ucBiographie1.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                    if (cmbErhebung.Items.Count >= 1) this.cmbErhebung.SelectedItem = cmbErhebung.Items[0];

                    if (this.mainWindowDatenerhebnungExtern != null && this.lstCounterClickableImages.Count == 1)
                    {
                        ucClickableImage ucClickableImageFound = lstCounterClickableImages[0];
                        this._clickableimages_DoubleClick(ucClickableImageFound.Index, ucClickableImageFound.Tag, ucClickableImageFound.XMLFile);
                    }
                }
                _bForceRefresh = false;

            }
            catch (Exception ex)
            {
                if (!this.IsExternControl)
                {
                    _framework.HEADER.ShowControlAndHeader(true);
                }
                ENV.HandleException(ex);
            }
            finally
            {
                if (!this.IsExternControl)
                {
                    _framework.HEADER.action(true);
                }
            }
        }

        public void DetachFramework()
        {
            AskForSave();

            ENV.UserLoggedOn -= new EventHandler(ENV_UserLoggedOn);
        }

        public void ProcessKeyEvent(KeyEventArgs e)
        {
            //			switch(e.KeyCode) 
            //			{
            //				case Keys.L:								
            //					HandleLabelEvent(SiteEvents.Terminliste);
            //					e.Handled = true;
            //					break;
            //			}
        }

        #endregion

        private void ENV_UserLoggedOn(object sender, EventArgs e)
        {
            UpdateActions();
        }

        private void UpdateActions()
        {
            panelKeinRecht.Visible = false;
            pnlErhebung.Height = 0;
            pnlPflegeAnamnese.Visible = true;

            if (!ENV.HasRight(UserRights.DatenerhebungAnzeigen))
            {
                panelKeinRecht.Visible = true;
                pnlPflegeAnamnese.Visible = false;
            }
            else
            {
                ucAnamneseBase control;

                foreach (Control c in pnlPflegeAnamnese.Controls)
                {
                    if (c is ucAnamneseBase)
                    {
                        control = (ucAnamneseBase)c;
                        control.ReadOnly = !ENV.HasRight(UserRights.DatenerhebungAendern);

                        control.DatenerhebungDrucken = ENV.HasRight(UserRights.DatenerhebungDrucken);
                        control.DatenerhebungLoeschen = ENV.HasRight(UserRights.DatenerhebungLoeschen);
                    }
                }
            }
        }

        private void loadAuswahl()
        {

            /*
                        if (this.mnuIsLoaded)
                        {
                            foreach (Control c in pnlPflegeAnamnese.Controls)
                            {
                                if (c is ucAssessement)
                                {
                                    c.Tag = null;
                                }
                            }

                            cmbErhebung.SelectedItem = cmbErhebung.Items[0];
                            _clickableimages.Visible = true;
            //                return;
                        }

            //            else

            //            {
            */

            _aAssenementMenu.Clear();
            FormularManager manager = new FormularManager();
            dsFormular.FormularDataTable dt = manager.Read();

            if (this.FormulareCountedLast != -1 && this.FormulareCountedLast != dt.Rows.Count)
            {
                ucDatenErhebung.AssesstmensHasChanged = true;
            }
            this.FormulareCountedLast = dt.Rows.Count;

            ucAnamneseBase control;

            List<ucAnamneseBase> list = new List<ucAnamneseBase>();
            foreach (Control c in pnlPflegeAnamnese.Controls)
            {
                if (c is ucAnamneseBase)
                {
                    control = (ucAnamneseBase)c;
                    if (IsPflegeModellVisible(control.Modell))
                    {
                        if ((this.IsExternControl && !control.GetType().Equals(typeof(ucAnamneseBiografie)) &&
                                !control.GetType().Equals(typeof(ucAnamneseKrohwinkel)) &&
                                !control.GetType().Equals(typeof(ucAnamneseOrem)) &&
                                !control.GetType().Equals(typeof(ucAnamnesePOP))) || !this.IsExternControl)
                        {
                            if (!this.IsExternControl)
                            {
                                list.Add(control);
                            }
                            else if (this.IsExternControl)
                            {
                                list.Add(control);
                            }
                        }
                    }
                }
            }
            //Liste sortieren
            ControlComparer cc = new ControlComparer();
            list.Sort(cc);

            if (!this.IsExternControl)
            {
                if (this.IsPflegeModellVisible(PflegeModelle.Krohwinkel))
                {
                    PMDSMenuEntry m3 = new PMDSMenuEntry(SiteGroups.Krohwinkel, "Anamnese .. nach Krohwinkel (AEDL)", null);
                    _aAssenementMenu.Add(m3);
                }

                if (this.IsPflegeModellVisible(PflegeModelle.Orem))
                {
                    PMDSMenuEntry m3 = new PMDSMenuEntry(SiteGroups.OREM, "Anamnese .. nach OREM", null);
                    _aAssenementMenu.Add(m3);
                }

                if (this.IsPflegeModellVisible(PflegeModelle.POP))
                {
                    PMDSMenuEntry m3 = new PMDSMenuEntry(SiteGroups.POP, "Anamnese .. nach POP", null);
                    _aAssenementMenu.Add(m3);
                }
            }

            foreach (ucAnamneseBase c in list)
            {
                PMDSMenuEntry m = new PMDSMenuEntry(SiteGroups.Assessment, c.EntyText, null);
                _aAssenementMenu.Add(m);
            }
            
            //Nur Assessments einfügen
            bool gefunden;
            foreach (dsFormular.FormularRow r in dt)
            {
                if ((this.IsExternControl && r.InNotfallAnzeigenJN) || (!this.IsExternControl) || (this.IsExternControl && this.mainWindowDatenerhebnungExtern != null))
                {
                    if (!r.GUI)                                        
                        continue;
                    gefunden = false;
                    foreach (Control c in pnlPflegeAnamnese.Controls)
                    {
                        if (c is ucAnamneseBase)
                        {
                            control = (ucAnamneseBase)c;

                            if (r.Bezeichnung.ToUpper().Contains(control.Modell.ToString().ToUpper()))
                            {
                                gefunden = true;
                                break;
                            }
                        }
                    }
                    if (!gefunden)
                    {
                        PMDSMenuEntry m = new PMDSMenuEntry(SiteGroups.Assessment, r.Bezeichnung, null);
                        m.Tag = r.ID;                 
                        _aAssenementMenu.Add(m);

                    }
                }
            }

            cmbErhebung.Items.Clear();
            PMDS.GUI.Datenerhebung.ValueListItemOwn item;
            item = new PMDS.GUI.Datenerhebung.ValueListItemOwn();
            item.DataValue = null;
            item.DisplayText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte wählen...");

            cmbErhebung.Items.Add(item);

            foreach (PMDSMenuEntry mnu in _aAssenementMenu)
            {
                item = new PMDS.GUI.Datenerhebung.ValueListItemOwn();  
                item.DataValue = mnu.EntryKey;
                item.DisplayText = mnu.EntryTxt;
                if (mnu.Tag != null)
                {
                    item.IDFormular = (Guid)mnu.Tag;
                }
                cmbErhebung.Items.Add(item);
            }
            
            cmbErhebung.SelectedItem = cmbErhebung.Items[0];
            RefreshClickableImages(cmbErhebung);        //os-Performance: bisher: 0,7 sek. Neu 8 ms)

            this.mnuIsLoaded = true;
            //           }
        }

        private void RefreshClickableImages(Infragistics.Win.UltraWinEditors.UltraComboEditor cmbErhebung)
        {
            try
            {
                bool IsInitialized = false;
                if (_clickableimages != null)  
                {
                    _clickableimages.Visible = true;
                    IsInitialized = true;
                }
                if (ucDatenErhebung.AssesstmensHasChanged)
                {
                    _clickableimages.Visible = true;
                    IsInitialized = false;
                }


                int iCount = -1;
                if (!IsInitialized)
                {
                    _clickableimages = new ucClickableImages();
                }

                PMDS.DB.PMDSBusiness b = new DB.PMDSBusiness();
                using (PMDS.db.Entities.ERModellPMDSEntities db = PMDS.DB.PMDSBusiness.getDBContext())
                {
                    if (!IsInitialized)
                    {
                        System.Collections.Generic.List<Control> lstControlsToDelete = new List<Control>();
                        foreach (Control cont in pnlPflegeAnamnese.Controls)
                        {
                            if (!cont.Name.Trim().ToLower().Equals(("pnlAnamneseOrem").Trim().ToLower()) &&
                                !cont.Name.Trim().ToLower().Equals(("pnlAnamneseKrohwinkel").Trim().ToLower()) &&
                                !cont.Name.Trim().ToLower().Equals(("pnlAnamnesePOP").Trim().ToLower()) &&
                                !cont.Name.Trim().ToLower().Equals(("ucAnamneseBiografie1").Trim().ToLower()) &&
                                !cont.Name.Trim().ToLower().Equals(("panelKeinRecht").Trim().ToLower()))
                            {
                                lstControlsToDelete.Add(cont);
                            }
                        }
                        foreach (Control cont in lstControlsToDelete)
                        {
                            pnlPflegeAnamnese.Controls.Remove(cont);
                        }

                        bool bAddImg = false;
                        foreach (ValueListItem item in cmbErhebung.Items)
                        {
                            ++iCount;
                            if (iCount == 0)
                            {
                                continue;
                            }

                            string s = item.DisplayText.Replace("(", "_").Replace(")", "_") + ".jpg";
                            string sFile = Path.Combine(ENV.Image_Path, s);
                            PMDS.GUI.Datenerhebung.ValueListItemOwn itemOwn = (PMDS.GUI.Datenerhebung.ValueListItemOwn)item;
                            Color BackgroundColor = Color.LightGray;

                            if (this.mainWindowDatenerhebnungExtern != null)
                            {
                                var rFormular = (from f in db.Formular
                                                 where f.ID == itemOwn.IDFormular
                                                 select new
                                                 {
                                                     IDAbteilung = f.ID,
                                                     Name = f.Name,
                                                     Bezeichnung = f.Bezeichnung
                                                 }).First();

                                var tFormular = (from lstFor in this.lstFormulare
                                                 where lstFor.Contains(rFormular.Name) 
                                                 select new
                                                 {
                                                     lstFor
                                                 });    
                                if (tFormular.Count() > 0)
                                {
                                    ucClickableImage ucClickableImageAdded = _clickableimages.AddFromFile(sFile, item.DisplayText, "", null, iCount, BackgroundColor, itemOwn.IDFormular, sFile);
                                    lstCounterClickableImages.Add(ucClickableImageAdded);
                                }
                            }
                            else
                            {
                                ucClickableImage ucClickableImageAdded = _clickableimages.AddFromFile(sFile, item.DisplayText, "", null, iCount, BackgroundColor, itemOwn.IDFormular, sFile);
                                lstCounterClickableImages.Add(ucClickableImageAdded);
                            }
                        }
                        _clickableimages.BackColor = Color.WhiteSmoke;
                        _clickableimages.Visible = true;
                        _clickableimages.Dock = DockStyle.Fill;

                        //_clickableimages.DoubleClick += new ClickableImagesClickDelegate(_clickableimages_DoubleClick);
                        _clickableimages.Click += new ClickableImagesClickDelegate(_clickableimages_DoubleClick);
                        pnlPflegeAnamnese.Controls.Add(_clickableimages);
                    }

                    List<PMDSBusiness.DataFormular> lFormCount =   b.getFormulardatenCountByPatient(ENV.CurrentIDPatient, db);
                    foreach (ucClickableImage ClickableImage in _clickableimages.pnlMain.Controls)
                    {
                        if (ClickableImage._IDFormular != null)
                        {

                            PMDSBusiness.DataFormular f = lFormCount.Find(x => x.key.Equals((Guid)ClickableImage._IDFormular));
                            if (f != null && f.cnt > 0)
                            {
                                ClickableImage.lblInfo.Text = ClickableImage.txtOriginal.Trim() + " (" + f.cnt.ToString() + ")";
                                ClickableImage.lblInfo.Appearance.BackColor = System.Drawing.Color.Wheat;
                            }
                            else
                            {
                                ClickableImage.lblInfo.Text = ClickableImage.txtOriginal.Trim();
                                ClickableImage.lblInfo.Appearance.BackColor = System.Drawing.Color.Gainsboro;
                            }
                        }
                    }
                }

                ucDatenErhebung.AssesstmensHasChanged = false;
            }
            catch (Exception ex)
            {
                ucDatenErhebung.AssesstmensHasChanged = false;
                throw new Exception("ucDatenErhebnung.RefreshClickableImages: " + ex.ToString());
            }
        }

        void _clickableimages_DoubleClick(int index, object Tag, string XMLFile)
        {
            if (this.IsExternControl)
            {
                if (this.mainWindowNotfall != null)
                {
                    this.mainWindowNotfall.SetUIDatenerhebung(true);
                }
                if (this.mainWindowDatenerhebnungExtern != null)
                {

                }
            }
            cmbErhebung.SelectedIndex = index;
        }

        private Control AddAssessementControl(PMDSMenuEntry entry, ref bool abort)
        {

            using (PMDS.db.Entities.ERModellPMDSEntities db = PMDSBusiness.getDBContext())
            {
                Guid IDFormularTmp = (Guid)entry.Tag;
                System.Linq.IQueryable<PMDS.db.Entities.Formular> tFormular = this.b.getFormularByID(IDFormularTmp, db);
                if (tFormular.Count() == 0)
                {
                    abort = true;
                    QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formular existiert nicht mehr!");
                    return null;
                }
                //PMDS.db.Entities.Formular rFormular = tFormular.First();
            }
     

            ucAssessement assessement = new ucAssessement();
            assessement.MainWindowDatenerhebung = this;
            assessement.IDPatient = ENV.CurrentIDPatient;
            assessement.IDFormular = (Guid)entry.Tag;
            assessement.Location = new Point(1, 1);
            assessement.Size = new Size(952, 537);
            assessement.Dock = DockStyle.Fill;
            pnlPflegeAnamnese.Controls.Add(assessement);
            return assessement;
        }


        public void loadControlKrohwinkel()
        {
            try
            {
                if (!this.IsExternControl)
                {
                    if (!this.IsInitializedKrohwinkel)
                    {
                        this.ucAnamneseKrohwinkel2 = new ucAnamneseKrohwinkel();
                        this.ucAnamneseKrohwinkel2.Dock = DockStyle.Fill;
                        this.ucAnamneseKrohwinkel2.BorderStyle = BorderStyle.FixedSingle;
                        this.ucAnamneseKrohwinkel2.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                        this.pnlAnamneseKrohwinkel.Controls.Add(this.ucAnamneseKrohwinkel2);
                        this.IsInitializedKrohwinkel = true;
                    }
                    this.pnlAnamneseKrohwinkel.Visible = true;
                }
                else
                {
                    this.pnlAnamneseKrohwinkel.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebung.loadControlKrohwinkel: " + ex.ToString());
            }
        }
        public void loadControlOrem()
        {
            try
            {
                if (!this.IsExternControl)
                {
                    if (!this.IsInitializedOrem)
                    {
                        this.ucAnamneseOrem2 = new ucAnamneseOrem();
                        this.ucAnamneseOrem2.Dock = DockStyle.Fill;
                        this.ucAnamneseOrem2.BorderStyle = BorderStyle.FixedSingle;
                        this.ucAnamneseOrem2.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                        this.pnlAnamneseOrem.Controls.Add(this.ucAnamneseOrem2);
                        this.IsInitializedOrem = true;
                    }
                    this.pnlAnamneseOrem.Visible = true;
                }
                else
                {
                    this.pnlAnamneseOrem.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebung.loadControlOrem: " + ex.ToString());
            }
        }
        public void loadControlPOP()
        {
            try
            {
                if (!this.IsExternControl)
                {
                    if (!this.IsInitializedPOP)
                    {
                        this.ucAnamnesePOP2 = new ucAnamnesePOP();
                        this.ucAnamnesePOP2.Dock = DockStyle.Fill;
                        this.ucAnamnesePOP2.BorderStyle = BorderStyle.FixedSingle;
                        this.ucAnamnesePOP2.setControlsAktivDisable(PMDS.Global.historie.HistorieOn);

                        this.pnlAnamnesePOP.Controls.Add(this.ucAnamnesePOP2);
                        this.IsInitializedPOP = true;
                    }
                    this.pnlAnamnesePOP.Visible = true;
                }
                else
                {
                    this.pnlAnamnesePOP.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebung.loadControlPOP: " + ex.ToString());
            }
        }



        private void SelectItem(Control uc)
        {
            foreach (Infragistics.Win.ValueListItem item in cmbErhebung.Items)
            {
                if (item.Tag != null && item.Tag.Equals(uc))
                {
                    cmbErhebung.SelectedItem = item;
                    break;
                }
            }
        }

        private void cmbErhebung_ValueChanged(object sender, EventArgs e)
        {
            this.selectcmbErhebung();
        }
        private void selectcmbErhebung()
        {
            try
            {
                Infragistics.Win.ValueListItem item = cmbErhebung.SelectedItem;
                if (item == null) return;
                foreach (Control c in pnlPflegeAnamnese.Controls)
                {
                    if (c.Visible && c is ucAssessement)
                    {
                        ucAssessement uc = (ucAssessement)c;

                        if (!uc.Equals(item.Tag) && uc.ISFORMULARTOSAVE)
                        {
                            DialogResult res = ENV.AskForSave();

                            if (res == DialogResult.Cancel)
                            {
                                SelectItem(uc);
                                return;
                            }
                            else if (res == DialogResult.Yes)
                                uc.ProcessSave(true);
                        }
                        break;
                    }
                    else if (c.Visible && c is ucAnamneseBase)
                    {
                        ucAnamneseBase uc = (ucAnamneseBase)c;
                        if (!uc.Equals(item.Tag) && uc.ISTOSAVE)
                        {
                            DialogResult res = ENV.AskForSave();

                            if (res == DialogResult.Cancel)
                            {
                                SelectItem(uc);
                                return;
                            }
                            else if (res == DialogResult.Yes)
                                uc.Save();
                        }
                        break;
                    }
                    //else if (c is Panel)
                    //{
                    //    ucAnamneseBase ucPanel = null;
                    //    if (item.DisplayText.ToString().Trim().ToLower().Contains(("OREM").Trim().ToLower()))
                    //    {
                    //        ucPanel = this.ucAnamneseOrem2;
                    //    }
                    //    else if (item.DisplayText.ToString().Trim().ToLower().Contains(("Krohwinkel").Trim().ToLower()))
                    //    {
                    //        ucPanel = this.ucAnamneseKrohwinkel2;
                    //    }
                    //    else if (item.DisplayText.ToString().Trim().ToLower().Contains(("POP").Trim().ToLower()))
                    //    {
                    //        ucPanel = this.ucAnamnesePOP2;
                    //    }

                    //    if (ucPanel != null && ucPanel.Visible)
                    //    {
                    //        if (ucPanel.ISTOSAVE)
                    //        {
                    //            DialogResult res = ENV.AskForSave();
                    //            if (res == DialogResult.Cancel)
                    //            {
                    //                SelectItem(ucPanel);
                    //                return;
                    //            }
                    //            else if (res == DialogResult.Yes)
                    //                ucPanel.Save();
                    //        }
                    //        break;
                    //    }
                    //}
                }

                if (this.ucAnamneseBasePanelLastSelected != null)
                {
                    if (this.ucAnamneseBasePanelLastSelected.ISTOSAVE)
                    {
                        DialogResult res = ENV.AskForSave();
                        if (res == DialogResult.Cancel)
                        {
                            SelectItem(this.ucAnamneseBasePanelLastSelected);
                            return;
                        }
                        else if (res == DialogResult.Yes)
                            this.ucAnamneseBasePanelLastSelected.Save();
                    }
                }
                this.ucAnamneseBasePanelLastSelected = null;

                foreach (Control c in pnlPflegeAnamnese.Controls)
                {
                    c.Visible = false;
                    c.Dock = DockStyle.Fill;
                }

                // Control suchen und Tg setzen
                if (item.Tag == null || item.Tag is ucAssessement)
                {
                    foreach (PMDSMenuEntry mnu in _aAssenementMenu)
                    {
                        if (item.DisplayText == mnu.EntryTxt)
                        {
                            bool PanelInFront = false;
                            foreach (Control c in pnlPflegeAnamnese.Controls)
                            {
                                if (c is ucAnamneseBase)
                                {
                                    if (mnu.EntryTxt.ToUpper().Contains(((ucAnamneseBase)c).Modell.ToString().ToUpper()))
                                    {
                                        item.Tag = c;
                                        break;
                                    }
                                }
                                else if (c is Panel)
                                {
                                    Panel pnl = (Panel)c;
                                    if (pnl.Tag != null)
                                    {
                                        if (item.DisplayText.ToString().Trim().ToLower().Contains(("OREM").Trim().ToLower()))
                                        {
                                            this.loadControlOrem();
                                            this.ucAnamneseOrem2.IDPatient = ENV.CurrentIDPatient;
                                            PanelInFront = true;
                                            this.ucAnamneseBasePanelLastSelected = this.ucAnamneseOrem2;
                                            break;
                                        }
                                        else if (item.DisplayText.ToString().Trim().ToLower().Contains(("Krohwinkel").Trim().ToLower()))
                                        {
                                            this.loadControlKrohwinkel();
                                            this.ucAnamneseKrohwinkel2.IDPatient = ENV.CurrentIDPatient;
                                            PanelInFront = true;
                                            this.ucAnamneseBasePanelLastSelected = this.ucAnamneseKrohwinkel2;
                                            break;
                                        }
                                        else if (item.DisplayText.ToString().Trim().ToLower().Contains(("POP").Trim().ToLower()))
                                        {
                                            this.loadControlPOP();
                                            this.ucAnamnesePOP2.IDPatient = ENV.CurrentIDPatient;
                                            PanelInFront = true;
                                            this.ucAnamneseBasePanelLastSelected = this.ucAnamnesePOP2;
                                            break;
                                        }
                                        else
                                        {
                                            //throw new Exception("ucDatenErhebnung.selectcmbErhebung: pnl.Tag  no correct!");
                                        }
                                    }
                                }
                            }

                            if (!PanelInFront && (item.Tag == null || item.Tag is ucAssessement))
                            {
                                bool abort = false;
                                item.Tag = AddAssessementControl(mnu, ref abort);
                                if (abort)
                                {
                                    ucDatenErhebung.AssesstmensHasChanged = true;
                                    this.loadMainSite();
                                    return;
                                }
                            }

                            break;
                        }
                    }
                }

                pnlPflegeAnamnese.BorderStyle = BorderStyle.None;
                if (item.Tag != null)
                {
                    ((Control)item.Tag).Visible = true;
                    if (item.Tag.GetType().Name == "ucAnamneseBiografie")
                    {
                        this.ucAnamneseBiografie1.loadDatenFürPatient();
                        ucAnamneseBiografie1.BorderStyle = BorderStyle.None;
                    }
                    else if (item.Tag.GetType().Name == "ucAssessement")
                    {
                        //((ucAssessement)item.Tag).BorderStyle = BorderStyle.None;
                        //((ucAssessement)item.Tag).BackColor = System.Drawing.Color.Gainsboro;
                    }
                    else if (item.Tag.GetType().Name == "pnlAnamneseOrem")
                    {
                        //this.loadControlOrem();
                    }
                    else if (item.Tag.GetType().Name == "pnlAnamneseKrohwinkel")
                    {
                        //this.loadControlKrohwinkel();
                    }
                    else if (item.Tag.GetType().Name == "pnlAnamnesePOP")
                    {
                        //this.loadControlPOP();
                    }

                }
                else
                {
                    pnlPflegeAnamnese.BorderStyle = BorderStyle.FixedSingle;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ucDatenErhebnung.selectcmbErhebung: " + ex.ToString());
            }
        }

        private void uc_DataChanged(bool isDataChanged)
        {
            _ContentChanged = isDataChanged;

        }


        private class ControlComparer : IComparer<ucAnamneseBase>
        {
            public int Compare(ucAnamneseBase uc1, ucAnamneseBase uc2)
            {
                if (uc1 == null)
                {
                    if (uc2 == null)
                        return 0;
                    else
                        return -1;
                }
                else
                {
                    if (uc2 == null)
                        return 1;
                    else
                        return uc1.EntyText.CompareTo(uc2.EntyText);
                }
            }
        }

        private void pnlPflegeAnamnese_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucAnamneseOrem1_Load(object sender, EventArgs e)
        {

        }



        private void ucDatenErhebung_Resize(object sender, EventArgs e)
        {
            this.ucAnamneseBiografie1.resizeForm(this.pnlPflegeAnamnese.Width, this.pnlPflegeAnamnese.Height);
        }

        private void pnlErhebung_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucDatenErhebung_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if ((this.Visible && !this.IsExternControl) || (this.Visible && !this.IsInitialized && this.IsExternControl))
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.loadMainSite();
                    this.IsInitialized = true;
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ENV.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ucAnamneseBiografie1_DataChanged(bool isDataChanged)
        {
            _ContentChanged = isDataChanged;
        }
        
    }

}
