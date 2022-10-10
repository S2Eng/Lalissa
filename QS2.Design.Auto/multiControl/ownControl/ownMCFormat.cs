using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using S2Extensions;


namespace qs2.design.auto.multiControl
{



    public class ownMCFormat
    {

        public qs2.core.generic.infoControl calculatedFormat1;
        public bool formatInitialized = false;







        public void setFormatFromDb(qs2.design.auto.multiControl.ownMultiControl ownControl1, bool DefaultValueCanBeNullxy, bool ExceptionColSysNotFound)
        {
            try
            {
                if (this.formatInitialized)
                {
                    return;
                }

                if (ownControl1.ownMCUI1.controlIsDbDataControl(ownControl1))
                {
                    //if (ownControl1.ownMCUI1.controlIsVisible && ownControl1.ownMCCriteria1.rCriteria != null)
                    //{
                    if (ownControl1.ownMCCriteria1.rCriteria != null)
                    {
                        string SourceTableForSetFormat = ownControl1.ownMCCriteria1.rCriteria.SourceTable;
                        string FldSHortForSetFormat = ownControl1.ownMCCriteria1.rCriteria.FldShort;
                        FldSHortForSetFormat = qs2.core.language.sqlLanguage.checkComma(ownControl1.ownMCCriteria1.rCriteria.FldShort);

                        qs2.core.SysDB.dsSysDB.COLUMNSRow rColSys = qs2.core.SysDB.sqlSysDB.getSysColumnRow(SourceTableForSetFormat, FldSHortForSetFormat, qs2.core.SysDB.sqlSysDB.dsSysDBAll, ExceptionColSysNotFound);
                        if (rColSys == null)
                        {
                            if (!ExceptionColSysNotFound)
                            {
                                return;
                            }
                        }

                        //lth Checken, ob systyp gleich controltyp ist
                        if (ownControl1._controlType == core.Enums.eControlType.Numeric ||
                            ownControl1._controlType == core.Enums.eControlType.Integer)
                        {
                            //if (ownControl1._controlType == core.Enums.eControlType.Integer)
                            //{
                            //    string xy = "";
                            //}

                            ownControl1.Numeric.FormatString = "";
                            ownControl1.Numeric.MaskInput = "";

                            int NUMERIC_PRECISION = 10;
                            int NUMERIC_SCALE = 2;
                            //if (!rColSys.IsNUMERIC_PRECISIONNull())
                            NUMERIC_PRECISION = rColSys.NUMERIC_PRECISION;
                            //else
                            //    return;

                            //if (!rColSys.IsNUMERIC_PRECISIONNull())
                            if (!rColSys.IsNUMERIC_SCALENull())
                            {
                                NUMERIC_SCALE = rColSys.NUMERIC_SCALE;
                            }
                            else
                            {
                                //string xy = "";
                                //ownControl1.ownMCCriteria1.rCriteria.ControlMinVal = "0.0";
                                //ownControl1.ownMCCriteria1.rCriteria.ControlMaxVal = "999.0";
                            }

                            //if (ownControl1.ownMCCriteria1.rCriteria.ControlMaxVal.Trim() != "")
                            //{
                            //    string xy = "";
                            //}
                            this.calculatedFormat1 = qs2.core.generic.setFormatNumeric(NUMERIC_PRECISION, NUMERIC_SCALE, ownControl1.ownMCCriteria1.rCriteria.ControlMinVal, ownControl1.ownMCCriteria1.rCriteria.ControlMaxVal);

                            ownControl1.Numeric.PromptChar = calculatedFormat1.PromptChar;
                            ownControl1.Numeric.NumericType = calculatedFormat1.NumericType;

                            ownControl1.Numeric.MinValue = qs2.core.generic.minValueDefaultNumeric;
                            ownControl1.Numeric.MaxValue = qs2.core.generic.maxValueDefaultNumeric;

                            if (calculatedFormat1.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                            {
                                //this.Numeric.MinValue = (int)calculatedFormat1.MinValue;
                                //this.Numeric.MaxValue = (int)calculatedFormat1.MaxValue;
                            }
                            else if (calculatedFormat1.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Decimal)
                            {
                                //this.Numeric.MinValue = calculatedFormat1.MinValue;
                                //this.Numeric.MaxValue = calculatedFormat1.MaxValue;
                            }

                            // Override calculated Format-Strings
                            if (ownControl1.ownMCCriteria1.rCriteria.ControlPattern != "")
                                calculatedFormat1.FormatString = ownControl1.ownMCCriteria1.rCriteria.ControlPattern;
                            if (ownControl1.ownMCCriteria1.rCriteria.MaskInput != "")
                                calculatedFormat1.MaskInput = ownControl1.ownMCCriteria1.rCriteria.MaskInput;

                            ownControl1.Numeric.FormatString = calculatedFormat1.FormatString;
                            ownControl1.Numeric.MaskInput = calculatedFormat1.MaskInput;
                            ownControl1.Numeric.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.DateTime)
                        {
                            this.calculatedFormat1 = new qs2.core.generic.infoControl();
                            calculatedFormat1.FormatString = qs2.core.generic.FormatDateTime;
                            calculatedFormat1.MaskInput = qs2.core.generic.maskInputDateTime;

                            if (ownControl1.ownMCCriteria1.rCriteria.ControlPattern != "")
                                calculatedFormat1.FormatString = ownControl1.ownMCCriteria1.rCriteria.ControlPattern;
                            if (ownControl1.ownMCCriteria1.rCriteria.MaskInput != "")
                                calculatedFormat1.MaskInput = ownControl1.ownMCCriteria1.rCriteria.MaskInput;

                            ownControl1.DateTime.FormatString = calculatedFormat1.FormatString;
                            ownControl1.DateTime.MaskInput = calculatedFormat1.MaskInput;
                            ownControl1.DateTime.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Date)
                        {
                            this.calculatedFormat1 = new qs2.core.generic.infoControl();
                            calculatedFormat1.FormatString = qs2.core.generic.FormatDate;
                            calculatedFormat1.MaskInput = qs2.core.generic.maskInputDate;

                            if (ownControl1.ownMCCriteria1.rCriteria.ControlPattern != "")
                                calculatedFormat1.FormatString = ownControl1.ownMCCriteria1.rCriteria.ControlPattern;
                            if (ownControl1.ownMCCriteria1.rCriteria.MaskInput != "")
                                calculatedFormat1.MaskInput = ownControl1.ownMCCriteria1.rCriteria.MaskInput;

                            ownControl1.Date.FormatString = calculatedFormat1.FormatString;
                            ownControl1.Date.MaskInput = calculatedFormat1.MaskInput;
                            ownControl1.Date.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Time)
                        {
                            this.calculatedFormat1 = new qs2.core.generic.infoControl();
                            calculatedFormat1.FormatString = qs2.core.generic.FormatTime;
                            calculatedFormat1.MaskInput = qs2.core.generic.maskInputTime;

                            if (ownControl1.ownMCCriteria1.rCriteria.ControlPattern != "")
                                calculatedFormat1.FormatString = ownControl1.ownMCCriteria1.rCriteria.ControlPattern;
                            if (ownControl1.ownMCCriteria1.rCriteria.MaskInput != "")
                                calculatedFormat1.MaskInput = ownControl1.ownMCCriteria1.rCriteria.MaskInput;

                            ownControl1.Time.FormatString = calculatedFormat1.FormatString;
                            ownControl1.Time.MaskInput = calculatedFormat1.MaskInput;
                            ownControl1.Time.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Textfield)
                        {
                            int CHARACTER_MAXIMUM_LENGTH = qs2.core.generic.maxValueDefaultText;
                            //if (!rColSys.IsCHARACTER_MAXIMUM_LENGTHNull())
                            CHARACTER_MAXIMUM_LENGTH = rColSys.CHARACTER_MAXIMUM_LENGTH;
                            //else
                            //    CHARACTER_MAXIMUM_LENGTH = -1;
                            this.calculatedFormat1 = qs2.core.generic.setFormatText(CHARACTER_MAXIMUM_LENGTH, ownControl1.ownMCCriteria1.rCriteria.ControlMinVal, ownControl1.ownMCCriteria1.rCriteria.ControlMaxVal, false);
                            ownControl1.Textfield.Tag = calculatedFormat1;
                            ownControl1.Textfield.MaxLength = qs2.core.generic.maxValueDefaultText;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti)
                        {
                            int CHARACTER_MAXIMUM_LENGTH = qs2.core.generic.maxValueDefaultText;
                            //if (!rColSys.IsCHARACTER_MAXIMUM_LENGTHNull())
                            CHARACTER_MAXIMUM_LENGTH = rColSys.CHARACTER_MAXIMUM_LENGTH;
                            //else
                            //    CHARACTER_MAXIMUM_LENGTH = -1;
                            this.calculatedFormat1 = qs2.core.generic.setFormatText(CHARACTER_MAXIMUM_LENGTH, ownControl1.ownMCCriteria1.rCriteria.ControlMinVal, ownControl1.ownMCCriteria1.rCriteria.ControlMaxVal, true);
                            ownControl1.TextfieldMulti.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.ComboBox)
                        {
                            this.calculatedFormat1 = new core.generic.infoControl();
                            ownControl1.ComboBox.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.CheckBox)
                        {
                            this.calculatedFormat1 = new core.generic.infoControl();
                            ownControl1.CheckBox.Tag = calculatedFormat1;
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox)
                        {
                            this.calculatedFormat1 = new core.generic.infoControl();
                            ownControl1.ThreeStateCheckBox.Tag = calculatedFormat1;
                        }
                        else
                        {
                            throw new Exception("ownMCFormat.setFormat: ControlType '" + ownControl1._controlType + "' not suppurted!");
                        }
                    }
                }

                this.formatInitialized = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCFormat.setFormat", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application, qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void setFormatNoCriteria(qs2.design.auto.multiControl.ownMultiControl ownControl1, Infragistics.Win.UltraWinEditors.NumericType NumericType)
        {
            try
            {
                if (ownControl1.ownMCUI1.controlIsDataControl(ownControl1))
                {
                    if (ownControl1._controlType == core.Enums.eControlType.Integer ||
                        ownControl1._controlType == core.Enums.eControlType.IntegerNoDb ||
                        ownControl1._controlType == core.Enums.eControlType.Numeric ||
                        ownControl1._controlType == core.Enums.eControlType.NumericNoDb)
                    {
                        ownControl1.Numeric.FormatString = "";
                        ownControl1.Numeric.MaskInput = "";
                        ownControl1.Numeric.Value = 0;
                        ownControl1.Numeric.NumericType = NumericType;

                        if (NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                        {
                            ownControl1.Numeric.FormatString = qs2.core.generic.FormatInteger;
                            ownControl1.Numeric.MaskInput = qs2.core.generic.maskInputInteger;
                        }
                        else
                        {
                            ownControl1.Numeric.FormatString = qs2.core.generic.FormatDecimal;
                            ownControl1.Numeric.MaskInput = qs2.core.generic.maskInputDecimal;
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.DateTime ||
                        ownControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                    {
                        ownControl1.DateTime.FormatString = qs2.core.generic.FormatDateTime;
                        ownControl1.DateTime.MaskInput = qs2.core.generic.maskInputDateTime;
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Date ||
                        ownControl1._controlType == core.Enums.eControlType.DateNoDb)
                    {
                        ownControl1.Date.FormatString = qs2.core.generic.FormatDate;
                        ownControl1.Date.MaskInput = qs2.core.generic.maskInputDate;
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Time ||
                        ownControl1._controlType == core.Enums.eControlType.TimeNoDb)
                    {
                        ownControl1.Time.FormatString = qs2.core.generic.FormatTime;
                        ownControl1.Time.MaskInput = qs2.core.generic.maskInputTime;
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                        ownControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                    {
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                        ownControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCFormat.setFormatNoCriteria", ownControl1._FldShort, false, true,
                                                                    ownControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public bool checkInput(qs2.design.auto.multiControl.ownMultiControl ownControl1, ref string message, bool withMsgBox)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownControl1._FldShort, "CPlegia_ml", false))
                //{
                //    string xy = "";
                //}

                //if (this.calculatedFormat1 == null) return true;
                if (ownControl1.checkIsVisible() && ownControl1.ownMCCriteria1.rCriteria != null)      //lth
                {
                    if (!ownControl1.ownMCCriteria1.rCriteria.Validate)
                        return true;

                    if (ownControl1._controlType == core.Enums.eControlType.Integer ||
                        ownControl1._controlType == core.Enums.eControlType.Numeric)
                    {
                        //if (this.calculatedFormat1 == null) return true;

                        //if (ownControl1._controlType == core.Enums.eControlType.Integer)
                        //{
                        //    string xy = "";
                        //}

                        if (ownControl1.Numeric.Value == System.DBNull.Value)
                        {
                            return true;
                        }
                        if (calculatedFormat1.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Integer)
                        {
                            int defaultValue = System.Convert.ToInt32(ownControl1.ownMCCriteria1.defaultDBValue.valueStr, CultureInfo.InvariantCulture.NumberFormat);
                            if ((System.Convert.ToDouble(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) >= this.calculatedFormat1.MinValue && System.Convert.ToDouble(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) <= this.calculatedFormat1.MaxValue) ||
                                System.Convert.ToInt32(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) == defaultValue)
                            {
                                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                                ownControl1.doActionControl(ownMultiControl.eTypActionControl.clearErrorProvider, ref calculatedFormatTmp, false);
                                return true;
                            }
                            else
                            {
                                string sTxtTranslated = qs2.core.language.sqlLanguage.getRes("ValueExeedsLimits");
                                sTxtTranslated = System.String.Format(sTxtTranslated, this.calculatedFormat1.MinValue.ToString(qs2.core.generic.FormatInteger), this.calculatedFormat1.MaxValue.ToString(qs2.core.generic.FormatInteger));
                                message = sTxtTranslated;
                                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                                ownControl1.doActionControl(ownMultiControl.eTypActionControl.showError, ref calculatedFormatTmp, false);
                                if (withMsgBox)
                                {
                                    qs2.core.generic.showMessageBox(message, System.Windows.Forms.MessageBoxButtons.OK, "");
                                }
                                return false;
                            }
                        }
                        else if (calculatedFormat1.NumericType == Infragistics.Win.UltraWinEditors.NumericType.Decimal)
                        {
                            double defaultValue = System.Convert.ToDouble(ownControl1.ownMCCriteria1.defaultDBValue.valueStr, CultureInfo.InvariantCulture.NumberFormat);
                            if ((System.Convert.ToDouble(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) >= this.calculatedFormat1.MinValue && System.Convert.ToDouble(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) <= this.calculatedFormat1.MaxValue) ||
                                System.Convert.ToDouble(ownControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat) == defaultValue)
                            {
                                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                                ownControl1.doActionControl(ownMultiControl.eTypActionControl.clearErrorProvider, ref calculatedFormatTmp, false);
                                return true;
                            }
                            else
                            {
                                string sTxtTranslated = qs2.core.language.sqlLanguage.getRes("ValueExeedsLimits");
                                sTxtTranslated = System.String.Format(sTxtTranslated, this.calculatedFormat1.MinValue.ToString(qs2.core.generic.FormatInteger), this.calculatedFormat1.MaxValue.ToString(qs2.core.generic.FormatInteger));
                                message = sTxtTranslated;
                                qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                                ownControl1.doActionControl(ownMultiControl.eTypActionControl.showError, ref calculatedFormatTmp, false);
                                if (withMsgBox)
                                {
                                    qs2.core.generic.showMessageBox(message, System.Windows.Forms.MessageBoxButtons.OK, "");
                                }
                                return false;
                            }
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.Textfield)
                    {
                        message = "";
                        if (ownControl1.Textfield.Text.sEquals("'", S2Extensions.Enums.eCompareMode.Contains))
                            message = qs2.core.language.sqlLanguage.getRes("ValueMayNotContainSingleQuotes", "ALL", "ALL", "Das Feld darf kein Hochkomma enthalten", false, true);
                        else if (ownControl1.Textfield.Text.Length < this.calculatedFormat1.MinValue || ownControl1.Textfield.Text.Length > this.calculatedFormat1.MaxValue)
                            message = qs2.core.language.sqlLanguage.getRes("ValueLengthMustBetween") + " " + this.calculatedFormat1.MinValue.ToString() + " " + qs2.core.language.sqlLanguage.getRes("and") + " " + this.calculatedFormat1.MaxValue.ToString();

                        qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                        if (String.IsNullOrWhiteSpace(message))
                        {
                            ownControl1.doActionControl(ownMultiControl.eTypActionControl.clearError, ref calculatedFormatTmp, false);
                            return true;
                        }
                        else
                        {
                            ownControl1.doActionControl(ownMultiControl.eTypActionControl.showError, ref calculatedFormatTmp, false);
                            if (withMsgBox)
                                qs2.core.generic.showMessageBox(message, System.Windows.Forms.MessageBoxButtons.OK, "");
                            return false;
                        }
                    }
                    else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti)
                    {
                        message = "";
                        if (ownControl1.TextfieldMulti.Text.sEquals("'", S2Extensions.Enums.eCompareMode.Contains))
                            message = qs2.core.language.sqlLanguage.getRes("ValueMayNotContainSingleQuotes", "ALL", "ALL", "Das Feld darf kein Hochkomma enthalten", false, true);
                        else if (ownControl1.TextfieldMulti.Text.Length < this.calculatedFormat1.MinValue || ownControl1.TextfieldMulti.Text.Length > this.calculatedFormat1.MaxValue)
                            message = qs2.core.language.sqlLanguage.getRes("ValueLengthMustBetween") + " " + this.calculatedFormat1.MinValue.ToString() + " " + qs2.core.language.sqlLanguage.getRes("and") + " " + this.calculatedFormat1.MaxValue.ToString();

                        qs2.core.generic.infoControl calculatedFormatTmp = new qs2.core.generic.infoControl();
                        if (String.IsNullOrWhiteSpace(message))
                        {
                            ownControl1.doActionControl(ownMultiControl.eTypActionControl.clearError, ref calculatedFormatTmp, false);
                            return true;
                        }
                        else
                        {
                            ownControl1.doActionControl(ownMultiControl.eTypActionControl.showError, ref calculatedFormatTmp, false);
                            if (withMsgBox)
                                qs2.core.generic.showMessageBox(message, System.Windows.Forms.MessageBoxButtons.OK, "");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCFormat.checkInput", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

    }
}
