using System;
using System.Runtime.Serialization;


namespace PMDS.Global
{

    public class AppException : Exception
    {

        public class AppExceptionDetails
        {
            public string Message { get; set; } = "";
            public int ExcepNr { get; set; } = -1;
            public string exceptInfo { get; set; } = "";
            public Exception InnerException { get; set; } 
            public string TargetSite { get; set; } = "";
            public string StackTrace { get; set; } = "";
            public string HResult { get; set; } = "";
            public string HelpLink { get; set; } = "";
        }

        public System.Collections.Generic.List<AppExceptionDetails> lstExceptNrs { get; set; } = new System.Collections.Generic.List<AppExceptionDetails>();
        public int ExcepNr { get; set; } = -1;






        public AppException(string message, Exception ex, int ExcepNrInput, Exception InnerException,
                            string TargetSite, string StackTrace, string HResult, string HelpLink, string exceptInfo) : base(message)
        {
            if (ex != null && ex.GetType().Equals(typeof(AppException)))
            {
                AppException AppEx = (AppException)ex;
                this.lstExceptNrs = AppEx.lstExceptNrs;
                this.ExcepNr = ExcepNrInput;

                AppExceptionDetails newAppExceptionDetails = new AppExceptionDetails();
                newAppExceptionDetails.Message = message;
                newAppExceptionDetails.ExcepNr = ExcepNr;
                newAppExceptionDetails.exceptInfo = exceptInfo;

                newAppExceptionDetails.InnerException = InnerException;
                newAppExceptionDetails.TargetSite = TargetSite;
                newAppExceptionDetails.StackTrace = StackTrace;
                newAppExceptionDetails.HResult = HResult;
                newAppExceptionDetails.HelpLink = HelpLink;

                this.lstExceptNrs.Add(newAppExceptionDetails);
            }
            else
            {
                this.ExcepNr = ExcepNrInput;

                AppExceptionDetails newAppExceptionDetails = new AppExceptionDetails();
                newAppExceptionDetails.Message = message;
                newAppExceptionDetails.ExcepNr = ExcepNr;
                newAppExceptionDetails.exceptInfo = exceptInfo;

                newAppExceptionDetails.InnerException = InnerException;
                newAppExceptionDetails.TargetSite = TargetSite;
                newAppExceptionDetails.StackTrace = StackTrace;
                newAppExceptionDetails.HResult = HResult;
                newAppExceptionDetails.HelpLink = HelpLink;

                this.lstExceptNrs.Add(newAppExceptionDetails);

                bool IsNoAppException = true;
            }
        }



        public static void throwException(string sEcepInfo, int ExcepNr)
        {
            //string NewLine = "<br/>";

            //string sExceptTmp = "MessageNr:" + ExcepNr.ToString() +  " - " + sEcepInfo;                 //NewLine + NewLine +
            //throw new AppException(sExceptTmp, null, ExcepNr, null, "", "", "", "", sExceptTmp);

            AppException.throwException(null, "", ExcepNr, sEcepInfo);
        }
        public static void throwException(Exception ex)
        {
            AppException.throwException(ex, "", -1, "");
        }
        public static void throwException(Exception ex, int ExcepNr)
        {
            AppException.throwException(ex, "", ExcepNr, "");
        }
        public static void throwException(Exception ex, string exceptInfo)
        {
            AppException.throwException(ex, exceptInfo, -1, "");
        }
        public static void throwException(Exception ex2, string exceptInfo, int ExcepNr, string excepTxt)
        {
            string NewLine = "<br/>";
            AppException AppEx = null;

            string sExceptTmp = "";
            Exception InnerExceptionTmp = null;
            string TargetSiteTmp = "";
            string StackTraceTmp = "";

            if (ex2 != null)
            {
                AppEx = new AppException(ex2.ToString(), ex2, ExcepNr, null, "", "", "", "", "");

                InnerExceptionTmp = ex2.InnerException;
                TargetSiteTmp = ex2.TargetSite.ToString();
                StackTraceTmp = ex2.StackTrace;

                AppEx.HelpLink = ex2.HelpLink;
                //AppEx.HResult = ex.HResult;
                //AppEx.InnerException = ex.InnerException;
                //AppEx.Message = ex.Message;
                AppEx.Source = ex2.Source;
                //AppEx.StackTrace = ex.StackTrace;
                //AppEx.TargetSite = ex.TargetSite;

                if (exceptInfo.Trim() != "")
                {
                    sExceptTmp = exceptInfo.Trim() + ": " + ex2.ToString();
                }
                else
                {
                    sExceptTmp = ex2.ToString();
                }
            }
            else
            {
                AppEx = new AppException(excepTxt, null, ExcepNr, null, "", "", "", "", "");
                sExceptTmp = excepTxt;
            }

            sExceptTmp = "MessageNr:" + ExcepNr.ToString() + " - " + sExceptTmp;                    //NewLine + NewLine + 
            throw new AppException(sExceptTmp, AppEx, ExcepNr, InnerExceptionTmp,
                                    TargetSiteTmp, StackTraceTmp,
                                    AppEx.HResult.ToString(), AppEx.HelpLink, exceptInfo);
        }
    }



    //[Serializable]
    //public class AppException : Exception
    //{



    //    public AppException(string message): base(message)
    //    {

    //    }

    //    protected AppException(SerializationInfo info, StreamingContext ctxt) : base(info, ctxt)
    //    {

    //    }

    //}

}