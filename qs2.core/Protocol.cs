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
            //if (addToTotalProtocol)
            //{
            qs2.core.Protocol.nrOfError += 1;
            string sError = qs2.core.generic.lineBreak + qs2.core.Protocol.nrOfError.ToString() + ". " + TypeError .ToString() + " from " + DateTime.Now.ToString() + qs2.core.generic.lineBreak +
                                                                    sExcepSum + qs2.core.generic.lineBreak +
                                                                    "------------------------------------------------------------------------------------------------------------------------------------------------------";
            qs2.core.Protocol.totalProtocol = sError + qs2.core.Protocol.totalProtocol + qs2.core.generic.lineBreak;
            qs2.core.Protocol.totalProtocolMainForm = sError + qs2.core.Protocol.totalProtocolMainForm + qs2.core.generic.lineBreak;
            //}

            if (exception.Trim().ToLower().Contains((("NullReference").Trim().ToLower())))
            {
                string xy = "";
            }
            if (showException || alwaysShowExceptionMulticontrol)
            {
                //throw new Exception(sExcepSum);
                qs2.core.generic.getExep(sExcepSum.ToString(), "");
            }

            qs2.core.generic.doProtocoll("Error Stay - " + fctName + " - Field: " + FieldName.Trim() + "\r\n" + "\r\n" + exception, "", -999, Application, qs2.core.license.doLicense.rParticipant.IDParticipant.Trim());
        }

        public static void doMonitoring(string fctName, string Field, object value1, object value2, string txt,   
                                        string Application, eTypeError TypeError)
        {
            if (!qs2.core.ENV.adminSecure)
            {
                return;
            }

            if (qs2.core.ENV.monitoring)
            {
                string sMonitoringTxtSum = "";
                if (fctName.Trim() != "")
                {
                    sMonitoringTxtSum += fctName.Trim() + "   ";
                }
                if (Field.Trim() != "")
                {
                    sMonitoringTxtSum += "Field: " + Field.Trim() + "   ";
                }
                if (value1 != null)
                {
                    sMonitoringTxtSum += qs2.core.generic.lineBreak + "value1: " + value1.ToString().Trim();
                }
                if (value2 != null)
                {
                    sMonitoringTxtSum += qs2.core.generic.lineBreak + "value2: " + value2.ToString().Trim();
                }
                if (txt.Trim() != "")
                {
                    sMonitoringTxtSum += qs2.core.generic.lineBreak + "txt " + qs2.core.generic.lineBreak + txt.Trim();
                }
                if (Application.Trim() != "")
                {
                    sMonitoringTxtSum += qs2.core.generic.lineBreak + "Application " + Application.Trim();
                }

                qs2.core.Protocol.nrOfMonitoring += 1;
                sMonitoringTxtSum = qs2.core.generic.lineBreak + qs2.core.Protocol.nrOfMonitoring.ToString() + ". " + TypeError.ToString() + " from " + DateTime.Now.ToString() + qs2.core.generic.lineBreak +
                                                                        sMonitoringTxtSum + qs2.core.generic.lineBreak +
                                                                        "------------------------------------------------------------------------------------------------------------------------------------------------------";
                qs2.core.Protocol.MonitoringOutput = sMonitoringTxtSum + qs2.core.Protocol.MonitoringOutput + qs2.core.generic.lineBreak;
            }
       }

    }


}
