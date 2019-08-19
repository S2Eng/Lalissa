using System;
using System.Collections.Generic;
using System.Text;
using PMDS.Global;
using PMDS.Data.PflegePlan;
using PMDS.Global.db.Pflegeplan;

namespace PMDS.BusinessLogic
{
    public class ASZMTransfer
    {
        public ASZMTransfer()
        {

        }

        public static bool IsUntertaegig(ASZMSelectionArgs arg)
        {
            if (arg.ZEITBEREICH != null)
                return true;
            if (arg.UNTERTAEGIG == null && !arg.UntertaegigBenutzerdefiniertJN)
                return false;
            else
                return true;    //UntertaegigBenutzerdefiniertJN : true
            //   - UNTERTAEGIG : null
            //UntertaegigBenutzerdefiniertJN : false
            //   - UNTERTAEGIG != null
        }

        public static PDxSelectionArgs[] GetPDxSelectionArgs(ASZMSelectionArgs[] args)
        {
            List<PDxSelectionArgs> list = new List<PDxSelectionArgs>();
            PDxSelectionArgs pdxSa;
            PDx pdx = new PDx();
            dsPDx.PDXRow pdxRow;

            bool found;
            foreach (ASZMSelectionArgs sa in args)
            {
                if (sa.IDPDX != null)
                {
                    pdxRow = pdx.ReadOne(sa.IDPDX);

                    pdxSa = new PDxSelectionArgs();
                    pdxSa.IDPDX              = sa.IDPDX;
                    pdxSa.Klartext           = pdxRow.Klartext;
                    pdxSa.Text               = pdxRow.Klartext;
                    pdxSa.StartDatum         = sa.StartDatum;
                    pdxSa.LokalisierungJN    = sa.LokalisierungJN;
                    pdxSa.Lokalisierung      = sa.Lokalisierung;
                    pdxSa.LokalisierungSeite = sa.LokalisierungSeite;
                    pdxSa.EvalStartDatum     = sa.EvalStartDatum;
                    pdxSa.LokalisierungsTyp  = (PDxLokalisierungsTypen)pdxRow.LokalisierungsTyp;
                    pdxSa.Resourceklient     = sa.Resourceklient;

                    found = false;

                    foreach (PDxSelectionArgs pdxA in list)
                    {
                        if (pdxA.IDPDX == pdxSa.IDPDX)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        list.Add(pdxSa);
                }
            }

            List<ASZMSelectionArgs> listSA;

            foreach (PDxSelectionArgs pdxA in list)
            {
                listSA = new List<ASZMSelectionArgs>();

                foreach (ASZMSelectionArgs sa in args)
                {
                    if (sa.IDPDX != null && sa.IDPDX == pdxA.IDPDX)
                        listSA.Add(sa);
                }

                pdxA.ARGS = listSA.ToArray();
            }

            return list.ToArray();
        }

    }
}
