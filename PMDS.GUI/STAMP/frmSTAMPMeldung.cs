using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S2Extensions;

namespace PMDS.GUI.STAMP
{
    public partial class frmSTAMPMeldung : Form
    {
        private   PMDS.Global.db.cSTAMPInterfaceDB STAMP = new PMDS.Global.db.cSTAMPInterfaceDB();
        private PMDS.Global.db.cSTAMPInterfaceDB.Bewohnerliste lBew = new Global.db.cSTAMPInterfaceDB.Bewohnerliste();

        public frmSTAMPMeldung()
        {
            InitializeComponent();
            this.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32);
            this.dtMonat.MaxDate = DateTime.Now;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.btnSenden.Enabled = false;
            this.rtbLog.Visible = true;
            rtbLog.Text = "";

            if (!PMDS.Global.ENV.lic_STAMP)
            {
                rtbLog.Text = "Sie haben keine Lizenz für diese Funktion.";
                return;
            }

            if (!Environment.MachineName.sEquals("sty041"))
            {
                if (String.IsNullOrWhiteSpace(PMDS.Global.ENV.STAMP_Traeger) || String.IsNullOrWhiteSpace(PMDS.Global.ENV.STAMP_Standort))
                {
                    rtbLog.Text = "Ihre STAMP-Träger-ID (" + PMDS.Global.ENV.STAMP_Traeger + ") oder STAMP-Standort-ID (" + PMDS.Global.ENV.STAMP_Standort + ") ist leer.\nBitte tragen Sie die Werte in der Konfigurationsdatei ein.";
                    return;
                }
            }

            if (STAMP.Init(this.dtMonat.DateTime))
            {
                lBew = STAMP.LoadBewohnerliste();
                if (!lBew.IsInitialized)
                {                    
                    this.rtbLog.Text = lBew.sbLog.ToString();   //unerwarteter Fehler (Exception)
                }
                else
                {

                    this.btnSenden.Enabled = true;


                    STAMP.CheckAll(ref lBew);
                    if (lBew.HasErrors) //Logikfehler -> nicht weiter machen
                    {
                        this.rtbLog.Text = "Bitte korrigieren Sie die nachfolgenden Fehler, um fortfahren zu können:\n\n" + lBew.sbLog.ToString();
                       // this.btnSenden.Enabled = false;
                    }
                    else
                    {
                        this.rtbLog.Text = "Kein logischer Fehler. Die Daten können jetzt gesendet werden: \n\n";    //Weitermachen
                        foreach (PMDS.Global.db.cSTAMPInterfaceDB.Bewohnerdaten bew in lBew.bewohnerdaten)
                        {
                            this.rtbLog.Text += bew.nachname + " " + bew.vorname + ", (" + (!String.IsNullOrWhiteSpace(bew.synonym) ? bew.synonym : "noch nicht gemeldet") + ")\n";
                        }
                       this.btnSenden.Enabled = true;

                        

                    }
                }
            }
            else
            {
                this.rtbLog.Text = "Fehler beim Initailisieren der Funktion. \nBitte überprüfen Sie das Datumsfeld. Es muss ein gültiges Datum ab 1.4.2022 und heute erfasst werden.";
            }
        }

        private void btnSenden_Click(object sender, EventArgs e)
        {
            Task<bool> res = STAMP.StartBewohnerMelden(Global.db.cSTAMPInterfaceDB.ServiceCallType.bewohnermelden, lBew);
            string y = "";
        }
    }
}
