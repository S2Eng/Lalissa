using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;




namespace qs2.design.auto.print
{



    public class TableToArray
    {



        public Object[,] copyTableToArrayForTranslation(ref DataTable dtToTranslate)
        {
            try
            {
                //DataTable dtNew = new DataTable();
                //dtNew = dtToTranslate.Copy();

                System.Collections.Generic.List<System.Data.DataColumn> lstCols = new System.Collections.Generic.List<System.Data.DataColumn>();
                foreach (DataColumn col in dtToTranslate.Columns)
                {
                    //col.ReadOnly = false;
                    lstCols.Add(col);
                }

                int transColAdded = 0;
                int countRows = dtToTranslate.Columns.Count;
                foreach (DataColumn col in lstCols)
                {
                    //if (transColAdded <= 10000000)
                    //{
                    string colNameNewTrans = qs2.core.generic.TransEmpty + "" + col.ColumnName;
                        if (!dtToTranslate.Columns.Contains(colNameNewTrans.Trim()))
                        {
                            System.Data.DataColumn newCol = dtToTranslate.Columns.Add(colNameNewTrans.Trim(), typeof(string)); 
                        }
                        dtToTranslate.Columns[colNameNewTrans].SetOrdinal(dtToTranslate.Columns[col.ColumnName].Ordinal + 1);
                        transColAdded += 1;
                    //}
                    countRows += 1; 
                }

                int colCount = 0;
                int rowCount = 0;
                Object[,] objTranslated = new object[dtToTranslate.Rows.Count, dtToTranslate.Columns.Count];
                foreach (DataRow row in dtToTranslate.Rows)
                {
                    object[] itemArray = row.ItemArray;
                    colCount = 0;
                    foreach (object o in itemArray)
                    {
                        objTranslated[rowCount, colCount] = o;
                        colCount += 1;
                    }
                    rowCount += 1;
                }

                return objTranslated;
            }
            catch(Exception ex)
            {
                throw new Exception("TableToArray.copyTableToArrayForTranslation: " + "\r\n" + ex.ToString());
            }
        }

        public DataTable copyTranslatedArrayToNewTable(ref Object[,] objTranslated, ref DataTable dtOrig)
        {
            try
            {
                DataTable dtResult = new DataTable();
                dtResult = dtOrig.Clone();

                for (int i = 0; i < dtOrig.Rows.Count; i++)
                {
                    Object[] oRow = new object[dtResult.Columns.Count];
                    for (int j = 0; j < dtResult.Columns.Count; j++)
                    {
                        oRow[j] = objTranslated[i, j];
                    }
                    DataRow rNewRow = (DataRow)dtResult.NewRow();
                    rNewRow.ItemArray = oRow;
                    dtResult.Rows.Add(rNewRow);
                    //dtResult.LoadDataRow(oRow,  LoadOption.OverwriteChanges );
                }

                //dtResult.AcceptChanges();
                return dtResult;
            }
            catch(Exception ex)
            {
                throw new Exception("TableToArray.copyTranslatedArrayToNewTable: " + "\r\n" + ex.ToString());
            }
        }

        public void clearColumnsNotUsedForTranslation(ref DataTable dtTranslated)
        {
            try
            {
                System.Collections.Generic.List<System.Data.DataColumn> lstCols = new System.Collections.Generic.List<System.Data.DataColumn>();
                foreach (DataColumn col in dtTranslated.Columns)
                {
                    lstCols.Add(col);
                }

                //int colCount = 0;
                foreach (DataColumn col in lstCols)
                {
                    if (col.ColumnName.ToLower().StartsWith(qs2.core.generic.TransEmpty.ToLower()))
                    {
                        dtTranslated.Columns.Remove(col);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("TableToArray.clearColumnsNotUsedForTranslation: " + "\r\n" + ex.ToString());
            }
        }


    }

}
