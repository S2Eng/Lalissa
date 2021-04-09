using Microsoft.Win32;
using PMDS.Global;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMDS.GUI.ELGA
{
    public class clsELGAPrint
    {

        private string PDFName;
        private Process processCDA2PDF = new Process();

        public void ConvertCDA2PDF(MemoryStream msXML, string sFileName)
        {
            try
            {
                //Java-Runtime prüfen
                string JavaVersion = "";
                int JavaVersionMajor_Min = 1;
                int JavaVersionMinor_Min = 8;
                try
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo();
                    procStartInfo.FileName = "java.exe";
                    procStartInfo.Arguments = " -version";
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.RedirectStandardError = true;
                    procStartInfo.UseShellExecute = false;
                    Process pr = Process.Start(procStartInfo);
                    JavaVersion = pr.StandardError.ReadLine().Split(' ')[2].Replace("\"", "");

                    string[] JavaVersionInfo = JavaVersion.Split('.');
                    if (Convert.ToInt32(JavaVersionInfo[0]) < JavaVersionMajor_Min && Convert.ToInt32(JavaVersionInfo[1]) < JavaVersionMinor_Min)
                    {
                        MessageBox.Show("Java Runtime-Umgebung muss mindestens " + JavaVersionMajor_Min.ToString() + "." + JavaVersionMinor_Min.ToString() + " sein. Das CDA-Dokument kann nicht als PDF konvertiert werden.", "Hinweis");
                    }
                }
                catch (System.ComponentModel.Win32Exception ex)
                {
                    MessageBox.Show("Java Runtime-Umgebung fehlt. Das CDA-Dokument kann nicht als PDF konvertiert werden.", "Hinweis");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Fehler beim Ermitteln der Java Runtime Version. Das CDA-Dokument kann nicht als PDF konvertiert werden.", "Hinweis");
                }

                sFileName = (String.IsNullOrWhiteSpace(sFileName) ? Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()) : sFileName);

                //CDA-Dokument auf Platte schreiben
                using (FileStream fs = new FileStream(sFileName, FileMode.Create))
                {
                    msXML.Position = 0;
                    msXML.CopyTo(fs);
                    fs.Flush();
                }

                //Ausgabepfad festlegen
                PDFName = Path.Combine(Path.GetDirectoryName(sFileName), Path.GetFileNameWithoutExtension(sFileName) + ".PDF");
                string pars = sFileName + " " + PDFName + " " + ENV.ActiveUser.Benutzer1;
                bool bConvertOk = false;

                //CDA-File in PDF-File konvertieren
                if (File.Exists(Path.Combine(ENV.path_bin, "S2_CDA2PDF.jar")))
                {
                    processCDA2PDF = Process.Start(Path.Combine(ENV.path_bin, "S2_CDA2PDF.jar"), pars);
                    processCDA2PDF.WaitForExit(20000);
                    bConvertOk = processCDA2PDF.ExitCode == 0 && File.Exists(PDFName);
                }
                else if (File.Exists(Path.Combine(ENV.path_bin, "S2_CDA2PDF.exe")))
                {
                    processCDA2PDF = Process.Start(Path.Combine(ENV.path_bin, "S2_CDA2PDF.exe"), pars);
                    Cursor.Current = Cursors.WaitCursor;
                    int i = 20;
                    while (!File.Exists(PDFName) && i > 0)      //Process.WaitForExit funktioniert nicht, weil der Wrapper für das jar immer sofort 0 zurückgibt
                    {
                        System.Threading.Thread.Sleep(1000);
                        i--;
                    }
                    Cursor.Current = Cursors.Default;
                    bConvertOk = File.Exists(PDFName);
                }
                else
                {
                    MessageBox.Show("CDA-Dokumentenkonverter (jar oder exe) fehlt. Das CDA-Dokument kann nicht als PDF konvertiert werden.", "Hinweis");
                }

                if (bConvertOk)
                {
                    PMDS.GUI.BaseControls.frmPDF frmPDF = new PMDS.GUI.BaseControls.frmPDF();       //no using! - schließt den Viewer sofort nach Show()
                    if (frmPDF.OpenPDFFromByte(File.ReadAllBytes(PDFName)))
                    {
                        frmPDF.SetCaption = "";
                        frmPDF.ShowBookmarks = false;
                        frmPDF.ShowOpenDialog = false;
                        frmPDF.ShowPrintDialog = true;
                        frmPDF.ShowSaveDialog = true;
                        frmPDF.RemoveFileBeforeClose = true;
                        frmPDF.FileNamesToRemove = new List<string>(new[] { sFileName, PDFName });
                        frmPDF.Show();
                    }
                }
                else
                {
                    MessageBox.Show("CDA-Dokument kann nicht als PDF konvertiert werden.", "Hinweis");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unerwarteter Fehler bei CDA2PDF-Konverter: " + ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                if (processCDA2PDF != null)
                {
                    string x = "";
                }
                    //processCDA2PDF.Kill();
            }
        }

        public void ShowXMLInBrowser(MemoryStream msXML, string sFileName, bool UseCDAStyleSheet)
        {
            try
            {                
                sFileName = (String.IsNullOrWhiteSpace(sFileName) ? Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString()) : sFileName);
                object path;
                List<string> browsers = new List<string>();

                List<string> chkBrowsers = new List<string> { "firefox.exe", "chrome.exe", "IExplore.exe", "Edge.exe" };
                List<string> chkRegs = new List<string> { "LOCAL_MACHINE", "CURRENT_USER" };

                foreach (string cBrowser in chkBrowsers)
                {
                    foreach (string cReg in chkRegs)
                    {
                        path = Registry.GetValue(@"HKEY_" + cReg + @"\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + cBrowser, "", null);
                        if (path != null)
                        {
                            Console.WriteLine(cBrowser + ": " + FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
                            browsers.Add(path.ToString());
                        }

                    }
                }

                browsers.Clear();
                using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
                {
                    RegistryKey webClientsRootKey = hklm.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                    if (webClientsRootKey != null)
                    {
                        try
                        {
                            foreach (var subKeyName in webClientsRootKey.GetSubKeyNames())
                            {
                                browsers.Add((string)webClientsRootKey.OpenSubKey(subKeyName).OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue(null));
                            }
                        }
                        catch (Exception ex)
                        {
                            //Browser ist nicht geeignet. Nicht zur Liste hinzufügen.
                        }
                    }
                }

                if (browsers.Count > 0)
                {
                    using (FileStream fs = new FileStream(sFileName, FileMode.Create))
                    {
                        msXML.Position = 0;
                        msXML.CopyTo(fs);
                        fs.Flush();
                    }

                    string sCheckXSLT = (UseCDAStyleSheet ? clsELGAPrint.CopyXSLT(sFileName) : ""); 
                    if (String.IsNullOrWhiteSpace(sCheckXSLT))
                    {
                        foreach (string sBrowser in browsers)
                        {
                            if (PMDS.Global.generic.sEquals(sBrowser,"FIREFOX", Enums.eCompareMode.Contains))
                            {
                                string firefox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Mozilla\Firefox\Profiles");
                                if (Directory.Exists(firefox))
                                {
                                    FileInfo di = new DirectoryInfo(firefox).GetDirectories()[0].GetFiles("prefs.js")[0];
                                    StreamReader sr = di.OpenText();
                                    using (RichTextBox rb = new RichTextBox())
                                    {
                                        rb.Text = sr.ReadToEnd();
                                        sr.Close();
                                        string[] s = rb.Lines;
                                        for (int i = 0; i < rb.Lines.Length; i++)
                                        {
                                            if (generic.sEquals(rb.Lines[i], "user_pref(\"privacy.file_unique_origin\", \"true\");"))
                                            {
                                                s[i] = "user_pref(\"privacy.file_unique_origin\", \"false\");";
                                                System.IO.File.Delete(di.FullName);
                                                System.IO.File.WriteAllLines(di.FullName, s);
                                                System.Diagnostics.Process.Start(sBrowser, sFileName);
                                                break;
                                            }
                                        }
                                    }
                                    System.Diagnostics.Process.Start(sBrowser, sFileName);
                                    return;
                                }
                            }
                            else if (generic.sEquals(sBrowser, "IEXPLORE", Enums.eCompareMode.Contains))
                            {
                                System.Diagnostics.Process.Start(sBrowser, sFileName);
                                return;
                            }
                            else if (generic.sEquals(sBrowser, "CHROME", Enums.eCompareMode.Contains) || generic.sEquals(sBrowser, "EDGE", Enums.eCompareMode.Contains))
                            {
                                
                                Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")); //Windows Script Host Shell Object
                                dynamic shell1 = Activator.CreateInstance(t);
                                try
                                {
                                    var startupFolderPath1 = ENV.path_Temp;
                                    var shortCutLinkFilePath1 = Path.Combine(startupFolderPath1, "PSB.lnk");
                                    var lnk = shell1.CreateShortcut(shortCutLinkFilePath1);
                                    try
                                    {
                                        lnk.Description = "Link für Anzeige Pflegesituationsbericht";
                                        lnk.WorkingDirectory = ENV.path_Temp;
                                        lnk.TargetPath = sBrowser; // + " --allow-file-access-from-files ";
                                        lnk.Arguments = "--allow-file-access-from-files";
                                        lnk.Save();
                                        System.Diagnostics.Process.Start(shortCutLinkFilePath1, sFileName);
                                        System.IO.File.Delete(shortCutLinkFilePath1);
                                    }
                                    finally
                                    {
                                        Marshal.FinalReleaseComObject(lnk);
                                    }
                                }
                                finally
                                {
                                    Marshal.FinalReleaseComObject(shell1);
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Bitte verwenden Sie Firefox, Chrome, Internet Explorer oder Edge (Chromium).", "Hinweis");
                            }
                        }
                    }
                    else 
                    {
                        MessageBox.Show(sCheckXSLT, "Hinweis");
                    }
                }
                else
                {
                    MessageBox.Show("Für die Anzeige muss ein geeigneter Browser (Firefox, Chrome, Internet Explorer oder Edge (Chromium)) verfügbar sein.", "Hinweis");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsELGAPrint.ShowXMLInBrowser: " + ex.ToString());
            }
        }

        private static string CopyXSLT(string sFileName)
        {
            try
            {
                string[] stylesheets = Directory.GetFiles(ENV.pathConfig, "*.xsl");

                foreach (string stylesheet in stylesheets)
                {
                    string nXSLT = Path.GetFileName(stylesheet);
                    string fXSLT = Path.Combine(ENV.pathConfig, nXSLT);
                    string dDest = System.IO.Path.GetDirectoryName(sFileName);
                    string fDest = Path.Combine(dDest, nXSLT);

                    FileInfo fiSource = new FileInfo(fXSLT);
                    FileInfo fiDest = new FileInfo(fDest);

                    //Prüfen, ob Stylesheet kopiert oder aktualisert werden muss
                    if (!fiDest.Exists || fiDest.Length != fiSource.Length)
                    {
                        File.Copy(fXSLT, fDest, true);
                        //Prüfen, ob Kopieren / Ersetzen erfolgreich war
                        fiDest = new FileInfo (fDest);
                        if (!fiDest.Exists || fiDest.Length != fiSource.Length)
                            return "Fehler beim Kopieren des Stylesheets " + nXSLT + ": Konnte nicht kopiert werden.";
                    }
                }
                return "";
            }
            catch (UnauthorizedAccessException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (ArgumentException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (PathTooLongException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (DirectoryNotFoundException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (FileNotFoundException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (IOException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (NotSupportedException ex)
            {
                return "Fehler beim Kopieren des Stylesheets: " + ex.Message;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CopyXSLT: " + ex.ToString());
            }
        }
    }
}
