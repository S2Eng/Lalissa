using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;



namespace qs2.design.auto
{

    
    public class ownMCCriteria
    {
        public string Application = "";
        public string IDParticipant = "";
        public bool _ControlIsFormatted = false;

        public static qs2.core.vb.dsAdmin dsAdminWork = null;
        public static qs2.core.vb.sqlAdmin sqlAdminWork = null;
        public static qs2.core.vb.dsObjects dsObjectsWork = null;
        public static qs2.core.vb.sqlObjects sqlObjectsWork = null;

        public qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria = null;
        public System.Collections.Generic.List<qs2.core.Enums.cVariables> lstVariablesClassification = new List<core.Enums.cVariables>();
        public System.Collections.Generic.List<string> lstLicenseKeys = new List<string>();
        public qs2.core.vb.dsAdmin.tblSelListEntriesObjRow[] arrSelListEntriesObj = null;
        public ownMCRelationship MCRelationship = null;
        public qs2.core.vb.dsAdmin.tblCriteriaOptRow[] arrCriteriaOptxy = null;
        public qs2.core.vb.dsAdmin.tblSideLogicRow[] arrSideLogicxy = null;
        public qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = null;
        public bool IsNullableInDb = false;
        public qs2.core.generic.retValue defaultDBValue = null;
        public bool IsKeyDb = false;

        public System.Windows.Forms.ErrorProvider errorProvider1 = null;
        public qs2.sitemap.workflowAssist.form.contAutoUI parentAutoUI = null;
        public qs2.design.auto.workflowAssist.autoForm.cTabTag tagTab;
        public bool _isInitializedGetData = false;
        public bool _isInitializedCriteria = false;
        public bool _isInitializedVar = false;

        public qs2.design.auto.multiControl.ownMCLogicRelation ownMCLogicRelation1 = null;
        public qs2.design.auto.multiControl.ownMCCombo ownMCCombo1 = new multiControl.ownMCCombo();

        public bool DefaultValuesCriteria = false;

        public static int counterNewCriteriaAssignments = 0;

        public static qs2.core.vb.businessFramework b = null;

        public string CombinationComboBoxAsDropDown = qs2.core.sqlTxt.and.ToString().Trim();
        public bool NoDefaultValuePossible = false;
        public bool defaultValueIsLoaded = false;
        public static List<qs2.core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive = null;
        public static List<qs2.core.vb.businessFramework.cSelListAndObj> lstRolesForUserAll = null;

        public static qs2.core.db.ERSystem.businessFramework b2 = new core.db.ERSystem.businessFramework();
        public static core.license.dsLicense dsLicense1 = null;

        public static Nullable<DateTime> dNowAssign = null;









