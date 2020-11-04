using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{
    public class OldFuncts
    {

        public enum eTypVar
        {
            tInt = 0,
            tString = 1,
            tDouble = 2
        }




        public static object getVarConfig_Old(string sVariable, string sValue, eTypVar TypVar)
        {
            if (TypVar == eTypVar.tString)
            {
                if (string.IsNullOrEmpty(sValue))
                    return "";
                else
                    return sValue.ToString().Trim();
            }
            else if (TypVar == eTypVar.tInt)
            {
                if (string.IsNullOrEmpty(sValue))
                    return -1;
                else
                    return System.Convert.ToInt32(sValue.ToString().Trim());
            }
            else if (TypVar == eTypVar.tDouble)
            {
                if (string.IsNullOrEmpty(sValue))
                    return -1;
                else
                    return System.Convert.ToDouble(sValue.ToString().Trim());
            }
            else
                throw new Exception("TypVar '" + TypVar.ToString() + "' not allowed!");
        }


    }
}
