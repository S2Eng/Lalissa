using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WCFServicePMDS.GenericClasses
{
    public class RegEx
    {

        public static string StripCharacters(string inputString)
        {
            string pattern = "[0-9]";
            Regex r = new Regex(pattern);
            MatchCollection mc = r.Matches(inputString);
            string retVal = string.Empty;
            for (int i = 0; i < mc.Count; i++)
            { retVal += mc[i].Value; }
            return retVal;
        }
    }
}
