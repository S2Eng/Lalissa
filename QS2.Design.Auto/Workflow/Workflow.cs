using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace qs2.design.auto.workflow
{

    public class retWorkflowObject
    {
        public string result = "";

    }

    public class Workflow
    {


        public static event doInterfaceWorkflow evDoInterfaceWorkflow;
        public delegate retWorkflowObject doInterfaceWorkflow(eTypActionObject TypActionObject, qs2.core.vb.dsObjects dsObjects, qs2.core.vb.dsWorkflow dsWorkflow);

        private static qs2.core.vb.dsObjects dsObjects;
        private static qs2.core.vb.dsWorkflow dsWorkflow;


        public enum eTypUserAction
        {
            PatSaveClicked = 0
        }


        public enum eTypActionObject
        {
            NewObjectFromInterface = 0,
            NewStayFromInterface = 1
        }



        public static void registerDelegate(doInterfaceWorkflow doInterfaceWorkflow)
        {
            try
            {
                evDoInterfaceWorkflow += doInterfaceWorkflow;
            }
            catch (Exception ex)
            {
                throw new Exception("Workflow.registerDelegate:" + qs2.core.generic.lineBreak + qs2.core.generic.lineBreak + ex.ToString());
            }
        }

    }
}