        public void initControl()
        {
            try
            {
                if (this._isInitializedVar)
                    return;

                //this.lstVariablesClassification = new List<core.Enums.cVariables>();
                ownMCCriteria.initSharedDataSets(true);

                this.MCRelationship = new ownMCRelationship();
                this.MCRelationship.initControl(this.Application);

                this.ownMCLogicRelation1 = new multiControl.ownMCLogicRelation();

                this._isInitializedVar = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.initControl", "", false, true, this.Application,
                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        
        public static void initSharedDataSets(bool GetAllRolesUser)
        {
            try
            {
                if (ownMCCriteria.sqlAdminWork == null)
                {
                    ownMCCriteria.sqlAdminWork = new core.vb.sqlAdmin();
                    ownMCCriteria.sqlAdminWork.initControl();
                }

                if (ownMCCriteria.b == null)
                {
                    ownMCCriteria.b = new core.vb.businessFramework();
                }
                if (ownMCCriteria.sqlObjectsWork == null)
                {
                    ownMCCriteria.sqlObjectsWork = new core.vb.sqlObjects();
                    ownMCCriteria.sqlObjectsWork.initControl();
                }
                if (ownMCCriteria.dsObjectsWork == null)
                {
                    ownMCCriteria.dsObjectsWork = new core.vb.dsObjects();
                }
                if (ownMCCriteria.dsAdminWork == null)
                {
                    ownMCCriteria.dsAdminWork = new core.vb.dsAdmin();
                }

                if (GetAllRolesUser)
                {
                    if (ownMCCriteria.lstRolesForUserActive == null)
                    {
                        ownMCCriteria.lstRolesForUserActive = new List<qs2.core.vb.businessFramework.cSelListAndObj>();
                        ownMCCriteria.b.getAllRolesForUser(qs2.core.vb.actUsr.rUsr.ID, ref ownMCCriteria.lstRolesForUserActive, true);
                    }
                    if (ownMCCriteria.lstRolesForUserAll == null)
                    {
                        ownMCCriteria.lstRolesForUserAll = new List<qs2.core.vb.businessFramework.cSelListAndObj>();
                        ownMCCriteria.b.getAllRolesForUser(qs2.core.vb.actUsr.rUsr.ID, ref ownMCCriteria.lstRolesForUserAll, false);
                    }
                }

                if (ownMCCriteria.dsLicense1 == null)
                {
                    ownMCCriteria.dsLicense1 = new core.license.dsLicense();
                    core.license.doLicense doLicense1 = new core.license.doLicense();
                    doLicense1.getAppsLicensedForParticipant(ownMCCriteria.dsLicense1, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim(), true);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("initSharedDataSets: " + ex.ToString());
            }
        }

        public void getDataInit2(System.Windows.Forms.Control ctl, string FldShort,
                        qs2.core.Enums.eControlType controlType,
                        UltraComboEditor ComboBox, ref qs2.design.auto.multiControl.ownMCUI ownControlUI1,
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControlPicture, ref string protocollForAdmin, ref  bool ProtocolWindow,
                        bool FieldForALLProducts, bool ControlWasCheckBox, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            qs2.design.auto.multiControl.ownMultiControl ownMultiControlExcept = null;
            try
            {
                qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                if (this._isInitializedGetData)
                    return;

                this.initControl();
                qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();

                //if (ownControlUI1 != null)
                //{

                //}

                if (FldShort.Trim() == "")
                {
                    if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        qs2.core.Protocol.doExcept("FldShort='' for ControlName '" + ctl.Name + "'  ", "ownMCCriteria.getData", "", false, true, this.Application,
                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                    }
                }

                //qs2.core.generic.CheckMemorySizeProcess();
                string IDApplicationTmp;
                // OMC.IDApplication.Check
                qs2.core.vb.dsAdmin.tblCriteriaRow[] arrCriteria = null;
                if (FieldForALLProducts)
                {
                    IDApplicationTmp = core.license.doLicense.eApp.ALL.ToString();
                    arrCriteria = ownMCCriteria.sqlAdminWork.getCriterias(qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, IDApplicationTmp,
                                                                false, false, false, "", "", false);
                }
                else
                {
                    IDApplicationTmp = Application;
                    arrCriteria = ownMCCriteria.sqlAdminWork.getCriterias(qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteria.idRam, FldShort, IDApplicationTmp,
                                                                false, false, false, "", "", false);
                }

                if (arrCriteria.Length == 1)
                {
                    this.rCriteria = (qs2.core.vb.dsAdmin.tblCriteriaRow)arrCriteria[0];

                    this.lstVariablesClassification.Clear();
                    qs2.core.vb.businessFramework b = new core.vb.businessFramework();
                    this.lstVariablesClassification = b.getVariablesClassification(this.rCriteria.Classification.Trim());
                    this.lstLicenseKeys.Clear();
                    if (rCriteria.LicenseKey.Trim() == "")
                    {
                        ownControlUI1.IsVisible_LicenseKey = true;
                    }
                    else
                    {
                        if (qs2.core.ENV.developModus)
                        {
                            ownControlUI1.IsVisible_LicenseKey = true; 
                        }
                        else
                        {
                            this.lstLicenseKeys = ownMCCriteria.b.getVariablesLicenseKeys(this.rCriteria.LicenseKey.Trim());
                            ownControlUI1.IsVisible_LicenseKey = ownMCCriteria.b2.checkLicenseKey(this.lstLicenseKeys, FldShort, Application.ToString().Trim());
                        }
                    }

                    if (this.rCriteria.Used)
                    {
                        if (!this.rCriteria.UsedCustomer)
                        {
                            ownControlUI1.IsVisible_Criteriaxy = false;
                        }
                        else
                        {
                            ownControlUI1.IsVisible_Criteriaxy = true;
                        }
                    }
                    else
                    {
                        ownControlUI1.IsVisible_Criteriaxy = false;
                    }

                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShort, "VSPuImSz", false))
                    //{
                    //    string xy = "";
                    //}

                    //qs2.core.ui.addWatch("Criteria.getRelationsship: start " + FldShort.Trim(), true);
                    qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                    this.MCRelationship.getRelationsship(FldShort, IDApplicationTmp);
                    //qs2.core.ui.addWatch("Criteria.getCriteriasOpt: start " + FldShort.Trim(), true);
                    //this.arrCriteriaOpt = ownMCCriteria.sqlAdminWork.getCriteriasOpt(qs2.design.auto.ownMCCriteria.dsAdminWork, qs2.core.vb.sqlAdmin.eTypSelCriteriaOpt.idRam, FldShort, IDApplicationTmp);
                    //qs2.core.ui.addWatch("Criteria.getSideLogic: start " + FldShort.Trim(), true);
                    //this.arrSideLogic = ownMCCriteria.sqlAdminWork.getSideLogic(qs2.core.vb.sqlAdmin.dsAllAdmin, core.vb.sqlAdmin.eTypeSideLogic.FldShortApplication, -999, FldShort, IDApplicationTmp);
                    //qs2.core.ui.addWatch("Criteria.getSysColumnRow: start " + FldShort.Trim(), true);
                    this.rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(this.rCriteria.SourceTable, this.rCriteria.FldShort, qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);
                    //qs2.core.ui.addWatch("Criteria.getSelListEntrysObj: start " + FldShort.Trim(), true);
                    this.arrSelListEntriesObj = ownMCCriteria.sqlAdminWork.getSelListEntrysObj(-999, core.vb.sqlAdmin.eDbTypAuswObj.Criterias, "", qs2.design.auto.ownMCCriteria.dsAdminWork,
                                                                                core.vb.sqlAdmin.eTypAuswahlObj.allFldShortRam,
                                                                                IDApplicationTmp, -999, FldShort, -999, "", -999);


                    if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                        ownMultiControlExcept = ownMultiControl1;

                        if (ownMultiControl1.hasINCondition)
                        {
                            //bool HasInCondition = true;
                        }
                        else
                        {
                            //qs2.core.ui.addWatch("Criteria.loadDefaultDBValue: start " + FldShort.Trim(), true);
                            this.loadDefaultDBValue(ref ownMultiControl1);
                            //qs2.core.ui.addWatch("Criteria.loadDefaultDBValue: end " + FldShort.Trim(), true);

                            if (controlType == core.Enums.eControlType.ComboBox ||
                                controlType == core.Enums.eControlType.ComboBoxNoDb)
                            {
                                //qs2.core.ui.addWatch("Criteria.initCombo: start " + FldShort.Trim(), true);
                                this.ownMCCombo1.initCombo(ownMultiControl1);
                                //qs2.core.ui.addWatch("Criteria.initCombo: end " + FldShort.Trim(), true);
                                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1.OwnFldShort, "Surgeon", false))
                                {
                                    bool bStop = true;
                                }
                                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1.OwnFldShort, "Surg_Assist1", false))
                                {
                                    bool bStop = true;
                                }

                                if (this.ownMCCombo1.TypeComboBox == qs2.core.Enums.cVariablesValues.Roles)
                                {
                                    ownMultiControl1.setLabels2(false, false, true);
                                }
                                else
                                {
                                    if (!this.rCriteria.UserDefined)
                                    {
                                        ownMultiControl1.setLabels2(false, true, false);
                                    }
                                }
                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                            {
                                this.ownMCCombo1.initCombo(ownMultiControl1);
                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                            {
                                this.ownMCCombo1.initCombo(ownMultiControl1);
                                ownMultiControl1.ControlForDropDown.initControl();
                            }
                            else if (controlType == core.Enums.eControlType.Picture)
                            {
                                //string xy = "";
                            }

                            //qs2.core.ui.addWatch("Criteria.checkAssignments: start " + FldShort.Trim(), true);
                            bool HasCriteria = false;
                            System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                            this.checkAssignments(ctl, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow,
                                                    ref lstElementsActive, FldShort, false, ownMCCriteria.sqlAdminWork, ref HasCriteria, false, -999);
                            //qs2.core.ui.addWatch("Criteria.checkAssignments: end " + FldShort.Trim(), true);
                        }
                         
                        ownMultiControl1.ownMCUI1.getColorsFromClassification(ref ownMultiControl1);
                        if (ownMultiControl1.OwnOnlyForProducts.Trim() != "")
                        {
                            if (!ownMultiControl1.OwnOnlyForProducts.Trim().ToLower().Contains(IDApplicationTmp.Trim().ToLower()))
                            {
                                ownControlUI1.IsVisible_Criteriaxy = false;
                            }
                        }

                    }
                    //string xyxy = "";
                }
                else
                {
                    this.WriteErrorNoCriteria(FldShort, ref ownControlUI1, ref ctl);
                }

