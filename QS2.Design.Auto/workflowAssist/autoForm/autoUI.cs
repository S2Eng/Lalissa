using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using qs2.core.vb;
using qs2.sitemap.workflowAssist.form;


namespace qs2.design.auto.workflowAssist.autoForm
{

        
    public class tgWindowHandler
    {
        public qs2.sitemap.workflowAssist.form.frmAutoUI produktForm = null;
        public qs2.sitemap.workflowAssist.form.contAutoUI produktControl = null;
        public qs2.core.license.doLicense.eApp Application;
        public qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1 = new autoUI();
        public bool IsOpend = false;
        public bool bPreloadStayDone = false;
        public bool StayFormIsinitialized = false;
    }
        
    public class autoUI
    {
        public qs2.core.license.doLicense.eApp forApplication;
        public int numberForm;
        public bool isIntilaized = false;
        public event doMainFormStayUI evdoMainFormStayUI;
        public delegate void doMainFormStayUI(string doFct);

        public void initialize(string Application)
        {
            if (this.isIntilaized)
            {
                return;
            }
            
            this.isIntilaized = true;
        }

        public bool DefaultValuesLoaded = false;

        public qs2.core.vb.dsAdmin.dbAutoUIRow addOwnMultiControl(Control cont, cTabTag cTagTab, UltraTab tab, 
                            System.Guid keyParentFrame, ref qs2.core.vb.dsAdmin dsAdminUI, 
                            qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                            string Application, string Participant, ref int typeLoading,
                            ref string protocollForAdmin, ref  bool ProtocolWindow,
                            ref System.Guid LastIDGroup,
                            ref int controlLevel, ref bool FirstLevel, ref int SerialNr,
                            string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuidParent, ref string IDGuidsParent)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow rNew = this.addAutoUI(ref dsAdminUI);
                SerialNr += 1;
                qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)cont;

                ownMultiControl1.parentAutoUI = parentAutoUI;
                ownMultiControl1.rAutoUI = rNew;
                ownMultiControl1.ID = System.Guid.NewGuid();
                rNew.ID = ownMultiControl1.ID;
                ownMultiControl1.IDGroup = LastIDGroup;
                rNew.IDGroup = LastIDGroup;

                ownMultiControl1.ownMCCriteria1.parentAutoUI = parentAutoUI;
                //string sChapter = "";
                if (tab != null)
                {
                    ownMultiControl1.ownMCCriteria1.tagTab = cTagTab;
                }
                else
                {
                    ownMultiControl1.ownMCCriteria1.tagTab = null; 
                }
                ownMultiControl1.ownMCCriteria1.Application = Application;
                ownMultiControl1.ownMCCriteria1.IDParticipant = Participant;
                rNew.IDApplication = Application;
                rNew.FldShort = ownMultiControl1._FldShort;
                rNew.control = ownMultiControl1;
                rNew.ControlType = ownMultiControl1._controlType.ToString();
                rNew.key = ownMultiControl1.key;
                rNew.top = ownMultiControl1.Top;
                rNew.left = ownMultiControl1.Left;

                rNew.ControlLevel = controlLevel;
                rNew.FirstLevel = FirstLevel;
                rNew.SerialNr = SerialNr;
                rNew.FldShortTabPageParent = FldShortTabPageParent;
                rNew.FldShortGroupBoxParent = FldShortGroupBoxParent;
                rNew.IDGuidsParent = IDGuidsParent;

