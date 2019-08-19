//----------------------------------------------------------------------------
/// <summary>
///	ucAbteilungBereichSelektor.cs
/// Erstellt am:    14.6.2007
/// Erstellt von:	RBU
/// Combo mit Auswahl von Abteilung/Bereich
/// </summary>
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PMDS.GUI.BaseControls
{
    public partial class ucAbteilungBereichSelektor : QS2.Desktop.ControlManagment.BaseControl
    {

        public event GroupDelegate SelectionChanged;

        //----------------------------------------------------------------------------
        /// <summary>
        /// Default Konstruktor
        /// </summary>
        //----------------------------------------------------------------------------
        public ucAbteilungBereichSelektor()
        {
            InitializeComponent();
            ucPatientGroup1.SelectionChanged += new GroupDelegate(ucPatientGroup1_SelectionChanged);
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Tree Auswahl verändert
        /// </summary>
        //----------------------------------------------------------------------------
        void ucPatientGroup1_SelectionChanged(object sender, PatientGroupSelection args)
        {
            RefreshText();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Doppelklick ist die Auswahl an sich
        /// </summary>
        //----------------------------------------------------------------------------
        private void ucPatientGroup1_DoubleClick(object sender, EventArgs e)
        {
            ultraDropDownButton1.Focus();
        }


        //----------------------------------------------------------------------------
        /// <summary>
        /// Button Text aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void RefreshText()
        {
            ultraDropDownButton1.Text = "";

            if (ucPatientGroup1.CurrentSelection.Abteilung == Guid.Empty)
                return;
            StringBuilder sb = new StringBuilder();
            sb.Append(ucPatientGroup1.CurrentSelection.SAbteilung);
            if (ucPatientGroup1.CurrentSelection.Bereich != Guid.Empty)
            {
                sb.Append("->");
                sb.Append(ucPatientGroup1.CurrentSelection.SBereich);
            }

            ultraDropDownButton1.Text = sb.ToString();
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Beim Verlassen den Text aktualisieren
        /// </summary>
        //----------------------------------------------------------------------------
        private void ultraDropDownButton1_ClosedUp(object sender, EventArgs e)
        {
            RefreshText();
            if (SelectionChanged != null)
                SelectionChanged(this, ucPatientGroup1.CurrentSelection);

        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Signalisiert ob eine Abteilung gewählt wurde oder nicht
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsAbteilungSelected
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.Abteilung != Guid.Empty;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Signalisiert ob eine Abteilung gewählt wurde oder nicht
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsBereichSelected
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.Bereich != Guid.Empty;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Abteilung ID
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDAbteilung
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.Abteilung;
            }
            set
            {
                ucPatientGroup1.SetAbteilungBereich(value, Guid.Empty);
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bereich ID
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDBereich
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.Bereich;
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Guid IDKlinik
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.IDKlinik;
            }
        }
        //----------------------------------------------------------------------------
        /// <summary>
        /// Abteilung String
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string AbteilungText
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.SAbteilung;
            }
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Bereich String
        /// </summary>
        //----------------------------------------------------------------------------
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string BereichText
        {
            get
            {
                return ucPatientGroup1.CurrentSelection.SBereich;
            }
        }

        private void ultraDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void ucPatientGroup1_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void ultraPopupControlContainer1_Opened(object sender, EventArgs e)
        {
            
            ucPatientGroup1.Focus();
        }

        private void ucAbteilungBereichSelektor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void ucPatientGroup1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Return)
                ultraDropDownButton1.Focus();
        }

       
    }
}
