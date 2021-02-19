using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    public partial class frmASZMZuordnung : QS2.Desktop.ControlManagment.baseForm 
    {
        public frmASZMZuordnung()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Runtime)
            {
                QS2.Desktop.ControlManagment.ControlManagment ControlManagment1 = new QS2.Desktop.ControlManagment.ControlManagment();
                ControlManagment1.autoTranslateForm(this);
            }
        }

        public Guid IDAbteilungVon
        {
            get { return ucASZMZuordnung1.IDAbteilungVon; }
            set { ucASZMZuordnung1.IDAbteilungVon = value; }
        }

        public Guid IDAbteilungFuer
        {
            get { return ucASZMZuordnung1.IDAbteilungFuer; }
            set { ucASZMZuordnung1.IDAbteilungFuer = value; }
        }

        public string Bezeichnung
        {
            get { return ucASZMZuordnung1.Bezeichnung; }
            set { ucASZMZuordnung1.Bezeichnung = value; }
        }

        public dsAbteilung.AbteilungDataTable Abteilungen
        {
            get { return ucASZMZuordnung1.Abteilungen; }
            set { ucASZMZuordnung1.Abteilungen = value;}
        }

        public bool LEERE_ASZMZuordnung
        {
            get { return ucASZMZuordnung1.LEERE_ASZMZuordnung; }
        }
    }
}