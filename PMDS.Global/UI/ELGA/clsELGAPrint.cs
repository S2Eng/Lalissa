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
        public void ShowXMLInBrowser(MemoryStream msXML, string sFileName, bool UseCDAStyleSheet)
        {
            try
            {
                sFileName = (String.IsNullOrWhiteSpace(sFileName) ? Path.GetTempFileName() : sFileName);
                object path;
                List<string> browsers = new List<string>();

                List<string> chkBrowsers = new List<string> { "firefox.exe", "chrome.exe", "IExplore.exe" };
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

                    clsELGAPrint clsELGAPrint = new clsELGAPrint();
                    int iCheckXSLT = (UseCDAStyleSheet ? clsELGAPrint.CopyXSLT(sFileName) : 0); 
                    if (iCheckXSLT == 0)
                    {
                        foreach (string sBrowser in browsers)
                        {
                            if (sBrowser.ToUpper().Contains("FIREFOX"))
                            {
                                string firefox = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla\\Firefox\\Profiles");
                                if (Directory.Exists(firefox))
                                {
                                    FileInfo di = new DirectoryInfo(firefox).GetDirectories()[0].GetFiles("prefs.js")[0];
                                    StreamReader sr = di.OpenText();
                                    RichTextBox rb = new RichTextBox();
                                    rb.Text = sr.ReadToEnd();
                                    sr.Close();
                                    string[] s = rb.Lines;
                                    for (int i = 0; i < rb.Lines.Length; i++)
                                    {
                                        if (rb.Lines[i].Equals("user_pref(\"privacy.file_unique_origin\", \"true\");"))
                                        {
                                            s[i] = "user_pref(\"privacy.file_unique_origin\", \"false\");";
                                            System.IO.File.Delete(di.FullName);
                                            System.IO.File.WriteAllLines(di.FullName, s);
                                            System.Diagnostics.Process.Start(sBrowser, sFileName);
                                            break;
                                        }
                                    }
                                    System.Diagnostics.Process.Start(sBrowser, sFileName);
                                    return;
                                }
                            }
                            else if (sBrowser.ToUpper().Contains("IEXPLORE"))
                            {
                                System.Diagnostics.Process.Start(sBrowser, sFileName);
                                return;
                            }
                            else if (sBrowser.ToUpper().Contains("CHROME") || sBrowser.ToUpper().Contains("EDGE"))   //Liest Dateien nur mit einem Link!
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
                    else if (iCheckXSLT == 1)
                    {
                        MessageBox.Show("Das erforderliche Stylesheet ist nicht verfügbar (Config!).\r\nDie korrekte Anzeige des Dokuments ist nicht möglich.", "Hinweis");
                    }
                    else if (iCheckXSLT == 2)
                    {
                        MessageBox.Show("Das temporäre Stylesheet kann nicht erstellt werden.\r\nDie korrekte Anzeige des Dokuments ist nicht möglich.", "Hinweis");
                    }
                }
                else
                {
                    MessageBox.Show("Für die Anzeige muss ein geeigneter Browser (Firefox, Chrome, Internet Explorer oder Edge (Chromium)) verfügbar sein.", "Hinweis");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.GenerateCDA: " + ex.ToString());
            }
        }

        private int CopyXSLT(string sFileName)
        {
            try
            {
                string nXSLT = "ELGA_Stylesheet_v1.0.xsl";
                string fXSLT = Path.Combine(ENV.pathConfig, nXSLT);
                string fDest = Path.Combine(System.IO.Path.GetDirectoryName(sFileName), nXSLT);
                if (System.IO.File.Exists(fXSLT))
                {
                    if (!System.IO.File.Exists(fDest))
                    {
                        System.IO.File.Copy(fXSLT, fDest, true);
                        if (System.IO.File.Exists(fDest))
                            return 0;
                        else
                            return 2;
                    }
                    else if (System.IO.File.Exists(fDest) && !PMDS.Global.Tools.IsFileLocked(new FileInfo(fDest)))
                    {
                        System.IO.File.Copy(fXSLT, fDest, true);
                        return 0;
                    }
                    return 2;
                }
                else
                    return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("ucELGAPrintPflegesituationsbericht.CopyXSLT: " + ex.ToString());
            }
        }

    }
}
