using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;




namespace qs2.core
{

    public class ui
    {

        public static string prefixMultiControl = "MC.";
        public static int maxSubrelations = 30;

        public enum eAutoFitStyle
        {
            ResizeAllColumns = 11200,
            ExtendLastColumn = 11201,
            None = 11202
        }

        public static Stopwatch watch = null;
        public static string watchResult = "";

        [DllImport("User32.dll")]
        public static extern long SetForegroundWindow(int hwnd);


        public enum eButtonType
        {
            Main = 1,
            Procedure = 2,
            Chapter = 3,
            StayBottom = 4,
            Queries = 5,
            Reports = 6,
            QueryGroups = 7
        }

        public class cHelpData
        {
            public string FldHort { get; set; }
            public string IDApplication { get; set; }
            public bool HasRes { get; set; }

        }
        public static System.Collections.Generic.List<cHelpData> lLastMCFocused { get; set; } = new List<cHelpData>();


        public static bool OpenStayUITimer { get; set; } = false;
        








        public static void doForegroundWindow(System.Windows.Forms.Form frm)
        {
            try
            {
                int hwnd = frm.Handle.ToInt32();
                SetForegroundWindow(hwnd);
            }
            catch (Exception ex)
            {
                throw new Exception("doForegroundWindow: " + ex.ToString());
            }
        }

        public static void showInfo(string txt)
        {
            //MessageBox.Show(txt);
        }
        public static void showInfo2(string txt)
        {
            //MessageBox.Show(txt);
        }
        public static void addWatch(string stateCode, bool newWatchStart)
        {
            if (!ENV.UseWatch)
                return;

            if (ui.watch == null)
            {
                ui.watch = new Stopwatch();
                ui.watch.Start();
            }

            ui.watch.Stop();
            //MessageBox.Show(main.watch.Elapsed.TotalMilliseconds.ToString());
            ui.watchResult += DateTime.Now.ToString("yy.MM.dd HH:mm:ss.fff - ")+  stateCode + ": " + ui.watch.Elapsed.TotalMilliseconds.ToString() + "\r\n";
            Clipboard.SetText(ui.watchResult.Trim());

            if (newWatchStart)
            {
                ui.watch = new Stopwatch();
                ui.watch.Start();
            }
        }

        public static void unvisibleAllTabs(Infragistics.Win.UltraWinTabControl.UltraTabControl tabControl)
        {
            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in tabControl.Tabs)
                tab.Visible = false;
        }
        public static void setTabVisible(Infragistics.Win.UltraWinTabControl.UltraTabControl tabControl, string key)
        {
            tabControl.Tabs[key].Visible = true;
            tabControl.SelectedTab = tabControl.Tabs[key];
        }

        public static void initGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            grid.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical;
            grid.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

