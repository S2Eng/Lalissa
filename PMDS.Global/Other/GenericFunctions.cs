using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace PMDS.Global
{

    
    public class GenericFunctions
    {

        public static System.Guid genGuid(System.Guid lastGuid)                                         //<20120202>
        {
            string sNewGuid = System.Guid.NewGuid().ToString();
            int lastNrFromGuid = System.Convert.ToInt32(lastGuid.ToString().Substring(36 - 12, 12));
            string sNewNrForGuid = (lastNrFromGuid + 1).ToString();
            string sNewGuidLastPart = "000000000000";
            sNewGuidLastPart = (sNewGuidLastPart + sNewNrForGuid).Substring((sNewGuidLastPart + sNewNrForGuid).Length -12 , 12);
            sNewGuid = sNewGuid.Substring(0, sNewGuid.Length - 12) + sNewGuidLastPart;
            return new System.Guid(sNewGuid);
        }

        public static System.Guid getLastGuid(System.Collections.Generic.List<System.Guid> lstGuid)     //<20120202>
        {
            string sNewGuid = System.Guid.NewGuid().ToString();
            int lastNrFromGuid = 0;
            foreach (System.Guid IDGuidActuell in lstGuid)
            {
                int NrFromGuid = System.Convert.ToInt32(IDGuidActuell.ToString().Substring(36 - 12, 12));
                if (NrFromGuid > lastNrFromGuid)
                {
                    lastNrFromGuid = NrFromGuid;
                }
            }

            string sNewNrForGuid = (lastNrFromGuid).ToString();
            string sNewGuidLastPart = "000000000000";

            sNewGuidLastPart = (sNewGuidLastPart + sNewNrForGuid).Substring((sNewGuidLastPart + sNewNrForGuid).Length - 12, 12);
            sNewGuid = sNewGuid.Substring(0, sNewGuid.Length - 12) + sNewGuidLastPart;

            return new System.Guid(sNewGuid);
        }

    }

}
