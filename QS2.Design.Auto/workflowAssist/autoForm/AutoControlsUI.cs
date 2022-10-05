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
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Panel))
                    {
                        System.Windows.Forms.Panel contAct = (System.Windows.Forms.Panel)cont;
                    }
                    else if (cont.GetType() == typeof(UltraPanel))
                    {
                        UltraPanel contAct = (UltraPanel)cont;
                    }
                    else if (cont.GetType() == typeof(UltraGroupBox))
                    {
                        UltraGroupBox contAct = (UltraGroupBox)cont;
                    }
                    else if (cont.GetType() == typeof(UltraTabControl))
                    {
                        UltraTabControl contAct = (UltraTabControl)cont;
                    }
                    else if (cont.GetType() == typeof(UltraTabPageControl))
                    {
                        UltraTabPageControl contAct = (UltraTabPageControl)cont;
                    }
                    else if (cont.GetType() == typeof(UltraTabSharedControlsPage))
                    {
                        UltraTabSharedControlsPage contAct = (UltraTabSharedControlsPage)cont;
                    }
                    else if (cont.GetType() == typeof(UltraGrid))
                    {
                        UltraGrid contAct = (UltraGrid)cont;
                    }
                    else if (cont.GetType() == typeof(UltraGridBagLayoutPanel))
                    {
                        UltraGridBagLayoutPanel contAct = (UltraGridBagLayoutPanel)cont;
                    }
                    else if (cont.GetType() == typeof(UltraDropDown))
                    {
                        UltraDropDown contAct = (UltraDropDown)cont;
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.dropDownApplications))
                    {
                        qs2.sitemap.dropDownApplications contAct = (qs2.sitemap.dropDownApplications)cont;
                    }
                    else if (cont.GetType() == typeof(UltraDropDownBase))
                    {
                        UltraDropDownBase contAct = (UltraDropDownBase)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.MenuStrip))
                    {
                        System.Windows.Forms.MenuStrip contAct = (System.Windows.Forms.MenuStrip)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.ToolStrip))
                    {
                        System.Windows.Forms.ToolStrip contAct = (System.Windows.Forms.ToolStrip)cont;
                    }
                    else if (cont.GetType() == typeof(UltraStatusBar))
                    {
                        UltraStatusBar contAct = (UltraStatusBar)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Button))
                    {
                        System.Windows.Forms.Button contAct = (System.Windows.Forms.Button)cont;
                    }
                    else if (cont.GetType() == typeof(UltraButton))
                    {
                        UltraButton contAct = (UltraButton)cont;
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.ownControls.inherit_Infrag.InfragButton))
                    {
                        qs2.sitemap.ownControls.inherit_Infrag.InfragButton contAct = (qs2.sitemap.ownControls.inherit_Infrag.InfragButton)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.Label))
                    {
                        System.Windows.Forms.Label contAct = (System.Windows.Forms.Label)cont;
                    }
                    else if (cont.GetType() == typeof(UltraFormattedLinkLabel))
                    {
                        UltraFormattedLinkLabel contAct = (UltraFormattedLinkLabel)cont;
                    }
                    else if (cont.GetType() == typeof(UltraLabel))
                    {
                        UltraLabel contAct = (UltraLabel)cont;
                    }
                    else if (cont.GetType() == typeof(UltraTextEditor))
                    {
                        UltraTextEditor contAct = (UltraTextEditor)cont;
                    }
                    else if (cont.GetType() == typeof(UltraFormattedTextEditor))
                    {
                        UltraFormattedTextEditor contAct = (UltraFormattedTextEditor)cont;
                    }
                    else if (cont.GetType() == typeof(RichTextBox))
                    {
                        RichTextBox contAct = (RichTextBox)cont;
                    }
                    else if (cont.GetType() == typeof(UltraNumericEditor))
                    {
                        UltraNumericEditor contAct = (UltraNumericEditor)cont;
                    }
                    else if (cont.GetType() == typeof(UltraDateTimeEditor))
                    {
                        UltraDateTimeEditor contAct = (UltraDateTimeEditor)cont;
                    }
                    else if (cont.GetType() == typeof(UltraComboEditor))
                    {
                        UltraComboEditor contAct = (UltraComboEditor)cont;
                    }
                    else if (cont.GetType() == typeof(UltraCombo))
                    {
                        UltraCombo contAct = (UltraCombo)cont;
                    }
                    else if (cont.GetType() == typeof(UltraDropDownButton))
                    {
                        UltraDropDownButton contAct = (UltraDropDownButton)cont;
                    }
                    else if (cont.GetType() == typeof(qs2.sitemap.comboApplication))
                    {
                        qs2.sitemap.comboApplication contAct = (qs2.sitemap.comboApplication)cont;
                    }
                    else if (cont.GetType() == typeof(UltraOptionSet))
                    {
                        UltraOptionSet contAct = (UltraOptionSet)cont;
                    }
                    else if (cont.GetType() == typeof(UltraCheckEditor))
                    {
                        UltraCheckEditor contAct = (UltraCheckEditor)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        System.Windows.Forms.CheckBox contAct = (System.Windows.Forms.CheckBox)cont;
                    }
                    else if (cont.GetType() == typeof(System.Windows.Forms.PictureBox))
                    {
                        System.Windows.Forms.PictureBox contAct = (System.Windows.Forms.PictureBox)cont;
                    }
                    else if (cont.GetType() == typeof(UltraProgressBar))
                    {
                        UltraProgressBar contAct = (UltraProgressBar)cont;
                    }
                    else if (cont.GetType() == typeof(TXTextControl.TextControl))
                    {
                        TXTextControl.TextControl contAct = (TXTextControl.TextControl)cont;
                    }
                    else if (cont.GetType() == typeof(UltraSplitter))
                    {
                        UltraSplitter contAct = (UltraSplitter)cont;
                    }
                    else if (cont.GetType() == typeof(UltraToolbarsDockArea))
                    {
                        UltraToolbarsDockArea contAct = (UltraToolbarsDockArea)cont;
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
