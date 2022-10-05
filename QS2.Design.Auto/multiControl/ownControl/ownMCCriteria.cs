using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;

namespace qs2.design.auto
{
    public class ownMCCriteria
    {
        private bool NoDefaultValuePossible = false;
        private static List<qs2.core.vb.businessFramework.cSelListAndObj> lstRolesForUserActive;
        private static List<qs2.core.vb.businessFramework.cSelListAndObj> lstRolesForUserAll;
        private static qs2.core.db.ERSystem.businessFramework b2 = new core.db.ERSystem.businessFramework();
        private System.Collections.Generic.List<string> lstLicenseKeys = new List<string>();
        private bool _isInitializedVar;
        private static qs2.core.vb.businessFramework b;

        public string Application = "";
        public string IDParticipant = "";
        public bool _ControlIsFormatted;
        public static qs2.core.vb.dsAdmin dsAdminWork;
        public static qs2.core.vb.sqlAdmin sqlAdminWork;
        public static qs2.core.vb.dsObjects dsObjectsWork;
        public static qs2.core.vb.sqlObjects sqlObjectsWork;
        public qs2.core.vb.dsAdmin.tblCriteriaRow rCriteria;
        public System.Collections.Generic.List<qs2.core.Enums.cVariables> lstVariablesClassification = new List<core.Enums.cVariables>();
        public qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys;
        public qs2.core.generic.retValue defaultDBValue;
        public bool _isInitializedGetData;
        public bool _isInitializedCriteria;
        public qs2.design.auto.multiControl.ownMCCombo ownMCCombo1 = new multiControl.ownMCCombo();
        public string CombinationComboBoxAsDropDown = qs2.core.sqlTxt.and.Trim();
        public static core.license.dsLicense dsLicense1;


        public void initControl()
        {
            try
            {
                if (this._isInitializedVar)
                    return;
                ownMCCriteria.initSharedDataSets(true);
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
                    doLicense1.GetAppsLicensedForParticipant(ownMCCriteria.dsLicense1);
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

                if (FldShort.Trim() == "")
                {
                    if (qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                    {
                        qs2.core.Protocol.doExcept("FldShort='' for ControlName '" + ctl.Name + "'  ", "ownMCCriteria.getData", "", false, true, this.Application,
                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                    }
                }

                string IDApplicationTmp;
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

                    qs2.design.auto.ownMCCriteria.dsAdminWork.Clear();
                    this.rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(this.rCriteria.SourceTable, this.rCriteria.FldShort, qs2.core.SysDB.sqlSysDB.dsSysDBAll, false);

                    if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                        ownMultiControlExcept = ownMultiControl1;

                        this.loadDefaultDBValue(ref ownMultiControl1);

                        if (controlType == core.Enums.eControlType.ComboBox || controlType == core.Enums.eControlType.ComboBoxNoDb)
                        {
                            this.ownMCCombo1.initCombo(ownMultiControl1);
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

                        ownMultiControl1.ownMCUI1.getColorsFromClassification(ref ownMultiControl1);
                        if (!string.IsNullOrWhiteSpace(ownMultiControl1.OwnOnlyForProducts))
                        {
                            if (!ownMultiControl1.OwnOnlyForProducts.Trim().ToLower().Contains(IDApplicationTmp.Trim().ToLower()))
                            {
                                ownControlUI1.IsVisible_Criteriaxy = false;
                            }
                        }
                    }
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

                if (this.rCriteria != null)
                {
                    if (ctl.GetType().Equals(typeof(qs2.design.auto.multiControl.ownMultiControl)))
                    {
                        qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = (qs2.design.auto.multiControl.ownMultiControl)ctl;
                        ownMultiControlExcept = ownMultiControl1;

                        if (!ownMultiControl1.hasINCondition)
                        {
                            if (controlType == core.Enums.eControlType.ComboBox ||
                                controlType == core.Enums.eControlType.ComboBoxNoDb)
                            {
                                this.ownMCCombo1.loadCombo(ownMultiControl1, "", this.CombinationComboBoxAsDropDown, false);
                                if (this.rCriteria.UserDefined)
                                {
                                    if (this.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.SelList)
                                    {
                                        ownMultiControl1.ownMCUI1.doButtonAddSelList(ownMultiControl1);
                                    }
                                }

                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                            {
                                this.ownMCCombo1.loadComboThreeStateCheckBox(ownMultiControl1, ControlWasCheckBox, false);
                            }
                            else if (controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                            {
                                string IDGroupOther = "";
                                if (ComboBoxCheckThreeStateBoxAsDropDown)
                                {
                                    IDGroupOther = "ComboBoxCheckThreeStateBox";
                                }
                                ownMultiControl1.ControlForDropDown.initControl();
                                this.ownMCCombo1.loadCombo(ownMultiControl1, IDGroupOther.Trim(), this.CombinationComboBoxAsDropDown, ComboBoxCheckThreeStateBoxAsDropDown);
                            }
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
                    }
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
                ownControlUI1.IsVisible_Criteriaxy = false;

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
                bool IsDefaultValue = false;
                if (!this.rCriteria.IsDefaultValuesNull())
                {
                    if (!string.IsNullOrWhiteSpace(rCriteria.DefaultValues))
                    {
                        this.defaultDBValue = qs2.core.generic.getValue(ownMultiControl1._controlType, this.rCriteria.DefaultValues.Trim(),
                                                                                    Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        IsDefaultValue = true;
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
                    }
                }

                if (!IsDefaultValue)
                {
                    if (this.rColSys != null)
                    {
                        System.Collections.Generic.List<string> lstTablesNoDateTimeCheck = new System.Collections.Generic.List<string>();

                        this.defaultDBValue = qs2.core.dbBase.getDefaultDBValue(ref this.rColSys, true, lstTablesNoDateTimeCheck, ref this.NoDefaultValuePossible);
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
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCCriteria.loadDefaultDBValue", ownMultiControl1._FldShort, false, true,
                                                                this.Application, qs2.core.Protocol.alwaysShowExceptionMulticontrol,
                                                                qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void getLicenseDesignTime(System.Windows.Forms.Control ctl)
        {
            this.Application = qs2.core.ENV.developApplication;
            this.IDParticipant = qs2.core.ENV.developParticipant;
        }
    }

}
