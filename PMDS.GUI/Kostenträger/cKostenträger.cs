using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace PMDS.Klient.UIKostenträger
{
    //<20120111>
    public class cKostenträger
    {


        public bool newFIBUKonto(PMDS.Global.db.Global.ds_abrechnung.ds_KostenträgerPatKostenträger.dsKostentraeger.KostentraegerDataTable tKostenträger,
                                    ref string sNewFIBUKonto, ref int nNewFIBUKonto,string Bereich)
        {
            try
            {
                string newFIBUKonto = Bereich.Trim();
                int nLastNr = 0;
                foreach (PMDS.Global.db.Global.ds_abrechnung.ds_KostenträgerPatKostenträger.dsKostentraeger.KostentraegerRow rKost in tKostenträger)
                {
                    int nNrActuell = -1;

                    try
                    {
                        if (rKost.FIBUKonto.Trim().Length == 6)
                        {
                            if (rKost.FIBUKonto.Trim().Substring(0, 2) == Bereich.Trim())
                            {
                                nNrActuell = System.Convert.ToInt32(rKost.FIBUKonto.Trim().Substring(rKost.FIBUKonto.Trim().Length - 4, 4));
                                if (nNrActuell > nLastNr)
                                    nLastNr = nNrActuell;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                    //sRechNr += bill.Bereich + Right(RechDatum.Year.ToString, 2) + Right("00000" & rechNr.ToString(), 5)
                }
                nLastNr += 1;
                string sTempNr = "0000" + nLastNr.ToString();
                sTempNr = sTempNr.Substring(sTempNr.Length - 4, 4);
                nNewFIBUKonto = System.Convert.ToInt32(sTempNr);
                sNewFIBUKonto = newFIBUKonto + sTempNr;
                return true;
            }
            catch (Exception ex)
            {
                PMDS.Global.ENV.HandleException(ex);
                return false;
            }
        }


    }
}
