using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;




namespace qs2.design.auto.multiControl
{



    public class ownMCTxt
    {

        public bool toolTipIsInitialized = false;
        public string TextTranslated = "";
        public string TextRightTranslated = "";

        private string _SelectedText = "";

        public static int counterCallsFctSelectText = 0;
        public string TextCombinationTranslated = "";
        public string TextCombinationEndTranslated = "";








        public void doText(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, bool setFldShortIfNoIDResFound, bool DesignMode)
        {
            try
            {
                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1.OwnFldShort, "PreOpDiagGeneral", false))
                //{
                //    string xy = "";
                //}

                if (!DesignMode)
                {
                    if (ownMultiControl1._txtIsLoaded)
                    {
                        return;
                    }
                }
                //qs2.design.auto.workflowAssist.autoForm.UIPrepareThread.CriteriaThread CriteriaThread = null;

                if (ownMultiControl1._FldShort.Trim() != "")
                {
                    if (ownMultiControl1._OwnLevelLeftVisible)
                    {
                        //qs2.design.auto.workflowAssist.autoForm.UIPrepareThread.dicProducts.TryGetValue(ownMultiControl1.OwnFldShort.Trim(), out CriteriaThread);
                        string txtFound = "";
                        //if (CriteriaThread == null || ownMultiControl1.IsEvaluation)
                        //{
                            qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                            txtFound = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                                                    ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                                    ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                                    true, true, core.language.sqlLanguage.eLanguage.NoText,
                                                                                    ownMultiControl1.IsEvaluation).Trim() + " ";

                        //}
                        //else
                        //{
                        //    txtFound = CriteriaThread.txtTranslated;
                        //}

                        if (!txtFound.Trim().Equals(""))
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
                        //qs2.design.auto.workflowAssist.autoForm.UIPrepareThread.dicProducts.TryGetValue(ownMultiControl1.OwnFldShort.Trim(), out CriteriaThread);
                        string res = "";
                        //if (CriteriaThread == null || ownMultiControl1.IsEvaluation)
                        //{
                            qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                            res = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(), core.Enums.eResourceType.Label,
                                                                            ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                            ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                            true, true, core.language.sqlLanguage.eLanguage.NoText, ownMultiControl1.IsEvaluation).Trim();
                        //}
                        //else
                        //{
                        //    res = CriteriaThread.txtTranslated;
                        //}

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
                            //qs2.design.auto.workflowAssist.autoForm.UIPrepareThread.dicProducts.TryGetValue(ownMultiControl1.OwnFldShort.Trim(), out CriteriaThread);
                            string res = "";
                            //if (CriteriaThread == null || ownMultiControl1.IsEvaluation)
                            //{
                                qs2.core.language.dsLanguage.RessourcenRow rLangFoundReturn = null;
                                res = qs2.core.language.sqlLanguage.getRes(ownMultiControl1._FldShort.Trim(),
                                                                                core.Enums.eResourceType.LabelRight,
                                                                                ownMultiControl1.ownMCCriteria1.IDParticipant,
                                                                                ownMultiControl1.ownMCCriteria1.Application, ref rLangFoundReturn,
                                                                                true, true, core.language.sqlLanguage.eLanguage.NoText, ownMultiControl1.IsEvaluation).Trim();
                            //}
                            //else
                            //{
                            //    res = CriteriaThread.txtTranslatedLabelRight;
                            //}

                            ownMultiControl1.infragLabelRight.Text = " " + res;
                            this.TextRightTranslated = res;
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
                        //infoToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Info");
                        //infoToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Info, 32, 32);
                        infoClassificationToolStripMenuItem.Text = qs2.core.language.sqlLanguage.getRes("Info") + " " + qs2.core.language.sqlLanguage.getRes("Classification");

