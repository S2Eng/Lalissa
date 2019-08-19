//----------------------------------------------------------------------------------------------
//  Erstellt am:	24.05.2007
//  Erstellt von:	MDA
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.Data.Patient;
using PMDS.Global.db.Patient;

namespace PMDS.GUI
{
    public partial class ucASZMZuordnung : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDAbteilungVon = Guid.Empty;
        private Guid _IDAbteilungFuer = Guid.Empty;
        private string _Bezeichnung = "";
        private dsAbteilung.AbteilungDataTable _Abteilungen;

        public ucASZMZuordnung()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAbteilungVon
        {
            get { return _IDAbteilungVon; }
            set { _IDAbteilungVon = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAbteilungFuer
        {
            get { return _IDAbteilungFuer; }
            set { _IDAbteilungFuer = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Bezeichnung
        {
            get { return _Bezeichnung; }
            set 
            { 
                _Bezeichnung = value;
                opt‹bernehmenLeereAnordnung.Items[0].DisplayText = string.Format(opt‹bernehmenLeereAnordnung.Items[0].DisplayText, _Bezeichnung);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public dsAbteilung.AbteilungDataTable Abteilungen
        {
            get { return _Abteilungen; }
            set 
            { 
                _Abteilungen = value;
                InitAbteilungen();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool LEERE_ASZMZuordnung
        {
            get { return (int)opt‹bernehmenLeereAnordnung.Value == 1; }
        }

        private void InitAbteilungen()
        {
            if (Abteilungen == null)
                return;

            cmbAbteilung.Items.Clear();

            foreach (dsAbteilung.AbteilungRow r in Abteilungen)
            {
                cmbAbteilung.Items.Add(r.ID, r.Bezeichnung);
            }
        }

        private void cmbAbteilung_ValueChanged(object sender, EventArgs e)
        {
            IDAbteilungFuer = (Guid)cmbAbteilung.Value;
        }

        private void ucASZMZuordnung_Load(object sender, EventArgs e)
        {
            opt‹bernehmenLeereAnordnung.Value = 0;
        }
    }
}
