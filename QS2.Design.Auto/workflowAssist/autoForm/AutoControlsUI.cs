using System;
using System.Collections.Generic;

using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.FormattedLinkLabel;
using System.Windows.Forms;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinStatusBar;
using Infragistics.Win.UltraWinProgressBar;
using qs2.core;

namespace qs2.design.auto.workflowAssist.autoForm
{


    public class AutoControlsUI
    {
        public bool IsInitialized = false;

        public System.Collections.Generic.List<cInfoControl> lstControls = new List<cInfoControl>();
        public class cInfoControl
        {
            public string ControlName = "";
            public string ControlType = "";
            public Guid ID = System.Guid.NewGuid();
        }

        public static string ControlsNoDef = "";
        public ColorSchemas ColorSchemas1 = new ColorSchemas();


        




        public void run2(Control controlFirst, Object components)
        {
            try
            {
                if (this.IsInitialized)
                {
                    return;
                }

                int level = 0;
                this.runControls_rek(controlFirst, ref level);
                this.runComponents_rek(controlFirst, ref components, ref lstControls);

                this.IsInitialized = true;
            }
            catch (Exception ex)
            {
                throw new Exception("AutoControlsUI:run: " + ex.ToString());
            }
        }   

        public void runControls_rek(Control controlParent, ref int level)
        {
            try
            {
                level += 1;

                foreach (Control cont in controlParent.Controls)
                {
                    bool bControlDefFound = true;

                    if (cont.GetType() == typeof(System.Windows.Forms.Control).GetType())
                    {
                        System.Windows.Forms.Control contAct = (System.Windows.Forms.Control)cont;
                        this.ColorSchemas1.setAppearanceControl(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Panel))
                    {
                        System.Windows.Forms.Panel contAct = (System.Windows.Forms.Panel)cont;
                        this.ColorSchemas1.setAppearancePanelWin(contAct, ColorSchemas.eTypeUIPanelWin.Default, false);
                    }
                    else if (cont.GetType() == typeof(UltraPanel))
                    {
                        UltraPanel contAct = (UltraPanel)cont;
                        this.ColorSchemas1.setAppearancePanel(contAct, ColorSchemas.eTypeUIPanel.Default, false);
                    }
                    else if (cont.GetType() == typeof(UltraGroupBox))
                    {
                        UltraGroupBox contAct = (UltraGroupBox)cont;
                        this.ColorSchemas1.setAppearanceGroupBox(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraTabControl))
                    {
                        UltraTabControl contAct = (UltraTabControl)cont;
                        this.ColorSchemas1.setAppearanceTab(contAct, ColorSchemas.eTypeUIStayTab.Default, false);
                        //foreach (UltraTab tabPage in contAct.Tabs)
                        //{
                        //    this.runControls_rek(tabPage.TabControl, ref level);
                        //}
                    }
                    else if (cont.GetType() == typeof(UltraTabPageControl))
                    {
                        UltraTabPageControl contAct = (UltraTabPageControl)cont;
                        this.ColorSchemas1.setAppearanceTabPageControl(contAct, false);
                        //this.runControls_rek(contAct, ref level);
                    }
                    else if (cont.GetType() == typeof(UltraTabSharedControlsPage))
                    {
                        UltraTabSharedControlsPage contAct = (UltraTabSharedControlsPage)cont;
                        this.ColorSchemas1.setAppearanceTabSharedControlsPage(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraGrid))
                    {
                        UltraGrid contAct = (UltraGrid)cont;
                        this.ColorSchemas1.setAppearanceGrid(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraGridBagLayoutPanel))
                    {
                        UltraGridBagLayoutPanel contAct = (UltraGridBagLayoutPanel)cont;
                        this.ColorSchemas1.setAppearanceGridBag(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraDropDown))
                    {
                        UltraDropDown contAct = (UltraDropDown)cont;
                        this.ColorSchemas1.setAppearanceDropDown(contAct, false);
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.dropDownApplications))
                    {
                        qs2.sitemap.dropDownApplications contAct = (qs2.sitemap.dropDownApplications)cont;
                        this.ColorSchemas1.setAppearanceDropDownApplication(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraDropDownBase))
                    {
                        UltraDropDownBase contAct = (UltraDropDownBase)cont;
                        this.ColorSchemas1.setAppearanceDropDownBase(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    {
                        System.Windows.Forms.MenuStrip contAct = (System.Windows.Forms.MenuStrip)cont;
                        this.ColorSchemas1.setAppearanceMenüStrip(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.ToolStrip))
                    {
                        System.Windows.Forms.ToolStrip contAct = (System.Windows.Forms.ToolStrip)cont;
                        this.ColorSchemas1.setAppearanceToolStrip(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraStatusBar))
                    {
                        UltraStatusBar contAct = (UltraStatusBar)cont;
                        this.ColorSchemas1.setAppearanceStatusBar(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        System.Windows.Forms.Button contAct = (System.Windows.Forms.Button)cont;
                        this.ColorSchemas1.setAppearanceButtonWin(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraButton))
                    {
                        UltraButton contAct = (UltraButton)cont;
                        this.ColorSchemas1.setAppearanceButton(contAct, ColorSchemas.eTypeButton.Default, false);
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.ownControls.inherit_Infrag.InfragButton))
                    {
                        qs2.sitemap.ownControls.inherit_Infrag.InfragButton contAct = (qs2.sitemap.ownControls.inherit_Infrag.InfragButton)cont;
                        this.ColorSchemas1.setAppearanceButton(contAct, ColorSchemas.eTypeButton.Default, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Label))
                    {
                        System.Windows.Forms.Label contAct = (System.Windows.Forms.Label)cont;
                        this.ColorSchemas1.setAppearanceLabelWin(contAct, ColorSchemas.eTypeLabel.Default);
                    }
                    else if (cont.GetType() == typeof(UltraFormattedLinkLabel))
                    {
                        UltraFormattedLinkLabel contAct = (UltraFormattedLinkLabel)cont;
                        this.ColorSchemas1.setAppearanceFormattedLinkLabel(contAct, ColorSchemas.eTypeLabel.Default);
                    }
                    else if (cont.GetType() == typeof(UltraLabel))
                    {
                        UltraLabel contAct = (UltraLabel)cont;
                        this.ColorSchemas1.setAppearanceLabel(contAct, ColorSchemas.eTypeLabel.Default);
                    }
                    else if (cont.GetType() == typeof(UltraTextEditor))
                    {
                        UltraTextEditor contAct = (UltraTextEditor)cont;
                        this.ColorSchemas1.setAppearanceTextfield(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraFormattedTextEditor))
                    {
                        UltraFormattedTextEditor contAct = (UltraFormattedTextEditor)cont;
                        this.ColorSchemas1.setAppearanceMultiTextfield(contAct, false);
                    }
                    else if (cont.GetType() == typeof(RichTextBox))
                    {
                        RichTextBox contAct = (RichTextBox)cont;
                        this.ColorSchemas1.setAppearanceRichTextBox(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraNumericEditor))
                    {
                        UltraNumericEditor contAct = (UltraNumericEditor)cont;
                        this.ColorSchemas1.setAppearanceNumeric(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraDateTimeEditor))
                    {
                        UltraDateTimeEditor contAct = (UltraDateTimeEditor)cont;
                        this.ColorSchemas1.setAppearanceDateTime(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraComboEditor))
                    {
                        UltraComboEditor contAct = (UltraComboEditor)cont;
                        this.ColorSchemas1.setAppearanceComboBox(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraCombo))
                    {
                        UltraCombo contAct = (UltraCombo)cont;
                        this.ColorSchemas1.setAppearanceCombo(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraDropDownButton))
                    {
                        UltraDropDownButton contAct = (UltraDropDownButton)cont;
                        this.ColorSchemas1.setAppearanceComboBoxAsDropDown(contAct, false);
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.comboApplication))
                    {
                        qs2.sitemap.comboApplication contAct = (qs2.sitemap.comboApplication)cont;
                        this.ColorSchemas1.setAppearanceComboApplication(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraOptionSet))
                    {
                        UltraOptionSet contAct = (UltraOptionSet)cont;
                        this.ColorSchemas1.setAppearanceUltraOptionSet(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraCheckEditor))
                    {
                        UltraCheckEditor contAct = (UltraCheckEditor)cont;
                        this.ColorSchemas1.setAppearanceCheckBox(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        System.Windows.Forms.CheckBox contAct = (System.Windows.Forms.CheckBox)cont;
                        this.ColorSchemas1.setAppearanceCheckBoxWin(contAct, false);
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.PictureBox))
                    {
                        System.Windows.Forms.PictureBox contAct = (System.Windows.Forms.PictureBox)cont;
                        this.ColorSchemas1.setAppearancePictureWin(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraProgressBar))
                    {
                        UltraProgressBar contAct = (UltraProgressBar)cont;
                        this.ColorSchemas1.setAppearanceProgressBar(contAct, false);
                    }
                    else if (cont.GetType() == typeof(TXTextControl.TextControl))
                    {
                        TXTextControl.TextControl contAct = (TXTextControl.TextControl)cont;
                        this.ColorSchemas1.setAppearanceTextControl(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraSplitter))
                    {
                        UltraSplitter contAct = (UltraSplitter)cont;
                        this.ColorSchemas1.setAppearanceSplitter(contAct, false);
                    }
                    else if (cont.GetType() == typeof(UltraToolbarsDockArea))
                    {
                        UltraToolbarsDockArea contAct = (UltraToolbarsDockArea)cont;
                        this.ColorSchemas1.setAppearanceToolbarsDockArea(contAct, false);
                    }
                    //else
                    //{
                    //    bControlDefFound = false;
                    //    this.addControlToListNoDef(cont);
                    //}

                    //if (bControlDefFound)
                    //{
                    //    this.addControlToList(cont, ref this.lstControls);
                    //}
                    


                    this.runControls_rek(cont, ref level);
                    level--;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("AutoControlsUI:runControls_rek: " + ex.ToString());
            }
        }
        public void runComponents_rek(Control controlParent, ref Object components, ref System.Collections.Generic.List<cInfoControl> lstControls)
        {
            try
            {
                if (components != null)
                {
                    System.ComponentModel.Container Container = (System.ComponentModel.Container)components;

                    foreach (object componentFound in Container.Components)
                    {
                        bool bControlDefFound = true;

                        if (componentFound.GetType() == typeof(UltraToolbarsManager))
                        {
                            UltraToolbarsManager contAct = (UltraToolbarsManager)componentFound;
                            this.ColorSchemas1.setAppearanceUltraToolbarsManager(contAct, false);
                            bool bControlFound = false;
                        }
                        else if(componentFound.GetType() == typeof(ContextMenuStrip))
                        {
                            bool bControlFound = false;
                        }
                        else if (componentFound.GetType() == typeof(MenuStrip))
                        {
                            bool bControlFound = false;
                        }
                        else if (componentFound.GetType() == typeof(Panel))
                        {
                            bool bControlFound = false;
                        }
                        else
                        {
                            bool bControlNotFound = false;
                            //this.addControlToList(componentFound, ref this.lstControlsNoDef);
                        }

                        if (bControlDefFound)
                        {
                            //this.addControlToList(componentFound, ref this.lstControls);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("AutoControlsUI:runComponents_rek: " + ex.ToString());
            }
        }

        

        public void addControlToList(Control control, ref System.Collections.Generic.List<cInfoControl> lstControlToAdd)
        {
            try
            {
                cInfoControl newInfoControl = new cInfoControl();
                newInfoControl.ControlName = control.Name;
                newInfoControl.ControlType = control.GetType().ToString();
                if (control.Parent != null)
                {
                    newInfoControl.ControlName = control.Name;
                }
                this.lstControls.Add(newInfoControl);

            }
            catch (Exception ex)
            {
                throw new Exception("AutoControlsUI:addControlToList: " + ex.ToString());
            }
        }
        public void addControlToListNoDef(Control control)
        {
            try
            {
                AutoControlsUI.ControlsNoDef += control.GetType().ToString() + "    -    " + control.Name.Trim() + "\r\n";

            }
            catch (Exception ex)
            {
                throw new Exception("AutoControlsUI:addControlToListNoDef: " + ex.ToString());
            }
        }
    }
    
}
