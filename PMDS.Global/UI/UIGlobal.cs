using System;
using System.Collections.Generic;
using System.Text;

using Infragistics.Win.UltraWinEditors;
using System.Drawing;
using Infragistics.Win.Misc;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid ;
using PMDS.BusinessLogic;

namespace PMDS.Global
{
   public  class UIGlobal
    {

       public static int mainWindowTop = 0;
       public static int mainWindowLeft = 0;
       public static int mainWindowWidth = 0;

       public static frmInfo infoStart = new frmInfo();


       public class eSelectedNodes
       {
           public Nullable<Guid> IDKlient = null;
           public Nullable<Guid> IDAufenthalt = null;
           public string Txt = "";
           public bool bDone = false;
       }


        public enum ButtonPlacement
        {
               normal,
               grid
        }







        public void removeDoubledPatients(System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelected)
        {
            try
            {
                System.Collections.Generic.List<PMDS.Global.UIGlobal.eSelectedNodes> lstPatienteSelectedDistinct = new List<UIGlobal.eSelectedNodes>();
                foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodesOrig in lstPatienteSelected)
                {
                    bool PatientExists = false;
                    foreach (PMDS.Global.UIGlobal.eSelectedNodes SelectedNodesDistinct in lstPatienteSelectedDistinct)
                    {
                        if (SelectedNodesDistinct.IDKlient.Equals(SelectedNodesOrig.IDKlient))
                        {
                            PatientExists = true;
                        }
                    }
                    if (!PatientExists)
                    {
                        lstPatienteSelectedDistinct.Add(SelectedNodesOrig);
                    }
                }

                lstPatienteSelected = lstPatienteSelectedDistinct;

            }
            catch (Exception ex)
            {
                throw new Exception("UIGlobal.removeDoubledPatients: " + ex.ToString());
            }
        }

