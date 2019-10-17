using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMDS.Global.db.ERSystem
{


    public class TestUnits
    {



        public void start()
        {
            try
            {
                return;
                //if (!Environment.MachineName.Trim().ToLower().Equals(("STYHL").Trim().ToLower()))
                //{
                //    return;
                //}


                //this.testFcts();
                //this.testTranslations();
                //this.testMsgBoxes();
                //this.newRessources2017();
                //this.newRessources2018();
                //this.newRessources2019();

                //PMDS.DB.PMDSBusiness b = new PMDS.DB.PMDSBusiness();
                //string sPfadArchiv = b.getPfadArchiv();

            }
            catch (Exception ex)
            {
                throw new Exception("start: " + ex.ToString());
            }
        }

        public void testFcts()
        {
            try
            {



            }
            catch (Exception ex)
            {
                throw new Exception("testFcts: " + ex.ToString());
            }
        }


        public void newRessources2018()
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bilder können erst nach dem Speichern des Wundverlaufs hinzugefügt werden.", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Entlassungszeitpunkt darf nicht vor dem Aufnahmezeitpunkt liegen.", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei der Kontrolle der Berichtsparameter wurde ein möglicher Fehler erkannt.\n\r\n\rSofern Sie alle erforderlichen Berichtsparameter vollständig ausgefüllt haben, notieren Sie sich den Bericht, den Sie öffnen wollten und kontaktieren Sie S2-Engineering GmbH unter 07252 / 22080.\n\rAndernfalls füllen Sie bitte alle erforderlichen Parameter aus und versuchen Sie es noch einmal.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der erforderliche Berichtsparameter '{0}' hat einen ungültigen Wert!\n\rBitte geben Sie einen gültigen Wert ein.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Abgabe darf nicht mehr als 24 Stunden vor dem geplanten Zeitpunkt gemeldet werden!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie dürfen nicht mehr als 500 Abgaben auf einmal markieren!", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient kann nicht auf Abwesend gesetzt werden, da er bereits abwesend ist!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abwesenheit des Klienten kann nicht beendet werden, da die Abwesenheit bereits beendet wurde!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurden editiert.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorgeschlagen von: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Angeordnet am: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Angeordnet von: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Debridement: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Reinigung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundauflage: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrandschutz: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sekundärverband: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fixierung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("VW-Intervall: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hyperkeratoseentfernung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hautpflege: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzernährung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kompression: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Freillagerung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundabstrich: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abgesetzt am: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abgesetzt von: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert am: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidiert von: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde wurde editiert.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} hinzugefügt");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie vom {0} vidiert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Angeordnet am: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erhebungszeitpunkt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Stadium: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Schmerzqualität: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Schmerzintensität: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("nekrotisch?: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundzustand: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundheilungsphase: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundgrund: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Länge (cm): ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Breite (cm): ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Tiefe (cm): ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreger: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Infektionszeichen: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fisteln / Taschen: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundbelag: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Freiliegende Strukturen: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundexudat Farbe: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundexudat Menge: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundgeruch: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand intakt?: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand mazeriert: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand unterminiert / zerklüftet / glatt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand gerötet: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand Hyperkeratose: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundrand ödemös / wulstig: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung intakt?: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung trocken / pergamentartig: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung Ekzem / Ödem / Rötung: ");            
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung Spannungsblase: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundumgebung sonstiges: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Granulation %: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Epithelisierung %: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Heilungsverlauf: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonstiges: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundverlauf vom {0} hinzugefügt");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundverlauf vom {0} geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Wunde wurde erfasst.");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ziel wurde nicht geändert!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" und ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Eval.Status: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einmalige Anforderung zur Verordnung hinzufügen");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig bis: Eingabe erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab muss gleich Gültig bis sein!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Daten richtig ausfüllen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum nächster Anspruch muss angegeben werden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Verordnungen können nicht gelöscht werden da kein Recht vorhanden!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wunde vorher speichern!", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Beziehungen zu den gewählten Zeilen gefunden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sätze trotzdem löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren folgende Bestelldaten zu der Verordnung:");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren folgende Bestellpositionen zu den Bestelldaten:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellpositionen zu Bestelldaten:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" (Achtung: Kein Kostenträger zugeordnet!)");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die Wundbeschreibung!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Speichern Sie bitte vorher die PDx!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Threads Ready!", "");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dem Klienten {0} wurde am {1} das Medikament {2} bereits verabreicht! \r\n Das Medikament wird daher nicht verabreicht!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll Medikamente verabreichen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("FIBU: Eingabe erforderlich!", "", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.getRes("für Patient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("gefunden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("SR Rechnung von");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Warnung für Rechnungsstorno");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende bereits stornierte Rechnungen können nicht erneut storniert werden:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Stornodatum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rechnungs-Datum: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beilage von");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Prüfung bestehende freigegebene Rechnungen auf Storno bzw. Korrektur Beilagen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Klienten existieren bereits freigegeben Rechnungen bzw. Beilagen" + "\r\n" + "Sollen diese storniert bzw. korrigiert werden?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Zeilen wirklich rollen?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Sperre für Stornorechnungen und Rollung wirklich aufheben?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sperre Storno und Rollung aufheben!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sperre Storno und Rollung aufheben");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("kein Kostenträger zugeordnet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für {0} Leistung/en wurde kein Zahler gefunden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinische Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Anamnese ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese vom {0} als Vorlage für neue Anamnese verwendet.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste leeren");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} kann nicht gelöscht werden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Löschen Termine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Termine können nicht gelöscht werden da keine Berechtigung:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin {0} wurde gelöscht!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine löschen");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ex existieren offene Termine für den Klienten!" + "\r\n" +
                                                                "Sollen diese beendet werden?", "Klient ist aktiver Bewerber", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei dem Termin handelt es sich um einen Serientermin!" + "\r\n" +
                                                                            "Sollen die Änderungen auf alle zukünftigen offenen Termine des Serientermines übernommen werden?", "", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei dem Termin handelt es sich um einen Serientermin!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen die Änderungen auf alle zukünftigen Termine des Serientermines übernommen werden?");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Serientermin wurde beendet!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen die Termine aller Beteiligten dieses Serientermines beendet werden?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Status des Serientermines wurde geändert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen der Status für alle Beteiligten dieses Serientermines übernommen werden?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden Serientermine zum Löschen ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen bei Serienterminen alle Termine gelöscht werden?");


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete medizinsche Daten zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Wunden zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu medizinschen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu medizinischen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu Wunden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinsche Daten zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zu medizinschen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zu Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu medizinischen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu Wunde");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete medizinsche Daten zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Wunden zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu medizinschen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zu Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu medizinischen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu Wunden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinsche Daten zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zu medizinschen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zu Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu medizinischen Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu Wunde");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu Klient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu Klient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zu medizinische Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zu medizinische Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwaltung Verordnungen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Medikamente zur Verordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete medizinischen Daten zur Verordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Wunden zur Verordnung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zur Verordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung medizinische Daten zur Verordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Wunden zur Verordnung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Medikamente zur Wunde");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste zugeordnete Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zuordnung Verordnungen zur Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe erforderlich!");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zusatzwerte richtig ausfüllen!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung Maßnahme Zusatzwerte");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung Zusatzwerte Dekurs");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung ungeplante Maßnahme Zusatzwerte");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste Berufsgruppen aller Kopien:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Info Kopien");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassungszeitpunkt: ");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für Klienten ohne aktuellen Aufenthalt ist diese Funktion nicht möglich. Bitte legen Sie einen Kostenträger an und ordnen Sie den Klienten zu.", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lager Seriennummer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lager Zustand: Eingabe erforderlich!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Vidieren wurde durchgeführt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Recht für Vidierung!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidierung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidierung durchgeführt!");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wundtherapie ist bereits vidiert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vidierung durchgeführt für Therapie {0} vom {1}");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert im Archiv kein Ordner {0}. " + "Bitte erstellen Sie den Ordner zum Ablegen ins Archiv!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Pflegebegleitschreiben wurde ins Archiv abgelegt!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegebegleitschreiben für");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ins Archiv ablegen");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger wurden erfogreich geprüft!", "Kostenträger prüfen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger prüfen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("FIBU {0} für Kostenträger {1} kommt in Datenbank mehrfach vor");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("FIBU kommt auch vor in Kostenträger {0}");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Vidierung ist nicht aktiviert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine FIBU-Angabe für Kostenträger {0} vorhanden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundart: nicht definiert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierung: nicht definiert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierungsseite: nicht definiert");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis: Nicht abgesetzte Therapie");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis: Die Wundbeschreibung wurde in der Zwischenzeit durch einen anderen Benutzer geändert:\n\r{0}");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Skala: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wert: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bekannt seit: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde entstanden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bisherige Behandlung: ");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Daten werden im Log-Verzeichnis protokolliert", "HAG Protokoll-Verzeichnis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Applikationsform: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie wirklich alle nicht verwendeten Medikamente löschen?", "PMDS", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Medikamente wurden gelöscht!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient ist rezeptgebührenbefreit");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wegen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befristet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("bis");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rego");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ab");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Unbefristet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sachwalter");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Patienten und alle seine Aufenthalte wirklich löschen?", "PMDS", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ID-Patient");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die eingegebene ID-Patient ist falsch!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Patientendaten als PDF gesichert werden?", "PMDS", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Patient wurde erfogreich gelöscht!", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient und Aufenthalte löschen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient {0} wurde gelöscht");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Patient kann nicht gelöscht werden, da der letzte Entlassungszeitpunkt weniger als 10 Jahre zurückliegt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Entlassungsdatum");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abbruch Patient löschen!" + "\r\n" + "Klientenbereicht konnte nicht erfogreich erstellt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das generierte PDF-Dokument mit den Patientendaten öffnen?", "PMDS", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("keines");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Patient wurde erfolgreich gelöscht!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Achtung: Das letzte Entlassungsdatum des Patienten liegt weniger als 10 Jahre zurück!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten mit aktuellem Aufenthalt können nicht gelöscht werden.Bitte beenden Sie den ausgewählten Aufenthalt.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} geöffnet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bericht {0} wurde von Benutzer {1} geöffnet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Parameter");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Nachricht eingegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Benutzer ausgewählt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sender");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Meldung ausgewählt!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Nachricht existiert nicht mehr!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Absender");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Empfänger");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachrichten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungelesene Nachrichten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} von {1} Empfängern haben die Nachricht gelesen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Druck Nachricht");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Absender");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erstellt am");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Betreff");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gesendet an:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachricht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Druck Nachricht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Druck Nachricht");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde bereits mindestens eine Rechnung freigegeben. Die Vorschau kann nicht gelöscht werden!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, die Datei hier zu speichern", "Speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Medikament ausgewählt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rezeptgebührenbefreit");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheit beendet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Holocaust");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheit nicht beendet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitend bestätigen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient ist abwesend");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rezeptgebührenbefreiung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtstag");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Palliativ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfälle");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgebevollmächtiger");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter");


            }

            catch (Exception ex)
            {
                throw new Exception("newRessources2018: " + ex.ToString());
            }
        }
        public void newRessources2019()
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Neuer med. Typ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Belange");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ab");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Leistungskatalog '{0}' kann nicht gelöscht werden, da er von folgenden Klienten verwendet wird:");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("PLZ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Strasse: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("FIBU existiert bereits!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Leistung {0} für Klient {1} im Monat {2} kann nicht vollständig verrechnet werden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler bei der Abrechnung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde nicht erfolgreich abgerechnet!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Details siehe Protokoll.");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehler beim Befundimport. Kein Berufsgruppen-Eintrag in Auswahlliste BefundimportTermin gefunden! Kann keinen Termin erstellen. Befund wurde trotzdem im Archiv abgelegt.");


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament absetzen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament {0} wurde abgesetzt und scheint daher ab {1} nicht mehr in der Medikamentenbestellung auf!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS Info");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Falsche Eingabe!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorschau");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Freigegeben");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es können max. ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen ausgewählt werden.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Standardprozedur offen");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Schnellrückmeldung ist bereits geöffnet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Schnellrückmeldung ist bereits geöffnet!");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dem angemeldeten Benutzer wurde keine Klinik zugeordnet! " + "\r\n" + "PMDS wird beendet.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Breite");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Höhe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wichtige Informationen: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Übernehmer");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("WCF-Service für Version '" + PMDS.Global.ENV.VersionNr.ToString() + "' ist nicht installiert!" + "\r\n" +
                                                                            "Bitte Administrator kontaktieren." + "\r\n" +
                                                                            "PMDS wird beendet!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Versions-Nr");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag darf nicht gelöscht werden.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag wurde vor mehr als eine Stunde angelegt: {0}.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag wurde bereits auf einer Blisterliste angedruckt: Zuletzt am {0}.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Medikament wurde bereits bestellt. Zuletzt am {0}.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Medikament wurde schon {0} mal als Einzelabgabe gemeldet.");
            
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte kontrollieren sie das Datum, ab dem die Änderung gelten soll!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag ist auf einer Blisterliste vom {0} enthalten.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dieser Rezepteintrag wurde zuletzt am {0} bestellt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden bereits {0} Einzel-Verabreichungen gemeldet.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte beachten Sie, dass Sie bei einer rückwirkenden Änderung des Datums die Datenkontinuität zerstören werden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie das Datum {0} trotzdem beibehalten?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wird nicht empfohlen, Daten rückwirkend zu verändern!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es gibt bereits eine freigegebene Rechnung vom {0}. Das Datum dieser Rechnung muss daher auf {1} gesetzt werden.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Soll das durchgeführt werden?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Stornodatum darf nicht kleiner als das größte Rechnungsdatum ({0}) sein!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Dokument wurde gespeichert!", MessageBoxButtons.OK, "");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist nicht mehr in der Liste der aktuellen Klienten!");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Im Pfad {0} besteht kein Schreibrecht! Bitte dem Administrator melden!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pfade"), true);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte prüfen Sie die Zeitpunkte der Interventionen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Feher bei der Planung");


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV Mitversichert bei: Feld darf nicht leer sein!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV-Nr. muss 10-stellig oder leer sein!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("SV-Nr.: Die letzten 6 Stellen müssen das Geburtsdatum im Format TTMMJJ sein!", "Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden ELGA-Felder geändert. Dies kann Auswirkungen auf die Datenübergabe an ELGA haben!" + "\r\n" + 
                                                                            "Wollen Sie die Daten trotzdem speichern?", "Speichern", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kontaktart: Angabe erforderlich!", "Speichern", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktart: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwandtschaft: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vertrauensperson: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Externer Dienstleister: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Strasse: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Plz: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ort: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Land: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Telefon: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Mobil: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fax: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("E-Mail: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Andere: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ansprechpartner: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz1: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz2: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatz3: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Berufsst.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA Author speciality");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verwand.-verhältnis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Akad. Grad");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktart");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Land");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA Author speciality");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Berufsst.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geschlecht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anrede");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Akad.Grad");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fam.Stand");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsbg.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfession");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Augenfarbe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Haarfarbe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Statur");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Falsche Eingabe!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Status");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("SV-Nr leer weil");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klasse");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Krankenkasse");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("[Kein Name]");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Land");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Land Hauptwohnsitz");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Berechtigung zum Abzeichnen für folgende Berufsgruppen:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine!");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Einrichtung: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben kein Recht, dieses Feld zu bearbeiten.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wundart");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den DNR-Status wirklich ändern?", "ACHTUNG!", MessageBoxButtons.YesNoCancel);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Palliativ-Status wirklich ändern?", "ACHTUNG!", MessageBoxButtons.YesNoCancel);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Applikationsform");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Packungseinheit");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einheit");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Darreichungsformform");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fachrichtung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA_AuthorSpeciality");

                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wenn Sie diesen Eintrag löschen, werden alle bisher erfassten Zusatzwerte unwiederbringlich gelöscht.\r\nSind Sie Sicher, dass Sie das möchten?", "ACHTUNG!", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel nachgestellt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereichsspez. Personenkennz.: ");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Patienten existiert bereits ein ELGA-Hausarzt!" + "\r\n" +
                                                                                "Soll dieser als Hausarzt gespeichert werden und der neue Arzt als ELGA-Hausarzt gespeichert werden?", "", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Patienten wurden mehr als ein ELGA-Hausarzt angegeben!" + "\r\n" +
                                                            "", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("STORNIERT");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikation");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bei Storno ist eine Anmerkung erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Applikationsform: Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückdatieren nicht erlaubt. Bitte beenden Sie die Anordnung und legen Sie eine neue an.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament: Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bei Storno ist eine Anmerkung erforderlich!", "", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Benutzer: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Die beiden Passwort-Eingaben sind nicht gleich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Für das Passwort sind mindestens 5 Zeichen erforderlich!", "", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Altes Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Altes Passwort ist falsch!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Das neue Passwort muss mindestens 5 Zeichen lang sein!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort Wiederholung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neues ELGA-Passwort: Die beiden Passwort-Eingaben stimmen nicht überein!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ELGA-Passwort: Altes und neues Passwort sind zu ähnlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Für den Benutzer kann kein Passwort erfasst werden, da die Anmeldung des Benutzers in ELGA automatisch erfolgt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Benutzereinstellungen wurden geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Passwort wurde geändert");


                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Rechte wurde geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Sitzung aktiv");


                DialogResult res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Derzeit ist eine ELGA-Sitzung aktiv." + "\r\n" +
                                                                                            "Wollen Sie sich von der ELGA-Sitzung wirklich abmelden?", "ELGA", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die ELGA-Sitzung läuft in {0} Minuten ab." + "\r\n" +
                                                                        "Soll die ELGA-Sitzung automatisch verlängert werden?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("ELGA-Sitzung - keine Verlängerung mehr möglich");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anzahl Medikamente deaktiviert: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensätze verarbeitet.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensätze werden deaktiviert.");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soz.Vers.Nr: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientensuche");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patientensuche nach Soz.Vers.Nr '{0}' durchgeführt");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Storno Kontaktbestätigung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung für Patient {0} von Benutzer {1} durchgeführt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("SOO für Patient {0} von Benutzer {1} durchgeführt.");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es ist keine ELGA-Sitzung aktiv" + "\r\n" +
                                                                            "Aktion kann nicht ausgeführt werden.", "ELGA", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient wurde über seine Rechte belehrt: Bestätigung erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Patient stimmt dem situativem Opt-Out zu: Bestätigung erforderlich!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontaktbestätigung hergestellt!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soz.Vers.Nr: Mind. 2 Zeichen Eingabe erforderlich!", "", MessageBoxButtons.OK);






            }
            catch (Exception ex)
            {
                throw new Exception("newRessources2019: " + ex.ToString());
            }
        }









        public void newRessources2017()
        {
            try
            {
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sind Sie sicher, dass Sie das Bild löschen wollen?", "PMDS", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patient: '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' - Bild wurde geändert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten-Stammdaten Änderung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' - Bild wurde gelöscht!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beachtlich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verbindlich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anmerkung");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Am: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer Password: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Übernehmer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Schlüsselübergabe wurde gespeichert!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Heimvertrag");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Patient ausgewählt!", "", System.Windows.Forms.MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt hinzugefügt für Patient {0}");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt geändert für Patient {0}");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kontakt gelöscht für Patient {0}");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                
                int iCounterUpdatedPatient = 0;
                int iCounterUpdatedPE = 0;
                string sTitle = QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten und PE - Abteilungen und Bereiche prüfen und updaten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Patienten und PE - Abteilungen und Bereiche prüfen");
                string sTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen die Aktivität wirklich durchgeführt werden?");
                string sMsg = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Patienten und {1} PE upgedated!");
                sMsg = string.Format(sMsg, iCounterUpdatedPatient.ToString(), iCounterUpdatedPE.ToString());
                sMsg = QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Patienten und {1} PE geprüft!");
                sMsg = string.Format(sMsg, iCounterUpdatedPatient.ToString(), iCounterUpdatedPE.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsg, sTitle, true);
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Liste");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Dekurs-Entwurf ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Patient ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Dekurs-Entwurf wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Dekurs-Entwurf wirklich löschen?", "", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dekurs wurde nicht geändert!" + "\r\n" + "(Es wurde nichts gespeichert)", "Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Warnung Speicherverbrauch");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auf Ihrem Windows-Rechner steht zu wenig RAM zur Verfügung!" + "\r\n" +
                                                                            "Bitte starten Sie in den nächsten Minunten PMDS neu um das Problem zu beheben.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es sind noch Dekurs-Entwürfe offen!" + "\r\n" +
                                                                "Wollen Sie PMDS trotzdem beenden?", "Hinweis", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Bitte geben Sie Details für die Rezeptgebührenbefreiung an!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab Datum darf nicht grösser sein als Rego bis Datum!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab Datum muss angegeben werden!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego bis Datum muss angegeben werden!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab Datum und Rego bis Datum müssen angegeben werden!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' - Rezeptgebührenbefreiung abgelaufen!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet bis Datum muss angegeben werden!", "Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wochentage: Angabe erforderlich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lokalisierung: Angabe erforderlich");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab Datum muss angegeben werden!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet bis Datum muss angegeben werden!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab Datum darf nicht grösser sein als Befristet bis Datum!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet bis Datum muss angegeben werden!", "Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Hinweis: Bitte geben Sie Details für die Rezeptgebührenbefreiung an!", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es muss genau ein Grund für die Rezeptgebührenbefreiung angegeben werden.", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab und Rego bis müssen angegeben werden.", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rego ab darf nicht größer als Rego bis sein.", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab und befristet bis müssen angegeben werden.", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet ab darf nicht grösser als befristet bis sein.", "Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Grund für Rezeptgebührenbefreiung muss angeführt werden.", "Speichern");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Änderung wurde gespeichert", "Speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Benutzer ausgewählt.", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rückdatieren nicht erlaubt. Bitte beenden Sie die Anordnung und legen Sie eine neue an.", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgeimpfung am");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zum Notfall");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zur Standardprozedur");


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der max. Speicherverbrauch für PMDS wurde überschritten! (32 Bit Version)" + "\r\n" +
                                                                                         "PMDS muss neu gestartet werden!" + "\r\n" + "\r\n" +
                                                                                         "Bitte klicken Sie OK um PMDS zu beenden und starten Sie die Anwendung anschließend neu!", "PMDS", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("ID des gewählten Dokuments nicht gefunden!");

                DialogResult resHAG = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es existieren offenen HAG Meldungen für diesen Klienten. Möchten Sie diese beenden?", "", MessageBoxButtons.YesNo);



                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Patienten werden zusätzlich aufgrund der Mehrfachauswahl Dekurs-Entwürfe erstellt:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie diese Dekurse-Entwürfe wirklich erstellen?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Patienten werden zusätzlich aufgrund der Mehrfachauswahl Dekurse erstellt:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie diese Dekurse wirklich erstellen?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten Mehrfachauswahl");
                string sMsgBoxTxt = QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Eingabekriterien wurden für den Dekurstext nicht erfüllt:");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!", "", MessageBoxButtons.OK);
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Planung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Empfangene E-Mails");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gesendete E-Mails");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entwürfe");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kliententermine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Meine Termine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle Termine");


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Listenansicht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Monatsansicht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wochenansicht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Tagesansicht");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kategorie wählen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("vom");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Datensatz wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten wurden gesichert!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formularname existiert bereits!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formularname: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Eingabe erforderlich!", "", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sprache für Klient wurde geändert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende wurde zurückgesetzt!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende für");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("wurde bestätigt");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("auf");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sprache für Klient wurde geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sprache");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' -> Bild wurde gelöscht!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' -> Bild wurde geändert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenschutz für Klient aktiviert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenschutz: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("erstellt von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anmerkung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung: Eingabe erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: Eingabe erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund: Eingabe erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie: Eingabe erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Typ: Eingabe erforderlich!");
                
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Logischer Fehler!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten wurden  gespeichert!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Formular existiert nicht mehr!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Palliativ: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment wurde editiert.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medizinische Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dosierung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medizinischer Typ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Das Medikament wurde abgesetzt!" + "\r\n" +  "Wollen Sie die medizinischen Daten auch absetzen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die medizinischen Daten wurden abgesetzt!" + "\r\n" + "Wollen Sie das Medikament auch absetzen?", "", MessageBoxButtons.YesNo);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Med.Typ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beschreibung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Therapie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beendigungsgrund");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bezeichnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dosierung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Signatur");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Palliativ ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR    Palliativ ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Amputation: ");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Amputation muss zwischen 0 und 60 Prozent liegen!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Datensatz ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamente aktualisieren!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Suchtext: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment wurde editiert");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Funktion noch nicht fertig! (In Entwicklung)", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnungen");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Medikament ausgewählt!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Verordnet ab: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Verordnet bis: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Eingabe erforderlich!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Planungseintrag nicht gespeichert oder nicht vorhanden!" + "\r\n" +
                                                                        "Bitte vorher speichern!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Zeilen ausgewählt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("n-ten des Monats: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wochentage: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wert wiederholen alle n Tage/Wochen/Monate: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wochentage: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Serientermin endet am muss grösser sein als Gültig ab!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dauerbestellung endet am: Eingabe erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig bis: Eingabe erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Gültig ab: Eingabe erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Medikament ausgewählt!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestelldaten zur Verordnung hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Verordnung ausgewählt!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich speichern?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Bestellvorschläge wirklich speichern?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die gespeicherten Bestellvorschläge drucken?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lieferung erfassen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellvorschlag Detail");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datumn Lieferung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datumn Bestellung: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Menge Lieferung: Eingabe erforderlich!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ab");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Falsche Eingabe!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lieferant: Falsche Eingabe!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es konnte kein Datum für den nächsten Anspruch berechnet werden!" + "\r\n" +
                                                           "Bitte korrigieren Sie entspr. die Eingaben.", "", MessageBoxButtons.OK);

                string sTxtmsgBox = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestelldaten wurden gespeichert!") + "\r\n";
                sTxtmsgBox += QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächster Anspruch");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Status: Falsche Eingabe!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Typ: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie für die ausgewählten Bestellungen die Lieferungen wirklich bestätigen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellungen wurden gespeichert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Lieferungen wurden gespeichert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren für dieses Medikament und den Klienten '{0}' mehr als eine Bestellvorschrift in diesem Zeitraum!" + "\r\n" + "\r\n" +
                                                                                                                    "Wollen Sie die Bestellvorschrift trotzdem speichern?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum nächster Anspruch");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnet ab");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verordnet bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig ab");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gültig bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Reportdatei '{0}' wurde nicht gefunden!" + "\r\n" + "Es kann kein Druck durchgeführt werden!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Lieferant: Eingabe erforderlich!", "", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Med.Daten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Von");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Massnahmen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Massnahmen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Massnahmen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenschutz aktiviert und Foto ist bereits vorhanden.\n\rSoll das Foto gelöscht werden?");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datenschutz aktiviert und Foto ist bereits vorhanden.\n\rSoll das Foto gelöscht werden?", "Hinweis", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Foto wurde wegen Datenschutz gelöscht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Foto wurde trotz Frage nicht gelöscht");

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datenschutz ist aktiviert. Sie dürfen kein Foto hinzufügen.", "Hinweis", MessageBoxButtons.OK);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuen Lizenzstring in die Datenbank schreiben?", "Sind Sie sicher?", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuer Lizenzstring wurde in die Datenbank geschrieben", "Hinweis", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Neuer Lizenzstring wurde NICHT in die Datenbank geschrieben", "Hinweis", MessageBoxButtons.OK);

            }

            catch (Exception ex)
            {
                throw new Exception("newRessources2017: " + ex.ToString());
            }
        }



        public void testMsgBoxes()
        {
            try
            {
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("", true);
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("", "", MessageBoxButtons.OK);
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox("", "", false);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Klienten ausgewählt!", "Auswahl");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Spalte ausgewählt!", "Spalte kopieren");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Abrechnungsmonat ausgewählt!", "Abrechnen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Rechnungsdatum ausgewählt!", "Abrechnen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klienten ausgewählt!", "Abrechnung starten");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abrechnung ausgewählt!", "Auswahl Abrechnung");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Auswahl erforderlich!", "Auswahl Suche", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Auswahl erforderlich", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("No entry selected!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Diese Version ist abgelaufen,\r\nbitte setzten Sie sich mit ihrem lokalen Administrator in Verbindung");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist keinem Bereich zugeordnet. Planung wird durchgeführt, aber es wird kein Protokoll geschrieben! \n\r" +
                                                                        "Bitte ordnen Sie so rasch wie möglich einen Bereich zu.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Archivpfad fürs Archivsystem angegeben", "Import Befunde", System.Windows.Forms.MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Diese Version ist abgelaufen,\r\nbitte setzten Sie sich mit ihrem lokalen Administrator in Verbindung");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Konfigurationsdatei wurde aktualisiert.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Befundverzeichnis angegeben!", "Befundverzeichnis öffnen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Eingabe ist erforderlich!", "Eingabe");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Eingabe ist erforderlich!", "Eingabe");
                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie sich wirklich abmelden und eine neue Sitzung von PMDS starten?", "Abmelden", System.Windows.Forms.MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("System-Check: All OK!", "System-Check");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Remoteunterstützung kann nicht gestartet werden.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Remoteunterstützung kann nicht gestartet werden.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bild kann leider nicht als Icon benutzt werden - bitte wählen Sie ein anderes Bild!");
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Bild wirklich löschen ?", "Bild löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeitbereiche wurden gespeichert!", "Zeitbereiche", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeitbereichserien wurden gespeichert!", "Zeitbereichserien", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte einen Benutzer auswählen", "Benutzer wählen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Kennwort", "Falsches Kennwort", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Benutzer verfügt nicht über das notwendige Recht um Massnahmen zu melden", "Ungenügende Rechte", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Ungeplante Maßnahme auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Medikament auswählen", "Fehlende Eingabe", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beschreibung fehlt", "Fehlende Eingabe", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Todeszeitpunkt: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Todeszeitpunkt darf nicht in der zukunft liegen!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde keine Klinik ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Aufnahmezeitpunkt: Eingabe erforderlich!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Aufnahmezeitpunkt liegt vor Entlassungszeitpunkt!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es darf nur einen aktuellen Aufenthalt (kein Entlassungszeitpunkt) geben!", "Aufenhalt speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Bild ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zeile(n) löschen ?", "Löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungstext: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Betrag: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungsdatum: Eingabe erforderlich!", "Buchungen speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde nichts ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Rechnung ausgewählt!", "Aktivität ausführen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!", "Sammelabrechnung starten");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Rechnungsänderung wurde in PMDS gesichert!", "Rechnung sichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Abrechnungsmonat ausgewählt!", "Abrechnen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Datum eingegeben!", "Jahresabschluß");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Jahresabschluss wirklich durchführen?", "Jahresabschluß", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!", "Eintrag löschen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!", "Beleg drucken", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Betrag darf nicht null sein!", "Betrag", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Buchungstext muß angegeben werden!", "Buchungstext", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kostenträger muß angegeben werden!", "Kostenträger", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die man. Buchung wirklich löschen?", "Buchung löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Buchung ausgewählt!", "Buchung löschen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Fehlerhafte Eingabe!", "Eingabe", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datum: Falsche Eingabe!", "Datum", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte ein gültiges Datum eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die gewählten Abwesenheiten ins Abrechnungssystem überspielen?", "Abwesenheiten überspielen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Abrechnungstabellen wirklich erstellen?" + "\r\n" +
                                                                            "(Hinweis: Bereits überspielte Abrechnungsdaten werden gelöscht!)", "Abrechnungstabellen erstellen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abrechnungstabellen wurden erfolgreich erstellt!", "Abrechnungstabellen erstellen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Abrechnungen wirklich überspielen?", "Abrechnungen überspielen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen das Überspielungsprotokoll öffnen?", "Abrechungen überspielen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen sie den/die Datensätz/e wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Abrechnungssystem wirklich beenden?", "PMDS Abrechnung", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung.: Eingabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Benutzer: Auswahl erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Dokument wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kein Dokument ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Anmeldedatum: Angabe erforderlich!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Benutzer ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Fortbildung für den Benutzer wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Fortbildung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Fortbildung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Fortbildung wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Veranstalter wirklich löschen?", "", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Veranstalter ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bezeichnung: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Dokumentenname: Es wurde kein Name angegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen sie den/die Datensätz/e wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen sie den/die Datensätz/e wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Bewerbungsdaten zurückgesetzt werden?", "Klient ist aktiver Bewerber", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (1)");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (2)");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (3)");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Falsches Login (4)");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Key Quick-Filter: Eingabe erforderlich!", "Eingabe erforderlich", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Layout wirklich löschen?", "Löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Quickfilter wirklich kopieren?", "Quickfilter kopieren", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Eintrag wirklich löschen?", "Eintrag löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Kurzbezeichnung: Es wurde kein Text eingegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Abwesend' geändert.", "Hinweis");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten wurde in der Zwischenzeit auf 'Anwesend' geändert.", "Hinweis");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der Status des Klienten kann nicht festgestellt werden. Bitte schließen Sie das Fenster und probieren Sie es nocheinmal", "Hinweis");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Benutzer wirklich löschen?", "Benutzer löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Einrichtung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Klinik wirklich löschen?", "Klink löschen",
                                                                                    MessageBoxButtons.YesNo,
                                                                                    MessageBoxIcon.Question);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Name: Eingabe erforderich!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben alle Einträge in 'Wichtig für' zurückgesetzt. Ihre Änderungen im Dekurs werden ebenfalls zurückgesetzt.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben alle Einträge in 'Wichtig für' zurückgesetzt. Ihre Änderungen im Dekurs werden ebenfalls zurückgesetzt.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Interventionen vorhanden", "Drucken", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Zu dieser Intervention ist kein Pflegestandard hinterlegt!", "Pflegestandard drucken");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Auswahl Termin");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Klienten ausgewählt!", "Auswahl");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Markierte Zeile ist kein Pflegeplan!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einträge ausgewählt!", "Schnellrückmeldung");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie diese Operation wirklich ausführen?", "'Nächstes-Datum' updaten für alle Interventionen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Einträge wirklich rückmelden?", "PDx rückmelden", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die ausgewählten Zeilen wirklich gegenzeichnen?", "Gegenzeichnen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeilen ausgewählt!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist bereits aufgenommen", "Klient bereits aufgenommen", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Rückmelden nicht möglich: Qualifikation nicht ausreichend, falscher Berufsstand oder kein Recht.");
                DialogResult res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu löschen!", "Termin löschen", MessageBoxButtons.OK);
                DialogResult res2 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abgezeichnete Termine können nicht gelöscht, sondern nur beendet werden!", "Termin löschen", MessageBoxButtons.OK);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Termin wirklich löschen?", "Termin löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin löschen");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin löschen");
                res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu ändern!", "Termin ändern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin editieren");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin");
                res3 = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Berechtigung, den Termin zu beenden!", "Termin beenden", MessageBoxButtons.OK);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie den Termin wirklich beenden?", "Termin beenden", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Termin ausgewählt!", "Termin editieren");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es ist kein Klient gewählt.\r\nBitte wählen Sie einen Klienten", "Klient nicht ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bereich: Es wurde kein Text angegeben!", "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Klinik ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Befristet bis: Datumseingabe erforderlich!", "Befristet bis", MessageBoxButtons.OK);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Änderungen in Medizinische Daten gespeichert werden?", "Medizinische Daten", MessageBoxButtons.OKCancel);
                DialogResult resDoppelterArzt = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der gewählte Arzt ist dem Bewohner bereits zugeordnet, wollen sie ihn trotzdem zuordnen ?",
                                                                                        "Dieser Arzt ist bereits zugeordnet",
                                                                                        MessageBoxButtons.YesNo,
                                                                                        MessageBoxIcon.Question);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Freiheitsbeschränkende Maßnahme bitte vor dem Senden speichern!", "Senden", MessageBoxButtons.OK);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die freiheitsbeschränkende Maßnahme wurde bereits einmal gesendet. Wollen Sie sie erneut senden?", "Hinweis", MessageBoxButtons.YesNo);
                res = (QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Daten für die freiheitsbeschränkende Maßnahme jetzt senden?", "Senden", MessageBoxButtons.YesNo));
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Daten für die freiheitsbeschränkende Maßnahme wurden erfolgreich versendet!", "Senden", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Maßnahme ausgewählt!", "Senden", MessageBoxButtons.OK);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Datensätze gelöscht werden?", "Datensätze löschen", MessageBoxButtons.YesNo);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Änderungen speichern?", "Speichern", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einrichtung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Einrichtung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abteilung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Abteilung ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Bereich ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Bereich ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sollen die Änderungen gespeichert werden??", "Speichern", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Satz ausgewählt.", "Klient zu Kostenträger zuordnen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Kostenträger ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine Zeilen ausgewählt.\r\nBitte markieren sie die zu löschenden Zeilen am linken Rand der Tabelle", "Keine Zeilen ausgewählt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resDoppelterArzt = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der gewählte Arzt ist dem Bewohner bereits zugeordnet, wollen sie ihn trotzdem zuordnen ?",
                                                                                        "Dieser Arzt ist bereits zugeordnet",
                                                                                        MessageBoxButtons.YesNo,
                                                                                        MessageBoxIcon.Question);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte geben Sie zu jedem erfaßten Zeitpunkt eine Dosierung bzw. zu jeder Dosierung einen Zeitpunkt an!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte geben Sie zu jeder erfaßten Dosierung einen Zeitpunkt bzw. zu jedem erfaßten Zeitpunkt eine Dosierung an!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keinen Eintrag ausgewählt!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die Medikamente wirklich neu importieren?", "Importieren", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Medikament: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Medikament: Auswahl erforderlich!", "PMDS", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie das Medikament wirklich löschen ?", "Medikament löschen", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Soll der Datensatz gelöscht werden?", "Datensatz löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Medikamente ausgewählt!", "Medikamente verabreichen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Die Vorbereitung wurde abgezeichnet", "Vorbereitung wurde abgezeichnet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie die markierten Bestellungen wirklich löschen?", "Bestellung Medikamente löschen", MessageBoxButtons.YesNo);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Bestellungen zum Löschen ausgewählt!", "Bestellung Medikamente löschen", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Medikamente zum Drucken ausgewählt!", "Medikamente Drucken", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Einrichtung: Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Abteilung: Auswahl erforderlich!");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Modell oder Gruppe ausfüllen.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Änderungen speichern");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keinen Bericht ausgewählt");
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Wollen Sie wirklich die ausgewählten ASZM Einträge löschen?", "ASZM löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Sie haben keine ASZM Einträge ausgewählt.", "Löschen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Medikamente ausgewählt!", "Bestellung Medikamente", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Einträge ausgewählt.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Bitte Änderungen in Zusatzwerte speichern.", "Speichern", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurden keine Einträge ausgewählt.");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Keine Zeile ausgewählt!");


                // ---------------------------------------- MsgBoxes with   ENV.String()-Call ------------------------------------------------------

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.PATIENT_URLAUB"), ENV.String("GUI.DIALOGTITLE_PATIENT_URLAUB"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEFORMULAR"), ENV.String("DIALOGTITLE_DELETEFORMULAR"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEFORMULAR"), ENV.String("DIALOGTITLE_DELETEFORMULAR"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
                
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_PATIENT_ALREADY_EXISTS"), true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSING_LICENCE"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);

                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), true);
                                
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_SAVECHANGES"), ENV.String("VERWALTUNG.DIALOGTITLE_SAVECHANGES"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);
              
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MAIN.ASK_FOR_CLOSE"),
                                                                                        ENV.String("MAIN.DIALOGTITLE_ASK_FOR_CLOSE"),
                                                                                        MessageBoxButtons.YesNo,
                                                                                        MessageBoxIcon.Question, true);

                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_ASZMAUSWAHL_ZUORDNEN"),
                                                                                        ENV.String("DIALOGTITLE_ASZMAUSWAHL_ZUORDNEN"),
                                                                                        MessageBoxButtons.YesNoCancel,
                                                                                        MessageBoxIcon.Question, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSINGFIELDS"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);

                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_PDXAUSWAHL_ZUORDNEN"),
                                                                                ENV.String("DIALOGTITLE_PDXAUSWAHL_ZUORDNEN"),
                                                                                MessageBoxButtons.YesNoCancel,
                                                                                MessageBoxIcon.Question, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_PDX_CODE_EXISTS"), true);

                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("PP_ORIGINAL_TEXT_CHANGED"),
                                                                                ENV.String("DIALOGTITLE_PP_ORIGINAL_TEXT_CHANGED"),
                                                                                MessageBoxButtons.YesNoCancel,
                                                                                MessageBoxIcon.Question, true);
                
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_SCHLIESSENMITAUSWAHL"), ENV.String("DIALOGTITLE_SCHLIESSENMITAUSWAHL"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("DIALOGTITLE_MISSINGPDXSELECTION"), ENV.String("DIALOGTITLE_MISSINGPDXSELECTION"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_NO_SELECTION"), ENV.String("MESSAGE_NO_SELECTION"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSING_ZEITPUNKT"), true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_SAVE_BEVORE_PRINT"), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("MESSAGE_CANNOT_DELETE_DEFAULT_EINTRAGZUSATZ"), ENV.String("MESSAGE_CANNOT_DELETE_DEFAULT_EINTRAGZUSATZ"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.NO_EVAL_WITH_ONCE"), true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("GUI.E_NO_TEXT"), ENV.String("DIALOGTITLE_INPUTERROR"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_TOP10_NAME_EXISTS", MessageBoxIcon.Warning), true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("REPORT.NO_DATA"),
                                                                                    ENV.String("REPORT.DIALOGTITLE_NO_DATA"),
                                                                                    MessageBoxButtons.OK,
                                                                                    MessageBoxIcon.Warning, true);
                string retSendUnterbringung1_ErrorTxt = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Beim Versenden der Daten für die freiheitsbeschränkende Maßnahme ist ein Fehler aufgetreten. Bitte kontaktieren Sie Ihren Administrator." + "\r\n\r\n" +
                                                                        "Fehlerbeschreibung:" + retSendUnterbringung1_ErrorTxt, "Senden", MessageBoxButtons.OK);

                string txt1 = "Es wurde kein Klient ausgewählt!";
                string txt2 = "Depotgeld";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt1, txt2, MessageBoxButtons.OK);


                // ---------------------------------------- MsgBoxes with Variables (112) ------------------------------------------------------
                string sMsgBoxTranslate = "";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, "".ToString(), "".ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "");
                

                int countRowsTotalCopied = 12;
                int countDbTotalCopied = 23;
                sMsgBoxTranslate = "{0} Abrechnungen wurden überspielt!" + "\r\n" +
                                            "({1} Zeilen insgesamt!)";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, countDbTotalCopied.ToString(), countRowsTotalCopied.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Abrechnungen überspielen", MessageBoxButtons.OK);
                

                string UsableScreen_Width = "";
                string UsableScreen_Height = "";
                sMsgBoxTranslate = "Die verfügbare Arbeitsfläche Ihres Bildschirms ({0} * {1}" +
                                        ") ist kleiner als die empfohlene Mindestauflösung (1200 * 737)\n\r" +
                                        "Bei einigen Funktionen wird die Anzeige nicht vollständig sein.";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, UsableScreen_Width.ToString(), UsableScreen_Height.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Wichtiger Hinweis zur Anzeige Ihres Gerätes!");

                int anz = 12;
                sMsgBoxTranslate = "Es wurden {0} Abwesenheiten überspielt!";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, anz.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Abwesenheiten überspielen", MessageBoxButtons.OK);

                string rSelDokument_DokumentenName = " fileName ";
                sMsgBoxTranslate = "Die Datei '{0}' wurde nicht gefunden!";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, ENV.PathDokumente.Trim() + @"\" + rSelDokument_DokumentenName.Trim());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Datei öffnen");

                int iCounterBenutzerChanged = 12;
                sMsgBoxTranslate = "{0}. Benutzer neu zu Abteilungen und Bereichen zugeordnet!";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, iCounterBenutzerChanged.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "PMDS", MessageBoxButtons.OK);

                string filenamePDFA = " fileName ";
                sMsgBoxTranslate = "Datenarchiv wurde als {0} erstellt.";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, filenamePDFA.ToString());
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Information");

                DateTime datum = DateTime.Now;
                sMsgBoxTranslate = "Wollen Sie die Pflegeanamnese \"" + "{0}" + "\" wirklich löschen?";
                sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, datum.ToString("dd.MM.yyyy HH:mm"));
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "Löschen", MessageBoxButtons.YesNo);
                
                DateTime gueltigAb = DateTime.Now;
                string txt = "Für den Zeitraum {0} sind keine Transfer Kostenträger zugeordnet. Bitte TransferKostenträger zuordnen oder Zeitraum ändern.";
                txt = QS2.Desktop.ControlManagment.ControlManagment.getRes(txt, gueltigAb.ToString("dd.MM.yyyy"));
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Buchungen speichern", MessageBoxButtons.OK);

                txt = "Mit diesem Formular können keine freiheitsbeschränkenden Maßnahmen gemeldet werden, die nach dem 11.1.2016 beginnen.";
                txt += "\n\rBitte warten Sie und erstellen Sie die Meldung am 11.1.2016 noch einmal mit dem neuen Formular.";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Achtung: Geänderte Meldestruktur ab dem 11.1.2016", MessageBoxButtons.OK);


                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "", MessageBoxButtons.OK);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "Benutzer-Einrichtungen");
                string title = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, title, MessageBoxButtons.YesNo);

                string txtKtoGKto = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtKtoGKto, "Buchungen speichern", MessageBoxButtons.OK);
                
                //string txtQuestion = "";
                //string txtHeader = "";
                //res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtQuestion, txtHeader, MessageBoxButtons.YesNo);

                string ErrorText = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ErrorText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                
                string _modellErrorText = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(_modellErrorText);

                string sError = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sError);
                string ex = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ex.ToString(), true);

                StringBuilder sb = new StringBuilder();
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), "Datensatz löschen", MessageBoxButtons.OK, MessageBoxIcon.Error, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                string ASZMOhneArtikel = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sb.ToString(), ENV.String("DIALOGTITLE_DELETEASZM", ASZMOhneArtikel), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Es wurde kein Archivpfad fürs Archivsystem angegeben", "Import Befunde", System.Windows.Forms.MessageBoxButtons.OK);
                string ArchivePath  = " pfad ";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivpfad '") + ArchivePath.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                string FolderImport = " folder ";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Import-Verzeichnis '") + FolderImport.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Pflegegeldstufe(n) (") + sb.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(") ist(sind) zu Klienten zugeordenet, Daher kann(können) nicht gelöscht werden."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegegeldstufe löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);
                string ex_Message = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ex_Message, QS2.Desktop.ControlManagment.ControlManagment.getRes("Fehler beim Zugriff auf externe Programme"), MessageBoxButtons.OK, MessageBoxIcon.Stop, true);
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamentenwarnung");

                string sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), " bezeichnung ");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);

                sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wert des Feldes {0} muss zwischen {1} und {2} liegen"), " bezeichnung ", "2", "4");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Falscher Wertebereich"), MessageBoxButtons.OK, true);

                sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), " bezeichnung ");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);

                sText = string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Feld {0} muss ausgefüllt werden"), " bezeichnung ");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Eingabe fehlt"), MessageBoxButtons.OK, true);

                sText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Den Dialog wirklich verlassen ?");
                sText += QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\nEs sind noch Maßnahmen zum Abzeichnen markiert");
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlassen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);
                string txtInfo = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtInfo, QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en"), true);

                string RightsErrorText = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(RightsErrorText, QS2.Desktop.ControlManagment.ControlManagment.getRes("Unzureichende Rechte"), MessageBoxButtons.OK, MessageBoxIcon.Stop);















                //sMsgBoxTranslate = "";
                //sMsgBoxTranslate = QS2.Desktop.ControlManagment.ControlManagment.getRes(sMsgBoxTranslate, "".ToString(), "".ToString());
                //QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTranslate, "");

                string CurrentRow_Nachname = "";
                string CurrentRow_Vorname = "";
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen alle Daten von ") + CurrentRow_Nachname + " " + CurrentRow_Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wirklich gelöscht werden?"),
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Bewerber löschen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);

                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(CurrentRow_Nachname + " " + CurrentRow_Vorname + QS2.Desktop.ControlManagment.ControlManagment.getRes(" hat bereits mindestens einen Aufenthalt und kann ") +
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("daher nicht gelsöcht werden. Soll statt dessen der Bewerberstatus zurückgesetzt werden?"),
                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Bewerberstatus zurücksetzen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);

                int aktRow = 12;
                int maxLines = 13;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben ") + aktRow.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen ausgewählt, es können aber nur ") + maxLines.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Meldungen auf einmal in der Liste anzeigt werden.\r\n") +
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte wiederholen Sie die Schnellrückmeldung für die restlichen Meldungen."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), MessageBoxButtons.OK, true);

                string txtBezugspersonen = "";
                int CountBezugspersonen = 12;
                txtBezugspersonen = CountBezugspersonen > 0 ? "\n\r" + CountBezugspersonen.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bezugspersonenzuordnung werden gelöscht. ") : "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben die Abteilung geändert!") + txtBezugspersonen +
                                                                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rBitte überprüfen Sie die Pflegeplanung auf abteilungsspezifische Planungseinträge!\n\r\n\rWollen Sie fortfahren?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), MessageBoxButtons.YesNo, true);
                int iCounterÄrzteDeleted = 12;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterÄrzteDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(". Ärzte gelöscht bzw. zusammengeführt!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS"), MessageBoxButtons.OK, true);

                DateTime dtpAbgebenVon = DateTime.Now;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox((QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie das Datum ") + (((DateTime)dtpAbgebenVon).Date.ToShortDateString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" beibehalten?"))), QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte kontrollieren sie das Datum ab dem die Änderung gelten soll!"), MessageBoxButtons.YesNo, true);
                int iDekurse = 3;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iDekurse.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Dekurse wurden kopiert."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurse von Voraufenthalt kopieren"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);                        

                string _select_Text = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("VERWALTUNG.QUESTION_DELETE", _select_Text),
                                                                            ENV.String("VERWALTUNG.DIALOGTITLE_DELETE"),
                                                                            MessageBoxButtons.YesNo,
                                                                            MessageBoxIcon.Question, true);
                
                int iAppVersion = 0;
                string iDBVersion = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("ERROR_MISSMATCH_DBVERSION", iDBVersion, iAppVersion), "", MessageBoxButtons.OK, MessageBoxIcon.Stop, true);

                string cbTopTen_Text = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEPDXGRUPPE", cbTopTen_Text), ENV.String("DIALOGTITLE_DELETEPDXGRUPPE"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);

                string cbPDX_SelectedItem_DisplayText = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEPDX", cbPDX_SelectedItem_DisplayText), ENV.String("DIALOGTITLE_DELETEPDX"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);

                string ASZM = "";
                string dgKatalog_ActiveRow_Cells_Text_Value = "";
                string _Katalog_GROUP = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEASZM", ASZM, dgKatalog_ActiveRow_Cells_Text_Value.ToString()), ENV.String("DIALOGTITLE_DELETEASZM", ENV.String(_Katalog_GROUP.ToString() + "Single")), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                string ASZMSingleForm = "";
                string cbASZM_SelectedItem_DisplayText = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(ENV.String("QUESTION_DELETEASZM", ASZMSingleForm, cbASZM_SelectedItem_DisplayText), ENV.String("DIALOGTITLE_DELETEASZM", ASZMOhneArtikel), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, true);

                string fiPMDS_Handbuch_FullName = "";
                var result = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Kann Handbuch ") + fiPMDS_Handbuch_FullName + QS2.Desktop.ControlManagment.ControlManagment.getRes(" nicht öffnen. Ist ein PDF-Reader installiert?"), true);

                string sFile = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Datei " + sFile + " existiert nicht");
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + sFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert nicht"), true);

                DateTime dt = DateTime.Now;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Diese Demoversion läuft am {0} ab"), dt.ToShortDateString()), true);

                string dir = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Pfad '") + dir + QS2.Desktop.ControlManagment.ControlManagment.getRes("' kann nicht erstellt werden! Bitte dem Administrator melden!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pfade"), true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Import-Verzeichnis '") + FolderImport.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivpfad '") + ArchivePath.Trim() + QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
            
                string Befund_Verzeichnis = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Verzeichnis ") + Befund_Verzeichnis + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist in Verwendung. Bitte händisch löschen."), true);

                string Befund_ImportFile = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + Befund_ImportFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist in Verwendung. Bitte händisch löschen."), true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ") + Befund_ImportFile + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde in der Zwischenzeit gelöscht."));

                int iCounterFilesImportedError = 0;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterFilesImportedError.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde/n nicht erfolgreich eingelesen."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Einlesen Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);

                int iCounterBefundeImported = 0;
                int iCounterBefundeImportedError = 0;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Erfolgreich importiert: ") + iCounterBefundeImported.ToString() + "\r\n" +
                                                                            QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht importiert (Ältere Version, Datei bereits im Archiv, nicht zuordenbar oder die Datei wurde vor dem Import gelöscht) : ") + iCounterBefundeImportedError.ToString(), QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde"), System.Windows.Forms.MessageBoxButtons.OK, true);
           
                int iCounterAbgezeichnet = 0;
                int iCountNichtGegengezeichnet = 0;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterAbgezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Einträg/e wurden gegengezeichnet.") + "\r\n" +
                                                                            iCountNichtGegengezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Einträg/e wurden nicht gegengezeichnet. Berufsstand bzw. Hierarchie oder Berufsgruppe nicht passend."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Gegenzeichnen"), System.Windows.Forms.MessageBoxButtons.OK, true);
                string AddMsg = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt der Durchführung darf nicht") + AddMsg + QS2.Desktop.ControlManagment.ControlManagment.getRes(" in der Zukunft liegen!"), "", System.Windows.Forms.MessageBoxButtons.OK, true);

                string NachNameSecure = "";
                string rPatient_Nachname = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Der von Ihnen eingebene Nachname '") + NachNameSecure + QS2.Desktop.ControlManagment.ControlManagment.getRes("' unterscheidet sich vom Nachnamen des zu entlassenden Klienten '") + rPatient_Nachname + QS2.Desktop.ControlManagment.ControlManagment.getRes("'. Bitte geben Sie den richtigen Nachnamen ein."), true);

                string panel1_BorderStyle = "";
                string panel1_BackColor = "";
                string panel1_Visible = "";
                string panel1_Enabled = "";
                string panel1_Top = "";
                string panel1_Left = "";
                string ultraLabel1_Top = "";
                string ultraLabel1_Left = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format("{0} / {1} / {2} / enabled:{3} / X:{4}, Y:{5} / X:{6}, Y:{7}", panel1_BorderStyle.ToString(), panel1_BackColor.ToString(), panel1_Visible.ToString(), panel1_Enabled.ToString(), panel1_Top, panel1_Left, ultraLabel1_Top, ultraLabel1_Left));

                DateTime Ablauf = DateTime.Now;
                result = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Ihr Passwort läuft am ") + Ablauf.ToString("dd. MMMM yyyy") + QS2.Desktop.ControlManagment.ControlManagment.getRes(" ab.\n\rWollen Sie Ihr Passwort jetzt ändern?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinweis"), System.Windows.Forms.MessageBoxButtons.YesNo, true);

                sFile = "";
                string sLine = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(string.Format(QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Link Datei {0} mit dem Inhalt <{1}> ist ungültig"), sFile, sLine), true);

                string tab_Text = "";
                res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die Zuordnung für \"") + tab_Text + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" wirklich löschen?"), QS2.Desktop.ControlManagment.ControlManagment.getRes("ASZM Zuordnung löschen"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, true);

                string ACTIVE_PDXDEF_Klartext = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Die PDx \"") + ACTIVE_PDXDEF_Klartext + QS2.Desktop.ControlManagment.ControlManagment.getRes("\" kann nicht gelöscht werden, wurde in Pflegeanamnesen verwendet."), true);

                string arg_Text = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(arg_Text + QS2.Desktop.ControlManagment.ControlManagment.getRes(" existert bereits daher kann nicht hinzugefügt werden."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Eintrag existert bereits"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);

                int iCounterDeleted = 0;
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Medikamente wurden bestellt!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellung Medikamente"), MessageBoxButtons.OK, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterDeleted.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bestellung/en wurde/n gelöscht!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("Bestellung Medikamente löschen"), MessageBoxButtons.OK, true);

                string row_Bezeichnung = "";
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament ") + row_Bezeichnung + QS2.Desktop.ControlManagment.ControlManagment.getRes(" kann nicht gelöscht werden weil es in Rezepten vorhanden ist."), QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament löschen"), MessageBoxButtons.OK, MessageBoxIcon.Information, true);

                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(iCounterAbgezeichnet.ToString() + QS2.Desktop.ControlManagment.ControlManagment.getRes(" PDx-Einträge wurden rückgemeldet!"), QS2.Desktop.ControlManagment.ControlManagment.getRes("PDX Rückmeldung"), MessageBoxButtons.OK, true);
                QS2.Desktop.ControlManagment.ControlManagment.MessageBox(txtInfo, QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en"), true);

            }
            catch (Exception ex)
            {
                throw new Exception("testMsgBoxes: " + ex.ToString());
            }
        }
        public void testTranslations()
        {
            try
            {
                string retStr2 = ENV.String("OneRowByID: DB.E_ID_NOT_FOUND");

                //string sResult =  ENV.String("EINZELSPENDER");
                //sResult =  ENV.String("WOCHENSPENDER");
                //sResult =  ENV.String("TAGESSPENDER");
                //sResult =  ENV.String("A");
                //sResult =  ENV.String("S");
                //sResult =  ENV.String("R");
                //sResult =  ENV.String("Z");
                //sResult =  ENV.String("M");
                //sResult =  ENV.String("X");
                //sResult =  ENV.String("PATIENT_BASEINFO");
                //sResult =  ENV.String("WIEDERHOLUNGSTYP_T") + " ";

                //sResult =  ENV.String("WIEDERHOLUNGSTYP_A");
                //int wert = 0;
                //sResult =  ENV.String("WIEDERHOLUNGSTYP_J", wert.ToString()) + " ";
                //string Group = "";
                //sResult =  ENV.String("SiteGroups." + Group.ToString());
                //string Entry = "";
                //sResult =  ENV.String("SiteEvents." + Entry.ToString());
                //sResult =  ENV.String("PATIENT_BASEINFO");

                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("ERROR_MS_ORZB");
                //sResult =  ENV.String("B");
                //string name = "";
                //sResult =  ENV.String(name);
                //sResult =  ENV.String("INFO_KEINE_RESOURCEN");
                //sResult =  ENV.String("GUI_AREA_TERMINLISTE");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //string usr_FullName = "";
                //sResult =  ENV.String("GUI.STATUS_USER", usr_FullName);
                //sResult = PMDS.Global. ENV.String("GUI.STATUS_DB");
                //sResult =  ENV.String("GUI.E_ZUSATZ_ENTRY");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("DAS");
                //sResult =  ENV.String("DIE");
                //string _Katalog_GROUP2 = "";
                // ENV.String(_Katalog_GROUP2.ToString() + "Single");
                //string _SelectedGroup = "";
                //sResult =  ENV.String(_SelectedGroup + "_Select");
                //sResult =  ENV.String(_SelectedGroup + "Single") + " " +  ENV.String("SEARCH");
                //sResult =  ENV.String(_SelectedGroup + "_Select");



                // ---------------------------------------------------------------------------------------------------------------------------------------
                // ------------------------- ABGEARBEITET ------------------------------------------------------------------------------------------
                // ---------------------------------------------------------------------------------------------------------------------------------------

                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Unzureichende Rechte")
                //getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"
                //getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"
                //getRes("Berichte PEP")
                //getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen")

                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rErgänzung / Änderung: Ersetzt Version ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(", importiert am ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Kombination aus SozVers.Nr (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(") und Name im Befund (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(") stimmt nicht mit den Daten im PMDS überein (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existieren mehrere Klienten mit der SozVers.Nr '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert kein Klient '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");


                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert mehr als ein Klient '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' in der Datenbank.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es existiert kein Klient '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' mit der SozVers.Nr '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' bzw. dem Geburtsdatum '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befund wird nicht importiert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n(Kopie von Aufenthalt mit Aufnahmedatum ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n(Kopie von Aufenthalt mit Aufnahmedatum ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es bestehen offene Freiheitsbeschränkungen für den Patienten! (Anzahl: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" ist fällig am ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ältere Version der Datei ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" für SozVers.Nr: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird übersprungen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" für SozVers.Nr: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" kann wegen fehlerhafter Version nicht geladen werden!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(". Zeile/n gelöscht!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärztlicher Dekurs für {0}");

                string retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Durchführungsnachweis");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("noch nie rückgemeldet");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("BLZ");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes(", Kto.Nr ");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Alle Maßnahmen ab Wiederaufnahmezeitpunkt wurden neu geplant!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Es waren keine Maßnahmen geplant.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsende");

                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Update Nächstes Datum für ges. Db");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes(", dringend");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung für Eintrag ");

                DialogResult res = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Klient ist keinem Bereich zugeordnet. Planung wird durchgeführt, aber es wird kein Protokoll geschrieben! \n\r" +
                                                                            "Bitte ordnen Sie so rasch wie möglich einen Bereich zu.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurskopie");

                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme umgeplant");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Senden Unterbringung");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie Ihr Passwort ein");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung senden");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Senden HAG-Meldung");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Interner Fehler");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein gültiges Zertifikat gefunden.");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht gesendet");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie Ihr Passwort ein");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung senden");
                retStr = QS2.Desktop.ControlManagment.ControlManagment.getRes("... keine PDx gefunden.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einschränkung ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" vom ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(", Vorraussichtliches Ende: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle Befundarten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Befunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" eingelesen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein Befund ausgewählt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll für Befunde einlesen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Protokoll für Befunde speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem PDF-Viewer angezeigt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument wird in externem Dicom-Viewer angezeigt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hier Klicken um Daten zu filtern");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Mit Zeitbezug");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ohne Zeitbezug");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Mit Pflegediagnose abzeichnen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelabzeichnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus Intervention");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus Übergabe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus mitverantwortlichen Bereich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs aus medizinischer Diagnosen/Patient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahmenrückmeldung aus Intervention");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung aus Intervention");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungeplante Maßnahme rückmelden aus Intervention");
                              
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Planung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungepl. Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Planung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungepl. Maßnahme");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfigurationsdatei speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("S2 - Engineering GmbH\r\n\r\nIm Stadtgut A1\r\nA - 4407 Steyr - Gleink\r\nTel.: +43 7252 2208 0\r\n");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung zum Beginn ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung zum Ende");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten-Ärztlicher Dekurs ...");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung"); ;                //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Periodische Leistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Sonderleistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen und Sonderleistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alles");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung"); ;             //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Periodische Leistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistungen und Sonderleistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen und Sonderleistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alles");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("nein (z.B. Salben)");                 //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("kurzfristig (z.B. Tropfen)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("langfristig (Dispenser)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ärztlich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchtgift");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("wie hergerichtet");                   //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("einzeln");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Intervention");                         //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Übergabe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereich Int.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereich Über.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereich Dek");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abteilung / Bereich \nwählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pfleger wählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bereich wählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klienten wählen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme suchen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abbrechen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ignorieren");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Drucken");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Editieren");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entfernen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rückgängig");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beenden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzen Sie die rechte Maustaste, um den Vorfall zu öffnen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient(en)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl für historische Klienten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Auswahl für aktuelle Klienten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientenauswahl");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Name eingeben.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme wählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bild zur Wunddokumentation vom ");
                // oberhaltb von hier nochmals durchgehen ------------------

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgender Zeitbereich ist in Zeitbereichserien zugeordnet, daher kann er");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Zeitbereiche sind in Zeitbereichserien zugeordnet, daher können sie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" nicht gelöscht werden.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Evaluierung für Ziel ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Historie für: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - ASZM ändern");                         //checkn
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - weiter wie bisher");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erreicht - PDX beenden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - ASZM ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - weiter wie bisher");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Teilweise erreicht - PDX beenden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - ASZM ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - weiter wie bisher");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nicht erreicht - PDX beenden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("nein (z.B. Salben)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("kurzfristig (z.B. Tropfen)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("langfristig (Dispenser)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("ärztlich");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchtgift");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("einzeln");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("wie hergerichtet");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Kostenträger wählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzerdefiniert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Benutzer definiert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abteilung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Aufnahmedaten für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplante Aufnahme am: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplante Abteilung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geplanter Bereich (Zi: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geboren am: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Soz.Vers.Nr.: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Familienstand: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Religionsbekenntnis: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsangehörigkeit: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pension:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Versichert: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rezeptgebührenbefreiung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzversicherung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Angehörige: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegestufe: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("FSW: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kommt von: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientennummer: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Buchungen wirklich löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungen wurden gelöscht!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungen drucken");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zurück");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Monatsabrechnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Freie Rechnung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abgerechnet bis");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Rechnungen wirklich löschen?");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die selektierten Rechnungen wirklich stornieren?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnungen wurden storniert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlösbuchung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie die ausgewählten Rechnungen wirklich als Einzahlung buchen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzahlungen gebucht");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Rechnungen gefunden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Rechnung/en");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger   (Anzahl Klienten:");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegekomponente Grundleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wohnkomponente Grundleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahreabschluß Depotgeld für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahreabschluß Buchungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Jahreabschluß Buchungen für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\nDas aktuelle Datum wurde gesetzt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Bis darf nicht vor dem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeld für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeld - Kostenträgerzuordnung für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Einträge gefunden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für der Zeitraum ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits ein Kostenträger. Die Zeiten dürfen sich nicht überschneiden. Bitte ändern.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Leistungskatalog ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig ab ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Datensätze sind Abrechnungen erstellt worden, daher können sie nicht gelöscht werden.\n\t");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Betrag darf nicht null sein!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kostenträger muß angegeben werden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Buchungstext muß angegeben werden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Betrag darf nicht null sein!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Manuelle Buchungen (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Manuelle Buchungen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Periodische Leistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sonderleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Leistungskatalog ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte ein gültiges Datum(mm.yyyy) eingeben.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig bis darf nicht vor dem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(": Für eine Abwesenheit ist das Beginndatum leer!         ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnung - Abwesenheiten übernehmen für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abwesenheiten gefunden!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Überspielen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnungen überspielen für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Export Csv");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Export Abrechnungen für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Meldungen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldungen: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Rechnungsnummern löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Depotgeldabrechnungen löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich die gesamte Abrechnungs- und Buchungsdatenbank löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Admin");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Sammelabrechnungen löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wollen Sie wirklich alle Depotgeldabrechnungen löschen?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Sonderleistung auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Klient auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Transfer Kostenträger wählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Biografie");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach Krohwinkel (AEDL)");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum darf nicht in der Zukunft liegen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach OREM");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anamnese .. nach POP");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben keine Berechtigung Daten zu ändern.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es ist noch keine Anamnese erfasst");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(", drücken Sie Hinzufügen um eine Anamnese zu erfassen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PD \"{0}\" jetzt planen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' and Modellgruppe='");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Assessment ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" des Patienten ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorhandene Formulare");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte wählen...");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" vom ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wählen Sie bitte eine Datei aus:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" DEMO Version");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Daten werden geladen ...");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' von Benutzer '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" gelesen!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" (Anonym User:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Textbaustein hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Textbaustein editieren");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Altes und neues Passwort sind zu ähnlich!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das neue Passwort ist stark genug (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Punkte)\n\r");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der von Ihnen eingebene Nachname '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' unterscheidet sich vom Nachnamen des zu entlassenden Klienten '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("'. Bitte geben Sie den richtigen Nachnamen ein.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rEntlassungsstatus ist ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("verstorben ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("lebend");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rTodeszeitpunkt = ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("IDKlient: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname aus DB: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname eingegeben: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Entlassung Klient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Gesperrt");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Neu anmelden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gesperrt von ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abbrechen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Standardprozedur: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung erfassen für {0}");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Eintrag");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs zu ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("einmaligem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termin ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abwesenheitsbeginn ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" - Alle Maßnahmen werden unterbrochen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Planungsänderung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bezugspersonenzuordnung werden gelöscht. ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie haben die Abteilung geändert!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\rBitte überprüfen Sie die Pflegeplanung auf abteilungsspezifische Planungseinträge!\n\r\n\rWollen Sie fortfahren?");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Neue Abteilung ist ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Neuer");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(", neuer");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Bereich ist ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bemerkung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlegung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klicken Sie auf \"OK\", um den Vorgang abzuschließen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klicken Sie auf \"Weiter\", um den Vorgang fortzusetzen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv von {0} für {1} ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Archivsystem");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("E-Mails");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für Klient ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Ziel");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ärzte Quelle");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Notfall: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" um ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(". Beschreibung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum in der Zukunft ist nicht zulässig");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Uhrzeit 00:00 ist nicht zulässig");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("kein nächster Zeitpunkt");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 10 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 15 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 20 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 30 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 45 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 60 Minuten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 2 Stunden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 4 Stunden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 8 Stunden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 16 Stunden");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 1 Tag");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("+ 2 Tage");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Einzelverordnung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ungeplante Maßnahme: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dauer: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Durchgeführt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzwerte vor der Änderung:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Werte vom Benutzer ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurden durch ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" am {0} um {1} ersetzt.\r\n");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\nzuletzt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Termine - Sql-Command");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zusatzwerte: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erstellt von: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Werte der letzten 24 Stunden:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Werte der letzten 24 Stunden konnten nicht gelesen werden.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Beginn ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bearbeiten ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Am");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Ende darf nicht kleiner sein als der Beginn.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächste Versorgung darf nicht kleiner sein als die letzte Versorgung.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ressource bearbeiten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ressource hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme bearbeiten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Maßnahme hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bis darf nicht kleiner als Von.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamentöse Freiheitsbeschränkung/-einschränkung kann nur ein Arzt anordnen. Bitte Arzt auswählen und eintragen und Dosierung überprüfen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte eine Dauer auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte anordnende Person angeben.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es muss ein ärztliches Dokument angegeben werden (Art, Arzt und Datum prüfen).");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte psychische Krankheit oder geistige Behinderung oder beide auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Selbstgefährdung oder Fremdengefährdung oder beide auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Muss ausgewählt werden.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("xyxy");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Empfänger auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Berufsgruppe auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Art der Freiheitsbeschränkung/- einschränkung auswählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für eine Verlängerung, Vorraussichtliche Dauer oder oder Berufsgruppe ändern.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitpunkt der Aufhebung darf nicht kleiner als der Beginn sein.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Meldung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Vornahme einer Freiheitsbeschränkung/einschränkung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Aufhebung einer Freiheitsbeschränkung/einschränkung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" über die Verlängerung einer gerichtlich zulässig erklärten Freiheitsbeschränkung nach Ablauf der Frist");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" gemäß HeimAufG");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n für ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte eine Dauer auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte anordnende Person angeben.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte psychische Krankheit oder geistige Behinderung oder beide auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Selbstgefährdung oder Fremdengefährdung oder beide auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datum vor 11.1.2016 nicht erlaubt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Berufsgruppe auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Art der Freiheitsbeschränkung/- einschränkung auswählen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für eine Verlängerung bitte das vorraussichtliche Ende ändern.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" am ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgebevollmächtigte ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" von ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erwachsenenvertreter ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorsorgevollmächtige ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" von ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine Abteilung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nachname: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vorname: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Titel: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Fallnummer: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gruppenkennzahl: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientennummer: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zimmernummer: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsdatum: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsname: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geschlecht: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Geburtsort: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Familienstand: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Staatsbürgerschaft: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Konfession: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Erlernter Beruf: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verstorben: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Todeszeitpunkt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ja");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nein");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Größe: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gewicht: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Größe: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Haarfarbe: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Statur: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Namenstag: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kosename: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bes. Kennzeichen: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Initialberührung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kennwort: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Milieubetreuung: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("KZ-Überlebender: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anatomie: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen zur Übergabe wurden geändert.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientendaten wurden editiert.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datenänderung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bild von ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(", geb. am ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument auswählen und speichern");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument löschen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument öffnen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein Dokument vorhanden");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument für Klient '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dokument für Klient");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' hinterlegt");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Verlängerung am ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient zu Kostenträger zuordnen für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient zu Kostenträger (Klienten aller Einrichtungen)");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte einen Klienten auswählen.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig bis darf nicht vor dem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Transferleistung");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Grundleistung");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} Kostenträger");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Konto (FIBU): ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" existiert bereits. Bitte ändern.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Allgemeine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klientenbezogene");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Transfer");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte einen Kostenträger auswählen.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das Datum Gültig bis darf nicht vor dem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" liegen.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Weitere Klienten mit ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Kein Medikament markiert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Änderung einer Medikation!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("geändert");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("angeordnet");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("gelöscht");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeiten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikament(e) abgegeben:");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Heute");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Morgen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Woche ab Heute");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Woche ab Morgen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächster ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Dekurs Einzel");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient: ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Startdatum ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" und Lokalisierung ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für PDx \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ätiologie \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Symptom \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ressource \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Informationen für Ziel \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Startzeitpunkte für Maßnahme \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\" angeben");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Es wurden keine Ätiologien, Symptome, Ressourcen, Ziele oder Maßnahmen ausgewählt.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("{0} hinzufügen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Eine Pflegedefinition darf pro Modell nur einmal vorkommen. Bitte ändern.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Wählen Sie die Favoriten für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" aus");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Allgemeine Favoriten");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegeanamnesen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Suchmuster - drücken Sie ENTER um die Suche zu starten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Favoriten");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("&Pflegedefinitionen hinzufügen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("&Wunden hinzufügen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Uhrzeit");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Zeitbereich");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Eintrag ist mehrmals der Selben Abteilung zugewiesen. Bitte ändern.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ein Eintrag auswählen.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("einem Pflegeplaneintrag");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' ist ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Pflegeplaneinträgen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" zugeordnet. \n\rDer Eintrag kann nicht entfernt werden.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("' ist im Katalog zu folgenden Pflegedefinitionen zugeordnet:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\n\nDer Eintrag kann erst gelöscht werden, wenn Sie alle Zuordnungen entfernt haben.");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Pflegediagnose suchen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Aufenthalt von ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" bis ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Übergabe ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Interventionen");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Übergabe");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Historie");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" seit ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("DNR ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - Pflegemanagement- und Dokumentationssystem ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("für ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Termin");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("e");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Automatische Sperre in ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("einer Sekunde!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Sekunden!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS - ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("PMDS");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anleitungen (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickfilter ");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickmaßnahme ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Quickmaßnahme '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' abzeichnen!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für folgende Klienten wurde eine Abrechnung durchgeführt:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Abrechnung für Monat ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird durchgeführt:");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Depotgeldabrechnung bis ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wird abgerechnet ...");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde erfolgreich abgerechnet!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Für ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurden keine Leistungen gefunden!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes(" wurde erfolgreich abgerechnet! (");
                QS2.Desktop.ControlManagment.ControlManagment.getRes(" Positionen verrechnet)");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Keine");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Alle");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Übernächstes Monat");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Nächstes Monat");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Aktuelles Monat");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vormonat");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 2 Monaten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 3 Monaten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 4 Monaten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor 5 Monaten");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Vor einem halbem Jahr");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Letztes Jahr");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Das gesamte letzte Jahr");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Gefunden: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Klient ist Kostenträger");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Aktuelle Config-Datei: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Installationsordner: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechner: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Rechnung/en");
                
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte geben Sie einen Dekurs ein.");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\r\n (Die Maßnahme wurde nicht durchgeführt)");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Anzahl Medikamente eingespielt: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Start: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Ende: ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Medikamente wurden importiert!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Die Standardprozedur \"");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("\" kann nicht gelöscht werden. Weil Sie zu folgende Maßnahmen zugeordnet ist:\n");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datensatz löschen");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgender Arzt hat Rezepte erstellt, deshalb kann er nicht entfernt werden. ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Folgende Ärzte haben Rezepte erstellt, deshalb können Sie nicht entfernt werden. ");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Lokalisierung und Lokalisierungseite für folgende PDx'en hinzufügen.\n\t");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Bitte Lokalisierung und Lokalisierungseite für folgende PDx'en hinzufügen.\n\t");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Import Befunde");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv-Ordner '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert mehr als einmal!");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("Archiv-Ordner '");
                QS2.Desktop.ControlManagment.ControlManagment.getRes("' existiert nicht!");

                QS2.Desktop.ControlManagment.ControlManagment.getRes("Datei nicht gefunden.");


                bool bCheckOK = true;

                // -------------------------------------------------------------------------------------------------------------------------------
                // -- ----------------------- UNSICHER ---------------------------------------------------------------------------------
                // -------------------------------------------------------------------------------------------------------------------------------
                
                //string sResult =  ENV.String("EINZELSPENDER");
                //sResult =  ENV.String("WOCHENSPENDER");
                //sResult =  ENV.String("TAGESSPENDER");
                //sResult =  ENV.String("A");
                //sResult =  ENV.String("S");
                //sResult =  ENV.String("R");
                //sResult =  ENV.String("Z");
                //sResult =  ENV.String("M");
                //sResult =  ENV.String("X");
                //sResult =  ENV.String("PATIENT_BASEINFO");
                //sResult =  ENV.String("WIEDERHOLUNGSTYP_T") + " ";

                //sResult =  ENV.String("WIEDERHOLUNGSTYP_A");
                //int wert = 0;
                //sResult =  ENV.String("WIEDERHOLUNGSTYP_J", wert.ToString()) + " ";
                //string Group = "";
                //sResult =  ENV.String("SiteGroups." + Group.ToString());
                //string Entry = "";
                //sResult =  ENV.String("SiteEvents." + Entry.ToString());
                //sResult =  ENV.String("PATIENT_BASEINFO");

                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("ERROR_MS_ORZB");
                //sResult =  ENV.String("B");
                //string name = "";
                //sResult =  ENV.String(name);
                //sResult =  ENV.String("INFO_KEINE_RESOURCEN");
                //sResult =  ENV.String("GUI_AREA_TERMINLISTE");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //string usr_FullName = "";
                //sResult =  ENV.String("GUI.STATUS_USER", usr_FullName);
                //sResult = PMDS.Global. ENV.String("GUI.STATUS_DB");
                //sResult =  ENV.String("GUI.E_ZUSATZ_ENTRY");
                //sResult =  ENV.String("GUI.E_NO_TEXT");
                //sResult =  ENV.String("DAS");
                //sResult =  ENV.String("DIE");
                //string _Katalog_GROUP2 = "";
                // ENV.String(_Katalog_GROUP2.ToString() + "Single");
                //string _SelectedGroup = "";
                //sResult =  ENV.String(_SelectedGroup + "_Select");
                //sResult =  ENV.String(_SelectedGroup + "Single") + " " +  ENV.String("SEARCH");
                //sResult =  ENV.String(_SelectedGroup + "_Select");

                // ---------------------------------------------------------------------------------------------------------------------------------------
                // ------------------------- ABGEARBEITET ------------------------------------------------------------------------------------------
                // ---------------------------------------------------------------------------------------------------------------------------------------

                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Unzureichende Rechte")
                //getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"
                //getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"
                //getRes("Berichte PEP")
                //getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen")

                // -------------------------------------------------------------------------------------------------------------------------------
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);            // Abrechnung starten 
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Berichte PEP");
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen"), true, false, true);                    // Quickmeldung starten 
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um die Abrechnung direkt zu starten"), false, false, false);            // Abrechnung starten 
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Berichte PEP")
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen"), true, false, true);                    // Quickmeldung starten 
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Berichte PEP");
                //QS2.Desktop.ControlManagment.ControlManagment.getRes("Sie verfügen nicht über die notwendigen Rechte um Klientenrückmeldungen zu tätigen"), true, false, true);                    // Quickmeldung starten 

                bool bOPK = true;

            }
            catch (Exception ex)
            {
                throw new Exception("testTranslations: " + ex.ToString());
            }
        }



    }

}

