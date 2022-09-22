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

            public class cLstRefresh
            {
                public string multiControlToRefresh = "";
                public bool RunRelationship = true;
            }


        public event doMainFormStayUI evdoMainFormStayUI;
        public delegate void doMainFormStayUI(string doFct);


        //AddNewProduct
        public event doVASCULAR evDoVASCULAR;
        public delegate qs2.core.Enums.cDoProdukt doVASCULAR(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                        qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                        qs2.core.Enums.eStayTyp StayTyp,
                                        qs2.core.license.doLicense.eApp Application,
                                        qs2.core.vb.dsObjects.tblStayRow rStay,
                                        qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                        object r,
                                        System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                        ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                        ref qs2.core.Enums.eCalcMode CalcMode,
                                        ref dsAdmin.tblStayAdditionsDataTable tStayAdditions,
                                        ref string sProtocol);


        public event doCardiac evDoCardiac;
        public delegate qs2.core.Enums.cDoProdukt doCardiac(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                        qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                        qs2.core.Enums.eStayTyp StayTyp,
                                        qs2.core.license.doLicense.eApp Application,
                                        qs2.core.vb.dsObjects.tblStayRow rStay,
                                        qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                        object r,
                                        System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                        ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                        ref qs2.core.Enums.eCalcMode CalcMode,
                                        ref dsAdmin.tblStayAdditionsDataTable tStayAdditions, 
                                        ref string sProtocol);
        
        public event doQTH evDoQTH;
        public delegate qs2.core.Enums.cDoProdukt doQTH(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                        qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                        qs2.core.Enums.eStayTyp StayTyp,
                                        qs2.core.license.doLicense.eApp Application,
                                        qs2.core.vb.dsObjects.tblStayRow rStay,
                                        qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                        object r,
                                        System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                        ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                        ref qs2.core.Enums.eCalcMode CalcMode,
                                        ref dsAdmin.tblStayAdditionsDataTable tStayAdditions,
                                        ref string sProtocol);

        public event doNC evDoNC;
        public delegate qs2.core.Enums.cDoProdukt doNC(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                        qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                        qs2.core.Enums.eStayTyp StayTyp,
                                        qs2.core.license.doLicense.eApp Application,
                                        qs2.core.vb.dsObjects.tblStayRow rStay,
                                        qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                        object r,
                                        System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                        ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                        ref qs2.core.Enums.eCalcMode CalcMode,
                                        ref dsAdmin.tblStayAdditionsDataTable tStayAdditions,
                                        ref string sProtocol);

        public event doTestProduct evDoTestProduct;
        public delegate qs2.core.Enums.cDoProdukt doTestProduct(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                        qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                        qs2.core.Enums.eStayTyp StayTyp,
                                        qs2.core.license.doLicense.eApp Application,
                                        qs2.core.vb.dsObjects.tblStayRow rStay,
                                        qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                        object r,
                                        System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                        ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                        ref qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                        ref qs2.core.Enums.eCalcMode CalcMode,
                                        ref dsAdmin.tblStayAdditionsDataTable tStayAdditions,
                                        ref string sProtocol);
        

         




        public void initialize(string Application)
        {
            if (this.isIntilaized)
            {
                return;
            }
            
            this.isIntilaized = true;
        }

        public bool DefaultValuesLoaded = false;


        public void  doProduktDelegate(qs2.core.Enums.eDoProduktMode DoProduktMode,
                                             qs2.core.vb.dsAdmin.tblRelationshipRow rRelationsship,
                                             qs2.core.Enums.eStayTyp StayTyp,
                                             qs2.core.license.doLicense.eApp Application, 
                                             qs2.core.vb.dsObjects.tblStayRow rStay, 
                                             qs2.core.vb.dsObjects.tblObjectRow rPatient,
                                             dataStay dataStayProdukt, 
                                             System.Collections.Generic.List<qs2.core.vb.dsAdmin.tblStayAdditionsRow> arrStayAdditions,
                                             ref System.Collections.Generic.List<qs2.design.auto.workflowAssist.autoForm.autoUI.cLstRefresh> lstControlsFormRefresh,
                                             ref qs2.core.vb.dsAdmin.protokollDataTable protocolToAdd,
                                             qs2.core.vb.dsAdmin.protokollDataTable protocolTotal,
                                             ref System.Collections.Generic.List<qs2.core.generic.retValue> ProcGroups,
                                             ref qs2.core.Enums.eCalcMode CalcMode,
                                             ref dsAdmin.tblStayAdditionsDataTable tStayAdditions,
                                             ref qs2.core.Enums.cDoProdukt retDoProdukt,
                                             ref string sProtocol)
        {
            try 
            {
                if (Application == core.license.doLicense.eApp.VASCULAR)
                {
                    retDoProdukt = this.evDoVASCULAR.Invoke(DoProduktMode, rRelationsship, StayTyp, Application, rStay, rPatient,
                                            dataStayProdukt.coreStaysProducts.r,
                                            arrStayAdditions,
                                            ref lstControlsFormRefresh, ref protocolToAdd, ref protocolTotal, ref   CalcMode,
                                            ref tStayAdditions, ref sProtocol);
                }
                else if (Application == core.license.doLicense.eApp.CARDIAC)
                {
                    retDoProdukt = this.evDoCardiac.Invoke(DoProduktMode, rRelationsship, StayTyp, Application, rStay, rPatient,
                                                    dataStayProdukt.coreStaysProducts.r,
                                                    arrStayAdditions,
                                                    ref lstControlsFormRefresh, ref protocolToAdd, ref protocolTotal,  ref CalcMode,
                                                    ref tStayAdditions, ref sProtocol);

                }
                else if (Application == core.license.doLicense.eApp.NC)
                {
                    retDoProdukt = this.evDoNC.Invoke(DoProduktMode, rRelationsship, StayTyp, Application, rStay, rPatient,
                                                    dataStayProdukt.coreStaysProducts.r,
                                                    arrStayAdditions,
                                                    ref lstControlsFormRefresh, ref protocolToAdd, ref protocolTotal, ref CalcMode,
                                                    ref tStayAdditions, ref sProtocol);

                }
                else if (Application == core.license.doLicense.eApp.QTH)
                {
                    retDoProdukt = this.evDoQTH.Invoke(DoProduktMode, rRelationsship, StayTyp, Application, rStay, rPatient,
                                                dataStayProdukt.coreStaysProducts.r,
                                                arrStayAdditions,
                                                ref lstControlsFormRefresh, ref protocolToAdd, ref protocolTotal, ref CalcMode,
                                                ref tStayAdditions, ref sProtocol);

                }
                else if (Application == core.license.doLicense.eApp.TestProduct)
                {
                    retDoProdukt = this.evDoTestProduct.Invoke(DoProduktMode, rRelationsship, StayTyp, Application, rStay, rPatient,
                                                        dataStayProdukt.coreStaysProducts.r,
                                                        arrStayAdditions,
                                                        ref lstControlsFormRefresh, ref protocolToAdd, ref protocolTotal, ref CalcMode,
                                                        ref tStayAdditions, ref sProtocol);
                }
             
            }
            catch (Exception ex)
            {
                throw new Exception("autoUI.doProductDelegate: " + ex.ToString());
            }
        }
        
        public qs2.core.vb.dsAdmin.dbAutoUIRow addOwnMultiControl(Control cont, cTabTag cTagTab, UltraTab tab, 
                            System.Guid keyParentFrame, ref qs2.core.vb.dsAdmin dsAdminUI, 
                            qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI,
                            string Application, string Participant, ref int typeLoading,
                            ref string protocollForAdmin, ref  bool ProtocolWindow,
                            ref System.Guid LastIDGroup,
                            ref int controlLevel, ref bool FirstLevel, ref int SerialNr,
                            ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                            string FldShortTabPageParent, string FldShortGroupBoxParent, ref Nullable<Guid> IDGuidParent, ref string IDGuidsParent)
        {
            try
            {
                //if (cont.Name.Trim().ToLower().Equals(("StayComplete").Trim().ToLower()))
                //{
                //    string xy = "";
                //}

                qs2.core.vb.dsAdmin.dbAutoUIRow rNew = this.addAutoUI(ref dsAdminUI);
                SerialNr += 1;
                qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)cont;
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1.OwnFldShort, "StayComplete", false))
                //{
                //    string xy = "";
                //}

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

                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownGroupBox1._FldShort, "GroupBoxNotExists", false))
                //{
                //    string xy = "";
                //}
                ownGroupBox1.doControl();
                ownGroupBox1.ownControlCriteria1.getData(ownGroupBox1, ownGroupBox1._FldShort, core.Enums.eControlType.GroupBox, null,
                                                        ref ownGroupBox1.ownControlUI1, null, ref protocollForAdmin, ref ProtocolWindow, ownGroupBox1.OwnFieldForALLProducts, false, false);
                ownGroupBox1.doVisible();
                //ownGroupBox1.isLoaded = true;
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
                //return null;
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
                //ownTab1.doText();
                ownTab1.parentAutoUI = parentAutoUI;
                ownTab1.ID = ID;
                ownTab1.IDGroup = IDGroup;
                ownTab1.FldShortTabPageParent = FldShortTabPageParent;
                ownTab1.FldShortGroupBoxParent = FldShortGroupBoxParent;
                ownTab1.rAutoUI = rNew;
                //ownTab1.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                //ownTab1.Style = UltraTabControlStyle.Wizard;

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
               

                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownTab1._FldShort, "PreOpDiagBAA", false))
                //{
                //    string xy = "";
                //}
                if (!ownTab1.ownControlUI1.IsVisible_Criteriaxy)
                {
                    ownTab1.Visible = ownTab1.ownControlUI1.IsVisible_Criteriaxy; 
                    //string xy = "";
                }
                //ownTab1.tagTab = (cTabTag)tab.Tag;
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
            //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(tabPage.Tag.ToString(), "tabPreOpDiagBAA", false))
            //{
            //    string xy = "";
            //}

            if (tabCont.Tag != null)
            {
                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                tabCont.Text = qs2.core.language.sqlLanguage.getRes(tabPage.Tag.ToString(), core.Enums.eResourceType.Label, ownTab1.ownControlCriteria1.IDParticipant, ownTab1.ownControlCriteria1.Application, ref  rLangFoundReturn).Trim();
                //ownTab1.ownControlCriteria1.getData(tabCont.TabControl, tabCont.Tag.ToString(), core.Enums.eControlType.TabPage, null, 
                //                                    ref ownTab1.ownControlUI1, null, ref protocollForAdmin, ref ProtocolWindow, ownTab1.OwnFieldForALLProducts);

                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(tabCont.Tag.ToString(), "tabCardiac_Complications_Artap", false))
                //{
                //    string xy = "";
                //}

                qs2.design.auto.ownMCCriteria ownMCCriteriaTabPage = new ownMCCriteria();
                ownMCCriteriaTabPage.Application = Application;
                ownMCCriteriaTabPage.IDParticipant = Participant;
                ownMCCriteriaTabPage.getData(tabCont.TabControl, tabPage.Tag.ToString(), core.Enums.eControlType.TabPage, null,
                                                    ref ownMCUITabPage, null, ref protocollForAdmin, ref ProtocolWindow, ownTab1.OwnFieldForALLProducts, false, false);

                bool TabPageIsVisible = autoUI.doVisibleTabPage(ownMCUITabPage);
                tabPage.Visible = TabPageIsVisible;
                //ownTab1.Tabs[tabPage.Key].Visible = TabPageIsVisible;

                //if (!ownMCUITabPage.IsVisible_Criteriaxy)
                //{
                //    tabPage.Visible = ownMCUITabPage.IsVisible_Criteriaxy;
                //    ownTab1.Tabs[tabPage.Key].Visible = ownMCUITabPage.IsVisible_Criteriaxy;
                //}
                //if (!ownMCUITabPage.IsVisible_LicenseKey)
                //{
                //    string xy = "";
                //    tabPage.Visible = ownMCUITabPage.IsVisible_LicenseKey;
                //    ownTab1.Tabs[tabPage.Key].Visible = ownMCUITabPage.IsVisible_LicenseKey;
                //}
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
        
        public void initMulticontrol(qs2.design.auto.multiControl.ownMultiControl ownControlChild,
                                        ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay)
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

        public void multicontrolFillData(ref qs2.design.auto.workflowAssist.autoForm.dataStay dataStay,
                                            qs2.design.auto.multiControl.ownMultiControl ownControlChild)
        {
            try
            {
                if (ownControlChild.ownMCCriteria1.rCriteria != null)
                {
                    if (ownControlChild.ownMCUI1.controlIsDbDataControl(ownControlChild))
                    {
                        ownControlChild.ownMCDataBind1.setBindingContext(ownControlChild, dataStay);
                        ownControlChild.ownMCDataBind1.BindControlToData(ownControlChild, false, dataStay, true);
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
                   //if (rCont.StayTyp.ToString() == loadedStayTyp.ToString())
                   //{
                       if (rCont.control.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                       {
                           qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)rCont.control;
                           lstMultiControlReturn.Add(ownMultiControl1);
                           if (!ownMultiControl1.ownMCCriteria1._isInitializedCriteria)
                           {
                               ownMultiControl1.parentAutoUI.autoUI1.initMulticontrol(ownMultiControl1, ref ownMultiControl1.parentAutoUI.dataStay);
                               //ownMultiControl1.parentAutoUI.autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
                           }
                           if (!doNotDataBinding && ownMultiControl1.ownMCDataBind1.Binding1 == null)
                           {
                               ownMultiControl1.parentAutoUI.autoUI1.multicontrolFillData(ref ownMultiControl1.parentAutoUI.dataStay, ownMultiControl1);
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
                   //}
               }

               if (lstMultiControlReturn.Count > 1)
               {
                   //throw new Exception("autoUI.getMultiControl: lstMultiControlReturn.Count > 1 for FldShort '" + FldShort + "'!");
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
                       //throw new Exception("");
                       //qs2.core.Protocol.doExcept(ExceptTxt, "autoUI.getMultiControl", "", false, true, Application,
                       //                             qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Info);  //lthxy
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


        public static string getTitleWindow(string IDResTitleForm, qs2.core.vb.dsObjects.tblStayRow rStay, string Application,
                                                ref qs2.core.vb.dsObjects.tblObjectRow rPatient)
        {
            string sTitle = "";

            string PatientInfo = "";
            string Dates = "";

            PatientInfo = qs2.core.language.sqlLanguage.getRes("Patientname") + ": " + rPatient.NameCombination.Trim();

            if (!rStay.IsAdmitDtNull())
            {
                Dates = ", " + qs2.core.language.sqlLanguage.getRes("AdmitDt") + ": " + rStay.AdmitDt.ToString("dd.MM.yyyy") + "";
            }
            
            if (!rStay.IsSurgDtStartNull())
            {
                Dates += ", " + qs2.core.language.sqlLanguage.getRes("SurgDtStart") + ": " + rStay.SurgDtStart.ToString("dd.MM.yyyy") + ""; 
            }

            sTitle = qs2.core.language.sqlLanguage.getRes(IDResTitleForm) + ": " + rStay.MedRecN.Trim() + " (" +
                                qs2.core.language.sqlLanguage.getRes(Application.ToString()) + ")" + ", " + PatientInfo.Trim() + Dates.Trim();

            return sTitle.Trim();
        }


        public void addToDoMainFormStayUI1(doMainFormStayUI doMainFormStayUI1)
        {
            this.evdoMainFormStayUI += doMainFormStayUI1;
        }
        public void runDoMainFormStayUI1(string Fct)
        {
            this.evdoMainFormStayUI.Invoke(Fct);
        }
        //AddNewProduct
        public void addVASCULAR(doVASCULAR doVASCULAR1)
        {
            this.evDoVASCULAR += doVASCULAR1;
        }
        public void addCARDIAC(doCardiac doCardiac1)
        {
            this.evDoCardiac += doCardiac1;
        }
        public void addNC(doNC doNC1)
        {
            this.evDoNC += doNC1;
        }
        public void addQTH(doQTH doQTH1)
        {
            this.evDoQTH += doQTH1;
        }
        public void addTestProduct(doTestProduct doTestProduct1)
        {
            this.evDoTestProduct += doTestProduct1;
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
           //public bool wasClicked = false;
       }
}
