using System;
using System.Diagnostics;

namespace qs2.core.Exceptions
{
    public class ExceptionHand

    {
 
        public static string GetStackTraceForException(Exception e)
        {
            StackTrace trace = new StackTrace(e);
            string stackFcts = "";
            foreach (StackFrame frame in trace.GetFrames())
            {
                stackFcts = (frame != null ? frame.GetMethod().Name : "") + (stackFcts == "" ? "" : "." + stackFcts);
            }
            return "Exception in Function " + stackFcts + "\r\n\r\n" + e.ToString();
        }

    }

}

