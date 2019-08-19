using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{
    
    public partial class ucPrintStammDatenBlatt : QS2.Desktop.ControlManagment.BaseControl
    {
        public delegate void PrintStammdatenDelegate(bool Freiheit, bool Versicherung, bool Med, bool Kontakt, bool Sachwalter, bool Arzt,bool Regelung,bool Pflegestufe,bool Kostentraeger,bool Verwahrung,bool Hilfsmittel,bool Dienstleister,bool Reha);
        public event PrintStammdatenDelegate btnPrintStammdatenKlicked;


        public ucPrintStammDatenBlatt()
        {
            InitializeComponent();            
        }
        //-----------------------------------------------------------------------------------------------------
        /// <summary>
        /// Property für Checkbox Freiheitsbeschränkung visibility  {{{eng}}} 24.10.2007
        /// </summary>
        //-----------------------------------------------------------------------------------------------------
        public bool chkFreiHeitVisible
        {
            get { return true; }
            set
            {
                chkFreiheitsbeschränkungen.Visible = value;
                chkHilfsmittel.Visible = value;
                chkKostentraeger.Visible = value;
                chkVerwahrung.Visible = value;

                pnlPrintStammDatenBlatt.Height =(value ? 197 :  172);
            }           
        }                     
               
        private void btnPrintStammdaten_Click(object sender, EventArgs e)
        {   
            btnPrintSettings.CloseUp();

            if (btnPrintStammdatenKlicked != null)
                btnPrintStammdatenKlicked(chkFreiheitsbeschränkungen.Checked, chkVersicherungsdaten.Checked, chkMedizinischeDaten.Checked, chkKontaktPersonen.Checked, chkSachwalter.Checked, chkAerzte.Checked,chkRegelungen.Checked,chkPflegestufe.Checked,chkKostentraeger .Checked,chkVerwahrung.Checked,chkHilfsmittel.Checked,chkDienstleister.Checked,chkReha.Checked );
                                               
        }
       
    }
}
