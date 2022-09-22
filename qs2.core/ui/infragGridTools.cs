using Infragistics.Win.UltraWinGrid;
using System.Collections;




namespace qs2.core
{

    public class infragGridTools
    {
        protected static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly)
        {
            GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, false);
        }

        protected static void GetAllRowsFromGroupedUltraGrid(UltraGridRow r, ref ArrayList al, bool bSelectedOnly, bool bUseChildBands)
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
        
        public static UltraGridRow[] GetAllRowsFromGroupedUltraGrid(UltraGrid g, bool bSelectedOnly, bool bUseChildBands)
        {
            ArrayList al = new ArrayList();
            foreach (UltraGridRow r in g.Rows)
                GetAllRowsFromGroupedUltraGrid(r, ref al, bSelectedOnly, bUseChildBands);
            return (UltraGridRow[])al.ToArray(typeof(UltraGridRow));
        }

    }

}
