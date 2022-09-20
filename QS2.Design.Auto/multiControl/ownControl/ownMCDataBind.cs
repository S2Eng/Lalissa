﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;




namespace qs2.design.auto.multiControl
{


    public class ownMCDataBind
    {

        public System.Windows.Forms.Binding Binding1 = null;
        public DataColumn bindedColumnGenericTables;
        public DataRow RowGenericTables = null;

        public dTypeBinding TypeBinding = new dTypeBinding();
        public enum dTypeBinding
        {
            AutoDll = 0,
            Ds = 1,
            noBinding = 100
        }

        //public qs2.core.generic generic1 { get; set; } = new qs2.core.generic();
        public bool isDoingReadValueFromBindingRowToControl = false;
        public bool isDoingWriteValueFromControlToBindingRow = false;


        public enum eTypeSetDataAndMC
        {
            SurgDtEnd = 0

        }











        public void BindControlToData(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool onlyClearBindings,
                                        qs2.design.auto.workflowAssist.autoForm.dataStay dataStay, bool getSelectedText)
        {
            try
            {
                //return;

                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "vac1surg", false))
                {
                    string xy = "";
                }
                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "vac2surg", false))
                {
                    string xy = "";
                }
                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "vac3surg", false))
                {
                    string xy = "";
                }
                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "Surgeon", false))
                {
                    string xy = "";
                }

                if ((this.bindedColumnGenericTables != null && this.RowGenericTables != null && this.TypeBinding == dTypeBinding.Ds) ||
                    (ownControl1.parentAutoUI.dataStay.coreStaysProducts.ColumnNameExists(ownControl1.ownMCCriteria1.rCriteria.FldShort) && this.TypeBinding == dTypeBinding.AutoDll))
                {
                    this.Binding1 = null;

                    if (ownControl1._controlType == core.Enums.eControlType.Numeric ||
                        ownControl1._controlType == core.Enums.eControlType.Integer)
                    {
                        ownControl1.Numeric.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                this.Binding1 = ownControl1.Numeric.DataBindings.Add("Value", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                            else if (this.TypeBinding == dTypeBinding.AutoDll)
                            {
                                this.Binding1 = ownControl1.Numeric.DataBindings.Add("Value", dataStay.coreStaysProducts.r, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.ComboBox)
                    {
                        ownControl1.ComboBox.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                if (ownControl1.IsComboBoxWithTxtBox)
                                {
                                    this.setTextBoxForComboBoxGeneric(ownControl1);
                                }
                                this.Binding1 = ownControl1.ComboBox.DataBindings.Add("Value", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.DateTime)
                    {
                        ownControl1.DateTime.DataBindings.Clear();
                        if (this.TypeBinding == dTypeBinding.Ds)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.DateTime);
                        }
                        else if (this.TypeBinding == dTypeBinding.AutoDll)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.DateTime);
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Date)
                    {
                        ownControl1.Date.DataBindings.Clear();
                        if (this.TypeBinding == dTypeBinding.Ds)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.Date);
                        }
                        else if (this.TypeBinding == dTypeBinding.AutoDll)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.Date);
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Time)
                    {
                        ownControl1.Time.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        //if (!onlyClearBindings)
                        //{
                        //    this.Binding1 = ownControl1.Time.DataBindings.Add("Value", this.row, ownControl1.ownControlCriteria1.rCriteria.FldShort, true);
                        //}                        
                        if (this.TypeBinding == dTypeBinding.Ds)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.Time);
                        }
                        else if (this.TypeBinding == dTypeBinding.AutoDll)
                        {
                            this.setDateTimeToInfragControl(ownControl1, ownControl1.Time);
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Textfield)
                    {
                        ownControl1.Textfield.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                this.Binding1 = ownControl1.Textfield.DataBindings.Add("Text", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                            else if (this.TypeBinding == dTypeBinding.AutoDll)
                            {
                                this.Binding1 = ownControl1.Textfield.DataBindings.Add("Text", dataStay.coreStaysProducts.r, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti)
                    {
                        ownControl1.TextfieldMulti.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                this.Binding1 = ownControl1.TextfieldMulti.DataBindings.Add("Value", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                            else if (this.TypeBinding == dTypeBinding.AutoDll)
                            {
                                this.Binding1 = ownControl1.TextfieldMulti.DataBindings.Add("Value", dataStay.coreStaysProducts.r, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.CheckBox)
                    {
                        ownControl1.CheckBox.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                this.Binding1 = ownControl1.CheckBox.DataBindings.Add("Checked", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                            else if (this.TypeBinding == dTypeBinding.AutoDll)
                            {
                                this.Binding1 = ownControl1.CheckBox.DataBindings.Add("Checked", dataStay.coreStaysProducts.r, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox)
                    {
                        ownControl1.ThreeStateCheckBox.DataBindings.Clear();
                        //ownControl1.ownControlEvents1.registerRowColumnChanged(true, ownControl1);
                        if (!onlyClearBindings)
                        {
                            if (this.TypeBinding == dTypeBinding.Ds)
                            {
                                this.Binding1 = ownControl1.ThreeStateCheckBox.DataBindings.Add("OwnCheckStateInt", this.RowGenericTables, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                            else if (this.TypeBinding == dTypeBinding.AutoDll)
                            {
                                this.Binding1 = ownControl1.ThreeStateCheckBox.DataBindings.Add("OwnCheckStateInt", dataStay.coreStaysProducts.r, ownControl1.ownMCCriteria1.rCriteria.FldShort, true);
                            }
                        }
                    }
                }
                else
                {
                    //string xy = "";
                }

                if (onlyClearBindings)
                {
                    this.bindedColumnGenericTables = null;
                    this.RowGenericTables = null;
                }

                if (getSelectedText)
                {
                    ownControl1.ownMCTxt1.getSelectedText(ownControl1, ownControl1.IsInDesignerModus);
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.BindControlToData", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setTextBoxForComboBoxGeneric(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                int IDObject = System.Convert.ToInt32(this.RowGenericTables[ownControl1.ownMCCriteria1.rCriteria.FldShort]);
                ownControl1.ownMCCriteria1.ownMCCombo1.resetComboBoxObject(ownControl1);
                //ownControl1.ownMCCriteria1.ownMCCombo1.lstCombBoxObjectsAdded.Clear();

                if (IDObject != -1)
                {
                    ownControl1.Textfield.Text = this.getUserNameFromRAM(ownControl1, IDObject);
                    ownControl1.ownMCCriteria1.ownMCCombo1.addObjectToComboBoxObject(IDObject, ownControl1);
                }
                else
                {
                    ownControl1.Textfield.Text = "";
                }
                ownControl1.Textfield.Tag = IDObject;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setTextBoxForComboBoxGeneric", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public string getUserNameFromRAM(qs2.design.auto.multiControl.ownMultiControl ownControl1, int IDObject)
        {
            try
            {
                qs2.core.vb.dsAdmin.tblSelListGroupRow[] arrSelListEntrieiesGroupUsers = (qs2.core.vb.dsAdmin.tblSelListGroupRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListGroup.Select("IDGroupStr='Users'");
                if (arrSelListEntrieiesGroupUsers.Length != 1)
                {
                    throw new Exception("getUserNameFromRAM: Group Users not found in dsAllAdmin.tblSelListGroup!");
                }
                qs2.core.vb.dsAdmin.tblSelListGroupRow rSelListEntrieiesGroupUsers = arrSelListEntrieiesGroupUsers[0];

                qs2.core.vb.dsAdmin.tblSelListEntriesRow[] arrSelListEntriesUser = (qs2.core.vb.dsAdmin.tblSelListEntriesRow[])qs2.core.vb.sqlAdmin.dsAllAdmin.tblSelListEntries.Select("ID='" +  IDObject .ToString() + "' and IDGroup=" + rSelListEntrieiesGroupUsers.ID.ToString()  + "");
                if (arrSelListEntriesUser.Length != 1)
                {
                    throw new Exception("getUserNameFromRAM: IDObject '" + IDObject.ToString() + "' not found in dsAllAdmin.tblSelListEntries!");
                }
                qs2.core.vb.dsAdmin.tblSelListEntriesRow rSelListEntriesUsers = arrSelListEntriesUser[0];
                return rSelListEntriesUsers.IDRessource.Trim();
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getUserNameFromRAM", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return "";
            }
        }

        public void BindControlDateTimeNew(qs2.design.auto.multiControl.ownMultiControl ownControl1,
                                            Infragistics.Win.UltraWinEditors.UltraDateTimeEditor infragDateTime)
        {
            try
            {
                this.setRowValue(ownControl1, infragDateTime.Value, true);
                ownControl1.ownMCDataBind1.BindControlToData(ownControl1, false, ownControl1.parentAutoUI.dataStay, true);
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.BindControlDateTimeNew", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public qs2.core.generic.retValue getValueFromRow(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (ownControl1.ownMCUI1.controlIsDbDataControl(ownControl1))
                {
                    qs2.core.generic.retValue ret = new qs2.core.generic.retValue();
                    if (ownControl1._controlType == core.Enums.eControlType.Numeric ||
                        ownControl1._controlType == core.Enums.eControlType.Integer)
                    {
                        if (this.TypeBinding == dTypeBinding.Ds)
                        {
                            ret = qs2.core.generic.getValue(ownControl1._controlType, this.RowGenericTables[this.bindedColumnGenericTables], ownControl1.Numeric.NumericType, false);
                        }
                        else if (this.TypeBinding == dTypeBinding.AutoDll)
                        {
                            ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.parentAutoUI.dataStay.coreStaysProducts.getField(ownControl1._FldShort), ownControl1.Numeric.NumericType, false);
                        }
                        return ret;
                    }
                    else
                    {
                        if (this.TypeBinding == dTypeBinding.Ds)
                        {
                            ret = qs2.core.generic.getValue(ownControl1._controlType, this.RowGenericTables[this.bindedColumnGenericTables], Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        }
                        else if (this.TypeBinding == dTypeBinding.AutoDll)
                        {
                            ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.parentAutoUI.dataStay.coreStaysProducts.getField(ownControl1._FldShort), Infragistics.Win.UltraWinEditors.NumericType.Integer, false);
                        }
                        return ret;
                    }
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getValueFromRow", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        public void setRowValue(qs2.design.auto.multiControl.ownMultiControl ownControl1, object objectVal,
                                bool DoValueToControl)
        {
            try
            {
                //if (this.bindedColumn != null && this.row != null)
                //{

                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1._FldShort, "VSAoIm", false))
                //{
                //    string xy = "";
                //}

                if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                    ownControl1._controlType == core.Enums.eControlType.Date ||
                    ownControl1._controlType == core.Enums.eControlType.Time)
                {
                    if (objectVal == null)
                        objectVal = System.DBNull.Value;

                    if (this.TypeBinding == dTypeBinding.Ds)
                    {
                        this.RowGenericTables[this.bindedColumnGenericTables] = objectVal;
                        if (DoValueToControl)
                        {
                            ownControl1.ownMCDataBind1.BindControlToData(ownControl1, false, ownControl1.parentAutoUI.dataStay, true);
                        }
                    }
                    else if (this.TypeBinding == dTypeBinding.AutoDll)
                    {

                        ownControl1.parentAutoUI.dataStay.coreStaysProducts.setField(ownControl1.OwnFldShort, objectVal);
                        if (DoValueToControl)
                        {
                            ownControl1.ownMCDataBind1.BindControlToData(ownControl1, false, ownControl1.parentAutoUI.dataStay, true);
                            //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1._FldShort, "VSAOIm", false))
                            //{
                            //    string xy = "";
                            //}
                        }
                    }
                }
                else
                {
                    //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, " VSAOIm", false))
                    //{
                    //    string xy = "";
                    //}

                    if (this.TypeBinding == dTypeBinding.Ds)
                    {
                        this.RowGenericTables[this.bindedColumnGenericTables] = objectVal;
                        if (DoValueToControl)
                        {
                            this.readValueFromBindingRowToControl(ownControl1, true);
                        }
                    }
                    else if (this.TypeBinding == dTypeBinding.AutoDll)
                    {
                        ownControl1.parentAutoUI.dataStay.coreStaysProducts.setField(ownControl1.OwnFldShort, objectVal);
                        //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1._FldShort, "VSAOIm", false))
                        //{
                        //    string xy = "";
                        //}
                        if (DoValueToControl)
                        {
                            this.readValueFromBindingRowToControl(ownControl1, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setRowValue", ownControl1._FldShort, false, true,
                                                        ownControl1.ownMCCriteria1.Application,
                                                        qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void setDateTimeToInfragControl(qs2.design.auto.multiControl.ownMultiControl ownControl1,
                                                Infragistics.Win.UltraWinEditors.UltraDateTimeEditor contDateTime)
        {
            try
            {
                if (this.TypeBinding == dTypeBinding.Ds)
                {
                    if (this.RowGenericTables[ownControl1.ownMCCriteria1.rCriteria.FldShort] == System.DBNull.Value)
                    {
                        contDateTime.Value = null;
                    }
                    else
                    {
                        contDateTime.Value = this.RowGenericTables[ownControl1.ownMCCriteria1.rCriteria.FldShort];
                    }
                }
                else if (this.TypeBinding == dTypeBinding.AutoDll)
                {
                    if ((DateTime)ownControl1.parentAutoUI.dataStay.coreStaysProducts.getField(ownControl1.ownMCCriteria1.rCriteria.FldShort) == DateTime.MinValue)
                    {
                        contDateTime.Value = null;
                    }
                    else
                    {
                        contDateTime.Value = ownControl1.parentAutoUI.dataStay.coreStaysProducts.getField(ownControl1.OwnFldShort);
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setDateTimeToInfragControl", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        // Data-Binding
        public void readValueFromBindingRowToControl(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool getSelectedText)
        {
            try
            {
                this.isDoingReadValueFromBindingRowToControl = true;
                this.Binding1.ReadValue();
                if (getSelectedText)
                {
                    ownControl1.ownMCTxt1.getSelectedText(ownControl1, ownControl1.IsInDesignerModus);
                }
                this.isDoingReadValueFromBindingRowToControl = false;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.readValueFromBindingRowToControl", "", false, true,
                                                                "FldShort: " + ownControl1.OwnFldShort.Trim() + ", Application: " + ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                this.isDoingReadValueFromBindingRowToControl = false;
            }
        }
        public void writeValueFromControlToBindingRow(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                this.isDoingWriteValueFromControlToBindingRow = true;
                this.Binding1.WriteValue();
                this.isDoingWriteValueFromControlToBindingRow = false;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept("" + ownControl1.OwnFldShort.Trim() + "\r\n" + ex.ToString(), "ownMCDataBind.writeValueFromControlToBindingRow", "", false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                this.isDoingWriteValueFromControlToBindingRow = false;
            }
        }

        public void setBindingContext(qs2.design.auto.multiControl.ownMultiControl ownControl1, qs2.design.auto.workflowAssist.autoForm.dataStay dataStay)
        {
            try
            {
                this.TypeBinding = dTypeBinding.noBinding;

                if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1.OwnFldShort, "CIOthDesc", false))
                {
                    string xy = "";
                }

                if (ownControl1.ownMCCriteria1.rCriteria != null)
                {
                    if (ownControl1.ownMCCriteria1.rCriteria.SourceTable.Trim() == "")
                    {
                        qs2.core.Protocol.doExcept("No SourceTable in Criteria-Field '" + ownControl1.OwnFldShort + "' defined!", "ownMCDataBind.setBindingContext", ownControl1.OwnFldShort, false, true,
                            ownControl1.ownMCCriteria1.Application,
                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                    }

                    this.bindedColumnGenericTables = this.getColumnGenericTables(ownControl1, dataStay);
                    if (this.bindedColumnGenericTables != null)
                    {
                        this.TypeBinding = dTypeBinding.Ds;
                        this.RowGenericTables = this.getDataRowGenericTables(ownControl1, dataStay);
                    }
                    else
                    {
                        if (ownControl1.parentAutoUI.dataStay.coreStaysProducts.ColumnNameExists(ownControl1.ownMCCriteria1.rCriteria.FldShort))
                        {
                            this.TypeBinding = dTypeBinding.AutoDll;
                        }
                        else
                        {
                            qs2.core.Protocol.doExcept("No Binding-Context to Database found for Field " + ownControl1.OwnFldShort + "! (Table:" + ownControl1.ownMCCriteria1.rCriteria.SourceTable + "')", "ownMCDataBind.setBindingContext", ownControl1.OwnFldShort, false, true,
                                    ownControl1.ownMCCriteria1.Application,
                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setRowColumn", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        private DataColumn getColumnGenericTables(qs2.design.auto.multiControl.ownMultiControl ownControl1, qs2.design.auto.workflowAssist.autoForm.dataStay dataStay)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1._FldShort, "VSAOIm", false))
                //{
                //    string xy = "";
                //}

                //System.Data.DataSet dsConvert = this.getDataSetForProdukt(ownControl1, dataStay);
                if (dataStay.dsObject.Tables.Contains(ownControl1.ownMCCriteria1.rCriteria.SourceTable))
                {
                    if (dataStay.dsObject.Tables[ownControl1.ownMCCriteria1.rCriteria.SourceTable].Columns.Contains(ownControl1.ownMCCriteria1.rCriteria.FldShort))
                    {
                        return dataStay.dsObject.Tables[ownControl1.ownMCCriteria1.rCriteria.SourceTable].Columns[ownControl1.ownMCCriteria1.rCriteria.FldShort];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getColumn", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        private DataRow getDataRowGenericTables(qs2.design.auto.multiControl.ownMultiControl ownControl1, qs2.design.auto.workflowAssist.autoForm.dataStay dataStay)
        {
            try
            {
                //if (ownControl1.ownMCCriteria1.rCriteria.SourceTable.ToLower().Trim().Equals("tblObject"))
                //{
                //    string xy = "";
                //}

                if (dataStay.dsObject.Tables.Contains(ownControl1.ownMCCriteria1.rCriteria.SourceTable))
                {
                    return dataStay.dsObject.Tables[ownControl1.ownMCCriteria1.rCriteria.SourceTable].Rows[0];
                }
                else
                {
                    //System.Data.DataSet dsConvert = this.getDataSetForProdukt(ownControl1, dataStay);
                    //return dsConvert.Tables[ownControl1.ownMCCriteria1.rCriteria.SourceTable].Rows[0];
                    throw new Exception("getDataRow: Table '" + ownControl1.ownMCCriteria1.rCriteria.SourceTable + "' is not in dataStay.dsObject!");
                    //return null;
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getDataRow", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }




        private DataSet getDataSetForProduktxyxy(qs2.design.auto.multiControl.ownMultiControl ownControl1, qs2.design.auto.workflowAssist.autoForm.dataStay dataStay)
        {
            try
            {
                System.Data.DataSet dsConvert = null;
                //if (ownControl1.ownMCCriteria1.IDApplication == core.license.doLicense.eApp.CARDIAC)          // OMC.IDApplication.Check
                //{
                //    dsConvert = (System.Data.DataSet)dataStay.dsStayCARDIAC;
                //}
                //else if (ownControl1.ownMCCriteria1.IDApplication == core.license.doLicense.eApp.VASCULAR)    // OMC.IDApplication.Check
                //{
                //    //dsConvert = (System.Data.DataSet)dataStay.dsStayVASCULAR; 
                //}
                //if (ownControl1.ownMCCriteria1.IDApplication == core.license.doLicense.eApp.QTH)              // OMC.IDApplication.Check
                //{
                //    dsConvert = (System.Data.DataSet)dataStay.dsStayQTH;
                //}
                return dsConvert;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getDataSetForProdukt", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        public object getValueFromRowxyxyxyxy(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            //try
            //{
            //    //if (this.bindedColumn != null && this.row != null)
            //    //{

            //    if (ownControl1.ownMCUI1.controlIsDataControl(ownControl1))
            //    {
            //        return this.row[this.bindedColumn];
            //    }
            //    else
            //        return null;
            //}
            //catch (Exception ex)
            //{
            //    qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.getValueFromRowxyxy", ownControl1._FldShort, false, true,
            //                                                    ownControl1.ownMCCriteria1.IDApplication.ToString(),
            //                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            //    return null;
            //}
            return null;
        }

        public void setRowAndMC(ref qs2.design.auto.multiControl.ownMultiControl ownControl1, eTypeSetDataAndMC TypeSetDataAndMC,
                                bool SetFocus)
        {
            try
            {
                if (TypeSetDataAndMC == eTypeSetDataAndMC.SurgDtEnd)
                {
                    if (SetFocus && ownControl1.OwnFldShort.Trim().ToLower().Equals(("SurgDtEnd").Trim().ToLower()))
                    {
                        if (ownControl1.Date != null && ownControl1.Date.Value == null)
                        {
                            qs2.core.vb.dsObjects.tblStayRow rStayProd = null;
                            System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl>();
                            this.getMCAndStayAndCheckMC(ref ownControl1, ref rStayProd, TypeSetDataAndMC, ref lstMultiControl);

                            foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControlToSet in lstMultiControl)
                            {
                                if (rStayProd.IsSurgDtEndNull() && !rStayProd.IsSurgDtStartNull())
                                {
                                    if (ownMultiControlToSet.OwnControlType == core.Enums.eControlType.Date &&
                                        (rStayProd.SurgDtStart.Hour != 0 || rStayProd.SurgDtStart.Minute != 0))
                                    {
                                        ownMultiControlToSet.Date.DateTime = rStayProd.SurgDtStart;
                                        qs2.core.generic.retValue retValue1 = new core.generic.retValue();
                                        retValue1.valueObj = rStayProd.SurgDtStart;
                                        ownMultiControlToSet.ownMCDataBind1.setRowValue(ownMultiControlToSet, retValue1.valueObj, true);
                                       ownMultiControlToSet.ownMCDataBind1.BindControlToData(ownMultiControlToSet, false, ownMultiControlToSet.parentAutoUI.dataStay, true);
                                    }
                                    else if (ownMultiControlToSet.OwnControlType == core.Enums.eControlType.Time)
                                    {
                                        //ownMultiControlToSet.Time.DateTime = rStayProd.SurgDtStart;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setRowAndMC", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void getMCAndStayAndCheckMC(ref qs2.design.auto.multiControl.ownMultiControl ownControlMain, 
                                            ref qs2.core.vb.dsObjects.tblStayRow rStayProd,
                                            eTypeSetDataAndMC TypeSetDataAndMC,
                                            ref System.Collections.Generic.List<qs2.design.auto.multiControl.ownMultiControl> lstMultiControl)
        {
            try
            {
                System.Collections.Generic.List<Infragistics.Win.UltraWinTabControl.UltraTab> lstTabePageReturn = new System.Collections.Generic.List<Infragistics.Win.UltraWinTabControl.UltraTab>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox> lstGroupBoxReturn = new System.Collections.Generic.List<qs2.design.auto.multiControl.ownGroupBox>();
                System.Collections.Generic.List<qs2.design.auto.multiControl.ownTab> lstTab = new List<qs2.design.auto.multiControl.ownTab>();
                qs2.design.auto.workflowAssist.autoForm.autoUI.getMultiControl(eTypeSetDataAndMC.SurgDtEnd.ToString(),
                                                                                ownControlMain.parentAutoUI._license.OwnApplication.ToString(),
                                                                                ref ownControlMain.parentAutoUI.dsAdmin1, "", ref lstMultiControl,
                                                                                ref lstTabePageReturn, ref lstTab, ref lstGroupBoxReturn);

                if (lstMultiControl.Count == 0)
                {
                    throw new Exception("ControlLeave: lstMultiControl.Count != 1) not allowed vor FldShort '" + TypeSetDataAndMC.ToString() + "'!");
                }
                foreach (qs2.design.auto.multiControl.ownMultiControl ownMultiControlToSet in lstMultiControl)
                {
                    if (ownControlMain.parentAutoUI.dataStay.dsObject.tblStay.Rows.Count != 1)
                    {
                        throw new Exception("ControlLeave: ownControl1.parentAutoUI.dataStay.dsObject.tblStay.Rows.Count!=1 not allowed!");
                    }
                    rStayProd = (qs2.core.vb.dsObjects.tblStayRow)ownControlMain.parentAutoUI.dataStay.dsObject.tblStay[0];
                    if (!ownMultiControlToSet.ownMCCriteria1._isInitializedCriteria)
                    {
                        ownMultiControlToSet.parentAutoUI.autoUI1.initMulticontrol(ownMultiControlToSet, ref ownMultiControlToSet.parentAutoUI.dataStay);
                        //ownControl1.parentAutoUI.autoUI1.multicontrolFillData(ref ownControl1.parentAutoUI.dataStay, ownControl1);
                    }
                    if (ownMultiControlToSet.ownMCDataBind1.Binding1 == null)
                    {
                        ownMultiControlToSet.parentAutoUI.autoUI1.multicontrolFillData(ref ownMultiControlToSet.parentAutoUI.dataStay, ownMultiControlToSet);
                    }
                    //qs2.core.generic.retValue retValue1 = ownMultiControl1.ownMCDataBind1.getValueFromRow(ownMultiControl1);
                    //ownMultiControl1.ownMCDataBind1.setRowValue(ownMultiControl1, retValue1.valueObj, false);
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCDataBind.setValueToMC", ownControlMain._FldShort, false, true,
                                                                ownControlMain.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


    }
}