                        //if (!DesignMode && qs2.core.ENV.adminSecure && qs2.core.vb.actUsr.rUsr.isAdmin)
                        if (!DesignMode && qs2.core.vb.actUsr.IsAdminSecureOrSupervisor())
                        {
                            ownMultiControl1.ContextMenuStrip = contextMenuStripSelList;
                            criteriasToolStripMenuItem.Visible = true;
                            ressourcenToolStripMenuItem.Visible = true;
                            infoClassificationToolStripMenuItem.Visible = true;
                            if (ownMultiControl1._controlType == core.Enums.eControlType.ComboBox)
                            {
                                selListToolStripMenuItem.Visible = true;
                            }
                            else
                            {
                                selListToolStripMenuItem.Visible = false;
                            }

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

                    if (ownMultiControl1._controlType == core.Enums.eControlType.Picture)
                    {
                        ownMCRelationship.setPictureRessource(ownMultiControl1, ownMultiControl1._FldShort, ownMultiControl1.ownMCCriteria1.IDParticipant, ownMultiControl1.ownMCCriteria1.Application);
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
                    if (!String.IsNullOrWhiteSpace(txtTip))
                    {
                        txtToolTip = txtTip;
                        if (qs2.core.ENV.ExtendedUI && !String.IsNullOrWhiteSpace(txtHelp))
                        {
                            txtToolTip += "\n" + txtHelp;
                        }
                    }
                    else
                    {
                        if (qs2.core.ENV.ExtendedUI && !String.IsNullOrWhiteSpace(txtHelp))
                        {
                            txtToolTip = txtHelp;
                        }
                    }

                    if (!String.IsNullOrWhiteSpace(txtToolTip))
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

                //if (this.TextTranslated.Trim() == "")
                //{
                //    string xy = "";
                //}

                ownMultiControl1._txtIsLoaded = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.doText", "", false, true,
                                                                ownMultiControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }

        public void setToolTipFormatForDbControl(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (this.toolTipIsInitialized)
                {
                    return;
                }

                if (ownControl1.ownMCUI1.controlIsDbDataControl(ownControl1))
                {
                    if (ownControl1.ownMCUI1.IsVisible_Criteriaxy && ownControl1.ownMCCriteria1.rCriteria != null)
                    {
                        if (ownControl1._controlType == core.Enums.eControlType.Integer ||
                            ownControl1._controlType == core.Enums.eControlType.Numeric)
                        {
                            //if (ownControl1._controlType == core.Enums.eControlType.Integer)
                            //{
                            //    string xy = "";
                            //}

                            string infoToolTip = qs2.core.language.sqlLanguage.getRes("MinValue") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MinValue.ToString() + qs2.core.generic.lineBreak +
                                            qs2.core.language.sqlLanguage.getRes("MaxValue") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaxValue.ToString() + qs2.core.generic.lineBreak;

                            if (qs2.core.ENV.adminSecure)
                            {
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("FormatString") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.FormatString + qs2.core.generic.lineBreak +
                                               qs2.core.language.sqlLanguage.getRes("MaskInput") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaskInput + qs2.core.generic.lineBreak +
                                               qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.Numeric.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.Numeric, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                    ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }

                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.DateTime)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = qs2.core.language.sqlLanguage.getRes("FormatString") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.FormatString + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("MaskInput") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaskInput + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.DateTime.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.DateTime, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip,
                                                                ownControl1, false, ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Date)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = qs2.core.language.sqlLanguage.getRes("FormatString") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.FormatString + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("MaskInput") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaskInput + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.Date.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.Date, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                                                ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Time)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = qs2.core.language.sqlLanguage.getRes("FormatString") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.FormatString + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("MaskInput") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaskInput + qs2.core.generic.lineBreak +
                                             qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.Time.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.Time, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                                                ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.Textfield)
                        {
                            string infoToolTip = qs2.core.language.sqlLanguage.getRes("MinLength") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MinValue.ToString() + qs2.core.generic.lineBreak +
                                                 qs2.core.language.sqlLanguage.getRes("MaxLength") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaxValue.ToString() + qs2.core.generic.lineBreak;

                            if (qs2.core.ENV.adminSecure)
                            {
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.Textfield.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.Textfield, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                    ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.TextfieldMulti)
                        {
                            string infoToolTip = qs2.core.language.sqlLanguage.getRes("MinLength") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MinValue.ToString() + qs2.core.generic.lineBreak +
                                                    qs2.core.language.sqlLanguage.getRes("MaxLength") + ": " + ownControl1.ownMCFormat1.calculatedFormat1.MaxValue.ToString() + qs2.core.generic.lineBreak;

                            if (qs2.core.ENV.adminSecure)
                            {
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + core.Enums.eControlType.TextfieldMulti.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);
                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.TextfieldMulti, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false, ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.CheckBox)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = "";
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + ownControl1._controlType.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.CheckBox, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                                                ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.ThreeStateCheckBox)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = "";
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + ownControl1._controlType.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.ThreeStateCheckBox, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                                                ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                        else if (ownControl1._controlType == core.Enums.eControlType.ComboBox)
                        {
                            if (qs2.core.ENV.adminSecure)
                            {
                                string infoToolTip = "";
                                infoToolTip += qs2.core.language.sqlLanguage.getRes("ControlType") + ": " + ownControl1._controlType.ToString();
                                infoToolTip += qs2.core.generic.lineBreak + ownControl1.ownMCTxt1.getToolTippDefaultValueDB(ownControl1);

                                ownControl1.ownMCInfo1.doToolTipxy(ownControl1.ComboBox, qs2.core.language.sqlLanguage.getRes("Info"), infoToolTip, ownControl1, false,
                                                                ownControl1.ownMCCriteria1.Application, ownControl1.OwnFieldForALLProducts);
                            }
                        }
                    }
                }

