using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace qs2.sitemap.print
{


    public class print
    {


        public qs2.core.Enums.eStayTyp getTypeQuery(string Classification)
        {
            try
            {
                qs2.core.Enums.eStayTyp StayTypeSubQuery = core.Enums.eStayTyp.All;
                System.Collections.Generic.List<string> lstClassification = qs2.core.generic.readStrVariables(Classification.Trim());
                foreach (string entryClassification in lstClassification)
                {
                    string sValue = "";
                    string sType = "Type";
                    qs2.core.vb.funct.getVariablesLefRightOfPoint(entryClassification.Trim(), ref sType, ref sValue, "=");
                    if (sValue.Trim().ToLower().Equals(core.Enums.eTypList.PROCGRP.ToString().Trim().ToLower() + "0"))
                    {
                        StayTypeSubQuery = core.Enums.eStayTyp.Stay;
                    }
                    else if (sValue.Trim().ToLower().Equals(core.Enums.eTypList.PROCGRP.ToString().Trim().ToLower() + "1"))
                    {
                        StayTypeSubQuery = core.Enums.eStayTyp.FollowUp;
                    }
                }

                return StayTypeSubQuery;
            }
            catch (Exception ex)
            {
                throw new Exception("getTypeQuery: " + ex.ToString());
                //return core.Enums.eStayTyp.All;
            }
        }

    }
}
