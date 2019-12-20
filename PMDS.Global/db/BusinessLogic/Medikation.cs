using System;
using System.Collections.Generic;
using System.Text;
using PMDS.DB.Global;
using PMDS.Data.Global;
using PMDS.Global;
using System.Data;
using PMDS.Global.db.Global;


namespace PMDS.BusinessLogic
{

    public class Medikation
    {
        private DBMedikation _db = new DBMedikation();




        ///	Liefert eine aufbereitete Liste der Medikamente je nach Abgabeart etc.
        /// Es werden horizontale Einträge bei bedarf in vertikale gesplittet.
        public dsMedikationVonBis.MedikationDataTable GetAlleAufbereiteten(DateTime dtvon, DateTime dtbis, List<Guid> IDAufenthalt, MedikationListenMode mode)
        {
            dsMedikationVonBis.MedikationDataTable dtret = new dsMedikationVonBis.MedikationDataTable();
            foreach (Guid id in IDAufenthalt)
            {
                //osMed
                dsMedikationVonBis.MedikationDataTable dt = ReadValidEntries(dtvon, dtbis, id);    // ausgewählten Bereich lesen
                //dsMedikationVonBis.MedikationDataTable dt = ReadValidEntries(dtvon.Date, dtbis.Date.AddDays(1), id);    // immer 24 Stunden ende lesen
                SplitAndAdd(ref dt, ref dtret, mode, dtvon, dtbis, id);
            }
            return dtret;
        }

        private dsMedikationVonBis.MedikationDataTable ReadValidEntries(DateTime dtvon, DateTime dtbis, Guid IDAufenthalt)
        {
            return _db.Read(dtvon, dtbis, IDAufenthalt);
        }


        ///	Je nach Regel und Modus Horizontal oder Vertikal anfügen und den Standardtext für
        /// untertägige Tagesspender vorbelegen.
        /// Regeln:
        /// Modus:  Herrichten
        ///         Langfristig             = 1 Eintrag pro Tag/Medikament
        ///         Kurzfristig             = 1 Eintrag pro Tag/Zeitpunkt/Medikament
        ///         Nicht Standardzeiten    = 1 Eintrag pro Tag/Zeitpunkt/Medikament
        ///         -----------------------------------------------------------------
        ///         Vorbereitung: wie herrichten jedoch wenn verabreichung einzel ist
        ///         dann 1 Eintrag pro Tag/Zeitpunkt/Medikament
        private void SplitAndAdd(ref dsMedikationVonBis.MedikationDataTable dtMed, ref dsMedikationVonBis.MedikationDataTable dtret, MedikationListenMode mode, 
                                 DateTime dtvon, DateTime dtbis, Guid IDAufenthalt)
        {
            DateTime dt = dtvon;
            List<DateTime> adt = new List<DateTime>();                                      // Liste aller zu verarbeitenden Tage aufbauen

            //os191220
            int iFullDays = (int)(dtbis - dtvon).TotalDays;
            for (int i = 0; i <= iFullDays; i++)
            {
                if (i == 0)
                    adt.Add(dt);
                else
                    adt.Add(dt.Date.AddDays(i));
            }
            /*
            while (dt < dtbis)
            {
                adt.Add(dt);
                dt = dt.AddDays(1);
            }
            */

            //lthMedikation
            dsMedikationVonBis.MedikationDataTable dttemp = new dsMedikationVonBis.MedikationDataTable();
            foreach (dsMedikationVonBis.MedikationRow r in dtMed)
            {
                foreach (DateTime dtWork in adt)                                            // Jeden Tag durchgehen
                {
                    if (!RandbedingungOK(r, dtWork, dtbis, mode))                                  // Prüfen ob Ds in das schema passt zB nur MO oder jeden 4ten des Monats etc
                        continue;
                    
                    // Randbedingung ok ==> Datensatz erzeugen je nach herrichten und mode
                    if (
                            (r.Herrichten == (int)medHerrichten.langfristig && r.StandardzeitenJN) && 
                            !(mode== MedikationListenMode.Abgabe && r.Verabreichungsart == (int)medVerabreichung.einzeln)
                       )
                        CopyOnly(r, ref dttemp, dtWork);
                    else
                        Split(r, ref dttemp, dtWork, dtvon, dtbis);
                    
                }
            }

            if (mode == MedikationListenMode.Abgabe)
                dttemp = Compress(dttemp, adt, IDAufenthalt);                           // Abgabe will nur einen Eintrag pro Tag pro Tagesspender

            Copyall(ref dttemp, ref dtret);
        }

        