                this._isInitializedGetData = true;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.getData", FldShort, false, true, this.Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        
        public void getData(System.Windows.Forms.Control ctl, string FldShort,
                                qs2.core.Enums.eControlType controlType,
                                UltraComboEditor ComboBox, ref qs2.design.auto.multiControl.ownMCUI ownControlUI1,
                                qs2.design.auto.multiControl.ownMultiControl ownMultiControlPicture, ref string protocollForAdmin, ref  bool ProtocolWindow,
                                bool FieldForALLProducts, bool ControlWasCheckBox, bool ComboBoxCheckThreeStateBoxAsDropDown)
        {
            qs2.design.auto.multiControl.ownMultiControl ownMultiControlExcept = null;
            try
            {
                this.getDataInit2(ctl, FldShort, controlType, ComboBox, ref ownControlUI1, ownMultiControlPicture, ref protocollForAdmin, ref ProtocolWindow,
                                FieldForALLProducts, ControlWasCheckBox, ComboBoxCheckThreeStateBoxAsDropDown);

                if (this._isInitializedCriteria)
                    return;


                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShort, "MedRecN", false))
                {
                    //string xy = "";
                }

                if (this.rCriteria != null)
                {
                    if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                        ownMultiControlExcept = ownMultiControl1;
                        //this.loadDefaultDBValue(ref ownMultiControl1);

                        if (!ownMultiControl1.hasINCondition)
                        {
                            if (controlType == core.Enums.eControlType.ComboBox ||
                                controlType == core.Enums.eControlType.ComboBoxNoDb)
                            {
                                //this.ownMCCombo1.initCombo(ownMultiControl1);
                                //qs2.core.ui.addWatch("Criteria.loadCombo: start " + FldShort.Trim(), true);
                                this.ownMCCombo1.loadCombo(ownMultiControl1, "", this.CombinationComboBoxAsDropDown, false);
                                //qs2.core.ui.addWatch("Criteria.loadCombo: end " + FldShort.Trim(), true);
                                if (this.rCriteria.UserDefined)
                                {
                                    if (this.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.SelList)
                                    {
                                        ownMultiControl1.ownMCUI1.doButtonAddSelList(ownMultiControl1);
                                    }
                                    else
                                    {
                                        //string xy = "";
                                    }
                                }

                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                            {
                                //this.ownMCCombo1.initCombo(ownMultiControl1);
                                this.ownMCCombo1.loadComboThreeStateCheckBox(ownMultiControl1, ControlWasCheckBox, false);
                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                            {
                                string IDGroupOther = "";
                                if (ComboBoxCheckThreeStateBoxAsDropDown)
                                {
                                    IDGroupOther = "ComboBoxCheckThreeStateBox";
                                }
                                //this.ownMCCombo1.initCombo(ownMultiControl1);
                                ownMultiControl1.ControlForDropDown.initControl();
                                this.ownMCCombo1.loadCombo(ownMultiControl1, IDGroupOther.Trim(), this.CombinationComboBoxAsDropDown, ComboBoxCheckThreeStateBoxAsDropDown);
                            }
                            else if (controlType == core.Enums.eControlType.Picture)
                            {
                                //this.ownControlPictures1.getRelationshipPictures(ref ownMultiControlPicture, this.arrRelationships, this.IDApplication.ToString());

                                //qs2.design.auto.multiControl.ownMultiControl ownControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                                //foreach (string IDResPic in ownControl1._FldShorts)
                                //{
                                //    qs2.core.language.dsLanguage.RessourcenRow rResHelp = qs2.core.language.sqlLanguage.getResRow(IDResPic, core.Enums.eResourceType.PictureEnabled, this.IDParticipant, this.IDApplication.ToString());
                                //    if (rResHelp != null)
                                //    {
                                //        if (!rResHelp.IsfileBytesNull())
                                //        {
                                //            qs2.core.print.dsQryAuto.picturesRow rResPicNew = (qs2.core.print.dsQryAuto.picturesRow)this.tResPictures.NewRow();
                                //            rResPicNew.IDRessource = rResHelp.IDRes;
                                //            rResPicNew.picture = rResHelp.fileBytes;
                                //            rResPicNew.fileType = rResHelp.fileTyp;
                                //            this.tResPictures.Rows.Add(rResPicNew);
                                //        }
                                //    }
                                //}
                            }
                            //bool HasCriteria = false;
                            //System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                            //this.checkAssignments(ctl, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow,
                            //                        ref lstElementsActive, FldShort, false, ownMCCriteria.sqlAdminWork, ref HasCriteria, false, -999);
                        }

                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                    {
                        if (this.rCriteria.Used)
                        {
                            if (!this.rCriteria.UsedCustomer)
                            {
                                ownControlUI1.IsVisible_Criteriaxy = false;
                            }
                            else
                            {
                                ownControlUI1.IsVisible_Criteriaxy = true;
                            }
                        }
                        else
                        {
                            ownControlUI1.IsVisible_Criteriaxy = false;
                        }
                        bool HasCriteria = false;
                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                        this.checkAssignments(ctl, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow,
                                                ref lstElementsActive, FldShort, false, ownMCCriteria.sqlAdminWork, ref HasCriteria, false, -999);
                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    {
                        if (this.rCriteria.Used)
                        {
                            if (!this.rCriteria.UsedCustomer)
                            {
                                ownControlUI1.IsVisible_Criteriaxy = false;
                            }
                            else
                            {
                                ownControlUI1.IsVisible_Criteriaxy = true;
                            }
                        }
                        else
                        {
                            ownControlUI1.IsVisible_Criteriaxy = false;
                        }
                        bool HasCriteria = false;
                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                        this.checkAssignments(ctl, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow,
                                                ref lstElementsActive, FldShort, false, ownMCCriteria.sqlAdminWork, ref HasCriteria, false, -999);
                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        if (this.rCriteria.Used)
                        {
                            if (!this.rCriteria.UsedCustomer)
                            {
                                ownControlUI1.IsVisible_Criteriaxy = false;
                            }
                            else
                            {
                                ownControlUI1.IsVisible_Criteriaxy = true;
                            }
                        }
                        else
                        {
                            ownControlUI1.IsVisible_Criteriaxy = false;
                        }
                        bool HasCriteria = false;
                        System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                        this.checkAssignments(ctl, ownMCRelationship.eTypAssignments.Roles, ref protocollForAdmin, ref ProtocolWindow,
                                                ref lstElementsActive, FldShort, false, ownMCCriteria.sqlAdminWork, ref HasCriteria, false, -999);
                    }
                    //System.Collections.Generic.List<string> lstElementsActive = new System.Collections.Generic.List<string>();
                    //this.checkAssignmentsxy(ctl, ownMCRelationship.eTypAssignments.Chapter, ref protocollForAdmin, ref ProtocolWindow,
                    //                        ref lstElementsActive, ref FldShort);


                    //string xyxy = "";

                }
                else
                {
                    this.WriteErrorNoCriteria(FldShort, ref ownControlUI1, ref ctl);
                }

                this._isInitializedCriteria = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.getData", FldShort, false, true, this.Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
       
        public void WriteErrorNoCriteria(string FldShort, ref qs2.design.auto.multiControl.ownMCUI ownControlUI1, 
                                            ref Control ctl)
        {
            try
            {
                //if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                //{

                //}
                //else
                //{
                ownControlUI1.IsVisible_Criteriaxy = false;
                // if (this.parentAutoUI != null)
                //this.parentAutoUI.contAutoProtokoll1.addRow(this.tagTab.text, FldShort, qs2.core.language.sqlLanguage.getRes("NoCriteriaForControl") + "!", null, core.vb.qs2.Resources.getRes.ePicture.ico_sys, true);   

                bool doProt = true;
                if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                {
                    qs2.design.auto.multiControl.ownMultiControl ownMultiControlProt = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                    if (ownMultiControlProt != null && ownMultiControlProt.OwnOnlyForProducts.Trim() != "" &&
                         !ownMultiControlProt.OwnOnlyForProducts.Trim().ToLower().Contains(this.Application.Trim().ToLower()))
                    {
                        doProt = false;
                    }
                }

                if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() && doProt)
                {
                    qs2.core.Protocol.doExcept("No Criteria found for Field " + FldShort + "", "ownMCCriteria.getData", FldShort, false, true,
                                                this.Application,
                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                }
                //}

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.getData", FldShort, false, true, this.Application,
                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public void loadDefaultDBValue(ref qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1._FldShort, "IDParticipant", false))
                {
                    //string xy = "";
                }

                bool IsDefaultValue = false;
                if (!this.rCriteria.IsDefaultValuesNull())
                {
                    if (!this.rCriteria.DefaultValues.Trim().Equals(""))
                    {
                        //qs2.core.generic.retValue ret = new qs2.core.generic.retValue();
                        this.defaultDBValue = qs2.core.generic.getValue(ownMultiControl1._controlType, this.rCriteria.DefaultValues.Trim(),
                                                                                    Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        IsDefaultValue = true;
                        this.DefaultValuesCriteria = true;

                    }
                }
                if (!this.rCriteria.IsDefaultValuesCustomerNull())
                {
                    if (!this.rCriteria.DefaultValuesCustomer.Trim().Equals(""))
                    {
                        //qs2.core.generic.retValue ret = new qs2.core.generic.retValue();
                        this.defaultDBValue = qs2.core.generic.getValue(ownMultiControl1._controlType, this.rCriteria.DefaultValuesCustomer.Trim(),
                                                                                    Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        IsDefaultValue = true;
                        this.DefaultValuesCriteria = true;

                    }
                }

                if (!IsDefaultValue)
                {
                    if (this.rColSys != null)
                    {
                        System.Collections.Generic.List<string> lstTablesNoDateTimeCheck = new System.Collections.Generic.List<string>();
                        lstTablesNoDateTimeCheck.Add(ownMCCriteria.dsObjectsWork.tblStay.TableName);

                        this.defaultDBValue = qs2.core.dbBase.getDefaultDBValue(ref this.rColSys, true, lstTablesNoDateTimeCheck, ref this.NoDefaultValuePossible);
                        this.IsNullableInDb = qs2.core.dbBase.checkColSysNullable(ref this.rColSys);
                        this.IsKeyDb = qs2.core.SysDB.sqlSysDB.IsKeyInDb(this.rCriteria.SourceTable, this.rCriteria.FldShort, qs2.core.SysDB.sqlSysDB.dsSysDBAll);
                        //ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, this.defaultDBValue.valueObj);
                    }
                    else
                    {
                        this.defaultDBValue = new core.generic.retValue();
                        if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBox ||
                            ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                        {
                            this.defaultDBValue.valueObj = -1;
                            this.defaultDBValue.valueStr = "-1";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                        {
                            this.defaultDBValue.valueObj = -1;
                            this.defaultDBValue.valueStr = "-1";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                        {
                            this.defaultDBValue.valueObj = -1;
                            this.defaultDBValue.valueStr = "-1";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.Textfield ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.TextfieldNoDb ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                        {
                            this.defaultDBValue.valueObj = "";
                            this.defaultDBValue.valueStr = "";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.Integer ||
                                ownMultiControl1._controlType == core.Enums.eControlType.IntegerNoDb ||
                                ownMultiControl1._controlType == core.Enums.eControlType.Numeric ||
                                ownMultiControl1._controlType == core.Enums.eControlType.NumericNoDb)
                        {
                            this.defaultDBValue.valueObj = 0;
                            this.defaultDBValue.valueStr = "0";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                        {
                            this.defaultDBValue.valueObj = false;
                            this.defaultDBValue.valueStr = "0";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                        {
                            this.defaultDBValue.valueObj = -1;
                            this.defaultDBValue.valueStr = "-1";
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.DateTime ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.Date ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.Time ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.DateTimeNoDb ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.DateNoDb ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.TimeNoDb)
                        {
                            this.defaultDBValue.valueObj = System.DBNull.Value;
                            this.defaultDBValue.valueStr = "";
                        }
                    }
                }

                this.defaultValueIsLoaded = true;
                if (this.defaultDBValue == null)
                {
                    //bool HasNoDefaultValue = true;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.loadDefaultDBValue", ownMultiControl1._FldShort, false, true,
                                                                this.Application, qs2.core.Protocol.alwaysShowExceptionMulticontrol,
                                                                qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool checkAssignments(System.Windows.Forms.Control ctl, ownMCRelationship.eTypAssignments TypAssignmentToCheck,
                                    ref string protocollForAdmin, ref bool ProtocolWindow,
                                    ref System.Collections.Generic.List<string> lstElementsActive,
                                    string FldShort, bool TranslateSelListInQuery,
                                    qs2.core.vb.sqlAdmin sqlAdminWork, ref bool HasCriteria, 
                                    bool RunAsSystemUser, int UserIDSystemuser)
        {
            try
            {
                if (TypAssignmentToCheck == ownMCRelationship.eTypAssignments.AutoSaveToChapter)
                {
                    dsAdminWork.Clear();
                    string sGroup = "";
                    //if (ownMultiControl1.StayTyp == core.Enums.eStayTyp.Stay)
                    //{
                    //    sGroup = "CHAPTERS0";
                    //}
                    //else if (ownMultiControl1.StayTyp == core.Enums.eStayTyp.FollowUp)
                    //{
                    //    sGroup = "Chapters1";
                    //}
                    //else
                    //{
                    //    throw new Exception("checkChapterAssignmentInDb: ownMultiControl1.StayTyp ' " + ownMultiControl1.StayTyp.ToString() + "'  is wrong!");
                    //}

                    Nullable<System.Guid> IDSelListObjChapter0 = null;
                    bool ExistsInChapter0 = false;
                    sGroup = "CHAPTERS0";
                    qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[] arrSelListWithGroup = null;
                    arrSelListWithGroup = (qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[])sqlAdminWork.getSelListEntrysRelGroup(sGroup, this.IDParticipant, this.Application,
                                                                                                ref dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.IDGroupStrAppRam);   // OMC.IDApplication.Check
                    this.IsInObjArr(ref arrSelListWithGroup, ref ExistsInChapter0, ref this.arrSelListEntriesObj, ref IDSelListObjChapter0);
                    
                    Nullable<System.Guid> IDSelListObjChapter1 = null;
                    bool ExistsInChapter1 = false;
                    sGroup = "CHAPTERS1";
                    arrSelListWithGroup = (qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[])sqlAdminWork.getSelListEntrysRelGroup(sGroup, this.IDParticipant, this.Application,
                                                                                                ref dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.IDGroupStrAppRam);   // OMC.IDApplication.Check
                    this.IsInObjArr(ref arrSelListWithGroup, ref ExistsInChapter1, ref this.arrSelListEntriesObj, ref IDSelListObjChapter1);

                    if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                        this.doChapterAssignmentForControl(ownMultiControl1.OwnFldShort, ref Application, ownMultiControl1.rAutoUI.Chapter.Trim(), "CHAPTERS0",
                                                            ref ProtocolWindow, ref protocollForAdmin, ownMultiControl1.rAutoUI,
                                                            ref IDSelListObjChapter0, ref IDSelListObjChapter1, ref ExistsInChapter0, ref ExistsInChapter1,
                                                            ownMultiControl1.rAutoUI.Chapter.Trim(), ref ownMultiControl1.parentAutoUI.loadedStayTyp);
                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                    {
                        qs2.design.auto.multiControl.ownGroupBox ownGroupBox1 = (qs2.design.auto.multiControl.ownGroupBox)ctl;
                        this.doChapterAssignmentForControl(ownGroupBox1.OwnFldShort, ref Application, ownGroupBox1.rAutoUI.Chapter.Trim(), "CHAPTERS0",
                                                            ref ProtocolWindow, ref protocollForAdmin, ownGroupBox1.rAutoUI,
                                                            ref IDSelListObjChapter0, ref IDSelListObjChapter1, ref ExistsInChapter0, ref ExistsInChapter1,
                                                            ownGroupBox1.rAutoUI.Chapter.Trim(), ref ownGroupBox1.parentAutoUI.loadedStayTyp);
                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                    {
                        qs2.design.auto.multiControl.ownTab ownTab1 = (qs2.design.auto.multiControl.ownTab)ctl;
                        this.doChapterAssignmentForControl(ownTab1.OwnFldShort, ref Application, ownTab1.rAutoUI.Chapter.Trim(), "CHAPTERS0",
                                                            ref ProtocolWindow, ref protocollForAdmin, ownTab1.rAutoUI,
                                                            ref IDSelListObjChapter0, ref IDSelListObjChapter1, ref ExistsInChapter0, ref ExistsInChapter1,
                                                            ownTab1.rAutoUI.Chapter.Trim(), ref ownTab1.parentAutoUI.loadedStayTyp);
                    }
                    else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                    {
                        qs2.design.auto.multiControl.ownMultiGridSelList ownMultiGridSelList1 = (qs2.design.auto.multiControl.ownMultiGridSelList)ctl;
                        this.doChapterAssignmentForControl(ownMultiGridSelList1._FldShortTitle, ref Application, ownMultiGridSelList1.rAutoUI.Chapter.Trim(), "CHAPTERS0",
                                                            ref ProtocolWindow, ref protocollForAdmin, ownMultiGridSelList1.rAutoUI,
                                                            ref IDSelListObjChapter0, ref IDSelListObjChapter1, ref ExistsInChapter0, ref ExistsInChapter1,
                                                            ownMultiGridSelList1.rAutoUI.Chapter.Trim(), ref ownMultiGridSelList1.parentAutoUI.loadedStayTyp);
                    }
                    else
                    {
                        throw new Exception("ownMCCriteria.checkAssignments: Control-Type '" + ctl.GetType().ToString() + "' not allowed for this operation!");
                    }

                }
                else if (TypAssignmentToCheck == ownMCRelationship.eTypAssignments.ProcGroup)
                {
                    dsAdminWork.Clear();
                    //System.Collections.Generic.List<string> lstProcGroupsActive = qs2.core.generic.readStrVariables(ProcGroupsActive.Trim());
                    foreach (string ProcGroupActive in lstElementsActive)
                    {
                        dsAdminWork.Clear();
                        qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[] arrSelListWithGroup = null;
                        arrSelListWithGroup = (qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[])sqlAdminWork.getSelListEntrysRelGroup(ProcGroupActive, this.IDParticipant, this.Application,
                                                                                                    ref dsAdminWork, core.vb.sqlAdmin.eTypAuswahlList.IDGroupStrAppRam);    // OMC.IDApplication.Check
                        Nullable<System.Guid> IDSelListObj = null;
                        bool Exists = false;
                        this.IsInObjArr(ref arrSelListWithGroup, ref Exists, ref this.arrSelListEntriesObj, ref IDSelListObj);
                    }
                }
                else if (TypAssignmentToCheck == ownMCRelationship.eTypAssignments.ProcGroupDropDownList)
                {
                    dsAdminWork.Clear();
                }
                else if (TypAssignmentToCheck == ownMCRelationship.eTypAssignments.ChapterDropDownList)
                {
                    dsAdminWork.Clear();
                }
                else if (TypAssignmentToCheck == ownMCRelationship.eTypAssignments.Roles)
                {
                    dsAdminWork.Clear();
                    bool rigthOK = false;
                    int rigthOKnVisible  = -1;
                    int UserIDTmp = qs2.core.vb.actUsr.rUsr.ID;
                    if (RunAsSystemUser)
                    {
                        UserIDTmp = UserIDSystemuser;
                    }
                    rigthOK = b.checkRigthFldShortForRole(FldShort, UserIDTmp, ref Application, ref HasCriteria);

                    if (TranslateSelListInQuery)
                    {
                        return rigthOK;
                    }
                    else
                    {
                        if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                        {
                            qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                            ownMultiControl1.ownMCUI1.IsVisible_Roles = rigthOK;
                        }
                        else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownGroupBox)))
                        {
                            qs2.design.auto.multiControl.ownGroupBox ownGroupBox1 = (qs2.design.auto.multiControl.ownGroupBox)ctl;
                            ownGroupBox1.IsVisibleControlAssignmentChapters = rigthOK;
                        }
                        else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownTab)))
                        {
                            qs2.design.auto.multiControl.ownTab ownTab1 = (qs2.design.auto.multiControl.ownTab)ctl;
                            ownTab1.IsVisibleControlAssignmentChapters = rigthOK;
                        }
                        else if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiGridSelList)))
                        {
                            qs2.design.auto.multiControl.ownMultiGridSelList ownMultiGridSelList1 = (qs2.design.auto.multiControl.ownMultiGridSelList)ctl;
                            ownMultiGridSelList1.IsVisibleControlAssignmentChapters = rigthOK;
                        }
                        else
                        {
                            throw new Exception("ownMCCriteria.checkAssignments: Control-Type '" + ctl.GetType().ToString() + "' not allowed for this operation!");
                        }
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.checkAssignments", FldShort, false, true,
                                                                this.Application, qs2.core.Protocol.alwaysShowExceptionMulticontrol,
                                                                qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }
       
        public void doChapterAssignmentForControl(string FldShort, ref string IDApplication2,
                                                    string IDOwnStrChapterSelListxy, string IDGroupChapterxy,
                                                    ref bool ProtocolWindow, ref string protocollForAdmin,
                                                    qs2.core.vb.dsAdmin.dbAutoUIRow rAutoUI,
                                                    ref Nullable<System.Guid> IDSelListObjChapter0xy, ref Nullable<System.Guid> IDSelListObjChapter1xy,
                                                    ref bool ExistsInChapter0xy, ref bool ExistsInChapter1xy, string IDChapter,
                                                    ref core.Enums.eStayTyp StayTyp)
        {
            try
            {
                if (IDChapter.Trim().ToLower().Equals(("FreeTopBelow").Trim().ToLower()))
                {
                    return;
                }
                
                qs2.core.vb.dsAdmin dsAdminUpdate = new core.vb.dsAdmin();
                qs2.core.vb.sqlAdmin sqlAdminUpdate = new core.vb.sqlAdmin();
                sqlAdminUpdate.initControl();

                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShort, "PatWeight", false))
                {
                    bool bStop = true;
                }

                string IDGroupChapter = "Chapters0";
                qs2.core.vb.dsAdmin.tblSelListGroupRow rSelListGroupCheckChapter = ownMCCriteria.sqlAdminWork.getSelListGroupRow(IDGroupChapter, qs2.core.license.doLicense.eApp.ALL.ToString(), Application.Trim());
                qs2.core.vb.sqlAdmin.ParametersSelListEntries Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                ownMCCriteria.sqlAdminWork.getSelListEntrys(ref Parameters, "", this.IDParticipant, IDApplication2.ToString(),
                                                ref dsAdminUpdate, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDOwnStrIDGroup, "", -999, IDChapter, rSelListGroupCheckChapter.ID);
                if (dsAdminUpdate.tblSelListEntries.Rows.Count != 1)
                {
                    dsAdminUpdate.tblSelListEntries.Clear();
                    IDGroupChapter = "Chapters1";
                    rSelListGroupCheckChapter = ownMCCriteria.sqlAdminWork.getSelListGroupRow(IDGroupChapter, qs2.core.license.doLicense.eApp.ALL.ToString(), Application.Trim());
                    Parameters = new qs2.core.vb.sqlAdmin.ParametersSelListEntries();
                    ownMCCriteria.sqlAdminWork.getSelListEntrys(ref Parameters, "", this.IDParticipant, IDApplication2.ToString(),
                                                    ref dsAdminUpdate, qs2.core.vb.sqlAdmin.eTypAuswahlList.IDOwnStrIDGroup, "", -999, IDChapter, rSelListGroupCheckChapter.ID);
                    if (dsAdminUpdate.tblSelListEntries.Rows.Count != 1)
                    {
                        throw new Exception("ownMCCriteria.qs2: dsAdminUpdate.tblSelListEntries.Rows.Count != 1 for IDChapter '" + IDChapter.ToString() + "'!");
                    }
                }

                qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntryChapter = (qs2.core.vb.dsAdmin.tblSelListEntriesRow)dsAdminUpdate.tblSelListEntries.Rows[0];
                qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rNew = null;

                
                string IDApplicationTmp = IDApplication2.Trim();
                dsAdminUpdate.tblCriteria.Clear();
                sqlAdminUpdate.getCriterias(dsAdminUpdate, core.vb.sqlAdmin.eTypSelCriteria.id, FldShort.Trim(), IDApplicationTmp.Trim(), false, false, false, "", "", false);
                if (dsAdminUpdate.tblCriteria.Rows.Count == 0)
                {
                    IDApplicationTmp = qs2.core.license.doLicense.eApp.ALL.ToString();
                    dsAdminUpdate.tblCriteria.Clear();
                    sqlAdminUpdate.getCriterias(dsAdminUpdate, core.vb.sqlAdmin.eTypSelCriteria.id, FldShort.Trim(), IDApplicationTmp.Trim(), false, false, false, "", "", false);
                    if (dsAdminUpdate.tblCriteria.Rows.Count != 1)
                    {
                        throw new Exception("ownMCCriteria.qs2: dsAdminUpdate.tblCriteria.Rows.Count != 1 for FldShort '" + FldShort.Trim() + "'!");
                    }
                }

                string sqlCommand = "";
                bool addRow = false;
                dsAdminUpdate.tblSelListEntriesObj.Clear();
                ownMCCriteria.sqlAdminWork.getSelListEntrysObj(rSelListEntryChapter.ID, core.vb.sqlAdmin.eDbTypAuswObj.Criterias, IDApplication2.Trim(), dsAdminUpdate, core.vb.sqlAdmin.eTypAuswahlObj.IDSelListEntryFldShort, IDApplicationTmp.Trim(),
                                                                rSelListEntryChapter.ID, FldShort.Trim(), -999, "", -999, "", "", true, null, sqlCommand);
                if (dsAdminUpdate.tblSelListEntriesObj.Rows.Count == 0)
                {
                    rNew = ownMCCriteria.sqlAdminWork.getNewRowSelListObj(dsAdminUpdate); 
                    addRow = true;
                }
                else if (dsAdminUpdate.tblSelListEntriesObj.Rows.Count == 1)
                {
                    rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow)dsAdminUpdate.tblSelListEntriesObj.Rows[0];
                    ownMCCriteria.sqlAdminWork.updateSelListEntryObjCreated(rNew.IDGuid, rNew.Created);
                }
                else if (dsAdminUpdate.tblSelListEntriesObj.Rows.Count > 1)
                {
                    rNew = (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow)dsAdminUpdate.tblSelListEntriesObj.Rows[0];
                    ownMCCriteria.sqlAdminWork.updateSelListEntryObjCreated(rNew.IDGuid, rNew.Created);
                }

                if (addRow)
                {
                    rNew.FldShort = FldShort.Trim();
                    if (IDApplication2.Trim().ToLower().Equals(qs2.core.license.doLicense.eApp.ALL.ToString().Trim().ToLower()))
                    {
                        //string xy = "";
                    }
                    rNew.IDApplication = IDApplicationTmp.Trim();
                    rNew.IDSelListEntry = rSelListEntryChapter.ID;
                    rNew.typIDGroup = qs2.core.vb.sqlAdmin.eDbTypAuswObj.Criterias.ToString();

                    rNew.Description = "";
                    rNew.IDClassification = "";
                    rNew.Sort = 0;
                    rNew.SetIDOwnIntNull();
                    rNew.IDClassification = "";     //"Application=" + IDApplication.Trim();
                    rNew.Created = dNowAssign.Value;
                    rNew.Modified = dNowAssign.Value;

                    sqlAdminUpdate.daSelListEntrysObj.SelectCommand.Connection = qs2.core.dbBase.dbConn;
                    sqlAdminUpdate.daSelListEntrysObj.InsertCommand.Connection = qs2.core.dbBase.dbConn;
                    sqlAdminUpdate.daSelListEntrysObj.UpdateCommand.Connection = qs2.core.dbBase.dbConn;
                    sqlAdminUpdate.daSelListEntrysObj.DeleteCommand.Connection = qs2.core.dbBase.dbConn;

                    if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShort, "PatWeight", false))
                    {
                        bool bStop = true;
                    }

                    sqlAdminUpdate.daSelListEntrysObj.Update(dsAdminUpdate.tblSelListEntriesObj);

                    // protocol
                    string sChapter = "";
                    if (this.tagTab != null)
                    {
                        sChapter = this.tagTab.text.Trim();
                    }
                    else
                    {
                        sChapter = "";
                    }

                    string sTxtProt = "FldShort '" + FldShort + "' autom. assigned to chapter '" + sChapter + "' (IDOwnStr='" + rSelListEntryChapter.IDOwnStr.Trim() + "')!";
                    if (ProtocolWindow)
                    {
                        protocollForAdmin += sTxtProt + "\r\n";
                    }

                    this.parentAutoUI.contAutoProtokoll1.addRow(sChapter, FldShort, sTxtProt + "!", rAutoUI, QS2.Resources.getRes.Allgemein2.ico_Wichtig, true, true, false, false);
                    this.parentAutoUI.setButtonProtocolCaption();

                    ownMCCriteria.counterNewCriteriaAssignments += 1;
                }

                core.vb.dsAdmin dsAdminTmp = new core.vb.dsAdmin();
                ownMCCriteria.sqlAdminWork.getSelListEntrysObj(rSelListEntryChapter.ID, core.vb.sqlAdmin.eDbTypAuswObj.Criterias, "",
                                                                dsAdminTmp, core.vb.sqlAdmin.eTypAuswahlObj.FldShortOtherChapters, IDApplicationTmp.Trim(),
                                                                rSelListEntryChapter.ID, FldShort.Trim(), -999, "", -999, IDApplication2, "", true, null, sqlCommand, "",
                                                                ownMCCriteria.dNowAssign.Value);
                if (dsAdminTmp.tblSelListEntriesObj.Rows.Count > 0)
                {
                    ownMCCriteria.sqlAdminWork.deleteSelListEntryObjOtherChapters(FldShort.Trim(), IDApplicationTmp.Trim(), core.vb.sqlAdmin.eDbTypAuswObj.Criterias.ToString(),
                                                                                    rSelListEntryChapter.ID, ownMCCriteria.dNowAssign.Value, IDApplication2.Trim());
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.doChapterAssignmentForControl", FldShort, false, true,
                                                                this.Application, qs2.core.Protocol.alwaysShowExceptionMulticontrol,
                                                                qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void IsInObjArr(ref qs2.core.vb.dsAdmin.vListEntriesWithGroupRow[] arrSelListToProve, ref bool Exists,
                               ref qs2.core.vb.dsAdmin.tblSelListEntriesObjRow[] arrSelListEntriesObj, ref Nullable<System.Guid> IDSelListObj)
        {
            if (arrSelListEntriesObj != null)
            {
                foreach (qs2.core.vb.dsAdmin.tblSelListEntriesObjRow rObj in arrSelListEntriesObj)
                {
                    foreach (qs2.core.vb.dsAdmin.vListEntriesWithGroupRow rSelListWithGroup in arrSelListToProve)
                    {
                        if (rObj.IDSelListEntry.Equals(rSelListWithGroup.s_ID))
                        {
                            IDSelListObj = rObj.IDGuid;
                            Exists = true;
                        }
                    }
                }
            }

        }

        public void getLicenseDesignTime(System.Windows.Forms.Control ctl)
        {
            this.Application = qs2.core.ENV.developApplication;
            this.IDParticipant = qs2.core.ENV.developParticipant;
        }
    }

}
