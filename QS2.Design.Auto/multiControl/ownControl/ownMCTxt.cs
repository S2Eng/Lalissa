using System;
using System.Globalization;

namespace qs2.design.auto.multiControl
{
    public class ownMCTxt
    {
        private string _SelectedText = "";

        public bool toolTipIsInitialized = false;
        public string TextTranslated = "";
        public string TextCombinationTranslated = "";
        public string TextCombinationEndTranslated = "";
        public string SelectedText { get; set; }

        public void doText(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, bool setFldShortIfNoIDResFound, bool DesignMode)
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv")
                {
                    if (ownMultiControl1._txtIsLoaded)
                    {
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(ownMultiControl1._FldShort))
                {
                    if (ownMultiControl1._OwnLevelLeftVisible)
                    {
                        string txtFound = "";
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        txtFound = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                                                ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                                ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                                true, true, core.language.sqlLanguage.eLanguage.NoText,
                                                                                ownMultiControl1.IsEvaluation).Trim() + " ";

                        if (!string.IsNullOrWhiteSpace(txtFound))
                        {
                            ownMultiControl1.infragLabelLeft.Text = txtFound;
                            this.TextTranslated = txtFound;
                        }
                        else
                        {
                            if (setFldShortIfNoIDResFound)
                            {
                                string txtFoundTmp = qs2.core.language.sqlLanguage.checkComma(ownMultiControl1._FldShort.Trim());
                                ownMultiControl1.infragLabelLeft.Text = txtFoundTmp;
                                this.TextTranslated = txtFoundTmp;
                            }
                            else
                            {
                                ownMultiControl1.infragLabelLeft.Text = "";
                                this.TextTranslated = ownMultiControl1._FldShort.Trim() + " (No Ressource found)";
                            }
                        }
                    }
                    else
                    {
                        ownMultiControl1.infragLabelLeft.Text = "";
                    }

                    if (((ownMultiControl1._OwnLevelRightVisible ||
                        ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                        ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb ||
                        ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox) ||
                         ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb) &&
                        (!ownMultiControl1._OwnLevelLeftVisible))
                    {
                        string res = "";
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        res = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                                        ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                        ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                        true, true, core.language.sqlLanguage.eLanguage.NoText, ownMultiControl1.IsEvaluation).Trim();

                        ownMultiControl1.infragLabelRight.Text = " " + res;
                        this.TextTranslated = res;
                        if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                            ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                        {
                            ownMultiControl1.CheckBox.Text = res;
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                        {
                            ownMultiControl1.ThreeStateCheckBox.Text = res;
                        }
                    }
                    else
                    {
                        if (ownMultiControl1._OwnLevelRightVisible ||
                            ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                            ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb ||
                            ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                            ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                        {
                            string res = "";
                            qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                            res = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(),
                                                                            core.Enums.eResourceType.LabelRight,
                                                                            ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                            ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                            true, true, core.language.sqlLanguage.eLanguage.NoText, ownMultiControl1.IsEvaluation).Trim();

                            ownMultiControl1.infragLabelRight.Text = " " + res;
                            if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                            {
                                ownMultiControl1.CheckBox.Text = res;
                            }
                            else if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                    ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                            {
                                ownMultiControl1.ThreeStateCheckBox.Text = res;
                            }
                        }
                        else
                        {
                            ownMultiControl1.infragLabelRight.Text = "";
                        }

                    }

                    if (qs2.core.ENV.ExtendedUI)
                    {
                        System.Windows.Forms.ContextMenuStrip contextMenuStripSelList;
                        contextMenuStripSelList = new System.Windows.Forms.ContextMenuStrip();

                        System.Windows.Forms.ToolStripMenuItem criteriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        criteriasToolStripMenuItem.Name = "toolStripMenuItem1";
                        criteriasToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        criteriasToolStripMenuItem.Text = "criterias";
                        criteriasToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.loadedDatToolStripMenuItem_Click);

                        System.Windows.Forms.ToolStripMenuItem ressourcenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        ressourcenToolStripMenuItem.Name = "ressourcenToolStripMenuItem_Click";
                        ressourcenToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        ressourcenToolStripMenuItem.Text = "ressourcen";
                        ressourcenToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.ressourcenToolStripMenuItem_Click);

                        System.Windows.Forms.ToolStripMenuItem selListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        selListToolStripMenuItem.Name = "selListToolStripMenuItem";
                        selListToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        selListToolStripMenuItem.Text = "selList";
                        selListToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.selListToolStripMenuItem_Click);
                        