        ///	Die Abgabe gibt einen Tagesspender mit mehreren Medikamenten aus
        /// Die Liste der Medikamente des Tages werden zu einem Datensatz komprimiert
        /// in dttemp stehen alle Datensätze aller Medikamente aller Tage des Klienten
        /// Alle nicht langfristig vorzubereitenden bleiben unangetastet
        /// Bei Tagesspendern wird die ID auf Guid.Empty gesetzt (ID == IDRezepteintrag)
        /// Damit kann beim Vergleich, ob abgegeben worden ist oder nicht,
        /// der Schlüssel Zeitpunkt/IDRezepteintrag für den Abgleich herangezogen werden
        private dsMedikationVonBis.MedikationDataTable Compress(dsMedikationVonBis.MedikationDataTable dttemp, List<DateTime> adt, Guid IDAufenthalt)
        {
            string sselect;
            DataRow[] ar;
            dsMedikationVonBis.MedikationDataTable dtret = new dsMedikationVonBis.MedikationDataTable();
            foreach (DateTime d in adt)
            {
                string sTranslate = string.Format("MedikationDatum = '{0}' and herrichten = {1} and verabreichungsart = {2}", d.Date.ToShortDateString(), (int)medHerrichten.langfristig, (int)medVerabreichung.wieHergerichtet);
                sselect = sTranslate;
                ar =  dttemp.Select(sselect, "");
                if (ar.Length > 0)
                {
                    dsMedikationVonBis.MedikationRow rnew = (dsMedikationVonBis.MedikationRow)dtret.Rows.Add(ar[0].ItemArray);
                    rnew.ZeitenText     = "";
                    rnew.Einheit        = "Tagesspender";
                    rnew.Bezeichnung    = GetAllMedikamente(ar);
                    rnew.ID             = IDAufenthalt;
                    rnew.ZP0            = 1;
                    rnew.Applikationsform = "";
                }
            }

            // Alle nicht Tagesspender anfügen
            sselect = string.Format("not (herrichten = {0} and verabreichungsart = {1})", (int)medHerrichten.langfristig, (int)medVerabreichung.wieHergerichtet);
            ar = dttemp.Select(sselect, "");
            foreach(dsMedikationVonBis.MedikationRow r in ar)
                dtret.Rows.Add(r.ItemArray);

            // Abgabe checken
            foreach (dsMedikationVonBis.MedikationRow r in dtret)
            {
                AbgegebenHelper h   = IsAbgegeben(r.ID, r.MedikationDatum);
                r.Abgegeben         = h._IsAbgegeben;
                r.AbgegebenVon      = h._AbgegebenVon;
            }

            

            return dtret;
        }

        ///	Liefert alle Medikamente als String
        private string GetAllMedikamente(DataRow[] ar)
        {
            StringBuilder sb = new StringBuilder();
            foreach (dsMedikationVonBis.MedikationRow r in ar)
            {
                bool bNuechtern = (r.ZP0 != 0 && r.StandardzeitenJN);

                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(r.Bezeichnung);

                if (bNuechtern)
                {
                    sb.Append("(");
                    sb.Append(Standardzeiten.StandardzeitenStrings[0]);
                    sb.Append(")");
                }
            }
            return sb.ToString();
        }

        //	Umkopieren der Tabelle
        private void Copyall(ref dsMedikationVonBis.MedikationDataTable dttemp, ref dsMedikationVonBis.MedikationDataTable dtret)
        {
            foreach(dsMedikationVonBis.MedikationRow r in dttemp)
                
                dtret.Rows.Add(r.ItemArray);
        }