        public static void NewLogIn(string AppType, bool CloseOldInstanz)
        {
            System.Windows.Forms.DialogResult res = System.Windows.Forms.DialogResult.No;
            if (CloseOldInstanz)
            {
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie sich wirklich abmelden und eine neue Sitzung von PMDS starten?", "Abmelden", System.Windows.Forms.MessageBoxButtons.YesNo);
            }
            else
            {
                res = System.Windows.Forms.DialogResult.Yes;
            }

            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

                string sSimpleInstall = "";
                if (ENV.SimpleInstall.Trim() != "")
                {
                    sSimpleInstall = " ?SimpleInstall=" + ENV.SimpleInstall.Trim();
                }
                startInfo.Arguments = "?typ=" + AppType.Trim() + " ?ConfigPath=" + ENV.OrigConfigDir + " ?ConfigFile=" + ENV.OrigConfigFile + sSimpleInstall;

                //startInfo.UseShellExecute = true;
                //startInfo.Verb = "Print";
                //startInfo.CreateNoWindow = false;
                //startInfo.WindowStyle  = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = ENV.path_bin + "\\PMDS.Main.exe";

                proc.StartInfo = startInfo;

                PMDS.DB.PMDSBusiness PMDSBusiness1 = new DB.PMDSBusiness();
                PMDSBusiness1.checkEndAnonymLogIn();

                proc.Start();

                if (CloseOldInstanz)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                }
            }
        }


        public static void setUIButton(UltraButton butt, bool bAktiv)
        {
            butt.Appearance.FontData.Bold = DefaultableBoolean.False;
            butt.UseOsThemes = DefaultableBoolean.False;
            butt.UseFlatMode = DefaultableBoolean.True;
            butt.ShowFocusRect = false;
            butt.UseHotTracking = DefaultableBoolean.True;
            butt.HotTrackAppearance.BackColor = ENVCOLOR.hoverBackCol;
            butt.HotTrackAppearance.BorderColor = ENVCOLOR.hoverFrameCol;

            if (bAktiv)
            {
                butt.Appearance.BackColor = ENVCOLOR.activeBackCol;
                butt.Appearance.ForeColor = ENVCOLOR.activeForeCol;
                butt.Appearance.BorderColor = ENVCOLOR.activeFrameCol;
            }
            else
            {
                butt.Appearance.BackColor = ENVCOLOR.inactiveBackCol;
                butt.Appearance.ForeColor = ENVCOLOR.inactiveForeCol;
                butt.Appearance.BorderColor = ENVCOLOR.inactiveFrameCol;
            }
        }

        public static void setUIButton(UltraDropDownButton butt, bool bAktiv)
        {
            butt.Appearance.FontData.Bold = DefaultableBoolean.False;
            butt.UseOsThemes = DefaultableBoolean.False;
            butt.UseFlatMode = DefaultableBoolean.True;
            butt.ShowFocusRect = false;

            butt.HotTrackAppearance.BackColor = ENVCOLOR.hoverBackCol;
            butt.HotTrackAppearance.BorderColor = ENVCOLOR.hoverFrameCol;

            if (bAktiv)
            {
                butt.Appearance.BackColor = ENVCOLOR.activeBackCol;
                butt.Appearance.ForeColor = ENVCOLOR.activeForeCol;
                butt.Appearance.BorderColor = ENVCOLOR.activeFrameCol;
            }
            else
            {
                butt.Appearance.BackColor = ENVCOLOR.inactiveBackCol;
                butt.Appearance.ForeColor = ENVCOLOR.inactiveForeCol;
                butt.Appearance.BorderColor = ENVCOLOR.inactiveFrameCol;
            }
        }

        //public static void setAktivXX(UltraButton butt, int ineu, Color foreCol, Color bordCol, Color backCol)
        //{
        //    butt.Appearance.FontData.Bold = DefaultableBoolean.False;
        //    butt.UseOsThemes = DefaultableBoolean.False;
        //    butt.Appearance.BackColor = backCol; 
        //    butt.Appearance.ForeColor = foreCol;
        //    butt.Appearance.BorderColor = bordCol;
        //    butt.PressedAppearance.BackColor = System.Drawing.Color.Gainsboro;
        //    butt.PressedAppearance.ForeColor = foreCol;
        //    butt.HotTrackAppearance.BackColor = ENVCOLOR.hoverBackCol;
        //    butt.UseFlatMode = DefaultableBoolean.True;
        //    butt.ShowFocusRect = false;
        //}

        //public static void setAktivDisableXX(UltraButton butt, int i, Color foreCol, Color hotTrackBackCol, Color bordColor, Color backCol, UIElementButtonStyle styleButt )
        //{
        //    butt.Appearance.ForeColor = foreCol;
        //    butt.Appearance.BackColor = backCol;
        //    butt.Appearance.BorderColor = bordColor;
        //    butt.HotTrackAppearance.BackColor = hotTrackBackCol;
        //    butt.HotTrackAppearance.BorderColor = ENVCOLOR.hoverFrameCol;
        //    butt.ButtonStyle = styleButt; 
        //    butt.UseOsThemes = DefaultableBoolean.False;
        //    butt.UseHotTracking = DefaultableBoolean.True;
        //    butt.Appearance.FontData.Bold = DefaultableBoolean.False;
        //    butt.UseFlatMode = DefaultableBoolean.True;
        //    butt.ShowFocusRect = false;            
        //}

        //public static void setAktivDisableDropDown(UltraDropDownButton butt, int i, Color foreCol, Color hotTrackBackCol, Color bordColor, System.Drawing.Color backCol, UIElementButtonStyle styleButt)
        //{
        //    butt.Appearance.ForeColor = foreCol;
        //    butt.Appearance.BackColor = backCol;
        //    butt.Appearance.BorderColor = bordColor;
        //    butt.HotTrackAppearance.BackColor = hotTrackBackCol;
        //    butt.HotTrackAppearance.BorderColor = System.Drawing.Color.Transparent;
        //    butt.ButtonStyle = styleButt;
        //    butt.UseOsThemes = DefaultableBoolean.False;
        //    butt.UseHotTracking = DefaultableBoolean.True;
        //    butt.Appearance.FontData.Bold = DefaultableBoolean.False;
        //    butt.UseFlatMode = DefaultableBoolean.True;
        //    butt.ShowFocusRect = false;
        //}

        //public static void setStyleButton(Infragistics.Win.Misc.UltraButton butt)
        //{
        //    PMDS.Global.UIGlobal.setAktivDisable(butt, -1, ENVCOLOR.inactiveForeCol, ENVCOLOR.hoverBackCol, ENVCOLOR.inactiveFrameCol, ENVCOLOR.inactiveBackCol, UIElementButtonStyle.Button);                // Wunde
        //}

        //public static void setStyleButtonDropDown(Infragistics.Win.Misc.UltraDropDownButton butt)
        //{
        //    PMDS.Global.UIGlobal.setAktivDisableDropDown(butt, -1, ENVCOLOR.inactiveForeCol, ENVCOLOR.hoverBackCol, ENVCOLOR.inactiveFrameCol, ENVCOLOR.inactiveBackCol, UIElementButtonStyle.Button);                // Wunde
        //}


        //public void setUISelektAlleKeine(bool alle, Infragistics.Win.UltraWinGrid.BandsCollection coll, UltraGrid grid)
        //{
        //    foreach (Infragistics.Win.UltraWinGrid.UltraGridBand b in coll)
        //    {
        //        foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grid.Rows)
        //        {
        //            if (!r.IsGroupByRow && !r.IsFilteredOut)
        //            {
        //                r.Selected = alle;
        //                r.Activated = alle;
        //            }
        //        }
        //    }
        //}

        public void setButtonStyleStandard(UltraButton butt, PMDS.Global.UIGlobal.ButtonPlacement TYPEPlacement)
        {
            if (TYPEPlacement == ButtonPlacement.grid)
            {
                butt.Appearance.BackColor = System.Drawing.Color.White;
            }
        }

        public static PMDS.Global.retFkt openInputForm(string titWindow, string descrEingabe1, string defaultValue1, bool pflicht1,
                      string descrEingabe2, string defaultValue2, bool pflicht2, System.Windows.Forms.Form frmParent)
        {
            PMDS.GUI.BaseControls.frmInputText frmInput = new PMDS.GUI.BaseControls.frmInputText();
            frmInput.setData(titWindow, descrEingabe1, defaultValue1, pflicht1,
                                descrEingabe2, defaultValue2, pflicht2);

            if (frmParent == null) frmInput.ShowDialog();
            else frmInput.ShowDialog(frmParent);

            if (frmInput._apport)
            {
                PMDS.Global.retFkt ret = new PMDS.Global.retFkt();
                return ret;
            }
            else
            {
                return frmInput.retValues;
            }
        }

        public static void  setFilterGrid( UltraGrid grd  )
        {
            grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow;
            grd.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden;
            grd.DisplayLayout.Override.FilterRowPrompt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Hier Klicken um Daten zu filtern");
            grd.DisplayLayout.Override.FilterRowAppearance.ForeColor = Color.RoyalBlue;
            grd.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.White;
            grd.DisplayLayout.Override.FilterRowAppearance.FontData.Bold = DefaultableBoolean.False ;
            grd.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo;
            grd.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow;
            //grd.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.LightSteelBlue;
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted;
            grd.DisplayLayout.Override.MergedCellAppearance.BackColor = Color.Beige;
            grd.DisplayLayout.Override.FilterRowPromptAppearance.FontData.SizeInPoints = 9;
            grd.DisplayLayout.Override.FilterRowPromptAppearance.ForeColor = Color.DarkGray  ;
        }

        public bool evClickOK(ref object sender, ref EventArgs e, UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evDoubleClickOK(ref object sender, ref EventArgs e, UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }


        public bool evDoubleClickOKMonth(ref object sender, ref EventArgs e, ref Infragistics.Win.UltraWinSchedule.UltraMonthViewSingle calend)
        {
            if (calend.UIElement.LastElementEntered != null)

                if (calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evDoubleClickOKWeek(ref object sender, ref EventArgs e, ref Infragistics.Win.UltraWinSchedule.UltraWeekView calend)
        {
            if (calend.UIElement.LastElementEntered != null)

                if (calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evDoubleClickOKDay(ref object sender, ref EventArgs e, ref Infragistics.Win.UltraWinSchedule.UltraDayView calend)
        {
            if (calend.UIElement.LastElementEntered != null)

                if (calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     calend.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }

        public bool evClickOKTree(ref object sender, ref EventArgs e, ref Infragistics.Win.UltraWinTree.UltraTree tree)
        {
            if (tree.UIElement.LastElementEntered != null)

                if (tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))
                    //tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement) &&
                    return true;

            return false;
        }

        public bool evClickOKListView(ref object sender, ref EventArgs e, ref Infragistics.Win.UltraWinListView.UltraListView ListView)
        {
            if (ListView.UIElement.LastElementEntered != null)

                if (ListView.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     ListView.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     ListView.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))
                    //tree.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinTree.NodeTextUIElement) &&
                    return true;

            return false;
        }

        public string ParameterHelper_ReplaceString(string StringToReplace)
        {
            string sRet = StringToReplace;

            // Vordefinierte Werte ersetzen
            if (StringToReplace.Contains("{{{IDKlient_current}}}"))
                sRet = sRet.Replace("{{{IDKlient_current}}}", ENV.CurrentIDPatient.ToString());

            if (StringToReplace.Contains("{{{IDUser_current}}}"))
                sRet = sRet.Replace("{{{IDUser_current}}}", ENV.USERID.ToString());

            if (StringToReplace.Contains("{{{IDAufenthalt_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAufenthalt_current}}}", p.Aufenthalt.ID.ToString());
            }

            if (StringToReplace.Contains("{{{IDAbteilung_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDAbteilung_current}}}", p.Aufenthalt.IDAbteilung.ToString());
            }

            if (StringToReplace.Contains("{{{IDKlinik_current}}}"))
            {
                Patient p = new Patient(ENV.CurrentIDPatient);
                sRet = sRet.Replace("{{{IDKlinik_current}}}", p.Aufenthalt.IDKlinik.ToString());
            }

            //// Alle Parameter iterieren
            //foreach (IBerichtParameterGUI u in this.pnlParameter.Controls)
            //{
            //    string sField = "{{{" + string.Format("{0}.Wert", u.BERICHTPARAMETER.Name) + "}}}";
            //    string sField1 = "{{{" + string.Format("{0}.Text", u.BERICHTPARAMETER.Name) + "}}}";
            //    if (StringToReplace.Contains(sField))
            //    {
            //        try
            //        {
            //            sRet = sRet.Replace(sField, u.VALUE.ToString());
            //        }
            //        catch (Exception ex)
            //        {
            //            string sMsgTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der erforderliche Berichtsparameter '{0}' hat einen ungültigen Wert!\n\rBitte geben Sie einen gültigen Wert ein.");
            //            sMsgTxt = string.Format(sMsgTxt, u.BERICHTPARAMETER.Name);
            //            System.Windows.Forms.MessageBox.Show(sMsgTxt);
            //        }
            //    }

            //    if (StringToReplace.Contains(sField1))
            //    {
            //        try
            //        {
            //            sRet = sRet.Replace(sField1, u.VALUE_TEXT);
            //        }
            //        catch (Exception ex)
            //        {
            //            string sMsgTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der erforderliche Berichtsparameter '{0}' hat einen ungültigen Wert!\n\rBitte geben Sie einen gültigen Wert ein.");
            //            sMsgTxt = string.Format(sMsgTxt, u.BERICHTPARAMETER.Name);
            //            System.Windows.Forms.MessageBox.Show(sMsgTxt);
            //        }
            //    }
            //}
            return sRet;
        }

    }

}
