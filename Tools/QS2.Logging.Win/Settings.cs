using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QS2.Logging
{
    public class Settings
    {

        public static string _path_log = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static bool _SystemIsInitialized = false;
        public static bool _adminSecure = false;

        public static void init(string path_log, bool SystemIsInitialized, bool adminSecure)
        {
            try
            {
                if (!Settings._SystemIsInitialized)
                {
                    Settings._path_log = path_log;
                    Settings._SystemIsInitialized = SystemIsInitialized;
                    Settings._adminSecure = adminSecure;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "QS2 - Error QS2.Logging.init::ex2");
            }
        }

        public static void doLog(string ex, string title, string usr, bool germanTxt = false)
        {
            try
            {
                if (!QS2.Logging.Settings._SystemIsInitialized)
                {
                    MessageBox.Show(title.Trim() + "\r\n" + ex.Trim() + "\r\n" + "\r\n" + "System is not initialized!", "QS2 - Error");
                }
                else
                {
                    bool errPath = false;
                    if (QS2.Logging.Settings._path_log.Trim().Equals(""))
                    {
                        errPath = true;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(QS2.Logging.Settings._path_log))
                        {
                            try
                            {
                                System.IO.Directory.CreateDirectory(QS2.Logging.Settings._path_log);
                            }
                            catch (Exception ex2)
                            {
                                errPath = true;
                            }
                        }
                    }

                    if (!errPath)
                    {
                        QS2.Logging.frmError frmErr = new QS2.Logging.frmError();
                        if (germanTxt)
                        {
                            frmErr.ucError1.germanTxt = true;
                            frmErr.ucError1.setGermanUI();
                        }
                        else
                        {
                            frmErr.ucError1.setUIEnglish();
                        }
                        frmErr.setData(title, ex, "", true);
                        frmErr.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(title.Trim() + "\r\n" + ex.Trim(), "QS2 - Error");
                    }

                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex.ToString(), "QS2 - Error QS2.Logging.doLog::ex2");
            }
        }

        public static void doLog2(string exOr, DateTime time, string MachineName, string IPAdress, string usr, string sType, 
                                    bool germanTxt = false, bool ShowMsgBox = true,
                                    string TitleAlternative = "")
        {
            string CrHtml = "<br/>";          //"<br/>";     "\r\n";
            string exShort = exOr;
            string sInfoExcep1 = "Time: " + time.ToString() + ", Machine: " + MachineName.Trim() + ", IPAdress: " + IPAdress.Trim() + ", User: " + usr.Trim() + ", Type: " + sType.Trim();
            string exLong = exOr + CrHtml + CrHtml + sInfoExcep1 + CrHtml + CrHtml + TitleAlternative + CrHtml;
            try
            {
                if (!QS2.Logging.Settings._SystemIsInitialized)
                {
                    MessageBox.Show(exLong.Trim() + "\r\n" + "\r\n" + "System is not initialized!", "QS2 - Error");
                }
                else
                {
                    bool errPath = false;
                    if (QS2.Logging.Settings._path_log.Trim().Equals(""))
                    {
                        errPath = true;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(QS2.Logging.Settings._path_log.Trim()))
                        {
                            try
                            {
                                System.IO.Directory.CreateDirectory(QS2.Logging.Settings._path_log.Trim());
                                System.GC.Collect();
                            }
                            catch (Exception ex2)
                            {
                                errPath = true;
                            }
                        }
                    }

                    if (!errPath)
                    {
                        string txtLog = "<Entry>" + "\r\n";
                        txtLog += "<Time>" + time.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                        txtLog += "<Machine>" + MachineName.Trim() + "\r\n";
                        txtLog += "<IPAdress>" + IPAdress.Trim() + "\r\n";
                        txtLog += "<User>" + usr.Trim() + "\r\n";
                        txtLog += "<Text>" + exShort.Trim() + "\r\n";
                        txtLog += "<Type>" + sType.Trim() + "\r\n";
                        txtLog += "<EndEntry>" + "\r\n" + "\r\n";

                        bool ErrorWriteLog = false;
                        string sErrorWriteLog = "";
                        try
                        {
                            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(QS2.Logging.Settings._path_log.Trim(), "Log_" + System.Environment.MachineName.Trim() + "" + ".logQS2"), true))
                            {
                                outputFile.WriteLine(txtLog);
                            }
                        }
                        catch (Exception ex4)
                        {
                            sErrorWriteLog = ex4.ToString();
                            ErrorWriteLog = true;
                        }
                        if (ErrorWriteLog)
                        {
                            exLong = exLong + "\r\n" + "\r\n" + sErrorWriteLog;
                        }

                        if (ShowMsgBox)
                        {
                            QS2.Logging.frmError frmErr = new QS2.Logging.frmError();
                            if (germanTxt)
                            {
                                frmErr.ucError1.germanTxt = true;
                                frmErr.ucError1.setGermanUI();
                            }
                            else
                            {
                                frmErr.ucError1.setUIEnglish();
                            }
                            frmErr.setData(sInfoExcep1, exLong, "", false);
                            if (TitleAlternative.Trim() != "")
                            {
                                frmErr.ucError1.lblMessageGerman.Text = "Es ist ein Problem aufgetreten:" + "\r\n" + TitleAlternative.Trim();
                            }
                            frmErr.ShowDialog();

                        }
                    }
                    else
                    {
                        MessageBox.Show(exLong.Trim(), "QS2 - Error");
                    }

                }

            }
            catch (Exception ex2)
            {
                MessageBox.Show(exLong.ToString(), "QS2 - Error QS2.Logging.doLog::ex2");
            }
        }


    }
}