        ///	Alle Werte welche nebeneinander stehen werden nun als eine Zeile dargestellt und der Zeitpunkt 
        /// in Zeitpunkt0 geschrieben (Abgabedatum mit Uhrzeit) 
        /// Abgabe im Dispenser
        private void Split(dsMedikationVonBis.MedikationRow r, ref dsMedikationVonBis.MedikationDataTable dtret, DateTime dtWork, DateTime dtvon, DateTime dtbis)
        {
            bool bNuechtern = (r.ZP0 != 0 && r.StandardzeitenJN);

            if (r.StandardzeitenJN)     // Bei Standardzeiten sind die Werte nicht belegt ==> vorbelegen weil sonst Split nicht funktioniert
            {
                if (r.ZP0 > 0) r.Zeitpunkt0 = Standardzeiten.StandardzeitenZeitpunkte[0]; else r.SetZeitpunkt0Null();
                if (r.ZP1 > 0) r.Zeitpunkt1 = Standardzeiten.StandardzeitenZeitpunkte[1]; else r.SetZeitpunkt1Null();
                if (r.ZP2 > 0) r.Zeitpunkt2 = Standardzeiten.StandardzeitenZeitpunkte[2]; else r.SetZeitpunkt2Null();
                if (r.ZP3 > 0) r.Zeitpunkt3 = Standardzeiten.StandardzeitenZeitpunkte[3]; else r.SetZeitpunkt3Null();
                if (r.ZP4 > 0) r.Zeitpunkt4 = Standardzeiten.StandardzeitenZeitpunkte[4]; else r.SetZeitpunkt4Null();
            }
            List<DateTime> al       = new List<DateTime>();
            List<double>   avalues  = new List<double>();
            if (!r.IsZeitpunkt0Null()) { al.Add(r.Zeitpunkt0); avalues.Add(r.ZP0); }
            if (!r.IsZeitpunkt1Null()) { al.Add(r.Zeitpunkt1); avalues.Add(r.ZP1); }
            if (!r.IsZeitpunkt2Null()) { al.Add(r.Zeitpunkt2); avalues.Add(r.ZP2); }
            if (!r.IsZeitpunkt3Null()) { al.Add(r.Zeitpunkt3); avalues.Add(r.ZP3); }
            if (!r.IsZeitpunkt4Null()) { al.Add(r.Zeitpunkt4); avalues.Add(r.ZP4); }

            int iCount = -1;
            foreach (DateTime dt in al)
            {

                DateTime dtZeitpunkt = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, dt.Hour, dt.Minute, 0);
                dsMedikationVonBis.MedikationRow rnew = (dsMedikationVonBis.MedikationRow)dtret.Rows.Add(r.ItemArray);

                if (rnew.AbzugebenVon <= dtZeitpunkt && dtZeitpunkt  <= rnew.AbzugebenBis)
                {
                    rnew.Zeitpunkt0 = dtZeitpunkt;
                    rnew.SetZeitpunkt1Null();
                    rnew.SetZeitpunkt2Null();
                    rnew.SetZeitpunkt3Null();
                    rnew.SetZeitpunkt4Null();

                    rnew.ZP0 = avalues[++iCount];
                    rnew.ZP1 = 0;
                    rnew.ZP2 = 0;
                    rnew.ZP3 = 0;
                    rnew.ZP4 = 0;

                    rnew.UntertaegigJN = false;
                    rnew.StandardzeitenJN = false || bNuechtern;                  // wird benötigt dass die nüchtern Information für die folgeprozesse nicht verloren geht nüchtern == Standardzeiten und ZP0 belegt
                    rnew.MedikationDatum = dtWork.Date.AddHours(dt.Hour).AddMinutes(dt.Minute);
                    rnew.ZeitenText = Tools.ToStringFromMediaktionRow(rnew);
                }
                else
                    dtret.Rows.Remove(rnew);
            }
        }
        
