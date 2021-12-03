using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using PMDS.Data.Global;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Global.db.Global;

namespace PMDS.BusinessLogic
{
     public class Tools
    {
        public Tools()
        {
        }



        // Liefert die gesetzten Wochentage in Kurzform
        private static string Wochentage(int iWochentage)
        {
            StringBuilder sb = new StringBuilder();
            for (int day = 0; day < ENV.WochentagekurzMoBeginnend.Length; day++)
            {
                if ((iWochentage & (1 << day)) != 0)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(ENV.WochentagekurzMoBeginnend[day]);
                }
            }
            return sb.ToString();
        }

        // Liefert den String in Abhängigkeit der Wiederholungen
        private static void AppendWiederholungen(medWiederholungstypen wtype, medWiederholungseinheiten einh, double wert, int Wiederholungswert, StringBuilder sb)
        {
            switch (wtype)
            {
                case medWiederholungstypen.taeglich:
                    if (Wiederholungswert == 127)
                        sb.Append(ENV.String("WIEDERHOLUNGSTYP_T") + " ");      
                    break;
                case medWiederholungstypen.alle_x_Tage_Wochen:
                    sb.Append(ENV.String("WIEDERHOLUNGSTYP_A"));                
                    sb.Append(" " + wert.ToString() + " ");
                    switch (einh)
                    {
                        case medWiederholungseinheiten.tage:
                            sb.Append("Tage ");                             //-IntVers=NoTranslation
                            break;
                        case medWiederholungseinheiten.Wochen:
                            sb.Append("Wochen ");
                            break;
                        case medWiederholungseinheiten.Monate:
                            sb.Append("Monate ");
                            break;
                    }
                    break;
                case medWiederholungstypen.jeden_xten_desMonat:
                    sb.Append(ENV.String("WIEDERHOLUNGSTYP_J", wert.ToString()) + " ");
                    break;
            }
        }
        
        // Liefert einen String in Form von täglich, nur am MO, Morgens:3 /Abends:2 Stück
        public static string ToStringFromRezepteintragRow(dsRezeptEintrag.RezeptEintragRow row)
        {
            return ToStringFromRow(row, true);
        }

        /// Liefert einen String in Form von täglich, nur am MO, Morgens:3 /Abends:2 Stück
        public static string ToStringFromMediaktionRow(dsMedikationVonBis.MedikationRow row)
        {
            return ToStringFromRow(row, false);
        }

