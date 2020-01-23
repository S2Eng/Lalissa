using Microsoft.VisualBasic;
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
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Patienten wurde noch keine ELGA-Kontaktbestätigung durchgeführt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Daten gefunden!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Kontakt wurde storniert!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das situative Opt-Out wurde durchgeführt!", "", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wcf-Service initialisieren fehlgeschlagen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wcf-Service per Thread initialisieren fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wcf-Client-Objekt erstellen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Stammdaten vom Wcf-Service abholen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Exception per Wcf-Service versenden fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Login ELGA fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Logout ELGA fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suche Patienten in ELGA fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient in ELGA einfügen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient in ELGA updaten fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientenkontakt in ELGA hinzufügen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientenkontakt in ELGA deaktivieren fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientenkontakt aus ELGA löschen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientenkontakte aus ELGA abfragen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suche GDA in ELGA fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suche Dokumente in ELGA fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokumentinhalt aus ELGA abholen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument in ELGA ablegen fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument in ELGA stornieren fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("CDA-Dokument generieren fehlgeschlagen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokales WCF-Service beenden fehlgeschlagen!");




            }
            catch (Exception ex)
            {
                throw new Exception("TestUnitsHL.newRessources: " + ex.ToString());
            }
        }


    }

}