        ///	Die Daten bleiben unverändert - es wird nur der ZeitenText ergänzt
        /// in Zeitpunkt0 - Zeitpunkt4 stehen die Werte für das jeweilige Datum mit der richtigen Zeit
        private void CopyOnly(dsMedikationVonBis.MedikationRow r, ref dsMedikationVonBis.MedikationDataTable dtret, DateTime dtWork)
        {
            dsMedikationVonBis.MedikationRow rnew = (dsMedikationVonBis.MedikationRow)dtret.Rows.Add(r.ItemArray);
            if (!rnew.IsZeitpunkt0Null()) rnew.Zeitpunkt0 = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, rnew.Zeitpunkt0.Hour, rnew.Zeitpunkt0.Minute, 0);
            if (!rnew.IsZeitpunkt1Null()) rnew.Zeitpunkt0 = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, rnew.Zeitpunkt1.Hour, rnew.Zeitpunkt1.Minute, 0);
            if (!rnew.IsZeitpunkt2Null()) rnew.Zeitpunkt0 = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, rnew.Zeitpunkt2.Hour, rnew.Zeitpunkt2.Minute, 0);
            if (!rnew.IsZeitpunkt3Null()) rnew.Zeitpunkt0 = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, rnew.Zeitpunkt3.Hour, rnew.Zeitpunkt3.Minute, 0);
            if (!rnew.IsZeitpunkt4Null()) rnew.Zeitpunkt0 = new DateTime(dtWork.Year, dtWork.Month, dtWork.Day, rnew.Zeitpunkt4.Hour, rnew.Zeitpunkt4.Minute, 0);
            rnew.ZeitenText         = Tools.ToStringFromMediaktionRow(rnew);
            rnew.UntertaegigJN      = true;
            rnew.MedikationDatum    = dtWork.Date;

        }


        ///	Liefert ture wenn die Randbedingungen für den Datensatz stimmen
        /// Bedingungen:
        ///     Wochentags (nur bei täglich)
        ///     Alle x Tage
        ///     Alle x Wochen
        ///     Bedarfsmedikamente werden weder vorbereitet noch abgegeben
        ///     "Ärztliche Vorbereitung" wird nicht vorbereitet nur abgegeben
        ///     Herrichten "nein" bedeutet dass das Medikament unmittelbar bei der Abgabe hergerichtet wird (Augentropfen)
        ///     Alles außer Bedarfsmedikamente werden in der GUI gefiltert
        private bool RandbedingungOK(dsMedikationVonBis.MedikationRow r, DateTime dt, DateTime dtbis, MedikationListenMode mode)
        {
            if (r.Herrichten == (int)medHerrichten.beiBedarf)
                return false;

            //Verschreibungszeitraum berücksichtigen
            //os191202
            if (r.AbzugebenVon > dtbis || r.AbzugebenBis < dt)
                return false;

            if (dt.Date == r.AbzugebenVon.Date && dt.TimeOfDay > r.AbzugebenVon.TimeOfDay)
                return false;

            //if (r.AbzugebenVon > dt || r.AbzugebenBis < dt)                         
            //    return false;

            medWiederholungstypen wtype = (medWiederholungstypen)r.Wiederholungstyp;
            switch (wtype)
            {
                case medWiederholungstypen.taeglich:                                        // Bei täglich gibt es die Einschränkung MO-SO
                    if (!PMDS.Global.Tools.IsAllowedWeekDay(dt, r.Wochentage))
                        return false;
                    return true;

                case medWiederholungstypen.alle_x_Tage_Wochen:
                    medWiederholungseinheiten we = (medWiederholungseinheiten)r.Wiederholungseinheit;

                    int iTage = 0;
                    if (we == medWiederholungseinheiten.tage)
                    {
                        iTage = (int)r.Wiederholungswert;
                        TimeSpan span = dt - r.AbzugebenVon;
                        if (span.Days % iTage == 0)
                            return true;
                        return false;
                    }
                    else if (we == medWiederholungseinheiten.Wochen)
                    {
                        iTage = (int)r.Wiederholungswert * 7;
                        if (r.Wochentage == 127)   // an jedem Tage der Woche möglich
                        {
                            TimeSpan span = dt - r.AbzugebenVon;
                            if (span.Days % iTage == 0)
                                return true;
                            return false;
                        }
                        else                //nur an bestimmten Tagen der Woche
                        {
                            //Wochenbeginn ermitteln, in der das Medikament angesetzt wurde
                            //Wochenbeginn der aktuellen Woche ermitteln
                            //Wenn Wochenbeginn eine Woche ist, in der das Medikament abgeben ist, prüfen, ob Tag Erlaubt ist

                            DateTime WochenbeginnAngesetzt = r.AbzugebenVon;
                            while (WochenbeginnAngesetzt.DayOfWeek != DayOfWeek.Monday)
                                WochenbeginnAngesetzt = WochenbeginnAngesetzt.Subtract(new TimeSpan(1, 0, 0, 0));

                            DateTime WochenbeginnAktuell = dt;
                            while (WochenbeginnAktuell.DayOfWeek != DayOfWeek.Monday)
                                WochenbeginnAktuell = WochenbeginnAktuell.Subtract(new TimeSpan(1, 0, 0, 0));

                            TimeSpan span = WochenbeginnAktuell - WochenbeginnAngesetzt;
                            if (span.Days % iTage == 0)   // Woche passt
                            {
                                if (!PMDS.Global.Tools.IsAllowedWeekDay(dt, r.Wochentage))
                                    return false;           //Wochentag passt nicht -> nicht abgeben
                                return true;
                            }
                            return false;
                        }

                    }
                    else if (we == medWiederholungseinheiten.Monate)
                    {

                        int Monate = (dt.Year * 12 + dt.Month) - (r.AbzugebenVon.Year * 12 + r.AbzugebenVon.Month);
              
                        if (Monate % r.Wiederholungswert == 0 && dt.Day == r.AbzugebenVon.Day)
                            return true;
                        return false;
                    
                    }
                    return false;

                case medWiederholungstypen.jeden_xten_desMonat:
                    if (dt.Day == r.Wiederholungswert)
                        return true;
                    return false;

                    
                default:
                    break;
            }

            return true;
        }
        
        //	Liefert true wenn eine Medikation bereits abgegeben wurde
        public static AbgegebenHelper IsAbgegeben(Guid IDRezeptEintrag, DateTime dt)
        {
            return DBMedikation.IsAbgegeben(IDRezeptEintrag, dt);
        }

        //	Eine Abgabe verspeichern
        public static void InsertMedikationAbgabe(Guid IDRezeptEintrag, DateTime dt, Guid IDBenutzer, string MedikamentText, Guid IDaufenthalt, bool TagesspenderJN)
        {
            DBMedikation.InsertMedikationAbgabe(IDRezeptEintrag, dt, IDBenutzer, MedikamentText, IDaufenthalt, TagesspenderJN);
        }

    }

    public enum MedikationListenMode
    {
        Vorbereitung = 0,
        Abgabe
    }

}