            grid.DisplayLayout.Bands[0].ColHeaderLines = 1;
            grid.DisplayLayout.Bands[0].Override.RowAlternateAppearance.BackColor = Color.LightYellow;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ugCol in grid.DisplayLayout.Bands[0].Columns)
            {
                grid.DisplayLayout.Bands[0].Columns[ugCol.Key].Hidden = true;
            }

            grid.DisplayLayout.Override.SupportDataErrorInfo = Infragistics.Win.UltraWinGrid.SupportDataErrorInfo.CellsOnly;

            grid.Width = 2;

            grid.ActiveRow = null;
            grid.Selected.Rows.Clear();

        }

        public static void showColumn(string description, int width, int pos, string column, Infragistics.Win.UltraWinGrid.UltraGrid grid, string maskInput, bool allowUpdate)
        {
            grid.DisplayLayout.Bands[0].Columns[column].Hidden = false;
            grid.DisplayLayout.Bands[0].Columns[column].Width = width;
            grid.DisplayLayout.Bands[0].Columns[column].Header.VisiblePosition = pos;
            grid.DisplayLayout.Bands[0].Columns[column].Width = width;
            grid.DisplayLayout.Bands[0].Columns[column].Header.Caption = description;
            //if (allowUpdate)
            //{
            //    grid.DisplayLayout.Bands[0].Columns[column].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            //    grid.DisplayLayout.Bands[0].Columns[column].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //}
            //else
            //{
            grid.DisplayLayout.Bands[0].Columns[column].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            grid.DisplayLayout.Bands[0].Columns[column].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            //}
            grid.DisplayLayout.Bands[0].Columns[column].MaskInput = maskInput;

            grid.Width += width;
        }

        public void evBeforeRowRegionScrollAuto(ref object sender, ref BeforeRowRegionScrollEventArgs e, ref UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    e.Cancel = true;
        }
        public bool evDoubleClickOK(ref object sender, ref EventArgs e, ref UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinGrid.ExpansionIndicatorUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }
        public bool evClickOK(ref object sender, ref EventArgs e, ref UltraGrid grid)
        {
            if (grid.DisplayLayout.UIElement.LastElementEntered != null)

                if (grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollArrowUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollTrackSubAreaUIElement) &&
                     grid.DisplayLayout.UIElement.LastElementEntered.GetType() != typeof(Infragistics.Win.UltraWinScrollBar.ScrollThumbUIElement))

                    return true;

            return false;
        }

        public static bool delGridRowYN(Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            if (qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DeleteRecord"), MessageBoxButtons.YesNo, "") == DialogResult.Yes)
            {
                e.Cancel = false;
                return true;
            }
            else
            {
                e.Cancel = true;
                return true;
            }
        }

        public static void getSelectedGridRows(UltraGrid grid, List<UltraGridRow> arrSelected, bool useChildBands)
        {
            try
            {
                foreach (UltraGridRow r in infragGridTools.GetAllRowsFromGroupedUltraGrid(grid, true, useChildBands))
                {
                    if (!ui.IsInExpandedGroup(r))
                        continue;
                    arrSelected.Add(r);
                    //if (r.Selected) { arrSelected.Add(r); }
                }

                //if (arrSelected.Count > 0)
                //{
                //}
                //else
                //{
                //}
            }
            catch (Exception ex)
            {
                throw new Exception("ui.getSelectedGridRows:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
        public static bool IsInExpandedGroup(UltraGridRow r)
        {
            if (r.ParentRow == null)			// keine Gruppierung ==> soll markiert werden
                return true;

            return r.ParentRow.IsExpanded;
        }

        public static void loadResGridRessourcen(UltraGridBand band, qs2.core.language.dsLanguage dsLanguage1)
        {
            band.Columns[dsLanguage1.Ressourcen.IDResColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("IDRessource");
            band.Columns[dsLanguage1.Ressourcen.EnglishColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("English");
            band.Columns[dsLanguage1.Ressourcen.GermanColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("German");
            band.Columns[dsLanguage1.Ressourcen.UserColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("User");
            band.Columns[dsLanguage1.Ressourcen.IDLanguageUserColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("LanguageUser");
            band.Columns[dsLanguage1.Ressourcen.IDApplicationColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Application");
            band.Columns[dsLanguage1.Ressourcen.IDParticipantColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Participant");

            band.Columns[dsLanguage1.Ressourcen.TypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Type");
            band.Columns[dsLanguage1.Ressourcen.TypeSubColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("TypeSub");

            band.Columns[dsLanguage1.Ressourcen.DescriptionColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Description");

            band.Columns[dsLanguage1.Ressourcen.fileBytesColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("File");
            band.Columns[dsLanguage1.Ressourcen.fileTypeColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Filetype");

            band.Columns[dsLanguage1.Ressourcen.CreatedColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("Created");
            band.Columns[dsLanguage1.Ressourcen.CreatedUserColumn.ColumnName].Header.Caption = qs2.core.language.sqlLanguage.getRes("CreatedUser");
        }

        public static void editGrid(bool bEdit, UltraGrid grid, bool AddNewBox, Infragistics.Win.UltraWinGrid.AllowAddNew typAdd)
        {
            try
            {
                if (bEdit)
                {
                    grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
                    grid.DisplayLayout.Override.AllowAddNew = typAdd;
                    grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                    grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                }
                else
                {
                    grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                    grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
                    grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                    grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                }

                if (AddNewBox) grid.DisplayLayout.AddNewBox.Hidden = !bEdit;
            }
            catch (Exception ex)
            {
                throw new Exception("ui.editGrid:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

        public static void expandCollapseGridRow(UltraGridRow row, int bandIndex)
        {
            if (row != null)
            {
                if (row.Band.Index == 0)
                {
                    if (row.Expanded)
                        row.CollapseAll();
                    else
                        row.ExpandAll();
                }
            }
        }

        public static void CheckMouseHoverLeaveContr(object sender, EventArgs e, bool enter, string fldshort2, string app)
        {
            try
            {
                if (sender is Infragistics.Win.UltraWinEditors.UltraComboEditor || sender is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                    sender is Infragistics.Win.UltraWinEditors.UltraCheckEditor || sender is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor ||
                    sender is Infragistics.Win.UltraWinEditors.UltraNumericEditor || sender is Infragistics.Win.UltraWinEditors.UltraTextEditor ||
                    sender is Infragistics.Win.FormattedLinkLabel.UltraFormattedTextEditor || sender is Infragistics.Win.Misc.UltraLabel ||
                    sender is Infragistics.Win.Misc.UltraPanel || sender is Infragistics.Win.Misc.UltraButton)
                {
                    string fldshortTmp = fldshort2;
                    if (fldshort2.Contains(""))
                        fldshortTmp = fldshort2.Split('.')[1];
                    
                    if (enter)
                    {
                        var rRes = (from r in qs2.core.language.sqlLanguage.dsLanguageAll.Ressourcen
                                    where r.IDRes == fldshortTmp && r.IDApplication == app && r.Type == "Help" && r.IDLanguageUser == "ALL" && r.IDParticipant == "ALL"
                                    select new { r.IDRes, r.German, r.English }).FirstOrDefault();
                        if (sender is Infragistics.Win.Misc.UltraLabel)
                        {
                            if (rRes != null)
                                ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.True;
                            else
                                ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                        }
                             
                        var rLastSelected = (from l in lLastMCFocused
                                                where l.IDApplication == app
                                                select new { l.FldHort, l.IDApplication }).FirstOrDefault();
                        if (rLastSelected == null)
                            lLastMCFocused.Add(new core.ui.cHelpData() { FldHort = fldshortTmp, IDApplication = app, HasRes = (rRes != null ? true : false) });
                        else
                        {
                            lLastMCFocused.First().FldHort = fldshortTmp;
                            lLastMCFocused.First().HasRes = (rRes != null ? true : false);
                        } 
                    }
                    else
                    {
                        if (sender is Infragistics.Win.Misc.UltraLabel)
                        {
                            ((Infragistics.Win.Misc.UltraLabel)sender).Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;
                        }
                    
                        var rLastSelected = (from l in lLastMCFocused
                                                where l.IDApplication == app
                                                select new { l.IDApplication }).FirstOrDefault();
                        if (rLastSelected != null)
                            lLastMCFocused.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("ui.CheckMouseHoverLeaveContr:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }
    }

}
