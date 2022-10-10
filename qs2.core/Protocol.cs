using System;




namespace qs2.core
{
    public class Protocol
    {
        public static string MonitoringOutput = "";
        public static int nrOfMonitoring = 0;

        public static string totalProtocolMainForm = "";
        public static string totalProtocol = "";
        public static int nrOfError = 0;
        public static bool alwaysShowExceptionMulticontrol = true;
        public static bool ErrorsShowedToUser = false;

        public enum eTypeError
        {
            Error = 0,
            Info = 1,
            FldShort = 2
        }

        public static void doExcept(string exception, string fctName, string FieldName, bool showException, bool addToTotalProtocol,
                                        string Application, bool alwaysShowExceptionMulticontrol, eTypeError TypeError)
        {
            string sExcepSum = "";
            if (Application.Trim() != "")
            {
                sExcepSum = "Application " + Application.Trim() + ": ";
            }
            if (fctName.Trim() != "")
            {
                sExcepSum += fctName.Trim() + ": ";
            }
            if (FieldName.Trim() != "")
            {
                sExcepSum += "Field: " + FieldName.Trim() + "";
            }
            if (sExcepSum.Trim() != "")
            {
                sExcepSum += qs2.core.generic.lineBreak + qs2.core.generic.lineBreak;
            }
            sExcepSum += exception.Trim();
            qs2.core.Protocol.nrOfError += 1;
            string sError = qs2.core.generic.lineBreak + qs2.core.Protocol.nrOfError.ToString() + ". " + TypeError .ToString() + " from " + DateTime.Now.ToString() + qs2.core.generic.lineBreak +
                                                                    sExcepSum + qs2.core.generic.lineBreak +
                                                                    "------------------------------------------------------------------------------------------------------------------------------------------------------";
            qs2.core.Protocol.totalProtocol = sError + qs2.core.Protocol.totalProtocol + qs2.core.generic.lineBreak;
            qs2.core.Protocol.totalProtocolMainForm = sError + qs2.core.Protocol.totalProtocolMainForm + qs2.core.generic.lineBreak;

            if (showException || alwaysShowExceptionMulticontrol)
            {
                qs2.core.generic.getExep(sExcepSum.ToString(), "");
            }
        }
    }
}
