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
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Dokument");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Storniert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das Dokument wurde erfolgreich nach ELGA übertragen!", "", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                throw new Exception("TestUnitsHL.newRessources: " + ex.ToString());
            }
        }


    }

}

