using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace qs2.core
{
    public class generic
    {
        private static int minValueDefaultText = 0;

        public static event doLog evdoLog;
        public delegate void doLog(string ex, string title);

        public delegate void writeProtocoll(string txt, string info, int IDStay, string IDApplication, string IDParticipant);

        public static string incorrSel = "Incorrect selection";
        public static int idMinus = -999999;
        public static string columnNameSelection = "Selection";
        public static string columnNameText = "Text";
        public static string columnNameSort = "Sort";
        public static string columnNameSortCustomer = "SortCustomer";
        public static string columnActive = "Active";
        public static string columnNameClassification = "Classification";
        public static string columnNameType = "Type";
        public static string columnNameVal = "Val";
        public static string columnNameValTxt = "ValTxt";
        public static string columnNameIDJoin = "IDJoin";
        public static string columnNameObject = "Obj";
        public static string columnNameIDKey = "IDKey";
        public static string columnChecked = "Checked";
        public static string columnUsed = "Used";
        public static string columnNewTranslation = "NewTranslation";
        public static string columnValueTranslated = "ValueTranslated";
        public static string columnStatus = "Status";
        public static string columnNewName = "NewName";
        public static string columnNameIDGroup = "IDGroup";
        public static string columnMultiControl = "MultiControl";
        public static string columnRemoved = "Removed";
        public static string columnCheckOn = "CheckOn";
        public static string columnIsObjectComboBox = "IsObjectComboBox ";
        public static string columnNoCheckClamps = "NoCheckClamps";
        public static string columnNameEnglish = "English";
        public static string columnNameGerman = "German";
        public static string columnParameterForReport = "ParameterForReport";
        public static string columnParameterLabelTranslated = "ParameterLabelTranslated";
        public static string columnParameterCombinationTranslated = "CombinationTranslated";
        public static string columnParameterCombinationEndTranslated = "CombinationEndTranslated";
        public static string columnParameterSqlWhereUI = "SqlWhereUI";
        public static string columnOrderBy = "OrderBy";
        public static string columnNewSort = "NewSort";
        public static string columnIDGuidMainForNewSort = "IDGuidMainForNewSort";
        public static string columnAutoAddedCol = "AutoAddedCol";
        public static string columnClampEbene = "ClampEbene";
        public static string columnClampKey = "ClampKey";
        public static string typBytes = "Bytes";
        public static string maskInputInteger = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
        public static string FormatInteger = "###,###,###,###,###,##0";
        public static string maskInputDecimal = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn.nn";
        public static string FormatDecimal = "###,###,###,###,###,##0.00";
        public static int maxValueDefaultNumeric = 2147483647;
        public static int minValueDefaultNumeric = -2147483648;
        public static int maxValueDefaultText = 32767;
        public static string maskInputDateTime = "{date} {time}";
        public static string FormatDateTime = "g";
        public static string maskInputDate = "{date}";
        public static string FormatDate = "d";
        public static string maskInputTime = "{LOC}hh:mm";
        public static string FormatTime = "HH:mm";
        public static string lineBreak = "\r\n";

        [DllImport("kernel32.dll")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public static string TransEmpty = "TransEmptyEnvironment_";
        public static string prefixColAutoTranslate = "autoColTrans_";
        public static string prefixColAutoTranslateFunctions = "TRANS_";
        public delegate void dException(bool IsExternProcess);

        public static void getExep(string ex, string title, string additionalInformation)
        {
            qs2.core.generic.getExep(additionalInformation + " - " + ex.ToString(), title);
        }

        public static void getExep(string ex, string title)
        {
            if (qs2.core.generic.evdoLog != null)
                qs2.core.generic.evdoLog.Invoke(ex, "");
            else
            {
                string info = "The following error occured: " + qs2.core.generic.lineBreak + "(This error can influence the quality of the application!)" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + "Please contact your administrator." + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak;
                System.Windows.Forms.MessageBox.Show(info + ex.ToString(), "Info Error");
            }
        }

        public static DialogResult showMessageBox(string txt, MessageBoxButtons typButtons, string title)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(title))
                    title = qs2.core.language.sqlLanguage.getRes("QS2");

                Infragistics.Win.UltraMessageBox.UltraMessageBoxManager UltraMessageBoxManager1 = new Infragistics.Win.UltraMessageBox.UltraMessageBoxManager();
                Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo UltraMessageBoxInfo1 = new Infragistics.Win.UltraMessageBox.UltraMessageBoxInfo();
                UltraMessageBoxInfo1.Buttons = typButtons;
                UltraMessageBoxInfo1.Text = txt;
                
                if (typButtons == MessageBoxButtons.YesNo || typButtons == MessageBoxButtons.YesNoCancel)
                {
                    UltraMessageBoxInfo1.Icon = MessageBoxIcon.Question;
                    UltraMessageBoxInfo1.DefaultButton = MessageBoxDefaultButton.Button2;
                }
                else
                {
                    UltraMessageBoxInfo1.Icon = MessageBoxIcon.Information;
                }
                UltraMessageBoxInfo1.Caption = title;
                Application.DoEvents();

                Form frm = new Form();
                frm.TopMost = true;
                UltraMessageBoxInfo1.Owner = frm;
                UltraMessageBoxInfo1.StartPosition = Infragistics.Win.UltraMessageBox.DialogStartPosition.Manual;
                UltraMessageBoxInfo1.StartLocation =new Point(100,100);
                UltraMessageBoxInfo1.Appearance.BackColor = Color.LightSteelBlue;
                DialogResult res = UltraMessageBoxManager1.ShowMessageBox(UltraMessageBoxInfo1);
                return res;
                
            }
            catch (Exception ex)
            {
                throw new Exception("generic.showMessageBox:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }

        }

        public static System.Collections.Generic.List<string> getVarsBy(string str, string delimiter)
        {
            System.Collections.Generic.List<string> lstVars = new System.Collections.Generic.List<string>();
            string[] separators = { delimiter.Trim() };
            string[] ArgPars = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ArgPar in ArgPars)
            {
                lstVars.Add(ArgPar.Trim());
            }
            return lstVars;
        }

        public static void getListVarIDOwnInt(ref System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnInt,
                                ref System.Collections.Generic.List<qs2.core.Enums.cVariables> lstClassificationsVarIDOwnIntAll,
                                bool bIsIDOwnIntApp)
        {
            try
            {
                if (bIsIDOwnIntApp && lstClassificationsVarIDOwnInt.Count > 0)
                {
                    lstClassificationsVarIDOwnIntAll.Clear();
                }

                foreach (qs2.core.Enums.cVariables varDef in lstClassificationsVarIDOwnInt)
                {
                    System.Collections.Generic.List<string> lstVars = qs2.core.generic.getVarsBy(varDef.value.Trim(), ",");
                    foreach (string var in lstVars)
                    {
                        bool ValIsInList = false;
                        foreach (qs2.core.Enums.cVariables varDefAll in lstClassificationsVarIDOwnIntAll)
                        {
                            if (varDefAll.value.Trim().ToLower().Equals(var.Trim().ToLower()))
                            {
                                ValIsInList = true;
                            }
                        }
                        if (!ValIsInList)
                        {
                            qs2.core.Enums.cVariables c = new core.Enums.cVariables();
                            c.definition = qs2.core.Enums.cVariablesDefinition.IDOwnInt.ToString();
                            c.value = var.Trim();
                            lstClassificationsVarIDOwnIntAll.Add(c);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("getListVarIDOwnInt: " + ex.ToString());
            }
        }

        public static System.Collections.Generic.List<string> readStrVariables(string str)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            int lastPos = 0;
            bool bEnd = false;
            while (!bEnd)
            {
                int aktPos = str.IndexOf(";", lastPos);
                if (aktPos != -1)
                {
                    string var = str.Substring(lastPos, aktPos - lastPos);
                    result.Add(var);
                    lastPos = aktPos + 1;
                }
                else
                {
                    string varLast = str.Substring(lastPos, str.Length - lastPos);
                    if (varLast.Length > 0)
                    {
                        if (varLast.Length == 1)
                        {
                            if (varLast.Equals(";"))
                            {
                                bEnd = true;
                            }
                            else
                            {
                                result.Add(varLast);
                                bEnd = true;
                            }
                        }
                        else
                        {
                            result.Add(varLast);
                            bEnd = true;
                        }
                    }
                    else
                    {
                        bEnd = true;
                    }
                }
            }
            return result;
        }

        public static bool getVarsByPoint(string strAll, ref string first, ref string last)
        {
            int posSign = strAll.IndexOf(".", 0);
            if (posSign != -1)
            {
                first = strAll.Substring(0, posSign);
                last = strAll.Substring(posSign + 1, strAll.Length - posSign - 1);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static void getResourceTypes(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(Enums.eResourceType)))
            {
                string sResTyp = Enum.GetName(typeof(Enums.eResourceType), val);
                if (valList != null) valList.ValueListItems.Add(sResTyp);
                cbo?.Items.Add(sResTyp, sResTyp);

            }
        }

        public static void getSpecialDefinitionsMinValue(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(Enums.eSpecialDefinitionsMinValue)))
            {
                string sResTyp = Enum.GetName(typeof(Enums.eSpecialDefinitionsMinValue), val);
                valList?.ValueListItems.Add(sResTyp, qs2.core.language.sqlLanguage.getRes(sResTyp));
                cbo?.Items.Add(sResTyp, qs2.core.language.sqlLanguage.getRes(sResTyp));
            }
        }

        public static void getSpecialDefinitionsMaxValue(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(Enums.eSpecialDefinitionsMaxValue)))
            {
                string sResTyp = Enum.GetName(typeof(Enums.eSpecialDefinitionsMaxValue), val);
                valList?.ValueListItems.Add(sResTyp, qs2.core.language.sqlLanguage.getRes(sResTyp));
                cbo?.Items.Add(sResTyp, qs2.core.language.sqlLanguage.getRes(sResTyp));
            }
        }

        public static void getTypeSub(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(Enums.eTypeSub)))
            {
                string sResTyp = Enum.GetName(typeof(Enums.eTypeSub), val);
                valList?.ValueListItems.Add(sResTyp);
                cbo?.Items.Add(sResTyp, sResTyp);
            }
        }

        public static void getTypQueryDefs(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(Enums.eTypQueryDef)))
            {
                string sResTyp = Enum.GetName(typeof(Enums.eTypQueryDef), val);
                valList?.ValueListItems.Add(sResTyp, sResTyp);
                cbo?.Items.Add(sResTyp, sResTyp);
            }
        }

        public static void getAutoFitStyleGrid(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            foreach (int val in Enum.GetValues(typeof(ui.eAutoFitStyle)))
            {
                string sResTyp = Enum.GetName(typeof(ui.eAutoFitStyle), val);
                valList?.ValueListItems.Add(sResTyp, sResTyp);
                cbo?.Items.Add(sResTyp, sResTyp);
            }
        }

        public static core.license.doLicense.eApp searchEnumApplication(string keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(license.doLicense.eApp)))
            {
                string sResTyp = Enum.GetName(typeof(license.doLicense.eApp), val);
                if (keyToSearch == sResTyp)
                    return (core.license.doLicense.eApp)val;
            }
            throw new Exception("searchEnumApplication: key '" + keyToSearch + "' not found!");
        }
       
        public static qs2.core.Enums.eControlType searchEnumControlType(string keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(qs2.core.Enums.eControlType)))
            {
                string sResTyp = Enum.GetName(typeof(qs2.core.Enums.eControlType), val);
                if (keyToSearch.ToLower() == sResTyp.ToLower())
                {
                    return (qs2.core.Enums.eControlType)val;
                }
            }
            throw new Exception("searchEnumControlType: key '" + keyToSearch + "' not found!");
        }

        public static qs2.core.Enums.eTypSubReport searchEnumTypSubReport(string keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(qs2.core.Enums.eTypSubReport)))
            {
                string sResTyp = Enum.GetName(typeof(qs2.core.Enums.eTypSubReport), val);
                if (keyToSearch == sResTyp)
                    return (qs2.core.Enums.eTypSubReport)val;
            }
            throw new Exception("searchEnumTypSubReport: key '" + keyToSearch + "' not found!");
        }

        public static core.Enums.eResourceType searchEnumRessourcenTyp(string keyToSearch)
        {
            foreach (int val in Enum.GetValues(typeof(core.Enums.eResourceType)))
            {
                string sResTyp = Enum.GetName(typeof(core.Enums.eResourceType), val);
                if (keyToSearch == sResTyp)
                    return (core.Enums.eResourceType)val;
            }
            return Enums.eResourceType.None;
        }

        public static System.Collections.Generic.List<string> getEnumValues(Type TypeToSearch)
        {
            System.Collections.Generic.List<string> lstReturn = new System.Collections.Generic.List<string>();
            foreach (int val in Enum.GetValues(TypeToSearch))
            {
                string sResTyp = Enum.GetName(TypeToSearch, val);
                lstReturn.Add(sResTyp);
            }
            return lstReturn;
        }

        public static infoControl setFormatNumeric(int NUMERIC_PRECISION, int NUMERIC_SCALE, string ControlMinVal, string ControlMaxVal)
        {
            infoControl calculatedFormat1 = new infoControl();
            try
            {
                calculatedFormat1.PromptChar = System.Convert.ToChar("_");

                double minValue = qs2.core.generic.minValueDefaultNumeric;
                double maxValue = qs2.core.generic.maxValueDefaultNumeric;
                int lengthMaxValuePre = NUMERIC_PRECISION - NUMERIC_SCALE;
                int lengthMaxValuePost = NUMERIC_SCALE;
                //Modulo

                if (ControlMinVal != "")
                    minValue = Convert.ToDouble(ControlMinVal, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                if (ControlMaxVal != "")
                {
                    maxValue = System.Convert.ToDouble(ControlMaxVal, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                    lengthMaxValuePre = System.Convert.ToInt32((maxValue)).ToString().Length;
                    int indexPoint = ControlMaxVal.IndexOf(".", 0);
                    if (indexPoint == -1)
                        lengthMaxValuePost = 0;     // (System.Convert.ToString((int)maxValue)).Length;
                    else
                    {
                        string post = ControlMaxVal.Substring(indexPoint, ControlMaxVal.Length - indexPoint - 1);
                        lengthMaxValuePost = post.Length;
                    }
                }

                // Calc Format-Strings
                string FormatStringCalc = "";
                string MaskInputCalc = "";
                int thousands = 0;
                for (int i = 1; i <= lengthMaxValuePre; i++)
                {
                    if (i == 1)
                        FormatStringCalc = "0" + FormatStringCalc;
                    else
                        FormatStringCalc = "#" + FormatStringCalc;
                    MaskInputCalc = "n" + MaskInputCalc;
                    thousands += 1;
                    if (thousands == 3 && i != lengthMaxValuePre)
                    {
                        FormatStringCalc = "," + FormatStringCalc;
                        MaskInputCalc = "," + MaskInputCalc;
                        thousands = 0;
                    }
                }
                MaskInputCalc = "{LOC}" + MaskInputCalc;

                if (NUMERIC_SCALE == 0)
                {
                    calculatedFormat1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Integer;
                    calculatedFormat1.MinValue = (int)minValue;
                    calculatedFormat1.MaxValue = (int)maxValue;
                }
                else if (NUMERIC_SCALE > 0 && lengthMaxValuePost > 0)
                {
                    calculatedFormat1.MinValue = minValue;
                    calculatedFormat1.MaxValue = maxValue;

                    // Calc PRECISION
                    calculatedFormat1.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Decimal;
                    FormatStringCalc += ".";
                    MaskInputCalc += ".";
                    for (int i = 1; i <= lengthMaxValuePost; i++)
                    {
                        FormatStringCalc += "0";
                        MaskInputCalc += "n";
                    }
                }

                calculatedFormat1.FormatString = FormatStringCalc;
                calculatedFormat1.MaskInput = MaskInputCalc;

                return calculatedFormat1;
            }
            catch (Exception ex)
            {
                throw new Exception("generic.setFormatNumeric:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return calculatedFormat1;
            }
        }

        public static infoControl setFormatText(int CHARACTER_MAXIMUM_LENGTH, string ControlMinVal, string ControlMaxVal, bool isFormatedTxt)
        {
            infoControl calculatedFormat1 = new infoControl();
            try
            {
                int minValue = qs2.core.generic.minValueDefaultText;
                int maxValue = CHARACTER_MAXIMUM_LENGTH;
                if (!isFormatedTxt)
                {
                    if (CHARACTER_MAXIMUM_LENGTH == -1)
                        maxValue = qs2.core.generic.maxValueDefaultText;
                }
                else
                {
                    if (CHARACTER_MAXIMUM_LENGTH == -1)
                        maxValue = qs2.core.generic.maxValueDefaultText;
                }

                if (ControlMinVal != "")
                    minValue = System.Convert.ToInt32(ControlMinVal);

                if (ControlMaxVal != "")
                    maxValue = System.Convert.ToInt32(ControlMaxVal);

                calculatedFormat1.MinValue = minValue;
                calculatedFormat1.MaxValue = maxValue;

                return calculatedFormat1;
            }
            catch (Exception ex)
            {
                throw new Exception("generic.setFormatText:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
                return calculatedFormat1;
            }
        }

        public static void getConditions(Infragistics.Win.ValueList valList, Infragistics.Win.UltraWinEditors.UltraComboEditor cbo)
        {
            System.Collections.Generic.List<string> conditions = new System.Collections.Generic.List<string>();
            conditions.Add(qs2.core.sqlTxt.like);
            conditions.Add(qs2.core.sqlTxt.equals);
            conditions.Add(qs2.core.sqlTxt.notEquals);
            conditions.Add(qs2.core.sqlTxt.smaller);
            conditions.Add(qs2.core.sqlTxt.smallerEquals);
            conditions.Add(qs2.core.sqlTxt.greater);
            conditions.Add(qs2.core.sqlTxt.greaterEquals);
            conditions.Add(qs2.core.sqlTxt.isNull);
            conditions.Add(qs2.core.sqlTxt.isNotNull);
            conditions.Add(qs2.core.sqlTxt.between);
            conditions.Add(qs2.core.sqlTxt.notBetween);
            conditions.Add(qs2.core.sqlTxt.In);
            conditions.Add(qs2.core.sqlTxt.NotIn);
        
            foreach (string condition in conditions)
            {
                valList?.ValueListItems.Add(condition, qs2.core.language.sqlLanguage.getRes(condition));
                cbo?.Items.Add(condition, qs2.core.language.sqlLanguage.getRes(condition));
            }

            valList?.ValueListItems.Add("", "");
            cbo?.Items.Add("", "");
        }

        public static qs2.core.generic.retValue getValue(qs2.core.Enums.eControlType controlType, object value,
                                        Infragistics.Win.UltraWinEditors.NumericType NumericType, 
                                        bool NumericDoNull,
                                        bool doDateTimeAsTSQL = false)
        {
            try
            {
                qs2.core.generic.retValue ret = new qs2.core.generic.retValue();

                if (controlType == core.Enums.eControlType.Numeric ||
                    controlType == core.Enums.eControlType.NumericNoDb ||
                    controlType == core.Enums.eControlType.Integer ||
                    controlType == core.Enums.eControlType.IntegerNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        if (System.Convert.ToString(value).Contains(".") || System.Convert.ToString(value).Contains(","))
                        {
                            if (System.Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat) == 0)
                            {
                                if (NumericDoNull)
                                {
                                    ret.valueStr = "";
                                    ret.valueObj = null;
                                }
                                else
                                {
                                    ret.valueStr = "0";
                                    ret.valueObj = System.Convert.ToDouble(0);
                                }
                            }
                            else
                            {
                                double dbl = 0;
                                if (value.GetType().Equals(typeof(string)))
                                {
                                    dbl = Convert.ToDouble(value.ToString(), System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                                }
                                else
                                {
                                    dbl = System.Convert.ToDouble(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                                }
                                ret.valueStr = dbl.ToString().Replace(",", ".");
                                ret.valueObj = dbl;
                            }
                        }
                        else if (!System.Convert.ToString(value).Contains(".") && !System.Convert.ToString(value).Contains(","))
                        {
                            if (System.Convert.ToInt32(value) == 0)
                            {
                                if (NumericDoNull)
                                {
                                    ret.valueStr = "";
                                    ret.valueObj = null;
                                }
                                else
                                {
                                    ret.valueStr = "0";
                                    ret.valueObj = System.Convert.ToInt32(0);
                                }
                            }
                            else
                            {
                                ret.valueStr = System.Convert.ToString(value);
                                ret.valueObj = System.Convert.ToInt32(value);
                            }
                        }
                        else
                        {
                            ret.valueStr = "";
                            ret.valueObj = null;
                        }
                    }
                }
                else if (controlType == core.Enums.eControlType.ComboBox ||
                            controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        ret.valueStr = System.Convert.ToString(value);
                        try
                        {
                            ret.valueObj = System.Convert.ToInt32(value);
                        }
                        catch (Exception ex2)
                        {
                            try
                            {
                                ret.valueObj = value.ToString();
                            }
                            catch (Exception ex3)
                            {
                                System.Guid guid = new System.Guid(value.ToString());
                                ret.valueObj = guid;
                            }
                        }
                    }
                }
                else if (controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        ret.valueStr = System.Convert.ToString(value);
                        try
                        {
                            ret.valueObj = System.Convert.ToInt32(value);
                        }
                        catch (Exception ex2)
                        {
                            System.Guid guid = new System.Guid(value.ToString());
                            ret.valueObj = guid;
                        }
                    }
                }
                else if (controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        ret.valueStr = value.ToString();
                        ret.valueObj = value.ToString();
                    }
                }
                else if (controlType == core.Enums.eControlType.DateTime ||
                            controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        DateTime dateTime = System.Convert.ToDateTime(value, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        ret.valueStr = dateTime.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        ret.valueObj = dateTime;
                    }
                }
                else if (controlType == core.Enums.eControlType.Date ||
                            controlType == core.Enums.eControlType.DateNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        DateTime dat = System.Convert.ToDateTime(value, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        dat = new DateTime(dat.Year, dat.Month, dat.Day, 0, 0, 0);
                        ret.valueStr = dat.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        ret.valueObj = dat;
                    }
                }
                else if (controlType == core.Enums.eControlType.Time ||
                            controlType == core.Enums.eControlType.TimeNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = null;
                    }
                    else
                    {
                        DateTime time = System.Convert.ToDateTime(value, System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        time = new DateTime(1900, 1, 1, time.Hour, time.Minute, time.Second);
                        ret.valueStr = time.ToString(System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat);
                        ret.valueObj = time;
                    }
                }
                else if (((controlType == core.Enums.eControlType.Textfield) ||
                            (controlType == core.Enums.eControlType.TextfieldMulti)) ||
                            ((controlType == core.Enums.eControlType.TextfieldNoDb) ||
                            (controlType == core.Enums.eControlType.TextfieldMultiNoDb)))
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "";
                        ret.valueObj = "";
                    }
                    else
                    {
                        ret.valueStr = System.Convert.ToString(value);
                        ret.valueObj = System.Convert.ToString(value);
                    }
                }
                else if (controlType == core.Enums.eControlType.CheckBox ||
                        controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "0";
                        ret.valueObj = false;
                    }
                    else
                    {
                        int valInt = System.Convert.ToInt32(value);
                        ret.valueStr = valInt.ToString();
                        ret.valueObj = System.Convert.ToBoolean(valInt);
                    }
                }
                else if (controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                        controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (generic.checkValueNull(value))
                    {
                        ret.valueStr = "-1";
                        ret.valueObj = -1;
                    }
                    else
                    {
                        ret.valueStr = System.Convert.ToString(value);
                        ret.valueObj = System.Convert.ToInt32(value);
                    }
                }

                return ret;
            }
            catch (Exception ex)
            {
                throw new Exception("generic.getValue:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        private static bool checkValueNull(object value)
        {

            if (value == null)
            {
                return true;
            }
            else
            {
                if (value.Equals(System.DBNull.Value))
                {
                    return true;
                }
                else if (value.GetType().Equals(typeof(string)))
                {
                    if (value.ToString() == "")
                        return true;
                }
            }

            return false;
        }

        public static void readVariableAndValue(string str, ref string VariableReturn, ref string ValueReturn)
        {
            int posEquals = str.IndexOf("=");
            if (posEquals != -1)
            {
                VariableReturn = str.Substring(0, posEquals).Trim();
                ValueReturn = str.Substring(posEquals + 1, str.Length - (posEquals + 1)).Trim();
            }
        }

        public static void getValues(string str, string delimiter, ref System.Collections.Generic.List<string> lstValuesFound)
        {
            try
            {
                int iPosActuell = 0;
                while (iPosActuell <= str.Length)
                {
                    bool exit = false;
                    int nextPosDelimitier = str.IndexOf(delimiter.Trim(), iPosActuell);
                    string sVar = "";
                    if (nextPosDelimitier == -1)
                    {
                        sVar = str.Substring(iPosActuell, str.Length - iPosActuell);
                        exit = true;
                    }
                    else
                    {
                        sVar = str.Substring(iPosActuell, nextPosDelimitier - iPosActuell);
                    }
                    if (!String.IsNullOrWhiteSpace(sVar))
                    {
                        lstValuesFound.Add(sVar.Trim());
                    }
                    if (exit)
                    {
                        return;
                    }
                    iPosActuell = nextPosDelimitier + 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("getValues: " + ex.ToString());
            }
        }

        public static string readStrBetween(string strToSearch, ref int actPos, string separatorToSearchBetween,
                                            string separatorToSearchEnd, bool forwarding, bool searchFirstPos,
                                            bool returnEmptyIfNotContains)
        {
            if (actPos > strToSearch.Length)
                return "";

            if (returnEmptyIfNotContains)
            {
                // Search-String not contains separatorToSearchBetween
                string subToSearch = strToSearch.Substring(actPos, strToSearch.Length - actPos);
                if (!subToSearch.Contains(separatorToSearchBetween))
                    return "";
            }

            if (searchFirstPos)
            {
                int posForSearching = actPos;
                bool firstSignPosFound = false;
                bool abort = false;
                while (posForSearching <= strToSearch.Length && !abort && !firstSignPosFound)
                {
                    if (posForSearching == strToSearch.Length)
                        abort = true;
                    else
                    {
                        string nextSign = qs2.core.generic.getSubstring(strToSearch, posForSearching, 1);
                        if (nextSign == separatorToSearchBetween)
                        {
                            firstSignPosFound = true;
                        }
                        else
                            posForSearching += 1;
                    }
                }
                if (firstSignPosFound)
                    actPos = posForSearching;
            }

            if (forwarding)
            {
                bool lastSpaceFound = false;
                int posToSearch = actPos;
                while (posToSearch <= strToSearch.Length && !lastSpaceFound)
                {
                    if (posToSearch == strToSearch.Length)
                        lastSpaceFound = true;
                    else
                    {
                        string nextSign = qs2.core.generic.getSubstring(strToSearch, posToSearch, 1);
                        if (nextSign == separatorToSearchBetween)
                        {
                            posToSearch += 1;
                        }
                        else
                            lastSpaceFound = true;
                    }
                }
                actPos = posToSearch;
            }

            int actPosNextSpace = -1;
            actPosNextSpace = qs2.core.generic.nextPos(strToSearch, separatorToSearchEnd.Trim() == "" ? separatorToSearchBetween : separatorToSearchEnd, actPos);

            if (actPosNextSpace != -1)
            {
                int actPosRead = actPos;
                actPos = actPosNextSpace;
                return qs2.core.generic.getSubstring(strToSearch, actPosRead, actPosNextSpace - actPosRead);
            }
            else
            {
                int actPosRead = actPos;
                actPos = strToSearch.Length;
                return qs2.core.generic.getSubstring(strToSearch, actPosRead, strToSearch.Length - actPosRead);
            }
        }

        public static string getSubstring(string strToSearch, int startIndex, int length)
        {
            return strToSearch.Substring(startIndex, length);
        }

        public static int nextPos(string strToSearch, string searchStr, int actPos)
        {
            return strToSearch.IndexOf(searchStr, actPos);
        }

        public class retValue
        {
            public string valueStr = "";
            public object valueObj = null;
            public string valueSql = "";
            public string fieldInfo = "";
            public string sType = "";
        }

        public class infoControl
        {
            public string FormatString = "";
            public string MaskInput = "";
            public double MinValue = 0;
            public double MaxValue = 0;
            public char PromptChar = System.Convert.ToChar("_");
            public Infragistics.Win.UltraWinEditors.NumericType NumericType;
        }
 
        public static void WaitMilli(int WaitMilliseconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitMilliseconds)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        public static void TogglePassword(object sender)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Control))
            {
                if (sender.GetType().Equals(typeof(Infragistics.Win.UltraWinEditors.UltraTextEditor)))
                {
                    Infragistics.Win.UltraWinEditors.UltraTextEditor ed = (Infragistics.Win.UltraWinEditors.UltraTextEditor)sender;
                    if (ed.PasswordChar == '\0')
                        ed.PasswordChar = '*';
                    else
                        ed.PasswordChar = '\0';
                }
                Application.DoEvents();
            }
        }

        public static string TranslateEx(string STranslate)
        {
            try
            {
                return string.IsNullOrWhiteSpace(qs2.core.language.sqlLanguage.getRes(STranslate)) ? STranslate : qs2.core.language.sqlLanguage.getRes(STranslate);
            }
            catch (Exception ex)
            {
                throw new Exception("qs2.generic.TranslateEx: " + ex.ToString());
            }
        }
    }
}