using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S2Extensions;

namespace PMDS.GUI.STAMP
{
    public partial class frmSTAMPMeldung : Form
    {
        private PMDS.Global.db.cSTAMPInterfaceDB STAMP = new PMDS.Global.db.cSTAMPInterfaceDB();
        private PMDS.Global.db.cSTAMPInterfaceDB.Bewohnerliste lBew = new Global.db.cSTAMPInterfaceDB.Bewohnerliste();

        public frmSTAMPMeldung()
        {
            InitializeComponent();
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            if (DateTime.Now >= new DateTime(2022, 5, 1))
            {
                this.dtMonat.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            }
            this.dtMonat.MaxDate = DateTime.Now;
            STAMP.LoadAll += () => LoadAll();
            STAMP.ShowLog += () => ShowLog();
            STAMP.SaveServiceResult += () => SaveServiceResult();
        }

        private void ShowLog()
        {
            rtbLog.Text = lBew.sbLog.ToString();
            rtbOhneSynonym.Text = lBew.sbLogNoSynonym.ToString();
            rtbOK.Text = lBew.sbLogOk.ToString();

            if (lBew.sbLogServiceCalls.ToString().Length != 0)
            {
                WriteLogToFile(lBew.ServiceLogID);
            }

            pnlLog.Visible = true;
            pnlOhneSynonym.Visible = true;
            pnlOK.Visible = true;
            Application.DoEvents();
        }

        private void SaveServiceResult()
        {
            btnCheck.Enabled = true;
            btnMelden.Enabled = false;
            btnSenden.Enabled = false;

            if (lBew.sbLog.Length != 0)
            {
                WriteLogToFile(lBew.ServiceLogID);
                rtbLog.Text = lBew.sbLog.ToString();
                rtbOhneSynonym.Clear();
                rtbOK.Clear();
            }
            else
            {
                //Fertig, erfolgreiche Übertragung
                rtbLog.Text = "Fertig! Alle Daten wurden erfolgreich übertragen und ein Protokoll wurde erstellt.\n.";
                WriteLogToFile(lBew.ServiceLogID);
                rtbLog.Text += ".\nSie können dieses Fenster jetzt schließen.";
            }
            Application.DoEvents();
        }

        private void  WriteLogToFile(string ServiceLogID)
        {
            string sLogFile = System.IO.Path.Combine(PMDS.Global.ENV.STAMP_LOG_Path, ServiceLogID);
            if (!PMDS.Global.generic.CheckDirWritable(sLogFile))
            {
                //Log anzeigen
                MessageBox.Show(lBew.sbLogServiceCalls.ToString());
                rtbLog.Text += ".\nDie Protkoll-Datei für den Serviceaufruf konnte wegen eines Schreibfehlers auf " + PMDS.Global.ENV.STAMP_LOG_Path + " nicht gesichert werden";
            }
            else
            {
                //Log auf die Festplatte schreiben
                System.IO.File.WriteAllText(sLogFile, lBew.sbLogServiceCalls.ToString());
                rtbLog.Text += "Die Protokoll-Datei wurde hier gespeichert: " + sLogFile;

            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.btnMelden.Enabled = false;
            this.btnSenden.Enabled = false;

            rtbLog.Text = "";

            if (!PMDS.Global.ENV.lic_STAMP)
            {
                MessageBox.Show("Sie haben keine Lizenz für diese Funktion.");
                return;
            }

            if (!PMDS.Global.ENV.HasRight(Global.UserRights.STAMPMeldung))
            {

                MessageBox.Show("Sie haben kein Recht für diese Funktion.");
                return;
            }

            if (STAMP.Init(this.dtMonat.DateTime))
            {
                LoadAll();
            }
            else
            {
                this.rtbLog.Text = "Fehler beim Initialisieren der Funktion. \nBitte überprüfen Sie das Datumsfeld. Es muss ein gültiges Datum ab 1.4.2022 und heute erfasst werden.";
            }
        }

        private void LoadAll() 
        {
            lBew.bewohnerdaten.Clear();
            lBew = STAMP.LoadBewohnerliste();
            if (!lBew.IsInitialized)
            {
                this.rtbLog.Text = lBew.sbLog.ToString();   //unerwarteter Fehler (Exception)
                this.btnMelden.Enabled = false;
                this.btnSenden.Enabled = false;
            }
            else
            {
                this.btnMelden.Enabled = true;
                this.btnSenden.Enabled = true;

                lBew.sbLog.Clear();
                lBew.sbLogOk.Clear();
                lBew.sbLogNoSynonym.Clear();
                lBew.sbLogServiceCalls.Clear();


                this.rtbLog.Clear();
                this.rtbOhneSynonym.Clear();
                this.rtbOK.Clear();

                STAMP.CheckAll(ref lBew);
                foreach (PMDS.Global.db.cSTAMPInterfaceDB.Bewohnerdaten bew in lBew.bewohnerdaten)
                {
                    if (!bew.HasError)
                    {
                        if (String.IsNullOrWhiteSpace(bew.synonym))
                        {
                            lBew.sbLogNoSynonym.Append(bew.nachname + " " + bew.vorname + "\n");
                            btnSenden.Enabled = false;
                        }
                        else
                        {
                            lBew.sbLogOk.Append(bew.nachname + " " + bew.vorname + "\n");
                        }
                    }
                }
                ShowLog();
            }
        }

        private void btnMelden_Click(object sender, EventArgs e)
        {
            //Geprüfte Daten vorhanden. Synonyme für neue Bewohner holen und in DB speichern
            lBew.sbLog.Clear();
            lBew.sbLogNoSynonym.Clear();
            lBew.sbLogOk.Clear();
            lBew.sbLogServiceCalls.Clear();
            //lBew.HasErrors = false;

            btnMelden.Enabled = false;
            btnSenden.Enabled = false;
            ShowLog();

            Task<bool> res = STAMP.CallService(Global.db.cSTAMPInterfaceDB.ServiceCallType.bewohnermelden, lBew);
        }

        private void btnSenden_Click(object sender, EventArgs e)
        {
            btnCheck.Enabled = true;
            btnMelden.Enabled = false;
            btnSenden.Enabled = false;

            lBew.sbLog.Clear();
            lBew.sbLogNoSynonym.Clear();
            lBew.sbLogOk.Clear();
            lBew.sbLogServiceCalls.Clear();
            lBew.HasErrors = false;
            Task<bool> res = STAMP.CallService(Global.db.cSTAMPInterfaceDB.ServiceCallType.bewohnerupdate, lBew);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private int linesPrinted;
        private string[] lines;

        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            using (Brush brush = new SolidBrush(rtbLog.ForeColor))
            {
                while (linesPrinted < lines.Length)
                {
                    e.Graphics.DrawString(lines[linesPrinted++],
                        rtbLog.Font, brush, x, y);
                    y += 15;
                    if (y >= e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
            }
            linesPrinted = 0;
            e.HasMorePages = false;
        }

        private void printDocument1_BeginPrint_1(object sender, PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = rtbLog.SelectedText.Split(param);
            }
            else
            {
                lines = rtbLog.Text.Split(param);
            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }
    }
}
