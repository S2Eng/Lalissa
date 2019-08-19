using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PMDS.BusinessLogic;
using PMDS.Data.Global;
using Infragistics.Win;
using PMDS.Global.db.Global;

namespace PMDS.GUI
{
    public partial class ucPatientAerzte : QS2.Desktop.ControlManagment.BaseControl
    {
        private Guid _IDPatient;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDPatient
        {
            get { return _IDPatient; }
            set 
            { 
                _IDPatient = value;
                InitCmbAerzte();
            }
        }

        public Guid SelctedIDAerzte
        {
            get
            {
                if (cmbArzt.SelectedItem == null)
                    return Guid.Empty;

                return (Guid)cmbArzt.SelectedItem.DataValue;
            }
            set
            {
                foreach (ValueListItem item in cmbArzt.Items)
                {
                    if ((Guid)item.DataValue == value)
                    {
                        cmbArzt.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public ucPatientAerzte()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Liste der Ärzte aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void InitCmbAerzte()
        {
            if (IDPatient == Guid.Empty)
                return;

            Patient pat = new Patient(IDPatient);
            
            cmbArzt.Items.Clear();
            foreach (dsAerzte.AerzteRow r in pat.GetAllAerzte(DateTime.Now).Rows)
            {
                string arzt = r.Nachname.Trim() + " " + r.Vorname .Trim();
                cmbArzt.Items.Add(r.ID, arzt);
            }
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Liste der Ärzte aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void cmbArzt_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            frmAerzteEdit frm = new frmAerzteEdit();
            Aerzte aerzte = new Aerzte();
            aerzte.Read();

            aerzte.ReadByPatient(IDPatient);
            frm.CLASS_AERZTE = aerzte;
            DialogResult res = frm.ShowDialog();

            if (res != DialogResult.OK)
                return;


            DialogResult resDoppelterArzt;
         
            if (frm.CurrentArztRow != null)
            {
                foreach (dsPatientAerzte.PatientAerzteRow PatientaerzteRow in aerzte.PATIENTAERZTE.PatientAerzte.Rows)
                {
                    if (frm.CurrentArztRow.ID == PatientaerzteRow.IDAerzte)
                    {
                        resDoppelterArzt = QS2.Desktop.ControlManagment.ControlManagment.MessageBox("Der gewählte Arzt ist dem Bewohner bereits zugeordnet, wollen sie ihn trotzdem zuordnen ?",
                              "Dieser Arzt ist bereits zugeordnet",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);

                        if (resDoppelterArzt == DialogResult.No)
                        {
                            cmbArzt.Value = frm.CurrentArztRow.ID;
                            return;
                        }
                        if (resDoppelterArzt == DialogResult.Yes)
                        {
                            break;
                        }
                    }
                             
                }
                aerzte.NewPatientAerzte(frm.CurrentArztRow.ID);
                aerzte.Write();
                InitCmbAerzte();
                cmbArzt.Value = frm.CurrentArztRow.ID;
            }
        }
    }
}
