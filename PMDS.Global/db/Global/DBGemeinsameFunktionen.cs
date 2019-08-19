using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

using RBU;
using PMDS.Global;
using PMDS.Data.Global;


namespace PMDS.DB.Global
{
    public class DBGemeinsameFunktionen
    {
        //----------------------------------------------------------------------------
        /// <summary>
        /// Sortieren
        /// </summary>
        //----------------------------------------------------------------------------
        public static DataTable Sort(DataTable dtSelect, string sSelect, string sSort)
        {
            DataTable dtResult = new DataTable();
            dtResult = dtSelect.Copy();
            dtResult.Clear();

            //dsAuswahlGruppe.AuswahlListeDataTable dtRes = new dsAuswahlGruppe.AuswahlListeDataTable();
            System.Data.DataRow[] rArray = (System.Data.DataRow[])dtSelect.Select(sSelect, sSort);
            rArray.CopyToDataTable(dtResult, LoadOption.Upsert);
            return dtResult;
        }

    }
}
