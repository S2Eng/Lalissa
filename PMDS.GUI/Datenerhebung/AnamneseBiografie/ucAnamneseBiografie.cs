using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinMaskedEdit;
using Infragistics.Win.UltraWinTabControl;
using PMDS.GUI.BaseControls;
using PMDS.Global;
using PMDS.BusinessLogic;
using PMDS.Data.Patient;
using PMDS.Data.PflegePlan;
using PMDS.Klient;



namespace PMDS.GUI
{


    public partial class ucAnamneseBiografie : ucAnamneseBase
    {

        public PMDS.GUI.VB.ucBiografie ucBiographie1 = new PMDS.GUI.VB.ucBiografie();


        public ucAnamneseBiografie()
        {
            InitializeComponent();

            if (DesignMode || !ENV.AppRunning)
            {
                return;
            }

            this.panelBiographie.Controls.Add(this.ucBiographie1);
            Modell = PflegeModelle.Biografie ;
            EntyText = QS2.Desktop.ControlManagment.ControlManagment.getRes("Biografie");

            AnamneseObject = new AnamneseBiografie ();
            this.ucBiographie1.loadForm();
            //this.ucBiographie1.loadDatenFürPatient();
            
        }

        private Guid _IDPatient = Guid.Empty; 
        public override Guid IDPatient
        {
            get { return _IDPatient; }
            set
            {
                _IDPatient = value;
                ucBiographie1.IDPatient = value;
            }
            
        }
        public void  loadDatenFürPatient()
        {
            this.ucBiographie1.loadDatenFürPatient();
        }

        public override bool ISTOSAVE
        {
            get { return ucBiographie1.ISTOSAVE; }
            set { ucBiographie1.ISTOSAVE = value; }
        }
        public override void Save()
        {          
            ucBiographie1.saveFormular() ;
        }
        


        private void ucAnamneseKrohwinkel2_Load(object sender, EventArgs e)
        {
            if (DesignMode)
                return;

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Daten-Änderung signalisieren
        /// </summary>
        //----------------------------------------------------------------------------
        //protected void Control_ValueChanged(object sender, EventArgs e)
        //{
        //    OnValueChanged(sender, e);
        //}

        private void panelBiografie_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucAnamneseBiografie_Resize(object sender, EventArgs e)
        {
            this.ucBiographie1.resizeForm(this.panelBiographie.Width, this.panelBiographie.Height);
        }

        public void resizeForm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.ucBiographie1.resizeForm(this.panelBiographie.Width, this.panelBiographie.Height);
        }

        private void ucAnamneseBiografie_DataChanged(bool isDataChanged)
        {
            base._dataChanged = isDataChanged;
        }      
    }
}
