using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.GUI.PMDSClient
{

    public class PMDSClientWrapper
    {


        public static void doExcept(Exception e, string sType = "Exception", bool ShowMsgBox = true, bool checkOutOfMemory = true)
        {
            ENV.HandleException(e, sType, ShowMsgBox, checkOutOfMemory);
        }

        public static Icon getIcon(Enum icon, int width, int height)
        {
          return QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
        }
    }

}