                this.toolTipIsInitialized = true;
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.setToolTipFormat", ownControl1._FldShort, false, true,
                                                                    ownControl1.ownMCCriteria1.Application,
                                                                    qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
            }
        }
        public string getToolTippDefaultValueDB(qs2.design.auto.multiControl.ownMultiControl ownControl1)
        {
            try
            {
                if (ownControl1.ownMCCriteria1.defaultDBValue != null)
                {
                    object valueObj = ownControl1.ownMCCriteria1.defaultDBValue.valueObj;
                    if (ownControl1.ownMCCriteria1.defaultDBValue.valueObj.GetType().Equals(typeof(System.DBNull)))
                    {
                        valueObj = "[null]";
                    }
                    return qs2.core.language.sqlLanguage.getRes("DefaultDBValue") + ": " + valueObj.ToString() + " ['" + ownControl1.ownMCCriteria1.defaultDBValue.valueStr + "']";
                }
                return "";
            }
            catch (Exception ex)
            {
                qs2.core.Protocol.doExcept(ex.ToString(), "ownMCTxt.getToolTippDefaultValueDB", ownControl1._FldShort, false, true,
                                                                ownControl1.ownMCCriteria1.Application,
                                                                qs2.core.Protocol.alwaysShowExceptionMulticontrol, qs2.core.Protocol.eTypeError.Error);
                return "";
            }
        }


        public string SelectedText
        {
            get
            {
                return this._SelectedText;
            }
            set
            {
                this._SelectedText = value;
            }
        }

        public void getSelectedText(qs2.design.auto.multiControl.ownMultiControl ownMultiControl1, bool DesignMode)
        {
            try
            {
                if (DesignMode)
                    return;

                //if (qs2.design.auto.multiControl.ownMCInfo.stopWhenFldShort(ownMultiControl1._FldShort, "StayComplete", false))
                //{
                //    string xy = "";
                //}

                string NoSpecification = qs2.core.language.sqlLanguage.getRes("NoSpecification").Trim();

                //ownMCTxt.counterCallsFctSelectText += 1;

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
                //Infragistics.Win.DefaultableBoolean InfragBold = new Infragistics.Win.DefaultableBoolean();

                //System.Drawing.Color ForeColor = new System.Drawing.Color();
                //bool UseAppStyling = false;
                if (bOn)
                {
                    InfragOnOff = Infragistics.Win.DefaultableBoolean.True;
                    //ForeColor = System.Drawing.Color.Black;   //System.Drawing.Color.RoyalBlue;  
                    //UseAppStyling = false;
                    //InfragBold = Infragistics.Win.DefaultableBoolean.False;
                }
                else
                {
                    InfragOnOff = Infragistics.Win.DefaultableBoolean.False;
                    //ForeColor = System.Drawing.Color.Black;
                    //UseAppStyling = false;
                    //InfragBold = Infragistics.Win.DefaultableBoolean.False;
                }

                //ownMultiControl1.infragLabelLeft.UseAppStyling = UseAppStyling;
                //ownMultiControl1.infragLabelRight.UseAppStyling = UseAppStyling;
                //ownMultiControl1.infragLabelTop.UseAppStyling = UseAppStyling;

                //ownMultiControl1.infragLabelLeft.Appearance.ForeColor = ForeColor;
                //ownMultiControl1.infragLabelRight.Appearance.ForeColor = ForeColor;
                //ownMultiControl1.infragLabelTop.Appearance.ForeColor = ForeColor;

                ownMultiControl1.infragLabelLeft.Appearance.FontData.Underline = InfragOnOff;
                ownMultiControl1.infragLabelRight.Appearance.FontData.Underline = InfragOnOff;

                //ownMultiControl1.infragLabelLeft.Appearance.FontData.Bold = InfragBold;
                //ownMultiControl1.infragLabelRight.Appearance.FontData.Bold = InfragBold;
                //ownMultiControl1.infragLabelTop.Appearance.FontData.Bold = InfragBold;

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
