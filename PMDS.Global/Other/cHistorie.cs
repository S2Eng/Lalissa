using System;
using System.Collections.Generic;
using System.Text;

namespace PMDS.Global
{
    public class historie
    {
        public static bool HistorieOn = false;
        private  static System.Guid _IDAufenthalt;


        public System.Guid  IDAufenthalt
        {
            get
            {
                return PMDS.Global.historie._IDAufenthalt;
            }
            set
            {
                PMDS.Global.historie._IDAufenthalt  = value;
            }
        }

    }

}
