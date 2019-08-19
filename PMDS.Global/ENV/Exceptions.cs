using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WCFServicePMDS
{

    class Exceptions
    {

        public static void checkFault(List<Task> tasks)
        {
            foreach (Task t in tasks)
            {
                if (t.Status == TaskStatus.Faulted)
                {
                    foreach (var e in t.Exception.InnerExceptions)
                    {
                        throw e;
                    }
                }
            }

        }

    }
}
