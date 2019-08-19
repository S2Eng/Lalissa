using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace itscont.service.core.cs
{

    public class General
    {
                
        public static System.Collections.Generic.List<string> readStrVariables(string str)
        {
            System.Collections.Generic.List<string> result = new System.Collections.Generic.List<string>();
            int lastPos = 0;
            bool bEnd = false;
            while (!bEnd)
            {
                int aktPos = str.IndexOf(";", lastPos);
                if (aktPos != -1)
                {
                    string var = str.Substring(lastPos, aktPos - lastPos);
                    result.Add(var);
                    lastPos = aktPos + 1;
                }
                else
                {
                    bEnd = true;
                }
            }
            return result;
        }

        public static string readStrBetween(string strToSearch, ref int actPos, string separatorToSearchBetween,
                            string separatorToSearchEnd, bool forwarding, bool searchFirstPos,
                            bool returnEmptyIfNotContains)
        {
            if (actPos > strToSearch.Length)
                return "";

            if (returnEmptyIfNotContains)
            {
                // Search-String not contains separatorToSearchBetween
                string subToSearch = strToSearch.Substring(actPos, strToSearch.Length - actPos);
                if (!subToSearch.Contains(separatorToSearchBetween))
                    return "";
            }

            if (searchFirstPos)
            {
                int posForSearching = actPos;
                bool firstSignPosFound = false;
                bool abort = false;
                while (posForSearching <= strToSearch.Length && !abort && !firstSignPosFound)
                {
                    if (posForSearching == strToSearch.Length)
                        abort = true;
                    else
                    {
                        string nextSign = itscont.service.core.cs.General.getSubstring(strToSearch, posForSearching, 1);
                        if (nextSign == separatorToSearchBetween)
                        {
                            firstSignPosFound = true;
                        }
                        else
                            posForSearching += 1;
                    }
                }
                if (firstSignPosFound)
                    actPos = posForSearching;
            }

            if (forwarding)
            {
                bool lastSpaceFound = false;
                int posToSearch = actPos;
                while (posToSearch <= strToSearch.Length && !lastSpaceFound)
                {
                    if (posToSearch == strToSearch.Length)
                        lastSpaceFound = true;
                    else
                    {
                        string nextSign = itscont.service.core.cs.General.getSubstring(strToSearch, posToSearch, 1);
                        if (nextSign == separatorToSearchBetween)
                        {
                            posToSearch += 1;
                        }
                        else
                            lastSpaceFound = true;
                    }
                }
                actPos = posToSearch;
            }

            int actPosNextSpace = -1;
            if (separatorToSearchEnd.Trim() == "")
                actPosNextSpace = itscont.service.core.cs.General.nextPos(strToSearch, separatorToSearchBetween, actPos);
            else
                actPosNextSpace = itscont.service.core.cs.General.nextPos(strToSearch, separatorToSearchEnd, actPos);

            if (actPosNextSpace != -1)
            {
                int actPosRead = actPos;
                actPos = actPosNextSpace;
                return itscont.service.core.cs.General.getSubstring(strToSearch, actPosRead, actPosNextSpace - actPosRead);
            }
            else
            {
                int actPosRead = actPos;
                actPos = strToSearch.Length;
                return itscont.service.core.cs.General.getSubstring(strToSearch, actPosRead, strToSearch.Length - actPosRead);
            }
        }

        public static string getSubstring(string strToSearch, int startIndex, int length)
        {
            return strToSearch.Substring(startIndex, length);
        }
        public static int nextPos(string strToSearch, string searchStr, int actPos)
        {
            return strToSearch.IndexOf(searchStr, actPos);
        }
        
    }
}