                this.addTabInfosToRow(ref rNew, cTagTab, tab, keyParentFrame);
                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.addOwnMultiControl: " + ex.ToString());
                //return null;
            }
        }

        public qs2.core.vb.dsAdmin.dbAutoUIRow addOwnGroupBox(Control cont, cTabTag cTagTab, UltraTab tab,
                                            System.Guid keyParentFrame, ref qs2.core.vb.dsAdmin dsAdminUI,
                                            qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                            string Application, string Participant, ref int typeLoading,
                                            ref string protocollForAdmin, ref bool ProtocolWindow,
                                            ref System.Guid LastIDGroup,
                                            ref int controlLevel, ref bool FirstLevel, ref int SerialNr,
                                            string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuid, ref string IDGuidsParent)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow rNew = this.addAutoUI(ref dsAdminUI);
                SerialNr += 1;
                qs2.design.auto.multiControl.ownGroupBox ownGroupBox1 = (qs2.design.auto.multiControl.ownGroupBox)cont;
                ownGroupBox1.parentAutoUI = parentAutoUI;
                ownGroupBox1.ownControlCriteria1.parentAutoUI = parentAutoUI;
                if (tab != null)
                {
                    ownGroupBox1.ownControlCriteria1.tagTab = cTagTab;
                }
                else
                {
                    ownGroupBox1.ownControlCriteria1.tagTab = null;
                }
                ownGroupBox1.ownControlCriteria1.Application = Application;
                ownGroupBox1.ownControlCriteria1.IDParticipant = Participant;
                rNew.IDApplication = Application;
                rNew.FldShort = ownGroupBox1._FldShort;
                rNew.control = ownGroupBox1;
                IDGuid = System.Guid.NewGuid();
                ownGroupBox1.ID = (Guid)IDGuid;
                rNew.ID = ownGroupBox1.ID;
                ownGroupBox1.IDGroup = LastIDGroup;
                rNew.IDGroup = LastIDGroup;

                ownGroupBox1.doControl();
                ownGroupBox1.ownControlCriteria1.getData(ownGroupBox1, ownGroupBox1._FldShort, core.Enums.eControlType.GroupBox, null,
                                                        ref ownGroupBox1.ownControlUI1, null, ref protocollForAdmin, ref ProtocolWindow, ownGroupBox1.OwnFieldForALLProducts, false, false);
                ownGroupBox1.doVisible();
    
                rNew.ControlType = qs2.core.Enums.eControlType.GroupBox.ToString();
                rNew.key = ownGroupBox1.key;
                rNew.top = ownGroupBox1.Top;
                rNew.left = ownGroupBox1.Left;
                rNew.ControlLevel = controlLevel;
                keyParentFrame = rNew.key;
                rNew.SerialNr = SerialNr;
                rNew.FldShortTabPageParent = FldShortTabPageParent;
                rNew.FldShortGroupBoxParent = FldShortGroupBoxParent;
                ownGroupBox1.rAutoUI = rNew;
                rNew.IDGuidsParent = IDGuidsParent;

                this.addTabInfosToRow(ref rNew, cTagTab, tab, keyParentFrame);
                ownGroupBox1.OwnOrder = qs2.design.auto.multiControl.ownMCGeneric.getTabOrder(ref ownGroupBox1._OwnOrderLineNr, ref ownGroupBox1._OwnOrderControlNr);

                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.addOwnGroupBox: " + ex.ToString());
            }
        }

        public qs2.core.vb.dsAdmin.dbAutoUIRow addOwnMultiGrid(Control cont, cTabTag cTagTab, UltraTab tab,
                                            System.Guid keyParentFrame, ref qs2.core.vb.dsAdmin dsAdminUI,
                                            qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                            string Application, string Participant, ref int typeLoading, 
                                            ref string protocollForAdmin, ref bool ProtocolWindow,
                                            ref System.Guid LastIDGroup,
                                            ref int controlLevel, ref bool FirstLevel, ref int SerialNr,
                                            string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuidParent, ref string IDGuidsParent)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow rNew = this.addAutoUI(ref dsAdminUI);
                SerialNr += 1;
                qs2.design.auto.multiControl.ownMultiGridSelList ownMultiGridSelList1 = (qs2.design.auto.multiControl.ownMultiGridSelList)cont;
                ownMultiGridSelList1.parentAutoUI = parentAutoUI;
                ownMultiGridSelList1.ownMCCriteria1.parentAutoUI = parentAutoUI;
                if (tab != null)
                {
                    ownMultiGridSelList1.ownMCCriteria1.tagTab = (cTabTag)tab.Tag;
                }
                else
                {
                    ownMultiGridSelList1.ownMCCriteria1.tagTab = null;
                }
                ownMultiGridSelList1.ownMCCriteria1.Application = Application;
                ownMultiGridSelList1.ownMCCriteria1.IDParticipant = Participant;
                ownMultiGridSelList1.ID = System.Guid.NewGuid();
                rNew.ID = ownMultiGridSelList1.ID;
                ownMultiGridSelList1.IDGroup = LastIDGroup;
                ownMultiGridSelList1.rAutoUI = rNew;
                rNew.IDGroup = LastIDGroup;

                rNew.IDApplication = Application;
                rNew.FldShort = ownMultiGridSelList1._FldShortTitle;
                rNew.control = ownMultiGridSelList1;

                ownMultiGridSelList1.initControl();
                ownMultiGridSelList1.ownMCCriteria1.getData(ownMultiGridSelList1, ownMultiGridSelList1._FldShortTitle, 
                                                            core.Enums.eControlType.GridMultiSelect, null, ref ownMultiGridSelList1.ownControlUI1,
                                                            null, ref protocollForAdmin, ref ProtocolWindow, ownMultiGridSelList1.OwnFieldForALLProducts, false, false);
                //ownMultiGridSelList1.isLoaded = true;
                rNew.ControlType = qs2.core.Enums.eControlType.GridMultiSelect.ToString();
                rNew.key = ownMultiGridSelList1.key;
                rNew.top = ownMultiGridSelList1.Top;
                rNew.left = ownMultiGridSelList1.Left;
                rNew.ControlLevel = controlLevel;
                keyParentFrame = rNew.key;
                rNew.SerialNr = SerialNr;
                rNew.FldShortTabPageParent = FldShortTabPageParent;
                rNew.FldShortGroupBoxParent = FldShortGroupBoxParent;
                rNew.IDGuidsParent = IDGuidsParent;

                this.addTabInfosToRow(ref rNew, cTagTab, tab, keyParentFrame);
                ownMultiGridSelList1.OwnOrder = qs2.design.auto.multiControl.ownMCGeneric.getTabOrder(ref ownMultiGridSelList1._OwnOrderLineNr, ref ownMultiGridSelList1._OwnOrderControlNr);

                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.addOwnMultiGrid: " + ex.ToString());
                //return null;
            }
        }
        public qs2.core.vb.dsAdmin.dbAutoUIRow loadOwnTabControl(Control cont, UltraTab tab,
                                    ref qs2.core.vb.dsAdmin dsAdminUI,
                                    qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                    string Application, string Participant,
                                    ref int typeLoading, ref string protocollForAdmin, ref bool ProtocolWindow,
                                    ref System.Guid LastIDGroup, ref System.Guid ID, ref System.Guid IDGroup,
                                    ref int controlLevel, ref bool FirstLevel, ref int SerialNr,
                                    string FldShortTabPageParent, string FldShortGroupBoxParent,
                                    cTabTag cTagTab, System.Guid keyParentFrame)
        {
            try
            {
                qs2.core.vb.dsAdmin.dbAutoUIRow rNew = this.addAutoUI(ref dsAdminUI);
                qs2.design.auto.multiControl.ownTab ownTab1 = (qs2.design.auto.multiControl.ownTab)cont;
                ownTab1.parentAutoUI = parentAutoUI;
                ownTab1.ownControlCriteria1.parentAutoUI = parentAutoUI;
                ownTab1.ownControlCriteria1.Application = Application;
                ownTab1.ownControlCriteria1.IDParticipant = Participant;
                ownTab1.parentAutoUI = parentAutoUI;
                ownTab1.ID = ID;
                ownTab1.IDGroup = IDGroup;
                ownTab1.FldShortTabPageParent = FldShortTabPageParent;
                ownTab1.FldShortGroupBoxParent = FldShortGroupBoxParent;
                ownTab1.rAutoUI = rNew;

                rNew.ID = ownTab1.ID;
                rNew.IDApplication = Application;
                rNew.FldShort = ownTab1._FldShort;
                rNew.control = ownTab1;
                rNew.IDGroup = LastIDGroup;
                rNew.ControlType = qs2.core.Enums.eControlType.GroupBox.ToString();
                rNew.key = ownTab1.key;
                rNew.top = ownTab1.Top;
                rNew.left = ownTab1.Left;
                rNew.ControlLevel = controlLevel;
                rNew.SerialNr = SerialNr;
                rNew.FldShortTabPageParent = FldShortTabPageParent;
                rNew.FldShortGroupBoxParent = FldShortGroupBoxParent;

                ownTab1.ownControlCriteria1.getData(ownTab1, ownTab1._FldShort, core.Enums.eControlType.Tab, null, ref ownTab1.ownControlUI1,
                                                    null, ref protocollForAdmin, ref ProtocolWindow, ownTab1.OwnFieldForALLProducts, false, false);
               

                if (!ownTab1.ownControlUI1.IsVisible_Criteriaxy)
                {
                    ownTab1.Visible = ownTab1.ownControlUI1.IsVisible_Criteriaxy; 
                }
                this.addTabInfosToRow(ref rNew, cTagTab, tab, keyParentFrame);

                return rNew;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.loadOwnTabControl: " + ex.ToString());
            }
        }

        public void loadResTabPage(Infragistics.Win.UltraWinTabControl.UltraTab tabCont, qs2.design.auto.multiControl.ownTab ownTab1, 
                                ref qs2.core.vb.dsAdmin dsAdminUI,
                                qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                                string Application, string Participant, ref int typeLoading, 
                                ref string protocollForAdmin, ref bool ProtocolWindow, ref System.Guid LastIDGroup,
                                ref qs2.core.vb.dsAdmin.dbAutoUIRow rNewTab, ref int SerialNr, 
                                Infragistics.Win.UltraWinTabControl.UltraTab tabPage,
                                string FldShortTabPageParent, string FldShortGroupBoxParent, ref qs2.design.auto.multiControl.ownMCUI ownMCUITabPage)
        {
            if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(tabPage.Tag.ToString(), "tabCardiac_Complications_VAC", false))
            {
                string xy = "";
            }

            if (tabCont.Tag != null)
            {
                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                tabCont.Text = qs2.core.language.sqlLanguage.getRes(tabPage.Tag.ToString(), core.Enums.eResourceType.Label, ownTab1.ownControlCriteria1.IDParticipant, ownTab1.ownControlCriteria1.Application, ref  rLangFoundReturn).Trim();

                qs2.design.auto.ownMCCriteria ownMCCriteriaTabPage = new ownMCCriteria();
                ownMCCriteriaTabPage.Application = Application;
                ownMCCriteriaTabPage.IDParticipant = Participant;
                ownMCCriteriaTabPage.getData(tabCont.TabControl, tabPage.Tag.ToString(), core.Enums.eControlType.TabPage, null,
                                                    ref ownMCUITabPage, null, ref protocollForAdmin, ref ProtocolWindow, ownTab1.OwnFieldForALLProducts, false, false);

                bool TabPageIsVisible = autoUI.doVisibleTabPage(ownMCUITabPage);
                tabPage.Visible = TabPageIsVisible;
            }
            else
            {
                tabCont.Text = "[NoRessource]";
                ownTab1.ownControlCriteria1.getData(tabCont.TabControl, "", core.Enums.eControlType.TabPage, null, ref ownTab1.ownControlUI1,
                                                    null, ref protocollForAdmin, ref ProtocolWindow, ownTab1.OwnFieldForALLProducts, false, false);
            }
        }
        public static bool doVisibleTabPage(qs2.design.auto.multiControl.ownMCUI ownControlUI1)
        {
            try
            {
                bool VisibleReturn = (ownControlUI1.IsVisible_Criteriaxy && ownControlUI1.IsVisible_LicenseKey);   // && ownControlUI1.IsVisible_RelationsshipGroups)
                return VisibleReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("doVisibleTabPage: " + ex.ToString());
            }
        }

        public System.Guid addTabPage(string FldSHort, string FldShortChapter, UltraTab tab, 
                System.Guid keyParentFrameTab, ref qs2.core.vb.dsAdmin dsAdminUI,
                qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                string IDApplication, string Participant,
                int top, ref int typeLoading, ref System.Guid LastIDGroup, bool IsChapter, ref qs2.core.vb.dsAdmin.dbAutoUIRow rNewTab,
                ref int ControlLevel, bool FirstLevel, ref int SerialNr,
                string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuid, ref string IDGuidsParent)
        {
            try 
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldSHort, "tabCardiac_Artap", false))
                //{
                //    string xy = "";
                //}

                rNewTab.IDApplication = IDApplication;
                rNewTab.FldShort = FldSHort;
                rNewTab.control = tab;
                rNewTab.ControlType = qs2.core.Enums.eControlType.Tab.ToString();
                rNewTab.key = keyParentFrameTab;
                rNewTab.Chapter = FldShortChapter;
                rNewTab.ControlTab = tab;
                rNewTab.top = top;
                rNewTab.left = tab.Index;
                rNewTab.IsChapter = IsChapter;
                IDGuid = System.Guid.NewGuid();
                rNewTab.ID = (Guid)IDGuid;
                rNewTab.IDGroup = LastIDGroup;
                rNewTab.ControlLevel = ControlLevel;
                rNewTab.FirstLevel = FirstLevel;
                rNewTab.SerialNr = SerialNr;
                rNewTab.FldShortTabPageParent = FldShortTabPageParent;
                rNewTab.FldShortGroupBoxParent = FldShortGroupBoxParent;
                rNewTab.IDGuidsParent = IDGuidsParent;

                return keyParentFrameTab;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.addTabPage: " + ex.ToString());
                //return keyParentFrameTab;
            }
        }
        
        public void initMulticontrol(qs2.design.auto.multiControl.ownMultiControl ownControlChild)
        {
            try
            {
                string protocollForAdmin = "";
                bool ProtocolWindow = false;
            
                ownControlChild.setControl(false);
                ownControlChild.ownMCCriteria1.getData(ownControlChild, ownControlChild._FldShort, ownControlChild._controlType,
                                                        ownControlChild.ComboBox, ref ownControlChild.ownMCUI1, ownControlChild,
                                                        ref protocollForAdmin, ref ProtocolWindow, ownControlChild.OwnFieldForALLProducts, false, false);
                ownControlChild.ownMCTxt1.doText(ownControlChild, false, false);
                ownControlChild.ownMCFormat1.setFormatFromDb(ownControlChild,false ,true );
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.initMulticontrol: " + ex.ToString());
            }
        }

        public void multicontrolFillData(qs2.design.auto.multiControl.ownMultiControl ownControlChild)
        {
            try
            {
                if (ownControlChild.ownMCCriteria1.rCriteria != null)
                {
                    if (ownControlChild.ownMCUI1.controlIsDbDataControl(ownControlChild))
                    {
                        ownControlChild.ownMCDataBind1.setBindingContext(ownControlChild);
                        ownControlChild.ownMCDataBind1.BindControlToData(ownControlChild, false, true);
                    }
                    qs2.core.generic.infoControl calculatedFormat1 = new qs2.core.generic.infoControl();
                    ownControlChild.doActionControl(design.auto.multiControl.ownMultiControl.eTypActionControl.clearErrorProvider, ref calculatedFormat1, false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.multicontrolFillData: " + ex.ToString());
            }
        }

        public void addTabInfosToRow(ref qs2.core.vb.dsAdmin.dbAutoUIRow rNew,  
                                                cTabTag cTagTab, UltraTab tab,
                                                System.Guid keyParentFrame)
        {
            try
            {
                if (cTagTab == null)
                {
                    rNew.Chapter = qs2.core.vb.sqlAdmin.ChapterFreeTopBelow;
                }
                else
                {
                    rNew.Chapter = cTagTab.IDOwnStr;
                }

                if (tab == null)
                    rNew.SetControlTabNull();
                else
                    rNew.ControlTab = tab;

                rNew.IsChapter = false;
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.addTabInfosToRow: " + ex.ToString());
            }
        }
        
        public qs2.core.vb.dsAdmin.dbAutoUIRow addAutoUI(ref qs2.core.vb.dsAdmin dsAdminUI)
        {
            qs2.core.vb.dsAdmin.dbAutoUIRow rNew = (qs2.core.vb.dsAdmin.dbAutoUIRow)dsAdminUI.dbAutoUI.NewRow();

            rNew.FldShort = "";
            rNew.IDApplication = "";
            rNew.Chapter = "";
            rNew.control = "";
            rNew.ControlType = "";
            rNew.SetControlTabNull();
            rNew.key = System.Guid.NewGuid();
            rNew.top = 0;
            rNew.left = 0;
            rNew.IsChapter = false;
            rNew.ID = System.Guid.Empty;
            rNew.IDGroup = System.Guid.Empty;
            rNew.OrderLineNr = 1;
            rNew.OrderControlNr = 1;
            rNew.ControlLevel = -1;
            rNew.FirstLevel = false;
            rNew.SerialNr = -1;
            rNew.FldShortTabPageParent = "";
            rNew.FldShortGroupBoxParent = "";
            rNew.IDGuidsParent = "";

            dsAdminUI.dbAutoUI.Rows.Add(rNew);
            return rNew;
        }
        
        
        
        
        
        public static bool getMultiControl(string FldShort, string Application,
                                            ref qs2.core.vb.dsAdmin dsAdminAuto,
                                            string Chapter,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControlReturn,
                                            ref System.Collections.Generic.List<UltraTab> lstTabPageReturn,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn, bool doNotDataBinding = false)
       {    
            try
            {
                string sWhere = dsAdminAuto.dbAutoUI.FldShortColumn.ColumnName + "='" + FldShort + "' " + qs2.core.sqlTxt.and +
                                dsAdminAuto.dbAutoUI.IDApplicationColumn.ColumnName + "='" + Application + "' ";
                if (Chapter.Trim() != "")
                {
                    sWhere += qs2.core.sqlTxt.and + dsAdminAuto.dbAutoUI.ChapterColumn.ColumnName + "='" + Chapter.Trim() + "' ";
                }

                qs2.core.vb.dsAdmin.dbAutoUIRow[] arrAutoUIRow = (qs2.core.vb.dsAdmin.dbAutoUIRow[])dsAdminAuto.dbAutoUI.Select(sWhere);
                foreach (qs2.core.vb.dsAdmin.dbAutoUIRow rCont in arrAutoUIRow)
                {
                    if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {   
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)rCont.control;
                        lstMultiControlReturn.Add(ownMultiControl1);
                        if (!ownMultiControl1.ownMCCriteria1._isInitializedCriteria)
                        {
                            ownMultiControl1.parentAutoUI.autoUI1.initMulticontrol(ownMultiControl1);
                        }
                        if (!doNotDataBinding && ownMultiControl1.ownMCDataBind1.Binding1 == null)
                        {
                            ownMultiControl1.parentAutoUI.autoUI1.multicontrolFillData(ownMultiControl1);
                        }
                    }
                    else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                    {
                        qs2.design.auto.multiControl.ownGroupBox ownGroupBoxReturn = (qs2.design.auto.multiControl.ownGroupBox)rCont.control;
                        lstGroupBoxReturn.Add(ownGroupBoxReturn);
                    }
                    else if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    {
                        qs2.design.auto.multiControl.ownTab ownTabReturn = (qs2.design.auto.multiControl.ownTab)rCont.control;
                        lstTab.Add(ownTabReturn);
                    }
                    else if (rCont.control.GetType().Equals(typeof(UltraTab)))
                    {
                        UltraTab TabPageReturn = (UltraTab)rCont.control;
                        lstTabPageReturn.Add(TabPageReturn);
                    }
                }

               if (lstGroupBoxReturn.Count > 1)
               {
                   throw new Exception("autoUI.getMultiControl: lstGroupBoxReturn.Count > 0 for FldShort '" + FldShort + "'!");
               }
               if (lstTabPageReturn.Count > 1)
               {
                   throw new Exception("autoUI.getMultiControl: lstTabPageReturn.Count > 0 for FldShort '" + FldShort + "'!");
               }
               if (lstMultiControlReturn.Count == 0 && lstGroupBoxReturn.Count == 0 && lstTabPageReturn.Count == 0)
               {
                   if (qs2.core.ENV.adminSecure && qs2.core.ENV.developModus)
                   {
                       string ExceptTxt = "autoUI.getMultiControl: lstMultiControlReturn.Count == 0 && lstGroupBoxReturn.Count == 0 && lstTabPageReturn.Count == 0 for FldShort '" + FldShort + "'!";
                   }
               }

               return true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "autoUI.getMultiControl", "", false, true, Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }


    }


       public class cTabTag
       {
           public string IDOwnStr = "";
           public string text = "";
           public System.Guid key;
           public string IDOwnStrTabPage = "";
           public string TextTabPage = "";
           public qs2.core.vb.dsAdmin.dbAutoUIRow rCont = null;
           public qs2.design.auto.ownMCCriteria Criteria = null;
           public qs2.design.auto.multiControl.ownMCUI ownMCUI1 = null;
           public multiControl.ownTab ownUltraTab  = null;
           public bool IsChapter = false;
           public int IDSelListChapter = -999;
           public qs2.sitemap.workflowAssist.contListAssistentElem  element = null;
       }
}