        // Liefert einen String in Form von täglich, nur am MO, Morgens:3 /Abends:2 Stück
        // !bAppendWiederholungen: nur Zeiten ohne Standardtext für untertägige.
        //                        nüchtern wird ausgeschrieben.
        private static string ToStringFromRow(DataRow row, bool bAppendWiederholungen)
        {
            StringBuilder               sb = new StringBuilder();
            medWiederholungstypen       row_Wiederholungstyp        = (medWiederholungstypen)row["Wiederholungstyp"];
            medWiederholungseinheiten   row_Wiederholungseinheit    = (medWiederholungseinheiten)row["Wiederholungseinheit"];
            double                      row_Wiederholungswert       = (double)row["Wiederholungswert"];
            int                         row_Wochentage              = (int)row["Wochentage"];

            bool bBedarfsMedikationJN   = (bool)row["BedarfsMedikationJN"];
            bool bStandardzeiten        = (bool)row["StandardzeitenJN"];
            bool bnuechtern = ((double)row["ZP0"] != 0 && bStandardzeiten);  



            StringBuilder sbTimes = new StringBuilder();
            StringBuilder sbNüchtern = new StringBuilder();

            //<20120216>

            if (bnuechtern)
            {
                sbNüchtern.Append(Standardzeiten.StandardzeitenStrings[0] + " ");
                sbNüchtern.Append(row["ZP0"].ToString() + " ");

                if (!bStandardzeiten)
                    sbNüchtern.Append(((DateTime)row["Zeitpunkt0"]).ToString("HH:mm"));
            }

            sb.Append(sbNüchtern);
            sb.Append(" ");


            if (bAppendWiederholungen)
            {
                for (int im = 1; im <= 4; im++)          //nur mo-mi-ab-na 
                {
                    string sCol = string.Format("ZP{0}", im);
                    string sCol2 = string.Format("Zeitpunkt{0}", im);

                    //if (row.IsNull(sCol) || (double)row[sCol] == 0 || (row.IsNull(sCol2) && !bStandardzeiten))
                    //    continue;

                    if (bStandardzeiten)
                    {
                        //sbTimes.Append(Standardzeiten.StandardzeitenStrings[im]);
                        if (sbTimes.Length > 0) sbTimes.Append(" - ");
                        sbTimes.Append("");
                        sbTimes.Append(ConvertFractalsToString((double)row[sCol]));
                    }
                    else
                    {
                        if (isDate(row[sCol2].ToString()))
                        {
                            if (sbTimes.Length > 0) sbTimes.Append(" - ");
                            sbTimes.Append("(");
                            sbTimes.Append(((DateTime)row[sCol2]).ToString("HH:mm"));
                            sbTimes.Append(") ");
                            sbTimes.Append(ConvertFractalsToString((double)row[sCol]));
                        }
                    }

                    //if (bStandardzeiten)
                    //    //sbTimes.Append(":");
                    //    sbTimes.Append("");
                    //else
                    //    sbTimes.Append(" - ");

                    //sbTimes.Append(row[sCol].ToString());
                }
            }
            else
            { 
                if (row["Zeitpunkt0"] is DBNull)
                {
                }
                else
                {
                    sbTimes.Append(((DateTime)row["Zeitpunkt0"]).ToString("HH:mm"));        //Für Verabreichung. Zeit steht immer in Zeitpunkt0
                }
            }

            if (sbTimes.ToString() != "0 - 0 - 0 - 0")
            {
                sb.Append(sbTimes);
            }
            else
            {
                if (!bnuechtern) 
                    sb.Append("Dosierung beachten!");
            }

            sb.Append(" ");
            
            if (bAppendWiederholungen)
            {
                if (bBedarfsMedikationJN)
                {
                    sb.Append("Einzelverordnung");

                    if (ENV.UseEinzelverordnungEinfach)
                    {
                        sb.Clear();
                        sb.Append("Einzelverordnung: Einzeldosis = " + ConvertFractalsToString((double)row["ZP5"]) + " " + row["Einheit"] +  ", maximal " + ConvertFractalsToString((double)row["ZP6"]) + " " + row["Einheit"] + " in 24 Stunden");
                    }
                }
                else
                    AppendWiederholungen(row_Wiederholungstyp, row_Wiederholungseinheit, row_Wiederholungswert, row_Wochentage, sb);
            }

            if (row_Wochentage != 127 && (row_Wiederholungstyp == medWiederholungstypen.taeglich || row_Wiederholungstyp == medWiederholungstypen.alle_x_Tage_Wochen) && bAppendWiederholungen)
            {
                if (row_Wochentage != 0)
                {
                    sb.Append("nur am ");
                    sb.Append(Wochentage(row_Wochentage));
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }
        
        public static string ConvertFractalsToString (double dMenge)
        {

            try
            {
                string strMenge = "";
                if (dMenge == 0.125)
                {
                    strMenge = "1/8";
                }
                else if (dMenge == 0.25)
                {
                    strMenge = "1/4";
                }
                else if (dMenge == 0.33) 
                {
                    strMenge = "1/3";
                }
                else if (dMenge == 0.5)
                {
                    strMenge = "1/2";
                }
                else if (dMenge == 0.66)
                {
                    strMenge = "2/3";
                }
                else if (dMenge == 0.75)
                {
                    strMenge = "3/4";
                }
                else
                {
                    strMenge = dMenge.ToString();
                }
                return strMenge;
            }
            catch
            {
                return "Signatur prüfen.";
            }

        }

        public static string GetBankVerbindung( dsBank.BankRow rBank)
        {
            StringBuilder sbBank = new StringBuilder();
                        
            sbBank.Append(rBank.Bezeichnung);
            sbBank.Append(", " + QS2.Desktop.ControlManagment.ControlManagment.getRes("BLZ") + " " + rBank.BLZ.ToString() + ", " + QS2.Desktop.ControlManagment.ControlManagment.getRes(", Kto.Nr ") + " ");      
            sbBank.Append(rBank.Kontonummer.ToString());
            return sbBank.ToString();
        }

         // Klinik Logo in Datarow verschpeichern
         public static void FillHeimLogo(DataRow r, string ColumnName)
         {
             try
             {
                 // Klinik Logo aus Datei auslesen
                 System.IO.FileStream FilStr = new System.IO.FileStream("KlinikLogo.bmp", System.IO.FileMode.Open);
                 System.IO.BinaryReader BinRed = new System.IO.BinaryReader(FilStr);
                 //Adding the values to the columns
                 // adding the image path to the path column

                 //Important:
                 // Here you use ReadBytes method to add a byte array of the image stream.
                 //so the image column will hold a byte array.
                 r[ColumnName] = BinRed.ReadBytes((int)BinRed.BaseStream.Length);
                 FilStr.Close();
                 BinRed.Close();
             }
             catch
             {
             }
         }

         public static bool isDate(String date)
         {
             DateTime Temp;
             if (DateTime.TryParse(date, out Temp) == true)
                 return true;
             else
                 return false; 
         }
        
    }
}
