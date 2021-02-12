using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PMDS.Global.db.ERSystem
{


    public class TestUnitsOS
    {
        public void newRessources()
        {
            try
            {

                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("DemoTxt!", "", MessageBoxButtons.OK);
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("DemoTxt: ");
                //2019

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Ändern (von-Datum) nicht erlaubt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Ändern (bis-Datum) nicht erlaubt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Anordnen (von-Datum) nicht erlaubt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren beim Anordnen (von-Datum) nur bis {0} erlaubt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von-Datum darf nicht leer sein.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis-Datum darf nicht leer sein.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("n.A.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR / Palliativ Anmerkung: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Restliche Sperrzeit: eine Minute.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Restliche Sperrzeit: {0} Minuten.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sperrzeit ist abgelaufen!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("HAG-Pflichtig");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Herrichten: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verabreichung: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Nr: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Nr leer weil : ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Krankenkasse: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Status: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Mitversichert bei: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzvers.: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klasse: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pol.Nr.: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("bPK: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA abgemeldet: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS-Passwort ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort ändern");

            }
            catch (Exception ex)
            {
                throw new Exception("TestUnitsOS.newRessources: " + ex.ToString());
            }
        }

    }

}

