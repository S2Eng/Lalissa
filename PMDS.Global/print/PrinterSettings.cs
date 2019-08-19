using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Printing;
using Microsoft.Win32;
using System.Runtime.InteropServices;    //Für das Setzen des Standard-Druckers (Klientenbericht)
using System.IO;

using Bullzip.PdfWriter;






namespace PMDS.Print.CR
{
    public class PrinterSettings
    {

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool SetDefaultPrinter(string Name);

        public static bool SetDefaultPrinterName(string PrinterName)
        {
            return SetDefaultPrinter(PrinterName);

        }


        public static string GetDefaultPrinterName()
        {
            PrintDocument pd = new PrintDocument();
            return pd.PrinterSettings.PrinterName;
        }




        public static bool ConvertPdfToPdfA(string FilePdf, string FilePdfA)
        {

            try
            {
                string printerName = PdfUtil.DefaultPrinterName;
                string errorMessage = "";

                bool isError = false;

                PdfSettings settings = new PdfSettings();
                settings.PrinterName = printerName;
                settings.SetValue("Output", FilePdfA);
                settings.SetValue("ShowSettings", "never");
                settings.SetValue("ShowSaveAS", "never");
                settings.SetValue("ShowProgress", "no");
                settings.SetValue("ShowProgressFinished", "no");
                settings.SetValue("ShowPDF", "no");
                settings.SetValue("ConfirmOverwrite", "no");
                settings.SetValue("Format", "pdfa1b");

                // Get the name of a status file and delete it if it already exist
                string statusFileName = Path.Combine(Path.GetTempPath(), System.Guid.NewGuid().ToString());
                if (File.Exists(statusFileName))
                    File.Delete(statusFileName);
                settings.SetValue("StatusFile", statusFileName);
                settings.WriteSettings(PdfSettingsFileType.RunOnce);

                try
                {
                    PdfUtil.PrintFile(FilePdf, printerName);
                    PdfUtil.WaitForFile(statusFileName, 60000);
                    isError = !File.Exists(FilePdfA);
                }

                catch (Exception ex)
                {
                    isError = true;
                    errorMessage = ex.Message;
                }

                if (!isError)
                {
                    File.Delete(FilePdf);
                    if (File.Exists(statusFileName))
                        File.Delete(statusFileName);
                    return true;
                }
                else
                    return false;

            }

            catch (Exception ex)
            {
                throw new Exception("PrinterSettings.ConvertPdfToPdfA: " + ex.ToString());
            }
        }

      
        public static Boolean PrintToBullZip(string FileName, bool pdfa)
        {
            try
            {
                Boolean BullZipInstalled = false;
                for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
                {
                    if (System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].ToString().Equals("bullzip pdf printer", StringComparison.CurrentCultureIgnoreCase))
                    {
                        BullZipInstalled = true;
                        break;
                    }
                }



                if (BullZipInstalled)
                {
                    Bullzip.PdfWriter.PdfSettings bz = new Bullzip.PdfWriter.PdfSettings();
                    bz.Init();
                    bz.PrinterName = PdfUtil.DefaultPrinterName;
                    bz.SetValue("output", FileName);
                    bz.SetValue("suppresserrors", "no");
                    bz.SetValue("openfolder", "no");
                    bz.SetValue("rememberlastfilename", "no");
                    bz.SetValue("rememberlastfoldername", "no");
                    bz.SetValue("res", "150");
                    bz.SetValue("resx", "150");
                    bz.SetValue("resy", "150");
                    bz.SetValue("textalphabits", "4");
                    bz.SetValue("graphicsalphabits", "4");
                    bz.SetValue("linearize", "no");
                    bz.SetValue("usethumbs", "no");
                    bz.SetValue("macroscripttimeout", "120");
                    bz.SetValue("printencrypted", "no");
                    bz.SetValue("appendifexists", "no");
                    bz.SetValue("confirmoverwrite", "no");
                    bz.SetValue("usedefaultauthor", "no");
                    bz.SetValue("usedefaulttitle", "no");
                    bz.SetValue("rememberlastoptionset", "yes");
                    bz.SetValue("showsaveas", "never");
                    bz.SetValue("showsettings", "never");
                    bz.SetValue("showpdf", "never");
                    if (pdfa)
                        bz.SetValue("Format", "pdfa1b");
                    bz.WriteSettings(PdfSettingsFileType.RunOnce);

                    SetDefaultPrinterName(bz.PrinterName);
                }
                return BullZipInstalled;

            }
            catch (Exception ex)
            {
                throw new Exception("PrinterSettings.PrintToBullZip: " + ex.ToString());
            }

        }


        public static bool WaitForFile(string FileName)
        {
            //Warten, bis Ausgabedatei geschrieben wurde oder maximal 100 Sekunden
            bool FileWritten = false;
            for (int i = 1; i <= 100; i++)
            {
                FileWritten = true;
                while (!File.Exists(FileName))
                {
                    System.Threading.Thread.Sleep(1000);   //jeweils 1 Sekunden warten, bis PDF sicher geschrieben sind
                    FileWritten = false;
                }
            }
            return FileWritten;
        }



    }
}
