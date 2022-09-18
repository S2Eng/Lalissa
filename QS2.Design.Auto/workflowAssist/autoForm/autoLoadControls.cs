using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinTabs;
using qs2.core.vb;
using qs2.design.auto.workflowAssist.autoForm;



namespace qs2.design.auto.workflowAssist.autoForm
{



    public class autoLoadControls
    {
        
        public bool IsIntitialized = false;
        public qs2.design.auto.workflowAssist.autoForm.ColorSchemas ColorSchemas1 = new qs2.design.auto.workflowAssist.autoForm.ColorSchemas();





        public void startxy(UltraTabControl tabsParent, 
                            Infragistics.Win.Misc.UltraPanel freeTop,
                            Infragistics.Win.Misc.UltraPanel freeTopLeft, Infragistics.Win.Misc.UltraPanel freeTopRigth,
                            Infragistics.Win.Misc.UltraPanel freeBelow, ref int typeLoading, ref string protocollForAdmin, ref bool ProtocolWindow,
                            ref  qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1,
                            ref qs2.core.vb.dsAdmin dsAdminAutoUI,
                            string Application, string Participant,
                            qs2.sitemap.workflowAssist.form.contAutoUI AutoUI)
        {
            try
            {
                if (this.IsIntitialized)
                {
                    return;
                }

                System.Guid keyParentFrameFreeBottomTop = System.Guid.Empty;

                freeTop.Tag = System.Guid.NewGuid();
                freeTopLeft.Tag = System.Guid.NewGuid();
                freeTopRigth.Tag = System.Guid.NewGuid();
                Nullable<Guid> IDGuidParentNull = null;
                string IDGuidsParentNull = "";

                int SerialNr = 0;
                int controlLevelNoChapter = 0;
                System.Guid IDGroupNull = System.Guid.Empty;
                this.loadControls_rek(ref tabsParent, (Control)freeTop, null, null, true, keyParentFrameFreeBottomTop,
                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, IDGroupNull, false, ref controlLevelNoChapter,
                                        ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, true, ref SerialNr, ref AutoUI.dataStay, "", "", ref IDGuidParentNull, ref IDGuidsParentNull);
                this.loadControls_rek(ref tabsParent, (Control)freeTopLeft, null, null, true, keyParentFrameFreeBottomTop,
                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, IDGroupNull, false, ref controlLevelNoChapter,
                                        ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, true, ref SerialNr, ref AutoUI.dataStay, "", "", ref IDGuidParentNull, ref IDGuidsParentNull);
                this.loadControls_rek(ref tabsParent, (Control)freeTopRigth, null, null,  true, keyParentFrameFreeBottomTop,
                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, IDGroupNull, false, ref controlLevelNoChapter,
                                        ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, true, ref SerialNr, ref AutoUI.dataStay, "", "", ref IDGuidParentNull, ref IDGuidsParentNull);

                System.Guid LastIDGroup = System.Guid.Empty;
                foreach (UltraTab tabChapter in tabsParent.Tabs)        //Perf = 1.4 Sek
                {
                    cTabTag cTagTab;
                    cTagTab = (cTabTag)tabChapter.Tag;
                    //if (cTagTab.StayTyp == StayTyp)
                    //{
                        System.Guid keyParentFrameTab = System.Guid.NewGuid();
                        cTagTab.key = keyParentFrameTab;
                        
                        LastIDGroup = System.Guid.Empty;
                        if (!cTagTab.IDOwnStr.Trim().ToLower().Equals(("protokoll").Trim().ToLower()))
                        {
                            qs2.core.vb.dsAdmin.dbAutoUIRow rNewTab = autoUI1.addAutoUI(ref dsAdminAutoUI);
                            SerialNr += 1;
                            int controlLevelChapter = 1;
                            Nullable<Guid> IDGuid = null;
                            autoUI1.addTabPage(cTagTab.IDOwnStr, cTagTab.IDOwnStr, tabChapter, keyParentFrameTab, ref dsAdminAutoUI, AutoUI,
                                                        Application, Participant,
                                                        tabsParent.Top, ref typeLoading, ref LastIDGroup, true, ref rNewTab,
                                                        ref controlLevelChapter, true, ref SerialNr, "", "", ref IDGuid, ref IDGuidsParentNull);

                            cTagTab.IsChapter = true;
                        string IDGuidsParent = "";
                        IDGuidsParent = IDGuid.ToString() + ";";
                        //cTagTab.IDOwnStr = cTagTab.IDOwnStr;            //=Chapter
                        //cTagTab.text = cTagTab.text;                    //=Chapter
                        //cTagTab.IDOwnStrTabPage = cTagTab.IDOwnStr;
                        //cTagTab.TextTabPage = cTagTab.text;
                        //cTagTab.key = rNewTab.key;
                        //cTagTab.StayTyp = StayTyp;
                        //cTagTab.rCont = rNewTab;

                        //controlLevelChapter = 2;
                        this.loadControls_rek(ref tabsParent, (Control)tabChapter.TabPage, cTagTab, tabChapter, true, keyParentFrameTab,
                                                    ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, rNewTab.ID, true, ref controlLevelChapter,
                                                    ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, true, ref SerialNr, ref AutoUI.dataStay,
                                                    "", "", ref IDGuid, ref IDGuidsParent);
                        //}
                    }
                }

                freeBelow.Tag = System.Guid.NewGuid();
                this.loadControls_rek(ref tabsParent, (Control)freeBelow, null, null, true, keyParentFrameFreeBottomTop,
                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, IDGroupNull, false, ref controlLevelNoChapter,
                                        ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, true, ref SerialNr, ref AutoUI.dataStay,
                                        "", "", ref IDGuidParentNull, ref IDGuidsParentNull);

                tabsParent.Tabs[qs2.sitemap.workflowAssist.form.contAutoUI.tabNameProtokoll].Text = qs2.core.language.sqlLanguage.getRes("Protokoll");

                this.IsIntitialized = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "autoLoadControls.start", "", false, true, Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
            finally
            {
                qs2.design.auto.multiControl.ownMCInfo.checkForProtocol(false);
            }
        }

        public void loadControls_rek(ref UltraTabControl tabsParent, Control parentControl, cTabTag cTagTab, UltraTab tab, 
                                bool UnderTab,
                                System.Guid keyParentFrame, ref int typeLoading, ref string protocollForAdmin, ref bool ProtocolWindow,
                                System.Guid LastIDGroup, bool ParentIsMainTabPage, ref int controlLevel,
                                ref  qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1,
                                ref qs2.core.vb.dsAdmin dsAdminAutoUI,
                                ref string Application, ref string Participant,
                                ref qs2.sitemap.workflowAssist.form.contAutoUI AutoUI, bool mainNode, ref int SerialNr,
                                ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, 
                                string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuidParent, ref string IDGuidsParent)
        {
            try
            {
                foreach (Control cont in parentControl.Controls)
                {
                    //if (tab == null)
                    //{
                    //    string xy = "";
                    //}

                    //if (cont.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTab)))
                    //{
                    //    return;
                    //}

                    if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    {
                        qs2.design.auto.multiControl.ownTab ownTab1 = (qs2.design.auto.multiControl.ownTab)cont;
                        if (!ownTab1.isLoaded)
                        {
                            System.Guid ID = System.Guid.NewGuid();
                            System.Guid IDGroup = System.Guid.NewGuid();
                            qs2.core.vb.dsAdmin.dbAutoUIRow rNew = autoUI1.loadOwnTabControl(cont, tab, ref dsAdminAutoUI,
                                    AutoUI, Application, Participant,
                                    ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup, ref ID, ref IDGroup,
                                    ref controlLevel, ref mainNode, ref SerialNr, FldShortTabPageParent, FldShortGroupBoxParent, cTagTab, keyParentFrame);

                            //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownTab1.OwnFldShort, "tabCardiac_Artap", false))
                            //{
                            //    string xy = "";
                            //}

                            ownTab1.OwnOrder = qs2.design.auto.multiControl.ownMCGeneric.getTabOrder(ref ownTab1._OwnOrderLineNr, ref ownTab1._OwnOrderControlNr);

                            controlLevel += 1;
                            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tabCont in ownTab1.Tabs)
                            {
                                //this.autoUI1.addOwnSubTab(tabCont, cTagTab, ownTab1, tab, tabCont, StayTyp, keyParentFrame, ref this.dsAdmin1, this,
                                //                    this.OwnLicense.OwnApplication, this.OwnLicense.OwnParticipant.ToString(),
                                //                    ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);

                                System.Guid keyNewParentFrameTab = System.Guid.NewGuid();
                                qs2.core.vb.dsAdmin.dbAutoUIRow rNewTab = autoUI1.addAutoUI(ref dsAdminAutoUI);
                                SerialNr += 1;
                                Nullable<Guid> IDGuid = null;
                                autoUI1.addTabPage(tabCont.Tag.ToString(), cTagTab.IDOwnStr, tabCont, keyNewParentFrameTab,
                                                        ref dsAdminAutoUI, AutoUI, Application, Participant,
                                                        tabsParent.Top, ref typeLoading, ref LastIDGroup, false, ref rNewTab,
                                                        ref controlLevel, mainNode, ref SerialNr, FldShortTabPageParent, FldShortGroupBoxParent, ref IDGuid, ref IDGuidsParent);
                               
                                qs2.design.auto.multiControl.ownMCUI ownMCUITabPage = new qs2.design.auto.multiControl.ownMCUI(); 
                                autoUI1.loadResTabPage(tabCont, ownTab1, ref dsAdminAutoUI, AutoUI,
                                                            Application, Participant,
                                                            ref typeLoading, ref protocollForAdmin, ref ProtocolWindow,
                                                            ref LastIDGroup, ref rNewTab, ref SerialNr, tabCont, tabCont.Tag.ToString().Trim(), FldShortGroupBoxParent,
                                                            ref ownMCUITabPage);

                                cTabTag cTagTabPage = new cTabTag();
                                cTagTabPage.ownMCUI1 = ownMCUITabPage;
                                cTagTabPage.IDOwnStr = cTagTab.IDOwnStr;            //=Chapter
                                cTagTabPage.text = cTagTab.text;                    //=Chapter
                                cTagTabPage.IDOwnStrTabPage = tabCont.Tag.ToString().Trim();
                                cTagTabPage.TextTabPage = tabCont.Text;
                                cTagTabPage.key = rNewTab.key;
                                cTagTabPage.rCont = rNewTab;
                                cTagTabPage.Criteria = ownTab1.ownControlCriteria1;
                                cTagTabPage.ownUltraTab = ownTab1;
                                tabCont.Tag = cTagTabPage;
                                tabCont.Key = rNewTab.key.ToString();
                                IDGuidsParent += IDGuid.ToString() + ";";
                                System.Guid IDGroupNextControls = rNewTab.ID;
                                this.loadControls_rek(ref tabsParent, (Control)tabCont.TabPage, cTagTab, tabCont, false, keyNewParentFrameTab, ref typeLoading,
                                                        ref protocollForAdmin, ref ProtocolWindow, IDGroupNextControls, false, ref controlLevel,
                                                        ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, false, ref SerialNr, ref dataStay,
                                                        cTagTabPage.IDOwnStrTabPage, FldShortGroupBoxParent, ref IDGuid, ref IDGuidsParent);
                            }
                        }
                        ownTab1.isLoaded = true;
                    }
                    else
                    {
                        System.Guid keyParentFrameNew = System.Guid.NewGuid();
                        Nullable<Guid> IDGuid = null;

                        string FldShortGroupBoxParentTmp = FldShortGroupBoxParent;
                        System.Guid IDGroupNextControls = LastIDGroup;
                        if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)) ||
                            cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)) ||
                            cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)) ||
                            cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)) ||
                            cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                        {
                            if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                            {
                                qs2.design.auto.multiControl.ownGroupBox ownGroupBoxTmp = (qs2.design.auto.multiControl.ownGroupBox)cont;
                                FldShortGroupBoxParentTmp = ownGroupBoxTmp._FldShort.Trim();
                            }
                            qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUIAdded = this.addControlToDb(cont, cTagTab, tab, keyParentFrame,
                                                                                    ref typeLoading, ref protocollForAdmin, ref ProtocolWindow,
                                                                                    ref LastIDGroup,
                                                                                    ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI,
                                                                                    ref controlLevel, ref mainNode, ref SerialNr, ref dataStay,
                                                                                    FldShortTabPageParent, FldShortGroupBoxParentTmp, ref IDGuid, ref IDGuidsParent);
                            if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                            {
                                IDGroupNextControls = rAutoUIAdded.ID;
                            }
                        }

                        if (!cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)) &&
                               !cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                        {
                            Nullable<Guid> IDGuid2 = null;
                            if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                            {
                                IDGuid2 = IDGuid;
                                IDGuidsParent += IDGuid2.ToString() + ";";
                                controlLevel += 1;
                            }
                            this.loadControls_rek(ref tabsParent, cont, cTagTab, tab, false, keyParentFrameNew, ref typeLoading,
                                                ref protocollForAdmin, ref ProtocolWindow, IDGroupNextControls, false, ref controlLevel,
                                                ref autoUI1, ref dsAdminAutoUI, ref Application, ref Participant, ref AutoUI, false, ref SerialNr, ref AutoUI.dataStay,
                                                FldShortTabPageParent, FldShortGroupBoxParentTmp, ref IDGuid2, ref IDGuidsParent);
                        }

                        if (cont.GetType().Equals(typeof(System.Windows.Forms.Panel)))
                        {
                            this.ColorSchemas1.setAppearancePanelWin((Panel)cont, ColorSchemas.eTypeUIPanelWin.PanelWinInChapters, false);
                        }

                    }

                    //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownControl)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTabPageControl)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(Panel)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTab)))
                    //{
                    //    string xy = "";
                    //}
                    //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                    //{
                    //    this.loadControls_rek(cont, cTagTab, tab, StayTyp, false, keyParentFrameNew, ref typeLoading,
                    //                            ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);
                    //}
                    //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    //{
                    //    this.loadControls_rek(cont, cTagTab, tab, StayTyp, false, keyParentFrameNew, ref typeLoading,
                    //                            ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);
                    //}
                    //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    //{
                    //    string xy = "";
                    //}
                    //else
                    //{
                    //    this.loadControls_rek(cont, cTagTab, tab, StayTyp, false, keyParentFrameNew, ref typeLoading,
                    //                            ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);
                    //}
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "autoLoadControls.loadControls_rek", "", false, true, Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        

        public qs2.core.vb.dsAdmin.dbAutoUIRow addControlToDb(Control cont, cTabTag cTagTab, UltraTab tab, 
                                    System.Guid keyParentFrame, ref int typeLoading, ref string protocollForAdmin, ref  bool ProtocolWindow,
                                    ref System.Guid LastIDGroup, 
                                    ref  qs2.design.auto.workflowAssist.autoForm.autoUI autoUI1,
                                    ref qs2.core.vb.dsAdmin dsAdminAutoUI,
                                    ref string Application, ref string Participant,
                                    ref qs2.sitemap.workflowAssist.form.contAutoUI AutoUI,
                                    ref int controlLevel, ref bool mainNode, ref int SerialNr,
                                    ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                                    string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuid, ref string IDGuidsParent)
        {
            try
            {
                if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                {
                    qs2.core.vb.dsAdmin.dbAutoUIRow rNew = autoUI1.addOwnMultiControl(cont, cTagTab, tab, keyParentFrame, ref dsAdminAutoUI,
                                                            AutoUI, Application, Participant,
                                                            ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup,
                                                            ref controlLevel, ref mainNode, ref SerialNr, ref dataStay,
                                                            FldShortTabPageParent, FldShortGroupBoxParent, ref IDGuid, ref IDGuidsParent);
                    return rNew;
                }
                else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                {
                    qs2.core.vb.dsAdmin.dbAutoUIRow rNew = autoUI1.addOwnMultiGrid(cont, cTagTab, tab,keyParentFrame, ref dsAdminAutoUI,
                                                        AutoUI, Application, Participant,
                                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup,
                                                        ref controlLevel, ref mainNode, ref SerialNr,
                                                        FldShortTabPageParent, FldShortGroupBoxParent, ref IDGuid, ref IDGuidsParent);
                    return rNew;
                }
                else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                {
                    qs2.core.vb.dsAdmin.dbAutoUIRow rNew = autoUI1.addOwnGroupBox(cont, cTagTab, tab, keyParentFrame, ref dsAdminAutoUI,
                                                        AutoUI, Application, Participant,
                                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup,
                                                        ref controlLevel, ref mainNode, ref SerialNr,
                                                        FldShortTabPageParent, FldShortGroupBoxParent, ref IDGuid, ref IDGuidsParent);
                    return rNew;
                }
                //else if (cont.GetType().Equals(typeof(Infragistics.Win.UltraWinTabControl.UltraTabControl)))
                //{
                //    LastIDGroup = System.Guid.Empty;
                //    return this.autoUI1.addOwnTab(cont, cTagTab, tab, StayTyp, keyParentFrame, ref this.dsAdmin1,
                //                                        this, this._license.OwnApplication, this._license.OwnParticipant,
                //                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);
                //}
                //else if (cont.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                //{
                //    LastIDGroup = System.Guid.Empty;
                //    return this.autoUI1.addOwnTab(cont, cTagTab, tab, StayTyp, keyParentFrame, ref this.dsAdmin1, 
                //                                        this, this._license.OwnApplication, this._license.OwnParticipant,
                //                                        ref typeLoading, ref protocollForAdmin, ref ProtocolWindow, ref LastIDGroup);
                //}

                //else if (cont.GetType().Equals(typeof(qs2.sitemap.vb.contObject)))
                //{
                //    return this.autoUI1.addObjectControlToDb(cont, cTagTab, tab, StayTyp, keyParentFrame, ref this.dsAdmin1, this, this._license.OwnApplication, this._license.OwnParticipant, ref this.contObject1, ref typeLoading);

                //}
                else
                {
                    throw new Exception("autoLoadControls.addControlToDb: Control-Type '" + cont.GetType().FullName.ToString() + "' not supported!");
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "autoLoadControls.addControlToDb", "", false, true, Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }

        public bool checkRightLicenseChapter(qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelEntriesChapter)
        {
            try
            {
                bool rigthOK = false;
                if (rSelEntriesChapter.Classification.Trim() != "")
                {
                    bool LicenseKeyYesFound = false;
                    System.Collections.Generic.List<string> lstLicenseKeys = qs2.core.generic.readStrVariables(rSelEntriesChapter.Classification.Trim());
                    foreach (string LicensekeyFound in lstLicenseKeys)
                    {
                        string Var = "";
                        string VarValue = "";
                        qs2.core.generic.readVariableAndValue(LicensekeyFound, ref Var, ref VarValue);
                        qs2.core.Enums.cLicense LicenseFoundForSession = qs2.core.license.doLicense.GetLicense(VarValue.Trim());
                        if (LicenseFoundForSession != null)
                        {
                            if (LicenseFoundForSession.bValue == true && !LicenseKeyYesFound)
                            {
                                rigthOK = true;
                                LicenseKeyYesFound = true;
                            }
                        }
                    }
                }
                else
                {
                    rigthOK = true;
                }

                if (!rigthOK)
                {
                    bool bStop = true;
                }
                return rigthOK;
            }
            catch (Exception ex)
            {
                throw new Exception("autoLoadControls.checkRightLicenseChapter: " + ex.ToString());
            }
        }

    }

}
