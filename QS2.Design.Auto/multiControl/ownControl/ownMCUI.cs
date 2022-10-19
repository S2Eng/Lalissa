using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;




namespace qs2.design.auto.multiControl
{



    public class ownMCUI
    {

        private bool _IsVisible_Criteria = false;
        private bool _IsVisible_LicenseKey = false;
        
        private bool _IsVisible_Roles = false;
        private bool _IsVisible_RelationsshipMCParent = true;
        private bool _IsVisible_RelationsshipGroups = true;
        private bool _IsVisible_RelationsshipElementProcGrp = true;
        private bool _IsVisible_RelationsshipElementChapter = true;
        private bool _IsVisible_RelationsshipElementProcGrpDropDown = true;
        private bool _IsVisible_RelationsshipElementChapterDropDown = true;
        private bool _IsVisible_RelationsshipRoles = true;

        public qs2.design.auto.multiControl.ownMultiControl ownMultiControl1 = null;
        public Infragistics.Win.Appearance AppearanceLabelFromCriteriaToSet = null;

        public System.Collections.Generic.List<cColor> lstColors = null;
        public class cColor
        {
            public Color Background ;
            public Decimal ValueFrom = -999;
            public Decimal ValueTo = -999;
            public bool ValueEquals = false;
            public bool ColorDefault = false;
        }



        




        public void doButtonAddSelList(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            if (ownMultiControl1._FldShort.Trim() != "")
            {
                System.Windows.Forms.Control cont = ownMultiControl1.ownMCUI1.doButtonControls(ownMCEvents.eTypButtonControl.addSelList, null, "", qs2.core.language.sqlLanguage.getRes("AddEntryToComboBox"), ownMultiControl1);
            }
        }