                        System.Windows.Forms.ToolStripMenuItem infoFieldSQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        infoFieldSQLServerToolStripMenuItem.Name = "infoFieldSQLServerToolStripMenuItem";
                        infoFieldSQLServerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        infoFieldSQLServerToolStripMenuItem.Text = "Info Field SQL Server";
                        infoFieldSQLServerToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.infoFieldSQLServerToolStripMenuItem_Click);

                        System.Windows.Forms.ToolStripMenuItem fielShortsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        fielShortsToolStripMenuItem.Name = "infoFieldSQLServerToolStripMenuItem";
                        fielShortsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        fielShortsToolStripMenuItem.Text = "Info Field SQL Server";
                        fielShortsToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.fielShortsToolStripMenuItem_Click);

                        System.Windows.Forms.ToolStripMenuItem infoClassificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                        infoClassificationToolStripMenuItem.Name = "infoClassificationToolStripMenuItem";
                        infoClassificationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
                        infoClassificationToolStripMenuItem.Text = "info classification";
                        infoClassificationToolStripMenuItem.Click += new System.EventHandler(ownMultiControl1.infoClassificationToolStripMenuItem_Click);
                        
                        //infoToolStripMenuItem
                        contextMenuStripSelList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                            criteriasToolStripMenuItem,
                                                            ressourcenToolStripMenuItem,
                                                            selListToolStripMenuItem,
                                                            infoFieldSQLServerToolStripMenuItem,
                                                            fielShortsToolStripMenuItem,
                                                            infoClassificationToolStripMenuItem});
                        
                        criteriasToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Criterias") + " [" + ownMultiControl1._controlType.ToString() + "]";
                        ressourcenToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Ressourcen") + " [" + ownMultiControl1._controlType.ToString() + "]";
                        selListToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("SelList");
                        infoFieldSQLServerToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("infoFieldSQLServer");
                        fielShortsToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("ListFielShorts") + " [" + ownMultiControl1._controlType.ToString() + "]";
                        infoClassificationToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Info") + " " + qs2.core.language.sqlLanguage.getRes("Classification");

                        if (System.Diagnostics.Process.GetCurrentProcess().ProcessName != "devenv" && qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                        {
                            ownMultiControl1.ContextMenuStrip = contextMenuStripSelList;
                            criteriasToolStripMenuItem.Visible = true;
                            ressourcenToolStripMenuItem.Visible = true;
                            infoClassificationToolStripMenuItem.Visible = true;
                            selListToolStripMenuItem.Visible = ownMultiControl1._controlType == core.Enums.eControlType.ComboBox;

                            infoFieldSQLServerToolStripMenuItem.Visible = true;
                            if (ownMultiControl1._FldShorts != null)
                            {
                                fielShortsToolStripMenuItem.Visible = true;
                            }
                        }
                        else if (!DesignMode && !qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                        {
                            ownMultiControl1.ContextMenuStrip = contextMenuStripSelList;
                            criteriasToolStripMenuItem.Visible = false;
                            ressourcenToolStripMenuItem.Visible = false;
                            if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                            {
                                selListToolStripMenuItem.Visible = true;
                            }
                            infoFieldSQLServerToolStripMenuItem.Visible = false;
                            if (ownMultiControl1._FldShorts != null)
                            {
                                fielShortsToolStripMenuItem.Visible = false;
                            }
                            infoClassificationToolStripMenuItem.Visible = false;
                        }
                    }

                    qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn2 = null;
                    string txtToolTip = "";
                    string txtTip = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.ToolTip,
                                                    ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                    ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn2, true, false);

                    string txtHelp = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Help,
                                                    ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                    ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn2, true, false);

                    //If Tooltip is available -> show always
                    if (!string.IsNullOrWhiteSpace(txtTip))
                    {
                        txtToolTip = txtTip;
                        if (qs2.core.ENV.ExtendedUI && !string.IsNullOrWhiteSpace(txtHelp))
                        {
                            txtToolTip += "\n" + txtHelp;
                        }
                    }
                    else
                    {
                        if (qs2.core.ENV.ExtendedUI && !string.IsNullOrWhiteSpace(txtHelp))
                        {
                            txtToolTip = txtHelp;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(txtToolTip))
                    {
                        if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                            ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                        {
                            ownMultiControl1.ownMCInfo1.doToolTipxy(ownMultiControl1.CheckBox, qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, ownMultiControl1, false, ownMultiControl1.ownMCCriteria1.Application, ownMultiControl1.OwnFieldForALLProducts);
                        }
                        else if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                                ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                        {
                            ownMultiControl1.ownMCInfo1.doToolTipxy(ownMultiControl1.ThreeStateCheckBox, qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, ownMultiControl1, false, ownMultiControl1.ownMCCriteria1.Application, ownMultiControl1.OwnFieldForALLProducts);
                        }
                        else
                        {
                            ownMultiControl1.ownMCInfo1.doToolTipxy((ownMultiControl1._OwnLevelLeftVisible == true ? ownMultiControl1.infragLabelLeft : (ownMultiControl1._OwnLevelRightVisible == true ? ownMultiControl1.infragLabelRight : null)), qs2.core.language.sqlLanguage.getRes("Info"), txtToolTip, ownMultiControl1, false, ownMultiControl1.ownMCCriteria1.Application, ownMultiControl1.OwnFieldForALLProducts);
                        }
                    }                   
                }

                if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    this.TextTranslated = ownMultiControl1.CheckBox.Text.Trim();
                    if (this.TextTranslated.Trim() == "")
                    {
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        string txtFound = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                            ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                            ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn).Trim() + " ";
                        this.TextTranslated = txtFound;
                    }
                }
                if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    this.TextTranslated = ownMultiControl1.ThreeStateCheckBox.Text.Trim();
                    if (this.TextTranslated.Trim() == "")
                    {
                        qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                        string txtFound = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                            ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                            ownMultiControl1.ownMCCriteria1.Application, ref  rLangFoundReturn).Trim() + " ";
                        this.TextTranslated = txtFound;
                    }
                }

                ownMultiControl1._txtIsLoaded = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.doText", "", false, true,
                                                                ownMultiControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void getSelectedText(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, bool DesignMode)
        {
            try
            {
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    return;

                string NoSpecification = qs2.core.language.sqlLanguage.getRes("NoSpecification").Trim();


                if (ownMultiControl1._controlType == core.Enums.eControlType.Integer ||
                    ownMultiControl1._controlType == core.Enums.eControlType.IntegerNoDb)
                {
                    if (ownMultiControl1.Numeric.Value != null && ownMultiControl1.Numeric.Value != System.DBNull.Value)
                    {
                        int val = System.Convert.ToInt32(ownMultiControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat);
                        this.SelectedText = val.ToString(qs2.core.generic.FormatInteger);
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Numeric ||
                    ownMultiControl1._controlType == core.Enums.eControlType.NumericNoDb)
                {
                    if (ownMultiControl1.Numeric.Value != null && ownMultiControl1.Numeric.Value != System.DBNull.Value)
                    {
                        if (ownMultiControl1.Numeric.Value.GetType().Name.Equals(("Int32").Trim().ToLower()) ||
                            ownMultiControl1.Numeric.Value.GetType().Name.Equals(("Int64").Trim().ToLower()))
                        {
                            int val = System.Convert.ToInt32(ownMultiControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat);
                            this.SelectedText = val.ToString(qs2.core.generic.FormatInteger);
                        }
                        else
                        {
                            double val = System.Convert.ToDouble(ownMultiControl1.Numeric.Value, CultureInfo.InvariantCulture.NumberFormat);
                            this.SelectedText = val.ToString(qs2.core.generic.FormatDecimal);
                        }
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxNoDb)
                {
                    if (ownMultiControl1.ComboBox.Value != null && ownMultiControl1.ComboBox.Text != null)
                    {
                        this.SelectedText = "'" + ownMultiControl1.ComboBox.Text.Trim() + "'";
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxCheckThreeStateBox)
                {
                    if (ownMultiControl1.ComboBox.Value != null && ownMultiControl1.ComboBox.Text != null)
                    {
                        this.SelectedText = "'" + ownMultiControl1.ComboBox.Text.Trim() + "'";
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBoxAsDropDown)
                {
                    this.SelectedText = "'" + ownMultiControl1.DropDown.Text.Trim() + "'";
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.DateTime ||
                    ownMultiControl1._controlType == core.Enums.eControlType.DateTimeNoDb)
                {
                    if (ownMultiControl1.DateTime.Value != null && ownMultiControl1.DateTime.Value != System.DBNull.Value)
                    {
                        DateTime val = System.Convert.ToDateTime(ownMultiControl1.DateTime.Value);
                        this.SelectedText = "'" + val.ToString(qs2.core.generic.FormatDateTime) + "'";
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Date ||
                    ownMultiControl1._controlType == core.Enums.eControlType.DateNoDb)
                {
                    if (ownMultiControl1.Date.Value != null && ownMultiControl1.Date.Value != System.DBNull.Value)
                    {
                        DateTime val = System.Convert.ToDateTime(ownMultiControl1.Date.Value);
                        this.SelectedText = "'" + val.ToString(qs2.core.generic.FormatDate) + "'";
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Time ||
                    ownMultiControl1._controlType == core.Enums.eControlType.TimeNoDb)
                {
                    if (ownMultiControl1.Time.Value != null && ownMultiControl1.Time.Value != System.DBNull.Value)
                    {
                        DateTime val = System.Convert.ToDateTime(ownMultiControl1.Time.Value);
                        this.SelectedText = "'" + val.ToString(qs2.core.generic.FormatTime) + "'";
                    }
                    else
                    {
                        this.SelectedText = NoSpecification;
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Textfield ||
                    ownMultiControl1._controlType == core.Enums.eControlType.TextfieldNoDb)
                {
                    if (ownMultiControl1.Textfield.Value != null && ownMultiControl1.Textfield.Text != null)
                    {
                        if (ownMultiControl1.Textfield.Value != "")
                        {
                            this.SelectedText = "'" + ownMultiControl1.Textfield.Text.Trim() + "'";
                        }
                        else
                        {
                            this.SelectedText = "''";
                        }
                    }
                    else
                    {
                        this.SelectedText = "''";
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMulti ||
                    ownMultiControl1._controlType == core.Enums.eControlType.TextfieldMultiNoDb)
                {
                    if (ownMultiControl1.TextfieldMulti.Value != null && ownMultiControl1.TextfieldMulti.Text != null)
                    {
                        if (ownMultiControl1.TextfieldMulti.Value != "")
                        {
                            this.SelectedText = "'" + ownMultiControl1.TextfieldMulti.Text.Trim() + "'";
                        }
                        else
                        {
                            this.SelectedText = "''";
                        }
                    }
                    else
                    {
                        this.SelectedText = "''";
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    qs2.design.auto.print.translateQuery translateQuerWork = new print.translateQuery();
                    System.Collections.Specialized.ListDictionary lstYesNo = translateQuerWork.getRessourceThreeStateButtons();

                    if (ownMultiControl1.CheckBox.Checked)
                    {
                        this.SelectedText = (string)lstYesNo[1];
                    }
                    else
                    {
                        this.SelectedText = (string)lstYesNo[0];
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    if (ownMultiControl1.ThreeStateCheckBox.CheckState == System.Windows.Forms.CheckState.Checked)
                    {
                        this.SelectedText = (string)ownMCGeneric.lstYesNo[1];
                    }
                    else if (ownMultiControl1.ThreeStateCheckBox.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    {
                        this.SelectedText = (string)ownMCGeneric.lstYesNo[0];
                    }
                    else if (ownMultiControl1.ThreeStateCheckBox.CheckState == System.Windows.Forms.CheckState.Indeterminate)
                    {
                        this.SelectedText = (string)ownMCGeneric.lstYesNo[-1];
                    }
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Label)
                {
                    this.SelectedText = "";
                }
                else if (ownMultiControl1._controlType == core.Enums.eControlType.Picture)
                {
                    this.SelectedText = "";
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.getSelectedText", "", false, true,
                                                                ownMultiControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void doFocus(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, bool bOn)
        {
            try
            {
                Infragistics.Win.DefaultableBoolean InfragOnOff = new Infragistics.Win.DefaultableBoolean();

                if (bOn)
                {
                    InfragOnOff = Infragistics.Win.DefaultableBoolean.True;
                }
                else
                {
                    InfragOnOff = Infragistics.Win.DefaultableBoolean.False;
                }

                ownMultiControl1.infragLabelLeft.Appearance.FontData.Underline = InfragOnOff;
                ownMultiControl1.infragLabelRight.Appearance.FontData.Underline = InfragOnOff;

                if (ownMultiControl1._controlType == core.Enums.eControlType.CheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.CheckBoxNoDb)
                {
                    ownMultiControl1.CheckBox.Appearance.FontData.Underline = InfragOnOff;
                }
                if (ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox ||
                    ownMultiControl1._controlType == core.Enums.eControlType.ThreeStateCheckBoxNoDb)
                {
                    ownMultiControl1.ThreeStateCheckBox.Appearance.FontData.Underline = InfragOnOff;
                }

            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.getSelectedText", "", false, true,
                                                                ownMultiControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
    }
}
