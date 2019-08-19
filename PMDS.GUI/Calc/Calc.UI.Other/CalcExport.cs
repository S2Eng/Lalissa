using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMDS.Global.db.Global.ds_abrechnung;



namespace PMDS.Calc.UI.Admin.WorkCalcDb
{
    

    public class CalcExport
    {
        private dsKostentraeger.KostentraegerDataTable _dtKostenträger;
        private PMDS.DB.Global.DBKostentraeger _kostentraeger = new PMDS.DB.Global.DBKostentraeger();
        private PMDS.Calc.Logic.dbExport dbExport1  = new PMDS.Calc.Logic.dbExport();

        


        public void loadKostenträger(ref PMDS.Calc.Logic.dsExport dsExport1, Infragistics.Win.UltraWinGrid.UltraGrid gridKost)
        {
            try
            {
                //<20120111>
                dsExport1.ExportKostentraeger.Rows.Clear();
                
                if (this._dtKostenträger != null)
                {
                    this._dtKostenträger.Rows.Clear();
                    gridKost.Refresh();
                }
                
                this._dtKostenträger = this._kostentraeger.GetKostentraeger(true, true, true, true, PMDS.Global.ENV.IDKlinik);
                foreach (dsKostentraeger.KostentraegerRow rKost in this._dtKostenträger.Rows)
                {
                    PMDS.Calc.Logic.dsExport.ExportKostentraegerRow rKostExport = this.dbExport1.getNewRowExportKostenträger(dsExport1);

                    int nKontoNr = -1;
                    try
                    {
                        nKontoNr = System.Convert.ToInt32(rKost.FIBUKonto.Trim());
                        rKostExport.KontoNr = nKontoNr.ToString();
                    }
                    catch (Exception ex)
                    {
                        rKostExport.KontoNr = "Error: FIBU-Konto '" + rKost.FIBUKonto.Trim() + "' is no Integer!";
                    }
                    rKostExport.Name = rKost.Name.ToString() + " " + rKost.Vorname.ToString();
                    rKostExport.Matchcode = rKostExport.Name;
                    rKostExport.Strasse = rKost.Strasse.Trim();
                    rKostExport.Postltz = rKost.PLZ.Trim();
                    rKostExport.Ort = rKost.Ort.Trim();
                    rKostExport.Platzhalter = "";
                    rKostExport.Sammelkonto = "?";
                    rKostExport.IDKostenträger = rKost.ID;
                    rKostExport.Message = "";        //"<br/>";
                }

                gridKost.Refresh();
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
            }
        }


    }
}