        public System.Windows.Forms.Control doButtonControls(ownMCEvents.eTypButtonControl typ, qs2.core.language.dsLanguage.RessourcenRow rResHelp,
                                                            string tag, string toolTipText, qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                Infragistics.Win.Misc.UltraButton button = null;
                if (ownMultiControl1.panelButtons.Controls.Count >= 1)
                {
                    return (System.Windows.Forms.Control)ownMultiControl1.panelButtons.Controls[0];
                    //button = ( Infragistics.Win.Misc.UltraButton)this.ownMultiControl1.panelButtons.Controls[0];
                }
                else
                {
                    button = new Infragistics.Win.Misc.UltraButton();
                    ownMultiControl1.panelButtons.Controls.Add(button);

                    //button.ShowFocusRect = false;
                    System.Drawing.Size sizeButt = new System.Drawing.Size(19, 19);
                    button.Size = sizeButt;
                    button.TabStop = false;
                    button.TabIndex = 1;
                    button.ImageSize = new System.Drawing.Size(12, 12);
                    button.Left = 2;

                    //System.Drawing.Point locButt = new System.Drawing.Point(1, 1);
                    //button.Location = locButt;
                    button.Left = 1;
                    button.Top = 1;

                    //qs2.core.ui.setInaktiv(button);
                    //button.Dock = System.Windows.Forms.DockStyle.Fill;
                    button.Visible = true;
                    button.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    button.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                    ownMultiControl1.ownMCEvents1.ownControl1 = ownMultiControl1;
                    button.Click += new System.EventHandler(ownMultiControl1.ownMCEvents1.ButtonClick);
                    ownMultiControl1.panelButtons.Visible = true;
                }

                button.Name = typ.ToString();
                button.Tag = tag.ToString();

                if (typ == ownMCEvents.eTypButtonControl.Help)
                {
                    button.Tag = rResHelp;
                    button.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Info, 32, 32);
                }
                else if (typ == ownMCEvents.eTypButtonControl.addSelList)
                {
                    button.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32);
                }
                else if (typ == ownMCEvents.eTypButtonControl.Search)
                {
                    button.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Suche, 32, 32);
                }
                else if (typ == ownMCEvents.eTypButtonControl.Clear)
                {
                    button.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32);
                }

                if (ownMultiControl1.IsEvaluation)
                {
                    ownMultiControl1.countButtonsRigth = 1;
                    ownMultiControl1.setLabels2(true, false, false);
                }
                return button;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.doButtonControls", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }



        public void doCheckBoxAdd(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            System.Windows.Forms.Control cont = ownMultiControl1.ownMCUI1.doCheckBoxAdd(ownMCEvents.eTypButtonControl.CheckBox, null, "", "", ownMultiControl1);

        }
        public System.Windows.Forms.Control doCheckBoxAdd(ownMCEvents.eTypButtonControl typ, qs2.core.language.dsLanguage.RessourcenRow rResHelp,
                                                       string tag, string toolTipText, qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                Infragistics.Win.UltraWinEditors.UltraCheckEditor CheckEdtor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
                ownMultiControl1.panelButtons.Controls.Add(CheckEdtor);

                System.Drawing.Size sizeChkBox = new System.Drawing.Size(30, 19);
                CheckEdtor.Size = sizeChkBox;
                CheckEdtor.TabStop = false;
                CheckEdtor.TabIndex = 1;
                CheckEdtor.Left = 22;
                CheckEdtor.Top = 1;
                CheckEdtor.Visible = true;
                CheckEdtor.Appearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                CheckEdtor.Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                ownMultiControl1.ownMCEvents1.ownControl1 = ownMultiControl1;
                ownMultiControl1.panelButtons.Visible = true;
                ownMultiControl1.panelButtonsOnOff.Visible = true;

                CheckEdtor.Name = typ.ToString();
                CheckEdtor.Tag = tag.ToString();

                ownMultiControl1.countButtonsRigth = 2;
                if (ownMultiControl1.IsEvaluation)
                {
                    ownMultiControl1.setLabels2(true, false, false);
                }
                else
                {
                    ownMultiControl1.setLabels2(false, false, false);
                }
                CheckEdtor.Checked = false;

                return CheckEdtor;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.doCheckBoxAdd", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return null;
            }
        }
        public bool getValueCheckBox(ref bool CheckBoxExists)
        {
            try
            {
                foreach (System.Windows.Forms.Control contFound in ownMultiControl1.panelButtons.Controls)
                {
                    if (contFound.GetType().Equals(typeof(Infragistics.Win.UltraWinEditors.UltraCheckEditor)))
                    {
                        Infragistics.Win.UltraWinEditors.UltraCheckEditor CheckEdtor = (Infragistics.Win.UltraWinEditors.UltraCheckEditor)contFound;
                        CheckBoxExists = true;
                        return CheckEdtor.Checked;
                    }
                }
                //throw new Exception("getValueCheckBox: No check-Editor found for FldShort!'" + this .ownMultiControl1.OwnFldShort.Trim()  +"'");
                return false;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.getValueCheckBox", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }
        public bool checkIsSurgeonControl(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                if ((ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBox ||
                    ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBoxNoDb ||
                    ownMultiControl1.OwnControlType == core.Enums.eControlType.ComboBoxAsDropDown) &&
                    ownMultiControl1.OwnFldShort.Trim().ToLower().Equals(("Surgeon").Trim().ToLower()))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.checkIsSurgeonControl", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return false;
            }
        }

        public void setUIFromClassification(ref ownMCCriteria ownMCCriteria1, bool IsOwnMultiControl, bool IsGroupBox,
                                            qs2.design.auto.multiControl.ownMultiControl ownMultiControl1,
                                            qs2.design.auto.multiControl.ownGroupBox ownGroupBox1, string FldShort)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(FldShort, "SumEuroScore", false))
                //{
                //    string xy = "";
                //}

                bool UIStyleFoundInClassificationLabel = false;
                Infragistics.Win.Appearance AppToSetLabel = new Infragistics.Win.Appearance();
                this.getAppearanceFromClassificationForUI(ref UIStyleFoundInClassificationLabel, ref AppToSetLabel, "Label", ref ownMCCriteria1);
                if (UIStyleFoundInClassificationLabel)
                {
                    if (IsOwnMultiControl)
                    {
                        ownMultiControl1.infragLabelLeft.UseAppStyling = false;
                        ownMultiControl1.infragLabelLeft.Appearance = AppToSetLabel;
                        ownMultiControl1.infragLabelLeft.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                        ownMultiControl1.infragLabelRight.UseAppStyling = false;
                        ownMultiControl1.infragLabelRight.Appearance = AppToSetLabel;
                        ownMultiControl1.infragLabelRight.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                        this.AppearanceLabelFromCriteriaToSet = AppToSetLabel;
                    }
                    else if (IsGroupBox)
                    {
                        ownGroupBox1.UseAppStyling = false;
                        ownGroupBox1.HeaderAppearance = AppToSetLabel;
                        //ownGroupBox1.ContentAreaAppearance.BackColor = AppToSetLabel.BackColor;
                    }
                }
                else
                {
                    if (IsOwnMultiControl)
                    {
                        ownMultiControl1.infragLabelLeft.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                        ownMultiControl1.infragLabelRight.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                    else if (IsGroupBox)
                    {
                        ownGroupBox1.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;
                    }
                }

                
                //os: Doesn't work properly, 170417
                bool UIStyleFoundInClassificationControl = false;
                Infragistics.Win.Appearance AppToSetControl = new Infragistics.Win.Appearance();
                this.getAppearanceFromClassificationForUI(ref UIStyleFoundInClassificationControl, ref AppToSetControl, "Control", ref ownMCCriteria1);
                if (UIStyleFoundInClassificationControl)
                {
                    if (IsOwnMultiControl)
                    {
                        this.setAppearanceForControl(ref AppToSetControl);
                    }
                    else if (IsGroupBox)
                    {

                    }
                }
                else
                {
                }
                
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.setUIFromClassification", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void getAppearanceFromClassificationForUI(ref bool UIStyleFoundInClassification, ref Infragistics.Win.Appearance AppToSet,
                                                        string PrefixDefinition, ref ownMCCriteria ownMCCriteria1)
        {
            try
            {
                foreach (qs2.core.Enums.cVariables varsFound in ownMCCriteria1.lstVariablesClassification)
                {
                    if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "ForeColor")).Trim().ToLower()))
                    {
                        KnownColor[] values = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                        foreach (KnownColor kc in values)
                        {
                            Color ActColor = Color.FromKnownColor(kc);
                            if (ActColor.Name.Trim().ToLower().Equals(varsFound.value.Trim().ToLower()))
                            {
                                AppToSet.ForeColor = ActColor;
                                UIStyleFoundInClassification = true;
                                continue;
                            }
                        }
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "BackColor")).Trim().ToLower()))
                    {
                        KnownColor[] values = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                        foreach (KnownColor kc in values)
                        {
                            Color ActColor = Color.FromKnownColor(kc);
                            if (ActColor.Name.Trim().ToLower().Equals(varsFound.value.Trim().ToLower()))
                            {
                                AppToSet.BackColor = ActColor;
                                UIStyleFoundInClassification = true;
                                continue;
                            }
                        }
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "FontSize")).Trim().ToLower()))
                    {
                        AppToSet.FontData.SizeInPoints = System.Convert.ToInt32(varsFound.value.Trim(), CultureInfo.InvariantCulture.NumberFormat);
                        UIStyleFoundInClassification = true;
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "Bold")).Trim().ToLower()))
                    {
                        if (varsFound.value.Trim().ToLower().Equals(("1").Trim().ToLower()))
                        {
                            AppToSet.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            UIStyleFoundInClassification = true;
                        }
                        else
                        {
                            AppToSet.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "Underline")).Trim().ToLower()))
                    {
                        if (varsFound.value.Trim().ToLower().Equals(("1").Trim().ToLower()))
                        {
                            AppToSet.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                            UIStyleFoundInClassification = true;
                        }
                        else
                        {
                            AppToSet.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "Italic")).Trim().ToLower()))
                    {
                        if (varsFound.value.Trim().ToLower().Equals(("1").Trim().ToLower()))
                        {
                            AppToSet.FontData.Italic = Infragistics.Win.DefaultableBoolean.True;
                            UIStyleFoundInClassification = true;
                        }
                        else
                        {
                            AppToSet.FontData.Italic = Infragistics.Win.DefaultableBoolean.False;
                        }
                    }
                    else if (varsFound.definition.Trim().ToLower().Equals(((PrefixDefinition + "Font")).Trim().ToLower()))
                    {
                        foreach (FontFamily font in System.Drawing.FontFamily.Families)
                        {
                            if (font.Name.Trim().ToLower().Equals(varsFound.value.Trim().ToLower()))
                            {
                                AppToSet.FontData.Name = font.Name;
                                UIStyleFoundInClassification = true;
                                continue;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.getAppearanceFromClassificationForUI", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void setAppearanceForControl(ref Infragistics.Win.Appearance AppToSet)
        {
            try
            {
                if (this.ownMultiControl1._controlType == core.Enums.eControlType.Numeric ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.NumericNoDb ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.Integer ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.IntegerNoDb)
                {
                    this.ownMultiControl1.Numeric.Appearance = AppToSet;
                    this.ownMultiControl1.Numeric.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.ComboBox ||
                        this.ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    this.ownMultiControl1.ComboBox.Appearance = AppToSet;
                    this.ownMultiControl1.ComboBox.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    this.ownMultiControl1.ComboBox.Appearance = AppToSet;
                    this.ownMultiControl1.ComboBox.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.DateTime ||
                        this.ownMultiControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    this.ownMultiControl1.DateTime.Appearance = AppToSet;
                    this.ownMultiControl1.DateTime.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.Date ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.DateNoDb)
                {
                    this.ownMultiControl1.Date.Appearance = AppToSet;
                    this.ownMultiControl1.Date.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.Time ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    this.ownMultiControl1.Time.Appearance = AppToSet;
                    this.ownMultiControl1.Time.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.Textfield ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    this.ownMultiControl1.Textfield.Appearance = AppToSet;
                    this.ownMultiControl1.Textfield.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    this.ownMultiControl1.TextfieldMulti.Appearance = AppToSet;
                    this.ownMultiControl1.TextfieldMulti.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    this.ownMultiControl1.CheckBox.Appearance = AppToSet;
                    this.ownMultiControl1.CheckBox.UseAppStyling = false;
                }
                else if (this.ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    this.ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    this.ownMultiControl1.ThreeStateCheckBox.Appearance = AppToSet;
                    this.ownMultiControl1.ThreeStateCheckBox.UseAppStyling = false;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.setAppearanceForControl", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void getColorsFromClassification(ref qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                foreach (core.Enums.cVariables var in ownMultiControl1.ownMCCriteria1.lstVariablesClassification)
                {
                    if (var.definition.Trim().ToLower().Equals(("BackColor").Trim().ToLower()))
                    {
                        cColor newColor = new cColor();
                        string sColor = "";
                        string sValueFromTo = "";
                        qs2.core.vb.funct.getVariablesLefRightOfPoint(var.value, ref sColor, ref sValueFromTo, ":");

                        bool ValueEquals = false;
                        bool ColorDefault = false;
                        string sValueFrom = "";
                        string sValueTo = "";
                        if (sValueFromTo.Contains("-"))
                        {
                            qs2.core.vb.funct.getVariablesLefRightOfPoint(sValueFromTo, ref sValueFrom, ref sValueTo, "-");
                        }
                        else
                        {
                            if (sValueFromTo.Trim().ToLower().Equals(("Default").Trim().ToLower()))
                            {
                                ColorDefault = true;
                            }
                            else
                            {
                                ValueEquals = true;
                            }
                        }

                        if (sColor.Trim().ToLower().StartsWith(("RGB").Trim().ToLower()))
                        {
                            string[] ColorTmp = sColor.Split('(');
                            ColorTmp = ColorTmp[1].Split(')');
                            ColorTmp = ColorTmp[0].Split(',');
                            newColor.Background = Color.FromArgb(System.Convert.ToInt32(ColorTmp[0]), System.Convert.ToInt32(ColorTmp[1]), System.Convert.ToInt32(ColorTmp[2]));
                        }
                        else
                        {
                            if (sColor.Trim().ToLower().Equals(("Green").Trim().ToLower()))
                            {
                                newColor.Background = Color.Green;
                            }
                            else if (sColor.Trim().ToLower().Equals(("Yellow").Trim().ToLower()))
                            {
                                newColor.Background = Color.Yellow;
                            }
                            else if (sColor.Trim().ToLower().Equals(("Red").Trim().ToLower()))
                            {
                                newColor.Background = Color.Red;
                            }
                            else if (sColor.Trim().ToLower().Equals(("White").Trim().ToLower()))
                            {
                                newColor.Background = Color.White;
                            }
                            else if (sColor.Trim().ToLower().Equals(("LemonChiffon").Trim().ToLower()))
                            {
                                newColor.Background = Color.LemonChiffon;
                            }
                            else if (sColor.Trim().ToLower().Equals(("LightCoral").Trim().ToLower()))
                            {
                                newColor.Background = Color.LightCoral;
                            }
                            else if (sColor.Trim().ToLower().Equals(("YellowGreen").Trim().ToLower()))
                            {
                                newColor.Background = Color.YellowGreen;
                            }
                            else
                            {
                                throw new Exception("getColorsFromClassification: sColor '" + sColor.Trim() + "' not allowed for FldShort '" + ownMultiControl1.OwnFldShort.Trim() + "'!");
                            }
                        }

                        if (ownMultiControl1.OwnControlType == core.Enums.eControlType.Numeric || ownMultiControl1.OwnControlType == core.Enums.eControlType.Integer)
                        {
                            if (ValueEquals)
                            {
                                newColor.ValueEquals = true;
                                sValueFromTo = sValueFromTo.Replace(".", ",");
                                newColor.ValueFrom = System.Convert.ToDecimal(sValueFromTo.Trim());
                            }
                            else if (ColorDefault)
                            {
                                newColor.ColorDefault = true;
                            }
                            else
                            {
                                sValueFrom = sValueFrom.Replace(".", ",");
                                sValueTo = sValueTo.Replace(".", ",");
                                newColor.ValueFrom = System.Convert.ToDecimal(sValueFrom.Trim());
                                newColor.ValueTo = System.Convert.ToDecimal(sValueTo.Trim());
                            }
                        }
                        else
                        {
                            throw new Exception("getColorsFromClassification: ownMultiControl1.OwnControlType '" + ownMultiControl1.OwnControlType.ToString().Trim() + "' not allowed for FldShort '" + ownMultiControl1.OwnFldShort.Trim() + "'!");
                        }

                        if (this.lstColors == null)
                        {
                            this.lstColors = new List<cColor>();
                        }
                        this.lstColors.Add(newColor);
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.getColorsFromClassification", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setColorsFromClassification(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                if (this.lstColors.Count > 0)
                {
                    bool AnyValueEqualsDefinition = false;
                    Color BackColorTmp = System.Drawing.Color.White;
                    Color ForeColorTmp = System.Drawing.Color.Black;

                    foreach (cColor Color in this.lstColors)
                    {
                        if (ownMultiControl1.OwnControlType == core.Enums.eControlType.Numeric || ownMultiControl1.OwnControlType == core.Enums.eControlType.Integer)
                        {
                            if (Color.ColorDefault)
                            {
                                BackColorTmp = Color.Background;
                            }
                            else
                            {
                                qs2.core.generic.retValue retValue1 = ownMultiControl1.ownMCDataBind1.getValueFromRow(ownMultiControl1);
                                if (retValue1.valueObj != null && retValue1.valueObj != System.DBNull.Value)
                                {
                                    //Color.Background = System.Drawing.Color.YellowGreen;        //Grenn
                                    //Color.Background = System.Drawing.Color.LemonChiffon;       //Yellow
                                    //Color.Background = System.Drawing.Color.LightCoral;         //Red

                                    //Decimal actValue = (Decimal)ownMultiControl1.Numeric.Value;
                                    Decimal actValue =  System.Convert.ToDecimal(retValue1.valueObj); 
                                    if (!Color.ValueEquals && (actValue >= Color.ValueFrom && actValue <= Color.ValueTo))
                                    {
                                        ownMultiControl1.Numeric.Appearance.BackColor = Color.Background;
                                        ownMultiControl1.Numeric.Appearance.BackColorDisabled = Color.Background;
                                        ownMultiControl1.Numeric.Appearance.ForeColor = ForeColorTmp;
                                        ownMultiControl1.Numeric.Appearance.ForeColorDisabled = ForeColorTmp;
                                        if (qs2.core.ENV.UseAppStylingDefault)
                                        {
                                            ownMultiControl1.Numeric.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                                            ownMultiControl1.Numeric.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                                            ownMultiControl1.Numeric.UseAppStyling = false;
                                        }

                                        AnyValueEqualsDefinition = true;
                                        //System.Windows.Forms.Application.DoEvents();
                                    }
                                    else if (Color.ValueEquals && actValue == Color.ValueFrom)
                                    {
                                        
                                        ownMultiControl1.Numeric.Appearance.BackColor = Color.Background;
                                        ownMultiControl1.Numeric.Appearance.BackColorDisabled = Color.Background;
                                        ownMultiControl1.Numeric.Appearance.ForeColor = ForeColorTmp;
                                        ownMultiControl1.Numeric.Appearance.ForeColorDisabled = ForeColorTmp;
                                        if (qs2.core.ENV.UseAppStylingDefault)
                                        {
                                            ownMultiControl1.Numeric.UseAppStyling = false;
                                            ownMultiControl1.Numeric.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                                            ownMultiControl1.Numeric.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                                        }
                                        AnyValueEqualsDefinition = true;
                                        //System.Windows.Forms.Application.DoEvents();
                                    }
                                    else
                                    {
                                        //ownMultiControl1.Numeric.Appearance.BackColor = System.Drawing.Color.White;
                                        //ownMultiControl1.Numeric.Appearance.BackColorDisabled = System.Drawing.Color.White;
                                        //ownMultiControl1.Numeric.UseAppStyling = true;
                                    }
                                }
                                else
                                {
                                    //ownMultiControl1.Numeric.Appearance.BackColor = System.Drawing.Color.White;
                                    //ownMultiControl1.Numeric.Appearance.BackColorDisabled = System.Drawing.Color.White;
                                    //ownMultiControl1.Numeric.UseAppStyling = true;
                                }
                            }

                        }
                        else
                        {
                            throw new Exception("setColorsFromClassification: ownMultiControl1.OwnControlType '" + ownMultiControl1.OwnControlType.ToString().Trim() + "' not allowed for FldShort '" + ownMultiControl1.OwnFldShort.Trim() + "'!");
                        }
                    }

                    if (!AnyValueEqualsDefinition)
                    {
                        ownMultiControl1.Numeric.Appearance.BackColor = BackColorTmp;
                        ownMultiControl1.Numeric.UseAppStyling = false;
                        ownMultiControl1.Numeric.Appearance.ForeColor = ForeColorTmp;
                        ownMultiControl1.Numeric.Appearance.ForeColorDisabled = ForeColorTmp;
                        ownMultiControl1.Numeric.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                        ownMultiControl1.Numeric.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                    }
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.setColorsFromClassification", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public void resetColorsMC(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1)
        {
            try
            {
                ownMultiControl1.Numeric.Appearance.BackColor = Color.White;
                ownMultiControl1.Numeric.Appearance.ForeColor = Color.Black;
                ownMultiControl1.Numeric.Appearance.ForeColorDisabled = Color.Black;
                ownMultiControl1.Numeric.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
                ownMultiControl1.Numeric.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
                ownMultiControl1.Numeric.UseAppStyling = qs2.core.ENV.UseAppStylingDefault;

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCUI.resetColorsMC", "", false, true,
                                                                    ownMultiControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }


        public System.Windows.Forms.Control buttonInPanelxy
        {
            get
            {
                //Infragistics.Win.Misc.UltraButton button = null;
                if (this.ownMultiControl1.panelButtons.Controls.Count == 1)
                {
                    return (System.Windows.Forms.Control)this.ownMultiControl1.panelButtons.Controls[0];
                    //if (this.ownMultiControl1.panelButtons.Controls[0].GetType().Equals(typeof(Infragistics.Win.Misc.UltraButton)))
                    //{
                    //    return (Infragistics.Win.Misc.UltraButton)this.ownMultiControl1.panelButtons.Controls[0];
                    //}
                    //else if (this.ownMultiControl1.panelButtons.Controls[0].GetType().Equals(typeof(Infragistics.Win.UltraWinEditors.UltraCheckEditor)))
                    //{
                    //    return (Infragistics.Win.Misc.UltraButton)this.ownMultiControl1.panelButtons.Controls[0];
                    //}
                    //else
                    //{
                    //    return null;
                    //}
                }
                else
                    return null;
            }
        }

        public bool controlIsDbDataControl(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                ownControl1._controlType == core.Enums.eControlType.Integer ||
                ownControl1._controlType == core.Enums.eControlType.Numeric ||
                ownControl1._controlType == core.Enums.eControlType.Date ||
                ownControl1._controlType == core.Enums.eControlType.DateTime ||
                ownControl1._controlType == core.Enums.eControlType.Time ||
                ownControl1._controlType == core.Enums.eControlType.CheckBox ||
                ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                ownControl1._controlType == core.Enums.eControlType.ComboBox)
            {
                return true;
            }
            else
                return false;
        }
        public bool controlIsDataControl(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            if (ownControl1._controlType == core.Enums.eControlType.Textfield ||
                ownControl1._controlType == core.Enums.eControlType.TextfieldNoDb ||
                ownControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                ownControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb ||
                ownControl1._controlType == core.Enums.eControlType.Integer ||
                ownControl1._controlType == core.Enums.eControlType.IntegerNoDb ||
                ownControl1._controlType == core.Enums.eControlType.Numeric ||
                ownControl1._controlType == core.Enums.eControlType.NumericNoDb ||
                ownControl1._controlType == core.Enums.eControlType.Date ||
                ownControl1._controlType == core.Enums.eControlType.DateNoDb ||
                ownControl1._controlType == core.Enums.eControlType.DateTime ||
                ownControl1._controlType == core.Enums.eControlType.DateTimeNoDb ||
                ownControl1._controlType == core.Enums.eControlType.Time ||
                ownControl1._controlType == core.Enums.eControlType.TimeNoDb ||
                ownControl1._controlType == core.Enums.eControlType.CheckBox ||
                ownControl1._controlType == core.Enums.eControlType.CheckBoxNoDb ||
                ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb ||
                ownControl1._controlType == core.Enums.eControlType.ComboBox ||
                ownControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
            {
                return true;
            }
            else
                return false;
        }
        public bool IsVisible_Roles
        {
            get
            {
                return this._IsVisible_Roles;
            }
            set
            {
                this._IsVisible_Roles = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_Criteriaxy
        {
            get
            {
                return this._IsVisible_Criteria;
            }
            set
            {
                this._IsVisible_Criteria = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_LicenseKey
        {
            get
            {
                return this._IsVisible_LicenseKey;
            }
            set
            {
                this._IsVisible_LicenseKey = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipMCParent
        {
            get
            {
                return this._IsVisible_RelationsshipMCParent;
            }
            set
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(this.ownMultiControl1.OwnFldShort, "vasc_IsV2", false))
                //{
                //    string xy = "";
                //}
                this._IsVisible_RelationsshipMCParent = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipGroups
        {
            get
            {
                return this._IsVisible_RelationsshipGroups;
            }
            set
            {
                this._IsVisible_RelationsshipGroups = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }

        public bool IsVisible_RelationsshipElementProcGrp
        {
            get
            {
                return this._IsVisible_RelationsshipElementProcGrp;
            }
            set
            {
                this._IsVisible_RelationsshipElementProcGrp = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipElementChapter
        {
            get
            {
                return this._IsVisible_RelationsshipElementChapter;
            }
            set
            {
                this._IsVisible_RelationsshipElementChapter = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipElementProcGrpDropDown
        {
            get
            {
                return this._IsVisible_RelationsshipElementProcGrpDropDown;
            }
            set
            {
                this._IsVisible_RelationsshipElementProcGrpDropDown = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipElementChapterDropDown
        {
            get
            {
                return this._IsVisible_RelationsshipElementChapterDropDown;
            }
            set
            {
                this._IsVisible_RelationsshipElementChapterDropDown = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }
        public bool IsVisible_RelationsshipRoles
        {
            get
            {
                return this._IsVisible_RelationsshipRoles;
            }
            set
            {
                this._IsVisible_RelationsshipRoles = value;
                if (this.ownMultiControl1 != null)
                    this.ownMultiControl1.setVisible();
            }
        }

    }
}
