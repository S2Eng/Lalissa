using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace PMDS.Global
{
    
    public class generic
    {

        public enum eAction
        {
            delete = 0,
            freigeben = 1,
            print = 2,
            save = 3,
            stornieren = 4
        }

        [DllImport("kernel32.dll")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);










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
                    bEnd = true;
                }
            }
            return result;
        }

        public DialogResult doAction(eAction typ, string txtQuestion, string txtHeader, string txtInfo, UltraGrid grid,
                    UltraLabel lblCount, List<UltraGridRow> arrSelected, bool msgBox, bool useChildBands)
        {
            try
            {
                foreach (UltraGridRow r in generic.GetAllRowsFromGroupedUltraGrid(grid, true, useChildBands))
                {
                    if (!IsInExpandedGroup(r))
                        continue;
                    arrSelected.Add(r);
                    //if (r.Selected) { arrSelected.Add(r); }
                }

                if (arrSelected.Count > 0)
                {
                    DialogResult res = DialogResult.Yes;
                    if (txtQuestion != "")
                        res = MessageBox.Show(txtQuestion, txtHeader, MessageBoxButtons.YesNo);
                    return res;
                }
                else
                {
                    if (msgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "", MessageBoxButtons.OK);
                    return DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doAction: " + ex.ToString());
                //return DialogResult.No;
            }
        }
        public static void getSelectedGridRows(UltraGrid grid, List<UltraGridRow> arrSelected, bool useChildBands)
        {
            foreach (UltraGridRow r in GetAllRowsFromGroupedUltraGrid(grid, true, useChildBands))
            {
                if (!IsInExpandedGroup(r))
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

        public static bool IsInExpandedGroup(UltraGridRow r)
        {
            if (r.ParentRow == null)			// keine Gruppierung ==> soll markiert werden
                return true;

            return r.ParentRow.IsExpanded;
        }
        public static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly)
        {
            GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, false);
        }

        public static DialogResult doAction2(eAction typ, string txtQuestion, string txtHeader, string txtInfo, UltraGrid grid,
                    UltraLabel lblCount, List<UltraGridRow> arrSelected, bool msgBox, bool useChildBands)
        {
            try
            {
                foreach (UltraGridRow r in  generic.GetAllRowsFromGroupedUltraGrid(grid, true, useChildBands))
                {
                    if (!generic.IsInExpandedGroup(r))
                        continue;
                    arrSelected.Add(r);
                    //if (r.Selected) { arrSelected.Add(r); }
                }

                if (arrSelected.Count > 0)
                {
                    DialogResult res = DialogResult.Yes;
                    if (txtQuestion != "")
                        res = MessageBox.Show(txtQuestion, txtHeader, MessageBoxButtons.YesNo);
                    return res;
                }
                else
                {
                    if (msgBox) QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "", MessageBoxButtons.OK);
                    return DialogResult.No;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("doAction2: " + ex.ToString());
            }
        }

        public static UltraGridRow[] GetAllRowsFromGroupedUltraGrid(UltraGrid g, bool bSelectedOnly, bool bUseChildBands)
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in g.Rows)
                generic.GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, bUseChildBands);
            return (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
        }
        public static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly, bool bUseChildBands)
        {
            if (r is UltraGridGroupByRow)
            {
                UltraGridGroupByRow gr = (UltraGridGroupByRow)r;
                foreach (UltraGridRow rr in gr.Rows)
                    GetAllRowsFromGroupedUltraGrid(rr, ref al, bSelectedOnly);
                return;
            }

            if (bUseChildBands && r.ChildBands != null)
            {
                foreach (UltraGridChildBand b in r.ChildBands)
                {
                    foreach (UltraGridRow rchild in b.Rows)
                        GetAllRowsFromGroupedUltraGrid(rchild, ref al, bSelectedOnly, bUseChildBands);
                }
            }

            if (r.IsFilteredOut)
                return;

            if (bSelectedOnly)
            {
                if (r.Selected)
                    al.Add(r);
            }
            else
            {
                al.Add(r);
            }

        }


        public static bool sEquals(List<object> s1, List<object> s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                foreach (object o1 in s1)
                {
                    foreach (object o2 in s2)
                    {
                        if (sEquals(o1, o2, compareMode, trim, IgnoreCase) == true)
                            return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("qs2.generic.sEquals (check list in list of objects): " + ex.ToString());
            }
        }

        public static bool sEquals(object s1, List<object> s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                foreach (object o2 in s2)
                {
                    if (sEquals(s1, o2, compareMode, trim, IgnoreCase) == true)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("qs2.generic.sEquals (check object in list of objects): " + ex.ToString());
            }
        }

        public static bool sEquals(object s1, object s2, Enums.eCompareMode compareMode = Enums.eCompareMode.Equals, bool trim = true, bool IgnoreCase = true)
        {
            try
            {
                if (trim)

                    switch (compareMode)
                    {
                        case Enums.eCompareMode.Equals:
                            return (s1.ToString() ?? "").Trim().Equals((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.StartsWith:
                            return (s1.ToString() ?? "").Trim().StartsWith((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.EndsWith:
                            return (s1.ToString() ?? "").Trim().EndsWith((s2.ToString() ?? "").Trim(), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.Contains:
                            return (s1.ToString() ?? "").Trim().IndexOf((s2.ToString() ?? "").Trim(), StringComparison.OrdinalIgnoreCase) >= 0;

                        default:
                            return false;
                    }
                else
                {
                    switch (compareMode)
                    {
                        case Enums.eCompareMode.Equals:
                            return (s1.ToString() ?? "").Equals((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.StartsWith:
                            return (s1.ToString() ?? "").StartsWith((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.EndsWith:
                            return (s1.ToString() ?? "").EndsWith((s2.ToString() ?? ""), IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

                        case Enums.eCompareMode.Contains:
                            return (s1.ToString() ?? "").IndexOf((s2.ToString() ?? ""), StringComparison.OrdinalIgnoreCase) >= 0;

                        default:
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("qs2.generic.sEquals: " + ex.ToString());
            }
        }


        //public static void CheckMemorySizeProcess(bool adminSecure, long MaxSizeMemory)
        //{
        //    try
        //    {
        //        if (!adminSecure)
        //        {
        //            System.Diagnostics.Process loProcess = System.Diagnostics.Process.GetCurrentProcess();
        //            long lnValue = loProcess.WorkingSet;
        //            long MemorySize = loProcess.WorkingSet64;
        //            long MaxSizeMemoryTmp = MaxSizeMemory * 1000 * 1000;
        //            if (MemorySize > MaxSizeMemoryTmp)
        //            {
        //                GC.Collect();
        //                GC.WaitForPendingFinalizers();
        //                if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        //                {
        //                    SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        //                }
        //            }
        //        }

        //        string xy = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("generic.CheckMemorySizeProcess: " + ex.ToString());
        //    }

        //}

    }

}
