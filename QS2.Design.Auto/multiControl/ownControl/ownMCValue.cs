using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;




namespace qs2.design.auto.multiControl
{


    public class ownMCValue
    {

        //public qs2.core.generic generic1 { get; set; } = new qs2.core.generic();

        public void setValue(qs2.design.auto.multiControl.ownMultiControl ownControl1, string valueText)
        {
            try
            {
                if (ownControl1._controlType == core.Enums.eControlType.Numeric ||
                    ownControl1._controlType == core.Enums.eControlType.NumericNoDb ||
                    ownControl1._controlType == core.Enums.eControlType.Integer ||
                    ownControl1._controlType == core.Enums.eControlType.IntegerNoDb)
                {
                    if (valueText == "")
                        ownControl1.Numeric.Value = System.DBNull.Value;
                    else
                    {
                        //if (System.Convert.ToString(valueText).Contains(".") || System.Convert.ToString(valueText).Contains(","))
                        //{
                        //    double dbl = this.generic1.GetDouble(valueText);
                        //}
                        //else
                        //{
                        //}

                        decimal decimalHelp = System.Convert.ToDecimal(valueText);
                        if (ownControl1.Numeric.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                        {
                            ownControl1.Numeric.Value = System.Convert.ToInt32(decimalHelp, CultureInfo.InvariantCulture.NumberFormat);
                        }
                        else if (ownControl1.Numeric.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Decimal)
                        {
                            ownControl1.Numeric.Value = Convert.ToDouble(valueText, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                            //this.Numeric.Value = this.generic1.GetDouble(valueText);  // System.Convert.ToDecimal(decimalHelp); 
                        }
                    }
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBox ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (valueText == "")
                        try
                        {
                            ownControl1.ComboBox.Value = -1;

                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                            ownControl1.ComboBox.Value = System.DBNull.Value;
                        }
                    else
                    {
                        try
                        {
                            System.Guid guid = new System.Guid(valueText);
                            ownControl1.ComboBox.Value = guid;
                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                            ownControl1.ComboBox.Value = System.Convert.ToInt32(valueText, CultureInfo.InvariantCulture);
                            //ownControl1.ComboBox.Refresh();
                        }
                    }
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (valueText == "")
                        try
                        {
                            ownControl1.ComboBox.Value = -1;

                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                            ownControl1.ComboBox.Value = System.DBNull.Value;
                        }
                    else
                    {
                        try
                        {
                            System.Guid guid = new System.Guid(valueText);
                            ownControl1.ComboBox.Value = guid;
                        }
                        catch (Exception ex2)
                        {
                            string xy = ex2.ToString();
                            ownControl1.ComboBox.Value = System.Convert.ToInt32(valueText, CultureInfo.InvariantCulture.NumberFormat);
                            //ownControl1.ComboBox.Refresh();
                        }
                    }
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ownControl1.ControlForDropDown.setValue(ref valueText);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                    ownControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    if (valueText == "")
                        ownControl1.DateTime.Value = null;
                    else
                        ownControl1.DateTime.Value = System.Convert.ToDateTime(valueText, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Date ||
                    ownControl1._controlType == core.Enums.eControlType.DateNoDb)
                {
                    if (valueText == "")
                        ownControl1.Date.Value = null;
                    else
                        ownControl1.Date.Value = System.Convert.ToDateTime(valueText, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Time ||
                    ownControl1._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    if (valueText == "")
                        ownControl1.Time.Value = null;
                    else
                        ownControl1.Time.Value = System.Convert.ToDateTime(valueText, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    ownControl1.Textfield.Text = valueText;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    ownControl1.TextfieldMulti.Value = valueText;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    if (valueText == "")
                        ownControl1.CheckBox.Checked = false;
                    else
                    {
                        int valInt = System.Convert.ToInt32(valueText, CultureInfo.InvariantCulture.NumberFormat);
                        if (valInt == 0)
                            ownControl1.CheckBox.Checked = false;
                        else
                            ownControl1.CheckBox.Checked = true;
                    }

                }
                else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (valueText == "")
                        ownControl1.ThreeStateCheckBox.OwnCheckStateInt = 0;
                    else
                        ownControl1.ThreeStateCheckBox.OwnCheckStateInt = System.Convert.ToInt32(valueText, CultureInfo.InvariantCulture.NumberFormat);
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCValue.setValue", ownControl1._FldShort, false, true,
                                                            ownControl1.ownMCCriteria1.Application,
                                                            qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public qs2.core.generic.retValue getValue(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool NumericDoNull)
        {
            try
            {
                qs2.core.generic.retValue ret = new qs2.core.generic.retValue();

                if (ownControl1._controlType == core.Enums.eControlType.Integer ||
                    ownControl1._controlType == core.Enums.eControlType.IntegerNoDb ||
                    ownControl1._controlType == core.Enums.eControlType.Numeric ||
                    ownControl1._controlType == core.Enums.eControlType.NumericNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.Numeric.Value, ownControl1.Numeric.NumericType, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBox ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.ComboBox.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.ComboBox.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.ControlForDropDown.getValue(), Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                    ownControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.DateTime.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Date ||
                    ownControl1._controlType == core.Enums.eControlType.DateNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.Date.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Time ||
                    ownControl1._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.Time.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.Textfield.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.TextfieldMulti.Value, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.CheckBox.Checked, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    ret = qs2.core.generic.getValue(ownControl1._controlType, ownControl1.ThreeStateCheckBox.OwnCheckStateInt, Infragistics.Win.UltraWinEditors.NumericType.Integer, NumericDoNull);
                }
                return ret;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCValue.getValue", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        public string getValueTextCombo(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (ownControl1._controlType == core.Enums.eControlType.ComboBox)
                {
                    if (ownControl1.ComboBox.Text.Trim() != "")
                        return ownControl1.ComboBox.Text.Trim();
                    else
                        return "";
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCValue.getValueTextCombo", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return "";
            }
        }

        public void clearValue(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool AllToNull, bool setNumericMinus1, bool NoResetDB = false)
        {
            try
            {
                if (ownControl1._controlType == core.Enums.eControlType.Integer ||
                    ownControl1._controlType == core.Enums.eControlType.IntegerNoDb)
                {
                    if (setNumericMinus1)
                    {
                        ownControl1.Numeric.Value = -1;
                    }
                    else
                    {
                        ownControl1.Numeric.Value = System.DBNull.Value;
                    }
                   
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Numeric ||
                    ownControl1._controlType == core.Enums.eControlType.NumericNoDb)
                {
                    ownControl1.Numeric.Value = System.DBNull.Value;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBox ||
                    ownControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (!NoResetDB && ownControl1.ownMCCriteria1.ownMCCombo1.TypeComboBox == core.Enums.cVariablesValues.Roles)
                    {
                        ownControl1.ComboBox.Text = "";
                        ownControl1.ComboBox.Value = -1;
                        ownControl1.ownMCDataBind1.setRowValue(ownControl1, -1, true);
                    }
                    else
                    {
                        if (ownControl1.ComboBox.ValueMember == "IDOwnInt")
                        {
                            if (AllToNull)
                            {
                                ownControl1.ComboBox.Value = null;
                            }
                            else
                            {
                                ownControl1.ComboBox.Value = -1;
                            }

                        }
                        else
                        {
                            ownControl1.ComboBox.Value = System.DBNull.Value;
                        }
                    }



                    //try
                    //{
                    //    ownControl1.ComboBox.Value = -1;
                    //}
                    //catch (Exception ex2)
                    //{
                    //    ownControl1.ComboBox.Value = System.DBNull.Value;
                    //}
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (AllToNull)
                    {
                        ownControl1.ComboBox.Value = 2;
                    }
                    else
                    {
                        ownControl1.ComboBox.Value = -1;
                    }

                }
                else if (ownControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    ownControl1.ControlForDropDown.selectAllNone(false, ownControl1.ControlForDropDown._TypeUI);
                }
                else if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                    ownControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    ownControl1.DateTime.Value = null;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Date ||
                    ownControl1._controlType == core.Enums.eControlType.DateNoDb)
                {
                    ownControl1.Date.Value = null;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Time ||
                    ownControl1._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    ownControl1.Time.Value = null;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    ownControl1.Textfield.Text = "";
                }
                else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                    ownControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    ownControl1.TextfieldMulti.Value = "";
                }
                else if (ownControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    ownControl1.CheckBox.Checked = false;
                }
                else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (AllToNull)
                    {
                        ownControl1.ThreeStateCheckBox.OwnCheckStateInt = -1;
                    }
                    else
                    {
                        ownControl1.ThreeStateCheckBox.OwnCheckStateInt = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCValue.clearValue", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

    }
}
