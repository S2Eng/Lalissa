using System;

namespace QS2.functions.cs
{
    public class Funct
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
    }
}

