using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.Global.db.ERSystem
{

    public class TestUnitsHL
    {

        public void newRessources()
        {
            try
            {

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung-Storno für Patient {0} von Benutzer {1} durchgeführt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung Storno");

                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("DemoTxt!", "", MessageBoxButtons.OK);


            }
            catch (Exception ex)
            {
                throw new Exception("TestUnitsHL.newRessources: " + ex.ToString());
            }
        }


    }

}

