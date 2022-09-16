using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Design;
using System.Diagnostics;

namespace QS2.functions.cs
{

    
    public class funct
    {
        public static string incorrSel = "Incorrect selection";
        public static int idMinus = -999999;

        public static string columnNameSelection = "Selection";
        public static string columnNameText = "Text";
        public static string columnActive = "Active";
        public static string columnNameClassification = "Classification";
        public static string columnNameType = "Type";
        public static string columnNameVal = "Val";
        public static string columnNameValTxt = "ValTxt";
        public static string columnNameIDJoin = "IDJoin";
        public static string columnNameObject = "Obj";
        public static string columnNameIDKey = "IDKey";
        public static string columnChecked = "Checked";
        public static string columnUsed = "Used";
        public static string columnNewTranslation = "NewTranslation";
        public static string columnValueTranslated = "ValueTranslated";
        public static string columnStatus = "Status";
        public static string columnNewName = "NewName";
        public static string columnNameIDGroup = "IDGroup";
        public static string columnMultiControl = "MultiControl";

        public static string columnParameterForReport = "ParameterForReport";
        public static string columnParameterLabelTranslated = "ParameterLabelTranslated";
        public static string columnParameterCombinationTranslated = "CombinationTranslated";
        public static string columnParameterCombinationEndTranslated = "CombinationEndTranslated";
        public static string columnParameterSqlWhereUI = "SqlWhereUI";
        public static string columnOrderBy = "OrderBy";

        public static string CriteriaApplicationParameters = "Parameters";

        public static string typBytes = "Bytes";

        public static event doLog evdoLog;
        public delegate void doLog(string ex, string title);

        public static string maskInputInteger = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
        public static string FormatInteger = "###,###,###,###,###,##0";

        public static string maskInputDecimal = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn.nn";
        public static string FormatDecimal = "###,###,###,###,###,##0.00";

        public static int maxValueDefaultNumeric = 2147483647;
        public static int minValueDefaultNumeric = -2147483648;

        public static int maxValueDefaultText = 32767;
        public static int minValueDefaultText = 0;

        public static string maskInputDateTime = "{date} {time}";
        public static string FormatDateTime = "g";

        public static string maskInputDate = "{date}";
        public static string FormatDate = "d";

        public static string maskInputTime = "{LOC}hh:mm";
        public static string FormatTime = "HH:mm";

        public static string lineBreak = "\r\n";

        public enum eStatusTmp
        {
            Done = 0,
            ForDelete = 1
        }



        public static void openWindowsExplorer(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", path);
        }


        public static void runGarbColl()
        {
            try
            {
                System.GC.Collect();
            }
            catch (Exception e)
            {
                throw new Exception("funct.runGarbColl: " + e.ToString());
            }
        }




        // Fkt. Get Variablen by Semikolon
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
                        string nextSign = funct.getSubstring(strToSearch, posForSearching, 1);
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
                        string nextSign = funct.getSubstring(strToSearch, posToSearch, 1);
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
                actPosNextSpace = funct.nextPos(strToSearch, separatorToSearchBetween, actPos);
            else
                actPosNextSpace = funct.nextPos(strToSearch, separatorToSearchEnd, actPos);

            if (actPosNextSpace != -1)
            {
                int actPosRead = actPos;
                actPos = actPosNextSpace;
                return funct.getSubstring(strToSearch, actPosRead, actPosNextSpace - actPosRead);
            }
            else
            {
                int actPosRead = actPos;
                actPos = strToSearch.Length;
                return funct.getSubstring(strToSearch, actPosRead, strToSearch.Length - actPosRead);
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


        public static bool checkExceptionServerNotReachable(string except)
        {
            if (funct.checkExceptionDBNetLib2(except) || funct.checkExceptionDBNetLib5(except) || funct.checkExceptionDBNetLib3(except) || funct.checkExceptionDBNetLib4(except) || funct.checkExceptionDBNetLib2(except) || funct.checkExceptionAbfragetimeout(except) || funct.checkExceptionPhysischeVerbindung(except))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkExceptionDBNetLib4(string except)
        {
            if (except.Trim().ToLower().Contains(("Server antwortet nicht").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib2(string except)
        {
            if (except.Trim().ToLower().Contains(("DBNETLIB").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib3(string except)
        {
            if (except.Trim().ToLower().Contains(("bereits ein geöffneter DataReader zugeordnet").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionDBNetLib5(string except)
        {
            if (except.Trim().ToLower().Contains(("Status der Verbindung ist 'Geschlossen'").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionAbfragetimeout(string except)
        {
            if (except.Trim().ToLower().Contains(("Abfragetimeout").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkExceptionPhysischeVerbindung(string except)
        {
            if (except.Trim().ToLower().Contains(("Physische Verbindung nicht einsatzbereit").Trim().ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Wait(int WaitSeconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitSeconds * 1000)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }
        }
        public static void WaitMilli(int WaitMilliseconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool bEndWait = false;
            while (!bEndWait)
            {
                if (stopwatch.ElapsedMilliseconds >= WaitMilliseconds)
                {
                    bEndWait = true;
                }
                System.Threading.Thread.Sleep(1);
            }
        }

    }

}


