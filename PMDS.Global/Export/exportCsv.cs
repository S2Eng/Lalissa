using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace PMDS.Global.ExportCsv
{


    public class exportCsv
    {
        public static string Separator = ";";
        public static string lineBreak = "\r\n";

        

        public bool doCSV(Infragistics.Win.UltraWinGrid.UltraGrid gridxy, Environment.SpecialFolder toFolder, 
                        System.Data.DataSet dsToExport, string fileSelected , string  TableNameToExport, 
                        System.Collections.Generic.List<String> lstColsNotExport, 
                        string columnCheckIfRowExport)
        {
            try
            {
                string resultCsv = "";
                foreach (System.Data.DataTable table in dsToExport.Tables)
                {
                    bool exportTable = false;
                    if (TableNameToExport.Trim() == "")
                    {
                        exportTable = true;
                    }
                    else
                    {
                        if (TableNameToExport.Trim() == table.TableName)
                        {
                            exportTable = true;
                        }
                    }

                    if (exportTable)
                    {
                        foreach (System.Data.DataColumn col in table.Columns)
                        {
                            bool exportCol = this.exportColumn(lstColsNotExport, col.ColumnName);
                            if (exportCol)
                            {
                                resultCsv += col.ColumnName + Separator;
                                //resultCsv += "äöü" + Separator;
                            }
                        }
                        resultCsv += exportCsv.lineBreak;
                        foreach (System.Data.DataRow r in table.Rows)
                        {
                            bool exportColOk = false;
                            if (columnCheckIfRowExport.Trim() != "")
                            {
                                if ((bool)r[columnCheckIfRowExport.Trim()] == true)
                                    exportColOk = true;
                            }
                            else
                            {
                                exportColOk = true;
                            }
                            if (exportColOk)
                            {
                                foreach (System.Data.DataColumn col in table.Columns)
                                {
                                    bool exportCol = this.exportColumn(lstColsNotExport, col.ColumnName);
                                    if (exportCol)
                                    {
                                        if (r[col.ColumnName] != System.DBNull.Value)
                                        {
                                            resultCsv += r[col.ColumnName].ToString() + Separator;
                                        }
                                        else
                                        {
                                            resultCsv += Separator;
                                        }
                                    }
                                }
                                resultCsv += exportCsv.lineBreak;
                            }
                        } 
                    }
                }

                System.IO.FileStream FileStream1 = new System.IO.FileStream(fileSelected, System.IO.FileMode.CreateNew);
                System.IO.StreamWriter StreamWriter1 = new System.IO.StreamWriter(FileStream1, Encoding.GetEncoding("iso-8859-1"));
                StreamWriter1.Write(resultCsv);
                StreamWriter1.Close();
                FileStream1.Close();

                //UnicodeEncoding ascII = new UnicodeEncoding();
                //Byte[] encodedBytes = ascII.GetBytes(resultCsv);
                //System.IO.FileStream FileStreamBytes = new System.IO.FileStream(fileSelected, System.IO.FileMode.CreateNew);
                //System.IO.BinaryWriter BinaryWriter1 = new System.IO.BinaryWriter(FileStreamBytes);
                //BinaryWriter1.Write(encodedBytes);
                //BinaryWriter1.Close();
               
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("exportCsv.doCSV: " + "\r\n" + ex.ToString());
            }
        }

        public bool exportColumn(System.Collections.Generic.List<String> lstColsNotExport, string colToCheck)
        {
            foreach(string colNotExport in lstColsNotExport)
            {
                if (colNotExport.Trim() == colToCheck.Trim())
                {
                    return false;  
                }
            }
            return true;
        }
  

    }
}
